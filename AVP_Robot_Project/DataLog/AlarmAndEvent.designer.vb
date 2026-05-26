<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlarmAndEvent
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PnlCenter = New System.Windows.Forms.Panel
        Me.labRow = New System.Windows.Forms.Label
        Me.dgvUserLog = New System.Windows.Forms.DataGridView
        Me.gcTimestamp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gcType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gcUsername = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gcSource = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gcDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbxView = New System.Windows.Forms.GroupBox
        Me.btnExportCSV = New AVPControls.AVPButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFilterDescription = New AVP_Robot_Project.AVPTextBox
        Me.btnRefresh = New AVPControls.AVPButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.cmbUsername = New System.Windows.Forms.ComboBox
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PnlCenter.SuspendLayout()
        CType(Me.dgvUserLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxView.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlCenter
        '
        Me.PnlCenter.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PnlCenter.Controls.Add(Me.labRow)
        Me.PnlCenter.Controls.Add(Me.dgvUserLog)
        Me.PnlCenter.Controls.Add(Me.gbxView)
        Me.PnlCenter.Controls.Add(Me.lblStatus)
        Me.PnlCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlCenter.Location = New System.Drawing.Point(0, 0)
        Me.PnlCenter.Name = "PnlCenter"
        Me.PnlCenter.Size = New System.Drawing.Size(1272, 756)
        Me.PnlCenter.TabIndex = 0
        '
        'labRow
        '
        Me.labRow.BackColor = System.Drawing.SystemColors.Control
        Me.labRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labRow.Location = New System.Drawing.Point(705, 137)
        Me.labRow.Name = "labRow"
        Me.labRow.Size = New System.Drawing.Size(103, 17)
        Me.labRow.TabIndex = 2
        Me.labRow.Text = "12,345"
        Me.labRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvUserLog
        '
        Me.dgvUserLog.AllowUserToAddRows = False
        Me.dgvUserLog.AllowUserToDeleteRows = False
        Me.dgvUserLog.AllowUserToResizeColumns = False
        Me.dgvUserLog.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUserLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvUserLog.ColumnHeadersHeight = 35
        Me.dgvUserLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvUserLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gcTimestamp, Me.gcType, Me.gcUsername, Me.gcSource, Me.gcDescription})
        Me.dgvUserLog.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvUserLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUserLog.Location = New System.Drawing.Point(0, 128)
        Me.dgvUserLog.Name = "dgvUserLog"
        Me.dgvUserLog.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUserLog.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvUserLog.RowHeadersVisible = False
        Me.dgvUserLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvUserLog.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvUserLog.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvUserLog.RowTemplate.Height = 30
        Me.dgvUserLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUserLog.Size = New System.Drawing.Size(1272, 610)
        Me.dgvUserLog.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblStatus.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblStatus.Location = New System.Drawing.Point(0, 738)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(1272, 18)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Please wait while loading...."
        '
        'gbxView
        '
        Me.gbxView.BackColor = System.Drawing.Color.Transparent
        Me.gbxView.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgMsgBoxHeader
        Me.gbxView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gbxView.Controls.Add(Me.btnExportCSV)
        Me.gbxView.Controls.Add(Me.txtFilterDescription)
        Me.gbxView.Controls.Add(Me.Label5)
        Me.gbxView.Controls.Add(Me.btnRefresh)
        Me.gbxView.Controls.Add(Me.Label4)
        Me.gbxView.Controls.Add(Me.Label3)
        Me.gbxView.Controls.Add(Me.Label2)
        Me.gbxView.Controls.Add(Me.Label1)
        Me.gbxView.Controls.Add(Me.dtTo)
        Me.gbxView.Controls.Add(Me.dtFrom)
        Me.gbxView.Controls.Add(Me.cmbUsername)
        Me.gbxView.Controls.Add(Me.cmbType)
        Me.gbxView.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxView.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxView.ForeColor = System.Drawing.Color.White
        Me.gbxView.Location = New System.Drawing.Point(0, 0)
        Me.gbxView.Name = "gbxView"
        Me.gbxView.Size = New System.Drawing.Size(1272, 128)
        Me.gbxView.TabIndex = 0
        Me.gbxView.TabStop = False
        Me.gbxView.Text = "Filter"
        '
        'btnExportCSV
        '
        Me.btnExportCSV.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnExportCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportCSV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportCSV.FlatAppearance.BorderSize = 0
        Me.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportCSV.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportCSV.ForeColor = System.Drawing.Color.Black
        Me.btnExportCSV.Image = Global.AVP_Robot_Project.My.Resources.Resources.filesaveas
        Me.btnExportCSV.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnExportCSV.Location = New System.Drawing.Point(1131, 61)
        Me.btnExportCSV.Name = "btnExportCSV"
        Me.btnExportCSV.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnExportCSV.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnExportCSV.Size = New System.Drawing.Size(107, 32)
        Me.btnExportCSV.TabIndex = 11
        Me.btnExportCSV.Text = "Export"
        Me.btnExportCSV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportCSV.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(362, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 22)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Search:"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.Black
        Me.btnRefresh.Image = Global.AVP_Robot_Project.My.Resources.Resources.refresh
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnRefresh.Location = New System.Drawing.Point(1131, 17)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRefresh.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnRefresh.Size = New System.Drawing.Size(107, 32)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(837, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 22)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Username:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(362, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Type:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(48, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date To:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(48, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Date From:"
        '
        'dtTo
        '
        Me.dtTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtTo.CustomFormat = "MM/dd/yyyy HH:mm:ss tt"
        Me.dtTo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(159, 63)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(151, 29)
        Me.dtTo.TabIndex = 1
        '
        'dtFrom
        '
        Me.dtFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtFrom.CustomFormat = "MM/dd/yyyy HH:mm:ss tt"
        Me.dtFrom.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtFrom.Location = New System.Drawing.Point(159, 19)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(151, 29)
        Me.dtFrom.TabIndex = 1
        '
        'cmbUsername
        '
        Me.cmbUsername.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsername.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsername.FormattingEnabled = True
        Me.cmbUsername.Location = New System.Drawing.Point(945, 17)
        Me.cmbUsername.Name = "cmbUsername"
        Me.cmbUsername.Size = New System.Drawing.Size(132, 30)
        Me.cmbUsername.TabIndex = 0
        '
        'cmbType
        '
        Me.cmbType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(450, 17)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(129, 30)
        Me.cmbType.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle5.Format = "G"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn1.HeaderText = "Timestamp"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 140
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 140
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Source"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 250
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 357
        '
        'gcTimestamp
        '
        DataGridViewCellStyle2.Format = "G"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.gcTimestamp.DefaultCellStyle = DataGridViewCellStyle2
        Me.gcTimestamp.HeaderText = "Timestamp"
        Me.gcTimestamp.Name = "gcTimestamp"
        Me.gcTimestamp.ReadOnly = True
        Me.gcTimestamp.Width = 230
        '
        'gcType
        '
        Me.gcType.HeaderText = "Type"
        Me.gcType.Name = "gcType"
        Me.gcType.ReadOnly = True
        Me.gcType.Width = 120
        '
        'gcUsername
        '
        Me.gcUsername.HeaderText = "Username"
        Me.gcUsername.Name = "gcUsername"
        Me.gcUsername.ReadOnly = True
        '
        'gcSource
        '
        Me.gcSource.HeaderText = "Source"
        Me.gcSource.Name = "gcSource"
        Me.gcSource.ReadOnly = True
        Me.gcSource.Width = 140
        '
        'gcDescription
        '
        Me.gcDescription.HeaderText = "Description"
        Me.gcDescription.Name = "gcDescription"
        Me.gcDescription.ReadOnly = True
        Me.gcDescription.Width = 800
        '
        'txtFilterDescription
        '
        Me.txtFilterDescription.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtFilterDescription.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtFilterDescription.HideSelection = False
        Me.txtFilterDescription.Location = New System.Drawing.Point(450, 65)
        Me.txtFilterDescription.Name = "txtFilterDescription"
        Me.txtFilterDescription.Size = New System.Drawing.Size(627, 24)
        Me.txtFilterDescription.TabIndex = 10
        '
        'AlarmAndEvent
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.PnlCenter)
        Me.Name = "AlarmAndEvent"
        Me.Size = New System.Drawing.Size(1272, 756)
        Me.PnlCenter.ResumeLayout(False)
        CType(Me.dgvUserLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxView.ResumeLayout(False)
        Me.gbxView.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlCenter As System.Windows.Forms.Panel
    Friend WithEvents gbxView As System.Windows.Forms.GroupBox
    Friend WithEvents dgvUserLog As System.Windows.Forms.DataGridView
    Friend WithEvents cmbUsername As System.Windows.Forms.ComboBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents labRow As System.Windows.Forms.Label
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRefresh As AVPControls.AVPButton
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents gcTimestamp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gcType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gcUsername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gcSource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gcDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnExportCSV As AVPControls.AVPButton
    Friend WithEvents txtFilterDescription As AVP_Robot_Project.AVPTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
