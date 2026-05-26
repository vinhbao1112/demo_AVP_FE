<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CORONA_ProcessMonitor
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
        Me.components = New System.ComponentModel.Container
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtWaferID = New AVP_Robot_Project.SL_Textbox
        Me.txtRecipe = New AVP_Robot_Project.SL_Textbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtProcessStep = New AVP_Robot_Project.SL_Textbox
        Me.txtStepTime = New AVP_Robot_Project.SL_Textbox
        Me.txtStatus = New AVP_Robot_Project.SL_Textbox
        Me.lblRevolutionCount = New System.Windows.Forms.Label
        Me.txtRevolutionCount = New AVP_Robot_Project.SL_Textbox
        Me.txtProcessMode = New AVP_Robot_Project.SL_Textbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTotalTime = New AVP_Robot_Project.SL_Textbox
        Me.screenToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 34)
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
        Me.Label1.Location = New System.Drawing.Point(9, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 19)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Wafer ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 106)
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
        Me.Label7.Location = New System.Drawing.Point(9, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 19)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Step Time (s)"
        '
        'txtWaferID
        '
        Me.txtWaferID.AccessibleName = "Wafer ID"
        Me.txtWaferID.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtWaferID.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtWaferID.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtWaferID.IsReadBack = True
        Me.txtWaferID.Location = New System.Drawing.Point(115, 57)
        Me.txtWaferID.Multiline = True
        Me.txtWaferID.Name = "txtWaferID"
        Me.txtWaferID.ReadOnly = True
        Me.txtWaferID.Size = New System.Drawing.Size(195, 42)
        Me.txtWaferID.TabIndex = 13
        Me.txtWaferID.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtWaferID.UseScientificFormat = True
        '
        'txtRecipe
        '
        Me.txtRecipe.AccessibleName = "Recipe"
        Me.txtRecipe.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRecipe.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRecipe.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRecipe.IsReadBack = True
        Me.txtRecipe.Location = New System.Drawing.Point(115, 32)
        Me.txtRecipe.Name = "txtRecipe"
        Me.txtRecipe.ReadOnly = True
        Me.txtRecipe.Size = New System.Drawing.Size(195, 24)
        Me.txtRecipe.TabIndex = 13
        Me.txtRecipe.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtRecipe.UseScientificFormat = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 19)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Status"
        '
        'txtProcessStep
        '
        Me.txtProcessStep.AccessibleName = "Process Step"
        Me.txtProcessStep.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProcessStep.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtProcessStep.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtProcessStep.IsReadBack = True
        Me.txtProcessStep.Location = New System.Drawing.Point(115, 100)
        Me.txtProcessStep.Name = "txtProcessStep"
        Me.txtProcessStep.ReadOnly = True
        Me.txtProcessStep.Size = New System.Drawing.Size(195, 24)
        Me.txtProcessStep.TabIndex = 13
        Me.txtProcessStep.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        '
        'txtStepTime
        '
        Me.txtStepTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStepTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStepTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStepTime.IsReadBack = True
        Me.txtStepTime.Location = New System.Drawing.Point(115, 125)
        Me.txtStepTime.Name = "txtStepTime"
        Me.txtStepTime.ReadOnly = True
        Me.txtStepTime.Size = New System.Drawing.Size(195, 24)
        Me.txtStepTime.TabIndex = 13
        Me.txtStepTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtStepTime.UseScientificFormat = True
        '
        'txtStatus
        '
        Me.txtStatus.AccessibleName = "Status"
        Me.txtStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStatus.IsReadBack = True
        Me.txtStatus.Location = New System.Drawing.Point(115, 175)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(195, 24)
        Me.txtStatus.TabIndex = 13
        Me.txtStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtStatus.UseScientificFormat = True
        '
        'lblRevolutionCount
        '
        Me.lblRevolutionCount.AutoSize = True
        Me.lblRevolutionCount.BackColor = System.Drawing.Color.Transparent
        Me.lblRevolutionCount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRevolutionCount.Location = New System.Drawing.Point(9, 202)
        Me.lblRevolutionCount.Name = "lblRevolutionCount"
        Me.lblRevolutionCount.Size = New System.Drawing.Size(100, 19)
        Me.lblRevolutionCount.TabIndex = 16
        Me.lblRevolutionCount.Text = "Recipe Mode"
        '
        'txtRevolutionCount
        '
        Me.txtRevolutionCount.AccessibleName = "Status"
        Me.txtRevolutionCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRevolutionCount.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRevolutionCount.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRevolutionCount.IsReadBack = True
        Me.txtRevolutionCount.Location = New System.Drawing.Point(115, 200)
        Me.txtRevolutionCount.Name = "txtRevolutionCount"
        Me.txtRevolutionCount.ReadOnly = True
        Me.txtRevolutionCount.Size = New System.Drawing.Size(195, 24)
        Me.txtRevolutionCount.TabIndex = 15
        Me.txtRevolutionCount.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtRevolutionCount.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        '
        'txtProcessMode
        '
        Me.txtProcessMode.AccessibleName = "Status"
        Me.txtProcessMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProcessMode.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtProcessMode.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtProcessMode.IsReadBack = True
        Me.txtProcessMode.Location = New System.Drawing.Point(66, 176)
        Me.txtProcessMode.Name = "txtProcessMode"
        Me.txtProcessMode.ReadOnly = True
        Me.txtProcessMode.Size = New System.Drawing.Size(37, 24)
        Me.txtProcessMode.TabIndex = 17
        Me.txtProcessMode.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtProcessMode.UseScientificFormat = True
        Me.txtProcessMode.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 19)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Process Time"
        '
        'txtTotalTime
        '
        Me.txtTotalTime.AccessibleName = "Process Step"
        Me.txtTotalTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalTime.IsReadBack = True
        Me.txtTotalTime.Location = New System.Drawing.Point(115, 150)
        Me.txtTotalTime.Name = "txtTotalTime"
        Me.txtTotalTime.ReadOnly = True
        Me.txtTotalTime.Size = New System.Drawing.Size(195, 24)
        Me.txtTotalTime.TabIndex = 18
        Me.txtTotalTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtTotalTime.UseScientificFormat = True
        '
        'CORONA_ProcessMonitor
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTotalTime)
        Me.Controls.Add(Me.txtProcessMode)
        Me.Controls.Add(Me.lblRevolutionCount)
        Me.Controls.Add(Me.txtRevolutionCount)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRecipe)
        Me.Controls.Add(Me.txtWaferID)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtStepTime)
        Me.Controls.Add(Me.txtProcessStep)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "CORONA_ProcessMonitor"
        Me.Size = New System.Drawing.Size(320, 230)
        Me.Text = "Process Monitor"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtProcessStep, 0)
        Me.Controls.SetChildIndex(Me.txtStepTime, 0)
        Me.Controls.SetChildIndex(Me.txtStatus, 0)
        Me.Controls.SetChildIndex(Me.txtWaferID, 0)
        Me.Controls.SetChildIndex(Me.txtRecipe, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtRevolutionCount, 0)
        Me.Controls.SetChildIndex(Me.lblRevolutionCount, 0)
        Me.Controls.SetChildIndex(Me.txtProcessMode, 0)
        Me.Controls.SetChildIndex(Me.txtTotalTime, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtWaferID As SL_Textbox
    Friend WithEvents txtRecipe As SL_Textbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtProcessStep As SL_Textbox
    Friend WithEvents txtStepTime As SL_Textbox
    Friend WithEvents txtStatus As SL_Textbox
    Friend WithEvents lblRevolutionCount As System.Windows.Forms.Label
    Friend WithEvents txtRevolutionCount As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtProcessMode As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents screenToolTip As System.Windows.Forms.ToolTip

End Class
