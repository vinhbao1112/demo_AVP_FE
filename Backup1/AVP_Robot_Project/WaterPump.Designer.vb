<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WaterPump
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
        Me.txtT2 = New System.Windows.Forms.TextBox()
        Me.btnOn = New System.Windows.Forms.Button()
        Me.btnRegen = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlCom = New System.Windows.Forms.Panel()
        Me.btnComStatus = New AVP_Robot_Project.ButtonIGCGControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblComunicationLED = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblT = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtT = New System.Windows.Forms.TextBox()
        Me.btnFastRegen = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.pnlCom.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Text = "WaterPump"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'txtT2
        '
        Me.txtT2.Location = New System.Drawing.Point(179, 54)
        Me.txtT2.Name = "txtT2"
        Me.txtT2.ReadOnly = True
        Me.txtT2.Size = New System.Drawing.Size(10, 29)
        Me.txtT2.TabIndex = 9
        Me.txtT2.Visible = False
        '
        'btnOn
        '
        Me.btnOn.BackColor = System.Drawing.Color.Transparent
        Me.btnOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOn.ForeColor = System.Drawing.Color.Black
        Me.btnOn.Location = New System.Drawing.Point(10, 59)
        Me.btnOn.Name = "btnOn"
        Me.btnOn.Size = New System.Drawing.Size(70, 25)
        Me.btnOn.TabIndex = 11
        Me.btnOn.Text = "On"
        Me.btnOn.UseVisualStyleBackColor = False
        '
        'btnRegen
        '
        Me.btnRegen.BackColor = System.Drawing.Color.Transparent
        Me.btnRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRegen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRegen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegen.ForeColor = System.Drawing.Color.Black
        Me.btnRegen.Location = New System.Drawing.Point(109, 59)
        Me.btnRegen.Name = "btnRegen"
        Me.btnRegen.Size = New System.Drawing.Size(70, 25)
        Me.btnRegen.TabIndex = 10
        Me.btnRegen.Text = "Regen"
        Me.btnRegen.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgMsgBoxHeader
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.pnlCom)
        Me.Panel1.Controls.Add(Me.lblComunicationLED)
        Me.Panel1.Controls.Add(Me.lblHeader)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(190, 27)
        Me.Panel1.TabIndex = 12
        '
        'pnlCom
        '
        Me.pnlCom.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgCommunication
        Me.pnlCom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlCom.Controls.Add(Me.btnComStatus)
        Me.pnlCom.Controls.Add(Me.Label1)
        Me.pnlCom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlCom.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCom.Location = New System.Drawing.Point(125, 0)
        Me.pnlCom.Name = "pnlCom"
        Me.pnlCom.Size = New System.Drawing.Size(65, 27)
        Me.pnlCom.TabIndex = 37
        '
        'btnComStatus
        '
        Me.btnComStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnComStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnComStatus.CausesValidation = False
        Me.btnComStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnComStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnComStatus.FlatAppearance.BorderSize = 0
        Me.btnComStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnComStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnComStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnComStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComStatus.ForeColor = System.Drawing.Color.White
        Me.btnComStatus.Location = New System.Drawing.Point(42, 5)
        Me.btnComStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnComStatus.Name = "btnComStatus"
        Me.btnComStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.btnComStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.btnComStatus.Size = New System.Drawing.Size(17, 17)
        Me.btnComStatus.TabIndex = 36
        Me.btnComStatus.TabStop = False
        Me.btnComStatus.TextLocation = New System.Drawing.Point(0, 0)
        Me.btnComStatus.TextLocIsFix = True
        Me.btnComStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.btnComStatus.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 27)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "COM."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblComunicationLED
        '
        Me.lblComunicationLED.BackColor = System.Drawing.Color.Red
        Me.lblComunicationLED.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblComunicationLED.Location = New System.Drawing.Point(191, 8)
        Me.lblComunicationLED.Name = "lblComunicationLED"
        Me.lblComunicationLED.Size = New System.Drawing.Size(19, 12)
        Me.lblComunicationLED.TabIndex = 30
        '
        'lblHeader
        '
        Me.lblHeader.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(103, 27)
        Me.lblHeader.TabIndex = 7
        Me.lblHeader.Text = "WaterPump"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.lblT)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(190, 30)
        Me.Panel2.TabIndex = 13
        '
        'lblT
        '
        Me.lblT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblT.BackColor = System.Drawing.Color.Transparent
        Me.lblT.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblT.ForeColor = System.Drawing.Color.Lime
        Me.lblT.Location = New System.Drawing.Point(99, 1)
        Me.lblT.Name = "lblT"
        Me.lblT.Padding = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.lblT.Size = New System.Drawing.Size(89, 27)
        Me.lblT.TabIndex = 11
        Me.lblT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(32, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(61, 27)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "TEMP."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtT
        '
        Me.txtT.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtT.Location = New System.Drawing.Point(0, 57)
        Me.txtT.Name = "txtT"
        Me.txtT.ReadOnly = True
        Me.txtT.Size = New System.Drawing.Size(10, 29)
        Me.txtT.TabIndex = 14
        Me.txtT.Visible = False
        '
        'btnFastRegen
        '
        Me.btnFastRegen.BackColor = System.Drawing.Color.Transparent
        Me.btnFastRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnFastRegen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFastRegen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFastRegen.ForeColor = System.Drawing.Color.Black
        Me.btnFastRegen.Location = New System.Drawing.Point(57, 64)
        Me.btnFastRegen.Name = "btnFastRegen"
        Me.btnFastRegen.Size = New System.Drawing.Size(80, 25)
        Me.btnFastRegen.TabIndex = 15
        Me.btnFastRegen.Text = "Fast Regen"
        Me.btnFastRegen.UseVisualStyleBackColor = False
        Me.btnFastRegen.Visible = False
        '
        'WaterPump
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.btnFastRegen)
        Me.Controls.Add(Me.txtT)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnOn)
        Me.Controls.Add(Me.btnRegen)
        Me.Controls.Add(Me.txtT2)
        Me.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderFont = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderText = "WaterPump"
        Me.HeaderVisible = False
        Me.Name = "WaterPump"
        Me.Size = New System.Drawing.Size(190, 90)
        Me.Text = "WaterPump"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.txtT2, 0)
        Me.Controls.SetChildIndex(Me.btnRegen, 0)
        Me.Controls.SetChildIndex(Me.btnOn, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.txtT, 0)
        Me.Controls.SetChildIndex(Me.btnFastRegen, 0)
        Me.Panel1.ResumeLayout(False)
        Me.pnlCom.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtT2 As System.Windows.Forms.TextBox
    Friend WithEvents btnOn As System.Windows.Forms.Button
    Friend WithEvents btnRegen As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblComunicationLED As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblT As System.Windows.Forms.Label
    Friend WithEvents txtT As System.Windows.Forms.TextBox
    Friend WithEvents btnFastRegen As System.Windows.Forms.Button
    Friend WithEvents btnComStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents pnlCom As System.Windows.Forms.Panel

End Class
