Public Class SL_SystemControl

#Region "Constructors & Dispose"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            btnOnline.Clickable = True
            btnOnline.ValueToBeSend = ""

            btnOffline.Clickable = True
            btnOffline.ValueToBeSend = ""

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Protected methods"
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbtOnlineStatus As New SL_StatusButton(btnOnline)
            Dim sbtOfflineStatus As New SL_StatusButton(btnOffline)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sbtOnlineStatus)
            m_stoStatusObject.AddChild(sbtOfflineStatus)
            btnOnline.ParentStatusObj = m_stoStatusObject
            btnOffline.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    Private Sub btnOnline_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnline.StatusChange
        If btnOnline.Status = SL_CustomButton.DisplayStatus.On Then
            btnOffline.Status = SL_CustomButton.DisplayStatus.Off
        ElseIf btnOnline.Status = SL_CustomButton.DisplayStatus.Off Then
            btnOffline.Status = SL_CustomButton.DisplayStatus.On
        End If
    End Sub
#End Region

#Region "Public methods"
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Set default status to show on GUI when PM disconnect.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaultStatus()
        m_stoStatusObject.RequestStatus(btnOffline.Name, "")
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Make online for Gem.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Online_Click()
        Try
            m_stoStatusObject.RequestStatus(btnOnline.Name, btnOnline.ValueToBeSend)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

End Class
