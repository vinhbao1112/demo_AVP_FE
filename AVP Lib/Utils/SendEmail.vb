Imports System.Net.Mail
Public Class SendEmail

    Private Shared m_Instance As SendEmail
    Private m_AutoSendMail As Boolean = False
    Private m_SMTPServer As String = String.Empty
    Private m_PortID As Integer = 465 'or 587
    Private m_UserName As String = String.Empty
    Private m_Password As String = String.Empty
    Private m_Key4Password As String = "abcd1234"
    Private m_HashTriggers As Hashtable = New Hashtable()

    Private SmtpClient As System.Net.Mail.SmtpClient = Nothing
    Private TimerPressure As Timers.Timer
    Private objLockMail As New Object

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' AutoSendMail
    ''' </summary>
    Public Property AutoSendMail() As Boolean
        Get
            Return m_AutoSendMail
        End Get
        Set(ByVal value As Boolean)
            m_AutoSendMail = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' SMTPServer
    ''' </summary>
    Public Property SMTPServer() As String
        Get
            Return m_SMTPServer
        End Get
        Set(ByVal value As String)
            If m_SMTPServer <> value Then
                m_SMTPServer = value
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' PortID
    ''' </summary>
    Public Property PortID() As Integer
        Get
            Return m_PortID
        End Get
        Set(ByVal value As Integer)
            If m_PortID <> value Then
                m_PortID = value
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' UserName
    ''' </summary>
    Public Property UserName() As String
        Get
            Return m_UserName
        End Get
        Set(ByVal value As String)
            If m_UserName <> value Then
                m_UserName = value
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' Password
    ''' </summary>
    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set(ByVal value As String)
            If m_Password <> value Then
                m_Password = value
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' Key4Password
    ''' </summary>
    Public ReadOnly Property Key4Password() As String
        Get
            Return m_Key4Password
        End Get
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' HashTriggers
    ''' </summary>
    Public ReadOnly Property HashTriggers() As Hashtable
        Get
            Return m_HashTriggers
        End Get
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' Instance
    ''' </summary>
    Public Shared Function Instance() As SendEmail
        If m_Instance Is Nothing Then
            m_Instance = New SendEmail
        End If

        Return m_Instance
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-09 </date>
    ''' </author>
    ''' <summary>
    ''' Initalize
    ''' </summary>
    Public Sub Initalize()
        Try
            TimerPressure = New Timers.Timer
            TimerPressure.Interval = 60000
            TimerPressure.Enabled = AutoSendMail
            AddHandler TimerPressure.Elapsed, AddressOf TimerSendEmailForPressure

            SmtpClient = New System.Net.Mail.SmtpClient()
            SmtpClient.EnableSsl = True
            SmtpClient.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            SmtpClient.Timeout = 20000
            SmtpClient.UseDefaultCredentials = False
            SmtpClient.Host = SMTPServer
            SmtpClient.Port = PortID
            SmtpClient.Credentials = New System.Net.NetworkCredential(UserName, Password)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-07-23 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    Private Sub Send_BG(ByVal objInformationEmail As Object)
        ' Do not access the form's BackgroundWorker reference directly.
        ' Instead, use the reference provided by the sender parameter.
        Try
            Dim objInfoEmail As InformationEmail = CType(objInformationEmail, InformationEmail)

            Dim sFrom As String = UserName
            Dim sAddressTo As String = objInfoEmail.AddressTo
            Dim sSubject As String = objInfoEmail.Subject
            Dim sBody As String = objInfoEmail.Content

            Select Case objInfoEmail.TriggerType
                Case ConstEnum.TriggerType.ALARM
                    For Each element As DictionaryEntry In m_HashTriggers
                        Dim objTriggerEmail As AVPLib.TriggerEmail = element.Value

                        If objTriggerEmail.IsAlarm Then
                            sAddressTo = sAddressTo & objTriggerEmail.Name & ","
                        End If
                    Next

                    sSubject = ConstEnum.TriggerType.ALARM.ToString() & " on " & AVPLib.ContainerData.ToolID
                    sBody = "The Tool " & AVPLib.ContainerData.ToolID & " has alarm " & " "" " & objInfoEmail.Content & " "" "

                Case ConstEnum.TriggerType.SCHEDULER
                    For Each element As DictionaryEntry In m_HashTriggers
                        Dim objTriggerEmail As AVPLib.TriggerEmail = element.Value

                        If objTriggerEmail.IsScheduler Then
                            sAddressTo = sAddressTo & objTriggerEmail.Name & ","
                        End If
                    Next

                    sSubject = ConstEnum.TriggerType.SCHEDULER.ToString() & " on " & AVPLib.ContainerData.ToolID
                    sBody = "The Tool " & AVPLib.ContainerData.ToolID & " has scheduler status " & Chr(13) & " "" " & objInfoEmail.Content & " "" "

                Case ConstEnum.TriggerType.PRESSURE
                    For Each element As DictionaryEntry In m_HashTriggers
                        Dim objTriggerEmail As AVPLib.TriggerEmail = element.Value

                        If objTriggerEmail.IsPressure Then
                            sAddressTo = sAddressTo & objTriggerEmail.Name & ","
                        End If
                    Next

                    sSubject = ConstEnum.TriggerType.PRESSURE.ToString() & " on " & AVPLib.ContainerData.ToolID
                    sBody = "Current pressure on " & AVPLib.ContainerData.ToolID
                    sBody = sBody & Chr(10) & Chr(13) & CollectPressureToMail()

                Case ConstEnum.TriggerType.TESTING

                    sSubject = ConstEnum.TriggerType.TESTING.ToString & " on " & AVPLib.ContainerData.ToolID
                    sBody = "Set up Mail Testing on " & AVPLib.ContainerData.ToolID & " successful!"
                    sAddressTo = UserName & ","

            End Select

            If Not String.IsNullOrEmpty(sAddressTo) Then
                sAddressTo = sAddressTo.Replace(";", ",").Trim()

                Try

                    SyncLock objLockMail
                        UpdateSMTPClient()

                        SmtpClient.Send(sFrom, sAddressTo, sSubject, sBody)
                    End SyncLock

                    If objInfoEmail.TriggerType = ConstEnum.TriggerType.TESTING Then
                        Utils.Create_Core_MessageBox("Sending Successfully")
                        Utils.RaiseEnableDisableButtonToGUI(ConstEnum.Equipments.CassettesModule.ToString(), "TestSetupStatus", True)
                    End If

                Catch ex As System.Net.Mail.SmtpException
                    If objInfoEmail.TriggerType = ConstEnum.TriggerType.TESTING Then
                        Utils.Create_Core_MessageBox("Failed to send Email" & Chr(13) & "Please Check All information above!")
                        Utils.RaiseEnableDisableButtonToGUI(ConstEnum.Equipments.CassettesModule.ToString(), "TestSetupStatus", True)
                    End If

                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "Mail sending error:" & sFrom)
                End Try

            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' UpdateSMTPClient
    ''' </summary>
    Public Sub UpdateSMTPClient()
        Try
            If SmtpClient IsNot Nothing Then
                Dim objCredential As System.Net.NetworkCredential = SmtpClient.Credentials.GetCredential(SMTPServer, PortID, "Basic")

                If SmtpClient.Host <> SMTPServer Then
                    SmtpClient.Host = SMTPServer
                End If

                If SmtpClient.Port <> PortID Then
                    SmtpClient.Port = PortID
                End If

                If objCredential.UserName <> UserName Or objCredential.Password <> Password Then
                    SmtpClient.Credentials = New System.Net.NetworkCredential(UserName, Password)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-10 </date>
    ''' </author>
    ''' <summary>
    ''' AddTriggers
    ''' </summary>
    Public Sub AddTrigger(ByVal key As String, ByVal value As Object)
        Try
            If Not m_HashTriggers.ContainsKey(key) Then
                m_HashTriggers.Add(key, value)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-10 </date>
    ''' </author>
    ''' <summary>
    ''' RemoveTriggers
    ''' </summary>
    Public Sub RemoveTrigger(ByVal key As String)
        Try
            If m_HashTriggers.ContainsKey(key) Then
                m_HashTriggers.Remove(key)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-10 </date>
    ''' </author>
    ''' <summary>
    ''' UpdateTriggers
    ''' </summary>
    Public Sub UpdateTrigger(ByVal key As String, ByVal value As Object)
        Try
            If m_HashTriggers.ContainsKey(key) Then
                m_HashTriggers.Item(key) = value
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-10 </date>
    ''' </author>
    ''' <summary>
    ''' GetTriggers
    ''' </summary>
    Public Function GetTrigger(ByVal key As String) As Object
        Dim strResult As Object = Nothing

        Try
            If m_HashTriggers.ContainsKey(key) Then
                strResult = m_HashTriggers.Item(key)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return strResult
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-08 </date>
    ''' </author>
    ''' <summary>
    ''' Send
    ''' </summary>
    Public Sub Send(ByVal content As String, ByVal triggerType As ConstEnum.TriggerType, _
                    Optional ByVal subject As String = "", Optional ByVal addressTo As String = "")
        Try
            If SmtpClient Is Nothing OrElse (Not m_AutoSendMail) Then
                Return
            End If

            Dim objInfoEmail As InformationEmail = New InformationEmail(addressTo, subject, content, triggerType)
            Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(AddressOf Send_BG), objInfoEmail)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Vu</name>
    '''    	<date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' CollectPressureToMail() collect pressure numbers from all chamber, TM, and LL
    ''' </summary>
    Private Function CollectPressureToMail() As String
        Dim PressureMessages As New Text.StringBuilder
        Try
            'Collect info pressure of TM
            Using ObjTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())
                PressureMessages.AppendLine(ConstEnum.TM_STR & ":" & ObjTM.Pressure.ToString("0.00E+00"))
            End Using

            'Collect info pressure of LLA
            Using ObjLLA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                PressureMessages.AppendLine("LLA:" & ObjLLA.Pressure.ToString("0.00E+00"))
            End Using

            'Collect info pressure of all chambers
            Dim strPressure As String = String.Empty
            For i As Integer = 1 To RobotConfigurationValues.CHAMBERX_VISIBLE.Count
                Dim strChamber As String = ConstEnum.Chamber & i.ToString()
                'if Chamber is visible 
                If RobotConfigurationValues.CHAMBERX_VISIBLE(i - 1) = Boolean.TrueString Then
                    Using objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(strChamber)
                        With objChamber
                            If .IGStatus = DataManagerment.Equipment.WorkingStatuses.On Then
                                strPressure = AVPLib.Utils.chamberID2ChamberName(strChamber) & ": " & .IG.ToString("0.00E+00")
                            Else
                                strPressure = AVPLib.Utils.chamberID2ChamberName(strChamber) & ": " & .CG.ToString("0.00E+00")
                            End If
                        End With
                        PressureMessages.AppendLine(strPressure)
                    End Using
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        ' end funtions
        Return PressureMessages.ToString()
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-09 </date>
    ''' </author>
    ''' <summary>
    ''' TimerSendEmailForPressure
    ''' </summary>
    Private Sub TimerSendEmailForPressure(ByVal source As Object, ByVal e As Timers.ElapsedEventArgs)
        Try
            For Each element As DictionaryEntry In m_HashTriggers
                Dim objTriggerEmail As AVPLib.TriggerEmail = element.Value

                objTriggerEmail.PressureCount += 1
                If objTriggerEmail.IsPressure AndAlso objTriggerEmail.PressureCount >= objTriggerEmail.PressureInterval Then
                    Send("", ConstEnum.TriggerType.PRESSURE)
                    objTriggerEmail.PressureCount = 0
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' ResetTimerPressure
    ''' </summary>
    Public Sub ResetTimerPressure(ByVal isAutoSendMail As Boolean)
        Try
            If isAutoSendMail Then
                m_AutoSendMail = True
                TimerPressure.Enabled = True
            Else
                m_AutoSendMail = False
                TimerPressure.Enabled = False
                For Each element As DictionaryEntry In m_HashTriggers
                    Dim objTriggerEmail As AVPLib.TriggerEmail = element.Value

                    objTriggerEmail.PressureCount = 0
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Vu</name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' ValidateEmail
    ''' </summary>
    Public Function ValidateEmail(ByVal email As String) As Boolean
        Dim check As Boolean

        Try
            Static emailExpression As New Text.RegularExpressions.Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@" & _
                "(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+([a-zA-Z]{2,9})$")

            check = emailExpression.IsMatch(email)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return check
    End Function

    ''' <author>
    '''    	<name> Tin Vu</name>
    '''    	<date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' UnInitalize() dispose all
    ''' </summary>
    Public Sub UnInitalize()
        Try
            'save email config to file config
            AVPLib.ContainerData.SaveConfigMail()

            m_HashTriggers.Clear()
            TimerPressure.Dispose()
            SmtpClient = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class

Public Class InformationEmail

    Public AddressTo As String = String.Empty
    Public Subject As String = String.Empty
    Public Content As String = String.Empty
    Public TriggerType As ConstEnum.TriggerType

    Public Sub New(ByVal strAddressTo As String, ByVal strSubject As String, _
                   ByVal strContent As String, ByVal enumTriggerType As ConstEnum.TriggerType)
        AddressTo = strAddressTo
        Subject = strSubject
        Content = strContent
        TriggerType = enumTriggerType
    End Sub

End Class
