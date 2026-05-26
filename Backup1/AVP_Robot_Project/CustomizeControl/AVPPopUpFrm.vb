Imports AVPControls

Public Class AVPPopUpFrm
    Private mouseOffset As Point = New Point(0, 0)
    Private isDragDrop As Boolean = False
    Protected m_stoStatusObject As StatusObject
    Public blnGoOnline As Boolean = False
    Private m_strPermissionCode As String = String.Empty

#Region "Property"
    Public Property PopUpTitle() As String
        Get
            Return lblTitle.Text
        End Get
        Set(ByVal value As String)
            lblTitle.Text = value
        End Set
    End Property

    Public Property PermissionCode() As String
        Get
            Return m_strPermissionCode
        End Get
        Set(ByVal value As String)
            m_strPermissionCode = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Get status of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Status() As StatusObject
        Get
            If m_stoStatusObject.Name Is Nothing Then
                m_stoStatusObject.Name = Me.Name
                Me.CreateStatusTree()
            End If
            Return m_stoStatusObject
        End Get
    End Property
#End Region

#Region "Protected Sub"
    Protected Overridable Function CheckPermission() As Boolean
        Try
            Return AVPLib.ContainerData.Permission(m_strPermissionCode)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    Protected Overridable Sub CreateStatusTree()
        Try
            ''implement in child class
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Event"
    Protected Overridable Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lblTitle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTitle.MouseDown
        mouseOffset = New Point(e.Location.X, e.Location.Y)
        isDragDrop = True
    End Sub

    Private Sub lblTitle_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTitle.MouseMove
        If isDragDrop Then
            Dim point As Point = Me.Location
            Me.Location = New Point(point.X + (e.Location.X - mouseOffset.X), point.Y + (e.Location.Y - mouseOffset.Y))
            Me.Opacity = 0.5
        End If
    End Sub

    Private Sub lblTitle_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTitle.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso isDragDrop Then
            isDragDrop = False
            Me.Opacity = 1
        End If
    End Sub

    Private Sub AVPPopUpFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, btnCancel.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_stoStatusObject = New StatusObject
        ' Add any initialization after the InitializeComponent() call.

    End Sub



End Class