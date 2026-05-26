<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sequence
    Inherits System.Windows.Forms.UserControl

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.labTitle = New System.Windows.Forms.Label
        Me.btnClearSelected = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.dgvSequence = New System.Windows.Forms.DataGridView
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.btnUnSelectAll = New System.Windows.Forms.Button
        Me.pnlShowWaferFlow = New System.Windows.Forms.Panel
        Me.picShowWaferFlow = New System.Windows.Forms.PictureBox
        Me.picWaferFlow = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnSaveAs = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ValueToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbxShowReworkFiles = New System.Windows.Forms.CheckBox
        CType(Me.dgvSequence, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlShowWaferFlow.SuspendLayout()
        CType(Me.picShowWaferFlow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picWaferFlow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'labTitle
        '
        Me.labTitle.BackColor = System.Drawing.Color.Black
        Me.labTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.labTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold)
        Me.labTitle.ForeColor = System.Drawing.Color.White
        Me.labTitle.Location = New System.Drawing.Point(0, 0)
        Me.labTitle.Name = "labTitle"
        Me.labTitle.Size = New System.Drawing.Size(1271, 43)
        Me.labTitle.TabIndex = 0
        Me.labTitle.Text = "New Sequence"
        Me.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.labTitle.UseMnemonic = False
        '
        'btnClearSelected
        '
        Me.btnClearSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearSelected.BackColor = System.Drawing.SystemColors.Info
        Me.btnClearSelected.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearSelected.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSelected.Location = New System.Drawing.Point(1109, 166)
        Me.btnClearSelected.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClearSelected.Name = "btnClearSelected"
        Me.btnClearSelected.Size = New System.Drawing.Size(153, 36)
        Me.btnClearSelected.TabIndex = 3
        Me.btnClearSelected.Text = "Clear Selected"
        Me.btnClearSelected.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 22)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Description:"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescription.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(156, 8)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(1053, 29)
        Me.txtDescription.TabIndex = 5
        '
        'dgvSequence
        '
        Me.dgvSequence.AllowUserToAddRows = False
        Me.dgvSequence.AllowUserToDeleteRows = False
        Me.dgvSequence.AllowUserToResizeColumns = False
        Me.dgvSequence.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvSequence.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSequence.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSequence.ColumnHeadersHeight = 35
        Me.dgvSequence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSequence.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvSequence.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvSequence.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSequence.Location = New System.Drawing.Point(0, 94)
        Me.dgvSequence.MultiSelect = False
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = True
        Me.dgvSequence.RowHeadersVisible = False
        Me.dgvSequence.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSequence.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSequence.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSequence.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSequence.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.RowTemplate.Height = 40
        Me.dgvSequence.Size = New System.Drawing.Size(614, 671)
        Me.dgvSequence.TabIndex = 7
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.BackColor = System.Drawing.SystemColors.Info
        Me.btnSelectAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelectAll.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectAll.Location = New System.Drawing.Point(1109, 230)
        Me.btnSelectAll.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(153, 36)
        Me.btnSelectAll.TabIndex = 3
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = False
        '
        'btnUnSelectAll
        '
        Me.btnUnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUnSelectAll.BackColor = System.Drawing.SystemColors.Info
        Me.btnUnSelectAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUnSelectAll.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnSelectAll.Location = New System.Drawing.Point(1109, 294)
        Me.btnUnSelectAll.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnUnSelectAll.Name = "btnUnSelectAll"
        Me.btnUnSelectAll.Size = New System.Drawing.Size(153, 36)
        Me.btnUnSelectAll.TabIndex = 3
        Me.btnUnSelectAll.Text = "UnSelect All"
        Me.btnUnSelectAll.UseVisualStyleBackColor = False
        '
        'pnlShowWaferFlow
        '
        Me.pnlShowWaferFlow.AutoScroll = True
        Me.pnlShowWaferFlow.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.pnlShowWaferFlow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlShowWaferFlow.Controls.Add(Me.picShowWaferFlow)
        Me.pnlShowWaferFlow.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlShowWaferFlow.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlShowWaferFlow.Location = New System.Drawing.Point(614, 94)
        Me.pnlShowWaferFlow.Name = "pnlShowWaferFlow"
        Me.pnlShowWaferFlow.Size = New System.Drawing.Size(490, 671)
        Me.pnlShowWaferFlow.TabIndex = 9
       '
        'picShowWaferFlow
        '
        Me.picShowWaferFlow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picShowWaferFlow.Dock = System.Windows.Forms.DockStyle.Top
        Me.picShowWaferFlow.Location = New System.Drawing.Point(0, 0)
        Me.picShowWaferFlow.Name = "picShowWaferFlow"
        Me.picShowWaferFlow.Size = New System.Drawing.Size(486, 126)
        Me.picShowWaferFlow.TabIndex = 0
        Me.picShowWaferFlow.TabStop = False       
        '
        'picWaferFlow
        '
        Me.picWaferFlow.Location = New System.Drawing.Point(1164, 467)
        Me.picWaferFlow.Name = "picWaferFlow"
        Me.picWaferFlow.Size = New System.Drawing.Size(45, 28)
        Me.picWaferFlow.TabIndex = 10
        Me.picWaferFlow.TabStop = False
        Me.picWaferFlow.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgMsgBoxHeader
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnNew)
        Me.Panel2.Controls.Add(Me.btnOpen)
        Me.Panel2.Controls.Add(Me.btnDelete)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnSaveAs)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 43)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1271, 51)
        Me.Panel2.TabIndex = 6
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.BackColor = System.Drawing.SystemColors.Info
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = Global.AVP_Robot_Project.My.Resources.Resources.file_new
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnNew.Location = New System.Drawing.Point(75, 4)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(120, 41)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "    New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.BackColor = System.Drawing.SystemColors.Info
        Me.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpen.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.Image = Global.AVP_Robot_Project.My.Resources.Resources.folder_add
        Me.btnOpen.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnOpen.Location = New System.Drawing.Point(317, 4)
        Me.btnOpen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(120, 41)
        Me.btnOpen.TabIndex = 1
        Me.btnOpen.Text = "  Open"
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Info
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.AVP_Robot_Project.My.Resources.Resources.removeimage
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnDelete.Location = New System.Drawing.Point(576, 4)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 41)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "  Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.SystemColors.Info
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.AVP_Robot_Project.My.Resources.Resources.save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnSave.Location = New System.Drawing.Point(829, 4)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 41)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "  Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnSaveAs
        '
        Me.btnSaveAs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAs.BackColor = System.Drawing.SystemColors.Info
        Me.btnSaveAs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveAs.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAs.Image = Global.AVP_Robot_Project.My.Resources.Resources.save_as
        Me.btnSaveAs.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnSaveAs.Location = New System.Drawing.Point(1074, 4)
        Me.btnSaveAs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.Size = New System.Drawing.Size(120, 41)
        Me.btnSaveAs.TabIndex = 4
        Me.btnSaveAs.Text = "Save As"
        Me.btnSaveAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveAs.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtDescription)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 765)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1271, 45)
        Me.Panel1.TabIndex = 11
        Me.Panel1.Visible = False
        '
        'ValueToolTip
        '
        Me.ValueToolTip.AutomaticDelay = 200
        Me.ValueToolTip.AutoPopDelay = 2000
        Me.ValueToolTip.InitialDelay = 200
        Me.ValueToolTip.ReshowDelay = 20
        Me.ValueToolTip.ShowAlways = True
        '
        'cbxShowReworkFiles
        '
        Me.cbxShowReworkFiles.AccessibleDescription = ""
        Me.cbxShowReworkFiles.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbxShowReworkFiles.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxShowReworkFiles.Location = New System.Drawing.Point(1110, 358)
        Me.cbxShowReworkFiles.Name = "cbxShowReworkFiles"
        Me.cbxShowReworkFiles.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbxShowReworkFiles.Size = New System.Drawing.Size(150, 57)
        Me.cbxShowReworkFiles.TabIndex = 71
        Me.cbxShowReworkFiles.Text = "Show Rework Files"
        Me.cbxShowReworkFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cbxShowReworkFiles.UseVisualStyleBackColor = True
        '
        'Sequence
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Controls.Add(Me.cbxShowReworkFiles)
        Me.Controls.Add(Me.pnlShowWaferFlow)
        Me.Controls.Add(Me.dgvSequence)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.picWaferFlow)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnUnSelectAll)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.btnClearSelected)
        Me.Controls.Add(Me.labTitle)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Sequence"
        Me.Size = New System.Drawing.Size(1271, 810)
        CType(Me.dgvSequence, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlShowWaferFlow.ResumeLayout(False)
        CType(Me.picShowWaferFlow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picWaferFlow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnSaveAs As System.Windows.Forms.Button
    Friend WithEvents btnClearSelected As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents labTitle As System.Windows.Forms.Label
    Friend WithEvents dgvSequence As System.Windows.Forms.DataGridView
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnUnSelectAll As System.Windows.Forms.Button
    Friend WithEvents pnlShowWaferFlow As System.Windows.Forms.Panel
    Friend WithEvents picShowWaferFlow As System.Windows.Forms.PictureBox
    Friend WithEvents picWaferFlow As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ValueToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents cbxShowReworkFiles As System.Windows.Forms.CheckBox

End Class
