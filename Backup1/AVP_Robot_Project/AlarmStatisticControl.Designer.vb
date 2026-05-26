<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlarmStatisticControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.zgraph = New ZedGraph.ZedGraphControl
        Me.btnRefresh = New AVPControls.AVPButton
        Me.lblStatus = New System.Windows.Forms.Label
        Me.gbxView = New System.Windows.Forms.GroupBox
        Me.btnExport = New AVPControls.AVPButton
        Me.btnPrevious = New AVPControls.AVPButton
        Me.btnNext = New AVPControls.AVPButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.PnlCenter = New System.Windows.Forms.Panel
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbxView.SuspendLayout()
        Me.PnlCenter.SuspendLayout()
        Me.SuspendLayout()
        '
        'zgraph
        '
        Me.zgraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zgraph.EditButtons = System.Windows.Forms.MouseButtons.Left
        Me.zgraph.IsEnableWheelZoom = False
        Me.zgraph.Location = New System.Drawing.Point(0, 59)
        Me.zgraph.Name = "zgraph"
        Me.zgraph.PanModifierKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)
        Me.zgraph.ScrollGrace = 0
        Me.zgraph.ScrollMaxX = 0
        Me.zgraph.ScrollMaxY = 0
        Me.zgraph.ScrollMaxY2 = 0
        Me.zgraph.ScrollMinX = 0
        Me.zgraph.ScrollMinY = 0
        Me.zgraph.ScrollMinY2 = 0
        Me.zgraph.Size = New System.Drawing.Size(1272, 679)
        Me.zgraph.TabIndex = 4
        Me.zgraph.ZoomButtons = System.Windows.Forms.MouseButtons.None
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
        Me.btnRefresh.Location = New System.Drawing.Point(702, 16)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRefresh.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnRefresh.Size = New System.Drawing.Size(107, 32)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
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
        Me.gbxView.Controls.Add(Me.btnExport)
        Me.gbxView.Controls.Add(Me.btnPrevious)
        Me.gbxView.Controls.Add(Me.btnNext)
        Me.gbxView.Controls.Add(Me.btnRefresh)
        Me.gbxView.Controls.Add(Me.Label2)
        Me.gbxView.Controls.Add(Me.Label1)
        Me.gbxView.Controls.Add(Me.dtTo)
        Me.gbxView.Controls.Add(Me.dtFrom)
        Me.gbxView.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxView.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxView.ForeColor = System.Drawing.Color.White
        Me.gbxView.Location = New System.Drawing.Point(0, 0)
        Me.gbxView.Name = "gbxView"
        Me.gbxView.Size = New System.Drawing.Size(1272, 59)
        Me.gbxView.TabIndex = 0
        Me.gbxView.TabStop = False
        Me.gbxView.Text = "Filter"
        '
        'btnExport
        '
        Me.btnExport.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.ForeColor = System.Drawing.Color.Black
        Me.btnExport.Image = Global.AVP_Robot_Project.My.Resources.Resources.filesave
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExport.Location = New System.Drawing.Point(815, 16)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnExport.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnExport.Size = New System.Drawing.Size(108, 32)
        Me.btnExport.TabIndex = 6
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrevious.FlatAppearance.BorderSize = 0
        Me.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevious.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.btnPrevious.ForeColor = System.Drawing.Color.Black
        Me.btnPrevious.Location = New System.Drawing.Point(959, 16)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPrevious.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnPrevious.Size = New System.Drawing.Size(143, 32)
        Me.btnPrevious.TabIndex = 4
        Me.btnPrevious.Text = "Previous Page"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNext.FlatAppearance.BorderSize = 0
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.btnNext.ForeColor = System.Drawing.Color.Black
        Me.btnNext.Location = New System.Drawing.Point(1106, 16)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnNext.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnNext.Size = New System.Drawing.Size(143, 32)
        Me.btnNext.TabIndex = 4
        Me.btnNext.Text = "Next Page"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(384, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date To:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(56, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Date From:"
        '
        'dtTo
        '
        Me.dtTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtTo.CustomFormat = "MM/dd/yyyy"
        Me.dtTo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(473, 18)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(136, 29)
        Me.dtTo.TabIndex = 1
        '
        'dtFrom
        '
        Me.dtFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtFrom.CustomFormat = "MM/dd/yyyy"
        Me.dtFrom.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtFrom.Location = New System.Drawing.Point(167, 18)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(135, 29)
        Me.dtFrom.TabIndex = 1
        '
        'PnlCenter
        '
        Me.PnlCenter.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PnlCenter.Controls.Add(Me.zgraph)
        Me.PnlCenter.Controls.Add(Me.gbxView)
        Me.PnlCenter.Controls.Add(Me.lblStatus)
        Me.PnlCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlCenter.Location = New System.Drawing.Point(0, 0)
        Me.PnlCenter.Name = "PnlCenter"
        Me.PnlCenter.Size = New System.Drawing.Size(1272, 756)
        Me.PnlCenter.TabIndex = 5
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Source"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 250
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle4.Format = "G"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
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
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 357
        '
        'AlarmStatisticControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.PnlCenter)
        Me.Name = "AlarmStatisticControl"
        Me.Size = New System.Drawing.Size(1272, 756)
        Me.gbxView.ResumeLayout(False)
        Me.gbxView.PerformLayout()
        Me.PnlCenter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents zgraph As ZedGraph.ZedGraphControl
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRefresh As AVPControls.AVPButton
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbxView As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PnlCenter As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPrevious As AVPControls.AVPButton
    Friend WithEvents btnNext As AVPControls.AVPButton
    Friend WithEvents btnExport As AVPControls.AVPButton

End Class
