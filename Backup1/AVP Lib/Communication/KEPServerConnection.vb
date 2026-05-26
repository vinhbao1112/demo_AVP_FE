Imports OPCAutomation

Namespace Communication
    Public Class KEPServerConnection
        Inherits Connection
#Region "Class Constants & Variables"

        Private Const On_Option As String = "On"
        Private Const Off_Option As String = "Off"
        Private Const Unknown_Option As String = "Unknown"

        Private m_ServerName As String = DataManagerment.ConfigurationManager.GetConfigItem("KepServer").Name
        Private m_IndexKepItemHash As Hashtable = New Hashtable()
        Private m_TagKepItemHash As Hashtable = New Hashtable()
        Private m_listKepItem As ArrayList = Nothing
        Private m_MessageWrite As Hashtable = New Hashtable()
        Private m_ActionsHash As Hashtable = Nothing
        Private m_StatusesHash As Hashtable = Nothing
        Private m_ReverseStatuesHash As Hashtable = Nothing
        Private WithEvents m_OPCServer As OPCServer = Nothing
        Dim WithEvents ConnectedGroup As OPCGroup = Nothing
        Public Event KepServerChangeEvent As EventHandler
        Private m_ItemCount As Integer = 1
#End Region

#Region "Public Method"
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-21</date>
        ''' </author>
        ''' <summary>
        ''' return Kepserver Data
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetGroupItem() As ArrayList
            Return m_listKepItem
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' initateMessageWrite
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub InitiateMessageWrite()
            If Not ContainerDAO.GetConfigurableKepServer(m_ActionsHash, m_StatusesHash) Then
                AVPLib.Log.avpLogger.Error("Failed to read configurable Kep Server Tags.")
            End If
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-21</date>
        ''' </author>
        ''' <summary>
        ''' Add Action Hash
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddActionKepserTag(ByVal key As String, ByVal value As String)
            AVPLib.Log.avpLogger.Info("Enter AddActionKepserTag")
            Try
                If (m_ActionsHash Is Nothing) Then
                    m_ActionsHash = New Hashtable
                End If
                m_ActionsHash.Add(key, value)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave AddActionKepserTag")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-21</date>
        ''' </author>
        ''' <summary>
        ''' each group have some tag
        ''' each tag is an kep server item
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddKepserItem(ByVal GroupName As String, ByVal DisplayGroup As String, ByVal PropertyName As String, _
                                    ByVal KepServerName As String, ByVal DataType As String, _
                                    ByVal Desc As String)
            AVPLib.Log.avpLogger.Info("Enter AddKepserItem")
            Try
                If (m_listKepItem IsNot Nothing) Then
                    Dim objKepServerGroup As KepServerGroup = GetKepServerGroupByName(GroupName)
                    If (objKepServerGroup IsNot Nothing) Then
                        Dim KepServerItem = objKepServerGroup.AddItem(DisplayGroup, PropertyName, KepServerName, DataType, Desc)
                        If (KepServerItem IsNot Nothing) Then
                            Dim ItemName As String = KepServerItem.KepServerName
                            Dim ItemPropertyName As String = KepServerItem.PropertyName

                            KepServerItem.MyIndex = m_ItemCount
                            Try
                                KepServerItem.MyOPCItem = ConnectedGroup.OPCItems.AddItem(ItemName, m_ItemCount)
                            Catch ex As Exception
                                AVPLib.Log.avpLogger.Error(ex.ToString())
                            End Try

                            m_IndexKepItemHash.Add(m_ItemCount, KepServerItem)
                            m_TagKepItemHash.Add(ItemName, KepServerItem)
                            m_ItemCount += 1
                        End If
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave AddKepserItem")
        End Sub


        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-21</date>
        ''' </author>
        ''' <summary>
        ''' Add Action Hash
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddStatusKepserTag(ByVal key As String, ByVal value As String)
            AVPLib.Log.avpLogger.Info("Enter AddStatusKepserTag")
            Try
                If (m_StatusesHash Is Nothing) Then
                    m_StatusesHash = New Hashtable
                End If
                m_StatusesHash.Add(key, value)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave AddStatusKepserTag")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-21</date>
        ''' </author>
        ''' <summary>
        ''' Get Group by Name
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetKepServerGroupByName(ByVal sName As String) As KepServerGroup
            AVPLib.Log.avpLogger.Info("Enter GetKepServerGroupByName")
            Dim objResult As KepServerGroup = Nothing
            Try

                For Each Item As KepServerGroup In m_listKepItem
                    If (Item.GroupName = sName) Then
                        objResult = Item
                        Exit For
                    End If
                Next

            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave GetKepServerGroupByName")
            Return objResult
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' WriteItem
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <param name="Value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function WriteItem(ByVal Message As String, ByVal Value As Object) As String
            AVPLib.Log.kepServerLogger.Info("Enter WriteItem")

            ' Modified by Dat Nguyen.
            Const Tag_Separator As String = ";"
            Const Tag_Value_Separator As String = "="

            Dim tags As String = String.Empty
            Dim strErrMsg As String = String.Empty

            Try
                ' Default
                Dim key As String = Message
                If (Value.ToString() = Boolean.TrueString) Then
                    ' Turn On
                    ' Search Tags by `Message` & `On`.
                    key = Message & " " & On_Option
                ElseIf (Value.ToString() = Boolean.FalseString) Then
                    ' Turn Off
                    ' Search Tags by `Message` & `Off`.
                    key = Message & " " & Off_Option
                ElseIf (Value.ToString() = Unknown_Option) Then
                    ' Unknown
                    ' Search Tags by `Message` & `Unknown`.
                    key = Message & " " & Unknown_Option
                End If
                tags = m_ActionsHash.Item(key)
                If Not String.IsNullOrEmpty(tags) Then
                    Dim TagAndValueArr As String() = tags.Split(New String() {Tag_Separator}, StringSplitOptions.RemoveEmptyEntries)
                    If Not (TagAndValueArr Is Nothing) Then
                        For Each tagAndValue As String In TagAndValueArr
                            Dim tagAndValuePair As String() = tagAndValue.Split(New String() {Tag_Value_Separator}, StringSplitOptions.RemoveEmptyEntries)
                            If Not (tagAndValuePair) Is Nothing Then
                                If (tagAndValuePair.Length >= 1) Then
                                    If (tagAndValuePair.Length = 2) Then
                                        Dim writtenValue As String = tagAndValuePair(1).Trim()
                                        If (Value.ToString() = Boolean.TrueString) Or (Value.ToString() = Boolean.FalseString) Or (Value.ToString() = Unknown_Option) Then
                                            If writtenValue.ToLower() = Boolean.TrueString.ToLower() Then
                                                Value = True
                                            ElseIf writtenValue.ToLower() = Boolean.FalseString.ToLower() Then
                                                Value = False
                                            End If
                                        Else
                                            ' Tags with data type is not boolean, ignore for now.
                                        End If
                                    End If
                                    If Not SendMessage(tagAndValuePair(0), Value) Then
                                        AVPLib.Log.kepServerLogger.Error("Couldn't write to Kep Server with the tag " & tagAndValuePair(0) & _
                                        " and the value " & Value)
                                        strErrMsg = String.Format(ContainerData.GetMessageText("WriteKepserverError"), tagAndValuePair(0), Message)
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                strErrMsg = String.Format(ContainerData.GetMessageText("WriteKepserverError"), tags, Message)
            End Try
            AVPLib.Log.kepServerLogger.Info("Leave WriteItem")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Send a message
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function SendMessage(ByVal Message As String, ByVal Value As Object) As Boolean
            AVPLib.Log.kepServerLogger.Info("Enter SendMessage")
            Dim bRet As Boolean = True
            Try
                If Not ConnectedGroup Is Nothing Then
                    Dim KepItem As KepServerItem = m_TagKepItemHash(Message)
                    If (KepItem IsNot Nothing) Then
                        Dim AnOpcItem As OPCAutomation.OPCItem = KepItem.MyOPCItem
                        If Not AnOpcItem Is Nothing Then
                            ' Write synchronously.
                            AnOpcItem.Write(Value)
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                bRet = False
            End Try
            AVPLib.Log.kepServerLogger.Info("Leave SendMessage")
            Return bRet
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Open KEPServerConnection
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Open() As Boolean
            AVPLib.Log.kepServerLogger.Info("Enter Open")
            Try
                If m_OPCServer Is Nothing Then
                    m_OPCServer = New OPCServer()
                End If
                m_OPCServer.Connect(m_ServerName, "")
                m_CurrentState = States.Connected
                Me.InitiateMessageWrite()
                Me.LoadGroups()
                m_CurrentState = States.Connected
                Return True
            Catch ex As Exception
                m_CurrentState = States.Disconnected
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.kepServerLogger.Info("Leave Open")
            Return False
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' close KEPServerConnection
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Close() As Boolean
            AVPLib.Log.kepServerLogger.Info("Enter Close")
            Try
                If Not m_OPCServer Is Nothing Then
                    m_OPCServer.Disconnect()
                End If
                m_CurrentState = States.Disconnected
                Return True
            Catch ex As Exception
                m_CurrentState = States.Disconnected
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.kepServerLogger.Info("Leave Close")
            Return False
        End Function

        ''' <author>
        '''    	<name> Diep Chi Cuong </name>
        '''    	<date> 2008-11-14</date>
        ''' </author>
        ''' <summary>
        ''' LoadGroups
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function LoadGroups() As Boolean
            AVPLib.Log.kepServerLogger.Info("Enter LoadGroups")
            If m_OPCServer Is Nothing Then
                Return False
            End If
            Try
                m_OPCServer.OPCGroups.DefaultGroupIsActive = True
                m_OPCServer.OPCGroups.DefaultGroupDeadband = 0

                m_listKepItem = ContainerData.GetKepServer()
                m_ItemCount = 1
                For Each Group As KepServerGroup In m_listKepItem
                    ConnectedGroup = m_OPCServer.OPCGroups.Add(Group.GroupName)
                    ConnectedGroup.IsActive = Group.IsActive
                    ConnectedGroup.DeadBand = 0
                    ConnectedGroup.UpdateRate = Group.UpdateRate
                    ConnectedGroup.IsSubscribed = True
                    'Begin Add Item
                    Dim ListItem As ArrayList = Group.ListItems
                    For Each Item As KepServerItem In ListItem

                        Dim ItemName As String = Item.KepServerName
                        Dim PropertyName As String = Item.PropertyName

                        Item.MyIndex = m_ItemCount
                        Try
                            Item.MyOPCItem = ConnectedGroup.OPCItems.AddItem(ItemName, m_ItemCount)
                        Catch ex As Exception
                            AVPLib.Log.avpLogger.Error(ex.ToString())
                            Continue For
                        End Try

                        m_IndexKepItemHash.Add(m_ItemCount, Item)
                        m_TagKepItemHash.Add(ItemName, Item)
                        m_ItemCount += 1
                    Next
                Next
                AVPLib.Log.kepServerLogger.Info("Leave LoadGroups")
                Return True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.kepServerLogger.Info("Leave LoadGroups")
            Return False
        End Function

        ''' <author>
        '''    	<name> Diep Chi Cuong </name>
        '''    	<date> 2008-11-14</date>
        ''' </author>
        ''' <summary>
        ''' ChangeStatus
        ''' </summary>
        ''' <param name="index"></param>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Private Sub ChangeStatus(ByVal index As Integer, ByVal Value As Object)
            AVPLib.Log.kepServerLogger.Info("Enter ChangeStatus")

            If (Value Is Nothing) Then
                AVPLib.Log.kepServerLogger.Info("Leave ChangeStatus")
                Return
            End If
            Try
                Dim KepItem As KepServerItem = m_IndexKepItemHash(index)

                Dim PropertyName As String = KepItem.PropertyName
                If String.IsNullOrEmpty(PropertyName) Then
                    Return
                End If
                Dim myOpcItem As OPCItem = KepItem.MyOPCItem
                Dim KepTagName As String = KepItem.KepServerName
                If Not (PropertyName.Contains("CassettesModule.KepWareServerDisConnected")) Then
                    Dim changedValue As Object = DataManagerment.Equipment.WorkingStatuses.Unknown
                    Dim dataType As String = KepItem.DataType
                    ' Two tags needed, we will know this equipment status based on this couple.
                    ' Not support more than two tags.
                    If (dataType.ToLower() = "boolean" AndAlso ((Value.ToString() = Boolean.TrueString) Or (Value.ToString() = Boolean.FalseString))) Then
                        Dim statusKey As String = KepTagName & "=" & Value.ToString()
                        Dim reverseStatusKey As String = KepTagName & "=" & Value.ToString()
                        Dim associatedTag As String = String.Empty
                        If GetAssociatedTag(PropertyName, KepTagName, associatedTag) Then
                            Dim associatedKepItem As KepServerItem = m_TagKepItemHash(associatedTag)
                            If (associatedKepItem IsNot Nothing) AndAlso (associatedKepItem.MyOPCItem IsNot Nothing) Then
                                If associatedKepItem.MyOPCItem.Value IsNot Nothing Then
                                    statusKey = statusKey & ";" & associatedTag & "=" & associatedKepItem.MyOPCItem.Value.ToString()
                                    reverseStatusKey = associatedTag & "=" & associatedKepItem.MyOPCItem.Value.ToString() & ";" & reverseStatusKey
                                Else
                                    statusKey = statusKey & ";" & associatedTag & "=" & Boolean.FalseString
                                    reverseStatusKey = associatedTag & "=" & Boolean.FalseString & ";" & reverseStatusKey
                                End If
                            End If
                        End If
                        Dim status As String = m_StatusesHash.Item(statusKey)
                        If String.IsNullOrEmpty(status) And (reverseStatusKey <> statusKey) Then
                            status = m_StatusesHash.Item(reverseStatusKey)
                        End If
                        If Not String.IsNullOrEmpty(status) Then
                            Dim statusAndValuePair As String() = status.Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)
                            If (Not statusAndValuePair Is Nothing) And (statusAndValuePair.Length = 2) Then
                                Dim statusValue As String = statusAndValuePair(1).Trim()
                                If (statusValue.ToLower() = On_Option.ToLower()) Then
                                    changedValue = DataManagerment.Equipment.WorkingStatuses.On
                                ElseIf statusValue.ToLower() = Off_Option.ToLower() Then
                                    changedValue = DataManagerment.Equipment.WorkingStatuses.Off
                                ElseIf (statusValue = Boolean.TrueString OrElse statusValue = Boolean.FalseString) Then
                                    changedValue = Convert.ToBoolean(statusValue)
                                End If
                            End If
                        End If
                    Else
                        changedValue = Value
                    End If
                    RaiseEvent KepServerChangeEvent(KepTagName & "#" & Value, Nothing)
                    Dim ReplyValues As ArrayList = New ArrayList()
                    Dim PropertyNames As ArrayList = New ArrayList()
                    Dim pos As Integer = PropertyName.IndexOf(".")
                    Dim Equipment As String = ""
                    If pos > -1 Then
                        Equipment = PropertyName.Substring(0, pos)
                        PropertyName = PropertyName.Substring(pos + 1)
                    End If
                    PropertyNames.Add(PropertyName)
                    If PropertyName = "CG" Then
                        changedValue = AVPLib.ContainerData.convertCGValue(CDbl(Value))
                    ElseIf PropertyName = "IG" Then
                        changedValue = AVPLib.ContainerData.convertIGValue(CDbl(Value))
                    End If

                    'keep to reuse at the future
                    'If (Not ContainerDAO.Is_RGY_AlarmLightConfig AndAlso Equipment = "Alarm" AndAlso PropertyName = "GreenStatus") Then
                    '    If (changedValue = DataManagerment.Equipment.WorkingStatuses.On) Then
                    '        changedValue = DataManagerment.Equipment.WorkingStatuses.Off
                    '    ElseIf (changedValue = DataManagerment.Equipment.WorkingStatuses.Off) Then
                    '        changedValue = DataManagerment.Equipment.WorkingStatuses.On
                    '    End If
                    'End If

                    ReplyValues.Add(changedValue)
                    If Equipment = "Alarm" AndAlso PropertyName = "AlarmStatus" Then
                        Return
                    End If
                    AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Equipment, PropertyNames, ReplyValues)
                ElseIf AVPLib.RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                    Dim ReplyValues As ArrayList = New ArrayList()
                    Dim PropertyNames As ArrayList = New ArrayList()
                    Dim pos As Integer = PropertyName.IndexOf(".")
                    Dim Equipment As String = ""
                    If pos > -1 Then
                        Equipment = PropertyName.Substring(0, pos)
                        PropertyName = PropertyName.Substring(pos + 1)
                    End If
                    PropertyNames.Add(PropertyName)
                    ReplyValues.Add(Value)
                    If Value.ToString() = "True" Then
                        Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("KepServerDisconnect")), ConstEnum.GEM_ALARM_SYSTEM)
                    End If
                    AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Equipment, PropertyNames, ReplyValues)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.kepServerLogger.Info("Leave ChangeStatus")
        End Sub
