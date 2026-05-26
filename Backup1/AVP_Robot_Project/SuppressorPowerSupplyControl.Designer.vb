<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuppressorPowerSupplyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SuppressorPowerSupplyControl))
        Me.txtVoltageRight = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtVoltage1 = New System.Windows.Forms.TextBox
        Me.btnBeam = New System.Windows.Forms.Button
        Me.txtCurrent = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCurrentRight = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = CType(resources.GetObject("Header.BackgroundImage"), System.Drawing.Image)
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.Size = New System.Drawing.Size(300, 27)
        Me.Header.Status = AVP_Robot_Project.DisplayStatus.[On]
        Me.Header.Text = "Suppressor Power Supply"
        '
        'txtVoltageRight
        '
        Me.txtVoltageRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtVoltageRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtVoltageRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVoltageRight.Location = New System.Drawing.Point(226, 54)
        Me.txtVoltageRight.Name = "txtVoltageRight"
        Me.txtVoltageRight.ReadOnly = True
        Me.txtVoltageRight.Size = New System.Drawing.Size(70, 22)
        Me.txtVoltageRight.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Voltage (V)"
        '
        'txtVoltage1
        '
        Me.txtVoltage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVoltage1.Location = New System.Drawing.Point(147, 54)
        Me.txtVoltage1.Name = "txtVoltage1"
        Me.txtVoltage1.ReadOnly = True
        Me.txtVoltage1.Size = New System.Drawing.Size(70, 22)
        Me.txtVoltage1.TabIndex = 12
        '
        'btnBeam
        '
        Me.btnBeam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBeam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBeam.Location = New System.Drawing.Point(216, 10)
        Me.btnBeam.Name = "btnBeam"
        Me.btnBeam.Size = New System.Drawing.Size(58, 23)
        Me.btnBeam.TabIndex = 7
        Me.btnBeam.Text = "Beam"
        Me.btnBeam.UseVisualStyleBackColor = True
        Me.btnBeam.Visible = False
        '
        'txtCurrent
        '
        Me.txtCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrent.Location = New System.Drawing.Point(147, 84)
        Me.txtCurrent.Name = "txtCurrent"
        Me.txtCurrent.ReadOnly = True
        Me.txtCurrent.Size = New System.Drawing.Size(70, 22)
        Me.txtCurrent.TabIndex = 12
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
        'txtCurrentRight
        '
        Me.txtCurrentRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtCurrentRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCurrentRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentRight.Location = New System.Drawing.Point(226, 85)
        Me.txtCurrentRight.Name = "txtCurrentRight"
        Me.txtCurrentRight.ReadOnly = True
        Me.txtCurrentRight.Size = New System.Drawing.Size(70, 22)
        Me.txtCurrentRight.TabIndex = 13
        '
        'SuppressorPowerSupplyControl
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnBeam)
        Me.Controls.Add(Me.txtCurrentRight)
        Me.Controls.Add(Me.txtVoltageRight)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCurrent)
        Me.Controls.Add(Me.txtVoltage1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "SuppressorPowerSupplyControl"
        Me.Size = New System.Drawing.Size(300, 141)
        Me.Text = "Suppressor Power Supply"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.txtVoltage1, 0)
        Me.Controls.SetChildIndex(Me.txtCurrent, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtVoltageRight, 0)
        Me.Controls.SetChildIndex(Me.txtCurrentRight, 0)
        Me.Controls.SetChildIndex(Me.btnBeam, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVoltageRight As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVoltage1 As System.Windows.Forms.TextBox
    Friend WithEvents btnBeam As System.Windows.Forms.Button
    Friend WithEvents txtCurrent As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCurrentRight As System.Windows.Forms.TextBox

End Class
