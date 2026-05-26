Public Class SequenceLib
#Region "Functions"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' SaveWFSequence: Save WaferFlowSequence to FilePath
    ''' </summary>
    ''' <param name="DBListSequenceSlot"></param>
    ''' <param name="FilePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveWFSequence(ByVal currentDBSeq As AVPLib.DBWaferList, ByVal FilePath As String, ByVal Description As String) As Boolean
        AVPLib.Log.dataManagementLogger.Info("Enter SaveSequence")
        Dim blnSuccess As Boolean = False
        Try
            Dim SequenceDoc As System.Xml.XmlDocument = New System.Xml.XmlDocument()

            Dim RootNode As System.Xml.XmlNode = SequenceDoc.CreateElement("ControlJob")
            SequenceDoc.AppendChild(RootNode)
            Dim WaferListNode As System.Xml.XmlNode = SequenceDoc.CreateElement("WaferList")
            RootNode.AppendChild(WaferListNode)
            If currentDBSeq.WaferList.Count = 0 Then
                GoTo EndFunc
            End If
            For Each item As AVPLib.DBWaferSlot In currentDBSeq.WaferList
                Dim WaferNode As System.Xml.XmlNode = CreateWaferNode(SequenceDoc, item)
                If Not WaferNode Is Nothing Then
                    WaferListNode.AppendChild(WaferNode)
                Else
                    GoTo EndFunc
                    Exit For
                End If
            Next
            Dim DescriptionNode As System.Xml.XmlNode = SequenceDoc.CreateElement("Description")
            DescriptionNode.InnerText = Description
            RootNode.AppendChild(DescriptionNode)

            SequenceDoc.Save(FilePath)
            ''Save to GEM DATA Folder
            If (Utils.Create_GEMDATA_Folder) Then
                SequenceDoc.Save(ContainerDAO.FPath_GEMData_Sequence & Utils.GetFileName(FilePath, False))
            End If
            AVPLib.Log.coreLogger.Info("Leave SaveSequence")
            blnSuccess = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
EndFunc:
        AVPLib.Log.dataManagementLogger.Info("Leave SaveSequence")
        Return blnSuccess
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' Create WaferNode in SequenceDoc -> receive current Wafer Slot to generate a <Wafer> Node in JobFile
    ''' a node like: <Wafer><ScrSlot>...<ScrSlot>...
    ''' </summary>
    ''' <param name="SequenceDoc"></param>
    ''' <param name="SequenceSlot"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function CreateWaferNode(ByVal SequenceDoc As System.Xml.XmlDocument, ByVal curWaferSlot As AVPLib.DBWaferSlot) As System.Xml.XmlNode
        AVPLib.Log.dataManagementLogger.Info("Enter CreateWaferNode")
        Try
            Dim wfFlow As AVPLib.DataManagerment.WaferFlow = Nothing
            Dim intSeqNo As Integer = 1
            Dim WaferNode As System.Xml.XmlNode = SequenceDoc.CreateElement("Wafer")
            Dim SrcSlotNode As System.Xml.XmlNode = SequenceDoc.CreateElement("SrcSlot")
            SrcSlotNode.InnerText = curWaferSlot.Slot
            WaferNode.AppendChild(SrcSlotNode)
            Dim waferFlowNode As System.Xml.XmlNode = SequenceDoc.CreateElement("WaferFlow")
            waferFlowNode.InnerText = curWaferSlot.WaferSequence.SeqName
            WaferNode.AppendChild(waferFlowNode)
            ' This code is deprecated.--------------------------------------------------------------
            ''we save the master row here
            'Dim WaferSeqNode As System.Xml.XmlNode = SequenceDoc.CreateElement("WaferSeq")
            'WaferNode.AppendChild(WaferSeqNode)
            'Dim NameNode As System.Xml.XmlNode = SequenceDoc.CreateElement("Name")
            'NameNode.InnerText = curWaferSlot.WaferSequence.SeqName
            'WaferSeqNode.AppendChild(NameNode)

            'Dim SeqStepListNode As System.Xml.XmlNode = SequenceDoc.CreateElement("SeqStepList")
            'WaferSeqNode.AppendChild(SeqStepListNode)
            'wfFlow = AVPLib.ContainerData.GetWaferFlowbyName(curWaferSlot.WaferSequence.SeqName)
            'If wfFlow Is Nothing Then
            '    GoTo EndFunc
            'End If
            ''''we save the child row here
            'For Each item As AVPLib.DataManagerment.WaferflowStep In wfFlow.StepList
            '    Dim SeqStepNode As System.Xml.XmlNode = SequenceDoc.CreateElement("SeqStep")
            '    SeqStepListNode.AppendChild(SeqStepNode)

            '    Dim SeqNumberNode As System.Xml.XmlNode = SequenceDoc.CreateElement("SeqNumber")
            '    SeqNumberNode.InnerText = intSeqNo.ToString()
            '    intSeqNo += 1
            '    SeqStepNode.AppendChild(SeqNumberNode)

            '    Dim RecipeNode As System.Xml.XmlNode = SequenceDoc.CreateElement("RecipeName")
            '    RecipeNode.InnerText = item.RecipeName
            '    SeqStepNode.AppendChild(RecipeNode)
            '    ''<StationList>
            '    Dim StationListNode As System.Xml.XmlNode = SequenceDoc.CreateElement("StationList")
            '    Dim stationNode As Xml.XmlNode = SequenceDoc.CreateElement("Station")
            '    stationNode.InnerText = item.StationList.Item(0).ToString()
            '    StationListNode.AppendChild(stationNode)

            '    SeqStepNode.AppendChild(StationListNode)
            'Next
            ''' <StepList>
            '''we get the master row
            'Dim StepListNode As System.Xml.XmlNode = SequenceDoc.CreateElement("StepList")
            '''''''''''''''''''''''''''''''''''''we get WaferFlowLoop from WaferFlowName
            'If Not (intSeqNo = 1) Then
            '    intSeqNo -= 1
            'End If
            'StepListNode.InnerText = GenStep(ParseLoopToStep(wfFlow, intSeqNo))
            'WaferSeqNode.AppendChild(StepListNode)
            '----------------------------------------------------------------------------------------
            AVPLib.Log.coreLogger.Info("Leave CreateWaferNode")
            Return WaferNode
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
endfunc:
        AVPLib.Log.dataManagementLogger.Info("Leave CreateWaferNode")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-07-28</date>
    ''' </author>
    ''' <summary>
    ''' ParseLoopToStep: parse loopinfo to list of step
    ''' </summary>
    '''input: waferflow, intSumOfStep: total of Step 
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseLoopToStep(ByVal wfflow As DataManagerment.WaferFlow, ByVal intSumOfStep As Integer) As List(Of String)
        AVPLib.Log.dataManagementLogger.Info("Enter ParseLoopToStep")
        Dim StepList As List(Of String) = Nothing
        Try
            StepList = InitStep(intSumOfStep) ''1,2,3,4,5
            If wfflow.LoopList.Count > 0 Then ''if we have loop in waferflow
                ''create new step
                For i As Integer = 0 To intSumOfStep - 1
                    Dim wfLoop As New DataManagerment.WaferflowLoop
                    If IsStartLoop(wfflow, i, wfLoop) Then
                        StepList = CloneStep(i + 1, StepList, wfLoop)
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return StepList
        AVPLib.Log.dataManagementLogger.Info("Leave ParseLoopToStep")
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-07-28</date>
    ''' </author>
    ''' <summary>
    ''' Generate Step in Steplist to String. Ex: (1,2,3,4,5) -->1,2,3,4,5
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function GenStep(ByVal Steplist As List(Of String)) As String
        AVPLib.Log.dataManagementLogger.Info("Enter GenStep")
        Dim result As String = String.Empty
        For Each item As String In Steplist
            result = result & item & ","
        Next
        result = result.Remove(result.LastIndexOf(","), 1)
        Return result
        AVPLib.Log.dataManagementLogger.Info("Leave GenStep")
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-07-28</date>
    ''' </author>
    ''' <summary>
    ''' Generate StepList from Sum of Sequence
    ''' Input: 4--->result: 1,2,3,4
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function InitStep(ByVal intSeqNo As Integer) As List(Of String)
        AVPLib.Log.dataManagementLogger.Info("Enter InitStep")
        Dim result As New List(Of String)
        For i As Integer = 1 To intSeqNo
            result.Add(i.ToString())
        Next
        AVPLib.Log.dataManagementLogger.Info("Leave InitStep")
        Return result
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' IsStartLoop: check index is start of Wafer Loop in WaferFlow
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function IsStartLoop(ByVal wfFlow As DataManagerment.WaferFlow, ByVal index As Integer, ByRef wfLoop As DataManagerment.WaferflowLoop) As Boolean
        AVPLib.Log.dataManagementLogger.Info("Enter IsStartLoop")
        Dim blnResult As Boolean = False
        For Each item As AVPLib.DataManagerment.WaferflowLoop In wfFlow.LoopList
            If index = CInt(item.LoopStart) Then
                blnResult = True
                wfLoop = item
                Exit For
            End If
        Next
        AVPLib.Log.dataManagementLogger.Info("Leave IsStartLoop")
        Return blnResult
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-28</date>
    ''' </author>
    ''' <summary>
    ''' Clone Step: LoopInfo(Start=1,End=2,Count=3)-->1,2,1,2,1,2,3,4
    ''' </summary>
    '''input:
    ''' indexStart: Start of Loop; Steplist: 1,2,3,4 ; WaferLoop: Loop contains indexStart
    '''b/c: index of Loop + 1 = index of Step --->indexStart=LoopStart or LoopEnd + 1
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function CloneStep(ByVal indexStart As Integer, ByVal steplist As List(Of String), ByVal wfloop As DataManagerment.WaferflowLoop) As List(Of String)
        AVPLib.Log.dataManagementLogger.Info("Enter CloneStep")
        Dim ListOfResult As List(Of String) = Nothing ''3,4,5,3,4,5
        Dim ListOfRemove As List(Of String) = Nothing ''3,4,5
        Try
            ''''in Waferflow, we start from 0, in jobfile: we start from 1-->so LoopStart + 1
            If indexStart = CInt(wfloop.LoopStart) + 1 Then '''start=3, end =5, loop =2---> strResult=3,4,5,3,4,5
                Dim j As Integer = 1
                '''copy range of step to clone
                ListOfResult = New List(Of String)(steplist.GetRange(steplist.IndexOf(indexStart), steplist.IndexOf(wfloop.LoopEnd + 1) - steplist.IndexOf(wfloop.LoopStart + 1) + 1)) ''get string 3,4,5
                ListOfRemove = New List(Of String)(ListOfResult)
                While j < wfloop.LoopCount - 1 ''clone the list with the loopcount
                    ListOfResult.AddRange(ListOfRemove)
                    j += 1
                End While
                ''''in Waferflow, we start from 0, in jobfile: we start from 1-->so LoopEnd + 1
                steplist.InsertRange(steplist.IndexOf(wfloop.LoopEnd + 1) + 1, ListOfResult) ''append the list after clone to the end of loop
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            ListOfResult = Nothing
            ListOfRemove = Nothing
        End Try
        AVPLib.Log.dataManagementLogger.Info("Leave CloneStep")
        Return steplist
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Update Sequence
    ''' </summary>
    ''' <param name="SequenceDoc"></param>
    ''' <param name="FileName"></param>
    ''' <param name="SequencePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UpdateWFSequence(ByVal FullFileName As String, ByVal currentDBSeq As AVPLib.DBWaferList, Optional ByVal Description As String = "") As Boolean
        AVPLib.Log.dataManagementLogger.Info("Enter UpdateSequence")
        Dim blnSuccess As Boolean = False
        Try
            If DeleteWFSequence(FullFileName) Then
                blnSuccess = SaveWFSequence(currentDBSeq, FullFileName, Description)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.dataManagementLogger.Info("Leave UpdateSequence")
        Return blnSuccess
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' Delete Sequence File
    ''' </summary>
    ''' <param name="FullFileName">file like : abc.xml</param>
    ''' <returns>true or false </returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteWFSequence(ByVal FullFileName As String) As Boolean
        AVPLib.Log.dataManagementLogger.Info("Enter DeleteSequence")
        Dim blnSuccess As Boolean = False
        Try
            Utils.DeleteFile(ContainerDAO.FPath_SequenceData & "\" & FullFileName)
            ''Update GEM DATA Folder
            Utils.DeleteFile(ContainerDAO.FPath_GEMData_Sequence & FullFileName)
            blnSuccess = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.dataManagementLogger.Info("Leave DeleteSequence")
        Return blnSuccess
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Update Sequence
    ''' </summary>
    ''' <param name="SequenceDoc"></param>
    ''' <param name="FileName"></param>
    ''' <param name="SequencePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UpdateSequence(ByVal SequenceDoc As System.Xml.XmlDocument, ByVal FileName As String, ByVal SequencePath As String) As System.Xml.XmlDocument
        AVPLib.Log.dataManagementLogger.Info("Enter UpdateSequence")
        Try
            Dim root As System.Xml.XmlNode = SequenceDoc.SelectSingleNode(ConstEnum.XPATH_SEQUENCE)
            root.ChildNodes.Item(2).InnerText = FileName

            'SequenceDoc.Save(SequencePath)
            BinarySerialize.SaveTo_DatFileConfig(SequencePath, SequenceDoc)
            'Update GEM DATA
            SequenceDoc.Save(ContainerDAO.FPath_GEMData_Sequence & FileName)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.dataManagementLogger.Info("Leave UpdateSequence")
        Return SequenceDoc
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Delete Sequence
    ''' </summary>
    ''' <param name="SequenceDoc"></param>
    ''' <param name="FilePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteSequence(ByVal SequenceDoc As System.Xml.XmlDocument, ByVal FilePath As String) As System.Xml.XmlDocument
        AVPLib.Log.dataManagementLogger.Info("Enter DeleteSequence")
        Try
            Dim root As System.Xml.XmlNode = SequenceDoc.SelectSingleNode(ConstEnum.XPATH_SEQUENCE)
            SequenceDoc.RemoveChild(root)
            SequenceDoc.Save(FilePath)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.dataManagementLogger.Info("Leave DeleteSequence")
        Return SequenceDoc
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' Get List Sequence Name
    ''' </summary>
    ''' <param name="PathFolderSequence"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetListSequenceName(ByVal PathFolderSequence As String) As ArrayList
        AVPLib.Log.dataManagementLogger.Info("Enter GetListSequenceName")
        Try
            Dim ListSequenceName As New ArrayList()
            Dim Files As String() = System.IO.Directory.GetFiles(PathFolderSequence, "*.xml")
            For Each File As String In Files
                If Utils.CanToAddFile(File) Then
                    ListSequenceName.Add(Utils.GetFileName(File, True))
                End If
            Next
            AVPLib.Log.coreLogger.Info("Leave GetListSequenceName")
            Return ListSequenceName
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.dataManagementLogger.Info("Leave GetListSequenceName")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' GetChamberStations: return a list of chamberstation from sequenceName
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChamberStations(ByVal sequenceName As String, Optional ByVal CheckSequenceOnly As Boolean = False) As List(Of String)
        AVPLib.Log.dataManagementLogger.Info("Enter GetChamberStations")
        Dim ChamberStations As List(Of String) = Nothing
        Try
            Dim sequenFileName As String = AVPLib.Utils.GetFileName(sequenceName, "xml")
            Dim filepath As String = ContainerDAO.FPath_SequenceData + "\" + sequenFileName

            If System.IO.File.Exists(filepath) = False Then
                Return Nothing
            End If
            ChamberStations = New List(Of String)()

            Dim wfSequence As AVPLib.DBWaferList = Nothing
            Dim strDescription As String = Nothing
            ' If can not open the flow
            If Not AVPLib.ContainerData.GetSequence(filepath, wfSequence, strDescription) Then
                Return Nothing
            End If

            For Each waferSlot As DBWaferSlot In wfSequence.WaferList
                For Each seqStep As DBSeqStep In waferSlot.WaferSequence.SeqStepList
                    If (seqStep.StationList.Count > 0) Then
                        Dim station As String = seqStep.StationList(0)
                        If Not ChamberStations.Contains(station) Then
                            ChamberStations.Add(station)
                            If CheckSequenceOnly Then
                                Return ChamberStations
                            End If
                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.dataManagementLogger.Info("Leave GetChamberStations")
        Return ChamberStations
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-03-18</date>
    ''' </author>
    ''' <summary>
    ''' Check Sequence 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function IsValidStationName(ByVal Name As String) As Boolean
        Dim blResult As Boolean = False
        Try
            If (Name = ConstEnum.Equipments.LoadLockA.ToString OrElse _
            (Name = ConstEnum.Equipments.Chamber1.ToString AndAlso RobotConfigurationValues.CHAMBER1_VISIBLE) OrElse _
            (Name = ConstEnum.Equipments.Chamber2.ToString AndAlso RobotConfigurationValues.CHAMBER2_VISIBLE) OrElse _
            (Name = ConstEnum.Equipments.Chamber3.ToString AndAlso RobotConfigurationValues.CHAMBER3_VISIBLE) OrElse _
            (Name = ConstEnum.Equipments.Aligner.ToString AndAlso RobotConfigurationValues.ALINER_VISIBLE)) Then
                blResult = True
            Else
                If (AVPLib.ContainerDAO.Enable_ANYIBE_Mode AndAlso Name = RobotConfigurationValues.ANY_IBE_CHAMBER) Then
                    blResult = True
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blResult
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-03-18</date>
    ''' </author>
    ''' <summary>
    ''' Check Sequence 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckInvalidSequence(ByVal sequenceName As String, ByVal LLName As String, _
            Optional ByRef eRemoteResult As AVPLib.ConstEnum.CustomRemoteCommandResult = Nothing) As Boolean
        AVPLib.Log.dataManagementLogger.Info("Enter GetSequence")
        Try
            Dim sequenFileName As String = AVPLib.Utils.GetFileName(sequenceName, "xml")
            Dim filepath As String = ContainerDAO.FPath_SequenceData + "\" + sequenFileName
            'file not exist
            If System.IO.File.Exists(filepath) = False Then
                eRemoteResult = ConstEnum.CustomRemoteCommandResult.SEQUENCE_IS_NOT_EXISTED
                Return False
            End If

            Dim wfSequence As AVPLib.DBWaferList = Nothing
            Dim strDescription As String = Nothing
            ' If can not open the flow
            If Not AVPLib.ContainerData.GetSequence(filepath, wfSequence, strDescription) Then
                eRemoteResult = ConstEnum.CustomRemoteCommandResult.WF_IS_NOT_EXISTED
                Return False
            End If

            For Each waferSlot As DBWaferSlot In wfSequence.WaferList
                For Each seqStep As DBSeqStep In waferSlot.WaferSequence.SeqStepList
                    If (System.IO.File.Exists(seqStep.RecipePath) = False OrElse IsValidStationName(seqStep.StationName) = False) Then
                        eRemoteResult = ConstEnum.CustomRemoteCommandResult.RECIPE_IS_NOT_EXISTED
                        Return False
                    End If
                Next
            Next

            'when sequence is valid then copy sequence,waferflow,recipe to RunningData folder
            If (Not IO.Directory.Exists(ContainerDAO.FPath_TempData)) Then
                IO.Directory.CreateDirectory(ContainerDAO.FPath_TempData)
            End If

            If (Not IO.Directory.Exists(ContainerDAO.FPath_TempData & "\" & LLName)) Then
                IO.Directory.CreateDirectory(ContainerDAO.FPath_TempData & "\" & LLName)
            End If
            'copy sequence to tem sequence

            'Dim tempJobFile As String = ContainerDAO.FPath_TempData & "\" & LLName & "\JobFiles"
            'If (Not IO.Directory.Exists(tempJobFile)) Then
            '    IO.Directory.CreateDirectory(tempJobFile)
            'End If

            'Dim tempWaferFile As String = ContainerDAO.FPath_TempData & "\" & LLName & "\WaferFlows"
            'If (Not IO.Directory.Exists(tempWaferFile)) Then
            '    IO.Directory.CreateDirectory(tempWaferFile)
            'End If

            Dim tempRecipeFile As String = ContainerDAO.FPath_TempData & "\" & LLName & "\Recipes"
            If (Not IO.Directory.Exists(tempRecipeFile)) Then
                IO.Directory.CreateDirectory(tempRecipeFile)
            End If

            'IO.File.Copy(filepath, tempJobFile & "\" & sequenFileName, True)
            For Each waferSlot As DBWaferSlot In wfSequence.WaferList
                'IO.File.Copy(ContainerDAO.FPath_WaferFlow & "\" & waferSlot.WaferSequence.SeqName & ".xml", _
                'tempWaferFile & "\" & waferSlot.WaferSequence.SeqName & ".xml", True)
                For Each seqStep As DBSeqStep In waferSlot.WaferSequence.SeqStepList
                    If (Not IO.Directory.Exists(tempRecipeFile & "\" & seqStep.StationName)) Then
                        IO.Directory.CreateDirectory(tempRecipeFile & "\" & seqStep.StationName)
                    End If

                    If (Not seqStep.StationName = AVPLib.ConstEnum.Equipments.Aligner.ToString()) Then
                        Dim stationName As String = String.Empty
                        Dim recipeName As String = String.Empty

                        stationName = seqStep.StationName
                        recipeName = seqStep.RecipeName
                        If (Utils.IsIBEChamber_ANYIBE(stationName)) Then
                            stationName = RobotConfigurationValues.ANY_IBE_CHAMBER
                            If (Not IO.Directory.Exists(tempRecipeFile & "\" & RobotConfigurationValues.ANY_IBE_CHAMBER)) Then
                                IO.Directory.CreateDirectory(tempRecipeFile & "\" & RobotConfigurationValues.ANY_IBE_CHAMBER)
                            End If
                        End If

                        Dim source_XML As String = ContainerDAO.FPath_ChamberRecipe & "\" & stationName & "\" & recipeName & ".xml"
                        Dim des_XML As String = tempRecipeFile & "\" & stationName & "\" & recipeName & ".xml"

                        Dim source_PRC As String = ContainerDAO.FPath_ChamberRecipe & "\" & stationName & "\" & recipeName & ".prc"
                        Dim des_PRC As String = tempRecipeFile & "\" & stationName & "\" & recipeName & ".prc"



                        If (IO.File.Exists(source_XML)) Then
                            IO.File.Copy(source_XML, des_XML, True)
                        End If

                        If (IO.File.Exists(source_PRC)) Then
                            IO.File.Copy(source_PRC, des_PRC, True)
                        End If

                        'COPY ALL STEP TO TEMP FOLDER
                        Dim des_STEP As String = tempRecipeFile & "\" & stationName & "\"
                        Dim myfolder As IO.DirectoryInfo = New IO.DirectoryInfo(ContainerDAO.FPath_ChamberRecipe & "\" & stationName)
                        Dim strFiles As IO.FileInfo() = myfolder.GetFiles()
                        For Each myItem As IO.FileInfo In strFiles
                            If (myItem.Name.Contains(recipeName & "_step")) Then
                                IO.File.Copy(myItem.FullName, des_STEP & myItem.Name, True)
                            End If
                        Next
                    End If
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.dataManagementLogger.Info("Leave GetChamberStations")
        Return True
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-11</date>
    ''' </author>
    ''' <summary>
    ''' copy recipe from source to dest
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CopyRecipeToRunningFolder(ByVal LoadLockName As String, ByVal SourceStation As String, _
    ByVal DestStation As String, _
    ByVal RecipeName As String) As Boolean
        Dim blResult As Boolean = False
        AVPLib.Log.dataManagementLogger.Info("Leave GetChamberStations")
        Try
            Dim tempRecipeFile As String = ContainerDAO.FPath_TempData & "\" & LoadLockName & "\Recipes"

            Dim source_XML As String = ContainerDAO.FPath_ChamberRecipe & "\" & SourceStation & "\" & RecipeName & ".xml"
            Dim des_XML As String = tempRecipeFile & "\" & DestStation & "\" & RecipeName & ".xml"

            Dim source_PRC As String = ContainerDAO.FPath_ChamberRecipe & "\" & SourceStation & "\" & RecipeName & ".prc"
            Dim des_PRC As String = tempRecipeFile & "\" & DestStation & "\" & RecipeName & ".prc"


            'when sequence is valid then copy sequence,waferflow,recipe to RunningData folder
            If (Not IO.Directory.Exists(ContainerDAO.FPath_TempData)) Then
                IO.Directory.CreateDirectory(ContainerDAO.FPath_TempData)
            End If

            If (Not IO.Directory.Exists(ContainerDAO.FPath_TempData & "\" & LoadLockName)) Then
                IO.Directory.CreateDirectory(ContainerDAO.FPath_TempData & "\" & LoadLockName)
            End If

            If (Not IO.Directory.Exists(tempRecipeFile & "\" & DestStation)) Then
                IO.Directory.CreateDirectory(tempRecipeFile & "\" & DestStation)
            End If

            If (IO.File.Exists(source_XML)) Then
                IO.File.Copy(source_XML, des_XML, True)
            Else
                blResult = False
                GoTo ExitFunc
            End If

            If (IO.File.Exists(source_PRC)) Then
                IO.File.Copy(source_PRC, des_PRC, True)
            Else
                blResult = False
                GoTo ExitFunc
            End If

            'COPY ALL STEP TO TEMP FOLDER
            Dim des_STEP As String = tempRecipeFile & "\" & DestStation & "\"
            Dim myfolder As IO.DirectoryInfo = New IO.DirectoryInfo(ContainerDAO.FPath_ChamberRecipe & "\" & SourceStation)
            Dim strFiles As IO.FileInfo() = myfolder.GetFiles()
            For Each myItem As IO.FileInfo In strFiles
                If (myItem.Name.Contains(RecipeName & "_step")) Then
                    IO.File.Copy(myItem.FullName, des_STEP & myItem.Name, True)
                End If
            Next

            'pass anything 
            blResult = True
        Catch ex As Exception
            AVPLib.Log.dataManagementLogger.Info(ex.Message)
        End Try
ExitFunc:
        AVPLib.Log.dataManagementLogger.Info("Leave CopyRecipeToRunningFolder")
        Return blResult
    End Function

#End Region
End Class
