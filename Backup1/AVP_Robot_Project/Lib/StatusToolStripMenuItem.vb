Imports System.Windows.Forms
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Public Class StatusToolStripMenuItem
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_mnuToolStripMenuItem As ToolStripMenuItem
    Private m_mnuParent As ContextMenuStrip
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
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with menu item that will be managed by this object
    ''' </summary>
    ''' <param name="mnuToolStripMenuItem"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal mnuToolStripMenuItem As ToolStripMenuItem, ByVal parent As ContextMenuStrip)
        Try
            m_mnuToolStripMenuItem = mnuToolStripMenuItem
            m_mnuParent = parent
            Me.Name = m_mnuToolStripMenuItem.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Dat Do </name>
    '''     <date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)

            Dim strBtnStartLLAText As String = ContainerForm.ProcessPanel.lpcLoadLockA.btnStart.Text
            If m_mnuParent.Name = "cmsLeftTool" Then ' Load Lock A.
                Me.LoadLockAClicked(strBtnStartLLAText, Value)
            ElseIf m_mnuParent.Name = "cmsMechineTool" Then ' Transfer Module.
                Me.MechineClicked(strBtnStartLLAText, Value)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-18</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
    ''' <author>
    '''     	<name> Ngo Cao Dinh </name>
    '''     	<date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub
    ''' <author>
    '''     	<name> Le Hieu Truc </name>
    '''     	<date> 2009-03-19</date>
    ''' </author>
    ''' <summary>
    ''' This procedure will set Visible and Enable Menu Item (6 params for Visible, 6 params for Enable)
    ''' </summary>
    ''' <param name="blnOnlineVisible"></param>
    ''' <param name="blnOnlineEnable"></param>
    ''' <remarks></remarks>
    Private Sub SetVisibleEnableMenuItemLeftTool(ByVal blnOnlineVisible As Boolean, ByVal blnOfflineVisible As Boolean, _
                                                 ByVal blnPumpDownVisible As Boolean, ByVal blnStopPumpDownVisible As Boolean, _
                                                 ByVal blnVentVisible As Boolean, ByVal blnStopVentVisible As Boolean, _
                                                 ByVal blnOnlineEnable As Boolean, ByVal blnOfflineEnable As Boolean, _
                                                 ByVal blnPumpDownEnable As Boolean, ByVal blnStopPumpDownEnable As Boolean, _
                                                 ByVal blnVentEnable As Boolean, ByVal blnStopVentEnable As Boolean)

        ContainerForm.CassettesPanel.SetVisibleMenuItemLeftTool(blnOnlineVisible, blnOfflineVisible, _
                                                                blnPumpDownVisible, blnStopPumpDownVisible, _
                                                                blnVentVisible, blnStopVentVisible)
        ContainerForm.CassettesPanel.SetEnableMenuItemLeftTool(blnOnlineEnable, blnOfflineEnable, _
                                                               blnPumpDownEnable, blnStopPumpDownEnable, _
                                                               blnVentEnable, blnStopVentEnable)
    End Sub

    Private Sub SetVisibleEnableMenuItemRightTool(ByVal blnOnlineVisible As Boolean, ByVal blnOfflineVisible As Boolean, _
                                                  ByVal blnPumpDownVisible As Boolean, ByVal blnStopPumpDownVisible As Boolean, _
                                                  ByVal blnVentVisible As Boolean, ByVal blnStopVentVisible As Boolean, _
                                                  ByVal blnOnlineEnable As Boolean, ByVal blnOfflineEnable As Boolean, _
                                                  ByVal blnPumpDownEnable As Boolean, ByVal blnStopPumpDownEnable As Boolean, _
                                                  ByVal blnVentEnable As Boolean, ByVal blnStopVentEnable As Boolean)

        ContainerForm.CassettesPanel.SetVisibleMenuItemRightTool(blnOnlineVisible, blnOfflineVisible, _
                                                                 blnPumpDownVisible, blnStopPumpDownVisible, _
                                                                 blnVentVisible, blnStopVentVisible)
        ContainerForm.CassettesPanel.SetEnableMenuItemRightTool(blnOnlineEnable, blnOfflineEnable, _
                                                                blnPumpDownEnable, blnStopPumpDownEnable, _
                                                                blnVentEnable, blnStopVentEnable)
    End Sub

    Private Sub SetVisibleEnableMenuItemMechineTool(ByVal blnOnlineVisible As Boolean, ByVal blnOfflineVisible As Boolean, _
                                                    ByVal blnPumpDownVisible As Boolean, ByVal blnStopPumpDownVisible As Boolean, _
                                                    ByVal blnVentVisible As Boolean, ByVal blnStopVentVisible As Boolean, _
                                                    ByVal blnOnlineEnable As Boolean, ByVal blnOfflineEnable As Boolean, _
                                                    ByVal blnPumpDownEnable As Boolean, ByVal blnStopPumpDownEnable As Boolean, _
                                                    ByVal blnVentEnable As Boolean, ByVal blnStopVentEnable As Boolean)

        ContainerForm.CassettesPanel.SetVisibleMenuItemMechineTool(blnOnlineVisible, blnOfflineVisible, _
                                                                   blnPumpDownVisible, blnStopPumpDownVisible, _
                                                                   blnVentVisible, blnStopVentVisible)
        ContainerForm.CassettesPanel.SetEnableMenuItemMechineTool(blnOnlineEnable, blnOfflineEnable, _
                                                                  blnPumpDownEnable, blnStopPumpDownEnable, _
                                                                  blnVentEnable, blnStopVentEnable)
        ContainerForm.ProcessPanel.TMCtl.lblHeader.Text = _
                                               IIf(blnOnlineVisible, ContainerForm.ProcessPanel.TMCtl.HeaderText_Offline, _
                                               ContainerForm.ProcessPanel.TMCtl.HeaderText_Online)
        ContainerForm.ProcessPanel.TMCtl.pnlHeader.BackgroundImage = _
                                               IIf(blnOnlineVisible, AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue, _
                                               AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen)
        ContainerForm.ProcessPanel.TMCtl.lblHeader.ForeColor = IIf(blnOnlineVisible, Color.White, Color.Black)
    End Sub
  
    ''' <author>
    '''     	<name> Le Hieu Truc </name>
    '''     	<date> 2009-03-26</date>
    ''' </author>
    ''' <summary>
    ''' This procedure will set for Visible Image when online and Enable/Disable Valve
    ''' </summary>
    ''' <param name="strPos">Left - Right - Machine Valve</param>
    ''' <param name="index">Image Index: can be 0 or 1</param>
    ''' <param name="blnStatus">status of valve: can be true or false</param>
    ''' <remarks></remarks>
    Private Sub SetValveStatusAndImage(ByVal index As Integer, ByVal strPos As String, ByVal blnStatus As Boolean)
        AVPLib.Log.guiLogger.Info("Enter SetValveStatusAndImage")
        Select Case strPos
            Case LEFT_VALVE 'is Left Valve
                ContainerForm.CassettesPanel.btnLeftTool.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(index)
                ContainerForm.CassettesPanel.LeftValveStatus(blnStatus)
            Case MACHINE_VALVE 'is Machine Valve
                ContainerForm.CassettesPanel.btnMechineTool.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(index)
                ContainerForm.CassettesPanel.MechineValveStatus(blnStatus)
            Case RIGHT_VALVE  'is Right Valve
                ContainerForm.CassettesPanel.btnRightTool.BackgroundImage = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(index)
                ContainerForm.CassettesPanel.RightValveStatus(blnStatus)
        End Select
        AVPLib.Log.guiLogger.Info("Leave SetValveStatusAndImage")
    End Sub
    
    ''' <author>
    '''     	<name> Le Hieu Truc </name>
    '''     	<date> 2009-03-19</date>
    ''' </author>
    ''' <summary>
    ''' This procedure will check condition for Visible and Enable Menu Item on Machine
    ''' </summary>
    ''' <param name="strBtnStartLLAText"></param>
    ''' <param name="strBtnStartLLBText"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Private Sub MechineClicked(ByVal strBtnStartLLAText As String, ByVal value As String)
        AVPLib.Log.guiLogger.Info("Enter MechineClicked")
        If value.CompareTo(STR_OFF) = 0 Then
            ''Value=Off - menu Online, Pumdown, Vent was clicked
            Select Case m_mnuToolStripMenuItem.Name
                Case MACHINEONLINE ''Online clicked
                    SetVisibleEnableMenuItemMechineTool(False, True, True, False, True, False, False, True, False, False, False, False)
                    SetValveStatusAndImage(1, MACHINE_VALVE, False)
                    ContainerForm.CassettesPanel.SetTMOnline(True)
                Case MACHINESTOPPUMPDOWN ''PumpDown clicked
                    SetVisibleEnableMenuItemMechineTool(True, False, False, True, True, False, False, False, False, True, False, False)
                Case MACHINESTOPVENT ''Vent clicked
                    SetVisibleEnableMenuItemMechineTool(True, False, True, False, False, True, False, False, False, False, False, True)
            End Select
        Else ''Value=On - menu Offline, stoppumdown, stopvent was clicked
            If m_mnuToolStripMenuItem.Name = MACHINEONLINE And strBtnStartLLAText = START Then
                ''no button is pause and resume
                SetVisibleEnableMenuItemMechineTool(True, False, True, False, True, False, True, False, True, False, True, False)
                SetValveStatusAndImage(0, MACHINE_VALVE, True)
                ContainerForm.CassettesPanel.SetTMOnline(False)
                AVPLib.Log.guiLogger.Info("Leave MechineClicked")
                Exit Sub
            Else 'running 
                Select Case m_mnuToolStripMenuItem.Name
                    Case MACHINEONLINE ''Offline clicked
                        SetVisibleEnableMenuItemMechineTool(True, False, True, False, True, False, True, False, False, False, False, False)
                        SetValveStatusAndImage(0, MACHINE_VALVE, True)
                        ContainerForm.CassettesPanel.SetTMOnline(False)
                    Case MACHINESTOPPUMPDOWN, MACHINESTOPVENT ''stoppumpdown clicked & stopvent clicked
                        ContainerForm.CassettesPanel.EvtTMVentPumpdownInProgress.Reset()
                        SetVisibleEnableMenuItemMechineTool(True, False, True, False, True, False, True, False, True, False, True, False)
                        ContainerForm.CassettesPanel.LockLoadARobotCassettes(True)
                        ContainerForm.Diagnostic.tabDiag_TM.Enabled = True
                End Select
            End If
        End If

        AVPLib.Log.guiLogger.Info("Leave MechineClicked")
    End Sub
    ''' <author>
    '''     	<name> Le Hieu Truc </name>
    '''     	<date> 2009-03-19</date>
    ''' </author>
    ''' <summary>
    ''' This procedure will check condition for Visible and Enable Menu Item on Load Lock A
    ''' </summary>
    ''' <param name="strBtnStartText"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Private Sub LoadLockAClicked(ByVal strBtnStartText As String, ByVal value As String)
        AVPLib.Log.guiLogger.Info("Enter LoadLockAClicked")
        ''LLA is not Running.
        If value.CompareTo(STR_OFF) = 0 Then
            ''value=off - menu online, pumpdown, vent was clicked before and we want to enable or disables other buttons appropriately.
            Select Case m_mnuToolStripMenuItem.Name
                Case LEFTONLINE ''Online clicked
                    SetVisibleEnableMenuItemLeftTool(False, True, True, False, True, False, False, True, False, False, False, False)
                    SetValveStatusAndImage(1, LEFT_VALVE, False)
                    ContainerForm.CassettesPanel.SetLLAOnline(True)
                Case LEFTSTOPPUMPDOWN ''PumpDown clicked
                    SetVisibleEnableMenuItemLeftTool(True, False, False, True, True, False, False, False, False, True, False, False)
                Case LEFTSTOPVENT ''Vent clicked
                    SetVisibleEnableMenuItemLeftTool(True, False, True, False, False, True, False, False, False, False, False, True)
            End Select

        Else ''Value=On - menu Offline was clicked or Online process succeeded or failed.
            If m_mnuToolStripMenuItem.Name = LEFTONLINE And (strBtnStartText = START) Then 'LLA is not running too.
                SetVisibleEnableMenuItemLeftTool(True, False, True, False, True, False, True, False, True, False, True, False)
                SetValveStatusAndImage(0, LEFT_VALVE, True)
                ContainerForm.CassettesPanel.SetLLAOnline(False)
                Exit Sub
            Else 'Already run (running, paused).
                Select Case m_mnuToolStripMenuItem.Name
                    Case LEFTONLINE ''menu Offline clicked
                        SetVisibleEnableMenuItemLeftTool(True, False, True, False, True, False, True, False, False, False, False, False)
                        SetValveStatusAndImage(0, LEFT_VALVE, True)
                        ContainerForm.CassettesPanel.SetLLAOnline(False)
                    Case LEFTSTOPPUMPDOWN, LEFTSTOPVENT ''stoppumpdown clicked & stopvent clicked
                        ContainerForm.CassettesPanel.EvtLLAVentPumpdownInProgress.Reset()
                        SetVisibleEnableMenuItemLeftTool(True, False, True, False, True, False, True, False, True, False, True, False)
                        ContainerForm.CassettesPanel.LockLoadARobotCassettes(True)
                        ContainerForm.Diagnostic.tabDiag_LLA.Enabled = True
                End Select
            End If
        End If

        AVPLib.Log.guiLogger.Info("Leave LoadLockAClicked")
    End Sub
#End Region

End Class
