<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RobotHandNew
    Inherits System.Windows.Forms.UserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RobotHandNew))
        Me.WaferControl = New AVP_Robot_Project.AVPWafer
        Me.SuspendLayout()
        '
        'WaferControl
        '
        Me.WaferControl.BackColor = System.Drawing.Color.Transparent
        Me.WaferControl.Location = New System.Drawing.Point(3, 83)
        Me.WaferControl.Name = "WaferControl"
        Me.WaferControl.ScaleNumber = 1.0!
        Me.WaferControl.Size = New System.Drawing.Size(38, 38)
        Me.WaferControl.Status = AVPLib.ConstEnum.enumWaferStatus.eWaferNew
        Me.WaferControl.TabIndex = 0
        Me.WaferControl.WaferID = ""
        '
        'RobotHandNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.WaferControl)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "RobotHandNew"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WaferControl As AVP_Robot_Project.AVPWafer

End Class
