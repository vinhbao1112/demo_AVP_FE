Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Imports System.ComponentModel

Public Class SlitValve
    Private m_OnImage As Bitmap = AVP_Robot_Project.My.Resources.Resources.SlitValve_Open
    Private m_OffImage As Bitmap = AVP_Robot_Project.My.Resources.Resources.SlitValve_Close
    Private m_UnkImage As Bitmap = AVP_Robot_Project.My.Resources.Resources.SlitValve_Unknown
    Private m_NoneImage As Bitmap = AVP_Robot_Project.My.Resources.Resources.SlitValve_None
    Private m_pmPos As SlitValvePositions = SlitValvePositions.None
    Private m_supportCX As PMControl.Support_CX = PMControl.Support_CX.Support_CX4
    Private m_status As SlitValveDisplayStatus = SlitValveDisplayStatus.Unknown
    Private m_hasDataChanged As Boolean = True
    Private m_needRecreateRegion As Boolean = True
    Private m_screen As Support_Screen = Support_Screen.TM
    Private m_angle As Single = 0

    Public Enum SlitValvePositions
        None = -1
        LLA = 0
        PM1 = 1
        PM2 = 2
        PM3 = 3
        LLB = 7
        HivacTM = 8
        HivacLLA = 9
    End Enum

    Public Enum SlitValveDisplayStatus
        [Off] = 0
        [On] = 1
        [Unknown] = 2
        [None] = 3
    End Enum

#Region "Properties"
    Public ReadOnly Property PositionIndex() As Integer
        Get
            Return m_pmPos
        End Get
    End Property

    <DefaultValue(GetType(Support_Screen), "TM")> _
    Public Property InScreen() As Support_Screen
        Get
            Return m_screen
        End Get
        Set(ByVal value As Support_Screen)
            If m_screen <> value Then
                m_screen = value
            End If
        End Set
    End Property

    <DefaultValue(GetType(SlitValveDisplayStatus), "Unknown")>
    Public Property Status() As SlitValveDisplayStatus
        Get
            Return m_status
        End Get
        Set(ByVal value As SlitValveDisplayStatus)
            If m_status <> value Then
                m_status = value

                ' Re-draw
                m_hasDataChanged = True
                SetPosition()
            End If
        End Set
    End Property

    Public ReadOnly Property IsPMSlitValve() As Boolean
        Get
            If Me.PositionIndex >= 1 AndAlso Me.PositionIndex <= 6 Then
                Return True
            End If
            Return False
        End Get
    End Property

    <DefaultValue(GetType(PMControl.Support_CX), "Support_CX4")> _
    Public Property CX_Supported() As PMControl.Support_CX
        Get
            Return m_supportCX
        End Get
        Set(ByVal value As PMControl.Support_CX)
            If (m_supportCX <> value) Then
                m_supportCX = value
                ' Get angle for drawing slit valve
                GetAngle()
                ' Re-draw
                m_hasDataChanged = True
                m_needRecreateRegion = True
                SetPosition()
            End If
        End Set
    End Property

    <DefaultValue(GetType(SlitValvePositions), "None")> _
    Public Property DockPosition() As SlitValvePositions
        Get
            Return m_pmPos
        End Get
        Set(ByVal value As SlitValvePositions)
            If (m_pmPos <> value) Then
                m_pmPos = value
                ' Get angle for drawing slit valve
                GetAngle()
                ' Re-draw
                m_hasDataChanged = True
                m_needRecreateRegion = True
                SetPosition()
            End If
        End Set
    End Property

#End Region

#Region "Subs & Functions"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Private Sub SlitValve_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetPosition()
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-09 </date>
    ''' </author>
    ''' <summary>    
    ''' Draw Slitvalve follow Properties
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPosition()
        Try
            If m_hasDataChanged Then
                Dim slitValveImage As Bitmap
                If Me.Status = SlitValveDisplayStatus.On Then
                    slitValveImage = m_OnImage
                ElseIf Me.Status = SlitValveDisplayStatus.Off Then
                    slitValveImage = m_OffImage
                ElseIf Me.Status = SlitValveDisplayStatus.None Then
                    slitValveImage = m_NoneImage
                Else
                    slitValveImage = m_UnkImage
                End If

                Dim image As New Bitmap(slitValveImage)

                If m_pmPos = SlitValvePositions.HivacTM OrElse m_pmPos = SlitValvePositions.HivacLLA Then
                    image = Utils.ScaleImage(image, 47)
                End If
                image = Utils.RotateImageCenter(image, m_angle)

                If m_needRecreateRegion Then
                    Utils.CreateControlRegion(Me, image)
                    m_needRecreateRegion = False
                Else
                    Me.BackgroundImage = image
                    Me.Refresh()
                End If
                m_hasDataChanged = False

                slitValveImage = Nothing
                image = Nothing
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-09 </date>
    ''' </author>
    ''' <summary>    
    ''' Angle for rotating slitvalve
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetAngle()
        m_angle = 0
        Select Case m_pmPos
            Case SlitValvePositions.PM1
                m_angle = -90
            Case SlitValvePositions.PM2
                m_angle = 0
            Case SlitValvePositions.PM3, SlitValvePositions.HivacLLA
                m_angle = 90
            Case SlitValvePositions.LLA
                m_angle = 0
            Case SlitValvePositions.HivacTM
                m_angle = 45
        End Select
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-24 </date>
    ''' </author>
    ''' <summary>
    ''' Convert specific value to SlitValveDisplayStatus type
    ''' </summary>
    Public Shared Function ParseStatus(ByVal value As Object) As SlitValveDisplayStatus
        Dim result As SlitValveDisplayStatus = SlitValveDisplayStatus.Unknown
        Try
            TryParseStatus(value, result)
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
    ''' Convert specific value to SlitValveDisplayStatus type
    ''' </summary>
    Public Shared Function TryParseStatus(ByVal value As Object, ByRef result As SlitValveDisplayStatus) As Boolean
        Dim isSuccess As Boolean = True
        Try
            Dim strValue As String = System.Convert.ToString(value)

            If [Enum].IsDefined(GetType(SlitValveDisplayStatus), strValue) Then
                result = CType([Enum].Parse(GetType(SlitValveDisplayStatus), strValue), SlitValveDisplayStatus)
            Else
                strValue = strValue.ToLower()
                Select Case strValue
                    Case "on", "true", "open", "opened", CInt(SlitValveDisplayStatus.On).ToString()
                        result = SlitValveDisplayStatus.On
                    Case "off", "false", "close", "closed", CInt(SlitValveDisplayStatus.Off).ToString()
                        result = SlitValveDisplayStatus.Off
                    Case "unknown", "other", "unk", "unknow", "between", CInt(SlitValveDisplayStatus.Unknown).ToString()
                        result = SlitValveDisplayStatus.Unknown
                    Case "None", "none", CInt(SlitValveDisplayStatus.None).ToString()
                        result = SlitValveDisplayStatus.None
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
#End Region

End Class
