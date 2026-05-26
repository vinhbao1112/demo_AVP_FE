<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chamber3DetailsControl
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
        Me.txtRecipe = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtGas1Argon = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtGas2O2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDepPressure = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTargetPower = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSourcePower = New System.Windows.Forms.TextBox
        Me.txtRatationSpeed = New System.Windows.Forms.TextBox
        Me.txtTiltAngle = New System.Windows.Forms.TextBox
        Me.txtProcessStep = New System.Windows.Forms.TextBox
        Me.txtStepTime = New System.Windows.Forms.TextBox
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtRecipe
        '
        Me.txtRecipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecipe.Location = New System.Drawing.Point(111, 28)
        Me.txtRecipe.Name = "txtRecipe"
        Me.txtRecipe.ReadOnly = True
        Me.txtRecipe.Size = New System.Drawing.Size(165, 26)
        Me.txtRecipe.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Recipe"
        '
        'txtGas1Argon
        '
        Me.txtGas1Argon.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGas1Argon.Location = New System.Drawing.Point(111, 54)
        Me.txtGas1Argon.Name = "txtGas1Argon"
        Me.txtGas1Argon.ReadOnly = True
        Me.txtGas1Argon.Size = New System.Drawing.Size(165, 26)
        Me.txtGas1Argon.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 19)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Gas 1: Argon"
        '
        'txtGas2O2
        '
        Me.txtGas2O2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGas2O2.Location = New System.Drawing.Point(111, 80)
        Me.txtGas2O2.Name = "txtGas2O2"
        Me.txtGas2O2.ReadOnly = True
        Me.txtGas2O2.Size = New System.Drawing.Size(165, 26)
        Me.txtGas2O2.TabIndex = 8
        Me.txtGas2O2.Text = " "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 19)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Gas 2: O2"
        '
        'txtDepPressure
        '
        Me.txtDepPressure.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepPressure.Location = New System.Drawing.Point(111, 106)
        Me.txtDepPressure.Name = "txtDepPressure"
        Me.txtDepPressure.ReadOnly = True
        Me.txtDepPressure.Size = New System.Drawing.Size(165, 26)
        Me.txtDepPressure.TabIndex = 10
        Me.txtDepPressure.Text = "  "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 19)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Dep. Pressure"
        '
        'txtTargetPower
        '
        Me.txtTargetPower.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTargetPower.Location = New System.Drawing.Point(111, 132)
        Me.txtTargetPower.Name = "txtTargetPower"
        Me.txtTargetPower.ReadOnly = True
        Me.txtTargetPower.Size = New System.Drawing.Size(165, 26)
        Me.txtTargetPower.TabIndex = 12
        Me.txtTargetPower.Text = "    "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 19)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "  "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 19)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Target Power"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 19)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Source Power"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 186)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 19)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Rotation Speed"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 19)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Tilt Angle"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 238)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 19)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Process Step"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 264)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 19)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Step Time"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 290)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 19)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Status"
        '
        'txtSourcePower
        '
        Me.txtSourcePower.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSourcePower.Location = New System.Drawing.Point(111, 158)
        Me.txtSourcePower.Name = "txtSourcePower"
        Me.txtSourcePower.ReadOnly = True
        Me.txtSourcePower.Size = New System.Drawing.Size(165, 26)
        Me.txtSourcePower.TabIndex = 12
        Me.txtSourcePower.Text = "    "
        '
        'txtRatationSpeed
        '
        Me.txtRatationSpeed.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRatationSpeed.Location = New System.Drawing.Point(111, 184)
        Me.txtRatationSpeed.Name = "txtRatationSpeed"
        Me.txtRatationSpeed.ReadOnly = True
        Me.txtRatationSpeed.Size = New System.Drawing.Size(165, 26)
        Me.txtRatationSpeed.TabIndex = 12
        Me.txtRatationSpeed.Text = "    "
        '
        'txtTiltAngle
        '
        Me.txtTiltAngle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiltAngle.Location = New System.Drawing.Point(111, 210)
        Me.txtTiltAngle.Name = "txtTiltAngle"
        Me.txtTiltAngle.ReadOnly = True
        Me.txtTiltAngle.Size = New System.Drawing.Size(165, 26)
        Me.txtTiltAngle.TabIndex = 12
        Me.txtTiltAngle.Text = "    "
        '
        'txtProcessStep
        '
        Me.txtProcessStep.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessStep.Location = New System.Drawing.Point(111, 236)
        Me.txtProcessStep.Name = "txtProcessStep"
        Me.txtProcessStep.ReadOnly = True
        Me.txtProcessStep.Size = New System.Drawing.Size(165, 26)
        Me.txtProcessStep.TabIndex = 12
        Me.txtProcessStep.Text = "    "
        '
        'txtStepTime
        '
        Me.txtStepTime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStepTime.Location = New System.Drawing.Point(111, 262)
        Me.txtStepTime.Name = "txtStepTime"
        Me.txtStepTime.ReadOnly = True
        Me.txtStepTime.Size = New System.Drawing.Size(165, 26)
        Me.txtStepTime.TabIndex = 12
        Me.txtStepTime.Text = "    "
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(111, 288)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(165, 26)
        Me.txtStatus.TabIndex = 12
        Me.txtStatus.Text = "    "
        '
        'Chamber3DetailsControl
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtStepTime)
        Me.Controls.Add(Me.txtProcessStep)
        Me.Controls.Add(Me.txtTiltAngle)
        Me.Controls.Add(Me.txtRatationSpeed)
        Me.Controls.Add(Me.txtSourcePower)
        Me.Controls.Add(Me.txtTargetPower)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDepPressure)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtGas2O2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtGas1Argon)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRecipe)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Chamber3DetailsControl"
        Me.Size = New System.Drawing.Size(284, 318)
        Me.Text = "Chamber "
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtRecipe, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtGas1Argon, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtGas2O2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtDepPressure, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtTargetPower, 0)
        Me.Controls.SetChildIndex(Me.txtSourcePower, 0)
        Me.Controls.SetChildIndex(Me.txtRatationSpeed, 0)
        Me.Controls.SetChildIndex(Me.txtTiltAngle, 0)
        Me.Controls.SetChildIndex(Me.txtProcessStep, 0)
        Me.Controls.SetChildIndex(Me.txtStepTime, 0)
        Me.Controls.SetChildIndex(Me.txtStatus, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRecipe As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGas1Argon As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGas2O2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDepPressure As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTargetPower As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSourcePower As System.Windows.Forms.TextBox
    Friend WithEvents txtRatationSpeed As System.Windows.Forms.TextBox
    Friend WithEvents txtTiltAngle As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessStep As System.Windows.Forms.TextBox
    Friend WithEvents txtStepTime As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox

End Class
