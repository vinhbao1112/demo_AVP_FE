Imports System.Threading

Namespace DeviceNet
    Public Enum CondResult
        [Error] = -1
        [False] = 0
        [True] = 1
    End Enum

    Public Class DeviceNetThread
        Inherits SuspendableThread
        Implements IDisposable
        ' Fields
        Private m_strWhoAmI As String
        Private m_blDisposed As Boolean = False
        Private m_blStarted As Boolean = False

        ' Methods
        Public Sub New(ByVal pstrWhoAmI As String)
            If pstrWhoAmI IsNot Nothing Then
                m_strWhoAmI = pstrWhoAmI
                If m_strWhoAmI.Length = 0 Then
                    m_strWhoAmI = "BaseThread"
                End If
            End If
        End Sub

        Protected Overrides Sub Finalize()
            Debug.Fail("You forgot to Dispose this instance: " & m_strWhoAmI)
            Dispose(False)
        End Sub

        Protected Overrides Sub OnDoWork()
            m_blStarted = True
            Dim name As String = Thread.CurrentThread.Name
            AVPLib.Log.coreLogger.Debug("Starting the thread " & name & " for the component " & m_strWhoAmI)
            Try
                ThreadMainRoutine()
            Finally
                m_blStarted = False
            End Try
            AVPLib.Log.coreLogger.Debug("The thread " & name & " ended")
        End Sub

        ' Override these methods in derive classes.-----------------------------------------------------
        Protected Overridable Sub ThreadMainRoutine()
            Throw New Exception("The method or operation is not implemented.")
        End Sub
        '-----------------------------------------------------------------------------------------------

        ' Call this function and wait for it stops completely.
        Public Function [Stop]() As Boolean
            If m_blStarted Then
                TerminateAndWait()
            End If
            Return True
        End Function

        Public Function Run() As Boolean
            If Not m_blStarted Then
                Start()
                Return True
            End If
            Return False
        End Function

        ''' <summary>
        ''' Thread is stopped or not
        ''' </summary>
        ''' <returns></returns>
        Public Function IsStopped() As Boolean
            Return (False = m_blStarted)
        End Function

    End Class
End Namespace
