<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDMagnatron
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.bicRotating = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnRotationStart = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Rotating"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 19)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Rotation Start"
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
        Me.bicRotating.Location = New System.Drawing.Point(198, 31)
        Me.bicRotating.Name = "bicRotating"
        Me.bicRotating.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.bicRotating.OffText = ""
        Me.bicRotating.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.bicRotating.OnText = ""
        Me.bicRotating.Size = New System.Drawing.Size(20, 20)
        Me.bicRotating.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicRotating.StyleOfButton = ButtonStyle.Horizontal
        Me.bicRotating.TabIndex = 15
        Me.bicRotating.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.bicRotating.UnKnownText = ""
        Me.bicRotating.UseVisualStyleBackColor = False
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
        Me.btnRotationStart.Location = New System.Drawing.Point(176, 56)
        Me.btnRotationStart.Name = "btnRotationStart"
        Me.btnRotationStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnRotationStart.OffText = "On/Off"
        Me.btnRotationStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_On
        Me.btnRotationStart.OnText = "Off/On"
        Me.btnRotationStart.Size = New System.Drawing.Size(65, 24)
        Me.btnRotationStart.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnRotationStart.StyleOfButton = ButtonStyle.Horizontal
        Me.btnRotationStart.TabIndex = 15
        Me.btnRotationStart.Text = "On/Off"
        Me.btnRotationStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnRotationStart.UnKnownText = ""
        Me.btnRotationStart.UseVisualStyleBackColor = False
        '
        'PVDMagnatron
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnRotationStart)
        Me.Controls.Add(Me.bicRotating)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.HeaderHeight = 28
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "PVDMagnatron"
        Me.Size = New System.Drawing.Size(325, 86)
        Me.Text = "Magnetron"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.bicRotating, 0)
        Me.Controls.SetChildIndex(Me.btnRotationStart, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bicRotating As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnRotationStart As AVP_Robot_Project.ButtonIGCGControl

End Class
