<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDTarControl
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
        Me.lblTar = New System.Windows.Forms.Label
        Me.lblTargetMaterial = New System.Windows.Forms.Label
        Me.bicPlasmaIgniter = New AVP_Robot_Project.ButtonIGCGControl
        Me.SuspendLayout()
        '
        'lblTar
        '
        Me.lblTar.AutoSize = True
        Me.lblTar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTar.Location = New System.Drawing.Point(50, 12)
        Me.lblTar.Name = "lblTar"
        Me.lblTar.Size = New System.Drawing.Size(54, 19)
        Me.lblTar.TabIndex = 8
        Me.lblTar.Text = "Target"
        '
        'lblTargetMaterial
        '
        Me.lblTargetMaterial.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetMaterial.Location = New System.Drawing.Point(8, 33)
        Me.lblTargetMaterial.Name = "lblTargetMaterial"
        Me.lblTargetMaterial.Size = New System.Drawing.Size(136, 15)
        Me.lblTargetMaterial.TabIndex = 9
        Me.lblTargetMaterial.Text = "<Target Material here>"
        Me.lblTargetMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bicPlasmaIgniter
        '
        Me.bicPlasmaIgniter.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.bicPlasmaIgniter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bicPlasmaIgniter.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bicPlasmaIgniter.ColorText_OffStatus = System.Drawing.Color.Black
        Me.bicPlasmaIgniter.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bicPlasmaIgniter.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bicPlasmaIgniter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bicPlasmaIgniter.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_Off
        Me.bicPlasmaIgniter.ErrorText = ""
        Me.bicPlasmaIgniter.FlatAppearance.BorderSize = 0
        Me.bicPlasmaIgniter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bicPlasmaIgniter.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bicPlasmaIgniter.ForeColor = System.Drawing.Color.Black
        Me.bicPlasmaIgniter.Location = New System.Drawing.Point(147, 16)
        Me.bicPlasmaIgniter.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.bicPlasmaIgniter.Name = "bicPlasmaIgniter"
        Me.bicPlasmaIgniter.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.bicPlasmaIgniter.OffText = ""
        Me.bicPlasmaIgniter.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower
        Me.bicPlasmaIgniter.OnText = ""
        Me.bicPlasmaIgniter.Size = New System.Drawing.Size(30, 30)
        Me.bicPlasmaIgniter.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bicPlasmaIgniter.StyleOfButton = ButtonStyle.Horizontal
        Me.bicPlasmaIgniter.TabIndex = 20
        Me.bicPlasmaIgniter.Text = "P.I"
        Me.bicPlasmaIgniter.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.btnPBNPower_Off
        Me.bicPlasmaIgniter.UnKnownText = ""
        Me.bicPlasmaIgniter.UseVisualStyleBackColor = True
        '
        'PVDTarControl
        '
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Tar
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.bicPlasmaIgniter)
        Me.Controls.Add(Me.lblTargetMaterial)
        Me.Controls.Add(Me.lblTar)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderHeight = 25
        Me.HeaderVisible = False
        Me.Name = "PVDTarControl"
        Me.Size = New System.Drawing.Size(183, 60)
        Me.Text = "CG"
        Me.Controls.SetChildIndex(Me.lblTar, 0)
        Me.Controls.SetChildIndex(Me.lblTargetMaterial, 0)
        Me.Controls.SetChildIndex(Me.bicPlasmaIgniter, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTar As System.Windows.Forms.Label
    Friend WithEvents lblTargetMaterial As System.Windows.Forms.Label
    Friend WithEvents bicPlasmaIgniter As AVP_Robot_Project.ButtonIGCGControl

End Class
