<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDChamberInterlock
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
        Me.lblLidWater = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.bicChuckWater = New AVP_Robot_Project.ButtonIGCGControl
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblPSRelay = New System.Windows.Forms.Label
        Me.bicChamberPress = New AVP_Robot_Project.ButtonIGCGControl
        Me.bicChamberWater = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnPSRelay = New AVP_Robot_Project.ButtonIGCGControl
        Me.bicTargetWater = New AVP_Robot_Project.ButtonIGCGControl
        Me.lblTurboWater = New System.Windows.Forms.Label
        Me.bicTurboWater = New AVP_Robot_Project.ButtonIGCGControl
        Me.lblTurboForeline = New System.Windows.Forms.Label
        Me.bicTurboForeline = New AVP_Robot_Project.ButtonIGCGControl
        Me.lblLidSensor = New System.Windows.Forms.Label
        Me.bicLidSensor = New AVP_Robot_Project.ButtonIGCGControl
        Me.lblTargetWater = New System.Windows.Forms.Label
        Me.bicTargetMBWater = New AVP_Robot_Project.ButtonIGCGControl
        Me.lblTargetMBWater = New System.Windows.Forms.Label
        Me.bicLidWater = New AVP_Robot_Project.ButtonIGCGControl
        Me.lblClampWater = New System.Windows.Forms.Label
        Me.bicSubMBWater = New AVP_Robot_Project.ButtonIGCGControl
        Me.lblSubMBWater = New System.Windows.Forms.Label
        Me.bicClampWater = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Chuck Water"
        '
        'lblLidWater
        '
        Me.lblLidWater.AutoSize = True
        Me.lblLidWater.BackColor = System.Drawing.Color.Transparent
        Me.lblLidWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLidWater.Location = New System.Drawing.Point(2, 97)
        Me.lblLidWater.Name = "lblLidWater"
        Me.lblLidWater.Size = New System.Drawing.Size(77, 19)
        Me.lblLidWater.TabIndex = 11
        Me.lblLidWater.Text = "Lid Water"
        Me.lblLidWater.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(144, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 19)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Cham.Press"
        '
        'bicChuckWater
        '
        Me.bicChuckWater.BackColor = System.Drawing.Color.Transparent
        Me.bicChuckWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicChuckWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicChuckWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicChuckWater.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicChuckWater.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicChuckWater.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicChuckWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicChuckWater.ErrorText = ""
        Me.bicChuckWater.FlatAppearance.BorderSize = 0
        Me.bicChuckWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicChuckWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicChuckWater.ForeColor = System.Drawing.Color.White
        Me.bicChuckWater.Location = New System.Drawing.Point(109, 35)
        Me.bicChuckWater.Name = "bicChuckWater"
        Me.bicChuckWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicChuckWater.OffText = ""
        Me.bicChuckWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicChuckWater.OnText = ""
        Me.bicChuckWater.Size = New System.Drawing.Size(20, 20)
        Me.bicChuckWater.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicChuckWater.StyleOfButton = ButtonStyle.Horizontal
        Me.bicChuckWater.TabIndex = 15
        Me.bicChuckWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicChuckWater.UnKnownText = ""
        Me.bicChuckWater.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 19)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Cham.Water"
        '
        'lblPSRelay
        '
        Me.lblPSRelay.AutoSize = True
        Me.lblPSRelay.BackColor = System.Drawing.Color.Transparent
        Me.lblPSRelay.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPSRelay.Location = New System.Drawing.Point(144, 34)
        Me.lblPSRelay.Name = "lblPSRelay"
        Me.lblPSRelay.Size = New System.Drawing.Size(75, 19)
        Me.lblPSRelay.TabIndex = 14
        Me.lblPSRelay.Text = "P.S Relay"
        '
        'bicChamberPress
        '
        Me.bicChamberPress.BackColor = System.Drawing.Color.Transparent
        Me.bicChamberPress.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicChamberPress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicChamberPress.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicChamberPress.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicChamberPress.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicChamberPress.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicChamberPress.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicChamberPress.ErrorText = ""
        Me.bicChamberPress.FlatAppearance.BorderSize = 0
        Me.bicChamberPress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicChamberPress.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicChamberPress.ForeColor = System.Drawing.Color.White
        Me.bicChamberPress.Location = New System.Drawing.Point(272, 56)
        Me.bicChamberPress.Name = "bicChamberPress"
        Me.bicChamberPress.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicChamberPress.OffText = ""
        Me.bicChamberPress.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicChamberPress.OnText = ""
        Me.bicChamberPress.Size = New System.Drawing.Size(20, 20)
        Me.bicChamberPress.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicChamberPress.StyleOfButton = ButtonStyle.Horizontal
        Me.bicChamberPress.TabIndex = 15
        Me.bicChamberPress.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicChamberPress.UnKnownText = ""
        Me.bicChamberPress.UseVisualStyleBackColor = False
        '
        'bicChamberWater
        '
        Me.bicChamberWater.BackColor = System.Drawing.Color.Transparent
        Me.bicChamberWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicChamberWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicChamberWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicChamberWater.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicChamberWater.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicChamberWater.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicChamberWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicChamberWater.ErrorText = ""
        Me.bicChamberWater.FlatAppearance.BorderSize = 0
        Me.bicChamberWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicChamberWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicChamberWater.ForeColor = System.Drawing.Color.White
        Me.bicChamberWater.Location = New System.Drawing.Point(109, 56)
        Me.bicChamberWater.Name = "bicChamberWater"
        Me.bicChamberWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicChamberWater.OffText = ""
        Me.bicChamberWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicChamberWater.OnText = ""
        Me.bicChamberWater.Size = New System.Drawing.Size(20, 20)
        Me.bicChamberWater.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicChamberWater.StyleOfButton = ButtonStyle.Horizontal
        Me.bicChamberWater.TabIndex = 15
        Me.bicChamberWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicChamberWater.UnKnownText = ""
        Me.bicChamberWater.UseVisualStyleBackColor = False
        '
        'btnPSRelay
        '
        Me.btnPSRelay.BackColor = System.Drawing.Color.Transparent
        Me.btnPSRelay.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnPSRelay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPSRelay.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnPSRelay.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPSRelay.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnPSRelay.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnPSRelay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPSRelay.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnPSRelay.ErrorText = ""
        Me.btnPSRelay.FlatAppearance.BorderSize = 0
        Me.btnPSRelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPSRelay.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPSRelay.ForeColor = System.Drawing.Color.Black
        Me.btnPSRelay.Location = New System.Drawing.Point(248, 32)
        Me.btnPSRelay.Name = "btnPSRelay"
        Me.btnPSRelay.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnPSRelay.OffText = ""
        Me.btnPSRelay.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_On
        Me.btnPSRelay.OnText = ""
        Me.btnPSRelay.Size = New System.Drawing.Size(65, 22)
        Me.btnPSRelay.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnPSRelay.StyleOfButton = ButtonStyle.Horizontal
        Me.btnPSRelay.TabIndex = 15
        Me.btnPSRelay.Text = "On/Off"
        Me.btnPSRelay.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.btnPSRelay.UnKnownText = ""
        Me.btnPSRelay.UseVisualStyleBackColor = False
        '
        'bicTargetWater
        '
        Me.bicTargetWater.BackColor = System.Drawing.Color.Transparent
        Me.bicTargetWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicTargetWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicTargetWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicTargetWater.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicTargetWater.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicTargetWater.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicTargetWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicTargetWater.ErrorText = ""
        Me.bicTargetWater.FlatAppearance.BorderSize = 0
        Me.bicTargetWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTargetWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicTargetWater.ForeColor = System.Drawing.Color.White
        Me.bicTargetWater.Location = New System.Drawing.Point(272, 119)
        Me.bicTargetWater.Name = "bicTargetWater"
        Me.bicTargetWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicTargetWater.OffText = ""
        Me.bicTargetWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicTargetWater.OnText = ""
        Me.bicTargetWater.Size = New System.Drawing.Size(20, 20)
        Me.bicTargetWater.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicTargetWater.StyleOfButton = ButtonStyle.Horizontal
        Me.bicTargetWater.TabIndex = 15
        Me.bicTargetWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicTargetWater.UnKnownText = ""
        Me.bicTargetWater.UseVisualStyleBackColor = False
        Me.bicTargetWater.Visible = False
        '
        'lblTurboWater
        '
        Me.lblTurboWater.AutoSize = True
        Me.lblTurboWater.BackColor = System.Drawing.Color.Transparent
        Me.lblTurboWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurboWater.Location = New System.Drawing.Point(2, 76)
        Me.lblTurboWater.Name = "lblTurboWater"
        Me.lblTurboWater.Size = New System.Drawing.Size(95, 19)
        Me.lblTurboWater.TabIndex = 8
        Me.lblTurboWater.Text = "Turbo Water"
        Me.lblTurboWater.Visible = False
        '
        'bicTurboWater
        '
        Me.bicTurboWater.BackColor = System.Drawing.Color.Transparent
        Me.bicTurboWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicTurboWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicTurboWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicTurboWater.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicTurboWater.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicTurboWater.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicTurboWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicTurboWater.ErrorText = ""
        Me.bicTurboWater.FlatAppearance.BorderSize = 0
        Me.bicTurboWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTurboWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicTurboWater.ForeColor = System.Drawing.Color.White
        Me.bicTurboWater.Location = New System.Drawing.Point(109, 77)
        Me.bicTurboWater.Name = "bicTurboWater"
        Me.bicTurboWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicTurboWater.OffText = ""
        Me.bicTurboWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicTurboWater.OnText = ""
        Me.bicTurboWater.Size = New System.Drawing.Size(20, 20)
        Me.bicTurboWater.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicTurboWater.StyleOfButton = ButtonStyle.Horizontal
        Me.bicTurboWater.TabIndex = 15
        Me.bicTurboWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicTurboWater.UnKnownText = ""
        Me.bicTurboWater.UseVisualStyleBackColor = False
        Me.bicTurboWater.Visible = False
        '
        'lblTurboForeline
        '
        Me.lblTurboForeline.AutoSize = True
        Me.lblTurboForeline.BackColor = System.Drawing.Color.Transparent
        Me.lblTurboForeline.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurboForeline.Location = New System.Drawing.Point(144, 76)
        Me.lblTurboForeline.Name = "lblTurboForeline"
        Me.lblTurboForeline.Size = New System.Drawing.Size(108, 19)
        Me.lblTurboForeline.TabIndex = 8
        Me.lblTurboForeline.Text = "Turbo Foreline"
        Me.lblTurboForeline.Visible = False
        '
        'bicTurboForeline
        '
        Me.bicTurboForeline.BackColor = System.Drawing.Color.Transparent
        Me.bicTurboForeline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicTurboForeline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicTurboForeline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicTurboForeline.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicTurboForeline.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicTurboForeline.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicTurboForeline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicTurboForeline.ErrorText = ""
        Me.bicTurboForeline.FlatAppearance.BorderSize = 0
        Me.bicTurboForeline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTurboForeline.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicTurboForeline.ForeColor = System.Drawing.Color.White
        Me.bicTurboForeline.Location = New System.Drawing.Point(272, 77)
        Me.bicTurboForeline.Name = "bicTurboForeline"
        Me.bicTurboForeline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicTurboForeline.OffText = ""
        Me.bicTurboForeline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicTurboForeline.OnText = ""
        Me.bicTurboForeline.Size = New System.Drawing.Size(20, 20)
        Me.bicTurboForeline.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicTurboForeline.StyleOfButton = ButtonStyle.Horizontal
        Me.bicTurboForeline.TabIndex = 15
        Me.bicTurboForeline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicTurboForeline.UnKnownText = ""
        Me.bicTurboForeline.UseVisualStyleBackColor = False
        Me.bicTurboForeline.Visible = False
        '
        'lblLidSensor
        '
        Me.lblLidSensor.AutoSize = True
        Me.lblLidSensor.BackColor = System.Drawing.Color.Transparent
        Me.lblLidSensor.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLidSensor.Location = New System.Drawing.Point(144, 97)
        Me.lblLidSensor.Name = "lblLidSensor"
        Me.lblLidSensor.Size = New System.Drawing.Size(81, 19)
        Me.lblLidSensor.TabIndex = 8
        Me.lblLidSensor.Text = "Lid Sensor"
        Me.lblLidSensor.Visible = False
        '
        'bicLidSensor
        '
        Me.bicLidSensor.BackColor = System.Drawing.Color.Transparent
        Me.bicLidSensor.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicLidSensor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicLidSensor.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicLidSensor.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicLidSensor.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicLidSensor.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicLidSensor.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicLidSensor.ErrorText = ""
        Me.bicLidSensor.FlatAppearance.BorderSize = 0
        Me.bicLidSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicLidSensor.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicLidSensor.ForeColor = System.Drawing.Color.White
        Me.bicLidSensor.Location = New System.Drawing.Point(272, 98)
        Me.bicLidSensor.Name = "bicLidSensor"
        Me.bicLidSensor.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicLidSensor.OffText = ""
        Me.bicLidSensor.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicLidSensor.OnText = ""
        Me.bicLidSensor.Size = New System.Drawing.Size(20, 20)
        Me.bicLidSensor.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicLidSensor.StyleOfButton = ButtonStyle.Horizontal
        Me.bicLidSensor.TabIndex = 15
        Me.bicLidSensor.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicLidSensor.UnKnownText = ""
        Me.bicLidSensor.UseVisualStyleBackColor = False
        Me.bicLidSensor.Visible = False
        '
        'lblTargetWater
        '
        Me.lblTargetWater.AutoSize = True
        Me.lblTargetWater.BackColor = System.Drawing.Color.Transparent
        Me.lblTargetWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetWater.Location = New System.Drawing.Point(144, 118)
        Me.lblTargetWater.Name = "lblTargetWater"
        Me.lblTargetWater.Size = New System.Drawing.Size(100, 19)
        Me.lblTargetWater.TabIndex = 11
        Me.lblTargetWater.Text = "Target Water"
        Me.lblTargetWater.Visible = False
        '
        'bicTargetMBWater
        '
        Me.bicTargetMBWater.BackColor = System.Drawing.Color.Transparent
        Me.bicTargetMBWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicTargetMBWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicTargetMBWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicTargetMBWater.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicTargetMBWater.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicTargetMBWater.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicTargetMBWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicTargetMBWater.ErrorText = ""
        Me.bicTargetMBWater.FlatAppearance.BorderSize = 0
        Me.bicTargetMBWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTargetMBWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicTargetMBWater.ForeColor = System.Drawing.Color.White
        Me.bicTargetMBWater.Location = New System.Drawing.Point(272, 140)
        Me.bicTargetMBWater.Name = "bicTargetMBWater"
        Me.bicTargetMBWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicTargetMBWater.OffText = ""
        Me.bicTargetMBWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicTargetMBWater.OnText = ""
        Me.bicTargetMBWater.Size = New System.Drawing.Size(20, 20)
        Me.bicTargetMBWater.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicTargetMBWater.StyleOfButton = ButtonStyle.Horizontal
        Me.bicTargetMBWater.TabIndex = 17
        Me.bicTargetMBWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicTargetMBWater.UnKnownText = ""
        Me.bicTargetMBWater.UseVisualStyleBackColor = False
        Me.bicTargetMBWater.Visible = False
        '
        'lblTargetMBWater
        '
        Me.lblTargetMBWater.AutoSize = True
        Me.lblTargetMBWater.BackColor = System.Drawing.Color.Transparent
        Me.lblTargetMBWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetMBWater.Location = New System.Drawing.Point(144, 140)
        Me.lblTargetMBWater.Name = "lblTargetMBWater"
        Me.lblTargetMBWater.Size = New System.Drawing.Size(110, 19)
        Me.lblTargetMBWater.TabIndex = 16
        Me.lblTargetMBWater.Text = "Tar.MB Water"
        Me.lblTargetMBWater.Visible = False
        '
        'bicLidWater
        '
        Me.bicLidWater.BackColor = System.Drawing.Color.Transparent
        Me.bicLidWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicLidWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicLidWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicLidWater.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicLidWater.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicLidWater.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicLidWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicLidWater.ErrorText = ""
        Me.bicLidWater.FlatAppearance.BorderSize = 0
        Me.bicLidWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicLidWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicLidWater.ForeColor = System.Drawing.Color.White
        Me.bicLidWater.Location = New System.Drawing.Point(109, 98)
        Me.bicLidWater.Name = "bicLidWater"
        Me.bicLidWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicLidWater.OffText = ""
        Me.bicLidWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicLidWater.OnText = ""
        Me.bicLidWater.Size = New System.Drawing.Size(20, 20)
        Me.bicLidWater.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicLidWater.StyleOfButton = ButtonStyle.Horizontal
        Me.bicLidWater.TabIndex = 19
        Me.bicLidWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicLidWater.UnKnownText = ""
        Me.bicLidWater.UseVisualStyleBackColor = False
        Me.bicLidWater.Visible = False
        '
        'lblClampWater
        '
        Me.lblClampWater.AutoSize = True
        Me.lblClampWater.BackColor = System.Drawing.Color.Transparent
        Me.lblClampWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClampWater.Location = New System.Drawing.Point(2, 118)
        Me.lblClampWater.Name = "lblClampWater"
        Me.lblClampWater.Size = New System.Drawing.Size(98, 19)
        Me.lblClampWater.TabIndex = 18
        Me.lblClampWater.Text = "Clamp Water"
        Me.lblClampWater.Visible = False
        '
        'bicSubMBWater
        '
        Me.bicSubMBWater.BackColor = System.Drawing.Color.Transparent
        Me.bicSubMBWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicSubMBWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicSubMBWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicSubMBWater.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicSubMBWater.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicSubMBWater.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicSubMBWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicSubMBWater.ErrorText = ""
        Me.bicSubMBWater.FlatAppearance.BorderSize = 0
        Me.bicSubMBWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicSubMBWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicSubMBWater.ForeColor = System.Drawing.Color.White
        Me.bicSubMBWater.Location = New System.Drawing.Point(109, 140)
        Me.bicSubMBWater.Name = "bicSubMBWater"
        Me.bicSubMBWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicSubMBWater.OffText = ""
        Me.bicSubMBWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicSubMBWater.OnText = ""
        Me.bicSubMBWater.Size = New System.Drawing.Size(20, 20)
        Me.bicSubMBWater.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicSubMBWater.StyleOfButton = ButtonStyle.Horizontal
        Me.bicSubMBWater.TabIndex = 21
        Me.bicSubMBWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicSubMBWater.UnKnownText = ""
        Me.bicSubMBWater.UseVisualStyleBackColor = False
        Me.bicSubMBWater.Visible = False
        '
        'lblSubMBWater
        '
        Me.lblSubMBWater.AutoSize = True
        Me.lblSubMBWater.BackColor = System.Drawing.Color.Transparent
        Me.lblSubMBWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubMBWater.Location = New System.Drawing.Point(2, 140)
        Me.lblSubMBWater.Name = "lblSubMBWater"
        Me.lblSubMBWater.Size = New System.Drawing.Size(111, 19)
        Me.lblSubMBWater.TabIndex = 20
        Me.lblSubMBWater.Text = "Sub MB Water"
        Me.lblSubMBWater.Visible = False
        '
        'bicClampWater
        '
        Me.bicClampWater.BackColor = System.Drawing.Color.Transparent
        Me.bicClampWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicClampWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicClampWater.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicClampWater.ColorText_OffStatus = System.Drawing.Color.White
        Me.bicClampWater.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicClampWater.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicClampWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.bicClampWater.ErrorText = ""
        Me.bicClampWater.FlatAppearance.BorderSize = 0
        Me.bicClampWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicClampWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicClampWater.ForeColor = System.Drawing.Color.White
        Me.bicClampWater.Location = New System.Drawing.Point(109, 119)
        Me.bicClampWater.Name = "bicClampWater"
        Me.bicClampWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicClampWater.OffText = ""
        Me.bicClampWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicClampWater.OnText = ""
        Me.bicClampWater.Size = New System.Drawing.Size(20, 20)
        Me.bicClampWater.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicClampWater.StyleOfButton = ButtonStyle.Horizontal
        Me.bicClampWater.TabIndex = 23
        Me.bicClampWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicClampWater.UnKnownText = ""
        Me.bicClampWater.UseVisualStyleBackColor = False
        Me.bicClampWater.Visible = False
        '
        'PVDChamberInterlock
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.bicClampWater)
        Me.Controls.Add(Me.bicSubMBWater)
        Me.Controls.Add(Me.lblSubMBWater)
        Me.Controls.Add(Me.bicLidWater)
        Me.Controls.Add(Me.lblClampWater)
        Me.Controls.Add(Me.bicTargetMBWater)
        Me.Controls.Add(Me.bicTurboWater)
        Me.Controls.Add(Me.lblTargetMBWater)
        Me.Controls.Add(Me.bicTargetWater)
        Me.Controls.Add(Me.bicLidSensor)
        Me.Controls.Add(Me.bicTurboForeline)
        Me.Controls.Add(Me.bicChamberWater)
        Me.Controls.Add(Me.btnPSRelay)
        Me.Controls.Add(Me.bicChamberPress)
        Me.Controls.Add(Me.bicChuckWater)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblPSRelay)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTurboWater)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblLidSensor)
        Me.Controls.Add(Me.lblTurboForeline)
        Me.Controls.Add(Me.lblTargetWater)
        Me.Controls.Add(Me.lblLidWater)
        Me.DoubleBuffered = True
        Me.HeaderHeight = 28
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "PVDChamberInterlock"
        Me.Size = New System.Drawing.Size(316, 166)
        Me.Text = "Interlocks"
        Me.Controls.SetChildIndex(Me.lblLidWater, 0)
        Me.Controls.SetChildIndex(Me.lblTargetWater, 0)
        Me.Controls.SetChildIndex(Me.lblTurboForeline, 0)
        Me.Controls.SetChildIndex(Me.lblLidSensor, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblTurboWater, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.lblPSRelay, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.bicChuckWater, 0)
        Me.Controls.SetChildIndex(Me.bicChamberPress, 0)
        Me.Controls.SetChildIndex(Me.btnPSRelay, 0)
        Me.Controls.SetChildIndex(Me.bicChamberWater, 0)
        Me.Controls.SetChildIndex(Me.bicTurboForeline, 0)
        Me.Controls.SetChildIndex(Me.bicLidSensor, 0)
        Me.Controls.SetChildIndex(Me.bicTargetWater, 0)
        Me.Controls.SetChildIndex(Me.lblTargetMBWater, 0)
        Me.Controls.SetChildIndex(Me.bicTurboWater, 0)
        Me.Controls.SetChildIndex(Me.bicTargetMBWater, 0)
        Me.Controls.SetChildIndex(Me.lblClampWater, 0)
        Me.Controls.SetChildIndex(Me.bicLidWater, 0)
        Me.Controls.SetChildIndex(Me.lblSubMBWater, 0)
        Me.Controls.SetChildIndex(Me.bicSubMBWater, 0)
        Me.Controls.SetChildIndex(Me.bicClampWater, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLidWater As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents bicChuckWater As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPSRelay As System.Windows.Forms.Label
    Friend WithEvents bicChamberPress As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents bicChamberWater As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnPSRelay As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents bicTargetWater As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents lblTurboWater As System.Windows.Forms.Label
    Friend WithEvents bicTurboWater As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents lblTurboForeline As System.Windows.Forms.Label
    Friend WithEvents bicTurboForeline As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents lblLidSensor As System.Windows.Forms.Label
    Friend WithEvents bicLidSensor As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents lblTargetWater As System.Windows.Forms.Label
    Friend WithEvents bicTargetMBWater As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents lblTargetMBWater As System.Windows.Forms.Label
    Friend WithEvents bicLidWater As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents lblClampWater As System.Windows.Forms.Label
    Friend WithEvents bicSubMBWater As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents lblSubMBWater As System.Windows.Forms.Label
    Friend WithEvents bicClampWater As AVP_Robot_Project.ButtonIGCGControl

End Class
