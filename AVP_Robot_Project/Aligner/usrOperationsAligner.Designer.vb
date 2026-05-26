<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrOperationsAligner
    Inherits AVP_Robot_Project.PVDStatusBoard

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usrOperationsAligner))
        Me.btnAlign = New AVPControls.AVPButton
        Me.btnScan = New AVPControls.AVPButton
        Me.btnHome = New AVPControls.AVPButton
        Me.cboAlignAngle = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnToolLED = New AVP_Robot_Project.ButtonIGCGControl
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = CType(resources.GetObject("Header.BackgroundImage"), System.Drawing.Image)
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.Size = New System.Drawing.Size(150, 28)
        Me.Header.Status = AVP_Robot_Project.DisplayStatus.[On]
        Me.Header.Text = "Operations"
        '
        'btnAlign
        '
        Me.btnAlign.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAlign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAlign.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAlign.FlatAppearance.BorderSize = 0
        Me.btnAlign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlign.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlign.ForeColor = System.Drawing.Color.Black
        Me.btnAlign.Image = Global.AVP_Robot_Project.My.Resources.Resources.Picture
        Me.btnAlign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAlign.Location = New System.Drawing.Point(5, 0)
        Me.btnAlign.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnAlign.Name = "btnAlign"
        Me.btnAlign.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAlign.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnAlign.Size = New System.Drawing.Size(100, 27)
        Me.btnAlign.TabIndex = 45
        Me.btnAlign.Text = "Align"
        Me.btnAlign.UseVisualStyleBackColor = True
        '
        'btnScan
        '
        Me.btnScan.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnScan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnScan.FlatAppearance.BorderSize = 0
        Me.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnScan.ForeColor = System.Drawing.Color.Black
        Me.btnScan.Image = Global.AVP_Robot_Project.My.Resources.Resources.Print
        Me.btnScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnScan.Location = New System.Drawing.Point(5, 39)
        Me.btnScan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnScan.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnScan.Size = New System.Drawing.Size(100, 27)
        Me.btnScan.TabIndex = 45
        Me.btnScan.Text = "Scan"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHome.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHome.FlatAppearance.BorderSize = 0
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnHome.ForeColor = System.Drawing.Color.Black
        Me.btnHome.Image = Global.AVP_Robot_Project.My.Resources.Resources.home_48
        Me.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHome.Location = New System.Drawing.Point(5, 78)
        Me.btnHome.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHome.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnHome.Size = New System.Drawing.Size(100, 27)
        Me.btnHome.TabIndex = 45
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'cboAlignAngle
        '
        Me.cboAlignAngle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboAlignAngle.FormattingEnabled = True
        Me.cboAlignAngle.Items.AddRange(New Object() {"0", "90", "180", "270"})
        Me.cboAlignAngle.Location = New System.Drawing.Point(112, 0)
        Me.cboAlignAngle.Name = "cboAlignAngle"
        Me.cboAlignAngle.Size = New System.Drawing.Size(69, 27)
        Me.cboAlignAngle.TabIndex = 82
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnToolLED)
        Me.Panel1.Controls.Add(Me.btnHome)
        Me.Panel1.Controls.Add(Me.cboAlignAngle)
        Me.Panel1.Controls.Add(Me.btnScan)
        Me.Panel1.Controls.Add(Me.btnAlign)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(187, 108)
        Me.Panel1.TabIndex = 83
        '
        'btnToolLED
        '
        Me.btnToolLED.BackColor = System.Drawing.Color.Transparent
        Me.btnToolLED.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnToolLED.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnToolLED.CausesValidation = False
        Me.btnToolLED.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnToolLED.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnToolLED.FlatAppearance.BorderSize = 0
        Me.btnToolLED.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnToolLED.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnToolLED.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToolLED.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToolLED.ForeColor = System.Drawing.Color.White
        Me.btnToolLED.Location = New System.Drawing.Point(153, 142)
        Me.btnToolLED.Margin = New System.Windows.Forms.Padding(0)
        Me.btnToolLED.Name = "btnToolLED"
        Me.btnToolLED.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnToolLED.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnToolLED.Size = New System.Drawing.Size(15, 15)
        Me.btnToolLED.TabIndex = 81
        Me.btnToolLED.TabStop = False
        Me.btnToolLED.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnToolLED.UseVisualStyleBackColor = False
        Me.btnToolLED.Visible = False
        '
        'usrOperationsAligner
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.HeaderHeight = 28
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.HeaderVisible = False
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "usrOperationsAligner"
        Me.Size = New System.Drawing.Size(187, 108)
        Me.Text = "Operations"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAlign As AVPControls.AVPButton
    Friend WithEvents btnScan As AVPControls.AVPButton
    Friend WithEvents btnHome As AVPControls.AVPButton
    Friend WithEvents cboAlignAngle As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnToolLED As AVP_Robot_Project.ButtonIGCGControl

End Class
