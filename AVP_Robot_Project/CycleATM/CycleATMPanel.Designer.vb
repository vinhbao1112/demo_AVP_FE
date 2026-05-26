<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CycleATMPanel
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
        Me.gbxCycleLoadLock = New System.Windows.Forms.GroupBox
        Me.rbCycleLLA = New System.Windows.Forms.RadioButton
        Me.gbxCyclePM = New System.Windows.Forms.GroupBox
        Me.cbxPM6 = New System.Windows.Forms.CheckBox
        Me.cbxPM5 = New System.Windows.Forms.CheckBox
        Me.cbxPM3 = New System.Windows.Forms.CheckBox
        Me.cbxPM4 = New System.Windows.Forms.CheckBox
        Me.cbxPM2 = New System.Windows.Forms.CheckBox
        Me.cbxPM1 = New System.Windows.Forms.CheckBox
        Me.cbAlignerRecipe = New System.Windows.Forms.ComboBox
        Me.lblAligner = New System.Windows.Forms.Label
        Me.gbxCycleOptions = New System.Windows.Forms.GroupBox
        Me.rbCycleWithoutMotion = New System.Windows.Forms.RadioButton
        Me.rbCycleWithMotion = New System.Windows.Forms.RadioButton
        Me.btnStartATM = New AVPControls.AVPButton
        Me.gbxCycleLoadLock.SuspendLayout()
        Me.gbxCyclePM.SuspendLayout()
        Me.gbxCycleOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Size = New System.Drawing.Size(464, 32)
        Me.Header.Text = "Cycle ATM"
        '
        'gbxCycleLoadLock
        '
        Me.gbxCycleLoadLock.Controls.Add(Me.rbCycleLLA)
        Me.gbxCycleLoadLock.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxCycleLoadLock.ForeColor = System.Drawing.Color.White
        Me.gbxCycleLoadLock.Location = New System.Drawing.Point(7, 34)
        Me.gbxCycleLoadLock.Name = "gbxCycleLoadLock"
        Me.gbxCycleLoadLock.Size = New System.Drawing.Size(449, 63)
        Me.gbxCycleLoadLock.TabIndex = 11
        Me.gbxCycleLoadLock.TabStop = False
        Me.gbxCycleLoadLock.Text = "Cycle LoadLock"
        '
        'rbCycleLLA
        '
        Me.rbCycleLLA.AutoSize = True
        Me.rbCycleLLA.Checked = True
        Me.rbCycleLLA.ForeColor = System.Drawing.Color.Black
        Me.rbCycleLLA.Location = New System.Drawing.Point(22, 25)
        Me.rbCycleLLA.Name = "rbCycleLLA"
        Me.rbCycleLLA.Size = New System.Drawing.Size(58, 23)
        Me.rbCycleLLA.TabIndex = 0
        Me.rbCycleLLA.TabStop = True
        Me.rbCycleLLA.Text = "LLA"
        Me.rbCycleLLA.UseVisualStyleBackColor = True
        '
        'gbxCyclePM
        '
        Me.gbxCyclePM.Controls.Add(Me.cbxPM6)
        Me.gbxCyclePM.Controls.Add(Me.cbxPM5)
        Me.gbxCyclePM.Controls.Add(Me.cbxPM3)
        Me.gbxCyclePM.Controls.Add(Me.cbxPM4)
        Me.gbxCyclePM.Controls.Add(Me.cbxPM2)
        Me.gbxCyclePM.Controls.Add(Me.cbxPM1)
        Me.gbxCyclePM.Controls.Add(Me.cbAlignerRecipe)
        Me.gbxCyclePM.Controls.Add(Me.lblAligner)
        Me.gbxCyclePM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxCyclePM.ForeColor = System.Drawing.Color.White
        Me.gbxCyclePM.Location = New System.Drawing.Point(7, 103)
        Me.gbxCyclePM.Name = "gbxCyclePM"
        Me.gbxCyclePM.Size = New System.Drawing.Size(449, 246)
        Me.gbxCyclePM.TabIndex = 12
        Me.gbxCyclePM.TabStop = False
        Me.gbxCyclePM.Text = "Cycle PM"
        '
        'cbxPM6
        '
        Me.cbxPM6.AutoSize = True
        Me.cbxPM6.ForeColor = System.Drawing.Color.Black
        Me.cbxPM6.Location = New System.Drawing.Point(22, 209)
        Me.cbxPM6.Name = "cbxPM6"
        Me.cbxPM6.Size = New System.Drawing.Size(61, 23)
        Me.cbxPM6.TabIndex = 2
        Me.cbxPM6.Text = "PM6"
        Me.cbxPM6.UseVisualStyleBackColor = True
        Me.cbxPM6.Visible = False
        '
        'cbxPM5
        '
        Me.cbxPM5.AutoSize = True
        Me.cbxPM5.ForeColor = System.Drawing.Color.Black
        Me.cbxPM5.Location = New System.Drawing.Point(22, 180)
        Me.cbxPM5.Name = "cbxPM5"
        Me.cbxPM5.Size = New System.Drawing.Size(61, 23)
        Me.cbxPM5.TabIndex = 2
        Me.cbxPM5.Text = "PM5"
        Me.cbxPM5.UseVisualStyleBackColor = True
        Me.cbxPM5.Visible = False
        '
        'cbxPM3
        '
        Me.cbxPM3.AutoSize = True
        Me.cbxPM3.ForeColor = System.Drawing.Color.Black
        Me.cbxPM3.Location = New System.Drawing.Point(22, 122)
        Me.cbxPM3.Name = "cbxPM3"
        Me.cbxPM3.Size = New System.Drawing.Size(61, 23)
        Me.cbxPM3.TabIndex = 2
        Me.cbxPM3.Text = "PM3"
        Me.cbxPM3.UseVisualStyleBackColor = True
        Me.cbxPM3.Visible = False
        '
        'cbxPM4
        '
        Me.cbxPM4.AutoSize = True
        Me.cbxPM4.ForeColor = System.Drawing.Color.Black
        Me.cbxPM4.Location = New System.Drawing.Point(22, 151)
        Me.cbxPM4.Name = "cbxPM4"
        Me.cbxPM4.Size = New System.Drawing.Size(61, 23)
        Me.cbxPM4.TabIndex = 2
        Me.cbxPM4.Text = "PM4"
        Me.cbxPM4.UseVisualStyleBackColor = True
        Me.cbxPM4.Visible = False
        '
        'cbxPM2
        '
        Me.cbxPM2.AutoSize = True
        Me.cbxPM2.ForeColor = System.Drawing.Color.Black
        Me.cbxPM2.Location = New System.Drawing.Point(22, 93)
        Me.cbxPM2.Name = "cbxPM2"
        Me.cbxPM2.Size = New System.Drawing.Size(61, 23)
        Me.cbxPM2.TabIndex = 2
        Me.cbxPM2.Text = "PM2"
        Me.cbxPM2.UseVisualStyleBackColor = True
        Me.cbxPM2.Visible = False
        '
        'cbxPM1
        '
        Me.cbxPM1.AutoSize = True
        Me.cbxPM1.ForeColor = System.Drawing.Color.Black
        Me.cbxPM1.Location = New System.Drawing.Point(22, 64)
        Me.cbxPM1.Name = "cbxPM1"
        Me.cbxPM1.Size = New System.Drawing.Size(61, 23)
        Me.cbxPM1.TabIndex = 2
        Me.cbxPM1.Text = "PM1"
        Me.cbxPM1.UseVisualStyleBackColor = True
        Me.cbxPM1.Visible = False
        '
        'cbAlignerRecipe
        '
        Me.cbAlignerRecipe.FormattingEnabled = True
        Me.cbAlignerRecipe.Location = New System.Drawing.Point(79, 27)
        Me.cbAlignerRecipe.Name = "cbAlignerRecipe"
        Me.cbAlignerRecipe.Size = New System.Drawing.Size(131, 27)
        Me.cbAlignerRecipe.TabIndex = 1
        '
        'lblAligner
        '
        Me.lblAligner.AutoSize = True
        Me.lblAligner.ForeColor = System.Drawing.Color.Black
        Me.lblAligner.Location = New System.Drawing.Point(18, 31)
        Me.lblAligner.Name = "lblAligner"
        Me.lblAligner.Size = New System.Drawing.Size(58, 19)
        Me.lblAligner.TabIndex = 0
        Me.lblAligner.Text = "Aligner"
        '
        'gbxCycleOptions
        '
        Me.gbxCycleOptions.Controls.Add(Me.rbCycleWithoutMotion)
        Me.gbxCycleOptions.Controls.Add(Me.rbCycleWithMotion)
        Me.gbxCycleOptions.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxCycleOptions.ForeColor = System.Drawing.Color.White
        Me.gbxCycleOptions.Location = New System.Drawing.Point(7, 355)
        Me.gbxCycleOptions.Name = "gbxCycleOptions"
        Me.gbxCycleOptions.Size = New System.Drawing.Size(449, 63)
        Me.gbxCycleOptions.TabIndex = 12
        Me.gbxCycleOptions.TabStop = False
        Me.gbxCycleOptions.Text = "Cycle Options"
        '
        'rbCycleWithoutMotion
        '
        Me.rbCycleWithoutMotion.AutoSize = True
        Me.rbCycleWithoutMotion.ForeColor = System.Drawing.Color.Black
        Me.rbCycleWithoutMotion.Location = New System.Drawing.Point(224, 25)
        Me.rbCycleWithoutMotion.Name = "rbCycleWithoutMotion"
        Me.rbCycleWithoutMotion.Size = New System.Drawing.Size(129, 23)
        Me.rbCycleWithoutMotion.TabIndex = 0
        Me.rbCycleWithoutMotion.Text = "Without motion"
        Me.rbCycleWithoutMotion.UseVisualStyleBackColor = True
        '
        'rbCycleWithMotion
        '
        Me.rbCycleWithMotion.AutoSize = True
        Me.rbCycleWithMotion.Checked = True
        Me.rbCycleWithMotion.ForeColor = System.Drawing.Color.Black
        Me.rbCycleWithMotion.Location = New System.Drawing.Point(22, 25)
        Me.rbCycleWithMotion.Name = "rbCycleWithMotion"
        Me.rbCycleWithMotion.Size = New System.Drawing.Size(108, 23)
        Me.rbCycleWithMotion.TabIndex = 0
        Me.rbCycleWithMotion.TabStop = True
        Me.rbCycleWithMotion.Text = "With motion"
        Me.rbCycleWithMotion.UseVisualStyleBackColor = True
        '
        'btnStartATM
        '
        Me.btnStartATM.BackColor = System.Drawing.SystemColors.Control
        Me.btnStartATM.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnStartATM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStartATM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStartATM.FlatAppearance.BorderSize = 0
        Me.btnStartATM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartATM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartATM.Location = New System.Drawing.Point(161, 425)
        Me.btnStartATM.Name = "btnStartATM"
        Me.btnStartATM.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnStartATM.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnStartATM.Size = New System.Drawing.Size(127, 36)
        Me.btnStartATM.TabIndex = 9
        Me.btnStartATM.Text = "START"
        Me.btnStartATM.UseVisualStyleBackColor = False
        '
        'CycleATMPanel
        '
        Me.Controls.Add(Me.btnStartATM)
        Me.Controls.Add(Me.gbxCycleOptions)
        Me.Controls.Add(Me.gbxCyclePM)
        Me.Controls.Add(Me.gbxCycleLoadLock)
        Me.HeaderHeight = 32
        Me.Name = "CycleATMPanel"
        Me.Size = New System.Drawing.Size(464, 471)
        Me.Text = "Cycle ATM"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.gbxCycleLoadLock, 0)
        Me.Controls.SetChildIndex(Me.gbxCyclePM, 0)
        Me.Controls.SetChildIndex(Me.gbxCycleOptions, 0)
        Me.Controls.SetChildIndex(Me.btnStartATM, 0)
        Me.gbxCycleLoadLock.ResumeLayout(False)
        Me.gbxCycleLoadLock.PerformLayout()
        Me.gbxCyclePM.ResumeLayout(False)
        Me.gbxCyclePM.PerformLayout()
        Me.gbxCycleOptions.ResumeLayout(False)
        Me.gbxCycleOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbxCycleLoadLock As System.Windows.Forms.GroupBox
    Friend WithEvents rbCycleLLA As System.Windows.Forms.RadioButton
    Friend WithEvents gbxCyclePM As System.Windows.Forms.GroupBox
    Friend WithEvents lblAligner As System.Windows.Forms.Label
    Friend WithEvents cbxPM6 As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPM5 As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPM3 As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPM4 As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPM2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPM1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbAlignerRecipe As System.Windows.Forms.ComboBox
    Friend WithEvents gbxCycleOptions As System.Windows.Forms.GroupBox
    Friend WithEvents rbCycleWithoutMotion As System.Windows.Forms.RadioButton
    Friend WithEvents rbCycleWithMotion As System.Windows.Forms.RadioButton
    Friend WithEvents btnStartATM As AVPControls.AVPButton

End Class
