Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Imports System.Windows.Forms
Imports System.ComponentModel
Imports AVPControls

Public Class SL_CustomButton
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
    Protected m_clickable As Boolean = False
    Protected m_updateIfNotClickable = True
    Protected m_bUseClickedEventInForm As Boolean = False
    Protected m_strValueToBeSend As String = STR_ON
    Protected m_enmDisplayStatus As DisplayStatus
    Protected m_imgOnImage As Image = My.Resources.Resources.BtnButtonGreen
    Protected m_imgOffImage As Image = My.Resources.Resources.BtnButtonWhite
    Protected m_imgUnknowImage As Image = My.Resources.Resources.BtnButtonYellow
    Protected m_imgErrorImage As Image = My.Resources.Resources.BtnButtonRed
    Protected m_colorText_OnStatus As Color = Color.Black
    Protected m_colorText_OffStatus As Color = Color.White
    Protected m_colorText_UnknowStatus As Color = Color.Black
    Protected m_colorText_ErrorStatus As Color = Color.White

    Protected m_StyleButton As ButtonStyle = ButtonStyle.Horizontal
    Protected m_strOnText As String = String.Empty
    Protected m_strOffText As String = String.Empty
    Protected m_strUnknownText As String = String.Empty
    Protected m_strErrorText As String = String.Empty
    Public Event StatusChange(ByVal sender As Object, ByVal e As System.EventArgs)
    Public ParentStatusObj As StatusObject = Nothing
    Private m_blnDenyKeyEnter As Boolean = False
    Protected m_strValueToSend_StatusOff As String = AVPLib.ConstEnum.STR_ON
    Protected m_strValueToSend_StatusOn As String = AVPLib.ConstEnum.STR_OFF
    Protected m_strValueToSend_StatusUnknown As String = String.Empty
    Protected m_strValueToSend_StatusErr As String = String.Empty
    Protected m_blnChangeValueToSend_BaseOnStatus As Boolean = False
    Protected m_IsNotValve As Boolean = False
    Protected m_IsStartStop As Boolean = False
    Protected m_IsUpDown As Boolean = False
    Protected m_IsSingleFunction As Boolean = False
    Private m_blnIsLiftOrPlaten As Boolean = False
    Private m_strLogSource As String = String.Empty
    Private m_strEquipmentName As String = String.Empty
    Private m_TypeOfChamberSupport As TypeOfAVPChamber = TypeOfAVPChamber.PVD4
    Private m_MessageBox_IsNotBaseOn_Status As Boolean = False
    Private m_MessageBoxText As String
    Protected m_IsConfirmMessage As Boolean = True
    Private m_MessageTitle As String = String.Empty
#End Region

