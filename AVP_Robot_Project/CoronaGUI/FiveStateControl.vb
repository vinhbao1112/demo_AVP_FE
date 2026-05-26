Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPControls

Public Class FiveStateControl
#Region "Class Constants & Variables"
    Protected m_clickable As Boolean = False
    Protected m_bHasDiffClickFunc As Boolean = False
    Protected m_strValueToBeSend As String = STR_ON
    Protected m_enmDisplayStatus As DisplayStatus
    Protected m_imgOnImage As Image
    Protected m_imgOffImage As Image
    Protected m_imgUnknowImage As Image
    Protected m_imgErrorImage As Image
    Protected m_imgNoneImage As Image
    Protected m_colorText_OnStatus As Color = Color.Black
    Protected m_colorText_OffStatus As Color = Color.White
    Protected m_colorText_UnknowStatus As Color = Color.Black
    Protected m_colorText_ErrorStatus As Color = Color.Black
    Protected m_colorText_NoneStatus As Color = Color.White

    Protected m_StyleButton As ButtonStyle = ButtonStyle.Horizontal
    Protected m_strOnText As String = String.Empty
    Protected m_strOffText As String = String.Empty
    Protected m_strUnknownText As String = String.Empty
    Protected m_strErrorText As String = String.Empty
    Protected m_strNoneText As String = String.Empty
    Public Event StatusChange(ByVal sender As Object, ByVal e As System.EventArgs)
    Public ParentStatusObj As StatusObject = Nothing
    Protected m_TextLocation As Point = New Point(Me.Width / 2, Me.Height / 2)
#End Region

#Region "Public Properties"
    Public Property TextLocation() As Point
        Get
            Return m_TextLocation
        End Get
        Set(ByVal value As Point)
            m_TextLocation = value
        End Set
    End Property

    Public Property Clickable() As Boolean
        Get
            Return m_clickable
        End Get
        Set(ByVal value As Boolean)
            m_clickable = value
            If value Then
                Me.Cursor = Cursors.Hand
            Else
                Me.Cursor = Cursors.Arrow
            End If
        End Set
    End Property

    Public Property HasDiffClickFunc() As Boolean
        Get
            Return m_bHasDiffClickFunc
        End Get
        Set(ByVal value As Boolean)
            m_bHasDiffClickFunc = value
        End Set
    End Property

    Public Property ValueToBeSend() As String
        Get
            Return m_strValueToBeSend
        End Get
        Set(ByVal value As String)
            m_strValueToBeSend = value
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
    Public Property ColorText_OffStatus() As Color
        Get
            Return m_colorText_OffStatus
        End Get
        Set(ByVal value As Color)
            m_colorText_OffStatus = value
        End Set
    End Property

    Public Property ColorText_NoneStatus() As Color
        Get
            Return m_colorText_NoneStatus
        End Get
        Set(ByVal value As Color)
            m_colorText_NoneStatus = value
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
    Public Property OnText() As String
        Get
            Return m_strOnText
        End Get
        Set(ByVal value As String)
            m_strOnText = value
        End Set
    End Property

    Public Property NoneImage() As Image
        Get
            Return m_imgNoneImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgNoneImage = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    Public Property NoneText() As String
        Get
            Return m_strNoneText
        End Get
        Set(ByVal value As String)
            m_strNoneText = value
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
    Public Property Status() As DisplayStatus
        Get
            Return m_enmDisplayStatus
        End Get
        Set(ByVal value As DisplayStatus)
            Try
                If (value = DisplayStatus.Off) Then
                    'MyBase.Image = m_imgOffImage
                    ' MyBase.BackgroundImage = m_imgOffImage
                    Utils.CreateControlRegion(Me, m_imgOffImage)
                    Me.ForeColor = ColorText_OffStatus
                    If Not (m_strOffText = "") Then
                        Me.Text = m_strOffText
                    End If
                ElseIf value = DisplayStatus.On Then
                    'MyBase.Image = m_imgOnImage
                    'MyBase.BackgroundImage = m_imgOnImage
                    Utils.CreateControlRegion(Me, m_imgOnImage)
                    Me.ForeColor = ColorText_OnStatus
                    If Not (m_strOnText = "") Then
                        Me.Text = m_strOnText
                    End If
                ElseIf value = DisplayStatus.Error Then
                    'MyBase.BackgroundImage = m_imgErrorImage
                    Utils.CreateControlRegion(Me, m_imgErrorImage)
                    Me.ForeColor = ColorText_ErrorStatus
                    If Not (m_strErrorText = "") Then
                        Me.Text = m_strErrorText
                    End If
                ElseIf value = DisplayStatus.Unknow Then
                    'MyBase.BackgroundImage = m_imgUnknowImage
                    Utils.CreateControlRegion(Me, m_imgUnknowImage)
                    Me.ForeColor = ColorText_UnknowStatus
                    If Not (m_strUnknownText = "") Then
                        Me.Text = m_strUnknownText
                    End If
                Else
                    Utils.CreateControlRegion(Me, m_imgNoneImage)
                    Me.ForeColor = ColorText_NoneStatus
                    If Not (m_strNoneText = "") Then
                        Me.Text = m_strNoneText
                    End If
                End If
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
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
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
            Me.LoadDefaultButtonPicture()
            'MyBase.Image = m_imgOffImage
            MyBase.BackgroundImage = m_imgOffImage
            MyBase.Size = m_imgOffImage.Size
            Me.Cursor = Cursors.Hand
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SL_ValveControl))
            m_imgOnImage = Global.AVP_Robot_Project.My.Resources.Resources.bigcgIGOnImage
            m_imgOffImage = Global.AVP_Robot_Project.My.Resources.Resources.bigcgIGOffImage_ChamberInterlock
            m_imgUnknowImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
            m_imgErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.bigcgIGOffImage
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub



