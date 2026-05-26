<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IGCGControl
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
        Me.txtIG = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        Me.Header.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Header.Dock = System.Windows.Forms.DockStyle.Left
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Font = New System.Drawing.Font("Times New Roman", 14.25!)
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Size = New System.Drawing.Size(60, 27)
        Me.Header.Status = AVP_Robot_Project.DisplayStatus.Unknow
        Me.Header.Text = "PM1"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'txtIG
        '
        Me.txtIG.BackColor = System.Drawing.Color.Black
        Me.txtIG.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtIG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIG.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.txtIG.ForeColor = System.Drawing.Color.Lime
        Me.txtIG.Location = New System.Drawing.Point(60, 0)
        Me.txtIG.Name = "txtIG"
        Me.txtIG.ReadOnly = True
        Me.txtIG.Size = New System.Drawing.Size(156, 26)
        Me.txtIG.TabIndex = 2
        Me.txtIG.Text = "OFF"
        '
        'IGCGControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.txtIG)
        Me.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkBlue
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.Unknow
        Me.HeaderStyle = AVP_Robot_Project.PVDStatusBoard.StyleOfBoard.Vertical
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "IGCGControl"
        Me.Size = New System.Drawing.Size(216, 27)
        Me.Text = "PM1"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.txtIG, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIG As System.Windows.Forms.TextBox

End Class
