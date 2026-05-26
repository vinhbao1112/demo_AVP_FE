Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPControls
Imports AVPLib

Public Class CoronaPanel
    Private m_bPM_DeviceNet As Boolean = False
    Private m_PopUpPanel As CORONAPopUpPanel = Nothing
    Private m_CryoPopUpPanel As CryoPopUpPanel = Nothing
    Private m_SystemSetupPopUpPanel As SystemSetupPopUpPanel = Nothing
    Public bUnProtectedClicked As Boolean = False
    Public intTimeUnProtectedTimeCountInProcessModule As Integer = 0
    Public IsWaitingInitializeMotionOff As Boolean = False
    Private m_blnIsBeamOn As Boolean = False
    Private m_blnIsShutterOpen As Boolean = False
    Private m_blnVatControlVisible As Boolean = True
    Private m_blnMagnatronVisible As Boolean = False
    Private m_CGGaugesFrm As CGGaugesFrm = Nothing
    Private m_RPCGGaugesFrm As CGGaugesFrm = Nothing
    Private m_FLCGGaugesFrm As CGGaugesFrm = Nothing
    Private m_iGasEndIndex As Integer = 1
    Private m_TurboInstalled As Boolean = True
    Private m_blnWaterPumpVisible As Boolean
    Private m_blnHeaterVisible As Boolean = False

#Region "Properties"
    'It's have got in ChamberPanel.vb
    'Rem by Buu Tran - 01/10/2013
    'Public ReadOnly Property IsProtectedMode() As Boolean
    '    Get
    '        Return m_IsProtectedMode
    '    End Get
    'End Property
    Public Property WaterPumpVisible() As Boolean
        Get
            Return m_blnWaterPumpVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnWaterPumpVisible = value
            WPHeader.Visible = value
            txtWaterPump.Visible = value
            btnWP.Visible = value
            TurboControl.IsWaterPumpInstalled = m_blnWaterPumpVisible
        End Set
    End Property


    Public Property TurboInstalled() As Boolean
        Get
            Return m_TurboInstalled
        End Get
        Set(ByVal value As Boolean)
            m_TurboInstalled = value
            If m_TurboInstalled Then
                TurboControl.Visible = True
                'TurboControl.Status = DisplayStatus.Off
                btnHivacValve.Visible = True
                btnWaterPumpOn.Visible = True
            Else
                TurboControl.Visible = False
                btnHivacValve.Visible = False
                btnWaterPumpOn.Visible = False
            End If
        End Set
    End Property
    Public WriteOnly Property IsDC_or_RF() As String
        Set(ByVal value As String)
            If value = "DC" Then
                RFTargetPowerSupply.PSType = "DCTarget"               
            End If
        End Set
    End Property

    Public Property IsBeamOn() As Boolean
        Get
            Return m_blnIsBeamOn
        End Get
        Set(ByVal value As Boolean)
            m_blnIsBeamOn = value
        End Set
    End Property

    Public Property IsShuttterOpen() As Boolean
        Get
            Return m_blnIsShutterOpen
        End Get
        Set(ByVal value As Boolean)
            m_blnIsShutterOpen = value
        End Set
    End Property

    Public Property PM_DeviceNet() As Boolean
        Get
            Return m_bPM_DeviceNet
        End Get
        Set(ByVal value As Boolean)
            m_bPM_DeviceNet = value
            If m_bPM_DeviceNet Then
                txtForelineCG.Visible = True
                ' txtRoughlineCG.Visible = True
                'ValveControl1.Visible = True
            Else
                txtForelineCG.Visible = False
                txtRoughlineCG.Visible = False
                'ValveControl1.Visible = False
            End If
        End Set
    End Property
    Private m_blnGas1Visible As Boolean = False
    Public Property Gas1Visible() As Boolean
        Get
            Return m_blnGas1Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnGas1Visible = value
            Gas1ShutOffValve.Visible = value
        End Set
    End Property
    Private m_blnGas2Visible As Boolean = False
    Public Property Gas2Visible() As Boolean
        Get
            Return m_blnGas2Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnGas2Visible = value
            Gas2ShutOffValve.Visible = value
        End Set
    End Property
    Private m_blnGas3Visible As Boolean = False
    Public Property Gas3Visible() As Boolean
        Get
            Return m_blnGas3Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnGas3Visible = value
            Gas3ShutOffValve.Visible = value
        End Set
    End Property
    Private m_blnGas4Visible As Boolean = False
    Public Property Gas4Visible() As Boolean
        Get
            Return m_blnGas4Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnGas4Visible = value
            Gas4ShutOffValve.Visible = value
        End Set
    End Property
    Private m_blnGas5Visible As Boolean = False
    Public Property Gas5Visible() As Boolean
        Get
            Return m_blnGas5Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnGas5Visible = value
            Gas5ShutOffValve.Visible = value
        End Set
    End Property

    Private m_blnGasInjectionVisible As Boolean = False
    Public Property GasInjectionVisible() As Boolean
        Get
            Return m_blnGasInjectionVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnGasInjectionVisible = value
        End Set
    End Property

    Private m_SupportMainSecondDistributionValves As Boolean = False
    Public Property SupportMainSecondDistributionValves() As Boolean
        Get
            Return m_SupportMainSecondDistributionValves
        End Get
        Set(ByVal value As Boolean)
            m_SupportMainSecondDistributionValves = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-08-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set IGIsoValveInstalled
    ''' </summary>
    ''' <remarks></remarks>
    Private m_blnIGIsoValveVisible As Boolean = False
    Public Property IGIsoValveVisible() As Boolean
        Get
            Return m_blnIGIsoValveVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnIGIsoValveVisible = value
            IGIsolationValve.Visible = value
            GasIGIsolation1.Visible = value
            GasIGIsolation2.Visible = value
        End Set
    End Property

    Public WriteOnly Property Interlock_AirPressure_Visible() As Boolean
        Set(ByVal value As Boolean)
            If Not value Then
                Me.PVD4Interlock.AirPressure_Visible = value
                Me.PVD4Interlock.Size = New Point(325, 178)
            End If
        End Set
    End Property
#End Region

