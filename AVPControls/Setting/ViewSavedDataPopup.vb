Public Class ViewSavedDataPopup
    Private Const TITLE_FORMAT As String = "{0} Setting History"

    Private m_viewData As List(Of StoredConfigData)
    Private m_result As StoredConfigData
    Private m_configName As String = String.Empty
    Private m_configOf As ConfigDevice
    Private m_configPanel As StoredConfigPanel
    Private m_hasDataChanged As Boolean

    Public Enum ConfigDevice
        LoadLock
        Robot
    End Enum

#Region "Properties"
    Public Property ConfigOf() As ConfigDevice
        Get
            Return m_configOf
        End Get
        Set(ByVal value As ConfigDevice)
            m_configOf = value
            If m_configPanel IsNot Nothing Then
                m_configPanel.Dispose()
            End If
            Select Case m_configOf
                Case ConfigDevice.LoadLock
                    m_configPanel = New LLConfigPanel()
                Case ConfigDevice.Robot
                    m_configPanel = New RobotConfigPanel()
                Case Else
                    m_configPanel = New StoredConfigPanel
            End Select
            Me.SuspendLayout()

            m_configPanel.Name = "ConfigPanel"
            m_configPanel.Location = New Point(18, 16)
            Me.pnlRight.Controls.Clear()
            Me.pnlRight.Controls.Add(m_configPanel)
            Me.Width = m_configPanel.Width + 170
            Me.Height = m_configPanel.Height + 250
            Me.UpdateButtons()

            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Set
    End Property

    Protected Property ConfigPanel() As StoredConfigPanel
        Get
            Return m_configPanel
        End Get
        Set(ByVal value As StoredConfigPanel)
            m_configPanel = value
        End Set
    End Property

    Public Property ViewData() As List(Of StoredConfigData)
        Get
            Return m_viewData
        End Get
        Set(ByVal value As List(Of StoredConfigData))
            m_viewData = value
        End Set
    End Property

    Public ReadOnly Property Result() As StoredConfigData
        Get
            Return m_result
        End Get
    End Property

    Public Property ConfigName() As String
        Get
            Return m_configName
        End Get
        Set(ByVal value As String)
            If m_configName <> value Then
                m_configName = value
                
                Dim strTitle As String = m_configName
                If String.IsNullOrEmpty(strTitle) Then
                    strTitle = m_configOf.ToString()
                End If

                Me.lblHeader.Text = String.Format(Me.lblHeader.Tag.ToString(), strTitle)
                Me.Text = String.Format(TITLE_FORMAT, strTitle)

            End If
        End Set
    End Property

    Public ReadOnly Property HasDataChanged() As Boolean
        Get
            Return m_hasDataChanged
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.AllowAutoClose = True
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Public Sub New(ByVal viewData As List(Of StoredConfigData))

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.AllowAutoClose = True
        Me.ViewData = viewData
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    ''' <summary>
    ''' Show saved data.
    ''' </summary>
    Protected Overridable Sub UpdateView()
        Try
            Dim index As Integer = Me.lstSavedItems.SelectedIndex
            If index < 0 OrElse m_viewData Is Nothing OrElse m_viewData.Count = 0 Then
                Me.lblDate.Text = String.Empty
                Me.lblVersion.Text = String.Empty
                Me.ClearViewData()
                Return
            End If

            Dim configItem As StoredConfigData = Me.ViewData(index)

            Me.lblDate.Text = configItem.SavedOn
            Me.lblVersion.Text = configItem.Version
            Me.UpdateViewData(configItem)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    ''' <summary>
    ''' Show saved data.
    ''' </summary>
    Protected Overridable Sub UpdateList()
        Try
            Me.lstSavedItems.Items.Clear()
            If Me.ViewData Is Nothing OrElse Me.ViewData.Count = 0 Then
                Me.lstSavedItems.Text = "No item."
                Me.btnDeleteItem.Enabled = False
                Me.btnOK.Enabled = False
                Return
            End If

            Me.btnDeleteItem.Enabled = True
            Me.btnOK.Enabled = CBool(IIf(m_configOf = ConfigDevice.Robot, False, True))
            For index As Integer = 1 To Me.ViewData.Count
                Me.lstSavedItems.Items.Add("Saved #" & index.ToString())
            Next
            Me.lstSavedItems.SelectedIndex = 0
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-11</date>
    ''' </author>
    ''' <summary>
    ''' Show/hide buttons.
    ''' </summary>
    Private Sub UpdateButtons()
        Select Case m_configOf
            Case ConfigDevice.Robot
                Me.btnOK.Visible = False
                Me.btnCancel.Visible = True
                Me.btnCancel.Text = "Close"
                Me.btnCancel.Left = Convert.ToInt32((Me.Width - Me.btnCancel.Width) / 2.0F)

            Case Else
                Me.btnOK.Visible = True
                Me.btnOK.Left = Convert.ToInt32(Me.Width / 2.0F - Me.btnOK.Width - 3)

                Me.btnCancel.Visible = True
                Me.btnCancel.Text = "Cancel"
                Me.btnCancel.Left = Me.btnOK.Right + 6
        End Select
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-11</date>
    ''' </author>
    ''' <summary>
    ''' Clear all view data in form.
    ''' </summary>
    Private Sub ClearViewData()
        If Me.ConfigPanel IsNot Nothing AndAlso Not Me.ConfigPanel.IsDisposed Then
            Me.ConfigPanel.ClearData()
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-11</date>
    ''' </author>
    ''' <summary>
    ''' Set view data.
    ''' </summary>
    Private Sub UpdateViewData(ByVal configItem As StoredConfigData)
        If Me.ConfigPanel IsNot Nothing AndAlso Not Me.ConfigPanel.IsDisposed Then
            Me.ConfigPanel.SetData(configItem)
        End If
    End Sub

#End Region

#Region "Events"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    Private Sub ViewSavedDataPopup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            m_result = Nothing
            UpdateList()
            UpdateView()
            UpdateButtons()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-13</date>
    ''' </author>
    ''' <summary>
    ''' Show saved data on select item.
    ''' </summary>
    Private Sub lstSavedItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSavedItems.SelectedIndexChanged
        UpdateView()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-13</date>
    ''' </author>
    ''' <summary>
    ''' OK button event.
    ''' </summary>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Dim index As Integer = lstSavedItems.SelectedIndex

            If m_viewData IsNot Nothing AndAlso index >= 0 AndAlso m_viewData.Count > index Then
                m_result = m_viewData(index)
            Else
                m_result = Nothing
            End If

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-13</date>
    ''' </author>
    ''' <summary>
    ''' Cancel button event.
    ''' </summary>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_result = Nothing
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-13</date>
    ''' </author>
    ''' <summary>
    ''' Delete saved item.
    ''' </summary>
    Private Sub btnDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteItem.Click
        Try
            If m_viewData IsNot Nothing AndAlso lstSavedItems.SelectedIndex >= 0 Then
                Dim confirmBox As New AVPMessageBox(Me.Text, "Would you like to delete this item?", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.YesNo)
                If confirmBox.ShowDialog = Windows.Forms.DialogResult.OK Then
                    m_viewData.RemoveAt(lstSavedItems.SelectedIndex)
                    m_hasDataChanged = True
                    Me.UpdateList()
                    Me.UpdateView()
                End If
                confirmBox.Dispose()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub
#End Region

End Class