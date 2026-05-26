Imports System.ComponentModel

Public Class AVPDeviceControlBase
    Protected m_isOnline As Boolean
    Protected m_isActive As Boolean = True
    Protected m_isConnected As Boolean
    ''' <summary>
    ''' Occurs when the device online status changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event OnlineChanged As EventHandler
    ''' <summary>
    ''' Occurs when the control active status changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ActivationChanged As EventHandler
    ''' <summary>
    ''' Occurs when the device connection status changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ConnectionChanged As EventHandler


#Region "Properties"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicating whether the divice is online.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False"), Category("AVP Device"), Description("Get or set a value indicating whether the device is online.")> _
    Public Property IsOnline() As Boolean
        Get
            Return m_isOnline
        End Get
        Set(ByVal value As Boolean)
            If m_isOnline <> value Then
                m_isOnline = value
                OnOnlineChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicating whether the device is active for action on it.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "True"), Category("AVP Device"), Description("Get or set a value indicating whether the device is enabled for action on it.")> _
    Public Property IsActive() As Boolean
        Get
            Return m_isActive
        End Get
        Set(ByVal value As Boolean)
            If m_isActive <> value Then
                m_isActive = value
                OnActivationChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicating whether the device is connected.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False"), Category("AVP Device"), Description("Get or set a value indicating whether the device is connected.")> _
    Public Property IsConnected() As Boolean
        Get
            Return m_isConnected
        End Get
        Set(ByVal value As Boolean)
            If m_isConnected <> value Then
                m_isConnected = value
                OnConnectionChanged(EventArgs.Empty)
            End If
        End Set
    End Property
#End Region

#Region "Events"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Raise the OnlineChanged event.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnOnlineChanged(ByVal e As EventArgs)
        RaiseEvent OnlineChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Raise the ActivationChanged event.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnActivationChanged(ByVal e As EventArgs)
        RaiseEvent ActivationChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Raise the ConnectionChanged event.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnConnectionChanged(ByVal e As EventArgs)
        RaiseEvent ConnectionChanged(Me, e)
    End Sub

#End Region

End Class
