<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FixtureControl
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
        Me.txtTiltAngleRight = New System.Windows.Forms.TextBox
        Me.lblTiltAngle = New System.Windows.Forms.Label
        Me.txtTiltAngle1 = New System.Windows.Forms.TextBox
        Me.lblRotationMode = New System.Windows.Forms.Label
        Me.txtRotationMode = New System.Windows.Forms.TextBox
        Me.btnMode = New System.Windows.Forms.Button
        Me.txtRotationRight = New System.Windows.Forms.TextBox
        Me.lblRotationRPM = New System.Windows.Forms.Label
        Me.txtRotation1 = New System.Windows.Forms.TextBox
        Me.txtRotationLastRight = New System.Windows.Forms.TextBox
        Me.lblRotationEnd = New System.Windows.Forms.Label
        Me.lblFixtureError = New System.Windows.Forms.Label
        Me.SmallCricleControlTiltAngle = New AVP_Robot_Project.SmallCircleControl
        Me.SmallCricleControlTiltRotation = New AVP_Robot_Project.SmallCircleControl
        Me.sccFixtureError = New AVP_Robot_Project.SmallCircleControl
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtTiltAngleRight
        '
        Me.txtTiltAngleRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtTiltAngleRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTiltAngleRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiltAngleRight.Location = New System.Drawing.Point(196, 40)
        Me.txtTiltAngleRight.Name = "txtTiltAngleRight"
        Me.txtTiltAngleRight.ReadOnly = True
        Me.txtTiltAngleRight.Size = New System.Drawing.Size(70, 22)
        Me.txtTiltAngleRight.TabIndex = 41
        '
        'lblTiltAngle
        '
        Me.lblTiltAngle.AutoSize = True
        Me.lblTiltAngle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiltAngle.Location = New System.Drawing.Point(0, 41)
        Me.lblTiltAngle.Name = "lblTiltAngle"
        Me.lblTiltAngle.Size = New System.Drawing.Size(74, 16)
        Me.lblTiltAngle.TabIndex = 39
        Me.lblTiltAngle.Text = "Tilt Angle"
        '
        'txtTiltAngle1
        '
        Me.txtTiltAngle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiltAngle1.Location = New System.Drawing.Point(122, 40)
        Me.txtTiltAngle1.Name = "txtTiltAngle1"
        Me.txtTiltAngle1.ReadOnly = True
        Me.txtTiltAngle1.Size = New System.Drawing.Size(70, 22)
        Me.txtTiltAngle1.TabIndex = 40
        '
        'lblRotationMode
        '
        Me.lblRotationMode.AutoSize = True
        Me.lblRotationMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRotationMode.Location = New System.Drawing.Point(0, 70)
        Me.lblRotationMode.Name = "lblRotationMode"
        Me.lblRotationMode.Size = New System.Drawing.Size(109, 16)
        Me.lblRotationMode.TabIndex = 43
        Me.lblRotationMode.Text = "Rotation Mode"
        '
        'txtRotationMode
        '
        Me.txtRotationMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRotationMode.Location = New System.Drawing.Point(122, 69)
        Me.txtRotationMode.Name = "txtRotationMode"
        Me.txtRotationMode.ReadOnly = True
        Me.txtRotationMode.Size = New System.Drawing.Size(70, 22)
        Me.txtRotationMode.TabIndex = 44
        '
        'btnMode
        '
        Me.btnMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMode.Location = New System.Drawing.Point(195, 70)
        Me.btnMode.Name = "btnMode"
        Me.btnMode.Size = New System.Drawing.Size(71, 23)
        Me.btnMode.TabIndex = 45
        Me.btnMode.Text = "Mode"
        Me.btnMode.UseVisualStyleBackColor = True
        '
        'txtRotationRight
        '
        Me.txtRotationRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtRotationRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRotationRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRotationRight.Location = New System.Drawing.Point(196, 99)
        Me.txtRotationRight.Name = "txtRotationRight"
        Me.txtRotationRight.ReadOnly = True
        Me.txtRotationRight.Size = New System.Drawing.Size(70, 22)
        Me.txtRotationRight.TabIndex = 48
        '
        'lblRotationRPM
        '
        Me.lblRotationRPM.AutoSize = True
        Me.lblRotationRPM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRotationRPM.Location = New System.Drawing.Point(0, 100)
        Me.lblRotationRPM.Name = "lblRotationRPM"
        Me.lblRotationRPM.Size = New System.Drawing.Size(113, 16)
        Me.lblRotationRPM.TabIndex = 46
        Me.lblRotationRPM.Text = "Rotation (RPM)"
        '
        'txtRotation1
        '
        Me.txtRotation1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRotation1.Location = New System.Drawing.Point(122, 99)
        Me.txtRotation1.Name = "txtRotation1"
        Me.txtRotation1.ReadOnly = True
        Me.txtRotation1.Size = New System.Drawing.Size(70, 22)
        Me.txtRotation1.TabIndex = 47
        '
        'txtRotationLastRight
        '
        Me.txtRotationLastRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtRotationLastRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRotationLastRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRotationLastRight.Location = New System.Drawing.Point(196, 129)
        Me.txtRotationLastRight.Name = "txtRotationLastRight"
        Me.txtRotationLastRight.ReadOnly = True
        Me.txtRotationLastRight.Size = New System.Drawing.Size(70, 22)
        Me.txtRotationLastRight.TabIndex = 51
        Me.txtRotationLastRight.Visible = False
        '
        'lblRotationEnd
        '
        Me.lblRotationEnd.AutoSize = True
        Me.lblRotationEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRotationEnd.Location = New System.Drawing.Point(0, 129)
        Me.lblRotationEnd.Name = "lblRotationEnd"
        Me.lblRotationEnd.Size = New System.Drawing.Size(97, 16)
        Me.lblRotationEnd.TabIndex = 53
        Me.lblRotationEnd.Text = "Rotation End"
        Me.lblRotationEnd.Visible = False
        '
        'lblFixtureError
        '
        Me.lblFixtureError.AutoSize = True
        Me.lblFixtureError.BackColor = System.Drawing.Color.Transparent
        Me.lblFixtureError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFixtureError.Location = New System.Drawing.Point(125, 5)
        Me.lblFixtureError.Name = "lblFixtureError"
        Me.lblFixtureError.Size = New System.Drawing.Size(92, 16)
        Me.lblFixtureError.TabIndex = 55
        Me.lblFixtureError.Text = "Fixture Error"
        '
        'SmallCricleControlTiltAngle
        '
        Me.SmallCricleControlTiltAngle.DefaultImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.SmallCricleControlTiltAngle.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.SmallCricleControlTiltAngle.HomeImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.SmallCricleControlTiltAngle.Location = New System.Drawing.Point(101, 36)
        Me.SmallCricleControlTiltAngle.MovingImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.SmallCricleControlTiltAngle.Name = "SmallCricleControlTiltAngle"
        Me.SmallCricleControlTiltAngle.Size = New System.Drawing.Size(15, 14)
        Me.SmallCricleControlTiltAngle.Status = AVP_Robot_Project.FourStatusControl.DisplayStatus.[Default]
        Me.SmallCricleControlTiltAngle.TabIndex = 56
        '
        'SmallCricleControlTiltRotation
        '
        Me.SmallCricleControlTiltRotation.DefaultImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.SmallCricleControlTiltRotation.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.SmallCricleControlTiltRotation.HomeImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.SmallCricleControlTiltRotation.Location = New System.Drawing.Point(101, 89)
        Me.SmallCricleControlTiltRotation.MovingImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.SmallCricleControlTiltRotation.Name = "SmallCricleControlTiltRotation"
        Me.SmallCricleControlTiltRotation.Size = New System.Drawing.Size(15, 14)
        Me.SmallCricleControlTiltRotation.Status = AVP_Robot_Project.FourStatusControl.DisplayStatus.[Default]
        Me.SmallCricleControlTiltRotation.TabIndex = 56
        '
        'sccFixtureError
        '
        Me.sccFixtureError.DefaultImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Black
        Me.sccFixtureError.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Red
        Me.sccFixtureError.HomeImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Green
        Me.sccFixtureError.Location = New System.Drawing.Point(101, 5)
        Me.sccFixtureError.MovingImage = Global.AVP_Robot_Project.My.Resources.Resources.Sensor_Yellow
        Me.sccFixtureError.Name = "sccFixtureError"
        Me.sccFixtureError.Size = New System.Drawing.Size(15, 14)
        Me.sccFixtureError.Status = AVP_Robot_Project.FourStatusControl.DisplayStatus.[Default]
        Me.sccFixtureError.TabIndex = 56
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Fixture"
        '
        'FixtureControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SmallCricleControlTiltRotation)
        Me.Controls.Add(Me.sccFixtureError)
        Me.Controls.Add(Me.SmallCricleControlTiltAngle)
        Me.Controls.Add(Me.lblFixtureError)
        Me.Controls.Add(Me.lblRotationEnd)
        Me.Controls.Add(Me.txtRotationLastRight)
        Me.Controls.Add(Me.txtRotationRight)
        Me.Controls.Add(Me.lblRotationRPM)
        Me.Controls.Add(Me.txtRotation1)
        Me.Controls.Add(Me.btnMode)
        Me.Controls.Add(Me.lblRotationMode)
        Me.Controls.Add(Me.txtRotationMode)
        Me.Controls.Add(Me.txtTiltAngleRight)
        Me.Controls.Add(Me.lblTiltAngle)
        Me.Controls.Add(Me.txtTiltAngle1)
        Me.DoubleBuffered = True
        Me.HeaderHeight = 28
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.Name = "FixtureControl"
        Me.Size = New System.Drawing.Size(270, 156)
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.txtTiltAngle1, 0)
        Me.Controls.SetChildIndex(Me.lblTiltAngle, 0)
        Me.Controls.SetChildIndex(Me.txtTiltAngleRight, 0)
        Me.Controls.SetChildIndex(Me.txtRotationMode, 0)
        Me.Controls.SetChildIndex(Me.lblRotationMode, 0)
        Me.Controls.SetChildIndex(Me.btnMode, 0)
        Me.Controls.SetChildIndex(Me.txtRotation1, 0)
        Me.Controls.SetChildIndex(Me.lblRotationRPM, 0)
        Me.Controls.SetChildIndex(Me.txtRotationRight, 0)
        Me.Controls.SetChildIndex(Me.txtRotationLastRight, 0)
        Me.Controls.SetChildIndex(Me.lblRotationEnd, 0)
        Me.Controls.SetChildIndex(Me.lblFixtureError, 0)
        Me.Controls.SetChildIndex(Me.SmallCricleControlTiltAngle, 0)
        Me.Controls.SetChildIndex(Me.sccFixtureError, 0)
        Me.Controls.SetChildIndex(Me.SmallCricleControlTiltRotation, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTiltAngleRight As System.Windows.Forms.TextBox
    Friend WithEvents lblTiltAngle As System.Windows.Forms.Label
    Friend WithEvents txtTiltAngle1 As System.Windows.Forms.TextBox
    Friend WithEvents lblRotationMode As System.Windows.Forms.Label
    Friend WithEvents txtRotationMode As System.Windows.Forms.TextBox
    Friend WithEvents btnMode As System.Windows.Forms.Button
    Friend WithEvents txtRotationRight As System.Windows.Forms.TextBox
    Friend WithEvents lblRotationRPM As System.Windows.Forms.Label
    Friend WithEvents txtRotation1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRotationLastRight As System.Windows.Forms.TextBox
    'Friend WithEvents SmallCricleControlTiltAngle As AVP_Robot_Project.SmallCricleControl
    'Friend WithEvents SmallCricleControlTiltRotation As AVP_Robot_Project.SmallCricleControl
    Friend WithEvents lblRotationEnd As System.Windows.Forms.Label
    'Friend WithEvents sccFixtureError As AVP_Robot_Project.SmallCricleControl
    Friend WithEvents lblFixtureError As System.Windows.Forms.Label
    Friend WithEvents SmallCricleControlTiltAngle As AVP_Robot_Project.SmallCircleControl
    Friend WithEvents SmallCricleControlTiltRotation As AVP_Robot_Project.SmallCircleControl
    Friend WithEvents sccFixtureError As AVP_Robot_Project.SmallCircleControl
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
