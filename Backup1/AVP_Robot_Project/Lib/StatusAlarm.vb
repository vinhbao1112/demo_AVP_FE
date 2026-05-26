Imports System.Windows.Forms
Public Class StatusAlarm
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_aplAlarmPanel As AlarmPanel
    Private m_lblAlarmLabel As Label
#End Region


#Region "Properties"
	''' <author>
	'''    	<name> Ngo Cao Dinh </name>
	'''    	<date> 2008-09-20</date>
	''' </author>
	''' <summary>
	''' Get or set the alarm panel that will be managed by this object
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
    Public Property ManagedAlarmPanel() As AlarmPanel
        Get
            Return m_aplAlarmPanel
        End Get
        Set(ByVal value As AlarmPanel)
            m_aplAlarmPanel = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the textbox that will be managed by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedAlarmLabel() As Label
        Get
            Return m_lblAlarmLabel
        End Get
        Set(ByVal value As Label)
            m_lblAlarmLabel = value
        End Set
    End Property

#End Region

#Region "Construtor and Destructor"
	''' <author>
	'''    	<name> Ngo Cao Dinh </name>
	'''    	<date> 2008-09-20</date>
	''' </author>
	''' <summary>
	''' Initalize with alarm panel that will be managed by this object
	''' </summary>
	''' <param name="aplAlarmPanel"></param>
	''' <remarks></remarks>
    Public Sub New(ByVal aplAlarmPanel As AlarmPanel)
        Try
            m_aplAlarmPanel = aplAlarmPanel
            Me.Name = "Alarm"

            m_aplAlarmPanel.StartAlarm()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            m_aplAlarmPanel.IsStopFlashing = False
            StatusManager.IsAlarm = True
            If (m_lblAlarmLabel.Text IsNot Nothing) Then
                m_lblAlarmLabel.Text = arg.ToString()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#Region "Public Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-20</date>
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
    '''     	<date> 2008-08-21</date>
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
