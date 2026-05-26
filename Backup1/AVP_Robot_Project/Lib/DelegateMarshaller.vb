Imports System.Threading

Public NotInheritable Class DelegateMarshaler
    ' Methods
    Private Sub New(ByVal synchronizationContext As SynchronizationContext)
        m_synchronizationContext = synchronizationContext
    End Sub

    ' NOTE: This shared method must be called from UI thread.
    Public Shared Function Create() As DelegateMarshaler
        If (SynchronizationContext.Current Is Nothing) Then
            Throw New InvalidOperationException("No SynchronizationContext exists for the current thread.")
        End If
        Return New DelegateMarshaler(SynchronizationContext.Current)
    End Function

    Public Sub Invoke(Of T)(ByVal action As Threading.SendOrPostCallback, ByVal arg As T)
        If Not IsMarshalRequired Then
            Action.Invoke(arg)
        Else
            m_synchronizationContext.Send(Action, arg)
        End If
    End Sub

    ' Properties
    Private ReadOnly Property IsMarshalRequired() As Boolean
        Get
            Return (Not m_synchronizationContext Is SynchronizationContext.Current)
        End Get
    End Property


    ' Fields
    Private m_synchronizationContext As SynchronizationContext
End Class
