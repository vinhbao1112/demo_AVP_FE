<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chamber1RFPVDPanel
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
        Me.RFTargetPowerSupply = New AVP_Robot_Project.BiasPowerSupply
        Me.SuspendLayout()
        '
        'RFTargetPowerSupply
        '
        Me.RFTargetPowerSupply.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.RFTargetPowerSupply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RFTargetPowerSupply.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RFTargetPowerSupply.HeaderHeight = 30
        Me.RFTargetPowerSupply.HeaderStatus = DisplayStatus.Off
        Me.RFTargetPowerSupply.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Horizontal
        Me.RFTargetPowerSupply.HeaderTextColor = System.Drawing.Color.White
        Me.RFTargetPowerSupply.HeaderVisible = True
        Me.RFTargetPowerSupply.Headerwidth = 60
        Me.RFTargetPowerSupply.Location = New System.Drawing.Point(0, 15)
        Me.RFTargetPowerSupply.Name = "RFTargetPowerSupply"
        Me.RFTargetPowerSupply.Size = New System.Drawing.Size(325, 245)
        Me.RFTargetPowerSupply.TabIndex = 177
        Me.RFTargetPowerSupply.Text = "Target Power Supply"
        '
        'Chamber1RFPVDPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me.RFTargetPowerSupply)
        Me.Name = "Chamber1RFPVDPanel"
        Me.Controls.SetChildIndex(Me.RFTargetPowerSupply, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RFTargetPowerSupply As AVP_Robot_Project.BiasPowerSupply

End Class
