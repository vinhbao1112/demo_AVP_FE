<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVD5T_TableControl
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
        Me.txtRotateRight = New AVP_Robot_Project.SL_Textbox()
        Me.btnHOME = New AVP_Robot_Project.SL_CustomButton()
        Me.btnRotate = New AVP_Robot_Project.SL_CustomButton()
        Me.cbxGoTo = New System.Windows.Forms.ComboBox()
        Me.txtGotoSlot = New AVP_Robot_Project.SL_Textbox()
        Me.txtRotate = New AVP_Robot_Project.SL_Textbox()
        Me.btnLiftUp = New AVP_Robot_Project.SL_CustomButton()
        Me.btnLiftDown = New AVP_Robot_Project.SL_CustomButton()
        Me.txtTablePos = New AVP_Robot_Project.SL_Textbox()
        Me.txtTablePosRight = New AVP_Robot_Project.SL_Textbox()
        Me.btnHomeTable = New AVP_Robot_Project.SL_CustomButton()
        Me.lblAllAxisHome = New System.Windows.Forms.Label()
        Me.txtNumberOfUnitPerRevolution = New AVP_Robot_Project.SL_Textbox()
        Me.txtSubstrateTableRotatePosition = New AVP_Robot_Project.SL_Textbox()
        Me.lblTSD = New System.Windows.Forms.Label()
        Me.btnShutterHome = New AVP_Robot_Project.SL_CustomButton()
        Me.cbxShutterSP = New System.Windows.Forms.ComboBox()
        Me.txtShutterRB = New AVP_Robot_Project.SL_Textbox()
        Me.grbGotoSlot = New System.Windows.Forms.GroupBox()
        Me.grbTableRatate = New System.Windows.Forms.GroupBox()
        Me.grbShutter = New System.Windows.Forms.GroupBox()
        Me.grbTableHeight = New System.Windows.Forms.GroupBox()
        Me.txtShutterCurrentSP = New AVP_Robot_Project.SL_Textbox()
        Me.grbGotoSlot.SuspendLayout()
        Me.grbTableRatate.SuspendLayout()
        Me.grbShutter.SuspendLayout()
        Me.grbTableHeight.SuspendLayout()
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
        Me.Header.Status = AVP_Robot_Project.ButtonIGCGControl.DisplayStatus.[On]
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
        Me.txtRotateRight.Location = New System.Drawing.Point(4, 51)
        Me.txtRotateRight.MinimumValueHighlightedGreen = 0R
        Me.txtRotateRight.Name = "txtRotateRight"
        Me.txtRotateRight.ReadOnly = True
        Me.txtRotateRight.Size = New System.Drawing.Size(100, 24)
        Me.txtRotateRight.TabIndex = 8
        Me.txtRotateRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD5T
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
        Me.btnHOME.Size = New System.Drawing.Size(120, 55)
        Me.btnHOME.TabIndex = 17
        Me.btnHOME.Text = "HOME ALL"
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
        Me.btnRotate.Location = New System.Drawing.Point(4, 21)
        Me.btnRotate.MessageBoxText = Nothing
        Me.btnRotate.Name = "btnRotate"
        Me.btnRotate.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRotate.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnRotate.Size = New System.Drawing.Size(100, 25)
        Me.btnRotate.TabIndex = 17
        Me.btnRotate.Text = "Rotate Cont."
        Me.btnRotate.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD5T
        Me.btnRotate.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnRotate.UseChangeValueToSend_BaseOnStatus = True
        Me.btnRotate.UseClickedEventInForm = True
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
        Me.cbxGoTo.Location = New System.Drawing.Point(4, 52)
        Me.cbxGoTo.Name = "cbxGoTo"
        Me.cbxGoTo.Size = New System.Drawing.Size(100, 23)
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
        Me.txtGotoSlot.Location = New System.Drawing.Point(4, 80)
        Me.txtGotoSlot.MinimumValueHighlightedGreen = 0R
        Me.txtGotoSlot.Name = "txtGotoSlot"
        Me.txtGotoSlot.ReadOnly = True
        Me.txtGotoSlot.Size = New System.Drawing.Size(100, 24)
        Me.txtGotoSlot.TabIndex = 20
        Me.txtGotoSlot.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD5T
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
        Me.txtRotate.Location = New System.Drawing.Point(4, 80)
        Me.txtRotate.MinimumValueHighlightedGreen = 0R
        Me.txtRotate.Name = "txtRotate"
        Me.txtRotate.ReadOnly = True
        Me.txtRotate.Size = New System.Drawing.Size(100, 24)
        Me.txtRotate.TabIndex = 8
        Me.txtRotate.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD5T
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
        Me.btnLiftUp.Location = New System.Drawing.Point(8, 93)
        Me.btnLiftUp.MessageBoxText = Nothing
        Me.btnLiftUp.Name = "btnLiftUp"
        Me.btnLiftUp.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLiftUp.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLiftUp.Size = New System.Drawing.Size(120, 25)
        Me.btnLiftUp.TabIndex = 17
        Me.btnLiftUp.Text = "Wafer Lift Up"
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
        Me.btnLiftDown.Location = New System.Drawing.Point(8, 122)
        Me.btnLiftDown.MessageBoxText = Nothing
        Me.btnLiftDown.Name = "btnLiftDown"
        Me.btnLiftDown.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnLiftDown.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnLiftDown.Size = New System.Drawing.Size(120, 25)
        Me.btnLiftDown.TabIndex = 17
        Me.btnLiftDown.Text = "Wafer Lift Down"
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
        Me.txtTablePos.Location = New System.Drawing.Point(4, 80)
        Me.txtTablePos.MinimumValueHighlightedGreen = 0R
        Me.txtTablePos.Name = "txtTablePos"
        Me.txtTablePos.ReadOnly = True
        Me.txtTablePos.Size = New System.Drawing.Size(100, 24)
        Me.txtTablePos.TabIndex = 22
        Me.txtTablePos.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD5T
        '
        'txtTablePosRight
        '
        Me.txtTablePosRight.AccessibleDescription = "TextboxClick"
        Me.txtTablePosRight.AccessibleName = "Table Height"
        Me.txtTablePosRight.BackColor = System.Drawing.Color.White
        Me.txtTablePosRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTablePosRight.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTablePosRight.IsNumericTextbox = True
        Me.txtTablePosRight.Location = New System.Drawing.Point(4, 51)
        Me.txtTablePosRight.MinimumValueHighlightedGreen = 0R
        Me.txtTablePosRight.Name = "txtTablePosRight"
        Me.txtTablePosRight.ReadOnly = True
        Me.txtTablePosRight.Size = New System.Drawing.Size(100, 24)
        Me.txtTablePosRight.TabIndex = 21
        Me.txtTablePosRight.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD5T
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
        Me.btnHomeTable.Location = New System.Drawing.Point(4, 21)
        Me.btnHomeTable.MessageBoxText = Nothing
        Me.btnHomeTable.Name = "btnHomeTable"
        Me.btnHomeTable.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHomeTable.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnHomeTable.Size = New System.Drawing.Size(100, 25)
        Me.btnHomeTable.TabIndex = 23
        Me.btnHomeTable.Text = " Home"
        Me.btnHomeTable.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD5T
        Me.btnHomeTable.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnHomeTable.UseClickedEventInForm = True
        Me.btnHomeTable.UseVisualStyleBackColor = True
        Me.btnHomeTable.ValueToBeSend = "On"
        Me.btnHomeTable.ValueToSend_WhenStatusOn = "On"
        '
        'lblAllAxisHome
        '
        Me.lblAllAxisHome.AutoSize = True
        Me.lblAllAxisHome.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAllAxisHome.ForeColor = System.Drawing.Color.Lime
        Me.lblAllAxisHome.Location = New System.Drawing.Point(4, 124)
        Me.lblAllAxisHome.Name = "lblAllAxisHome"
        Me.lblAllAxisHome.Size = New System.Drawing.Size(129, 17)
        Me.lblAllAxisHome.TabIndex = 24
        Me.lblAllAxisHome.Text = "ALL AXIS HOME"
        Me.lblAllAxisHome.Visible = False
        '
        'txtNumberOfUnitPerRevolution
        '
        Me.txtNumberOfUnitPerRevolution.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumberOfUnitPerRevolution.Clickable = False
        Me.txtNumberOfUnitPerRevolution.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtNumberOfUnitPerRevolution.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumberOfUnitPerRevolution.IsReadBack = True
        Me.txtNumberOfUnitPerRevolution.Location = New System.Drawing.Point(531, 192)
        Me.txtNumberOfUnitPerRevolution.MinimumValueHighlightedGreen = 0R
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
        Me.txtSubstrateTableRotatePosition.Location = New System.Drawing.Point(531, 162)
        Me.txtSubstrateTableRotatePosition.MinimumValueHighlightedGreen = 0R
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
        Me.lblTSD.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTSD.ForeColor = System.Drawing.Color.Black
        Me.lblTSD.Location = New System.Drawing.Point(68, 55)
        Me.lblTSD.Name = "lblTSD"
        Me.lblTSD.Size = New System.Drawing.Size(40, 15)
        Me.lblTSD.TabIndex = 323
        Me.lblTSD.Text = "(TSD)"
        '
        'btnShutterHome
        '
        Me.btnShutterHome.AccessibleDescription = "HomeShutter"
        Me.btnShutterHome.AccessibleName = "HomeShutter"
        Me.btnShutterHome.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnShutterHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShutterHome.Clickable = True
        Me.btnShutterHome.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnShutterHome.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnShutterHome.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShutterHome.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnShutterHome.FlatAppearance.BorderSize = 0
        Me.btnShutterHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShutterHome.Font = New System.Drawing.Font("Times New Roman", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShutterHome.ForeColor = System.Drawing.Color.Black
        Me.btnShutterHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShutterHome.Location = New System.Drawing.Point(4, 21)
        Me.btnShutterHome.MessageBoxText = Nothing
        Me.btnShutterHome.Name = "btnShutterHome"
        Me.btnShutterHome.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnShutterHome.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnShutterHome.Size = New System.Drawing.Size(100, 25)
        Me.btnShutterHome.TabIndex = 17
        Me.btnShutterHome.Text = "Home"
        Me.btnShutterHome.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD5T
        Me.btnShutterHome.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
        Me.btnShutterHome.UseChangeValueToSend_BaseOnStatus = True
        Me.btnShutterHome.UseClickedEventInForm = True
        Me.btnShutterHome.UseVisualStyleBackColor = True
        Me.btnShutterHome.ValueToBeSend = "On"
        '
        'cbxShutterSP
        '
        Me.cbxShutterSP.AccessibleDescription = "Shutter"
        Me.cbxShutterSP.AccessibleName = "ShutterX"
        Me.cbxShutterSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxShutterSP.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cbxShutterSP.FormattingEnabled = True
        Me.cbxShutterSP.IntegralHeight = False
        Me.cbxShutterSP.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cbxShutterSP.Location = New System.Drawing.Point(4, 52)
        Me.cbxShutterSP.Name = "cbxShutterSP"
        Me.cbxShutterSP.Size = New System.Drawing.Size(100, 23)
        Me.cbxShutterSP.TabIndex = 19
        '
        'txtShutterRB
        '
        Me.txtShutterRB.AccessibleDescription = "TextboxClick"
        Me.txtShutterRB.AccessibleName = "Rotate"
        Me.txtShutterRB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtShutterRB.Clickable = False
        Me.txtShutterRB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtShutterRB.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtShutterRB.GetDefaultMinMax = True
        Me.txtShutterRB.IsNumericTextbox = True
        Me.txtShutterRB.IsReadBack = True
        Me.txtShutterRB.Location = New System.Drawing.Point(4, 80)
        Me.txtShutterRB.MinimumValueHighlightedGreen = 0R
        Me.txtShutterRB.Name = "txtShutterRB"
        Me.txtShutterRB.ReadOnly = True
        Me.txtShutterRB.Size = New System.Drawing.Size(100, 24)
        Me.txtShutterRB.TabIndex = 20
        Me.txtShutterRB.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD5T
        '
        'grbGotoSlot
        '
        Me.grbGotoSlot.Controls.Add(Me.txtGotoSlot)
        Me.grbGotoSlot.Controls.Add(Me.cbxGoTo)
        Me.grbGotoSlot.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbGotoSlot.Location = New System.Drawing.Point(140, 35)
        Me.grbGotoSlot.Name = "grbGotoSlot"
        Me.grbGotoSlot.Size = New System.Drawing.Size(107, 112)
        Me.grbGotoSlot.TabIndex = 324
        Me.grbGotoSlot.TabStop = False
        Me.grbGotoSlot.Text = "Go To Slot"
        '
        'grbTableRatate
        '
        Me.grbTableRatate.Controls.Add(Me.txtRotate)
        Me.grbTableRatate.Controls.Add(Me.txtRotateRight)
        Me.grbTableRatate.Controls.Add(Me.btnRotate)
        Me.grbTableRatate.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbTableRatate.Location = New System.Drawing.Point(259, 35)
        Me.grbTableRatate.Name = "grbTableRatate"
        Me.grbTableRatate.Size = New System.Drawing.Size(107, 112)
        Me.grbTableRatate.TabIndex = 324
        Me.grbTableRatate.TabStop = False
        Me.grbTableRatate.Text = "Table Rotate"
        '
        'grbShutter
        '
        Me.grbShutter.Controls.Add(Me.txtShutterRB)
        Me.grbShutter.Controls.Add(Me.btnShutterHome)
        Me.grbShutter.Controls.Add(Me.cbxShutterSP)
        Me.grbShutter.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbShutter.Location = New System.Drawing.Point(497, 35)
        Me.grbShutter.Name = "grbShutter"
        Me.grbShutter.Size = New System.Drawing.Size(107, 112)
        Me.grbShutter.TabIndex = 324
        Me.grbShutter.TabStop = False
        Me.grbShutter.Text = "Shutter"
        '
        'grbTableHeight
        '
        Me.grbTableHeight.Controls.Add(Me.txtTablePos)
        Me.grbTableHeight.Controls.Add(Me.btnHomeTable)
        Me.grbTableHeight.Controls.Add(Me.lblTSD)
        Me.grbTableHeight.Controls.Add(Me.txtTablePosRight)
        Me.grbTableHeight.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbTableHeight.Location = New System.Drawing.Point(378, 35)
        Me.grbTableHeight.Name = "grbTableHeight"
        Me.grbTableHeight.Size = New System.Drawing.Size(107, 112)
        Me.grbTableHeight.TabIndex = 324
        Me.grbTableHeight.TabStop = False
        Me.grbTableHeight.Text = "Table Height"
        '
        'txtShutterCurrentSP
        '
        Me.txtShutterCurrentSP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtShutterCurrentSP.Clickable = False
        Me.txtShutterCurrentSP.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtShutterCurrentSP.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtShutterCurrentSP.IsReadBack = True
        Me.txtShutterCurrentSP.Location = New System.Drawing.Point(531, 222)
        Me.txtShutterCurrentSP.MinimumValueHighlightedGreen = 0R
        Me.txtShutterCurrentSP.Name = "txtShutterCurrentSP"
        Me.txtShutterCurrentSP.ReadOnly = True
        Me.txtShutterCurrentSP.Size = New System.Drawing.Size(76, 24)
        Me.txtShutterCurrentSP.TabIndex = 325
        Me.txtShutterCurrentSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtShutterCurrentSP.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtShutterCurrentSP.Visible = False
        '
        'PVD5T_TableControl
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtShutterCurrentSP)
        Me.Controls.Add(Me.grbTableHeight)
        Me.Controls.Add(Me.grbShutter)
        Me.Controls.Add(Me.grbTableRatate)
        Me.Controls.Add(Me.grbGotoSlot)
        Me.Controls.Add(Me.txtNumberOfUnitPerRevolution)
        Me.Controls.Add(Me.txtSubstrateTableRotatePosition)
        Me.Controls.Add(Me.lblAllAxisHome)
        Me.Controls.Add(Me.btnHOME)
        Me.Controls.Add(Me.btnLiftDown)
        Me.Controls.Add(Me.btnLiftUp)
        Me.DoubleBuffered = True
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderText = "Table Control"
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "PVD5T_TableControl"
        Me.Size = New System.Drawing.Size(623, 156)
        Me.Text = "Table Control"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.btnLiftUp, 0)
        Me.Controls.SetChildIndex(Me.btnLiftDown, 0)
        Me.Controls.SetChildIndex(Me.btnHOME, 0)
        Me.Controls.SetChildIndex(Me.lblAllAxisHome, 0)
        Me.Controls.SetChildIndex(Me.txtSubstrateTableRotatePosition, 0)
        Me.Controls.SetChildIndex(Me.txtNumberOfUnitPerRevolution, 0)
        Me.Controls.SetChildIndex(Me.grbGotoSlot, 0)
        Me.Controls.SetChildIndex(Me.grbTableRatate, 0)
        Me.Controls.SetChildIndex(Me.grbShutter, 0)
        Me.Controls.SetChildIndex(Me.grbTableHeight, 0)
        Me.Controls.SetChildIndex(Me.txtShutterCurrentSP, 0)
        Me.grbGotoSlot.ResumeLayout(False)
        Me.grbGotoSlot.PerformLayout()
        Me.grbTableRatate.ResumeLayout(False)
        Me.grbTableRatate.PerformLayout()
        Me.grbShutter.ResumeLayout(False)
        Me.grbShutter.PerformLayout()
        Me.grbTableHeight.ResumeLayout(False)
        Me.grbTableHeight.PerformLayout()
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
    Friend WithEvents btnShutterHome As SL_CustomButton
    Friend WithEvents cbxShutterSP As ComboBox
    Friend WithEvents txtShutterRB As SL_Textbox
    Friend WithEvents grbGotoSlot As GroupBox
    Friend WithEvents grbTableRatate As GroupBox
    Friend WithEvents grbShutter As GroupBox
    Friend WithEvents grbTableHeight As GroupBox
    Friend WithEvents txtShutterCurrentSP As SL_Textbox
End Class
