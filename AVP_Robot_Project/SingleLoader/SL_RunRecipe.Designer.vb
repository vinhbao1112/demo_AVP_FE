<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_RunRecipe
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
        Me.components = New System.ComponentModel.Container
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtProcessRecipe = New System.Windows.Forms.TextBox
        Me.btnStart = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnPause = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnAbort = New AVP_Robot_Project.ButtonIGCGControl
        Me.ValueToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Recipe"
        '
        'txtProcessRecipe
        '
        Me.txtProcessRecipe.BackColor = System.Drawing.SystemColors.Window
        Me.txtProcessRecipe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtProcessRecipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessRecipe.Location = New System.Drawing.Point(89, 30)
        Me.txtProcessRecipe.Name = "txtProcessRecipe"
        Me.txtProcessRecipe.ReadOnly = True
        Me.txtProcessRecipe.Size = New System.Drawing.Size(211, 26)
        Me.txtProcessRecipe.TabIndex = 13
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.Transparent
        Me.btnStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.button1
        Me.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStart.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnStart.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnStart.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.button
        Me.btnStart.ErrorText = ""
        Me.btnStart.FlatAppearance.BorderSize = 0
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.Black
        Me.btnStart.Location = New System.Drawing.Point(3, 58)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.button1
        Me.btnStart.OffText = ""
        Me.btnStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.button1
        Me.btnStart.OnText = ""
        Me.btnStart.Size = New System.Drawing.Size(82, 24)
        Me.btnStart.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.btnStart.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.btnStart.TabIndex = 15
        Me.btnStart.Text = "Start"
        Me.btnStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnStart.UnKnownText = ""
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'btnPause
        '
        Me.btnPause.BackColor = System.Drawing.Color.Transparent
        Me.btnPause.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.button1
        Me.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPause.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnPause.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPause.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnPause.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnPause.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPause.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.button
        Me.btnPause.ErrorText = ""
        Me.btnPause.FlatAppearance.BorderSize = 0
        Me.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPause.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPause.ForeColor = System.Drawing.Color.Black
        Me.btnPause.Location = New System.Drawing.Point(89, 58)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.button1
        Me.btnPause.OffText = ""
        Me.btnPause.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.button1
        Me.btnPause.OnText = ""
        Me.btnPause.Size = New System.Drawing.Size(89, 24)
        Me.btnPause.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.btnPause.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.btnPause.TabIndex = 15
        Me.btnPause.Text = "Pause"
        Me.btnPause.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnPause.UnKnownText = ""
        Me.btnPause.UseVisualStyleBackColor = False
        '
        'btnAbort
        '
        Me.btnAbort.BackColor = System.Drawing.Color.Transparent
        Me.btnAbort.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.button1
        Me.btnAbort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbort.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAbort.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAbort.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnAbort.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnAbort.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbort.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.button
        Me.btnAbort.ErrorText = ""
        Me.btnAbort.FlatAppearance.BorderSize = 0
        Me.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbort.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbort.ForeColor = System.Drawing.Color.Black
        Me.btnAbort.Location = New System.Drawing.Point(182, 58)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.button1
        Me.btnAbort.OffText = ""
        Me.btnAbort.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.button1
        Me.btnAbort.OnText = ""
        Me.btnAbort.Size = New System.Drawing.Size(140, 24)
        Me.btnAbort.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.btnAbort.StyleOfButton = AVP_Robot_Project.ButtonIGCGControl.ButtonStyle.Horizontal
        Me.btnAbort.TabIndex = 15
        Me.btnAbort.Text = "End Current Step"
        Me.btnAbort.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Me.btnAbort.UnKnownText = ""
        Me.btnAbort.UseVisualStyleBackColor = False
        '
        'ValueToolTip
        '
        Me.ValueToolTip.AutomaticDelay = 200
        Me.ValueToolTip.AutoPopDelay = 2000
        Me.ValueToolTip.InitialDelay = 200
        Me.ValueToolTip.ReshowDelay = 20
        Me.ValueToolTip.ShowAlways = True
        '
        'SL_RunRecipe
        '
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.btnPause)
        Me.Controls.Add(Me.txtProcessRecipe)
        Me.DoubleBuffered = True
        Me.HeaderHeight = 28
        Me.HeaderStatus = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "SL_RunRecipe"
        Me.Size = New System.Drawing.Size(325, 87)
        Me.Text = "Run Process Recipe"
        Me.Controls.SetChildIndex(Me.txtProcessRecipe, 0)
        Me.Controls.SetChildIndex(Me.btnPause, 0)
        Me.Controls.SetChildIndex(Me.btnAbort, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnStart, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProcessRecipe As System.Windows.Forms.TextBox
    Friend WithEvents btnStart As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnPause As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnAbort As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents ValueToolTip As System.Windows.Forms.ToolTip

End Class
