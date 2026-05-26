<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopUp_TerminalMessage
    Inherits AVPControls.AVPPopupForm

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
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtMessageFromHost = New AVP_Robot_Project.SL_Textbox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtMessageToHost = New AVP_Robot_Project.SL_Textbox
        Me.FormContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.txtMessageToHost)
        Me.FormContainer.Controls.Add(Me.Label23)
        Me.FormContainer.Controls.Add(Me.txtMessageFromHost)
        Me.FormContainer.Controls.Add(Me.Label19)
        Me.FormContainer.Size = New System.Drawing.Size(661, 195)
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(0, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(661, 24)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "Terminal Service Messages"
        '
        'txtMessageFromHost
        '
        Me.txtMessageFromHost.BackColor = System.Drawing.Color.White
        Me.txtMessageFromHost.Clickable = False
        Me.txtMessageFromHost.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMessageFromHost.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtMessageFromHost.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMessageFromHost.IsReadBack = False
        Me.txtMessageFromHost.Location = New System.Drawing.Point(0, 24)
        Me.txtMessageFromHost.Multiline = True
        Me.txtMessageFromHost.Name = "txtMessageFromHost"
        Me.txtMessageFromHost.ReadOnly = True
        Me.txtMessageFromHost.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMessageFromHost.Size = New System.Drawing.Size(661, 108)
        Me.txtMessageFromHost.TabIndex = 81
        Me.txtMessageFromHost.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtMessageFromHost.UseScientificFormat = True
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(0, 132)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(661, 22)
        Me.Label23.TabIndex = 82
        Me.Label23.Text = "Message to Host:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMessageToHost
        '
        Me.txtMessageToHost.BackColor = System.Drawing.Color.White
        Me.txtMessageToHost.Clickable = False
        Me.txtMessageToHost.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMessageToHost.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtMessageToHost.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMessageToHost.IsReadBack = False
        Me.txtMessageToHost.Location = New System.Drawing.Point(0, 154)
        Me.txtMessageToHost.Multiline = True
        Me.txtMessageToHost.Name = "txtMessageToHost"
        Me.txtMessageToHost.ReadOnly = True
        Me.txtMessageToHost.Size = New System.Drawing.Size(661, 29)
        Me.txtMessageToHost.TabIndex = 83
        Me.txtMessageToHost.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtMessageToHost.UseScientificFormat = True
        '
        'PopUp_TerminalMessage
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(671, 240)
        Me.Name = "PopUp_TerminalMessage"
        Me.Text = "PopUp_TerminalMessage"
        Me.FormContainer.ResumeLayout(False)
        Me.FormContainer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtMessageFromHost As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtMessageToHost As AVP_Robot_Project.SL_Textbox
End Class
