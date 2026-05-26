Imports System.ComponentModel

Public Class AVPPopupForm

#Region "Fields"
    Protected m_stoStatusObject As New StatusObject
    Private m_permissionCode As String = String.Empty
    Private m_isOnline As Boolean
    'Time auto close pannel
    Protected m_iClosingTime As Integer = 300
#End Region

#Region "Properties"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-19</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indication permission code of the form.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property PermissionCode() As String
        Get
            Return m_permissionCode
        End Get
        Set(ByVal value As String)
            m_permissionCode = value
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-19</date>
    ''' </author>
    ''' <summary>
    ''' Gets status object of this form.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overridable ReadOnly Property Status() As StatusObject
        Get
            If m_stoStatusObject.Name Is Nothing Then
                m_stoStatusObject.Name = Me.Name
                Me.CreateStatusTree()
            End If

            Return m_stoStatusObject
        End Get
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-19</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates the online status.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Overridable Property IsOnline() As Boolean
        Get
            Return m_isOnline
        End Get
        Set(ByVal value As Boolean)
            If m_isOnline = value Then
                Return
            End If

            m_isOnline = value
            OnOnlineChanged()
        End Set
    End Property
#End Region

#Region "Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-19</date>
    ''' </author>
    ''' <summary>
    ''' Check user permission.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function CheckPermission() As Boolean
        Return True
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub CreateStatusTree()
        ' Implement in childs.
    End Sub
#End Region

#Region "Events"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-19</date>
    ''' </author>
    ''' <summary>
    ''' Close form when user press down Escape key.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPPopupForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DoClose()
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-19</date>
    ''' </author>
    ''' <summary>
    ''' Do action on online status changed.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub OnOnlineChanged()
        ' Do action on online status changed.
    End Sub
#End Region

End Class