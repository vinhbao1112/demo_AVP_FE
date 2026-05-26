<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDStatusBoard
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
        Me.Header = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackColor = System.Drawing.Color.Transparent
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Header.Font = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.Header.ForeColor = System.Drawing.Color.White
        Me.Header.Location = New System.Drawing.Point(0, 0)
        Me.Header.Name = "Header"
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Size = New System.Drawing.Size(150, 27)
        Me.Header.TabIndex = 7
        Me.Header.Text = "Header"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        Me.Header.UseVisualStyleBackColor = False
        '
        'PVDStatusBoard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Header)
        Me.Name = "PVDStatusBoard"
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents Header As AVP_Robot_Project.ButtonIGCGControl

End Class
