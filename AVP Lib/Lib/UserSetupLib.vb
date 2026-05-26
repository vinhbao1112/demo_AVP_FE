Imports AVPLib
Imports AVPLib.Utils
Imports AVPLib.ConstEnum
Public Class UserSetupLib
#Region "Functions"
    Private Shared Function UpdateRecipeParametersPrivilege(ByRef ListOfStdDBChambers As Dictionary(Of String, AVPLib.DBChamber), ByVal ListOfDBChambersOfCurrentUser As Dictionary(Of String, AVPLib.DBChamber))
        Dim strPMDifferent As String = String.Empty
        For Each stdDbChamber As DBChamber In ListOfStdDBChambers.Values
            Dim key As String = stdDbChamber.ChamberType & "." & stdDbChamber.ChamberName
            If (ListOfDBChambersOfCurrentUser.ContainsKey(key)) Then
                Dim selectedDbChamberOfCurrentUser As DBChamber = ListOfDBChambersOfCurrentUser.Item(key)
                For Each group As DBParameterGroup In stdDbChamber.ListGroupParameters
                    For Each para As DBParameter In group.Parameters
                        Dim paraOfCurrentUser As DBParameter = selectedDbChamberOfCurrentUser.GetParameter(group.GroupCode, para.Name)
                        If (paraOfCurrentUser IsNot Nothing) Then
                            para.ViewOnly = paraOfCurrentUser.ViewOnly
                            para.ReadWrite = paraOfCurrentUser.ReadWrite
                        End If
                    Next
                Next
            Else
                ''
                ''we don't compare Aligner RecipePrivilege
                ''
                If Not stdDbChamber.ChamberName.Contains(Equipments.Aligner.ToString()) Then
                strPMDifferent &= IIf(String.IsNullOrEmpty(strPMDifferent), _
                                      Utils.chamberID2ChamberName(stdDbChamber.ChamberName), _
                                      ", " & Utils.chamberID2ChamberName(stdDbChamber.ChamberName))
            End If
            End If
        Next
        Return strPMDifferent
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-30</date>
    ''' </author>
    ''' <summary>
    ''' GetUser
    ''' </summary>
    ''' <param name="UserDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUser(ByVal UserDoc As System.Xml.XmlDocument, ByVal Username As String) As DBUser
        AVPLib.Log.coreLogger.Info("Enter GetUser")
        Try
            Dim ListOfstdDBChamber As Dictionary(Of String, AVPLib.DBChamber) = AVPLib.ContainerData.GetAllDBChambers()
            Const STR_PERMIT As String = "Permit"
            Const STR_CODE As String = "Code"
            Const STR_SCREEN As String = "Screen"
            Dim root As System.Xml.XmlNode = UserDoc.FirstChild
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                If String.Compare(node.FirstChild.InnerText, Username, True) = 0 Then
                    Dim nodeUserList As System.Xml.XmlNodeList = node.ChildNodes
                    Dim User As String = nodeUserList.Item(0).InnerText
                    Dim Password As String = nodeUserList.Item(1).InnerText
                    Dim groupID As Integer = Integer.Parse(nodeUserList.Item(2).InnerText)
                    Dim Group As DBGroup = ContainerDAO.GetGroup(groupID)
                    Dim Disable As Boolean = (nodeUserList.Item(3).InnerText <> "0")
                    Dim nodePermitList As System.Xml.XmlNodeList = nodeUserList.Item(4).ChildNodes
                    Dim ListPermit As ArrayList = New ArrayList()
                    For p As Integer = 0 To nodePermitList.Count - 1
                        Dim permitNode As System.Xml.XmlNode = nodePermitList.Item(p)
                        Dim Permit As Boolean = (permitNode.Attributes.ItemOf(STR_PERMIT).Value <> "0")
                        Dim Code As String = permitNode.Attributes.ItemOf(STR_CODE).Value
                        Dim ScreenName As String = permitNode.Attributes.ItemOf(STR_SCREEN).Value
                        ''if chamber is available or other device -> add to permission list
                        If ((permitNode.InnerText.Contains(ConstEnum.Chamber)) AndAlso ContainerData.IsChamberVisible(ScreenName)) Or _
                            Not (permitNode.InnerText.Contains(ConstEnum.Chamber)) Then
                            ListPermit.Add(New DBUserPermission(Code, ScreenName, Permit, String.Empty))
                        End If
                        If permitNode.HasChildNodes Then
                            Dim ListchildScreenNode As Xml.XmlNodeList = permitNode.ChildNodes
                            For Each childScrNod As Xml.XmlNode In ListchildScreenNode
                                Dim childPermit As Boolean = (childScrNod.Attributes.ItemOf(STR_PERMIT).Value <> "0")
                                Dim childCode As String = (childScrNod.Attributes.ItemOf(STR_CODE).Value)
                                Dim childScreen As String = childScrNod.Attributes.ItemOf(STR_SCREEN).Value
                                ListPermit.Add(New DBUserPermission(childCode, childScreen, childPermit, ScreenName))
                            Next
                        End If
                    Next
                    ' Recipe Priviledge.
                    Const kRecipePrivilege As String = "RecipePrivilege"
                    Const kRecipe As String = "Recipe"
                    Const kName As String = "Name"
                    Const kType As String = "Type"
                    Dim ListOfDbChambersOfCurrentUser As New Dictionary(Of String, DBChamber)
                    Dim nodeRecPrivilege As System.Xml.XmlNode = nodeUserList.Item(5)
                    If (nodeRecPrivilege IsNot Nothing) Then
                        If (kRecipePrivilege = nodeRecPrivilege.Name) Then
                            For Each recipeNode As Xml.XmlNode In nodeRecPrivilege.ChildNodes
                                If (kRecipe = recipeNode.Name) Then
                                    Dim recipeNameAtt As Xml.XmlAttribute = recipeNode.Attributes(kName)
                                    Dim recipeTypeAtt As Xml.XmlAttribute = recipeNode.Attributes(kType)
                                    If (recipeNameAtt IsNot Nothing) And (recipeTypeAtt IsNot Nothing) Then
                                        If (recipeTypeAtt.Value.Length > 0) Then
                                            Dim chamberName As String = recipeNameAtt.Value
                                            Dim chamberType As String = recipeTypeAtt.Value
                                            Dim dbChamberRecipe As DBChamber = _
                                                           ContainerData.GetDBChamber(chamberType, _
                                                                                      recipeNode.ChildNodes, _
                                                                                      chamberName)
                                            If dbChamberRecipe Is Nothing Then
                                                Continue For
                                            End If
                                            dbChamberRecipe.ChamberName = recipeNameAtt.Value
                                            Dim key As String = chamberType & "." & chamberName
                                            If (Not ListOfDbChambersOfCurrentUser.ContainsKey(key)) Then
                                                ListOfDbChambersOfCurrentUser.Add(key, dbChamberRecipe)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                    Dim PMxNeed_ToUpdatePrivilege As String = _
                                 UpdateRecipeParametersPrivilege(ListOfstdDBChamber, ListOfDbChambersOfCurrentUser)
                    AVPLib.Log.coreLogger.Info("Leave GetUser")
                    Return New DBUser(User, Password, Group, Disable, ListPermit, ListOfstdDBChamber, PMxNeed_ToUpdatePrivilege)
                    Exit For
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetUser")
        Return Nothing
    End Function
 ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2010-06-12</date>
    ''' </author>
    ''' <summary>
    ''' GetListOf Default Access for default User
    ''' </summary>
    ''' <param name="UserDoc"></param>
    ''' <returns>List String</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDefaultAccessForUser(ByVal UserDoc As System.Xml.XmlDocument) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetUser")
        Dim hstDefaultAccess As New Hashtable ''key is Param Name -> return a list of User can access as default
        Dim listOfUser As List(Of String) = Nothing
        Try
            Dim root As System.Xml.XmlNode = UserDoc.FirstChild
            For Each usernode As Xml.XmlNode In root.ChildNodes
                If UCase(usernode.FirstChild.InnerText) = UCase("DEFAULT_DO_NOT_READ_IN_GUI") Then
                    Dim nodePermitList As System.Xml.XmlNodeList = usernode.SelectSingleNode("AccessList").ChildNodes
                    For Each itmAccess As Xml.XmlNode In nodePermitList
                        GetListOfDefaultUser(itmAccess, listOfUser, False)
                        hstDefaultAccess.Add(itmAccess.Attributes.ItemOf("Screen").Value, listOfUser)
                        If itmAccess.HasChildNodes Then
                            For Each childAccess As Xml.XmlNode In itmAccess.ChildNodes
                                GetListOfDefaultUser(childAccess, listOfUser, False)
                                hstDefaultAccess.Add(childAccess.Attributes.ItemOf("Screen").Value, listOfUser)
                            Next
                        End If
                    Next
                    ' Recipe Priviledge.
                    Dim ListOfDbChambersOfCurrentUser As New Dictionary(Of String, DBChamber)
                    Dim nodeRecPrivilege As System.Xml.XmlNode = usernode.SelectSingleNode("RecipePrivilege").FirstChild ''get the first child only
                    If (nodeRecPrivilege IsNot Nothing) Then
                        For Each recipeNode As Xml.XmlNode In nodeRecPrivilege.ChildNodes ''3 nodes
                            For Each paramnode As Xml.XmlNode In recipeNode.ChildNodes
                                GetListOfDefaultUser(paramnode, listOfUser, True)
                                If Not hstDefaultAccess.ContainsKey(paramnode.FirstChild.InnerText) Then
                                    hstDefaultAccess.Add(paramnode.FirstChild.InnerText, listOfUser)
                                    End If
                            Next
                        Next
                    End If
                    Return hstDefaultAccess
                    Exit For
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetUser")
        Return Nothing
    End Function
 ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2010-06-12</date>
    ''' </author>
    ''' <summary>
    ''' Get List Of Default User (Administrator, Engineer...)
    ''' </summary>
    ''' <param name="UserDoc"></param>
    ''' <returns>List String</returns>
    ''' <remarks></remarks>
    Private Shared Sub GetListOfDefaultUser(ByVal paramnode As Xml.XmlNode, ByRef ListOfUser As List(Of String), ByVal blnPreviledge As Boolean)
        Try
            ListOfUser = New List(Of String)
            Dim listDefaultUser As String = String.Empty
            If blnPreviledge AndAlso (paramnode.LastChild.Attributes.ItemOf("DefaultFor") IsNot Nothing) Then
                listDefaultUser = paramnode.LastChild.Attributes.ItemOf("DefaultFor").Value
            ElseIf blnPreviledge = False AndAlso paramnode.Attributes.ItemOf("DefaultFor") IsNot Nothing Then
                listDefaultUser = paramnode.Attributes.ItemOf("DefaultFor").Value
            End If
            Dim arrListUser As String() = listDefaultUser.Split(",")
            For Each strUser As String In arrListUser
                ListOfUser.Add(strUser)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' GetListUser
    ''' </summary>
    ''' <param name="UserDoc"></param>
    ''' <returns>List String</returns>
    ''' <remarks></remarks>
    Public Shared Function GetListUser(ByVal UserDoc As System.Xml.XmlDocument) As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetListUser")
        Try
            Dim root As System.Xml.XmlNode = UserDoc.FirstChild
            Dim listUser As ArrayList = New ArrayList()
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                If Not (nodeList.Item(i).FirstChild.InnerText = "DEFAULT_DO_NOT_READ_IN_GUI") AndAlso _
                    Not (nodeList.Item(i).FirstChild.InnerText = ROOT_USER_NAME) Then
                    listUser.Add(nodeList.Item(i).FirstChild.InnerText)
                End If
            Next
            AVPLib.Log.coreLogger.Info("Leave GetListUser")
            Return listUser
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetListUser")
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-30</date>
    ''' </author>
    ''' <summary>
    ''' SaveUser
    ''' </summary>
    ''' <param name="UserDoc"></param>
    ''' <param name="user"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveUser(ByVal UserDoc As System.Xml.XmlDocument, ByVal user As DBUser) As DBUser
        AVPLib.Log.coreLogger.Info("Enter SaveUser")
        Try
            Dim root As System.Xml.XmlNode = UserDoc.FirstChild
            Dim UserNode As System.Xml.XmlNode = UserDoc.CreateElement("User")
            Dim Username As System.Xml.XmlNode = UserDoc.CreateElement("Username")
            Username.InnerText = user.Username
            UserNode.AppendChild(Username)
            Dim Password As System.Xml.XmlNode = UserDoc.CreateElement("Password")
            Password.InnerText = user.Password
            UserNode.AppendChild(Password)
            Dim Group As System.Xml.XmlNode = UserDoc.CreateElement("Group")
            Group.InnerText = user.Group.Id
            UserNode.AppendChild(Group)
            Dim Disable As System.Xml.XmlNode = UserDoc.CreateElement("Disable")
            Disable.InnerText = Math.Abs(CInt(user.Disable))
            UserNode.AppendChild(Disable)

            Dim AccessList As System.Xml.XmlNode = UserDoc.CreateElement("AccessList")
            For i As Integer = 0 To user.ListPermission.Count - 1
                Dim Access As System.Xml.XmlNode = UserDoc.CreateElement("Access")
                Dim Permit As System.Xml.XmlAttribute = UserDoc.CreateAttribute("Permit")
                Dim DBUserPermission As DBUserPermission = CType(user.ListPermission.Item(i), DBUserPermission)
                Permit.Value = Math.Abs(CInt(DBUserPermission.Permit))
                Dim Code As System.Xml.XmlAttribute = UserDoc.CreateAttribute("Code")
                Code.Value = DBUserPermission.Code
                Access.Attributes.Append(Permit)
                Access.Attributes.Append(Code)
                Dim Screen As System.Xml.XmlAttribute = UserDoc.CreateAttribute("Screen")
                Screen.Value = DBUserPermission.Name
                Access.Attributes.Append(Screen)
                If String.IsNullOrEmpty(DBUserPermission.ParentPermission) Then
                    AccessList.AppendChild(Access)
                Else
                    For Each node As Xml.XmlNode In AccessList
                        If node.Attributes.ItemOf("Screen").Value = DBUserPermission.ParentPermission Then
                            node.AppendChild(Access)
                            Exit For
                        End If
                    Next
                End If
            Next
            UserNode.AppendChild(AccessList)

            Dim recipePrivilegeNewXmlNode As Xml.XmlNode = CreateRecipePrivilegeXmlNode(UserDoc, user)
            UserNode.AppendChild(recipePrivilegeNewXmlNode)

            root.AppendChild(UserNode)
            'UserDoc.Save(ContainerDAO.FPath_User)
            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_User, UserDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveUser")
        Return user
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-30</date>
    ''' </author>
    ''' <summary>
    ''' UpdateUser
    ''' </summary>
    ''' <param name="UserDoc"></param>
    ''' <param name="user"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UpdateUser(ByVal UserDoc As System.Xml.XmlDocument, ByVal user As DBUser) As DBUser
        AVPLib.Log.coreLogger.Info("Enter UpdateUser")
        Try
            Dim root As System.Xml.XmlNode = UserDoc.FirstChild
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For Each node As Xml.XmlNode In nodeList
                'Dim node As System.Xml.XmlNode = nodeList.Item(i)
                If String.Compare(node.FirstChild.InnerText, user.Username, True) = 0 Then
                    Dim nodeUserList As System.Xml.XmlNodeList = node.ChildNodes
                    nodeUserList.Item(0).InnerText = user.Username
                    nodeUserList.Item(1).InnerText = user.Password
                    nodeUserList.Item(2).InnerText = user.Group.Id
                    nodeUserList.Item(3).InnerText = Math.Abs(CInt(user.Disable))
                    Dim nodePermitList As System.Xml.XmlNodeList = nodeUserList.Item(4).ChildNodes
                    Dim p As Integer = 0
                    For Each permitNode As Xml.XmlNode In nodePermitList
                        If p >= user.ListPermission.Count Then
                            Exit For
                        End If
                        permitNode.Attributes.ItemOf("Permit").Value = Math.Abs(CInt(CType(user.ListPermission.Item(p), DBUserPermission).Permit))
                        permitNode.Attributes.ItemOf("Code").Value = CType(user.ListPermission.Item(p), DBUserPermission).Code
                        permitNode.Attributes.ItemOf("Screen").Value = CType(user.ListPermission.Item(p), DBUserPermission).Name
                        If permitNode.HasChildNodes Then

                            For Each childNode As Xml.XmlNode In permitNode.ChildNodes
                                p += 1
                                childNode.Attributes.ItemOf("Screen").Value = CType(user.ListPermission.Item(p), DBUserPermission).Name
                                childNode.Attributes.ItemOf("Permit").Value = Math.Abs(CInt(CType(user.ListPermission.Item(p), DBUserPermission).Permit))
                                childNode.Attributes.ItemOf("Code").Value = CType(user.ListPermission.Item(p), DBUserPermission).Code
                            Next
                        End If
                        p += 1
                    Next
                    Dim oldNodeRecPrivilege As System.Xml.XmlNode = nodeUserList.Item(5)
                    Dim recipePrivilegeNewXmlNode As Xml.XmlNode = CreateRecipePrivilegeXmlNode(UserDoc, user)
                    If (oldNodeRecPrivilege IsNot Nothing) Then
                        node.RemoveChild(oldNodeRecPrivilege)
                    End If
                    node.AppendChild(recipePrivilegeNewXmlNode)
                    Exit For
                End If
            Next
            'UserDoc.Save(ContainerDAO.FPath_User)
            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_User, UserDoc)
            '#04/25/2011 
            '#If some of the configuration change and operator login, AVP display message below.  I have log on as admin 
            '#and save all privileged include operator but each time operator log on, the below message appear.   
            '#Operator or other user might not have priviledge to save user setting
            '#Begin fix:
            user.PMxNeed_ToUpdatePrivilege = String.Empty
            '#End fix.
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave UpdateUser")
        Return user
    End Function

    Private Shared Function CreateParameterXmlNode(ByVal UserDoc As System.Xml.XmlDocument, ByVal recParameter As DBParameter) As Xml.XmlNode
        ' Begin Parameter node.
        Dim ParameterChildNode As Xml.XmlNode = UserDoc.CreateElement("Parameter")

        Dim NameChildNode As Xml.XmlNode = UserDoc.CreateElement("Name")
        NameChildNode.InnerText = recParameter.Name
        ParameterChildNode.AppendChild(NameChildNode)

        Dim RWChildNode As Xml.XmlNode = UserDoc.CreateElement("RW")
        RWChildNode.InnerText = recParameter.ReadWrite.ToString()
        ParameterChildNode.AppendChild(RWChildNode)

        ' End Parameter node.
        Return ParameterChildNode
    End Function

    Private Shared Function CreateParameterListXmlNode(ByVal UserDoc As System.Xml.XmlDocument, ByVal recParameterGroup As DBParameterGroup) As Xml.XmlNode
        ' Begin ParameterList node.
        Dim ParameterListChildNode As Xml.XmlNode = UserDoc.CreateElement("ParameterList")
        Dim groupAtt As Xml.XmlNode = UserDoc.CreateAttribute("Group")
        groupAtt.Value = recParameterGroup.GroupCode
        ParameterListChildNode.Attributes.Append(groupAtt)
        For Each recParameter As DBParameter In recParameterGroup.Parameters
            ParameterListChildNode.AppendChild(CreateParameterXmlNode(UserDoc, recParameter))
        Next
        ' End ParameterList node.
        Return ParameterListChildNode
    End Function

    Private Shared Function CreateRecipePrivilegeXmlNode(ByVal UserDoc As System.Xml.XmlDocument, ByVal user As DBUser) As Xml.XmlNode
        ' Begin RecipePrivilege.
        Dim recipePrivilegeXmlNode As Xml.XmlNode = UserDoc.CreateElement("RecipePrivilege")
        For Each recipeChamber As DBChamber In user.ListOfDBChamber.Values
            ' Recipe node.
            Dim recipeChildNode As Xml.XmlNode = UserDoc.CreateElement("Recipe")
            Dim recipeTypeAtt As Xml.XmlNode = UserDoc.CreateAttribute("Type")
            Dim recipeNameAtt As Xml.XmlNode = UserDoc.CreateAttribute("Name")
            recipeTypeAtt.Value = recipeChamber.ChamberType
            recipeChildNode.Attributes.Append(recipeTypeAtt)
            recipeNameAtt.Value = recipeChamber.ChamberName
            recipeChildNode.Attributes.Append(recipeNameAtt)
            For Each parameterGroup As DBParameterGroup In recipeChamber.ListGroupParameters
                ' End ParameterList node.
                recipeChildNode.AppendChild(CreateParameterListXmlNode(UserDoc, parameterGroup))
            Next
            ' End Recipe node.
            recipePrivilegeXmlNode.AppendChild(recipeChildNode)
        Next
        ' End RecipePrivilege.
        Return recipePrivilegeXmlNode
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-30</date>
    ''' </author>
    ''' <summary>
    ''' DeleteUser
    ''' </summary>
    ''' <param name="UserDoc"></param>
    ''' <param name="user"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteUser(ByVal UserDoc As System.Xml.XmlDocument, ByVal user As DBUser) As DBUser
        AVPLib.Log.coreLogger.Info("Enter DeleteUser")
        Try
            Dim root As System.Xml.XmlNode = UserDoc.FirstChild
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                If String.Compare(node.FirstChild.InnerText, user.Username, True) = 0 Then
                    root.RemoveChild(node)
                    Exit For
                End If
            Next
            'UserDoc.Save(ContainerDAO.FPath_User)
            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_User, UserDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave DeleteUser")
        Return user
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-30</date>
    ''' </author>
    ''' <summary>
    ''' GetGroup
    ''' </summary>
    ''' <param name="GroupDoc"></param>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetGroup(ByVal GroupDoc As System.Xml.XmlDocument, ByVal Id As Integer) As DBGroup
        AVPLib.Log.coreLogger.Info("Enter GetGroup")
        Try
            Dim root As System.Xml.XmlNode = GroupDoc.FirstChild
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                Dim GroupId As Integer = Integer.Parse(node.Attributes.ItemOf("id").Value)
                If GroupId = Id Then
                    Dim GroupName As String = node.InnerText
                    AVPLib.Log.coreLogger.Info("Leave GetGroup")
                    Return New DBGroup(GroupId, GroupName)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetGroup")
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-30</date>
    ''' </author>
    ''' <summary>
    ''' GetListGroup
    ''' </summary>
    ''' <param name="GroupDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetListGroup(ByVal GroupDoc As System.Xml.XmlDocument) As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetListGroup")
        Try
            Dim root As System.Xml.XmlNode = GroupDoc.FirstChild
            Dim listGroup As ArrayList = New ArrayList()
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                Dim GroupId As Integer = Integer.Parse(node.Attributes.ItemOf("id").Value)
                Dim GroupName As String = node.InnerText
                
                listGroup.Add(New DBGroup(GroupId, GroupName))
            Next
            AVPLib.Log.coreLogger.Info("Leave GetListGroup")
            Return listGroup
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetListGroup")
        Return Nothing
    End Function
#End Region
End Class
