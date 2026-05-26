<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChamberPanel
    Inherits StatusPanel

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
        Me.components = New System.ComponentModel.Container
        Me.LabTitle = New System.Windows.Forms.Label
        Me.lblStatusText = New System.Windows.Forms.Label
        Me.cmsTooltipMachine = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMachineOnline = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMachinePumpDown = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMachineVent = New System.Windows.Forms.ToolStripMenuItem
        Me.lblChamberType = New System.Windows.Forms.Label
        Me.btnTooltipMachine = New System.Windows.Forms.Button
        Me.btnReConnect = New AVP_Robot_Project.ButtonIGCGControl
        Me.RunRecipe = New AVP_Robot_Project.PVDRunRecipe
        Me.txtPMWaferCount = New System.Windows.Forms.TextBox
        Me.txtShieldQuart = New System.Windows.Forms.TextBox
        Me.cmsTooltipMachine.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabTitle
        '
        Me.LabTitle.BackColor = System.Drawing.Color.Transparent
        Me.LabTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabTitle.ForeColor = System.Drawing.Color.Red
        Me.LabTitle.Location = New System.Drawing.Point(0, 0)
        Me.LabTitle.Name = "LabTitle"
        Me.LabTitle.Size = New System.Drawing.Size(1280, 50)
        Me.LabTitle.TabIndex = 5
        Me.LabTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LabTitle.Visible = False
        '
        'lblStatusText
        '
        Me.lblStatusText.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusText.ForeColor = System.Drawing.Color.White
        Me.lblStatusText.Location = New System.Drawing.Point(87, 497)
        Me.lblStatusText.Name = "lblStatusText"
        Me.lblStatusText.Size = New System.Drawing.Size(1106, 31)
        Me.lblStatusText.TabIndex = 107
        '
        'cmsTooltipMachine
        '
        Me.cmsTooltipMachine.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsTooltipMachine.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMachineOnline, Me.mnuMachinePumpDown, Me.mnuMachineVent})
        Me.cmsTooltipMachine.Name = "cmsMechineTool"
        Me.cmsTooltipMachine.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsTooltipMachine.ShowImageMargin = False
        Me.cmsTooltipMachine.Size = New System.Drawing.Size(189, 106)
        '
        'mnuMachineOnline
        '
        Me.mnuMachineOnline.Name = "mnuMachineOnline"
        Me.mnuMachineOnline.Size = New System.Drawing.Size(188, 34)
        Me.mnuMachineOnline.Text = "Online"
        '
        'mnuMachinePumpDown
        '
        Me.mnuMachinePumpDown.Name = "mnuMachinePumpDown"
        Me.mnuMachinePumpDown.Size = New System.Drawing.Size(188, 34)
        Me.mnuMachinePumpDown.Text = "Pump Down"
        '
        'mnuMachineVent
        '
        Me.mnuMachineVent.Name = "mnuMachineVent"
        Me.mnuMachineVent.Size = New System.Drawing.Size(188, 34)
        Me.mnuMachineVent.Text = "Vent"
        '
        'lblChamberType
        '
        Me.lblChamberType.BackColor = System.Drawing.Color.Transparent
        Me.lblChamberType.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblChamberType.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChamberType.ForeColor = System.Drawing.Color.Yellow
        Me.lblChamberType.Location = New System.Drawing.Point(0, 50)
        Me.lblChamberType.Name = "lblChamberType"
        Me.lblChamberType.Size = New System.Drawing.Size(1280, 35)
        Me.lblChamberType.TabIndex = 137
        Me.lblChamberType.Text = "RFPVD"
        Me.lblChamberType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnTooltipMachine
        '
        Me.btnTooltipMachine.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tool
        Me.btnTooltipMachine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTooltipMachine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTooltipMachine.FlatAppearance.BorderSize = 0
        Me.btnTooltipMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTooltipMachine.Location = New System.Drawing.Point(451, 259)
        Me.btnTooltipMachine.Name = "btnTooltipMachine"
        Me.btnTooltipMachine.Size = New System.Drawing.Size(30, 28)
        Me.btnTooltipMachine.TabIndex = 136
        Me.btnTooltipMachine.UseVisualStyleBackColor = True
        '
        'btnReConnect
        '
        Me.btnReConnect.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnReConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReConnect.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnReConnect.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnReConnect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReConnect.ErrorImage = Nothing
        Me.btnReConnect.FlatAppearance.BorderSize = 0
        Me.btnReConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReConnect.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReConnect.ForeColor = System.Drawing.Color.Black
        Me.btnReConnect.Location = New System.Drawing.Point(1134, 6)
        Me.btnReConnect.Name = "btnReConnect"
        Me.btnReConnect.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnReConnect.OffText = "CONNECT"
        Me.btnReConnect.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnReConnect.OnText = "CONNECTED"
        Me.btnReConnect.Size = New System.Drawing.Size(127, 31)
        Me.btnReConnect.TabIndex = 135
        Me.btnReConnect.Text = "CONNECT"
        Me.btnReConnect.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnReConnect.UnKnownText = "CONNECTING"
        Me.btnReConnect.UseVisualStyleBackColor = True
        Me.btnReConnect.Visible = False
        '
        'RunRecipe
        '
        Me.RunRecipe.BackColor = System.Drawing.Color.Transparent
        Me.RunRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RunRecipe.Chamber = Nothing
        Me.RunRecipe.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunRecipe.HeaderStatus = DisplayStatus.[On]
        Me.RunRecipe.HeaderTextColor = System.Drawing.SystemColors.ControlText
        Me.RunRecipe.HeaderVisible = True
        Me.RunRecipe.IsOnline = False
        Me.RunRecipe.Location = New System.Drawing.Point(840, 794)
        Me.RunRecipe.Name = "RunRecipe"
        Me.RunRecipe.Real_Device_Enable = False
        Me.RunRecipe.RecipeName = Nothing
        Me.RunRecipe.Size = New System.Drawing.Size(325, 87)
        Me.RunRecipe.Support_Single_Loader = False
        Me.RunRecipe.TabIndex = 174
        Me.RunRecipe.Text = "Run Recipe"
        Me.RunRecipe.UseBorderStyle = True
        '
        'txtPMWaferCount
        '
        Me.txtPMWaferCount.Location = New System.Drawing.Point(274, 547)
        Me.txtPMWaferCount.Name = "txtPMWaferCount"
        Me.txtPMWaferCount.Size = New System.Drawing.Size(135, 20)
        Me.txtPMWaferCount.TabIndex = 175
        Me.txtPMWaferCount.Visible = False
        '
        'txtShieldQuart
        '
        Me.txtShieldQuart.Location = New System.Drawing.Point(311, 319)
        Me.txtShieldQuart.Name = "txtShieldQuart"
        Me.txtShieldQuart.Size = New System.Drawing.Size(64, 20)
        Me.txtShieldQuart.TabIndex = 176
        Me.txtShieldQuart.Visible = False
        '
        'ChamberPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me.txtShieldQuart)
        Me.Controls.Add(Me.txtPMWaferCount)
        Me.Controls.Add(Me.lblChamberType)
        Me.Controls.Add(Me.btnTooltipMachine)
        Me.Controls.Add(Me.btnReConnect)
        Me.Controls.Add(Me.RunRecipe)
        Me.Controls.Add(Me.lblStatusText)
        Me.Controls.Add(Me.LabTitle)
        Me.Name = "ChamberPanel"
        Me.Size = New System.Drawing.Size(1280, 1024)
        Me.cmsTooltipMachine.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabTitle As System.Windows.Forms.Label
    Friend WithEvents lblStatusText As System.Windows.Forms.Label
    Friend WithEvents btnReConnect As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnTooltipMachine As System.Windows.Forms.Button
    Friend WithEvents cmsTooltipMachine As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMachineOnline As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMachinePumpDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMachineVent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblChamberType As System.Windows.Forms.Label
    Friend WithEvents RunRecipe As AVP_Robot_Project.PVDRunRecipe
    Friend WithEvents txtPMWaferCount As System.Windows.Forms.TextBox
    Friend WithEvents txtShieldQuart As System.Windows.Forms.TextBox

End Class