#Region "Private method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.Name)
            If objPanel.IsOnline Then
                CoronaChamber.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
                CoronaChamber.SetOnlineOfflineContainerBox(IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True))
                Exit Sub
            End If
            btnWaterPumpOn.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnHivacValve.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            CoronaChamber.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            Me.RunRecipe.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            RFTargetPowerSupply.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            BiasPowerSupply.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            BAControl.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            PVD4Interlock.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            GasController.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            ProcessMonitor.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            VatValveController.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            TableControl.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            CoronaPressure.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            btnOverrideMode.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveRough.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            MechanicalPump.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveVent.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveBaratron.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveForeline.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            Gas1ShutOffValve.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            Gas2ShutOffValve.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            Gas3ShutOffValve.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            Gas4ShutOffValve.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            Gas5ShutOffValve.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            SecDistValve.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            MainDistValve.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            IGIsolationValve.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            lblDisconnect.Tag = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtForelineCG.Clickable = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnHivacValve.Clickable = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtForelineCG.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnWaterPumpOn.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            HeaterControl.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            FilMetricControl.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            m_CryoPopUpPanel.DeviceOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            CoronaChamber.Enabled = False
            Me.RunRecipe.IsOnline = True
            TableControl.IsOnline = True
            RFTargetPowerSupply.IsOnline = True
            BiasPowerSupply.IsOnline = True
            BAControl.IsOnline = True
            PVD4Interlock.IsOnline = True
            GasController.IsOnline = True
            ProcessMonitor.IsOnline = True
            VatValveController.IsOnline = True
            CoronaPressure.IsOnline = True
            btnOverrideMode.Enabled = False
            ValveRough.Enabled = False
            MechanicalPump.Enabled = False
            ValveVent.Enabled = False
            ValveBaratron.Enabled = False
            ValveForeline.Enabled = False
            Gas1ShutOffValve.Enabled = False
            Gas2ShutOffValve.Enabled = False
            Gas3ShutOffValve.Enabled = False
            Gas4ShutOffValve.Enabled = False
            Gas5ShutOffValve.Enabled = False
            SecDistValve.Enabled = False
            MainDistValve.Enabled = False
            IGIsolationValve.Enabled = False
            lblDisconnect.Tag = False
            txtForelineCG.Clickable = False
            btnHivacValve.Clickable = False
            btnWaterPumpOn.Enabled = False
            HeaterControl.IsOnline = True
            m_CryoPopUpPanel.DeviceOnline = True
            FilMetricControl.IsOnline = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-06-03</date>
    ''' </author>
    ''' <summary>
    ''' Show label InjectionValve 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub bicTarget1Water_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InjectionValve1.StatusChange, _
    InjectionValve2.StatusChange, InjectionValve3.StatusChange, InjectionValve4.StatusChange
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then

                Dim strLabelInjection As String = "Injection "
                Dim arrTemp(5) As String
                Dim count As Integer = 0

                If InjectionValve1.Status = DisplayStatus.On Then
                    arrTemp(count) = "T1"
                    count += 1
                End If
                If InjectionValve2.Status = DisplayStatus.On Then
                    arrTemp(count) = "T2"
                    count += 1
                End If
                If InjectionValve3.Status = DisplayStatus.On Then
                    arrTemp(count) = "T3"
                    count += 1
                End If
                If InjectionValve4.Status = DisplayStatus.On Then
                    arrTemp(count) = "T4"
                    count += 1
                End If

                If count > 0 Then
                    Array.Resize(arrTemp, count)
                    strLabelInjection &= String.Join("/", arrTemp)
                    lblInjection.Text = strLabelInjection
                Else
                    lblInjection.Text = String.Empty
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Set SlitValve status to chamber control
    ''' </summary>
    Protected Overrides Sub SetSlitValveStatus()
        Try
            Select Case SlitValveStatus
                Case SlitValve.SlitValveDisplayStatus.On
                    Me.CoronaChamber.SlitValveStatus = DisplayStatus.On
                Case SlitValve.SlitValveDisplayStatus.Off
                    Me.CoronaChamber.SlitValveStatus = DisplayStatus.Off
                Case Else
                    Me.CoronaChamber.SlitValveStatus = DisplayStatus.Unknow
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Overrides Sub GoOnline(ByVal blnThrowAlarm As Boolean)
        ''must get status obj PopUpPanel to Request Status-> ParseMessageGui will convert
        If m_PopUpPanel IsNot Nothing Then
            m_PopUpPanel.Status.RequestStatus(SL_PopUpPanel.btnOnline.Name, blnThrowAlarm)
        End If
    End Sub

    Public Sub New(ByVal ChamberName As String, ByVal TypeOfIBE As AVPLib.ConstEnum.IBEType, Optional ByVal CryoInstalled As Boolean = True, Optional ByVal WPInstalled As Boolean = True)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.lblDisconnect.Location = New Point(377, 303)
        Me.Name = ChamberName
        Me.Tag = AVPLib.Utils.chamberID2ChamberName(Me.Name)
        m_PopUpPanel = New CORONAPopUpPanel
        m_PopUpPanel.Name = "PopUpPanel"
        m_PopUpPanel.StartPosition = FormStartPosition.CenterScreen
        m_PopUpPanel.ShowInTaskbar = False
        m_PopUpPanel.ShowIcon = False
        m_PopUpPanel.Text = "PVD4 Panel"
        m_PopUpPanel.ChamberHandle = ChamberName
        m_PopUpPanel.Hide()
        'If CryoInstalled = False And WPInstalled = True Then
        '    m_PopUpPanel.NoCryoInstalled = True
        'ElseIf CryoInstalled = True And WPInstalled = False Then
        '    m_PopUpPanel.NoWaterPumpInstalled = True
        'ElseIf CryoInstalled = False And WPInstalled = False Then
        '    m_PopUpPanel.NoCryoAndWPInstalled = True
        'End If

        m_CryoPopUpPanel = New CryoPopUpPanel
        m_CryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
        m_CryoPopUpPanel.Name = "CryoPopUpPanel"
        m_CryoPopUpPanel.ShowInTaskbar = False
        m_CryoPopUpPanel.ShowIcon = False
        m_CryoPopUpPanel.TypeOfCryoPanel = AVP_Robot_Project.CryoPopUpPanel.CryoPanelType.WaterPumpPanel
        m_CryoPopUpPanel.Text = AVPLib.Utils.chamberID2ChamberName(ChamberName) & " WaterPump"
        m_CryoPopUpPanel.PanelHandle = ChamberName
        m_CryoPopUpPanel.txtExtendedPurgeTime.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtPumpRestartDelay.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtRateOfRise.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtRoughToPressure.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtStartUpTemp.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtRepurgeCycles.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.ChamberType = "PVD4"
        CoronaChamber.IsTableHome = True
        RFTargetPowerSupply.Header.Cursor = Cursors.Hand
        BiasPowerSupply.Header.Cursor = Cursors.Hand

        m_CryoPopUpPanel.Hide()

        NewConvectronGaugeFrm(AVPLib.Utils.chamberID2ChamberName(ChamberName))
        NewRPConvectronGaugeFrm(AVPLib.Utils.chamberID2ChamberName(ChamberName))
        NewFLConvectronGaugeFrm(AVPLib.Utils.chamberID2ChamberName(ChamberName))
        Me.txtWaterPump.Cursor = Cursors.Hand
        Me.lblCurrentPurgeCycle.Location = New Point(755, 94)
        RunRecipe.Left = ProcessMonitor.Left
        RunRecipe.Top = ProcessMonitor.Top + ProcessMonitor.Height + 1
        RunRecipe.Height = 95
        RunRecipe.Width = 320
        RunRecipe.Real_Device_Enable = True
        BiasPowerSupply.Top = RFTargetPowerSupply.Top + RFTargetPowerSupply.Height
        PVD4Interlock.Top = BiasPowerSupply.Top + BiasPowerSupply.Height
        Me.lblStatusText.Location = New Point(0, 740) '(322, 740)
        Me.lblStatusText.Visible = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or _
          ControlStyles.OptimizedDoubleBuffer Or _
          ControlStyles.DoubleBuffer, True)

        AddHandler CoronaPressure.PressureCG_Click, AddressOf PressureCG_Click
        AddHandler CoronaPressure.StatusIGChanged, AddressOf StatusIGChanged

        AddHandler m_CryoPopUpPanel.ButtonPump_StatusChanged, AddressOf btnCryoPopupPanel_StatusChange
        AddHandler m_CryoPopUpPanel.ButtonRegen_StatusChanged, AddressOf btnCryoPopupPanel_StatusChange
    End Sub

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-05-13 </date>
    ''' </author>
    ''' <summary>
    ''' Handle status change event for cryo popup panel buttons.
    ''' </summary>
    Private Sub btnCryoPopupPanel_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim objChamber As AVPLib.DataManagerment.CoronaChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
            If objChamber IsNot Nothing AndAlso CryoPopUpPanel IsNot Nothing Then
                If objChamber.Water_Pump_State_Status = Equipment.WorkingStatuses.On Then
                    btnWP.Status = DisplayStatus.On
                ElseIf objChamber.Water_Pump_Regen_Status = Equipment.WorkingStatuses.On Then
                    btnWP.Status = DisplayStatus.Unknow
                Else
                    btnWP.Status = DisplayStatus.Off
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        AVPLib.Log.guiLogger.Info("Enter Your Function")
        Try
            For Each ctrl As Control In Me.Controls
                If ctrl.GetType().Name = "SL_CustomButton" Then
                    Dim statusbtn As New StatusCoronaButton(CType(ctrl, SL_CustomButton))
                    m_stoStatusObject.AddChild(statusbtn)
                    CType(ctrl, SL_CustomButton).ParentStatusObj = m_stoStatusObject
                ElseIf ctrl.GetType().Name = "ValveControl" Then
                    Dim sValve As New StatusCoronaBinaryControl(CType(ctrl, ValveControl))
                    m_stoStatusObject.AddChild(sValve)
                    CType(ctrl, ValveControl).ParentStatusObj = m_stoStatusObject
                ElseIf ctrl.GetType().Name = "SL_Textbox" Then
                    Dim statusText As New StatusCoronaTextBox(CType(ctrl, SL_Textbox))
                    m_stoStatusObject.AddChild(statusText)
                    CType(ctrl, SL_Textbox).ParentStatusObj = m_stoStatusObject

                ElseIf ctrl.GetType().Name = "CustomTabControl" Then
                    Dim tbctrl As CustomTabControl = CType(ctrl, CustomTabControl)
                    For Each tbpage As TabPage In tbctrl.TabPages
                        For Each childCtrl As Control In tbpage.Controls
                            If childCtrl.GetType().Name = "SL_Textbox" Then
                                Dim statusText As New StatusCoronaTextBox(CType(childCtrl, SL_Textbox))
                                m_stoStatusObject.AddChild(statusText)
                                CType(childCtrl, SL_Textbox).ParentStatusObj = m_stoStatusObject
                            ElseIf childCtrl.GetType().Name = "SL_CustomButton" Then
                                Dim statusbtn As New StatusCoronaButton(CType(childCtrl, SL_CustomButton))
                                m_stoStatusObject.AddChild(statusbtn)
                                CType(childCtrl, SL_CustomButton).ParentStatusObj = m_stoStatusObject
                            ElseIf ctrl.GetType().Name = "ImageBinaryStatusControl" Then
                                Dim statusbtn As New StatusBinaryStatusControl(CType(ctrl, ImageBinaryStatusControl))
                                m_stoStatusObject.AddChild(statusbtn)
                                CType(childCtrl, ImageBinaryStatusControl).ParentStatusObj = m_stoStatusObject
                            End If
                        Next
                    Next
                End If
            Next
            Dim sbcConnectionStatus As New StatusIGCGButton(btnReConnect)
            Dim sbcTargetPlasma As New StatusPVD4TargetControl(CoronaTarget)
            Dim sHivacValve As New Corona_HivacValve(btnHivacValve)
            Dim sWPHeader As New StatusIGCGButton(WPHeader)
            Dim stbWaferCount As New StatusTextBox(txtPMWaferCount)

            Dim slbSequenceRunningStatus As New SL_StatusLabel(lblNameOfSequenceRunning)
            Dim slbCurrentPurgeCycle As New StatusLabel(lblCurrentPurgeCycle)
            Dim slbWaitingMPOn As New StatusLabel(lblWaitingMPOn)
            Dim sclComunicationLED_MpumpSerial As New StatusColorLabel(lblComunicationLED_MP)
            sclComunicationLED_MpumpSerial.CommStateChanged = New CommunicationState(AddressOf UpdateMPumpSerial)

            m_stoStatusObject.AddChild(stbWaferCount)
            m_stoStatusObject.AddChild(sbcTargetPlasma)
            m_stoStatusObject.AddChild(sbcConnectionStatus)
            m_stoStatusObject.AddChild(BiasPowerSupply.Status)
            m_stoStatusObject.AddChild(RFTargetPowerSupply.Status)
            m_stoStatusObject.AddChild(PVD4Interlock.Status)
            m_stoStatusObject.AddChild(GasController.Status)
            m_stoStatusObject.AddChild(TableControl.Status)
            m_stoStatusObject.AddChild(ProcessMonitor.Status)
            m_stoStatusObject.AddChild(VatValveController.Status)
            m_stoStatusObject.AddChild(BAControl.Status)
            m_stoStatusObject.AddChild(Me.RunRecipe.Status)
            m_stoStatusObject.AddChild(m_CryoPopUpPanel.Status)
            m_stoStatusObject.AddChild(m_PopUpPanel.Status)
            m_stoStatusObject.AddChild(CoronaChamber.Status)
            m_stoStatusObject.AddChild(CoronaPressure.Status)
            m_stoStatusObject.AddChild(sHivacValve)
            m_stoStatusObject.AddChild(sWPHeader)
            m_stoStatusObject.AddChild(HeaterControl.Status)
            m_stoStatusObject.AddChild(FilMetricControl.Status)
            btnHivacValve.ParentStatusObj = m_stoStatusObject
            m_stoStatusObject.AddChild(slbSequenceRunningStatus)
            m_stoStatusObject.AddChild(slbCurrentPurgeCycle)

            m_stoStatusObject.AddChild(Me.m_CGGaugesFrm.Status)
            m_stoStatusObject.AddChild(Me.m_RPCGGaugesFrm.Status)
            m_stoStatusObject.AddChild(Me.m_FLCGGaugesFrm.Status)
            m_stoStatusObject.AddChild(slbWaitingMPOn)

            m_stoStatusObject.AddChild(sclComunicationLED_MpumpSerial)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Your Function")
    End Sub
