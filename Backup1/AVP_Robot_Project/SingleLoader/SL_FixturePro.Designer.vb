<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SL_FixturePro
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnFlowcoolGas = New AVP_Robot_Project.SL_CustomButton
        Me.btnMotionInitialized = New AVP_Robot_Project.SL_CustomButton
        Me.btnIonBeam = New AVP_Robot_Project.SL_CustomButton
        Me.btnNeutralizer = New AVP_Robot_Project.SL_CustomButton
        Me.btnProcessGas = New AVP_Robot_Project.SL_CustomButton
        Me.txtRotating = New AVP_Robot_Project.SL_Textbox
        Me.txtTiltAngle = New AVP_Robot_Project.SL_Textbox
        Me.txtClampped = New AVP_Robot_Project.SL_Textbox
        Me.btnRotating = New AVP_Robot_Project.SL_CustomButton
        Me.txtElapsedTime = New AVP_Robot_Project.SL_Textbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRemainingTime = New AVP_Robot_Project.SL_Textbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtStepTime = New AVP_Robot_Project.SL_Textbox
        Me.lblTiltAngle = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.Size = New System.Drawing.Size(480, 27)
        Me.Header.Text = "Fixture"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(160, 230)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Rotating"
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Tilt Angle"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(243, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Clamp"
        '
        'btnFlowcoolGas
        '
        Me.btnFlowcoolGas.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnFlowcoolGas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFlowcoolGas.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnFlowcoolGas.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnFlowcoolGas.FlatAppearance.BorderSize = 0
        Me.btnFlowcoolGas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFlowcoolGas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFlowcoolGas.ForeColor = System.Drawing.Color.White
        Me.btnFlowcoolGas.Location = New System.Drawing.Point(77, 94)
        Me.btnFlowcoolGas.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFlowcoolGas.MessageBoxText = Nothing
        Me.btnFlowcoolGas.Name = "btnFlowcoolGas"
        Me.btnFlowcoolGas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnFlowcoolGas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnFlowcoolGas.Size = New System.Drawing.Size(144, 26)
        Me.btnFlowcoolGas.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnFlowcoolGas.TabIndex = 33
        Me.btnFlowcoolGas.Text = "Flowcool Gas"
        Me.btnFlowcoolGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnFlowcoolGas.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnFlowcoolGas.UseVisualStyleBackColor = True
        Me.btnFlowcoolGas.ValueToBeSend = ""
        '
        'btnMotionInitialized
        '
        Me.btnMotionInitialized.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnMotionInitialized.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMotionInitialized.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnMotionInitialized.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnMotionInitialized.FlatAppearance.BorderSize = 0
        Me.btnMotionInitialized.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMotionInitialized.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMotionInitialized.ForeColor = System.Drawing.Color.White
        Me.btnMotionInitialized.Location = New System.Drawing.Point(77, 64)
        Me.btnMotionInitialized.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMotionInitialized.MessageBoxText = Nothing
        Me.btnMotionInitialized.Name = "btnMotionInitialized"
        Me.btnMotionInitialized.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnMotionInitialized.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnMotionInitialized.Size = New System.Drawing.Size(144, 26)
        Me.btnMotionInitialized.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnMotionInitialized.TabIndex = 32
        Me.btnMotionInitialized.Text = "Motion Initialized"
        Me.btnMotionInitialized.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnMotionInitialized.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnMotionInitialized.UseVisualStyleBackColor = True
        Me.btnMotionInitialized.ValueToBeSend = ""
        '
        'btnIonBeam
        '
        Me.btnIonBeam.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnIonBeam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIonBeam.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnIonBeam.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnIonBeam.FlatAppearance.BorderSize = 0
        Me.btnIonBeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIonBeam.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIonBeam.ForeColor = System.Drawing.Color.White
        Me.btnIonBeam.Location = New System.Drawing.Point(261, 94)
        Me.btnIonBeam.Margin = New System.Windows.Forms.Padding(2)
        Me.btnIonBeam.MessageBoxText = Nothing
        Me.btnIonBeam.Name = "btnIonBeam"
        Me.btnIonBeam.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnIonBeam.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnIonBeam.Size = New System.Drawing.Size(144, 26)
        Me.btnIonBeam.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnIonBeam.TabIndex = 30
        Me.btnIonBeam.Text = "Ion Beam"
        Me.btnIonBeam.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnIonBeam.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnIonBeam.UseVisualStyleBackColor = True
        Me.btnIonBeam.ValueToBeSend = ""
        '
        'btnNeutralizer
        '
        Me.btnNeutralizer.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnNeutralizer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNeutralizer.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnNeutralizer.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnNeutralizer.FlatAppearance.BorderSize = 0
        Me.btnNeutralizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNeutralizer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNeutralizer.ForeColor = System.Drawing.Color.White
        Me.btnNeutralizer.Location = New System.Drawing.Point(261, 124)
        Me.btnNeutralizer.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNeutralizer.MessageBoxText = Nothing
        Me.btnNeutralizer.Name = "btnNeutralizer"
        Me.btnNeutralizer.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnNeutralizer.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnNeutralizer.Size = New System.Drawing.Size(144, 26)
        Me.btnNeutralizer.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnNeutralizer.TabIndex = 29
        Me.btnNeutralizer.Text = "PBN"
        Me.btnNeutralizer.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnNeutralizer.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnNeutralizer.UseVisualStyleBackColor = True
        Me.btnNeutralizer.ValueToBeSend = ""
        '
        'btnProcessGas
        '
        Me.btnProcessGas.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnProcessGas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProcessGas.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnProcessGas.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnProcessGas.FlatAppearance.BorderSize = 0
        Me.btnProcessGas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcessGas.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcessGas.ForeColor = System.Drawing.Color.White
        Me.btnProcessGas.Location = New System.Drawing.Point(77, 124)
        Me.btnProcessGas.Margin = New System.Windows.Forms.Padding(2)
        Me.btnProcessGas.MessageBoxText = Nothing
        Me.btnProcessGas.Name = "btnProcessGas"
        Me.btnProcessGas.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnProcessGas.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnProcessGas.Size = New System.Drawing.Size(144, 26)
        Me.btnProcessGas.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnProcessGas.TabIndex = 31
        Me.btnProcessGas.Text = "Process Gas"
        Me.btnProcessGas.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnProcessGas.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnProcessGas.UseVisualStyleBackColor = True
        Me.btnProcessGas.ValueToBeSend = ""
        '
        'txtRotating
        '
        Me.txtRotating.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRotating.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRotating.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotating.IsReadBack = True
        Me.txtRotating.Location = New System.Drawing.Point(223, 234)
        Me.txtRotating.Multiline = True
        Me.txtRotating.Name = "txtRotating"
        Me.txtRotating.ReadOnly = True
        Me.txtRotating.Size = New System.Drawing.Size(100, 22)
        Me.txtRotating.TabIndex = 34
        Me.txtRotating.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRotating.UseScientificFormat = True
        Me.txtRotating.Visible = False
        '
        'txtTiltAngle
        '
        Me.txtTiltAngle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTiltAngle.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTiltAngle.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTiltAngle.IsReadBack = True
        Me.txtTiltAngle.Location = New System.Drawing.Point(121, 39)
        Me.txtTiltAngle.Multiline = True
        Me.txtTiltAngle.Name = "txtTiltAngle"
        Me.txtTiltAngle.ReadOnly = True
        Me.txtTiltAngle.Size = New System.Drawing.Size(100, 22)
        Me.txtTiltAngle.TabIndex = 34
        Me.txtTiltAngle.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtTiltAngle.UseScientificFormat = True
        '
        'txtClampped
        '
        Me.txtClampped.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtClampped.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtClampped.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtClampped.IsReadBack = True
        Me.txtClampped.Location = New System.Drawing.Point(335, 39)
        Me.txtClampped.Multiline = True
        Me.txtClampped.Name = "txtClampped"
        Me.txtClampped.ReadOnly = True
        Me.txtClampped.Size = New System.Drawing.Size(100, 22)
        Me.txtClampped.TabIndex = 34
        Me.txtClampped.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtClampped.UseScientificFormat = True
        '
        'btnRotating
        '
        Me.btnRotating.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnRotating.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRotating.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnRotating.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.Red_Button
        Me.btnRotating.FlatAppearance.BorderSize = 0
        Me.btnRotating.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRotating.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRotating.ForeColor = System.Drawing.Color.White
        Me.btnRotating.Location = New System.Drawing.Point(261, 64)
        Me.btnRotating.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRotating.MessageBoxText = Nothing
        Me.btnRotating.Name = "btnRotating"
        Me.btnRotating.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Gray_Button
        Me.btnRotating.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Green_Button
        Me.btnRotating.Size = New System.Drawing.Size(144, 26)
        Me.btnRotating.Status = AVP_Robot_Project.SL_CustomButton.DisplayStatus.Off
        Me.btnRotating.TabIndex = 32
        Me.btnRotating.Text = "Rotating"
        Me.btnRotating.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.btnRotating.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.Yellow_Button
        Me.btnRotating.UseVisualStyleBackColor = True
        Me.btnRotating.ValueToBeSend = ""
        '
        'txtElapsedTime
        '
        Me.txtElapsedTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtElapsedTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtElapsedTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtElapsedTime.IsReadBack = True
        Me.txtElapsedTime.Location = New System.Drawing.Point(183, 158)
        Me.txtElapsedTime.Name = "txtElapsedTime"
        Me.txtElapsedTime.ReadOnly = True
        Me.txtElapsedTime.Size = New System.Drawing.Size(101, 24)
        Me.txtElapsedTime.TabIndex = 83
        Me.txtElapsedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtElapsedTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtElapsedTime.UseScientificFormat = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(115, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 16)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "Elapsed"
        '
        'txtRemainingTime
        '
        Me.txtRemainingTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRemainingTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRemainingTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRemainingTime.IsReadBack = True
        Me.txtRemainingTime.Location = New System.Drawing.Point(370, 158)
        Me.txtRemainingTime.Name = "txtRemainingTime"
        Me.txtRemainingTime.ReadOnly = True
        Me.txtRemainingTime.Size = New System.Drawing.Size(101, 24)
        Me.txtRemainingTime.TabIndex = 81
        Me.txtRemainingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRemainingTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtRemainingTime.UseScientificFormat = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(286, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 16)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Remaining"
        '
        'txtStepTime
        '
        Me.txtStepTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStepTime.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtStepTime.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStepTime.IsReadBack = True
        Me.txtStepTime.Location = New System.Drawing.Point(49, 158)
        Me.txtStepTime.Name = "txtStepTime"
        Me.txtStepTime.ReadOnly = True
        Me.txtStepTime.Size = New System.Drawing.Size(64, 24)
        Me.txtStepTime.TabIndex = 80
        Me.txtStepTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtStepTime.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtStepTime.UseScientificFormat = True
        '
        'lblTiltAngle
        '
        Me.lblTiltAngle.AutoSize = True
        Me.lblTiltAngle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiltAngle.Location = New System.Drawing.Point(7, 162)
        Me.lblTiltAngle.Name = "lblTiltAngle"
        Me.lblTiltAngle.Size = New System.Drawing.Size(40, 16)
        Me.lblTiltAngle.TabIndex = 79
        Me.lblTiltAngle.Text = "Step"
        '
        'SL_FixturePro
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.txtElapsedTime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRemainingTime)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtStepTime)
        Me.Controls.Add(Me.lblTiltAngle)
        Me.Controls.Add(Me.txtClampped)
        Me.Controls.Add(Me.txtTiltAngle)
        Me.Controls.Add(Me.txtRotating)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFlowcoolGas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnIonBeam)
        Me.Controls.Add(Me.btnRotating)
        Me.Controls.Add(Me.btnMotionInitialized)
        Me.Controls.Add(Me.btnProcessGas)
        Me.Controls.Add(Me.btnNeutralizer)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderText = "Fixture"
        Me.Name = "SL_FixturePro"
        Me.Size = New System.Drawing.Size(480, 206)
        Me.Text = "Fixture"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.btnNeutralizer, 0)
        Me.Controls.SetChildIndex(Me.btnProcessGas, 0)
        Me.Controls.SetChildIndex(Me.btnMotionInitialized, 0)
        Me.Controls.SetChildIndex(Me.btnRotating, 0)
        Me.Controls.SetChildIndex(Me.btnIonBeam, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.btnFlowcoolGas, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtRotating, 0)
        Me.Controls.SetChildIndex(Me.txtTiltAngle, 0)
        Me.Controls.SetChildIndex(Me.txtClampped, 0)
        Me.Controls.SetChildIndex(Me.lblTiltAngle, 0)
        Me.Controls.SetChildIndex(Me.txtStepTime, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtRemainingTime, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtElapsedTime, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFlowcoolGas As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnMotionInitialized As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnIonBeam As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnNeutralizer As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnProcessGas As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtRotating As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtTiltAngle As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtClampped As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnRotating As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtElapsedTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRemainingTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtStepTime As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblTiltAngle As System.Windows.Forms.Label

End Class
