Imports ZedGraph
Imports System.Text
Imports System.Xml
Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Imports System
Imports System.Globalization
Imports AVPControls

Public Class DiagnosticScreen
    Private m_strdataFile As String = String.Empty
    Private m_ListOfValue As List(Of String) = Nothing
    Private m_Type As DiagnosticType
    Private m_strTitleOfGraph As String
    Private m_strXAxisTitle As String
    Private m_strYAxisTitle As String
    Private m_dtHistory As DataTable
    Private m_rowOfHistory As DataRow
    Private m_strSample As String
    Private m_strFileName As String
    Private m_strDescription As String
    Private m_xmldoc As XmlDocument = Nothing
    Private m_xmlSampleNode As XmlNode = Nothing
    Protected m_marshaller As DelegateMarshaler
    Protected m_marshaller_for_Button As DelegateMarshaler
    Private m_intSampleCount As Integer
    Const INDEX_OF_TIME As Integer = 0
    Const INDEX_OF_DATA As Integer = 1
    Const FILE_PATH As String = "FilePath"
    Const SAMPLE_COUNT As String = "Sample Count"
    Const AT_TIME As String = "At Time"
    Const DESCRIPTION As String = "Description"
    Const MARK_DELETE As String = "MarkDelete"
    Const RESULT As String = "Result (Torr*Litter / Secs.)"
    Const START_BUTTON_TXT As String = "Start"
    Const STOP_BUTTON_TXT As String = "Stop"
    Private m_intCurrentSelRow As Integer = -1
    Private m_blnHasSendStart_CMD As Boolean = False
    Private m_blnStoreFirstPressure As Boolean = False
    Private m_dblFirstPressure As Double = 0
    Private m_dblLastPressure As Double = 0
    Private m_intFirstTime As Double = 0
    Private m_intLastTime As Double = 0
    Private m_dblLitterval As Double = 0
    Private m_dblResult As Double = 0
    Private m_strChamberName As Equipments ''only use Chamber1...5
    Private LoadSample_Worker As ComponentModel.BackgroundWorker = Nothing 'worker for Open File
    Private Delegate Sub UpdateSampleCountToGrid(ByVal obj As Object)
    Private m_ListOfLLStart As New List(Of String)
    Public IsPDC_ROR_Running As Boolean = False
    Private m_strReplace As String = Nothing
    Private m_iStartCounter As Integer = 0
    Private m_iSendStopCounter As Integer = 0
    Private m_isScheduler_Running As Boolean = False
    Private m_isActive As Boolean = False
    Private m_isEnableDeleteDatarun As Boolean = False

#Region "Enum and Property"
    Public Enum DiagnosticType
        PumpDown_Curve
        Rate_Of_Rise
        Recover_Pressure
    End Enum

    Public WriteOnly Property IsScheduler_Running() As Boolean
        Set(ByVal value As Boolean)
            m_isScheduler_Running = value
        End Set
    End Property

    Public Property Active() As Boolean
        Get
            Return m_isActive
        End Get
        Set(ByVal value As Boolean)
            Me.txtDescription.Enabled = value And Not (m_isScheduler_Running)
            Me.txtSampleTime.Enabled = value And Not (m_isScheduler_Running)
            Me.txtTotalTime.Enabled = value And Not (m_isScheduler_Running)
            Me.btnStart.Enabled = value And Not (m_isScheduler_Running)
            m_isActive = value
            Me.btnDelete.Enabled = value And Not (m_isScheduler_Running) And m_isEnableDeleteDatarun
        End Set
    End Property

    Public Property ChamberName() As Equipments
        Get
            Return m_strChamberName
        End Get
        Set(ByVal value As Equipments)
            m_strChamberName = value
        End Set
    End Property

    Public Property TypeOf_DiagnosticScreen() As DiagnosticType
        Get
            Return m_Type
        End Get
        Set(ByVal value As DiagnosticType)
            m_Type = value
            If m_Type = DiagnosticType.PumpDown_Curve Then
                Me.lblTitleHistory.Text = AVPLib.Utils.chamberID2ChamberName(ChamberName.ToString()) & " Pump Down History"
                m_strReplace = "IG="
                txtSampleTime.Text = "5"
                txtTotalTime.Text = "60"
            ElseIf m_Type = DiagnosticType.Rate_Of_Rise Then
                Me.lblTitleHistory.Text = AVPLib.Utils.chamberID2ChamberName(ChamberName.ToString()) & " Rate Of Rise History"
                txtSampleTime.Text = "1"
                txtTotalTime.Text = "5"

                If ChamberName.ToString() = ConstEnum.Equipments.LoadLockA.ToString Then
                    If RobotConfigurationValues.LLA_HIVAC_INSTALLED Then
                        m_strReplace = "IG="
                    Else
                        m_strReplace = "CG="
                    End If
                Else
                    m_strReplace = "IG="
                End If

            Else
                Me.lblTitleHistory.Text = AVPLib.Utils.chamberID2ChamberName(ChamberName.ToString()) & " Recover Pressure History"
                txtSampleTime.Text = "1"
                txtTotalTime.Text = "5"
                m_strReplace = "Pressure="
            End If
        End Set
    End Property

    Public Property TitleOfGraph() As String
        Get
            Return m_strTitleOfGraph
        End Get
        Set(ByVal value As String)
            m_strTitleOfGraph = value
            Me.MainGraph.GraphPane.Title.Text = m_strTitleOfGraph
            Me.zgraphFromFile.GraphPane.Title.Text = m_strTitleOfGraph
        End Set
    End Property

    Public Property X_Axis_Title() As String
        Get
            Return m_strXAxisTitle
        End Get
        Set(ByVal value As String)
            m_strXAxisTitle = value
            Me.MainGraph.GraphPane.XAxis.Title.Text = m_strXAxisTitle
            Me.zgraphFromFile.GraphPane.XAxis.Title.Text = m_strXAxisTitle
        End Set
    End Property

    Public Property Y_Axis_Title() As String
        Get
            Return m_strYAxisTitle
        End Get
        Set(ByVal value As String)
            m_strYAxisTitle = value
        End Set
    End Property

    Public Property Litter_Value() As Double
        Get
            Return m_dblLitterval
        End Get
        Set(ByVal value As Double)
            m_dblLitterval = value
        End Set
    End Property
#End Region

#Region "Protected method"
    Protected Overrides Sub CreateStatusTree()
        m_stoStatusObject.Name = Me.Name
    End Sub
