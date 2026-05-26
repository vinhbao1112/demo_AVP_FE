Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class AVPStatusControlBase
    Protected m_status As DisplayStatus = DisplayStatus.Off
    Private m_lastStatus As DisplayStatus = DisplayStatus.Off

    ' Hai Tran: (2015-09-07) Event for status changed
    Public Event StatusChanged As EventHandler(Of StatusChangedEventArgs)

#Region "Properties"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicating status of this control
    ''' </summary>
    <DefaultValue(GetType(DisplayStatus), "Off"), Category("AVP Properties"), Description("Get or set a value indicating status of this control.")> _
    Public Overridable Property Status() As DisplayStatus
        Get
            Return m_status
        End Get
        Set(ByVal value As DisplayStatus)
            If m_status <> value Then
                m_lastStatus = m_status
                m_status = value
                UpdateView()
                OnStatusChanged(New StatusChangedEventArgs(m_lastStatus, m_status))
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-14 </date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates the last changed status of this control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property LastStatus() As DisplayStatus
        Get
            Return m_lastStatus
        End Get
    End Property
#End Region

#Region "Overridable Methods"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Method called when status changed
    ''' </summary>
    Protected Overridable Sub OnStatusChanged(ByVal e As StatusChangedEventArgs)
        RaiseEvent StatusChanged(Me, e)
    End Sub

#End Region
End Class

Public Class StatusChangedEventArgs
    Inherits EventArgs

    Private m_lastStatus As DisplayStatus
    Private m_status As DisplayStatus

#Region "Properties"
    ''' <summary>
    ''' Gets or sets a value indicates the status before change.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LastStatus() As DisplayStatus
        Get
            Return m_lastStatus
        End Get
        Set(ByVal value As DisplayStatus)
            m_lastStatus = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicates the current changed status.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Status() As DisplayStatus
        Get
            Return m_status
        End Get
        Set(ByVal value As DisplayStatus)
            m_status = value
        End Set
    End Property
#End Region

#Region "Methods"
    Public Sub New(ByVal lastStatus As DisplayStatus, ByVal currentStatus As DisplayStatus)
        m_lastStatus = lastStatus
        m_status = currentStatus
    End Sub
#End Region

End Class
