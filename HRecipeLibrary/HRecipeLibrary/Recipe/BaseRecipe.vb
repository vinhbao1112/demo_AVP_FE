Public MustInherit Class BaseRecipe

#Region "private method"

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get Xml Document of recipe template
    ''' </summary>
    Private Function GetRecipeTemplate(ByVal recipeTemplatePath As String) As Xml.XmlDocument
        Dim recipeTemplate As New System.Xml.XmlDocument()

        Try
            If Not recipeTemplatePath.Contains(HConstants.XmlExtension) Then
                recipeTemplatePath = recipeTemplatePath & HConstants.XmlExtension
            End If

            If System.IO.File.Exists(recipeTemplatePath) = False Then
                recipeTemplate = Nothing
                Exit Try
            End If

            recipeTemplate.Load(recipeTemplatePath)
        Catch ex As Exception
            Logger.Error(ex.Message)
            recipeTemplate = Nothing
        End Try

        Return recipeTemplate
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get Xml Document of recipe
    ''' </summary>
    Private Function GetRecipe(ByVal recipePath As String) As Xml.XmlDocument
        Dim recipe As New System.Xml.XmlDocument()

        Try
            If Not recipePath.Contains(HConstants.XmlExtension) Then
                recipePath = recipePath & HConstants.XmlExtension
            End If

            If System.IO.File.Exists(recipePath) = False Then
                recipe = Nothing
                Exit Try
            End If

            recipe.Load(recipePath)

        Catch ex As Exception
            Logger.Error(ex.Message)
            recipe = Nothing
        End Try

        Return recipe
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Create a list of recipe template group parameters
    ''' </summary>
    Private Function CreateListOfRecipeTemplateGroupParameters(ByVal recipeTemplateDoc As Xml.XmlDocument, ByVal baseConfigData As BaseConfigurationData) As ArrayList
        Dim listOfRecipeTemplateGroupParameters As ArrayList = Nothing

        Try
            If recipeTemplateDoc Is Nothing Then
                listOfRecipeTemplateGroupParameters = New ArrayList()
            Else
                Dim root As System.Xml.XmlNode = recipeTemplateDoc.FirstChild
                Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes

                listOfRecipeTemplateGroupParameters = CreateListOfRecipeTemplateGroupParameters(nodeList, baseConfigData)
            End If
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try

        Return listOfRecipeTemplateGroupParameters
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Create a list of recipe template group parameters
    ''' </summary>
    Private Function CreateListOfRecipeTemplateGroupParameters(ByVal parameterListNodeList As Xml.XmlNodeList, ByVal baseConfigData As BaseConfigurationData) As ArrayList
        Const kInvalidId As Integer = -1
        Const kParameterList As String = "ParameterList"
        Const kId As String = "Id"
        Const kIsGroup As String = "isGroup"
        Const kGroupCode As String = "Group"
        Const kGroupName As String = "GroupName"
        Const kShowInUI As String = "ShowInUI"

        Const kParameter As String = "Parameter"
        Const kParaSeqNo As String = "SeqNo"
        Const kParaName As String = "Name"
        Const kParaDescription As String = "Description"
        Const kParaMin As String = "Min"
        Const kParaMax As String = "Max"
        Const kParaDefault As String = "Default"
        Const kParaUnit As String = "Unit"
        Const kParaUnitShow As String = "UnitShow"
        Const kReadOnly As String = "RO"
        Const kReadWrite As String = "RW"
        ' Support to display user-defined values.
        Const kDisplayItems As String = "DisplayItems"

        Dim listOfRecipeTemplateGroupParameters As New ArrayList()

        For Each paraListNode As Xml.XmlNode In parameterListNodeList
            If (kParameterList = paraListNode.Name) Then
                Dim id As Integer = kInvalidId
                Dim isGroup As Boolean = True
                Dim groupCode As String = String.Empty
                Dim groupName As String = String.Empty
                Dim groupShowInUI As String = Boolean.TrueString
                Dim groupSaveButNotShow As Boolean = False

                For Each paraListAttr As Xml.XmlAttribute In paraListNode.Attributes
                    If (kId = paraListAttr.Name) Then
                        Integer.TryParse(paraListAttr.Value, id)
                    ElseIf (kIsGroup = paraListAttr.Name) Then
                        Dim tmpIsGroup As Integer = 0
                        Integer.TryParse(paraListAttr.Value, tmpIsGroup)
                        isGroup = IIf(tmpIsGroup >= 1, True, False)
                    ElseIf (kGroupCode = paraListAttr.Name) Then
                        groupCode = paraListAttr.Value
                    ElseIf (kGroupName = paraListAttr.Name) Then
                        groupName = paraListAttr.Value
                    ElseIf (kShowInUI = paraListAttr.Name) Then
                        groupShowInUI = CheckingGroupShowInUI(groupCode, groupSaveButNotShow, paraListAttr.Value, baseConfigData)
                    Else
                        Logger.Error("Uknown group attribute found " & paraListAttr.Name)
                    End If
                Next

                If (Boolean.TrueString.ToLower() = groupShowInUI.ToLower()) OrElse _
                   (groupSaveButNotShow And Boolean.FalseString.ToLower() = groupShowInUI.ToLower()) Then

                    Dim listOfParameters As New ArrayList()
                    Dim pulsePara As DBRecipeTemplateParameter = Nothing
                    Dim pulseParaFrequency As DBRecipeTemplateParameter = Nothing
                    Dim pulseParaDutyCycle As DBRecipeTemplateParameter = Nothing
                    Dim tarpowerPara As DBRecipeTemplateParameter = Nothing
                    Dim nodeParameters As System.Xml.XmlNodeList = paraListNode.ChildNodes

                    For Each paraNode As Xml.XmlNode In nodeParameters
                        If (kParameter = paraNode.Name) Then
                            Dim paraSeqNo As Integer = kInvalidId
                            Dim paraName As String = String.Empty
                            Dim paraDescription As String = String.Empty
                            Dim paraMin As Double = HConstants.MinDefaultValue
                            Dim paraMax As Double = HConstants.MaxDefaultValue
                            Dim paraDefaultValue As String = String.Empty
                            Dim paraUnit As String = String.Empty
                            Dim paraShowUI As Boolean = True
                            Dim paraReadOnly As Boolean = False
                            Dim paraReadWrite As Boolean = True
                            Dim paraUnitShow As String = String.Empty
                            Dim listOfDisplayItem As List(Of KeyValuePair(Of String, String)) = Nothing

                            For Each paraChildNode As Xml.XmlNode In paraNode.ChildNodes
                                If (kParaSeqNo = paraChildNode.Name) Then
                                    Integer.TryParse(paraChildNode.InnerText, paraSeqNo)
                                ElseIf (kParaName = paraChildNode.Name) Then
                                    paraName = paraChildNode.InnerText
                                ElseIf (kParaDescription = paraChildNode.Name) Then
                                    paraDescription = paraChildNode.InnerText
                                ElseIf (kParaMin = paraChildNode.Name) Then
                                    Double.TryParse(paraChildNode.InnerText, paraMin)
                                ElseIf (kParaMax = paraChildNode.Name) Then
                                    Double.TryParse(paraChildNode.InnerText, paraMax)
                                ElseIf (kParaDefault = paraChildNode.Name) Then
                                    paraDefaultValue = paraChildNode.InnerText
                                ElseIf (kParaUnit = paraChildNode.Name) Then
                                    paraUnit = paraChildNode.InnerText
                                ElseIf (kParaUnitShow = paraChildNode.Name) Then
                                    paraUnitShow = paraChildNode.InnerText
                                ElseIf (kShowInUI = paraChildNode.Name) Then
                                    Boolean.TryParse(paraChildNode.InnerText, paraShowUI)
                                ElseIf (kReadWrite = paraChildNode.Name) Then
                                    Boolean.TryParse(paraChildNode.InnerText, paraReadWrite)
                                ElseIf (kReadOnly = paraChildNode.Name) Then
                                    Boolean.TryParse(paraChildNode.InnerText, paraReadOnly)
                                ElseIf (kDisplayItems = paraChildNode.Name) Then
                                    listOfDisplayItem = CreateListOfDisplayItem(paraChildNode.ChildNodes, groupCode, paraName, baseConfigData)
                                Else
                                    Logger.Error("Uknown parameter child node found " & paraChildNode.Name)
                                End If
                            Next

                            Dim paraSaveButNotShow As Boolean = False
                            If (paraShowUI) Then
                                Dim saveAndShow As Boolean = CheckingParameter(groupCode, paraName, paraSaveButNotShow, baseConfigData)
                                'change description
                                saveAndShow = saveAndShow And ChangeDescription(groupCode, paraName, paraDescription, paraSaveButNotShow, baseConfigData)
                                ''for Save_And_Show -> param is for DC or RF,
                                ''blnSave_And_not_show -> param is for dc or rf, but not installed
                                If (saveAndShow) OrElse (Not (saveAndShow) And paraSaveButNotShow) Then
                                    Dim anotherDbPara As DBRecipeTemplateParameter = New DBRecipeTemplateParameter(paraSeqNo, paraName, paraDescription, paraMin, paraMax, paraDefaultValue, paraUnit, paraUnitShow, paraShowUI, listOfDisplayItem)
                                    anotherDbPara.ViewOnly = paraReadOnly
                                    anotherDbPara.ReadWrite = paraReadWrite
                                    anotherDbPara.SaveNotShow = (Not (saveAndShow) And paraSaveButNotShow) Or groupSaveButNotShow

                                    If baseConfigData.IsPVDDCTargetPowerSupplyInstalled() Then
                                        If (paraName = HConstants.Pulse) Then ''this param is use for order item in datagrid
                                            pulsePara = anotherDbPara
                                        ElseIf paraName = HConstants.PulseFrequency Then
                                            pulseParaFrequency = anotherDbPara
                                        ElseIf paraName = HConstants.PulseWidth Then
                                            pulseParaDutyCycle = anotherDbPara
                                        Else
                                            listOfParameters.Add(anotherDbPara)
                                        End If
                                    Else
                                        listOfParameters.Add(anotherDbPara)
                                    End If
                                End If
                            End If
                        Else
                            Logger.Error("Uknown parameter found " & paraNode.Name)
                        End If
                    Next

                    If baseConfigData.IsPVDDCTargetPowerSupplyInstalled() Then
                        For Each para As DBRecipeTemplateParameter In listOfParameters
                            If para.Name = HConstants.TargetPower Then
                                Dim index As Integer = listOfParameters.IndexOf(para)
                                If pulsePara IsNot Nothing Then
                                    index += 1
                                    listOfParameters.Insert(index, pulsePara)
                                End If

                                If pulseParaFrequency IsNot Nothing Then
                                    index += 1
                                    listOfParameters.Insert(index, pulseParaFrequency)
                                End If

                                If pulseParaDutyCycle IsNot Nothing Then
                                    index += 1
                                    listOfParameters.Insert(index, pulseParaDutyCycle)
                                End If

                                Exit For
                            End If
                        Next
                    End If

                    listOfRecipeTemplateGroupParameters.Add(New DBRecipeTemplateGroupParameters(id, isGroup, groupCode, groupName, listOfParameters, groupSaveButNotShow))
                End If
            End If
        Next

        Return listOfRecipeTemplateGroupParameters
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Create a list of display item
    ''' </summary>
    Private Function CreateListOfDisplayItem(ByVal displayItemNodeList As System.Xml.XmlNodeList, ByVal groupCode As String, _
                                             ByVal parameterName As String, _
                                             ByVal baseConfigData As BaseConfigurationData) As List(Of KeyValuePair(Of String, String))
        Dim listOfDisplayItems As List(Of KeyValuePair(Of String, String)) = Nothing

        If (displayItemNodeList.Count > 0) Then
            listOfDisplayItems = New List(Of KeyValuePair(Of String, String))()

            For Each itemNode As Xml.XmlNode In displayItemNodeList
                If (HConstants.Item = itemNode.Name) Then
                    Dim name As String = itemNode.InnerText
                    Dim value As String = String.Empty
                    Dim valueAttribute As Xml.XmlAttribute = itemNode.Attributes(HConstants.Value)

                    If (valueAttribute IsNot Nothing) Then
                        value = valueAttribute.Value
                        CheckingListOfDisplayItem(groupCode, parameterName, name, value, baseConfigData)
                    End If

                    If (Not String.IsNullOrEmpty(name)) And (Not String.IsNullOrEmpty(value)) Then
                        listOfDisplayItems.Add(New KeyValuePair(Of String, String)(name, value))
                    End If

                End If
            Next
        End If

        Return listOfDisplayItems
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Create a list of recipe steps
    ''' </summary>
    Private Function CreateListOfRecipeSteps(ByVal recipeDoc As System.Xml.XmlDocument) As ArrayList
        Dim listOfRecipeSteps As New ArrayList()

        Try
            If recipeDoc Is Nothing Then
                Exit Try
            End If

            Dim root As System.Xml.XmlNode = recipeDoc.SelectSingleNode(HConstants.XPathRecipe)
            Dim stepList As System.Xml.XmlNode = root.SelectSingleNode("StepList")
            Dim nodeList As System.Xml.XmlNodeList = stepList.ChildNodes

            For i As Integer = 0 To nodeList.Count - 1
                Dim nodeStep As System.Xml.XmlNode = nodeList.Item(i)
                Dim nodeStepDetail As System.Xml.XmlNodeList = nodeStep.ChildNodes
                Dim seqNo As Integer = Integer.Parse(nodeStepDetail.Item(0).InnerText)
                Dim listOfGroupParameters As New ArrayList()

                For n As Integer = 1 To nodeStepDetail.Count - 1
                    Dim nodeGroupValue As System.Xml.XmlNode = nodeStepDetail.Item(n)
                    Dim groupCode As String = nodeGroupValue.Name
                    Dim nodeGroupValueDetail As System.Xml.XmlNodeList = nodeGroupValue.ChildNodes
                    Dim listOfParameters As New ArrayList()

                    For g As Integer = 0 To nodeGroupValueDetail.Count - 1
                        Dim nodeValue As System.Xml.XmlNode = nodeGroupValueDetail.Item(g)
                        Dim name As String = nodeValue.Name
                        Dim value As String = nodeValue.InnerText

                        listOfParameters.Add(New DBRecipeParameter(name, value))
                    Next

                    listOfGroupParameters.Add(New DBRecipeGroupParameters(groupCode, listOfParameters))
                Next

                listOfRecipeSteps.Add(New DBRecipeStep(seqNo, listOfGroupParameters))
            Next

        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try

        Return listOfRecipeSteps
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get description of recipe
    ''' </summary>
    Private Function GetDescription(ByVal recipeDoc As System.Xml.XmlDocument) As String
        Dim description As String = String.Empty

        Try
            If recipeDoc IsNot Nothing Then
                Dim root As System.Xml.XmlNode = recipeDoc.SelectSingleNode(HConstants.XPathRecipe)

                description = root.SelectSingleNode("Description").InnerText
            End If
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try

        Return description
    End Function

#End Region

#Region "public method"

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Create a DB recipe
    ''' </summary>
    Public Function CreateDBRecipe(ByVal recipeTemplatePath As String, ByVal recipePath As String, ByVal baseConfigData As BaseConfigurationData) As DBRecipe
        Dim dbRecipe As DBRecipe = Nothing

        Try
            Dim recipeTemplateDoc As System.Xml.XmlDocument = GetRecipeTemplate(recipeTemplatePath)
            Dim recipeDoc As System.Xml.XmlDocument = GetRecipe(recipePath)

            Dim listOfRecipeTemplateGroupParameters As ArrayList = CreateListOfRecipeTemplateGroupParameters(recipeTemplateDoc, baseConfigData)
            Dim listOfRecipeSteps As ArrayList = CreateListOfRecipeSteps(recipeDoc)
            Dim description As String = GetDescription(recipeDoc)

            dbRecipe = New DBRecipe(baseConfigData.ChamberType, baseConfigData.IsPVDDCTargetPowerSupplyInstalled(), description, listOfRecipeTemplateGroupParameters, listOfRecipeSteps)
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try

        Return dbRecipe
    End Function

#End Region

#Region "overridable and abstract method"

    Protected MustOverride Function ChangeDescription(ByVal groupCode As String, ByVal parameterName As String, ByRef parameterDescription As String, ByRef saveNotShow As Boolean, ByVal baseConfigData As BaseConfigurationData) As Boolean
    Protected MustOverride Function CheckingGroupShowInUI(ByVal groupCode As String, ByRef groupSaveButNotShow As Boolean, ByVal value As String, ByVal baseConfigData As BaseConfigurationData) As String
    Protected MustOverride Function CheckingParameter(ByVal groupCode As String, ByVal parameterName As String, ByRef saveNotShow As Boolean, ByVal baseConfigData As BaseConfigurationData) As Boolean
    Protected MustOverride Function CheckingListOfDisplayItem(ByVal groupCode As String, ByVal parameterName As String, ByRef name As String, ByRef value As String, ByVal baseConfigData As BaseConfigurationData) As Boolean

#End Region

End Class
