Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ContainerDAO
Imports AVPLib.ConstEnum
Imports AVPLib.Business
Imports AVPLib.DataManagerment
Imports System.ComponentModel
Imports AVPControls

Public Class LockProcessControl
#Region "Class Constants & Variables"
    Private m_intTimerCount_BlinkText As Integer = 100
    Private isClickAbort As Boolean = True
    Private isCheckPermission As Boolean = False
    Public Enum DisplayStyle
        [Left] = 0
        [Right] = 1
    End Enum
    Private Const BUTTON_WIDTH As Integer = 294

    Private m_intDisplayStyle As DisplayStyle
    Private m_ProcessStatus As ProcessStatuses
    Private m_arrWafer As AVPLib.AVPWaferInfo()

    ' For Lot ID and Sequence
    Private m_strLotID As String = String.Empty
    Private m_strSeqID As String = String.Empty
    Private m_strLotIDCharFitted As Integer
    Private m_strSeqIDCharFitted As Integer
    Private m_sf As StringFormat = Nothing

    Private m_strHeaderText_On As String
    Private m_strHeaderText_Off As String

    Private m_LotIDGraphics As Graphics
    Private m_SeqIDGraphics As Graphics

    Private m_isInCycleMode As Boolean = False
    Private m_isCycleInATMMode As Boolean = False

    Public Event StartAutoProcess(ByVal sender As Object, ByVal e As EventArgs)
    Public Event PauseAutoProcesss(ByVal sender As Object, ByVal e As EventArgs)
    Public Event StopAutoProcess(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ResumeAutoProcess(ByVal sender As Object, ByVal e As EventArgs)
    Public Event AbortAutoProcess(ByVal sender As Object, ByVal e As EventArgs)
    Public Event FinishedAutoProcess(ByVal sender As Object, ByVal e As EventArgs)

    Public Event LoadProcess(ByVal sender As Object, ByVal e As EventArgs)
    Public Event UnLoadProcess(ByVal sender As Object, ByVal e As EventArgs)

    Public Event StopLoadProcess(ByVal sender As Object, ByVal e As EventArgs)
    Public Event StopUnLoadProcess(ByVal sender As Object, ByVal e As EventArgs)
    Public Event FinishedLoadProcess(ByVal sender As Object, ByVal e As EventArgs)
    Public Event FinishedUnLoadProcess(ByVal sender As Object, ByVal e As EventArgs)

    Private m_ChamberStations As List(Of String)
    Public m_blnStopSequenceByClickAbort As Boolean = False
    Public m_blnStopSequenceByClickStop As Boolean = False

    Private testScheduler As Integer = 0
#End Region

#Region "Properties"
    Public Property IsInCycleMode() As Boolean
        Get
            Return m_isInCycleMode
        End Get
        Set(ByVal value As Boolean)
            m_isInCycleMode = value
            If value Then
                Me.Header.OffText = Me.Header.OffText + " - Cycling"
                Me.Header.OnText = Me.Header.OnText + " - Cycling"
                Me.Header.ColorText_OnStatus = Color.Red
                Me.Header.ColorText_OffStatus = Color.Red
            Else
                Me.Header.OffText = HeaderText_Off
                Me.Header.OnText = HeaderText_On
                Me.Header.ColorText_OnStatus = Color.Black
                Me.Header.ColorText_OffStatus = Color.White
            End If
            Me.Header.Text = IIf(Me.Header.Status = DisplayStatus.On, Me.Header.OnText, Me.Header.OffText)
        End Set
    End Property

    Public Property HeaderText_On() As String
        Get
            Return m_strHeaderText_On
        End Get
        Set(ByVal value As String)
            m_strHeaderText_On = value
            Me.Header.OnText = m_strHeaderText_On
        End Set
    End Property

    Public Property HeaderText_Off() As String
        Get
            Return m_strHeaderText_Off
        End Get
        Set(ByVal value As String)
            m_strHeaderText_Off = value
            Me.Header.OffText = m_strHeaderText_Off
        End Set
    End Property

    Public Property ProcessStatus()
        Get
            Return m_ProcessStatus
        End Get
        Set(ByVal value)
            m_ProcessStatus = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>    
    ''' <summary>
    ''' Get or set value to align all child controls inside this user control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlignStyle() As DisplayStyle
        Get
            AlignStyle = m_intDisplayStyle
        End Get
        Set(ByVal value As DisplayStyle)
            Try
                m_intDisplayStyle = value
                If (m_intDisplayStyle = DisplayStyle.Left) Then
                    Me.AlignLeft()
                Else
                    Me.AlignRight()
                End If
                Me.Refresh()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-16</date>
    ''' </author>    
    ''' <summary>
    ''' CheckPermission
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CheckingPermission() As Boolean
        Get
            Return isCheckPermission
        End Get
        Set(ByVal value As Boolean)
            Try
                isCheckPermission = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-04-05</date>
    ''' </author>    
    ''' <summary>
    ''' Lot ID: for internal use
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LotID() As String
        Get
            Return m_strLotID
        End Get
        Set(ByVal value As String)
            m_strLotID = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-04-05</date>
    ''' </author>    
    ''' <summary>
    ''' Seq ID: for internal use, in some case SeqID is not the same txtSeqID.Text
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SeqID() As String
        Get
            Return m_strSeqID
        End Get
        Set(ByVal value As String)
            If (m_strSeqID <> value) Then
                m_strSeqID = value
                'check valid
                SequenceIDTextChange(value)

                'if not error
                If (m_strSeqID.Length > 0) Then
                    m_strSeqID = value
                    If Not (String.IsNullOrEmpty(value)) Then
                        AVPLib.Business.AVPSecsGemLib.TriggerEvent(ConstantAndEnum.LOAD_LOCK_A, "PPSelected")
                    End If
                End If

            End If
        End Set
    End Property
    Sub SequenceIDTextChange(ByVal strValue As String)
        Dim strLLName As String = ConstantAndEnum.LOAD_LOCK_A
        Dim blnShowPopUp As Boolean = False
        If Not Boolean.TryParse(txtSeqID.Tag, blnShowPopUp) Then
            blnShowPopUp = False
        End If
        'check invalid sequence
        If AVPLib.SequenceLib.CheckInvalidSequence(strValue, strLLName) = False AndAlso Not String.IsNullOrEmpty(strValue) Then
            If blnShowPopUp Then
                Utils.ShowAVPMessageBox("Sequence [" & strValue & "] Is Invalid. Related Recipe Does Not Exist.", WAFER_PROCESSING, MessageBoxIcon.Error, MessageBoxButtons.OK)
            End If
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                             AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                             "[Main Screen] " + "Sequence file error")
            AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
            txtSeqID.Text = String.Empty
            m_strSeqID = String.Empty
            Exit Sub
        End If

        m_ChamberStations = AVPLib.SequenceLib.GetChamberStations(strValue, True) ' Get list chambers
        'Check file Sequence is corrupted            
        If (m_ChamberStations Is Nothing OrElse m_ChamberStations.Count = 0) AndAlso Not String.IsNullOrEmpty(strValue) Then
            If blnShowPopUp Then
                Utils.ShowAVPMessageBox("Sequence [" & strValue & "] Is Invalid. Related WaferFlow Does Not Exist.", WAFER_PROCESSING, MessageBoxIcon.Error, MessageBoxButtons.OK)
            End If
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                             AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                             "[Main Screen] " + "Sequence file error.")
            AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
            txtSeqID.Text = String.Empty
            m_strSeqID = String.Empty
        End If
    End Sub

    <DefaultValue(GetType(Integer), "12")> _
    Public Property NumSlot() As Integer
        Get
            Return psgPressureGraph.BarsNum
        End Get
        Set(ByVal value As Integer)
            psgPressureGraph.BarsNum = value
            If Me.AlignStyle = DisplayStyle.Right Then
                AlignRight()
            Else
                AlignLeft()
            End If
        End Set
    End Property

    Public ReadOnly Property ChamberInUse() As List(Of String)
        Get
            Return m_ChamberStations
        End Get
    End Property

#End Region

#Region "Constructors & Dispose"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Initiate Lock process control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_intDisplayStyle = DisplayStyle.Left

        ' Calculate the length of SeqID and LotID text box
        m_sf = New StringFormat(StringFormatFlags.NoWrap)
        m_sf.LineAlignment = StringAlignment.Center
        m_sf.Alignment = StringAlignment.Near
        m_sf.Trimming = StringTrimming.EllipsisCharacter

        m_LotIDGraphics = txtLotID.CreateGraphics()
        m_SeqIDGraphics = txtSeqID.CreateGraphics()

        ' Default is not enable
        SetTextBoxState(txtSeqID, False)
        tmBlinkText.Enabled = True
        tmBlinkText.Interval = 1000
        lblFinishProcess.Visible = True
        lblFinishProcess.Text = SCHEDULER & IDLE
        btnStart.Enabled = False
        txtSeqID.Tag = Boolean.FalseString
        Me.Header.Cursor = Cursors.Hand
    End Sub
#End Region

#Region "Public method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle all wafer are processed
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FinishProcess()
        Try
            btnStart.Text = START
            Me.EnableForm(True)
            lblFinishProcess.Text = SCHEDULER & COMPLETED_PROCESSING
            lblFinishLoadUnload.Visible = False
            Dim e As New EventArgs()
            RaiseEvent FinishedAutoProcess(Me, e)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle all wafer are processed
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FinishLoad()
        Try
            Dim e As New EventArgs()
            If btnStart.Text = START Then
                lblFinishProcess.Text = SCHEDULER & IDLE
            Else
                lblFinishProcess.Text = SCHEDULER & RUNNING
            End If
            lblFinishLoadUnload.Visible = False
            RaiseEvent FinishedLoadProcess(Me, e)
            ContainerForm.CassettesPanel.lccLoadLockA.IsAllowAction = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle all wafer are processed
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FinishUnLoad()
        Try
            Dim e As New EventArgs()
            lblFinishProcess.Text = SCHEDULER & IDLE
            lblFinishLoadUnload.Visible = False
            RaiseEvent FinishedUnLoadProcess(Me, e)
            ContainerForm.CassettesPanel.lccLoadLockA.IsAllowAction = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stgGraph As New StatusGraph(psgPressureGraph)
            Dim slbPresure As New StatusPressureLabel(lblPressure)
            Dim btnStart As New StatusButtonProcessStart(Me.btnStart)
            Dim btnLoad As New StatusButton(Me.btnLoad)
            Dim btnUnload As New StatusButton(Me.btnUnload)
            Dim btnAbort As New StatusButton(Me.btnAbort)
            Dim sclOnlineLL As New StatusIGCGButton(Me.Header)
            Dim stbTotal As New StatusTextBox(txtTotal)
            Dim stbLotID As New StatusTextBox(txtLotID)
            Dim stbSeqID As New StatusTextBox(txtSeqID)
            Dim stbCompleteCycleWafer As New StatusTextBox(txtCompletedCycleWaferAt)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stgGraph)
            m_stoStatusObject.AddChild(slbPresure)
            m_stoStatusObject.AddChild(btnStart)
            m_stoStatusObject.AddChild(btnLoad)
            m_stoStatusObject.AddChild(btnUnload)
            m_stoStatusObject.AddChild(btnAbort)
            m_stoStatusObject.AddChild(sclOnlineLL)
            m_stoStatusObject.AddChild(stbTotal)
            m_stoStatusObject.AddChild(stbLotID)
            m_stoStatusObject.AddChild(stbSeqID)
            m_stoStatusObject.AddChild(stbCompleteCycleWafer)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>    
    ''' <summary>
    ''' Aligning all child controls inside this user control to left side
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AlignLeft()
        Try
            Me.lblLotID.Left = 7
            Me.lblSeqID.Left = lblLotID.Left
            Me.btnStart.Left = lblLotID.Left
            Me.btnAbort.Left = lblLotID.Left
            Me.btnLoad.Left = btnAbort.Left + btnAbort.Width + 6
            Me.btnUnload.Left = btnLoad.Left
            Me.txtSeqID.Left = btnLoad.Left + btnLoad.Width - txtSeqID.Width
            Me.txtLotID.Left = txtSeqID.Left

            Me.lblFinishProcess.Dock = DockStyle.Left
            Me.lblFinishProcess.Padding = New Padding(6, 0, 0, 1)

            Me.lblPressure.Dock = DockStyle.Right
            Me.lblPressure.Padding = New Padding(0, 0, 6, 1)
            Me.lblPressure.TextAlign = ContentAlignment.MiddleRight

            Me.psgPressureGraph.Left = btnLoad.Left + btnLoad.Width + 4

            Me.txtTotal.Left = btnUnload.Left
            Me.lblWaferCount.Left = txtTotal.Left - lblWaferCount.Width - 4

            Me.Width = psgPressureGraph.Left + psgPressureGraph.Width + 7

            Me.lblFinishLoadUnload.Left = btnLoad.Left + btnLoad.Width / 2 - lblFinishLoadUnload.Width / 2
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>    
    ''' <summary>
    ''' Aligning all child controls inside this user control to right side
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AlignRight()
        Try
            Me.psgPressureGraph.Location = New System.Drawing.Point(9, 52)

            Me.lblFinishLoadUnload.Dock = DockStyle.Left
            Me.lblPressure.Dock = DockStyle.Left

            lblPressure.SendToBack()
           
            Me.btnStart.Left = Me.psgPressureGraph.Left + Me.psgPressureGraph.Width + 10
            Me.btnAbort.Left = btnStart.Left
            Me.btnLoad.Left = btnAbort.Left + btnAbort.Width + 10
            Me.btnUnload.Left = btnLoad.Left
            Me.lblFinishProcess.Left = Me.btnAbort.Left + 20

            Me.lblLotID.Left = btnLoad.Left + btnLoad.Width - lblLotID.Width
            Me.txtLotID.Left = Me.lblLotID.Left - Me.txtLotID.Width

            Me.txtSeqID.Left = txtLotID.Left
            Me.lblSeqID.Left = lblLotID.Left

            Me.lblWaferCount.Left = btnStart.Left
            Me.txtTotal.Left = btnLoad.Left
            Me.lblFinishLoadUnload.Left = Me.lblFinishProcess.Width + (Me.lblPressure.Left - Me.lblFinishProcess.Width - Me.lblFinishLoadUnload.Width) / 2
            If Me.lblFinishLoadUnload.Left + Me.lblFinishLoadUnload.Width > Me.lblPressure.Left Then
                Me.lblFinishLoadUnload.Left = Me.lblPressure.Left - Me.lblFinishLoadUnload.Width
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Function DetectPressureErrorWhenStartJob(ByVal LoadlockName As String, Optional ByRef strErrorMsg As String = "") As Boolean
        Dim blResult As Boolean = False

        Dim objTMController As AVPLib.Business.TMController = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.CassettesModule.ToString)
        If (objTMController IsNot Nothing) Then
            If (objTMController.CheckPressureCommunication(strErrorMsg)) Then
                Dim objLoadlockController As AVPLib.Business.LoadLockController = AVPLib.Business.ControllerManager.GetController(LoadlockName)
                If (objLoadlockController IsNot Nothing) Then
                    If (objLoadlockController.CheckPressureCommunication(strErrorMsg)) Then
                        blResult = True
                    End If
                End If
            End If
        End If
        Return blResult
    End Function
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on start button
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Start_Click(Optional ByVal blnShowPopUp As Boolean = False, Optional ByRef eRemoteResut As AVPLib.ConstEnum.CustomRemoteCommandResult = Nothing)
        Try
            Dim title As String = "AVP"
            If Not My.Application.Info.Copyright.Contains("AVP") Then
                title = "CTC"
            End If

            If AVPLib.AVPDataLib.Verify() <> 0 OrElse Not AVPLib.AVPDataLib.IsSecureDllLoaded() Then
                If blnShowPopUp Then
                    Utils.ShowAVPMessageBox("Your License Is Expired", title, MessageBoxIcon.Error, MessageBoxButtons.OK)
                Else
                    eRemoteResut = EMSERVICELib.CommandResults.cmdCannotPerform
                End If

                Return False
            End If

            Dim avpMsgBox As AVPMessageBox = Nothing
            Dim strLLName As String = ConstantAndEnum.LOAD_LOCK_A
            ''Update Gem Obj
            AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.SETUP, strLLName)
            If Not checkOnline(blnShowPopUp) Then 'check LL and TM Online
                AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                eRemoteResut = CustomRemoteCommandResult.LL_TM_IS_NOT_ONLINE
                Return False
            End If
            Dim map As Hashtable = Nothing
            Dim strMessage As String = String.Empty
            Dim strErrMsg As String = String.Empty

            If String.IsNullOrEmpty(LotID) Then
                strErrMsg = String.Format(AVPLib.ContainerData.GetMessageText("LOTID_LL_ERR"), GetEquipment())
                If blnShowPopUp Then
                    Utils.ShowAVPMessageBox(strErrMsg, WAFER_PROCESSING, MessageBoxIcon.Error, MessageBoxButtons.OK)
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                  "[Main Screen] " + "Start recipe process error with LotID.")
                AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                eRemoteResut = CustomRemoteCommandResult.LOTID_IS_EMPTY
                Return False
            ElseIf String.IsNullOrEmpty(SeqID) Then
                strErrMsg = String.Format(AVPLib.ContainerData.GetMessageText("SEQID_LL_ERR"), GetEquipment())
                If blnShowPopUp Then
                    Utils.ShowAVPMessageBox(strErrMsg, WAFER_PROCESSING, MessageBoxIcon.Error, MessageBoxButtons.OK)
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 "[Main Screen] " + "Start recipe process error with SequenceID.")
                AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                eRemoteResut = CustomRemoteCommandResult.SEQUENCE_IS_NOT_EXISTED
                Return False
            End If

            'check invalid sequence
            Dim eSeqRemoteResult As AVPLib.ConstEnum.CustomRemoteCommandResult = Nothing
            If AVPLib.SequenceLib.CheckInvalidSequence(SeqID, strLLName, eSeqRemoteResult) = False Then
                If blnShowPopUp Then
                    Utils.ShowAVPMessageBox("Sequence " & SeqID & " Is Invalid. Related Recipe Does Not Exist.", WAFER_PROCESSING, MessageBoxIcon.Error, MessageBoxButtons.OK)
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 "[Main Screen] " + "Start recipe process error becauseof corrupted file sequence")
                AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                eRemoteResut = eSeqRemoteResult
                Return False
            End If

            m_ChamberStations = AVPLib.SequenceLib.GetChamberStations(SeqID) ' Get list chambers

            'Check file Sequence is corrupted            
            If m_ChamberStations Is Nothing OrElse m_ChamberStations.Count = 0 Then
                If blnShowPopUp Then
                    Utils.ShowAVPMessageBox("Sequence " & SeqID & " Is Invalid. Related WaferFlow Does Not Exist.", WAFER_PROCESSING, MessageBoxIcon.Error, MessageBoxButtons.OK)
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 "[Main Screen] " + "Start recipe process error because of corrupted file Sequence.")
                AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                eRemoteResut = CustomRemoteCommandResult.SEQUENCE_FILE_IS_CORRUPTED
                Return False
            End If
            'Checking: if Aligner is not installed,sequence is invalid if have aligner station
            If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE And m_ChamberStations.Contains("Aligner") Then
                If blnShowPopUp Then
                    Utils.ShowAVPMessageBox("The Sequence File """ & SeqID & """ Is Invalid, There Is Aligner in Sequence while Aligner is not installed.", WAFER_PROCESSING, MessageBoxIcon.Error, MessageBoxButtons.OK)
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 "[Main Screen] " + "Start recipe process error because of corrupted  Sequence file .")
                AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                Return False
            End If

            'Check online and Wafer Orphan
            Dim ListChamberNotOnline As List(Of String) = Utils.CheckChamberStationsNotExistAndNotOnline(m_ChamberStations, m_isCycleInATMMode)
            Dim ListChamberExitWafer As List(Of String) = Utils.CheckChamberStationsExistWafer(m_ChamberStations)

            'DAT CAO MODIFY HERE, APPLY FOR ANYIBE(CX5 SCHEDULER STYPE)
            'Check m_ChamberStations
            'if exist ANYCHAMBER
            'system must exist at least a IBE = ONLINE + not have wafer on it
            If (ListChamberNotOnline.Contains(AVPLib.ConstEnum.Equipments.IBE.ToString())) Then
                ListChamberNotOnline.Remove(AVPLib.ConstEnum.Equipments.IBE.ToString())
                If Not Utils.CheckAnyIBEOnline() Then

                    For Each Item As String In Utils.GetListIBENotOnline
                        If (Not ListChamberNotOnline.Contains(Item)) Then
                            ListChamberNotOnline.Add(Item)
                        End If
                    Next

                End If
            End If

            If (ListChamberExitWafer.Count > 0) Then
                For Each message As String In ListChamberExitWafer
                    Dim strtmp As String = AVPLib.Utils.chamberID2ChamberName(message)
                    strMessage += strtmp + " - "
                Next
                If blnShowPopUp Then
                    strMessage = strMessage.Substring(0, strMessage.LastIndexOf("-") - 1)
                    Utils.ShowAVPMessageBox("There are unscheduled wafers in " & strMessage, WAFER_PROCESSING, MessageBoxIcon.Error, MessageBoxButtons.OK)
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 "[Main Screen] " + "Start recipe process error becauseof having orphan wafer.")
                AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                eRemoteResut = CustomRemoteCommandResult.HAS_WAFER_IN_PM
                Return False
            ElseIf (ListChamberNotOnline.Count > 0) Then

                If blnShowPopUp Then

                    For Each message As String In ListChamberNotOnline
                        Dim strtmp As String = AVPLib.Utils.chamberID2ChamberName(message)
                        strMessage += strtmp + " "
                    Next

                    If ListChamberNotOnline.Count = 1 Then
                        Utils.ShowAVPMessageBox(strMessage + "is not online or invalid job file.",
                                                WAFER_PROCESSING, MessageBoxIcon.Error, MessageBoxButtons.OK)
                    Else
                        Utils.ShowAVPMessageBox(strMessage + "are not online or invalid job file.",
                                                WAFER_PROCESSING, MessageBoxIcon.Error, MessageBoxButtons.OK)
                    End If
                End If

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                AVPLib.ContainerData.LogSource.AVPMainScreen,
                                "[Main Screen] " + "Start recipe process error becauseof " & strMessage & "is not online or invalid job file.")
                AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                eRemoteResut = CustomRemoteCommandResult.PM_IS_NOT_ONLINE
                Return False
            End If
            'Check Scheduler Condition
            Dim LLName As String = AVPLib.ConstEnum.Equipments.LoadLockA.ToString() 'default LLA
            'if the system configure only one LLB then above code is totally wrong. DOn't know why you do this
            LLName = strLLName

            ' 0004787: [KhoiHa 03/22/2014]If user run a scheduler with recipe only using T2/T3/T4. 
            ' With picture below, user should be allow to run since this schedule is not using T1.
            ' Get sequence information
            Dim hstRecipeTargetSelectionInformation As Hashtable = Utils.GetAllTargetXBaseOnSequenceFiles(SeqID)

            If Not m_isCycleInATMMode And Not AVPLib.RobotConfigurationValues.DEBUGMODE Then

                'if any chamber reached Alarm KWH -> Stop scheduler
                Dim strListOfPM_ReachedLmt As String = Utils.CheckStartScheduler_ReachFaultLimit(m_ChamberStations, hstRecipeTargetSelectionInformation)
                If Not (String.IsNullOrEmpty(strListOfPM_ReachedLmt)) Then
                    If blnShowPopUp Then
                        Utils.ShowAVPMessageBox(strListOfPM_ReachedLmt & ": Current Source Usage/KWH reached Alarm limit value ." & Chr(13) &
                                                "Scheduler can not run.", "Scheduler Failed", MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                             AVPLib.ContainerData.LogSource.AVPMainScreen,
                                             "[Main Screen] " + "Some Current Source Usage/KWH of some chambers reached Alarm limit value, Scheduler had stopped")
                    AVPLib.Log.avpLogger.Debug("Some Current Source Usage/KWH of some chambers reached Alarm limit value, Scheduler had stopped")
                    AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                    eRemoteResut = CustomRemoteCommandResult.SOURCE_USAGE_KWH_REACH_LIMIT
                    Return False
                End If

                strListOfPM_ReachedLmt = Utils.CheckStartScheduler_ReachWarningLimit(m_ChamberStations, hstRecipeTargetSelectionInformation)
                'list of chamber reached Warning Limit KWH
                If Not String.IsNullOrEmpty(strListOfPM_ReachedLmt) Then
                    'if user cancel start scheduler -> Stop Scheduler
                    If blnShowPopUp Then
                        If Utils.ShowAVPMessageBox(strListOfPM_ReachedLmt & ": Current Source Usage/KWH reached Warning limit value." & Chr(13) &
                                                   "Do you want to continue to START Scheduler?", "Scheduler Warning",
                                                   MessageBoxIcon.Warning, MessageBoxButtons.YesNo) = DialogResult.Cancel Then

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                        AVPLib.ContainerData.LogSource.AVPMainScreen,
                        "[Main Screen] " + strListOfPM_ReachedLmt & ": Source Usage/KWH reached Warning limit value.")
                            AVPLib.Log.avpLogger.Debug("User cancel run Scheduler when current Source Usage/KWH reach Warning limit: chambers reach:" _
                                                        & strListOfPM_ReachedLmt)
                            AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                            eRemoteResut = CustomRemoteCommandResult.SOURCE_USAGE_KWH_REACH_WARNING_LIMIT
                            Return False
                        Else
                            ' logs for user confirmation to start scheduler when KWH warning is reach.  
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                            AVPLib.ContainerData.LogSource.AVPMainScreen,
                                            "[Main Screen] " + "User confirm to start scheduler when Source Usage/KWH Warning limit is reach at " & strListOfPM_ReachedLmt)
                            AVPLib.Log.avpLogger.Debug("User continue run Scheduler when current Source Usage/KWH reach Warning limit: chambers reach:" _
                                           & strListOfPM_ReachedLmt)
                        End If
                    End If
                    eRemoteResut = CustomRemoteCommandResult.SOURCE_USAGE_KWH_REACH_WARNING_LIMIT
                End If

                'if any chamber shields/quartz reached Alarm Limit-> Stop scheduler
                strListOfPM_ReachedLmt = Utils.CheckStartScheduler_ShieldsQuartz_ReachFaultLimit(m_ChamberStations, hstRecipeTargetSelectionInformation)
                If Not (String.IsNullOrEmpty(strListOfPM_ReachedLmt)) Then
                    If blnShowPopUp Then
                        Utils.ShowAVPMessageBox(strListOfPM_ReachedLmt & ": Current Shields/Quartz reached Alarm limit value ." & Chr(13) &
                                                "Scheduler can not run.", "Scheduler Failed", MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                             AVPLib.ContainerData.LogSource.AVPMainScreen,
                                             "[Main Screen] " + "Some Current Shields/Quartz of some chambers reached Alarm limit value, Scheduler had stopped")
                    AVPLib.Log.avpLogger.Debug("Some Current Shields/Quartz of some chambers reached Alarm limit value, Scheduler had stopped")
                    AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                    eRemoteResut = CustomRemoteCommandResult.SHIELDS_QUARTZ_REACH_LIMIT
                    Return False
                End If

                strListOfPM_ReachedLmt = Utils.CheckStartScheduler_ShieldsQuartz_ReachWarningLimit(m_ChamberStations, hstRecipeTargetSelectionInformation)
                'list of chamber shields/quartz reached Warning Limit
                If Not String.IsNullOrEmpty(strListOfPM_ReachedLmt) Then
                    'if user cancel start scheduler -> Stop Scheduler
                    If blnShowPopUp Then
                        If Utils.ShowAVPMessageBox(strListOfPM_ReachedLmt & ": Current Shields/Quartz reached Warning limit value." & Chr(13) &
                                                   "Do you want to continue to START Scheduler?", "Scheduler Warning",
                                                   MessageBoxIcon.Warning, MessageBoxButtons.YesNo) = DialogResult.Cancel Then

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                        AVPLib.ContainerData.LogSource.AVPMainScreen,
                        "[Main Screen] " + strListOfPM_ReachedLmt & ": Shields/Quartz reached Warning limit value.")
                            AVPLib.Log.avpLogger.Debug("User cancel run Scheduler when current Shields/Quartz reach Warning limit: chambers reach:" _
                                                        & strListOfPM_ReachedLmt)
                            AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                            eRemoteResut = CustomRemoteCommandResult.SHIELDS_QUARTZ_REACH_WARNING_LIMIT
                            Return False
                        Else
                            ' logs for user confirmation to start scheduler when KWH warning is reach.  
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                            AVPLib.ContainerData.LogSource.AVPMainScreen,
                                            "[Main Screen] " + "User confirm to start scheduler when Shields/Quartz Warning limit is reach at " & strListOfPM_ReachedLmt)
                            AVPLib.Log.avpLogger.Debug("User continue run Scheduler when current Shields/Quartz reach Warning limit: chambers reach:" _
                                           & strListOfPM_ReachedLmt)
                        End If
                    Else
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                "[Main Screen] " + strListOfPM_ReachedLmt & ": Shields/Quartz reached Warning limit value.")
                    End If
                    eRemoteResut = CustomRemoteCommandResult.SHIELDS_QUARTZ_REACH_WARNING_LIMIT
                End If

                Dim strErrorMsg As String = String.Empty
                If Not (DetectPressureErrorWhenStartJob(LLName, strErrorMsg)) Then
                    Utils.ShowAVPMessageBox(strErrorMsg & " Scheduler can not run.", MessageBoxIcon.Error, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                            AVPLib.ContainerData.LogSource.AVPMainScreen,
                                            "[Main Screen] " + strErrorMsg & ", Scheduler Stop")
                    AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                    Return False
                End If

                'if user agree to start scheduler or no chamber reached Warning Limit KWH
                'continue check LL Hivac Open and IG On
                'If AlignStyle = DisplayStyle.Right Then '-> LLB
                '    'if LL Hivac is Closed
                '    LLName = AVPLib.ConstEnum.Equipments.LoadLockB.ToString()
                'End If
                ''check if LL Hivac is Open

                If blnShowPopUp Then
                    If Not Utils.CheckLLHivac_Open(LLName) Then
                        Utils.ShowAVPMessageBox(LLA_STR & " Hivac Valve was not Open." & Chr(13) & "Scheduler can not run.",
                                               "Scheduler Stop", MessageBoxIcon.Error, MessageBoxButtons.OK)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                "[Main Screen] " + LLName & " Hivac was not Open, Scheduler Stop")
                        AVPLib.Log.avpLogger.Debug(LLName & " Hivac was not Open, Scheduler Stop")
                        AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                        Return False
                    End If
                    'check if LL IG is On
                    If Not Utils.CheckLLIG_On(LLName) Then
                        Utils.ShowAVPMessageBox(LLA_STR & " IG was not On." & Chr(13) & " Scheduler can not run.",
                                                 "Scheduler Stop", MessageBoxIcon.Error, MessageBoxButtons.OK)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                "[Main Screen] " + LLName & " IG was not On, Scheduler Stop")
                        AVPLib.Log.avpLogger.Debug(LLName & " IG was not On, Scheduler Stop")
                        AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
                        Return False
                    End If
                End If
            End If

            If Not CheckWaferIsValid(SeqID, strLLName) Then
                Return False
            End If

            ' Sequence Start Log
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                               AVPLib.ContainerData.LogSource.AVPMainScreen,
                                               "Start sequence " & SeqID & " on " & LLName)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                               AVPLib.ContainerData.LogSource.AVPMainScreen,
                                               "Start time  = " & DateTime.Now.ToString())

            'Ready to start
            Me.EnableFormAbortStart(False)
            'Lock Diagnostic Screen Relevant
            Utils.Lock_UnLockDiagnosticScreen(m_ChamberStations, LLName, True)
            btnStart.Text = "Starting"
            btnStart.Enabled = False
            Dim e As New EventArgs()
            RaiseEvent StartAutoProcess(Me, e)
            m_blnStopSequenceByClickStop = False
            SendMailWhenSchedulerStatusChange(STR_RUNNING)
            lblFinishProcess.Text = SCHEDULER & RUNNING
            ''Update Gem Obj
            AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.READY, strLLName)
            ''''''''''''
            Dim strValue As String = LotID + "," + SeqID
            'update SequenceID and LotID for GEM
            Dim objLoadLock As AVPLib.DataManagerment.LoadLock = EquipmentManager.GetEquipment(strLLName)
            objLoadLock.LotID = LotID
            objLoadLock.SequenceID = SeqID

            If AVPLib.RobotConfigurationValues.RUN_SCHEDULER_NO = AVPLib.ConstEnum.NUM_9999 Then
                AVPLib.RobotConfigurationValues.RUN_SCHEDULER_NO = AVPLib.ConstEnum.NUM_1000
            Else
                AVPLib.RobotConfigurationValues.RUN_SCHEDULER_NO = AVPLib.RobotConfigurationValues.RUN_SCHEDULER_NO + 1
            End If

            m_stoStatusObject.RequestStatus(btnStart.Name, strValue)
            ContainerForm.ProcessPanel.runNoControl.txtRunNo.Text = AVPLib.RobotConfigurationValues.RUN_SCHEDULER_NO
            AVPLib.ContainerDAO.SaveRunNo(AVPLib.RobotConfigurationValues.RUN_SCHEDULER_NO)

            testScheduler = testScheduler + 1
            AVPLib.Log.avpLogger.Error("Start Scheduler:------------> " & testScheduler.ToString() & " times")
            Me.m_ProcessStatus = ProcessStatuses.RUNNING
            ''disable sensor checking
            If AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False Or (AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED And ContainerForm.CassettesPanel.atwAutoTransferWafer.chkDisableChekingSensor.Enabled) Then
                AVPLib.RobotConfigurationValues.DISABLE_SENSOR_CHECKING = False
                ContainerForm.CassettesPanel.atwAutoTransferWafer.chkDisableChekingSensor.Checked = False
                ContainerForm.CassettesPanel.atwAutoTransferWafer.SendCMD2Robot()
                ContainerForm.CassettesPanel.atwAutoTransferWafer.chkDisableChekingSensor.Enabled = False
            End If

            'ContainerForm.SystemSetup.cbAutoVentWhenProcessCompleted.Enabled = False

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return True
    End Function

    Private Function CheckWaferIsValid(ByVal strSequenceID As String, ByVal strLoadLockName As String) As Boolean
        Try
            Dim objLoadLock As LoadLock = CType(EquipmentManager.GetEquipment(strLoadLockName), LoadLock)
            Dim arrSlotsStatus As Integer() = objLoadLock.Elevator.SlotStatus
            Dim wfSequence As AVPLib.DBWaferList = Nothing
            Dim strSequenceDescription As String = Nothing
            Dim CJBatchProcessing As Boolean = False
            Dim lstProcessJob As List(Of AVPProcessJob) = New List(Of AVPProcessJob)

            If (Not String.IsNullOrEmpty(strSequenceID)) Then
                If Not AVPLib.ContainerData.GetSequence(AVPLib.ContainerDAO.FPath_SequenceData & "\" & AVPLib.Utils.GetFileName(strSequenceID, "xml"),
                        wfSequence, strSequenceDescription) Then
                    AVPLib.Log.avpLogger.Error("Failed to load Ctrl Job - " & AVPLib.ContainerDAO.FPath_SequenceData & "\" & AVPLib.Utils.GetFileName(strSequenceID, "xml"))
                    Return False
                End If
            End If

            Dim objLLElevator As LLElevator = EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())

            For Each SequenceSlot As AVPLib.DBWaferSlot In wfSequence.WaferList
                If (SequenceSlot.WaferSequence.SeqStepList.Count > 0) Then
                    Dim iSlotNo As Integer = CInt(SequenceSlot.Slot)
                    If iSlotNo <= arrSlotsStatus.Length Then
                        ' Generate wafer information
                        Dim waferinfo As AVPLib.AVPWaferInfo = objLLElevator.ListOfWaferInfo(iSlotNo - 1)
                        If (waferinfo IsNot Nothing) Then
                            If (waferinfo.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNew) Then
                                Dim sqiSequence As New AVPLib.SequenceInfor(waferinfo)
                                sqiSequence.LoadLockName = strLoadLockName
                                Dim waferflow As New ArrayList

                                '' Translate from sequence step list (1,2,3,4 ...) to sequence step (DBSeqStep)
                                For Each strSeqNo As String In SequenceSlot.WaferSequence.StepList
                                    Dim seqStep As AVPLib.DBSeqStep = Nothing
                                    seqStep = SequenceSlot.WaferSequence.SeqNo(strSeqNo)
                                    If seqStep IsNot Nothing Then
                                        waferflow.Add(seqStep)
                                    End If
                                Next
                                sqiSequence.WaferFlow = waferflow

                                ' Create the process Job
                                Dim avpPJ As AVPProcessJob = New AVPProcessJob(sqiSequence, SequenceSlot.WaferSequence.SeqName)
                                avpPJ.ListRoute = BuildListRoute(avpPJ)
                                If sqiSequence IsNot Nothing AndAlso sqiSequence.ChamberNames IsNot Nothing Then
                                    For Each chamberName As String In sqiSequence.ChamberNames
                                        Dim chamberConfig As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(chamberName)
                                        If chamberConfig IsNot Nothing AndAlso chamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD4 Then
                                            CJBatchProcessing = True
                                            Exit For
                                        End If
                                    Next
                                End If
                                lstProcessJob.Add(avpPJ)
                            ElseIf waferinfo.WaferStatus = enumWaferStatus.eWaferError Then
                                ShowMessageBoxStopScheduler("Scheduler Can Not Start Due To Wafer Status Is Invalid", strLoadLockName)
                                Return False
                            ElseIf waferinfo.WaferStatus = enumWaferStatus.eWaferComplete Then
                                ShowMessageBoxStopScheduler("Scheduler Can Not Start Due To Wafer Status Is Invalid", strLoadLockName)
                                Return False
                            End If
                        End If
                    Else
                        ShowMessageBoxStopScheduler("Scheduler Can Not Start Due To Sequence Invalid", strLoadLockName)
                        Return False
                    End If
                End If
            Next

            If (CJBatchProcessing) Then
                AVPLib.AVPJob.BuildBatchProcessJob(lstProcessJob)
                If (RemoveAllJobNotFullPatch(lstProcessJob) = False) Then
                    ShowMessageBoxStopScheduler("Sequence is invalid or not enough wafer for start", strLoadLockName)
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return False
    End Function

    Private Function BuildListRoute(ByVal avpPJ As AVPProcessJob) As List(Of AVPLib.DBSeqStep)
        Dim lstRoute As New List(Of AVPLib.DBSeqStep)
        Dim stepobj As New AVPLib.DBSeqStep(avpPJ.SequenceInfor.LoadLockName + ",Slot" + avpPJ.SequenceInfor.WaferInfo.SlotID.ToString(), 0)
        lstRoute.Add(stepobj)

        For Each SequenceStep As AVPLib.DBSeqStep In avpPJ.SequenceInfor.WaferFlow
            lstRoute.Add(SequenceStep)
        Next

        lstRoute.Add(stepobj)

        Return lstRoute
    End Function

    Private Function RemoveAllJobNotFullPatch(ByVal lstProcessJob) As Boolean
        Dim jobList As List(Of AVPProcessJob) = New List(Of AVPProcessJob)
        Dim IsRemove As Boolean = False
        'clone temp job list
        For Each job As AVPProcessJob In lstProcessJob
            jobList.Add(job)
        Next

        'remove all job not full patch
        For Each PJob As AVPProcessJob In jobList
            If (PJob.WaferCapacity > PJob.BatchProcessCount) Then
                lstProcessJob.Remove(PJob)
                IsRemove = True
            End If
        Next

        If (IsRemove AndAlso lstProcessJob.Count = 0) Then
            Return False
        End If

        Return True
    End Function

    Private Sub ShowMessageBoxStopScheduler(ByVal message As String, ByVal strLLName As String)
        Utils.ShowAVPMessageBox(message, "Scheduler Stop", MessageBoxIcon.Error, MessageBoxButtons.OK)
        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Main Screen] " + strLLName & " " & message)
        AVPLib.Log.avpLogger.Debug(strLLName & " " & message)
        AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, strLLName)
    End Sub

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2013-08-28</date>
    ''' </author>
    ''' <summary>
    ''' Run with cycle until mode
    ''' wich chamber are multi wafer processing
    ''' must check enough wafer for chamber
    ''' </summary>
    ''' <remarks></remarks>
    Private Function IsEnoughWaferInCycleUntilMode(ByVal strLLName As String, ByRef sErrorMsg As String) As Boolean
        Dim blResult As Boolean = False
        Try

            Dim objLoadLock As AVPLib.DataManagerment.LoadLock = Nothing
            objLoadLock = EquipmentManager.GetEquipment(strLLName)

            If (objLoadLock IsNot Nothing AndAlso
                objLoadLock.MaxCycleCount > 0 AndAlso
                m_ChamberStations.Count > 0) Then
                For Each Item As String In m_ChamberStations
                    Dim objStation As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Item)
                    If (objStation IsNot Nothing AndAlso objStation.WaferCapacity > objLoadLock.MaxCycleCount) Then
                        sErrorMsg = "Cycle Until Number must be equal or greater than " & objStation.WaferCapacity
                        'return false
                        Exit Try
                    Else
                        AVPLib.Log.avpLogger.Error("Check enough wafer in cycle until mode " & objStation.Name & " :OK, Wafer Capacity=" & objStation.WaferCapacity.ToString)
                    End If
                Next
            ElseIf (objLoadLock Is Nothing) Then
                AVPLib.Log.avpLogger.Error("object loadlock is nothing")
            ElseIf (objLoadLock.MaxCycleCount <= 0) Then
                AVPLib.Log.avpLogger.Error("Max Cycle Count = 0")
            ElseIf (m_ChamberStations.Count <= 0) Then
                AVPLib.Log.avpLogger.Error("Station List is empty")
            End If

            'Pass anything return true
            blResult = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blResult
    End Function

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on pause button
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Pause_Click()
        Try
            Me.EnableFormAbortStart(False)
            Dim e As New EventArgs()
            'RaiseEvent PauseAutoProcess(Me, e)
            btnStart.Text = REZUME
            m_stoStatusObject.RequestStatus(btnStart.Name, "Click Pause")
            Me.m_ProcessStatus = ProcessStatuses.PAUSE
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub Stop_Click()
        Try
            Me.EnableFormAbortStart(False)
            Dim e As New EventArgs()
            RaiseEvent StopAutoProcess(Me, e)
            m_blnStopSequenceByClickStop = True
            SendMailWhenSchedulerStatusChange(STR_STOP)
            lblFinishProcess.Text = SCHEDULER & STOPPING
            btnStart.Text = "Stopping"
            btnStart.Enabled = False
            m_stoStatusObject.RequestStatus(btnStart.Name, "Click Stop")
            Me.m_ProcessStatus = ProcessStatuses.STOP
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Dat Vo fix: Trigger Stop Event
            ' Is there a Load lock level event for STOP command? 
            ' I see the events from the manual for processing started, aborted, paused, 
            ' resumed but not for processing stopped. Please let me know.
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim strTargetLoadLock As String = ConstantAndEnum.LOAD_LOCK_A
            AVPLib.Business.AVPSecsGemLib.TriggerEvent(strTargetLoadLock, "ProcessingStopped")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' End Fix
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Turn Off Cycle Mode.
            TurnOffCycleMode()

            ' Sequence Start Log
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                               AVPLib.ContainerData.LogSource.AVPMainScreen,
                                               "Stop sequence " & SeqID)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                               AVPLib.ContainerData.LogSource.AVPMainScreen,
                                               "Stop time  = " & DateTime.Now.ToString())

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on resume button
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Resume_Click()
        Try
            If Not checkOnline() Then
                Return
            End If

            Me.EnableFormAbortStart(False)
            Dim e As New EventArgs()
            RaiseEvent ResumeAutoProcess(Me, e)

            btnStart.Text = PAUSE
            m_stoStatusObject.RequestStatus(btnStart.Name, "Click Resume")
            Me.m_ProcessStatus = ProcessStatuses.RUNNING
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name>Tran Ngoc Khiet </name>
    '''    	<date> 2009-08-18</date>
    ''' </author>
    ''' <summary>
    ''' Get equipment that is recently choosed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Function GetEquipment() As String
        If Me.Name = LOADLOCKA Then
            Return ONLINELOADLOCKA
        End If
        Return String.Empty
    End Function
