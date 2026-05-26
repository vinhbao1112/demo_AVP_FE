<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_ROR_PDC_Info
    Inherits AVPControls.AVPPopupForm

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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.grbInfo = New System.Windows.Forms.GroupBox
        Me.btnCancel = New AVP_Robot_Project.SL_CustomButton
        Me.btnStart = New AVP_Robot_Project.SL_CustomButton
        Me.txtTotalTime = New AVP_Robot_Project.SL_Textbox
        Me.txtSampleTime = New AVP_Robot_Project.SL_Textbox
        Me.lblLotID = New System.Windows.Forms.Label
        Me.lblPalletID = New System.Windows.Forms.Label
        Me.lblTIP = New System.Windows.Forms.Label
        Me.lblOperatorID = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.grbInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.grbInfo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(495, 215)
        Me.Panel2.TabIndex = 40
        '
        'grbInfo
        '
        Me.grbInfo.Controls.Add(Me.btnCancel)
        Me.grbInfo.Controls.Add(Me.btnStart)
        Me.grbInfo.Controls.Add(Me.txtTotalTime)
        Me.grbInfo.Controls.Add(Me.txtSampleTime)
        Me.grbInfo.Controls.Add(Me.lblLotID)
        Me.grbInfo.Controls.Add(Me.lblPalletID)
        Me.grbInfo.Controls.Add(Me.lblTIP)
        Me.grbInfo.Controls.Add(Me.lblOperatorID)
        Me.grbInfo.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbInfo.Location = New System.Drawing.Point(4, 0)
        Me.grbInfo.Name = "grbInfo"
        Me.grbInfo.Size = New System.Drawing.Size(488, 212)
        Me.grbInfo.TabIndex = 75
        Me.grbInfo.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnCancel.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(266, 136)
        Me.btnCancel.MessageBoxText = Nothing
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnCancel.Size = New System.Drawing.Size(148, 47)
        Me.btnCancel.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnCancel.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnCancel.UseClickedEventInForm = True
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.ValueToBeSend = "On"
        '
        'btnStart
        '
        Me.btnStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnStart.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnStart.FlatAppearance.BorderSize = 0
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnStart.ForeColor = System.Drawing.Color.Black
        Me.btnStart.Location = New System.Drawing.Point(48, 136)
        Me.btnStart.MessageBoxText = Nothing
        Me.btnStart.Name = "btnStart"
        Me.btnStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnStart.Size = New System.Drawing.Size(148, 47)
        Me.btnStart.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnStart.TabIndex = 6
        Me.btnStart.Text = "Start"
        Me.btnStart.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnStart.UseClickedEventInForm = True
        Me.btnStart.UseVisualStyleBackColor = True
        Me.btnStart.ValueToBeSend = "On"
        '
        'txtTotalTime
        '
        Me.txtTotalTime.AutoSendKeyTabWhenFinishInput = True
        Me.txtTotalTime.BackColor = System.Drawing.Color.White
        Me.txtTotalTime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTotalTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalTime.IsNumericTextbox = True
        Me.txtTotalTime.Location = New System.Drawing.Point(174, 82)
        Me.txtTotalTime.Name = "txtTotalTime"
        Me.txtTotalTime.ReadOnly = True
        Me.txtTotalTime.Size = New System.Drawing.Size(191, 24)
        Me.txtTotalTime.TabIndex = 1
        Me.txtTotalTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTotalTime.UseScientificFormat = True
        '
        'txtSampleTime
        '
        Me.txtSampleTime.AutoSendKeyTabWhenFinishInput = True
        Me.txtSampleTime.BackColor = System.Drawing.Color.White
        Me.txtSampleTime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSampleTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSampleTime.IsNumericTextbox = True
        Me.txtSampleTime.Location = New System.Drawing.Point(174, 38)
        Me.txtSampleTime.Name = "txtSampleTime"
        Me.txtSampleTime.ReadOnly = True
        Me.txtSampleTime.Size = New System.Drawing.Size(191, 24)
        Me.txtSampleTime.TabIndex = 0
        Me.txtSampleTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSampleTime.UseScientificFormat = True
        '
        'lblLotID
        '
        Me.lblLotID.AutoSize = True
        Me.lblLotID.Location = New System.Drawing.Point(390, 83)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(76, 22)
        Me.lblLotID.TabIndex = 0
        Me.lblLotID.Text = "Minutes"
        '
        'lblPalletID
        '
        Me.lblPalletID.AutoSize = True
        Me.lblPalletID.Location = New System.Drawing.Point(390, 39)
        Me.lblPalletID.Name = "lblPalletID"
        Me.lblPalletID.Size = New System.Drawing.Size(47, 22)
        Me.lblPalletID.TabIndex = 0
        Me.lblPalletID.Text = "Secs"
        '
        'lblTIP
        '
        Me.lblTIP.AutoSize = True
        Me.lblTIP.Location = New System.Drawing.Point(32, 83)
        Me.lblTIP.Name = "lblTIP"
        Me.lblTIP.Size = New System.Drawing.Size(99, 22)
        Me.lblTIP.TabIndex = 0
        Me.lblTIP.Text = "Total Time"
        '
        'lblOperatorID
        '
        Me.lblOperatorID.AutoSize = True
        Me.lblOperatorID.Location = New System.Drawing.Point(32, 39)
        Me.lblOperatorID.Name = "lblOperatorID"
        Me.lblOperatorID.Size = New System.Drawing.Size(133, 22)
        Me.lblOperatorID.TabIndex = 0
        Me.lblOperatorID.Text = "Sampling Time"
        '
        'SL_ROR_PDC_Info
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(495, 255)
        Me.ControlBox = False
        Me.FormContainer.Controls.Add(Me.Panel2)
        Me.Name = "SL_ROR_PDC_Info"
        Me.ShowTitle = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Info"
        Me.Panel2.ResumeLayout(False)
        Me.grbInfo.ResumeLayout(False)
        Me.grbInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSampleTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblLotID As System.Windows.Forms.Label
    Friend WithEvents lblPalletID As System.Windows.Forms.Label
    Friend WithEvents lblTIP As System.Windows.Forms.Label
    Friend WithEvents lblOperatorID As System.Windows.Forms.Label
    Friend WithEvents btnStart As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnCancel As AVP_Robot_Project.SL_CustomButton

End Class
