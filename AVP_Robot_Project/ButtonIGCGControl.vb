Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports System.ComponentModel

Public Class ButtonIGCGControl
#Region "Class Constants & Variables"
    Public Enum DisplayStatus
        [Off] = 0
        [On] = 1
        [Error] = 2
        [Unknow] = 3
    End Enum
    Public Enum ButtonStyle
        [Vertical]
        [Horizontal]
    End Enum

    Private m_enmDisplayStatus As DisplayStatus
    Private m_imgOnImage As Image
    Private m_imgOffImage As Image
    Private m_imgUnknowImage As Image
    Private m_imgErrorImage As Image
    Private m_colorText_OnStatus As Color = Color.Black
    Private m_colorText_OffStatus As Color = Color.White
    Private m_colorText_UnknowStatus As Color = Color.Black
    Private m_colorText_ErrorStatus As Color = Color.White

    Private m_StyleButton As ButtonStyle = ButtonStyle.Horizontal
    Private m_strOnText As String = String.Empty
    Private m_strOffText As String = String.Empty
    Private m_strUnknownText As String = String.Empty
    Private m_strErrorText As String = String.Empty
    Private m_strTextValue As String = String.Empty
    Private m_TextLocIsFix As Boolean = True
    Private m_textlocation As Point = New Point(0, 0)
    Public Event StatusChange(ByVal sender As Object, ByVal e As System.EventArgs)
    Private m_blnIsTextColorWhiteWhenOnlineAndLogout As Boolean = False


#End Region

#Region "Public Properties"
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Color), "Black")> _
    Public Property ColorText_OnStatus() As Color
        Get
            Return m_colorText_OnStatus
        End Get
        Set(ByVal value As Color)
            m_colorText_OnStatus = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Color), "White")> _
    Public Property ColorText_OffStatus() As Color
        Get
            Return m_colorText_OffStatus
        End Get
        Set(ByVal value As Color)
            m_colorText_OffStatus = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Color), "Black")> _
    Public Property ColorText_UnknowStatus() As Color
        Get
            Return m_colorText_UnknowStatus
        End Get
        Set(ByVal value As Color)
            m_colorText_UnknowStatus = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Color), "White")> _
    Public Property ColorText_ErrorStatus() As Color
        Get
            Return m_colorText_ErrorStatus
        End Get
        Set(ByVal value As Color)
            m_colorText_ErrorStatus = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property ErrorText() As String
        Get
            Return m_strErrorText
        End Get
        Set(ByVal value As String)
            m_strErrorText = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property UnKnownText() As String
        Get
            Return m_strUnknownText
        End Get
        Set(ByVal value As String)
            m_strUnknownText = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property OffText() As String
        Get
            Return m_strOffText
        End Get
        Set(ByVal value As String)
            m_strOffText = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property OnText() As String
        Get
            Return m_strOnText
        End Get
        Set(ByVal value As String)
            m_strOnText = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Set of get display status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(ButtonStyle), "Horizontal")> _
    Public Property StyleOfButton() As ButtonStyle
        Get
            Return m_StyleButton
        End Get
        Set(ByVal value As ButtonStyle)
            m_StyleButton = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Set of get display status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Property Status() As DisplayStatus
        Get
            Return m_enmDisplayStatus
        End Get
        Set(ByVal value As DisplayStatus)
            Try
                ChangeBackground(value)
                m_enmDisplayStatus = value
                RaiseEvent StatusChange(Me, Nothing)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Get or set image of On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OnImage() As Image
        Get
            Return m_imgOnImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgOnImage = value
                If m_enmDisplayStatus = DisplayStatus.On Then
                    ChangeBackground(DisplayStatus.On)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Get or set image of Off Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OffImage() As Image
        Get
            Return m_imgOffImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgOffImage = value
                If m_enmDisplayStatus = DisplayStatus.Off Then
                    ChangeBackground(DisplayStatus.Off)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Tran Ngoc Khiet</name>
    '''    	<date> 2009-09-29</date>
    ''' </author>
    ''' <summary>
    ''' Get or set image of yellow Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UnknownImage() As Image
        Get
            Return m_imgUnknowImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgUnknowImage = value
                If m_enmDisplayStatus = DisplayStatus.Unknow Then
                    ChangeBackground(DisplayStatus.Unknow)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Tran Ngoc Khiet</name>
    '''    	<date> 2009-09-29</date>
    ''' </author>
    ''' <summary>
    ''' Get or set image of error Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ErrorImage() As Image
        Get
            Return m_imgErrorImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgErrorImage = value
                If m_enmDisplayStatus = DisplayStatus.Error Then
                    ChangeBackground(DisplayStatus.Error)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2014-07-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set image of error Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property TextValue() As String
        Get
            Return m_strTextValue
        End Get
        Set(ByVal value As String)
            Try
                m_strTextValue = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property


    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-07 </date>
    ''' <author>
    ''' <summary>
    ''' Get or set value indicate whether or not use text location
    ''' </summary>
    Public Property TextLocIsFix() As Boolean
        Get
            Return m_TextLocIsFix
        End Get
        Set(ByVal value As Boolean)
            m_TextLocIsFix = value
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-07 </date>
    ''' <author>
    ''' <summary>
    ''' Text location
    ''' </summary>
    Public Property TextLocation() As Point
        Get
            Return m_textlocation
        End Get
        Set(ByVal value As Point)
            m_textlocation = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran</name>
    '''    	<date> 2017-11-1</date>
    ''' </author>
    ''' <summary>
    ''' Is text color is white when online and logout.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsTextColorWhiteWhenOnlineAndLogout() As Boolean
        Get
            Return m_blnIsTextColorWhiteWhenOnlineAndLogout
        End Get
        Set(ByVal value As Boolean)
            m_blnIsTextColorWhiteWhenOnlineAndLogout = value
        End Set
    End Property

