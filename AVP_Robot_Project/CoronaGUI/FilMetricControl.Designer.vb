<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilMetricControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FilMetricControl))
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnGotoBaseLine = New AVP_Robot_Project.SL_CustomButton
        Me.btnGotoThickness = New AVP_Robot_Project.SL_CustomButton
        Me.btnMeasure = New AVP_Robot_Project.SL_CustomButton
        Me.txtMeasure = New AVP_Robot_Project.SL_Textbox
        Me.txtProcessRecipe = New AVP_Robot_Project.SL_Textbox
        Me.txtProcessListRecipe = New AVP_Robot_Project.SL_Textbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtGoodnessOfFit = New AVP_Robot_Project.SL_Textbox
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = CType(resources.GetObject("Header.BackgroundImage"), System.Drawing.Image)
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.Size = New System.Drawing.Size(325, 27)
        Me.Header.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.On
        Me.Header.Text = "Thickness Monitor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Tag = "Pressure "
        Me.Label2.Text = "Recipe"
        '
        'btnGotoBaseLine
        '
        Me.btnGotoBaseLine.AccessibleDescription = "GotoBaseLine"
        Me.btnGotoBaseLine.AccessibleName = "GotoBaseLine"
        Me.btnGotoBaseLine.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGotoBaseLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGotoBaseLine.Clickable = True
        Me.btnGotoBaseLine.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnGotoBaseLine.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnGotoBaseLine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGotoBaseLine.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnGotoBaseLine.FlatAppearance.BorderSize = 0
        Me.btnGotoBaseLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGotoBaseLine.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGotoBaseLine.ForeColor = System.Drawing.Color.Black
        Me.btnGotoBaseLine.Location = New System.Drawing.Point(3, 53)
        Me.btnGotoBaseLine.MessageBoxText = Nothing
        Me.btnGotoBaseLine.Name = "btnGotoBaseLine"
        Me.btnGotoBaseLine.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGotoBaseLine.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnGotoBaseLine.Size = New System.Drawing.Size(116, 24)
        Me.btnGotoBaseLine.TabIndex = 21
        Me.btnGotoBaseLine.Text = "Goto Baseline"
        Me.btnGotoBaseLine.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnGotoBaseLine.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnGotoBaseLine.UseVisualStyleBackColor = True
        Me.btnGotoBaseLine.ValueToBeSend = "On"
        '
        'btnGotoThickness
        '
        Me.btnGotoThickness.AccessibleDescription = "GotoThickness"
        Me.btnGotoThickness.AccessibleName = "GotoThickness"
        Me.btnGotoThickness.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGotoThickness.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGotoThickness.Clickable = True
        Me.btnGotoThickness.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnGotoThickness.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnGotoThickness.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGotoThickness.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnGotoThickness.FlatAppearance.BorderSize = 0
        Me.btnGotoThickness.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGotoThickness.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGotoThickness.ForeColor = System.Drawing.Color.Black
        Me.btnGotoThickness.Location = New System.Drawing.Point(119, 53)
        Me.btnGotoThickness.MessageBoxText = Nothing
        Me.btnGotoThickness.Name = "btnGotoThickness"
        Me.btnGotoThickness.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGotoThickness.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnGotoThickness.Size = New System.Drawing.Size(120, 24)
        Me.btnGotoThickness.TabIndex = 21
        Me.btnGotoThickness.Text = "Goto Thickness"
        Me.btnGotoThickness.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnGotoThickness.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnGotoThickness.UseVisualStyleBackColor = True
        Me.btnGotoThickness.ValueToBeSend = "On"
        '
        'btnMeasure
        '
        Me.btnMeasure.AccessibleDescription = "Measure"
        Me.btnMeasure.AccessibleName = "Measure"
        Me.btnMeasure.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMeasure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMeasure.Clickable = True
        Me.btnMeasure.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnMeasure.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnMeasure.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMeasure.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnMeasure.FlatAppearance.BorderSize = 0
        Me.btnMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMeasure.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMeasure.ForeColor = System.Drawing.Color.Black
        Me.btnMeasure.Location = New System.Drawing.Point(243, 52)
        Me.btnMeasure.MessageBoxText = Nothing
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnMeasure.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnMeasure.Size = New System.Drawing.Size(78, 24)
        Me.btnMeasure.TabIndex = 21
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnMeasure.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnMeasure.UseVisualStyleBackColor = True
        Me.btnMeasure.ValueToBeSend = "On"
        '
        'txtMeasure
        '
        Me.txtMeasure.AccessibleDescription = "txtMeasure"
        Me.txtMeasure.AccessibleName = "txtMeasure"
        Me.txtMeasure.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMeasure.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtMeasure.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeasure.IsNumericTextbox = True
        Me.txtMeasure.IsReadBack = True
        Me.txtMeasure.Location = New System.Drawing.Point(243, 31)
        Me.txtMeasure.Name = "txtMeasure"
        Me.txtMeasure.ReadOnly = True
        Me.txtMeasure.Size = New System.Drawing.Size(78, 21)
        Me.txtMeasure.TabIndex = 22
        Me.txtMeasure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMeasure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtMeasure.UnitTypeUsed = "%"
        Me.txtMeasure.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtProcessRecipe
        '
        Me.txtProcessRecipe.AccessibleDescription = ""
        Me.txtProcessRecipe.AccessibleName = "txtProcessRecipe"
        Me.txtProcessRecipe.BackColor = System.Drawing.Color.White
        Me.txtProcessRecipe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtProcessRecipe.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessRecipe.IsNumericTextbox = True
        Me.txtProcessRecipe.IsReadBack = False
        Me.txtProcessRecipe.Location = New System.Drawing.Point(64, 31)
        Me.txtProcessRecipe.Name = "txtProcessRecipe"
        Me.txtProcessRecipe.ReadOnly = True
        Me.txtProcessRecipe.Size = New System.Drawing.Size(175, 21)
        Me.txtProcessRecipe.TabIndex = 23
        Me.txtProcessRecipe.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtProcessRecipe.UnitTypeUsed = "%"
        Me.txtProcessRecipe.UseClickEventInForm = True
        Me.txtProcessRecipe.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtProcessListRecipe
        '
        Me.txtProcessListRecipe.AccessibleDescription = ""
        Me.txtProcessListRecipe.AccessibleName = "txtProcessRecipe"
        Me.txtProcessListRecipe.BackColor = System.Drawing.Color.White
        Me.txtProcessListRecipe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtProcessListRecipe.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessListRecipe.IsNumericTextbox = True
        Me.txtProcessListRecipe.IsReadBack = False
        Me.txtProcessListRecipe.Location = New System.Drawing.Point(209, 0)
        Me.txtProcessListRecipe.Name = "txtProcessListRecipe"
        Me.txtProcessListRecipe.ReadOnly = True
        Me.txtProcessListRecipe.Size = New System.Drawing.Size(104, 22)
        Me.txtProcessListRecipe.TabIndex = 24
        Me.txtProcessListRecipe.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtProcessListRecipe.UnitTypeUsed = "%"
        Me.txtProcessListRecipe.UseClickEventInForm = True
        Me.txtProcessListRecipe.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtProcessListRecipe.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 25
        Me.Label1.Tag = "Pressure "
        Me.Label1.Text = "Goddness of fit"
        '
        'txtGoodnessOfFit
        '
        Me.txtGoodnessOfFit.AccessibleDescription = ""
        Me.txtGoodnessOfFit.AccessibleName = ""
        Me.txtGoodnessOfFit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGoodnessOfFit.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGoodnessOfFit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGoodnessOfFit.IsNumericTextbox = True
        Me.txtGoodnessOfFit.IsReadBack = True
        Me.txtGoodnessOfFit.Location = New System.Drawing.Point(119, 77)
        Me.txtGoodnessOfFit.Name = "txtGoodnessOfFit"
        Me.txtGoodnessOfFit.ReadOnly = True
        Me.txtGoodnessOfFit.Size = New System.Drawing.Size(202, 21)
        Me.txtGoodnessOfFit.TabIndex = 26
        Me.txtGoodnessOfFit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGoodnessOfFit.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtGoodnessOfFit.UnitTypeUsed = "%"
        Me.txtGoodnessOfFit.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'FilMetricControl
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtGoodnessOfFit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProcessListRecipe)
        Me.Controls.Add(Me.txtProcessRecipe)
        Me.Controls.Add(Me.txtMeasure)
        Me.Controls.Add(Me.btnMeasure)
        Me.Controls.Add(Me.btnGotoThickness)
        Me.Controls.Add(Me.btnGotoBaseLine)
        Me.Controls.Add(Me.Label2)
        Me.DoubleBuffered = True
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "FilMetricControl"
        Me.Size = New System.Drawing.Size(325, 104)
        Me.Text = "Thickness Monitor"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnGotoBaseLine, 0)
        Me.Controls.SetChildIndex(Me.btnGotoThickness, 0)
        Me.Controls.SetChildIndex(Me.btnMeasure, 0)
        Me.Controls.SetChildIndex(Me.txtMeasure, 0)
        Me.Controls.SetChildIndex(Me.txtProcessRecipe, 0)
        Me.Controls.SetChildIndex(Me.txtProcessListRecipe, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtGoodnessOfFit, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGotoBaseLine As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnGotoThickness As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnMeasure As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtMeasure As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtProcessRecipe As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtProcessListRecipe As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGoodnessOfFit As AVP_Robot_Project.SL_Textbox

End Class