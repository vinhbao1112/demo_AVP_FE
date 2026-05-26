Imports System.Threading

Public MustInherit Class SuspendableThread
    Inherits AVPLib.Business.AVPObject
    ' Fields
    Private m_failsafeThreadState As ThreadState = ThreadState.Unstarted
    Private m_suspendChangedEvent As ManualResetEvent = New ManualResetEvent(False)
    Protected m_thread As Thread

    Protected m_suspended As Long = 0
    Protected m_terminateEvent As ManualResetEvent = New ManualResetEvent(False)
    Protected m_objLock As New Object
    Private m_isBackgroundThread As Boolean = True
    Public Sub New()

    End Sub
    Public Property isBackgroundThread() As Boolean
        Get
            Return m_isBackgroundThread
        End Get
        Set(ByVal value As Boolean)
            m_isBackgroundThread = value
        End Set
    End Property
    Public ReadOnly Property ThreadState() As ThreadState
        Get
            If (m_thread IsNot Nothing) Then
                Return m_thread.ThreadState
            Else
                Return m_failsafeThreadState
            End If
        End Get
    End Property

    Public Sub Join()
        If (m_thread IsNot Nothing) Then
            m_thread.Join()
        End If
    End Sub

    Public Function Join(ByVal milliseconds As Integer) As Boolean
        If (m_thread IsNot Nothing) Then
            Return m_thread.Join(milliseconds)
        End If
        Return True
    End Function

    Public Function Join(ByVal timeSpan As TimeSpan) As Boolean
        If (m_thread IsNot Nothing) Then
            Return m_thread.Join(timeSpan)
        End If
        Return True
    End Function

    Protected Function HasTerminateRequest() As Boolean
        Return m_terminateEvent.WaitOne(0, True)
    End Function

    ' This method sleeps this thread in millisecondsSleepTime, and return true if there is a terminate request.
    Protected Function SleepButAlertabletoTerminateRequest(ByVal millisecondsSleepTime As Integer) As Boolean
        Return (0 = WaitHandle.WaitAny(New WaitHandle() {m_terminateEvent}, millisecondsSleepTime, False))
    End Function

    ' This method suspends this thread if needed, and return true if there is a terminate request.
    Protected Function SuspendIfNeeded(Optional ByVal waitTimeInMilliseconds As Integer = 0) As Boolean
        If m_suspendChangedEvent.WaitOne(waitTimeInMilliseconds, True) Then
            Dim needToSuspend As Boolean = (Interlocked.Read((m_suspended)) <> 0)
            m_suspendChangedEvent.Reset()
            If (needToSuspend AndAlso (1 = WaitHandle.WaitAny(New WaitHandle() {m_suspendChangedEvent, m_terminateEvent}))) Then
                Return True
            End If
        End If
        Return False
    End Function

    Protected Function HasSuspendRequest() As Boolean
        If m_suspendChangedEvent.WaitOne(0, True) Then
            Dim needToSuspend As Boolean = (Interlocked.Read((m_suspended)) <> 0)
            Return needToSuspend
        End If
        Return False
    End Function

    Protected Function HasTerminateRequest(ByVal milliseconds As Int32) As Boolean
        Return m_terminateEvent.WaitOne(milliseconds, True)
    End Function
    ' Main thread function.
    Protected MustOverride Sub OnDoWork()

    Private Sub ThreadEntry()
        m_failsafeThreadState = ThreadState.Stopped
        m_suspended = 0
        m_suspendChangedEvent.Reset()
        m_terminateEvent.Reset()
        OnDoWork()
    End Sub

    Public Sub Start()
        m_thread = New Thread(New ThreadStart(AddressOf ThreadEntry))
        ' Make sure this thread will be automaticaly
        ' terminated by the runtime when the
        ' application exits
        m_thread.IsBackground = m_isBackgroundThread
        m_thread.Start()
    End Sub

    Public Sub Suspend()
        SyncLock m_objLock
            If (m_suspended = 0) Then
                m_suspended = 1
                m_suspendChangedEvent.Set()
            End If
        End SyncLock
    End Sub

    Public Sub [Resume]()
        SyncLock m_objLock
            If (m_suspended = 1) Then
                m_suspended = 0
                m_suspendChangedEvent.Set()
            End If
        End SyncLock
    End Sub

    Public Sub Terminate()
        m_terminateEvent.Set()
    End Sub

    Public Sub TerminateAndWait()
        m_terminateEvent.Set()
        Join()
    End Sub
    Public Function IsStoping() As Boolean
        Return HasTerminateRequest()
    End Function

    Public Function IsStoping(ByVal milliseconds As Int32) As Boolean
        Return HasTerminateRequest(milliseconds)
    End Function

    Public Overridable Sub Interrupt()
        ' do not use this
    End Sub

    Public Overridable Sub Abort()
        ' do not use this
    End Sub
End Class
