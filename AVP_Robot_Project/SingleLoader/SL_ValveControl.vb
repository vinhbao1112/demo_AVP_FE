Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports System.ComponentModel
Imports AVPControls

Public Class SL_ValveControl
#Region "Class Constants & Variables"
    Public Enum DisplayStatus
        [Off] = 0
        [On] = 1
        [Error] = 2
        [Unknow] = 3
        [None] = 4
    End Enum
    Public Enum ButtonStyle
        [Vertical]
        [Horizontal]
    End Enum
    Private m_clickable As Boolean = False
    Private m_bHasDiffClickFunc As Boolean = False
    Private m_strValueToBeSend As String = STR_ON
    Private m_enmDisplayStatus As DisplayStatus
    Private m_imgOnImage As Image
    Private m_imgOffImage As Image
    Private m_imgUnknowImage As Image
    Private m_imgErrorImage As Image
    Private m_imgNoneImage As Image
    Private m_colorText_OnStatus As Color = Color.Black
    Private m_colorText_OffStatus As Color = Color.White
    Private m_colorText_UnknowStatus As Color = Color.Black
    Private m_colorText_ErrorStatus As Color = Color.Black
    Private m_colorText_NoneStatus As Color = Color.Black

    Private m_StyleButton As ButtonStyle = ButtonStyle.Horizontal
    Private m_strOnText As String = String.Empty
    Private m_strOffText As String = String.Empty
    Private m_strUnknownText As String = String.Empty
    Private m_strErrorText As String = String.Empty
    Private m_strNoneText As String = String.Empty
    Private m_strTextValue As String = String.Empty
    Public Event StatusChange(ByVal sender As Object, ByVal e As System.EventArgs)
    Public ParentStatusObj As StatusObject = Nothing
    Private m_TypeOfChamberSupport As TypeOfAVPChamber = TypeOfAVPChamber.IBE
    Private m_textlocation As Point = New Point(Me.Width / 2 - 1, 35)
    Private m_UsingTheSameMsgboxWithName As String = String.Empty
    Private m_needRecreateRegion As Boolean = True
#End Region

