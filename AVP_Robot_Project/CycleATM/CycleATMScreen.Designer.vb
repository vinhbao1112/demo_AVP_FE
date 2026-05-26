<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CycleATMScreen
    Inherits AVP_Robot_Project.StatusPanel

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
        Me.CycleATMPanel = New AVP_Robot_Project.CycleATMPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'CycleATMPanel
        '
        Me.CycleATMPanel.BackColor = System.Drawing.Color.Transparent
        Me.CycleATMPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CycleATMPanel.HeaderHeight = 32
        Me.CycleATMPanel.HeaderTextColor = System.Drawing.Color.White
        Me.CycleATMPanel.HeaderVisible = True
        Me.CycleATMPanel.Location = New System.Drawing.Point(400, 99)
        Me.CycleATMPanel.Name = "CycleATMPanel"
        Me.CycleATMPanel.Size = New System.Drawing.Size(464, 471)
        Me.CycleATMPanel.TabIndex = 0
        Me.CycleATMPanel.Text = "Cycle ATM "
        Me.CycleATMPanel.UseBorderStyle = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 24.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1280, 50)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "CYCLE ATM"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CycleATMScreen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CycleATMPanel)
        Me.Name = "CycleATMScreen"
        Me.Size = New System.Drawing.Size(1280, 756)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CycleATMPanel As AVP_Robot_Project.CycleATMPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
