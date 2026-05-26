<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVD5TCryoControl
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
        Me.txtT2 = New AVP_Robot_Project.SL_Textbox()
        Me.txtT1 = New AVP_Robot_Project.SL_Textbox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnRegen = New AVP_Robot_Project.ButtonIGCGControl()
        Me.btnCryoCommucation = New AVP_Robot_Project.SL_CustomButton()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Size = New System.Drawing.Size(150, 25)
        Me.Header.Text = "CRYO"
        Me.Header.TextValue = "CRYO"
        '
        'txtT2
        '
        Me.txtT2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtT2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtT2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtT2.IsReadBack = True
        Me.txtT2.Location = New System.Drawing.Point(44, 64)
        Me.txtT2.MinimumValueHighlightedGreen = 0R
        Me.txtT2.Name = "txtT2"
        Me.txtT2.ReadOnly = True
        Me.txtT2.Size = New System.Drawing.Size(58, 24)
        Me.txtT2.TabIndex = 9
        Me.txtT2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtT2.UseScientificFormat = True
        '
        'txtT1
        '
        Me.txtT1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtT1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtT1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtT1.IsReadBack = True
        Me.txtT1.Location = New System.Drawing.Point(44, 37)
        Me.txtT1.MinimumValueHighlightedGreen = 0R
        Me.txtT1.Name = "txtT1"
        Me.txtT1.ReadOnly = True
        Me.txtT1.Size = New System.Drawing.Size(58, 24)
        Me.txtT1.TabIndex = 7
        Me.txtT1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtT1.UseScientificFormat = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 19)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "T1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 19)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "T2"
        '
        'btnRegen
        '
        Me.btnRegen.BackColor = System.Drawing.Color.Transparent
        Me.btnRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRegen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnRegen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRegen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnRegen.FlatAppearance.BorderSize = 0
        Me.btnRegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegen.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegen.ForeColor = System.Drawing.Color.Black
        Me.btnRegen.Location = New System.Drawing.Point(44, 90)
        Me.btnRegen.Name = "btnRegen"
        Me.btnRegen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRegen.OffText = "Off"
        Me.btnRegen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnRegen.OnText = "On"
        Me.btnRegen.Size = New System.Drawing.Size(58, 27)
        Me.btnRegen.TabIndex = 16
        Me.btnRegen.Text = "Off"
        Me.btnRegen.TextLocation = New System.Drawing.Point(0, 0)
        Me.btnRegen.TextLocIsFix = True
        Me.btnRegen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnRegen.UnKnownText = "Reg"
        Me.btnRegen.UseVisualStyleBackColor = False
        '
        'btnCryoCommucation
        '
        Me.btnCryoCommucation.AccessibleName = ""
        Me.btnCryoCommucation.BackColor = System.Drawing.Color.Transparent
        Me.btnCryoCommucation.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.btnCryoCommucation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCryoCommucation.Clickable = True
        Me.btnCryoCommucation.ColorText_UnknowStatus = System.Drawing.Color.White
        Me.btnCryoCommucation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCryoCommucation.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.btnCryoCommucation.FlatAppearance.BorderSize = 0
        Me.btnCryoCommucation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCryoCommucation.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCryoCommucation.ForeColor = System.Drawing.Color.White
        Me.btnCryoCommucation.Location = New System.Drawing.Point(24, 12)
        Me.btnCryoCommucation.MessageBoxText = Nothing
        Me.btnCryoCommucation.Name = "btnCryoCommucation"
        Me.btnCryoCommucation.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.btnCryoCommucation.OffText = "CRYO"
        Me.btnCryoCommucation.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.btnCryoCommucation.OnText = "CRYO"
        Me.btnCryoCommucation.Size = New System.Drawing.Size(78, 23)
        Me.btnCryoCommucation.TabIndex = 200
        Me.btnCryoCommucation.Text = "CRYO"
        Me.btnCryoCommucation.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD5T
        Me.btnCryoCommucation.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.btnCryoCommucation.UnKnownText = "CRYO"
        Me.btnCryoCommucation.UseClickedEventInForm = True
        Me.btnCryoCommucation.UseVisualStyleBackColor = False
        Me.btnCryoCommucation.ValueToBeSend = ""
        '
        'PVD5TCryoControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD_Cryo_Panel
        Me.Controls.Add(Me.btnCryoCommucation)
        Me.Controls.Add(Me.txtT1)
        Me.Controls.Add(Me.txtT2)
        Me.Controls.Add(Me.btnRegen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderHeight = 25
        Me.HeaderText = "CRYO"
        Me.HeaderVisible = False
        Me.Name = "PVD5TCryoControl"
        Me.Size = New System.Drawing.Size(120, 125)
        Me.Text = "CRYO"
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnRegen, 0)
        Me.Controls.SetChildIndex(Me.txtT2, 0)
        Me.Controls.SetChildIndex(Me.txtT1, 0)
        Me.Controls.SetChildIndex(Me.btnCryoCommucation, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtT2 As SL_Textbox
    Friend WithEvents txtT1 As SL_Textbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnRegen As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnCryoCommucation As AVP_Robot_Project.SL_CustomButton

End Class