<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppHostCommunicationPanel
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
        Me.txtHostLocal = New System.Windows.Forms.TextBox
        Me.txtHostOffline = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTitle.Text = "HOST COMMUNICATION"
        '
        'txtHostLocal
        '
        Me.txtHostLocal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHostLocal.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtHostLocal.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHostLocal.ForeColor = System.Drawing.Color.Black
        Me.txtHostLocal.Location = New System.Drawing.Point(105, 40)
        Me.txtHostLocal.Multiline = True
        Me.txtHostLocal.Name = "txtHostLocal"
        Me.txtHostLocal.ReadOnly = True
        Me.txtHostLocal.Size = New System.Drawing.Size(80, 27)
        Me.txtHostLocal.TabIndex = 2
        Me.txtHostLocal.Text = "Local"
        Me.txtHostLocal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHostOffline
        '
        Me.txtHostOffline.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHostOffline.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtHostOffline.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHostOffline.ForeColor = System.Drawing.Color.Black
        Me.txtHostOffline.Location = New System.Drawing.Point(22, 40)
        Me.txtHostOffline.Multiline = True
        Me.txtHostOffline.Name = "txtHostOffline"
        Me.txtHostOffline.ReadOnly = True
        Me.txtHostOffline.Size = New System.Drawing.Size(80, 27)
        Me.txtHostOffline.TabIndex = 1
        Me.txtHostOffline.Text = "Offline"
        Me.txtHostOffline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AppHostCommunicationPanel
        '
        Me.Controls.Add(Me.txtHostLocal)
        Me.Controls.Add(Me.txtHostOffline)
        Me.MaximumSize = New System.Drawing.Size(207, 76)
        Me.MinimumSize = New System.Drawing.Size(207, 76)
        Me.Name = "AppHostCommunicationPanel"
        Me.Controls.SetChildIndex(Me.txtHostOffline, 0)
        Me.Controls.SetChildIndex(Me.txtHostLocal, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents txtHostLocal As System.Windows.Forms.TextBox
    Protected WithEvents txtHostOffline As System.Windows.Forms.TextBox

End Class