#Region "Public Properties"
    <DefaultValue(GetType(String), "")> _
    Public Property UsingTheSameMsgboxWithName() As String
        Get
            Return m_UsingTheSameMsgboxWithName
        End Get
        Set(ByVal value As String)
            m_UsingTheSameMsgboxWithName = value
        End Set
    End Property
    Public Property TypeOfChamberSupport() As TypeOfAVPChamber
        Get
            Return m_TypeOfChamberSupport
        End Get
        Set(ByVal value As TypeOfAVPChamber)
            m_TypeOfChamberSupport = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
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

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property HasDiffClickFunc() As Boolean
        Get
            Return m_bHasDiffClickFunc
        End Get
        Set(ByVal value As Boolean)
            m_bHasDiffClickFunc = value
        End Set
    End Property

    <DefaultValue(GetType(String), "On")> _
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
    <DefaultValue(GetType(Color), "Black")> _
    Public Property ColorText_ErrorStatus() As Color
        Get
            Return m_colorText_ErrorStatus
        End Get
        Set(ByVal value As Color)
            m_colorText_ErrorStatus = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Kiet Tran</name>
    '''    	<date> 2026-04-10</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Color), "Black")>
    Public Property ColorText_NoneStatus() As Color
        Get
            Return m_colorText_NoneStatus
        End Get
        Set(ByVal value As Color)
            m_colorText_NoneStatus = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran</name>
    '''    	<date> 2026-04-10</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")>
    Public Property NoneText() As String
        Get
            Return m_strNoneText
        End Get
        Set(ByVal value As String)
            m_strNoneText = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran</name>
    '''    	<date> 2026-04-10</date>
    ''' </author>
    ''' <summary>
    ''' Get or set image of none Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Image), "Nothing")>
    Public Property NoneImage() As Image
        Get
            Return m_imgNoneImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgNoneImage = value

                If m_enmDisplayStatus = DisplayStatus.None Then
                    ChangeImage()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    Public Property TextValue() As String
        Get
            Return m_strTextValue
        End Get
        Set(ByVal value As String)
            m_strTextValue = value
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
            If m_StyleButton <> value Then
            m_StyleButton = value
                m_needRecreateRegion = True
            End If
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
            If m_enmDisplayStatus <> value Then
                m_enmDisplayStatus = value

                ChangeImage()
                Try
                RaiseEvent StatusChange(Me, Nothing)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            End If
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
    <DefaultValue(GetType(Image), "Nothing")> _
    Public Property OnImage() As Image
        Get
            Return m_imgOnImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgOnImage = value

                If m_enmDisplayStatus = DisplayStatus.On Then
                    ChangeImage()
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
    <DefaultValue(GetType(Image), "Nothing")> _
    Public Property OffImage() As Image
        Get
            Return m_imgOffImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgOffImage = value
                m_needRecreateRegion = True
                If m_enmDisplayStatus = DisplayStatus.Off Then
                    ChangeImage()
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
    <DefaultValue(GetType(Image), "Nothing")> _
    Public Property UnknownImage() As Image
        Get
            Return m_imgUnknowImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgUnknowImage = value

                If m_enmDisplayStatus = DisplayStatus.Unknow Then
                    ChangeImage()
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
    <DefaultValue(GetType(Image), "Nothing")> _
    Public Property ErrorImage() As Image
        Get
            Return m_imgErrorImage
        End Get
        Set(ByVal value As Image)
            Try
                m_imgErrorImage = value

                If m_enmDisplayStatus = DisplayStatus.Error Then
                    ChangeImage()
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
    Public Property TextLocation() As Point
        Get
            Return m_textlocation
        End Get
        Set(ByVal value As Point)
            m_textlocation = value
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
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-31 </date>
    ''' </author>
    ''' <summary>
    ''' Change control image
    ''' </summary>
    Private Sub ChangeImage()
        Try
            Dim imgCtrl As Image
            If (m_enmDisplayStatus = DisplayStatus.Off) Then
                imgCtrl = m_imgOffImage
                Me.ForeColor = ColorText_OffStatus
                If Not (m_strOffText = "") Then
                    Me.Text = m_strOffText
                End If
            ElseIf m_enmDisplayStatus = DisplayStatus.On Then
                imgCtrl = m_imgOnImage
                Me.ForeColor = ColorText_OnStatus
                If Not (m_strOnText = "") Then
                    Me.Text = m_strOnText
                End If
            ElseIf m_enmDisplayStatus = DisplayStatus.Error Then
                imgCtrl = m_imgErrorImage
                Me.ForeColor = ColorText_ErrorStatus
                If Not (m_strErrorText = "") Then
                    Me.Text = m_strErrorText
                End If
            ElseIf m_enmDisplayStatus = DisplayStatus.None Then
                imgCtrl = m_imgNoneImage
                Me.ForeColor = ColorText_NoneStatus
                If Not (m_strNoneText = "") Then
                    Me.Text = m_strNoneText
                End If
            Else
                imgCtrl = m_imgUnknowImage
                Me.ForeColor = ColorText_UnknowStatus
                If Not (m_strUnknownText = "") Then
                    Me.Text = m_strUnknownText
                End If
            End If

            Utils.CreateControlRegion(Me, imgCtrl)
            imgCtrl = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

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
            m_imgOnImage = Global.AVP_Robot_Project.My.Resources.Resources.bigcgIG_OnImage
            m_imgOffImage = Global.AVP_Robot_Project.My.Resources.Resources.bigcgIG_OffImage_ChamberInterlock
            m_imgUnknowImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
            m_imgErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.bigcgIG_OffImage
            m_imgNoneImage = Global.AVP_Robot_Project.My.Resources.Resources.YellowButton
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-14</date>
    ''' </author>
    ''' <summary>
    ''' Do click event.
    ''' </summary>
    Public Sub PerformClick()
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
            Dim strNameForMsgBox As String = IIf(String.IsNullOrEmpty(UsingTheSameMsgboxWithName), Me.Name, UsingTheSameMsgboxWithName)
            Dim Source As String = Me.TypeOfChamberSupport.ToString() & "." & Me.Parent.Name & "." & strNameForMsgBox & "." & ValueToBeSend
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)
            If strMessageText = String.Empty Then
                Source = Me.TypeOfChamberSupport.ToString() & "." & strNameForMsgBox & "." & ValueToBeSend
                strMessageText = AVPLib.ContainerData.GetMessageText(Source)
            End If
            Dim chamberName As String = String.Empty
            chamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
            If String.IsNullOrEmpty(chamberName) OrElse Not Me.Name.StartsWith(AVPLib.ConstEnum.Chamber) Then
                If Not Me.Parent.Name.StartsWith(AVPLib.ConstEnum.Chamber) Then
                    chamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Parent.Name)
                Else
                    chamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
                End If
            End If

            Utils.LogUserEvent(Me)
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

    Private Sub SL_ValControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        PerformClick()
    End Sub

    Private Sub ButtonIGCGControl_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Try
        Dim g As Graphics = e.Graphics
        Dim string_format As New StringFormat
        If StyleOfButton = ButtonStyle.Vertical Then
            string_format.Alignment = StringAlignment.Center
            string_format.LineAlignment = StringAlignment.Center
            string_format.FormatFlags = _
                StringFormatFlags.DirectionVertical Or _
                StringFormatFlags.DirectionRightToLeft
        Else
            string_format.Alignment = StringAlignment.Center
            string_format.LineAlignment = StringAlignment.Center
            string_format.FormatFlags = StringFormatFlags.MeasureTrailingSpaces
        End If

            Dim img As Image = Nothing
            Dim text As String = TextValue
            Dim brush As SolidBrush = Nothing

            Select Case Me.Status
                Case DisplayStatus.On
                    If m_imgOnImage IsNot Nothing Then
                        img = m_imgOnImage
                    End If
                    If Not String.IsNullOrEmpty(OnText) Then
                        text = OnText
                    End If
                    brush = New SolidBrush(ColorText_OnStatus)

                Case DisplayStatus.Off
                    If m_imgOffImage IsNot Nothing Then
                        img = m_imgOffImage
                    End If
                    If Not String.IsNullOrEmpty(OffText) Then
                        text = OffText
                    End If
                    brush = New SolidBrush(ColorText_OffStatus)

                Case DisplayStatus.Unknow
                    If m_imgUnknowImage IsNot Nothing Then
                        img = m_imgUnknowImage
                    End If
                    If Not String.IsNullOrEmpty(UnKnownText) Then
                        text = UnKnownText
                    End If
                    brush = New SolidBrush(ColorText_UnknowStatus)

                Case DisplayStatus.Error
                    If m_imgErrorImage IsNot Nothing Then
                        img = m_imgErrorImage
                    End If
                    If Not String.IsNullOrEmpty(ErrorText) Then
                        text = ErrorText
                    End If
                    brush = New SolidBrush(ColorText_ErrorStatus)

                Case DisplayStatus.None
                    If m_imgNoneImage IsNot Nothing Then
                        img = m_imgNoneImage
                    End If
                    If Not String.IsNullOrEmpty(NoneText) Then
                        text = NoneText
                    End If
                    brush = New SolidBrush(ColorText_NoneStatus)

            End Select

            If img IsNot Nothing Then
                g.DrawImage(img, 0, 0, Me.Width, Me.Height)
            End If
            If Not String.IsNullOrEmpty(text) Then
                If brush Is Nothing Then
                    brush = New SolidBrush(Me.ForeColor)
                End If
                g.DrawString(text, Me.Font, brush, TextLocation.X, TextLocation.Y, string_format)
            End If

            ' Release resources
            img = Nothing
            string_format.Dispose()
            text = Nothing
            If brush IsNot Nothing Then
                brush.Dispose()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-24 </date>
    ''' </author>
    ''' <summary>
    ''' Convert specific value to BinaryStatusControl.DisplayStatus type
    ''' </summary>
    Public Shared Function ParseDisplayStatus(ByVal value As Object) As SL_ValveControl.DisplayStatus
        Dim result As SL_ValveControl.DisplayStatus = DisplayStatus.Unknow
        Try
            TryParseDisplayStatus(value, result)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-24 </date>
    ''' </author>
    ''' <summary>
    ''' Convert specific value to BinaryStatusControl.DisplayStatus type
    ''' </summary>
    Public Shared Function TryParseDisplayStatus(ByVal value As Object, ByRef result As SL_ValveControl.DisplayStatus) As Boolean
        Dim isSuccess As Boolean = True
        Try
            If value Is Nothing Then
                Return False
            End If

            Dim strValue As String = System.Convert.ToString(value)

            If [Enum].IsDefined(GetType(SL_ValveControl.DisplayStatus), strValue) Then
                result = CType([Enum].Parse(GetType(SL_ValveControl.DisplayStatus), strValue), SL_ValveControl.DisplayStatus)
            Else
                strValue = strValue.ToLower()
                Select Case strValue
                    Case STR_ON.ToLower(), Boolean.TrueString.ToLower(), STRING_OPEN.ToLower(), OPENED.ToLower()
                        result = SL_ValveControl.DisplayStatus.On
                    Case STR_OFF.ToLower(), Boolean.FalseString.ToLower(), STRING_CLOSE.ToLower(), CLOSED.ToLower()
                        result = SL_ValveControl.DisplayStatus.Off
                    Case STR_UNKNOWN.ToLower(), STR_OTHER.ToLower(), "unk", "unknow", "between"
                        result = SL_ValveControl.DisplayStatus.Unknow
                    Case STR_ERROR.ToLower(), "err"
                        result = DisplayStatus.Error
                    Case "none", "n/a", "na", ""
                        result = DisplayStatus.None
                    Case Else
                        isSuccess = False
                End Select
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            isSuccess = False
        End Try
        Return isSuccess
    End Function
End Class

