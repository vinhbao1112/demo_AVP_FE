<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_SystemControl
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
        Me.btnOnline = New AVP_Robot_Project.SL_CustomButton
        Me.btnOffline = New AVP_Robot_Project.SL_CustomButton
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Size = New System.Drawing.Size(226, 27)
        Me.Header.Text = "System Control"
        '
        'btnOnline
        '
        Me.btnOnline.BackColor = System.Drawing.Color.Transparent
        Me.btnOnline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOnline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOnline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOnline.DenyKeyEnter = True
        Me.btnOnline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnOnline.FlatAppearance.BorderSize = 0
        Me.btnOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOnline.ForeColor = System.Drawing.Color.Black
        Me.btnOnline.Location = New System.Drawing.Point(24, 34)
        Me.btnOnline.MessageBoxText = Nothing
        Me.btnOnline.Name = "btnOnline"
        Me.btnOnline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOnline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOnline.Size = New System.Drawing.Size(83, 29)
        Me.btnOnline.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnOnline.TabIndex = 38
        Me.btnOnline.Text = "Online"
        Me.btnOnline.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnOnline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnOnline.UseVisualStyleBackColor = False
        Me.btnOnline.ValueToBeSend = "On"
        '
        'btnOffline
        '
        Me.btnOffline.BackColor = System.Drawing.Color.Transparent
        Me.btnOffline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOffline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOffline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOffline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOffline.DenyKeyEnter = True
        Me.btnOffline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnOffline.FlatAppearance.BorderSize = 0
        Me.btnOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOffline.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOffline.ForeColor = System.Drawing.Color.Black
        Me.btnOffline.Location = New System.Drawing.Point(128, 34)
        Me.btnOffline.MessageBoxText = Nothing
        Me.btnOffline.Name = "btnOffline"
        Me.btnOffline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOffline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnOffline.Size = New System.Drawing.Size(83, 29)
        Me.btnOffline.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[On]
        Me.btnOffline.TabIndex = 38
        Me.btnOffline.Text = "Offline"
        Me.btnOffline.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnOffline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnOffline.UseVisualStyleBackColor = False
        Me.btnOffline.ValueToBeSend = "On"
        '
        'SL_SystemControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btnOffline)
        Me.Controls.Add(Me.btnOnline)
        Me.HeaderText = "System Control"
        Me.Name = "SL_SystemControl"
        Me.Size = New System.Drawing.Size(226, 89)
        Me.Text = "System Control"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.btnOnline, 0)
        Me.Controls.SetChildIndex(Me.btnOffline, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOnline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnOffline As AVP_Robot_Project.SL_CustomButton

End Class
