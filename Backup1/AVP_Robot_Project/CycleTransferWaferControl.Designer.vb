<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CycleTransferWaferControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CycleTransferWaferControl))
        Me.chkRunWithRecipeA = New System.Windows.Forms.CheckBox
        Me.chkInCycleModeA = New System.Windows.Forms.CheckBox
        Me.grpLLA = New System.Windows.Forms.GroupBox
        Me.txtLLAMaxCycleCount = New AVP_Robot_Project.SL_Textbox
        Me.cbLLAStopCycleAt = New System.Windows.Forms.CheckBox
        Me.grpLLA.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = CType(resources.GetObject("Header.BackgroundImage"), System.Drawing.Image)
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.Status = AVP_Robot_Project.DisplayStatus.[On]
        Me.Header.Text = "CYCLE WAFER"
        '
        'chkRunWithRecipeA
        '
        Me.chkRunWithRecipeA.AutoSize = True
        Me.chkRunWithRecipeA.BackColor = System.Drawing.Color.Transparent
        Me.chkRunWithRecipeA.Checked = True
        Me.chkRunWithRecipeA.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRunWithRecipeA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkRunWithRecipeA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRunWithRecipeA.Location = New System.Drawing.Point(398, 200)
        Me.chkRunWithRecipeA.Name = "chkRunWithRecipeA"
        Me.chkRunWithRecipeA.Size = New System.Drawing.Size(138, 23)
        Me.chkRunWithRecipeA.TabIndex = 2
        Me.chkRunWithRecipeA.Text = "Run with Recipe"
        Me.chkRunWithRecipeA.UseVisualStyleBackColor = False
        Me.chkRunWithRecipeA.Visible = False
        '
        'chkInCycleModeA
        '
        Me.chkInCycleModeA.AutoSize = True
        Me.chkInCycleModeA.BackColor = System.Drawing.Color.Transparent
        Me.chkInCycleModeA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkInCycleModeA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInCycleModeA.ForeColor = System.Drawing.Color.Black
        Me.chkInCycleModeA.Location = New System.Drawing.Point(49, 41)
        Me.chkInCycleModeA.Name = "chkInCycleModeA"
        Me.chkInCycleModeA.Size = New System.Drawing.Size(137, 23)
        Me.chkInCycleModeA.TabIndex = 1
        Me.chkInCycleModeA.Text = "Cycle Continuous"
        Me.chkInCycleModeA.UseVisualStyleBackColor = False
        '
        'grpLLA
        '
        Me.grpLLA.Controls.Add(Me.txtLLAMaxCycleCount)
        Me.grpLLA.Controls.Add(Me.cbLLAStopCycleAt)
        Me.grpLLA.Controls.Add(Me.chkInCycleModeA)
        Me.grpLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLLA.ForeColor = System.Drawing.Color.White
        Me.grpLLA.Location = New System.Drawing.Point(7, 3)
        Me.grpLLA.Name = "grpLLA"
        Me.grpLLA.Size = New System.Drawing.Size(449, 171)
        Me.grpLLA.TabIndex = 11
        Me.grpLLA.TabStop = False
        Me.grpLLA.Text = "Cycle"
        '
        'txtLLAMaxCycleCount
        '
        Me.txtLLAMaxCycleCount.BackColor = System.Drawing.Color.White
        Me.txtLLAMaxCycleCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLLAMaxCycleCount.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtLLAMaxCycleCount.IsIntergerNumber = True
        Me.txtLLAMaxCycleCount.IsNumericTextbox = True
        Me.txtLLAMaxCycleCount.IsReadBack = False
        Me.txtLLAMaxCycleCount.Location = New System.Drawing.Point(115, 85)
        Me.txtLLAMaxCycleCount.Name = "txtLLAMaxCycleCount"
        Me.txtLLAMaxCycleCount.ReadOnly = True
        Me.txtLLAMaxCycleCount.Size = New System.Drawing.Size(70, 24)
        Me.txtLLAMaxCycleCount.SourceOfMessageBox = "LLMaxCycleCount"
        Me.txtLLAMaxCycleCount.TabIndex = 9
        Me.txtLLAMaxCycleCount.Text = "0"
        Me.txtLLAMaxCycleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtLLAMaxCycleCount.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'cbLLAStopCycleAt
        '
        Me.cbLLAStopCycleAt.AutoSize = True
        Me.cbLLAStopCycleAt.BackColor = System.Drawing.Color.Transparent
        Me.cbLLAStopCycleAt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbLLAStopCycleAt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLLAStopCycleAt.ForeColor = System.Drawing.Color.Black
        Me.cbLLAStopCycleAt.Location = New System.Drawing.Point(49, 85)
        Me.cbLLAStopCycleAt.Name = "cbLLAStopCycleAt"
        Me.cbLLAStopCycleAt.Size = New System.Drawing.Size(194, 23)
        Me.cbLLAStopCycleAt.TabIndex = 5
        Me.cbLLAStopCycleAt.Text = "Cycle                    Wafers"
        Me.cbLLAStopCycleAt.UseVisualStyleBackColor = False
        '
        'CycleTransferWaferControl
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.grpLLA)
        Me.Controls.Add(Me.chkRunWithRecipeA)
        Me.DoubleBuffered = True
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.HeaderVisible = False
        Me.Name = "CycleTransferWaferControl"
        Me.Size = New System.Drawing.Size(460, 185)
        Me.Text = "CYCLE WAFER"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.chkRunWithRecipeA, 0)
        Me.Controls.SetChildIndex(Me.grpLLA, 0)
        Me.grpLLA.ResumeLayout(False)
        Me.grpLLA.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkRunWithRecipeA As System.Windows.Forms.CheckBox
    Friend WithEvents chkInCycleModeA As System.Windows.Forms.CheckBox
    Friend WithEvents grpLLA As System.Windows.Forms.GroupBox
    Friend WithEvents cbLLAStopCycleAt As System.Windows.Forms.CheckBox
    Friend WithEvents txtLLAMaxCycleCount As AVP_Robot_Project.SL_Textbox

End Class
