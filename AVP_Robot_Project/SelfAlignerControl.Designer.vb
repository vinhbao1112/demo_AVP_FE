<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelfAlignerControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelfAlignerControl))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblSlot = New System.Windows.Forms.Label
        Me.cboListSlot = New System.Windows.Forms.ComboBox
        Me.txtRTAfter = New System.Windows.Forms.TextBox
        Me.lblRTAfter = New System.Windows.Forms.Label
        Me.txtRTBefore = New System.Windows.Forms.TextBox
        Me.lblRTBefore = New System.Windows.Forms.Label
        Me.lblRecipeAligner = New System.Windows.Forms.Label
        Me.lblStation = New System.Windows.Forms.Label
        Me.cboListStation = New System.Windows.Forms.ComboBox
        Me.btnSelfAligner = New AVP_Robot_Project.ButtonIGCGControl
        Me.cboRecipeAligner = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = CType(resources.GetObject("Header.BackgroundImage"), System.Drawing.Image)
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.Size = New System.Drawing.Size(150, 28)
        Me.Header.Status = AVP_Robot_Project.DisplayStatus.[On]
        Me.Header.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboRecipeAligner)
        Me.GroupBox1.Controls.Add(Me.lblSlot)
        Me.GroupBox1.Controls.Add(Me.cboListSlot)
        Me.GroupBox1.Controls.Add(Me.txtRTAfter)
        Me.GroupBox1.Controls.Add(Me.lblRTAfter)
        Me.GroupBox1.Controls.Add(Me.txtRTBefore)
        Me.GroupBox1.Controls.Add(Me.lblRTBefore)
        Me.GroupBox1.Controls.Add(Me.lblRecipeAligner)
        Me.GroupBox1.Controls.Add(Me.lblStation)
        Me.GroupBox1.Controls.Add(Me.cboListStation)
        Me.GroupBox1.Controls.Add(Me.btnSelfAligner)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(445, 172)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Self Align Control"
        '
        'lblSlot
        '
        Me.lblSlot.AutoSize = True
        Me.lblSlot.ForeColor = System.Drawing.Color.Black
        Me.lblSlot.Location = New System.Drawing.Point(23, 71)
        Me.lblSlot.Name = "lblSlot"
        Me.lblSlot.Size = New System.Drawing.Size(35, 19)
        Me.lblSlot.TabIndex = 66
        Me.lblSlot.Text = "Slot"
        '
        'cboListSlot
        '
        Me.cboListSlot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboListSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboListSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboListSlot.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cboListSlot.FormattingEnabled = True
        Me.cboListSlot.Location = New System.Drawing.Point(55, 93)
        Me.cboListSlot.Name = "cboListSlot"
        Me.cboListSlot.Size = New System.Drawing.Size(120, 24)
        Me.cboListSlot.TabIndex = 65
        '
        'txtRTAfter
        '
        Me.txtRTAfter.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtRTAfter.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRTAfter.Location = New System.Drawing.Point(261, 94)
        Me.txtRTAfter.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtRTAfter.Multiline = True
        Me.txtRTAfter.Name = "txtRTAfter"
        Me.txtRTAfter.ReadOnly = True
        Me.txtRTAfter.Size = New System.Drawing.Size(145, 24)
        Me.txtRTAfter.TabIndex = 61
        '
        'lblRTAfter
        '
        Me.lblRTAfter.AutoSize = True
        Me.lblRTAfter.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRTAfter.ForeColor = System.Drawing.Color.Black
        Me.lblRTAfter.Location = New System.Drawing.Point(213, 71)
        Me.lblRTAfter.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblRTAfter.Name = "lblRTAfter"
        Me.lblRTAfter.Size = New System.Drawing.Size(84, 19)
        Me.lblRTAfter.TabIndex = 59
        Me.lblRTAfter.Text = "R/T (After)"
        '
        'txtRTBefore
        '
        Me.txtRTBefore.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtRTBefore.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRTBefore.Location = New System.Drawing.Point(261, 44)
        Me.txtRTBefore.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtRTBefore.Multiline = True
        Me.txtRTBefore.Name = "txtRTBefore"
        Me.txtRTBefore.ReadOnly = True
        Me.txtRTBefore.Size = New System.Drawing.Size(145, 24)
        Me.txtRTBefore.TabIndex = 55
        '
        'lblRTBefore
        '
        Me.lblRTBefore.AutoSize = True
        Me.lblRTBefore.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRTBefore.ForeColor = System.Drawing.Color.Black
        Me.lblRTBefore.Location = New System.Drawing.Point(213, 22)
        Me.lblRTBefore.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblRTBefore.Name = "lblRTBefore"
        Me.lblRTBefore.Size = New System.Drawing.Size(95, 19)
        Me.lblRTBefore.TabIndex = 47
        Me.lblRTBefore.Text = "R/T (Before)"
        '
        'lblRecipeAligner
        '
        Me.lblRecipeAligner.AutoSize = True
        Me.lblRecipeAligner.ForeColor = System.Drawing.Color.Black
        Me.lblRecipeAligner.Location = New System.Drawing.Point(23, 120)
        Me.lblRecipeAligner.Name = "lblRecipeAligner"
        Me.lblRecipeAligner.Size = New System.Drawing.Size(108, 19)
        Me.lblRecipeAligner.TabIndex = 28
        Me.lblRecipeAligner.Text = "Recipe Aligner"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.ForeColor = System.Drawing.Color.Black
        Me.lblStation.Location = New System.Drawing.Point(23, 22)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(56, 19)
        Me.lblStation.TabIndex = 16
        Me.lblStation.Text = "Station"
        '
        'cboListStation
        '
        Me.cboListStation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboListStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboListStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboListStation.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cboListStation.FormattingEnabled = True
        Me.cboListStation.Location = New System.Drawing.Point(55, 44)
        Me.cboListStation.Name = "cboListStation"
        Me.cboListStation.Size = New System.Drawing.Size(120, 24)
        Me.cboListStation.TabIndex = 12
        '
        'btnSelfAligner
        '
        Me.btnSelfAligner.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSelfAligner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSelfAligner.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnSelfAligner.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelfAligner.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnSelfAligner.FlatAppearance.BorderSize = 0
        Me.btnSelfAligner.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelfAligner.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelfAligner.ForeColor = System.Drawing.Color.Black
        Me.btnSelfAligner.Location = New System.Drawing.Point(261, 132)
        Me.btnSelfAligner.Name = "btnSelfAligner"
        Me.btnSelfAligner.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSelfAligner.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnSelfAligner.Size = New System.Drawing.Size(145, 32)
        Me.btnSelfAligner.TabIndex = 27
        Me.btnSelfAligner.Text = "Start Self Align"
        Me.btnSelfAligner.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnSelfAligner.UseVisualStyleBackColor = True
        '
        'cboRecipeAligner
        '
        Me.cboRecipeAligner.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRecipeAligner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecipeAligner.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRecipeAligner.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cboRecipeAligner.FormattingEnabled = True
        Me.cboRecipeAligner.Items.AddRange(New Object() {"ALIGN_0", "ALIGN_90", "ALIGN_180", "ALIGN_270"})
        Me.cboRecipeAligner.Location = New System.Drawing.Point(55, 142)
        Me.cboRecipeAligner.Name = "cboRecipeAligner"
        Me.cboRecipeAligner.Size = New System.Drawing.Size(120, 24)
        Me.cboRecipeAligner.TabIndex = 67
        '
        'SelfAlignerControl
        '
        Me.Controls.Add(Me.GroupBox1)
        Me.HeaderHeight = 28
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.HeaderVisible = False
        Me.Name = "SelfAlignerControl"
        Me.Size = New System.Drawing.Size(460, 185)
        Me.Text = ""
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboListStation As System.Windows.Forms.ComboBox
    Friend WithEvents btnSelfAligner As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents lblRecipeAligner As System.Windows.Forms.Label
    Friend WithEvents lblRTBefore As System.Windows.Forms.Label
    Friend WithEvents txtRTBefore As System.Windows.Forms.TextBox
    Friend WithEvents txtRTAfter As System.Windows.Forms.TextBox
    Friend WithEvents lblRTAfter As System.Windows.Forms.Label
    Friend WithEvents lblSlot As System.Windows.Forms.Label
    Friend WithEvents cboListSlot As System.Windows.Forms.ComboBox
    Friend WithEvents cboRecipeAligner As System.Windows.Forms.ComboBox

End Class