#End Region

#Region "Events"
        ''' <author>
        '''    	<name> Diep Chi Cuong </name>
        '''    	<date> 2008-11-14</date>
        ''' </author>
        ''' <summary>3
        ''' OPCGroup_DataChange
        ''' </summary>
        ''' <param name="TransactionID"></param>
        ''' <param name="NumItems"></param>
        ''' <param name="ClientHandles"></param>
        ''' <param name="ItemValues"></param>
        ''' <param name="Qualities"></param>
        ''' <param name="TimeStamps"></param>
        ''' <remarks></remarks>
        Private Sub ConnectedGroup_DataChange(ByVal TransactionID As Integer, ByVal NumItems As Integer, ByRef ClientHandles As System.Array, ByRef ItemValues As System.Array, ByRef Qualities As System.Array, ByRef TimeStamps As System.Array) Handles ConnectedGroup.DataChange
            AVPLib.Log.kepServerLogger.Info("Enter ConnectedGroup_DataChange")

            ' We don't have error handling here since this is an event called from the OPC interface
            Try
                Dim i As Short
                For i = 1 To NumItems
                    ' Use the 'Clienthandles' array returned by the server to pull out the
                    ' index number of the control to update and load the value.
                    If IsArray(ItemValues(i)) = False Then
                        ChangeStatus(ClientHandles(i), ItemValues(i))
                    End If
                Next i
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.kepServerLogger.Info("Leave ConnectedGroup_DataChange")
        End Sub
