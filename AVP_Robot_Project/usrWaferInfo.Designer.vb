<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrWaferInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usrWaferInfo))
        Me.lblRecipe = New System.Windows.Forms.Label
        Me.txtRecipe = New System.Windows.Forms.TextBox
        Me.lblWaferID = New System.Windows.Forms.Label
        Me.txtWaferID = New System.Windows.Forms.TextBox
        Me.pnlHeader = New System.Windows.Forms.Panel
        Me.lblHeader = New System.Windows.Forms.Label
        Me.lblAngle = New System.Windows.Forms.Label
        Me.txtAlignAngle = New System.Windows.Forms.TextBox
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = CType(resources.GetObject("Header.BackgroundImage"), System.Drawing.Image)
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.Status = AVP_Robot_Project.DisplayStatus.[On]
        Me.Header.Text = "Wafer Information"
        '
        'lblRecipe
        '
        Me.lblRecipe.AutoSize = True
        Me.lblRecipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecipe.Location = New System.Drawing.Point(16, 45)
        Me.lblRecipe.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblRecipe.Name = "lblRecipe"
        Me.lblRecipe.Size = New System.Drawing.Size(56, 19)
        Me.lblRecipe.TabIndex = 39
        Me.lblRecipe.Text = "Recipe"
        '
        'txtRecipe
        '
        Me.txtRecipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecipe.Location = New System.Drawing.Point(110, 42)
        Me.txtRecipe.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtRecipe.Multiline = True
        Me.txtRecipe.Name = "txtRecipe"
        Me.txtRecipe.ReadOnly = True
        Me.txtRecipe.Size = New System.Drawing.Size(164, 35)
        Me.txtRecipe.TabIndex = 40
        '
        'lblWaferID
        '
        Me.lblWaferID.AutoSize = True
        Me.lblWaferID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaferID.Location = New System.Drawing.Point(16, 91)
        Me.lblWaferID.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblWaferID.Name = "lblWaferID"
        Me.lblWaferID.Size = New System.Drawing.Size(72, 19)
        Me.lblWaferID.TabIndex = 43
        Me.lblWaferID.Text = "Wafer ID"
        '
        'txtWaferID
        '
        Me.txtWaferID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWaferID.Location = New System.Drawing.Point(110, 88)
        Me.txtWaferID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtWaferID.Multiline = True
        Me.txtWaferID.Name = "txtWaferID"
        Me.txtWaferID.ReadOnly = True
        Me.txtWaferID.Size = New System.Drawing.Size(164, 35)
        Me.txtWaferID.TabIndex = 44
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.Transparent
        Me.pnlHeader.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgMsgBoxHeader
        Me.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(301, 30)
        Me.pnlHeader.TabIndex = 45
        '
        'lblHeader
        '
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(301, 30)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Wafer Information"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAngle
        '
        Me.lblAngle.AutoSize = True
        Me.lblAngle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAngle.Location = New System.Drawing.Point(16, 137)
        Me.lblAngle.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAngle.Name = "lblAngle"
        Me.lblAngle.Size = New System.Drawing.Size(48, 19)
        Me.lblAngle.TabIndex = 43
        Me.lblAngle.Text = "Angle"
        '
        'txtAlignAngle
        '
        Me.txtAlignAngle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlignAngle.Location = New System.Drawing.Point(110, 134)
        Me.txtAlignAngle.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtAlignAngle.Multiline = True
        Me.txtAlignAngle.Name = "txtAlignAngle"
        Me.txtAlignAngle.ReadOnly = True
        Me.txtAlignAngle.Size = New System.Drawing.Size(164, 35)
        Me.txtAlignAngle.TabIndex = 44
        '
        'usrWaferInfo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.txtAlignAngle)
        Me.Controls.Add(Me.lblAngle)
        Me.Controls.Add(Me.txtWaferID)
        Me.Controls.Add(Me.lblWaferID)
        Me.Controls.Add(Me.lblRecipe)
        Me.Controls.Add(Me.txtRecipe)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.HeaderVisible = False
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "usrWaferInfo"
        Me.Size = New System.Drawing.Size(301, 186)
        Me.Text = "Wafer Information"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.txtRecipe, 0)
        Me.Controls.SetChildIndex(Me.lblRecipe, 0)
        Me.Controls.SetChildIndex(Me.lblWaferID, 0)
        Me.Controls.SetChildIndex(Me.txtWaferID, 0)
        Me.Controls.SetChildIndex(Me.lblAngle, 0)
        Me.Controls.SetChildIndex(Me.txtAlignAngle, 0)
        Me.Controls.SetChildIndex(Me.pnlHeader, 0)
        Me.pnlHeader.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRecipe As System.Windows.Forms.Label
    Friend WithEvents txtRecipe As System.Windows.Forms.TextBox
    Friend WithEvents lblWaferID As System.Windows.Forms.Label
    Friend WithEvents txtWaferID As System.Windows.Forms.TextBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblAngle As System.Windows.Forms.Label
    Friend WithEvents txtAlignAngle As System.Windows.Forms.TextBox

End Class
