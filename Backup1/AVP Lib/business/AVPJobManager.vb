Imports AVPLib.DataManagerment
Imports System.Threading
Namespace Business
    Public Class AVPJobManager
        Inherits SuspendableThread
#Region "Avariables and Properties"
        Private m_iPJProcessingOrder As Integer = ConstEnum.PROCESSING_ORDER_OPTIMIZATION
        Private m_iCJProcessingOrder As Integer = ConstEnum.PROCESSING_ORDER_OPTIMIZATION

        'SPECIFICATION FOR CORONA PROCESSING
        Private m_iCJBatchProcessing As Boolean = False

        Private m_lstControlJob As List(Of AVPControlJob) = New List(Of AVPControlJob)

        Private m_ilastCtlJobNum As Integer
        Private m_iReturnFreeJobCount As Integer
        Public Check_Safety_Interlock_During_Process As Boolean = True
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-02</date>
        ''' </author>
        ''' <summary>
        ''' Initialize processing order
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize()
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                m_ilastCtlJobNum = 0
                'Init CJ Processing order here
                m_iCJProcessingOrder = AVPLib.ContainerData.GetIntegerFromKeyValueInRobotConfig(ConstEnum.CJPROCESSING_ORDER, ConstEnum.PROCESSING_ORDER_OPTIMIZATION)
                If (m_iCJProcessingOrder <> ConstEnum.PROCESSING_ORDER_OPTIMIZATION And _
                    m_iCJProcessingOrder <> ConstEnum.PROCESSING_ORDER_LIST) Then
                    m_iCJProcessingOrder = ConstEnum.PROCESSING_ORDER_OPTIMIZATION
                End If

                'Init PJ processing order here
                m_iPJProcessingOrder = AVPLib.ContainerData.GetIntegerFromKeyValueInRobotConfig(ConstEnum.PJPROCESSING_ORDER, ConstEnum.PROCESSING_ORDER_OPTIMIZATION)
                If (m_iPJProcessingOrder <> ConstEnum.PROCESSING_ORDER_OPTIMIZATION And _
                    m_iPJProcessingOrder <> ConstEnum.PROCESSING_ORDER_LIST) Then
                    m_iPJProcessingOrder = ConstEnum.PROCESSING_ORDER_OPTIMIZATION
                End If

                ' Start processing.
                Start()

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Sub
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            AVPLib.Log.coreLogger.Info("Enter Dispose")
            If (disposing) Then
                Dim controlJob As AVPControlJob = Nothing
                For Each controlJob In m_lstControlJob
                    controlJob.JobAbort()
                Next
                TerminateAndWait()
            End If
            MyBase.Dispose(disposing)
            AVPLib.Log.coreLogger.Info("Leave Dispose")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-08-04</date>
        ''' </author>
        ''' <summary>
        ''' get processing order
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CJBatchProcessing() As Boolean
            Get
                Return m_iCJBatchProcessing
            End Get
            Set(ByVal value As Boolean)
                m_iCJBatchProcessing = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-08-04</date>
        ''' </author>
        ''' <summary>
        ''' get processing order
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ReturnFreeJobCount() As Integer
            Get
                Return m_iReturnFreeJobCount
            End Get
        End Property
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' get processing order
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CJProcessingOrder() As Integer
            Get
                Return m_iCJProcessingOrder
            End Get
            Set(ByVal value As Integer)
                m_iCJProcessingOrder = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' get processing order
        ''' </summary>
        ''' <remarks></remarks>
        Public Property PJProcessingOrder() As Integer
            Get
                Return m_iPJProcessingOrder
            End Get
            Set(ByVal value As Integer)
                m_iPJProcessingOrder = value
            End Set
        End Property
        'able to next Control Job
        ReadOnly Property CanStartNextControlJob() As Boolean
            Get
                Return (ConstEnum.PROCESSING_ORDER_OPTIMIZATION = m_iCJProcessingOrder)
            End Get
        End Property

        ReadOnly Property ListControlJob() As List(Of AVPControlJob)
            Get
                Return m_lstControlJob
            End Get
        End Property
#End Region

#Region "Public method"
        ' If PLATFORM = CX, SequenceID is a xml file
        ' SINGLE_LOADER, SequenceID has the format of 'Chamber1=recipe.xml'
        Public Function CreateAutoControlJobForSingleLoader(ByVal strLoadLockName As String, ByVal strLotID As String, ByVal strSequenceID As String, _
        ByVal bIsContinuousJob As Boolean, ByVal bRuntWithRecipe As Boolean) As String
            If (m_ilastCtlJobNum = Integer.MaxValue) Then
                m_ilastCtlJobNum = 0
            End If
            m_ilastCtlJobNum += 1
            Dim strCtrlJobId As String = ("CTRL_JOB_" & m_ilastCtlJobNum.ToString())
            'Do not run in ATM mode
            Dim avpCJ As AVPControlJob = New AVPControlJob(strLoadLockName, strLotID, strSequenceID, strCtrlJobId, bIsContinuousJob, bRuntWithRecipe, False)
            avpCJ.JobManager = Me
            AddHandler avpCJ.CJTransferCompletedEvent, AddressOf CJCompletedEventHandler
            AddHandler avpCJ.CJProcessingStatusEvent, AddressOf CJProcessingStatusHandler
            avpCJ.Initialize()
            SyncLock m_lstControlJob
                m_lstControlJob.Add(avpCJ)
                avpCJ.ChangeStateCJ(ConstEnum.CJSTATE_MACHINES.Queued.ToString())
                AVPLib.Log.schedulerLogger.Debug("AUTO SINGLE LOADER CTRLJOB=" & avpCJ.JobID & " HAS BEEN ADDED TO JOBQUEUE.")
            End SyncLock
            avpCJ.SelectJob()
            Return strCtrlJobId
        End Function

        Public Function CreateControlJob(ByVal strLoadLockName As String, ByVal strLotID As String, ByVal strSequenceID As String) As String
            Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(strLoadLockName)
            If (m_ilastCtlJobNum = Integer.MaxValue) Then
                m_ilastCtlJobNum = 0
            End If
            m_ilastCtlJobNum += 1
            Dim strCtrlJobId As String = ("CTRL_JOB_" & m_ilastCtlJobNum.ToString())
            Dim avpCJ As AVPControlJob = New AVPControlJob(strLoadLockName, _
                                                            strLotID, _
                                                            strSequenceID, _
                                                            strCtrlJobId, _
                                                            objLoadLock.InCycleMode_RunWithRecipe, _
                                                            objLoadLock.RunWithRecipe, _
                                                            objLoadLock.IsCycleInATM_Mode, objLoadLock.MaxCycleCount)
            avpCJ.JobManager = Me
            AddHandler avpCJ.CJTransferCompletedEvent, AddressOf CJCompletedEventHandler
            AddHandler avpCJ.CJProcessingStatusEvent, AddressOf CJProcessingStatusHandler

            'disible Clear All Wafer in ProcessPanel
            AVPLib.Utils.EnableDisableClearAllWaferButton(AVPLib.ConstEnum.STR_OFF)

            avpCJ.Initialize()
            SyncLock m_lstControlJob
                m_lstControlJob.Add(avpCJ)
                avpCJ.ChangeStateCJ(ConstEnum.CJSTATE_MACHINES.Queued.ToString())
                AVPLib.Log.schedulerLogger.Debug("AUTO CTRLJOB=" & avpCJ.JobID & " HAS BEEN ADDED TO JOBQUEUE.")
            End SyncLock
            avpCJ.SelectJob()
            Return strCtrlJobId
        End Function

        Public Function CreateControlJobForSemiTransfer(ByVal strFullCommand As String, _
                        Optional ByVal blReturnFreeJob As Boolean = False) As String
            If (m_ilastCtlJobNum = Integer.MaxValue) Then
                m_ilastCtlJobNum = 0
            End If
            m_ilastCtlJobNum += 1
            Dim strCtrlJobId As String = ("CTRL_JOB_" & m_ilastCtlJobNum.ToString())

            Dim avpCJ As AVPControlJob = Nothing
            If (blReturnFreeJob = False) Then
                avpCJ = New AVPControlJob(strFullCommand, strCtrlJobId)
            Else
                avpCJ = New AVPControlJob(strFullCommand, strCtrlJobId, True)
            End If

            AddHandler avpCJ.CJTransferCompletedEvent, AddressOf CJCompletedEventHandler
            If (strFullCommand.IndexOf(ConstEnum.ONLINELOADLOCKA) >= 0) OrElse (strFullCommand.IndexOf(ConstEnum.LoadLockA_STR) >= 0) Then
                avpCJ.LoadlockName = ConstEnum.LoadLockA_STR
            End If
            avpCJ.JobManager = Me
            avpCJ.Initialize()
            SyncLock m_lstControlJob
                m_lstControlJob.Add(avpCJ)

                If (blReturnFreeJob) Then
                    IncReturnFreeJobCount()
                End If

                avpCJ.ChangeStateCJ(ConstEnum.CJSTATE_MACHINES.Queued.ToString())
                AVPLib.Log.schedulerLogger.Debug("MANUAL CTRLJOB=" & avpCJ.JobID & " HAS BEEN ADDED TO JOBQUEUE.")
            End SyncLock
            avpCJ.SelectJob()
            Return strCtrlJobId
        End Function

        Public Sub CJCommand(ByVal strJobId As String, ByVal strCmd As String, Optional ByVal strParameters As String = Nothing)
            Dim cj As AVPControlJob = Nothing
            cj = GetControlJob(strJobId)
            If (cj Is Nothing) Then
                Return
            End If
            Select Case strCmd
                Case ConstEnum.CJ_CMDS.CJ_CMD_START
                    AVPLotDatalog.AddLotDatalog(cj.LoadlockName, LogType.Info, _
                        "LotID: " & cj.LotId & ", Job Starting", cj.IsAutoTransferJob)
                    cj.JobStart()
                Case ConstEnum.CJ_CMDS.CJ_CMD_STOP
                    AVPLotDatalog.AddLotDatalog(cj.LoadlockName, LogType.Info, _
                        "LotID: " & cj.LotId & ", Job Stopping", cj.IsAutoTransferJob)
                    cj.JobStop()
                Case ConstEnum.CJ_CMDS.CJ_CMD_ABORT
                    Dim bReturnAllWafers As Boolean = False
                    Boolean.TryParse(strParameters, bReturnAllWafers)
                    If String.IsNullOrEmpty(strParameters) Or bReturnAllWafers = False Then
                        AVPLotDatalog.AddLotDatalog(cj.LoadlockName, LogType.Info, _
                        "LotID: " & cj.LotId & ", User Aborting", cj.IsAutoTransferJob)
                        cj.JobAbort(False)
                    ElseIf bReturnAllWafers Then
                        AVPLotDatalog.AddLotDatalog(cj.LoadlockName, LogType.Info, _
                        "LotID: " & cj.LotId & ", Job Abort And Return All Wafer", cj.IsAutoTransferJob)
                        cj.JobAbort(True)
                    End If
                Case ConstEnum.CJ_CMDS.CJ_CMD_PAUSE
                    AVPLotDatalog.AddLotDatalog(cj.LoadlockName, LogType.Info, _
                        "LotID: " & cj.LotId & ", Job Pause", cj.IsAutoTransferJob)
                    cj.JobPause()
                Case ConstEnum.CJ_CMDS.CJ_CMD_RESUME
                    AVPLotDatalog.AddLotDatalog(cj.LoadlockName, LogType.Info, _
                        "LotID: " & cj.LotId & ", Job Resuming", cj.IsAutoTransferJob)
                    cj.JobResume()
                Case ConstEnum.CJ_CMDS.CJ_CMD_FORCE_ABORT
                    AVPLotDatalog.AddLotDatalog(cj.LoadlockName, LogType.Info, _
                        "LotID: " & cj.LotId & ", Force Job Aborting", cj.IsAutoTransferJob)
                    cj.ForceAbortJob()
            End Select
        End Sub

        Public Sub PJCommand(ByVal strWaferID As String, ByVal strCmd As String)
            Dim proJob As AVPProcessJob = GetProcessJob(strWaferID)
            If (proJob Is Nothing) Then
                Return
            End If
            Select Case strCmd
                Case ConstEnum.PJ_CMDS.PJ_CMD_START
                    AVPLotDatalog.AddLotDatalog(proJob.AVPParentControlJob.LoadlockName, LogType.Info, _
                        "Wafer: " & strWaferID & ", Processing Start", proJob.IsAutoTransfer)
                    proJob.JobStart()
                Case ConstEnum.PJ_CMDS.PJ_CMD_ABORT
                    proJob.JobAbort(False)
                    AVPLotDatalog.AddLotDatalog(proJob.AVPParentControlJob.LoadlockName, LogType.Info, _
                        "Wafer: " & strWaferID & ", Processing Abort", proJob.IsAutoTransfer)
                Case ConstEnum.PJ_CMDS.PJ_CMD_PAUSE
                    proJob.JobPause()
                    AVPLotDatalog.AddLotDatalog(proJob.AVPParentControlJob.LoadlockName, LogType.Info, _
                        "Wafer: " & strWaferID & ", Processing Pause", proJob.IsAutoTransfer)
                Case ConstEnum.PJ_CMDS.PJ_CMD_RESUME
                    proJob.JobResume()
                    AVPLotDatalog.AddLotDatalog(proJob.AVPParentControlJob.LoadlockName, LogType.Info, _
                        "Wafer: " & strWaferID & ", Processing Resume", proJob.IsAutoTransfer)
                Case ConstEnum.PJ_CMDS.PJ_CMD_MARK_FOR_RETURN

                    If m_iCJBatchProcessing Then
                        proJob.AVPParentControlJob.BatchMarkForReturn(proJob.BatchProcessJobGroupIdx)
                    Else
                        proJob.JobAbort(True)
                    End If

                    AVPLotDatalog.AddLotDatalog(proJob.AVPParentControlJob.LoadlockName, LogType.Info, _
                        "Wafer: " & strWaferID & ", Mark For Return Wafer", proJob.IsAutoTransfer)
            End Select
        End Sub

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Get control job 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetControlJob(ByVal strJobId As String) As AVPControlJob
            SyncLock m_lstControlJob
                Dim controlJob As AVPControlJob
                For Each controlJob In m_lstControlJob
                    If controlJob.JobID = strJobId Then
                        Return controlJob
                    End If
                Next
            End SyncLock
            Return Nothing
        End Function

        Public Function GetProcessJob(ByVal strJobId As String) As AVPProcessJob
            Dim controlJob As AVPControlJob = Nothing
            Dim processJob As AVPProcessJob = Nothing
            SyncLock m_lstControlJob
                For Each controlJob In m_lstControlJob
                    processJob = controlJob.GetProcJob(strJobId)
                    If (processJob IsNot Nothing) Then
                        Return processJob
                    End If
                Next
            End SyncLock
            Return Nothing
        End Function

        ''' <author>Hai Tran</author>
        ''' <date>2016-03-24</date>
        ''' <summary>
        ''' Get process job is current running.
        ''' <summary>
        Public Function GetProcessJobRunning() As AVPProcessJob
            Dim controlJob As AVPControlJob = Nothing
            Dim processJob As AVPProcessJob = Nothing
            SyncLock m_lstControlJob
                For Each controlJob In m_lstControlJob
                    processJob = controlJob.GetProcJobRunning
                    If (processJob IsNot Nothing) Then
                        Return processJob
                    End If
                Next
            End SyncLock
            Return Nothing
        End Function

