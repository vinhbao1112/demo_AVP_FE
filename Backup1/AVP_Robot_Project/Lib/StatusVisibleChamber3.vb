Public Class StatusVisibleChamber3
    Inherits AVPControls.StatusObject
#Region "Class Constants & Variables"
    Private m_ticTransparentImageControl As TransparentImageControl
#End Region


#Region "Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the transparent image control that will be managed by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedTransparentImageControl() As TransparentImageControl
        Get
            Return m_ticTransparentImageControl
        End Get
        Set(ByVal value As TransparentImageControl)
            m_ticTransparentImageControl = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with transparent image control that will be managed by this object
    ''' </summary>
    ''' <param name="ticTransparentImageControl"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ticTransparentImageControl As TransparentImageControl)
        m_ticTransparentImageControl = ticTransparentImageControl
        Me.Name = m_ticTransparentImageControl.Name
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
                Case "On"
                    m_ticTransparentImageControl.Visible = False
                Case "Off"
                    m_ticTransparentImageControl.Visible = True
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''     <date> 2008-09-11</date>
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
    '''     	<name> Cao Anh Kiet </name>
    '''     	<date> 2008-09-05</date>
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
