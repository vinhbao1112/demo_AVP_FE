<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CORONA_ChamberInterlock
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
        Me.lblDoorClosed = New System.Windows.Forms.Label
        Me.bicDoorClosed = New AVP_Robot_Project.SL_CustomButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblLidClosed = New System.Windows.Forms.Label
        Me.bicLidClosed = New AVP_Robot_Project.SL_CustomButton
        Me.lblTargetPanels = New System.Windows.Forms.Label
        Me.bicTargetPanels = New AVP_Robot_Project.SL_CustomButton
        Me.lblAirPressure = New System.Windows.Forms.Label
        Me.bicAirPressure = New AVP_Robot_Project.SL_CustomButton
        Me.lblSubTableWater = New System.Windows.Forms.Label
        Me.bicSubTableWater = New AVP_Robot_Project.SL_CustomButton
        Me.lblDeviceNetCom = New System.Windows.Forms.Label
        Me.bicDeviceNetCom = New AVP_Robot_Project.SL_CustomButton
        Me.lblTurboWater = New System.Windows.Forms.Label
        Me.bicTurboWater = New AVP_Robot_Project.SL_CustomButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.bicChamberPress = New AVP_Robot_Project.SL_CustomButton
        Me.lblTurboForeline = New System.Windows.Forms.Label
        Me.bicTurboForeline = New AVP_Robot_Project.SL_CustomButton
        Me.lblMB1Water = New System.Windows.Forms.Label
        Me.bicTargetMBWater = New AVP_Robot_Project.SL_CustomButton
        Me.lblMB2Water = New System.Windows.Forms.Label
        Me.bicBiasMBWater = New AVP_Robot_Project.SL_CustomButton
        Me.lblTarget1Water = New System.Windows.Forms.Label
        Me.bicTarget1_3Water = New AVP_Robot_Project.SL_CustomButton
        Me.lblTarget2Water = New System.Windows.Forms.Label
        Me.bicTarget2_4Water = New AVP_Robot_Project.SL_CustomButton
        Me.lblPSRelay = New System.Windows.Forms.Label
        Me.btnPSRelay = New AVP_Robot_Project.SL_CustomButton
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDoorClosed
        '
        Me.lblDoorClosed.AutoSize = True
        Me.lblDoorClosed.BackColor = System.Drawing.Color.Transparent
        Me.lblDoorClosed.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoorClosed.Location = New System.Drawing.Point(5, 215)
        Me.lblDoorClosed.Name = "lblDoorClosed"
        Me.lblDoorClosed.Size = New System.Drawing.Size(93, 19)
        Me.lblDoorClosed.TabIndex = 8
        Me.lblDoorClosed.Text = "Door Closed"
        Me.lblDoorClosed.Visible = False
        '
        'bicDoorClosed
        '
        Me.bicDoorClosed.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicDoorClosed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicDoorClosed.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicDoorClosed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicDoorClosed.Enabled = False
        Me.bicDoorClosed.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicDoorClosed.FlatAppearance.BorderSize = 0
        Me.bicDoorClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicDoorClosed.ForeColor = System.Drawing.Color.White
        Me.bicDoorClosed.Location = New System.Drawing.Point(129, 216)
        Me.bicDoorClosed.MessageBoxText = Nothing
        Me.bicDoorClosed.Name = "bicDoorClosed"
        Me.bicDoorClosed.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicDoorClosed.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicDoorClosed.Size = New System.Drawing.Size(16, 16)
        Me.bicDoorClosed.TabIndex = 25
        Me.bicDoorClosed.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicDoorClosed.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicDoorClosed.UseVisualStyleBackColor = True
        Me.bicDoorClosed.ValueToBeSend = "On"
        Me.bicDoorClosed.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(325, 170)
        Me.Panel1.TabIndex = 28
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblLidClosed)
        Me.Panel3.Controls.Add(Me.bicLidClosed)
        Me.Panel3.Controls.Add(Me.lblTargetPanels)
        Me.Panel3.Controls.Add(Me.bicTargetPanels)
        Me.Panel3.Controls.Add(Me.lblAirPressure)
        Me.Panel3.Controls.Add(Me.bicAirPressure)
        Me.Panel3.Controls.Add(Me.lblSubTableWater)
        Me.Panel3.Controls.Add(Me.bicSubTableWater)
        Me.Panel3.Controls.Add(Me.lblDeviceNetCom)
        Me.Panel3.Controls.Add(Me.bicDeviceNetCom)
        Me.Panel3.Controls.Add(Me.lblTurboWater)
        Me.Panel3.Controls.Add(Me.bicTurboWater)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.bicChamberPress)
        Me.Panel3.Controls.Add(Me.lblTurboForeline)
        Me.Panel3.Controls.Add(Me.bicTurboForeline)
        Me.Panel3.Controls.Add(Me.lblMB1Water)
        Me.Panel3.Controls.Add(Me.bicTargetMBWater)
        Me.Panel3.Controls.Add(Me.lblMB2Water)
        Me.Panel3.Controls.Add(Me.bicBiasMBWater)
        Me.Panel3.Controls.Add(Me.lblTarget1Water)
        Me.Panel3.Controls.Add(Me.bicTarget1_3Water)
        Me.Panel3.Controls.Add(Me.lblTarget2Water)
        Me.Panel3.Controls.Add(Me.bicTarget2_4Water)
        Me.Panel3.Controls.Add(Me.lblPSRelay)
        Me.Panel3.Controls.Add(Me.btnPSRelay)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(325, 170)
        Me.Panel3.TabIndex = 1
        '
        'lblLidClosed
        '
        Me.lblLidClosed.AutoSize = True
        Me.lblLidClosed.BackColor = System.Drawing.Color.Transparent
        Me.lblLidClosed.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLidClosed.Location = New System.Drawing.Point(3, 25)
        Me.lblLidClosed.Name = "lblLidClosed"
        Me.lblLidClosed.Size = New System.Drawing.Size(119, 19)
        Me.lblLidClosed.TabIndex = 49
        Me.lblLidClosed.Text = "Door/Lid Closed"
        '
        'bicLidClosed
        '
        Me.bicLidClosed.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicLidClosed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicLidClosed.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicLidClosed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicLidClosed.Enabled = False
        Me.bicLidClosed.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicLidClosed.FlatAppearance.BorderSize = 0
        Me.bicLidClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicLidClosed.ForeColor = System.Drawing.Color.White
        Me.bicLidClosed.Location = New System.Drawing.Point(142, 26)
        Me.bicLidClosed.MessageBoxText = Nothing
        Me.bicLidClosed.Name = "bicLidClosed"
        Me.bicLidClosed.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicLidClosed.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicLidClosed.Size = New System.Drawing.Size(16, 16)
        Me.bicLidClosed.TabIndex = 50
        Me.bicLidClosed.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicLidClosed.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicLidClosed.UseVisualStyleBackColor = True
        Me.bicLidClosed.ValueToBeSend = "On"
        '
        'lblTargetPanels
        '
        Me.lblTargetPanels.AutoSize = True
        Me.lblTargetPanels.BackColor = System.Drawing.Color.Transparent
        Me.lblTargetPanels.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetPanels.Location = New System.Drawing.Point(3, 4)
        Me.lblTargetPanels.Name = "lblTargetPanels"
        Me.lblTargetPanels.Size = New System.Drawing.Size(101, 19)
        Me.lblTargetPanels.TabIndex = 47
        Me.lblTargetPanels.Text = "Target Panels"
        '
        'bicTargetPanels
        '
        Me.bicTargetPanels.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTargetPanels.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicTargetPanels.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicTargetPanels.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicTargetPanels.Enabled = False
        Me.bicTargetPanels.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicTargetPanels.FlatAppearance.BorderSize = 0
        Me.bicTargetPanels.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTargetPanels.ForeColor = System.Drawing.Color.White
        Me.bicTargetPanels.Location = New System.Drawing.Point(142, 5)
        Me.bicTargetPanels.MessageBoxText = Nothing
        Me.bicTargetPanels.Name = "bicTargetPanels"
        Me.bicTargetPanels.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTargetPanels.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicTargetPanels.Size = New System.Drawing.Size(16, 16)
        Me.bicTargetPanels.TabIndex = 48
        Me.bicTargetPanels.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicTargetPanels.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicTargetPanels.UseVisualStyleBackColor = True
        Me.bicTargetPanels.ValueToBeSend = "On"
        '
        'lblAirPressure
        '
        Me.lblAirPressure.AutoSize = True
        Me.lblAirPressure.BackColor = System.Drawing.Color.Transparent
        Me.lblAirPressure.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAirPressure.Location = New System.Drawing.Point(3, 88)
        Me.lblAirPressure.Name = "lblAirPressure"
        Me.lblAirPressure.Size = New System.Drawing.Size(93, 19)
        Me.lblAirPressure.TabIndex = 45
        Me.lblAirPressure.Text = "Air Pressure"
        '
        'bicAirPressure
        '
        Me.bicAirPressure.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicAirPressure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicAirPressure.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicAirPressure.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicAirPressure.Enabled = False
        Me.bicAirPressure.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicAirPressure.FlatAppearance.BorderSize = 0
        Me.bicAirPressure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicAirPressure.ForeColor = System.Drawing.Color.White
        Me.bicAirPressure.Location = New System.Drawing.Point(142, 89)
        Me.bicAirPressure.MessageBoxText = Nothing
        Me.bicAirPressure.Name = "bicAirPressure"
        Me.bicAirPressure.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicAirPressure.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicAirPressure.Size = New System.Drawing.Size(16, 16)
        Me.bicAirPressure.TabIndex = 46
        Me.bicAirPressure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicAirPressure.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicAirPressure.UseVisualStyleBackColor = True
        Me.bicAirPressure.ValueToBeSend = "On"
        '
        'lblSubTableWater
        '
        Me.lblSubTableWater.AutoSize = True
        Me.lblSubTableWater.BackColor = System.Drawing.Color.Transparent
        Me.lblSubTableWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTableWater.Location = New System.Drawing.Point(3, 67)
        Me.lblSubTableWater.Name = "lblSubTableWater"
        Me.lblSubTableWater.Size = New System.Drawing.Size(120, 19)
        Me.lblSubTableWater.TabIndex = 43
        Me.lblSubTableWater.Text = "Sub Table Water"
        '
        'bicSubTableWater
        '
        Me.bicSubTableWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicSubTableWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicSubTableWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicSubTableWater.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicSubTableWater.Enabled = False
        Me.bicSubTableWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicSubTableWater.FlatAppearance.BorderSize = 0
        Me.bicSubTableWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicSubTableWater.ForeColor = System.Drawing.Color.White
        Me.bicSubTableWater.Location = New System.Drawing.Point(142, 68)
        Me.bicSubTableWater.MessageBoxText = Nothing
        Me.bicSubTableWater.Name = "bicSubTableWater"
        Me.bicSubTableWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicSubTableWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicSubTableWater.Size = New System.Drawing.Size(16, 16)
        Me.bicSubTableWater.TabIndex = 44
        Me.bicSubTableWater.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicSubTableWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicSubTableWater.UseVisualStyleBackColor = True
        Me.bicSubTableWater.ValueToBeSend = "On"
        '
        'lblDeviceNetCom
        '
        Me.lblDeviceNetCom.AutoSize = True
        Me.lblDeviceNetCom.BackColor = System.Drawing.Color.Transparent
        Me.lblDeviceNetCom.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeviceNetCom.Location = New System.Drawing.Point(3, 46)
        Me.lblDeviceNetCom.Name = "lblDeviceNetCom"
        Me.lblDeviceNetCom.Size = New System.Drawing.Size(120, 19)
        Me.lblDeviceNetCom.TabIndex = 41
        Me.lblDeviceNetCom.Text = "Device Net Com"
        '
        'bicDeviceNetCom
        '
        Me.bicDeviceNetCom.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicDeviceNetCom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicDeviceNetCom.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicDeviceNetCom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicDeviceNetCom.Enabled = False
        Me.bicDeviceNetCom.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicDeviceNetCom.FlatAppearance.BorderSize = 0
        Me.bicDeviceNetCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicDeviceNetCom.ForeColor = System.Drawing.Color.White
        Me.bicDeviceNetCom.Location = New System.Drawing.Point(142, 47)
        Me.bicDeviceNetCom.MessageBoxText = Nothing
        Me.bicDeviceNetCom.Name = "bicDeviceNetCom"
        Me.bicDeviceNetCom.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicDeviceNetCom.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicDeviceNetCom.Size = New System.Drawing.Size(16, 16)
        Me.bicDeviceNetCom.TabIndex = 42
        Me.bicDeviceNetCom.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicDeviceNetCom.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicDeviceNetCom.UseVisualStyleBackColor = True
        Me.bicDeviceNetCom.ValueToBeSend = "On"
        '
        'lblTurboWater
        '
        Me.lblTurboWater.AutoSize = True
        Me.lblTurboWater.BackColor = System.Drawing.Color.Transparent
        Me.lblTurboWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurboWater.Location = New System.Drawing.Point(3, 109)
        Me.lblTurboWater.Name = "lblTurboWater"
        Me.lblTurboWater.Size = New System.Drawing.Size(93, 19)
        Me.lblTurboWater.TabIndex = 39
        Me.lblTurboWater.Text = "Turbo Water"
        '
        'bicTurboWater
        '
        Me.bicTurboWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTurboWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicTurboWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicTurboWater.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicTurboWater.Enabled = False
        Me.bicTurboWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicTurboWater.FlatAppearance.BorderSize = 0
        Me.bicTurboWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTurboWater.ForeColor = System.Drawing.Color.White
        Me.bicTurboWater.Location = New System.Drawing.Point(142, 110)
        Me.bicTurboWater.MessageBoxText = Nothing
        Me.bicTurboWater.Name = "bicTurboWater"
        Me.bicTurboWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTurboWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicTurboWater.Size = New System.Drawing.Size(16, 16)
        Me.bicTurboWater.TabIndex = 40
        Me.bicTurboWater.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicTurboWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicTurboWater.UseVisualStyleBackColor = True
        Me.bicTurboWater.ValueToBeSend = "On"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(161, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 19)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Cham.Press"
        '
        'bicChamberPress
        '
        Me.bicChamberPress.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicChamberPress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicChamberPress.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicChamberPress.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicChamberPress.Enabled = False
        Me.bicChamberPress.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicChamberPress.FlatAppearance.BorderSize = 0
        Me.bicChamberPress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicChamberPress.ForeColor = System.Drawing.Color.White
        Me.bicChamberPress.Location = New System.Drawing.Point(301, 5)
        Me.bicChamberPress.MessageBoxText = Nothing
        Me.bicChamberPress.Name = "bicChamberPress"
        Me.bicChamberPress.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicChamberPress.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicChamberPress.Size = New System.Drawing.Size(16, 16)
        Me.bicChamberPress.TabIndex = 38
        Me.bicChamberPress.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicChamberPress.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicChamberPress.UseVisualStyleBackColor = True
        Me.bicChamberPress.ValueToBeSend = "On"
        '
        'lblTurboForeline
        '
        Me.lblTurboForeline.AutoSize = True
        Me.lblTurboForeline.BackColor = System.Drawing.Color.Transparent
        Me.lblTurboForeline.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurboForeline.Location = New System.Drawing.Point(161, 25)
        Me.lblTurboForeline.Name = "lblTurboForeline"
        Me.lblTurboForeline.Size = New System.Drawing.Size(107, 19)
        Me.lblTurboForeline.TabIndex = 35
        Me.lblTurboForeline.Text = "Turbo Foreline"
        '
        'bicTurboForeline
        '
        Me.bicTurboForeline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTurboForeline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicTurboForeline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicTurboForeline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicTurboForeline.Enabled = False
        Me.bicTurboForeline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicTurboForeline.FlatAppearance.BorderSize = 0
        Me.bicTurboForeline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTurboForeline.ForeColor = System.Drawing.Color.White
        Me.bicTurboForeline.Location = New System.Drawing.Point(301, 26)
        Me.bicTurboForeline.MessageBoxText = Nothing
        Me.bicTurboForeline.Name = "bicTurboForeline"
        Me.bicTurboForeline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTurboForeline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicTurboForeline.Size = New System.Drawing.Size(16, 16)
        Me.bicTurboForeline.TabIndex = 36
        Me.bicTurboForeline.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicTurboForeline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicTurboForeline.UseVisualStyleBackColor = True
        Me.bicTurboForeline.ValueToBeSend = "On"
        '
        'lblMB1Water
        '
        Me.lblMB1Water.AutoSize = True
        Me.lblMB1Water.BackColor = System.Drawing.Color.Transparent
        Me.lblMB1Water.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMB1Water.Location = New System.Drawing.Point(161, 46)
        Me.lblMB1Water.Name = "lblMB1Water"
        Me.lblMB1Water.Size = New System.Drawing.Size(129, 19)
        Me.lblMB1Water.TabIndex = 33
        Me.lblMB1Water.Text = "Target MB Water"
        '
        'bicTargetMBWater
        '
        Me.bicTargetMBWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTargetMBWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicTargetMBWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicTargetMBWater.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicTargetMBWater.Enabled = False
        Me.bicTargetMBWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicTargetMBWater.FlatAppearance.BorderSize = 0
        Me.bicTargetMBWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTargetMBWater.ForeColor = System.Drawing.Color.White
        Me.bicTargetMBWater.Location = New System.Drawing.Point(301, 47)
        Me.bicTargetMBWater.MessageBoxText = Nothing
        Me.bicTargetMBWater.Name = "bicTargetMBWater"
        Me.bicTargetMBWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTargetMBWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicTargetMBWater.Size = New System.Drawing.Size(16, 16)
        Me.bicTargetMBWater.TabIndex = 34
        Me.bicTargetMBWater.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicTargetMBWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicTargetMBWater.UseVisualStyleBackColor = True
        Me.bicTargetMBWater.ValueToBeSend = "On"
        '
        'lblMB2Water
        '
        Me.lblMB2Water.AutoSize = True
        Me.lblMB2Water.BackColor = System.Drawing.Color.Transparent
        Me.lblMB2Water.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMB2Water.Location = New System.Drawing.Point(162, 67)
        Me.lblMB2Water.Name = "lblMB2Water"
        Me.lblMB2Water.Size = New System.Drawing.Size(115, 19)
        Me.lblMB2Water.TabIndex = 31
        Me.lblMB2Water.Text = "Bias MB Water"
        '
        'bicBiasMBWater
        '
        Me.bicBiasMBWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicBiasMBWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicBiasMBWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicBiasMBWater.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicBiasMBWater.Enabled = False
        Me.bicBiasMBWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicBiasMBWater.FlatAppearance.BorderSize = 0
        Me.bicBiasMBWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicBiasMBWater.ForeColor = System.Drawing.Color.White
        Me.bicBiasMBWater.Location = New System.Drawing.Point(301, 68)
        Me.bicBiasMBWater.MessageBoxText = Nothing
        Me.bicBiasMBWater.Name = "bicBiasMBWater"
        Me.bicBiasMBWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicBiasMBWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicBiasMBWater.Size = New System.Drawing.Size(16, 16)
        Me.bicBiasMBWater.TabIndex = 32
        Me.bicBiasMBWater.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicBiasMBWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicBiasMBWater.UseVisualStyleBackColor = True
        Me.bicBiasMBWater.ValueToBeSend = "On"
        '
        'lblTarget1Water
        '
        Me.lblTarget1Water.AutoSize = True
        Me.lblTarget1Water.BackColor = System.Drawing.Color.Transparent
        Me.lblTarget1Water.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTarget1Water.Location = New System.Drawing.Point(162, 88)
        Me.lblTarget1Water.Name = "lblTarget1Water"
        Me.lblTarget1Water.Size = New System.Drawing.Size(139, 19)
        Me.lblTarget1Water.TabIndex = 29
        Me.lblTarget1Water.Text = "Target 1 && 3 Water"
        '
        'bicTarget1_3Water
        '
        Me.bicTarget1_3Water.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTarget1_3Water.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicTarget1_3Water.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicTarget1_3Water.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicTarget1_3Water.Enabled = False
        Me.bicTarget1_3Water.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicTarget1_3Water.FlatAppearance.BorderSize = 0
        Me.bicTarget1_3Water.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTarget1_3Water.ForeColor = System.Drawing.Color.White
        Me.bicTarget1_3Water.Location = New System.Drawing.Point(301, 89)
        Me.bicTarget1_3Water.MessageBoxText = Nothing
        Me.bicTarget1_3Water.Name = "bicTarget1_3Water"
        Me.bicTarget1_3Water.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTarget1_3Water.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicTarget1_3Water.Size = New System.Drawing.Size(16, 16)
        Me.bicTarget1_3Water.TabIndex = 30
        Me.bicTarget1_3Water.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicTarget1_3Water.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicTarget1_3Water.UseVisualStyleBackColor = True
        Me.bicTarget1_3Water.ValueToBeSend = "On"
        '
        'lblTarget2Water
        '
        Me.lblTarget2Water.AutoSize = True
        Me.lblTarget2Water.BackColor = System.Drawing.Color.Transparent
        Me.lblTarget2Water.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTarget2Water.Location = New System.Drawing.Point(162, 109)
        Me.lblTarget2Water.Name = "lblTarget2Water"
        Me.lblTarget2Water.Size = New System.Drawing.Size(139, 19)
        Me.lblTarget2Water.TabIndex = 27
        Me.lblTarget2Water.Text = "Target 2 && 4 Water"
        '
        'bicTarget2_4Water
        '
        Me.bicTarget2_4Water.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTarget2_4Water.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicTarget2_4Water.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicTarget2_4Water.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicTarget2_4Water.Enabled = False
        Me.bicTarget2_4Water.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.bicTarget2_4Water.FlatAppearance.BorderSize = 0
        Me.bicTarget2_4Water.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTarget2_4Water.ForeColor = System.Drawing.Color.White
        Me.bicTarget2_4Water.Location = New System.Drawing.Point(301, 110)
        Me.bicTarget2_4Water.MessageBoxText = Nothing
        Me.bicTarget2_4Water.Name = "bicTarget2_4Water"
        Me.bicTarget2_4Water.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.bicTarget2_4Water.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.bicTarget2_4Water.Size = New System.Drawing.Size(16, 16)
        Me.bicTarget2_4Water.TabIndex = 28
        Me.bicTarget2_4Water.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.bicTarget2_4Water.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.bicTarget2_4Water.UseVisualStyleBackColor = True
        Me.bicTarget2_4Water.ValueToBeSend = "On"
        '
        'lblPSRelay
        '
        Me.lblPSRelay.AutoSize = True
        Me.lblPSRelay.BackColor = System.Drawing.Color.Transparent
        Me.lblPSRelay.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPSRelay.Location = New System.Drawing.Point(3, 130)
        Me.lblPSRelay.Name = "lblPSRelay"
        Me.lblPSRelay.Size = New System.Drawing.Size(95, 19)
        Me.lblPSRelay.TabIndex = 25
        Me.lblPSRelay.Text = "P.S Interlock"
        '
        'btnPSRelay
        '
        Me.btnPSRelay.AccessibleDescription = "PS Relay"
        Me.btnPSRelay.AccessibleName = "PSRelay"
        Me.btnPSRelay.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPSRelay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPSRelay.Clickable = True
        Me.btnPSRelay.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnPSRelay.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPSRelay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPSRelay.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnPSRelay.FlatAppearance.BorderSize = 0
        Me.btnPSRelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPSRelay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnPSRelay.ForeColor = System.Drawing.Color.Black
        Me.btnPSRelay.IsNotValve = True
        Me.btnPSRelay.Location = New System.Drawing.Point(98, 127)
        Me.btnPSRelay.MessageBoxText = Nothing
        Me.btnPSRelay.Name = "btnPSRelay"
        Me.btnPSRelay.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPSRelay.OffText = "On/Off"
        Me.btnPSRelay.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnPSRelay.OnText = "On/Off"
        Me.btnPSRelay.Size = New System.Drawing.Size(63, 23)
        Me.btnPSRelay.TabIndex = 26
        Me.btnPSRelay.Text = "On/Off"
        Me.btnPSRelay.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnPSRelay.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnPSRelay.UseChangeValueToSend_BaseOnStatus = True
        Me.btnPSRelay.UseVisualStyleBackColor = True
        Me.btnPSRelay.ValueToBeSend = "On"
        '
        'CORONA_ChamberInterlock
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.bicDoorClosed)
        Me.Controls.Add(Me.lblDoorClosed)
        Me.DoubleBuffered = True
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "CORONA_ChamberInterlock"
        Me.Size = New System.Drawing.Size(325, 201)
        Me.Text = "Interlocks"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.lblDoorClosed, 0)
        Me.Controls.SetChildIndex(Me.bicDoorClosed, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDoorClosed As System.Windows.Forms.Label
    Friend WithEvents bicDoorClosed As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents bicChamberPress As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblTurboForeline As System.Windows.Forms.Label
    Friend WithEvents bicTurboForeline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblMB1Water As System.Windows.Forms.Label
    Friend WithEvents bicTargetMBWater As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblMB2Water As System.Windows.Forms.Label
    Friend WithEvents bicBiasMBWater As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblTarget1Water As System.Windows.Forms.Label
    Friend WithEvents bicTarget1_3Water As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblTarget2Water As System.Windows.Forms.Label
    Friend WithEvents bicTarget2_4Water As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblPSRelay As System.Windows.Forms.Label
    Friend WithEvents btnPSRelay As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblLidClosed As System.Windows.Forms.Label
    Friend WithEvents bicLidClosed As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblTargetPanels As System.Windows.Forms.Label
    Friend WithEvents bicTargetPanels As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblAirPressure As System.Windows.Forms.Label
    Friend WithEvents bicAirPressure As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblSubTableWater As System.Windows.Forms.Label
    Friend WithEvents bicSubTableWater As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblDeviceNetCom As System.Windows.Forms.Label
    Friend WithEvents bicDeviceNetCom As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblTurboWater As System.Windows.Forms.Label
    Friend WithEvents bicTurboWater As AVP_Robot_Project.SL_CustomButton

End Class
