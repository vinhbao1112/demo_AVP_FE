<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoTransferWaferControl
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
        Me.chkRunWithRecipeA = New System.Windows.Forms.CheckBox
        Me.chkRunWithRecipeB = New System.Windows.Forms.CheckBox
        Me.btnDNStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnUPStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnREStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnEXStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkDisableChekingSensor = New System.Windows.Forms.CheckBox
        Me.txtCurrentPos = New AVP_Robot_Project.SL_Textbox
        Me.cboStationList = New System.Windows.Forms.ComboBox
        Me.btnHome = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnPlace = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnPick = New AVP_Robot_Project.ButtonIGCGControl
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Status = AVP_Robot_Project.DisplayStatus.[On]
        Me.Header.Text = "CYCLE WAFER"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'chkRunWithRecipeA
        '
        Me.chkRunWithRecipeA.AutoSize = True
        Me.chkRunWithRecipeA.BackColor = System.Drawing.Color.Transparent
        Me.chkRunWithRecipeA.Checked = True
        Me.chkRunWithRecipeA.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRunWithRecipeA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkRunWithRecipeA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRunWithRecipeA.Location = New System.Drawing.Point(398, 200)
        Me.chkRunWithRecipeA.Name = "chkRunWithRecipeA"
        Me.chkRunWithRecipeA.Size = New System.Drawing.Size(138, 23)
        Me.chkRunWithRecipeA.TabIndex = 2
        Me.chkRunWithRecipeA.Text = "Run with Recipe"
        Me.chkRunWithRecipeA.UseVisualStyleBackColor = False
        Me.chkRunWithRecipeA.Visible = False
        '
        'chkRunWithRecipeB
        '
        Me.chkRunWithRecipeB.AutoSize = True
        Me.chkRunWithRecipeB.BackColor = System.Drawing.Color.Transparent
        Me.chkRunWithRecipeB.Checked = True
        Me.chkRunWithRecipeB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRunWithRecipeB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkRunWithRecipeB.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRunWithRecipeB.Location = New System.Drawing.Point(398, 200)
        Me.chkRunWithRecipeB.Name = "chkRunWithRecipeB"
        Me.chkRunWithRecipeB.Size = New System.Drawing.Size(138, 23)
        Me.chkRunWithRecipeB.TabIndex = 5
        Me.chkRunWithRecipeB.Text = "Run with Recipe"
        Me.chkRunWithRecipeB.UseVisualStyleBackColor = False
        Me.chkRunWithRecipeB.Visible = False
        '
        'btnDNStatus
        '
        Me.btnDNStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnDNStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnDNStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDNStatus.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnDNStatus.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnDNStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDNStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnDNStatus.FlatAppearance.BorderSize = 0
        Me.btnDNStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDNStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDNStatus.ForeColor = System.Drawing.Color.Black
        Me.btnDNStatus.Location = New System.Drawing.Point(302, 97)
        Me.btnDNStatus.Name = "btnDNStatus"
        Me.btnDNStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDNStatus.OffText = "Down"
        Me.btnDNStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnDNStatus.OnText = "Down"
        Me.btnDNStatus.Size = New System.Drawing.Size(68, 60)
        Me.btnDNStatus.Status = AVP_Robot_Project.DisplayStatus.Unknow
        Me.btnDNStatus.TabIndex = 25
        Me.btnDNStatus.Text = "Down"
        Me.btnDNStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnDNStatus.UseVisualStyleBackColor = False
        '
        'btnUPStatus
        '
        Me.btnUPStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnUPStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnUPStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUPStatus.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnUPStatus.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnUPStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUPStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnUPStatus.FlatAppearance.BorderSize = 0
        Me.btnUPStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUPStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUPStatus.ForeColor = System.Drawing.Color.Black
        Me.btnUPStatus.Location = New System.Drawing.Point(302, 25)
        Me.btnUPStatus.Name = "btnUPStatus"
        Me.btnUPStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUPStatus.OffText = "Up"
        Me.btnUPStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnUPStatus.OnText = "Up"
        Me.btnUPStatus.Size = New System.Drawing.Size(68, 60)
        Me.btnUPStatus.Status = AVP_Robot_Project.DisplayStatus.Unknow
        Me.btnUPStatus.TabIndex = 26
        Me.btnUPStatus.Text = "Up"
        Me.btnUPStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnUPStatus.UseVisualStyleBackColor = False
        '
        'btnREStatus
        '
        Me.btnREStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnREStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnREStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnREStatus.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnREStatus.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnREStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnREStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnREStatus.FlatAppearance.BorderSize = 0
        Me.btnREStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnREStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnREStatus.ForeColor = System.Drawing.Color.Black
        Me.btnREStatus.Location = New System.Drawing.Point(372, 97)
        Me.btnREStatus.Name = "btnREStatus"
        Me.btnREStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnREStatus.OffText = "Retract"
        Me.btnREStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnREStatus.OnText = "Retract"
        Me.btnREStatus.Size = New System.Drawing.Size(68, 60)
        Me.btnREStatus.Status = AVP_Robot_Project.DisplayStatus.Unknow
        Me.btnREStatus.TabIndex = 23
        Me.btnREStatus.Text = "Retract"
        Me.btnREStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnREStatus.UnKnownText = "Retract"
        Me.btnREStatus.UseVisualStyleBackColor = False
        '
        'btnEXStatus
        '
        Me.btnEXStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnEXStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnEXStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEXStatus.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnEXStatus.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnEXStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEXStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnEXStatus.FlatAppearance.BorderSize = 0
        Me.btnEXStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEXStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEXStatus.ForeColor = System.Drawing.Color.Black
        Me.btnEXStatus.Location = New System.Drawing.Point(372, 25)
        Me.btnEXStatus.Name = "btnEXStatus"
        Me.btnEXStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnEXStatus.OffText = "Extend"
        Me.btnEXStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnEXStatus.OnText = "Extend"
        Me.btnEXStatus.Size = New System.Drawing.Size(68, 60)
        Me.btnEXStatus.Status = AVP_Robot_Project.DisplayStatus.Unknow
        Me.btnEXStatus.TabIndex = 24
        Me.btnEXStatus.Text = "Extend"
        Me.btnEXStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnEXStatus.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDisableChekingSensor)
        Me.GroupBox1.Controls.Add(Me.txtCurrentPos)
        Me.GroupBox1.Controls.Add(Me.cboStationList)
        Me.GroupBox1.Controls.Add(Me.btnHome)
        Me.GroupBox1.Controls.Add(Me.btnPlace)
        Me.GroupBox1.Controls.Add(Me.btnDNStatus)
        Me.GroupBox1.Controls.Add(Me.btnEXStatus)
        Me.GroupBox1.Controls.Add(Me.btnPick)
        Me.GroupBox1.Controls.Add(Me.btnUPStatus)
        Me.GroupBox1.Controls.Add(Me.btnREStatus)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(452, 172)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Robot Control"
        '
        'chkDisableChekingSensor
        '
        Me.chkDisableChekingSensor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDisableChekingSensor.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDisableChekingSensor.ForeColor = System.Drawing.Color.Black
        Me.chkDisableChekingSensor.Location = New System.Drawing.Point(9, 105)
        Me.chkDisableChekingSensor.Name = "chkDisableChekingSensor"
        Me.chkDisableChekingSensor.Size = New System.Drawing.Size(150, 44)
        Me.chkDisableChekingSensor.TabIndex = 44
        Me.chkDisableChekingSensor.Text = "Disable all wafers sensor checking"
        Me.chkDisableChekingSensor.UseVisualStyleBackColor = True
        '
        'txtCurrentPos
        '
        Me.txtCurrentPos.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCurrentPos.Clickable = False
        Me.txtCurrentPos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCurrentPos.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentPos.ForeColor = System.Drawing.Color.Black
        Me.txtCurrentPos.IsReadBack = True
        Me.txtCurrentPos.Location = New System.Drawing.Point(9, 26)
        Me.txtCurrentPos.Name = "txtCurrentPos"
        Me.txtCurrentPos.ReadOnly = True
        Me.txtCurrentPos.Size = New System.Drawing.Size(145, 24)
        Me.txtCurrentPos.TabIndex = 28
        Me.txtCurrentPos.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtCurrentPos.UseScientificFormat = True
        '
        'cboStationList
        '
        Me.cboStationList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboStationList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStationList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStationList.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cboStationList.FormattingEnabled = True
        Me.cboStationList.Location = New System.Drawing.Point(9, 59)
        Me.cboStationList.Name = "cboStationList"
        Me.cboStationList.Size = New System.Drawing.Size(145, 24)
        Me.cboStationList.TabIndex = 12
        '
        'btnHome
        '
        Me.btnHome.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHome.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnHome.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnHome.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHome.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnHome.FlatAppearance.BorderSize = 0
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHome.ForeColor = System.Drawing.Color.Black
        Me.btnHome.Location = New System.Drawing.Point(160, 25)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHome.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnHome.Size = New System.Drawing.Size(68, 60)
        Me.btnHome.TabIndex = 27
        Me.btnHome.Text = "HOME"
        Me.btnHome.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'btnPlace
        '
        Me.btnPlace.BackColor = System.Drawing.Color.Transparent
        Me.btnPlace.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPlace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPlace.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnPlace.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPlace.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPlace.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnPlace.FlatAppearance.BorderSize = 0
        Me.btnPlace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlace.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlace.ForeColor = System.Drawing.Color.Black
        Me.btnPlace.Location = New System.Drawing.Point(231, 97)
        Me.btnPlace.Name = "btnPlace"
        Me.btnPlace.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPlace.OffText = "PLACE"
        Me.btnPlace.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnPlace.OnText = "PLACE"
        Me.btnPlace.Size = New System.Drawing.Size(68, 60)
        Me.btnPlace.TabIndex = 25
        Me.btnPlace.Text = "PLACE"
        Me.btnPlace.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnPlace.UseVisualStyleBackColor = False
        '
        'btnPick
        '
        Me.btnPick.BackColor = System.Drawing.Color.Transparent
        Me.btnPick.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPick.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnPick.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPick.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPick.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnPick.FlatAppearance.BorderSize = 0
        Me.btnPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPick.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPick.ForeColor = System.Drawing.Color.Black
        Me.btnPick.Location = New System.Drawing.Point(231, 25)
        Me.btnPick.Name = "btnPick"
        Me.btnPick.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPick.OffText = "PICK"
        Me.btnPick.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnPick.OnText = "PICK"
        Me.btnPick.Size = New System.Drawing.Size(68, 60)
        Me.btnPick.TabIndex = 26
        Me.btnPick.Text = "PICK"
        Me.btnPick.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnPick.UseVisualStyleBackColor = False
        '
        'AutoTransferWaferControl
        '
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkRunWithRecipeB)
        Me.Controls.Add(Me.chkRunWithRecipeA)
        Me.DoubleBuffered = True
        Me.HeaderStatus = DisplayStatus.On
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.HeaderVisible = False
        Me.Name = "AutoTransferWaferControl"
        Me.Size = New System.Drawing.Size(464, 182)
        Me.Text = "CYCLE WAFER"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.chkRunWithRecipeA, 0)
        Me.Controls.SetChildIndex(Me.chkRunWithRecipeB, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkRunWithRecipeA As System.Windows.Forms.CheckBox
    Friend WithEvents chkRunWithRecipeB As System.Windows.Forms.CheckBox
    Friend WithEvents btnDNStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnUPStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnREStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnEXStatus As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnHome As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents cboStationList As System.Windows.Forms.ComboBox
    Friend WithEvents txtCurrentPos As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnPlace As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnPick As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents chkDisableChekingSensor As System.Windows.Forms.CheckBox

End Class
