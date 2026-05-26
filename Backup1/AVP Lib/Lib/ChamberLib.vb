Imports AVPLib.ConstEnum
Public Class ChamberLib

#Region "Functions"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' GetMessageConfig
    ''' </summary>
    ''' <param name="MessageDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessageConfig(ByVal MessageDoc As System.Xml.XmlDocument) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetMessageConfig")
        Dim map As New Hashtable()
        Try
            Dim root As System.Xml.XmlNode = MessageDoc.FirstChild
            Dim nodeListEquipment As System.Xml.XmlNodeList = root.ChildNodes

            For e As Integer = 0 To nodeListEquipment.Count - 1
                Try
                    Dim nodeEquipment As System.Xml.XmlNode = nodeListEquipment.Item(e)
                    Dim Name As String = nodeEquipment.Name
                    Dim Value As Object = nodeEquipment.InnerText
                    map.Add(Name, Value)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetMessageConfig")
        Return map
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Get Map Document Chamber
    ''' </summary>
    ''' <param name="RecipeDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMapDocumentChamber(ByVal RecipeDoc As System.Xml.XmlDocument, Optional ByVal blnIsFirstLoad As Boolean = True) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetMapDocumentChamber")
        Dim ChamberDocMap As New Hashtable()
        Try
            Dim root As System.Xml.XmlNode = RecipeDoc.SelectSingleNode(ConstEnum.XPATH_RECIPE)
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                Dim ChamberName As String = node.Name
                Dim chamberModule As SystemModule = Nothing
                Dim bVisible As Boolean = AVPLib.ContainerData.IsChamberVisible(ChamberName, chamberModule)
                If (bVisible) Then
                    Dim strChamberType As String = chamberModule.Type.ToString()

                    Dim ChamberDoc As New System.Xml.XmlDocument()
                    Dim ChamberPath As String = String.Empty
                    '''Dat Cao chane here
                    '''with SL: only one chamber so get PVD/IBE path at template file and save to it when finish 
                    '''with CX: each chamber have one file on Chamber folder
                    '''Chamber folder not existed -> create
                    '''in Chamber folder have list chamber folder
                    '''not existed -> create
                    '''in Child chamber folder haven't Chamber file then copy template to it
                    '''existed -> check type of it
                    '''if dif type -> copy template to this file
                    '''template is PVD/IBE file in root folder
