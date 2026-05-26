Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum

' Notify the communication status changed
Public Delegate Sub CommunicationState(ByVal state As Boolean)

Public Class StatusColorLabel
    Inherits AVPControls.StatusObject
#Region "Class Constants & Variables"
    Private m_lblLabel As Label
    Private m_strText As String
    Private m_evtCommStateChanged As CommunicationState
#End Region


#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the label that will be managed by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property ManagedLabel() As Label
        Get
            Return m_lblLabel
        End Get
        Set(ByVal value As Label)
            m_lblLabel = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-05-07</date>
    ''' </author>
    ''' <summary>
    ''' State changed event
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>s
    Public Property CommStateChanged() As CommunicationState
        Get
            Return m_evtCommStateChanged
        End Get
        Set(ByVal value As CommunicationState)
            m_evtCommStateChanged = value
        End Set
    End Property

#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with label that will be managed by this object
    ''' </summary>
    ''' <param name="lblLabel"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal lblLabel As Label)
        Try
            m_lblLabel = lblLabel
            Me.Name = m_lblLabel.Name
            m_strText = m_lblLabel.Text
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Dat Do </name>
    '''     <date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            Dim arr As String() = Nothing
            Dim strColor As String = String.Empty
            Dim COMMUNICATION_OK As String = MessageMapper.GetColorValue(COMMUNICATION_COLOR_ONLINE)
            Select Case Value
                Case STR_ON, Boolean.TrueString  ''for Led Communication/Robot Led Online/Offline
                    strColor = MessageMapper.GetColorValue(COMMUNICATION_COLOR_ONLINE)
                Case STR_OFF, Boolean.FalseString ''for Led Communication/Robot Led Online/Offline
                    strColor = MessageMapper.GetColorValue(COMMUNICATION_COLOR_OFFLINE)
                Case "ONLINE" ''for Chamber Online/Offline
                    strColor = MessageMapper.GetColorValue(CHAMBER_COLOR_ONLINE)
                    m_lblLabel.Text = m_strText.Replace(ConstantAndEnum.STRING_OFFLINE, ConstantAndEnum.STRING_ONLINE)
                Case "OFFLINE" ''for Chamber Online/Offline
                    strColor = MessageMapper.GetColorValue(CHAMBER_COLOR_OFFLINE)
                    m_lblLabel.Text = m_strText
                Case ConstantAndEnum.STRING_ONLINE ''for LoadLock Online/Offline
                    strColor = MessageMapper.GetColorValue(CHAMBER_COLOR_ONLINE)
                    m_lblLabel.Text = m_strText.Replace(ConstantAndEnum.STRING_OFFLINE, ConstantAndEnum.STRING_ONLINE)
                Case ConstantAndEnum.STRING_OFFLINE ''for LoadLock Online/Offline
                    strColor = MessageMapper.GetColorValue(CHAMBER_COLOR_OFFLINE)
                    m_lblLabel.Text = m_strText
            End Select
            Dim bRaiseEvent As Boolean = False
            If (Not String.IsNullOrEmpty(strColor)) Then
                Dim destinationColor As Color = Color.FromName(strColor)
                If m_lblLabel.BackColor <> destinationColor Then
                    m_lblLabel.BackColor = destinationColor
                    bRaiseEvent = True
                End If
            Else ''if strcolor not found, use color Yellow as default
                If m_lblLabel.BackColor <> Color.Yellow Then
                    m_lblLabel.BackColor = Color.Yellow
                End If
            End If

            If bRaiseEvent And (CommStateChanged <> Nothing) Then
                If m_lblLabel.BackColor = Color.FromName(COMMUNICATION_OK) Then
                    CommStateChanged.Invoke(True)
                Else
                    CommStateChanged.Invoke(False)
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
    ''' <author>
    '''     	<name> Ngo Cao Dinh </name>
    '''     	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub

#End Region

End Class
