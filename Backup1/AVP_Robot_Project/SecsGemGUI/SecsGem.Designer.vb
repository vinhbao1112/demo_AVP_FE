<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SecsGemPanel
    Inherits PVDStatusPanel

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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.chkUsePopUpTerminal = New System.Windows.Forms.CheckBox
        Me.btnChatPopUp = New System.Windows.Forms.Button
        Me.txtMessageToHost = New AVP_Robot_Project.SL_Textbox
        Me.btnClearfromHost = New AVP_Robot_Project.SL_CustomButton
        Me.txtMessageFromHost = New AVP_Robot_Project.SL_Textbox
        Me.Label23 = New System.Windows.Forms.Label
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.rbnRecipe = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.rbnSequence = New System.Windows.Forms.RadioButton
        Me.rbnWaferFlow = New System.Windows.Forms.RadioButton
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.lstPP = New System.Windows.Forms.ListBox
        Me.btnDownloadProcess = New AVP_Robot_Project.SL_CustomButton
        Me.btnUploadProcess = New AVP_Robot_Project.SL_CustomButton
        Me.txtPPDownload = New AVP_Robot_Project.SL_Textbox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnGoOnlineRemote = New AVP_Robot_Project.SL_CustomButton
        Me.btnGoOnlineLocal = New AVP_Robot_Project.SL_CustomButton
        Me.btnOnlineRemote = New AVP_Robot_Project.SL_CustomButton
        Me.btnOffline = New AVP_Robot_Project.SL_CustomButton
        Me.btnAttemptOnline = New AVP_Robot_Project.SL_CustomButton
        Me.btnOnlineLocal = New AVP_Robot_Project.SL_CustomButton
        Me.btnHostOffline = New AVP_Robot_Project.SL_CustomButton
        Me.lblPadding = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.btnCommunicationStatus = New AVP_Robot_Project.SL_CustomButton
        Me.btnDisable = New AVP_Robot_Project.SL_CustomButton
        Me.btnEnable = New AVP_Robot_Project.SL_CustomButton
        Me.cbOnlineLocal = New System.Windows.Forms.RadioButton
        Me.cbOnlineRemote = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.UploadDownloadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.pnlTerminal = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTerminal.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgMsgBoxHeader
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1280, 70)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1280, 70)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SECS/GEM MENU"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.chkUsePopUpTerminal)
        Me.Panel8.Controls.Add(Me.btnChatPopUp)
        Me.Panel8.Controls.Add(Me.txtMessageToHost)
        Me.Panel8.Controls.Add(Me.btnClearfromHost)
        Me.Panel8.Controls.Add(Me.txtMessageFromHost)
        Me.Panel8.Controls.Add(Me.Label23)
        Me.Panel8.Controls.Add(Me.PictureBox7)
        Me.Panel8.Controls.Add(Me.Label19)
        Me.Panel8.Controls.Add(Me.rbnRecipe)
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Controls.Add(Me.rbnSequence)
        Me.Panel8.Controls.Add(Me.rbnWaferFlow)
        Me.Panel8.Controls.Add(Me.PictureBox5)
        Me.Panel8.Controls.Add(Me.PictureBox2)
        Me.Panel8.Controls.Add(Me.lstPP)
        Me.Panel8.Controls.Add(Me.btnDownloadProcess)
        Me.Panel8.Controls.Add(Me.btnUploadProcess)
        Me.Panel8.Controls.Add(Me.txtPPDownload)
        Me.Panel8.Controls.Add(Me.Label12)
        Me.Panel8.Location = New System.Drawing.Point(18, 245)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1255, 480)
        Me.Panel8.TabIndex = 9
        '
        'chkUsePopUpTerminal
        '
        Me.chkUsePopUpTerminal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkUsePopUpTerminal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUsePopUpTerminal.Location = New System.Drawing.Point(1099, 369)
        Me.chkUsePopUpTerminal.Name = "chkUsePopUpTerminal"
        Me.chkUsePopUpTerminal.Size = New System.Drawing.Size(161, 61)
        Me.chkUsePopUpTerminal.TabIndex = 23
        Me.chkUsePopUpTerminal.Text = "Enable Pop-Up"
        Me.chkUsePopUpTerminal.UseVisualStyleBackColor = True
        '
        'btnChatPopUp
        '
        Me.btnChatPopUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChatPopUp.Image = Global.AVP_Robot_Project.My.Resources.Resources.ChatPopUp
        Me.btnChatPopUp.Location = New System.Drawing.Point(1150, 433)
        Me.btnChatPopUp.Name = "btnChatPopUp"
        Me.btnChatPopUp.Size = New System.Drawing.Size(45, 34)
        Me.btnChatPopUp.TabIndex = 22
        Me.btnChatPopUp.UseVisualStyleBackColor = True
        '
        'txtMessageToHost
        '
        Me.txtMessageToHost.AutoSendEventHandler = False
        Me.txtMessageToHost.AutoSendKeyTabWhenFinishInput = False
        Me.txtMessageToHost.BackColor = System.Drawing.Color.White
        Me.txtMessageToHost.Clickable = False
        Me.txtMessageToHost.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMessageToHost.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMessageToHost.GasName = ""
        Me.txtMessageToHost.GetDefaultMinMax = False
        Me.txtMessageToHost.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtMessageToHost.IsIntergerNumber = False
        Me.txtMessageToHost.IsNumericTextbox = False
        Me.txtMessageToHost.IsReadBack = False
        Me.txtMessageToHost.IsTurboPumpTextbox = False
        Me.txtMessageToHost.Location = New System.Drawing.Point(159, 438)
        Me.txtMessageToHost.LogSource = ""
        Me.txtMessageToHost.Multiline = True
        Me.txtMessageToHost.Name = "txtMessageToHost"
        Me.txtMessageToHost.PermissionCode = ""
        Me.txtMessageToHost.ReadOnly = True
        Me.txtMessageToHost.ShowUnitFormat = False
        Me.txtMessageToHost.Size = New System.Drawing.Size(925, 29)
        Me.txtMessageToHost.SourceOfMessageBox = ""
        Me.txtMessageToHost.TabIndex = 7
        Me.txtMessageToHost.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtMessageToHost.UnitTypeUsed = ""
        Me.txtMessageToHost.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtMessageToHost.UseClickEventInForm = False
        Me.txtMessageToHost.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtMessageToHost.UseScientificFormat = True
        '
        'btnClearfromHost
        '
        Me.btnClearfromHost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearfromHost.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClearfromHost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearfromHost.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnClearfromHost.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnClearfromHost.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearfromHost.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClearfromHost.FlatAppearance.BorderSize = 0
        Me.btnClearfromHost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearfromHost.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearfromHost.ForeColor = System.Drawing.Color.Black
        Me.btnClearfromHost.Image = Global.AVP_Robot_Project.My.Resources.Resources.Delete2
        Me.btnClearfromHost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearfromHost.Location = New System.Drawing.Point(1101, 322)
        Me.btnClearfromHost.MessageBoxText = Nothing
        Me.btnClearfromHost.Name = "btnClearfromHost"
        Me.btnClearfromHost.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClearfromHost.OffText = "Clear   "
        Me.btnClearfromHost.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClearfromHost.OnText = "Clear   "
        Me.btnClearfromHost.Size = New System.Drawing.Size(143, 43)
        Me.btnClearfromHost.TabIndex = 8
        Me.btnClearfromHost.Text = "Clear All   "
        Me.btnClearfromHost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClearfromHost.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClearfromHost.UseVisualStyleBackColor = True
        Me.btnClearfromHost.ValueToBeSend = "On"
        '
        'txtMessageFromHost
        '
        Me.txtMessageFromHost.AutoSendEventHandler = False
        Me.txtMessageFromHost.AutoSendKeyTabWhenFinishInput = False
        Me.txtMessageFromHost.BackColor = System.Drawing.Color.White
        Me.txtMessageFromHost.Clickable = False
        Me.txtMessageFromHost.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtMessageFromHost.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMessageFromHost.GasName = ""
        Me.txtMessageFromHost.GetDefaultMinMax = False
        Me.txtMessageFromHost.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtMessageFromHost.IsIntergerNumber = False
        Me.txtMessageFromHost.IsNumericTextbox = False
        Me.txtMessageFromHost.IsReadBack = False
        Me.txtMessageFromHost.IsTurboPumpTextbox = False
        Me.txtMessageFromHost.Location = New System.Drawing.Point(159, 322)
        Me.txtMessageFromHost.LogSource = ""
        Me.txtMessageFromHost.Multiline = True
        Me.txtMessageFromHost.Name = "txtMessageFromHost"
        Me.txtMessageFromHost.PermissionCode = ""
        Me.txtMessageFromHost.ReadOnly = True
        Me.txtMessageFromHost.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMessageFromHost.ShowUnitFormat = False
        Me.txtMessageFromHost.Size = New System.Drawing.Size(925, 108)
        Me.txtMessageFromHost.SourceOfMessageBox = ""
        Me.txtMessageFromHost.TabIndex = 7
        Me.txtMessageFromHost.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtMessageFromHost.UnitTypeUsed = ""
        Me.txtMessageFromHost.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtMessageFromHost.UseClickEventInForm = False
        Me.txtMessageFromHost.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtMessageFromHost.UseScientificFormat = True
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(11, 437)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(138, 31)
        Me.Label23.TabIndex = 17
        Me.Label23.Text = "Message to Host:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox7
        '
        Me.PictureBox7.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox7.Location = New System.Drawing.Point(0, 308)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(1260, 3)
        Me.PictureBox7.TabIndex = 21
        Me.PictureBox7.TabStop = False
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(11, 345)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(82, 65)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Terminal Service Messages"
        '
        'rbnRecipe
        '
        Me.rbnRecipe.AutoSize = True
        Me.rbnRecipe.Cursor = System.Windows.Forms.Cursors.Default
        Me.rbnRecipe.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbnRecipe.Location = New System.Drawing.Point(896, 53)
        Me.rbnRecipe.Name = "rbnRecipe"
        Me.rbnRecipe.Size = New System.Drawing.Size(69, 23)
        Me.rbnRecipe.TabIndex = 4
        Me.rbnRecipe.TabStop = True
        Me.rbnRecipe.Text = "Recipe"
        Me.rbnRecipe.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 272)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 19)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Download Name:"
        '
        'rbnSequence
        '
        Me.rbnSequence.AutoSize = True
        Me.rbnSequence.Cursor = System.Windows.Forms.Cursors.Default
        Me.rbnSequence.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbnSequence.Location = New System.Drawing.Point(192, 53)
        Me.rbnSequence.Name = "rbnSequence"
        Me.rbnSequence.Size = New System.Drawing.Size(86, 23)
        Me.rbnSequence.TabIndex = 4
        Me.rbnSequence.TabStop = True
        Me.rbnSequence.Text = "Sequence"
        Me.rbnSequence.UseVisualStyleBackColor = True
        '
        'rbnWaferFlow
        '
        Me.rbnWaferFlow.AutoSize = True
        Me.rbnWaferFlow.Cursor = System.Windows.Forms.Cursors.Default
        Me.rbnWaferFlow.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbnWaferFlow.Location = New System.Drawing.Point(539, 53)
        Me.rbnWaferFlow.Name = "rbnWaferFlow"
        Me.rbnWaferFlow.Size = New System.Drawing.Size(95, 23)
        Me.rbnWaferFlow.TabIndex = 4
        Me.rbnWaferFlow.TabStop = True
        Me.rbnWaferFlow.Text = "WaferFlow"
        Me.rbnWaferFlow.UseVisualStyleBackColor = True
        '
        'PictureBox5
        '
        Me.PictureBox5.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox5.Location = New System.Drawing.Point(0, 38)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(1253, 3)
        Me.PictureBox5.TabIndex = 18
        Me.PictureBox5.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(0, 257)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1260, 3)
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'lstPP
        '
        Me.lstPP.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPP.FormattingEnabled = True
        Me.lstPP.ItemHeight = 22
        Me.lstPP.Location = New System.Drawing.Point(12, 86)
        Me.lstPP.Name = "lstPP"
        Me.lstPP.Size = New System.Drawing.Size(1230, 158)
        Me.lstPP.TabIndex = 7
        '
        'btnDownloadProcess
        '
        Me.btnDownloadProcess.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDownloadProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDownloadProcess.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnDownloadProcess.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnDownloadProcess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDownloadProcess.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDownloadProcess.FlatAppearance.BorderSize = 0
        Me.btnDownloadProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDownloadProcess.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDownloadProcess.ForeColor = System.Drawing.Color.Black
        Me.btnDownloadProcess.Image = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_Off
        Me.btnDownloadProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDownloadProcess.Location = New System.Drawing.Point(1099, 266)
        Me.btnDownloadProcess.MessageBoxText = Nothing
        Me.btnDownloadProcess.Name = "btnDownloadProcess"
        Me.btnDownloadProcess.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDownloadProcess.OffText = "Upload"
        Me.btnDownloadProcess.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDownloadProcess.OnText = "Upload"
        Me.btnDownloadProcess.Size = New System.Drawing.Size(143, 32)
        Me.btnDownloadProcess.TabIndex = 6
        Me.btnDownloadProcess.Text = "     Download"
        Me.btnDownloadProcess.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDownloadProcess.UseVisualStyleBackColor = True
        Me.btnDownloadProcess.ValueToBeSend = "On"
        '
        'btnUploadProcess
        '
        Me.btnUploadProcess.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUploadProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUploadProcess.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnUploadProcess.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnUploadProcess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUploadProcess.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUploadProcess.FlatAppearance.BorderSize = 0
        Me.btnUploadProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUploadProcess.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUploadProcess.ForeColor = System.Drawing.Color.Black
        Me.btnUploadProcess.Image = Global.AVP_Robot_Project.My.Resources.Resources.Relay_Indicator_On
        Me.btnUploadProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUploadProcess.Location = New System.Drawing.Point(1099, 47)
        Me.btnUploadProcess.MessageBoxText = Nothing
        Me.btnUploadProcess.Name = "btnUploadProcess"
        Me.btnUploadProcess.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUploadProcess.OffText = "  Upload"
        Me.btnUploadProcess.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUploadProcess.OnText = "  Upload"
        Me.btnUploadProcess.Size = New System.Drawing.Size(143, 32)
        Me.btnUploadProcess.TabIndex = 6
        Me.btnUploadProcess.Text = "  Upload"
        Me.btnUploadProcess.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnUploadProcess.UseVisualStyleBackColor = True
        Me.btnUploadProcess.ValueToBeSend = "On"
        '
        'txtPPDownload
        '
        Me.txtPPDownload.AutoSendEventHandler = False
        Me.txtPPDownload.AutoSendKeyTabWhenFinishInput = False
        Me.txtPPDownload.BackColor = System.Drawing.Color.White
        Me.txtPPDownload.Clickable = True
        Me.txtPPDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPPDownload.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPPDownload.GasName = ""
        Me.txtPPDownload.GetDefaultMinMax = False
        Me.txtPPDownload.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtPPDownload.IsIntergerNumber = False
        Me.txtPPDownload.IsNumericTextbox = False
        Me.txtPPDownload.IsReadBack = False
        Me.txtPPDownload.IsTurboPumpTextbox = False
        Me.txtPPDownload.Location = New System.Drawing.Point(159, 271)
        Me.txtPPDownload.LogSource = ""
        Me.txtPPDownload.Name = "txtPPDownload"
        Me.txtPPDownload.PermissionCode = ""
        Me.txtPPDownload.ReadOnly = True
        Me.txtPPDownload.ShowUnitFormat = False
        Me.txtPPDownload.Size = New System.Drawing.Size(925, 24)
        Me.txtPPDownload.SourceOfMessageBox = ""
        Me.txtPPDownload.TabIndex = 5
        Me.txtPPDownload.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.txtPPDownload.UnitTypeUsed = ""
        Me.txtPPDownload.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtPPDownload.UseClickEventInForm = False
        Me.txtPPDownload.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtPPDownload.UseScientificFormat = True
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(0, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(1253, 38)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Process Recipe Management"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.PictureBox3)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.btnGoOnlineRemote)
        Me.Panel5.Controls.Add(Me.btnGoOnlineLocal)
        Me.Panel5.Controls.Add(Me.btnOnlineRemote)
        Me.Panel5.Controls.Add(Me.btnOffline)
        Me.Panel5.Controls.Add(Me.btnAttemptOnline)
        Me.Panel5.Controls.Add(Me.btnOnlineLocal)
        Me.Panel5.Controls.Add(Me.btnHostOffline)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(643, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(618, 166)
        Me.Panel5.TabIndex = 4
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox3.Location = New System.Drawing.Point(0, 28)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(616, 3)
        Me.PictureBox3.TabIndex = 17
        Me.PictureBox3.TabStop = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(616, 28)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Control State"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGoOnlineRemote
        '
        Me.btnGoOnlineRemote.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoOnlineRemote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGoOnlineRemote.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnGoOnlineRemote.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnGoOnlineRemote.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGoOnlineRemote.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoOnlineRemote.FlatAppearance.BorderSize = 0
        Me.btnGoOnlineRemote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGoOnlineRemote.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGoOnlineRemote.ForeColor = System.Drawing.Color.Black
        Me.btnGoOnlineRemote.Location = New System.Drawing.Point(20, 44)
        Me.btnGoOnlineRemote.MessageBoxText = Nothing
        Me.btnGoOnlineRemote.Name = "btnGoOnlineRemote"
        Me.btnGoOnlineRemote.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoOnlineRemote.OffText = "Online Remote"
        Me.btnGoOnlineRemote.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoOnlineRemote.OnText = "Online Remote"
        Me.btnGoOnlineRemote.Size = New System.Drawing.Size(179, 43)
        Me.btnGoOnlineRemote.TabIndex = 0
        Me.btnGoOnlineRemote.Text = "Online Remote"
        Me.btnGoOnlineRemote.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoOnlineRemote.UseClickedEventInForm = True
        Me.btnGoOnlineRemote.UseVisualStyleBackColor = True
        Me.btnGoOnlineRemote.ValueToBeSend = "On"
        '
        'btnGoOnlineLocal
        '
        Me.btnGoOnlineLocal.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoOnlineLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGoOnlineLocal.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnGoOnlineLocal.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnGoOnlineLocal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGoOnlineLocal.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoOnlineLocal.FlatAppearance.BorderSize = 0
        Me.btnGoOnlineLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGoOnlineLocal.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGoOnlineLocal.ForeColor = System.Drawing.Color.Black
        Me.btnGoOnlineLocal.Location = New System.Drawing.Point(221, 47)
        Me.btnGoOnlineLocal.MessageBoxText = Nothing
        Me.btnGoOnlineLocal.Name = "btnGoOnlineLocal"
        Me.btnGoOnlineLocal.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoOnlineLocal.OffText = "Online Local"
        Me.btnGoOnlineLocal.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoOnlineLocal.OnText = "Online Local"
        Me.btnGoOnlineLocal.Size = New System.Drawing.Size(179, 43)
        Me.btnGoOnlineLocal.TabIndex = 0
        Me.btnGoOnlineLocal.Text = "Online Local"
        Me.btnGoOnlineLocal.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnGoOnlineLocal.UseClickedEventInForm = True
        Me.btnGoOnlineLocal.UseVisualStyleBackColor = True
        Me.btnGoOnlineLocal.ValueToBeSend = "On"
        '
        'btnOnlineRemote
        '
        Me.btnOnlineRemote.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOnlineRemote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOnlineRemote.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnOnlineRemote.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOnlineRemote.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOnlineRemote.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRedDown
        Me.btnOnlineRemote.ErrorText = "Error"
        Me.btnOnlineRemote.FlatAppearance.BorderSize = 0
        Me.btnOnlineRemote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnlineRemote.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOnlineRemote.ForeColor = System.Drawing.Color.Black
        Me.btnOnlineRemote.Location = New System.Drawing.Point(20, 108)
        Me.btnOnlineRemote.MessageBoxText = Nothing
        Me.btnOnlineRemote.Name = "btnOnlineRemote"
        Me.btnOnlineRemote.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOnlineRemote.OffText = "On-Line Remote"
        Me.btnOnlineRemote.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreenDown
        Me.btnOnlineRemote.OnText = "On-Line Remote"
        Me.btnOnlineRemote.Size = New System.Drawing.Size(179, 43)
        Me.btnOnlineRemote.TabIndex = 1
        Me.btnOnlineRemote.Text = "On-Line Remote"
        Me.btnOnlineRemote.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOnlineRemote.UseVisualStyleBackColor = True
        Me.btnOnlineRemote.ValueToBeSend = "On"
        '
        'btnOffline
        '
        Me.btnOffline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOffline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOffline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnOffline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOffline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOffline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOffline.FlatAppearance.BorderSize = 0
        Me.btnOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOffline.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOffline.ForeColor = System.Drawing.Color.Black
        Me.btnOffline.Location = New System.Drawing.Point(422, 48)
        Me.btnOffline.MessageBoxText = Nothing
        Me.btnOffline.Name = "btnOffline"
        Me.btnOffline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOffline.OffText = "Offline"
        Me.btnOffline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOffline.OnText = "Offline"
        Me.btnOffline.Size = New System.Drawing.Size(179, 43)
        Me.btnOffline.TabIndex = 0
        Me.btnOffline.Text = "Offline"
        Me.btnOffline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOffline.UseClickedEventInForm = True
        Me.btnOffline.UseVisualStyleBackColor = True
        Me.btnOffline.ValueToBeSend = "On"
        '
        'btnAttemptOnline
        '
        Me.btnAttemptOnline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnAttemptOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAttemptOnline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAttemptOnline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAttemptOnline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAttemptOnline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRedDown
        Me.btnAttemptOnline.ErrorText = "Error"
        Me.btnAttemptOnline.FlatAppearance.BorderSize = 0
        Me.btnAttemptOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAttemptOnline.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttemptOnline.ForeColor = System.Drawing.Color.Black
        Me.btnAttemptOnline.Location = New System.Drawing.Point(619, 103)
        Me.btnAttemptOnline.MessageBoxText = Nothing
        Me.btnAttemptOnline.Name = "btnAttemptOnline"
        Me.btnAttemptOnline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnAttemptOnline.OffText = "Attempting On-Line"
        Me.btnAttemptOnline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreenDown
        Me.btnAttemptOnline.OnText = "Attempting On-Line"
        Me.btnAttemptOnline.Size = New System.Drawing.Size(18, 43)
        Me.btnAttemptOnline.TabIndex = 1
        Me.btnAttemptOnline.Text = "Attempting On-Line"
        Me.btnAttemptOnline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAttemptOnline.UseVisualStyleBackColor = True
        Me.btnAttemptOnline.ValueToBeSend = "On"
        '
        'btnOnlineLocal
        '
        Me.btnOnlineLocal.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOnlineLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOnlineLocal.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnOnlineLocal.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnOnlineLocal.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOnlineLocal.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRedDown
        Me.btnOnlineLocal.ErrorText = "Error"
        Me.btnOnlineLocal.FlatAppearance.BorderSize = 0
        Me.btnOnlineLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnlineLocal.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOnlineLocal.ForeColor = System.Drawing.Color.Black
        Me.btnOnlineLocal.Location = New System.Drawing.Point(221, 108)
        Me.btnOnlineLocal.MessageBoxText = Nothing
        Me.btnOnlineLocal.Name = "btnOnlineLocal"
        Me.btnOnlineLocal.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOnlineLocal.OffText = "On-Line Local"
        Me.btnOnlineLocal.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreenDown
        Me.btnOnlineLocal.OnText = "On-Line Local"
        Me.btnOnlineLocal.Size = New System.Drawing.Size(179, 43)
        Me.btnOnlineLocal.TabIndex = 1
        Me.btnOnlineLocal.Text = "On-Line Local"
        Me.btnOnlineLocal.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOnlineLocal.UseVisualStyleBackColor = True
        Me.btnOnlineLocal.ValueToBeSend = "On"
        '
        'btnHostOffline
        '
        Me.btnHostOffline.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnHostOffline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHostOffline.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnHostOffline.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnHostOffline.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHostOffline.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRedDown
        Me.btnHostOffline.ErrorText = "Error"
        Me.btnHostOffline.FlatAppearance.BorderSize = 0
        Me.btnHostOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHostOffline.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHostOffline.ForeColor = System.Drawing.Color.Black
        Me.btnHostOffline.Location = New System.Drawing.Point(422, 108)
        Me.btnHostOffline.MessageBoxText = Nothing
        Me.btnHostOffline.Name = "btnHostOffline"
        Me.btnHostOffline.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnHostOffline.OffText = "Host Off-Line"
        Me.btnHostOffline.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreenDown
        Me.btnHostOffline.OnText = "Host Off-Line"
        Me.btnHostOffline.Size = New System.Drawing.Size(179, 43)
        Me.btnHostOffline.TabIndex = 1
        Me.btnHostOffline.Text = "Host Off-Line"
        Me.btnHostOffline.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnHostOffline.UseVisualStyleBackColor = True
        Me.btnHostOffline.ValueToBeSend = "On"
        '
        'lblPadding
        '
        Me.lblPadding.BackColor = System.Drawing.Color.Transparent
        Me.lblPadding.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblPadding.Location = New System.Drawing.Point(1269, 70)
        Me.lblPadding.Name = "lblPadding"
        Me.lblPadding.Size = New System.Drawing.Size(11, 671)
        Me.lblPadding.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(0, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(8, 671)
        Me.Label2.TabIndex = 6
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.PictureBox4)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.btnCommunicationStatus)
        Me.Panel4.Controls.Add(Me.btnDisable)
        Me.Panel4.Controls.Add(Me.btnEnable)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(271, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(364, 166)
        Me.Panel4.TabIndex = 8
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox4.Location = New System.Drawing.Point(0, 30)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(362, 3)
        Me.PictureBox4.TabIndex = 18
        Me.PictureBox4.TabStop = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(362, 30)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Communication State"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCommunicationStatus
        '
        Me.btnCommunicationStatus.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnCommunicationStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCommunicationStatus.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnCommunicationStatus.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnCommunicationStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCommunicationStatus.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRedDown
        Me.btnCommunicationStatus.ErrorText = "Error"
        Me.btnCommunicationStatus.FlatAppearance.BorderSize = 0
        Me.btnCommunicationStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCommunicationStatus.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCommunicationStatus.ForeColor = System.Drawing.Color.Black
        Me.btnCommunicationStatus.Location = New System.Drawing.Point(70, 108)
        Me.btnCommunicationStatus.MessageBoxText = Nothing
        Me.btnCommunicationStatus.Name = "btnCommunicationStatus"
        Me.btnCommunicationStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnCommunicationStatus.OffText = "Disabled"
        Me.btnCommunicationStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreenDown
        Me.btnCommunicationStatus.OnText = "Communicating"
        Me.btnCommunicationStatus.Size = New System.Drawing.Size(232, 43)
        Me.btnCommunicationStatus.TabIndex = 0
        Me.btnCommunicationStatus.Text = "Disabled"
        Me.btnCommunicationStatus.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellowDown
        Me.btnCommunicationStatus.UnKnownText = "Waiting Host"
        Me.btnCommunicationStatus.UseVisualStyleBackColor = True
        Me.btnCommunicationStatus.ValueToBeSend = "On"
        '
        'btnDisable
        '
        Me.btnDisable.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDisable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDisable.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnDisable.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnDisable.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDisable.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDisable.FlatAppearance.BorderSize = 0
        Me.btnDisable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisable.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisable.ForeColor = System.Drawing.Color.Black
        Me.btnDisable.Location = New System.Drawing.Point(191, 47)
        Me.btnDisable.MessageBoxText = Nothing
        Me.btnDisable.Name = "btnDisable"
        Me.btnDisable.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDisable.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDisable.Size = New System.Drawing.Size(160, 43)
        Me.btnDisable.TabIndex = 0
        Me.btnDisable.Text = "DisConnect"
        Me.btnDisable.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnDisable.UseClickedEventInForm = True
        Me.btnDisable.UseVisualStyleBackColor = True
        Me.btnDisable.ValueToBeSend = "On"
        '
        'btnEnable
        '
        Me.btnEnable.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnEnable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEnable.Clickable = True
        Me.btnEnable.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnEnable.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnEnable.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnable.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnEnable.FlatAppearance.BorderSize = 0
        Me.btnEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnable.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnable.ForeColor = System.Drawing.Color.Black
        Me.btnEnable.Location = New System.Drawing.Point(10, 47)
        Me.btnEnable.MessageBoxText = Nothing
        Me.btnEnable.Name = "btnEnable"
        Me.btnEnable.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnEnable.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnEnable.Size = New System.Drawing.Size(160, 43)
        Me.btnEnable.TabIndex = 0
        Me.btnEnable.Text = "Connect"
        Me.btnEnable.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnEnable.UseClickedEventInForm = True
        Me.btnEnable.UseVisualStyleBackColor = True
        Me.btnEnable.ValueToBeSend = "On"
        '
        'cbOnlineLocal
        '
        Me.cbOnlineLocal.AutoSize = True
        Me.cbOnlineLocal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbOnlineLocal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbOnlineLocal.Location = New System.Drawing.Point(10, 92)
        Me.cbOnlineLocal.Name = "cbOnlineLocal"
        Me.cbOnlineLocal.Size = New System.Drawing.Size(104, 23)
        Me.cbOnlineLocal.TabIndex = 19
        Me.cbOnlineLocal.Text = "Online Local"
        Me.cbOnlineLocal.UseVisualStyleBackColor = True
        '
        'cbOnlineRemote
        '
        Me.cbOnlineRemote.AutoSize = True
        Me.cbOnlineRemote.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbOnlineRemote.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbOnlineRemote.Location = New System.Drawing.Point(131, 92)
        Me.cbOnlineRemote.Name = "cbOnlineRemote"
        Me.cbOnlineRemote.Size = New System.Drawing.Size(117, 23)
        Me.cbOnlineRemote.TabIndex = 20
        Me.cbOnlineRemote.Text = "Online Remote"
        Me.cbOnlineRemote.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Location = New System.Drawing.Point(8, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(1261, 8)
        Me.Label5.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label13.Location = New System.Drawing.Point(0, 741)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(1280, 9)
        Me.Label13.TabIndex = 11
        '
        'UploadDownloadTimer
        '
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(8, 166)
        Me.Label7.TabIndex = 11
        '
        'pnlTerminal
        '
        Me.pnlTerminal.BackColor = System.Drawing.Color.Transparent
        Me.pnlTerminal.Controls.Add(Me.Panel5)
        Me.pnlTerminal.Controls.Add(Me.Label10)
        Me.pnlTerminal.Controls.Add(Me.Panel4)
        Me.pnlTerminal.Controls.Add(Me.Label9)
        Me.pnlTerminal.Controls.Add(Me.Panel3)
        Me.pnlTerminal.Controls.Add(Me.Label7)
        Me.pnlTerminal.Location = New System.Drawing.Point(11, 73)
        Me.pnlTerminal.Name = "pnlTerminal"
        Me.pnlTerminal.Size = New System.Drawing.Size(1262, 166)
        Me.pnlTerminal.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label10.Location = New System.Drawing.Point(635, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(8, 166)
        Me.Label10.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label9.Location = New System.Drawing.Point(263, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(8, 166)
        Me.Label9.TabIndex = 13
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.cbOnlineRemote)
        Me.Panel3.Controls.Add(Me.cbOnlineLocal)
        Me.Panel3.Controls.Add(Me.PictureBox9)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(8, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(255, 166)
        Me.Panel3.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(0, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(253, 38)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "  Default Start-Up Online State"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox9
        '
        Me.PictureBox9.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Header
        Me.PictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox9.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox9.Location = New System.Drawing.Point(0, 28)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(253, 3)
        Me.PictureBox9.TabIndex = 18
        Me.PictureBox9.TabStop = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(253, 28)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Configuration"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SecsGemPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.pnlTerminal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblPadding)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label13)
        Me.DoubleBuffered = True
        Me.Name = "SecsGemPanel"
        Me.Size = New System.Drawing.Size(1280, 750)
        Me.Panel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTerminal.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblPadding As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnCommunicationStatus As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnDisable As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnEnable As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnOnlineRemote As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnAttemptOnline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnOnlineLocal As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnHostOffline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnUploadProcess As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents lstPP As System.Windows.Forms.ListBox
    Friend WithEvents btnDownloadProcess As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtPPDownload As AVP_Robot_Project.SL_Textbox
    Friend WithEvents rbnRecipe As System.Windows.Forms.RadioButton
    Friend WithEvents rbnWaferFlow As System.Windows.Forms.RadioButton
    Friend WithEvents rbnSequence As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents UploadDownloadTimer As System.Windows.Forms.Timer
    Friend WithEvents cbOnlineLocal As System.Windows.Forms.RadioButton
    Friend WithEvents cbOnlineRemote As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnGoOnlineLocal As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnOffline As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents btnGoOnlineRemote As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtMessageToHost As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnClearfromHost As AVP_Robot_Project.SL_CustomButton
    Friend WithEvents txtMessageFromHost As AVP_Robot_Project.SL_Textbox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents pnlTerminal As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents btnChatPopUp As System.Windows.Forms.Button
    Friend WithEvents chkUsePopUpTerminal As System.Windows.Forms.CheckBox

End Class
