<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrAligner
    'Inherits System.Windows.Forms.UserControl
    ' Inherits AVP_Robot_Project.StatusBoard
    Inherits AVP_Robot_Project.StatusPanel
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.usrOperations = New AVP_Robot_Project.usrOperationsAligner
        Me.usrAlignmentInfo = New AVP_Robot_Project.usrAlignmentInfo
        Me.usrWaferInfo = New AVP_Robot_Project.usrWaferInfo
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 24.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1280, 50)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ALIGNER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'usrOperations
        '
        Me.usrOperations.BackColor = System.Drawing.Color.White
        Me.usrOperations.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.usrOperations.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usrOperations.ForeColor = System.Drawing.Color.Black
        Me.usrOperations.HeaderHeight = 28
        Me.usrOperations.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.usrOperations.HeaderTextColor = System.Drawing.Color.Black
        Me.usrOperations.HeaderVisible = False
        Me.usrOperations.IsOnline = False
        Me.usrOperations.Location = New System.Drawing.Point(860, 171)
        Me.usrOperations.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.usrOperations.Name = "usrOperations"
        Me.usrOperations.Size = New System.Drawing.Size(350, 245)
        Me.usrOperations.TabIndex = 2
        Me.usrOperations.Text = "Operations"
        Me.usrOperations.UseBorderStyle = True
        '
        'usrAlignmentInfo
        '
        Me.usrAlignmentInfo.BackColor = System.Drawing.Color.White
        Me.usrAlignmentInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.usrAlignmentInfo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usrAlignmentInfo.HeaderHeight = 28
        Me.usrAlignmentInfo.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.usrAlignmentInfo.HeaderTextColor = System.Drawing.Color.Black
        Me.usrAlignmentInfo.HeaderVisible = False
        Me.usrAlignmentInfo.Location = New System.Drawing.Point(380, 171)
        Me.usrAlignmentInfo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.usrAlignmentInfo.Name = "usrAlignmentInfo"
        Me.usrAlignmentInfo.Size = New System.Drawing.Size(460, 313)
        Me.usrAlignmentInfo.TabIndex = 1
        Me.usrAlignmentInfo.Text = "Alignment Information"
        Me.usrAlignmentInfo.UseBorderStyle = True
        '
        'usrWaferInfo
        '
        Me.usrWaferInfo.BackColor = System.Drawing.Color.White
        Me.usrWaferInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.usrWaferInfo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usrWaferInfo.HeaderHeight = 28
        Me.usrWaferInfo.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.usrWaferInfo.HeaderTextColor = System.Drawing.Color.Black
        Me.usrWaferInfo.HeaderVisible = False
        Me.usrWaferInfo.Location = New System.Drawing.Point(66, 171)
        Me.usrWaferInfo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.usrWaferInfo.Name = "usrWaferInfo"
        Me.usrWaferInfo.Size = New System.Drawing.Size(294, 185)
        Me.usrWaferInfo.TabIndex = 0
        Me.usrWaferInfo.Text = "Wafer Information"
        Me.usrWaferInfo.UseBorderStyle = True
        '
        'usrAligner
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.usrOperations)
        Me.Controls.Add(Me.usrAlignmentInfo)
        Me.Controls.Add(Me.usrWaferInfo)
        Me.Name = "usrAligner"
        Me.Size = New System.Drawing.Size(1280, 756)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents usrWaferInfo As AVP_Robot_Project.usrWaferInfo
    Friend WithEvents usrAlignmentInfo As AVP_Robot_Project.usrAlignmentInfo
    Friend WithEvents usrOperations As AVP_Robot_Project.usrOperationsAligner
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
