<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDGasController
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
        Me.lblGas1 = New System.Windows.Forms.Label
        Me.txtGas1 = New AVP_Robot_Project.SL_Textbox
        Me.lblGas2 = New System.Windows.Forms.Label
        Me.txtGas2 = New AVP_Robot_Project.SL_Textbox
        Me.txtGas3 = New AVP_Robot_Project.SL_Textbox
        Me.lblGas3 = New System.Windows.Forms.Label
        Me.txtGas3Right = New AVP_Robot_Project.PVDTextbox
        Me.lblGas4 = New System.Windows.Forms.Label
        Me.lblGas5 = New System.Windows.Forms.Label
        Me.txtGas4 = New AVP_Robot_Project.SL_Textbox
        Me.txtGas2Right = New AVP_Robot_Project.PVDTextbox
        Me.txtGas1Right = New AVP_Robot_Project.PVDTextbox
        Me.txtGas5 = New AVP_Robot_Project.SL_Textbox
        Me.txtGas4Right = New AVP_Robot_Project.PVDTextbox
        Me.txtGas5Right = New AVP_Robot_Project.PVDTextbox
        Me.SuspendLayout()
        '
        'lblGas1
        '
        Me.lblGas1.AutoSize = True
        Me.lblGas1.BackColor = System.Drawing.Color.Transparent
        Me.lblGas1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas1.Location = New System.Drawing.Point(157, 32)
        Me.lblGas1.Name = "lblGas1"
        Me.lblGas1.Size = New System.Drawing.Size(48, 19)
        Me.lblGas1.TabIndex = 8
        Me.lblGas1.Text = "Gas 1"
        '
        'txtGas1
        '
        Me.txtGas1.AccessibleName = "Gas1"
        Me.txtGas1.AutoSendKeyTabWhenFinishInput = False
        Me.txtGas1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas1.Clickable = True
        Me.txtGas1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas1.GasName = ""
        Me.txtGas1.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtGas1.IsNumericTextbox = False
        Me.txtGas1.IsReadBack = True
        Me.txtGas1.IsTurboPumpTextbox = False
        Me.txtGas1.Location = New System.Drawing.Point(8, 29)
        Me.txtGas1.Name = "txtGas1"
        Me.txtGas1.PermissionCode = ""
        Me.txtGas1.ReadOnly = True
        Me.txtGas1.ShowUnitFormat = False
        Me.txtGas1.Size = New System.Drawing.Size(70, 24)
        Me.txtGas1.SourceOfMessageBox = ""
        Me.txtGas1.TabIndex = 9
        Me.txtGas1.UnitTypeUsed = ""
        Me.txtGas1.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtGas1.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtGas1.UseScientificFormat = True
        '
        'lblGas2
        '
        Me.lblGas2.AutoSize = True
        Me.lblGas2.BackColor = System.Drawing.Color.Transparent
        Me.lblGas2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas2.Location = New System.Drawing.Point(156, 62)
        Me.lblGas2.Name = "lblGas2"
        Me.lblGas2.Size = New System.Drawing.Size(48, 19)
        Me.lblGas2.TabIndex = 11
        Me.lblGas2.Text = "Gas 2"
        '
        'txtGas2
        '
        Me.txtGas2.AccessibleName = "Gas2"
        Me.txtGas2.AutoSendKeyTabWhenFinishInput = False
        Me.txtGas2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas2.Clickable = True
        Me.txtGas2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas2.GasName = ""
        Me.txtGas2.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtGas2.IsNumericTextbox = False
        Me.txtGas2.IsReadBack = True
        Me.txtGas2.IsTurboPumpTextbox = False
        Me.txtGas2.Location = New System.Drawing.Point(8, 58)
        Me.txtGas2.Name = "txtGas2"
        Me.txtGas2.PermissionCode = ""
        Me.txtGas2.ReadOnly = True
        Me.txtGas2.ShowUnitFormat = False
        Me.txtGas2.Size = New System.Drawing.Size(70, 24)
        Me.txtGas2.SourceOfMessageBox = ""
        Me.txtGas2.TabIndex = 12
        Me.txtGas2.UnitTypeUsed = ""
        Me.txtGas2.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtGas2.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtGas2.UseScientificFormat = True
        '
        'txtGas3
        '
        Me.txtGas3.AccessibleName = "Gas3"
        Me.txtGas3.AutoSendKeyTabWhenFinishInput = False
        Me.txtGas3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas3.Clickable = True
        Me.txtGas3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas3.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas3.GasName = ""
        Me.txtGas3.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtGas3.IsNumericTextbox = False
        Me.txtGas3.IsReadBack = True
        Me.txtGas3.IsTurboPumpTextbox = False
        Me.txtGas3.Location = New System.Drawing.Point(8, 88)
        Me.txtGas3.Name = "txtGas3"
        Me.txtGas3.PermissionCode = ""
        Me.txtGas3.ReadOnly = True
        Me.txtGas3.ShowUnitFormat = False
        Me.txtGas3.Size = New System.Drawing.Size(70, 24)
        Me.txtGas3.SourceOfMessageBox = ""
        Me.txtGas3.TabIndex = 12
        Me.txtGas3.UnitTypeUsed = ""
        Me.txtGas3.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtGas3.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtGas3.UseScientificFormat = True
        '
        'lblGas3
        '
        Me.lblGas3.AutoSize = True
        Me.lblGas3.BackColor = System.Drawing.Color.Transparent
        Me.lblGas3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas3.Location = New System.Drawing.Point(157, 92)
        Me.lblGas3.Name = "lblGas3"
        Me.lblGas3.Size = New System.Drawing.Size(48, 19)
        Me.lblGas3.TabIndex = 11
        Me.lblGas3.Text = "Gas 3"
        '
        'txtGas3Right
        '
        Me.txtGas3Right.BackColor = System.Drawing.SystemColors.Window
        Me.txtGas3Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas3Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas3Right.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas3Right.Location = New System.Drawing.Point(85, 88)
        Me.txtGas3Right.Name = "txtGas3Right"
        Me.txtGas3Right.ReadOnly = True
        Me.txtGas3Right.Size = New System.Drawing.Size(70, 24)
        Me.txtGas3Right.TabIndex = 13
        Me.txtGas3Right.UseBackGroundWorkerToUpdateMinMax = True
        '
        'lblGas4
        '
        Me.lblGas4.AutoSize = True
        Me.lblGas4.BackColor = System.Drawing.Color.Transparent
        Me.lblGas4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas4.Location = New System.Drawing.Point(157, 122)
        Me.lblGas4.Name = "lblGas4"
        Me.lblGas4.Size = New System.Drawing.Size(48, 19)
        Me.lblGas4.TabIndex = 14
        Me.lblGas4.Text = "Gas 4"
        '
        'lblGas5
        '
        Me.lblGas5.AutoSize = True
        Me.lblGas5.BackColor = System.Drawing.Color.Transparent
        Me.lblGas5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGas5.Location = New System.Drawing.Point(158, 152)
        Me.lblGas5.Name = "lblGas5"
        Me.lblGas5.Size = New System.Drawing.Size(48, 19)
        Me.lblGas5.TabIndex = 14
        Me.lblGas5.Text = "Gas 5"
        '
        'txtGas4
        '
        Me.txtGas4.AccessibleName = "Gas4"
        Me.txtGas4.AutoSendKeyTabWhenFinishInput = False
        Me.txtGas4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas4.Clickable = True
        Me.txtGas4.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas4.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas4.GasName = ""
        Me.txtGas4.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtGas4.IsNumericTextbox = False
        Me.txtGas4.IsReadBack = True
        Me.txtGas4.IsTurboPumpTextbox = False
        Me.txtGas4.Location = New System.Drawing.Point(8, 118)
        Me.txtGas4.Name = "txtGas4"
        Me.txtGas4.PermissionCode = ""
        Me.txtGas4.ReadOnly = True
        Me.txtGas4.ShowUnitFormat = False
        Me.txtGas4.Size = New System.Drawing.Size(70, 24)
        Me.txtGas4.SourceOfMessageBox = ""
        Me.txtGas4.TabIndex = 12
        Me.txtGas4.UnitTypeUsed = ""
        Me.txtGas4.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtGas4.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtGas4.UseScientificFormat = True
        '
        'txtGas2Right
        '
        Me.txtGas2Right.BackColor = System.Drawing.SystemColors.Window
        Me.txtGas2Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas2Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas2Right.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas2Right.Location = New System.Drawing.Point(84, 58)
        Me.txtGas2Right.Name = "txtGas2Right"
        Me.txtGas2Right.ReadOnly = True
        Me.txtGas2Right.Size = New System.Drawing.Size(70, 24)
        Me.txtGas2Right.TabIndex = 13
        Me.txtGas2Right.UseBackGroundWorkerToUpdateMinMax = True
        '
        'txtGas1Right
        '
        Me.txtGas1Right.BackColor = System.Drawing.SystemColors.Window
        Me.txtGas1Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas1Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas1Right.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas1Right.Location = New System.Drawing.Point(84, 29)
        Me.txtGas1Right.Name = "txtGas1Right"
        Me.txtGas1Right.ReadOnly = True
        Me.txtGas1Right.Size = New System.Drawing.Size(70, 24)
        Me.txtGas1Right.TabIndex = 13
        Me.txtGas1Right.UseBackGroundWorkerToUpdateMinMax = True
        '
        'txtGas5
        '
        Me.txtGas5.AccessibleName = "Gas5"
        Me.txtGas5.AutoSendKeyTabWhenFinishInput = False
        Me.txtGas5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGas5.Clickable = True
        Me.txtGas5.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGas5.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas5.GasName = ""
        Me.txtGas5.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtGas5.IsNumericTextbox = False
        Me.txtGas5.IsReadBack = True
        Me.txtGas5.IsTurboPumpTextbox = False
        Me.txtGas5.Location = New System.Drawing.Point(8, 147)
        Me.txtGas5.Name = "txtGas5"
        Me.txtGas5.PermissionCode = ""
        Me.txtGas5.ReadOnly = True
        Me.txtGas5.ShowUnitFormat = False
        Me.txtGas5.Size = New System.Drawing.Size(70, 24)
        Me.txtGas5.SourceOfMessageBox = ""
        Me.txtGas5.TabIndex = 12
        Me.txtGas5.UnitTypeUsed = ""
        Me.txtGas5.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtGas5.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtGas5.UseScientificFormat = True
        '
        'txtGas4Right
        '
        Me.txtGas4Right.BackColor = System.Drawing.SystemColors.Window
        Me.txtGas4Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas4Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas4Right.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas4Right.Location = New System.Drawing.Point(84, 118)
        Me.txtGas4Right.Name = "txtGas4Right"
        Me.txtGas4Right.ReadOnly = True
        Me.txtGas4Right.Size = New System.Drawing.Size(70, 24)
        Me.txtGas4Right.TabIndex = 13
        Me.txtGas4Right.UseBackGroundWorkerToUpdateMinMax = True
        '
        'txtGas5Right
        '
        Me.txtGas5Right.BackColor = System.Drawing.SystemColors.Window
        Me.txtGas5Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGas5Right.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGas5Right.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = True
        Me.txtGas5Right.Location = New System.Drawing.Point(85, 147)
        Me.txtGas5Right.Name = "txtGas5Right"
        Me.txtGas5Right.ReadOnly = True
        Me.txtGas5Right.Size = New System.Drawing.Size(70, 24)
        Me.txtGas5Right.TabIndex = 13
        Me.txtGas5Right.UseBackGroundWorkerToUpdateMinMax = True
        '
        'PVDGasController
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.lblGas5)
        Me.Controls.Add(Me.lblGas4)
        Me.Controls.Add(Me.lblGas1)
        Me.Controls.Add(Me.txtGas1)
        Me.Controls.Add(Me.txtGas1Right)
        Me.Controls.Add(Me.txtGas2Right)
        Me.Controls.Add(Me.txtGas5Right)
        Me.Controls.Add(Me.txtGas4Right)
        Me.Controls.Add(Me.txtGas3Right)
        Me.Controls.Add(Me.lblGas3)
        Me.Controls.Add(Me.txtGas5)
        Me.Controls.Add(Me.txtGas4)
        Me.Controls.Add(Me.txtGas3)
        Me.Controls.Add(Me.lblGas2)
        Me.Controls.Add(Me.txtGas2)
        Me.DoubleBuffered = True
        Me.HeaderHeight = 28
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "PVDGasController"
        Me.Size = New System.Drawing.Size(251, 177)
        Me.Text = "Gas Controller"
        Me.Controls.SetChildIndex(Me.txtGas2, 0)
        Me.Controls.SetChildIndex(Me.lblGas2, 0)
        Me.Controls.SetChildIndex(Me.txtGas3, 0)
        Me.Controls.SetChildIndex(Me.txtGas4, 0)
        Me.Controls.SetChildIndex(Me.txtGas5, 0)
        Me.Controls.SetChildIndex(Me.lblGas3, 0)
        Me.Controls.SetChildIndex(Me.txtGas3Right, 0)
        Me.Controls.SetChildIndex(Me.txtGas4Right, 0)
        Me.Controls.SetChildIndex(Me.txtGas5Right, 0)
        Me.Controls.SetChildIndex(Me.txtGas2Right, 0)
        Me.Controls.SetChildIndex(Me.txtGas1Right, 0)
        Me.Controls.SetChildIndex(Me.txtGas1, 0)
        Me.Controls.SetChildIndex(Me.lblGas1, 0)
        Me.Controls.SetChildIndex(Me.lblGas4, 0)
        Me.Controls.SetChildIndex(Me.lblGas5, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGas1 As System.Windows.Forms.Label
    Friend WithEvents txtGas1 As SL_Textbox
    Friend WithEvents lblGas2 As System.Windows.Forms.Label
    Friend WithEvents txtGas2 As SL_Textbox
    Friend WithEvents txtGas3 As SL_Textbox
    Friend WithEvents lblGas3 As System.Windows.Forms.Label
    Friend WithEvents txtGas3Right As AVP_Robot_Project.PVDTextbox
    Friend WithEvents lblGas4 As System.Windows.Forms.Label
    Friend WithEvents lblGas5 As System.Windows.Forms.Label
    Friend WithEvents txtGas4 As SL_Textbox
    Friend WithEvents txtGas2Right As AVP_Robot_Project.PVDTextbox
    Friend WithEvents txtGas1Right As AVP_Robot_Project.PVDTextbox
    Friend WithEvents txtGas5 As SL_Textbox
    Friend WithEvents txtGas4Right As AVP_Robot_Project.PVDTextbox
    Friend WithEvents txtGas5Right As AVP_Robot_Project.PVDTextbox

End Class
