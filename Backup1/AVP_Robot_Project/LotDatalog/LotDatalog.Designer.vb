<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LotDatalog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblItemsCount = New System.Windows.Forms.Label
        Me.btnApply = New AVPControls.AVPButton
        Me.btnRefresh = New AVP_Robot_Project.SL_CustomButton
        Me.dtFilter = New System.Windows.Forms.DateTimePicker
        Me.dgvLotList = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabLotDatalog = New System.Windows.Forms.CustomTabControl
        Me.tabSystem = New System.Windows.Forms.TabPage
        Me.dtgLotDatalogInfo = New System.Windows.Forms.DataGridView
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvLotList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLotDatalog.SuspendLayout()
        Me.tabSystem.SuspendLayout()
        CType(Me.dtgLotDatalogInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblItemsCount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnApply)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRefresh)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvLotList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabLotDatalog)
        Me.SplitContainer1.Size = New System.Drawing.Size(1280, 521)
        Me.SplitContainer1.SplitterDistance = 420
        Me.SplitContainer1.TabIndex = 1
        '
        'lblItemsCount
        '
        Me.lblItemsCount.BackColor = System.Drawing.Color.Transparent
        Me.lblItemsCount.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblItemsCount.ForeColor = System.Drawing.Color.White
        Me.lblItemsCount.Location = New System.Drawing.Point(167, 8)
        Me.lblItemsCount.Name = "lblItemsCount"
        Me.lblItemsCount.Size = New System.Drawing.Size(43, 19)
        Me.lblItemsCount.TabIndex = 6
        Me.lblItemsCount.Text = "00"
        Me.lblItemsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.Color.Transparent
        Me.btnApply.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnApply.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApply.FlatAppearance.BorderSize = 0
        Me.btnApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApply.Font = New System.Drawing.Font("Arial", 11.25!)
        Me.btnApply.Image = Global.AVP_Robot_Project.My.Resources.Resources.refresh
        Me.btnApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApply.Location = New System.Drawing.Point(336, 2)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnApply.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnApply.Size = New System.Drawing.Size(85, 32)
        Me.btnApply.TabIndex = 5
        Me.btnApply.Text = "Refresh"
        Me.btnApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRefresh.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.ErrorImage = Nothing
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(112, 0)
        Me.btnRefresh.MessageBoxText = Nothing
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.OffImage = Nothing
        Me.btnRefresh.OnImage = Nothing
        Me.btnRefresh.Size = New System.Drawing.Size(49, 26)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UnknownImage = Nothing
        Me.btnRefresh.UseVisualStyleBackColor = True
        Me.btnRefresh.ValueToBeSend = "On"
        Me.btnRefresh.Visible = False
        '
        'dtFilter
        '
        Me.dtFilter.CalendarFont = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtFilter.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold)
        Me.dtFilter.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFilter.Location = New System.Drawing.Point(211, 3)
        Me.dtFilter.Name = "dtFilter"
        Me.dtFilter.Size = New System.Drawing.Size(128, 29)
        Me.dtFilter.TabIndex = 3
        '
        'dgvLotList
        '
        Me.dgvLotList.AllowUserToAddRows = False
        Me.dgvLotList.AllowUserToDeleteRows = False
        Me.dgvLotList.AllowUserToResizeColumns = False
        Me.dgvLotList.AllowUserToResizeRows = False
        Me.dgvLotList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvLotList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLotList.ColumnHeadersVisible = False
        Me.dgvLotList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvLotList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLotList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLotList.Location = New System.Drawing.Point(0, 36)
        Me.dgvLotList.MultiSelect = False
        Me.dgvLotList.Name = "dgvLotList"
        Me.dgvLotList.ReadOnly = True
        Me.dgvLotList.RowHeadersVisible = False
        Me.dgvLotList.RowHeadersWidth = 20
        Me.dgvLotList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvLotList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgvLotList.RowTemplate.DividerHeight = 1
        Me.dgvLotList.RowTemplate.Height = 40
        Me.dgvLotList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLotList.Size = New System.Drawing.Size(420, 485)
        Me.dgvLotList.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(420, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Lots:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabLotDatalog
        '
        Me.tabLotDatalog.Controls.Add(Me.tabSystem)
        Me.tabLotDatalog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabLotDatalog.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabLotDatalog.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabLotDatalog.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.tabLotDatalog.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabLotDatalog.DisplayStyleProvider.FocusTrack = False
        Me.tabLotDatalog.DisplayStyleProvider.HotTrack = True
        Me.tabLotDatalog.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabLotDatalog.DisplayStyleProvider.Opacity = 1.0!
        Me.tabLotDatalog.DisplayStyleProvider.Overlap = 0
        Me.tabLotDatalog.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabLotDatalog.DisplayStyleProvider.Radius = 10
        Me.tabLotDatalog.DisplayStyleProvider.ShowTabCloser = False
        Me.tabLotDatalog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabLotDatalog.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabLotDatalog.HotTrack = True
        Me.tabLotDatalog.Location = New System.Drawing.Point(0, 0)
        Me.tabLotDatalog.Name = "tabLotDatalog"
        Me.tabLotDatalog.SelectedIndex = 0
        Me.tabLotDatalog.Size = New System.Drawing.Size(856, 521)
        Me.tabLotDatalog.TabIndex = 152
        '
        'tabSystem
        '
        Me.tabSystem.Controls.Add(Me.dtgLotDatalogInfo)
        Me.tabSystem.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSystem.Location = New System.Drawing.Point(0, 36)
        Me.tabSystem.Name = "tabSystem"
        Me.tabSystem.Size = New System.Drawing.Size(856, 485)
        Me.tabSystem.TabIndex = 1
        Me.tabSystem.Text = "Lot Info"
        Me.tabSystem.UseVisualStyleBackColor = True
        '
        'dtgLotDatalogInfo
        '
        Me.dtgLotDatalogInfo.AllowUserToAddRows = False
        Me.dtgLotDatalogInfo.AllowUserToDeleteRows = False
        Me.dtgLotDatalogInfo.AllowUserToResizeColumns = False
        Me.dtgLotDatalogInfo.AllowUserToResizeRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        Me.dtgLotDatalogInfo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgLotDatalogInfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dtgLotDatalogInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgLotDatalogInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgLotDatalogInfo.Location = New System.Drawing.Point(0, 0)
        Me.dtgLotDatalogInfo.Name = "dtgLotDatalogInfo"
        Me.dtgLotDatalogInfo.ReadOnly = True
        Me.dtgLotDatalogInfo.RowHeadersVisible = False
        Me.dtgLotDatalogInfo.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dtgLotDatalogInfo.RowTemplate.DividerHeight = 1
        Me.dtgLotDatalogInfo.RowTemplate.Height = 40
        Me.dtgLotDatalogInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgLotDatalogInfo.Size = New System.Drawing.Size(856, 485)
        Me.dtgLotDatalogInfo.TabIndex = 0
        '
        'LotDatalog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "LotDatalog"
        Me.Size = New System.Drawing.Size(1280, 521)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvLotList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLotDatalog.ResumeLayout(False)
        Me.tabSystem.ResumeLayout(False)
        CType(Me.dtgLotDatalogInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dtFilter As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvLotList As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabLotDatalog As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabSystem As System.Windows.Forms.TabPage
    Friend WithEvents dtgLotDatalogInfo As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefresh As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnApply As AVPControls.AVPButton
    Friend WithEvents lblItemsCount As System.Windows.Forms.Label

End Class
