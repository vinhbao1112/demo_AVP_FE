<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AVPIOTab
    Inherits System.Windows.Forms.Form

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
        Me.GridViewIO = New System.Windows.Forms.DataGridView
        CType(Me.GridViewIO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridViewIO
        '
        Me.GridViewIO.AllowUserToAddRows = False
        Me.GridViewIO.AllowUserToDeleteRows = False
        Me.GridViewIO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridViewIO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridViewIO.Location = New System.Drawing.Point(0, 0)
        Me.GridViewIO.Name = "GridViewIO"
        Me.GridViewIO.ReadOnly = True
        Me.GridViewIO.Size = New System.Drawing.Size(784, 482)
        Me.GridViewIO.TabIndex = 0
        '
        'AVPIOTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 482)
        Me.Controls.Add(Me.GridViewIO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AVPIOTab"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IOTab"
        CType(Me.GridViewIO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridViewIO As System.Windows.Forms.DataGridView
End Class
