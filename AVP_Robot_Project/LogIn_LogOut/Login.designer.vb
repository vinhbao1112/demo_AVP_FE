<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits AVPControls.AVPPopupForm

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
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.btnLogin = New AVPControls.AVPButton
        Me.btnCancel = New AVPControls.AVPButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnQuit = New AVPControls.AVPButton
        Me.btnLogOut = New AVPControls.AVPButton
        Me.cmbUsername = New System.Windows.Forms.ComboBox
        Me.btnShowAllUserName = New AVPControls.AVPButton
        Me.FormContainer.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.btnShowAllUserName)
        Me.FormContainer.Controls.Add(Me.cmbUsername)
        Me.FormContainer.Controls.Add(Me.Panel1)
        Me.FormContainer.Controls.Add(Me.Label3)
        Me.FormContainer.Controls.Add(Me.Label2)
        Me.FormContainer.Controls.Add(Me.Label1)
        Me.FormContainer.Controls.Add(Me.txtPassword)
        Me.FormContainer.Location = New System.Drawing.Point(0, 0)
        Me.FormContainer.Size = New System.Drawing.Size(515, 252)
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(122, 147)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(371, 26)
        Me.txtPassword.TabIndex = 13
        '
        'btnLogin
        '
        Me.btnLogin.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Image = Global.AVP_Robot_Project.My.Resources.Resources.Key
        Me.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogin.Location = New System.Drawing.Point(136, 11)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLogin.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnLogin.Size = New System.Drawing.Size(114, 38)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.AVP_Robot_Project.My.Resources.Resources.ErrorImage
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(262, 11)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnCancel.Size = New System.Drawing.Size(114, 38)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(122, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 22)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Enter Username and password"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Username"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Password"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(515, 4)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnQuit)
        Me.Panel1.Controls.Add(Me.btnLogOut)
        Me.Panel1.Controls.Add(Me.btnLogin)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 192)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(515, 60)
        Me.Panel1.TabIndex = 11
        '
        'btnQuit
        '
        Me.btnQuit.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.Enabled = False
        Me.btnQuit.FlatAppearance.BorderSize = 0
        Me.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnQuit.Image = Global.AVP_Robot_Project.My.Resources.Resources.Shutdown
        Me.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuit.Location = New System.Drawing.Point(388, 11)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnQuit.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnQuit.Size = New System.Drawing.Size(114, 40)
        Me.btnQuit.TabIndex = 12
        Me.btnQuit.Text = "  Exit"
        Me.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'btnLogOut
        '
        Me.btnLogOut.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogOut.Enabled = False
        Me.btnLogOut.FlatAppearance.BorderSize = 0
        Me.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogOut.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLogOut.Image = Global.AVP_Robot_Project.My.Resources.Resources.LogOff
        Me.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogOut.Location = New System.Drawing.Point(9, 10)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLogOut.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnLogOut.Size = New System.Drawing.Size(114, 40)
        Me.btnLogOut.TabIndex = 11
        Me.btnLogOut.Text = "      Log Out"
        Me.btnLogOut.UseVisualStyleBackColor = True
        '
        'cmbUsername
        '
        Me.cmbUsername.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsername.FormattingEnabled = True
        Me.cmbUsername.Location = New System.Drawing.Point(122, 103)
        Me.cmbUsername.Name = "cmbUsername"
        Me.cmbUsername.Size = New System.Drawing.Size(312, 26)
        Me.cmbUsername.TabIndex = 12
        '
        'btnShowAllUserName
        '
        Me.btnShowAllUserName.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.agt_forum
        Me.btnShowAllUserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnShowAllUserName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowAllUserName.FlatAppearance.BorderSize = 0
        Me.btnShowAllUserName.Location = New System.Drawing.Point(440, 98)
        Me.btnShowAllUserName.Name = "btnShowAllUserName"
        Me.btnShowAllUserName.Size = New System.Drawing.Size(53, 36)
        Me.btnShowAllUserName.TabIndex = 1
        Me.btnShowAllUserName.UseVisualStyleBackColor = False
        '
        'Login
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AVPBorderStyle = AVPControls.AVPDataLib.AVPBorderStyles.None
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LoginBox1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(515, 252)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.ShowInTaskbar = False
        Me.ShowTitle = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.FormContainer.ResumeLayout(False)
        Me.FormContainer.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As AVPControls.AVPButton
    Friend WithEvents btnCancel As AVPControls.AVPButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbUsername As System.Windows.Forms.ComboBox
    Friend WithEvents btnShowAllUserName As AVPControls.AVPButton
    Friend WithEvents btnLogOut As AVPControls.AVPButton
    Friend WithEvents btnQuit As AVPControls.AVPButton
End Class
