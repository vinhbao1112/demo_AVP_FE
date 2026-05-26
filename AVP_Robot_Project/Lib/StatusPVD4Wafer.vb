Public Class StatusPVD4Wafer
    Inherits AVPControls.StatusObject

    Private m_managedControl As PVD4WaferControl

    Public Property ManagedControl() As PVD4WaferControl
        Get
            Return m_managedControl
        End Get
        Set(ByVal value As PVD4WaferControl)
            m_managedControl = value
        End Set
    End Property

    Public Sub New(ByVal control As PVD4WaferControl)
        Try
            m_managedControl = control
            Me.Name = m_managedControl.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-30 </date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            AVP_Robot_Project.Utils.ChangeWaferStatusColor(Value, Me.Parent.Parent.Name)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-30 </date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-30 </date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub

End Class
