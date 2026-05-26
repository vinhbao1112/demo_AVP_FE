<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AVPProcessChimeBox
    Inherits AVPControls.AVPMsgBox

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
        Me.btnAbortOnly = New AVPControls.AVPButton

        Me.SuspendLayout()
        '
        'lblContent
        '
        
        Me.lblContent.Text = "Process Completed"
        
        '
        'btnAbortOnly
        '
        Me.btnAbortOnly.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAbortOnly.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbortOnly.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbortOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbortOnly.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbortOnly.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbortOnly.Location = New System.Drawing.Point(201, 9)
        Me.btnAbortOnly.Name = "btnAbortOnly"
        Me.btnAbortOnly.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAbortOnly.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnAbortOnly.Size = New System.Drawing.Size(120, 40)
        Me.btnAbortOnly.TabIndex = 3
        Me.btnAbortOnly.Text = "Ok"
        Me.btnAbortOnly.UseVisualStyleBackColor = True

     
        Me.ImageIcon = Global.AVP_Robot_Project.My.Resources.Resources.Warning
        
        '
        'AVPProcessChimeBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(537, 239)
        Me.ControlBox = False
        Me.pnlBottom.Controls.Add(Me.btnAbortOnly)

        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "AVPProcessChimeBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AVPMessageBox"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAbortOnly As AVPControls.AVPButton
End Class
