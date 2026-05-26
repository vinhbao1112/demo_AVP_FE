Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVD2R4ChamberControl
    Inherits DepChamberControl

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
        Me.DoorShield = New AVPControls.PVD2R4DoorShieldControl
        Me.WaferControl = New AVPControls.AVPWaferControl
        Me.Shutter1 = New AVPControls.AVPShutterControl
        Me.Shutter2 = New AVPControls.AVPShutterControl
        Me.Shutter3 = New AVPControls.AVPShutterControl
        Me.Shutter4 = New AVPControls.AVPShutterControl
        CType(Me.DoorShield, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WaferControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Shutter1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Shutter2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Shutter3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Shutter4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DoorShield
        '
        Me.DoorShield.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX5
        Me.DoorShield.BackColor = System.Drawing.SystemColors.ControlDark
        Me.DoorShield.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoorShield.Location = New System.Drawing.Point(41, 104)
        Me.DoorShield.Name = "DoorShield"
        Me.DoorShield.Size = New System.Drawing.Size(40, 41)
        Me.DoorShield.TabIndex = 0
        '
        'WaferControl
        '
        Me.WaferControl.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX5
        Me.WaferControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.WaferControl.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD2R4
        Me.WaferControl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WaferControl.Location = New System.Drawing.Point(146, 123)
        Me.WaferControl.Name = "WaferControl"
        Me.WaferControl.Size = New System.Drawing.Size(130, 18)
        Me.WaferControl.TabIndex = 1
        Me.WaferControl.Visible = False
        '
        'Shutter1
        '
        Me.Shutter1.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX5
        Me.Shutter1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Shutter1.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD2R4
        Me.Shutter1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Shutter1.Location = New System.Drawing.Point(45, 42)
        Me.Shutter1.Name = "Shutter1"
        Me.Shutter1.Size = New System.Drawing.Size(78, 14)
        Me.Shutter1.TabIndex = 2
        '
        'Shutter2
        '
        Me.Shutter2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX5
        Me.Shutter2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Shutter2.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD2R4
        Me.Shutter2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Shutter2.Location = New System.Drawing.Point(129, 42)
        Me.Shutter2.Name = "Shutter2"
        Me.Shutter2.Size = New System.Drawing.Size(78, 14)
        Me.Shutter2.TabIndex = 2
        '
        'Shutter3
        '
        Me.Shutter3.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX5
        Me.Shutter3.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Shutter3.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD2R4
        Me.Shutter3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Shutter3.Location = New System.Drawing.Point(213, 42)
        Me.Shutter3.Name = "Shutter3"
        Me.Shutter3.Size = New System.Drawing.Size(78, 14)
        Me.Shutter3.TabIndex = 2
        '
        'Shutter4
        '
        Me.Shutter4.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX5
        Me.Shutter4.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Shutter4.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD2R4
        Me.Shutter4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Shutter4.Location = New System.Drawing.Point(297, 42)
        Me.Shutter4.Name = "Shutter4"
        Me.Shutter4.Size = New System.Drawing.Size(78, 14)
        Me.Shutter4.TabIndex = 2
        '
        'PVD2R4ChamberControl
        '
        Me.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD2R4
        Me.Controls.Add(Me.Shutter4)
        Me.Controls.Add(Me.Shutter3)
        Me.Controls.Add(Me.Shutter2)
        Me.Controls.Add(Me.Shutter1)
        Me.Controls.Add(Me.WaferControl)
        Me.Controls.Add(Me.DoorShield)
        Me.Name = "PVD2R4ChamberControl"
        Me.Size = New System.Drawing.Size(450, 343)
        CType(Me.DoorShield, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WaferControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Shutter1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Shutter2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Shutter3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Shutter4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DoorShield As AVPControls.PVD2R4DoorShieldControl
    Friend WithEvents WaferControl As AVPControls.AVPWaferControl
    Friend WithEvents Shutter1 As AVPControls.AVPShutterControl
    Friend WithEvents Shutter2 As AVPControls.AVPShutterControl
    Friend WithEvents Shutter3 As AVPControls.AVPShutterControl
    Friend WithEvents Shutter4 As AVPControls.AVPShutterControl



End Class
