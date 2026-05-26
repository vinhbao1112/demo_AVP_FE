Imports System
Imports System.Threading
Imports System.IO
Imports System.Collections
Imports System.Text.RegularExpressions

Public Class MessageManager

    Public Class BlockingQueue(Of T)
        ' Methods
        Public Sub New()
            m_queue = New Queue(Of T)
        End Sub

        Public Function Dequeue() As T
            If m_stopped Then
                Return Nothing
            End If
            SyncLock m_queue
                If m_stopped Then
                    Return Nothing
                End If
                While (m_queue.Count = 0)
                    Monitor.Wait(m_queue)
                    If m_stopped Then
                        Return Nothing
                    End If
                End While
                Return m_queue.Dequeue()
            End SyncLock
        End Function

        Public Function Enqueue(ByVal item As T) As Boolean
            If m_stopped Then
                Return False
            End If
            SyncLock m_queue
                If m_stopped Then
                    Return False
                End If
                m_queue.Enqueue(item)
                Monitor.Pulse(m_queue)
            End SyncLock
            Return True
        End Function

        Public Function EnqueueButNotDuplicate(ByVal item As T) As Boolean
            If m_stopped Then
                Return False
            End If
            SyncLock m_queue
                If m_stopped Then
                    Return False
                End If
                If m_queue.Contains(item) Then
                    Return False
                End If
                m_queue.Enqueue(item)
                Monitor.Pulse(m_queue)
            End SyncLock
            Return True
        End Function

        Public Sub Clear()
            SyncLock m_queue
                m_queue.Clear()
            End SyncLock
        End Sub

        Public Function ToArray() As T()
            SyncLock m_queue
                Return m_queue.ToArray
            End SyncLock
        End Function

        Public ReadOnly Property Count() As Integer
            Get
                SyncLock m_queue
                    Return m_queue.Count
                End SyncLock
            End Get
        End Property

        Public Sub [Stop]()
            If Not m_stopped Then
                SyncLock m_queue
                    If Not m_stopped Then
                        m_stopped = True
                        Monitor.PulseAll(m_queue)
                    End If
                End SyncLock
            End If
        End Sub

        ' Fields
        Private ReadOnly m_queue As Queue(Of T)
        Private m_stopped As Boolean
    End Class

    Public Shared m_StatusManager As StatusManager

    Private Shared m_blnIsReceiving As Boolean
    Private Shared m_blnIsSending As Boolean
    Private Shared m_blnIsProcessing As Boolean
    Private Shared m_blnIsAlarm As Boolean = True
    Private Shared m_blnIsProcessingAlarm As Boolean = False

    Private Shared m_queReceivedMessages As Queue = New Queue()
    Private Shared m_queRequestMessages As BlockingQueue(Of String) = New BlockingQueue(Of String)()
    Private Shared m_queReceivedAlarm As BlockingQueue(Of String) = New BlockingQueue(Of String)()

#Region "Properties"
    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property IsAlarm() As Boolean
        Get
            Return m_blnIsAlarm
        End Get
        Set(ByVal value As Boolean)
            m_blnIsAlarm = value
        End Set
    End Property
#End Region

