<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_ChillerControl
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
        Me.txtChillerTempRB = New AVP_Robot_Project.SL_Textbox
        Me.txtChillerTempSP = New AVP_Robot_Project.SL_Textbox
        Me.btnChillerOnOff = New AVP_Robot_Project.SL_CustomButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtChillerFlowRateRB = New AVP_Robot_Project.SL_Textbox
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
        Me.Header.Size = New System.Drawing.Size(256, 27)
        Me.Header.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.Header.Text = "Chiller"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'txtChillerTempRB
        '
        Me.txtChillerTempRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtChillerTempRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtChillerTempRB.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtChillerTempRB.IsReadBack = True
        Me.txtChillerTempRB.Location = New System.Drawing.Point(106, 31)
        Me.txtChillerTempRB.Name = "txtChillerTempRB"
        Me.txtChillerTempRB.ReadOnly = True
        Me.txtChillerTempRB.Size = New System.Drawing.Size(70, 24)
        Me.txtChillerTempRB.TabIndex = 200
        Me.txtChillerTempRB.TabStop = False
        Me.txtChillerTempRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtChillerTempRB.UnitTypeUsed = "C"
        Me.txtChillerTempRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtChillerTempSP
        '
        Me.txtChillerTempSP.BackColor = System.Drawing.Color.White
        Me.txtChillerTempSP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtChillerTempSP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtChillerTempSP.IsNumericTextbox = True
        Me.txtChillerTempSP.Location = New System.Drawing.Point(180, 31)
        Me.txtChillerTempSP.Name = "txtChillerTempSP"
        Me.txtChillerTempSP.ReadOnly = True
        Me.txtChillerTempSP.Size = New System.Drawing.Size(70, 24)
        Me.txtChillerTempSP.TabIndex = 200
        Me.txtChillerTempSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtChillerTempSP.UnitTypeUsed = "C"
        Me.txtChillerTempSP.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'btnChillerOnOff
        '
        Me.btnChillerOnOff.AccessibleName = "ChillerOnOff"
        Me.btnChillerOnOff.BackColor = System.Drawing.Color.Transparent
        Me.btnChillerOnOff.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
        Me.btnChillerOnOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnChillerOnOff.Clickable = True
        Me.btnChillerOnOff.ColorText_UnknowStatus = System.Drawing.Color.White
        Me.btnChillerOnOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChillerOnOff.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnChillerOnOff.ErrorText = "Error"
        Me.btnChillerOnOff.FlatAppearance.BorderSize = 0
        Me.btnChillerOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChillerOnOff.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChillerOnOff.ForeColor = System.Drawing.Color.White
        Me.btnChillerOnOff.Location = New System.Drawing.Point(4, 31)
        Me.btnChillerOnOff.LogSource = "Chiller"
        Me.btnChillerOnOff.MessageBoxText = Nothing
        Me.btnChillerOnOff.Name = "btnChillerOnOff"
        Me.btnChillerOnOff.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
        Me.btnChillerOnOff.OffText = "Off"
        Me.btnChillerOnOff.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnChillerOnOff.OnText = "On"
        Me.btnChillerOnOff.Size = New System.Drawing.Size(43, 24)
        Me.btnChillerOnOff.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnChillerOnOff.TabIndex = 201
        Me.btnChillerOnOff.Text = "Off"
        Me.btnChillerOnOff.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnChillerOnOff.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
        Me.btnChillerOnOff.UnKnownText = "Off"
        Me.btnChillerOnOff.UseChangeValueToSend_BaseOnStatus = True
        Me.btnChillerOnOff.UseVisualStyleBackColor = False
        Me.btnChillerOnOff.ValueToBeSend = "On"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(49, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 202
        Me.Label2.Text = "Temp (C)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 15)
        Me.Label3.TabIndex = 203
        Me.Label3.Text = "FlowRate (GPM)"
        '
        'txtChillerFlowRateRB
        '
        Me.txtChillerFlowRateRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtChillerFlowRateRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtChillerFlowRateRB.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtChillerFlowRateRB.IsReadBack = True
        Me.txtChillerFlowRateRB.Location = New System.Drawing.Point(106, 61)
        Me.txtChillerFlowRateRB.Name = "txtChillerFlowRateRB"
        Me.txtChillerFlowRateRB.ReadOnly = True
        Me.txtChillerFlowRateRB.Size = New System.Drawing.Size(70, 24)
        Me.txtChillerFlowRateRB.TabIndex = 200
        Me.txtChillerFlowRateRB.TabStop = False
        Me.txtChillerFlowRateRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtChillerFlowRateRB.UnitTypeUsed = "C"
        Me.txtChillerFlowRateRB.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Two_Digits
        '
        'SL_ChillerControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.txtChillerTempSP)
        Me.Controls.Add(Me.txtChillerFlowRateRB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnChillerOnOff)
        Me.Controls.Add(Me.txtChillerTempRB)
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.On
        Me.HeaderText = "Chiller"
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Headerwidth = 85
        Me.Name = "SL_ChillerControl"
        Me.Size = New System.Drawing.Size(256, 60)
        Me.Text = "Chiller"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.txtChillerTempRB, 0)
        Me.Controls.SetChildIndex(Me.btnChillerOnOff, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtChillerFlowRateRB, 0)
        Me.Controls.SetChildIndex(Me.txtChillerTempSP, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtChillerTempRB As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtChillerTempSP As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnChillerOnOff As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtChillerFlowRateRB As AVP_Robot_Project.SL_Textbox

End Class