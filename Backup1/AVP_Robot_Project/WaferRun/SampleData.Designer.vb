<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SampleData
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlLoadingStatus = New System.Windows.Forms.Panel
        Me.psgBar = New System.Windows.Forms.ProgressBar
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvStep = New System.Windows.Forms.DataGridView
        Me.grbSampleDetail = New System.Windows.Forms.GroupBox
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.lblTotalTime = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnExportHidenData = New AVPControls.AVPButton
        Me.btnHidenData = New AVPControls.AVPButton
        Me.btnHiddenCol = New AVPControls.AVPButton
        Me.btnExport = New AVPControls.AVPButton
        Me.btnExpAll = New AVPControls.AVPButton
        Me.pnlInfo = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblWaferID = New System.Windows.Forms.Label
        Me.lblRecipe = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnClearSelected = New AVPControls.AVPButton
        Me.btnShowGraph = New AVPControls.AVPButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.graphContainer = New System.Windows.Forms.SplitContainer
        Me.tvStepList = New System.Windows.Forms.TreeView
        Me.zgraphFromFile = New ZedGraph.ZedGraphControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnAddMore = New AVPControls.AVPButton
        Me.pnlDataSample = New System.Windows.Forms.Panel
        Me.rRecipeToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlLoadingStatus.SuspendLayout()
        CType(Me.dgvStep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbSampleDetail.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.graphContainer.Panel1.SuspendLayout()
        Me.graphContainer.Panel2.SuspendLayout()
        Me.graphContainer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlDataSample.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLoadingStatus
        '
        Me.pnlLoadingStatus.BackColor = System.Drawing.Color.Transparent
        Me.pnlLoadingStatus.Controls.Add(Me.psgBar)
        Me.pnlLoadingStatus.Controls.Add(Me.Label4)
        Me.pnlLoadingStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlLoadingStatus.Location = New System.Drawing.Point(0, 643)
        Me.pnlLoadingStatus.Name = "pnlLoadingStatus"
        Me.pnlLoadingStatus.Size = New System.Drawing.Size(1123, 21)
        Me.pnlLoadingStatus.TabIndex = 10
        Me.pnlLoadingStatus.Visible = False
        '
        'psgBar
        '
        Me.psgBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.psgBar.Location = New System.Drawing.Point(122, 0)
        Me.psgBar.Name = "psgBar"
        Me.psgBar.Size = New System.Drawing.Size(809, 21)
        Me.psgBar.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 21)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Loading..."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvStep
        '
        Me.dgvStep.AllowUserToAddRows = False
        Me.dgvStep.AllowUserToDeleteRows = False
        Me.dgvStep.AllowUserToResizeColumns = False
        Me.dgvStep.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvStep.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStep.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvStep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvStep.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStep.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvStep.ColumnHeadersHeight = 25
        Me.dgvStep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvStep.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvStep.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvStep.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgvStep.Location = New System.Drawing.Point(0, 0)
        Me.dgvStep.MultiSelect = False
        Me.dgvStep.Name = "dgvStep"
        Me.dgvStep.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStep.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvStep.RowHeadersWidth = 20
        Me.dgvStep.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvStep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStep.Size = New System.Drawing.Size(642, 171)
        Me.dgvStep.TabIndex = 0
        '
        'grbSampleDetail
        '
        Me.grbSampleDetail.Controls.Add(Me.dgvData)
        Me.grbSampleDetail.Controls.Add(Me.pnlButton)
        Me.grbSampleDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbSampleDetail.Location = New System.Drawing.Point(0, 171)
        Me.grbSampleDetail.Name = "grbSampleDetail"
        Me.grbSampleDetail.Size = New System.Drawing.Size(642, 339)
        Me.grbSampleDetail.TabIndex = 0
        Me.grbSampleDetail.TabStop = False
        Me.grbSampleDetail.Text = "Sample Detail"
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeColumns = False
        Me.dgvData.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvData.ColumnHeadersHeight = 25
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvData.EnableHeadersVisualStyles = False
        Me.dgvData.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgvData.Location = New System.Drawing.Point(3, 16)
        Me.dgvData.Name = "dgvData"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvData.RowHeadersWidth = 20
        Me.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvData.Size = New System.Drawing.Size(636, 270)
        Me.dgvData.TabIndex = 2
        '
        'pnlButton
        '
        Me.pnlButton.AutoScroll = True
        Me.pnlButton.Controls.Add(Me.lblTotalTime)
        Me.pnlButton.Controls.Add(Me.Label3)
        Me.pnlButton.Controls.Add(Me.btnExportHidenData)
        Me.pnlButton.Controls.Add(Me.btnHidenData)
        Me.pnlButton.Controls.Add(Me.btnHiddenCol)
        Me.pnlButton.Controls.Add(Me.btnExport)
        Me.pnlButton.Controls.Add(Me.btnExpAll)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButton.Location = New System.Drawing.Point(3, 286)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(636, 50)
        Me.pnlButton.TabIndex = 1
        '
        'lblTotalTime
        '
        Me.lblTotalTime.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalTime.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTotalTime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTime.ForeColor = System.Drawing.Color.Black
        Me.lblTotalTime.Location = New System.Drawing.Point(82, 0)
        Me.lblTotalTime.Name = "lblTotalTime"
        Me.lblTotalTime.Size = New System.Drawing.Size(70, 20)
        Me.lblTotalTime.TabIndex = 4
        Me.lblTotalTime.Text = ""
        Me.lblTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Total Time"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExportHidenData
        '
        Me.btnExportHidenData.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnExportHidenData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportHidenData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportHidenData.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExportHidenData.FlatAppearance.BorderSize = 0
        Me.btnExportHidenData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportHidenData.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportHidenData.Image = Global.AVP_Robot_Project.My.Resources.Resources.filesave
        Me.btnExportHidenData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportHidenData.Location = New System.Drawing.Point(152, 0)
        Me.btnExportHidenData.Name = "btnExportHidenData"
        Me.btnExportHidenData.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnExportHidenData.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnExportHidenData.Size = New System.Drawing.Size(165, 20)
        Me.btnExportHidenData.TabIndex = 2
        Me.btnExportHidenData.Text = "Export Hiden Data"
        Me.btnExportHidenData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportHidenData.UseVisualStyleBackColor = True
        '
        'btnHidenData
        '
        Me.btnHidenData.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHidenData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHidenData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHidenData.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnHidenData.FlatAppearance.BorderSize = 0
        Me.btnHidenData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHidenData.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHidenData.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnHidenData.Location = New System.Drawing.Point(317, 0)
        Me.btnHidenData.Name = "btnHidenData"
        Me.btnHidenData.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHidenData.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnHidenData.Size = New System.Drawing.Size(95, 20)
        Me.btnHidenData.TabIndex = 2
        Me.btnHidenData.Text = "Hiden Data"
        Me.btnHidenData.UseVisualStyleBackColor = True
        '
        'btnHiddenCol
        '
        Me.btnHiddenCol.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHiddenCol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHiddenCol.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHiddenCol.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnHiddenCol.FlatAppearance.BorderSize = 0
        Me.btnHiddenCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHiddenCol.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHiddenCol.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnHiddenCol.Location = New System.Drawing.Point(412, 0)
        Me.btnHiddenCol.Name = "btnHiddenCol"
        Me.btnHiddenCol.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHiddenCol.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnHiddenCol.Size = New System.Drawing.Size(150, 20)
        Me.btnHiddenCol.TabIndex = 2
        Me.btnHiddenCol.Text = "Show/Hide Columns"
        Me.btnHiddenCol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHiddenCol.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Image = Global.AVP_Robot_Project.My.Resources.Resources.filesave
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExport.Location = New System.Drawing.Point(562, 0)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnExport.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnExport.Size = New System.Drawing.Size(120, 20)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "Export Data"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnExpAll
        '
        Me.btnExpAll.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnExpAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExpAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExpAll.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExpAll.FlatAppearance.BorderSize = 0
        Me.btnExpAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpAll.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpAll.Image = Global.AVP_Robot_Project.My.Resources.Resources.filesave
        Me.btnExpAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExpAll.Location = New System.Drawing.Point(682, 0)
        Me.btnExpAll.Name = "btnExpAll"
        Me.btnExpAll.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnExpAll.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnExpAll.Size = New System.Drawing.Size(110, 20)
        Me.btnExpAll.TabIndex = 5
        Me.btnExpAll.Text = "Export All"
        Me.btnExpAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExpAll.UseVisualStyleBackColor = True
        '
        'pnlInfo
        '
        Me.pnlInfo.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgMsgBoxHeader
        Me.pnlInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlInfo.Controls.Add(Me.Panel3)
        Me.pnlInfo.Controls.Add(Me.Panel5)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 0)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(1123, 55)
        Me.pnlInfo.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.lblWaferID)
        Me.Panel3.Controls.Add(Me.lblRecipe)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(861, 55)
        Me.Panel3.TabIndex = 6
        '
        'lblWaferID
        '
        Me.lblWaferID.BackColor = System.Drawing.Color.Transparent
        Me.lblWaferID.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaferID.ForeColor = System.Drawing.Color.White
        Me.lblWaferID.Location = New System.Drawing.Point(95, 0)
        Me.lblWaferID.Name = "lblWaferID"
        Me.lblWaferID.Size = New System.Drawing.Size(760, 27)
        Me.lblWaferID.TabIndex = 4
        Me.lblWaferID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecipe
        '
        Me.lblRecipe.BackColor = System.Drawing.Color.Transparent
        Me.lblRecipe.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecipe.ForeColor = System.Drawing.Color.White
        Me.lblRecipe.Location = New System.Drawing.Point(80, 28)
        Me.lblRecipe.Name = "lblRecipe"
        Me.lblRecipe.Size = New System.Drawing.Size(775, 27)
        Me.lblRecipe.TabIndex = 1
        Me.lblRecipe.Tag = ""
        Me.lblRecipe.UseMnemonic = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 27)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "WaferID: "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 27)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Recipe:"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.Panel2)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(861, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(262, 55)
        Me.Panel5.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btnClearSelected)
        Me.Panel2.Controls.Add(Me.btnShowGraph)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(3, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(254, 45)
        Me.Panel2.TabIndex = 5
        '
        'btnClearSelected
        '
        Me.btnClearSelected.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClearSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearSelected.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearSelected.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnClearSelected.FlatAppearance.BorderSize = 0
        Me.btnClearSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSelected.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSelected.Image = Global.AVP_Robot_Project.My.Resources.Resources.Delete2
        Me.btnClearSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearSelected.Location = New System.Drawing.Point(0, 0)
        Me.btnClearSelected.Name = "btnClearSelected"
        Me.btnClearSelected.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClearSelected.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnClearSelected.Size = New System.Drawing.Size(136, 45)
        Me.btnClearSelected.TabIndex = 0
        Me.btnClearSelected.Text = "Clear Selected"
        Me.btnClearSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClearSelected.UseVisualStyleBackColor = True
        Me.btnClearSelected.Visible = False
        '
        'btnShowGraph
        '
        Me.btnShowGraph.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnShowGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowGraph.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowGraph.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnShowGraph.FlatAppearance.BorderSize = 0
        Me.btnShowGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowGraph.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowGraph.Image = Global.AVP_Robot_Project.My.Resources.Resources.downarrowmain
        Me.btnShowGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowGraph.Location = New System.Drawing.Point(137, 0)
        Me.btnShowGraph.Name = "btnShowGraph"
        Me.btnShowGraph.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnShowGraph.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnShowGraph.Size = New System.Drawing.Size(117, 45)
        Me.btnShowGraph.TabIndex = 0
        Me.btnShowGraph.Text = "Graph View"
        Me.btnShowGraph.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShowGraph.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Location = New System.Drawing.Point(0, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(257, 5)
        Me.Label8.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.Location = New System.Drawing.Point(257, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(5, 50)
        Me.Label6.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(262, 5)
        Me.Label7.TabIndex = 9
        '
        'graphContainer
        '
        Me.graphContainer.Location = New System.Drawing.Point(22, 108)
        Me.graphContainer.Name = "graphContainer"
        '
        'graphContainer.Panel1
        '
        Me.graphContainer.Panel1.Controls.Add(Me.tvStepList)
        '
        'graphContainer.Panel2
        '
        Me.graphContainer.Panel2.Controls.Add(Me.zgraphFromFile)
        Me.graphContainer.Panel2.Controls.Add(Me.Panel1)
        Me.graphContainer.Size = New System.Drawing.Size(430, 446)
        Me.graphContainer.SplitterDistance = 162
        Me.graphContainer.TabIndex = 11
        '
        'tvStepList
        '
        Me.tvStepList.CheckBoxes = True
        Me.tvStepList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tvStepList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvStepList.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvStepList.ItemHeight = 20
        Me.tvStepList.Location = New System.Drawing.Point(0, 0)
        Me.tvStepList.Name = "tvStepList"
        Me.tvStepList.ShowLines = False
        Me.tvStepList.Size = New System.Drawing.Size(162, 446)
        Me.tvStepList.TabIndex = 0
        '
        'zgraphFromFile
        '
        Me.zgraphFromFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zgraphFromFile.EditButtons = System.Windows.Forms.MouseButtons.Left
        Me.zgraphFromFile.Location = New System.Drawing.Point(0, 0)
        Me.zgraphFromFile.Name = "zgraphFromFile"
        Me.zgraphFromFile.PanModifierKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)
        Me.zgraphFromFile.ScrollGrace = 0
        Me.zgraphFromFile.ScrollMaxX = 0
        Me.zgraphFromFile.ScrollMaxY = 0
        Me.zgraphFromFile.ScrollMaxY2 = 0
        Me.zgraphFromFile.ScrollMinX = 0
        Me.zgraphFromFile.ScrollMinY = 0
        Me.zgraphFromFile.ScrollMinY2 = 0
        Me.zgraphFromFile.Size = New System.Drawing.Size(264, 422)
        Me.zgraphFromFile.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAddMore)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 422)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(264, 24)
        Me.Panel1.TabIndex = 5
        '
        'btnAddMore
        '
        Me.btnAddMore.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAddMore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddMore.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddMore.FlatAppearance.BorderSize = 0
        Me.btnAddMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddMore.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMore.Location = New System.Drawing.Point(134, 0)
        Me.btnAddMore.Name = "btnAddMore"
        Me.btnAddMore.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAddMore.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnAddMore.Size = New System.Drawing.Size(130, 24)
        Me.btnAddMore.TabIndex = 5
        Me.btnAddMore.Text = "Compare Wafer"
        Me.btnAddMore.UseVisualStyleBackColor = True
        '
        'pnlDataSample
        '
        Me.pnlDataSample.Controls.Add(Me.grbSampleDetail)
        Me.pnlDataSample.Controls.Add(Me.dgvStep)
        Me.pnlDataSample.Location = New System.Drawing.Point(476, 108)
        Me.pnlDataSample.Name = "pnlDataSample"
        Me.pnlDataSample.Size = New System.Drawing.Size(642, 510)
        Me.pnlDataSample.TabIndex = 12
        '
        'SampleData
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.pnlDataSample)
        Me.Controls.Add(Me.graphContainer)
        Me.Controls.Add(Me.pnlLoadingStatus)
        Me.Controls.Add(Me.pnlInfo)
        Me.Name = "SampleData"
        Me.Size = New System.Drawing.Size(1123, 664)
        Me.pnlLoadingStatus.ResumeLayout(False)
        CType(Me.dgvStep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbSampleDetail.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlInfo.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.graphContainer.Panel1.ResumeLayout(False)
        Me.graphContainer.Panel2.ResumeLayout(False)
        Me.graphContainer.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlDataSample.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLoadingStatus As System.Windows.Forms.Panel
    Friend WithEvents psgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents lblRecipe As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnClearSelected As AVPControls.AVPButton
    Friend WithEvents btnShowGraph As AVPControls.AVPButton
    Friend WithEvents dgvStep As System.Windows.Forms.DataGridView
    Friend WithEvents grbSampleDetail As System.Windows.Forms.GroupBox
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents graphContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents tvStepList As System.Windows.Forms.TreeView
    Friend WithEvents zgraphFromFile As ZedGraph.ZedGraphControl
    Friend WithEvents pnlDataSample As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnExport As AVPControls.AVPButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAddMore As AVPControls.AVPButton
    Friend WithEvents btnHiddenCol As AVPControls.AVPButton
    Friend WithEvents lblTotalTime As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblWaferID As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnExpAll As AVPControls.AVPButton
    Friend WithEvents rRecipeToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnHidenData As AVPControls.AVPButton
    Friend WithEvents btnExportHidenData As AVPControls.AVPButton

End Class
