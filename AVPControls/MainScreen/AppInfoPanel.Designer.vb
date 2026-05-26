<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppInfoPanel
    Inherits AppPanel

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
        Me.txtAVPReleaseNo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Text = "ABC"
        '
        'txtAVPReleaseNo
        '
        Me.txtAVPReleaseNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAVPReleaseNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAVPReleaseNo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtAVPReleaseNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAVPReleaseNo.ForeColor = System.Drawing.Color.Black
        Me.txtAVPReleaseNo.Location = New System.Drawing.Point(12, 40)
        Me.txtAVPReleaseNo.MaxLength = 16
        Me.txtAVPReleaseNo.Name = "txtAVPReleaseNo"
        Me.txtAVPReleaseNo.ReadOnly = True
        Me.txtAVPReleaseNo.Size = New System.Drawing.Size(182, 26)
        Me.txtAVPReleaseNo.TabIndex = 152
        Me.txtAVPReleaseNo.Text = "AVP Release No"
        Me.txtAVPReleaseNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AppInfoPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.txtAVPReleaseNo)
        Me.MaximumSize = New System.Drawing.Size(0, 0)
        Me.MinimumSize = New System.Drawing.Size(0, 0)
        Me.Name = "AppInfoPanel"
        Me.Controls.SetChildIndex(Me.txtAVPReleaseNo, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents txtAVPReleaseNo As System.Windows.Forms.TextBox

End Class
