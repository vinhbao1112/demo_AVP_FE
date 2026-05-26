Imports System.ComponentModel

''' <author>
'''     <name>Hai Tran</name>
'''     <date>2015-10-01</date>
''' </author>
''' <summary>
''' Host communication panel.
''' </summary>
''' <remarks></remarks>
Public Class AppHostCommunicationPanel
    Private m_hostStatus As String = "Offline"
    Private m_hostMode As String = "Local"

    Public Event HostStatusChanged As EventHandler
    Public Event HostModeChanged As EventHandler

    <DefaultValue(GetType(String), "Offline")> _
    Public Property HostStatus() As String
        Get
            Return m_hostStatus
        End Get
        Set(ByVal value As String)
            If m_hostStatus <> value Then
                m_hostStatus = value
                txtHostOffline.Text = m_hostStatus
                RaiseEvent HostStatusChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    <DefaultValue(GetType(String), "Local")> _
    Public Property HostMode() As String
        Get
            Return m_hostMode
        End Get
        Set(ByVal value As String)
            If m_hostMode <> value Then
                m_hostMode = value
                txtHostLocal.Text = m_hostMode
                RaiseEvent HostModeChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

End Class
