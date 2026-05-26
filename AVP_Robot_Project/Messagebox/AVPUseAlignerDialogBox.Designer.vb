<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AVPUseAlignerDialogBox
    Inherits AVPControls.AVPPopupForm

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
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.btnOk = New AVPControls.AVPButton
        Me.btnCancel = New AVPControls.AVPButton
        Me.chkUseAligner = New System.Windows.Forms.CheckBox
        Me.lblRecipe = New System.Windows.Forms.Label
        Me.cbRecipeList = New System.Windows.Forms.ComboBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSource = New System.Windows.Forms.TextBox
        Me.txtDestination = New System.Windows.Forms.TextBox
        Me.FormContainer.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.txtDestination)
        Me.FormContainer.Controls.Add(Me.txtSource)
        Me.FormContainer.Controls.Add(Me.PictureBox1)
        Me.FormContainer.Controls.Add(Me.cbRecipeList)
        Me.FormContainer.Controls.Add(Me.chkUseAligner)
        Me.FormContainer.Controls.Add(Me.Label2)
        Me.FormContainer.Controls.Add(Me.Label1)
        Me.FormContainer.Controls.Add(Me.lblRecipe)
        Me.FormContainer.Controls.Add(Me.btnCancel)
        Me.FormContainer.Controls.Add(Me.btnOk)
        Me.FormContainer.Controls.Add(Me.PictureBox2)
        Me.FormContainer.Location = New System.Drawing.Point(5, 50)
        Me.FormContainer.Size = New System.Drawing.Size(542, 241)
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(-1, 183)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(550, 4)
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = Global.AVP_Robot_Project.My.Resources.Resources.apply
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(81, 196)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOk.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOk.Size = New System.Drawing.Size(120, 40)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
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
        Me.btnCancel.Location = New System.Drawing.Point(320, 196)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnCancel.Size = New System.Drawing.Size(120, 40)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel "
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkUseAligner
        '
        Me.chkUseAligner.AutoSize = True
        Me.chkUseAligner.BackColor = System.Drawing.Color.Transparent
        Me.chkUseAligner.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkUseAligner.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseAligner.Location = New System.Drawing.Point(27, 113)
        Me.chkUseAligner.Name = "chkUseAligner"
        Me.chkUseAligner.Size = New System.Drawing.Size(123, 26)
        Me.chkUseAligner.TabIndex = 24
        Me.chkUseAligner.Text = "Use Aligner"
        Me.chkUseAligner.UseVisualStyleBackColor = False
        '
        'lblRecipe
        '
        Me.lblRecipe.AutoSize = True
        Me.lblRecipe.BackColor = System.Drawing.Color.Transparent
        Me.lblRecipe.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecipe.Location = New System.Drawing.Point(163, 136)
        Me.lblRecipe.Name = "lblRecipe"
        Me.lblRecipe.Size = New System.Drawing.Size(83, 22)
        Me.lblRecipe.TabIndex = 23
        Me.lblRecipe.Text = "RECIPE"
        '
        'cbRecipeList
        '
        Me.cbRecipeList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbRecipeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRecipeList.Enabled = False
        Me.cbRecipeList.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRecipeList.FormattingEnabled = True
        Me.cbRecipeList.Location = New System.Drawing.Point(258, 132)
        Me.cbRecipeList.Name = "cbRecipeList"
        Me.cbRecipeList.Size = New System.Drawing.Size(195, 29)
        Me.cbRecipeList.TabIndex = 25
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(-5, 107)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(550, 4)
        Me.PictureBox1.TabIndex = 26
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 22)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "SOURCE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 22)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "DESTINATION"
        '
        'txtSource
        '
        Me.txtSource.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtSource.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSource.Location = New System.Drawing.Point(167, 14)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.ReadOnly = True
        Me.txtSource.Size = New System.Drawing.Size(368, 26)
        Me.txtSource.TabIndex = 10
        '
        'txtDestination
        '
        Me.txtDestination.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtDestination.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDestination.Location = New System.Drawing.Point(167, 58)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.ReadOnly = True
        Me.txtDestination.Size = New System.Drawing.Size(368, 26)
        Me.txtDestination.TabIndex = 28
        '
        'AVPUseAlignerDialogBox
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(552, 296)
        Me.HeaderHeight = 50
        Me.ImageIcon = Global.AVP_Robot_Project.My.Resources.Resources.Warning
        Me.Name = "AVPUseAlignerDialogBox"
        Me.ShowButton = False
        Me.ShowIcon = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transfer Wafer"
        Me.TopMost = True
        Me.FormContainer.ResumeLayout(False)
        Me.FormContainer.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnOk As AVPControls.AVPButton
    Friend WithEvents btnCancel As AVPControls.AVPButton
    Friend WithEvents chkUseAligner As System.Windows.Forms.CheckBox
    Friend WithEvents lblRecipe As System.Windows.Forms.Label
    Friend WithEvents cbRecipeList As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
End Class
