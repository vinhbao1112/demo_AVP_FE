<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDCryoControl
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
        Me.txtT2 = New AVP_Robot_Project.SL_Textbox
        Me.txtT1 = New AVP_Robot_Project.SL_Textbox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnRegen = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'txtT2
        '
        Me.txtT2.AutoSendKeyTabWhenFinishInput = False
        Me.txtT2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtT2.Clickable = True
        Me.txtT2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtT2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtT2.GasName = ""
        Me.txtT2.IsNumericTextbox = False
        Me.txtT2.IsReadBack = True
        Me.txtT2.IsTurboPumpTextbox = False
        Me.txtT2.Location = New System.Drawing.Point(25, 56)
        Me.txtT2.Name = "txtT2"
        Me.txtT2.ReadOnly = True
        Me.txtT2.ShowUnitFormat = False
        Me.txtT2.Size = New System.Drawing.Size(70, 24)
        Me.txtT2.TabIndex = 9
        Me.txtT2.UnitTypeUsed = ""
        Me.txtT2.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtT2.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtT2.UseScientificFormat = True
        '
        'txtT1
        '
        Me.txtT1.AutoSendKeyTabWhenFinishInput = False
        Me.txtT1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtT1.Clickable = True
        Me.txtT1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtT1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtT1.GasName = ""
        Me.txtT1.IsNumericTextbox = False
        Me.txtT1.IsReadBack = True
        Me.txtT1.IsTurboPumpTextbox = False
        Me.txtT1.Location = New System.Drawing.Point(25, 29)
        Me.txtT1.Name = "txtT1"
        Me.txtT1.ReadOnly = True
        Me.txtT1.ShowUnitFormat = False
        Me.txtT1.Size = New System.Drawing.Size(70, 24)
        Me.txtT1.TabIndex = 7
        Me.txtT1.UnitTypeUsed = ""
        Me.txtT1.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtT1.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtT1.UseScientificFormat = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 32)
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
        Me.Label3.Location = New System.Drawing.Point(3, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 19)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "T2"
        '
        'btnRegen
        '
        Me.btnRegen.BackColor = System.Drawing.Color.Transparent
        Me.btnRegen.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnRegen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRegen.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRegen.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnRegen.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnRegen.ColorText_UnknowStatus = System.Drawing.Color.White
        Me.btnRegen.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnRegen.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnRegen.ErrorText = ""
        Me.btnRegen.FlatAppearance.BorderSize = 0
        Me.btnRegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegen.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegen.ForeColor = System.Drawing.Color.Black
        Me.btnRegen.Location = New System.Drawing.Point(30, 85)
        Me.btnRegen.Name = "btnRegen"
        Me.btnRegen.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnRegen.OffText = ""
        Me.btnRegen.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnRegen.OnText = ""
        Me.btnRegen.Size = New System.Drawing.Size(60, 24)
        Me.btnRegen.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnRegen.StyleOfButton = ButtonStyle.Horizontal
        Me.btnRegen.TabIndex = 16
        Me.btnRegen.Text = "Off"
        Me.btnRegen.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnRegen.UnKnownText = ""
        Me.btnRegen.UseVisualStyleBackColor = False
        '
        'PVDCryoControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Turbo_Pump
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtT1)
        Me.Controls.Add(Me.txtT2)
        Me.Controls.Add(Me.btnRegen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderHeight = 25
        Me.Name = "PVDCryoControl"
        Me.Size = New System.Drawing.Size(111, 117)
        Me.Text = "CRYO"
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnRegen, 0)
        Me.Controls.SetChildIndex(Me.txtT2, 0)
        Me.Controls.SetChildIndex(Me.txtT1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtT2 As SL_Textbox
    Friend WithEvents txtT1 As SL_Textbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnRegen As AVP_Robot_Project.ButtonIGCGControl

End Class