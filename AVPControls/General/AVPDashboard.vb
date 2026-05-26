Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class AVPDashboard
    Inherits AVPPanel

#Region "Fields"
    Private m_header As HeaderControl

    Public Event StatusChanged As EventHandler
#End Region

#Region "Properties"
    Protected Friend Property Header() As HeaderControl
        Get
            Return m_header
        End Get
        Set(ByVal value As HeaderControl)
            m_header = value
        End Set
    End Property

    <DefaultValue(GetType(AVPBorderStyles), "AVP3D")> _
    Public Shadows Property AVPBorderStyle() As AVPBorderStyles
        Get
            Return MyBase.AVPBorderStyle
        End Get
        Set(ByVal value As AVPBorderStyles)
            If MyBase.AVPBorderStyle <> value Then
                MyBase.AVPBorderStyle = value
            End If
        End Set
    End Property

    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Overridable Property Status() As DisplayStatus
        Get
            Return Me.m_header.Status
        End Get
        Set(ByVal value As DisplayStatus)
            If Me.m_header.Status <> value Then
                Me.m_header.Status = value
                RaiseEvent StatusChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    <DefaultValue(GetType(String), "AVPDashboard"), Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Overrides Property Text() As String
        Get
            Return Me.m_header.Text
        End Get
        Set(ByVal value As String)
            If Me.m_header.Text <> value Then
                Me.m_header.Text = value
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Public Property HeaderVisible() As Boolean
        Get
            Return m_header.Visible
        End Get
        Set(ByVal value As Boolean)
            m_header.Visible = value
        End Set
    End Property

    <DefaultValue(GetType(Integer), "28")> _
    Public Property HeaderHeight() As Integer
        Get
            Return m_header.Height
        End Get
        Set(ByVal value As Integer)
            m_header.Height = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property CommunicationVisible() As Boolean
        Get
            Return m_header.CommunicationVisible
        End Get
        Set(ByVal value As Boolean)
            m_header.CommunicationVisible = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsConnected() As Boolean
        Get
            Return m_header.IsConnected
        End Get
        Set(ByVal value As Boolean)
            m_header.IsConnected = value
        End Set
    End Property
#End Region

#Region "Events"
    Public Sub New()
        m_header = New HeaderControl()
        m_header.Dock = DockStyle.Top
        m_header.Name = "Header"
        m_header.Text = "AVPDashboard"

        MyBase.AVPBorderStyle = AVPBorderStyles.AVP3D
        Me.Controls.Add(m_header)
    End Sub

    Private Sub AVPDashboard_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        m_header.SendToBack()
    End Sub
#End Region

End Class
