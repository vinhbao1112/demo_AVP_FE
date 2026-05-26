<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDialog
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
        Me.pnlTop = New AVPControls.AVPPanel
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.pnlBottom = New AVPControls.AVPPanel
        Me.pnlSeparator = New AVPControls.AVPPanel
        Me.btnOK = New AVPControls.AVPButton
        Me.btnClose = New AVPControls.AVPButton
        Me.pnlCenter = New AVPControls.AVPPanel
        Me.lstItems = New System.Windows.Forms.ListBox
        Me.FormContainer.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.pnlCenter.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.pnlCenter)
        Me.FormContainer.Controls.Add(Me.pnlBottom)
        Me.FormContainer.Controls.Add(Me.pnlTop)
        Me.FormContainer.Location = New System.Drawing.Point(5, 50)
        Me.FormContainer.Size = New System.Drawing.Size(490, 500)
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.SystemColors.Control
        Me.pnlTop.Controls.Add(Me.txtFilter)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(490, 32)
        Me.pnlTop.TabIndex = 0
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(3, 3)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(484, 26)
        Me.txtFilter.TabIndex = 0
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.pnlSeparator)
        Me.pnlBottom.Controls.Add(Me.btnOK)
        Me.pnlBottom.Controls.Add(Me.btnClose)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 440)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(490, 60)
        Me.pnlBottom.TabIndex = 0
        '
        'pnlSeparator
        '
        Me.pnlSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSeparator.Location = New System.Drawing.Point(0, 0)
        Me.pnlSeparator.Name = "pnlSeparator"
        Me.pnlSeparator.Size = New System.Drawing.Size(490, 3)
        Me.pnlSeparator.TabIndex = 5
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top
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
        Me.btnOK.Location = New System.Drawing.Point(85, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.NormalBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.PressedBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOK.Size = New System.Drawing.Size(120, 40)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "   OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top
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
        Me.btnClose.Location = New System.Drawing.Point(285, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.NormalBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhite
        Me.btnClose.PressedBackground = Global.AVPControls.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnClose.Size = New System.Drawing.Size(120, 40)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "   Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pnlCenter
        '
        Me.pnlCenter.Controls.Add(Me.lstItems)
        Me.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCenter.Location = New System.Drawing.Point(0, 32)
        Me.pnlCenter.Name = "pnlCenter"
        Me.pnlCenter.Size = New System.Drawing.Size(490, 408)
        Me.pnlCenter.TabIndex = 0
        '
        'lstItems
        '
        Me.lstItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstItems.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstItems.FormattingEnabled = True
        Me.lstItems.HorizontalScrollbar = True
        Me.lstItems.ItemHeight = 27
        Me.lstItems.Location = New System.Drawing.Point(0, 0)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(490, 407)
        Me.lstItems.TabIndex = 1
        '
        'SelectDialog
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(500, 555)
        Me.HeaderHeight = 50
        Me.MinimumSize = New System.Drawing.Size(342, 0)
        Me.Name = "SelectDialog"
        Me.ShowButton = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SelectDialog"
        Me.FormContainer.ResumeLayout(False)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlCenter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As AVPControls.AVPPanel
    Friend WithEvents pnlCenter As AVPControls.AVPPanel
    Friend WithEvents pnlBottom As AVPControls.AVPPanel
    Friend WithEvents pnlSeparator As AVPControls.AVPPanel
    Protected WithEvents btnOK As AVPControls.AVPButton
    Protected WithEvents btnClose As AVPControls.AVPButton
    Protected WithEvents lstItems As System.Windows.Forms.ListBox
    Protected WithEvents txtFilter As System.Windows.Forms.TextBox
End Class
