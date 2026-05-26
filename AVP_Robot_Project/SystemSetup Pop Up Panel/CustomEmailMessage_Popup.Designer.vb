<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomEmailMessage_Popup
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
        Me.btnSend = New System.Windows.Forms.Button
        Me.lblTo = New System.Windows.Forms.Label
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.errValidateEmailTo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.lblSubject = New System.Windows.Forms.Label
        Me.txtContent = New System.Windows.Forms.TextBox
        Me.FormContainer.SuspendLayout()
        CType(Me.errValidateEmailTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.txtContent)
        Me.FormContainer.Controls.Add(Me.txtSubject)
        Me.FormContainer.Controls.Add(Me.lblSubject)
        Me.FormContainer.Controls.Add(Me.txtTo)
        Me.FormContainer.Controls.Add(Me.btnSend)
        Me.FormContainer.Controls.Add(Me.lblTo)
        Me.FormContainer.Size = New System.Drawing.Size(919, 396)
        '
        'btnSend
        '
        Me.btnSend.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.Location = New System.Drawing.Point(12, 115)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 34)
        Me.btnSend.TabIndex = 31
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTo.Location = New System.Drawing.Point(8, 11)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(44, 24)
        Me.lblTo.TabIndex = 29
        Me.lblTo.Text = "To :"
        '
        'txtTo
        '
        Me.txtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTo.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtTo.Location = New System.Drawing.Point(93, 8)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(819, 32)
        Me.txtTo.TabIndex = 28
        '
        'errValidateEmailTo
        '
        Me.errValidateEmailTo.ContainerControl = Me
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtSubject.Location = New System.Drawing.Point(93, 48)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(819, 32)
        Me.txtSubject.TabIndex = 29
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblSubject.Location = New System.Drawing.Point(8, 51)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(89, 24)
        Me.lblSubject.TabIndex = 82
        Me.lblSubject.Text = "Subject :"
        '
        'txtContent
        '
        Me.txtContent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContent.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtContent.Location = New System.Drawing.Point(93, 116)
        Me.txtContent.Multiline = True
        Me.txtContent.Name = "txtContent"
        Me.txtContent.Size = New System.Drawing.Size(819, 272)
        Me.txtContent.TabIndex = 30
        '
        'CustomEmailMessage_Popup
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(929, 441)
        Me.Name = "CustomEmailMessage_Popup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Target Power"
        Me.Text = "Custom Email Message"
        Me.FormContainer.ResumeLayout(False)
        Me.FormContainer.PerformLayout()
        CType(Me.errValidateEmailTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents errValidateEmailTo As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
End Class