#End Region

    Private Sub Control_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Try
            If Clickable = False Or HasDiffClickFunc = True Then
                Exit Sub
            End If
            If Me.Status = DisplayStatus.Off Then
                ValueToBeSend = STR_ON
            ElseIf Me.Status = DisplayStatus.On Then
                ValueToBeSend = STR_OFF
            Else
                ValueToBeSend = UNKNOWN
            End If
            Dim Source As String = STR_IBE & "." & Me.Parent.Name & "." & Me.Name & "." & ValueToBeSend
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)

            Dim chamberName As String = String.Empty

            chamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
            If String.IsNullOrEmpty(chamberName) OrElse Not Me.Name.StartsWith(AVPLib.ConstEnum.Chamber) Then
                chamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Parent.Name)
            End If

            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + Me.Parent.Name + "] " + Me.Name + " Click ")
            If ValueToBeSend = UNKNOWN Then
                Dim dlgResult As DialogResult = Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OpenCloseCancel) 'MessageBoxButtons.YesNoCancel)
                If dlgResult = DialogResult.OK Then
                    ParentStatusObj.RequestStatus(Name, STR_ON)
                ElseIf dlgResult = DialogResult.No Then
                    ParentStatusObj.RequestStatus(Name, STR_OFF)
                End If
            Else
                If Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                    ParentStatusObj.RequestStatus(Name, ValueToBeSend)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overridable Sub Control_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        Dim string_format As New StringFormat
        string_format.Alignment = StringAlignment.Center
        string_format.LineAlignment = StringAlignment.Center
        string_format.FormatFlags = StringFormatFlags.DirectionRightToLeft
        If Me.Status = DisplayStatus.On Then
            g.DrawImage(m_imgOnImage, 0, 0, Me.Width, Me.Height)
            g.DrawString(Me.Text, Me.Font, New SolidBrush(ColorText_OnStatus), Me.m_TextLocation.X, Me.m_TextLocation.Y, string_format)
        ElseIf Me.Status = DisplayStatus.Off Then
            g.DrawImage(m_imgOffImage, 0, 0, Me.Width, Me.Height)
            g.DrawString(Me.Text, Me.Font, New SolidBrush(ColorText_OffStatus), Me.m_TextLocation.X, Me.m_TextLocation.Y, string_format)
        ElseIf Me.Status = DisplayStatus.Unknow Then
            g.DrawImage(m_imgUnknowImage, 0, 0, Me.Width, Me.Height)
            g.DrawString(Me.Text, Me.Font, New SolidBrush(ColorText_UnknowStatus), Me.m_TextLocation.X, Me.m_TextLocation.Y, string_format)
        ElseIf Me.Status = DisplayStatus.Error Then
            g.DrawImage(m_imgErrorImage, 0, 0, Me.Width, Me.Height)
            g.DrawString(Me.Text, Me.Font, New SolidBrush(ColorText_ErrorStatus), Me.m_TextLocation.X, Me.m_TextLocation.Y, string_format)
        ElseIf Me.Status = DisplayStatus.None Then
            g.DrawImage(m_imgNoneImage, 0, 0, Me.Width, Me.Height)
            g.DrawString(Me.Text, Me.Font, New SolidBrush(ColorText_NoneStatus), Me.m_TextLocation.X, Me.m_TextLocation.Y, string_format)
        End If
    End Sub
End Class

