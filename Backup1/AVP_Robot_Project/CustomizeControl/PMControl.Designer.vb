<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PMControl
    Inherits AVP_Robot_Project.PVDStatusPanel

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
        Me.mnuCreateWafer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDeleteWafer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSrcForMove = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDstForMove = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuUpdateWaferInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsChamber = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.lblDisconnected = New System.Windows.Forms.Label
        Me.WFControl = New AVPControls.AVPWaferControl
        Me.bicShutter = New AVP_Robot_Project.SL_CustomButton
        Me.WFControl8 = New AVPControls.AVPWaferControl
        Me.WFControl2 = New AVPControls.AVPWaferControl
        Me.WFControl3 = New AVPControls.AVPWaferControl
        Me.WFControl4 = New AVPControls.AVPWaferControl
        Me.WFControl5 = New AVPControls.AVPWaferControl
        Me.WFControl6 = New AVPControls.AVPWaferControl
        Me.WFControl7 = New AVPControls.AVPWaferControl
        Me.lblCurrentPos = New System.Windows.Forms.Label
        Me.cmsChamber.SuspendLayout()
        CType(Me.WFControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WFControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WFControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WFControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WFControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WFControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WFControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WFControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuCreateWafer
        '
        Me.mnuCreateWafer.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuCreateWafer.Name = "mnuCreateWafer"
        Me.mnuCreateWafer.Size = New System.Drawing.Size(239, 32)
        Me.mnuCreateWafer.Text = "Create Wafer"
        '
        'mnuDeleteWafer
        '
        Me.mnuDeleteWafer.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuDeleteWafer.Name = "mnuDeleteWafer"
        Me.mnuDeleteWafer.Size = New System.Drawing.Size(239, 32)
        Me.mnuDeleteWafer.Text = "Delete Wafer"
        '
        'mnuSrcForMove
        '
        Me.mnuSrcForMove.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSrcForMove.Name = "mnuSrcForMove"
        Me.mnuSrcForMove.Size = New System.Drawing.Size(239, 32)
        Me.mnuSrcForMove.Text = "Src For Move"
        '
        'mnuDstForMove
        '
        Me.mnuDstForMove.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuDstForMove.Name = "mnuDstForMove"
        Me.mnuDstForMove.Size = New System.Drawing.Size(239, 32)
        Me.mnuDstForMove.Text = "Dst For Move"
        '
        'mnuUpdateWaferInfoToolStripMenuItem
        '
        Me.mnuUpdateWaferInfoToolStripMenuItem.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuUpdateWaferInfoToolStripMenuItem.Name = "mnuUpdateWaferInfoToolStripMenuItem"
        Me.mnuUpdateWaferInfoToolStripMenuItem.Size = New System.Drawing.Size(239, 32)
        Me.mnuUpdateWaferInfoToolStripMenuItem.Text = "Update Wafer Info"
        '
        'cmsChamber
        '
        Me.cmsChamber.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsChamber.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCreateWafer, Me.mnuDeleteWafer, Me.mnuDstForMove, Me.mnuSrcForMove, Me.mnuUpdateWaferInfoToolStripMenuItem})
        Me.cmsChamber.Name = "cmsChamber"
        Me.cmsChamber.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsChamber.ShowImageMargin = False
        Me.cmsChamber.Size = New System.Drawing.Size(240, 164)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(32, 19)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(32, 19)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(32, 19)
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(32, 19)
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(32, 19)
        '
        'lblDisconnected
        '
        Me.lblDisconnected.AutoSize = True
        Me.lblDisconnected.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisconnected.ForeColor = System.Drawing.Color.Red
        Me.lblDisconnected.Location = New System.Drawing.Point(39, 63)
        Me.lblDisconnected.Name = "lblDisconnected"
        Me.lblDisconnected.Size = New System.Drawing.Size(97, 17)
        Me.lblDisconnected.TabIndex = 2
        Me.lblDisconnected.Text = "Disconnected"
        Me.lblDisconnected.Visible = False
        '
        'WFControl
        '
        Me.WFControl.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.WFControl.BackColor = System.Drawing.Color.Transparent
        Me.WFControl.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD4
        Me.WFControl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WFControl.IsShowBorder = True
        Me.WFControl.Location = New System.Drawing.Point(62, 94)
        Me.WFControl.Name = "WFControl"
        Me.WFControl.Size = New System.Drawing.Size(35, 35)
        Me.WFControl.TabIndex = 14
        '
        'bicShutter
        '
        Me.bicShutter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bicShutter.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicShutter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicShutter.ErrorImage = Nothing
        Me.bicShutter.FlatAppearance.BorderSize = 0
        Me.bicShutter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicShutter.ForeColor = System.Drawing.Color.White
        Me.bicShutter.Location = New System.Drawing.Point(28, 292)
        Me.bicShutter.MessageBoxText = Nothing
        Me.bicShutter.Name = "bicShutter"
        Me.bicShutter.OffImage = Nothing
        Me.bicShutter.OnImage = Nothing
        Me.bicShutter.Size = New System.Drawing.Size(94, 8)
        Me.bicShutter.TabIndex = 3
        Me.bicShutter.UnknownImage = Nothing
        Me.bicShutter.UseVisualStyleBackColor = True
        Me.bicShutter.ValueToBeSend = "On"
        Me.bicShutter.Visible = False
        '
        'WFControl8
        '
        Me.WFControl8.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.WFControl8.BackColor = System.Drawing.Color.Transparent
        Me.WFControl8.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD4
        Me.WFControl8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WFControl8.IsShowBorder = True
        Me.WFControl8.Location = New System.Drawing.Point(42, 145)
        Me.WFControl8.Name = "WFControl8"
        Me.WFControl8.PMSlotNumber = 8
        Me.WFControl8.PositionID = 7
        Me.WFControl8.Size = New System.Drawing.Size(35, 35)
        Me.WFControl8.TabIndex = 15
        '
        'WFControl2
        '
        Me.WFControl2.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.WFControl2.BackColor = System.Drawing.Color.Transparent
        Me.WFControl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.WFControl2.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD4
        Me.WFControl2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WFControl2.IsShowBorder = True
        Me.WFControl2.Location = New System.Drawing.Point(102, 132)
        Me.WFControl2.Name = "WFControl2"
        Me.WFControl2.PMSlotNumber = 2
        Me.WFControl2.PositionID = 1
        Me.WFControl2.Size = New System.Drawing.Size(35, 35)
        Me.WFControl2.TabIndex = 13
        '
        'WFControl3
        '
        Me.WFControl3.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.WFControl3.BackColor = System.Drawing.Color.Transparent
        Me.WFControl3.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD4
        Me.WFControl3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WFControl3.IsShowBorder = True
        Me.WFControl3.Location = New System.Drawing.Point(191, 132)
        Me.WFControl3.Name = "WFControl3"
        Me.WFControl3.PMSlotNumber = 3
        Me.WFControl3.PositionID = 2
        Me.WFControl3.Size = New System.Drawing.Size(35, 35)
        Me.WFControl3.TabIndex = 12
        '
        'WFControl4
        '
        Me.WFControl4.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.WFControl4.BackColor = System.Drawing.Color.Transparent
        Me.WFControl4.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD4
        Me.WFControl4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WFControl4.IsShowBorder = True
        Me.WFControl4.Location = New System.Drawing.Point(15, 213)
        Me.WFControl4.Name = "WFControl4"
        Me.WFControl4.PMSlotNumber = 4
        Me.WFControl4.PositionID = 3
        Me.WFControl4.Size = New System.Drawing.Size(35, 35)
        Me.WFControl4.TabIndex = 7
        '
        'WFControl5
        '
        Me.WFControl5.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.WFControl5.BackColor = System.Drawing.Color.Transparent
        Me.WFControl5.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD4
        Me.WFControl5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WFControl5.IsShowBorder = True
        Me.WFControl5.Location = New System.Drawing.Point(102, 213)
        Me.WFControl5.Name = "WFControl5"
        Me.WFControl5.PMSlotNumber = 5
        Me.WFControl5.PositionID = 4
        Me.WFControl5.Size = New System.Drawing.Size(35, 35)
        Me.WFControl5.TabIndex = 8
        '
        'WFControl6
        '
        Me.WFControl6.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.WFControl6.BackColor = System.Drawing.Color.Transparent
        Me.WFControl6.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD4
        Me.WFControl6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WFControl6.IsShowBorder = True
        Me.WFControl6.Location = New System.Drawing.Point(191, 213)
        Me.WFControl6.Name = "WFControl6"
        Me.WFControl6.PMSlotNumber = 6
        Me.WFControl6.PositionID = 5
        Me.WFControl6.Size = New System.Drawing.Size(35, 35)
        Me.WFControl6.TabIndex = 9
        '
        'WFControl7
        '
        Me.WFControl7.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        Me.WFControl7.BackColor = System.Drawing.Color.Transparent
        Me.WFControl7.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVD4
        Me.WFControl7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WFControl7.IsShowBorder = True
        Me.WFControl7.Location = New System.Drawing.Point(281, 213)
        Me.WFControl7.Name = "WFControl7"
        Me.WFControl7.PMSlotNumber = 7
        Me.WFControl7.PositionID = 6
        Me.WFControl7.Size = New System.Drawing.Size(35, 35)
        Me.WFControl7.TabIndex = 10
        '
        'lblCurrentPos
        '
        Me.lblCurrentPos.AutoSize = True
        Me.lblCurrentPos.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentPos.ForeColor = System.Drawing.Color.Red
        Me.lblCurrentPos.Location = New System.Drawing.Point(172, 42)
        Me.lblCurrentPos.Name = "lblCurrentPos"
        Me.lblCurrentPos.Size = New System.Drawing.Size(0, 17)
        Me.lblCurrentPos.TabIndex = 11
        Me.lblCurrentPos.Visible = False
        '
        'PMControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lblCurrentPos)
        Me.Controls.Add(Me.WFControl7)
        Me.Controls.Add(Me.WFControl6)
        Me.Controls.Add(Me.WFControl5)
        Me.Controls.Add(Me.WFControl4)
        Me.Controls.Add(Me.WFControl3)
        Me.Controls.Add(Me.WFControl2)
        Me.Controls.Add(Me.lblDisconnected)
        Me.Controls.Add(Me.WFControl)
        Me.Controls.Add(Me.WFControl8)
        Me.Controls.Add(Me.bicShutter)
        Me.Name = "PMControl"
        Me.Size = New System.Drawing.Size(182, 170)
        Me.cmsChamber.ResumeLayout(False)
        CType(Me.WFControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WFControl8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WFControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WFControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WFControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WFControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WFControl6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WFControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WFControl As AVPControls.AVPWaferControl
    Friend WithEvents mnuCreateWafer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteWafer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSrcForMove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDstForMove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUpdateWaferInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsChamber As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblDisconnected As System.Windows.Forms.Label
    Friend WithEvents bicShutter As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents WFControl8 As AVPControls.AVPWaferControl
    Friend WithEvents WFControl2 As AVPControls.AVPWaferControl
    Friend WithEvents WFControl3 As AVPControls.AVPWaferControl
    Friend WithEvents WFControl4 As AVPControls.AVPWaferControl
    Friend WithEvents WFControl5 As AVPControls.AVPWaferControl
    Friend WithEvents WFControl6 As AVPControls.AVPWaferControl
    Friend WithEvents WFControl7 As AVPControls.AVPWaferControl
    Friend WithEvents lblCurrentPos As System.Windows.Forms.Label
End Class
