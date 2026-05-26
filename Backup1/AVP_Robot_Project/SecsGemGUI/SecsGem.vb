Imports AVPLib.DataManagerment
Imports System.Threading
Imports AVPSecsGemLib
Imports AVPLib
Imports AVPLib.Business.AVPSecsGemLib
Imports EMSERVICELib
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls

Public Class SecsGemPanel
#Region "Const - Variables"
    Const CMD_START_GEM As String = "START"
    Const CMD_STOP_GEM As String = "STOP"
    Const CMD_ABORT_GEM As String = "ABORT"
    Const CMD_SELECT_GEM As String = "PP-SELECT"
    Const CMD_RESUME_GEM As String = "RESUME"
    Const CMD_MAKE_ONLINE_GEM As String = "MAKE_ONLINE" ' For SL
    Const CMD_PAUSE_GEM As String = "PAUSE"

    Public Const CMD_MARKFORRETURN_GEM As String = "MARK_FOR_RETURN"
    Public Const CMD_MAKE_ALL_ONLINE_GEM As String = "MAKE_ALL_ONLINE"
    Public Const CMD_LOAD_WAFER_GEM As String = "LOAD"
    Public Const CMD_UNLOAD_WAFER_GEM As String = "UNLOAD"
    Public Const EXT_SEQUENCE_FILE As String = "SEQUENCE."
    Public Const EXT_WAFERFLOW_FILE As String = "WAFERFLOW."
    Public Const EXT_RECIPE_FILE As String = "RECIPE."
    Const CMD_RUN_GEM As String = "RUN"
    Const CMD_CONTINUE_GEM As String = "CONTINUE"
    Const CMD_ENDCURRENTSTEP_GEM As String = "END_CURRENT_STEP"
    Const CMD_LOAD_GEM As String = "LOAD"
    Const RECIPE_TYPE As String = "RECIPE"
    Const WAFERFLOW_TYPE As String = "WAFERLOW"
    Const SEQUENCE_TYPE As String = "SEQUENCE"
    Protected m_marshaller As DelegateMarshaler
    Public m_isUpload_Processing As Boolean
    Public m_isDownload_Processing As Boolean

    Public m_iUpload_ProcessingTime As Integer = 0
    Public m_iDownload_ProcessingTime As Integer = 0
    Private trd As Thread

    Public err_validation = ""
    Private m_InitDefaultControlState As Boolean = False
    Private m_ChatPopUp As PopUp_TerminalMessage = Nothing
    Private m_EnablePopUpTerminal As Boolean = False
#End Region

