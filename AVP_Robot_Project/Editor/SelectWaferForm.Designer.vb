<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectWaferForm
    Inherits AVPControls.AVPPopupForm

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
        Me.pnlGraph = New System.Windows.Forms.Panel
        Me.btnSelection = New AVPControls.AVPButton
        Me.btnCreateWafer = New AVPControls.AVPButton
        Me.btnDeleteWafer = New AVPControls.AVPButton
        Me.btnSrcForMove = New AVPControls.AVPButton
        Me.btnDstForMove = New AVPControls.AVPButton
        Me.btnClose = New AVPControls.AVPButton
        Me.cmsSelection = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSelectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuClearAll = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSelectEven = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSelectOdd = New System.Windows.Forms.ToolStripMenuItem
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbcStatus = New System.Windows.Forms.ComboBox
        Me.FormContainer.SuspendLayout()
        Me.cmsSelection.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.cbcStatus)
        Me.FormContainer.Controls.Add(Me.Label6)
        Me.FormContainer.Controls.Add(Me.pnlGraph)
        Me.FormContainer.Controls.Add(Me.btnClose)
        Me.FormContainer.Controls.Add(Me.btnSelection)
        Me.FormContainer.Controls.Add(Me.btnDstForMove)
        Me.FormContainer.Controls.Add(Me.btnSrcForMove)
        Me.FormContainer.Controls.Add(Me.btnDeleteWafer)
        Me.FormContainer.Controls.Add(Me.btnCreateWafer)
        Me.FormContainer.Location = New System.Drawing.Point(5, 0)
        Me.FormContainer.Size = New System.Drawing.Size(690, 415)
        '
        'pnlGraph
        '
        Me.pnlGraph.BackColor = System.Drawing.Color.Silver
        Me.pnlGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlGraph.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlGraph.Location = New System.Drawing.Point(8, 9)
        Me.pnlGraph.Name = "pnlGraph"
        Me.pnlGraph.Size = New System.Drawing.Size(515, 400)
        Me.pnlGraph.TabIndex = 0
        '
        'btnSelection
        '
        Me.btnSelection.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSelection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSelection.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelection.FlatAppearance.BorderSize = 0
        Me.btnSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelection.Image = Global.AVP_Robot_Project.My.Resources.Resources.Modify
        Me.btnSelection.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnSelection.Location = New System.Drawing.Point(542, 12)
        Me.btnSelection.Name = "btnSelection"
        Me.btnSelection.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSelection.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnSelection.Size = New System.Drawing.Size(135, 31)
        Me.btnSelection.TabIndex = 1
        Me.btnSelection.Text = "  Selection"
        Me.btnSelection.UseVisualStyleBackColor = True
        '
        'btnCreateWafer
        '
        Me.btnCreateWafer.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCreateWafer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCreateWafer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreateWafer.FlatAppearance.BorderSize = 0
        Me.btnCreateWafer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateWafer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateWafer.Image = Global.AVP_Robot_Project.My.Resources.Resources.Add
        Me.btnCreateWafer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateWafer.Location = New System.Drawing.Point(542, 61)
        Me.btnCreateWafer.Name = "btnCreateWafer"
        Me.btnCreateWafer.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCreateWafer.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnCreateWafer.Size = New System.Drawing.Size(135, 31)
        Me.btnCreateWafer.TabIndex = 1
        Me.btnCreateWafer.Text = "     Create Wafer"
        Me.btnCreateWafer.UseVisualStyleBackColor = True
        '
        'btnDeleteWafer
        '
        Me.btnDeleteWafer.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDeleteWafer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeleteWafer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteWafer.FlatAppearance.BorderSize = 0
        Me.btnDeleteWafer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteWafer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteWafer.Image = Global.AVP_Robot_Project.My.Resources.Resources.Delete2
        Me.btnDeleteWafer.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnDeleteWafer.Location = New System.Drawing.Point(542, 110)
        Me.btnDeleteWafer.Name = "btnDeleteWafer"
        Me.btnDeleteWafer.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDeleteWafer.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnDeleteWafer.Size = New System.Drawing.Size(135, 31)
        Me.btnDeleteWafer.TabIndex = 1
        Me.btnDeleteWafer.Text = "     Delete Wafer"
        Me.btnDeleteWafer.UseVisualStyleBackColor = True
        '
        'btnSrcForMove
        '
        Me.btnSrcForMove.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSrcForMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSrcForMove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSrcForMove.FlatAppearance.BorderSize = 0
        Me.btnSrcForMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSrcForMove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSrcForMove.Image = Global.AVP_Robot_Project.My.Resources.Resources.NextImage
        Me.btnSrcForMove.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnSrcForMove.Location = New System.Drawing.Point(542, 159)
        Me.btnSrcForMove.Name = "btnSrcForMove"
        Me.btnSrcForMove.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSrcForMove.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnSrcForMove.Size = New System.Drawing.Size(135, 31)
        Me.btnSrcForMove.TabIndex = 1
        Me.btnSrcForMove.Text = "     Src For Move"
        Me.btnSrcForMove.UseVisualStyleBackColor = True
        '
        'btnDstForMove
        '
        Me.btnDstForMove.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDstForMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDstForMove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDstForMove.FlatAppearance.BorderSize = 0
        Me.btnDstForMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDstForMove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDstForMove.Image = Global.AVP_Robot_Project.My.Resources.Resources.back
        Me.btnDstForMove.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDstForMove.Location = New System.Drawing.Point(542, 208)
        Me.btnDstForMove.Name = "btnDstForMove"
        Me.btnDstForMove.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDstForMove.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnDstForMove.Size = New System.Drawing.Size(135, 31)
        Me.btnDstForMove.TabIndex = 1
        Me.btnDstForMove.Text = "Dst For Move     "
        Me.btnDstForMove.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = Global.AVP_Robot_Project.My.Resources.Resources.ExitImage
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnClose.Location = New System.Drawing.Point(553, 365)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClose.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnClose.Size = New System.Drawing.Size(113, 37)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "   Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cmsSelection
        '
        Me.cmsSelection.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelectAll, Me.mnuClearAll, Me.mnuSelectEven, Me.mnuSelectOdd})
        Me.cmsSelection.Name = "cmsSelection"
        Me.cmsSelection.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsSelection.ShowImageMargin = False
        Me.cmsSelection.Size = New System.Drawing.Size(126, 92)
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSelectAll.Name = "mnuSelectAll"
        Me.mnuSelectAll.Size = New System.Drawing.Size(125, 22)
        Me.mnuSelectAll.Text = "Select All"
        '
        'mnuClearAll
        '
        Me.mnuClearAll.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuClearAll.Name = "mnuClearAll"
        Me.mnuClearAll.Size = New System.Drawing.Size(125, 22)
        Me.mnuClearAll.Text = "Clear All"
        '
        'mnuSelectEven
        '
        Me.mnuSelectEven.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSelectEven.Name = "mnuSelectEven"
        Me.mnuSelectEven.Size = New System.Drawing.Size(125, 22)
        Me.mnuSelectEven.Text = "Select Even"
        '
        'mnuSelectOdd
        '
        Me.mnuSelectOdd.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSelectOdd.Name = "mnuSelectOdd"
        Me.mnuSelectOdd.Size = New System.Drawing.Size(125, 22)
        Me.mnuSelectOdd.Text = "Select Odd"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(529, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 23)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Wafer Status"
        '
        'cbcStatus
        '
        Me.cbcStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbcStatus.BackColor = System.Drawing.Color.White
        Me.cbcStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbcStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcStatus.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcStatus.ForeColor = System.Drawing.Color.Black
        Me.cbcStatus.FormattingEnabled = True
        Me.cbcStatus.Location = New System.Drawing.Point(542, 305)
        Me.cbcStatus.Name = "cbcStatus"
        Me.cbcStatus.Size = New System.Drawing.Size(135, 29)
        Me.cbcStatus.TabIndex = 5
        '
        'SelectWaferForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(700, 420)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectWaferForm"
        Me.ShowInTaskbar = False
        Me.ShowTitle = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SelectWaferForm"
        Me.Controls.SetChildIndex(Me.FormContainer, 0)
        Me.FormContainer.ResumeLayout(False)
        Me.FormContainer.PerformLayout()
        Me.cmsSelection.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlGraph As System.Windows.Forms.Panel
    Friend WithEvents btnSelection As AVPControls.AVPButton
    Friend WithEvents btnCreateWafer As AVPControls.AVPButton
    Friend WithEvents btnDeleteWafer As AVPControls.AVPButton
    Friend WithEvents btnSrcForMove As AVPControls.AVPButton
    Friend WithEvents btnDstForMove As AVPControls.AVPButton
    Friend WithEvents btnClose As AVPControls.AVPButton
    Friend WithEvents cmsSelection As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClearAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectEven As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectOdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbcStatus As System.Windows.Forms.ComboBox
End Class
