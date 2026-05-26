<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CORONA_MagnatronController
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnMag1RotationStart = New AVP_Robot_Project.SL_CustomButton
        Me.btnMag2RotationStart = New AVP_Robot_Project.SL_CustomButton
        Me.btnMag3RotationStart = New AVP_Robot_Project.SL_CustomButton
        Me.btnMag4RotationStart = New AVP_Robot_Project.SL_CustomButton
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(27, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 19)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "T1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(106, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "T2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(185, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "T3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(264, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "T4"
        '
        'btnMag1RotationStart
        '
        Me.btnMag1RotationStart.AccessibleDescription = "Magnatron 1"
        Me.btnMag1RotationStart.AccessibleName = "Magnatron1"
        Me.btnMag1RotationStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag1RotationStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMag1RotationStart.Clickable = True
        Me.btnMag1RotationStart.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnMag1RotationStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMag1RotationStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMag1RotationStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMag1RotationStart.FlatAppearance.BorderSize = 0
        Me.btnMag1RotationStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMag1RotationStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMag1RotationStart.ForeColor = System.Drawing.Color.Black
        Me.btnMag1RotationStart.IsNotValve = True
        Me.btnMag1RotationStart.Location = New System.Drawing.Point(12, 47)
        Me.btnMag1RotationStart.MessageBoxText = Nothing
        Me.btnMag1RotationStart.Name = "btnMag1RotationStart"
        Me.btnMag1RotationStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag1RotationStart.OffText = "On/Off"
        Me.btnMag1RotationStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnMag1RotationStart.OnText = "On/Off"
        Me.btnMag1RotationStart.Size = New System.Drawing.Size(56, 23)
        Me.btnMag1RotationStart.TabIndex = 51
        Me.btnMag1RotationStart.Text = "On/Off"
        Me.btnMag1RotationStart.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnMag1RotationStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnMag1RotationStart.UseChangeValueToSend_BaseOnStatus = True
        Me.btnMag1RotationStart.UseVisualStyleBackColor = True
        Me.btnMag1RotationStart.ValueToBeSend = "On"
        '
        'btnMag2RotationStart
        '
        Me.btnMag2RotationStart.AccessibleDescription = "Magnatron 2"
        Me.btnMag2RotationStart.AccessibleName = "Magnatron2"
        Me.btnMag2RotationStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag2RotationStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMag2RotationStart.Clickable = True
        Me.btnMag2RotationStart.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnMag2RotationStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMag2RotationStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMag2RotationStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMag2RotationStart.FlatAppearance.BorderSize = 0
        Me.btnMag2RotationStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMag2RotationStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMag2RotationStart.ForeColor = System.Drawing.Color.Black
        Me.btnMag2RotationStart.IsNotValve = True
        Me.btnMag2RotationStart.Location = New System.Drawing.Point(92, 47)
        Me.btnMag2RotationStart.MessageBoxText = Nothing
        Me.btnMag2RotationStart.Name = "btnMag2RotationStart"
        Me.btnMag2RotationStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag2RotationStart.OffText = "On/Off"
        Me.btnMag2RotationStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnMag2RotationStart.OnText = "On/Off"
        Me.btnMag2RotationStart.Size = New System.Drawing.Size(56, 23)
        Me.btnMag2RotationStart.TabIndex = 55
        Me.btnMag2RotationStart.Text = "On/Off"
        Me.btnMag2RotationStart.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnMag2RotationStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnMag2RotationStart.UseChangeValueToSend_BaseOnStatus = True
        Me.btnMag2RotationStart.UseVisualStyleBackColor = True
        Me.btnMag2RotationStart.ValueToBeSend = "On"
        '
        'btnMag3RotationStart
        '
        Me.btnMag3RotationStart.AccessibleDescription = "Magnatron 3"
        Me.btnMag3RotationStart.AccessibleName = "Magnatron3"
        Me.btnMag3RotationStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag3RotationStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMag3RotationStart.Clickable = True
        Me.btnMag3RotationStart.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnMag3RotationStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMag3RotationStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMag3RotationStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMag3RotationStart.FlatAppearance.BorderSize = 0
        Me.btnMag3RotationStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMag3RotationStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMag3RotationStart.ForeColor = System.Drawing.Color.Black
        Me.btnMag3RotationStart.IsNotValve = True
        Me.btnMag3RotationStart.Location = New System.Drawing.Point(171, 47)
        Me.btnMag3RotationStart.MessageBoxText = Nothing
        Me.btnMag3RotationStart.Name = "btnMag3RotationStart"
        Me.btnMag3RotationStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag3RotationStart.OffText = "On/Off"
        Me.btnMag3RotationStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnMag3RotationStart.OnText = "On/Off"
        Me.btnMag3RotationStart.Size = New System.Drawing.Size(56, 23)
        Me.btnMag3RotationStart.TabIndex = 57
        Me.btnMag3RotationStart.Text = "On/Off"
        Me.btnMag3RotationStart.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnMag3RotationStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnMag3RotationStart.UseChangeValueToSend_BaseOnStatus = True
        Me.btnMag3RotationStart.UseVisualStyleBackColor = True
        Me.btnMag3RotationStart.ValueToBeSend = "On"
        '
        'btnMag4RotationStart
        '
        Me.btnMag4RotationStart.AccessibleDescription = "Magnatron 4"
        Me.btnMag4RotationStart.AccessibleName = "Magnatron4"
        Me.btnMag4RotationStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag4RotationStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMag4RotationStart.Clickable = True
        Me.btnMag4RotationStart.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnMag4RotationStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMag4RotationStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMag4RotationStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMag4RotationStart.FlatAppearance.BorderSize = 0
        Me.btnMag4RotationStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMag4RotationStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnMag4RotationStart.ForeColor = System.Drawing.Color.Black
        Me.btnMag4RotationStart.IsNotValve = True
        Me.btnMag4RotationStart.Location = New System.Drawing.Point(250, 47)
        Me.btnMag4RotationStart.MessageBoxText = Nothing
        Me.btnMag4RotationStart.Name = "btnMag4RotationStart"
        Me.btnMag4RotationStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMag4RotationStart.OffText = "On/Off"
        Me.btnMag4RotationStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnMag4RotationStart.OnText = "On/Off"
        Me.btnMag4RotationStart.Size = New System.Drawing.Size(56, 23)
        Me.btnMag4RotationStart.TabIndex = 59
        Me.btnMag4RotationStart.Text = "On/Off"
        Me.btnMag4RotationStart.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnMag4RotationStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnMag4RotationStart.UseChangeValueToSend_BaseOnStatus = True
        Me.btnMag4RotationStart.UseVisualStyleBackColor = True
        Me.btnMag4RotationStart.ValueToBeSend = "On"
        '
        'CORONA_MagnatronController
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnMag4RotationStart)
        Me.Controls.Add(Me.btnMag3RotationStart)
        Me.Controls.Add(Me.btnMag2RotationStart)
        Me.Controls.Add(Me.btnMag1RotationStart)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "CORONA_MagnatronController"
        Me.Size = New System.Drawing.Size(320, 76)
        Me.Text = "Magnetron Controller"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnMag1RotationStart, 0)
        Me.Controls.SetChildIndex(Me.btnMag2RotationStart, 0)
        Me.Controls.SetChildIndex(Me.btnMag3RotationStart, 0)
        Me.Controls.SetChildIndex(Me.btnMag4RotationStart, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnMag1RotationStart As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnMag2RotationStart As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnMag3RotationStart As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnMag4RotationStart As AVP_Robot_Project.SL_CustomButton

End Class