#Region "Init-Finalize"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_marshaller = DelegateMarshaler.Create()
        m_isUpload_Processing = False
        m_isDownload_Processing = False
        trd = New Thread(AddressOf InitializeSecsGemComponent)
        trd.IsBackground = True
        trd.Start()
        If (AVPLib.ContainerDAO.DefaultOnlineControlState) Then
            cbOnlineRemote.Checked = True
            cbOnlineLocal.Checked = False
        Else
            cbOnlineRemote.Checked = False
            cbOnlineLocal.Checked = True
        End If
        If (AVPLib.ContainerDAO.AllowPopUpTerminalMessage) Then
            chkUsePopUpTerminal.Checked = True
            btnChatPopUp.Enabled = True
            m_EnablePopUpTerminal = True
        Else
            chkUsePopUpTerminal.Checked = False
            btnChatPopUp.Enabled = False
            m_EnablePopUpTerminal = False
        End If

        m_ChatPopUp = New PopUp_TerminalMessage
        m_ChatPopUp.TopMost = True

    End Sub

    Public ReadOnly Property EnablePopUpTerminal() As Boolean
        Get
            Return m_EnablePopUpTerminal
        End Get
    End Property

    Public ReadOnly Property PopUpTerminalMessage() As PopUp_TerminalMessage
        Get
            If m_ChatPopUp Is Nothing Then
                m_ChatPopUp = New PopUp_TerminalMessage
                m_ChatPopUp.TopMost = True
            End If
            m_ChatPopUp.txtMessageFromHost.Text = txtMessageFromHost.Text
            m_ChatPopUp.txtMessageFromHost.SelectionStart = m_ChatPopUp.txtMessageFromHost.TextLength
            m_ChatPopUp.txtMessageFromHost.ScrollToCaret()
            Return m_ChatPopUp
        End Get
    End Property

    Private Sub InitializeSecsGemComponent()
        Try
            If MySecsGemObj Is Nothing Then
                Exit Try
            End If
            AddHandler MySecsGemObj.m_TerminalServiceHandler, AddressOf CMyCIMConnect_TerminalServiceHandler
            AddHandler MySecsGemObj.m_GEMStateChangeHandler, AddressOf CMyCIMConnect_GEMStateMachineHandler
            AddHandler MySecsGemObj.m_RemoteCommandHandler, AddressOf CMyCIMConnect_RemoteCommandHandler
            AddHandler MySecsGemObj.m_PPLoadInquireHandler, AddressOf CMyCIMConnect_PPLoadInquireHandler
            AddHandler MySecsGemObj.m_HostPPSendAckHandler, AddressOf CMyCIMConnect_HostPPSendAckHandler
            AddHandler MySecsGemObj.m_PPSendDataHandler, AddressOf CMyCIMConnect_HostPPSendDataHandler
            AddHandler MySecsGemObj.m_HostPPSendFileHandler, AddressOf CMyCIMConnect_HostPPSendFileHandler
            AddHandler MySecsGemObj.m_HostPPDeleteFileHandler, AddressOf CMyCIMConnect_HostPPDeleteFileHandler

            AVPLib.Business.AVPSecsGemLib.MySecsGemObj.Initialize(AVPConstants.sGemConfigName, False, Utils.CheckGemLicense())

            If Not Utils.CheckGemLicense() Then
                Exit Try
            End If

            MySecsGemObj.Create_Alarms(ConstEnum.LoadLockA_STR, AVP_GEMTYPE.LOADLOCK)
            MySecsGemObj.CreateVariables(ConstEnum.LoadLockA_STR, AVP_GEMTYPE.LOADLOCK)
            MySecsGemObj.Create_Events(ConstEnum.LoadLockA_STR, AVP_GEMTYPE.LOADLOCK)
            MySecsGemObj.UpdateProcessState(AVPProcessState.INIT, AVPLib.ConstEnum.LoadLockA_STR)

            MySecsGemObj.Create_Alarms(ConstEnum.TM_STR, AVP_GEMTYPE.TRANSFERMODULE)
            MySecsGemObj.CreateVariables(ConstEnum.TM_STR, AVP_GEMTYPE.TRANSFERMODULE)
            MySecsGemObj.Create_Events(ConstEnum.TM_STR, AVP_GEMTYPE.TRANSFERMODULE)

            If RobotConfigurationValues.CHAMBER1_VISIBLE Then
                If RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.PVD_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.PVD_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.PVD_CHAMBER)
                ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.IBE_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.IBE_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.IBE_CHAMBER)
                ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD4 Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.CORONA_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.CORONA_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.CORONA_CHAMBER)
                ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD5T Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.PVD5T_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.PVD5T_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber1.ToString(), AVP_GEMTYPE.PVD5T_CHAMBER)
                End If
            End If
            If RobotConfigurationValues.CHAMBER2_VISIBLE Then
                If RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.PVD_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.PVD_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.PVD_CHAMBER)
                ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.IBE_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.IBE_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.IBE_CHAMBER)
                ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD4 Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.CORONA_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.CORONA_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.CORONA_CHAMBER)
                ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD5T Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.PVD5T_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.PVD5T_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber2.ToString(), AVP_GEMTYPE.PVD5T_CHAMBER)
                End If
            End If
            If RobotConfigurationValues.CHAMBER3_VISIBLE Then
                If RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.PVD_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.PVD_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.PVD_CHAMBER)
                ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.IBE_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.IBE_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.IBE_CHAMBER)
                ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD4 Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.CORONA_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.CORONA_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.CORONA_CHAMBER)
                ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD5T Then
                    MySecsGemObj.Create_Alarms(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.PVD5T_CHAMBER)
                    MySecsGemObj.CreateVariables(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.PVD5T_CHAMBER)
                    MySecsGemObj.Create_Events(ConstEnum.Equipments.Chamber3.ToString(), AVP_GEMTYPE.PVD5T_CHAMBER)
                End If
            End If

            If Not AVPLib.Utils.Create_GEMDATA_Folder() Then
                AVPLib.Log.avpLogger.Error("Can't access or create GEM Data Folder when init GEM, please check")
            End If
            ''''copy Recipe/WaferFlow/Sequence to GEMDATA Folder
            Utils.CopyData2_GEMFolder()

            If (Not MySecsGemObj.m_initialized) Then
                MySecsGemObj.InitializeFinal()
            End If

            UpdateVariableLoaderForGemWhenInit()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        ''if SecsGem is nothing or init completed
        'AVPRobotMain.LoadStoreGUI()
    End Sub

    ''Truc Le add
    Protected Sub UpdateVariableForCXXWhenInit()
        Try
            Dim value As String = String.Empty
            value = RobotConfigurationValues.LOADLOCKA_SLOTS
            AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstantAndEnum.LOAD_LOCK_A, _
                                           EMSERVICELib.VarType.SV, "Numslot", VALUELib.ValueType.U4, value)

            For Each de As DictionaryEntry In AVPLib.DataManagerment.EquipmentManager.EquipmentList
                Dim objchamber As AVPLib.DataManagerment.Equipment = CType(de.Value, AVPLib.DataManagerment.Equipment)

                If objchamber IsNot Nothing AndAlso objchamber.Name.Contains(ConstEnum.Chamber) Then
                    With CType(objchamber, Chamber)
                        .GEMModuleName = .GEMModuleName
                        .GEMModuleType = .GEMModuleType
                    End With
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("UpdateVariableForCXXWhenInit" & ex.ToString())
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        Try
            MyBase.Finalize()
            If MySecsGemObj IsNot Nothing Then
                RemoveHandler MySecsGemObj.m_TerminalServiceHandler, AddressOf CMyCIMConnect_TerminalServiceHandler
                RemoveHandler MySecsGemObj.m_GEMStateChangeHandler, AddressOf CMyCIMConnect_GEMStateMachineHandler
                RemoveHandler MySecsGemObj.m_RemoteCommandHandler, AddressOf CMyCIMConnect_RemoteCommandHandler
                RemoveHandler MySecsGemObj.m_PPLoadInquireHandler, AddressOf CMyCIMConnect_PPLoadInquireHandler
                RemoveHandler MySecsGemObj.m_HostPPSendAckHandler, AddressOf CMyCIMConnect_HostPPSendAckHandler
                RemoveHandler MySecsGemObj.m_PPSendDataHandler, AddressOf CMyCIMConnect_HostPPSendDataHandler
                RemoveHandler MySecsGemObj.m_HostPPSendFileHandler, AddressOf CMyCIMConnect_HostPPSendFileHandler

                RemoveHandler MySecsGemObj.m_HostPPDeleteFileHandler, AddressOf CMyCIMConnect_HostPPDeleteFileHandler

                MySecsGemObj.Shutdown()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub CheckPermission()
        Try
            If AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_014) Then
                ActiveForm()
            Else
                InactiveForm()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub ActiveForm()
        Try
            Dim blnEnable As Boolean = False

            btnClearfromHost.Enabled = True

            btnEnable.Enabled = True
            btnDisable.Enabled = True
            cbOnlineLocal.Enabled = True
            cbOnlineRemote.Enabled = True
            btnGoOnlineLocal.Enabled = True
            btnOffline.Enabled = True
            btnGoOnlineRemote.Enabled = True

            blnEnable = (btnCommunicationStatus.Status = SL_CustomButton.DisplayStatus.On)
            blnEnable = blnEnable And (btnOnlineLocal.Status = SL_CustomButton.DisplayStatus.On OrElse _
                             btnOnlineRemote.Status = SL_CustomButton.DisplayStatus.On)

            txtMessageToHost.Enabled = blnEnable
            btnChatPopUp.Enabled = blnEnable
            chkUsePopUpTerminal.Enabled = blnEnable
            txtPPDownload.Enabled = blnEnable
            If EnablePopUpTerminal Then
                PopUpTerminalMessage.txtMessageToHost.Enabled = blnEnable
            End If
            btnUploadProcess.Enabled = blnEnable
            btnDownloadProcess.Enabled = blnEnable
            cbOnlineLocal.Cursor = Cursors.Hand
            cbOnlineRemote.Cursor = Cursors.Hand
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub InactiveForm()
        Try
            btnUploadProcess.Enabled = False
            btnDownloadProcess.Enabled = False

            btnClearfromHost.Enabled = False

            btnEnable.Enabled = False
            btnDisable.Enabled = False

            btnGoOnlineLocal.Enabled = False
            btnOffline.Enabled = False
            btnGoOnlineRemote.Enabled = False
            txtPPDownload.Enabled = False
            txtMessageToHost.Enabled = False
            btnChatPopUp.Enabled = False
            chkUsePopUpTerminal.Enabled = False
            If EnablePopUpTerminal Then
                PopUpTerminalMessage.txtMessageToHost.Enabled = False
            End If
            cbOnlineLocal.Enabled = False
            cbOnlineRemote.Enabled = False
            cbOnlineLocal.Cursor = Cursors.Default
            cbOnlineRemote.Cursor = Cursors.Default
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub SecsGem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If AVPLib.Business.AVPSecsGemLib.MySecsGemObj Is Nothing Then
            Exit Sub
        End If
        Me.rbnSequence.Checked = True
        LoadPPFile(True, False, False)
    End Sub

    Public Sub LoadRecipePPFileName(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadPPFile(False, False, True)
    End Sub

    Public Sub LoadWaferFlowPPFileName(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadPPFile(False, True, False)
    End Sub

    Public Sub LoadSequencePPFileName(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadPPFile(True, False, False)
    End Sub

    Public Sub UnregisterGemHandler()
        Try
            If MySecsGemObj IsNot Nothing Then
                RemoveHandler MySecsGemObj.m_TerminalServiceHandler, AddressOf CMyCIMConnect_TerminalServiceHandler
                RemoveHandler MySecsGemObj.m_GEMStateChangeHandler, AddressOf CMyCIMConnect_GEMStateMachineHandler
                RemoveHandler MySecsGemObj.m_RemoteCommandHandler, AddressOf CMyCIMConnect_RemoteCommandHandler
                RemoveHandler MySecsGemObj.m_PPLoadInquireHandler, AddressOf CMyCIMConnect_PPLoadInquireHandler
                RemoveHandler MySecsGemObj.m_HostPPSendAckHandler, AddressOf CMyCIMConnect_HostPPSendAckHandler
                RemoveHandler MySecsGemObj.m_PPSendDataHandler, AddressOf CMyCIMConnect_HostPPSendDataHandler
                RemoveHandler MySecsGemObj.m_HostPPSendFileHandler, AddressOf CMyCIMConnect_HostPPSendFileHandler
                RemoveHandler MySecsGemObj.m_HostPPDeleteFileHandler, AddressOf CMyCIMConnect_HostPPDeleteFileHandler
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Function GetChamberNameFromRecipeGEMFOLDER(ByVal strFileName As String) As String
        Dim strResult As String = String.Empty
        Try
            Dim arrStrTemp As Array = strFileName.Split(".")
            If (arrStrTemp.Length >= 3) Then
                strResult = AVPLib.Utils.chamberName2ChamberID(arrStrTemp(1).ToString)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function

    Private Sub LoadPPFile(ByVal isLoadSeqFile As Boolean, ByVal isLoadWF As Boolean, ByVal isLoadRecipe As Boolean)
        Try
            Dim strPP As String = EXT_SEQUENCE_FILE
            If isLoadWF Then
                strPP = EXT_WAFERFLOW_FILE
            ElseIf isLoadRecipe Then
                strPP = EXT_RECIPE_FILE
            End If
            lstPP.Items.Clear()
            If Not System.IO.Directory.Exists(AVPLib.ContainerDAO.FPath_GEMData) Then
                System.IO.Directory.CreateDirectory(AVPLib.ContainerDAO.FPath_GEMData)
            End If
            Dim listOfPP As String() = System.IO.Directory.GetFiles(AVPLib.ContainerDAO.FPath_GEMData, "*.xml")
            For Each strfile As String In listOfPP
                Dim strRawFileName As String = strfile.ToUpper()
                strRawFileName = AVPLib.Utils.GetFileName(strRawFileName, True)
                Dim strFileView As String = AVPLib.Utils.GetFileName(strfile, True)
                If strRawFileName.Contains(strPP) Then
                    If (strPP = EXT_RECIPE_FILE) Then
                        If ((RobotConfigurationValues.CHAMBER1_VISIBLE AndAlso GetChamberNameFromRecipeGEMFOLDER(strFileView) = ConstEnum.Equipments.Chamber1.ToString) OrElse _
                        (RobotConfigurationValues.CHAMBER2_VISIBLE AndAlso GetChamberNameFromRecipeGEMFOLDER(strFileView) = ConstEnum.Equipments.Chamber2.ToString) OrElse _
                        (RobotConfigurationValues.CHAMBER3_VISIBLE AndAlso GetChamberNameFromRecipeGEMFOLDER(strFileView) = ConstEnum.Equipments.Chamber3.ToString) OrElse _
                        (RobotConfigurationValues.ALINER_VISIBLE AndAlso GetChamberNameFromRecipeGEMFOLDER(strFileView) = ConstEnum.Equipments.Aligner.ToString.ToUpper) OrElse _
                        (AVPLib.ContainerDAO.Enable_ANYIBE_Mode AndAlso GetChamberNameFromRecipeGEMFOLDER(strFileView) = ConstEnum.Equipments.IBE.ToString)) Then
                            lstPP.Items.Add(strFileView)
                        End If
                    Else
                        lstPP.Items.Add(strFileView)
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Event Click"
    '''' <author>
    ''''    	<name> Tin.Tran </name>
    ''''    	<date> 2012-07-31</date>
    ''''        <do> Modified txtMessageToHost_Click </do>
    '''' </author>
    Private Sub txtMessageToHost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessageToHost.Click
        If AVPLib.ContainerData.UserLogin Is Nothing Then
            Exit Sub
        End If
        Dim pad As New KeyPad
        Dim Value As String = String.Empty
        If pad.DisplayKeypad(Value, "Message To Host", False) = DialogResult.OK Then
            SecsGem_EventHandler.SendTerminalMessage(Value)
            txtMessageFromHost.Text &= "->: " & Value & Environment.NewLine
            txtMessageFromHost.SelectionStart = txtMessageFromHost.TextLength
            txtMessageFromHost.ScrollToCaret()
            '
            If EnablePopUpTerminal Then
                With PopUpTerminalMessage
                    .txtMessageFromHost.Text = txtMessageFromHost.Text
                    .txtMessageFromHost.SelectionStart = txtMessageFromHost.TextLength
                    .txtMessageFromHost.ScrollToCaret()
                End With
            End If
        End If
    End Sub

    Private Sub btnEnable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnable.Click, btnDisable.Click
        If MySecsGemObj IsNot Nothing Then
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            If (sender Is ContainerForm.Secs_GemPanel.btnDisable) Then
                If (m_isUpload_Processing = True) Then
                    If (Utils.ShowAVPMessageBox("Upload PP in progress, are you sure goto Disable?", "GEM Control", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OKCancel) = DialogResult.OK) Then
                        SecsGem_EventHandler.Enable_Disable_SecsGemCommunication(sender, e)
                        m_isUpload_Processing = False
                    End If
                    Exit Sub
                ElseIf (m_isDownload_Processing = True) Then
                    If (Utils.ShowAVPMessageBox("Download PP in progress, are you sure goto Offline?", "GEM Control", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OKCancel) = DialogResult.OK) Then
                        SecsGem_EventHandler.Enable_Disable_SecsGemCommunication(sender, e)
                        m_isDownload_Processing = False
                    End If
                    Exit Sub
                End If
            End If
            SecsGem_EventHandler.Enable_Disable_SecsGemCommunication(sender, e)
        End If
    End Sub

    Private Sub btnOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOffline.Click
        If MySecsGemObj IsNot Nothing Then
            If (sender Is ContainerForm.Secs_GemPanel.btnOffline) Then
                If (m_isUpload_Processing = True) Then
                    If (Utils.ShowAVPMessageBox("Upload PP in progress, are you sure goto Offline?", "GEM Control", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OKCancel) = DialogResult.OK) Then
                        SecsGem_EventHandler.Offline_SecsGem(sender, e)
                        m_isUpload_Processing = False
                    End If
                    Exit Sub
                ElseIf (m_isDownload_Processing = True) Then
                    If (Utils.ShowAVPMessageBox("Download PP in progress, are you sure goto Offline?", "GEM Control", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OKCancel) = DialogResult.OK) Then
                        SecsGem_EventHandler.Offline_SecsGem(sender, e)
                        m_isDownload_Processing = False
                    End If
                    Exit Sub
                End If
            End If
            SecsGem_EventHandler.Offline_SecsGem(sender, e)
        End If
    End Sub

    Private Sub btnRemote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoOnlineRemote.Click, btnGoOnlineLocal.Click
        If MySecsGemObj IsNot Nothing Then
            SecsGem_EventHandler.Online_Remote_Local_SecsGem(sender, e)
        End If
    End Sub

    Private Sub btnTerminalService(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearfromHost.Click
        SecsGem_EventHandler.ClearTerminalMessage(sender, e)
    End Sub
#End Region

#Region "Marshaller Update GUI"
    '''' <author>
    ''''    	<name> Truc Le </name>
    ''''    	<date> 2011-06-30</date>
    '''' </author>
    '''' <summary>
    '''' Only Used for AVP Secs Gem, 
    '''' </summary>
    '''' <remarks></remarks>
    Public Sub CMyCIMConnect_TerminalServiceHandler(ByVal sender As Object, ByVal e As AVPSecsGem.TerminalServiceArgs)
        AVPLib.Log.guiLogger.Info("Enter CMyCIMConnect_TerminalServiceHandler")
        m_marshaller.Invoke(Of Object)(New Threading.SendOrPostCallback(AddressOf UpdateTerminalService), e)
        AVPLib.Log.guiLogger.Info("Leave CMyCIMConnect_TerminalServiceHandler")
    End Sub
    '''' <author>
    ''''    	<name> Truc Le </name>
    ''''    	<date> 2011-06-30</date>
    '''' </author>
    '''' <summary>
    '''' Only Used for AVP Secs Gem, 
    '''' </summary>
    '''' <remarks></remarks>
    Public Sub CMyCIMConnect_GEMStateMachineHandler(ByVal sender As Object, ByVal e As AVPSecsGem.GEMStateChangeArgs)
        AVPLib.Log.guiLogger.Info("Enter CMyCIMConnect_GEMConnectionHandler")
        m_marshaller.Invoke(Of Object)(New Threading.SendOrPostCallback(AddressOf UpdateGemStatus), e)
        AVPLib.Log.guiLogger.Info("Leave CMyCIMConnect_GEMStateMachineHandler")
    End Sub

    Public Sub CMyCIMConnect_HostPPSendDataHandler(ByVal sender As Object, ByVal e As AVPSecsGem.PPSendDataArgs)
        AVPLib.Log.guiLogger.Info("Enter CMyCIMConnect_HostPPSendDataHandler")
        m_marshaller.Invoke(Of Object)(New Threading.SendOrPostCallback(AddressOf HostPPSendData), e)
        AVPLib.Log.guiLogger.Info("Leave CMyCIMConnect_HostPPSendDataHandler")
    End Sub

    Public Sub CMyCIMConnect_HostPPSendFileHandler(ByVal sender As Object, ByVal e As AVPSecsGem.HostPPSendFileArgs)
        AVPLib.Log.guiLogger.Info("Enter CMyCIMConnect_HostPPSendFileHandler")
        m_marshaller.Invoke(Of Object)(New Threading.SendOrPostCallback(AddressOf HostPPSendFile), e)
        AVPLib.Log.guiLogger.Info("Leave CMyCIMConnect_HostPPSendFileHandler")
    End Sub

    Public Sub CMyCIMConnect_HostPPSendAckHandler(ByVal sender As Object, ByVal e As AVPSecsGem.HostPPSendAckArgs)
        AVPLib.Log.guiLogger.Info("Enter CMyCIMConnect_PPSendAckHandler")
        m_marshaller.Invoke(Of Object)(New Threading.SendOrPostCallback(AddressOf HostPPSendAck), e)
        AVPLib.Log.guiLogger.Info("Leave CMyCIMConnect_PPSendAckHandler")
    End Sub

    Public Sub CMyCIMConnect_PPLoadInquireHandler(ByVal sender As Object, ByVal e As AVPSecsGem.PPLoadInquireArgs)
        AVPLib.Log.guiLogger.Info("Enter CMyCIMConnect_PPLoadInquireHandler")
        m_marshaller.Invoke(Of Object)(New Threading.SendOrPostCallback(AddressOf PPLoadInquireAck), e)
        AVPLib.Log.guiLogger.Info("Leave CMyCIMConnect_PPLoadInquireHandler")
    End Sub
    '''' <author>
    ''''    	<name> Truc Le </name>
    ''''    	<date> 2011-06-30</date>
    '''' </author>
    '''' <summary>
    '''' Only Used for AVP Secs Gem, 
    '''' </summary>
    '''' <remarks></remarks>
    Public Sub CMyCIMConnect_RemoteCommandHandler(ByVal sender As Object, ByVal e As AVPSecsGem.RemoteCommandArgs)
        AVPLib.Log.guiLogger.Info("Enter CMyCIMConnect_RemoteCommandHandler")
        m_marshaller.Invoke(Of Object)(New Threading.SendOrPostCallback(AddressOf ProcessRemoteCommand), e)
        AVPLib.Log.guiLogger.Info("Leave CMyCIMConnect_RemoteCommandHandler")
    End Sub

#If AVP_PLATFORM = "CX" Then
    Public Sub CMyCIMConnect_HostPPDeleteFileHandler(ByVal sender As Object, ByVal e As AVPSecsGem.HostPPDeleteFileArgs)
        AVPLib.Log.guiLogger.Info("Enter CMyCIMConnect_RemoteCommandHandler")
        m_marshaller.Invoke(Of Object)(New Threading.SendOrPostCallback(AddressOf HostPPDeleteFile), e)
        AVPLib.Log.guiLogger.Info("Leave CMyCIMConnect_RemoteCommandHandler")
    End Sub
#End If

    '''' <author>
    ''''    	<name> Truc Le </name>
    ''''    	<date> 2011-06-30</date>
    '''' </author>
    '''' <summary>
    '''' Only Used for AVP Secs Gem, 
    '''' </summary>
    '''' <remarks></remarks>
    Private Sub ResetGemControlStatus()
        'btnEQOffline.Status = SL_CustomButton.DisplayStatus.Off
        'btnAttemptOnline.Status = SL_CustomButton.DisplayStatus.Off
        btnOnlineLocal.Status = SL_CustomButton.DisplayStatus.Off
        btnOnlineRemote.Status = SL_CustomButton.DisplayStatus.Off
        btnHostOffline.Status = SL_CustomButton.DisplayStatus.Off
    End Sub

    Protected Sub HostPPSendFile(ByVal arg As Object)
        Try
            Dim result As AVPSecsGemLib.AVPSecsGem.HostPPSendFileArgs = CType(arg, AVPSecsGemLib.AVPSecsGem.HostPPSendFileArgs)
            ''check filename -->copy file
            Dim fileType As String = String.Empty
            Dim sFileName As String = String.Empty
            sFileName = SelectFile(result.sFileName, fileType)

            If fileType = WAFERFLOW_TYPE Or fileType = SEQUENCE_TYPE Then
                If XmlValidate(result.sFileName, sFileName) = True AndAlso CheckRecipeWaferFlowExist(result.sFileName) = True Then
                    If CopyPP_To_Folder(result.sFileName) Then
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                           AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                           "Host send " & fileType & ": " & AVPLib.Utils.GetFileName(result.sFileName, True))
                        result.Result = EMSERVICELib.RecipeAck.raAccepted
                    Else
                        result.Result = AVPLib.ConstEnum.CustomUploadDownloadResult.OTHER_ERROR
                        CleanUp_GEMDataFolder(result.sFileName)
                    End If
                Else
                    result.Result = AVPLib.ConstEnum.CustomUploadDownloadResult.INVALID_STRUCTURE_DATA
                    CleanUp_GEMDataFolder(result.sFileName)
                End If

            Else
                If XmlValidate(result.sFileName, sFileName) = True Then
                    If CopyPP_To_Folder(result.sFileName) Then
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                           AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                           "Host send " & fileType & ": " & AVPLib.Utils.GetFileName(result.sFileName, True))
                        result.Result = EMSERVICELib.RecipeAck.raAccepted
                    Else
                        result.Result = AVPLib.ConstEnum.CustomUploadDownloadResult.OTHER_ERROR
                        CleanUp_GEMDataFolder(result.sFileName)
                    End If
                Else
                    result.Result = AVPLib.ConstEnum.CustomUploadDownloadResult.INVALID_STRUCTURE_DATA
                    CleanUp_GEMDataFolder(result.sFileName)
                End If
            End If
            'Host Request send file not Need 
            'm_isDownload_Processing = False
            'm_iDownload_ProcessingTime = 0
            'DownloadPPStatus()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub CleanUp_GEMDataFolder(ByVal sFileName As String)
        Try
            If System.IO.File.Exists(sFileName) Then
                System.IO.File.Delete(sFileName)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Sub HostPPSendData(ByVal arg As Object)
        Try
            Dim result As AVPSecsGemLib.AVPSecsGem.PPSendDataArgs = CType(arg, AVPSecsGemLib.AVPSecsGem.PPSendDataArgs)
            Dim sFileName As String = String.Empty
            Dim fileType As String = String.Empty
            sFileName = SelectFile(result.sFileName, fileType)
            If fileType = RECIPE_TYPE Then
                If XmlValidate(result.sFileName, sFileName) = True Then
                    If result.Result = 0 Then
                        Utils.ShowAVPMessageBox("Download Process Program File successfullly!", "GEM Control", MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)

                        ''copy to folder Recipe, Jobfile, Waferflow
                        CopyPP_To_Folder(result.sFileName)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                           AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                           "Host send " & fileType & ": " & AVPLib.Utils.GetFileName(result.sFileName, True))
                    Else
                        Utils.ShowAVPMessageBox("Download Process Program File fail", "GEM Control", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                        CleanUp_GEMDataFolder(result.sFileName)
                    End If
                Else

                    Utils.ShowAVPMessageBox("Downloaded File is invalid!", "GEM Control", MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)
                    CleanUp_GEMDataFolder(result.sFileName)
                End If
            ElseIf fileType = WAFERFLOW_TYPE Or fileType = SEQUENCE_TYPE Then
                If XmlValidate(result.sFileName, sFileName) = True AndAlso CheckRecipeWaferFlowExist(result.sFileName) = True Then
                    If result.Result = 0 Then
                        Utils.ShowAVPMessageBox("Download Process Program File successfullly!", "GEM Control", MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)

                        ''copy to folder Recipe, Jobfile, Waferflow
                        CopyPP_To_Folder(result.sFileName)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                           AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                           "Host send " & fileType & ": " & AVPLib.Utils.GetFileName(result.sFileName, True))
                    Else
                        Utils.ShowAVPMessageBox("Download Process Program File fail", "GEM Control", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                        CleanUp_GEMDataFolder(result.sFileName)
                    End If
                Else
                    Utils.ShowAVPMessageBox("Downloaded File is invalid", "GEM Control", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                    CleanUp_GEMDataFolder(result.sFileName)
                End If
            End If
            'Stop Timer and flag Equipment Download File
            m_isDownload_Processing = False
            m_iDownload_ProcessingTime = 0
            DownloadPPStatus()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function SL_CopyPP_To_Folder(ByVal sFileName As String) As Boolean
        Try
            Dim fileName As String = AVPLib.Utils.GetFileName(sFileName, False)
            Dim sSubFolder As String = AVPLib.Utils.chamberName2ChamberID(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
            sSubFolder = AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & sSubFolder
            If System.IO.Directory.Exists(sSubFolder) = False Then
                System.IO.Directory.CreateDirectory(sSubFolder)
            End If
            Dim dFileName As String = Nothing
            dFileName = sSubFolder & "\" & fileName
            System.IO.File.Copy(sFileName, dFileName, True)
            Dim chamber As AVPLib.DBChamber = Nothing
            chamber = AVPLib.ContainerDAO.GetChamber(AVPLib.ConstEnum.Equipments.Chamber1.ToString(), fileName)
            ExportToFile_stp(dFileName, chamber)

            'Refresh recipe name list
            LoadRecipePPFileName(Nothing, Nothing)
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    Private Shared Sub ExportToFile_stp(ByVal filepath As String, ByVal chamber As DBChamber)
        AVPLib.Log.coreLogger.Info("Enter ExportToFile_stp")
        Try
            ''delete the old file
            Dim i As Integer = 0
            Const strStpExt As String = ".stp"
            Const strPrcExt As String = ".prc"
            Dim ProjNamewithPath As String = filepath.Replace(".xml", strPrcExt) '''save project file
            Dim fiProj As New System.IO.FileInfo(ProjNamewithPath)
            If fiProj.Exists Then
                fiProj.Delete()
            End If

            Dim strProjName As String = AVPLib.Utils.GetFileName(ProjNamewithPath, True) ''extract project file name

            Dim stepName As String = ProjNamewithPath.Replace(strPrcExt, "_step") ''save step file
            ''start writing to new project file
            Dim SwFromProjTrueUTF8 As New System.IO.StreamWriter(ProjNamewithPath, True, System.Text.Encoding.ASCII)
            SwFromProjTrueUTF8.WriteLine("[ProcessParameters]")
            SwFromProjTrueUTF8.WriteLine("Abort_At_Fault=N")
            SwFromProjTrueUTF8.WriteLine("Use_Pretilt=N")
            SwFromProjTrueUTF8.WriteLine("Pretilt_Angle=90")
            SwFromProjTrueUTF8.WriteLine("Use_Recipe_Process_Start_Pressure=N")
            SwFromProjTrueUTF8.WriteLine("Process_Start_Pressure=0.000005")
            SwFromProjTrueUTF8.WriteLine("[ProcessSteps]")

            Dim ListChamberSteps As ArrayList = chamber.ListChamberSteps
            ''check condition
            If ListChamberSteps.Count > 200 Or ListChamberSteps.Count <= 0 Then
                AVPLib.Log.coreLogger.Error("Recipe Step is out of control")
                AVPLib.Log.coreLogger.Info("Leave ExportToFile_stp")
                Exit Sub
            End If
            '''''''''''''''
            For Each ChamberStep As DBChamberStep In ListChamberSteps
                ''create new step file name with extention
                i += 1
                SwFromProjTrueUTF8.WriteLine("Step_" & i.ToString() & "=" & strProjName & "_step" & i.ToString())
                ''create step file
                Dim stepfi As New System.IO.FileInfo(stepName & i.ToString() & strStpExt)
                If stepfi.Exists Then
                    stepfi.Delete()
                End If
                '''save step file with path
                Dim swFromFileTrueUTF8 As New System.IO.StreamWriter(stepName & i.ToString() & strStpExt, True, System.Text.Encoding.ASCII)
                'writing step file
                Dim listParam As ArrayList = ChamberStep.ListGroupParameterValues
                For Each DBParam As AVPLib.DBGroupParameterValue In listParam
                    Dim listGroupParam As ArrayList = DBParam.ListParameterValues
                    swFromFileTrueUTF8.WriteLine("[" & DBParam.GroupCode.ToString() & "]")
                    For Each ParamValue As DBParameterValue In listGroupParam
                        If LCase(ParamValue.Value) = "true" Then
                            swFromFileTrueUTF8.WriteLine(ParamValue.Name & "=Y")
                        ElseIf LCase(ParamValue.Value) = "false" Then
                            swFromFileTrueUTF8.WriteLine(ParamValue.Name & "=N")
                        Else
                            swFromFileTrueUTF8.WriteLine(ParamValue.Name & "=" & ParamValue.Value)
                        End If
                    Next
                Next
                'close step file 
                swFromFileTrueUTF8.Flush()
                swFromFileTrueUTF8.Close()
            Next
            ''close project file
            SwFromProjTrueUTF8.Flush()
            SwFromProjTrueUTF8.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            ''Utils.ThrowAlarm(chamber.ChamberName + ":Can not write to files with path: " & filepath)
            'AVPLib.Utils.ThrowAlarm(String.Format(AVPLib.ContainerData.GetMessageText("EquipmentCanNotWriteFileToPath"), _
            '            chamber.ChamberName, filepath))
        End Try
        AVPLib.Log.coreLogger.Info("Leave ExportToFile_stp")
    End Sub
    '''' <author>
    ''''    	<name> DatCao </name>
    ''''    	<date> 2012-03-08</date>
    '''' </author>
    '''' <summary>
    '''' return any IBE chamber exited in system 
    '''' </summary>
    '''' <remarks></remarks>
    Private Function GetANYIBEDBChamber(ByVal sFileName As String) As AVPLib.DBChamber
        Dim dbresult As AVPLib.DBChamber = Nothing
        Try
            If (AVPLib.Utils.IsIBEChamber_ANYIBE(AVPLib.ConstEnum.Equipments.Chamber1.ToString())) Then
                dbresult = AVPLib.ContainerData.Chamber(AVPLib.ConstEnum.Equipments.Chamber1.ToString(), sFileName)
                If (dbresult IsNot Nothing) Then
                    Return dbresult
                End If
            End If

            If (AVPLib.Utils.IsIBEChamber_ANYIBE(AVPLib.ConstEnum.Equipments.Chamber2.ToString())) Then
                dbresult = AVPLib.ContainerData.Chamber(AVPLib.ConstEnum.Equipments.Chamber2.ToString(), sFileName)
                If (dbresult IsNot Nothing) Then
                    Return dbresult
                End If
            End If

            If (AVPLib.Utils.IsIBEChamber_ANYIBE(AVPLib.ConstEnum.Equipments.Chamber3.ToString())) Then
                dbresult = AVPLib.ContainerData.Chamber(AVPLib.ConstEnum.Equipments.Chamber3.ToString(), sFileName)
                If (dbresult IsNot Nothing) Then
                    Return dbresult
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.coreLogger.Error(ex.Message.ToString)
        End Try
        Return dbresult
    End Function

    ''copy to folder Recipe, Jobfile, Waferflow
    Private Function CopyPP_To_Folder(ByVal sFileName As String) As Boolean
        Try
            Dim fileName As String = AVPLib.Utils.GetFileName(sFileName, False)
            Dim newfilename As String = fileName
            If fileName.ToUpper.StartsWith(EXT_RECIPE_FILE) Then
                Dim tmp As Array = fileName.Split(".") ''file name must be recipe.PM1.abc.xml
                If tmp.Length >= 3 Then
                    Dim sSubFolder As String = AVPLib.Utils.chamberName2ChamberID(tmp(1).ToString().ToUpper)
                    Dim chamberName As String = sSubFolder
                    If (sSubFolder = RobotConfigurationValues.ANY_IBE_CHAMBER) Then
                        sSubFolder = RobotConfigurationValues.ANY_IBE_CHAMBER
                    End If
                    sSubFolder = AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & sSubFolder
                    If System.IO.Directory.Exists(sSubFolder) = False Then
                        System.IO.Directory.CreateDirectory(sSubFolder)
                    End If

                    System.IO.File.Copy(sFileName, sSubFolder & "\" & tmp(2) & ".xml", True)
                    newfilename = EXT_RECIPE_FILE & tmp(1) & "." & tmp(2) & ".xml"

                    '''export to stp file
                    Dim chamber As AVPLib.DBChamber = Nothing
                    If (chamberName = RobotConfigurationValues.ANY_IBE_CHAMBER) Then
                        chamber = GetANYIBEDBChamber(tmp(2) & ".xml")
                    Else
                        chamber = AVPLib.ContainerData.Chamber(chamberName, tmp(2) & ".xml")
                    End If

                    'ONLY VEECO IBE USED THE FILE .STP AND .PRC
                    Dim objChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(chamberName)
                    If (objChamberConfig IsNot Nothing AndAlso _
                        (objChamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD OrElse _
                        objChamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD4 OrElse _
                        objChamberConfig.IBE_Type <> AVPLib.ConstEnum.IBEType.AVP_IBE)) Then
                        ExportToFile_stp(sSubFolder & "\" & tmp(2) & ".xml", chamber)
                    End If

                End If
            ElseIf fileName.ToUpper().StartsWith(EXT_WAFERFLOW_FILE) Then
                Dim tmp As Array = fileName.Split(".")
                If (tmp.Length >= 2) Then
                    Dim subfileName As String = tmp(1).ToString() & ".xml"
                    If System.IO.Directory.Exists(AVPLib.ContainerDAO.FPath_WaferFlow) = False Then
                        System.IO.Directory.CreateDirectory(AVPLib.ContainerDAO.FPath_WaferFlow)
                    End If
                    System.IO.File.Copy(sFileName, AVPLib.ContainerDAO.FPath_WaferFlow & "\" & subfileName, True)
                    newfilename = EXT_WAFERFLOW_FILE & tmp(1) & ".xml"
                End If
            ElseIf fileName.ToUpper().StartsWith(EXT_SEQUENCE_FILE) Then
                Dim tmp As Array = fileName.Split(".")
                If (tmp.Length >= 2) Then
                    Dim subfileName As String = tmp(1).ToString() & ".xml"
                    If System.IO.Directory.Exists(AVPLib.ContainerDAO.FPath_SequenceData) = False Then
                        System.IO.Directory.CreateDirectory(AVPLib.ContainerDAO.FPath_SequenceData)
                    End If
                    System.IO.File.Copy(sFileName, AVPLib.ContainerDAO.FPath_SequenceData & "\" & subfileName, True)
                    newfilename = EXT_SEQUENCE_FILE & tmp(1) & ".xml"
                End If
            End If
            Dim newpath As String = sFileName.Replace(fileName, newfilename)
            System.IO.File.Move(sFileName, newpath)
            ''My.Computer.FileSystem.RenameFile(sFileName, newfilename)

            UpdateListPPName()
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    Protected Sub HostPPSendAck(ByVal arg As Object)
        Try
            Utils.ShowAVPMessageBox("Upload Process Program File successfullly!", "GEM Control", MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)
            m_isUpload_Processing = False
            m_iUpload_ProcessingTime = 0
            UploadPPStatus()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Sub PPLoadInquireAck(ByVal arg As Object)
        Try
            If CType(arg, AVPSecsGemLib.AVPSecsGem.PPLoadInquireArgs).RecipeGrant = EMSERVICELib.RecipeGrant.rgOk Then
                MySecsGemObj.PPSend(Me.lstPP.SelectedItem.ToString, String.Empty)
                m_isUpload_Processing = True
                m_iUpload_ProcessingTime = 0
                UploadPPStatus()
            Else
                Utils.ShowAVPMessageBox("Upload PP File Failed", "GEM Control", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                m_isUpload_Processing = False
                m_iUpload_ProcessingTime = 0
                UploadPPStatus()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    '''' <author>
    ''''    	<name> Truc Le </name>
    ''''    	<date> 2011-06-30</date>
    '''' </author>
    '''' <summary>
    '''' Only Used for AVP Secs Gem, 
    '''' </summary>
    '''' <remarks></remarks>
    Protected Sub ProcessRemoteCommand(ByVal arg As Object)
        Try
            Dim gemCommand As AVPSecsGem.RemoteCommandArgs = CType(arg, AVPSecsGem.RemoteCommandArgs)
            Dim strArgValues As String() = gemCommand.ArgumentValues
            Dim strArgNames As String() = gemCommand.ArgumentNames
            Dim cmdResult As EMSERVICELib.CommandResults = gemCommand.CommandResult
            Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing
            Dim objavpCtrlJob As AVPLib.Business.AVPControlJob = Nothing
            Dim eRemoteResult As AVPLib.ConstEnum.CustomRemoteCommandResult = Nothing

            Dim strHostName As String = "Host"
            If strArgNames IsNot Nothing AndAlso strArgNames.Length > 0 AndAlso strArgNames(0).StartsWith("Mobile") Then
                strHostName = strArgNames(0)
            End If

            If gemCommand.Command = CMD_ABORT_GEM OrElse gemCommand.Command = CMD_RESUME_GEM OrElse _
            gemCommand.Command = CMD_START_GEM OrElse gemCommand.Command = CMD_STOP_GEM OrElse gemCommand.Command = CMD_PAUSE_GEM _
            OrElse gemCommand.Command = CMD_LOAD_WAFER_GEM OrElse gemCommand.Command = CMD_UNLOAD_WAFER_GEM Then
                ''start.stop.abort.resume here
                Dim lpcLoadLock As LockProcessControl = Nothing
                lpcLoadLock = IIf(strArgValues(0) = "A", ContainerForm.ProcessPanel.lpcLoadLockA, _
                                                         Nothing)
                objLoadLockCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                If lpcLoadLock Is Nothing OrElse objLoadLockCtrl Is Nothing Then
                    gemCommand.CommandResult = CommandResults.cmdNoObject
                    Exit Sub
                End If
                Select Case gemCommand.Command
                    Case CMD_PAUSE_GEM
                        objavpCtrlJob = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockCtrl.CtrlJobId)
                        If objavpCtrlJob IsNot Nothing AndAlso Not (objavpCtrlJob.CheckIfAllJobsAborted) Then
                            ''turn on flag
                            objavpCtrlJob.IsGEMPauseJob = True
                            lpcLoadLock.lblFinishProcess.Text = SCHEDULER & "Paused By " & strHostName.ToUpper() & "...."
                            gemCommand.CommandResult = CommandResults.cmdPerformed
                        Else
                            gemCommand.CommandResult = ConstEnum.CustomRemoteCommandResult.ALL_WAFER_PROCESSING_ARE_ABORTED ' All wafer processing...aborted
                        End If

                    Case CMD_ABORT_GEM
                        objavpCtrlJob = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockCtrl.CtrlJobId)
                        If objavpCtrlJob IsNot Nothing AndAlso Not (objavpCtrlJob.CheckIfAllJobsAborted) Then
                            objLoadLockCtrl.Abort(True) ''Abort and trigger event for GEM
                            lpcLoadLock.btnAbort.Text = "Aborting"
                            lpcLoadLock.lblFinishProcess.Text = SCHEDULER & ABORT_AND_RETURN_WAFER
                            lpcLoadLock.SendMailWhenSchedulerStatusChange(STR_ABORT_AND_RETURN)
                            gemCommand.CommandResult = CommandResults.cmdPerformed
                        Else
                            gemCommand.CommandResult = ConstEnum.CustomRemoteCommandResult.ALL_WAFER_PROCESSING_ARE_ABORTED ' All wafer processing...aborted
                        End If

                    Case CMD_RESUME_GEM
                        If objLoadLockCtrl.CtrlJobId Is Nothing Then
                            gemCommand.CommandResult = CommandResults.cmdNoObject
                            Exit Sub
                        End If
                        objavpCtrlJob = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockCtrl.CtrlJobId)
                        ''if Control Job is Pause by GEM -> turn off flag 
                        If objavpCtrlJob IsNot Nothing AndAlso Not (objavpCtrlJob.CheckIfAllJobsAborted) AndAlso objavpCtrlJob.IsGEMPauseJob Then
                            ''turn off flag
                            objavpCtrlJob.IsGEMPauseJob = False
                            lpcLoadLock.lblFinishProcess.Text = SCHEDULER & "Resumed By " & strHostName.ToUpper() & "...."
                        End If
                        '''if any job is paused -> resume it
                        '''ResumeAllEquipment only resume paused job
                        Dim blnResult As Boolean = ContainerForm.ProcessPanel.ResumeAllEquipment(ConstantAndEnum.LOAD_LOCK_A)
                        If blnResult Then
                            gemCommand.CommandResult = CommandResults.cmdPerformed
                        Else
                            gemCommand.CommandResult = ConstEnum.CustomRemoteCommandResult.LL_TM_IS_NOT_ONLINE ' LL or TM is not online
                        End If

                    Case CMD_START_GEM
                        If lpcLoadLock.Start_Click(False, eRemoteResult) Then
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                               AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                              "Host send start processing LL" & strArgValues(0))
                            If eRemoteResult = ConstEnum.CustomRemoteCommandResult.SOURCE_USAGE_KWH_REACH_WARNING_LIMIT OrElse _
                               eRemoteResult = ConstEnum.CustomRemoteCommandResult.SHIELDS_QUARTZ_REACH_WARNING_LIMIT Then
                                gemCommand.CommandResult = eRemoteResult
                            Else
                                gemCommand.CommandResult = CommandResults.cmdPerformed
                            End If
                        Else
                            If eRemoteResult = Nothing Then
                                gemCommand.CommandResult = CommandResults.cmdCannotPerform
                            Else
                                gemCommand.CommandResult = eRemoteResult
                            End If
                        End If

                    Case CMD_STOP_GEM
                        objavpCtrlJob = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockCtrl.CtrlJobId)
                        If objavpCtrlJob IsNot Nothing AndAlso Not (objavpCtrlJob.CheckIfAllJobsStopped) Then
                            lpcLoadLock.Stop_Click()
                            gemCommand.CommandResult = CommandResults.cmdPerformed
                        Else
                            gemCommand.CommandResult = ConstEnum.CustomRemoteCommandResult.ALL_WAFER_PROCESSING_ARE_STOPPED ' All wafer processing...stopped
                        End If
                    Case CMD_LOAD_WAFER_GEM
                        Dim IsCassettePresent As Boolean = False
                        IsCassettePresent = IIf(strArgValues(0) = "A", ContainerForm.ProcessPanel.LLALeg.CassettePresent, _
                                                                 False)
                        If Not (lpcLoadLock.btnLoad.Text = "LOAD" AndAlso IsCassettePresent) Then
                            gemCommand.CommandResult = CommandResults.cmdCannotPerform
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                          AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                         "Host send Load command wafer in LL, Cassette is not Present" & strArgValues(0))
                        Else
                            ' CX4 has only LLA
                            If ContainerForm.CassettesPanel.lccLoadLockA.IsCassetteInUsed Then
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                          AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                         "Host send Load command wafer in LL, Cassette is in used" & strArgValues(0))
                                gemCommand.CommandResult = CommandResults.cmdCannotPerform
                            Else
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                               AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                              "Host send Load command wafer in LL" & strArgValues(0))
                                lpcLoadLock.StartLoadCassette()
                                gemCommand.CommandResult = CommandResults.cmdPerformed
                            End If
                        End If

                    Case CMD_UNLOAD_WAFER_GEM
                        If Not lpcLoadLock.btnUnload.Text = "UNLOAD" Then
                            gemCommand.CommandResult = CommandResults.cmdCannotPerform
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                          AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                         "Host send UnLoad command wafer in LL, Cassette is Unloading..." & strArgValues(0))
                        Else
                            ' CX4 has only LLA
                            If ContainerForm.CassettesPanel.lccLoadLockA.IsCassetteInUsed Then
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                          AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                         "Host send UnLoad command wafer in LL, Cassette is in used" & strArgValues(0))
                                gemCommand.CommandResult = CommandResults.cmdCannotPerform
                            Else
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                               AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                              "Host send UnLoad command wafer in LL" & strArgValues(0))
                                lpcLoadLock.StartUnLoadCassette()
                                gemCommand.CommandResult = CommandResults.cmdPerformed
                            End If
                        End If
                End Select
                ''
            ElseIf (gemCommand.Command = CMD_MARKFORRETURN_GEM) Then
                Dim processPanel As ProcessPanel = ContainerForm.ProcessPanel
                Dim ChamberNambe As String = strArgValues(0)
                If (processPanel.SECSGEM_MarkForReturn(ChamberNambe)) Then
                    gemCommand.CommandResult = CommandResults.cmdPerformed
                Else
                    gemCommand.CommandResult = CommandResults.cmdCannotPerform
                End If

            ElseIf (gemCommand.Command = CMD_MAKE_ALL_ONLINE_GEM) Then
                ContainerForm.ProcessPanel.MakeAllOnline()
                gemCommand.CommandResult = GetGEMResultAfterMakeAllOnline()

            ElseIf strArgValues.Length = 4 Then  ''select lot id port id
                Dim strLLName As String = strArgValues(0)
                Dim strLotID As String = strArgValues(1)

                '07/11/2012
                'What is the length limit for the lotid sent with PPSELECT?  
                'I had one that was about 87 characters long and the wafers just sat in the loadlock and would not process.
                If (Not CheckValidLotID(strLotID)) Then
                    gemCommand.CommandResult = CommandResults.cmdParamInvalid
                    Exit Try
                End If

                Dim strJobID As String = strArgValues(2)
                Dim strAllWaferID As String = strArgValues(3)
                Dim ListOfGEM_WaferID As String() = Nothing
                If Not String.IsNullOrEmpty(strAllWaferID) Then
                    ListOfGEM_WaferID = strAllWaferID.Split(";")
                End If

                Dim blnAccept As Boolean = False
                Dim lstChamberStations As List(Of String)
                Dim objLLElevator As LLElevator = Nothing
                Dim objLoadLock As DataManagerment.LoadLock = Nothing
                If strLLName = "A" Then
                    blnAccept = AVPLib.SequenceLib.CheckInvalidSequence(strJobID, ConstEnum.LoadLockA_STR, eRemoteResult)
                    If blnAccept Then
                        lstChamberStations = AVPLib.SequenceLib.GetChamberStations(strJobID, True) ' Get list chambers
                        'Check file Sequence is corrupted            
                        If lstChamberStations IsNot Nothing AndAlso lstChamberStations.Count > 0 Then
                            ContainerForm.ProcessPanel.lpcLoadLockA.txtLotID.Text = strLotID
                            ContainerForm.ProcessPanel.lpcLoadLockA.txtSeqID.Text = strJobID

                            '0009554: [KhoiHa - 06/15/2016] URGENT: Cassette ABORT halts the CVC tool (CVC-20) (Main Branch)
                            'solution fix: reset SeqId before assign it
                            ContainerForm.ProcessPanel.lpcLoadLockA.SeqID = String.Empty

                            ContainerForm.ProcessPanel.lpcLoadLockA.txtSeqID_MeasureString()
                            ContainerForm.ProcessPanel.lpcLoadLockA.txtSeqID.Tag = Boolean.FalseString
                            ContainerForm.ProcessPanel.lpcLoadLockA.LotID = strLotID

                            objLLElevator = EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                            objLLElevator.Build_Mapping_GEMWaferID_AVPWaferID(ListOfGEM_WaferID)
                            'update SequenceID and LotID for GEM
                            objLoadLock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
                            objLoadLock.LotID = strLotID
                            objLoadLock.SequenceID = strJobID

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                               AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                              "Host send sequence for start processing LLA: " & strJobID & " - Lot ID: " & strLotID)
                            gemCommand.CommandResult = CommandResults.cmdPerformed
                            Exit Try
                        End If
                    End If
                End If
                If eRemoteResult = Nothing Then
                    gemCommand.CommandResult = CommandResults.cmdCannotPerform
                Else
                    gemCommand.CommandResult = eRemoteResult
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function GetGEMResultAfterMakeAllOnline() As EMSERVICELib.CommandResults
        Dim cmdResult As EMSERVICELib.CommandResults = CommandResults.cmdPerformed
        Try
            'request of Khoi Ha, only check TM online after make all online
            Dim objTM As AVPLib.DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.CassettesModule.ToString)
            If Not (objTM IsNot Nothing AndAlso objTM.ControlStatus = AVPLib.DataManagerment.Equipment.ControlStatuses.ONLINE) Then
                cmdResult = CommandResults.cmdCannotPerform
            End If
            '' Make online for all chambers
            '' Chamber 1
            'If ContainerForm.Chamber1Visible AndAlso Not ContainerForm.Chamber1Panel.IsOnline Then
            '    cmdResult = CommandResults.cmdCannotPerform
            'End If

            '' Chamber 2
            'If ContainerForm.Chamber2Visible AndAlso Not ContainerForm.Chamber2Panel.IsOnline Then
            '    cmdResult = CommandResults.cmdCannotPerform
            'End If

            '' Chamber 3
            'If ContainerForm.Chamber3Visible AndAlso Not ContainerForm.Chamber3Panel.IsOnline Then
            '    cmdResult = CommandResults.cmdCannotPerform
            'End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return cmdResult
    End Function

    Private Function CheckValidLotID(ByVal strLotID As String) As Boolean
        Dim blResult As Boolean = False
        Try
            Dim rgx As New System.Text.RegularExpressions.Regex("^[a-zA-Z0-9\s_\-\.]+$")
            blResult = rgx.IsMatch(strLotID)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blResult
    End Function

    '''' <author>
    ''''    	<name> Truc Le </name>
    ''''    	<date> 2011-06-30</date>
    '''' </author>
    '''' <summary>
    '''' Only Used for AVP Secs Gem, 
    '''  Dat Cao rem code because in EJP file had define default comm and control state
    '''  Only change on EJP file
    '''' </summary>
    '''' <remarks></remarks>

    Protected Sub UpdateGemStatus(ByVal arg As Object)
        Dim eState As AVPSecsGem.GEMStateChangeArgs = CType(arg, AVPSecsGem.GEMStateChangeArgs)
        Select Case eState.AVP_StateMachine
            Case AVPSecsGemLib.AVPStateMachine.smCommunications
                Select Case eState.State
                    Case 0 ' = disabled
                        'UPDATE STATUS TO DISABLE
                        If (Me.btnCommunicationStatus.Status <> SL_CustomButton.DisplayStatus.Off) Then
                            AVPLib.Business.AVPSecsGemLib.DoOffline()
                        End If
                        Me.btnCommunicationStatus.Status = SL_CustomButton.DisplayStatus.Off
                    Case 260 ' = communicating
                        'UPDATE STATUS TO ENABLE
                        If (Me.btnCommunicationStatus.Status <> SL_CustomButton.DisplayStatus.On) Then
                            AVPLib.Business.AVPSecsGemLib.DoOnline()
                        End If
                        Me.btnCommunicationStatus.Status = SL_CustomButton.DisplayStatus.On

                        'Init Default Control State when first time
                        If (m_InitDefaultControlState = False) Then
                            'Read Config and go to Online Local or Online Remote
                            If (AVPLib.ContainerDAO.DefaultOnlineControlState) Then
                                AVPLib.Business.AVPSecsGemLib.DoControlRemote()
                            Else
                                AVPLib.Business.AVPSecsGemLib.DoControlLocal()
                            End If
                            m_InitDefaultControlState = True
                        End If
                    Case 273, 274 ' = WaitCRA | WaitCRFromHost, WaitDelay | WaitCRFromHost
                        'UPDATE STATUS TO ENABLE
                        If (Me.btnCommunicationStatus.Status <> SL_CustomButton.DisplayStatus.Unknow) Then
                            AVPLib.Business.AVPSecsGemLib.DoOffline()
                        End If
                        Me.btnCommunicationStatus.Status = SL_CustomButton.DisplayStatus.Unknow
                End Select
            Case AVPSecsGemLib.AVPStateMachine.smControl
                Select Case eState.State
                    Case 1 '=EquipOffline
                        ResetGemControlStatus()
                        btnHostOffline.Status = SL_CustomButton.DisplayStatus.On
                        AVPRobotMain.OfflineLocal = True
                    Case 2 ' AttemptOnline
                        ResetGemControlStatus()
                        'btnAttemptOnline.Status = SL_CustomButton.DisplayStatus.On
                    Case 3 ' HostOffline
                        ResetGemControlStatus()
                        btnHostOffline.Status = SL_CustomButton.DisplayStatus.On
                        AVPRobotMain.OfflineLocal = True
                        'UPDATE CONTROL TO OFFLINE
                    Case 4 '=OnlineLocal and 
                        ResetGemControlStatus()
                        btnOnlineLocal.Status = SL_CustomButton.DisplayStatus.On
                        AVPRobotMain.OnlineLocal = True
                        'UPDATE CONTROL TO ONLINE
                        'UPDATE REMOTE OFF
                    Case 5 ' =OnlineRemote
                        ResetGemControlStatus()
                        btnOnlineRemote.Status = SL_CustomButton.DisplayStatus.On
                        AVPRobotMain.OnlineRemote = True
                        'UPDATE CONTROL TO ONLINE
                        'UPDATE REMOTE ON
                End Select
            Case AVPSecsGemLib.AVPStateMachine.smProtocol
                Select Case eState.State
                    Case 0 'something
                    Case 1 'something
                End Select
            Case AVPSecsGemLib.AVPStateMachine.smSpooling
                Select Case eState.State
                    Case 0 'something
                    Case 1 'something
                End Select
        End Select

        UploadPPStatus()
        DownloadPPStatus()
        TerminalMessageStatus()

        ContainerForm.ProcessPanel.lpcLoadLockA.Enable_Disable_StartButton()
        
    End Sub

    Private Sub UploadPPStatus()
        If (Me.btnCommunicationStatus.Status = SL_CustomButton.DisplayStatus.On AndAlso _
                btnOnlineLocal.Status = SL_CustomButton.DisplayStatus.On) OrElse _
                (Me.btnCommunicationStatus.Status = SL_CustomButton.DisplayStatus.On AndAlso _
                btnOnlineRemote.Status = SL_CustomButton.DisplayStatus.On) Then
            If (m_isUpload_Processing = False) Then
                btnUploadProcess.Enabled = AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_014)
            End If
        ElseIf (Me.btnCommunicationStatus.Status = SL_CustomButton.DisplayStatus.Off) OrElse _
                (btnOnlineLocal.Status = SL_CustomButton.DisplayStatus.Off AndAlso _
                btnOnlineRemote.Status = SL_CustomButton.DisplayStatus.Off) Then
            btnUploadProcess.Enabled = False
            m_iUpload_ProcessingTime = 0
        End If
        StopUploadDownLoadTimer()
    End Sub

    Private Sub DownloadPPStatus()
        If Me.btnCommunicationStatus.Status = SL_CustomButton.DisplayStatus.On AndAlso _
                (btnOnlineLocal.Status = SL_CustomButton.DisplayStatus.On OrElse _
                         btnOnlineRemote.Status = SL_CustomButton.DisplayStatus.On) Then
            If (m_isUpload_Processing = False) Then
                btnDownloadProcess.Enabled = AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_014)
            End If
        ElseIf (Me.btnCommunicationStatus.Status = SL_CustomButton.DisplayStatus.Off) OrElse _
                (btnOnlineLocal.Status = SL_CustomButton.DisplayStatus.Off AndAlso _
                btnOnlineRemote.Status = SL_CustomButton.DisplayStatus.Off) Then
            btnDownloadProcess.Enabled = False
            m_iDownload_ProcessingTime = 0
        End If
        StopUploadDownLoadTimer()
    End Sub

    '''' <author>
    ''''    	<name> Tin.Tran </name>
    ''''    	<date> 2012-07-31</date>
    ''''        <do> Fill up function TerminalMessageStatus()
    '''' </author>
    '''' <summary>

    Private Sub TerminalMessageStatus()
        If Me.btnCommunicationStatus.Status = SL_CustomButton.DisplayStatus.On AndAlso _
               (btnOnlineLocal.Status = SL_CustomButton.DisplayStatus.On OrElse _
                      btnOnlineRemote.Status = SL_CustomButton.DisplayStatus.On) Then
            txtMessageToHost.Enabled = AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_014)
            btnChatPopUp.Enabled = AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_014)
            chkUsePopUpTerminal.Enabled = AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_014)
            If EnablePopUpTerminal Then
                PopUpTerminalMessage.txtMessageToHost.Enabled = AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_014)
            End If
        Else
            txtMessageToHost.Enabled = False
            btnChatPopUp.Enabled = False
            chkUsePopUpTerminal.Enabled = False
        End If
    End Sub

