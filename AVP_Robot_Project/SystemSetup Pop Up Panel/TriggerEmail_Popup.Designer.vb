<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TriggerEmail_Popup
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
        Me.components = New System.ComponentModel.Container
        Me.lblPadding = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.gbTrigger = New System.Windows.Forms.GroupBox
        Me.chkScheduler = New System.Windows.Forms.CheckBox
        Me.Cancel = New System.Windows.Forms.Button
        Me.Confirm = New System.Windows.Forms.Button
        Me.LEmailTo = New System.Windows.Forms.Label
        Me.txtEmailTo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtEveryMinutes = New System.Windows.Forms.TextBox
        Me.chkReport = New System.Windows.Forms.CheckBox
        Me.chkAlarm = New System.Windows.Forms.CheckBox
        Me.errValidateEmailTo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.FormContainer.SuspendLayout()
        Me.gbTrigger.SuspendLayout()
        CType(Me.errValidateEmailTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.gbTrigger)
        Me.FormContainer.Controls.Add(Me.Label2)
        Me.FormContainer.Controls.Add(Me.lblPadding)
        Me.FormContainer.Size = New System.Drawing.Size(691, 251)
        '
        'lblPadding
        '
        Me.lblPadding.BackColor = System.Drawing.Color.Transparent
        Me.lblPadding.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPadding.Location = New System.Drawing.Point(0, 0)
        Me.lblPadding.Name = "lblPadding"
        Me.lblPadding.Size = New System.Drawing.Size(10, 251)
        Me.lblPadding.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(10, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(681, 5)
        Me.Label2.TabIndex = 80
        '
        'gbTrigger
        '
        Me.gbTrigger.Controls.Add(Me.chkScheduler)
        Me.gbTrigger.Controls.Add(Me.Cancel)
        Me.gbTrigger.Controls.Add(Me.Confirm)
        Me.gbTrigger.Controls.Add(Me.LEmailTo)
        Me.gbTrigger.Controls.Add(Me.txtEmailTo)
        Me.gbTrigger.Controls.Add(Me.Label9)
        Me.gbTrigger.Controls.Add(Me.Label8)
        Me.gbTrigger.Controls.Add(Me.txtEveryMinutes)
        Me.gbTrigger.Controls.Add(Me.chkReport)
        Me.gbTrigger.Controls.Add(Me.chkAlarm)
        Me.gbTrigger.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTrigger.Location = New System.Drawing.Point(8, 10)
        Me.gbTrigger.Name = "gbTrigger"
        Me.gbTrigger.Size = New System.Drawing.Size(673, 231)
        Me.gbTrigger.TabIndex = 81
        Me.gbTrigger.TabStop = False
        Me.gbTrigger.Text = "Trigger"
        '
        'chkScheduler
        '
        Me.chkScheduler.AutoSize = True
        Me.chkScheduler.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.chkScheduler.Location = New System.Drawing.Point(62, 143)
        Me.chkScheduler.Name = "chkScheduler"
        Me.chkScheduler.Size = New System.Drawing.Size(190, 21)
        Me.chkScheduler.TabIndex = 32
        Me.chkScheduler.Text = "Scheduler Status Change"
        Me.chkScheduler.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cancel.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.Location = New System.Drawing.Point(575, 179)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 32)
        Me.Cancel.TabIndex = 31
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'Confirm
        '
        Me.Confirm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Confirm.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Confirm.Location = New System.Drawing.Point(483, 179)
        Me.Confirm.Name = "Confirm"
        Me.Confirm.Size = New System.Drawing.Size(75, 32)
        Me.Confirm.TabIndex = 25
        Me.Confirm.Text = "OK" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Confirm.UseVisualStyleBackColor = True
        '
        'LEmailTo
        '
        Me.LEmailTo.AutoSize = True
        Me.LEmailTo.Location = New System.Drawing.Point(100, 45)
        Me.LEmailTo.Name = "LEmailTo"
        Me.LEmailTo.Size = New System.Drawing.Size(101, 24)
        Me.LEmailTo.TabIndex = 29
        Me.LEmailTo.Text = "Email To :"
        '
        'txtEmailTo
        '
        Me.txtEmailTo.Location = New System.Drawing.Point(207, 42)
        Me.txtEmailTo.Name = "txtEmailTo"
        Me.txtEmailTo.Size = New System.Drawing.Size(332, 32)
        Me.txtEmailTo.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(194, 179)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 17)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "every"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(310, 180)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 17)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Mins"
        '
        'txtEveryMinutes
        '
        Me.txtEveryMinutes.AccessibleDescription = ""
        Me.txtEveryMinutes.BackColor = System.Drawing.SystemColors.Window
        Me.txtEveryMinutes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtEveryMinutes.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEveryMinutes.Location = New System.Drawing.Point(253, 176)
        Me.txtEveryMinutes.Name = "txtEveryMinutes"
        Me.txtEveryMinutes.ReadOnly = True
        Me.txtEveryMinutes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEveryMinutes.Size = New System.Drawing.Size(55, 25)
        Me.txtEveryMinutes.TabIndex = 5
        Me.txtEveryMinutes.Text = "20"
        '
        'chkReport
        '
        Me.chkReport.AutoSize = True
        Me.chkReport.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.chkReport.Location = New System.Drawing.Point(62, 179)
        Me.chkReport.Name = "chkReport"
        Me.chkReport.Size = New System.Drawing.Size(136, 21)
        Me.chkReport.TabIndex = 2
        Me.chkReport.Text = "Report Pressure"
        Me.chkReport.UseVisualStyleBackColor = True
        '
        'chkAlarm
        '
        Me.chkAlarm.AutoSize = True
        Me.chkAlarm.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.chkAlarm.Location = New System.Drawing.Point(62, 107)
        Me.chkAlarm.Name = "chkAlarm"
        Me.chkAlarm.Size = New System.Drawing.Size(67, 21)
        Me.chkAlarm.TabIndex = 0
        Me.chkAlarm.Text = "Alarm"
        Me.chkAlarm.UseVisualStyleBackColor = True
        '
        'errValidateEmailTo
        '
        Me.errValidateEmailTo.ContainerControl = Me
        '
        'TriggerEmail_Popup
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(701, 296)
        Me.Name = "TriggerEmail_Popup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Target Power"
        Me.Text = "Trigger Email"
        Me.FormContainer.ResumeLayout(False)
        Me.gbTrigger.ResumeLayout(False)
        Me.gbTrigger.PerformLayout()
        CType(Me.errValidateEmailTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblPadding As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbTrigger As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEveryMinutes As System.Windows.Forms.TextBox
    Friend WithEvents chkReport As System.Windows.Forms.CheckBox
    Friend WithEvents chkAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents LEmailTo As System.Windows.Forms.Label
    Friend WithEvents txtEmailTo As System.Windows.Forms.TextBox
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Confirm As System.Windows.Forms.Button
    Friend WithEvents errValidateEmailTo As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkScheduler As System.Windows.Forms.CheckBox
End Class
