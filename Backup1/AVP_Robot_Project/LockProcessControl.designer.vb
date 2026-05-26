<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LockProcessControl
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
        Me.components = New System.ComponentModel.Container()
        Me.txtLotID = New AVP_Robot_Project.AVPTextBox()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblSeqID = New System.Windows.Forms.Label()
        Me.txtSeqID = New AVP_Robot_Project.AVPTextBox()
        Me.btnStart = New AVPControls.AVPButton()
        Me.btnLoad = New AVPControls.AVPButton()
        Me.btnAbort = New AVPControls.AVPButton()
        Me.btnUnload = New AVPControls.AVPButton()
        Me.lblPressure = New System.Windows.Forms.Label()
        Me.ctmAbort = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAbort = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbortAndReturn = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblWaferCount = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.psgPressureGraph = New AVP_Robot_Project.PressureGraph()
        Me.ValueToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmBlinkText = New System.Windows.Forms.Timer(Me.components)
        Me.txtCompletedCycleWaferAt = New AVP_Robot_Project.AVPTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblFinishLoadUnload = New System.Windows.Forms.Label()
        Me.lblFinishProcess = New System.Windows.Forms.Label()
        Me.ctmAbort.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Size = New System.Drawing.Size(341, 27)
        Me.Header.Text = "Load Lock"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'txtLotID
        '
        Me.txtLotID.BackColor = System.Drawing.SystemColors.Window
        Me.txtLotID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLotID.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtLotID.HideSelection = False
        Me.txtLotID.Location = New System.Drawing.Point(59, 60)
        Me.txtLotID.Name = "txtLotID"
        Me.txtLotID.ReadOnly = True
        Me.txtLotID.Size = New System.Drawing.Size(208, 24)
        Me.txtLotID.TabIndex = 1
        '
        'lblLotID
        '
        Me.lblLotID.AutoSize = True
        Me.lblLotID.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLotID.Location = New System.Drawing.Point(7, 65)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(48, 15)
        Me.lblLotID.TabIndex = 2
        Me.lblLotID.Text = "LOT ID"
        Me.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSeqID
        '
        Me.lblSeqID.AutoSize = True
        Me.lblSeqID.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.lblSeqID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeqID.Location = New System.Drawing.Point(7, 92)
        Me.lblSeqID.Name = "lblSeqID"
        Me.lblSeqID.Size = New System.Drawing.Size(48, 15)
        Me.lblSeqID.TabIndex = 4
        Me.lblSeqID.Text = "SEQ ID"
        Me.lblSeqID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSeqID
        '
        Me.txtSeqID.BackColor = System.Drawing.SystemColors.Window
        Me.txtSeqID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSeqID.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeqID.Location = New System.Drawing.Point(59, 87)
        Me.txtSeqID.Name = "txtSeqID"
        Me.txtSeqID.ReadOnly = True
        Me.txtSeqID.Size = New System.Drawing.Size(208, 24)
        Me.txtSeqID.TabIndex = 3
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.SystemColors.Control
        Me.btnStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStart.FlatAppearance.BorderSize = 0
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(7, 145)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnStart.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnStart.Size = New System.Drawing.Size(127, 36)
        Me.btnStart.TabIndex = 8
        Me.btnStart.Text = "START"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.SystemColors.Control
        Me.btnLoad.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoad.FlatAppearance.BorderSize = 0
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(140, 145)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLoad.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnLoad.Size = New System.Drawing.Size(127, 36)
        Me.btnLoad.TabIndex = 9
        Me.btnLoad.Text = "LOAD"
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'btnAbort
        '
        Me.btnAbort.BackColor = System.Drawing.SystemColors.Control
        Me.btnAbort.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAbort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbort.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbort.Enabled = False
        Me.btnAbort.FlatAppearance.BorderSize = 0
        Me.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbort.Location = New System.Drawing.Point(7, 184)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAbort.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnAbort.Size = New System.Drawing.Size(127, 36)
        Me.btnAbort.TabIndex = 10
        Me.btnAbort.Text = "ABORT"
        Me.btnAbort.UseVisualStyleBackColor = False
        '
        'btnUnload
        '
        Me.btnUnload.BackColor = System.Drawing.SystemColors.Control
        Me.btnUnload.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUnload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUnload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUnload.FlatAppearance.BorderSize = 0
        Me.btnUnload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnload.Location = New System.Drawing.Point(140, 184)
        Me.btnUnload.Name = "btnUnload"
        Me.btnUnload.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUnload.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnUnload.Size = New System.Drawing.Size(127, 36)
        Me.btnUnload.TabIndex = 11
        Me.btnUnload.Text = "UNLOAD"
        Me.btnUnload.UseVisualStyleBackColor = False
        '
        'lblPressure
        '
        Me.lblPressure.BackColor = System.Drawing.Color.Transparent
        Me.lblPressure.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblPressure.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblPressure.ForeColor = System.Drawing.Color.Lime
        Me.lblPressure.Location = New System.Drawing.Point(262, 0)
        Me.lblPressure.Name = "lblPressure"
        Me.lblPressure.Padding = New System.Windows.Forms.Padding(0, 0, 6, 1)
        Me.lblPressure.Size = New System.Drawing.Size(79, 30)
        Me.lblPressure.TabIndex = 13
        Me.lblPressure.Text = "0.76E+03"
        Me.lblPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ctmAbort
        '
        Me.ctmAbort.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctmAbort.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbort, Me.mnuAbortAndReturn})
        Me.ctmAbort.Name = "ctmAbort"
        Me.ctmAbort.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ctmAbort.ShowImageMargin = False
        Me.ctmAbort.Size = New System.Drawing.Size(236, 52)
        '
        'mnuAbort
        '
        Me.mnuAbort.Name = "mnuAbort"
        Me.mnuAbort.Size = New System.Drawing.Size(235, 24)
        Me.mnuAbort.Text = "Only"
        Me.mnuAbort.ToolTipText = "Abort Sequence Only"
        '
        'mnuAbortAndReturn
        '
        Me.mnuAbortAndReturn.Name = "mnuAbortAndReturn"
        Me.mnuAbortAndReturn.Size = New System.Drawing.Size(235, 24)
        Me.mnuAbortAndReturn.Text = "And Return All Wafers"
        Me.mnuAbortAndReturn.ToolTipText = "Abort Sequence and Return Wafer"
        '
        'lblWaferCount
        '
        Me.lblWaferCount.AutoSize = True
        Me.lblWaferCount.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.lblWaferCount.Location = New System.Drawing.Point(48, 120)
        Me.lblWaferCount.Name = "lblWaferCount"
        Me.lblWaferCount.Size = New System.Drawing.Size(88, 17)
        Me.lblWaferCount.TabIndex = 14
        Me.lblWaferCount.Text = "Wafer Count"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTotal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(140, 114)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(127, 26)
        Me.txtTotal.TabIndex = 3
        Me.txtTotal.Text = "0"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'psgPressureGraph
        '
        Me.psgPressureGraph.AlignStyle = AVP_Robot_Project.PressureGraph.DisplayStyle.Left
        Me.psgPressureGraph.BackColor = System.Drawing.Color.Gainsboro
        Me.psgPressureGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.psgPressureGraph.Cursor = System.Windows.Forms.Cursors.Hand
        Me.psgPressureGraph.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.psgPressureGraph.Location = New System.Drawing.Point(271, 60)
        Me.psgPressureGraph.Name = "psgPressureGraph"
        Me.psgPressureGraph.Size = New System.Drawing.Size(62, 160)
        Me.psgPressureGraph.TabIndex = 22
        '
        'ValueToolTip
        '
        Me.ValueToolTip.AutomaticDelay = 200
        '
        'tmBlinkText
        '
        Me.tmBlinkText.Enabled = True
        '
        'txtCompletedCycleWaferAt
        '
        Me.txtCompletedCycleWaferAt.BackColor = System.Drawing.SystemColors.Window
        Me.txtCompletedCycleWaferAt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCompletedCycleWaferAt.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompletedCycleWaferAt.Location = New System.Drawing.Point(7, 115)
        Me.txtCompletedCycleWaferAt.Name = "txtCompletedCycleWaferAt"
        Me.txtCompletedCycleWaferAt.ReadOnly = True
        Me.txtCompletedCycleWaferAt.Size = New System.Drawing.Size(35, 24)
        Me.txtCompletedCycleWaferAt.TabIndex = 3
        Me.txtCompletedCycleWaferAt.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.lblPressure)
        Me.Panel1.Controls.Add(Me.lblFinishLoadUnload)
        Me.Panel1.Controls.Add(Me.lblFinishProcess)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Lime
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(341, 30)
        Me.Panel1.TabIndex = 24
        '
        'lblFinishLoadUnload
        '
        Me.lblFinishLoadUnload.BackColor = System.Drawing.Color.Transparent
        Me.lblFinishLoadUnload.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblFinishLoadUnload.ForeColor = System.Drawing.Color.Lime
        Me.lblFinishLoadUnload.Location = New System.Drawing.Point(146, 0)
        Me.lblFinishLoadUnload.Name = "lblFinishLoadUnload"
        Me.lblFinishLoadUnload.Size = New System.Drawing.Size(104, 28)
        Me.lblFinishLoadUnload.TabIndex = 26
        Me.lblFinishLoadUnload.Text = "UNLOADING..."
        Me.lblFinishLoadUnload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFinishProcess
        '
        Me.lblFinishProcess.BackColor = System.Drawing.Color.Transparent
        Me.lblFinishProcess.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblFinishProcess.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.lblFinishProcess.ForeColor = System.Drawing.Color.Lime
        Me.lblFinishProcess.Location = New System.Drawing.Point(0, 0)
        Me.lblFinishProcess.Name = "lblFinishProcess"
        Me.lblFinishProcess.Padding = New System.Windows.Forms.Padding(6, 0, 0, 1)
        Me.lblFinishProcess.Size = New System.Drawing.Size(256, 30)
        Me.lblFinishProcess.TabIndex = 27
        Me.lblFinishProcess.Text = "Scheduler Abort And Return Wafer..."
        Me.lblFinishProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LockProcessControl
        '
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtCompletedCycleWaferAt)
        Me.Controls.Add(Me.psgPressureGraph)
        Me.Controls.Add(Me.lblWaferCount)
        Me.Controls.Add(Me.btnUnload)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtSeqID)
        Me.Controls.Add(Me.txtLotID)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblSeqID)
        Me.HeaderText = "Load Lock"
        Me.Name = "LockProcessControl"
        Me.Size = New System.Drawing.Size(341, 228)
        Me.Text = "Load Lock"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.lblSeqID, 0)
        Me.Controls.SetChildIndex(Me.lblLotID, 0)
        Me.Controls.SetChildIndex(Me.txtLotID, 0)
        Me.Controls.SetChildIndex(Me.txtSeqID, 0)
        Me.Controls.SetChildIndex(Me.txtTotal, 0)
        Me.Controls.SetChildIndex(Me.btnStart, 0)
        Me.Controls.SetChildIndex(Me.btnLoad, 0)
        Me.Controls.SetChildIndex(Me.btnAbort, 0)
        Me.Controls.SetChildIndex(Me.btnUnload, 0)
        Me.Controls.SetChildIndex(Me.lblWaferCount, 0)
        Me.Controls.SetChildIndex(Me.psgPressureGraph, 0)
        Me.Controls.SetChildIndex(Me.txtCompletedCycleWaferAt, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.ctmAbort.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLotID As AVPTextBox
    Friend WithEvents lblLotID As System.Windows.Forms.Label
    Friend WithEvents lblSeqID As System.Windows.Forms.Label
    Friend WithEvents txtSeqID As AVPTextBox
    Friend WithEvents btnStart As AVPControls.AVPButton
    Friend WithEvents btnLoad As AVPControls.AVPButton
    Friend WithEvents btnAbort As AVPControls.AVPButton
    Friend WithEvents btnUnload As AVPControls.AVPButton
    Friend WithEvents lblPressure As System.Windows.Forms.Label
    Friend WithEvents ctmAbort As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAbort As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbortAndReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblWaferCount As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents psgPressureGraph As AVP_Robot_Project.PressureGraph
    Friend WithEvents ValueToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents tmBlinkText As System.Windows.Forms.Timer
    Friend WithEvents txtCompletedCycleWaferAt As AVP_Robot_Project.AVPTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblFinishProcess As System.Windows.Forms.Label
    Friend WithEvents lblFinishLoadUnload As System.Windows.Forms.Label
End Class
