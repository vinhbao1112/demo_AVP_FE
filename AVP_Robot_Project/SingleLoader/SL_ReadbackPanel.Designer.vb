<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_ReadbackPanel
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtBeamVoltage = New AVP_Robot_Project.SL_Textbox
        Me.txtBeamCurrent = New AVP_Robot_Project.SL_Textbox
        Me.txtSuppressorVoltage = New AVP_Robot_Project.SL_Textbox
        Me.txtForwardRFPower = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNCurrent = New AVP_Robot_Project.SL_Textbox
        Me.txtPBNBody = New AVP_Robot_Project.SL_Textbox
        Me.txtCryoTemp = New AVP_Robot_Project.SL_Textbox
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Size = New System.Drawing.Size(260, 27)
        Me.Header.Text = "Readback"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Beam Voltage (V)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Beam Current (mA)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Suppressor Voltage (V)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Forward RF Power"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "PBN Current (A)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "PBN Body (A)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Cryo Temprature"
        '
        'txtBeamVoltage
        '
        Me.txtBeamVoltage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBeamVoltage.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBeamVoltage.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtBeamVoltage.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtBeamVoltage.IsReadBack = True
        Me.txtBeamVoltage.Location = New System.Drawing.Point(176, 36)
        Me.txtBeamVoltage.Multiline = True
        Me.txtBeamVoltage.Name = "txtBeamVoltage"
        Me.txtBeamVoltage.ReadOnly = True
        Me.txtBeamVoltage.Size = New System.Drawing.Size(74, 20)
        Me.txtBeamVoltage.TabIndex = 12
        Me.txtBeamVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBeamVoltage.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtBeamCurrent
        '
        Me.txtBeamCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBeamCurrent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBeamCurrent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtBeamCurrent.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtBeamCurrent.IsReadBack = True
        Me.txtBeamCurrent.Location = New System.Drawing.Point(176, 65)
        Me.txtBeamCurrent.Multiline = True
        Me.txtBeamCurrent.Name = "txtBeamCurrent"
        Me.txtBeamCurrent.ReadOnly = True
        Me.txtBeamCurrent.Size = New System.Drawing.Size(74, 20)
        Me.txtBeamCurrent.TabIndex = 12
        Me.txtBeamCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBeamCurrent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtSuppressorVoltage
        '
        Me.txtSuppressorVoltage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSuppressorVoltage.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSuppressorVoltage.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSuppressorVoltage.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtSuppressorVoltage.IsReadBack = True
        Me.txtSuppressorVoltage.Location = New System.Drawing.Point(176, 95)
        Me.txtSuppressorVoltage.Multiline = True
        Me.txtSuppressorVoltage.Name = "txtSuppressorVoltage"
        Me.txtSuppressorVoltage.ReadOnly = True
        Me.txtSuppressorVoltage.Size = New System.Drawing.Size(74, 20)
        Me.txtSuppressorVoltage.TabIndex = 12
        Me.txtSuppressorVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSuppressorVoltage.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtForwardRFPower
        '
        Me.txtForwardRFPower.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtForwardRFPower.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtForwardRFPower.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtForwardRFPower.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtForwardRFPower.IsReadBack = True
        Me.txtForwardRFPower.Location = New System.Drawing.Point(176, 125)
        Me.txtForwardRFPower.Multiline = True
        Me.txtForwardRFPower.Name = "txtForwardRFPower"
        Me.txtForwardRFPower.ReadOnly = True
        Me.txtForwardRFPower.Size = New System.Drawing.Size(74, 20)
        Me.txtForwardRFPower.TabIndex = 12
        Me.txtForwardRFPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtForwardRFPower.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtPBNCurrent
        '
        Me.txtPBNCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNCurrent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNCurrent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNCurrent.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtPBNCurrent.IsReadBack = True
        Me.txtPBNCurrent.Location = New System.Drawing.Point(176, 155)
        Me.txtPBNCurrent.Multiline = True
        Me.txtPBNCurrent.Name = "txtPBNCurrent"
        Me.txtPBNCurrent.ReadOnly = True
        Me.txtPBNCurrent.Size = New System.Drawing.Size(74, 20)
        Me.txtPBNCurrent.TabIndex = 12
        Me.txtPBNCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPBNCurrent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtPBNBody
        '
        Me.txtPBNBody.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPBNBody.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPBNBody.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPBNBody.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtPBNBody.IsReadBack = True
        Me.txtPBNBody.Location = New System.Drawing.Point(176, 184)
        Me.txtPBNBody.Multiline = True
        Me.txtPBNBody.Name = "txtPBNBody"
        Me.txtPBNBody.ReadOnly = True
        Me.txtPBNBody.Size = New System.Drawing.Size(74, 20)
        Me.txtPBNBody.TabIndex = 12
        Me.txtPBNBody.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPBNBody.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtCryoTemp
        '
        Me.txtCryoTemp.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCryoTemp.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCryoTemp.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCryoTemp.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtCryoTemp.IsReadBack = True
        Me.txtCryoTemp.Location = New System.Drawing.Point(176, 212)
        Me.txtCryoTemp.Multiline = True
        Me.txtCryoTemp.Name = "txtCryoTemp"
        Me.txtCryoTemp.ReadOnly = True
        Me.txtCryoTemp.Size = New System.Drawing.Size(74, 20)
        Me.txtCryoTemp.TabIndex = 12
        Me.txtCryoTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCryoTemp.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'SL_ReadbackPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.txtCryoTemp)
        Me.Controls.Add(Me.txtPBNBody)
        Me.Controls.Add(Me.txtPBNCurrent)
        Me.Controls.Add(Me.txtForwardRFPower)
        Me.Controls.Add(Me.txtSuppressorVoltage)
        Me.Controls.Add(Me.txtBeamCurrent)
        Me.Controls.Add(Me.txtBeamVoltage)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderText = "Readback"
        Me.Name = "SL_ReadbackPanel"
        Me.Size = New System.Drawing.Size(260, 255)
        Me.Text = "Readback"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtBeamVoltage, 0)
        Me.Controls.SetChildIndex(Me.txtBeamCurrent, 0)
        Me.Controls.SetChildIndex(Me.txtSuppressorVoltage, 0)
        Me.Controls.SetChildIndex(Me.txtForwardRFPower, 0)
        Me.Controls.SetChildIndex(Me.txtPBNCurrent, 0)
        Me.Controls.SetChildIndex(Me.txtPBNBody, 0)
        Me.Controls.SetChildIndex(Me.txtCryoTemp, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBeamVoltage As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtBeamCurrent As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSuppressorVoltage As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtForwardRFPower As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNCurrent As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPBNBody As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtCryoTemp As AVP_Robot_Project.SL_Textbox

End Class
