Imports AVP_Robot_Project.ConstantAndEnum
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrWaferFlow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usrWaferFlow))
        Me.labTitle = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtRepeatCount = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnEnd = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.pnlEquipmentRight = New System.Windows.Forms.Panel
        Me.UsrEquipmentNameAnyIBE = New AVP_Robot_Project.usrEquipmentName
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.groupbox = New System.Windows.Forms.GroupBox
        Me.pnlEquipmentLeft = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblPadding1 = New System.Windows.Forms.Label
        Me.lblPadding2 = New System.Windows.Forms.Label
        Me.btnDown = New System.Windows.Forms.Button
        Me.btnRemoveAll = New System.Windows.Forms.Button
        Me.btnUp = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnSaveAs = New System.Windows.Forms.Button
        Me.usrEquipmentNameAligner = New AVP_Robot_Project.usrEquipmentName
        Me.UsrEquipmentNameChamber3 = New AVP_Robot_Project.usrEquipmentName
        Me.UsrEquipmentNameChamber2 = New AVP_Robot_Project.usrEquipmentName
        Me.UsrEquipmentNameChamber1 = New AVP_Robot_Project.usrEquipmentName
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsrEquipmentNameAnyPVD = New AVP_Robot_Project.usrEquipmentName
        Me.cbxShowReworkFiles = New System.Windows.Forms.CheckBox
        Me.GroupBox2.SuspendLayout()
        Me.groupbox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.labTitle.TabIndex = 8
        Me.labTitle.Tag = "New Wafer Flow"
        Me.labTitle.Text = "New Wafer Flow"
        Me.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.labTitle.UseMnemonic = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtRepeatCount)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnEnd)
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Controls.Add(Me.btnStart)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(430, 598)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(341, 156)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Loop"
        '
        'txtRepeatCount
        '
        Me.txtRepeatCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRepeatCount.BackColor = System.Drawing.SystemColors.Window
        Me.txtRepeatCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRepeatCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRepeatCount.Enabled = False
        Me.txtRepeatCount.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepeatCount.Location = New System.Drawing.Point(125, 45)
        Me.txtRepeatCount.MaxLength = 2
        Me.txtRepeatCount.Multiline = True
        Me.txtRepeatCount.Name = "txtRepeatCount"
        Me.txtRepeatCount.ReadOnly = True
        Me.txtRepeatCount.Size = New System.Drawing.Size(90, 38)
        Me.txtRepeatCount.TabIndex = 10
        Me.txtRepeatCount.Text = "2"
        Me.txtRepeatCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(335, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Repeat Count"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEnd
        '
        Me.btnEnd.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnEnd.BackColor = System.Drawing.SystemColors.Info
        Me.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnd.Enabled = False
        Me.btnEnd.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnd.Location = New System.Drawing.Point(235, 39)
        Me.btnEnd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(95, 46)
        Me.btnEnd.TabIndex = 0
        Me.btnEnd.Text = "End"
        Me.btnEnd.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Info
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Enabled = False
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(84, 90)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(172, 46)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnStart
        '
        Me.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnStart.BackColor = System.Drawing.SystemColors.Info
        Me.btnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStart.Enabled = False
        Me.btnStart.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(13, 41)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(95, 46)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'pnlEquipmentRight
        '
        Me.pnlEquipmentRight.AutoScroll = True
        Me.pnlEquipmentRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.pnlEquipmentRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEquipmentRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEquipmentRight.Location = New System.Drawing.Point(771, 94)
        Me.pnlEquipmentRight.Name = "pnlEquipmentRight"
        Me.pnlEquipmentRight.Size = New System.Drawing.Size(490, 660)
        Me.pnlEquipmentRight.TabIndex = 18
        '
        'UsrEquipmentNameAnyIBE
        '
        Me.UsrEquipmentNameAnyIBE.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UsrEquipmentNameAnyIBE.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.UsrEquipmentNameAnyIBE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsrEquipmentNameAnyIBE.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.UsrEquipmentNameAnyIBE.Header = "IBE"
        Me.UsrEquipmentNameAnyIBE.Index = 0
        Me.UsrEquipmentNameAnyIBE.IsProcessingStep = False
        Me.UsrEquipmentNameAnyIBE.Location = New System.Drawing.Point(33, 367)
        Me.UsrEquipmentNameAnyIBE.Name = "UsrEquipmentNameAnyIBE"
        Me.UsrEquipmentNameAnyIBE.Size = New System.Drawing.Size(380, 47)
        Me.UsrEquipmentNameAnyIBE.TabIndex = 0
        Me.UsrEquipmentNameAnyIBE.WaferFlowForm = Nothing
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescription.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(206, 14)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(964, 29)
        Me.txtDescription.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(95, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 22)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Description:"
        '
        'groupbox
        '
        Me.groupbox.Controls.Add(Me.pnlEquipmentLeft)
        Me.groupbox.Dock = System.Windows.Forms.DockStyle.Left
        Me.groupbox.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupbox.Location = New System.Drawing.Point(10, 94)
        Me.groupbox.Name = "groupbox"
        Me.groupbox.Size = New System.Drawing.Size(420, 660)
        Me.groupbox.TabIndex = 0
        Me.groupbox.TabStop = False
        Me.groupbox.Text = "Equipments"
        '
        'pnlEquipmentLeft
        '
        Me.pnlEquipmentLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEquipmentLeft.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEquipmentLeft.Location = New System.Drawing.Point(3, 25)
        Me.pnlEquipmentLeft.Name = "pnlEquipmentLeft"
        Me.pnlEquipmentLeft.Size = New System.Drawing.Size(414, 632)
        Me.pnlEquipmentLeft.TabIndex = 18
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtDescription)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 754)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1271, 56)
        Me.Panel1.TabIndex = 21
        Me.Panel1.Visible = False
        '
        'lblPadding1
        '
        Me.lblPadding1.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPadding1.Location = New System.Drawing.Point(0, 94)
        Me.lblPadding1.Name = "lblPadding1"
        Me.lblPadding1.Size = New System.Drawing.Size(10, 660)
        Me.lblPadding1.TabIndex = 22
        '
        'lblPadding2
        '
        Me.lblPadding2.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblPadding2.Location = New System.Drawing.Point(1261, 94)
        Me.lblPadding2.Name = "lblPadding2"
        Me.lblPadding2.Size = New System.Drawing.Size(10, 660)
        Me.lblPadding2.TabIndex = 23
        '
        'btnDown
        '
        Me.btnDown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDown.BackColor = System.Drawing.SystemColors.Info
        Me.btnDown.BackgroundImage = CType(resources.GetObject("btnDown.BackgroundImage"), System.Drawing.Image)
        Me.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDown.Location = New System.Drawing.Point(675, 374)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(61, 87)
        Me.btnDown.TabIndex = 10
        Me.btnDown.UseVisualStyleBackColor = False
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRemoveAll.BackColor = System.Drawing.SystemColors.Info
        Me.btnRemoveAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveAll.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveAll.Image = Global.AVP_Robot_Project.My.Resources.Resources.RecycleBin
        Me.btnRemoveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveAll.Location = New System.Drawing.Point(483, 424)
        Me.btnRemoveAll.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(165, 57)
        Me.btnRemoveAll.TabIndex = 0
        Me.btnRemoveAll.Text = "   Remove All"
        Me.btnRemoveAll.UseVisualStyleBackColor = False
        '
        'btnUp
        '
        Me.btnUp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnUp.BackColor = System.Drawing.SystemColors.Info
        Me.btnUp.BackgroundImage = CType(resources.GetObject("btnUp.BackgroundImage"), System.Drawing.Image)
        Me.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUp.Location = New System.Drawing.Point(675, 233)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(61, 87)
        Me.btnUp.TabIndex = 10
        Me.btnUp.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRemove.BackColor = System.Drawing.SystemColors.Info
        Me.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemove.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Image = Global.AVP_Robot_Project.My.Resources.Resources.Previous
        Me.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove.Location = New System.Drawing.Point(483, 312)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(165, 57)
        Me.btnRemove.TabIndex = 0
        Me.btnRemove.Text = "Remove    "
        Me.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Info
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = Global.AVP_Robot_Project.My.Resources.Resources.Forward
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.Location = New System.Drawing.Point(483, 200)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(165, 57)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "   Add     "
        Me.btnAdd.UseVisualStyleBackColor = False
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
        Me.Panel2.TabIndex = 13
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
        Me.btnNew.Text = "  New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.BackColor = System.Drawing.SystemColors.Info
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
        'usrEquipmentNameAligner
        '
        Me.usrEquipmentNameAligner.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.usrEquipmentNameAligner.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.usrEquipmentNameAligner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.usrEquipmentNameAligner.Header = "Aligner"
        Me.usrEquipmentNameAligner.Index = 0
        Me.usrEquipmentNameAligner.IsProcessingStep = False
        Me.usrEquipmentNameAligner.Location = New System.Drawing.Point(3, 12)
        Me.usrEquipmentNameAligner.Name = "usrEquipmentNameAligner"
        Me.usrEquipmentNameAligner.Size = New System.Drawing.Size(290, 47)
        Me.usrEquipmentNameAligner.TabIndex = 10
        Me.usrEquipmentNameAligner.WaferFlowForm = Nothing
        '
        'UsrEquipmentNameChamber3
        '
        Me.UsrEquipmentNameChamber3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UsrEquipmentNameChamber3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.UsrEquipmentNameChamber3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsrEquipmentNameChamber3.Header = "Chamber3"
        Me.UsrEquipmentNameChamber3.Index = 0
        Me.UsrEquipmentNameChamber3.IsProcessingStep = False
        Me.UsrEquipmentNameChamber3.Location = New System.Drawing.Point(16, 218)
        Me.UsrEquipmentNameChamber3.Name = "UsrEquipmentNameChamber3"
        Me.UsrEquipmentNameChamber3.Size = New System.Drawing.Size(290, 47)
        Me.UsrEquipmentNameChamber3.TabIndex = 10
        Me.UsrEquipmentNameChamber3.WaferFlowForm = Nothing
        '
        'UsrEquipmentNameChamber2
        '
        Me.UsrEquipmentNameChamber2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UsrEquipmentNameChamber2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.UsrEquipmentNameChamber2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsrEquipmentNameChamber2.Header = "Chamber2"
        Me.UsrEquipmentNameChamber2.Index = 0
        Me.UsrEquipmentNameChamber2.IsProcessingStep = False
        Me.UsrEquipmentNameChamber2.Location = New System.Drawing.Point(16, 150)
        Me.UsrEquipmentNameChamber2.Name = "UsrEquipmentNameChamber2"
        Me.UsrEquipmentNameChamber2.Size = New System.Drawing.Size(290, 47)
        Me.UsrEquipmentNameChamber2.TabIndex = 10
        Me.UsrEquipmentNameChamber2.WaferFlowForm = Nothing
        '
        'UsrEquipmentNameChamber1
        '
        Me.UsrEquipmentNameChamber1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UsrEquipmentNameChamber1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.UsrEquipmentNameChamber1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsrEquipmentNameChamber1.Header = "Chamber1"
        Me.UsrEquipmentNameChamber1.Index = 0
        Me.UsrEquipmentNameChamber1.IsProcessingStep = False
        Me.UsrEquipmentNameChamber1.Location = New System.Drawing.Point(16, 81)
        Me.UsrEquipmentNameChamber1.Name = "UsrEquipmentNameChamber1"
        Me.UsrEquipmentNameChamber1.Size = New System.Drawing.Size(290, 47)
        Me.UsrEquipmentNameChamber1.TabIndex = 10
        Me.UsrEquipmentNameChamber1.WaferFlowForm = Nothing
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Recipe"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Water Flow"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 320
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Slot No"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'UsrEquipmentNameAnyPVD
        '
        Me.UsrEquipmentNameAnyPVD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UsrEquipmentNameAnyPVD.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.UsrEquipmentNameAnyPVD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsrEquipmentNameAnyPVD.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.UsrEquipmentNameAnyPVD.Header = "Any PVD"
        Me.UsrEquipmentNameAnyPVD.Index = 0
        Me.UsrEquipmentNameAnyPVD.IsProcessingStep = False
        Me.UsrEquipmentNameAnyPVD.Location = New System.Drawing.Point(29, 238)
        Me.UsrEquipmentNameAnyPVD.Name = "UsrEquipmentNameAnyPVD"
        Me.UsrEquipmentNameAnyPVD.Size = New System.Drawing.Size(380, 47)
        Me.UsrEquipmentNameAnyPVD.TabIndex = 1
        Me.UsrEquipmentNameAnyPVD.WaferFlowForm = Nothing
        '
        'cbxShowReworkFiles
        '
        Me.cbxShowReworkFiles.AccessibleDescription = ""
        Me.cbxShowReworkFiles.AutoSize = True
        Me.cbxShowReworkFiles.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbxShowReworkFiles.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxShowReworkFiles.Location = New System.Drawing.Point(483, 143)
        Me.cbxShowReworkFiles.Name = "cbxShowReworkFiles"
        Me.cbxShowReworkFiles.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbxShowReworkFiles.Size = New System.Drawing.Size(185, 27)
        Me.cbxShowReworkFiles.TabIndex = 71
        Me.cbxShowReworkFiles.Text = "Show Rework Files"
        Me.cbxShowReworkFiles.UseVisualStyleBackColor = True
        '
        'usrWaferFlow
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Controls.Add(Me.cbxShowReworkFiles)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pnlEquipmentRight)
        Me.Controls.Add(Me.lblPadding2)
        Me.Controls.Add(Me.groupbox)
        Me.Controls.Add(Me.lblPadding1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnRemoveAll)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.labTitle)
        Me.DoubleBuffered = True
        Me.Name = "usrWaferFlow"
        Me.Size = New System.Drawing.Size(1271, 810)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.groupbox.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnSaveAs As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents labTitle As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEnd As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents txtRepeatCount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents usrEquipmentNameAligner As AVP_Robot_Project.usrEquipmentName
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlEquipmentRight As System.Windows.Forms.Panel
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UsrEquipmentNameChamber3 As AVP_Robot_Project.usrEquipmentName
    Friend WithEvents UsrEquipmentNameChamber2 As AVP_Robot_Project.usrEquipmentName
    Friend WithEvents UsrEquipmentNameChamber1 As AVP_Robot_Project.usrEquipmentName
    Friend WithEvents groupbox As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblPadding1 As System.Windows.Forms.Label
    Friend WithEvents lblPadding2 As System.Windows.Forms.Label
    Friend WithEvents pnlEquipmentLeft As System.Windows.Forms.Panel
    Friend WithEvents UsrEquipmentNameAnyIBE As AVP_Robot_Project.usrEquipmentName
    Friend WithEvents UsrEquipmentNameAnyPVD As AVP_Robot_Project.usrEquipmentName
    Friend WithEvents cbxShowReworkFiles As System.Windows.Forms.CheckBox
End Class
