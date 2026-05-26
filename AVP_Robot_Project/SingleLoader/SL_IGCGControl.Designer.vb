<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_IGCGControl
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
        Me.txtIG = New AVP_Robot_Project.SL_Textbox
        Me.txtCG = New AVP_Robot_Project.SL_Textbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSwitchIGFilament = New AVP_Robot_Project.SL_Textbox
        Me.txtEnableIGFilament = New AVP_Robot_Project.SL_Textbox
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Size = New System.Drawing.Size(132, 27)
        Me.Header.Text = "IG - CG"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'txtIG
        '
        Me.txtIG.BackColor = System.Drawing.Color.White
        Me.txtIG.Clickable = False
        Me.txtIG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtIG.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtIG.Location = New System.Drawing.Point(39, 34)
        Me.txtIG.MinimumValueHighlightedGreen = 0
        Me.txtIG.Name = "txtIG"
        Me.txtIG.ReadOnly = True
        Me.txtIG.Size = New System.Drawing.Size(87, 24)
        Me.txtIG.TabIndex = 8
        Me.txtIG.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'txtCG
        '
        Me.txtCG.BackColor = System.Drawing.Color.White
        Me.txtCG.Clickable = False
        Me.txtCG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCG.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCG.Location = New System.Drawing.Point(39, 60)
        Me.txtCG.MinimumValueHighlightedGreen = 0
        Me.txtCG.Name = "txtCG"
        Me.txtCG.ReadOnly = True
        Me.txtCG.Size = New System.Drawing.Size(87, 24)
        Me.txtCG.TabIndex = 8
        Me.txtCG.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 19)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "IG"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 19)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "CG"
        '
        'txtSwitchIGFilament
        '
        Me.txtSwitchIGFilament.BackColor = System.Drawing.Color.White
        Me.txtSwitchIGFilament.Clickable = False
        Me.txtSwitchIGFilament.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSwitchIGFilament.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSwitchIGFilament.Location = New System.Drawing.Point(39, 90)
        Me.txtSwitchIGFilament.MinimumValueHighlightedGreen = 0
        Me.txtSwitchIGFilament.Name = "txtSwitchIGFilament"
        Me.txtSwitchIGFilament.ReadOnly = True
        Me.txtSwitchIGFilament.Size = New System.Drawing.Size(87, 24)
        Me.txtSwitchIGFilament.TabIndex = 10
        Me.txtSwitchIGFilament.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtSwitchIGFilament.Visible = False
        '
        'txtEnableIGFilament
        '
        Me.txtEnableIGFilament.BackColor = System.Drawing.Color.White
        Me.txtEnableIGFilament.Clickable = False
        Me.txtEnableIGFilament.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtEnableIGFilament.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtEnableIGFilament.Location = New System.Drawing.Point(38, 34)
        Me.txtEnableIGFilament.MinimumValueHighlightedGreen = 0
        Me.txtEnableIGFilament.Name = "txtEnableIGFilament"
        Me.txtEnableIGFilament.ReadOnly = True
        Me.txtEnableIGFilament.Size = New System.Drawing.Size(87, 24)
        Me.txtEnableIGFilament.TabIndex = 11
        Me.txtEnableIGFilament.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        '
        'SL_IGCGControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.txtEnableIGFilament)
        Me.Controls.Add(Me.txtSwitchIGFilament)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCG)
        Me.Controls.Add(Me.txtIG)
        Me.HeaderText = "IG - CG"
        Me.Name = "SL_IGCGControl"
        Me.Size = New System.Drawing.Size(132, 91)
        Me.Text = "IG - CG"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.txtIG, 0)
        Me.Controls.SetChildIndex(Me.txtCG, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtSwitchIGFilament, 0)
        Me.Controls.SetChildIndex(Me.txtEnableIGFilament, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIG As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtCG As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSwitchIGFilament As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtEnableIGFilament As AVP_Robot_Project.SL_Textbox

End Class
