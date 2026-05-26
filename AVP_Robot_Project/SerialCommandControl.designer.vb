<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SerialCommandControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SerialCommandControl))
        Me.btnSend = New System.Windows.Forms.Button
        Me.txtCommand = New System.Windows.Forms.TextBox
        Me.txtResponse = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboSerialCommand = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = CType(resources.GetObject("Header.BackgroundImage"), System.Drawing.Image)
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.Status = AVP_Robot_Project.DisplayStatus.[On]
        Me.Header.Text = "SERIAL COMMAND"
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.SystemColors.Control
        Me.btnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSend.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.Location = New System.Drawing.Point(367, 47)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(92, 28)
        Me.btnSend.TabIndex = 3
        Me.btnSend.Text = "SEND"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'txtCommand
        '
        Me.txtCommand.BackColor = System.Drawing.SystemColors.Window
        Me.txtCommand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCommand.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommand.Location = New System.Drawing.Point(8, 47)
        Me.txtCommand.Name = "txtCommand"
        Me.txtCommand.ReadOnly = True
        Me.txtCommand.Size = New System.Drawing.Size(350, 26)
        Me.txtCommand.TabIndex = 2
        '
        'txtResponse
        '
        Me.txtResponse.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResponse.Location = New System.Drawing.Point(8, 79)
        Me.txtResponse.Multiline = True
        Me.txtResponse.Name = "txtResponse"
        Me.txtResponse.ReadOnly = True
        Me.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtResponse.Size = New System.Drawing.Size(350, 95)
        Me.txtResponse.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(367, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "RESPONSE"
        '
        'cboSerialCommand
        '
        Me.cboSerialCommand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSerialCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSerialCommand.DropDownWidth = 50
        Me.cboSerialCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSerialCommand.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSerialCommand.FormattingEnabled = True
        Me.cboSerialCommand.ItemHeight = 19
        Me.cboSerialCommand.Items.AddRange(New Object() {"ROBOT"})
        Me.cboSerialCommand.Location = New System.Drawing.Point(8, 14)
        Me.cboSerialCommand.Name = "cboSerialCommand"
        Me.cboSerialCommand.Size = New System.Drawing.Size(350, 27)
        Me.cboSerialCommand.TabIndex = 1
        '
        'SerialCommandControl
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.cboSerialCommand)
        Me.Controls.Add(Me.txtResponse)
        Me.Controls.Add(Me.txtCommand)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderStatus = DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.HeaderVisible = False
        Me.Name = "SerialCommandControl"
        Me.Size = New System.Drawing.Size(460, 185)
        Me.Text = "SERIAL COMMAND"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnSend, 0)
        Me.Controls.SetChildIndex(Me.txtCommand, 0)
        Me.Controls.SetChildIndex(Me.txtResponse, 0)
        Me.Controls.SetChildIndex(Me.cboSerialCommand, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents txtCommand As System.Windows.Forms.TextBox
    Friend WithEvents txtResponse As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSerialCommand As System.Windows.Forms.ComboBox

End Class
