Imports System.Text.RegularExpressions
Imports System.Threading
Imports AVPLib.DataManagerment
Imports AVPLib.ConstEnum
Imports AVPLib
Imports AVPSecsGemLib

Namespace Business
    Public Class AVPProcessJob
        Inherits AVPJob

#Region "Variables and Constants"

        Private m_lstSeqStep As List(Of List(Of DBSeqStep))

        Private m_AVPControlJob As AVPControlJob
        Private m_blnIsAutoTransfer As Boolean = False

        Public Const ChamberID As String = "Chamber"
        Public Const LoadLockID As String = "LoadLock"
        Public Const AlignerID As String = "Aligner"
        Public Const RobotArmID As String = "RobotArm"
        'Public Const LoaderID As String = "Loader"
        Private Const Chuck_Zero_Distant As String = "0"

        Private m_lstRoute As List(Of DBSeqStep)
        Dim m_listConvertedRoute As List(Of String)
        Private m_sifSequenceInfor As SequenceInfor
        Private m_strWaferFlowName As String
        'When PJ Completed processing for the SemiTransfer or Auto Transfer
        Public Event PJTransferCompletedEvent(ByVal sender As Object, ByVal pea As ProcessedEventArgs)

        Public Const OpenCloseSplitValveTimeOutInMilliSeconds As Integer = 10000
        Public Const OpenCloseSlitValveWaitTimeInMilliSeconds As Integer = 2000
        Private Const TIME_WHEN_RUNNING As String = "#TIME_WHEN_RUNNING#"
        Private Const DATE_WHEN_RUNNING As String = "#DATE_WHEN_RUNNING#"
        Private m_idxCurrentStationForPickingInRoute As Integer = 0
        Private m_strDataRunStartTime As String = String.Empty

        Private m_blnJobPausedBy_PMOffline_CloseSplitValve As Boolean = False
        'Private enmPosition As Positions = Nothing
        'Private next_enmPosition As Positions = Nothing
        'Private next_next_enmPosition As Positions = Nothing
        'Private previous_enmPosition As Positions = Nothing

        'Self-Aligner
        Private m_IsSelfAligner As Boolean = False
        Private m_IsCheckedECCLimitForSelfAligner As Boolean = False
        Private m_IsPlaceAlignerForSelfAligner As Boolean = False
        Private m_strSelfAlignerPMName As String = String.Empty
        Private m_iSelfAlignerLoop As Integer = 0

        Private Shared m_lockChamberResources As New Object
        Private Shared m_lockTransportResource As New Object

        Private Shared m_ErrorWhenPlaceToStation As Boolean = False

        Private m_BatchProcessCount As Integer = 1
        Private m_Priority As Integer = 1
        Private m_BatchSlotID As Integer = 1
        Private m_BatchProcessJobGroupIdx As Integer = 1
        'Only Job have Master flag = true can be send start/stop/pause to chamber
        'All Job have Master flag = false only wait for processing completed
        Private m_MasterBatchProcessing As Boolean = False

        Private m_isCancelMove As Boolean = False
        Private m_randomTime As Integer = CInt(Int((120 * Rnd()) + 30)) * 1000
        Public Property BatchProcessCount() As Integer
            Get
                Return m_BatchProcessCount
            End Get
            Set(ByVal value As Integer)
                m_BatchProcessCount = value
            End Set
        End Property

        Public Property IsSelfAligner() As Boolean
            Get
                Return m_IsSelfAligner
            End Get
            Set(ByVal value As Boolean)
                m_IsSelfAligner = value
            End Set
        End Property

        Public Property IsCheckedECCLimitForSelfAligner() As Boolean
            Get
                Return m_IsCheckedECCLimitForSelfAligner
            End Get
            Set(ByVal value As Boolean)
                m_IsCheckedECCLimitForSelfAligner = value
            End Set
        End Property

        Public Property IsPlaceAlignerForSelfAligner() As Boolean
            Get
                Return m_IsPlaceAlignerForSelfAligner
            End Get
            Set(ByVal value As Boolean)
                m_IsPlaceAlignerForSelfAligner = value
            End Set
        End Property

        Public Property SelfAlignerPMName() As String
            Get
                Return m_strSelfAlignerPMName
            End Get
            Set(ByVal value As String)
                m_strSelfAlignerPMName = value
            End Set
        End Property

        Public Property SelfAlignerLoop() As Integer
            Get
                Return m_iSelfAlignerLoop
            End Get
            Set(ByVal value As Integer)
                m_iSelfAlignerLoop = value
            End Set
        End Property

        Public Property Priority() As Integer
            Get
                Return m_Priority
            End Get
            Set(ByVal value As Integer)
                m_Priority = value
            End Set
        End Property

        Public Property BatchSlotID() As Integer
            Get
                Return m_BatchSlotID
            End Get
            Set(ByVal value As Integer)
                m_BatchSlotID = value
            End Set
        End Property

        Public Property BatchProcessJobGroupIdx() As Integer
            Get
                Return m_BatchProcessJobGroupIdx
            End Get
            Set(ByVal value As Integer)
                m_BatchProcessJobGroupIdx = value
            End Set
        End Property
        Public Property DataRunStartTime() As String
            Get
                Return m_strDataRunStartTime
            End Get
            Set(ByVal value As String)
                m_strDataRunStartTime = value
            End Set
        End Property
        Public Property ErrorWhenPlaceToStation() As Boolean
            Get
                Return m_ErrorWhenPlaceToStation
            End Get
            Set(ByVal value As Boolean)
                m_ErrorWhenPlaceToStation = value
            End Set
        End Property
        Public ReadOnly Property JobPaused_By_PMOffline_CloseSplitValve() As Boolean
            Get
                Return m_blnJobPausedBy_PMOffline_CloseSplitValve
            End Get
        End Property
        Public Property ListRoute() As List(Of DBSeqStep)
            Get
                Return m_lstRoute
            End Get
            Set(ByVal value As List(Of DBSeqStep))
                m_lstRoute = value
            End Set
        End Property
        Public Property ListSegquenceStep() As List(Of List(Of DBSeqStep))
            Get
                Return m_lstSeqStep
            End Get
            Set(ByVal value As List(Of List(Of DBSeqStep)))
                m_lstSeqStep = value
            End Set
        End Property
        Public Shared ReadOnly Property LockTransportResource() As Object
            Get
                Return m_lockTransportResource
            End Get
        End Property

        Private m_bllockTransportResource As Boolean = False

        Private m_curAllocatedWFResources As Hashtable
        Public AbortInProcess As Boolean
        Public ReturnWafer As Boolean
        Public StopInProcess As Boolean
        ' Run Data Support.
        Private m_chamberNameListForRunData As List(Of String) = Nothing
        Private m_OrgRunDataName As String = String.Empty
        Private m_AligerDataRunFileName As String = String.Empty

        Public Shared CheckSensors As Boolean = True

        Public IsGivenPriority As Boolean = True
        Private m_IsWaitingProcessingComplete As Boolean = False
        Public ReturnWaferAlignerRecipe As String
        Public ReturnWaferUseAligner As Boolean

#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Tri Do </name>
        '''    	<date> 2014-07-28 </date>
        ''' </author>
        ''' <summary>
        ''' Is Recipe Aborted in PM
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsWaitingProcessingComplete() As Boolean
            Get
                Return m_IsWaitingProcessingComplete
            End Get
        End Property

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' get wafer information
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SequenceInfor() As SequenceInfor
            Get
                Return m_sifSequenceInfor
            End Get
            Set(ByVal value As SequenceInfor)
                m_sifSequenceInfor = value
            End Set
        End Property

        Public Property WaferFlowName() As String
            Get
                Return m_strWaferFlowName
            End Get
            Set(ByVal value As String)
                m_strWaferFlowName = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-2</date>
        ''' </author>
        ''' <summary>
        ''' get wafer information
        ''' </summary>
        ''' <remarks></remarks>
        Public Property IsAutoTransfer() As Boolean
            Get
                Return m_blnIsAutoTransfer
            End Get
            Set(ByVal value As Boolean)
                m_blnIsAutoTransfer = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 05-12-2011</date>
        ''' </author>
        ''' <summary>
        ''' get/set is Return Wafer
        ''' </summary>
        ''' <remarks></remarks>
        Public Property IsReturnWafer() As Boolean
            Get
                Return ReturnWafer
            End Get
            Set(ByVal value As Boolean)
                ReturnWafer = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' get avp control job
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AVPParentControlJob() As AVPControlJob
            Get
                Return m_AVPControlJob
            End Get
            Set(ByVal value As AVPControlJob)
                m_AVPControlJob = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-04-08</date>
        ''' </author>
        ''' <summary>
        ''' get List of SegStep
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property curAllocatedWFResources() As Hashtable
            Get
                Return m_curAllocatedWFResources
            End Get
        End Property
        Public ReadOnly Property CurrentStation() As String
            Get
                Return m_listConvertedRoute(m_idxCurrentStationForPickingInRoute)
            End Get
        End Property

        ''' <author>Hoai Ly</author>
        ''' <date>2019-01-02</date>
        ''' <summary>
        ''' Gets and Set a value indicates is manual cancel move of the process job.
        ''' </summary>
        Public Property IsCancelMove() As Boolean
            Get
                Return m_isCancelMove
            End Get
            Set(ByVal value As Boolean)
                m_isCancelMove = value
            End Set
        End Property
#End Region

        Private Function WaitOnCondition(ByVal condition As CheckConditionOneParam, ByVal oneParam As String, ByVal waitTimeInMilliseconds As Integer, ByVal checkAbortedEvent As Boolean) As Boolean
            Dim span As Int64 = waitTimeInMilliseconds
            Dim start As Int64 = Environment.TickCount
            While (Environment.TickCount - start <= span)
                If checkAbortedEvent And HasTerminateRequest() Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
                ' Check Condition.
                If condition(oneParam) Then
                    Return True
                End If
                If checkAbortedEvent Then
                    If SleepButAlertabletoTerminateRequest(100) Then
                        AVPLib.Log.coreLogger.Debug("Aborted requested.")
                        Return False
                    End If
                Else
                    Thread.Sleep(100)
                End If
            End While
            Return False
        End Function
        Private Function WaitOnCondition(ByVal condition As CheckCondition, ByVal waitTimeInMilliseconds As Integer, ByVal checkAbortedEvent As Boolean) As Boolean
            Dim span As Int64 = waitTimeInMilliseconds
            Dim start As Int64 = Environment.TickCount
            While (Environment.TickCount - start <= span)
                If checkAbortedEvent And HasTerminateRequest() Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
                ' Check Condition.
                If condition() Then
                    Return True
                End If
                If checkAbortedEvent Then
                    If SleepButAlertabletoTerminateRequest(100) Then
                        AVPLib.Log.coreLogger.Debug("Aborted requested.")
                        Return False
                    End If
                Else
                    Thread.Sleep(100)
                End If
            End While
            Return False
        End Function

        ''' <author>
        ''' <name>Hoa Nguyen</name>
        ''' <date> 2015-08-25</date>
        ''' </author>
        ''' <summary>Wait on condition with checking duration time that cond is still correct
        ''' Example: Check motor stop. We only return true if it still keep status stop in 2s
        ''' </summary>
        ''' <para></para>
        ''' <returns></returns> 
        Private Function WaitOnConditionWithDurationCheck(ByVal condition As CheckCondition, ByVal waitTimeInMilliseconds As Integer, _
                                                    ByVal checkAbortedEvent As Boolean, ByVal durationTimeInMiliseconds As Integer) As Boolean
            Dim span As Int64 = waitTimeInMilliseconds
            Dim start As Int64 = Environment.TickCount
            Dim durationTime As Int64 = Environment.TickCount
            Dim startedCounting As Boolean = False

            While (Environment.TickCount - start <= span)
                If checkAbortedEvent And HasTerminateRequest() Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If

                ' Check Condition.
                If condition() Then
                    If (startedCounting) Then
                        If (Environment.TickCount - durationTime >= durationTimeInMiliseconds) Then
                            Return True
                        End If
                    Else
                        'First time reach condition, we record the current time.
                        durationTime = Environment.TickCount
                        startedCounting = True
                    End If
                Else
                    startedCounting = False
                End If

                If checkAbortedEvent Then
                    If SleepButAlertabletoTerminateRequest(100) Then
                        AVPLib.Log.coreLogger.Debug("Aborted requested.")
                        Return False
                    End If
                Else
                    Thread.Sleep(100)
                End If
            End While
            Return False
        End Function

        Public Function GetRemainingChambersInRoute() As List(Of String)
            Dim remainingChambers As New List(Of String)()
            Dim numOfRemainingStations = m_listConvertedRoute.Count - 1
            For idx As Integer = m_idxCurrentStationForPickingInRoute To numOfRemainingStations
                Dim station As String = m_listConvertedRoute(idx)
                If station.StartsWith(ChamberID) Then
                    remainingChambers.Add(station)
                End If
            Next
            Return remainingChambers
        End Function

        Public Function GetNextChamberInNeed() As String
            Dim numberOfStations = m_listConvertedRoute.Count - 1
            For idx As Integer = (m_idxCurrentStationForPickingInRoute + 1) To numberOfStations
                Dim station As String = m_listConvertedRoute(idx)
                If station.StartsWith(ChamberID) Then
                    AVPLib.Log.schedulerLogger.Debug("THE NEXT CHAMBER: " & station & " IS IN NEED OF THE PJ=" + JobID)
                    Return station
                End If
            Next
            Return String.Empty
        End Function

        Public Function BuildDirectedGraph(ByRef graph As TopologicalSorter) As Boolean
            Dim bResult As Boolean = False
            Dim remainingChambers As List(Of String) = GetRemainingChambersInRoute()
            Const Min_Lenth As Integer = 2
            If (remainingChambers.Count >= Min_Lenth) Then
                For i As Integer = 0 To remainingChambers.Count - Min_Lenth
                    Dim owner As String = remainingChambers(i)
                    Dim ownerDependsTo As String = remainingChambers(i + 1)
                    If owner <> ownerDependsTo Then
                        graph.AddEdge(owner, ownerDependsTo)
                    End If
                Next
                bResult = True
            End If
            Return bResult
        End Function

        Public Sub Initialize()
            AVPLib.Log.schedulerLogger.Info("Enter initialize")
            If (IsAutoTransfer) Then
                InitializeAutoTransfer()
            Else
                InitializeSemiTransfer()
            End If
            AVPLib.Log.schedulerLogger.Info("Leave initialize")
        End Sub

        Public Sub InitializeSemiTransfer()
            AVPLib.Log.schedulerLogger.Info("Enter InitializeSemiTransfer")
            Dim lstRoute As New List(Of DBSeqStep)
            AVPLib.Log.schedulerLogger.Debug("Before update arrRoute Information")
            AVPLib.Log.schedulerLogger.Debug(lstRoute)

            For Each SequenceStep As AVPLib.DBSeqStep In m_sifSequenceInfor.WaferFlow
                lstRoute.Add(SequenceStep)
            Next

            m_lstRoute = lstRoute
            m_listConvertedRoute = m_lstRoute.ConvertAll(Of String)(New Converter(Of DBSeqStep, String)( _
            AddressOf GetStationNameFromSequenceStep))
            m_lstSeqStep = New List(Of List(Of DBSeqStep))()
            DivideRouteIntoAtomicSubRoute(m_lstRoute, m_lstSeqStep)
            m_curAllocatedWFResources.Clear()

            AVPLib.Log.schedulerLogger.Debug("After update arrRoute Information")
            AVPLib.Log.schedulerLogger.Debug(lstRoute)

            AVPLib.Log.schedulerLogger.Info("Leave InitializeSemiTransfer")
        End Sub

        Public Sub InitializeAutoTransfer()
            AVPLib.Log.schedulerLogger.Info("Enter InitializeAutoTransfer")
            Try

                AVPLib.Log.schedulerLogger.Debug("SequenceInfor.ChamberCount:" + m_sifSequenceInfor.ChamberCount.ToString())

                If (m_sifSequenceInfor.ChamberCount > 0) Then
                    ' original slot + waferflow + return to the original slot
                    Dim lstRoute As New List(Of DBSeqStep)
                    Dim stepobj As New DBSeqStep(m_sifSequenceInfor.LoadLockName + ",Slot" + m_sifSequenceInfor.WaferInfo.SlotID.ToString(), 0)
                    lstRoute.Add(stepobj)

                    AVPLib.Log.schedulerLogger.Debug("Before update arrRoute Information")
                    AVPLib.Log.schedulerLogger.Debug(lstRoute)

                    For Each SequenceStep As AVPLib.DBSeqStep In m_sifSequenceInfor.WaferFlow
                        SequenceStep.LoadLockName = Me.m_AVPControlJob.LoadlockName
                        lstRoute.Add(SequenceStep)
                    Next

                    lstRoute.Add(stepobj)
                    m_lstRoute = lstRoute
                    m_listConvertedRoute = m_lstRoute.ConvertAll(Of String)(New Converter(Of DBSeqStep, String)( _
                    AddressOf GetStationNameFromSequenceStep))
                    ' Run Data Support.
                    m_chamberNameListForRunData = MakeChamberNameListForRunData()

                    Dim strLoadLockXSlotX As String = m_listConvertedRoute(0)
                    strLoadLockXSlotX = strLoadLockXSlotX.Replace(",Slot", "_")
                    If strLoadLockXSlotX.Contains(LoadLockA_STR) Then
                        strLoadLockXSlotX = strLoadLockXSlotX.Replace(LoadLockA_STR, LLA_STR)

                        If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
                            strLoadLockXSlotX = LLA_STR & "_$$$"
                        End If
                    End If

                    Dim strFolderName As String = DateTime.Now.ToString("yyyy_MM_dd")
                    Dim strFolderPath As String = ContainerDAO.FPath_RunDataOfWafer & "\" & strFolderName

                    If Not System.IO.Directory.Exists(strFolderPath) Then
                        Try
                            System.IO.Directory.CreateDirectory(strFolderPath)
                        Catch ex As IO.IOException
                            Utils.ThrowAlarm("Failed To Create Folder For Wafer Run Data:" & strFolderPath)
                            AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                            "Failed To Create Folder For Wafer Run Data:" & strFolderPath, _
                            Me.IsAutoTransfer())
                        End Try
                    End If

                    m_OrgRunDataName = DATE_WHEN_RUNNING & "\" & TIME_WHEN_RUNNING & _
                                       ConstEnum.DataRunFileNameSeparator & AVPParentControlJob.LotId & "_" & strLoadLockXSlotX

                    m_AligerDataRunFileName = m_OrgRunDataName

                    m_lstSeqStep = New List(Of List(Of DBSeqStep))()
                    DivideRouteIntoAtomicSubRoute(m_lstRoute, m_lstSeqStep)
                    m_curAllocatedWFResources.Clear()
                    StopInProcess = False
                    AbortInProcess = False
                    ReturnWafer = False

                    AVPLib.Log.schedulerLogger.Debug("After update arrRoute Information")
                    AVPLib.Log.schedulerLogger.Debug(lstRoute)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave InitializeAutoTransfer")
        End Sub

        Public Function OnAbortJob() As Boolean
            AVPLib.Log.schedulerLogger.Debug(JobID & " OnAbortJob() called.")

            If (Me.AVPParentControlJob.IsAutoTransferJob) Then
                AVPParentControlJob.CycleCount += 1
                AVPLib.Log.avpLogger.Error("Job Finished Count=" & AVPParentControlJob.CycleCount.ToString)
            End If

            ReleaseCurResources()
            ReleaseTransportResource()
            AbortInProcess = False
            ReturnWafer = False
            Return ChangeState(ConstEnum.PJSTATE_MACHINES.ProcessComplete.ToString())
        End Function

        Public Function OnJobComplete() As Boolean
            AVPLib.Log.schedulerLogger.Debug(JobID & " OnJobComplete() called.")

            'least one wafer finished -> anable to vent when CJ completed
            If (Me.AVPParentControlJob.IsAutoTransferJob) Then

                AVPParentControlJob.CycleCount += 1
                AVPLib.Log.avpLogger.Error("Job Completed Count=" & AVPParentControlJob.CycleCount.ToString)

                Me.AVPParentControlJob.IsLeastOneProcessJobFinished = True
                'cycle until mode and one wafer complete ->increase cycle count
                'If (AVPParentControlJob.IsContinuousJob AndAlso AVPParentControlJob.IsRunCylceUntilMode) Then
                '    AVPParentControlJob.CycleCount += 1
                'End If
            End If

            ReleaseTransportResource()
            ReleaseCurResources()
            Return ChangeState(ConstEnum.PJSTATE_MACHINES.ProcessComplete.ToString())
        End Function

        Public Function OnStopJob() As Boolean
            AVPLib.Log.schedulerLogger.Debug(JobID & " OnStopJob() called.")

            If (Me.AVPParentControlJob.IsAutoTransferJob) Then
                AVPParentControlJob.CycleCount += 1
                AVPLib.Log.avpLogger.Error("Job Completed Count=" & AVPParentControlJob.CycleCount.ToString)
            End If

            ReleaseCurResources()
            ReleaseTransportResource()
            StopInProcess = False
            Return ChangeState(ConstEnum.PJSTATE_MACHINES.ProcessComplete.ToString())
        End Function

        Public Sub AddChamberToAllocatedWFResources(ByVal chName As String)
            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": ADDING " & chName & " TO m_curAllocatedWFResources")
            If Not m_curAllocatedWFResources.Contains(chName) Then
                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": ADDED " & chName & " TO m_curAllocatedWFResources")
                m_curAllocatedWFResources.Add(chName, chName)
            End If
        End Sub
        Public Function RemoveChamberFromAllocatedWFResources(ByVal chName As String) As Boolean
            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": REMOVING " & chName & " FROM m_curAllocatedWFResources")
            If m_curAllocatedWFResources.Contains(chName) Then
                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": REMOVED " & chName & " FROM m_curAllocatedWFResources")
                m_curAllocatedWFResources.Remove(chName)
            End If
        End Function

        ' - Processing Chamber(strEquipmentName): Chamber 1, Chamber 2, ... Chamber n
        Private Function InnerAcquireChamberResource(ByVal pstrEquipmentName As String, ByVal SlotID As Integer, Optional ByVal blcheckOnline As Boolean = True, Optional ByVal blcheckWaferStatus As Boolean = True, Optional ByVal bAlarmIfHasError As Boolean = False) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter InnerAcquireChamberResource")
            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " is trying to accquire " & pstrEquipmentName)
            Try
                Dim eqmEquiment As Equipment = Nothing
                Dim blnResult = True
                Dim strSlot As String = "0"

                eqmEquiment = EquipmentManager.GetEquipment(pstrEquipmentName)

                If (eqmEquiment Is Nothing) Then
                    blnResult = False
                    GoTo end_func
                End If

                If (eqmEquiment.OperationStatus = Equipment.OperationStatuses.BUSY OrElse _
                    eqmEquiment.OperationStatus = Equipment.OperationStatuses.ERROR) Then
                    If (bAlarmIfHasError) Then

                        Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentIsNotReady"), _
                                         Utils.chamberID2ChamberName(eqmEquiment.Name), eqmEquiment.OperationStatus.ToString()))
                        AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                            String.Format(ContainerData.GetMessageText("EquipmentIsNotReady")), _
                            Me.IsAutoTransfer())
                    End If

                    AVPLib.Log.avpLogger.Error(Me.JobID & " Acquire Chamber Resource failed " & eqmEquiment.Name & " " & eqmEquiment.OperationStatus.ToString())
                    blnResult = False
                Else
                    ' Check online status
                    If (blcheckOnline) Then
                        Dim objChamber As Chamber = CType(eqmEquiment, Chamber)
                        If (objChamber.ConnectionStatus <> Equipment.WorkingStatuses.On) Then
                            AVPLib.Log.schedulerLogger.Debug(pstrEquipmentName & " is disconnected.")
                            If (bAlarmIfHasError) Then
                                Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentDisconnect"), Utils.chamberID2ChamberName(eqmEquiment.Name)))
                                AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                String.Format(ContainerData.GetMessageText("EquipmentDisconnect"), _
                                Utils.chamberID2ChamberName(eqmEquiment.Name)), _
                                Me.IsAutoTransfer())
                            End If
                            blnResult = False
                            GoTo end_func
                        End If
                        If (Not AVPParentControlJob.IsCycleInATMMode AndAlso eqmEquiment.ControlStatus <> Equipment.ControlStatuses.ONLINE) Then
                            AVPLib.Log.schedulerLogger.Debug(pstrEquipmentName & " is Offline.")
                            If (bAlarmIfHasError) Then
                                Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentOffline"), _
                                Utils.chamberID2ChamberName(eqmEquiment.Name)))
                                AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                String.Format(ContainerData.GetMessageText("EquipmentOffline"), _
                                Utils.chamberID2ChamberName(eqmEquiment.Name)), _
                                Me.IsAutoTransfer())
                            End If
                            blnResult = False
                            GoTo end_func
                        End If
                    End If

                    'Check for CJ Batch processing mode in Waiting 
                    If (AVPParentControlJob.JobManager.CJBatchProcessing) Then
                        If (eqmEquiment.OperationStatus = Equipment.OperationStatuses.WAITING AndAlso m_blnIsAutoTransfer) Then
                            If (eqmEquiment.ProcessingWaferFlow <> m_strWaferFlowName OrElse _
                                (eqmEquiment.CurrentWaferCount >= BatchProcessCount AndAlso eqmEquiment.GetCountWaferIsProcessing() >= BatchProcessCount)) Then
                                ShowAlarmFullWaferSlot(pstrEquipmentName, bAlarmIfHasError)
                                blnResult = False
                                GoTo end_func
                            End If
                        ElseIf (eqmEquiment.OperationStatus = Equipment.OperationStatuses.READY) Then
                            eqmEquiment.ProcessingWaferFlow = m_strWaferFlowName
                        End If
                    End If

                    ' Check wafer inside chamber status
                    If (eqmEquiment.GetWaferInfo(SlotID) IsNot Nothing AndAlso _
                        blcheckWaferStatus = True AndAlso eqmEquiment.GetCountWaferIsProcessing < SlotID) Then
                        blnResult = False
                        ShowAlarmFullWaferSlot(pstrEquipmentName, bAlarmIfHasError)
                        GoTo end_func
                    End If

                    'Batch mode
                    If (AVPParentControlJob.JobManager.CJBatchProcessing) Then
                        If (m_blnIsAutoTransfer) Then
                            ' We check if having wafers in chamber, if yes, in this case those wafers are in middle of moving to other chamber or return to LL.
                            If HaveWafersAtNextSlotsInChamber(eqmEquiment, SlotID) AndAlso eqmEquiment.GetCountWaferIsProcessing <= 0 Then
                                AVPLib.Log.schedulerLogger.Error("Previous wafer in chamber hasn't been moved yet. Can't acquired resourse for " & JobID)
                                blnResult = False
                                GoTo end_func
                            End If
                            'check Equipment Capacity and Batch process count
                            If (eqmEquiment.IsFullWaferCapacity OrElse eqmEquiment.CurrentWaferCount >= BatchProcessCount) _
                            AndAlso eqmEquiment.GetCountWaferIsProcessing() >= BatchProcessCount Then
                                'FUll -> change equipment status -> buzy
                                eqmEquiment.OperationStatus = Equipment.OperationStatuses.BUSY
                            Else 'Not FUll -> continue waiting for full
                                eqmEquiment.OperationStatus = Equipment.OperationStatuses.WAITING
                            End If
                        Else 'manual transfer wafer on batch mode
                            If (eqmEquiment.IsFullWaferCapacity) Then
                                eqmEquiment.OperationStatus = Equipment.OperationStatuses.BUSY
                            Else
                                eqmEquiment.OperationStatus = Equipment.OperationStatuses.WAITING
                            End If
                        End If
                    Else
                        eqmEquiment.OperationStatus = Equipment.OperationStatuses.BUSY
                    End If

                    ' Allocate this chamber for this PJ.
                    AVPLib.Log.schedulerLogger.Error("PJ-" & JobID & " successfully accquired the chamber " & pstrEquipmentName)
                    AddChamberToAllocatedWFResources(eqmEquiment.Name)
                End If
                AVPLib.Log.coreLogger.Info("Leave InnerAcquireChamberResource")
end_func:
                Return blnResult
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
        End Function

        Private Function HaveWafersAtNextSlotsInChamber(ByVal eqmEquiment As Equipment, ByVal currentSlotForAcquiredResourceInChamber As Integer) As Boolean
            Try
                For i As Integer = currentSlotForAcquiredResourceInChamber + 1 To eqmEquiment.WaferCapacity
                    Dim objWaferInfo As AVPWaferInfo = eqmEquiment.GetWaferInfo(i)
                    If objWaferInfo IsNot Nothing Then
                        Return True
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return False
        End Function

        Private Sub ShowAlarmFullWaferSlot(ByVal pstrEquipmentName As String, ByVal bAlarmIfHasError As Boolean)
            Try
                Dim eqmEquiment As Equipment = EquipmentManager.GetEquipment(pstrEquipmentName)
                AVPLib.Log.schedulerLogger.Debug(pstrEquipmentName & " already has a wafer.")
                If (bAlarmIfHasError) Then
                    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentHasWafer"), Utils.chamberID2ChamberName(eqmEquiment.Name)))

                    AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                        String.Format(ContainerData.GetMessageText("EquipmentHasWafer"), _
                        Utils.chamberID2ChamberName(eqmEquiment.Name)), _
                        Me.IsAutoTransfer())
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

        End Sub
        ' - Processing Chamber(strEquipmentName): Chamber 1, Chamber 2, ... Chamber n
        Private Function ReleaseChamberResource(ByVal strEquipmentName As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter releaseResource")
            AVPLib.Log.schedulerLogger.Debug("RELEASING STATION RESOURCE: " & strEquipmentName)
            SyncLock (m_lockChamberResources)
                Try
                    Dim eqmEquiment As Equipment = Nothing

                    eqmEquiment = EquipmentManager.GetEquipment(strEquipmentName)

                    If (eqmEquiment Is Nothing) Then
                        Return False
                    End If

                    If m_curAllocatedWFResources.Contains(strEquipmentName) Then
                        'make sure equipment is free -> change to ready
                        'or abort job -> equipment -> ready
                        'or stop job -> equipment -> ready
                        If ((eqmEquiment.WaferInside = DataManagerment.Equipment.WorkingStatuses.Off) OrElse _
                        AbortInProcess = True OrElse StopInProcess = True OrElse Not IsAutoTransfer) Then
                            eqmEquiment.OperationStatus = Equipment.OperationStatuses.READY
                        Else
                            AVPLib.Log.avpLogger.Error(Me.JobID & " Failed to ReleaseChamberResource " & strEquipmentName)

                            For index As Integer = 1 To eqmEquiment.WaferCapacity
                                Dim wafer As AVPWaferInfo = eqmEquiment.GetWaferInfo(index)
                                If (wafer IsNot Nothing) Then
                                    AVPLib.Log.avpLogger.Error(eqmEquiment.Name & " SlotID=" & index & ",Has a wafer" & ",WaferStatus=" & wafer.WaferStatus.ToString)
                                Else
                                    AVPLib.Log.avpLogger.Error(eqmEquiment.Name & " SlotID=" & index & ",Empty")
                                End If

                            Next

                        End If

                        AVPLib.Log.schedulerLogger.Debug("RELEASED STATION RESOURCE SUCCESSFULLY: " & strEquipmentName)
                        RemoveChamberFromAllocatedWFResources(strEquipmentName)
                    End If

                    AVPLib.Log.schedulerLogger.Info("Leave releaseResource")
                Catch ex As Exception
                    AVPLib.Log.schedulerLogger.Error(ex.ToString())
                    Return False
                End Try
                Return True
            End SyncLock
        End Function

        Public Function AcquireChamberResource(ByVal chName As String, ByVal SlotID As Integer, Optional ByVal blcheckOnline As Boolean = True, _
                                               Optional ByVal blcheckWaferStatus As Boolean = True, Optional ByVal bAlarmIfHasError As Boolean = False) As Boolean
            Try
                SyncLock (m_lockChamberResources)
                    Dim eqmEquiment As Equipment = Nothing
                    If chName.StartsWith(AlignerID) Then ' Aligner
                        eqmEquiment = EquipmentManager.GetEquipment(chName)
                        If (eqmEquiment Is Nothing) Then
                            Return False
                        End If
                        If (IsAutoTransfer And (eqmEquiment.OperationStatus <> Equipment.OperationStatuses.READY)) Then
                            AVPLib.Log.schedulerLogger.Debug(chName & " is not ready, its status " & eqmEquiment.OperationStatus.ToString())
                            If (bAlarmIfHasError) Then
                                Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentNotWorkProperly"), _
                                                     Utils.chamberID2ChamberName(chName), eqmEquiment.OperationStatus.ToString()))

                                AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                    String.Format(ContainerData.GetMessageText("EquipmentNotWorkProperly"), _
                                    Utils.chamberID2ChamberName(eqmEquiment.Name)), _
                                    Me.IsAutoTransfer())
                            End If
                            Return False
                        End If
                        If (blcheckOnline) Then
                            ' Default: Aligner is always online.
                        End If
                        If (blcheckWaferStatus) AndAlso Not IsSelfAligner Then
                            If (eqmEquiment.WaferInside = Equipment.WorkingStatuses.On) Then
                                AVPLib.Log.schedulerLogger.Debug(chName & " already has a wafer.")
                                If (bAlarmIfHasError) Then
                                    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentHasWafer"), _
                                                         Utils.chamberID2ChamberName(chName)))

                                    AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                    String.Format(ContainerData.GetMessageText("EquipmentHasWafer"), _
                                    Utils.chamberID2ChamberName(eqmEquiment.Name)), _
                                    Me.IsAutoTransfer())
                                End If
                                Return False
                            End If
                        End If
                        AddChamberToAllocatedWFResources(AlignerID)
                        AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " successfully accquired the resource " & chName)
                        Return True
                    ElseIf chName.StartsWith(RobotArmID) Then ' RobotArm
                        eqmEquiment = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                        If (eqmEquiment Is Nothing) Then
                            Return False
                        End If
                        If (IsAutoTransfer And (eqmEquiment.OperationStatus <> Equipment.OperationStatuses.READY)) Then
                            AVPLib.Log.schedulerLogger.Error(eqmEquiment.Name & " is not ready, its status " & eqmEquiment.OperationStatus.ToString())
                            If (bAlarmIfHasError) Then
                                Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentNotWorkProperly"), _
                                                     Utils.chamberID2ChamberName(eqmEquiment.Name), eqmEquiment.OperationStatus.ToString()))
                                AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                    String.Format(ContainerData.GetMessageText("EquipmentNotWorkProperly"), _
                                    Utils.chamberID2ChamberName(eqmEquiment.Name)), _
                                    Me.IsAutoTransfer())
                            End If
                            Return False
                        End If
                        ' Check online status
                        If (blcheckOnline) Then
                            ' Default: RobotArm is always online.
                        End If
                        ' Check wafer inside chamber status
                        If (blcheckWaferStatus) Then
                            If (eqmEquiment.WaferInside = Equipment.WorkingStatuses.On) Then
                                AVPLib.Log.schedulerLogger.Error(eqmEquiment.Name & " already has a wafer.")
                                If (bAlarmIfHasError) Then
                                    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentHasWafer"), Utils.chamberID2ChamberName(eqmEquiment.Name)))
                                    AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                    String.Format(ContainerData.GetMessageText("EquipmentHasWafer"), _
                                    Utils.chamberID2ChamberName(eqmEquiment.Name)), _
                                    Me.IsAutoTransfer())
                                End If
                                Return False
                            End If
                        End If
                        AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " successfully accquired the resource " & chName)
                        Return True
                    ElseIf chName.StartsWith(LoadLockID) Then ' LoadLock(A|B),SlotN
                        Dim strRegExp As String = "^(LoadLock[AB]),Slot(\d+)"
                        Dim mtcMatch As Match = Regex.Match(chName, strRegExp)
                        Dim LoadLockName As String = mtcMatch.Groups(1).Value
                        Dim strSlot As String = mtcMatch.Groups(2).Value
                        eqmEquiment = EquipmentManager.GetEquipment(LoadLockName)
                        If (eqmEquiment Is Nothing) Then
                            Return False
                        End If
                        If (eqmEquiment.OperationStatus <> Equipment.OperationStatuses.READY) Then
                            AVPLib.Log.schedulerLogger.Error(chName & " is not ready, its status " & eqmEquiment.OperationStatus.ToString())
                            If (bAlarmIfHasError) Then
                                Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentNotWorkProperly"), _
                                                     Utils.chamberID2ChamberName(eqmEquiment.Name), eqmEquiment.OperationStatus.ToString()))
                                AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                    String.Format(ContainerData.GetMessageText("EquipmentNotWorkProperly"), _
                                    Utils.chamberID2ChamberName(eqmEquiment.Name)), _
                                    Me.IsAutoTransfer())
                            End If
                            Return False
                        End If
                        ''check flag IsGEMPaused
                        If m_AVPControlJob.IsGEMPauseJob Then
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " was paused by GEM - " & LoadLockName)
                            Return False
                        End If
                        ' Check online status
                        If (blcheckOnline) Then
                            If (Not AVPParentControlJob.IsCycleInATMMode AndAlso eqmEquiment.ControlStatus <> Equipment.ControlStatuses.ONLINE) Then
                                AVPLib.Log.schedulerLogger.Error(LoadLockName & " is Offline.")
                                If (bAlarmIfHasError) Then
                                    'Utils.ThrowAlarm(eqmEquiment.Name & " is Offline.")
                                    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentOffline"), Utils.chamberID2ChamberName(eqmEquiment.Name)))
                                    AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                    String.Format(ContainerData.GetMessageText("EquipmentOffline"), _
                                    Utils.chamberID2ChamberName(eqmEquiment.Name)), _
                                    Me.IsAutoTransfer())
                                End If
                                Return False
                            End If
                        End If
                        ' Check wafer inside chamber status
                        Dim objLoadLock As LoadLock = CType(eqmEquiment, LoadLock)
                        Dim nSlot As Integer
                        If (Integer.TryParse(strSlot, nSlot)) AndAlso (Not IsSelfAligner) Then
                            If (blcheckWaferStatus) Then
                                ' Check if there is a wafer at the slot Nth
                                If (objLoadLock.Elevator.ListOfWaferInfo(nSlot - 1) IsNot Nothing) Then
                                    If objLoadLock.Elevator.ListOfWaferInfo(nSlot - 1).WaferStatus <> enumWaferStatus.eWaferNone Then
                                        AVPLib.Log.schedulerLogger.Error(LoadLockName & " has a wafer at the slot " & strSlot)
                                        If (bAlarmIfHasError) Then
                                            Utils.ThrowAlarm(Utils.chamberID2ChamberName(eqmEquiment.Name) & " Has a Wafer At Slot " & strSlot)
                                            AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                            Utils.chamberID2ChamberName(eqmEquiment.Name) & " Has a Wafer At Slot " & strSlot, _
                                            Me.IsAutoTransfer())
                                        End If
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                        AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " successfully accquired the resource " & chName)
                        Return True
                    ElseIf chName.StartsWith(ChamberID) Then ' This is one of Chamber 1, ...Chamber n

                        eqmEquiment = EquipmentManager.GetEquipment(chName)
                        If (eqmEquiment Is Nothing) Then
                            Return False
                        End If

                        If (m_blnIsAutoTransfer) Then
                            SlotID = eqmEquiment.GetNextFreeWaferSlotIndex()
                        End If

                        If m_curAllocatedWFResources.Contains(chName) Then
                            Dim objChamber As Chamber = CType(eqmEquiment, Chamber)

                            ' Check online status
                            If (blcheckOnline) Then
                                If (Not AVPParentControlJob.IsCycleInATMMode AndAlso eqmEquiment.ControlStatus <> Equipment.ControlStatuses.ONLINE) Then
                                    Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentDisconnect"), _
                                                     AVPLib.Utils.chamberID2ChamberName(chName)))
                                    Return False
                                End If
                                If (eqmEquiment.ControlStatus <> Equipment.ControlStatuses.ONLINE) Then
                                    AVPLib.Log.schedulerLogger.Error(chName & " is Offline.")
                                    If (bAlarmIfHasError) Then
                                        Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentOffline"), Utils.chamberID2ChamberName(chName)))
                                        AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                        String.Format(ContainerData.GetMessageText("EquipmentOffline"), _
                                        Utils.chamberID2ChamberName(eqmEquiment.Name)), _
                                        Me.IsAutoTransfer())
                                    End If
                                    Return False
                                End If
                            End If

                            ' Check wafer inside chamber status
                            If (blcheckWaferStatus AndAlso (Not IsSelfAligner) AndAlso Not CheckWaferStatusInChamber(eqmEquiment, SlotID, bAlarmIfHasError)) Then
                                Return False
                            End If
                            Return True
                        Else
                            ' Check wafer inside chamber status
                            If (blcheckWaferStatus) Then
                                If (eqmEquiment.IsFullWaferCapacity) Then
                                    Dim pJob As AVPProcessJob = Me.AVPParentControlJob.GetProcJob(eqmEquiment.GetWaferInfo(SlotID).WaferID)
                                    If (pJob Is Nothing) Then
                                        AVPLib.Log.schedulerLogger.Error(chName & " already has a wafer.")
                                        If (bAlarmIfHasError) Then
                                            Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentHasWafer"), Utils.chamberID2ChamberName(chName)))
                                            AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                            String.Format(ContainerData.GetMessageText("EquipmentHasWafer"), _
                                            Utils.chamberID2ChamberName(chName)), _
                                            Me.IsAutoTransfer())
                                            Return False
                                        End If
                                    End If
                                End If
                            End If
                            Return InnerAcquireChamberResource(chName, SlotID, blcheckOnline, blcheckWaferStatus, bAlarmIfHasError)
                        End If
                    End If
                End SyncLock
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
        End Function

        Private Function CheckWaferStatusInChamber(ByVal eqmEquiment As DataManagerment.Equipment, ByVal strSlot As String, ByVal bAlarmIfHasError As Boolean) As Boolean
            Dim blResult As Boolean = True
            Try
                If (IsAutoTransfer = False AndAlso AVPParentControlJob.JobManager.CJBatchProcessing) Then
                    Dim nSlot As Integer = 1
                    If (Integer.TryParse(strSlot, nSlot)) Then
                        If (eqmEquiment.GetWaferInfo(nSlot) IsNot Nothing) Then
                            AVPLib.Log.schedulerLogger.Error(eqmEquiment.Name & " has a wafer at the slot " & strSlot)
                            If (bAlarmIfHasError) Then
                                Utils.ThrowAlarm(Utils.chamberID2ChamberName(eqmEquiment.Name) & " Has a Wafer At Slot " & strSlot)
                                AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                                Utils.chamberID2ChamberName(eqmEquiment.Name) & " Has a Wafer At Slot " & strSlot, _
                                Me.IsAutoTransfer())
                            End If
                            Return False
                        End If
                    End If
                Else
                    If (eqmEquiment.IsFullWaferCapacity) Then
                        AVPLib.Log.schedulerLogger.Error(eqmEquiment.Name & " already has a wafer.")
                        If (bAlarmIfHasError) Then
                            Utils.ThrowAlarm(String.Format(ContainerData.GetMessageText("EquipmentHasWafer"), Utils.chamberID2ChamberName(eqmEquiment.Name)))
                            AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                            String.Format(ContainerData.GetMessageText("EquipmentHasWafer"), _
                            Utils.chamberID2ChamberName(eqmEquiment.Name)), _
                            Me.IsAutoTransfer())
                        End If
                        Return False
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
        Public Function ReleaseCurResources() As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter ReleaseCurResources")
            Dim chamber As String = Nothing
            Dim list As New List(Of String)
            For Each chamber In m_curAllocatedWFResources.Keys
                list.Add(chamber)
            Next

            For Each chamber In list
                ReleaseChamberResource(chamber)
            Next
            AVPLib.Log.schedulerLogger.Info("Leave ReleaseCurResources")
            Return True
        End Function

        Public Function AcquireTransportResourceEx() As Boolean
            Dim objRobotArm As Equipment = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
            Dim objTransferModule As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            If (objRobotArm Is Nothing) Then
                Return False
            End If

            Try
                While (Not HasTerminateRequest())
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                    If (awokenByTerminate) Then
                        ' User is aborting this Process Job.
                        AVPLib.Log.schedulerLogger.Info("Leave Move")
                        Return False
                    End If
                    ' Check TM is online.
                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTransferModule.ControlStatus <> Equipment.ControlStatuses.ONLINE) Then
                        AVPLib.Log.schedulerLogger.Debug(" AcquireTransportResourceEx: TM IS NOT OFFLINE.")
                        GoTo SLEEP_FOR_A_WHILE
                    End If
                    ' Check Robot Arm is ok.
                    If (objRobotArm.OperationStatus <> Equipment.OperationStatuses.READY) Then
                        AVPLib.Log.schedulerLogger.Debug("AcquireTransportResourceEx: " & objRobotArm.Name & " IS NOT READY, ITS STATUS IS " & objRobotArm.OperationStatus.ToString())
                        GoTo SLEEP_FOR_A_WHILE
                    End If
                    ' Check wafer inside Robot Arm.
                    If (objRobotArm.WaferInside = Equipment.WorkingStatuses.On) Then
                        AVPLib.Log.schedulerLogger.Debug("AcquireTransportResourceEx: " & objRobotArm.Name & " ALREADY HAS A WAFER.")
                        GoTo SLEEP_FOR_A_WHILE
                    End If
                    ' It's Ok to Get Robot Arm now.
                    Exit While
SLEEP_FOR_A_WHILE:
                    Const Fine_Tune_Sleep_Time As Integer = 200
                    If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                        ' User is aborting this Process Job.
                        Return False
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try

            Return AcquireTransportResource()
        End Function

        Public Function AcquireTransportResource() As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter AcquireTransportResource")
            AVPLib.Log.schedulerLogger.Debug(JobID & " is trying to accquire the transport resource.")

            Try
                If (Not m_bllockTransportResource) Then
                    Monitor.Enter(m_lockTransportResource)
                    AVPLib.Log.schedulerLogger.Debug(JobID & " accquired the transport resource.")
                    m_bllockTransportResource = True
                Else
                    AVPLib.Log.schedulerLogger.Debug(JobID & " has already accquired the transport resource.")
                End If

            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try

            AVPLib.Log.schedulerLogger.Info("Leave AcquireTransportResource")
            Return m_bllockTransportResource
        End Function

        Public Function ReleaseTransportResource() As Boolean
            AVPLib.Log.coreLogger.Info("Enter ReleaseTransportResource")
            Try
                If m_bllockTransportResource = True Then
                    Monitor.Exit(m_lockTransportResource)
                    AVPLib.Log.schedulerLogger.Debug(JobID & " released the transport resource.")
                    m_bllockTransportResource = False
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return False
        End Function

#Region "Construtor and destructor"
        Public Sub New(ByVal sequenceInfo As SequenceInfor, ByVal waferFlowName As String)
            MyBase.New(sequenceInfo.WaferInfo.WaferID, JobTypeEnum.ProcessJob)
            m_sifSequenceInfor = sequenceInfo
            m_strWaferFlowName = waferFlowName
            m_curAllocatedWFResources = New Hashtable()
            StopInProcess = False
            AbortInProcess = False
            ReturnWafer = False
            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " created.")
        End Sub
#End Region

#Region "Public method"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Move wafer based on sequence information
        ''' </summary>
        ''' <param name="SeqInfor"></param>
        ''' <remarks></remarks>
        Public Function AutoTransfer(ByVal SeqInfor As SequenceInfor) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter AutoTransfer")

            Dim blnResult As Boolean = False
            Try
                m_sifSequenceInfor = SeqInfor

                AVPLib.Log.schedulerLogger.Debug("SequenceInfor.ChamberCount:" + m_sifSequenceInfor.ChamberCount.ToString())

                If (m_sifSequenceInfor.ChamberCount > 0) Then
                    ' original slot + waferflow + return to the original slot
                    Dim lstRoute As New List(Of DBSeqStep)
                    Dim stepobj As New DBSeqStep(m_sifSequenceInfor.LoadLockName + ",Slot" + m_sifSequenceInfor.WaferInfo.SlotID.ToString(), 0)

                    lstRoute.Add(stepobj)
                    AVPLib.Log.schedulerLogger.Debug("Before update arrRoute Information")
                    AVPLib.Log.schedulerLogger.Debug(lstRoute)

                    For Each SequenceStep As AVPLib.DBSeqStep In m_sifSequenceInfor.WaferFlow
                        SequenceStep.LoadLockName = Me.m_AVPControlJob.LoadlockName
                        lstRoute.Add(SequenceStep)
                    Next

                    lstRoute.Add(stepobj)
                    m_lstRoute = lstRoute
                    m_listConvertedRoute = m_lstRoute.ConvertAll(Of String)(New Converter(Of DBSeqStep, String)( _
                    AddressOf GetStationNameFromSequenceStep))

                    AVPLib.Log.schedulerLogger.Debug("After update arrRoute Information")
                    AVPLib.Log.schedulerLogger.Debug(lstRoute)

                    m_blnIsAutoTransfer = True
                    ' Start the processing thread
                    MyBase.Start()
                    blnResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave AutoTransfer")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-5-05 </date>
        ''' </author>
        ''' <summary>
        ''' The thread proc for moving manually a wafer.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub MoveSemiAutoTransferProc()
            AVPLib.Log.schedulerLogger.Info("Enter MoveSemiAutoTransferProc")
            Try
                Dim peaProcessed As ProcessedEventArgs = Nothing
                ' If there is a wafer in RobotAram -> Alarm.
                If (m_lstRoute.Count > 0) And (m_lstRoute.Item(0).StationName.IndexOf(RobotArmID) < 0) Then
                    Dim eqpRobot As Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                    If (eqpRobot.WaferInside = Equipment.WorkingStatuses.On) Then
                        OnProcessingError("Had wafer " & eqpRobot.GetWaferInfo().WaferID & " at Robot Arm, Please return wafer at Robot Arm first.", True)
                        ' Consider this job complete.
                        OnJobComplete()
                        peaProcessed = New ProcessedEventArgs(False, m_sifSequenceInfor.WaferInfo, False, m_AVPControlJob.IsReturnFreeJob, IsSelfAligner, m_AVPControlJob.IsReturnForProcessCJ)
                        RaiseEvent PJTransferCompletedEvent(Me, peaProcessed)

                        If (m_AVPControlJob.IsReturnFreeJob) Then
                            m_AVPControlJob.JobManager().AbortAllReturnFreeJob()
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                            "Return All Wafer Failed")
                            AVPLib.Utils.ShowStatusMessage("Return All Wafer Failed")
                            AVPLib.Log.schedulerLogger.Info("Leave MoveSemiAutoTransferProc")
                        End If
                        Return
                    End If
                End If

                'if return wafer and align had wafer on it
                If m_AVPControlJob.IsReturnFreeJob Then
                    Dim strSrcStation As String = m_listConvertedRoute.Item(0)
                    If (Not strSrcStation.StartsWith(ConstEnum.Equipments.Aligner.ToString)) Then

                        If RobotConfigurationValues.ALINER_VISIBLE Then
                            Dim objALigner As Aligner = EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                            If (objALigner.WaferInside = Equipment.WorkingStatuses.On) Then
                                If AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = 1 AndAlso m_AVPControlJob.LoadlockName = "LoadLockA" Then

                                    OnProcessingError("Had wafer at Aligner, Please return wafer manual", True)

                                    ' Consider this job complete.
                                    OnJobComplete()
                                    peaProcessed = New ProcessedEventArgs(False, m_sifSequenceInfor.WaferInfo, False, m_AVPControlJob.IsReturnFreeJob, IsSelfAligner, m_AVPControlJob.IsReturnForProcessCJ)
                                    RaiseEvent PJTransferCompletedEvent(Me, peaProcessed)

                                    m_AVPControlJob.JobManager().AbortAllReturnFreeJob()
                                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                    "Return All Wafer Failed")
                                    AVPLib.Utils.ShowStatusMessage("Return All Wafer Failed")
                                    AVPLib.Log.schedulerLogger.Info("Leave MoveSemiAutoTransferProc")
                                    Return
                                End If
                            End If
                        End If
                    End If
                End If

                'ONLY SHOW MESSAGE TO GUI, NOT LOG AT HERE
                'BECAUSE WHEN MESSAGETEXT CHANGED -> WRITE TO LOG
                Dim strStatus As String = String.Empty
                If IsSelfAligner Then
                    strStatus = "Self aligning at " & AVPLib.Utils.chamberID2ChamberName(m_lstRoute.Item(0).StationName) & " is running"
                Else
                    strStatus = "Start Transfer Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " From: " & _
                                    AVPLib.Utils.chamberID2ChamberName(m_lstRoute.Item(0).StationName) & _
                                    " To: " & AVPLib.Utils.chamberID2ChamberName(m_lstRoute.Item(m_lstRoute.Count - 1).StationName)
                End If

                AVPLib.Utils.ShowStatusMessage(strStatus)
                AVPLib.Utils.ShowFlashingText(strStatus, True)
                'TRUC LE 
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                     "Start Transfer Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " From: " & _
                AVPLib.Utils.chamberID2ChamberName(m_lstRoute.Item(0).StationName) & " To: " & _
                AVPLib.Utils.chamberID2ChamberName(m_lstRoute.Item(m_lstRoute.Count - 1).StationName))

                Dim result As Boolean = Move(m_lstRoute, True)

                ' Consider this job complete.
                OnJobComplete()
                peaProcessed = New ProcessedEventArgs(result, m_sifSequenceInfor.WaferInfo, False, m_AVPControlJob.IsReturnFreeJob, IsSelfAligner, m_AVPControlJob.IsReturnForProcessCJ)
                RaiseEvent PJTransferCompletedEvent(Me, peaProcessed)

                If (peaProcessed.Result = False AndAlso m_AVPControlJob.IsReturnFreeJob) Then
                    m_AVPControlJob.JobManager().AbortAllReturnFreeJob()
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                    "Transfer Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " Failed")
                    AVPLib.Utils.ShowStatusMessage("Return All Wafer Failed")
                    AVPLib.Utils.ShowFlashingText(String.Empty, True)
                    Return
                End If

                If (peaProcessed.Result = False) Then
                    If IsSelfAligner Then
                        AVPLib.Utils.ShowStatusMessage("Self-Align At " & AVPLib.Utils.chamberID2ChamberName(m_lstRoute.Item(0).StationName) & " Failed")
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                         "Self-Align At " & AVPLib.Utils.chamberID2ChamberName(m_lstRoute.Item(0).StationName) & " Failed")
                    Else
                        AVPLib.Utils.ShowStatusMessage("Transfer Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " Failed")
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                         "Transfer Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " Failed")
                    End If
                    AVPLib.Utils.ShowFlashingText(String.Empty, True)

                Else
                    If IsSelfAligner Then
                        AVPLib.Utils.ShowStatusMessage("Self-Align At " & AVPLib.Utils.chamberID2ChamberName(m_lstRoute.Item(0).StationName) & " Completed")
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                         "Self-Align At " & AVPLib.Utils.chamberID2ChamberName(m_lstRoute.Item(0).StationName) & " Completed")
                    Else
                        AVPLib.Utils.ShowStatusMessage("Transfer Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " Completed")
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                         "Transfer Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " Completed")
                    End If
                    AVPLib.Utils.ShowFlashingText(String.Empty, True)

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                IsSelfAligner = False
                IsCheckedECCLimitForSelfAligner = False
                IsPlaceAlignerForSelfAligner = False
                IsCancelMove = False
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave MoveSemiAutoTransferProc")
        End Sub

#End Region

#Region "Protected methods"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Error while processing wafer
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overridable Sub OnProcessingError(ByVal ErrorMessage As String, ByVal isPause As Boolean, Optional ByVal GemAlarmName As String = "")
            AVPLib.Log.schedulerLogger.Info("Enter OnProcessingError")
            Try
                Dim eea As New ProcessingErrorEventArgs()
                eea.Message = "Error: " + ErrorMessage
                eea.Pause = isPause

                AVPLib.Log.avpLogger.Error(JobID + " " + ErrorMessage)

                If m_sifSequenceInfor IsNot Nothing Then
                    eea.Slot = m_sifSequenceInfor.WaferInfo.SlotID
                    ' If (isPause = True) Then
                    AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Alarm, ErrorMessage, IsAutoTransfer())
                    'Else
                    'AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Warning, ErrorMessage, IsAutoTransfer())
                    ' End If
                End If
                ' For Testing Only--------------------------------
                If String.IsNullOrEmpty(GemAlarmName) Then
                    GemAlarmName = Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString)
                End If
                AVPLib.Utils.ShowFlashingText(String.Empty, False)

                Utils.ThrowAlarm(eea.Message, GemAlarmName)
                '-------------------------------------------------
                'RaiseEvent WaferProcessingErrorEvent(Me, eea)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave OnProcessingError")
        End Sub
#End Region

#Region "Private methods"
        Private Function StopAllControlJob() As Boolean
            Dim result As Boolean = False

            Try
                SyncLock AVPCore.Instance().JobManager().ListControlJob
                    Dim controlJob As AVPControlJob
                    For Each controlJob In AVPCore.Instance().JobManager().ListControlJob
                        If controlJob.IsStopInProcess Then
                            Continue For
                        End If

                        result = True

                        Dim objLoadlock As LoadLock = EquipmentManager.GetEquipment(controlJob.LoadlockName)
                        If objLoadlock IsNot Nothing Then
                            objLoadlock.StartStatus = Equipment.ProcessStatuses.START
                            Dim ctrLoadlock As LoadLockController = ControllerManager.GetController(controlJob.LoadlockName)
                            If ctrLoadlock IsNot Nothing Then
                                AVPCore.Instance().JobManager().CJCommand(ctrLoadlock.CtrlJobId, ConstEnum.CJ_CMDS.CJ_CMD_STOP)
                            End If
                        End If
                    Next
                End SyncLock
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return result
        End Function
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Move wafer along the route defined in Route
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub MoveAutoTransferProc()
            AVPLib.Log.schedulerLogger.Info("Enter MoveProc")
            Try
                If (m_lstRoute.Count > 1) Then

                    m_idxCurrentStationForPickingInRoute = 0
                    Dim blnResult As Boolean = MoveEx()

                    If AbortInProcess Then
                        If (Not ReturnWafer) Then
                            OnAbortJob()
                            Return
                        Else
                            ' Return the wafer to its source
                            OnReturnWafer()
                            Return
                        End If
                    End If

                    Dim peaProcessed As New ProcessedEventArgs(blnResult, m_sifSequenceInfor.WaferInfo, True, False, False, False)
                    RaiseEvent PJTransferCompletedEvent(Me, peaProcessed)

                    If StopInProcess Then
                        OnStopJob()
                    ElseIf blnResult Then
                        OnJobComplete()
                    End If

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave MoveProc")
        End Sub

        Private Function OnReturnWafer() As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter OnReturnWafer")
            AVPLib.Log.schedulerLogger.Debug("OnReturnWafer is called for the PJ - " & JobID)
            Try
                Dim objRobot As Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim destStation As String = m_listConvertedRoute(m_listConvertedRoute.Count - 1)
                Dim srcStation As String = m_listConvertedRoute(m_idxCurrentStationForPickingInRoute)
                If srcStation.Contains(SequenceInfor.LoadLockName) Then
                    If (objRobot.GetWaferInfo() IsNot Nothing) Then
                        ' Wafer is on Robot Arm
                        AVPLib.Log.schedulerLogger.Debug("Wafer now is in " & RobotArmID)
                        Dim strLoadLockSlot = SequenceInfor.LoadLockName & ",Slot" & objRobot.GetWaferInfo().SlotID
                        If (strLoadLockSlot = destStation) Then
                            If (Not MoveWaferHome(RobotArmID, destStation, 0)) Then
                                AVPLib.Log.schedulerLogger.Error("Failed to return wafer from " & RobotArmID & " to " & destStation)
                            End If
                        Else
                            AVPLib.Log.schedulerLogger.Debug("let it be, because it's not the responsibilty of PJob" & JobID & " return this wafer.")
                        End If
                    Else
                        ' It's already been home.
                        ' Do nothing.
                        AVPLib.Log.schedulerLogger.Debug("Wafer's already been home.")
                    End If
                ElseIf (srcStation.Contains(ChamberID)) Then
                    Dim ChamberName As String = String.Empty
                    Dim objEquipment As Equipment = EquipmentManager.GetEquipment(srcStation)

                    If (objEquipment IsNot Nothing) Then
                        Dim srcStationSlotIndex As Integer = objEquipment.GetWaferSlotIndex(Me.JobID)

                        If (objEquipment.GetWaferInfo(srcStationSlotIndex) IsNot Nothing) Then
                            ' Wafer stays in Chamber or Aligner
                            AVPLib.Log.schedulerLogger.Debug("Wafer now is in " & srcStation)
                            If (Not MoveWaferHome(srcStation, destStation, srcStationSlotIndex)) Then
                                AVPLib.Log.schedulerLogger.Error("Failed to return wafer from " & srcStation & " to " & destStation)
                            End If
                        Else
                            If (objRobot.GetWaferInfo() IsNot Nothing) Then
                                ' Wafer is on Robot Arm
                                AVPLib.Log.schedulerLogger.Debug("Wafer now is in " & RobotArmID)
                                If (Not MoveWaferHome(RobotArmID, destStation, 0)) Then
                                    AVPLib.Log.schedulerLogger.Error("Failed to return wafer from " & RobotArmID & " to " & destStation)
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Debug("Wafer's in unknown place, just abort normally.")
                            End If
                        End If
                    Else
                        AVPLib.Log.schedulerLogger.Debug("Wafer's in unknown place, just abort normally.")
                    End If
                Else
                    Dim objEquipment As Equipment = EquipmentManager.GetEquipment(srcStation)
                    If (objEquipment IsNot Nothing) Then
                        Dim srcStationSlotIndex As Integer = objEquipment.GetWaferSlotIndex(Me.JobID)
                        If (objEquipment.GetWaferInfo(srcStationSlotIndex) IsNot Nothing) Then
                            ' Wafer stays in Chamber or Aligner
                            AVPLib.Log.schedulerLogger.Debug("Wafer now is in " & srcStation)
                            If (Not MoveWaferHome(srcStation, destStation, srcStationSlotIndex)) Then
                                AVPLib.Log.schedulerLogger.Error("Failed to return wafer from " & srcStation & " to " & destStation)
                            End If
                        Else
                            If (objRobot.GetWaferInfo() IsNot Nothing) Then
                                ' Wafer is on Robot Arm
                                AVPLib.Log.schedulerLogger.Debug("Wafer now is in " & RobotArmID)
                                If (Not MoveWaferHome(RobotArmID, destStation, 0)) Then
                                    AVPLib.Log.schedulerLogger.Error("Failed to return wafer from " & RobotArmID & " to " & destStation)
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Debug("Wafer's in unknown place, just abort normally.")
                            End If
                        End If
                    Else
                        AVPLib.Log.schedulerLogger.Debug("Wafer's in unknown place, just abort normally.")
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave OnReturnWafer")
            Return OnAbortJob()
        End Function

#Region "Return All Wafers"
        ' Destination must be LoadLockA|B,SlotN
        Private Function PickFromRobotArmOnReturn(ByVal Source As String, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromRobotArmOnReturn")
            Dim blnResult As Boolean = False
            Try
                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False

                Const CHECK_PRESSURE_STEP As Integer = 1
                Const PICK_WAFER_STEP As Integer = 2

                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)

                Dim strRegExp As String = "^(LoadLock[AB]),Slot"
                Dim mtcMatch As Match = Regex.Match(Destination, strRegExp)
                Dim LoadLockName As String = mtcMatch.Groups(1).Value

                ' Wafer Movement Log
                If (objRobot IsNot Nothing) AndAlso (objRobot.GetWaferInfo() IsNot Nothing) Then
                    LogPickWaferMovement(objRobot.GetWaferInfo().WaferID, Source)
                End If

                While (ReturnWafer AndAlso (Not blnIsTaskFished))

                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso _
                    Destination.IndexOf(LoadLockID) >= 0 AndAlso Not objTMController.IsStationOnline(LoadLockName)) Then
                        If (m_blnIsAutoTransfer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False

                            Dim check As Boolean = False
                            Dim strPressureError As String = String.Empty
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer
                            If (Destination.IndexOf(LoadLockID) >= 0) Then
                                check = objTMController.CheckCG10DifferenceFromStation(LoadLockName, _
                                                                                       bCheckSetPointTransferPresssure, _
                                                                                       AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            Else
                                check = True
                            End If
                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError("Move wafer home: " & strPressureError, True)
                                End If

                                Exit While
                            End If
                        Case PICK_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP.")
                            blnIsError = False
                            ControllerManager.SetWaferInsideStation(Source, "Off", Nothing, True) 'Wafer disappear inside robot
                            blnIsTaskFished = True
                            blnResult = True
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, _
                                AVPLib.ContainerData.LogSource.AVPMainScreen, "Pick Completed")

                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromRobotArmOnReturn")
            Return blnResult
        End Function

        ' Destination must be LoadLockA|B,SlotN
        Private Function PickFromAlignerOnReturn(ByVal Source As String, _
                                         ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromAlignerOnReturn")
            Dim blnResult As Boolean = False
            Try
                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False

                Const CHECK_PRESSURE_STEP As Integer = 1
                Const PICK_WAFER_STEP As Integer = 2

                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)

                Dim strRegExp As String = "^(LoadLock[AB]),Slot"
                Dim mtcMatch As Match = Regex.Match(Destination, strRegExp)
                Dim LoadLockName As String = mtcMatch.Groups(1).Value

                ' Wafer Movement Log
                If objAligner IsNot Nothing Then
                    LogPickWaferMovement(objAligner.GetWaferInfo().WaferID, Source)
                End If

                While (ReturnWafer AndAlso (Not blnIsTaskFished))
                    If (Not m_bllockTransportResource AndAlso Not AcquireTransportResourceEx()) Then
                        Continue While
                    End If

                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso _
                    Destination.IndexOf(LoadLockID) >= 0 AndAlso Not objTMController.IsStationOnline(LoadLockName)) Then
                        If (m_blnIsAutoTransfer And Not ReturnWafer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False

                            Dim check As Boolean = False
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer And Not ReturnWafer
                            Dim strPressureError As String = String.Empty
                            If (Destination.IndexOf(LoadLockID) >= 0) Then
                                check = objTMController.CheckCG10DifferenceFromStation(LoadLockName, _
                                                                                       bCheckSetPointTransferPresssure, _
                                                                                       AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            Else
                                check = True
                            End If
                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError("Move wafer home: " & strPressureError, True)
                                End If

                                Exit While
                            End If
                            ''<check sensor from config file>
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_BEFORE_PICK.")
                            If RobotConfigurationValues.CHECKSENSOR_BEFOREPICK Then
                                If Not Utils.CheckAllSensorOff And RobotConfigurationValues.DEBUGMODE = False Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: all sensors are not off", False)
                                    Exit While
                                End If
                            End If
                            ''<check sensor from config file>
                        Case PICK_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP.")
                            blnIsError = False

                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim objAlignerController As AlignerController = ControllerManager.GetController(ConstEnum.Equipments.Aligner.ToString())
                            Dim check As Boolean = False
                            '--------------------------------------------------------------------------------------
                            Dim strErr As String = ctrRobot.PickWaferFromStation(Source, IsAutoTransfer, IsReturnWafer)
                            check = IIf(strErr = String.Empty, True, False) 'Aligner, current_pos and previous_pos.
                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                objRobot.SetWaferInfo()
                                ControllerManager.SetWaferInsideAligner("On", objAligner.GetWaferInfo(), True)
                                OnProcessingError("Move wafer home: pick from " & Utils.chamberID2ChamberName(Source) & ". " & strErr, True, _
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                Exit While
                            Else
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, _
                                    AVPLib.ContainerData.LogSource.AVPMainScreen, "Pick Completed")

                                Dim LoadLockData As DataManagerment.LoadLock = CType(EquipmentManager.GetEquipment(LoadLockA_STR), DataManagerment.LoadLock)
                                Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)

                                Dim eqpAligner As Aligner = EquipmentManager.GetEquipment(Source)
                                objRobot.SetWaferInfo(eqpAligner.GetWaferInfo())
                                eqpAligner.SetWaferInfo()

                                objRobot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                AVPLib.ContainerData.LogSource.Aligner, "Wafer Out")
                                ControllerManager.SetWaferInsideSrc_Dst(Equipments.Aligner.ToString(), _
                                                                        Equipments.Robot.ToString(), _
                                                                        objRobot.GetWaferInfo())
                                blnIsTaskFished = True
                                blnResult = True
                            End If
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromAlignerOnReturn")
            Return blnResult
        End Function

        Private Function PickFromChamberMultiSlotsOnReturn(ByVal Source As String, ByVal slotID As Integer, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromChamberMultiSlotsOnReturn")
            Dim blResult As Boolean = False
            Try
                Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Source)
                If (objChamber IsNot Nothing) Then
                    Dim objChamberConfig As SystemModule = ContainerData.GetRobotConfig(objChamber.Name)
                    If objChamberConfig IsNot Nothing Then
                        'PVD4
                        If (objChamberConfig.Type = SystemModule.ModuleType.PVD4) Then
                            If (m_blnIsAutoTransfer) Then
                                slotID = objChamber.GetWaferSlotIndex(JobID)
                            End If
                            blResult = PickFromCoronaChamberOnReturn(Source, slotID, Destination)
                            ''PVD5T
                        ElseIf objChamberConfig.Type = SystemModule.ModuleType.PVD5T Then
                            If (m_blnIsAutoTransfer) Then
                                slotID = objChamber.GetWaferSlotIndex(JobID)
                            End If
                            blResult = PickFromPVD5TChamberOnReturn(Source, slotID, Destination)
                        Else
                            blResult = PickFromChamberOnReturn(Source, Destination)
                            'ADD MORE CHAMBER MULTY SLOT HERE
                            'USED FOR FUTURE
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamberMultiSlotsOnReturn")
            Return blResult
        End Function
        Private Function PickFromCoronaChamberOnReturn(ByVal Source As String, ByVal slotID As Integer, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromChamber")
            Dim blnResult As Boolean = False
            Dim srcChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Source)
            Dim objCoronaChamber As CoronaChamber = CType(srcChamber, CoronaChamber)
            Dim blIsMoveLiftToDown As Boolean = False
            'Const HOME_INDEX_POSITION As Integer = 1
            Try
                Dim blnIsTaskFished As Boolean = False
                Dim blnIsError = False

                Dim chamberConfig As SystemModule = Nothing

                Dim objTransferModule As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
                Dim objRobotController As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)


                Dim intStep = 1
                Dim CHECK_PRESSURE_STEP As Integer = 1
                Dim VERIFY_MOTION_INITIALIZED As Integer = 2
                'Move table lift home
                Dim MOVE_TABLE_HOME As Integer = 3
                'check rotation table at wafer position and sub stable is up
                Dim CHECK_ROTATION_TABLE_POSITION As Integer = 4
                'rotate table to station X
                Dim MOVE_TABLE_TO_STATION_X As Integer = 5
                'Move sublift up 
                Dim MOVE_TABLE_UP As Integer = 6
                Dim CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE As Integer = 7
                'all thing is ready -> open slit valve
                Dim OPEN_SPLITVALVE_STEP As Integer = 8
                Dim PICK_WAFER_STEP As Integer = 9
                'move Table
                Dim MOVE_TABLE_DOWN As Integer = 10
                Dim MAKE_ROBOT_GO_TO_LOADLOCK As Integer = 11
                Dim CLOSE_SPLITVALVE_STEP As Integer = 12


                While (ReturnWafer AndAlso (Not blnIsTaskFished))
                    AVPLib.Log.avpLogger.Debug(Me.JobID + " Pick Return Wafer with Block Transport Resource: " & m_bllockTransportResource.ToString())

                    If blnIsError Then
                        StepMoveCoronaSubLiftToDown(objCoronaChamber)
                    End If

                    If (Not CheckWaferAtAligner(Destination)) Then
                        If (m_blnIsAutoTransfer) Then

                            Const Fine_Tune_Sleep_Time As Integer = 200
                            Thread.Sleep(Fine_Tune_Sleep_Time)

                            Continue While
                        Else
                            OnProcessingError("Aligner has a wafer, can not pick wafer from " & Source, True)
                            Return False
                        End If
                    End If

                    If (Not IsHighestPriorityOnSource(Source, slotID)) Then
                        If (m_blnIsAutoTransfer) Then
                            'release for highest priority
                            ReleaseTransportResource()
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            Thread.Sleep(Fine_Tune_Sleep_Time)

                            Continue While
                        End If
                    End If

                    If (Not m_bllockTransportResource AndAlso Not AcquireTransportResourceEx()) Then
                        Continue While
                    End If

                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso Not objTMController.IsStationOnline(Source)) Then
                        If (m_blnIsAutoTransfer And Not ReturnWafer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    If blnIsError Then
                        blnIsError = False
                    End If

                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer And Not ReturnWafer
                            Dim check As Boolean = True
                            Dim strPressureError As String = String.Empty
                            check = objTMController.CheckCG10DifferenceFromStation(Source, _
                                                                                   bCheckSetPointTransferPresssure, _
                                                                                   AVPParentControlJob.IsCycleInATMMode, strPressureError)

                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError("Move wafer home: " & strPressureError, False)
                                End If
                                Exit While
                            End If
                            ''<check sensor from config file>
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_BEFORE_PICK.")
                            If RobotConfigurationValues.CHECKSENSOR_BEFOREPICK Then
                                If Not Utils.CheckAllSensorOff() And RobotConfigurationValues.DEBUGMODE = False Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: all sensors are not off", False)
                                    Exit While
                                End If
                            End If
                        Case VERIFY_MOTION_INITIALIZED
                            If Not (StepVerifyMotionStopped(objCoronaChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to wait for" + Utils.chamberID2ChamberName(Source) + " Motion stop", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    Exit While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                        Case MOVE_TABLE_HOME
                            'Move Table Lift go to Home
                            If Not (StepMoveCoronaTableLiftToHome(objCoronaChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Table to Home Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamberOnReturn")
                                        Return False
                                    End If
                                    blnIsError = True
                                    Exit While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                        Case CHECK_ROTATION_TABLE_POSITION
                            'check current slot
                            If (CType(srcChamber, CoronaChamber).Substrate_Current_Station = slotID AndAlso _
                                CType(srcChamber, CoronaChamber).SetSubStrateLiftUpDownStatus(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)) Then
                                intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                            Else
                                intStep = MOVE_TABLE_TO_STATION_X - 1
                            End If
                        Case MOVE_TABLE_TO_STATION_X
                            'if table is moving -> continue wait for motor
                            ContinueWaitMotor(objCoronaChamber)
                            'Special case for Go to Slot 1 because it call macro home.
                            'Take very long time to finish motion. Sleep 5s because backend keep 
                            'slot table 5s before update to GUI.
                            'If (slotID = HOME_INDEX_POSITION) Then
                            Thread.Sleep(6000) 'WAIT MORE 5S
                            'End If

                            'if not at position -> send goto position
                            If (Not objCoronaChamber.IsSubStrateTableAtPosition(slotID)) Then

                                'Move SubStrate go Down
                                If Not (StepMoveCoronaSubLiftToDown(objCoronaChamber)) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamberOnReturn")
                                            Return False
                                        End If
                                        blnIsError = True
                                        Exit While
                                    End If
                                    'Else 'Move Ok
                                    'GO TO NEXT STEP
                                End If

                                'move table go to slot X
                                If Not (StepMoveCoronaTableGoToSlot(objCoronaChamber, slotID)) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed To Rotate Substrate To Station: " & slotID, False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamberOnReturn")
                                            Return False
                                        End If
                                        blnIsError = True
                                        Exit While
                                    End If
                                End If
                                'Else -> GOTO NEXT STEP
                            End If
                        Case MOVE_TABLE_UP
                            blIsMoveLiftToDown = True
                            'Move SubLift go to Up
                            If Not (StepMoveCoronaSubLiftToUp(objCoronaChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Up Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamberOnReturn")
                                        Return False
                                    End If
                                    blnIsError = True
                                    Exit While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If

                        Case CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE.")
                            Dim strErr As String = CheckRobotIsOkToOpenSlitValve(Source)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: pick from " & Utils.chamberID2ChamberName(Source) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                Exit While
                            End If

                        Case OPEN_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, _
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & Utils.chamberID2ChamberName(Source) & " isovalve")

                            blnIsError = False
                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Source, True)
                            If (check <> String.Empty) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: failed to open " + Utils.chamberID2ChamberName(Source) + " SlitValve: " & check, False)
                                Exit While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveOpen, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        blnIsError = True
                                        blnResult = False
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        Exit While
                                    End If
                                End If
                            End If

                        Case PICK_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP.")

                            blnIsError = False
                            Dim strErr As String = String.Empty
                            Dim check As Boolean = False

                            If IsTableHome(objCoronaChamber) Then
                                ' Wafer Movement Log
                                If (srcChamber IsNot Nothing) AndAlso (srcChamber.GetWaferInfo(slotID) IsNot Nothing) Then
                                    LogPickWaferMovement(srcChamber.GetWaferInfo(slotID).WaferID, Source)
                                End If

                                strErr = objRobotController.PickWaferFromStation(Source, IsAutoTransfer, IsReturnWafer, False)
                                check = IIf(strErr = String.Empty, True, False)
                            Else
                                strErr = "Table is not Home Position"
                            End If

                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: pick from " & Utils.chamberID2ChamberName(Source) & ". " & strErr, False, _
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                Exit While
                            End If

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, _
                                AVPLib.ContainerData.LogSource.AVPMainScreen, "Pick Completed")

                            'Dat Cao, Note: Need to review this 
                            If (srcChamber.WaferInside = DataManagerment.Equipment.WorkingStatuses.Off) Then
                                Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), Source) ' Update PM State to IDLE
                            End If

                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP.")

                            'End counting wafer process time
                            srcChamber.GetWaferInfo(slotID).EndCountingWaferProcessTime()

                            ' Have wafer inside robot
                            objRobot.SetWaferInfo(srcChamber.GetWaferInfo(slotID))
                            ControllerManager.SetWaferInsideSrc_Dst(srcChamber.Name, Equipments.Robot.ToString(), objRobot.GetWaferInfo(), slotID, 1)

                            Dim strCustomWaferId As String = Utils.GetGEMWaferID(objCoronaChamber.GetWaferInfo(slotID).WaferID)
                            objCoronaChamber.Last_Wafer_Out = strCustomWaferId

                            'Update MaterialProcessingState by Dat Cao
                            objRobot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                            srcChamber.SetWaferInfo(Nothing, slotID)
                            AVPLib.Business.ControllerManager.SetWaferInsideChamber_without_UpdateGEM(srcChamber.Name, STR_OFF, srcChamber.GetWaferInfo(slotID), True, slotID)

                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If checkRobotRetract = False AndAlso RobotConfigurationValues.DEBUGMODE = False Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: Robot Arm is not retracted when closing SlitValve", False)
                                Exit While
                            End If

                            ' AFTER PICK WAFER SUCCESSFULLY => TRIGGER EVENT WAFER OUT
                            ' Trigger SECS/GEM Event by Dat Vo
                            ' Var Name: PMX.WaferOut
                            Business.AVPSecsGemLib.TriggerEvent(Source, "WaferOut")

                        Case MOVE_TABLE_DOWN
                            'Move SubStrate go Down
                            If Not (StepMoveCoronaSubLiftToDown(objCoronaChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamberOnReturn")
                                        Return False
                                    End If
                                    blnIsError = True
                                    Exit While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                            blIsMoveLiftToDown = False

                        Case MAKE_ROBOT_GO_TO_LOADLOCK
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MAKE_ROBOT_GO_TO_LOADLOCK.")
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.MoveRobotToLoadLock(IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError(strErr, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamberOnReturn")
                                    Return False
                                End If
                                blnIsError = True
                                blnResult = False
                                Exit While
                            End If

                        Case CLOSE_SPLITVALVE_STEP
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & Utils.chamberID2ChamberName(Source) & " isovalve")
                            Dim strError As String = CheckRobotIsOkToCloseSlitValve(Source)
                            If strError <> String.Empty AndAlso RobotConfigurationValues.DEBUGMODE = False Then
                                OnProcessingError(strError, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamberOnReturn")
                                    Return False
                                End If
                                blnIsError = True
                                blnResult = False
                                JobPause()
                                Exit While
                            End If

                            strError = ChamberUtility.OpenCloseSlitValve(Source, False)
                            If (strError <> String.Empty) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: failed to close " + Utils.chamberID2ChamberName(Source) + " SlitValve", False)
                                Exit While
                            Else
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveClose, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        blnIsError = True
                                        blnResult = False
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        Exit While
                                    End If
                                End If
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                            End If

                            'move table go to slot X + 1
                            StepMoveNextSlot(objCoronaChamber, slotID, True)

                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " IS RELEASING THE CHAMBER: " & srcChamber.Name)
                            If (srcChamber.WaferInside = DataManagerment.Equipment.WorkingStatuses.Off) Then
                                ReleaseChamberResource(srcChamber.Name)
                            End If
                            ' Finally we get there.
                            blnIsTaskFished = True
                            blnResult = True
                            Exit While
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If (blIsMoveLiftToDown) Then
                    StepMoveCoronaSubLiftToDown(objCoronaChamber)
                End If
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
            Return blnResult
        End Function

        Private Function PickFromPVD5TChamberOnReturn(ByVal Source As String, ByVal slotID As Integer, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromChamber")
            Dim blnResult As Boolean = False
            Dim srcChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Source)
            Dim objPVD5TChamber As PVD5TChamber = CType(srcChamber, PVD5TChamber)
            Dim blIsMoveLiftToDown As Boolean = False
            'Const HOME_INDEX_POSITION As Integer = 1
            Try
                Dim blnIsTaskFished As Boolean = False
                Dim blnIsError = False

                Dim chamberConfig As SystemModule = Nothing

                Dim objTransferModule As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
                Dim objRobotController As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)


                Dim intStep = 1
                Dim CHECK_PRESSURE_STEP As Integer = 1
                Dim VERIFY_MOTION_INITIALIZED As Integer = 2
                'Move table lift home
                Dim MOVE_TABLE_HOME As Integer = 3
                'check rotation table at wafer position and sub stable is up
                Dim CHECK_ROTATION_TABLE_POSITION As Integer = 4
                'rotate table to station X
                Dim MOVE_TABLE_TO_STATION_X As Integer = 5
                'Move sublift up 
                Dim MOVE_TABLE_UP As Integer = 6
                Dim CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE As Integer = 7
                'all thing is ready -> open slit valve
                Dim OPEN_SPLITVALVE_STEP As Integer = 8
                Dim PICK_WAFER_STEP As Integer = 9
                'move Table
                Dim MOVE_TABLE_DOWN As Integer = 10
                Dim MAKE_ROBOT_GO_TO_LOADLOCK As Integer = 11
                Dim CLOSE_SPLITVALVE_STEP As Integer = 12


                While (ReturnWafer AndAlso (Not blnIsTaskFished))
                    AVPLib.Log.avpLogger.Debug(Me.JobID + " Pick Return Wafer with Block Transport Resource: " & m_bllockTransportResource.ToString())

                    If blnIsError Then
                        StepMovePVD5TSubLiftToDown(objPVD5TChamber)
                    End If

                    If (Not CheckWaferAtAligner(Destination)) Then
                        If (m_blnIsAutoTransfer) Then

                            Const Fine_Tune_Sleep_Time As Integer = 200
                            Thread.Sleep(Fine_Tune_Sleep_Time)

                            Continue While
                        Else
                            OnProcessingError("Aligner has a wafer, can not pick wafer from " & Source, True)
                            Return False
                        End If
                    End If

                    If (Not IsHighestPriorityOnSource(Source, slotID)) Then
                        If (m_blnIsAutoTransfer) Then
                            'release for highest priority
                            ReleaseTransportResource()
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            Thread.Sleep(Fine_Tune_Sleep_Time)

                            Continue While
                        End If
                    End If

                    If (Not m_bllockTransportResource AndAlso Not AcquireTransportResourceEx()) Then
                        Continue While
                    End If

                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso Not objTMController.IsStationOnline(Source)) Then
                        If (m_blnIsAutoTransfer And Not ReturnWafer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    If blnIsError Then
                        blnIsError = False
                    End If

                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer And Not ReturnWafer
                            Dim check As Boolean = True
                            Dim strPressureError As String = String.Empty
                            check = objTMController.CheckCG10DifferenceFromStation(Source,
                                                                                   bCheckSetPointTransferPresssure,
                                                                                   AVPParentControlJob.IsCycleInATMMode, strPressureError)

                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError("Move wafer home: " & strPressureError, False)
                                End If
                                Exit While
                            End If
                            ''<check sensor from config file>
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_BEFORE_PICK.")
                            If RobotConfigurationValues.CHECKSENSOR_BEFOREPICK Then
                                If Not Utils.CheckAllSensorOff() And RobotConfigurationValues.DEBUGMODE = False Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: all sensors are not off", False)
                                    Exit While
                                End If
                            End If
                        Case VERIFY_MOTION_INITIALIZED
                            If Not (StepVerifyMotionStopped(objPVD5TChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to wait for" + Utils.chamberID2ChamberName(Source) + " Motion stop", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    Exit While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                        Case MOVE_TABLE_HOME
                            'Move Table Lift go to Home
                            If Not (StepMovePVD5TTableLiftToHome(objPVD5TChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Table to Home Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamberOnReturn")
                                        Return False
                                    End If
                                    blnIsError = True
                                    Exit While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                        Case CHECK_ROTATION_TABLE_POSITION
                            'check current slot
                            If (CType(srcChamber, PVD5TChamber).Substrate_Current_Station = slotID AndAlso
                                CType(srcChamber, PVD5TChamber).SetSubStrateLiftUpDownStatus(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)) Then
                                intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                            Else
                                intStep = MOVE_TABLE_TO_STATION_X - 1
                            End If
                        Case MOVE_TABLE_TO_STATION_X
                            'if table is moving -> continue wait for motor
                            PVD5TContinueWaitMotor(objPVD5TChamber)
                            'Special case for Go to Slot 1 because it call macro home.
                            'Take very long time to finish motion. Sleep 5s because backend keep 
                            'slot table 5s before update to GUI.
                            'If (slotID = HOME_INDEX_POSITION) Then
                            Thread.Sleep(6000) 'WAIT MORE 5S
                            'End If

                            'if not at position -> send goto position
                            If (Not objPVD5TChamber.IsSubStrateTableAtPosition(slotID)) Then

                                'Move SubStrate go Down
                                If Not (StepMovePVD5TSubLiftToDown(objPVD5TChamber)) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamberOnReturn")
                                            Return False
                                        End If
                                        blnIsError = True
                                        Exit While
                                    End If
                                    'Else 'Move Ok
                                    'GO TO NEXT STEP
                                End If

                                'move table go to slot X
                                If Not (StepMovePVD5TTableGoToSlot(objPVD5TChamber, slotID)) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed To Rotate Substrate To Station: " & slotID, False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamberOnReturn")
                                            Return False
                                        End If
                                        blnIsError = True
                                        Exit While
                                    End If
                                End If
                                'Else -> GOTO NEXT STEP
                            End If
                        Case MOVE_TABLE_UP
                            blIsMoveLiftToDown = True
                            'Move SubLift go to Up
                            If Not (StepMovePVD5TSubLiftToUp(objPVD5TChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Up Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamberOnReturn")
                                        Return False
                                    End If
                                    blnIsError = True
                                    Exit While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If

                        Case CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE.")
                            Dim strErr As String = CheckRobotIsOkToOpenSlitValve(Source)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: pick from " & Utils.chamberID2ChamberName(Source) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                Exit While
                            End If

                        Case OPEN_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                   AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & Utils.chamberID2ChamberName(Source) & " isovalve")
                            blnIsError = False
                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Source, True)
                            If (check <> String.Empty) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: failed to open " + Utils.chamberID2ChamberName(Source) + " SlitValve: " & check, False)
                                Exit While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveOpen, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        blnIsError = True
                                        blnResult = False
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        Exit While
                                    End If
                                End If
                            End If
                        Case PICK_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP.")

                            blnIsError = False
                            Dim strErr As String = String.Empty
                            Dim check As Boolean = False

                            If PVD5TIsTableHome(objPVD5TChamber) Then
                                ' Wafer Movement Log
                                If (srcChamber IsNot Nothing) AndAlso (srcChamber.GetWaferInfo(slotID) IsNot Nothing) Then
                                    LogPickWaferMovement(srcChamber.GetWaferInfo(slotID).WaferID, Source)
                                End If

                                strErr = objRobotController.PickWaferFromStation(Source, IsAutoTransfer, IsReturnWafer, False)
                                check = IIf(strErr = String.Empty, True, False)
                            Else
                                strErr = "Table is not Home Position"
                            End If

                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: pick from " & Utils.chamberID2ChamberName(Source) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                Exit While
                            End If

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                AVPLib.ContainerData.LogSource.AVPMainScreen, "Pick Completed")

                            'Dat Cao, Note: Need to review this 
                            If (srcChamber.WaferInside = DataManagerment.Equipment.WorkingStatuses.Off) Then
                                Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), Source) ' Update PM State to IDLE
                            End If

                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP.")

                            'End counting wafer process time
                            srcChamber.GetWaferInfo(slotID).EndCountingWaferProcessTime()

                            ' Have wafer inside robot
                            objRobot.SetWaferInfo(srcChamber.GetWaferInfo(slotID))
                            ControllerManager.SetWaferInsideSrc_Dst(srcChamber.Name, Equipments.Robot.ToString(), objRobot.GetWaferInfo(), slotID, 1)

                            Dim strCustomWaferId As String = Utils.GetGEMWaferID(objPVD5TChamber.GetWaferInfo(slotID).WaferID)
                            objPVD5TChamber.Last_Wafer_Out = strCustomWaferId

                            'Update MaterialProcessingState by Dat Cao
                            objRobot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                            srcChamber.SetWaferInfo(Nothing, slotID)
                            AVPLib.Business.ControllerManager.SetWaferInsideChamber_without_UpdateGEM(srcChamber.Name, STR_OFF, srcChamber.GetWaferInfo(slotID), True, slotID)

                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If checkRobotRetract = False AndAlso RobotConfigurationValues.DEBUGMODE = False Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: Robot Arm is not retracted when closing SlitValve", False)
                                Exit While
                            End If

                            ' AFTER PICK WAFER SUCCESSFULLY => TRIGGER EVENT WAFER OUT
                            ' Trigger SECS/GEM Event by Dat Vo
                            ' Var Name: PMX.WaferOut
                            Business.AVPSecsGemLib.TriggerEvent(Source, "WaferOut")

                        Case MOVE_TABLE_DOWN
                            'Move SubStrate go Down
                            If Not (StepMovePVD5TSubLiftToDown(objPVD5TChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamberOnReturn")
                                        Return False
                                    End If
                                    blnIsError = True
                                    Exit While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                            blIsMoveLiftToDown = False

                        Case MAKE_ROBOT_GO_TO_LOADLOCK
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MAKE_ROBOT_GO_TO_LOADLOCK.")
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.MoveRobotToLoadLock(IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            ' [0004886] Wait up to 10s for robot to confirm arrival at Loadlock Station 1 before proceeding.
                            If check Then
                                Try
                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": Wait 10s for Robot to go to Station 1.")
                                    Dim isArrived As Boolean = WaitOnCondition(AddressOf IsRobotAtLoadlockPosition, 10000, True)
                                    If Not isArrived Then
                                        check = False
                                        strErr = "Failed to wait for Robot at Station 1"
                                    End If
                                Catch ex As Exception
                                    AVPLib.Log.avpLogger.Error("Wait PVD5T GoToLoadlock: " & ex.ToString())
                                End Try
                            End If

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError(strErr, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamberOnReturn")
                                    Return False
                                End If
                                blnIsError = True
                                blnResult = False
                                Exit While
                            End If

                        Case CLOSE_SPLITVALVE_STEP
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & Utils.chamberID2ChamberName(Source) & " isovalve")

                            Dim strError As String = CheckRobotIsOkToCloseSlitValve(Source)
                            If strError <> String.Empty AndAlso RobotConfigurationValues.DEBUGMODE = False Then
                                OnProcessingError(strError, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamberOnReturn")
                                    Return False
                                End If
                                blnIsError = True
                                blnResult = False
                                JobPause()
                                Exit While
                            End If

                            strError = ChamberUtility.OpenCloseSlitValve(Source, False)
                            If (strError <> String.Empty) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: failed to close " + Utils.chamberID2ChamberName(Source) + " SlitValve", False)
                                Exit While
                            Else
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveClose, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        blnIsError = True
                                        blnResult = False
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        Exit While
                                    End If
                                End If
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                            End If

                            'move table go to slot X + 1
                            StepPVD5TMoveNextSlot(objPVD5TChamber, slotID, True)

                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " IS RELEASING THE CHAMBER: " & srcChamber.Name)
                            If (srcChamber.WaferInside = DataManagerment.Equipment.WorkingStatuses.Off) Then
                                ReleaseChamberResource(srcChamber.Name)
                            End If
                            ' Finally we get there.
                            blnIsTaskFished = True
                            blnResult = True
                            Exit While
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If (blIsMoveLiftToDown) Then
                    StepMovePVD5TSubLiftToDown(objPVD5TChamber)
                End If
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
            Return blnResult
        End Function
        Private Function PickFromChamberOnReturn(ByVal Source As String, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromChamber")
            Dim blnResult As Boolean = False
            Try
                Dim blnIsTaskFished As Boolean = False
                Dim blnIsError = False

                Dim chamberConfig As SystemModule = Nothing
                Dim srcChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Source)
                Dim objTransferModule As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
                Dim objRobotController As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)

                ' Wafer Movement Log
                If (srcChamber IsNot Nothing) AndAlso (srcChamber.GetWaferInfo() IsNot Nothing) Then
                    LogPickWaferMovement(srcChamber.GetWaferInfo().WaferID, Source)
                End If
                ''PLEASE ADD NOTE HERE IF CHANGE FLOW
                ''IBE FLOW:
                'CHECK PRESSURE ->CHECK MOTION OFF ->CLAMP UP ->VERIFY CLAMP UP ->MOTION INITIALIZE ->VERIFY MOTION(2minutes) ->OPEN SLITVALVE ->PICK WAFER->CLOSE SLITVALVE
                ''''''''''''''''->CHECK MOTION ON ->OPEN SLITVALVE ->PICK WAFER -> CLOSE SLITVALVE
                ''PVD FLOW:
                'CHECK PRESSURE ->OPEN SHUTTER ->VERIFY OPEN SHUTTER ->MOVE CHUCK TO ZERO ->VERIFY CHUCK ->UNCLAMP ->VERIFY UNCLAMP -> OPEN SLITVALVE ->PICK WAFER ->CLOSE SLITVALVE
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim intStep = 1
                Dim CHECK_PRESSURE_STEP As Integer = 1
                Dim IBE_CLAMP_UP As Integer = 2
                Dim IBE_VERIFY_CLAMP_UP As Integer = 3
                Dim MOTION_INITIALIZE As Integer = 4
                Dim VERIFY_MOTION_INITIALIZE As Integer = 5
                Dim OPEN_SHUTTER As Integer = 6
                Dim VERIFY_OPEN_SHUTTER As Integer = 7
                Dim MOVE_CHUCK_TO_ZERO As Integer = 8
                Dim VERIFY_CHUCK_POSITION As Integer = 9
                Dim PVD_UNCLAMP As Integer = 10
                Dim PVD_VERIFY_UNCLAMP As Integer = 11
                Dim CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE As Integer = 12
                Dim OPEN_SPLITVALVE_STEP As Integer = 13
                Dim PICK_WAFER_STEP As Integer = 14
                Dim MAKE_ROBOT_GO_TO_LOADLOCK As Integer = 15
                Dim CLOSE_SPLITVALVE_STEP As Integer = 16

                While (ReturnWafer AndAlso (Not blnIsTaskFished))
                    AVPLib.Log.avpLogger.Error("Pick Return Wafer with Block Transport Resource: " & m_bllockTransportResource.ToString())

                    If (Not CheckWaferAtAligner(Destination)) Then
                        If (m_blnIsAutoTransfer) Then

                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            OnProcessingError("Aligner has a wafer, can not pick wafer from " & Source, True)
                            Return False
                        End If
                    End If

                    If (Not m_bllockTransportResource AndAlso Not AcquireTransportResourceEx()) Then
                        Continue While
                    End If

                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso Not objTMController.IsStationOnline(Source)) Then
                        If (m_blnIsAutoTransfer And Not ReturnWafer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If


                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer And Not ReturnWafer
                            Dim check As Boolean = True
                            Dim strPressureError As String = String.Empty
                            check = objTMController.CheckCG10DifferenceFromStation(Source,
                                                                                   bCheckSetPointTransferPresssure,
                                                                                   AVPParentControlJob.IsCycleInATMMode, strPressureError)

                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError("Move wafer home: " & strPressureError, False)
                                End If
                                Exit While
                            End If
                            ''<check sensor from config file>
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_BEFORE_PICK.")
                            If RobotConfigurationValues.CHECKSENSOR_BEFOREPICK Then
                                If Not Utils.CheckAllSensorOff() And RobotConfigurationValues.DEBUGMODE = False Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: all sensors are not off", False)
                                    Exit While
                                End If
                            End If
                        Case IBE_CLAMP_UP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": IBE_CLAMP_UP.")
                            blnIsError = False
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(srcChamber.Name) ' Get the configuration
                            If chamberConfig.Type = AVPLib.SystemModule.ModuleType.IBE Then
                                ''check motion off''
                                If (srcChamber.Initialize_Motion_readback <> Equipment.WorkingStatuses.On) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    ''send clamp Up if UnClamp
                                    Dim ibeChamber As IBEChamber = CType(srcChamber, IBEChamber)
                                    ''clamp status is On = clamp up
                                    If (ibeChamber.ClampStatus <> Equipment.WorkingStatuses.On) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                        If Not (IBEUtility.Fixture_Clamp(srcChamber.Name, ConfigurationValues.DEVICE_CLAMP_UP)) Then
                                            OnProcessingError("Move wafer home: " & Utils.chamberID2ChamberName(Source) + " can not send command to clamp up", False)
                                            blnIsError = True
                                            Exit While
                                        End If
                                    Else ''go to step MOTION_INITIALED IF CLAMP UP
                                        intStep = MOTION_INITIALIZE - 1
                                    End If
                                ElseIf (srcChamber.Initialize_Motion_readback = Equipment.WorkingStatuses.On) Then
                                    ''go to step OPEN_SPLITVALVE_STEP
                                    intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                                ''if PVD jump to Open shutter
                            ElseIf chamberConfig.Type = SystemModule.ModuleType.PVD Then
                                intStep = OPEN_SHUTTER - 1
                            End If

                        Case IBE_VERIFY_CLAMP_UP
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(srcChamber.Name) ' Get the configuration
                            If chamberConfig.Type = AVPLib.SystemModule.ModuleType.IBE Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": IBE_VERIFY_CLAMP_UP.")
                                blnIsError = False
                                Dim TimeForVerifyClampUp As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig(
                                                                         ConstEnum.CLAMP_UP_WAIT_TIME_IN_SECONDS, 30)
                                If Not CheckAndWaitForClampUp(CType(srcChamber, IBEChamber), TimeForVerifyClampUp) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: " & Utils.chamberID2ChamberName(Source) + " can not send Unclamp command to IBE", False)
                                    Exit While
                                End If
                            End If

                        Case MOTION_INITIALIZE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MOTION_INITIALIZE.")
                            blnIsError = False
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(srcChamber.Name) ' Get the configuration
                            If chamberConfig.Type = AVPLib.SystemModule.ModuleType.IBE Then
                                ''check motion initialize
                                If (srcChamber.Initialize_Motion_readback <> Equipment.WorkingStatuses.On) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    ' Do not send command if motion is initializing
                                    If CType(srcChamber, IBEChamber).Initializing_Motion_readback <> Equipment.WorkingStatuses.On Then

                                        ''send command to initialze motion
                                        If Not IBEUtility.Initialize_Motion(srcChamber.Name, ConfigurationValues.DEVICE_STATUS_OPEN) Then

                                            blnIsError = True
                                            blnResult = False
                                            OnProcessingError("Move wafer home: " & Utils.chamberID2ChamberName(Source) + " can not send Motion Initialize command to IBE", False)
                                            Exit While
                                        End If
                                    Else
                                        intStep = VERIFY_MOTION_INITIALIZE - 1
                                    End If
                                Else
                                    intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            End If
                        Case VERIFY_MOTION_INITIALIZE
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.IBE Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_MOTION_INITIALIZE.")
                                blnIsError = False
                                Dim TimeForVerifyMotionInitialize As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig(
                                                                             ConstEnum.MOTION_INITIALZE_WAIT_TIME_IN_SECONDS, 2 * 60) '2 minutes
                                If Not CheckAndWaitForMotionInitialize(srcChamber, TimeForVerifyMotionInitialize) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: " & Utils.chamberID2ChamberName(Source) + " can not send Motion Initialize command to IBE", False)
                                    Exit While
                                Else ''GO DIRECTLY TO OPEN SLITVALVE
                                    intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Error("DO NOT HAVE MOTION INITIALIZE")
                            End If

                        Case OPEN_SHUTTER
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SHUTTER.")
                            blnIsError = False
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(srcChamber.Name) ' Get the configuration
                            'FIX ISSUE THAT SUPPORT BOTH PVD AND IBE
                            'Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                            'If PVD we need to open shutter
                            'If IBE we need to open shutter too
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                'check if shutter is installed -> need to Open shutter,else skip this step
                                If chamberConfig.ShutterVisible AndAlso Not (srcChamber.IsShutterOpen()) Then
                                    If Not (PVDUtility.Shutter_Valve(srcChamber.Name, ConfigurationValues.DEVICE_STATUS_OPEN.ToString())) Then
                                        blnIsError = True
                                        blnResult = False
                                        OnProcessingError("Move wafer home: " & Utils.chamberID2ChamberName(Source) + " can not send command to open shutter", False)

                                        Exit While
                                    End If
                                Else 'if Shutter is already Opened
                                    intStep = MOVE_CHUCK_TO_ZERO - 1
                                End If
                            Else
                                intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                            End If
                        Case VERIFY_OPEN_SHUTTER
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_OPEN_SHUTTER.")
                            blnIsError = False
                            'Dim srcPVDChamber As PVDChamber = CType(srcChamber, PVDChamber)
                            Dim TimeForOpenShutter As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig(
                                                                     ConstEnum.OPEN_SHUTTER_WAIT_TIME_IN_SECONDS, 30)
                            Const MinimumSleepTimeInSeconds As Integer = 1
                            Dim quotaInSeconds As Integer = TimeForOpenShutter
                            Dim bCheckResult As Boolean = False
                            While (ReturnWafer AndAlso (quotaInSeconds >= 0))
                                If Not srcChamber.IsShutterOpen() Then
                                    Thread.Sleep(MinimumSleepTimeInSeconds * 1000)
                                    quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                                    Continue While
                                Else
                                    bCheckResult = True
                                    Exit While
                                End If
                            End While
                            If (ReturnWafer AndAlso (Not bCheckResult)) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: " & Utils.chamberID2ChamberName(Source) + " open shutter failed", False)
                                Exit While
                            End If

                            If (srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.IBE) Then
                                'Go directly to OPEN_SPLITVALVE_STEP, ignore the move chuck step
                                intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                            End If

                        Case MOVE_CHUCK_TO_ZERO
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MOVE_CHUCK_TO_ZERO.")
                                blnIsError = False
                                'only PVD have chuck, so that the convertion is OK
                                Dim srcPVDChamber As PVDChamber = CType(srcChamber, PVDChamber)
                                If Not (CInt(srcPVDChamber.ChuckPos_Readback) = 0) Then
                                    If Not (PVDUtility.Chuck_Pos2(srcPVDChamber.Name, Chuck_Zero_Distant)) Then
                                        blnIsError = True
                                        blnResult = False
                                        OnProcessingError("Move wafer home: " & Utils.chamberID2ChamberName(Source) + " can not send command to move chuck to zero", False)
                                        Exit While
                                    End If
                                Else 'if Chuck distant is already Zero
                                    intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Error("DO NOT HAVE CHUCK TO OPEN")
                            End If
                        Case VERIFY_CHUCK_POSITION
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_CHUCK_POSITION.")
                                blnIsError = False
                                'only PVD have chuck, so that the convertion is OK
                                Dim srcPVDChamber As PVDChamber = CType(srcChamber, PVDChamber)
                                Dim TimeForMoveChuckToZero As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig(
                                                                        ConstEnum.MOVING_CHUCK_TO_ZERO_WAIT_TIME_IN_SECONDS, 30)
                                Const MinimumSleepTimeInSeconds As Integer = 1
                                Dim quotaInSeconds As Integer = TimeForMoveChuckToZero
                                Dim bCheckResult As Boolean = False
                                While (ReturnWafer AndAlso (quotaInSeconds >= 0))
                                    If Not (CInt(srcPVDChamber.ChuckPos_Readback) = 0) Then
                                        Thread.Sleep(MinimumSleepTimeInSeconds * 1000)
                                        quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                                        Continue While
                                    Else
                                        bCheckResult = True
                                        Exit While
                                    End If
                                End While
                                If (ReturnWafer AndAlso (Not bCheckResult)) Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: " & Utils.chamberID2ChamberName(Source) + " move chuck to Zero failed.", False)
                                    Exit While
                                Else
                                    Utils.ShowStatusMessage("Move wafer home: " & srcPVDChamber.Name & " have already moved chuck to zero.")
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Error("DO NOT HAVE CHUCK TO OPEN")
                            End If
                        Case PVD_UNCLAMP
                            'AVP.  Manual transfer/scheduling.   If PVD had flowcool/clamp installed,   we need to unclamp also before transferring wafer out.
                            Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                            Dim objChamberConfig As SystemModule = ContainerData.GetRobotConfig(srcChamber.Name)
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD AndAlso objChamberConfig.ClampInstalled Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": UNCLAMP TO PICK WAFER FROM CHAMBER.")
                                blnIsError = False
                                If Not (pvdChamber.ClampStatus_Readback = Equipment.WorkingStatuses.Off) Then ''not unclamp
                                    ''send unclamp
                                    If Not PVDUtility.Clamp_UnClamp_Status(srcChamber.Name, ConfigurationValues.DEVICE_STATUS_CLOSED) _
                                      And (RobotConfigurationValues.DEBUGMODE = False) Then
                                        blnIsError = True
                                        blnResult = False
                                        OnProcessingError("Move wafer home: " & Utils.chamberID2ChamberName(Source) + " can not send Unclamp command to PVD", False)
                                        Exit While
                                    End If
                                Else 'if already Unclamp
                                    intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            Else 'If Clamp is not install -> move over these steps 
                                intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1 '
                                AVPLib.Log.schedulerLogger.Error("DO NOT UNCLAMP TO PICK WAFER FROM CHAMBER")
                            End If

                        Case PVD_VERIFY_UNCLAMP
                            'AVP.  Manual transfer/scheduling.   If PVD had flowcool/clamp installed,   we need to unclamp also before transferring wafer out.
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_UNCLAMP_PVD.")
                                blnIsError = False
                                Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                                Dim TimeForVerifyUnClamp As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig(
                                      ConstEnum.PVD_UNCLAMP_WAIT_TIME_IN_SECONDS, RobotConfigurationValues.PVD_UNCLAMP_WAIT_TIME)
                                If Not CheckAndWaitForUnClamp(pvdChamber, TimeForVerifyUnClamp) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: " & Utils.chamberID2ChamberName(Source) + " can not send Unclamp command to PVD", False)
                                    Exit While
                                Else
                                    Utils.ShowStatusMessage("Move wafer home: " & Utils.chamberID2ChamberName(Source) & " have already unclamped.")
                                End If
                            Else
                                intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1 '
                                AVPLib.Log.schedulerLogger.Error("DO NOT UNCLAMP TO PICK WAFER FROM CHAMBER")
                            End If

                        Case CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE.")
                            Dim strErr As String = CheckRobotIsOkToOpenSlitValve(Source)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)
                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: " & Utils.chamberID2ChamberName(Source) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                Exit While
                            End If

                        Case OPEN_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                   AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & Utils.chamberID2ChamberName(Source) & " isovalve")

                            blnIsError = False
                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Source, True)
                            If (check <> String.Empty) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: failed to open " + Utils.chamberID2ChamberName(Source) + " SlitValve: " & check, False)
                                Exit While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveOpen, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        blnIsError = True
                                        blnResult = False
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        Exit While
                                    End If
                                End If
                            End If
                        Case PICK_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP.")
                            blnIsError = False
                            Dim strErr As String = objRobotController.PickWaferFromStation(Source, IsAutoTransfer, IsReturnWafer, False)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)
                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: pick from " & Utils.chamberID2ChamberName(Source) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                Exit While
                            End If

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                AVPLib.ContainerData.LogSource.AVPMainScreen, "Pick Completed")

                            Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), Source) ' Update PM State to IDLE
                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP.")

                            'End counting wafer process time
                            srcChamber.GetWaferInfo().EndCountingWaferProcessTime()

                            ' Have wafer inside robot
                            objRobot.SetWaferInfo(srcChamber.GetWaferInfo())
                            ControllerManager.SetWaferInsideSrc_Dst(srcChamber.Name, Equipments.Robot.ToString(), objRobot.GetWaferInfo())

                            'Update MaterialProcessingState by Dat Cao
                            objRobot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES

                            srcChamber.SetWaferInfo()

                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If checkRobotRetract = False AndAlso RobotConfigurationValues.DEBUGMODE = False Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: Robot Arm is not retracted when closing SlitValve", False)
                                Exit While
                            End If

                            ' AFTER PICK WAFER SUCCESSFULLY => TRIGGER EVENT WAFER OUT
                            ' Trigger SECS/GEM Event by Dat Vo
                            ' Var Name: PMX.WaferOut
                            Business.AVPSecsGemLib.TriggerEvent(Source, "WaferOut")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & Utils.chamberID2ChamberName(Source) & " isovalve")

                            Dim strError As String = ChamberUtility.OpenCloseSlitValve(Source, False)
                            If (strError <> String.Empty) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: failed to close " + Utils.chamberID2ChamberName(Source) + " SlitValve", False)
                                Exit While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveClose, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        blnIsError = True
                                        blnResult = False
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        Exit While
                                    End If
                                End If
                            End If

                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " IS RELEASING THE CHAMBER: " & srcChamber.Name)
                            ReleaseChamberResource(srcChamber.Name)
                            ' Finally we get there.
                            blnIsTaskFished = True
                            blnResult = True
                            Exit While
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
            Return blnResult
        End Function

        Private Function PlaceIntoLoadLockOnReturn(ByVal Source As String, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PlaceToLoadLock")

            Dim blnResult As Boolean = False
            Dim LoadLockName As String = String.Empty
            Dim Slot As String = String.Empty
            GetLoadLockNameAndSlot(Destination, LoadLockName, Slot)
            Dim objTransferModule As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(LoadLockName)
            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
            Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
            Dim objLoadLockController As LoadLockController = CType(ControllerManager.GetController(LoadLockName), LoadLockController)
            Dim objElevatorController As LLElevatorController = CType(objLoadLockController.ChildController.Item("LLElevator"), LLElevatorController)
            Dim objRobotController As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
            ' Wafer Movement Log
            If (objRobot IsNot Nothing) AndAlso (objRobot.GetWaferInfo() IsNot Nothing) Then
                LogPlaceWaferMovement(objRobot.GetWaferInfo().WaferID, Destination)
            End If
            Try
                Dim blnIsTaskFished As Boolean = False
                Dim blnIsError = False

                Const CHECK_PRESSURE_STEP As Integer = 1
                Const CHECK_WAFER_PRESENT_STEP As Integer = 2
                Const GO_TO_SLOT_STEP As Integer = 3
                Const OPEN_SPLITVALVE_STEP As Integer = 4
                Const PLACE_WAFER_STEP As Integer = 5
                'Const CLOSE_SPLITVALVE_STEP As Integer = 6

                Dim intStep = CHECK_PRESSURE_STEP

                While (ReturnWafer AndAlso (Not blnIsTaskFished))

                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso Not objTMController.IsStationOnline(LoadLockName)) Then
                        If (m_blnIsAutoTransfer And Not ReturnWafer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer And Not ReturnWafer
                            Dim check As Boolean = True
                            Dim strPressureError As String = String.Empty
                            check = objTMController.CheckCG10DifferenceFromStation(LoadLockName, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError("Move wafer home: " & strPressureError, True)
                                End If
                                Exit While
                            End If
                        Case CHECK_WAFER_PRESENT_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_WAFER_PRESENT_STEP.")
                            blnIsError = False
                            ' Check wafer inside chamber status
                            Dim nSlot As Integer = -1
                            If (Integer.TryParse(Slot, nSlot)) Then
                                ' Check if there is a wafer at the slot Nth
                                If (objLoadLock.Elevator.ListOfWaferInfo(nSlot - 1) IsNot Nothing) Then
                                    If objLoadLock.Elevator.ListOfWaferInfo(nSlot - 1).WaferStatus <> enumWaferStatus.eWaferNone Then
                                        blnIsError = True
                                        OnProcessingError(LoadLockName & " has a wafer at the slot " & Slot, True)
                                        blnResult = False
                                        Exit While
                                    End If
                                End If
                            End If
                            If (RobotConfigurationValues.ALINER_VISIBLE) Then
                                ''check Aligner wafer present
                                Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                                If objAligner.GetWaferInfo() IsNot Nothing Then
                                    AVPLib.Log.schedulerLogger.Debug("Has wafer at aligner")
                                    ''Aligner has wafer on the left and place to LLA
                                    If (AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = 1 AndAlso _
                                                                   objLoadLock.Name = ConstEnum.Equipments.LoadLockA.ToString()) Then
                                        AVPLib.Log.schedulerLogger.Debug("Aligner on the left and place to LLA")
                                        OnProcessingError("Aligner has a wafer, can not place wafer to " & LoadLockName & " : " & Slot, True)
                                        blnIsError = True
                                        blnResult = False
                                        Exit While
                                    End If
                                End If
                            End If

                        Case GO_TO_SLOT_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": GO_TO_SLOT_STEP.")
                            blnIsError = False

                            If Not (objRobot.IsCommunicating) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: Robot Communication is off", True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                    Return False
                                End If
                                Exit While
                            End If

                            If Not (objRobot.IsRetracted AndAlso objRobot.IsReallyRetracted) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: Robot is not retracted.", True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                    Return False
                                End If
                                Exit While
                            End If

                            Dim check As Boolean = objElevatorController.WaitReadyAndGotoSlot(Slot)
                            If (Not check) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: failed GotoSlot " + LoadLockName + " " + Slot, True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                    Return False
                                End If
                                Exit While
                            End If
                        Case OPEN_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, _
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & LoadLockName & " isovalve")

                            blnIsError = False
                            Dim check As String = ChamberUtility.OpenCloseSlitValve(LoadLockName, True)
                            If (check <> String.Empty) Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: failed to open " + LoadLockName + " SlitValve: " & check, True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                    Return False
                                End If
                                Exit While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsLLSlitValveOpen, objLoadLock.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(objLoadLock.Name)
                                        blnIsError = True
                                        blnResult = False
                                        OnProcessingError("Failed to wait for " + LoadLockName + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        Exit While
                                    End If
                                End If
                            End If
                        Case PLACE_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PLACE_WAFER_STEP.")
                            blnIsError = False
                            Dim strErr As String = objRobotController.PlaceWaferToStation(LoadLockName, IsAutoTransfer, IsReturnWafer) 'LLA
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)
                            m_ErrorWhenPlaceToStation = Not check
                            If Not check Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: failed to place wafer into " & LoadLockName & ". " & strErr, True, _
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                    Return False
                                End If
                                Exit While
                            End If

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, _
                                 AVPLib.ContainerData.LogSource.AVPMainScreen, "Place Completed")

                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP.")
                            blnIsError = False

                            Dim strCustomWaferId As String = Utils.GetGEMWaferID(objRobot.GetWaferInfo().WaferID)
                            AVPSecsGemLib.UpdateSECSGEM_Variable(LoadLockName, EMSERVICELib.VarType.SV, "LastWaferIn", VALUELib.ValueType.A, strCustomWaferId)

                            'Update wafer status
                            'Bug 
                            'm_sifSequenceInfor.WaferInfo.WaferStatus = ConstEnum.enumWaferStatus.eWaferError
                            objRobot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.IN_CASSETTE_MODULE
                            ControllerManager.SetWaferInsideSrc_Dst(Equipments.Robot.ToString(), Destination, objRobot.GetWaferInfo())

                            AVPSecsGemLib.TriggerEvent(LoadLockName, "WaferIn")

                            'keep wafer info and roll back to robot when place wafer fail
                            Dim objAVPWaferInfo As AVPWaferInfo = objRobot.GetWaferInfo()

                            'set wafer at robot = nothing
                            objRobot.SetWaferInfo()

                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If checkRobotRetract = False Then
                                blnIsError = True
                                blnResult = False
                                OnProcessingError("Move wafer home: Robot Arm is not retracted when opening SlitValve", False)
                                Exit While
                            End If

                            'When place a wafer back to Llx, before closing Llx iso valve, 
                            'issue a command �A,GC,xx� then �R,WP�.  If request for wafer is OK then continue on or alarm 
                            '(�Wafer not found in LLx�) if WP is not OK.

                            Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(LoadLockName), LoadLockController)
                            Dim ctrElevator As LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)
                            Dim blnElevator_GoCheck_Error As Boolean = False
                            check = ctrElevator.CheckWaferPresent(Slot, blnElevator_GoCheck_Error)

                            AVPLib.Log.schedulerLogger.Debug("Wafer Present result:" + check.ToString())
                            If (Not check) Then
                                If Not blnElevator_GoCheck_Error Then 'need to roll back Wafer in Robot
                                    'roll back wafer to robot
                                    objRobot.SetWaferInfo(objAVPWaferInfo)
                                    ControllerManager.SetWaferInsideSrc_Dst(Destination, Equipments.Robot.ToString(), objAVPWaferInfo)
                                    OnProcessingError("Wafer not found in " + LoadLockName + " Slot " + Slot, True)
                                Else ''Assume LL Error, Wafer is still in LL
                                    OnProcessingError("Error in LoadLock " + LoadLockName + " Slot " + Slot, True)
                                End If
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLockOnReturn")
                                    Return False
                                End If
                                blnIsError = True
                                AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLockOnReturn")
                                Return False
                            End If

                            '0001010: [Khoi Ha - 06/20/2012] - LLx rough only configuration. During a schedule run after picking or placing a wafer from/to LLx, C
                            If (objLoadLock IsNot Nothing AndAlso Not objLoadLock.IsRoughOnlyMode) Then

                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                   AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & LoadLockName & " isovalve")

                                Dim strError As String = ChamberUtility.OpenCloseSlitValve(LoadLockName, False)
                                If (strError <> String.Empty) Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: failed to close " + LoadLockName + " SlitValve", True)
                                    Exit While
                                Else
                                    Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                    If Not WaitOnCondition(AddressOf Utils.IsLLSlitValveClose, objLoadLock.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                        If (RobotConfigurationValues.DEBUGMODE = False) Then
                                            ChamberUtility.UnknownSlitValve(objLoadLock.Name)
                                            blnIsError = True
                                            blnResult = False
                                            OnProcessingError("Failed to wait for " + LoadLockName + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                            Exit While
                                        End If
                                    End If
                                    ' Finally we get there.
                                    blnIsTaskFished = True
                                    blnResult = True
                                    Exit While
                                End If
                            Else
                                ' Finally we get there.
                                blnIsTaskFished = True
                                blnResult = True
                                Exit While
                            End If
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If blnResult AndAlso AVPParentControlJob.JobManager.CJBatchProcessing Then
                    Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(LoadLockName), LoadLockController)
                    If ctrLoadLock IsNot Nothing Then
                        Dim ctrElevator As LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)
                        If ctrElevator IsNot Nothing Then
                            ctrElevator.GotoNextSlot()
                        End If
                    End If
                End If
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
            Return blnResult
        End Function

        ' SrcStation maybe Aligner, Robot Arm, ChamberX
        ' HomeStation must be LoadLockA|B,SlotN
        Private Function MoveWaferHome(ByVal srcStation As String, ByVal homeStation As String, ByVal StationSlotID As Integer) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter MoveWaferHome")
            Dim bResult As Boolean = True
            Const CHECK_SET_POINT_PRESSURE_FIRST_TIME_STEP As Integer = 1
            Const ACQUIRE_TRANSPORT_RESOURCE_STEP As Integer = 2
            Const PICK_FROM_SOURCE_STEP As Integer = 3
            Const PlACE_INTO_DEST_STEP As Integer = 4
            Const END_STEP As Integer = 5

            Dim intStep = CHECK_SET_POINT_PRESSURE_FIRST_TIME_STEP

            Dim blnIsError As Boolean = False
            Dim blnIsTaskFished As Boolean = False
            Dim objRobot As Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
            Try
                While (ReturnWafer AndAlso (Not blnIsTaskFished))

                    If Not srcStation.Contains(AlignerID) AndAlso Not CheckWaferAtAligner(homeStation) Then
                        If (m_blnIsAutoTransfer) Then

                            Const Fine_Tune_Sleep_Time As Integer = 200
                            Thread.Sleep(Fine_Tune_Sleep_Time)
                            Continue While
                        Else
                            OnProcessingError("Aligner has a wafer, can not pick wafer from " & srcStation, True)
                            Return False
                        End If
                    End If

                    If (Not m_bllockTransportResource AndAlso Not AcquireTransportResourceEx()) Then
                        Continue While
                    End If
                    Select Case intStep
                        Case CHECK_SET_POINT_PRESSURE_FIRST_TIME_STEP
                            blnIsError = False
                            If srcStation.Contains(ChamberID) Then
                                ' 60 * 60 Maximize 1 Hour, this value is configurable.
                                Dim TransferSetPointWaitTimeInSeconds As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig( _
                                ConstEnum.TRANSFER_SET_POINT_WAIT_TIME_IN_SECONDS, 60 * 60)
                                Dim LoadLockNameOnReturn As String = String.Empty
                                Dim Slot As String = String.Empty
                                If GetLoadLockNameAndSlot(homeStation, LoadLockNameOnReturn, Slot) Then
                                    If Not CheckAndWaitForReachingSetPointPressureOnReturn(srcStation, LoadLockNameOnReturn, TransferSetPointWaitTimeInSeconds) Then
                                        blnIsError = True
                                        AVPLib.Log.schedulerLogger.Info("MoveWaferHome")
                                        Return False
                                    End If
                                End If
                            End If
                        Case ACQUIRE_TRANSPORT_RESOURCE_STEP
                            blnIsError = False
                            AVPLib.Log.schedulerLogger.Debug("Try to get Transport Resource to return wafer.")
                            ' This method maybe block.
                            AcquireTransportResource()
                        Case PICK_FROM_SOURCE_STEP
                            blnIsError = False
                            ' Pick happens only when wafer is at Aligner or Chamber
                            AVPLib.Log.schedulerLogger.Debug("Move wafer home: Pick from " & srcStation)
                            If srcStation.Contains(RobotArmID) Then
                                If Not PickFromRobotArmOnReturn(srcStation, homeStation) Then
                                    bResult = False
                                    Me.AVPParentControlJob.TerminateAllAbortJob()
                                    Exit While
                                End If
                            ElseIf srcStation.Contains(AlignerID) Then
                                If (objRobot.GetWaferInfo() IsNot Nothing) Then
                                    ' Wafer is on Robot Arm.
                                    AVPLib.Log.schedulerLogger.Error("Failed to return wafer from " & srcStation & " to " & homeStation & ". Because there has already been a wafer in " & RobotArmID)
                                    bResult = False
                                    Exit While
                                End If
                                If Not PickFromAlignerOnReturn(srcStation, homeStation) Then
                                    bResult = False
                                    Me.AVPParentControlJob.TerminateAllAbortJob()
                                    Exit While
                                End If
                            ElseIf srcStation.Contains(ChamberID) Then
                                If (objRobot.GetWaferInfo() IsNot Nothing) Then
                                    ' Wafer is on Robot Arm.
                                    AVPLib.Log.schedulerLogger.Error("Failed to return wafer from " & srcStation & " to " & homeStation & ". Because there has already been a wafer in " & RobotArmID)
                                    bResult = False
                                    Exit While
                                End If

                                Dim ChamberName As String = String.Empty
                                Dim iSlot As Integer = 1
                                If (AVPParentControlJob.JobManager.CJBatchProcessing AndAlso StationSlotID >= 0) Then
                                    If (Not Utils.IsChamberSlitValveClose(srcStation)) Then
                                        If StationSlotID = 1 Then
                                            Utils.ThrowAlarm("PM Isovalve Is Not Closed, Can Not Return Wafers")
                                        End If
                                        Exit While
                                    End If
                                    If Not PickFromChamberMultiSlotsOnReturn(srcStation, iSlot, homeStation) Then
                                        bResult = False
                                        Me.AVPParentControlJob.TerminateAllAbortJob()
                                        Exit While
                                    End If
                                Else
                                    If Not PickFromChamberOnReturn(srcStation, homeStation) Then
                                        bResult = False
                                        Me.AVPParentControlJob.TerminateAllAbortJob()
                                        Exit While
                                    End If
                                End If
                            Else
                                bResult = False
                                Exit While
                            End If
                        Case PlACE_INTO_DEST_STEP
                            blnIsError = False
                            ' Must be placing into LoadLock, not something else.
                            AVPLib.Log.schedulerLogger.Debug("Move wafer home: Place into " & homeStation)
                            If homeStation.Contains(LoadLockID) Then
                                If (Not PlaceIntoLoadLockOnReturn(srcStation, homeStation)) Then
                                    bResult = False
                                    Me.AVPParentControlJob.TerminateAllAbortJob()
                                    Exit While
                                End If
                            Else
                                bResult = False
                                Exit While
                            End If
                        Case END_STEP
                            blnIsTaskFished = True
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try

            AVPLib.Log.schedulerLogger.Info("Leave MoveWaferHome")
            Return bResult
        End Function
#End Region

#Region "Run Data"
        Private Function MakeChamberNameListForRunData() As List(Of String)
            Dim chamberNameListForRunData As New List(Of String)()
            Dim SeqNo As Integer = 0
            For Each station As String In m_listConvertedRoute
                If (station.StartsWith(ChamberID) OrElse station.StartsWith(AlignerID) OrElse station.StartsWith(RobotConfigurationValues.ANY_IBE_CHAMBER)) Then
                    SeqNo += 1
                    chamberNameListForRunData.Add(station & "_" & SeqNo)
                Else
                    chamberNameListForRunData.Add(station)
                End If
            Next
            Return chamberNameListForRunData
        End Function

        Private Function GetCurrentChamberNameForRunData(ByVal chamberName As String, Optional ByVal AVPWaferID As String = "") As String
            Regenerate_DataRunFolder()
            ''after appending: DataRun FileName : GEMWaferID#YY_MM_dd.....
            Dim strDataRunFile As String = m_OrgRunDataName
            ''if strDataRun
            If String.IsNullOrEmpty(m_strDataRunStartTime) Then '
                m_strDataRunStartTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")
            End If
            Dim txtRunNoMode As String = IIf(ContainerDAO.EnableRunNo, ConstEnum.DataRunFileNameSeparator & RobotConfigurationValues.RUN_SCHEDULER_NO, String.Empty)

            '''''''''''
            For idx As Integer = m_idxCurrentStationForPickingInRoute To m_chamberNameListForRunData.Count - 1
                Dim station As String = m_chamberNameListForRunData(idx)
                If station.StartsWith(chamberName) Then
                    ''get specific time 
                    If m_OrgRunDataName.Contains(TIME_WHEN_RUNNING) Then
                        strDataRunFile = m_OrgRunDataName.Replace(TIME_WHEN_RUNNING, m_strDataRunStartTime)
                    End If
                    ''append to file
                    If Not String.IsNullOrEmpty(AVPWaferID) Then

                        Dim obj As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(chamberName)

                        'Get data run for multi slot
                        If (obj IsNot Nothing AndAlso obj.WaferCapacity > 1) Then

                            Dim slotID As String = String.Empty
                            Dim GEMWaferID As String = String.Empty
                            Dim waferInfo As AVPWaferInfo = Nothing
                            For index As Integer = 1 To obj.WaferCapacity
                                waferInfo = obj.GetWaferInfo(index)
                                If (waferInfo IsNot Nothing) Then
                                    slotID = slotID & IIf(String.IsNullOrEmpty(slotID), "", "-") & waferInfo.SlotID
                                    GEMWaferID = GEMWaferID & IIf(String.IsNullOrEmpty(GEMWaferID), "", "-") & Utils.GetGEMWaferID(waferInfo.WaferID)
                                End If
                            Next

                            If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
                                strDataRunFile = strDataRunFile.Replace("$$$", slotID)
                            End If
                            Return GEMWaferID & "#" & strDataRunFile & ConstEnum.DataRunFileNameSeparator & station.Replace(chamberName, Utils.chamberID2ChamberName(chamberName)) & txtRunNoMode

                        Else 'data run for one slot
                            Return Utils.GetGEMWaferID(AVPWaferID) & "#" & strDataRunFile & ConstEnum.DataRunFileNameSeparator & station.Replace(chamberName, Utils.chamberID2ChamberName(chamberName)) & txtRunNoMode
                        End If

                    Else 'data run for other station
                        Return strDataRunFile & ConstEnum.DataRunFileNameSeparator & station.Replace(chamberName, Utils.chamberID2ChamberName(chamberName)) & txtRunNoMode
                    End If

                ElseIf station.StartsWith(AlignerID) Then
                    strDataRunFile = m_AligerDataRunFileName
                    'get specific time
                    If m_AligerDataRunFileName.Contains(TIME_WHEN_RUNNING) Then
                        strDataRunFile = m_AligerDataRunFileName.Replace(TIME_WHEN_RUNNING, m_strDataRunStartTime)
                    End If
                    'append to file
                    AVPLib.Log.coreLogger.Error(strDataRunFile & ConstEnum.DataRunFileNameSeparator & station & txtRunNoMode & ".xml")
                    Return strDataRunFile & ConstEnum.DataRunFileNameSeparator & station & txtRunNoMode & ".xml"
                End If
            Next
            Return String.Empty
        End Function

        'Truc Le Add
        Private Sub Regenerate_DataRunFolder()
            Try
                Dim strTemp As String = m_OrgRunDataName
                'Ex:Yesterday =2013_08_23 => New run is: 2013_08_24
                Dim strFolderName As String = DateTime.Now.ToString("yyyy_MM_dd")
                Dim strFolderPath As String = ContainerDAO.FPath_RunDataOfWafer & "\" & strFolderName
                'replace path: Ex:2013_08_23\xxxx -> 2013_08_23\xxxx

                ''if different day
                If Not strTemp.StartsWith(strFolderName) Then
                    If Not System.IO.Directory.Exists(strFolderPath) Then
                        Try
                            System.IO.Directory.CreateDirectory(strFolderPath)
                        Catch ex As IO.IOException
                            Utils.ThrowAlarm("Failed To Create Folder For Wafer Run Data:" & strFolderPath)
                            AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm, _
                            "Failed To Create Folder For Wafer Run Data:" & strFolderPath, _
                            Me.IsAutoTransfer())
                        End Try
                    End If
                    ''strTemp=2013_08_23\xxx =>strTemp=Today\xxx
                    Dim strYesterdayFolderName As String = DateTime.Today.AddDays(-1).ToString("yyyy_MM_dd")
                    strTemp = strTemp.Replace(strYesterdayFolderName, strFolderName)
                    m_OrgRunDataName = strTemp
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub
#End Region

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-5-05 </date>
        ''' </author>
        ''' <summary>
        ''' Convert list of DBSeqStep into list of station name.
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Function GetStationNameFromSequenceStep(ByVal sqStep As DBSeqStep) As String
            Return sqStep.StationName
        End Function

        Private Sub DivideRouteIntoAtomicSubRoute(ByVal Route As List(Of DBSeqStep), ByVal AtomicSubRoutes As List(Of List(Of DBSeqStep)))
            If (AtomicSubRoutes Is Nothing) Then
                Return
            End If
            Dim convertedRoute As List(Of String) = Route.ConvertAll(Of String)(New Converter(Of DBSeqStep, String)( _
            AddressOf GetStationNameFromSequenceStep))

            Dim ALIGNER As String = AlignerID
            Const MIN_LEN_FOR_MOVE As Integer = 2
            Try
                Dim firstAlignerIdx As Integer = convertedRoute.IndexOf(ALIGNER)
                If (firstAlignerIdx >= 0) Then
                    Dim currentAlignerIdx As Integer = firstAlignerIdx
                    Dim lastAlignerIdx As Integer = currentAlignerIdx
                    ' This loop below cares for repeated Aligner found in the flow: '...Aligner Aligner ...'
                    ' This case shouldn't be here, but for sake of safety I check it too.
                    currentAlignerIdx = convertedRoute.IndexOf(ALIGNER, (lastAlignerIdx + 1))
                    Do While (currentAlignerIdx > 0) And (currentAlignerIdx - lastAlignerIdx = 1)
                        lastAlignerIdx = currentAlignerIdx
                        currentAlignerIdx = convertedRoute.IndexOf(ALIGNER, (lastAlignerIdx + 1))
                    Loop
                    '
                    Dim subRouteHasAlignerLen = (lastAlignerIdx - firstAlignerIdx) + 1
                    If (firstAlignerIdx - 1) >= 0 Then
                        subRouteHasAlignerLen = subRouteHasAlignerLen + 1
                    End If
                    If (lastAlignerIdx + 1) <= (convertedRoute.Count - 1) Then
                        subRouteHasAlignerLen = subRouteHasAlignerLen + 1
                    End If
                    ' Body
                    Dim routeHasAligner As List(Of DBSeqStep) = Nothing
                    If (convertedRoute.Count = subRouteHasAlignerLen) Then
                        ' We are the same.
                        routeHasAligner = Route
                        ' End recursion here
                        '------------------------------------------------------------------
                        AtomicSubRoutes.Add(routeHasAligner)
                        '------------------------------------------------------------------
                    ElseIf (convertedRoute.Count > subRouteHasAlignerLen) Then ' We have more than one atomic subroute.
                        ' First
                        Dim firstRoute As List(Of DBSeqStep) = Nothing
                        ' Tail
                        Dim remainSubRoute As List(Of DBSeqStep) = Nothing
                        ' Head
                        If (firstAlignerIdx > 1) Then
                            firstRoute = Route.GetRange(0, firstAlignerIdx)
                            '
                            routeHasAligner = Route.GetRange(firstAlignerIdx - 1, subRouteHasAlignerLen)
                        ElseIf (firstAlignerIdx = 1) Then
                            routeHasAligner = Route.GetRange(firstAlignerIdx - 1, subRouteHasAlignerLen)
                        Else
                            routeHasAligner = Route.GetRange(firstAlignerIdx, subRouteHasAlignerLen)
                        End If
                        ' Tail
                        Dim remainIdx As Integer = lastAlignerIdx + 1
                        Dim remainLength = convertedRoute.Count - remainIdx
                        If (remainLength > 1) Then
                            remainSubRoute = Route.GetRange(remainIdx, remainLength)
                        End If
                        ' Divide into atomic subroutes here.
                        If (firstRoute IsNot Nothing) Then
                            Dim i As Integer = 0
                            For i = 0 To firstRoute.Count - MIN_LEN_FOR_MOVE
                                Dim subRoute As List(Of DBSeqStep) = firstRoute.GetRange(i, MIN_LEN_FOR_MOVE)
                                '------------------------------------------------------------------
                                AtomicSubRoutes.Add(subRoute)
                                '------------------------------------------------------------------
                            Next
                        End If
                        '
                        If (routeHasAligner IsNot Nothing) Then
                            '------------------------------------------------------------------
                            AtomicSubRoutes.Add(routeHasAligner)
                            '------------------------------------------------------------------
                        End If
                        '
                        If (remainSubRoute IsNot Nothing) Then
                            ' Call recursively
                            DivideRouteIntoAtomicSubRoute(remainSubRoute, AtomicSubRoutes)
                        End If
                    End If
                Else
                    Dim i As Integer = 0
                    For i = 0 To Route.Count - MIN_LEN_FOR_MOVE
                        Dim subRoute As List(Of DBSeqStep) = Route.GetRange(i, MIN_LEN_FOR_MOVE)
                        '------------------------------------------------------------------
                        AtomicSubRoutes.Add(subRoute)
                        '------------------------------------------------------------------
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
        End Sub

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-5-05 </date>
        ''' </author>
        ''' <summary>
        ''' Breaking a wafer flow into several atomic subflows.
        ''' </summary>
        ''' <remarks></remarks>
        Private Function MoveEx() As Boolean
            ' Route: LoadLockA,SlotI Aligner ChamberJ [Aligner ChamberK]* LoadLockA,SlotI
            ' Route: LoadLockA,SlotN Aligner ChamberM LoadLockA,SlotN.
            ' We assume that we always have got a valid sequence, eg.. Departing from Src ( LLA|B,SlotN ),
            ' transits at some intermediate stations Aligner or ChamberX and arriving at Dest (LLA|B SlotN)
            ' --> make a round trip.
            ' Other sequences considered invalid and it's user responsibility if there is something wrong happens

            AVPLib.Log.schedulerLogger.Info("Enter MoveEx")

            Dim bCheck As Boolean = False
            ' Currently there are two approaches here that spins around the concept 'Transport Resource'
            ' - The first: we consider 'Robot Arm' AND Aligner as an unique transport resource
            '   so if we accquire this transport resource that means we lock Robot Arm and Aligner,
            '   and if we follow this way we should split a main waferflow into sub waferflows(may has Aligner in it) in which
            '   we only lock the transport resource in each subwaferflow not the whole main waferflow for maximizing thoughput.
            ' - The second: If we consider the transport is only 'RoboArm', it's ok but it's not good because a thread that just
            '   release the lock on the transport resource is the one MUST accquire it again, in this case we should give it more
            '   time to finish, it's not necessary to yield the resource.
            Try

                Dim i As Integer = 0
                For i = 0 To m_lstSeqStep.Count - 1
                    Dim subRoute As List(Of DBSeqStep) = m_lstSeqStep.Item(i)
                    bCheck = Move(subRoute, IIf(i = 0, True, False))
                    AVPLib.Log.schedulerLogger.Info("Move Result: " + bCheck.ToString())
                    If Not bCheck Then
                        AVPLib.Log.schedulerLogger.Info("Leave MoveEx")
                        Return False
                    End If
                    If HasTerminateRequest() Then
                        AVPLib.Log.schedulerLogger.Info("Leave MoveEx")
                        Return False
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave MoveEx")
            Return bCheck
        End Function

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-22</date>
        ''' </author>
        ''' <summary>
        ''' Checking processing equipments reaching theirs transfer set point pressure.
        ''' </summary>
        Private Function AreProcessingEquipmentsReachingTransferSetPointPressure(ByVal SrcLLorChamber As String, _
        ByVal DestLLorChamber As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter AreProcessingEquipmentsReachingTransferSetPointPressure")
            Dim SrcLLOrChamberTransferSetPointPressure As Single = 0.1
            ' Source: LLA, Chamber1, Chamber2, Chamber3, Chamber4, Chamber5.
            If Not String.IsNullOrEmpty(SrcLLorChamber) Then
                Dim SrcLLorChamberPressure As Single = 0.0
                Dim eqmEquipment As Equipment = EquipmentManager.GetEquipment(SrcLLorChamber)
                If (eqmEquipment.Name.IndexOf(ConstEnum.Chamber) >= 0) Then
                    Dim objChamber As Chamber = CType(eqmEquipment, Chamber)
                    SrcLLorChamberPressure = IIf(objChamber.IGStatus = Equipment.WorkingStatuses.On, objChamber.IG, objChamber.CG)
                Else
                    Dim objLoadlLock As LoadLock = CType(eqmEquipment, LoadLock)
                    SrcLLorChamberPressure = IIf(objLoadlLock.IGStatus = Equipment.WorkingStatuses.On, objLoadlLock.IG, objLoadlLock.CG)
                End If
                SrcLLOrChamberTransferSetPointPressure = ContainerData.GetTransferSetPointPressureForStation(eqmEquipment.Name, 0.1)
                If (SrcLLorChamberPressure > SrcLLOrChamberTransferSetPointPressure) Then
                    Return False
                End If
            End If
            Dim TMTransferSetPointPressure As Single = 0.1
            ' Transfer Module.
            Dim objTransferModule As DataManagerment.CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            Dim TMPressure As Single = IIf(objTransferModule.IGStatus = Equipment.WorkingStatuses.On, objTransferModule.IG, objTransferModule.CG)
            TMTransferSetPointPressure = ContainerData.GetTransferSetPointPressureForStation(objTransferModule.Name, 0.1)
            If (TMPressure > TMTransferSetPointPressure) Then
                Return False
            End If
            Dim DestLLOrChamberTransferSetPointPressure As Single = 0.1
            ' Destination: LLA, Chamber1, Chamber2, Chamber3, Chamber4, Chamber5.
            If Not String.IsNullOrEmpty(DestLLorChamber) Then
                Dim DestLLorChamberPressure As Single = 0.0
                Dim eqmEquipment As Equipment = EquipmentManager.GetEquipment(DestLLorChamber)
                If (eqmEquipment.Name.IndexOf(ConstEnum.Chamber) >= 0) Then
                    Dim objChamber As Chamber = CType(eqmEquipment, Chamber)
                    DestLLorChamberPressure = IIf(objChamber.IGStatus = Equipment.WorkingStatuses.On, objChamber.IG, objChamber.CG)
                Else
                    Dim objLoadlLock As LoadLock = CType(eqmEquipment, LoadLock)
                    DestLLorChamberPressure = IIf(objLoadlLock.IGStatus = Equipment.WorkingStatuses.On, objLoadlLock.IG, objLoadlLock.CG)
                End If
                DestLLOrChamberTransferSetPointPressure = ContainerData.GetTransferSetPointPressureForStation(eqmEquipment.Name, 0.1)
                If (DestLLorChamberPressure > DestLLOrChamberTransferSetPointPressure) Then
                    Return False
                End If
            End If
            AVPLib.Log.schedulerLogger.Info("Leave AreProcessingEquipmentsReachingTransferSetPointPressure")
            Return True
        End Function

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-22</date>
        ''' </author>
        ''' <summary>
        ''' CheckSetPointPressure
        ''' </summary>
        ''' <param name="Route"></param>
        ''' <param name="waitTimeInSeconds"></param>
        ''' <returns></returns>
        ''' <remarks>Route is an atomic transfering, which has at most 3 stations </remarks>
        Private Function CheckAndWaitForReachingSetPointPressure(ByVal SrcLLorChamber As String, _
        ByVal DestLLorChamber As String, ByVal waitTimeInSeconds As Integer, ByVal bCheckStopInProcess As Boolean) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckAndWaitForReachingSetPointPressure")
            Try
                '---------------------------------------------Main Loop-----------------------------------------------
                Dim SrcLLOrChamberTransferSetPointPressure As Single = 0.1
                Dim TMTransferSetPointPressure As Single = 0.1
                Dim DestLLOrChamberTransferSetPointPressure As Single = 0.1

                Const MinimumSleepTimeInSeconds As Integer = 1
                Dim quotaInSeconds As Integer = IIf(waitTimeInSeconds <= 0, MinimumSleepTimeInSeconds, waitTimeInSeconds)

                While (Not HasTerminateRequest())
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                    If (awokenByTerminate) Then
                        AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForReachingSetPointPressure")
                        Return False
                    End If
                    If (bCheckStopInProcess) Then
                        If Me.StopInProcess Then
                            ' Exit this job - Do Not Continue Because Wafer Is Still In LoadLock And User Just Stops It.
                            Return False
                        End If
                    End If
                    ' Check if we have run out of time ?
                    If (quotaInSeconds < 0) Then
                        Dim strConvertedSrcLLorChamber As String = Utils.chamberID2ChamberName(SrcLLorChamber)
                        Dim strConvertedDestLLorChamber As String = Utils.chamberID2ChamberName(DestLLorChamber)

                        Dim strRelatedEquipmentsMsg As String = IIf(String.IsNullOrEmpty(strConvertedSrcLLorChamber), String.Empty, strConvertedSrcLLorChamber & ", ") & _
                        "Transfer Module" & IIf(String.IsNullOrEmpty(strConvertedDestLLorChamber), String.Empty, ", " & strConvertedDestLLorChamber)

                        ' Fire an alarm to user about waiting too long for related equipments reaching their transfer Set Point Pressure.
                        OnProcessingError("Failed to wait for related Equipments - `" & strRelatedEquipmentsMsg & _
                        "` reaching their transfer Set Point in a period of time: " & waitTimeInSeconds & " seconds.", False)
                        ' Reset Quota, in case user want to resume.
                        quotaInSeconds = IIf(waitTimeInSeconds <= 0, MinimumSleepTimeInSeconds, waitTimeInSeconds)
                        JobPause()
                        Continue While
                    End If
                    ' Source: LLA, Chamber1, Chamber2, Chamber3, Chamber4, Chamber5.
                    If Not String.IsNullOrEmpty(SrcLLorChamber) Then
                        Dim SrcLLorChamberPressure As Single = 0.0
                        Dim eqmEquipment As Equipment = EquipmentManager.GetEquipment(SrcLLorChamber)
                        If (eqmEquipment.Name.IndexOf(ConstEnum.Chamber) >= 0) Then
                            Dim objChamber As Chamber = CType(eqmEquipment, Chamber)
                            SrcLLorChamberPressure = IIf(objChamber.IGStatus = Equipment.WorkingStatuses.On, objChamber.IG, objChamber.CG)
                        Else
                            Dim objLoadlLock As LoadLock = CType(eqmEquipment, LoadLock)
                            SrcLLorChamberPressure = IIf(objLoadlLock.IGStatus = Equipment.WorkingStatuses.On, objLoadlLock.IG, objLoadlLock.CG)
                        End If
                        SrcLLOrChamberTransferSetPointPressure = ContainerData.GetTransferSetPointPressureForStation(eqmEquipment.Name, 0.1)
                        If (SrcLLorChamberPressure > SrcLLOrChamberTransferSetPointPressure) Then
                            ' Event notification: `Waits for X reaching its transfer Set Point Pressure`.
                            Utils.ShowStatusMessage("Waits for " & Utils.chamberID2ChamberName(SrcLLorChamber) & _
                            " reaching its transfer Set Point Pressure:" & SrcLLOrChamberTransferSetPointPressure & _
                            ", now its pressure is " & Format(SrcLLorChamberPressure, AVPLib.ConstEnum.SCIENTIFIC_FORMAT))
                            If SleepButAlertabletoTerminateRequest(MinimumSleepTimeInSeconds * 1000) Then
                                Return False
                            End If
                            quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                            Continue While
                        End If
                    End If
                    ' Transfer Module.
                    Dim objTransferModule As DataManagerment.CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                    Dim TMPressure As Single = IIf(objTransferModule.IGStatus = Equipment.WorkingStatuses.On, objTransferModule.IG, objTransferModule.CG)
                    TMTransferSetPointPressure = ContainerData.GetTransferSetPointPressureForStation(objTransferModule.Name, 0.1)
                    If (TMPressure > TMTransferSetPointPressure) Then
                        ' Event notification: `Waits for TM reaching its transfer Set Point Pressure`.
                        Utils.ShowStatusMessage("Waits for Transfer Module" & _
                            " reaching its transfer Set Point Pressure:" & TMTransferSetPointPressure & _
                            ", now its pressure is " & Format(TMPressure, AVPLib.ConstEnum.SCIENTIFIC_FORMAT))
                        If (SleepButAlertabletoTerminateRequest(MinimumSleepTimeInSeconds * 1000)) Then
                            Return False
                        End If
                        quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                        Continue While
                    End If
                    ' Destination: LLA, Chamber1, Chamber2, Chamber3, Chamber4, Chamber5.
                    If Not String.IsNullOrEmpty(DestLLorChamber) Then
                        Dim DestLLorChamberPressure As Single = 0.0
                        Dim eqmEquipment As Equipment = EquipmentManager.GetEquipment(DestLLorChamber)
                        If (eqmEquipment.Name.IndexOf(ConstEnum.Chamber) >= 0) Then
                            Dim objChamber As Chamber = CType(eqmEquipment, Chamber)
                            DestLLorChamberPressure = IIf(objChamber.IGStatus = Equipment.WorkingStatuses.On, objChamber.IG, objChamber.CG)
                        Else
                            Dim objLoadlLock As LoadLock = CType(eqmEquipment, LoadLock)
                            DestLLorChamberPressure = IIf(objLoadlLock.IGStatus = Equipment.WorkingStatuses.On, objLoadlLock.IG, objLoadlLock.CG)
                        End If
                        DestLLOrChamberTransferSetPointPressure = ContainerData.GetTransferSetPointPressureForStation(eqmEquipment.Name, 0.1)
                        If (DestLLorChamberPressure > DestLLOrChamberTransferSetPointPressure) Then
                            ' Event notification: `Waits for X reaching its transfer Set Point Pressure`.
                            Utils.ShowStatusMessage("Waits for " & Utils.chamberID2ChamberName(DestLLorChamber) & _
                            " reaching its transfer Set Point Pressure:" & DestLLOrChamberTransferSetPointPressure & _
                            ", now its pressure is " & Format(DestLLorChamberPressure, AVPLib.ConstEnum.SCIENTIFIC_FORMAT))
                            If (SleepButAlertabletoTerminateRequest(MinimumSleepTimeInSeconds * 1000)) Then
                                Return False
                            End If
                            quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                            Continue While
                        End If
                    End If

                    Dim strRelatedEquipments As String = IIf(String.IsNullOrEmpty(SrcLLorChamber), String.Empty, Utils.chamberID2ChamberName(SrcLLorChamber) & ", Transfer Module") & _
                    IIf(String.IsNullOrEmpty(DestLLorChamber), String.Empty, ", " & Utils.chamberID2ChamberName(DestLLorChamber))
                    Utils.ShowStatusMessage(strRelatedEquipments & " have already reached theirs transferring setpoint pressure, starting trasferring wafer.")

                    AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForReachingSetPointPressure")
                    Return True
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForReachingSetPointPressure")
            Return False
        End Function

        Private Function CheckAndWaitForReachingSetPointPressureOnReturn(ByVal srcChamber As String, _
        ByVal destLoadLock As String, ByVal waitTimeInSeconds As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckAndWaitForReachingSetPointPressureOnReturn")
            Try
                '---------------------------------------------Main Loop-----------------------------------------------
                Dim strConvertedSrcChamber As String = Utils.chamberID2ChamberName(srcChamber)
                Dim strConvertedDestLoadLock As String = Utils.chamberID2ChamberName(destLoadLock)
                Dim eqmEquipment As Equipment = EquipmentManager.GetEquipment(srcChamber)
                If (eqmEquipment Is Nothing) Then
                    AVPLib.Log.coreLogger.Error(strConvertedSrcChamber & " is not present.")
                    Return False
                End If
                Dim objChamber As Chamber = Nothing
                If (srcChamber.IndexOf(ConstEnum.Chamber) >= 0) Then
                    objChamber = CType(eqmEquipment, Chamber)
                Else
                    AVPLib.Log.coreLogger.Error(strConvertedSrcChamber & " is not a PM.")
                    Return False
                End If

                eqmEquipment = EquipmentManager.GetEquipment(destLoadLock)
                If (eqmEquipment Is Nothing) Then
                    AVPLib.Log.coreLogger.Error(strConvertedDestLoadLock & " is not present.")
                    Return False
                End If
                Dim objLoadlLock As LoadLock = Nothing
                If (destLoadLock.IndexOf(ConstEnum.LoadLock) >= 0) Then
                    objLoadlLock = CType(eqmEquipment, LoadLock)
                Else
                    AVPLib.Log.coreLogger.Error(strConvertedDestLoadLock & " is not a LoadLock.")
                End If

                Dim objTransferModule As DataManagerment.CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                Dim SrcChamberTransferSetPointPressure As Single = 0.1
                Dim TMTransferSetPointPressure As Single = 0.1
                Dim DestLoadLockTransferSetPointPressure As Single = 0.1

                Const MinimumSleepTimeInSeconds As Integer = 1
                Dim quotaInSeconds As Integer = IIf(waitTimeInSeconds <= 0, MinimumSleepTimeInSeconds, waitTimeInSeconds)
                While (ReturnWafer)
                    ' Check if we have run out of time ?
                    If (quotaInSeconds < 0) Then
                        Dim strRelatedEquipmentsMsg As String = IIf(String.IsNullOrEmpty(strConvertedSrcChamber), String.Empty, strConvertedSrcChamber & ", ") & _
                        "Transfer Module" & IIf(String.IsNullOrEmpty(strConvertedDestLoadLock), String.Empty, ", " & strConvertedDestLoadLock)

                        ' Fire an alarm to user about waiting too long for related equipments reaching their transfer Set Point Pressure.
                        OnProcessingError("Failed to wait for related Equipments - `" & strRelatedEquipmentsMsg & _
                        "` reaching their transfer Set Point in a period of time: " & waitTimeInSeconds & " seconds.", False)
                        Return False
                    End If
                    ' Source: Chamber1, Chamber2, Chamber3, Chamber4, Chamber5.
                    eqmEquipment = EquipmentManager.GetEquipment(srcChamber)
                    If (eqmEquipment Is Nothing) Then
                        AVPLib.Log.coreLogger.Error(srcChamber & " is not present.")
                        Return False
                    End If
                    Dim SrcChamberPressure As Single = IIf(objChamber.IGStatus = Equipment.WorkingStatuses.On, objChamber.IG, objChamber.CG)
                    SrcChamberTransferSetPointPressure = ContainerData.GetTransferSetPointPressureForStation(eqmEquipment.Name, 0.1)
                    If (SrcChamberPressure > SrcChamberTransferSetPointPressure) Then
                        Utils.ShowStatusMessage("Waits for " & Utils.chamberID2ChamberName(srcChamber) & _
                        " reaching its transfer Set Point Pressure:" & SrcChamberTransferSetPointPressure & _
                        ", now its pressure is " & Format(SrcChamberPressure, AVPLib.ConstEnum.SCIENTIFIC_FORMAT))
                        Thread.Sleep(MinimumSleepTimeInSeconds * 1000)
                        quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                        Continue While
                    End If
                    ' Transfer Module.
                    Dim TMPressure As Single = IIf(objTransferModule.IGStatus = Equipment.WorkingStatuses.On, objTransferModule.IG, objTransferModule.CG)
                    TMTransferSetPointPressure = ContainerData.GetTransferSetPointPressureForStation(objTransferModule.Name, 0.1)
                    If (TMPressure > TMTransferSetPointPressure) Then
                        Utils.ShowStatusMessage("Waits for Transfer Module" & _
                            " reaching its transfer Set Point Pressure:" & TMTransferSetPointPressure & _
                            ", now its pressure is " & Format(TMPressure, AVPLib.ConstEnum.SCIENTIFIC_FORMAT))
                        Thread.Sleep(MinimumSleepTimeInSeconds * 1000)
                        quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                        Continue While
                    End If
                    ' Destination: LLA, Chamber1, Chamber2, Chamber3, Chamber4, Chamber5.
                    If Not String.IsNullOrEmpty(destLoadLock) Then
                        eqmEquipment = EquipmentManager.GetEquipment(destLoadLock)
                        If (eqmEquipment Is Nothing) Then
                            AVPLib.Log.coreLogger.Error(destLoadLock & " is not present.")
                            Return False
                        End If
                        Dim DestLLorChamberPressure As Single = IIf(objLoadlLock.IGStatus = Equipment.WorkingStatuses.On, objLoadlLock.IG, objLoadlLock.CG)
                        DestLoadLockTransferSetPointPressure = ContainerData.GetTransferSetPointPressureForStation(eqmEquipment.Name, 0.1)
                        If (DestLLorChamberPressure > DestLoadLockTransferSetPointPressure) Then
                            Utils.ShowStatusMessage("Waits for " & Utils.chamberID2ChamberName(destLoadLock) & _
                            " reaching its transfer Set Point Pressure:" & DestLoadLockTransferSetPointPressure & _
                            ", now its pressure is " & Format(DestLLorChamberPressure, AVPLib.ConstEnum.SCIENTIFIC_FORMAT))
                            Thread.Sleep(MinimumSleepTimeInSeconds * 1000)
                            quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                            Continue While
                        End If
                    End If

                    Dim strRelatedEquipments As String = strConvertedSrcChamber & ", Transfer Module, " & strConvertedDestLoadLock
                    Utils.ShowStatusMessage(strRelatedEquipments & " have already reached theirs transferring setpoint pressure, starting trasferring wafer.")
                    AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForReachingSetPointPressure")
                    Return True
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForReachingSetPointPressure")
            Return False
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Move wafer along the route defined in Route
        ''' </summary>
        ''' <param name="Route"></param>
        ''' <remarks></remarks>
        Private Function Move(ByVal Route As List(Of DBSeqStep), ByVal bFirstSubRoute As Boolean) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter Move")

            Dim blnResult As Boolean = False
            Try
                AVPLib.Log.schedulerLogger.Debug("Route")
                AVPLib.Log.schedulerLogger.Debug(Route)

                If (Route.Count > 1) Then
                    ' Getting the station names ( source and destination ).
                    Dim convertedRoute As List(Of String) = Route.ConvertAll(Of String)(New Converter(Of DBSeqStep, String)( _
                                                                            AddressOf GetStationNameFromSequenceStep))
                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": ATOMIC SUBROUTE MOVEMENT - " & Utils.ArrayToString(convertedRoute))
                    Dim SrcLLorChamber As String = String.Empty ' LoadLockA|B or ChamberX
                    Dim SrcLLorChamberRaw As String = String.Empty ' LoadLockA|B,SlotN or ChamberX

                    Dim DestLLorChamber As String = String.Empty ' LoadLockA|B or ChamberX
                    Dim DestLLorChamberRaw As String = String.Empty ' LoadLockA|B,SlotN or ChamberX

                    Dim strRegExp As String = "^(LoadLock[AB]),Slot"
                    For Each station As String In convertedRoute
                        If station.StartsWith(ConstEnum.LoadLock) Or station.StartsWith(ConstEnum.Chamber) Then
                            Dim mtcMatch As Match = Regex.Match(station, strRegExp)
                            Dim tmpLLorChamberName As String = String.Empty
                            If (mtcMatch.Success) Then
                                tmpLLorChamberName = mtcMatch.Groups(1).Value
                            Else
                                tmpLLorChamberName = station
                            End If

                            If String.IsNullOrEmpty(SrcLLorChamber) Then
                                SrcLLorChamber = tmpLLorChamberName
                                AVPLib.Log.schedulerLogger.Debug("SOURCE: " & SrcLLorChamber)
                                SrcLLorChamberRaw = station
                            Else
                                DestLLorChamber = tmpLLorChamberName
                                AVPLib.Log.schedulerLogger.Debug("DESTINATION: " & DestLLorChamber)
                                DestLLorChamberRaw = station
                            End If
                        End If
                        If (Not String.IsNullOrEmpty(SrcLLorChamber)) And (Not String.IsNullOrEmpty(DestLLorChamber)) Then
                            Exit For
                        End If
                    Next

                    If (String.IsNullOrEmpty(SrcLLorChamber)) Then
                        SrcLLorChamberRaw = convertedRoute.Item(0)
                        SrcLLorChamber = SrcLLorChamberRaw
                        AVPLib.Log.schedulerLogger.Debug("SOURCE: " & SrcLLorChamber)
                    End If

                    If (String.IsNullOrEmpty(DestLLorChamber)) Then
                        DestLLorChamberRaw = convertedRoute.Item(convertedRoute.Count - 1)
                        DestLLorChamber = DestLLorChamberRaw
                        AVPLib.Log.schedulerLogger.Debug("DESTINATION: " & DestLLorChamber)
                    End If

                    If IsAutoTransfer Then
                        Const CHECK_SET_POINT_PRESSURE_FIRST_TIME_STEP As Integer = 1
                        Const ACQUIRE_CHAMBER_RESOURCE_STEP As Integer = 2
                        Const ACQUIRE_TRANSPORT_RESOURCE_STEP As Integer = 3

                        Dim intStep = CHECK_SET_POINT_PRESSURE_FIRST_TIME_STEP

                        ' 60 * 60 Maximize 1 Hour, this value is configurable.
                        Dim TransferSetPointWaitTimeInSeconds As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig( _
                        ConstEnum.TRANSFER_SET_POINT_WAIT_TIME_IN_SECONDS, 60 * 60)

                        Dim blnIsTaskFished As Boolean = False
                        Dim blnIsError As Boolean = False
                        While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                            Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                            If (awokenByTerminateRequest) Then
                                Return False
                            End If
                            Select Case intStep
                                Case CHECK_SET_POINT_PRESSURE_FIRST_TIME_STEP
                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SET_POINT_PRESSURE_FIRST_TIME_STEP")
                                    blnIsError = False
                                    If Not AVPParentControlJob.IsCycleInATMMode AndAlso Not CheckAndWaitForReachingSetPointPressure(SrcLLorChamber, DestLLorChamber, TransferSetPointWaitTimeInSeconds, bFirstSubRoute) Then ' If this is the first sub route, we should care for StopInProcess Request.
                                        ' User is aborting this Process Job.
                                        AVPLib.Log.schedulerLogger.Info("Leave Move")
                                        Return False
                                    End If
                                Case ACQUIRE_CHAMBER_RESOURCE_STEP
                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": ACQUIRE_CHAMBER_RESOURCE_STEP")
                                    blnIsError = False
                                    While (Not HasTerminateRequest())
                                        Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                                        If (awokenByTerminate) Then
                                            ' User is aborting this Process Job.
                                            AVPLib.Log.schedulerLogger.Info("Leave Move")
                                            Return False
                                        End If
                                        If (bFirstSubRoute) Then
                                            If Me.StopInProcess Then
                                                ' Exit this job - Do Not Continue Because Wafer Is Still In LoadLock And User Just Stops It.
                                                AVPLib.Log.schedulerLogger.Info("Leave Move")
                                                Return False
                                            End If
                                        End If
                                        Dim bCheckWaferPresent As Boolean = True
                                        If (DestLLorChamber = SrcLLorChamber) Then
                                            bCheckWaferPresent = False
                                        End If
                                        If Not (AcquireChamberResource(DestLLorChamberRaw, GetSlotID(DestLLorChamberRaw), m_blnIsAutoTransfer, bCheckWaferPresent, False) _
                                        AndAlso CheckWaferAtAligner(DestLLorChamberRaw)) Then
                                            Const Fine_Tune_Sleep_Time As Integer = 200
                                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                                ' User is aborting this Process Job.
                                                Return False
                                            End If
                                        Else
                                            Exit While
                                        End If
                                    End While
                                Case ACQUIRE_TRANSPORT_RESOURCE_STEP
                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": ACQUIRE_TRANSPORT_RESOURCE_STEP")
                                    blnIsError = False
                                    AcquireTransportResourceEx()
                                    If HasTerminateRequest() Then
                                        AVPLib.Log.schedulerLogger.Info("Leave Move")
                                        Return False
                                    End If
                                    'Check if there is another wafer existed on Robot Arm.
                                    Dim eqpRobot As Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                                    If eqpRobot.WaferInside = Equipment.WorkingStatuses.On Then
                                        OnProcessingError("Had wafer on Robot Arm.", False)
                                        If Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave Move")
                                            Return False
                                        End If
                                        blnIsError = True
                                        ReleaseTransportResource()
                                        intStep = ACQUIRE_TRANSPORT_RESOURCE_STEP
                                        JobPause()
                                        Continue While
                                    End If
                                    ' To make sure everything okie, check the set point pressures again.
                                    If AVPParentControlJob.IsCycleInATMMode OrElse CheckAndWaitForReachingSetPointPressure(SrcLLorChamber, DestLLorChamber, TransferSetPointWaitTimeInSeconds, bFirstSubRoute) Then
                                        blnIsTaskFished = True
                                    Else
                                        ' For some reasons if the pressures are not reached, release the transport resource, chamber resource and return to the step CHECK_SET_POINT_PRESSURE_FIRST_TIME_STEP.
                                        blnIsError = True
                                        ReleaseTransportResource()
                                        ReleaseChamberResource(DestLLorChamber)
                                        intStep = CHECK_SET_POINT_PRESSURE_FIRST_TIME_STEP
                                        Continue While
                                    End If
                                Case ACQUIRE_TRANSPORT_RESOURCE_STEP + 1
                                    Exit While
                            End Select
                            If (Not blnIsError) Then
                                intStep += 1
                            End If
                        End While
                    Else
                        Const CHECK_SET_POINT_PRESSURE_ON_RETURN_STEP As Integer = 1
                        Const ACQUIRE_CHAMBER_RESOURCE_ON_RETURN_STEP As Integer = 2
                        Const ACQUIRE_TRANSPORT_RESOURCE_ON_RETURN_STEP As Integer = 3

                        Dim nStep As Integer = CHECK_SET_POINT_PRESSURE_ON_RETURN_STEP
                        Dim bIsTaskFished As Boolean = False
                        Dim bIsError As Boolean = False
                        While (Not bIsTaskFished AndAlso Not HasTerminateRequest())
                            Select Case nStep
                                Case CHECK_SET_POINT_PRESSURE_ON_RETURN_STEP
                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SET_POINT_PRESSURE_ON_RETURN_STEP")
                                    bIsError = False

                                Case ACQUIRE_CHAMBER_RESOURCE_ON_RETURN_STEP
                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": ACQUIRE_CHAMBER_RESOURCE_ON_RETURN_STEP")
                                    bIsError = False

                                    If Not AcquireChamberResource(DestLLorChamberRaw, GetSlotID(DestLLorChamberRaw), m_blnIsAutoTransfer, True, True) Then
                                        bIsError = True
                                        OnProcessingError("Please manually return the wafer.", False)
                                        Return False
                                    End If

                                Case ACQUIRE_TRANSPORT_RESOURCE_ON_RETURN_STEP
                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": ACQUIRE_TRANSPORT_RESOURCE_ON_RETURN_STEP")
                                    bIsError = False
                                    AcquireTransportResource()
                                    bIsTaskFished = True
                            End Select
                            If (Not bIsError) Then
                                nStep += 1
                            End If
                        End While
                    End If
                    ' 
                    If HasTerminateRequest() Then
                        AVPLib.Log.schedulerLogger.Info("Leave Move")
                        Return False
                    End If

                    Dim idx As Integer = 0
                    For idx = 0 To Route.Count - 2
                        Dim Source As String = Route.Item(idx).StationName
                        Dim srcRecipePath As String = Route.Item(idx).RunningRecipePath
                        Dim Destination As String = Route.Item(idx + 1).StationName
                        Dim destRecipePath As String = Route.Item(idx + 1).RunningRecipePath
                        Dim SourceSlotIdx As Integer = Route.Item(idx).SlotID
                        Dim DestSlotIdx As Integer = Route.Item(idx + 1).SlotID
                        blnResult = Move(Source, srcRecipePath, Destination, destRecipePath, SourceSlotIdx, DestSlotIdx)

                        ' only support for self-aligner
                        If Not blnResult AndAlso Not IsAutoTransfer Then
                            ' Just need exiting the loop.
                            Exit For
                        End If

                        If HasTerminateRequest() Then
                            ' Just need exiting the loop.
                            Exit For
                        End If

                        If Not blnResult AndAlso IsAutoTransfer Then
                            OnProcessingError("Transfer Wafer Failed Due To Unexpected Error. Aborted Wafer " + JobID, False)
                            ' Bring TM Offline for not interfering to other processing wafers.
                            Dim objTransferModule As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                            Dim objTMController As TMController = ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString())
                            objTransferModule.ControlStatus = Equipment.ControlStatuses.OFFLINE
                            objTMController.RaiseFinishOnline(False)
                            Me.JobAbort()
                            Return False
                        End If
                    Next
                    If IsAutoTransfer Then
                        If (AbortInProcess And ReturnWafer) Then
                            OnReturnWafer()

                            ' Indicate that we once have tried to return wafer.
                            ReturnWafer = False
                            ' Indicate that we want to exit this Job.
                            blnResult = False

                            If Not AVPParentControlJob.JobManager.CJBatchProcessing Then
                                AVPLib.Utils.ShowFlashingText(String.Empty, False)
                            End If
                        End If
                    End If

                    If blnResult AndAlso IsSelfAligner Then
                        Dim ctrRobot As RobotController = ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString())
                        ctrRobot.SetStore(m_strSelfAlignerPMName)
                    End If

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                Try
                    ' Only release Transport Resource if we're actually holding the lock.
                    ReleaseTransportResource()
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Error(ex.Message)
                End Try
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave Move")
            Return blnResult
        End Function

        Private Function IsHighestPriorityOnSource(ByVal Source As String, ByVal slotID As Integer) As Boolean
            Dim blResult As Boolean = False
            Try
                Dim objEquipment As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(Source)
                If (objEquipment IsNot Nothing) Then

                    For index As Integer = 1 To objEquipment.WaferCapacity
                        If (index <> slotID) Then
                            Dim objWaferInfo As AVPWaferInfo = objEquipment.GetWaferInfo(index)
                            If (objWaferInfo IsNot Nothing) AndAlso (Not objEquipment.IsExistWaferProcessing(objWaferInfo.WaferID)) Then
                                Dim objPJ As AVPProcessJob = AVPParentControlJob.GetProcJob(objWaferInfo.WaferID)
                                If (objPJ IsNot Nothing AndAlso objPJ.Priority < Priority) Then
                                    Exit Try
                                    'return false
                                End If
                            End If
                        End If
                    Next

                End If
                blResult = True
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function

        Private Function CheckWaferAtAligner(ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter CheckWaferAtAligner")
            Try
                If (RobotConfigurationValues.ALINER_VISIBLE) Then
                    If Destination.IndexOf(LoadLockID) >= 0 Then
                        Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                        If objAligner.GetWaferInfo() IsNot Nothing Then
                            AVPLib.Log.schedulerLogger.Debug("Has wafer at aligner")
                            ''Aligner has wafer on the left and place to LLA
                            If (AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = 1 AndAlso _
                                                           Destination.Contains(ConstEnum.Equipments.LoadLockA.ToString())) Then
                                AVPLib.Log.schedulerLogger.Debug("Aligner on the left and place to LLA")
                                Return False
                            End If
                        End If
                    ElseIf Destination.IndexOf(AlignerID) >= 0 Then
                        Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                        If objAligner.GetWaferInfo() IsNot Nothing Then
                            Return False
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return True
            AVPLib.Log.schedulerLogger.Info("Leave CheckWaferAtAligner")
        End Function
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Cao Anh Kiet</Name>
        '''   	<Date>2008-12-16</Date>
        '''		<Description></Description>
        ''' </Modifier>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Move wafer from source to destination
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <param name="Destination"></param>
        ''' <remarks></remarks>
        Private Function Move(ByVal Source As String, _
                              ByVal srcRecipePath As String, _
                              ByVal Destination As String, _
                              ByVal destRecipePath As String, _
                              ByVal SourceSlotIdx As Integer, _
                              ByVal DestSlotIdx As Integer) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter Move")
            Dim blnResult As Boolean = False
            Try
                AVPLib.Log.schedulerLogger.Debug("Move from " & Source & " to " & Destination)
                AVPLib.Log.schedulerLogger.Debug("Source Station Recipe:" + srcRecipePath)
                AVPLib.Log.schedulerLogger.Debug("Destination Station Recipe:" + destRecipePath)
                If HasTerminateRequest() Then
                    AVPLib.Log.schedulerLogger.Info("Leave Move")
                    Return False
                End If

                If Not IsAutoTransfer AndAlso (Source.Contains("LoadLock") OrElse Destination.Contains("LoadLock")) Then
                    Utils.ManualTransferStatus("On")
                End If

                If (Pick(Source, Destination, srcRecipePath, SourceSlotIdx, DestSlotIdx)) Then
                    If IsAutoTransfer Then
                        m_idxCurrentStationForPickingInRoute = m_idxCurrentStationForPickingInRoute + 1
                    End If
                    If (HasTerminateRequest()) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Move")
                        Return False
                    End If
                    If (Place(Source, Destination, destRecipePath, SourceSlotIdx, DestSlotIdx)) Then
                        blnResult = True
                    End If
                End If

                If Not IsAutoTransfer AndAlso (Source.Contains("LoadLock") OrElse Destination.Contains("LoadLock")) Then
                    Utils.ManualTransferStatus("Off")
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave Move")
            Return blnResult
        End Function

        Private Sub LogPickWaferMovement(ByVal WaferID As String, ByVal FromSrc As String)
            ' Log Wafer Movement
            Dim LogStr As String = String.Format("Picking Wafer {0} from {1}", WaferID, AVPLib.Utils.chamberID2ChamberName(FromSrc))
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, AVPLib.ContainerData.LogSource.AVPMainScreen, LogStr)
        End Sub

        Private Sub LogPlaceWaferMovement(ByVal WaferID As String, ByVal ToDes As String)
            ' Log Wafer Movement
            Dim LogStr As String = String.Format("Placing Wafer {0} to {1}", WaferID, AVPLib.Utils.chamberID2ChamberName(ToDes))
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, AVPLib.ContainerData.LogSource.AVPMainScreen, LogStr)
        End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Cao Anh Kiet</Name>
        '''   	<Date>2008-12-16</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Pick wafer from source
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function Pick(ByVal Source As String, _
                              ByVal Destination As String, _
                              ByVal srcRecipePath As String, _
                              ByVal SourceSlotIdx As Integer, _
                              ByVal DestSlotIdx As Integer) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter Pick")
            Dim blnResult As Boolean = False
            Try
                AVPLib.Log.schedulerLogger.Debug("Source:" + Source)
                AVPLib.Log.schedulerLogger.Debug("Destination:" + Destination)
                AVPLib.Log.schedulerLogger.Debug("Destination Station Recipe:" + srcRecipePath)

                Dim Robot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                If (Source.IndexOf(ChamberID) >= 0) Then
                    If (HasTerminateRequest()) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Pick")
                        Return False
                    End If
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                    If (m_sifSequenceInfor IsNot Nothing) And (False = awokenByTerminate) Then
                        Me.RaiseToWafer(Source, m_sifSequenceInfor.WaferInfo.SlotID)
                    End If
                    If (awokenByTerminate) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Pick")
                        Return False
                    End If
                    Dim chamberConfig As SystemModule = ContainerData.GetRobotConfig(Source)

                    blnResult = PickFromChamberMultiSlots(Source, SourceSlotIdx, Destination)

                    If (HasTerminateRequest()) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Pick")
                        Return False
                    End If
                    Me.RaiseToWafer(Source, 0)
                ElseIf (Source.IndexOf(LoadLockID) >= 0) Then
                    If (HasTerminateRequest()) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Pick")
                        Return False
                    End If

                    blnResult = PickFromLoadLock(Source, Destination)
                ElseIf (Source.IndexOf(AlignerID) >= 0) Then
                    If (HasTerminateRequest()) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Pick")
                        Return False
                    End If

                    'MANUAL TRANSFER: RETURN WAFER AND MOVE MANUAL
                    'RETURN WAFER ONLY PICK WAFER, NO NEVER USE RECIPE
                    'MANUAL TRANSFER: 2 OPPTION USE/NOT USE ALIGNER 
                    'MANUAL TRANSFER CASE:
                    '   + SOURCE = ALIGNER & USE ALIGNER
                    '   + SOURCE = ALIGNER & NOT USE ALIGNER
                    If (ReturnWafer) Then
                        blnResult = PickFromAlignerOnReturn(Source, Destination)
                    Else
                        blnResult = PickFromAligner(Source, Destination, srcRecipePath)

                        If blnResult Then
                            blnResult = AlignerDeltaPickCheckECCMLimit(Source, Destination, srcRecipePath)
                        End If
                    End If
                ElseIf (Source.IndexOf(RobotArmID) >= 0) Then
                    If (HasTerminateRequest()) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Pick")
                        Return False
                    End If
                    blnResult = PickFromRobotArm(Source, Destination)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave Pick")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-05-29 </date>
        ''' </author>
        ''' <summary>
        ''' AlignerDeltaPickCheckECCMLimit
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function AlignerDeltaPickCheckECCMLimit(ByVal Source As String, _
                                                        ByVal Destination As String, _
                                                        ByVal srcRecipePath As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter AlignerDeltaPickCheckECCMLimit")
            Dim blnResult As Boolean = False
            Try
                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False
                Dim nReties As Integer = 0

                Const CHECKING_ECC_M_OVER_LIMIT As Integer = 1

                AVPLib.Log.schedulerLogger.Debug("Source:" + Source)
                AVPLib.Log.schedulerLogger.Debug("Destination:" + Destination)

                Dim Aligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                Dim objAlignerController As AlignerController = ControllerManager.GetController(ConstEnum.Equipments.Aligner.ToString())

                If ((Not IsSelfAligner) AndAlso objAlignerController.IsDeltaPickNeeded()) Then

                    While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                        Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                        If (awokenByTerminateRequest OrElse IsCancelMove) Then
                            Return False
                        End If

                        Select Case intStep
                            Case CHECKING_ECC_M_OVER_LIMIT
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECKING_ECC_M_OVER_LIMIT")
                                blnIsError = False
                                Dim check As Boolean = False
                                If RobotConfigurationValues.ALLOW_CHECKING_ECC_LIMIT AndAlso _
                                   Aligner.RSLTMaxEccentricityMils > RobotConfigurationValues.ECC_M_LIMIT Then
                                    blnIsError = True
                                    nReties = nReties + 1
                                    If nReties < AlignerController.DeltaPickMaxRetry Then
                                        check = PlaceToAlginer(ConstEnum.STR_ROBOT_ARM, Source, srcRecipePath)
                                        If check Then
                                            check = PickFromAligner(Source, Destination, srcRecipePath)
                                        End If

                                        If Not check AndAlso Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave AlignerDeltaPickCheckECCMLimit")
                                            Return False
                                        End If
                                    Else
                                        OnProcessingError("Failed To Transfer Wafer Due To ECC.M Over Limit", True)
                                        If Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave AlignerDeltaPickCheckECCMLimit")
                                            Return False
                                        End If
                                        nReties = -1
                                        JobPause()
                                        Continue While
                                    End If

                                Else
                                    blnIsTaskFished = True
                                    blnResult = True
                                End If
                        End Select
                        If (Not blnIsError) Then
                            intStep += 1
                        End If
                    End While

                Else
                    blnResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error("AlignerDeltaPickCheckECCMLimit " & ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave AlignerDeltaPickCheckECCMLimit")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Cao Anh Kiet</Name>
        '''   	<Date>2008-12-16</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Pick wafer from Chamber(Chamber1, Chamber3, Chamber5)
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PickFromChamber(ByVal Source As String, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromChamber")
            Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            Dim blnResult As Boolean = False
            Try
                AVPLib.Log.schedulerLogger.Debug("Source:" + Source)
                AVPLib.Log.schedulerLogger.Debug("Destination:" + Destination)

                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False
                Dim chamberConfig As SystemModule = Nothing
                Dim srcChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Source)
                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)

                ''PLEASE ADD NOTE HERE IF CHANGE FLOW
                ''IBE FLOW:
                'CHECK PRESSURE ->CHECK MOTION OFF ->CLAMP UP ->VERIFY CLAMP UP ->MOTION INITIALIZE ->VERIFY MOTION ->OPEN SLITVALVE ->PICK WAFER->CLOSE SLITVALVE
                ''''''''''''''''->CHECK MOTION ON ->OPEN SLITVALVE ->PICK WAFER -> CLOSE SLITVALVE
                ''PVD FLOW:
                'CHECK PRESSURE ->OPEN SHUTTER ->VERIFY OPEN SHUTTER ->MOVE CHUCK TO ZERO ->VERIFY CHUCK ->UNCLAMP ->VERIFY UNCLAMP -> OPEN SLITVALVE ->PICK WAFER ->CLOSE SLITVALVE
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim CHECK_PRESSURE_STEP As Integer = 1
                Dim IBE_CLAMP_UP As Integer = 2
                Dim IBE_VERIFY_CLAMP_UP As Integer = 3
                Dim MOTION_INITIALIZE As Integer = 4
                Dim VERIFY_MOTION_INITIALIZE As Integer = 5
                Dim OPEN_SHUTTER As Integer = 6
                Dim VERIFY_OPEN_SHUTTER As Integer = 7
                Dim MOVE_CHUCK_TO_ZERO As Integer = 8
                Dim VERIFY_CHUCK_POSITION As Integer = 9
                Dim PVD_UNCLAMP As Integer = 10
                Dim PVD_VERIFY_UNCLAMP As Integer = 11
                Dim CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE As Integer = 12
                Dim OPEN_SPLITVALVE_STEP As Integer = 13
                Dim PICK_WAFER_STEP As Integer = 14
                Dim MAKE_ROBOT_GO_TO_LOADLOCK As Integer = 15
                Dim CLOSE_SPLITVALVE_STEP As Integer = 16

                While ((Not blnIsTaskFished) And (Not HasTerminateRequest()))
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                    If (awokenByTerminate OrElse IsCancelMove) Then
                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                        Return False
                    End If

                    If (Not CheckWaferAtAligner(Destination)) Then
                        If (m_blnIsAutoTransfer) Then

                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            OnProcessingError("Aligner has a wafer, can not pick wafer from " & Source, True)
                            Return False
                        End If
                    End If

                    If (Not m_bllockTransportResource AndAlso Not AcquireTransportResourceEx()) Then
                        Continue While
                    End If

                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso Not objTMController.IsStationOnline(Source)) Then
                        If (m_blnIsAutoTransfer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    If blnIsError Then
                        blnIsError = False
                    End If
                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False

                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer
                            Dim check As Boolean = True
                            Dim strPressureError As String = String.Empty
                            check = objTMController.CheckCG10DifferenceFromStation(Source, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)

                            AVPLib.Log.schedulerLogger.Debug("Check pressure result:" + check.ToString())
                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError(strPressureError, False)
                                End If
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If
                            ''<check sensor from config file>
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_BEFORE_PICK.")
                            If RobotConfigurationValues.CHECKSENSOR_BEFOREPICK Then
                                If Not Utils.CheckAllSensorOff() And RobotConfigurationValues.DEBUGMODE = False Then
                                    OnProcessingError("All SensorStatus are not Off", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    JobPause()
                                    Continue While
                                End If
                            End If
                        Case IBE_CLAMP_UP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": IBE_CLAMP_UP.")
                            blnIsError = False
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(srcChamber.Name) ' Get the configuration
                            If chamberConfig.Type = AVPLib.SystemModule.ModuleType.IBE Then
                                ''check motion off
                                If (srcChamber.Initialize_Motion_readback <> Equipment.WorkingStatuses.On) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    ''send clamp Up if UnClamp
                                    Dim ibeChamber As IBEChamber = CType(srcChamber, IBEChamber)
                                    ''clamp status is On = clamp up
                                    If (ibeChamber.ClampStatus <> Equipment.WorkingStatuses.On) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                        If Not (IBEUtility.Fixture_Clamp(srcChamber.Name, ConfigurationValues.DEVICE_CLAMP_UP)) Then
                                            OnProcessingError(Utils.chamberID2ChamberName(Source) + " is not intialized its Motion", False)
                                            If Not m_blnIsAutoTransfer Then
                                                AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                                Return False
                                            End If
                                            blnIsError = True
                                            intStep = CHECK_PRESSURE_STEP 'start pick process again
                                            JobPause()
                                            Continue While
                                        End If
                                    Else ''go to step MOTION_INITIALED IF CLAMP UP
                                        intStep = MOTION_INITIALIZE - 1
                                    End If
                                ElseIf (srcChamber.Initialize_Motion_readback = Equipment.WorkingStatuses.On) Then
                                    ''go to step CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE
                                    intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            ElseIf chamberConfig.Type = SystemModule.ModuleType.PVD Then
                                intStep = OPEN_SHUTTER - 1
                            End If
                        Case IBE_VERIFY_CLAMP_UP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": IBE_VERIFY_CLAMP_UP.")
                            blnIsError = False
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(srcChamber.Name) ' Get the configuration
                            If chamberConfig.Type = AVPLib.SystemModule.ModuleType.IBE Then
                                Dim TimeForVerifyClampUp As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig( _
                                                                                                     ConstEnum.CLAMP_UP_WAIT_TIME_IN_SECONDS, 30)
                                If Not CheckAndWaitForClampUp(CType(srcChamber, IBEChamber), TimeForVerifyClampUp) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    If HasTerminateRequest() Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                        Return False
                                    End If
                                    OnProcessingError(Utils.chamberID2ChamberName(Source) + " verify clamp up fail", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                            End If
                        Case MOTION_INITIALIZE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MOTION_INITIALIZE.")
                            blnIsError = False
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(srcChamber.Name) ' Get the configuration
                            If chamberConfig.Type = AVPLib.SystemModule.ModuleType.IBE Then
                                ''check motion initialize
                                If (srcChamber.Initialize_Motion_readback <> Equipment.WorkingStatuses.On) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    ' Do not send command if motion is initializing
                                    If CType(srcChamber, IBEChamber).Initializing_Motion_readback <> Equipment.WorkingStatuses.On Then

                                        ''send command to initialze motion
                                        If Not IBEUtility.Initialize_Motion(srcChamber.Name, ConfigurationValues.DEVICE_STATUS_OPEN) Then
                                            OnProcessingError(Utils.chamberID2ChamberName(Source) + " is not intialized its Motion", False)
                                            If Not m_blnIsAutoTransfer Then
                                                AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                                Return False
                                            End If
                                            blnIsError = True
                                            intStep = CHECK_PRESSURE_STEP 'start pick process again
                                            JobPause()
                                            Continue While
                                        End If
                                    Else
                                        intStep = VERIFY_MOTION_INITIALIZE - 1
                                    End If
                                Else
                                    intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            End If
                        Case VERIFY_MOTION_INITIALIZE
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.IBE Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_MOTION_INITIALIZE.")
                                blnIsError = False
                                Dim TimeForVerifyMotionInitialize As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig( _
                                                                             ConstEnum.MOTION_INITIALZE_WAIT_TIME_IN_SECONDS, 2 * 60) '2minutes
                                If Not CheckAndWaitForMotionInitialize(srcChamber, TimeForVerifyMotionInitialize) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    If HasTerminateRequest() Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                        Return False
                                    End If
                                    OnProcessingError(Utils.chamberID2ChamberName(Source) + " motion initialize failed", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                Else ''GO DIRECTLY TO OPEN SLITVALVE
                                    intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Error("DO NOT HAVE MOTION INITIALIZE")
                            End If

                        Case OPEN_SHUTTER
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SHUTTER.")
                            blnIsError = False
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(srcChamber.Name) ' Get the configuration
                            'FIX ISSUE THAT SUPPORT BOTH PVD AND IBE
                            'Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                            'If PVD we need to open shutter
                            'If IBE we need to open shutter too
                            'Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                If chamberConfig.ShutterVisible AndAlso Not srcChamber.IsShutterOpen() Then
                                    If Not (PVDUtility.Shutter_Valve(srcChamber.Name, ConfigurationValues.DEVICE_STATUS_OPEN.ToString())) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError(Utils.chamberID2ChamberName(Source) + " can not send command to open shutter", False)
                                        If Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                Else 'if Shutter is already Opened or Shutter is not installed
                                    intStep = MOVE_CHUCK_TO_ZERO - 1
                                End If
                            Else 'If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.IBE Then
                                'chamberConfig = AVPLib.ContainerData.GetRobotConfig(srcChamber.Name) ' Get the configuration
                                'If chamberConfig.ShutterVisible AndAlso Not (srcChamber.IsShutterOpen()) Then
                                '    If Not (IBEUtility.Shutter_Position(srcChamber.Name, IBEConfigurationValues.DEVICE_STATUS_OPEN)) Then
                                '        OnProcessingError(Utils.chamberID2ChamberName(Source) + " can not send command to open shutter", False)
                                '        If Not m_blnIsAutoTransfer Then
                                '            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                '            Return False
                                '        End If
                                '        blnIsError = True
                                '        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                '        JobPause()
                                '        Continue While
                                '    End If

                                'Else
                                '    'Go directly to OPEN_SPLITVALVE_STEP
                                '    intStep = OPEN_SPLITVALVE_STEP - 1
                                'End If
                                '    'Go directly to CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE
                                intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                            End If

                        Case VERIFY_OPEN_SHUTTER
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_OPEN_SHUTTER.")
                            blnIsError = False
                            'Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                            Dim TimeForOpenShutter As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig( _
                                                                     ConstEnum.OPEN_SHUTTER_WAIT_TIME_IN_SECONDS, 2)
                            If Not CheckAndWaitForShutterOpen(srcChamber, TimeForOpenShutter) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                If HasTerminateRequest() Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                OnProcessingError(Utils.chamberID2ChamberName(Source) + " open shutter fail", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = OPEN_SHUTTER
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If

                            If (srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.IBE) Then
                                'Go directly to CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE, ignore the move chuck step
                                intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                            End If

                        Case MOVE_CHUCK_TO_ZERO
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MOVE_CHUCK_TO_ZERO.")
                                blnIsError = False
                                Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                                If Not (CInt(pvdChamber.ChuckPos_Readback) = 0) Then
                                    If Not (PVDUtility.Chuck_Pos2(pvdChamber.Name, Chuck_Zero_Distant)) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError(Utils.chamberID2ChamberName(Source) + " can not send command to move chuck to zero", False)
                                        If Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                Else 'If Chuck distant is already Zero
                                    intStep = PVD_UNCLAMP - 1
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Error("DO NOT HAVE CHUCK TO OPEN")
                            End If
                        Case VERIFY_CHUCK_POSITION
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_CHUCK_POSITION.")
                                blnIsError = False
                                Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                                Dim TimeForMoveChuckToZero As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig( _
                                                                        ConstEnum.MOVING_CHUCK_TO_ZERO_WAIT_TIME_IN_SECONDS, 30)
                                If Not CheckAndWaitForMovingChuckToZero(pvdChamber, TimeForMoveChuckToZero) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    If HasTerminateRequest() Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                        Return False
                                    End If
                                    OnProcessingError(Utils.chamberID2ChamberName(Source) + " move chuck to Zero fail", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    'intStep = MOVE_CHUCK_TO_ZERO
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Error("DO NOT HAVE CHUCK TO OPEN")
                            End If
                        Case PVD_UNCLAMP
                            'AVP.  Manual transfer/scheduling.   If PVD had flowcool/clamp installed,   we need to unclamp also before transferring wafer out.
                            Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                            Dim objChamberConfig As SystemModule = ContainerData.GetRobotConfig(srcChamber.Name)
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD AndAlso objChamberConfig.ClampInstalled Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": UNCLAMP TO PICK WAFER FROM CHAMBER.")
                                blnIsError = False
                                If Not (pvdChamber.ClampStatus_Readback = Equipment.WorkingStatuses.Off) Then ''not unclamp
                                    ''send unclamp
                                    If Not PVDUtility.Clamp_UnClamp_Status(srcChamber.Name, ConfigurationValues.DEVICE_STATUS_CLOSED) Then
                                        'And (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError(Utils.chamberID2ChamberName(Source) + " can not send command to UnClamp to PVD", False)
                                        If Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                Else 'if already Unclamp
                                    intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            Else
                                'If Clamp is not install -> move over these steps 
                                intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                AVPLib.Log.schedulerLogger.Error("DO NOT UNCLAMP TO PICK WAFER FROM CHAMBER")
                            End If

                        Case PVD_VERIFY_UNCLAMP
                            'AVP.  Manual transfer/scheduling.   If PVD had flowcool/clamp installed,   we need to unclamp also before transferring wafer out.
                            If srcChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_UNCLAMP_PVD.")
                                blnIsError = False
                                Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                                Dim TimeForVerifyUnClamp As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig( _
                                                                      ConstEnum.PVD_UNCLAMP_WAIT_TIME_IN_SECONDS, RobotConfigurationValues.PVD_UNCLAMP_WAIT_TIME)
                                If Not CheckAndWaitForUnClamp(pvdChamber, TimeForVerifyUnClamp) Then 'And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    If HasTerminateRequest() Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                        Return False
                                    End If
                                    OnProcessingError(Utils.chamberID2ChamberName(Source) + " unclamp fail", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Error("DO NOT UNCLAMP TO PICK WAFER FROM CHAMBER")
                            End If

                        Case CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE.")
                            Dim strErr As String = CheckRobotIsOkToOpenSlitValve(Source)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)
                            AVPLib.Log.schedulerLogger.Debug("Pick wafer result:" + check.ToString())

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Pick Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " From " + Utils.chamberID2ChamberName(Source) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'if resume, start at Pick step.
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If

                        Case OPEN_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, _
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & Utils.chamberID2ChamberName(Source) & " isovalve")
                            blnIsError = False

                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Source, True)
                            AVPLib.Log.schedulerLogger.Debug("Open valve result:" + check.ToString())
                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Open " + Utils.chamberID2ChamberName(Source) + " SlitValve: " & check, False)
                                If Not IsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveOpen, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                            End If
                            'DONOT SEND TO IBE/PVD HERE, ONLY SEND ON SLITVALVE PROPERTY
                            'If IsAutoTransfer Then
                            '    Dim pmController As ChamberController = ControllerManager.GetController(Source)
                            '    If Not pmController.SetIsoValveStatus(True) Then
                            '        OnProcessingError("Failed to set Slit valve Status = Open for, " + Utils.chamberID2ChamberName(Source), False)
                            '        blnIsError = True
                            '        intStep = CHECK_PRESSURE_STEP 'start pick process again
                            '        JobPause()
                            '        Continue While
                            '    End If
                            '    SleepButAlertabletoTerminateRequest(1000)
                            'End If
                        Case PICK_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP.")
                            blnIsError = False
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)

                            ' Wafer Movement Log
                            If (srcChamber IsNot Nothing) AndAlso (srcChamber.GetWaferInfo() IsNot Nothing) Then
                                LogPickWaferMovement(srcChamber.GetWaferInfo().WaferID, Source)
                                AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info, _
                                "Start Pick Wafer: " & srcChamber.GetWaferInfo().WaferID & " From: " & Utils.chamberID2ChamberName(srcChamber.Name), m_blnIsAutoTransfer)
                            End If

                            Dim strErr As String = ctrRobot.PickWaferFromStation(Source, IsAutoTransfer, IsReturnWafer, False)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)
                            AVPLib.Log.schedulerLogger.Debug("Pick wafer result:" + check.ToString())
                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Pick Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " From " + Utils.chamberID2ChamberName(Source) & ". " & strErr, False, _
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'if resume, start at Pick step.
                                'intStep = PICK_WAFER_STEP
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, _
                                AVPLib.ContainerData.LogSource.AVPMainScreen, "Pick Completed")

                            Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), Source) ' Update PM State to IDLE

                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP.")
                            Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                            'End counting wafer process time
                            srcChamber.GetWaferInfo().EndCountingWaferProcessTime()

                            ' Have wafer inside robot
                            objRobot.SetWaferInfo(srcChamber.GetWaferInfo())

                            ' AFTER PICK WAFER SUCCESSFULLY => TRIGGER EVENT WAFER OUT
                            ' Trigger SECS/GEM Event by Dat Vo
                            ' Var Name: PMX.WaferOut
                            Business.AVPSecsGemLib.TriggerEvent(Source, "WaferOut")

                            'Update Wafer Processing State by Dat Cao
                            objRobot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                            ControllerManager.SetWaferInsideSrc_Dst(srcChamber.Name, Equipments.Robot.ToString(), objRobot.GetWaferInfo())
                            srcChamber.SetWaferInfo()
                            ' Robot Extended At Chamber X and Have A Wafer.
                            'MoveHandToPosition(next_enmPosition) '--> we get real Robot status
                            ' Robot Retracted At Chamber X and Have A Wafer.
                            'MoveHandToPosition(next_next_enmPosition) '--> we get real Robot status
                            ' Then set the wafer status empty for this PM
                            Dim objPMController As ChamberController = ControllerManager.GetController(Source)
                            If Not objPMController.DoSetWaferStatus(String.Format("{0:00}", CType(AVPLib.ConstEnum.enumWaferStatus.eWaferNone, Integer))) Then
                                If IsAutoTransfer Then
                                    OnProcessingError("Failed to set wafer empty for " & Utils.chamberID2ChamberName(Source), False)
                                End If
                            End If

                            ' ALWAYS DOES CLOSE_SPLITVALVE_STEP AFTER OPEN_SPLITVALVE_STEP
                            ' BUT WE CAN RESUME AT CLOSE_SPLITVALVE_STEP IF WE FAIL TO CLOSE SLIT VALVE.
                            intStep = MAKE_ROBOT_GO_TO_LOADLOCK ' BYPASS ONE WHILE TURN.
                            GoTo MAKE_ROBOT_GO_TO_LOADLOCK
                        Case MAKE_ROBOT_GO_TO_LOADLOCK
MAKE_ROBOT_GO_TO_LOADLOCK:
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MAKE_ROBOT_GO_TO_LOADLOCK.")
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.MoveRobotToLoadLock(IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError(strErr, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If
                        Case CLOSE_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            blnIsError = False
                            Dim strError As String = CheckRobotIsOkToCloseSlitValve(Source)
                            If strError <> String.Empty AndAlso RobotConfigurationValues.DEBUGMODE = False Then
                                OnProcessingError(strError, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If (checkRobotRetract = False) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Robot Hand is not retracted when closing SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                JobPause()
                                Continue While
                            End If

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, _
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & Utils.chamberID2ChamberName(Source) & " isovalve")

                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Source, False)
                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Failed to close " + Utils.chamberID2ChamberName(Source) + " SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                JobPause()
                                Continue While
                            Else
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveClose, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        blnIsError = True
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                            Return False
                                        End If
                                        m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                        'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                            End If
                            'DO NOT SEND SLITVALVE STATUS TO IBE/PVD, ONLY SEND ON SLIT VALVE STATUS PROPERTY
                            'If IsAutoTransfer Then
                            '    Dim pmController As ChamberController = ControllerManager.GetController(Source)
                            '    If Not pmController.SetIsoValveStatus(False) Then
                            '        OnProcessingError("Failed to set Slit valve Status = Closed for, " + Utils.chamberID2ChamberName(Source), False)
                            '    End If
                            'End If
                            If IsAutoTransfer Then
                                ' Check if we can release this chamber or not.
                                Dim chamberIdx = m_listConvertedRoute.IndexOf(srcChamber.Name, m_idxCurrentStationForPickingInRoute + 1)
                                ' If Chamber is not in remaining route, it's ok to release it.
                                If m_idxCurrentStationForPickingInRoute > chamberIdx Then
                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " is releasing the chamber: " & srcChamber.Name)
                                    ' Optimize Scheduler -----------------------------------------------------
                                    'ReleaseChamberResource(srcChamber.Name)
                                    ReleaseChamberResourceAndReserveForAnotherRunningPJInNeed(srcChamber.Name)
                                    '-------------------------------------------------------------------------
                                End If
                            End If
                            ' Finally we get there.
                            blnIsTaskFished = True
                            blnResult = True
                            Exit While
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
            Return blnResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-01-04</date>
        ''' </author>
        ''' <Modifiers>
        '''</Modifiers>
        ''' <summary>
        ''' Pick wafer from Corona Chamber(Chamber1, Chamber2, Chamber3)
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PickFromChamberMultiSlots(ByVal Source As String, ByVal SlotID As Integer, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromChamberMultiSlots")
            Dim blResult As Boolean = False
            Try
                Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Source)
                If (objChamber IsNot Nothing) Then
                    Dim objChamberConfig As SystemModule = ContainerData.GetRobotConfig(objChamber.Name)
                    If objChamberConfig IsNot Nothing Then
                        ''PVD4
                        If (objChamberConfig.Type = SystemModule.ModuleType.PVD4) Then
                            If (m_blnIsAutoTransfer) Then
                                SlotID = objChamber.GetWaferSlotIndex(JobID)
                            End If
                            blResult = PickFromCoronaChamber(Source, SlotID, Destination)
                            ''PVD5T
                        ElseIf objChamberConfig.Type = SystemModule.ModuleType.PVD5T Then
                            If (m_blnIsAutoTransfer) Then
                                SlotID = objChamber.GetWaferSlotIndex(JobID)
                            End If
                            blResult = PickFromPVD5TChamber(Source, SlotID, Destination)
                        Else
                            blResult = PickFromChamber(Source, Destination)
                            'ADD MORE CHAMBER MULTY SLOT HERE
                            'USED FOR FUTURE
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamberMultiSlots")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-01-04</date>
        ''' </author>
        ''' <Modifiers>
        '''</Modifiers>
        ''' <summary>
        ''' Pick wafer from Corona Chamber(Chamber1, Chamber2, Chamber3)
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PickFromCoronaChamber(ByVal Source As String, ByVal SlotID As Integer, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromCoronaChamber")
            Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            Dim blnResult As Boolean = False
            Me.m_MasterBatchProcessing = False
            Dim blIsMoveliftDown As Boolean = False
            Dim srcChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Source)
            Dim objCoronaChamber As CoronaChamber = CType(srcChamber, DataManagerment.CoronaChamber)
            Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
            Const HOME_INDEX_POSITION As Integer = 1
            Try
                AVPLib.Log.coreLogger.Error(JobID + " Start Pick from Source:" + Source + "To Destination:" + Destination)

                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False
                Dim chamberConfig As SystemModule = Nothing

                Dim CHECK_PRESSURE_STEP As Integer = 1
                Dim VERIFY_MOTION_INITIALIZED As Integer = 2
                'Move table lift home
                Dim MOVE_TABLE_HOME As Integer = 3
                'check rotation table at wafer position and sub stable is up
                Dim CHECK_ROTATION_TABLE_POSITION As Integer = 4
                'rotate table to station X
                Dim MOVE_TABLE_TO_STATION_X As Integer = 5
                'Move sublift up 
                Dim MOVE_TABLE_UP As Integer = 6
                Dim CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE As Integer = 7
                'all thing is ready -> open slit valve
                Dim OPEN_SPLITVALVE_STEP As Integer = 8
                'pick wafer from chamber
                Dim PICK_WAFER_STEP As Integer = 9
                'move Table
                Dim MOVE_TABLE_DOWN As Integer = 10

                Dim MAKE_ROBOT_GO_TO_LOADLOCK As Integer = 11
                'close slit valve
                Dim CLOSE_SPLITVALVE_STEP As Integer = 12


                While ((Not blnIsTaskFished) And (Not HasTerminateRequest()))

                    If blnIsError Then
                        StepMoveCoronaSubLiftToDown(objCoronaChamber)
                    End If

                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                    If (awokenByTerminate OrElse IsCancelMove) Then
                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                        Return False
                    End If

                    If (Not CheckWaferAtAligner(Destination)) Then
                        If (m_blnIsAutoTransfer) Then

                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            OnProcessingError("Aligner has a wafer, can not pick wafer from " & Source, True)
                            Return False
                        End If
                    End If

                    If (Not IsHighestPriorityOnSource(Source, SlotID)) Then
                        If (m_blnIsAutoTransfer) Then
                            'release for highest priority
                            ReleaseTransportResource()
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        End If
                    End If

                    If (Not m_bllockTransportResource AndAlso Not AcquireTransportResourceEx()) Then
                        Continue While
                    End If

                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso Not objTMController.IsStationOnline(Source)) Then
                        If (m_blnIsAutoTransfer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    If blnIsError Then
                        blnIsError = False
                    End If

                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False

                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer
                            Dim check As Boolean = True
                            Dim strPressureError As String = String.Empty
                            check = objTMController.CheckCG10DifferenceFromStation(Source, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)

                            AVPLib.Log.schedulerLogger.Debug("Check pressure result:" + check.ToString())
                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError(strPressureError, False)
                                End If
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Pressure OK")

                            ''<check sensor from config file>
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_BEFORE_PICK.")
                            If RobotConfigurationValues.CHECKSENSOR_BEFOREPICK Then
                                If Not Utils.CheckAllSensorOff() And RobotConfigurationValues.DEBUGMODE = False Then
                                    OnProcessingError("All SensorStatus are not Off", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    JobPause()
                                    Continue While
                                End If
                            End If
                            AddActionLog("Check Sensor before pick OK")

                        Case VERIFY_MOTION_INITIALIZED
                            If Not (StepVerifyMotionStopped(objCoronaChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to wait for" + Utils.chamberID2ChamberName(Source) + " Motion stop", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                            AddActionLog("Check Motion Initalized OK")
                        Case MOVE_TABLE_HOME
                            'Move Table Lift go to Home
                            If Not (StepMoveCoronaTableLiftToHome(objCoronaChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Table to Home Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                            AddActionLog("Check Move Table To Home OK")
                        Case CHECK_ROTATION_TABLE_POSITION
                            'check current slot
                            AVPLib.Log.avpLogger.Error("DEBUG-------: CHECK_ROTATION_TABLE_POSITION")
                            AVPLib.Log.avpLogger.Error("DEBUG-------: Substrate_Current_Station = " + CType(srcChamber, CoronaChamber).Substrate_Current_Station.ToString())
                            AVPLib.Log.avpLogger.Error("DEBUG-------: SlotID = " + SlotID.ToString())
                            If (CType(srcChamber, CoronaChamber).Substrate_Current_Station = SlotID AndAlso
                                CType(srcChamber, CoronaChamber).SetSubStrateLiftUpDownStatus(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)) Then
                                intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                AVPLib.Log.avpLogger.Error("DEBUG-------: Set intStep = OPEN_SPLITVALVE_STEP - 1")
                            Else
                                intStep = MOVE_TABLE_TO_STATION_X - 1
                                AVPLib.Log.avpLogger.Error("DEBUG-------: Set intStep = MOVE_TABLE_TO_STATION_X - 1")
                            End If
                            AddActionLog("Check Current Slot OK")
                        Case MOVE_TABLE_TO_STATION_X
                            'if table is moving -> continue wait for motor
                            ContinueWaitMotor(objCoronaChamber)
                            'Special case for Go to Slot 1 because it call macro home.
                            'Take very long time to finish motion. Sleep 5s because backend keep 
                            'slot table 5s before update to GUI.
                            'If (SlotID = HOME_INDEX_POSITION) Then
                            Thread.Sleep(6000) 'WAIT MORE 5S
                            'End If

                            AVPLib.Log.avpLogger.Error("DEBUG-------: goto MOVE_TABLE_TO_STATION_X")
                            'if not at position -> send goto position
                            If (Not objCoronaChamber.IsSubStrateTableAtPosition(SlotID)) Then

                                'Move SubStrate go Down
                                If Not (StepMoveCoronaSubLiftToDown(objCoronaChamber)) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                    'Else 'Move Ok
                                    'GO TO NEXT STEP
                                End If
                                AddActionLog("Check Move SubStrate Go Down OK")
                                AVPLib.Log.avpLogger.Error("DEBUG-------: goto StepMoveCoronaTableGoToSlot")
                                'move table go to slot X
                                If Not (StepMoveCoronaTableGoToSlot(objCoronaChamber, SlotID)) Then
                                    AVPLib.Log.avpLogger.Error("DEBUG-------: goto StepMoveCoronaTableGoToSlot failed")
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed To Rotate Substrate To Station: " & SlotID, False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                                AddActionLog("Check Move Table Go To Slot X OK")
                                'Else -> GOTO NEXT STEP
                            End If
                            AddActionLog("Check MOVE TABLE TO STATION X OK")
                            AVPLib.Log.avpLogger.Error("DEBUG-------: moveout MOVE_TABLE_TO_STATION_X without gotoSlot")
                        Case MOVE_TABLE_UP
                            'Move SubLift go to Up
                            blIsMoveliftdown = True
                            If Not (StepMoveCoronaSubLiftToUp(objCoronaChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Up Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = MOVE_TABLE_UP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                            AddActionLog("Check Move SubLift Go To Up OK")

                        Case CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE.")
                            Dim strErr As String = CheckRobotIsOkToOpenSlitValve(Source)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Pick Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " From " + Utils.chamberID2ChamberName(Source) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'if resume, start at Pick step.
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If

                        Case OPEN_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & Utils.chamberID2ChamberName(Source) & " isovalve")

                            blnIsError = False
                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Source, True)
                            AVPLib.Log.schedulerLogger.Debug("Open valve result:" + check.ToString())
                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Open " + Utils.chamberID2ChamberName(Source) + " SlitValve: " & check, False)
                                If Not IsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveOpen, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                            End If
                            AddActionLog("OPEN slit valve OK")

                        Case PICK_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP.")
                            blnIsError = False

                            Dim strErr As String = String.Empty
                            Dim check As Boolean = False

                            If IsTableHome(objCoronaChamber) Then
                                Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                                strErr = ctrRobot.PickWaferFromStation(Source, IsAutoTransfer, IsReturnWafer, False)
                                check = IIf(strErr = String.Empty, True, False)
                                AVPLib.Log.schedulerLogger.Debug("Pick wafer result:" + check.ToString())

                                ' Wafer Movement Log
                                If (srcChamber IsNot Nothing) AndAlso (srcChamber.GetWaferInfo(SlotID) IsNot Nothing) Then
                                    LogPickWaferMovement(srcChamber.GetWaferInfo(SlotID).WaferID, Source)
                                    AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info,
                                    "Start Pick Wafer: " & srcChamber.GetWaferInfo(SlotID).WaferID & " From: " & Utils.chamberID2ChamberName(srcChamber.Name), m_blnIsAutoTransfer)
                                End If
                            Else
                                strErr = "Table is not Home Position."
                            End If

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Pick Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " From " + Utils.chamberID2ChamberName(Source) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'if resume, start at Pick step.
                                'intStep = PICK_WAFER_STEP
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If

                            'DATCAO Note: Need review this problem 
                            If (srcChamber.WaferInside = DataManagerment.Equipment.WorkingStatuses.Off) Then
                                Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), Source) ' Update PM State to IDLE
                            Else
                                Utils.SetPMStatus(EnumChamberState.WAITING_UNLOAD.ToString(), Source) ' Update PM State to IDLE
                            End If

                            AddActionLog("Pick wafer OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                AVPLib.ContainerData.LogSource.AVPMainScreen, "Pick Completed")

                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP.")
                            Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                            'End counting wafer process time
                            srcChamber.GetWaferInfo(SlotID).EndCountingWaferProcessTime()

                            ' Have wafer inside robot
                            objRobot.SetWaferInfo(srcChamber.GetWaferInfo(SlotID))

                            ' AFTER PICK WAFER SUCCESSFULLY => TRIGGER EVENT WAFER OUT
                            ' Trigger SECS/GEM Event by Dat Vo
                            ' Var Name: PMX.WaferOut
                            Business.AVPSecsGemLib.TriggerEvent(Source, "WaferOut")

                            Dim strCustomWaferId As String = Utils.GetGEMWaferID(objCoronaChamber.GetWaferInfo(SlotID).WaferID)
                            objCoronaChamber.Last_Wafer_Out = strCustomWaferId

                            'Update Wafer Processing State by Dat Cao
                            objRobot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                            ControllerManager.SetWaferInsideSrc_Dst(srcChamber.Name, Equipments.Robot.ToString(), objRobot.GetWaferInfo(), SlotID, 1)
                            srcChamber.SetWaferInfo(Nothing, SlotID)
                            AVPLib.Business.ControllerManager.SetWaferInsideChamber_without_UpdateGEM(srcChamber.Name, STR_OFF, srcChamber.GetWaferInfo(SlotID), True, SlotID)

                            ' Robot Extended At Chamber X and Have A Wafer.
                            'MoveHandToPosition(next_enmPosition) '--> we get real Robot status
                            ' Robot Retracted At Chamber X and Have A Wafer.
                            'MoveHandToPosition(next_next_enmPosition) '--> we get real Robot status
                            ' Then set the wafer status empty for this PM
                            Dim objPMController As ChamberController = ControllerManager.GetController(Source)
                            ''''UPDATE REAL TIME''If (srcChamber.WaferInside = DataManagerment.Equipment.WorkingStatuses.Off) Then
                            If Not objPMController.DoSetWaferStatus(String.Format("{0:00}", CType(objCoronaChamber.WaferStatus, Integer))) Then
                                If IsAutoTransfer Then
                                    OnProcessingError("Failed to set wafer empty for " & Utils.chamberID2ChamberName(Source), False)
                                End If
                            End If
                            ''End If
                            AddActionLog("Check sensor OK")

                        Case MOVE_TABLE_DOWN
                            'Move SubStrate go Down
                            If Not (StepMoveCoronaSubLiftToDown(objCoronaChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = MOVE_TABLE_DOWN 'do not pick wafer again when failed to move table down
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                            blIsMoveliftDown = False
                            AddActionLog("Check Move SubStrate go Down OK")

                            ' ALWAYS DOES CLOSE_SPLITVALVE_STEP AFTER OPEN_SPLITVALVE_STEP
                            ' BUT WE CAN RESUME AT CLOSE_SPLITVALVE_STEP IF WE FAIL TO CLOSE SLIT VALVE.
                            intStep = MAKE_ROBOT_GO_TO_LOADLOCK ' BYPASS ONE WHILE TURN.
                            GoTo MAKE_ROBOT_GO_TO_LOADLOCK
                        Case MAKE_ROBOT_GO_TO_LOADLOCK
MAKE_ROBOT_GO_TO_LOADLOCK:
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MAKE_ROBOT_GO_TO_LOADLOCK.")
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.MoveRobotToLoadLock(IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError(strErr, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If
                        Case CLOSE_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            blnIsError = False
                            Dim strError As String = CheckRobotIsOkToCloseSlitValve(Source)
                            If strError <> String.Empty AndAlso RobotConfigurationValues.DEBUGMODE = False Then
                                OnProcessingError(strError, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If (checkRobotRetract = False) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Robot Hand is not retracted when closing SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Robot Comm and Retracted OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & Utils.chamberID2ChamberName(Source) & " isovalve")

                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Source, False)
                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Failed to close " + Utils.chamberID2ChamberName(Source) + " SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                JobPause()
                                Continue While
                            Else
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveClose, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        blnIsError = True
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromCoronaChamber")
                                            Return False
                                        End If
                                        m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                        'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                            End If

                            AddActionLog("CLOSE slit valve OK")

                            If IsAutoTransfer Then
                                ' Check if we can release this chamber or not.
                                Dim chamberIdx = m_listConvertedRoute.IndexOf(srcChamber.Name, m_idxCurrentStationForPickingInRoute + 1)
                                ' If Chamber is not in remaining route, it's ok to release it.
                                If m_idxCurrentStationForPickingInRoute > chamberIdx Then
                                    'move table go to slot X + 1
                                    StepMoveNextSlot(objCoronaChamber, SlotID, True)

                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " is releasing the chamber: " & srcChamber.Name)
                                    ' Optimize Scheduler -----------------------------------------------------
                                    'ReleaseChamberResource(srcChamber.Name)
                                    ReleaseChamberResourceAndReserveForAnotherRunningPJInNeed(srcChamber.Name)
                                    '-------------------------------------------------------------------------
                                End If
                            Else
                                'move table go to slot X + 1
                                StepMoveNextSlot(objCoronaChamber, SlotID, True)
                            End If
                            ' Finally we get there.
                            blnIsTaskFished = True
                            blnResult = True
                            Exit While
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While

                AddActionLog("Pick From " + Source + " OK")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If (blIsMoveliftdown) Then
                    StepMoveCoronaSubLiftToDown(objCoronaChamber)
                End If
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
            Return blnResult
        End Function
        Private Function PickFromPVD5TChamber(ByVal Source As String, ByVal SlotID As Integer, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromPVD5TChamber")
            Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            Dim blnResult As Boolean = False
            Me.m_MasterBatchProcessing = False
            Dim blIsMoveliftDown As Boolean = False
            Dim srcChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Source)
            Dim objPVD5TChamber As PVD5TChamber = CType(srcChamber, DataManagerment.PVD5TChamber)
            Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
            'Const HOME_INDEX_POSITION As Integer = 1
            Try
                AVPLib.Log.coreLogger.Error(JobID + " Start Pick from Source:" + Source + "To Destination:" + Destination)

                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False
                Dim chamberConfig As SystemModule = Nothing

                Dim CHECK_PRESSURE_STEP As Integer = 1
                Dim VERIFY_MOTION_INITIALIZED As Integer = 2
                'Move table lift home
                Dim MOVE_TABLE_HOME As Integer = 3
                'check rotation table at wafer position and sub stable is up
                Dim CHECK_ROTATION_TABLE_POSITION As Integer = 4
                'rotate table to station X
                Dim MOVE_TABLE_TO_STATION_X As Integer = 5
                'Move sublift up 
                Dim MOVE_TABLE_UP As Integer = 6
                Dim CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE As Integer = 7
                'all thing is ready -> open slit valve
                Dim OPEN_SPLITVALVE_STEP As Integer = 8
                'pick wafer from chamber
                Dim PICK_WAFER_STEP As Integer = 9
                'move Table
                Dim MOVE_TABLE_DOWN As Integer = 10

                Dim MAKE_ROBOT_GO_TO_LOADLOCK As Integer = 11
                'close slit valve
                Dim CLOSE_SPLITVALVE_STEP As Integer = 12


                While ((Not blnIsTaskFished) And (Not HasTerminateRequest()))

                    If blnIsError Then
                        StepMovePVD5TSubLiftToDown(objPVD5TChamber)
                    End If

                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                    If (awokenByTerminate OrElse IsCancelMove) Then
                        AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                        Return False
                    End If

                    If (Not CheckWaferAtAligner(Destination)) Then
                        If (m_blnIsAutoTransfer) Then

                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            OnProcessingError("Aligner has a wafer, can not pick wafer from " & Source, True)
                            Return False
                        End If
                    End If

                    If (Not IsHighestPriorityOnSource(Source, SlotID)) Then
                        If (m_blnIsAutoTransfer) Then
                            'release for highest priority
                            ReleaseTransportResource()
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        End If
                    End If

                    If (Not m_bllockTransportResource AndAlso Not AcquireTransportResourceEx()) Then
                        Continue While
                    End If

                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso Not objTMController.IsStationOnline(Source)) Then
                        If (m_blnIsAutoTransfer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    If blnIsError Then
                        blnIsError = False
                    End If

                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False

                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer
                            Dim check As Boolean = True
                            Dim strPressureError As String = String.Empty
                            check = objTMController.CheckCG10DifferenceFromStation(Source, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)

                            AVPLib.Log.schedulerLogger.Debug("Check pressure result:" + check.ToString())
                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError(strPressureError, False)
                                End If
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Pressure OK")

                            ''<check sensor from config file>
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_BEFORE_PICK.")
                            If RobotConfigurationValues.CHECKSENSOR_BEFOREPICK Then
                                If Not Utils.CheckAllSensorOff() And RobotConfigurationValues.DEBUGMODE = False Then
                                    OnProcessingError("All SensorStatus are not Off", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    JobPause()
                                    Continue While
                                End If
                            End If
                            AddActionLog("Check Sensor before pick OK")

                        Case VERIFY_MOTION_INITIALIZED
                            If Not (PVD5TStepVerifyMotionStopped(objPVD5TChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to wait for" + Utils.chamberID2ChamberName(Source) + " Motion stop", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                            AddActionLog("Check Motion Initalized OK")
                        Case MOVE_TABLE_HOME
                            'Move Table Lift go to Home
                            If Not (StepMovePVD5TTableLiftToHome(objPVD5TChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Table to Home Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                            AddActionLog("Check Move Table To Home OK")
                        Case CHECK_ROTATION_TABLE_POSITION
                            'check current slot
                            AVPLib.Log.avpLogger.Error("DEBUG-------: CHECK_ROTATION_TABLE_POSITION")
                            AVPLib.Log.avpLogger.Error("DEBUG-------: Substrate_Current_Station = " + CType(srcChamber, PVD5TChamber).Substrate_Current_Station.ToString())
                            AVPLib.Log.avpLogger.Error("DEBUG-------: SlotID = " + SlotID.ToString())
                            If (CType(srcChamber, PVD5TChamber).Substrate_Current_Station = SlotID AndAlso
                                CType(srcChamber, PVD5TChamber).SetSubStrateLiftUpDownStatus(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)) Then
                                intStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                AVPLib.Log.avpLogger.Error("DEBUG-------: Set intStep = OPEN_SPLITVALVE_STEP - 1")
                            Else
                                intStep = MOVE_TABLE_TO_STATION_X - 1
                                AVPLib.Log.avpLogger.Error("DEBUG-------: Set intStep = MOVE_TABLE_TO_STATION_X - 1")
                            End If
                            AddActionLog("Check Current Slot OK")
                        Case MOVE_TABLE_TO_STATION_X
                            'if table is moving -> continue wait for motor
                            PVD5TContinueWaitMotor(objPVD5TChamber)
                            'Special case for Go to Slot 1 because it call macro home.
                            'Take very long time to finish motion. Sleep 5s because backend keep 
                            'slot table 5s before update to GUI.
                            'If (SlotID = HOME_INDEX_POSITION) Then
                            Thread.Sleep(6000) 'WAIT MORE 5S
                            'End If

                            AVPLib.Log.avpLogger.Error("DEBUG-------: goto MOVE_TABLE_TO_STATION_X")
                            'if not at position -> send goto position
                            If (Not objPVD5TChamber.IsSubStrateTableAtPosition(SlotID)) Then

                                'Move SubStrate go Down
                                If Not (StepMovePVD5TSubLiftToDown(objPVD5TChamber)) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                    'Else 'Move Ok
                                    'GO TO NEXT STEP
                                End If
                                AddActionLog("Check Move SubStrate Go Down OK")
                                AVPLib.Log.avpLogger.Error("DEBUG-------: goto StepMovePVD5TTableGoToSlot")
                                'move table go to slot X
                                If Not (StepMovePVD5TTableGoToSlot(objPVD5TChamber, SlotID)) Then
                                    AVPLib.Log.avpLogger.Error("DEBUG-------: goto StepMovePVD5TTableGoToSlot failed")
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed To Rotate Substrate To Station: " & SlotID, False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                                AddActionLog("Check Move Table Go To Slot X OK")
                                'Else -> GOTO NEXT STEP
                            End If
                            AddActionLog("Check MOVE TABLE TO STATION X OK")
                            AVPLib.Log.avpLogger.Error("DEBUG-------: moveout MOVE_TABLE_TO_STATION_X without gotoSlot")
                        Case MOVE_TABLE_UP
                            'Move SubLift go to Up
                            blIsMoveliftDown = True
                            If Not (StepMovePVD5TSubLiftToUp(objPVD5TChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Up Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = MOVE_TABLE_UP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                            AddActionLog("Check Move SubLift Go To Up OK")

                        Case CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE.")
                            Dim strErr As String = CheckRobotIsOkToOpenSlitValve(Source)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Pick Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " From " + Utils.chamberID2ChamberName(Source) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If

                        Case OPEN_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                   AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & Utils.chamberID2ChamberName(Source) & " isovalve")

                            blnIsError = False
                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Source, True)
                            AVPLib.Log.schedulerLogger.Debug("Open valve result:" + check.ToString())
                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Open " + Utils.chamberID2ChamberName(Source) + " SlitValve: " & check, False)
                                If Not IsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveOpen, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                            End If
                            AddActionLog("OPEN slit valve OK")
                        Case PICK_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP.")
                            blnIsError = False

                            Dim strErr As String = String.Empty
                            Dim check As Boolean = False

                            If PVD5TIsTableHome(objPVD5TChamber) Then
                                Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                                strErr = ctrRobot.PickWaferFromStation(Source, IsAutoTransfer, IsReturnWafer, False)
                                check = IIf(strErr = String.Empty, True, False)
                                AVPLib.Log.schedulerLogger.Debug("Pick wafer result:" + check.ToString())

                                ' Wafer Movement Log
                                If (srcChamber IsNot Nothing) AndAlso (srcChamber.GetWaferInfo(SlotID) IsNot Nothing) Then
                                    LogPickWaferMovement(srcChamber.GetWaferInfo(SlotID).WaferID, Source)
                                    AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info,
                                    "Start Pick Wafer: " & srcChamber.GetWaferInfo(SlotID).WaferID & " From: " & Utils.chamberID2ChamberName(srcChamber.Name), m_blnIsAutoTransfer)
                                End If
                            Else
                                strErr = "Table is not Home Position."
                            End If

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Pick Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " From " + Utils.chamberID2ChamberName(Source) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'if resume, start at Pick step.
                                'intStep = PICK_WAFER_STEP
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If

                            'DATCAO Note: Need review this problem 
                            If (srcChamber.WaferInside = DataManagerment.Equipment.WorkingStatuses.Off) Then
                                Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), Source) ' Update PM State to IDLE
                            Else
                                Utils.SetPMStatus(EnumChamberState.WAITING_UNLOAD.ToString(), Source) ' Update PM State to IDLE
                            End If

                            AddActionLog("Pick wafer OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                AVPLib.ContainerData.LogSource.AVPMainScreen, "Pick Completed")

                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP.")
                            Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                            'End counting wafer process time
                            srcChamber.GetWaferInfo(SlotID).EndCountingWaferProcessTime()

                            ' Have wafer inside robot
                            objRobot.SetWaferInfo(srcChamber.GetWaferInfo(SlotID))

                            ' AFTER PICK WAFER SUCCESSFULLY => TRIGGER EVENT WAFER OUT
                            ' Trigger SECS/GEM Event by Dat Vo
                            ' Var Name: PMX.WaferOut
                            Business.AVPSecsGemLib.TriggerEvent(Source, "WaferOut")

                            Dim strCustomWaferId As String = Utils.GetGEMWaferID(objPVD5TChamber.GetWaferInfo(SlotID).WaferID)
                            objPVD5TChamber.Last_Wafer_Out = strCustomWaferId

                            'Update Wafer Processing State by Dat Cao
                            objRobot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                            ControllerManager.SetWaferInsideSrc_Dst(srcChamber.Name, Equipments.Robot.ToString(), objRobot.GetWaferInfo(), SlotID, 1)
                            srcChamber.SetWaferInfo(Nothing, SlotID)
                            AVPLib.Business.ControllerManager.SetWaferInsideChamber_without_UpdateGEM(srcChamber.Name, STR_OFF, srcChamber.GetWaferInfo(SlotID), True, SlotID)

                            ' Robot Extended At Chamber X and Have A Wafer.
                            'MoveHandToPosition(next_enmPosition) '--> we get real Robot status
                            ' Robot Retracted At Chamber X and Have A Wafer.
                            'MoveHandToPosition(next_next_enmPosition) '--> we get real Robot status
                            ' Then set the wafer status empty for this PM
                            Dim objPMController As ChamberController = ControllerManager.GetController(Source)
                            ''''UPDATE REAL TIME''If (srcChamber.WaferInside = DataManagerment.Equipment.WorkingStatuses.Off) Then
                            If Not objPMController.DoSetWaferStatus(String.Format("{0:00}", CType(objPVD5TChamber.WaferStatus, Integer))) Then
                                If IsAutoTransfer Then
                                    OnProcessingError("Failed to set wafer empty for " & Utils.chamberID2ChamberName(Source), False)
                                End If
                            End If
                            ''End If
                            AddActionLog("Check sensor OK")

                        Case MOVE_TABLE_DOWN
                            'Move SubStrate go Down
                            If Not (StepMovePVD5TSubLiftToDown(objPVD5TChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = MOVE_TABLE_DOWN 'do not pick wafer again when failed to move table down
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If
                            blIsMoveliftDown = False
                            AddActionLog("Check Move SubStrate go Down OK")

                            ' ALWAYS DOES CLOSE_SPLITVALVE_STEP AFTER OPEN_SPLITVALVE_STEP
                            ' BUT WE CAN RESUME AT CLOSE_SPLITVALVE_STEP IF WE FAIL TO CLOSE SLIT VALVE.
                            intStep = MAKE_ROBOT_GO_TO_LOADLOCK ' BYPASS ONE WHILE TURN.
                            GoTo MAKE_ROBOT_GO_TO_LOADLOCK
                        Case MAKE_ROBOT_GO_TO_LOADLOCK
MAKE_ROBOT_GO_TO_LOADLOCK:
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MAKE_ROBOT_GO_TO_LOADLOCK.")
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.MoveRobotToLoadLock(IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            ' [0004886] Wait up to 10s for robot to confirm arrival at Loadlock Station 1 before proceeding.
                            If check Then
                                Try
                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": Wait 10s for Robot to go to Station 1.")
                                    Dim isArrived As Boolean = WaitOnCondition(AddressOf IsRobotAtLoadlockPosition, 10000, True)
                                    If Not isArrived Then
                                        check = False
                                        strErr = "Failed to wait for Robot at Station 1"
                                    End If
                                Catch ex As Exception
                                    AVPLib.Log.avpLogger.Error("Wait PVD5T GoToLoadlock: " & ex.ToString())
                                End Try
                            End If

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError(strErr, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If
                        Case CLOSE_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            blnIsError = False
                            Dim strError As String = CheckRobotIsOkToCloseSlitValve(Source)
                            If strError <> String.Empty AndAlso RobotConfigurationValues.DEBUGMODE = False Then
                                OnProcessingError(strError, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If (checkRobotRetract = False) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Robot Hand is not retracted when closing SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Robot Comm and Retracted OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                   AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & Utils.chamberID2ChamberName(Source) & " isovalve")

                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Source, False)
                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Failed to close " + Utils.chamberID2ChamberName(Source) + " SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                JobPause()
                                Continue While
                            Else
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveClose, srcChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(srcChamber.Name)
                                        blnIsError = True
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Source) + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
                                            Return False
                                        End If
                                        m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                        'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                            End If
                            AddActionLog("CLOSE slit valve OK")

                            If IsAutoTransfer Then
                                ' Check if we can release this chamber or not.
                                Dim chamberIdx = m_listConvertedRoute.IndexOf(srcChamber.Name, m_idxCurrentStationForPickingInRoute + 1)
                                ' If Chamber is not in remaining route, it's ok to release it.
                                If m_idxCurrentStationForPickingInRoute > chamberIdx Then
                                    'move table go to slot X + 1
                                    StepPVD5TMoveNextSlot(objPVD5TChamber, SlotID, True)

                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " is releasing the chamber: " & srcChamber.Name)
                                    ' Optimize Scheduler -----------------------------------------------------
                                    'ReleaseChamberResource(srcChamber.Name)
                                    ReleaseChamberResourceAndReserveForAnotherRunningPJInNeed(srcChamber.Name)
                                    '-------------------------------------------------------------------------
                                End If
                            Else
                                'move table go to slot X + 1
                                StepPVD5TMoveNextSlot(objPVD5TChamber, SlotID, True)
                            End If
                            ' Finally we get there.
                            blnIsTaskFished = True
                            blnResult = True
                            Exit While
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While

                AddActionLog("Pick From " + Source + " OK")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If (blIsMoveliftDown) Then
                    StepMovePVD5TSubLiftToDown(objPVD5TChamber)
                End If
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromPVD5TChamber")
            Return blnResult
        End Function
        Private Function ReleaseChamberResourceAndReserveForAnotherRunningPJInNeed(ByVal strEquipmentName As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter ReleaseChamberResourceAndReserveForAnotherRunningPJInNeed")
            SyncLock (m_lockChamberResources)
                Try
                    Dim eqmEquiment As Equipment = Nothing

                    eqmEquiment = EquipmentManager.GetEquipment(strEquipmentName)

                    If (eqmEquiment Is Nothing) Then
                        Return False
                    End If

                    If m_curAllocatedWFResources.Contains(strEquipmentName) Then
                        eqmEquiment.OperationStatus = Equipment.OperationStatuses.READY
                        AVPLib.Log.schedulerLogger.Debug("RELEASED CHAMBER RESOURCE: " & strEquipmentName)
                        RemoveChamberFromAllocatedWFResources(strEquipmentName)
                    End If
                    ' Optimize Scheduler--------------------------------------------------------------------------
                    If (Me.AVPParentControlJob.ReserveThisChamberForAnotherRunningPJInNeed(strEquipmentName)) Then
                        eqmEquiment.OperationStatus = Equipment.OperationStatuses.BUSY
                    End If
                    '---------------------------------------------------------------------------------------------
                    AVPLib.Log.schedulerLogger.Info("Leave ReleaseChamberResourceAndReserveForAnotherRunningPJInNeed")
                Catch ex As Exception
                    AVPLib.Log.schedulerLogger.Error(ex.ToString())
                    Return False
                End Try
                Return True
            End SyncLock
        End Function

        Private Function GetLoadLockNameAndSlot(ByVal loadLock As String, ByRef outLoadLockName As String, ByRef outSlot As String) As Boolean
            Dim strRegExp As String = "^(LoadLock[AB]),Slot(\d+)"
            Dim mtcMatch As Match = Regex.Match(loadLock, strRegExp)
            If (mtcMatch IsNot Nothing) And (mtcMatch.Length >= 2) Then
                outLoadLockName = mtcMatch.Groups(1).Value
                outSlot = mtcMatch.Groups(2).Value
                Return True
            End If
            Return False
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Cao Anh Kiet</Name>
        '''   	<Date>2008-12-16</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Pick wafer from LoadLock
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PickFromLoadLock(ByVal Source As String, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromLoadLock")
            Dim blnResult As Boolean = False
            Dim LoadLockName As String = String.Empty
            Try
                AVPLib.Log.coreLogger.Error(JobID + " Start Pick from Source:" + Source + "To Destination:" + Destination)

                ''set start time -> use for Data Run, this time is unique
                If (m_blnIsAutoTransfer) Then
                    If (AVPParentControlJob.JobManager.CJBatchProcessing) Then
                        'master -> create start time for batch
                        If (Priority = 1) Then
                            m_strDataRunStartTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")
                        Else ' get start time from master
                            m_strDataRunStartTime = AVPParentControlJob.DataRunStartTime4BatchProcessing(Me.BatchProcessJobGroupIdx)
                        End If
                    Else
                        m_strDataRunStartTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")
                    End If

                    Dim strFolderName As String = DateTime.Now.ToString("yyyy_MM_dd")
                    If m_AligerDataRunFileName.Contains(DATE_WHEN_RUNNING) Then
                        m_AligerDataRunFileName = m_AligerDataRunFileName.Replace(DATE_WHEN_RUNNING, strFolderName)
                    End If
                    If m_OrgRunDataName.Contains(DATE_WHEN_RUNNING) Then
                        m_OrgRunDataName = m_OrgRunDataName.Replace(DATE_WHEN_RUNNING, strFolderName)
                    End If
                    '''
                    'Generate Folder if needed
                    Dim strFolderPath As String = ContainerDAO.FPath_RunDataOfWafer & "\" & strFolderName
                    If Not System.IO.Directory.Exists(strFolderPath) Then
                        Try
                            System.IO.Directory.CreateDirectory(strFolderPath)
                        Catch ex As IO.IOException
                            Utils.ThrowAlarm("Failed To Create Folder For Wafer Run Data:" & strFolderPath)
                            AVPLotDatalog.AddLotDatalog(Me.AVPParentControlJob.LoadlockName, LogType.Alarm,
                            "Failed To Create Folder For Wafer Run Data:" & strFolderPath,
                            Me.IsAutoTransfer())
                        End Try
                    End If
                End If

                Dim Slot As String = String.Empty
                GetLoadLockNameAndSlot(Source, LoadLockName, Slot)

                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False

                Const CHECK_PRESSURE_STEP As Integer = 1
                Const GO_TO_SLOT_STEP As Integer = 2
                Const CHECK_WAFER_SENSOR As Integer = 3
                Const OPEN_SPLITVALVE_STEP As Integer = 4
                Const PICK_WAFER_STEP As Integer = 5
                Const CLOSE_SPLITVALVE_STEP As Integer = 6
                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)

                'check completed - > abort this job
                If m_blnIsAutoTransfer Then
                    If (Me.AVPParentControlJob.IsContinuousJob AndAlso Me.AVPParentControlJob.IsRunCylceUntilMode) Then
                        If (Me.AVPParentControlJob.PickWaferCount >= Me.AVPParentControlJob.MaxCycleCount) Then
                            Me.AVPParentControlJob.CompletedCycleWafer()
                            Me.AVPParentControlJob.IsPickFullWaferInCycleUntilMode = True
                            Return False
                        End If

                    End If
                End If

                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                    If (awokenByTerminate OrElse IsCancelMove) Then
                        Return False
                    End If

                    If (Not AVPParentControlJob.IsHighestPriorityOnBatch(Me) OrElse AVPParentControlJob.IsThereJobWithHigherIdRunningInChamber(Me)) Then
                        If (m_blnIsAutoTransfer) Then
                            'release for highest priority
                            ReleaseTransportResource()
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        End If
                    End If

                    If (Not m_bllockTransportResource AndAlso Not AcquireTransportResourceEx()) Then
                        Continue While
                    End If

                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso Not objTMController.IsStationOnline(LoadLockName)) Then
                        If (m_blnIsAutoTransfer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If


                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            If IsAutoTransfer And StopInProcess Then

                                If Not (Me.AVPParentControlJob.JobManager.CJBatchProcessing AndAlso
                                    IsContinueToPickOnLoadlockOnStoppingMode()) Then

                                    ' Exit this job - Do Not Continue Because Wafer Is Still In LoadLock And User Just Stops It.
                                    Return False
                                End If

                            End If
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False

                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer
                            Dim check As Boolean = True
                            Dim strPressureError As String = String.Empty
                            check = objTMController.CheckCG10DifferenceFromStation(LoadLockName, m_blnIsAutoTransfer, AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            If (Not check) Then
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError(strPressureError, True)
                                End If
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                    Return False
                                End If

                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Pressure OK")

                            ''<check sensor from config file>
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_BEFORE_PICK.")
                            If RobotConfigurationValues.CHECKSENSOR_BEFOREPICK Then
                                If Not Utils.CheckAllSensorOff And RobotConfigurationValues.DEBUGMODE = False Then
                                    OnProcessingError("All SensorStatus are not Off", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                        Return False
                                    End If
                                    blnIsError = True
                                    'intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                            End If

                            AddActionLog("Check Sensor before pick OK")
                            ''<check sensor from config file>
                        Case GO_TO_SLOT_STEP
                            If IsAutoTransfer And StopInProcess Then

                                If Not (Me.AVPParentControlJob.JobManager.CJBatchProcessing AndAlso
                                    IsContinueToPickOnLoadlockOnStoppingMode()) Then

                                    ' Exit this job - Do Not Continue Because Wafer Is Still In LoadLock And User Just Stops It.
                                    Return False
                                End If

                            End If
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": GO_TO_SLOT_STEP.")
                            blnIsError = False

                            'Transfer from LLX to locationX with LLX isolation is already open.   
                            'Need to check for robot communication and retracted before moving to SlotX.   
                            'This condition also apply during scheduler run.  
                            Dim objRobot As Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString)
                            If (objRobot IsNot Nothing) Then
                                If Not (objRobot.IsCommunicating) Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: Robot Communication is off", True)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                        Return False
                                    End If
                                    intStep = CHECK_PRESSURE_STEP 'start place process again
                                    JobPause()
                                    Continue While
                                End If

                                If Not (objRobot.IsRetracted AndAlso objRobot.IsReallyRetracted) Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Pick from Loadlock: Robot is not retracted.", True)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                        Return False
                                    End If
                                    intStep = CHECK_PRESSURE_STEP
                                    AVPLib.Log.coreLogger.Error(JobID + " Robot is not retracted.")
                                    JobPause()
                                    Continue While
                                End If
                            End If

                            AddActionLog("Check Robot comm and retracted OK")


                            '0003691: [KhoiHa - 05/02/2024] C10 - Set, Store, Or Action Command Received While Previous Action Still In Progress.
                            Dim objElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                            Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(LoadLockName), LoadLockController)
                            Dim ctrElevator As LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)
                            Dim check As Boolean = True

                            If ctrElevator IsNot Nothing Then
                                ' IF loadlock = busy wait for loadlock ready
                                If (objElevator IsNot Nothing) AndAlso objElevator.OperationStatus = Equipment.OperationStatuses.BUSY Then
                                    check = ctrElevator.WaitForLoadLockReadyContionTimeOut(ConstEnum.Equipments.LLAElevator.ToString())

                                    If (Not check) Then
                                        OnProcessingError("Failed To Wait For " + LoadLockName + " Ready", True)
                                        If Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                            Return False
                                        End If
                                        blnIsError = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        AVPLib.Log.coreLogger.Error(JobID + " Robot is not retracted.")
                                        JobPause()
                                        Continue While
                                    End If
                                End If

                                ' go to slot and wait for current slot = slotID
                                check = ctrElevator.WaitReadyAndGotoSlot(Slot)
                                If (Not check) Then
                                    OnProcessingError("GotoSlot " + LoadLockName + " " + Slot, True)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    AVPLib.Log.coreLogger.Error(JobID + " Robot is not retracted.")
                                    JobPause()
                                    Continue While
                                End If
                            End If


                            AddActionLog("Check GOTO slot OK")

                        Case CHECK_WAFER_SENSOR
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_WAFER_SENSOR.")
                            blnIsError = False
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.CheckSensorBeforePick(LoadLockName, IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False) 'LLA, robot hand retract, extract without wafer

                            If (Not check) Then
                                OnProcessingError("Pick Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " From " + LoadLockName & ". " & strErr, True,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                ' Robot Hand Retracted At LoadLock and Has No Wafer.
                                'MoveHandToPosition(previous_enmPosition) '--> we get real Robot status
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                    Return False
                                End If
                                blnIsError = True
                                ' If user resume, start at Pick step.
                                'intStep = PICK_WAFER_STEP
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If

                        Case OPEN_SPLITVALVE_STEP
                            If IsAutoTransfer And StopInProcess Then

                                If Not (Me.AVPParentControlJob.JobManager.CJBatchProcessing AndAlso
                                    IsContinueToPickOnLoadlockOnStoppingMode()) Then

                                    ' Exit this job - Do Not Continue Because Wafer Is Still In LoadLock And User Just Stops It.
                                    Return False
                                End If

                            End If
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            blnIsError = False

                            'Step close Rough valve when loadlock rough only is installed
                            Dim check As String = String.Empty
                            If Not (CloseLoadlockRoughValve(LoadLockName, check)) Then
                                If (check <> String.Empty) Then
                                    OnProcessingError("Close " + LoadLockName + " Rough Valve", True)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                            End If

                            AddActionLog("Close LL Rough valve OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & LoadLockName & " isovalve")

                            check = ChamberUtility.OpenCloseSlitValve(LoadLockName, True)
                            AVPLib.Log.schedulerLogger.Debug("open valve result:" + check.ToString())
                            If (check <> String.Empty) Then
                                OnProcessingError("Open " + LoadLockName + " SlitValve: " & check, True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                    Return False
                                End If
                                blnIsError = True
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsLLSlitValveOpen, LoadLockName, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(LoadLockName)
                                        blnIsError = True
                                        OnProcessingError("Failed to wait for " + LoadLockName + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                            Return False
                                        End If
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                            End If

                            AddActionLog("OPEN slit valve OK")

                        Case PICK_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP.")
                            blnIsError = False

                            ' Wafer Movement Log
                            LogPickWaferMovement(Me.JobID, Source)
                            AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info,
                            "Start Pick Wafer: " & Me.JobID & " From: " & AVPParentControlJob.LoadlockName, m_blnIsAutoTransfer)

                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.PickWaferFromStation(LoadLockName, IsAutoTransfer, IsReturnWafer, False)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False) 'LLA, robot hand retract, extract without wafer
                            If (Not check) Then
                                OnProcessingError("Pick Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " From " + LoadLockName & ". " & strErr, True,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                ' Robot Hand Retracted At LoadLock and Has No Wafer.
                                'MoveHandToPosition(previous_enmPosition) '--> we get real Robot status
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                    Return False
                                End If
                                blnIsError = True
                                ' If user resume, start at Pick step.
                                'intStep = PICK_WAFER_STEP
                                intStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Pick wafer OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                AVPLib.ContainerData.LogSource.AVPMainScreen, "Pick Completed")

                            ' Add wafer id handled into lot datalog
                            AVPParentControlJob.AddWaferIDHandledToList(JobID)

                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP.")
                            blnIsError = False
                            AVPLib.Log.schedulerLogger.Debug("checking sensor")
                            Dim Robot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                            Dim LoadLockData As DataManagerment.LoadLock = CType(EquipmentManager.GetEquipment(LoadLockName), DataManagerment.LoadLock)
                            Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                            '##this comment caused by Modify rules Pick/Place, check sensor by hardware or software==##
                            'If (CheckSensors) Then
                            '    '##this comment caused by Modify rules Pick/Place, check sensor by hardware or software==##
                            '    'If Not TransferModuleObj.GetSensorStatus(LoadLockName) = Equipment.WorkingStatuses.On And RobotConfigurationValues.DEBUGMODE = False Then
                            '        Robot.SetWaferInfo()  Nothing
                            '        ' Robot Hand Extended At LoadLock and Has No Wafer.
                            '        MoveHandToPosition(enmPosition) '--> we get real Robot status
                            '        ' Robot Hand Retracted At LoadLock and Has No Wafer.
                            '        MoveHandToPosition(previous_enmPosition) '--> we get real Robot status
                            '        OnProcessingError(LoadLockName + " SensorStatus is not On", True)
                            '        If Not m_blnIsAutoTransfer Then
                            '            AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                            '            Return False
                            '        End If
                            '        blnIsError = True
                            '        ' If user resume, start at Pick step.
                            '        intStep = PICK_WAFER_STEP
                            '        JobPause()
                            '        Continue While
                            '    End If
                            'End If
                            '##==================end this comment=============================================##
                            Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(LoadLockName), LoadLockController)
                            Dim ctrElevator As LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)
                            Dim LLElevator As LLElevator = EquipmentManager.GetEquipment(ctrElevator.EquipmentName)
                            Robot.SetWaferInfo(LLElevator.ListOfWaferInfo(Integer.Parse(Slot) - 1))
                            'UPDATE GEM
                            Dim strCustomWaferId As String = Utils.GetGEMWaferID(Robot.GetWaferInfo().WaferID)
                            AVPSecsGemLib.UpdateSECSGEM_Variable(LoadLockName, EMSERVICELib.VarType.SV, "LastWaferOut", VALUELib.ValueType.A, strCustomWaferId)

                            'Update Wafer Processing State by Dat Cao
                            Robot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                            ControllerManager.SetWaferInsideSrc_Dst(Source, Equipments.Robot.ToString(), Robot.GetWaferInfo())
                            Business.AVPSecsGemLib.TriggerEvent(LoadLockName, "WaferOut")
                            ' Robot Extended At LoadLock And Has A Wafer.
                            'MoveHandToPosition(next_enmPosition) '--> we get real Robot status
                            ' Robot Retracted At LoadLock And Has A Wafer.
                            'MoveHandToPosition(next_next_enmPosition) '--> we get real Robot status

                            AddActionLog("Check sensor OK")

                        Case CLOSE_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            blnIsError = False
                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If (checkRobotRetract = False And RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Robot Hand is not retracted when closing SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Robot Comm and Retracted OK")

                            '0001010: [Khoi Ha - 06/20/2012] - LLx rough only configuration. During a schedule run after picking or placing a wafer from/to LLx, C
                            Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(LoadLockName)
                            If (objLoadLock IsNot Nothing AndAlso Not objLoadLock.IsRoughOnlyMode) Then
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                   AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & LoadLockName & " isovalve")

                                Dim check As String = ChamberUtility.OpenCloseSlitValve(LoadLockName, False)
                                If (check <> String.Empty) Then
                                    OnProcessingError("Close " + LoadLockName + " SlitValve", True)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                        Return False
                                    End If
                                    blnIsError = True
                                    'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                    JobPause()
                                    Continue While
                                Else
                                    If Not WaitOnCondition(AddressOf Utils.IsLLSlitValveClose, LoadLockName, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                        If (RobotConfigurationValues.DEBUGMODE = False) Then
                                            ChamberUtility.UnknownSlitValve(LoadLockName)
                                            blnIsError = True
                                            OnProcessingError("Failed to wait for " + LoadLockName + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                            If Not IsAutoTransfer Then
                                                AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                                Return False
                                            End If
                                            'intStep = CHECK_PRESSURE_STEP 'start pick process again, do not do this in this step
                                            JobPause()
                                            Continue While
                                        End If
                                    End If
                                    Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                    ' Finally we get there.
                                    blnIsTaskFished = True
                                    blnResult = True
                                End If
                            Else
                                ' Finally we get there.
                                blnIsTaskFished = True
                                blnResult = True
                            End If
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While

                'after pick wafer from loadlock -> increase wafer cycle count
                Me.AVPParentControlJob.PickWaferCount += 1
                If m_blnIsAutoTransfer Then
                    If (Me.AVPParentControlJob.IsContinuousJob AndAlso Me.AVPParentControlJob.IsRunCylceUntilMode) Then

                        Me.AVPParentControlJob.CompletedCycleWafer()
                        If (Me.AVPParentControlJob.PickWaferCount >= Me.AVPParentControlJob.MaxCycleCount) Then
                            Me.AVPParentControlJob.IsPickFullWaferInCycleUntilMode = True
                        End If
                    End If
                End If

                AddActionLog("Pick From " + Source + " OK")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If m_blnIsAutoTransfer And blnResult AndAlso Me.AVPParentControlJob.JobManager.CJBatchProcessing Then
                    Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(LoadLockName), LoadLockController)
                    If ctrLoadLock IsNot Nothing Then
                        Dim ctrElevator As LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)
                        If ctrElevator IsNot Nothing Then
                            ctrElevator.GotoNextSlot()
                        End If
                    End If
                End If
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
            Return blnResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-07-17</date>
        ''' </author>
        ''' <summary>
        ''' Close Rough valve when Open Loadlock Isolation valve
        ''' aply for rough only
        ''' Get Equipment check rough valve status
        ''' with hivac is not installed
        ''' </summary>
        ''' <remarks></remarks>
        Private Function CloseLoadlockRoughValve(ByVal sLoadlockName As String, Optional ByRef strErrorMsg As String = "") As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter CloseLoadlockRoughValve")
            Dim blResult As Boolean = False
            Try
                Dim objLoadlock As LoadLock = DataManagerment.EquipmentManager.GetEquipment(sLoadlockName)
                If (objLoadlock IsNot Nothing AndAlso RobotConfigurationValues.LLA_HIVAC_INSTALLED = False) Then
                    'close slow rough valve 
                    If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                        If (objLoadlock.SlowRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                            strErrorMsg = LLCryoUtility.CloseLLSlowRough(sLoadlockName)
                            If (strErrorMsg <> String.Empty) Then
                                blResult = False
                                Exit Try
                            End If
                        End If
                    End If

                    'close fast rough valve
                    If (objLoadlock.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                        strErrorMsg = LLCryoUtility.CloseLLFastRough(sLoadlockName)
                        If (strErrorMsg <> String.Empty) Then
                            blResult = False
                            Exit Try
                        End If
                    End If
                Else
                    blResult = True
                End If

                blResult = True
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave CloseLoadlockRoughValve")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat, Nguyen Tien </name>
        '''    	<date> 2009-07-14</date>
        ''' </author>
        ''' <summary>
        ''' PlaceToAlginerWithNoCheckWafer
        ''' </summary>
        ''' <remarks></remarks>
        Private Function PlaceToAlginerWithNoCheckWafer(ByVal alignerStation As String, ByVal strRecipePath As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PlaceToAlginerWithNoCheckWafer")
            Dim blnResult As Boolean = False
            Try
                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False
                Const PLACE_WAFER_STEP As Integer = 1
                Const RUN_RECIPE_STEP As Integer = 2
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())

                ' Wafer Movement Log
                If (objRobot IsNot Nothing) AndAlso (objRobot.GetWaferInfo() IsNot Nothing) Then
                    LogPlaceWaferMovement(objRobot.GetWaferInfo().WaferID, alignerStation)
                End If

                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                    Dim awokenByTerminateRequest = SuspendIfNeeded()
                    If (awokenByTerminateRequest) Then
                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToAlginerWithNoCheckWafer")
                        'ReleaseTransportResource()
                        Return False
                    End If
                    Select Case intStep
                        Case PLACE_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PLACE_WAFER_STEP.")
                            blnIsError = False
                            Dim ctrRobot As RobotController = ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString())
                            Dim strErr As String = ctrRobot.PlaceWaferToStation(alignerStation, IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)
                            m_ErrorWhenPlaceToStation = Not check
                            If (Not check) Then
                                OnProcessingError("Place Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " To " & alignerStation & ". " & strErr, True,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToAlginer")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            Else
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                     AVPLib.ContainerData.LogSource.AVPMainScreen, "Place Completed")

                                blnIsError = False
                                Dim objLoadLock As DataManagerment.LoadLock = CType(EquipmentManager.GetEquipment(LoadLockA_STR), DataManagerment.LoadLock)
                                Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                                objAligner.SetWaferInfo(objRobot.GetWaferInfo())
                                ControllerManager.SetWaferInsideSrc_Dst(Equipments.Robot.ToString(),
                                                                        Equipments.Aligner.ToString(),
                                                                        objRobot.GetWaferInfo())

                                'Update MaterialProcessingState by Dat Cao
                                If (objAligner.GetWaferInfo() IsNot Nothing) Then
                                    objAligner.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.NOT_ALIGNED
                                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                    AVPLib.ContainerData.LogSource.Aligner, "Wafer In")
                                End If

                                objRobot.SetWaferInfo()
                            End If
                        Case RUN_RECIPE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": RUN_RECIPE_STEP.")
                            blnIsError = False
                            'We execute Aligner Recipe instead of Aligning.
                            Dim objAlignerController As AlignerController = ControllerManager.GetController(ConstEnum.Equipments.Aligner.ToString())
                            'Update MaterialProcessingState by Dat Cao
                            If (objAligner.GetWaferInfo() IsNot Nothing) Then
                                objAligner.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.ALIGNING
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                AVPLib.ContainerData.LogSource.Aligner, "Wafer Aligning")
                            End If
                            Dim check As Boolean = objAlignerController.RunRecipe(strRecipePath)
                            If (Not check) Then
                                OnProcessingError("Error executing Recipe at " + alignerStation, True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToAlginerWithNoCheckWafer")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            Else

                                'Update MaterialProcessingState by Dat Cao
                                If (objAligner.GetWaferInfo() IsNot Nothing) Then
                                    objAligner.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.ALIGNED
                                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner,
                                                          "Wafer Aligned")
                                End If

                                blnIsTaskFished = True
                                blnResult = True
                            End If
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PlaceToAlginerWithNoCheckWafer")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Dat, Nguyen Tien </name>
        '''    	<date> 2009-07-08</date>
        ''' </author>
        ''' <summary>
        ''' AlignerDeltaPickWafer
        ''' </summary>
        ''' <remarks></remarks>
        Private Function AlignerDeltaPickWafer(ByVal strRecipePath As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter AlignerDeltaPickWafer")

            Dim blnResult As Boolean = False
            Try
                Const STEP_PLACE_INTO_STN_8 As Integer = 1
                Const STEP_SCAN_AT_ALIGNER As Integer = 2
                Const STEP_SET_MAX_ECCENTRICITY As Integer = 3
                Const STEP_RQ_STN_9 As Integer = 4
                Const STEP_MAKE_ALIGNER_CALCULATION As Integer = 5
                Const STEP_SET_STN_8_PARAMETERS As Integer = 6
                Const STEP_PICK_FROM_STN_8 As Integer = 7
                Const STEP_CHECK_RESCAN_REQUIRED As Integer = 8
                Const STEP_EXIT_SUCCESSFULL As Integer = 9
                Const STEP_EXIT_FAILED_DUE_TO_REACHING_MAX_DELTA_PICK_RETRY As Integer = 10

                Dim intStep = STEP_SCAN_AT_ALIGNER
                Dim blnIsError = False
                Dim blnIsTaskFished As Boolean = False

                Dim nRetries As Integer = 0
                Dim ctrRobot As RobotController = ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString())
                Dim objAligner As DataManagerment.Aligner = EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                Dim objRobot As DataManagerment.Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim objAlignerController As AlignerController = ControllerManager.GetController(ConstEnum.Equipments.Aligner.ToString())
                Dim objLoadLockA As DataManagerment.LoadLock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())

                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                    Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                    If (awokenByTerminateRequest OrElse IsCancelMove) Then
                        AVPLib.Log.schedulerLogger.Info("Leave AlignerDeltaPickWafer")
                        Return False
                    End If
                    Select Case intStep
                        Case STEP_PLACE_INTO_STN_8
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_PLACE_INTO_STN_8.")
                            blnIsError = False
                            Dim check As Boolean = False
                            'DeltaPick, 3. Place wafer on the aligner.
                            check = PlaceToAlginerWithNoCheckWafer(ConstEnum.Equipments.Aligner.ToString(), strRecipePath)
                            If (Not check) Then
                                Return False
                            End If
                        Case STEP_SCAN_AT_ALIGNER
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_SCAN_AT_ALIGNER.")
                            blnIsError = False
                            Dim check As Boolean = False
                            'DeltaPick, 7&8. Send 'SCAN' to aligner.
                            check = objAlignerController.Scan()
                            If (Not check) Then
                                OnProcessingError("AlignerDeltaPickWafer failed at 'DeltaPick, 7&8. Send SCAN to aligner' step.", True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave AlignerDeltaPickWafer")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If
                        Case STEP_SET_MAX_ECCENTRICITY
                            blnIsError = False
                            'DeltaPick, 9. If ECC_Rraw > 1250, ECC_Rraw=1250.
                            If (objAligner.RSLTMaxEccentricity > Aligner.DeltaPickMaxEccentricity) Then
                                objAligner.RSLTMaxEccentricity = Aligner.DeltaPickMaxEccentricity
                            End If
                        Case STEP_RQ_STN_9
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_RQ_STN_9.")
                            blnIsError = False
                            Dim check As Boolean = False
                            'DeltaPick, 10. Send 'RQ STN 9 ALL' to robot.
                            'Request Robot Station Information.
                            check = ctrRobot.RequestStnAll(ConstEnum.Equipments.Aligner.ToString())
                            If (Not check) Then
                                OnProcessingError("AlignerDeltaPickWafer failed at the 'DeltaPick, 10. Send 'RQ STN 9 ALL' to robot' step.", True,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave AlignerDeltaPickWafer")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If
                        Case STEP_MAKE_ALIGNER_CALCULATION
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_MAKE_ALIGNER_CALCULATION.")
                            blnIsError = False
                            'Make Aligner Calculation.
                            objAlignerController.MakeAlignerCalculation()
                        Case STEP_SET_STN_8_PARAMETERS
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_SET_STN_8_PARAMETERS.")
                            blnIsError = False
                            Dim check As Boolean = False
                            'Set Robot Station Information - SET STN 8 ...
                            check = ctrRobot.SetStationParameters(objAligner.PickStation.ToString(),
                                    CInt(objAligner.Wafer_Rstation).ToString(), CInt(objAligner.Wafer_Tstation).ToString(),
                                    objRobot.ReqAlStn_Z.ToString(), objRobot.ReqLOWER.ToString(), objRobot.ReqNSLOTS.ToString(),
                                    objRobot.ReqPITCH.ToString())
                            If (Not check) Then
                                OnProcessingError("AlignerDeltaPickWafer failed at the 'SET STN 8 Wafer_Rstation Wafer_Tstation AlStn_Z LOWER NSLOTS PITCH' step.", True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave AlignerDeltaPickWafer")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If
                        Case STEP_PICK_FROM_STN_8
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_PICK_FROM_STN_8.")
                            blnIsError = False
                            Dim strErr As String = ctrRobot.PickWaferFromStation(ConstEnum.Equipments.Aligner.ToString(), IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)
                            If (Not check) Then
                                objRobot.SetWaferInfo()
                                ControllerManager.SetWaferInsideAligner("On", objAligner.GetWaferInfo(), True)
                                ' Should add a position called Arm_Retracted_At_Aligner_HasNoWafer
                                ' Temporally I use Positions.LoadLockA instead, please rename and add a new position.
                                'MoveHandToPosition(Positions.LoadLockA) '--> we get real Robot status
                                OnProcessingError("AlignerDeltaPickWafer failed at the 'Aligner Delta Pick Wafer' step." & strErr, True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave AlignerDeltaPickWafer")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            Else
                                ' Check sensor to know that whether we pick successfully.
                                Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                                '##this comment caused by Modify rules Pick/Place, check sensor by hardware or software==##
                                'If (CheckSensors) Then
                                '    If Not TransferModuleObj.GetSensorStatus(ConstEnum.Equipments.LoadLockA.ToString()) = Equipment.WorkingStatuses.On And RobotConfigurationValues.DEBUGMODE = False Then
                                '        objRobot.SetWaferInfo()  Nothing
                                '        ControllerManager.SetWaferInsideAligner("On", objAligner.GetWaferInfo(), True)
                                '        ' Robot Hand Is Retracted At Aligner Position and Has No Wafer.
                                '        ' Temporally I use Positions.LoadLockA instead, please rename add add a new position.
                                '        MoveHandToPosition(Positions.LoadLockA)
                                '        OnProcessingError("LoadLockA SensorStatus is not On", True)
                                '        If Not m_blnIsAutoTransfer Then
                                '            AVPLib.Log.coreLogger.Info("Leave AlignerDeltaPickWafer")
                                '            Return False
                                '        End If
                                '        blnIsError = True
                                '        JobPause()
                                '        Continue While
                                '    End If
                                'End If
                                '##===============================================================##
                                objRobot.SetWaferInfo(objAligner.GetWaferInfo())
                                objAligner.SetWaferInfo()
                                ControllerManager.SetWaferInsideAligner("Off", Nothing, True)
                                ' Robot Hand Retracted At Aligner And Has A Wafer.
                                ' Should add a position called Arm_Retracted_At_Aligner_HasWafer
                                ' Currently, I use Arm_At_LLA_Wafer instead.
                                'MoveHandToPosition(Positions.Arm_At_LLA_Wafer)
                            End If
                        Case STEP_CHECK_RESCAN_REQUIRED
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_CHECK_RESCAN_REQUIRED.")
                            blnIsError = False
                            Dim check As Boolean = False
                            'DeltaPick, 14. RescanRequired=Y, Maximum tries...
                            If objAligner.RSLTReScanNeed Then
                                If (nRetries < AlignerController.DeltaPickMaxRetry) Then
                                    ' Retry one more.
                                    nRetries = nRetries + 1
                                    intStep = STEP_PLACE_INTO_STN_8 - 1
                                Else
                                    intStep = STEP_EXIT_FAILED_DUE_TO_REACHING_MAX_DELTA_PICK_RETRY - 1
                                End If
                            Else
                                intStep = STEP_EXIT_SUCCESSFULL - 1
                            End If
                        Case STEP_EXIT_SUCCESSFULL
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_EXIT_SUCCESSFULL.")
                            blnIsError = False
                            blnIsTaskFished = True
                            ' RETURN TRUE HERE, EXIT STATE MACHINE.
                            blnResult = True
                        Case STEP_EXIT_FAILED_DUE_TO_REACHING_MAX_DELTA_PICK_RETRY
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_EXIT_FAILED_DUE_TO_REACHING_MAX_DELTA_PICK_RETRY.")
                            blnIsError = True
                            'OnProcessingError("PickFromAlginer failed at the step ''DeltaPick, 14. RescanRequired=Y, Maximum tries...' due to 'Max DeltaPickRetry done'.", True)
                            OnProcessingError("PickFromAligner failed at step 'Delta pick failed after " & nRetries.ToString() & " tries'", True)
                            If Not m_blnIsAutoTransfer Then
                                AVPLib.Log.schedulerLogger.Info("Leave AlignerDeltaPickWafer")
                                Return False
                            End If
                            ' We should reset all local variables needed and jobPause here, 
                            ' in case users want to start a new cycle.
                            intStep = STEP_PLACE_INTO_STN_8
                            nRetries = 0
                            JobPause()
                            Continue While
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave AlignerDeltaPickWafer")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-05-05 </date>
        ''' </author>
        ''' <summary>
        ''' SelfAligner
        ''' </summary>
        ''' <remarks></remarks>
        Private Function SelfAligner(ByVal strChamberName As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter SelfAligner")

            Dim blnResult As Boolean = False
            Try
                Const STEP_SCAN_AT_ALIGNER As Integer = 1
                Const STEP_SET_MAX_ECCENTRICITY As Integer = 2
                Const STEP_RQ_STN_9 As Integer = 3
                Const STEP_MAKE_SELF_ALIGNER_CALCULATION As Integer = 4
                Const STEP_SET_STN_8_PARAMETERS As Integer = 5
                Const STEP_RQ_STN_PMx As Integer = 6
                Const STEP_SET_STN_PMx_PARAMETERS As Integer = 7
                Const STEP_PICK_FROM_STN_8 As Integer = 8
                Const STEP_EXIT_SUCCESSFULL As Integer = 9

                Dim intStep = STEP_SCAN_AT_ALIGNER
                Dim blnIsError = False
                Dim blnIsTaskFished As Boolean = False

                Dim nRetries As Integer = 0
                Dim ctrRobot As RobotController = ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString())
                Dim objAligner As DataManagerment.Aligner = EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                Dim objRobot As DataManagerment.Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim objAlignerController As AlignerController = ControllerManager.GetController(ConstEnum.Equipments.Aligner.ToString())
                Dim iStationNo As Integer = -1
                Dim iAlignerR_OldStaion As Integer = 0
                Dim iAlignerT_OldStation As Integer = 0
                Dim iAlignerR_NewStation As Integer = 0
                Dim iAlignerT_NewStation As Integer = 0

                If (Not ContainerData.GetStationLocation(strChamberName, iStationNo)) Then
                    AVPLib.Log.coreLogger.Info("Leave SelfAligner")
                    Return False
                End If
                m_iSelfAlignerLoop += 1

                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                    Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                    If (awokenByTerminateRequest OrElse IsCancelMove) Then
                        AVPLib.Log.schedulerLogger.Info("Leave SelfAligner")
                        Return False
                    End If
                    Select Case intStep
                        Case STEP_SCAN_AT_ALIGNER
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_SCAN_AT_ALIGNER.")
                            blnIsError = False
                            Dim check As Boolean = False
                            'DeltaPick, 7&8. Send 'SCAN' to aligner.
                            check = objAlignerController.Scan()
                            If (Not check) Then
                                OnProcessingError("SelfAligner failed at the step: Send 'SCAN' to aligner.", True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave SelfAligner")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                        Case STEP_SET_MAX_ECCENTRICITY
                            blnIsError = False
                            'DeltaPick, 9. If ECC_Rraw > 1250, ECC_Rraw=1250.
                            If (objAligner.RSLTMaxEccentricity > Aligner.DeltaPickMaxEccentricity) Then
                                objAligner.RSLTMaxEccentricity = Aligner.DeltaPickMaxEccentricity
                            End If

                        Case STEP_RQ_STN_9
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_RQ_STN_9.")
                            blnIsError = False
                            Dim check As Boolean = False
                            'DeltaPick, 10. Send 'RQ STN 9 ALL' to robot.
                            'Request Robot Station Information.
                            check = ctrRobot.RequestStnAll(ConstEnum.Equipments.Aligner.ToString())
                            iAlignerR_OldStaion = objRobot.ReqAlStn_R
                            iAlignerT_OldStation = objRobot.ReqAlStn_Traw

                            If (Not check) Then
                                OnProcessingError("SelfAligner failed at the step: Send 'RQ STN 9 ALL' to robot.", True,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave SelfAligner")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                        Case STEP_MAKE_SELF_ALIGNER_CALCULATION
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_MAKE_SELF_ALIGNER_CALCULATION.")
                            blnIsError = False
                            If strChamberName = ConstEnum.Equipments.Aligner.ToString() AndAlso m_iSelfAlignerLoop = 1 Then
                                RaiseRAndTBefore(objRobot.ReqAlStn_R, objRobot.ReqAlStn_Traw)
                            End If
                            'Make Self Aligner Calculation.
                            objAlignerController.MakeSelfAlignCalculation()

                        Case STEP_SET_STN_8_PARAMETERS
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_SET_STN_8_PARAMETERS.")
                            blnIsError = False
                            Dim check As Boolean = False

                            If strChamberName <> ConstEnum.Equipments.Aligner.ToString() Then
                                'Set Robot Station Information - SET STN 8 ...
                                check = ctrRobot.SetStationParameters(objAligner.PickStation.ToString(),
                                        CInt(objAligner.Wafer_Rstation).ToString(), CInt(objAligner.Wafer_Tstation).ToString(),
                                        objRobot.ReqAlStn_Z.ToString(), objRobot.ReqLOWER.ToString(), objRobot.ReqNSLOTS.ToString(),
                                        objRobot.ReqPITCH.ToString())
                            Else
                                check = ctrRobot.SetStationParameters(objAligner.PickStation.ToString(),
                                                                        iAlignerR_OldStaion.ToString(), iAlignerT_OldStation.ToString(),
                                                                        objRobot.ReqAlStn_Z.ToString(), objRobot.ReqLOWER.ToString(), objRobot.ReqNSLOTS.ToString(),
                                                                        objRobot.ReqPITCH.ToString())
                            End If

                            If (Not check) Then
                                OnProcessingError("SelfAligner failed at the 'SET STN 8 Wafer_Rstation Wafer_Tstation AlStn_Z LOWER NSLOTS PITCH' step.", True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave SelfAligner")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                        Case STEP_RQ_STN_PMx
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_RQ_STN_PMx.")
                            blnIsError = False
                            If strChamberName <> ConstEnum.Equipments.Aligner.ToString() Then
                                Dim check As Boolean = False
                                'Request Robot Station Information.
                                check = ctrRobot.RequestStnAll(strChamberName)
                                If (Not check) Then
                                    OnProcessingError("SelfAligner failed at the step: Send 'RQ STN " & iStationNo.ToString() & " ALL' to robot.", True,
                                        Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave SelfAligner")
                                        Return False
                                    End If
                                    blnIsError = True
                                    JobPause()
                                    Continue While
                                End If
                            End If

                        Case STEP_SET_STN_PMx_PARAMETERS
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_SET_STN_PMx_PARAMETERS.")
                            blnIsError = False

                            If strChamberName <> ConstEnum.Equipments.Aligner.ToString() Then
                                If m_iSelfAlignerLoop = 1 Then
                                    RaiseRAndTBefore(objRobot.ReqAlStn_R, objRobot.ReqAlStn_Traw)
                                End If
                                iAlignerR_NewStation = CInt(objRobot.ReqAlStn_R + objAligner.SelfAlign_Wafer_Rstation)
                                iAlignerT_NewStation = CInt(objRobot.ReqAlStn_Traw + objAligner.SelfAlign_Wafer_Tstation)
                            Else
                                iAlignerR_NewStation = CInt(objRobot.ReqAlStn_R - objAligner.SelfAlign_Wafer_Rstation)
                                iAlignerT_NewStation = CInt(objRobot.ReqAlStn_Traw - objAligner.SelfAlign_Wafer_Tstation)
                            End If

                            Dim check As Boolean = False
                            'Set Robot Station Information - SET STN 2...7
                            check = ctrRobot.SetStationParameters(iStationNo.ToString(),
                                    iAlignerR_NewStation.ToString(), iAlignerT_NewStation.ToString(),
                                    objRobot.ReqAlStn_Z.ToString(), objRobot.ReqLOWER.ToString(), objRobot.ReqNSLOTS.ToString(),
                                    objRobot.ReqPITCH.ToString())
                            If (Not check) Then
                                OnProcessingError("SelfAligner failed at the 'SET STN " & iStationNo.ToString() & " SelfAlign_Wafer_Rstation SelfAlign_Wafer_Tstation AlStn_Z LOWER NSLOTS PITCH' step.", True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave SelfAligner")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                        Case STEP_PICK_FROM_STN_8
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_PICK_FROM_STN_8.")
                            blnIsError = False
                            RaiseRAndTAfter(iAlignerR_NewStation.ToString(), iAlignerT_NewStation.ToString())
                            Dim strErr As String = ctrRobot.PickWaferFromStation(ConstEnum.Equipments.Aligner.ToString(), IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)
                            If (Not check) Then
                                objRobot.SetWaferInfo()
                                ControllerManager.SetWaferInsideAligner("On", objAligner.GetWaferInfo(), True)
                                ' Should add a position called Arm_Retracted_At_Aligner_HasNoWafer
                                ' Temporally I use Positions.LoadLockA instead, please rename and add a new position.
                                'MoveHandToPosition(Positions.LoadLockA) '--> we get real Robot status
                                OnProcessingError("SelfAligner failed at the 'PICK FROM STN 8' step." & strErr, True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave SelfAligner")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            Else
                                objRobot.SetWaferInfo(objAligner.GetWaferInfo())
                                objAligner.SetWaferInfo()
                                ControllerManager.SetWaferInsideAligner("Off", Nothing, True)
                            End If

                        Case STEP_EXIT_SUCCESSFULL
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": STEP_EXIT_SUCCESSFULL.")
                            If RobotConfigurationValues.ALLOW_CHECKING_ECC_LIMIT Then
                                IsCheckedECCLimitForSelfAligner = (objAligner.RSLTMaxEccentricityMils <= RobotConfigurationValues.ECC_M_LIMIT)
                            End If
                            blnIsError = False
                            blnIsTaskFished = True
                            ' RETURN TRUE HERE, EXIT STATE MACHINE.
                            blnResult = True
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error("SelfAligner " & ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave SelfAligner")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-05-19 </date>
        ''' </author>
        ''' <summary>
        ''' RaiseRAndTBefore
        ''' </summary>
        ''' <param name="Status"></param>
        ''' <remarks></remarks>
        Public Shared Sub RaiseRAndTBefore(ByVal valueRBefore As String, ByVal valueTBefore As String)
            AVPLib.Log.coreLogger.Info("Enter RaiseRAndTBefore")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(valueRBefore & " / " & valueTBefore)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("RTBefore")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error("RaiseRAndTBefore " & ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseRAndTBefore")
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-05-19 </date>
        ''' </author>
        ''' <summary>
        ''' RaiseRAndTAfter
        ''' </summary>
        ''' <param name="Status"></param>
        ''' <remarks></remarks>
        Public Shared Sub RaiseRAndTAfter(ByVal valueRAfter As String, ByVal valueTAfter As String)
            AVPLib.Log.coreLogger.Info("Enter RaiseRAndTAfter")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(valueRAfter & " / " & valueTAfter)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("RTAfter")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error("RaiseRAndTAfter " & ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseRAndTAfter")
        End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Cao Anh Kiet</Name>
        '''   	<Date>2008-12-16</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Pick wafer from Aligner
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PickFromAligner(ByVal Source As String,
                                         ByVal Destination As String,
                                         ByVal srcRecipePath As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromAlginer")
            Dim blnResult As Boolean = False
            Try
                If IsSelfAligner AndAlso IsCheckedECCLimitForSelfAligner Then
                    Return True
                End If

                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False

                Const CHECK_PRESSURE_STEP As Integer = 1
                Const PICK_WAFER_STEP As Integer = 2

                AVPLib.Log.coreLogger.Error(JobID + " Start Pick from Source:" + Source + "To Destination:" + Destination)

                Dim Robot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim Aligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
                Dim strRegExp As String = "^(LoadLock[AB]),Slot"
                Dim mtcMatch As Match = Regex.Match(Destination, strRegExp)
                Dim LoadLockName As String = mtcMatch.Groups(1).Value

                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                    Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                    If (awokenByTerminateRequest OrElse IsCancelMove) Then
                        Return False
                    End If
                    If (Not m_bllockTransportResource AndAlso Not AcquireTransportResourceEx()) Then
                        Continue While
                    End If

                    If Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso
                      ((Destination.IndexOf(ChamberID) >= 0 AndAlso Not objTMController.IsStationOnline(Destination)) OrElse
                      (Destination.IndexOf(LoadLockID) >= 0 AndAlso Not objTMController.IsStationOnline(LoadLockName))) Then
                        If (m_blnIsAutoTransfer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False
                            Dim check As Boolean = False
                            Dim strPressureError As String = String.Empty
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer
                            If (Destination.IndexOf(ChamberID) >= 0) Then
                                check = objTMController.CheckCG10DifferenceFromStation(Destination, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            ElseIf (Destination.IndexOf(LoadLockID) >= 0) Then
                                check = objTMController.CheckCG10DifferenceFromStation(LoadLockName, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            Else
                                check = True
                            End If
                            AVPLib.Log.schedulerLogger.Debug("check pressure result:" + check.ToString())
                            If (Not check) Then
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError(strPressureError, True)
                                End If
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromAlginer")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Pressure OK")

                            ''<check sensor from config file>
                            AVPLib.Log.schedulerLogger.Debug("Checking sensor before pick wafer")
                            If RobotConfigurationValues.CHECKSENSOR_BEFOREPICK Then
                                If Not Utils.CheckAllSensorOff And RobotConfigurationValues.DEBUGMODE = False Then
                                    OnProcessingError("All SensorStatus are not Off", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromAlginer")
                                        Return False
                                    End If
                                    blnIsError = True
                                    JobPause()
                                    Continue While
                                End If
                            End If
                            ''<check sensor from config file>
                            AddActionLog("Check Sensor before pick OK")

                        Case PICK_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP.")
                            ''previous pos#: robot
                            ''current pos#: Aligner extract without wafer
                            '''''''''''''''''is pick success? No -> robot
                            ''next_pos#: Yes: Aligner extract with wafer
                            '''''''''''''''''check sensor on/off-->Off: Aligner retract with wafer
                            '''next_next_pos#: On: Robot hand with wafer
                            'previous_enmPosition = Positions.Robot
                            ' Robot Hand Extended At Aligner And Has No Wafer.
                            'enmPosition = Positions.Aligner
                            ' Robot Hand Extended At Aligner And Has A Wafer.
                            'next_enmPosition = Positions.Arm_At_Aligner_Wafer
                            ' Robot Hand Retracted At Aligner And Has A Wafer.
                            ' Should add a position called Arm_Retracted_At_Aligner_HasWafer
                            ' Currently, I use Arm_At_LLA_Wafer instead.
                            'next_next_enmPosition = Positions.Arm_At_LLA_Wafer

                            ' Wafer Movement Log
                            If Aligner IsNot Nothing AndAlso Aligner.GetWaferInfo() IsNot Nothing Then
                                LogPickWaferMovement(Aligner.GetWaferInfo().WaferID, Source)
                                AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info,
                                "Start Pick Wafer: " & Aligner.GetWaferInfo().WaferID & " From Aligner", m_blnIsAutoTransfer)
                            End If

                            blnIsError = False
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim objAlignerController As AlignerController = ControllerManager.GetController(ConstEnum.Equipments.Aligner.ToString())
                            Dim check As Boolean = False
                            '-----------------------------------------------------------------------------------------
                            If ((Not IsSelfAligner) AndAlso objAlignerController.IsDeltaPickNeeded() AndAlso RobotConfigurationValues.ALLOW_CHECKING_ECC_LIMIT) Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP, DELTA_PICK_ENABLE = TRUE.")
                                check = AlignerDeltaPickWafer(srcRecipePath)
                                AVPLib.Log.schedulerLogger.Debug("pick wafer result:" + check.ToString())
                                If (Not check) Then
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromAlginer")
                                        Return False
                                    End If
                                    blnIsError = True
                                    JobPause()
                                    Continue While
                                Else
                                    blnIsError = False
                                    blnIsTaskFished = True
                                    blnResult = True
                                    '''Update Wafer for DeltaPick
                                    Robot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                                    '''''
                                    ''Get Aligner Information after Pick --> this info will show in data run
                                    If m_blnIsAutoTransfer Then
                                        Dim strStartTime As String = DateTime.Today.ToString("yyyy/MM/dd HH:mm:fff")
                                        Dim strGemwaferid As String = Utils.GetGEMWaferID(Robot.GetWaferInfo().WaferID)
                                        AlignerUtility.GenerateAlignerDataRun(GetCurrentChamberNameForRunData(Equipments.Aligner.ToString()), srcRecipePath, strStartTime, strGemwaferid, False)
                                    End If
                                End If

                                AddActionLog("Pick wafer(DELTA_PICK_ENABLE = TRUE) OK")

                            ElseIf IsSelfAligner Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": SELF-ALIGNER")
                                check = SelfAligner(SelfAlignerPMName)
                                AVPLib.Log.schedulerLogger.Debug("self-align result:" + check.ToString())
                                If (Not check) Then
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromAlginer")
                                        Return False
                                    End If
                                    blnIsError = True
                                    JobPause()
                                    Continue While
                                Else
                                    blnIsError = False
                                    blnIsTaskFished = True
                                    blnResult = True
                                    '''Update Wafer for DeltaPick
                                    Robot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                                End If
                                AddActionLog("Pick wafer(SELF-ALIGNER) OK")

                            Else
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP, DELTA_PICK_ENABLE = FALSE.")
                                Dim strErr As String = ctrRobot.PickWaferFromStation(Source, IsAutoTransfer, IsReturnWafer) = String.Empty
                                check = IIf(strErr, True, False) 'Aligner, current_pos and previous_pos.
                                AVPLib.Log.schedulerLogger.Debug("pick wafer result:" + check.ToString())
                                If (Not check) Then
                                    Robot.SetWaferInfo()
                                    ControllerManager.SetWaferInsideAligner("On", Aligner.GetWaferInfo(), True)
                                    OnProcessingError("Pick Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " From " + Utils.chamberID2ChamberName(Source) & ". " & strErr, True,
                                        Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromAlginer")
                                        Return False
                                    End If
                                    blnIsError = True
                                    JobPause()
                                    Continue While
                                Else
                                    blnIsError = False
                                    Dim LoadLockData As DataManagerment.LoadLock = CType(EquipmentManager.GetEquipment(LoadLockA_STR), DataManagerment.LoadLock)
                                    Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)

                                    Dim eqpAligner As Aligner = EquipmentManager.GetEquipment(Source)
                                    Robot.SetWaferInfo(eqpAligner.GetWaferInfo())
                                    eqpAligner.SetWaferInfo()

                                    'Update Wafer Processing State by Dat Cao
                                    Robot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner,
                                                          "Wafer Out")
                                    ControllerManager.SetWaferInsideSrc_Dst(Source,
                                                                            Equipments.Robot.ToString(),
                                                                             Robot.GetWaferInfo())

                                    If (objAlignerController.IsDeltaPickNeeded() AndAlso m_blnIsAutoTransfer AndAlso Not RobotConfigurationValues.ALLOW_CHECKING_ECC_LIMIT) Then
                                        Dim strStartTime As String = DateTime.Today.ToString("yyyy/MM/dd HH:mm:fff")
                                        Dim strGemwaferid As String = Utils.GetGEMWaferID(Robot.GetWaferInfo().WaferID)
                                        AlignerUtility.GenerateAlignerDataRun(GetCurrentChamberNameForRunData(Equipments.Aligner.ToString()), srcRecipePath, strStartTime, strGemwaferid, True)
                                    End If

                                    blnIsTaskFished = True
                                    blnResult = True

                                End If

                                AddActionLog("Pick wafer(DELTA_PICK_ENABLE = FALSE) OK")
                            End If
                            AddActionLog("Pick wafer OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                AVPLib.ContainerData.LogSource.AVPMainScreen, "Pick Completed")

                            '-----------------------------------------------------------------------------------------
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While

                AddActionLog("Pick From " + Source + " OK")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromAlginer")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Cao Anh Kiet</Name>
        '''   	<Date>2008-12-16</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Pick wafer from Robot Arm
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PickFromRobotArm(ByVal Source As String, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PickFromRobotArm")
            Dim blnResult As Boolean = False
            Try
                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False

                AVPLib.Log.schedulerLogger.Debug("Source:" + Source)
                AVPLib.Log.schedulerLogger.Debug("Destination:" + Destination)
                Const CHECK_PRESSURE_STEP As Integer = 1
                Const PICK_WAFER_STEP As Integer = 2

                Dim Robot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
                Dim strRegExp As String = "^(LoadLock[AB]),Slot"
                Dim mtcMatch As Match = Regex.Match(Destination, strRegExp)
                Dim LoadLockName As String = mtcMatch.Groups(1).Value

                ' Wafer Movement Log
                If (Robot IsNot Nothing) AndAlso (Robot.GetWaferInfo() IsNot Nothing) Then
                    LogPickWaferMovement(Robot.GetWaferInfo().WaferID, Source)
                End If

                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                    Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                    If (awokenByTerminateRequest OrElse IsCancelMove) Then
                        Return False
                    End If
                    'If (Not AcquireTransportResourceEx()) Then
                    '    Continue While
                    'End If


                    If Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso
                       ((Destination.IndexOf(ChamberID) >= 0 AndAlso Not objTMController.IsStationOnline(Destination)) OrElse
                       (Destination.IndexOf(LoadLockID) >= 0 AndAlso Not objTMController.IsStationOnline(LoadLockName))) Then
                        If (m_blnIsAutoTransfer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False
                            Dim strPressureError As String = String.Empty
                            Dim check As Boolean = False
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer
                            If (Destination.IndexOf(ChamberID) >= 0) Then
                                check = objTMController.CheckCG10DifferenceFromStation(Destination, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            ElseIf (Destination.IndexOf(LoadLockID) >= 0) Then
                                check = objTMController.CheckCG10DifferenceFromStation(LoadLockName, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            Else
                                check = True
                            End If
                            If (Not check) Then
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError(strPressureError, True)
                                End If
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromRobotArm")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If
                        Case PICK_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PICK_WAFER_STEP.")
                            ' Robot Hand Retracted At XXX and Has A Wafer.
                            ' Please do not assume that Robot Hand Is At Home Position.
                            ControllerManager.SetWaferInsideStation(Source, "Off", Nothing, True) 'Wafer disappear inside robot
                            blnIsError = False
                            blnIsTaskFished = True
                            blnResult = True
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                AVPLib.ContainerData.LogSource.AVPMainScreen, "Pick Completed")

                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PickFromRobotArm")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Le Hieu Truc</name>
        '''    	<date> 2009-07-08</date>
        ''' </author>
        ''' <summary>
        ''' Update image for any moving of Robot hand
        ''' </summary>
        ''' <param name=Pos> Position to move</param>
        ''' <param name=blnRobotHasWafer> Has wafer inside robot hand or not? using for pick or place unsuccess</param>
        ''' <remarks></remarks>
        'Shared Sub MoveHandToPosition(ByVal pos As Positions)
        '    AVPLib.Log.coreLogger.Info("Enter MoveHandToPosition")
        '    Try
        '        'Thread.Sleep(RobotConfigurationValues.DELAY_ROBOT_ANIMATION)
        '        'Dim PropertyNames As ArrayList = New ArrayList()
        '        'PropertyNames.Add("CurrentPosition")
        '        'Dim Values As ArrayList = New ArrayList()
        '        'Values.Clear()
        '        'Values.Add(pos)
        '        'EquipmentManager.ChangeStatus(ConstEnum.Equipments.Robot.ToString(), PropertyNames, Values)
        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Error(ex.ToString())
        '    End Try
        '    AVPLib.Log.coreLogger.Info("Leave MoveHandToPosition")
        'End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Cao Anh Kiet</Name>
        '''   	<Date>2008-12-16</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Place wafer to destination
        ''' </summary>
        ''' <param name="Destination"></param>
        ''' <remarks></remarks>
        Private Function Place(ByVal Source As String,
                               ByVal Destination As String,
                               ByVal destRecipePath As String,
                               ByVal SourceSlotIdx As Integer,
                              ByVal DestSlotIdx As Integer) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter Place")
            Dim blnResult As Boolean = False
            Try
                AVPLib.Log.schedulerLogger.Debug("Source:" + Source)
                AVPLib.Log.schedulerLogger.Debug("Destination:" + Destination)
                AVPLib.Log.schedulerLogger.Debug("Destination Station Recipe:" + destRecipePath)
                If (Destination.IndexOf(ChamberID) >= 0) Then
                    If (HasTerminateRequest()) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Place")
                        Return False
                    End If
                    Dim awokenByTerminateThread As Boolean = SuspendIfNeeded()
                    If (m_sifSequenceInfor IsNot Nothing) And (False = awokenByTerminateThread) Then
                        Me.RaiseToWafer(Destination, m_sifSequenceInfor.WaferInfo.SlotID)
                    End If
                    If (awokenByTerminateThread) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Place")
                        Return False
                    End If

                    Dim ChamberName As String = String.Empty
                    ' check CJBatchProcessing in process
                    Dim chamberConfig As SystemModule = ContainerData.GetRobotConfig(Destination)
                    blnResult = PlaceToChamberMultiSlots(ChamberName, DestSlotIdx, Destination, destRecipePath)

                    If (HasTerminateRequest()) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Place")
                        Return False
                    End If
                    Me.RaiseToWafer(Destination, 0)
                ElseIf (Destination.IndexOf(LoadLockID) >= 0) Then
                    If (HasTerminateRequest()) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Place")
                        Return False
                    End If
                    blnResult = PlaceToLoadLock(Source, Destination)
                ElseIf (Destination.IndexOf(AlignerID) >= 0) Then
                    If (HasTerminateRequest()) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Place")
                        Return False
                    End If
                    blnResult = PlaceToAlginer(Source, Destination, destRecipePath)
                ElseIf (Destination.IndexOf(RobotArmID) >= 0) Then
                    If (HasTerminateRequest()) Then 'Abort
                        AVPLib.Log.schedulerLogger.Info("Leave Place")
                        Return False
                    End If
                    blnResult = PlaceToRobotArm(Source, Destination)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave Place")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-01-04</date>
        ''' </author>
        ''' <Modifiers>
        '''</Modifiers>
        ''' <summary>
        ''' Place wafer to Chamber Multi slot(Chamber1, Chamber2, Chamber3)
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PlaceToChamberMultiSlots(ByVal Source As String, ByVal SlotID As Integer, ByVal Destination As String, ByVal strRecipePath As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PlaceToChamberMultiSlots")
            Dim blResult As Boolean = False
            Try
                Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Destination)
                If (objChamber IsNot Nothing) Then
                    Dim objChamberConfig As SystemModule = ContainerData.GetRobotConfig(objChamber.Name)

                    If objChamberConfig IsNot Nothing Then
                        '' PVD4
                        If (objChamberConfig.Type = SystemModule.ModuleType.PVD4) Then
                            If (m_blnIsAutoTransfer) Then
                                SlotID = Me.BatchSlotID
                                AVPLib.Log.avpLogger.Error("JobID=" & Me.JobID & " ,Acquire Slot ID=" & Me.BatchSlotID.ToString())
                            End If
                            blResult = PlaceToCoronaChamber(Source, SlotID, Destination, strRecipePath)
                            'PVD5T
                        ElseIf objChamberConfig.Type = SystemModule.ModuleType.PVD5T Then
                            If (m_blnIsAutoTransfer) Then
                                SlotID = Me.BatchSlotID
                                AVPLib.Log.avpLogger.Error("JobID=" & Me.JobID & " ,Acquire Slot ID=" & Me.BatchSlotID.ToString())
                            End If
                            blResult = PlaceToPVD5TChamber(Source, SlotID, Destination, strRecipePath)
                        Else
                            blResult = PlaceToChamber(Source, Destination, strRecipePath)
                            'ADD MORE CHAMBER MULTY SLOT HERE
                            'USED FOR FUTURE
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamberMultiSlots")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-01-04</date>
        ''' </author>
        ''' <Modifiers>
        '''</Modifiers>
        ''' <summary>
        ''' Place wafer to Corona Chamber(Chamber1, Chamber2, Chamber3)
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PlaceToCoronaChamber(ByVal Source As String, ByVal SlotID As Integer, ByVal Destination As String, ByVal strRecipePath As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PlaceToCoronaChamber")
            Dim blnResult As Boolean = False
            Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Destination)
            Dim objCoronaChamber As DataManagerment.CoronaChamber = CType(objChamber, DataManagerment.CoronaChamber)
            Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
            Dim blIsMoveLiftDown As Boolean = False
            'Const HOME_INDEX_POSITION As Integer = 1
            Try
                AVPLib.Log.coreLogger.Error(JobID + " Start Place from Source:" + Source + "To Destination:" + Destination)

                Dim blnIsTaskFished As Boolean = False
                Dim outerStep = 1
                Dim blnIsError = False

                Dim chamberConfig As SystemModule = Nothing

                Const DO_NO_THING_STEP As Integer = 0
                Const CHECK_PRESSURE_STEP As Integer = 1
                Const VERIFY_MOTION_INITIALIZED As Integer = 2
                'Move table lift home
                Dim MOVE_TABLE_HOME As Integer = 3
                'check rotation table at wafer position and sub stable is up
                Dim CHECK_ROTATION_TABLE_POSITION As Integer = 4
                'rotate table to station X
                Dim MOVE_TABLE_TO_STATION_X As Integer = 5
                'Move sublift up 
                Dim MOVE_TABLE_UP As Integer = 6
                Const CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE As Integer = 7
                Const OPEN_SPLITVALVE_STEP As Integer = 8
                Const PLACE_WAFER_STEP As Integer = 9
                Const MOVE_TABLE_DOWN As Integer = 10
                Const MAKE_ROBOT_GO_TO_LOADLOCK As Integer = 11
                Const CLOSE_SPLITVALVE_STEP As Integer = 12
                Const START_RECIPE_PROCESSING As Integer = 13

                Dim strRegExp As String = "^(LoadLock[AB]),Slot"
                Dim mtcMatch As Match = Regex.Match(Destination, strRegExp)
                Dim LoadLockName As String = mtcMatch.Groups(1).Value


                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))

                    If blnIsError Then
                        StepMoveCoronaSubLiftToDown(objCoronaChamber)
                    End If

                    Dim awokenByTerminateThread As Boolean = SuspendIfNeeded()
                    If (awokenByTerminateThread OrElse IsCancelMove) Then
                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                        Return False
                    End If

                    If blnIsError Then
                        blnIsError = False
                    End If

                    If Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso
                       ((Destination.IndexOf(ChamberID) >= 0 AndAlso Not objTMController.IsStationOnline(Destination)) OrElse
                       (Destination.IndexOf(LoadLockID) >= 0 AndAlso Not objTMController.IsStationOnline(LoadLockName))) Then
                        If (m_blnIsAutoTransfer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    Select Case outerStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP")
                            blnIsError = False
                            Dim bcheck As Boolean = False
                            Dim strPressureError As String = String.Empty
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer
                            Dim blnPM_Is_Offline As Boolean = False
                            If (Destination.IndexOf(ChamberID) >= 0) Then
                                bcheck = objTMController.CheckCG10DifferenceFromStation(Destination, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError, blnPM_Is_Offline)
                            ElseIf (Destination.IndexOf(LoadLockID) >= 0) Then
                                bcheck = objTMController.CheckCG10DifferenceFromStation(LoadLockName, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            Else
                                bcheck = True
                            End If
                            If (Not bcheck) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError(strPressureError, True)
                                End If
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                    Return False
                                End If
                                If blnPM_Is_Offline Then
                                    m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Pressure OK")

                        Case VERIFY_MOTION_INITIALIZED
                            If Not (StepVerifyMotionStopped(objCoronaChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to wait for" + Utils.chamberID2ChamberName(Source) + " Motion stop", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'GO TO NEXT STEP
                            End If

                            AddActionLog("Check Motion Initalized OK")

                        Case MOVE_TABLE_HOME
                            'Move Table Lift go to Home
                            If Not (StepMoveCoronaTableLiftToHome(objCoronaChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Table to Home Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If

                            AddActionLog("Check Move Table To Home OK")

                        Case CHECK_ROTATION_TABLE_POSITION
                            'check current slot
                            If (CType(objChamber, CoronaChamber).Substrate_Current_Station = SlotID AndAlso
                                CType(objChamber, CoronaChamber).SetSubStrateLiftUpDownStatus(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)) Then
                                outerStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                            Else
                                outerStep = MOVE_TABLE_TO_STATION_X - 1
                            End If

                            AddActionLog("Check Current Slot OK")

                        Case MOVE_TABLE_TO_STATION_X
                            'if table is moving -> continue wait for motor
                            ContinueWaitMotor(objCoronaChamber)
                            'Special case for Go to Slot 1 because it call macro home.
                            'Take very long time to finish motion. Sleep 5s because backend keep 
                            'slot table 5s before update to GUI.
                            'If (SlotID = HOME_INDEX_POSITION) Then
                            Thread.Sleep(6000) 'WAIT MORE 5S
                            'End If

                            'if not at position -> send goto position
                            If (Not objCoronaChamber.IsSubStrateTableAtPosition(SlotID)) Then
                                'Move SubStrate go Down
                                If Not (StepMoveCoronaSubLiftToDown(objCoronaChamber)) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                    'Else 'Move Ok
                                    'GO TO NEXT STEP
                                End If

                                AddActionLog("Check Move SubStrate Go Down OK")

                                'move table go to slot X
                                If Not (StepMoveCoronaTableGoToSlot(objCoronaChamber, SlotID)) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed To Rotate Substrate To Station: " & SlotID, False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                                AddActionLog("Check Move Table Go To Slot X OK")
                                'Else -> GOTO NEXT STEP
                            End If

                            AddActionLog("Check MOVE TABLE TO STATION X OK")

                        Case MOVE_TABLE_UP
                            blIsMoveLiftDown = True
                            'Move SubLift go to Up
                            If Not (StepMoveCoronaSubLiftToUp(objCoronaChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Up Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If

                            AddActionLog("Check Move SubLift Go To Up OK")

                        Case CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE.")
                            Dim check As String = CheckRobotIsOkToOpenSlitValve(Destination)
                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError(check, False,
                                                  Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            End If

                        Case OPEN_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & Utils.chamberID2ChamberName(Destination) & " isovalve")

                            blnIsError = False
                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Destination, True)
                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Open " + Utils.chamberID2ChamberName(Destination) + " SlitValve: " & check, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveOpen, objChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(objChamber.Name)
                                        blnIsError = True
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Destination) + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                            Return False
                                        End If
                                        m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                        outerStep = CHECK_PRESSURE_STEP 'start place process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                            End If

                            AddActionLog("OPEN slit valve OK")

                        Case PLACE_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PLACE_WAFER_STEP")
                            blnIsError = False
                            Dim strErr As String = String.Empty
                            Dim check As Boolean = False
                            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())

                            If IsTableHome(objCoronaChamber) Then
                                ''previous pos#: retract with wafer
                                ''current pos#: extract with wafer
                                '''''''''''''''''place command is send ok? No ->retract with wafer
                                ''next_pos#: Yes: check sensor ok: extract without wafer
                                '''next_next_pos#:  retract without wafer
                                'Check have wafer
                                Dim eqpChamber As Chamber = EquipmentManager.GetEquipment(Destination)
                                If eqpChamber.GetWaferInfo(SlotID) IsNot Nothing Then
                                    OnProcessingError("Had wafer at " + Utils.chamberID2ChamberName(Destination), False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    outerStep = CHECK_PRESSURE_STEP 'start place process again
                                    JobPause()
                                    Continue While
                                End If

                                ' Wafer Movement Log
                                If (objRobot IsNot Nothing) AndAlso (objRobot.GetWaferInfo() IsNot Nothing) Then
                                    LogPlaceWaferMovement(objRobot.GetWaferInfo().WaferID, Destination)
                                    AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info,
                                    "Start Place Wafer: " & objRobot.GetWaferInfo().WaferID & " To: " & Utils.chamberID2ChamberName(objChamber.Name), m_blnIsAutoTransfer)
                                End If

                                Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                                strErr = ctrRobot.PlaceWaferToStation(Destination, IsAutoTransfer, IsReturnWafer) 'retract,extract with wafer if place success
                                check = IIf(strErr = String.Empty, True, False)
                            Else
                                strErr = "Table is not Home Position"
                            End If

                            m_ErrorWhenPlaceToStation = Not check
                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Place Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " To " + Utils.chamberID2ChamberName(Destination) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                ' If user resume, should restart at Place step.
                                'outerStep = PLACE_WAFER_STEP
                                outerStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Place wafer OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                 AVPLib.ContainerData.LogSource.AVPMainScreen, "Place Completed")

                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP")
                            Dim ChamberData As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(Destination), DataManagerment.Chamber)
                            'Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                            Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                            ' Show wafer image at Dest, and Hide wafer image at Source.
                            objChamber.AddWaferToList(objRobot.GetWaferInfo().WaferID)
                            objChamber.SetWaferInfo(objRobot.GetWaferInfo(), SlotID)
                            objRobot.SetWaferInfo()

                            AVPLib.Business.ControllerManager.SetWaferInsideChamber_without_UpdateGEM(objChamber.Name, STR_ON, objChamber.GetWaferInfo(SlotID), True, SlotID)
                            ControllerManager.SetWaferInsideSrc_Dst(Equipments.Robot.ToString(), objChamber.Name, objChamber.GetWaferInfo(SlotID), 1, SlotID)
                            Dim objPMController As ChamberController = ControllerManager.GetController(Destination)
                            If Not objPMController.DoSetWaferStatus(String.Format("{0:00}", CType(objChamber.WaferStatus, Integer))) Then
                                If IsAutoTransfer Then
                                    OnProcessingError("Failed to set wafer inside for " & Utils.chamberID2ChamberName(Destination), False)
                                End If
                            End If

                            ' AFTER PLACE WAFER SUCCESSFULLY => TRIGGER EVENT WAFER IN
                            ' Trigger SECS/GEM Event by Dat Vo
                            ' Var Name: PMX.WaferIn
                            Business.AVPSecsGemLib.TriggerEvent(Destination, "WaferIn")

                            Dim strCustomWaferId As String = Utils.GetGEMWaferID(objCoronaChamber.GetWaferInfo(SlotID).WaferID)
                            objCoronaChamber.Last_Wafer_In = strCustomWaferId

                            AddActionLog("Check sensor OK")

                        Case MOVE_TABLE_DOWN
                            'Move SubStrate go Down
                            If Not (StepMoveCoronaSubLiftToDown(objCoronaChamber)) Then
                                'If (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                If Not IsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = MOVE_TABLE_DOWN 'start pick process again
                                JobPause()
                                Continue While
                                'End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If

                            blIsMoveLiftDown = False
                            AddActionLog("Check Move SubStrate go Down OK")

                            ' ALWAYS DOES CLOSE_SPLITVALVE_STEP AFTER OPEN_SPLITVALVE_STEP
                            ' BUT WE CAN RESUME AT CLOSE_SPLITVALVE_STEP IF WE FAIL TO CLOSE SLIT VALVE.
                            outerStep = MAKE_ROBOT_GO_TO_LOADLOCK ' BYPASS ONE WHILE TURN.
                            GoTo MAKE_ROBOT_GO_TO_LOADLOCK

                        Case MAKE_ROBOT_GO_TO_LOADLOCK
MAKE_ROBOT_GO_TO_LOADLOCK:
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MAKE_ROBOT_GO_TO_LOADLOCK.")
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.MoveRobotToLoadLock(IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError(strErr, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If

                        Case CLOSE_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            blnIsError = False
                            Dim strError As String = CheckRobotIsOkToCloseSlitValve(Destination)
                            If strError <> String.Empty AndAlso RobotConfigurationValues.DEBUGMODE = False Then
                                OnProcessingError(strError, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If (checkRobotRetract = False) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Robot Hand is not retracted when open SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start place process again, do not do this in this step
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Robot Comm and Retracted OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & Utils.chamberID2ChamberName(Destination) & " isovalve")

                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Destination, False)
                            If (check <> String.Empty) Then
                                OnProcessingError("Close " + Utils.chamberID2ChamberName(Destination) + " SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            Else
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveClose, objChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(objChamber.Name)
                                        blnIsError = True
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Destination) + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToCoronaChamber")
                                            Return False
                                        End If
                                        'intStep = CHECK_PRESSURE_STEP 'start place process again, do not do this in this step
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                            End If

                            AddActionLog("CLOSE slit valve OK")

                            'move table go to slot X + 1
                            StepMoveNextSlot(objCoronaChamber, SlotID, False)

                            If (IsAutoTransfer) Then
                                IsGivenPriority = False
                                AVPLib.Log.schedulerLogger.Info("SET IS_GIVEN_PRIORITY OF THE PJ-" & JobID & " = " & IsGivenPriority.ToString())
                            End If
                            '--------------------------------------------
                            If Not AVPParentControlJob.RunWithRecipe Then
                                outerStep = DO_NO_THING_STEP - 1
                                blnIsTaskFished = True
                                blnResult = True
                            Else
                                outerStep = START_RECIPE_PROCESSING - 1
                            End If
                            If (objChamber.GetCountWaferIsProcessing() = BatchProcessCount) Then
                                Me.m_MasterBatchProcessing = True
                            End If

                        Case START_RECIPE_PROCESSING
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE")
                            AVPLib.Log.coreLogger.Error(JobID + " Start Recipe With Recipe Path Is " + strRecipePath)
                            blnIsError = False

                            Dim isPassCheck As Boolean = AVPDataLib.Verify() = 0 AndAlso AVPDataLib.IsSecureDllLoaded()
                            Dim isJobStop As Boolean = False
                            Dim startCheck As Long = 0

                            If (IsAutoTransfer) Then
                                Dim PathFrom As String = strRecipePath
                                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(Destination)
                                Dim PathTo As String = serverConfig.RecipeFolder + "\" + AVPLib.Utils.GetFileName(PathFrom, False)
                                Dim ibeController As ChamberController = ControllerManager.GetController(Destination)
                                Dim ibeChamber As Chamber = EquipmentManager.GetEquipment(Destination)
                                Dim ProcessModuleName As String = Utils.chamberID2ChamberName(Destination)
                                ' Log Wafer Movement
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, AVPLib.Utils.chamberID2ChamberName(Destination) & " start process with recipe = " & AVPLib.Utils.GetFileName(PathFrom, False))
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, "Start Time = " & DateTime.Now.ToString())

                                Const RELEASE_TRANSPORT_RESOURCE_STEP As Integer = 1
                                Const RESET_PROCESS_ERROR_STEP As Integer = 2
                                Const COPY_PROCESS_FILE_STEP As Integer = 3
                                Const SET_PROCESS_NAME_STEP As Integer = 4
                                Const SEND_START_COMMAND_STEP As Integer = 5
                                Const SEND_PAUSE_COMMAND_STEP As Integer = 6
                                Const SEND_RESUME_COMMAND_STEP As Integer = 7
                                Const CHECK_IF_IBE_PROCESS_STOPPED_YET_STEP As Integer = 8
                                Dim iStep = RELEASE_TRANSPORT_RESOURCE_STEP
                                Dim bHasError = False

                                If (objChamber.GetWaferInfo(SlotID) IsNot Nothing) Then
                                    'Update MaterialProcessingState by Dat Cao
                                    objChamber.GetWaferInfo(SlotID).WaferProcessingStatus = WaferProcessingState.PROCESSING
                                End If
                                While (True)
                                    Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                                    ' Scheduler aborted Or MarkForReturnEquipment.
                                    If (awokenByTerminateRequest) Then
                                        Dim bAbortedCmdSent As Boolean = False
                                        While (enumProcessStatus.eStop <> ibeChamber.RunProcessStatus)
                                            If (AbortInProcess And (False = bAbortedCmdSent)) Then
                                                bAbortedCmdSent = True
                                                If m_MasterBatchProcessing Then
                                                    Dim bResult As Boolean = ibeController.StopRecipe()
                                                    If (Not bResult) Then
                                                        OnProcessingError("Failed to send STOP command", False)
                                                        Return bResult
                                                    End If
                                                End If
                                            End If
                                            ' If abort only, we don't need to wait for recipe processing finished.
                                            If (bAbortedCmdSent) AndAlso (False = ReturnWafer) Then
                                                Exit While
                                            End If
                                            ' Sleep and Poll again.
                                            Thread.Sleep(500)
                                        End While
                                        Return False
                                    End If
                                    Select Case iStep
                                        Case RELEASE_TRANSPORT_RESOURCE_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.RELEASE_TRANSPORT_RESOURCE_STEP")
                                            bHasError = False
                                            ' Try to release Transport Resource as soon as possible for maximizing performance.
                                            ' of course we just proceed if we're actually holding the lock.
                                            ReleaseTransportResource()

                                            AddActionLog("Release transport resource OK")

                                        Case RESET_PROCESS_ERROR_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.RESET_PROCESS_ERROR_STEP")
                                                bHasError = False
                                                ibeController.Process_Reset_Error()

                                                AddActionLog("Reset Process Error OK")

                                            End If

                                        Case COPY_PROCESS_FILE_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.COPY_PROCESS_FILE_STEP")
                                                bHasError = False
                                                If (Not ibeController.CopyProcessFile(PathFrom, PathTo)) Then
                                                    AVPLib.Log.schedulerLogger.Error("failed to copy file from " & PathFrom & " to " & PathTo)
                                                    bHasError = True
                                                    JobPause()
                                                    Continue While
                                                End If

                                                AddActionLog("Copy Process File OK")

                                            End If

                                        Case SET_PROCESS_NAME_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SET_PROCESS_NAME_STEP")

                                                ' Send start CycleATM
                                                If m_blnIsAutoTransfer AndAlso AVPParentControlJob.IsCycleInATMMode Then
                                                    Dim val As String = "01"
                                                    If AVPParentControlJob.IsWithoutMotion Then
                                                        val = "00"
                                                    End If
                                                    If (Not ibeController.StartProcessCycleATM(val)) Then
                                                        OnProcessingError("failed to send CycleATM Start command.", False)
                                                        bHasError = True
                                                        JobPause()
                                                        Continue While
                                                    End If
                                                End If

                                                ' Send process LotID and WaferID before send recipe name.
                                                ibeController.SendProcessLotID()
                                                ibeController.SendProcessWaferID()

                                                bHasError = False
                                                If (Not ibeController.SetProcessName(PathFrom)) Then
                                                    OnProcessingError("failed to program recipe name: " & PathFrom, False)
                                                    bHasError = True
                                                    JobPause()
                                                    Continue While
                                                End If
                                                ' Set Run Data File Name also.
                                                Dim strRunDataFileName = GetCurrentChamberNameForRunData(Destination, objChamber.GetWaferInfo().WaferID)
                                                If (Not String.IsNullOrEmpty(strRunDataFileName)) Then
                                                    If (Not ibeController.SetDataRunFileName(strRunDataFileName)) Then
                                                        OnProcessingError("Failed to program Run Data File Name = " & strRunDataFileName & " for " & ProcessModuleName, False)
                                                    End If
                                                End If

                                                AddActionLog("Set Process Name OK")

                                            End If

                                        Case SEND_START_COMMAND_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SEND_START_COMMAND_STEP")
                                                bHasError = False
                                                objChamber.IsSchedulerRunningInPM = True
                                                If (Not ibeController.StartProcess()) Then
                                                    OnProcessingError("failed to send start command.", False)
                                                    bHasError = True
                                                    JobPause()
                                                    Continue While
                                                End If

                                                AddActionLog("Start Process OK")

                                                iStep = CHECK_IF_IBE_PROCESS_STOPPED_YET_STEP
                                                Continue While
                                            End If

                                        Case SEND_PAUSE_COMMAND_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SEND_PAUSE_COMMAND_STEP")
                                                bHasError = False
                                                If (Not ibeController.PauseProcess()) Then
                                                    OnProcessingError("Failed to send PAUSE command", False)
                                                    bHasError = True
                                                    JobPause()
                                                    Continue While
                                                Else

                                                    AddActionLog("Pause Process OK")

                                                    iStep = SEND_RESUME_COMMAND_STEP
                                                    Continue While
                                                End If
                                            End If
                                        Case SEND_RESUME_COMMAND_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SEND_RESUME_COMMAND_STEP")
                                                bHasError = False
                                                If (Not ibeController.ResumeProcess()) Then
                                                    OnProcessingError("Failed to send RESUME command", False)
                                                    bHasError = True
                                                    JobPause()
                                                    Continue While
                                                End If
                                                ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Resuming

                                                AddActionLog("Resume Process OK")

                                            End If
                                        Case CHECK_IF_IBE_PROCESS_STOPPED_YET_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.CHECK_IF_PROCESS_STOPPED_YET_STEP")
                                            'wait for master send start command
                                            If (m_MasterBatchProcessing = False AndAlso
                                            Not WaitOnCondition(AddressOf objCoronaChamber.IsProcessRecipeStarted,
                                            objCoronaChamber.ProcessRecipeStartedWaitTimeInMiliseconds, True)) Then
                                                If HasTerminateRequest() Then
                                                    Return False
                                                End If
                                                OnProcessingError(JobID & " Failed to wait for other wafers to start processing on " & Destination, False)
                                                AVPLib.Log.schedulerLogger.Error("Can't start processing:" & JobID)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            End If
                                            Dim bAbortedCmdSent As Boolean = False
                                            AVPLib.Log.schedulerLogger.Debug("Waiting for the chamber: " & ibeChamber.Name & " finished")

                                            While ((ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Starting) _
                                            Or (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Running) _
                                            Or (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Aborting) _
                                            Or (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Resuming))

                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " has RunProcessResult of " & ibeChamber.Name & " is " & ibeChamber.RunProcessResult.ToString())

                                                If (HasTerminateRequest() And AbortInProcess) Then
                                                    If (False = bAbortedCmdSent) Then
                                                        bAbortedCmdSent = True
                                                        If (m_MasterBatchProcessing) Then
                                                            AVPLib.Log.schedulerLogger.Debug("PJ - STOP_RECIPE_PROCESSING_STEP_IBE.SEND_STOP_COMMAND_STEP")
                                                            Dim bResult As Boolean = ibeController.StopRecipe()
                                                            If (Not bResult) Then
                                                                OnProcessingError("Failed to send STOP command for " & ProcessModuleName, False)
                                                                Return bResult
                                                            End If
                                                        End If
                                                    Else
                                                        If (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Starting) Then
                                                            ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Aborting
                                                        End If
                                                    End If
                                                End If
                                                If HasSuspendRequest() Then
                                                    AVPLib.Log.schedulerLogger.Debug("User want to pause Processing.")
                                                    Exit While
                                                End If
                                                If HasTerminateRequest() Then
                                                    AVPLib.Log.schedulerLogger.Debug("User want to abort Processing.")
                                                    Return False
                                                End If
                                                ' Sleeps for a while and then polls.
                                                Thread.Sleep(2000)
                                                CheckLicenseAndStopJobsIfNeeded(isPassCheck, isJobStop, startCheck)
                                            End While
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " has RunProcessResult of " & ibeChamber.Name & " is " & ibeChamber.RunProcessResult.ToString())
                                            If (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.CouldNotStart) Then
                                                ' If process stopped due to an error happenned during processing.
                                                AVPLib.Log.schedulerLogger.Debug("Process stopped because it cound't start.")
                                                bHasError = True
                                                iStep = SEND_START_COMMAND_STEP
                                                JobPause()
                                                Continue While
                                            End If
                                            If HasSuspendRequest() Then ' User pause this process job.
                                                AVPLib.Log.schedulerLogger.Debug("User paused this process job - " & JobID)
                                                If (Not ibeController.PauseProcess()) Then
                                                    OnProcessingError("Failed to send PAUSE command", False)
                                                    bHasError = True
                                                    ' JobPause() : not necessary because suspended event already set.
                                                    iStep = SEND_PAUSE_COMMAND_STEP
                                                    Continue While
                                                Else
                                                    iStep = SEND_RESUME_COMMAND_STEP
                                                    Continue While
                                                End If
                                            End If
                                            ' If process stopped due to an error happenned during processing.
                                            If (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.AlarmHappennedDuringProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("Process stopped due to an error happenned during processing.")
                                                JobPause()
                                                iStep = SEND_RESUME_COMMAND_STEP
                                                Continue While
                                            End If

                                            AddActionLog("Run Reicpe Done OK")

                                            ' Done with the sub state machine.
                                            Exit While
                                    End Select
                                    If (Not bHasError) Then
                                        iStep += 1
                                    End If
                                End While
                            End If
                            blnIsTaskFished = True
                            blnResult = True

                            If (objChamber.GetWaferInfo(SlotID) IsNot Nothing) Then
                                'Update MaterialProcessingState by Dat Cao
                                objChamber.GetWaferInfo(SlotID).WaferProcessingStatus = WaferProcessingState.READY_FOR_TRANSFER
                            End If

                            '-----------Optimize Scheduler---------------
                            If (IsAutoTransfer) Then
                                IsGivenPriority = True
                                AVPLib.Log.schedulerLogger.Info("SET IS_GIVEN_PRIORITY OF THE PJ-" & JobID & " = " & IsGivenPriority.ToString())
                            End If
                            '--------------------------------------------
                    End Select
                    If (Not blnIsError) Then
                        outerStep += 1
                    End If
                End While

                AddActionLog("Place To " + Destination + " OK")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                objChamber.IsSchedulerRunningInPM = False
                objChamber.ClearListOfWafer()
                If (blIsMoveLiftDown) Then
                    StepMoveCoronaSubLiftToDown(objCoronaChamber)
                End If
            End Try

            AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
            Return blnResult
        End Function

        Private Function PlaceToPVD5TChamber(ByVal Source As String, ByVal SlotID As Integer, ByVal Destination As String, ByVal strRecipePath As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PlaceToPVD5TChamber")
            Dim blnResult As Boolean = False
            Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Destination)
            Dim objPVD5TChamber As DataManagerment.PVD5TChamber = CType(objChamber, DataManagerment.PVD5TChamber)
            Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
            Dim blIsMoveLiftDown As Boolean = False
            'Const HOME_INDEX_POSITION As Integer = 1
            Try
                AVPLib.Log.coreLogger.Error(JobID + " Start Place from Source:" + Source + "To Destination:" + Destination)

                Dim blnIsTaskFished As Boolean = False
                Dim outerStep = 1
                Dim blnIsError = False

                Dim chamberConfig As SystemModule = Nothing

                Const DO_NO_THING_STEP As Integer = 0
                Const CHECK_PRESSURE_STEP As Integer = 1
                Const VERIFY_MOTION_INITIALIZED As Integer = 2
                'Move table lift home
                Dim MOVE_TABLE_HOME As Integer = 3
                'check rotation table at wafer position and sub stable is up
                Dim CHECK_ROTATION_TABLE_POSITION As Integer = 4
                'rotate table to station X
                Dim MOVE_TABLE_TO_STATION_X As Integer = 5
                'Move sublift up 
                Dim MOVE_TABLE_UP As Integer = 6
                Const CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE As Integer = 7
                Const OPEN_SPLITVALVE_STEP As Integer = 8
                Const PLACE_WAFER_STEP As Integer = 9
                Const MOVE_TABLE_DOWN As Integer = 10
                Const MAKE_ROBOT_GO_TO_LOADLOCK As Integer = 11
                Const CLOSE_SPLITVALVE_STEP As Integer = 12
                Const START_RECIPE_PROCESSING As Integer = 13

                Dim strRegExp As String = "^(LoadLock[AB]),Slot"
                Dim mtcMatch As Match = Regex.Match(Destination, strRegExp)
                Dim LoadLockName As String = mtcMatch.Groups(1).Value


                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))

                    If blnIsError Then
                        StepMovePVD5TSubLiftToDown(objPVD5TChamber)
                    End If

                    Dim awokenByTerminateThread As Boolean = SuspendIfNeeded()
                    If (awokenByTerminateThread OrElse IsCancelMove) Then
                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                        Return False
                    End If

                    If blnIsError Then
                        blnIsError = False
                    End If

                    If Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso
                       ((Destination.IndexOf(ChamberID) >= 0 AndAlso Not objTMController.IsStationOnline(Destination)) OrElse
                       (Destination.IndexOf(LoadLockID) >= 0 AndAlso Not objTMController.IsStationOnline(LoadLockName))) Then
                        If (m_blnIsAutoTransfer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    Select Case outerStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP")
                            blnIsError = False
                            Dim bcheck As Boolean = False
                            Dim strPressureError As String = String.Empty
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer
                            Dim blnPM_Is_Offline As Boolean = False
                            If (Destination.IndexOf(ChamberID) >= 0) Then
                                bcheck = objTMController.CheckCG10DifferenceFromStation(Destination, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError, blnPM_Is_Offline)
                            ElseIf (Destination.IndexOf(LoadLockID) >= 0) Then
                                bcheck = objTMController.CheckCG10DifferenceFromStation(LoadLockName, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            Else
                                bcheck = True
                            End If
                            If (Not bcheck) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError(strPressureError, True)
                                End If
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                    Return False
                                End If
                                If blnPM_Is_Offline Then
                                    m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Pressure OK")

                        Case VERIFY_MOTION_INITIALIZED
                            If Not (PVD5TStepVerifyMotionStopped(objPVD5TChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to wait for" + Utils.chamberID2ChamberName(Source) + " Motion stop", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'GO TO NEXT STEP
                            End If

                            AddActionLog("Check Motion Initalized OK")

                        Case MOVE_TABLE_HOME
                            'Move Table Lift go to Home
                            If Not (StepMovePVD5TTableLiftToHome(objPVD5TChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Table to Home Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If

                            AddActionLog("Check Move Table To Home OK")

                        Case CHECK_ROTATION_TABLE_POSITION
                            'check current slot
                            If (CType(objChamber, PVD5TChamber).Substrate_Current_Station = SlotID AndAlso
                                CType(objChamber, PVD5TChamber).SetSubStrateLiftUpDownStatus(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)) Then
                                outerStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                            Else
                                outerStep = MOVE_TABLE_TO_STATION_X - 1
                            End If

                            AddActionLog("Check Current Slot OK")

                        Case MOVE_TABLE_TO_STATION_X
                            'if table is moving -> continue wait for motor
                            PVD5TContinueWaitMotor(objPVD5TChamber)
                            'Special case for Go to Slot 1 because it call macro home.
                            'Take very long time to finish motion. Sleep 5s because backend keep 
                            'slot table 5s before update to GUI.
                            'If (SlotID = HOME_INDEX_POSITION) Then
                            Thread.Sleep(6000) 'WAIT MORE 5S
                            'End If

                            'if not at position -> send goto position
                            If (Not objPVD5TChamber.IsSubStrateTableAtPosition(SlotID)) Then
                                'Move SubStrate go Down
                                If Not (StepMovePVD5TSubLiftToDown(objPVD5TChamber)) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                    'Else 'Move Ok
                                    'GO TO NEXT STEP
                                End If

                                AddActionLog("Check Move SubStrate Go Down OK")

                                'move table go to slot X
                                If Not (StepMovePVD5TTableGoToSlot(objPVD5TChamber, SlotID)) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError("Failed To Rotate Substrate To Station: " & SlotID, False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                                AddActionLog("Check Move Table Go To Slot X OK")
                                'Else -> GOTO NEXT STEP
                            End If

                            AddActionLog("Check MOVE TABLE TO STATION X OK")

                        Case MOVE_TABLE_UP
                            blIsMoveLiftDown = True
                            'Move SubLift go to Up
                            If Not (StepMovePVD5TSubLiftToUp(objPVD5TChamber)) Then
                                If (RobotConfigurationValues.DEBUGMODE = False) Then
                                    OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Up Position", False)
                                    If Not IsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If

                            AddActionLog("Check Move SubLift Go To Up OK")
                        Case CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE.")
                            Dim check As String = CheckRobotIsOkToOpenSlitValve(Destination)
                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError(check, False,
                                                  Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            End If

                        Case OPEN_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                   AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & Utils.chamberID2ChamberName(Destination) & " isovalve")
                            blnIsError = False
                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Destination, True)

                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Open " + Utils.chamberID2ChamberName(Destination) + " SlitValve: " & check, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveOpen, objChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(objChamber.Name)
                                        blnIsError = True
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Destination) + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                            Return False
                                        End If
                                        m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                        outerStep = CHECK_PRESSURE_STEP 'start place process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                            End If
                            AddActionLog("OPEN slit valve OK")
                        Case PLACE_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PLACE_WAFER_STEP")
                            blnIsError = False
                            Dim strErr As String = String.Empty
                            Dim check As Boolean = False
                            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())

                            If PVD5TIsTableHome(objPVD5TChamber) Then
                                ''previous pos#: retract with wafer
                                ''current pos#: extract with wafer
                                '''''''''''''''''place command is send ok? No ->retract with wafer
                                ''next_pos#: Yes: check sensor ok: extract without wafer
                                '''next_next_pos#:  retract without wafer
                                'Check have wafer
                                Dim eqpChamber As Chamber = EquipmentManager.GetEquipment(Destination)
                                If eqpChamber.GetWaferInfo(SlotID) IsNot Nothing Then
                                    OnProcessingError("Had wafer at " + Utils.chamberID2ChamberName(Destination), False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    outerStep = CHECK_PRESSURE_STEP 'start place process again
                                    JobPause()
                                    Continue While
                                End If

                                ' Wafer Movement Log
                                If (objRobot IsNot Nothing) AndAlso (objRobot.GetWaferInfo() IsNot Nothing) Then
                                    LogPlaceWaferMovement(objRobot.GetWaferInfo().WaferID, Destination)
                                    AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info,
                                    "Start Place Wafer: " & objRobot.GetWaferInfo().WaferID & " To: " & Utils.chamberID2ChamberName(objChamber.Name), m_blnIsAutoTransfer)
                                End If

                                Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                                strErr = ctrRobot.PlaceWaferToStation(Destination, IsAutoTransfer, IsReturnWafer) 'retract,extract with wafer if place success
                                check = IIf(strErr = String.Empty, True, False)
                            Else
                                strErr = "Table is not Home Position"
                            End If

                            m_ErrorWhenPlaceToStation = Not check
                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Place Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " To " + Utils.chamberID2ChamberName(Destination) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                ' If user resume, should restart at Place step.
                                'outerStep = PLACE_WAFER_STEP
                                outerStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Place wafer OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                 AVPLib.ContainerData.LogSource.AVPMainScreen, "Place Completed")

                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP")
                            Dim ChamberData As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(Destination), DataManagerment.Chamber)
                            'Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                            Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                            ' Show wafer image at Dest, and Hide wafer image at Source.
                            objChamber.AddWaferToList(objRobot.GetWaferInfo().WaferID)
                            objChamber.SetWaferInfo(objRobot.GetWaferInfo(), SlotID)
                            objRobot.SetWaferInfo()

                            AVPLib.Business.ControllerManager.SetWaferInsideChamber_without_UpdateGEM(objChamber.Name, STR_ON, objChamber.GetWaferInfo(SlotID), True, SlotID)
                            ControllerManager.SetWaferInsideSrc_Dst(Equipments.Robot.ToString(), objChamber.Name, objChamber.GetWaferInfo(SlotID), 1, SlotID)
                            Dim objPMController As ChamberController = ControllerManager.GetController(Destination)
                            If Not objPMController.DoSetWaferStatus(String.Format("{0:00}", CType(objChamber.WaferStatus, Integer))) Then
                                If IsAutoTransfer Then
                                    OnProcessingError("Failed to set wafer inside for " & Utils.chamberID2ChamberName(Destination), False)
                                End If
                            End If

                            ' AFTER PLACE WAFER SUCCESSFULLY => TRIGGER EVENT WAFER IN
                            ' Trigger SECS/GEM Event by Dat Vo
                            ' Var Name: PMX.WaferIn
                            Business.AVPSecsGemLib.TriggerEvent(Destination, "WaferIn")

                            Dim strCustomWaferId As String = Utils.GetGEMWaferID(objPVD5TChamber.GetWaferInfo(SlotID).WaferID)
                            objPVD5TChamber.Last_Wafer_In = strCustomWaferId

                            AddActionLog("Check sensor OK")

                        Case MOVE_TABLE_DOWN
                            'Move SubStrate go Down
                            If Not (StepMovePVD5TSubLiftToDown(objPVD5TChamber)) Then
                                'If (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Failed to move " + Utils.chamberID2ChamberName(Source) + " Wafer Lift to Down Position:", False)
                                If Not IsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = MOVE_TABLE_DOWN 'start pick process again
                                JobPause()
                                Continue While
                                'End If
                                'Else 'Move Ok
                                'GO TO NEXT STEP
                            End If

                            blIsMoveLiftDown = False
                            AddActionLog("Check Move SubStrate go Down OK")

                            ' ALWAYS DOES CLOSE_SPLITVALVE_STEP AFTER OPEN_SPLITVALVE_STEP
                            ' BUT WE CAN RESUME AT CLOSE_SPLITVALVE_STEP IF WE FAIL TO CLOSE SLIT VALVE.
                            outerStep = MAKE_ROBOT_GO_TO_LOADLOCK ' BYPASS ONE WHILE TURN.
                            GoTo MAKE_ROBOT_GO_TO_LOADLOCK
                        Case MAKE_ROBOT_GO_TO_LOADLOCK
MAKE_ROBOT_GO_TO_LOADLOCK:
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MAKE_ROBOT_GO_TO_LOADLOCK.")
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.MoveRobotToLoadLock(IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            ' [0004886] Wait up to 10s for robot to confirm arrival at Loadlock Station 1 before proceeding.
                            If check Then
                                Try
                                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": Wait 10s for Robot to go to Station 1.")
                                    Dim isArrived As Boolean = WaitOnCondition(AddressOf IsRobotAtLoadlockPosition, 10000, True)
                                    If Not isArrived Then
                                        check = False
                                        strErr = "Failed to wait for Robot at Station 1"
                                    End If
                                Catch ex As Exception
                                    AVPLib.Log.avpLogger.Error("Wait PVD5T GoToLoadlock: " & ex.ToString())
                                End Try
                            End If

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError(strErr, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If
                        Case CLOSE_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            blnIsError = False
                            Dim strError As String = CheckRobotIsOkToCloseSlitValve(Destination)
                            If strError <> String.Empty AndAlso RobotConfigurationValues.DEBUGMODE = False Then
                                OnProcessingError(strError, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If (checkRobotRetract = False) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Robot Hand is not retracted when open SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start place process again, do not do this in this step
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Robot Comm and Retracted OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                   AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & Utils.chamberID2ChamberName(Destination) & " isovalve")

                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Destination, False)
                            If (check <> String.Empty) Then
                                OnProcessingError("Close " + Utils.chamberID2ChamberName(Destination) + " SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            Else
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveClose, objChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(objChamber.Name)
                                        blnIsError = True
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Destination) + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                            Return False
                                        End If
                                        'intStep = CHECK_PRESSURE_STEP 'start place process again, do not do this in this step
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                            End If
                            AddActionLog("CLOSE slit valve OK")

                            'move table go to slot X + 1
                            StepPVD5TMoveNextSlot(objPVD5TChamber, SlotID, False)

                            If (IsAutoTransfer) Then
                                IsGivenPriority = False
                                AVPLib.Log.schedulerLogger.Info("SET IS_GIVEN_PRIORITY OF THE PJ-" & JobID & " = " & IsGivenPriority.ToString())
                            End If
                            '--------------------------------------------
                            If Not AVPParentControlJob.RunWithRecipe Then
                                outerStep = DO_NO_THING_STEP - 1
                                blnIsTaskFished = True
                                blnResult = True
                            Else
                                outerStep = START_RECIPE_PROCESSING - 1
                            End If
                            If (objChamber.GetCountWaferIsProcessing() = BatchProcessCount) Then
                                Me.m_MasterBatchProcessing = True
                            End If

                        Case START_RECIPE_PROCESSING
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE")
                            AVPLib.Log.coreLogger.Error(JobID + " Start Recipe With Recipe Path Is " + strRecipePath)
                            blnIsError = False

                            Dim isPassCheck As Boolean = AVPDataLib.Verify() = 0 AndAlso AVPDataLib.IsSecureDllLoaded()
                            Dim isJobStop As Boolean = False
                            Dim startCheck As Long = 0

                            If (IsAutoTransfer) Then
                                Dim PathFrom As String = strRecipePath
                                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(Destination)
                                Dim PathTo As String = serverConfig.RecipeFolder + "\" + AVPLib.Utils.GetFileName(PathFrom, False)
                                Dim ibeController As ChamberController = ControllerManager.GetController(Destination)
                                Dim ibeChamber As Chamber = EquipmentManager.GetEquipment(Destination)
                                Dim ProcessModuleName As String = Utils.chamberID2ChamberName(Destination)
                                ' Log Wafer Movement
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, AVPLib.Utils.chamberID2ChamberName(Destination) & " start process with recipe = " & AVPLib.Utils.GetFileName(PathFrom, False))
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, "Start Time = " & DateTime.Now.ToString())

                                Const RELEASE_TRANSPORT_RESOURCE_STEP As Integer = 1
                                Const RESET_PROCESS_ERROR_STEP As Integer = 2
                                Const COPY_PROCESS_FILE_STEP As Integer = 3
                                Const SET_PROCESS_NAME_STEP As Integer = 4
                                Const SEND_START_COMMAND_STEP As Integer = 5
                                Const SEND_PAUSE_COMMAND_STEP As Integer = 6
                                Const SEND_RESUME_COMMAND_STEP As Integer = 7
                                Const CHECK_IF_IBE_PROCESS_STOPPED_YET_STEP As Integer = 8
                                Dim iStep = RELEASE_TRANSPORT_RESOURCE_STEP
                                Dim bHasError = False

                                If (objChamber.GetWaferInfo(SlotID) IsNot Nothing) Then
                                    'Update MaterialProcessingState by Dat Cao
                                    objChamber.GetWaferInfo(SlotID).WaferProcessingStatus = WaferProcessingState.PROCESSING
                                End If
                                While (True)
                                    Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                                    ' Scheduler aborted Or MarkForReturnEquipment.
                                    If (awokenByTerminateRequest) Then
                                        Dim bAbortedCmdSent As Boolean = False
                                        While (enumProcessStatus.eStop <> ibeChamber.RunProcessStatus)
                                            If (AbortInProcess And (False = bAbortedCmdSent)) Then
                                                bAbortedCmdSent = True
                                                If m_MasterBatchProcessing Then
                                                    Dim bResult As Boolean = ibeController.StopRecipe()
                                                    If (Not bResult) Then
                                                        OnProcessingError("Failed to send STOP command", False)
                                                        Return bResult
                                                    End If
                                                End If
                                            End If
                                            ' If abort only, we don't need to wait for recipe processing finished.
                                            If (bAbortedCmdSent) AndAlso (False = ReturnWafer) Then
                                                Exit While
                                            End If
                                            ' Sleep and Poll again.
                                            Thread.Sleep(500)
                                        End While
                                        Return False
                                    End If
                                    Select Case iStep
                                        Case RELEASE_TRANSPORT_RESOURCE_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.RELEASE_TRANSPORT_RESOURCE_STEP")
                                            bHasError = False
                                            ' Try to release Transport Resource as soon as possible for maximizing performance.
                                            ' of course we just proceed if we're actually holding the lock.
                                            ReleaseTransportResource()

                                            AddActionLog("Release transport resource OK")

                                        Case RESET_PROCESS_ERROR_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.RESET_PROCESS_ERROR_STEP")
                                                bHasError = False
                                                ibeController.Process_Reset_Error()

                                                AddActionLog("Reset Process Error OK")

                                            End If

                                        Case COPY_PROCESS_FILE_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.COPY_PROCESS_FILE_STEP")
                                                bHasError = False
                                                If (Not ibeController.CopyProcessFile(PathFrom, PathTo)) Then
                                                    AVPLib.Log.schedulerLogger.Error("failed to copy file from " & PathFrom & " to " & PathTo)
                                                    bHasError = True
                                                    JobPause()
                                                    Continue While
                                                End If

                                                AddActionLog("Copy Process File OK")

                                            End If

                                        Case SET_PROCESS_NAME_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SET_PROCESS_NAME_STEP")

                                                ' Send start CycleATM
                                                If m_blnIsAutoTransfer AndAlso AVPParentControlJob.IsCycleInATMMode Then
                                                    Dim val As String = "01"
                                                    If AVPParentControlJob.IsWithoutMotion Then
                                                        val = "00"
                                                    End If
                                                    If (Not ibeController.StartProcessCycleATM(val)) Then
                                                        OnProcessingError("failed to send CycleATM Start command.", False)
                                                        bHasError = True
                                                        JobPause()
                                                        Continue While
                                                    End If
                                                End If

                                                ' Send process LotID and WaferID before send recipe name.
                                                ibeController.SendProcessLotID()
                                                ibeController.SendProcessWaferID()

                                                bHasError = False
                                                If (Not ibeController.SetProcessName(PathFrom)) Then
                                                    OnProcessingError("failed to program recipe name: " & PathFrom, False)
                                                    bHasError = True
                                                    JobPause()
                                                    Continue While
                                                End If
                                                ' Set Run Data File Name also.
                                                Dim strRunDataFileName = GetCurrentChamberNameForRunData(Destination, objChamber.GetWaferInfo().WaferID)
                                                If (Not String.IsNullOrEmpty(strRunDataFileName)) Then
                                                    If (Not ibeController.SetDataRunFileName(strRunDataFileName)) Then
                                                        OnProcessingError("Failed to program Run Data File Name = " & strRunDataFileName & " for " & ProcessModuleName, False)
                                                    End If
                                                End If

                                                AddActionLog("Set Process Name OK")

                                            End If

                                        Case SEND_START_COMMAND_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SEND_START_COMMAND_STEP")
                                                bHasError = False
                                                objChamber.IsSchedulerRunningInPM = True
                                                If (Not ibeController.StartProcess()) Then
                                                    OnProcessingError("failed to send start command.", False)
                                                    bHasError = True
                                                    JobPause()
                                                    Continue While
                                                End If

                                                AddActionLog("Start Process OK")

                                                iStep = CHECK_IF_IBE_PROCESS_STOPPED_YET_STEP
                                                Continue While
                                            End If

                                        Case SEND_PAUSE_COMMAND_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SEND_PAUSE_COMMAND_STEP")
                                                bHasError = False
                                                If (Not ibeController.PauseProcess()) Then
                                                    OnProcessingError("Failed to send PAUSE command", False)
                                                    bHasError = True
                                                    JobPause()
                                                    Continue While
                                                Else

                                                    AddActionLog("Pause Process OK")

                                                    iStep = SEND_RESUME_COMMAND_STEP
                                                    Continue While
                                                End If
                                            End If
                                        Case SEND_RESUME_COMMAND_STEP
                                            If (m_MasterBatchProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SEND_RESUME_COMMAND_STEP")
                                                bHasError = False
                                                If (Not ibeController.ResumeProcess()) Then
                                                    OnProcessingError("Failed to send RESUME command", False)
                                                    bHasError = True
                                                    JobPause()
                                                    Continue While
                                                End If
                                                ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Resuming

                                                AddActionLog("Resume Process OK")

                                            End If
                                        Case CHECK_IF_IBE_PROCESS_STOPPED_YET_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.CHECK_IF_PROCESS_STOPPED_YET_STEP")
                                            'wait for master send start command
                                            If (m_MasterBatchProcessing = False AndAlso
                                            Not WaitOnCondition(AddressOf objPVD5TChamber.IsProcessRecipeStarted,
                                            objPVD5TChamber.ProcessRecipeStartedWaitTimeInMiliseconds, True)) Then
                                                If HasTerminateRequest() Then
                                                    Return False
                                                End If
                                                OnProcessingError(JobID & " Failed to wait for other wafers to start processing on " & Destination, False)
                                                AVPLib.Log.schedulerLogger.Error("Can't start processing:" & JobID)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            End If
                                            Dim bAbortedCmdSent As Boolean = False
                                            AVPLib.Log.schedulerLogger.Debug("Waiting for the chamber: " & ibeChamber.Name & " finished")

                                            While ((ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Starting) _
                                            Or (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Running) _
                                            Or (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Aborting) _
                                            Or (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Resuming))

                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " has RunProcessResult of " & ibeChamber.Name & " is " & ibeChamber.RunProcessResult.ToString())

                                                If (HasTerminateRequest() And AbortInProcess) Then
                                                    If (False = bAbortedCmdSent) Then
                                                        bAbortedCmdSent = True
                                                        If (m_MasterBatchProcessing) Then
                                                            AVPLib.Log.schedulerLogger.Debug("PJ - STOP_RECIPE_PROCESSING_STEP_IBE.SEND_STOP_COMMAND_STEP")
                                                            Dim bResult As Boolean = ibeController.StopRecipe()
                                                            If (Not bResult) Then
                                                                OnProcessingError("Failed to send STOP command for " & ProcessModuleName, False)
                                                                Return bResult
                                                            End If
                                                        End If
                                                    Else
                                                        If (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Starting) Then
                                                            ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Aborting
                                                        End If
                                                    End If
                                                End If
                                                If HasSuspendRequest() Then
                                                    AVPLib.Log.schedulerLogger.Debug("User want to pause Processing.")
                                                    Exit While
                                                End If
                                                If HasTerminateRequest() Then
                                                    AVPLib.Log.schedulerLogger.Debug("User want to abort Processing.")
                                                    Return False
                                                End If
                                                ' Sleeps for a while and then polls.
                                                Thread.Sleep(2000)
                                                CheckLicenseAndStopJobsIfNeeded(isPassCheck, isJobStop, startCheck)
                                            End While
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " has RunProcessResult of " & ibeChamber.Name & " is " & ibeChamber.RunProcessResult.ToString())
                                            If (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.CouldNotStart) Then
                                                ' If process stopped due to an error happenned during processing.
                                                AVPLib.Log.schedulerLogger.Debug("Process stopped because it cound't start.")
                                                bHasError = True
                                                iStep = SEND_START_COMMAND_STEP
                                                JobPause()
                                                Continue While
                                            End If
                                            If HasSuspendRequest() Then ' User pause this process job.
                                                AVPLib.Log.schedulerLogger.Debug("User paused this process job - " & JobID)
                                                If (Not ibeController.PauseProcess()) Then
                                                    OnProcessingError("Failed to send PAUSE command", False)
                                                    bHasError = True
                                                    ' JobPause() : not necessary because suspended event already set.
                                                    iStep = SEND_PAUSE_COMMAND_STEP
                                                    Continue While
                                                Else
                                                    iStep = SEND_RESUME_COMMAND_STEP
                                                    Continue While
                                                End If
                                            End If
                                            ' If process stopped due to an error happenned during processing.
                                            If (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.AlarmHappennedDuringProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("Process stopped due to an error happenned during processing.")
                                                JobPause()
                                                iStep = SEND_RESUME_COMMAND_STEP
                                                Continue While
                                            End If

                                            AddActionLog("Run Reicpe Done OK")

                                            ' Done with the sub state machine.
                                            Exit While
                                    End Select
                                    If (Not bHasError) Then
                                        iStep += 1
                                    End If
                                End While
                            End If
                            blnIsTaskFished = True
                            blnResult = True

                            If (objChamber.GetWaferInfo(SlotID) IsNot Nothing) Then
                                'Update MaterialProcessingState by Dat Cao
                                objChamber.GetWaferInfo(SlotID).WaferProcessingStatus = WaferProcessingState.READY_FOR_TRANSFER
                            End If

                            '-----------Optimize Scheduler---------------
                            If (IsAutoTransfer) Then
                                IsGivenPriority = True
                                AVPLib.Log.schedulerLogger.Info("SET IS_GIVEN_PRIORITY OF THE PJ-" & JobID & " = " & IsGivenPriority.ToString())
                            End If
                            '--------------------------------------------
                    End Select
                    If (Not blnIsError) Then
                        outerStep += 1
                    End If
                End While

                AddActionLog("Place To " + Destination + " OK")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                objChamber.IsSchedulerRunningInPM = False
                objChamber.ClearListOfWafer()
                If (blIsMoveLiftDown) Then
                    StepMovePVD5TSubLiftToDown(objPVD5TChamber)
                End If
            End Try

            AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
            Return blnResult
        End Function

        Private Function CheckRobotIsOkToOpenSlitValve(strChamber As String) As String
            AVPLib.Log.coreLogger.Info("Enter CheckRobotIsOkToOpenSlitValve")
            Dim strErrMsg As String = String.Empty
            Try
                Dim check As Boolean = RobotUtility.GetRobotPositionStatus(ConstEnum.Equipments.Robot.ToString())
                strErrMsg = AVPLib.Utils.IsRobotStationOKToOpenCloseSlitValve(strChamber, Utils.chamberID2ChamberName(strChamber), True)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckRobotIsOkToOpenSlitValve")
            Return strErrMsg
        End Function

        Private Function CheckRobotIsOkToCloseSlitValve(strChamber As String) As String
            AVPLib.Log.coreLogger.Info("Enter CheckRobotIsOkToCloseSlitValve")
            Dim strErrMsg As String = String.Empty
            Try
                Dim check As Boolean = RobotUtility.GetRobotPositionStatus(ConstEnum.Equipments.Robot.ToString())
                strErrMsg = AVPLib.Utils.IsRobotStationOKToOpenCloseSlitValve(strChamber, Utils.chamberID2ChamberName(strChamber), False)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckRobotIsOkToCloseSlitValve")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Cao Anh Kiet</Name>
        '''   	<Date>2008-12-16</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Pick wafer from Chamber
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PlaceToChamber(ByVal Source As String,
                                        ByVal Destination As String,
                                        ByVal strRecipePath As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PlaceToChamber")
            Dim blnResult As Boolean = False
            Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Destination)
            Try
                AVPLib.Log.schedulerLogger.Debug("Source:" + Source)
                AVPLib.Log.schedulerLogger.Debug("Destination:" + Destination)
                AVPLib.Log.schedulerLogger.Debug("Destination Station Recipe:" + strRecipePath)

                Dim blnIsTaskFished As Boolean = False
                Dim outerStep = 1
                Dim blnIsError = False
                Dim chamberConfig As SystemModule = Nothing
                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)
                Dim strRegExp As String = "^(LoadLock[AB]),Slot"
                Dim mtcMatch As Match = Regex.Match(Destination, strRegExp)
                Dim LoadLockName As String = mtcMatch.Groups(1).Value

                ''PLEASE ADD NOTE HERE IF CHANGE FLOW
                ''IBE FLOW:
                'CHECK PRESSURE ->CHECK MOTION OFF ->CLAMP UP ->VERIFY CLAMP UP ->MOTION INITIALIZE ->VERIFY MOTION ->OPEN SLITVALVE ->PICK WAFER->CLOSE SLITVALVE
                ''''''''''''''''->CHECK MOTION ON ->OPEN SLITVALVE ->PICK WAFER -> CLOSE SLITVALVE
                ''PVD FLOW:
                'CHECK PRESSURE ->OPEN SHUTTER ->VERIFY OPEN SHUTTER ->MOVE CHUCK TO ZERO ->VERIFY CHUCK ->UNCLAMP ->VERIFY UNCLAMP -> OPEN SLITVALVE ->PICK WAFER ->CLOSE SLITVALVE
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Const CHECK_PRESSURE_STEP As Integer = 1
                Const IBE_CLAMP_UP As Integer = 2
                Const IBE_VERIFY_CLAMP_UP As Integer = 3
                Const MOTION_INITIALIZE As Integer = 4
                Const VERIFY_MOTION_INITIALIZE As Integer = 5
                Const OPEN_SHUTTER As Integer = 6
                Const VERIFY_OPEN_SHUTTER As Integer = 7
                Const MOVE_CHUCK_TO_ZERO As Integer = 8
                Const VERIFY_CHUCK_POSITION As Integer = 9
                Const PVD_UNCLAMP As Integer = 10
                Const PVD_VERIFY_UNCLAMP As Integer = 11
                Const CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE As Integer = 12
                Const OPEN_SPLITVALVE_STEP As Integer = 13
                Const PLACE_WAFER_STEP As Integer = 14
                Const MAKE_ROBOT_GO_TO_LOADLOCK As Integer = 15
                Const CLOSE_SPLITVALVE_STEP As Integer = 16
                Const START_RECIPE_PROCESSING_STEP_IBE As Integer = 17
                Const START_RECIPE_PROCESSING_STEP_PVD As Integer = 18

                Const DO_NO_THING_STEP As Integer = 0

                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                    Dim awokenByTerminateThread As Boolean = SuspendIfNeeded(1)
                    If (awokenByTerminateThread OrElse IsCancelMove) Then
                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                        Return False
                    End If

                    If Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso
                       ((Destination.IndexOf(ChamberID) >= 0 AndAlso Not objTMController.IsStationOnline(Destination)) OrElse
                       (Destination.IndexOf(LoadLockID) >= 0 AndAlso Not objTMController.IsStationOnline(LoadLockName))) Then
                        If (m_blnIsAutoTransfer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    If blnIsError Then
                        blnIsError = False
                    End If
                    Select Case outerStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP")
                            blnIsError = False
                            Dim bcheck As Boolean = False
                            Dim strPressureError As String = String.Empty
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer
                            Dim blnPM_Is_Offline As Boolean = False
                            If (Destination.IndexOf(ChamberID) >= 0) Then
                                bcheck = objTMController.CheckCG10DifferenceFromStation(Destination, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError, blnPM_Is_Offline)
                            ElseIf (Destination.IndexOf(LoadLockID) >= 0) Then
                                bcheck = objTMController.CheckCG10DifferenceFromStation(LoadLockName, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            Else
                                bcheck = True
                            End If
                            If (Not bcheck) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError(strPressureError, True)
                                End If
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                    Return False
                                End If
                                If blnPM_Is_Offline Then
                                    m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If
                        Case IBE_CLAMP_UP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": IBE_CLAMP_UP.")
                            blnIsError = False
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(objChamber.Name) ' Get the configuration
                            If chamberConfig.Type = AVPLib.SystemModule.ModuleType.IBE Then
                                ''check motion off
                                If (objChamber.Initialize_Motion_readback <> Equipment.WorkingStatuses.On) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    ''send clamp Up if UnClamp
                                    Dim ibeChamber As IBEChamber = CType(objChamber, IBEChamber)
                                    ''clamp status is On = clamp up
                                    If (ibeChamber.ClampStatus <> Equipment.WorkingStatuses.On) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                        If Not (IBEUtility.Fixture_Clamp(objChamber.Name, ConfigurationValues.DEVICE_CLAMP_UP)) Then
                                            OnProcessingError(Utils.chamberID2ChamberName(Destination) + " is not intialized its Motion", False)
                                            If Not m_blnIsAutoTransfer Then
                                                AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                                Return False
                                            End If
                                            blnIsError = True
                                            outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                            JobPause()
                                            Continue While
                                        End If
                                    Else ''go to step MOTION_INITIALED IF CLAMP UP
                                        outerStep = MOTION_INITIALIZE - 1
                                    End If
                                ElseIf (objChamber.Initialize_Motion_readback = Equipment.WorkingStatuses.On) Then
                                    ''go to step OPEN_SPLITVALVE_STEP
                                    outerStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            ElseIf chamberConfig.Type = SystemModule.ModuleType.PVD Then
                                outerStep = OPEN_SHUTTER - 1
                            End If
                        Case IBE_VERIFY_CLAMP_UP
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(objChamber.Name) ' Get the configuration
                            If chamberConfig.Type = AVPLib.SystemModule.ModuleType.IBE Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": IBE_VERIFY_CLAMP_UP.")
                                blnIsError = False
                                Dim TimeForVerifyClampUp As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig(
                                                                         ConstEnum.CLAMP_UP_WAIT_TIME_IN_SECONDS, 30)
                                If Not CheckAndWaitForClampUp(CType(objChamber, IBEChamber), TimeForVerifyClampUp) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    If HasTerminateRequest() Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                        Return False
                                    End If
                                    OnProcessingError(Utils.chamberID2ChamberName(Destination) + " verify clamp up fail", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                            End If

                        Case MOTION_INITIALIZE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MOTION_INITIALIZE.")
                            blnIsError = False
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(objChamber.Name) ' Get the configuration
                            If chamberConfig.Type = AVPLib.SystemModule.ModuleType.IBE Then
                                ''check motion initialize
                                If (objChamber.Initialize_Motion_readback <> Equipment.WorkingStatuses.On) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    ''send command to initialze motion
                                    If Not IBEUtility.Initialize_Motion(objChamber.Name, ConfigurationValues.DEVICE_STATUS_OPEN) Then
                                        OnProcessingError(Utils.chamberID2ChamberName(Destination) + " is not intialized its Motion", False)
                                        If Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                        JobPause()
                                        Continue While
                                    End If
                                Else
                                    outerStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            End If
                        Case VERIFY_MOTION_INITIALIZE
                            If objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.IBE Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_MOTION_INITIALIZE.")
                                blnIsError = False
                                Dim TimeForVerifyMotionInitialize As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig(
                                                                             ConstEnum.MOTION_INITIALZE_WAIT_TIME_IN_SECONDS, 2 * 60) '2 minutes
                                If Not CheckAndWaitForMotionInitialize(objChamber, TimeForVerifyMotionInitialize) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    If HasTerminateRequest() Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                        Return False
                                    End If
                                    OnProcessingError(Utils.chamberID2ChamberName(Destination) + " motion initialize failed", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                Else ''GO DIRECTLY TO OPEN SLITVALVE
                                    outerStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Error("DO NOT HAVE MOTION INITIALIZE")
                            End If
                        Case OPEN_SHUTTER
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SHUTTER")
                            blnIsError = False
                            chamberConfig = AVPLib.ContainerData.GetRobotConfig(objChamber.Name) ' Get the configuration
                            'FIX ISSUE THAT SUPPORT BOTH PVD AND IBE
                            'Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                            'If PVD we need to open shutter
                            'If IBE we need to open shutter too
                            'Dim pvdChamber As PVDChamber = CType(srcChamber, PVDChamber)
                            If objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                'check if shutter is installed -> need to Open shutter,else skip this step
                                If chamberConfig.ShutterVisible AndAlso Not (objChamber.IsShutterOpen()) Then
                                    If Not (PVDUtility.Shutter_Valve(objChamber.Name, ConfigurationValues.DEVICE_STATUS_OPEN.ToString())) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError(Utils.chamberID2ChamberName(Destination) + " can not send command to open shutter", False)
                                        If Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        outerStep = CHECK_PRESSURE_STEP 'start place process again
                                        JobPause()
                                        Continue While
                                    End If
                                Else 'if Shutter is already Opened
                                    outerStep = MOVE_CHUCK_TO_ZERO - 1
                                End If
                            Else
                                'ElseIf objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.IBE Then
                                '    'check if shutter is installed -> need to Open shutter,else skip this step
                                '    If chamberConfig.ShutterVisible AndAlso Not (objChamber.IsShutterOpen()) Then
                                '        If Not (IBEUtility.Shutter_Position(objChamber.Name, IBEConfigurationValues.DEVICE_STATUS_OPEN)) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                '            OnProcessingError(Utils.chamberID2ChamberName(Destination) + " can not send command to open shutter", False)
                                '            If Not m_blnIsAutoTransfer Then
                                '                AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                '                Return False
                                '            End If
                                '            blnIsError = True
                                '            outerStep = CHECK_PRESSURE_STEP 'start place process again
                                '            JobPause()
                                '            Continue While
                                '        End If
                                '    Else 'if Shutter is already Opened
                                outerStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                            End If

                        Case VERIFY_OPEN_SHUTTER
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_OPEN_SHUTTER")
                            blnIsError = False
                            Dim TimeForOpenShutter As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig(
                                                                     ConstEnum.OPEN_SHUTTER_WAIT_TIME_IN_SECONDS, 2)
                            'Dim objPvdChamber As PVDChamber = CType(objChamber, PVDChamber)
                            If Not CheckAndWaitForShutterOpen(objChamber, TimeForOpenShutter) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                If HasTerminateRequest() Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                    Return False
                                End If
                                OnProcessingError(Utils.chamberID2ChamberName(Destination) + " open shutter failed", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'outerStep = OPEN_SHUTTER
                                outerStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            End If

                            If (objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.IBE) Then
                                'Go directly to OPEN_SPLITVALVE_STEP, ignore the move chuck step
                                outerStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                            End If

                        Case MOVE_CHUCK_TO_ZERO
                            If objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MOVE_CHUCK_TO_ZERO")
                                blnIsError = False
                                Dim objPvdChamber As PVDChamber = CType(objChamber, PVDChamber)
                                If Not (CInt(objPvdChamber.ChuckPos_Readback) = 0) Then
                                    If Not (PVDUtility.Chuck_Pos2(objPvdChamber.Name, Chuck_Zero_Distant)) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError(Utils.chamberID2ChamberName(Destination) + " can not send command to move chuck to zero", False)
                                        If Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        outerStep = CHECK_PRESSURE_STEP 'start place process again
                                        JobPause()
                                        Continue While
                                    End If
                                Else 'if Chuck distant is already Zero
                                    outerStep = PVD_UNCLAMP - 1
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Error("DO NOT HAVE CHUCK TO OPEN")
                            End If
                        Case VERIFY_CHUCK_POSITION
                            If objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_CHUCK_POSITION")
                                blnIsError = False
                                Dim TimeForMoveChuckToZero As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig(
                                                                        ConstEnum.MOVING_CHUCK_TO_ZERO_WAIT_TIME_IN_SECONDS, 30)
                                Dim objPvdChamber As PVDChamber = CType(objChamber, PVDChamber)
                                If Not CheckAndWaitForMovingChuckToZero(objPvdChamber, TimeForMoveChuckToZero) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    If HasTerminateRequest() Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                        Return False
                                    End If
                                    OnProcessingError(Utils.chamberID2ChamberName(Destination) + " move chuck to Zero fail", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    'outerStep = MOVE_CHUCK_TO_ZERO
                                    outerStep = CHECK_PRESSURE_STEP 'start place process again
                                    JobPause()
                                    Continue While
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Error("DO NOT HAVE CHUCK TO OPEN")
                            End If
                        Case PVD_UNCLAMP
                            'AVP.  Manual transfer/scheduling.   If PVD had flowcool/clamp installed,   we need to unclamp also before transferring wafer out.
                            Dim pvdChamber As PVDChamber = CType(objChamber, PVDChamber)
                            Dim objChamberConfig As SystemModule = ContainerData.GetRobotConfig(objChamber.Name)
                            If objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD AndAlso objChamberConfig.ClampInstalled Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": UNCLAMP TO PLACE WAFER FROM CHAMBER.")
                                blnIsError = False
                                If Not (pvdChamber.ClampStatus_Readback = Equipment.WorkingStatuses.Off) Then ''not unclamp
                                    ''send unclamp
                                    If Not PVDUtility.Clamp_UnClamp_Status(objChamber.Name, ConfigurationValues.DEVICE_STATUS_CLOSED) Then
                                        'And (RobotConfigurationValues.DEBUGMODE = False) Then
                                        OnProcessingError(Utils.chamberID2ChamberName(Source) + " can not send command to UnClamp to PVD", False)
                                        If Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                            Return False
                                        End If
                                        blnIsError = True
                                        outerStep = CHECK_PRESSURE_STEP 'start place process again
                                        JobPause()
                                        Continue While
                                    End If
                                Else 'if already Unclamp
                                    outerStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1
                                End If
                            Else
                                'If Clamp is not install -> move over these steps 
                                outerStep = CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE - 1 '
                                AVPLib.Log.schedulerLogger.Error("DO NOT UNCLAMP TO PICK WAFER FROM CHAMBER")
                            End If

                        Case PVD_VERIFY_UNCLAMP
                            'AVP.  Manual transfer/scheduling.   If PVD had flowcool/clamp installed,   we need to unclamp also before transferring wafer out.
                            If objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD Then
                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": VERIFY_UNCLAMP_PVD.")
                                blnIsError = False
                                Dim pvdChamber As PVDChamber = CType(objChamber, PVDChamber)
                                Dim TimeForVerifyUnClamp As Integer = ContainerData.GetIntegerFromKeyValueInRobotConfig(
                                                                      ConstEnum.PVD_UNCLAMP_WAIT_TIME_IN_SECONDS, RobotConfigurationValues.PVD_UNCLAMP_WAIT_TIME)
                                If Not CheckAndWaitForUnClamp(pvdChamber, TimeForVerifyUnClamp) Then 'And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    If HasTerminateRequest() Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                        Return False
                                    End If
                                    OnProcessingError(Utils.chamberID2ChamberName(Source) + " unclamp fail", False)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                        Return False
                                    End If
                                    blnIsError = True
                                    outerStep = CHECK_PRESSURE_STEP 'start place process again
                                    JobPause()
                                    Continue While
                                End If
                            Else
                                AVPLib.Log.schedulerLogger.Error("DO NOT UNCLAMP TO PLACE WAFER FROM CHAMBER")
                            End If

                        Case CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SAFETY_ROBOT_BEFOR_OPEN_SLIT_VALVE.")
                            Dim check As String = CheckRobotIsOkToOpenSlitValve(Destination)
                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError(check, False,
                                                  Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            End If

                        Case OPEN_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & Utils.chamberID2ChamberName(Destination) & " isovalve")

                            blnIsError = False
                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Destination, True)
                            If (check <> String.Empty) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Open " + Utils.chamberID2ChamberName(Destination) + " SlitValve: " & check, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveOpen, objChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(objChamber.Name)
                                        blnIsError = True
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Destination) + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                            Return False
                                        End If
                                        m_blnJobPausedBy_PMOffline_CloseSplitValve = True
                                        outerStep = CHECK_PRESSURE_STEP 'start place process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                            End If
                            'DO NOT SEND SLITVALVE STATUS TO IBE/PVD, ONLY SEND ON SLIT VALVE STATUS PROPERTY
                            'If IsAutoTransfer Then
                            '    Dim pmController As ChamberController = ControllerManager.GetController(Destination)
                            '    If Not pmController.SetIsoValveStatus(True) Then
                            '        OnProcessingError("Failed to set Slit valve Status = Open for, " + Utils.chamberID2ChamberName(Destination), False)
                            '        blnIsError = True
                            '        outerStep = CHECK_PRESSURE_STEP 'start place process again
                            '        JobPause()
                            '        Continue While
                            '    End If
                            '    SleepButAlertabletoTerminateRequest(1000)
                            'End If
                        Case PLACE_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PLACE_WAFER_STEP")
                            blnIsError = False
                            ''previous pos#: retract with wafer
                            ''current pos#: extract with wafer
                            '''''''''''''''''place command is send ok? No ->retract with wafer
                            ''next_pos#: Yes: check sensor ok: extract without wafer
                            '''next_next_pos#:  retract without wafer
                            'Check have wafer
                            Dim eqpChamber As Chamber = EquipmentManager.GetEquipment(Destination)
                            If eqpChamber.GetWaferInfo(GetSlotID(eqpChamber.Name)) IsNot Nothing Then
                                OnProcessingError("Had wafer at " + Utils.chamberID2ChamberName(Destination), False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            End If

                            ' Wafer Movement Log
                            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
                            If (objRobot IsNot Nothing) AndAlso (objRobot.GetWaferInfo() IsNot Nothing) Then
                                LogPlaceWaferMovement(objRobot.GetWaferInfo().WaferID, Destination)
                                AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info,
                                "Start Place Wafer: " & objRobot.GetWaferInfo().WaferID & " To: " & Utils.chamberID2ChamberName(objChamber.Name), m_blnIsAutoTransfer)
                            End If

                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.PlaceWaferToStation(Destination, IsAutoTransfer, IsReturnWafer) 'retract,extract with wafer if place success
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)
                            m_ErrorWhenPlaceToStation = Not check
                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Place Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " To " + Utils.chamberID2ChamberName(Destination) & ". " & strErr, False,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                    Return False
                                End If
                                blnIsError = True
                                ' If user resume, should restart at Place step.
                                'outerStep = PLACE_WAFER_STEP
                                outerStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            End If

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                 AVPLib.ContainerData.LogSource.AVPMainScreen, "Place Completed")

                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP")
                            Dim ChamberData As DataManagerment.Chamber = CType(EquipmentManager.GetEquipment(Destination), DataManagerment.Chamber)
                            'Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                            Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                            ' Show wafer image at Dest, and Hide wafer image at Source.
                            objChamber.SetWaferInfo(objRobot.GetWaferInfo())
                            objRobot.SetWaferInfo()

                            'set wafer processing status in SetWaferInsideChamber Function
                            'donot set here
                            'If (objChamber.GetWaferInfo() IsNot Nothing) Then
                            '    'Update MaterialProcessingState by Dat Cao
                            '    Dim chamberIndex As String = objChamber.Name.Replace("Chamber", "")
                            '    Dim CurrentState As Integer = Convert.ToInt32(chamberIndex) + WaferProcessingState.IN_CASSETTE_MODULE
                            '    objChamber.GetWaferInfo().WaferProcessingStatus = CurrentState
                            'End If
                            ''if not completed, not error
                            'If (m_sifSequenceInfor.WaferInfo.WaferStatus <> enumWaferStatus.eWaferError And _
                            'm_sifSequenceInfor.WaferInfo.WaferStatus <> enumWaferStatus.eWaferComplete) Then
                            '    m_sifSequenceInfor.WaferInfo.WaferStatus = ConstEnum.enumWaferStatus.eWaferExposed
                            'End If
                            ControllerManager.SetWaferInsideSrc_Dst(Equipments.Robot.ToString(), objChamber.Name, objChamber.GetWaferInfo())
                            Dim objPMController As ChamberController = ControllerManager.GetController(Destination)
                            If Not objPMController.DoSetWaferStatus(String.Format("{0:00}", CType(objChamber.GetWaferInfo().WaferStatus, Integer))) Then
                                If IsAutoTransfer Then
                                    OnProcessingError("Failed to set wafer inside for " & Utils.chamberID2ChamberName(Destination), False)
                                End If
                            End If

                            ' AFTER PLACE WAFER SUCCESSFULLY => TRIGGER EVENT WAFER IN
                            ' Trigger SECS/GEM Event by Dat Vo
                            ' Var Name: PMX.WaferIn
                            Business.AVPSecsGemLib.TriggerEvent(Destination, "WaferIn")

                            ' ALWAYS DOES CLOSE_SPLITVALVE_STEP AFTER OPEN_SPLITVALVE_STEP
                            ' BUT WE CAN RESUME AT CLOSE_SPLITVALVE_STEP IF WE FAIL TO CLOSE SLIT VALVE.
                            outerStep = MAKE_ROBOT_GO_TO_LOADLOCK ' BYPASS ONE WHILE TURN.
                            GoTo MAKE_ROBOT_GO_TO_LOADLOCK
                        Case MAKE_ROBOT_GO_TO_LOADLOCK
MAKE_ROBOT_GO_TO_LOADLOCK:
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": MAKE_ROBOT_GO_TO_LOADLOCK.")
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.MoveRobotToLoadLock(IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)

                            If (Not check) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError(strErr, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToPVD5TChamber")
                                    Return False
                                End If
                                blnIsError = True
                                outerStep = CHECK_PRESSURE_STEP 'start pick process again
                                JobPause()
                                Continue While
                            End If
                        Case CLOSE_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            blnIsError = False
                            Dim strError As String = CheckRobotIsOkToCloseSlitValve(Destination)
                            If strError <> String.Empty AndAlso RobotConfigurationValues.DEBUGMODE = False Then
                                OnProcessingError(strError, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If (checkRobotRetract = False) And (RobotConfigurationValues.DEBUGMODE = False) Then
                                OnProcessingError("Robot Hand is not retracted when open SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start place process again, do not do this in this step
                                JobPause()
                                Continue While
                            End If

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & Utils.chamberID2ChamberName(Destination) & " isovalve")

                            Dim check As String = ChamberUtility.OpenCloseSlitValve(Destination, False)
                            If (check <> String.Empty) Then
                                OnProcessingError("Close " + Utils.chamberID2ChamberName(Destination) + " SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            Else
                                If Not WaitOnCondition(AddressOf Utils.IsChamberSlitValveClose, objChamber.Name, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(objChamber.Name)
                                        blnIsError = True
                                        OnProcessingError("Failed to wait for " + Utils.chamberID2ChamberName(Destination) + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
                                            Return False
                                        End If
                                        'intStep = CHECK_PRESSURE_STEP 'start place process again, do not do this in this step
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                            End If

                            ''DO NOT SEND SLITVALVE STATUS TO IBE/PVD, ONLY SEND ON SLIT VALVE STATUS PROPERTY
                            'If IsAutoTransfer Then
                            '    Dim pmController As ChamberController = ControllerManager.GetController(Destination)
                            '    If Not pmController.SetIsoValveStatus(False) Then
                            '        OnProcessingError("Failed to set Slit valve Status = Closed for, " + Utils.chamberID2ChamberName(Destination), False)
                            '        blnIsError = True
                            '        JobPause()
                            '        'intStep = CHECK_PRESSURE_STEP 'start place process again, do not do this in this step
                            '        Continue While
                            '    End If
                            '    ' Make sure PM has known about this status.
                            '    SleepButAlertabletoTerminateRequest(3000)
                            'End If

                            '-----------Optimize Scheduler---------------
                            If (IsAutoTransfer) Then
                                IsGivenPriority = False
                                AVPLib.Log.schedulerLogger.Info("SET IS_GIVEN_PRIORITY OF THE PJ-" & JobID & " = " & IsGivenPriority.ToString())
                            End If
                            '--------------------------------------------
                            If Not AVPParentControlJob.RunWithRecipe Then
                                outerStep = DO_NO_THING_STEP - 1
                                blnIsTaskFished = True
                                blnResult = True
                            Else
                                ' Run Recipe only if user wants.
                                Dim objSystemModule As SystemModule = Nothing
                                AVPLib.ContainerData.IsChamberVisible(objChamber.Name, objSystemModule)
                                If objSystemModule.Type = AVPLib.SystemModule.ModuleType.IBE Then
                                    outerStep = START_RECIPE_PROCESSING_STEP_IBE - 1
                                Else
                                    outerStep = START_RECIPE_PROCESSING_STEP_PVD - 1
                                End If
                            End If

                        Case START_RECIPE_PROCESSING_STEP_IBE
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE")
                            blnIsError = False

                            Dim isPassCheck As Boolean = AVPDataLib.Verify() = 0 AndAlso AVPDataLib.IsSecureDllLoaded()
                            Dim isJobStop As Boolean = False
                            Dim startCheck As Long = 0

                            If (IsAutoTransfer) Then
                                Dim PathFrom As String = strRecipePath
                                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(Destination)
                                Dim PathTo As String = serverConfig.RecipeFolder + "\" + AVPLib.Utils.GetFileName(PathFrom, False)
                                Dim ibeController As ChamberController = ControllerManager.GetController(Destination)
                                Dim ibeChamber As Chamber = EquipmentManager.GetEquipment(Destination)
                                Dim ProcessModuleName As String = Utils.chamberID2ChamberName(Destination)
                                ' Log Wafer Movement
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, AVPLib.Utils.chamberID2ChamberName(Destination) & " start process with recipe = " & AVPLib.Utils.GetFileName(PathFrom, False))
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, "Start Time = " & DateTime.Now.ToString())

                                Const RELEASE_TRANSPORT_RESOURCE_STEP As Integer = 1
                                Const RESET_PROCESS_ERROR_STEP As Integer = 2
                                Const COPY_PROCESS_FILE_STEP As Integer = 3
                                Const SET_PROCESS_NAME_STEP As Integer = 4
                                Const SEND_START_COMMAND_STEP As Integer = 5
                                Const SEND_PAUSE_COMMAND_STEP As Integer = 6
                                Const SEND_RESUME_COMMAND_STEP As Integer = 7
                                Const CHECK_IF_IBE_PROCESS_STOPPED_YET_STEP As Integer = 8
                                Dim iStep = RELEASE_TRANSPORT_RESOURCE_STEP
                                Dim bHasError = False

                                If (objChamber.GetWaferInfo() IsNot Nothing) Then
                                    'Update MaterialProcessingState by Dat Cao
                                    objChamber.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.PROCESSING
                                End If
                                While (True)
                                    Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                                    ' Scheduler aborted Or MarkForReturnEquipment.
                                    If (awokenByTerminateRequest) Then
                                        Dim bAbortedCmdSent As Boolean = False
                                        While (enumProcessStatus.eStop <> ibeChamber.RunProcessStatus)
                                            If (AbortInProcess And (False = bAbortedCmdSent)) Then
                                                Dim bResult As Boolean = ibeController.StopRecipe()
                                                bAbortedCmdSent = True
                                                If (Not bResult) Then
                                                    OnProcessingError("Failed to send STOP command", False)
                                                    Return bResult
                                                End If
                                            End If
                                            ' If abort only, we don't need to wait for recipe processing finished.
                                            If (bAbortedCmdSent) AndAlso (False = ReturnWafer) Then
                                                Exit While
                                            End If
                                            ' Sleep and Poll again.
                                            Thread.Sleep(500)
                                        End While
                                        Return False
                                    End If
                                    Select Case iStep
                                        Case RELEASE_TRANSPORT_RESOURCE_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.RELEASE_TRANSPORT_RESOURCE_STEP")
                                            bHasError = False
                                            ' Try to release Transport Resource as soon as possible for maximizing performance.
                                            ' of course we just proceed if we're actually holding the lock.
                                            ReleaseTransportResource()
                                        Case RESET_PROCESS_ERROR_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.RESET_PROCESS_ERROR_STEP")
                                            bHasError = False
                                            ibeController.Process_Reset_Error()
                                        Case COPY_PROCESS_FILE_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.COPY_PROCESS_FILE_STEP")
                                            bHasError = False
                                            If (Not ibeController.CopyProcessFile(PathFrom, PathTo)) Then
                                                OnProcessingError("failed to copy file from " & PathFrom & " to " & PathTo, False)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            End If
                                        Case SET_PROCESS_NAME_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SET_PROCESS_NAME_STEP")

                                            ' Send process LotID and WaferID before send recipe name.
                                            ibeController.SendProcessLotID()
                                            ibeController.SendProcessWaferID()

                                            bHasError = False
                                            If (Not ibeController.SetProcessName(PathFrom)) Then
                                                OnProcessingError("failed to program recipe name: " & PathFrom, False)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            End If
                                            ' Set Run Data File Name also.
                                            Dim strRunDataFileName = GetCurrentChamberNameForRunData(Destination, objChamber.GetWaferInfo().WaferID)
                                            If (Not String.IsNullOrEmpty(strRunDataFileName)) Then
                                                If (Not ibeController.SetDataRunFileName(strRunDataFileName)) Then
                                                    OnProcessingError("Failed to program Run Data File Name = " & strRunDataFileName & " for " & ProcessModuleName, False)
                                                End If
                                            End If
                                        Case SEND_START_COMMAND_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SEND_START_COMMAND_STEP")
                                            bHasError = False
                                            objChamber.IsSchedulerRunningInPM = True
                                            If (Not ibeController.StartProcess()) Then
                                                OnProcessingError("failed to send start command.", False)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            End If
                                            iStep = CHECK_IF_IBE_PROCESS_STOPPED_YET_STEP
                                            Continue While
                                        Case SEND_PAUSE_COMMAND_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SEND_PAUSE_COMMAND_STEP")
                                            bHasError = False
                                            If (Not ibeController.PauseProcess()) Then
                                                OnProcessingError("Failed to send PAUSE command", False)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            Else
                                                iStep = SEND_RESUME_COMMAND_STEP
                                                Continue While
                                            End If
                                        Case SEND_RESUME_COMMAND_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.SEND_RESUME_COMMAND_STEP")
                                            bHasError = False
                                            If (Not ibeController.ResumeProcess()) Then
                                                OnProcessingError("Failed to send RESUME command", False)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            End If
                                            ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Resuming
                                        Case CHECK_IF_IBE_PROCESS_STOPPED_YET_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_IBE.CHECK_IF_PROCESS_STOPPED_YET_STEP")
                                            Thread.Sleep(4000)
                                            Dim bAbortedCmdSent As Boolean = False
                                            AVPLib.Log.schedulerLogger.Debug("Waiting for the chamber: " & ibeChamber.Name & " finished")


                                            While ((ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Starting) _
                                            Or (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Running) _
                                            Or (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Aborting) _
                                            Or (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Resuming))

                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " has RunProcessResult of " & ibeChamber.Name & " is " & ibeChamber.RunProcessResult.ToString())

                                                If (HasTerminateRequest() And AbortInProcess) Then
                                                    If (False = bAbortedCmdSent) Then
                                                        AVPLib.Log.schedulerLogger.Debug("Process aborted, stop and exit.")
                                                        bAbortedCmdSent = True
                                                        Dim bResult As Boolean = ibeController.StopRecipe()
                                                        If (Not bResult) Then
                                                            OnProcessingError("Failed to send STOP command for " & ProcessModuleName, False)
                                                            Return bResult
                                                        End If
                                                    Else
                                                        If (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Starting) Then
                                                            ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Aborting
                                                        End If
                                                    End If
                                                End If
                                                If HasSuspendRequest() Then
                                                    AVPLib.Log.schedulerLogger.Debug("User want to pause Processing.")
                                                    Exit While
                                                End If
                                                If HasTerminateRequest() Then
                                                    AVPLib.Log.schedulerLogger.Debug("User want to abort Processing.")
                                                    Return False
                                                End If
                                                ' Sleeps for a while and then polls.
                                                Thread.Sleep(2000)
                                                CheckLicenseAndStopJobsIfNeeded(isPassCheck, isJobStop, startCheck)
                                            End While
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " has RunProcessResult of " & ibeChamber.Name & " is " & ibeChamber.RunProcessResult.ToString())
                                            If (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.CouldNotStart) Then
                                                ' If process stopped due to an error happenned during processing.
                                                AVPLib.Log.schedulerLogger.Debug("Process stopped because it cound't start.")
                                                bHasError = True
                                                iStep = SEND_START_COMMAND_STEP
                                                JobPause()
                                                Continue While
                                            End If
                                            If HasSuspendRequest() Then ' User pause this process job.
                                                AVPLib.Log.schedulerLogger.Debug("User paused this process job - " & JobID)
                                                If (Not ibeController.PauseProcess()) Then
                                                    OnProcessingError("Failed to send PAUSE command", False)
                                                    bHasError = True
                                                    ' JobPause() : not necessary because suspended event already set.
                                                    iStep = SEND_PAUSE_COMMAND_STEP
                                                    Continue While
                                                Else
                                                    iStep = SEND_RESUME_COMMAND_STEP
                                                    Continue While
                                                End If
                                            End If
                                            ' If process stopped due to an error happenned during processing.
                                            If (ibeChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.AlarmHappennedDuringProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("Process stopped due to an error happenned during processing.")
                                                JobPause()
                                                iStep = SEND_RESUME_COMMAND_STEP
                                                Continue While
                                            End If
                                            ' Done with the sub state machine.
                                            Exit While
                                    End Select
                                    If (Not bHasError) Then
                                        iStep += 1
                                    End If
                                End While
                            End If
                            blnIsTaskFished = True
                            blnResult = True

                            If (objChamber.GetWaferInfo() IsNot Nothing) Then
                                'Update MaterialProcessingState by Dat Cao
                                objChamber.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.READY_FOR_TRANSFER
                            End If

                            '-----------Optimize Scheduler---------------
                            If (IsAutoTransfer) Then
                                IsGivenPriority = True
                                AVPLib.Log.schedulerLogger.Info("SET IS_GIVEN_PRIORITY OF THE PJ-" & JobID & " = " & IsGivenPriority.ToString())
                            End If
                            '--------------------------------------------
                        Case START_RECIPE_PROCESSING_STEP_PVD
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_PVD.")
                            blnIsError = False

                            Dim isPassCheck As Boolean = AVPDataLib.Verify() = 0 AndAlso AVPDataLib.IsSecureDllLoaded()
                            Dim isJobStop As Boolean = False
                            Dim startCheck As Long = 0

                            If (IsAutoTransfer) Then
                                Dim PathFrom As String = strRecipePath
                                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(Destination)
                                Dim PathTo As String = serverConfig.RecipeFolder + "\" + AVPLib.Utils.GetFileName(PathFrom, False)
                                Dim pvdController As ChamberController = ControllerManager.GetController(Destination)
                                Dim objPvdChamber As PVDChamber = CType(objChamber, PVDChamber)
                                Dim ProcessModuleName As String = Utils.chamberID2ChamberName(Destination)

                                ' Log Wafer Movement
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, AVPLib.Utils.chamberID2ChamberName(Destination) & " start process with recipe = " & AVPLib.Utils.GetFileName(PathFrom, False))
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Robot, "Start Time = " & DateTime.Now.ToString())

                                Const RELEASE_TRANSPORT_RESOURCE_STEP As Integer = 1
                                Const RESET_PROCESS_ERROR_STEP As Integer = 2
                                Const COPY_PROCESS_FILE_STEP As Integer = 3
                                Const SET_PROCESS_NAME_STEP As Integer = 4
                                Const SEND_START_COMMAND_STEP As Integer = 5
                                Const SEND_PAUSE_COMMAND_STEP As Integer = 6
                                Const SEND_RESUME_COMMAND_STEP As Integer = 7
                                Const CHECK_IF_PROCESS_STOPPED_YET_STEP As Integer = 8
                                Dim innerStep = RELEASE_TRANSPORT_RESOURCE_STEP
                                Dim bHasError = False
                                If (objChamber.GetWaferInfo() IsNot Nothing) Then
                                    objChamber.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.PROCESSING
                                End If
                                While (True)
                                    Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                                    ' Scheduler aborted Or MarkForReturnEquipment.
                                    If (awokenByTerminateRequest) Then
                                        Dim bAbortedCmdSent As Boolean = False
                                        While (enumProcessStatus.eStop <> objPvdChamber.RunProcessStatus)
                                            If (AbortInProcess And (False = bAbortedCmdSent)) Then
                                                Dim bResult As Boolean = pvdController.StopRecipe()
                                                bAbortedCmdSent = True
                                                If (Not bResult) Then
                                                    OnProcessingError("Failed to send STOP command to " & ProcessModuleName, False)
                                                    Return bResult
                                                End If
                                            End If
                                            ' If abort only, we don't need to wait for recipe processing finished.
                                            If (bAbortedCmdSent) AndAlso (False = ReturnWafer) Then
                                                Exit While
                                            End If
                                            ' Sleep and Poll again.
                                            Thread.Sleep(500)
                                        End While
                                        Return False
                                    End If
                                    Select Case innerStep
                                        Case RELEASE_TRANSPORT_RESOURCE_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_PVD.RELEASE_TRANSPORT_RESOURCE_STEP")
                                            bHasError = False
                                            ' Try to release Transport Resource as soon as possible for maximizing performance.
                                            ' of course we just proceed if we're actually holding the lock.
                                            ReleaseTransportResource()
                                        Case RESET_PROCESS_ERROR_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_PVD.RESET_PROCESS_ERROR_STEP")
                                            bHasError = False
                                            pvdController.Process_Reset_Error()
                                        Case COPY_PROCESS_FILE_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_PVD.COPY_PROCESS_FILE_STEP")
                                            bHasError = False
                                            If (Not pvdController.CopyProcessFile(PathFrom, PathTo)) Then
                                                OnProcessingError("Failed to copy file from " & PathFrom & " to " & PathTo & " for " & ProcessModuleName, False)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            End If
                                        Case SET_PROCESS_NAME_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_PVD.SET_PROCESS_NAME_STEP")

                                            ' Send process LotID and WaferID before send recipe name.
                                            pvdController.SendProcessLotID()
                                            pvdController.SendProcessWaferID()

                                            bHasError = False
                                            If (Not pvdController.SetProcessName(PathFrom)) Then
                                                OnProcessingError("Failed to program Recipe Name: " & PathFrom & " for " & ProcessModuleName, False)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            End If
                                            ' Set Run Data File Name also.
                                            Dim strRunDataFileName = GetCurrentChamberNameForRunData(Destination, objChamber.GetWaferInfo().WaferID)
                                            If (Not String.IsNullOrEmpty(strRunDataFileName)) Then
                                                If (Not pvdController.SetDataRunFileName(strRunDataFileName)) Then
                                                    OnProcessingError("Failed to program Run Data File Name = " & strRunDataFileName & " for " & ProcessModuleName, False)
                                                End If
                                            End If
                                        Case SEND_START_COMMAND_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_PVD.SEND_START_COMMAND_STEP")
                                            bHasError = False
                                            objChamber.IsSchedulerRunningInPM = True
                                            If (Not pvdController.StartProcess()) Then
                                                OnProcessingError("Failed to send START command for " & ProcessModuleName, False)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            End If
                                            innerStep = CHECK_IF_PROCESS_STOPPED_YET_STEP
                                            Continue While
                                        Case SEND_PAUSE_COMMAND_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_PVD.SEND_PAUSE_COMMAND_STEP")
                                            bHasError = False
                                            If (Not pvdController.PauseProcess()) Then
                                                OnProcessingError("Failed to send PAUSE command for " & ProcessModuleName, False)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            Else
                                                innerStep = SEND_RESUME_COMMAND_STEP
                                                Continue While
                                            End If
                                        Case SEND_RESUME_COMMAND_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_PVD.SEND_RESUME_COMMAND_STEP")
                                            bHasError = False
                                            If (Not pvdController.ResumeProcess()) Then
                                                OnProcessingError("Failed to send RESUME command for " & ProcessModuleName, False)
                                                bHasError = True
                                                JobPause()
                                                Continue While
                                            End If
                                            objPvdChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Resuming
                                        Case CHECK_IF_PROCESS_STOPPED_YET_STEP
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP_PVD.CHECK_IF_PROCESS_STOPPED_YET_STEP")
                                            Thread.Sleep(4000)
                                            Dim bAbortedCmdSent As Boolean = False
                                            AVPLib.Log.schedulerLogger.Debug("Waiting for the chamber: " & objPvdChamber.Name & " finished")
                                            While ((objPvdChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Starting) _
                                            Or (objPvdChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Running) _
                                            Or (objPvdChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Aborting) _
                                            Or (objPvdChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Resuming))
                                                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " has RunProcessResult of " & objPvdChamber.Name & " is " & objPvdChamber.RunProcessResult.ToString())
                                                If (HasTerminateRequest() And AbortInProcess) Then
                                                    If (False = bAbortedCmdSent) Then
                                                        AVPLib.Log.schedulerLogger.Debug("Process aborted, stop and exit.")
                                                        bAbortedCmdSent = True
                                                        Dim bResult As Boolean = pvdController.StopRecipe()
                                                        If (Not bResult) Then
                                                            OnProcessingError("Failed to send STOP command for " & ProcessModuleName, False)
                                                            Return bResult
                                                        End If
                                                    Else
                                                        If (objPvdChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Starting) Then
                                                            objPvdChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.Aborting
                                                        End If
                                                    End If
                                                End If
                                                If HasSuspendRequest() Then
                                                    AVPLib.Log.schedulerLogger.Debug("User want to pause Processing.")
                                                    Exit While
                                                End If
                                                If HasTerminateRequest() Then
                                                    AVPLib.Log.schedulerLogger.Debug("User want to abort Processing.")
                                                    Return False
                                                End If
                                                ' Sleeps for a while and then polls.
                                                Thread.Sleep(2000)
                                                CheckLicenseAndStopJobsIfNeeded(isPassCheck, isJobStop, startCheck)
                                            End While
                                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " has RunProcessResult of " & objPvdChamber.Name & " is " & objPvdChamber.RunProcessResult.ToString())
                                            If (objPvdChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.CouldNotStart) Then
                                                ' If process stopped due to an error happenned during processing.
                                                AVPLib.Log.schedulerLogger.Debug("Process stopped because it cound't start.")
                                                bHasError = True
                                                innerStep = SEND_START_COMMAND_STEP
                                                JobPause()
                                                Continue While
                                            End If
                                            If HasSuspendRequest() Then ' User pause this process job.
                                                AVPLib.Log.schedulerLogger.Debug("User paused this process job - " & JobID)
                                                If (Not pvdController.PauseProcess()) Then
                                                    OnProcessingError("Failed to send PAUSE command for " & ProcessModuleName, False)
                                                    bHasError = True
                                                    ' JobPause() : not necessary because suspended event already set.
                                                    innerStep = SEND_PAUSE_COMMAND_STEP
                                                    Continue While
                                                Else
                                                    innerStep = SEND_RESUME_COMMAND_STEP
                                                    Continue While
                                                End If
                                            End If
                                            If (objPvdChamber.RunProcessResult = DataManagerment.Chamber.EnumRunProcessResult.AlarmHappennedDuringProcessing) Then
                                                AVPLib.Log.schedulerLogger.Debug("Process stopped due to an error happenned during processing.")
                                                JobPause()
                                                innerStep = SEND_RESUME_COMMAND_STEP
                                                Continue While
                                            End If
                                            ' Done with the sub state machine.
                                            Exit While
                                    End Select
                                    If (Not bHasError) Then
                                        innerStep += 1
                                    End If
                                End While
                            End If
                            blnIsTaskFished = True
                            blnResult = True
                            If (objChamber.GetWaferInfo() IsNot Nothing) Then
                                'Update MaterialProcessingState by Dat Cao
                                objChamber.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.READY_FOR_TRANSFER
                            End If
                            '-----------Optimize Scheduler---------------
                            If (IsAutoTransfer) Then
                                IsGivenPriority = True
                                AVPLib.Log.schedulerLogger.Debug("SET IS_GIVEN_PRIORITY OF THE PJ-" & JobID & " = " & IsGivenPriority.ToString())
                            End If
                            '--------------------------------------------
                    End Select
                    If (Not blnIsError) Then
                        outerStep += 1
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                objChamber.IsSchedulerRunningInPM = False
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PlaceToChamber")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Cao Anh Kiet</Name>
        '''   	<Date>2008-12-16</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Pick wafer from LoadLock
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PlaceToLoadLock(ByVal Source As String, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PlaceToLoadLock")
            Dim blnResult As Boolean = False
            Dim LoadLockName As String = String.Empty
            Try
                AVPLib.Log.coreLogger.Error(JobID + " Start Place from Source:" + Source + "To Destination:" + Destination)

                ' Wafer Movement Log
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
                Dim objTMController As Business.TMController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), Business.TMController)

                Dim Slot As String = String.Empty
                GetLoadLockNameAndSlot(Destination, LoadLockName, Slot)

                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False

                Const CHECK_PRESSURE_STEP As Integer = 1
                Const CHECK_WAFER_PRESENT_STEP As Integer = 2
                Const GO_TO_SLOT_STEP As Integer = 3
                Const OPEN_SPLITVALVE_STEP As Integer = 4
                Const PLACE_WAFER_STEP As Integer = 5
                Const CLOSE_SPLITVALVE_STEP As Integer = 6

                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                    Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                    If (awokenByTerminateRequest OrElse IsCancelMove) Then
                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                        Return False
                    End If

                    If (Not AVPParentControlJob.IsCycleInATMMode AndAlso objTMController IsNot Nothing AndAlso
                        Not objTMController.IsStationOnline(LoadLockName)) Then
                        If (m_blnIsAutoTransfer And Not ReturnWafer) Then
                            Const Fine_Tune_Sleep_Time As Integer = 200
                            If SleepButAlertabletoTerminateRequest(Fine_Tune_Sleep_Time) Then
                                ' User is aborting this Process Job.
                                Return False
                            End If

                            Continue While
                        Else
                            'do nothing, continue step
                        End If
                    End If

                    Select Case intStep
                        Case CHECK_PRESSURE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_PRESSURE_STEP.")
                            blnIsError = False
                            Dim strPressureError As String = String.Empty
                            Dim bCheckSetPointTransferPresssure = m_blnIsAutoTransfer
                            Dim check As Boolean = objTMController.CheckCG10DifferenceFromStation(LoadLockName, bCheckSetPointTransferPresssure, AVPParentControlJob.IsCycleInATMMode, strPressureError)
                            AVPLib.Log.schedulerLogger.Debug("check pressure result:" + check.ToString())
                            If (Not check) Then
                                If String.IsNullOrEmpty(strPressureError) = False Then
                                    OnProcessingError(strPressureError, True)
                                End If
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Pressure OK")

                        Case CHECK_WAFER_PRESENT_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_WAFER_PRESENT_STEP.")
                            blnIsError = False
                            ' Check wafer inside chamber status
                            Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(LoadLockName)
                            Dim nSlot As Integer = -1
                            If (Integer.TryParse(Slot, nSlot)) Then
                                ' Check if there is a wafer at the slot Nth
                                If (objLoadLock.Elevator.ListOfWaferInfo(nSlot - 1) IsNot Nothing) Then
                                    If objLoadLock.Elevator.ListOfWaferInfo(nSlot - 1).WaferStatus <> enumWaferStatus.eWaferNone Then
                                        OnProcessingError(LoadLockName & " has a wafer at the slot " & Slot, True)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                            Return False
                                        End If
                                        blnIsError = True
                                        intStep = CHECK_PRESSURE_STEP 'start place process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                            End If

                            AddActionLog("Check wafer inside chamber status OK")

                            If RobotConfigurationValues.ALINER_VISIBLE Then

                                ''check Aligner wafer present
                                Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                                If objAligner.GetWaferInfo() IsNot Nothing Then
                                    AVPLib.Log.schedulerLogger.Debug("Has wafer at aligner")
                                    ''Aligner has wafer on the left and place to LLA
                                    If (AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = 1 AndAlso
                                                                   objLoadLock.Name = ConstEnum.Equipments.LoadLockA.ToString()) Then
                                        AVPLib.Log.schedulerLogger.Debug("Aligner on the left and place to LLA")
                                        OnProcessingError("Aligner has a wafer, can not place wafer to " & LoadLockName & " : " & Slot, True)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                            Return False
                                        End If
                                        blnIsError = True
                                        intStep = CHECK_PRESSURE_STEP 'start place process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                            End If

                            AddActionLog("Check Aligner wafer present OK")

                        Case GO_TO_SLOT_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": GO_TO_SLOT_STEP.")
                            blnIsError = False
                            Dim check As Boolean = False

                            'Transfer from LLX to locationX with LLX isolation is already open.   
                            'Need to check for robot communication and retracted before moving to SlotX.   
                            'This condition also apply during scheduler run.  
                            If (objRobot IsNot Nothing) Then
                                If Not (objRobot.IsCommunicating) Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: Robot Communication is off", True)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                        Return False
                                    End If
                                    intStep = CHECK_PRESSURE_STEP 'start place process again
                                    JobPause()
                                    Continue While
                                End If

                                If Not (objRobot.IsRetracted AndAlso objRobot.IsReallyRetracted) Then
                                    blnIsError = True
                                    blnResult = False
                                    OnProcessingError("Move wafer home: Robot is not retracted.", True)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                        Return False
                                    End If
                                    intStep = CHECK_PRESSURE_STEP 'start place process again
                                    JobPause()
                                    Continue While
                                End If
                            End If

                            AddActionLog("Check Robot comm and retracted OK")

                            Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(LoadLockName), LoadLockController)
                            Dim ctrElevator As LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)
                            Dim objElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())

                            If ctrElevator IsNot Nothing Then
                                ' IF loadlock = busy wait for loadlock ready
                                If (objElevator IsNot Nothing) AndAlso objElevator.OperationStatus = Equipment.OperationStatuses.BUSY Then
                                    check = ctrElevator.WaitForLoadLockReadyContionTimeOut(ConstEnum.Equipments.LLAElevator.ToString())

                                    If (Not check) Then
                                        OnProcessingError("Failed To Wait For " + LoadLockName + " Ready", True)
                                        If Not m_blnIsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                            Return False
                                        End If
                                        blnIsError = True
                                        intStep = CHECK_PRESSURE_STEP 'start pick process again
                                        AVPLib.Log.coreLogger.Error(JobID + " Robot is not retracted.")
                                        JobPause()
                                        Continue While
                                    End If
                                End If

                                ' go to slot and wait for current slot = slotID
                                check = ctrElevator.WaitReadyAndGotoSlot(Slot)
                                If (Not check) Then
                                    OnProcessingError("GotoSlot " + LoadLockName + " " + Slot, True)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    AVPLib.Log.coreLogger.Error(JobID + " Robot is not retracted.")
                                    JobPause()
                                    Continue While
                                End If
                            End If
                            AddActionLog("Check GOTO slot OK")

                        Case OPEN_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": OPEN_SPLITVALVE_STEP.")
                            blnIsError = False

                            'Step close Rough valve when loadlock rough only is installed
                            Dim check As String = String.Empty
                            If Not (CloseLoadlockRoughValve(LoadLockName, check)) Then
                                If (check <> String.Empty) Then
                                    OnProcessingError("Close " + LoadLockName + " Rough Valve", True)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PickFromLoadLock")
                                        Return False
                                    End If
                                    blnIsError = True
                                    intStep = CHECK_PRESSURE_STEP 'start pick process again
                                    JobPause()
                                    Continue While
                                End If
                            End If

                            AddActionLog("Close LL Rough valve OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                               AVPLib.ContainerData.LogSource.AVPMainScreen, "Open " & LoadLockName & " isovalve")

                            check = ChamberUtility.OpenCloseSlitValve(LoadLockName, True)
                            AVPLib.Log.schedulerLogger.Debug("open slit valve result:" + check.ToString())
                            If (check <> String.Empty) Then
                                blnIsError = True
                                OnProcessingError("Open " + LoadLockName + " SlitValve: " & check, True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                    Return False
                                End If
                                intStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            Else
                                Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                If Not WaitOnCondition(AddressOf Utils.IsLLSlitValveOpen, LoadLockName, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                    If (RobotConfigurationValues.DEBUGMODE = False) Then
                                        ChamberUtility.UnknownSlitValve(LoadLockName)
                                        blnIsError = True
                                        OnProcessingError("Failed to wait for " + LoadLockName + " SlitValve to open after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                        If Not IsAutoTransfer Then
                                            AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                            Return False
                                        End If
                                        intStep = CHECK_PRESSURE_STEP 'start place process again
                                        JobPause()
                                        Continue While
                                    End If
                                End If
                            End If

                            AddActionLog("OPEN slit valve OK")

                        Case PLACE_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PLACE_WAFER_STEP.")
                            ''previous pos#: retract with wafer
                            ''current pos#: extract with wafer
                            '''''''''''''''''is place success? No ->retract with wafer
                            ''next_pos#: Yes: extract without wafer
                            '''''''''''''''''check sensor on/off-->Off: retract with wafer
                            '''next_next_pos#: On: retract without wafer

                            If (objRobot IsNot Nothing) AndAlso (objRobot.GetWaferInfo() IsNot Nothing) Then
                                LogPlaceWaferMovement(objRobot.GetWaferInfo().WaferID, Destination)
                                AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info,
                                "Start Place Wafer: " & objRobot.GetWaferInfo().WaferID & " To: " & Utils.chamberID2ChamberName(Destination), m_blnIsAutoTransfer)
                            End If

                            blnIsError = False
                            Dim check As Boolean = False
                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.PlaceWaferToStation(LoadLockName, IsAutoTransfer, IsReturnWafer) 'LLA
                            check = IIf(strErr = String.Empty, True, False)
                            m_ErrorWhenPlaceToStation = Not check
                            AVPLib.Log.schedulerLogger.Debug("place wafer result:" + check.ToString())
                            If Not check Then
                                OnProcessingError("Place Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " To " & LoadLockName & ". " & strErr, True,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                    Return False
                                End If
                                blnIsError = True
                                'If user resume, should restart at Place step.
                                'intStep = PLACE_WAFER_STEP
                                intStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Place wafer OK")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                 AVPLib.ContainerData.LogSource.AVPMainScreen, "Place Completed")

                            ' CHECK_SENSOR_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CHECK_SENSOR_STEP.")
                            blnIsError = False

                            Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(LoadLockName)
                            ' Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                            Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                            'Update wafer status
                            'Dat Cao fix: when come back loaklock -> complete or error
                            If m_blnIsAutoTransfer = True And
                            m_sifSequenceInfor.WaferInfo.WaferStatus <> ConstEnum.enumWaferStatus.eWaferComplete _
                            And m_sifSequenceInfor.WaferInfo.WaferStatus <> ConstEnum.enumWaferStatus.eWaferError Then
                                m_sifSequenceInfor.WaferInfo.WaferStatus = ConstEnum.enumWaferStatus.eWaferComplete
                            End If
                            Dim strCustomWaferId As String = Utils.GetGEMWaferID(objRobot.GetWaferInfo().WaferID)
                            AVPSecsGemLib.UpdateSECSGEM_Variable(LoadLockName, EMSERVICELib.VarType.SV, "LastWaferIn", VALUELib.ValueType.A, strCustomWaferId)

                            ControllerManager.SetWaferInsideSrc_Dst(Equipments.Robot.ToString(), Destination, objRobot.GetWaferInfo())

                            'keep wafer info and roll back to robot when place wafer fail
                            Dim objAVPWaferInfo As AVPWaferInfo = objRobot.GetWaferInfo()

                            'set wafer info of robot = nothing
                            objRobot.SetWaferInfo()
                            AVPSecsGemLib.TriggerEvent(LoadLockName, "WaferIn")
                            'When place a wafer back to Llx, before closing Llx iso valve, 
                            'issue a command �A,GC,xx� then �R,WP�.  If request for wafer is OK then continue on or alarm 
                            '(�Wafer not found in LLx�) if WP is not OK.


                            Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(LoadLockName), LoadLockController)
                            Dim ctrElevator As LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)
                            Dim blnElevator_GoCheck_Error As Boolean = False
                            check = ctrElevator.CheckWaferPresent(Slot, blnElevator_GoCheck_Error)

                            AVPLib.Log.schedulerLogger.Debug("goto slot result:" + check.ToString())
                            If (Not check) Then
                                'need to roll back Wafer in Robot???
                                If Not blnElevator_GoCheck_Error Then
                                    'roll back wafer to robot
                                    objRobot.SetWaferInfo(objAVPWaferInfo)
                                    ControllerManager.SetWaferInsideSrc_Dst(Destination, Equipments.Robot.ToString(), objAVPWaferInfo)
                                    'throw alarm 
                                    OnProcessingError("Wafer not found in " + LoadLockName + " Slot " + Slot, False)
                                Else
                                    OnProcessingError("Error in LoadLock " + LoadLockName + " Slot " + Slot, False)
                                End If
                                blnIsError = True
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                    Return False
                                End If
                                intStep = CHECK_PRESSURE_STEP 'start place process again
                                JobPause()
                                Continue While
                            Else
                                If (objAVPWaferInfo IsNot Nothing) Then
                                    objAVPWaferInfo.WaferProcessingStatus = WaferProcessingState.IN_CASSETTE_MODULE
                                End If
                            End If
                            AddActionLog("Check sensor OK")

                        Case CLOSE_SPLITVALVE_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": CLOSE_SPLITVALVE_STEP.")
                            blnIsError = False
                            Dim checkRobotRetract As Boolean = RobotUtility.IsRobotRetract()
                            If checkRobotRetract = False And RobotConfigurationValues.DEBUGMODE = False Then
                                OnProcessingError("Robot Hand is not retracted when open SlitValve", False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PickFromChamber")
                                    Return False
                                End If
                                blnIsError = True
                                'intStep = CHECK_PRESSURE_STEP 'start place process again, do not do this in this step
                                JobPause()
                                Continue While
                            End If

                            AddActionLog("Check Robot Comm and Retracted OK")

                            '0001010: [Khoi Ha - 06/20/2012] - LLx rough only configuration. During a schedule run after picking or placing a wafer from/to LLx, C
                            Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(LoadLockName)
                            If (objLoadLock IsNot Nothing AndAlso Not objLoadLock.IsRoughOnlyMode) Then
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                   AVPLib.ContainerData.LogSource.AVPMainScreen, "Close " & LoadLockName & " isovalve")

                                Dim check As String = ChamberUtility.OpenCloseSlitValve(LoadLockName, False)
                                AVPLib.Log.schedulerLogger.Debug("close slit valve result:" + check)
                                If (check <> String.Empty) Then
                                    OnProcessingError("Close " + LoadLockName + " SlitValve", True)
                                    If Not m_blnIsAutoTransfer Then
                                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                        Return False
                                    End If
                                    blnIsError = True
                                    'intStep = CHECK_PRESSURE_STEP 'start place process again, do not do this in this step
                                    JobPause()
                                    Continue While
                                Else
                                    If Not WaitOnCondition(AddressOf Utils.IsLLSlitValveClose, LoadLockName, OpenCloseSplitValveTimeOutInMilliSeconds, False) Then
                                        If (RobotConfigurationValues.DEBUGMODE = False) Then
                                            ChamberUtility.UnknownSlitValve(LoadLockName)
                                            blnIsError = True
                                            OnProcessingError("Failed to wait for " + LoadLockName + " SlitValve to close after " & (OpenCloseSplitValveTimeOutInMilliSeconds / 1000).ToString & " seconds", False)
                                            If Not IsAutoTransfer Then
                                                AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
                                                Return False
                                            End If
                                            'intStep = CHECK_PRESSURE_STEP 'start place process again, do not do this in this step
                                            JobPause()
                                            Continue While
                                        End If
                                    End If
                                    Thread.Sleep(OpenCloseSlitValveWaitTimeInMilliSeconds)
                                End If

                                ' Finally we get there.
                                blnIsTaskFished = True
                                blnResult = True
                            Else
                                ' Finally we get there.
                                blnIsTaskFished = True
                                blnResult = True
                            End If
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While

                AddActionLog("Place To " + Destination + " OK")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            Finally
                If blnResult AndAlso AVPParentControlJob.JobManager.CJBatchProcessing Then
                    Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(LoadLockName), LoadLockController)
                    If ctrLoadLock IsNot Nothing Then
                        Dim ctrElevator As LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)
                        If ctrElevator IsNot Nothing Then
                            ctrElevator.GotoNextSlot()
                        End If
                    End If
                End If
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PlaceToLoadLock")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Cao Anh Kiet</Name>
        '''   	<Date>2008-12-16</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Place wafer from Aligner
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PlaceToAlginer(ByVal Source As String,
                                        ByVal Destination As String,
                                        ByVal strRecipePath As String) As Boolean

            AVPLib.Log.schedulerLogger.Info("Enter PlaceToAlginer")
            Dim blnResult As Boolean = False
            Try
                If IsSelfAligner AndAlso IsCheckedECCLimitForSelfAligner AndAlso
                  (IsPlaceAlignerForSelfAligner OrElse SelfAlignerPMName <> Equipments.Aligner.ToString()) Then
                    Return True
                End If

                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                Dim blnIsError = False

                AVPLib.Log.coreLogger.Error(JobID + " Start Place from Source:" + Source + "To Destination:" + Destination)

                Const PLACE_WAFER_STEP As Integer = 1
                Const START_RECIPE_PROCESSING_STEP As Integer = 2

                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())

                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                    Dim awokenByTerminateRequest = SuspendIfNeeded()
                    If (awokenByTerminateRequest OrElse IsCancelMove) Then
                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToAlginer")
                        'ReleaseTransportResource()
                        Return False
                    End If
                    Select Case intStep
                        Case PLACE_WAFER_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": PLACE_WAFER_STEP.")
                            blnIsError = False
                            'Check if there is another wafer existed.
                            Dim eqpAligner As Aligner = EquipmentManager.GetEquipment(Destination)
                            If eqpAligner.GetWaferInfo() IsNot Nothing Then
                                OnProcessingError("Had wafer at " + Destination, False)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToAlginer")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            End If

                            ' Wafer Movement Log 
                            If (objRobot IsNot Nothing) AndAlso (objRobot.GetWaferInfo() IsNot Nothing) Then
                                LogPlaceWaferMovement(objRobot.GetWaferInfo().WaferID, Destination)
                                AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info,
                                "Start Place Wafer: " & objRobot.GetWaferInfo().WaferID & " To: " & objAligner.Name, m_blnIsAutoTransfer)
                            End If

                            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                            Dim strErr As String = ctrRobot.PlaceWaferToStation(Destination, IsAutoTransfer, IsReturnWafer)
                            Dim check As Boolean = IIf(strErr = String.Empty, True, False)
                            m_ErrorWhenPlaceToStation = Not check
                            If (Not check) Then
                                OnProcessingError("Place Wafer " & m_sifSequenceInfor.WaferInfo.WaferID & " To " & Utils.chamberID2ChamberName(Destination) & ". " & strErr, True,
                                    Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString, ConstEnum.GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED))
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToAlginer")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            Else
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                                     AVPLib.ContainerData.LogSource.AVPMainScreen, "Place Completed")

                                blnIsError = False
                                Dim LoadLockData As DataManagerment.LoadLock = CType(EquipmentManager.GetEquipment(LoadLockA_STR), DataManagerment.LoadLock)
                                Dim TransferModuleObj As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
                                objAligner.SetWaferInfo(objRobot.GetWaferInfo())
                                objRobot.SetWaferInfo()
                                ' There is No Wafer Image At Source.
                                ControllerManager.SetWaferInsideSrc_Dst(Equipments.Robot.ToString(),
                                                                        Equipments.Aligner.ToString(),
                                                                        objAligner.GetWaferInfo())

                                'Update MaterialProcessingState by Dat Cao
                                If (objAligner.GetWaferInfo() IsNot Nothing) Then
                                    objAligner.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.NOT_ALIGNED
                                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner,
                                                          "Wafer In")
                                End If
                            End If

                            AddActionLog("Check Pressure OK")
                        Case START_RECIPE_PROCESSING_STEP
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & ": START_RECIPE_PROCESSING_STEP.")
                            blnIsError = False
                            'We execute Aligner Recipe instead of Aligning.
                            Dim objAlignerController As AlignerController = ControllerManager.GetController(ConstEnum.Equipments.Aligner.ToString())
                            Dim recipePath As String = strRecipePath

                            'Update MaterialProcessingState by Dat Cao
                            If (objAligner.GetWaferInfo() IsNot Nothing) Then
                                objAligner.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.ALIGNING
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner,
                                                          "Wafer Aligning")
                            End If

                            Dim check As Boolean = objAlignerController.RunRecipe(recipePath)
                            If (Not check) Then
                                OnProcessingError("Error executing Recipe at " + Utils.chamberID2ChamberName(Destination), True)
                                If Not m_blnIsAutoTransfer Then
                                    AVPLib.Log.schedulerLogger.Info("Leave PlaceToAlginer")
                                    Return False
                                End If
                                blnIsError = True
                                JobPause()
                                Continue While
                            Else
                                'Update MaterialProcessingState by Dat Cao
                                If (objAligner.GetWaferInfo() IsNot Nothing) Then
                                    objAligner.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.ALIGNED
                                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner,
                                                          "Wafer Aligned")
                                End If
                                blnIsTaskFished = True
                                blnResult = True
                                If IsSelfAligner AndAlso IsCheckedECCLimitForSelfAligner Then
                                    IsPlaceAlignerForSelfAligner = True
                                End If
                            End If

                            AddActionLog("Check Run Recipe OK")
                    End Select
                    If (Not blnIsError) Then
                        intStep += 1
                    End If
                End While
                AddActionLog("Place To " + Destination + " OK")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PlaceToAlginer")
            Return blnResult
        End Function
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-10</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Cao Anh Kiet</Name>
        '''   	<Date>2008-12-16</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Place wafer from Robot Arm
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <remarks></remarks>
        Private Function PlaceToRobotArm(ByVal Source As String, ByVal Destination As String) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter PlaceToRobotArm")
            Dim blnResult As Boolean = False
            Try
                Dim blnIsTaskFished As Boolean = False
                Dim intStep = 1
                AVPLib.Log.schedulerLogger.Debug("Source:" + Source)
                AVPLib.Log.schedulerLogger.Debug("Destination:" + Destination)

                ' Wafer Movement Log
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                If (objRobot IsNot Nothing) AndAlso (objRobot.GetWaferInfo() IsNot Nothing) Then
                    LogPlaceWaferMovement(objRobot.GetWaferInfo().WaferID, Destination)
                    objRobot.GetWaferInfo().WaferProcessingStatus = WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                End If

                While ((Not blnIsTaskFished) And (False = HasTerminateRequest()))
                    Dim awokenByTerminateRequest As Boolean = SuspendIfNeeded()
                    If (awokenByTerminateRequest OrElse IsCancelMove) Then
                        AVPLib.Log.schedulerLogger.Info("Leave PlaceToRobotArm")
                        Return False
                    End If
                    Select Case intStep
                        Case 1
                            ' We don't need to do anything.
                            blnIsTaskFished = True
                            blnResult = True
                    End Select
                End While

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage,
                    AVPLib.ContainerData.LogSource.AVPMainScreen, "Place Completed")

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave PlaceToRobotArm")
            Return blnResult
        End Function

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-01-14</date>
        ''' </author>
        ''' <summary>
        ''' Raise To Wafer
        ''' </summary>
        ''' <param name="ChamberName"></param>
        ''' <param name="SlotID"></param>
        ''' <remarks></remarks>
        Private Sub RaiseToWafer(ByVal ChamberName As String, ByVal SlotID As Int32)
            AVPLib.Log.schedulerLogger.Info("Enter RaiseToWafer")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                ReplyValues.Add(SlotID)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("WaferID")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ChamberName, PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave RaiseToWafer")
        End Sub

        ' =========================
        ' License Guard – random check + stop all jobs if license/DLL is invalid
        ' =========================
        Private Function CheckLicenseAndStopJobsIfNeeded(ByRef isPassCheck As Boolean,
                                                 ByRef isJobStop As Boolean,
                                                 ByRef startCheck As Long) As Boolean

            ' Initialize the starting timestamp on first use
            If startCheck = 0 Then
                startCheck = Environment.TickCount
            End If

            ' If license is invalid + job not yet stopped + exceeded random delay
            If Not isPassCheck AndAlso Not isJobStop AndAlso Utils.GetTickCountDelta(startCheck) > m_randomTime Then
                If StopAllControlJob() Then
                    isJobStop = True
                    ' "Stop Scheduler Due to Unexpected Error"
                    OnProcessingError(AVPDataLib.Base64Decode("U3RvcCBTY2hlZHVsZXIgRHVlIHRvIFVuZXhwZWN0ZWQgRXJyb3I="), False)
                    Return True   ' job has been stopped
                End If
            End If

            Return False          ' job is still running
        End Function

#End Region

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-5-05 </date>
        ''' </author>
        ''' <summary>
        ''' The thread proc for wafer processor.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnDoWork()
            AVPLib.Log.schedulerLogger.Info("Enter OnDoWork")
            AVPLib.Log.schedulerLogger.Debug("A NEW THREAD FOR PJ-" & JobID & " OF CJ-" & AVPParentControlJob.JobID & "-" & CurrentState & " IS COMING ALIVE AND PROCESSING SEQUENCE - ")
            AVPLib.Log.schedulerLogger.Debug(Utils.ArrayToString(m_listConvertedRoute))
            If (m_blnIsAutoTransfer) Then
                MoveAutoTransferProc()
            Else
                MoveSemiAutoTransferProc()
            End If
            AVPLib.Log.schedulerLogger.Debug("THE THREAD FOR PJ-" & JobID & " OF CJ-" & AVPParentControlJob.JobID & " IS EXITING.")
            AVPLib.Log.schedulerLogger.Info("Leave OnDoWork")
        End Sub

        Public Function JobPause() As Boolean
            Try
                AVPLib.Log.schedulerLogger.Info("Enter JobPause")
                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & "-" & CurrentState & " IS BEING PAUSED.")
                ChangeState(ConstEnum.PJSTATE_MACHINES.Pausing.ToString())

                Dim strEquipmentName As String = m_listConvertedRoute(m_idxCurrentStationForPickingInRoute).ToString()

                'change OperationStatus => ERROR
                'Roll back to previous status and continue to run
                If (strEquipmentName.Contains(ConstEnum.Chamber)) Then
                    Dim objChamber As Chamber = DataManagerment.EquipmentManager.GetEquipment(strEquipmentName)
                    If (objChamber IsNot Nothing AndAlso objChamber.OperationStatus <> Equipment.OperationStatuses.ERROR) Then
                        objChamber.PreviousOperationStatus = objChamber.OperationStatus
                        objChamber.OperationStatus = DataManagerment.Equipment.OperationStatuses.ERROR
                    End If
                End If

                ''Update Gem Obj
                Dim Processing_PAUSE As Integer = 5
                If (strEquipmentName <> String.Empty AndAlso strEquipmentName.Contains("LoadLockA")) Then
                    AVPSecsGemLib.MySecsGemObj.UpdateProcessState(Processing_PAUSE, ConstEnum.LoadLockA_STR)
                End If

                ' Pausing processing thread.
                MyBase.Suspend()
                If (Not IsJobPauseInRobot() AndAlso Not IsJobPauseAtAligner()) Then
                    ReleaseTransportResource()
                End If

                AVPLib.Log.schedulerLogger.Info("Leave JobPause")
                Return ChangeState(ConstEnum.PJSTATE_MACHINES.Paused.ToString())

                'Dat Cao
                AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info, JobID & " IS BEING PAUSED.", m_blnIsAutoTransfer)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Function

        Public Function JobResume() As Boolean
            AVPLib.Log.schedulerLogger.Info("Leave JobResume")
            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & "-" & CurrentState() & " IS BEING RESUMED.")

            'change OperationStatus => ERROR
            'Roll back to previous status and continue to run
            Dim strEquipmentName As String = m_listConvertedRoute(m_idxCurrentStationForPickingInRoute).ToString()
            If (strEquipmentName.Contains(ConstEnum.Chamber)) Then
                Dim objChamber As Chamber = DataManagerment.EquipmentManager.GetEquipment(strEquipmentName)
                If (objChamber IsNot Nothing) Then
                    objChamber.OperationStatus = objChamber.PreviousOperationStatus
                End If
            End If

            If m_blnJobPausedBy_PMOffline_CloseSplitValve Then
                m_blnJobPausedBy_PMOffline_CloseSplitValve = False
            End If
            ' Resuming processing thread.
            MyBase.Resume()
            Return ChangeState(ConstEnum.PJSTATE_MACHINES.Processing.ToString())
            'Dat Cao
            AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info, JobID & " IS BEING RESUMED.", m_blnIsAutoTransfer)

            'If (AcquirePauseResource()) Then
            '    MyBase.Resume()
            '    Return ChangeState(ConstEnum.PJSTATE_MACHINES.Processing.ToString())
            '    'Dat Cao
            '    AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info, JobID & " IS BEING RESUMED.", m_blnIsAutoTransfer)
            'End If
            AVPLib.Log.schedulerLogger.Info("Leave JobResume")
        End Function

        Public Function JobStart() As Boolean
            Start()
            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " OF CJ-" & AVPParentControlJob.JobID & " IS STARTED.")
            'Dat Cao
            AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info, JobID & " IS STARTED.", m_blnIsAutoTransfer)

            ChangeState(ConstEnum.PJSTATE_MACHINES.Processing.ToString())

            'cycle until mode -> when pick one wafer, increase pick wafer count when start a job
            If (Me.AVPParentControlJob.IsContinuousJob AndAlso Me.AVPParentControlJob.IsRunCylceUntilMode) Then
                Me.AVPParentControlJob.CompletedCycleWafer()
            End If
            Return True
        End Function

        Public Function IsRunning() As Boolean
            Select Case CurrentState
                'Case ConstEnum.PJSTATE_MACHINES.SettingUp.ToString(), _
                Case ConstEnum.PJSTATE_MACHINES.WaitingForStart.ToString(),
                         ConstEnum.PJSTATE_MACHINES.Pausing.ToString(),
                         ConstEnum.PJSTATE_MACHINES.Aborting.ToString(),
                         ConstEnum.PJSTATE_MACHINES.Processing.ToString()
                    Return True
            End Select
            Return False
        End Function

        Public Function JobStop() As Boolean
            If StopInProcess Then
                AVPLib.Log.schedulerLogger.Debug("Stop in process, please wait.")
                Return False
            End If
            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " - " & CurrentState & " IS BEING STOPPED.")
            ChangeState(ConstEnum.PJSTATE_MACHINES.Stopping.ToString())
            'Dat Cao
            AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info, JobID & " IS BEING STOPPED.", m_blnIsAutoTransfer)
            StopInProcess = True
            Return True
        End Function

        Public Function JobAbort(Optional ByVal blReturnWafer As Boolean = False) As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter Abort")
            If IsJobOver() Then
                AVPLib.Log.schedulerLogger.Debug(JobID & " couldn't be aborted, it's already over.")
                Return False
            End If
            If Not AbortInProcess Then
                Dim proJob As AVPProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(m_sifSequenceInfor.WaferInfo.WaferID)
                If (proJob IsNot Nothing) AndAlso (proJob.IsPaused) AndAlso (m_sifSequenceInfor.WaferInfo.WaferStatus = enumWaferStatus.eWaferExposed) Then
                    m_sifSequenceInfor.WaferInfo.WaferStatus = enumWaferStatus.eWaferError
                End If

                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " - " & CurrentState & " IS BEING ABORTED, RETURN_WAFER=" & blReturnWafer.ToString())
                AbortInProcess = True
                If (IsSettingUp()) Then
                    Return OnAbortJob()
                End If
                ChangeState(ConstEnum.PJSTATE_MACHINES.Aborting.ToString())
                ReturnWafer = blReturnWafer
                MyBase.Terminate()

                'update wafer status
                If (m_sifSequenceInfor.WaferInfo.WaferStatus = enumWaferStatus.eWaferExposed) Then
                    'm_sifSequenceInfor.WaferInfo.WaferStatus = enumWaferStatus.eWaferError
                End If

                'Dat Cao
                AVPLotDatalog.AddLotDatalog(AVPParentControlJob.LoadlockName, LogType.Info, JobID & " IS BEING ABORTED", m_blnIsAutoTransfer)
            Else
                ' Abort Of `Abort and Return Wafers` Case.
                AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " - " & CurrentState & " IS BEING ABORTED ( ABORT OF ABORT AND RETURN WAFER ).")
                ReturnWafer = False
            End If
            AVPLib.Log.schedulerLogger.Info("Leave Abort")
            Return True
        End Function

        Function MakeWaitingForStart() As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter SetupJob")
            ChangeState(ConstEnum.PJSTATE_MACHINES.WaitingForStart.ToString())
            If Not JobStart() Then
                AVPLib.Log.schedulerLogger.Debug("Failed to start job " & m_strJobID)
                Return False
            End If
            Return True
        End Function

        Public Function IsPaused() As Boolean
            Return (CurrentState = ConstEnum.PJSTATE_MACHINES.Paused.ToString())
        End Function

        Public Function IsQueued() As Boolean
            Return (CurrentState = ConstEnum.PJSTATE_MACHINES.Pooled.ToString())
        End Function

        Public Function IsSettingUp() As Boolean
            Return (CurrentState = ConstEnum.PJSTATE_MACHINES.SettingUp.ToString())
        End Function

        Public Function IsJobOver() As Boolean
            Select Case CurrentState
                Case ConstEnum.PJSTATE_MACHINES.ProcessComplete.ToString(),
                    ConstEnum.PJSTATE_MACHINES.NoState.ToString()
                    Return True
            End Select
            Return False
        End Function

        Public Function GetResourcesForAllSteps(Optional ByVal bAlarmIfHasError As Boolean = False) As Boolean
            AVPLib.Log.schedulerLogger.Info("Leave GetResourcesForAllSteps")
            Dim iCurrentStep As Integer = -1
            Dim blRes As Boolean = True
            Try

                For i As Integer = 1 To m_lstSeqStep.Count
                    If GetResourcesForStep(i, bAlarmIfHasError) = False Then
                        iCurrentStep = i
                        blRes = False
                        Exit For
                    End If
                Next

                'Roll back equipments status
                If (blRes = False) Then
                    For i As Integer = 1 To iCurrentStep
                        ReleaseResourcesForStep(i)
                    Next
                End If

            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try

            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " GetResourcesForAllSteps() = " & blRes.ToString())
            AVPLib.Log.schedulerLogger.Info("Leave GetResourcesForAllSteps")
            Return blRes
        End Function

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-09</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get resource for a step.
        ''' </summary>
        ''' <param name="SeqInfor"></param>
        ''' <remarks></remarks>
        Public Function GetResourcesForStep(ByVal stepNumber As Integer, Optional ByVal bAlarmIfHasError As Boolean = False) As Boolean
            If (m_lstSeqStep Is Nothing) Then
                AVPLib.Log.schedulerLogger.Error("PJ-" & JobID & " m_lstSeqStep is null.")
                Return False
            End If

            Dim bResult As Boolean = True

            Try
                If (stepNumber <= 0) Or (stepNumber > m_lstSeqStep.Count) Then
                    bResult = False
                Else
                    Dim sqSteps As List(Of DBSeqStep) = m_lstSeqStep.Item(stepNumber - 1)
                    Dim stp As DBSeqStep = Nothing
                    Dim bIsFirstStep As Boolean = IIf(stepNumber = 1, True, False)
                    Dim bIsFirstStation As Boolean = True
                    For Each stp In sqSteps
                        Dim bCheck As Boolean = False
                        Dim strEquipmentName As String = stp.StationName
                        AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " is acquiring the station " & strEquipmentName)
                        If m_blnIsAutoTransfer Then
                            Dim bErrorIfWaferPresent As Boolean = True
                            If (bIsFirstStep And bIsFirstStation) Then
                                bErrorIfWaferPresent = False
                                bIsFirstStation = False
                            End If

                            bCheck = AcquireChamberResource(strEquipmentName, GetSlotID(strEquipmentName), True, bErrorIfWaferPresent, bAlarmIfHasError)
                        Else
                            bCheck = AcquireChamberResource(strEquipmentName, GetSlotID(strEquipmentName), False, False, bAlarmIfHasError)
                        End If
                        If Not bCheck Then
                            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " has failed to acquire the station " & strEquipmentName)
                            bResult = False
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try

            AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " GetResourcesForStep(stepNumber=" & stepNumber.ToString() & ") = " & bResult.ToString())
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' IBE Free resource
        ''' used for ANYIBE MODE
        '''Free = Existed + (WaferInfo = Nothing) + (Type = IBE)
        ''' </summary>
        ''' <remarks></remarks>
        Function isFreeIBEChamber(ByVal ChamberName As String) As Boolean
            Dim blResult As Boolean = False
            Try
                Dim objChamber As Chamber = EquipmentManager.GetEquipment(ChamberName)
                If (objChamber IsNot Nothing AndAlso
                objChamber.ConnectionStatus = Equipment.WorkingStatuses.On AndAlso
                objChamber.ControlStatus = Equipment.ControlStatuses.ONLINE AndAlso
                objChamber.GetWaferInfo() Is Nothing AndAlso
                objChamber.OperationStatus = Equipment.OperationStatuses.READY) Then
                    Dim objIBE As DataManagerment.Chamber = CType(objChamber, DataManagerment.Chamber)
                    If (objIBE.EquipmentType = SystemModule.ModuleType.IBE) Then
                        blResult = True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' IBE Free resource
        ''' used for ANYIBE MODE
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetListFreeIBEChamber() As ArrayList
            Dim arrResult As ArrayList = New ArrayList
            Try
                If (isFreeIBEChamber(ConstEnum.Equipments.Chamber1.ToString)) Then
                    arrResult.Add(ConstEnum.Equipments.Chamber1.ToString)
                End If
                If (isFreeIBEChamber(ConstEnum.Equipments.Chamber2.ToString)) Then
                    arrResult.Add(ConstEnum.Equipments.Chamber2.ToString)
                End If
                If (isFreeIBEChamber(ConstEnum.Equipments.Chamber3.ToString)) Then
                    arrResult.Add(ConstEnum.Equipments.Chamber3.ToString)
                End If
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return arrResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' Clone List of Sequence step
        ''' used for ANYIBE MODE
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CloneListOfSegStep() As List(Of List(Of DBSeqStep))
            Dim arrResult As List(Of List(Of DBSeqStep)) = New List(Of List(Of DBSeqStep))()
            Try
                Dim i As Integer = 0
                For i = 0 To m_lstSeqStep.Count - 1
                    Dim subRoute As List(Of DBSeqStep) = m_lstSeqStep.Item(i)
                    Dim new_SubRoute As List(Of DBSeqStep) = New List(Of DBSeqStep)
                    If (subRoute IsNot Nothing AndAlso subRoute.Count > 0) Then
                        Dim new_Item As DBSeqStep = Nothing
                        For Each Item As DBSeqStep In subRoute
                            new_Item = Item.Clone
                            new_SubRoute.Add(new_Item)
                        Next
                    End If
                    arrResult.Add(new_SubRoute)
                Next
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return arrResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' Clone List Convert Route
        ''' used for ANYIBE MODE
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CloneListConvertedRoute() As List(Of String)
            Dim arrResult As List(Of String) = Nothing
            Try
                If (m_listConvertedRoute IsNot Nothing) Then
                    arrResult = New List(Of String)()
                    For Each Item As String In m_listConvertedRoute
                        arrResult.Add(Item)
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return arrResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' Clone Chamber Name List for RunData
        ''' used for ANYIBE MODE
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CloneChamberNameListForRunData() As List(Of String)
            Dim arrResult As List(Of String) = Nothing
            Try
                If (m_chamberNameListForRunData IsNot Nothing) Then
                    arrResult = New List(Of String)()
                    For Each Item As String In m_chamberNameListForRunData
                        arrResult.Add(Item)
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return arrResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' restore data when accquire resource failed
        ''' used for ANYIBE MODE
        ''' </summary>
        ''' <remarks></remarks>
        Public Function RestoreData(ByVal oldListofSecstep As List(Of List(Of DBSeqStep)),
                                    ByVal oldsifSequenceInfo As SequenceInfor,
                                    ByVal oldlistConvertedRoute As List(Of String),
                                    ByVal oldChamberNameListForRunData As List(Of String)) As Boolean
            Dim blResult As Boolean = False
            Try
                'clear all current data
                If (m_chamberNameListForRunData IsNot Nothing And m_chamberNameListForRunData.Count > 0) Then
                    m_chamberNameListForRunData.Clear()
                End If

                If (m_listConvertedRoute IsNot Nothing And m_listConvertedRoute.Count > 0) Then
                    m_listConvertedRoute.Clear()
                End If

                If (m_lstSeqStep IsNot Nothing And m_lstSeqStep.Count > 0) Then
                    m_lstSeqStep.Clear()
                End If

                If (m_sifSequenceInfor IsNot Nothing) Then
                    m_sifSequenceInfor.Clear()
                End If

                'restore data
                m_chamberNameListForRunData = oldChamberNameListForRunData
                m_listConvertedRoute = oldlistConvertedRoute
                m_lstSeqStep = oldListofSecstep
                m_sifSequenceInfor = oldsifSequenceInfo


                blResult = True
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
                blResult = False
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' Create Sequence step for ANYIBE MODE
        ''' Create success -> return true
        ''' find ANYIBE -> replay to FREE CHAMBER
        ''' modify recipe path and running recipe path
        ''' used for ANYIBE MODE
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CreareSequenceStepForANYIBE(ByVal ChamberName As String) As Boolean
            Dim blResult As Boolean = False
            Try
                Dim i As Integer = 0
                For i = 0 To m_lstSeqStep.Count - 1
                    Dim subRoute As List(Of DBSeqStep) = m_lstSeqStep.Item(i)
                    If (subRoute IsNot Nothing AndAlso subRoute.Count > 0) Then
                        For Each Item As DBSeqStep In subRoute
                            If (Item.StationName = ConstEnum.Equipments.IBE.ToString()) Then
                                Dim RecipeName As String = String.Empty

                                RecipeName = Item.RecipeName

                                Item.RecipeName = RecipeName
                                Item.StationName = ChamberName
                                If (Item.StationList IsNot Nothing) Then
                                    Item.StationList.RemoveAt(0)
                                    Item.StationList.Add(ChamberName)
                                End If
                            End If
                        Next
                    End If
                Next

                If (ChangeSequenceInfoForANYIBE(ChamberName) AndAlso
                ChangeListConvertRouteForANYIBE(ChamberName) AndAlso
                ChangeChamberNameListForANYIBE(ChamberName)) Then
                    blResult = True
                Else
                    blResult = False
                End If
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' Change from ANYIBE to ChamberName
        ''' used for ANYIBE MODE
        ''' </summary>
        ''' <remarks></remarks>
        Protected Function ChangeSequenceInfoForANYIBE(ByVal ChamberName As String) As Boolean
            Dim blResult As Boolean = False
            Try
                Dim i As Integer = 0
                For i = 0 To m_sifSequenceInfor.ChamberNames.Count - 1
                    Dim item As String = m_sifSequenceInfor.ChamberNames(i)
                    If (item = ConstEnum.Equipments.IBE.ToString()) Then
                        m_sifSequenceInfor.ChamberNames(i) = ChamberName
                        blResult = True
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' Change from ANYIBE to ChamberName
        ''' used for ANYIBE MODE
        ''' </summary>
        ''' <remarks></remarks>
        Protected Function ChangeListConvertRouteForANYIBE(ByVal ChamberName As String) As Boolean
            Dim blResult As Boolean = False
            Try
                Dim i As Integer = 0
                For i = 0 To m_listConvertedRoute.Count - 1
                    Dim item As String = m_listConvertedRoute(i)
                    If (item = ConstEnum.Equipments.IBE.ToString()) Then
                        m_listConvertedRoute(i) = ChamberName
                        blResult = True
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' Change from ANYIBE to ChamberName
        ''' used for ANYIBE MODE
        ''' </summary>
        ''' <remarks></remarks>
        Protected Function ChangeChamberNameListForANYIBE(ByVal ChamberName As String) As Boolean
            Dim blResult As Boolean = False
            Try
                Dim i As Integer = 0
                For i = 0 To m_chamberNameListForRunData.Count - 1
                    Dim item As String = m_chamberNameListForRunData(i)
                    If (item.Contains(RobotConfigurationValues.ANY_IBE_CHAMBER)) Then
                        m_chamberNameListForRunData(i) = m_chamberNameListForRunData(i).Replace(RobotConfigurationValues.ANY_IBE_CHAMBER, ChamberName)
                        blResult = True
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-28 </date>
        ''' </author>
        ''' <summary>
        ''' Create Sequence step for ANYIBE MODE
        ''' Create success -> return true
        ''' find ANYIBE -> replay to FREE CHAMBER
        ''' modify recipe path and running recipe path
        ''' used for ANYIBE MODE
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsANYIBE() As Boolean
            Dim blResult As Boolean = False
            Try
                If (SequenceInfor.ChamberNames.Count > 0) Then

                    For Each Item As String In SequenceInfor.ChamberNames
                        If (Item = ConstEnum.Equipments.IBE.ToString()) Then
                            blResult = True
                            Exit For
                        End If
                    Next

                End If
            Catch ex As Exception
                AVPLib.Log.schedulerLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
        Public Function ReleaseResourcesForStep(ByVal stepNumber As Integer) As Boolean
            If (stepNumber <= 0) Or (stepNumber > m_lstSeqStep.Count) Then
                Return False
            End If
            Dim sqSteps As List(Of DBSeqStep) = m_lstSeqStep.Item(stepNumber - 1)
            Dim stp As DBSeqStep = Nothing
            For Each stp In sqSteps
                Dim strEquipmentName As String = stp.StationName
                If Not ReleaseChamberResource(strEquipmentName) Then
                    Return False
                End If
            Next
            Return True
        End Function

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2010-03-10</date>
        ''' </author>
        ''' <summary>
        ''' Check and Wait for Open shutter
        ''' </summary>
        ''' <remarks></remarks>
        Private Function CheckAndWaitForShutterOpen(ByVal srcChamber As Chamber, ByVal waitTimeInSeconds As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckAndWaitForOpenShutter")
            Try
                '---------------------------------------------Main Loop-----------------------------------------------
                Const MinimumSleepTimeInSeconds As Integer = 1
                Dim quotaInSeconds As Integer = IIf(waitTimeInSeconds <= 0, MinimumSleepTimeInSeconds, waitTimeInSeconds)

                While (Not HasTerminateRequest())
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                    If (awokenByTerminate) Then
                        AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForOpenShutter")
                        Return False
                    End If
                    ' Check if we have run out of time ?
                    If (quotaInSeconds < 0) Then
                        Return False
                    End If
                    If Not srcChamber.IsShutterOpen() Then
                        Thread.Sleep(MinimumSleepTimeInSeconds * 1000)
                        quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                        Continue While
                    Else
                        Return True
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForOpenShutter")
            Return False
        End Function

        Private Function CheckAndWaitForClampUp(ByVal srcIBEChamber As IBEChamber, ByVal waitTimeInSeconds As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckAndWaitForClampUp")
            Try
                '---------------------------------------------Main Loop-----------------------------------------------
                Const MinimumSleepTimeInSeconds As Integer = 1
                Dim quotaInSeconds As Integer = IIf(waitTimeInSeconds <= 0, MinimumSleepTimeInSeconds, waitTimeInSeconds)

                While (Not HasTerminateRequest() OrElse IsReturnWafer)
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()

                    If (Not IsReturnWafer) Then
                        If (awokenByTerminate) Then
                            AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForClampUp")
                            Return False
                        End If
                    End If
                    ' Check if we have run out of time ?
                    If (quotaInSeconds < 0) Then
                        Return False
                    End If
                    ''clamp status is On = clamp up
                    ''check if clamp is not on -> wait
                    If (srcIBEChamber.ClampStatus <> Equipment.WorkingStatuses.On) Then
                        Thread.Sleep(MinimumSleepTimeInSeconds * 1000)
                        quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                        Continue While
                    Else
                        Return True
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForClampUp")
            Return False
        End Function
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2010-03-10</date>
        ''' </author>
        ''' <summary>
        ''' Check and Wait for Open shutter
        ''' </summary>
        ''' <remarks></remarks>
        Private Function CheckAndWaitForMotionInitialize(ByVal srcChamber As Chamber, ByVal waitTimeInSeconds As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckAndWaitForMotionInitialize")
            Try
                '---------------------------------------------Main Loop-----------------------------------------------
                Const MinimumSleepTimeInSeconds As Integer = 1
                Dim quotaInSeconds As Integer = IIf(waitTimeInSeconds <= 0, MinimumSleepTimeInSeconds, waitTimeInSeconds)
                Thread.Sleep(5000) ''waiting for motion status from IBE
                While (Not HasTerminateRequest() OrElse IsReturnWafer)
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()

                    If (Not IsReturnWafer) Then
                        If (awokenByTerminate) Then
                            AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForMotionInitialize")
                            Return False
                        End If
                    End If

                    ' Check if we have run out of time ?
                    If (quotaInSeconds < 0) Then
                        Return False
                    End If
                    If (srcChamber.Initialize_Motion_readback <> Equipment.WorkingStatuses.On) Then
                        If (CType(srcChamber, IBEChamber).Initializing_Motion_readback = Equipment.WorkingStatuses.On) Then
                            ''keep waiting for motion initialize
                            Thread.Sleep(MinimumSleepTimeInSeconds * 1000)
                            quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                            Continue While
                        Else
                            Return False ''no waiting for motion initialize, motion failed
                        End If
                    Else
                        ''motion initialize success
                        Return True
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForMotionInitialize")
            Return False
        End Function

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2010-03-10</date>
        ''' </author>
        ''' <summary>
        ''' Check and Wait for moving chuck to Zero
        ''' </summary>
        ''' <remarks></remarks>
        Private Function CheckAndWaitForMovingChuckToZero(ByVal srcPVDChamber As PVDChamber, ByVal waitTimeInSeconds As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckAndWaitForMovingChuckToZero")
            Try
                '---------------------------------------------Main Loop-----------------------------------------------
                Const MinimumSleepTimeInSeconds As Integer = 1
                Dim quotaInSeconds As Integer = IIf(waitTimeInSeconds <= 0, MinimumSleepTimeInSeconds, waitTimeInSeconds)

                While (Not HasTerminateRequest())
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()
                    If (awokenByTerminate) Then
                        AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForMovingChuckToZero")
                        Return False
                    End If
                    ' Check if we have run out of time ?
                    If (quotaInSeconds < 0) Then
                        Return False
                    End If
                    If Not (CInt(srcPVDChamber.ChuckPos_Readback) = 0) Then
                        Thread.Sleep(MinimumSleepTimeInSeconds * 1000)
                        quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                        Continue While
                    End If
                    Utils.ShowStatusMessage(Utils.chamberID2ChamberName(srcPVDChamber.Name) & " have already moved chuck to zero.")
                    AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForMovingChuckToZero")
                    Return True
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForMovingChuckToZero")
            Return False
        End Function
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2010-03-10</date>
        ''' </author>
        ''' <summary>
        ''' Check and Wait for moving chuck to Zero
        ''' </summary>
        ''' <remarks></remarks>
        Private Function CheckAndWaitForUnClamp(ByVal srcPVDChamber As PVDChamber, ByVal waitTimeInSeconds As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckAndWaitForUnClamp")
            Try
                '---------------------------------------------Main Loop-----------------------------------------------
                Const MinimumSleepTimeInSeconds As Integer = 1
                Dim quotaInSeconds As Integer = IIf(waitTimeInSeconds <= 0, MinimumSleepTimeInSeconds, waitTimeInSeconds)

                While (Not HasTerminateRequest() OrElse IsReturnWafer)
                    Dim awokenByTerminate As Boolean = SuspendIfNeeded()

                    If (Not IsReturnWafer) Then
                        If (awokenByTerminate) Then
                            AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForUnClamp")
                            Return False
                        End If
                    End If

                    ' Check if we have run out of time ?
                    If (quotaInSeconds < 0) Then
                        Return False
                    End If
                    If Not (srcPVDChamber.ClampStatus_Readback = Equipment.WorkingStatuses.Off) Then ''not unclamp
                        ''keep waiting
                        Thread.Sleep(MinimumSleepTimeInSeconds * 1000)
                        quotaInSeconds = quotaInSeconds - MinimumSleepTimeInSeconds
                        Continue While
                    End If
                    Utils.ShowStatusMessage(AVPLib.Utils.chamberID2ChamberName(srcPVDChamber.Name) & " have already unclamped.")
                    AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForUnClamp")
                    Return True
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.schedulerLogger.Info("Leave CheckAndWaitForUnClamp")
            Return False
        End Function

        Public Function isLastStep() As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter isLastStep")
            Try
                Dim nextChamber As String = GetNextChamberInNeed()
                If nextChamber = String.Empty Then
                    AVPLib.Log.schedulerLogger.Info("Leave isLastStep")
                    Return True
                Else
                    AVPLib.Log.schedulerLogger.Info("Leave isLastStep")
                    Return False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-07-18</date>
        ''' </author>
        ''' <summary>
        ''' When Job is Resumming -> Acquire resource
        ''' Step 1 Detect 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function AcquirePauseResource() As Boolean
            AVPLib.Log.schedulerLogger.Info("Enter AcquirePauseResource")
            Try
                Dim nextChamber As String = GetNextChamberInNeed()
                If nextChamber = String.Empty Then
                    If (m_idxCurrentStationForPickingInRoute + 1 < m_listConvertedRoute.Count) Then
                        Dim strStation As String = m_listConvertedRoute(m_idxCurrentStationForPickingInRoute + 1)
                        If (strStation <> String.Empty AndAlso strStation.Contains("LoadLock")) Then
                            AVPLib.Log.schedulerLogger.Info("Leave AcquirePauseResource")
                            Return True
                        Else
                            AVPLib.Log.schedulerLogger.Info("Leave AcquirePauseResource")
                            Return False
                        End If
                        AVPLib.Log.schedulerLogger.Info("Leave AcquirePauseResource")
                        Return False
                    Else
                        AVPLib.Log.schedulerLogger.Info("Leave AcquirePauseResource")
                        Return True
                    End If
                Else
                    AVPLib.Log.schedulerLogger.Info("Leave AcquirePauseResource")
                    Return AcquireChamberResource(nextChamber, GetSlotID(nextChamber), True, True, False)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-07-18</date>
        ''' </author>
        ''' <summary>
        ''' When Job is Pause -> release all resource(!chamber)
        ''' </summary>
        ''' <remarks></remarks>
        Public Function ReleasePauseResource() As Boolean
            Try
                Dim sCurrentChamberStep As String = m_listConvertedRoute(m_idxCurrentStationForPickingInRoute).ToString()

                For stepNumber As Integer = m_idxCurrentStationForPickingInRoute + 1 To m_listConvertedRoute.Count - 1
                    Dim strEquipmentName As String = m_listConvertedRoute(stepNumber).ToString()
                    If (m_curAllocatedWFResources.ContainsKey(strEquipmentName) AndAlso strEquipmentName <> sCurrentChamberStep) Then
                        If Not ReleaseChamberResource(strEquipmentName) Then
                            Return False
                        End If
                    End If

                Next
                Return True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try

        End Function

        Public Function IsJobPauseAtAligner() As Boolean
            Try
                Dim eqmEquiment As Equipment = Nothing
                eqmEquiment = EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString)
                If (eqmEquiment IsNot Nothing AndAlso eqmEquiment.GetWaferInfo() IsNot Nothing AndAlso eqmEquiment.GetWaferInfo().WaferID = SequenceInfor.WaferInfo.WaferID) Then
                    Return True
                End If
                Return False
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-07-18</date>
        ''' </author>
        ''' <summary>
        ''' When Job is Pause -> release all resource(!chamber)
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsJobPauseInRobot() As Boolean
            Try
                Dim eqmEquiment As Equipment = Nothing
                eqmEquiment = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString)
                If (eqmEquiment IsNot Nothing AndAlso eqmEquiment.GetWaferInfo() IsNot Nothing AndAlso eqmEquiment.GetWaferInfo().WaferID = SequenceInfor.WaferInfo.WaferID) Then
                    Return True
                End If
                Return False
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try

        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-05-24</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsJobPauseInAligner() As Boolean
            Dim blResult As Boolean = False
            Try
                If (IsPaused()) Then
                    blResult = CurrentStation = ConstEnum.Equipments.Aligner.ToString
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-01-28</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsJobPauseInChamber() As Boolean
            Try
                Dim eqmEquiment As Equipment = Nothing
                eqmEquiment = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString)
                If (eqmEquiment IsNot Nothing AndAlso eqmEquiment.GetWaferInfo() IsNot Nothing AndAlso eqmEquiment.GetWaferInfo().WaferID = SequenceInfor.WaferInfo.WaferID) Then
                    Return True
                End If
                Return False
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try

        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-07-18</date>
        ''' </author>
        ''' <summary>
        ''' Wafer Capacity 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function WaferCapacity() As Integer
            Dim iResult As Integer = -1
            Try
                If (m_lstRoute IsNot Nothing AndAlso m_lstRoute.Count > 0) Then

                    For index As Integer = 1 To m_lstRoute.Count - 2
                        If (m_lstRoute(index).StationName.Contains(ChamberID)) Then
                            Dim objChamber As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(m_lstRoute(index).StationName)
                            If (objChamber IsNot Nothing) Then
                                iResult = objChamber.WaferCapacity
                                Exit For
                            End If
                        End If
                    Next

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return iResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-07-18</date>
        ''' </author>
        ''' <summary>
        ''' Get Slot ID From Station
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetSlotID(ByVal strChamberName As String) As Integer
            Dim iResult As Integer = -1
            Try
                If (m_blnIsAutoTransfer) Then
                    If (m_lstRoute IsNot Nothing AndAlso m_lstRoute.Count > 0) Then

                        For Each Item As DBSeqStep In m_lstRoute
                            If (Item.StationName = strChamberName) Then
                                iResult = Item.SlotID
                                Exit For
                            End If
                        Next
                    End If
                Else
                    Dim objChamber As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(strChamberName)
                    If (objChamber IsNot Nothing) Then
                        iResult = objChamber.GetNextFreeWaferSlotIndex()
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return iResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-01-18</date>
        ''' </author>
        ''' <summary>
        ''' Step Move Corona SubLift ToUp
        ''' </summary>
        ''' <remarks></remarks>
        Private Function StepMoveCoronaSubLiftToUp(ByVal objCoronaChamber As CoronaChamber) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objCoronaChamber IsNot Nothing) Then
                    Dim m_objChamberModule As SystemModule = ContainerData.GetRobotConfig(objCoronaChamber.Name)
                    If m_objChamberModule IsNot Nothing AndAlso m_objChamberModule.WaferLiftInstalled = False Then
                        Return True
                    Else
                        If (objCoronaChamber.Substrate_Lift_Up_Down_Status <> DataManagerment.Equipment.WorkingStatuses.On) Then
                            If (CoronaUtility.DoSetSubstrate_Lift_Up_Down_Status(ConstEnum.STR_ON, objCoronaChamber.Name)) Then
                                blResult = WaitOnCondition(AddressOf objCoronaChamber.IsSubStrateLiftAtUpPosition, objCoronaChamber.SubStrateGoUpDownWaitTimeInMiliseconds, False)
                            End If
                        Else
                            blResult = True
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        Private Function StepMovePVD5TSubLiftToUp(ByVal objChamber As PVD5TChamber) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objChamber IsNot Nothing) Then
                    Dim m_objChamberModule As SystemModule = ContainerData.GetRobotConfig(objChamber.Name)
                    If m_objChamberModule IsNot Nothing AndAlso m_objChamberModule.WaferLiftInstalled = False Then
                        Return True
                    Else
                        If (objChamber.Substrate_Lift_Up_Down_Status <> DataManagerment.Equipment.WorkingStatuses.On) Then
                            If (PVD5TUtility.DoSetSubstrate_Lift_Up_Down_Status(ConstEnum.STR_ON, objChamber.Name)) Then
                                blResult = WaitOnCondition(AddressOf objChamber.IsSubStrateLiftAtUpPosition, objChamber.SubStrateGoUpDownWaitTimeInMiliseconds, False)
                            End If
                        Else
                            blResult = True
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-03-06</date>
        ''' </author>
        ''' <summary>
        ''' Step Move Corona Table Lift To Home
        ''' </summary>
        ''' <remarks></remarks>
        Private Function StepMoveCoronaTableLiftToHome(ByVal objCoronaChamber As CoronaChamber) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objCoronaChamber IsNot Nothing) Then
                    If objCoronaChamber.Substrate_Table_Lift_Home <> Equipment.WorkingStatuses.On Then
                        If (CoronaUtility.DoSetSubstrate_Table_Lift_Home(ConstEnum.STR_ON, objCoronaChamber.Name)) Then
                            blResult = WaitOnCondition(AddressOf objCoronaChamber.IsTableLiftHome, objCoronaChamber.TableLiftHomeWaitTimeInMiliseconds, False)
                        End If
                    Else
                        blResult = True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        Private Function StepMovePVD5TTableLiftToHome(ByVal objChamber As PVD5TChamber) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objChamber IsNot Nothing) Then
                    If objChamber.Substrate_Table_Lift_Home <> Equipment.WorkingStatuses.On Then
                        If (PVD5TUtility.DoSetSubstrate_Table_Lift_Home(ConstEnum.STR_ON, objChamber.Name)) Then
                            blResult = WaitOnCondition(AddressOf objChamber.IsTableLiftHome, objChamber.TableLiftHomeWaitTimeInMiliseconds, False)
                        End If
                    Else
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
        '''    	<date> 2013-04-10</date>
        ''' </author>
        ''' <summary>
        ''' wait for motion is stopped
        ''' </summary>
        ''' <remarks></remarks>
        Private Function StepVerifyMotionStopped(ByVal objCoronaChamber As CoronaChamber) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objCoronaChamber IsNot Nothing) Then
                    If objCoronaChamber.Initialized_Motion = Equipment.WorkingStatuses.Unknown Then
                        blResult = WaitOnCondition(AddressOf objCoronaChamber.IsMotionStop, objCoronaChamber.MotionInitializedWaitTimeInMiliseconds, False)
                    Else
                        blResult = True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        Private Function PVD5TStepVerifyMotionStopped(ByVal objChamber As PVD5TChamber) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objChamber IsNot Nothing) Then
                    If objChamber.Initialized_Motion = Equipment.WorkingStatuses.Unknown Then
                        blResult = WaitOnCondition(AddressOf objChamber.IsMotionStop, objChamber.MotionInitializedWaitTimeInMiliseconds, False)
                    Else
                        blResult = True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 201709-08 </date>
        ''' </author>
        ''' <summary>
        ''' Chekc if table is home or not.
        ''' </summary>
        ''' <remarks></remarks>
        Private Function IsTableHome(ByVal objCoronaChamber As CoronaChamber) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objCoronaChamber IsNot Nothing) Then
                    If (objCoronaChamber.Substrate_Table_Lift_Home = Equipment.WorkingStatuses.On) AndAlso objCoronaChamber.IsSubStrateTableStopMoving() Then
                        blResult = True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        Private Function PVD5TIsTableHome(ByVal objChamber As PVD5TChamber) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objChamber IsNot Nothing) Then
                    If (objChamber.Substrate_Table_Lift_Home = Equipment.WorkingStatuses.On) AndAlso objChamber.IsSubStrateTableStopMoving() Then
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
        '''    	<date> 2013-01-18</date>
        ''' </author>
        ''' <summary>
        ''' Step Move Corona Table to Station X
        ''' </summary>
        ''' <remarks></remarks>
        Private Function StepMoveCoronaTableGoToSlot(ByVal objCoronaChamber As CoronaChamber, ByVal SlotID As Integer) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objCoronaChamber IsNot Nothing) Then
                    'check if continue moving then wait for stop moving
                    If Not (objCoronaChamber.IsSubStrateTableStopMoving) Then 'moving
                        AVPLib.Log.avpLogger.Error("DEBUG-------: StepMoveCoronaTableGoToSlot. Table is still moving.")
                        'Check stop in 6s for special case. Back-end keep 5s before update GUI to front-end
                        'Add one more second to prevent delay time between front-end and back-end
                        blResult = WaitOnConditionWithDurationCheck(AddressOf objCoronaChamber.IsSubStrateTableStopMoving, objCoronaChamber.SubStrateGotoSlotWaitTimeInMiliseconds, False, 10000)
                    End If

                    ''''''''''''''''
                    If (objCoronaChamber.Substrate_Current_Station <> SlotID) Then
                        AVPLib.Log.avpLogger.Error("DEBUG-------: StepMoveCoronaTableGoToSlot. Current Slot = " + objCoronaChamber.Substrate_Current_Station.ToString() + " SlotID = " + SlotID.ToString())

                        If (CoronaUtility.DoSetSubstrate_Goto_Slot(SlotID, objCoronaChamber.Name)) Then
                            AVPLib.Log.avpLogger.Error("DEBUG-------: StepMoveCoronaTableGoToSlot. Sent goto slot. Wait for stop moving")
                            blResult = WaitOnConditionWithDurationCheck(AddressOf objCoronaChamber.IsSubStrateTableStopMoving, objCoronaChamber.SubStrateGotoSlotWaitTimeInMiliseconds, False, 10000)
                        End If
                        ''' check current slot 
                        If (objCoronaChamber.Substrate_Current_Station <> SlotID) Then
                            blResult = False
                        End If
                    Else
                        blResult = True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        Private Function StepMovePVD5TTableGoToSlot(ByVal objChamber As PVD5TChamber, ByVal SlotID As Integer) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objChamber IsNot Nothing) Then
                    'check if continue moving then wait for stop moving
                    If Not (objChamber.IsSubStrateTableStopMoving) Then 'moving
                        AVPLib.Log.avpLogger.Error("DEBUG-------: StepMovePVD5TTableGoToSlot. Table is still moving.")
                        'Check stop in 6s for special case. Back-end keep 5s before update GUI to front-end
                        'Add one more second to prevent delay time between front-end and back-end
                        blResult = WaitOnConditionWithDurationCheck(AddressOf objChamber.IsSubStrateTableStopMoving, objChamber.SubStrateGotoSlotWaitTimeInMiliseconds, False, 10000)
                    End If

                    ''''''''''''''''
                    If (objChamber.Substrate_Current_Station <> SlotID) Then
                        AVPLib.Log.avpLogger.Error("DEBUG-------: StepMovePVD5TTableGoToSlot. Current Slot = " + objChamber.Substrate_Current_Station.ToString() + " SlotID = " + SlotID.ToString())

                        If (PVD5TUtility.DoSetSubstrate_Goto_Slot(SlotID, objChamber.Name)) Then
                            AVPLib.Log.avpLogger.Error("DEBUG-------: StepMovePVD5TTableGoToSlot. Sent goto slot. Wait for stop moving")
                            blResult = WaitOnConditionWithDurationCheck(AddressOf objChamber.IsSubStrateTableStopMoving, objChamber.SubStrateGotoSlotWaitTimeInMiliseconds, False, 10000)
                        End If
                        ''' check current slot 
                        If (objChamber.Substrate_Current_Station <> SlotID) Then
                            blResult = False
                        End If
                    Else
                        blResult = True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2013-01-18</date>
        ''' </author>
        ''' <summary>
        ''' Continue wait when motor stop
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ContinueWaitMotor(ByVal objCoronaChamber As CoronaChamber)
            Try
                If (objCoronaChamber IsNot Nothing) Then
                    'check if continue moving then wait for stop moving
                    If (objCoronaChamber.IsSubStrateTableStopMoving) Then 'moving

                        AVPLib.Log.avpLogger.Error("DEBUG-------: ContinueWaitMotor. Wait 4s ")
                        Thread.Sleep(4000)

                        'check again
                        If Not (objCoronaChamber.IsSubStrateTableStopMoving) Then
                            AVPLib.Log.avpLogger.Error("DEBUG-------: ContinueWaitMotor. Subtrate table is still moving")
                            WaitOnConditionWithDurationCheck(AddressOf objCoronaChamber.IsSubStrateTableStopMoving, objCoronaChamber.SubStrateGotoSlotWaitTimeInMiliseconds, False, 10000)
                        End If
                    Else
                        WaitOnConditionWithDurationCheck(AddressOf objCoronaChamber.IsSubStrateTableStopMoving, objCoronaChamber.SubStrateGotoSlotWaitTimeInMiliseconds, False, 10000)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        Private Sub PVD5TContinueWaitMotor(ByVal objChamber As PVD5TChamber)
            Try
                If (objChamber IsNot Nothing) Then
                    'check if continue moving then wait for stop moving
                    If (objChamber.IsSubStrateTableStopMoving) Then 'moving

                        AVPLib.Log.avpLogger.Error("DEBUG-------: ContinueWaitMotor. Wait 4s ")
                        Thread.Sleep(4000)

                        'check again
                        If Not (objChamber.IsSubStrateTableStopMoving) Then
                            AVPLib.Log.avpLogger.Error("DEBUG-------: ContinueWaitMotor. Subtrate table is still moving")
                            WaitOnConditionWithDurationCheck(AddressOf objChamber.IsSubStrateTableStopMoving, objChamber.SubStrateGotoSlotWaitTimeInMiliseconds, False, 10000)
                        End If
                    Else
                        WaitOnConditionWithDurationCheck(AddressOf objChamber.IsSubStrateTableStopMoving, objChamber.SubStrateGotoSlotWaitTimeInMiliseconds, False, 10000)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub


        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-04-02</date>
        ''' </author>
        ''' <summary>
        ''' move table go to slot X + 1
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub StepMoveNextSlot(ByVal objCoronaChamber As CoronaChamber, ByVal SlotID As Integer, ByVal IsPickFromCoronaChamber As Boolean)
            Dim IsExecuteGoToSlot As Boolean = False
            Try
                If (objCoronaChamber IsNot Nothing) Then
                    '' if current slot is 8, assign slot is 1 else slot is slot + 1
                    If SlotID >= objCoronaChamber.WaferCapacity Then
                        SlotID = 1
                    Else
                        SlotID += 1
                    End If

                    'Scheduler run.   Currently when robot pickup wafer 1,  
                    'we send table to move to slot 2. Though when robot pick up wafer 8,  
                    'we are not sending move to slot 1
                    ''' check next slot is not empty if pick, check next slot is empty if place to CoronaChamber
                    If IsPickFromCoronaChamber Then
                        ''' if process is AutoTransfer or clear all wafer or return wafer, move to slot + 1
                        'If IsAutoTransfer OrElse m_AVPControlJob.IsReturnFreeJob OrElse ReturnWafer Then
                        '    IsExecuteGoToSlot = (objCoronaChamber.GetWaferInfo(SlotID) IsNot Nothing)
                        'End If
                        IsExecuteGoToSlot = True
                    Else
                        '' if process is AutoTransfer, move to slot + 1
                        If IsAutoTransfer Then
                            IsExecuteGoToSlot = (objCoronaChamber.GetCountWaferIsProcessing() < BatchProcessCount)
                        End If
                    End If

                    ' send command go to slot
                    If IsExecuteGoToSlot Then
                        CoronaUtility.DoSetSubstrate_Goto_Slot(SlotID, objCoronaChamber.Name)
                    End If

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        Private Sub StepPVD5TMoveNextSlot(ByVal objPVD5TChamber As PVD5TChamber, ByVal SlotID As Integer, ByVal IsPickFromPVD5TChamber As Boolean)
            Dim IsExecuteGoToSlot As Boolean = False
            Try
                If (objPVD5TChamber IsNot Nothing) Then
                    '' if current slot is 8, assign slot is 1 else slot is slot + 1
                    If SlotID >= objPVD5TChamber.WaferCapacity Then
                        SlotID = 1
                    Else
                        SlotID += 1
                    End If

                    'Scheduler run.   Currently when robot pickup wafer 1,  
                    'we send table to move to slot 2. Though when robot pick up wafer 8,  
                    'we are not sending move to slot 1
                    ''' check next slot is not empty if pick, check next slot is empty if place to CoronaChamber
                    If IsPickFromPVD5TChamber Then
                        ''' if process is AutoTransfer or clear all wafer or return wafer, move to slot + 1
                        'If IsAutoTransfer OrElse m_AVPControlJob.IsReturnFreeJob OrElse ReturnWafer Then
                        '    IsExecuteGoToSlot = (objCoronaChamber.GetWaferInfo(SlotID) IsNot Nothing)
                        'End If
                        IsExecuteGoToSlot = True
                    Else
                        '' if process is AutoTransfer, move to slot + 1
                        If IsAutoTransfer Then
                            IsExecuteGoToSlot = (objPVD5TChamber.GetCountWaferIsProcessing() < BatchProcessCount)
                        End If
                    End If

                    ' send command go to slot
                    If IsExecuteGoToSlot Then
                        PVD5TUtility.DoSetSubstrate_Goto_Slot(SlotID, objPVD5TChamber.Name)
                    End If

                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-01-18</date>
        ''' </author>
        ''' <summary>
        ''' Step Move Corona SubLift To Down
        ''' </summary>
        ''' <remarks></remarks>
        Private Function StepMoveCoronaSubLiftToDown(ByVal objCoronaChamber As CoronaChamber) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objCoronaChamber IsNot Nothing) Then
                    Dim m_objChamberModule As SystemModule = ContainerData.GetRobotConfig(objCoronaChamber.Name)
                    If m_objChamberModule IsNot Nothing AndAlso m_objChamberModule.WaferLiftInstalled = False Then
                        Return True
                    Else
                        If (objCoronaChamber.Substrate_Lift_Up_Down_Status <> DataManagerment.Equipment.WorkingStatuses.Off) Then
                            If (CoronaUtility.DoSetSubstrate_Lift_Up_Down_Status(ConstEnum.STR_OFF, objCoronaChamber.Name)) Then
                                blResult = WaitOnCondition(AddressOf objCoronaChamber.IsSubStrateLiftAtDownPosition, objCoronaChamber.SubStrateGoUpDownWaitTimeInMiliseconds, False)
                            End If
                        Else
                            blResult = True
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        Private Function StepMovePVD5TSubLiftToDown(ByVal objChamber As PVD5TChamber) As Boolean
            Dim blResult As Boolean = False
            Try
                If (objChamber IsNot Nothing) Then
                    Dim m_objChamberModule As SystemModule = ContainerData.GetRobotConfig(objChamber.Name)
                    If m_objChamberModule IsNot Nothing AndAlso m_objChamberModule.WaferLiftInstalled = False Then
                        Return True
                    Else
                        If (objChamber.Substrate_Lift_Up_Down_Status <> DataManagerment.Equipment.WorkingStatuses.Off) Then
                            If (PVD5TUtility.DoSetSubstrate_Lift_Up_Down_Status(ConstEnum.STR_OFF, objChamber.Name)) Then
                                blResult = WaitOnCondition(AddressOf objChamber.IsSubStrateLiftAtDownPosition, objChamber.SubStrateGoUpDownWaitTimeInMiliseconds, False)
                            End If
                        Else
                            blResult = True
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        '''' <author>
        ''''    	<name> Dat Cao </name>
        ''''    	<date> 2013-06-04</date>
        '''' </author>
        '''' <summary>
        '''' Is Continue To Pick On Loadlock On Stopping Mode
        '''' </summary>
        '''' <remarks></remarks>
        Public Function IsContinueToPickOnLoadlockOnStoppingMode() As Boolean
            Dim blResult As Boolean = False

            Try
                Dim pJob As AVPProcessJob = Nothing

                Dim ListOfProcessJob As List(Of AVPProcessJob) = Me.AVPParentControlJob.ListOfProcessJob

                If (ListOfProcessJob IsNot Nothing AndAlso ListOfProcessJob.Count > 0) Then
                    For Each pJob In ListOfProcessJob
                        If (pJob IsNot Nothing AndAlso pJob.JobID <> Me.JobID AndAlso
                            pJob.StopInProcess AndAlso pJob.BatchProcessJobGroupIdx = Me.BatchProcessJobGroupIdx) Then
                            blResult = True
                            Exit Try
                        End If
                    Next
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return blResult

        End Function

        ''' <author>
        '''    	<name> Kiet Tran </name>
        '''    	<date> 2026-03-03</date>
        ''' </author>
        ''' <summary>
        ''' Check Robot is at station or not
        ''' </summary>
        ''' <param name="chamberName"></param>
        ''' <returns></returns>
        Private Function IsRobotAtStation(ByVal chamberName As String) As Boolean
            Dim blResult As Boolean = False
            Try
                Dim objRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
                If (objRobot Is Nothing) Then
                    Return True
                End If

                Select Case chamberName
                    Case ConstEnum.Equipments.Chamber1.ToString()
                        If (objRobot.CurrentPosition = ConstEnum.Positions.Chamber1 OrElse
                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber1_Extract OrElse
                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber1_Wafer_Extract OrElse
                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber1_Wafer) Then

                            blResult = True
                        End If
                    Case ConstEnum.Equipments.Chamber2.ToString()
                        If (objRobot.CurrentPosition = ConstEnum.Positions.Chamber2 OrElse
                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber2_Extract OrElse
                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber2_Wafer_Extract OrElse
                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber2_Wafer) Then

                            blResult = True
                        End If
                    Case ConstEnum.Equipments.Chamber3.ToString()
                        If (objRobot.CurrentPosition = ConstEnum.Positions.Chamber3 OrElse
                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber3_Extract OrElse
                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber3_Wafer_Extract OrElse
                        objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber3_Wafer) Then

                            blResult = True
                        End If
                    Case Else

                End Select

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function

        Private Function IsRobotAtLoadlockPosition() As Boolean
            Dim blResult As Boolean = False
            Try
                Dim objRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
                If (objRobot Is Nothing) Then
                    Return True
                End If

                If (objRobot.CurrentPosition = ConstEnum.Positions.LoadLockA OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_LLA_Extract OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_LLA_Wafer_Extract OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_LLA_Wafer) Then
                    blResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function

        Private Sub AddActionLog(ByVal sMessage As String)
            AVPLib.Log.avpLogger.Debug(JobID + " " + sMessage)
        End Sub

        Public Overrides Sub Interrupt()
            If m_thread IsNot Nothing Then
                m_thread.Interrupt()
            End If
        End Sub

        Public Overrides Sub Abort()
            If m_thread IsNot Nothing Then
                m_thread.Abort()
            End If
        End Sub
    End Class

End Namespace
