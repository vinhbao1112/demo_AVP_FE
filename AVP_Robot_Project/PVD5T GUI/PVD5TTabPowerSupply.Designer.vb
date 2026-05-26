<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PVD5TTabPowerSupply
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tabDC = New System.Windows.Forms.TabPage()
        Me.DCTargetPowerSupply = New AVP_Robot_Project.PVD5TBiasPowerSupply()
        Me.tabRF = New System.Windows.Forms.TabPage()
        Me.RFTargetPowerSupply = New AVP_Robot_Project.PVD5TBiasPowerSupply()
        Me.TabTargetPowerSupply = New System.Windows.Forms.CustomTabControl()
        Me.tabDC.SuspendLayout()
        Me.tabRF.SuspendLayout()
        Me.TabTargetPowerSupply.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabDC
        '
        Me.tabDC.BackColor = System.Drawing.Color.Transparent
        Me.tabDC.Controls.Add(Me.DCTargetPowerSupply)
        Me.tabDC.Location = New System.Drawing.Point(0, 31)
        Me.tabDC.Name = "tabDC"
        Me.tabDC.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDC.Size = New System.Drawing.Size(325, 214)
        Me.tabDC.TabIndex = 3
        Me.tabDC.Text = "DC"
        '
        'DCTargetPowerSupply
        '
        Me.DCTargetPowerSupply.BackColor = System.Drawing.Color.Transparent
        Me.DCTargetPowerSupply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.DCTargetPowerSupply.ChamberName = ""
        Me.DCTargetPowerSupply.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.DCTargetPowerSupply.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.DCTargetPowerSupply.HeaderText = "DCTargetPowerSupply"
        Me.DCTargetPowerSupply.HeaderTextColor = System.Drawing.Color.White
        Me.DCTargetPowerSupply.HeaderVisible = False
        Me.DCTargetPowerSupply.IsBiasPowerSupply = False
        Me.DCTargetPowerSupply.IsDCTargetPowerSupply = True
        Me.DCTargetPowerSupply.IsOnline = False
        Me.DCTargetPowerSupply.ISShowPulse = True
        Me.DCTargetPowerSupply.Location = New System.Drawing.Point(0, 0)
        Me.DCTargetPowerSupply.Name = "DCTargetPowerSupply"
        Me.DCTargetPowerSupply.Size = New System.Drawing.Size(325, 213)
        Me.DCTargetPowerSupply.TabIndex = 0
        Me.DCTargetPowerSupply.Target1Install = True
        Me.DCTargetPowerSupply.Target2Install = True
        Me.DCTargetPowerSupply.Target3Install = True
        Me.DCTargetPowerSupply.Target4Install = True
        Me.DCTargetPowerSupply.Target5Install = True
        Me.DCTargetPowerSupply.Text = "DCTargetPowerSupply"
        Me.DCTargetPowerSupply.UseBorderStyle = True
        '
        'tabRF
        '
        Me.tabRF.BackColor = System.Drawing.Color.Transparent
        Me.tabRF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabRF.Controls.Add(Me.RFTargetPowerSupply)
        Me.tabRF.Location = New System.Drawing.Point(0, 31)
        Me.tabRF.Name = "tabRF"
        Me.tabRF.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRF.Size = New System.Drawing.Size(325, 214)
        Me.tabRF.TabIndex = 1
        Me.tabRF.Text = "RF"
        '
        'RFTargetPowerSupply
        '
        Me.RFTargetPowerSupply.BackColor = System.Drawing.Color.Transparent
        Me.RFTargetPowerSupply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RFTargetPowerSupply.ChamberName = ""
        Me.RFTargetPowerSupply.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.RFTargetPowerSupply.HeaderStatus = AVP_Robot_Project.DisplayStatus.Off
        Me.RFTargetPowerSupply.HeaderText = "RFTargetPowerSupply"
        Me.RFTargetPowerSupply.HeaderTextColor = System.Drawing.Color.White
        Me.RFTargetPowerSupply.HeaderVisible = False
        Me.RFTargetPowerSupply.IsBiasPowerSupply = False
        Me.RFTargetPowerSupply.IsDCTargetPowerSupply = False
        Me.RFTargetPowerSupply.IsOnline = False
        Me.RFTargetPowerSupply.ISShowPulse = True
        Me.RFTargetPowerSupply.Location = New System.Drawing.Point(0, 0)
        Me.RFTargetPowerSupply.Name = "RFTargetPowerSupply"
        Me.RFTargetPowerSupply.Size = New System.Drawing.Size(325, 213)
        Me.RFTargetPowerSupply.TabIndex = 0
        Me.RFTargetPowerSupply.Target1Install = True
        Me.RFTargetPowerSupply.Target2Install = True
        Me.RFTargetPowerSupply.Target3Install = True
        Me.RFTargetPowerSupply.Target4Install = True
        Me.RFTargetPowerSupply.Target5Install = True
        Me.RFTargetPowerSupply.Text = "RFTargetPowerSupply"
        Me.RFTargetPowerSupply.UseBorderStyle = True
        '
        'TabTargetPowerSupply
        '
        Me.TabTargetPowerSupply.CommunicationDisconnectedColor = System.Drawing.Color.Gray
        Me.TabTargetPowerSupply.CommunicationErrorColor = System.Drawing.Color.Red
        Me.TabTargetPowerSupply.Controls.Add(Me.tabRF)
        Me.TabTargetPowerSupply.Controls.Add(Me.tabDC)
        Me.TabTargetPowerSupply.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TabTargetPowerSupply.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.TabTargetPowerSupply.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.TabTargetPowerSupply.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabTargetPowerSupply.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.TabTargetPowerSupply.DisplayStyleProvider.FocusTrack = False
        Me.TabTargetPowerSupply.DisplayStyleProvider.HotTrack = True
        Me.TabTargetPowerSupply.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TabTargetPowerSupply.DisplayStyleProvider.Opacity = 1.0!
        Me.TabTargetPowerSupply.DisplayStyleProvider.Overlap = 0
        Me.TabTargetPowerSupply.DisplayStyleProvider.Padding = New System.Drawing.Point(20, 3)
        Me.TabTargetPowerSupply.DisplayStyleProvider.Radius = 10
        Me.TabTargetPowerSupply.DisplayStyleProvider.ShowTabCloser = False
        Me.TabTargetPowerSupply.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabTargetPowerSupply.HotTrack = True
        Me.TabTargetPowerSupply.Location = New System.Drawing.Point(3, 3)
        Me.TabTargetPowerSupply.Name = "TabTargetPowerSupply"
        Me.TabTargetPowerSupply.SelectedIndex = 0
        Me.TabTargetPowerSupply.ShowCommunicationIcon = True
        Me.TabTargetPowerSupply.Size = New System.Drawing.Size(325, 245)
        Me.TabTargetPowerSupply.TabIndex = 220
        '
        'PVD5TTabPowerSupply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.TabTargetPowerSupply)
        Me.Name = "PVD5TTabPowerSupply"
        Me.Size = New System.Drawing.Size(327, 247)
        Me.tabDC.ResumeLayout(False)
        Me.tabRF.ResumeLayout(False)
        Me.TabTargetPowerSupply.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabDC As TabPage
    Friend WithEvents DCTargetPowerSupply As PVD5TBiasPowerSupply
    Friend WithEvents tabRF As TabPage
    Friend WithEvents RFTargetPowerSupply As PVD5TBiasPowerSupply
    Friend WithEvents TabTargetPowerSupply As CustomTabControl
End Class
