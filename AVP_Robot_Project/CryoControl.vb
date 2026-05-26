Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Public Class CryoControl
#Region "Class Constants & Variables"
    Public Enum DisplayStyle
        [Left] = 0
        [Right] = 1
    End Enum

    Private m_intDisplayStyle As DisplayStyle
    Private m_blnButtonVisible As Boolean
    Private Const STRING_OFF As String = "Off"
    Private Const STRING_ON As String = "On"
    Private m_blnIsOnline As Boolean = False
    Private m_isOn As Boolean = False
    Private m_isRegen As Boolean = False
    Private m_blnEnableDisableForm As Boolean
#End Region

#Region "Public Properties"
    '  ''' <author>
    '  '''    	<name> Ngo Cao Dinh </name>
    '  '''    	<date> 2008-08-26</date>
    '  ''' </author>    
    '  ''' <summary>
    '  ''' Get or set value to align all child controls inside this user control
    '  ''' </summary>
    '  ''' <value></value>
    '  ''' <returns></returns>
    '  ''' <remarks></remarks>
    '  Public Property AlignStyle() As DisplayStyle
    '      Get
    '          AlignStyle = m_intDisplayStyle
    '      End Get
    'Set(ByVal value As DisplayStyle)
    '	Try
    '		If (value <> m_intDisplayStyle) Then
    '			m_intDisplayStyle = value
    '			Me.PositionControls()
    '		End If
    '	Catch ex As Exception
    '              AVPLib.Log.avpLogger.Error(ex.ToString())
    '          End Try
    '      End Set
    '  End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-28</date>
    ''' </author>    
    ''' <summary>
    ''' Get or set value to align all child controls inside this user control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ButtonVisible() As Boolean
        Get
            Return m_blnButtonVisible
        End Get
        Set(ByVal value As Boolean)
            Try
                If (value <> m_blnButtonVisible) Then
                    m_blnButtonVisible = value
                    Me.PositionControls()
                    btnOn.Visible = m_blnButtonVisible
                    btnRegen.Visible = m_blnButtonVisible
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnOn.Enabled = Not m_blnIsOnline
            btnRegen.Enabled = Not m_blnIsOnline
        End Set
    End Property

    Public Property Is_CryO_On_Status() As Boolean
        Get
            Return m_isOn
        End Get
        Set(ByVal value As Boolean)
            m_isOn = value
        End Set
    End Property

    Public Property Is_CryO_Regen_Status() As Boolean
        Get
            Return m_isRegen
        End Get
        Set(ByVal value As Boolean)
            m_isRegen = value
        End Set
    End Property

#End Region

#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Initiate cryo control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_blnButtonVisible = btnOn.Visible
        m_intDisplayStyle = DisplayStyle.Left
        'Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.HeaderPanel_Red
        Me.lblT1.Text = Me.txtT1.Text
        Me.lblT2.Text = Me.txtT2.Text
    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbT1 As New StatusTextBox(txtT1)
            Dim stbT2 As New StatusTextBox(txtT2)
            Dim scbOn As New StatusColorButton(btnOn)
            'Dim sclComunicationLED As New StatusColorLabel(lblComunicationLED)
            scbOn.OnText = STRING_OFF
            scbOn.OffText = STRING_ON
            Dim scbRegen As New StatusColorButton(btnRegen)
            Dim sbtComStatus As New StatusIGCGButton(btnComStatus)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbT1)
            m_stoStatusObject.AddChild(stbT2)
            m_stoStatusObject.AddChild(scbOn)
            m_stoStatusObject.AddChild(scbRegen)
            'm_stoStatusObject.AddChild(sclComunicationLED)
            m_stoStatusObject.AddChild(sbtComStatus)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-28</date>
    ''' </author>    
    ''' <summary>
    ''' Positioning all child controls inside this user control
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PositionControls()
        Try
            If (m_intDisplayStyle = DisplayStyle.Left) Then
                If (m_blnButtonVisible) Then
                    Me.AlignLeftButtonVisible()
                Else
                    Me.AlignLeftButtonInvisible()
                End If
            Else
                If (m_blnButtonVisible) Then
                    Me.AlignRightButtonVisible()
                Else
                    Me.AlignRightButtonInvisible()
                End If
            End If
            Me.Refresh()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-28</date>
    ''' </author>    
    ''' <summary>
    ''' Aligning all child controls inside this user control to left side and buttons visible
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AlignLeftButtonVisible()
        Try
            Me.lblHeader.Dock = DockStyle.Left
            Me.lblHeader.TextAlign = ContentAlignment.MiddleLeft

            Me.pnlCom.Dock = DockStyle.Right

            Me.Label1.Left = 1
            Me.Label1.TextAlign = ContentAlignment.MiddleRight

            Me.btnComStatus.Left = Me.pnlCom.Width - Me.btnComStatus.Width - 6

            Me.Size = New System.Drawing.Size(190, 88)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-28</date>
    ''' </author>    
    ''' <summary>
    ''' Aligning all child controls inside this user control to left side and buttons invisible
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AlignLeftButtonInvisible()
        Try
            Me.lblHeader.Dock = DockStyle.Left
            Me.lblHeader.TextAlign = ContentAlignment.MiddleLeft

            Me.pnlCom.Dock = DockStyle.Right

            Me.Label1.Left = 1
            Me.Label1.TextAlign = ContentAlignment.MiddleRight

            Me.btnComStatus.Left = Me.pnlCom.Width - Me.btnComStatus.Width - 6

            Me.Size = New System.Drawing.Size(190, 57)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-28</date>
    ''' </author>    
    ''' <summary>
    ''' Aligning all child controls inside this user control to right side and buttons visible
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AlignRightButtonVisible()
        Try
            Me.lblHeader.Dock = DockStyle.Right
            Me.lblHeader.TextAlign = ContentAlignment.MiddleRight

            Me.pnlCom.Dock = DockStyle.Left

            Me.btnComStatus.Left = 6
            Me.Label1.TextAlign = ContentAlignment.MiddleLeft
            Me.Label1.Left = btnComStatus.Right

            Me.Size = New System.Drawing.Size(190, 88)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-28</date>
    ''' </author>    
    ''' <summary>
    ''' Aligning all child controls inside this user control to right side and buttons invisible
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AlignRightButtonInvisible()
        Try
            Me.lblHeader.Dock = DockStyle.Right
            Me.lblHeader.TextAlign = ContentAlignment.MiddleRight

            Me.pnlCom.Dock = DockStyle.Left

            Me.btnComStatus.Left = 6
            Me.Label1.TextAlign = ContentAlignment.MiddleLeft
            Me.Label1.Left = btnComStatus.Right

            Me.Size = New System.Drawing.Size(190, 57)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on On button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Sub btnOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOn.Click
        AVPLib.Log.guiLogger.Info("Enter btnOn_Click")
        Try
            Dim strMessageText As String
            If (btnOn.Tag = STRING_ON) Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("TransferPumpStatusOff"), Me.Text)
                If (Utils.ShowAVPMessageBox(strMessageText, Me.Text, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(btnOn.Name, STRING_OFF)
                    Utils.LogUserEvent("Clicked CRYO button to set off", "TM Screen")
                End If
            ElseIf (btnOn.Tag = STRING_OFF) Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("TransferPumpStatusOn"), Me.Text)
                If (Utils.ShowAVPMessageBox(strMessageText, Me.Text, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(btnOn.Name, STRING_ON)
                    Utils.LogUserEvent("Clicked CRYO button to set on", "TM Screen")
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOn_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on Regen button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Sub btnRegen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegen.Click
        AVPLib.Log.guiLogger.Info("Enter btnRegen_Click")
        Try
            Dim strMessageText As String
            If Utils.CheckHivacValveOpen_BeforeCryo(Me.Name) Then
                Exit Sub
            End If
            'Green -> Regen is running -> Send Abort Regen
            'Blue  -> Regen isnot Running (Aborted or Completed) -> Send Start Regen
            If (btnRegen.Tag = STRING_ON) Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("TransferStartRegen"), Me.Text)
                If (Utils.ShowAVPMessageBox(strMessageText, Me.Text, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(btnRegen.Name, STRING_OFF)
                    Utils.LogUserEvent("Clicked Cryo REGEN button to set off", "TM Screen")
                End If
            ElseIf (btnRegen.Tag = STRING_OFF) Then
                'is check Other Cryo Is In Regen
                Dim strResult As String = Utils.CheckOtherCryoIsInRegen(Me.Name)
                If Not String.IsNullOrEmpty(strResult) Then
                    Utils.ShowAVPMessageBox(strResult, Me.Text, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                    Exit Try
                End If
                Dim loadlockA As AVPLib.DataManagerment.LoadLock = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                If loadlockA IsNot Nothing Then
                    strResult = loadlockA.CheckCondition2StartRegen()
                    If Not String.IsNullOrEmpty(strResult) Then
                        Utils.ShowAVPMessageBox(strResult, Me.Text, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                        Exit Try
                    End If
                End If

                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("TransferAbortRegen"), Me.Text)
                If (Utils.ShowAVPMessageBox(strMessageText, Me.Text, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(btnRegen.Name, STRING_ON)
                    Utils.LogUserEvent("Clicked Cryo REGEN button to set on", "TM Screen")
                End If
                ' End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnRegen_Click")
    End Sub

    Friend Sub btnFastRegen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFastRegen.Click
        AVPLib.Log.guiLogger.Info("Enter btnFastRegen_Click")
        Try
            Dim strMessageText As String = String.Format(AVPLib.ContainerData.GetMessageText("TransferStartFastRegen"), Me.Text)
            If Utils.CheckHivacValveOpen_BeforeCryo(Me.Name) Then
                Exit Sub
            End If
            'is check Other Cryo Is In Regen
            Dim strResult As String = Utils.CheckOtherCryoIsInRegen(Me.Name)
            If Not String.IsNullOrEmpty(strResult) Then
                Utils.ShowAVPMessageBox(strResult, Me.Text, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                Exit Try
            End If
            Dim loadlockA As AVPLib.DataManagerment.LoadLock = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
            If loadlockA IsNot Nothing Then
                strResult = loadlockA.CheckCondition2StartRegen()
                If Not String.IsNullOrEmpty(strResult) Then
                    Utils.ShowAVPMessageBox(strResult, Me.Text, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                    Exit Try
                End If
            End If

            If (Utils.ShowAVPMessageBox(strMessageText, Me.Text, MessageBoxIcon.Question) = DialogResult.OK) Then
                m_stoStatusObject.RequestStatus(btnFastRegen.Name, STRING_ON)
                Utils.LogUserEvent("Clicked CRYO FAST REGEN button", "TM Screen")
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnFastRegen_Click")
    End Sub


    Private Sub btn_BackgroundImageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegen.BackgroundImageChanged, btnOn.BackgroundImageChanged
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            AVPLib.Log.guiLogger.Info("Enter btn_BackgroundImageChanged")
            Try
                Dim btn As Button = CType(sender, Button)
                If btn.Name = btnOn.Name Then
                    IIf(btn.Tag = STRING_ON, Is_CryO_On_Status = True, Is_CryO_On_Status = False)
                ElseIf btn.Name = btnRegen.Name Then
                    IIf(btn.Tag = STRING_ON, Is_CryO_Regen_Status = True, Is_CryO_Regen_Status = False)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.guiLogger.Info("Leave btn_BackgroundImageChanged")
        End If
    End Sub

#End Region
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-02-03</date>
    ''' </author>
    ''' <summary>
    ''' txt_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT2.TextChanged
        AVPLib.Log.guiLogger.Info("Enter txt_TextChanged")
        Try
            Dim text As TextBox = CType(sender, TextBox)
            If Not text.Text.Contains("K") Then
                text.Text = Utils.SignificantFigures(text.Text)
            End If
            lblT2.Text = text.Text
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txt_TextChanged")
    End Sub

    Private Sub txtT1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT1.TextChanged
        lblT1.Text = txtT1.Text
    End Sub

    Private Sub CryoControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblHeader.Text = Me.Text
        btnOn.ForeColor = Color.Black 'Color.FromArgb(142, 143, 144)
        btnRegen.ForeColor = Color.Black 'Color.FromArgb(142, 143, 144)
        btnOn.Tag = STRING_OFF
        btnRegen.Tag = STRING_OFF
    End Sub

    
    Private Sub lblComunicationLED_BackColorChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblComunicationLED.BackColorChanged

        Dim destinationColor As Color = Color.FromName(MessageMapper.GetColorValue(COMMUNICATION_COLOR_OFFLINE))
        If lblComunicationLED.BackColor = destinationColor Then
            Me.btnOn.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
            Me.btnOn.Tag = STRING_OFF
            Me.btnRegen.Tag = STRING_OFF
            Me.btnOn.Text = STRING_OFF
            Me.btnRegen.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        End If
    End Sub

    ''' <author>
    '''     <name> Dy Do </name>
    '''     <date> 2015-06-04 </date>
    ''' </author>
    ''' <summary>
    ''' Handles communication status changed
    ''' </summary>
    Private Sub btnComStatus_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComStatus.StatusChange
        If btnComStatus.Status = DisplayStatus.Off Then
            Me.btnOn.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
            Me.btnOn.Tag = STRING_OFF
            Me.btnRegen.Tag = STRING_OFF
            Me.btnOn.Text = STRING_OFF
            Me.btnRegen.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click, lblComunicationLED.Click, lblHeader.Click, btnComStatus.Click, Label3.Click, lblT1.Click, lblT2.Click, Panel2.Click, pnlCom.Click, Panel1.Click
        'in CX5, don't use Cryo Pop Panel
        Try

            If Not m_blnEnableDisableForm Then
                Exit Sub
            End If

            If Me.Text.Contains(AVPLib.ConstEnum.LLA_STR) Then
                ContainerForm.CassettesPanel.LLACryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                ContainerForm.CassettesPanel.LLACryoPopUpPanel.ShowDialog(AVPRobotMain)
            ElseIf Me.Text.Contains(AVPLib.ConstEnum.TM_STR) Then
                ContainerForm.CassettesPanel.TMCryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                ContainerForm.CassettesPanel.TMCryoPopUpPanel.ShowDialog(AVPRobotMain)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-05-11 </date>
    ''' </author>
    ''' <summary>
    ''' Paint Border for panel
    ''' </summary>
    Private Sub Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        Utils.PaintBorder(sender, e)
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' DisableForm
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActiveForm(ByVal enable As Boolean)
        Try
            m_blnEnableDisableForm = enable
            Me.Panel1.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.Panel1.Enabled = enable
            Me.btnFastRegen.Enabled = enable
            Me.btnOn.Enabled = enable
            Me.btnRegen.Enabled = enable
            Me.Panel2.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.lblHeader.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.Label1.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.pnlCom.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.Panel1.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.btnComStatus.Enabled = enable
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
