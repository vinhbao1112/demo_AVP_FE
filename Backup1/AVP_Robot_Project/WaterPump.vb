Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Public Class WaterPump
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
#End Region

#Region "Public Properties"
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
#End Region

#Region "Constructor & Destructor"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_blnButtonVisible = btnOn.Visible
        m_intDisplayStyle = DisplayStyle.Left
        'Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.HeaderPanel_Red
        Me.lblT.Text = Me.txtT.Text
        'dat cao: init background image button
        Me.btnOn.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnRegen.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
    End Sub
#End Region

#Region "Protected method"
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbT As New StatusTextBox(txtT)
            Dim scbOn As New StatusColorButton(btnOn)
            'Dim sclComunicationLED As New StatusColorLabel(lblComunicationLED)
            scbOn.OnText = STRING_OFF
            scbOn.OffText = STRING_ON
            Dim scbRegen As New StatusColorButton(btnRegen)
            Dim sbtComStatus As New StatusIGCGButton(btnComStatus)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbT)
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
    Friend Sub btnOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOn.Click
        AVPLib.Log.guiLogger.Info("Enter btnOn_Click")
        Try
            Dim strMessageText As String
            Dim strResult As String = String.Empty
            If (btnOn.Tag = STRING_ON) Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("TMWaterPumpStatusOff"), Me.Text)
                If (Utils.ShowAVPMessageBox(strMessageText, ConstEnum.TM_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    Utils.LogUserEvent("Clicked WATER PUMP button to set off", "TM Screen")
                    m_stoStatusObject.RequestStatus(btnOn.Name, STRING_OFF)
                End If
            ElseIf (btnOn.Tag = STRING_OFF) Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("TMWaterPumpStatusOn"), Me.Text)
                If (Utils.ShowAVPMessageBox(strMessageText, ConstEnum.TM_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    Utils.LogUserEvent("Clicked WATER PUMP button to set on", "TM Screen")
                    m_stoStatusObject.RequestStatus(btnOn.Name, STRING_ON)
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOn_Click")
    End Sub
    Friend Sub btnRegen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegen.Click
        AVPLib.Log.guiLogger.Info("Enter btnRegen_Click")
        Try
            Dim strMessageText As String
            'If Utils.CheckHivacValveOpen_BeforeCryo(Me.Name) Then
            '    Exit Sub
            'End If
            'Green -> Regen is running -> Send Abort Regen
            'Blue  -> Regen isnot Running (Aborted or Completed) -> Send Start Regen
            If (btnRegen.Tag = STRING_ON) Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("TransferStartRegen"), Me.Text)
                If (Utils.ShowAVPMessageBox(strMessageText, ConstEnum.TM_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    Utils.LogUserEvent("Clicked Water Pump REGEN button to set off", "TM Screen")
                    m_stoStatusObject.RequestStatus(btnRegen.Name, STRING_OFF)
                End If
            ElseIf (btnRegen.Tag = STRING_OFF) Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("TransferAbortRegen"), Me.Text)
                If (Utils.ShowAVPMessageBox(strMessageText, ConstEnum.TM_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    Utils.LogUserEvent("Clicked Water Pump REGEN button to set on", "TM Screen")
                    m_stoStatusObject.RequestStatus(btnRegen.Name, STRING_ON)
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

            If (Utils.ShowAVPMessageBox(strMessageText, ConstEnum.TM_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                Utils.LogUserEvent("Clicked Water Pump FAST REGEN button", "TM Screen")
                m_stoStatusObject.RequestStatus(btnFastRegen.Name, STRING_ON)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnFastRegen_Click")
    End Sub


#End Region
    Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT.TextChanged
        AVPLib.Log.guiLogger.Info("Enter txt_TextChanged")
        Try
            Dim text As TextBox = CType(sender, TextBox)
            If Not text.Text.Contains("K") Then
                text.Text = Utils.SignificantFigures(text.Text)
            End If
            lblT.Text = text.Text
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txt_TextChanged")
    End Sub


    Private Sub WaterPump_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    '''     <name> Hai Tran </name>
    '''     <date> 2015-01-26 </date>
    ''' </author>
    ''' <summary>
    ''' Handles communication status changed
    ''' </summary>
    Private Sub btnComStatus_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComStatus.StatusChange
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            If btnComStatus.Status = DisplayStatus.Off Then
                Me.btnOn.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
                Me.btnOn.Tag = STRING_OFF
                Me.btnRegen.Tag = STRING_OFF
                Me.btnOn.Text = STRING_OFF
                Me.btnRegen.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
            End If
        End If
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' Paint Border for panel
    ''' </summary>
    Private Sub Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        Utils.PaintBorder(sender, e)
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-16</date>
    ''' </author>
    ''' <summary>
    ''' DisableForm
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActiveForm(ByVal enable As Boolean)
        Try
            Me.btnComStatus.Enabled = enable
            Me.btnFastRegen.Enabled = enable
            Me.btnOn.Enabled = enable
            Me.btnRegen.Enabled = enable
            Me.Panel1.Enabled = enable
            Me.Panel2.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.lblT.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.Label2.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.pnlCom.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.Panel1.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
