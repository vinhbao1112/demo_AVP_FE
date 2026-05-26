<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CORONA_Pressure
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CORONA_Pressure))
        Me.txtPressure = New AVP_Robot_Project.SL_Textbox
        Me.btnIGStatus = New AVP_Robot_Project.SL_CustomButton
        Me.txtCGPressure = New AVP_Robot_Project.SL_Textbox
        Me.txtIGPressure = New AVP_Robot_Project.SL_Textbox
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = CType(resources.GetObject("Header.BackgroundImage"), System.Drawing.Image)
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.Size = New System.Drawing.Size(110, 27)
        Me.Header.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.Header.Text = "Pressure"
        '
        'txtPressure
        '
        Me.txtPressure.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtPressure.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPressure.DisplayPressureFont = True
        Me.txtPressure.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPressure.ForeColor = System.Drawing.Color.Lime
        Me.txtPressure.IsReadBack = True
        Me.txtPressure.Location = New System.Drawing.Point(8, 32)
        Me.txtPressure.MinimumValueHighlightedGreen = 0
        Me.txtPressure.Name = "txtPressure"
        Me.txtPressure.ReadOnly = True
        Me.txtPressure.Size = New System.Drawing.Size(95, 24)
        Me.txtPressure.TabIndex = 8
        Me.txtPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPressure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtPressure.UseClickEventInForm = True
        Me.txtPressure.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPressure.UseScientificFormat = True
        '
        'btnIGStatus
        '
        Me.btnIGStatus.AccessibleDescription = "IG"
        Me.btnIGStatus.AccessibleName = "IGStatus"
        Me.btnIGStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
        Me.btnIGStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIGStatus.Clickable = True
        Me.btnIGStatus.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnIGStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIGStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnIGStatus.FlatAppearance.BorderSize = 0
        Me.btnIGStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIGStatus.ForeColor = System.Drawing.Color.White
        Me.btnIGStatus.IsNotValve = True
        Me.btnIGStatus.Location = New System.Drawing.Point(66, 66)
        Me.btnIGStatus.MessageBoxText = Nothing
        Me.btnIGStatus.Name = "btnIGStatus"
        Me.btnIGStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
        Me.btnIGStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnIGStatus.Size = New System.Drawing.Size(45, 20)
        Me.btnIGStatus.TabIndex = 9
        Me.btnIGStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnIGStatus.UseChangeValueToSend_BaseOnStatus = True
        Me.btnIGStatus.UseVisualStyleBackColor = True
        Me.btnIGStatus.ValueToBeSend = "On"
        Me.btnIGStatus.Visible = False
        '
        'txtCGPressure
        '
        Me.txtCGPressure.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCGPressure.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCGPressure.DisplayPressureFont = True
        Me.txtCGPressure.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCGPressure.ForeColor = System.Drawing.Color.Lime
        Me.txtCGPressure.IsReadBack = True
        Me.txtCGPressure.Location = New System.Drawing.Point(51, 61)
        Me.txtCGPressure.MinimumValueHighlightedGreen = 0
        Me.txtCGPressure.Name = "txtCGPressure"
        Me.txtCGPressure.ReadOnly = True
        Me.txtCGPressure.Size = New System.Drawing.Size(15, 24)
        Me.txtCGPressure.TabIndex = 11
        Me.txtCGPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCGPressure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PQL
        Me.txtCGPressure.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtCGPressure.UseScientificFormat = True
        Me.txtCGPressure.Visible = False
        '
        'txtIGPressure
        '
        Me.txtIGPressure.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtIGPressure.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtIGPressure.DisplayPressureFont = True
        Me.txtIGPressure.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtIGPressure.ForeColor = System.Drawing.Color.Lime
        Me.txtIGPressure.IsReadBack = True
        Me.txtIGPressure.Location = New System.Drawing.Point(117, 62)
        Me.txtIGPressure.MinimumValueHighlightedGreen = 0
        Me.txtIGPressure.Name = "txtIGPressure"
        Me.txtIGPressure.ReadOnly = True
        Me.txtIGPressure.Size = New System.Drawing.Size(15, 24)
        Me.txtIGPressure.TabIndex = 11
        Me.txtIGPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIGPressure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PQL
        Me.txtIGPressure.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtIGPressure.UseScientificFormat = True
        Me.txtIGPressure.Visible = False
        '
        'CORONA_Pressure
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtIGPressure)
        Me.Controls.Add(Me.txtCGPressure)
        Me.Controls.Add(Me.btnIGStatus)
        Me.Controls.Add(Me.txtPressure)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderText = "Pressure"
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "CORONA_Pressure"
        Me.Size = New System.Drawing.Size(110, 61)
        Me.Text = "Pressure"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.txtPressure, 0)
        Me.Controls.SetChildIndex(Me.btnIGStatus, 0)
        Me.Controls.SetChildIndex(Me.txtCGPressure, 0)
        Me.Controls.SetChildIndex(Me.txtIGPressure, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPressure As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnIGStatus As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtCGPressure As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtIGPressure As AVP_Robot_Project.SL_Textbox

End Class
