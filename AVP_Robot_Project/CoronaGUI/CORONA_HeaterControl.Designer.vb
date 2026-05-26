<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CORONA_HeaterControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CORONA_HeaterControl))
        Me.txtHeaterZone2RB = New AVP_Robot_Project.SL_Textbox
        Me.txtHeaterZone2SP = New AVP_Robot_Project.SL_Textbox
        Me.txtHeaterZone1SP = New AVP_Robot_Project.SL_Textbox
        Me.txtHeaterZone1RB = New AVP_Robot_Project.SL_Textbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnHeaterZone1Status = New AVP_Robot_Project.SL_CustomButton
        Me.btnHeaterZone2Status = New AVP_Robot_Project.SL_CustomButton
        Me.btnZone2ComStatus = New AVP_Robot_Project.SL_CustomButton
        Me.btnZone1ComStatus = New AVP_Robot_Project.SL_CustomButton
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = CType(resources.GetObject("Header.BackgroundImage"), System.Drawing.Image)
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.Size = New System.Drawing.Size(320, 27)
        Me.Header.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.On
        Me.Header.Text = "Heater"
        '
        'txtHeaterZone2RB
        '
        Me.txtHeaterZone2RB.AccessibleName = "Heater Zone 2"
        Me.txtHeaterZone2RB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHeaterZone2RB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtHeaterZone2RB.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtHeaterZone2RB.IsNumericTextbox = True
        Me.txtHeaterZone2RB.IsReadBack = True
        Me.txtHeaterZone2RB.Location = New System.Drawing.Point(173, 55)
        Me.txtHeaterZone2RB.Name = "txtHeaterZone2RB"
        Me.txtHeaterZone2RB.ReadOnly = True
        Me.txtHeaterZone2RB.Size = New System.Drawing.Size(70, 24)
        Me.txtHeaterZone2RB.TabIndex = 54
        Me.txtHeaterZone2RB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtHeaterZone2RB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtHeaterZone2SP
        '
        Me.txtHeaterZone2SP.AccessibleName = "Heater Zone 2 SP"
        Me.txtHeaterZone2SP.BackColor = System.Drawing.Color.White
        Me.txtHeaterZone2SP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtHeaterZone2SP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtHeaterZone2SP.IsNumericTextbox = True
        Me.txtHeaterZone2SP.IsReadBack = False
        Me.txtHeaterZone2SP.Location = New System.Drawing.Point(245, 55)
        Me.txtHeaterZone2SP.Name = "txtHeaterZone2SP"
        Me.txtHeaterZone2SP.ReadOnly = True
        Me.txtHeaterZone2SP.Size = New System.Drawing.Size(70, 24)
        Me.txtHeaterZone2SP.TabIndex = 56
        Me.txtHeaterZone2SP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtHeaterZone2SP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtHeaterZone1SP
        '
        Me.txtHeaterZone1SP.AccessibleName = "Heater Zone 1 SP"
        Me.txtHeaterZone1SP.BackColor = System.Drawing.Color.White
        Me.txtHeaterZone1SP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtHeaterZone1SP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtHeaterZone1SP.IsNumericTextbox = True
        Me.txtHeaterZone1SP.IsReadBack = False
        Me.txtHeaterZone1SP.Location = New System.Drawing.Point(245, 31)
        Me.txtHeaterZone1SP.Name = "txtHeaterZone1SP"
        Me.txtHeaterZone1SP.ReadOnly = True
        Me.txtHeaterZone1SP.Size = New System.Drawing.Size(70, 24)
        Me.txtHeaterZone1SP.TabIndex = 57
        Me.txtHeaterZone1SP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtHeaterZone1SP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtHeaterZone1RB
        '
        Me.txtHeaterZone1RB.AccessibleName = "Heater Zone 1"
        Me.txtHeaterZone1RB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHeaterZone1RB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtHeaterZone1RB.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtHeaterZone1RB.IsNumericTextbox = True
        Me.txtHeaterZone1RB.IsReadBack = True
        Me.txtHeaterZone1RB.Location = New System.Drawing.Point(173, 31)
        Me.txtHeaterZone1RB.Name = "txtHeaterZone1RB"
        Me.txtHeaterZone1RB.ReadOnly = True
        Me.txtHeaterZone1RB.Size = New System.Drawing.Size(70, 24)
        Me.txtHeaterZone1RB.TabIndex = 55
        Me.txtHeaterZone1RB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtHeaterZone1RB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 19)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Zone 2 (ºC)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 19)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Zone 1 (ºC)"
        '
        'btnHeaterZone1Status
        '
        Me.btnHeaterZone1Status.AccessibleDescription = "Heater Zone 1"
        Me.btnHeaterZone1Status.AccessibleName = "HeaterZone1Status"
        Me.btnHeaterZone1Status.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHeaterZone1Status.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHeaterZone1Status.Clickable = True
        Me.btnHeaterZone1Status.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnHeaterZone1Status.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnHeaterZone1Status.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHeaterZone1Status.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnHeaterZone1Status.FlatAppearance.BorderSize = 0
        Me.btnHeaterZone1Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHeaterZone1Status.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnHeaterZone1Status.ForeColor = System.Drawing.Color.Black
        Me.btnHeaterZone1Status.IsNotValve = True
        Me.btnHeaterZone1Status.Location = New System.Drawing.Point(114, 32)
        Me.btnHeaterZone1Status.MessageBoxText = Nothing
        Me.btnHeaterZone1Status.Name = "btnHeaterZone1Status"
        Me.btnHeaterZone1Status.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHeaterZone1Status.OffText = "On/Off"
        Me.btnHeaterZone1Status.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnHeaterZone1Status.OnText = "On/Off"
        Me.btnHeaterZone1Status.Size = New System.Drawing.Size(56, 23)
        Me.btnHeaterZone1Status.TabIndex = 51
        Me.btnHeaterZone1Status.Text = "On/Off"
        Me.btnHeaterZone1Status.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnHeaterZone1Status.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnHeaterZone1Status.UseChangeValueToSend_BaseOnStatus = True
        Me.btnHeaterZone1Status.UseVisualStyleBackColor = True
        Me.btnHeaterZone1Status.ValueToBeSend = "On"
        '
        'btnHeaterZone2Status
        '
        Me.btnHeaterZone2Status.AccessibleDescription = "Heater Zone 2"
        Me.btnHeaterZone2Status.AccessibleName = "HeaterZone2Status"
        Me.btnHeaterZone2Status.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHeaterZone2Status.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHeaterZone2Status.Clickable = True
        Me.btnHeaterZone2Status.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnHeaterZone2Status.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnHeaterZone2Status.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHeaterZone2Status.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnHeaterZone2Status.FlatAppearance.BorderSize = 0
        Me.btnHeaterZone2Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHeaterZone2Status.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnHeaterZone2Status.ForeColor = System.Drawing.Color.Black
        Me.btnHeaterZone2Status.IsNotValve = True
        Me.btnHeaterZone2Status.Location = New System.Drawing.Point(114, 56)
        Me.btnHeaterZone2Status.MessageBoxText = Nothing
        Me.btnHeaterZone2Status.Name = "btnHeaterZone2Status"
        Me.btnHeaterZone2Status.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHeaterZone2Status.OffText = "On/Off"
        Me.btnHeaterZone2Status.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnHeaterZone2Status.OnText = "On/Off"
        Me.btnHeaterZone2Status.Size = New System.Drawing.Size(56, 23)
        Me.btnHeaterZone2Status.TabIndex = 51
        Me.btnHeaterZone2Status.Text = "On/Off"
        Me.btnHeaterZone2Status.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnHeaterZone2Status.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnHeaterZone2Status.UseChangeValueToSend_BaseOnStatus = True
        Me.btnHeaterZone2Status.UseVisualStyleBackColor = True
        Me.btnHeaterZone2Status.ValueToBeSend = "On"
        '
        'btnZone2ComStatus
        '
        Me.btnZone2ComStatus.BackgroundImage = CType(resources.GetObject("btnZone2ComStatus.BackgroundImage"), System.Drawing.Image)
        Me.btnZone2ComStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnZone2ComStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnZone2ComStatus.ErrorImage = CType(resources.GetObject("btnZone2ComStatus.ErrorImage"), System.Drawing.Image)
        Me.btnZone2ComStatus.FlatAppearance.BorderSize = 0
        Me.btnZone2ComStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZone2ComStatus.ForeColor = System.Drawing.Color.White
        Me.btnZone2ComStatus.Location = New System.Drawing.Point(270, 0)
        Me.btnZone2ComStatus.MessageBoxText = Nothing
        Me.btnZone2ComStatus.Name = "btnZone2ComStatus"
        Me.btnZone2ComStatus.OffImage = CType(resources.GetObject("btnZone2ComStatus.OffImage"), System.Drawing.Image)
        Me.btnZone2ComStatus.OnImage = CType(resources.GetObject("btnZone2ComStatus.OnImage"), System.Drawing.Image)
        Me.btnZone2ComStatus.Size = New System.Drawing.Size(50, 23)
        Me.btnZone2ComStatus.TabIndex = 61
        Me.btnZone2ComStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnZone2ComStatus.UnknownImage = CType(resources.GetObject("btnZone2ComStatus.UnknownImage"), System.Drawing.Image)
        Me.btnZone2ComStatus.UseVisualStyleBackColor = True
        Me.btnZone2ComStatus.ValueToBeSend = "On"
        Me.btnZone2ComStatus.Visible = False
        '
        'btnZone1ComStatus
        '
        Me.btnZone1ComStatus.BackgroundImage = CType(resources.GetObject("btnZone1ComStatus.BackgroundImage"), System.Drawing.Image)
        Me.btnZone1ComStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnZone1ComStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnZone1ComStatus.ErrorImage = CType(resources.GetObject("btnZone1ComStatus.ErrorImage"), System.Drawing.Image)
        Me.btnZone1ComStatus.FlatAppearance.BorderSize = 0
        Me.btnZone1ComStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZone1ComStatus.ForeColor = System.Drawing.Color.White
        Me.btnZone1ComStatus.Location = New System.Drawing.Point(218, 0)
        Me.btnZone1ComStatus.MessageBoxText = Nothing
        Me.btnZone1ComStatus.Name = "btnZone1ComStatus"
        Me.btnZone1ComStatus.OffImage = CType(resources.GetObject("btnZone1ComStatus.OffImage"), System.Drawing.Image)
        Me.btnZone1ComStatus.OnImage = CType(resources.GetObject("btnZone1ComStatus.OnImage"), System.Drawing.Image)
        Me.btnZone1ComStatus.Size = New System.Drawing.Size(50, 23)
        Me.btnZone1ComStatus.TabIndex = 60
        Me.btnZone1ComStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnZone1ComStatus.UnknownImage = CType(resources.GetObject("btnZone1ComStatus.UnknownImage"), System.Drawing.Image)
        Me.btnZone1ComStatus.UseVisualStyleBackColor = True
        Me.btnZone1ComStatus.ValueToBeSend = "On"
        Me.btnZone1ComStatus.Visible = False
        '
        'CORONA_HeaterControl
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnZone2ComStatus)
        Me.Controls.Add(Me.btnZone1ComStatus)
        Me.Controls.Add(Me.txtHeaterZone2RB)
        Me.Controls.Add(Me.txtHeaterZone2SP)
        Me.Controls.Add(Me.txtHeaterZone1SP)
        Me.Controls.Add(Me.txtHeaterZone1RB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnHeaterZone2Status)
        Me.Controls.Add(Me.btnHeaterZone1Status)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "CORONA_HeaterControl"
        Me.Size = New System.Drawing.Size(320, 86)
        Me.Text = "Heater"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.btnHeaterZone1Status, 0)
        Me.Controls.SetChildIndex(Me.btnHeaterZone2Status, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtHeaterZone1RB, 0)
        Me.Controls.SetChildIndex(Me.txtHeaterZone1SP, 0)
        Me.Controls.SetChildIndex(Me.txtHeaterZone2SP, 0)
        Me.Controls.SetChildIndex(Me.txtHeaterZone2RB, 0)
        Me.Controls.SetChildIndex(Me.btnZone1ComStatus, 0)
        Me.Controls.SetChildIndex(Me.btnZone2ComStatus, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHeaterZone2RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtHeaterZone2SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtHeaterZone1SP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtHeaterZone1RB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnHeaterZone1Status As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnHeaterZone2Status As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnZone2ComStatus As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnZone1ComStatus As AVP_Robot_Project.SL_CustomButton

End Class