#End Region

#Region "Events � Buttons � Forms�"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Handle Click event on Start Button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        AVPLib.Log.guiLogger.Info("Enter btnStart_Click")
        Dim strMessageText As String = String.Empty
        Dim avpMsgBox As AVPMessageBox = Nothing
        '#05/06/2011 
        '#This error appea when running recipe with long files name.  The current selection is �TT_AVP��.�
        '#Begin fix:
        '  SeqID = txtSeqID.Text.Trim
        '#End fix
        Try
            Select Case btnStart.Text
                Case START
                    'Dim isLLA_Cycle_ATM As Boolean = False
                    'Dim isLLB_Cycle_ATM As Boolean = False
                    If String.IsNullOrEmpty(txtSeqID.Text.Trim) OrElse String.IsNullOrEmpty(txtLotID.Text.Trim) Then
                        Utils.ShowAVPMessageBox("Please input your Sequence and Lot ID before start", "Start Scheduler", MessageBoxIcon.Stop, MessageBoxButtons.OK)
                        Exit Sub
                    End If
                    Dim isCycle As Boolean = False

                    'This variable is used to check condition in LockProcessControl
                    m_isCycleInATMMode = False

                    'This variable is used to check the condition in lower layer (CJ and PJ)
                    Dim objLoadLock As AVPLib.DataManagerment.LoadLock = Nothing
                    Dim strLLName As String = String.Empty

                    If Me.Name = LOADLOCKA Then
                        isCycle = IIf(ContainerForm.CassettesPanel.ctwcCycleWafer.chkInCycleModeA.Checked, True, False)
                        objLoadLock = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                        strLLName = AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
                    End If

                    m_ChamberStations = AVPLib.SequenceLib.GetChamberStations(SeqID) ' Get list chambers

                    Dim strErrorMsg As String = String.Empty
                    'Check wafer on cycle until mode
                    If Not (IsEnoughWaferInCycleUntilMode(strLLName, strErrorMsg)) Then
                        Utils.ShowAVPMessageBox(strErrorMsg, WAFER_PROCESSING, MessageBoxIcon.Error, MessageBoxButtons.OK)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                         AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                         "[Main Screen] " + strErrorMsg)
                        Exit Sub
                    End If

                    objLoadLock.IsCycleInATM_Mode = False

                    If AVPLib.ContainerDAO.EnableReworkFeature() Then
                        Dim modeDialog As New AVPControls.AVPMessageBox("Start Scheduler", "Please select mode to start!", MessageBoxIcon.Question, AVPControls.AVPMessageBox.AVPMessageBoxButton.ProductionRework)
                        Dim modeResult As DialogResult = modeDialog.ShowDialog()
                        If modeResult = DialogResult.No Then
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                               AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                               "[Main Screen] User selected Rework for starting sequence: " & SeqID)
                            Dim reworkDialog As ReworkSequenceEditor = New ReworkSequenceEditor()
                            reworkDialog.OldSequenceName = SeqID
                            If reworkDialog.ShowDialog() = DialogResult.Cancel Then
                                reworkDialog.Dispose()

                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                                   AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                                   "[Main Screen] User cancelled rework of sequence: " & SeqID)
                                Exit Try
                            End If

                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                               AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                               "[Main Screen] User starting rework sequence: " & reworkDialog.NewSequenceName)

                            txtSeqID.Text = reworkDialog.NewSequenceName
                            txtSeqID_MeasureString()
                            reworkDialog.Dispose()
                        ElseIf modeResult = DialogResult.Cancel Then
                            modeDialog.Dispose()
                            Exit Try
                        Else
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                               AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                               "[Main Screen] User starting production sequence: " & SeqID)

                        End If
                        modeDialog.Dispose()
                    Else
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                                                       AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                                                       "[Main Screen] User starting sequence: " & SeqID)
                    End If

                    Dim waitdefine As Boolean = False
                    If AVPLib.RobotConfigurationValues.SUPPORT_MANUAL_DEFINE_GEM_WAFERID Then

                        Dim DefineGEMWaferIDDialog As New CreateGEMWaferIDPopUp(objLoadLock.Name, Me.NumSlot)
                        DefineGEMWaferIDDialog.ShowDialog()

                        If DefineGEMWaferIDDialog.DialogResult = DialogResult.OK Then
                            GoTo Start_Scheduler
                        End If
                    Else
                        GoTo Start_Scheduler
                    End If

                    Exit Select
