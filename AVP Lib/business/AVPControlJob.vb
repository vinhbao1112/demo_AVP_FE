Imports AVPLib.DataManagerment
Imports System.Threading
Imports System.Text.RegularExpressions
Namespace Business

    Public Class CJProcessingStatusEventArgs
        Inherits EventArgs
#Region "Class Constants & Variables"
        Private m_strProcessingStatus As String
        Private m_strLoadlockName As String
#End Region

        Public Sub New(ByVal loadLockName As String, ByVal processingStatus As String)
            m_strLoadlockName = loadLockName
            m_strProcessingStatus = processingStatus
        End Sub

        ''' <author>
        '''    	<name>Do Xuan Dat</name>
        '''    	<date> 2009-11-09</date>
        ''' </author>
        ''' <summary>
        ''' Get or set The LoadLock message
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LoadlockName() As String
            Get
                Return m_strLoadlockName
            End Get
            Set(ByVal value As String)
                m_strLoadlockName = value
            End Set
        End Property

        ''' <author>
        '''    	<name>Do Xuan Dat</name>
        '''    	<date> 2009-11-09</date>
        ''' </author>
        ''' <summary>
        ''' Get or set The error message
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ProcessingStatus() As String
            Get
                Return m_strProcessingStatus
            End Get
            Set(ByVal value As String)
                m_strProcessingStatus = value
            End Set
        End Property
    End Class

    Public Class AVPControlJob
        Inherits AVPJob

        Class ReverseIterator
            Implements IEnumerable

            ' a low-overhead ArrayList to store references
            Dim items As New ArrayList()

            Sub New(ByVal collection As IEnumerable)
                ' load all the items in the ArrayList, but in reverse order
                Dim o As Object
                For Each o In collection
                    items.Insert(0, o)
                Next
            End Sub

            Public Function GetEnumerator() As System.Collections.IEnumerator _
                Implements System.Collections.IEnumerable.GetEnumerator
                ' return the enumerator of the inner ArrayList
                Return items.GetEnumerator()
            End Function
        End Class

