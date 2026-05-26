<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RobotBody
    Inherits AVP_Robot_Project.PVDStatusPanel

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SensorPM3 = New AVP_Robot_Project.CircleStatusControl
        Me.SensorPM2 = New AVP_Robot_Project.CircleStatusControl
        Me.SensorPM1 = New AVP_Robot_Project.CircleStatusControl
        Me.SensorLLA = New AVP_Robot_Project.CircleStatusControl
        Me.SuspendLayout()
        '
        'SensorPM3
        '
        Me.SensorPM3.Location = New System.Drawing.Point(147, 79)
        Me.SensorPM3.Name = "SensorPM3"
        Me.SensorPM3.PMVisible = True
        Me.SensorPM3.Size = New System.Drawing.Size(12, 11)
        Me.SensorPM3.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.SensorPM3.TabIndex = 14
        '
        'SensorPM2
        '
        Me.SensorPM2.Location = New System.Drawing.Point(79, 11)
        Me.SensorPM2.Name = "SensorPM2"
        Me.SensorPM2.PMVisible = True
        Me.SensorPM2.Size = New System.Drawing.Size(12, 11)
        Me.SensorPM2.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.SensorPM2.TabIndex = 14
        '
        'SensorPM1
        '
        Me.SensorPM1.Location = New System.Drawing.Point(10, 79)
        Me.SensorPM1.Name = "SensorPM1"
        Me.SensorPM1.PMVisible = True
        Me.SensorPM1.Size = New System.Drawing.Size(12, 11)
        Me.SensorPM1.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.SensorPM1.TabIndex = 14
        '
        'SensorLLA
        '
        Me.SensorLLA.Location = New System.Drawing.Point(79, 147)
        Me.SensorLLA.Name = "SensorLLA"
        Me.SensorLLA.PMVisible = True
        Me.SensorLLA.Size = New System.Drawing.Size(12, 11)
        Me.SensorLLA.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.SensorLLA.TabIndex = 14
        '
        'RobotBody
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.SensorPM3)
        Me.Controls.Add(Me.SensorPM2)
        Me.Controls.Add(Me.SensorPM1)
        Me.Controls.Add(Me.SensorLLA)
        Me.Name = "RobotBody"
        Me.Size = New System.Drawing.Size(214, 219)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SensorLLA As AVP_Robot_Project.CircleStatusControl
    Friend WithEvents SensorPM1 As AVP_Robot_Project.CircleStatusControl
    Friend WithEvents SensorPM2 As AVP_Robot_Project.CircleStatusControl
    Friend WithEvents SensorPM3 As AVP_Robot_Project.CircleStatusControl

End Class
