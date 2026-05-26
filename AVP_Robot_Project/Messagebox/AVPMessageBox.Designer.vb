<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AVPMessageBox
    Inherits AVPControls.AVPMsgBox

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
        Me.btnCancel = New AVPControls.AVPButton
        Me.btnOK = New AVPControls.AVPButton
        Me.btnYesToAll = New AVPControls.AVPButton
        Me.btnNo = New AVPControls.AVPButton
        Me.cbAdditionalInfo = New System.Windows.Forms.CheckBox
        Me.pnlContent.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.FormContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContent
        '
        Me.pnlContent.Controls.Add(Me.cbAdditionalInfo)
        Me.pnlContent.Controls.SetChildIndex(Me.lblContent, 0)
        Me.pnlContent.Controls.SetChildIndex(Me.cbAdditionalInfo, 0)
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Controls.Add(Me.btnNo)
        Me.pnlBottom.Controls.Add(Me.btnYesToAll)
        Me.pnlBottom.Controls.Add(Me.btnOK)
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.AVP_Robot_Project.My.Resources.Resources.cancel
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(133, 9)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnCancel.Size = New System.Drawing.Size(120, 40)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = " Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Image = Global.AVP_Robot_Project.My.Resources.Resources.apply
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOK.Location = New System.Drawing.Point(7, 9)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOK.Size = New System.Drawing.Size(120, 40)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "   OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnYesToAll
        '
        Me.btnYesToAll.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnYesToAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnYesToAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnYesToAll.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnYesToAll.FlatAppearance.BorderSize = 0
        Me.btnYesToAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYesToAll.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYesToAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnYesToAll.Location = New System.Drawing.Point(309, 9)
        Me.btnYesToAll.Name = "btnYesToAll"
        Me.btnYesToAll.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnYesToAll.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnYesToAll.Size = New System.Drawing.Size(120, 40)
        Me.btnYesToAll.TabIndex = 3
        Me.btnYesToAll.Text = "Yes To All"
        Me.btnYesToAll.UseVisualStyleBackColor = True
        Me.btnYesToAll.Visible = False
        '
        'btnNo
        '
        Me.btnNo.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.No
        Me.btnNo.FlatAppearance.BorderSize = 0
        Me.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNo.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.Image = Global.AVP_Robot_Project.My.Resources.Resources.ErrorImage
        Me.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNo.Location = New System.Drawing.Point(259, 9)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnNo.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnNo.Size = New System.Drawing.Size(110, 40)
        Me.btnNo.TabIndex = 3
        Me.btnNo.Text = "No    "
        Me.btnNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNo.UseVisualStyleBackColor = True
        Me.btnNo.Visible = False
        '
        'cbAdditionalInfo
        '
        Me.cbAdditionalInfo.AutoSize = True
        Me.cbAdditionalInfo.Location = New System.Drawing.Point(138, 88)
        Me.cbAdditionalInfo.Name = "cbAdditionalInfo"
        Me.cbAdditionalInfo.Size = New System.Drawing.Size(81, 17)
        Me.cbAdditionalInfo.TabIndex = 7
        Me.cbAdditionalInfo.Text = "CheckBox1"
        Me.cbAdditionalInfo.UseVisualStyleBackColor = True
        Me.cbAdditionalInfo.Visible = False
        '
        'AVPMessageBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(446, 236)
        Me.ImageIcon = Global.AVP_Robot_Project.My.Resources.Resources.Warning
        Me.Name = "AVPMessageBox"
        Me.Text = "AVPMessageBox"
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContent.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.FormContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As AVPControls.AVPButton
    Friend WithEvents btnOK As AVPControls.AVPButton
    Friend WithEvents btnYesToAll As AVPControls.AVPButton
    Friend WithEvents btnNo As AVPControls.AVPButton
    Friend WithEvents cbAdditionalInfo As System.Windows.Forms.CheckBox
End Class
