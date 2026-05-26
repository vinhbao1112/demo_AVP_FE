<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IBE_WaferInside
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
        Me.lblWaferID = New System.Windows.Forms.Label
        Me.Wafer = New AVP_Robot_Project.SL_CustomButton
        Me.SuspendLayout()
        '
        'lblWaferID
        '
        Me.lblWaferID.BackColor = System.Drawing.Color.Transparent
        Me.lblWaferID.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaferID.ForeColor = System.Drawing.Color.White
        Me.lblWaferID.Image = Global.AVP_Robot_Project.My.Resources.Resources.WaferMass_Blue
        Me.lblWaferID.Location = New System.Drawing.Point(23, 11)
        Me.lblWaferID.Name = "lblWaferID"
        Me.lblWaferID.Size = New System.Drawing.Size(36, 19)
        Me.lblWaferID.TabIndex = 208
        Me.lblWaferID.Text = "B22"
        Me.lblWaferID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Wafer
        '
        Me.Wafer.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Wafer_Blue
        Me.Wafer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Wafer.Clickable = False
        Me.Wafer.ColorText_ErrorStatus = System.Drawing.Color.White
        Me.Wafer.ColorText_OffStatus = System.Drawing.Color.White
        Me.Wafer.ColorText_OnStatus = System.Drawing.Color.White
        Me.Wafer.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.Wafer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Wafer.Enabled = False
        Me.Wafer.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Wafer_Red
        Me.Wafer.ErrorText = ""
        Me.Wafer.FlatAppearance.BorderSize = 0
        Me.Wafer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Wafer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Wafer.ForeColor = System.Drawing.Color.White
        Me.Wafer.Location = New System.Drawing.Point(3, 0)
        Me.Wafer.Name = "Wafer"
        Me.Wafer.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Wafer_Green
        Me.Wafer.OffText = ""
        Me.Wafer.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Wafer_Blue
        Me.Wafer.OnText = ""
        Me.Wafer.Size = New System.Drawing.Size(79, 41)
        Me.Wafer.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.[On]
        Me.Wafer.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.Wafer.TabIndex = 207
        Me.Wafer.Text = " "
        Me.Wafer.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.SL_Wafer_Yellow
        Me.Wafer.UnKnownText = ""
        Me.Wafer.UseClickedEventInForm = False
        Me.Wafer.UseVisualStyleBackColor = True
        Me.Wafer.ValueToBeSend = ""
        '
        'IBE_WaferInside
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lblWaferID)
        Me.Controls.Add(Me.Wafer)
        Me.Name = "IBE_WaferInside"
        Me.Size = New System.Drawing.Size(88, 43)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblWaferID As System.Windows.Forms.Label
    Friend WithEvents Wafer As AVP_Robot_Project.SL_CustomButton

End Class