#Region "Public Shared Methods"

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Process recived message 
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub ProcessMessageProc()
        AVPLib.Log.guiLogger.Info("Enter ProcessMessageProc")
        Try
            AVPLib.Log.schedulerLogger.Debug("ProcessMessageProc : A NEW THREAD BORN FOR PROCESSING MESSAGES.")
            Dim strMessage As String = ""
            While m_blnIsProcessing
                Dim blnIsMessageEmpty As Boolean = True
                SyncLock m_queReceivedMessages.SyncRoot
                    If (m_queReceivedMessages.Count > 0) Then
                        strMessage = CType(m_queReceivedMessages.Dequeue(), String)
                        blnIsMessageEmpty = False
                    End If
                End SyncLock
                If blnIsMessageEmpty Then
                    Thread.Sleep(200)
                Else
                    m_StatusManager.ChangeStatus(strMessage)
                End If
            End While
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.schedulerLogger.Debug("ProcessMessageProc : THE THREAD PROCESSING MESSAGES IS OVER.")
        AVPLib.Log.guiLogger.Info("Leave ProcessMessageProc")
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' AddAlarm
    ''' </summary>
    ''' <param name="sMessageLine"></param>
    ''' <remarks></remarks>
    Public Shared Sub AddAlarm(ByVal sMessageLine As String)
        AVPLib.Log.guiLogger.Info("Enter AddAlarm")
        AVPLib.Log.guiLogger.Debug("sMessageLine=" + sMessageLine)

        Dim strAlarmSeprator As String = AVPLib.ConstEnum.GemAlarmSeperatorString
        Dim idxAlarmName As Integer = sMessageLine.LastIndexOf(strAlarmSeprator)
        Dim strGemAlarmName As String = String.Empty
        If idxAlarmName > 0 Then
            strGemAlarmName = sMessageLine.Substring(idxAlarmName + strAlarmSeprator.Length).Trim()
            sMessageLine = sMessageLine.Substring(0, idxAlarmName)
        End If

        Dim idxFirstSpace = sMessageLine.IndexOf(" ")
        Dim strActionCode As String = sMessageLine.Substring(0, idxFirstSpace)
        Dim strActionValue As String = sMessageLine.Substring(idxFirstSpace + 1, sMessageLine.Length - strActionCode.Length - 1)
        Dim strAlarmText As String = AVPLib.ContainerData.GetMessageText(strActionValue)
        Dim strSource As String = String.Empty
        '#05/06/2011 
        '#AVP Datalog.  Source of alarm/event is not correct.  The source of this alarm should be PM2 not GUI.
        '#Begin fix:
        Try
            strSource = strActionValue.Substring(0, strActionValue.IndexOf(" "))
            strSource = strSource.Replace(":", "")
            ''#05/11/2011 
            '#Fix: Source log wrong.
            '#Begin fix: Filter source log. Just only source exist in list of equipment.
            '#Note: temporary fix. Need to create a struct to store source and content of message. 
            Dim strFilter = String.Empty
            strFilter = AVPLib.Utils.chamberName2ChamberID(strSource)
            If AVPLib.Utils.CheckSourceLogIsAEquipment(strFilter) = False Then
                strSource = AVPLib.ContainerData.LogSource.AVPMainScreen
            End If
            'End fix

            If strSource.Contains(ConstantAndEnum.LOAD_LOCK_A) Then
                strSource = AVPLib.Utils.chamberID2ChamberName(strSource)
            End If
        Catch ex As Exception
            strSource = AVPLib.ContainerData.LogSource.AVPMainScreen
        End Try
        '#End fix
        If String.IsNullOrEmpty(strGemAlarmName) Then
            strGemAlarmName = AVPLib.Utils.GemGetAlarmName(strSource)
        End If

        If String.IsNullOrEmpty(strAlarmText) Then
            strAlarmText = strActionValue
        End If
        Dim strQueuedMsg As String = MessageMapper.GetGuiElement(strActionCode) & " " & strAlarmText
        ' Turn On Alarm Light.
        AVPLib.Utils.TurnAlarm_RedLightOnOff(False, , AVPLib.System_Shutdown_Indicator.IsMainFormClosing)
        If m_queReceivedAlarm.EnqueueButNotDuplicate(strQueuedMsg) Then
            '#05/23/2011 
            '#-	Redundancy.. … PM5 …. PM5….     PM5 in message string need to be remove
            '#Begin fix: If source is equipment, remove equipment from text alarm.
            If strSource <> AVPLib.ContainerData.LogSource.AVPMainScreen AndAlso Not strAlarmText.Contains(ConstantAndEnum.CANNOT_TRANSFER_WAFER) Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeAlarm, strSource, Regex.Match(strAlarmText, "[^ ]+\s+(.*)").Groups(1).Value, strGemAlarmName)
            Else
                '#End fix.
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeAlarm, strSource, strAlarmText, strGemAlarmName)
            End If

        End If
            AVPLib.Log.guiLogger.Info("Leave AddAlarm")
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' AddMessage
    ''' </summary>
    ''' <param name="sMessageLine"></param>
    ''' <remarks></remarks>
    Public Shared Sub AddMessage(ByVal sMessageLine As String, ByVal ChamberName As String)
        AVPLib.Log.guiLogger.Info("Enter AddMessage")
        AVPLib.Log.guiLogger.Info("sMessageLine=" + sMessageLine)
        SyncLock m_queReceivedMessages.SyncRoot
            sMessageLine = MessageMapper.Parse(sMessageLine) 'sMessageLine like PVD.ProcessMonitor.txtWaferID Off

            Dim strRegExp As String = "([^ ]+)\s+(.*)"
            Dim mtcMatch As Text.RegularExpressions.Match = Regex.Match(sMessageLine, strRegExp)
            If (mtcMatch IsNot Nothing) And (mtcMatch.Groups.Count >= 2) Then
                Dim sMessageControl = mtcMatch.Groups(1).Value
                Dim sMessageValue = mtcMatch.Groups(2).Value
                If sMessageControl.StartsWith(AVPLib.ConstEnum.PVD4) Or
             sMessageControl.Contains("CassettesPanel") And sMessageControl.Contains(AVPLib.ConstEnum.PVD4) Or
             sMessageControl.Contains("ProcessPanel") And sMessageControl.Contains(AVPLib.ConstEnum.PVD4) Then
                    sMessageControl = AVPLib.Utils.ReplaceFirstOccurence(sMessageControl, AVPLib.ConstEnum.PVD4, ChamberName)

                ElseIf sMessageControl.StartsWith(AVPLib.ConstEnum.PVD5T) Or
                    sMessageControl.Contains("CassettesPanel") And sMessageControl.Contains(AVPLib.ConstEnum.PVD5T) Or
                    sMessageControl.Contains("ProcessPanel") And sMessageControl.Contains(AVPLib.ConstEnum.PVD5T) Then

                    sMessageControl = AVPLib.Utils.ReplaceFirstOccurence(sMessageControl, AVPLib.ConstEnum.PVD5T, ChamberName)

                ElseIf sMessageControl.StartsWith(AVPLib.ConstEnum.STR_IBE) Or _
                  sMessageControl.Contains("CassettesPanel") And sMessageControl.Contains(AVPLib.ConstEnum.STR_IBE) Or _
                  sMessageControl.Contains("ProcessPanel") And sMessageControl.Contains(AVPLib.ConstEnum.STR_IBE) Then
                    sMessageControl = AVPLib.Utils.ReplaceFirstOccurence(sMessageControl, AVPLib.ConstEnum.STR_IBE, ChamberName)

                ElseIf sMessageControl.StartsWith(AVPLib.ConstEnum.PVD) Or _
                           sMessageControl.Contains("CassettesPanel") And sMessageControl.Contains(AVPLib.ConstEnum.PVD) Or _
                           sMessageControl.Contains("ProcessPanel") And sMessageControl.Contains(AVPLib.ConstEnum.PVD) Then
                    sMessageControl = AVPLib.Utils.ReplaceFirstOccurence(sMessageControl, AVPLib.ConstEnum.PVD, ChamberName)

                End If
                sMessageLine = sMessageControl & " " & sMessageValue

            Else '''maybe unuse, just in case
                If sMessageLine.StartsWith(AVPLib.ConstEnum.PVD) Or _
             sMessageLine.Contains("CassettesPanel") And sMessageLine.Contains(AVPLib.ConstEnum.PVD) Or _
             sMessageLine.Contains("ProcessPanel") And sMessageLine.Contains(AVPLib.ConstEnum.PVD) Then
                    sMessageLine = AVPLib.Utils.ReplaceFirstOccurence(sMessageLine, AVPLib.ConstEnum.PVD, ChamberName)

                ElseIf sMessageLine.StartsWith(AVPLib.ConstEnum.STR_IBE) Or _
                  sMessageLine.Contains("CassettesPanel") And sMessageLine.Contains(AVPLib.ConstEnum.STR_IBE) Or _
                  sMessageLine.Contains("ProcessPanel") And sMessageLine.Contains(AVPLib.ConstEnum.STR_IBE) Then
                    sMessageLine = AVPLib.Utils.ReplaceFirstOccurence(sMessageLine, AVPLib.ConstEnum.STR_IBE, ChamberName)
                End If

            End If
            If Not String.IsNullOrEmpty(sMessageLine) Then
                m_queReceivedMessages.Enqueue(sMessageLine)
            End If

        End SyncLock
        AVPLib.Log.guiLogger.Info("Leave AddMessage")
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' ProcessAlarmProc
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub ProcessAlarmProc()
        AVPLib.Log.guiLogger.Info("Enter ProcessAlarmProc")
        Try
            AVPLib.Log.schedulerLogger.Debug("ProcessAlarmProc : A NEW THREAD BORN FOR PROCESSING ALARMS.")
            Dim strMessage As String = String.Empty
            While m_blnIsProcessingAlarm
                If (IsAlarm) Then
                    IsAlarm = False ' Only Get One Alarm At A Time.
                    strMessage = m_queReceivedAlarm.Dequeue()
                    If Not String.IsNullOrEmpty(strMessage) Then
                        m_StatusManager.ChangeStatus(strMessage)
                    End If
                Else
                    Thread.Sleep(200)
                End If
                
            End While
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.schedulerLogger.Debug("ProcessAlarmProc : THE THREAD PROCESSING ALARMS IS OVER")
        AVPLib.Log.guiLogger.Info("Leave ProcessAlarmProc")
    End Sub

    ''' <author>
    '''     <name> Cao Anh Kiet </name>
    '''     <date> 2008-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Get_RemoveSameAlarm
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub ClearAllAlarms(ByVal bRemoveAll As Boolean)
        AVPLib.Log.guiLogger.Info("Enter RemoveSameAlarm")
        Try
            If (bRemoveAll) Then
                m_queReceivedAlarm.Clear()
                AVPLib.Utils.TurnAlarm_RedLightOnOff(True)
            ElseIf (m_queReceivedAlarm.Count <= 0) Then
                AVPLib.Utils.TurnAlarm_RedLightOnOff(True)
            End If
