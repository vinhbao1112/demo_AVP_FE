<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BACenterControl
	Inherits AVP_Robot_Project.StatusBoard

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
        Me.txtIG = New System.Windows.Forms.TextBox
        Me.txtCG1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCG2 = New System.Windows.Forms.TextBox
        Me.bigcgIG = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 16)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "IG"
        '
        'txtIG
        '
        Me.txtIG.Location = New System.Drawing.Point(3, 27)
        Me.txtIG.Name = "txtIG"
        Me.txtIG.ReadOnly = True
        Me.txtIG.Size = New System.Drawing.Size(75, 20)
        Me.txtIG.TabIndex = 21
        Me.txtIG.Text = "OFF"
        '
        'txtCG1
        '
        Me.txtCG1.Location = New System.Drawing.Point(3, 75)
        Me.txtCG1.Name = "txtCG1"
        Me.txtCG1.ReadOnly = True
        Me.txtCG1.Size = New System.Drawing.Size(75, 20)
        Me.txtCG1.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "CG (Torr)"
        '
        'txtCG2
        '
        Me.txtCG2.BackColor = System.Drawing.SystemColors.Window
        Me.txtCG2.Location = New System.Drawing.Point(3, 99)
        Me.txtCG2.Name = "txtCG2"
        Me.txtCG2.ReadOnly = True
        Me.txtCG2.Size = New System.Drawing.Size(75, 20)
        Me.txtCG2.TabIndex = 26
        '
        'bigcgIG
        '
        Me.bigcgIG.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BlueButton
        Me.bigcgIG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bigcgIG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bigcgIG.ErrorImage = Nothing
        Me.bigcgIG.ErrorText = ""
        Me.bigcgIG.FlatAppearance.BorderSize = 0
        Me.bigcgIG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bigcgIG.Location = New System.Drawing.Point(43, 1)
        Me.bigcgIG.Name = "bigcgIG"
        Me.bigcgIG.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BlueButton
        Me.bigcgIG.OffText = ""
        Me.bigcgIG.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.bigcgIG_OnImage
        Me.bigcgIG.OnText = ""
        Me.bigcgIG.Size = New System.Drawing.Size(35, 22)
        Me.bigcgIG.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.bigcgIG.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.bigcgIG.TabIndex = 27
        Me.bigcgIG.UnknownImage = Nothing
        Me.bigcgIG.UnKnownText = ""
        Me.bigcgIG.UseVisualStyleBackColor = True
        '
        'BACenterControl
        '
        Me.Controls.Add(Me.bigcgIG)
        Me.Controls.Add(Me.txtCG2)
        Me.Controls.Add(Me.txtCG1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtIG)
        Me.Controls.Add(Me.Label1)
        Me.HeaderVisible = False
        Me.Name = "BACenterControl"
        Me.Size = New System.Drawing.Size(82, 129)
        Me.Controls.SetChildIndex(Me.lblHeader, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtIG, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtCG1, 0)
        Me.Controls.SetChildIndex(Me.txtCG2, 0)
        Me.Controls.SetChildIndex(Me.bigcgIG, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents txtIG As System.Windows.Forms.TextBox
	Friend WithEvents txtCG1 As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCG2 As System.Windows.Forms.TextBox
	Friend WithEvents bigcgIG As AVP_Robot_Project.ButtonIGCGControl

End Class
