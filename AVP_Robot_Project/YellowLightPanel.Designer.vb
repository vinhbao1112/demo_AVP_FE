<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YellowLightPanel
    Inherits System.Windows.Forms.Button

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
        Me.labAlarm = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'labAlarm
        '
        Me.labAlarm.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.labAlarm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labAlarm.Location = New System.Drawing.Point(0, 0)
        Me.labAlarm.Name = "labAlarm"
        Me.labAlarm.Size = New System.Drawing.Size(135, 93)
        Me.labAlarm.TabIndex = 0
        Me.labAlarm.Visible = False
        '
        'YellowLightPanel
        '

        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.labAlarm)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "YellowLightPanel"
        Me.Size = New System.Drawing.Size(135, 93)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents labAlarm As System.Windows.Forms.Label

End Class
