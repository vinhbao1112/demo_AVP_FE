<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WaferInfoDlg
    Inherits AVPControls.AVPPopupForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Slot = New System.Windows.Forms.Label()
        Me.cbcSlot = New System.Windows.Forms.ComboBox()
        Me.cbcLoadLock = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbcWaferID = New System.Windows.Forms.ComboBox()
        Me.cbcStatus = New System.Windows.Forms.ComboBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.OK_Button = New AVPControls.AVPButton()
        Me.Cancel_Button = New AVPControls.AVPButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblWaferStatus = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.FormContainer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.Panel4)
        Me.FormContainer.Controls.Add(Me.Panel3)
        Me.FormContainer.Location = New System.Drawing.Point(5, 70)
        Me.FormContainer.Size = New System.Drawing.Size(395, 317)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Slot)
        Me.Panel1.Controls.Add(Me.cbcSlot)
        Me.Panel1.Controls.Add(Me.cbcLoadLock)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cbcWaferID)
        Me.Panel1.Controls.Add(Me.cbcStatus)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(395, 200)
        Me.Panel1.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox1.Location = New System.Drawing.Point(0, 197)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(395, 3)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Slot
        '
        Me.Slot.AutoSize = True
        Me.Slot.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Slot.Location = New System.Drawing.Point(13, 153)
        Me.Slot.Name = "Slot"
        Me.Slot.Size = New System.Drawing.Size(44, 23)
        Me.Slot.TabIndex = 5
        Me.Slot.Text = "Slot"
        '
        'cbcSlot
        '
        Me.cbcSlot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbcSlot.BackColor = System.Drawing.Color.White
        Me.cbcSlot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbcSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcSlot.Enabled = False
        Me.cbcSlot.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcSlot.ForeColor = System.Drawing.Color.Black
        Me.cbcSlot.FormattingEnabled = True
        Me.cbcSlot.Location = New System.Drawing.Point(121, 152)
        Me.cbcSlot.Name = "cbcSlot"
        Me.cbcSlot.Size = New System.Drawing.Size(264, 29)
        Me.cbcSlot.TabIndex = 6
        '
        'cbcLoadLock
        '
        Me.cbcLoadLock.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbcLoadLock.BackColor = System.Drawing.Color.White
        Me.cbcLoadLock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbcLoadLock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcLoadLock.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcLoadLock.ForeColor = System.Drawing.Color.Black
        Me.cbcLoadLock.FormattingEnabled = True
        Me.cbcLoadLock.Location = New System.Drawing.Point(121, 14)
        Me.cbcLoadLock.MaxDropDownItems = 24
        Me.cbcLoadLock.Name = "cbcLoadLock"
        Me.cbcLoadLock.Size = New System.Drawing.Size(264, 29)
        Me.cbcLoadLock.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "LoadLock"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 23)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Wafer ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Status"
        '
        'cbcWaferID
        '
        Me.cbcWaferID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbcWaferID.BackColor = System.Drawing.Color.White
        Me.cbcWaferID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbcWaferID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcWaferID.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcWaferID.ForeColor = System.Drawing.Color.Black
        Me.cbcWaferID.FormattingEnabled = True
        Me.cbcWaferID.Location = New System.Drawing.Point(121, 60)
        Me.cbcWaferID.MaxDropDownItems = 24
        Me.cbcWaferID.Name = "cbcWaferID"
        Me.cbcWaferID.Size = New System.Drawing.Size(264, 29)
        Me.cbcWaferID.TabIndex = 2
        '
        'cbcStatus
        '
        Me.cbcStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbcStatus.BackColor = System.Drawing.Color.White
        Me.cbcStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbcStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcStatus.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcStatus.ForeColor = System.Drawing.Color.Black
        Me.cbcStatus.FormattingEnabled = True
        Me.cbcStatus.Location = New System.Drawing.Point(121, 106)
        Me.cbcStatus.Name = "cbcStatus"
        Me.cbcStatus.Size = New System.Drawing.Size(264, 29)
        Me.cbcStatus.TabIndex = 3
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(395, 3)
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.OK_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.OK_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OK_Button.Enabled = False
        Me.OK_Button.FlatAppearance.BorderSize = 0
        Me.OK_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.OK_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = Global.AVP_Robot_Project.My.Resources.Resources.apply
        Me.OK_Button.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.OK_Button.Location = New System.Drawing.Point(55, 18)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.OK_Button.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.OK_Button.Size = New System.Drawing.Size(111, 35)
        Me.OK_Button.TabIndex = 4
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.Cancel_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatAppearance.BorderSize = 0
        Me.Cancel_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cancel_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_Button.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Image = Global.AVP_Robot_Project.My.Resources.Resources.cancel
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cancel_Button.Location = New System.Drawing.Point(218, 18)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.Cancel_Button.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.Cancel_Button.Size = New System.Drawing.Size(111, 35)
        Me.Cancel_Button.TabIndex = 5
        Me.Cancel_Button.Text = " Cancel"
        Me.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblWaferStatus)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 200)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(395, 49)
        Me.Panel2.TabIndex = 2
        '
        'lblWaferStatus
        '
        Me.lblWaferStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWaferStatus.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaferStatus.ForeColor = System.Drawing.Color.Red
        Me.lblWaferStatus.Location = New System.Drawing.Point(3, 12)
        Me.lblWaferStatus.Name = "lblWaferStatus"
        Me.lblWaferStatus.Size = New System.Drawing.Size(389, 24)
        Me.lblWaferStatus.TabIndex = 1
        Me.lblWaferStatus.Text = "No Process Scheduled!"
        Me.lblWaferStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(395, 249)
        Me.Panel4.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.OK_Button)
        Me.Panel3.Controls.Add(Me.Cancel_Button)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 249)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(395, 68)
        Me.Panel3.TabIndex = 6
        '
        'WaferInfoDlg
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(405, 392)
        Me.HeaderHeight = 70
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WaferInfoDlg"
        Me.ShowButton = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Wafer Information"
        Me.FormContainer.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblWaferStatus As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents OK_Button As AVPControls.AVPButton
    Friend WithEvents Cancel_Button As AVPControls.AVPButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Slot As System.Windows.Forms.Label
    Friend WithEvents cbcSlot As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cbcLoadLock As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbcWaferID As System.Windows.Forms.ComboBox
    Friend WithEvents cbcStatus As System.Windows.Forms.ComboBox

End Class
