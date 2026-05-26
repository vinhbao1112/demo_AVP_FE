<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_TurboPump
    Inherits AVP_Robot_Project.PVDStatusBoard

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
        Me.txtT = New AVP_Robot_Project.SL_Textbox
        Me.SuspendLayout()
        '
        'txtT
        '
        Me.txtT.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtT.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtT.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtT.IsNumericTextbox = False
        Me.txtT.IsReadBack = True
        Me.txtT.IsTurboPumpTextbox = True
        Me.txtT.Location = New System.Drawing.Point(20, 16)
        Me.txtT.Name = "txtT"
        Me.txtT.ReadOnly = True
        Me.txtT.Size = New System.Drawing.Size(66, 26)
        Me.txtT.TabIndex = 8
        Me.txtT.GasName = ""
        '
        'SL_TurboPump
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Turbo_Pump
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtT)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderVisible = False
        Me.Name = "SL_TurboPump"
        Me.Size = New System.Drawing.Size(111, 60)
        Me.Text = "TURBO"
        Me.Controls.SetChildIndex(Me.txtT, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtT As AVP_Robot_Project.SL_Textbox

End Class