#End Region


#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Initate default value of member variables
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Try
            m_enmDisplayStatus = DisplayStatus.Off
            ' Me.LoadDefaultButtonPicture()
            'MyBase.Image = m_imgOffImage
            ' MyBase.BackgroundImage = m_imgOffImage
            ' MyBase.Size = New Point(20, 20) 'm_imgOffImage.Size
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Load valve picture
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadDefaultButtonPicture()
        Try
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ButtonIGCGControl))
            m_imgOnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
            m_imgOffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonBlue
            m_imgUnknowImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonYellow
            m_imgErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub ChangeStatus_Text_BaseOn(ByVal value As String)
        Select Case value
            Case STR_ON

            Case STR_OFF
                Select Case Me.Name
                    Case "btnHivacValve"
                        If CInt(value) = 0 Then
                            Status = ButtonIGCGControl.DisplayStatus.Off
                            Text = UCase(STRING_CLOSE)
                        ElseIf CInt(value) = 100 Then
                            Status = ButtonIGCGControl.DisplayStatus.On
                            Text = UCase(STRING_OPEN)
                        Else
                            Status = ButtonIGCGControl.DisplayStatus.Unknow
                            Text = value
                        End If
                    Case "btnRegen", "btnShutter"
                        Status = ButtonIGCGControl.DisplayStatus.Unknow
                    Case "ibsHivacButton"
                        Text = "CLOSE HIVAC"
                    Case BTN_AUTO_BEAM
                        Text = ENABLE_AUTO_BEAM
                    Case "btnReConnect"
                        Enabled = True
                        Status = ButtonIGCGControl.DisplayStatus.Error
                    Case "btnRecall", "btnStore"
                        Enabled = True
                    Case "btnStart", "btnPause", "btnAbort"  'for Run Recipe
                        Enabled = False
                End Select

            Case Else
                Select Case Me.Name
                    Case "btnHivacValve"
                        If CInt(value) = 0 Then
                            Status = ButtonIGCGControl.DisplayStatus.Off
                            Text = UCase(STRING_CLOSE)
                        ElseIf CInt(value) = 100 Then
                            Status = ButtonIGCGControl.DisplayStatus.On
                            Text = UCase(STRING_OPEN)
                        Else
                            Status = ButtonIGCGControl.DisplayStatus.Unknow
                            Text = value
                        End If
                    Case "btnRegen", "btnShutter"
                        Status = ButtonIGCGControl.DisplayStatus.Unknow
                    Case "ibsHivacButton"
                        Text = "HIVAC UNKNOWN"
                        Status = ButtonIGCGControl.DisplayStatus.Unknow
                        ForeColor = Color.Black
                    Case "btnStart"
                        Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                        If objPanel.ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                            Dim chamberObj As PVDPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                            chamberObj.RunRecipe.btnPause.Enabled = True
                            chamberObj.RunRecipe.btnAbort.Enabled = True
                            chamberObj.RunRecipe.btnPause.Text = "Pause"
                            If value = AVPLib.ConfigurationValues.DEVICE_STATUS_OPEN Then
                                Text = "Stop"
                                Enabled = True
                                chamberObj.OnStartProcessing() ''reset editbox to empty
                            ElseIf value = AVPLib.ConfigurationValues.DEVICE_STATUS_CLOSED Then
                                Text = "Start"
                                Enabled = True
                            End If
                        End If

                    Case "btnPause"
                        Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                        If objPanel.ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                            Dim chamberObj As PVDPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                            chamberObj.RunRecipe.btnStart.Enabled = True
                            chamberObj.RunRecipe.btnAbort.Enabled = True
                            If value = AVPLib.ConfigurationValues.DEVICE_STATUS_PAUSE Then
                                Text = "Pause"
                                Enabled = True
                            ElseIf value = AVPLib.ConfigurationValues.DEVICE_STATUS_RESUMING Then
                                Text = "Resume"
                                chamberObj.RunRecipe.btnStart.Text = "Stop"
                                Enabled = True
                            End If
                        End If

                    Case "HeaderStatus"
                        If Me.Parent.Name.Contains("lpcLoadLock") And value = "Cycling" Then
                            ForeColor = Color.Red
                            Text = Tag & value
                        ElseIf Me.Parent.Name.Contains("lpcLoadLock") And value = "UnCycling" Then
                            ForeColor = Color.White
                            Text = Tag
                        End If
                    Case "Header"
                        Select Case value
                            Case "-1"
                                Status = ButtonIGCGControl.DisplayStatus.Error
                                'for case Chamber/LoadLock Online -> change status of Chamber/LoadLock in Process Screen
                            Case UCase(STRING_ONLINE)
                                Status = ButtonIGCGControl.DisplayStatus.On
                                If Me.Parent.Name.Contains("cbcChamber") Then
                                    Text = GetTitleOfHeader() & "-" & UCase(STRING_ONLINE)
                                End If
                            Case UCase(STRING_OFFLINE)
                                Status = ButtonIGCGControl.DisplayStatus.Off
                                If Me.Parent.Name.Contains("cbcChamber") Then
                                    Text = GetTitleOfHeader() & "-" & UCase(STRING_OFFLINE)
                                End If
                            Case UCase(STRING_MAINTENANCE)
                                Status = ButtonIGCGControl.DisplayStatus.Off
                                If Me.Parent.Name.Contains("cbcChamber") Then
                                    Text = GetTitleOfHeader() & "-" & UCase(STRING_MAINTENANCE)
                                End If
                        End Select
                End Select
        End Select
    End Sub

    Private Function GetTitleOfHeader() As String
        Dim sTag As String = String.Empty
        Try
            Select Case Me.Parent.Name
                Case "cbcChamber1" 'get status button from CassettesPanel to display value
                    sTag = ContainerForm.ProcessPanel.cbcChamber1.Tag
                Case "cbcChamber2"
                    sTag = ContainerForm.ProcessPanel.cbcChamber2.Tag
                Case "cbcChamber3"
                    sTag = ContainerForm.ProcessPanel.cbcChamber3.Tag
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return sTag
    End Function
