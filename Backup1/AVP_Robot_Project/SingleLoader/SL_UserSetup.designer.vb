<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_UserSetup
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlSystemUsers = New System.Windows.Forms.Panel
        Me.DGVSystemUser = New System.Windows.Forms.DataGridView
        Me.gcSystemUsers = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.labUserDetail = New System.Windows.Forms.Label
        Me.pnlPermit = New System.Windows.Forms.Panel
        Me.treeAcessControlListView = New AVP_Robot_Project.TriStateTreeView
        Me.myImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.labScreenAccessList = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbGroup = New System.Windows.Forms.ComboBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.chkDisableUser = New System.Windows.Forms.CheckBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.labPassword = New System.Windows.Forms.Label
        Me.labGroup = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.labSystemUsers = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlSystemUsers.SuspendLayout()
        CType(Me.DGVSystemUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPermit.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSystemUsers
        '
        Me.pnlSystemUsers.BackColor = System.Drawing.Color.Transparent
        Me.pnlSystemUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSystemUsers.Controls.Add(Me.DGVSystemUser)
        Me.pnlSystemUsers.Controls.Add(Me.PictureBox3)
        Me.pnlSystemUsers.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSystemUsers.Location = New System.Drawing.Point(0, 55)
        Me.pnlSystemUsers.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlSystemUsers.Name = "pnlSystemUsers"
        Me.pnlSystemUsers.Size = New System.Drawing.Size(353, 633)
        Me.pnlSystemUsers.TabIndex = 0
        '
        'DGVSystemUser
        '
        Me.DGVSystemUser.AllowUserToAddRows = False
        Me.DGVSystemUser.AllowUserToDeleteRows = False
        Me.DGVSystemUser.AllowUserToResizeColumns = False
        Me.DGVSystemUser.AllowUserToResizeRows = False
        Me.DGVSystemUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVSystemUser.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DGVSystemUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVSystemUser.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVSystemUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGVSystemUser.ColumnHeadersVisible = False
        Me.DGVSystemUser.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gcSystemUsers})
        Me.DGVSystemUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DGVSystemUser.Dock = System.Windows.Forms.DockStyle.Right
        Me.DGVSystemUser.Location = New System.Drawing.Point(3, 0)
        Me.DGVSystemUser.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DGVSystemUser.MultiSelect = False
        Me.DGVSystemUser.Name = "DGVSystemUser"
        Me.DGVSystemUser.ReadOnly = True
        Me.DGVSystemUser.RowHeadersVisible = False
        Me.DGVSystemUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVSystemUser.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVSystemUser.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVSystemUser.RowTemplate.Height = 35
        Me.DGVSystemUser.Size = New System.Drawing.Size(347, 633)
        Me.DGVSystemUser.TabIndex = 1
        '
        'gcSystemUsers
        '
        Me.gcSystemUsers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.gcSystemUsers.HeaderText = "System Users"
        Me.gcSystemUsers.Name = "gcSystemUsers"
        Me.gcSystemUsers.ReadOnly = True
        Me.gcSystemUsers.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Location = New System.Drawing.Point(350, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(3, 633)
        Me.PictureBox3.TabIndex = 11
        Me.PictureBox3.TabStop = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.Control
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = Global.AVP_Robot_Project.My.Resources.Resources.user_add_48
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(39, 15)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(100, 38)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.AVP_Robot_Project.My.Resources.Resources.user_delete_48
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(199, 15)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(110, 38)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'labUserDetail
        '
        Me.labUserDetail.BackColor = System.Drawing.Color.Transparent
        Me.labUserDetail.Dock = System.Windows.Forms.DockStyle.Left
        Me.labUserDetail.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labUserDetail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.labUserDetail.Location = New System.Drawing.Point(347, 0)
        Me.labUserDetail.Name = "labUserDetail"
        Me.labUserDetail.Size = New System.Drawing.Size(952, 55)
        Me.labUserDetail.TabIndex = 3
        Me.labUserDetail.Text = "User Detail"
        Me.labUserDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPermit
        '
        Me.pnlPermit.BackColor = System.Drawing.Color.Transparent
        Me.pnlPermit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlPermit.Controls.Add(Me.treeAcessControlListView)
        Me.pnlPermit.Controls.Add(Me.labScreenAccessList)
        Me.pnlPermit.Controls.Add(Me.GroupBox1)
        Me.pnlPermit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPermit.Location = New System.Drawing.Point(353, 55)
        Me.pnlPermit.Name = "pnlPermit"
        Me.pnlPermit.Size = New System.Drawing.Size(919, 633)
        Me.pnlPermit.TabIndex = 0
        '
        'treeAcessControlListView
        '
        Me.treeAcessControlListView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.treeAcessControlListView.CheckBoxes = True
        Me.treeAcessControlListView.CheckBoxesTriState = True
        Me.treeAcessControlListView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.treeAcessControlListView.Editable = False
        Me.treeAcessControlListView.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeAcessControlListView.FullRowSelect = True
        Me.treeAcessControlListView.ImageIndex = 0
        Me.treeAcessControlListView.ImageList = Me.myImageList
        Me.treeAcessControlListView.Indent = 40
        Me.treeAcessControlListView.ItemHeight = 35
        Me.treeAcessControlListView.Location = New System.Drawing.Point(351, 68)
        Me.treeAcessControlListView.Name = "treeAcessControlListView"
        Me.treeAcessControlListView.SelectedImageIndex = 0
        Me.treeAcessControlListView.Size = New System.Drawing.Size(546, 537)
        Me.treeAcessControlListView.TabIndex = 2
        '
        'myImageList
        '
        Me.myImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.myImageList.ImageSize = New System.Drawing.Size(20, 20)
        Me.myImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'labScreenAccessList
        '
        Me.labScreenAccessList.AutoSize = True
        Me.labScreenAccessList.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labScreenAccessList.Location = New System.Drawing.Point(347, 25)
        Me.labScreenAccessList.Name = "labScreenAccessList"
        Me.labScreenAccessList.Size = New System.Drawing.Size(175, 22)
        Me.labScreenAccessList.TabIndex = 0
        Me.labScreenAccessList.Text = "Access Control List"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbGroup)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.chkDisableUser)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.labPassword)
        Me.GroupBox1.Controls.Add(Me.labGroup)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 208)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'cmbGroup
        '
        Me.cmbGroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroup.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGroup.FormattingEnabled = True
        Me.cmbGroup.Location = New System.Drawing.Point(116, 74)
        Me.cmbGroup.Name = "cmbGroup"
        Me.cmbGroup.Size = New System.Drawing.Size(180, 29)
        Me.cmbGroup.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(116, 115)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.ReadOnly = True
        Me.txtPassword.Size = New System.Drawing.Size(180, 29)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.Text = "OPERATOR"
        '
        'chkDisableUser
        '
        Me.chkDisableUser.AutoSize = True
        Me.chkDisableUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDisableUser.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDisableUser.Location = New System.Drawing.Point(116, 157)
        Me.chkDisableUser.Name = "chkDisableUser"
        Me.chkDisableUser.Size = New System.Drawing.Size(136, 27)
        Me.chkDisableUser.TabIndex = 3
        Me.chkDisableUser.Text = "Disable User"
        Me.chkDisableUser.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtName.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(116, 33)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(180, 32)
        Me.txtName.TabIndex = 0
        Me.txtName.Text = "OPERATOR"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 22)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Name"
        '
        'labPassword
        '
        Me.labPassword.AutoSize = True
        Me.labPassword.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labPassword.Location = New System.Drawing.Point(6, 115)
        Me.labPassword.Name = "labPassword"
        Me.labPassword.Size = New System.Drawing.Size(94, 22)
        Me.labPassword.TabIndex = 0
        Me.labPassword.Text = "Password"
        '
        'labGroup
        '
        Me.labGroup.AutoSize = True
        Me.labGroup.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labGroup.Location = New System.Drawing.Point(27, 75)
        Me.labGroup.Name = "labGroup"
        Me.labGroup.Size = New System.Drawing.Size(63, 22)
        Me.labGroup.TabIndex = 0
        Me.labGroup.Text = "Group"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.labUserDetail)
        Me.Panel2.Controls.Add(Me.labSystemUsers)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1272, 55)
        Me.Panel2.TabIndex = 10
        '
        'labSystemUsers
        '
        Me.labSystemUsers.BackColor = System.Drawing.Color.Transparent
        Me.labSystemUsers.Dock = System.Windows.Forms.DockStyle.Left
        Me.labSystemUsers.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labSystemUsers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.labSystemUsers.Location = New System.Drawing.Point(0, 0)
        Me.labSystemUsers.Name = "labSystemUsers"
        Me.labSystemUsers.Size = New System.Drawing.Size(347, 55)
        Me.labSystemUsers.TabIndex = 4
        Me.labSystemUsers.Text = "System Users"
        Me.labSystemUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.btnNew)
        Me.Panel3.Controls.Add(Me.btnSave)
        Me.Panel3.Controls.Add(Me.btnDelete)
        Me.Panel3.Controls.Add(Me.btnReset)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 688)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1272, 68)
        Me.Panel3.TabIndex = 24
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1272, 4)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.AVP_Robot_Project.My.Resources.Resources.add_user
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(791, 15)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 40)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.SystemColors.Control
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = Global.AVP_Robot_Project.My.Resources.Resources.agt_forum
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(1022, 15)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(100, 40)
        Me.btnReset.TabIndex = 8
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "System Users"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'UserSetup
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.WhitePanel
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.pnlPermit)
        Me.Controls.Add(Me.pnlSystemUsers)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "UserSetup"
        Me.Size = New System.Drawing.Size(1272, 756)
        Me.pnlSystemUsers.ResumeLayout(False)
        CType(Me.DGVSystemUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPermit.ResumeLayout(False)
        Me.pnlPermit.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSystemUsers As System.Windows.Forms.Panel
    Friend WithEvents DGVSystemUser As System.Windows.Forms.DataGridView
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents labUserDetail As System.Windows.Forms.Label
    Friend WithEvents pnlPermit As System.Windows.Forms.Panel
    Friend WithEvents labScreenAccessList As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents cmbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents chkDisableUser As System.Windows.Forms.CheckBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents labPassword As System.Windows.Forms.Label
    Friend WithEvents labGroup As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gcSystemUsers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents treeAcessControlListView As TriStateTreeView
    Friend WithEvents myImageList As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents labSystemUsers As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button

End Class
