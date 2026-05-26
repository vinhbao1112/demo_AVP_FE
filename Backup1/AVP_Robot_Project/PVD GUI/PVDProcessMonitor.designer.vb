<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDProcessMonitor
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtProcessTime = New AVP_Robot_Project.SL_Textbox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtWaferID = New AVP_Robot_Project.SL_Textbox
        Me.txtRecipe = New AVP_Robot_Project.SL_Textbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtProcessStep = New AVP_Robot_Project.SL_Textbox
        Me.txtStepTime = New AVP_Robot_Project.SL_Textbox
        Me.txtStatus = New AVP_Robot_Project.SL_Textbox
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Recipe"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 19)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Wafer ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 19)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Process Time"
        '
        'txtProcessTime
        '
        Me.txtProcessTime.AccessibleName = ""
        Me.txtProcessTime.AutoSendKeyTabWhenFinishInput = False
        Me.txtProcessTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProcessTime.Clickable = True
        Me.txtProcessTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtProcessTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtProcessTime.GasName = ""
        Me.txtProcessTime.IsNumericTextbox = False
        Me.txtProcessTime.IsReadBack = True
        Me.txtProcessTime.IsTurboPumpTextbox = False
        Me.txtProcessTime.Location = New System.Drawing.Point(123, 81)
        Me.txtProcessTime.Name = "txtProcessTime"
        Me.txtProcessTime.ReadOnly = True
        Me.txtProcessTime.ShowUnitFormat = False
        Me.txtProcessTime.Size = New System.Drawing.Size(172, 24)
        Me.txtProcessTime.TabIndex = 13
        Me.txtProcessTime.UnitTypeUsed = ""
        Me.txtProcessTime.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtProcessTime.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtProcessTime.UseScientificFormat = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 19)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Process Step"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 19)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Step Time"
        '
        'txtWaferID
        '
        Me.txtWaferID.AccessibleName = "Wafer ID"
        Me.txtWaferID.AutoSendKeyTabWhenFinishInput = False
        Me.txtWaferID.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtWaferID.Clickable = True
        Me.txtWaferID.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtWaferID.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtWaferID.GasName = ""
        Me.txtWaferID.IsNumericTextbox = False
        Me.txtWaferID.IsReadBack = True
        Me.txtWaferID.IsTurboPumpTextbox = False
        Me.txtWaferID.Location = New System.Drawing.Point(123, 57)
        Me.txtWaferID.Name = "txtWaferID"
        Me.txtWaferID.ReadOnly = True
        Me.txtWaferID.ShowUnitFormat = False
        Me.txtWaferID.Size = New System.Drawing.Size(172, 24)
        Me.txtWaferID.TabIndex = 13
        Me.txtWaferID.UnitTypeUsed = ""
        Me.txtWaferID.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtWaferID.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtWaferID.UseScientificFormat = True
        '
        'txtRecipe
        '
        Me.txtRecipe.AccessibleName = "Recipe"
        Me.txtRecipe.AutoSendKeyTabWhenFinishInput = False
        Me.txtRecipe.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRecipe.Clickable = True
        Me.txtRecipe.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRecipe.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRecipe.GasName = ""
        Me.txtRecipe.IsNumericTextbox = False
        Me.txtRecipe.IsReadBack = True
        Me.txtRecipe.IsTurboPumpTextbox = False
        Me.txtRecipe.Location = New System.Drawing.Point(123, 33)
        Me.txtRecipe.Name = "txtRecipe"
        Me.txtRecipe.ReadOnly = True
        Me.txtRecipe.ShowUnitFormat = False
        Me.txtRecipe.Size = New System.Drawing.Size(172, 24)
        Me.txtRecipe.TabIndex = 13
        Me.txtRecipe.UnitTypeUsed = ""
        Me.txtRecipe.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtRecipe.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtRecipe.UseScientificFormat = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 19)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Status"
        '
        'txtProcessStep
        '
        Me.txtProcessStep.AccessibleName = "Process Step"
        Me.txtProcessStep.AutoSendKeyTabWhenFinishInput = False
        Me.txtProcessStep.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProcessStep.Clickable = True
        Me.txtProcessStep.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtProcessStep.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtProcessStep.GasName = ""
        Me.txtProcessStep.IsNumericTextbox = False
        Me.txtProcessStep.IsReadBack = True
        Me.txtProcessStep.IsTurboPumpTextbox = False
        Me.txtProcessStep.Location = New System.Drawing.Point(123, 105)
        Me.txtProcessStep.Name = "txtProcessStep"
        Me.txtProcessStep.ReadOnly = True
        Me.txtProcessStep.ShowUnitFormat = False
        Me.txtProcessStep.Size = New System.Drawing.Size(172, 24)
        Me.txtProcessStep.TabIndex = 13
        Me.txtProcessStep.UnitTypeUsed = ""
        Me.txtProcessStep.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtProcessStep.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtProcessStep.UseScientificFormat = True
        '
        'txtStepTime
        '
        Me.txtStepTime.AutoSendKeyTabWhenFinishInput = False
        Me.txtStepTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStepTime.Clickable = True
        Me.txtStepTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStepTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStepTime.GasName = ""
        Me.txtStepTime.IsNumericTextbox = False
        Me.txtStepTime.IsReadBack = True
        Me.txtStepTime.IsTurboPumpTextbox = False
        Me.txtStepTime.Location = New System.Drawing.Point(123, 129)
        Me.txtStepTime.Name = "txtStepTime"
        Me.txtStepTime.ReadOnly = True
        Me.txtStepTime.ShowUnitFormat = False
        Me.txtStepTime.Size = New System.Drawing.Size(172, 24)
        Me.txtStepTime.TabIndex = 13
        Me.txtStepTime.UnitTypeUsed = ""
        Me.txtStepTime.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtStepTime.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtStepTime.UseScientificFormat = True
        '
        'txtStatus
        '
        Me.txtStatus.AccessibleName = "Status"
        Me.txtStatus.AutoSendKeyTabWhenFinishInput = False
        Me.txtStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStatus.Clickable = True
        Me.txtStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStatus.GasName = ""
        Me.txtStatus.IsNumericTextbox = False
        Me.txtStatus.IsReadBack = True
        Me.txtStatus.IsTurboPumpTextbox = False
        Me.txtStatus.Location = New System.Drawing.Point(123, 153)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.ShowUnitFormat = False
        Me.txtStatus.Size = New System.Drawing.Size(172, 24)
        Me.txtStatus.TabIndex = 13
        Me.txtStatus.UnitTypeUsed = ""
        Me.txtStatus.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtStatus.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtStatus.UseScientificFormat = True
        '
        'PVDProcessMonitor
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRecipe)
        Me.Controls.Add(Me.txtWaferID)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtStepTime)
        Me.Controls.Add(Me.txtProcessStep)
        Me.Controls.Add(Me.txtProcessTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "PVDProcessMonitor"
        Me.Size = New System.Drawing.Size(325, 184)
        Me.Text = "Process Monitor"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtProcessTime, 0)
        Me.Controls.SetChildIndex(Me.txtProcessStep, 0)
        Me.Controls.SetChildIndex(Me.txtStepTime, 0)
        Me.Controls.SetChildIndex(Me.txtStatus, 0)
        Me.Controls.SetChildIndex(Me.txtWaferID, 0)
        Me.Controls.SetChildIndex(Me.txtRecipe, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProcessTime As SL_Textbox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtWaferID As SL_Textbox
    Friend WithEvents txtRecipe As SL_Textbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtProcessStep As SL_Textbox
    Friend WithEvents txtStepTime As SL_Textbox
    Friend WithEvents txtStatus As SL_Textbox

End Class