#If AVP_PLATFORM = "CX" Then
                    If (ChamberName.Contains(ConstEnum.Chamber)) OrElse (ChamberName = ConstEnum.Equipments.Aligner.ToString()) Then
                        Dim ChamberFolder As String = ContainerDAO.FPath_ChamberConfig & "\Chambers"
                        'Not exist -> Create
                        If (Not System.IO.Directory.Exists(ChamberFolder)) Then
                            System.IO.Directory.CreateDirectory(ChamberFolder)
                        End If

                        Dim ChamberSubFolder As String = ChamberFolder & "\" & ChamberName
                        'Not exist -> Create
                        If (Not System.IO.Directory.Exists(ChamberSubFolder)) Then
                            System.IO.Directory.CreateDirectory(ChamberSubFolder)
                        End If

                        Dim directoryinfo As New IO.DirectoryInfo(ChamberSubFolder)
                        Dim arrFile As IO.FileInfo() = directoryinfo.GetFiles("*.xml")
                        If ChamberName = ConstEnum.Equipments.Aligner.ToString() Then
                            ChamberPath = ChamberSubFolder & "\" & ChamberName & ".xml"
                        Else
                            ChamberPath = ChamberSubFolder & "\" & ChamberName & "_" & strChamberType & ".xml"
                        End If

                        'Folder Empty
                        If (arrFile.Length <= 0) Then
                            Dim ChamberTempPath As String = ContainerDAO.FPath_ChamberConfig & "\" & strChamberType & ".xml"
                            'IO.File.Create(ChamberPath)
                            'If (IO.File.Exists(ChamberPath)) Then
                            IO.File.Copy(ChamberTempPath, ChamberPath, True)
                            'End If
                        Else
                            'file in this folder is existed
                            If (IO.File.Exists(ChamberPath)) Then
                                'do nothing
                            Else
                                'delete old file and copy template to it
                                Dim dra As IO.FileInfo
                                'list the names of all files in the specified directory
                                For Each dra In arrFile
                                    IO.File.Delete(dra.Directory.FullName + "\" + dra.Name)
                                Next

                                Dim ChamberTempPath As String = ContainerDAO.FPath_ChamberConfig & "\" & strChamberType & ".xml"
                                ChamberPath = ChamberSubFolder & "\" & ChamberName & "_" & strChamberType & ".xml"
                                'IO.File.Create(ChamberPath)
                                'If (IO.File.Exists(ChamberPath)) Then
                                IO.File.Copy(ChamberTempPath, ChamberPath, True)
                                'End If
                            End If

                        End If
                    Else
                        ChamberPath = ContainerDAO.FPath_ChamberConfig & "\" & Utils.GetFileName(strChamberType, "xml")
                    End If
#End If
                    Try
                        ChamberDoc.Load(ChamberPath)
                        If ChamberDoc Is Nothing Then
                            If chamberModule.Type = SystemModule.ModuleType.IBE Then
                                ChamberDoc.LoadXml(XMLResources.IBE.XMLText)
                                ChamberDoc.Save(ChamberPath)
                            End If
                        End If
                        '#08/18/2011 
                        '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                        '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                        '# If any param that does not have min/max, we will have to add it's min/max.
                        '#Begin fix: Load min max value from PVD/IBE config to AVP config.
                        If blnIsFirstLoad Then
                            LoadMinMaxValueFromPM(ChamberDoc, ChamberName, strChamberType)
                            ChamberDoc.Save(ChamberPath)
                        End If
                        '#End fix.

                    Catch ex As Exception
                        ' Try to load the local file
                        Select Case chamberModule.Type
                            Case SystemModule.ModuleType.Aligner
                                ChamberDoc.LoadXml(XMLResources.Aligner.XMLText)
                            Case SystemModule.ModuleType.PVD
                                If chamberModule.DCTargetPowerVisible Then
                                    ChamberDoc.LoadXml(XMLResources.DCPVD.XMLText)
                                ElseIf chamberModule.RFTargetPowerVisible Then
                                    ChamberDoc.LoadXml(XMLResources.RFPVD.XMLText)
                                End If
                            Case SystemModule.ModuleType.IBE
                                ChamberDoc.LoadXml(XMLResources.IBE.XMLText)
                            Case SystemModule.ModuleType.PVD4
                                ChamberDoc.LoadXml(XMLResources.CORONA.XMLText)
                            Case SystemModule.ModuleType.PVD5T
                                ChamberDoc.LoadXml(XMLResources.PVD5T.XMLText)
                        End Select
                        ChamberDoc.Save(ChamberPath)
                    End Try
                    ChamberDocMap.Add(ChamberName & "." & strChamberType, ChamberDoc)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetMapDocumentChamber")
        Return ChamberDocMap
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-18</date>
    ''' </author>
    ''' <summary>
    ''' Load some min/max value from system config file to recipe file.
    ''' </summary>
    ''' <param name=""></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Sub LoadMinMaxValueFromPM(ByRef ChamberDoc As Xml.XmlDocument, ByVal strChamber As String, ByVal strType As String)
        AVPLib.Log.coreLogger.Info("Enter LoadMinMaxValueFromPM")
        Try
            Dim hstParamName As New Hashtable
            Const STR_MIN As String = "Min"
            Const STR_MAX As String = "Max"

            Dim hstGroupCode As New Hashtable

            If strType = PVD Then
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD_BIAS_POWER_MAX_SP, "BiasPower")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD_DC_POWER_MAX_SP, "TargetPower")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD_GAS1_MAX_SP, "Gas1")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD_GAS2_MAX_SP, "Gas2")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD_GAS3_MAX_SP, "Gas3")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD_GAS4_MAX_SP, "Gas4")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD_GAS5_MAX_SP, "Gas5")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD_PARALLEL_MAGNET_MAX_SP, "MagCurrent")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD_RF_POWER_MAX_SP, "Incident_RF_Power")
            ElseIf strType = STR_IBE Then
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_BEAM_VOLTAGE_MAX_SP, "Beam_Voltage")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_GAS1_MAX_SP, "Gas1")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_GAS2_MAX_SP, "Gas2")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_GAS3_MAX_SP, "Gas3")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_GAS4_MAX_SP, "Gas4")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_GAS5_MAX_SP, "Gas5")

                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_PBN_GAS_MAX_SP, "PBN_FLOWRATE")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_FLOWCOOL_GAS_MAX_SP, "FlowCool_Flowrate")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_RF_POWER_MAX_SP, "Incident_RF_Power")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_SUPPRESSOR_VOLTAGE_MAX_SP, "Suppresser_Voltage")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_TILE_ANGLE_MAX_SP, "Fixture_Angle")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_TILE_ANGLE_MIN_SP, "Fixture_Angle")

                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_BEAM_CURRENT_SP, "Beam_Current")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_K_FACTOR_SP, "K")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_SWEEP_START_SP, "Sweep_Start_Angle")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_SWEEP_END_SP, "Sweep_End_Angle")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_STATIC_ANGLE_SP, "Static_Angle")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.IBE_ROTATION_SPEED_SP, "Fixture_Rotation_Speed")
            ElseIf strType = PVD4 Then
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.CORONA_TARGET_POWER_MAX_SP, "TargetPower")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.CORONA_TARGET_POWER_MAX_SP, "RFTargetPower")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.CORONA_TARGET_DC_POWER_MAX_SP, "TargetPower")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.CORONA_TARGET_DC_POWER_MAX_SP, "DCTargetPower")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.CORONA_BIAS_POWER_MAX_SP, "BiasPower")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.CORONA_BIAS_POWER_MAX_SP, "SubstratePower")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.CORONA_GAS1_MAX_SP, "Gas1")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.CORONA_GAS1_MAX_SP, "Gasses")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.CORONA_GAS2_MAX_SP, "Gas2")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.CORONA_GAS2_MAX_SP, "Gasses")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.CORONA_GAS3_MAX_SP, "Gas3")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.CORONA_GAS3_MAX_SP, "Gasses")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.CORONA_GAS4_MAX_SP, "Gas4")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.CORONA_GAS4_MAX_SP, "Gasses")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.CORONA_GAS5_MAX_SP, "Gas5")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.CORONA_GAS5_MAX_SP, "Gasses")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.CORONA_STATIC_POSITION_SP, "StaticPostion")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.CORONA_STATIC_POSITION_SP, "ProcessControl")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.CORONA_TABLE_POS_RIGHT_MIN, "TableHeight")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.CORONA_TABLE_POS_RIGHT_MIN, "MotionControl")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.CORONA_TABLE_POS_RIGHT_MAX, "TableHeight")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.CORONA_TABLE_POS_RIGHT_MAX, "MotionControl")
            ElseIf strType = PVD5T Then
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_RF_TARGET_POWER_MAX_SP, "TargetPower")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_RF_TARGET_POWER_MAX_SP, "RFTargetPower")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_TARGET_DC_POWER_MAX_SP, "TargetPower")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_TARGET_DC_POWER_MAX_SP, "DCTargetPower")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_BIAS_POWER_MAX_SP, "BiasPower")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_BIAS_POWER_MAX_SP, "SubstratePower")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_GAS1_MAX_SP, "Gas1")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_GAS1_MAX_SP, "Gasses")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_GAS2_MAX_SP, "Gas2")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_GAS2_MAX_SP, "Gasses")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_GAS3_MAX_SP, "Gas3")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_GAS3_MAX_SP, "Gasses")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_GAS4_MAX_SP, "Gas4")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_GAS4_MAX_SP, "Gasses")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_GAS5_MAX_SP, "Gas5")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_GAS5_MAX_SP, "Gasses")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_STATIC_POSITION_SP, "StaticPostion")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_STATIC_POSITION_SP, "ProcessControl")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_TABLE_POS_RIGHT_MIN, "TableHeight")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_TABLE_POS_RIGHT_MIN, "MotionControl")
                hstParamName.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_TABLE_POS_RIGHT_MAX, "TableHeight")
                hstGroupCode.Add(PM_MIN_MAX_NAME_ITEM.PVD5T_TABLE_POS_RIGHT_MAX, "MotionControl")
            End If

            For Each strItem As String In hstParamName.Keys
                Dim lstKey As String() = strItem.Split(New String() {","}, StringSplitOptions.RemoveEmptyEntries)
                For Each item As String In lstKey
                    If item.Substring(item.Length - 3) = STR_MIN OrElse
                                       item.Substring(item.Length - 3) = STR_MAX Then
                        item = item.Remove(item.Length - 3, 3)
                    End If

                    Dim ValueMin As String = AVPLib.ContainerData.GetRobotConfig(strChamber & "." & item & STR_MIN)
                    If Not String.IsNullOrEmpty(ValueMin) Then
                        Dim node As Xml.XmlNode

                        If strType = PVD4 OrElse strType = PVD5T Then
                            node = ChamberDoc.SelectSingleNode(String.Format("/RecipeDef/ParameterList[@Group='{0}']/Parameter[Name = '{1}']/Min",
                                                                                                        hstGroupCode(strItem), hstParamName(strItem)))
                        Else
                            node = ChamberDoc.SelectSingleNode(String.Format("/RecipeDef/ParameterList/Parameter[Name = '{0}']/Min",
                                                                            hstParamName(strItem)))
                        End If

                        If (node IsNot Nothing) Then
                            node.InnerText = ValueMin
                        End If
                    End If
                    Dim ValueMax As String = AVPLib.ContainerData.GetRobotConfig(strChamber & "." & item & STR_MAX)
                    If Not String.IsNullOrEmpty(ValueMax) Then
                        Dim node As Xml.XmlNode
                        If strType = PVD4 OrElse strType = PVD5T Then
                            node = ChamberDoc.SelectSingleNode(String.Format("/RecipeDef/ParameterList[@Group='{0}']/Parameter[Name = '{1}']/Max",
                                                                                                        hstGroupCode(strItem), hstParamName(strItem)))
                        Else
                            node = ChamberDoc.SelectSingleNode(String.Format("/RecipeDef/ParameterList/Parameter[Name = '{0}']/Max",
                                                                            hstParamName(strItem)))
                        End If
                        If (node IsNot Nothing) Then
                            node.InnerText = ValueMax
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave LoadMinMaxValueFromPM")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Get Map Document List Chamber(Detail each chamber)
    ''' </summary>
    ''' <param name="RecipeDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMapDocumentListChamber(ByVal RecipeDoc As System.Xml.XmlDocument) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetMapDocumentListChamber")
        Dim ChamberDocMap As New Hashtable()
        Try
            Dim ListRecipe As New ArrayList()
            Dim root As System.Xml.XmlNode = RecipeDoc.SelectSingleNode(ConstEnum.XPATH_RECIPE)
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                Dim ChamberName As String = node.Name
                Dim ListChamberName As ArrayList = GetListChamberDoc(ChamberName)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetMapDocumentListChamber")
        Return ChamberDocMap
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Get List Recipe
    ''' </summary>
    ''' <param name="RecipeDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetListRecipe(ByVal RecipeDoc As System.Xml.XmlDocument) As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetListRecipe")
        Try
            Dim ListRecipe As New ArrayList()
            Dim root As System.Xml.XmlNode = RecipeDoc.SelectSingleNode(ConstEnum.XPATH_RECIPE)
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                Dim ChamberName As String = node.Name
                Dim bVisible As Boolean = True

                If (ChamberName.IndexOf(ConstEnum.Chamber) >= 0) Then
                    bVisible = ContainerData.IsChamberVisible(ChamberName)
                ElseIf (ChamberName = ConstEnum.Equipments.IBE.ToString) Then
                    bVisible = True
                End If

                If (bVisible) Or ChamberName.IndexOf(ConstEnum.Equipments.Aligner) >= 0 Then
                    Dim ChamberNameActive As String = node.InnerText
                    Dim ListChamberName As ArrayList = GetRecipesOfChamber(ChamberName)
                    ListRecipe.Add(New DBRecipe(ChamberName, ChamberNameActive, ListChamberName))
                End If
            Next
            AVPLib.Log.coreLogger.Info("Leave GetListRecipe")
            Return ListRecipe
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetListRecipe")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-07</date>
    ''' </author>
    ''' <summary>
    ''' Get List Chamber Name that support GetListRecipe
    ''' </summary>
    ''' <param name="Chamber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetRecipesOfChamber(ByVal Chamber As String) As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetListChamberName")
        Try
            Dim ListChamberName As New ArrayList()
            Dim strPath As String = ContainerDAO.FPath_ChamberRecipe + "\" + Chamber

            'get recipe list of ANYIBE

            If (Utils.IsIBEChamber_ANYIBE(Chamber) OrElse Chamber = ConstEnum.Equipments.IBE.ToString) Then
                strPath = ContainerDAO.FPath_ChamberRecipe + "\" + RobotConfigurationValues.ANY_IBE_CHAMBER
            End If

            If IO.Directory.Exists(strPath) Then
                Dim Files As String() = System.IO.Directory.GetFiles(strPath, "*.xml")
                For Each File As String In Files
                    If Utils.CanToAddFile(File) Then
                        ListChamberName.Add(Utils.GetFileName(File, True))
                    End If
                Next
                AVPLib.Log.coreLogger.Info("Leave GetListChamberName")
                Return ListChamberName
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetListChamberName")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-07</date>
    ''' </author>
    ''' <summary>
    ''' Get List ChamberDoc
    ''' </summary>
    ''' <param name="Chamber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetListChamberDoc(ByVal Chamber As String) As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetListChamberDoc")
        Try
            Dim ListChamberDoc As New ArrayList()
            Dim Files As String() = System.IO.Directory.GetFiles(ContainerDAO.FPath_ChamberRecipe + "\" + Chamber, "*.xml")
            For Each File As String In Files
                Dim ChamberDoc As New System.Xml.XmlDocument()
                ChamberDoc.Load(File)
                ListChamberDoc.Add(ChamberDoc)
            Next
            AVPLib.Log.coreLogger.Info("Leave GetListChamberDoc")
            Return ListChamberDoc
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetListChamberDoc")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-07</date>
    ''' </author>
    ''' <summary>
    ''' GetChamber
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <param name="ChamberParameterDoc"></param>
    ''' <param name="ChamberParameterValueDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChamber(ByVal ChamberName As String, ByVal ChamberParameterDoc As System.Xml.XmlDocument, ByVal ChamberParameterValueDoc As System.Xml.XmlDocument) As DBChamber
        AVPLib.Log.coreLogger.Info("Enter GetChamber")
        Try
            Dim objchamber As SystemModule = Nothing
            If AVPLib.ContainerData.IsChamberVisible(ChamberName, objchamber) Then
                Dim GetListGroupParameter As ArrayList = GetListGroupParameters(ChamberParameterDoc, objchamber.DCTargetPowerVisible, objchamber)
                Dim GetListGroupParameterValue As ArrayList = GetListGroupParameterValues(ChamberParameterValueDoc)
                Dim ChamberDescription As String = GetChamberDescription(ChamberParameterValueDoc)
                AVPLib.Log.coreLogger.Info("Leave GetChamber")
                Return New DBChamber(ChamberName, objchamber.Type.ToString(), ChamberDescription, GetListGroupParameter, GetListGroupParameterValue)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetChamber")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Get Chamber Empty
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <param name="ChamberParameterDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChamberEmpty(ByVal ChamberName As String, ByVal ChamberParameterDoc As System.Xml.XmlDocument, ByVal ChamberParameterValueDoc As System.Xml.XmlDocument) As DBChamber
        AVPLib.Log.coreLogger.Info("Enter GetChamberEmpty")
        Try
            Dim objchamber As SystemModule = Nothing
            If AVPLib.ContainerData.IsChamberVisible(ChamberName, objchamber) Then
                Dim GetListGroupParameter As ArrayList = GetListGroupParameters(ChamberParameterDoc, objchamber.DCTargetPowerVisible, objchamber)
                Dim ChamberDescription As String = GetChamberDescription(ChamberParameterValueDoc)
                AVPLib.Log.coreLogger.Info("Leave GetChamberEmpty")
                Return New DBChamber(ChamberName, objchamber.Type.ToString(), ChamberDescription, GetListGroupParameter, Nothing)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetChamberEmpty")
        Return Nothing
    End Function

    Public Shared Function GetListOfDisplayItem(ByVal DisplayItemNodeList As System.Xml.XmlNodeList, ByVal GroupCode As String,
                                                ByVal paraName As String, ByRef paraDefaultValue As String,
                                                ByVal objChamber As SystemModule, ByRef ListOfSeqNoDisable As Hashtable,
                                                ByRef ListOfSeqNoCalculate As Hashtable) As List(Of KeyValuePair(Of String, String))
        Const kItem As String = "Item"
        Const kValue As String = "Value"
        Const kSeqNoDisable As String = "SeqNoDisable"
        Const kSeqNoCalculate As String = "SeqNoCalculate"
        Const PARA_NAME_TARGET_SELECTION As String = "TargetSelection"
        Const TARGET As String = "T"

        Try
            If (DisplayItemNodeList.Count > 0) Then
                Dim listOfDisplayItems As New List(Of KeyValuePair(Of String, String))()
                For Each itemNode As Xml.XmlNode In DisplayItemNodeList
                    If (kItem = itemNode.Name) Then
                        Dim strName As String = itemNode.InnerText
                        Dim strVal As String = String.Empty
                        Dim valueAttribute As Xml.XmlAttribute = itemNode.Attributes(kValue)
                        If (valueAttribute IsNot Nothing) Then
                            strVal = valueAttribute.Value

                            If objChamber.Type = SystemModule.ModuleType.PVD4 OrElse objChamber.Type = SystemModule.ModuleType.PVD5T Then
                                If (GroupCode = "DCTargetPower" AndAlso paraName = PARA_NAME_TARGET_SELECTION) OrElse
                                   (GroupCode = "RFTargetPower" AndAlso paraName = PARA_NAME_TARGET_SELECTION) Then

                                    Dim maxTarget = 4  'max target in PVD4
                                    If (objChamber.Type = SystemModule.ModuleType.PVD5T) Then
                                        maxTarget = 5 'max target in PVD5T
                                    End If

                                    Dim indexTarget As String = IIf(Integer.Parse(strName.Replace(TARGET, "")) = 1, "", (Integer.Parse(strName.Replace(TARGET, "")) - 1).ToString)
                                    strName = strName & " (" & objChamber.GetType().GetProperty(TARGET_MATERIAL & indexTarget).GetValue(objChamber, Nothing) & ")"
                                    paraDefaultValue = String.Empty
                                    For i As Integer = 1 To maxTarget
                                        If CType(objChamber.GetType().GetProperty("Target" & IIf(i = 1, "", i) & "Visible").GetValue(objChamber, Nothing), Boolean) Then
                                            paraDefaultValue = TARGET & i & " (" & objChamber.GetType().GetProperty("Target_Material" & IIf(i = 1, "", i - 1)).GetValue(objChamber, Nothing) & ")"
                                            Exit For
                                        End If
                                    Next
                                End If

                                If GroupCode = "ProcessControl" AndAlso paraName = "ControlMode" AndAlso strName = "Thickness" AndAlso
                                   (objChamber.FilMetricDevice_Installed = False) Then
                                    Continue For
                                End If

                            End If
                        End If

                        If (Not String.IsNullOrEmpty(strName)) And (Not String.IsNullOrEmpty(strVal)) Then
                            listOfDisplayItems.Add(New KeyValuePair(Of String, String)(strName, strVal))
                        End If
                        '2013-07-11 Tin Pham
                        Dim seqNoDisableAttribute As Xml.XmlAttribute = itemNode.Attributes(kSeqNoDisable)
                        If (seqNoDisableAttribute IsNot Nothing) Then
                            strVal = seqNoDisableAttribute.Value
                            If (Not String.IsNullOrEmpty(strName)) And (Not String.IsNullOrEmpty(strVal)) Then
                                ListOfSeqNoDisable.Add(strName, strVal)
                            End If
                        End If
                        Dim seqNoCalculateAttribute As Xml.XmlAttribute = itemNode.Attributes(kSeqNoCalculate)
                        If (seqNoCalculateAttribute IsNot Nothing) Then
                            strVal = seqNoCalculateAttribute.Value
                            If (Not String.IsNullOrEmpty(strName)) And (Not String.IsNullOrEmpty(strVal)) Then
                                ListOfSeqNoCalculate.Add(strName, strVal)
                            End If
                        End If
                        '-------------------
                    End If
                Next
                Return listOfDisplayItems
            Else
                Return Nothing
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    Public Shared Function GetListGroupParameters(ByVal ParameterListNodeList As System.Xml.XmlNodeList,
                                                  ByVal isDCTargetPowerVisible As Boolean, ByVal objchamber As SystemModule) As ArrayList
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


        Dim ListGroupParameters As New ArrayList()

        For Each paraListNode As Xml.XmlNode In ParameterListNodeList
            If (kParameterList = paraListNode.Name) Then
                Dim Id As Integer = kInvalidId
                Dim isGroup As Boolean = True
                Dim GroupCode As String = String.Empty
                Dim GroupName As String = String.Empty
                Dim groupShowInUI As String = Boolean.TrueString
                Dim blnGroup_Save_But_Not_Show As Boolean = False
                For Each paraListAttr As Xml.XmlAttribute In paraListNode.Attributes
                    If (kId = paraListAttr.Name) Then
                        Integer.TryParse(paraListAttr.Value, Id)
                    ElseIf (kIsGroup = paraListAttr.Name) Then
                        Dim tmpIsGroup As Integer = 0
                        Integer.TryParse(paraListAttr.Value, tmpIsGroup)
                        isGroup = IIf(tmpIsGroup >= 1, True, False)
                    ElseIf (kGroupCode = paraListAttr.Name) Then
                        GroupCode = paraListAttr.Value
                    ElseIf (kGroupName = paraListAttr.Name) Then
                        GroupName = paraListAttr.Value
                    ElseIf (kShowInUI = paraListAttr.Name) Then
                        If objchamber.Type = SystemModule.ModuleType.PVD4 Or objchamber.Type = SystemModule.ModuleType.IBE Then
                            Select Case GroupCode
                                Case "RFTargetPower"
                                    If objchamber.RFTargetPowerVisible = False OrElse objchamber.DCTargetPowerVisible = True Then
                                        groupShowInUI = IIf(objchamber.RFTargetPowerVisible = False,
                                                            objchamber.RFTargetPowerVisible.ToString(),
                                                            (Not objchamber.RFTargetPowerVisible).ToString())
                                        blnGroup_Save_But_Not_Show = Not objchamber.RFTargetPowerVisible
                                    End If
                                Case "DCTargetPower"
                                    If objchamber.DCTargetPowerVisible = False AndAlso objchamber.RFTargetPowerVisible = True Then
                                        groupShowInUI = objchamber.DCTargetPowerVisible.ToString()
                                        blnGroup_Save_But_Not_Show = Not objchamber.DCTargetPowerVisible
                                    End If
                                Case "FilMetricControl"
                                    If objchamber.FilMetricDevice_Installed = False Then
                                        groupShowInUI = objchamber.FilMetricDevice_Installed.ToString()
                                        blnGroup_Save_But_Not_Show = Not objchamber.FilMetricDevice_Installed
                                    End If
                                Case "TiltSweep"
                                    If objchamber.SupportTiltSweepMode = False Then
                                        groupShowInUI = objchamber.SupportTiltSweepMode.ToString()
                                        blnGroup_Save_But_Not_Show = Not objchamber.SupportTiltSweepMode
                                    End If
                                Case Else
                                    groupShowInUI = paraListAttr.Value
                            End Select
                        ElseIf objchamber.Type = SystemModule.ModuleType.PVD5T Then
                            Select Case GroupCode
                                Case "RFTargetPower"
                                    If objchamber.RFTargetPowerVisible = False Then
                                        groupShowInUI = objchamber.RFTargetPowerVisible.ToString()
                                        blnGroup_Save_But_Not_Show = Not objchamber.RFTargetPowerVisible
                                    End If
                                Case "DCTargetPower"
                                    If objchamber.DCTargetPowerVisible = False Then
                                        groupShowInUI = objchamber.DCTargetPowerVisible.ToString()
                                        blnGroup_Save_But_Not_Show = Not objchamber.DCTargetPowerVisible
                                    End If
                                Case "FilMetricControl"
                                    If objchamber.FilMetricDevice_Installed = False Then
                                        groupShowInUI = objchamber.FilMetricDevice_Installed.ToString()
                                        blnGroup_Save_But_Not_Show = Not objchamber.FilMetricDevice_Installed
                                    End If
                                Case "TiltSweep"
                                    If objchamber.SupportTiltSweepMode = False Then
                                        groupShowInUI = objchamber.SupportTiltSweepMode.ToString()
                                        blnGroup_Save_But_Not_Show = Not objchamber.SupportTiltSweepMode
                                    End If
                                Case Else
                                    groupShowInUI = paraListAttr.Value
                            End Select
                        Else
                            groupShowInUI = paraListAttr.Value
                        End If
                    Else
                        AVPLib.Log.coreLogger.Error("Uknown group attribute found " & paraListAttr.Name)
                    End If
                Next
                If (Boolean.TrueString.ToLower() = groupShowInUI.ToLower()) OrElse
                (blnGroup_Save_But_Not_Show And Boolean.FalseString.ToLower() = groupShowInUI.ToLower()) Then
                    Dim Parameters As New ArrayList()
                    Dim pulsePara As DBParameter = Nothing
                    Dim pulseParaFrequency As DBParameter = Nothing
                    Dim pulseParaDutyCycle As DBParameter = Nothing
                    Dim tarpowerPara As DBParameter = Nothing
                    Dim nodeParameters As System.Xml.XmlNodeList = paraListNode.ChildNodes
                    For Each paraNode As Xml.XmlNode In nodeParameters
                        If (kParameter = paraNode.Name) Then
                            Dim paraSeqNo As Integer = kInvalidId
                            Dim paraName As String = String.Empty
                            Dim paraDescription As String = String.Empty
                            Dim paraMin As Double = MIN_DEFAULT_VALUE
                            Dim paraMax As Double = MAX_DEFAULT_VALUE
                            Dim paraDefaultValue As String = String.Empty
                            Dim paraUnit As String = String.Empty
                            Dim paraShowUI As Boolean = True
                            Dim paraReadOnly As Boolean = False
                            Dim paraReadWrite As Boolean = True
                            Dim paraUnitShow As String = String.Empty
                            Dim listOfDisplayItem As List(Of KeyValuePair(Of String, String)) = Nothing
                            Dim listOfSeqNoDisable As Hashtable = New Hashtable()
                            Dim listOfSeqNoCalculate As Hashtable = New Hashtable()
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
                                    listOfDisplayItem = GetListOfDisplayItem(paraChildNode.ChildNodes, GroupCode, paraName, paraDefaultValue, objchamber, listOfSeqNoDisable, listOfSeqNoCalculate)
                                Else
                                    AVPLib.Log.coreLogger.Error("Uknown parameter child node found " & paraChildNode.Name)
                                End If
                            Next
                            Dim blnpara_Save_But_Not_Show As Boolean = False
                            If (paraShowUI) Then
                                Dim blnSave_And_Show As Boolean = CheckingParameter(paraName, GroupCode, objchamber, blnpara_Save_But_Not_Show)
                                'change description
                                ChangeDescription(paraName, paraDescription, objchamber, blnpara_Save_But_Not_Show)
                                ''for Save_And_Show -> param is for DC or RF,
                                ''blnSave_And_not_show -> param is for dc or rf, but not installed
                                If (blnSave_And_Show) OrElse (Not (blnSave_And_Show) And blnpara_Save_But_Not_Show) Then
                                    Dim anotherDbPara As DBParameter = New DBParameter(paraSeqNo, paraName, paraDescription, paraMin, paraMax, paraDefaultValue, paraUnit, paraUnitShow, paraShowUI, listOfDisplayItem, listOfSeqNoDisable, listOfSeqNoCalculate)
                                    anotherDbPara.ViewOnly = paraReadOnly
                                    anotherDbPara.ReadWrite = paraReadWrite
                                    anotherDbPara.Save_Not_Show = (Not (blnSave_And_Show) And blnpara_Save_But_Not_Show) Or blnGroup_Save_But_Not_Show
                                    If isDCTargetPowerVisible Then
                                        If (paraName = "Pulse") Then ''this param is use for order item in datagrid
                                            pulsePara = anotherDbPara
                                        ElseIf paraName = "PulseFrequency" Then
                                            pulseParaFrequency = anotherDbPara
                                        ElseIf paraName = "PulseWidth" Then
                                            pulseParaDutyCycle = anotherDbPara
                                        Else
                                            Parameters.Add(anotherDbPara)
                                        End If
                                    Else
                                        Parameters.Add(anotherDbPara)
                                    End If
                                End If
                            End If
                        Else
                            AVPLib.Log.coreLogger.Error("Uknown parameter found " & paraNode.Name)
                        End If
                    Next
                    If isDCTargetPowerVisible Then
                        For Each para As DBParameter In Parameters
                            If para.Name = "TargetPower" Then
                                Dim index As Integer = Parameters.IndexOf(para)
                                If pulsePara IsNot Nothing Then
                                    index += 1
                                    Parameters.Insert(index, pulsePara)
                                End If
                                If pulseParaDutyCycle IsNot Nothing Then
                                    index += 1
                                    Parameters.Insert(index, pulseParaFrequency)
                                End If
                                If pulseParaDutyCycle IsNot Nothing Then
                                    index += 1
                                    Parameters.Insert(index, pulseParaDutyCycle)
                                End If
                                Exit For
                            End If
                        Next
                    End If
                    ListGroupParameters.Add(New DBParameterGroup(Id, isGroup, GroupCode, GroupName, Parameters, blnGroup_Save_But_Not_Show))
                End If
            End If
        Next
        Return ListGroupParameters
    End Function


    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-01-02 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ChangeDescription(ByVal paraName As String, ByRef paraDescription As String, ByVal objChamber As SystemModule, ByRef blnSave_Not_Show As Boolean) As Boolean
        Try
            If objChamber Is Nothing Then
                Return False
            End If
            Select Case paraName
                Case "Gas1"
                    paraDescription = String.Format(paraDescription, objChamber.Gas1Name)
                    blnSave_Not_Show = (objChamber.Gas1ShutoffPresent = False And objChamber.Gas1SupplyPresent = False)
                    Return Not blnSave_Not_Show
                Case "Gas2"
                    paraDescription = String.Format(paraDescription, objChamber.Gas2Name)
                    blnSave_Not_Show = (objChamber.gas2ShutoffPresent = False And objChamber.Gas2SupplyPresent = False)
                    Return Not blnSave_Not_Show
                Case "Gas3"
                    paraDescription = String.Format(paraDescription, objChamber.Gas3Name)
                    blnSave_Not_Show = (objChamber.gas3ShutoffPresent = False And objChamber.Gas3SupplyPresent = False)
                    Return Not blnSave_Not_Show
                Case "Gas4"
                    paraDescription = String.Format(paraDescription, objChamber.Gas4Name)
                    blnSave_Not_Show = (objChamber.gas4ShutoffPresent = False And objChamber.Gas4SupplyPresent = False)
                    Return Not blnSave_Not_Show
                Case "Gas5"
                    paraDescription = String.Format(paraDescription, objChamber.Gas5Name)
                    blnSave_Not_Show = (objChamber.gas5ShutoffPresent = False And objChamber.Gas5SupplyPresent = False)
                    Return Not blnSave_Not_Show
                Case "FlowcoolGas"
                    paraDescription = String.Format(paraDescription, objChamber.FlowcoolGasName)
                    blnSave_Not_Show = (objChamber.gas5ShutoffPresent = False And objChamber.Gas5SupplyPresent = False)
                    Return Not blnSave_Not_Show
                Case "StaticPostion"
                    If objChamber.Type = SystemModule.ModuleType.PVD4 OrElse objChamber.Type = SystemModule.ModuleType.PVD5T Then
                        paraDescription = String.Format(paraDescription, objChamber.MaxNumberOfSlot)
                    End If
                Case "TargetPulseWidth"
                    If objChamber.Type <> SystemModule.ModuleType.PVD5T AndAlso objChamber.DCTargetPowerModel = SystemModule.Power_Supply_Model.AE_PULSE_DC Then
                        paraDescription = "Target Pulse Width (µs)"
                    End If
                Case "PBN_FLOWRATE"
                    paraDescription = String.Format(paraDescription, objChamber.PBNGasName)
                    blnSave_Not_Show = (objChamber.PBNGasShutoffPresent = False And objChamber.PBNGasSupplyPresent = False)
                    Return Not blnSave_Not_Show
                Case "FlowCool_Flowrate"
                    paraDescription = String.Format(paraDescription, objChamber.FlowcoolGasName)
                    blnSave_Not_Show = (objChamber.FlowcoolGasShutoffPresent = False And objChamber.FlowcoolGasSupplyPresent = False)
                    Return Not blnSave_Not_Show
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
        Return True
    End Function

    Private Shared Function CheckingParameter(ByVal paraName As String, ByVal groupCode As String, ByVal objChamber As SystemModule, ByRef blnSave_Not_Show As Boolean) As Boolean
        If objChamber Is Nothing Then
            Return False
        End If

        If objChamber.Type = SystemModule.ModuleType.PVD5T AndAlso (groupCode = "RFTargetPower" OrElse groupCode = "DCTargetPower") Then
            'hide all params that is not belong to RF or DC
            If objChamber.DCTargetPowerVisible AndAlso groupCode = "DCTargetPower" Then
                If objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG_50_100 AndAlso
                objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG50 AndAlso
                    objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG100 Then
                    '''check Ps Model to set Pulse Mode
                    If (paraName = "Pulse" OrElse paraName = "PulseFrequency" OrElse paraName = "PulseWidth") Then
                        blnSave_Not_Show = True
                        Return False
                    End If
                End If
                ''hide RF Param
                If (paraName = "TargetC1" OrElse paraName = "TargetC2" OrElse paraName = "TargetMatchingMode") Then
                    blnSave_Not_Show = True
                    Return False
                End If
            End If

            If objChamber.RFTargetPowerVisible AndAlso groupCode = "RFTargetPower" Then
                If (paraName = "Pulse" OrElse paraName = "PulseFrequency" OrElse paraName = "PulseWidth" OrElse
                    (paraName = "Source_Electromagnet_Current" AndAlso Not objChamber.SourceMagnetVisible)) Then
                    blnSave_Not_Show = True
                    Return False
                End If
            End If
        Else
            'hide all params that is not belong to RF or DC
            ''this is DC chamber -> hide RF param
            If objChamber.DCTargetPowerVisible Then
                If objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG_50_100 AndAlso
                objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG50 AndAlso
                    objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG100 Then
                    '''check Ps Model to set Pulse Mode
                    If (paraName = "Pulse" OrElse paraName = "PulseFrequency" OrElse paraName = "PulseWidth") Then
                        blnSave_Not_Show = True
                        Return False
                    End If
                End If
                ''hide RF Param
                If (paraName = "TargetC1" OrElse paraName = "TargetC2" OrElse paraName = "TargetMatchingMode") Then
                    blnSave_Not_Show = True
                    Return False
                End If
            ElseIf objChamber.RFTargetPowerVisible Then 'this is RF Chamber -> hide DC param
                If (paraName = "Pulse" OrElse paraName = "PulseFrequency" OrElse paraName = "PulseWidth" OrElse (paraName = "Source_Electromagnet_Current" AndAlso Not objChamber.SourceMagnetVisible)) Then
                    blnSave_Not_Show = True
                    Return False
                End If
            End If
        End If

        'remove param that is belong to RF/DC but sometime it is invisible
        If objChamber.DCTargetPowerVisible = False And objChamber.RFTargetPowerVisible = False Then
            If (paraName = "TargetC1" OrElse paraName = "TargetC2" OrElse paraName = "TargetMatchingMode") OrElse
             (paraName = "Pulse" OrElse paraName = "PulseFrequency" OrElse paraName = "PulseWidth") OrElse
             (paraName = "RampTime") OrElse paraName = "TargetPower" Then
                ''this is Etch Chamber -> so hide those RF, DC param
                blnSave_Not_Show = True
                Return False
            End If
        End If

        '2013-01-02 Tin Pham added: just for Corona
        If objChamber.Type = SystemModule.ModuleType.PVD4 Then
            Select Case groupCode
                Case "RFTargetPower"
                    If objChamber.RFTargetPowerVisible = False OrElse objChamber.DCTargetPowerVisible = True Then
                        If (paraName = "TargetPower" OrElse paraName = "TargetRampTime" OrElse paraName = "TargetShutterOpen" _
                            OrElse paraName = "TargetSelection") Then
                            blnSave_Not_Show = True
                            Return False
                        End If
                    End If
                Case "DCTargetPower"
                    If objChamber.DCTargetPowerVisible = False AndAlso objChamber.RFTargetPowerVisible = True Then
                        If (paraName = "TargetPower" OrElse paraName = "TargetRampTime" OrElse paraName = "TargetShutterOpen" _
                            OrElse paraName = "TargetPulseFrequency" OrElse paraName = "TargetPulseWidth" OrElse paraName = "TargetSelection") Then
                            blnSave_Not_Show = True
                            Return False
                        End If
                    End If
                    If objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG_50_100 AndAlso
                     objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG50 AndAlso
                     objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG100 AndAlso
                     objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.AE_PULSE_DC Then
                        If (paraName = "TargetPulseFrequency" OrElse paraName = "TargetPulseWidth") Then
                            blnSave_Not_Show = True
                            Return False
                        End If
                    End If
                Case "Gasses"
                    If objChamber.GasInjectionInstall = True Then
                        If (paraName = "UseGasDistribution" Or paraName = "UseSecondaryGasOnly") OrElse
                        (objChamber.IsSupportMainSecondDistributionValves = False AndAlso (paraName = "UseMainDist" Or paraName = "UseSeconDist")) Then
                            blnSave_Not_Show = True
                            Return False
                        End If
                    Else
                        If (paraName = "UseMainDist" Or paraName = "UseSeconDist") Then
                            blnSave_Not_Show = True
                            Return False
                        End If
                    End If
            End Select

        ElseIf objChamber.Type = SystemModule.ModuleType.PVD5T Then
            Select Case groupCode
                Case "RFTargetPower"
                    If objChamber.RFTargetPowerVisible = False Then
                        If (paraName = "TargetPower" OrElse paraName = "TargetRampTime" OrElse paraName = "TargetShutterOpen" _
                            OrElse paraName = "TargetSelection") Then
                            blnSave_Not_Show = True
                            Return False
                        End If
                    End If
                Case "DCTargetPower"
                    If objChamber.DCTargetPowerVisible = False Then
                        If (paraName = "TargetPower" OrElse paraName = "TargetRampTime" OrElse paraName = "TargetShutterOpen" _
                            OrElse paraName = "TargetPulseFrequency" OrElse paraName = "TargetPulseWidth" OrElse paraName = "TargetSelection") Then
                            blnSave_Not_Show = True
                            Return False
                        End If
                    End If
                    If objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG_50_100 AndAlso
                        objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG50 AndAlso
                        objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.ENI_RPG100 AndAlso
                        objChamber.DCTargetPowerModel <> SystemModule.Power_Supply_Model.AE_PULSE_DC Then
                        If (paraName = "TargetPulseFrequency" OrElse paraName = "TargetPulseWidth") Then
                            blnSave_Not_Show = True
                            Return False
                        End If
                    End If
            End Select
        End If
        'End --------------------------------------

        'check for Bias not installed -> hide all Bias Param
        If objChamber.BiasPowerVisible = False And
        (paraName = "BiasPower" OrElse paraName = "BiasVoltage" OrElse paraName = "BiasC1" OrElse paraName = "BiasC2" _
        OrElse paraName = "BiasMatchingMode" OrElse paraName = "BiasC1C2FromRecipe" OrElse paraName = "BiasControl") Then
            blnSave_Not_Show = True
            Return False
        ElseIf objChamber.Gas1ShutoffPresent = False And objChamber.Gas1SupplyPresent = False _
               And paraName = "Gas1" Then
            blnSave_Not_Show = True
            Return False
        ElseIf objChamber.gas2ShutoffPresent = False And objChamber.Gas2SupplyPresent = False _
                And paraName = "Gas2" Then
            blnSave_Not_Show = True
            Return False
        ElseIf objChamber.gas3ShutoffPresent = False And objChamber.Gas3SupplyPresent = False _
                  And paraName = "Gas3" Then
            blnSave_Not_Show = True
            Return False
        ElseIf objChamber.gas4ShutoffPresent = False And objChamber.Gas4SupplyPresent = False _
                  And paraName = "Gas4" Then
            blnSave_Not_Show = True
            Return False
        ElseIf objChamber.gas5ShutoffPresent = False And objChamber.Gas5SupplyPresent = False _
                  And paraName = "Gas5" Then
            blnSave_Not_Show = True
            Return False
        ElseIf objChamber.ShutterVisible = False And paraName = "OpenShutter" Then
            blnSave_Not_Show = True
            Return False
        ElseIf objChamber.ParallelMagnetVisible = False And
            (paraName = "MagnetState" Or paraName = "MagCurrent" Or paraName = "MagFrequency" Or paraName = "MagnetDutyCycle") Then
            blnSave_Not_Show = True
            Return False
        ElseIf objChamber.DiverterGasValveVisible = False And paraName = "RIBE" Then
            blnSave_Not_Show = True
            Return False
        ElseIf objChamber.CryoVisible = False And paraName = "OpenCryoGate" Then
            blnSave_Not_Show = True
            Return False
        End If
        Return True
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-07</date>
    ''' </author>
    ''' <summary>
    ''' Get List GroupParameters
    ''' </summary>
    ''' <param name="ChamberParameterDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetListGroupParameters(ByVal ChamberParameterDoc As System.Xml.XmlDocument,
                                                  ByVal IsDCTargetPowerVisible As Boolean, ByVal objChamber As SystemModule) As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetListGroupParameters")
        Dim ListGroupParameters As ArrayList = Nothing
        Try
            If ChamberParameterDoc Is Nothing Then
                ListGroupParameters = New ArrayList()
            Else
                Dim root As System.Xml.XmlNode = ChamberParameterDoc.FirstChild
                Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
                ListGroupParameters = GetListGroupParameters(nodeList, IsDCTargetPowerVisible, objChamber)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetListGroupParameters")
        Return ListGroupParameters
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Get List GroupParameterValues
    ''' </summary>
    ''' <param name="ChamberParameterValueDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetListGroupParameterValues(ByVal ChamberParameterValueDoc As System.Xml.XmlDocument) As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetListGroupParameterValues")
        Try
            Dim ListSteps As New ArrayList()

            If ChamberParameterValueDoc Is Nothing Then
                AVPLib.Log.coreLogger.Info("Leave GetListGroupParameterValues")
                Return ListSteps
            End If

            Dim root As System.Xml.XmlNode = ChamberParameterValueDoc.SelectSingleNode(XPATH_RECIPE)
            Dim StepList As System.Xml.XmlNode = root.SelectSingleNode("StepList")

            Dim nodeList As System.Xml.XmlNodeList = StepList.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim nodeStep As System.Xml.XmlNode = nodeList.Item(i)

                Dim nodeStepDetail As System.Xml.XmlNodeList = nodeStep.ChildNodes
                Dim SeqNo As Integer = Integer.Parse(nodeStepDetail.Item(0).InnerText)

                Dim ListGroupParameterValues As New ArrayList()
                For n As Integer = 1 To nodeStepDetail.Count - 1
                    Dim nodeGroupValue As System.Xml.XmlNode = nodeStepDetail.Item(n)
                    Dim GroupCode As String = nodeGroupValue.Name

                    Dim nodeGroupValueDetail As System.Xml.XmlNodeList = nodeGroupValue.ChildNodes
                    Dim ListParameterValues As New ArrayList()

                    For g As Integer = 0 To nodeGroupValueDetail.Count - 1
                        Dim nodeValue As System.Xml.XmlNode = nodeGroupValueDetail.Item(g)
                        Dim ValueName As String = nodeValue.Name
                        Dim Value As String = nodeValue.InnerText
                        ListParameterValues.Add(New DBParameterValue(ValueName, Value))
                    Next

                    ListGroupParameterValues.Add(New DBGroupParameterValue(GroupCode, ListParameterValues))
                Next
                ListSteps.Add(New DBChamberStep(SeqNo, ListGroupParameterValues))
            Next
            AVPLib.Log.coreLogger.Info("Leave GetListGroupParameterValues")
            Return ListSteps
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetListGroupParameterValues")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' GetChamberDescription
    ''' </summary>
    ''' <param name="ChamberParameterValueDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetChamberDescription(ByVal ChamberParameterValueDoc As System.Xml.XmlDocument) As String
        AVPLib.Log.coreLogger.Info("Enter GetChamberDescription")
        Try
            If ChamberParameterValueDoc Is Nothing Then
                AVPLib.Log.coreLogger.Info("Leave GetChamberDescription")
                Return ""
            End If

            Dim root As System.Xml.XmlNode = ChamberParameterValueDoc.SelectSingleNode(XPATH_RECIPE)
            Dim Description As String = root.SelectSingleNode("Description").InnerText
            AVPLib.Log.coreLogger.Info("Leave GetChamberDescription")
            Return Description
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetChamberDescription")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' SaveChamber
    ''' </summary>
    ''' <param name="Chamber"></param>
    ''' <param name="FilePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveChamber(ByVal Chamber As DBChamber, ByVal FilePath As String) As DBChamber
        AVPLib.Log.coreLogger.Info("Enter SaveChamber")
        Try
            Dim ChamberDoc As System.Xml.XmlDocument = New System.Xml.XmlDocument()

            Dim RootNode As System.Xml.XmlNode = ChamberDoc.CreateElement("Recipe")
            ChamberDoc.AppendChild(RootNode)

            Dim VersionNode As System.Xml.XmlNode = ChamberDoc.CreateElement("Version")
            VersionNode.InnerText = "1.0"
            RootNode.AppendChild(VersionNode)

            Dim StepListNode As System.Xml.XmlNode = ChamberDoc.CreateElement("StepList")
            RootNode.AppendChild(StepListNode)

            Dim ListChamberSteps As ArrayList = Chamber.ListChamberSteps
            For Each ChamberStep As DBChamberStep In ListChamberSteps
                Dim StepNode As System.Xml.XmlNode = CreateChamberStep(ChamberDoc, ChamberStep)
                StepListNode.AppendChild(StepNode)
            Next

            Dim DescriptionNode As System.Xml.XmlNode = ChamberDoc.CreateElement("Description")
            DescriptionNode.InnerText = Chamber.ChamberDescription
            RootNode.AppendChild(DescriptionNode)

            Dim chamberModule As SystemModule = Nothing
            AVPLib.ContainerData.IsChamberVisible(Chamber.ChamberName, chamberModule)
            If (chamberModule.Type = SystemModule.ModuleType.IBE AndAlso chamberModule.IBE_Type <> IBEType.AVP_IBE) Then
                ExportToFile_stp(FilePath, Chamber)
            End If

            ChamberDoc.Save(FilePath)
            Dim strRecipe As String = Utils.GetFileName(FilePath, False)
            '''export to GEM folder
            If (Utils.Create_GEMDATA_Folder) Then
                If (Utils.IsIBEChamber_ANYIBE(AVPLib.Utils.chamberName2ChamberID(chamberModule.Name))) Then
                    ChamberDoc.Save(ContainerDAO.FPath_GEMData_Recipe & ConstEnum.Equipments.IBE.ToString & "." & strRecipe)
                Else
                    ChamberDoc.Save(ContainerDAO.FPath_GEMData_Recipe & UCase(chamberModule.Name) & "." & strRecipe)
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveChamber")
        Return Chamber
    End Function
    ''' <author>
    '''    	<name>Le Hieu Truc </name>
    '''    	<date> 2009-08-20</date>
    ''' </author>
    ''' <summary>
    ''' Export To File stp
    ''' </summary>
    ''' <param name="Chamber"></param>
    ''' <param name="FilePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Sub ExportToFile_stp(ByVal filepath As String, ByVal chamber As DBChamber)
        AVPLib.Log.coreLogger.Info("Enter ExportToFile_stp")
        Try
            ''delete the old file
            Dim i As Integer = 0
            Const strStpExt As String = ".stp"
            Const strPrcExt As String = ".prc"
            Dim ProjNamewithPath As String = filepath.Replace(".xml", strPrcExt) '''save project file
            Dim fiProj As New System.IO.FileInfo(ProjNamewithPath)
            If fiProj.Exists Then
                fiProj.Delete()
            End If

            Dim strProjName As String = Utils.GetFileName(ProjNamewithPath, True) ''extract project file name

            Dim stepName As String = ProjNamewithPath.Replace(strPrcExt, "_step") ''save step file
            ''start writing to new project file
            Dim SwFromProjTrueUTF8 As New System.IO.StreamWriter(ProjNamewithPath, True, System.Text.Encoding.ASCII)
            SwFromProjTrueUTF8.WriteLine("[ProcessParameters]")
            SwFromProjTrueUTF8.WriteLine("Abort_At_Fault=N")
            SwFromProjTrueUTF8.WriteLine("Use_Pretilt=N")
            SwFromProjTrueUTF8.WriteLine("Pretilt_Angle=90")
            SwFromProjTrueUTF8.WriteLine("Use_Recipe_Process_Start_Pressure=N")
            SwFromProjTrueUTF8.WriteLine("Process_Start_Pressure=0.000005")
            SwFromProjTrueUTF8.WriteLine("[ProcessSteps]")

            Dim ListChamberSteps As ArrayList = chamber.ListChamberSteps
            ''check condition
            If ListChamberSteps.Count > 200 Or ListChamberSteps.Count <= 0 Then
                AVPLib.Log.coreLogger.Error("Recipe Step is out of control")
                AVPLib.Log.coreLogger.Info("Leave ExportToFile_stp")
                Exit Sub
            End If
            '''''''''''''''
            For Each ChamberStep As DBChamberStep In ListChamberSteps
                ''create new step file name with extention
                i += 1
                SwFromProjTrueUTF8.WriteLine("Step_" & i.ToString() & "=" & strProjName & "_step" & i.ToString())
                ''create step file
                Dim stepfi As New System.IO.FileInfo(stepName & i.ToString() & strStpExt)
                If stepfi.Exists Then
                    stepfi.Delete()
                End If
                '''save step file with path
                Dim swFromFileTrueUTF8 As New System.IO.StreamWriter(stepName & i.ToString() & strStpExt, True, System.Text.Encoding.ASCII)
                'writing step file
                Dim listParam As ArrayList = ChamberStep.ListGroupParameterValues
                For Each DBParam As AVPLib.DBGroupParameterValue In listParam
                    Dim listGroupParam As ArrayList = DBParam.ListParameterValues
                    swFromFileTrueUTF8.WriteLine("[" & DBParam.GroupCode.ToString() & "]")
                    For Each ParamValue As DBParameterValue In listGroupParam
                        If LCase(ParamValue.Value) = "true" Then
                            swFromFileTrueUTF8.WriteLine(ParamValue.Name & "=Y")
                        ElseIf LCase(ParamValue.Value) = "false" Then
                            swFromFileTrueUTF8.WriteLine(ParamValue.Name & "=N")
                        Else
                            swFromFileTrueUTF8.WriteLine(ParamValue.Name & "=" & ParamValue.Value)
                        End If
                    Next
                Next
                'close step file 
                swFromFileTrueUTF8.Flush()
                swFromFileTrueUTF8.Close()
            Next
            ''close project file
            SwFromProjTrueUTF8.Flush()
            SwFromProjTrueUTF8.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            'Utils.ThrowAlarm(chamber.ChamberName + ":Can not write to files with path: " & filepath)
            Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentCanNotWriteFileToPath"),
                         chamber.ChamberName, filepath), AVPLib.ConstEnum.GEM_ALARM_SYSTEM)
        End Try
        AVPLib.Log.coreLogger.Info("Leave ExportToFile_stp")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' CreateChamberStep
    ''' </summary>
    ''' <param name="ChamberDoc"></param>
    ''' <param name="ChamberStep"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function CreateChamberStep(ByVal ChamberDoc As System.Xml.XmlDocument, ByVal ChamberStep As DBChamberStep) As System.Xml.XmlNode
        AVPLib.Log.coreLogger.Info("Enter CreateChamberStep")
        Try
            Dim StepNode As System.Xml.XmlNode = ChamberDoc.CreateElement("Step")
            Dim SeqNoNode As System.Xml.XmlNode = ChamberDoc.CreateElement("SeqNo")
            SeqNoNode.InnerText = ChamberStep.SeqNo
            StepNode.AppendChild(SeqNoNode)
            For Each GroupParameterValue As DBGroupParameterValue In ChamberStep.ListGroupParameterValues
                If Not GroupParameterValue.GroupCode.Contains("Version_Control") Then
                    Dim GroupNode As System.Xml.XmlNode = CreateGroupParameterValue(ChamberDoc, GroupParameterValue)
                    StepNode.AppendChild(GroupNode)
                End If
            Next
            AVPLib.Log.coreLogger.Info("Leave CreateChamberStep")
            Return StepNode
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave CreateChamberStep")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' CreateGroupParameterValue
    ''' </summary>
    ''' <param name="ChamberDoc"></param>
    ''' <param name="GroupParameterValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function CreateGroupParameterValue(ByVal ChamberDoc As System.Xml.XmlDocument, ByVal GroupParameterValue As DBGroupParameterValue) As System.Xml.XmlNode
        AVPLib.Log.coreLogger.Info("Enter CreateGroupParameterValue")
        Try
            Dim GroupCode As String = GroupParameterValue.GroupCode
            If GroupCode Is Nothing Or GroupCode.Length = 0 Then
                GroupCode = "NoGroup"
            End If

            Dim GroupNode As System.Xml.XmlNode = ChamberDoc.CreateElement(GroupCode)
            For Each ParameterValue As DBParameterValue In GroupParameterValue.ListParameterValues
                Dim ParameterNode As System.Xml.XmlNode = ChamberDoc.CreateElement(ParameterValue.Name)
                ParameterNode.InnerText = ParameterValue.Value
                GroupNode.AppendChild(ParameterNode)
            Next
            AVPLib.Log.coreLogger.Info("Leave CreateGroupParameterValue")
            Return GroupNode
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave CreateGroupParameterValue")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Update Chamber
    ''' </summary>
    ''' <param name="ChamberDoc"></param>
    ''' <param name="Chamber"></param>
    ''' <param name="ChamberName"></param>
    ''' <param name="RecipePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UpdateChamber(ByVal ChamberDoc As System.Xml.XmlDocument, ByVal Chamber As String, ByVal ChamberName As String, ByVal RecipePath As String) As System.Xml.XmlDocument
        AVPLib.Log.coreLogger.Info("Enter UpdateChamber")
        Try
            Dim root As System.Xml.XmlNode = ChamberDoc.SelectSingleNode(XPATH_RECIPE)
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                If Chamber = node.Name Then
                    node.InnerText = ChamberName
                End If
            Next

            'ChamberDoc.Save(RecipePath)
            BinarySerialize.SaveTo_DatFileConfig(RecipePath, ChamberDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave UpdateChamber")
        Return ChamberDoc
    End Function
#End Region

#Region "Recipe Priviledge"

#End Region
End Class
