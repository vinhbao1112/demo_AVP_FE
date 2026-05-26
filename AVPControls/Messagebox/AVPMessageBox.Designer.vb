<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AVPMessageBox
    Inherits AVPMsgBox

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
        Me.btnCancel = New AVPControls.AVPButton
        Me.btnOK = New AVPControls.AVPButton
        Me.btnYesToAll = New AVPControls.AVPButton
        Me.btnNo = New AVPControls.AVPButton
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbAdditionalInfo = New AVPControls.BigCheckBox(Me.components)
        Me.lblCheckbox = New System.Windows.Forms.Label
        Me.pnlContent.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.FormContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContent
        '
        Me.pnlContent.Controls.Add(Me.lblCheckbox)
        Me.pnlContent.Controls.Add(Me.cbAdditionalInfo)
        Me.pnlContent.Controls.SetChildIndex(Me.lblContent, 0)
        Me.pnlContent.Controls.SetChildIndex(Me.cbAdditionalInfo, 0)
        Me.pnlContent.Controls.SetChildIndex(Me.lblCheckbox, 0)
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
        Me.btnCancel.BackgroundImage = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatFocusStyleEnabled = True
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.AVPControls.My.Resources.Resources.cancel
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(133, 9)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.NormalBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.PressedBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnCancel.Size = New System.Drawing.Size(120, 40)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = " Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.BackgroundImage = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatFocusStyleEnabled = True
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Image = Global.AVPControls.My.Resources.Resources.apply
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOK.Location = New System.Drawing.Point(7, 9)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.NormalBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.PressedBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOK.Size = New System.Drawing.Size(120, 40)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "   OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnYesToAll
        '
        Me.btnYesToAll.BackgroundImage = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnYesToAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnYesToAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnYesToAll.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnYesToAll.FlatAppearance.BorderSize = 0
        Me.btnYesToAll.FlatFocusStyleEnabled = True
        Me.btnYesToAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYesToAll.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYesToAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnYesToAll.Location = New System.Drawing.Point(309, 9)
        Me.btnYesToAll.Name = "btnYesToAll"
        Me.btnYesToAll.NormalBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnYesToAll.PressedBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnYesToAll.Size = New System.Drawing.Size(120, 40)
        Me.btnYesToAll.TabIndex = 3
        Me.btnYesToAll.Text = "Yes To All"
        Me.btnYesToAll.UseVisualStyleBackColor = True
        Me.btnYesToAll.Visible = False
        '
        'btnNo
        '
        Me.btnNo.BackgroundImage = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.No
        Me.btnNo.FlatAppearance.BorderSize = 0
        Me.btnNo.FlatFocusStyleEnabled = True
        Me.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNo.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.Image = Global.AVPControls.My.Resources.Resources.ErrorImage
        Me.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNo.Location = New System.Drawing.Point(259, 9)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.NormalBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnNo.PressedBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnNo.Size = New System.Drawing.Size(110, 40)
        Me.btnNo.TabIndex = 3
        Me.btnNo.Text = "No    "
        Me.btnNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNo.UseVisualStyleBackColor = True
        Me.btnNo.Visible = False
        '
        'ToolTip
        '
        Me.ToolTip.AutomaticDelay = 200
        '
        'cbAdditionalInfo
        '
        Me.cbAdditionalInfo.Location = New System.Drawing.Point(145, 82)
        Me.cbAdditionalInfo.Name = "cbAdditionalInfo"
        Me.cbAdditionalInfo.Size = New System.Drawing.Size(24, 24)
        Me.cbAdditionalInfo.TabIndex = 8
        Me.cbAdditionalInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAdditionalInfo.UseVisualStyleBackColor = True
        Me.cbAdditionalInfo.Visible = False
        '
        'lblCheckbox
        '
        Me.lblCheckbox.AutoSize = True
        Me.lblCheckbox.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckbox.Location = New System.Drawing.Point(169, 85)
        Me.lblCheckbox.Name = "lblCheckbox"
        Me.lblCheckbox.Size = New System.Drawing.Size(55, 19)
        Me.lblCheckbox.TabIndex = 9
        Me.lblCheckbox.Text = "Label1"
        Me.lblCheckbox.Visible = False
        '
        'AVPMessageBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(446, 236)
        Me.ImageIcon = Global.AVPControls.My.Resources.Resources.Warning
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
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents cbAdditionalInfo As AVPControls.BigCheckBox
    Friend WithEvents lblCheckbox As System.Windows.Forms.Label
End Class