#If AVP_PLATFORM = "CX" Then
    Protected Sub HostPPDeleteFile(ByVal arg As Object)
        Try
            Dim success As Boolean = True
            Dim PPSendFileArgs As AVPSecsGemLib.AVPSecsGem.HostPPDeleteFileArgs = CType(arg, AVPSecsGemLib.AVPSecsGem.HostPPDeleteFileArgs)
            Dim sFileName As String = String.Empty

            For Each sFileName In PPSendFileArgs.sFileName
                If (CheckFileName(sFileName, PPSendFileArgs.Result) = False) Then
                    PPSendFileArgs.Result = EMSERVICELib.RecipeAck.raRejected
                    Exit Sub
                End If
            Next
            DeleteFileNames(PPSendFileArgs.sFileName)
            PPSendFileArgs.Result = EMSERVICELib.RecipeAck.raAccepted

            UpdateListPPName()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End If
    '''' <author>
    ''''    	<name> Truc Le </name>
    ''''    	<date> 2011-06-30</date>
    '''' </author>
    '''' <summary>
    '''' Only Used for AVP Secs Gem, 
    '''' <author>
    ''''    	<name> Tin.Tran </name>
    ''''    	<date> 2012-07-31</date>
    ''''        <do> Modified UpdateTerminalService </do>
    '''' </author>
    '''' </summary>
    '''' <remarks></remarks>
    Protected Sub UpdateTerminalService(ByVal arg As Object)
        Try
            Dim eText As AVPSecsGem.TerminalServiceArgs = CType(arg, AVPSecsGem.TerminalServiceArgs)
            txtMessageFromHost.Text = String.Empty
            txtMessageFromHost.Text &= "<-" & eText.TextMessage
            txtMessageFromHost.SelectionStart = txtMessageFromHost.TextLength
            txtMessageFromHost.ScrollToCaret()
            'sync
            If EnablePopUpTerminal Then
                PopUpTerminalMessage.Show()
                '0004813: [KhoiHa - 03/25/2014][GEM] Missing S6F1 traces!
                DisableFormsAfterOpenPopUp()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function RecipeInUse(ByVal recipeID As String, ByRef result As EMSERVICELib.RecipeAck) As Boolean
        Dim LLA_Sequence As String = String.Empty

        'get LLA Sequence
        LLA_Sequence = GetRunningSequenceName(AVPLib.ConstEnum.LoadLockA_STR)
        If (LLA_Sequence <> String.Empty And CheckRecipeInSequence(recipeID, LLA_Sequence) = True) Then
            result = EMSERVICELib.RecipeAck.raRejected
            Return True
        End If

        Return False
    End Function

    Private Function SequenceInUse(ByVal sName As String, ByRef result As EMSERVICELib.RecipeAck) As Boolean
        Dim LLA_Sequence As String = String.Empty
        Dim LLB_Sequence As String = String.Empty

        'get LLA Sequence
        LLA_Sequence = GetRunningSequenceName(ConstEnum.LoadLockA_STR)
        If (LLA_Sequence = sName) Then
            result = EMSERVICELib.RecipeAck.raRejected
            Return True
        End If

        Return False
    End Function

    Private Function WaferFlowInUse(ByVal sName As String, ByRef result As EMSERVICELib.RecipeAck) As Boolean
        Dim LLA_Sequence As String = String.Empty

        LLA_Sequence = GetRunningSequenceName(ConstEnum.LoadLockA_STR)
        If (LLA_Sequence <> String.Empty AndAlso CheckWaferFlowInSequence(sName, LLA_Sequence) = True) Then
            result = EMSERVICELib.RecipeAck.raRejected
            Return True
        End If

        Return False
    End Function

    Private Function GetRunningSequenceName(ByVal sLoadLockName As String) As String
        Try

            Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = AVPLib.Business.ControllerManager.GetController(sLoadLockName)
            If (objLoadLockCtrl Is Nothing) Then
                Return String.Empty
            End If
            Dim jobmanager As AVPLib.Business.AVPJobManager = AVPLib.Business.AVPCore.Instance().JobManager
            If (jobmanager Is Nothing) Then
                Return String.Empty
            End If
            Dim objControlJob As AVPLib.Business.AVPControlJob = jobmanager.GetControlJob(objLoadLockCtrl.CtrlJobId)
            If (objControlJob Is Nothing) Then
                Return String.Empty
            End If
            If (objControlJob.IsAutoTransferJob) Then
                Return objControlJob.SequenceID
            End If
        Catch
            Return String.Empty
        End Try
        Return String.Empty
    End Function

    Private Sub DeleteFileNames(ByVal sFileNames As String())
        Try
            'Parse recipeID to get Sequence/Waferflow/Recipe
            'Get AvpJobmanager to check SequenceInUse/WaferFlowInUse/RecipeInUse

            For Each Item As String In sFileNames
                Dim param As String() = Item.Split(".")
                If (param.Length < 2) Then
                    Exit Sub
                Else
                    Dim FileType As String = param(0)
                    If (FileType.ToUpper() <> "SEQUENCE" AndAlso _
                            FileType.ToUpper() <> "RECIPE" AndAlso _
                            FileType.ToUpper() <> "WAFERFLOW") Then
                        Exit Sub
                    Else
                        If (FileType.ToUpper() = "SEQUENCE") Then
                            Dim pos1 As Integer = Item.IndexOf(".") + 1
                            Dim pos2 As Integer = Item.Length
                            Dim FileName As String = Item.Substring(pos1, pos2 - pos1) 'ex abc.xml
                            System.IO.File.Delete(AVPLib.ContainerDAO.FPath_SequenceData & "\\" & FileName + ".xml")
                        ElseIf (FileType.ToUpper() = "WAFERFLOW") Then
                            Dim firstElement As String = Item.Substring(0, Item.IndexOf(".") + 1)
                            Dim WaferFlowName As String = Item.Replace(firstElement, "")
                            System.IO.File.Delete(AVPLib.ContainerDAO.FPath_WaferFlow + "\\" + WaferFlowName + ".xml")
                        ElseIf (FileType.ToUpper() = "RECIPE") Then
                            Dim firstElement As String = Item.Substring(0, Item.IndexOf(".") + 1)
                            Dim subFileName As String = Item.Replace(firstElement, "")
                            Dim pos1 As Integer = subFileName.IndexOf(".")
                            Dim RecipeName As String = subFileName.Substring(pos1 + 1, subFileName.Length - pos1 - 1)
                            Dim ChamberName As String = subFileName.Substring(0, pos1)

                            System.IO.File.Delete(AVPLib.ContainerDAO.FPath_ChamberRecipe & "\\" & AVPLib.Utils.chamberName2ChamberID(ChamberName) + "\\" & RecipeName & ".xml")
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function CheckFileName(ByVal recipeID As String, ByRef result As EMSERVICELib.RecipeAck) As Boolean
        Try
            'Parse recipeID to get Sequence/Waferflow/Recipe
            'Get AvpJobmanager to check SequenceInUse/WaferFlowInUse/RecipeInUse
            Dim param As String() = recipeID.Split(".")
            If (param.Length < 2) Then
                Return False
            Else
                Dim FileType As String = param(0)
                If (FileType.ToUpper() <> "SEQUENCE" AndAlso _
                        FileType.ToUpper() <> "RECIPE" AndAlso _
                        FileType.ToUpper() <> "WAFERFLOW") Then
                    result = EMSERVICELib.RecipeAck.raInvalidID
                    Return False
                Else
                    If (FileType.ToUpper() = "SEQUENCE") Then
                        Dim pos1 As Integer = recipeID.IndexOf(".") + 1
                        Dim pos2 As Integer = recipeID.Length
                        Dim FileName As String = recipeID.Substring(pos1, pos2 - pos1) 'ex abc.xml
                        If (SequenceInUse(FileName, result)) Then
                            Return False
                        Else
                            Return True
                        End If
                    ElseIf (FileType.ToUpper() = "WAFERFLOW") Then
                        Dim firstElement As String = recipeID.Substring(0, recipeID.IndexOf(".") + 1)
                        Dim WaferFlowName As String = recipeID.Replace(firstElement, "")

                        If (WaferFlowInUse(WaferFlowName, result)) Then
                            Return False
                        Else
                            Return True
                        End If
                    ElseIf (FileType.ToUpper() = "RECIPE") Then
                        Dim firstElement As String = recipeID.Substring(0, recipeID.IndexOf(".") + 1)
                        Dim subFileName As String = recipeID.Replace(firstElement, "")
                        Dim pos1 As Integer = subFileName.IndexOf(".")
                        Dim RecipeName As String = subFileName.Substring(pos1 + 1, subFileName.Length - pos1 - 1)
                        Dim ChamberName As String = subFileName.Substring(0, pos1)
                        If (RecipeInUse(RecipeName, result)) Then
                            Return False
                        Else
                            Return True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    Private Function CheckRecipeInSequence(ByVal sRecipe As String, ByVal sSequence As String) As Boolean
        Dim sequenFileName As String = AVPLib.Utils.GetFileName(sSequence, "xml")
        Dim filepath As String = AVPLib.ContainerDAO.FPath_SequenceData + "\\" + sequenFileName
        If (System.IO.File.Exists(filepath) = False) Then
            Return False
        End If

        Dim wfSequence As AVPLib.DBWaferList = Nothing
        Dim strDescription As String = String.Empty

        If (Not AVPLib.ContainerData.GetSequence(filepath, wfSequence, strDescription)) Then
            Return False
        End If

        For Each waferSlot As DBWaferSlot In wfSequence.WaferList
            For Each segStep As DBSeqStep In waferSlot.WaferSequence.SeqStepList
                Dim recipeFIle As String = segStep.RecipeName
                If (recipeFIle = sRecipe) Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function

    Private Function CheckWaferFlowInSequence(ByVal sWaferFlow As String, ByVal sSequence As String) As Boolean
        Dim sequenFileName As String = AVPLib.Utils.GetFileName(sSequence, "xml")
        Dim filepath As String = AVPLib.ContainerDAO.FPath_SequenceData & "\\" & sequenFileName

        If (System.IO.File.Exists(filepath) = False) Then
            Return False
        End If
        Dim wfSequence As AVPLib.DBWaferList = Nothing
        Dim strDescription As String = String.Empty
        ' If can not open the flow
        If (Not AVPLib.ContainerData.GetSequence(filepath, wfSequence, strDescription)) Then
            Return False
        End If

        Dim waferSlot As DBWaferSlot
        For Each waferSlot In wfSequence.WaferList
            If (waferSlot.WaferSequence.SeqName = sWaferFlow) Then
                Return True
            End If
        Next
        Return True
    End Function
#End Region

#Region "Process Program from GUI"

    Private Sub rbnWaferFlow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnWaferFlow.CheckedChanged
        If rbnWaferFlow.Checked Then
            LoadPPFile(False, True, False)
            rbnRecipe.Checked = False
            rbnSequence.Checked = False
        End If
    End Sub

    Private Sub rbnRecipe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnRecipe.CheckedChanged
        If rbnRecipe.Checked Then
            LoadPPFile(False, False, True)
            rbnWaferFlow.Checked = False
            rbnSequence.Checked = False
        End If
    End Sub

    Private Sub rbnSequence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnSequence.CheckedChanged
        If rbnSequence.Checked Then
            LoadPPFile(True, False, False)
            rbnRecipe.Checked = False
            rbnWaferFlow.Checked = False
        End If
    End Sub

    Private Sub btnUploadProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadProcess.Click, btnDownloadProcess.Click
        SecsGem_EventHandler.UpLoad_Download_PP(sender, e)
    End Sub

#End Region

    Private Sub UploadDownloadTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadDownloadTimer.Tick
        If (m_isUpload_Processing = True) Then
            If (btnOffline.Enabled = True) AndAlso _
            (btnOnlineLocal.Enabled = True OrElse btnOnlineRemote.Enabled = True) Then
                m_iUpload_ProcessingTime += 1

                If (m_iUpload_ProcessingTime > AVPConstants.m_iUpload_ProcessingTimeout) Then
                    btnUploadProcess.Enabled = True
                    m_isUpload_Processing = False
                    StopUploadDownLoadTimer()
                    m_iUpload_ProcessingTime = 0
                    Utils.ShowAVPMessageBox("Transaction Timeout! Upload PP File Failed", "GEM Control", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                End If
            Else
                m_iUpload_ProcessingTime = 0
            End If
        End If
        If (m_isDownload_Processing = True) Then
            If (btnOffline.Enabled = True) AndAlso _
                (btnOnlineLocal.Enabled = True OrElse btnOnlineRemote.Enabled = True) Then
                m_iDownload_ProcessingTime += 1

                If (m_iDownload_ProcessingTime > AVPConstants.m_iDownload_ProcessingTimeout) Then
                    btnDownloadProcess.Enabled = True
                    m_isDownload_Processing = False
                    m_iDownload_ProcessingTime = 0
                    StopUploadDownLoadTimer()
                    Utils.ShowAVPMessageBox("Transaction Timeout! Download PP File Failed", "GEM Control", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                End If
            Else
                m_iDownload_ProcessingTime = 0
            End If
        End If
    End Sub

    Private Function StopUploadDownLoadTimer() As Boolean
        If (m_isDownload_Processing = False And m_isUpload_Processing = False) Then
            UploadDownloadTimer.Enabled = False
            m_iUpload_ProcessingTime = 0
            m_iDownload_ProcessingTime = 0
        End If
    End Function

    '''' <author>
    ''''    	<name> Hoa Nguyen </name>
    ''''    	<date> 2011-07-20</date>
    '''' </author>
    '''' <summary>
    '''' Update Variable Loader For Gem When Init
    '''' </summary>
    '''' <remarks></remarks>
    Private Sub UpdateVariableLoaderForGemWhenInit()
        Try
            For Each eqt As Equipment In DataManagerment.EquipmentManager.EquipmentList.Values
                eqt.UpdateVariableForGemWhenInit()
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function SelectFile(ByVal inFile As String, ByRef fileType As String) As String
        Dim fileName As String = AVPLib.Utils.GetFileName(inFile, False)
        Dim sFileName As String = AVPLib.ContainerDAO.FPath_ChamberConfig
        If fileName.ToUpper.StartsWith(EXT_RECIPE_FILE) Then
            fileType = RECIPE_TYPE
            Dim tmp As Array = fileName.Split(".") ''file name must be recipe.PM1.abc.xml
            If tmp.Length >= 3 Then
                Dim schamber As String = AVPLib.Utils.chamberName2ChamberID(tmp(1).ToString().ToUpper)

                Select Case schamber
                    Case AVPLib.ConstEnum.Equipments.Aligner.ToString().ToUpper
                        sFileName = sFileName & "\ALIGNER.xsd"
                    Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                        If RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD Then
                            sFileName = sFileName & "\PVD.xsd"
                        ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
                            sFileName = sFileName & "\IBE.xsd"
                        ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD4 Then
                            sFileName = sFileName & "\PVD4.xsd"
                        ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD5T Then
                            sFileName = sFileName & "\PVD5T.xsd"
                        End If
                    Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                        If RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD Then
                            sFileName = sFileName & "\PVD.xsd"
                        ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
                            sFileName = sFileName & "\IBE.xsd"
                        ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD4 Then
                            sFileName = sFileName & "\PVD4.xsd"
                        ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD5T Then
                            sFileName = sFileName & "\PVD5T.xsd"
                        End If
                    Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                        If RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD Then
                            sFileName = sFileName & "\PVD.xsd"
                        ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
                            sFileName = sFileName & "\IBE.xsd"
                        ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD4 Then
                            sFileName = sFileName & "\PVD4.xsd"
                        ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD5T Then
                            sFileName = sFileName & "\PVD5T.xsd"
                        End If
                    Case AVPLib.RobotConfigurationValues.ANY_IBE_CHAMBER
                        sFileName = sFileName & "\IBE.xsd"
                End Select
            End If

        ElseIf fileName.ToUpper.StartsWith(EXT_WAFERFLOW_FILE) Then
            fileType = WAFERFLOW_TYPE
            sFileName = sFileName & "\WaferFlow.xsd"
        ElseIf fileName.ToUpper.StartsWith(EXT_SEQUENCE_FILE) Then
            fileType = SEQUENCE_TYPE
            sFileName = sFileName & "\Sequence.xsd"
        End If
        Return sFileName
    End Function

    Private Function XmlValidate(ByVal inFile As String, ByVal xsdPath As String) As Boolean
        Try
            Dim xmlRead As Xml.XmlDocument = New Xml.XmlDocument()
            Dim objSet As Xml.XmlReader = Xml.XmlReader.Create(xsdPath)
            xmlRead.Load(inFile)
            xmlRead.Schemas.Add("", objSet)
            err_validation = ""
            xmlRead.Validate(AddressOf ValidationEventHandler)
            If err_validation = "" Then
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return False
    End Function

    Private Sub ValidationEventHandler(ByVal sender As Object, ByVal e As System.Xml.Schema.ValidationEventArgs)
        err_validation += e.Message & "<br />"
    End Sub

    Private Function CheckRecipeWaferFlowExist(ByVal inFile As String) As Boolean
        Try

            Dim blResult As Boolean = False
            Dim XPATH_STEP = "/WaferFlow/StepList/Step"
            Dim XPATH_WAFER = "/ControlJob/WaferList/Wafer"

            Dim xmlDoc As System.Xml.XmlDocument = New System.Xml.XmlDocument()
            xmlDoc.Load(inFile)
            Dim fileName As String = AVPLib.Utils.GetFileName(inFile, False)
            If fileName.ToUpper.StartsWith(EXT_WAFERFLOW_FILE) Then
                'Dim RecipeList As String() = System.IO.Directory.GetFiles(AVPLib.ContainerDAO.FPath_ChamberRecipe)
                Dim nodeList As Xml.XmlNodeList = xmlDoc.SelectNodes(XPATH_STEP)
                For Each childNode As Xml.XmlNode In nodeList
                    Dim RecipeList As String() = {}
                    Dim chamber As String = childNode.SelectSingleNode("StationList").FirstChild.InnerText
                    Dim recipeNode As String = childNode.SelectSingleNode("RecipeName").InnerText

                    If (AVPLib.Utils.IsIBEChamber_ANYIBE(chamber)) Then
                        chamber = AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & RobotConfigurationValues.ANY_IBE_CHAMBER & "\"
                    Else
                        chamber = AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & chamber & "\"
                    End If

                    RecipeList = System.IO.Directory.GetFiles(chamber, "*.xml")
                    If RecipeList.Length > 0 Then
                        For i As Integer = 0 To RecipeList.Length - 1
                            Dim recipeName As String = AVPLib.Utils.GetFileName(RecipeList(i), True)
                            If recipeNode = recipeName Then
                                blResult = True
                                Exit For
                            Else
                                blResult = False
                            End If
                        Next
                        If blResult = False Then
                            Return False
                        End If
                    Else
                        blResult = False
                    End If

                Next
            ElseIf fileName.ToUpper.StartsWith(EXT_SEQUENCE_FILE) Then
                Dim WaferLost As String() = System.IO.Directory.GetFiles(AVPLib.ContainerDAO.FPath_WaferFlow)
                Dim nodeList As Xml.XmlNodeList = xmlDoc.SelectNodes(XPATH_WAFER)
                For Each childNode As Xml.XmlNode In nodeList
                    Dim waferflow As String = childNode.SelectSingleNode("WaferFlow").InnerText
                    If String.IsNullOrEmpty(Trim(waferflow)) Then
                        Continue For
                    End If
                    For i As Integer = 0 To WaferLost.Length - 1
                        Dim waferFlie = AVPLib.Utils.GetFileName(WaferLost(i), True)
                        If waferflow = waferFlie Then
                            blResult = True
                            Exit For
                        Else
                            blResult = False
                        End If
                    Next
                    If blResult = False Then
                        Return False
                    End If
                Next
            End If

            Return blResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-10-13</date>
    ''' </author>
    ''' <summary>
    '''  UpdateListPPName
    ''' </summary>
    Private Sub UpdateListPPName()
        Try
            If rbnRecipe.Checked Then
                LoadRecipePPFileName(Nothing, Nothing)
            ElseIf rbnWaferFlow.Checked Then
                LoadWaferFlowPPFileName(Nothing, Nothing)
            ElseIf rbnSequence.Checked Then
                LoadSequencePPFileName(Nothing, Nothing)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub saveToConfigFile(ByVal TrueFalseValue As Boolean, ByVal strConfig As String)
        Try
            Dim xmldoc As System.Xml.XmlDocument = AVPLib.ContainerDAO.SystemConfigDoc
            ' path of device net config
            Dim root As System.Xml.XmlNode = xmldoc.SelectSingleNode(strConfig)
            If (root IsNot Nothing) Then
                root.InnerText = TrueFalseValue.ToString()
                BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SystemConfig, xmldoc)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private bCurrentInitOnlineRemote As Boolean = False
    Private bCurrentInitOnlineLocal As Boolean = False
    Private Sub cbOnlineRemote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOnlineRemote.Click
        If (cbOnlineRemote.Checked = True AndAlso bCurrentInitOnlineRemote = False) Then
            Dim strMessageText As String = "Do you want to change default startup online state?"
            If Utils.ShowAVPMessageBox(strMessageText, "GEM Control", MessageBoxIcon.Information) = DialogResult.OK Then
                bCurrentInitOnlineRemote = True
                bCurrentInitOnlineLocal = False
                saveToConfigFile(cbOnlineRemote.Checked, ConstEnum.XPATH_DEFAULT_CONTROL_STATE)
            Else
                cbOnlineRemote.Checked = False
                cbOnlineLocal.Checked = True
            End If
        End If
    End Sub

    Private Sub cbOnlineLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOnlineLocal.Click
        If (cbOnlineLocal.Checked = True AndAlso bCurrentInitOnlineLocal = False) Then
            Dim strMessageText As String = "Do you want to change default startup online state?"
            If Utils.ShowAVPMessageBox(strMessageText, "GEM Control", MessageBoxIcon.Information) = DialogResult.OK Then
                bCurrentInitOnlineLocal = True
                bCurrentInitOnlineRemote = False
                saveToConfigFile(cbOnlineRemote.Checked, ConstEnum.XPATH_DEFAULT_CONTROL_STATE)
            Else
                cbOnlineRemote.Checked = True
                cbOnlineLocal.Checked = False
            End If
        End If
    End Sub

    Private Sub btnChatPopUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChatPopUp.Click
        PopUpTerminalMessage.Show()
        '0004813: [KhoiHa - 03/25/2014][GEM] Missing S6F1 traces!
        DisableFormsAfterOpenPopUp()
    End Sub

    Private Sub chkUsePopUpTerminal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUsePopUpTerminal.Click
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Dim strMessageText As String = "{0} Pop-Up Terminal Message?"
                If Not Utils.ShowAVPMessageBox(String.Format(strMessageText, IIf(chkUsePopUpTerminal.Checked, "Enable", "Disable")), "GEM Control", MessageBoxIcon.Information) = DialogResult.OK Then
                    chkUsePopUpTerminal.Checked = Not chkUsePopUpTerminal.Checked
                End If
                If chkUsePopUpTerminal.Checked Then
                    btnChatPopUp.Enabled = True
                    m_EnablePopUpTerminal = True
                Else
                    btnChatPopUp.Enabled = False
                    m_EnablePopUpTerminal = False
                End If
                saveToConfigFile(m_EnablePopUpTerminal, ConstEnum.XPATH_ALLOW_POPUP_TERMINALMESSAGE)

            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try


    End Sub

    '''' <author>
    ''''    	<name> Vy Nguyen </name>
    ''''    	<date> 03-28-2014 </date>
    '''' </author>
    '''' <summary>
    '''' Only Used for AVP Secs Gem, 
    '''' <remarks></remarks>
    Private Sub DisableFormsAfterOpenPopUp()
        ' In active SEC/GEM tab
        Me.InactiveForm()
        Me.PopUpTerminalMessage.txtMessageToHost.Enabled = True

        ' Block other button and tab
        AVPRobotMain.btnProcess.Enabled = False
        AVPRobotMain.btnEditor.Enabled = False
        AVPRobotMain.btnMaintenance.Enabled = False
        AVPRobotMain.btnSetup.Enabled = False
        AVPRobotMain.btnDataLog.Enabled = False

        'Process Panel
        ContainerForm.ProcessPanel.Enabled = False

        ' Alarm
        AVPRobotMain.aplAlarm.Enabled = False

        ' PM Connection status
        AVPRobotMain.pnlPMConnection.Enabled = False

        ' Login/Host
        AVPRobotMain.AVPLoginPanel.Enabled = False
        AVPRobotMain.AVPCommunicationPanel.Enabled = False

        ' All tabs in maintenance
        AVPRobotMain.tabMain.Enabled = False
        AVPRobotMain.tabSetup.Enabled = False
        AVPRobotMain.tabDataLog.Enabled = False
        AVPRobotMain.tabEditor.Enabled = False
    End Sub
End Class
