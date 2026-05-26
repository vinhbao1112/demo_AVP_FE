<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChamberInterlocks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChamberInterlocks))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.bicChamberPress = New AVP_Robot_Project.ButtonIGCGControl
        Me.bicForeline = New AVP_Robot_Project.ButtonIGCGControl
        Me.bicAirPressure = New AVP_Robot_Project.ButtonIGCGControl
        Me.bicTurboWater = New AVP_Robot_Project.ButtonIGCGControl
        Me.bicPanelInterlock = New AVP_Robot_Project.ButtonIGCGControl
        Me.bicSourceWater = New AVP_Robot_Project.ButtonIGCGControl
        Me.bicFixtureWater = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 19)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Fixture Water"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 19)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Chamber Press."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 19)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Foreline Press."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 19)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Source Water"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 19)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Air Pressure"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 19)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Panel Interlock"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 19)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Turbo Water"
        '
        'bicChamberPress
        '
        Me.bicChamberPress.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicChamberPress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicChamberPress.ErrorImage = Nothing
        Me.bicChamberPress.ErrorText = ""
        Me.bicChamberPress.FlatAppearance.BorderSize = 0
        Me.bicChamberPress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicChamberPress.Location = New System.Drawing.Point(142, 177)
        Me.bicChamberPress.Name = "bicChamberPress"
        Me.bicChamberPress.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicChamberPress.OffText = ""
        Me.bicChamberPress.OnImage = CType(resources.GetObject("bicChamberPress.OnImage"), System.Drawing.Image)
        Me.bicChamberPress.OnText = ""
        Me.bicChamberPress.Size = New System.Drawing.Size(35, 22)
        Me.bicChamberPress.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.bicChamberPress.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.bicChamberPress.TabIndex = 44
        Me.bicChamberPress.UnknownImage = Nothing
        Me.bicChamberPress.UnKnownText = ""
        Me.bicChamberPress.UseVisualStyleBackColor = True
        '
        'bicForeline
        '
        Me.bicForeline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicForeline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicForeline.ErrorImage = Nothing
        Me.bicForeline.ErrorText = ""
        Me.bicForeline.FlatAppearance.BorderSize = 0
        Me.bicForeline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicForeline.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicForeline.Location = New System.Drawing.Point(142, 153)
        Me.bicForeline.Name = "bicForeline"
        Me.bicForeline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicForeline.OffText = ""
        Me.bicForeline.OnImage = CType(resources.GetObject("bicForeline.OnImage"), System.Drawing.Image)
        Me.bicForeline.OnText = ""
        Me.bicForeline.Size = New System.Drawing.Size(35, 22)
        Me.bicForeline.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.bicForeline.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.bicForeline.TabIndex = 43
        Me.bicForeline.UnknownImage = Nothing
        Me.bicForeline.UnKnownText = ""
        Me.bicForeline.UseVisualStyleBackColor = True
        '
        'bicAirPressure
        '
        Me.bicAirPressure.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicAirPressure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicAirPressure.ErrorImage = Nothing
        Me.bicAirPressure.ErrorText = ""
        Me.bicAirPressure.FlatAppearance.BorderSize = 0
        Me.bicAirPressure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicAirPressure.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicAirPressure.Location = New System.Drawing.Point(142, 129)
        Me.bicAirPressure.Name = "bicAirPressure"
        Me.bicAirPressure.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicAirPressure.OffText = ""
        Me.bicAirPressure.OnImage = CType(resources.GetObject("bicAirPressure.OnImage"), System.Drawing.Image)
        Me.bicAirPressure.OnText = ""
        Me.bicAirPressure.Size = New System.Drawing.Size(35, 22)
        Me.bicAirPressure.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.bicAirPressure.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.bicAirPressure.TabIndex = 42
        Me.bicAirPressure.UnknownImage = Nothing
        Me.bicAirPressure.UnKnownText = ""
        Me.bicAirPressure.UseVisualStyleBackColor = True
        '
        'bicTurboWater
        '
        Me.bicTurboWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicTurboWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicTurboWater.ErrorImage = Nothing
        Me.bicTurboWater.ErrorText = ""
        Me.bicTurboWater.FlatAppearance.BorderSize = 0
        Me.bicTurboWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTurboWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicTurboWater.Location = New System.Drawing.Point(142, 57)
        Me.bicTurboWater.Name = "bicTurboWater"
        Me.bicTurboWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicTurboWater.OffText = ""
        Me.bicTurboWater.OnImage = CType(resources.GetObject("bicTurboWater.OnImage"), System.Drawing.Image)
        Me.bicTurboWater.OnText = ""
        Me.bicTurboWater.Size = New System.Drawing.Size(35, 22)
        Me.bicTurboWater.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.bicTurboWater.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.bicTurboWater.TabIndex = 41
        Me.bicTurboWater.UnknownImage = Nothing
        Me.bicTurboWater.UnKnownText = ""
        Me.bicTurboWater.UseVisualStyleBackColor = True
        '
        'bicPanelInterlock
        '
        Me.bicPanelInterlock.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicPanelInterlock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicPanelInterlock.ErrorImage = Nothing
        Me.bicPanelInterlock.ErrorText = ""
        Me.bicPanelInterlock.FlatAppearance.BorderSize = 0
        Me.bicPanelInterlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicPanelInterlock.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicPanelInterlock.Location = New System.Drawing.Point(142, 105)
        Me.bicPanelInterlock.Name = "bicPanelInterlock"
        Me.bicPanelInterlock.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicPanelInterlock.OffText = ""
        Me.bicPanelInterlock.OnImage = CType(resources.GetObject("bicPanelInterlock.OnImage"), System.Drawing.Image)
        Me.bicPanelInterlock.OnText = ""
        Me.bicPanelInterlock.Size = New System.Drawing.Size(35, 22)
        Me.bicPanelInterlock.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.bicPanelInterlock.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.bicPanelInterlock.TabIndex = 40
        Me.bicPanelInterlock.UnknownImage = Nothing
        Me.bicPanelInterlock.UnKnownText = ""
        Me.bicPanelInterlock.UseVisualStyleBackColor = True
        '
        'bicSourceWater
        '
        Me.bicSourceWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicSourceWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicSourceWater.ErrorImage = Nothing
        Me.bicSourceWater.ErrorText = ""
        Me.bicSourceWater.FlatAppearance.BorderSize = 0
        Me.bicSourceWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicSourceWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicSourceWater.Location = New System.Drawing.Point(142, 33)
        Me.bicSourceWater.Name = "bicSourceWater"
        Me.bicSourceWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicSourceWater.OffText = ""
        Me.bicSourceWater.OnImage = CType(resources.GetObject("bicSourceWater.OnImage"), System.Drawing.Image)
        Me.bicSourceWater.OnText = ""
        Me.bicSourceWater.Size = New System.Drawing.Size(35, 22)
        Me.bicSourceWater.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.bicSourceWater.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.bicSourceWater.TabIndex = 39
        Me.bicSourceWater.UnknownImage = Nothing
        Me.bicSourceWater.UnKnownText = ""
        Me.bicSourceWater.UseVisualStyleBackColor = True
        '
        'bicFixtureWater
        '
        Me.bicFixtureWater.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicFixtureWater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicFixtureWater.ErrorImage = Nothing
        Me.bicFixtureWater.ErrorText = ""
        Me.bicFixtureWater.FlatAppearance.BorderSize = 0
        Me.bicFixtureWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicFixtureWater.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicFixtureWater.Location = New System.Drawing.Point(142, 81)
        Me.bicFixtureWater.Name = "bicFixtureWater"
        Me.bicFixtureWater.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BlackButton
        Me.bicFixtureWater.OffText = ""
        Me.bicFixtureWater.OnImage = CType(resources.GetObject("bicFixtureWater.OnImage"), System.Drawing.Image)
        Me.bicFixtureWater.OnText = ""
        Me.bicFixtureWater.Size = New System.Drawing.Size(35, 22)
        Me.bicFixtureWater.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.bicFixtureWater.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.bicFixtureWater.TabIndex = 38
        Me.bicFixtureWater.UnknownImage = Nothing
        Me.bicFixtureWater.UnKnownText = ""
        Me.bicFixtureWater.UseVisualStyleBackColor = True
        '
        'ChamberInterlocks
        '
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.bicChamberPress)
        Me.Controls.Add(Me.bicForeline)
        Me.Controls.Add(Me.bicAirPressure)
        Me.Controls.Add(Me.bicTurboWater)
        Me.Controls.Add(Me.bicPanelInterlock)
        Me.Controls.Add(Me.bicSourceWater)
        Me.Controls.Add(Me.bicFixtureWater)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderHeight = 28
        Me.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "ChamberInterlocks"
        Me.Size = New System.Drawing.Size(194, 200)
        Me.Text = "Chamber Interlocks"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.bicFixtureWater, 0)
        Me.Controls.SetChildIndex(Me.bicSourceWater, 0)
        Me.Controls.SetChildIndex(Me.bicPanelInterlock, 0)
        Me.Controls.SetChildIndex(Me.bicTurboWater, 0)
        Me.Controls.SetChildIndex(Me.bicAirPressure, 0)
        Me.Controls.SetChildIndex(Me.bicForeline, 0)
        Me.Controls.SetChildIndex(Me.bicChamberPress, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents bicFixtureWater As AVP_Robot_Project.ButtonIGCGControl
	Friend WithEvents bicSourceWater As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents bicPanelInterlock As AVP_Robot_Project.ButtonIGCGControl
	Friend WithEvents bicTurboWater As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents bicAirPressure As AVP_Robot_Project.ButtonIGCGControl
	Friend WithEvents bicForeline As AVP_Robot_Project.ButtonIGCGControl
	Friend WithEvents bicChamberPress As AVP_Robot_Project.ButtonIGCGControl

End Class
