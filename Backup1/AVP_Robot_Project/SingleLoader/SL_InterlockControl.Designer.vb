<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_InterlockControl
    Inherits AVP_Robot_Project.PVDStatusBoard

    'UserControl overrides dispose to clean up the component list.
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
        Me.btnSource = New AVP_Robot_Project.SL_CustomButton
        Me.btnAirPressure = New AVP_Robot_Project.SL_CustomButton
        Me.btnPanels = New AVP_Robot_Project.SL_CustomButton
        Me.btnTurboWater = New AVP_Robot_Project.SL_CustomButton
        Me.btnFixtureWater = New AVP_Robot_Project.SL_CustomButton
        Me.btnForelinePress = New AVP_Robot_Project.SL_CustomButton
        Me.btnChamPress = New AVP_Robot_Project.SL_CustomButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblSource = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblChamberLid = New System.Windows.Forms.Label
        Me.lblAirPressure = New System.Windows.Forms.Label
        Me.lblTurboWater = New System.Windows.Forms.Label
        Me.btnFixtureWaterBug = New AVP_Robot_Project.SL_CustomButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Font = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Size = New System.Drawing.Size(324, 27)
        Me.Header.Text = "Interlocks"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'btnSource
        '
        Me.btnSource.BackColor = System.Drawing.Color.Transparent
        Me.btnSource.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSource.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnSource.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnSource.FlatAppearance.BorderSize = 0
        Me.btnSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSource.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSource.ForeColor = System.Drawing.Color.White
        Me.btnSource.Location = New System.Drawing.Point(137, 37)
        Me.btnSource.MessageBoxText = Nothing
        Me.btnSource.Name = "btnSource"
        Me.btnSource.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnSource.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnSource.Size = New System.Drawing.Size(15, 15)
        Me.btnSource.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnSource.TabIndex = 31
        Me.btnSource.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnSource.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnSource.UseVisualStyleBackColor = False
        Me.btnSource.ValueToBeSend = "On"
        '
        'btnAirPressure
        '
        Me.btnAirPressure.BackColor = System.Drawing.Color.Transparent
        Me.btnAirPressure.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnAirPressure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAirPressure.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnAirPressure.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnAirPressure.FlatAppearance.BorderSize = 0
        Me.btnAirPressure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAirPressure.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAirPressure.ForeColor = System.Drawing.Color.White
        Me.btnAirPressure.Location = New System.Drawing.Point(137, 97)
        Me.btnAirPressure.MessageBoxText = Nothing
        Me.btnAirPressure.Name = "btnAirPressure"
        Me.btnAirPressure.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnAirPressure.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnAirPressure.Size = New System.Drawing.Size(15, 15)
        Me.btnAirPressure.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnAirPressure.TabIndex = 30
        Me.btnAirPressure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnAirPressure.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnAirPressure.UseVisualStyleBackColor = False
        Me.btnAirPressure.ValueToBeSend = "On"
        '
        'btnPanels
        '
        Me.btnPanels.BackColor = System.Drawing.Color.Transparent
        Me.btnPanels.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnPanels.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPanels.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnPanels.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnPanels.FlatAppearance.BorderSize = 0
        Me.btnPanels.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPanels.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPanels.ForeColor = System.Drawing.Color.White
        Me.btnPanels.Location = New System.Drawing.Point(301, 37)
        Me.btnPanels.MessageBoxText = Nothing
        Me.btnPanels.Name = "btnPanels"
        Me.btnPanels.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnPanels.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnPanels.Size = New System.Drawing.Size(15, 15)
        Me.btnPanels.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnPanels.TabIndex = 28
        Me.btnPanels.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnPanels.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnPanels.UseVisualStyleBackColor = False
        Me.btnPanels.ValueToBeSend = "On"
        '
        'btnTurboWater
        '
        Me.btnTurboWater.BackColor = System.Drawing.Color.Transparent
        Me.btnTurboWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnTurboWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTurboWater.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnTurboWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnTurboWater.FlatAppearance.BorderSize = 0
        Me.btnTurboWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTurboWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTurboWater.ForeColor = System.Drawing.Color.White
        Me.btnTurboWater.Location = New System.Drawing.Point(301, 97)
        Me.btnTurboWater.MessageBoxText = Nothing
        Me.btnTurboWater.Name = "btnTurboWater"
        Me.btnTurboWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnTurboWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnTurboWater.Size = New System.Drawing.Size(15, 15)
        Me.btnTurboWater.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnTurboWater.TabIndex = 29
        Me.btnTurboWater.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnTurboWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnTurboWater.UseVisualStyleBackColor = False
        Me.btnTurboWater.ValueToBeSend = "On"
        '
        'btnFixtureWater
        '
        Me.btnFixtureWater.BackColor = System.Drawing.Color.Transparent
        Me.btnFixtureWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnFixtureWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFixtureWater.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnFixtureWater.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnFixtureWater.FlatAppearance.BorderSize = 0
        Me.btnFixtureWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFixtureWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFixtureWater.ForeColor = System.Drawing.Color.White
        Me.btnFixtureWater.Location = New System.Drawing.Point(137, 127)
        Me.btnFixtureWater.MessageBoxText = Nothing
        Me.btnFixtureWater.Name = "btnFixtureWater"
        Me.btnFixtureWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnFixtureWater.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnFixtureWater.Size = New System.Drawing.Size(15, 15)
        Me.btnFixtureWater.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnFixtureWater.TabIndex = 37
        Me.btnFixtureWater.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnFixtureWater.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnFixtureWater.UseVisualStyleBackColor = False
        Me.btnFixtureWater.ValueToBeSend = "On"
        '
        'btnForelinePress
        '
        Me.btnForelinePress.BackColor = System.Drawing.Color.Transparent
        Me.btnForelinePress.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnForelinePress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnForelinePress.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnForelinePress.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnForelinePress.FlatAppearance.BorderSize = 0
        Me.btnForelinePress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnForelinePress.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnForelinePress.ForeColor = System.Drawing.Color.White
        Me.btnForelinePress.Location = New System.Drawing.Point(137, 67)
        Me.btnForelinePress.MessageBoxText = Nothing
        Me.btnForelinePress.Name = "btnForelinePress"
        Me.btnForelinePress.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnForelinePress.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnForelinePress.Size = New System.Drawing.Size(15, 15)
        Me.btnForelinePress.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnForelinePress.TabIndex = 34
        Me.btnForelinePress.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnForelinePress.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnForelinePress.UseVisualStyleBackColor = False
        Me.btnForelinePress.ValueToBeSend = "On"
        '
        'btnChamPress
        '
        Me.btnChamPress.BackColor = System.Drawing.Color.Transparent
        Me.btnChamPress.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnChamPress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnChamPress.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnChamPress.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnChamPress.FlatAppearance.BorderSize = 0
        Me.btnChamPress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChamPress.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChamPress.ForeColor = System.Drawing.Color.White
        Me.btnChamPress.Location = New System.Drawing.Point(301, 67)
        Me.btnChamPress.MessageBoxText = Nothing
        Me.btnChamPress.Name = "btnChamPress"
        Me.btnChamPress.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnChamPress.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnChamPress.Size = New System.Drawing.Size(15, 15)
        Me.btnChamPress.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnChamPress.TabIndex = 35
        Me.btnChamPress.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnChamPress.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnChamPress.UseVisualStyleBackColor = False
        Me.btnChamPress.ValueToBeSend = "On"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 16)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Foreline"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 16)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Fixture Water"
        '
        'lblSource
        '
        Me.lblSource.AutoSize = True
        Me.lblSource.BackColor = System.Drawing.Color.Transparent
        Me.lblSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSource.Location = New System.Drawing.Point(4, 36)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(57, 16)
        Me.lblSource.TabIndex = 18
        Me.lblSource.Text = "Source"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(168, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Cham. Pressure"
        '
        'lblChamberLid
        '
        Me.lblChamberLid.BackColor = System.Drawing.Color.Transparent
        Me.lblChamberLid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChamberLid.Location = New System.Drawing.Point(168, 36)
        Me.lblChamberLid.Name = "lblChamberLid"
        Me.lblChamberLid.Size = New System.Drawing.Size(58, 16)
        Me.lblChamberLid.TabIndex = 16
        Me.lblChamberLid.Text = "Panels"
        '
        'lblAirPressure
        '
        Me.lblAirPressure.AutoSize = True
        Me.lblAirPressure.BackColor = System.Drawing.Color.Transparent
        Me.lblAirPressure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAirPressure.Location = New System.Drawing.Point(4, 97)
        Me.lblAirPressure.Name = "lblAirPressure"
        Me.lblAirPressure.Size = New System.Drawing.Size(93, 16)
        Me.lblAirPressure.TabIndex = 17
        Me.lblAirPressure.Text = "Air Pressure"
        '
        'lblTurboWater
        '
        Me.lblTurboWater.AutoSize = True
        Me.lblTurboWater.BackColor = System.Drawing.Color.Transparent
        Me.lblTurboWater.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurboWater.Location = New System.Drawing.Point(168, 96)
        Me.lblTurboWater.Name = "lblTurboWater"
        Me.lblTurboWater.Size = New System.Drawing.Size(94, 16)
        Me.lblTurboWater.TabIndex = 20
        Me.lblTurboWater.Text = "Turbo Water"
        '
        'btnFixtureWaterBug
        '
        Me.btnFixtureWaterBug.BackColor = System.Drawing.Color.Transparent
        Me.btnFixtureWaterBug.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnFixtureWaterBug.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFixtureWaterBug.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnFixtureWaterBug.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnFixtureWaterBug.FlatAppearance.BorderSize = 0
        Me.btnFixtureWaterBug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFixtureWaterBug.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFixtureWaterBug.ForeColor = System.Drawing.Color.White
        Me.btnFixtureWaterBug.Location = New System.Drawing.Point(301, 127)
        Me.btnFixtureWaterBug.MessageBoxText = Nothing
        Me.btnFixtureWaterBug.Name = "btnFixtureWaterBug"
        Me.btnFixtureWaterBug.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.btnFixtureWaterBug.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnFixtureWaterBug.Size = New System.Drawing.Size(15, 15)
        Me.btnFixtureWaterBug.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnFixtureWaterBug.TabIndex = 39
        Me.btnFixtureWaterBug.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnFixtureWaterBug.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnFixtureWaterBug.UseVisualStyleBackColor = False
        Me.btnFixtureWaterBug.ValueToBeSend = "On"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(168, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 16)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Fixture Water Bug"
        '
        'SL_InterlockControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btnFixtureWaterBug)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSource)
        Me.Controls.Add(Me.btnAirPressure)
        Me.Controls.Add(Me.btnPanels)
        Me.Controls.Add(Me.btnTurboWater)
        Me.Controls.Add(Me.btnFixtureWater)
        Me.Controls.Add(Me.btnForelinePress)
        Me.Controls.Add(Me.btnChamPress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblSource)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblChamberLid)
        Me.Controls.Add(Me.lblAirPressure)
        Me.Controls.Add(Me.lblTurboWater)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.HeaderText = "Interlocks"
        Me.Name = "SL_InterlockControl"
        Me.Size = New System.Drawing.Size(324, 150)
        Me.Text = "Interlocks"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.lblTurboWater, 0)
        Me.Controls.SetChildIndex(Me.lblAirPressure, 0)
        Me.Controls.SetChildIndex(Me.lblChamberLid, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblSource, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.btnChamPress, 0)
        Me.Controls.SetChildIndex(Me.btnForelinePress, 0)
        Me.Controls.SetChildIndex(Me.btnFixtureWater, 0)
        Me.Controls.SetChildIndex(Me.btnTurboWater, 0)
        Me.Controls.SetChildIndex(Me.btnPanels, 0)
        Me.Controls.SetChildIndex(Me.btnAirPressure, 0)
        Me.Controls.SetChildIndex(Me.btnSource, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnFixtureWaterBug, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSource As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnAirPressure As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnPanels As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnTurboWater As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnFixtureWater As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnForelinePress As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnChamPress As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSource As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblChamberLid As System.Windows.Forms.Label
    Friend WithEvents lblAirPressure As System.Windows.Forms.Label
    Friend WithEvents lblTurboWater As System.Windows.Forms.Label
    Friend WithEvents btnFixtureWaterBug As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
