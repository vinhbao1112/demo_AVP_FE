Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Imports System.Runtime.InteropServices
Imports AVPControls

Public Class AVPRobotMain

#Region "Class Constants & Variables"
    Public Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)

    Public Declare Function GetCursorPos Lib "user32" (ByRef lpPoint As Point) As Int32
    Private m_StatusManager As StatusManager
    Private m_trdBusiness As Threading.Thread
    Const Running As String = "Running"
    Const Idle As String = "Idle"
    Const ButtonSize As Integer = 110
    Private m_intRecipeClick As Integer = 0
    'Private m_blnIsMainFormInitialize As Boolean = False
    'Private m_blnIsMainFormClosing As Boolean = False

    'Dat Cao 
    Public m_systemStatus As SystemStatus = SystemStatus.None
    Private m_sysIdle_Count As Integer = -1
    Private m_idleTime As Double = 0 'Dat Cao hard code to test here
    Private m_LoginDialog As Login = Nothing
    Public m_Cursor_Pos As Point
    Private m_isInitSuccess As Boolean = False
    Private m_maxChamber2Installed As Integer = 0

    Private m_blnOnlineRemote As Boolean = False
    Private m_blnOnlineLocal As Boolean = False
    Private m_blnOfflineLocal As Boolean = False
    Private m_blnIsFolderExists As Boolean = False
    Private Delegate Sub UpdateArchiveStatusValue(ByVal objDateTime As Object, ByVal objStatus As Object, ByVal msg As String)
    Public Delegate Sub UpdatePressureValue(ByVal obj As Object)

    Public Enum SystemStatus
        [Idle] = 0 'ex: after 30' system goto Idle 
        [Running] = 1 ' system is running
        [None] = 2 'other
    End Enum

    Public Enum SystemScreens
        ProcessScreen
        CassetteScreen
        SetupScreen
        EditorScreen
        DatalogScreen
        PM1Screen
        PM2Screen
        PM3Screen
        TMScreen
        AlignerScreen
        GEMScreen
        CycelATM

    End Enum

    Private m_frmSplashScreen As AVPControls.SplashScreen
    Private m_blnSystemRunning As Integer
    Private m_lock As Object = New Object()
    Private m_arrOfLocation As New List(Of Point)
    Private m_arrOfButton As New List(Of RectButton)
    Private m_intLengthOfShift As Integer = 0
    Private m_MaintenanceClick As String = String.Empty
    Private m_EditorClick As String = String.Empty
    Private m_DataLogClick As String = String.Empty
    Private m_SetupClick As String = String.Empty

    Private m_tmrDeleteLogFile As System.Timers.Timer
    Private m_blnIsDeleteLog As Boolean = False
    Private m_blnIsCopyConfigFile As Boolean = False
    Private m_tabIODeviceNet As IOTab = Nothing

    Const ONE_HOUR_TICK_COUNT As Integer = 3600000 ''1H * 60 * 60 * 1000
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function PostMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
    End Function
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Public Declare Function FindWindowEx Lib "user32" (ByVal hWnd1 As Long, ByVal hWnd2 As Long, ByVal lpsz1 As String, ByVal lpsz2 As String) As Long


    Public Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal hWnd As Integer, ByVal Msg As Integer, ByVal ByValwParam As Integer, ByVal lParam As String) As Integer
    'Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    Private Const SC_CLOSE = &HF060
    Public Const WM_SYSCOMMAND = &H112
    Protected m_marshaller As DelegateMarshaler


#End Region

#Region "Properties"
    Public Property AdminAutologOffTime() As Double
        Get
            Return m_idleTime
        End Get
        Set(ByVal value As Double)
            m_idleTime = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-03-17</date>
    ''' </author>
    ''' <summary>
    ''' TabIODeviceNetControl
    ''' </summary>
    Public ReadOnly Property TabIODeviceNetControl() As IOTab
        Get
            If m_tabIODeviceNet Is Nothing Then
                m_tabIODeviceNet = New IOTab(AVPLib.Driver.DriverManager.ListAllDevice)
                m_tabIODeviceNet.TopLevel = False
                m_tabIODeviceNet.Dock = DockStyle.Fill
            End If
            Return m_tabIODeviceNet
        End Get
    End Property
#End Region

#Region "Constructors & Dispose"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Initialize main form
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            aplAlarm.ManagedAlarmLabel = Me.lblAlarmTextMain
            m_StatusManager = New StatusManager()
            m_LoginDialog = New Login()

            m_tmrDeleteLogFile = New System.Timers.Timer
            m_tmrDeleteLogFile.Interval = ONE_HOUR_TICK_COUNT
            m_tmrDeleteLogFile.Enabled = True
            AddHandler m_tmrDeleteLogFile.Elapsed, AddressOf DeleteFileLogAndDataRun
            m_marshaller = DelegateMarshaler.Create()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "public method"
    Public ReadOnly Property MaxChamber2Install() As Integer
        Get
            Return m_maxChamber2Installed
        End Get
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-22 </date>
    ''' </author>
    ''' <summary>
    ''' Get, Set SECS/GEM status
    ''' </summary>
    ''' <remarks></remarks>
    Public Property OnlineRemote() As Boolean
        Get
            Return m_blnOnlineRemote
        End Get
        Set(ByVal value As Boolean)
            m_blnOnlineRemote = value
            If value Then
                m_blnOfflineLocal = False
                m_blnOnlineLocal = False
                Me.AVPCommunicationPanel.HostStatus = ConstantAndEnum.STRING_ONLINE
                Me.AVPCommunicationPanel.HostMode = ConstantAndEnum.STR_REMOTE
                ContainerForm.RecipeEditor.CheckPermission()
                ContainerForm.Sequence.CheckPermission()
                ContainerForm.WaferFlow.CheckPermission()
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-22 </date>
    ''' </author>
    ''' <summary>
    ''' Get, Set SECS/GEM status
    ''' </summary>
    ''' <remarks></remarks>
    Public Property OnlineLocal() As Boolean
        Get
            Return m_blnOnlineLocal
        End Get
        Set(ByVal value As Boolean)
            m_blnOnlineLocal = value
            If value Then
                m_blnOfflineLocal = False
                m_blnOnlineRemote = False
                Me.AVPCommunicationPanel.HostStatus = ConstantAndEnum.STRING_ONLINE
                Me.AVPCommunicationPanel.HostMode = ConstantAndEnum.STR_LOCAL
                ContainerForm.RecipeEditor.CheckPermission()
                ContainerForm.Sequence.CheckPermission()
                ContainerForm.WaferFlow.CheckPermission()
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-22 </date>
    ''' </author>
    ''' <summary>
    ''' Get, Set SECS/GEM status
    ''' </summary>
    ''' <remarks></remarks>
    Public Property OfflineLocal() As Boolean
        Get
            Return m_blnOfflineLocal
        End Get
        Set(ByVal value As Boolean)
            m_blnOfflineLocal = value
            If value Then
                m_blnOnlineLocal = False
                m_blnOnlineRemote = False
                Me.AVPCommunicationPanel.HostStatus = ConstantAndEnum.STRING_OFFLINE
                Me.AVPCommunicationPanel.HostMode = ConstantAndEnum.STR_LOCAL
                ContainerForm.RecipeEditor.CheckPermission()
                ContainerForm.Sequence.CheckPermission()
                ContainerForm.WaferFlow.CheckPermission()
            End If
        End Set
    End Property

#End Region

#Region "Protected Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Stop receive message thread before exit
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            ' Update license registry key
            Dim strLastRunDate As String = String.Empty
            If Utils.Read_MarkedRegistry(strLastRunDate) Then
                Utils.UpdateRegitryIfCan(strLastRunDate)
            End If

            Try
                '0008959: [KhoiHa - 04/17/2015] [CX7#2]AVP.exe still exist after shutdown application.
                ExitGEM()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.System_Shutdown_Indicator.IsMainFormClosing = True

            TurnOffSystemLightWhenExit()

            MessageManager.StopSend()
            MessageManager.StopProcess()
            MessageManager.StopProcessAlarm()
            aplAlarm.EndProgram()
            Me.pnlRedLight.EndProgram()

            If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT > TWOLIGHTALARM Then
                Me.pnlGreenLight.EndProgram()
            End If

            If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT >= THREELIGHTALARM Then
                Me.pnlYellowLight.EndProgram()
            End If

            If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = FOURLIGHTALARM Then
                Me.pnlBlueLight.EndProgram()
            End If

            Dim exitFrm As New ExitFrm
            exitFrm.ShowDialog()

            If m_trdBusiness IsNot Nothing Then
                m_trdBusiness.Abort()
            End If

            AVPLib.Log.shutdown()

            ' UnInitalize Email
            AVPLib.SendEmail.Instance.UnInitalize()

            Me.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Truc Lee </name>
    '''    	<date> 2015-04-21</date>
    ''' </author>
    ''' <summary>
    ''' Exit SECS/GEM
    ''' </summary>
    Private Sub ExitGEM()
        Try
            Try
                Dim objLoadLockA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())

                If objLoadLockA IsNot Nothing Then
                    objLoadLockA.LotID = ContainerForm.ProcessPanel.lpcLoadLockA.txtLotID.Text
                    objLoadLockA.SequenceID = ContainerForm.ProcessPanel.lpcLoadLockA.SeqID
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            ' Shutdown SECS/GEM first
            ContainerForm.Secs_GemPanel.UnregisterGemHandler()
            AVPLib.Business.AVPSecsGemLib.Dispose() 'Must be disposed before others
        Catch ex As Runtime.InteropServices.COMException
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Catch exs As Exception
            AVPLib.Log.avpLogger.Error(exs.ToString())
        End Try

    End Sub

#End Region