#End Region

#Region "Public methods"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-01-19</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of SLPopUpPanel
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PopUpPanel() As CORONAPopUpPanel
        Get
            Return m_PopUpPanel
        End Get
    End Property

    Public ReadOnly Property CryoPopUpPanel() As CryoPopUpPanel
        Get
            Return m_CryoPopUpPanel
        End Get
    End Property
    Public Property PMSystemSetupPopUpPanel() As SystemSetupPopUpPanel
        Get
            Return m_SystemSetupPopUpPanel
        End Get
        Set(ByVal value As SystemSetupPopUpPanel)
            m_SystemSetupPopUpPanel = value
        End Set
    End Property
    Private Sub CreateSystemSetupPopUpPanel(ByRef PMXTargetPSConfigPopUpPanel As SystemSetupPopUpPanel)
        Try
            If PMSystemSetupPopUpPanel Is Nothing Then
                PMSystemSetupPopUpPanel = New SystemSetupPopUpPanel
                PMSystemSetupPopUpPanel.Name = "PVDASystemSetupPopUpPanel"
                PMSystemSetupPopUpPanel.StartPosition = FormStartPosition.CenterParent
                PMSystemSetupPopUpPanel.ShowInTaskbar = False
                PMSystemSetupPopUpPanel.ShowIcon = False
                PMSystemSetupPopUpPanel.Hide()
                PMSystemSetupPopUpPanel.Text = "PVD4 System Setup of PM"
                PMSystemSetupPopUpPanel.ChamberName = "PVD4"
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub CheckPermission(ByVal PERMISSION_Code As String)
        AVPLib.Log.guiLogger.Info("Enter CheckPermission")
        Try
            If AVPLib.ContainerData.Permission(PERMISSION_Code) Then
                ActiveForm()
            Else
                InactiveForm()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CheckPermission")
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-02-22</date>
    ''' </author>
    ''' <summary>
    ''' Disable/Enable control when online/offline
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetOnlineOfflinePM(ByVal blnIsOnline As Boolean)
        Try
            If blnIsOnline Then
                InactiveForm()
                If AVPLib.ContainerData.Permission(PERMISSION_001) Then
                    CoronaChamber.Enabled = True
                End If
                Me.IsOnline = True
            Else
                Me.IsOnline = False
                If AVPLib.ContainerData.Permission(PERMISSION_001) Then
                    ActiveForm()
                End If
            End If
            CoronaChamber.SetOnlineOfflineContainerBox(blnIsOnline)
            m_PopUpPanel.SetOnlineOfflinePopUp(blnIsOnline)
            m_CryoPopUpPanel.DeviceOnline = blnIsOnline
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Friend Sub Online_OfflineValveStatus(ByVal blnEnableStatus As Boolean, ByVal blnIsMenuOnlineClick As Boolean)

    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-22-23</date>
    ''' </author>
    ''' <summary>
    ''' Set default status to show on GUI when PM disconnect.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaultStatus()
        InactiveForm()
    End Sub

    Private Target_LastIndex As Object = Nothing
    Public Sub TurnOnOffTargetxSwitch(ByVal nIndex As Object)
        If Target_LastIndex <> nIndex Then
            Select Case nIndex
                Case "1"
                    'target1
                    RFTargetPowerSupply.btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.On
                    RFTargetPowerSupply.btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.txtMagnatron.Text = _
                        IIf(RFTargetPowerSupply.btnMag1RotationStart.Status = SL_CustomButton.DisplayStatus.On, _
                            ConstantAndEnum.STR_ROTATING, String.Empty)
                Case "2"
                    'target2
                    RFTargetPowerSupply.btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.On
                    RFTargetPowerSupply.btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.txtMagnatron.Text = _
                        IIf(RFTargetPowerSupply.btnMag2RotationStart.Status = SL_CustomButton.DisplayStatus.On, _
                            ConstantAndEnum.STR_ROTATING, String.Empty)
                Case "3"
                    'target3
                    RFTargetPowerSupply.btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.On
                    RFTargetPowerSupply.btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.txtMagnatron.Text = _
                        IIf(RFTargetPowerSupply.btnMag3RotationStart.Status = SL_CustomButton.DisplayStatus.On, _
                            ConstantAndEnum.STR_ROTATING, String.Empty)
                Case "4"
                    'target4
                    RFTargetPowerSupply.btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.On
                    RFTargetPowerSupply.txtMagnatron.Text = _
                        IIf(RFTargetPowerSupply.btnMag4RotationStart.Status = SL_CustomButton.DisplayStatus.On, _
                            ConstantAndEnum.STR_ROTATING, String.Empty)
                Case "0"
                    'no target
                    RFTargetPowerSupply.btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.Off
                    CoronaTarget.TargetStatus = DisplayStatus.Off
                Case Else
                    AVPLib.Log.avpLogger.Error("Error in TurnOnOffTargetxSwitch")
                    RFTargetPowerSupply.btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.Off
                    RFTargetPowerSupply.btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.Off
                    CoronaTarget.TargetStatus = DisplayStatus.Off
            End Select
            Target_LastIndex = nIndex
        End If
    End Sub

