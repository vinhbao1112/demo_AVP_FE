Namespace Business

    Public Interface IRecipeProcessing
        Function StartRecipe(ByVal pathFrom As String, ByVal pathTo As String, ByVal bSetRecipeNameAndStartCmd As Boolean) As Boolean
        Function StartWarmUp() As Boolean
        Function StopRecipe() As Boolean
        Function SetRecipeName(ByVal val As String) As Boolean
        Function SetDataRunFileName(ByVal val As String) As Boolean
        Function StartProcessing() As Boolean
        Function StartProcessingCycleATM(ByVal val As String) As Boolean
        Function PauseRecipe() As Boolean
        Function ResumeRecipe() As Boolean
        Function SetIsoValveStatus(ByVal strOnOff As String) As Boolean
        Function DoSetWaferStatus(ByVal strStatus As String) As Boolean
        Sub Process_Reset_Error()
        Sub CopyRecipeToPMFolder()
        Sub DoCheckRecipeTemplateVersion()
        Sub CopyRecipeTemplate()
        Sub SendResultOfCopyRecipeTemplate(ByVal blnResult As Boolean)
        Function SendToPM_CurrentAVPTime() As Boolean
        Sub SendRequestAllData()
        Function GetAllTargetBaseOnRecipe(ByVal strRecipeName As String, ByVal strStationName As String) As List(Of String)
        Function CheckingKWHOverAlarmLimit(ByVal sTargetUsed As List(Of String)) As String
        Function CheckingKWHOverWarningLimit(ByVal sTargetUsed As List(Of String)) As String
        Function CheckingShieldsQuartzOverAlarmLimit(ByVal sTargetUsed As List(Of String)) As String
        Function CheckingShieldsQuartzOverWarningLimit(ByVal sTargetUsed As List(Of String)) As String
        Function SendProcessLotID() As Boolean
        Function SendProcessWaferID() As Boolean
    End Interface

    Public Class ChamberController
        Inherits ControllerObject
        Implements IRecipeProcessing
        Private m_CopyRecipe_Worker As ComponentModel.BackgroundWorker = Nothing
