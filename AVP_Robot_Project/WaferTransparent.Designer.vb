<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WaferTransparent
    Inherits AVP_Robot_Project.TransparentControl
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
        Me.CirclePlasmaControlWafer = New AVP_Robot_Project.CirclePlasmaControl
        Me.SuspendLayout()
        '
        'CirclePlasmaControlWafer
        '
        Me.CirclePlasmaControlWafer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CirclePlasmaControlWafer.Location = New System.Drawing.Point(18, 13)
        Me.CirclePlasmaControlWafer.Name = "CirclePlasmaControlWafer"
        Me.CirclePlasmaControlWafer.OffState_ColorText = System.Drawing.Color.Empty
        Me.CirclePlasmaControlWafer.OnState_ColorText = System.Drawing.Color.Empty
        Me.CirclePlasmaControlWafer.PlasmaOn = False
        Me.CirclePlasmaControlWafer.Size = New System.Drawing.Size(67, 62)
        Me.CirclePlasmaControlWafer.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.CirclePlasmaControlWafer.TabIndex = 0
        Me.CirclePlasmaControlWafer.TextLocation = New System.Drawing.Point(0, 0)
        Me.CirclePlasmaControlWafer.TextLocIsFix = True
        Me.CirclePlasmaControlWafer.TextValue = ""
        Me.CirclePlasmaControlWafer.WaferID = ""
        Me.CirclePlasmaControlWafer.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
        '
        'WaferTransparent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CirclePlasmaControlWafer)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "WaferTransparent"
        Me.Size = New System.Drawing.Size(113, 94)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CirclePlasmaControlWafer As AVP_Robot_Project.CirclePlasmaControl

End Class