#End Region

#Region "Events – Buttons – Forms…"

#Region "Status Change"
    Private Sub UpdateMPumpSerial(ByVal state As Boolean)
        Try
            Dim objChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.Name)
            If objChamberConfig.MPumpSerialVisible Then
                If Me.InvokeRequired Then
                    Me.Invoke(New CommunicationState(AddressOf UpdateMPumpSerial), state)
                    Return
                End If

                If state Then
                    btnComMechanicalPump.Status = AVPControls.AVPDataLib.DisplayStatus.On
                Else
                    btnComMechanicalPump.Status = AVPControls.AVPDataLib.DisplayStatus.Error
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-08-03 </date>
    ''' </author>
    ''' <summary>
    ''' Update gasline status
    ''' </summary>
    Private Sub Valve_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    ValveVent.StatusChange, ValveRough.StatusChange, ValveBaratron.StatusChange, ValveForeline.StatusChange, _
    MainDistValve.StatusChange, SecDistValve.StatusChange, Gas1ShutOffValve.StatusChange, Gas2ShutOffValve.StatusChange, _
    Gas3ShutOffValve.StatusChange, Gas4ShutOffValve.StatusChange, Gas5ShutOffValve.StatusChange, IGIsolationValve.StatusChange
        Try

            If Not TypeOf sender Is ValveControl Then
                Return
            End If
            Dim status As BinaryStatusControl.DisplayStatus = CType(sender, ValveControl).Status
            Dim gaslineStatus As DisplayStatus = Utils.ConvertToDisplayStatus(status.ToString())

            If sender Is ValveVent Then
                If status = BinaryStatusControl.DisplayStatus.On Then
                    GaslineVentIn.Restart()
                End If
                ValveVentLine.Status = gaslineStatus
            ElseIf sender Is ValveRough Then
                If status = BinaryStatusControl.DisplayStatus.On Then
                    ValveRoughLineOut.Status = ValveRoughLine.Status
                    ValveRoughLine.Restart()
                Else
                    ValveRoughLineOut.Status = gaslineStatus
                End If

            ElseIf sender Is ValveBaratron Then
                ValveBaratronLine.Status = gaslineStatus

            ElseIf sender Is ValveForeline Then
                If status = BinaryStatusControl.DisplayStatus.On Then
                    ValveForelineLine.Status = RoughForeLine.Status
                    RoughForeLine.Restart()
                Else
                    ValveForelineLine.Status = gaslineStatus
                End If
            ElseIf sender Is MainDistValve OrElse _
                   sender Is SecDistValve OrElse _
                   sender Is Gas1ShutOffValve OrElse _
                   sender Is Gas2ShutOffValve OrElse _
                   sender Is Gas3ShutOffValve OrElse _
                   sender Is Gas4ShutOffValve OrElse _
                   sender Is Gas5ShutOffValve Then
                SetGaslineStatus()
                ReflowGasline()

            ElseIf sender Is IGIsolationValve Then
                GasIGIsolation1.Status = status
                GasIGIsolation2.Status = status
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-08-03 </date>
    ''' </author>
    ''' <summary>
    ''' Re-flow gas for sync animation
    ''' </summary>
    Private Sub ReflowGasline()
        Try
            Gas5Line.Restart()
            Gas4Line.Restart()
            Gas3Line.Restart()
            Gas2Line.Restart()
            Gas1Line.Restart()
            Gasline5_Top.Restart()
            Gasline4_Top.Restart()
            Gasline3_Top.Restart()
            Gasline2_Top.Restart()
            Gasline4_Below.Restart()
            Gasline3_Below.Restart()
            Gasline2_Below.Restart()
            TotalGas1.Restart()
            GasMainDist.Restart()
            GasSecDist.Restart()

            Gas1Line_2.Restart()
            TotalGas1_2.Restart()
            Gas1Main1.Restart()
            Gas1Main2.Restart()

            Gas2Line_2.Restart()
            Gas3Line_2.Restart()
            Gas4Line_2.Restart()
            Gas5Line_2.Restart()

            GaslineSecSupply_Top.Restart()
            GaslineSecSupply_Bottom.Restart()
            GasSupplyToSec.Restart()
            Gas1MainToSec.Restart()
            GasSecDist_2.Restart()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-08-04 </date>
    ''' </author>
    ''' <summary>
    ''' Set gas lines status
    ''' </summary>
    Private Sub SetGaslineStatus()
        Try
            Gas1Line.Status = Utils.ConvertToDisplayStatus(Gas1ShutOffValve.Status)
            Gas2Line.Status = Utils.ConvertToDisplayStatus(Gas2ShutOffValve.Status)
            Gas3Line.Status = Utils.ConvertToDisplayStatus(Gas3ShutOffValve.Status)
            Gas4Line.Status = Utils.ConvertToDisplayStatus(Gas4ShutOffValve.Status)
            Gas5Line.Status = Utils.ConvertToDisplayStatus(Gas5ShutOffValve.Status)

            Gasline2_Below.Status = IIf(Gas2ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On OrElse _
                                      Gas3ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On OrElse _
                                      Gas4ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On OrElse _
                                      Gas5ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On, DisplayStatus.On, DisplayStatus.Off)
            Gasline2_Top.Status = Gasline2_Below.Status

            Gasline3_Below.Status = IIf(Gas3ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On OrElse _
                                        Gas4ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On OrElse _
                                        Gas5ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On, DisplayStatus.On, DisplayStatus.Off)
            Gasline3_Top.Status = Gasline3_Below.Status

            Gasline4_Below.Status = IIf(Gas4ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On OrElse _
                                        Gas5ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On, DisplayStatus.On, DisplayStatus.Off)
            Gasline4_Top.Status = Gasline4_Below.Status

            Gasline5_Top.Status = Gas5Line.Status

            TotalGas1.Status = IIf(Gas1ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On OrElse _
                                Gas2ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On OrElse _
                                Gas3ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On OrElse _
                                Gas4ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On OrElse _
                                Gas5ShutOffValve.Status = BinaryStatusControl.DisplayStatus.On, DisplayStatus.On, DisplayStatus.Off)

            If MainDistValve.Status = BinaryStatusControl.DisplayStatus.On Then
                GasMainDist.Status = TotalGas1.Status
            Else
                GasMainDist.Status = DisplayStatus.Off
            End If

            If SecDistValve.Status = BinaryStatusControl.DisplayStatus.On Then
                GasSecDist.Status = TotalGas1.Status
            Else
                GasSecDist.Status = DisplayStatus.Off
            End If

            If Me.SupportMainSecondDistributionValves Then
                Gas1Line_2.Status = Gas1Line.Status
                Gas2Line_2.Status = Gas2Line.Status
                Gas3Line_2.Status = Gas3Line.Status
                Gas4Line_2.Status = Gas4Line.Status
                Gas5Line_2.Status = Gas5Line.Status

                TotalGas1_2.Status = Gas1Line_2.Status

                Gas1Main1.Status = Gas1Line_2.Status

                If MainDistValve.Status = BinaryStatusControl.DisplayStatus.On Then
                    Gas1Main2.Status = Gas1Main1.Status
                Else
                    Gas1Main2.Status = AVPControls.AVPDataLib.DisplayStatus.Off
                End If

                If Gas2Line_2.Status = AVPControls.AVPDataLib.DisplayStatus.On OrElse Gas3Line_2.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
                    GaslineSecSupply_Top.Status = AVPControls.AVPDataLib.DisplayStatus.On
                Else
                    GaslineSecSupply_Top.Status = AVPControls.AVPDataLib.DisplayStatus.Off
                End If

                If Gas4Line_2.Status = AVPControls.AVPDataLib.DisplayStatus.On OrElse Gas5Line_2.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
                    GaslineSecSupply_Bottom.Status = AVPControls.AVPDataLib.DisplayStatus.On
                Else
                    GaslineSecSupply_Bottom.Status = AVPControls.AVPDataLib.DisplayStatus.Off
                End If

                If GaslineSecSupply_Top.Status = AVPControls.AVPDataLib.DisplayStatus.On OrElse GaslineSecSupply_Bottom.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
                    GasSupplyToSec.Status = AVPControls.AVPDataLib.DisplayStatus.On
                Else
                    GasSupplyToSec.Status = AVPControls.AVPDataLib.DisplayStatus.Off
                End If

                If Gas1Main2.Status = AVPControls.AVPDataLib.DisplayStatus.On OrElse GasSupplyToSec.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
                    Gas1MainToSec.Status = AVPControls.AVPDataLib.DisplayStatus.On
                Else
                    Gas1MainToSec.Status = AVPControls.AVPDataLib.DisplayStatus.Off
                End If

                If SecDistValve.Status = BinaryStatusControl.DisplayStatus.On Then
                    GasSecDist_2.Status = Gas1MainToSec.Status
                Else
                    GasSecDist_2.Status = AVPControls.AVPDataLib.DisplayStatus.Off
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#End Region

    Private Sub btnOverrideMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOverrideMode.Click
        Try
            Dim strValue As String = String.Empty
            If btnOverrideMode.Status = SL_CustomButton.DisplayStatus.Off Then
                strValue = STR_ON
            Else
                strValue = STR_OFF
            End If
            Dim objCoronaPanel As CoronaPanel = ContainerForm.ChamberPanel(m_stoStatusObject.Name)
            If objCoronaPanel Is Nothing Then
                objCoronaPanel = ContainerForm.ChamberPanel(m_stoStatusObject.Name)
                If objCoronaPanel Is Nothing Then
                    Exit Try
                End If
            End If
            Dim chamberName As String = String.Empty
            chamberName = AVPLib.Utils.chamberID2ChamberName(objCoronaPanel.Name)
            Dim Source As String = btnOverrideMode.TypeOfChamberSupport.ToString() & "." & btnOverrideMode.Name & "." & strValue
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + chamberName + "] " + btnOverrideMode.Text + " Button Click ")
            If Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                m_stoStatusObject.RequestStatus(btnOverrideMode.AccessibleName, strValue)
                If btnOverrideMode.Status = SL_CustomButton.DisplayStatus.On Then
                    objCoronaPanel.btnOverrideMode.Status = SL_CustomButton.DisplayStatus.Off
                    m_IsProtectedMode = False
                ElseIf btnOverrideMode.Status = SL_CustomButton.DisplayStatus.Off Then
                    objCoronaPanel.btnOverrideMode.Status = SL_CustomButton.DisplayStatus.On
                    m_IsProtectedMode = True
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    Private Sub txtCoronaChamberCurrentSlot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoronaChamberCurrentSlot.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If txtCoronaChamberCurrentSlot.Text <> String.Empty AndAlso Single.Parse(txtCoronaChamberCurrentSlot.Text) > 0.0F Then
                    Me.CoronaChamber.CurrentSlot = Convert.ToInt32(txtCoronaChamberCurrentSlot.Text)
                    AVPRobotMain.SetPMControlCurrentSlot(Me.Name, Convert.ToInt32(txtCoronaChamberCurrentSlot.Text))
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Lastindex As Integer = 0
    Private LastStatus As String = String.Empty
    Public Sub TurnOffPlasma(ByVal index As Integer, ByVal Status As String)
        Try
            Dim Last_Index As Integer = Lastindex
            If (Lastindex <> index) OrElse (LastStatus <> Status) Then
                Lastindex = index
                LastStatus = Status
            Else
                Dim plasmaOn As Boolean = False
                If Boolean.TryParse(Status, plasmaOn) Then
                    TurnTargetPlasmaInPMControl(Lastindex, plasmaOn)
                End If
                Exit Sub
            End If
            Dim value As BinaryStatusControl.DisplayStatus = BinaryStatusControl.DisplayStatus.Off
            Select Case Status
                Case "0"
                    value = BinaryStatusControl.DisplayStatus.Off
                Case "1"
                    value = BinaryStatusControl.DisplayStatus.On
                Case "2"
                    value = BinaryStatusControl.DisplayStatus.Unknown
            End Select
            If (index = 0) Then
                For i As Integer = 1 To 4
                    CType(Controls("Plasma" & i.ToString), ValveControl).Status = BinaryStatusControl.DisplayStatus.Off
                    TurnTargetPlasmaInPMControl(i, False)
                Next
            ElseIf (index > 0 AndAlso index < 5) Then
                CType(Controls("Plasma" & index.ToString), ValveControl).Status = value
                TurnTargetPlasmaInPMControl(index, (value = BinaryStatusControl.DisplayStatus.On))
                If Last_Index <> index AndAlso Last_Index > 0 Then
                    CType(Controls("Plasma" & Last_Index.ToString), ValveControl).Status = BinaryStatusControl.DisplayStatus.Off
                    TurnTargetPlasmaInPMControl(Last_Index, False)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-29 </date>
    ''' </author>
    ''' <summary>
    ''' Update PVD4 Target plasma status to PMControl
    ''' </summary>
    Private Sub TurnTargetPlasmaInPMControl(ByVal index As Integer, ByVal plasmaOn As Boolean)
        Try
            Dim objProcPM As PMControl = Nothing
            Dim objCassetPM As PMControl = Nothing
            AVPRobotMain.GetPMControl(Me.Name, objProcPM, objCassetPM)
            If objProcPM IsNot Nothing AndAlso objCassetPM IsNot Nothing Then
                Select Case index
                    Case 1
                        objProcPM.T1HasPlasma = plasmaOn
                        objCassetPM.T1HasPlasma = plasmaOn
                    Case 2
                        objProcPM.T2HasPlasma = plasmaOn
                        objCassetPM.T2HasPlasma = plasmaOn
                    Case 3
                        objProcPM.T3HasPlasma = plasmaOn
                        objCassetPM.T3HasPlasma = plasmaOn
                    Case 4
                        objProcPM.T4HasPlasma = plasmaOn
                        objCassetPM.T4HasPlasma = plasmaOn
                End Select

                objProcPM.Repaint()
                objCassetPM.Repaint()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Function IsHaveWaferInside(ByRef IsWaferComplete As Boolean) As Boolean

        Try
            Dim chamberName As String = Me.Name
            Dim equipment As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(chamberName)
            Dim waferInfo As enumWaferStatus
            Dim Count As Integer = 0
            If equipment IsNot Nothing Then
                For i As Integer = 1 To 8
                    waferInfo = equipment.GetWaferStatus(i)
                    If waferInfo = enumWaferStatus.eWaferComplete Then
                        Count += 1
                    End If
                    If waferInfo <> enumWaferStatus.eWaferNone And waferInfo <> enumWaferStatus.eWaferComplete Then
                        Return True
                    End If
                Next
            End If
            If Count > 0 Then
                IsWaferComplete = True
            Else
                IsWaferComplete = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    Public Property WaterPumpInstalled() As Boolean
        Get
            Return WaterPumpVisible
        End Get
        Set(ByVal value As Boolean)
            WaterPumpVisible = value
        End Set
    End Property

    Public Property VatControlVisible() As Boolean
        Get
            Return m_blnVatControlVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnVatControlVisible = value
            VatValveController.Visible = value
            If Not value Then
                ProcessMonitor.Top = GasController.Top + GasController.Height
                RunRecipe.Top = ProcessMonitor.Top + ProcessMonitor.Height
            End If
        End Set
    End Property

    Public Property HeaterVisible() As Boolean
        Get
            Return m_blnHeaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnHeaterVisible = value
            HeaterControl.Visible = value
            If Not value Then
                If Not VatControlVisible Then
                    ProcessMonitor.Top = GasController.Top + GasController.Height
                Else
                    VatValveController.Top = GasController.Top + GasController.Height
                    ProcessMonitor.Top = VatValveController.Top + VatValveController.Height + 2
                End If
                RunRecipe.Top = ProcessMonitor.Top + ProcessMonitor.Height
            End If
        End Set
    End Property

    Public WriteOnly Property Heater1Visible() As Boolean
        Set(ByVal value As Boolean)
            HeaterControl.btnHeaterZone1Status.Visible = value
            HeaterControl.Label2.Visible = value
            HeaterControl.txtHeaterZone1SP.Visible = value
            HeaterControl.txtHeaterZone1RB.Visible = value
            If Not value Then
                HeaterControl.btnHeaterZone2Status.Top = HeaterControl.btnHeaterZone1Status.Top
                HeaterControl.Label3.Top = HeaterControl.Label2.Top
                HeaterControl.txtHeaterZone2SP.Top = HeaterControl.txtHeaterZone1SP.Top
                HeaterControl.txtHeaterZone2RB.Top = HeaterControl.txtHeaterZone1RB.Top
            End If
        End Set
    End Property

    Public WriteOnly Property Heater2Visible() As Boolean
        Set(ByVal value As Boolean)
            HeaterControl.btnHeaterZone2Status.Visible = value
            HeaterControl.Label3.Visible = value
            HeaterControl.txtHeaterZone2SP.Visible = value
            HeaterControl.txtHeaterZone2RB.Visible = value
        End Set
    End Property

    Public Sub SetMaintenanceMode(ByVal blnEditable As Boolean, ByVal blnMaintenanceMode As Boolean)
        m_IsMaintenanceMode = blnMaintenanceMode
        m_IsEditable_InMaintenanceMode = blnEditable
        If blnMaintenanceMode Then
            IsOnline = False
            If blnEditable Then
                If AVPLib.ContainerData.Permission(PERMISSION_001) Then
                    ActiveForm()
                End If
            Else
                InactiveForm()
            End If
            CoronaChamber.SetOnlineOfflineContainerBox(Not blnEditable)
            m_PopUpPanel.SetOnlineOfflinePopUp(Not blnEditable)
            m_CryoPopUpPanel.DeviceOnline = Not blnEditable
        Else
            If AVPLib.ContainerData.Permission(PERMISSION_001) Then
                ActiveForm()
                CoronaChamber.SetOnlineOfflineContainerBox(False)
                m_PopUpPanel.SetOnlineOfflinePopUp(False)
                m_CryoPopUpPanel.DeviceOnline = False
            End If
        End If
    End Sub

    Private Sub lblDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDisconnect.Click
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize AndAlso lblDisconnect.Tag Then
                Dim chamberName As String = AVPLib.Utils.chamberID2ChamberName(Me.Name)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + chamberName + "] " + lblDisconnect.Text + " Click ")
                If (Utils.ShowAVPMessageBox("Do you want to connect to " & chamberName & " ?", chamberName & " Reconnect", _
                                            MessageBoxIcon.Question) = DialogResult.OK) Then
                    ContainerForm.ChamberPanel(Me.Name).btnReConnect_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub PressureCG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then

                Dim objChamber As AVPLib.DataManagerment.CoronaChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
                If m_CGGaugesFrm IsNot Nothing Then
                    m_CGGaugesFrm.IsSetATM = IIf(objChamber.ATMChamberCGStatus = Equipment.WorkingStatuses.On, True, False)
                    m_CGGaugesFrm.IsSetVAC = IIf(objChamber.VACChamberCGStatus = Equipment.WorkingStatuses.On, True, False)
                    m_CGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
                    m_CGGaugesFrm.ShowDialog(AVPRobotMain)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub NewConvectronGaugeFrm(ByVal chambername As String)
        m_CGGaugesFrm = New CGGaugesFrm(True, False, True, True)
        m_CGGaugesFrm.Name = AVPLib.ConstEnum.PRESSURE & AVPLib.ConstEnum.CG_IG_FORM
        m_CGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_CGGaugesFrm.ShowInTaskbar = False
        m_CGGaugesFrm.ShowIcon = False
        m_CGGaugesFrm.Text = chambername & " " & AVPLib.ConstEnum.PRESSURE
        m_CGGaugesFrm.Hide()
    End Sub

    Private Sub NewRPConvectronGaugeFrm(ByVal chambername As String)
        m_RPCGGaugesFrm = New CGGaugesFrm(False, True, False)
        m_RPCGGaugesFrm.Name = AVPLib.ConstEnum.ROUGHLINE & AVPLib.ConstEnum.CG_IG_FORM
        m_RPCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_RPCGGaugesFrm.ShowInTaskbar = False
        m_RPCGGaugesFrm.ShowIcon = False
        m_RPCGGaugesFrm.Text = chambername & " " & AVPLib.ConstEnum.ROUGHPUMP
        m_RPCGGaugesFrm.PumpStatus = IIf(MechanicalPump.Status = BinaryStatusControl.DisplayStatus.On, Equipment.WorkingStatuses.On, Equipment.WorkingStatuses.Off)
        m_RPCGGaugesFrm.Hide()
    End Sub

    Private Sub NewFLConvectronGaugeFrm(ByVal chambername As String)
        m_FLCGGaugesFrm = New CGGaugesFrm(False, False, False)
        m_FLCGGaugesFrm.Text = chambername & " " & AVPLib.ConstEnum.FORELINE
        m_FLCGGaugesFrm.Name = AVPLib.ConstEnum.FORELINE & AVPLib.ConstEnum.CG_IG_FORM
        m_FLCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_FLCGGaugesFrm.ShowInTaskbar = False
        m_FLCGGaugesFrm.ShowIcon = False
        m_FLCGGaugesFrm.Hide()
    End Sub

    Private Sub txtForelineCG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtForelineCG.Click
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            If txtForelineCG.Clickable = False Then
                Return
            End If
            Dim objChamber As AVPLib.DataManagerment.CoronaChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
            If m_FLCGGaugesFrm IsNot Nothing AndAlso objChamber IsNot Nothing Then
                m_FLCGGaugesFrm.IsSetATM = IIf(objChamber.ATMForelineCGStatus = Equipment.WorkingStatuses.On, True, False)
                m_FLCGGaugesFrm.ShowDialog(AVPRobotMain)
            End If
        End If
    End Sub

    Private Sub MechanicalPump_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MechanicalPump.Click
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            If MechanicalPump.Enabled = False Then
                Return
            End If
            Dim objChamber As AVPLib.DataManagerment.CoronaChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
            If m_RPCGGaugesFrm IsNot Nothing AndAlso objChamber IsNot Nothing Then
                m_RPCGGaugesFrm.IsSetATM = IIf(objChamber.ATMMechanicalPumpCGStatus = Equipment.WorkingStatuses.On, True, False)
                m_RPCGGaugesFrm.ShowDialog(AVPRobotMain)
            End If
        End If
    End Sub

    Private Sub MechanicalPump_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles MechanicalPump.StatusChange
        If m_RPCGGaugesFrm IsNot Nothing Then
            m_RPCGGaugesFrm.PumpStatus = IIf(MechanicalPump.Status = BinaryStatusControl.DisplayStatus.On, Equipment.WorkingStatuses.On, Equipment.WorkingStatuses.Off)
        End If
        Dim gaslineStatus As DisplayStatus = Utils.ConvertToDisplayStatus(MechanicalPump.Status.ToString())
        ValveRoughLine.Status = gaslineStatus
        RoughForeLine.Status = gaslineStatus
        If ValveRough.Status = BinaryStatusControl.DisplayStatus.On Then
            ValveRoughLineOut.Status = gaslineStatus
        End If
        If ValveForeline.Status = BinaryStatusControl.DisplayStatus.On Then
            ValveForelineLine.Status = gaslineStatus
        End If
    End Sub

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-07-10</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub txtWaterPump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWaterPump.Click, btnWP.Click, WPHeader.Click
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Dim objConfigChamber As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.Name)
                CryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                CryoPopUpPanel.RegenParamSupport = objConfigChamber.RegenParamSupport
                CryoPopUpPanel.ShowDialog(AVPRobotMain)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#Region "Public"
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-04-15</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub GetGasEndIndex()

        If Gas5Visible Then
            m_iGasEndIndex = 5
        ElseIf Gas4Visible Then
            m_iGasEndIndex = 4
            Gas4Line.OffImage = AVP_Robot_Project.My.Resources.Resources.PVD4_Gasline_Curve_Off
            Gas4Line.OnImage0 = AVP_Robot_Project.My.Resources.Resources.PVD4_Gasline_Curve_On
            Gas4Line.OnImage1 = AVP_Robot_Project.My.Resources.Resources.PVD4_Gasline_Curve_On1
            Gas5Line.Visible = False
            Gasline5_Top.Visible = False
            Gasline4_Below.Visible = False
            Gas4Line.Location = New Point(Gasline4_Below.Location.X, Gasline4_Below.Location.Y)
        ElseIf Gas3Visible Then
            m_iGasEndIndex = 3
            Gas3Line.OffImage = AVP_Robot_Project.My.Resources.Resources.PVD4_Gasline_Curve_Off
            Gas3Line.OnImage0 = AVP_Robot_Project.My.Resources.Resources.PVD4_Gasline_Curve_On
            Gas3Line.OnImage1 = AVP_Robot_Project.My.Resources.Resources.PVD4_Gasline_Curve_On1
            Gas4Line.Visible = False
            Gasline4_Top.Visible = False
            Gasline3_Below.Visible = False
            Gas3Line.Location = New Point(Gasline3_Below.Location.X, Gasline3_Below.Location.Y)
        ElseIf Gas2Visible Then
            m_iGasEndIndex = 2
            Gas2Line.OffImage = AVP_Robot_Project.My.Resources.Resources.PVD4_Gasline_Curve_Off
            Gas2Line.OnImage0 = AVP_Robot_Project.My.Resources.Resources.PVD4_Gasline_Curve_On
            Gas2Line.OnImage1 = AVP_Robot_Project.My.Resources.Resources.PVD4_Gasline_Curve_On1
            Gas3Line.Visible = False
            Gasline3_Top.Visible = False
            Gasline2_Below.Visible = False
            Gas2Line.Location = New Point(Gasline2_Below.Location.X, Gasline2_Below.Location.Y)
        ElseIf Gas1Visible Then
            m_iGasEndIndex = 1
            Gas5Line.Visible = False
            Gas4Line.Visible = False
            Gas3Line.Visible = False
            Gas2Line.Visible = False

            Gasline5_Top.Visible = False
            Gasline4_Top.Visible = False
            Gasline3_Top.Visible = False
            Gasline2_Top.Visible = False

            Gasline4_Below.Visible = False
            Gasline3_Below.Visible = False
            Gasline2_Below.Visible = False
        End If
    End Sub

