Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Public Class StatusColorButton
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_btnButton As Button
    Private m_strOnText As String
    Private m_strOffText As String

    ' to store the information about regent status
    ' if user click abort this flag will be turn on (aborting)
    ' if AVP received a aborted message from Equipment, this flag will be turn on (aborted)
    Private m_blAborted As Boolean = False
#End Region


#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the button that will be managed by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedBButton() As Button
        Get
            Return m_btnButton
        End Get
        Set(ByVal value As Button)
            m_btnButton = value
        End Set
    End Property
    Public Property Abort() As Boolean
        Get
            Return m_blAborted
        End Get
        Set(ByVal value As Boolean)
            m_blAborted = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the text of button of on status
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
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the text of button of off status
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

#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with button that will be managed by this object
    ''' </summary>
    ''' <param name="btnButton"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal btnButton As Button)
        Try
            m_btnButton = btnButton
            Me.Name = m_btnButton.Name
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
            Select Case Value
                Case STRING_ON
                    'Dim destinationColor As Color = Color.FromName(MessageMapper.GetColorValue(REGENBUTTON_COLOR_ONLINE)) 'Color.Lime
                    If m_btnButton.Tag = STRING_ON Then
                        Return
                    End If
                    m_btnButton.Tag = STRING_ON
                    m_btnButton.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
                    'End If
                    If (m_strOnText IsNot Nothing) Then
                        m_btnButton.Text = Value '  m_strOnText
                    End If
                Case STRING_OFF
                    'Dim destinationColor As Color = Color.FromName(MessageMapper.GetColorValue(REGENBUTTON_COLOR_OFFLINE))
                    If m_btnButton.Tag = STRING_OFF Then
                        Return
                    End If
                    m_btnButton.Tag = STRING_OFF
                    m_btnButton.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
                    If (m_strOffText IsNot Nothing) Then
                        m_btnButton.Text = Value '  m_strOffText
                    End If
                    Abort = False

                Case AVPLib.ConstEnum.Abort
                  If (m_btnButton.Name.Contains("btnRegen")) Then
                        m_btnButton.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite 'Color.FromName(MessageMapper.GetColorValue(REGENBUTTON_COLOR_OFFLINE))
                        m_btnButton.Tag = STRING_OFF
                        Abort = True
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-17</date>
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