Start_Scheduler:

                    strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("StartProcessPanel"), START, SeqID, LLA_STR)
                    avpMsgBox = New AVPMessageBox(LLA_STR, strMessageText, MessageBoxIcon.Question)
                    avpMsgBox.ShowDialog()
                    If (avpMsgBox.DialogResult = DialogResult.OK) Then
                        Start_Click(True)
                        '#04/26/2011 
                        '#When scheduler complete, LL state should be complete instead of IDLE.
                        '#Begin fix:
                        m_blnStopSequenceByClickAbort = False
                        '#End fix
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                                  AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                                  "[Main Screen] " + "Start scheduler")
                    End If
                Case [STOP]
                    strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("StartProcessPanel"), [STOP], SeqID, LLA_STR)
                    avpMsgBox = New AVPMessageBox(LLA_STR, strMessageText, MessageBoxIcon.Question)
                    avpMsgBox.ShowDialog()
                    If (avpMsgBox.DialogResult = DialogResult.OK) Then
                        Stop_Click()
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                                   AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                                   "[Main Screen] " + "Stop scheduler")
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnStart_Click")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Handle Click event on Load Button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        AVPLib.Log.guiLogger.Info("Enter btnLoad_Click")
        Dim strMessageText As String = String.Empty
        Dim avpMsgBox As AVPMessageBox = Nothing
        Try
            If btnLoad.Text = "ABORT" Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("AbortLoadProcessPanel"), LLA_STR)
                avpMsgBox = New AVPMessageBox(LLA_STR, strMessageText, MessageBoxIcon.Question)
                avpMsgBox.ShowDialog()
                If (avpMsgBox.DialogResult = DialogResult.OK AndAlso btnLoad.Text = "ABORT") Then
                    btnLoad.Text = "LOAD"
                    Dim ear As New EventArgs()
                    lblFinishLoadUnload.Text = IDLE
                    lblFinishLoadUnload.Visible = False
                    RaiseEvent StopLoadProcess(Me, ear)
                    btnStart.Enabled = False
                    btnAbort.Enabled = False
                    btnLoad.Enabled = False
                    btnUnload.Enabled = False
                    ContainerForm.ProcessPanel.EnableClearAllWaferButton(False)

                    m_stoStatusObject.RequestStatus(btnLoad.Name, "StopLoad")
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                                   AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                                   "[Main Screen] " + "Abort load scheduler.")
                End If
            ElseIf btnLoad.Text = "LOAD" Then
                If Me.Name = ConstantAndEnum.LOADLOCKA AndAlso Not (ContainerForm.ProcessPanel.LLALeg.CassettePresent) Then
                    If Utils.ShowAVPMessageBox("LLA : Cassette is not present." & Chr(13) & "Do you want to continue to Load?", "Warning",
                                  MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.YesNo) = DialogResult.Cancel Then
                        Exit Try
                    Else
                        StartLoadCassette()
                        Exit Try
                    End If

                End If
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("LoadProcessPanel"), LLA_STR)
                avpMsgBox = New AVPMessageBox(LLA_STR, strMessageText, MessageBoxIcon.Question)
                avpMsgBox.ShowDialog()
                If (avpMsgBox.DialogResult = DialogResult.OK) Then
                    StartLoadCassette()
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnLoad_Click")
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-03-26</date>
    ''' </author>
    ''' <summary>
    ''' convert from lockprocess name to loadlock name
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetLoadlockName() As String
        AVPLib.Log.guiLogger.Info("Leave btnLoad_Click")
        Dim strEquipmentName As String = String.Empty
        Try
            If (Me.Name = ConstantAndEnum.LOADLOCKA) Then
                strEquipmentName = AVPLib.ConstEnum.LoadLockA_STR
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnLoad_Click")
        Return strEquipmentName
    End Function
    Public Sub StartLoadCassette()
        Try

            If AVPLib.AVPDataLib.Verify() <> 0 OrElse Not AVPLib.AVPDataLib.IsSecureDllLoaded() Then
                Exit Sub
            End If

            btnLoad.Text = "ABORT"
            btnStart.Enabled = False
            btnAbort.Enabled = False
            btnLoad.Enabled = True
            btnUnload.Enabled = False
            ContainerForm.CassettesPanel.lccLoadLockA.IsAllowAction = False
            ContainerForm.ProcessPanel.EnableClearAllWaferButton(False)
            Dim ear As New EventArgs()
            lblFinishLoadUnload.Text = LOADING
            lblFinishLoadUnload.Visible = True
            RaiseEvent LoadProcess(Me, ear)
            m_stoStatusObject.RequestStatus(btnLoad.Name, "Click")
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                           AVPLib.ContainerData.LogSource.LoadLockA,
                                                           "[Main Screen] " + "Loading Loadlock.")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub StartUnLoadCassette()
        Try
            btnUnload.Text = "ABORT"
            btnStart.Enabled = False
            btnAbort.Enabled = False
            btnLoad.Enabled = False
            btnUnload.Enabled = True
            ContainerForm.CassettesPanel.lccLoadLockA.IsAllowAction = False
            ContainerForm.ProcessPanel.EnableClearAllWaferButton(False)
            Dim ear As New EventArgs()
            lblFinishLoadUnload.Text = UNLOADING
            lblFinishLoadUnload.Visible = True
            RaiseEvent UnLoadProcess(Me, ear)
            m_stoStatusObject.RequestStatus(btnUnload.Name, "Click")
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                          AVPLib.ContainerData.LogSource.LoadLockA,
                                                          "[Main Screen] " + "Unloading Loadlock.")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    '''  Handle Click event on Unload Button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnload.Click
        AVPLib.Log.guiLogger.Info("Enter btnUnload_Click")
        Dim strMessageText As String = String.Empty
        Dim avpMsgBox As AVPMessageBox = Nothing
        Try
            If btnUnload.Text = "ABORT" Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("AbortUnLoadProcessPanel"), LLA_STR)
                avpMsgBox = New AVPMessageBox(LLA_STR, strMessageText, MessageBoxIcon.Question)
                avpMsgBox.ShowDialog()
                If (avpMsgBox.DialogResult = DialogResult.OK AndAlso btnUnload.Text = "ABORT") Then
                    'after messagebox show -> button was still ABORT
                    btnUnload.Text = "UNLOAD"
                    Dim ear As New EventArgs()
                    RaiseEvent StopUnLoadProcess(Me, ear)
                    lblFinishLoadUnload.Text = IDLE
                    lblFinishLoadUnload.Visible = False
                    btnStart.Enabled = False
                    btnAbort.Enabled = False
                    btnLoad.Enabled = False
                    btnUnload.Enabled = False
                    ContainerForm.ProcessPanel.EnableClearAllWaferButton(False)
                    m_stoStatusObject.RequestStatus(btnUnload.Name, "StopUnLoad")
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.LoadLockA,
                                                                   "[Main Screen] " + "Abort unloading Loadlock")
                End If
            Else
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("UnLoadProcessPanel"), LLA_STR)
                avpMsgBox = New AVPMessageBox(LLA_STR, strMessageText, MessageBoxIcon.Question)
                avpMsgBox.ShowDialog()
                If (avpMsgBox.DialogResult = DialogResult.OK) Then
                    StartUnLoadCassette()
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnUnload_Click")
    End Sub

    Public Sub ResetProcessStatus()
        lblFinishProcess.Text = SCHEDULER & IDLE

        btnStart.Text = START
        btnStart.Enabled = True

        btnAbort.Text = "ABORT"
        btnAbort.Enabled = False

        btnLoad.Text = "LOAD"
        btnLoad.Enabled = True

        btnUnload.Text = "UNLOAD"
        btnUnload.Enabled = True
    End Sub

    Public Sub Abort_And_Return_Wafer_Click()
        Try
            Dim ear As New EventArgs()
            RaiseEvent AbortAutoProcess(Me, ear)
            m_blnStopSequenceByClickStop = False
            SendMailWhenSchedulerStatusChange(STR_ABORT_AND_RETURN)

            'lblFinishProcess.Text = STOPPING
            '"AVP->Process screen.  Add some indicator that return wafer is running, this would include �abort and return wafer�"
            'Begin
            lblFinishProcess.Text = SCHEDULER & ABORT_AND_RETURN_WAFER
            'End

            Me.btnAbort.Text = "Aborting"
            Me.btnAbort.Enabled = Not (AVPRobotMain.OnlineRemote)

            Me.EnableForm(False)

            Me.isClickAbort = True
            btnStart.Text = START

            m_stoStatusObject.RequestStatus(btnAbort.Name, "Click True")
            Me.isClickAbort = False
            Me.m_ProcessStatus = ProcessStatuses.ABORT

            ' Turn Off Cycle Mode.
            TurnOffCycleMode()
            '#04/26/2011 
            '#When scheduler complete, LL state should be complete instead of IDLE.
            '#Begin fix:
            m_blnStopSequenceByClickAbort = True
            '#End fix.
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
              "Abort Process - Abort and Return click  ")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    '''  Handle Click event on Abort Button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        AVPLib.Log.guiLogger.Info("Enter btnAbort_Click")
        Dim strMessageText As String = String.Empty
        Try
            If Me.btnAbort.Text = "Aborting" Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("AbortProcessPanel"), LLA_STR)
                If Utils.ShowAVPMessageBox(strMessageText, "Abort Return Wafers", _
                                           MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    Me.isClickAbort = True
                    btnStart.Text = START
                    m_stoStatusObject.RequestStatus(btnAbort.Name, "Click False")
                    Me.isClickAbort = False
                    Me.m_ProcessStatus = ProcessStatuses.ABORT
                    Me.btnAbort.Text = "Aborting"
                    Me.btnAbort.Enabled = False
                    '#04/26/2011 
                    '#When scheduler complete, LL state should be complete instead of IDLE.
                    '#Begin fix:
                    m_blnStopSequenceByClickAbort = True
                    '#End fix
                    m_blnStopSequenceByClickStop = False
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                   "[Main Screen] " + "Abort scheduler.")

                End If
            Else ''btnAbort.Text=ABORT
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("AbortProcessPanel"), LLA_STR)
                Dim result As Integer = Utils.ShowAVPAbortMessageBox(strMessageText, "Abort", MessageBoxIcon.Exclamation)
                If result = DialogResult.Ignore Then 'Abort and Return 
                    Abort_And_Return_Wafer_Click()
                ElseIf result = DialogResult.Abort Then 'Abort Only 
                    Dim ear As New EventArgs()
                    RaiseEvent AbortAutoProcess(Me, ear)
                    m_blnStopSequenceByClickStop = False
                    SendMailWhenSchedulerStatusChange(STR_ABORT)
                    lblFinishProcess.Text = SCHEDULER & STOPPING

                    Me.btnAbort.Text = "Aborting"
                    Me.btnAbort.Enabled = False

                    Me.EnableForm(False)
                    Me.isClickAbort = True
                    btnStart.Text = START

                    m_stoStatusObject.RequestStatus(btnAbort.Name, "Click False")

                    Me.isClickAbort = False
                    Me.m_ProcessStatus = ProcessStatuses.ABORT

                    ' Turn Off Cycle Mode.
                    TurnOffCycleMode()
                    '#04/26/2011 
                    '#When scheduler complete, LL state should be complete instead of IDLE.
                    '#Begin fix:
                    m_blnStopSequenceByClickAbort = True
                    '#End fix.
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                     "Abort Process - Abort Only click  ")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnAbort_Click")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event of SeqID text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtSeqID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSeqID.Click
        AVPLib.Log.guiLogger.Info("Enter txtSeqID_Click")
        Try
            ''AVP is Online Remote -> SEC/GEM mode -> don't do anything
            If AVPRobotMain.OnlineRemote Then
                Exit Try
            End If
            '''''
            txtSeqID.Tag = Boolean.TrueString
            Dim frm As New OpenSequence(False)
            frm.Title = "Open Job Sequence"
            frm.ShowDialog()
            Dim strSequenceID As String = ""
            If frm.DialogResult = DialogResult.OK Then
                strSequenceID = frm.FileName
                txtSeqID.Text = strSequenceID.Substring(0, strSequenceID.LastIndexOf("."))
                txtSeqID_MeasureString()
            End If
            frm.Dispose()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtSeqID_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-16</date>
    ''' </author>
    ''' <summary>
    ''' Handle text change
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnStart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.TextChanged
        Try
            If (Me.btnStart.Text = START) And (Not isClickAbort) Then
                Me.FinishProcess()
                ''''''''this code suport for Resuming
                'ElseIf (Me.btnStart.Text = REZUME) And (Not isClickAbort) Then 'Support Disable TransferModule
                '    Dim ee As New EventArgs()
                '    RaiseEvent PauseAutoProcess(Me, ee)
                '''''''''''''''''''''''''''''''''''''''
                'If Me.Name.IndexOf("LoadLockA") > -1 Then
                '    ContainerForm.TransferChamberPanel.cmsLeftTool.Enabled = True
                'ElseIf Me.Name.IndexOf("LoadLockB") > -1 Then
                '    ContainerForm.TransferChamberPanel.cmsRightTool.Enabled = True
                'End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Function"
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-08-27</date>
    ''' </author>
    ''' <summary>
    ''' DisableForm
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EnableDisableForm(ByVal enable As Boolean)
        Try
            If Not isCheckPermission Then
                enable = False
            End If

            Me.Header.Enabled = ContainerForm.ProcessPanel.TMCtl.lblHeader.Enabled
            Me.txtTotal.Enabled = enable
            Me.psgPressureGraph.Enabled = enable

            Me.btnStart.Enabled = enable AndAlso CheckCondition_Enable_StartButton()
            Me.btnAbort.Enabled = enable AndAlso CheckCondition_Enable_AbortButton()
            Me.btnLoad.Enabled = enable AndAlso CheckCondition_Enable_LoadButton()
            Me.btnUnload.Enabled = enable AndAlso CheckCondition_Enable_UnLoadButton()
            Me.txtLotID.Enabled = enable AndAlso CheckCondition_Enable_Seq_LotID()
            Me.txtSeqID.Enabled = enable AndAlso CheckCondition_Enable_Seq_LotID()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' EnableForm
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EnableForm(ByVal Enable As Boolean)
        Try
            If isCheckPermission Then
                Me.btnStart.Enabled = CheckCondition_Enable_StartButton()
                Me.btnLoad.Enabled = Enable AndAlso CheckCondition_Enable_LoadButton()

                If (Enable) Then
                    Me.btnAbort.Enabled = CheckCondition_Enable_AbortButton()
                Else
                    Me.btnAbort.Enabled = Not (Enable) And Not (AVPRobotMain.OnlineRemote)
                End If

                Me.btnUnload.Enabled = Enable AndAlso CheckCondition_Enable_UnLoadButton()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' EnableFormAbortStart
    ''' </summary>
    ''' <param name="Enable"></param>
    ''' <remarks></remarks>
    Private Sub EnableFormAbortStart(ByVal Enable As Boolean)
        Try
            Me.isClickAbort = False
            Me.btnLoad.Enabled = Enable
            Me.btnUnload.Enabled = Enable
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Check Online"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-01-10</date>
    ''' </author>
    ''' <summary>
    ''' Check Online
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function checkOnline(Optional ByVal blnShowPopUp As Boolean = False) As Boolean
        AVPLib.Log.guiLogger.Info("Enter checkOnline")
        Try
            If m_isCycleInATMMode Then
                Return True
            End If

            If Me.Name.IndexOf("lpcLoadLockA") > -1 Then
                If Not Utils.checkOnlineTM() Then
                    If blnShowPopUp Then
                        Utils.ShowAVPMessageBox("TM is not Online, Scheduler can not run", "Scheduler Failed", MessageBoxIcon.Error, MessageBoxButtons.OK)
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                   "[Main Screen] " + "TM is not Online, Scheduler can not run")
                    AVPLib.Log.guiLogger.Info("Leave checkOnline")
                    Return False
                End If
                If Not Utils.checkOnlineLLA() Then
                    If blnShowPopUp Then
                        Utils.ShowAVPMessageBox("LLA is not Online, Scheduler can not run", "Scheduler Failed", MessageBoxIcon.Error, MessageBoxButtons.OK)
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                   "[Main Screen] " + "LLA is not Online, Scheduler can not run")
                    AVPLib.Log.guiLogger.Info("Leave checkOnline")
                    Return False
                End If
            Else
            End If
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave checkOnline")
        Return False
    End Function
#End Region

    Public Sub Enable_Disable_StartButton()
        If Not isCheckPermission Then
            Return
        End If

        'ONLY UPDATE BUTTON START WHEN TEXT IS START
        'WHEN OPEN CLOSE VALVE IG HIVAC
        'BOTTON START IS ENABLE
        'BUT WHEN ON RETURN WAFER MANUAL -> NOT UPDATE
        If (btnStart.Text = "START") Then
            Dim objLoadLock As AVPLib.DataManagerment.LoadLock = Nothing

            Dim objJobmanager As AVPLib.Business.AVPJobManager = Nothing
            objJobmanager = AVPLib.Business.AVPCore.Instance().JobManager()

            If Me.Name = ConstantAndEnum.LOADLOCKA Then
                If (objJobmanager IsNot Nothing AndAlso _
            objJobmanager.isAllJobInLoadLockFinished(ConstantAndEnum.LOAD_LOCK_A.ToString())) Then
                    'continue
                Else
                    Exit Sub
                End If
                objLoadLock = EquipmentManager.GetEquipment(LoadLockA_STR)
            Else
                Exit Sub
            End If

            btnStart.Enabled = CheckCondition_Enable_StartButton()

        End If
    End Sub

    Public Sub ClearAllWaferStatus()
        btnStart.Enabled = CheckCondition_Enable_StartButton()
    End Sub

    Private Sub TurnOffCycleMode()
        If Me.Name = ConstantAndEnum.LOADLOCKA Then
            If (ContainerForm.CassettesPanel.ctwcCycleWafer.chkInCycleModeA.Checked) Then
                ContainerForm.CassettesPanel.ctwcCycleWafer.chkInCycleModeA.Checked = False
            ElseIf (ContainerForm.CassettesPanel.ctwcCycleWafer.cbLLAStopCycleAt.Checked) Then
                ContainerForm.CassettesPanel.ctwcCycleWafer.cbLLAStopCycleAt.Checked = False
            End If
        End If
    End Sub

    Private Sub txtLotID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLotID.TextChanged
        ValueToolTip.SetToolTip(txtLotID, txtLotID.Text)
        ' Enable/disable sequence textbox
        SetTextBoxState(txtSeqID, txtLotID.Text.Length > 0)
        btnStart.Enabled = CheckCondition_Enable_StartButton()
    End Sub

    Private Sub txtSeqID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSeqID.TextChanged
        btnStart.Enabled = CheckCondition_Enable_StartButton()
    End Sub

    Public Function CheckCondition_Enable_StartButton() As Boolean
        Try
            If Not isCheckPermission Then
                Return False
            End If

            Dim blnResult As Boolean = False
            ''check for LotID, SeqID not empty
            If Not String.IsNullOrEmpty(txtLotID.Text) AndAlso Not String.IsNullOrEmpty(txtSeqID.Text) Then
                ''check Ig On, Hivac On
                Dim Is_IGOn_HivacOpen As Boolean = False
                Dim eqLL As LoadLock = Nothing
                Dim objLLElevator As AVPLib.DataManagerment.LLElevator = Nothing
                Dim objLLController As AVPLib.Business.LoadLockController = Nothing

                'Need to prevent user from clicking on start button at this condition. 
                'Rough only, Start button should not enable when pressure off LLx is not below 
                '�cross over pressure� & LLx(isovalve Is Not Open)
                Dim Cross_Over_Pressure As Single = 0

                If Me.Name = ConstantAndEnum.LOADLOCKA Then
                    Cross_Over_Pressure = AVPLib.VentPumdownLib.LLPumpdownConfig.LLAFastRoughPressure

                    eqLL = AVPLib.DataManagerment.EquipmentManager.GetEquipment(LoadLockA_STR)
                    objLLElevator = _
                    AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
                    objLLController = AVPLib.Business.ControllerManager.GetController(LoadLockA_STR)
                End If

                Dim objTMController As AVPLib.Business.TMController = _
                AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())

                '''''''''''''''''''''''''''''''''''''
                If eqLL IsNot Nothing AndAlso objLLController IsNot Nothing Then
                    ''''IG is On  + Hivac is On 
                    If Me.Name = ConstantAndEnum.LOADLOCKA AndAlso AVPLib.RobotConfigurationValues.LLA_HIVAC_INSTALLED Then
                        Is_IGOn_HivacOpen = (eqLL.IGStatus = Equipment.WorkingStatuses.On) AndAlso _
                                          (eqLL.HiVacValveStatus = Equipment.WorkingStatuses.On)
                    Else
                        Is_IGOn_HivacOpen = True
                    End If

                    ''checking for Load/Unload finish
                    Dim blnLoad_UnloadFinish As Boolean = False
                    blnLoad_UnloadFinish = (btnLoad.Text = "LOAD" AndAlso btnUnload.Text = "UNLOAD" AndAlso btnAbort.Text = "ABORT")

                    'VEN/PUMDOWN/UNLOAD/LOAD
                    Dim blSequenceRunning As Boolean = False
                    blSequenceRunning = objLLController.IsVentSeqRunning Or _
                                        objLLController.IsPumpDownSeqRunning Or _
                                        objLLController.IsUnloadSeqRunning Or _
                                        objLLController.IsLoadSeqRunning Or _
                                        objTMController.IsVentSeqRunning Or _
                                        objTMController.IsPumpDownSeqRunning

                    ' +++++++++++++++++not Online Remote
                    blnResult = Is_IGOn_HivacOpen And blnLoad_UnloadFinish And Not (AVPRobotMain.OnlineRemote)

                    Dim IsReturnFreeJob As Boolean = False
                    Dim objJobmanager As AVPLib.Business.AVPJobManager = Nothing
                    objJobmanager = AVPLib.Business.AVPCore.Instance().JobManager()

                    If Me.Name = ConstantAndEnum.LOADLOCKA Then
                        'Semi Auto Transfer running = Not auto tranfer + semi autotranfer running
                        If (objJobmanager IsNot Nothing) Then
                            IsReturnFreeJob = objJobmanager.isAllReturnFreeJobInLoadLockFinished(ConstantAndEnum.LOAD_LOCK_A.ToString())
                            If (btnStart.Text = "START") Then
                                IsReturnFreeJob = IsReturnFreeJob And objJobmanager.isAllJobInLoadLockFinished(ConstantAndEnum.LOAD_LOCK_A.ToString())
                            End If
                        End If
                    End If

                    'no sequence running
                    blnResult = blnResult And Not blSequenceRunning And IsReturnFreeJob

                    '+++ not Aborting
                    blnResult = blnResult And Not (Me.btnAbort.Text = "Aborting")

                    '+++ map success
                    blnResult = blnResult And objLLElevator.MapWaferSuccess

                    ' if clear all wafer is not running
                    blnResult = blnResult And Not ContainerForm.ProcessPanel.IsButtonClearAllWaferClicked

                    'Need to prevent user from clicking on start button at this condition. 
                    'Rough only, Start button should not enable when pressure off LLx is not below 
                    '�cross over pressure� & LLx(isovalve Is Not Open)
                    If (blnResult AndAlso Not eqLL.IsIGInstalled) Then
                        blnResult = blnResult And (eqLL.CG <= Cross_Over_Pressure)

                        If (blnResult) Then
                            Dim objTM As AVPLib.DataManagerment.CassettesModule = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.CassettesModule.ToString)
                            If (objTM IsNot Nothing) Then
                                If (Me.Name = ConstantAndEnum.LOADLOCKA) Then
                                    blnResult = blnResult And (objTM.SplitValve1Status = AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            Return blnResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-05-5</date>
    ''' </author>
    ''' <summary>
    ''' EnableFormAbortStart
    ''' </summary>
    ''' <param name="Enable"></param>
    ''' <remarks></remarks>
    'Only Enable when auto transfer job is running
    Private Function CheckCondition_Enable_AbortButton() As Boolean
        Try
            If Not isCheckPermission Then
                Return False
            End If

            Dim blnResult As Boolean = False

            Dim IsSchedulerRunning As Boolean = False
            Dim objJobmanager As AVPLib.Business.AVPJobManager = Nothing
            objJobmanager = AVPLib.Business.AVPCore.Instance().JobManager()

            If Me.Name = ConstantAndEnum.LOADLOCKA Then
                If (objJobmanager IsNot Nothing) Then
                    IsSchedulerRunning = Not objJobmanager.IsAllAutoTransferJobInLoadLockFinished(ConstantAndEnum.LOAD_LOCK_A.ToString())
                End If
            End If

            '''''''''''''''''''''''''''''''''''''
            blnResult = Not (AVPRobotMain.OnlineRemote)

            'no sequence running
            blnResult = blnResult And IsSchedulerRunning

            Return blnResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-05-5</date>
    ''' </author>
    ''' <summary>
    ''' Load Enable when:
    ''' Load disable when scheduler is running or other sequence running
    ''' </summary>
    ''' <param name="Enable"></param>
    ''' <remarks></remarks>

    Public Function CheckCondition_Enable_LoadButton() As Boolean
        Try
            If Not isCheckPermission Then
                Return False
            End If

            Dim blnResult As Boolean = False

            Dim eqLL As LoadLock = Nothing
            Dim objLLElevator As AVPLib.DataManagerment.LLElevator = Nothing
            Dim objLLController As AVPLib.Business.LoadLockController = Nothing
            Dim IsSchedulerRunning As Boolean = False
            Dim objJobmanager As AVPLib.Business.AVPJobManager = Nothing
            objJobmanager = AVPLib.Business.AVPCore.Instance().JobManager()

            If Me.Name = ConstantAndEnum.LOADLOCKA Then
                eqLL = AVPLib.DataManagerment.EquipmentManager.GetEquipment(LoadLockA_STR)
                objLLElevator = _
                AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
                objLLController = AVPLib.Business.ControllerManager.GetController(LoadLockA_STR)
                If (objJobmanager IsNot Nothing) Then
                    IsSchedulerRunning = Not objJobmanager.isAllJobInLoadLockFinished(ConstantAndEnum.LOAD_LOCK_A.ToString())
                End If
            End If

            Dim objTMController As AVPLib.Business.TMController = _
                AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())

            '''''''''''''''''''''''''''''''''''''
            If eqLL IsNot Nothing AndAlso objLLController IsNot Nothing AndAlso objTMController IsNot Nothing Then

                Dim blSequenceRunning As Boolean = False

                'SCHEDULER/VENT/PUMDOWN/UNLOAD

                blSequenceRunning = objLLController.IsVentSeqRunning Or _
                                    objLLController.IsPumpDownSeqRunning Or _
                                    objLLController.IsUnloadSeqRunning Or _
                                    objTMController.IsVentSeqRunning Or _
                                    objTMController.IsPumpDownSeqRunning Or _
                                    IsSchedulerRunning

                ' +++++++++++++++++not Online Remote
                ' blnResult = Not (AVPRobotMain.OnlineRemote)

                'no sequence running
                blnResult = Not blSequenceRunning

                ' if clear all wafer is not running
                blnResult = blnResult And Not ContainerForm.ProcessPanel.IsButtonClearAllWaferClicked
            End If

            If btnLoad.Text = UCase(AVPLib.ConstEnum.Abort) Then
                blnResult = True
            End If

            Return blnResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-05-5</date>
    ''' </author>
    ''' <summary>
    ''' Load Enable when:
    ''' Load disable when scheduler is running or other sequence running
    ''' </summary>
    ''' <param name="Enable"></param>
    ''' <remarks></remarks>
    Public Function CheckCondition_Enable_UnLoadButton() As Boolean
        Try
            If Not isCheckPermission Then
                Return False
            End If

            Dim blnResult As Boolean = False

            Dim eqLL As LoadLock = Nothing
            Dim objLLElevator As AVPLib.DataManagerment.LLElevator = Nothing
            Dim objLLController As AVPLib.Business.LoadLockController = Nothing
            Dim IsSchedulerRunning As Boolean = False
            Dim objJobmanager As AVPLib.Business.AVPJobManager = Nothing
            objJobmanager = AVPLib.Business.AVPCore.Instance().JobManager()

            If Me.Name = ConstantAndEnum.LOADLOCKA Then
                eqLL = AVPLib.DataManagerment.EquipmentManager.GetEquipment(LoadLockA_STR)
                objLLElevator = _
                AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
                objLLController = AVPLib.Business.ControllerManager.GetController(LoadLockA_STR)
                If (objJobmanager IsNot Nothing) Then
                    IsSchedulerRunning = Not objJobmanager.isAllJobInLoadLockFinished(ConstantAndEnum.LOAD_LOCK_A.ToString())
                End If
            End If

            Dim objTMController As AVPLib.Business.TMController = _
                AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())

            '''''''''''''''''''''''''''''''''''''
            If eqLL IsNot Nothing AndAlso objLLController IsNot Nothing AndAlso objTMController IsNot Nothing Then

                'SCHEDULER/VENT/PUMDOWN/UNLOAD
                Dim blSequenceRunning As Boolean = False
                blSequenceRunning = objLLController.IsVentSeqRunning Or _
                                    objLLController.IsPumpDownSeqRunning Or _
                                    objLLController.IsLoadSeqRunning Or _
                                    objTMController.IsVentSeqRunning Or _
                                    objTMController.IsPumpDownSeqRunning Or _
                                    IsSchedulerRunning

                ' +++++++++++++++++not Online Remote
                'blnResult = (AVPRobotMain.OnlineRemote)

                'no sequence running
                blnResult = Not blSequenceRunning

                ' if clear all wafer is not running
                blnResult = blnResult And Not ContainerForm.ProcessPanel.IsButtonClearAllWaferClicked
            End If

            If btnUnload.Text = UCase(AVPLib.ConstEnum.Abort) Then
                blnResult = True
            End If

            Return blnResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-05-05</date>
    ''' </author>
    ''' <summary>
    ''' CheckCondition_Enable_Seq_LotID
    ''' </summary>
    ''' <remarks></remarks>
    Public Function CheckCondition_Enable_Seq_LotID() As Boolean
        Dim bResult As Boolean = True

        Try
            Dim jobManager As AVPLib.Business.AVPJobManager = AVPLib.Business.AVPCore.Instance().JobManager
            If jobManager IsNot Nothing Then
                If Me.Name = ConstantAndEnum.LOADLOCKA Then
                    bResult = jobManager.IsAllAutoTransferJobInLoadLockFinished(ConstantAndEnum.LOAD_LOCK_A.ToString())
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return bResult
    End Function

    Private Sub SetTextBoxState(ByVal txtBox As TextBox, ByVal state As Boolean)
        txtBox.Enabled = state
        If state Then
            txtBox.BackColor = SystemColors.Window
        Else
            txtBox.BackColor = Color.LightGray
        End If
    End Sub

    Public Sub txtSeqID_MeasureString()
        ' Calculate the fitted string
        Dim linesFitted As Integer
        Dim f As Font = Me.txtSeqID.Font
        Dim rect As Rectangle = txtSeqID.ClientRectangle
        m_SeqIDGraphics.MeasureString(txtSeqID.Text, f, rect.Size, m_sf, m_strSeqIDCharFitted, linesFitted)

        ' Save original string 
        SeqID = txtSeqID.Text

        'after Measure text
        If (txtSeqID.Text.Length > 0) Then
            ' Use "..." for long string
            If m_strSeqIDCharFitted < txtSeqID.Text.Length Then
                txtSeqID.Text = txtSeqID.Text.Substring(0, m_strSeqIDCharFitted) & "..."
            End If
            ValueToolTip.SetToolTip(txtSeqID, SeqID)
        End If
    End Sub

    Private Sub txtLotID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLotID.Leave
        ' Calculate the fitted string
        Dim linesFitted As Integer
        Dim f As Font = Me.txtLotID.Font
        Dim rect As Rectangle = txtLotID.ClientRectangle
        m_LotIDGraphics.MeasureString(txtLotID.Text, f, rect.Size, m_sf, m_strLotIDCharFitted, linesFitted)

        ' Save the orginal string
        LotID = txtLotID.Text

        ' Use "..." for long string
        If m_strLotIDCharFitted < txtLotID.Text.Length Then
            txtLotID.Text = txtLotID.Text.Substring(0, m_strLotIDCharFitted) & "..."
        End If
        ValueToolTip.SetToolTip(txtLotID, LotID)
    End Sub

    Private Sub txtLotID_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLotID.Enter
        txtLotID.Text = LotID
    End Sub

    Protected Overrides Sub Finalize()
        If m_LotIDGraphics IsNot Nothing Then
            m_LotIDGraphics.Dispose()
        End If
        If m_SeqIDGraphics IsNot Nothing Then
            m_SeqIDGraphics.Dispose()
        End If
        'MyBase.Finalize()
        'Me.Finalize()
    End Sub

    Private Sub txtTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.Click
        Try
            If AVPLib.ContainerData.Permission(PERMISSION_006) = False Then
                Exit Sub
            End If
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText("ResetWaferCounter")
            If (Utils.ShowAVPMessageBox(strMessageText, "Reset Wafer Count", MessageBoxIcon.Question) = DialogResult.OK) Then

                Me.txtTotal.Text = "0"
                'If (Me.Name = "lpcLoadLockA" AndAlso ContainerForm.ProcessPanel.lpcLoadLockB IsNot Nothing) Then
                '    ContainerForm.ProcessPanel.wccWaferCount.txtTotal.Text = ContainerForm.ProcessPanel.lpcLoadLockB.txtTotal.Text
                'ElseIf (Me.Name = "lpcLoadLockA" AndAlso ContainerForm.ProcessPanel.lpcLoadLockB Is Nothing) Then
                '    ContainerForm.ProcessPanel.wccWaferCount.txtTotal.Text = "0"
                'ElseIf (Me.Name = "lpcLoadLockB" AndAlso ContainerForm.ProcessPanel.lpcLoadLockA IsNot Nothing) Then
                '    ContainerForm.ProcessPanel.wccWaferCount.txtTotal.Text = ContainerForm.ProcessPanel.lpcLoadLockA.txtTotal.Text
                'ElseIf (Me.Name = "lpcLoadLockB" AndAlso ContainerForm.ProcessPanel.lpcLoadLockA Is Nothing) Then
                '    ContainerForm.ProcessPanel.wccWaferCount.txtTotal.Text = "0"
                'End If

                ResetWaferCount()

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                          AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                          "[Main Screen] " + "Click on Total button.")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    'When Click to wafercount control
    '-> reset loadlockA and loadlockB 
    Public Sub ResetWaferCount()
        m_stoStatusObject.RequestStatus(txtTotal.Name, "reset")
    End Sub

    Private Sub txtLotID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLotID.Click
        Try
            Dim pad As New KeyPad
            pad.IsCheckInvalidCharacter = True
            pad.Enable_Disable_SpecKey(False)
            Dim Value As String = LotID
            If pad.DisplayKeypad(Value, "Please input Lot ID", False) = Windows.Forms.DialogResult.OK Then
                If Value.Contains(AVPLib.ConstEnum.DataRunFileNameSeparator) Then
                    Utils.ShowAVPMessageBox(String.Format("Lot ID must be not contained ""{0}"".", AVPLib.ConstEnum.DataRunFileNameSeparator), "", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                    Return
                End If

                txtLotID.Text = Value
                LotID = txtLotID.Text.Trim() ' Added to synchronize Lot ID value
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Private Sub tmBlinkText_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmBlinkText.Tick
        If m_intTimerCount_BlinkText > 0 Then
            If (m_intTimerCount_BlinkText Mod 2 = 1) Then
                lblFinishProcess.ForeColor = Color.Black
                lblFinishLoadUnload.ForeColor = Color.Black
            Else
                lblFinishProcess.ForeColor = Color.Lime
                lblFinishLoadUnload.ForeColor = Color.Lime
            End If
            m_intTimerCount_BlinkText -= 1
        Else
            m_intTimerCount_BlinkText = 1000
        End If
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 13-05-2011</date>
    ''' </author>
    ''' <summary>
    ''' Do not Enable when Scheduler is Running
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub psgPressureGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles psgPressureGraph.Click
        Try
            If AVPLib.ContainerData.Permission(PERMISSION_002) = False Then
                Exit Sub
            End If

            If Not AVPLib.ContainerDAO.ReadEnableQuickSequenceEditor() Then
                Exit Sub
            End If

            txtSeqID.Tag = Boolean.TrueString
            Dim CreateSequenceDlg As CreateSequenceDialog = Nothing
            Dim openDialogInReadOnly As Boolean = False

            If (btnStart.Text = "START") Then
                If Not String.IsNullOrEmpty(txtSeqID.Text) Then
                    If (Me.Name.Contains(ConstantAndEnum.LOAD_LOCK_A)) Then
                        CreateSequenceDlg = New CreateSequenceDialog(SeqID, AVPLib.RobotConfigurationValues.SLOT_NUM_LLA, openDialogInReadOnly)
                    End If
                Else
                    CreateSequenceDlg = New CreateSequenceDialog()
                End If
            Else  ''is running so we open sequence dialog in readonly
                openDialogInReadOnly = True

                If Not String.IsNullOrEmpty(txtSeqID.Text) AndAlso Me.Name.Contains(ConstantAndEnum.LOAD_LOCK_A) Then
                    CreateSequenceDlg = New CreateSequenceDialog(SeqID, AVPLib.RobotConfigurationValues.SLOT_NUM_LLA, openDialogInReadOnly)
                Else
                    Exit Sub
                End If
            End If
            CreateSequenceDlg.LLName = Me.Name
            CreateSequenceDlg.ShowDialog()

            CreateSequenceDlg.Dispose()
        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.Message)
        End Try
    End Sub

    Private Sub txtCompletedCycleWaferAt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompletedCycleWaferAt.TextChanged
        If m_isInCycleMode Then
            Me.Header.OffText = HeaderText_Off & " - Cycling " & txtCompletedCycleWaferAt.Text
            Me.Header.OnText = HeaderText_On & " - Cycling " & txtCompletedCycleWaferAt.Text
            Me.Header.Text = IIf(Me.Header.Status = DisplayStatus.On, Me.Header.OnText, Me.Header.OffText)
        End If
    End Sub

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-06-05 </date>
    ''' </author>
    ''' <summary>
    ''' Paint Border for panel
    ''' </summary>
    Private Sub Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Utils.PaintBorder(sender, e)
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Send mail when scheduler status change
    ''' </summary>
    Public Sub SendMailWhenSchedulerStatusChange(ByVal strStateScheduler As String)
        Try
            Dim strContentEmail As String = String.Empty

            If Not String.IsNullOrEmpty(txtLotID.Text) AndAlso Not String.IsNullOrEmpty(txtSeqID.Text) AndAlso Not String.IsNullOrEmpty(strStateScheduler) Then
                strContentEmail = "LotID/SequenceID : " & txtLotID.Text & "/" & txtSeqID.Text & " is " & strStateScheduler

                AVPLib.SendEmail.Instance.Send(" LoadLockA - " & strContentEmail, TriggerType.SCHEDULER)
            End If
        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.Message)
        End Try
    End Sub

    Friend Overrides Sub Header_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim wfProcessTime As New WaferProcessTimePopUp
            With wfProcessTime
                If Me.Name = ConstantAndEnum.LOADLOCKA Then
                    .LoadLockID = AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
                End If
                .ShowDialog()
            End With

        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.Message)
        End Try
    End Sub


    ''' <author>
    '''    	<name> Duc Pham </name>
    '''    	<date> 2018-11-26 </date>
    ''' </author>
    ''' <summary>
    ''' psgPressureGraph_MouseMove
    ''' </summary>
    Private Sub psgPressureGraph_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles psgPressureGraph.MouseMove
        Try
            If Not AVPLib.ContainerDAO.ReadEnableQuickSequenceEditor() Then
                psgPressureGraph.Cursor = Cursors.Arrow
            Else
                psgPressureGraph.Cursor = Cursors.Hand
            End If
        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.Message)
        End Try
    End Sub

    Private Sub lblPressure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPressure.TextChanged
        Try
            lblPressure.ForeColor = IIf(lblPressure.Text = AVPLib.ConstEnum.STR_ERROR, Color.Red, Color.Lime)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class