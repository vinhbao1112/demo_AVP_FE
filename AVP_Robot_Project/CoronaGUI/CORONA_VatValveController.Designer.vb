<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CORONA_VatValveController
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnTeach = New AVP_Robot_Project.SL_CustomButton
        Me.btnAutoZero = New AVP_Robot_Project.SL_CustomButton
        Me.btnSizeAdjust = New AVP_Robot_Project.SL_CustomButton
        Me.txtPressure = New AVP_Robot_Project.SL_Textbox
        Me.txtPressure_Percent = New AVP_Robot_Project.SL_Textbox
        Me.txtTeach = New AVP_Robot_Project.SL_Textbox
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Tag = "Pressure "
        Me.Label2.Text = "Pressure (mT)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 19)
        Me.Label1.TabIndex = 8
        Me.Label1.Tag = "Pressure "
        Me.Label1.Text = "Position (%)"
        '
        'btnTeach
        '
        Me.btnTeach.AccessibleDescription = "Teach"
        Me.btnTeach.AccessibleName = "Teach"
        Me.btnTeach.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTeach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTeach.Clickable = True
        Me.btnTeach.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTeach.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTeach.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTeach.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTeach.FlatAppearance.BorderSize = 0
        Me.btnTeach.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTeach.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnTeach.ForeColor = System.Drawing.Color.Black
        Me.btnTeach.Location = New System.Drawing.Point(11, 89)
        Me.btnTeach.MessageBoxText = Nothing
        Me.btnTeach.Name = "btnTeach"
        Me.btnTeach.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTeach.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTeach.Size = New System.Drawing.Size(74, 25)
        Me.btnTeach.TabIndex = 21
        Me.btnTeach.Text = "Teach"
        Me.btnTeach.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnTeach.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnTeach.UseVisualStyleBackColor = True
        Me.btnTeach.ValueToBeSend = "On"
        '
        'btnAutoZero
        '
        Me.btnAutoZero.AccessibleDescription = "Auto Zero"
        Me.btnAutoZero.AccessibleName = "AutoZero"
        Me.btnAutoZero.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoZero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoZero.Clickable = True
        Me.btnAutoZero.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAutoZero.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoZero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoZero.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnAutoZero.FlatAppearance.BorderSize = 0
        Me.btnAutoZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoZero.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAutoZero.ForeColor = System.Drawing.Color.Black
        Me.btnAutoZero.Location = New System.Drawing.Point(91, 89)
        Me.btnAutoZero.MessageBoxText = Nothing
        Me.btnAutoZero.Name = "btnAutoZero"
        Me.btnAutoZero.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoZero.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnAutoZero.Size = New System.Drawing.Size(102, 25)
        Me.btnAutoZero.TabIndex = 21
        Me.btnAutoZero.Text = "Auto Zero"
        Me.btnAutoZero.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnAutoZero.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnAutoZero.UseVisualStyleBackColor = True
        Me.btnAutoZero.ValueToBeSend = "On"
        '
        'btnSizeAdjust
        '
        Me.btnSizeAdjust.AccessibleDescription = "Size Adjust"
        Me.btnSizeAdjust.AccessibleName = "SizeAdjust"
        Me.btnSizeAdjust.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSizeAdjust.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSizeAdjust.Clickable = True
        Me.btnSizeAdjust.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnSizeAdjust.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnSizeAdjust.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSizeAdjust.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnSizeAdjust.FlatAppearance.BorderSize = 0
        Me.btnSizeAdjust.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSizeAdjust.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSizeAdjust.ForeColor = System.Drawing.Color.Black
        Me.btnSizeAdjust.Location = New System.Drawing.Point(199, 89)
        Me.btnSizeAdjust.MessageBoxText = Nothing
        Me.btnSizeAdjust.Name = "btnSizeAdjust"
        Me.btnSizeAdjust.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSizeAdjust.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnSizeAdjust.Size = New System.Drawing.Size(109, 25)
        Me.btnSizeAdjust.TabIndex = 21
        Me.btnSizeAdjust.Text = "Size Adjust"
        Me.btnSizeAdjust.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnSizeAdjust.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnSizeAdjust.UseVisualStyleBackColor = True
        Me.btnSizeAdjust.ValueToBeSend = "On"
        '
        'txtPressure
        '
        Me.txtPressure.AccessibleDescription = "TextboxClick"
        Me.txtPressure.AccessibleName = "Pressure"
        Me.txtPressure.AutoSendEventHandler = False
        Me.txtPressure.AutoSendKeyTabWhenFinishInput = False
        Me.txtPressure.BackColor = System.Drawing.Color.White
        Me.txtPressure.Clickable = True
        Me.txtPressure.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPressure.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPressure.GasName = ""
        Me.txtPressure.GetDefaultMinMax = False
        Me.txtPressure.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtPressure.IsIntergerNumber = False
        Me.txtPressure.IsNumericTextbox = True
        Me.txtPressure.IsReadBack = False
        Me.txtPressure.IsTurboPumpTextbox = False
        Me.txtPressure.Location = New System.Drawing.Point(121, 33)
        Me.txtPressure.LogSource = ""
        Me.txtPressure.Name = "txtPressure"
        Me.txtPressure.PermissionCode = ""
        Me.txtPressure.ReadOnly = True
        Me.txtPressure.ShowUnitFormat = False
        Me.txtPressure.Size = New System.Drawing.Size(187, 24)
        Me.txtPressure.SourceOfMessageBox = ""
        Me.txtPressure.TabIndex = 22
        Me.txtPressure.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtPressure.UnitTypeUsed = ""
        Me.txtPressure.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtPressure.UseClickEventInForm = False
        Me.txtPressure.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPressure.UseScientificFormat = False
        '
        'txtPressure_Percent
        '
        Me.txtPressure_Percent.AccessibleDescription = "TextboxClick"
        Me.txtPressure_Percent.AccessibleName = "Pressure Percent"
        Me.txtPressure_Percent.AutoSendEventHandler = False
        Me.txtPressure_Percent.AutoSendKeyTabWhenFinishInput = False
        Me.txtPressure_Percent.BackColor = System.Drawing.Color.White
        Me.txtPressure_Percent.Clickable = True
        Me.txtPressure_Percent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPressure_Percent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPressure_Percent.GasName = ""
        Me.txtPressure_Percent.GetDefaultMinMax = False
        Me.txtPressure_Percent.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtPressure_Percent.IsIntergerNumber = False
        Me.txtPressure_Percent.IsNumericTextbox = True
        Me.txtPressure_Percent.IsReadBack = False
        Me.txtPressure_Percent.IsTurboPumpTextbox = False
        Me.txtPressure_Percent.Location = New System.Drawing.Point(121, 60)
        Me.txtPressure_Percent.LogSource = ""
        Me.txtPressure_Percent.Name = "txtPressure_Percent"
        Me.txtPressure_Percent.PermissionCode = ""
        Me.txtPressure_Percent.ReadOnly = True
        Me.txtPressure_Percent.ShowUnitFormat = False
        Me.txtPressure_Percent.Size = New System.Drawing.Size(187, 24)
        Me.txtPressure_Percent.SourceOfMessageBox = ""
        Me.txtPressure_Percent.TabIndex = 22
        Me.txtPressure_Percent.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtPressure_Percent.UnitTypeUsed = "%"
        Me.txtPressure_Percent.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtPressure_Percent.UseClickEventInForm = False
        Me.txtPressure_Percent.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtPressure_Percent.UseScientificFormat = False
        '
        'txtTeach
        '
        Me.txtTeach.AutoSendEventHandler = False
        Me.txtTeach.AutoSendKeyTabWhenFinishInput = False
        Me.txtTeach.BackColor = System.Drawing.Color.White
        Me.txtTeach.Clickable = True
        Me.txtTeach.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTeach.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTeach.GasName = ""
        Me.txtTeach.GetDefaultMinMax = False
        Me.txtTeach.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtTeach.IsIntergerNumber = False
        Me.txtTeach.IsNumericTextbox = False
        Me.txtTeach.IsReadBack = False
        Me.txtTeach.IsTurboPumpTextbox = False
        Me.txtTeach.Location = New System.Drawing.Point(187, 27)
        Me.txtTeach.LogSource = ""
        Me.txtTeach.Name = "txtTeach"
        Me.txtTeach.PermissionCode = ""
        Me.txtTeach.ReadOnly = True
        Me.txtTeach.ShowUnitFormat = False
        Me.txtTeach.Size = New System.Drawing.Size(15, 24)
        Me.txtTeach.SourceOfMessageBox = ""
        Me.txtTeach.TabIndex = 22
        Me.txtTeach.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtTeach.UnitTypeUsed = ""
        Me.txtTeach.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtTeach.UseClickEventInForm = False
        Me.txtTeach.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtTeach.UseScientificFormat = False
        Me.txtTeach.Visible = False
        '
        'CORONA_VatValveController
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtPressure_Percent)
        Me.Controls.Add(Me.txtPressure)
        Me.Controls.Add(Me.btnSizeAdjust)
        Me.Controls.Add(Me.btnAutoZero)
        Me.Controls.Add(Me.btnTeach)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTeach)
        Me.DoubleBuffered = True
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "CORONA_VatValveController"
        Me.Size = New System.Drawing.Size(320, 121)
        Me.Text = "Vat Valve Controller"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.txtTeach, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnTeach, 0)
        Me.Controls.SetChildIndex(Me.btnAutoZero, 0)
        Me.Controls.SetChildIndex(Me.btnSizeAdjust, 0)
        Me.Controls.SetChildIndex(Me.txtPressure, 0)
        Me.Controls.SetChildIndex(Me.txtPressure_Percent, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTeach As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnAutoZero As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnSizeAdjust As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtPressure As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtPressure_Percent As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtTeach As AVP_Robot_Project.SL_Textbox

End Class