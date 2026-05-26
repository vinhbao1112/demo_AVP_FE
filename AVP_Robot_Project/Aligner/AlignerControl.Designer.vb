<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlignerControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlignerControl))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.usrOperations = New AVP_Robot_Project.usrOperationsAligner
        Me.btnToolLED = New AVP_Robot_Project.ButtonIGCGControl
        Me.lblDeltaR = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblDeltaT = New System.Windows.Forms.Label
        Me.txtDeltaT = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFiducialAngle = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDeltaR = New System.Windows.Forms.TextBox
        Me.lblFiducialAngle = New System.Windows.Forms.Label
        Me.txtEccentricityMagnitude = New System.Windows.Forms.TextBox
        Me.txtEccentricityAngle = New System.Windows.Forms.TextBox
        Me.usrWaferInfo = New AVP_Robot_Project.usrWaferInfo
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblEccA = New System.Windows.Forms.Label
        Me.lblEccM = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = CType(resources.GetObject("Header.BackgroundImage"), System.Drawing.Image)
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.Size = New System.Drawing.Size(150, 28)
        Me.Header.Status = AVP_Robot_Project.DisplayStatus.[On]
        Me.Header.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEccM)
        Me.GroupBox1.Controls.Add(Me.lblEccA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtEccentricityMagnitude)
        Me.GroupBox1.Controls.Add(Me.btnToolLED)
        Me.GroupBox1.Controls.Add(Me.txtEccentricityAngle)
        Me.GroupBox1.Controls.Add(Me.lblDeltaR)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblDeltaT)
        Me.GroupBox1.Controls.Add(Me.txtDeltaT)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFiducialAngle)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDeltaR)
        Me.GroupBox1.Controls.Add(Me.lblFiducialAngle)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(451, 172)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Aligner Control"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.usrOperations)
        Me.GroupBox2.Location = New System.Drawing.Point(248, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(206, 172)
        Me.GroupBox2.TabIndex = 103
        Me.GroupBox2.TabStop = False
        '
        'usrOperations
        '
        Me.usrOperations.BackColor = System.Drawing.Color.Transparent
        Me.usrOperations.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.usrOperations.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usrOperations.ForeColor = System.Drawing.Color.Black
        Me.usrOperations.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.usrOperations.HeaderHeight = 28
        Me.usrOperations.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.usrOperations.HeaderTextColor = System.Drawing.Color.Black
        Me.usrOperations.HeaderVisible = False
        Me.usrOperations.IsOnline = False
        Me.usrOperations.Location = New System.Drawing.Point(10, 19)
        Me.usrOperations.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.usrOperations.Name = "usrOperations"
        Me.usrOperations.Size = New System.Drawing.Size(187, 130)
        Me.usrOperations.TabIndex = 102
        Me.usrOperations.Text = "UsrOperationsAligner1"
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
        Me.btnToolLED.Location = New System.Drawing.Point(116, 3)
        Me.btnToolLED.Margin = New System.Windows.Forms.Padding(0)
        Me.btnToolLED.Name = "btnToolLED"
        Me.btnToolLED.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnToolLED.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnToolLED.Size = New System.Drawing.Size(15, 15)
        Me.btnToolLED.TabIndex = 103
        Me.btnToolLED.TabStop = False
        Me.btnToolLED.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnToolLED.UseVisualStyleBackColor = False
        '
        'lblDeltaR
        '
        Me.lblDeltaR.AutoSize = True
        Me.lblDeltaR.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeltaR.ForeColor = System.Drawing.Color.Black
        Me.lblDeltaR.Location = New System.Drawing.Point(6, 25)
        Me.lblDeltaR.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDeltaR.Name = "lblDeltaR"
        Me.lblDeltaR.Size = New System.Drawing.Size(58, 17)
        Me.lblDeltaR.TabIndex = 91
        Me.lblDeltaR.Text = "Delta R"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(209, 84)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 19)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "deg"
        '
        'lblDeltaT
        '
        Me.lblDeltaT.AutoSize = True
        Me.lblDeltaT.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeltaT.ForeColor = System.Drawing.Color.Black
        Me.lblDeltaT.Location = New System.Drawing.Point(6, 55)
        Me.lblDeltaT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDeltaT.Name = "lblDeltaT"
        Me.lblDeltaT.Size = New System.Drawing.Size(57, 17)
        Me.lblDeltaT.TabIndex = 96
        Me.lblDeltaT.Text = "Delta T"
        '
        'txtDeltaT
        '
        Me.txtDeltaT.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtDeltaT.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaT.Location = New System.Drawing.Point(125, 53)
        Me.txtDeltaT.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtDeltaT.Multiline = True
        Me.txtDeltaT.Name = "txtDeltaT"
        Me.txtDeltaT.ReadOnly = True
        Me.txtDeltaT.Size = New System.Drawing.Size(83, 20)
        Me.txtDeltaT.TabIndex = 89
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(209, 54)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 19)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "deg"
        '
        'txtFiducialAngle
        '
        Me.txtFiducialAngle.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtFiducialAngle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiducialAngle.Location = New System.Drawing.Point(125, 83)
        Me.txtFiducialAngle.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtFiducialAngle.Multiline = True
        Me.txtFiducialAngle.Name = "txtFiducialAngle"
        Me.txtFiducialAngle.ReadOnly = True
        Me.txtFiducialAngle.Size = New System.Drawing.Size(83, 20)
        Me.txtFiducialAngle.TabIndex = 87
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(209, 24)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 19)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "mils"
        '
        'txtDeltaR
        '
        Me.txtDeltaR.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtDeltaR.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaR.Location = New System.Drawing.Point(125, 23)
        Me.txtDeltaR.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtDeltaR.Multiline = True
        Me.txtDeltaR.Name = "txtDeltaR"
        Me.txtDeltaR.ReadOnly = True
        Me.txtDeltaR.Size = New System.Drawing.Size(83, 20)
        Me.txtDeltaR.TabIndex = 90
        '
        'lblFiducialAngle
        '
        Me.lblFiducialAngle.AutoSize = True
        Me.lblFiducialAngle.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiducialAngle.ForeColor = System.Drawing.Color.Black
        Me.lblFiducialAngle.Location = New System.Drawing.Point(6, 85)
        Me.lblFiducialAngle.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblFiducialAngle.Name = "lblFiducialAngle"
        Me.lblFiducialAngle.Size = New System.Drawing.Size(101, 17)
        Me.lblFiducialAngle.TabIndex = 95
        Me.lblFiducialAngle.Text = "Fiducial Angle"
        '
        'txtEccentricityMagnitude
        '
        Me.txtEccentricityMagnitude.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtEccentricityMagnitude.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEccentricityMagnitude.Location = New System.Drawing.Point(125, 143)
        Me.txtEccentricityMagnitude.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtEccentricityMagnitude.Multiline = True
        Me.txtEccentricityMagnitude.Name = "txtEccentricityMagnitude"
        Me.txtEccentricityMagnitude.ReadOnly = True
        Me.txtEccentricityMagnitude.Size = New System.Drawing.Size(83, 20)
        Me.txtEccentricityMagnitude.TabIndex = 42
        '
        'txtEccentricityAngle
        '
        Me.txtEccentricityAngle.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtEccentricityAngle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEccentricityAngle.Location = New System.Drawing.Point(125, 113)
        Me.txtEccentricityAngle.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtEccentricityAngle.Multiline = True
        Me.txtEccentricityAngle.Name = "txtEccentricityAngle"
        Me.txtEccentricityAngle.ReadOnly = True
        Me.txtEccentricityAngle.Size = New System.Drawing.Size(83, 20)
        Me.txtEccentricityAngle.TabIndex = 41
        '
        'usrWaferInfo
        '
        Me.usrWaferInfo.BackColor = System.Drawing.Color.White
        Me.usrWaferInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.usrWaferInfo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usrWaferInfo.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.usrWaferInfo.HeaderHeight = 28
        Me.usrWaferInfo.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.usrWaferInfo.HeaderTextColor = System.Drawing.Color.Black
        Me.usrWaferInfo.HeaderVisible = False
        Me.usrWaferInfo.Location = New System.Drawing.Point(111, 194)
        Me.usrWaferInfo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.usrWaferInfo.Name = "usrWaferInfo"
        Me.usrWaferInfo.Size = New System.Drawing.Size(294, 185)
        Me.usrWaferInfo.TabIndex = 43
        Me.usrWaferInfo.Text = "Wafer Information"
        Me.usrWaferInfo.UseBorderStyle = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(209, 114)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 19)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "deg"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(209, 144)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 19)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "mils"
        '
        'lblEccA
        '
        Me.lblEccA.AutoSize = True
        Me.lblEccA.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEccA.ForeColor = System.Drawing.Color.Black
        Me.lblEccA.Location = New System.Drawing.Point(6, 115)
        Me.lblEccA.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblEccA.Name = "lblEccA"
        Me.lblEccA.Size = New System.Drawing.Size(47, 17)
        Me.lblEccA.TabIndex = 106
        Me.lblEccA.Text = "Ecc.A"
        '
        'lblEccM
        '
        Me.lblEccM.AutoSize = True
        Me.lblEccM.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEccM.ForeColor = System.Drawing.Color.Black
        Me.lblEccM.Location = New System.Drawing.Point(6, 145)
        Me.lblEccM.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblEccM.Name = "lblEccM"
        Me.lblEccM.Size = New System.Drawing.Size(51, 17)
        Me.lblEccM.TabIndex = 107
        Me.lblEccM.Text = "Ecc.M"
        '
        'AlignerControl
        '
        Me.Controls.Add(Me.usrWaferInfo)
        Me.Controls.Add(Me.GroupBox1)
        Me.HeaderHeight = 28
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.HeaderVisible = False
        Me.Name = "AlignerControl"
        Me.Size = New System.Drawing.Size(464, 180)
        Me.Text = ""
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.usrWaferInfo, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDeltaR As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDeltaT As System.Windows.Forms.Label
    Friend WithEvents txtDeltaT As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFiducialAngle As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDeltaR As System.Windows.Forms.TextBox
    Friend WithEvents lblFiducialAngle As System.Windows.Forms.Label
    Friend WithEvents txtEccentricityMagnitude As System.Windows.Forms.TextBox
    Friend WithEvents txtEccentricityAngle As System.Windows.Forms.TextBox
    Friend WithEvents usrOperations As AVP_Robot_Project.usrOperationsAligner
    Friend WithEvents btnToolLED As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents usrWaferInfo As AVP_Robot_Project.usrWaferInfo
    Friend WithEvents lblEccM As System.Windows.Forms.Label
    Friend WithEvents lblEccA As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
