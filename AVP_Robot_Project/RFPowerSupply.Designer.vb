<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RFPowerSupply
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
        Me.txtForwardPower1 = New System.Windows.Forms.TextBox
        Me.txtForwardPowerRight = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtReflectedPower = New System.Windows.Forms.TextBox
        Me.txtReflectedPowerRight = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Forward Power (W)"
        '
        'txtForwardPower1
        '
        Me.txtForwardPower1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForwardPower1.Location = New System.Drawing.Point(147, 54)
        Me.txtForwardPower1.Name = "txtForwardPower1"
        Me.txtForwardPower1.ReadOnly = True
        Me.txtForwardPower1.Size = New System.Drawing.Size(70, 22)
        Me.txtForwardPower1.TabIndex = 8
        '
        'txtForwardPowerRight
        '
        Me.txtForwardPowerRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtForwardPowerRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtForwardPowerRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForwardPowerRight.Location = New System.Drawing.Point(226, 54)
        Me.txtForwardPowerRight.Name = "txtForwardPowerRight"
        Me.txtForwardPowerRight.ReadOnly = True
        Me.txtForwardPowerRight.Size = New System.Drawing.Size(70, 22)
        Me.txtForwardPowerRight.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Reflected Power (W)"
        '
        'txtReflectedPower
        '
        Me.txtReflectedPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReflectedPower.Location = New System.Drawing.Point(147, 84)
        Me.txtReflectedPower.Name = "txtReflectedPower"
        Me.txtReflectedPower.ReadOnly = True
        Me.txtReflectedPower.Size = New System.Drawing.Size(70, 22)
        Me.txtReflectedPower.TabIndex = 11
        '
        'txtReflectedPowerRight
        '
        Me.txtReflectedPowerRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtReflectedPowerRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtReflectedPowerRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReflectedPowerRight.Location = New System.Drawing.Point(226, 85)
        Me.txtReflectedPowerRight.Name = "txtReflectedPowerRight"
        Me.txtReflectedPowerRight.ReadOnly = True
        Me.txtReflectedPowerRight.Size = New System.Drawing.Size(70, 22)
        Me.txtReflectedPowerRight.TabIndex = 11
        '
        'RFPowerSupply
        '
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtReflectedPowerRight)
        Me.Controls.Add(Me.txtReflectedPower)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtForwardPowerRight)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtForwardPower1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "RFPowerSupply"
        Me.Size = New System.Drawing.Size(300, 141)
        Me.Text = "RF Power Supply"
        Me.Controls.SetChildIndex(Me.txtForwardPower1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtForwardPowerRight, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtReflectedPower, 0)
        Me.Controls.SetChildIndex(Me.txtReflectedPowerRight, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtForwardPower1 As System.Windows.Forms.TextBox
    Friend WithEvents txtForwardPowerRight As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtReflectedPower As System.Windows.Forms.TextBox
    Friend WithEvents txtReflectedPowerRight As System.Windows.Forms.TextBox

End Class
