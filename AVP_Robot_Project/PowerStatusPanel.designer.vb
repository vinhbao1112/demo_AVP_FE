<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PowerStatusPanel
    Inherits AVP_Robot_Project.StatusPanel

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
        Me.btnPBNPower = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnRFPower = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnGrid = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnACPower = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'btnPBNPower
        '
        Me.btnPBNPower.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower_Off
        Me.btnPBNPower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPBNPower.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPBNPower.FlatAppearance.BorderSize = 0
        Me.btnPBNPower.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPBNPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPBNPower.ForeColor = System.Drawing.Color.White
        Me.btnPBNPower.Location = New System.Drawing.Point(226, 1)
        Me.btnPBNPower.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPBNPower.Name = "btnPBNPower"
        Me.btnPBNPower.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower_Off
        Me.btnPBNPower.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower
        Me.btnPBNPower.Size = New System.Drawing.Size(70, 30)
        Me.btnPBNPower.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.btnPBNPower.TabIndex = 28
        Me.btnPBNPower.Text = "PBN"
        Me.btnPBNPower.UseVisualStyleBackColor = True
        '
        'btnRFPower
        '
        Me.btnRFPower.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower_Off
        Me.btnRFPower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRFPower.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRFPower.FlatAppearance.BorderSize = 0
        Me.btnRFPower.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRFPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRFPower.ForeColor = System.Drawing.Color.White
        Me.btnRFPower.Location = New System.Drawing.Point(76, 1)
        Me.btnRFPower.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRFPower.Name = "btnRFPower"
        Me.btnRFPower.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower_Off
        Me.btnRFPower.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower
        Me.btnRFPower.Size = New System.Drawing.Size(70, 30)
        Me.btnRFPower.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.btnRFPower.TabIndex = 28
        Me.btnRFPower.Text = "RF Power"
        Me.btnRFPower.UseVisualStyleBackColor = True
        '
        'btnGrid
        '
        Me.btnGrid.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower_Off
        Me.btnGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGrid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGrid.FlatAppearance.BorderSize = 0
        Me.btnGrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrid.ForeColor = System.Drawing.Color.White
        Me.btnGrid.Location = New System.Drawing.Point(151, 1)
        Me.btnGrid.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGrid.Name = "btnGrid"
        Me.btnGrid.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower_Off
        Me.btnGrid.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower
        Me.btnGrid.Size = New System.Drawing.Size(70, 30)
        Me.btnGrid.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.btnGrid.TabIndex = 28
        Me.btnGrid.Text = "Grid"
        Me.btnGrid.UseVisualStyleBackColor = True
        '
        'btnACPower
        '
        Me.btnACPower.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower_Off
        Me.btnACPower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnACPower.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnACPower.FlatAppearance.BorderSize = 0
        Me.btnACPower.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnACPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnACPower.ForeColor = System.Drawing.Color.White
        Me.btnACPower.Location = New System.Drawing.Point(1, 1)
        Me.btnACPower.Margin = New System.Windows.Forms.Padding(2)
        Me.btnACPower.Name = "btnACPower"
        Me.btnACPower.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower_Off
        Me.btnACPower.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower
        Me.btnACPower.Size = New System.Drawing.Size(70, 30)
        Me.btnACPower.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.Off
        Me.btnACPower.TabIndex = 28
        Me.btnACPower.Text = "AC Power"
        Me.btnACPower.UseVisualStyleBackColor = True
        '
        'PowerStatusPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 9.0!)
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Controls.Add(Me.btnPBNPower)
        Me.Controls.Add(Me.btnRFPower)
        Me.Controls.Add(Me.btnGrid)
        Me.Controls.Add(Me.btnACPower)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "PowerStatusPanel"
        Me.Size = New System.Drawing.Size(300, 36)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnACPower As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnGrid As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnRFPower As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnPBNPower As AVP_Robot_Project.ButtonIGCGControl

End Class
