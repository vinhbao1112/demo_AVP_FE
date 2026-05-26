<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AVPComapnyPopupForm
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.FormContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.Panel1)
        Me.FormContainer.Controls.Add(Me.Label1)
        Me.FormContainer.Location = New System.Drawing.Point(5, 0)
        Me.FormContainer.Size = New System.Drawing.Size(495, 309)
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(495, 5)
        Me.Label1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.AVPControls.My.Resources.Resources.CompanyInfo
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(495, 304)
        Me.Panel1.TabIndex = 1
        '
        'AVPComapnyPopupForm
        '
        Me.AllowAutoClose = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(505, 314)
        Me.KeyPreview = True
        Me.Name = "AVPComapnyPopupForm"
        Me.ShowTitle = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AVPComapnyPopupForm"
        Me.FormContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
