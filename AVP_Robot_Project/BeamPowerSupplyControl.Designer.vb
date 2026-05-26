<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BeamPowerSupplyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BeamPowerSupplyControl))
        Me.txtVoltageRight = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtVoltage1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCurrent = New System.Windows.Forms.TextBox
        Me.btnSuppressor = New System.Windows.Forms.Button
        Me.txtCurrentRight = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAutoBeam = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Current (A)"
        '
        'txtCurrent
        '
        Me.txtCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrent.Location = New System.Drawing.Point(147, 84)
        Me.txtCurrent.Name = "txtCurrent"
        Me.txtCurrent.ReadOnly = True
        Me.txtCurrent.Size = New System.Drawing.Size(70, 22)
        Me.txtCurrent.TabIndex = 15
        '
        'btnSuppressor
        '
        Me.btnSuppressor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSuppressor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSuppressor.Location = New System.Drawing.Point(178, 10)
        Me.btnSuppressor.Name = "btnSuppressor"
        Me.btnSuppressor.Size = New System.Drawing.Size(96, 23)
        Me.btnSuppressor.TabIndex = 7
        Me.btnSuppressor.Text = "Suppressor"
        Me.btnSuppressor.UseVisualStyleBackColor = True
        Me.btnSuppressor.Visible = False
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Auto Beam"
        '
        'btnAutoBeam
        '
        Me.btnAutoBeam.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower_Off
        Me.btnAutoBeam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoBeam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoBeam.ErrorImage = Nothing
        Me.btnAutoBeam.ErrorText = ""
        Me.btnAutoBeam.FlatAppearance.BorderSize = 0
        Me.btnAutoBeam.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAutoBeam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoBeam.ForeColor = System.Drawing.Color.White
        Me.btnAutoBeam.Location = New System.Drawing.Point(147, 112)
        Me.btnAutoBeam.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAutoBeam.Name = "btnAutoBeam"
        Me.btnAutoBeam.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower_Off
        Me.btnAutoBeam.OffText = ""
        Me.btnAutoBeam.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower
        Me.btnAutoBeam.OnText = ""
        Me.btnAutoBeam.Size = New System.Drawing.Size(148, 32)
        Me.btnAutoBeam.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.btnAutoBeam.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.btnAutoBeam.TabIndex = 29
        Me.btnAutoBeam.Text = "Enable Auto Beam"
        Me.btnAutoBeam.UnknownImage = Nothing
        Me.btnAutoBeam.UnKnownText = ""
        Me.btnAutoBeam.UseVisualStyleBackColor = True
        '
        'BeamPowerSupplyControl
        '
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnAutoBeam)
        Me.Controls.Add(Me.btnSuppressor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCurrent)
        Me.Controls.Add(Me.txtCurrentRight)
        Me.Controls.Add(Me.txtVoltageRight)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtVoltage1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderHeight = 28
        Me.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "BeamPowerSupplyControl"
        Me.Size = New System.Drawing.Size(300, 152)
        Me.Text = "Bean Power Supply"
        Me.Controls.SetChildIndex(Me.txtVoltage1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtVoltageRight, 0)
        Me.Controls.SetChildIndex(Me.txtCurrentRight, 0)
        Me.Controls.SetChildIndex(Me.txtCurrent, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnSuppressor, 0)
        Me.Controls.SetChildIndex(Me.btnAutoBeam, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVoltageRight As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVoltage1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCurrent As System.Windows.Forms.TextBox
    Friend WithEvents btnSuppressor As System.Windows.Forms.Button
    Friend WithEvents txtCurrentRight As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAutoBeam As AVP_Robot_Project.ButtonIGCGControl

End Class
