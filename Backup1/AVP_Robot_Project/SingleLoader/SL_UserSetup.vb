Imports AVPLib.ConstEnum
Imports AVPControls

Public Class SL_UserSetup
#Region "Members"
    Private m_blnIsLoadingUser As Boolean = False
    Private m_blnfirstLoad As Boolean = False
    Private Saving As Boolean = False
    Private m_UserDefaultAccessMap As Hashtable = Nothing
    Private Const SCREENS_NODE As String = "ScreensNode"
    Private Const MAINTENANCE_NODE As String = "MaintenanceNode"
#End Region

#Region "Load Form"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Load UserSetup_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UserSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            myImageList.Images.Add(Global.AVP_Robot_Project.My.Resources.Resources.permission)
            myImageList.Images.Add(Global.AVP_Robot_Project.My.Resources.Resources.permission)
            If m_UserDefaultAccessMap Is Nothing Then
                m_UserDefaultAccessMap = New Hashtable()
            End If
            m_UserDefaultAccessMap = AVPLib.ContainerDAO.GetListOfDefaultAccess

            Me.ClearForm()
            Me.loadCmbGroup()
            Me.LoadUser()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' load CmbGroup
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadCmbGroup()
        Try
            Me.m_blnfirstLoad = True
            Dim listGroup As ArrayList = AVPLib.ContainerData.ListGroup
            Me.cmbGroup.ValueMember = "Id"
            Me.cmbGroup.DisplayMember = "Name"
            Me.cmbGroup.DataSource = listGroup
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' load User
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadUser()
        Try
            LoadUserName(-1)
            Try
                If (AVPLib.ContainerData.UserLogin IsNot Nothing) Then
                    LoadUserDetail(AVPLib.ContainerData.UserLogin.Username)  'load User Login.
                End If
            Catch ex As Exception
                DGVSystemUser_CellClick(Nothing, Nothing) 'User don't Login
            End Try
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' LoadUserName
    ''' </summary>
    ''' <param name="focus"></param>
    ''' <remarks></remarks>
    Private Sub LoadUserName(ByVal focus As Integer)
        Try
            Me.LoadUserField()

            Dim listUser As ArrayList = AVPLib.ContainerData.ListUser
            Dim dtUser As DataTable = New DataTable()
            Dim rowSelected As Integer = IIf((focus = -1), 0, focus)
            Dim selected As Boolean = False
            dtUser.Columns.Add("Username", GetType(String))
            For Each Username As String In listUser
                Dim drUser As DataRow = dtUser.NewRow()
                drUser("Username") = Username
                dtUser.Rows.Add(drUser)
                If focus = -1 Then
                    Try
                        If AVPLib.ContainerData.UserLogin IsNot Nothing _
                            AndAlso AVPLib.ContainerData.UserLogin.Username IsNot Nothing Then

                            If Username = AVPLib.ContainerData.UserLogin.Username Then
                                selected = True
                            ElseIf selected = False Then
                                rowSelected += 1
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Next

            Me.DGVSystemUser.DataSource = dtUser

            If rowSelected >= 0 And rowSelected <= dtUser.Rows.Count - 1 Then
                Me.DGVSystemUser.CurrentCell = Me.DGVSystemUser.Item(0, rowSelected)
                Me.DGVSystemUser_CellClick(DGVSystemUser.CurrentCell, Nothing)
            End If

            Me.DGVSystemUser.Refresh()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Load UserField
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadUserField()
        Me.gcSystemUsers.DataPropertyName = "Username"
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' LoadUserDetail
    ''' </summary>
    ''' <param name="Username"></param>
    ''' <remarks></remarks>
    Private Sub LoadUserDetail(ByVal Username As String)
        Try
            m_blnIsLoadingUser = True
            treeAcessControlListView.Nodes.Clear()
            ' Add to the tree view
            Dim TreeScreenNode As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Screens")
            TreeScreenNode.Name = SCREENS_NODE
            TreeScreenNode.StateImageIndex = 1
            TreeScreenNode.Checked = True
            Me.treeAcessControlListView.Nodes.Add(TreeScreenNode)

            Dim User As AVPLib.DBUser = AVPLib.ContainerData.User(Username)
            Me.txtName.Text = User.Username
            Me.txtPassword.Text = User.Password
            '# Rem cramble password. Will add back later when needed.
          '  Me.txtPassword.Text = EncryptionHelper.Decrypt(User.Password)
            Me.chkDisableUser.Checked = User.Disable
            Me.cmbGroup.SelectedValue = User.Group.Id

            For Each UserPermission As AVPLib.DBUserPermission In User.ListPermission
                Dim screenNode As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(UserPermission.Name)
                screenNode.Checked = UserPermission.Permit
                screenNode.Name = UserPermission.Code
                screenNode.StateImageIndex = IIf(UserPermission.Permit, 1, 0)
                screenNode.Text = AVPLib.Utils.chamberID2ChamberName(UserPermission.Name)
                If String.IsNullOrEmpty(UserPermission.ParentPermission) = False Then
                    For Each Fnode As TreeNode In TreeScreenNode.Nodes
                        If Fnode.Text = UserPermission.ParentPermission Then
                            Fnode.Nodes.Add(screenNode)
                            Exit For
                        End If
                    Next
                Else
                    If UserPermission.Name.Contains(ConstantAndEnum.CHAMBER) Then
                        Dim objConfig As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(UserPermission.Name)
                        If (objConfig IsNot Nothing) Then
                            TreeScreenNode.Nodes.Add(screenNode)
                        End If
                    Else
                        TreeScreenNode.Nodes.Add(screenNode)
                    End If
                End If
            Next
            TreeScreenNode.Expand()

            'Load recipe parameters
            Dim maintenanceNode As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recipe Parameter Control")
            maintenanceNode.Name = MAINTENANCE_NODE
            maintenanceNode.StateImageIndex = 1
            maintenanceNode.Checked = True
            Me.treeAcessControlListView.Nodes.Add(maintenanceNode)

            For Each dbChamber As AVPLib.DBChamber In User.ListOfDBChamber.Values
                'Chamber Type
                Dim rootNode As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(dbChamber.ChamberType)
                rootNode.Name = dbChamber.ChamberType
                rootNode.StateImageIndex = 0
                rootNode.Text = dbChamber.ChamberType & " (" & dbChamber.ChamberDescription & ")"
                rootNode.Checked = True
                rootNode.StateImageIndex = 1
                maintenanceNode.Nodes.Add(rootNode)

                For Each dbGroup As AVPLib.DBParameterGroup In dbChamber.ListGroupParameters
                    'Group Node
                    Dim groupNode As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(dbGroup.GroupName)
                    groupNode.Name = dbGroup.GroupName
                    groupNode.StateImageIndex = 0
                    groupNode.Text = dbGroup.GroupName
                    groupNode.Checked = True
                    groupNode.StateImageIndex = 1
                    rootNode.Nodes.Add(groupNode)

                    For Each dbParameter As AVPLib.DBParameter In dbGroup.Parameters
                        'Parameter Node
                        Dim parameterNode As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(dbParameter.Name)
                        parameterNode.Name = dbParameter.Name
                        parameterNode.StateImageIndex = 0
                        parameterNode.Text = dbParameter.Name
                        parameterNode.Checked = IIf((User.Username <> "Admin"), dbParameter.ReadWrite, True)
                        groupNode.Nodes.Add(parameterNode)
                    Next
                Next
            Next

            Me.treeAcessControlListView.Refresh()

            If AVPLib.ContainerData.UserLogin IsNot Nothing Then
                If User.Username = "Admin" Then
                    Me.btnDelete.Enabled = False
                    'Me.btnSave.Enabled = False
                    btnReset.Enabled = False
                    btnNew.Enabled = False
                ElseIf AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_005) Then
                    Me.btnDelete.Enabled = True
                    Me.btnSave.Enabled = True
                    btnNew.Enabled = True
                    btnReset.Enabled = True
                End If
                Me.treeAcessControlListView.Editable = (User.Username <> "Admin")
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' DGVSystemUser_CellClick
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DGVSystemUser_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVSystemUser.CellClick
        Try
            Me.Saving = False
            Me.txtName.BackColor = System.Drawing.SystemColors.Control
            Me.txtName.Cursor = Cursors.Default
            Dim selected As Integer = Me.DGVSystemUser.SelectedCells(0).RowIndex
            Dim Username As String = CType(Me.DGVSystemUser.DataSource, DataTable).Rows(selected)("Username").ToString()
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[User Setup] Select Username =" + Username)
            Me.LoadUserDetail(Username)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Buttons Event"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' txtName_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        AVPLib.Log.guiLogger.Info("Enter txtName_TextChanged")
        Try
            Me.txtName.Text = Utils.RemoveSpecialChar(Me.txtName.Text)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtName_TextChanged")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' btnNew_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        AVPLib.Log.guiLogger.Info("Enter btnNew_Click")
        Try
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[User Setup] New User")
            m_blnIsLoadingUser = False
            Me.Saving = True
            Me.txtName.BackColor = System.Drawing.SystemColors.Window
            Me.txtName.Cursor = Cursors.Hand
            Me.txtName.Text = ""
            Me.txtPassword.Text = ""
            Me.cmbGroup.SelectedValue = 1
            Me.chkDisableUser.Checked = False

            Check_UnCheckAll(True)
            Me.treeAcessControlListView.Editable = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnNew_Click")
    End Sub
    'check and uncheck all node in tree access
    Private Sub Check_UnCheckAll(ByVal blnCheck As Boolean)
        For Each node As TreeNode In treeAcessControlListView.Nodes
            node.Checked = blnCheck
            For Each childNode As TreeNode In node.Nodes
                childNode.Checked = blnCheck
                For Each childrenNode As TreeNode In childNode.Nodes
                    childrenNode.Checked = blnCheck
                    For Each ccNode As TreeNode In childrenNode.Nodes
                        ccNode.Checked = blnCheck
                    Next
                Next
            Next
        Next
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' btnDelete_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        AVPLib.Log.guiLogger.Info("Enter btnDelete_Click")
        Try
            If String.IsNullOrEmpty(Me.txtName.Text) Then
                AVPLib.Log.guiLogger.Info("Leave btnDelete_Click")
                Return
            End If

            Dim User As AVPLib.DBUser = AVPLib.ContainerData.User(Me.txtName.Text)
            Dim dlg As DialogResult = Utils.ShowAVPMessageBox("Do You Want to Delete this user (" + User.Username + ") ?", "Delete User", MessageBoxIcon.Question)
            If dlg = DialogResult.OK Then
                AVPLib.ContainerData.DeleteUser(User)
                Dim selected As Integer = Me.DGVSystemUser.SelectedCells(0).RowIndex
                Me.DGVSystemUser.CurrentCell = Me.DGVSystemUser.Item(0, selected - 1)
                Me.DGVSystemUser_CellClick(Nothing, Nothing)
                Me.DGVSystemUser.Rows.RemoveAt(selected)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[User Setup] Deleted Username =" + Me.txtName.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnDelete_Click")
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-14-04</date>
    ''' </author>
    ''' <summary>
    ''' Update from GUI to data structure
    ''' </summary>
    ''' <param name="Username"></param>
    ''' <remarks></remarks>
    Private Sub UpdateDataBaseOnPath(ByVal strPath As String, ByVal blChecked As Boolean, ByVal lstdbChamber As Dictionary(Of String, AVPLib.DBChamber))
        Dim path() As String = Split(strPath, "\")
        'The path will be Maintenance\Chamber\Group\Parameter
        Dim componentsNum As Integer = 4
        'This is the actual data
        If path.Length = componentsNum Then
            Dim strChamber As String = path(1)
            Dim strGroup As String = path(2)
            Dim strParameter As String = path(3)

            'Search Chamber
            For Each dbChamber As AVPLib.DBChamber In lstdbChamber.Values
                Dim strCompared As String = dbChamber.ChamberType & " (" & dbChamber.ChamberDescription & ")"
                If strChamber = strCompared Then
                    'search group
                    For Each dbGroup As AVPLib.DBParameterGroup In dbChamber.ListGroupParameters
                        If strGroup = dbGroup.GroupName Then
                            'search parameter
                            For Each dbParameter As AVPLib.DBParameter In dbGroup.Parameters
                                If strParameter = dbParameter.Name Then
                                    dbParameter.ReadWrite = blChecked
                                    Return
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        Else
            'Just ignore
        End If
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-14-04</date>
    ''' </author>
    ''' <summary>
    ''' Update from GUI to data structure
    ''' </summary>
    ''' <param name="Username"></param>
    ''' <remarks></remarks>
    Private Sub UpdateDataFromGui(ByVal User As AVPLib.DBUser)
        Dim stNodes As Stack(Of TreeNode)
        stNodes = New Stack(Of TreeNode)
        Dim tnStacked As TreeNode

        ' create a new stack and
        For Each rootNode As TreeNode In treeAcessControlListView.Nodes
            ' This is the root node
            If rootNode.GetNodeCount(True) > 0 Then

                ' Screen Node
                If rootNode.Name = SCREENS_NODE Then
                    Dim lstPermission As New ArrayList()
                    Dim Chamber1Name As String = AVPLib.Utils.chamberID2ChamberName(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
                    Dim Chamber2Name As String = AVPLib.Utils.chamberID2ChamberName(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
                    Dim Chamber3Name As String = AVPLib.Utils.chamberID2ChamberName(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
                    For Each childNode As TreeNode In rootNode.Nodes
                        Dim strName As String = String.Empty
                        Select Case childNode.Text
                            Case Chamber1Name
                                strName = AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                            Case Chamber2Name
                                strName = AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                            Case Chamber3Name
                                strName = AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                            Case Else
                                strName = childNode.Text
                        End Select
                        Dim UserPermission As New AVPLib.DBUserPermission(childNode.Name, strName, childNode.Checked, String.Empty)
                        lstPermission.Add(UserPermission)
                        If childNode.Nodes.Count >= 1 Then
                            For Each ccNode As TreeNode In childNode.Nodes
                                UserPermission = New AVPLib.DBUserPermission(ccNode.Name, ccNode.Text, ccNode.Checked, childNode.Text)
                                lstPermission.Add(UserPermission)
                            Next
                        End If
                    Next
                    User.ListPermission = lstPermission
                ElseIf rootNode.Name = MAINTENANCE_NODE Then
                    ' push each ChamberType (ChamberName) node.
                    For Each chamberNode As TreeNode In rootNode.Nodes
                        stNodes.Push(chamberNode)
                    Next
                End If
            Else
                'do something here
            End If
        Next

        While stNodes.Count > 0
            ' let's pop node from stack,
            tnStacked = stNodes.Pop()
            ' set correct state image
            ' index if not already done
            UpdateDataBaseOnPath(tnStacked.FullPath, _
                                 IIf(User.Group.Name = AVPLib.ConstEnum.ADMINISTRATOR, True, tnStacked.Checked), _
                                 User.ListOfDBChamber)
            ' and push each child to stack
            For i As Integer = 0 To tnStacked.Nodes.Count - 1
                ' too until there are no
                stNodes.Push(tnStacked.Nodes(i))
                ' nodes left on stack.
            Next
        End While

    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' btnSave_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        AVPLib.Log.guiLogger.Info("Enter btnSave_Click")
        Try
            Dim Group As AVPLib.DBGroup = AVPLib.ContainerData.Group(Me.cmbGroup.SelectedValue)
            If Group Is Nothing Then
                Utils.ShowAVPMessageBox("Please Choose Group!", "Group", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                         AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                         "[Main Screen] " + "Failed to save user becauseof missing user group.")
                AVPLib.Log.guiLogger.Info("Leave btnSave_Click")
                Return
            End If

            ' Make it all upper case
            If String.IsNullOrEmpty(txtName.Text.Trim()) Then
                Return
            End If
            Me.txtName.Text = Me.txtName.Text.ToUpper()
            If Me.txtName.Text = ROOT_USER_NAME Then
                Utils.ShowAVPMessageBox("Please choose another name for this user", "Wrong User Name", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                         AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                         "[Main Screen] " + "Try to save user name.")
                AVPLib.Log.guiLogger.Info("Leave btnSave_Click")
                Exit Sub
            End If
            If Me.Saving = False Then
                Dim User As AVPLib.DBUser = AVPLib.ContainerData.User(Me.txtName.Text.ToUpper())
                If Me.txtPassword.Text.Length > 0 Then
                    User.Password = Me.txtPassword.Text
                    '# Rem cramble password. Will add back later when needed.
                   ' User.Password = EncryptionHelper.Encrypt(Me.txtPassword.Text)
                End If
                User.Username = User.Username.ToUpper()
                User.Disable = Me.chkDisableUser.Checked
                User.Group = Group
                UpdateDataFromGui(User)
                AVPLib.ContainerData.UpdateUser(User)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[User Setup] Updated User with Username =" + Me.txtName.Text)
                Utils.ShowAVPMessageBox("User (" + User.Username + ") updated success!", "Save User", MessageBoxIcon.Information, MessageBoxButtons.OK)
            Else
                If AVPLib.ContainerData.CheckUserExist(Me.txtName.Text) Then
                    Utils.ShowAVPMessageBox("Username existed! Please choose another", "New User", MessageBoxIcon.Error, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                        AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                        "[Main Screen] " + "Failed to save user becauseof existing username.")
                    AVPLib.Log.guiLogger.Info("Leave btnSave_Click")
                    Return
                ElseIf Me.txtName.Text.Length = 0 Then
                    Utils.ShowAVPMessageBox("Username is Empty! Please choose another", "New User", MessageBoxIcon.Error, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                        AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                        "[Main Screen] " + "Failed to save user becauseof missing username.")
                    AVPLib.Log.guiLogger.Info("Leave btnSave_Click")
                    Return
                Else
                    Dim User As AVPLib.DBUser = New AVPLib.DBUser()
                    User.Username = Me.txtName.Text
                    User.Password = Me.txtPassword.Text
                    '# Rem cramble password. Will add back later when needed.
                   ' User.Password = EncryptionHelper.Encrypt(Me.txtPassword.Text)
                    User.Disable = Me.chkDisableUser.Checked
                    User.Group = Group
                    User.ListOfDBChamber = AVPLib.ContainerData.GetAllDBChambers()

                    UpdateDataFromGui(User)
                    AVPLib.ContainerData.SaveUser(User)

                    Me.Saving = False
                    Me.txtName.BackColor = System.Drawing.SystemColors.Control
                    Me.txtName.Cursor = Cursors.Default
                    Me.btnDelete.Visible = True
                    Utils.ShowAVPMessageBox("User (" + User.Username + ") saved success!", "Save User", MessageBoxIcon.Information, MessageBoxButtons.OK)

                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[User Setup] Saved user with Username=" + Me.txtName.Text)
                    Me.LoadUserName(AVPLib.ContainerData.ListUser.Count - 1)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnSave_Click")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' btnReset_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        AVPLib.Log.guiLogger.Info("Enter btnReset_Click")
        Try
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[User Setup] Reset Permission")

            Dim selected As Integer = Me.DGVSystemUser.SelectedCells(0).RowIndex
            Dim Username As String = CType(Me.DGVSystemUser.DataSource, DataTable).Rows(selected)("Username").ToString()
            Dim User As AVPLib.DBUser = AVPLib.ContainerData.User(Username)
            Me.txtName.Text = User.Username
            Me.txtPassword.Text = User.Password
            '# Rem cramble password. Will add back later when needed.
          '  Me.txtPassword.Text = EncryptionHelper.Decrypt(User.Password)
            Me.chkDisableUser.Checked = User.Disable
            Me.cmbGroup.SelectedValue = User.Group.Id
            Select Case User.Group.Id
                Case 1 ''administrator
                    Check_UnCheckAll(True)
                Case Else
                    ResetUserRight()
            End Select

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnReset_Click")
    End Sub
#End Region

#Region "Support Functions"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' First Load
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearForm()
        Try
            Me.treeAcessControlListView.Nodes.Clear()
            Me.DGVSystemUser.DataSource = Nothing
            Me.txtName.Text = ""
            Me.txtPassword.Text = ""
            Me.cmbGroup.SelectedValue = 0
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        Try
            If AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_005) Then
                ActiveForm()
            Else
                InactiveForm()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.btnDelete.Enabled = True
            Me.btnNew.Enabled = True
            Me.btnReset.Enabled = True
            Me.btnSave.Enabled = True
            Me.txtName.Enabled = True
            Me.txtPassword.Enabled = True
            Me.cmbGroup.Enabled = True
            Me.chkDisableUser.Enabled = True
            Me.treeAcessControlListView.Enabled = True
            Me.DGVSystemUser.Enabled = True
            Me.treeAcessControlListView.Enabled = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            Me.btnDelete.Enabled = False
            Me.btnNew.Enabled = False
            Me.btnReset.Enabled = False
            Me.btnSave.Enabled = False
            Me.txtName.Enabled = False
            Me.txtPassword.Enabled = False
            Me.cmbGroup.Enabled = False
            Me.chkDisableUser.Enabled = False
            Me.treeAcessControlListView.Enabled = False
            Me.treeAcessControlListView.Enabled = False
            Me.DGVSystemUser.Enabled = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    Private Sub txtName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Click
        If txtName.BackColor = System.Drawing.SystemColors.Window Then ' Can edit the user name
            Dim pad As New KeyPad
            Dim Value As String = txtName.Text
            If pad.DisplayKeypad(Value, "Please input user name", False) = DialogResult.OK Then
                txtName.Text = Value
            End If
        End If
    End Sub

    Private Sub txtPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.Click
        Dim pad As New KeyPad
        Dim Value As String = txtPassword.Text
        If pad.DisplayKeypad(Value, "Please input password", True) = DialogResult.OK Then
            txtPassword.Text = Value
        End If
    End Sub

    Private Sub cmbGroup_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGroup.SelectedValueChanged
        Try
            If Me.m_blnfirstLoad Or m_blnIsLoadingUser Then
                m_blnfirstLoad = False
                m_blnIsLoadingUser = False
                Exit Sub
            End If
            If CType(cmbGroup.SelectedItem, AVPLib.DBGroup).Name = AVPLib.ConstEnum.ADMINISTRATOR Then ''-> Full Access
                Check_UnCheckAll(True)
            Else
                ResetUserRight()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub ResetUserRight()
        Try
            Check_UnCheckAll(False)
            Dim strUser As String = CType(cmbGroup.SelectedItem, AVPLib.DBGroup).Name
            For Each item As TreeNode In treeAcessControlListView.Nodes ''node Screen and Chamber
                For Each childNode As TreeNode In item.Nodes
                    If Me.m_UserDefaultAccessMap(childNode.Text) IsNot Nothing AndAlso _
                               CType(Me.m_UserDefaultAccessMap(childNode.Text), List(Of String)).Contains(strUser) Then
                        childNode.Checked = True
                    End If
                    For Each pmNode As TreeNode In childNode.Nodes
                        If Me.m_UserDefaultAccessMap(pmNode.Text) IsNot Nothing AndAlso _
                            CType(Me.m_UserDefaultAccessMap(pmNode.Text), List(Of String)).Contains(strUser) Then
                            pmNode.Checked = True
                        End If
                        For Each groupNode As TreeNode In pmNode.Nodes
                            If Me.m_UserDefaultAccessMap(groupNode.Text) IsNot Nothing AndAlso _
                               CType(Me.m_UserDefaultAccessMap(groupNode.Text), List(Of String)).Contains(strUser) Then
                                groupNode.Checked = True
                            End If
                        Next
                    Next
                Next
                item.ExpandAll()
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


End Class