#Region "Variables and Properties"
        Private m_JobManager As AVPJobManager = Nothing
        Private m_iNumberOfUncompletedPJ As Integer
        Private m_lstProcessJob As List(Of AVPProcessJob) = New List(Of AVPProcessJob)
        Private m_strLoadLockName As String = String.Empty
        Private m_strLotID As String = String.Empty

        Private m_strSequenceID As String = String.Empty
        Private m_lstSequenceInfor As ArrayList = New ArrayList

        ' The Index of the control job that is running.
        Private m_iCurrentRunIdx As Integer
        Private m_bLastRunIdxInProcess As Boolean

        Private m_pauseInProcess As Boolean
        Private m_stopInProcess As Boolean
        Private m_abortInProcess As Boolean

        Private m_strManualTransferCmd As String = String.Empty
        Private m_isReturnForProcessCJ As Boolean

        'When PJ Completed processing for the SemiTransfer or Auto Transfer
        Public Event CJTransferCompletedEvent(ByVal sender As Object, ByVal pea As ProcessedEventArgs)
        Public Event CJProcessingStatusEvent(ByVal sender As Object, ByVal processingStatusEvnt As CJProcessingStatusEventArgs)

        Private m_blIsContinuousJob As Boolean = False
        Private m_blIsAutoTransferJob As Boolean = True
        Private m_blRunWithRecipe As Boolean = True
        Private m_blCycleInATMMode As Boolean = False
        'Dat Cao add this variable to control order ControlJob
        Private m_isLastActiveControlJob As Boolean
        Private m_isReturnFreeJob As Boolean
        Private m_isGEMPauseJob As Boolean = False

        Private m_IsLeastOneProcessJobFinished As Boolean = False

        Private m_listOfWaferIDIsHandled As List(Of String)

        'USED TO CYCLE UNTILL MODE
        'Cycle Count = wafer completed in cycle until mode
        Private m_CycleCount As UInt16 = 0
        'max cycle count = run until cycle count = max cycle count
        Private m_MaxCycleCount As UInt16 = 0
        'cycle until mode or not
        Private m_IsRunCylceUntilMode As Boolean = False
        'pick full wafer but not complete all wafer
        'must be wait untill all wafer is completed
        Private m_IsPickFullWaferInCycleUntilMode As Boolean = False
        'pick wafer count when pick a wafer from loadlock
        Private m_PickWaferCount As Int16 = 0

        'Start new job but all job is finished
        ' or have empty job in list job
        'when one process job completed - > set variable = true
        'when finish CJ -> check this varialbe to do vent 
        Public Property IsLeastOneProcessJobFinished() As Boolean
            Get
                Return m_IsLeastOneProcessJobFinished
            End Get
            Set(ByVal value As Boolean)
                m_IsLeastOneProcessJobFinished = value
            End Set
        End Property

        Public Property CycleCount() As UInt16
            Get
                Return m_CycleCount
            End Get
            Set(ByVal value As UInt16)
                m_CycleCount = value
            End Set
        End Property

        Public Property PickWaferCount() As UInt16
            Get
                Return m_PickWaferCount
            End Get
            Set(ByVal value As UInt16)
                m_PickWaferCount = value
            End Set
        End Property

        Public Property IsPickFullWaferInCycleUntilMode() As Boolean
            Get
                Return m_IsPickFullWaferInCycleUntilMode
            End Get
            Set(ByVal value As Boolean)
                m_IsPickFullWaferInCycleUntilMode = value
            End Set
        End Property
        Public Property MaxCycleCount() As UInt16
            Get
                Return m_MaxCycleCount
            End Get
            Set(ByVal value As UInt16)
                m_MaxCycleCount = value
                If (m_MaxCycleCount > 0) Then
                    IsRunCylceUntilMode = True
                    m_IsPickFullWaferInCycleUntilMode = (m_PickWaferCount >= m_MaxCycleCount)
                Else
                    IsRunCylceUntilMode = False
                    m_IsPickFullWaferInCycleUntilMode = False
                End If
            End Set
        End Property
        Public Property IsRunCylceUntilMode() As Boolean
            Get
                Return m_IsRunCylceUntilMode
            End Get
            Set(ByVal value As Boolean)
                m_IsRunCylceUntilMode = value
            End Set
        End Property

        Public Property IsGEMPauseJob() As Boolean
            Get
                Return m_isGEMPauseJob
            End Get
            Set(ByVal value As Boolean)
                m_isGEMPauseJob = value
            End Set
        End Property

        Public Property isLastActiveControlJob() As Boolean
            Get
                Return m_isLastActiveControlJob
            End Get
            Set(ByVal value As Boolean)
                m_isLastActiveControlJob = value
            End Set
        End Property
        Public Property RunWithRecipe() As Boolean
            Get
                Return m_blRunWithRecipe
            End Get
            Set(ByVal value As Boolean)
                m_blRunWithRecipe = value
            End Set
        End Property
        Public Property IsReturnFreeJob() As Boolean
            Get
                Return m_isReturnFreeJob
            End Get
            Set(ByVal value As Boolean)
                m_isReturnFreeJob = value
            End Set
        End Property
        Public Property IsAutoTransferJob() As Boolean
            Get
                Return m_blIsAutoTransferJob
            End Get
            Set(ByVal value As Boolean)
                m_blIsAutoTransferJob = value
            End Set
        End Property
        Public ReadOnly Property LotId() As String
            Get
                Return m_strLotID
            End Get
        End Property
        Public ReadOnly Property SequenceID() As String
            Get
                Return m_strSequenceID
            End Get
        End Property
        Public Property LoadlockName() As String
            Get
                Return m_strLoadLockName
            End Get
            Set(ByVal value As String)
                m_strLoadLockName = value
            End Set
        End Property

        ''' <author> Dua Tran </author>
        ''' <date> 2021-11-26 </date>
        ''' <summary>
        ''' Gets or Sets IsReturnForProcessCJ
        ''' </summary>
        Public Property IsReturnForProcessCJ() As Boolean
            Get
                Return m_isReturnForProcessCJ
            End Get
            Set(ByVal value As Boolean)
                m_isReturnForProcessCJ = value
            End Set
        End Property

        Sub New(ByVal strLoadLockName As String, ByVal strLotID As String, _
                ByVal strSequenceID As String, ByVal strCtrlJobId As String, _
                ByVal bIsContinuousJob As Boolean, ByVal bRuntWithRecipe As Boolean, _
                ByVal bCycleInATMMode As Boolean, Optional ByVal iMaxCycleCount As Integer = 0)
            MyBase.New(strCtrlJobId, JobTypeEnum.ControlJob)
            m_strLoadLockName = strLoadLockName
            m_strLotID = strLotID
            m_strSequenceID = strSequenceID
            ObjectID = strLoadLockName
            m_strManualTransferCmd = String.Empty
            '
            m_blIsContinuousJob = bIsContinuousJob
            m_blRunWithRecipe = bRuntWithRecipe
            If (Not m_blIsContinuousJob) Then
                m_blRunWithRecipe = True
            End If
            m_blCycleInATMMode = bCycleInATMMode
            m_isLastActiveControlJob = False

            If (iMaxCycleCount = 0) Then
                m_IsRunCylceUntilMode = False
            Else
                m_IsRunCylceUntilMode = True
            End If
            m_MaxCycleCount = iMaxCycleCount

            'Lot Data log
            If (strLoadLockName = ConstEnum.LoadLockA_STR) Then
                AVPLotDatalog.LLALotDatalogStart(m_strLotID)
            End If
            AVPLotDatalog.AddLotDatalog(m_strLoadLockName, LogType.Info, "LotID: " & m_strLotID, m_blIsAutoTransferJob)
            AVPLotDatalog.AddLotDatalog(m_strLoadLockName, LogType.Info, "SequenceID: " & m_strSequenceID, m_blIsAutoTransferJob)
            AVPLotDatalog.AddLotDatalog(m_strLoadLockName, LogType.Info, "LoadLock: " & strLoadLockName, m_blIsAutoTransferJob)

            If ContainerDAO.EnableRunNo Then
                AVPLotDatalog.AddLotDatalog(m_strLoadLockName, LogType.Info, "Run No.: " & RobotConfigurationValues.RUN_SCHEDULER_NO, m_blIsAutoTransferJob)
            End If


            If m_blIsContinuousJob Then
                If m_IsRunCylceUntilMode Then
                    AVPLotDatalog.AddLotDatalog(m_strLoadLockName, LogType.Info, String.Format("Process is preparing to run cycle ({0}) wafers.", m_MaxCycleCount), m_blIsAutoTransferJob)
                Else
                    AVPLotDatalog.AddLotDatalog(m_strLoadLockName, LogType.Info, "Process is preparing to run cycle wafers.", m_blIsAutoTransferJob)
                End If
            End If

            RefreshLotDatalog()

            AVPLib.Log.schedulerLogger.Debug("AUTO CJ-" & JobID & " CREATED.")
        End Sub

        Sub New(ByVal strCommand As String, ByVal strCtrlJobId As String)
            MyBase.New(strCtrlJobId, JobTypeEnum.ControlJob)
            m_strManualTransferCmd = strCommand
            m_blIsAutoTransferJob = False
            m_isReturnForProcessCJ = True
            AVPLib.Log.schedulerLogger.Debug("MANUAL CJ-" & JobID & " CREATED WITH SEQUENCE=" & strCommand)
        End Sub

        Sub New(ByVal strCommand As String, ByVal strCtrlJobId As String, ByVal blReturnFreeJob As Boolean)
            MyBase.New(strCtrlJobId, JobTypeEnum.ControlJob)
            m_strManualTransferCmd = strCommand
            m_blIsAutoTransferJob = False
            m_isReturnForProcessCJ = False
            m_isReturnFreeJob = blReturnFreeJob
            AVPLib.Log.schedulerLogger.Debug("MANUAL CJ-" & JobID & " CREATED WITH SEQUENCE=" & strCommand)
        End Sub

        Public ReadOnly Property ListOfProcessJob() As List(Of AVPProcessJob)
            Get
                Return m_lstProcessJob
            End Get
        End Property

        Public Property JobManager() As AVPJobManager
            Get
                Return m_JobManager
            End Get
            Set(ByVal value As AVPJobManager)
                m_JobManager = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-02 </date>
        ''' </author>
        ''' <summary>
        ''' the thread proc for Control Job.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function JobPause() As Boolean
            If (IsStopInProcess) Then
                AVPLib.Log.schedulerLogger.Debug("Job is stopping, cannot pause.")
                Return False
            End If
            If IsPauseInProcess Then
                AVPLib.Log.schedulerLogger.Debug("Pause in process, please wait.")
                Return False
            End If
            m_pauseInProcess = True
            SyncLock m_lstProcessJob
                ' for each process job, do Pause
                For Each job As AVPProcessJob In m_lstProcessJob
                    If job.IsRunning() Then
                        job.JobPause()
                    End If
                Next
            End SyncLock
            Return True
        End Function
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-02 </date>
        ''' </author>
        ''' <summary>
        ''' the thread proc for Control Job.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsPaused() As Boolean
            Return (CurrentState = ConstEnum.PJSTATE_MACHINES.Paused.ToString())
        End Function

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-02 </date>
        ''' </author>
        ''' <summary>
        ''' the thread proc for Control Job.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function JobResume() As Boolean
            If (IsStopInProcess) Then
                AVPLib.Log.schedulerLogger.Debug("Job is stopping, cannot resume.")
                Return False
            End If
            If (Not IsPaused()) Then
                If Not IsAnyPausedProcessJob() Then
                    AVPLib.Log.schedulerLogger.Debug("Job needs to be in Paused state to resume.")
                    Return False
                End If
            End If
            SyncLock m_lstProcessJob
                ' for each process job, do Resume
                For Each job As AVPProcessJob In m_lstProcessJob
                    If (job.IsPaused()) Then
                        job.JobResume()
                    End If
                Next
            End SyncLock
            'MyBase.JobResume()
            ChangeState(ConstEnum.CJSTATE_MACHINES.Executing.ToString())
            m_pauseInProcess = False
            Return True
        End Function
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-02 </date>
        ''' </author>
        ''' <summary>
        ''' the thread proc for Control Job.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function JobStart() As Boolean
            If IsStopInProcess Then
                Return False
            End If
            AVPLib.Log.schedulerLogger.Debug("CTRLJOB-" & JobID & " IS BEING STARTED.")
            ChangeState(ConstEnum.CJSTATE_MACHINES.Executing.ToString())
            Dim job As AVPProcessJob
            For Each job In m_lstProcessJob
                job.ChangeStatePJ(ConstEnum.PJSTATE_MACHINES.SettingUp.ToString())
            Next
            Return True
        End Function

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-02 </date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function JobStop() As Boolean
            If IsStopInProcess Then
                AVPLib.Log.schedulerLogger.Debug("Stop in process, please wait.")
                Return False
            End If
            AVPLib.Log.schedulerLogger.Debug("CTRLJOB-" & JobID & " IS BEING STOPPED.")
            m_stopInProcess = True
            SyncLock m_lstProcessJob
                ' for each process job, do stop.
                For Each job As AVPProcessJob In m_lstProcessJob
                    If job.IsRunning() Then
                        job.JobStop()
                    End If
                Next
            End SyncLock
            Return True
        End Function

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-02 </date>
        ''' </author>
        ''' <summary>
        ''' the thread proc for Control Job.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function JobAbort(Optional ByVal blReturnWafer As Boolean = False) As Boolean
            If (IsAbortInProcess) Then
                AVPLib.Log.schedulerLogger.Debug("Abort in process, please wait.")
            End If
            AVPLib.Log.schedulerLogger.Debug("CTRLJOB-" & JobID & " IS BEING ABORTED, RETURN_WAFER=" & blReturnWafer.ToString())
            m_abortInProcess = True
            SyncLock m_lstProcessJob
                ' for each process job, do abort
                For Each job As AVPProcessJob In m_lstProcessJob
                    job.JobAbort(blReturnWafer)
                Next
            End SyncLock
            Return True
        End Function

        Public Sub ForceAbortJob()
            m_abortInProcess = True
            SyncLock m_lstProcessJob
                For Each job As AVPProcessJob In m_lstProcessJob
                    Try
                        job.JobAbort()
                        If Not job.Join(7000) Then
                            job.Interrupt()
                            If Not job.Join(5000) Then
                                job.Abort()
                                If Not job.Join(3000) Then
                                    ' If failed to join, sleep till it dies
                                    job.Join()
                                End If
                            End If
                            job.OnAbortJob()
                        End If
                    Catch ex As Exception
                        AVPLib.Log.avpLogger.Error(ex.ToString())
                    End Try
                Next
            End SyncLock
            RaiseCJTransferCompletedEvent()
            ChangeState(ConstEnum.CJSTATE_MACHINES.Completed.ToString())
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2014-02-06 </date>
        ''' </author>
        ''' <summary>

        ''' Abort All batch process job
        ''' batchid = batch group id
        ''' JobID = job call mark for return

        ''' support for batch process mode
        ''' one of wafer (aligner or robot) are mark for return -> all wafer on batch must mark for return
        ''' do not return call mark for return for JobID because this job already call aborted

        ''' </summary>
        ''' <remarks></remarks>
        Public Function BatchMarkForReturn(ByVal batchID As Integer) As Boolean

            Try

                SyncLock m_lstProcessJob
                    ' for each process job, do abort
                    For Each job As AVPProcessJob In m_lstProcessJob

                        If (job.BatchProcessJobGroupIdx = batchID AndAlso _
                            (job.IsPaused OrElse job.IsRunning OrElse job.IsSettingUp) AndAlso _
                            (Not job.AbortInProcess) AndAlso _
                            (Not job.StopInProcess)) Then

                            job.JobAbort(True)
                            job.SequenceInfor.WaferInfo.WaferStatus = ConstEnum.enumWaferStatus.eWaferError
                            Log.coreLogger.Error("JobID:" & job.JobID & " prepare for Mark For Return")
                        End If

                    Next
                End SyncLock

            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try

        End Function
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-02 </date>
        ''' </author>
        ''' <summary>
        ''' the thread proc for Control Job.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function TerminateAllAbortJob() As Boolean
            If (IsAbortInProcess) Then
                SyncLock m_lstProcessJob
                    ' for each process job, do abort
                    For Each job As AVPProcessJob In m_lstProcessJob
                        If (job.AbortInProcess AndAlso job.ReturnWafer) Then
                            job.ReturnWafer = False
                        End If
                    Next
                End SyncLock
                Return True
            End If
            Return False
        End Function

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' get number of uncompleted of PJ
        ''' </summary>
        ''' <remarks></remarks>
        Public Property NumberOfUncompletedPJ() As Integer
            Get
                Return m_iNumberOfUncompletedPJ
            End Get
            Set(ByVal value As Integer)
                m_iNumberOfUncompletedPJ = value
            End Set
        End Property

#End Region

#Region "public method"

        Public Sub Initialize()
            AVPLib.Log.schedulerLogger.Info("Enter Initialize")
            'Create the state machine
            CurrentState = ConstEnum.STATE_MACHINE_NO_STATE.ToString()
            PreviousState = ConstEnum.STATE_MACHINE_NO_STATE.ToString
            If m_strManualTransferCmd <> String.Empty Then
                InitializeSemiTransfer(m_strManualTransferCmd)
            Else
                InitializeAutoTransfer()
            End If
        End Sub

        Public Sub InitializeAutoTransfer()
            AVPLib.Log.schedulerLogger.Info("Enter InitializeAutoTransfer")
            Try
                ' The index of process job that will be running.
                m_iCurrentRunIdx = -1
                m_bLastRunIdxInProcess = False
                m_abortInProcess = False
                m_pauseInProcess = False
                m_stopInProcess = False

                '
                Dim objLoadLock As LoadLock = CType(EquipmentManager.GetEquipment(m_strLoadLockName), LoadLock)
                Dim arrSlotsStatus As Integer() = objLoadLock.Elevator.SlotStatus

                Dim wfSequence As AVPLib.DBWaferList = Nothing
                Dim strSequenceDescription As String = Nothing
                Dim WaferListInOrder As ReverseIterator = Nothing

                If (Not String.IsNullOrEmpty(m_strSequenceID)) Then
                    If Not AVPLib.ContainerData.GetSequence(ContainerDAO.FPath_SequenceData & "\" & Utils.GetFileName(m_strSequenceID, "xml"), _
                            wfSequence, strSequenceDescription) Then
                        AVPLib.Log.avpLogger.Error("Failed to load Ctrl Job - " & ContainerDAO.FPath_SequenceData & "\" & Utils.GetFileName(m_strSequenceID, "xml"))
                        Return
                    End If
                    WaferListInOrder = New ReverseIterator(wfSequence.WaferList)
                End If

                'For Each SequenceSlot As AVPLib.DBWaferSlot In (IIf(WaferListInOrder Is Nothing, wfSequence.WaferList, WaferListInOrder))
                For Each SequenceSlot As AVPLib.DBWaferSlot In wfSequence.WaferList
                    If (SequenceSlot.WaferSequence.SeqStepList.Count > 0) Then
                        Dim iSlotNo As Integer = CInt(SequenceSlot.Slot)
                        If iSlotNo <= arrSlotsStatus.Length AndAlso (arrSlotsStatus(iSlotNo - 1) = ConstEnum.SlotStatuses.Available) Then
                            Dim objLLElevator As LLElevator = Nothing
                            If m_strLoadLockName = ConstEnum.Equipments.LoadLockA.ToString() Then
                                objLLElevator = EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                            End If
                            ' Generate wafer information
                            Dim waferinfo As AVPWaferInfo = objLLElevator.ListOfWaferInfo(iSlotNo - 1)
                            If (waferinfo IsNot Nothing) Then
                                If IsContinuousJob Then
                                    If waferinfo.WaferStatus <> ConstEnum.enumWaferStatus.eWaferNew Then
                                        waferinfo.WaferStatus = ConstEnum.enumWaferStatus.eWaferNew
                                        objLLElevator.SetStatusGraph(iSlotNo, waferinfo)
                                    End If
                                End If
                                If (waferinfo.WaferStatus = ConstEnum.enumWaferStatus.eWaferNew) Then
                                    Dim sqiSequence As New SequenceInfor(waferinfo)
                                    sqiSequence.LoadLockName = m_strLoadLockName
                                    Dim waferflow As New ArrayList

                                    ' Translate from sequence step list (1,2,3,4 ...) to sequence step (DBSeqStep)
                                    For Each strSeqNo As String In SequenceSlot.WaferSequence.StepList
                                        Dim seqStep As DBSeqStep = Nothing
                                        seqStep = SequenceSlot.WaferSequence.SeqNo(strSeqNo)
                                        If seqStep IsNot Nothing Then
                                            waferflow.Add(seqStep)
                                        End If
                                    Next
                                    sqiSequence.WaferFlow = waferflow
                                    m_lstSequenceInfor.Add(sqiSequence)

                                    ' Create the process Job
                                    Dim avpPJ As AVPProcessJob = New AVPProcessJob(sqiSequence, SequenceSlot.WaferSequence.SeqName)
                                    avpPJ.AVPParentControlJob = Me
                                    ' This is the auto transfer case
                                    avpPJ.IsAutoTransfer = True
                                    avpPJ.Initialize()
                                    If sqiSequence IsNot Nothing AndAlso sqiSequence.ChamberNames IsNot Nothing Then
                                        For Each chamberName As String In sqiSequence.ChamberNames
                                            Dim chamberConfig As SystemModule = ContainerData.GetRobotConfig(chamberName)
                                            If chamberConfig IsNot Nothing AndAlso (chamberConfig.Type = SystemModule.ModuleType.PVD4 OrElse chamberConfig.Type = SystemModule.ModuleType.PVD5T) Then
                                                JobManager.CJBatchProcessing = True
                                                Exit For
                                            End If
                                        Next
                                    End If
                                    ''
                                    waferinfo.WaferProcessInfo = avpPJ.JobID & " was scheduled from " & avpPJ.SequenceInfor.LoadLockName
                                    ' Create the handler
                                    AddHandler avpPJ.PJTransferCompletedEvent, AddressOf AutoTransferCompletedEvent_processing
                                    m_lstProcessJob.Add(avpPJ)
                                    avpPJ.ChangeStatePJ(ConstEnum.PJSTATE_MACHINES.Pooled.ToString())
                                End If
                            End If
                        End If
                    End If
                Next

                If (JobManager.CJBatchProcessing) Then
                    BuildBatchProcessJob(m_lstProcessJob)
                    RemoveAllJobNotFullPatch()
                End If

                'm_LotDatalogLib.AddLotInfo(m_strLotID, "Start Processing")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave InitializeAutoTransfer")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-12-27</date>
        ''' </author>
        ''' <summary>
        ''' [KHOI HA - 11-04-2013]Scheduler change.   Only start transfer wafer to Pmx when there is enough wafer in LL to fully load to Pmx.
        '''  Example,  if there is 1 to 7 wafers in LL and user start the scheduler,  scheduler should not start.  
        '''This example is assume that Pmx is a 8 wafers PM.  We will confirm this in the next meeting. 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub RemoveAllJobNotFullPatch()
            Try

                Dim jobList As List(Of AVPProcessJob) = New List(Of AVPProcessJob)
                Dim IsRemove As Boolean = False
                SyncLock m_lstProcessJob
                    'clone temp job list
                    For Each job As AVPProcessJob In m_lstProcessJob
                        jobList.Add(job)
                    Next

                    'remove all job not full patch
                    For Each PJob As AVPProcessJob In jobList
                        If (PJob.WaferCapacity > PJob.BatchProcessCount) Then
                            m_lstProcessJob.Remove(PJob)
                            PJob.TerminateAndWait()
                            IsRemove = True
                        End If
                    Next

                    If (IsRemove AndAlso m_lstProcessJob.Count = 0) Then
                        RaiseCJTransferCompletedEvent()
                        Utils.ThrowAlarm(Me.LoadlockName & ": Sequence is invalid or not enough wafer for start.", Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString))
                        AVPLotDatalog.AddLotDatalog(Me.LoadlockName, LogType.Alarm, "Sequence is invalid or not enough wafer for start.", True)
                    End If
                End SyncLock

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' get Slot ID base on the input format (LoadLockA,Slot1)(LoadLockA,Slot2)(LoadLockB,Slot2)
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetSlotID(ByVal strEquipmentName) As Integer
            AVPLib.Log.schedulerLogger.Info("Enter getSlotID")
            AVPLib.Log.schedulerLogger.Debug("strEquipmentName" + strEquipmentName)

            Dim iSlotID As Integer = -1
            Try
                Dim strRegex As String = "LoadLock[AB],Slot(\d+)"
                If (Regex.IsMatch(strEquipmentName, strRegex)) Then
                    Dim mtcMatch As Match = Regex.Match(strEquipmentName, strRegex)
                    iSlotID = CInt(mtcMatch.Groups(1).Value)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.schedulerLogger.Info("Leave getSlotID")
            Return iSlotID

        End Function

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Get wafer inforamtion base on the equipment name, this function is used in semi transfer function
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetWaferInfo(ByVal strEquipmentName As String) As AVPWaferInfo
            AVPLib.Log.schedulerLogger.Info("Enter getWaferInfo")

            Dim waferInfo As AVPWaferInfo = Nothing
            Try
                If strEquipmentName.IndexOf(ConstEnum.Equipments.Robot.ToString()) >= 0 Then
                    Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                    If objRobot IsNot Nothing Then
                        waferInfo = objRobot.GetWaferInfo()
                    End If
                ElseIf strEquipmentName = ConstEnum.Equipments.Aligner.ToString() Or _
                    strEquipmentName = ConstEnum.Equipments.Chamber1.ToString() Or _
                    strEquipmentName = ConstEnum.Equipments.Chamber2.ToString() Or _
                    strEquipmentName = ConstEnum.Equipments.Chamber3.ToString() Then
                    Dim objChamber As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(strEquipmentName)
                    If objChamber IsNot Nothing Then
                        waferInfo = objChamber.GetWaferInfo()
                    End If
                ElseIf (strEquipmentName.Contains(ConstEnum.Equipments.Chamber1.ToString()) OrElse _
                strEquipmentName.Contains(ConstEnum.Equipments.Chamber2.ToString()) OrElse _
                strEquipmentName.Contains(ConstEnum.Equipments.Chamber3.ToString())) Then
                    Dim strRegex As String = "^((Chamber[1-6]),(Slot(\d+)))"
                    Dim mtcMatch As Match = Regex.Match(strEquipmentName, strRegex)
                    Dim objChamber As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(mtcMatch.Groups(2).ToString)

                    Dim slotIndex As Integer = 1
                    If (mtcMatch.Groups(4) IsNot Nothing) Then
                        Dim strSlotIndex As String = mtcMatch.Groups(4).ToString
                        Integer.TryParse(strSlotIndex, slotIndex)
                    End If

                    waferInfo = objChamber.GetWaferInfo(slotIndex)
                ElseIf strEquipmentName.IndexOf(ConstEnum.Equipments.LoadLockA.ToString()) >= 0 Then
                    Dim objLLAElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                    'Parse the slot number
                    If objLLAElevator IsNot Nothing Then
                        Dim iSlotId As Integer = GetSlotID(strEquipmentName)
                        waferInfo = objLLAElevator.ListOfWaferInfo(iSlotId - 1)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.schedulerLogger.Info("Leave getWaferInfo")
            Return waferInfo
        End Function

        Public Sub InitializeSemiTransfer(ByVal strManualTransferCmd As String)
            AVPLib.Log.schedulerLogger.Info("Enter InitializeSemiTransfer")
            Try
                ' The index of process job that will be running.
                m_iCurrentRunIdx = -1
                m_bLastRunIdxInProcess = False
                m_abortInProcess = False
                m_pauseInProcess = False
                m_stopInProcess = False

                AVPLib.Log.schedulerLogger.Info("Enter SemiAutoTransfer")
                AVPLib.Log.schedulerLogger.Debug("strManualTransferCmd:" + strManualTransferCmd)

                Dim recipe As String = String.Empty
                Dim blnResult As Boolean = False
                Dim blnUseAligner As Boolean = False
                Dim strSourceEquipment As String = String.Empty
                Dim isSelfAligner As Boolean = False

                If strManualTransferCmd.Contains(ConstEnum.SELFALIGNER) Then
                    isSelfAligner = True
                    strManualTransferCmd = strManualTransferCmd.Substring(ConstEnum.SELFALIGNER.Length + 1)
                End If

                If strManualTransferCmd.Contains(ConstEnum.USEALIGNER) Then
                    '''if command is UseAlignerTrue or UseAlignerFalse
                    ''->get value and convert this command to normal
                    blnUseAligner = IIf(strManualTransferCmd.Contains(ConstEnum.USEALIGNER_TRUE), True, False)
                    If blnUseAligner Then
                        recipe = strManualTransferCmd.Substring(strManualTransferCmd.LastIndexOf(",") + 1)
                    End If
                    strManualTransferCmd = strManualTransferCmd.Substring(0, strManualTransferCmd.IndexOf(ConstEnum.USEALIGNER) - 1)
                End If
                Dim arrRegExp(14) As String
                '"^(LoadLock[AB]),Slot(\d+)"
                arrRegExp(0) = "^((Chamber[1-6]),Slot(\d+)),((LoadLock[AB]),Slot(\d+))$"
                arrRegExp(1) = "^((LoadLock[AB]),Slot(\d+)),((Chamber[1-6]),Slot(\d+))$"
                arrRegExp(2) = "^((Chamber[1-6]),Slot(\d+)),((Chamber[1-6]),Slot(\d+))$"
                arrRegExp(3) = "^((Chamber[1-6]),Slot(\d+)),(Aligner)$"
                arrRegExp(4) = "^(Aligner),((Chamber[1-6]),Slot(\d+))$"
                arrRegExp(5) = "^((LoadLock[AB]),Slot(\d+)),(Aligner)$"
                arrRegExp(6) = "^(Aligner),((LoadLock[AB]),Slot(\d+))$"
                arrRegExp(7) = "^((LoadLock[AB]),Slot(\d+)),((LoadLock[AB]),Slot(\d+))$"
                arrRegExp(8) = "^((Chamber[1-6]),Slot(\d+)),(RobotArm)$"
                arrRegExp(9) = "^(RobotArm),((Chamber[1-6]),Slot(\d+))$"
                arrRegExp(10) = "^((LoadLock[AB]),Slot(\d+)),(RobotArm)$"
                arrRegExp(11) = "^(RobotArm),((LoadLock[AB]),Slot(\d+))$"
                arrRegExp(12) = "^(Aligner),(RobotArm)$"
                arrRegExp(13) = "^(RobotArm),(Aligner)$"
                arrRegExp(14) = "^(Aligner),(Aligner)$"

                Dim intIndex As Integer = -1
                For i As Integer = 0 To arrRegExp.Length - 1
                    If (Regex.IsMatch(strManualTransferCmd, arrRegExp(i))) Then
                        intIndex = i
                        Exit For
                    End If
                Next i

                If (intIndex > -1) And (intIndex < arrRegExp.Length) Then
                    Dim lstRoute As New List(Of DBSeqStep)
                    Dim mtcMatch As Match = Regex.Match(strManualTransferCmd, arrRegExp(intIndex))

                    strSourceEquipment = mtcMatch.Groups(1).Value

                    Select Case intIndex
                        Case 0 '"^(Chamber[1-6]),((LoadLock[AB]),Slot(\d+))$"
                            AddDBSegStep(lstRoute, mtcMatch, 2, 4, 3, 0, recipe, blnUseAligner)
                        Case 1 '"^((LoadLock[AB]),Slot(\d+)),(Chamber[1-6])$"
                            AddDBSegStep(lstRoute, mtcMatch, 1, 5, 0, 6, recipe, blnUseAligner)
                        Case 2 '"^(Chamber[1-6]),(Chamber[1-6])$"
                            AddDBSegStep(lstRoute, mtcMatch, 2, 5, 3, 6, recipe, blnUseAligner)
                        Case 3 '"^(Chamber[1-6]),(Aligner)$"
                            If (blnUseAligner) Then
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(2).Value, mtcMatch.Groups(3).Value))
                                lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                                If isSelfAligner Then
                                    lstRoute.Add(New DBSeqStep(ConstEnum.STR_ROBOT_ARM, 0))
                                    lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                                    lstRoute.Add(New DBSeqStep(ConstEnum.STR_ROBOT_ARM, 0))
                                    lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                                    lstRoute.Add(New DBSeqStep(mtcMatch.Groups(2).Value, mtcMatch.Groups(3).Value))
                                End If
                            Else ' DONOT SEND RECIPE
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(2).Value, mtcMatch.Groups(3).Value))
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(4).Value, 0))
                            End If
                        Case 4 '"^(Aligner),(Chamber[1-6])$"
                            If (blnUseAligner) Then
                                lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(3).Value, mtcMatch.Groups(4).Value))
                            Else 'DONOT SEND RECIPE
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(1).Value, 0))
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(3).Value, mtcMatch.Groups(4).Value))
                            End If

                        Case 5 '"^((LoadLock[AB]),Slot(\d+)),(Aligner)$"
                            If (blnUseAligner) Then
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(1).Value, 0))
                                lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                                If isSelfAligner Then
                                    lstRoute.Add(New DBSeqStep(ConstEnum.STR_ROBOT_ARM, 0))
                                    lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                                    lstRoute.Add(New DBSeqStep(ConstEnum.STR_ROBOT_ARM, 0))
                                    lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                                    lstRoute.Add(New DBSeqStep(mtcMatch.Groups(1).Value, 0))
                                End If
                            Else 'DONOT SEND RECIPE
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(1).Value, 0))
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(4).Value, 0))
                            End If

                        Case 6 '"^(Aligner),((LoadLock[AB]),Slot(\d+))$"
                            If (blnUseAligner) Then
                                lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(2).Value, 0))
                            Else 'DONOT SEND RECIPE
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(1).Value, 0))
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(2).Value, 0))
                            End If

                        Case 7 '"^((LoadLock[AB]),Slot(\d+)),((LoadLock[AB]),Slot(\d+))$"
                            AddDBSegStep(lstRoute, mtcMatch, 1, 4, 0, 0, recipe, blnUseAligner)
                        Case 8 '"^((Chamber[1-6]),Slot(\d+)),(RobotArm)$"
                            AddDBSegStep(lstRoute, mtcMatch, 2, 4, 3, 0, recipe, blnUseAligner)
                        Case 9 '"^(RobotArm),((Chamber[1-6]),Slot(\d+))$"
                            AddDBSegStep(lstRoute, mtcMatch, 1, 3, 0, 4, recipe, blnUseAligner)
                        Case 11 '"^(RobotArm),((LoadLock[AB]),Slot(\d+))$"
                            AddDBSegStep(lstRoute, mtcMatch, 1, 2, 0, 0, recipe, blnUseAligner)
                        Case 10 '"^((LoadLock[AB]),Slot(\d+)),(RobotArm)$"
                            AddDBSegStep(lstRoute, mtcMatch, 1, 4, 0, 0, recipe, blnUseAligner)
                        Case 12 'ALIGNER TO ROBOT ARM "^(Aligner),(RobotArm)$"
                            If (blnUseAligner) Then
                                lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(2).Value, 0))
                            Else 'OLD VERSION
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(1).Value, 0))
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(2).Value, 0))
                            End If
                        Case 13 ' ROBOT ARM TO ALIGNER "^(RobotArm),(Aligner)$"
                            If (blnUseAligner) Then
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(1).Value, 0))
                                lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                            Else
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(1).Value, 0))
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(2).Value, 0))
                            End If
                        Case 14 ' ALIGNER TO ALIGNER
                            If (blnUseAligner) AndAlso isSelfAligner Then
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(1).Value, 0))
                                lstRoute.Add(New DBSeqStep(ConstEnum.STR_ROBOT_ARM, 0))
                                lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                                lstRoute.Add(New DBSeqStep(ConstEnum.STR_ROBOT_ARM, 0))
                                lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                                lstRoute.Add(New DBSeqStep(ConstEnum.STR_ROBOT_ARM, 0))
                                lstRoute.Add(New DBSeqStep(mtcMatch.Groups(1).Value, 0))
                            End If
                    End Select

                    If (lstRoute.Count > 0) Then
                        AVPLib.Log.schedulerLogger.Debug("arrRoute:")
                        AVPLib.Log.schedulerLogger.Debug(lstRoute)

                        ' Generate wafer information
                        Dim waferinfo As AVPWaferInfo = GetWaferInfo(strSourceEquipment)

                        Dim sqiSequence As New SequenceInfor(waferinfo)
                        sqiSequence.LoadLockName = m_strLoadLockName
                        Dim waferflow As New ArrayList

                        ' translate from sequence step list (1,2,3,4 ...) to sequence step (DBSeqStep)
                        For Each seqStep As DBSeqStep In lstRoute
                            If seqStep IsNot Nothing Then
                                waferflow.Add(seqStep)
                            End If
                        Next
                        sqiSequence.WaferFlow = waferflow
                        ' Create the process Job
                        Dim avpPJ As AVPProcessJob = New AVPProcessJob(sqiSequence, Me.JobID)
                        avpPJ.AVPParentControlJob = Me
                        avpPJ.IsSelfAligner = isSelfAligner
                        avpPJ.IsCheckedECCLimitForSelfAligner = False
                        avpPJ.IsPlaceAlignerForSelfAligner = False
                        If mtcMatch.Groups(1).Value.IndexOf(",") <> -1 Then
                            avpPJ.SelfAlignerPMName = mtcMatch.Groups(1).Value.Substring(0, mtcMatch.Groups(1).Value.IndexOf(","))
                        Else
                            avpPJ.SelfAlignerPMName = mtcMatch.Groups(1).Value
                        End If
                        ' This is the auto transfer case
                        avpPJ.IsAutoTransfer = False
                        avpPJ.Initialize()

                        'OLD VERSION ONLY USE VARIABLE ReturnWafer TO CONTROL AUTOTRANSFER AND ABORT AND RETURN ALL WAFER
                        'AT THIS TIME, WE USE ReturnWafer property TO CONTROL MANUAL TRANSFER AND RETURN WAFER
                        'IF RETURN WAFER -> LIKE AUTOTRANSFER AND ABORT
                        'IF MANUAL TRANSFER & NOT USE ALIGNER -> LIKE AUTOTRANSFER AND ABORT
                        'IF MANUAL TRANSFER & USE ALIGNER -> NOT CHANGE 
                        If (blnUseAligner) Then
                            avpPJ.IsReturnWafer = False
                        Else
                            avpPJ.IsReturnWafer = True
                        End If
                        ' Create the handler
                        AddHandler avpPJ.PJTransferCompletedEvent, AddressOf SemiTransferCompletedEvent_processing
                        m_lstProcessJob.Add(avpPJ)
                        avpPJ.ChangeStatePJ(ConstEnum.PJSTATE_MACHINES.Pooled)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave Initialize")
        End Sub
#End Region

        Private Sub AddDBSegStep(ByRef lstRoute As List(Of DBSeqStep), ByVal mtcMatch As Match, _
                ByVal SourceIndex As Integer, ByVal DesIndex As Integer, _
                ByVal SourceSlotIndex As Integer, ByVal DesSlotIndex As Integer, _
                ByVal recipe As String, ByVal UseAligner As Boolean)
            Try
                If (SourceSlotIndex = 0) Then
                    lstRoute.Add(New DBSeqStep(mtcMatch.Groups(SourceIndex).Value, 0))
                Else
                    lstRoute.Add(New DBSeqStep(mtcMatch.Groups(SourceIndex).Value, mtcMatch.Groups(SourceSlotIndex).Value))
                End If

                If (UseAligner) Then
                    lstRoute.Add(New DBSeqStep(ConstEnum.Equipments.Aligner.ToString(), 0, recipe))
                End If

                If (DesSlotIndex = 0) Then
                    lstRoute.Add(New DBSeqStep(mtcMatch.Groups(DesIndex).Value, 0))
                Else
                    lstRoute.Add(New DBSeqStep(mtcMatch.Groups(DesIndex).Value, mtcMatch.Groups(DesSlotIndex).Value))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        Private Sub CleanUpJobQue()
            AVPLib.Log.schedulerLogger.Debug("CTRLJOB-" & JobID & " IS CLEANING ITS JOB QUEUE.")
            Dim job As AVPProcessJob
            Dim jobList As List(Of AVPProcessJob) = New List(Of AVPProcessJob)
            SyncLock m_lstProcessJob
                For Each job In m_lstProcessJob
                    jobList.Add(job)
                Next
                m_lstProcessJob.Clear()
            End SyncLock
            ' Make sure all jobs gone.
            For Each job In jobList
                AVPLib.Log.schedulerLogger.Debug("PJ-" & job.JobID & " OF CTRLJOB-" & JobID & " SHOULD BE OVER ALREADY, BUT MAKE SURE IT'S NOT ORPHANED, CALL TERMINATE AND WAIT FOR IT EXITING.")
                job.TerminateAndWait()
            Next
        End Sub

        Public Function CheckForMaterialAvailable() As Boolean
            Return True
        End Function

        Public Function IsThisChamberInNeedOfOtherRunningPJs(ByVal thisChamber As String) As Boolean
            Try
                Dim noOfRunningCtrlJobs As Integer = JobManager.GetNoOfCtrlJobs(ConstEnum.CJSTATE_MACHINES.Executing.ToString())
                For idx As Integer = 0 To noOfRunningCtrlJobs - 1
                    Dim runningCtrlJob As AVPControlJob = Nothing
                    If JobManager.GetNoOfCtrlJobs(ConstEnum.CJSTATE_MACHINES.Executing.ToString()) > 0 Then
                        runningCtrlJob = JobManager.GetFirstCtrlJob(idx, ConstEnum.CJSTATE_MACHINES.Executing.ToString())
                        If (runningCtrlJob IsNot Nothing) Then
                            Dim oneRunningPJ As AVPProcessJob = Nothing
                            For Each oneRunningPJ In runningCtrlJob.ListOfProcessJob
                                If (oneRunningPJ.IsRunning() And oneRunningPJ.IsGivenPriority) Then
                                    If (thisChamber = oneRunningPJ.GetNextChamberInNeed()) Then
                                        Return True
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return False
        End Function

        Public Function ReserveThisChamberForAnotherRunningPJInNeed(ByVal thisChamber As String) As Boolean
            Try
                Dim noOfRunningCtrlJobs As Integer = JobManager.GetNoOfCtrlJobs(ConstEnum.CJSTATE_MACHINES.Executing.ToString())
                For idx As Integer = 0 To noOfRunningCtrlJobs - 1
                    Dim runningCtrlJob As AVPControlJob = Nothing
                    If JobManager.GetNoOfCtrlJobs(ConstEnum.CJSTATE_MACHINES.Executing.ToString()) > 0 Then
                        runningCtrlJob = JobManager.GetFirstCtrlJob(idx, ConstEnum.CJSTATE_MACHINES.Executing.ToString())
                        If (runningCtrlJob IsNot Nothing) Then
                            Dim oneRunningPJ As AVPProcessJob = Nothing
                            For Each oneRunningPJ In runningCtrlJob.ListOfProcessJob
                                If (oneRunningPJ.IsRunning() And oneRunningPJ.IsGivenPriority) Then
                                    If (thisChamber = oneRunningPJ.GetNextChamberInNeed()) Then
                                        AVPLib.Log.schedulerLogger.Debug("RESERVE " & thisChamber & " FOR THE RUNNING PJ - " & oneRunningPJ.JobID)
                                        oneRunningPJ.AddChamberToAllocatedWFResources(thisChamber)
                                        Return True
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return False
        End Function

        ' Detect if there is deadlock may be happening.
        Private Function DetectWaitChainIfHas(ByVal procJob As AVPProcessJob) As Boolean
            Dim bBuildGraphOk As Boolean = False
            Dim bHasCycle As Boolean = False
            Try
                '
                Dim DirectedGraphForSequences As New TopologicalSorter()
                DirectedGraphForSequences.Initialize()
                '
                Dim noOfRunningCtrlJobs As Integer = JobManager.GetNoOfCtrlJobs(ConstEnum.CJSTATE_MACHINES.Executing.ToString())
                Dim idx As Integer = 0
                For idx = 0 To noOfRunningCtrlJobs - 1
                    Dim runningCtrlJob As AVPControlJob = Nothing
                    If JobManager.GetNoOfCtrlJobs(ConstEnum.CJSTATE_MACHINES.Executing.ToString()) > 0 Then
                        runningCtrlJob = JobManager.GetFirstCtrlJob(idx, ConstEnum.CJSTATE_MACHINES.Executing.ToString())
                        If (runningCtrlJob IsNot Nothing) Then
                            Dim pjJob As AVPProcessJob = Nothing
                            For Each pjJob In runningCtrlJob.ListOfProcessJob
                                If (pjJob.IsRunning() Or pjJob.IsPaused()) Then
                                    If (pjJob.BuildDirectedGraph(DirectedGraphForSequences)) Then
                                        bBuildGraphOk = True
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
                ' If we failed to build the graph for Running|Paused PJ Jobs, so we don't need to build graph for this PJ Job.
                If (bBuildGraphOk) Then
                    bBuildGraphOk = procJob.BuildDirectedGraph(DirectedGraphForSequences)
                End If

                If (bBuildGraphOk) Then ' If no graph built, don't need to do topological sort.
                    DirectedGraphForSequences.Sort(bHasCycle)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return bHasCycle
        End Function

        Function GetProcJob(ByVal pjJobId As String) As AVPProcessJob
            Dim job As AVPProcessJob = Nothing
            For Each job In m_lstProcessJob
                If (pjJobId = job.JobID) Then
                    Return job
                End If
            Next
            Return Nothing
        End Function

        ''' <author>Hai Tran</author>
        ''' <date>2016-03-24</date>
        ''' <summary>
        ''' Get process job is current running.
        ''' <summary>
        Public Function GetProcJobRunning() As AVPProcessJob
            Dim job As AVPProcessJob = Nothing
            For Each job In m_lstProcessJob
                If (job.IsRunning()) Then
                    Return job
                End If
            Next
            Return Nothing
        End Function

        'Dat Cao
        'any job is running: return True 
        Public Function IsAnyRunningProcessJob() As Boolean
            Dim job As AVPProcessJob = Nothing
            For Each job In m_lstProcessJob
                If (job.IsRunning()) Then
                    Return True
                End If
            Next
            Return False
        End Function
        Public Function IsAnyRunningProcessJobWithWaferFlow(ByVal waferFlowName As String) As Boolean
            Dim job As AVPProcessJob = Nothing
            For Each job In m_lstProcessJob
                If job.IsRunning() AndAlso (waferFlowName = job.WaferFlowName) Then
                    Return True
                End If
            Next
            Return False
        End Function

        Public Function GetPausedProcessJobs() As List(Of String)
            Dim listOfPausedPJs As New List(Of String)
            Dim job As AVPProcessJob = Nothing
            For Each job In m_lstProcessJob
                If job.IsPaused() Then
                    listOfPausedPJs.Add(job.JobID)
                End If
            Next
            Return listOfPausedPJs
        End Function

        Public Function IsAnyPausedProcessJob() As Boolean
            Dim job As AVPProcessJob = Nothing
            For Each job In m_lstProcessJob
                If job.IsPaused() Then
                    Return True
                End If
            Next
            Return False
        End Function

        'Existed ProcessJob A with state = SettingUp
        'And Existed ProcessJob B with state Running And A & B have same Batch group ID
        Private Function IsContinueToPickOnStopJob() As Boolean
            Dim blResult As Boolean = False

            Try
                Dim pJob As AVPProcessJob = Nothing
                Dim ListOfPJ As List(Of Integer) = GetStopingJobGroupIdx()

                If (ListOfPJ.Count > 0) Then
                    For Each pJob In m_lstProcessJob
                        If (pJob IsNot Nothing AndAlso JobManager.CJBatchProcessing AndAlso pJob.IsSettingUp) Then
                            If (ListOfPJ.Contains(pJob.BatchProcessJobGroupIdx)) Then
                                blResult = True
                                Exit Try
                            End If
                        End If
                    Next
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return blResult
        End Function

        Private Function GetStopingJobGroupIdx() As List(Of Integer)
            Dim listOfPJ As New List(Of Integer)()
            Try
                Dim pJob As AVPProcessJob = Nothing
                For Each pJob In m_lstProcessJob
                    If (pJob IsNot Nothing AndAlso JobManager.CJBatchProcessing AndAlso pJob.StopInProcess) Then
                        If Not (listOfPJ.Contains(pJob.BatchProcessJobGroupIdx)) Then
                            listOfPJ.Add(pJob.BatchProcessJobGroupIdx)
                        End If
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            
            Return listOfPJ
        End Function

        Private Function GetProcessJobHighestPriority() As List(Of AVPProcessJob)
            Dim listOfPJ As New List(Of AVPProcessJob)()
            Dim filterGroupIdx As New Dictionary(Of String, AVPProcessJob)()
            Dim filterWaferFlow As New Dictionary(Of String, AVPProcessJob)()
            Dim pJob As AVPProcessJob = Nothing
            For Each pJob In m_lstProcessJob
                If pJob.IsSettingUp() Then
                    'differ group index
                    If (Not filterGroupIdx.ContainsKey(pJob.BatchProcessJobGroupIdx)) Then
                        'not existed wafer flow 
                        If (Not filterWaferFlow.ContainsKey(pJob.WaferFlowName)) Then
                            filterGroupIdx.Add(pJob.BatchProcessJobGroupIdx, pJob)
                            filterWaferFlow.Add(pJob.WaferFlowName, pJob)
                            listOfPJ.Add(pJob)
                        End If
                    Else ' similar group index
                        Dim existedJob As AVPProcessJob = filterGroupIdx.Item(pJob.BatchProcessJobGroupIdx)

                        If (existedJob.Priority > pJob.Priority) Then
                            listOfPJ.Remove(existedJob)
                            listOfPJ.Add(pJob)
                        End If
                    End If
                End If
            Next
            Return listOfPJ
        End Function
        Private Function GetSettingUpPJJobsWillBeRunning() As List(Of AVPProcessJob)
            Dim listOfPJ As New List(Of AVPProcessJob)()
            Dim filterMap As New Dictionary(Of String, AVPProcessJob)()
            Dim pJob As AVPProcessJob = Nothing
            For Each pJob In m_lstProcessJob
                If pJob.IsSettingUp() Then
                    If (Not filterMap.ContainsKey(pJob.WaferFlowName)) Then
                        filterMap.Add(pJob.WaferFlowName, pJob)
                        listOfPJ.Add(pJob)
                    End If
                End If
            Next
            Return listOfPJ
        End Function

        ''' <author>
        '''    	<name>Dat Cao</name>
        '''    	<date> 2011-04-07</date>
        ''' </author>
        ''' <summary>
        ''' get next job in m_lstProcessJob
        ''' return Nothing if not get something to processing
        ''' </summary>
        Public Function GetNextProcJob(ByVal PJProcessingOrder As Boolean) As AVPProcessJob
            If Monitor.TryEnter(AVPProcessJob.LockTransportResource) Then
                Try

                    If IsStopInProcess AndAlso Not IsContinueToPickOnStopJob() Then
                        Return Nothing
                    End If
                    If IsPauseInProcess Then
                        Return Nothing
                    End If
                    If IsAbortInProcess Then
                        Return Nothing
                    End If

                    Dim pJob As AVPProcessJob = Nothing
                    Dim settingUpPJs As List(Of AVPProcessJob) = Nothing
                    If (JobManager.CJBatchProcessing) Then
                        settingUpPJs = GetProcessJobHighestPriority()
                    Else
                        settingUpPJs = GetSettingUpPJJobsWillBeRunning()
                    End If

                    For Each pJob In settingUpPJs
                        ' if PJ = list, wait until other job is finished
                        If (PJProcessingOrder = ConstEnum.PROCESSING_ORDER_LIST) _
                            And (IsAnyRunningProcessJob() = True) Then
                            AVPLib.Log.schedulerLogger.Debug("CJ in PROCESSING_ORDER_LIST mode, cannot start more process job.")
                            Continue For
                        End If

                        Dim bCanStart As Boolean = False

                        If (pJob.IsANYIBE) Then
                            bCanStart = DetectDeadlockForANYIBE(pJob)
                        Else
                            bCanStart = DetectDeadlock(pJob)
                        End If

                        If (bCanStart) Then
                            ' Now it's ok to start the job.
                            AVPLib.Log.schedulerLogger.Error("Starting Job " & pJob.JobID)
                            Return pJob
                        ElseIf (PJProcessingOrder = ConstEnum.PROCESSING_ORDER_LIST) Then
                            Exit For
                        End If
                    Next
                Finally
                    Monitor.Exit(AVPProcessJob.LockTransportResource)
                End Try
            End If
            Return Nothing
        End Function

        ''' <author>
        '''    	<name>Dat Cao</name>
        '''    	<date> 2011-11-28</date>
        ''' </author>
        ''' <summary>
        ''' Detect deathlock for general case
        ''' if build graph - no cycle -> get only one resource step
        ''' else get all resource step
        ''' </summary>
        Private Function DetectDeadlock(ByVal pJob As AVPProcessJob) As Boolean
            ' Detect deadlock as soon as possible.
            Dim bCanStart As Boolean = False

            Try
                If DetectWaitChainIfHas(pJob) Then
                    AVPLib.Log.schedulerLogger.Debug("It's dangerous to start the Job " & pJob.JobID & _
                        ", it may cause a deadlock, then try to acquire all resources.")
                    If (pJob.GetResourcesForAllSteps()) Then
                        bCanStart = True
                    End If
                Else
                    Dim bSkipIt As Boolean = False
                    ' If the first station is in immediate need of other processing PJs, then skip it.
                    If (Not bSkipIt) Then
                        AVPLib.Log.schedulerLogger.Debug("No potential deadlock found, then only try to acquire resources for the first step for " & pJob.JobID)
                        If (pJob.GetResourcesForStep(1)) Then
                            bCanStart = True
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return bCanStart
        End Function
        ''' <author>
        '''    	<name>Dat Cao</name>
        '''    	<date> 2011-11-28</date>
        ''' </author>
        ''' <summary>
        ''' Detect deathlock for general case
        ''' if build graph - no cycle -> get only one resource step
        ''' else get all resource step
        ''' </summary>
        Private Function DetectDeadlockForANYIBE(ByVal pJob As AVPProcessJob) As Boolean
            'backup data
            'list sequence step
            'NEED BACKUP DATA AND RESTORE WHEN CAN'T START THIS JOB
            'm_lstSeqStep
            'm_sifSequenceInfor
            'm_listConvertedRoute
            'm_chamberNameListForRunData
            Dim bCanStart As Boolean = False
            Try
                Dim oldListofSecstep As List(Of List(Of DBSeqStep)) = pJob.CloneListOfSegStep()
                Dim oldsifSequenceInfo As SequenceInfor = New SequenceInfor(pJob.SequenceInfor)
                Dim oldlistConvertedRoute As List(Of String) = pJob.CloneListConvertedRoute()
                Dim oldChamberNameListForRunData As List(Of String) = pJob.CloneChamberNameListForRunData()

                Dim arrFreeIBEList As ArrayList = pJob.GetListFreeIBEChamber()


                For Each Item As String In arrFreeIBEList
                    If (pJob.CreareSequenceStepForANYIBE(Item)) Then
                        If (Not DetectWaitChainIfHas(pJob)) Then
                            Dim bSkipIt As Boolean = False
                            ' If the first station is in immediate need of other processing PJs, then skip it.
                            If (Not bSkipIt) Then
                                AVPLib.Log.schedulerLogger.Debug("No potential deadlock found, then only try to acquire resources for the first step for " & pJob.JobID)
                                If (pJob.GetResourcesForStep(1)) Then
                                    'creare resource success
                                    bCanStart = True
                                    Exit For
                                End If
                            End If
                        Else
                            'continue find the best solusion
                            Continue For
                        End If
                    End If
                Next
                ' deathlock for all IBE chamber -> last solution -> get all resource for it
                If (Not bCanStart And pJob.GetResourcesForAllSteps()) Then
                    AVPLib.Log.schedulerLogger.Debug("It's dangerous to start the Job " & pJob.JobID & _
                                        ", it may cause a deadlock, then try to acquire all resources.")
                    bCanStart = True
                ElseIf (Not bCanStart) Then
                    'restore date when can't start here
                    pJob.RestoreData(oldListofSecstep, oldsifSequenceInfo, oldlistConvertedRoute, oldChamberNameListForRunData)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return bCanStart
        End Function
        Public Function GetNextProcJobToStart(ByVal PJProcessingOrder As Integer, ByVal bOnlyOneCJRunning As Boolean) As AVPProcessJob
            If Monitor.TryEnter(AVPProcessJob.LockTransportResource) Then
                Try
                    If IsStopInProcess Then
                        Return Nothing
                    End If
                    If IsPauseInProcess Then
                        Return Nothing
                    End If
                    If IsAbortInProcess Then
                        Return Nothing
                    End If

                    Dim pJob As AVPProcessJob = Nothing
                    Dim settingUpPJs As List(Of AVPProcessJob) = GetSettingUpPJJobsWillBeRunning()
                    For Each pJob In settingUpPJs
                        'get next process wrong here 
                        'if CJ = 0 PJ = 0 -> never run 
                        '   CJ = 1 PJ = 0 ->
                        'can get other job with differ waferflow name
                        ' If there is any PJ running, do not start more PJ.
                        If (Not bOnlyOneCJRunning) And (PJProcessingOrder = ConstEnum.PROCESSING_ORDER_LIST) Then
                            If IsAnyRunningProcessJobWithWaferFlow(pJob.WaferFlowName) Then
                                AVPLib.Log.schedulerLogger.Debug("CJ in PROCESSING_ORDER_LIST mode, cannot start more process job.")
                                Continue For
                            End If
                        End If
                        ' Detect deadlock as soon as possible.
                        Dim bCanStart As Boolean = False
                        If DetectWaitChainIfHas(pJob) Then
                            AVPLib.Log.schedulerLogger.Debug("It's dangerous to start the Job " & pJob.JobID & ", it may cause a deadlock, then try to acquire all resources.")
                            If (pJob.GetResourcesForAllSteps()) Then
                                bCanStart = True
                            End If
                        Else
                            Dim bSkipIt As Boolean = False
                            ' If the first station is in immediate need of other processing PJs, then skip it.
                            If (Not bSkipIt) Then
                                AVPLib.Log.schedulerLogger.Debug("No potential deadlock found, then only try to acquire resources for the first step for " & pJob.JobID)
                                If (pJob.GetResourcesForStep(1)) Then
                                    bCanStart = True
                                End If
                            End If
                        End If

                        If (bCanStart) Then
                            ' Now it's ok to start the job.
                            AVPLib.Log.schedulerLogger.Debug("Starting Job " & pJob.JobID)
                            Return pJob
                        End If
                    Next
                Finally
                    Monitor.Exit(AVPProcessJob.LockTransportResource)
                End Try
            End If
            Return Nothing
            'Dim currentRunIdx As Integer = m_iCurrentRunIdx
            'If (currentRunIdx <> -1) Then
            '    If (m_lstProcessJob.Count = (currentRunIdx + 1)) Then
            '        Return Nothing
            '    End If
            '    currentRunIdx += 1
            'Else
            '    currentRunIdx = 0
            'End If

            'If m_lstProcessJob.Count > 0 Then
            '    pJob = m_lstProcessJob.Item(currentRunIdx)
            'End If
            'If (pJob Is Nothing) Then
            '    AVPLib.Log.schedulerLogger.Debug("Memory Corruption, can not happen.")
            '    Return Nothing
            'End If
            'If (Not pJob.IsSettingUp()) Then
            '    Return Nothing
            'End If
            '' Detect deadlock.
            'If DetectWaitChainIfHas(pJob) Then
            '    AVPLib.Log.schedulerLogger.Debug("It's dangerous to start the Job " & pJob.JobID & ", it may cause a deadlock.")
            '    If (Not pJob.GetResourcesForAllSteps()) Then
            '        Return Nothing
            '    End If
            'Else
            '    If (Not pJob.GetResourcesForStep(1)) Then
            '        Return Nothing
            '    End If
            'End If
            '' Now it's ok to start the job.
            'AVPLib.Log.schedulerLogger.Debug("Starting Job " & pJob.JobID)
            'm_iCurrentRunIdx = currentRunIdx
            'If (m_lstProcessJob.Count = (currentRunIdx + 1)) Then
            '    AVPLib.Log.schedulerLogger.Debug("This is the last job in this control job.")
            '    m_bLastRunIdxInProcess = True
            'End If
            'Return pJob
        End Function

        Public Function CheckIfAllJobsAborted() As Boolean
            If Not IsAbortInProcess Then
                Return False
            End If
            Dim bResult As Boolean = True
            Dim job As AVPProcessJob = Nothing
            For Each job In m_lstProcessJob
                If job.IsRunning() Then
                    bResult = False
                    Exit For
                End If
                If (Not job.IsJobOver() AndAlso _
                        (((Not job.IsQueued()) AndAlso (Not job.IsSettingUp())) AndAlso (Not job.IsPaused()))) Then
                    bResult = False
                    Exit For
                End If
            Next
            Return bResult
        End Function

        Public Function CheckIfAllJobsDone() As Boolean
            Dim job As AVPProcessJob = Nothing
            For Each job In m_lstProcessJob
                If Not job.IsJobOver() Then
                    Return False
                End If
            Next
            Return True
        End Function

        Public Function CheckIfAllJobsStopped() As Boolean
            If Not IsStopInProcess Then
                Return False
            End If
            Dim bResult As Boolean = True

            Try
                Dim job As AVPProcessJob = Nothing
                For Each job In m_lstProcessJob
                    AVPLib.Log.schedulerLogger.Debug("PJOB " & job.JobID & " IN CURRENT STATE: " & job.CurrentState)
                    If job.IsRunning() Then
                        bResult = False
                        Exit For
                    End If
                    If (job.IsPaused()) Then
                        bResult = False
                        Exit For
                    End If
                    If (((((Not job.IsQueued()) AndAlso _
                           (Not job.IsSettingUp()))) AndAlso _
                           (Not job.IsPaused())) AndAlso _
                       Not job.IsJobOver()) Then
                        bResult = False
                        Exit For
                    End If
                Next
                AVPLib.Log.schedulerLogger.Debug("CJOB " & Me.JobID & " CHECK_IF_ALL_JOBS_STOPPED()=" & bResult.ToString())
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return bResult
        End Function

        Public Function CheckIfAllJobsPaused() As Boolean
            If Not IsPauseInProcess Then
                Return False
            End If
            Dim bResult As Boolean = True
            Dim job As AVPProcessJob = Nothing
            For Each job In m_lstProcessJob
                If (job.IsRunning()) Then
                    bResult = False
                    Exit For
                End If
            Next
            Return bResult
        End Function

        Public ReadOnly Property IsContinuousJob() As Boolean
            Get
                'Return m_blIsContinuousJob
                If Not String.IsNullOrEmpty(m_strManualTransferCmd) Then
                    Return False
                End If
                If String.IsNullOrEmpty(m_strLoadLockName) Then
                    Return False
                Else
                    Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(m_strLoadLockName)
                    Return objLoadLock.InCycleMode_RunWithRecipe
                End If
            End Get
        End Property


        Public ReadOnly Property IsWithoutMotion() As Boolean
            Get
                'Return IsWithoutMotion
                If Not String.IsNullOrEmpty(m_strManualTransferCmd) Then
                    Return False
                End If
                If String.IsNullOrEmpty(m_strLoadLockName) Then
                    Return False
                Else
                    Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(m_strLoadLockName)
                    Return objLoadLock.IsWithoutMotion
                End If
            End Get
        End Property

        Public ReadOnly Property IsCycleInATMMode() As Boolean
            Get
                Return m_blCycleInATMMode
            End Get
        End Property

        Public ReadOnly Property IsPauseInProcess() As Boolean
            Get
                Return m_pauseInProcess
            End Get
        End Property

        Public Function IsFullCycleProcess() As Boolean
            If (m_MaxCycleCount > 0) Then
                Return (m_CycleCount >= m_MaxCycleCount)
            Else
                Return False
            End If
        End Function

        Public Function StartNewCycle() As Boolean
            If (IsAbortInProcess) Then
                AVPLib.Log.schedulerLogger.Debug("Abort in process, please wait.")
                Return False
            End If
            If (IsStopInProcess) Then
                AVPLib.Log.schedulerLogger.Debug("Stop in process, cannot start a new cycle.")
                Return False
            End If
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, AVPLib.ContainerData.LogSource.AVPMainScreen, "Delay 5s to start new cycle.")
            Me.m_terminateEvent.WaitOne(5000, True)
            CleanUpJobQue()
            InitializeAutoTransfer()
            Return JobStart()
        End Function

        Public ReadOnly Property IsAbortInProcess() As Boolean
            Get
                Return m_abortInProcess
            End Get
        End Property

        Public ReadOnly Property IsStopInProcess() As Boolean
            Get
                Return m_stopInProcess
            End Get
        End Property

        Private Sub RaiseCJTransferCompletedEvent()
            If Not String.IsNullOrEmpty(LoadlockName) Then
                If m_blIsAutoTransferJob Then
                    AddTotalWaferProcessIntoLotDatalog()
                End If

                Dim eventData As ProcessedEventArgs = New ProcessedEventArgs(True, Nothing, m_blIsAutoTransferJob, m_isReturnFreeJob, False, m_isReturnForProcessCJ)
                eventData.LoadlockName = m_strLoadLockName
                RaiseEvent CJTransferCompletedEvent(Me, eventData)
            End If
        End Sub

        Public Sub RaiseCJProcessingStatusEvent(ByVal processingState As String)
            Dim eventData As CJProcessingStatusEventArgs = New CJProcessingStatusEventArgs(m_strLoadLockName, processingState)
            RaiseEvent CJProcessingStatusEvent(Me, eventData)
        End Sub

        Public Function OnAbortJob() As Boolean
            AVPLib.Log.schedulerLogger.Debug("CTRLJOB-" & JobID & ": OnAbortJob() CALLED.")
            CleanUpJobQue()
            RaiseCJTransferCompletedEvent()
            '
            Return ChangeState(ConstEnum.CJSTATE_MACHINES.Completed.ToString())
        End Function

        Public Sub CompletedCycleWafer()
            AVPLib.Log.coreLogger.Info("Enter CompletedCycleWafer")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                If (MaxCycleCount > 0) Then
                    ReplyValues.Add(PickWaferCount.ToString() & "/" & MaxCycleCount.ToString())
                Else
                    ReplyValues.Add(String.Empty)
                End If

                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("CompletedCycleWafer")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.LoadlockName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CompletedCycleWafer")
        End Sub

        Private Sub OnJobComplete(ByVal state As Object)
            AVPLib.Log.schedulerLogger.Debug("CTRLJOB-" & JobID & ": OnJobComplete() CALLED.")

            ' Log for User
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, "Finish processing sequence " & m_strSequenceID)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, "Complete at " & DateTime.Now.ToString())

            Try

                '2012-08-29 Need to turn off cycle mode when cycle until complete.   Prefer before autovent LLx
                If (IsContinuousJob AndAlso m_IsRunCylceUntilMode) Then
                    TurnOffCycleMode()
                End If

                TurnOnProcessCompleteChime()

                '0005524: [KhoHa- 08/20/2014]  Always got alarm C10 - Set, Store, Or Action Command Received While Previous Action Still In Progress after process completed.
                Me.m_terminateEvent.WaitOne(5000, True)
                Dim strEquipmentName As String = ConstEnum.Equipments.LLAElevator.ToString()
                Dim objElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(strEquipmentName)
                If (objElevator IsNot Nothing) AndAlso objElevator.OperationStatus = Equipment.OperationStatuses.BUSY Then
                    Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(LoadlockName), LoadLockController)
                    If ctrLoadLock IsNot Nothing Then
                        Dim ctrElevator As LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)
                        If ctrElevator IsNot Nothing Then
                            ctrElevator.WaitForLoadLockReady(strEquipmentName)
                        End If
                    End If
                End If

                'new request 2012-02-23
                'run auto vent when processing completed 
                '
                RunAutoVent()

                CleanUpJobQue()

                Me.m_terminateEvent.WaitOne(1000, True)

                If (HasSuspendRequest()) Then
                    RaiseCJTransferCompletedEvent()
                Else
                    Wait4AutoVentCompleted()
                    RaiseCJTransferCompletedEvent()
                End If

                ChangeState(ConstEnum.CJSTATE_MACHINES.Completed.ToString())
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

        End Sub

        Public Sub TurnOffCycleMode()
            AVPLib.Log.coreLogger.Info("Enter TurnOffCycleMode")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()

                ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("CycleUntilStatus")


                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.LoadlockName, PropertyNames, ReplyValues)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOffCycleMode")
        End Sub
        Public Sub OnJobCompleteProc()
            ThreadPool.QueueUserWorkItem(AddressOf OnJobComplete, Nothing)
        End Sub
        Private Function IsVentCompleted() As Boolean
            Dim objLoadlock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(Me.LoadlockName)
            Return (objLoadlock IsNot Nothing AndAlso objLoadlock.AutoVentStatus = DataManagerment.Equipment.WorkingStatuses.Off)
        End Function

        Private Function Wait4AutoVentCompleted() As Boolean
            Dim objLoadlock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(Me.LoadlockName)
            If (objLoadlock IsNot Nothing AndAlso objLoadlock.AutoVentStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                Dim miliseconds As Integer = VentPumdownLib.LLPumpdownConfig.LLVentComplete
                Utils.WaitOnCondition(AddressOf IsVentCompleted, miliseconds, Me.m_terminateEvent)
            End If
        End Function

        Public Function OnPauseJob() As Boolean
            m_pauseInProcess = False
            Return ChangeState(ConstEnum.CJSTATE_MACHINES.Paused.ToString())
        End Function

        Public Function OnStopJob() As Boolean
            AVPLib.Log.schedulerLogger.Debug("CTRLJOB-" & JobID & ": OnStopJob() CALLED.")
            ' Log for User
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, "End processing sequence " & m_strSequenceID)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, "End at " & DateTime.Now.ToString())
            CleanUpJobQue()
            RaiseCJTransferCompletedEvent()
            '
            Return ChangeState(ConstEnum.CJSTATE_MACHINES.Completed.ToString())
        End Function

        Public Function MakeWaitingToStart() As Boolean
            If IsStopInProcess Then
                Return False
            End If
            Return ChangeStateCJ(ConstEnum.CJSTATE_MACHINES.WaitingForStart.ToString())
        End Function

        Public Function SelectJob() As Boolean
            AVPLib.Log.schedulerLogger.Debug("Start CJ - ID=" & JobID)
            If IsStopInProcess Then
                Return False
            End If
            Return ChangeState(ConstEnum.CJSTATE_MACHINES.Selected.ToString())
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-05-23 </date>
        ''' </author>
        ''' <summary>
        ''' Add wafer id handled into list
        ''' </summary>
        Public Sub AddWaferIDHandledToList(ByVal waferID As String)
            Try
                If m_listOfWaferIDIsHandled Is Nothing Then
                    m_listOfWaferIDIsHandled = New List(Of String)
                End If

                If Not m_listOfWaferIDIsHandled.Contains(waferID) Then
                    m_listOfWaferIDIsHandled.Add(waferID)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-05-23 </date>
        ''' </author>
        ''' <summary>
        ''' Clear All WaferID Handled
        ''' </summary>
        Private Sub ClearAllWaferIDHandled()
            Try
                If m_listOfWaferIDIsHandled IsNot Nothing Then
                    m_listOfWaferIDIsHandled.Clear()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-05-23 </date>
        ''' </author>
        ''' <summary>
        ''' Format list of wafer id to string
        ''' </summary>
        Private Function FormatListOfWaferID() As String
            Dim result As String = String.Empty

            Try
                For Each waferID As String In m_listOfWaferIDIsHandled
                    result = result & waferID & ", "
                Next

                If Not String.IsNullOrEmpty(result) Then
                    result = result.Substring(0, result.LastIndexOf(","))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return result
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-05-23 </date>
        ''' </author>
        ''' <summary>
        ''' Add Total Wafer Process Into Lot Datalog
        ''' </summary>
        Private Sub AddTotalWaferProcessIntoLotDatalog()
            AVPLib.Log.coreLogger.Info("Enter AddTotalWaferProcessIntoLotDatalog")

            Try
                ' Format string
                Dim listOfWaferID As String = FormatListOfWaferID()

                If Not String.IsNullOrEmpty(listOfWaferID) Then
                    ' Add string of wafer id to lot datalog

                    If m_blIsContinuousJob Then
                        AVPLotDatalog.AddLotDatalog(LoadlockName, LogType.Info, "Total wafers process: " & _
                                                            m_CycleCount.ToString() & " (" & listOfWaferID & ")", IsAutoTransferJob)
                    Else
                        AVPLotDatalog.AddLotDatalog(LoadlockName, LogType.Info, "Total wafers process: " & _
                                                    m_listOfWaferIDIsHandled.Count.ToString() & " (" & listOfWaferID & ")", IsAutoTransferJob)
                    End If

                    'Add total alarm
                    If (m_strLoadLockName = ConstEnum.LoadLockA_STR) Then
                        AVPLotDatalog.AddLotDatalog(LoadlockName, LogType.Info, String.Format("Total alarm: {0}", AVPLotDatalog.LLATotalAlarm), IsAutoTransferJob)
                    End If

                    ' Clean up list of wafer id
                    ClearAllWaferIDHandled()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave AddTotalWaferProcessIntoLotDatalog")
        End Sub

        ''' <author>
        '''    	<name>Do Xuan Dat </name>
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
        ''' Handle wafer processed event
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub AutoTransferCompletedEvent_processing(ByVal sender As Object, ByVal pea As ProcessedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter WaferProcesser_Processed")
            Try
                If (pea.Result) Then
                    Dim objLoadLock As LoadLock = EquipmentManager.GetEquipment(m_strLoadLockName)
                    If pea.Result Then
                        objLoadLock.IncreaseWaferCount()

                        'Dat Cao Add LotDatalog
                        AVPLotDatalog.AddLotDatalog(m_strLoadLockName, LogType.Info, "Processing Completed", m_blIsAutoTransferJob)
                    End If
                Else
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave WaferProcesser_Processed")
        End Sub

        ''' <author>
        '''    	<name>Do Xuan Dat </name>
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
        ''' Handle wafer processed event
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Sub SemiTransferCompletedEvent_processing(ByVal sender As Object, ByVal pea As ProcessedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter WaferProcesser_Processed")
            Try
                If (Not pea.IsReturnFreeJob) Then
                    Dim strMessage As String
                    If (pea.Result) Then
                        strMessage = "Semi auto transfer successfully"
                        ShowSemiAutoReponse(strMessage)
                    Else
                        strMessage = "Semi Auto Transfer Failed"
                        ShowSemiAutoReponse(strMessage)
                    End If
                    If pea.IsSelfAligner Then
                        RaiseSelfAlignerProcessing(True)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave WaferProcesser_Processed")
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-05-07 </date>
        ''' </author>
        ''' <summary>
        ''' RaiseSelfAlignerProcessing
        ''' </summary>
        ''' <param name="Status"></param>
        ''' <remarks></remarks>
        Public Shared Sub RaiseSelfAlignerProcessing(ByVal Status As Boolean)
            AVPLib.Log.coreLogger.Info("Enter RaiseSelfAlignerProcessing")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(Status)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("SelfAlignerStatus")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseSelfAlignerProcessing")
        End Sub

        ''' <author>
        '''    	<name>Do Xuan Dat </name>
        '''    	<date> 2009-11-12</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Handle wafer processed event
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Sub ShowSemiAutoReponse(ByVal Message As String)
            AVPLib.Log.coreLogger.Info("Enter ShowSemiAutoReponse")
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrPropertyValues As New ArrayList()

                arrPropertyNames.Add("SemiAutoMessage")
                arrPropertyValues.Add(Message)

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus("Alarm", arrPropertyNames, arrPropertyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ShowSemiAutoReponse")
        End Sub

        Private Shared Sub RefreshLotDatalog()
            AVPLib.Log.coreLogger.Info("Enter ShowSemiAutoReponse")
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrPropertyValues As New ArrayList()

                arrPropertyNames.Add("RefreshLotDatalog")
                arrPropertyValues.Add("RefreshLotDatalog")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), arrPropertyNames, arrPropertyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ShowSemiAutoReponse")
        End Sub

        ''' <author>
        '''    	<name>Dat Cao </name>
        '''    	<date> 2012-02-23</date>
        ''' </author>
        ''' <summary>
        ''' Support autovent when processing completed
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub TurnOnProcessCompleteChime()
            AVPLib.Log.coreLogger.Info("Enter TurnOnProcessCompleteChime")
            Try
                'only apply for auto transfer
                If (Me.m_blIsAutoTransferJob AndAlso IsLeastOneProcessJobFinished) Then
                    TMCryoUtility.Turn_Process_Complete_Chime(True)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOnProcessCompleteChime")
        End Sub

        ''' <author>
        '''    	<name>Dat Cao </name>
        '''    	<date> 2012-02-23</date>
        ''' </author>
        ''' <summary>
        ''' Support autovent when processing completed
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub RunAutoVent()
            AVPLib.Log.coreLogger.Info("Enter RunAutoVent")
            Try
                'only apply for auto transfer
                If (ContainerDAO.AutoVentWhenProcessingConpleted() AndAlso Me.m_blIsAutoTransferJob AndAlso IsLeastOneProcessJobFinished AndAlso Not m_abortInProcess) Then
                    'get loadlock nane
                    Dim LLcontroller As LoadLockController = Nothing
                    If (Not String.IsNullOrEmpty(Me.LoadlockName)) Then
                        LLcontroller = ControllerManager.GetController(Me.LoadlockName)
                    End If
                    If (LLcontroller IsNot Nothing) Then
                        LLcontroller.UnLoad()
                    End If

                    If (LLcontroller IsNot Nothing) Then
                        LLcontroller.RunAutoVentAfterProcessingCompleted()
                    End If
                    'return to default value to prepare for next CJ
                    IsLeastOneProcessJobFinished = False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RunAutoVent")
        End Sub

        ''' <author>
        '''    	<name>Dat Cao </name>
        '''    	<date> 2012-02-23</date>
        ''' </author>
        ''' <summary>
        ''' Get Data run start time for batch processing
        ''' </summary>
        ''' <remarks></remarks>
        Public Function DataRunStartTime4BatchProcessing(ByVal batchIDx As Integer) As String
            AVPLib.Log.coreLogger.Info("Enter DataRunStartTime4BatchProcessing")
            Dim strResult As String = String.Empty
            Try
                If (Me.JobManager.CJBatchProcessing) Then
                    For Each pJob As AVPProcessJob In m_lstProcessJob
                        If (pJob.BatchProcessJobGroupIdx = batchIDx AndAlso pJob.Priority = 1) Then
                            strResult = pJob.DataRunStartTime
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return strResult
            AVPLib.Log.coreLogger.Info("Leave DataRunStartTime4BatchProcessing")
        End Function
        ''' <author>
        '''    	<name>Dat Cao</name>
        '''    	<date> 2013-05-24</date>
        ''' </author>
        ''' <summary>
        ''' Check existed job pause at aligner
        ''' </summary>
        Public Function IsJobPauseAtAligner() As Boolean
            Dim blResult As Boolean = False
            Try

                If Not RobotConfigurationValues.ALINER_VISIBLE Then
                    Exit Try
                End If

                For Each PJob As AVPProcessJob In m_lstProcessJob
                    If (PJob IsNot Nothing AndAlso PJob.IsJobPauseInAligner) Then
                        blResult = True
                        Exit Try
                    End If
                Next

            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try

            Return blResult
        End Function
        Public Function IsHighestPriorityOnBatch(ByVal objJobCurrent As AVPProcessJob) As Boolean
            Dim blResult As Boolean = False
            Try
                If Not (JobManager.CJBatchProcessing) Then
                    blResult = True
                    Exit Try
                End If

                Dim objLLElevator As DataManagerment.LLElevator = Nothing
                If (Me.LoadlockName = ConstEnum.LoadLockA_STR) Then
                    objLLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                End If

                If (objLLElevator IsNot Nothing) Then
                    For Each pJob As AVPProcessJob In m_lstProcessJob
                        If (pJob IsNot objJobCurrent AndAlso _
                            pJob.BatchProcessJobGroupIdx = objJobCurrent.BatchProcessJobGroupIdx AndAlso _
                            pJob.Priority < objJobCurrent.Priority) Then


                            For Each Item As AVPWaferInfo In objLLElevator.ListOfWaferInfo
                                If (Item IsNot Nothing AndAlso _
                                    Item.WaferID = pJob.JobID) Then
                                    AVPLib.Log.coreLogger.Error("Can't start Job ID = " + objJobCurrent.JobID + ", Wait for Job:" + pJob.JobID)
                                    Exit Try
                                End If
                            Next

                        End If
                    Next
                End If
                blResult = True
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function

        ''' <name> Tri Do </name>
        ''' <date> 2016/01 </date>
        ''' <summary>
        ''' Check to see if having another PJ with same (group id and flow) is (running or paused)
        ''' </summary>
        Public Function IsThereJobWithHigherIdRunningInChamber(ByVal currentJob As AVPProcessJob) As Boolean
            Dim blResult As Boolean = False
            Try
                If Not (JobManager.CJBatchProcessing) Then
                    Exit Try
                End If

                For Each pJob As AVPProcessJob In m_lstProcessJob
                    If (pJob IsNot currentJob AndAlso _
                            pJob.BatchProcessJobGroupIdx < currentJob.BatchProcessJobGroupIdx AndAlso _
                            pJob.WaferFlowName = currentJob.WaferFlowName AndAlso _
                            Not pJob.IsJobOver AndAlso _
                            currentJob.GetNextChamberInNeed() = pJob.CurrentStation) Then
                        blResult = True
                        Exit For
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
    End Class
End Namespace