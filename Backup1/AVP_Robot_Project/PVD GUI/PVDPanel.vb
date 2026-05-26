Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ContainerData
Imports AVPLib.ConstEnum
Imports AVPLib
Public Class PVDPanel
#Region "Class Constants & Variables"
    Private m_PopUpPanel As PopUpPanel = Nothing
    Private m_CryoPopUpPanel As CryoPopUpPanel = Nothing
    Private TimeWait As Integer = 60
    Private TimeWaiting As Integer = 0
    Private ValveRingClicked As Boolean = False
    Private HivacValveStatus As String = BinaryStatusControl.DisplayStatus.Off.ToString()
    Friend Shared m_Current_Status_Fixture As String = AVPLib.ConfigurationValues.DEVICE_CONTINUOUS
    '''For Visible Equipment
    Private m_blnHasShutter As Boolean = False
    Private m_blnTurboPumpVisible As Boolean = False ''Turbo Pump Control is visible or not
    Private m_blnWaterPumpVisible As Boolean = False ''Water Pump Control is visible or not
    Private m_blnTurboMPInstalled As Boolean = False ''Turbo MP Textbox  is visible or not
    Private m_blnCryoVisible As Boolean = False ''Cryo Control is visible or not
    Private m_blnMGVisible As Boolean = False ''MG Control is visible or not
    Private m_blnManatronVisible As Boolean = False ''Manatron Control is visible or not
    Private m_blnParallelMagneVisible As Boolean = False ''Manatron Control is visible or not
    Private m_blnChamberInterlock_TargetVisible As Boolean = False 'Extra Interlock has 8 interlock
    Private m_blnChamberInterlock_TurboVisible As Boolean = False 'Extra Interlock has 8 interlock
    Private m_blnChuckTableWater_Visible As Boolean = False
    Private m_blnChamberLid_Visible As Boolean = False
    Private m_strTitle As String = String.Empty
    Private m_strGasLine1Name As String = String.Empty
    Private m_strGasLine2Name As String = String.Empty
    Private m_strGasLine3Name As String = String.Empty
    Private m_strGasLine4Name As String = String.Empty
    Private m_strGasLine5Name As String = String.Empty
    Private m_strGasLine1Type As String = String.Empty
    Private m_strGasLine2Type As String = String.Empty
    Private m_strGasLine3Type As String = String.Empty
    Private m_strGasLine4Type As String = String.Empty
    Private m_strGasLine5Type As String = String.Empty
    Const TITLE As String = ": MAINTENANCE"
    Private m_blnRFIsTargetPowerSupply As Boolean = False
    Private m_blnDCIsTargetPowerSupply As Boolean = False
    Private m_blnClampInStall As Boolean = False
    Protected m_RFTargetPowerModel As AVPLib.SystemModule.Power_Supply_Model = SystemModule.Power_Supply_Model.ENI_1250
    Protected m_DCTargetPowerModel As AVPLib.SystemModule.Power_Supply_Model = SystemModule.Power_Supply_Model.ENI_1250
    Protected m_BiasPowerModel As AVPLib.SystemModule.Power_Supply_Model = SystemModule.Power_Supply_Model.ENI_1250
    Friend WithEvents mnuMachineIGDegas As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMachinePumpPurge As System.Windows.Forms.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Private m_blnBiasPowerSupplyVisible As Boolean = True
    Private m_blnWaterValveVisible As Boolean = True
    Private m_blnMainGas_ShutOff_Visible As Boolean = True
    Private m_CGGaugesFrm As CGGaugesFrm = Nothing
    Private m_RPCGGaugesFrm As CGGaugesFrm = Nothing
    Private m_FLCGGaugesFrm As CGGaugesFrm = Nothing
    Private m_bPM_DeviceNet As Boolean = False
#End Region

#Region "Property"
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
    Public ReadOnly Property PVDPopUpPanel() As PopUpPanel
        Get
            Return m_PopUpPanel
        End Get
    End Property

    Public ReadOnly Property CryoPopUpPanel() As CryoPopUpPanel
        Get
            Return m_CryoPopUpPanel
        End Get
    End Property

    Public Overridable Property BiasPowerSupplyVisible() As Boolean
        Get
            Return m_blnBiasPowerSupplyVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnBiasPowerSupplyVisible = value
            If value = False Then
                ChamberInterlock.Location = BiasPowerSupply.Location
            End If
        End Set
    End Property

    Public Overridable Property RFTargetPowerModel() As SystemModule.Power_Supply_Model
        Get
            Return m_RFTargetPowerModel
        End Get
        Set(ByVal value As SystemModule.Power_Supply_Model)
            m_RFTargetPowerModel = value
        End Set
    End Property

    Public Overridable Property DCTargetPowerModel() As SystemModule.Power_Supply_Model
        Get
            Return m_DCTargetPowerModel
        End Get
        Set(ByVal value As SystemModule.Power_Supply_Model)
            m_DCTargetPowerModel = value
        End Set
    End Property

    Public Overridable Property BiasPowerModel() As SystemModule.Power_Supply_Model
        Get
            Return m_BiasPowerModel
        End Get
        Set(ByVal value As SystemModule.Power_Supply_Model)
            m_BiasPowerModel = value
        End Set
    End Property

    Public Overridable Property ClampInstall() As Boolean
        Get
            Return m_blnClampInStall
        End Get
        Set(ByVal value As Boolean)
            m_blnClampInStall = value
            Me.ChuckControl.ClampInstall = value
        End Set
    End Property

    Public Overridable Property GasLine1Name() As String
        Get
            Return m_strGasLine1Name
        End Get
        Set(ByVal value As String)
            m_strGasLine1Name = value
            '  Me.GasController.Gas1Name = m_strGasLine1Name
        End Set
    End Property

    Public Overridable Property GasLine1Type() As String
        Get
            Return m_strGasLine1Type
        End Get
        Set(ByVal value As String)
            m_strGasLine1Type = value
            Me.GasController.Gas1Name = m_strGasLine1Type
        End Set
    End Property

    Public Overridable Property GasLine2Name() As String
        Get
            Return m_strGasLine2Name
        End Get
        Set(ByVal value As String)
            m_strGasLine2Name = value
            'Me.GasController.Gas2Name = m_strGasLine2Name
        End Set
    End Property

    Public Overridable Property GasLine2Type() As String
        Get
            Return m_strGasLine2Type
        End Get
        Set(ByVal value As String)
            m_strGasLine2Type = value
            Me.GasController.Gas2Name = m_strGasLine2Type
        End Set
    End Property

    Public Overridable Property GasLine3Name() As String
        Get
            Return m_strGasLine3Name
        End Get
        Set(ByVal value As String)
            m_strGasLine3Name = value
            '    Me.GasController.Gas3Name = m_strGasLine3Name
        End Set
    End Property

    Public Overridable Property GasLine3Type() As String
        Get
            Return m_strGasLine3Type
        End Get
        Set(ByVal value As String)
            m_strGasLine3Type = value
            Me.GasController.Gas3Name = m_strGasLine3Type
        End Set
    End Property

    Public Overridable Property GasLine4Name() As String
        Get
            Return m_strGasLine4Name
        End Get
        Set(ByVal value As String)
            m_strGasLine4Name = value
            'Me.GasController.Gas4Name = m_strGasLine4Name
        End Set
    End Property

    Public Overridable Property GasLine4Type() As String
        Get
            Return m_strGasLine4Type
        End Get
        Set(ByVal value As String)
            m_strGasLine4Type = value
            Me.GasController.Gas4Name = m_strGasLine4Type
        End Set
    End Property

    Public Overridable Property GasLine5Name() As String
        Get
            Return m_strGasLine5Name
        End Get
        Set(ByVal value As String)
            m_strGasLine5Name = value
            'Me.GasController.Gas5Name = m_strGasLine5Name
        End Set
    End Property

    Public Overridable Property GasLine5Type() As String
        Get
            Return m_strGasLine5Type
        End Get
        Set(ByVal value As String)
            m_strGasLine5Type = value
            Me.GasController.Gas5Name = m_strGasLine5Type
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Has Shutter or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Property ShutterVisible() As Boolean
        Get
            Return m_blnHasShutter
        End Get
        Set(ByVal value As Boolean)
            m_blnHasShutter = value
            Me.ChuckControl.ShutterStatus = IIf(m_blnHasShutter, BinaryStatusControl.DisplayStatus.On, BinaryStatusControl.DisplayStatus.Off)
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Turbo Pump Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Property TurboPumpVisible() As Boolean
        Get
            Return m_blnTurboPumpVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTurboPumpVisible = value
            m_blnWaterPumpVisible = value
            If m_blnTurboPumpVisible Then
                m_CryoPopUpPanel.TypeOfCryoPanel = AVP_Robot_Project.CryoPopUpPanel.CryoPanelType.WaterPumpPanel
                m_blnCryoVisible = False
                Me.SetCryoPumpControlVisible()
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Turbo Pump Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Property TurboMPInstalled() As Boolean
        Get
            Return m_blnTurboMPInstalled
        End Get
        Set(ByVal value As Boolean)
            m_blnTurboMPInstalled = value
            txtRoughLineCG.Visible = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Cryo Control Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Property CryoControlVisible() As Boolean
        Get
            Return m_blnCryoVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnCryoVisible = value
            If m_blnCryoVisible Then
                m_blnTurboPumpVisible = False
                m_blnWaterPumpVisible = False
                Me.SetCryoPumpControlVisible()
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Cryo Control Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Property WaterValveVisible() As Boolean
        Get
            Return m_blnWaterValveVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnWaterValveVisible = value
            GasLine_Water.Visible = m_blnWaterValveVisible
            ValveWater.Visible = m_blnWaterValveVisible
            Label5.Visible = m_blnWaterValveVisible
        End Set
    End Property

    Public Overridable Property MainGas_Visible() As Boolean
        Get
            Return m_blnMainGas_ShutOff_Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnMainGas_ShutOff_Visible = value
            If value Then
                GasLine_Total.OnImage = AVP_Robot_Project.My.Resources.Resources.Gasline_MainGas_On
                GasLine_Total.OffImage = AVP_Robot_Project.My.Resources.Resources.Gasline_MainGas
            Else
                GasLine_Total.OnImage = AVP_Robot_Project.My.Resources.Resources.GasLine_withoutMainGasOn
                GasLine_Total.OffImage = AVP_Robot_Project.My.Resources.Resources.GasLine_withoutMainGas
            End If
            ValveMainGas.Visible = value
            lblMainGas.Visible = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set MG Control is visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Property IsMGVisible() As Boolean
        Get
            Return m_blnMGVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnMGVisible = value
            If m_blnMGVisible Then
                Me.MGInformation.Visible = True
            Else
                Me.MGInformation.Visible = False
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Magnatron is visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Property ManatronVisible() As Boolean
        Get
            Return m_blnManatronVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnManatronVisible = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Magnatron is visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Property ParallelMagnetVisible() As Boolean
        Get
            Return m_blnParallelMagneVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnParallelMagneVisible = value
            If m_blnParallelMagneVisible Then
                Me.ParallelMagnet.Visible = True
            Else
                Me.ParallelMagnet.Visible = False
            End If
        End Set
    End Property
    '''' <author>
    ''''    	<name>Tran Ngoc Khiet </name>
    ''''    	<date> 2009-09-11</date>
    '''' </author>
    '''' <summary>
    '''' Check Current_Status_Fixture
    '''' </summary>
    '''' <remarks></remarks>
    Public Overridable Property Current_Status_Fixture() As String
        Get
            Return m_Current_Status_Fixture
        End Get
        Set(ByVal value As String)
            m_Current_Status_Fixture = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Target Power Supply is visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Property RFTargetPowerSupplyVisible() As Boolean
        Get
            Return m_blnRFIsTargetPowerSupply
        End Get
        Set(ByVal value As Boolean)
            m_blnRFIsTargetPowerSupply = value
        End Set
    End Property
    Public Overridable Property DCTargetPowerSupplyVisible() As Boolean
        Get
            Return m_blnDCIsTargetPowerSupply
        End Get
        Set(ByVal value As Boolean)
            m_blnDCIsTargetPowerSupply = value
        End Set
    End Property

    Public Property PM_DeviceNet() As Boolean
        Get
            Return m_bPM_DeviceNet
        End Get
        Set(ByVal value As Boolean)
            m_bPM_DeviceNet = value
        End Set
    End Property
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub CheckPermission(ByVal permission_code As String)
        If AVPLib.ContainerData.Permission(permission_code) Then
            Active_InActiveForm(True)
        Else
            Active_InActiveForm(False)
        End If
    End Sub
    Public Overridable Sub OnStartProcessing()
        Me.BiasPowerSupply.StartProcessing()
        Me.VatValveController.StartProcessing()
        Me.ChuckControl.StartProcessing()
        Me.GasController.StartProcessing()
        Me.ParallelMagnet.StartProcessing()
        Me.Baratron.StartProcessing()
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
                    Me.ChuckControl.ValveSlit.Status = DisplayStatus.On
                Case SlitValve.SlitValveDisplayStatus.Off
                    Me.ChuckControl.ValveSlit.Status = DisplayStatus.Off
                Case Else
                    Me.ChuckControl.ValveSlit.Status = DisplayStatus.Unknow
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            MyBase.CreateStatusTree()
            Dim sbcConnectionStatus As New StatusIGCGButton(btnReConnect)
            Dim sbcbuttonIGCGStatus As New StatusIGCGButton(btnHivacValve)
            Dim sbcRoughLineCGStatus As New StatusTextBox(txtRoughLineCG)
            Dim sbcForeLineStatus As New StatusTextBox(txtForeLineCG)
            Dim sbcRoughPumpStatus As New StatusBinaryStatusControl(RoughPump)
            Dim sbcOverrideModeStatus As New StatusIGCGButton(btnOverrideMode)

            Dim sbcGasLineShutOff1Status As New StatusBinaryStatusControl(GasLine_ShutOff1)
            Dim sbcGasLineShutOff2Status As New StatusBinaryStatusControl(GasLine_ShutOff2)
            Dim sbcGasLineShutOff3Status As New StatusBinaryStatusControl(GasLine_ShutOff3)
            Dim sbcGasLineShutOff4Status As New StatusBinaryStatusControl(GasLine_ShutOff4)
            Dim sbcGasLineShutOff5Status As New StatusBinaryStatusControl(GasLine_ShutOff5)
            Dim sbcGasLineSupply5Status As New StatusBinaryStatusControl(GasLine_Supply5)
            Dim sbcGasLineSupply4Status As New StatusBinaryStatusControl(GasLine_Supply4)
            Dim sbcGasLineSupply3Status As New StatusBinaryStatusControl(GasLine_Supply3)
            Dim sbcGasLineSupply2Status As New StatusBinaryStatusControl(GasLine_Supply2)
            Dim sbcGasLineSupply1Status As New StatusBinaryStatusControl(GasLine_Supply1)
            Dim sbcMainGasLineStatus As New StatusBinaryStatusControl(GasLine_Total)

            Dim sbcMainGasValveStatus As New StatusBinaryStatusControl(ValveMainGas)
            Dim sbcWaterValveStatus As New StatusBinaryStatusControl(ValveWater)
            Dim sbcGasLineBaratronStatus As New StatusBinaryStatusControl(GasLine_Baratron)
            Dim sbcGasLineVentStatus As New StatusBinaryStatusControl(GasLine_Vent)
            Dim sbcGasLineRoughPumpStatus As New StatusBinaryStatusControl(GasLine_RoughPump)
            Dim sbcGasLineTurboIsolationStatus As New StatusBinaryStatusControl(GasLine_Turbo_Isolation)
            Dim sbcGasLineVatValveStatus As New StatusBinaryStatusControl(GasLine_VatValve)

            Dim sbcBaratronValveStatus As New StatusBinaryStatusControl(ValveBaratron)
            Dim sbcVentValveStatus As New StatusBinaryStatusControl(ValveVent)
            Dim sbcRoughValveStatus As New StatusBinaryStatusControl(ValveRough)
            Dim sbcTurboIsolationValveStatus As New StatusBinaryStatusControl(ValveTurbo_Isolation)

            Dim sbcShutOff1ValveStatus As New StatusBinaryStatusControl(ValveShutOff1)
            Dim sbcSupply1ValveStatus As New StatusBinaryStatusControl(ValveSupply1)
            Dim sbcShutOff2ValveStatus As New StatusBinaryStatusControl(ValveShutOff2)
            Dim sbcSupply2ValveStatus As New StatusBinaryStatusControl(ValveSupply2)
            Dim sbcShutOff3ValveStatus As New StatusBinaryStatusControl(ValveShutOff3)
            Dim sbcSupply3ValveStatus As New StatusBinaryStatusControl(ValveSupply3)
            Dim sbcShutOff4ValveStatus As New StatusBinaryStatusControl(ValveShutOff4)
            Dim sbcSupply4ValveStatus As New StatusBinaryStatusControl(ValveSupply4)
            Dim sbcShutOff5ValveStatus As New StatusBinaryStatusControl(ValveShutOff5)
            Dim sbcSupply5ValveStatus As New StatusBinaryStatusControl(ValveSupply5)
            '''
            Dim sTooltipMachineOnline As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineOnline)
            Dim sTooltipMachinePumpDown As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachinePumpDown)
            Dim sTooltipMachineVent As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineVent)
            Dim sTooltipMachineCryoOn As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineCryoOn)
            Dim sTooltipMachineCryoRegen As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineCryoRegen)
            Dim sTooltipMachineShutDownPower As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineShutDownPower)

            Dim sTooltipMachinePumpPurge As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachinePumpPurge)
            Dim sTooltipMachineIGDegas As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineIGDegas)
            Dim sTooltipMachineFastRegen As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineFastRegen)
            'm_stoStatusObject.Name = Me.Name
            Dim stbWaferCount As New StatusTextBox(txtPMWaferCount)
            Dim slbSequenceRunningStatus As New SL_StatusLabel(lblNameOfSequenceRunning)
            Dim slbCurrentPurgeCycle As New StatusLabel(lblCurrentPurgeCycle)

            m_stoStatusObject.AddChild(stbWaferCount)
            m_stoStatusObject.AddChild(Me.BiasPowerSupply.Status)
            m_stoStatusObject.AddChild(Me.ParallelMagnet.Status)
            m_stoStatusObject.AddChild(Me.ChamberInterlock.Status)
            m_stoStatusObject.AddChild(Me.GasController.Status)
            m_stoStatusObject.AddChild(m_PopUpPanel.Status)
            m_stoStatusObject.AddChild(m_CryoPopUpPanel.Status)

            m_stoStatusObject.AddChild(Me.ProcessMonitor.Status)
            m_stoStatusObject.AddChild(Me.RunRecipe.Status)
            m_stoStatusObject.AddChild(Me.ChuckControl.Status)
            m_stoStatusObject.AddChild(Me.TarControl.Status)

            'If Me.ManatronVisible Then
            '    m_stoStatusObject.AddChild(Me.Magnatron.Status)
            'End If
            If Me.IsMGVisible Then
                m_stoStatusObject.AddChild(Me.MGInformation.Status)
            End If
            If Me.CryoControlVisible Then
                m_stoStatusObject.AddChild(Me.Cryo.Status)
            End If

            If Me.TurboPumpVisible Then
                m_stoStatusObject.AddChild(Me.TurboPump.Status)
            End If

            m_stoStatusObject.AddChild(Me.CGInformation.Status)
            m_stoStatusObject.AddChild(Me.Baratron.Status)
            m_stoStatusObject.AddChild(Me.VatValveController.Status)

            m_stoStatusObject.AddChild(sbcOverrideModeStatus)
            m_stoStatusObject.AddChild(sbcbuttonIGCGStatus)
            m_stoStatusObject.AddChild(sbcForeLineStatus)
            m_stoStatusObject.AddChild(sbcRoughLineCGStatus)

            m_stoStatusObject.AddChild(sbcGasLineBaratronStatus)
            m_stoStatusObject.AddChild(sbcGasLineRoughPumpStatus)
            m_stoStatusObject.AddChild(sbcGasLineVentStatus)
            m_stoStatusObject.AddChild(sbcGasLineTurboIsolationStatus)
            m_stoStatusObject.AddChild(sbcGasLineVatValveStatus)

            m_stoStatusObject.AddChild(sbcBaratronValveStatus)
            m_stoStatusObject.AddChild(sbcVentValveStatus)
            m_stoStatusObject.AddChild(sbcRoughValveStatus)

            If Me.TurboPumpVisible Then
                m_stoStatusObject.AddChild(sbcTurboIsolationValveStatus)
            End If
            If Me.WaterValveVisible Then
                m_stoStatusObject.AddChild(sbcWaterValveStatus)
            End If
            If Not Me.GasLine1Name = "" Then
                m_stoStatusObject.AddChild(sbcGasLineShutOff1Status)
                m_stoStatusObject.AddChild(sbcShutOff1ValveStatus)
                m_stoStatusObject.AddChild(sbcSupply1ValveStatus)
                m_stoStatusObject.AddChild(sbcGasLineSupply1Status)
            End If
            If Not Me.GasLine2Name = "" Then
                m_stoStatusObject.AddChild(sbcGasLineShutOff2Status)
                m_stoStatusObject.AddChild(sbcShutOff2ValveStatus)
                m_stoStatusObject.AddChild(sbcSupply2ValveStatus)
                m_stoStatusObject.AddChild(sbcGasLineSupply2Status)
            End If
            If Not Me.GasLine3Name = "" Then
                m_stoStatusObject.AddChild(sbcGasLineShutOff3Status)
                m_stoStatusObject.AddChild(sbcShutOff3ValveStatus)
                m_stoStatusObject.AddChild(sbcSupply3ValveStatus)
                m_stoStatusObject.AddChild(sbcGasLineSupply3Status)
            End If
            If Not Me.GasLine4Name = "" Then
                m_stoStatusObject.AddChild(sbcGasLineShutOff4Status)
                m_stoStatusObject.AddChild(sbcShutOff4ValveStatus)
                m_stoStatusObject.AddChild(sbcSupply4ValveStatus)
                m_stoStatusObject.AddChild(sbcGasLineSupply4Status)
            End If
            If Not Me.GasLine5Name = "" Then
                m_stoStatusObject.AddChild(sbcGasLineShutOff5Status)
                m_stoStatusObject.AddChild(sbcShutOff5ValveStatus)
                m_stoStatusObject.AddChild(sbcSupply5ValveStatus)
                m_stoStatusObject.AddChild(sbcGasLineSupply5Status)
            End If
            If Me.MainGas_Visible Then
                m_stoStatusObject.AddChild(sbcMainGasValveStatus)
                m_stoStatusObject.AddChild(sbcMainGasLineStatus)
            End If

            m_stoStatusObject.AddChild(sbcRoughPumpStatus)

            m_stoStatusObject.AddChild(sTooltipMachineCryoOn)
            m_stoStatusObject.AddChild(sTooltipMachineCryoRegen)
            m_stoStatusObject.AddChild(sTooltipMachineShutDownPower)

            m_stoStatusObject.AddChild(sTooltipMachinePumpPurge)
            m_stoStatusObject.AddChild(sTooltipMachineIGDegas)
            m_stoStatusObject.AddChild(sTooltipMachineFastRegen)

            m_stoStatusObject.AddChild(slbSequenceRunningStatus)
            m_stoStatusObject.AddChild(slbCurrentPurgeCycle)

            m_stoStatusObject.AddChild(Me.m_CGGaugesFrm.Status)
            m_stoStatusObject.AddChild(Me.m_RPCGGaugesFrm.Status)
            m_stoStatusObject.AddChild(Me.m_FLCGGaugesFrm.Status)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private method"
    Public Overrides Sub GoOnline(ByVal blnThrowAlarm As Boolean)
        ''must get status obj PopUpPanel to Request Status-> ParseMessageGui will convert
        If m_PopUpPanel IsNot Nothing Then
            m_PopUpPanel.Status.RequestStatus(PVDPopUpPanel.btnOnline.Name, STR_ON & "#" & blnThrowAlarm.ToString())
        End If
    End Sub

    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Cryo Control or Turbo Pump or Water Pump Visible
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub SetCryoPumpControlVisible()
        If m_blnCryoVisible Then ''cryo Visible
            Me.Cryo.Visible = True
            Me.Cryo.Location = New Point(648, 404) ''near chuck pos
            ''''''''''
            Me.TurboPump.Visible = False
            Me.TurboPump.Location = New Point(751, 599)
            Me.mnuMachineCryoOn.Text = STRING_CRYO_ON
            Me.mnuMachineCryoRegen.Text = STRING_CRYO_REGEN
            Me.mnuMachineFastRegen.Visible = True
            SetTurboComponents(False)
        ElseIf m_blnTurboPumpVisible Then
            Me.TurboPump.Visible = True
            Me.TurboPump.Location = New Point(648, 404) ''near chuck pos
            ''''''''''''''''''''
            Me.Cryo.Visible = False
            Me.Cryo.Location = New Point(751, 599)
            Me.mnuMachineCryoOn.Text = STRING_WATERPUMP_ON
            Me.mnuMachineCryoRegen.Text = STRING_WATERPUMP_REGEN
            Me.mnuMachineFastRegen.Visible = False
            SetTurboComponents(True)
        End If
    End Sub
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Turbo Slit valve is visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub SetTurboComponents(ByVal blVisible As Boolean)
        Me.GasLine_Turbo_Isolation.Visible = blVisible
        Me.ValveTurbo_Isolation.Visible = blVisible
        Label3.Visible = blVisible
        Me.txtForeLineCG.Visible = blVisible
        If m_blnTurboMPInstalled Then
            Me.txtRoughLineCG.Visible = blVisible
        Else
            Me.txtRoughLineCG.Visible = False
        End If
    End Sub
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Type of PVD
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub SetTypePVD()
        'LabTitle.Text = " PVD: MAINTENANCE"
        Me.BiasPowerSupply.Location = New Point(0, 246)
        Me.ParallelMagnet.Location = New Point(0, 481)
        Me.ChamberInterlock.Location = New Point(0, 612)
        ''right panel
        Me.ProcessMonitor.Location = New Point(957, 395)
        Me.ChuckControl.ClampInstall = Me.ClampInstall
        ''run recipe panel is fixed
        ''gas controller panel is fixed      
    End Sub

    ''' <author>
    '''    	<name>Do Xuan Dat</name>
    '''    	<date> 2010-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Set Gas Line & Valve Visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetGas1Info(ByVal strGasName As String, _
                ByVal strGasType As String, _
                ByVal blShutoffPresent As Boolean, _
                ByVal blSupplyPresent As Boolean)
        Me.GasLine1Name = strGasName
        Me.GasLine1Type = strGasType
        SetGasLine1Visible(blShutoffPresent, blSupplyPresent)
    End Sub
    ''' <author>
    '''    	<name>Do Xuan Dat</name>
    '''    	<date> 2010-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Set Gas Line & Valve Visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetGas2Info(ByVal strGasName As String, _
                ByVal strGasType As String, _
                ByVal blShutoffPresent As Boolean, _
                ByVal blSupplyPresent As Boolean)
        Me.GasLine2Name = strGasName
        Me.GasLine2Type = strGasType
        SetGasLine2Visible(blShutoffPresent, blSupplyPresent)
    End Sub
    ''' <author>
    '''    	<name>Do Xuan Dat</name>
    '''    	<date> 2010-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Set Gas Line & Valve Visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetGas3Info(ByVal strGasName As String, _
                ByVal strGasType As String, _
                ByVal blShutoffPresent As Boolean, _
                ByVal blSupplyPresent As Boolean)
        Me.GasLine3Name = strGasName
        Me.GasLine3Type = strGasType
        SetGasLine3Visible(blShutoffPresent, blSupplyPresent)
    End Sub
    ''' <author>
    '''    	<name>Do Xuan Dat</name>
    '''    	<date> 2010-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Set Gas Line & Valve Visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetGas4Info(ByVal strGasName As String, _
                ByVal strGasType As String, _
                ByVal blShutoffPresent As Boolean, _
                ByVal blSupplyPresent As Boolean)
        Me.GasLine4Name = strGasName
        Me.GasLine4Type = strGasType
        SetGasLine4Visible(blShutoffPresent, blSupplyPresent)
    End Sub
    ''' <author>
    '''    	<name>Do Xuan Dat</name>
    '''    	<date> 2010-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Set Gas Line & Valve Visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetGas5Info(ByVal strGasName As String, _
                ByVal strGasType As String, _
                ByVal blShutoffPresent As Boolean, _
                ByVal blSupplyPresent As Boolean)
        Me.GasLine5Name = strGasName
        Me.GasLine5Type = strGasType
        SetGasLine5Visible(blShutoffPresent, blSupplyPresent)
    End Sub
    ''' <author>
    '''    	<name>Do Xuan Dat</name>
    '''    	<date> 2010-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Set Gas Line & Valve Visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub SetGasLineVisible( _
                ByVal blShutoffPresent As Boolean, _
                ByVal blSupplyPresent As Boolean, _
                ByVal GasLine_ShutOff As AVP_Robot_Project.ImageBinaryStatusControl, _
                ByVal GasLine_Supply As AVP_Robot_Project.ImageBinaryStatusControl, _
                ByVal ValveShutOff As AVP_Robot_Project.ValveControl, _
                ByVal ValveSupply As AVP_Robot_Project.ValveControl)

        GasLine_ShutOff.Visible = blShutoffPresent
        GasLine_Supply.Visible = blSupplyPresent
        ValveShutOff.Visible = blShutoffPresent
        ValveSupply.Visible = blSupplyPresent

        'This is the special case
        If (blShutoffPresent = False And blSupplyPresent = True) Then
            GasLine_ShutOff.Visible = True
            If GasLine_ShutOff IsNot GasLine_ShutOff5 Then
                GasLine_ShutOff.Size = New Size(145, GasLine_ShutOff.Size.Height)
            Else
                GasLine_ShutOff.Size = New Size(340, GasLine_ShutOff.Size.Height)
            End If
        End If

    End Sub

    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Gas Line & Valve Visible or not
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub SetGasLine1Visible(ByVal blShutoffPresent As Boolean, _
                                                 ByVal blSupplyPresent As Boolean)
        SetGasLineVisible(blShutoffPresent, blSupplyPresent, GasLine_ShutOff1, GasLine_Supply1, ValveShutOff1, ValveSupply1)
    End Sub
    Protected Overridable Sub SetGasLine2Visible(ByVal blShutoffPresent As Boolean, _
                                                 ByVal blSupplyPresent As Boolean)
        SetGasLineVisible(blShutoffPresent, blSupplyPresent, GasLine_ShutOff2, GasLine_Supply2, ValveShutOff2, ValveSupply2)
    End Sub
    Protected Overridable Sub SetGasLine3Visible(ByVal blShutoffPresent As Boolean, _
                                                 ByVal blSupplyPresent As Boolean)
        SetGasLineVisible(blShutoffPresent, blSupplyPresent, GasLine_ShutOff3, GasLine_Supply3, ValveShutOff3, ValveSupply3)
    End Sub
    Protected Overridable Sub SetGasLine4Visible(ByVal blShutoffPresent As Boolean, _
                                                 ByVal blSupplyPresent As Boolean)
        SetGasLineVisible(blShutoffPresent, blSupplyPresent, GasLine_ShutOff4, GasLine_Supply4, ValveShutOff4, ValveSupply4)

       
        GasLine_Supply4.Size = New Size(300, 143)
    End Sub
    Protected Overridable Sub SetGasLine5Visible(ByVal blShutoffPresent As Boolean, _
                                                 ByVal blSupplyPresent As Boolean)
        SetGasLineVisible(blShutoffPresent, blSupplyPresent, GasLine_ShutOff5, GasLine_Supply5, ValveShutOff5, ValveSupply5)
        If blShutoffPresent = False AndAlso blSupplyPresent = False Then
            GasLine_Total.Size = New Size(237, 91)
        End If
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Active and InActive Form
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub Active_InActiveForm(ByVal blnStatus As Boolean)
        Try
            If Me.IsOnline = False Then
                Online_OfflineValveStatus(blnStatus, False)
                Me.btnReConnect.Enabled = blnStatus
            End If
            Me.btnPVDTooltipMachine.Enabled = blnStatus
            Me.btnWPCryo.Enabled = blnStatus
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Online_OfflineValveStatus
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Online_OfflineValveStatus(ByVal blnStatus As Boolean, ByVal blnIsMenuOnlineClick As Boolean)
        If blnIsMenuOnlineClick Then
            If m_IsMaintenanceMode Then
                Me.lblChamberType.Text = Me.lblChamberType.Tag & " (" & ConstantAndEnum.STRING_MAINTENANCE & ")"
            Else
                If blnStatus Then  'Offline
                    Me.lblChamberType.Text = Me.lblChamberType.Tag & OFFLINE_PM
                Else
                    Me.lblChamberType.Text = Me.lblChamberType.Tag & ONLINE_PM
                End If
            End If
        End If
        If AVPLib.ContainerData.Permission(PERMISSION_001) = False Then
            If blnStatus Then
                Exit Sub
            End If
        End If
        If BiasPowerSupplyVisible Then
            Me.BiasPowerSupply.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
            ''Add permission
            Me.BiasPowerSupply.IsOnline = BiasPowerSupply.IsOnline Or Not AVPLib.ContainerData.Permission(PERMISSION_001)
        End If
        Me.ValveBaratron.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveVent.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveRough.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveTurbo_Isolation.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveShutOff1.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveSupply1.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveShutOff2.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveSupply2.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveShutOff3.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveSupply3.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveShutOff4.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveSupply4.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveShutOff5.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveSupply5.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveMainGas.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ValveWater.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.RoughPump.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.btnHivacValve.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.Cryo.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)

        Me.VatValveController.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ChuckControl.btnClamp.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ChuckControl.btnShutter.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ChuckControl.txtPos2.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.GasController.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ParallelMagnet.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        'Me.Magnatron.IsOnline = Not blnStatus
        Me.Baratron.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.TarControl.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.TurboPump.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        ''
        mnuMachineCryoOn.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        mnuMachineCryoRegen.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        btnHivacValve.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)

        Me.RunRecipe.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.btnOverrideMode.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.ChamberInterlock.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        m_CryoPopUpPanel.DeviceOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Baratron.txtCG1.Clickable = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        txtRoughLineCG.Clickable = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        txtForeLineCG.Clickable = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on valve
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub ValveControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles ValveBaratron.Click, ValveVent.Click, ValveRough.Click, ValveTurbo_Isolation.Click, _
                        ValveShutOff1.Click, ValveSupply1.Click, ValveShutOff2.Click, ValveSupply2.Click, _
                        ValveShutOff3.Click, ValveSupply3.Click, ValveShutOff4.Click, ValveSupply4.Click, _
                        ValveShutOff5.Click, ValveSupply5.Click, ValveWater.Click, ValveMainGas.Click
        'NOTE:
        'DO NOT CHECK ANYTHING WHEN OPEN ROUGH VALVE
        'SEND REQUEST OPEN ROUGH VALVE 
        'ON CONTROLLER REQUEST ROUGH LINE
        'REQUEST OK -> MAKE ROUGH LINE IN USE
        'REQUEST FAILED -> SHOW POPUP
        'REQUEST OK, OPEN FAILED -> RELEASE RESOURCE,SHOW POPUP
        PVDSupport.ValveClick(sender, e, Me, m_stoStatusObject)
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle Click Tooltip Machine
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub mnuTooltipMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuMachineVent.Click, mnuMachinePumpDown.Click, _
        mnuMachineOnline.Click, mnuMachineCryoRegen.Click, mnuMachineCryoOn.Click, _
         mnuMachineShutDownPower.Click, mnuMachineIGDegas.Click, mnuMachinePumpPurge.Click, mnuMachineFastRegen.Click
        AVPLib.Log.guiLogger.Info("Enter mnuTooltipMachine_Click")
        Dim strMessageText As String = String.Empty
        Dim strLogMessage As String = String.Empty
        Try

            Dim strChamberName As String = AVPLib.Utils.chamberID2ChamberName(Me.Name)

            Dim Tooltip As System.Windows.Forms.ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)

            Dim Message As String = Tooltip.Name

            If Tooltip.Name = Me.mnuMachineOnline.Name Then
                If Tooltip.Text = STRING_OFFLINE Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("OfflineChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        strLogMessage = "[" + strChamberName + "] Bring Offline"
                    End If
                ElseIf Me.mnuMachineOnline.Text = STRING_ONLINE Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("OnlineChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        strLogMessage = "[" + strChamberName + "] Bring Online"
                    End If
                End If
            ElseIf Tooltip.Name = Me.mnuMachinePumpDown.Name Then
                If Tooltip.Text = STRING_ABORT_PUMP_DOWN Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("AbortPumpDownChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        strLogMessage = "[" + strChamberName + "] Stop Pump Down"
                    End If
                Else 'check Slit valve Close
                    Dim IsPMIsoValveClose As Boolean = AVPLib.Utils.IsChamberSlitValveClose(Me.Name)
                    If Not IsPMIsoValveClose Then
                        strLogMessage = "[" + strChamberName + "] Check Slit valve failed before Start Pump Down"
                        Utils.ShowAVPMessageBox("Slit Valve is not close", AVPLib.Utils.chamberName2ChamberID(Me.Name), MessageBoxIcon.Stop)
                        Exit Try
                    End If

                    strMessageText = AVPLib.ContainerData.GetMessageText("StartPumpDownChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        strLogMessage = "[" + strChamberName + "] Start Pump Down"
                    End If
                End If
            ElseIf Tooltip.Name = Me.mnuMachineVent.Name Then
                If Tooltip.Text = STRING_ABORT_VENT Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("AbortVentChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        strLogMessage = "[" + strChamberName + "] Stop Vent"
                    End If
                Else 'check Slit valve Close
                    Dim IsPMIsoValveClose As Boolean = AVPLib.Utils.IsChamberSlitValveClose(Me.Name)
                    If Not IsPMIsoValveClose Then
                        strLogMessage = "[" + strChamberName + "] Check Slit valve failed before Start Vent"
                        Utils.ShowAVPMessageBox("Slit Valve is not close", AVPLib.Utils.chamberName2ChamberID(Me.Name), MessageBoxIcon.Stop)
                        Exit Try
                    End If

                    strMessageText = AVPLib.ContainerData.GetMessageText("StartVentChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        strLogMessage = "[" + strChamberName + "] Start Vent"
                    End If
                End If
            ElseIf Tooltip.Name = Me.mnuMachineCryoOn.Name Then
                If Tooltip.Text = STRING_CRYO_OFF Then
                    If Utils.CheckHivacValveOpen_BeforeCryo(Me.Name) Then
                        strLogMessage = "[" + strChamberName + "] Check Hivac Valve failed before Set Cryo Off "
                        Exit Sub
                    End If
                    strMessageText = AVPLib.ContainerData.GetMessageText("CryoOffChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        strLogMessage = "[" + strChamberName + "] Cryo Off"
                    End If
                ElseIf Tooltip.Text = STRING_CRYO_ON Then
                    If Utils.CheckHivacValveOpen_BeforeCryo(Me.Name) Then
                        strLogMessage = "[" + strChamberName + "] Check Hivac Valve failed before Set Cryo On "
                        Exit Sub
                    End If
                    strMessageText = AVPLib.ContainerData.GetMessageText("CryoOnChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        strLogMessage = "[" + strChamberName + "] Cryo On"
                    End If
                ElseIf Tooltip.Text = STRING_WATERPUMP_OFF Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("WaterPumpOffChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus("TurnWaterPump", STR_OFF)
                        strLogMessage = "[" + strChamberName + "] Water Pump Off"
                    End If
                ElseIf Tooltip.Text = STRING_WATERPUMP_ON Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("WaterPumpOnChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus("TurnWaterPump", STR_ON)
                        strLogMessage = "[" + strChamberName + "] Water Pump On"
                    End If
                End If
            ElseIf Tooltip.Name = mnuMachineCryoRegen.Name Then

                If Tooltip.Text = STRING_CRYO_REGEN Then
                    If Utils.CheckHivacValveOpen_BeforeCryo(Me.Name) Then
                        strLogMessage = "[" + strChamberName + "] Check Hivac Valve failed before Stop Cryo Regen"
                        Exit Sub
                    End If
                    strMessageText = AVPLib.ContainerData.GetMessageText("CryoRegenOffChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        strLogMessage = "[" + strChamberName + "] Cryo Stop Regen"
                    End If
                ElseIf Tooltip.Text = STRING_ABORT_CRYO_REGEN Then
                    If Utils.CheckHivacValveOpen_BeforeCryo(Me.Name) Then
                        strLogMessage = "[" + strChamberName + "] Check Hivac Valve failed before Start Regen"
                        Exit Sub
                    End If
                    strMessageText = AVPLib.ContainerData.GetMessageText("CryoRegenOnChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        strLogMessage = "[" + strChamberName + "] Cryo Start Regen"
                    End If
                ElseIf Tooltip.Text = STRING_ABORT_WATERPUMP_REGEN Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("WaterPumpRegenOnChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus("TurnWaterPump_Regen", STR_OFF)
                        strLogMessage = "[" + strChamberName + "] Water Pump Stop Regen"
                    End If
                ElseIf Tooltip.Text = STRING_WATERPUMP_REGEN Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("WaterPumpRegenOnChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus("TurnWaterPump_Regen", STR_ON)
                        strLogMessage = "[" + strChamberName + "] Water Pump Start Regen"
                    End If
                End If
            ElseIf Tooltip.Name = Me.mnuMachineShutDownPower.Name Then
                strMessageText = AVPLib.ContainerData.GetMessageText("ShutDownPowerChamberPanel")
                If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                    m_stoStatusObject.RequestStatus(Message, STR_OFF)
                    strLogMessage = "[" + strChamberName + "] Shut Down All Power"
                End If

            ElseIf Tooltip.Name = Me.mnuMachineIGDegas.Name Then
                If Tooltip.Text = IG_DEGAS Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("IGDegasChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        strLogMessage = "[" + strChamberName + "] IG Degas"
                    End If
                ElseIf Tooltip.Text = Abort & " " & IG_DEGAS Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("AbortIGDegasChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        strLogMessage = "[" + strChamberName + "] IG Degas"
                    End If
                End If

            ElseIf Tooltip.Name = Me.mnuMachinePumpPurge.Name Then
                If Tooltip.Text = PUMP_PURGE Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("PumpPurgeChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        strLogMessage = "[" + strChamberName + "] Pump Purge"
                    End If
                ElseIf Tooltip.Text = Abort & " " & PUMP_PURGE Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("AbortPumpPurgeChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        strLogMessage = "[" + strChamberName + "] Pump Purge"
                    End If
                End If

            ElseIf Tooltip.Name = Me.mnuMachineFastRegen.Name Then
                If Tooltip.Text = FAST_REGEN Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("FastRegenChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_ON)
                        strLogMessage = "[" + strChamberName + "] Fast Regen"
                    End If
                ElseIf Tooltip.Text = Abort & " " & FAST_REGEN Then
                    strMessageText = AVPLib.ContainerData.GetMessageText("AbortFastRegenChamberPanel")
                    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Message, STR_OFF)
                        strLogMessage = "[" + strChamberName + "] Fast Regen"
                    End If
                End If

            End If

            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, strLogMessage)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuTooltipMachine_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Rough Valve
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub btnPVDTooltipMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPVDTooltipMachine.Click, btnWPCryo.Click
        AVPLib.Log.guiLogger.Info("Enter btnPVDTooltipMachine_Click")
        Try
            If CType(sender, Button).Name = btnPVDTooltipMachine.Name Then
                Dim pvdParent As PVDPanel = ContainerForm.ChamberPanel(Me.Name) ''must be PVd Panel
                If pvdParent Is Nothing Then
                    Exit Sub
                End If

                If pvdParent IsNot Nothing Then
                    pvdParent.PVDPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                    pvdParent.PVDPopUpPanel.ShowDialog(AVPRobotMain)
                End If

            ElseIf CType(sender, Button).Name = btnWPCryo.Name Then
                Dim pos As New System.Drawing.Point(Me.btnWPCryo.Location)
                pos.Y += Me.btnWPCryo.Height
                pos = Me.PointToScreen(pos)
                Me.cmsWPCryo.Show(pos)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnPVDTooltipMachine_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Change status of menu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MenuItemTextChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Tooltip As System.Windows.Forms.ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
            Select Case Tooltip.Name
                Case Me.mnuMachineOnline.Name
                    Dim blnIsOnline As Boolean = IIf(mnuMachineOnline.Text = STRING_ONLINE, True, False)
                    mnuMachinePumpDown.Enabled = (blnIsOnline)
                    mnuMachineVent.Enabled = blnIsOnline
                    mnuMachineIGDegas.Enabled = blnIsOnline
                    mnuMachinePumpPurge.Enabled = blnIsOnline
                    mnuMachineShutDownPower.Enabled = blnIsOnline
                Case Me.mnuMachineVent.Name
                    Dim blnIsVent As Boolean = IIf(mnuMachineVent.Text = VENT, True, False)
                    mnuMachinePumpDown.Enabled = blnIsVent
                    mnuMachineOnline.Enabled = blnIsVent
                    mnuMachineIGDegas.Enabled = blnIsVent
                    mnuMachinePumpPurge.Enabled = blnIsVent
                    mnuMachineShutDownPower.Enabled = blnIsVent
                Case Me.mnuMachinePumpDown.Name
                    Dim blnIsPumpDown As Boolean = IIf(mnuMachinePumpDown.Text = PUMP_DOWN, True, False)
                    mnuMachineVent.Enabled = blnIsPumpDown
                    mnuMachineOnline.Enabled = blnIsPumpDown
                    mnuMachineIGDegas.Enabled = blnIsPumpDown
                    mnuMachinePumpPurge.Enabled = blnIsPumpDown
                    mnuMachineShutDownPower.Enabled = blnIsPumpDown
                Case Me.mnuMachinePumpPurge.Name
                    Dim blnIsPumpPurge As Boolean = IIf(mnuMachinePumpPurge.Text = PUMP_PURGE, True, False)
                    mnuMachinePumpDown.Enabled = blnIsPumpPurge
                    mnuMachineVent.Enabled = blnIsPumpPurge
                    mnuMachineOnline.Enabled = blnIsPumpPurge
                    mnuMachineIGDegas.Enabled = blnIsPumpPurge
                    mnuMachineShutDownPower.Enabled = blnIsPumpPurge
                Case Me.mnuMachineIGDegas.Name
                    Dim blnIsIGDegas As Boolean = IIf(mnuMachineIGDegas.Text = IG_DEGAS, True, False)
                    mnuMachinePumpDown.Enabled = blnIsIGDegas
                    mnuMachineVent.Enabled = blnIsIGDegas
                    mnuMachineOnline.Enabled = blnIsIGDegas
                    mnuMachinePumpPurge.Enabled = blnIsIGDegas
                    mnuMachineShutDownPower.Enabled = blnIsIGDegas
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
    ''' Get or Set Rough Valve
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub btnPVDHivacValve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHivacValve.Click
        AVPLib.Log.guiLogger.Info("Enter Button_Click")

        Dim strMessageText As String = String.Empty
        Dim strValue As String = String.Empty
        Dim button As ButtonIGCGControl = CType(sender, ButtonIGCGControl)
        Dim strChamberName As String = String.Empty
        Dim strLogMessage As String = String.Empty
        Dim dlgRes As DialogResult
        Try

            If CType(sender, ButtonIGCGControl).Status = DisplayStatus.On Then
                strLogMessage = "Close Hivac"
            ElseIf CType(sender, ButtonIGCGControl).Status = DisplayStatus.Off Then
                strLogMessage = "Open Hivac"
            End If
            PVDSupport.ReadMessageText(sender, Me, strMessageText)
            strChamberName = AVPLib.Utils.chamberID2ChamberName(CType(Me, ChamberPanel).Name)

            Dim strSourceLogMessage As String = String.Empty

            strSourceLogMessage = "[" + strChamberName + "]"

            If button.Status = DisplayStatus.Unknow Then
                dlgRes = Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OpenCloseCancel) 'MessageBoxButtons.YesNoCancel)
                If dlgRes = DialogResult.Cancel Then
                    Exit Try
                ElseIf dlgRes = DialogResult.OK Then ''Open
                    GoTo SendOpenHivacCmd
                ElseIf dlgRes = DialogResult.No Then 'Close
                    GoTo SendCloseHivacCmd
                End If
            ElseIf button.Status = DisplayStatus.Off Then
                If Utils.ShowAVPMessageBox("Are you sure you want to Open Hivac Valve? ", strChamberName, _
                                            MessageBoxIcon.Warning, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    GoTo SendOpenHivacCmd
                End If
                Exit Try
            ElseIf button.Status = DisplayStatus.On Then
                If Utils.ShowAVPMessageBox("Are you sure you want to Close Hivac Valve? ", strChamberName, _
                                            MessageBoxIcon.Warning, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    GoTo SendCloseHivacCmd
                End If
                Exit Try
            End If

SendCloseHivacCmd:
            m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                               AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                               strSourceLogMessage + " " + strLogMessage)
            Exit Try

SendOpenHivacCmd:
            If CheckConditionBeforeOpenPVDHivac() Then
                m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   strSourceLogMessage + " " + strLogMessage)
            Else
                Utils.ShowAVPMessageBox("Please close Rough Valve/Vent Valve/Slit valve before Open Hivac Valve!", strChamberName, _
                                                            MessageBoxIcon.Warning, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                   strSourceLogMessage & " " & strLogMessage & "- Open failed")
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Button_Click")
    End Sub

    Private Function CheckConditionBeforeOpenPVDHivac() As Boolean
        'check condition Rough Valve/Vent Valve/ Slit valve is closed before Open Hivac ->base on RFE:04/08/2011
        Dim resResult As Boolean = False
        If (ValveRough.Status = BinaryStatusControl.DisplayStatus.Off) AndAlso _
           (ValveVent.Status = BinaryStatusControl.DisplayStatus.Off) AndAlso _
            Not (ChuckControl.ValveSlit.Status = DisplayStatus.On) Then
            resResult = True
        End If
        Return resResult
    End Function
