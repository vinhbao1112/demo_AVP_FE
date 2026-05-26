<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_CryoControl
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnRegen = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnPVDTooltipMachine = New System.Windows.Forms.Button
        Me.txtT1 = New AVP_Robot_Project.SL_Textbox
        Me.txtT2 = New AVP_Robot_Project.SL_Textbox
        Me.ButtonIGCGControl1 = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 19)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "T1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 19)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "T2"
        '
        'btnRegen
        '
        Me.btnRegen.BackColor = System.Drawing.Color.Transparent
        Me.btnRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnRegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRegen.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRegen.ColorText_OffStatus = System.Drawing.Color.White
        Me.btnRegen.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnRegen.ColorText_UnknowStatus = System.Drawing.Color.White
        Me.btnRegen.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnRegen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Red
        Me.btnRegen.ErrorText = ""
        Me.btnRegen.FlatAppearance.BorderSize = 0
        Me.btnRegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegen.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegen.ForeColor = System.Drawing.Color.White
        Me.btnRegen.Location = New System.Drawing.Point(43, 111)
        Me.btnRegen.Name = "btnRegen"
        Me.btnRegen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnRegen.OffText = ""
        Me.btnRegen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_On
        Me.btnRegen.OnText = ""
        Me.btnRegen.Size = New System.Drawing.Size(60, 24)
        Me.btnRegen.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.btnRegen.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.btnRegen.TabIndex = 16
        Me.btnRegen.Text = "Off"
        Me.btnRegen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnRegen.UnKnownText = ""
        Me.btnRegen.UseVisualStyleBackColor = False
        '
        'btnPVDTooltipMachine
        '
        Me.btnPVDTooltipMachine.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnPVDTooltipMachine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPVDTooltipMachine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPVDTooltipMachine.FlatAppearance.BorderSize = 0
        Me.btnPVDTooltipMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPVDTooltipMachine.Location = New System.Drawing.Point(7, 111)
        Me.btnPVDTooltipMachine.Name = "btnPVDTooltipMachine"
        Me.btnPVDTooltipMachine.Size = New System.Drawing.Size(30, 28)
        Me.btnPVDTooltipMachine.TabIndex = 199
        Me.btnPVDTooltipMachine.UseVisualStyleBackColor = True
        '
        'txtT1
        '
        Me.txtT1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtT1.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtT1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtT1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtT1.IsNumericTextbox = False
        Me.txtT1.IsReadBack = True
        Me.txtT1.IsTurboPumpTextbox = False
        Me.txtT1.Location = New System.Drawing.Point(33, 39)
        Me.txtT1.Name = "txtT1"
        Me.txtT1.ReadOnly = True
        Me.txtT1.Size = New System.Drawing.Size(70, 26)
        Me.txtT1.TabIndex = 200
        Me.txtT1.GasName = ""
        '
        'txtT2
        '
        Me.txtT2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtT2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtT2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtT2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtT2.IsNumericTextbox = False
        Me.txtT2.IsReadBack = True
        Me.txtT2.IsTurboPumpTextbox = False
        Me.txtT2.Location = New System.Drawing.Point(33, 76)
        Me.txtT2.Name = "txtT2"
        Me.txtT2.ReadOnly = True
        Me.txtT2.Size = New System.Drawing.Size(70, 26)
        Me.txtT2.TabIndex = 200
        Me.txtT2.GasName = ""
        '
        'ButtonIGCGControl1
        '
        Me.ButtonIGCGControl1.BackColor = System.Drawing.Color.Transparent
        Me.ButtonIGCGControl1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Vertical_Button_Off
        Me.ButtonIGCGControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonIGCGControl1.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.ButtonIGCGControl1.ColorText_OffStatus = System.Drawing.Color.White
        Me.ButtonIGCGControl1.ColorText_OnStatus = System.Drawing.Color.Black
        Me.ButtonIGCGControl1.ColorText_UnknowStatus = System.Drawing.Color.White
        Me.ButtonIGCGControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ButtonIGCGControl1.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Vertical_Button_Unknown
        Me.ButtonIGCGControl1.ErrorText = ""
        Me.ButtonIGCGControl1.FlatAppearance.BorderSize = 0
        Me.ButtonIGCGControl1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonIGCGControl1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonIGCGControl1.ForeColor = System.Drawing.Color.White
        Me.ButtonIGCGControl1.Location = New System.Drawing.Point(109, 24)
        Me.ButtonIGCGControl1.Name = "ButtonIGCGControl1"
        Me.ButtonIGCGControl1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Vertical_Button_Off
        Me.ButtonIGCGControl1.OffText = ""
        Me.ButtonIGCGControl1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Vertical_Button_On
        Me.ButtonIGCGControl1.OnText = ""
        Me.ButtonIGCGControl1.Size = New System.Drawing.Size(37, 115)
        Me.ButtonIGCGControl1.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.ButtonIGCGControl1.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.ButtonIGCGControl1.TabIndex = 16
        Me.ButtonIGCGControl1.Text = "Off"
        Me.ButtonIGCGControl1.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.ButtonIGCGControl1.UnKnownText = ""
        Me.ButtonIGCGControl1.UseVisualStyleBackColor = False
        '
        'SL_CryoControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtT2)
        Me.Controls.Add(Me.txtT1)
        Me.Controls.Add(Me.btnPVDTooltipMachine)
        Me.Controls.Add(Me.ButtonIGCGControl1)
        Me.Controls.Add(Me.btnRegen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderHeight = 25
        Me.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Vertical
        Me.HeaderVisible = False
        Me.Headerwidth = 25
        Me.Name = "SL_CryoControl"
        Me.Size = New System.Drawing.Size(176, 142)
        Me.Text = "CRYO"
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnRegen, 0)
        Me.Controls.SetChildIndex(Me.ButtonIGCGControl1, 0)
        Me.Controls.SetChildIndex(Me.btnPVDTooltipMachine, 0)
        Me.Controls.SetChildIndex(Me.txtT1, 0)
        Me.Controls.SetChildIndex(Me.txtT2, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnRegen As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnPVDTooltipMachine As System.Windows.Forms.Button
    Friend WithEvents txtT1 As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtT2 As AVP_Robot_Project.SL_Textbox
    Friend WithEvents ButtonIGCGControl1 As AVP_Robot_Project.ButtonIGCGControl

End Class