#End Region

#Region "Support"
        Private Function GetAssociatedTag(ByVal PropertyName As String, ByVal tag As String, ByRef associatedTag As String) As Boolean
            AVPLib.Log.kepServerLogger.Info("Leave GetAssociatedTag")
            Try
                For Each Group As KepServerGroup In m_listKepItem
                    Dim ListItem As ArrayList = Group.ListItems
                    For Each Item As KepServerItem In ListItem
                        If (Item.PropertyName = PropertyName) AndAlso (Item.KepServerName <> tag) Then
                            associatedTag = Item.KepServerName
                            Return True
                        End If
                    Next
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.kepServerLogger.Info("Leave GetAssociatedTag")
            Return False
        End Function
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-02-10</date>
        ''' </author>
        ''' <summary>
        ''' Load KepSever Value
        ''' </summary>
        ''' <param name="PropertyName"></param>
        ''' <param name="Index"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function LoadKepSeverValue(ByVal strTagID As String, ByVal strGroupName As String) As String
            AVPLib.Log.kepServerLogger.Info("Enter LoadKepSeverValue")
            If m_OPCServer Is Nothing Then
                Return Nothing
            End If
            Try
                For Each Group As KepServerGroup In m_listKepItem
                    If strGroupName.StartsWith(Group.GroupName) Then
                        Dim ListItem As ArrayList = Group.ListItems
                        For Each Item As KepServerItem In ListItem
                            If Item.KepServerName = strTagID Then
                                If Item.MyOPCItem Is Nothing Then
                                    Return String.Empty
                                Else
                                    Return Item.MyOPCItem.Value.ToString()
                                End If
                            End If
                        Next
                    End If
                Next
                AVPLib.Log.kepServerLogger.Info("Leave LoadGroups")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.kepServerLogger.Info("Leave LoadKepSeverValue")
            Return Nothing
        End Function
#End Region
    End Class
End Namespace

