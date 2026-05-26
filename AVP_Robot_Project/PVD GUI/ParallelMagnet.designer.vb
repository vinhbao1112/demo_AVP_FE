<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParallelMagnet
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
        Me.txtCurrent = New AVP_Robot_Project.SL_Textbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtVoltage = New AVP_Robot_Project.SL_Textbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFrequencyRight = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDutyRight = New System.Windows.Forms.TextBox
        Me.txtCurrentRight = New AVP_Robot_Project.PVDTextbox
        Me.btnStatus = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Current (Amps)"
        '
        'txtCurrent
        '
        Me.txtCurrent.AccessibleName = "Current"
        Me.txtCurrent.AutoSendKeyTabWhenFinishInput = False
        Me.txtCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCurrent.Clickable = True
        Me.txtCurrent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCurrent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCurrent.GasName = ""
        Me.txtCurrent.IsNumericTextbox = False
        Me.txtCurrent.IsReadBack = True
        Me.txtCurrent.IsTurboPumpTextbox = False
        Me.txtCurrent.Location = New System.Drawing.Point(173, 34)
        Me.txtCurrent.Name = "txtCurrent"
        Me.txtCurrent.ReadOnly = True
        Me.txtCurrent.ShowUnitFormat = False
        Me.txtCurrent.Size = New System.Drawing.Size(70, 24)
        Me.txtCurrent.TabIndex = 9
        Me.txtCurrent.UnitTypeUsed = ""
        Me.txtCurrent.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtCurrent.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtCurrent.UseScientificFormat = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 19)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Duty (%)"
        '
        'txtVoltage
        '
        Me.txtVoltage.AccessibleName = "Duty"
        Me.txtVoltage.AutoSendKeyTabWhenFinishInput = False
        Me.txtVoltage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVoltage.Clickable = True
        Me.txtVoltage.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtVoltage.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtVoltage.GasName = ""
        Me.txtVoltage.IsNumericTextbox = False
        Me.txtVoltage.IsReadBack = True
        Me.txtVoltage.IsTurboPumpTextbox = False
        Me.txtVoltage.Location = New System.Drawing.Point(173, 106)
        Me.txtVoltage.Name = "txtVoltage"
        Me.txtVoltage.ReadOnly = True
        Me.txtVoltage.ShowUnitFormat = False
        Me.txtVoltage.Size = New System.Drawing.Size(70, 24)
        Me.txtVoltage.TabIndex = 12
        Me.txtVoltage.UnitTypeUsed = ""
        Me.txtVoltage.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtVoltage.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtVoltage.UseScientificFormat = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 19)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Frequency (Hz)"
        '
        'txtFrequencyRight
        '
        Me.txtFrequencyRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtFrequencyRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtFrequencyRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtFrequencyRight.Location = New System.Drawing.Point(245, 82)
        Me.txtFrequencyRight.Name = "txtFrequencyRight"
        Me.txtFrequencyRight.ReadOnly = True
        Me.txtFrequencyRight.Size = New System.Drawing.Size(70, 24)
        Me.txtFrequencyRight.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 19)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Voltage"
        '
        'txtDutyRight
        '
        Me.txtDutyRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtDutyRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtDutyRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtDutyRight.Location = New System.Drawing.Point(245, 58)
        Me.txtDutyRight.Name = "txtDutyRight"
        Me.txtDutyRight.ReadOnly = True
        Me.txtDutyRight.Size = New System.Drawing.Size(70, 24)
        Me.txtDutyRight.TabIndex = 13
        '
        'txtCurrentRight
        '
        Me.txtCurrentRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtCurrentRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCurrentRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentRight.Location = New System.Drawing.Point(245, 34)
        Me.txtCurrentRight.Name = "txtCurrentRight"
        Me.txtCurrentRight.ReadOnly = True
        Me.txtCurrentRight.Size = New System.Drawing.Size(70, 24)
        Me.txtCurrentRight.TabIndex = 13
        Me.txtCurrentRight.UseBackGroundWorkerToUpdateMinMax = True
        '
        'btnStatus
        '
        Me.btnStatus.BackColor = System.Drawing.Color.Transparent
        Me.btnStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnStatus.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnStatus.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnStatus.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnStatus.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.btnStatus.ErrorText = ""
        Me.btnStatus.FlatAppearance.BorderSize = 3
        Me.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStatus.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStatus.ForeColor = System.Drawing.Color.Black
        Me.btnStatus.Location = New System.Drawing.Point(252, 3)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.btnStatus.OffText = ""
        Me.btnStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_On
        Me.btnStatus.OnText = ""
        Me.btnStatus.Size = New System.Drawing.Size(61, 27)
        Me.btnStatus.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.btnStatus.StyleOfButton = ButtonStyle.Horizontal
        Me.btnStatus.TabIndex = 15
        Me.btnStatus.Text = "On/Off"
        Me.btnStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnStatus.UnKnownText = ""
        Me.btnStatus.UseVisualStyleBackColor = False
        '
        'ParallelMagnet
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnStatus)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCurrent)
        Me.Controls.Add(Me.txtCurrentRight)
        Me.Controls.Add(Me.txtDutyRight)
        Me.Controls.Add(Me.txtFrequencyRight)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtVoltage)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "ParallelMagnet"
        Me.Size = New System.Drawing.Size(325, 135)
        Me.Text = "Parallel Magnet"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtVoltage, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtFrequencyRight, 0)
        Me.Controls.SetChildIndex(Me.txtDutyRight, 0)
        Me.Controls.SetChildIndex(Me.txtCurrentRight, 0)
        Me.Controls.SetChildIndex(Me.txtCurrent, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.btnStatus, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCurrent As SL_Textbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVoltage As SL_Textbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFrequencyRight As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDutyRight As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentRight As AVP_Robot_Project.PVDTextbox
    Friend WithEvents btnStatus As AVP_Robot_Project.ButtonIGCGControl

End Class
