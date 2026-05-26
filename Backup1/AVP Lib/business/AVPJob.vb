Public Enum JobTypeEnum
    ControlJob = 0
    ProcessJob = 1
End Enum

Public MustInherit Class AVPJob
    Inherits SuspendableThread

    Protected m_strJobID As String
    Protected m_eJobType As JobTypeEnum

    Public ReadOnly Property JobType() As JobTypeEnum
        Get
            Return m_eJobType
        End Get
    End Property

    Public ReadOnly Property JobID() As String
        Get
            Return m_strJobID
        End Get
    End Property

    Public Sub New(ByVal strJobID As String, ByVal eJobType As JobTypeEnum)
        m_strJobID = strJobID
        m_eJobType = eJobType
    End Sub
    
    Protected Overrides Sub OnDoWork()
        ' Do nothing here.
    End Sub

    Public Overloads Function ChangeState(ByVal strDestState As String) As Boolean
        If m_eJobType = JobTypeEnum.ControlJob Then
            Return ChangeStateCJ(strDestState)
        Else
            Return ChangeStatePJ(strDestState)
        End If
    End Function
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' change state Machine base on Trigger ID
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ChangeStateCJ(ByVal strDestState As String) As Boolean
        Dim blnRet As Boolean = False
        Try
            Dim stateMachine As AVPStateMachine = AVPCore.StateMachineManager.GetStateMachine(ConstEnum.STATE_MACHINE_TYPE.ControlJob.ToString())
            If stateMachine IsNot Nothing Then
                If stateMachine.CanChangeState(CurrentState, strDestState) Then
                    PreviousState = CurrentState
                    CurrentState = strDestState
                    AVPLib.Log.schedulerLogger.Debug("CJ-" & JobID & " changed from " & PreviousState & " to " & CurrentState)
                    blnRet = True
                Else
                    PreviousState = CurrentState
                    CurrentState = strDestState
                    AVPLib.Log.schedulerLogger.Debug("CJ-" & JobID & " change state from " + PreviousState + " to " + CurrentState + ", WARNING: this transition is not present in state machine file.")
                    blnRet = False
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blnRet
    End Function
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' change state Machine base on Trigger ID
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ChangeStatePJ(ByVal strDestState As String) As Boolean
        Dim blnRet As Boolean = False
        Try
            Dim stateMachine As AVPStateMachine = AVPCore.StateMachineManager.getStateMachine(ConstEnum.STATE_MACHINE_TYPE.ControlJob.ToString())
            If stateMachine IsNot Nothing Then
                If stateMachine.CanChangeState(CurrentState, strDestState) Then
                    PreviousState = CurrentState
                    CurrentState = strDestState
                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " changed from " & PreviousState & " to " & CurrentState)
                    blnRet = True
                Else
                    ' Allow it change state but send an error
                    PreviousState = CurrentState
                    CurrentState = strDestState
                    AVPLib.Log.schedulerLogger.Debug("PJ-" & JobID & " change state from " + PreviousState + " to " + CurrentState + ", WARNING: this transition is not present in state machine file.")
                    blnRet = False
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blnRet
    End Function

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-12-27</date>
    ''' </author>
    ''' <summary>
    ''' each process job have one varialbe name: BatchProcessCount 
    ''' = total Job have wafer flow similar to adjacent 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub BuildBatchProcessJob(ByVal lstProcessJob)
        Try
            If (lstProcessJob IsNot Nothing AndAlso lstProcessJob.Count > 1) Then
                Dim i As Integer = 1
                Dim PJ1 As Business.AVPProcessJob = Nothing
                Dim PJ2 As Business.AVPProcessJob = Nothing
                Dim WaferCount As Integer = 1
                Dim startIdx As Integer = 0
                Dim iBatchGroupIdx As Integer = 1
                For i = 1 To lstProcessJob.Count - 1
                    PJ1 = lstProcessJob(i)
                    PJ2 = lstProcessJob(i - 1)


                    If (PJ1.WaferFlowName = PJ2.WaferFlowName AndAlso PJ1.WaferCapacity > WaferCount) Then
                        'increase batch process
                        PJ2.Priority = PJ2.BatchProcessCount
                        PJ2.BatchSlotID = PJ2.BatchProcessCount
                        PJ2.BatchProcessCount += 1
                        PJ1.BatchProcessCount = PJ2.BatchProcessCount
                        PJ1.Priority = PJ1.BatchProcessCount
                        PJ1.BatchSlotID = PJ1.BatchProcessCount
                        WaferCount += 1

                        PJ2.BatchProcessJobGroupIdx = iBatchGroupIdx
                        PJ1.BatchProcessJobGroupIdx = iBatchGroupIdx
                        'roll back previous to inscrese batch count
                        Dim j As Integer = i - 2
                        If (j >= 0) Then

                            While (j >= 0 AndAlso j >= startIdx)
                                Dim PJ3 As Business.AVPProcessJob = lstProcessJob(j)
                                If (PJ3.WaferFlowName = PJ2.WaferFlowName) Then
                                    PJ3.BatchProcessCount += 1
                                Else
                                    Exit While
                                End If
                                j -= 1
                            End While
                        End If
                    Else
                        PJ2.BatchProcessJobGroupIdx = iBatchGroupIdx
                        iBatchGroupIdx += 1
                        PJ1.BatchProcessJobGroupIdx = iBatchGroupIdx
                        WaferCount = 1
                        startIdx = i
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