#End Region


    Public Sub New(ByVal ChamberName As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        '
        'mnucmsMechineTool-->Please do not remove this section when commit code
        '
        cmsTooltipMachine.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmsTooltipMachine.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMachineOnline, Me.mnuMachinePumpDown, Me.mnuMachineVent, Me.mnuMachineShutDownPower})
        cmsTooltipMachine.Name = "cmsMechineTool"
        cmsTooltipMachine.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        cmsTooltipMachine.ShowImageMargin = False
        cmsTooltipMachine.Size = New System.Drawing.Size(180, 136)

        cmsWPCryo.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmsWPCryo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMachineCryoOn, Me.mnuMachineCryoRegen})
        cmsWPCryo.Name = "cmsWPCryo"
        cmsWPCryo.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        cmsWPCryo.ShowImageMargin = False
        cmsWPCryo.Size = New System.Drawing.Size(180, 136)

        NewConvectronGaugeFrm(AVPLib.Utils.chamberID2ChamberName(ChamberName))
        NewRPConvectronGaugeFrm(AVPLib.Utils.chamberID2ChamberName(ChamberName))
        NewFLConvectronGaugeFrm(AVPLib.Utils.chamberID2ChamberName(ChamberName))

        lblDisconnect.Location = New Point(377, 303)
        AddHandler mnuMachineOnline.TextChanged, AddressOf MenuItemTextChange
        AddHandler mnuMachineVent.TextChanged, AddressOf MenuItemTextChange
        AddHandler mnuMachinePumpDown.TextChanged, AddressOf MenuItemTextChange
        ''
        Me.mnuMachineIGDegas.Name = "mnuMachineIGDegas"
        Me.mnuMachineIGDegas.Size = New System.Drawing.Size(139, 22)
        Me.mnuMachineIGDegas.Text = "IG Degas"
        '''
        Me.mnuMachinePumpPurge.Name = "mnuMachinePumpPurge"
        Me.mnuMachinePumpPurge.Size = New System.Drawing.Size(139, 22)
        Me.mnuMachinePumpPurge.Text = "Pump Purge"
        ''
        Me.cmsTooltipMachine.Items.Remove(mnuMachineShutDownPower)
        Me.cmsTooltipMachine.Items.Add(mnuMachineIGDegas)
        Me.cmsTooltipMachine.Items.Add(mnuMachinePumpPurge)
        Me.cmsTooltipMachine.Items.Add(mnuMachineShutDownPower)
        AddHandler mnuMachineIGDegas.TextChanged, AddressOf MenuItemTextChange
        AddHandler mnuMachinePumpPurge.TextChanged, AddressOf MenuItemTextChange
        AddHandler Baratron.PressureCG_Click, AddressOf PressureCG_Click

        RunRecipe.Left = ProcessMonitor.Left
        RunRecipe.Top = ProcessMonitor.Top + ProcessMonitor.Height - 2
        btnOverrideMode.Top = RunRecipe.Top + RunRecipe.Height + 1
        Me.Name = ChamberName
        m_PopUpPanel = New PopUpPanel
        m_PopUpPanel.Name = "PopUpPanel"
        m_PopUpPanel.StartPosition = FormStartPosition.CenterScreen
        m_PopUpPanel.ShowInTaskbar = False
        m_PopUpPanel.ShowIcon = False
        m_PopUpPanel.Text = AVPLib.Utils.chamberID2ChamberName(ChamberName) & " Menu"
        m_PopUpPanel.ChamberHandle = ChamberName
        m_PopUpPanel.Hide()
        ''
        m_CryoPopUpPanel = New CryoPopUpPanel
        m_CryoPopUpPanel.Name = "CryoPopUpPanel"
        m_CryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
        m_CryoPopUpPanel.ShowInTaskbar = False
        m_CryoPopUpPanel.ShowIcon = False
        m_CryoPopUpPanel.Text = AVPLib.Utils.chamberID2ChamberName(ChamberName) & " Cryo"
        m_CryoPopUpPanel.PanelHandle = ChamberName
        m_CryoPopUpPanel.txtExtendedPurgeTime.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtPumpRestartDelay.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtRateOfRise.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtRoughToPressure.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtStartUpTemp.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtRepurgeCycles.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.Hide()
        ''''
        lblRoughPumpInUse.Top = RoughPump.Top + RoughPump.Height - 3
        Me.StatusTextLocation = New Point(22, btnOverrideMode.Top + btnOverrideMode.Height)
        RoughPump.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    End Sub

    Private Sub RoughPump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoughPump.Click
        If CryoControlVisible And (Me.ValveRough.Status = BinaryStatusControl.DisplayStatus.On) AndAlso _
        (Not (Me.btnReConnect.Status = DisplayStatus.On)) Then
            If Utils.ShowAVPMessageBox("Want to release Rough Line In Use?", "Rough Pump", MessageBoxIcon.Question) = DialogResult.OK Then
                m_stoStatusObject.RequestStatus("ReleaseRoughLineInUse", STR_OFF)
                Dim strChamberName As String = AVPLib.Utils.chamberID2ChamberName(Me.Name)
                AVPLib.ContainerData.LogAlarmEvent(TypeUser, LogSource.AVPMainScreen, "[" + strChamberName + "] Rough Pump Click")
            End If
        End If
    End Sub

    Private Sub btnOverrideMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOverrideMode.Click
        PVDSupport.CommonButtonClick("Override Mode", sender, Me, m_stoStatusObject)
    End Sub

    Private Sub PressureCG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If Not PM_DeviceNet Then
                    Return
                End If
                Dim objChamber As AVPLib.DataManagerment.PVDChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
                If m_CGGaugesFrm IsNot Nothing Then
                    m_CGGaugesFrm.IsSetATM = IIf(objChamber.ATMChamberCGStatus = DataManagerment.Equipment.WorkingStatuses.On, True, False)
                    m_CGGaugesFrm.IsSetVAC = IIf(objChamber.VACChamberCGStatus = DataManagerment.Equipment.WorkingStatuses.On, True, False)
                    m_CGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
                    m_CGGaugesFrm.ShowDialog(AVPRobotMain)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub NewConvectronGaugeFrm(ByVal chambername As String)
        m_CGGaugesFrm = New CGGaugesFrm(False, False, True)
        m_CGGaugesFrm.Name = AVPLib.ConstEnum.PRESSURE & AVPLib.ConstEnum.CG_IG_FORM
        m_CGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_CGGaugesFrm.ShowInTaskbar = False
        m_CGGaugesFrm.ShowIcon = False
        m_CGGaugesFrm.Text = chambername & " " & AVPLib.ConstEnum.PRESSURE
        m_CGGaugesFrm.Hide()
    End Sub

    Private Sub NewRPConvectronGaugeFrm(ByVal chambername As String)
        m_RPCGGaugesFrm = New CGGaugesFrm(False, False, False)
        m_RPCGGaugesFrm.Name = AVPLib.ConstEnum.ROUGHLINE & AVPLib.ConstEnum.CG_IG_FORM
        m_RPCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_RPCGGaugesFrm.ShowInTaskbar = False
        m_RPCGGaugesFrm.ShowIcon = False
        m_RPCGGaugesFrm.Text = chambername & " " & AVPLib.ConstEnum.ROUGHLINE
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

    Private Sub txtRoughLineCG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRoughLineCG.Click
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If txtRoughLineCG.Clickable = False Or (Not PM_DeviceNet) Then
                    Return
                End If
                Dim objChamber As AVPLib.DataManagerment.PVDChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
                If m_RPCGGaugesFrm IsNot Nothing AndAlso objChamber IsNot Nothing Then
                    m_RPCGGaugesFrm.IsSetATM = IIf(objChamber.ATMRoughLineCGStatus = DataManagerment.Equipment.WorkingStatuses.On, True, False)
                    m_RPCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
                    m_RPCGGaugesFrm.ShowDialog(AVPRobotMain)
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtForeLineCG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtForeLineCG.Click
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If txtForeLineCG.Clickable = False Or (Not PM_DeviceNet) Then
                    Return
                End If
                Dim objChamber As AVPLib.DataManagerment.PVDChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
                If m_FLCGGaugesFrm IsNot Nothing AndAlso objChamber IsNot Nothing Then
                    m_FLCGGaugesFrm.IsSetATM = IIf(objChamber.ATMForelineCGStatus = DataManagerment.Equipment.WorkingStatuses.On, True, False)
                    m_FLCGGaugesFrm.ShowDialog(AVPRobotMain)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
