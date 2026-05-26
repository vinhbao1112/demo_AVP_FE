<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommunicationControl
    Inherits AVPStatusControlBase

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
        Me.pnlHeaderCom = New AVPControls.AVPPanel
        Me.pnlCom = New AVPControls.AVPPanel
        Me.ComPanel2 = New AVPControls.AVPPanel
        Me.LED2 = New AVPControls.LEDControl
        Me.ComLabel2 = New System.Windows.Forms.Label
        Me.ComPanel1 = New AVPControls.AVPPanel
        Me.LED = New AVPControls.LEDControl
        Me.ComLabel1 = New System.Windows.Forms.Label
        Me.ComPanel = New AVPControls.AVPPanel
        Me.lblCom = New System.Windows.Forms.Label
        Me.pnlComLeftEdge = New AVPControls.AVPPanel
        Me.pnlComRightEdge = New AVPControls.AVPPanel
        Me.pnlComBottomEdge = New AVPControls.AVPPanel
        Me.pnlComTopEdge = New AVPControls.AVPPanel
        Me.pnlHeaderCom.SuspendLayout()
        Me.pnlCom.SuspendLayout()
        Me.ComPanel2.SuspendLayout()
        CType(Me.LED2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ComPanel1.SuspendLayout()
        CType(Me.LED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ComPanel.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeaderCom
        '
        Me.pnlHeaderCom.BackColor = System.Drawing.Color.Transparent
        Me.pnlHeaderCom.Controls.Add(Me.pnlCom)
        Me.pnlHeaderCom.Controls.Add(Me.pnlComLeftEdge)
        Me.pnlHeaderCom.Controls.Add(Me.pnlComRightEdge)
        Me.pnlHeaderCom.Controls.Add(Me.pnlComBottomEdge)
        Me.pnlHeaderCom.Controls.Add(Me.pnlComTopEdge)
        Me.pnlHeaderCom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeaderCom.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeaderCom.Name = "pnlHeaderCom"
        Me.pnlHeaderCom.Size = New System.Drawing.Size(126, 28)
        Me.pnlHeaderCom.TabIndex = 3
        Me.pnlHeaderCom.Translucent = True
        '
        'pnlCom
        '
        Me.pnlCom.BackColor = System.Drawing.Color.Transparent
        Me.pnlCom.BackgroundImage = Global.AVPControls.My.Resources.Resources.BgCommunication
        Me.pnlCom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCom.Controls.Add(Me.ComPanel2)
        Me.pnlCom.Controls.Add(Me.ComPanel1)
        Me.pnlCom.Controls.Add(Me.ComPanel)
        Me.pnlCom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCom.EnableFormLevelDoubleBuffering = True
        Me.pnlCom.Location = New System.Drawing.Point(5, 4)
        Me.pnlCom.Name = "pnlCom"
        Me.pnlCom.Size = New System.Drawing.Size(116, 20)
        Me.pnlCom.TabIndex = 8
        '
        'ComPanel2
        '
        Me.ComPanel2.Controls.Add(Me.LED2)
        Me.ComPanel2.Controls.Add(Me.ComLabel2)
        Me.ComPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ComPanel2.Location = New System.Drawing.Point(80, 0)
        Me.ComPanel2.Name = "ComPanel2"
        Me.ComPanel2.Size = New System.Drawing.Size(39, 20)
        Me.ComPanel2.TabIndex = 5
        Me.ComPanel2.Visible = False
        '
        'LED2
        '
        Me.LED2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LED2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.LED2.BackColor = System.Drawing.Color.Transparent
        Me.LED2.Location = New System.Drawing.Point(20, 2)
        Me.LED2.Name = "LED2"
        Me.LED2.Size = New System.Drawing.Size(15, 15)
        Me.LED2.TabIndex = 3
        '
        'ComLabel2
        '
        Me.ComLabel2.AutoSize = True
        Me.ComLabel2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComLabel2.ForeColor = System.Drawing.Color.White
        Me.ComLabel2.Location = New System.Drawing.Point(2, 3)
        Me.ComLabel2.Name = "ComLabel2"
        Me.ComLabel2.Size = New System.Drawing.Size(0, 13)
        Me.ComLabel2.TabIndex = 2
        Me.ComLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ComLabel2.Visible = False
        '
        'ComPanel1
        '
        Me.ComPanel1.Controls.Add(Me.LED)
        Me.ComPanel1.Controls.Add(Me.ComLabel1)
        Me.ComPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ComPanel1.Location = New System.Drawing.Point(41, 0)
        Me.ComPanel1.Name = "ComPanel1"
        Me.ComPanel1.Size = New System.Drawing.Size(39, 20)
        Me.ComPanel1.TabIndex = 4
        '
        'LED
        '
        Me.LED.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8
        Me.LED.BackColor = System.Drawing.Color.Transparent
        Me.LED.Location = New System.Drawing.Point(21, 2)
        Me.LED.Name = "LED"
        Me.LED.Size = New System.Drawing.Size(15, 15)
        Me.LED.TabIndex = 2
        '
        'ComLabel1
        '
        Me.ComLabel1.AutoSize = True
        Me.ComLabel1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComLabel1.ForeColor = System.Drawing.Color.White
        Me.ComLabel1.Location = New System.Drawing.Point(0, 3)
        Me.ComLabel1.Name = "ComLabel1"
        Me.ComLabel1.Size = New System.Drawing.Size(0, 13)
        Me.ComLabel1.TabIndex = 1
        Me.ComLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ComLabel1.Visible = False
        '
        'ComPanel
        '
        Me.ComPanel.Controls.Add(Me.lblCom)
        Me.ComPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.ComPanel.Location = New System.Drawing.Point(0, 0)
        Me.ComPanel.Name = "ComPanel"
        Me.ComPanel.Size = New System.Drawing.Size(41, 20)
        Me.ComPanel.TabIndex = 6
        '
        'lblCom
        '
        Me.lblCom.AutoSize = True
        Me.lblCom.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCom.ForeColor = System.Drawing.Color.White
        Me.lblCom.Location = New System.Drawing.Point(1, 3)
        Me.lblCom.Name = "lblCom"
        Me.lblCom.Size = New System.Drawing.Size(39, 13)
        Me.lblCom.TabIndex = 1
        Me.lblCom.Text = "COM."
        Me.lblCom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlComLeftEdge
        '
        Me.pnlComLeftEdge.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlComLeftEdge.Location = New System.Drawing.Point(0, 4)
        Me.pnlComLeftEdge.Name = "pnlComLeftEdge"
        Me.pnlComLeftEdge.Size = New System.Drawing.Size(5, 20)
        Me.pnlComLeftEdge.TabIndex = 3
        '
        'pnlComRightEdge
        '
        Me.pnlComRightEdge.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlComRightEdge.Location = New System.Drawing.Point(121, 4)
        Me.pnlComRightEdge.Name = "pnlComRightEdge"
        Me.pnlComRightEdge.Size = New System.Drawing.Size(5, 20)
        Me.pnlComRightEdge.TabIndex = 2
        Me.pnlComRightEdge.Translucent = True
        '
        'pnlComBottomEdge
        '
        Me.pnlComBottomEdge.BackColor = System.Drawing.Color.Transparent
        Me.pnlComBottomEdge.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlComBottomEdge.Location = New System.Drawing.Point(0, 24)
        Me.pnlComBottomEdge.Name = "pnlComBottomEdge"
        Me.pnlComBottomEdge.Size = New System.Drawing.Size(126, 4)
        Me.pnlComBottomEdge.TabIndex = 1
        Me.pnlComBottomEdge.Translucent = True
        '
        'pnlComTopEdge
        '
        Me.pnlComTopEdge.BackColor = System.Drawing.Color.Transparent
        Me.pnlComTopEdge.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlComTopEdge.Location = New System.Drawing.Point(0, 0)
        Me.pnlComTopEdge.Name = "pnlComTopEdge"
        Me.pnlComTopEdge.Size = New System.Drawing.Size(126, 4)
        Me.pnlComTopEdge.TabIndex = 0
        Me.pnlComTopEdge.Translucent = True
        '
        'CommunicationControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pnlHeaderCom)
        Me.MinimumSize = New System.Drawing.Size(68, 0)
        Me.Name = "CommunicationControl"
        Me.Size = New System.Drawing.Size(126, 28)
        Me.pnlHeaderCom.ResumeLayout(False)
        Me.pnlCom.ResumeLayout(False)
        Me.ComPanel2.ResumeLayout(False)
        Me.ComPanel2.PerformLayout()
        CType(Me.LED2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ComPanel1.ResumeLayout(False)
        Me.ComPanel1.PerformLayout()
        CType(Me.LED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ComPanel.ResumeLayout(False)
        Me.ComPanel.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pnlHeaderCom As AVPControls.AVPPanel
    Private WithEvents LED As AVPControls.LEDControl
    Private WithEvents pnlCom As AVPControls.AVPPanel
    Private WithEvents lblCom As System.Windows.Forms.Label
    Private WithEvents pnlComLeftEdge As AVPControls.AVPPanel
    Private WithEvents pnlComRightEdge As AVPControls.AVPPanel
    Private WithEvents pnlComBottomEdge As AVPControls.AVPPanel
    Private WithEvents pnlComTopEdge As AVPControls.AVPPanel
    Private WithEvents LED2 As AVPControls.LEDControl
    Private WithEvents ComLabel1 As System.Windows.Forms.Label
    Friend WithEvents ComPanel2 As AVPControls.AVPPanel
    Private WithEvents ComLabel2 As System.Windows.Forms.Label
    Friend WithEvents ComPanel1 As AVPControls.AVPPanel
    Friend WithEvents ComPanel As AVPControls.AVPPanel

End Class
