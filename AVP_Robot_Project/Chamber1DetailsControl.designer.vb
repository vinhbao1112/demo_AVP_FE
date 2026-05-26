<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chamber1DetailsControl
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
        Me.lblRecipe = New System.Windows.Forms.Label
        Me.txtDepPower = New System.Windows.Forms.TextBox
        Me.lblDepPower = New System.Windows.Forms.Label
        Me.txtCheckHeigh = New System.Windows.Forms.TextBox
        Me.lblChuckHeight = New System.Windows.Forms.Label
        Me.txtProcPressure = New System.Windows.Forms.TextBox
        Me.lblProcPressure = New System.Windows.Forms.Label
        Me.lblStepTime = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.txtStepTime = New System.Windows.Forms.TextBox
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.lblStepNumber = New System.Windows.Forms.Label
        Me.txtStepNumber = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtRecipe
        '
        Me.txtRecipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecipe.Location = New System.Drawing.Point(101, 31)
        Me.txtRecipe.Name = "txtRecipe"
        Me.txtRecipe.ReadOnly = True
        Me.txtRecipe.Size = New System.Drawing.Size(165, 26)
        Me.txtRecipe.TabIndex = 4
        '
        'lblRecipe
        '
        Me.lblRecipe.AutoSize = True
        Me.lblRecipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecipe.Location = New System.Drawing.Point(0, 31)
        Me.lblRecipe.Name = "lblRecipe"
        Me.lblRecipe.Size = New System.Drawing.Size(56, 19)
        Me.lblRecipe.TabIndex = 3
        Me.lblRecipe.Text = "Recipe"
        '
        'txtDepPower
        '
        Me.txtDepPower.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepPower.Location = New System.Drawing.Point(101, 63)
        Me.txtDepPower.Name = "txtDepPower"
        Me.txtDepPower.ReadOnly = True
        Me.txtDepPower.Size = New System.Drawing.Size(165, 26)
        Me.txtDepPower.TabIndex = 8
        '
        'lblDepPower
        '
        Me.lblDepPower.AutoSize = True
        Me.lblDepPower.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepPower.Location = New System.Drawing.Point(0, 64)
        Me.lblDepPower.Name = "lblDepPower"
        Me.lblDepPower.Size = New System.Drawing.Size(82, 19)
        Me.lblDepPower.TabIndex = 7
        Me.lblDepPower.Text = "Dep Power"
        '
        'txtCheckHeigh
        '
        Me.txtCheckHeigh.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckHeigh.Location = New System.Drawing.Point(101, 95)
        Me.txtCheckHeigh.Name = "txtCheckHeigh"
        Me.txtCheckHeigh.ReadOnly = True
        Me.txtCheckHeigh.Size = New System.Drawing.Size(165, 26)
        Me.txtCheckHeigh.TabIndex = 10
        '
        'lblChuckHeight
        '
        Me.lblChuckHeight.AutoSize = True
        Me.lblChuckHeight.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChuckHeight.Location = New System.Drawing.Point(-2, 97)
        Me.lblChuckHeight.Name = "lblChuckHeight"
        Me.lblChuckHeight.Size = New System.Drawing.Size(101, 19)
        Me.lblChuckHeight.TabIndex = 9
        Me.lblChuckHeight.Text = "Chuck Height"
        '
        'txtProcPressure
        '
        Me.txtProcPressure.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcPressure.Location = New System.Drawing.Point(101, 127)
        Me.txtProcPressure.Name = "txtProcPressure"
        Me.txtProcPressure.ReadOnly = True
        Me.txtProcPressure.Size = New System.Drawing.Size(165, 26)
        Me.txtProcPressure.TabIndex = 12
        '
        'lblProcPressure
        '
        Me.lblProcPressure.AutoSize = True
        Me.lblProcPressure.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcPressure.Location = New System.Drawing.Point(0, 130)
        Me.lblProcPressure.Name = "lblProcPressure"
        Me.lblProcPressure.Size = New System.Drawing.Size(102, 19)
        Me.lblProcPressure.TabIndex = 11
        Me.lblProcPressure.Text = "Proc Pressure"
        '
        'lblStepTime
        '
        Me.lblStepTime.AutoSize = True
        Me.lblStepTime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStepTime.Location = New System.Drawing.Point(0, 196)
        Me.lblStepTime.Name = "lblStepTime"
        Me.lblStepTime.Size = New System.Drawing.Size(77, 19)
        Me.lblStepTime.TabIndex = 14
        Me.lblStepTime.Text = "Step Time"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(0, 229)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(51, 19)
        Me.lblStatus.TabIndex = 15
        Me.lblStatus.Text = "Status"
        '
        'txtStepTime
        '
        Me.txtStepTime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStepTime.Location = New System.Drawing.Point(101, 191)
        Me.txtStepTime.Name = "txtStepTime"
        Me.txtStepTime.ReadOnly = True
        Me.txtStepTime.Size = New System.Drawing.Size(165, 26)
        Me.txtStepTime.TabIndex = 12
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(101, 223)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(165, 26)
        Me.txtStatus.TabIndex = 12
        '
        'lblStepNumber
        '
        Me.lblStepNumber.AutoSize = True
        Me.lblStepNumber.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStepNumber.Location = New System.Drawing.Point(-2, 163)
        Me.lblStepNumber.Name = "lblStepNumber"
        Me.lblStepNumber.Size = New System.Drawing.Size(97, 19)
        Me.lblStepNumber.TabIndex = 5
        Me.lblStepNumber.Text = "Step Number"
        '
        'txtStepNumber
        '
        Me.txtStepNumber.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStepNumber.Location = New System.Drawing.Point(101, 159)
        Me.txtStepNumber.Name = "txtStepNumber"
        Me.txtStepNumber.ReadOnly = True
        Me.txtStepNumber.Size = New System.Drawing.Size(165, 26)
        Me.txtStepNumber.TabIndex = 6
        '
        'Chamber1DetailsControl
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblStepTime)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtStepTime)
        Me.Controls.Add(Me.txtProcPressure)
        Me.Controls.Add(Me.lblProcPressure)
        Me.Controls.Add(Me.txtCheckHeigh)
        Me.Controls.Add(Me.lblChuckHeight)
        Me.Controls.Add(Me.txtDepPower)
        Me.Controls.Add(Me.lblDepPower)
        Me.Controls.Add(Me.txtStepNumber)
        Me.Controls.Add(Me.lblStepNumber)
        Me.Controls.Add(Me.txtRecipe)
        Me.Controls.Add(Me.lblRecipe)
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Chamber1DetailsControl"
        Me.Size = New System.Drawing.Size(270, 263)
        Me.Text = "Chamber"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.lblRecipe, 0)
        Me.Controls.SetChildIndex(Me.txtRecipe, 0)
        Me.Controls.SetChildIndex(Me.lblStepNumber, 0)
        Me.Controls.SetChildIndex(Me.txtStepNumber, 0)
        Me.Controls.SetChildIndex(Me.lblDepPower, 0)
        Me.Controls.SetChildIndex(Me.txtDepPower, 0)
        Me.Controls.SetChildIndex(Me.lblChuckHeight, 0)
        Me.Controls.SetChildIndex(Me.txtCheckHeigh, 0)
        Me.Controls.SetChildIndex(Me.lblProcPressure, 0)
        Me.Controls.SetChildIndex(Me.txtProcPressure, 0)
        Me.Controls.SetChildIndex(Me.txtStepTime, 0)
        Me.Controls.SetChildIndex(Me.txtStatus, 0)
        Me.Controls.SetChildIndex(Me.lblStepTime, 0)
        Me.Controls.SetChildIndex(Me.lblStatus, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRecipe As System.Windows.Forms.TextBox
    Friend WithEvents lblRecipe As System.Windows.Forms.Label
    Friend WithEvents txtDepPower As System.Windows.Forms.TextBox
    Friend WithEvents lblDepPower As System.Windows.Forms.Label
    Friend WithEvents txtCheckHeigh As System.Windows.Forms.TextBox
    Friend WithEvents lblChuckHeight As System.Windows.Forms.Label
    Friend WithEvents txtProcPressure As System.Windows.Forms.TextBox
    Friend WithEvents lblProcPressure As System.Windows.Forms.Label
    Friend WithEvents lblStepTime As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtStepTime As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblStepNumber As System.Windows.Forms.Label
    Friend WithEvents txtStepNumber As System.Windows.Forms.TextBox

End Class
