Imports AVPControls

Public Class StatusAVPStatusControl
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_managedControl As AVPStatusControlBase
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-11-13 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the binary status control that will be manage by this object
    ''' </summary>
    Public Property ManagedControl() As AVPStatusControlBase
        Get
            Return m_managedControl
        End Get
        Set(ByVal value As AVPStatusControlBase)
            m_managedControl = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-11-13 </date>
    ''' </author>
    ''' <summary>
    ''' Initalize with binary status control that will be managed by this object
    ''' </summary>
    Public Sub New(ByVal control As AVPStatusControlBase)
        Try
            m_managedControl = control
            Me.Name = m_managedControl.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''     <date> 2015-11-13 </date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            If (Value = "Other") Or (Value = "Unknown") Then ' Invalid value.
                Return
            End If
            Dim enmStatus As DisplayStatus = Utils.ConvertToDisplayStatus(Value)
            If enmStatus <> m_managedControl.Status Then
                m_managedControl.Status = enmStatus
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("Error with: " & Me.Name & " - value:" & arg.ToString() & " - " & ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''     <date> 2015-11-13 </date>
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
    '''    	<name> Hai Tran </name>
    '''     <date> 2015-11-13 </date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub

#End Region

End Class
