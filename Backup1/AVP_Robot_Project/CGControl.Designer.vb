<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CGControl
    Inherits AVP_Robot_Project.PVDStatusBoard

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
        Me.txtInformation = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtInformation
        '
        Me.txtInformation.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInformation.Location = New System.Drawing.Point(5, 32)
        Me.txtInformation.Name = "txtInformation"
        Me.txtInformation.ReadOnly = True
        Me.txtInformation.Size = New System.Drawing.Size(74, 26)
        Me.txtInformation.TabIndex = 7
        '
        'CGControl
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtInformation)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "CGControl"
        Me.Size = New System.Drawing.Size(84, 63)
        Me.Text = "CG"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.txtInformation, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInformation As System.Windows.Forms.TextBox

End Class
