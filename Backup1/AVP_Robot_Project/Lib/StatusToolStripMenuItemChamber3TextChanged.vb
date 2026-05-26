Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Public Class StatusToolStripMenuItemChamber3TextChanged
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_mnuToolStripMenuItem As ToolStripMenuItem
#End Region


#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the menu item that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedToolStripMenuItem() As ToolStripMenuItem
        Get
            Return m_mnuToolStripMenuItem
        End Get
        Set(ByVal value As ToolStripMenuItem)
            m_mnuToolStripMenuItem = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with menu item that will be managed by this object
    ''' </summary>
    ''' <param name="mnuToolStripMenuItem"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal mnuToolStripMenuItem As ToolStripMenuItem)
        m_mnuToolStripMenuItem = mnuToolStripMenuItem
        Me.Name = m_mnuToolStripMenuItem.Name
    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Dat Do </name>
    '''     <date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' if menu item change from enable to disable or something else, go to StatusToolstripmenuitemchamber3
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)

            If m_mnuToolStripMenuItem.Text = ConstantAndEnum.OPEN_SHUTTER Or m_mnuToolStripMenuItem.Text = ConstantAndEnum.CLOSE_SHUTTER Then
                m_mnuToolStripMenuItem.Text = IIf((STR_OFF = Value), ConstantAndEnum.OPEN_SHUTTER, ConstantAndEnum.CLOSE_SHUTTER)
            ElseIf m_mnuToolStripMenuItem.Text = ConstantAndEnum.OPEN_WATER_VALVE Or m_mnuToolStripMenuItem.Text = ConstantAndEnum.CLOSE_WATER_VALVE Then
                m_mnuToolStripMenuItem.Text = IIf((STR_OFF = Value), ConstantAndEnum.OPEN_WATER_VALVE, ConstantAndEnum.CLOSE_WATER_VALVE)
            ElseIf m_mnuToolStripMenuItem.Text = ConstantAndEnum.OPEN_FLOW_COOL Or m_mnuToolStripMenuItem.Text = ConstantAndEnum.CLOSE_FLOW_COOL Then
                m_mnuToolStripMenuItem.Text = IIf((STR_OFF = Value), ConstantAndEnum.OPEN_FLOW_COOL, ConstantAndEnum.CLOSE_FLOW_COOL)
            ElseIf m_mnuToolStripMenuItem.Text = ConstantAndEnum.CLAMP_DOWN Or m_mnuToolStripMenuItem.Text = ConstantAndEnum.CLAMP_UP Then
                m_mnuToolStripMenuItem.Text = IIf((CInt(AVPLib.ConfigurationValues.DEVICE_CLAMP_DOWN) = CInt(Value)), ConstantAndEnum.CLAMP_UP, ConstantAndEnum.CLAMP_DOWN)
            ElseIf m_mnuToolStripMenuItem.Text = "Online" Or m_mnuToolStripMenuItem.Text = "Offline" Then
                DoOnline_Offline(Value)
            ElseIf m_mnuToolStripMenuItem.Text = PUMP_DOWN Or m_mnuToolStripMenuItem.Text = STRING_STOP_PUMP_DOWN _
                   Or m_mnuToolStripMenuItem.Text = STRING_ABORT_PUMP_DOWN Then
                m_mnuToolStripMenuItem.Text = IIf((STR_ON = Value), STRING_ABORT_PUMP_DOWN, PUMP_DOWN)
                If Value = STR_ON AndAlso ContainerForm.ChamberPanel(Me.Parent.Name).ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                    'CType(ContainerForm.ChamberPanel(Me.Parent.Name), PVDPanel).mnuMachineVent.Enabled = False
                ElseIf Value = STR_OFF AndAlso ContainerForm.ChamberPanel(Me.Parent.Name).ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                    'CType(ContainerForm.ChamberPanel(Me.Parent.Name), PVDPanel).mnuMachineVent.Enabled = True
                Else
                    AVPLib.Log.avpLogger.Error("Update Wrong value from Menu PumpDown in PVD: " & Value.ToString())
                End If
            ElseIf m_mnuToolStripMenuItem.Text = VENT Or m_mnuToolStripMenuItem.Text = STRING_STOP_VENT _
                   Or m_mnuToolStripMenuItem.Text = STRING_ABORT_VENT Then
                m_mnuToolStripMenuItem.Text = IIf((STR_ON = Value), STRING_ABORT_VENT, VENT)
                If Value = STR_ON AndAlso ContainerForm.ChamberPanel(Me.Parent.Name).ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                    'CType(ContainerForm.ChamberPanel(Me.Parent.Name), PVDPanel).mnuMachinePumpDown.Enabled = False
                ElseIf Value = STR_OFF AndAlso ContainerForm.ChamberPanel(Me.Parent.Name).ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                    'CType(ContainerForm.ChamberPanel(Me.Parent.Name), PVDPanel).mnuMachinePumpDown.Enabled = True
                Else
                    AVPLib.Log.avpLogger.Error("Update Wrong value from Menu Vent in PVD: " & Value.ToString())
                End If
            ElseIf m_mnuToolStripMenuItem.Text = STRING_CRYO_ON Or m_mnuToolStripMenuItem.Text = STRING_CRYO_OFF Then
                m_mnuToolStripMenuItem.Text = IIf((STR_ON = Value), STRING_CRYO_OFF, STRING_CRYO_ON)
            ElseIf m_mnuToolStripMenuItem.Text = TURBO_PUMP_POWER_ON Or m_mnuToolStripMenuItem.Text = TURBO_PUMP_POWER_OFF Then
                m_mnuToolStripMenuItem.Text = IIf((STR_ON = Value), TURBO_PUMP_POWER_OFF, TURBO_PUMP_POWER_ON)
            ElseIf m_mnuToolStripMenuItem.Text = ROUGH_PUMP_POWER_ON Or m_mnuToolStripMenuItem.Text = ROUGH_PUMP_POWER_OFF Then
                m_mnuToolStripMenuItem.Text = IIf((STR_ON = Value), ROUGH_PUMP_POWER_OFF, ROUGH_PUMP_POWER_ON)
            ElseIf m_mnuToolStripMenuItem.Text = "Cryo Regen" Or m_mnuToolStripMenuItem.Text = "Abort Cryo Regen" Then
                m_mnuToolStripMenuItem.Text = IIf((STR_ON = Value), "Abort Cryo Regen", "Cryo Regen")
            ElseIf m_mnuToolStripMenuItem.Text = "Cryo Pump Regen" Then
                m_mnuToolStripMenuItem.Text = "Cryo Pump Regen"
            ElseIf m_mnuToolStripMenuItem.Text = "Cryo Auto Regen" Then
                m_mnuToolStripMenuItem.Text = "Cryo Auto Regen"
            ElseIf m_mnuToolStripMenuItem.Text = STRING_WATERPUMP_REGEN And Value = STR_ON Then
                m_mnuToolStripMenuItem.Text = STRING_ABORT_WATERPUMP_REGEN
            ElseIf m_mnuToolStripMenuItem.Text = STRING_ABORT_WATERPUMP_REGEN And Value = STR_OFF Then
                m_mnuToolStripMenuItem.Text = STRING_WATERPUMP_REGEN
            ElseIf m_mnuToolStripMenuItem.Text = STRING_WATERPUMP_ON And Value = STR_ON Then
                m_mnuToolStripMenuItem.Text = STRING_WATERPUMP_OFF
            ElseIf m_mnuToolStripMenuItem.Text = STRING_WATERPUMP_OFF And Value = STR_OFF Then
                m_mnuToolStripMenuItem.Text = STRING_WATERPUMP_ON
            ElseIf m_mnuToolStripMenuItem.Text = PUMP_PURGE And Value = STR_ON Then
                m_mnuToolStripMenuItem.Text = Abort & " " & PUMP_PURGE
            ElseIf m_mnuToolStripMenuItem.Text = Abort & " " & PUMP_PURGE And Value = STR_OFF Then
                m_mnuToolStripMenuItem.Text = PUMP_PURGE
            ElseIf m_mnuToolStripMenuItem.Text = IG_DEGAS And Value = STR_ON Then
                m_mnuToolStripMenuItem.Text = Abort & " " & IG_DEGAS
            ElseIf m_mnuToolStripMenuItem.Text = Abort & " " & IG_DEGAS And Value = STR_OFF Then
                m_mnuToolStripMenuItem.Text = IG_DEGAS
            ElseIf m_mnuToolStripMenuItem.Text = Abort & " " & FAST_REGEN And Value = STR_OFF Then
                m_mnuToolStripMenuItem.Text = FAST_REGEN
            ElseIf m_mnuToolStripMenuItem.Text = FAST_REGEN And Value = STR_ON Then
                m_mnuToolStripMenuItem.Text = Abort & " " & FAST_REGEN
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
  
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-09-10</date>
    ''' </author>
    ''' <summary>Set text for toolstrip menu item Online and Offline
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub DoOnline_Offline(ByVal value As String)
        AVPLib.Log.guiLogger.Info("Enter DoOnline_Offline")
        If value = "OFFLINE" Then '''Online unsuccess
            m_mnuToolStripMenuItem.Enabled = True
            m_mnuToolStripMenuItem.Text = MenuIndex.Online.ToString()
            m_mnuToolStripMenuItem.Tag = False
            ContainerForm.ChamberPanel(Me.Parent.Name).IsOnline = False
            ChangeTextMenuTo_Online_Offline(Me.Parent.Name, MenuIndex.Online, True)

        ElseIf value = "ONLINE" Then ''Offline 
            m_mnuToolStripMenuItem.Enabled = True
            m_mnuToolStripMenuItem.Text = MenuIndex.Offline.ToString()
            m_mnuToolStripMenuItem.Tag = True
            ContainerForm.ChamberPanel(Me.Parent.Name).IsOnline = True
            ChangeTextMenuTo_Online_Offline(Me.Parent.Name, MenuIndex.Offline, False)

        End If
        AVPLib.Log.guiLogger.Info("Leave DoOnline_Offline")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-22 </date>
    ''' </author>
    ''' <summary>
    ''' Change text on menu Online on IBE chamber
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangeTextMenuTo_Online_Offline(ByVal strChamberName As String, ByVal intIndexOfImage As Integer, _
                                                   ByVal blnValveEnableStatus As Boolean)
        AVPLib.Log.guiLogger.Info("Enter ChangeTextMenuTo_Online_Offline")
        Dim PanelChamber As ChamberPanel = ContainerForm.ChamberPanel(strChamberName)
        PanelChamber.btnTooltipMachine.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(intIndexOfImage)
        ''b/c btn btnTooltipMachine is behind the ChuckControl ->create PVDTooltipmachine
        If PanelChamber.ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
            If CType(PanelChamber, PVDPanel).RFTargetPowerSupplyVisible Then
                CType(PanelChamber, Chamber1RFPVDPanel).Online_OfflineValveStatus(blnValveEnableStatus, True)
                CType(PanelChamber, Chamber1RFPVDPanel).btnPVDTooltipMachine.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(intIndexOfImage)
            ElseIf CType(PanelChamber, PVDPanel).DCTargetPowerSupplyVisible Then
                CType(PanelChamber, Chamber1DCPVDPanel).Online_OfflineValveStatus(blnValveEnableStatus, True)
                CType(PanelChamber, Chamber1DCPVDPanel).btnPVDTooltipMachine.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(intIndexOfImage)
            Else 'not DC or RF
                CType(PanelChamber, PVDPanel).Online_OfflineValveStatus(blnValveEnableStatus, True)
                CType(PanelChamber, PVDPanel).btnPVDTooltipMachine.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(intIndexOfImage)
            End If
        ElseIf PanelChamber.ChamberType = AVPLib.SystemModule.ModuleType.IBE Then
            'CType(PanelChamber, Chamber1Panel).Online_OfflineValveStatus(blnValveEnableStatus, True)
            CType(PanelChamber, IBEPanel).Online_OfflineValveStatus(blnValveEnableStatus, True)
        End If
        AVPLib.Log.guiLogger.Info("Leave ChangeTextMenuTo_Online_Offline")
    End Sub
   
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''     <date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
    ''' <author>
    '''     	<name> Cao Anh Kiet </name>
    '''     	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub

#End Region

End Class
