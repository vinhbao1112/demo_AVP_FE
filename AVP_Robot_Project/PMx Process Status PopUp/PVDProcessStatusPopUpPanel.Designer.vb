<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDProcessStatusPopUpPanel
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.tableContainer = New System.Windows.Forms.TableLayoutPanel
        Me.lblTargetForwardPower = New System.Windows.Forms.Label
        Me.lblTargetReflectivePower = New System.Windows.Forms.Label
        Me.lblTargetReflectiveVoltage = New System.Windows.Forms.Label
        Me.lblVoltage = New System.Windows.Forms.Label
        Me.lblCurrent = New System.Windows.Forms.Label
        Me.lblPulse = New System.Windows.Forms.Label
        Me.lblBiasForwardPower = New System.Windows.Forms.Label
        Me.lblBiasReflectedPower = New System.Windows.Forms.Label
        Me.lblMGInformation = New System.Windows.Forms.Label
        Me.lblBAPressure = New System.Windows.Forms.Label
        Me.lblheaterz1 = New System.Windows.Forms.Label
        Me.lblheaterz2 = New System.Windows.Forms.Label
        Me.lblGas1 = New System.Windows.Forms.Label
        Me.lblGas2 = New System.Windows.Forms.Label
        Me.lblGas3 = New System.Windows.Forms.Label
        Me.lblGas4 = New System.Windows.Forms.Label
        Me.lblChuck = New System.Windows.Forms.Label
        Me.lblMagnatron = New System.Windows.Forms.Label
        Me.lblClamp = New System.Windows.Forms.Label
        Me.txtheaterz1RB = New AVP_Robot_Project.SL_Textbox
        Me.txtheaterz2RB = New AVP_Robot_Project.SL_Textbox
        Me.txtheaterz1SP = New AVP_Robot_Project.SL_Textbox
        Me.txtheaterz2SP = New AVP_Robot_Project.SL_Textbox
        Me.txtTargetForwardPowerRB = New AVP_Robot_Project.SL_Textbox
        Me.txtTargetForwardPowerSP = New AVP_Robot_Project.SL_Textbox
        Me.txtTargetReflectivePowerRB = New AVP_Robot_Project.SL_Textbox
        Me.txtTargetReflectivePowerSP = New AVP_Robot_Project.SL_Textbox
        Me.txtTargetReflectiveVoltageRB = New AVP_Robot_Project.SL_Textbox
        Me.txtTargetReflectiveVoltageSP = New AVP_Robot_Project.SL_Textbox
        Me.txtVoltageRB = New AVP_Robot_Project.SL_Textbox
        Me.txtVoltageSP = New AVP_Robot_Project.SL_Textbox
        Me.txtCurrentRB = New AVP_Robot_Project.SL_Textbox
        Me.txtCurrentSP = New AVP_Robot_Project.SL_Textbox
        Me.txtPulseRB = New AVP_Robot_Project.SL_Textbox
        Me.txtPulseSP = New AVP_Robot_Project.SL_Textbox
        Me.txtBiasForwardPowerRB = New AVP_Robot_Project.SL_Textbox
        Me.txtBiasForwardPowerSP = New AVP_Robot_Project.SL_Textbox
        Me.txtBiasReflectedPowerRB = New AVP_Robot_Project.SL_Textbox
        Me.txtMGRB = New AVP_Robot_Project.SL_Textbox
        Me.txtBARB = New AVP_Robot_Project.SL_Textbox
        Me.txtGas1RB = New AVP_Robot_Project.SL_Textbox
        Me.txtGas1SP = New AVP_Robot_Project.SL_Textbox
        Me.txtGas2RB = New AVP_Robot_Project.SL_Textbox
        Me.txtGas2SP = New AVP_Robot_Project.SL_Textbox
        Me.txtGas3RB = New AVP_Robot_Project.SL_Textbox
        Me.txtGas3SP = New AVP_Robot_Project.SL_Textbox
        Me.txtGas4RB = New AVP_Robot_Project.SL_Textbox
        Me.txtGas4SP = New AVP_Robot_Project.SL_Textbox
        Me.txtChuckSP = New AVP_Robot_Project.SL_Textbox
        Me.txtChuckRB = New AVP_Robot_Project.SL_Textbox
        Me.txtMagnatronRB = New AVP_Robot_Project.SL_Textbox
        Me.txtClampRB = New AVP_Robot_Project.SL_Textbox
        Me.txtRoughToPressure = New AVP_Robot_Project.SL_Textbox
        Me.txtStartUpTemp = New AVP_Robot_Project.SL_Textbox
        Me.FormContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.tableContainer)
        Me.FormContainer.Controls.Add(Me.Label2)
        Me.FormContainer.Location = New System.Drawing.Point(5, 30)
        Me.FormContainer.Size = New System.Drawing.Size(365, 395)
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(365, 3)
        Me.Label2.TabIndex = 80
        '
        'tableContainer
        '
        Me.tableContainer.BackColor = System.Drawing.Color.Transparent
        Me.tableContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.tableContainer.ColumnCount = 3
        Me.tableContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tableContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tableContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.tableContainer.Location = New System.Drawing.Point(0, 3)
        Me.tableContainer.Name = "tableContainer"
        Me.tableContainer.RowCount = 15
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.Size = New System.Drawing.Size(352, 463)
        Me.tableContainer.TabIndex = 81
        '
        'lblTargetForwardPower
        '
        Me.lblTargetForwardPower.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTargetForwardPower.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetForwardPower.Location = New System.Drawing.Point(5, 2)
        Me.lblTargetForwardPower.Name = "lblTargetForwardPower"
        Me.lblTargetForwardPower.Size = New System.Drawing.Size(220, 30)
        Me.lblTargetForwardPower.TabIndex = 75
        Me.lblTargetForwardPower.Text = "Target Fwd Power (W)"
        Me.lblTargetForwardPower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTargetReflectivePower
        '
        Me.lblTargetReflectivePower.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTargetReflectivePower.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetReflectivePower.Location = New System.Drawing.Point(5, 34)
        Me.lblTargetReflectivePower.Name = "lblTargetReflectivePower"
        Me.lblTargetReflectivePower.Size = New System.Drawing.Size(220, 30)
        Me.lblTargetReflectivePower.TabIndex = 108
        Me.lblTargetReflectivePower.Text = "Target Ref Power (W)"
        Me.lblTargetReflectivePower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTargetReflectiveVoltage
        '
        Me.lblTargetReflectiveVoltage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTargetReflectiveVoltage.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetReflectiveVoltage.Location = New System.Drawing.Point(5, 66)
        Me.lblTargetReflectiveVoltage.Name = "lblTargetReflectiveVoltage"
        Me.lblTargetReflectiveVoltage.Size = New System.Drawing.Size(220, 30)
        Me.lblTargetReflectiveVoltage.TabIndex = 113
        Me.lblTargetReflectiveVoltage.Text = "Target Voltage (V)"
        Me.lblTargetReflectiveVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVoltage
        '
        Me.lblVoltage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblVoltage.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoltage.Location = New System.Drawing.Point(5, 98)
        Me.lblVoltage.Name = "lblVoltage"
        Me.lblVoltage.Size = New System.Drawing.Size(220, 30)
        Me.lblVoltage.TabIndex = 114
        Me.lblVoltage.Text = "Target Voltage (V)"
        Me.lblVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCurrent
        '
        Me.lblCurrent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCurrent.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrent.Location = New System.Drawing.Point(5, 130)
        Me.lblCurrent.Name = "lblCurrent"
        Me.lblCurrent.Size = New System.Drawing.Size(220, 30)
        Me.lblCurrent.TabIndex = 122
        Me.lblCurrent.Text = "Target Current (A)"
        Me.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPulse
        '
        Me.lblPulse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPulse.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPulse.Location = New System.Drawing.Point(5, 162)
        Me.lblPulse.Name = "lblPulse"
        Me.lblPulse.Size = New System.Drawing.Size(220, 30)
        Me.lblPulse.TabIndex = 121
        Me.lblPulse.Text = "Target Pulse Mode"
        Me.lblPulse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBiasForwardPower
        '
        Me.lblBiasForwardPower.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBiasForwardPower.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBiasForwardPower.Location = New System.Drawing.Point(5, 195)
        Me.lblBiasForwardPower.Name = "lblBiasForwardPower"
        Me.lblBiasForwardPower.Size = New System.Drawing.Size(220, 30)
        Me.lblBiasForwardPower.TabIndex = 76
        Me.lblBiasForwardPower.Text = "Bias Fwd Power (W)"
        Me.lblBiasForwardPower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBiasReflectedPower
        '
        Me.lblBiasReflectedPower.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBiasReflectedPower.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBiasReflectedPower.Location = New System.Drawing.Point(5, 227)
        Me.lblBiasReflectedPower.Name = "lblBiasReflectedPower"
        Me.lblBiasReflectedPower.Size = New System.Drawing.Size(220, 30)
        Me.lblBiasReflectedPower.TabIndex = 77
        Me.lblBiasReflectedPower.Text = "Bias Ref Power (W)"
        Me.lblBiasReflectedPower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMGInformation
        '
        Me.lblMGInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMGInformation.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMGInformation.Location = New System.Drawing.Point(5, 259)
        Me.lblMGInformation.Name = "lblMGInformation"
        Me.lblMGInformation.Size = New System.Drawing.Size(220, 30)
        Me.lblMGInformation.TabIndex = 78
        Me.lblMGInformation.Text = "Backside Pressure"
        Me.lblMGInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBAPressure
        '
        Me.lblBAPressure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBAPressure.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBAPressure.Location = New System.Drawing.Point(5, 291)
        Me.lblBAPressure.Name = "lblBAPressure"
        Me.lblBAPressure.Size = New System.Drawing.Size(220, 30)
        Me.lblBAPressure.TabIndex = 79
        Me.lblBAPressure.Text = "Baratron Gauge (mT)"
        Me.lblBAPressure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGas1
        '
        Me.lblGas1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGas1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas1.Location = New System.Drawing.Point(5, 323)
        Me.lblGas1.Name = "lblGas1"
        Me.lblGas1.Size = New System.Drawing.Size(220, 30)
        Me.lblGas1.TabIndex = 96
        Me.lblGas1.Text = "Gas1 (sccm)"
        Me.lblGas1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGas2
        '
        Me.lblGas2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGas2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas2.Location = New System.Drawing.Point(5, 356)
        Me.lblGas2.Name = "lblGas2"
        Me.lblGas2.Size = New System.Drawing.Size(220, 30)
        Me.lblGas2.TabIndex = 99
        Me.lblGas2.Text = "Gas2 (sccm)"
        Me.lblGas2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGas3
        '
        Me.lblGas3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGas3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas3.Location = New System.Drawing.Point(5, 388)
        Me.lblGas3.Name = "lblGas3"
        Me.lblGas3.Size = New System.Drawing.Size(220, 30)
        Me.lblGas3.TabIndex = 80
        Me.lblGas3.Text = "Gas3 (sccm)"
        Me.lblGas3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGas4
        '
        Me.lblGas4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGas4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas4.Location = New System.Drawing.Point(5, 420)
        Me.lblGas4.Name = "lblGas4"
        Me.lblGas4.Size = New System.Drawing.Size(220, 30)
        Me.lblGas4.TabIndex = 93
        Me.lblGas4.Text = "Gas4 (sccm)"
        Me.lblGas4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChuck
        '
        Me.lblChuck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChuck.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChuck.Location = New System.Drawing.Point(5, 452)
        Me.lblChuck.Name = "lblChuck"
        Me.lblChuck.Size = New System.Drawing.Size(220, 30)
        Me.lblChuck.TabIndex = 116
        Me.lblChuck.Text = "Chuck Pos. (inch)"
        Me.lblChuck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMagnatron
        '
        Me.lblMagnatron.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMagnatron.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMagnatron.Location = New System.Drawing.Point(5, 483)
        Me.lblMagnatron.Name = "lblMagnatron"
        Me.lblMagnatron.Size = New System.Drawing.Size(220, 29)
        Me.lblMagnatron.TabIndex = 102
        Me.lblMagnatron.Text = "Magnetron Rotation"
        Me.lblMagnatron.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblClamp
        '
        Me.lblClamp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblClamp.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClamp.Location = New System.Drawing.Point(5, 514)
        Me.lblClamp.Name = "lblClamp"
        Me.lblClamp.Size = New System.Drawing.Size(220, 30)
        Me.lblClamp.TabIndex = 105
        Me.lblClamp.Text = "Clamp Status"
        Me.lblClamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblheaterz1
        '
        Me.lblheaterz1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblheaterz1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheaterz1.Location = New System.Drawing.Point(5, 535)
        Me.lblheaterz1.Name = "lblheaterz1"
        Me.lblheaterz1.Size = New System.Drawing.Size(220, 30)
        Me.lblheaterz1.TabIndex = 105
        Me.lblheaterz1.Text = "Heater Zone 1"
        Me.lblheaterz1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblheaterz2
        '
        Me.lblheaterz2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblheaterz2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheaterz2.Location = New System.Drawing.Point(5, 556)
        Me.lblheaterz2.Name = "lblheaterz2"
        Me.lblheaterz2.Size = New System.Drawing.Size(220, 30)
        Me.lblheaterz2.TabIndex = 108
        Me.lblheaterz2.Text = "Heater Zone 2"
        Me.lblheaterz2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTargetForwardPowerRB
        '
        Me.txtTargetForwardPowerRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTargetForwardPowerRB.Clickable = False
        Me.txtTargetForwardPowerRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTargetForwardPowerRB.DisplayProcessFont = True
        Me.txtTargetForwardPowerRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTargetForwardPowerRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetForwardPowerRB.IsReadBack = True
        Me.txtTargetForwardPowerRB.Location = New System.Drawing.Point(233, 5)
        Me.txtTargetForwardPowerRB.Name = "txtTargetForwardPowerRB"
        Me.txtTargetForwardPowerRB.ReadOnly = True
        Me.txtTargetForwardPowerRB.Size = New System.Drawing.Size(72, 20)
        Me.txtTargetForwardPowerRB.TabIndex = 81
        Me.txtTargetForwardPowerRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTargetForwardPowerRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTargetForwardPowerRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtTargetForwardPowerRB.UseScientificFormat = True
        '
        'txtTargetForwardPowerSP
        '
        Me.txtTargetForwardPowerSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTargetForwardPowerSP.Clickable = False
        Me.txtTargetForwardPowerSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTargetForwardPowerSP.DisplayProcessFont = True
        Me.txtTargetForwardPowerSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTargetForwardPowerSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetForwardPowerSP.IsNumericTextbox = True
        Me.txtTargetForwardPowerSP.IsReadBack = True
        Me.txtTargetForwardPowerSP.Location = New System.Drawing.Point(313, 5)
        Me.txtTargetForwardPowerSP.Name = "txtTargetForwardPowerSP"
        Me.txtTargetForwardPowerSP.ReadOnly = True
        Me.txtTargetForwardPowerSP.Size = New System.Drawing.Size(69, 20)
        Me.txtTargetForwardPowerSP.TabIndex = 87
        Me.txtTargetForwardPowerSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTargetForwardPowerSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTargetForwardPowerSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtTargetReflectivePowerRB
        '
        Me.txtTargetReflectivePowerRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTargetReflectivePowerRB.Clickable = False
        Me.txtTargetReflectivePowerRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTargetReflectivePowerRB.DisplayProcessFont = True
        Me.txtTargetReflectivePowerRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTargetReflectivePowerRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetReflectivePowerRB.IsReadBack = True
        Me.txtTargetReflectivePowerRB.Location = New System.Drawing.Point(233, 37)
        Me.txtTargetReflectivePowerRB.Name = "txtTargetReflectivePowerRB"
        Me.txtTargetReflectivePowerRB.ReadOnly = True
        Me.txtTargetReflectivePowerRB.Size = New System.Drawing.Size(72, 20)
        Me.txtTargetReflectivePowerRB.TabIndex = 109
        Me.txtTargetReflectivePowerRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTargetReflectivePowerRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTargetReflectivePowerRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtTargetReflectivePowerRB.UseScientificFormat = True
        '
        'txtTargetReflectivePowerSP
        '
        Me.txtTargetReflectivePowerSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTargetReflectivePowerSP.Clickable = False
        Me.txtTargetReflectivePowerSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTargetReflectivePowerSP.DisplayProcessFont = True
        Me.txtTargetReflectivePowerSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTargetReflectivePowerSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetReflectivePowerSP.IsReadBack = True
        Me.txtTargetReflectivePowerSP.Location = New System.Drawing.Point(313, 37)
        Me.txtTargetReflectivePowerSP.Name = "txtTargetReflectivePowerSP"
        Me.txtTargetReflectivePowerSP.ReadOnly = True
        Me.txtTargetReflectivePowerSP.Size = New System.Drawing.Size(69, 20)
        Me.txtTargetReflectivePowerSP.TabIndex = 124
        Me.txtTargetReflectivePowerSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTargetReflectivePowerSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTargetReflectivePowerSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtTargetReflectivePowerSP.UseScientificFormat = True
        Me.txtTargetReflectivePowerSP.Visible = False
        '
        'txtTargetReflectiveVoltageRB
        '
        Me.txtTargetReflectiveVoltageRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTargetReflectiveVoltageRB.Clickable = False
        Me.txtTargetReflectiveVoltageRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTargetReflectiveVoltageRB.DisplayProcessFont = True
        Me.txtTargetReflectiveVoltageRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTargetReflectiveVoltageRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetReflectiveVoltageRB.IsReadBack = True
        Me.txtTargetReflectiveVoltageRB.Location = New System.Drawing.Point(233, 69)
        Me.txtTargetReflectiveVoltageRB.Name = "txtTargetReflectiveVoltageRB"
        Me.txtTargetReflectiveVoltageRB.ReadOnly = True
        Me.txtTargetReflectiveVoltageRB.Size = New System.Drawing.Size(72, 20)
        Me.txtTargetReflectiveVoltageRB.TabIndex = 112
        Me.txtTargetReflectiveVoltageRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTargetReflectiveVoltageRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTargetReflectiveVoltageRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtTargetReflectiveVoltageRB.UseScientificFormat = True
        '
        'txtTargetReflectiveVoltageSP
        '
        Me.txtTargetReflectiveVoltageSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTargetReflectiveVoltageSP.Clickable = False
        Me.txtTargetReflectiveVoltageSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTargetReflectiveVoltageSP.DisplayProcessFont = True
        Me.txtTargetReflectiveVoltageSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTargetReflectiveVoltageSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtTargetReflectiveVoltageSP.IsReadBack = True
        Me.txtTargetReflectiveVoltageSP.Location = New System.Drawing.Point(313, 69)
        Me.txtTargetReflectiveVoltageSP.Name = "txtTargetReflectiveVoltageSP"
        Me.txtTargetReflectiveVoltageSP.ReadOnly = True
        Me.txtTargetReflectiveVoltageSP.Size = New System.Drawing.Size(69, 20)
        Me.txtTargetReflectiveVoltageSP.TabIndex = 111
        Me.txtTargetReflectiveVoltageSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTargetReflectiveVoltageSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTargetReflectiveVoltageSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtTargetReflectiveVoltageSP.UseScientificFormat = True
        Me.txtTargetReflectiveVoltageSP.Visible = False
        '
        'txtVoltageRB
        '
        Me.txtVoltageRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVoltageRB.Clickable = False
        Me.txtVoltageRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtVoltageRB.DisplayProcessFont = True
        Me.txtVoltageRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVoltageRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtVoltageRB.IsReadBack = True
        Me.txtVoltageRB.Location = New System.Drawing.Point(233, 101)
        Me.txtVoltageRB.Name = "txtVoltageRB"
        Me.txtVoltageRB.ReadOnly = True
        Me.txtVoltageRB.Size = New System.Drawing.Size(72, 20)
        Me.txtVoltageRB.TabIndex = 115
        Me.txtVoltageRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtVoltageRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtVoltageRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtVoltageRB.UseScientificFormat = True
        '
        'txtVoltageSP
        '
        Me.txtVoltageSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVoltageSP.Clickable = False
        Me.txtVoltageSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtVoltageSP.DisplayProcessFont = True
        Me.txtVoltageSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVoltageSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtVoltageSP.IsReadBack = True
        Me.txtVoltageSP.Location = New System.Drawing.Point(313, 101)
        Me.txtVoltageSP.Name = "txtVoltageSP"
        Me.txtVoltageSP.ReadOnly = True
        Me.txtVoltageSP.Size = New System.Drawing.Size(69, 20)
        Me.txtVoltageSP.TabIndex = 123
        Me.txtVoltageSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtVoltageSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtVoltageSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtVoltageSP.UseScientificFormat = True
        '
        'txtCurrentRB
        '
        Me.txtCurrentRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCurrentRB.Clickable = False
        Me.txtCurrentRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCurrentRB.DisplayProcessFont = True
        Me.txtCurrentRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCurrentRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentRB.IsReadBack = True
        Me.txtCurrentRB.Location = New System.Drawing.Point(233, 133)
        Me.txtCurrentRB.Name = "txtCurrentRB"
        Me.txtCurrentRB.ReadOnly = True
        Me.txtCurrentRB.Size = New System.Drawing.Size(72, 20)
        Me.txtCurrentRB.TabIndex = 126
        Me.txtCurrentRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCurrentRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCurrentRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtCurrentRB.UseScientificFormat = True
        '
        'txtCurrentSP
        '
        Me.txtCurrentSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCurrentSP.Clickable = False
        Me.txtCurrentSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCurrentSP.DisplayProcessFont = True
        Me.txtCurrentSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCurrentSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentSP.IsReadBack = True
        Me.txtCurrentSP.Location = New System.Drawing.Point(313, 133)
        Me.txtCurrentSP.Name = "txtCurrentSP"
        Me.txtCurrentSP.ReadOnly = True
        Me.txtCurrentSP.Size = New System.Drawing.Size(69, 20)
        Me.txtCurrentSP.TabIndex = 125
        Me.txtCurrentSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCurrentSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCurrentSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtCurrentSP.UseScientificFormat = True
        '
        'txtPulseRB
        '
        Me.txtPulseRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPulseRB.Clickable = False
        Me.txtPulseRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPulseRB.DisplayProcessFont = True
        Me.txtPulseRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPulseRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtPulseRB.IsReadBack = True
        Me.txtPulseRB.Location = New System.Drawing.Point(233, 165)
        Me.txtPulseRB.Name = "txtPulseRB"
        Me.txtPulseRB.ReadOnly = True
        Me.txtPulseRB.Size = New System.Drawing.Size(72, 20)
        Me.txtPulseRB.TabIndex = 128
        Me.txtPulseRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPulseRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPulseRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPulseRB.UseScientificFormat = True
        '
        'txtPulseSP
        '
        Me.txtPulseSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPulseSP.Clickable = False
        Me.txtPulseSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPulseSP.DisplayProcessFont = True
        Me.txtPulseSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPulseSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtPulseSP.IsReadBack = True
        Me.txtPulseSP.Location = New System.Drawing.Point(313, 165)
        Me.txtPulseSP.Name = "txtPulseSP"
        Me.txtPulseSP.ReadOnly = True
        Me.txtPulseSP.Size = New System.Drawing.Size(69, 20)
        Me.txtPulseSP.TabIndex = 127
        Me.txtPulseSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPulseSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPulseSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPulseSP.UseScientificFormat = True
        '
        'txtBiasForwardPowerRB
        '
        Me.txtBiasForwardPowerRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBiasForwardPowerRB.Clickable = False
        Me.txtBiasForwardPowerRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBiasForwardPowerRB.DisplayProcessFont = True
        Me.txtBiasForwardPowerRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBiasForwardPowerRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtBiasForwardPowerRB.IsReadBack = True
        Me.txtBiasForwardPowerRB.Location = New System.Drawing.Point(233, 198)
        Me.txtBiasForwardPowerRB.Name = "txtBiasForwardPowerRB"
        Me.txtBiasForwardPowerRB.ReadOnly = True
        Me.txtBiasForwardPowerRB.Size = New System.Drawing.Size(72, 20)
        Me.txtBiasForwardPowerRB.TabIndex = 82
        Me.txtBiasForwardPowerRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBiasForwardPowerRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBiasForwardPowerRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtBiasForwardPowerRB.UseScientificFormat = True
        '
        'txtBiasForwardPowerSP
        '
        Me.txtBiasForwardPowerSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBiasForwardPowerSP.Clickable = False
        Me.txtBiasForwardPowerSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBiasForwardPowerSP.DisplayProcessFont = True
        Me.txtBiasForwardPowerSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBiasForwardPowerSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtBiasForwardPowerSP.IsNumericTextbox = True
        Me.txtBiasForwardPowerSP.IsReadBack = True
        Me.txtBiasForwardPowerSP.Location = New System.Drawing.Point(313, 198)
        Me.txtBiasForwardPowerSP.Name = "txtBiasForwardPowerSP"
        Me.txtBiasForwardPowerSP.ReadOnly = True
        Me.txtBiasForwardPowerSP.Size = New System.Drawing.Size(69, 20)
        Me.txtBiasForwardPowerSP.TabIndex = 88
        Me.txtBiasForwardPowerSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBiasForwardPowerSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBiasForwardPowerSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtBiasReflectedPowerRB
        '
        Me.txtBiasReflectedPowerRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBiasReflectedPowerRB.Clickable = False
        Me.txtBiasReflectedPowerRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBiasReflectedPowerRB.DisplayProcessFont = True
        Me.txtBiasReflectedPowerRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBiasReflectedPowerRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtBiasReflectedPowerRB.IsReadBack = True
        Me.txtBiasReflectedPowerRB.Location = New System.Drawing.Point(233, 230)
        Me.txtBiasReflectedPowerRB.Name = "txtBiasReflectedPowerRB"
        Me.txtBiasReflectedPowerRB.ReadOnly = True
        Me.txtBiasReflectedPowerRB.Size = New System.Drawing.Size(72, 20)
        Me.txtBiasReflectedPowerRB.TabIndex = 83
        Me.txtBiasReflectedPowerRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBiasReflectedPowerRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBiasReflectedPowerRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtBiasReflectedPowerRB.UseScientificFormat = True
        '
        'txtMGRB
        '
        Me.txtMGRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMGRB.Clickable = False
        Me.txtMGRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMGRB.DisplayProcessFont = True
        Me.txtMGRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMGRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtMGRB.IsReadBack = True
        Me.txtMGRB.Location = New System.Drawing.Point(233, 262)
        Me.txtMGRB.Name = "txtMGRB"
        Me.txtMGRB.ReadOnly = True
        Me.txtMGRB.Size = New System.Drawing.Size(72, 20)
        Me.txtMGRB.TabIndex = 84
        Me.txtMGRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMGRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtMGRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtMGRB.UseScientificFormat = True
        '
        'txtBARB
        '
        Me.txtBARB.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtBARB.Clickable = False
        Me.txtBARB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBARB.DisplayPressureFont = True
        Me.txtBARB.DisplayProcessFont = True
        Me.txtBARB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBARB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtBARB.ForeColor = System.Drawing.Color.Lime
        Me.txtBARB.IsReadBack = True
        Me.txtBARB.Location = New System.Drawing.Point(233, 294)
        Me.txtBARB.Name = "txtBARB"
        Me.txtBARB.ReadOnly = True
        Me.txtBARB.Size = New System.Drawing.Size(72, 20)
        Me.txtBARB.TabIndex = 85
        Me.txtBARB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBARB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBARB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtBARB.UseScientificFormat = True
        '
        'txtGas1RB
        '
        Me.txtGas1RB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas1RB.Clickable = False
        Me.txtGas1RB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas1RB.DisplayProcessFont = True
        Me.txtGas1RB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGas1RB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas1RB.IsReadBack = True
        Me.txtGas1RB.Location = New System.Drawing.Point(233, 326)
        Me.txtGas1RB.Name = "txtGas1RB"
        Me.txtGas1RB.ReadOnly = True
        Me.txtGas1RB.Size = New System.Drawing.Size(72, 20)
        Me.txtGas1RB.TabIndex = 97
        Me.txtGas1RB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGas1RB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas1RB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtGas1RB.UseScientificFormat = True
        '
        'txtGas1SP
        '
        Me.txtGas1SP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas1SP.Clickable = False
        Me.txtGas1SP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas1SP.DisplayProcessFont = True
        Me.txtGas1SP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGas1SP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas1SP.IsNumericTextbox = True
        Me.txtGas1SP.IsReadBack = True
        Me.txtGas1SP.Location = New System.Drawing.Point(313, 326)
        Me.txtGas1SP.Name = "txtGas1SP"
        Me.txtGas1SP.ReadOnly = True
        Me.txtGas1SP.Size = New System.Drawing.Size(69, 20)
        Me.txtGas1SP.TabIndex = 98
        Me.txtGas1SP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGas1SP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas1SP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas2RB
        '
        Me.txtGas2RB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas2RB.Clickable = False
        Me.txtGas2RB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas2RB.DisplayProcessFont = True
        Me.txtGas2RB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGas2RB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas2RB.IsReadBack = True
        Me.txtGas2RB.Location = New System.Drawing.Point(233, 359)
        Me.txtGas2RB.Name = "txtGas2RB"
        Me.txtGas2RB.ReadOnly = True
        Me.txtGas2RB.Size = New System.Drawing.Size(72, 20)
        Me.txtGas2RB.TabIndex = 100
        Me.txtGas2RB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGas2RB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas2RB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtGas2RB.UseScientificFormat = True
        '
        'txtGas2SP
        '
        Me.txtGas2SP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas2SP.Clickable = False
        Me.txtGas2SP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas2SP.DisplayProcessFont = True
        Me.txtGas2SP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGas2SP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas2SP.IsNumericTextbox = True
        Me.txtGas2SP.IsReadBack = True
        Me.txtGas2SP.Location = New System.Drawing.Point(313, 359)
        Me.txtGas2SP.Name = "txtGas2SP"
        Me.txtGas2SP.ReadOnly = True
        Me.txtGas2SP.Size = New System.Drawing.Size(69, 20)
        Me.txtGas2SP.TabIndex = 101
        Me.txtGas2SP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGas2SP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas2SP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas3RB
        '
        Me.txtGas3RB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas3RB.Clickable = False
        Me.txtGas3RB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas3RB.DisplayProcessFont = True
        Me.txtGas3RB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGas3RB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas3RB.IsReadBack = True
        Me.txtGas3RB.Location = New System.Drawing.Point(233, 391)
        Me.txtGas3RB.Name = "txtGas3RB"
        Me.txtGas3RB.ReadOnly = True
        Me.txtGas3RB.Size = New System.Drawing.Size(72, 20)
        Me.txtGas3RB.TabIndex = 86
        Me.txtGas3RB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGas3RB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas3RB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtGas3RB.UseScientificFormat = True
        '
        'txtGas3SP
        '
        Me.txtGas3SP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas3SP.Clickable = False
        Me.txtGas3SP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas3SP.DisplayProcessFont = True
        Me.txtGas3SP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGas3SP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas3SP.IsNumericTextbox = True
        Me.txtGas3SP.IsReadBack = True
        Me.txtGas3SP.Location = New System.Drawing.Point(313, 391)
        Me.txtGas3SP.Name = "txtGas3SP"
        Me.txtGas3SP.ReadOnly = True
        Me.txtGas3SP.Size = New System.Drawing.Size(69, 20)
        Me.txtGas3SP.TabIndex = 119
        Me.txtGas3SP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGas3SP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas3SP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtGas4RB
        '
        Me.txtGas4RB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas4RB.Clickable = False
        Me.txtGas4RB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas4RB.DisplayProcessFont = True
        Me.txtGas4RB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGas4RB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas4RB.IsReadBack = True
        Me.txtGas4RB.Location = New System.Drawing.Point(233, 423)
        Me.txtGas4RB.Name = "txtGas4RB"
        Me.txtGas4RB.ReadOnly = True
        Me.txtGas4RB.Size = New System.Drawing.Size(72, 20)
        Me.txtGas4RB.TabIndex = 94
        Me.txtGas4RB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGas4RB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas4RB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtGas4RB.UseScientificFormat = True
        '
        'txtGas4SP
        '
        Me.txtGas4SP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas4SP.Clickable = False
        Me.txtGas4SP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas4SP.DisplayProcessFont = True
        Me.txtGas4SP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGas4SP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas4SP.IsNumericTextbox = True
        Me.txtGas4SP.IsReadBack = True
        Me.txtGas4SP.Location = New System.Drawing.Point(313, 423)
        Me.txtGas4SP.Name = "txtGas4SP"
        Me.txtGas4SP.ReadOnly = True
        Me.txtGas4SP.Size = New System.Drawing.Size(69, 20)
        Me.txtGas4SP.TabIndex = 120
        Me.txtGas4SP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGas4SP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas4SP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtChuckSP
        '
        Me.txtChuckSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtChuckSP.Clickable = False
        Me.txtChuckSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtChuckSP.DisplayProcessFont = True
        Me.txtChuckSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChuckSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtChuckSP.IsReadBack = True
        Me.txtChuckSP.Location = New System.Drawing.Point(313, 455)
        Me.txtChuckSP.Name = "txtChuckSP"
        Me.txtChuckSP.ReadOnly = True
        Me.txtChuckSP.Size = New System.Drawing.Size(69, 20)
        Me.txtChuckSP.TabIndex = 117
        Me.txtChuckSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtChuckSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtChuckSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtChuckSP.UseScientificFormat = True
        '
        'txtChuckRB
        '
        Me.txtChuckRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtChuckRB.Clickable = False
        Me.txtChuckRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtChuckRB.DisplayProcessFont = True
        Me.txtChuckRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChuckRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtChuckRB.IsReadBack = True
        Me.txtChuckRB.Location = New System.Drawing.Point(233, 455)
        Me.txtChuckRB.Name = "txtChuckRB"
        Me.txtChuckRB.ReadOnly = True
        Me.txtChuckRB.Size = New System.Drawing.Size(72, 20)
        Me.txtChuckRB.TabIndex = 118
        Me.txtChuckRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtChuckRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtChuckRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtChuckRB.UseScientificFormat = True
        '
        'txtMagnatronRB
        '
        Me.txtMagnatronRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMagnatronRB.Clickable = False
        Me.txtMagnatronRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMagnatronRB.DisplayProcessFont = True
        Me.txtMagnatronRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMagnatronRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtMagnatronRB.IsReadBack = True
        Me.txtMagnatronRB.Location = New System.Drawing.Point(233, 486)
        Me.txtMagnatronRB.Name = "txtMagnatronRB"
        Me.txtMagnatronRB.ReadOnly = True
        Me.txtMagnatronRB.Size = New System.Drawing.Size(72, 20)
        Me.txtMagnatronRB.TabIndex = 103
        Me.txtMagnatronRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMagnatronRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtMagnatronRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtMagnatronRB.UseScientificFormat = True
        '
        'txtClampRB
        '
        Me.txtClampRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtClampRB.Clickable = False
        Me.txtClampRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtClampRB.DisplayProcessFont = True
        Me.txtClampRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtClampRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtClampRB.IsReadBack = True
        Me.txtClampRB.Location = New System.Drawing.Point(233, 517)
        Me.txtClampRB.Name = "txtClampRB"
        Me.txtClampRB.ReadOnly = True
        Me.txtClampRB.Size = New System.Drawing.Size(72, 20)
        Me.txtClampRB.TabIndex = 106
        Me.txtClampRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtClampRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtClampRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtClampRB.UseScientificFormat = True
        '
        'txtheaterz1RB
        '
        Me.txtheaterz1RB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtheaterz1RB.Clickable = False
        Me.txtheaterz1RB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtheaterz1RB.DisplayProcessFont = True
        Me.txtheaterz1RB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtheaterz1RB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtheaterz1RB.IsReadBack = True
        Me.txtheaterz1RB.Location = New System.Drawing.Point(233, 535)
        Me.txtheaterz1RB.MinimumValueHighlightedGreen = 0
        Me.txtheaterz1RB.Name = "txtheaterz1RB"
        Me.txtheaterz1RB.ReadOnly = True
        Me.txtheaterz1RB.Size = New System.Drawing.Size(72, 20)
        Me.txtheaterz1RB.TabIndex = 97
        Me.txtheaterz1RB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtheaterz1RB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtheaterz1RB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtheaterz1RB.UseScientificFormat = True
        '
        'txtheaterz1SP
        '
        Me.txtheaterz1SP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtheaterz1SP.Clickable = False
        Me.txtheaterz1SP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtheaterz1SP.DisplayProcessFont = True
        Me.txtheaterz1SP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtheaterz1SP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtheaterz1SP.IsNumericTextbox = True
        Me.txtheaterz1SP.IsReadBack = True
        Me.txtheaterz1SP.Location = New System.Drawing.Point(313, 445)
        Me.txtheaterz1SP.MinimumValueHighlightedGreen = 0
        Me.txtheaterz1SP.Name = "txtheaterz1SP"
        Me.txtheaterz1SP.ReadOnly = True
        Me.txtheaterz1SP.Size = New System.Drawing.Size(69, 20)
        Me.txtheaterz1SP.TabIndex = 87
        Me.txtheaterz1SP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtheaterz1SP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtheaterz1SP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtheaterz2RB
        '
        Me.txtheaterz2RB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtheaterz2RB.Clickable = False
        Me.txtheaterz2RB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtheaterz2RB.DisplayProcessFont = True
        Me.txtheaterz2RB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtheaterz2RB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtheaterz2RB.IsReadBack = True
        Me.txtheaterz2RB.Location = New System.Drawing.Point(233, 556)
        Me.txtheaterz2RB.MinimumValueHighlightedGreen = 0
        Me.txtheaterz2RB.Name = "txtheaterz2RB"
        Me.txtheaterz2RB.ReadOnly = True
        Me.txtheaterz2RB.Size = New System.Drawing.Size(72, 20)
        Me.txtheaterz2RB.TabIndex = 102
        Me.txtheaterz2RB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtheaterz2RB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtheaterz2RB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtheaterz2RB.UseScientificFormat = True
        '
        'txtheaterz2SP
        '
        Me.txtheaterz2SP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtheaterz2SP.Clickable = False
        Me.txtheaterz2SP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtheaterz2SP.DisplayProcessFont = True
        Me.txtheaterz2SP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtheaterz2SP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtheaterz2SP.IsNumericTextbox = True
        Me.txtheaterz2SP.IsReadBack = True
        Me.txtheaterz2SP.Location = New System.Drawing.Point(313, 476)
        Me.txtheaterz2SP.MinimumValueHighlightedGreen = 0
        Me.txtheaterz2SP.Name = "txtheaterz2SP"
        Me.txtheaterz2SP.ReadOnly = True
        Me.txtheaterz2SP.Size = New System.Drawing.Size(69, 20)
        Me.txtheaterz2SP.TabIndex = 87
        Me.txtheaterz2SP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtheaterz2SP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtheaterz2SP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtRoughToPressure
        '
        Me.txtRoughToPressure.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRoughToPressure.Clickable = False
        Me.txtRoughToPressure.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRoughToPressure.DisplayProcessFont = True
        Me.txtRoughToPressure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRoughToPressure.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtRoughToPressure.IsNumericTextbox = True
        Me.txtRoughToPressure.IsReadBack = True
        Me.txtRoughToPressure.Location = New System.Drawing.Point(293, 101)
        Me.txtRoughToPressure.Name = "txtRoughToPressure"
        Me.txtRoughToPressure.ReadOnly = True
        Me.txtRoughToPressure.Size = New System.Drawing.Size(115, 20)
        Me.txtRoughToPressure.TabIndex = 90
        Me.txtRoughToPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRoughToPressure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRoughToPressure.Visible = False
        '
        'txtStartUpTemp
        '
        Me.txtStartUpTemp.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStartUpTemp.Clickable = False
        Me.txtStartUpTemp.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStartUpTemp.DisplayProcessFont = True
        Me.txtStartUpTemp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStartUpTemp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtStartUpTemp.IsNumericTextbox = True
        Me.txtStartUpTemp.IsReadBack = True
        Me.txtStartUpTemp.Location = New System.Drawing.Point(293, 165)
        Me.txtStartUpTemp.Name = "txtStartUpTemp"
        Me.txtStartUpTemp.ReadOnly = True
        Me.txtStartUpTemp.Size = New System.Drawing.Size(115, 20)
        Me.txtStartUpTemp.TabIndex = 92
        Me.txtStartUpTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtStartUpTemp.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtStartUpTemp.Visible = False
        '
        'PVDProcessStatusPopUpPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(375, 434)
        Me.HeaderHeight = 30
        Me.HeaderStatus = AVPControls.AVPDataLib.DisplayStatus.[On]
        Me.Name = "PVDProcessStatusPopUpPanel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PM Process Status"
        Me.FormContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tableContainer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblGas3 As System.Windows.Forms.Label
    Friend WithEvents lblTargetForwardPower As System.Windows.Forms.Label
    Friend WithEvents lblheaterz1 As System.Windows.Forms.Label
    Friend WithEvents lblheaterz2 As System.Windows.Forms.Label
    Friend WithEvents lblBiasForwardPower As System.Windows.Forms.Label
    Friend WithEvents lblBiasReflectedPower As System.Windows.Forms.Label
    Friend WithEvents lblMGInformation As System.Windows.Forms.Label
    Friend WithEvents lblBAPressure As System.Windows.Forms.Label
    Friend WithEvents txtTargetForwardPowerRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtheaterz1RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtheaterz1SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtheaterz2RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtheaterz2SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBiasForwardPowerRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBiasReflectedPowerRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtMGRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBARB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas3RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblTargetReflectivePower As System.Windows.Forms.Label
    Friend WithEvents txtTargetReflectivePowerRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblClamp As System.Windows.Forms.Label
    Friend WithEvents txtClampRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblMagnatron As System.Windows.Forms.Label
    Friend WithEvents txtMagnatronRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblGas2 As System.Windows.Forms.Label
    Friend WithEvents txtGas2RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas2SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblGas1 As System.Windows.Forms.Label
    Friend WithEvents txtGas1RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas1SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblGas4 As System.Windows.Forms.Label
    Friend WithEvents txtGas4RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtTargetForwardPowerSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBiasForwardPowerSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRoughToPressure As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtStartUpTemp As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblTargetReflectiveVoltage As System.Windows.Forms.Label
    Friend WithEvents txtTargetReflectiveVoltageRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtTargetReflectiveVoltageSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblVoltage As System.Windows.Forms.Label
    Friend WithEvents txtVoltageRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblChuck As System.Windows.Forms.Label
    Friend WithEvents txtChuckRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtChuckSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas3SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas4SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblCurrent As System.Windows.Forms.Label
    Friend WithEvents lblPulse As System.Windows.Forms.Label
    Friend WithEvents txtTargetReflectivePowerSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtVoltageSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtCurrentRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtCurrentSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPulseRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPulseSP As AVP_Robot_Project.SL_Textbox
End Class