#Region "Public Properties"
    <DefaultValue(GetType(TypeOfAVPChamber), "PVD4")> _
    Public Property TypeOfChamberSupport() As TypeOfAVPChamber
        Get
            Return m_TypeOfChamberSupport
        End Get
        Set(ByVal value As TypeOfAVPChamber)
            m_TypeOfChamberSupport = value
        End Set
    End Property
    'Equipment Name = coil, platen, robot, loadlock vv....
    <DefaultValue(GetType(String), "")> _
    Public Property EquipmentName() As String
        Get
            Return m_strEquipmentName
        End Get
        Set(ByVal value As String)
            m_strEquipmentName = value
        End Set
    End Property

    <DefaultValue(GetType(String), "")> _
    Public Property LogSource() As String
        Get
            Return m_strLogSource
        End Get
        Set(ByVal value As String)
            m_strLogSource = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsLiftOrPlaten() As Boolean
        Get
            Return m_blnIsLiftOrPlaten
        End Get
        Set(ByVal value As Boolean)
            m_blnIsLiftOrPlaten = value
            If value Then
                Me.SetStyle(ControlStyles.Selectable, False)
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property DenyKeyEnter() As Boolean
        Get
            Return m_blnDenyKeyEnter
        End Get
        Set(ByVal value As Boolean)
            m_blnDenyKeyEnter = value
            If value Then
                Me.SetStyle(ControlStyles.Selectable, False)
            End If
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
                Me.ForeColor = Color.Black
            Else
                Me.ForeColor = Color.FromArgb(85, 85, 85)
                Me.Cursor = Cursors.Arrow
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Public Property UpdateIfNotClickable() As Boolean
        Get
            Return m_updateIfNotClickable
        End Get
        Set(ByVal value As Boolean)
            m_updateIfNotClickable = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property UseClickedEventInForm() As Boolean
        Get
            Return m_bUseClickedEventInForm
        End Get
        Set(ByVal value As Boolean)
            m_bUseClickedEventInForm = value
        End Set
    End Property

    <DefaultValue(GetType(String), "On")> _
    Public Property ValueToSend_WhenStatusOff() As String
        Get
            Return m_strValueToSend_StatusOff
        End Get
        Set(ByVal value As String)
            m_strValueToSend_StatusOff = value
        End Set
    End Property

    <DefaultValue(GetType(String), "Off")> _
    Public Property ValueToSend_WhenStatusOn() As String
        Get
            Return m_strValueToSend_StatusOn
        End Get
        Set(ByVal value As String)
            m_strValueToSend_StatusOn = value
        End Set
    End Property

    <DefaultValue(GetType(String), "")> _
    Public Property ValueToSend_WhenStatusErr() As String
        Get
            Return m_strValueToSend_StatusErr
        End Get
        Set(ByVal value As String)
            m_strValueToSend_StatusErr = value
        End Set
    End Property

    <DefaultValue(GetType(String), "")> _
    Public Property ValueToSend_WhenStatusUnknown() As String
        Get
            Return m_strValueToSend_StatusUnknown
        End Get
        Set(ByVal value As String)
            m_strValueToSend_StatusUnknown = value
        End Set
    End Property

    ''Change ValueToBeSend when Status of Button Changed
    ''Use this property with 4 property ValueToSend_WhenStatusOn/Off/Err...
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property UseChangeValueToSend_BaseOnStatus() As Boolean
        Get
            Return m_blnChangeValueToSend_BaseOnStatus
        End Get
        Set(ByVal value As Boolean)
            m_blnChangeValueToSend_BaseOnStatus = value
        End Set
    End Property

    Public Property ValueToBeSend() As String
        Get
            If UseChangeValueToSend_BaseOnStatus Then
                ChangeValuefor_ButtonStatusOnOff()
            End If
            Return m_strValueToBeSend
        End Get
        Set(ByVal value As String)
            If UseChangeValueToSend_BaseOnStatus Then
                ChangeValuefor_ButtonStatusOnOff()
            Else
                m_strValueToBeSend = value
            End If
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
            If m_colorText_OnStatus <> value Then
                m_colorText_OnStatus = value
                If m_enmDisplayStatus = DisplayStatus.On Then
                    UpdateView()
                End If
            End If
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
            If m_colorText_OffStatus <> value Then
                m_colorText_OffStatus = value

                If m_enmDisplayStatus = DisplayStatus.Off Then
                    UpdateView()
                End If
            End If
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
            If m_colorText_UnknowStatus <> value Then
                m_colorText_UnknowStatus = value

                If m_enmDisplayStatus = DisplayStatus.Unknow Then
                    UpdateView()
                End If
            End If
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
            If m_colorText_ErrorStatus <> value Then
                m_colorText_ErrorStatus = value

                If m_enmDisplayStatus = DisplayStatus.Error Then
                    UpdateView()
                End If
            End If
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
            If m_strErrorText <> value Then
                m_strErrorText = value

                If m_enmDisplayStatus = DisplayStatus.Error Then
                    UpdateView()
                End If
            End If
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
            If m_strUnknownText <> value Then
                m_strUnknownText = value

                If m_enmDisplayStatus = DisplayStatus.Unknow Then
                    UpdateView()
                End If
            End If
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
            If m_strOffText <> value Then
                m_strOffText = value

                If m_enmDisplayStatus = DisplayStatus.Off Then
                    UpdateView()
                End If
            End If
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
            If m_strOnText <> value Then
                m_strOnText = value

                If m_enmDisplayStatus = DisplayStatus.On Then
                    UpdateView()
                End If
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
    <DefaultValue(GetType(ButtonStyle), "Horizontal")> _
    Public Property StyleOfButton() As ButtonStyle
        Get
            Return m_StyleButton
        End Get
        Set(ByVal value As ButtonStyle)
            If m_StyleButton <> value Then
                m_StyleButton = value
                Me.Refresh()
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
            Try
                If m_enmDisplayStatus <> value Then
                    m_enmDisplayStatus = value
                    UpdateView()
                End If
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
                    UpdateView()
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
                    UpdateView()
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
                    UpdateView()
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
                    UpdateView()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsNotValve() As Boolean
        Get
            Return m_IsNotValve
        End Get
        Set(ByVal value As Boolean)
            m_IsNotValve = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsStartStopAction() As Boolean
        Get
            Return m_IsStartStop
        End Get
        Set(ByVal value As Boolean)
            m_IsStartStop = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsUpDownAction() As Boolean
        Get
            Return m_IsUpDown
        End Get
        Set(ByVal value As Boolean)
            m_IsUpDown = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsSingleFunction() As Boolean
        Get
            Return m_IsSingleFunction
        End Get
        Set(ByVal value As Boolean)
            m_IsSingleFunction = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property MessageBox_IsNot_BaseOn_Status() As Boolean
        Get
            Return m_MessageBox_IsNotBaseOn_Status
        End Get
        Set(ByVal value As Boolean)
            m_MessageBox_IsNotBaseOn_Status = value
        End Set
    End Property

    <DefaultValue(GetType(String), "")> _
    Public Property MessageBoxText() As String
        Get
            Return m_MessageBoxText
        End Get
        Set(ByVal value As String)
            m_MessageBoxText = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-04-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set IsConfirmMessage
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property IsConfirmMessage() As Boolean
        Get
            Return m_IsConfirmMessage
        End Get
        Set(ByVal value As Boolean)
            m_IsConfirmMessage = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-07-15 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set MessageTitle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property MessageTitle() As String
        Get
            Return m_MessageTitle
        End Get
        Set(ByVal value As String)
            m_MessageTitle = value
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
            Me.Size = m_imgOffImage.Size
            Me.Cursor = Cursors.Hand
            ChangeValuefor_ButtonStatusOnOff()
            UpdateView()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2012-09-27 </date>
    ''' </author>
    ''' <summary>
    ''' Get Message after format massage
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFormatMessageText(ByVal strMessageText As String) As String

        'If TypeOfChamberSupport is PQL or PVD6P, use AccessibleDescription instead AccessibleName
        Dim IsUseAccessibleDescription As Boolean = Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD2R4 _
                                             OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.IBD _
                                             OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD4 _
                                            OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD5T
        If Me.m_MessageBox_IsNotBaseOn_Status Then
            strMessageText = String.Format(strMessageText, MessageBoxText, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName))
        Else
            If Me.Status = DisplayStatus.On Then
                If IsNotValve And (Not IsLiftOrPlaten) Then
                    strMessageText = String.Format(strMessageText, STRING_TURN_OFF, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName))
                ElseIf IsStartStopAction Then
                    strMessageText = String.Format(strMessageText, STRING_STOP_ACTION, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName))
                ElseIf IsUpDownAction Then
                    strMessageText = String.Format(strMessageText, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName), STRING_DOWN_ACTION)
                Else
                    strMessageText = String.Format(strMessageText, STRING_CLOSE, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName))
                End If
            ElseIf Me.Status = DisplayStatus.Off Then
                If IsNotValve And (Not IsLiftOrPlaten) Then
                    strMessageText = String.Format(strMessageText, STRING_TURN_ON, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName))
                ElseIf IsStartStopAction Then
                    strMessageText = String.Format(strMessageText, STRING_START_ACTION, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName))
                ElseIf IsUpDownAction Then
                    strMessageText = String.Format(strMessageText, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName), STRING_UP_ACTION)
                Else
                    strMessageText = String.Format(strMessageText, STRING_OPEN, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName))
                End If
            ElseIf Me.Status = DisplayStatus.Unknow OrElse Me.Status = DisplayStatus.Error Then
                If IsNotValve And (Not IsLiftOrPlaten) Then
                    strMessageText = String.Format(strMessageText, STRING_TURN_ON_OFF, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName))
                ElseIf IsStartStopAction Then
                    strMessageText = String.Format(strMessageText, STRING_STOP_ACTION, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName))
                ElseIf IsUpDownAction Then
                    strMessageText = String.Format(strMessageText, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName), STRING_UP_DOWN_ACTION)
            Else
                    strMessageText = String.Format(strMessageText, STRING_OPEN_CLOSE, IIf(IsUseAccessibleDescription, AccessibleDescription, AccessibleName))
            End If
        End If
        End If

        Return strMessageText
    End Function

    Private Sub SL_CustomButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Try
            If DenyKeyEnter Then
                Me.Parent.Focus()
            End If

            If Clickable = False Or UseClickedEventInForm = True Then
                Exit Sub
            End If

            Dim Source As String = Me.TypeOfChamberSupport.ToString() & "." & Me.Parent.Name & "." & Me.Name
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)

            'if not, get normal click
            If String.IsNullOrEmpty(strMessageText) Then
                'retry 
                Source = Me.TypeOfChamberSupport.ToString() & "." & Me.Parent.Name & "." & Me.Name & "." & Me.Status.ToString()
                strMessageText = AVPLib.ContainerData.GetMessageText(Source)
                'use normal click
                If String.IsNullOrEmpty(strMessageText) Then
                    If Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD4 Then
                        Source = TypeOfChamberSupport.ToString() & ".ButtonClick"
                        Else
                    Source = TypeOfChamberSupport.ToString() & ".ButtonClick." & Me.Status.ToString()
                    End If
                    strMessageText = AVPLib.ContainerData.GetMessageText(Source)
                    strMessageText = GetFormatMessageText(strMessageText).Replace("\n", Environment.NewLine)
                End If
            End If

            Dim chamberName As String = MessageTitle
            If String.IsNullOrEmpty(chamberName) Then
                chamberName = AVPLib.Utils.chamberID2ChamberName(ParentStatusObj.Name)
                If String.IsNullOrEmpty(chamberName) _
                OrElse (ParentStatusObj.Parent IsNot Nothing _
                        AndAlso ParentStatusObj.Parent.Name IsNot Nothing _
                        AndAlso Not ParentStatusObj.Name.StartsWith(AVPLib.ConstEnum.Chamber)) _
                OrElse (Not String.IsNullOrEmpty(chamberName) AndAlso chamberName.StartsWith(AVPLib.ConstEnum.Chamber)) Then
                chamberName = AVPLib.Utils.chamberID2ChamberName(ParentStatusObj.Parent.Name)
            End If
                If String.IsNullOrEmpty(chamberName) _
                OrElse (ParentStatusObj.Parent.Parent IsNot Nothing _
                        AndAlso ParentStatusObj.Parent.Parent.Name IsNot Nothing _
                        AndAlso Not ParentStatusObj.Parent.Name.StartsWith(AVPLib.ConstEnum.Chamber)) _
                OrElse (Not String.IsNullOrEmpty(chamberName) AndAlso chamberName.StartsWith(AVPLib.ConstEnum.Chamber)) Then
                    chamberName = AVPLib.Utils.chamberID2ChamberName(ParentStatusObj.Parent.Parent.Name)
                End If
            chamberName = IIf(chamberName = CASSETTESPANEL_STR, TM_STR, chamberName)
            End If
            Dim strCheckResult As String = String.Empty
            Dim dlgResult As DialogResult = Nothing
            If Not IsSingleFunction AndAlso Me.Status = DisplayStatus.Unknow Then
                If IsNotValve Then
                    If IsLiftOrPlaten Then
                        dlgResult = Utils.ShowAVPMessageBoxWith_UpDownCancelConfirm(strMessageText, _
                                                                       chamberName, MessageBoxIcon.Information)
                Else
                        dlgResult = Utils.ShowAVPMessageBoxWith_OnOffCancelConfirm(strMessageText, _
                                                   chamberName, MessageBoxIcon.Information)
                End If

                Else
                    dlgResult = Utils.ShowAVPMessageBoxWith_OpenCloseCancelConfirm(strMessageText, _
                                                   chamberName, MessageBoxIcon.Information)
                End If
                If dlgResult = Windows.Forms.DialogResult.OK Then
                    m_strValueToBeSend = STR_ON
                ElseIf dlgResult = Windows.Forms.DialogResult.No Then
                    m_strValueToBeSend = STR_OFF
                End If
            Else
                If IsConfirmMessage Then
                    dlgResult = Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Information, MessageBoxButtons.YesNo)
                Else
                    dlgResult = Windows.Forms.DialogResult.OK
                End If
            End If
            If dlgResult <> Windows.Forms.DialogResult.Cancel Then
                If dlgResult = Windows.Forms.DialogResult.OK Then

                    If (String.IsNullOrEmpty(strCheckResult)) Then
                        If Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD2R4 _
                            OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD4 _
                            OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.IBD _
                            OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD5T Then

                            ParentStatusObj.RequestStatus(IIf(Me.AccessibleName <> String.Empty, Me.AccessibleName, Me.Name), ValueToBeSend)
                        Else
                            ParentStatusObj.RequestStatus(Name, ValueToBeSend)
                        End If

                        'Update Secs/Gem process state, only for    
                    Else
                        Utils.ShowAVPMessageBox(strCheckResult, chamberName, MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                    End If

                ElseIf dlgResult = Windows.Forms.DialogResult.No Then
                    If Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD2R4 _
                        OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD4 _
                        OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.IBD _
                        OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD5T Then
                        ParentStatusObj.RequestStatus(IIf(Me.AccessibleName <> String.Empty, Me.AccessibleName, Me.Name), ValueToSend_WhenStatusOn)
                    Else
                        ParentStatusObj.RequestStatus(Name, ValueToBeSend)
                    End If
                End If
                Utils.LogUserEvent(Me)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(Me.Parent.Name & " " & Me.Name & " " & ex.ToString())
        End Try
    End Sub

    Protected Overridable Sub ButtonIGCGControl_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If StyleOfButton = ButtonStyle.Vertical Then
            Dim g As Graphics = e.Graphics
            Dim string_format As New StringFormat
            string_format.Alignment = StringAlignment.Center
            string_format.LineAlignment = StringAlignment.Center
            string_format.FormatFlags = _
                StringFormatFlags.DirectionVertical Or _
                StringFormatFlags.DirectionRightToLeft
            If Me.Status = DisplayStatus.On Then
                g.DrawImage(m_imgOnImage, 0, 0, Me.Width, Me.Height)
                g.DrawString(Me.Text, Me.Font, New SolidBrush(IIf(Clickable, ColorText_OnStatus, Color.FromArgb(85, 85, 85))), Me.Width / 2 - 1, Me.Height / 2, string_format)
            ElseIf Me.Status = DisplayStatus.Off Then
                g.DrawImage(m_imgOffImage, 0, 0, Me.Width, Me.Height)
                g.DrawString(Me.Text, Me.Font, New SolidBrush(IIf(Clickable, ColorText_OffStatus, Color.FromArgb(85, 85, 85))), Me.Width / 2 - 1, Me.Height / 2, string_format)
            ElseIf Me.Status = DisplayStatus.Unknow Then
                g.DrawImage(m_imgUnknowImage, 0, 0, Me.Width, Me.Height)
                g.DrawString(Me.Text, Me.Font, New SolidBrush(IIf(Clickable, ColorText_UnknowStatus, Color.FromArgb(85, 85, 85))), Me.Width / 2 - 1, Me.Height / 2, string_format)
            ElseIf Me.Status = DisplayStatus.Error Then
                g.DrawImage(m_imgErrorImage, 0, 0, Me.Width, Me.Height)
                g.DrawString(Me.Text, Me.Font, New SolidBrush(IIf(Clickable, ColorText_ErrorStatus, Color.FromArgb(85, 85, 85))), Me.Width / 2 - 1, Me.Height / 2, string_format)
            End If

        End If
    End Sub

    Private Sub SL_CustomButton_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.StatusChange
        ChangeValuefor_ButtonStatusOnOff()
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Change value to Request Message when Button Status changed
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangeValuefor_ButtonStatusOnOff()
        Try
            If UseChangeValueToSend_BaseOnStatus Then
                If Status = DisplayStatus.Off Then
                    m_strValueToBeSend = ValueToSend_WhenStatusOff
                ElseIf Status = DisplayStatus.On Then
                    m_strValueToBeSend = ValueToSend_WhenStatusOn
                ElseIf Status = DisplayStatus.Error Then
                    m_strValueToBeSend = ValueToSend_WhenStatusErr
                ElseIf Status = DisplayStatus.Unknow Then
                    m_strValueToBeSend = ValueToSend_WhenStatusUnknown
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-28 </date>
    ''' </author>
    ''' <summary>
    ''' Convert specific value to SL_CustomButton.DisplayStatus type
    ''' </summary>
    Public Shared Function ParseDisplayStatus(ByVal value As Object) As SL_CustomButton.DisplayStatus
        Dim result As SL_CustomButton.DisplayStatus = DisplayStatus.Unknow
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
    ''' Convert specific value to SL_CustomButton.DisplayStatus type
    ''' </summary>
    Public Shared Function TryParseDisplayStatus(ByVal value As Object, ByRef result As SL_CustomButton.DisplayStatus) As Boolean
        Dim isSuccess As Boolean = True
        Try
            Dim strValue As String = System.Convert.ToString(value)

            If [Enum].IsDefined(GetType(SL_CustomButton.DisplayStatus), strValue) Then
                result = CType([Enum].Parse(GetType(SL_CustomButton.DisplayStatus), strValue), SL_CustomButton.DisplayStatus)
            Else
                strValue = strValue.ToLower()
                Select Case strValue
                    Case "on", "true", "open", "opened", CInt(SL_CustomButton.DisplayStatus.On).ToString()
                        result = SL_CustomButton.DisplayStatus.On
                    Case "off", "false", "close", "closed", CInt(SL_CustomButton.DisplayStatus.Off).ToString()
                        result = SL_CustomButton.DisplayStatus.Off
                    Case "unknown", "other", "unk", "unknow", "between", CInt(SL_CustomButton.DisplayStatus.Unknow).ToString()
                        result = SL_CustomButton.DisplayStatus.Unknow
                    Case "error", "err", CInt(SL_CustomButton.DisplayStatus.Error).ToString()
                        result = SL_CustomButton.DisplayStatus.Error
                    Case Else
                        isSuccess = False
                End Select
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return isSuccess
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-08-04 </date>
    ''' </author>
    ''' <summary>
    ''' Update GUI
    ''' </summary>
    Private Sub UpdateView()
        If (m_enmDisplayStatus = DisplayStatus.Off) Then
            Me.BackgroundImage = m_imgOffImage
            Me.ForeColor = ColorText_OffStatus
            If Not String.IsNullOrEmpty(m_strOffText) Then
                Me.Text = m_strOffText
            End If
        ElseIf m_enmDisplayStatus = DisplayStatus.On Then
            Me.BackgroundImage = m_imgOnImage
            Me.ForeColor = ColorText_OnStatus
            If Not String.IsNullOrEmpty(m_strOnText) Then
                Me.Text = m_strOnText
            End If
        ElseIf m_enmDisplayStatus = DisplayStatus.Error Then
            Me.BackgroundImage = m_imgErrorImage
            Me.ForeColor = ColorText_ErrorStatus
            If Not String.IsNullOrEmpty(m_strErrorText) Then
                Me.Text = m_strErrorText
            End If
        Else
            Me.BackgroundImage = m_imgUnknowImage
            Me.ForeColor = ColorText_UnknowStatus
            If Not String.IsNullOrEmpty(m_strUnknownText) Then
                Me.Text = m_strUnknownText
            End If
        End If
    End Sub
End Class

