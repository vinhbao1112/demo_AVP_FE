<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDRunRecipe
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
        Me.btnPauseRealDevice = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnQuickView = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Recipe"
        '
        'txtProcessRecipe
        '
        Me.txtProcessRecipe.BackColor = System.Drawing.SystemColors.Window
        Me.txtProcessRecipe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtProcessRecipe.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtProcessRecipe.Location = New System.Drawing.Point(102, 32)
        Me.txtProcessRecipe.Name = "txtProcessRecipe"
        Me.txtProcessRecipe.ReadOnly = True
        Me.txtProcessRecipe.Size = New System.Drawing.Size(205, 24)
        Me.txtProcessRecipe.TabIndex = 13
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.Transparent
        Me.btnStart.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStart.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnStart.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStart.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnStart.FlatAppearance.BorderSize = 0
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.Black
        Me.btnStart.Location = New System.Drawing.Point(6, 58)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnStart.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnStart.Size = New System.Drawing.Size(80, 31)
        Me.btnStart.TabIndex = 15
        Me.btnStart.Text = "Start"
        Me.btnStart.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'btnPause
        '
        Me.btnPause.BackColor = System.Drawing.Color.Transparent
        Me.btnPause.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPause.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnPause.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPause.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPause.Enabled = False
        Me.btnPause.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPause.FlatAppearance.BorderSize = 0
        Me.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPause.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPause.ForeColor = System.Drawing.Color.Black
        Me.btnPause.Location = New System.Drawing.Point(86, 58)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPause.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPause.Size = New System.Drawing.Size(79, 31)
        Me.btnPause.TabIndex = 15
        Me.btnPause.Text = "Pause"
        Me.btnPause.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPause.UseVisualStyleBackColor = False
        '
        'btnAbort
        '
        Me.btnAbort.BackColor = System.Drawing.Color.Transparent
        Me.btnAbort.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAbort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbort.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAbort.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAbort.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbort.Enabled = False
        Me.btnAbort.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAbort.FlatAppearance.BorderSize = 0
        Me.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbort.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbort.ForeColor = System.Drawing.Color.Black
        Me.btnAbort.Location = New System.Drawing.Point(165, 58)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAbort.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAbort.Size = New System.Drawing.Size(142, 31)
        Me.btnAbort.TabIndex = 15
        Me.btnAbort.Text = "End Current Step"
        Me.btnAbort.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
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
        'btnPauseRealDevice
        '
        Me.btnPauseRealDevice.BackColor = System.Drawing.Color.Transparent
        Me.btnPauseRealDevice.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPauseRealDevice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPauseRealDevice.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnPauseRealDevice.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPauseRealDevice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPauseRealDevice.Enabled = False
        Me.btnPauseRealDevice.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPauseRealDevice.FlatAppearance.BorderSize = 0
        Me.btnPauseRealDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPauseRealDevice.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPauseRealDevice.ForeColor = System.Drawing.Color.Black
        Me.btnPauseRealDevice.Location = New System.Drawing.Point(86, 58)
        Me.btnPauseRealDevice.Name = "btnPauseRealDevice"
        Me.btnPauseRealDevice.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPauseRealDevice.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPauseRealDevice.Size = New System.Drawing.Size(79, 31)
        Me.btnPauseRealDevice.TabIndex = 15
        Me.btnPauseRealDevice.Text = "Resume"
        Me.btnPauseRealDevice.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPauseRealDevice.UseVisualStyleBackColor = False
        Me.btnPauseRealDevice.Visible = False
        '
        'btnQuickView
        '
        Me.btnQuickView.BackColor = System.Drawing.SystemColors.Control
        Me.btnQuickView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuickView.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuickView.Image = Global.AVP_Robot_Project.My.Resources.Resources.Quick_View
        Me.btnQuickView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuickView.Location = New System.Drawing.Point(61, 31)
        Me.btnQuickView.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnQuickView.Name = "btnQuickView"
        Me.btnQuickView.Size = New System.Drawing.Size(40, 27)
        Me.btnQuickView.TabIndex = 16
        Me.btnQuickView.UseVisualStyleBackColor = False
        '
        'PVDRunRecipe
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnQuickView)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.btnPause)
        Me.Controls.Add(Me.txtProcessRecipe)
        Me.Controls.Add(Me.btnPauseRealDevice)
        Me.DoubleBuffered = True
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "PVDRunRecipe"
        Me.Size = New System.Drawing.Size(314, 95)
        Me.Text = "Run Process Recipe"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.btnPauseRealDevice, 0)
        Me.Controls.SetChildIndex(Me.txtProcessRecipe, 0)
        Me.Controls.SetChildIndex(Me.btnPause, 0)
        Me.Controls.SetChildIndex(Me.btnAbort, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnStart, 0)
        Me.Controls.SetChildIndex(Me.btnQuickView, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProcessRecipe As System.Windows.Forms.TextBox
    Friend WithEvents btnStart As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnPause As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnAbort As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents ValueToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnPauseRealDevice As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnQuickView As System.Windows.Forms.Button

End Class
