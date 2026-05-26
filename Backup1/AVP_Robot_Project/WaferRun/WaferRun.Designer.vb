<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WaferRun
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblItemsCount = New System.Windows.Forms.Label
        Me.btnApply = New AVPControls.AVPButton
        Me.lblFilter = New System.Windows.Forms.Label
        Me.btnRefresh = New AVP_Robot_Project.ButtonIGCGControl
        Me.dtFilter = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvWFList = New System.Windows.Forms.DataGridView
        Me.tabSystem = New System.Windows.Forms.TabPage
        Me.tabWaferRun = New System.Windows.Forms.CustomTabControl
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvWFList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabWaferRun.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRefresh)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvWFList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tabWaferRun)
        Me.SplitContainer1.Size = New System.Drawing.Size(1280, 652)
        Me.SplitContainer1.SplitterDistance = 490
        Me.SplitContainer1.TabIndex = 0
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
        Me.btnApply.Location = New System.Drawing.Point(391, 2)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnApply.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnApply.Size = New System.Drawing.Size(99, 32)
        Me.btnApply.TabIndex = 5
        Me.btnApply.Text = "Refresh"
        Me.btnApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'lblFilter
        '
        Me.lblFilter.BackColor = System.Drawing.Color.Transparent
        Me.lblFilter.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilter.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblFilter.Location = New System.Drawing.Point(28, -1)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(48, 25)
        Me.lblFilter.TabIndex = 4
        Me.lblFilter.Text = "Filter"
        Me.lblFilter.Visible = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.refresh
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefresh.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRefresh.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.refresh
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.ForeColor = System.Drawing.Color.Black
        Me.btnRefresh.Location = New System.Drawing.Point(0, -1)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.refresh
        Me.btnRefresh.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.refresh
        Me.btnRefresh.Size = New System.Drawing.Size(22, 22)
        Me.btnRefresh.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.On
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.refresh
        Me.btnRefresh.UseVisualStyleBackColor = True
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
        Me.dtFilter.Size = New System.Drawing.Size(174, 29)
        Me.dtFilter.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(490, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Wafer Run:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvWFList
        '
        Me.dgvWFList.AllowUserToAddRows = False
        Me.dgvWFList.AllowUserToDeleteRows = False
        Me.dgvWFList.AllowUserToResizeColumns = False
        Me.dgvWFList.AllowUserToResizeRows = False
        Me.dgvWFList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvWFList.ColumnHeadersHeight = 30
        Me.dgvWFList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvWFList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvWFList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWFList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvWFList.Location = New System.Drawing.Point(0, 36)
        Me.dgvWFList.MultiSelect = False
        Me.dgvWFList.Name = "dgvWFList"
        Me.dgvWFList.RowHeadersWidth = 20
        Me.dgvWFList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvWFList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWFList.Size = New System.Drawing.Size(490, 616)
        Me.dgvWFList.TabIndex = 2
        '
        'tabSystem
        '
        Me.tabSystem.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSystem.Location = New System.Drawing.Point(0, 36)
        Me.tabSystem.Name = "tabSystem"
        Me.tabSystem.Size = New System.Drawing.Size(786, 616)
        Me.tabSystem.TabIndex = 1
        Me.tabSystem.Text = "PMx"
        Me.tabSystem.UseVisualStyleBackColor = True
        '
        'tabWaferRun
        '
        Me.tabWaferRun.Controls.Add(Me.tabSystem)
        Me.tabWaferRun.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabWaferRun.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabWaferRun.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabWaferRun.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlText
        Me.tabWaferRun.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabWaferRun.DisplayStyleProvider.FocusTrack = False
        Me.tabWaferRun.DisplayStyleProvider.HotTrack = True
        Me.tabWaferRun.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabWaferRun.DisplayStyleProvider.Opacity = 1.0!
        Me.tabWaferRun.DisplayStyleProvider.Overlap = 0
        Me.tabWaferRun.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabWaferRun.DisplayStyleProvider.Radius = 10
        Me.tabWaferRun.DisplayStyleProvider.ShowTabCloser = False
        Me.tabWaferRun.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabWaferRun.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabWaferRun.HotTrack = True
        Me.tabWaferRun.Location = New System.Drawing.Point(0, 0)
        Me.tabWaferRun.Name = "tabWaferRun"
        Me.tabWaferRun.SelectedIndex = 0
        Me.tabWaferRun.Size = New System.Drawing.Size(786, 652)
        Me.tabWaferRun.TabIndex = 152
        '
        'WaferRun
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "WaferRun"
        Me.Size = New System.Drawing.Size(1280, 652)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvWFList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabWaferRun.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFilter As System.Windows.Forms.Label
    Friend WithEvents dtFilter As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRefresh As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnApply As AVPControls.AVPButton
    Friend WithEvents lblItemsCount As System.Windows.Forms.Label
    Friend WithEvents dgvWFList As System.Windows.Forms.DataGridView
    Friend WithEvents tabWaferRun As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabSystem As System.Windows.Forms.TabPage

End Class
