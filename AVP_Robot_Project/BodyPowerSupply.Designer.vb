<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BodyPowerSupply
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBodyCurrent = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDischargeCurrent = New System.Windows.Forms.TextBox
        Me.txtKFactor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtKFactorRight = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Current (A)"
        '
        'txtBodyCurrent
        '
        Me.txtBodyCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBodyCurrent.Location = New System.Drawing.Point(147, 54)
        Me.txtBodyCurrent.Name = "txtBodyCurrent"
        Me.txtBodyCurrent.ReadOnly = True
        Me.txtBodyCurrent.Size = New System.Drawing.Size(70, 22)
        Me.txtBodyCurrent.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Current (A)"
        '
        'txtDischargeCurrent
        '
        Me.txtDischargeCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDischargeCurrent.Location = New System.Drawing.Point(147, 84)
        Me.txtDischargeCurrent.Name = "txtDischargeCurrent"
        Me.txtDischargeCurrent.ReadOnly = True
        Me.txtDischargeCurrent.Size = New System.Drawing.Size(70, 22)
        Me.txtDischargeCurrent.TabIndex = 12
        '
        'txtKFactor
        '
        Me.txtKFactor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKFactor.Location = New System.Drawing.Point(147, 112)
        Me.txtKFactor.Name = "txtKFactor"
        Me.txtKFactor.ReadOnly = True
        Me.txtKFactor.Size = New System.Drawing.Size(70, 22)
        Me.txtKFactor.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "K Factor"
        '
        'txtKFactorRight
        '
        Me.txtKFactorRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtKFactorRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtKFactorRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKFactorRight.Location = New System.Drawing.Point(227, 112)
        Me.txtKFactorRight.Name = "txtKFactorRight"
        Me.txtKFactorRight.ReadOnly = True
        Me.txtKFactorRight.Size = New System.Drawing.Size(70, 22)
        Me.txtKFactorRight.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(217, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "(Body)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(216, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "(Filament)"
        '
        'BodyPowerSupply
        '
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBodyCurrent)
        Me.Controls.Add(Me.txtKFactorRight)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtKFactor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDischargeCurrent)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "BodyPowerSupply"
        Me.Size = New System.Drawing.Size(300, 141)
        Me.Text = "Body - Filament Power Supply"
        Me.Controls.SetChildIndex(Me.txtDischargeCurrent, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtKFactor, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtKFactorRight, 0)
        Me.Controls.SetChildIndex(Me.txtBodyCurrent, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBodyCurrent As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDischargeCurrent As System.Windows.Forms.TextBox
    Friend WithEvents txtKFactor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtKFactorRight As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
