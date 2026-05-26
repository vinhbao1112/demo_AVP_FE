<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CORONA_TableControl
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
        Me.txtRotateRight = New AVP_Robot_Project.SL_Textbox
        Me.btnHOME = New AVP_Robot_Project.SL_CustomButton
        Me.btnRotate = New AVP_Robot_Project.SL_CustomButton
        Me.cbxGoTo = New System.Windows.Forms.ComboBox
        Me.txtGotoSlot = New AVP_Robot_Project.SL_Textbox
        Me.txtRotate = New AVP_Robot_Project.SL_Textbox
        Me.btnLiftUp = New AVP_Robot_Project.SL_CustomButton
        Me.btnLiftDown = New AVP_Robot_Project.SL_CustomButton
        Me.txtTablePos = New AVP_Robot_Project.SL_Textbox
        Me.txtTablePosRight = New AVP_Robot_Project.SL_Textbox
        Me.btnHomeTable = New AVP_Robot_Project.SL_CustomButton
        Me.lblAllAxisHome = New System.Windows.Forms.Label
        Me.txtNumberOfUnitPerRevolution = New AVP_Robot_Project.SL_Textbox
        Me.txtSubstrateTableRotatePosition = New AVP_Robot_Project.SL_Textbox
        Me.lblTSD = New System.Windows.Forms.Label
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
        Me.Header.Size = New System.Drawing.Size(623, 27)
        Me.Header.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.On
        Me.Header.Text = "Table Control"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'txtRotateRight
        '
        Me.txtRotateRight.AccessibleDescription = "TextboxClick"
        Me.txtRotateRight.AccessibleName = "Rotate Speed"
        Me.txtRotateRight.BackColor = System.Drawing.Color.White
        Me.txtRotateRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtRotateRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotateRight.IsNumericTextbox = True
        Me.txtRotateRight.IsReadBack = False
        Me.txtRotateRight.Location = New System.Drawing.Point(359, 63)
        Me.txtRotateRight.Name = "txtRotateRight"
        Me.txtRotateRight.ReadOnly = True
        Me.txtRotateRight.Size = New System.Drawing.Size(125, 24)
        Me.txtRotateRight.TabIndex = 8
        Me.txtRotateRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        '
        'btnHOME
        '
        Me.btnHOME.AccessibleDescription = "Home"
        Me.btnHOME.AccessibleName = "Home"
        Me.btnHOME.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHOME.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHOME.Clickable = True
        Me.btnHOME.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnHOME.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnHOME.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHOME.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnHOME.FlatAppearance.BorderSize = 0
        Me.btnHOME.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHOME.Font = New System.Drawing.Font("Times New Roman", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnHOME.ForeColor = System.Drawing.Color.Black
        Me.btnHOME.IsSingleFunction = True
        Me.btnHOME.Location = New System.Drawing.Point(8, 35)
        Me.btnHOME.MessageBoxText = Nothing
        Me.btnHOME.Name = "btnHOME"
        Me.btnHOME.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHOME.OffText = "HOME ALL"
        Me.btnHOME.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnHOME.OnText = "HOME ALL"
        Me.btnHOME.Size = New System.Drawing.Size(75, 52)
        Me.btnHOME.TabIndex = 17
        Me.btnHOME.Text = "HOME ALL"
        Me.btnHOME.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnHOME.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnHOME.UnKnownText = "HOME ALL"
        Me.btnHOME.UseChangeValueToSend_BaseOnStatus = True
        Me.btnHOME.UseVisualStyleBackColor = True
        Me.btnHOME.ValueToBeSend = "On"
        Me.btnHOME.ValueToSend_WhenStatusOn = "On"
        Me.btnHOME.ValueToSend_WhenStatusUnknown = "Off"
        '
        'btnRotate
        '
        Me.btnRotate.AccessibleDescription = "Rotate"
        Me.btnRotate.AccessibleName = "Rotate"
        Me.btnRotate.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRotate.Clickable = True
        Me.btnRotate.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnRotate.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnRotate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRotate.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnRotate.FlatAppearance.BorderSize = 0
        Me.btnRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRotate.Font = New System.Drawing.Font("Times New Roman", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRotate.ForeColor = System.Drawing.Color.Black
        Me.btnRotate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRotate.Location = New System.Drawing.Point(359, 35)
        Me.btnRotate.MessageBoxText = Nothing
        Me.btnRotate.Name = "btnRotate"
        Me.btnRotate.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRotate.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnRotate.Size = New System.Drawing.Size(125, 25)
        Me.btnRotate.TabIndex = 17
        Me.btnRotate.Text = "Rotate Cont."
        Me.btnRotate.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnRotate.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnRotate.UseChangeValueToSend_BaseOnStatus = True
        Me.btnRotate.UseVisualStyleBackColor = True
        Me.btnRotate.ValueToBeSend = "On"
        '
        'cbxGoTo
        '
        Me.cbxGoTo.AccessibleDescription = "Go To"
        Me.cbxGoTo.AccessibleName = "GoToSlot"
        Me.cbxGoTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGoTo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cbxGoTo.FormattingEnabled = True
        Me.cbxGoTo.IntegralHeight = False
        Me.cbxGoTo.Location = New System.Drawing.Point(228, 36)
        Me.cbxGoTo.Name = "cbxGoTo"
        Me.cbxGoTo.Size = New System.Drawing.Size(125, 23)
        Me.cbxGoTo.TabIndex = 19
        '
        'txtGotoSlot
        '
        Me.txtGotoSlot.AccessibleDescription = "TextboxClick"
        Me.txtGotoSlot.AccessibleName = "Rotate"
        Me.txtGotoSlot.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGotoSlot.Clickable = False
        Me.txtGotoSlot.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGotoSlot.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGotoSlot.GetDefaultMinMax = True
        Me.txtGotoSlot.IsNumericTextbox = True
        Me.txtGotoSlot.IsReadBack = True
        Me.txtGotoSlot.Location = New System.Drawing.Point(228, 92)
        Me.txtGotoSlot.Name = "txtGotoSlot"
        Me.txtGotoSlot.ReadOnly = True
        Me.txtGotoSlot.Size = New System.Drawing.Size(125, 24)
        Me.txtGotoSlot.TabIndex = 20
        Me.txtGotoSlot.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        '
        'txtRotate
        '
        Me.txtRotate.AccessibleDescription = ""
        Me.txtRotate.AccessibleName = ""
        Me.txtRotate.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRotate.Clickable = False
        Me.txtRotate.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRotate.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtRotate.GetDefaultMinMax = True
        Me.txtRotate.IsNumericTextbox = True
        Me.txtRotate.IsReadBack = True
        Me.txtRotate.Location = New System.Drawing.Point(359, 92)
        Me.txtRotate.Name = "txtRotate"
        Me.txtRotate.ReadOnly = True
        Me.txtRotate.Size = New System.Drawing.Size(125, 24)
        Me.txtRotate.TabIndex = 8
        Me.txtRotate.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        '
        'btnLiftUp
        '
        Me.btnLiftUp.AccessibleDescription = "Up"
        Me.btnLiftUp.AccessibleName = "LiftUp"
        Me.btnLiftUp.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLiftUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLiftUp.Clickable = True
        Me.btnLiftUp.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnLiftUp.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnLiftUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLiftUp.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnLiftUp.FlatAppearance.BorderSize = 0
        Me.btnLiftUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLiftUp.Font = New System.Drawing.Font("Times New Roman", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnLiftUp.ForeColor = System.Drawing.Color.Black
        Me.btnLiftUp.IsSingleFunction = True
        Me.btnLiftUp.Location = New System.Drawing.Point(89, 35)
        Me.btnLiftUp.MessageBoxText = Nothing
        Me.btnLiftUp.Name = "btnLiftUp"
        Me.btnLiftUp.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLiftUp.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLiftUp.Size = New System.Drawing.Size(133, 25)
        Me.btnLiftUp.TabIndex = 17
        Me.btnLiftUp.Text = "Wafer Lift Up"
        Me.btnLiftUp.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnLiftUp.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnLiftUp.UseVisualStyleBackColor = True
        Me.btnLiftUp.ValueToBeSend = "On"
        '
        'btnLiftDown
        '
        Me.btnLiftDown.AccessibleDescription = "Down"
        Me.btnLiftDown.AccessibleName = "LiftDown"
        Me.btnLiftDown.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLiftDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLiftDown.Clickable = True
        Me.btnLiftDown.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnLiftDown.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnLiftDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLiftDown.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnLiftDown.FlatAppearance.BorderSize = 0
        Me.btnLiftDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLiftDown.Font = New System.Drawing.Font("Times New Roman", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnLiftDown.ForeColor = System.Drawing.Color.Black
        Me.btnLiftDown.IsSingleFunction = True
        Me.btnLiftDown.Location = New System.Drawing.Point(89, 62)
        Me.btnLiftDown.MessageBoxText = Nothing
        Me.btnLiftDown.Name = "btnLiftDown"
        Me.btnLiftDown.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLiftDown.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLiftDown.Size = New System.Drawing.Size(133, 25)
        Me.btnLiftDown.TabIndex = 17
        Me.btnLiftDown.Text = "Wafer Lift Down"
        Me.btnLiftDown.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnLiftDown.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnLiftDown.UseVisualStyleBackColor = True
        Me.btnLiftDown.ValueToBeSend = "On"
        '
        'txtTablePos
        '
        Me.txtTablePos.AccessibleDescription = ""
        Me.txtTablePos.AccessibleName = ""
        Me.txtTablePos.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTablePos.Clickable = False
        Me.txtTablePos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTablePos.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTablePos.GetDefaultMinMax = True
        Me.txtTablePos.IsNumericTextbox = True
        Me.txtTablePos.IsReadBack = True
        Me.txtTablePos.Location = New System.Drawing.Point(490, 92)
        Me.txtTablePos.Name = "txtTablePos"
        Me.txtTablePos.ReadOnly = True
        Me.txtTablePos.Size = New System.Drawing.Size(125, 24)
        Me.txtTablePos.TabIndex = 22
        Me.txtTablePos.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        '
        'txtTablePosRight
        '
        Me.txtTablePosRight.AccessibleDescription = "TextboxClick"
        Me.txtTablePosRight.AccessibleName = "Table Height"
        Me.txtTablePosRight.BackColor = System.Drawing.Color.White
        Me.txtTablePosRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTablePosRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTablePosRight.IsNumericTextbox = True
        Me.txtTablePosRight.IsReadBack = False
        Me.txtTablePosRight.Location = New System.Drawing.Point(490, 63)
        Me.txtTablePosRight.Name = "txtTablePosRight"
        Me.txtTablePosRight.ReadOnly = True
        Me.txtTablePosRight.Size = New System.Drawing.Size(125, 24)
        Me.txtTablePosRight.TabIndex = 21
        Me.txtTablePosRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        '
        'btnHomeTable
        '
        Me.btnHomeTable.AccessibleDescription = "Table Home"
        Me.btnHomeTable.AccessibleName = "TableHome"
        Me.btnHomeTable.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHomeTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHomeTable.Clickable = True
        Me.btnHomeTable.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnHomeTable.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnHomeTable.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHomeTable.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnHomeTable.FlatAppearance.BorderSize = 0
        Me.btnHomeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHomeTable.Font = New System.Drawing.Font("Times New Roman", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnHomeTable.ForeColor = System.Drawing.Color.Black
        Me.btnHomeTable.Image = Global.AVP_Robot_Project.My.Resources.Resources.Up_Down_Arow
        Me.btnHomeTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHomeTable.IsSingleFunction = True
        Me.btnHomeTable.Location = New System.Drawing.Point(490, 35)
        Me.btnHomeTable.MessageBoxText = Nothing
        Me.btnHomeTable.Name = "btnHomeTable"
        Me.btnHomeTable.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHomeTable.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHomeTable.Size = New System.Drawing.Size(125, 25)
        Me.btnHomeTable.TabIndex = 23
        Me.btnHomeTable.Text = " Home Table"
        Me.btnHomeTable.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.btnHomeTable.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnHomeTable.UseVisualStyleBackColor = True
        Me.btnHomeTable.ValueToBeSend = "On"
        Me.btnHomeTable.ValueToSend_WhenStatusOn = "On"
        '
        'lblAllAxisHome
        '
        Me.lblAllAxisHome.AutoSize = True
        Me.lblAllAxisHome.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAllAxisHome.ForeColor = System.Drawing.Color.Lime
        Me.lblAllAxisHome.Location = New System.Drawing.Point(7, 94)
        Me.lblAllAxisHome.Name = "lblAllAxisHome"
        Me.lblAllAxisHome.Size = New System.Drawing.Size(159, 22)
        Me.lblAllAxisHome.TabIndex = 24
        Me.lblAllAxisHome.Text = "ALL AXIS HOME"
        '
        'txtNumberOfUnitPerRevolution
        '
        Me.txtNumberOfUnitPerRevolution.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumberOfUnitPerRevolution.Clickable = False
        Me.txtNumberOfUnitPerRevolution.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtNumberOfUnitPerRevolution.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumberOfUnitPerRevolution.IsReadBack = True
        Me.txtNumberOfUnitPerRevolution.Location = New System.Drawing.Point(539, 172)
        Me.txtNumberOfUnitPerRevolution.Name = "txtNumberOfUnitPerRevolution"
        Me.txtNumberOfUnitPerRevolution.ReadOnly = True
        Me.txtNumberOfUnitPerRevolution.Size = New System.Drawing.Size(76, 24)
        Me.txtNumberOfUnitPerRevolution.TabIndex = 322
        Me.txtNumberOfUnitPerRevolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtNumberOfUnitPerRevolution.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtNumberOfUnitPerRevolution.UseScientificFormat = True
        Me.txtNumberOfUnitPerRevolution.Visible = False
        '
        'txtSubstrateTableRotatePosition
        '
        Me.txtSubstrateTableRotatePosition.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSubstrateTableRotatePosition.Clickable = False
        Me.txtSubstrateTableRotatePosition.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSubstrateTableRotatePosition.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSubstrateTableRotatePosition.IsReadBack = True
        Me.txtSubstrateTableRotatePosition.Location = New System.Drawing.Point(539, 142)
        Me.txtSubstrateTableRotatePosition.Name = "txtSubstrateTableRotatePosition"
        Me.txtSubstrateTableRotatePosition.ReadOnly = True
        Me.txtSubstrateTableRotatePosition.Size = New System.Drawing.Size(76, 24)
        Me.txtSubstrateTableRotatePosition.TabIndex = 321
        Me.txtSubstrateTableRotatePosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtSubstrateTableRotatePosition.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtSubstrateTableRotatePosition.UseScientificFormat = True
        Me.txtSubstrateTableRotatePosition.Visible = False
        '
        'lblTSD
        '
        Me.lblTSD.AutoSize = True
        Me.lblTSD.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblTSD.ForeColor = System.Drawing.Color.Black
        Me.lblTSD.Location = New System.Drawing.Point(573, 67)
        Me.lblTSD.Name = "lblTSD"
        Me.lblTSD.Size = New System.Drawing.Size(47, 17)
        Me.lblTSD.TabIndex = 323
        Me.lblTSD.Text = "(TSD)"
        '
        'CORONA_TableControl
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.lblTSD)
        Me.Controls.Add(Me.txtNumberOfUnitPerRevolution)
        Me.Controls.Add(Me.txtSubstrateTableRotatePosition)
        Me.Controls.Add(Me.lblAllAxisHome)
        Me.Controls.Add(Me.btnHomeTable)
        Me.Controls.Add(Me.txtTablePos)
        Me.Controls.Add(Me.txtTablePosRight)
        Me.Controls.Add(Me.txtGotoSlot)
        Me.Controls.Add(Me.cbxGoTo)
        Me.Controls.Add(Me.btnRotate)
        Me.Controls.Add(Me.btnHOME)
        Me.Controls.Add(Me.btnLiftDown)
        Me.Controls.Add(Me.btnLiftUp)
        Me.Controls.Add(Me.txtRotate)
        Me.Controls.Add(Me.txtRotateRight)
        Me.DoubleBuffered = True
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.On
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "CORONA_TableControl"
        Me.Size = New System.Drawing.Size(623, 125)
        Me.Text = "Table Control"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.txtRotateRight, 0)
        Me.Controls.SetChildIndex(Me.txtRotate, 0)
        Me.Controls.SetChildIndex(Me.btnLiftUp, 0)
        Me.Controls.SetChildIndex(Me.btnLiftDown, 0)
        Me.Controls.SetChildIndex(Me.btnHOME, 0)
        Me.Controls.SetChildIndex(Me.btnRotate, 0)
        Me.Controls.SetChildIndex(Me.cbxGoTo, 0)
        Me.Controls.SetChildIndex(Me.txtGotoSlot, 0)
        Me.Controls.SetChildIndex(Me.txtTablePosRight, 0)
        Me.Controls.SetChildIndex(Me.txtTablePos, 0)
        Me.Controls.SetChildIndex(Me.btnHomeTable, 0)
        Me.Controls.SetChildIndex(Me.lblAllAxisHome, 0)
        Me.Controls.SetChildIndex(Me.txtSubstrateTableRotatePosition, 0)
        Me.Controls.SetChildIndex(Me.txtNumberOfUnitPerRevolution, 0)
        Me.Controls.SetChildIndex(Me.lblTSD, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRotateRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnHOME As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnRotate As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents cbxGoTo As System.Windows.Forms.ComboBox
    Friend WithEvents txtGotoSlot As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtRotate As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnLiftUp As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnLiftDown As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtTablePos As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtTablePosRight As AVP_Robot_Project.SL_Textbox
    Friend WithEvents btnHomeTable As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lblAllAxisHome As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfUnitPerRevolution As AVP_Robot_Project.SL_Textbox
    Friend WithEvents txtSubstrateTableRotatePosition As AVP_Robot_Project.SL_Textbox
    Friend WithEvents lblTSD As System.Windows.Forms.Label

End Class
