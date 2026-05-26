<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectRecipeStepDialog
    Inherits AVPPopupForm

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvChamber = New HRecipeLibrary.RecipeDataGridView
        Me.pnlBottom = New System.Windows.Forms.Panel
        Me.pnlSeparator = New AVPControls.AVPPanel
        Me.btnOK = New AVPControls.AVPButton
        Me.btnClose = New AVPControls.AVPButton
        Me.cbxStep = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlLeft = New AVPControls.AVPPanel
        Me.pnlLeftCenter = New AVPControls.AVPPanel
        Me.lstItems = New System.Windows.Forms.ListBox
        Me.pnlFilter = New System.Windows.Forms.Panel
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.pnlRightPadding = New System.Windows.Forms.Panel
        Me.pnlLeftPadding = New System.Windows.Forms.Panel
        Me.pnlCenter = New AVPControls.AVPPanel
        Me.pnlContent = New AVPControls.AVPPanel
        Me.pnlBorderBottom = New System.Windows.Forms.Panel
        Me.pnlBorderRight = New System.Windows.Forms.Panel
        Me.pnlBorderLeft = New AVPControls.AVPPanel
        Me.pnlBorderTop = New System.Windows.Forms.Panel
        Me.pnlTopCenter = New System.Windows.Forms.Panel
        Me.FormContainer.SuspendLayout()
        CType(Me.dgvChamber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.pnlLeftCenter.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        Me.pnlCenter.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlTopCenter.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.pnlCenter)
        Me.FormContainer.Controls.Add(Me.pnlLeft)
        Me.FormContainer.Controls.Add(Me.pnlBottom)
        Me.FormContainer.Size = New System.Drawing.Size(1125, 505)
        '
        'dgvChamber
        '
        Me.dgvChamber.AllowUserToAddRows = False
        Me.dgvChamber.AllowUserToDeleteRows = False
        Me.dgvChamber.AllowUserToResizeColumns = False
        Me.dgvChamber.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvChamber.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvChamber.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvChamber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvChamber.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvChamber.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvChamber.ColumnHeadersHeight = 30
        Me.dgvChamber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvChamber.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvChamber.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvChamber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvChamber.EnableHeadersVisualStyles = False
        Me.dgvChamber.Location = New System.Drawing.Point(7, 7)
        Me.dgvChamber.Name = "dgvChamber"
        Me.dgvChamber.ReadOnly = True
        Me.dgvChamber.RowHeadersVisible = False
        Me.dgvChamber.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvChamber.RowTemplate.Height = 16
        Me.dgvChamber.Size = New System.Drawing.Size(728, 387)
        Me.dgvChamber.TabIndex = 0
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.pnlSeparator)
        Me.pnlBottom.Controls.Add(Me.btnOK)
        Me.pnlBottom.Controls.Add(Me.btnClose)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 449)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(1125, 56)
        Me.pnlBottom.TabIndex = 1
        '
        'pnlSeparator
        '
        Me.pnlSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSeparator.Location = New System.Drawing.Point(0, 0)
        Me.pnlSeparator.Name = "pnlSeparator"
        Me.pnlSeparator.Size = New System.Drawing.Size(1125, 3)
        Me.pnlSeparator.TabIndex = 6
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackgroundImage = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Image = Global.AVPControls.My.Resources.Resources.apply
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnOK.Location = New System.Drawing.Point(857, 10)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.NormalBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.PressedBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOK.Size = New System.Drawing.Size(120, 40)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "   OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackgroundImage = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = Global.AVPControls.My.Resources.Resources.cancel
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnClose.Location = New System.Drawing.Point(987, 10)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.NormalBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnClose.PressedBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnClose.Size = New System.Drawing.Size(120, 40)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "  Cancel"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cbxStep
        '
        Me.cbxStep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbxStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxStep.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxStep.Location = New System.Drawing.Point(174, 9)
        Me.cbxStep.Name = "cbxStep"
        Me.cbxStep.Size = New System.Drawing.Size(92, 29)
        Me.cbxStep.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 21)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Select Step To Load"
        '
        'pnlLeft
        '
        Me.pnlLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.pnlLeft.Controls.Add(Me.pnlLeftCenter)
        Me.pnlLeft.Controls.Add(Me.pnlFilter)
        Me.pnlLeft.Controls.Add(Me.pnlRightPadding)
        Me.pnlLeft.Controls.Add(Me.pnlLeftPadding)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(385, 449)
        Me.pnlLeft.TabIndex = 2
        '
        'pnlLeftCenter
        '
        Me.pnlLeftCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLeftCenter.Controls.Add(Me.lstItems)
        Me.pnlLeftCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLeftCenter.Location = New System.Drawing.Point(3, 39)
        Me.pnlLeftCenter.Name = "pnlLeftCenter"
        Me.pnlLeftCenter.Size = New System.Drawing.Size(377, 410)
        Me.pnlLeftCenter.TabIndex = 3
        '
        'lstItems
        '
        Me.lstItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstItems.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstItems.FormattingEnabled = True
        Me.lstItems.HorizontalScrollbar = True
        Me.lstItems.IntegralHeight = False
        Me.lstItems.ItemHeight = 27
        Me.lstItems.Location = New System.Drawing.Point(0, 0)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(375, 408)
        Me.lstItems.TabIndex = 2
        '
        'pnlFilter
        '
        Me.pnlFilter.Controls.Add(Me.txtFilter)
        Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilter.Location = New System.Drawing.Point(3, 0)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(377, 39)
        Me.pnlFilter.TabIndex = 0
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(1, 7)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(375, 26)
        Me.txtFilter.TabIndex = 1
        '
        'pnlRightPadding
        '
        Me.pnlRightPadding.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRightPadding.Location = New System.Drawing.Point(380, 0)
        Me.pnlRightPadding.Name = "pnlRightPadding"
        Me.pnlRightPadding.Size = New System.Drawing.Size(5, 449)
        Me.pnlRightPadding.TabIndex = 4
        '
        'pnlLeftPadding
        '
        Me.pnlLeftPadding.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftPadding.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeftPadding.Name = "pnlLeftPadding"
        Me.pnlLeftPadding.Size = New System.Drawing.Size(3, 449)
        Me.pnlLeftPadding.TabIndex = 5
        '
        'pnlCenter
        '
        Me.pnlCenter.BackColor = System.Drawing.Color.Transparent
        Me.pnlCenter.Controls.Add(Me.pnlContent)
        Me.pnlCenter.Controls.Add(Me.pnlTopCenter)
        Me.pnlCenter.Location = New System.Drawing.Point(385, 0)
        Me.pnlCenter.Name = "pnlCenter"
        Me.pnlCenter.Size = New System.Drawing.Size(740, 449)
        Me.pnlCenter.TabIndex = 3
        '
        'pnlContent
        '
        Me.pnlContent.AVPBorderStyle = AVPControls.AVPDataLib.AVPBorderStyles.AVP3DDown
        Me.pnlContent.BackColor = System.Drawing.Color.White
        Me.pnlContent.Controls.Add(Me.dgvChamber)
        Me.pnlContent.Controls.Add(Me.pnlBorderBottom)
        Me.pnlContent.Controls.Add(Me.pnlBorderRight)
        Me.pnlContent.Controls.Add(Me.pnlBorderLeft)
        Me.pnlContent.Controls.Add(Me.pnlBorderTop)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 0)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(740, 402)
        Me.pnlContent.TabIndex = 3
        '
        'pnlBorderBottom
        '
        Me.pnlBorderBottom.BackColor = System.Drawing.Color.Transparent
        Me.pnlBorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBorderBottom.Location = New System.Drawing.Point(7, 394)
        Me.pnlBorderBottom.Name = "pnlBorderBottom"
        Me.pnlBorderBottom.Size = New System.Drawing.Size(728, 8)
        Me.pnlBorderBottom.TabIndex = 4
        '
        'pnlBorderRight
        '
        Me.pnlBorderRight.BackColor = System.Drawing.Color.Transparent
        Me.pnlBorderRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBorderRight.Location = New System.Drawing.Point(735, 7)
        Me.pnlBorderRight.Name = "pnlBorderRight"
        Me.pnlBorderRight.Size = New System.Drawing.Size(5, 395)
        Me.pnlBorderRight.TabIndex = 3
        '
        'pnlBorderLeft
        '
        Me.pnlBorderLeft.BackColor = System.Drawing.Color.Transparent
        Me.pnlBorderLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBorderLeft.Location = New System.Drawing.Point(0, 7)
        Me.pnlBorderLeft.Name = "pnlBorderLeft"
        Me.pnlBorderLeft.Size = New System.Drawing.Size(7, 395)
        Me.pnlBorderLeft.TabIndex = 1
        '
        'pnlBorderTop
        '
        Me.pnlBorderTop.BackColor = System.Drawing.Color.Transparent
        Me.pnlBorderTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBorderTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlBorderTop.Name = "pnlBorderTop"
        Me.pnlBorderTop.Size = New System.Drawing.Size(740, 7)
        Me.pnlBorderTop.TabIndex = 2
        '
        'pnlTopCenter
        '
        Me.pnlTopCenter.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.pnlTopCenter.Controls.Add(Me.cbxStep)
        Me.pnlTopCenter.Controls.Add(Me.Label1)
        Me.pnlTopCenter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTopCenter.Location = New System.Drawing.Point(0, 402)
        Me.pnlTopCenter.Name = "pnlTopCenter"
        Me.pnlTopCenter.Size = New System.Drawing.Size(740, 47)
        Me.pnlTopCenter.TabIndex = 0
        '
        'SelectRecipeStepDialog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1135, 550)
        Me.Name = "SelectRecipeStepDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Recipe Step"
        Me.FormContainer.ResumeLayout(False)
        CType(Me.dgvChamber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlLeftCenter.ResumeLayout(False)
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.pnlCenter.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        Me.pnlTopCenter.ResumeLayout(False)
        Me.pnlTopCenter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvChamber As HRecipeLibrary.RecipeDataGridView
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents cbxStep As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As AVPControls.AVPButton
    Friend WithEvents btnClose As AVPControls.AVPButton
    Friend WithEvents pnlCenter As AVPPanel
    Friend WithEvents pnlLeft As AVPPanel
    Friend WithEvents pnlTopCenter As System.Windows.Forms.Panel
    Friend WithEvents pnlBorderLeft As AVPPanel
    Friend WithEvents lstItems As System.Windows.Forms.ListBox
    Friend WithEvents pnlLeftCenter As AVPPanel
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents pnlSeparator As AVPControls.AVPPanel
    Friend WithEvents pnlBorderTop As System.Windows.Forms.Panel
    Friend WithEvents pnlRightPadding As System.Windows.Forms.Panel
    Friend WithEvents pnlLeftPadding As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As AVPPanel
    Friend WithEvents pnlBorderRight As System.Windows.Forms.Panel
    Friend WithEvents pnlBorderBottom As System.Windows.Forms.Panel
End Class