#If AVP_PLATFORM = "CX" Then
            If AVPLib.ContainerData.SoundOnDuringAlarm AndAlso (bRemoveAll Or m_queReceivedAlarm.Count = 0) Then
                AVPLib.Utils.WriteCommandKepServer("Alarm.AlarmStatus", False)
            End If
#End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave RemoveSameAlarm")
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Send message from this sytem to equipment
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub SendProc()
        AVPLib.Log.guiLogger.Info("Enter SendProc")
        Try
            AVPLib.Log.schedulerLogger.Debug("Message Manager : A NEW THREAD BORN FOR PROCESSING GUI BUSINESS MESSAGES.")
            Dim strMessage As String = String.Empty
            While m_blnIsSending
                strMessage = m_queRequestMessages.Dequeue()
                If Not String.IsNullOrEmpty(strMessage) Then
                    Dim MessageBusiness As String = ContainerData.GetMessageGuiBusiness(strMessage)
                    AVPLib.Log.guiLogger.Warn("strMessage=" & strMessage & " and MessageBusiness=" & MessageBusiness)
                    AVPLib.Business.ControllerManager.DoTask(MessageBusiness)
                End If
            End While
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.schedulerLogger.Debug("Message Manager : THE THREAD PROCESSING GUI BUSINESS MESSAGES IS OVER.")
        AVPLib.Log.guiLogger.Info("Leave SendProc")
    End Sub
