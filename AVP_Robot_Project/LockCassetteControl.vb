Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.DataManagerment
Imports AVPLib.Business
Imports AVPControls

Public Class LockCassetteControl
#Region "Class Constants & Variables"
    Public Enum DisplayStyle
        [Left] = 0
        [Right] = 1
    End Enum

    Private m_intDisplayStyle As DisplayStyle
    Public SemiautoTransferWaferPanel As SemiautoTranferWaferControl
    Private m_strLockName As String
    Private m_blnHave25Slot As Boolean = False
    Private Const BUTTON_WIDTH As Integer = 100
    Private m_Is_Connected As Boolean = False
    Private m_blnIsLLOnline As Boolean = False
    Private m_IsCassetteInUsed As Boolean = False
    Private m_blnEnableDisableForm As Boolean
    Private m_isAllowActionInForm As Boolean = True
    Private m_isCassetteHome As Boolean

#End Region

#Region "Public Properties"
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property Is_Connected() As Boolean
        Get
            Return m_Is_Connected
        End Get
        Set(ByVal value As Boolean)
            If m_Is_Connected <> value Then
                m_Is_Connected = value
                SetActiveForm()

                If Not Is_Connected Then
                    btnClose.NormalBackground = My.Resources.Resources.BtnButtonGreen
                    btnClose.PressedBackground = My.Resources.Resources.BtnButtonGreenDown
                    btnOpen.NormalBackground = My.Resources.Resources.BtnButtonWhite
                    btnOpen.PressedBackground = My.Resources.Resources.BtnButtonWhiteDown
                End If
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsLLOnline() As Boolean
        Get
            Return m_blnIsLLOnline
        End Get
        Set(ByVal value As Boolean)
            If m_blnIsLLOnline <> value Then
                m_blnIsLLOnline = value
                If m_blnIsLLOnline Then
                    Me.Panel2.BackgroundImage = My.Resources.Resources.BgHeaderGreen
                    Me.lblTitle.ForeColor = Color.Black
                    Me.lblOnline.ForeColor = Color.Black
                    Me.lblOnline.Text = "(Online)"
                Else
                    Me.Panel2.BackgroundImage = My.Resources.Resources.BgHeaderBlue
                    Me.lblTitle.ForeColor = Color.White
                    Me.lblOnline.ForeColor = Color.Yellow
                    lblOnline.Text = "(Offline)"
                End If
                SetActiveForm()
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Get or set text of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Overrides Property Text() As String
        Get
            Return lblTitle.Text
        End Get
        Set(ByVal value As String)
            lblTitle.Text = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-27</date>
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
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author> 
    ''' <summary>
    ''' Set or get name of lock
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property LockName() As String
        Get
            Return m_strLockName
        End Get
        Set(ByVal value As String)
            Try
                m_strLockName = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    Public Property IsCassetteInUsed() As Boolean
        Get
            Return m_IsCassetteInUsed
        End Get
        Set(ByVal value As Boolean)
            If m_IsCassetteInUsed <> value Then
                m_IsCassetteInUsed = value
                SetActiveForm()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Public Property IsAllowAction() As Boolean
        Get
            Return m_isAllowActionInForm
        End Get
        Set(ByVal value As Boolean)
            If m_isAllowActionInForm <> value Then
                m_isAllowActionInForm = value
                SetActiveForm()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-06</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the casstte is home.
    ''' </summary>
    <DefaultValue(False)> _
    Public Property IsCassetteHome() As Boolean
        Get
            Return m_isCassetteHome
        End Get
        Set(ByVal value As Boolean)
            If m_isCassetteHome <> value Then
                m_isCassetteHome = value

                If m_isCassetteHome Then
                    btnHome.NormalBackground = My.Resources.Resources.BtnButtonGreen
                    btnHome.PressedBackground = My.Resources.Resources.BtnButtonGreenDown
                Else
                    btnHome.NormalBackground = My.Resources.Resources.BtnButtonWhite
                    btnHome.PressedBackground = My.Resources.Resources.BtnButtonWhiteDown
                End If
            End If
        End Set
    End Property

#End Region

#Region "Protected method"
    Private Sub ElevatorCMDAction(ByVal blnActionSend As Boolean, ByVal blnManualAction As Boolean, ByVal strEquipmentName As String)
        ' In this case, we have to access directly to the controller
        Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(strEquipmentName), LoadLockController)
        Dim ctrElevator As LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)
        ' turn the flag off; mean the polling command return from now on do not sure is the actual status, util this flag on
        ' The command is not really sent yet 
        ctrElevator.ActionCMDSent = blnActionSend
        ctrElevator.IsManualAction = blnManualAction
    End Sub

    Private Function CheckLLCGReachVentPressure(ByVal strEquipmentName As String, Optional ByVal isCheckSafety As Boolean = False) As Boolean
        If (isCheckSafety) Then
            Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(strEquipmentName), LoadLockController)

            If (ctrLoadLock.IsLLCGDisconnected) Then
                AVPLib.Utils.ThrowAlarm(AVPLib.Utils.chamberID2ChamberName(strEquipmentName) & AVPLib.ConstEnum.CG_DISCONNECTED)
                Return False
            End If

            If Not ctrLoadLock.IsLLCGReachFastVentPressureSetPointCondToOpenDoor Then
                AVPLib.Utils.ThrowAlarm(String.Format("{0} Pressure is not at Vent Pressure. Open Failed", strEquipmentName))
                Return False
            End If
        End If

        Return True
    End Function
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            'Dim sbcCL As New StatusBinaryStatusControl(cscCL)
            'Dim sbcCP As New StatusBinaryStatusControl(cscCP)
            Dim sbcDC As New StatusBinaryStatusControl(cscDC)
            Dim slbTorr As New StatusPressureLabel(lblTorr)
            Dim stgGraph As New StatusGraph(psgPressureGraph)
            Dim operationStatus As New StatusLoadLockControl(Me, "operationStatus")
            Dim stb_Relay As New StatusTurboRelayIndicator(btnRelay)
            Dim sbtComStatus As New StatusIGCGButton(btnComStatus)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(slbTorr)
            m_stoStatusObject.AddChild(stgGraph)
            m_stoStatusObject.AddChild(operationStatus)
            m_stoStatusObject.AddChild(sbcDC)
            m_stoStatusObject.AddChild(stb_Relay)
            m_stoStatusObject.AddChild(sbtComStatus)

            ' Attach stattus changed event handler for DC Control.
            AddHandler sbcDC.StatusChangedEvent, AddressOf BinaryControlStatusChangedEventHandler
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub CommStateChangeHandler(ByVal state As Boolean)
        If (Me.InvokeRequired) Then
            Me.Invoke(New CommunicationState(AddressOf CommStateChangeHandler), state)
        Else
            Is_Connected = state

            ' Also update to LoadLockLeg in each screens
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If Me.Name = ConstantAndEnum.LOCKCASSETTEA Then
                    ContainerForm.CassettesPanel.LLALeg.IsLLConnected = state
                    ContainerForm.ProcessPanel.LLALeg.IsLLConnected = state
                End If
            End If
        End If
    End Sub

    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2011-03-22</date>
    ''' </author>
    ''' <summary>
    ''' If it is an manual elevator, we don't update the status
    ''' It is always Disabled
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Public Function EnableDisableOpenButton(ByVal newState As Boolean) As Boolean
        Dim serverConfig As AVPLib.Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
        
        If serverConfig IsNot Nothing Then
            If serverConfig.IsManualDoorElevator = True Then
                ' always return false
                Return False
            Else
                Return newState
            End If
        End If
        Return newState
    End Function

    Private Sub BinaryControlStatusChangedEventHandler(ByVal sender As Object, ByVal sce As AVPLib.DataManagerment.StatusChangedEventArgs)
        If sender.Equals(cscDC) Then
            'btnOpen.Enabled = IIf(sce.Message = STRING_OFF And btnOpen.Enabled, True, False)
            'btnClose.Enabled = IIf(sce.Message = STRING_ON And btnClose.Enabled, True, False)
            If sce.Message = STRING_ON Then ''door Open

                If Me.Name = ContainerForm.CassettesPanel.lccLoadLockA.Name Then
                    ContainerForm.ProcessPanel.lpcLoadLockA.txtLotID.Text = String.Empty
                    ContainerForm.ProcessPanel.lpcLoadLockA.LotID = String.Empty
                    btnOpen.NormalBackground = My.Resources.Resources.BtnButtonGreen
                    btnOpen.PressedBackground = My.Resources.Resources.BtnButtonGreenDown
                    btnClose.NormalBackground = My.Resources.Resources.BtnButtonWhite
                    btnClose.PressedBackground = My.Resources.Resources.BtnButtonWhiteDown
                End If
            ElseIf sce.Message = STRING_OFF Then
                If Me.Name = ContainerForm.CassettesPanel.lccLoadLockA.Name Then
                    btnClose.NormalBackground = My.Resources.Resources.BtnButtonGreen
                    btnClose.PressedBackground = My.Resources.Resources.BtnButtonGreenDown
                    btnOpen.NormalBackground = My.Resources.Resources.BtnButtonWhite
                    btnOpen.PressedBackground = My.Resources.Resources.BtnButtonWhiteDown
                End If
            End If
        End If
    End Sub

#End Region

#Region "Private Methods"
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
            Me.lblTitle.Dock = DockStyle.Left
            Me.lblTitle.TextAlign = ContentAlignment.MiddleLeft

            Me.btnGoToSlot.Left = 7
            Me.btnHome.Left = 7
            Me.btnMap.Left = 7
            Me.btnOpen.Left = 7
            Me.btnClose.Left = 7

            Me.psgPressureGraph.AlignStyle = AVP_Robot_Project.PressureGraph.DisplayStyle.Left
            Me.psgPressureGraph.Left = btnClose.Left + btnClose.Width + 4

            Me.Width = psgPressureGraph.Left + psgPressureGraph.Width + 7

            Me.pnlRelay.Left = Me.Width - Me.pnlRelay.Width - 6

            Me.lblPressure.Left = (Me.Width / 2 - Me.lblPressure.Width) - 6
            Me.lblPressure.TextAlign = ContentAlignment.MiddleRight

            Me.lblTorr.Left = (Me.Width / 2) - 6
            Me.lblTorr.TextAlign = ContentAlignment.MiddleLeft

            Me.pnlCom.Left = Me.Width - Me.pnlCom.Width
            Me.btnComStatus.Left = Me.pnlCom.Width - Me.btnComStatus.Width - 7
            Me.lblCommunication.Left = Me.btnComStatus.Left - Me.lblCommunication.Width
            Me.lblOnline.Left = Me.lblTitle.Left + Me.lblTitle.Width + (Me.pnlCom.Left - Me.lblTitle.Left - Me.lblTitle.Width) / 2 - Me.lblOnline.Width / 2

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
            Me.lblTitle.Dock = DockStyle.Right
            Me.lblTitle.TextAlign = ContentAlignment.MiddleRight

            Me.pnlCom.Left = 0
            Me.btnComStatus.Left = 7
            Me.lblCommunication.TextAlign = ContentAlignment.MiddleLeft
            Me.lblCommunication.Left = btnComStatus.Left + btnComStatus.Width

            Me.psgPressureGraph.AlignStyle = AVP_Robot_Project.PressureGraph.DisplayStyle.Right
            Me.psgPressureGraph.Left = 7

            Me.btnGoToSlot.Left = Me.psgPressureGraph.Left + Me.psgPressureGraph.Width + 4
            Me.btnHome.Left = Me.psgPressureGraph.Left + Me.psgPressureGraph.Width + 4
            Me.btnOpen.Left = Me.psgPressureGraph.Left + Me.psgPressureGraph.Width + 4
            Me.btnMap.Left = Me.psgPressureGraph.Left + Me.psgPressureGraph.Width + 4
            Me.btnClose.Left = Me.psgPressureGraph.Left + Me.psgPressureGraph.Width + 4

            Me.Width = btnClose.Left + btnClose.Width + 7

            Me.lblOnline.Left = Me.lblCommunication.Left + Me.lblCommunication.Width + (Me.lblTitle.Left - Me.lblCommunication.Left - Me.lblCommunication.Width) / 2 - Me.lblOnline.Width / 2

            Me.pnlRelay.Left = 6


            Me.lblPressure.Left = (Me.Width / 2 - Me.lblPressure.Width) + 6
            Me.lblPressure.TextAlign = ContentAlignment.MiddleRight

            Me.lblTorr.Left = (Me.Width / 2) + 3
            Me.lblTorr.TextAlign = ContentAlignment.MiddleLeft

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-07 </date>
    ''' </author>
    ''' <summary>
    ''' Active form base on conditions
    ''' </summary>
    Private Sub SetActiveForm()
        Dim enable As Boolean = m_blnEnableDisableForm AndAlso Is_Connected AndAlso Not m_blnIsLLOnline AndAlso Not m_IsCassetteInUsed AndAlso m_isAllowActionInForm
        Me.btnComStatus.Enabled = enable
        Me.btnGoToSlot.Enabled = enable
        Me.btnHome.Enabled = enable
        Me.btnMap.Enabled = enable
        Me.btnOpen.Enabled = EnableDisableOpenButton(enable)
        Me.btnClose.Enabled = EnableDisableOpenButton(enable)
        Me.psgPressureGraph.Enabled = enable
        Me.btnRelay.Enabled = enable
        Me.lblTorr.Cursor = IIf(m_blnEnableDisableForm AndAlso Not IsLLOnline AndAlso m_isAllowActionInForm, Cursors.Hand, Cursors.Default)

        ' Also update to LoadLockLeg control
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            If Me.Name = ContainerForm.CassettesPanel.lccLoadLockA.Name Then
                ContainerForm.CassettesPanel.LLALeg.IsAllowAction = enable
            End If
        End If

    End Sub
#End Region

#Region "Events � Buttons � Forms�"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Handle event that user click on graph
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub psgPressureGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles psgPressureGraph.Click
        AVPLib.Log.guiLogger.Info("Enter psgPressureGraph_Click")
        Try
            If (Not Me.btnMap.Enabled) Then
                Return
            End If

            Dim f As New SelectWaferForm
            f.SemiautoTransferWaferPanel = SemiautoTransferWaferPanel
            f.LockName = Me.LockName
            f.stoStatusObject = Me.m_stoStatusObject
            f.Text = "LOAD LOCK " + Me.LockName + " MAP"
            f.BarsStatus = psgPressureGraph.BarsStatus
            f.ShowDialog()
            Dim intWaferID As Integer = f.SelectedWaferIndex
            Dim strCMD As String = "Load Lock " + LockName + ", Slot " + intWaferID.ToString()
            Select Case f.WaferDialogResult
                Case SelectWaferForm.SelectWaferDialogResult.SourceForMove
                    If SemiautoTransferWaferPanel.btnStart.Enabled = False AndAlso _
               Not String.IsNullOrEmpty(SemiautoTransferWaferPanel.txtSource.Text) AndAlso _
                      Not String.IsNullOrEmpty(SemiautoTransferWaferPanel.txtDestination.Text) Then ''transferring
                        Utils.ShowAVPMessageBox("Please wait for other transfer to complete...", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
                    Else
                        'SOURCE = NEW SOURCE
                        SemiautoTransferWaferPanel.txtSource.Text = strCMD
                        'IF DESTINATION = SOURCE (ERROR)
                        If SemiautoTransferWaferPanel.txtSource.Text = SemiautoTransferWaferPanel.txtDestination.Text Then
                            Utils.ShowAVPMessageBox("Source and Destination for Transfer Wafer are the same, Destination will be clear. " & Chr(13) & "Please select Destination for Transfer Wafer again", "Transfer Wafer", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                            'NEW DESTIANTION IS WRONG SO CLEAR IT
                            SemiautoTransferWaferPanel.txtDestination.Clear()
                        End If
                        'WHEN EVERYTHING OK -> SHOW STATUS MESSAGE ON BOTTON LEFT SCREEN
                        AVPLib.Utils.ShowStatusMessage("Source for Transfer Wafer: " & SemiautoTransferWaferPanel.txtSource.Text)
                        'SHOW DIALOG BOX TO SELECT ALIGNER
                        ContainerForm.CassettesPanel.ShowTransferWaferDialog()
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Select Source For Move " + SemiautoTransferWaferPanel.txtSource.Text)
                    End If
                Case SelectWaferForm.SelectWaferDialogResult.DestinationForMove
                    If SemiautoTransferWaferPanel.btnStart.Enabled = False AndAlso _
               Not String.IsNullOrEmpty(SemiautoTransferWaferPanel.txtSource.Text) AndAlso _
                      Not String.IsNullOrEmpty(SemiautoTransferWaferPanel.txtDestination.Text) Then ''transferring
                        Utils.ShowAVPMessageBox("Please wait for other transfer to complete...", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
                    Else
                        'DESTINATION = NEW DESTINATION
                        SemiautoTransferWaferPanel.txtDestination.Text = strCMD
                        'IF DESTINATION = SOURCE (ERROR)
                        If SemiautoTransferWaferPanel.txtSource.Text = SemiautoTransferWaferPanel.txtDestination.Text Then
                            Utils.ShowAVPMessageBox("Source and Destination for Transfer Wafer are the same, Destination will be clear. " & Chr(13) & "Please select Destination for Transfer Wafer again", "Transfer Wafer", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                            'NEW DESTIANTION IS WRONG SO CLEAR IT
                            SemiautoTransferWaferPanel.txtSource.Clear()
                        End If
                        'WHEN EVERYTHING OK -> SHOW STATUS MESSAGE ON BOTTON LEFT SCREEN
                        AVPLib.Utils.ShowStatusMessage("Destination for Transfer Wafer: " & SemiautoTransferWaferPanel.txtDestination.Text)
                        'SHOW DIALOG BOX TO SELECT ALIGNER
                        ContainerForm.CassettesPanel.ShowTransferWaferDialog()
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Select Destination For Move " + SemiautoTransferWaferPanel.txtDestination.Text)
                    End If
            End Select
            'CheckSourceDes()
            Me.Refresh()

            f.Dispose()
            'Me.lblTorr.Location = New System.Drawing.Point(54, 38)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave psgPressureGraph_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Go to slot button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGoToSlot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoToSlot.Click
        AVPLib.Log.guiLogger.Info("Enter btnGoToSlot_Click")
        Dim strMessageText As String = String.Empty
        Dim strEquipmentName As String = String.Empty
        Try
            Dim MaxSlots As Integer = 12
            If Me.Name = LOCKCASSETTEA Then
                strEquipmentName = AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
                MaxSlots = AVPLib.RobotConfigurationValues.SLOT_NUM_LLA
            End If

            If Not Check_IsoValve_BeforeMoving(strEquipmentName) Then
                Exit Sub
            End If

            Dim f As New NumPad()
            Dim Text As String = "LL" + Me.LockName + " move to slot number:"
            Dim Value As String = "1"   'Min default is 1
            If f.GetUserInput(Value, -1, -1, 1, MaxSlots, Text, 0, True, False) = MsgBoxResult.Ok Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("GotoSlotRobotCassettes"), Value, AVPLib.ConstEnum.LLA_STR)
                If (Utils.ShowAVPMessageBox(strMessageText, AVPLib.ConstEnum.LLA_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ElevatorCMDAction(False, True, strEquipmentName)
                    m_stoStatusObject.RequestStatus(btnGoToSlot.Name, Value)
                    ContainerForm.CassettesPanel.SetLLIsWorking(Me, True)
                    Utils.LogUserEvent("Clicked on Go To Slot button of LoadLock " & Me.LockName, "TM Screen")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnGoToSlot_Click")
    End Sub
    ''' <author>
    '''    	<name>Le Hieu Truc </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Check Slit valve is Closed before action
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Function Check_IsoValve_BeforeMoving(ByVal strequipment As String) As Boolean
        Try
            If strequipment = AVPLib.ConstEnum.Equipments.LoadLockA.ToString() AndAlso _
                ContainerForm.CassettesPanel.MesaValveLLA.Status = BinaryStatusControl.DisplayStatus.Off Then
                Return True
            End If

            Dim strMessageText As String = String.Empty
            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("CheckMesaValveBeforeAction"), AVPLib.ConstEnum.LLA_STR)

            Utils.ShowAVPMessageBox(strMessageText, AVPLib.ConstEnum.LLA_STR, MessageBoxIcon.Information, MessageBoxButtons.OK)

            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                              AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                              ConstantAndEnum.TM_SCREEN & " - Check MesaValve before moving.")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Home button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        AVPLib.Log.guiLogger.Info("Enter btnHome_Click")
        Dim strMessageText As String = String.Empty
        Dim strEquipmentName As String = String.Empty
        Try
            If Me.Name = LOCKCASSETTEA Then
                strEquipmentName = AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
            End If
            If Not Check_IsoValve_BeforeMoving(strEquipmentName) Then
                Exit Sub
            End If
            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("HomeRobotCassettes"), AVPLib.ConstEnum.LLA_STR)
            If (Utils.ShowAVPMessageBox(strMessageText, AVPLib.ConstEnum.LLA_STR, MessageBoxIcon.Question) = DialogResult.OK) Then

                ElevatorCMDAction(False, True, strEquipmentName)

                m_stoStatusObject.RequestStatus(btnHome.Name, "Click")
                ContainerForm.CassettesPanel.SetLLIsWorking(Me, True)
                Utils.LogUserEvent("Clicked on Home button of LoadLock " & Me.LockName, "TM Screen")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnHome_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Map to slot button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap.Click
        AVPLib.Log.guiLogger.Info("Enter btnMap_Click")
        Dim strMessageText As String = String.Empty
        Dim strEquipmentName As String = String.Empty
        Try
            If Me.Name = LOCKCASSETTEA Then
                strEquipmentName = AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
            End If

            If Not Check_IsoValve_BeforeMoving(strEquipmentName) Then
                Exit Sub
            End If
            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MapRobotCassettes"), AVPLib.ConstEnum.LLA_STR)
            If (Utils.ShowAVPMessageBox(strMessageText, AVPLib.ConstEnum.LLA_STR, MessageBoxIcon.Question) = DialogResult.OK) Then

                ElevatorCMDAction(False, True, strEquipmentName)

                m_stoStatusObject.RequestStatus(btnMap.Name, "Click")
                ContainerForm.CassettesPanel.SetLLIsWorking(Me, True)
                Utils.LogUserEvent("Clicked on Map button of LoadLock " & Me.LockName, "TM Screen")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnMap_Click")
    End Sub
    

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Open to slot button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click, btnClose.Click
        AVPLib.Log.guiLogger.Info("Enter btnOpen_Click")
        Dim strMessageText As String = String.Empty
        Dim strEquipmentName As String = String.Empty
        Try

            If Me.Name = LOCKCASSETTEA Then
                strEquipmentName = AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
            End If
            If (sender Is btnOpen) Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("OpenRobotCassettes"), AVPLib.ConstEnum.LLA_STR)
                If (Utils.ShowAVPMessageBox(strMessageText, AVPLib.ConstEnum.LLA_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    If Not CheckLLCGReachVentPressure(strEquipmentName, ContainerForm.CassettesPanel.btnTMProtectedMode.Status = SL_CustomButton.DisplayStatus.Off) Then
                        Exit Sub
                    End If
                    ' In this case, we have to access directly to the controller
                    ElevatorCMDAction(False, True, strEquipmentName)
                    m_stoStatusObject.RequestStatus(btnOpen.Name, "Click Open")
                    ContainerForm.CassettesPanel.SetLLIsWorking(Me, True)
                    Utils.LogUserEvent("Open Robot Cassettes of LoadLock " & Me.LockName, "TM Screen")
                End If
            ElseIf (sender Is btnClose) Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("CloseRobotCassettes"), AVPLib.ConstEnum.LLA_STR)
                If (Utils.ShowAVPMessageBox(strMessageText, AVPLib.ConstEnum.LLA_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ElevatorCMDAction(False, True, strEquipmentName)
                    m_stoStatusObject.RequestStatus(btnOpen.Name, "Click Close")
                    ContainerForm.CassettesPanel.SetLLIsWorking(Me, True)
                    Utils.LogUserEvent("Close Robot Cassettes of LoadLock " & Me.LockName, "TM Screen")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOpen_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Reset to slot button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        AVPLib.Log.guiLogger.Info("Enter btnReset_Click")
        Dim strMessageText As String = String.Empty
        Dim strEquipment As String = String.Empty
        Dim strEquipmentName As String = String.Empty
        Try
            If Me.Name = LOCKCASSETTEA Then
                'strEquipmentName = ONLINELOADLOCKA
                strEquipmentName = AVPLib.ConstEnum.LLA_STR
                strEquipment = AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
            End If
            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("ResetRobotCassettes"), strEquipmentName)
            If (Utils.ShowAVPMessageBox(strMessageText, strEquipmentName, MessageBoxIcon.Question) = DialogResult.OK) Then
                ElevatorCMDAction(False, True, strEquipment)
                m_stoStatusObject.RequestStatus(btnReset.Name, "Click")
                ContainerForm.CassettesPanel.SetLLIsWorking(Me, True)
                Utils.LogUserEvent("Reset Robot Cassettes of LoadLock " & Me.LockName, "TM Screen")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnReset_Click")
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub lblTorr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTorr.Click, pnlRelay.Click, Panel1.Click, lblPressure.Click, btnRelay.Click
        If m_blnEnableDisableForm AndAlso Not IsLLOnline AndAlso m_isAllowActionInForm Then

            Dim eqLL As LoadLock = GetObjLL()
            If Me.Name = LOCKCASSETTEA Then
                If ContainerForm.CassettesPanel.LLACGGaugesFrm IsNot Nothing AndAlso eqLL IsNot Nothing Then

                    ContainerForm.CassettesPanel.LLACGGaugesFrm.IsSetATM = eqLL.IsSafetySetATM
                    ContainerForm.CassettesPanel.LLACGGaugesFrm.IsSetVAC = eqLL.IsSafetySetVAC
                    ContainerForm.CassettesPanel.LLACGGaugesFrm.ShowDialog(AVPRobotMain)
                End If
            End If
        End If
    End Sub

    Private Function GetObjLL() As LoadLock
        Dim eqLL As LoadLock = Nothing
        Dim strEquipmentName As String = Nothing

        If Me.Name = LOCKCASSETTEA Then
            strEquipmentName = AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
        End If

        eqLL = AVPLib.DataManagerment.EquipmentManager.GetEquipment(strEquipmentName)

        Return eqLL
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-16</date>
    ''' </author>
    ''' <summary>
    ''' Update location
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub lblTorr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTorr.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If Me.Text <> "0.00mTorr" Then
                    If Me.AlignStyle = DisplayStyle.Right Then
                        Me.lblPressure.Left = (Me.Width / 2 - Me.lblPressure.Width) + 13
                        Me.lblPressure.TextAlign = ContentAlignment.MiddleRight

                        Me.lblTorr.Left = (Me.Width / 2) + 15
                        Me.lblTorr.TextAlign = ContentAlignment.MiddleLeft
                    Else
                        Me.lblPressure.Left = (Me.Width / 2 - Me.lblPressure.Width)
                        Me.lblPressure.TextAlign = ContentAlignment.MiddleRight

                        Me.lblTorr.Left = (Me.Width / 2) + 4
                        Me.lblTorr.TextAlign = ContentAlignment.MiddleLeft
                    End If
                End If
            End If

            lblTorr.ForeColor = IIf(lblTorr.Text = AVPLib.ConstEnum.STR_ERROR, Color.Red, Color.Lime)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-05-08 </date>
    ''' </author>
    ''' <summary>
    ''' Paint Border for panel
    ''' </summary>
    Private Sub Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint, MyBase.Paint
        Utils.PaintBorder(sender, e)
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-16</date>
    ''' </author>
    ''' <summary>
    ''' DisableForm
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActiveForm(ByVal enable As Boolean)
        Try
            m_blnEnableDisableForm = enable
            Me.lblTorr.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.Panel1.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.lblPressure.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.btnRelay.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.pnlRelay.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
            Me.Panel2.Enabled = enable
            SetActiveForm()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-06</date>
    ''' <summary>
    ''' Update on load.
    ''' </summary>
    Private Sub LockCassetteControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objElevator As LLElevator = Nothing
            If m_strLockName = "A" Then
                objElevator = EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
            ElseIf m_strLockName = "B" Then
                'objElevator = EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLBElevator.ToString())
            End If

            If objElevator IsNot Nothing Then
                IsCassetteHome = (objElevator.CurrentSlot = 0)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
