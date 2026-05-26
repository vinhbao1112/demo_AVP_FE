<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrAlignmentInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usrAlignmentInfo))
        Me.lblEccentricityAngle = New System.Windows.Forms.Label
        Me.txtEccentricityAngle = New System.Windows.Forms.TextBox
        Me.lblEccentricityMagnitude = New System.Windows.Forms.Label
        Me.lblDeltaR = New System.Windows.Forms.Label
        Me.lblDeltaT = New System.Windows.Forms.Label
        Me.lblFiducialAngle = New System.Windows.Forms.Label
        Me.lblRescanNeeded = New System.Windows.Forms.Label
        Me.txtEccentricityMagnitude = New System.Windows.Forms.TextBox
        Me.txtDeltaR = New System.Windows.Forms.TextBox
        Me.txtDeltaT = New System.Windows.Forms.TextBox
        Me.txtFiducialAngle = New System.Windows.Forms.TextBox
        Me.txtRescanNeeded = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.pnlHeader = New System.Windows.Forms.Panel
        Me.lblHeader = New System.Windows.Forms.Label
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = CType(resources.GetObject("Header.BackgroundImage"), System.Drawing.Image)
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.Status = AVP_Robot_Project.DisplayStatus.[On]
        Me.Header.Text = "Alignment Information"
        '
        'lblEccentricityAngle
        '
        Me.lblEccentricityAngle.AutoSize = True
        Me.lblEccentricityAngle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEccentricityAngle.Location = New System.Drawing.Point(11, 53)
        Me.lblEccentricityAngle.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblEccentricityAngle.Name = "lblEccentricityAngle"
        Me.lblEccentricityAngle.Size = New System.Drawing.Size(130, 19)
        Me.lblEccentricityAngle.TabIndex = 39
        Me.lblEccentricityAngle.Text = "Eccentricity Angle"
        '
        'txtEccentricityAngle
        '
        Me.txtEccentricityAngle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEccentricityAngle.Location = New System.Drawing.Point(180, 45)
        Me.txtEccentricityAngle.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtEccentricityAngle.Multiline = True
        Me.txtEccentricityAngle.Name = "txtEccentricityAngle"
        Me.txtEccentricityAngle.ReadOnly = True
        Me.txtEccentricityAngle.Size = New System.Drawing.Size(236, 35)
        Me.txtEccentricityAngle.TabIndex = 40
        '
        'lblEccentricityMagnitude
        '
        Me.lblEccentricityMagnitude.AutoSize = True
        Me.lblEccentricityMagnitude.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEccentricityMagnitude.Location = New System.Drawing.Point(11, 97)
        Me.lblEccentricityMagnitude.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblEccentricityMagnitude.Name = "lblEccentricityMagnitude"
        Me.lblEccentricityMagnitude.Size = New System.Drawing.Size(165, 19)
        Me.lblEccentricityMagnitude.TabIndex = 43
        Me.lblEccentricityMagnitude.Text = "Eccentricity Magnitude"
        '
        'lblDeltaR
        '
        Me.lblDeltaR.AutoSize = True
        Me.lblDeltaR.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeltaR.Location = New System.Drawing.Point(11, 140)
        Me.lblDeltaR.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDeltaR.Name = "lblDeltaR"
        Me.lblDeltaR.Size = New System.Drawing.Size(62, 19)
        Me.lblDeltaR.TabIndex = 46
        Me.lblDeltaR.Text = "Delta R"
        '
        'lblDeltaT
        '
        Me.lblDeltaT.AutoSize = True
        Me.lblDeltaT.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeltaT.Location = New System.Drawing.Point(11, 183)
        Me.lblDeltaT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDeltaT.Name = "lblDeltaT"
        Me.lblDeltaT.Size = New System.Drawing.Size(60, 19)
        Me.lblDeltaT.TabIndex = 53
        Me.lblDeltaT.Text = "Delta T"
        '
        'lblFiducialAngle
        '
        Me.lblFiducialAngle.AutoSize = True
        Me.lblFiducialAngle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiducialAngle.Location = New System.Drawing.Point(11, 226)
        Me.lblFiducialAngle.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblFiducialAngle.Name = "lblFiducialAngle"
        Me.lblFiducialAngle.Size = New System.Drawing.Size(103, 19)
        Me.lblFiducialAngle.TabIndex = 53
        Me.lblFiducialAngle.Text = "Fiducial Angle"
        '
        'lblRescanNeeded
        '
        Me.lblRescanNeeded.AutoSize = True
        Me.lblRescanNeeded.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRescanNeeded.Location = New System.Drawing.Point(11, 270)
        Me.lblRescanNeeded.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblRescanNeeded.Name = "lblRescanNeeded"
        Me.lblRescanNeeded.Size = New System.Drawing.Size(115, 19)
        Me.lblRescanNeeded.TabIndex = 53
        Me.lblRescanNeeded.Text = "Rescan Needed"
        '
        'txtEccentricityMagnitude
        '
        Me.txtEccentricityMagnitude.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEccentricityMagnitude.Location = New System.Drawing.Point(180, 89)
        Me.txtEccentricityMagnitude.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtEccentricityMagnitude.Multiline = True
        Me.txtEccentricityMagnitude.Name = "txtEccentricityMagnitude"
        Me.txtEccentricityMagnitude.ReadOnly = True
        Me.txtEccentricityMagnitude.Size = New System.Drawing.Size(236, 35)
        Me.txtEccentricityMagnitude.TabIndex = 40
        '
        'txtDeltaR
        '
        Me.txtDeltaR.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaR.Location = New System.Drawing.Point(180, 132)
        Me.txtDeltaR.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtDeltaR.Multiline = True
        Me.txtDeltaR.Name = "txtDeltaR"
        Me.txtDeltaR.ReadOnly = True
        Me.txtDeltaR.Size = New System.Drawing.Size(236, 35)
        Me.txtDeltaR.TabIndex = 40
        '
        'txtDeltaT
        '
        Me.txtDeltaT.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaT.Location = New System.Drawing.Point(180, 175)
        Me.txtDeltaT.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtDeltaT.Multiline = True
        Me.txtDeltaT.Name = "txtDeltaT"
        Me.txtDeltaT.ReadOnly = True
        Me.txtDeltaT.Size = New System.Drawing.Size(236, 35)
        Me.txtDeltaT.TabIndex = 40
        '
        'txtFiducialAngle
        '
        Me.txtFiducialAngle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiducialAngle.Location = New System.Drawing.Point(180, 218)
        Me.txtFiducialAngle.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtFiducialAngle.Multiline = True
        Me.txtFiducialAngle.Name = "txtFiducialAngle"
        Me.txtFiducialAngle.ReadOnly = True
        Me.txtFiducialAngle.Size = New System.Drawing.Size(236, 35)
        Me.txtFiducialAngle.TabIndex = 40
        '
        'txtRescanNeeded
        '
        Me.txtRescanNeeded.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRescanNeeded.Location = New System.Drawing.Point(180, 262)
        Me.txtRescanNeeded.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtRescanNeeded.Multiline = True
        Me.txtRescanNeeded.Name = "txtRescanNeeded"
        Me.txtRescanNeeded.ReadOnly = True
        Me.txtRescanNeeded.Size = New System.Drawing.Size(236, 35)
        Me.txtRescanNeeded.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(419, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 19)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "deg"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(417, 97)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 19)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "mils"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(417, 140)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 19)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "mils"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(419, 183)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 19)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "deg"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(419, 226)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 19)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "deg"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.Transparent
        Me.pnlHeader.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgMsgBoxHeader
        Me.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(692, 30)
        Me.pnlHeader.TabIndex = 54
        '
        'lblHeader
        '
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(692, 30)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Alignment Information"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'usrAlignmentInfo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.txtEccentricityMagnitude)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.lblRescanNeeded)
        Me.Controls.Add(Me.lblFiducialAngle)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblDeltaT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDeltaR)
        Me.Controls.Add(Me.lblEccentricityMagnitude)
        Me.Controls.Add(Me.lblEccentricityAngle)
        Me.Controls.Add(Me.txtRescanNeeded)
        Me.Controls.Add(Me.txtFiducialAngle)
        Me.Controls.Add(Me.txtDeltaT)
        Me.Controls.Add(Me.txtDeltaR)
        Me.Controls.Add(Me.txtEccentricityAngle)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.HeaderVisible = False
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "usrAlignmentInfo"
        Me.Size = New System.Drawing.Size(692, 472)
        Me.Text = "Alignment Information"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.txtEccentricityAngle, 0)
        Me.Controls.SetChildIndex(Me.txtDeltaR, 0)
        Me.Controls.SetChildIndex(Me.txtDeltaT, 0)
        Me.Controls.SetChildIndex(Me.txtFiducialAngle, 0)
        Me.Controls.SetChildIndex(Me.txtRescanNeeded, 0)
        Me.Controls.SetChildIndex(Me.lblEccentricityAngle, 0)
        Me.Controls.SetChildIndex(Me.lblEccentricityMagnitude, 0)
        Me.Controls.SetChildIndex(Me.lblDeltaR, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblDeltaT, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblFiducialAngle, 0)
        Me.Controls.SetChildIndex(Me.lblRescanNeeded, 0)
        Me.Controls.SetChildIndex(Me.pnlHeader, 0)
        Me.Controls.SetChildIndex(Me.txtEccentricityMagnitude, 0)
        Me.pnlHeader.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEccentricityAngle As System.Windows.Forms.Label
    Friend WithEvents txtEccentricityAngle As System.Windows.Forms.TextBox
    Friend WithEvents lblEccentricityMagnitude As System.Windows.Forms.Label
    Friend WithEvents lblDeltaR As System.Windows.Forms.Label
    Friend WithEvents lblDeltaT As System.Windows.Forms.Label
    Friend WithEvents lblFiducialAngle As System.Windows.Forms.Label
    Friend WithEvents lblRescanNeeded As System.Windows.Forms.Label
    Friend WithEvents txtEccentricityMagnitude As System.Windows.Forms.TextBox
    Friend WithEvents txtDeltaR As System.Windows.Forms.TextBox
    Friend WithEvents txtDeltaT As System.Windows.Forms.TextBox
    Friend WithEvents txtFiducialAngle As System.Windows.Forms.TextBox
    Friend WithEvents txtRescanNeeded As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label

End Class
