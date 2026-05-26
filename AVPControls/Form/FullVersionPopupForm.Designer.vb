<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FullVersionPopupForm
    Inherits AVPForm

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbVersion = New System.Windows.Forms.Label()
        Me.FormContainer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FormContainer.AVPBorderStyle = AVPControls.AVPDataLib.AVPBorderStyles.None
        Me.FormContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.FormContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FormContainer.Controls.Add(Me.Panel1)
        Me.FormContainer.Dock = System.Windows.Forms.DockStyle.None
        Me.FormContainer.Location = New System.Drawing.Point(8, 4)
        Me.FormContainer.Size = New System.Drawing.Size(490, 212)
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(474, 55)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "ABC"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lbVersion)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 202)
        Me.Panel1.TabIndex = 156
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = Global.AVPControls.My.Resources.Resources.AVPLogoNew
        Me.PictureBox1.Location = New System.Drawing.Point(9, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(104, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 157
        Me.PictureBox1.TabStop = False
        '
        'lbVersion
        '
        Me.lbVersion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVersion.Location = New System.Drawing.Point(7, 125)
        Me.lbVersion.Name = "lbVersion"
        Me.lbVersion.Size = New System.Drawing.Size(474, 33)
        Me.lbVersion.TabIndex = 156
        Me.lbVersion.Text = "AVP Release No"
        Me.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FullVersionPopupForm
        '
        Me.AllowAutoClose = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(505, 220)
        Me.Name = "FullVersionPopupForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowButton = False
        Me.ShowTitle = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FullVersionPopupForm"
        Me.FormContainer.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbVersion As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