#Region "Public method"
        Enum ControllerType
            IBEController
            PVDController
            CORONAController
            PVD5TController
        End Enum

        Protected m_ObjController As ControllerObject = Nothing

        Public ReadOnly Property Myself() As ControllerObject
            Get
                Return m_ObjController
            End Get
        End Property

        Public Sub New(ByVal strControllerName As String, ByVal EQName As String)
            MyBase.New()
            If (strControllerName = ControllerType.PVDController.ToString()) Then
                m_ObjController = New PVDController(EQName)
            ElseIf (strControllerName = ControllerType.IBEController.ToString()) Then
                m_ObjController = New IBEController(EQName)
            ElseIf (strControllerName = ControllerType.CORONAController.ToString()) Then
                m_ObjController = New CoronaController(EQName)
            ElseIf (strControllerName = ControllerType.PVD5TController.ToString()) Then
                m_ObjController = New PVD5TController(EQName)
            End If
            Me.EquipmentName = EQName
        End Sub

        Public ReadOnly Property CurrentRoutineExecutor() As ChamberRoutineExecutor
            Get
                If (m_ObjController.GetType().Name = ControllerType.PVDController.ToString()) Then
                    Return CType(m_ObjController, PVDController).CurrentRoutineExecutor
                ElseIf (m_ObjController.GetType().Name = ControllerType.IBEController.ToString()) Then
                    Return CType(m_ObjController, IBEController).CurrentRoutineExecutor
                ElseIf (UCase(m_ObjController.GetType().Name) = UCase(ControllerType.CORONAController.ToString())) Then
                    Return CType(m_ObjController, CoronaController).CurrentRoutineExecutor
                ElseIf (UCase(m_ObjController.GetType().Name) = UCase(ControllerType.PVD5TController.ToString())) Then
                    Return CType(m_ObjController, PVD5TController).CurrentRoutineExecutor
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Overrides Property PDC_ROR_SampleTime() As Integer
            Get
                Return Myself.PDC_ROR_SampleTime
            End Get
            Set(ByVal value As Integer)
                Myself.PDC_ROR_SampleTime = value
            End Set
        End Property

        Public Overrides Property PDC_ROR_WaitTime() As Integer
            Get
                Return Myself.PDC_ROR_WaitTime
            End Get
            Set(ByVal value As Integer)
                Myself.PDC_ROR_WaitTime = value
            End Set
        End Property

        Public Overrides Property PDC_ROR_Description() As String
            Get
                Return Myself.PDC_ROR_Description
            End Get
            Set(ByVal value As String)
                Myself.PDC_ROR_Description = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Do task ControllerManager
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Overrides Sub DoTask(ByVal Message As String)
            AVPLib.Log.coreLogger.Info("Enter DoTask")
            Dim strErrMsg As String = String.Empty
            Try

                If (m_ObjController IsNot Nothing) Then
                    m_ObjController.DoTask(Message)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub

        Public Overrides Property EquipmentName() As String
            Get
                Return MyBase.EquipmentName
            End Get
            Set(ByVal value As String)
                MyBase.EquipmentName = value
                If (m_ObjController IsNot Nothing) Then
                    m_ObjController.EquipmentName = value
                End If
            End Set
        End Property

        Function CopyProcessFile(ByVal pathFrom As String, ByVal pathTo As String) As Boolean
            AVPLib.Log.coreLogger.Info("Leave CopyProcessFile")
            Return CType(m_ObjController, IRecipeProcessing).StartRecipe(pathFrom, pathTo, False)
            AVPLib.Log.coreLogger.Info("Leave CopyProcessFile")
        End Function

        Public Function SetProcessName(ByVal pathFrom As String) As Boolean
            AVPLib.Log.coreLogger.Info("Leave CopyProcessFile")
            Return CType(m_ObjController, IRecipeProcessing).SetRecipeName(pathFrom)
            AVPLib.Log.coreLogger.Info("Leave CopyProcessFile")
        End Function

        Public Function StartProcess() As Boolean
            AVPLib.Log.coreLogger.Info("Enter StartProcess")
            Return CType(m_ObjController, IRecipeProcessing).StartProcessing()
            AVPLib.Log.coreLogger.Info("Leave StartProcess")
        End Function

        Public Function StartProcessCycleATM(ByVal val As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter StartProcessCycleATM")
            Return CType(m_ObjController, IRecipeProcessing).StartProcessingCycleATM(val)
            AVPLib.Log.coreLogger.Info("Leave StartProcessCycleATM")
        End Function

        Public Function PauseProcess() As Boolean
            AVPLib.Log.coreLogger.Info("Enter PauseProcess")
            Return CType(m_ObjController, IRecipeProcessing).PauseRecipe()
            AVPLib.Log.coreLogger.Info("Leave PauseProcess")
        End Function

        Public Function ResumeProcess() As Boolean
            AVPLib.Log.coreLogger.Info("Enter ResumeProcess")
            Return CType(m_ObjController, IRecipeProcessing).ResumeRecipe()
            AVPLib.Log.coreLogger.Info("Leave ResumeProcess")
        End Function

        Function SetIsoValveStatus(ByVal bOpen As Boolean) As Boolean
            Return CType(m_ObjController, IRecipeProcessing).SetIsoValveStatus(IIf(bOpen, ConfigurationValues.DEVICE_STATUS_OPEN, ConfigurationValues.DEVICE_STATUS_CLOSED))
        End Function

        Public Overridable Sub SendRequestAllData() Implements IRecipeProcessing.SendRequestAllData
            CType(m_ObjController, IRecipeProcessing).SendRequestAllData()
        End Sub
#Region "Recipe Processing, implementing IRecipeProcessing"

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-28-04</date>
        ''' </author>
        ''' <summary>
        ''' Start recipe processing.
        ''' </summary>
        ''' <param name="pathFrom"></param>
        ''' <param name="pathTo"></param>
        ''' <remarks></remarks>
        Public Function StartRecipe(ByVal pathFrom As String, ByVal pathTo As String, ByVal bSetRecipeNameAndStartCmd As Boolean) As Boolean Implements IRecipeProcessing.StartRecipe
            Dim bRet As Boolean = False
            Try
                bRet = CType(m_ObjController, IRecipeProcessing).StartRecipe(pathFrom, pathTo, bSetRecipeNameAndStartCmd)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bRet
        End Function

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-28-04</date>
        ''' </author>
        ''' <summary>
        ''' Stop recipe processing.
        ''' </summary>
        Public Function StopRecipe() As Boolean Implements IRecipeProcessing.StopRecipe
            Try
                Return CType(m_ObjController, IRecipeProcessing).StopRecipe()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Function

        Public Function SetRecipeName(ByVal Val As String) As Boolean Implements IRecipeProcessing.SetRecipeName
            'implement in IBEController or PVDController
            AVPLib.Log.coreLogger.Info("Leave SetRecipeName")
            Return CType(m_ObjController, IRecipeProcessing).SetRecipeName(Val)
            AVPLib.Log.coreLogger.Info("Leave SetRecipeName")
        End Function

        Public Function SetDataRunFileName(ByVal Val As String) As Boolean Implements IRecipeProcessing.SetDataRunFileName
            'implement in IBEController or PVDController
            AVPLib.Log.coreLogger.Info("Leave SetDataRunFileName")
            Return CType(m_ObjController, IRecipeProcessing).SetDataRunFileName(Val)
            AVPLib.Log.coreLogger.Info("Leave SetDataRunFileName")
        End Function

        Public Function SendToPM_CurrentAVPTime() As Boolean Implements IRecipeProcessing.SendToPM_CurrentAVPTime
            Try
                Return CType(m_ObjController, IRecipeProcessing).SendToPM_CurrentAVPTime
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Function

        Public Function StartProcessing() As Boolean Implements IRecipeProcessing.StartProcessing
            'implement in IBEController or PVDController
            AVPLib.Log.coreLogger.Info("Leave StartProcessing")
            Return CType(m_ObjController, IRecipeProcessing).StartProcessing()
            AVPLib.Log.coreLogger.Info("Leave StartProcessing")
        End Function

        Public Function StartProcessingCycleATM(ByVal val As String) As Boolean Implements IRecipeProcessing.StartProcessingCycleATM
            'implement in IBEController or PVDController
            AVPLib.Log.coreLogger.Info("Leave StartProcessingCycleATM")
            Return CType(m_ObjController, IRecipeProcessing).StartProcessingCycleATM(val)
            AVPLib.Log.coreLogger.Info("Leave StartProcessingCycleATM")
        End Function

        Public Sub Process_Reset_Error() Implements IRecipeProcessing.Process_Reset_Error
            'implement in IBEController or PVDController
            AVPLib.Log.coreLogger.Info("Leave Process_Reset_Error")
            CType(m_ObjController, IRecipeProcessing).Process_Reset_Error()
            AVPLib.Log.coreLogger.Info("Leave Process_Reset_Error")
        End Sub

        Public Function DoSetWaferStatus(ByVal strStatus As String) As Boolean Implements IRecipeProcessing.DoSetWaferStatus
            'implement in IBEController or PVDController
            AVPLib.Log.coreLogger.Info("Leave DoSetWaferStatus")
            Return CType(m_ObjController, IRecipeProcessing).DoSetWaferStatus(strStatus)
            AVPLib.Log.coreLogger.Info("Leave DoSetWaferStatus")
        End Function

        Function SetIsoValveStatus(ByVal strOnOff As String) As Boolean Implements IRecipeProcessing.SetIsoValveStatus
            AVPLib.Log.coreLogger.Info("Leave SetIsoValveStatus")
            CType(m_ObjController, IRecipeProcessing).SetIsoValveStatus(strOnOff)
            AVPLib.Log.coreLogger.Info("Leave SetIsoValveStatus")
        End Function

        Function ResumeRecipe() As Boolean Implements IRecipeProcessing.ResumeRecipe
            'implement in IBEController or PVDController
            AVPLib.Log.coreLogger.Info("Leave ResumeRecipe")
            Return CType(m_ObjController, IRecipeProcessing).ResumeRecipe()
            AVPLib.Log.coreLogger.Info("Leave ResumeRecipe")
        End Function

        Function PauseRecipe() As Boolean Implements IRecipeProcessing.PauseRecipe
            'implement in IBEController or PVDController
            AVPLib.Log.coreLogger.Info("Leave PauseRecipe")
            Return CType(m_ObjController, IRecipeProcessing).PauseRecipe()
            AVPLib.Log.coreLogger.Info("Leave PauseRecipe")
        End Function
#End Region

        Public Overrides Sub RaiseFinishOnline(ByVal Check As Boolean)
            If (m_ObjController IsNot Nothing) Then
                m_ObjController.RaiseFinishOnline(Check)
            End If
        End Sub
#End Region
        Public Sub DoCheckRecipeTemplateVersion() Implements IRecipeProcessing.DoCheckRecipeTemplateVersion
            CType(m_ObjController, IRecipeProcessing).DoCheckRecipeTemplateVersion()
        End Sub
        ''Truc Le: Call backgroundworker for copy file
        Public Sub CopyRecipeToPMFolder() Implements IRecipeProcessing.CopyRecipeToPMFolder
            AVPLib.Log.coreLogger.Info("Enter CopyRecipeToPMFolder")
            Try
                If m_CopyRecipe_Worker Is Nothing Then
                    m_CopyRecipe_Worker = New ComponentModel.BackgroundWorker()
                    AddHandler m_CopyRecipe_Worker.DoWork, New ComponentModel.DoWorkEventHandler(AddressOf OnBackGroundWorking_CopyRecipeToPMFolder)
                End If
                If m_CopyRecipe_Worker.IsBusy Then
                    Exit Try
                End If
                m_CopyRecipe_Worker.RunWorkerAsync()

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CopyRecipeToPMFolder")
        End Sub

        ''Truc Le: BackGroundWorker copy recipe file to each PM Folder
        Private Sub OnBackGroundWorking_CopyRecipeToPMFolder(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
            AVPLib.Log.coreLogger.Info("Enter OnBackGroundWorking_CopyRecipeToPMFolder")
            Dim blnResultCopingFile As Boolean = True
            Try
                Dim PathFrom As String = String.Empty
                If Not (Utils.IsIBEChamber_ANYIBE(Me.EquipmentName)) Then
                    PathFrom = AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & Me.EquipmentName
                Else
                    PathFrom = AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & ConstEnum.Equipments.IBE.ToString
                End If

                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(Me.EquipmentName)
                Dim PathTo As String = serverConfig.RecipeFolder

                'check if Directory is not exist
                If Not System.IO.Directory.Exists(PathTo) Then ''check and create Directory if not exist
                    Try
                        System.IO.Directory.CreateDirectory(PathTo)
                    Catch ex As Exception
                        blnResultCopingFile = False
                        AVPLib.Log.avpLogger.Error("Failed to copy file to PM Folder: Recipe PM Folder doesn't exist")
                    End Try
                End If

                If Not System.IO.Directory.Exists(PathFrom) OrElse Not System.IO.Directory.Exists(PathTo) Then
                    AVPLib.Log.avpLogger.Error("Copy Recipe to PM Failed, nothing to be copy")
                    blnResultCopingFile = False
                    Exit Try
                End If
                ''Get and Copy Files
                Dim Files As String() = System.IO.Directory.GetFiles(PathFrom, "*.xml")
                For Each File As String In Files
                    Dim strDestFile As String = Utils.GetFileName(File, False)
                    Try
                        System.IO.File.Copy(File, PathTo & "\" & strDestFile, True)
                    Catch ex As IO.IOException
                        blnResultCopingFile = False
                        AVPLib.Log.avpLogger.Error("Failed to copy file to PM Folder: " & File & " - " & ex.Message)
                    End Try
                Next

            Catch ex As Exception
                blnResultCopingFile = False
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            'send result to PMx
            If (m_ObjController.GetType().Name = ControllerType.IBEController.ToString()) Then
                IBEUtility.SendCommandWithDataToIBE(m_ObjController.EquipmentName,
                                                    IBECommands.COPYRECIPE_TO_PMFOLDER.ToString(),
                                                    IIf(blnResultCopingFile, ConfigurationValues.DEVICE_STATUS_OPEN,
                                                    ConfigurationValues.DEVICE_STATUS_CLOSED))

            ElseIf m_ObjController.GetType.Name = ControllerType.PVDController.ToString() Then
                PVDUtility.SendCommandWithDataToPVD(m_ObjController.EquipmentName,
                                                                    PVDCommands.COPYRECIPE_TO_PMFOLDER.ToString(),
                                                                    IIf(blnResultCopingFile, ConfigurationValues.DEVICE_STATUS_OPEN,
                                                                    ConfigurationValues.DEVICE_STATUS_CLOSED))
            ElseIf UCase(m_ObjController.GetType.Name) = UCase(ControllerType.CORONAController.ToString()) Then
                CoronaUtility.SendCommandWithDataToCorona(m_ObjController.EquipmentName,
                                                                    CORONACommands.COPYRECIPE_TO_PMFOLDER.ToString(),
                                                                    IIf(blnResultCopingFile, ConfigurationValues.DEVICE_STATUS_OPEN,
                                                                    ConfigurationValues.DEVICE_STATUS_CLOSED))
            ElseIf UCase(m_ObjController.GetType.Name) = UCase(ControllerType.PVD5TController.ToString()) Then
                PVD5TUtility.SendCommandWithDataToPVD5T(m_ObjController.EquipmentName,
                                                                    CORONACommands.COPYRECIPE_TO_PMFOLDER.ToString(),
                                                                    IIf(blnResultCopingFile, ConfigurationValues.DEVICE_STATUS_OPEN,
                                                                    ConfigurationValues.DEVICE_STATUS_CLOSED))

            End If
            AVPLib.Log.coreLogger.Info("Leave OnBackGroundWorking_CopyRecipeToPMFolder")
        End Sub

        ''Truc Le: Call backgroundworker for copy file
        Public Sub CopyRecipeTemplate() Implements IRecipeProcessing.CopyRecipeTemplate
            AVPLib.Log.coreLogger.Info("Enter CopyRecipeTemplate")
            Try
                Threading.ThreadPool.QueueUserWorkItem(AddressOf DoCopyRecipeTemplate)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CopyRecipeTemplate")
        End Sub


        'Private Sub GetNewFileName(Byval fleInfo as FileInfo, Byval name as string) As String

        '    Dim format As String = String.Format("{0}_{1}", name, "Template")
        '    Dim extension As String = ".xml"
        '    Return Path.Combine(fleInfo.DirectoryName, String.Concat(fleInfo.Name.Split(".")(0), "_", format, extension))
        'End Sub

        ''Truc Le: BackGroundWorker copy recipe file to each PM Folder
        Public Sub DoCopyRecipeTemplate(ByVal state As Object)
            AVPLib.Log.coreLogger.Info("Enter OnBackGroundWorking_CopyRecipeTemplate")
            Dim blnResultCopingFile As Boolean = True
            Try
                Dim ChamberName As String = Me.EquipmentName
                Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(ChamberName)
                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ChamberName)
                Dim ChamberType As String = objChamber.Type.ToString()
                Dim PathTo As String = serverConfig.RecipeFolder
                Dim PathFrom As String = AVPLib.ContainerDAO.FPath_RecipeTemplate
                If Utils.CreateDirectory(PathTo) Then ''check and create Directory if not exist
                    If Not System.IO.Directory.Exists(PathFrom) Then
                        AVPLib.Log.avpLogger.Error("Copy Recipe to PM Failed, nothing to be copy")
                        blnResultCopingFile = False
                        Exit Try
                    End If
                    Try
                        Dim Files As String() = System.IO.Directory.GetFiles(PathFrom, ChamberType & ".xml")
                        For Each File As String In Files
                            Dim strDestFile As String = Utils.GetFileName(File, False)
                            Try
                                System.IO.File.Copy(File, PathTo & "\" & ChamberType & "_Template.xml", True)
                            Catch ex As IO.IOException
                                blnResultCopingFile = False
                                AVPLib.Log.avpLogger.Error("Failed to copy file to PM Folder: " & File & " - " & ex.Message)
                            End Try
                        Next
                    Catch ex As IO.IOException
                        blnResultCopingFile = False
                        AVPLib.Log.avpLogger.Error("Failed to get File : " & ChamberType & ".xml" & " - " & ex.Message)
                    End Try
                Else
                    ''show log error if path is not exist
                    AVPLib.Log.avpLogger.Error("Can not create or path does not exist: " & PathTo)
                    blnResultCopingFile = False
                    Exit Try
                End If

            Catch ex As Exception
                blnResultCopingFile = False
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            'send result to PMx
            SendResultOfCopyRecipeTemplate(blnResultCopingFile)
            AVPLib.Log.coreLogger.Info("Leave OnBackGroundWorking_CopyRecipeToPMFolder")
        End Sub

        Public Sub SendResultOfCopyRecipeTemplate(ByVal blnResult As Boolean) Implements IRecipeProcessing.SendResultOfCopyRecipeTemplate
            CType(m_ObjController, IRecipeProcessing).SendResultOfCopyRecipeTemplate(blnResult)
        End Sub
        ''<name> Truc Le </name>
        ''<date> 2014-04-14</date>
        ''</author>
        ''<summary>
        ''' 0004787: [KhoiHa 03/22/2014]If user run a scheduler with recipe only using T2/T3/T4. 
        ''' With picture below, user should be allow to run since this schedule is not using T1.
        ''</summary>
        Public Function GetAllTargetBaseOnRecipe(ByVal strRecipeName As String, ByVal strStationName As String) As System.Collections.Generic.List(Of String) Implements IRecipeProcessing.GetAllTargetBaseOnRecipe
            Return CType(m_ObjController, IRecipeProcessing).GetAllTargetBaseOnRecipe(strRecipeName, strStationName)
        End Function

        ''' <author>
        '''    	<name> Vy Nguyen </name>
        '''    	<date> 2014-04-11 </date>
        ''' </author>
        ''' <summary>
        ''' 0004787: [KhoiHa 03/22/2014]If user run a scheduler with recipe only using T2/T3/T4. 
        ''' With picture below, user should be allow to run since this schedule is not using T1.
        ''' Get sequence information
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CheckingKWHOverAlarmLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingKWHOverAlarmLimit
            Return CType(m_ObjController, IRecipeProcessing).CheckingKWHOverAlarmLimit(sTargetUsed)
        End Function

        ''' <author>
        '''    	<name> Vy Nguyen </name>
        '''    	<date> 2014-04-11 </date>
        ''' </author>
        ''' <summary>
        ''' 0004787: [KhoiHa 03/22/2014]If user run a scheduler with recipe only using T2/T3/T4. 
        ''' With picture below, user should be allow to run since this schedule is not using T1.
        ''' Get sequence information
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CheckingKWHOverWarningLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingKWHOverWarningLimit
            Return CType(m_ObjController, IRecipeProcessing).CheckingKWHOverWarningLimit(sTargetUsed)
        End Function

        ''' <author>
        '''     <name> Hai Tran </name>
        '''     <date> 2015-06-19 </date>
        ''' </author>
        ''' <summary>
        ''' CheckingShieldsQuartzOverAlarmLimit
        ''' </summary>
        Public Function CheckingShieldsQuartzOverAlarmLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingShieldsQuartzOverAlarmLimit
            Return CType(m_ObjController, IRecipeProcessing).CheckingShieldsQuartzOverAlarmLimit(sTargetUsed)
        End Function

        ''' <author>
        '''     <name> Hai Tran </name>
        '''     <date> 2015-06-19 </date>
        ''' </author>
        ''' <summary>
        ''' CheckingShieldsQuartzOverWarningLimit
        ''' </summary>
        Public Function CheckingShieldsQuartzOverWarningLimit(ByVal sTargetUsed As System.Collections.Generic.List(Of String)) As String Implements IRecipeProcessing.CheckingShieldsQuartzOverWarningLimit
            Return CType(m_ObjController, IRecipeProcessing).CheckingShieldsQuartzOverWarningLimit(sTargetUsed)
        End Function

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2016-06-20</date>
        ''' </author>
        ''' <summary>
        ''' Send WaferID to PM.
        ''' </summary>
        Public Overridable Function SendProcessWaferID() As Boolean Implements IRecipeProcessing.SendProcessWaferID
            Return CType(m_ObjController, IRecipeProcessing).SendProcessWaferID()
        End Function

        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2016-06-20</date>
        ''' </author>
        ''' <summary>
        ''' Send LotID to PM.
        ''' </summary>
        Public Overridable Function SendProcessLotID() As Boolean Implements IRecipeProcessing.SendProcessLotID
            Return CType(m_ObjController, IRecipeProcessing).SendProcessLotID
        End Function
        ''' <author>
        '''     <name>Tinh Le</name>
        '''     <date>2020-12-10</date>
        ''' </author>
        ''' <summary>
        ''' Send start recipe to PM.
        ''' </summary>
        Public Overridable Function StartWarmUp() As Boolean Implements IRecipeProcessing.StartWarmUp
            Return CType(m_ObjController, IRecipeProcessing).StartWarmUp
        End Function
    End Class
End Namespace