#Region "Private Methods"
    Private Sub TurnOffSystemLightWhenExit()
        Try
            If (AVPLib.RobotConfigurationValues.NUMBER_ACTIVE_LIGHT > TWOLIGHTALARM) Then
                'turn Yellow Light On-> Idle status
                AVPLib.Utils.TurnIdle_YellowLightOnOff(True)
            End If
            'turn off timer if it running when system closing
            If (RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = TWOLIGHTALARM) Then
                AVPLib.Utils.TurnRunning_GreenLight2Off_RGMode(False, False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all status object
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateStatusTree()
        Try
            m_StatusManager.AddChild(ContainerForm.ProcessPanel.Status)
            m_StatusManager.AddChild(ContainerForm.CassettesPanel.Status)
            If ContainerForm.Chamber1Visible Then
                m_StatusManager.AddChild(ContainerForm.Chamber1Panel.Status)
            End If
            If ContainerForm.Chamber2Visible Then
                m_StatusManager.AddChild(ContainerForm.Chamber2Panel.Status)
            End If
            If ContainerForm.Chamber3Visible Then
                m_StatusManager.AddChild(ContainerForm.Chamber3Panel.Status)
            End If
            m_StatusManager.AddChild(ContainerForm.Diagnostic.Status)
            m_StatusManager.AddChild(aplAlarm.Status)
            m_StatusManager.AddChild(pnlPMConnection.Status)
            m_StatusManager.AddChild(ContainerForm.WaferRun.Status)
            m_StatusManager.AddChild(ContainerForm.Lotdatalog.Status)
            m_StatusManager.AddChild(ContainerForm.SystemSetup.Status)
            m_StatusManager.AddChild(ContainerForm.CycleATM.Status)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Load all panel to create Message Manager Tree 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadFirst()
        Try
            ' Lazy Initialization
            ' Dim maxChamber2Installed As Integer
            ''Load alarm image

            Me.StackLight.Type = RobotConfigurationValues.NUMBER_LIGHT_ALARM

            Dim chamber As AVPLib.SystemModule = Nothing

            tabSecsGem.Controls.Add(ContainerForm.Secs_GemPanel)
            If Utils.CheckGemLicense() = False Then
                ContainerForm.Secs_GemPanel.Enabled = False
            End If

            If AVPLib.ContainerDAO.EnableCycleATM() Then
                tabCycleATM.Controls.Add(ContainerForm.CycleATM)
                ContainerForm.CycleATM.CycleATMPanel.LoadGuiFromRobotConfiguration()
            Else
                tabMain.Controls.Remove(tabCycleATM)
            End If

            'default for CX4
            m_maxChamber2Installed = 3

            tabTM.Controls.Add(ContainerForm.CassettesPanel)
            ContainerForm.CassettesPanel.Dock = DockStyle.Fill

            If RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                tabIO.Controls.Add(ContainerForm.TroubleShootPanel)
            Else
                tabIO.Dispose()
            End If

            pnlCenter.Controls.Add(tabMain)
            tabMain.Dock = DockStyle.Fill

            tabRecipe.Controls.Add(ContainerForm.RecipeEditor) ''recipe Editor
            AddHandler ContainerForm.RecipeEditor.Reload_PPRecipeEvent, AddressOf ContainerForm.Secs_GemPanel.LoadRecipePPFileName

            tabWaferFlow.Controls.Add(ContainerForm.WaferFlow)
            AddHandler ContainerForm.WaferFlow.Reload_PPWFEvent, AddressOf ContainerForm.Secs_GemPanel.LoadWaferFlowPPFileName

            tabSequence.Controls.Add(ContainerForm.Sequence)
            AddHandler ContainerForm.Sequence.Reload_PPSequenceEvent, AddressOf ContainerForm.Secs_GemPanel.LoadSequencePPFileName

            pnlCenter.Controls.Add(tabEditor)
            tabEditor.Dock = DockStyle.Fill

            tabSystem.Controls.Add(ContainerForm.SystemSetup)
            tabUserSetup.Controls.Add(ContainerForm.UserSetup)
            pnlCenter.Controls.Add(tabSetup)
            tabSetup.Dock = DockStyle.Fill

            tabDTLog.Controls.Add(ContainerForm.AlarmAndEvent)

            tabWR.Controls.Add(ContainerForm.WaferRun)
            tabAlarmStatistic.Controls.Add(ContainerForm.AlarmStatisticCtrl)
            TabLotDatalog.Controls.Add(ContainerForm.Lotdatalog)
            pnlCenter.Controls.Add(tabDataLog)
            tabDataLog.Dock = DockStyle.Fill
            ''Load chamberpanel
            For i As Integer = 1 To MaxChamber2Install
                Dim strChamberName As String = ConstEnum.Chamber & i.ToString()
                If AVPLib.ContainerData.IsChamberVisible(strChamberName, chamber) Then
                    Dim chamberPanel As ChamberPanel = Nothing
                    chamberPanel = ContainerForm.GetChamberPanel(chamberPanel, strChamberName, chamber)
                    Me.LoadChamberPanel(chamberPanel, strChamberName)
                    'set flag Visible of each chamber
                    If i = 1 Then
                        ContainerForm.Chamber1Visible = True
                        tabPM1.Controls.Add(chamberPanel)
                        tabPM1.Text = chamber.Name
                        ContainerForm.Chamber1Panel.lblChamberType.Text = chamber.Name & " " & chamber.Type.ToString() & OFFLINE_PM
                        ContainerForm.Chamber1Panel.lblChamberType.Tag = chamber.Name & " " & chamber.Type.ToString()
                        Me.pnlPMConnection.PM1Visible = True
                    End If
                    If i = 2 Then
                        ContainerForm.Chamber2Visible = True
                        tabPM2.Controls.Add(chamberPanel)
                        tabPM2.Text = chamber.Name
                        ContainerForm.Chamber2Panel.lblChamberType.Text = chamber.Name & " " & chamber.Type.ToString() & OFFLINE_PM
                        ContainerForm.Chamber2Panel.lblChamberType.Tag = chamber.Name & " " & chamber.Type.ToString()
                        Me.pnlPMConnection.PM2Visible = True
                    End If
                    If i = 3 Then
                        ContainerForm.Chamber3Visible = True
                        tabPM3.Controls.Add(chamberPanel)
                        tabPM3.Text = chamber.Name
                        ContainerForm.Chamber3Panel.lblChamberType.Text = chamber.Name & " " & chamber.Type.ToString() & OFFLINE_PM
                        ContainerForm.Chamber3Panel.lblChamberType.Tag = chamber.Name & " " & chamber.Type.ToString()
                        Me.pnlPMConnection.PM3Visible = True
                    End If
                Else
                    If i = 1 Then
                        tabMain.Controls.Remove(tabPM1)
                        ContainerForm.SystemSetup.SetPM1Enable(False)
                        ContainerForm.SystemSetup.txtTransferPM1.Enabled = False
                    End If
                    If i = 2 Then
                        tabMain.Controls.Remove(tabPM2)
                        ContainerForm.SystemSetup.SetPM2Enable(False)
                        ContainerForm.SystemSetup.txtTransferPM2.Enabled = False
                    End If
                    If i = 3 Then
                        tabMain.Controls.Remove(tabPM3)
                        ContainerForm.SystemSetup.SetPM3Enable(False)
                        ContainerForm.SystemSetup.txtTransferPM3.Enabled = False
                    End If
                End If
            Next
            pnlCenter.Controls.Add(ContainerForm.ProcessPanel)
            tabDiag.Controls.Add(ContainerForm.Diagnostic)

            ContainerForm.SystemSetup.SystemSetupForPM1()
            ContainerForm.SystemSetup.SystemSetupForPM2()
            ContainerForm.SystemSetup.SystemSetupForPM3()
            AVPLib.ContainerData.LoadPMConfig()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#Region "Permission"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Permission AVP Robot
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Permission()
        Try
            If ContainerForm.Chamber1Visible Then
                Me.CheckPermissionOnChamber(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
            End If
            If ContainerForm.Chamber2Visible Then
                Me.CheckPermissionOnChamber(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
            End If
            If ContainerForm.Chamber3Visible Then
                Me.CheckPermissionOnChamber(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
            End If

            ContainerForm.SystemSetup.CheckPermission()
            ContainerForm.UserSetup.CheckPermission()
            ContainerForm.RecipeEditor.CheckPermission()
            ContainerForm.Sequence.CheckPermission()
            ContainerForm.ProcessPanel.CheckPermission()
            ContainerForm.CassettesPanel.CheckPermission()
            ContainerForm.WaferFlow.CheckPermission()
            ContainerForm.WaferRun.CheckPermission()
            ContainerForm.Lotdatalog.CheckPermission()
            ContainerForm.AlarmAndEvent.CheckPermission()
            ContainerForm.AlarmStatisticCtrl.CheckPermission()
            ContainerForm.Diagnostic.CheckPermission()
            ContainerForm.TroubleShootPanel.CheckPermission()
            ContainerForm.Secs_GemPanel.CheckPermission()
            aplAlarm.CheckPermission()
            Me.pnlRedLight.CheckPermission()
            Me.pnlGreenLight.CheckPermission()
            Me.pnlYellowLight.CheckPermission()
            ContainerForm.CycleATM.CheckPermission()

            If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = FOURLIGHTALARM Then
                pnlBlueLight.CheckPermission()
            End If

            If AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_009) Then
                btnClearAllAlarm.Enabled = True
            Else
                btnClearAllAlarm.Enabled = False
            End If
            pnlPMConnection.BringToFront()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' CheckPermissionOnChamber
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckPermissionOnChamber(ByVal ChamberName As String)
        Try
            Select Case ChamberName
                Case Equipments.Chamber1.ToString()
                    ContainerForm.Chamber1Panel.CheckPermission(PERMISSION_001)
                    ContainerForm.Chamber1Panel.Refresh()
                Case Equipments.Chamber2.ToString()
                    ContainerForm.Chamber2Panel.CheckPermission(PERMISSION_001)
                    ContainerForm.Chamber2Panel.Refresh()
                Case Equipments.Chamber3.ToString()
                    ContainerForm.Chamber3Panel.CheckPermission(PERMISSION_001)
                    ContainerForm.Chamber3Panel.Refresh()
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
#End Region

#Region "Events � Buttons � Forms�"
    Private Sub AVPRobotMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'reset Idle
        m_sysIdle_Count = -1

        If (e.Alt) And (e.KeyValue = Keys.F4) Then
            Try

                If Not AVPLib.ContainerData.Permission(PERMISSION_008) Then
                    e.Handled = True
                    Exit Sub
                End If

                If Utils.IsSchedulerRunning() Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                    "[Main Screen]" & " User tries to exit application by press Alt + F4")
                    If Utils.ShowAVPMessageBox("Scheduler is running. Do you really want to exit?", "Exit", _
                       MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                        "[Main Screen]" & " User exit application when scheduler is running")
                        Me.Close()
                    Else
                        e.Handled = True
                    End If
                Else
                    If Utils.ShowAVPMessageBox("Do you really want to quit AVP Application?", "Quit", MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End If
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Handle Load Form Main
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPRobotMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim errorCode = AVPLib.AVPDataLib.Verify()
        'If errorCode <> 0 Then
        '    MessageBox.Show("License is invalid, can not run the application." + Environment.NewLine + "Error code: " + errorCode.ToString())
        '    Me.Dispose()
        '    Exit Sub
        'End If

        'If Not AVPLib.AVPDataLib.IsSecureDllLoaded() Then
        '    MessageBox.Show("License is invalid, can not run the application.")
        '    Me.Dispose()
        '    Exit Sub
        'End If

        ''Check license, use Me.Dispose before exit
        'If Not Utils.UserCanRunApplication() Then
        '    Me.Dispose()
        '    Exit Sub
        'End If

        Try
            ' Maximize this form.
            Me.WindowState = FormWindowState.Maximized
            '
            AVPLib.System_Init_Indicator.IsMainFormInitialize = False
            Me.Hide()
            '  Boolean.TryParse(My.Settings.SERIALIZE_MODE.ToString(), AVPLib.BinarySerialize.SERIALIZE_MODE)

            ' init loggers
            AVPLib.Log.initialize()
            AVPControls.Logger.LogHandler = AVPLib.Log.avpLogger

            '''Fix bug 0000775: [KhoiHa 14-05-2012] - Please logs revision number to when AVP/PVD/IBE/SL startup...
            '''Begin fix
            Dim AVPVersion As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                       "[Main Screen] Starting AVP with version " & AVPVersion.GetName.Version.ToString())
            AVPLib.Log.guiLogger.Info("[Main Screen] Starting AVP with version " & AVPVersion.GetName.Version.ToString())
            '''End fix

            AVPSecsGemLib.AVPSecsGemLog.initialize()
            ' Pump messages.
            Application.DoEvents()

            'Show splash screen.
            EnableControlsWhenInitializationDone(False)
            '
            m_frmSplashScreen = New AVPControls.SplashScreen
            m_frmSplashScreen.SetVersion(AVPVersion)
            m_frmSplashScreen.Show()
            m_frmSplashScreen.BarStatus.PerformStep() '10

            ' Load xml files.
            AVPLib.ContainerData.LoadConfigurationData()
            AVPLib.Business.AVPSecsGemLib.Initialize()
            m_frmSplashScreen.BarStatus.PerformStep() '20

            m_idleTime = AVPLib.ContainerData.SystemIDLE_Time

            Utils.intCleanUpTime = AVPLib.ContainerData.SystemCleanUpTime
            Utils.intMaxDateDataRunDelete = AVPLib.ContainerData.SystemCleanUpDataRunTime()

            ' Create child Panels and check permissions

            ' Pump messages.
            Application.DoEvents()

            AVPLib.DataManagerment.EquipmentManager.Initialize()
            ' Pump messages.
            Application.DoEvents()
            m_frmSplashScreen.BarStatus.PerformStep() '30

            ContainerForm.ProcessPanel.Visible = True
            ContainerForm.CassettesPanel.Visible = True

            LoadFirst()
            Permission()
            m_frmSplashScreen.BarStatus.PerformStep() '40

            Application.DoEvents()
            ' Show ProcessPanel first
            pnlCenter.Controls.Item(ContainerForm.ProcessPanel.Name).BringToFront()
            pnlPMConnection.BringToFront()
            ContainerForm.HandleForm(ContainerForm.ProcessPanel)


            ' Start Alarm Processing
            pnlRedLight.StartAlarm()

            If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT > TWOLIGHTALARM Then
                pnlGreenLight.StartAlarm()
            End If

            If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT >= THREELIGHTALARM Then
                pnlYellowLight.StartAlarm()
            End If

            If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = FOURLIGHTALARM Then
                pnlBlueLight.StartAlarm()
            End If

            ' Create Status objects
            CreateStatusTree()

            ' Pump messages.
            Application.DoEvents()
            '
            MessageManager.m_StatusManager = m_StatusManager
            '
            MessageMapper.Initiate()
            MessageManager.StartProcess()
            MessageManager.StartProcessAlarm()
            MessageManager.StartSend()
            ' Pump messages.
            Application.DoEvents()
            m_frmSplashScreen.BarStatus.PerformStep() '50

            Dim EquipmentElement As DictionaryEntry
            Dim CurrentEquipment As AVPLib.DataManagerment.Equipment
            For Each EquipmentElement In AVPLib.DataManagerment.EquipmentManager.EquipmentList
                CurrentEquipment = CType(EquipmentElement.Value, AVPLib.DataManagerment.Equipment)
                AddHandler CurrentEquipment.StatusChangedEvent, AddressOf Equipment_StatusChanged
                ''raise event on each equipment-> one PM has 2 screen: PumpDownCurve and RateOfRise
                RaiseEventOnEachDialog(CurrentEquipment, ContainerForm.Diagnostic)
            Next EquipmentElement

            ' Pump messages.
            Application.DoEvents()
            m_frmSplashScreen.BarStatus.PerformStep() '60
            ' Initialize Equiment Connections.
            AVPLib.Communication.ConnectionManager.Initialize()

            'Check Kepware installed
            If RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                'register kepserver change event 
                Dim m_kepserver As Communication.KEPServerConnection = _
                         CType(Communication.ConnectionManager.GetConnection(Equipments.KepServer.ToString()), Communication.KEPServerConnection)
                AddHandler m_kepserver.KepServerChangeEvent, AddressOf ContainerForm.TroubleShootPanel.IOScreen_Reload
            End If

            AddHandler Me.pnlRedLight.eShowAlarmLight, AddressOf Me.ShowAlarm
            AddHandler Me.pnlGreenLight.eShowAlarmLight, AddressOf Me.ShowAlarm
            AddHandler Me.pnlYellowLight.eShowAlarmLight, AddressOf Me.ShowAlarm
            AddHandler Me.pnlBlueLight.eShowAlarmLight, AddressOf Me.ShowAlarm
            AddHandler Me.pnlRedLight.eStopAlarmLight, AddressOf Me.StopAlarm
            AddHandler Me.pnlGreenLight.eStopAlarmLight, AddressOf Me.StopAlarm
            AddHandler Me.pnlYellowLight.eStopAlarmLight, AddressOf Me.StopAlarm
            AddHandler Me.pnlBlueLight.eStopAlarmLight, AddressOf Me.StopAlarm

            m_frmSplashScreen.BarStatus.PerformStep() '70
            ' Pump messages.
            Application.DoEvents()
            AVPLib.Communication.TerminalDriver.TSCommandManager.Initialize()
            AVPLib.Communication.TerminalDriver.TransactionManager.CreateTransactionList()
            ' Pump messages.
            Application.DoEvents()
            m_frmSplashScreen.BarStatus.PerformStep() '80
            'Singleton object
            AVPLib.Business.AVPCore.Instance().Initialize()

            tabIODeviceNet.Controls.Add(TabIODeviceNetControl)
            TabIODeviceNetControl.Show()

            ' Pump messages.
            Application.DoEvents()
            'AVPLib.Business.AVPLotDatalog.Initialize()
            'Open 3 logError

            LoadStoreGUI()

            Dim strTailPath As String = String.Empty

            strTailPath = My.Application.Info.DirectoryPath() & TAILFILENAME
            Dim strLogErrorRobotPath As String = My.Application.Info.DirectoryPath() & LOGERROR_ROBOT_PATH
            Dim strLogErrorChamberPath As String = My.Application.Info.DirectoryPath() & LOGERROR_CHAMBER_PATH
            Dim strLogErrorCryOPath As String = My.Application.Info.DirectoryPath() & LOGERROR_CRYO_PATH
            Dim proc As New Process
            If Not (System.IO.File.Exists(strTailPath)) Then
                AVPLib.Log.avpLogger.Error(strTailPath + " does not exist")
            Else
                proc.StartInfo.FileName = strTailPath
                If (AVPLib.Log.terminalServerRobotLogger.IsDebugEnabled) Then
                    proc.StartInfo.Arguments = strLogErrorRobotPath
                    proc.Start()
                    ' Pump messages.
                    Application.DoEvents()
                End If
                If (AVPLib.Log.terminalServerCryoLogger.IsDebugEnabled) Then
                    proc.StartInfo.Arguments = strLogErrorCryOPath
                    proc.Start()
                    ' Pump messages.
                    Application.DoEvents()
                End If
                If (AVPLib.Log.terminalServerChamberLogger.IsDebugEnabled) Then
                    proc.StartInfo.Arguments = strLogErrorChamberPath
                    proc.Start()
                    ' Pump messages.
                    Application.DoEvents()
                End If
            End If
            m_frmSplashScreen.BarStatus.PerformStep() '90

            'Load Assemply version
            Me.AVPInfoPanel.ReleaseNo = m_frmSplashScreen.VersionText
            ' Maximize the main form again.
            Me.AVPInfoPanel.ToolID = AVPLib.ContainerData.ToolID
            ''check store gui finish load and main form init
            AVPLib.System_Init_Indicator.IsMainFormInitialize = True And AVPLib.System_Init_Indicator.IsLoadStoreGuiFinish

            WaitAllEquipmentInitFinished()
            m_frmSplashScreen.BarStatus.PerformStep() '100
            Me.Show()
            ProcessCompleteChime(False)
            AVPLib.System_Init_Indicator.IsMainFormInitialize = True
            'request all new data
            For i As Integer = 1 To MaxChamber2Install
                Dim strChamber As String = ConstEnum.Chamber & i.ToString()
                'if Chamber is visible -> create Chamber Controller
                If RobotConfigurationValues.CHAMBERX_VISIBLE(i - 1) = Boolean.TrueString Then
                    m_StatusManager.RequestStatus(strChamber & ".SendRequestAllData")
                End If
            Next
            ' Pump messages.
            Application.DoEvents()
            '
            m_frmSplashScreen.Hide()
            ' Pump messages.
            Application.DoEvents()

            If (AVPLib.RobotConfigurationValues.NUMBER_ACTIVE_LIGHT > TWOLIGHTALARM) Then
                'turn Yellow Light On-> Idle status
                AVPLib.Utils.TurnIdle_YellowLightOnOff(False)
            ElseIf (AVPLib.RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = TWOLIGHTALARM) Then
                AVPLib.Utils.TurnRunning_GreenLight2Off_RGMode(True)

                '0009210: [KhoiHa - 04/07/2016]  One note regarding stack light. If the stack light configure as 3 lights and 
                'the system is idle (idle light will comes one). Once user exit the software and configure as 2 lights, 
                'the idle light stay on. We need to turn off any lights that is not applicable open ctc start up.
                AVPLib.Utils.TurnIdle_YellowLightOnOff(True) '-> turn Yellow Light Off
            End If
            '-> Turn off alarm light I/O when application start up
            MessageManager.ClearAllAlarms(True)
            Me.KeyPreview = True

            'initialize email
            AVPLib.SendEmail.Instance.Initalize()

            ' Throw alarm if can not access to PMx config file
            If AVPLib.RobotConfiguration.lstPM.Count > 0 Then
                Dim strMessage As String = String.Empty
                strMessage = String.Join(", ", AVPLib.RobotConfiguration.lstPM.ToArray())
                AVPLib.Utils.ThrowAlarm("Can not access to " & strMessage & " Configuration File")
                AVPLib.RobotConfiguration.lstPM.Clear()
            End If

            'turn off TM/IG when starting up.
            If RobotConfigurationValues.TM_HIVAC_INSTALLED Then
                AVPLib.Business.TMCryoUtility.TurnOffIG(ConstEnum.Equipments.CassettesModule.ToString())
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                             AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                             "[Main Screen] " + "Turn Off TM IG.")
            End If

            'turn off LLA/IG when starting up
            If RobotConfigurationValues.LLA_HIVAC_INSTALLED Then
                AVPLib.Business.LLCryoUtility.TurnOffIG(ConstEnum.Equipments.LoadLockA.ToString())
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                             AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                             "[Main Screen] " + "Turn Off LLA IG.")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            m_frmSplashScreen.Close()
            m_frmSplashScreen.Dispose()
            m_frmSplashScreen = Nothing
            '
            EnableControlsWhenInitializationDone(True)
            'dat cao add new dialog
            Me.UserLogin(True)
            m_isInitSuccess = True
        End Try
    End Sub

    Friend Sub LoadStoreGUI()
        Try
            Dim StoreGui As DBStoreGui = AVPLib.DataManagerment.EquipmentManager.LoadStoreGui()
            ContainerForm.SystemSetup.rbUseMaxKWH.Checked = Not (StoreGui.UseAbsoluteKWH)
            ContainerForm.SystemSetup.rbUseAbsoluteKWH.Checked = StoreGui.UseAbsoluteKWH
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.System_Init_Indicator.IsLoadStoreGuiFinish = True
        AVPLib.System_Init_Indicator.IsMainFormInitialize = AVPLib.System_Init_Indicator.IsLoadStoreGuiFinish
    End Sub

    Private Function IsAllEquipmentInitFinished() As Boolean
        Dim blResult As Boolean = True

        Dim ctrLoadLock As AVPLib.Business.LoadLockController = Business.ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString)
        If (ctrLoadLock IsNot Nothing) Then
            Dim ctrElevator As Business.LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), Business.LLElevatorController)
            If (ctrElevator IsNot Nothing) Then
                blResult = blResult And ctrElevator.IsInitFinished
            End If
        End If

        Dim objRobot As AVPLib.Business.RobotController = Business.ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString)
        If (objRobot IsNot Nothing) Then
            blResult = blResult And objRobot.IsInitFinished
        End If

        Return blResult
    End Function
    Private Function WaitAllEquipmentInitFinished()
        Dim timeout As Integer = 300000 '5mil
        Return WaitOnCondition(AddressOf IsAllEquipmentInitFinished, timeout, Nothing)
    End Function
    Private Function WaitOnCondition(ByVal condition As CheckCondition, ByVal waitTimeInMilliseconds As Integer, ByVal abortedEvent As Threading.ManualResetEvent) As Boolean
        Dim span As Int64 = waitTimeInMilliseconds
        Dim start As Int64 = Environment.TickCount
        While (Environment.TickCount - start <= span)
            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(0, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            End If
            ' Check Condition.
            If condition() Then
                Return True
            End If
            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(100, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            Else
                Application.DoEvents()
                Threading.Thread.Sleep(1000)
            End If
        End While
        Return False
    End Function
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-06-04</date>
    ''' </author>
    ''' <summary>
    ''' Show Image Alarm
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowAlarm(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If sender Is pnlGreenLight Then
                Me.StackLight.GreenLightOn = True
            ElseIf sender Is pnlRedLight Then
                Me.StackLight.RedLightOn = True
            ElseIf sender Is pnlYellowLight Then
                Me.StackLight.YellowLightOn = True
            ElseIf sender Is pnlBlueLight Then
                Me.StackLight.BlueLightOn = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-06-04</date>
    ''' </author>
    ''' <summary>
    ''' Stop Image Alarm
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StopAlarm(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If sender Is pnlGreenLight Then
                Me.StackLight.GreenLightOn = False
            ElseIf sender Is pnlRedLight Then
                Me.StackLight.RedLightOn = False
            ElseIf sender Is pnlYellowLight Then
                Me.StackLight.YellowLightOn = False
            ElseIf sender Is pnlBlueLight Then
                Me.StackLight.BlueLightOn = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Register Event
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RaiseEventOnEachDialog(ByVal CurrentEquipment As AVPLib.DataManagerment.Equipment, ByVal currentDiagnosDialog As DiagnosticDialog)
        AVPLib.Log.guiLogger.Info("Enter RaiseEventOnEachDialog")
        Try
            Dim currenDiagnosPumpDown As AVP_Robot_Project.DiagnosticScreen = Nothing
            Dim currenDiagnosRateOfRise As AVP_Robot_Project.DiagnosticScreen = Nothing
            Dim currenRecoverPressure As AVP_Robot_Project.DiagnosticScreen = Nothing
            Dim blnIsChamber As Boolean = False
            Select Case CurrentEquipment.Name
                Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                    If ContainerForm.Chamber1Visible Then
                        currenDiagnosPumpDown = currentDiagnosDialog.dgsPumpDownPM1
                        currenDiagnosRateOfRise = currentDiagnosDialog.dgsRateOfRisePM1
                        currenRecoverPressure = currentDiagnosDialog.dgsRecoverPressurePM1
                        blnIsChamber = True
                    End If
                Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                    If ContainerForm.Chamber2Visible Then
                        currenDiagnosPumpDown = currentDiagnosDialog.dgsPumpDownPM2
                        currenDiagnosRateOfRise = currentDiagnosDialog.dgsRateOfRisePM2
                        currenRecoverPressure = currentDiagnosDialog.dgsRecoverPressurePM2
                        blnIsChamber = True
                    End If
                Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                    If ContainerForm.Chamber3Visible Then
                        currenDiagnosPumpDown = currentDiagnosDialog.dgsPumpDownPM3
                        currenDiagnosRateOfRise = currentDiagnosDialog.dgsRateOfRisePM3
                        currenRecoverPressure = currentDiagnosDialog.dgsRecoverPressurePM3
                        blnIsChamber = True
                    End If
                Case AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
                    currenDiagnosPumpDown = currentDiagnosDialog.dgsPumpDownLLA
                    currenDiagnosRateOfRise = currentDiagnosDialog.dgsRateOfRiseLLA
                    currenRecoverPressure = currentDiagnosDialog.dgsRecoverPressureLLA
                    blnIsChamber = True
                Case AVPLib.ConstEnum.Equipments.CassettesModule.ToString()
                    currenDiagnosPumpDown = currentDiagnosDialog.dgsPumpDownTM
                    currenDiagnosRateOfRise = currentDiagnosDialog.dgsRateOfRiseTM
                    currenRecoverPressure = currentDiagnosDialog.dgsRecoverPressureTM
                    blnIsChamber = True
            End Select
            If blnIsChamber = True Then
                AddHandler CurrentEquipment.DiagnosPumpDownSample_Event, AddressOf currenDiagnosPumpDown.GetDataFromPM
                AddHandler CurrentEquipment.DiagnosPumpDownStop_Event, AddressOf currenDiagnosPumpDown.EndGetDataFromPM
                AddHandler CurrentEquipment.DiagnosPumpDownStart_Event, AddressOf currenDiagnosPumpDown.StartCollectDataFromPM

                AddHandler CurrentEquipment.DiagnosRateOfRiseSample_Event, AddressOf currenDiagnosRateOfRise.GetDataFromPM
                AddHandler CurrentEquipment.DiagnosRateOfRiseStop_Event, AddressOf currenDiagnosRateOfRise.EndGetDataFromPM
                AddHandler CurrentEquipment.DiagnosRateOfRiseStart_Event, AddressOf currenDiagnosRateOfRise.StartCollectDataFromPM

                AddHandler CurrentEquipment.DiagnosRecoverPressureSample_Event, AddressOf currenRecoverPressure.GetDataFromPM
                AddHandler CurrentEquipment.DiagnosRecoverPressureStop_Event, AddressOf currenRecoverPressure.EndGetDataFromPM
                AddHandler CurrentEquipment.DiagnosRecoverPressureStart_Event, AddressOf currenRecoverPressure.StartCollectDataFromPM
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave RaiseEventOnEachDialog")
    End Sub

    Private Sub EnableControlsWhenInitializationDone(ByVal bEnable As Boolean)
        Me.AVPLoginPanel.Enabled = bEnable
        Me.btnProcess.Enabled = bEnable
        Me.btnEditor.Enabled = bEnable
        Me.btnMaintenance.Enabled = bEnable
        Me.btnSetup.Enabled = bEnable
        Me.btnDataLog.Enabled = bEnable
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-11-15 </date>
    ''' </author>
    ''' <summary>
    ''' Equipment_StatusChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="sce"></param>
    ''' <remarks></remarks>
    Private Sub Equipment_StatusChanged(ByVal sender As Object, ByVal sce As AVPLib.DataManagerment.StatusChangedEventArgs)
        Try
            Dim sMessageLine As String = sce.Message
            Dim strLogSource As String
            If RobotConfigurationValues.IS_KEPWARE_INSTALLED Then
                strLogSource = AVPLib.ContainerData.LogSource.KepServer
            Else
                strLogSource = AVPLib.ContainerData.LogSource.DeviceNet
            End If
            If sMessageLine.IndexOf("FlashRedLight") > -1 Then
                If sMessageLine.IndexOf("FlashRedLight On") > -1 Then
                    If Me.pnlRedLight.IsStopFlashing Then
                        Me.pnlRedLight.IsStopFlashing = False
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, strLogSource, "[Main Screen] Alarm Light On")
                    End If
                ElseIf sMessageLine.IndexOf("FlashRedLight Off") = 0 Then
                    If Me.pnlRedLight.IsStopFlashing = False Then
                        Me.pnlRedLight.IsStopFlashing = True
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, strLogSource, "[Main Screen] Alarm Light Off")
                    End If
                End If
            ElseIf sMessageLine.IndexOf("FlashGreenLight") > -1 Then
                If sMessageLine.IndexOf("FlashGreenLight On") > -1 Then
                    If AVPLib.RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = TWOLIGHTALARM Then
                        Me.pnlGreenLight.VisibleAlarm = True
                    Else
                        Me.pnlGreenLight.IsStopFlashing = False
                    End If
                ElseIf sMessageLine.IndexOf("FlashGreenLight Off") = 0 Then
                    If AVPLib.RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = TWOLIGHTALARM Then
                        Me.pnlGreenLight.VisibleAlarm = False
                    Else
                        Me.pnlGreenLight.IsStopFlashing = True
                    End If
                End If
            ElseIf sMessageLine.IndexOf("FlashOrangeLight") > -1 Then
                If sMessageLine.IndexOf("FlashOrangeLight On") > -1 Then
                    Me.pnlYellowLight.IsStopFlashing = False
                    ' AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.KepServer, "[Main Screen] Idle Light On")
                ElseIf sMessageLine.IndexOf("FlashOrangeLight Off") = 0 Then
                    Me.pnlYellowLight.IsStopFlashing = True
                    'AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.KepServer, "[Main Screen] Idle Light Off")
                End If
            ElseIf sMessageLine.IndexOf("FlashBlueLight") > -1 Then
                If sMessageLine.IndexOf("FlashBlueLight On") > -1 Then
                    Me.pnlBlueLight.IsStopFlashing = False
                ElseIf sMessageLine.IndexOf("FlashBlueLight Off") = 0 Then
                    Me.pnlBlueLight.IsStopFlashing = True
                End If
            ElseIf sMessageLine.IndexOf("StartAlarm") > -1 Then
                If sMessageLine <> "StartAlarm Off" Then
                    MessageManager.AddAlarm(sMessageLine)
                End If
            Else
                MessageManager.AddMessage(sMessageLine, sce.ChamberName)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Handle Click show Editor
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditor.Click
        Try
            If TypeOf sender Is AVPButton AndAlso CType(sender, AVPButton).IsSelected Then
                Return
            End If
            Dim indexTab As Integer = ContainerForm.RecipeEditor.tabEditorRecipe.SelectedIndex
            If indexTab = 0 Then
                ContainerForm.RecipeEditor.tabEditorRecipe.SelectedTab = ContainerForm.RecipeEditor.tabEditorRecipe.TabPages(0)
                ContainerForm.RecipeEditor.LoadDataGrid(False, Nothing)
            Else
                ContainerForm.RecipeEditor.LoadDataGrid(False, Nothing, ContainerForm.RecipeEditor.LastOpenRecipe)
            End If
            tabEditor.BringToFront()
            pnlPMConnection.BringToFront()
            SetSelectedState(sender)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Resize Changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPRobotMain_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Try
            Dim posPanel As Integer = 1024 / 2
            Dim posForm As Integer = Me.Size.Width / 2
            Me.pnlMain.Location = New Point(posForm - posPanel, 0)
            Dim pnlHeight As Integer = Me.Size.Height - (768 - 734)
            Me.pnlMain.Size = New Size(Me.pnlMain.Size.Width, pnlHeight)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on button setup
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetup.Click
        Try
            If TypeOf sender Is AVPButton AndAlso CType(sender, AVPButton).IsSelected Then
                Return
            End If
            tabSetup.BringToFront()
            pnlPMConnection.BringToFront()
            '#05/17/2011 
            '#- Cant not create user when avp init.
            '#Begin fix
            If (AVPLib.ContainerData.UserLogin IsNot Nothing) AndAlso ContainerForm.UserSetup.DGVSystemUser.CurrentRow IsNot Nothing Then
                Dim i As Integer
                ContainerForm.UserSetup.DGVSystemUser.CurrentRow.Selected = False
                For i = 0 To ContainerForm.UserSetup.DGVSystemUser.Rows.Count - 1
                    If UCase(ContainerForm.UserSetup.DGVSystemUser.Rows(i).Cells(0).Value) = UCase(AVPLib.ContainerData.UserLogin.Username) Then
                        ContainerForm.UserSetup.DGVSystemUser.Rows(i).Selected = True
                        ContainerForm.UserSetup.LoadUserDetail(AVPLib.ContainerData.UserLogin.Username)  'load User Login.
                        Exit For
                    End If
                Next
            End If
            '#End fix
            SetSelectedState(sender)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' handle DataLog
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDataLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataLog.Click
        Try
            If TypeOf sender Is AVPButton AndAlso CType(sender, AVPButton).IsSelected Then
                Return
            End If
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Main Screen] Enter Log viewer screen")
            ContainerForm.HandleForm(ContainerForm.AlarmAndEvent)
            ContainerForm.AlarmAndEvent.LoadAlarmAndEvent(String.Empty, AlarmAndEvent.Filter_Type.All)
            tabDataLog.BringToFront()
            pnlPMConnection.BringToFront()
            SetSelectedState(sender)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Show process user control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Try
            If TypeOf sender Is AVPButton AndAlso CType(sender, AVPButton).IsSelected Then
                Return
            End If
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Main Screen] Enter Process screen")
            pnlCenter.Controls.Item(ContainerForm.ProcessPanel.Name).Visible = True
            pnlCenter.Controls.Item(ContainerForm.ProcessPanel.Name).BringToFront()
            ContainerForm.HandleForm(ContainerForm.ProcessPanel)
            pnlPMConnection.BringToFront()
            SetSelectedState(sender)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-05-08 </date>
    ''' </author>
    ''' <summary>
    ''' Set selected state for button
    ''' </summary>
    Private Sub SetSelectedState(ByVal sender As System.Object)
        Try
            If Not (TypeOf sender Is AVPButton) Then
                Exit Sub
            End If

            btnProcess.IsSelected = False
            btnEditor.IsSelected = False
            btnMaintenance.IsSelected = False
            btnSetup.IsSelected = False
            btnDataLog.IsSelected = False

            CType(sender, AVPButton).IsSelected = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-05-08 </date>
    ''' </author>
    ''' <summary>
    ''' Goto screen and set selected state for button
    ''' </summary>
    Public Sub GotoScreen(ByVal screen As SystemScreens)
        Try
            If screen = SystemScreens.PM1Screen Then
                tabMain.SelectedTab = tabPM1
            ElseIf screen = SystemScreens.PM2Screen Then
                tabMain.SelectedTab = tabPM2
            ElseIf screen = SystemScreens.PM3Screen Then
                tabMain.SelectedTab = tabPM3
            ElseIf screen = SystemScreens.TMScreen Then
                tabMain.SelectedTab = tabTM
            ElseIf screen = SystemScreens.GEMScreen Then
                tabMain.SelectedTab = tabSecsGem
            ElseIf screen = SystemScreens.DatalogScreen Then
                tabDataLog.BringToFront()
                tabDataLog.SelectedTab = tabDTLog
                pnlPMConnection.BringToFront()
                pnlCenter.Controls.Item(ContainerForm.ProcessPanel.Name).Visible = False
                SetSelectedState(btnDataLog)
            ElseIf screen = SystemScreens.CycelATM Then
                tabMain.SelectedTab = tabCycleATM
            End If

            If IsMaintenanceScreen(screen) Then
                tabMain.BringToFront()
                pnlPMConnection.BringToFront()
                pnlCenter.Controls.Item(ContainerForm.ProcessPanel.Name).Visible = False
                SetSelectedState(btnMaintenance)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-05-08 </date>
    ''' </author>
    ''' <summary>
    ''' Indicate the screen whether is maintenace screen or not
    ''' </summary>
    Private Function IsMaintenanceScreen(ByVal screen As SystemScreens) As Boolean
        If screen = SystemScreens.AlignerScreen OrElse _
        screen = SystemScreens.GEMScreen OrElse _
        screen = SystemScreens.PM1Screen OrElse _
        screen = SystemScreens.PM2Screen OrElse _
        screen = SystemScreens.PM3Screen OrElse _
        screen = SystemScreens.TMScreen Then
            Return True
        End If
        Return False
    End Function


    Public Sub ProcessCompleteChime(Optional ByVal isShowMsg As Boolean = False)
        Try
            ContainerForm.CassettesPanel.RequestTurnOff_ProcessChime(isShowMsg)
            'If (isShowMsg) Then
            '    'If Utils.ShowAVPMessageBox("Process Complete", "AVP", MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.OK) Then
            '    '    ContainerForm.CassettesPanel.RequestTurnOff_ProcessChime()
            '    'End If
            'Else
            '    ContainerForm.CassettesPanel.RequestTurnOff_ProcessChime()
            'End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Show Time on the top right of form main
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    ''' <author>
    '''    	<name> Dat Cao  </name>
    '''    	<date> 20011-03-22</date>
    ''' </author>
    ''' <summary>
    ''' Main Windown Idle, no key, no mouse move, > Interval Time
    ''' this Interval Time is Hard code
    ''' it will be add to config file and show it in Option panel
    ''' User is Loging -> log out and show login panel
    ''' User do not Loging -> show login panel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmrTopRightClock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTopRightClock.Tick
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                For i As Integer = 1 To MaxChamber2Install
                    Dim strChamberName As String = ConstEnum.Chamber & i.ToString()
                    Dim ChamberModule As SystemModule = Nothing
                    ''if chamber is IBE => count unprotected mode
                    ''if IBE & Non-Device Net => count Source Usage 
                    If AVPLib.ContainerData.IsChamberVisible(strChamberName, ChamberModule) AndAlso _
                        ChamberModule.Type = AVPLib.SystemModule.ModuleType.IBE Then
                        Utils.CountUnProtectedTimeInProcessModule(strChamberName)
                        If ChamberModule.PM_DeviceNet = False Then
                            Utils.CountSourceUsageTime(strChamberName)
                        End If
                    End If
                Next
            Else
                Exit Sub
            End If
            If m_isInitSuccess = True Then
                'dat cao add here to count idleTime
                If Not m_systemStatus = SystemStatus.Idle Then
                    m_sysIdle_Count += 1 'just count when system status is not idle.
                End If
                Dim mycursorpos As Point
                GetCursorPos(mycursorpos)
                If Not (m_Cursor_Pos = mycursorpos) Then
                    m_Cursor_Pos = mycursorpos
                    m_sysIdle_Count = -1
                End If

                '''win idle condition:
                '+ idleTime > Interval
                '+ SystemStatus != Idle
                '+ User is Login
                '+ User Permission
                '+ this version not check permission, Ask Mr.Truc 
                If CheckAutoLogout() Then       'form not Idle
                    'log out 
                    Dim userName As String = Me.AVPLoginPanel.Username
                    Me.AVPLoginPanel.Username = String.Empty
                    Me.AVPLoginPanel.Group = String.Empty
                    AVPLib.ContainerData.UserLogin = Nothing
                    '#07/26/2011 
                    '#-	AVP does not log when admin is autolog out.
                    '# Begin fix:
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, userName + " is autolog out.")
                    '#End fix
                    Permission()
                    If ContainerForm.PanelCurrent.Equals(ContainerForm.ProcessPanel) Then
                        ContainerForm.PanelCurrent.Refresh()
                    End If

                    m_systemStatus = SystemStatus.Idle
                    m_sysIdle_Count = 0
                    Me.UserLogin(False)

                    Dim hWnd As Long = FindWindow(vbNullString, "AVPMessageBox")
                    If (hWnd > 0) Then
                        m_marshaller.Invoke(Of Long)(New Threading.SendOrPostCallback(AddressOf ClosePopUpWindow), hWnd)
                    End If
                End If
            End If
            '#If AVP_PLATFORM = "CX" Then
            ''' handle protected mode for TM
            If (ContainerForm.CassettesPanel.TM_ProtectedMode.Status = ProtectedModStatus.On) Then
                If (ContainerForm.CassettesPanel.TM_ProtectedMode.CurrentTime < ContainerForm.CassettesPanel.TM_ProtectedMode.MaxTime) Then
                    ContainerForm.CassettesPanel.TM_ProtectedMode.CurrentTime += 1
                Else
                    ContainerForm.CassettesPanel.TM_ProtectedMode.StopProtectedMode()
                    'ContainerForm.CassettesPanel.btnTMProtectedMode.Text = "Unprotected"
                    ContainerForm.CassettesPanel.btnTMProtectedMode.Status = SL_CustomButton.DisplayStatus.Off

                    ' Update SECS/GEM variables by Hoa Nguyen
                    ' Var Name: OverideModeOnOff
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, _
                                                        "OverideModeOnOff", VALUELib.ValueType.U1, SL_CustomButton.DisplayStatus.Off)
                End If
            End If
            '#End If
            Me.AVPDatetimePanel.Time = DateTime.Now.ToString("HH:mm:ss")
            Me.AVPDatetimePanel.Date = DateTime.Now.ToString("MM/dd/yyyy")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-12-03</date>
    ''' </author>
    ''' <summary>
    ''' check auto logout
    ''' </summary>
    Private Function CheckAutoLogout() As Boolean
        Dim bResult As Boolean

        Try
            If (m_sysIdle_Count * tmrTopRightClock.Interval / 1000) > (m_idleTime * 60) AndAlso _
                (Not m_systemStatus = SystemStatus.Idle) AndAlso m_idleTime > 0 Then

                Dim groupName As String = Me.AVPLoginPanel.Group
                Dim logoutOption As Integer = AVPLib.ContainerData.AutoLogoutOption

                Select Case logoutOption

                    ' Option 1. Admin logout only
                    Case 1
                        If groupName = ConstEnum.ADMINISTRATOR.ToUpper() Then
                            bResult = True
                        End If

                        ' Option 2. Logout all user except operator
                    Case 2
                        If groupName <> ConstEnum.STR_OPERATOR.ToUpper() Then
                            bResult = True
                        End If

                        ' Option 3. Logout all all user
                    Case 3
                        bResult = True

                End Select

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return bResult
    End Function

    Private Sub ClosePopUpWindow(ByVal hwind2 As Object)
        Try
            'SendMessage(hwind2, WM_SYSCOMMAND, SC_CLOSE, 0)
            Dim hwind As IntPtr = New IntPtr(CType(hwind2, Long))
            Dim VK_COMMAND As UInteger = 16
            Dim hPRAM As IntPtr = 0
            Dim lPRAM As IntPtr = 0
            PostMessage(hwind, VK_COMMAND, hPRAM, lPRAM)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2018-11-28 </date>
    ''' </author>
    ''' <summary>
    ''' Delete File Log And DataRun
    ''' </summary>
    Private Sub DeleteFileLogAndDataRun(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
        Try
            m_tmrDeleteLogFile.Enabled = False

            Utils.DeleteSubFolderAfterDay(AVPLib.ContainerDAO.FPath_RunDataOfWafer)
            Utils.DeleteSubFolderAfterDay(AVPLib.ContainerDAO.GetFolderSystemConfig())

            tmrDeleteLogFile_Tick()
            m_tmrDeleteLogFile.Enabled = True
        Catch ex As Exception
            AVPLib.Log.coreLogger.Error("DeleteFileLogAndDataRun " + ex.ToString())
        End Try
    End Sub

    Private Sub tmrDeleteLogFile_Tick()
        AVPLib.Log.coreLogger.Info("Enter tmrDeleteLogFile_Tick")
        Try
            Dim now As TimeSpan = DateTime.Now.TimeOfDay
            Dim intHour As Integer = now.Hours
            Dim isSync As Boolean = IsSyncArchive(now)

            ''check and delete log file around 1 AM everyday
            If intHour = 0 AndAlso m_blnIsDeleteLog = False Then
                ''turn on flag
                Utils.CleanLogFiles()
                m_blnIsDeleteLog = True

                ' Update license registry key
                Dim strLastRunDate As String = String.Empty
                If Utils.Read_MarkedRegistry(strLastRunDate) Then
                    Utils.UpdateRegitryIfCan(strLastRunDate)
                End If
            ElseIf (intHour <> 0) Then
                ''turn off flag
                m_blnIsDeleteLog = False
            End If

            ''Hoai Ly - 2015-04-22: check and copy system config file around 1 AM everyday
            If isSync AndAlso m_blnIsCopyConfigFile = False Then
                m_blnIsCopyConfigFile = True
                Threading.ThreadPool.QueueUserWorkItem(AddressOf _
                     AutoArchiveConfigFile, AVPLib.ContainerDAO.AutoArchiveSystemConfigFile())
            ElseIf (intHour <> 0) Then
                ''turn off flag
                m_blnIsCopyConfigFile = False
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("tmrDeleteLogFile_Tick " & ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave tmrDeleteLogFile_Tick")
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-06-04 </date>
    ''' </author>
    ''' <summary>
    ''' check time sync archive
    ''' </summary>
    Public Function IsSyncArchive(ByVal now As TimeSpan) As Boolean
        AVPLib.Log.coreLogger.Info("Enter IsSyncArchive")
        Dim result As Boolean = False

        Try
            Dim archiveFirst As TimeSpan = New TimeSpan(0, 0, 0)
            Dim archiveSecond As TimeSpan = New TimeSpan(21, 0, 0)

            If now.Hours = archiveFirst.Hours OrElse now.Hours = archiveSecond.Hours Then
                result = True
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        AVPLib.Log.coreLogger.Info("Leave IsSyncArchive")
        Return result
    End Function

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-04-22 </date>
    ''' </author>
    ''' <summary>
    ''' Copy all config file to share folder
    ''' </summary>
    Public Sub AutoArchiveConfigFile(ByVal isActive As Object)
        AVPLib.Log.coreLogger.Info("Enter AutoArchiveConfigFile")
        Dim m_autoArchiveStatus As Boolean = False
        Dim msgError As String = String.Empty

        Try
            If isActive Then
                Dim strFolderSystemConfig As String = AVPLib.ContainerDAO.GetFolderSystemConfig()
                
                Dim yesterday As Date = DateTime.Now.AddDays(-1)
                Dim PathTo As String = strFolderSystemConfig + "\" + yesterday.ToString(ConstantAndEnum.STR_FORMAT_DATE_UNDERLINED)

                CreateDirectory(PathTo)
                m_blnIsFolderExists = FileExistsHelper.FolderExists(PathTo, 5000)
                If Not m_blnIsFolderExists Then
                    msgError = "folder has no permission"
                    Exit Try
                End If

                'Archive system config files for CXX
                Dim strSystemName As String = AVPLib.ContainerDAO.GetToolID
                PathTo = PathTo + "\" + strSystemName
                Dim strConfigFilePathTo As String = PathTo + "\" + STR_CTC + "\" + STR_CONFIG_FILES
                Try
                    CopyDirectory(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + STR_CONFIG_FILES, strConfigFilePathTo)
                    BackupLicenseFile(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, strConfigFilePathTo)
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Error("Error copy system config file to " + strConfigFilePathTo)
                End Try

                'Archive data files for CX4
                Dim strDataFilePathTo As String = PathTo + "\" + STR_CTC + "\" + STR_DATA_FILES
                Try
                    BackupDataFiles(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + STR_DATA_FILES, strDataFilePathTo)
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Error("Error copy data file to " + strDataFilePathTo)
                End Try

                'Archive system config files for each PM
                For i As Integer = 1 To MaxChamber2Install
                    Dim strChamberName As String = AVPLib.Utils.chamberID2ChamberName(ConstEnum.Chamber & i.ToString())
                    Dim ser As Server = AVPLib.DataManagerment.ConfigurationManager.ConfigItemList.Item(ConstEnum.Chamber + i.ToString())
                    If ser.IsInstalled = True Then
                        Try
                            Dim PathFrom As String = ser.ConfigFolder
                            Dim strPath As String = PathTo + "\" + strChamberName
                            CopyDirectory(PathFrom, strPath)
                            BackupLicenseFile(PathFrom.Substring(0, (PathFrom.Length - 7)), PathTo + "\" + strChamberName)

                            'copy logs file in backend
                            Dim logPath As String = PathFrom.Replace("Config", "Logs")
                            CopyLogFilesBackend(logPath, strPath + "\Logs")

                        Catch ex As Exception
                            AVPLib.Log.coreLogger.Error("Error copy system config file to " + PathTo + "\" + strChamberName)
                        End Try
                    End If
                Next

                m_autoArchiveStatus = True
            End If

        Catch ex As Exception
            m_autoArchiveStatus = False
            AVPLib.Log.avpLogger.Error("AutoArchiveConfigFile" & ex.ToString())
        Finally
            If isActive Then
                If (Me.InvokeRequired) Then
                    Me.Invoke(New UpdateArchiveStatusValue(AddressOf UpdateArchiveStatus), DateAndTime.Now.ToString("MM/dd/yyyy H:mm:ss"), m_autoArchiveStatus, msgError)
                Else
                    UpdateArchiveStatus(DateAndTime.Now.ToString("MM/dd/yyyy H:mm:ss"), m_autoArchiveStatus, msgError)
                End If
            End If
        End Try

        AVPLib.Log.coreLogger.Info("Leave AutoArchiveConfigFile")
    End Sub

    '' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' Update Auto Archive Status
    ''' </summary>
    Private Sub UpdateArchiveStatus(ByVal objDateTime As Object, ByVal objStatus As Object, ByVal msgError As String)
        Dim strStatus As String = IIf(objStatus = True, "successful", "failed")
        Dim strResult As String = "The backup was "
        strResult = strResult + strStatus + " on " + objDateTime

        If Not objStatus AndAlso Not String.IsNullOrEmpty(msgError) Then
            strResult = strResult & ", " & msgError
        End If

        ContainerForm.SystemSetup.lblAutoArchiveStatus.Text = strResult.ToString()
        ContainerForm.SystemSetup.lblAutoArchiveStatus.Refresh()
        ContainerForm.SystemSetup.btnArchiveNow.Enabled = True

        If Not m_blnIsCopyConfigFile Then
            Utils.ShowAVPMessageBox("Archive System File was " + strStatus, "Archive System File", MessageBoxIcon.Information, MessageBoxButtons.OK)
        End If

        AVPLib.ContainerDAO.SaveAutoArchiveStatusValue(objDateTime, ConstEnum.XPATH_AUTO_ARCHIVE_DATE_TIME)
        AVPLib.ContainerDAO.SaveAutoArchiveStatusValue(objStatus, ConstEnum.XPATH_AUTO_ARCHIVE_STATUS)
    End Sub

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-04-22 </date>
    ''' </author>
    ''' <summary>
    ''' Copy all config file to share folder
    ''' </summary>
    Private Sub CopyDirectory(ByVal sOriginal As String, ByVal sDestination As String)
        AVPLib.Log.coreLogger.Info("Enter CopyDirectory")

        Dim oFiles() As IO.FileInfo
        Dim oFile As IO.FileInfo
        Dim oDirectory As New IO.DirectoryInfo(sOriginal)
        CreateDirectory(sDestination)

        Try
            oFiles = oDirectory.GetFiles()
            For Each oFile In oFiles
                CopyFile(oFile, sDestination, sOriginal.Length)
            Next
        Catch ex As Exception
            AVPLib.Log.coreLogger.Error("Error copy file to " + sDestination)
        End Try

        Try
            For Each oEntry As IO.DirectoryInfo In oDirectory.GetDirectories
                If (oEntry.GetFiles().Length = 0 And oEntry.GetDirectories().Length = 0) Then
                    Continue For
                End If
                CopyDirectory(oEntry.FullName, sDestination & "\" & oEntry.FullName.Substring(sOriginal.Length))
            Next
        Catch ex As Exception
            AVPLib.Log.coreLogger.Error("Error copy file to " + sDestination)
        End Try

        AVPLib.Log.coreLogger.Info("Leave CopyDirectory")
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-08-05 </date>
    ''' </author>
    ''' <summary>
    ''' Copy all config file to share folder if it is day back up
    ''' </summary>
    Private Sub CopyDirectoryByDay(ByVal sOriginal As String, ByVal sDestination As String, ByVal isFolderDay As Boolean)
        AVPLib.Log.coreLogger.Info("Enter CopyDirectoryByDay")

        Try
            Dim oDirectory As New IO.DirectoryInfo(sOriginal)
            CreateDirectory(sDestination)

            Dim strExtends() As String = {"*.txt", "*.csv"}
            CopyFileWithExtension(oDirectory, sOriginal.Length, sDestination, strExtends)

            For Each oEntry As IO.DirectoryInfo In oDirectory.GetDirectories
                Dim sDes As String = sDestination & "\" & oEntry.FullName.Substring(sOriginal.Length)
                If isFolderDay Then
                    If ValidationFileBackup(oEntry.Name) Then
                        CopyDirectoryByDay(oEntry.FullName, sDes, isFolderDay)
                    End If
                Else
                    CopyDirectoryByDay(oEntry.FullName, sDes, isFolderDay)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.coreLogger.Error("Error copy file to " + sDestination)
        End Try

        AVPLib.Log.coreLogger.Info("Leave CopyDirectoryByDay")
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-08-27 </date>
    ''' </author>
    ''' <summary>
    ''' Copy log file if it belong to day backup
    ''' </summary>
    Private Sub CopyLogFilesBackend(ByVal sOriginal As String, ByVal sDestination As String)
        AVPLib.Log.coreLogger.Info("Enter CopyLogFilesBackend")

        Try
            Dim oDirectory As New IO.DirectoryInfo(sOriginal)
            CreateDirectory(sDestination)

            CopyFileWithExtension(oDirectory, sOriginal.Length, sDestination)
        Catch ex As Exception
            AVPLib.Log.coreLogger.Error("Error copy file to " + sDestination)
        End Try

        AVPLib.Log.coreLogger.Info("Leave CopyLogFilesBackend")
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-09-06 </date>
    ''' </author>
    ''' <summary>
    ''' Create directory
    ''' </summary>
    Private Sub CreateDirectory(ByVal path As String)
        Try
            IO.Directory.CreateDirectory(path)
        Catch ex As Exception
            AVPLib.Log.coreLogger.Error("Error create folder " + path)
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-09-06 </date>
    ''' </author>
    ''' <summary>
    ''' Copy file from source to destination
    ''' </summary>
    Private Sub CopyFile(ByVal oFile As IO.FileInfo, ByVal sDestination As String, ByVal length As Integer)
        Try
            IO.File.Copy(oFile.FullName, sDestination & "\" & oFile.FullName.Substring(length), True)
        Catch ex As Exception
            AVPLib.Log.coreLogger.Error("Error copy file to " + sDestination)
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-09-06 </date>
    ''' </author>
    ''' <summary>
    ''' Copy file with extension
    ''' </summary>
    Private Sub CopyFileWithExtension(ByVal oDirectory As IO.DirectoryInfo, ByVal originalLength As Integer, ByVal sDestination As String, Optional ByVal strExtends() As String = Nothing)
        Try
            Dim oFiles() As IO.FileInfo
            Dim oFile As IO.FileInfo

            If strExtends Is Nothing Then
                oFiles = oDirectory.GetFiles()

                For Each oFile In oFiles
                    If ValidationFileBackup(oFile.Name) Then
                        CopyFile(oFile, sDestination, originalLength)
                    End If
                Next
            Else
                For i As Integer = 0 To strExtends.Length - 1
                    oFiles = oDirectory.GetFiles(strExtends(i))

                    For Each oFile In oFiles
                        If ValidationFileBackup(oFile.Name) Then
                            CopyFile(oFile, sDestination, originalLength)
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.coreLogger.Error("Error copy file to " + sDestination)
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung PHam </name>
    '''    	<date> 2020-08-27 </date>
    ''' </author>
    ''' <summary>
    ''' check file backup
    ''' return true if file belong to day backup and otherwise
    ''' </summary>
    Private Function ValidationFileBackup(ByVal strName As String) As Boolean
        Dim result As Boolean = False

        Try
            Dim dayBackup As Date = DateTime.Now.AddDays(-1)
            If strName.Contains(dayBackup.ToString(ConstantAndEnum.STR_FORMAT_DATE_DASH)) Then
                result = True
                Exit Try
            End If

            If strName.Contains(dayBackup.ToString(ConstantAndEnum.STR_FORMAT_DATE_DOT)) Then
                result = True
                Exit Try
            End If

            If strName.Contains(dayBackup.ToString(ConstantAndEnum.STR_FORMAT_DATE_UNDERLINED)) Then
                result = True
                Exit Try
            End If

            If strName.Contains(dayBackup.ToString(ConstantAndEnum.STR_FORMAT_DATE_UNDERLINED2)) Then
                result = True
                Exit Try
            End If
        Catch ex As Exception
            AVPLib.Log.coreLogger.Error(ex.ToString())
        End Try

        Return result
    End Function

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' Backup License File
    ''' </summary>
    Private Sub BackupLicenseFile(ByVal sOriginal As String, ByVal sDestination As String)
        AVPLib.Log.coreLogger.Info("Enter BackupLicenseFile")
        Try
            Dim lstFile As String() = System.IO.Directory.GetFiles(sOriginal, "license")

            If lstFile IsNot Nothing AndAlso lstFile.Length > 0 Then
                IO.File.Copy(lstFile(0), sDestination & "\license", True)
            End If

        Catch ex As Exception
            AVPLib.Log.coreLogger.Error("Error copy license file to " + sDestination)
        End Try
        AVPLib.Log.coreLogger.Info("Leave BackupLicenseFile")
    End Sub

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-09-10 </date>
    ''' </author>
    ''' <summary>
    ''' Backup Data Files
    ''' </summary>
    Private Sub BackupDataFiles(ByVal sOriginal As String, ByVal sDestination As String)
        AVPLib.Log.coreLogger.Info("Enter BackupDataFiles")
        Try
            Dim lstFolder As New List(Of String)
            lstFolder.Add(ConstEnum.STR_JOB_FILES)
            lstFolder.Add(ConstEnum.STR_RECIPES)
            lstFolder.Add(ConstEnum.STR_WARER_FLOWS)
            lstFolder.Add(ConstEnum.STR_ARCHIVED)
            lstFolder.Add(ConstEnum.STR_DATARUN)

            Dim oDirectory As New IO.DirectoryInfo(sOriginal)
            For Each oEntry As IO.DirectoryInfo In oDirectory.GetDirectories
                If lstFolder.Contains(oEntry.Name.ToString()) Then
                    Dim sDes As String = sDestination & "\" & oEntry.FullName.Substring(sOriginal.Length)

                    If oEntry.Name = ConstEnum.STR_ARCHIVED Then
                        CopyDirectoryByDay(oEntry.FullName, sDes, False)

                    ElseIf oEntry.Name = ConstEnum.STR_DATARUN Then
                        CopyDirectoryByDay(oEntry.FullName, sDes, True)

                    Else
                        CopyDirectory(oEntry.FullName, sDes)
                    End If

                End If
            Next

        Catch ex As Exception
            AVPLib.Log.coreLogger.Error("Error copy data file to " + sDestination)
        End Try

        AVPLib.Log.coreLogger.Info("Enter BackupDataFiles")
    End Sub

#Region "Permission"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Login - Logout click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AVPLoginPanel.Click
        Try
            If AVPLib.ContainerData.UserLogin Is Nothing Then
                m_LoginDialog.btnLogOut.Enabled = False
                m_LoginDialog.btnQuit.Enabled = False
            Else
                m_LoginDialog.btnLogOut.Enabled = True
                Dim blnSchedulerIsRun As Boolean = False
                If Not (ContainerForm.ProcessPanel.lpcLoadLockA.btnStart.Text = "START") Then
                    blnSchedulerIsRun = True
                End If

                If Not (blnSchedulerIsRun) And AVPLib.ContainerData.Permission(PERMISSION_008) Then
                    m_LoginDialog.btnQuit.Enabled = True
                ElseIf (blnSchedulerIsRun) Then 'if disable Exit
                    m_LoginDialog.btnQuit.Enabled = False
                ElseIf Not (AVPLib.ContainerData.Permission(PERMISSION_008)) Then ''if not enough permission
                    m_LoginDialog.btnQuit.Enabled = False
                End If
            End If


            m_LoginDialog.ShowDialog()
            If m_LoginDialog.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.AVPLoginPanel.Username = UCase(m_LoginDialog.cmbUsername.Text)
                Me.AVPLoginPanel.Group = UCase(m_LoginDialog.Group)
                Permission()
                If ContainerForm.PanelCurrent.Equals(ContainerForm.ProcessPanel) Then
                    ContainerForm.PanelCurrent.Refresh()
                End If
                CheckRecipe_And_UserRight()
            Else
                Try
                    ' Logout
                    If m_LoginDialog.DialogResult = Windows.Forms.DialogResult.Retry Then
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                               AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                               "[Main Screen] " + AVPLib.ContainerData.UserLogin.Username + " logout")

                        Me.AVPLoginPanel.Username = ""
                        Me.AVPLoginPanel.Group = ""
                        AVPLib.ContainerData.UserLogin = Nothing
                        Permission()
                        'Dim strMessageText As String = AVPLib.ContainerData.GetMessageText("LogoutSuccessfully")
                        'Utils.ShowAVPMessageBox(strMessageText, "Logout", MessageBoxIcon.Information, MessageBoxButtons.OK)
                        If ContainerForm.PanelCurrent.Equals(ContainerForm.ProcessPanel) Then
                            ContainerForm.PanelCurrent.Refresh()
                        End If
                        'Quit App
                    ElseIf m_LoginDialog.DialogResult = Windows.Forms.DialogResult.Abort Then
                        Dim strExitDeviceNet As String = String.Empty
                        Dim isExitDeviceNetApp As Boolean = False
                        If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                            strExitDeviceNet = "Turn off all I/O"
                        End If
                        If Utils.ShowAVPMessageBoxWithCB("Do you really want to quit AVP Application?", "Quit", MessageBoxIcon.Question, strExitDeviceNet, isExitDeviceNetApp, AVPMessageBox.AVPMessageBoxButton.OKCancel) = Windows.Forms.DialogResult.OK Then
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                 "[Main Screen] " + AVPLib.ContainerData.UserLogin.Username + " quit application")
                            If isExitDeviceNetApp Then
                                Dim m_objDnetAppController As AVPLib.Business.DeviceNetAppController = AVPLib.Business.ControllerManager.GetController(ConstEnum.Equipments.DeviceNetApp.ToString())
                                m_objDnetAppController.ExitDeviceNetApp = True
                            End If
                            ContainerForm.Diagnostic.SendStop_ROR_PDC()
                            Me.Close()
                        End If
                    End If
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try

                ' clean up dialog when login logout canel
                m_systemStatus = SystemStatus.None
                m_LoginDialog.cmbUsername.Text = String.Empty
                m_LoginDialog.txtPassword.Text = String.Empty
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-03-22</date>
    ''' </author>
    ''' <summary>
    ''' Login - Logout click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UserLogin(ByVal blnIsShowLoginForm As Boolean)
        m_LoginDialog.txtPassword.Text = String.Empty '" "
        m_LoginDialog.cmbUsername.Text = String.Empty
        Try
            If AVPLib.ContainerData.UserLogin Is Nothing Then
                If blnIsShowLoginForm Then
                    m_LoginDialog.ShowDialog()
                End If
                m_systemStatus = SystemStatus.Idle
                If blnIsShowLoginForm Then
                    If m_LoginDialog.DialogResult = Windows.Forms.DialogResult.OK Then
                        Me.AVPLoginPanel.Username = UCase(m_LoginDialog.cmbUsername.Text)
                        Me.AVPLoginPanel.Group = UCase(m_LoginDialog.Group)
                        Permission()
                        If ContainerForm.PanelCurrent.Equals(ContainerForm.ProcessPanel) Then
                            ContainerForm.PanelCurrent.Refresh()
                        End If
                        CheckRecipe_And_UserRight()
                        ' clean up dialog when login logout canel
                        m_LoginDialog.cmbUsername.Text = String.Empty
                        m_LoginDialog.txtPassword.Text = String.Empty
                    End If
                    'when exit dialog then
                    m_systemStatus = SystemStatus.None
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub CheckRecipe_And_UserRight()
        Dim CurrentUser As AVPLib.DBUser = AVPLib.ContainerData.UserLogin
        If Not String.IsNullOrEmpty(CurrentUser.PMxNeed_ToUpdatePrivilege) Then
            Utils.ShowAVPMessageBox(CurrentUser.PMxNeed_ToUpdatePrivilege & " : Configuration changed" & Chr(13) & _
                               " Please go to Set Up Screen and Save your Recipe Privilege. Then Restart AVP!", _
                          "Recipe Privilege is out of date", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "Check out AVP Privilege")

        End If
    End Sub
#End Region

#End Region
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Load or Unload IBE Item 
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub LoadIBEItem(ByVal IBEPanel As AVP_Robot_Project.IBEPanel, ByVal ChamberConfig As AVPLib.SystemModule)
        Try
            Dim objEQ As DataManagerment.IBEChamber = Nothing
            objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(IBEPanel.Name)
            With objEQ
                .Etch_Rate = ChamberConfig.Etch_Rate
            End With

            IBEPanel.IGIsoValveInstalled = ChamberConfig.IGIsoValveInstalled
            IBEPanel.PM_DeviceNet = ChamberConfig.PM_DeviceNet
            IBEPanel.CryoVisible = ChamberConfig.CryoVisible
            IBEPanel.ROR_Litter_Value = ChamberConfig.Litter_Value
            IBEPanel.RunRecipe.Real_Device_Enable = RobotConfigurationValues.REAL_DEVICE_INSTALLED
            IBEPanel.SLContainerBox.TypeOfIBEChamber = ChamberConfig.IBE_Type
            IBEPanel.SLContainerBox.RotationFixture.ChamberPanelType = ChamberConfig.IBE_Type
            IBEPanel.SLContainerBox.RotationFixture.HasShutterOnFixture = (ChamberConfig.ShutterVisible AndAlso ChamberConfig.FixtureShutterVisible)
            IBEPanel.SLContainerBox.RotationFixture.ShutterOnFixtureUsedByGalilVisible = ChamberConfig.ShutterOnFixtureUsedByGalilVisible
            IBEPanel.SLContainerBox.ShutterInstalled = (ChamberConfig.ShutterVisible AndAlso (Not ChamberConfig.FixtureShutterVisible))
            IBEPanel.SLFixture.TypeOfIBEChamber = ChamberConfig.IBE_Type
            IBEPanel.txtGridSerialNumber.Text = ChamberConfig.Grid_SerialNumber
            IBEPanel.txtGridID.Text = ChamberConfig.Grid_ID
            IBEPanel.cmbRebuildLevel.SelectedIndex = ChamberConfig.Grid_RebuildLevel

            IBEPanel.SLInterlocks.SourceVisible = ChamberConfig.ChamberInterlock_SourceWaterVisible
            IBEPanel.SLInterlocks.TurboWaterVisible = ChamberConfig.ChamberInterlock_TurboWaterVisible
            IBEPanel.SLInterlocks.FixtureWaterVisible = ChamberConfig.ChamberInterlock_FixtureWaterVisible
            IBEPanel.SLInterlocks.PanelVisible = ChamberConfig.ChamberInterlock_PanelInterlockVisible
            IBEPanel.SLInterlocks.ForeLineVisible = ChamberConfig.ChamberInterlock_ForelinePressureVisible
            IBEPanel.SLInterlocks.FixtureWaterBugVisible = ChamberConfig.ChamberInterlock_FixtureWaterBugVisible
            IBEPanel.SLInterlocks.ChamPressVisible = ChamberConfig.ChamberInterlock_ChamberPressureVisible
            IBEPanel.SLInterlocks.AirPressureVisible = ChamberConfig.Interlock_AirPressure_Visible
            IBEPanel.SLInterlocks.ArrangePanel()
            IBEPanel.RunRecipe.Top = IBEPanel.SLInterlocks.Top + IBEPanel.SLInterlocks.Height + 5
            IBEPanel.SLContainerBox.RotationFixture.TiltAngleReferenceAsLegacy = ChamberConfig.TiltAngleReferenceAsLegacy

            ' Set default angle to fixture control
            If ChamberConfig.TiltAngleReferenceAsLegacy Then
                IBEPanel.SLContainerBox.RotationFixture.RotationAngle = 90
            Else
                IBEPanel.SLContainerBox.RotationFixture.RotationAngle = 0
            End If

            'Chiller
            If ChamberConfig.ChillerVisible = True Then
                IBEPanel.ChillerControl.Visible = True
            Else
                IBEPanel.ChillerControl.Visible = False
            End If

            'cryo, wp
            If ChamberConfig.CryoVisible = True And ChamberConfig.WaterPumpVisible = False Then
                IBEPanel.SLContainerBox.FullyInstalled = False
                IBEPanel.SLContainerBox.NoWaterPumpInstalled = True
                IBEPanel.SLContainerBox.NoCryoInstalled = False
            ElseIf ChamberConfig.CryoVisible = False And ChamberConfig.WaterPumpVisible = True Then
                IBEPanel.SLContainerBox.FullyInstalled = False
                IBEPanel.SLContainerBox.NoWaterPumpInstalled = False
                IBEPanel.SLContainerBox.NoCryoInstalled = True
            ElseIf ChamberConfig.CryoVisible = False And ChamberConfig.WaterPumpVisible = False Then
                IBEPanel.SLContainerBox.FullyInstalled = False
                IBEPanel.SLContainerBox.NoWaterPumpInstalled = False
                IBEPanel.SLContainerBox.NoCryoInstalled = False
            Else
                IBEPanel.SLContainerBox.FullyInstalled = True
                IBEPanel.SLContainerBox.NoWaterPumpInstalled = False
                IBEPanel.SLContainerBox.NoCryoInstalled = False
            End If

            IBEPanel.SetLabelIGIsolation(IBEPanel.SLContainerBox.FullyInstalled)

            If ChamberConfig.TurboPumpModel = SystemModule.TurboPump_Model.Leybold OrElse ChamberConfig.TurboPumpModel = SystemModule.TurboPump_Model.Shimadzu Then
                IBEPanel.SLContainerBox.txtRampingPercent.Visible = True
            End If

            IBEPanel.SetGas1Info(ChamberConfig.Gas1Type, ChamberConfig.Gas1ShutoffPresent, ChamberConfig.Gas1SupplyPresent)
            IBEPanel.SetGas2Info(ChamberConfig.Gas2Type, ChamberConfig.gas2ShutoffPresent, ChamberConfig.Gas2SupplyPresent)
            IBEPanel.SetGas3Info(ChamberConfig.Gas3Type, ChamberConfig.gas3ShutoffPresent, ChamberConfig.Gas3SupplyPresent)
            IBEPanel.SetGas4Info(ChamberConfig.Gas4Type, ChamberConfig.gas4ShutoffPresent, ChamberConfig.Gas4SupplyPresent)
            IBEPanel.SetPBNGasInfo(ChamberConfig.PBNGasType)
            IBEPanel.SetGasLineTotalVisible()
            IBEPanel.DiverterGasValveInstalled = ChamberConfig.DiverterGasValveVisible
            IBEPanel.GetGasEndIndex()
            IBEPanel.SetInternalShutterVisible(ChamberConfig.InternalShutterInstalled)
            IBEPanel.ArrangeSourceBeam(ChamberConfig)

            '2017-02-08: Dua Tran,
            IBEPanel.txtGas1_SourceTab.MinimumValueHighlightedGreen = ChamberConfig.SystemInterlockGas1Minimum
            IBEPanel.txtGas2_SourceTab.MinimumValueHighlightedGreen = ChamberConfig.SystemInterlockGas2Minimum
            IBEPanel.txtGas3_SourceTab.MinimumValueHighlightedGreen = ChamberConfig.SystemInterlockGas3Minimum
            IBEPanel.txtGas4_SourceTab.MinimumValueHighlightedGreen = ChamberConfig.SystemInterlockGas4Minimum
            IBEPanel.txtPBNGas_SourceTab.MinimumValueHighlightedGreen = 0.5

            '2017-04-12: Dua Tran.
            If (ChamberConfig.FastTiltInstalled = False Or ChamberConfig.SupportTiltSweepMode = False) Then
                IBEPanel.SLFixture.LoadingStaticTiltAngle()
            End If

            '2017-05-24: Dua Tran.
            If ChamberConfig.ShutterVisible = False Then
                IBEPanel.SLFixture.DissableButtonShutter()
            End If

            Select Case IBEPanel.Name
                Case Equipments.Chamber1.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM1.Text = ChamberConfig.SourceUsageTimeLimit
                    ContainerForm.SystemSetup.txtWarningKWH_PM1.Text = ChamberConfig.SourceUsageTimeWarning
                    ContainerForm.SystemSetup.txtUsageKWH_PM1.Text = ChamberConfig.SourceUsageTime
                    ContainerForm.SystemSetup.txtTarMaterialPM1.Enabled = False
                    'ContainerForm.SystemSetup.txtTarMaterialPM1.BackColor = System.Drawing.SystemColors.Control
                    'ContainerForm.ProcessPanel.CX_PM1.HasShutter = ChamberConfig.ShutterVisible
                    'ContainerForm.CassettesPanel.CX_PM1.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.SystemSetup.txtMaxKWHPM1.Text = ChamberConfig.Max_KWH_Source
                    ContainerForm.SystemSetup.txtEtchRatePM1.Text = ChamberConfig.Etch_Rate
                    ContainerForm.SystemSetup.txtEtchRatePM1.Enabled = True
                    ContainerForm.SystemSetup.lblSlowRough.Enabled = True
                    ContainerForm.SystemSetup.txtLimitShieldsPM1.Text = ChamberConfig.ShieldsQuartzLimit
                    ContainerForm.SystemSetup.txtWarningShieldsPM1.Text = ChamberConfig.ShieldsQuartzWarning
                    ContainerForm.SystemSetup.txtMaxShieldsPM1.Text = ChamberConfig.Max_KWH_ShieldsQuartz
                    ContainerForm.SystemSetup.PM1ChamberType = SystemModule.ModuleType.IBE

                Case Equipments.Chamber2.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM2.Text = ChamberConfig.SourceUsageTimeLimit
                    ContainerForm.SystemSetup.txtWarningKWH_PM2.Text = ChamberConfig.SourceUsageTimeWarning
                    ContainerForm.SystemSetup.txtUsageKWH_PM2.Text = ChamberConfig.SourceUsageTime
                    ContainerForm.SystemSetup.txtTarMaterialPM2.Enabled = False
                    'ContainerForm.SystemSetup.txtTarMaterialPM2.BackColor = System.Drawing.SystemColors.Control
                    'ContainerForm.ProcessPanel.CX_PM2.HasShutter = ChamberConfig.ShutterVisible
                    'ContainerForm.CassettesPanel.CX_PM2.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.SystemSetup.txtMaxKWHPM2.Text = ChamberConfig.Max_KWH_Source
                    ContainerForm.SystemSetup.txtEtchRatePM2.Text = ChamberConfig.Etch_Rate
                    ContainerForm.SystemSetup.txtEtchRatePM2.Enabled = True
                    ContainerForm.SystemSetup.Label5.Enabled = True
                    ContainerForm.SystemSetup.txtLimitShieldsPM2.Text = ChamberConfig.ShieldsQuartzLimit
                    ContainerForm.SystemSetup.txtWarningShieldsPM2.Text = ChamberConfig.ShieldsQuartzWarning
                    ContainerForm.SystemSetup.txtMaxShieldsPM2.Text = ChamberConfig.Max_KWH_ShieldsQuartz
                    ContainerForm.SystemSetup.PM2ChamberType = SystemModule.ModuleType.IBE

                Case Equipments.Chamber3.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM3.Text = ChamberConfig.SourceUsageTimeLimit
                    ContainerForm.SystemSetup.txtWarningKWH_PM3.Text = ChamberConfig.SourceUsageTimeWarning
                    ContainerForm.SystemSetup.txtUsageKWH_PM3.Text = ChamberConfig.SourceUsageTime
                    ContainerForm.SystemSetup.txtTarMaterialPM3.Enabled = False
                    'ContainerForm.SystemSetup.txtTarMaterialPM3.BackColor = System.Drawing.SystemColors.Control
                    'ContainerForm.ProcessPanel.CX_PM3.HasShutter = ChamberConfig.ShutterVisible
                    'ContainerForm.CassettesPanel.CX_PM3.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.SystemSetup.txtMaxKWHPM3.Text = ChamberConfig.Max_KWH_Source
                    ContainerForm.SystemSetup.txtEtchRatePM3.Text = ChamberConfig.Etch_Rate
                    ContainerForm.SystemSetup.txtEtchRatePM3.Enabled = True
                    ContainerForm.SystemSetup.Label10.Enabled = True
                    ContainerForm.SystemSetup.txtLimitShieldsPM3.Text = ChamberConfig.ShieldsQuartzLimit
                    ContainerForm.SystemSetup.txtWarningShieldsPM3.Text = ChamberConfig.ShieldsQuartzWarning
                    ContainerForm.SystemSetup.txtMaxShieldsPM3.Text = ChamberConfig.Max_KWH_ShieldsQuartz
                    ContainerForm.SystemSetup.PM3ChamberType = SystemModule.ModuleType.IBE

#If AVP_CX_STYLE = "CX4" Then
                    AVPLib.Log.avpLogger.Error("Missing Load IBE Items For CX4")
#End If
            End Select

            ' Set first-load status and config for PMControl
            Dim objProcPM As PMControl = Nothing
            Dim objCassetPM As PMControl = Nothing
            GetPMControl(IBEPanel.Name, objProcPM, objCassetPM)
            If objProcPM IsNot Nothing AndAlso objCassetPM IsNot Nothing Then
                objProcPM.SetDefaultStatus()
                objCassetPM.SetDefaultStatus()

                objProcPM.HasShutter = (ChamberConfig.ShutterVisible AndAlso (Not ChamberConfig.FixtureShutterVisible))
                objCassetPM.HasShutter = (ChamberConfig.ShutterVisible AndAlso (Not ChamberConfig.FixtureShutterVisible))
                objProcPM.IBEShutterOnFixture = (ChamberConfig.ShutterVisible AndAlso ChamberConfig.FixtureShutterVisible)
                objCassetPM.IBEShutterOnFixture = (ChamberConfig.ShutterVisible AndAlso ChamberConfig.FixtureShutterVisible)

                objProcPM.Repaint()
                objCassetPM.Repaint()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Friend Sub LoadCoronaItem(ByVal objCoronaPanel As AVP_Robot_Project.CoronaPanel, ByVal ChamberConfig As AVPLib.SystemModule)
        Try
            AVPLib.Log.avpLogger.Error("Missing Load Corona Items For CX4")
            Dim objEQ As DataManagerment.CoronaChamber = Nothing
            objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(objCoronaPanel.Name)
            objCoronaPanel.RunRecipe.Real_Device_Enable = RobotConfigurationValues.REAL_DEVICE_INSTALLED
            Dim strEmpty As String = String.Empty

            objCoronaPanel.GasController.Gas1Name = ChamberConfig.Gas1Type
            objCoronaPanel.GasController.Gas2Name = ChamberConfig.Gas2Type
            objCoronaPanel.GasController.Gas3Name = ChamberConfig.Gas3Type
            objCoronaPanel.GasController.Gas4Name = ChamberConfig.Gas4Type
            objCoronaPanel.GasController.Gas5Name = ChamberConfig.Gas5Type

            objCoronaPanel.GasController.txtGas1Right.IsReadBack = (ChamberConfig.Gas1Name = strEmpty)
            objCoronaPanel.GasController.txtGas2Right.IsReadBack = (ChamberConfig.Gas2Name = strEmpty)
            objCoronaPanel.GasController.txtGas3Right.IsReadBack = (ChamberConfig.Gas3Name = strEmpty)
            objCoronaPanel.GasController.txtGas4Right.IsReadBack = (ChamberConfig.Gas4Name = strEmpty)
            objCoronaPanel.GasController.txtGas5Right.IsReadBack = (ChamberConfig.Gas5Name = strEmpty)

            objCoronaPanel.TableControl.NumberOfWafer = ChamberConfig.MaxNumberOfSlot
            objCoronaPanel.HeaterVisible = ChamberConfig.HeaterZone1Installed Or ChamberConfig.HeaterZone2Installed
            objCoronaPanel.Heater1Visible = ChamberConfig.HeaterZone1Installed
            objCoronaPanel.Heater2Visible = ChamberConfig.HeaterZone2Installed

            If Not ChamberConfig.RFTargetPowerVisible AndAlso ChamberConfig.DCTargetPowerVisible Then
                objCoronaPanel.IsDC_or_RF = "DC"
                objCoronaPanel.RFTargetPowerSupply.TypeOfDC(ChamberConfig.DCTargetPowerModel)
                objCoronaPanel.ResizeRFTargetPowerSuply()
            End If
            objCoronaPanel.WaterPumpInstalled = ChamberConfig.WaterPumpVisible
            objCoronaPanel.VatControlVisible = ChamberConfig.VatValveControllerVisible
            objCoronaPanel.btnComMechanicalPump.Visible = ChamberConfig.MPumpSerialVisible

            objCoronaPanel.GasController.Gas1Visible = ChamberConfig.Gas1Install
            objCoronaPanel.GasController.Gas2Visible = ChamberConfig.Gas2Install
            objCoronaPanel.GasController.Gas3Visible = ChamberConfig.Gas3Install
            objCoronaPanel.GasController.Gas4Visible = ChamberConfig.Gas4Install
            objCoronaPanel.GasController.Gas5Visible = ChamberConfig.Gas5Install
            objCoronaPanel.GasInjectionVisible = ChamberConfig.GasInjectionInstall
            objCoronaPanel.SupportMainSecondDistributionValves = ChamberConfig.IsSupportMainSecondDistributionValves
            objCoronaPanel.IGIsoValveVisible = ChamberConfig.IGIsoValveInstalled
            objCoronaPanel.Gas5Visible = ChamberConfig.Gas5Install
            objCoronaPanel.Gas4Visible = ChamberConfig.Gas4Install
            objCoronaPanel.Gas3Visible = ChamberConfig.Gas3Install
            objCoronaPanel.Gas2Visible = ChamberConfig.Gas2Install
            objCoronaPanel.Gas1Visible = ChamberConfig.Gas1Install

            objCoronaPanel.CoronaChamber.Shutter1Visible = ChamberConfig.ShutterVisible
            objCoronaPanel.CoronaChamber.Shutter2Visible = ChamberConfig.Shutter2Visible
            objCoronaPanel.CoronaChamber.Shutter3Visible = ChamberConfig.Shutter3Visible
            objCoronaPanel.CoronaChamber.Shutter4Visible = ChamberConfig.Shutter4Visible

            objCoronaPanel.RFTargetPowerSupply.Target1Install = ChamberConfig.TargetVisible
            objCoronaPanel.RFTargetPowerSupply.Target2Install = ChamberConfig.Target2Visible
            objCoronaPanel.RFTargetPowerSupply.Target3Install = ChamberConfig.Target3Visible
            objCoronaPanel.RFTargetPowerSupply.Target4Install = ChamberConfig.Target4Visible
            objCoronaPanel.RFTargetPowerSupply.ArrangTarget()
            objCoronaPanel.GetGasEndIndex()
            objCoronaPanel.RFTargetPowerSupply.TypeOfDC(ChamberConfig.DCTargetPowerModel)

            objCoronaPanel.CoronaTarget.T1Installed = ChamberConfig.TargetVisible
            objCoronaPanel.CoronaTarget.T2Installed = ChamberConfig.Target2Visible
            objCoronaPanel.CoronaTarget.T3Installed = ChamberConfig.Target3Visible
            objCoronaPanel.CoronaTarget.T4Installed = ChamberConfig.Target4Visible

            objCoronaPanel.CoronaTarget.T1Text = objCoronaPanel.CoronaTarget.T1Text & "-" & ChamberConfig.Target_Material
            objCoronaPanel.CoronaTarget.T2Text = objCoronaPanel.CoronaTarget.T2Text & "-" & ChamberConfig.Target_Material1
            objCoronaPanel.CoronaTarget.T3Text = objCoronaPanel.CoronaTarget.T3Text & "-" & ChamberConfig.Target_Material2
            objCoronaPanel.CoronaTarget.T4Text = objCoronaPanel.CoronaTarget.T4Text & "-" & ChamberConfig.Target_Material3
            objCoronaPanel.CoronaTarget.Repaint()
            ' update water pump install
            objCoronaPanel.TurboControl.IsWaterPumpInstalled = ChamberConfig.WaterPumpVisible

            '2012-01-03 Tin Pham added
            Dim corona As String = objCoronaPanel.RFTargetPowerSupply.txtForwardPowerRight.TypeOfChamberSupport.ToString()
            objCoronaPanel.RFTargetPowerSupply.txtForwardPowerRight.SourceOfMessageBox = objCoronaPanel.Name & "." & corona & ".TargetPowerSupply"
            objCoronaPanel.RFTargetPowerSupply.txtC1Right.SourceOfMessageBox = objCoronaPanel.Name & "." & corona & ".TargetPowerSupply"
            objCoronaPanel.RFTargetPowerSupply.txtC2Right.SourceOfMessageBox = objCoronaPanel.Name & "." & corona & ".TargetPowerSupply"
            objCoronaPanel.RFTargetPowerSupply.txtDCForwardPowerRight.SourceOfMessageBox = objCoronaPanel.Name & "." & corona & ".TargetPowerSupply"
            objCoronaPanel.RFTargetPowerSupply.txtPulseFrequencyRight.SourceOfMessageBox = objCoronaPanel.Name & "." & corona & ".TargetPowerSupply"
            objCoronaPanel.RFTargetPowerSupply.txtPulseWidthRight.SourceOfMessageBox = objCoronaPanel.Name & "." & corona & ".TargetPowerSupply"
            objCoronaPanel.RFTargetPowerSupply.txtRampTimeRight.SourceOfMessageBox = objCoronaPanel.Name & "." & corona & ".TargetPowerSupply"
            objCoronaPanel.RFTargetPowerSupply.ChamberName = objCoronaPanel.Name

            If ChamberConfig.BiasPowerVisible Then
                objCoronaPanel.BiasPowerSupply.txtForwardPowerRight.SourceOfMessageBox = objCoronaPanel.Name & "." & corona & ".BiasPowerSupply"
                objCoronaPanel.BiasPowerSupply.txtVoltageRight.SourceOfMessageBox = objCoronaPanel.Name & "." & corona & ".BiasPowerSupply"
                objCoronaPanel.BiasPowerSupply.txtC1Right.SourceOfMessageBox = objCoronaPanel.Name & "." & corona & ".BiasPowerSupply"
                objCoronaPanel.BiasPowerSupply.txtC2Right.SourceOfMessageBox = objCoronaPanel.Name & "." & corona & ".BiasPowerSupply"
                objCoronaPanel.BiasPowerSupply.ChamberName = objCoronaPanel.Name
            Else
                objCoronaPanel.BiasPowerSupply.Visible = ChamberConfig.BiasPowerVisible
                objCoronaPanel.PVD4Interlock.Top = objCoronaPanel.BiasPowerSupply.Top
            End If

            'Invisible ChamberInterlock when they not install
            objCoronaPanel.PVD4Interlock.TurboWater_Visible = ChamberConfig.ChamberInterlock_TurboWaterVisible
            objCoronaPanel.PVD4Interlock.TargetMBWater_Visible = ChamberConfig.Target_Matchbox_Water_Visible
            objCoronaPanel.PVD4Interlock.BiasMBWater_Visible = ChamberConfig.Bias_Matchbox_Water_Visible
            objCoronaPanel.PVD4Interlock.Target13Water_Visible = ChamberConfig.Interlock_Target13Water_Visible
            objCoronaPanel.PVD4Interlock.Target24Water_Visible = ChamberConfig.Interlock_Target24Water_Visible
            objCoronaPanel.PVD4Interlock.SubTableWater_Visible = ChamberConfig.Interlock_SubstrateTableWater_Visible
            objCoronaPanel.PVD4Interlock.AirPressure_Visible = ChamberConfig.Interlock_AirPressure_Visible
            objCoronaPanel.PVD4Interlock.ArrangeInterlock()
            '-------------------------
            'number of wafer ->>add here
            objCoronaPanel.CoronaChamber.NumberOfWafer = ChamberConfig.MaxNumberOfSlot

            'objEQ.Etch_Rate = ChamberConfig.Etch_Rate

            'objCoronaPanel.PM_DeviceNet = ChamberConfig.PM_DeviceNet
            objCoronaPanel.ROR_Litter_Value = ChamberConfig.Litter_Value

            'objCoronaPanel.SLContainerBox.TypeOfIBEChamber = ChamberConfig.IBE_Type
            'objCoronaPanel.SLContainerBox.RotationFixture.IBEPanelType = ChamberConfig.IBE_Type
            'objCoronaPanel.SLFixture.TypeOfIBEChamber = ChamberConfig.IBE_Type

            'cryo, wp
            'If ChamberConfig.CryoVisible = True And ChamberConfig.WaterPumpVisible = False Then
            '    objCoronaPanel.SLContainerBox.FullyInstalled = False
            '    objCoronaPanel.SLContainerBox.NoWaterPumpInstalled = True
            '    objCoronaPanel.SLContainerBox.NoCryoInstalled = False
            'ElseIf ChamberConfig.CryoVisible = False And ChamberConfig.WaterPumpVisible = True Then
            '    objCoronaPanel.SLContainerBox.FullyInstalled = False
            '    objCoronaPanel.SLContainerBox.NoWaterPumpInstalled = False
            '    objCoronaPanel.SLContainerBox.NoCryoInstalled = True
            'ElseIf ChamberConfig.CryoVisible = False And ChamberConfig.WaterPumpVisible = False Then
            '    objCoronaPanel.SLContainerBox.FullyInstalled = False
            '    objCoronaPanel.SLContainerBox.NoWaterPumpInstalled = False
            '    objCoronaPanel.SLContainerBox.NoCryoInstalled = False
            'Else
            '    objCoronaPanel.SLContainerBox.FullyInstalled = True
            '    objCoronaPanel.SLContainerBox.NoWaterPumpInstalled = False
            '    objCoronaPanel.SLContainerBox.NoCryoInstalled = False
            'End If

            objCoronaPanel.FilMetricControl.Visible = ChamberConfig.FilMetricDevice_Installed
            objCoronaPanel.FilMetricControl.Top = objCoronaPanel.PVD4Interlock.Bottom

            If ChamberConfig.TurboPumpModel = SystemModule.TurboPump_Model.Leybold OrElse ChamberConfig.TurboPumpModel = SystemModule.TurboPump_Model.Shimadzu Then
                objCoronaPanel.txtRampingPercent.Visible = True
            Else
                objCoronaPanel.btnWaterPumpOn.Location = New Point(856, 344)
            End If

            Select Case objCoronaPanel.Name
                Case Equipments.Chamber1.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM1.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.txtWarningKWH_PM1.Text = STR_CLICK_FOR_DETAIL 'ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.txtUsageKWH_PM1.Text = STR_CLICK_FOR_DETAIL 'ChamberConfig.SourceUsageTime
                    ContainerForm.SystemSetup.txtMaxKWHPM1.Text = STR_CLICK_FOR_DETAIL

                    ' shield/quartz
                    ContainerForm.SystemSetup.txtShieldPM1.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtLimitShieldsPM1.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtWarningShieldsPM1.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtMaxShieldsPM1.Text = STR_CLICK_FOR_DETAIL

                    ContainerForm.SystemSetup.txtTarMaterialPM1.Enabled = True
                    ContainerForm.SystemSetup.txtTarMaterialPM1.BackColor = Color.White
                    ContainerForm.SystemSetup.txtShieldPM1.BackColor = Color.White
                    ContainerForm.SystemSetup.txtUsageKWH_PM1.BackColor = Color.White
                    ContainerForm.ProcessPanel.CX_PM1.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.CassettesPanel.CX_PM1.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.SystemSetup.PM1ChamberType = SystemModule.ModuleType.PVD4

                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T1_Limit = ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T2_Limit = ChamberConfig.Alarm_KWH1
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T3_Limit = ChamberConfig.Alarm_KWH2
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T4_Limit = ChamberConfig.Alarm_KWH3
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T5_Limit = ChamberConfig.Alarm_KWH4

                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T1_Warning = ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T2_Warning = ChamberConfig.Warning_KWH1
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T3_Warning = ChamberConfig.Warning_KWH2
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T4_Warning = ChamberConfig.Warning_KWH3
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T5_Warning = ChamberConfig.Warning_KWH4

                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T1_Max = ChamberConfig.Max_KWH_Source
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T2_Max = ChamberConfig.Max_KWH_Source1
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T3_Max = ChamberConfig.Max_KWH_Source2
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T4_Max = ChamberConfig.Max_KWH_Source3
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T5_Max = ChamberConfig.Max_KWH_Source4

                    ContainerForm.SystemSetup.txtTarMaterialPM1.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Target_Material3

                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T1_Material = ChamberConfig.Target_Material
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T2_Material = ChamberConfig.Target_Material1
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T3_Material = ChamberConfig.Target_Material2
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T4_Material = ChamberConfig.Target_Material3
                    objCoronaPanel.PMSystemSetupPopUpPanel = ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel

                Case Equipments.Chamber2.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM2.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.txtWarningKWH_PM2.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.txtUsageKWH_PM2.Text = STR_CLICK_FOR_DETAIL '  ChamberConfig.SourceUsageTime
                    ContainerForm.SystemSetup.txtMaxKWHPM2.Text = STR_CLICK_FOR_DETAIL

                    ' shield/quartz
                    ContainerForm.SystemSetup.txtShieldsPM2.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtLimitShieldsPM2.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtWarningShieldsPM2.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtMaxShieldsPM2.Text = STR_CLICK_FOR_DETAIL

                    ContainerForm.SystemSetup.txtTarMaterialPM2.Enabled = True
                    ContainerForm.SystemSetup.txtTarMaterialPM2.BackColor = Color.White
                    ContainerForm.SystemSetup.txtShieldsPM2.BackColor = Color.White
                    ContainerForm.SystemSetup.txtUsageKWH_PM2.BackColor = Color.White
                    ContainerForm.ProcessPanel.CX_PM2.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.CassettesPanel.CX_PM2.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.SystemSetup.PM2ChamberType = SystemModule.ModuleType.PVD4

                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T1_Limit = ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T2_Limit = ChamberConfig.Alarm_KWH1
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T3_Limit = ChamberConfig.Alarm_KWH2
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T4_Limit = ChamberConfig.Alarm_KWH3
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T5_Limit = ChamberConfig.Alarm_KWH4

                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T1_Warning = ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T2_Warning = ChamberConfig.Warning_KWH1
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T3_Warning = ChamberConfig.Warning_KWH2
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T4_Warning = ChamberConfig.Warning_KWH3
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T5_Warning = ChamberConfig.Warning_KWH4

                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T1_Max = ChamberConfig.Max_KWH_Source
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T2_Max = ChamberConfig.Max_KWH_Source1
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T3_Max = ChamberConfig.Max_KWH_Source2
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T4_Max = ChamberConfig.Max_KWH_Source3
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T5_Max = ChamberConfig.Max_KWH_Source4

                    ContainerForm.SystemSetup.txtTarMaterialPM2.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Target_Material3

                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T1_Material = ChamberConfig.Target_Material
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T2_Material = ChamberConfig.Target_Material1
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T3_Material = ChamberConfig.Target_Material2
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T4_Material = ChamberConfig.Target_Material3
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T5_Material = ChamberConfig.Target_Material4

                    objCoronaPanel.PMSystemSetupPopUpPanel = ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel

                Case Equipments.Chamber3.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM3.Text = STR_CLICK_FOR_DETAIL '  ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.txtWarningKWH_PM3.Text = STR_CLICK_FOR_DETAIL '  ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.txtUsageKWH_PM3.Text = STR_CLICK_FOR_DETAIL '  ChamberConfig.SourceUsageTime
                    ContainerForm.SystemSetup.txtTarMaterialPM3.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Target_Material3
                    ContainerForm.SystemSetup.txtMaxKWHPM3.Text = STR_CLICK_FOR_DETAIL

                    ' shield/quartz
                    ContainerForm.SystemSetup.txtShieldsPM3.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtLimitShieldsPM3.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtWarningShieldsPM3.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtMaxShieldsPM3.Text = STR_CLICK_FOR_DETAIL

                    ContainerForm.SystemSetup.txtTarMaterialPM3.Enabled = True
                    ContainerForm.SystemSetup.txtShieldsPM3.BackColor = Color.White
                    ContainerForm.SystemSetup.txtTarMaterialPM3.BackColor = Color.White
                    ContainerForm.SystemSetup.txtUsageKWH_PM3.BackColor = Color.White
                    ContainerForm.ProcessPanel.CX_PM3.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.CassettesPanel.CX_PM3.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.SystemSetup.PM3ChamberType = SystemModule.ModuleType.PVD4

                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T1_Limit = ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T2_Limit = ChamberConfig.Alarm_KWH1
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T3_Limit = ChamberConfig.Alarm_KWH2
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T4_Limit = ChamberConfig.Alarm_KWH3
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T5_Limit = ChamberConfig.Alarm_KWH4

                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T1_Warning = ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T2_Warning = ChamberConfig.Warning_KWH1
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T3_Warning = ChamberConfig.Warning_KWH2
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T4_Warning = ChamberConfig.Warning_KWH3
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T5_Warning = ChamberConfig.Warning_KWH4

                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T1_Max = ChamberConfig.Max_KWH_Source
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T2_Max = ChamberConfig.Max_KWH_Source1
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T3_Max = ChamberConfig.Max_KWH_Source2
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T4_Max = ChamberConfig.Max_KWH_Source3
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T5_Max = ChamberConfig.Max_KWH_Source4

                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T1_Material = ChamberConfig.Target_Material
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T2_Material = ChamberConfig.Target_Material1
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T3_Material = ChamberConfig.Target_Material2
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T4_Material = ChamberConfig.Target_Material3
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T5_Material = ChamberConfig.Target_Material4

                    objCoronaPanel.PMSystemSetupPopUpPanel = ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel
            End Select

            objCoronaPanel.TableControl.IsWaferLiftInstalled = ChamberConfig.WaferLiftInstalled
            objCoronaPanel.TableControl.SupportTSDMode = ChamberConfig.ChuckPositionTSDRef
            objCoronaPanel.TableControl.TargetToHomeDistance = ChamberConfig.TargetToHomeDistance

            ' Set first-load status and config for PMControl
            Dim objProcPM As PMControl = Nothing
            Dim objCassetPM As PMControl = Nothing
            GetPMControl(objCoronaPanel.Name, objProcPM, objCassetPM)
            If objProcPM IsNot Nothing AndAlso objCassetPM IsNot Nothing Then
                objProcPM.NumberOfWafer = ChamberConfig.MaxNumberOfSlot
                objProcPM.T1Installed = ChamberConfig.TargetVisible
                objProcPM.T2Installed = ChamberConfig.Target2Visible
                objProcPM.T3Installed = ChamberConfig.Target3Visible
                objProcPM.T4Installed = ChamberConfig.Target4Visible

                objCassetPM.NumberOfWafer = ChamberConfig.MaxNumberOfSlot
                objCassetPM.T1Installed = ChamberConfig.TargetVisible
                objCassetPM.T2Installed = ChamberConfig.Target2Visible
                objCassetPM.T3Installed = ChamberConfig.Target3Visible
                objCassetPM.T4Installed = ChamberConfig.Target4Visible

                objProcPM.Repaint()
                objCassetPM.Repaint()
            End If

            objCoronaPanel.UpdateGUISetting()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Friend Sub LoadPVD5TItem(ByVal objPVD5TPanel As AVP_Robot_Project.PVD5TPanel, ByVal ChamberConfig As AVPLib.SystemModule)
        Try
            AVPLib.Log.avpLogger.Error("Missing Load PVD5T Items For CX4")
            Dim objEQ As DataManagerment.CoronaChamber = Nothing
            objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(objPVD5TPanel.Name)
            objPVD5TPanel.RunRecipe.Real_Device_Enable = RobotConfigurationValues.REAL_DEVICE_INSTALLED
            Dim strEmpty As String = String.Empty

            objPVD5TPanel.GasController.Gas1Name = ChamberConfig.Gas1Type
            objPVD5TPanel.GasController.Gas2Name = ChamberConfig.Gas2Type
            objPVD5TPanel.GasController.Gas3Name = ChamberConfig.Gas3Type
            objPVD5TPanel.GasController.Gas4Name = ChamberConfig.Gas4Type
            objPVD5TPanel.GasController.Gas5Name = ChamberConfig.Gas5Type

            objPVD5TPanel.GasController.txtGas1Right.IsReadBack = (ChamberConfig.Gas1Name = strEmpty)
            objPVD5TPanel.GasController.txtGas2Right.IsReadBack = (ChamberConfig.Gas2Name = strEmpty)
            objPVD5TPanel.GasController.txtGas3Right.IsReadBack = (ChamberConfig.Gas3Name = strEmpty)
            objPVD5TPanel.GasController.txtGas4Right.IsReadBack = (ChamberConfig.Gas4Name = strEmpty)
            objPVD5TPanel.GasController.txtGas5Right.IsReadBack = (ChamberConfig.Gas5Name = strEmpty)

            objPVD5TPanel.TableControl.NumberOfWafer = ChamberConfig.MaxNumberOfSlot
            objPVD5TPanel.HeaterVisible = ChamberConfig.HeaterZone1Installed Or ChamberConfig.HeaterZone2Installed
            objPVD5TPanel.Heater1Visible = ChamberConfig.HeaterZone1Installed
            objPVD5TPanel.Heater2Visible = ChamberConfig.HeaterZone2Installed

            objPVD5TPanel.InitTargetPowerSupply(ChamberConfig)

            objPVD5TPanel.WaterPumpInstalled = ChamberConfig.WaterPumpVisible
            objPVD5TPanel.VatControlVisible = ChamberConfig.VatValveControllerVisible
            objPVD5TPanel.btnComMechanicalPump.Visible = ChamberConfig.MPumpSerialVisible
            objPVD5TPanel.TurboPumpVisible = ChamberConfig.TurboPumpVisible
            objPVD5TPanel.CryoControlVisible = ChamberConfig.CryoVisible

            objPVD5TPanel.GasController.Gas1Visible = ChamberConfig.Gas1Install
            objPVD5TPanel.GasController.Gas2Visible = ChamberConfig.Gas2Install
            objPVD5TPanel.GasController.Gas3Visible = ChamberConfig.Gas3Install
            objPVD5TPanel.GasController.Gas4Visible = ChamberConfig.Gas4Install
            objPVD5TPanel.GasController.Gas5Visible = ChamberConfig.Gas5Install
            objPVD5TPanel.IGIsoValveVisible = ChamberConfig.IGIsoValveInstalled
            objPVD5TPanel.Gas5Visible = ChamberConfig.Gas5Install
            objPVD5TPanel.Gas4Visible = ChamberConfig.Gas4Install
            objPVD5TPanel.Gas3Visible = ChamberConfig.Gas3Install
            objPVD5TPanel.Gas2Visible = ChamberConfig.Gas2Install
            objPVD5TPanel.Gas1Visible = ChamberConfig.Gas1Install

            objPVD5TPanel.CoronaChamber.Shutter1Visible = ChamberConfig.ShutterVisible
            objPVD5TPanel.CoronaChamber.Shutter2Visible = ChamberConfig.ShutterVisible
            objPVD5TPanel.CoronaChamber.Shutter3Visible = ChamberConfig.ShutterVisible
            objPVD5TPanel.CoronaChamber.Shutter4Visible = ChamberConfig.ShutterVisible
            objPVD5TPanel.CoronaChamber.Shutter5Visible = ChamberConfig.ShutterVisible

            'objPVD5TPanel.RFTargetPowerSupply.Target1Install = ChamberConfig.TargetVisible
            'objPVD5TPanel.RFTargetPowerSupply.Target2Install = ChamberConfig.Target2Visible
            'objPVD5TPanel.RFTargetPowerSupply.Target3Install = ChamberConfig.Target3Visible
            'objPVD5TPanel.RFTargetPowerSupply.Target4Install = ChamberConfig.Target4Visible
            'objPVD5TPanel.RFTargetPowerSupply.ArrangTarget()

            objPVD5TPanel.TabTargetPowerSupply.SetupTarget(ChamberConfig.TargetVisible, ChamberConfig.Target2Visible,
                                                            ChamberConfig.Target3Visible, ChamberConfig.Target4Visible, ChamberConfig.Target5Visible)


            objPVD5TPanel.GetGasEndIndex()
            'objPVD5TPanel.RFTargetPowerSupply.TypeOfDC(ChamberConfig.DCTargetPowerModel)

            objPVD5TPanel.CoronaTarget.T1Installed = ChamberConfig.TargetVisible
            objPVD5TPanel.CoronaTarget.T2Installed = ChamberConfig.Target2Visible
            objPVD5TPanel.CoronaTarget.T3Installed = ChamberConfig.Target3Visible
            objPVD5TPanel.CoronaTarget.T4Installed = ChamberConfig.Target4Visible
            objPVD5TPanel.CoronaTarget.T5Installed = ChamberConfig.Target5Visible

            objPVD5TPanel.CoronaTarget.T1Text = objPVD5TPanel.CoronaTarget.T1Text & "-" & ChamberConfig.Target_Material
            objPVD5TPanel.CoronaTarget.T2Text = objPVD5TPanel.CoronaTarget.T2Text & "-" & ChamberConfig.Target_Material1
            objPVD5TPanel.CoronaTarget.T3Text = objPVD5TPanel.CoronaTarget.T3Text & "-" & ChamberConfig.Target_Material2
            objPVD5TPanel.CoronaTarget.T4Text = objPVD5TPanel.CoronaTarget.T4Text & "-" & ChamberConfig.Target_Material3
            objPVD5TPanel.CoronaTarget.T5Text = objPVD5TPanel.CoronaTarget.T5Text & "-" & ChamberConfig.Target_Material4
            objPVD5TPanel.CoronaTarget.Repaint()
            ' update water pump install
            objPVD5TPanel.TurboControl.IsWaterPumpInstalled = ChamberConfig.WaterPumpVisible

            objPVD5TPanel.TabTargetPowerSupply.SetupSourceMessageBox(objPVD5TPanel.Name)
            objPVD5TPanel.TabTargetPowerSupply.SetupSourceMessageBox(objPVD5TPanel.Name)

            If ChamberConfig.BiasPowerVisible Then
                Dim corona As String = objPVD5TPanel.BiasPowerSupply.txtForwardPowerRight.TypeOfChamberSupport.ToString()
                objPVD5TPanel.BiasPowerSupply.txtForwardPowerRight.SourceOfMessageBox = objPVD5TPanel.Name & "." & corona & ".BiasPowerSupply"
                objPVD5TPanel.BiasPowerSupply.txtVoltageRight.SourceOfMessageBox = objPVD5TPanel.Name & "." & corona & ".BiasPowerSupply"
                objPVD5TPanel.BiasPowerSupply.txtC1Right.SourceOfMessageBox = objPVD5TPanel.Name & "." & corona & ".BiasPowerSupply"
                objPVD5TPanel.BiasPowerSupply.txtC2Right.SourceOfMessageBox = objPVD5TPanel.Name & "." & corona & ".BiasPowerSupply"
                objPVD5TPanel.BiasPowerSupply.ChamberName = objPVD5TPanel.Name
                objPVD5TPanel.BiasPowerSupply.MagnatronInstalled = ChamberConfig.MagnatronVisible
                objPVD5TPanel.BiasPowerSupply.txtMagnatron.Visible = ChamberConfig.MagnatronVisible
                objPVD5TPanel.BiasPowerSupply.lblMagnatron.Visible = ChamberConfig.MagnatronVisible
                objPVD5TPanel.BiasPowerSupply.btnMag1RotationStart.Visible = ChamberConfig.MagnatronVisible
                objPVD5TPanel.BiasPowerSupply.btnMag2RotationStart.Visible = ChamberConfig.MagnatronVisible
                objPVD5TPanel.BiasPowerSupply.btnMag3RotationStart.Visible = ChamberConfig.MagnatronVisible
                objPVD5TPanel.BiasPowerSupply.btnMag4RotationStart.Visible = ChamberConfig.MagnatronVisible
                objPVD5TPanel.BiasPowerSupply.btnMag5RotationStart.Visible = ChamberConfig.MagnatronVisible
            Else
                objPVD5TPanel.BiasPowerSupply.Visible = ChamberConfig.BiasPowerVisible
                objPVD5TPanel.PVD5TInterlock.Top = objPVD5TPanel.BiasPowerSupply.Top
            End If

            'Invisible ChamberInterlock when they not install
            objPVD5TPanel.PVD5TInterlock.TurboWater_Visible = ChamberConfig.ChamberInterlock_TurboWaterVisible
            objPVD5TPanel.PVD5TInterlock.TargetMBWater_Visible = ChamberConfig.Target_Matchbox_Water_Visible
            objPVD5TPanel.PVD5TInterlock.BiasMBWater_Visible = ChamberConfig.Bias_Matchbox_Water_Visible
            objPVD5TPanel.PVD5TInterlock.Target1Water_Visible = ChamberConfig.TargetVisible
            objPVD5TPanel.PVD5TInterlock.Target2Water_Visible = ChamberConfig.Target2Visible
            objPVD5TPanel.PVD5TInterlock.Target3Water_Visible = ChamberConfig.Target3Visible
            objPVD5TPanel.PVD5TInterlock.Target4Water_Visible = ChamberConfig.Target4Visible
            objPVD5TPanel.PVD5TInterlock.Target5Water_Visible = ChamberConfig.Target5Visible
            objPVD5TPanel.PVD5TInterlock.SubTableWater_Visible = ChamberConfig.Interlock_SubstrateTableWater_Visible
            objPVD5TPanel.PVD5TInterlock.AirPressure_Visible = ChamberConfig.Interlock_AirPressure_Visible
            objPVD5TPanel.PVD5TInterlock.ArrangeInterlock()
            '-------------------------
            'number of wafer ->>add here
            objPVD5TPanel.CoronaChamber.NumberOfWafer = ChamberConfig.MaxNumberOfSlot

            'objEQ.Etch_Rate = ChamberConfig.Etch_Rate

            'objCoronaPanel.PM_DeviceNet = ChamberConfig.PM_DeviceNet
            objPVD5TPanel.ROR_Litter_Value = ChamberConfig.Litter_Value

            'objCoronaPanel.SLContainerBox.TypeOfIBEChamber = ChamberConfig.IBE_Type
            'objCoronaPanel.SLContainerBox.RotationFixture.IBEPanelType = ChamberConfig.IBE_Type
            'objCoronaPanel.SLFixture.TypeOfIBEChamber = ChamberConfig.IBE_Type

            'cryo, wp
            'If ChamberConfig.CryoVisible = True And ChamberConfig.WaterPumpVisible = False Then
            '    objCoronaPanel.SLContainerBox.FullyInstalled = False
            '    objCoronaPanel.SLContainerBox.NoWaterPumpInstalled = True
            '    objCoronaPanel.SLContainerBox.NoCryoInstalled = False
            'ElseIf ChamberConfig.CryoVisible = False And ChamberConfig.WaterPumpVisible = True Then
            '    objCoronaPanel.SLContainerBox.FullyInstalled = False
            '    objCoronaPanel.SLContainerBox.NoWaterPumpInstalled = False
            '    objCoronaPanel.SLContainerBox.NoCryoInstalled = True
            'ElseIf ChamberConfig.CryoVisible = False And ChamberConfig.WaterPumpVisible = False Then
            '    objCoronaPanel.SLContainerBox.FullyInstalled = False
            '    objCoronaPanel.SLContainerBox.NoWaterPumpInstalled = False
            '    objCoronaPanel.SLContainerBox.NoCryoInstalled = False
            'Else
            '    objCoronaPanel.SLContainerBox.FullyInstalled = True
            '    objCoronaPanel.SLContainerBox.NoWaterPumpInstalled = False
            '    objCoronaPanel.SLContainerBox.NoCryoInstalled = False
            'End If

            objPVD5TPanel.FilMetricControl.Visible = ChamberConfig.FilMetricDevice_Installed
            objPVD5TPanel.FilMetricControl.Top = objPVD5TPanel.PVD5TInterlock.Bottom

            If ChamberConfig.TurboPumpModel = SystemModule.TurboPump_Model.Leybold OrElse ChamberConfig.TurboPumpModel = SystemModule.TurboPump_Model.Shimadzu Then
                objPVD5TPanel.txtRampingPercent.Visible = True
            Else
                objPVD5TPanel.btnWaterPumpOn.Location = New Point(856, 344)
            End If

            Select Case objPVD5TPanel.Name
                Case Equipments.Chamber1.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM1.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.txtWarningKWH_PM1.Text = STR_CLICK_FOR_DETAIL 'ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.txtUsageKWH_PM1.Text = STR_CLICK_FOR_DETAIL 'ChamberConfig.SourceUsageTime
                    ContainerForm.SystemSetup.txtMaxKWHPM1.Text = STR_CLICK_FOR_DETAIL

                    ' shield/quartz
                    ContainerForm.SystemSetup.txtShieldPM1.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtLimitShieldsPM1.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtWarningShieldsPM1.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtMaxShieldsPM1.Text = STR_CLICK_FOR_DETAIL

                    ContainerForm.SystemSetup.txtTarMaterialPM1.Enabled = True
                    ContainerForm.SystemSetup.txtTarMaterialPM1.BackColor = Color.White
                    ContainerForm.SystemSetup.txtShieldPM1.BackColor = Color.White
                    ContainerForm.SystemSetup.txtUsageKWH_PM1.BackColor = Color.White
                    ContainerForm.ProcessPanel.CX_PM1.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.CassettesPanel.CX_PM1.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.SystemSetup.PM1ChamberType = SystemModule.ModuleType.PVD5T

                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T1_Limit = ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T2_Limit = ChamberConfig.Alarm_KWH1
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T3_Limit = ChamberConfig.Alarm_KWH2
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T4_Limit = ChamberConfig.Alarm_KWH3
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T5_Limit = ChamberConfig.Alarm_KWH4
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T1_Warning = ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T2_Warning = ChamberConfig.Warning_KWH1
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T3_Warning = ChamberConfig.Warning_KWH2
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T4_Warning = ChamberConfig.Warning_KWH3
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T5_Warning = ChamberConfig.Warning_KWH4
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T1_Max = ChamberConfig.Max_KWH_Source
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T2_Max = ChamberConfig.Max_KWH_Source1
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T3_Max = ChamberConfig.Max_KWH_Source2
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T4_Max = ChamberConfig.Max_KWH_Source3
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T5_Max = ChamberConfig.Max_KWH_Source4
                    ContainerForm.SystemSetup.txtTarMaterialPM1.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Target_Material3

                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T1_Material = ChamberConfig.Target_Material
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T2_Material = ChamberConfig.Target_Material1
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T3_Material = ChamberConfig.Target_Material2
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T4_Material = ChamberConfig.Target_Material3
                    ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T5_Material = ChamberConfig.Target_Material4
                    objPVD5TPanel.PMSystemSetupPopUpPanel = ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel

                Case Equipments.Chamber2.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM2.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.txtWarningKWH_PM2.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.txtUsageKWH_PM2.Text = STR_CLICK_FOR_DETAIL '  ChamberConfig.SourceUsageTime
                    ContainerForm.SystemSetup.txtMaxKWHPM2.Text = STR_CLICK_FOR_DETAIL

                    ' shield/quartz
                    ContainerForm.SystemSetup.txtShieldsPM2.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtLimitShieldsPM2.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtWarningShieldsPM2.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtMaxShieldsPM2.Text = STR_CLICK_FOR_DETAIL

                    ContainerForm.SystemSetup.txtTarMaterialPM2.Enabled = True
                    ContainerForm.SystemSetup.txtTarMaterialPM2.BackColor = Color.White
                    ContainerForm.SystemSetup.txtShieldsPM2.BackColor = Color.White
                    ContainerForm.SystemSetup.txtUsageKWH_PM2.BackColor = Color.White
                    ContainerForm.ProcessPanel.CX_PM2.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.CassettesPanel.CX_PM2.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.SystemSetup.PM2ChamberType = SystemModule.ModuleType.PVD5T

                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T1_Limit = ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T2_Limit = ChamberConfig.Alarm_KWH1
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T3_Limit = ChamberConfig.Alarm_KWH2
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T4_Limit = ChamberConfig.Alarm_KWH3
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T5_Limit = ChamberConfig.Alarm_KWH4

                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T1_Warning = ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T2_Warning = ChamberConfig.Warning_KWH1
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T3_Warning = ChamberConfig.Warning_KWH2
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T4_Warning = ChamberConfig.Warning_KWH3
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T5_Warning = ChamberConfig.Warning_KWH4

                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T1_Max = ChamberConfig.Max_KWH_Source
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T2_Max = ChamberConfig.Max_KWH_Source1
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T3_Max = ChamberConfig.Max_KWH_Source2
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T4_Max = ChamberConfig.Max_KWH_Source3
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T5_Max = ChamberConfig.Max_KWH_Source4
                    ContainerForm.SystemSetup.txtTarMaterialPM2.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Target_Material3

                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T1_Material = ChamberConfig.Target_Material
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T2_Material = ChamberConfig.Target_Material1
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T3_Material = ChamberConfig.Target_Material2
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T4_Material = ChamberConfig.Target_Material3
                    ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T5_Material = ChamberConfig.Target_Material4
                    objPVD5TPanel.PMSystemSetupPopUpPanel = ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel

                Case Equipments.Chamber3.ToString()
                    ContainerForm.SystemSetup.txtLimitsKWH_PM3.Text = STR_CLICK_FOR_DETAIL '  ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.txtWarningKWH_PM3.Text = STR_CLICK_FOR_DETAIL '  ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.txtUsageKWH_PM3.Text = STR_CLICK_FOR_DETAIL '  ChamberConfig.SourceUsageTime
                    ContainerForm.SystemSetup.txtTarMaterialPM3.Text = STR_CLICK_FOR_DETAIL ' ChamberConfig.Target_Material3
                    ContainerForm.SystemSetup.txtMaxKWHPM3.Text = STR_CLICK_FOR_DETAIL

                    ' shield/quartz
                    ContainerForm.SystemSetup.txtShieldsPM3.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtLimitShieldsPM3.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtWarningShieldsPM3.Text = STR_CLICK_FOR_DETAIL
                    ContainerForm.SystemSetup.txtMaxShieldsPM3.Text = STR_CLICK_FOR_DETAIL

                    ContainerForm.SystemSetup.txtTarMaterialPM3.Enabled = True
                    ContainerForm.SystemSetup.txtShieldsPM3.BackColor = Color.White
                    ContainerForm.SystemSetup.txtTarMaterialPM3.BackColor = Color.White
                    ContainerForm.SystemSetup.txtUsageKWH_PM3.BackColor = Color.White
                    ContainerForm.ProcessPanel.CX_PM3.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.CassettesPanel.CX_PM3.HasShutter = ChamberConfig.ShutterVisible
                    ContainerForm.SystemSetup.PM3ChamberType = SystemModule.ModuleType.PVD5T

                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T1_Limit = ChamberConfig.Alarm_KWH
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T2_Limit = ChamberConfig.Alarm_KWH1
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T3_Limit = ChamberConfig.Alarm_KWH2
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T4_Limit = ChamberConfig.Alarm_KWH3
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T5_Limit = ChamberConfig.Alarm_KWH4

                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T1_Warning = ChamberConfig.Warning_KWH
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T2_Warning = ChamberConfig.Warning_KWH1
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T3_Warning = ChamberConfig.Warning_KWH2
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T4_Warning = ChamberConfig.Warning_KWH3
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T5_Warning = ChamberConfig.Warning_KWH4

                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T1_Max = ChamberConfig.Max_KWH_Source
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T2_Max = ChamberConfig.Max_KWH_Source1
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T3_Max = ChamberConfig.Max_KWH_Source2
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T4_Max = ChamberConfig.Max_KWH_Source3
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T5_Max = ChamberConfig.Max_KWH_Source4

                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T1_Material = ChamberConfig.Target_Material
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T2_Material = ChamberConfig.Target_Material1
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T3_Material = ChamberConfig.Target_Material2
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T4_Material = ChamberConfig.Target_Material3
                    ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T5_Material = ChamberConfig.Target_Material4
                    objPVD5TPanel.PMSystemSetupPopUpPanel = ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel
            End Select

            objPVD5TPanel.TableControl.IsWaferLiftInstalled = ChamberConfig.WaferLiftInstalled
            objPVD5TPanel.TableControl.SupportTSDMode = ChamberConfig.ChuckPositionTSDRef
            objPVD5TPanel.TableControl.TargetToHomeDistance = ChamberConfig.TargetToHomeDistance

            ' Set first-load status and config for PMControl
            Dim objProcPM As PMControl = Nothing
            Dim objCassetPM As PMControl = Nothing
            GetPMControl(objPVD5TPanel.Name, objProcPM, objCassetPM)
            If objProcPM IsNot Nothing AndAlso objCassetPM IsNot Nothing Then
                objProcPM.NumberOfWafer = ChamberConfig.MaxNumberOfSlot
                objProcPM.T1Installed = ChamberConfig.TargetVisible
                objProcPM.T2Installed = ChamberConfig.Target2Visible
                objProcPM.T3Installed = ChamberConfig.Target3Visible
                objProcPM.T4Installed = ChamberConfig.Target4Visible
                objProcPM.T5Installed = ChamberConfig.Target5Visible

                objCassetPM.NumberOfWafer = ChamberConfig.MaxNumberOfSlot
                objCassetPM.T1Installed = ChamberConfig.TargetVisible
                objCassetPM.T2Installed = ChamberConfig.Target2Visible
                objCassetPM.T3Installed = ChamberConfig.Target3Visible
                objCassetPM.T4Installed = ChamberConfig.Target4Visible
                objCassetPM.T5Installed = ChamberConfig.Target5Visible

                objProcPM.Repaint()
                objCassetPM.Repaint()
            End If

            objPVD5TPanel.UpdateGUISetting()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Load or Unload PVD Item 
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub LoadPVDItem(ByVal PVDPanel As AVP_Robot_Project.PVDPanel, ByVal Chambermodule As AVPLib.SystemModule)
        Try
            Dim blnTargetVisible As Boolean = False

            PVDPanel.ROR_Litter_Value = Chambermodule.Litter_Value
            PVDPanel.BiasPowerSupply.Visible = Chambermodule.BiasPowerVisible
            PVDPanel.BiasPowerSupplyVisible = Chambermodule.BiasPowerVisible ''->store for setting in PVDPanel

            PVDPanel.RunRecipe.Real_Device_Enable = RobotConfigurationValues.REAL_DEVICE_INSTALLED
            PVDPanel.ManatronVisible = Chambermodule.MagnatronVisible
            PVDPanel.ParallelMagnetVisible = Chambermodule.ParallelMagnetVisible
            PVDPanel.ShutterVisible = Chambermodule.ShutterVisible
            PVDPanel.TurboPumpVisible = Chambermodule.TurboPumpVisible
            PVDPanel.TurboMPInstalled = Chambermodule.TurboMPVisible
            PVDPanel.ClampInstall = Chambermodule.ClampInstalled
            PVDPanel.CryoControlVisible = Chambermodule.CryoVisible
            PVDPanel.WaterValveVisible = Chambermodule.WaterValveInstalled
            PVDPanel.MainGas_Visible = Chambermodule.Main_Gas_Valve_Installed
            'config PVD Pop Up Menu
            PVDPanel.PVDPopUpPanel.grbCryo.Enabled = PVDPanel.CryoControlVisible
            PVDPanel.PVDPopUpPanel.grbWaterPump.Enabled = Not (PVDPanel.CryoControlVisible)

            PVDPanel.IsMGVisible = Chambermodule.MGVisible
            PVDPanel.SetGas1Info(Chambermodule.Gas1Name, Chambermodule.Gas1Type, Chambermodule.Gas1ShutoffPresent, Chambermodule.Gas1SupplyPresent)
            PVDPanel.SetGas2Info(Chambermodule.Gas2Name, Chambermodule.Gas2Type, Chambermodule.gas2ShutoffPresent, Chambermodule.Gas2SupplyPresent)
            PVDPanel.SetGas3Info(Chambermodule.Gas3Name, Chambermodule.Gas3Type, Chambermodule.gas3ShutoffPresent, Chambermodule.Gas3SupplyPresent)
            PVDPanel.SetGas4Info(Chambermodule.Gas4Name, Chambermodule.Gas4Type, Chambermodule.gas4ShutoffPresent, Chambermodule.Gas4SupplyPresent)
            PVDPanel.SetGas5Info(Chambermodule.Gas5Name, Chambermodule.Gas5Type, Chambermodule.gas5ShutoffPresent, Chambermodule.Gas5SupplyPresent)

            PVDPanel.ChamberInterlock.TurboWaterVisible = Chambermodule.ChamberInterlock_TurboWaterVisible
            PVDPanel.ChamberInterlock.TurboForelineVisible = Chambermodule.ChamberInterlock_TurboForelineVisible
            PVDPanel.ChamberInterlock.TargetWaterVisible = Chambermodule.ChamberInterlock_TargetWaterVisible
            PVDPanel.ChamberInterlock.LidSensorVisible = Chambermodule.ChamberInterlock_LidSensorVisible
            PVDPanel.ChamberInterlock.LidWaterVisible = Chambermodule.ChamberInterlock_LidWaterVisible
            PVDPanel.ChamberInterlock.TargetMBWaterVisible = Chambermodule.ChamberInterlock_TargetMBWaterVisible
            PVDPanel.ChamberInterlock.ClampWaterVisible = Chambermodule.ChamberInterlock_ClampWaterVisible
            PVDPanel.ChamberInterlock.SubMBWaterVisible = Chambermodule.ChamberInterlock_SubMBWaterVisible
            PVDPanel.ChamberInterlock.ArrangeInterlock()

            PVDPanel.RFTargetPowerSupplyVisible = Chambermodule.RFTargetPowerVisible
            PVDPanel.RFTargetPowerModel = Chambermodule.RFTargetPowerModel
            PVDPanel.DCTargetPowerSupplyVisible = Chambermodule.DCTargetPowerVisible
            PVDPanel.DCTargetPowerModel = Chambermodule.DCTargetPowerModel
            PVDPanel.BiasPowerModel = Chambermodule.BiasPowerModel

            If Chambermodule.RFTargetPowerVisible Then
                blnTargetVisible = True
            ElseIf Chambermodule.DCTargetPowerVisible Then
                blnTargetVisible = True
            Else
                blnTargetVisible = False
            End If

            PVDPanel.PM_DeviceNet = Chambermodule.PM_DeviceNet
            PVDPanel.TarControl.TargetInstalled = blnTargetVisible
            ContainerForm.SystemSetup.Enable_Disable_TxtBox_BaseOnPVDType(PVDPanel.Name, blnTargetVisible)
            Select Case PVDPanel.Name
                Case Equipments.Chamber1.ToString()
                    'ContainerForm.SystemSetup.pnlPM1.Enabled = blnTargetVisible
                    ContainerForm.SystemSetup.txtLimitsKWH_PM1.Text = Chambermodule.Alarm_KWH
                    ContainerForm.SystemSetup.txtWarningKWH_PM1.Text = Chambermodule.Warning_KWH
                    ContainerForm.SystemSetup.txtTarMaterialPM1.Text = Chambermodule.Target_Material
                    ContainerForm.SystemSetup.txtMaxKWHPM1.Text = Chambermodule.Max_KWH_Source
                    ContainerForm.CassettesPanel.CX_PM1.HasShutter = PVDPanel.ShutterVisible
                    ContainerForm.ProcessPanel.CX_PM1.HasShutter = PVDPanel.ShutterVisible
                Case Equipments.Chamber2.ToString()
                    'ContainerForm.SystemSetup.pnlPM2.Enabled = blnTargetVisible
                    ContainerForm.SystemSetup.txtLimitsKWH_PM2.Text = Chambermodule.Alarm_KWH
                    ContainerForm.SystemSetup.txtWarningKWH_PM2.Text = Chambermodule.Warning_KWH
                    ContainerForm.SystemSetup.txtTarMaterialPM2.Text = Chambermodule.Target_Material
                    ContainerForm.SystemSetup.txtMaxKWHPM2.Text = Chambermodule.Max_KWH_Source
                    ContainerForm.CassettesPanel.CX_PM2.HasShutter = PVDPanel.ShutterVisible
                    ContainerForm.ProcessPanel.CX_PM2.HasShutter = PVDPanel.ShutterVisible
                Case Equipments.Chamber3.ToString()
                    'ContainerForm.SystemSetup.pnlPM3.Enabled = blnTargetVisible
                    ContainerForm.SystemSetup.txtLimitsKWH_PM3.Text = Chambermodule.Alarm_KWH
                    ContainerForm.SystemSetup.txtWarningKWH_PM3.Text = Chambermodule.Warning_KWH
                    ContainerForm.SystemSetup.txtTarMaterialPM3.Text = Chambermodule.Target_Material
                    ContainerForm.SystemSetup.txtMaxKWHPM3.Text = Chambermodule.Max_KWH_Source
                    ContainerForm.CassettesPanel.CX_PM3.HasShutter = PVDPanel.ShutterVisible
                    ContainerForm.ProcessPanel.CX_PM3.HasShutter = PVDPanel.ShutterVisible
#If AVP_CX_STYLE = "CX4" Then
                    AVPLib.Log.avpLogger.Error("Missing Load PVD Item For CX4")
#End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Load and Handle Chamber (DCPVD, RFPVD, IBE)
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub LoadChamberPanel(ByVal PanelChamber As ChamberPanel, ByVal chamberName As String, Optional ByVal blnCanHandle As Boolean = False, Optional ByVal blnCreateStatus As Boolean = False)
        Try
            Dim ChamberModule As AVPLib.SystemModule = Nothing

            If AVPLib.ContainerData.IsChamberVisible(chamberName, ChamberModule) Then
                If PanelChamber.ChamberType = AVPLib.SystemModule.ModuleType.IBE Then
                    PanelChamber = CType(PanelChamber, IBEPanel) 'Chamber1Panel)
                    LoadIBEItem(PanelChamber, ChamberModule)
                ElseIf PanelChamber.ChamberType = SystemModule.ModuleType.PVD AndAlso
                       ChamberModule.DCTargetPowerVisible Then
                    PanelChamber = CType(PanelChamber, Chamber1DCPVDPanel)
                    LoadPVDItem(PanelChamber, ChamberModule)
                ElseIf PanelChamber.ChamberType = AVPLib.SystemModule.ModuleType.PVD AndAlso
                       ChamberModule.RFTargetPowerVisible Then
                    PanelChamber = CType(PanelChamber, Chamber1RFPVDPanel)
                    LoadPVDItem(PanelChamber, ChamberModule)
                ElseIf PanelChamber.ChamberType = SystemModule.ModuleType.PVD Then '
                    PanelChamber = CType(PanelChamber, PVDPanel)
                    LoadPVDItem(PanelChamber, ChamberModule)
                ElseIf PanelChamber.ChamberType = SystemModule.ModuleType.PVD4 Then '
                    PanelChamber = CType(PanelChamber, CoronaPanel) 'Chamber1Panel)
                    LoadCoronaItem(PanelChamber, ChamberModule)
                ElseIf PanelChamber.ChamberType = SystemModule.ModuleType.PVD5T Then
                    PanelChamber = CType(PanelChamber, PVD5TPanel)
                    LoadPVD5TItem(PanelChamber, ChamberModule)
                End If

                pnlCenter.Controls.Add(PanelChamber)
                If blnCanHandle Then
                    ContainerForm.HandleForm(PanelChamber)
                End If
                If blnCreateStatus Then
                    m_StatusManager.AddChild(PanelChamber.Status)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for TroubleShootPage
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TroubleShootPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Maintenance] Enter I/O Screen")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for Diagnostic Screen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClearAllAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAllAlarm.Click
        Try
            aplAlarm.IsStopFlashing = True
            StatusManager.IsAlarm = False
            MessageManager.ClearAllAlarms(True) 'remove all 
            lblAlarmTextMain.Text = String.Empty

            'Dat Cao Clear All SecsGem Alarm
            AVPLib.Business.AVPSecsGemLib.SECSGEM_AlarmClearAll()

            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Maintenance] Clear All Alarm Message")
            MessageManager.IsAlarm = True ' Get next alarm

            If (pnlPMConnection.btnConnectPM1.Status = DisplayStatus.On) Then
                m_StatusManager.RequestStatus("Chamber1.ClearAllAlarm", String.Empty)
            End If

            If (pnlPMConnection.btnConnectPM2.Status = DisplayStatus.On) Then
                m_StatusManager.RequestStatus("Chamber2.ClearAllAlarm", String.Empty)
            End If

            If (pnlPMConnection.btnConnectPM3.Status = DisplayStatus.On) Then
                m_StatusManager.RequestStatus("Chamber3.ClearAllAlarm", String.Empty)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-07-05</date>
    ''' </author>
    ''' <summary>
    ''' ALARM CLEAR ALL
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Sub ClearAllSecsGemAlarm()
        Try
            Business.AVPSecsGemLib.SECSGEM_CommonAlarmCLEAR("AVPSystemAlarm")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for Load current Alarm when click Alarm 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Sub ProcessAlarmMessage()
        Try
            GotoScreen(SystemScreens.DatalogScreen)
            ContainerForm.HandleForm(ContainerForm.AlarmAndEvent)
            ContainerForm.AlarmAndEvent.LoadAlarmAndEvent(aplAlarm.ManagedAlarmLabel.Text, AlarmAndEvent.Filter_Type.Alarm)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaintenance.Click
        Try
            If TypeOf sender Is AVPButton AndAlso CType(sender, AVPButton).IsSelected Then
                Return
            End If
            tabMain.BringToFront()
            pnlCenter.Controls.Item(ContainerForm.ProcessPanel.Name).Visible = False
            pnlPMConnection.BringToFront()
            SetSelectedState(sender)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub picHost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AVPCommunicationPanel.Click
        GotoScreen(SystemScreens.GEMScreen)
    End Sub

    Private Sub tabDataLog_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabDataLog.SelectedIndexChanged
        Try
            If tabDataLog.SelectedTab.Name = "tabDTLog" Then
                'Refresh Data Log
                ContainerForm.AlarmAndEvent.LoadAlarmAndEvent(String.Empty, AlarmAndEvent.Filter_Type.All)

            ElseIf tabDataLog.SelectedTab.Name = "tabWR" Then
                'Refresh Wafer Run
                ContainerForm.WaferRun.RefreshData()

            ElseIf tabDataLog.SelectedTab.Name = "TabLotDatalog" Then
                'Refresh Lot DataLog
                ContainerForm.Lotdatalog.RefreshData()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get PMControl of chamber in Process Screen, Cassette Screen
    ''' </summary>
    Public Sub GetPMControl(ByVal chamberID As String, ByRef objProcCX As PMControl, ByRef objCassCX As PMControl)
        Try
            Select Case chamberID
                Case Equipments.Chamber1.ToString()
                    objProcCX = ContainerForm.ProcessPanel.CX_PM1
                    objCassCX = ContainerForm.CassettesPanel.CX_PM1
                Case Equipments.Chamber2.ToString()
                    objProcCX = ContainerForm.ProcessPanel.CX_PM2
                    objCassCX = ContainerForm.CassettesPanel.CX_PM2
                Case Equipments.Chamber3.ToString()
                    objProcCX = ContainerForm.ProcessPanel.CX_PM3
                    objCassCX = ContainerForm.CassettesPanel.CX_PM3
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-18 </date>
    ''' </author>
    ''' <summary>
    ''' Set current slot for PM control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Public Sub SetPMControlCurrentSlot(ByVal chamberID As String, ByVal slotIndex As Integer)
        Try
            Dim objPMProcess As PMControl = Nothing
            Dim objPMCassette As PMControl = Nothing
            GetPMControl(chamberID, objPMProcess, objPMCassette)

            If objPMProcess IsNot Nothing AndAlso objPMCassette IsNot Nothing Then
                objPMProcess.CurrentPosition = slotIndex
                objPMCassette.CurrentPosition = slotIndex
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-22 </date>
    ''' </author>
    ''' <summary>
    ''' Update pressure
    ''' </summary>
    Public Sub UpdateGUIWhenInitCompleted(ByVal obj As Object)
        Try
            If (Me.InvokeRequired) Then
                Me.Invoke(New UpdatePressureValue(AddressOf UpdateGUIWhenInitCompleted), obj)
            Else
                Utils.UpdateTMPressure()
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-11-19 </date>
    ''' </author>
    ''' <summary>
    ''' reload data for gui
    ''' </summary>
    Private Sub tabEditor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabEditor.SelectedIndexChanged
        Try
            If tabEditor.SelectedTab.Name = "tabRecipe" Then
                ContainerForm.RecipeEditor.RefreshData()

            ElseIf tabEditor.SelectedTab.Name = "tabWaferFlow" Then
                ContainerForm.WaferFlow.RefreshData()

            ElseIf tabEditor.SelectedTab.Name = "tabSequence" Then
                ContainerForm.Sequence.RefreshData()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
