Imports AVPLib.DataManagerment
Imports AVPLib.ConstEnum
Imports System.IO
Imports System.Xml

Namespace Business
    Public Class ChamberRoutineExecutor
        Inherits SuspendableThread

        Protected m_eActiveRoutine As RoutineType
        Protected m_strCurrentEQName As String

        Private m_iSampleTime As Int32 = 1 ' default interval : 1 second.
        Private m_iWaitTime As Int32 = 1  ' default recording time : 1 minute.
        Private m_strDescription As String = String.Empty

        Private m_lpdcStartTickCount As Long = Environment.TickCount
        Protected m_pdcTimer As System.Timers.Timer = Nothing

        ' Event will be fired once 1 sample is collected
        Public Event OnDataCollect As DataCollectEvent

        Public Sub RaiseDataSample(ByVal Type As RoutineType, ByVal RemainingTimeSecsNo As Integer, ByVal SecsNo As Integer, ByVal Value As Double)
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrValues As New ArrayList()

                If Type = RoutineType.RecoverPressure Then
                    arrPropertyNames.Add("Recover_Pressure_Sample")
                    arrValues.Add("RemainingTime=" & RemainingTimeSecsNo.ToString() & "#Time=" & SecsNo.ToString() & "#Pressure=" & Value.ToString() & "#") '"Time=1#IG=1.000E-005#"
                End If

                EquipmentManager.ChangeStatus(m_strCurrentEQName, arrPropertyNames, arrValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Private Sub RaiseOnOffEvent(ByVal Type As RoutineType, ByVal OnOffEvent As Equipment.WorkingStatuses)
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrValues As New ArrayList()
                If Type = RoutineType.RecoverPressure Then
                    arrPropertyNames.Add("Recover_Pressure_Status")
                End If
                arrValues.Add(OnOffEvent)
                EquipmentManager.ChangeStatus(m_strCurrentEQName, arrPropertyNames, arrValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Private Sub CreateFileName(ByVal type As RoutineType)
            Try
                Dim arrPropertyNames As New ArrayList()
                Dim arrValues As New ArrayList()
                Dim dtPDC As DateTime = DateTime.Now
                Dim strPDCXmlFile As String = dtPDC.ToString("yy-MM-dd_HH_mm_ss") & ".xml"
                If type = RoutineType.RecoverPressure Then
                    arrPropertyNames.Add("Recover_Pressure_FileName")
                End If
                arrValues.Add(strPDCXmlFile)
                EquipmentManager.ChangeStatus(m_strCurrentEQName, arrPropertyNames, arrValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Public Property SampleTime() As Integer
            Get
                Return m_iSampleTime
            End Get
            Set(ByVal value As Integer)
                m_iSampleTime = value
            End Set
        End Property

        Public Property WaitTime() As Integer
            Get
                Return m_iWaitTime
            End Get
            Set(ByVal value As Integer)
                m_iWaitTime = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set
        End Property

        Public Property ActiveRoutine() As RoutineType
            Get
                Return m_eActiveRoutine
            End Get

            Set(ByVal value As RoutineType)
                m_eActiveRoutine = value
            End Set
        End Property

        ' Constructor
        Public Sub New(ByVal ChamberName As String)
            m_strCurrentEQName = ChamberName
        End Sub

        ' Run when calling Start Method
        Protected Overrides Sub OnDoWork()
            If (m_eActiveRoutine = RoutineType.RecoverPressure) Then
                Me.RunRecoverPresure()
                RaiseOnOffEvent(RoutineType.RecoverPressure, Equipment.WorkingStatuses.Off)
            End If
        End Sub

#Region "FLOW CONTROL"
        Private Function RunRecoverPresure() As Boolean
            ' Start Recover Pressure           
            Dim span As New TimeSpan(0, WaitTime, 0)
            Dim rorStartTickCount As Int64 = Environment.TickCount
            Try
                'max sample count
                Dim maxLoopCount As Integer = (WaitTime * 60) / SampleTime
                'start with one sample
                Dim iLoopCount As Integer = 0

                RaiseOnOffEvent(RoutineType.RecoverPressure, Equipment.WorkingStatuses.On)
                CreateFileName(RoutineType.RecoverPressure)
                While Not HasTerminateRequest()
                    Dim tick As Integer = Environment.TickCount
                    ' Record Recover Samples to a file
                    Dim rorSpan As TimeSpan = TimeSpan.FromMilliseconds(Utils.GetTickCountDelta(rorStartTickCount))
                    Dim objPM As DataManagerment.Chamber = EquipmentManager.GetEquipment(Me.m_strCurrentEQName)
                    Dim dblPressure As Double = 0
                    If objPM.IGStatus = Equipment.WorkingStatuses.On Then
                        dblPressure = objPM.IG
                    Else
                        dblPressure = objPM.CG
                    End If

                    'and notify to caller also.
                    Dim remainingTimeInSecs As Integer = (WaitTime * 60) - rorSpan.TotalSeconds
                    Me.RaiseDataSample(RoutineType.RecoverPressure, remainingTimeInSecs, rorSpan.TotalSeconds, dblPressure)

                    'increase loop count
                    iLoopCount += 1
                    If iLoopCount > maxLoopCount Then
                        AVPLib.Log.coreLogger.Debug("Done  Recover Pressure Sampling, Sample time=" & span.TotalSeconds.ToString() & "Secs.")
                        Return True
                    End If
                    Dim delta As Integer = Utils.GetTickCountDelta(tick)
                    If Me.SleepButAlertabletoTerminateRequest(Me.SampleTime * 1000 - delta) Then
                        AVPLib.Log.coreLogger.Error("Error, in stopping mode")
                        Return False
                    End If

                End While
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
            Return False
        End Function
#End Region

    End Class

End Namespace