#End Region

    Private Sub ButtonIGCGControl_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        Dim string_format As New StringFormat

        Dim strText As String = Me.Text
        If String.IsNullOrEmpty(strText) Then
            strText = TextValue
        End If

        If StyleOfButton = ButtonStyle.Vertical Then
            string_format.Alignment = StringAlignment.Center
            string_format.LineAlignment = StringAlignment.Center
            string_format.FormatFlags = _
                StringFormatFlags.DirectionVertical Or _
                StringFormatFlags.DirectionRightToLeft

            If Not Me.TextLocIsFix Then
            If Me.Status = DisplayStatus.On Then
                g.DrawImage(m_imgOnImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_OnStatus), Me.TextLocation.X, Me.TextLocation.Y, string_format)
            ElseIf Me.Status = DisplayStatus.Off Then
                g.DrawImage(m_imgOffImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_OffStatus), Me.TextLocation.X, Me.TextLocation.Y, string_format)
            ElseIf Me.Status = DisplayStatus.Unknow Then
                g.DrawImage(m_imgUnknowImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_UnknowStatus), Me.TextLocation.X, Me.TextLocation.Y, string_format)
            ElseIf Me.Status = DisplayStatus.Error Then
                g.DrawImage(m_imgErrorImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_ErrorStatus), Me.TextLocation.X, Me.TextLocation.Y, string_format)
                End If
            Else
                If Me.Status = DisplayStatus.On Then
                    g.DrawImage(m_imgOnImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_OnStatus), Me.Width / 2 - 1, Me.Height / 2, string_format)
                ElseIf Me.Status = DisplayStatus.Off Then
                    g.DrawImage(m_imgOffImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_OffStatus), Me.Width / 2 - 1, Me.Height / 2, string_format)
                ElseIf Me.Status = DisplayStatus.Unknow Then
                    g.DrawImage(m_imgUnknowImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_UnknowStatus), Me.Width / 2 - 1, Me.Height / 2, string_format)
                ElseIf Me.Status = DisplayStatus.Error Then
                    g.DrawImage(m_imgErrorImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_ErrorStatus), Me.Width / 2 - 1, Me.Height / 2, string_format)
                End If
            End If
        Else
            If Not Me.TextLocIsFix Then
                If Me.Status = DisplayStatus.On Then
                    g.DrawImage(m_imgOnImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_OnStatus), Me.TextLocation.X, Me.TextLocation.Y)
                ElseIf Me.Status = DisplayStatus.Off Then
                    g.DrawImage(m_imgOffImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_OffStatus), Me.TextLocation.X, Me.TextLocation.Y)
                ElseIf Me.Status = DisplayStatus.Unknow Then
                    g.DrawImage(m_imgUnknowImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_UnknowStatus), Me.TextLocation.X, Me.TextLocation.Y)
                ElseIf Me.Status = DisplayStatus.Error Then
                    g.DrawImage(m_imgErrorImage, 0, 0, Me.Width, Me.Height)
                    g.DrawString(strText, Me.Font, New SolidBrush(ColorText_ErrorStatus), Me.TextLocation.X, Me.TextLocation.Y)
            End If
        Else
            If Not Me.Enabled AndAlso Not String.IsNullOrEmpty(strText) Then
                If Me.BackgroundImageLayout = ImageLayout.Stretch Then
                    If Me.Status = DisplayStatus.On Then
                        g.DrawImage(m_imgOnImage, 0, 0, Me.Width, Me.Height)
                    ElseIf Me.Status = DisplayStatus.Off Then
                        g.DrawImage(m_imgOffImage, 0, 0, Me.Width, Me.Height)
                    ElseIf Me.Status = DisplayStatus.Unknow Then
                        g.DrawImage(m_imgUnknowImage, 0, 0, Me.Width, Me.Height)
                    ElseIf Me.Status = DisplayStatus.Error Then
                        g.DrawImage(m_imgErrorImage, 0, 0, Me.Width, Me.Height)
                    End If
                End If
                Dim format As TextFormatFlags = TextFormatFlags.WordBreak Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter

                    If IsTextColorWhiteWhenOnlineAndLogout Then
                        TextRenderer.DrawText(e.Graphics, strText, Me.Font, Me.ClientRectangle, Color.White, format)
                    Else
                TextRenderer.DrawText(e.Graphics, strText, Me.Font, Me.ClientRectangle, SystemColors.ControlDark, format)
            End If

                End If
            End If
        End If
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-02 </date>
    ''' </author>
    ''' <summary>
    ''' Change background of Image base on specific status
    ''' </summary>
    Private Sub ChangeBackground(ByVal status As DisplayStatus)
        If status = DisplayStatus.Off Then
            'MyBase.Image = m_imgOffImage
            MyBase.BackgroundImage = m_imgOffImage
            Me.ForeColor = ColorText_OffStatus
            If Not (m_strOffText = "") Then
                Me.Text = m_strOffText
            End If
        ElseIf status = DisplayStatus.On Then
            'MyBase.Image = m_imgOnImage
            MyBase.BackgroundImage = m_imgOnImage
            Me.ForeColor = ColorText_OnStatus
            If Not (m_strOnText = "") Then
                Me.Text = m_strOnText
            End If
        ElseIf status = DisplayStatus.Error Then
            MyBase.BackgroundImage = m_imgErrorImage
            Me.ForeColor = ColorText_ErrorStatus
            If Not (m_strErrorText = "") Then
                Me.Text = m_strErrorText
            End If
        Else
            MyBase.BackgroundImage = m_imgUnknowImage
            Me.ForeColor = ColorText_UnknowStatus
            If Not (m_strUnknownText = "") Then
                Me.Text = m_strUnknownText
            End If
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-28 </date>
    ''' </author>
    ''' <summary>
    ''' Convert specific value to ButtonIGCGControl.DisplayStatus type
    ''' </summary>
    Public Shared Function ParseDisplayStatus(ByVal value As Object) As ButtonIGCGControl.DisplayStatus
        Dim result As ButtonIGCGControl.DisplayStatus = DisplayStatus.Unknow
        Try
            TryParseDisplayStatus(value, result)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-28 </date>
    ''' </author>
    ''' <summary>
    ''' Convert specific value to ButtonIGCGControl.DisplayStatus type
    ''' </summary>
    Public Shared Function TryParseDisplayStatus(ByVal value As Object, ByRef result As ButtonIGCGControl.DisplayStatus) As Boolean
        Dim isSuccess As Boolean = True
        Try
            Dim strValue As String = System.Convert.ToString(value)

            If [Enum].IsDefined(GetType(ButtonIGCGControl.DisplayStatus), strValue) Then
                result = CType([Enum].Parse(GetType(ButtonIGCGControl.DisplayStatus), strValue), ButtonIGCGControl.DisplayStatus)
            Else
                strValue = strValue.ToLower()
                Select Case strValue
                    Case "on", "true", "open", "opened", CInt(ButtonIGCGControl.DisplayStatus.On).ToString()
                        result = ButtonIGCGControl.DisplayStatus.On
                    Case "off", "false", "close", "closed", CInt(ButtonIGCGControl.DisplayStatus.Off).ToString()
                        result = ButtonIGCGControl.DisplayStatus.Off
                    Case "unknown", "other", "unk", "unknow", "between", CInt(ButtonIGCGControl.DisplayStatus.Unknow).ToString()
                        result = ButtonIGCGControl.DisplayStatus.Unknow
                    Case "error", "err", CInt(ButtonIGCGControl.DisplayStatus.Error).ToString()
                        result = ButtonIGCGControl.DisplayStatus.Error
                    Case Else
                        isSuccess = False
                End Select
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return isSuccess
    End Function
End Class
