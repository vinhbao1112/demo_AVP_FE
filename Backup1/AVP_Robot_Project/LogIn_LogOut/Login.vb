Imports AVPControls

Public Class Login
#Region "Members"
    Public Group As String = ""

    Private m_dialogListAllUsers As ListAllUsers = Nothing
#End Region

#Region "Buttons Event"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-24</date>
    ''' </author>
    ''' <summary>
    ''' Login
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        AVPLib.Log.guiLogger.Info("Enter btnLogin_Click")
        Try
            If Me.cmbUsername.Text.Length = 0 Or Me.cmbUsername.Text.Length = 0 Then
                MessageBox.Show("Enter username and password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Main Screen] Login Failed: Missing username and password")
                AVPLib.Log.guiLogger.Info("Leave btnLogin_Click")
                Return
            End If

            Dim username As String = Trim(Me.cmbUsername.Text)
            Dim password As String = Me.txtPassword.Text
            Dim User As AVPLib.DBUser = AVPLib.ContainerData.User(username)
            If (User.Password = password And User.Disable = False) Then
                '# Rem cramble password. Will add back later when needed.
                ' If (EncryptionHelper.Decrypt(User.Password) = password And User.Disable = False) Then
                AVPLib.ContainerData.UserLogin = User
                Me.Group = User.Group.Name
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Main Screen] Login Successed with Username " + username)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                For i As Integer = 1 To AVPRobotMain.MaxChamber2Install
                    UpdateUserLevel(AVPLib.ConstEnum.Chamber & i.ToString(), User.Group.Name)
                Next
                If ContainerForm.RecipeEditor IsNot Nothing Then
                    If ContainerForm.RecipeEditor.tabEditorRecipe.TabPages.Count > 0 Then
                        ContainerForm.RecipeEditor.tabEditorRecipe.SelectedTab = ContainerForm.RecipeEditor.tabEditorRecipe.TabPages(0)
                        ContainerForm.RecipeEditor.Refresh()
                    End If
                End If
                '#06/23/2011 
                '#-	Interal bug: Auto log off function run incorrect.
                '#Begin fix: when user log in, change system status = None to count exactly
                AVPRobotMain.m_systemStatus = AVPRobotMain.SystemStatus.None
                '#End fix

                If ContainerForm.SystemSetup IsNot Nothing Then
                    If Me.Group = "Administrator" Then
                        ContainerForm.SystemSetup.grpResetScheduler.Visible = True
                    Else
                        ContainerForm.SystemSetup.grpResetScheduler.Visible = False
                    End If
                End If
            Else
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Main Screen] Login Failed with Username " + username)

                'MessageBox.Show("Username and Password is not correct", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Utils.ShowAVPMessageBox("Username and Password is not correct", "Login", MessageBoxIcon.Error, MessageBoxButtons.OK)

            End If
        Catch ex As Exception
            'MessageBox.Show("Username and Password is not correct", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Utils.ShowAVPMessageBox("Username and Password is not correct", "Login", MessageBoxIcon.Error, MessageBoxButtons.OK)

            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Main Screen] Login Failed")
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnLogin_Click")
    End Sub

    Private Sub btnLogOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogOut.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-24</date>
    ''' </author>
    ''' <summary>
    ''' Close form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-24</date>
    ''' </author>
    ''' <summary>
    ''' KeyDown F10 that default root
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Login_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        AVPLib.Log.guiLogger.Info("Enter Login_KeyDown")
        Try
            If AVPLib.RobotConfigurationValues.REAL_DEVICE_INSTALLED Then
                ''turn off function F10
                Exit Sub
            End If
            If e.KeyCode = Keys.F10 Then
                Dim User As AVPLib.DBUser = AVPLib.ContainerData.User("Admin")
                Me.cmbUsername.Text = User.Username
                Me.txtPassword.Text = User.Password
                '# Rem cramble password. Will add back later when needed.
                'Me.txtPassword.Text = EncryptionHelper.Decrypt(User.Password)
                btnLogin_Click(Nothing, Nothing)
            End If
            ''
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Login_KeyDown")
    End Sub

    Private Sub UpdateUserLevel(ByVal ChamberName As String, ByVal UserLevel As String)
        AVPLib.Log.guiLogger.Info("Enter UpdateUserLevel")
        Try
            Dim ReplyValues As ArrayList = New ArrayList()
            Dim strReplyValue As String = UserLevel
            ReplyValues.Add(strReplyValue)

            Dim PropertyNames As ArrayList = New ArrayList()

            PropertyNames.Add("ProcessMonitor_UserLevel_Readback")

            Dim chamberModule As AVPLib.SystemModule = Nothing
            If AVPLib.ContainerData.IsChamberVisible(ChamberName, chamberModule) _
                    AndAlso (chamberModule.Type = AVPLib.SystemModule.ModuleType.PVD) Then
                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ChamberName, PropertyNames, ReplyValues)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave UpdateUserLevel")
    End Sub
#End Region

    Private Sub txtPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.Click
        Dim pad As New KeyPad
        Dim Value As String = txtPassword.Text
        If pad.DisplayKeypad(Value, "Please input password", True) = Windows.Forms.DialogResult.OK Then
            txtPassword.Text = Value
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ActiveControl = cmbUsername
        '#06/23/2011 
        '#-	AVP. Show all user name and allow them to select which name to login.
        '#Begin fix
        cmbUsername.Items.Clear()
        Dim listUser As ArrayList = AVPLib.ContainerData.ListUser
        For Each Username As String In listUser
            Dim User As AVPLib.DBUser = AVPLib.ContainerData.User(Username)
            If User.Disable = False Then       'Do not show users that disable.
                cmbUsername.Items.Add(Username)
            End If
        Next
        '#End fix.
    End Sub

    Private Sub cmbUsername_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmbUsername.MouseDown
        Const MOUSE_POS As Integer = 190
        Try
            If e.X < MOUSE_POS Then
                Dim pad As New KeyPad
                Dim Value As String = cmbUsername.Text
                If pad.DisplayKeypad(Value, "Please input username", False) = Windows.Forms.DialogResult.OK Then
                    cmbUsername.Text = Value
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnShowAllUserName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAllUserName.Click
        Try
            m_dialogListAllUsers.ShowDialog()

            ' #4538: [KhoiHa 02/13/2014][CX5-PVD2R4]
            ' After user select names and click OK from the 40 user list, auto tab to password text.
            If String.IsNullOrEmpty(Me.cmbUsername.Text) = False Then
                Me.txtPassword.Focus()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_dialogListAllUsers = New ListAllUsers(Me)

    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.DialogResult = Windows.Forms.DialogResult.Abort
    End Sub
End Class