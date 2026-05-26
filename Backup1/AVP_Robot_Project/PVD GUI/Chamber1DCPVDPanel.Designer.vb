<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chamber1DCPVDPanel
    Inherits AVP_Robot_Project.PVDPanel

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
        Me.DCTargetPowerSupply = New AVP_Robot_Project.TargetPowerSupply
        Me.SuspendLayout()
        '
        'DCTargetPowerSupply
        '
        Me.DCTargetPowerSupply.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DCTargetPowerSupply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.DCTargetPowerSupply.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DCTargetPowerSupply.HeaderHeight = 30
        Me.DCTargetPowerSupply.HeaderStatus = DisplayStatus.Off
        Me.DCTargetPowerSupply.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.DCTargetPowerSupply.HeaderTextColor = System.Drawing.Color.White
        Me.DCTargetPowerSupply.HeaderVisible = True
        Me.DCTargetPowerSupply.Headerwidth = 60
        Me.DCTargetPowerSupply.Location = New System.Drawing.Point(0, 87)
        Me.DCTargetPowerSupply.Name = "DCTargetPowerSupply"
        Me.DCTargetPowerSupply.Size = New System.Drawing.Size(325, 144)
        Me.DCTargetPowerSupply.TabIndex = 135
        Me.DCTargetPowerSupply.Text = "Target Power Supply"
        '
        'Chamber1DCPVDPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me.DCTargetPowerSupply)
        Me.Name = "Chamber1DCPVDPanel"
        Me.Controls.SetChildIndex(Me.DCTargetPowerSupply, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
   
    Friend WithEvents DCTargetPowerSupply As AVP_Robot_Project.TargetPowerSupply
  
End Class
