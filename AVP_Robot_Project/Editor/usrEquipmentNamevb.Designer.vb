<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrEquipmentName
    Inherits System.Windows.Forms.UserControl

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
        Me.components = New System.ComponentModel.Container
        Me.lblEquipment = New System.Windows.Forms.Label
        Me.txtWaferFlow = New System.Windows.Forms.TextBox
        Me.btnWaferFlow = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.recipeTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEquipment
        '
        Me.lblEquipment.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblEquipment.Enabled = False
        Me.lblEquipment.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquipment.Location = New System.Drawing.Point(0, 0)
        Me.lblEquipment.Name = "lblEquipment"
        Me.lblEquipment.Size = New System.Drawing.Size(75, 47)
        Me.lblEquipment.TabIndex = 10
        Me.lblEquipment.Text = "Aligner"
        Me.lblEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtWaferFlow
        '
        Me.txtWaferFlow.BackColor = System.Drawing.SystemColors.Window
        Me.txtWaferFlow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtWaferFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWaferFlow.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWaferFlow.Location = New System.Drawing.Point(0, 0)
        Me.txtWaferFlow.Multiline = True
        Me.txtWaferFlow.Name = "txtWaferFlow"
        Me.txtWaferFlow.ReadOnly = True
        Me.txtWaferFlow.Size = New System.Drawing.Size(288, 37)
        Me.txtWaferFlow.TabIndex = 10
        Me.txtWaferFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnWaferFlow
        '
        Me.btnWaferFlow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWaferFlow.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnWaferFlow.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWaferFlow.Location = New System.Drawing.Point(360, 5)
        Me.btnWaferFlow.Name = "btnWaferFlow"
        Me.btnWaferFlow.Size = New System.Drawing.Size(35, 37)
        Me.btnWaferFlow.TabIndex = 10
        Me.btnWaferFlow.Text = "..."
        Me.btnWaferFlow.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(75, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(325, 5)
        Me.Label1.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtWaferFlow)
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(75, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(288, 37)
        Me.Panel1.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Location = New System.Drawing.Point(75, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(325, 5)
        Me.Label2.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label3.Location = New System.Drawing.Point(395, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(5, 37)
        Me.Label3.TabIndex = 14
        '
        'recipeTooltip
        '
        Me.recipeTooltip.IsBalloon = True
        '
        'usrEquipmentName
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Controls.Add(Me.btnWaferFlow)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblEquipment)
        Me.Name = "usrEquipmentName"
        Me.Size = New System.Drawing.Size(400, 47)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents txtWaferFlow As System.Windows.Forms.TextBox
    Friend WithEvents lblEquipment As System.Windows.Forms.Label
    Friend WithEvents btnWaferFlow As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents recipeTooltip As System.Windows.Forms.ToolTip

End Class
