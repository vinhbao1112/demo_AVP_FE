<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PMProcessStatusPopUpPanel
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
        Me.lblSourceEMCurrent = New System.Windows.Forms.Label
        Me.txtSourceEMCurrent = New AVP_Robot_Project.SL_Textbox
        Me.lblBeamVoltage = New System.Windows.Forms.Label
        Me.lblBeamCurrent = New System.Windows.Forms.Label
        Me.lblSuppressorVoltage = New System.Windows.Forms.Label
        Me.lblSuppressorCurrent = New System.Windows.Forms.Label
        Me.lblRFPower = New System.Windows.Forms.Label
        Me.lblRFReflected = New System.Windows.Forms.Label
        Me.lblPBNGas = New System.Windows.Forms.Label
        Me.lblGas1 = New System.Windows.Forms.Label
        Me.lblGas2 = New System.Windows.Forms.Label
        Me.lblGas3 = New System.Windows.Forms.Label
        Me.lblGas4 = New System.Windows.Forms.Label
        Me.lblFlowCool = New System.Windows.Forms.Label
        Me.lblKFactor = New System.Windows.Forms.Label
        Me.lblPBNBody = New System.Windows.Forms.Label
        Me.lblPBNDischarge = New System.Windows.Forms.Label
        Me.lblTiltAngle = New System.Windows.Forms.Label
        Me.txtBeamVoltageRB = New AVP_Robot_Project.SL_Textbox
        Me.txtBeamVoltageSP = New AVP_Robot_Project.SL_Textbox
        Me.txtBeamCurrentRB = New AVP_Robot_Project.SL_Textbox
        Me.txtBeamCurrentSP = New AVP_Robot_Project.SL_Textbox
        Me.txtSuppressorVoltageRB = New AVP_Robot_Project.SL_Textbox
        Me.txtSuppressorVoltageSP = New AVP_Robot_Project.SL_Textbox
        Me.txtSuppressorCurrentRB = New AVP_Robot_Project.SL_Textbox
        Me.txtRFPowerRB = New AVP_Robot_Project.SL_Textbox
        Me.txtRFPowerSP = New AVP_Robot_Project.SL_Textbox
        Me.txtRFReflectedRB = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNGasRB = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNGasSP = New AVP_Robot_Project.SL_Textbox
        Me.txtGas1RB = New AVP_Robot_Project.SL_Textbox
        Me.txtGas1SP = New AVP_Robot_Project.SL_Textbox
        Me.txtGas2RB = New AVP_Robot_Project.SL_Textbox
        Me.txtGas2SP = New AVP_Robot_Project.SL_Textbox
        Me.txtGas3RB = New AVP_Robot_Project.SL_Textbox
        Me.txtGas3SP = New AVP_Robot_Project.SL_Textbox
        Me.txtGas4RB = New AVP_Robot_Project.SL_Textbox
        Me.txtGas4SP = New AVP_Robot_Project.SL_Textbox
        Me.txtFlowCoolSP = New AVP_Robot_Project.SL_Textbox
        Me.txtFlowCoolRB = New AVP_Robot_Project.SL_Textbox
        Me.txtKFactorRB = New AVP_Robot_Project.SL_Textbox
        Me.txtKFactorSP = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNBodyRB = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNDischargeRB = New AVP_Robot_Project.SL_Textbox
        Me.txtTiltAngleRB = New AVP_Robot_Project.SL_Textbox
        Me.txtTiltAngleSP = New AVP_Robot_Project.SL_Textbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPBNDischargeVoltRB = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNBodyVoltRB = New AVP_Robot_Project.SL_Textbox
        Me.txtRotatonMode = New AVP_Robot_Project.SL_Textbox
        Me.lblRotationMode = New System.Windows.Forms.Label
        Me.txtANC = New AVP_Robot_Project.SL_Textbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRoughToPressure = New AVP_Robot_Project.SL_Textbox
        Me.txtStartUpTemp = New AVP_Robot_Project.SL_Textbox
        Me.FormContainer.SuspendLayout()
        Me.tableContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.tableContainer)
        Me.FormContainer.Controls.Add(Me.Label2)
        Me.FormContainer.Location = New System.Drawing.Point(5, 30)
        Me.FormContainer.Size = New System.Drawing.Size(252, 560)
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 3)
        Me.Label2.TabIndex = 80
        '
        'tableContainer
        '
        Me.tableContainer.BackColor = System.Drawing.Color.Transparent
        Me.tableContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.tableContainer.ColumnCount = 3
        Me.tableContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.tableContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tableContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tableContainer.Controls.Add(Me.lblSourceEMCurrent, 0, 20)
        Me.tableContainer.Controls.Add(Me.txtSourceEMCurrent, 0, 20)
        Me.tableContainer.Controls.Add(Me.lblBeamVoltage, 0, 0)
        Me.tableContainer.Controls.Add(Me.lblBeamCurrent, 0, 1)
        Me.tableContainer.Controls.Add(Me.lblSuppressorVoltage, 0, 2)
        Me.tableContainer.Controls.Add(Me.lblSuppressorCurrent, 0, 3)
        Me.tableContainer.Controls.Add(Me.lblRFPower, 0, 4)
        Me.tableContainer.Controls.Add(Me.lblRFReflected, 0, 5)
        Me.tableContainer.Controls.Add(Me.lblPBNGas, 0, 6)
        Me.tableContainer.Controls.Add(Me.lblGas1, 0, 7)
        Me.tableContainer.Controls.Add(Me.lblGas2, 0, 8)
        Me.tableContainer.Controls.Add(Me.lblGas3, 0, 9)
        Me.tableContainer.Controls.Add(Me.lblGas4, 0, 10)
        Me.tableContainer.Controls.Add(Me.lblFlowCool, 0, 11)
        Me.tableContainer.Controls.Add(Me.lblKFactor, 0, 12)
        Me.tableContainer.Controls.Add(Me.lblPBNBody, 0, 13)
        Me.tableContainer.Controls.Add(Me.lblPBNDischarge, 0, 14)
        Me.tableContainer.Controls.Add(Me.lblTiltAngle, 0, 15)
        Me.tableContainer.Controls.Add(Me.txtBeamVoltageRB, 1, 0)
        Me.tableContainer.Controls.Add(Me.txtBeamVoltageSP, 2, 0)
        Me.tableContainer.Controls.Add(Me.txtBeamCurrentRB, 1, 1)
        Me.tableContainer.Controls.Add(Me.txtBeamCurrentSP, 2, 1)
        Me.tableContainer.Controls.Add(Me.txtSuppressorVoltageRB, 1, 2)
        Me.tableContainer.Controls.Add(Me.txtSuppressorVoltageSP, 2, 2)
        Me.tableContainer.Controls.Add(Me.txtSuppressorCurrentRB, 1, 3)
        Me.tableContainer.Controls.Add(Me.txtRFPowerRB, 1, 4)
        Me.tableContainer.Controls.Add(Me.txtRFPowerSP, 2, 4)
        Me.tableContainer.Controls.Add(Me.txtRFReflectedRB, 1, 5)
        Me.tableContainer.Controls.Add(Me.txtPBNGasRB, 1, 6)
        Me.tableContainer.Controls.Add(Me.txtPBNGasSP, 2, 6)
        Me.tableContainer.Controls.Add(Me.txtGas1RB, 1, 7)
        Me.tableContainer.Controls.Add(Me.txtGas1SP, 2, 7)
        Me.tableContainer.Controls.Add(Me.txtGas2RB, 1, 8)
        Me.tableContainer.Controls.Add(Me.txtGas2SP, 2, 8)
        Me.tableContainer.Controls.Add(Me.txtGas3RB, 1, 9)
        Me.tableContainer.Controls.Add(Me.txtGas3SP, 2, 9)
        Me.tableContainer.Controls.Add(Me.txtGas4RB, 1, 10)
        Me.tableContainer.Controls.Add(Me.txtGas4SP, 2, 10)
        Me.tableContainer.Controls.Add(Me.txtFlowCoolSP, 2, 11)
        Me.tableContainer.Controls.Add(Me.txtFlowCoolRB, 1, 11)
        Me.tableContainer.Controls.Add(Me.txtKFactorRB, 1, 12)
        Me.tableContainer.Controls.Add(Me.txtKFactorSP, 2, 12)
        Me.tableContainer.Controls.Add(Me.txtPBNBodyRB, 1, 13)
        Me.tableContainer.Controls.Add(Me.txtPBNDischargeRB, 1, 14)
        Me.tableContainer.Controls.Add(Me.txtTiltAngleRB, 1, 15)
        Me.tableContainer.Controls.Add(Me.txtTiltAngleSP, 2, 15)
        Me.tableContainer.Controls.Add(Me.Label1, 0, 16)
        Me.tableContainer.Controls.Add(Me.Label3, 0, 17)
        Me.tableContainer.Controls.Add(Me.txtPBNDischargeVoltRB, 1, 17)
        Me.tableContainer.Controls.Add(Me.txtPBNBodyVoltRB, 1, 16)
        Me.tableContainer.Controls.Add(Me.txtRotatonMode, 1, 19)
        Me.tableContainer.Controls.Add(Me.lblRotationMode, 0, 19)
        Me.tableContainer.Controls.Add(Me.txtANC, 1, 18)
        Me.tableContainer.Controls.Add(Me.Label4, 0, 18)
        Me.tableContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.tableContainer.Location = New System.Drawing.Point(0, 3)
        Me.tableContainer.Name = "tableContainer"
        Me.tableContainer.RowCount = 21
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
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tableContainer.Size = New System.Drawing.Size(252, 550)
        Me.tableContainer.TabIndex = 81
        '
        'lblSourceEMCurrent
        '
        Me.lblSourceEMCurrent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSourceEMCurrent.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSourceEMCurrent.Location = New System.Drawing.Point(5, 524)
        Me.lblSourceEMCurrent.Name = "lblSourceEMCurrent"
        Me.lblSourceEMCurrent.Size = New System.Drawing.Size(104, 24)
        Me.lblSourceEMCurrent.TabIndex = 124
        Me.lblSourceEMCurrent.Text = "E.M Curr (A)"
        Me.lblSourceEMCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSourceEMCurrent
        '
        Me.txtSourceEMCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSourceEMCurrent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSourceEMCurrent.DisplayProcessFont = True
        Me.txtSourceEMCurrent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSourceEMCurrent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtSourceEMCurrent.IsReadBack = True
        Me.txtSourceEMCurrent.Location = New System.Drawing.Point(117, 527)
        Me.txtSourceEMCurrent.MinimumValueHighlightedGreen = 0
        Me.txtSourceEMCurrent.Name = "txtSourceEMCurrent"
        Me.txtSourceEMCurrent.ReadOnly = True
        Me.txtSourceEMCurrent.Size = New System.Drawing.Size(59, 20)
        Me.txtSourceEMCurrent.TabIndex = 123
        Me.txtSourceEMCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSourceEMCurrent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSourceEMCurrent.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Three_Digits
        '
        'lblBeamVoltage
        '
        Me.lblBeamVoltage.BackColor = System.Drawing.Color.Transparent
        Me.lblBeamVoltage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBeamVoltage.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBeamVoltage.Location = New System.Drawing.Point(5, 2)
        Me.lblBeamVoltage.Name = "lblBeamVoltage"
        Me.lblBeamVoltage.Size = New System.Drawing.Size(104, 24)
        Me.lblBeamVoltage.TabIndex = 75
        Me.lblBeamVoltage.Text = "Beam Vol (V)"
        Me.lblBeamVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBeamCurrent
        '
        Me.lblBeamCurrent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBeamCurrent.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBeamCurrent.Location = New System.Drawing.Point(5, 28)
        Me.lblBeamCurrent.Name = "lblBeamCurrent"
        Me.lblBeamCurrent.Size = New System.Drawing.Size(104, 24)
        Me.lblBeamCurrent.TabIndex = 76
        Me.lblBeamCurrent.Text = "Beam Cur (mA)"
        Me.lblBeamCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSuppressorVoltage
        '
        Me.lblSuppressorVoltage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSuppressorVoltage.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuppressorVoltage.Location = New System.Drawing.Point(5, 54)
        Me.lblSuppressorVoltage.Name = "lblSuppressorVoltage"
        Me.lblSuppressorVoltage.Size = New System.Drawing.Size(104, 24)
        Me.lblSuppressorVoltage.TabIndex = 77
        Me.lblSuppressorVoltage.Text = "Supp Vol (V)"
        Me.lblSuppressorVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSuppressorCurrent
        '
        Me.lblSuppressorCurrent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSuppressorCurrent.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuppressorCurrent.Location = New System.Drawing.Point(5, 80)
        Me.lblSuppressorCurrent.Name = "lblSuppressorCurrent"
        Me.lblSuppressorCurrent.Size = New System.Drawing.Size(104, 24)
        Me.lblSuppressorCurrent.TabIndex = 78
        Me.lblSuppressorCurrent.Text = "Supp Cur (mA)"
        Me.lblSuppressorCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRFPower
        '
        Me.lblRFPower.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRFPower.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFPower.Location = New System.Drawing.Point(5, 106)
        Me.lblRFPower.Name = "lblRFPower"
        Me.lblRFPower.Size = New System.Drawing.Size(104, 24)
        Me.lblRFPower.TabIndex = 79
        Me.lblRFPower.Text = "RF Power (W)"
        Me.lblRFPower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRFReflected
        '
        Me.lblRFReflected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRFReflected.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFReflected.Location = New System.Drawing.Point(5, 132)
        Me.lblRFReflected.Name = "lblRFReflected"
        Me.lblRFReflected.Size = New System.Drawing.Size(104, 24)
        Me.lblRFReflected.TabIndex = 80
        Me.lblRFReflected.Text = "RF Ref (W)"
        Me.lblRFReflected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPBNGas
        '
        Me.lblPBNGas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPBNGas.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPBNGas.Location = New System.Drawing.Point(5, 158)
        Me.lblPBNGas.Name = "lblPBNGas"
        Me.lblPBNGas.Size = New System.Drawing.Size(104, 24)
        Me.lblPBNGas.TabIndex = 93
        Me.lblPBNGas.Text = "PBN (sccm)"
        Me.lblPBNGas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGas1
        '
        Me.lblGas1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGas1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas1.Location = New System.Drawing.Point(5, 184)
        Me.lblGas1.Name = "lblGas1"
        Me.lblGas1.Size = New System.Drawing.Size(104, 24)
        Me.lblGas1.TabIndex = 96
        Me.lblGas1.Text = "Gas1 (sccm)"
        Me.lblGas1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGas2
        '
        Me.lblGas2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGas2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas2.Location = New System.Drawing.Point(5, 210)
        Me.lblGas2.Name = "lblGas2"
        Me.lblGas2.Size = New System.Drawing.Size(104, 24)
        Me.lblGas2.TabIndex = 99
        Me.lblGas2.Text = "Gas2 (sccm)"
        Me.lblGas2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGas3
        '
        Me.lblGas3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGas3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas3.Location = New System.Drawing.Point(5, 236)
        Me.lblGas3.Name = "lblGas3"
        Me.lblGas3.Size = New System.Drawing.Size(104, 24)
        Me.lblGas3.TabIndex = 99
        Me.lblGas3.Text = "Gas3 (sccm)"
        Me.lblGas3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGas4
        '
        Me.lblGas4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGas4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas4.Location = New System.Drawing.Point(5, 262)
        Me.lblGas4.Name = "lblGas4"
        Me.lblGas4.Size = New System.Drawing.Size(104, 24)
        Me.lblGas4.TabIndex = 99
        Me.lblGas4.Text = "Gas4 (sccm)"
        Me.lblGas4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFlowCool
        '
        Me.lblFlowCool.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFlowCool.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlowCool.Location = New System.Drawing.Point(5, 288)
        Me.lblFlowCool.Name = "lblFlowCool"
        Me.lblFlowCool.Size = New System.Drawing.Size(104, 24)
        Me.lblFlowCool.TabIndex = 116
        Me.lblFlowCool.Text = "FlowCool (sccm)"
        Me.lblFlowCool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKFactor
        '
        Me.lblKFactor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKFactor.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKFactor.Location = New System.Drawing.Point(5, 314)
        Me.lblKFactor.Name = "lblKFactor"
        Me.lblKFactor.Size = New System.Drawing.Size(104, 24)
        Me.lblKFactor.TabIndex = 102
        Me.lblKFactor.Text = "KFactor"
        Me.lblKFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPBNBody
        '
        Me.lblPBNBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPBNBody.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPBNBody.Location = New System.Drawing.Point(5, 340)
        Me.lblPBNBody.Name = "lblPBNBody"
        Me.lblPBNBody.Size = New System.Drawing.Size(104, 24)
        Me.lblPBNBody.TabIndex = 105
        Me.lblPBNBody.Text = "PBN Body (mA)"
        Me.lblPBNBody.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPBNDischarge
        '
        Me.lblPBNDischarge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPBNDischarge.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPBNDischarge.Location = New System.Drawing.Point(5, 366)
        Me.lblPBNDischarge.Name = "lblPBNDischarge"
        Me.lblPBNDischarge.Size = New System.Drawing.Size(104, 24)
        Me.lblPBNDischarge.TabIndex = 108
        Me.lblPBNDischarge.Text = "PBN Disc (A)"
        Me.lblPBNDischarge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTiltAngle
        '
        Me.lblTiltAngle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTiltAngle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiltAngle.Location = New System.Drawing.Point(5, 392)
        Me.lblTiltAngle.Name = "lblTiltAngle"
        Me.lblTiltAngle.Size = New System.Drawing.Size(104, 24)
        Me.lblTiltAngle.TabIndex = 113
        Me.lblTiltAngle.Text = "Tilt Angle"
        Me.lblTiltAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBeamVoltageRB
        '
        Me.txtBeamVoltageRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBeamVoltageRB.Clickable = False
        Me.txtBeamVoltageRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBeamVoltageRB.DisplayProcessFont = True
        Me.txtBeamVoltageRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBeamVoltageRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtBeamVoltageRB.IsReadBack = True
        Me.txtBeamVoltageRB.Location = New System.Drawing.Point(117, 5)
        Me.txtBeamVoltageRB.MinimumValueHighlightedGreen = 0
        Me.txtBeamVoltageRB.Name = "txtBeamVoltageRB"
        Me.txtBeamVoltageRB.ReadOnly = True
        Me.txtBeamVoltageRB.Size = New System.Drawing.Size(59, 20)
        Me.txtBeamVoltageRB.TabIndex = 81
        Me.txtBeamVoltageRB.TabStop = False
        Me.txtBeamVoltageRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBeamVoltageRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBeamVoltageRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtBeamVoltageRB.UseScientificFormat = True
        '
        'txtBeamVoltageSP
        '
        Me.txtBeamVoltageSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBeamVoltageSP.Clickable = False
        Me.txtBeamVoltageSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBeamVoltageSP.DisplayProcessFont = True
        Me.txtBeamVoltageSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBeamVoltageSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtBeamVoltageSP.IsNumericTextbox = True
        Me.txtBeamVoltageSP.IsReadBack = True
        Me.txtBeamVoltageSP.Location = New System.Drawing.Point(184, 5)
        Me.txtBeamVoltageSP.MinimumValueHighlightedGreen = 0
        Me.txtBeamVoltageSP.Name = "txtBeamVoltageSP"
        Me.txtBeamVoltageSP.ReadOnly = True
        Me.txtBeamVoltageSP.Size = New System.Drawing.Size(63, 20)
        Me.txtBeamVoltageSP.TabIndex = 87
        Me.txtBeamVoltageSP.TabStop = False
        Me.txtBeamVoltageSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBeamVoltageSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBeamVoltageSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtBeamCurrentRB
        '
        Me.txtBeamCurrentRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBeamCurrentRB.Clickable = False
        Me.txtBeamCurrentRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBeamCurrentRB.DisplayProcessFont = True
        Me.txtBeamCurrentRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBeamCurrentRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtBeamCurrentRB.IsReadBack = True
        Me.txtBeamCurrentRB.Location = New System.Drawing.Point(117, 31)
        Me.txtBeamCurrentRB.MinimumValueHighlightedGreen = 0
        Me.txtBeamCurrentRB.Name = "txtBeamCurrentRB"
        Me.txtBeamCurrentRB.ReadOnly = True
        Me.txtBeamCurrentRB.Size = New System.Drawing.Size(59, 20)
        Me.txtBeamCurrentRB.TabIndex = 82
        Me.txtBeamCurrentRB.TabStop = False
        Me.txtBeamCurrentRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBeamCurrentRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBeamCurrentRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtBeamCurrentRB.UseScientificFormat = True
        '
        'txtBeamCurrentSP
        '
        Me.txtBeamCurrentSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBeamCurrentSP.Clickable = False
        Me.txtBeamCurrentSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBeamCurrentSP.DisplayProcessFont = True
        Me.txtBeamCurrentSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBeamCurrentSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtBeamCurrentSP.IsNumericTextbox = True
        Me.txtBeamCurrentSP.IsReadBack = True
        Me.txtBeamCurrentSP.Location = New System.Drawing.Point(184, 31)
        Me.txtBeamCurrentSP.MinimumValueHighlightedGreen = 0
        Me.txtBeamCurrentSP.Name = "txtBeamCurrentSP"
        Me.txtBeamCurrentSP.ReadOnly = True
        Me.txtBeamCurrentSP.Size = New System.Drawing.Size(63, 20)
        Me.txtBeamCurrentSP.TabIndex = 88
        Me.txtBeamCurrentSP.TabStop = False
        Me.txtBeamCurrentSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBeamCurrentSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtBeamCurrentSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtSuppressorVoltageRB
        '
        Me.txtSuppressorVoltageRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSuppressorVoltageRB.Clickable = False
        Me.txtSuppressorVoltageRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSuppressorVoltageRB.DisplayProcessFont = True
        Me.txtSuppressorVoltageRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSuppressorVoltageRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtSuppressorVoltageRB.IsReadBack = True
        Me.txtSuppressorVoltageRB.Location = New System.Drawing.Point(117, 57)
        Me.txtSuppressorVoltageRB.MinimumValueHighlightedGreen = 0
        Me.txtSuppressorVoltageRB.Name = "txtSuppressorVoltageRB"
        Me.txtSuppressorVoltageRB.ReadOnly = True
        Me.txtSuppressorVoltageRB.Size = New System.Drawing.Size(59, 20)
        Me.txtSuppressorVoltageRB.TabIndex = 83
        Me.txtSuppressorVoltageRB.TabStop = False
        Me.txtSuppressorVoltageRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSuppressorVoltageRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSuppressorVoltageRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtSuppressorVoltageRB.UseScientificFormat = True
        '
        'txtSuppressorVoltageSP
        '
        Me.txtSuppressorVoltageSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSuppressorVoltageSP.Clickable = False
        Me.txtSuppressorVoltageSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSuppressorVoltageSP.DisplayProcessFont = True
        Me.txtSuppressorVoltageSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSuppressorVoltageSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtSuppressorVoltageSP.IsNumericTextbox = True
        Me.txtSuppressorVoltageSP.IsReadBack = True
        Me.txtSuppressorVoltageSP.Location = New System.Drawing.Point(184, 57)
        Me.txtSuppressorVoltageSP.MinimumValueHighlightedGreen = 0
        Me.txtSuppressorVoltageSP.Name = "txtSuppressorVoltageSP"
        Me.txtSuppressorVoltageSP.ReadOnly = True
        Me.txtSuppressorVoltageSP.Size = New System.Drawing.Size(63, 20)
        Me.txtSuppressorVoltageSP.TabIndex = 89
        Me.txtSuppressorVoltageSP.TabStop = False
        Me.txtSuppressorVoltageSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSuppressorVoltageSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSuppressorVoltageSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtSuppressorCurrentRB
        '
        Me.txtSuppressorCurrentRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSuppressorCurrentRB.Clickable = False
        Me.txtSuppressorCurrentRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSuppressorCurrentRB.DisplayProcessFont = True
        Me.txtSuppressorCurrentRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSuppressorCurrentRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtSuppressorCurrentRB.IsReadBack = True
        Me.txtSuppressorCurrentRB.Location = New System.Drawing.Point(117, 83)
        Me.txtSuppressorCurrentRB.MinimumValueHighlightedGreen = 0
        Me.txtSuppressorCurrentRB.Name = "txtSuppressorCurrentRB"
        Me.txtSuppressorCurrentRB.ReadOnly = True
        Me.txtSuppressorCurrentRB.Size = New System.Drawing.Size(59, 20)
        Me.txtSuppressorCurrentRB.TabIndex = 84
        Me.txtSuppressorCurrentRB.TabStop = False
        Me.txtSuppressorCurrentRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSuppressorCurrentRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSuppressorCurrentRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtSuppressorCurrentRB.UseScientificFormat = True
        '
        'txtRFPowerRB
        '
        Me.txtRFPowerRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRFPowerRB.Clickable = False
        Me.txtRFPowerRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRFPowerRB.DisplayProcessFont = True
        Me.txtRFPowerRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRFPowerRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtRFPowerRB.IsReadBack = True
        Me.txtRFPowerRB.Location = New System.Drawing.Point(117, 109)
        Me.txtRFPowerRB.MinimumValueHighlightedGreen = 0
        Me.txtRFPowerRB.Name = "txtRFPowerRB"
        Me.txtRFPowerRB.ReadOnly = True
        Me.txtRFPowerRB.Size = New System.Drawing.Size(59, 20)
        Me.txtRFPowerRB.TabIndex = 85
        Me.txtRFPowerRB.TabStop = False
        Me.txtRFPowerRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRFPowerRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRFPowerRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtRFPowerRB.UseScientificFormat = True
        '
        'txtRFPowerSP
        '
        Me.txtRFPowerSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRFPowerSP.Clickable = False
        Me.txtRFPowerSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRFPowerSP.DisplayProcessFont = True
        Me.txtRFPowerSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRFPowerSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtRFPowerSP.IsNumericTextbox = True
        Me.txtRFPowerSP.IsReadBack = True
        Me.txtRFPowerSP.Location = New System.Drawing.Point(184, 109)
        Me.txtRFPowerSP.MinimumValueHighlightedGreen = 0
        Me.txtRFPowerSP.Name = "txtRFPowerSP"
        Me.txtRFPowerSP.ReadOnly = True
        Me.txtRFPowerSP.Size = New System.Drawing.Size(63, 20)
        Me.txtRFPowerSP.TabIndex = 91
        Me.txtRFPowerSP.TabStop = False
        Me.txtRFPowerSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRFPowerSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRFPowerSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtRFReflectedRB
        '
        Me.txtRFReflectedRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRFReflectedRB.Clickable = False
        Me.txtRFReflectedRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRFReflectedRB.DisplayProcessFont = True
        Me.txtRFReflectedRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRFReflectedRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtRFReflectedRB.IsReadBack = True
        Me.txtRFReflectedRB.Location = New System.Drawing.Point(117, 135)
        Me.txtRFReflectedRB.MinimumValueHighlightedGreen = 0
        Me.txtRFReflectedRB.Name = "txtRFReflectedRB"
        Me.txtRFReflectedRB.ReadOnly = True
        Me.txtRFReflectedRB.Size = New System.Drawing.Size(59, 20)
        Me.txtRFReflectedRB.TabIndex = 86
        Me.txtRFReflectedRB.TabStop = False
        Me.txtRFReflectedRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRFReflectedRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRFReflectedRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtRFReflectedRB.UseScientificFormat = True
        '
        'txtPBNGasRB
        '
        Me.txtPBNGasRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNGasRB.Clickable = False
        Me.txtPBNGasRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNGasRB.DisplayProcessFont = True
        Me.txtPBNGasRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPBNGasRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNGasRB.IsReadBack = True
        Me.txtPBNGasRB.Location = New System.Drawing.Point(117, 161)
        Me.txtPBNGasRB.MinimumValueHighlightedGreen = 0
        Me.txtPBNGasRB.Name = "txtPBNGasRB"
        Me.txtPBNGasRB.ReadOnly = True
        Me.txtPBNGasRB.Size = New System.Drawing.Size(59, 20)
        Me.txtPBNGasRB.TabIndex = 94
        Me.txtPBNGasRB.TabStop = False
        Me.txtPBNGasRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPBNGasRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNGasRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPBNGasRB.UseScientificFormat = True
        '
        'txtPBNGasSP
        '
        Me.txtPBNGasSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNGasSP.Clickable = False
        Me.txtPBNGasSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNGasSP.DisplayProcessFont = True
        Me.txtPBNGasSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPBNGasSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNGasSP.IsNumericTextbox = True
        Me.txtPBNGasSP.IsReadBack = True
        Me.txtPBNGasSP.Location = New System.Drawing.Point(184, 161)
        Me.txtPBNGasSP.MinimumValueHighlightedGreen = 0
        Me.txtPBNGasSP.Name = "txtPBNGasSP"
        Me.txtPBNGasSP.ReadOnly = True
        Me.txtPBNGasSP.Size = New System.Drawing.Size(63, 20)
        Me.txtPBNGasSP.TabIndex = 95
        Me.txtPBNGasSP.TabStop = False
        Me.txtPBNGasSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPBNGasSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNGasSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
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
        Me.txtGas1RB.Location = New System.Drawing.Point(117, 187)
        Me.txtGas1RB.MinimumValueHighlightedGreen = 0
        Me.txtGas1RB.Name = "txtGas1RB"
        Me.txtGas1RB.ReadOnly = True
        Me.txtGas1RB.Size = New System.Drawing.Size(59, 20)
        Me.txtGas1RB.TabIndex = 97
        Me.txtGas1RB.TabStop = False
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
        Me.txtGas1SP.Location = New System.Drawing.Point(184, 187)
        Me.txtGas1SP.MinimumValueHighlightedGreen = 0
        Me.txtGas1SP.Name = "txtGas1SP"
        Me.txtGas1SP.ReadOnly = True
        Me.txtGas1SP.Size = New System.Drawing.Size(63, 20)
        Me.txtGas1SP.TabIndex = 98
        Me.txtGas1SP.TabStop = False
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
        Me.txtGas2RB.Location = New System.Drawing.Point(117, 213)
        Me.txtGas2RB.MinimumValueHighlightedGreen = 0
        Me.txtGas2RB.Name = "txtGas2RB"
        Me.txtGas2RB.ReadOnly = True
        Me.txtGas2RB.Size = New System.Drawing.Size(59, 20)
        Me.txtGas2RB.TabIndex = 100
        Me.txtGas2RB.TabStop = False
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
        Me.txtGas2SP.Location = New System.Drawing.Point(184, 213)
        Me.txtGas2SP.MinimumValueHighlightedGreen = 0
        Me.txtGas2SP.Name = "txtGas2SP"
        Me.txtGas2SP.ReadOnly = True
        Me.txtGas2SP.Size = New System.Drawing.Size(63, 20)
        Me.txtGas2SP.TabIndex = 101
        Me.txtGas2SP.TabStop = False
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
        Me.txtGas3RB.Location = New System.Drawing.Point(117, 239)
        Me.txtGas3RB.MinimumValueHighlightedGreen = 0
        Me.txtGas3RB.Name = "txtGas3RB"
        Me.txtGas3RB.ReadOnly = True
        Me.txtGas3RB.Size = New System.Drawing.Size(59, 20)
        Me.txtGas3RB.TabIndex = 100
        Me.txtGas3RB.TabStop = False
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
        Me.txtGas3SP.IsReadBack = True
        Me.txtGas3SP.Location = New System.Drawing.Point(184, 239)
        Me.txtGas3SP.MinimumValueHighlightedGreen = 0
        Me.txtGas3SP.Name = "txtGas3SP"
        Me.txtGas3SP.ReadOnly = True
        Me.txtGas3SP.Size = New System.Drawing.Size(63, 20)
        Me.txtGas3SP.TabIndex = 100
        Me.txtGas3SP.TabStop = False
        Me.txtGas3SP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGas3SP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas3SP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtGas3SP.UseScientificFormat = True
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
        Me.txtGas4RB.Location = New System.Drawing.Point(117, 265)
        Me.txtGas4RB.MinimumValueHighlightedGreen = 0
        Me.txtGas4RB.Name = "txtGas4RB"
        Me.txtGas4RB.ReadOnly = True
        Me.txtGas4RB.Size = New System.Drawing.Size(59, 20)
        Me.txtGas4RB.TabIndex = 100
        Me.txtGas4RB.TabStop = False
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
        Me.txtGas4SP.IsReadBack = True
        Me.txtGas4SP.Location = New System.Drawing.Point(184, 265)
        Me.txtGas4SP.MinimumValueHighlightedGreen = 0
        Me.txtGas4SP.Name = "txtGas4SP"
        Me.txtGas4SP.ReadOnly = True
        Me.txtGas4SP.Size = New System.Drawing.Size(63, 20)
        Me.txtGas4SP.TabIndex = 100
        Me.txtGas4SP.TabStop = False
        Me.txtGas4SP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGas4SP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtGas4SP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtGas4SP.UseScientificFormat = True
        '
        'txtFlowCoolSP
        '
        Me.txtFlowCoolSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFlowCoolSP.Clickable = False
        Me.txtFlowCoolSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFlowCoolSP.DisplayProcessFont = True
        Me.txtFlowCoolSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFlowCoolSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtFlowCoolSP.IsReadBack = True
        Me.txtFlowCoolSP.Location = New System.Drawing.Point(184, 291)
        Me.txtFlowCoolSP.MinimumValueHighlightedGreen = 0
        Me.txtFlowCoolSP.Name = "txtFlowCoolSP"
        Me.txtFlowCoolSP.ReadOnly = True
        Me.txtFlowCoolSP.Size = New System.Drawing.Size(63, 20)
        Me.txtFlowCoolSP.TabIndex = 117
        Me.txtFlowCoolSP.TabStop = False
        Me.txtFlowCoolSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFlowCoolSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtFlowCoolSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtFlowCoolSP.UseScientificFormat = True
        '
        'txtFlowCoolRB
        '
        Me.txtFlowCoolRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFlowCoolRB.Clickable = False
        Me.txtFlowCoolRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFlowCoolRB.DisplayProcessFont = True
        Me.txtFlowCoolRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFlowCoolRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtFlowCoolRB.IsReadBack = True
        Me.txtFlowCoolRB.Location = New System.Drawing.Point(117, 291)
        Me.txtFlowCoolRB.MinimumValueHighlightedGreen = 0
        Me.txtFlowCoolRB.Name = "txtFlowCoolRB"
        Me.txtFlowCoolRB.ReadOnly = True
        Me.txtFlowCoolRB.Size = New System.Drawing.Size(59, 20)
        Me.txtFlowCoolRB.TabIndex = 118
        Me.txtFlowCoolRB.TabStop = False
        Me.txtFlowCoolRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFlowCoolRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtFlowCoolRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtFlowCoolRB.UseScientificFormat = True
        '
        'txtKFactorRB
        '
        Me.txtKFactorRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtKFactorRB.Clickable = False
        Me.txtKFactorRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtKFactorRB.DisplayProcessFont = True
        Me.txtKFactorRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtKFactorRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtKFactorRB.IsReadBack = True
        Me.txtKFactorRB.Location = New System.Drawing.Point(117, 317)
        Me.txtKFactorRB.MinimumValueHighlightedGreen = 0
        Me.txtKFactorRB.Name = "txtKFactorRB"
        Me.txtKFactorRB.ReadOnly = True
        Me.txtKFactorRB.Size = New System.Drawing.Size(59, 20)
        Me.txtKFactorRB.TabIndex = 103
        Me.txtKFactorRB.TabStop = False
        Me.txtKFactorRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtKFactorRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtKFactorRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtKFactorRB.UseScientificFormat = True
        '
        'txtKFactorSP
        '
        Me.txtKFactorSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtKFactorSP.Clickable = False
        Me.txtKFactorSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtKFactorSP.DisplayProcessFont = True
        Me.txtKFactorSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtKFactorSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtKFactorSP.IsNumericTextbox = True
        Me.txtKFactorSP.IsReadBack = True
        Me.txtKFactorSP.Location = New System.Drawing.Point(184, 317)
        Me.txtKFactorSP.MinimumValueHighlightedGreen = 0
        Me.txtKFactorSP.Name = "txtKFactorSP"
        Me.txtKFactorSP.ReadOnly = True
        Me.txtKFactorSP.Size = New System.Drawing.Size(63, 20)
        Me.txtKFactorSP.TabIndex = 104
        Me.txtKFactorSP.TabStop = False
        Me.txtKFactorSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtKFactorSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtKFactorSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtPBNBodyRB
        '
        Me.txtPBNBodyRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNBodyRB.Clickable = False
        Me.txtPBNBodyRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNBodyRB.DisplayProcessFont = True
        Me.txtPBNBodyRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPBNBodyRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNBodyRB.IsReadBack = True
        Me.txtPBNBodyRB.Location = New System.Drawing.Point(117, 343)
        Me.txtPBNBodyRB.MinimumValueHighlightedGreen = 0
        Me.txtPBNBodyRB.Name = "txtPBNBodyRB"
        Me.txtPBNBodyRB.ReadOnly = True
        Me.txtPBNBodyRB.Size = New System.Drawing.Size(59, 20)
        Me.txtPBNBodyRB.TabIndex = 106
        Me.txtPBNBodyRB.TabStop = False
        Me.txtPBNBodyRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPBNBodyRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNBodyRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPBNBodyRB.UseScientificFormat = True
        '
        'txtPBNDischargeRB
        '
        Me.txtPBNDischargeRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNDischargeRB.Clickable = False
        Me.txtPBNDischargeRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNDischargeRB.DisplayProcessFont = True
        Me.txtPBNDischargeRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPBNDischargeRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNDischargeRB.IsReadBack = True
        Me.txtPBNDischargeRB.Location = New System.Drawing.Point(117, 369)
        Me.txtPBNDischargeRB.MinimumValueHighlightedGreen = 0
        Me.txtPBNDischargeRB.Name = "txtPBNDischargeRB"
        Me.txtPBNDischargeRB.ReadOnly = True
        Me.txtPBNDischargeRB.Size = New System.Drawing.Size(59, 20)
        Me.txtPBNDischargeRB.TabIndex = 109
        Me.txtPBNDischargeRB.TabStop = False
        Me.txtPBNDischargeRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPBNDischargeRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNDischargeRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Two_Digits
        Me.txtPBNDischargeRB.UseScientificFormat = True
        '
        'txtTiltAngleRB
        '
        Me.txtTiltAngleRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTiltAngleRB.Clickable = False
        Me.txtTiltAngleRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTiltAngleRB.DisplayProcessFont = True
        Me.txtTiltAngleRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTiltAngleRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtTiltAngleRB.IsReadBack = True
        Me.txtTiltAngleRB.Location = New System.Drawing.Point(117, 395)
        Me.txtTiltAngleRB.MinimumValueHighlightedGreen = 0
        Me.txtTiltAngleRB.Name = "txtTiltAngleRB"
        Me.txtTiltAngleRB.ReadOnly = True
        Me.txtTiltAngleRB.Size = New System.Drawing.Size(59, 20)
        Me.txtTiltAngleRB.TabIndex = 112
        Me.txtTiltAngleRB.TabStop = False
        Me.txtTiltAngleRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTiltAngleRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTiltAngleRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtTiltAngleRB.UseScientificFormat = True
        '
        'txtTiltAngleSP
        '
        Me.txtTiltAngleSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTiltAngleSP.Clickable = False
        Me.txtTiltAngleSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTiltAngleSP.DisplayProcessFont = True
        Me.txtTiltAngleSP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTiltAngleSP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtTiltAngleSP.IsReadBack = True
        Me.txtTiltAngleSP.Location = New System.Drawing.Point(184, 395)
        Me.txtTiltAngleSP.MinimumValueHighlightedGreen = 0
        Me.txtTiltAngleSP.Name = "txtTiltAngleSP"
        Me.txtTiltAngleSP.ReadOnly = True
        Me.txtTiltAngleSP.Size = New System.Drawing.Size(63, 20)
        Me.txtTiltAngleSP.TabIndex = 111
        Me.txtTiltAngleSP.TabStop = False
        Me.txtTiltAngleSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTiltAngleSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTiltAngleSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtTiltAngleSP.UseScientificFormat = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(5, 418)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "PBN Body (V)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(5, 444)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 24)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "PBN Disc (V)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPBNDischargeVoltRB
        '
        Me.txtPBNDischargeVoltRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNDischargeVoltRB.Clickable = False
        Me.txtPBNDischargeVoltRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNDischargeVoltRB.DisplayProcessFont = True
        Me.txtPBNDischargeVoltRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPBNDischargeVoltRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNDischargeVoltRB.IsReadBack = True
        Me.txtPBNDischargeVoltRB.Location = New System.Drawing.Point(117, 447)
        Me.txtPBNDischargeVoltRB.MinimumValueHighlightedGreen = 0
        Me.txtPBNDischargeVoltRB.Name = "txtPBNDischargeVoltRB"
        Me.txtPBNDischargeVoltRB.ReadOnly = True
        Me.txtPBNDischargeVoltRB.Size = New System.Drawing.Size(59, 20)
        Me.txtPBNDischargeVoltRB.TabIndex = 115
        Me.txtPBNDischargeVoltRB.TabStop = False
        Me.txtPBNDischargeVoltRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPBNDischargeVoltRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNDischargeVoltRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPBNDischargeVoltRB.UseScientificFormat = True
        '
        'txtPBNBodyVoltRB
        '
        Me.txtPBNBodyVoltRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNBodyVoltRB.Clickable = False
        Me.txtPBNBodyVoltRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNBodyVoltRB.DisplayProcessFont = True
        Me.txtPBNBodyVoltRB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPBNBodyVoltRB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNBodyVoltRB.IsReadBack = True
        Me.txtPBNBodyVoltRB.Location = New System.Drawing.Point(117, 421)
        Me.txtPBNBodyVoltRB.MinimumValueHighlightedGreen = 0
        Me.txtPBNBodyVoltRB.Name = "txtPBNBodyVoltRB"
        Me.txtPBNBodyVoltRB.ReadOnly = True
        Me.txtPBNBodyVoltRB.Size = New System.Drawing.Size(59, 20)
        Me.txtPBNBodyVoltRB.TabIndex = 115
        Me.txtPBNBodyVoltRB.TabStop = False
        Me.txtPBNBodyVoltRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPBNBodyVoltRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPBNBodyVoltRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPBNBodyVoltRB.UseScientificFormat = True
        '
        'txtRotatonMode
        '
        Me.txtRotatonMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRotatonMode.Clickable = False
        Me.txtRotatonMode.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRotatonMode.DisplayProcessFont = True
        Me.txtRotatonMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRotatonMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotatonMode.IsReadBack = True
        Me.txtRotatonMode.Location = New System.Drawing.Point(117, 501)
        Me.txtRotatonMode.MinimumValueHighlightedGreen = 0
        Me.txtRotatonMode.Name = "txtRotatonMode"
        Me.txtRotatonMode.ReadOnly = True
        Me.txtRotatonMode.Size = New System.Drawing.Size(59, 20)
        Me.txtRotatonMode.TabIndex = 115
        Me.txtRotatonMode.TabStop = False
        Me.txtRotatonMode.Text = "Home"
        Me.txtRotatonMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRotatonMode.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRotatonMode.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtRotatonMode.UseScientificFormat = True
        '
        'lblRotationMode
        '
        Me.lblRotationMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRotationMode.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRotationMode.Location = New System.Drawing.Point(5, 498)
        Me.lblRotationMode.Name = "lblRotationMode"
        Me.lblRotationMode.Size = New System.Drawing.Size(104, 24)
        Me.lblRotationMode.TabIndex = 114
        Me.lblRotationMode.Text = "Rotation Mode"
        Me.lblRotationMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtANC
        '
        Me.txtANC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtANC.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtANC.DisplayProcessFont = True
        Me.txtANC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtANC.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtANC.IsReadBack = True
        Me.txtANC.Location = New System.Drawing.Point(117, 473)
        Me.txtANC.MinimumValueHighlightedGreen = 0
        Me.txtANC.Name = "txtANC"
        Me.txtANC.ReadOnly = True
        Me.txtANC.Size = New System.Drawing.Size(59, 20)
        Me.txtANC.TabIndex = 121
        Me.txtANC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtANC.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtANC.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Two_Digits
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(5, 470)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 26)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "ANC Probe (V)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRoughToPressure
        '
        Me.txtRoughToPressure.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRoughToPressure.Clickable = False
        Me.txtRoughToPressure.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRoughToPressure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRoughToPressure.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRoughToPressure.IsNumericTextbox = True
        Me.txtRoughToPressure.IsReadBack = True
        Me.txtRoughToPressure.Location = New System.Drawing.Point(293, 101)
        Me.txtRoughToPressure.MinimumValueHighlightedGreen = 0
        Me.txtRoughToPressure.Name = "txtRoughToPressure"
        Me.txtRoughToPressure.ReadOnly = True
        Me.txtRoughToPressure.Size = New System.Drawing.Size(115, 24)
        Me.txtRoughToPressure.TabIndex = 90
        Me.txtRoughToPressure.TabStop = False
        Me.txtRoughToPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRoughToPressure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRoughToPressure.Visible = False
        '
        'txtStartUpTemp
        '
        Me.txtStartUpTemp.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStartUpTemp.Clickable = False
        Me.txtStartUpTemp.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStartUpTemp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStartUpTemp.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStartUpTemp.IsNumericTextbox = True
        Me.txtStartUpTemp.IsReadBack = True
        Me.txtStartUpTemp.Location = New System.Drawing.Point(293, 165)
        Me.txtStartUpTemp.MinimumValueHighlightedGreen = 0
        Me.txtStartUpTemp.Name = "txtStartUpTemp"
        Me.txtStartUpTemp.ReadOnly = True
        Me.txtStartUpTemp.Size = New System.Drawing.Size(115, 24)
        Me.txtStartUpTemp.TabIndex = 92
        Me.txtStartUpTemp.TabStop = False
        Me.txtStartUpTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtStartUpTemp.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtStartUpTemp.Visible = False
        '
        'PMProcessStatusPopUpPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(262, 595)
        Me.HeaderHeight = 30
        Me.HeaderStatus = AVPControls.AVPDataLib.DisplayStatus.[On]
        Me.Name = "PMProcessStatusPopUpPanel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PMx Process Status"
        Me.FormContainer.ResumeLayout(False)
        Me.tableContainer.ResumeLayout(False)
        Me.tableContainer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tableContainer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblRFReflected As System.Windows.Forms.Label
    Friend WithEvents lblBeamVoltage As System.Windows.Forms.Label
    Friend WithEvents lblBeamCurrent As System.Windows.Forms.Label
    Friend WithEvents lblSuppressorVoltage As System.Windows.Forms.Label
    Friend WithEvents lblSuppressorCurrent As System.Windows.Forms.Label
    Friend WithEvents lblRFPower As System.Windows.Forms.Label
    Friend WithEvents txtBeamVoltageRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBeamCurrentRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSuppressorVoltageRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSuppressorCurrentRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRFPowerRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRFReflectedRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblPBNDischarge As System.Windows.Forms.Label
    Friend WithEvents txtPBNDischargeRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblPBNBody As System.Windows.Forms.Label
    Friend WithEvents txtPBNBodyRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblKFactor As System.Windows.Forms.Label
    Friend WithEvents txtKFactorRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtKFactorSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblGas2 As System.Windows.Forms.Label
    Friend WithEvents txtGas2RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas2SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblGas1 As System.Windows.Forms.Label
    Friend WithEvents txtGas1RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas1SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblPBNGas As System.Windows.Forms.Label
    Friend WithEvents txtPBNGasRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNGasSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBeamVoltageSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBeamCurrentSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSuppressorVoltageSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRoughToPressure As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRFPowerSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtStartUpTemp As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblTiltAngle As System.Windows.Forms.Label
    Friend WithEvents txtTiltAngleRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtTiltAngleSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblRotationMode As System.Windows.Forms.Label
    Friend WithEvents txtRotatonMode As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblFlowCool As System.Windows.Forms.Label
    Friend WithEvents txtFlowCoolRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtFlowCoolSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblGas3 As System.Windows.Forms.Label
    Friend WithEvents lblGas4 As System.Windows.Forms.Label
    Friend WithEvents txtGas3RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas4RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas3SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtGas4SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPBNDischargeVoltRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNBodyVoltRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtANC As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSourceEMCurrent As System.Windows.Forms.Label
    Friend WithEvents txtSourceEMCurrent As AVP_Robot_Project.SL_Textbox
End Class
