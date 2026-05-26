<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CoronaChamberControl
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
        Me.components = New System.ComponentModel.Container
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnMesaValve = New AVP_Robot_Project.SL_ValveControl
        Me.Wafer8 = New AVP_Robot_Project.CoronaWafer
        Me.Wafer7 = New AVP_Robot_Project.CoronaWafer
        Me.Wafer4 = New AVP_Robot_Project.CoronaWafer
        Me.Wafer5 = New AVP_Robot_Project.CoronaWafer
        Me.Wafer6 = New AVP_Robot_Project.CoronaWafer
        Me.Wafer3 = New AVP_Robot_Project.CoronaWafer
        Me.Wafer2 = New AVP_Robot_Project.CoronaWafer
        Me.Wafer1 = New AVP_Robot_Project.CoronaWafer
        Me.Shutter3 = New AVP_Robot_Project.SL_ValveControl
        Me.Shutter2 = New AVP_Robot_Project.SL_ValveControl
        Me.Shutter1 = New AVP_Robot_Project.SL_ValveControl
        Me.Shutter4 = New AVP_Robot_Project.SL_ValveControl
        Me.btnCtxMenu = New System.Windows.Forms.Button
        Me.btnBiasPlasmaStatus = New AVP_Robot_Project.SL_CustomButton
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300
        '
        'btnMesaValve
        '
        Me.btnMesaValve.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Corona_SlitValve
        Me.btnMesaValve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMesaValve.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnMesaValve.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Corona_SlitValve_Error
        Me.btnMesaValve.ForeColor = System.Drawing.Color.White
        Me.btnMesaValve.Location = New System.Drawing.Point(26, 120)
        Me.btnMesaValve.Name = "btnMesaValve"
        Me.btnMesaValve.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Corona_SlitValve
        Me.btnMesaValve.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Corona_SlitValve_On
        Me.btnMesaValve.Size = New System.Drawing.Size(24, 33)
        Me.btnMesaValve.TabIndex = 307
        Me.btnMesaValve.TextLocation = New System.Drawing.Point(74, 35)
        Me.btnMesaValve.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnMesaValve.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Corona_SlitValve_Unknown
        '
        'Wafer8
        '
        Me.Wafer8.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Wafer8.Clickable = False
        Me.Wafer8.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.Wafer8.ColorText_NoneStatus = System.Drawing.Color.White
        Me.Wafer8.ColorText_OffStatus = System.Drawing.Color.White
        Me.Wafer8.ColorText_OnStatus = System.Drawing.Color.Black
        Me.Wafer8.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.Wafer8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Wafer8.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Red1
        Me.Wafer8.ErrorText = "08"
        Me.Wafer8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wafer8.ForeColor = System.Drawing.Color.White
        Me.Wafer8.HasDiffClickFunc = False
        Me.Wafer8.Location = New System.Drawing.Point(284, 151)
        Me.Wafer8.Name = "Wafer8"
        Me.Wafer8.NoneImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer8.NoneText = "08"
        Me.Wafer8.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Blue1
        Me.Wafer8.OffText = "08"
        Me.Wafer8.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Green1
        Me.Wafer8.OnText = "08"
        Me.Wafer8.Size = New System.Drawing.Size(57, 27)
        Me.Wafer8.Status = AVP_Robot_Project.DisplayStatus.None
        Me.Wafer8.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.Wafer8.TabIndex = 306
        Me.Wafer8.TextLocation = New System.Drawing.Point(29, 12)
        Me.Wafer8.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Yellow2
        Me.Wafer8.UnKnownText = "08"
        Me.Wafer8.ValueToBeSend = "On"
        '
        'Wafer7
        '
        Me.Wafer7.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Wafer7.Clickable = False
        Me.Wafer7.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.Wafer7.ColorText_NoneStatus = System.Drawing.Color.White
        Me.Wafer7.ColorText_OffStatus = System.Drawing.Color.White
        Me.Wafer7.ColorText_OnStatus = System.Drawing.Color.Black
        Me.Wafer7.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.Wafer7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Wafer7.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Red1
        Me.Wafer7.ErrorText = "07"
        Me.Wafer7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wafer7.ForeColor = System.Drawing.Color.White
        Me.Wafer7.HasDiffClickFunc = False
        Me.Wafer7.Location = New System.Drawing.Point(227, 138)
        Me.Wafer7.Name = "Wafer7"
        Me.Wafer7.NoneImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer7.NoneText = "07"
        Me.Wafer7.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Blue1
        Me.Wafer7.OffText = "07"
        Me.Wafer7.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Green1
        Me.Wafer7.OnText = "07"
        Me.Wafer7.Size = New System.Drawing.Size(57, 27)
        Me.Wafer7.Status = AVP_Robot_Project.DisplayStatus.None
        Me.Wafer7.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.Wafer7.TabIndex = 305
        Me.Wafer7.TextLocation = New System.Drawing.Point(29, 12)
        Me.Wafer7.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Yellow2
        Me.Wafer7.UnKnownText = "07"
        Me.Wafer7.ValueToBeSend = "On"
        '
        'Wafer4
        '
        Me.Wafer4.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Wafer4.Clickable = False
        Me.Wafer4.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.Wafer4.ColorText_NoneStatus = System.Drawing.Color.White
        Me.Wafer4.ColorText_OffStatus = System.Drawing.Color.White
        Me.Wafer4.ColorText_OnStatus = System.Drawing.Color.Black
        Me.Wafer4.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.Wafer4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Wafer4.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Red1
        Me.Wafer4.ErrorText = "04"
        Me.Wafer4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wafer4.ForeColor = System.Drawing.Color.White
        Me.Wafer4.HasDiffClickFunc = False
        Me.Wafer4.Location = New System.Drawing.Point(106, 164)
        Me.Wafer4.Name = "Wafer4"
        Me.Wafer4.NoneImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer4.NoneText = "04"
        Me.Wafer4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Blue1
        Me.Wafer4.OffText = "04"
        Me.Wafer4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Green1
        Me.Wafer4.OnText = "04"
        Me.Wafer4.Size = New System.Drawing.Size(57, 27)
        Me.Wafer4.Status = AVP_Robot_Project.DisplayStatus.None
        Me.Wafer4.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.Wafer4.TabIndex = 304
        Me.Wafer4.TextLocation = New System.Drawing.Point(29, 12)
        Me.Wafer4.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Yellow2
        Me.Wafer4.UnKnownText = "04"
        Me.Wafer4.ValueToBeSend = "On"
        '
        'Wafer5
        '
        Me.Wafer5.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Wafer5.Clickable = False
        Me.Wafer5.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.Wafer5.ColorText_NoneStatus = System.Drawing.Color.White
        Me.Wafer5.ColorText_OffStatus = System.Drawing.Color.White
        Me.Wafer5.ColorText_OnStatus = System.Drawing.Color.Black
        Me.Wafer5.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.Wafer5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Wafer5.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Red1
        Me.Wafer5.ErrorText = "05"
        Me.Wafer5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wafer5.ForeColor = System.Drawing.Color.White
        Me.Wafer5.HasDiffClickFunc = False
        Me.Wafer5.Location = New System.Drawing.Point(167, 167)
        Me.Wafer5.Name = "Wafer5"
        Me.Wafer5.NoneImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer5.NoneText = "05"
        Me.Wafer5.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Blue1
        Me.Wafer5.OffText = "05"
        Me.Wafer5.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Green1
        Me.Wafer5.OnText = "05"
        Me.Wafer5.Size = New System.Drawing.Size(57, 27)
        Me.Wafer5.Status = AVP_Robot_Project.DisplayStatus.None
        Me.Wafer5.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.Wafer5.TabIndex = 304
        Me.Wafer5.TextLocation = New System.Drawing.Point(29, 12)
        Me.Wafer5.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Yellow2
        Me.Wafer5.UnKnownText = "05"
        Me.Wafer5.ValueToBeSend = "On"
        '
        'Wafer6
        '
        Me.Wafer6.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Wafer6.Clickable = False
        Me.Wafer6.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.Wafer6.ColorText_NoneStatus = System.Drawing.Color.White
        Me.Wafer6.ColorText_OffStatus = System.Drawing.Color.White
        Me.Wafer6.ColorText_OnStatus = System.Drawing.Color.Black
        Me.Wafer6.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.Wafer6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Wafer6.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Red1
        Me.Wafer6.ErrorText = "06"
        Me.Wafer6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wafer6.ForeColor = System.Drawing.Color.White
        Me.Wafer6.HasDiffClickFunc = False
        Me.Wafer6.Location = New System.Drawing.Point(230, 165)
        Me.Wafer6.Name = "Wafer6"
        Me.Wafer6.NoneImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer6.NoneText = "06"
        Me.Wafer6.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Blue1
        Me.Wafer6.OffText = "06"
        Me.Wafer6.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Green1
        Me.Wafer6.OnText = "06"
        Me.Wafer6.Size = New System.Drawing.Size(57, 27)
        Me.Wafer6.Status = AVP_Robot_Project.DisplayStatus.None
        Me.Wafer6.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.Wafer6.TabIndex = 304
        Me.Wafer6.TextLocation = New System.Drawing.Point(29, 12)
        Me.Wafer6.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Yellow2
        Me.Wafer6.UnKnownText = "06"
        Me.Wafer6.ValueToBeSend = "On"
        '
        'Wafer3
        '
        Me.Wafer3.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Wafer3.Clickable = False
        Me.Wafer3.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.Wafer3.ColorText_NoneStatus = System.Drawing.Color.White
        Me.Wafer3.ColorText_OffStatus = System.Drawing.Color.White
        Me.Wafer3.ColorText_OnStatus = System.Drawing.Color.Black
        Me.Wafer3.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.Wafer3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Wafer3.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Red1
        Me.Wafer3.ErrorText = "03"
        Me.Wafer3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wafer3.ForeColor = System.Drawing.Color.White
        Me.Wafer3.HasDiffClickFunc = False
        Me.Wafer3.Location = New System.Drawing.Point(165, 137)
        Me.Wafer3.Name = "Wafer3"
        Me.Wafer3.NoneImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer3.NoneText = "03"
        Me.Wafer3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Blue1
        Me.Wafer3.OffText = "03"
        Me.Wafer3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Green1
        Me.Wafer3.OnText = "03"
        Me.Wafer3.Size = New System.Drawing.Size(57, 27)
        Me.Wafer3.Status = AVP_Robot_Project.DisplayStatus.None
        Me.Wafer3.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.Wafer3.TabIndex = 304
        Me.Wafer3.TextLocation = New System.Drawing.Point(29, 12)
        Me.Wafer3.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Yellow2
        Me.Wafer3.UnKnownText = "03"
        Me.Wafer3.ValueToBeSend = "On"
        '
        'Wafer2
        '
        Me.Wafer2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Wafer2.Clickable = False
        Me.Wafer2.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.Wafer2.ColorText_NoneStatus = System.Drawing.Color.White
        Me.Wafer2.ColorText_OffStatus = System.Drawing.Color.White
        Me.Wafer2.ColorText_OnStatus = System.Drawing.Color.Black
        Me.Wafer2.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.Wafer2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Wafer2.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Red1
        Me.Wafer2.ErrorText = "02"
        Me.Wafer2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wafer2.ForeColor = System.Drawing.Color.White
        Me.Wafer2.HasDiffClickFunc = False
        Me.Wafer2.Location = New System.Drawing.Point(104, 140)
        Me.Wafer2.Name = "Wafer2"
        Me.Wafer2.NoneImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer2.NoneText = "02"
        Me.Wafer2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Blue1
        Me.Wafer2.OffText = "02"
        Me.Wafer2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Green1
        Me.Wafer2.OnText = "02"
        Me.Wafer2.Size = New System.Drawing.Size(57, 27)
        Me.Wafer2.Status = AVP_Robot_Project.DisplayStatus.None
        Me.Wafer2.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.Wafer2.TabIndex = 304
        Me.Wafer2.TextLocation = New System.Drawing.Point(29, 12)
        Me.Wafer2.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Yellow2
        Me.Wafer2.UnKnownText = "02"
        Me.Wafer2.ValueToBeSend = "On"
        '
        'Wafer1
        '
        Me.Wafer1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Wafer1.Clickable = False
        Me.Wafer1.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.Wafer1.ColorText_NoneStatus = System.Drawing.Color.White
        Me.Wafer1.ColorText_OffStatus = System.Drawing.Color.White
        Me.Wafer1.ColorText_OnStatus = System.Drawing.Color.Black
        Me.Wafer1.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.Wafer1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Wafer1.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Red1
        Me.Wafer1.ErrorText = "01"
        Me.Wafer1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wafer1.ForeColor = System.Drawing.Color.White
        Me.Wafer1.HasDiffClickFunc = False
        Me.Wafer1.Location = New System.Drawing.Point(49, 153)
        Me.Wafer1.Name = "Wafer1"
        Me.Wafer1.NoneImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Black1
        Me.Wafer1.NoneText = "01"
        Me.Wafer1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Blue1
        Me.Wafer1.OffText = "01"
        Me.Wafer1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Green1
        Me.Wafer1.OnText = "01"
        Me.Wafer1.Size = New System.Drawing.Size(57, 27)
        Me.Wafer1.Status = AVP_Robot_Project.DisplayStatus.None
        Me.Wafer1.StyleOfButton = AVP_Robot_Project.ButtonStyle.Horizontal
        Me.Wafer1.TabIndex = 304
        Me.Wafer1.TextLocation = New System.Drawing.Point(29, 12)
        Me.Wafer1.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Yellow2
        Me.Wafer1.UnKnownText = "01"
        Me.Wafer1.ValueToBeSend = "On"
        '
        'Shutter3
        '
        Me.Shutter3.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Blue
        Me.Shutter3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Shutter3.Clickable = True
        Me.Shutter3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Shutter3.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Yellow
        Me.Shutter3.ErrorText = "S3"
        Me.Shutter3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Shutter3.ForeColor = System.Drawing.Color.White
        Me.Shutter3.Location = New System.Drawing.Point(181, 97)
        Me.Shutter3.Name = "Shutter3"
        Me.Shutter3.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Blue
        Me.Shutter3.OffText = "S3"
        Me.Shutter3.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Green
        Me.Shutter3.OnText = "S3"
        Me.Shutter3.Size = New System.Drawing.Size(157, 17)
        Me.Shutter3.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.Shutter3.TabIndex = 304
        Me.Shutter3.TextLocation = New System.Drawing.Point(78, 9)
        Me.Shutter3.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.Shutter3.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Yellow
        Me.Shutter3.UnKnownText = "S3"
        '
        'Shutter2
        '
        Me.Shutter2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Blue
        Me.Shutter2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Shutter2.Clickable = True
        Me.Shutter2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Shutter2.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Yellow
        Me.Shutter2.ErrorText = "S2"
        Me.Shutter2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Shutter2.ForeColor = System.Drawing.Color.White
        Me.Shutter2.Location = New System.Drawing.Point(102, 80)
        Me.Shutter2.Name = "Shutter2"
        Me.Shutter2.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Blue
        Me.Shutter2.OffText = "S2"
        Me.Shutter2.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Green
        Me.Shutter2.OnText = "S2"
        Me.Shutter2.Size = New System.Drawing.Size(157, 17)
        Me.Shutter2.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.Shutter2.TabIndex = 304
        Me.Shutter2.TextLocation = New System.Drawing.Point(78, 9)
        Me.Shutter2.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.Shutter2.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Yellow
        Me.Shutter2.UnKnownText = "S2"
        '
        'Shutter1
        '
        Me.Shutter1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Blue
        Me.Shutter1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Shutter1.Clickable = True
        Me.Shutter1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Shutter1.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Yellow
        Me.Shutter1.ErrorText = "S1"
        Me.Shutter1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Shutter1.ForeColor = System.Drawing.Color.White
        Me.Shutter1.Location = New System.Drawing.Point(21, 98)
        Me.Shutter1.Name = "Shutter1"
        Me.Shutter1.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Blue
        Me.Shutter1.OffText = "S1"
        Me.Shutter1.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Green
        Me.Shutter1.OnText = "S1"
        Me.Shutter1.Size = New System.Drawing.Size(157, 17)
        Me.Shutter1.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.Shutter1.TabIndex = 304
        Me.Shutter1.TextLocation = New System.Drawing.Point(78, 9)
        Me.Shutter1.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.Shutter1.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Yellow
        Me.Shutter1.UnKnownText = "S1"
        '
        'Shutter4
        '
        Me.Shutter4.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Blue
        Me.Shutter4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Shutter4.Clickable = True
        Me.Shutter4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Shutter4.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Yellow
        Me.Shutter4.ErrorText = "S4"
        Me.Shutter4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Shutter4.ForeColor = System.Drawing.Color.White
        Me.Shutter4.Location = New System.Drawing.Point(103, 115)
        Me.Shutter4.Name = "Shutter4"
        Me.Shutter4.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Blue
        Me.Shutter4.OffText = "S4"
        Me.Shutter4.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Green
        Me.Shutter4.OnText = "S4"
        Me.Shutter4.Size = New System.Drawing.Size(157, 17)
        Me.Shutter4.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.Shutter4.TabIndex = 304
        Me.Shutter4.TextLocation = New System.Drawing.Point(78, 9)
        Me.Shutter4.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.Shutter4.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Shutter_Yellow
        Me.Shutter4.UnKnownText = "S4"
        '
        'btnCtxMenu
        '
        Me.btnCtxMenu.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnCtxMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCtxMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCtxMenu.FlatAppearance.BorderSize = 0
        Me.btnCtxMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCtxMenu.Location = New System.Drawing.Point(176, 216)
        Me.btnCtxMenu.Name = "btnCtxMenu"
        Me.btnCtxMenu.Size = New System.Drawing.Size(30, 28)
        Me.btnCtxMenu.TabIndex = 310
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
        Me.btnBiasPlasmaStatus.Location = New System.Drawing.Point(281, 282)
        Me.btnBiasPlasmaStatus.MessageBoxText = Nothing
        Me.btnBiasPlasmaStatus.Name = "btnBiasPlasmaStatus"
        Me.btnBiasPlasmaStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnBiasPlasmaStatus.OffText = "Off"
        Me.btnBiasPlasmaStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnBiasPlasmaStatus.OnText = "On"
        Me.btnBiasPlasmaStatus.Size = New System.Drawing.Size(60, 30)
        Me.btnBiasPlasmaStatus.TabIndex = 314
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
        'CoronaChamberControl
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Chamber_Table_Up
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Wafer7)
        Me.Controls.Add(Me.Wafer1)
        Me.Controls.Add(Me.btnBiasPlasmaStatus)
        Me.Controls.Add(Me.btnCtxMenu)
        Me.Controls.Add(Me.btnMesaValve)
        Me.Controls.Add(Me.Wafer8)
        Me.Controls.Add(Me.Wafer4)
        Me.Controls.Add(Me.Wafer5)
        Me.Controls.Add(Me.Wafer6)
        Me.Controls.Add(Me.Wafer3)
        Me.Controls.Add(Me.Wafer2)
        Me.Controls.Add(Me.Shutter3)
        Me.Controls.Add(Me.Shutter2)
        Me.Controls.Add(Me.Shutter1)
        Me.Controls.Add(Me.Shutter4)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "CoronaChamberControl"
        Me.Size = New System.Drawing.Size(412, 244)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Shutter4 As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents Wafer1 As AVP_Robot_Project.CoronaWafer
    Friend WithEvents Wafer2 As AVP_Robot_Project.CoronaWafer
    Friend WithEvents Wafer3 As AVP_Robot_Project.CoronaWafer
    Friend WithEvents Wafer6 As AVP_Robot_Project.CoronaWafer
    Friend WithEvents Wafer5 As AVP_Robot_Project.CoronaWafer
    Friend WithEvents Wafer4 As AVP_Robot_Project.CoronaWafer
    Friend WithEvents Shutter1 As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents Shutter2 As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents Shutter3 As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents Wafer8 As AVP_Robot_Project.CoronaWafer
    Friend WithEvents Wafer7 As AVP_Robot_Project.CoronaWafer
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnMesaValve As AVP_Robot_Project.SL_ValveControl
    Friend WithEvents btnCtxMenu As System.Windows.Forms.Button
    Friend WithEvents btnBiasPlasmaStatus As AVP_Robot_Project.SL_CustomButton


End Class
