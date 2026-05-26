<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CORONA_TargetSelect
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
        Me.pnlContent.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.FormContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSeparator
        '
        Me.pnlSeparator.Location = New System.Drawing.Point(0, 92)
        Me.pnlSeparator.Size = New System.Drawing.Size(394, 3)
        '
        'pnlContent
        '
        Me.pnlContent.Size = New System.Drawing.Size(394, 95)
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Controls.Add(Me.btnNo)
        Me.pnlBottom.Controls.Add(Me.btnYesToAll)
        Me.pnlBottom.Controls.Add(Me.btnOK)
        Me.pnlBottom.Location = New System.Drawing.Point(0, 95)
        Me.pnlBottom.Size = New System.Drawing.Size(394, 55)
        '
        'lblContent
        '
        Me.lblContent.Size = New System.Drawing.Size(394, 95)
        Me.lblContent.Text = "Please Choose Target"
        '
        'FormContainer
        '
        Me.FormContainer.Location = New System.Drawing.Point(5, 55)
        Me.FormContainer.Size = New System.Drawing.Size(394, 150)
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(105, 9)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnCancel.Size = New System.Drawing.Size(90, 40)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Target 2"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOK.Location = New System.Drawing.Point(9, 9)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOK.Size = New System.Drawing.Size(90, 40)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "Target 1"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnYesToAll
        '
        Me.btnYesToAll.BackColor = System.Drawing.Color.Transparent
        Me.btnYesToAll.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnYesToAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnYesToAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnYesToAll.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.btnYesToAll.FlatAppearance.BorderSize = 0
        Me.btnYesToAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnYesToAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnYesToAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYesToAll.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYesToAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnYesToAll.Location = New System.Drawing.Point(297, 9)
        Me.btnYesToAll.Name = "btnYesToAll"
        Me.btnYesToAll.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnYesToAll.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnYesToAll.Size = New System.Drawing.Size(90, 40)
        Me.btnYesToAll.TabIndex = 3
        Me.btnYesToAll.Text = "Target 4"
        Me.btnYesToAll.UseVisualStyleBackColor = False
        '
        'btnNo
        '
        Me.btnNo.BackColor = System.Drawing.Color.Transparent
        Me.btnNo.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.Retry
        Me.btnNo.FlatAppearance.BorderSize = 0
        Me.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNo.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNo.Location = New System.Drawing.Point(201, 9)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnNo.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnNo.Size = New System.Drawing.Size(90, 40)
        Me.btnNo.TabIndex = 3
        Me.btnNo.Text = "Target 3"
        Me.btnNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNo.UseVisualStyleBackColor = False
        '
        'CORONA_TargetSelect
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(404, 210)
        Me.HeaderHeight = 55
        Me.ImageIcon = Global.AVP_Robot_Project.My.Resources.Resources.Warning
        Me.Name = "CORONA_TargetSelect"
        Me.Text = "CORONA_TargetSelect"
        Me.pnlContent.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.FormContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As AVPControls.AVPButton
    Friend WithEvents btnOK As AVPControls.AVPButton
    Friend WithEvents btnYesToAll As AVPControls.AVPButton
    Friend WithEvents btnNo As AVPControls.AVPButton
End Class
