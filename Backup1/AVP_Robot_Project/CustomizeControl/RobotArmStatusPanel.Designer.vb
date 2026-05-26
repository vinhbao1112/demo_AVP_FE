<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RobotArmStatusPanel
  Inherits AVP_Robot_Project.PVDStatusBoard
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
        Me.lblPM3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnDNStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnUPStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnREStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnEXStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'lblPM3
        '
        Me.lblPM3.BackColor = System.Drawing.Color.Transparent
        Me.lblPM3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPM3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPM3.ForeColor = System.Drawing.Color.White
        Me.lblPM3.Location = New System.Drawing.Point(21, 8)
        Me.lblPM3.Name = "lblPM3"
        Me.lblPM3.Size = New System.Drawing.Size(45, 15)
        Me.lblPM3.TabIndex = 22
        Me.lblPM3.Text = "EX"
        Me.lblPM3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(69, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "RE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(117, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "UP"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(165, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "DN"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDNStatus
        '
        Me.btnDNStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnDNStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnDNStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDNStatus.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnDNStatus.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnDNStatus.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnDNStatus.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnDNStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDNStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnDNStatus.ErrorText = ""
        Me.btnDNStatus.FlatAppearance.BorderSize = 0
        Me.btnDNStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDNStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDNStatus.ForeColor = System.Drawing.Color.White
        Me.btnDNStatus.Location = New System.Drawing.Point(154, 11)
        Me.btnDNStatus.Name = "btnDNStatus"
        Me.btnDNStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnDNStatus.OffText = ""
        Me.btnDNStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnDNStatus.OnText = ""
        Me.btnDNStatus.Size = New System.Drawing.Size(19, 12)
        Me.btnDNStatus.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnDNStatus.StyleOfButton = ButtonStyle.Horizontal
        Me.btnDNStatus.TabIndex = 21
        Me.btnDNStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnDNStatus.UnKnownText = ""
        Me.btnDNStatus.UseVisualStyleBackColor = False
        '
        'btnUPStatus
        '
        Me.btnUPStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnUPStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnUPStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUPStatus.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnUPStatus.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnUPStatus.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnUPStatus.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnUPStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUPStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnUPStatus.ErrorText = ""
        Me.btnUPStatus.FlatAppearance.BorderSize = 0
        Me.btnUPStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUPStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUPStatus.ForeColor = System.Drawing.Color.White
        Me.btnUPStatus.Location = New System.Drawing.Point(106, 11)
        Me.btnUPStatus.Name = "btnUPStatus"
        Me.btnUPStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnUPStatus.OffText = ""
        Me.btnUPStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnUPStatus.OnText = ""
        Me.btnUPStatus.Size = New System.Drawing.Size(19, 12)
        Me.btnUPStatus.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnUPStatus.StyleOfButton = ButtonStyle.Horizontal
        Me.btnUPStatus.TabIndex = 21
        Me.btnUPStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnUPStatus.UnKnownText = ""
        Me.btnUPStatus.UseVisualStyleBackColor = False
        '
        'btnREStatus
        '
        Me.btnREStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnREStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnREStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnREStatus.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnREStatus.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnREStatus.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnREStatus.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnREStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnREStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnREStatus.ErrorText = ""
        Me.btnREStatus.FlatAppearance.BorderSize = 0
        Me.btnREStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnREStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnREStatus.ForeColor = System.Drawing.Color.White
        Me.btnREStatus.Location = New System.Drawing.Point(58, 10)
        Me.btnREStatus.Name = "btnREStatus"
        Me.btnREStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnREStatus.OffText = ""
        Me.btnREStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnREStatus.OnText = ""
        Me.btnREStatus.Size = New System.Drawing.Size(19, 12)
        Me.btnREStatus.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnREStatus.StyleOfButton = ButtonStyle.Horizontal
        Me.btnREStatus.TabIndex = 21
        Me.btnREStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnREStatus.UnKnownText = ""
        Me.btnREStatus.UseVisualStyleBackColor = False
        '
        'btnEXStatus
        '
        Me.btnEXStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnEXStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnEXStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEXStatus.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnEXStatus.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnEXStatus.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnEXStatus.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnEXStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEXStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnEXStatus.ErrorText = ""
        Me.btnEXStatus.FlatAppearance.BorderSize = 0
        Me.btnEXStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEXStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEXStatus.ForeColor = System.Drawing.Color.White
        Me.btnEXStatus.Location = New System.Drawing.Point(10, 10)
        Me.btnEXStatus.Name = "btnEXStatus"
        Me.btnEXStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnEXStatus.OffText = ""
        Me.btnEXStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnEXStatus.OnText = ""
        Me.btnEXStatus.Size = New System.Drawing.Size(19, 12)
        Me.btnEXStatus.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnEXStatus.StyleOfButton = ButtonStyle.Horizontal
        Me.btnEXStatus.TabIndex = 21
        Me.btnEXStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnEXStatus.UnKnownText = ""
        Me.btnEXStatus.UseVisualStyleBackColor = False
        '
        'RobotArmStatusPanel
        '
        Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnDNStatus)
        Me.Controls.Add(Me.btnUPStatus)
        Me.Controls.Add(Me.btnREStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnEXStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPM3)
        Me.DoubleBuffered = True
        Me.HeaderVisible = False
        Me.Name = "RobotArmStatusPanel"
        Me.Size = New System.Drawing.Size(216, 33)
        Me.Controls.SetChildIndex(Me.lblPM3, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnEXStatus, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.btnREStatus, 0)
        Me.Controls.SetChildIndex(Me.btnUPStatus, 0)
        Me.Controls.SetChildIndex(Me.btnDNStatus, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEXStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents lblPM3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnREStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnUPStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnDNStatus As AVP_Robot_Project.ButtonIGCGControl

End Class