#End Region
        Public Function GetNoOfCtrlJobs(ByVal strState As String) As Integer
            Dim num As Integer = 0
            SyncLock m_lstControlJob
                Dim job As AVPControlJob = Nothing
                For Each job In m_lstControlJob
                    If ((job.JobType = JobTypeEnum.ControlJob) AndAlso (job.CurrentState = strState)) Then
                        num += 1
                    End If
                Next
            End SyncLock
            Return num
        End Function
        Public Function GetFirstCtrlJob(ByVal idx As Integer, ByVal strState As String) As AVPControlJob
            Dim num As Integer = 0
            SyncLock m_lstControlJob
                Dim job As AVPControlJob = Nothing
                For Each job In m_lstControlJob
                    If ((job.JobType = JobTypeEnum.ControlJob) AndAlso (job.CurrentState = strState)) Then
                        If (num = idx) Then
                            Return job
                        End If
                        num += 1
                    End If
                Next
            End SyncLock
            Return Nothing
        End Function
        Public Function DequeueJob(ByVal ctrlJob As AVPControlJob) As Boolean
            Dim flag As Boolean = False
            If (ctrlJob Is Nothing) Then
                AVPLib.Log.schedulerLogger.Debug("Null job can not be dequeued.")
                Return flag
            End If
            SyncLock m_lstControlJob
                If m_lstControlJob.Contains(ctrlJob) Then
                    m_lstControlJob.Remove(ctrlJob)
                    flag = True
                    AVPLib.Log.schedulerLogger.Debug("CTRLJOB=" & ctrlJob.JobID & " HAS BEEN DEQUEUED.")
                End If
            End SyncLock
            Return flag
        End Function
        Public Function GetStoppingCtrlJob(ByVal idx As Integer) As AVPControlJob
            Dim num As Integer = 0
            SyncLock m_lstControlJob
                Dim job As AVPControlJob = Nothing
                For Each job In m_lstControlJob
                    If (job.JobType = JobTypeEnum.ControlJob) Then
                        If job.IsStopInProcess Then
                            If (num = idx) Then
                                Return job
                            End If
                            num += 1
                        End If
                    End If
                Next
            End SyncLock
            Return Nothing
        End Function
        Public Function GetAbortingCtrlJob(ByVal idx As Integer) As AVPControlJob
            Dim num As Integer = 0
            SyncLock m_lstControlJob
                Dim job As AVPControlJob = Nothing
                For Each job In m_lstControlJob
                    If (job.JobType = JobTypeEnum.ControlJob) Then
                        If job.IsAbortInProcess Then
                            If (num = idx) Then
                                Return job
                            End If
                            num += 1
                        End If
                    End If
                Next
            End SyncLock
            Return Nothing
        End Function
        Public Function GetPauseingCtrlJob(ByVal idx As Integer) As AVPControlJob
            Dim num As Integer = 0
            SyncLock m_lstControlJob
                Dim job As AVPControlJob = Nothing
                For Each job In m_lstControlJob
                    If (job.JobType = JobTypeEnum.ControlJob) Then
                        If job.IsPauseInProcess Then
                            If (num = idx) Then
                                Return job
                            End If
                            num += 1
                        End If
                    End If
                Next
            End SyncLock
            Return Nothing
        End Function
        ' Scheduler.  LLA/LLB takes turn to run.
        Private Function IsAllCJInCycleMode() As Boolean            
            Dim job As AVPControlJob = Nothing
            For Each job In m_lstControlJob
                If (job.JobType = JobTypeEnum.ControlJob) Then
                    If Not job.IsContinuousJob Then
                        Return False
                    End If
                End If
            Next
            Return True
        End Function
        'Dat Cao - 08-04-2011
        'Last active control job push to end of list
        'it mean CJ have priority smaller
        Private Sub SortControlJob(ByRef listCJ As List(Of AVPControlJob))
            If (listCJ IsNot Nothing) Then
                Dim CJ As AVPControlJob = Nothing
                Dim i As Integer = 0
                For i = 0 To listCJ.Count - 1
                    If (i < listCJ.Count - 1) Then
                        CJ = listCJ.Item(i)
                        If (CJ.isLastActiveControlJob AndAlso CJ.IsAutoTransferJob) Then
                            listCJ.Remove(CJ)
                            listCJ.Add(CJ)
                            CJ.isLastActiveControlJob = False
                        End If
                    End If
                Next
            End If
        End Sub
        ''' <author>
        '''    	<name>Dat Cao</name>
        '''    	<date> 2011-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Aligner is current in use when:
        ''' + Nothing
        ''' + Busy
        ''' + ERROR
        ''' </summary>
        Private Function CheckAlinerCurrentInUse() As Boolean

            If Not RobotConfigurationValues.ALINER_VISIBLE Then
                Return False
            End If

            Dim e As Equipment = Nothing
            e = EquipmentManager.GetEquipment("Aligner")
            If (e IsNot Nothing AndAlso e.GetWaferInfo() IsNot Nothing) Then
                Return True
            End If

            Return IsJobPauseAtAligner()
        End Function
        ''' <author>
        '''    	<name>Dat Cao</name>
        '''    	<date> 2013-05-24</date>
        ''' </author>
        ''' <summary>
        ''' Check existed job pause at aligner
        ''' </summary>
        Private Function IsJobPauseAtAligner() As Boolean
            Dim blResult As Boolean = False
            Try

                If Not RobotConfigurationValues.ALINER_VISIBLE Then
                    Exit Try
                End If

                SyncLock m_lstControlJob
                    For Each job As AVPControlJob In m_lstControlJob
                        If (job IsNot Nothing AndAlso job.IsJobPauseAtAligner) Then
                            blResult = True
                            Exit Try
                        End If
                    Next
                End SyncLock

            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try

            Return blResult
        End Function
        ''' <author>
        '''    	<name>Dat Cao</name>
        '''    	<date> 2011-04-07</date>
        ''' </author>
        ''' <summary>
        ''' Aligner is current in use when:
        ''' + Nothing
        ''' + Busy
        ''' + ERROR
        ''' </summary>
        Private Function isAnyReturnFreeJobRunning() As Boolean
            For Each Job As AVPControlJob In m_lstControlJob
                If (Job.IsReturnFreeJob AndAlso Job.IsAnyRunningProcessJob()) Then
                    Return True
                End If
            Next
            Return False
        End Function
        Protected Overrides Sub OnDoWork()
            AVPLib.Log.schedulerLogger.Info("Enter OnDoWork")
            AVPLib.Log.schedulerLogger.Debug("A THREAD FOR JOB MANAGER IS COMING ALIVE.")
            Try
                Const sleep_At_Startup As Integer = 20000
                If (SleepButAlertabletoTerminateRequest(sleep_At_Startup)) Then
                    Exit Sub
                End If

                ' LLA
                Dim objLLA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())

                Dim objLLAPumpPackageCtrl As Business.PumpPackageController = Nothing
                If RobotConfigurationValues.LLA_CRYO_VISIBLE OrElse RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                    objLLAPumpPackageCtrl = Business.ControllerManager.GetController(ConstEnum.Equipments.LLAPumpPackage.ToString())
                End If
                Dim blLLACommOK As Boolean = True
                Dim blLLATurboOK As Boolean = True
                Dim blLLAVacSwitchOK As Boolean = True
                Dim blLLATurboCGRelayOK As Boolean = True
                Dim blLLARelayMPOK As Boolean = True


                Dim objLLAController As LoadLockController = ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString())
                ' TM
                Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())

                Dim objTMPumpPackageCtrl As Business.PumpPackageController = Nothing
                If RobotConfigurationValues.TMCRYO_VISIBLE OrElse RobotConfigurationValues.TMTURBO_VISIBLE Then
                    objTMPumpPackageCtrl = Business.ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString())
                End If
                Dim blTMCommOK As Boolean = True
                Dim blTMTurboOK As Boolean = True
                Dim blTMVacSwitchOK As Boolean = True
                Dim blTMTurboCGRelayOK As Boolean = True
                Dim blTMRelayMPOK As Boolean = True

                Dim objTMController As TMController = ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString())
                ' PMx
                Dim objPM1 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
                Dim PM1Controller As ChamberController = ControllerManager.GetController(ConstEnum.Equipments.Chamber1.ToString())
                Dim objPM2 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
                Dim PM2Controller As ChamberController = ControllerManager.GetController(ConstEnum.Equipments.Chamber2.ToString())
                Dim objPM3 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
                Dim PM3Controller As ChamberController = ControllerManager.GetController(ConstEnum.Equipments.Chamber3.ToString())

                ' MAIN LOOP PROCESSING.
                While (False = HasTerminateRequest())
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                    If (awokenByTerminate) Then
                        Exit While
                    End If
                    ' SCHEDULER ALGORITHM'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' JobProcessAlgo
                    ' We support the two processing order: Serial = PROCESSING_ORDER_LIST
                    ' and Parallel = PROCESSING_ORDER_OPTIMIZATION
                    Dim noOfCtrlJobs As Integer = m_lstControlJob.Count

                    ' Turn On Green light, turn off Yellow light appropriately
                    If noOfCtrlJobs > 0 Then
                        Utils.TurnOffSystem_Light(False)
                    Else
                        '0006118: [KhoiHa- 12-08-2014]Everything (PM, LL) is IDLE, but Green Light is blinking===>should be Yellow 
                        Utils.TurnOffSystem_Light(True)
                        'End --------------------------
                    End If

                    Dim canStartNextControlJob As Boolean = True
                    Dim idx As Integer = 0
                    Dim bOnlyOneCJRunning As Boolean = IIf(noOfCtrlJobs <= 1, True, False)

                    'if run order -> not sort
                    If (m_iCJProcessingOrder) Then
                        'Dat Cao take turn LLA/LLB -> LLB/LLA 
                        SortControlJob(m_lstControlJob)
                    End If

                    For idx = 0 To noOfCtrlJobs - 1
                        Dim stoppingCtrlJob As AVPControlJob = Nothing
                        If GetNoOfCtrlJobs(ConstEnum.CJSTATE_MACHINES.Selected.ToString()) > 0 Then
                            stoppingCtrlJob = GetFirstCtrlJob(idx, ConstEnum.CJSTATE_MACHINES.Selected.ToString())
                            If (stoppingCtrlJob IsNot Nothing) AndAlso (stoppingCtrlJob.CheckForMaterialAvailable()) Then
                                stoppingCtrlJob.MakeWaitingToStart()
                            End If
                            stoppingCtrlJob = Nothing
                        ElseIf GetNoOfCtrlJobs(ConstEnum.CJSTATE_MACHINES.Executing.ToString()) > 0 Then

                            If (m_iCJProcessingOrder = ConstEnum.PROCESSING_ORDER_LIST) AndAlso (Not canStartNextControlJob) Then

                                stoppingCtrlJob = GetFirstCtrlJob(idx, ConstEnum.CJSTATE_MACHINES.Executing.ToString())
                                If (stoppingCtrlJob IsNot Nothing AndAlso stoppingCtrlJob.CheckIfAllJobsDone = False) Then
                                    If stoppingCtrlJob.IsAnyPausedProcessJob() Then
                                        stoppingCtrlJob.RaiseCJProcessingStatusEvent(ConstEnum.CJSTATE_MACHINES.Paused.ToString())
                                    Else
                                        stoppingCtrlJob.RaiseCJProcessingStatusEvent(ConstEnum.CJSTATE_MACHINES.Executing.ToString())
                                    End If
                                End If

                                GoTo CHECK_SAFETY_INTERLOCK_DURING_PROCESS
                            End If

                            stoppingCtrlJob = GetFirstCtrlJob(idx, ConstEnum.CJSTATE_MACHINES.Executing.ToString())
                            If (stoppingCtrlJob IsNot Nothing) Then

                                ' Scheduler.  LLA/LLB takes turn to run.
                                Dim TmpPJProcessingOrder As Integer = m_iPJProcessingOrder
                                If (Not bOnlyOneCJRunning) And IsAllCJInCycleMode() Then
                                    TmpPJProcessingOrder = ConstEnum.PROCESSING_ORDER_LIST
                                End If

                                'If (bOnlyOneCJRunning = False) Then
                                '    GoTo CHECK_SAFETY_INTERLOCK_DURING_PROCESS
                                'End If

                                'if Aligner is BUSY or ERROR or Nothing
                                'Aligner in LLA or LLB? 
                                'Manual transfer -> check on GUI layfer
                                'if Aborting ->
                                If (stoppingCtrlJob.IsAutoTransferJob() AndAlso CheckAlinerCurrentInUse() = True) Then
                                    'if LLA and pjob in LLA
                                    If (stoppingCtrlJob.IsAbortInProcess = False) Then
                                        If (AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = 1 And _
                                       stoppingCtrlJob.LoadlockName = "LoadLockA") Then
                                            AVPLib.Log.schedulerLogger.Debug("Aliner is current in used, cannot start more process job.")
                                            Continue For
                                        End If
                                    End If
                                    'DAT CAO ADD FOR CLEAR ALL WAFER 
                                    'RETURN FREE JOB ONLY PROCESSING ORDER SO:
                                    'WHEN AN JOB IS RUNNING THEN -> DO NOT SELECT ANY JOB FOR RUNNING
                                ElseIf (stoppingCtrlJob.IsReturnFreeJob AndAlso isAnyReturnFreeJobRunning()) Then
                                    Exit For
                                End If

                                'DAT CAO ADD FOR RUN CYCLE WAFER UNTIL MODE
                                'IF FULL CYCLE -> STOP
                                'IF FICK FULL WAFER -> DONOT CONTINUE TO PICK WAFER
                                'ELSE CONTINUE TO PICK IN NOMAL CASE
                                If (stoppingCtrlJob IsNot Nothing AndAlso _
                                stoppingCtrlJob.IsContinuousJob()) Then
                                    'full cycle process = cycle until mode
                                    'processed full cycle
                                    If (stoppingCtrlJob.IsFullCycleProcess) Then
                                        'if existed job are running 
                                        If (Not stoppingCtrlJob.IsAnyRunningProcessJob) Then
                                            'full cycle -> raise complete event
                                            stoppingCtrlJob.OnJobCompleteProc()
                                            If DequeueJob(stoppingCtrlJob) Then
                                                idx -= 1
                                                'idx = IIf(idx < 0, 0, idx)
                                            End If
                                            Continue For
                                        Else
                                            'do not complete job
                                            'wait for other processing completed
                                            Continue For
                                        End If

                                        'not full cycle 
                                    ElseIf (stoppingCtrlJob.IsPickFullWaferInCycleUntilMode) Then
                                        '
                                        If (stoppingCtrlJob.CheckIfAllJobsAborted()) Then
                                            AVPLib.Log.schedulerLogger.Debug("Aborted job...!")
                                            stoppingCtrlJob.OnAbortJob()

                                            If DequeueJob(stoppingCtrlJob) Then
                                                idx -= 1
                                                'idx = IIf(idx < 0, 0, idx)
                                            End If
                                        Else
                                            'do not complete job
                                            'wait for other processing completed
                                            Continue For
                                        End If

                                    End If
                                End If

                                ''' when able get next PJ in the LoadLock
                                Dim nextProcJobToStart As AVPProcessJob = stoppingCtrlJob.GetNextProcJob(TmpPJProcessingOrder)
                                '----------------------------------------
                                Dim bCheckIfAnyPJPaused As Boolean = True
                                '----------------------------------------

                                If (nextProcJobToStart Is Nothing) Then
                                    If (stoppingCtrlJob.CheckIfAllJobsDone()) Then
                                        '-------------------------------
                                        bCheckIfAnyPJPaused = False
                                        '-------------------------------
                                        If (stoppingCtrlJob.CheckIfAllJobsAborted()) Then
                                            AVPLib.Log.schedulerLogger.Debug("Aborted job...!")
                                            stoppingCtrlJob.OnAbortJob()

                                            If DequeueJob(stoppingCtrlJob) Then
                                                idx -= 1
                                                'idx = IIf(idx < 0, 0, idx)
                                            End If
                                        Else
                                            AVPLib.Log.schedulerLogger.Debug("All jobs are done...!")
                                            If (stoppingCtrlJob.IsContinuousJob()) Then

                                                If (stoppingCtrlJob.IsFullCycleProcess) Then

                                                    'if existed job are running 
                                                    If (Not stoppingCtrlJob.IsAnyRunningProcessJob) Then
                                                        stoppingCtrlJob.OnJobCompleteProc()
                                                        If DequeueJob(stoppingCtrlJob) Then
                                                            idx -= 1
                                                            'idx = IIf(idx < 0, 0, idx)
                                                        End If
                                                    Else
                                                        'do not complete job
                                                        'wait for other processing completed
                                                        Continue For
                                                    End If

                                                Else
                                                    stoppingCtrlJob.StartNewCycle()
                                                    'Cjprocessing_order = 0.   
                                                    'In this mode,  it only cycle one Llx.   '
                                                    'Example, if 2 Llx is cycling,  '
                                                    'LLA runs but LLB just sit and wait.   '
                                                    'In this mode,  it should complete LLA and then run LLB.
                                                    'solution :remove first job on job queue and push this job to end of job queue

                                                    If (m_lstControlJob IsNot Nothing AndAlso m_lstControlJob.Count > 1) Then
                                                        m_lstControlJob.Remove(stoppingCtrlJob)
                                                        m_lstControlJob.Add(stoppingCtrlJob)
                                                    End If

                                                    If stoppingCtrlJob.ListOfProcessJob.Count = 0 AndAlso DequeueJob(stoppingCtrlJob) Then
                                                        idx -= 1
                                                        'idx = IIf(idx < 0, 0, idx)
                                                    End If

                                                End If
                                            Else
                                                AVPLib.Log.schedulerLogger.Debug("Completed job...!")
                                                stoppingCtrlJob.OnJobCompleteProc()
                                                If DequeueJob(stoppingCtrlJob) Then
                                                    idx -= 1
                                                    'idx = IIf(idx < 0, 0, idx)
                                                End If
                                            End If
                                        End If
                                    End If
                                Else
                                    nextProcJobToStart.MakeWaitingForStart()

                                    If (m_iPJProcessingOrder And m_lstControlJob.Count > 1) Then
                                        'Dat Cao turn off all last active control job
                                        Dim cjTemp As AVPControlJob = Nothing
                                        For Each cjTemp In m_lstControlJob
                                            cjTemp.isLastActiveControlJob = False
                                        Next
                                        'turn on this job 
                                        'ONLY TAKE TURN TO RUN FOR AUTO TRANSFER JOB
                                        If (stoppingCtrlJob.IsAutoTransferJob) Then
                                            stoppingCtrlJob.isLastActiveControlJob() = True
                                        End If
                                    Else
                                        'turn on this mode wait other CJ  
                                        If (stoppingCtrlJob.IsAutoTransferJob) Then
                                            stoppingCtrlJob.isLastActiveControlJob() = True
                                        End If
                                    End If
                                End If
                                '-----------------------------------------------------------
                                'Change Button's text from Pause -> Resume if any PJ paused.
                                If (bCheckIfAnyPJPaused) Then
                                    If stoppingCtrlJob.IsAnyPausedProcessJob() Then
                                        stoppingCtrlJob.RaiseCJProcessingStatusEvent(ConstEnum.CJSTATE_MACHINES.Paused.ToString())
                                    Else
                                        stoppingCtrlJob.RaiseCJProcessingStatusEvent(ConstEnum.CJSTATE_MACHINES.Executing.ToString())
                                    End If
                                End If
                                '-----------------------------------------------------------
                                canStartNextControlJob = Me.CanStartNextControlJob
                            End If
                            stoppingCtrlJob = Nothing
                        End If
                        '
                        stoppingCtrlJob = GetStoppingCtrlJob(idx)
                        If (stoppingCtrlJob IsNot Nothing) AndAlso (Not stoppingCtrlJob.IsAbortInProcess) AndAlso (stoppingCtrlJob.CheckIfAllJobsStopped()) Then
                            AVPLib.Log.schedulerLogger.Debug("Stopped job...!")
                            stoppingCtrlJob.OnStopJob()
                            If DequeueJob(stoppingCtrlJob) Then
                                idx -= 1
                                'idx = IIf(idx < 0, 0, idx)
                            End If
                        End If
                        '
                        stoppingCtrlJob = GetAbortingCtrlJob(idx)
                        If (stoppingCtrlJob IsNot Nothing) AndAlso (stoppingCtrlJob.CheckIfAllJobsAborted()) Then
                            AVPLib.Log.schedulerLogger.Debug("Aborted job...!")
                            stoppingCtrlJob.OnAbortJob()
                            If DequeueJob(stoppingCtrlJob) Then
                                idx -= 1
                                'idx = IIf(idx < 0, 0, idx)
                            End If
                        End If
                        '
                        stoppingCtrlJob = GetPauseingCtrlJob(idx)
                        If (stoppingCtrlJob IsNot Nothing) _
                            AndAlso (stoppingCtrlJob.CheckIfAllJobsPaused()) _
                            AndAlso (ConstEnum.CJSTATE_MACHINES.Paused.ToString() <> stoppingCtrlJob.CurrentState) Then
                            AVPLib.Log.schedulerLogger.Debug("Paused job...!")
                            stoppingCtrlJob.OnPauseJob()
                        End If
                        stoppingCtrlJob = Nothing
                    Next idx
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
CHECK_SAFETY_INTERLOCK_DURING_PROCESS:

                    ' Monitor PMx connections.
                    If (objPM1 IsNot Nothing) AndAlso (PM1Controller IsNot Nothing) Then
                        If (objPM1.ConnectionStatus = DataManagerment.Equipment.WorkingStatuses.Off) AndAlso (objPM1.ControlStatus = DataManagerment.Equipment.ControlStatuses.ONLINE) Then
                            PM1Controller.RaiseFinishOnline(False)
                        End If
                    End If
                    If (objPM2 IsNot Nothing) AndAlso (PM2Controller IsNot Nothing) Then
                        If (objPM2.ConnectionStatus = DataManagerment.Equipment.WorkingStatuses.Off) AndAlso (objPM2.ControlStatus = DataManagerment.Equipment.ControlStatuses.ONLINE) Then
                            PM2Controller.RaiseFinishOnline(False)
                        End If
                    End If
                    If (objPM3 IsNot Nothing) AndAlso (PM3Controller IsNot Nothing) Then
                        If (objPM3.ConnectionStatus = DataManagerment.Equipment.WorkingStatuses.Off) AndAlso (objPM3.ControlStatus = DataManagerment.Equipment.ControlStatuses.ONLINE) Then
                            PM3Controller.RaiseFinishOnline(False)
                        End If
                    End If

                    'monitor elevator device
                    'if error -> stop LOAD/UNLOAD sequence
                    MonitorLLElevatorError(ConstEnum.Equipments.LoadLockA.ToString)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Const Fine_Tune_Sleep_Time As Integer = 1000
                    If (SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time)) Then
                        Exit While
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.schedulerLogger.Debug("A THREAD FOR JOB MANAGER IS EXITING.")
            AVPLib.Log.coreLogger.Info("Leave OnDoWork")
        End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-12</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Handle error while wafer are being processed
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CJCompletedEventHandler(ByVal sender As Object, ByVal eea As ProcessedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter CJCompletedEvent_processing")
            Try
                Utils.TurnOffSystem_Light(True)
                If Not eea.IsAutoTransfer Then
                    If (eea.IsReturnFreeJob) Then
                        Me.DecReturnFreeJobCount()
                        Exit Sub
                    Else
                        If eea.IsReturnForProcessCJ AndAlso m_iReturnFreeJobCount <= 0 Then
                            AVPLib.Utils.ShowFlashingText(String.Empty, False) ''clear flashing text
                        End If
                        Me.RaiseSemiTransferProcessing(eea.LoadlockName, "SEMI_TRANSFER_FINISH")
                    End If
                Else
                    Dim LL As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(eea.LoadlockName)
                    LL.StartStatus = AVPLib.DataManagerment.Equipment.ProcessStatuses.START
                    Me.RaiseProcessing(eea.LoadlockName, DataManagerment.Equipment.ProcessStatuses.START)

                    'Enable Button ClearAllWafer
                    'If ((eea.LoadlockName = ConstEnum.LoadLockA_STR AndAlso Not CheckExistControlJob(ConstEnum.LoadLockB_STR)) OrElse _
                    '(eea.LoadlockName = ConstEnum.LoadLockB_STR AndAlso Not CheckExistControlJob(ConstEnum.LoadLockA_STR))) Then
                    If (m_iReturnFreeJobCount = 0) Then
                        AVPLib.Utils.EnableDisableClearAllWaferButton(AVPLib.ConstEnum.STR_ON)
                    End If
                    'End If
                    AVPLib.Utils.ShowFlashingText(String.Empty, False)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CJCompletedEvent_processing")
        End Sub
        Public Sub CJProcessingStatusHandler(ByVal sender As Object, ByVal eea As CJProcessingStatusEventArgs)
            AVPLib.Log.coreLogger.Info("Enter CJProcessingStatusHandler")
            Try
                Dim LL As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(eea.LoadlockName)
                If (ConstEnum.CJSTATE_MACHINES.Paused.ToString() = eea.ProcessingStatus) Then
                    LL.StartStatus = AVPLib.DataManagerment.Equipment.ProcessStatuses.RESUME
                ElseIf (ConstEnum.CJSTATE_MACHINES.Executing.ToString() = eea.ProcessingStatus) Then
                    LL.StartStatus = AVPLib.DataManagerment.Equipment.ProcessStatuses.PAUSE
                End If

                Me.RaiseProcessing(eea.LoadlockName, LL.StartStatus)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CJProcessingStatusHandler")
        End Sub
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-12</date>
        ''' </author>
        ''' <summary>
        ''' Raise Processing
        ''' </summary>
        ''' <param name="Status"></param>
        ''' <remarks></remarks>
        Private Sub RaiseProcessing(ByVal strEquipmentName As String, ByVal Status As DataManagerment.Equipment.ProcessStatuses)
            AVPLib.Log.coreLogger.Info("Enter RaiseProcessing")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(Status)
                Dim PropertyNames As ArrayList = New ArrayList()
                Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(strEquipmentName)
                If objLoadLock IsNot Nothing AndAlso objLoadLock.IsCycleInATM_Mode Then
                    PropertyNames.Add("StartATMStatus")
                    AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), PropertyNames, ReplyValues)
                Else
                    PropertyNames.Add("StartStatus")
                    AVPLib.DataManagerment.EquipmentManager.ChangeStatus(strEquipmentName, PropertyNames, ReplyValues)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseProcessing")
        End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-12</date>
        ''' </author>
        ''' <summary>
        ''' Raise Processing
        ''' </summary>
        ''' <param name="Status"></param>
        ''' <remarks></remarks>
        Private Sub RaiseSemiTransferProcessing(ByVal strEquipmentName As String, ByVal Status As String)
            AVPLib.Log.coreLogger.Info("Enter RaiseSemiTransferProcessing")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(Status)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("SemiTransferStatus")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(strEquipmentName, PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseSemiTransferProcessing")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-05-04</date>
        ''' </author>
        ''' <summary>
        ''' Check Clear All wafer finished
        ''' </summary>
        ''' <param name="Status"></param>
        ''' <remarks></remarks>
        Public Function isAllReturnFreeJobInLoadLockFinished(ByVal strloadlockName As String) As Boolean
            If (m_lstControlJob Is Nothing) Then
                Return True
            Else
                Dim job As AVPControlJob = Nothing
                For Each job In m_lstControlJob
                    If (job.LoadlockName = strloadlockName) Then
                        If (job.IsAutoTransferJob = False AndAlso Not job.CheckIfAllJobsDone()) Then
                            Return False
                        End If
                    End If
                Next

                Return True
            End If
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-05-04</date>
        ''' </author>
        ''' <summary>
        ''' Raise Processing
        ''' </summary>
        ''' <param name="Status"></param>
        ''' <remarks></remarks>
        Public Function isAllJobInLoadLockFinished(ByVal strloadlockName As String) As Boolean
            If (m_lstControlJob Is Nothing) Then
                Return True
            Else
                Dim job As AVPControlJob = Nothing
                For Each job In m_lstControlJob
                    If (job.LoadlockName = strloadlockName) Then
                        If (Not job.CheckIfAllJobsDone()) Then
                            Return False
                        End If
                    End If
                Next
                'only true when all job by name strloadlockName is finished
                Return True
            End If
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-05-05</date>
        ''' </author>
        ''' <summary>
        ''' Raise Processing
        ''' </summary>
        ''' <param name="Status"></param>
        ''' <remarks></remarks>
        Public Function isAllJobFinished() As Boolean
            If (m_lstControlJob Is Nothing) Then
                Return True
            Else
                Dim job As AVPControlJob = Nothing
                For Each job In m_lstControlJob
                    If (job.CheckIfAllJobsDone() = False) Then
                        Return False
                    End If
                Next
                'only true when all job by name strloadlockName is finished
                Return True
            End If
        End Function
        ''' <author>
        '''    	<name> Dy Do </name>
        '''    	<date> 2015-05-05</date>
        ''' </author>
        ''' <summary>
        ''' Check All auto transfer job inloadlock is finished
        ''' </summary>
        ''' <param name="Status"></param>
        ''' <remarks></remarks>
        Public Function IsAllAutoTransferJobInLoadLockFinished(ByVal strloadlockName As String) As Boolean
            If (m_lstControlJob Is Nothing) Then
                Return True
            Else
                Dim job As AVPControlJob = Nothing
                For Each job In m_lstControlJob
                    If (job.LoadlockName = strloadlockName AndAlso job.IsAutoTransferJob AndAlso Not job.CheckIfAllJobsDone()) Then
                        Return False
                    End If
                Next
                'only true when all job by name strloadlockName is finished
                Return True
            End If
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-08-04</date>
        ''' </author>
        ''' <summary>
        ''' Increase Return Free Job
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub IncReturnFreeJobCount()
            m_iReturnFreeJobCount += 1
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-08-04</date>
        ''' </author>
        ''' <summary>
        ''' Decrease Return Free Job
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub DecReturnFreeJobCount()
            m_iReturnFreeJobCount -= 1
            RaiseReturnFreeJobCompleted()
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-08-04</date>
        ''' </author>
        ''' <summary>
        ''' Check LL control job existed
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CheckExistControlJob(ByVal LoadLockName As String) As Boolean
            Try
                Dim objLoadLockCtrl As LoadLockController = _
                            AVPLib.Business.ControllerManager.GetController(LoadLockName)

                If (objLoadLockCtrl Is Nothing) Then
                    Return False
                End If

                Dim objavpCtrlJob As AVPControlJob = GetControlJob(objLoadLockCtrl.CtrlJobId)
                If (objavpCtrlJob IsNot Nothing) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Info(ex.Message)
            End Try
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-08-04</date>
        ''' </author>
        ''' <summary>
        ''' Abort all return free job when one return free job is error
        ''' </summary>
        ''' <remarks></remarks>
        Public Function AbortAllReturnFreeJob() As Boolean
            Dim Result As Boolean = False
            If (m_lstControlJob Is Nothing) Then
                Return Result
            Else
                Dim job As AVPControlJob = Nothing
                For Each job In m_lstControlJob
                    If (job.IsReturnFreeJob AndAlso Not job.CheckIfAllJobsDone()) Then
                        Result = Result And job.JobAbort()
                    End If
                Next
                Return Result
            End If
        End Function

        Public Sub RaiseReturnFreeJobCompleted()
            Try
                If (m_iReturnFreeJobCount <= 0) Then
                    AVPLib.Utils.ShowStatusMessage("Return All Wafers Completed")
                    AVPLib.Utils.ShowFlashingText(String.Empty, False) ''clear flashing text
                    AVPLib.Utils.EnableDisableClearAllWaferButton(AVPLib.ConstEnum.STR_ON)
                    'enable LLA
                    Dim LLA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.LoadLockA_STR)
                    If (LLA IsNot Nothing) Then
                        LLA.StartStatus = AVPLib.DataManagerment.Equipment.ProcessStatuses.START
                        Me.RaiseProcessing(ConstEnum.LoadLockA_STR, DataManagerment.Equipment.ProcessStatuses.START)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Info(ex.Message)
            End Try
        End Sub

        Private Function getElevator(ByVal sLLName As String) As LLElevator
            Dim objLLElevator As LLElevator = Nothing
            Try
                If sLLName = ConstEnum.Equipments.LoadLockA.ToString() Then
                    objLLElevator = EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Info(ex.Message)
            End Try
            Return objLLElevator
        End Function


        Private Sub MonitorLLElevatorError(ByVal sLLName As String)
            Try
                Dim objLoadlockController As LoadLockController = ControllerManager.GetController(sLLName)
                Dim objLoadlock As LoadLock = DataManagerment.EquipmentManager.GetEquipment(sLLName)

                'check loadlock elevator error received
                If (objLoadlock IsNot Nothing AndAlso objLoadlock.LoadStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    Dim objLLElevator As LLElevator = getElevator(sLLName)

                    'has error 
                    If (objLLElevator IsNot Nothing AndAlso objLLElevator.IsHwErrorReceived) Then
                        'abort LOAD
                        If (objLoadlockController IsNot Nothing) Then
                            objLoadlockController.StopLoad()
                        End If
                    End If
                End If

                'check loadlock elevator error received
                If (objLoadlock IsNot Nothing AndAlso objLoadlock.UnloadStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                    Dim objLLElevator As LLElevator = getElevator(sLLName)

                    'has error 
                    If (objLLElevator IsNot Nothing AndAlso objLLElevator.IsHwErrorReceived) Then
                        'abort LOAD
                        If (objLoadlockController IsNot Nothing) Then
                            objLoadlockController.StopUnLoad()
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Info(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
