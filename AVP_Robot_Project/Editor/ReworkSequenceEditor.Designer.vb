<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReworkSequenceEditor
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cbAlignRecipes = New System.Windows.Forms.ComboBox
        Me.cbxUseAligner = New System.Windows.Forms.CheckBox
        Me.btnCancel = New AVPControls.AVPButton
        Me.btnOK = New AVPControls.AVPButton
        Me.pnlSequence = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.dgvRecipe = New System.Windows.Forms.DataGridView
        Me.gcParameters = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gcStep1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.lblNewRecipeName = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.picShowWaferFlow = New System.Windows.Forms.Panel
        Me.pnlRightEdge = New System.Windows.Forms.Panel
        Me.pnlLeftEdge = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.cbWaferFlows = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlCenter = New System.Windows.Forms.Panel
        Me.ValueToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FormContainer.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlSequence.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.dgvRecipe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlCenter.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.pnlCenter)
        Me.FormContainer.Controls.Add(Me.Panel2)
        Me.FormContainer.Location = New System.Drawing.Point(5, 50)
        Me.FormContainer.Size = New System.Drawing.Size(1190, 592)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.cbAlignRecipes)
        Me.Panel2.Controls.Add(Me.cbxUseAligner)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnOK)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 543)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1190, 49)
        Me.Panel2.TabIndex = 9
        '
        'cbAlignRecipes
        '
        Me.cbAlignRecipes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbAlignRecipes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlignRecipes.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAlignRecipes.FormattingEnabled = True
        Me.cbAlignRecipes.Location = New System.Drawing.Point(127, 15)
        Me.cbAlignRecipes.Name = "cbAlignRecipes"
        Me.cbAlignRecipes.Size = New System.Drawing.Size(203, 24)
        Me.cbAlignRecipes.TabIndex = 4
        '
        'cbxUseAligner
        '
        Me.cbxUseAligner.AutoSize = True
        Me.cbxUseAligner.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbxUseAligner.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxUseAligner.Location = New System.Drawing.Point(17, 17)
        Me.cbxUseAligner.Name = "cbxUseAligner"
        Me.cbxUseAligner.Size = New System.Drawing.Size(104, 21)
        Me.cbxUseAligner.TabIndex = 3
        Me.cbxUseAligner.Text = "Use Aligner"
        Me.cbxUseAligner.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(1086, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnCancel.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnCancel.Size = New System.Drawing.Size(97, 32)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(965, 10)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOK.Size = New System.Drawing.Size(97, 32)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'pnlSequence
        '
        Me.pnlSequence.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.pnlSequence.Controls.Add(Me.Panel3)
        Me.pnlSequence.Controls.Add(Me.Panel1)
        Me.pnlSequence.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSequence.Location = New System.Drawing.Point(0, 0)
        Me.pnlSequence.Name = "pnlSequence"
        Me.pnlSequence.Size = New System.Drawing.Size(1190, 543)
        Me.pnlSequence.TabIndex = 10
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(330, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(860, 543)
        Me.Panel3.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.dgvRecipe)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.Location = New System.Drawing.Point(0, 67)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(860, 476)
        Me.Panel7.TabIndex = 1
        '
        'dgvRecipe
        '
        Me.dgvRecipe.AllowUserToAddRows = False
        Me.dgvRecipe.AllowUserToDeleteRows = False
        Me.dgvRecipe.AllowUserToResizeColumns = False
        Me.dgvRecipe.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvRecipe.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRecipe.BackgroundColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRecipe.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRecipe.ColumnHeadersHeight = 35
        Me.dgvRecipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvRecipe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gcParameters, Me.gcStep1})
        Me.dgvRecipe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvRecipe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRecipe.EnableHeadersVisualStyles = False
        Me.dgvRecipe.Location = New System.Drawing.Point(0, 0)
        Me.dgvRecipe.MultiSelect = False
        Me.dgvRecipe.Name = "dgvRecipe"
        Me.dgvRecipe.RowHeadersVisible = False
        Me.dgvRecipe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvRecipe.RowTemplate.Height = 35
        Me.dgvRecipe.Size = New System.Drawing.Size(860, 476)
        Me.dgvRecipe.TabIndex = 7
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
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblNewRecipeName)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(860, 67)
        Me.Panel6.TabIndex = 0
        '
        'lblNewRecipeName
        '
        Me.lblNewRecipeName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNewRecipeName.AutoEllipsis = True
        Me.lblNewRecipeName.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewRecipeName.Location = New System.Drawing.Point(6, 33)
        Me.lblNewRecipeName.Name = "lblNewRecipeName"
        Me.lblNewRecipeName.Size = New System.Drawing.Size(851, 26)
        Me.lblNewRecipeName.TabIndex = 3
        Me.lblNewRecipeName.Text = "recipe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Recipe name:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(330, 543)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.picShowWaferFlow)
        Me.Panel5.Controls.Add(Me.pnlRightEdge)
        Me.Panel5.Controls.Add(Me.pnlLeftEdge)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 67)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(330, 476)
        Me.Panel5.TabIndex = 3
        '
        'picShowWaferFlow
        '
        Me.picShowWaferFlow.AutoScroll = True
        Me.picShowWaferFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picShowWaferFlow.Location = New System.Drawing.Point(8, 0)
        Me.picShowWaferFlow.Name = "picShowWaferFlow"
        Me.picShowWaferFlow.Size = New System.Drawing.Size(314, 476)
        Me.picShowWaferFlow.TabIndex = 1
        '
        'pnlRightEdge
        '
        Me.pnlRightEdge.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRightEdge.Location = New System.Drawing.Point(322, 0)
        Me.pnlRightEdge.Name = "pnlRightEdge"
        Me.pnlRightEdge.Size = New System.Drawing.Size(8, 476)
        Me.pnlRightEdge.TabIndex = 3
        '
        'pnlLeftEdge
        '
        Me.pnlLeftEdge.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftEdge.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeftEdge.Name = "pnlLeftEdge"
        Me.pnlLeftEdge.Size = New System.Drawing.Size(8, 476)
        Me.pnlLeftEdge.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.cbWaferFlows)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(330, 67)
        Me.Panel4.TabIndex = 2
        '
        'cbWaferFlows
        '
        Me.cbWaferFlows.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbWaferFlows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbWaferFlows.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbWaferFlows.FormattingEnabled = True
        Me.cbWaferFlows.ItemHeight = 19
        Me.cbWaferFlows.Location = New System.Drawing.Point(9, 33)
        Me.cbWaferFlows.Name = "cbWaferFlows"
        Me.cbWaferFlows.Size = New System.Drawing.Size(312, 27)
        Me.cbWaferFlows.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Wafer flow name:"
        '
        'pnlCenter
        '
        Me.pnlCenter.BackColor = System.Drawing.Color.Transparent
        Me.pnlCenter.Controls.Add(Me.pnlSequence)
        Me.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCenter.Location = New System.Drawing.Point(0, 0)
        Me.pnlCenter.Name = "pnlCenter"
        Me.pnlCenter.Size = New System.Drawing.Size(1190, 543)
        Me.pnlCenter.TabIndex = 1
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
        'ctxMenu
        '
        Me.ctxMenu.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(61, 4)
        '
        'ReworkSequenceEditor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1200, 647)
        Me.HeaderHeight = 50
        Me.Name = "ReworkSequenceEditor"
        Me.ShowButton = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rework"
        Me.Controls.SetChildIndex(Me.FormContainer, 0)
        Me.FormContainer.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlSequence.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.dgvRecipe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlCenter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlSequence As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As AVPControls.AVPButton
    Friend WithEvents btnOK As AVPControls.AVPButton
    Friend WithEvents pnlCenter As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblNewRecipeName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents cbxUseAligner As System.Windows.Forms.CheckBox
    Friend WithEvents cbAlignRecipes As System.Windows.Forms.ComboBox
    Friend WithEvents picShowWaferFlow As System.Windows.Forms.Panel
    Friend WithEvents ValueToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents dgvRecipe As System.Windows.Forms.DataGridView
    Friend WithEvents gcParameters As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gcStep1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlRightEdge As System.Windows.Forms.Panel
    Friend WithEvents pnlLeftEdge As System.Windows.Forms.Panel
    Friend WithEvents cbWaferFlows As System.Windows.Forms.ComboBox
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
End Class