#End Region

#Region "Public Shared Methods"
    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Stop receive message
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StopReceive()
        Try
            m_blnIsReceiving = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Start processing messages thread
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StartProcess()
        Try
            Dim trdProcessMessage As New Thread(AddressOf ProcessMessageProc)
            m_blnIsProcessing = True
            trdProcessMessage.Start()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StartProcessAlarm()
        Try
            Dim trdProcessAlarm As New Thread(AddressOf ProcessAlarmProc)
            m_blnIsProcessingAlarm = True
            trdProcessAlarm.Start()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Stop processing messages thread 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StopProcess()
        Try
            m_blnIsProcessing = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' StopProcessAlarm
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StopProcessAlarm()
        Try
            m_queReceivedAlarm.Stop()
            m_blnIsProcessingAlarm = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Start thread send message from queue
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StartSend()
        Try
            Dim trdSend As New Thread(AddressOf SendProc)
            m_blnIsSending = True
            trdSend.Start()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Stop thread send message from queue
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StopSend()
        Try
            m_queRequestMessages.Stop()
            m_blnIsSending = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Add request status message to queue
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub AddRequestMessage(ByVal strMessage As String)
        AVPLib.Log.guiLogger.Info("Enter AddRequestMessage")
        AVPLib.Log.guiLogger.Warn("Parameter: strMessage = " & strMessage)
        Try
            m_queRequestMessages.Enqueue(strMessage)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave AddRequestMessage")
    End Sub

    ''' <author>
    '''     <name> Dat Cao </name>
    '''     <date> 2011-07-05</date>
    ''' </author>
    ''' <summary>
    ''' Check Alarm existed in Module 
    ''' </summary>
    ''' <remarks>strModuleName = LLA,LLB,PM1,...PM6,TM,GUI,Other</remarks>

    ''' Remember: need to review to remove this function - Hoa Nguyen  
    Public Shared Function CheckExistedAlarmNotIsInterlock(ByVal CurrentAlarmText As String) As Boolean
        AVPLib.Log.guiLogger.Info("Enter Check Alarm")
        Try
            Dim arrayAlarm() As String
            If (m_queReceivedAlarm.Count > 0) Then
                arrayAlarm = m_queReceivedAlarm.ToArray()
                Dim alarmText As String = String.Empty
                For Each Item As String In arrayAlarm
                    ''not Interlock Alarm and not currentAlarmText
                    If Not (alarmText.Contains("Interlock") AndAlso alarmText.Contains("Is Not ON.")) AndAlso _
                        (alarmText <> CurrentAlarmText) Then
                        Return True
                    End If
                Next
            End If
            Return False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
        AVPLib.Log.guiLogger.Info("Leave Check Alarm")
    End Function

    ''' <author>
    '''     <name> Hoa Nguyen </name>
    '''     <date> 2011-07-19</date>
    ''' </author>
    ''' <summary>
    ''' Check Alarm that can clear SLSystemAlarm.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function CheckConditionForClearAlarm() As Boolean
        AVPLib.Log.guiLogger.Info("Enter CheckConditionForClearAlarm")
        Try
            If m_queReceivedAlarm.Count = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
        AVPLib.Log.guiLogger.Info("LeaveCheckConditionForClearAlarm")
    End Function
#End Region
End Class