#End Region

    Public Sub Enable_Disable_Start(ByVal blnEnable As Boolean, ByVal LLName As String)
        If blnEnable Then
            If m_ListOfLLStart.Contains(LLName) Then
                m_ListOfLLStart.Remove(LLName)
            End If
            If m_ListOfLLStart.Count = 0 Then ''enable button
                btnStart.Enabled = blnEnable
                txtDescription.Enabled = blnEnable
                txtSampleTime.Enabled = blnEnable
                txtTotalTime.Enabled = blnEnable
            End If
        Else
            If m_ListOfLLStart.Contains(LLName) = False Then
                m_ListOfLLStart.Add(LLName)
            End If 'disable button
            btnStart.Enabled = blnEnable
            txtDescription.Enabled = blnEnable
            txtSampleTime.Enabled = blnEnable
            txtTotalTime.Enabled = blnEnable
        End If
    End Sub

    Private Sub DisableEnable_PDC_ROR(ByVal blnEnable As Boolean)
        Select Case ChamberName
            Case Equipments.Chamber1
                If TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve Then
                    ContainerForm.Diagnostic.dgsRateOfRisePM1.btnStart.Enabled = blnEnable
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise Then
                    ContainerForm.Diagnostic.dgsPumpDownPM1.btnStart.Enabled = blnEnable
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                    ContainerForm.Diagnostic.dgsRecoverPressurePM1.btnStart.Enabled = True
                End If
            Case Equipments.Chamber2
                If TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve Then
                    ContainerForm.Diagnostic.dgsRateOfRisePM2.btnStart.Enabled = blnEnable
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise Then
                    ContainerForm.Diagnostic.dgsPumpDownPM2.btnStart.Enabled = blnEnable
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                    ContainerForm.Diagnostic.dgsRecoverPressurePM2.btnStart.Enabled = True
                End If
            Case Equipments.Chamber3
                If TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve Then
                    ContainerForm.Diagnostic.dgsRateOfRisePM3.btnStart.Enabled = blnEnable
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise Then
                    ContainerForm.Diagnostic.dgsPumpDownPM3.btnStart.Enabled = blnEnable
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                    ContainerForm.Diagnostic.dgsRecoverPressurePM3.btnStart.Enabled = True
                End If
            Case Equipments.LoadLockA
                If TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve Then
                    ContainerForm.Diagnostic.dgsRateOfRiseLLA.btnStart.Enabled = blnEnable
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise Then
                    ContainerForm.Diagnostic.dgsPumpDownLLA.btnStart.Enabled = blnEnable
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                    ContainerForm.Diagnostic.dgsRecoverPressureLLA.btnStart.Enabled = True
                End If
            Case Equipments.CassettesModule
                If TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve Then
                    ContainerForm.Diagnostic.dgsRateOfRiseTM.btnStart.Enabled = blnEnable
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise Then
                    ContainerForm.Diagnostic.dgsPumpDownTM.btnStart.Enabled = blnEnable
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                    ContainerForm.Diagnostic.dgsRecoverPressureTM.btnStart.Enabled = True
                End If
        End Select
    End Sub

    Public Sub Send_Stop_When_App_Exit()
        Me.Stop_ROR_PDC(Me.ChamberName.ToString())
        Me.SaveFilePDC_ROR_RecoverPressure()
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Start Click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Dim strMessageText As String = String.Empty
        Dim button As Button = CType(sender, Button)
        Try
            Dim strChamber As String = Me.ChamberName.ToString()

            Dim EQName As String = AVPLib.Utils.chamberID2ChamberName(strChamber)
            EQName = IIf(EQName = LoadLockA_STR, LLA_STR, EQName)

            If (txtSampleTime.Text = "" Or txtTotalTime.Text = "") Then
                Utils.ShowAVPMessageBox("Invalid input", EQName, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                  "[Main Screen] " + "Diagnostic: Invalid input when click start button.")
                Exit Sub
            End If
            If (txtDescription.Text.Trim().Length = 0) Then
                Utils.ShowAVPMessageBox("Please enter description", EQName, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                 "[Main Screen] " + "Diagnostic: No description when click start button.")
                Exit Sub
            Else
                m_strDescription = txtDescription.Text.Trim()
            End If
            'Get message text to show Messagebox
            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText( _
                               PVD + ".DiagnosticScreen." + button.Name + "." + button.Text.Trim()), TypeOf_DiagnosticScreen.ToString())

            If (Utils.ShowAVPMessageBox(strMessageText, EQName, MessageBoxIcon.Question) = DialogResult.OK) Then
                If btnStart.Text.Trim() = START_BUTTON_TXT Then 'Start Click
                    'check Slit valve Closed
                    Dim IsPMIsoValveClose As Boolean = True
                    If strChamber.StartsWith(ConstantAndEnum.CHAMBER) Then
                        IsPMIsoValveClose = AVPLib.Utils.IsChamberSlitValveClose(strChamber)
                    ElseIf strChamber.StartsWith(LoadLock) Then
                        If TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise Then
                            'check LL Hivac not Present
                            If Not AVPLib.Utils.CheckLLHivacNotPresent() Then
                                Utils.ShowAVPMessageBox(CAN_NOT_RUN_ROR_DUE_TO_HIVAC_NOT_PRESENT, EQName,
                                                        MessageBoxIcon.Stop, AVPMessageBox.AVPMessageBoxButton.OK)
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                          AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                          "[Main Screen] Diagnostic:" + CAN_NOT_RUN_ROR_DUE_TO_HIVAC_NOT_PRESENT)
                                Exit Sub
                            End If
                        End If

                        IsPMIsoValveClose = AVPLib.Utils.IsLLSlitValveClose(strChamber)
                    Else ''TM
                        If TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise Then
                            'check TM Hivac not Present
                            If Not AVPLib.Utils.CheckTMHivacNotPresent() Then
                                Utils.ShowAVPMessageBox(CAN_NOT_RUN_ROR_DUE_TO_HIVAC_NOT_PRESENT, EQName,
                                                        MessageBoxIcon.Stop, AVPMessageBox.AVPMessageBoxButton.OK)
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                          AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                          "[Main Screen] Diagnostic:" + CAN_NOT_RUN_ROR_DUE_TO_HIVAC_NOT_PRESENT)
                                Exit Sub
                            End If
                        End If

                        IsPMIsoValveClose = AVPLib.Utils.CheckAllSplitValvesClosed()
                    End If

                    If Not IsPMIsoValveClose Then
                        Utils.ShowAVPMessageBox("Slit Valve is not close", AVPLib.Utils.chamberName2ChamberID(strChamber),
                            MessageBoxIcon.Stop, AVPMessageBox.AVPMessageBoxButton.OK)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                      "[Main Screen] " + "Diagnostic: Slit Valve is not close when click start button.")
                        Exit Sub
                    End If

                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                           "[" + AVPLib.Utils.chamberID2ChamberName(strChamber) + "] Start Collecting Diagnostic Data")
                    m_intSampleCount = 0
                        m_dblResult = 0
                        m_dblFirstPressure = 0
                        m_dblLastPressure = 0
                        m_intLastTime = 0
                        m_intFirstTime = 0
                        m_blnStoreFirstPressure = False
                        ''check connection and send command
                        If Check_ConnectionStatus(strChamber) Then
                            ''initialize database
                            m_rowOfHistory = m_dtHistory.NewRow
                            m_rowOfHistory(DESCRIPTION) = txtDescription.Text.Trim()
                            m_rowOfHistory(AT_TIME) = Now
                            m_rowOfHistory(SAMPLE_COUNT) = m_intSampleCount
                            m_rowOfHistory(RESULT) = Format(Double.Parse(m_dblResult), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                            m_rowOfHistory(FILE_PATH) = Nothing
                            m_dtHistory.Rows.InsertAt(m_rowOfHistory, 0)
                            'm_dtHistory.AcceptChanges()
                            Me.dgvHistory.Columns(FILE_PATH).Visible = False
                            Me.dgvHistory.Rows(0).Selected = True

                            Me.dgvHistory.Refresh()
                            Me.MainGraph.Visible = True
                            Me.MainGraph.BringToFront()
                            If Me.MainGraph.GraphPane.CurveList.Count > 0 Then
                                Me.MainGraph.GraphPane.CurveList(m_strYAxisTitle).Clear()
                            End If
                            Me.TitleOfGraph = TypeOf_DiagnosticScreen.ToString() & " run at: " & DateTime.Now.ToString("MM/dd/yy HH:mm:ss")
                            ''send and get data 
                            If Start_ROR_PDC(strChamber) Then
                                m_blnHasSendStart_CMD = True
                                txtDescription.Enabled = False
                                txtSampleTime.Enabled = False
                                txtTotalTime.Enabled = False
                                btnStart.Text = STOP_BUTTON_TXT
                                IsPDC_ROR_Running = True
                                btnStart.Image = AVP_Robot_Project.My.Resources.Resources.player_end
                                Me.DisableEnable_PDC_ROR(False)
                                Me.EnableDisableStartButton(False)
                                lblStatus.Text = "Collecting data sample...."
                            End If
                            m_iSendStopCounter = 0
                        End If
                    ElseIf btnStart.Text = STOP_BUTTON_TXT Then ''Stop Click
                        Me.Stop_ROR_PDC(strChamber)
                    m_iSendStopCounter = 1
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                       "[" + AVPLib.Utils.chamberID2ChamberName(strChamber) + "] Stop Collecting Diagnostic Data")
                    txtDescription.Enabled = True
                    txtSampleTime.Enabled = True
                    txtTotalTime.Enabled = True
                    lblStatus.Text = "Data collection is done."
                    btnStart.Image = AVP_Robot_Project.My.Resources.Resources.player_play
                    btnStart.Text = START_BUTTON_TXT
                    IsPDC_ROR_Running = False
                    CleanUpGrid()
                    Me.DisableEnable_PDC_ROR(True)
                    Me.EnableDisableStartButton(False)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function Start_ROR_PDC(ByVal strChamberName As String) As Boolean
        Dim strStartSequence As String = String.Empty
        Const START_PDC As String = "Start Pump Down Curve"
        Const START_ROR As String = "Start Rate Of Rise"
        Const START_RECPRESS As String = "Start Recover Pressure"
        Dim objController As Business.ControllerObject = Nothing
        Dim intSampleTime As Integer = 0
        Dim intTotalTime As Integer = 0
        Dim strDescription As String = txtDescription.Text
        Try
            Integer.TryParse(Trim(txtSampleTime.Text), intSampleTime)
            Integer.TryParse(Trim(txtTotalTime.Text), intTotalTime)
            With m_stoStatusObject
                objController = Business.ControllerManager.GetController(strChamberName)
                If objController Is Nothing Then
                    AVPLib.Log.avpLogger.Error("Error! Can not get Objectc Controller ")
                    Return False
                End If
                strStartSequence = "[" & AVPLib.Utils.chamberID2ChamberName(strChamberName) & "] "
                If strChamberName.StartsWith(LoadLock) Then
                    If TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                        With CType(objController, Business.LoadLockController).CurrentRecoverPressureRoutineExecutor
                            .SampleTime = intSampleTime
                            .WaitTime = intTotalTime
                            .Description = strDescription
                        End With
                    Else
                        With CType(objController, Business.LoadLockController).CurrentRoutineExecutor
                            .SampleTime = intSampleTime
                            .WaitTime = intTotalTime
                            .Description = strDescription
                        End With
                    End If
                    
                ElseIf strChamberName.StartsWith(Equipments.CassettesModule.ToString()) Then
                    strStartSequence = "[" & TM_STR & "] "
                    If TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                        With CType(objController, Business.TMController).CurrentRecoverPressureRoutineExecutor
                            .SampleTime = intSampleTime
                            .WaitTime = intTotalTime
                            .Description = strDescription
                        End With
                    Else
                        With CType(objController, Business.TMController).CurrentRoutineExecutor
                            .SampleTime = intSampleTime
                            .WaitTime = intTotalTime
                            .Description = strDescription
                        End With
                    End If

                ElseIf strChamberName.StartsWith(ConstantAndEnum.CHAMBER) Then
                    If TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then ''
                        With CType(objController, Business.ChamberController).CurrentRoutineExecutor
                            .SampleTime = intSampleTime
                            .WaitTime = intTotalTime
                            .Description = strDescription
                        End With
                    Else
                        With CType(objController, Business.ChamberController)
                            .PDC_ROR_SampleTime = intSampleTime
                            .PDC_ROR_WaitTime = intTotalTime
                            .PDC_ROR_Description = strDescription
                        End With
                    End If
                End If

                Select Case TypeOf_DiagnosticScreen
                    Case DiagnosticType.PumpDown_Curve
                        strStartSequence = strStartSequence & START_PDC
                        .RequestStatus(ConstEnum.STR_PUMP_DOWN_CURVE, String.Empty)
                    Case DiagnosticType.Rate_Of_Rise
                        strStartSequence = strStartSequence & START_ROR
                        .RequestStatus(ConstEnum.STR_RATE_OF_RISE, String.Empty)
                    Case DiagnosticType.Recover_Pressure
                        strStartSequence = strStartSequence & START_RECPRESS
                        .RequestStatus(ConstEnum.STR_RECOVER_PRESSURE, String.Empty)
                End Select

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen, strStartSequence)
                Return True
            End With
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    Private Function Stop_ROR_PDC(ByVal strChamberName As String) As Boolean
        Try
            Dim strStopSequence As String = String.Empty
            Const STOP_PDC As String = "Stop Pump Down Curve"
            Const STOP_ROR As String = "Stop Rate Of Rise"
            Const STOP_RECPRESS As String = "Stop Recover Pressure"

            If m_iSendStopCounter > 1 Then
                m_iSendStopCounter = 0
            End If
            With m_stoStatusObject
                Dim objController As Business.ControllerObject = Nothing
                If strChamberName.StartsWith(LoadLock) Then 'LL
                    objController = Business.ControllerManager.GetController(strChamberName)
                    If objController Is Nothing Then
                        AVPLib.Log.avpLogger.Error("Error! Can not get Object Controller " & strChamberName)
                        Exit Function
                    End If

                ElseIf strChamberName.StartsWith(Equipments.CassettesModule.ToString()) Then 'TM
                    objController = Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString())
                    If objController Is Nothing Then
                        AVPLib.Log.avpLogger.Error("Error! Can not get Object Controller " & strChamberName)
                        Exit Function
                    End If
                End If

                Select Case TypeOf_DiagnosticScreen
                    Case DiagnosticType.PumpDown_Curve
                        strStopSequence = STOP_PDC
                        .RequestStatus(ConstEnum.STR_STOP_PUMP_DOWN_CURVE, String.Empty)

                    Case DiagnosticType.Rate_Of_Rise
                        strStopSequence = STOP_ROR
                        .RequestStatus(ConstEnum.STR_STOP_RATE_OF_RISE, String.Empty)
                        If (strChamberName.StartsWith(ConstEnum.LoadLockA_STR)) Then
                            ContainerForm.CassettesPanel.PopUpPanel.LLAAutoPumpdown()
                        ElseIf strChamberName.StartsWith(Equipments.CassettesModule.ToString()) Then
                            ContainerForm.CassettesPanel.PopUpPanel.TMAutoPumdown()
                        End If

                    Case DiagnosticType.Recover_Pressure
                        strStopSequence = STOP_RECPRESS
                        .RequestStatus(ConstEnum.STR_STOP_RECOVER_PRESSURE, String.Empty)
                End Select
                m_iSendStopCounter += 1
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                  "[" & AVPLib.Utils.chamberID2ChamberName(strChamberName) & "] " & strStopSequence)
            End With
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    Private Sub CleanUpGrid()
        Try
            For i As Integer = 0 To Me.dgvHistory.RowCount - 2
                Dim row As DataGridViewRow = Me.dgvHistory.Rows(i)
                ''check all sample count is 0 and file doesn't exist
                If CInt(row.Cells(SAMPLE_COUNT).Value) = 0 Then
                    If DBNull.Value.Equals(row.Cells(FILE_PATH).Value) Then
                        Me.dgvHistory.Rows.RemoveAt(i)
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Check the connection Status of equipment
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckConnectionStatus(ByVal strChamberName As String) As Boolean
        Try
            Dim stConnectStatus As DisplayStatus = DisplayStatus.Off
            Select Case strChamberName
                Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                    stConnectStatus = (ContainerForm.Chamber1Panel.btnReConnect.Status)
                Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                    stConnectStatus = (ContainerForm.Chamber2Panel.btnReConnect.Status)
                Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                    stConnectStatus = (ContainerForm.Chamber3Panel.btnReConnect.Status)
                Case AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
                    Dim objLL As AVPLib.DataManagerment.LLElevator = _
                                   (AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString()))
                    If objLL Is Nothing Then
                        Return False
                    End If
                    Return objLL.IsCommunicating
                Case AVPLib.ConstEnum.Equipments.CassettesModule.ToString()
                    Dim objRobot As AVPLib.DataManagerment.Robot = _
                                   (AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString()))
                    If objRobot Is Nothing Then
                        Return False
                    End If
                    Return objRobot.IsCommunicating
            End Select
            If Not (stConnectStatus = DisplayStatus.On) Then
                lblStatus.Text = "Chamber is disconnect..."
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Check connection and send command to PVD
    ''' </summary>
    ''' <remarks></remarks>
    Private Function Check_ConnectionStatus(ByVal strChamberName As String) As Boolean
        Dim blnConnectStatus As Boolean = CheckConnectionStatus(strChamberName)
        Try
            If blnConnectStatus = False Then
                btnStart.Text = START_BUTTON_TXT
                IsPDC_ROR_Running = False
                btnStart.Image = AVP_Robot_Project.My.Resources.Resources.player_play
                CleanUpGrid()
                lblStatus.Text = "Equipment is disconnected"
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blnConnectStatus
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Init DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Private Function InitializeGrid() As DataTable
        Try
            m_dtHistory = New DataTable("History Table")
            ' Add columns to the table.
            m_dtHistory.Columns.Add(DESCRIPTION, GetType([String]))
            m_dtHistory.Columns.Add(AT_TIME, GetType([DateTime]))
            m_dtHistory.Columns.Add(SAMPLE_COUNT, GetType([String]))
            m_dtHistory.Columns.Add(RESULT, GetType([String]))
            m_dtHistory.Columns.Add(FILE_PATH, GetType([String]))
            m_dtHistory.Columns.Add(MARK_DELETE, GetType([Boolean]))

            If DesignMode = False Then
                ''Load all file in folder
                Dim arrFile As ArrayList = Nothing
                Dim indexOfChamber As String = Me.Name.Substring(Me.Name.Length() - 1)
                Dim ChamberName As String = Me.ChamberName.ToString()
                If Me.ChamberName = Equipments.CassettesModule Then
                    ChamberName = TM_STR
                ElseIf Me.ChamberName = Equipments.LoadLockA Then
                    ChamberName = LLA_STR
                End If
                Dim strFolder As String = String.Empty
                If TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve Then
                    strFolder = AVPLib.ContainerDAO.FPath_GraphData_PDC & "\" & ChamberName
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise Then
                    strFolder = AVPLib.ContainerDAO.FPath_GraphData_RateOfRise & "\" & ChamberName
                ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                    strFolder = AVPLib.ContainerDAO.FPath_GraphData_RecoverPressure & "\" & ChamberName
                End If
                ''array of file name
                arrFile = AVPLib.Utils.GetAllGraphFiles(strFolder)
                If arrFile IsNot Nothing AndAlso arrFile.Count > 0 Then
                    For Each filename As String In arrFile
                        If System.IO.File.Exists(strFolder & "\" & filename) Then
                            Dim xmldoc As New XmlDocument
                            Try
                                xmldoc.Load(strFolder & "\" & filename)
                                Dim descNode As XmlNode = xmldoc.SelectSingleNode("/" & TypeOf_DiagnosticScreen.ToString() & "/Description")
                                Dim startNode As XmlNode = xmldoc.SelectSingleNode("/" & TypeOf_DiagnosticScreen.ToString() & "/Start")
                                Dim resultNode As XmlNode = xmldoc.SelectSingleNode("/" & TypeOf_DiagnosticScreen.ToString() & "/Result")
                                Dim sampleNode As XmlNode = xmldoc.SelectSingleNode("/" & TypeOf_DiagnosticScreen.ToString() & "/SampleList")
                                m_rowOfHistory = m_dtHistory.NewRow
                                m_rowOfHistory(DESCRIPTION) = IIf(descNode Is Nothing, String.Empty, descNode.InnerText)
                                m_rowOfHistory(AT_TIME) = CType(startNode.InnerText, DateTime)
                                m_rowOfHistory(SAMPLE_COUNT) = sampleNode.ChildNodes.Count
                                m_rowOfHistory(RESULT) = resultNode.InnerText
                                m_rowOfHistory(FILE_PATH) = strFolder & "\" & filename
                                m_dtHistory.Rows.Add(m_rowOfHistory)
                            Catch ex As Exception
                                AVPLib.Log.avpLogger.Error("AVP can't load data from " & strFolder & "\" & filename)
                            End Try
                        End If
                    Next
                End If
                m_dtHistory.DefaultView.Sort = AT_TIME & " DESC"
                Me.dgvHistory.DataSource = m_dtHistory
                Me.dgvHistory.Columns(FILE_PATH).Visible = False
                Me.dgvHistory.Columns(AT_TIME).DefaultCellStyle.Format = "MM/dd/yy HH:mm:ss"
                If Me.TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve OrElse Me.TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                    Me.dgvHistory.Columns(RESULT).Visible = False
                End If
                Me.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                Me.dgvHistory.Columns(RESULT).Width = 230
                If Me.Name.Contains("RateOfRise") Then
                    Me.dgvHistory.Columns(AT_TIME).Width = 180
                End If
                Me.dgvHistory.Refresh()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return m_dtHistory
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' DiagnosticScreen Load
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DiagnosticScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            m_dtHistory = InitializeGrid()
            Me.lbStatus.Text = ""
            Me.dgvHistory.DataSource = m_dtHistory
            Me.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            Dim indexOfColMarkDelete As Integer = Me.dgvHistory.Columns(MARK_DELETE).Index
            Me.dgvHistory.Columns(indexOfColMarkDelete).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.dgvHistory.Columns(indexOfColMarkDelete).Width = 70

            Dim myCurve As LineItem
            Dim list As New PointPairList
            myCurve = Me.MainGraph.GraphPane.AddCurve(m_strYAxisTitle, list, Color.Red, SymbolType.Diamond)
            ' Fill the symbols with white
            myCurve.Symbol.Fill = New Fill(Color.White)
            Me.MainGraph.GraphPane.YAxis.Title.Text = ""
            Me.MainGraph.GraphPane.YAxis.Type = AxisType.Log
            Me.MainGraph.GraphPane.YAxis.Scale.Min = 0.0000001
            Me.MainGraph.GraphPane.XAxis.Scale.MagAuto = False
            Me.zgraphFromFile.GraphPane.XAxis.Scale.MagAuto = False
            Me.zgraphFromFile.GraphPane.YAxis.Type = AxisType.Log
            Me.zgraphFromFile.GraphPane.YAxis.Scale.Min = 0.0000001
            Me.zgraphFromFile.GraphPane.YAxis.Title.Text = Me.MainGraph.GraphPane.YAxis.Title.Text
            m_marshaller = DelegateMarshaler.Create()
            m_marshaller_for_Button = DelegateMarshaler.Create()

            LoadSample_Worker = New ComponentModel.BackgroundWorker()
            LoadSample_Worker.WorkerReportsProgress = True
            LoadSample_Worker.WorkerSupportsCancellation = True

            AddHandler LoadSample_Worker.DoWork, New ComponentModel.DoWorkEventHandler(AddressOf OnWork)
            AddHandler LoadSample_Worker.RunWorkerCompleted, New ComponentModel.RunWorkerCompletedEventHandler(AddressOf Worker_RunWorkerCompleted)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub StopCollectDataFromPM()
        Try
            With m_stoStatusObject
                Select Case TypeOf_DiagnosticScreen
                    Case DiagnosticType.PumpDown_Curve
                        .RequestStatus(ConstEnum.STR_STOP_PUMP_DOWN_CURVE, String.Empty)
                    Case DiagnosticType.Rate_Of_Rise
                        .RequestStatus(ConstEnum.STR_STOP_RATE_OF_RISE, String.Empty)
                    Case DiagnosticType.Recover_Pressure
                        .RequestStatus(ConstEnum.STR_STOP_RECOVER_PRESSURE, String.Empty)
                End Select
            End With
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Get Data from PVD -> Save to file and draw graph
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetDataFromPM(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strTime As String = String.Empty
        Dim strData As String = String.Empty
        Try

            ''Save file to Data\Graph
            Dim data As String = sender.ToString()
            If (data.Contains("RemainingTime=")) Then
                data = data.Substring(data.IndexOf("#") + 1)
            End If

            Dim arrData As String() = Split(data, "#")
            If arrData.Length > 1 Then
                strTime = arrData(INDEX_OF_TIME)
                strData = arrData(INDEX_OF_DATA)
                If m_blnStoreFirstPressure = False Then
                    If strData.Contains(m_strReplace) Then
                        strData = strData.Replace(m_strReplace, "")
                        strTime = strTime.Replace("Time=", "")
                    End If
                    Double.TryParse(strData, m_dblFirstPressure)
                    Double.TryParse(strTime, m_intFirstTime)
                    m_blnStoreFirstPressure = True
                End If

                If strData.Contains(m_strReplace) Then
                    strData = strData.Replace(m_strReplace, "")
                    strTime = strTime.Replace("Time=", "")
                End If
                Double.TryParse(strData, m_dblLastPressure)
                Double.TryParse(strTime, m_intLastTime)

            End If
            '''get file name 
            GetSampleNode()
            If m_xmlSampleNode Is Nothing Then
                AVPLib.Log.avpLogger.Error("PDC/ROR/Recover Pressure status was not updated -> Can't not write data graph to file...with " & Me.ChamberName.ToString())
                Exit Sub
            End If
            '//write data to xml
            Dim sampleNode As XmlNode = m_xmldoc.CreateElement("Sample")
            Dim timeNode As XmlNode = m_xmldoc.CreateElement("Time")
            Dim totalPressure As Double = m_dblLastPressure - m_dblFirstPressure
            Dim totalTime As Double = m_intLastTime - m_intFirstTime

            timeNode.InnerText = strTime
            sampleNode.AppendChild(timeNode)
            Dim igNode As XmlNode = m_xmldoc.CreateElement(IIf(Me.TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure, "IG_CG_Pressure", "Pressure"))

            'Should only contain <Time>5 </Time> and
            '<Ion_Gauge_Pressure>.0027400000 </Ion_Gauge_Pressure>
            '** This will help import data better via excel.
            igNode.InnerText = strData.Replace(m_strReplace, "")

            sampleNode.AppendChild(igNode)
            m_xmlSampleNode.AppendChild(sampleNode) ''samplelist node append sample node
            ''update DataTable
            m_intSampleCount += 1
            If totalTime = 0 Then
                m_dblResult = 0
            Else
                m_dblResult = ((totalPressure) * Litter_Value) / (totalTime)
            End If
            Try
                If Not (m_xmldoc Is Nothing Or m_strFileName = "") Then
                    Dim resultNode As XmlNode = m_xmldoc.SelectSingleNode("/" & TypeOf_DiagnosticScreen.ToString() & "/Result")
                    resultNode.InnerText = Format(Double.Parse(m_dblResult), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                    If m_intSampleCount Mod 20 = 0 Then
                        m_xmldoc.Save(m_strFileName) ''close file
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error("Error saving file in PDC/ROR/RecoverPressure: " & Me.ChamberName.ToString() & "-" & m_strFileName & " ex:" & ex.ToString())
            End Try

            m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateGraphWithRefresh), sender)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub SaveFilePDC_ROR_RecoverPressure(Optional ByVal numberRecord As Integer = 1)
        Try
            If Not (m_xmldoc Is Nothing Or m_strFileName = "") Then
                Dim resultNode As XmlNode = m_xmldoc.SelectSingleNode("/" & TypeOf_DiagnosticScreen.ToString() & "/Result")
                resultNode.InnerText = Format(Double.Parse(m_dblResult), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                If m_intSampleCount Mod numberRecord = 0 Then
                    m_xmldoc.Save(m_strFileName) ''close file
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("Error saving file in PDC/ROR/RecoverPressure: " & Me.ChamberName.ToString() & "-" & m_strFileName & " ex:" & ex.ToString())
        End Try
    End Sub

    Private Sub GetSampleNode()

        Dim ChamberObj As AVPLib.DataManagerment.Equipment = _
                      AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.ChamberName.ToString())
        Dim strFolderName As String = String.Empty

        If ChamberObj.Name.StartsWith(Equipments.CassettesModule.ToString()) Then
            strFolderName = TM_STR
        ElseIf ChamberObj.Name.StartsWith(Equipments.LoadLockA.ToString()) Then
            strFolderName = LLA_STR
        Else
            strFolderName = ChamberName.ToString()
        End If
        If Me.TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure AndAlso ChamberObj.Recover_Pressure_Status = DataManagerment.Equipment.WorkingStatuses.On Then
            m_strFileName = AVPLib.ContainerDAO.FPath_GraphData_RecoverPressure & "\" & strFolderName & "\" & ChamberObj.Recover_Pressure_FileName
            m_xmlSampleNode = AVPLib.Utils.StoreFile(m_xmldoc, m_strFileName, _
                                              TypeOf_DiagnosticScreen.ToString(), m_strDescription)
        End If

        If Me.TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve AndAlso ChamberObj.PumpDown_Curve_Status = DataManagerment.Equipment.WorkingStatuses.On Then
            m_strFileName = AVPLib.ContainerDAO.FPath_GraphData_PDC & "\" & strFolderName & "\" & ChamberObj.PumpDown_Curve_FileName
            m_xmlSampleNode = AVPLib.Utils.StoreFile(m_xmldoc, m_strFileName, _
                                              TypeOf_DiagnosticScreen.ToString(), m_strDescription)

        ElseIf Me.TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise AndAlso ChamberObj.RateOfRise_Status = DataManagerment.Equipment.WorkingStatuses.On Then
            m_strFileName = AVPLib.ContainerDAO.FPath_GraphData_RateOfRise & "\" & strFolderName & "\" & ChamberObj.RateOfRise_FileName
            m_xmlSampleNode = AVPLib.Utils.StoreFile(m_xmldoc, m_strFileName, _
                                              TypeOf_DiagnosticScreen.ToString(), m_strDescription)
        Else
            'something wrong
        End If
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' End Get Data: when PVD send command Stop or Disconnect
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndGetDataFromPM(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If (sender.ToString().Contains("PumpDown_Curve_Status") And Me.TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve) _
            OrElse (sender.ToString().Contains("RateOfRise_Status") And Me.TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise) _
            OrElse (sender.ToString().Contains("Recover_Pressure_Status") And Me.TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure) Then
                If Not (m_xmldoc Is Nothing Or m_strFileName = "") Then
                    Dim resultNode As XmlNode = m_xmldoc.SelectSingleNode("/" & TypeOf_DiagnosticScreen.ToString() & "/Result")
                    resultNode.InnerText = Format(Double.Parse(m_dblResult), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                    m_xmldoc.Save(m_strFileName) ''close file
                    Utils.ExportToCSVFile(m_xmldoc, m_strFileName)
                End If

                ''when PVD reconnect to AVP, PVD send Stop command to AVP 
                If m_blnHasSendStart_CMD Then
                    Dim blnDontWaitStartCounter As Boolean = False
                    If Me.ChamberName = Equipments.CassettesModule OrElse Me.ChamberName = Equipments.LoadLockA _
                    OrElse Me.TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                        blnDontWaitStartCounter = True
                    End If
                    'need delete these line when all pm support request data changed
                    If Not blnDontWaitStartCounter AndAlso AVPLib.RobotConfigurationValues.SUPPORT_REQUEST_ALL_DATA_CHANGED Then
                        'if some PM support request data changed but others are not
                        Dim objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.ChamberName.ToString())
                        If objChamber IsNot Nothing Then
                            With objChamber
                                If (.EquipmentType = SystemModule.ModuleType.IBE AndAlso RobotConfigurationValues.SUPPORT_IBE_UPDATE_WHEN_DATA_CHANGED) OrElse _
                                (.EquipmentType = SystemModule.ModuleType.PVD4 AndAlso RobotConfigurationValues.SUPPORT_CORONA_UPDATE_WHEN_DATA_CHANGED) OrElse _
                                (.EquipmentType = SystemModule.ModuleType.PVD AndAlso RobotConfigurationValues.SUPPORT_PVD_UPDATE_WHEN_DATA_CHANGED) Then
                                    blnDontWaitStartCounter = True
                                End If
                            End With
                        End If
                    End If
                    '
                    m_iStartCounter += 1 ''wait for PM
                    If m_iStartCounter >= 5 Then
                        m_iStartCounter = 0
                        ''Update GUI
                        m_marshaller_for_Button.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateButtonText), STOP_BUTTON_TXT)
                    ElseIf blnDontWaitStartCounter Then
                        m_iStartCounter = 0
                        m_marshaller_for_Button.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateButtonText), STOP_BUTTON_TXT)
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub StartCollectDataFromPM(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If (sender.ToString().Contains("PumpDown_Curve_Status") And Me.TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve) _
                       OrElse (sender.ToString().Contains("RateOfRise_Status") And Me.TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise) _
                       OrElse (sender.ToString().Contains("Recover_Pressure_Status") And Me.TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure) Then
                m_iStartCounter = 0
                If m_blnHasSendStart_CMD Then
                    ''Update GUI
                    m_marshaller_for_Button.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateButtonText), START_BUTTON_TXT)

                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-02-18</date>
    ''' </author>
    ''' <summary>
    ''' EnableDisableStartButton
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub EnableDisableStartButton(ByVal blnEnable As Boolean)
        Try
            Select Case ChamberName
                Case Equipments.Chamber1
                    If TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve Then
                        ContainerForm.Diagnostic.dgsPumpDownPM1.btnStart.Enabled = blnEnable
                    ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise Then
                        ContainerForm.Diagnostic.dgsRateOfRisePM1.btnStart.Enabled = blnEnable
                    ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                        ContainerForm.Diagnostic.dgsRecoverPressurePM1.btnStart.Enabled = True
                    End If
                Case Equipments.Chamber2
                    If TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve Then
                        ContainerForm.Diagnostic.dgsPumpDownPM2.btnStart.Enabled = blnEnable
                    ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise Then
                        ContainerForm.Diagnostic.dgsRateOfRisePM2.btnStart.Enabled = blnEnable
                    ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                        ContainerForm.Diagnostic.dgsRecoverPressurePM2.btnStart.Enabled = True
                    End If
                Case Equipments.Chamber3
                    If TypeOf_DiagnosticScreen = DiagnosticType.PumpDown_Curve Then
                        ContainerForm.Diagnostic.dgsPumpDownPM3.btnStart.Enabled = blnEnable
                    ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Rate_Of_Rise Then
                        ContainerForm.Diagnostic.dgsRateOfRisePM3.btnStart.Enabled = blnEnable
                    ElseIf TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure Then
                        ContainerForm.Diagnostic.dgsRecoverPressurePM3.btnStart.Enabled = True
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Update Graph GUI
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateButtonText(ByVal arg As Object)
        Try
            Me.EnableDisableStartButton(True)
            Dim Value As String = arg.ToString() ''value is always: Stop
            If Value = STOP_BUTTON_TXT Then 'PM send stop
                btnStart.Text = START_BUTTON_TXT ''->change to Start
                IsPDC_ROR_Running = False
                btnStart.Image = AVP_Robot_Project.My.Resources.Resources.player_play
                CleanUpGrid()
                Me.DisableEnable_PDC_ROR(True)
                txtDescription.Enabled = True
                txtSampleTime.Enabled = True
                txtTotalTime.Enabled = True
                lblStatus.Text = "Data collection is done."
                m_blnHasSendStart_CMD = False ''restore flag to default value, AVP don't send start command to PVD
            ElseIf Value = START_BUTTON_TXT Then 'pm send start
                btnStart.Text = STOP_BUTTON_TXT ''->change to Start
                IsPDC_ROR_Running = True
                btnStart.Image = AVP_Robot_Project.My.Resources.Resources.player_end
                Me.DisableEnable_PDC_ROR(False)
                txtDescription.Enabled = False
                txtSampleTime.Enabled = False
                txtTotalTime.Enabled = False
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
    ''' Update Graph GUI
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function UpdateGraph(ByVal arg As Object) As ZedGraphControl
        Try
            Dim graphControl As ZedGraphControl = Nothing
            If m_ListOfValue IsNot Nothing AndAlso m_ListOfValue.Count >= 0 Then ''DRAW FROM FILE
                graphControl = zgraphFromFile
                graphControl.GraphPane.CurveList(m_strYAxisTitle).Clear()
                graphControl.BringToFront()
                graphControl.Refresh()
                Dim i As Integer = 0
                For Each item As String In m_ListOfValue
                    i += 1
                    DrawGraphWithValue(item, graphControl)
                Next
                graphControl.AxisChange()
                lbStatus.Text = ""
                m_ListOfValue = Nothing
            ElseIf m_ListOfValue Is Nothing Then 'DRAW FROM PVD
                m_rowOfHistory(SAMPLE_COUNT) = m_intSampleCount
                m_rowOfHistory(RESULT) = Format(Double.Parse(m_dblResult), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                If (m_rowOfHistory(FILE_PATH).ToString() = Nothing) Then
                    m_rowOfHistory(FILE_PATH) = m_strFileName
                End If
                m_dtHistory.AcceptChanges()
                Me.dgvHistory.Rows(0).Selected = True
                graphControl = MainGraph
                graphControl.BringToFront()
                '0008781: [KhoiHa - 12/02/2015] PDC/ROR. Add remaining time so that user know how much time is remaining.
                Dim data As String = arg.ToString()
                Dim remainingTimeInSecs As Integer
                If data.Contains("RemainingTime=") Then
                    data = data.Replace("RemainingTime=", "")
                    Integer.TryParse(data.Substring(0, data.IndexOf("#")), remainingTimeInSecs)

                    If remainingTimeInSecs < 0 Then
                        remainingTimeInSecs = 0
                    End If

                    Dim remainingTimeMinutes As Integer = Math.Floor(remainingTimeInSecs / 60)
                    remainingTimeInSecs = remainingTimeInSecs - remainingTimeMinutes * 60

                    txtRemainingTime.Text = remainingTimeMinutes.ToString("D2") & ":" & remainingTimeInSecs.ToString("D2")
                    data = data.Substring(data.IndexOf("#") + 1)
                End If
                'End -----------------------------------------------------------------------------------------------------
                DrawGraphWithValue(data, graphControl)
                graphControl.AxisChange()
            End If
            If graphControl IsNot Nothing Then
                graphControl.AxisChange()
                graphControl.IsShowPointValues = True
            End If
            Return graphControl
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    Private Sub DrawGraphWithValue(ByVal dataValue As String, ByRef GraphControl As ZedGraphControl)
        Dim strTime As String = String.Empty
        Dim strData As String = String.Empty

        Dim arrData As String()
        arrData = Split(dataValue, "#")
        If arrData.Length > 1 Then
            strTime = arrData(INDEX_OF_TIME).Replace("Time=", "")
            strData = arrData(INDEX_OF_DATA).Replace(m_strReplace, "")
        End If
        If GraphControl.GraphPane.CurveList.Count = 0 Then
            AVPLib.Log.avpLogger.Error("Can't not create Graph from Data: " & dataValue.ToString())
            Exit Sub
        End If
        Dim ip As IPointListEdit = GraphControl.GraphPane.CurveList(m_strYAxisTitle).Points
        Dim x As Double, y As Double
        x = CDbl(strTime)
        y = CDbl(strData)
        ip.Add(x, y)
        toolhint.ToolTipTitle = String.Format("Point [{0},{1}]", x, y)

    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-03-17</date>
    ''' </author>
    ''' <summary>
    ''' Update Graph GUI
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateGraphWithRefresh(ByVal arg As Object)
        Dim graphControl As ZedGraphControl = Nothing
        graphControl = UpdateGraph(arg)
        If graphControl IsNot Nothing Then
            graphControl.Refresh()
        End If
    End Sub

    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-03-17</date>
    ''' </author>
    ''' <summary>
    ''' Update Graph GUI
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub UpdateGraphWithoutRefresh(ByVal arg As Object)
        Dim graphControl As ZedGraphControl = Nothing
        graphControl = UpdateGraph(arg)
    End Sub

    Private Sub OnWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        If Me.LoadSample_Worker.CancellationPending Or String.IsNullOrEmpty(m_strdataFile) Then
            e.Cancel = True
            Return
        End If
        ' Do not access the form's BackgroundWorker reference directly.
        ' Instead, use the reference provided by the sender parameter.
        LoadDataFile(m_strdataFile, m_ListOfValue, TitleOfGraph) 'get xmldoc for show GU
        If Me.LoadSample_Worker.CancellationPending Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            If e.Cancelled Then
                Return
            End If
            'After Worker read file XML to Hashtable
            If m_ListOfValue IsNot Nothing AndAlso m_ListOfValue.Count >= 0 Then
                m_marshaller.Invoke(Of List(Of String))(New Threading.SendOrPostCallback(AddressOf UpdateGraphWithRefresh), m_ListOfValue)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub LoadDataFile(ByVal strFileName As String, ByRef ListOfValue As List(Of String), ByRef strTitleOfGraph As String)
        Try
            Dim xmlDoc As New System.Xml.XmlDocument()
            xmlDoc.Load(strFileName)
            If ListOfValue Is Nothing Then
                ListOfValue = New List(Of String)
            End If
            Dim startNode As XmlNode = xmlDoc.SelectSingleNode("/" & TypeOf_DiagnosticScreen.ToString() & "/Start")
            strTitleOfGraph = startNode.InnerText
            Dim SampleListNode As System.Xml.XmlNode = xmlDoc.SelectSingleNode("/" & TypeOf_DiagnosticScreen.ToString() & "/SampleList")
            For Each node As XmlNode In SampleListNode.ChildNodes
                '2013-06-06 Tin Pham: support cancel data
                If LoadSample_Worker IsNot Nothing AndAlso LoadSample_Worker.CancellationPending Then
                    Exit Try
                End If
                '
                Dim strValue As String = String.Empty
                Dim samplenode As Xml.XmlNodeList = node.ChildNodes
                strValue = samplenode.Item(INDEX_OF_TIME).InnerText & "#"
                strValue = strValue & samplenode.Item(INDEX_OF_DATA).InnerText & "#"
                strValue = strValue & "$#"
                ListOfValue.Add(strValue)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Draw Graph
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DrawGraphFromFile(ByVal filename As String)
        Try
            Me.zgraphFromFile.GraphPane.CurveList.Clear()
            Dim myCurve As LineItem
            Dim list As New PointPairList
            myCurve = Me.zgraphFromFile.GraphPane.AddCurve(m_strYAxisTitle, list, Color.Red, SymbolType.Diamond)
            ' Fill the symbols with white
            myCurve.Symbol.Fill = New Fill(Color.White)
            Me.zgraphFromFile.GraphPane.YAxis.Title.Text = ""

            If Not (m_strdataFile = filename) AndAlso LoadSample_Worker.IsBusy Then
                LoadSample_Worker.CancelAsync()
            End If
            If System.IO.File.Exists(filename) AndAlso Not (LoadSample_Worker.IsBusy) Then
                m_strdataFile = filename
                m_ListOfValue = New List(Of String)
                lbStatus.Text = "Please wait while loading...."
                LoadSample_Worker.RunWorkerAsync()
                'zgraphFromFile.Refresh()
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
    ''' DataGrid Cell Click 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub dgvHistory_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHistory.CellClick
        Try
            If e.RowIndex >= 0 Then
                'Me.zgraphFromFile.Visible = False
                'Me.MainGraph.Visible = False
                Dim row As DataGridViewRow = Me.dgvHistory.Rows(e.RowIndex)
                If btnStart.Text = START_BUTTON_TXT Or e.RowIndex > 0 Then ''system is not start
                    Dim filename As String = row.Cells(FILE_PATH).Value
                    If filename = String.Empty Then
                        Exit Sub
                    End If
                    DrawGraphFromFile(filename)
                    Me.MainGraph.Visible = False
                    Me.zgraphFromFile.Visible = True
                Else ''this cell don't have filepath -> still draw graph
                    Me.TitleOfGraph = row.Cells(AT_TIME).FormattedValue
                    Me.zgraphFromFile.Visible = False
                    Me.MainGraph.Visible = True
                End If

                If e.ColumnIndex = Me.dgvHistory.Columns(MARK_DELETE).Index Then
                    Dim chk As DataGridViewCheckBoxCell = TryCast(Me.dgvHistory.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewCheckBoxCell)

                    If chk IsNot Nothing Then
                        If (TypeOf chk.Value Is Boolean) Then
                            If chk.Value = True Then
                                chk.Value = False
                            Else
                                chk.Value = True
                            End If
                        Else
                            chk.Value = True
                        End If
                    End If

                    CheckEnableDeleteDataRun()
                End If
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
    ''' Textbox click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub txtSampleTime_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSampleTime.Click, txtTotalTime.Click
        Try
            Dim TextBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            Dim Source As String = PVD + ".DiagnosticScreen" + "." + TextBox.Name
            Dim SourceMinMax As String = ChamberName.ToString() + "." + Source
            Dim frm As New NumPad()
            Dim Min As Single = AVPLib.ContainerData.GetRobotConfig(SourceMinMax + STRING_MIN)
            Dim Max As Single = AVPLib.ContainerData.GetRobotConfig(SourceMinMax + STRING_MAX)
            Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
            Dim Value As String = TextBox.Text

            Dim InputRes As MsgBoxResult = frm.GetUserInput(Value, -1, -1, Min, Max, Title, 0, True, False)

            If frm.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(SourceMinMax + STRING_MIN, frm.NewMin)
                AVPLib.ContainerData.SetRobotConfig(SourceMinMax + STRING_MAX, frm.NewMax)
            End If

            If InputRes = MsgBoxResult.Ok Then
                TextBox.Text = Value

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Diagnostic] Set Sampling Time to " + Value)
                Try
                    Dim strRetValue As String = TextBox.Text
                    If TextBox.Name = txtSampleTime.Name Then
                        txtSampleTime.Text = strRetValue
                    Else
                        txtTotalTime.Text = strRetValue
                    End If

                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.Click
        Dim pad As New KeyPad
        Dim Value As String = txtDescription.Text
        If pad.DisplayKeypad(Value, "Please input the description", False) = DialogResult.OK Then
            txtDescription.Text = Value
        End If
    End Sub

    Private Function MainGraph_PointValueEvent(ByVal sender As ZedGraph.ZedGraphControl, _
                                               ByVal pane As ZedGraph.GraphPane, _
                                               ByVal curve As ZedGraph.CurveItem, _
                                               ByVal iPt As Integer) As String Handles MainGraph.PointValueEvent, zgraphFromFile.PointValueEvent
        Dim pt As PointPair = curve(iPt)
        Return "Time= " & pt.X.ToString() & IIf(Me.TypeOf_DiagnosticScreen = DiagnosticType.Recover_Pressure, ",IG/CG_Pressure= ", ",IG_Pressure= ") & Format(Double.Parse(pt.Y.ToString()), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
    End Function

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2018-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' btnDelete_Click
    ''' </summary>
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Dim fileName As String = String.Empty
            Dim isDeleted As Boolean = False
            Dim rowDeletedList As List(Of String) = New List(Of String)()

            For Each row As DataGridViewRow In Me.dgvHistory.Rows
                fileName = GetFilePathNeedToDeleted(row)

                If Not String.IsNullOrEmpty(fileName) Then
                    rowDeletedList.Add(fileName)
                End If
            Next

            If rowDeletedList.Count >= 1 Then
                Dim strMessageBox As String = String.Empty

                Select Case (TypeOf_DiagnosticScreen)
                    Case (DiagnosticType.PumpDown_Curve)
                        strMessageBox = "Pump Down Curve"
                    Case (DiagnosticType.Rate_Of_Rise)
                        strMessageBox = "Rate Of Rise"
                    Case (DiagnosticType.Recover_Pressure)
                        strMessageBox = "Recover Pressure"
                End Select

                TypeOf_DiagnosticScreen.ToString().Replace("_", " ")
                Dim dlg As DialogResult = Utils.ShowAVPMessageBox("Do you want to delete " + strMessageBox + " files?", strMessageBox, MessageBoxIcon.Exclamation)

                If dlg = DialogResult.OK Then
                    For Each filePath As String In rowDeletedList
                        If filePath <> String.Empty Then
                            If IsPDC_ROR_Running AndAlso Not String.IsNullOrEmpty(m_strFileName) AndAlso m_strFileName = filePath Then
                                ''Do nothing.
                            Else
                                ''Delete DataGridViewRow
                                For Each row As DataGridViewRow In Me.dgvHistory.Rows
                                    If filePath = GetFilePathNeedToDeleted(row) Then
                                        Me.dgvHistory.Rows.Remove(row)
                                        Exit For
                                    End If
                                Next

                                ''Delete .xml
                                If System.IO.File.Exists(filePath) AndAlso Not Utils.FileInUse(filePath) Then
                                    System.IO.File.Delete(filePath)
                                    isDeleted = True
                                End If

                                ''Delete .csv
                                filePath = filePath.Replace(".xml", ".csv")
                                If System.IO.File.Exists(filePath) AndAlso Not Utils.FileInUse(filePath) Then
                                    System.IO.File.Delete(filePath)
                                End If
                            End If
                        End If
                    Next

                    If isDeleted Then
                        If Me.dgvHistory.Rows.Count > 0 Then
                            fileName = Me.dgvHistory.Rows(0).Cells(FILE_PATH).Value

                            If btnStart.Text = START_BUTTON_TXT Then ''system is not start
                                If fileName = String.Empty Then
                                    Exit Sub
                                End If
                                DrawGraphFromFile(fileName)
                                Me.MainGraph.Visible = False
                                Me.zgraphFromFile.Visible = True
                            Else ''this cell don't have filepath -> still draw graph
                                Me.zgraphFromFile.Visible = False
                                Me.MainGraph.Visible = True
                            End If

                            Me.dgvHistory.Rows(0).Selected = True
                        Else
                            TitleOfGraph = TypeOf_DiagnosticScreen.ToString()
                            If Me.MainGraph.GraphPane.CurveList.Count > 0 Then
                                Me.MainGraph.GraphPane.CurveList(m_strYAxisTitle).Clear()
                                Me.MainGraph.Refresh()
                            End If

                            If Me.zgraphFromFile.GraphPane.CurveList.Count > 0 Then
                                Me.zgraphFromFile.GraphPane.CurveList(m_strYAxisTitle).Clear()
                                Me.zgraphFromFile.Refresh()
                            End If
                        End If

                        CheckEnableDeleteDataRun()
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2018-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' Check Enable Delete DataRun
    ''' </summary>
    Private Sub CheckEnableDeleteDataRun()
        Try
            Dim checkDelete As Boolean = False

            For Each row As DataGridViewRow In Me.dgvHistory.Rows
                If (TypeOf row.Cells(MARK_DELETE).Value Is Boolean) AndAlso row.Cells(MARK_DELETE).Value = True Then
                    checkDelete = True
                    Exit For
                End If
            Next

            m_isEnableDeleteDatarun = checkDelete
            Me.btnDelete.Enabled = m_isActive And Not (m_isScheduler_Running) And m_isEnableDeleteDatarun
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2018-12-25 </date>
    ''' </author>
    ''' <summary>
    ''' Get File Path Need To Deleted
    ''' </summary>
    Private Function GetFilePathNeedToDeleted(ByVal dgvRow As DataGridViewRow) As String
        Dim result As String = String.Empty

        Try
            If (TypeOf dgvRow.Cells(MARK_DELETE).Value Is Boolean) AndAlso dgvRow.Cells(MARK_DELETE).Value = True Then
                If Not dgvRow.Cells(FILE_PATH).Value Is DBNull.Value Then
                    result = dgvRow.Cells(FILE_PATH).Value
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return result
    End Function

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        btnStart.Text = START_BUTTON_TXT
        IsPDC_ROR_Running = False
        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class
