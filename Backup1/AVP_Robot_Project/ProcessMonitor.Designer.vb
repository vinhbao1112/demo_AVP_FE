<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessMonitor
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
        Me.txtRecipe = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtWaferID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtRemainingTime = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtProcessStep = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtStepTime = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.txtElapsedTime = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTotalStep = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-1, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 19)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Recipe"
        '
        'txtRecipe
        '
        Me.txtRecipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecipe.Location = New System.Drawing.Point(110, 46)
        Me.txtRecipe.Name = "txtRecipe"
        Me.txtRecipe.ReadOnly = True
        Me.txtRecipe.Size = New System.Drawing.Size(79, 26)
        Me.txtRecipe.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-1, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 19)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Wafer ID"
        '
        'txtWaferID
        '
        Me.txtWaferID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWaferID.Location = New System.Drawing.Point(110, 73)
        Me.txtWaferID.Name = "txtWaferID"
        Me.txtWaferID.ReadOnly = True
        Me.txtWaferID.Size = New System.Drawing.Size(79, 26)
        Me.txtWaferID.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(-3, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 19)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Remaining Time"
        '
        'txtRemainingTime
        '
        Me.txtRemainingTime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemainingTime.Location = New System.Drawing.Point(110, 100)
        Me.txtRemainingTime.Name = "txtRemainingTime"
        Me.txtRemainingTime.ReadOnly = True
        Me.txtRemainingTime.Size = New System.Drawing.Size(79, 26)
        Me.txtRemainingTime.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(-1, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 19)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Process Step"
        '
        'txtProcessStep
        '
        Me.txtProcessStep.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessStep.Location = New System.Drawing.Point(110, 156)
        Me.txtProcessStep.Name = "txtProcessStep"
        Me.txtProcessStep.ReadOnly = True
        Me.txtProcessStep.Size = New System.Drawing.Size(79, 26)
        Me.txtProcessStep.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(-1, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 19)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Step Time"
        '
        'txtStepTime
        '
        Me.txtStepTime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStepTime.Location = New System.Drawing.Point(110, 183)
        Me.txtStepTime.Name = "txtStepTime"
        Me.txtStepTime.ReadOnly = True
        Me.txtStepTime.Size = New System.Drawing.Size(79, 26)
        Me.txtStepTime.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 213)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 19)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(110, 210)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(79, 26)
        Me.txtStatus.TabIndex = 33
        '
        'txtElapsedTime
        '
        Me.txtElapsedTime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtElapsedTime.Location = New System.Drawing.Point(110, 129)
        Me.txtElapsedTime.Name = "txtElapsedTime"
        Me.txtElapsedTime.ReadOnly = True
        Me.txtElapsedTime.Size = New System.Drawing.Size(79, 26)
        Me.txtElapsedTime.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(-1, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 19)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Elapsed Time"
        '
        'txtTotalStep
        '
        Me.txtTotalStep.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalStep.Location = New System.Drawing.Point(88, 159)
        Me.txtTotalStep.Name = "txtTotalStep"
        Me.txtTotalStep.ReadOnly = True
        Me.txtTotalStep.Size = New System.Drawing.Size(16, 26)
        Me.txtTotalStep.TabIndex = 25
        Me.txtTotalStep.Visible = False
        '
        'ProcessMonitor
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtStepTime)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtElapsedTime)
        Me.Controls.Add(Me.txtTotalStep)
        Me.Controls.Add(Me.txtProcessStep)
        Me.Controls.Add(Me.txtRemainingTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtWaferID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRecipe)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderStatus = DisplayStatus.On
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "ProcessMonitor"
        Me.Size = New System.Drawing.Size(192, 237)
        Me.Text = "Process Monitor"
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtRecipe, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtWaferID, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtRemainingTime, 0)
        Me.Controls.SetChildIndex(Me.txtProcessStep, 0)
        Me.Controls.SetChildIndex(Me.txtTotalStep, 0)
        Me.Controls.SetChildIndex(Me.txtElapsedTime, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtStepTime, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtStatus, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRecipe As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWaferID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRemainingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtProcessStep As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtStepTime As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtElapsedTime As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalStep As System.Windows.Forms.TextBox

End Class
