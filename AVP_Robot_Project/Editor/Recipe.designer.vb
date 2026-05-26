<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecipeEditor
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
        Me.LabTitle = New System.Windows.Forms.Label
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.cbxShowReworkFiles = New System.Windows.Forms.CheckBox
        Me.btnAddCopiedStep = New System.Windows.Forms.Button
        Me.btnInsertCopiedStep = New System.Windows.Forms.Button
        Me.btnPasteStep = New System.Windows.Forms.Button
        Me.btnCopyStep = New System.Windows.Forms.Button
        Me.btnDeleteStep = New System.Windows.Forms.Button
        Me.btnAddStep = New System.Windows.Forms.Button
        Me.btnInsertStep = New System.Windows.Forms.Button
        Me.dgvChamber = New System.Windows.Forms.DataGridView
        Me.gcParameters = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gcStep1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tabEditorRecipe = New System.Windows.Forms.CustomTabControl
        Me.tabAlignerRecipe = New System.Windows.Forms.TabPage
        Me.tabPM1Recipe = New System.Windows.Forms.TabPage
        Me.tabPM2Recipe = New System.Windows.Forms.TabPage
        Me.tabPM3Recipe = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnQuickView = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnSaveAs = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblTotalStep = New System.Windows.Forms.Label
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvChamber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEditorRecipe.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabTitle
        '
        Me.LabTitle.BackColor = System.Drawing.Color.Black
        Me.LabTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold)
        Me.LabTitle.ForeColor = System.Drawing.Color.White
        Me.LabTitle.Location = New System.Drawing.Point(0, 0)
        Me.LabTitle.Name = "LabTitle"
        Me.LabTitle.Size = New System.Drawing.Size(1271, 43)
        Me.LabTitle.TabIndex = 4
        Me.LabTitle.Text = "Recipe Editor - A0084"
        Me.LabTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabTitle.UseMnemonic = False
        '
        'ctxMenu
        '
        Me.ctxMenu.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(61, 4)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtDescription)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 771)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1271, 39)
        Me.Panel3.TabIndex = 7
        Me.Panel3.Visible = False
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescription.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(156, 4)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(1090, 29)
        Me.txtDescription.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(23, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Description:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel4.Controls.Add(Me.cbxShowReworkFiles)
        Me.Panel4.Controls.Add(Me.lblTotalStep)
        Me.Panel4.Controls.Add(Me.btnAddCopiedStep)
        Me.Panel4.Controls.Add(Me.btnInsertCopiedStep)
        Me.Panel4.Controls.Add(Me.btnPasteStep)
        Me.Panel4.Controls.Add(Me.btnCopyStep)
        Me.Panel4.Controls.Add(Me.btnDeleteStep)
        Me.Panel4.Controls.Add(Me.btnAddStep)
        Me.Panel4.Controls.Add(Me.btnInsertStep)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(1048, 94)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(223, 677)
        Me.Panel4.TabIndex = 8
        '
        'cbxShowReworkFiles
        '
        Me.cbxShowReworkFiles.AccessibleDescription = ""
        Me.cbxShowReworkFiles.AutoSize = True
        Me.cbxShowReworkFiles.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbxShowReworkFiles.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxShowReworkFiles.Location = New System.Drawing.Point(16, 440)
        Me.cbxShowReworkFiles.Name = "cbxShowReworkFiles"
        Me.cbxShowReworkFiles.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbxShowReworkFiles.Size = New System.Drawing.Size(185, 27)
        Me.cbxShowReworkFiles.TabIndex = 70
        Me.cbxShowReworkFiles.Text = "Show Rework Files"
        Me.cbxShowReworkFiles.UseVisualStyleBackColor = True
        '
        'btnAddCopiedStep
        '
        Me.btnAddCopiedStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCopiedStep.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddCopiedStep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddCopiedStep.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.btnAddCopiedStep.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_update
        Me.btnAddCopiedStep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddCopiedStep.Location = New System.Drawing.Point(16, 382)
        Me.btnAddCopiedStep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAddCopiedStep.Name = "btnAddCopiedStep"
        Me.btnAddCopiedStep.Size = New System.Drawing.Size(202, 36)
        Me.btnAddCopiedStep.TabIndex = 3
        Me.btnAddCopiedStep.Text = "  Add Copied Step"
        Me.btnAddCopiedStep.UseVisualStyleBackColor = False
        '
        'btnInsertCopiedStep
        '
        Me.btnInsertCopiedStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertCopiedStep.BackColor = System.Drawing.SystemColors.Control
        Me.btnInsertCopiedStep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInsertCopiedStep.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.btnInsertCopiedStep.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_update
        Me.btnInsertCopiedStep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInsertCopiedStep.Location = New System.Drawing.Point(16, 324)
        Me.btnInsertCopiedStep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnInsertCopiedStep.Name = "btnInsertCopiedStep"
        Me.btnInsertCopiedStep.Size = New System.Drawing.Size(202, 36)
        Me.btnInsertCopiedStep.TabIndex = 3
        Me.btnInsertCopiedStep.Text = "   Insert Copied Step"
        Me.btnInsertCopiedStep.UseVisualStyleBackColor = False
        '
        'btnPasteStep
        '
        Me.btnPasteStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPasteStep.BackColor = System.Drawing.SystemColors.Control
        Me.btnPasteStep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPasteStep.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.btnPasteStep.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_status
        Me.btnPasteStep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPasteStep.Location = New System.Drawing.Point(16, 266)
        Me.btnPasteStep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPasteStep.Name = "btnPasteStep"
        Me.btnPasteStep.Size = New System.Drawing.Size(202, 36)
        Me.btnPasteStep.TabIndex = 3
        Me.btnPasteStep.Text = "Paste Step"
        Me.btnPasteStep.UseVisualStyleBackColor = False
        '
        'btnCopyStep
        '
        Me.btnCopyStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyStep.BackColor = System.Drawing.SystemColors.Control
        Me.btnCopyStep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCopyStep.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.btnCopyStep.Image = Global.AVP_Robot_Project.My.Resources.Resources.db
        Me.btnCopyStep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCopyStep.Location = New System.Drawing.Point(16, 208)
        Me.btnCopyStep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCopyStep.Name = "btnCopyStep"
        Me.btnCopyStep.Size = New System.Drawing.Size(202, 36)
        Me.btnCopyStep.TabIndex = 3
        Me.btnCopyStep.Text = "Copy Step"
        Me.btnCopyStep.UseVisualStyleBackColor = False
        '
        'btnDeleteStep
        '
        Me.btnDeleteStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteStep.BackColor = System.Drawing.SystemColors.Control
        Me.btnDeleteStep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteStep.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.btnDeleteStep.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_remove
        Me.btnDeleteStep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteStep.Location = New System.Drawing.Point(16, 150)
        Me.btnDeleteStep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDeleteStep.Name = "btnDeleteStep"
        Me.btnDeleteStep.Size = New System.Drawing.Size(202, 36)
        Me.btnDeleteStep.TabIndex = 3
        Me.btnDeleteStep.Text = "Delete Step"
        Me.btnDeleteStep.UseVisualStyleBackColor = False
        '
        'btnAddStep
        '
        Me.btnAddStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddStep.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddStep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddStep.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.btnAddStep.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_add
        Me.btnAddStep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddStep.Location = New System.Drawing.Point(16, 92)
        Me.btnAddStep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAddStep.Name = "btnAddStep"
        Me.btnAddStep.Size = New System.Drawing.Size(202, 36)
        Me.btnAddStep.TabIndex = 3
        Me.btnAddStep.Text = "Add Step"
        Me.btnAddStep.UseVisualStyleBackColor = False
        '
        'btnInsertStep
        '
        Me.btnInsertStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertStep.BackColor = System.Drawing.SystemColors.Control
        Me.btnInsertStep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInsertStep.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInsertStep.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_comit
        Me.btnInsertStep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInsertStep.Location = New System.Drawing.Point(16, 34)
        Me.btnInsertStep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnInsertStep.Name = "btnInsertStep"
        Me.btnInsertStep.Size = New System.Drawing.Size(202, 36)
        Me.btnInsertStep.TabIndex = 3
        Me.btnInsertStep.Text = "Insert Step"
        Me.btnInsertStep.UseVisualStyleBackColor = False
        '
        'dgvChamber
        '
        Me.dgvChamber.AllowUserToAddRows = False
        Me.dgvChamber.AllowUserToDeleteRows = False
        Me.dgvChamber.AllowUserToResizeColumns = False
        Me.dgvChamber.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvChamber.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvChamber.BackgroundColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvChamber.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvChamber.ColumnHeadersHeight = 35
        Me.dgvChamber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvChamber.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gcParameters, Me.gcStep1})
        Me.dgvChamber.ContextMenuStrip = Me.ctxMenu
        Me.dgvChamber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvChamber.EnableHeadersVisualStyles = False
        Me.dgvChamber.Location = New System.Drawing.Point(4, 493)
        Me.dgvChamber.MultiSelect = False
        Me.dgvChamber.Name = "dgvChamber"
        Me.dgvChamber.RowHeadersVisible = False
        Me.dgvChamber.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvChamber.RowTemplate.Height = 35
        Me.dgvChamber.Size = New System.Drawing.Size(694, 251)
        Me.dgvChamber.TabIndex = 6
        '
        'gcParameters
        '
        Me.gcParameters.HeaderText = "Parameters"
        Me.gcParameters.Name = "gcParameters"
        Me.gcParameters.ReadOnly = True
        Me.gcParameters.Width = 300
        '
        'gcStep1
        '
        Me.gcStep1.HeaderText = "Step-1"
        Me.gcStep1.Name = "gcStep1"
        Me.gcStep1.ReadOnly = True
        Me.gcStep1.Width = 80
        '
        'tabEditorRecipe
        '
        Me.tabEditorRecipe.Controls.Add(Me.tabAlignerRecipe)
        Me.tabEditorRecipe.Controls.Add(Me.tabPM1Recipe)
        Me.tabEditorRecipe.Controls.Add(Me.tabPM2Recipe)
        Me.tabEditorRecipe.Controls.Add(Me.tabPM3Recipe)
        Me.tabEditorRecipe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabEditorRecipe.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabEditorRecipe.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabEditorRecipe.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.tabEditorRecipe.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabEditorRecipe.DisplayStyleProvider.FocusTrack = False
        Me.tabEditorRecipe.DisplayStyleProvider.HotTrack = True
        Me.tabEditorRecipe.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabEditorRecipe.DisplayStyleProvider.Opacity = 1.0!
        Me.tabEditorRecipe.DisplayStyleProvider.Overlap = 0
        Me.tabEditorRecipe.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabEditorRecipe.DisplayStyleProvider.Radius = 10
        Me.tabEditorRecipe.DisplayStyleProvider.ShowTabCloser = False
        Me.tabEditorRecipe.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabEditorRecipe.HotTrack = True
        Me.tabEditorRecipe.Location = New System.Drawing.Point(0, 101)
        Me.tabEditorRecipe.Name = "tabEditorRecipe"
        Me.tabEditorRecipe.SelectedIndex = 0
        Me.tabEditorRecipe.Size = New System.Drawing.Size(1048, 386)
        Me.tabEditorRecipe.TabIndex = 152
        '
        'tabAlignerRecipe
        '
        Me.tabAlignerRecipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAlignerRecipe.Location = New System.Drawing.Point(0, 36)
        Me.tabAlignerRecipe.Name = "tabAlignerRecipe"
        Me.tabAlignerRecipe.Size = New System.Drawing.Size(1048, 350)
        Me.tabAlignerRecipe.TabIndex = 0
        Me.tabAlignerRecipe.Text = "Aligner"
        Me.tabAlignerRecipe.UseVisualStyleBackColor = True
        '
        'tabPM1Recipe
        '
        Me.tabPM1Recipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPM1Recipe.Location = New System.Drawing.Point(0, 36)
        Me.tabPM1Recipe.Name = "tabPM1Recipe"
        Me.tabPM1Recipe.Size = New System.Drawing.Size(1048, 350)
        Me.tabPM1Recipe.TabIndex = 1
        Me.tabPM1Recipe.Tag = "Chamber1"
        Me.tabPM1Recipe.Text = "PM1"
        Me.tabPM1Recipe.UseVisualStyleBackColor = True
        '
        'tabPM2Recipe
        '
        Me.tabPM2Recipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPM2Recipe.Location = New System.Drawing.Point(0, 36)
        Me.tabPM2Recipe.Name = "tabPM2Recipe"
        Me.tabPM2Recipe.Size = New System.Drawing.Size(1048, 350)
        Me.tabPM2Recipe.TabIndex = 2
        Me.tabPM2Recipe.Tag = "Chamber2"
        Me.tabPM2Recipe.Text = "PM2"
        Me.tabPM2Recipe.UseVisualStyleBackColor = True
        '
        'tabPM3Recipe
        '
        Me.tabPM3Recipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPM3Recipe.Location = New System.Drawing.Point(0, 36)
        Me.tabPM3Recipe.Name = "tabPM3Recipe"
        Me.tabPM3Recipe.Size = New System.Drawing.Size(1048, 350)
        Me.tabPM3Recipe.TabIndex = 3
        Me.tabPM3Recipe.Tag = "Chamber3"
        Me.tabPM3Recipe.Text = "PM3"
        Me.tabPM3Recipe.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgMsgBoxHeader
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnQuickView)
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
        Me.Panel2.TabIndex = 5
        '
        'btnQuickView
        '
        Me.btnQuickView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuickView.BackColor = System.Drawing.SystemColors.Info
        Me.btnQuickView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuickView.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuickView.Image = Global.AVP_Robot_Project.My.Resources.Resources.Quick_View
        Me.btnQuickView.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnQuickView.Location = New System.Drawing.Point(472, 4)
        Me.btnQuickView.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnQuickView.Name = "btnQuickView"
        Me.btnQuickView.Size = New System.Drawing.Size(146, 41)
        Me.btnQuickView.TabIndex = 153
        Me.btnQuickView.Text = "     Quick View"
        Me.btnQuickView.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.BackColor = System.Drawing.SystemColors.Info
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.btnNew.Image = Global.AVP_Robot_Project.My.Resources.Resources.file_new
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnNew.Location = New System.Drawing.Point(76, 4)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(120, 41)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "    New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.BackColor = System.Drawing.SystemColors.Info
        Me.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpen.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.btnOpen.Image = Global.AVP_Robot_Project.My.Resources.Resources.folder_add
        Me.btnOpen.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnOpen.Location = New System.Drawing.Point(275, 4)
        Me.btnOpen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(120, 41)
        Me.btnOpen.TabIndex = 2
        Me.btnOpen.Text = "  Open"
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Info
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.btnDelete.Image = Global.AVP_Robot_Project.My.Resources.Resources.removeimage
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnDelete.Location = New System.Drawing.Point(695, 4)
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
        Me.btnSave.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.btnSave.Image = Global.AVP_Robot_Project.My.Resources.Resources.save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnSave.Location = New System.Drawing.Point(892, 4)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 41)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "  Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnSaveAs
        '
        Me.btnSaveAs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAs.BackColor = System.Drawing.SystemColors.Info
        Me.btnSaveAs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveAs.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.btnSaveAs.Image = Global.AVP_Robot_Project.My.Resources.Resources.save_as
        Me.btnSaveAs.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnSaveAs.Location = New System.Drawing.Point(1088, 4)
        Me.btnSaveAs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.Size = New System.Drawing.Size(120, 41)
        Me.btnSaveAs.TabIndex = 2
        Me.btnSaveAs.Text = "Save As"
        Me.btnSaveAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveAs.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Parameters"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 300
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Step-1"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'lblTotalStep
        '
        Me.lblTotalStep.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalStep.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTotalStep.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalStep.Location = New System.Drawing.Point(0, 0)
        Me.lblTotalStep.Name = "lblTotalStep"
        Me.lblTotalStep.Size = New System.Drawing.Size(223, 29)
        Me.lblTotalStep.TabIndex = 5
        Me.lblTotalStep.Tag = "Total Steps: "
        Me.lblTotalStep.Text = "Total Steps: "
        Me.lblTotalStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RecipeEditor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Controls.Add(Me.tabEditorRecipe)
        Me.Controls.Add(Me.dgvChamber)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LabTitle)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "RecipeEditor"
        Me.Size = New System.Drawing.Size(1271, 810)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgvChamber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEditorRecipe.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabTitle As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnSaveAs As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnInsertStep As System.Windows.Forms.Button
    Friend WithEvents btnInsertCopiedStep As System.Windows.Forms.Button
    Friend WithEvents btnPasteStep As System.Windows.Forms.Button
    Friend WithEvents btnCopyStep As System.Windows.Forms.Button
    Friend WithEvents btnDeleteStep As System.Windows.Forms.Button
    Friend WithEvents btnAddStep As System.Windows.Forms.Button
    Friend WithEvents btnAddCopiedStep As System.Windows.Forms.Button
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tabEditorRecipe As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabAlignerRecipe As System.Windows.Forms.TabPage
    Friend WithEvents tabPM1Recipe As System.Windows.Forms.TabPage
    Friend WithEvents tabPM2Recipe As System.Windows.Forms.TabPage
    Friend WithEvents tabPM3Recipe As System.Windows.Forms.TabPage
    Friend WithEvents dgvChamber As System.Windows.Forms.DataGridView
    Friend WithEvents gcParameters As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gcStep1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnQuickView As System.Windows.Forms.Button
    Friend WithEvents lblTotalStep As System.Windows.Forms.Label
    Friend WithEvents cbxShowReworkFiles As System.Windows.Forms.CheckBox
End Class
