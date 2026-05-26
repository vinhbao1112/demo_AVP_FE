<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopUpWaferRun
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvWFList = New System.Windows.Forms.DataGridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtFilter = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lstStep = New System.Windows.Forms.ListBox
        Me.btnCancel = New AVPControls.AVPButton
        Me.btnOK = New AVPControls.AVPButton
        Me.grpPM = New System.Windows.Forms.GroupBox
        Me.lstPM = New System.Windows.Forms.ListBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lstValue = New System.Windows.Forms.ListBox
        Me.pnlPaddingLeft = New System.Windows.Forms.Panel
        Me.pnlPaddingRight = New System.Windows.Forms.Panel
        Me.pnlCenter = New System.Windows.Forms.Panel
        Me.pnlPaddingBottom = New System.Windows.Forms.Panel
        Me.FormContainer.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvWFList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpPM.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.pnlCenter.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.pnlPaddingRight)
        Me.FormContainer.Controls.Add(Me.pnlPaddingLeft)
        Me.FormContainer.Controls.Add(Me.pnlCenter)
        Me.FormContainer.Controls.Add(Me.pnlPaddingBottom)
        Me.FormContainer.Location = New System.Drawing.Point(5, 55)
        Me.FormContainer.Size = New System.Drawing.Size(985, 574)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dgvWFList)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 569)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Wafer Run List"
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
        Me.dgvWFList.Location = New System.Drawing.Point(3, 73)
        Me.dgvWFList.MultiSelect = False
        Me.dgvWFList.Name = "dgvWFList"
        Me.dgvWFList.RowHeadersWidth = 20
        Me.dgvWFList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvWFList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWFList.Size = New System.Drawing.Size(414, 493)
        Me.dgvWFList.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.dtFilter)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Font = New System.Drawing.Font("Times New Roman", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(3, 25)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(414, 48)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Select date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtFilter
        '
        Me.dtFilter.CalendarFont = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtFilter.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFilter.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFilter.Location = New System.Drawing.Point(182, 9)
        Me.dtFilter.Name = "dtFilter"
        Me.dtFilter.Size = New System.Drawing.Size(226, 32)
        Me.dtFilter.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lstStep)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(520, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(90, 569)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Step"
        '
        'lstStep
        '
        Me.lstStep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstStep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstStep.FormattingEnabled = True
        Me.lstStep.ItemHeight = 22
        Me.lstStep.Location = New System.Drawing.Point(3, 25)
        Me.lstStep.Name = "lstStep"
        Me.lstStep.Size = New System.Drawing.Size(84, 532)
        Me.lstStep.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.AVP_Robot_Project.My.Resources.Resources.cancel
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(875, 383)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnCancel.Size = New System.Drawing.Size(108, 40)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = " Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Image = Global.AVP_Robot_Project.My.Resources.Resources.apply
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOK.Location = New System.Drawing.Point(875, 221)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOK.Size = New System.Drawing.Size(108, 40)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "   OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'grpPM
        '
        Me.grpPM.BackColor = System.Drawing.Color.Transparent
        Me.grpPM.Controls.Add(Me.lstPM)
        Me.grpPM.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpPM.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.grpPM.Location = New System.Drawing.Point(420, 0)
        Me.grpPM.Name = "grpPM"
        Me.grpPM.Size = New System.Drawing.Size(100, 569)
        Me.grpPM.TabIndex = 7
        Me.grpPM.TabStop = False
        Me.grpPM.Text = "PM"
        '
        'lstPM
        '
        Me.lstPM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstPM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstPM.FormattingEnabled = True
        Me.lstPM.ItemHeight = 24
        Me.lstPM.Location = New System.Drawing.Point(3, 25)
        Me.lstPM.Name = "lstPM"
        Me.lstPM.Size = New System.Drawing.Size(94, 532)
        Me.lstPM.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.lstValue)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(610, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(255, 569)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Value"
        '
        'lstValue
        '
        Me.lstValue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstValue.FormattingEnabled = True
        Me.lstValue.ItemHeight = 22
        Me.lstValue.Location = New System.Drawing.Point(3, 25)
        Me.lstValue.Name = "lstValue"
        Me.lstValue.Size = New System.Drawing.Size(249, 532)
        Me.lstValue.TabIndex = 0
        '
        'pnlPaddingLeft
        '
        Me.pnlPaddingLeft.BackColor = System.Drawing.Color.Transparent
        Me.pnlPaddingLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlPaddingLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlPaddingLeft.Name = "pnlPaddingLeft"
        Me.pnlPaddingLeft.Size = New System.Drawing.Size(5, 569)
        Me.pnlPaddingLeft.TabIndex = 1
        '
        'pnlPaddingRight
        '
        Me.pnlPaddingRight.BackColor = System.Drawing.Color.Transparent
        Me.pnlPaddingRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlPaddingRight.Location = New System.Drawing.Point(980, 0)
        Me.pnlPaddingRight.Name = "pnlPaddingRight"
        Me.pnlPaddingRight.Size = New System.Drawing.Size(5, 569)
        Me.pnlPaddingRight.TabIndex = 2
        '
        'pnlCenter
        '
        Me.pnlCenter.Controls.Add(Me.GroupBox3)
        Me.pnlCenter.Controls.Add(Me.GroupBox2)
        Me.pnlCenter.Controls.Add(Me.grpPM)
        Me.pnlCenter.Controls.Add(Me.btnOK)
        Me.pnlCenter.Controls.Add(Me.btnCancel)
        Me.pnlCenter.Controls.Add(Me.GroupBox1)
        Me.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCenter.Location = New System.Drawing.Point(0, 0)
        Me.pnlCenter.Name = "pnlCenter"
        Me.pnlCenter.Size = New System.Drawing.Size(985, 569)
        Me.pnlCenter.TabIndex = 3
        '
        'pnlPaddingBottom
        '
        Me.pnlPaddingBottom.BackColor = System.Drawing.Color.Transparent
        Me.pnlPaddingBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPaddingBottom.Location = New System.Drawing.Point(0, 569)
        Me.pnlPaddingBottom.Name = "pnlPaddingBottom"
        Me.pnlPaddingBottom.Size = New System.Drawing.Size(985, 5)
        Me.pnlPaddingBottom.TabIndex = 0
        '
        'PopUpWaferRun
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(995, 634)
        Me.HeaderHeight = 55
        Me.Name = "PopUpWaferRun"
        Me.ShowButton = False
        Me.Text = "Select Wafer Run to Compare"
        Me.FormContainer.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvWFList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.grpPM.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.pnlCenter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As AVPControls.AVPButton
    Friend WithEvents btnOK As AVPControls.AVPButton
    Friend WithEvents dgvWFList As System.Windows.Forms.DataGridView
    Friend WithEvents lstStep As System.Windows.Forms.ListBox
    Friend WithEvents grpPM As System.Windows.Forms.GroupBox
    Friend WithEvents lstPM As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lstValue As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtFilter As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlCenter As System.Windows.Forms.Panel
    Friend WithEvents pnlPaddingBottom As System.Windows.Forms.Panel
    Friend WithEvents pnlPaddingRight As System.Windows.Forms.Panel
    Friend WithEvents pnlPaddingLeft As System.Windows.Forms.Panel
End Class
