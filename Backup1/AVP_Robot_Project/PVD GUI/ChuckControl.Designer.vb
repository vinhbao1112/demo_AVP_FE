<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChuckControl
    Inherits AVP_Robot_Project.PVDStatusPanel

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChuckControl))
        Me.txtPos1 = New AVP_Robot_Project.SL_Textbox
        Me.txtPos2 = New System.Windows.Forms.TextBox
        Me.bicPlasmaOn = New AVP_Robot_Project.ButtonIGCGControl
        Me.ValveSlit = New AVP_Robot_Project.ButtonIGCGControl
        Me.ValveTar = New AVP_Robot_Project.ButtonIGCGControl
        Me.bicWaferInside = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnShutter = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnClamp = New AVP_Robot_Project.ButtonIGCGControl
        Me.imbstMainChuck = New AVP_Robot_Project.ImageBinaryStatusControl
        Me.btnShutterStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'txtPos1
        '
        Me.txtPos1.AccessibleName = "Chuck"
        Me.txtPos1.AutoSendKeyTabWhenFinishInput = False
        Me.txtPos1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPos1.Clickable = True
        Me.txtPos1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPos1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPos1.GasName = ""
        Me.txtPos1.IsNumericTextbox = False
        Me.txtPos1.IsReadBack = True
        Me.txtPos1.IsTurboPumpTextbox = False
        Me.txtPos1.Location = New System.Drawing.Point(70, 335)
        Me.txtPos1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtPos1.Name = "txtPos1"
        Me.txtPos1.ReadOnly = True
        Me.txtPos1.ShowUnitFormat = False
        Me.txtPos1.Size = New System.Drawing.Size(72, 24)
        Me.txtPos1.TabIndex = 14
        Me.txtPos1.UnitTypeUsed = ""
        Me.txtPos1.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtPos1.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtPos1.UseScientificFormat = True
        '
        'txtPos2
        '
        Me.txtPos2.BackColor = System.Drawing.SystemColors.Window
        Me.txtPos2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPos2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPos2.Location = New System.Drawing.Point(70, 363)
        Me.txtPos2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtPos2.Name = "txtPos2"
        Me.txtPos2.ReadOnly = True
        Me.txtPos2.Size = New System.Drawing.Size(72, 24)
        Me.txtPos2.TabIndex = 14
        '
        'bicPlasmaOn
        '
        Me.bicPlasmaOn.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.PlasmaOn
        Me.bicPlasmaOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicPlasmaOn.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.bicPlasmaOn.ColorText_OffStatus = System.Drawing.Color.Black
        Me.bicPlasmaOn.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicPlasmaOn.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicPlasmaOn.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.PlasmaOn
        Me.bicPlasmaOn.ErrorText = ""
        Me.bicPlasmaOn.FlatAppearance.BorderSize = 0
        Me.bicPlasmaOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicPlasmaOn.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicPlasmaOn.ForeColor = System.Drawing.Color.Black
        Me.bicPlasmaOn.Location = New System.Drawing.Point(22, 94)
        Me.bicPlasmaOn.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.bicPlasmaOn.Name = "bicPlasmaOn"
        Me.bicPlasmaOn.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.PlasmaOn
        Me.bicPlasmaOn.OffText = ""
        Me.bicPlasmaOn.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.PlasmaOn
        Me.bicPlasmaOn.OnText = ""
        Me.bicPlasmaOn.Size = New System.Drawing.Size(175, 6)
        Me.bicPlasmaOn.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicPlasmaOn.StyleOfButton = ButtonStyle.Horizontal
        Me.bicPlasmaOn.TabIndex = 22
        Me.bicPlasmaOn.Tag = "False"
        Me.bicPlasmaOn.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.PlasmaOn
        Me.bicPlasmaOn.UnKnownText = ""
        Me.bicPlasmaOn.UseVisualStyleBackColor = False
        Me.bicPlasmaOn.Visible = False
        '
        'ValveSlit
        '
        Me.ValveSlit.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.SlitValve_Off
        Me.ValveSlit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ValveSlit.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.ValveSlit.ColorText_OffStatus = System.Drawing.Color.Black
        Me.ValveSlit.ColorText_OnStatus = System.Drawing.Color.Black
        Me.ValveSlit.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.ValveSlit.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.SlitValve_Err
        Me.ValveSlit.ErrorText = ""
        Me.ValveSlit.FlatAppearance.BorderSize = 0
        Me.ValveSlit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ValveSlit.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ValveSlit.ForeColor = System.Drawing.Color.Black
        Me.ValveSlit.Location = New System.Drawing.Point(2, 101)
        Me.ValveSlit.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ValveSlit.Name = "ValveSlit"
        Me.ValveSlit.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SlitValve_Off
        Me.ValveSlit.OffText = ""
        Me.ValveSlit.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.SlitValve_On
        Me.ValveSlit.OnText = ""
        Me.ValveSlit.Size = New System.Drawing.Size(10, 35)
        Me.ValveSlit.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.ValveSlit.StyleOfButton = ButtonStyle.Horizontal
        Me.ValveSlit.TabIndex = 21
        Me.ValveSlit.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.SlitValve_Unkn
        Me.ValveSlit.UnKnownText = ""
        Me.ValveSlit.UseVisualStyleBackColor = True
        '
        'ValveTar
        '
        Me.ValveTar.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tar_Valve_Off
        Me.ValveTar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ValveTar.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.ValveTar.ColorText_OffStatus = System.Drawing.Color.Black
        Me.ValveTar.ColorText_OnStatus = System.Drawing.Color.Black
        Me.ValveTar.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.ValveTar.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Tar_Valve_Off
        Me.ValveTar.ErrorText = ""
        Me.ValveTar.FlatAppearance.BorderSize = 0
        Me.ValveTar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ValveTar.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ValveTar.ForeColor = System.Drawing.Color.Black
        Me.ValveTar.Location = New System.Drawing.Point(22, 75)
        Me.ValveTar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ValveTar.Name = "ValveTar"
        Me.ValveTar.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Tar_Valve_Off
        Me.ValveTar.OffText = ""
        Me.ValveTar.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Tar_Valve_On
        Me.ValveTar.OnText = ""
        Me.ValveTar.Size = New System.Drawing.Size(175, 17)
        Me.ValveTar.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.ValveTar.StyleOfButton = ButtonStyle.Horizontal
        Me.ValveTar.TabIndex = 21
        Me.ValveTar.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Tar_Valve_Off
        Me.ValveTar.UnKnownText = ""
        Me.ValveTar.UseVisualStyleBackColor = True
        Me.ValveTar.Visible = False
        '
        'bicWaferInside
        '
        Me.bicWaferInside.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_inside_Green
        Me.bicWaferInside.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicWaferInside.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.bicWaferInside.ColorText_OffStatus = System.Drawing.Color.Black
        Me.bicWaferInside.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicWaferInside.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicWaferInside.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_inside_red
        Me.bicWaferInside.ErrorText = ""
        Me.bicWaferInside.FlatAppearance.BorderSize = 0
        Me.bicWaferInside.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicWaferInside.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicWaferInside.ForeColor = System.Drawing.Color.Black
        Me.bicWaferInside.Location = New System.Drawing.Point(49, 138)
        Me.bicWaferInside.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.bicWaferInside.Name = "bicWaferInside"
        Me.bicWaferInside.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_inside_Green
        Me.bicWaferInside.OffText = ""
        Me.bicWaferInside.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_inside_Blue
        Me.bicWaferInside.OnText = ""
        Me.bicWaferInside.Size = New System.Drawing.Size(116, 12)
        Me.bicWaferInside.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicWaferInside.StyleOfButton = ButtonStyle.Horizontal
        Me.bicWaferInside.TabIndex = 21
        Me.bicWaferInside.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.wafer_Yellow1
        Me.bicWaferInside.UnKnownText = ""
        Me.bicWaferInside.UseVisualStyleBackColor = True
        '
        'btnShutter
        '
        Me.btnShutter.BackgroundImage = CType(resources.GetObject("btnShutter.BackgroundImage"), System.Drawing.Image)
        Me.btnShutter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShutter.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnShutter.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnShutter.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnShutter.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnShutter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShutter.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnShutter.ErrorText = ""
        Me.btnShutter.FlatAppearance.BorderSize = 0
        Me.btnShutter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShutter.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShutter.ForeColor = System.Drawing.Color.Black
        Me.btnShutter.Location = New System.Drawing.Point(217, 90)
        Me.btnShutter.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnShutter.Name = "btnShutter"
        Me.btnShutter.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnShutter.OffText = "Shutter Close"
        Me.btnShutter.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_On
        Me.btnShutter.OnText = "Shutter Open"
        Me.btnShutter.Size = New System.Drawing.Size(134, 30)
        Me.btnShutter.Status = AVP_Robot_Project.DisplayStatus.Unknow
        Me.btnShutter.StyleOfButton = ButtonStyle.Horizontal
        Me.btnShutter.TabIndex = 19
        Me.btnShutter.Text = "Shutter Unknown"
        Me.btnShutter.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.btnYellowButton
        Me.btnShutter.UnKnownText = "Shutter Unknown"
        Me.btnShutter.UseVisualStyleBackColor = True
        '
        'btnClamp
        '
        Me.btnClamp.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnClamp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClamp.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnClamp.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnClamp.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnClamp.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnClamp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClamp.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnClamp.ErrorText = ""
        Me.btnClamp.FlatAppearance.BorderSize = 0
        Me.btnClamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClamp.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClamp.ForeColor = System.Drawing.Color.White
        Me.btnClamp.Location = New System.Drawing.Point(150, 188)
        Me.btnClamp.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnClamp.Name = "btnClamp"
        Me.btnClamp.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnClamp.OffText = "Clamp"
        Me.btnClamp.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower
        Me.btnClamp.OnText = "UnClamp"
        Me.btnClamp.Size = New System.Drawing.Size(65, 22)
        Me.btnClamp.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnClamp.StyleOfButton = ButtonStyle.Horizontal
        Me.btnClamp.TabIndex = 19
        Me.btnClamp.Text = "Clamp"
        Me.btnClamp.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.btnYellowButton
        Me.btnClamp.UnKnownText = "UnClamp"
        Me.btnClamp.UseVisualStyleBackColor = True
        Me.btnClamp.Visible = False
        '
        'imbstMainChuck
        '
        Me.imbstMainChuck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imbstMainChuck.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.imbstMainChuck.Location = New System.Drawing.Point(0, 0)
        Me.imbstMainChuck.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.imbstMainChuck.Name = "imbstMainChuck"
        Me.imbstMainChuck.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.TM_No_Shutter
        Me.imbstMainChuck.OffState_ColorText = System.Drawing.Color.Empty
        Me.imbstMainChuck.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.TM_Has_Shutter
        Me.imbstMainChuck.OnState_ColorText = System.Drawing.Color.Empty
        Me.imbstMainChuck.Size = New System.Drawing.Size(452, 406)
        Me.imbstMainChuck.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.[On]
        Me.imbstMainChuck.TabIndex = 0
        Me.imbstMainChuck.TextLocation = New System.Drawing.Point(85, 160)
        Me.imbstMainChuck.TextLocIsFix = False
        Me.imbstMainChuck.TextValue = "Clamp"
        '
        'btnShutterStatus
        '
        Me.btnShutterStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.PlasmaOff
        Me.btnShutterStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShutterStatus.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.btnShutterStatus.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnShutterStatus.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnShutterStatus.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnShutterStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.PlasmaOff
        Me.btnShutterStatus.ErrorText = ""
        Me.btnShutterStatus.FlatAppearance.BorderSize = 0
        Me.btnShutterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShutterStatus.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShutterStatus.ForeColor = System.Drawing.Color.White
        Me.btnShutterStatus.Location = New System.Drawing.Point(15, 101)
        Me.btnShutterStatus.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnShutterStatus.Name = "btnShutterStatus"
        Me.btnShutterStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.PlasmaOff
        Me.btnShutterStatus.OffText = ""
        Me.btnShutterStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.PlasmaOff
        Me.btnShutterStatus.OnText = ""
        Me.btnShutterStatus.Size = New System.Drawing.Size(195, 7)
        Me.btnShutterStatus.Status = AVP_Robot_Project.DisplayStatus.[Error]
        Me.btnShutterStatus.StyleOfButton = ButtonStyle.Horizontal
        Me.btnShutterStatus.TabIndex = 23
        Me.btnShutterStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.PlasmaOff
        Me.btnShutterStatus.UnKnownText = ""
        Me.btnShutterStatus.UseVisualStyleBackColor = False
        Me.btnShutterStatus.Visible = False
        '
        'ChuckControl
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnShutterStatus)
        Me.Controls.Add(Me.bicPlasmaOn)
        Me.Controls.Add(Me.ValveSlit)
        Me.Controls.Add(Me.ValveTar)
        Me.Controls.Add(Me.bicWaferInside)
        Me.Controls.Add(Me.btnShutter)
        Me.Controls.Add(Me.btnClamp)
        Me.Controls.Add(Me.txtPos2)
        Me.Controls.Add(Me.txtPos1)
        Me.Controls.Add(Me.imbstMainChuck)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "ChuckControl"
        Me.Size = New System.Drawing.Size(452, 406)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imbstMainChuck As AVP_Robot_Project.ImageBinaryStatusControl
    Friend WithEvents txtPos1 As SL_Textbox
    Friend WithEvents txtPos2 As System.Windows.Forms.TextBox
    Friend WithEvents bicWaferInside As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents ValveTar As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents ValveSlit As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnShutter As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnClamp As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents bicPlasmaOn As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnShutterStatus As AVP_Robot_Project.ButtonIGCGControl

End Class
