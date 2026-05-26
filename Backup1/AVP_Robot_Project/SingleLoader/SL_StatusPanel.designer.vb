<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_StatusPanel
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
        Me.components = New System.ComponentModel.Container
        Me.btnMotionInitialized = New AVP_Robot_Project.SL_CustomButton
        Me.btnFlowcoolGas = New AVP_Robot_Project.SL_CustomButton
        Me.btnProcessGas = New AVP_Robot_Project.SL_CustomButton
        Me.btnIonBeam = New AVP_Robot_Project.SL_CustomButton
        Me.btnNeutralizer = New AVP_Robot_Project.SL_CustomButton
        Me.txtStepTime = New AVP_Robot_Project.SL_Textbox
        Me.lblTiltAngle = New System.Windows.Forms.Label
        Me.txtRemainingTime = New AVP_Robot_Project.SL_Textbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtElapsedTime = New AVP_Robot_Project.SL_Textbox
        Me.txtStatus = New AVP_Robot_Project.SL_Textbox
        Me.txtEPDRecipe = New AVP_Robot_Project.SL_Textbox
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblEPDRecipe = New System.Windows.Forms.Label
        Me.screenToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Font = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Size = New System.Drawing.Size(324, 27)
        Me.Header.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
        Me.Header.Text = "Status"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'btnMotionInitialized
        '
        Me.btnMotionInitialized.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnMotionInitialized.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMotionInitialized.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnMotionInitialized.DenyKeyEnter = True
        Me.btnMotionInitialized.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnMotionInitialized.FlatAppearance.BorderSize = 0
        Me.btnMotionInitialized.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMotionInitialized.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMotionInitialized.ForeColor = System.Drawing.Color.White
        Me.btnMotionInitialized.Location = New System.Drawing.Point(82, 36)
        Me.btnMotionInitialized.MessageBoxText = Nothing
        Me.btnMotionInitialized.Name = "btnMotionInitialized"
        Me.btnMotionInitialized.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnMotionInitialized.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnMotionInitialized.Size = New System.Drawing.Size(160, 26)
        Me.btnMotionInitialized.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnMotionInitialized.TabIndex = 29
        Me.btnMotionInitialized.Text = "Motion Initialized"
        Me.btnMotionInitialized.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnMotionInitialized.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnMotionInitialized.UseVisualStyleBackColor = True
        Me.btnMotionInitialized.ValueToBeSend = "On"
        '
        'btnFlowcoolGas
        '
        Me.btnFlowcoolGas.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnFlowcoolGas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFlowcoolGas.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnFlowcoolGas.DenyKeyEnter = True
        Me.btnFlowcoolGas.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnFlowcoolGas.FlatAppearance.BorderSize = 0
        Me.btnFlowcoolGas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFlowcoolGas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFlowcoolGas.ForeColor = System.Drawing.Color.White
        Me.btnFlowcoolGas.Location = New System.Drawing.Point(20, 65)
        Me.btnFlowcoolGas.MessageBoxText = Nothing
        Me.btnFlowcoolGas.Name = "btnFlowcoolGas"
        Me.btnFlowcoolGas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnFlowcoolGas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnFlowcoolGas.Size = New System.Drawing.Size(124, 26)
        Me.btnFlowcoolGas.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnFlowcoolGas.TabIndex = 29
        Me.btnFlowcoolGas.Text = "Flowcool Gas"
        Me.btnFlowcoolGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnFlowcoolGas.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnFlowcoolGas.UseVisualStyleBackColor = True
        Me.btnFlowcoolGas.ValueToBeSend = "On"
        '
        'btnProcessGas
        '
        Me.btnProcessGas.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnProcessGas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProcessGas.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnProcessGas.DenyKeyEnter = True
        Me.btnProcessGas.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnProcessGas.FlatAppearance.BorderSize = 0
        Me.btnProcessGas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcessGas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcessGas.ForeColor = System.Drawing.Color.White
        Me.btnProcessGas.Location = New System.Drawing.Point(20, 94)
        Me.btnProcessGas.MessageBoxText = Nothing
        Me.btnProcessGas.Name = "btnProcessGas"
        Me.btnProcessGas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnProcessGas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnProcessGas.Size = New System.Drawing.Size(124, 26)
        Me.btnProcessGas.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnProcessGas.TabIndex = 29
        Me.btnProcessGas.Text = "Process Gas"
        Me.btnProcessGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnProcessGas.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnProcessGas.UseVisualStyleBackColor = True
        Me.btnProcessGas.ValueToBeSend = "On"
        '
        'btnIonBeam
        '
        Me.btnIonBeam.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnIonBeam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIonBeam.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnIonBeam.DenyKeyEnter = True
        Me.btnIonBeam.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnIonBeam.FlatAppearance.BorderSize = 0
        Me.btnIonBeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIonBeam.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIonBeam.ForeColor = System.Drawing.Color.White
        Me.btnIonBeam.Location = New System.Drawing.Point(180, 65)
        Me.btnIonBeam.MessageBoxText = Nothing
        Me.btnIonBeam.Name = "btnIonBeam"
        Me.btnIonBeam.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnIonBeam.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnIonBeam.Size = New System.Drawing.Size(124, 26)
        Me.btnIonBeam.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnIonBeam.TabIndex = 29
        Me.btnIonBeam.Text = "Ion Beam"
        Me.btnIonBeam.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnIonBeam.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnIonBeam.UseVisualStyleBackColor = True
        Me.btnIonBeam.ValueToBeSend = "On"
        '
        'btnNeutralizer
        '
        Me.btnNeutralizer.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnNeutralizer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNeutralizer.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnNeutralizer.DenyKeyEnter = True
        Me.btnNeutralizer.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnNeutralizer.FlatAppearance.BorderSize = 0
        Me.btnNeutralizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNeutralizer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNeutralizer.ForeColor = System.Drawing.Color.White
        Me.btnNeutralizer.Location = New System.Drawing.Point(180, 95)
        Me.btnNeutralizer.MessageBoxText = Nothing
        Me.btnNeutralizer.Name = "btnNeutralizer"
        Me.btnNeutralizer.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnNeutralizer.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnNeutralizer.Size = New System.Drawing.Size(124, 26)
        Me.btnNeutralizer.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnNeutralizer.TabIndex = 29
        Me.btnNeutralizer.Text = "PBN"
        Me.btnNeutralizer.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnNeutralizer.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnNeutralizer.UseVisualStyleBackColor = True
        Me.btnNeutralizer.ValueToBeSend = "On"
        '
        'txtStepTime
        '
        Me.txtStepTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStepTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStepTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStepTime.IsReadBack = True
        Me.txtStepTime.Location = New System.Drawing.Point(120, 153)
        Me.txtStepTime.Name = "txtStepTime"
        Me.txtStepTime.ReadOnly = True
        Me.txtStepTime.Size = New System.Drawing.Size(184, 24)
        Me.txtStepTime.TabIndex = 75
        Me.txtStepTime.TabStop = False
        Me.txtStepTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtStepTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtStepTime.UseScientificFormat = True
        '
        'lblTiltAngle
        '
        Me.lblTiltAngle.AutoSize = True
        Me.lblTiltAngle.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiltAngle.Location = New System.Drawing.Point(20, 157)
        Me.lblTiltAngle.Name = "lblTiltAngle"
        Me.lblTiltAngle.Size = New System.Drawing.Size(37, 17)
        Me.lblTiltAngle.TabIndex = 74
        Me.lblTiltAngle.Text = "Step"
        '
        'txtRemainingTime
        '
        Me.txtRemainingTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRemainingTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRemainingTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRemainingTime.IsReadBack = True
        Me.txtRemainingTime.Location = New System.Drawing.Point(120, 205)
        Me.txtRemainingTime.Name = "txtRemainingTime"
        Me.txtRemainingTime.ReadOnly = True
        Me.txtRemainingTime.Size = New System.Drawing.Size(184, 24)
        Me.txtRemainingTime.TabIndex = 77
        Me.txtRemainingTime.TabStop = False
        Me.txtRemainingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRemainingTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRemainingTime.UseScientificFormat = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 17)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Elapsed"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 17)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Remaining"
        '
        'txtElapsedTime
        '
        Me.txtElapsedTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtElapsedTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtElapsedTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtElapsedTime.IsReadBack = True
        Me.txtElapsedTime.Location = New System.Drawing.Point(120, 179)
        Me.txtElapsedTime.Name = "txtElapsedTime"
        Me.txtElapsedTime.ReadOnly = True
        Me.txtElapsedTime.Size = New System.Drawing.Size(184, 24)
        Me.txtElapsedTime.TabIndex = 75
        Me.txtElapsedTime.TabStop = False
        Me.txtElapsedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtElapsedTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtElapsedTime.UseScientificFormat = True
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStatus.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStatus.IsReadBack = True
        Me.txtStatus.Location = New System.Drawing.Point(120, 127)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(184, 24)
        Me.txtStatus.TabIndex = 80
        Me.txtStatus.TabStop = False
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtStatus.UseScientificFormat = True
        '
        'txtEPDRecipe
        '
        Me.txtEPDRecipe.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtEPDRecipe.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtEPDRecipe.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtEPDRecipe.IsReadBack = True
        Me.txtEPDRecipe.Location = New System.Drawing.Point(120, 231)
        Me.txtEPDRecipe.Name = "txtEPDRecipe"
        Me.txtEPDRecipe.ReadOnly = True
        Me.txtEPDRecipe.Size = New System.Drawing.Size(184, 24)
        Me.txtEPDRecipe.TabIndex = 81
        Me.txtEPDRecipe.TabStop = False
        Me.txtEPDRecipe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEPDRecipe.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtEPDRecipe.UseScientificFormat = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(19, 130)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 19)
        Me.Label18.TabIndex = 78
        Me.Label18.Text = "Status"
        '
        'lblEPDRecipe
        '
        Me.lblEPDRecipe.AutoSize = True
        Me.lblEPDRecipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEPDRecipe.Location = New System.Drawing.Point(19, 234)
        Me.lblEPDRecipe.Name = "lblEPDRecipe"
        Me.lblEPDRecipe.Size = New System.Drawing.Size(91, 19)
        Me.lblEPDRecipe.TabIndex = 79
        Me.lblEPDRecipe.Text = "EPD Recipe"
        '
        'SL_StatusPanel
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Panel
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtEPDRecipe)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblEPDRecipe)
        Me.Controls.Add(Me.txtRemainingTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtElapsedTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStepTime)
        Me.Controls.Add(Me.lblTiltAngle)
        Me.Controls.Add(Me.btnNeutralizer)
        Me.Controls.Add(Me.btnProcessGas)
        Me.Controls.Add(Me.btnIonBeam)
        Me.Controls.Add(Me.btnFlowcoolGas)
        Me.Controls.Add(Me.btnMotionInitialized)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderFont = New System.Drawing.Font("Arial", 17.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.On
        Me.HeaderText = "Status"
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "SL_StatusPanel"
        Me.Size = New System.Drawing.Size(324, 265)
        Me.Text = "Status"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.btnMotionInitialized, 0)
        Me.Controls.SetChildIndex(Me.btnFlowcoolGas, 0)
        Me.Controls.SetChildIndex(Me.btnIonBeam, 0)
        Me.Controls.SetChildIndex(Me.btnProcessGas, 0)
        Me.Controls.SetChildIndex(Me.btnNeutralizer, 0)
        Me.Controls.SetChildIndex(Me.lblTiltAngle, 0)
        Me.Controls.SetChildIndex(Me.txtStepTime, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtElapsedTime, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtRemainingTime, 0)
        Me.Controls.SetChildIndex(Me.lblEPDRecipe, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.txtEPDRecipe, 0)
        Me.Controls.SetChildIndex(Me.txtStatus, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMotionInitialized As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnFlowcoolGas As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnProcessGas As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnIonBeam As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnNeutralizer As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtStepTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblTiltAngle As System.Windows.Forms.Label
    Friend WithEvents txtRemainingTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtElapsedTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtStatus As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtEPDRecipe As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblEPDRecipe As System.Windows.Forms.Label
    Friend WithEvents screenToolTip As System.Windows.Forms.ToolTip

End Class
