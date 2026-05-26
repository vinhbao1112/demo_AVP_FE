<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDTurboPump
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
        Me.txtT = New AVP_Robot_Project.SL_Textbox
        Me.bicTurboPump = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnWaterPumpOnOff = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'txtT
        '
        Me.txtT.AccessibleName = "WP"
        Me.txtT.AutoSendKeyTabWhenFinishInput = False
        Me.txtT.BackColor = System.Drawing.Color.White
        Me.txtT.Clickable = False
        Me.txtT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtT.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtT.GasName = ""
        Me.txtT.GetDefaultMinMax = False
        Me.txtT.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtT.IsIntergerNumber = False
        Me.txtT.IsNumericTextbox = False
        Me.txtT.IsReadBack = False
        Me.txtT.IsTurboPumpTextbox = False
        Me.txtT.Location = New System.Drawing.Point(4, 80)
        Me.txtT.LogSource = ""
        Me.txtT.Name = "txtT"
        Me.txtT.PermissionCode = ""
        Me.txtT.ReadOnly = True
        Me.txtT.ShowUnitFormat = False
        Me.txtT.Size = New System.Drawing.Size(55, 24)
        Me.txtT.SourceOfMessageBox = ""
        Me.txtT.TabIndex = 7
        Me.txtT.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtT.UnitTypeUsed = ""
        Me.txtT.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtT.UseClickEventInForm = False
        Me.txtT.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtT.UseScientificFormat = True
        '
        'bicTurboPump
        '
        Me.bicTurboPump.BackColor = System.Drawing.Color.Transparent
        Me.bicTurboPump.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.bicTurboPump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicTurboPump.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicTurboPump.ColorText_OffStatus = System.Drawing.Color.Black
        Me.bicTurboPump.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicTurboPump.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicTurboPump.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicTurboPump.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.bicTurboPump.ErrorText = ""
        Me.bicTurboPump.FlatAppearance.BorderSize = 0
        Me.bicTurboPump.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicTurboPump.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicTurboPump.ForeColor = System.Drawing.Color.Black
        Me.bicTurboPump.Location = New System.Drawing.Point(10, 34)
        Me.bicTurboPump.Name = "bicTurboPump"
        Me.bicTurboPump.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.bicTurboPump.OffText = "Off"
        Me.bicTurboPump.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_On
        Me.bicTurboPump.OnText = "On"
        Me.bicTurboPump.Size = New System.Drawing.Size(80, 38)
        Me.bicTurboPump.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicTurboPump.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.bicTurboPump.TabIndex = 16
        Me.bicTurboPump.Text = "Off"
        Me.bicTurboPump.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.bicTurboPump.UnKnownText = "Ramp"
        Me.bicTurboPump.UseVisualStyleBackColor = False
        '
        'btnWaterPumpOnOff
        '
        Me.btnWaterPumpOnOff.BackColor = System.Drawing.Color.Transparent
        Me.btnWaterPumpOnOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnWaterPumpOnOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWaterPumpOnOff.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnWaterPumpOnOff.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnWaterPumpOnOff.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnWaterPumpOnOff.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnWaterPumpOnOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWaterPumpOnOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnWaterPumpOnOff.ErrorText = ""
        Me.btnWaterPumpOnOff.FlatAppearance.BorderSize = 0
        Me.btnWaterPumpOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWaterPumpOnOff.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWaterPumpOnOff.ForeColor = System.Drawing.Color.Black
        Me.btnWaterPumpOnOff.Location = New System.Drawing.Point(61, 81)
        Me.btnWaterPumpOnOff.Name = "btnWaterPumpOnOff"
        Me.btnWaterPumpOnOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnWaterPumpOnOff.OffText = "On"
        Me.btnWaterPumpOnOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_On
        Me.btnWaterPumpOnOff.OnText = "On"
        Me.btnWaterPumpOnOff.Size = New System.Drawing.Size(34, 24)
        Me.btnWaterPumpOnOff.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnWaterPumpOnOff.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.btnWaterPumpOnOff.TabIndex = 19
        Me.btnWaterPumpOnOff.Text = "Off"
        Me.btnWaterPumpOnOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnWaterPumpOnOff.UnKnownText = "Unk"
        Me.btnWaterPumpOnOff.UseVisualStyleBackColor = False
        '
        'PVDTurboPump
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Turbo_Pump
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnWaterPumpOnOff)
        Me.Controls.Add(Me.txtT)
        Me.Controls.Add(Me.bicTurboPump)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "PVDTurboPump"
        Me.Size = New System.Drawing.Size(100, 117)
        Me.Text = "TURBO"
        Me.Controls.SetChildIndex(Me.bicTurboPump, 0)
        Me.Controls.SetChildIndex(Me.txtT, 0)
        Me.Controls.SetChildIndex(Me.btnWaterPumpOnOff, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtT As SL_Textbox
    Friend WithEvents bicTurboPump As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnWaterPumpOnOff As AVP_Robot_Project.ButtonIGCGControl

End Class
