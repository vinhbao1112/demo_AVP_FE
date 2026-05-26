<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_PowerPanel
    Inherits AVP_Robot_Project.PVDStatusBoard

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
        Me.btnACPower = New AVP_Robot_Project.SL_CustomButton
        Me.btnRFPower = New AVP_Robot_Project.SL_CustomButton
        Me.btnGrid = New AVP_Robot_Project.SL_CustomButton
        Me.btnPBN = New AVP_Robot_Project.SL_CustomButton
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Size = New System.Drawing.Size(324, 27)
        Me.Header.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.Header.Text = "Power Panel"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'btnACPower
        '
        Me.btnACPower.BackColor = System.Drawing.Color.Transparent
        Me.btnACPower.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnACPower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnACPower.Clickable = False
        Me.btnACPower.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnACPower.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnACPower.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnACPower.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnACPower.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnACPower.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnACPower.ErrorText = "ACPower"
        Me.btnACPower.FlatAppearance.BorderSize = 0
        Me.btnACPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnACPower.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnACPower.ForeColor = System.Drawing.Color.Black
        Me.btnACPower.Location = New System.Drawing.Point(22, 38)
        Me.btnACPower.LogSource = "AC Power"
        Me.btnACPower.Name = "btnACPower"
        Me.btnACPower.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnACPower.OffText = "AC"
        Me.btnACPower.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnACPower.OnText = "AC"
        Me.btnACPower.Size = New System.Drawing.Size(121, 27)
        Me.btnACPower.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnACPower.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnACPower.TabIndex = 36
        Me.btnACPower.Text = "AC"
        Me.btnACPower.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnACPower.UnKnownText = "ACPower"
        Me.btnACPower.UseClickedEventInForm = True
        Me.btnACPower.UseVisualStyleBackColor = False
        Me.btnACPower.ValueToBeSend = "On"
        '
        'btnRFPower
        '
        Me.btnRFPower.BackColor = System.Drawing.Color.Transparent
        Me.btnRFPower.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRFPower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRFPower.Clickable = False
        Me.btnRFPower.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRFPower.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnRFPower.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnRFPower.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnRFPower.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRFPower.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnRFPower.ErrorText = "RFPower"
        Me.btnRFPower.FlatAppearance.BorderSize = 0
        Me.btnRFPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRFPower.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRFPower.ForeColor = System.Drawing.Color.Black
        Me.btnRFPower.Location = New System.Drawing.Point(181, 38)
        Me.btnRFPower.LogSource = "RF Power"
        Me.btnRFPower.Name = "btnRFPower"
        Me.btnRFPower.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRFPower.OffText = "RF"
        Me.btnRFPower.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnRFPower.OnText = "RF"
        Me.btnRFPower.Size = New System.Drawing.Size(121, 27)
        Me.btnRFPower.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnRFPower.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnRFPower.TabIndex = 36
        Me.btnRFPower.Text = "RF"
        Me.btnRFPower.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnRFPower.UnKnownText = "RFPower"
        Me.btnRFPower.UseClickedEventInForm = True
        Me.btnRFPower.UseVisualStyleBackColor = False
        Me.btnRFPower.ValueToBeSend = "On"
        '
        'btnGrid
        '
        Me.btnGrid.BackColor = System.Drawing.Color.Transparent
        Me.btnGrid.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGrid.Clickable = False
        Me.btnGrid.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnGrid.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnGrid.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnGrid.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnGrid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGrid.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnGrid.ErrorText = "Grid"
        Me.btnGrid.FlatAppearance.BorderSize = 0
        Me.btnGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrid.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrid.ForeColor = System.Drawing.Color.Black
        Me.btnGrid.Location = New System.Drawing.Point(22, 73)
        Me.btnGrid.LogSource = "Grid Power"
        Me.btnGrid.Name = "btnGrid"
        Me.btnGrid.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGrid.OffText = "Grid"
        Me.btnGrid.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnGrid.OnText = "Grid"
        Me.btnGrid.Size = New System.Drawing.Size(121, 27)
        Me.btnGrid.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnGrid.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnGrid.TabIndex = 36
        Me.btnGrid.Text = "Grid"
        Me.btnGrid.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_YellowButton
        Me.btnGrid.UnKnownText = "Grid"
        Me.btnGrid.UseClickedEventInForm = True
        Me.btnGrid.UseVisualStyleBackColor = False
        Me.btnGrid.ValueToBeSend = "On"
        '
        'btnPBN
        '
        Me.btnPBN.BackColor = System.Drawing.Color.Transparent
        Me.btnPBN.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPBN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPBN.Clickable = False
        Me.btnPBN.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnPBN.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnPBN.ColorText_OnStatus = System.Drawing.Color.Black
        Me.btnPBN.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.btnPBN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPBN.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnPBN.ErrorText = "PBN"
        Me.btnPBN.FlatAppearance.BorderSize = 0
        Me.btnPBN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPBN.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPBN.ForeColor = System.Drawing.Color.Black
        Me.btnPBN.Location = New System.Drawing.Point(181, 73)
        Me.btnPBN.LogSource = "PBN Power"
        Me.btnPBN.Name = "btnPBN"
        Me.btnPBN.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnPBN.OffText = "PBN"
        Me.btnPBN.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnPBN.OnText = "PBN"
        Me.btnPBN.Size = New System.Drawing.Size(121, 29)
        Me.btnPBN.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnPBN.StyleOfButton = AVP_Robot_Project.SL_CustomButton.ButtonStyle.Horizontal
        Me.btnPBN.TabIndex = 36
        Me.btnPBN.Text = "PBN"
        Me.btnPBN.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnPBN.UnKnownText = "PBN"
        Me.btnPBN.UseClickedEventInForm = True
        Me.btnPBN.UseVisualStyleBackColor = False
        Me.btnPBN.ValueToBeSend = "On"
        '
        'SL_PowerPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btnRFPower)
        Me.Controls.Add(Me.btnPBN)
        Me.Controls.Add(Me.btnGrid)
        Me.Controls.Add(Me.btnACPower)
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.On
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "SL_PowerPanel"
        Me.Size = New System.Drawing.Size(324, 110)
        Me.Text = "Power Panel"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.btnACPower, 0)
        Me.Controls.SetChildIndex(Me.btnGrid, 0)
        Me.Controls.SetChildIndex(Me.btnPBN, 0)
        Me.Controls.SetChildIndex(Me.btnRFPower, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnACPower As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnRFPower As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnGrid As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnPBN As AVP_Robot_Project.SL_CustomButton

End Class
