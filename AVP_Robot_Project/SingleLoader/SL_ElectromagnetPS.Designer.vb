<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_ElectromagnetPS
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
        Me.txtSourceEMCurrent = New AVP_Robot_Project.SL_Textbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSourceEMVolt = New AVP_Robot_Project.SL_Textbox
        Me.txtSourceEMVoltRight = New AVP_Robot_Project.SL_Textbox
        Me.txtSourceEMCurrentRight = New AVP_Robot_Project.SL_Textbox
        Me.SourceEMStatus = New AVP_Robot_Project.SL_CustomButton
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Size = New System.Drawing.Size(331, 27)
        Me.Header.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.Header.TabStop = False
        Me.Header.Text = "Electromagnet Power Supply"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'txtSourceEMCurrent
        '
        Me.txtSourceEMCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSourceEMCurrent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSourceEMCurrent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSourceEMCurrent.IsReadBack = True
        Me.txtSourceEMCurrent.Location = New System.Drawing.Point(169, 56)
        Me.txtSourceEMCurrent.Name = "txtSourceEMCurrent"
        Me.txtSourceEMCurrent.ReadOnly = True
        Me.txtSourceEMCurrent.Size = New System.Drawing.Size(71, 24)
        Me.txtSourceEMCurrent.TabIndex = 77
        Me.txtSourceEMCurrent.TabStop = False
        Me.txtSourceEMCurrent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSourceEMCurrent.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Three_Digits
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 16)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Source E.M Volt (V)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 16)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Source E.M Curr (A)"
        '
        'txtSourceEMVolt
        '
        Me.txtSourceEMVolt.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSourceEMVolt.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSourceEMVolt.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSourceEMVolt.IsReadBack = True
        Me.txtSourceEMVolt.Location = New System.Drawing.Point(169, 32)
        Me.txtSourceEMVolt.Name = "txtSourceEMVolt"
        Me.txtSourceEMVolt.ReadOnly = True
        Me.txtSourceEMVolt.Size = New System.Drawing.Size(71, 24)
        Me.txtSourceEMVolt.TabIndex = 75
        Me.txtSourceEMVolt.TabStop = False
        Me.txtSourceEMVolt.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSourceEMVolt.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtSourceEMVoltRight
        '
        Me.txtSourceEMVoltRight.AccessibleDescription = ""
        Me.txtSourceEMVoltRight.AccessibleName = "SourceEMVoltage"
        Me.txtSourceEMVoltRight.AutoSendKeyTabWhenFinishInput = True
        Me.txtSourceEMVoltRight.BackColor = System.Drawing.Color.White
        Me.txtSourceEMVoltRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSourceEMVoltRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSourceEMVoltRight.IsNumericTextbox = True
        Me.txtSourceEMVoltRight.Location = New System.Drawing.Point(246, 32)
        Me.txtSourceEMVoltRight.Multiline = True
        Me.txtSourceEMVoltRight.Name = "txtSourceEMVoltRight"
        Me.txtSourceEMVoltRight.ReadOnly = True
        Me.txtSourceEMVoltRight.Size = New System.Drawing.Size(71, 24)
        Me.txtSourceEMVoltRight.TabIndex = 1
        Me.txtSourceEMVoltRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSourceEMVoltRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtSourceEMVoltRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtSourceEMVoltRight.Visible = False
        '
        'txtSourceEMCurrentRight
        '
        Me.txtSourceEMCurrentRight.AccessibleDescription = ""
        Me.txtSourceEMCurrentRight.AccessibleName = "SourceEMCurrent"
        Me.txtSourceEMCurrentRight.AutoSendKeyTabWhenFinishInput = True
        Me.txtSourceEMCurrentRight.BackColor = System.Drawing.Color.White
        Me.txtSourceEMCurrentRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSourceEMCurrentRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSourceEMCurrentRight.IsNumericTextbox = True
        Me.txtSourceEMCurrentRight.Location = New System.Drawing.Point(246, 56)
        Me.txtSourceEMCurrentRight.Multiline = True
        Me.txtSourceEMCurrentRight.Name = "txtSourceEMCurrentRight"
        Me.txtSourceEMCurrentRight.ReadOnly = True
        Me.txtSourceEMCurrentRight.Size = New System.Drawing.Size(71, 24)
        Me.txtSourceEMCurrentRight.TabIndex = 2
        Me.txtSourceEMCurrentRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSourceEMCurrentRight.UseBackGroundWorkerToUpdateMinMax = True
        Me.txtSourceEMCurrentRight.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Three_Digits
        '
        'SourceEMStatus
        '
        Me.SourceEMStatus.BackColor = System.Drawing.Color.Transparent
        Me.SourceEMStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.SourceEMStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SourceEMStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.SourceEMStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDRed
        Me.SourceEMStatus.FlatAppearance.BorderSize = 0
        Me.SourceEMStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SourceEMStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SourceEMStatus.ForeColor = System.Drawing.Color.White
        Me.SourceEMStatus.Location = New System.Drawing.Point(148, 49)
        Me.SourceEMStatus.MessageBoxText = Nothing
        Me.SourceEMStatus.Name = "SourceEMStatus"
        Me.SourceEMStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGrey
        Me.SourceEMStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDGreen
        Me.SourceEMStatus.Size = New System.Drawing.Size(15, 15)
        Me.SourceEMStatus.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.SourceEMStatus.TabIndex = 129
        Me.SourceEMStatus.TabStop = False
        Me.SourceEMStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.SourceEMStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.LEDYellow
        Me.SourceEMStatus.UseVisualStyleBackColor = False
        Me.SourceEMStatus.ValueToBeSend = "On"
        Me.SourceEMStatus.Visible = False
        '
        'SL_ElectromagnetPS
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.SourceEMStatus)
        Me.Controls.Add(Me.txtSourceEMCurrentRight)
        Me.Controls.Add(Me.txtSourceEMVoltRight)
        Me.Controls.Add(Me.txtSourceEMCurrent)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSourceEMVolt)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.On
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "SL_ElectromagnetPS"
        Me.Size = New System.Drawing.Size(331, 86)
        Me.Text = "Electromagnet Power Supply"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtSourceEMVolt, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtSourceEMCurrent, 0)
        Me.Controls.SetChildIndex(Me.txtSourceEMVoltRight, 0)
        Me.Controls.SetChildIndex(Me.txtSourceEMCurrentRight, 0)
        Me.Controls.SetChildIndex(Me.SourceEMStatus, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSourceEMCurrent As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSourceEMVolt As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSourceEMVoltRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSourceEMCurrentRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents SourceEMStatus As AVP_Robot_Project.SL_CustomButton

End Class

