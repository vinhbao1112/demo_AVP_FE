<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TroubleShootPanel
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.tvKepServerTag = New System.Windows.Forms.TreeView
        Me.dgvKepServerValue = New System.Windows.Forms.DataGridView
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvKepServerValue, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvKepServerTag)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvKepServerValue)
        Me.SplitContainer1.Size = New System.Drawing.Size(779, 723)
        Me.SplitContainer1.SplitterDistance = 200
        Me.SplitContainer1.TabIndex = 0
        '
        'tvKepServerTag
        '
        Me.tvKepServerTag.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tvKepServerTag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvKepServerTag.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvKepServerTag.ForeColor = System.Drawing.Color.DarkBlue
        Me.tvKepServerTag.Location = New System.Drawing.Point(0, 0)
        Me.tvKepServerTag.Name = "tvKepServerTag"
        Me.tvKepServerTag.Size = New System.Drawing.Size(200, 723)
        Me.tvKepServerTag.TabIndex = 0
        '
        'dgvKepServerValue
        '
        Me.dgvKepServerValue.AllowUserToAddRows = False
        Me.dgvKepServerValue.AllowUserToDeleteRows = False
        Me.dgvKepServerValue.AllowUserToResizeColumns = False
        Me.dgvKepServerValue.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvKepServerValue.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvKepServerValue.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvKepServerValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvKepServerValue.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvKepServerValue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvKepServerValue.ColumnHeadersHeight = 30
        Me.dgvKepServerValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvKepServerValue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvKepServerValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvKepServerValue.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvKepServerValue.EnableHeadersVisualStyles = False
        Me.dgvKepServerValue.Location = New System.Drawing.Point(0, 0)
        Me.dgvKepServerValue.Name = "dgvKepServerValue"
        Me.dgvKepServerValue.ReadOnly = True
        Me.dgvKepServerValue.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvKepServerValue.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvKepServerValue.RowHeadersVisible = False
        Me.dgvKepServerValue.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvKepServerValue.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvKepServerValue.RowTemplate.Height = 40
        Me.dgvKepServerValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvKepServerValue.Size = New System.Drawing.Size(575, 723)
        Me.dgvKepServerValue.TabIndex = 0
        '
        'TroubleShootPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Name = "TroubleShootPanel"
        Me.Size = New System.Drawing.Size(779, 723)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvKepServerValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tvKepServerTag As System.Windows.Forms.TreeView
    Friend WithEvents dgvKepServerValue As System.Windows.Forms.DataGridView

End Class