#End Region

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-31 </date>
    ''' </author>
    ''' <summary>
    ''' Update plasma status to PMControl
    ''' </summary>
    ''' <value></value>
    Private Sub CoronaChamber_PlasmaStatusChanged(ByVal sender As System.Object) Handles CoronaChamber.PlasmaStatusChanged
        Try
            Utils.ChangeBiasPlasmaControlStatus(Me.Name, CoronaChamber.BiasPlasmaOn)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-31 </date>
    ''' </author>
    ''' <summary>
    ''' Update target plasma status to PMControl
    ''' </summary>
    ''' <value></value>
    Private Sub CoronaTarget_StatusChanged(ByVal sender As Object, ByVal targetIndex As PVD4TargetControl.TargetIndexs) Handles CoronaTarget.StatusChanged
        Try
            TurnTargetPlasmaInPMControl(targetIndex, (CoronaTarget.TargetStatus = DisplayStatus.On))
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-08-04 </date>
    ''' </author>
    ''' <summary>
    ''' Update target status when target switched
    ''' </summary>
    ''' <value></value>
    Private Sub RFTargetPowerSupply_TargetSwitched(ByVal targetSelectedIndex As AVP_Robot_Project.PVD4TargetControl.TargetIndexs) Handles RFTargetPowerSupply.TargetSwitched
        Try
            CoronaTarget.ActiveTarget = targetSelectedIndex
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-06-27 </date>
    ''' </author>
    ''' <summary>
    ''' Resize RFTargetPowerSupply.
    ''' </summary>
    ''' <value></value>
    Public Sub ResizeRFTargetPowerSuply()
        Try
            If RFTargetPowerSupply.ISShowPulse = True Then
                RFTargetPowerSupply.Size = New System.Drawing.Size(325, 240)
            Else
                RFTargetPowerSupply.Size = New System.Drawing.Size(325, 219)
            End If
            BiasPowerSupply.Top = RFTargetPowerSupply.Top + RFTargetPowerSupply.Height
            PVD4Interlock.Top = BiasPowerSupply.Top + BiasPowerSupply.Height
            Me.lblStatusText.Location = New Point(0, 740)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''   	<name>Dung Pham</name>
    '''   	<date> 2018-12-10</date>
    ''' </author>
    ''' <summary>
    ''' Status IG Changed.
    ''' </summary>
    Private Sub StatusIGChanged(ByVal status As Boolean)
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If m_CGGaugesFrm IsNot Nothing Then
                    m_CGGaugesFrm.UpdateIGStatus(status)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''   	<name>Dung Pham</name>
    '''   	<date> 2018-12-10</date>
    ''' </author>
    ''' <summary>
    ''' txtSwitchIGFilament_TextChanged.
    ''' </summary>
    Private Sub txtSwitchIGFilament_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSwitchIGFilament.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If m_CGGaugesFrm IsNot Nothing Then
                    Dim isIGOn As Double = 0
                    Double.TryParse(txtSwitchIGFilament.Text, isIGOn)
                    m_CGGaugesFrm.UpdateSwitchIGFilament(isIGOn)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''   	<name>Dung Pham</name>
    '''   	<date> 2018-12-10</date>
    ''' </author>
    ''' <summary>
    ''' txtEnableIGFilament_TextChanged.
    ''' </summary>
    Private Sub txtEnableIGFilament_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEnableIGFilament.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If m_CGGaugesFrm IsNot Nothing Then
                    Dim isEnable As Boolean = IIf(txtEnableIGFilament.Text = "0", True, False)
                    m_CGGaugesFrm.UpdateEnableIGFilament(isEnable)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub CoronaTarget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoronaTarget.Click
        If Not IsOnline Then
            PMSystemSetupPopUpPanel.ShowDialog(AVPRobotMain)
        End If
    End Sub

    Private Sub CoronaPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CreateSystemSetupPopUpPanel(m_SystemSetupPopUpPanel)
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2023-12-27</date>
    ''' <summary>
    ''' Call this function after setting all configs
    ''' </summary>
    Public Sub UpdateGUISetting()
        Try
            Dim shouldVisible As Boolean = Not Me.GasInjectionVisible OrElse Me.SupportMainSecondDistributionValves
            If Not shouldVisible Then
                TotalGas1.OffImage = AVP_Robot_Project.My.Resources.Resources.PVD4_InjectionGasLine
                TotalGas1.OnImage0 = AVP_Robot_Project.My.Resources.Resources.PVD4_InjectionGasLine_On
                TotalGas1.OnImage1 = AVP_Robot_Project.My.Resources.Resources.PVD4_InjectionGasLine_On1
                lblMainDist.Visible = False
                lblSecDist.Visible = False
                MainDistValve.Visible = False
                SecDistValve.Visible = False
                GasSecDist.Visible = False
                GasMainDist.Visible = False
            Else
                lblCurrentPurgeCycle.Location = lblInjection.Location
                lblInjection.Visible = False
            End If

            Dim visibleMainAndSecondGaslines As Boolean = Me.GasInjectionVisible AndAlso Me.SupportMainSecondDistributionValves

            TotalGas1_2.Visible = visibleMainAndSecondGaslines AndAlso Gas1Visible
            Gas1Main1.Visible = visibleMainAndSecondGaslines AndAlso Gas1Visible
            Gas1Main2.Visible = visibleMainAndSecondGaslines AndAlso Gas1Visible
            Gas1MainToSec.Visible = visibleMainAndSecondGaslines
            GasSecDist_2.Visible = visibleMainAndSecondGaslines
            GasSupplyToSec.Visible = visibleMainAndSecondGaslines
            GaslineSecSupply_Top.Visible = visibleMainAndSecondGaslines
            GaslineSecSupply_Bottom.Visible = visibleMainAndSecondGaslines
            Gas1Line_2.Visible = visibleMainAndSecondGaslines AndAlso Gas1Visible
            Gas2Line_2.Visible = visibleMainAndSecondGaslines AndAlso Gas2Visible
            Gas3Line_2.Visible = visibleMainAndSecondGaslines AndAlso Gas3Visible
            Gas4Line_2.Visible = visibleMainAndSecondGaslines AndAlso Gas4Visible
            Gas5Line_2.Visible = visibleMainAndSecondGaslines AndAlso Gas5Visible

            If visibleMainAndSecondGaslines Then
                SetLayout2()
                GasMainDist.Visible = False
                TotalGas1.Visible = False
                Gas1Line.Visible = False
                GasSecDist.Visible = False
                Gasline2_Top.Visible = False
                Gasline2_Below.Visible = False
                Gasline3_Top.Visible = False
                Gasline3_Below.Visible = False
                Gasline4_Top.Visible = False
                Gasline4_Below.Visible = False
                Gasline5_Top.Visible = False
                Gas5Line.Visible = False
                Gas4Line.Visible = False
                Gas3Line.Visible = False
                Gas2Line.Visible = False
                MainDistValve.Visible = Gas1Visible
                lblMainDist.Visible = Gas1Visible
            Else
                SetLayout1()
                Gas1Line.Visible = Gas1Visible
                Gas2Line.Visible = Gas2Visible
                Gas3Line.Visible = Gas3Visible
                Gas4Line.Visible = Gas4Visible
                Gas5Line.Visible = Gas5Visible
                Gasline5_Top.Visible = Gas5Visible

                If Not Gas2Visible And Not Gas5Visible And Not Gas4Visible And Not Gas3Visible Then
                    Gasline2_Below.Visible = Gas2Visible
                    Gasline3_Top.Visible = Gas2Visible
                End If

                If Not Gas3Visible And Not Gas5Visible And Not Gas4Visible Then
                    Gasline3_Below.Visible = Gas3Visible
                    Gasline4_Top.Visible = Gas3Visible
                End If

                If Not Gas4Visible And Not Gas5Visible Then
                    Gasline4_Below.Visible = Gas4Visible
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub SetLayout1()
        Try
            lblMainDist.Location = New Point(639, 136)
            MainDistValve.Location = New Point(730, 127)
            lblSecDist.Location = New Point(769, 136)
            SecDistValve.Location = New Point(843, 127)

            lblCurrentPurgeCycle.Location = New Point(755, 94)
            lblCurrentPurgeCycle.Size = New Size(124, 14)
            lblNameOfSequenceRunning.Location = New Point(504, 93)
            lblNameOfSequenceRunning.Size = New Size(234, 33)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub SetLayout2()
        Try
            SecDistValve.OffImage = My.Resources.Resources.New_Valve_Closed
            SecDistValve.OnImage = My.Resources.Resources.New_Valve_Opened

            lblMainDist.Location = lblMainDist_2.Location
            MainDistValve.Location = New Point(843, 107)
            lblSecDist.Location = lblSecDist_2.Location
            SecDistValve.Location = New Point(800, 153)

            lblCurrentPurgeCycle.Location = New Point(561, 132)
            lblCurrentPurgeCycle.Size = New Size(177, 14)
            lblNameOfSequenceRunning.Location = New Point(561, 93)
            lblNameOfSequenceRunning.Size = New Size(177, 33)

            If Not Gas5Visible Then
                GaslineSecSupply_Bottom.Visible = False

                If Gas4Visible Then
                    Gas4Line_2.OffImage = My.Resources.Resources.PVD4_2Gasline_BottomCurve2_Off
                    Gas4Line_2.OnImage0 = My.Resources.Resources.PVD4_2Gasline_BottomCurve2_On
                    Gas4Line_2.OnImage1 = My.Resources.Resources.PVD4_2Gasline_BottomCurve2_On1

                    Gas4Line_2.Location = New Point(880, 169)
                Else
                    GaslineSecSupply_Top.OffImage = My.Resources.Resources.PVD4_2GaslineSecSupply_Top2_Off
                    GaslineSecSupply_Top.OnImage0 = My.Resources.Resources.PVD4_2GaslineSecSupply_Top2_On
                    GaslineSecSupply_Top.OnImage1 = My.Resources.Resources.PVD4_2GaslineSecSupply_Top2_On1

                    GasSupplyToSec.OffImage = My.Resources.Resources.PVD4_2GasSupplyToSec2_Off
                    GasSupplyToSec.OnImage0 = My.Resources.Resources.PVD4_2GasSupplyToSec2_On
                    GasSupplyToSec.OnImage1 = My.Resources.Resources.PVD4_2GasSupplyToSec2_On1
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class

