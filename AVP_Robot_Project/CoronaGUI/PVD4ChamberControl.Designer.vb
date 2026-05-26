<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVD4ChamberControl
    Inherits AVP_Robot_Project.PVDStatusPanel

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PVD4ChamberControl))
        Me.Wafer8 = New AVP_Robot_Project.PVD4WaferControl
        Me.Wafer7 = New AVP_Robot_Project.PVD4WaferControl
        Me.Wafer6 = New AVP_Robot_Project.PVD4WaferControl
        Me.Wafer5 = New AVP_Robot_Project.PVD4WaferControl
        Me.Wafer4 = New AVP_Robot_Project.PVD4WaferControl
        Me.Wafer3 = New AVP_Robot_Project.PVD4WaferControl
        Me.Wafer2 = New AVP_Robot_Project.PVD4WaferControl
        Me.Wafer1 = New AVP_Robot_Project.PVD4WaferControl
        Me.btnMesaValve = New AVP_Robot_Project.SL_ValveControl
        Me.btnCtxMenu = New System.Windows.Forms.Button
        Me.btnBiasPlasmaStatus = New AVP_Robot_Project.SL_CustomButton
        Me.Shutter1 = New AVP_Robot_Project.SL_ValveControl
        Me.Shutter2 = New AVP_Robot_Project.SL_ValveControl
        Me.Shutter3 = New AVP_Robot_Project.SL_ValveControl
        Me.Shutter4 = New AVP_Robot_Project.SL_ValveControl
        Me.SuspendLayout()
        '
        'Wafer8
        '
        Me.Wafer8.BackColor = System.Drawing.Color.Transparent
        Me.Wafer8.BackgroundImage = CType(resources.GetObject("Wafer8.BackgroundImage"), System.Drawing.Image)
        Me.Wafer8.Location = New System.Drawing.Point(99, 160)
        Me.Wafer8.Name = "Wafer8"
        Me.Wafer8.PositionSlot = 8
        Me.Wafer8.Size = New System.Drawing.Size(70, 13)
        Me.Wafer8.TabIndex = 0
        '
        'Wafer7
        '
        Me.Wafer7.BackColor = System.Drawing.Color.Transparent
        Me.Wafer7.BackgroundImage = CType(resources.GetObject("Wafer7.BackgroundImage"), System.Drawing.Image)
        Me.Wafer7.Location = New System.Drawing.Point(175, 148)
        Me.Wafer7.Name = "Wafer7"
        Me.Wafer7.PositionSlot = 7
        Me.Wafer7.Size = New System.Drawing.Size(70, 13)
        Me.Wafer7.TabIndex = 0
        '
        'Wafer6
        '
        Me.Wafer6.BackColor = System.Drawing.Color.Transparent
        Me.Wafer6.BackgroundImage = CType(resources.GetObject("Wafer6.BackgroundImage"), System.Drawing.Image)
        Me.Wafer6.Location = New System.Drawing.Point(251, 151)
        Me.Wafer6.Name = "Wafer6"
        Me.Wafer6.PositionSlot = 6
        Me.Wafer6.Size = New System.Drawing.Size(70, 13)
        Me.Wafer6.TabIndex = 0
        '
        'Wafer5
        '
        Me.Wafer5.BackColor = System.Drawing.Color.Transparent
        Me.Wafer5.BackgroundImage = CType(resources.GetObject("Wafer5.BackgroundImage"), System.Drawing.Image)
        Me.Wafer5.Location = New System.Drawing.Point(299, 166)
        Me.Wafer5.Name = "Wafer5"
        Me.Wafer5.PositionSlot = 5
        Me.Wafer5.Size = New System.Drawing.Size(70, 13)
        Me.Wafer5.TabIndex = 0
        '
        'Wafer4
        '
        Me.Wafer4.BackColor = System.Drawing.Color.Transparent
        Me.Wafer4.BackgroundImage = CType(resources.GetObject("Wafer4.BackgroundImage"), System.Drawing.Image)
        Me.Wafer4.Location = New System.Drawing.Point(283, 183)
        Me.Wafer4.Name = "Wafer4"
        Me.Wafer4.PositionSlot = 4
        Me.Wafer4.Size = New System.Drawing.Size(70, 13)
        Me.Wafer4.TabIndex = 0
        '
        'Wafer3
        '
        Me.Wafer3.BackColor = System.Drawing.Color.Transparent
        Me.Wafer3.BackgroundImage = CType(resources.GetObject("Wafer3.BackgroundImage"), System.Drawing.Image)
        Me.Wafer3.Location = New System.Drawing.Point(220, 196)
        Me.Wafer3.Name = "Wafer3"
        Me.Wafer3.PositionSlot = 3
        Me.Wafer3.Size = New System.Drawing.Size(70, 13)
        Me.Wafer3.TabIndex = 0
        '
        'Wafer2
        '
        Me.Wafer2.BackColor = System.Drawing.Color.Transparent
        Me.Wafer2.BackgroundImage = CType(resources.GetObject("Wafer2.BackgroundImage"), System.Drawing.Image)
        Me.Wafer2.Location = New System.Drawing.Point(134, 197)
        Me.Wafer2.Name = "Wafer2"
        Me.Wafer2.PositionSlot = 2
        Me.Wafer2.Size = New System.Drawing.Size(70, 13)
        Me.Wafer2.TabIndex = 0
        '
        'Wafer1
        '
        Me.Wafer1.BackColor = System.Drawing.Color.Transparent
        Me.Wafer1.BackgroundImage = CType(resources.GetObject("Wafer1.BackgroundImage"), System.Drawing.Image)
        Me.Wafer1.Location = New System.Drawing.Point(80, 181)
        Me.Wafer1.Name = "Wafer1"
        Me.Wafer1.Size = New System.Drawing.Size(70, 13)
        Me.Wafer1.TabIndex = 0
        '
        'btnMesaValve
        '
        Me.btnMesaValve.BackColor = System.Drawing.Color.Transparent
        Me.btnMesaValve.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_SlitValve_Unknown
        Me.btnMesaValve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMesaValve.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnMesaValve.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_SlitValve_Unknown
        Me.btnMesaValve.ForeColor = System.Drawing.Color.Black
        Me.btnMesaValve.Location = New System.Drawing.Point(28, 116)
        Me.btnMesaValve.Name = "btnMesaValve"
        Me.btnMesaValve.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_SlitValve_Close
        Me.btnMesaValve.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_SlitValve_Open
        Me.btnMesaValve.Size = New System.Drawing.Size(16, 39)
        Me.btnMesaValve.Status = AVP_Robot_Project.SL_ValveControl.DisplayStatus.Unknow
        Me.btnMesaValve.TabIndex = 308
        Me.btnMesaValve.TextLocation = New System.Drawing.Point(74, 35)
        Me.btnMesaValve.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnMesaValve.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_SlitValve_Unknown
        '
        'btnCtxMenu
        '
        Me.btnCtxMenu.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnCtxMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCtxMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCtxMenu.FlatAppearance.BorderSize = 0
        Me.btnCtxMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCtxMenu.Location = New System.Drawing.Point(10, 194)
        Me.btnCtxMenu.Name = "btnCtxMenu"
        Me.btnCtxMenu.Size = New System.Drawing.Size(30, 28)
        Me.btnCtxMenu.TabIndex = 311
        Me.btnCtxMenu.UseVisualStyleBackColor = True
        '
        'btnBiasPlasmaStatus
        '
        Me.btnBiasPlasmaStatus.AccessibleDescription = "Turbo"
        Me.btnBiasPlasmaStatus.AccessibleName = "TurboPump"
        Me.btnBiasPlasmaStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnBiasPlasmaStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnBiasPlasmaStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBiasPlasmaStatus.Clickable = True
        Me.btnBiasPlasmaStatus.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnBiasPlasmaStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBiasPlasmaStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnBiasPlasmaStatus.ErrorText = "Error"
        Me.btnBiasPlasmaStatus.FlatAppearance.BorderSize = 0
        Me.btnBiasPlasmaStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBiasPlasmaStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBiasPlasmaStatus.ForeColor = System.Drawing.Color.Black
        Me.btnBiasPlasmaStatus.IsNotValve = True
        Me.btnBiasPlasmaStatus.Location = New System.Drawing.Point(384, 205)
        Me.btnBiasPlasmaStatus.MessageBoxText = Nothing
        Me.btnBiasPlasmaStatus.Name = "btnBiasPlasmaStatus"
        Me.btnBiasPlasmaStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnBiasPlasmaStatus.OffText = "Off"
        Me.btnBiasPlasmaStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnBiasPlasmaStatus.OnText = "On"
        Me.btnBiasPlasmaStatus.Size = New System.Drawing.Size(52, 30)
        Me.btnBiasPlasmaStatus.TabIndex = 315
        Me.btnBiasPlasmaStatus.Text = "Off"
        Me.btnBiasPlasmaStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnBiasPlasmaStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnBiasPlasmaStatus.UnKnownText = "Ramp"
        Me.btnBiasPlasmaStatus.UseChangeValueToSend_BaseOnStatus = True
        Me.btnBiasPlasmaStatus.UseVisualStyleBackColor = False
        Me.btnBiasPlasmaStatus.ValueToBeSend = "On"
        Me.btnBiasPlasmaStatus.ValueToSend_WhenStatusUnknown = "On"
        Me.btnBiasPlasmaStatus.Visible = False
        '
        'Shutter1
        '
        Me.Shutter1.BackColor = System.Drawing.Color.Transparent
        Me.Shutter1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Shutter1.Clickable = True
        Me.Shutter1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Shutter1.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter1.ErrorText = "S1"
        Me.Shutter1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Shutter1.ForeColor = System.Drawing.Color.Black
        Me.Shutter1.Location = New System.Drawing.Point(69, 94)
        Me.Shutter1.Name = "Shutter1"
        Me.Shutter1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Close
        Me.Shutter1.OffText = "S1"
        Me.Shutter1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Open
        Me.Shutter1.OnText = "S1"
        Me.Shutter1.Size = New System.Drawing.Size(112, 20)
        Me.Shutter1.Status = AVP_Robot_Project.SL_ValveControl.DisplayStatus.Unknow
        Me.Shutter1.TabIndex = 316
        Me.Shutter1.TextLocation = New System.Drawing.Point(56, 9)
        Me.Shutter1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.Shutter1.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter1.UnKnownText = "S1"
        '
        'Shutter2
        '
        Me.Shutter2.BackColor = System.Drawing.Color.Transparent
        Me.Shutter2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Shutter2.Clickable = True
        Me.Shutter2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Shutter2.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter2.ErrorText = "S2"
        Me.Shutter2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Shutter2.ForeColor = System.Drawing.Color.Black
        Me.Shutter2.Location = New System.Drawing.Point(178, 84)
        Me.Shutter2.Name = "Shutter2"
        Me.Shutter2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Close
        Me.Shutter2.OffText = "S2"
        Me.Shutter2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Open
        Me.Shutter2.OnText = "S2"
        Me.Shutter2.Size = New System.Drawing.Size(112, 20)
        Me.Shutter2.Status = AVP_Robot_Project.SL_ValveControl.DisplayStatus.Unknow
        Me.Shutter2.TabIndex = 317
        Me.Shutter2.TextLocation = New System.Drawing.Point(56, 9)
        Me.Shutter2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.Shutter2.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter2.UnKnownText = "S2"
        '
        'Shutter3
        '
        Me.Shutter3.BackColor = System.Drawing.Color.Transparent
        Me.Shutter3.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Shutter3.Clickable = True
        Me.Shutter3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Shutter3.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter3.ErrorText = "S3"
        Me.Shutter3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Shutter3.ForeColor = System.Drawing.Color.Black
        Me.Shutter3.Location = New System.Drawing.Point(261, 99)
        Me.Shutter3.Name = "Shutter3"
        Me.Shutter3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Close
        Me.Shutter3.OffText = "S3"
        Me.Shutter3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Open
        Me.Shutter3.OnText = "S3"
        Me.Shutter3.Size = New System.Drawing.Size(112, 20)
        Me.Shutter3.Status = AVP_Robot_Project.SL_ValveControl.DisplayStatus.Unknow
        Me.Shutter3.TabIndex = 318
        Me.Shutter3.TextLocation = New System.Drawing.Point(56, 9)
        Me.Shutter3.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.Shutter3.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter3.UnKnownText = "S3"
        '
        'Shutter4
        '
        Me.Shutter4.BackColor = System.Drawing.Color.Transparent
        Me.Shutter4.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Shutter4.Clickable = True
        Me.Shutter4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Shutter4.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter4.ErrorText = "S4"
        Me.Shutter4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Shutter4.ForeColor = System.Drawing.Color.Black
        Me.Shutter4.Location = New System.Drawing.Point(152, 108)
        Me.Shutter4.Name = "Shutter4"
        Me.Shutter4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Close
        Me.Shutter4.OffText = "S4"
        Me.Shutter4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Open
        Me.Shutter4.OnText = "S4"
        Me.Shutter4.Size = New System.Drawing.Size(112, 20)
        Me.Shutter4.Status = AVP_Robot_Project.SL_ValveControl.DisplayStatus.Unknow
        Me.Shutter4.TabIndex = 319
        Me.Shutter4.TextLocation = New System.Drawing.Point(56, 9)
        Me.Shutter4.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.Shutter4.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber_Shutter_Unknown
        Me.Shutter4.UnKnownText = "S4"
        '
        'PVD4ChamberControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.PVD4Chamber
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.Shutter4)
        Me.Controls.Add(Me.Shutter3)
        Me.Controls.Add(Me.Shutter2)
        Me.Controls.Add(Me.Shutter1)
        Me.Controls.Add(Me.btnBiasPlasmaStatus)
        Me.Controls.Add(Me.btnCtxMenu)
        Me.Controls.Add(Me.btnMesaValve)
        Me.Controls.Add(Me.Wafer8)
        Me.Controls.Add(Me.Wafer7)
        Me.Controls.Add(Me.Wafer6)
        Me.Controls.Add(Me.Wafer5)
        Me.Controls.Add(Me.Wafer4)
        Me.Controls.Add(Me.Wafer3)
        Me.Controls.Add(Me.Wafer2)
        Me.Controls.Add(Me.Wafer1)
        Me.Name = "PVD4ChamberControl"
        Me.Size = New System.Drawing.Size(442, 241)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Wafer1 As AVP_Robot_Project.PVD4WaferControl
    Friend WithEvents Wafer2 As AVP_Robot_Project.PVD4WaferControl
    Friend WithEvents Wafer3 As AVP_Robot_Project.PVD4WaferControl
    Friend WithEvents Wafer4 As AVP_Robot_Project.PVD4WaferControl
    Friend WithEvents Wafer5 As AVP_Robot_Project.PVD4WaferControl
    Friend WithEvents Wafer6 As AVP_Robot_Project.PVD4WaferControl
    Friend WithEvents Wafer7 As AVP_Robot_Project.PVD4WaferControl
    Friend WithEvents Wafer8 As AVP_Robot_Project.PVD4WaferControl
    Friend WithEvents btnMesaValve As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents btnCtxMenu As System.Windows.Forms.Button
    Friend WithEvents btnBiasPlasmaStatus As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Shutter1 As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents Shutter2 As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents Shutter3 As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents Shutter4 As AVP_Robot_Project.SL_ValveControl

End Class
