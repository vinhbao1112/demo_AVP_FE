Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports System.Text.RegularExpressions
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.Utils

Public Enum ProtectedModStatus
    [On]
    [Off]
End Enum
Public Enum TranferWaferStatus
    [None]
    [Starting]
    [Error]
    [Finished]
End Enum
Public Class CassettesPanel
   
    Public Class TMProtectedMode
#Region "LocalVariable"
        Private m_status As ProtectedModStatus
        Private m_TMProtected_Time As Integer = 0
        Private m_TMProtected_Timer As Integer = 0
#End Region
#Region "Constructor"
        Public Sub New()
            m_status = ProtectedModStatus.Off
            m_TMProtected_Time = 0
            m_TMProtected_Timer = 0 ' get from file config here
        End Sub
        Public Sub New(ByVal IsOpen As Boolean, ByVal MaxTime As Integer)
            m_status = ProtectedModStatus.Off
            m_TMProtected_Time = MaxTime
            m_TMProtected_Timer = 0
        End Sub
#End Region
#Region "Properties"
        Public Property Status() As ProtectedModStatus
            Get
                Return m_status
            End Get
            Set(ByVal value As ProtectedModStatus)
                m_status = value
            End Set
        End Property
        Public Property MaxTime() As Integer
            Get
                Return m_TMProtected_Time
            End Get
            Set(ByVal value As Integer)
                m_TMProtected_Time = value
            End Set
        End Property
        Public Property CurrentTime() As Integer
            Get
                Return m_TMProtected_Timer
            End Get
            Set(ByVal value As Integer)
                m_TMProtected_Timer = value
            End Set
        End Property
#End Region
#Region "Function"
        Public Sub StartProtectedMode()
            m_status = ProtectedModStatus.On
        End Sub
        Public Sub StopProtectedMode()
            m_status = ProtectedModStatus.Off
            m_TMProtected_Timer = 0
        End Sub
#End Region
    End Class
#Region "Class Constants & Variables"
    Private Const CLICKEDNOWHERE As Integer = -1
    Private Const CLICKEDALIGNER As Integer = 0
    Private Const CLICKEDCHAMBER1 As Integer = 1
    Private Const CLICKEDCHAMBER2 As Integer = 2
    Private Const CLICKEDCHAMBER3 As Integer = 3
    Private Const CLICKEDCHAMBER4 As Integer = 4
    Private Const CLICKEDCHAMBER5 As Integer = 5
    Private Const CLICKEDCHAMBER6 As Integer = 6
    Private Const CLICKEDROBOT As Integer = 7
    Private m_Robot As Robot
    Private Shared m_intClickedChamber As Integer
    Public ISLLA_ONLINE As Boolean = False
    Public ISLLB_ONLINE As Boolean = False
    Public ISTM_ONLINE As Boolean = False
    Private m_PanelStyle As CX_Style = CX_Style.CX7
    Private m_PopUpPanel As TMPopUpPanel = Nothing
    Private m_LLACryoPopUpPanel As CryoPopUpPanel = Nothing
    Private m_LLBCryoPopUpPanel As CryoPopUpPanel = Nothing
    Private m_TMCryoPopUpPanel As CryoPopUpPanel = Nothing
    Private m_TM_Protected_Mode As TMProtectedMode
    Private m_ReturnWaferStatus As TranferWaferStatus = TranferWaferStatus.None
    Private m_ReturnStatusText As String = String.Empty
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
    Public ReadOnly Property PopUpPanel() As TMPopUpPanel
        Get
            Return m_PopUpPanel
        End Get
    End Property

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
    Public ReadOnly Property LLACryoPopUpPanel() As CryoPopUpPanel
        Get
            Return m_LLACryoPopUpPanel
        End Get
    End Property
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
    Public ReadOnly Property LLBCryoPopUpPanel() As CryoPopUpPanel
        Get
            Return m_LLBCryoPopUpPanel
        End Get
    End Property
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
    Public ReadOnly Property TMCryoPopUpPanel() As CryoPopUpPanel
        Get
            Return m_TMCryoPopUpPanel
        End Get
    End Property
    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''    	<date> 20098-10-29</date>
    ''' </author>
    ''' <summary>
    ''' Get ClickedPosition
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PanelStyle() As CX_Style
        Get
            Return m_PanelStyle
        End Get
        Set(ByVal value As CX_Style)
            m_PanelStyle = value
            If value = CX_Style.CX6 Then
                CX_PM5.Dispose()
                CX_PM6.Dispose()
                MesaValvePM5.Dispose()
                MesaValvePM6.Dispose()
                IgcgChamber5.Dispose()
                IgcgChamber6.Dispose()
            ElseIf value = CX_Style.CX7 Then
                CX_PM6.Dispose()
                MesaValvePM6.Dispose()
                IgcgChamber6.Dispose()
            End If
        End Set
    End Property

    Friend m_evtTMVentPumpdownInProgress As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public ReadOnly Property EvtTMVentPumpdownInProgress() As Threading.ManualResetEvent
        Get
            Return m_evtTMVentPumpdownInProgress
        End Get
    End Property

    Friend m_evtLLAVentPumpdownInProgress As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public ReadOnly Property EvtLLAVentPumpdownInProgress() As Threading.ManualResetEvent
        Get
            Return m_evtLLAVentPumpdownInProgress
        End Get
    End Property

    Friend m_evtLLBVentPumpdownInProgress As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public ReadOnly Property EvtLLBVentPumpdownInProgress() As Threading.ManualResetEvent
        Get
            Return m_evtLLBVentPumpdownInProgress
        End Get
    End Property


    Public Property ReturnWaferStatus() As TranferWaferStatus
        Get
            Return m_ReturnWaferStatus
        End Get
        Set(ByVal value As TranferWaferStatus)
            m_ReturnWaferStatus = value
        End Set
    End Property
    'Dat Cao
    '31-03-2011
    Public ReadOnly Property TM_ProtectedMode() As TMProtectedMode
        Get
            If (m_TM_Protected_Mode Is Nothing) Then
                m_TM_Protected_Mode = New TMProtectedMode(False, 100)
            End If
            Return m_TM_Protected_Mode
        End Get
    End Property
#End Region

#Region "Constructors & Dispose"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Initalize cassettes panel
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            m_Robot = New Robot("CassetteRobot")
            IgcgChamber1.Left = crcTMCryo.Left + crcTMCryo.Width + 30
            IgcgChamber1.Top = CX_PM1.Top - IgcgChamber1.Height - 2

            IgcgChamber2.Left = CX_PM2.Left - 40
            IgcgChamber2.Top = CX_PM2.Top - IgcgChamber2.Height - 10

            IgcgChamber3.Left = CX_PM3.Left
            IgcgChamber3.Top = TMCtl.Top

            IgcgChamber4.Left = CX_PM4.Left + CX_PM4.Width / 2 + 10
            IgcgChamber4.Top = IgcgChamber2.Top

            IgcgChamber5.Left = CX_PM5.Left + CX_PM5.Width / 2
            IgcgChamber5.Top = IgcgChamber1.Top + 3

            ticHandOriginal.Location = New System.Drawing.Point(400, 165) '(448, 267)
            m_Robot.Hands(Positions.Original) = ticHandOriginal

            lccLoadLockA.SemiautoTransferWaferPanel = stwSemiautoTransferWafer
            lccLoadLockA.LockName = "A"
            lccLoadLockB.SemiautoTransferWaferPanel = stwSemiautoTransferWafer
            lccLoadLockB.LockName = "B"
            m_intClickedChamber = CLICKEDNOWHERE
            stwSemiautoTransferWafer.Width = 280
            atwAutoTransferWafer.Width = 280
            sccSerialCommand.Width = 280

            Me.SetVisibleMenuItemMechineTool(True, False, True, False, True, False)
            Me.SetVisibleMenuItemLeftTool(True, False, True, False, True, False)
            Me.SetVisibleMenuItemRightTool(True, False, True, False, True, False)
            Me.SetEnableMenuItemMechineTool(True, False, True, False, True, False)
            Me.SetEnableMenuItemLeftTool(True, False, True, False, True, False)
            Me.SetEnableMenuItemRightTool(True, False, True, False, True, False)

            m_PopUpPanel = New TMPopUpPanel
            m_PopUpPanel.Name = "PopUpPanel"
            m_PopUpPanel.StartPosition = FormStartPosition.CenterScreen
            m_PopUpPanel.ShowInTaskbar = False
            m_PopUpPanel.ShowIcon = False
            m_PopUpPanel.lblTitle.Text = "TM Menu"
            m_PopUpPanel.Hide()

            m_LLACryoPopUpPanel = New CryoPopUpPanel
            m_LLACryoPopUpPanel.Name = "LLACryoPopUpPanel"
            m_LLACryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
            m_LLACryoPopUpPanel.ShowInTaskbar = False
            m_LLACryoPopUpPanel.ShowIcon = False
            m_LLACryoPopUpPanel.lblTitle.Text = "LLA Cryo Menu"
            m_LLACryoPopUpPanel.Hide()
            m_LLACryoPopUpPanel.PanelHandle = ConstEnum.Equipments.LoadLockA.ToString()
            m_LLACryoPopUpPanel.txtExtendedPurgeTime.SourceOfMessageBox = "CryoPopUpPanel"
            m_LLACryoPopUpPanel.txtPumpRestartDelay.SourceOfMessageBox = "CryoPopUpPanel"
            m_LLACryoPopUpPanel.txtRateOfRise.SourceOfMessageBox = "CryoPopUpPanel"
            m_LLACryoPopUpPanel.txtRoughToPressure.SourceOfMessageBox = "CryoPopUpPanel"
            m_LLACryoPopUpPanel.txtStartUpTemp.SourceOfMessageBox = "CryoPopUpPanel"
            m_LLACryoPopUpPanel.txtRepurgeCycles.SourceOfMessageBox = "CryoPopUpPanel"


        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub InitializeShutterForPM_CX5()
        If RobotConfigurationValues.CHAMBER1_VISIBLE Then
            With CX_PM1
                .CX_Supported = PMControl.Support_CX.Support_CX5
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM1 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER2_VISIBLE Then
            With CX_PM2
                .CX_Supported = PMControl.Support_CX.Support_CX5
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM2 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER3_VISIBLE Then
            With CX_PM3
                .CX_Supported = PMControl.Support_CX.Support_CX5
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM3 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
    End Sub

    Private Sub InitializeShutterForPM_CX6()
        If RobotConfigurationValues.CHAMBER1_VISIBLE Then
            With CX_PM1
                .CX_Supported = PMControl.Support_CX.Support_CX6
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM1 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER2_VISIBLE Then
            With CX_PM2
                .CX_Supported = PMControl.Support_CX.Support_CX6
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM2 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER3_VISIBLE Then
            With CX_PM3
                .CX_Supported = PMControl.Support_CX.Support_CX6
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM3 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER4_VISIBLE Then
            With CX_PM4
                .CX_Supported = PMControl.Support_CX.Support_CX6
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM4 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
    End Sub

    Private Sub InitializeShutterForPM_CX7()
        If RobotConfigurationValues.CHAMBER1_VISIBLE Then
            With CX_PM1
                .CX_Supported = PMControl.Support_CX.Support_CX7
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM1 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER2_VISIBLE Then
            With CX_PM2
                .CX_Supported = PMControl.Support_CX.Support_CX7
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM2 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER3_VISIBLE Then
            With CX_PM3
                .CX_Supported = PMControl.Support_CX.Support_CX7
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM3 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER4_VISIBLE Then
            With CX_PM4
                .CX_Supported = PMControl.Support_CX.Support_CX7
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM4 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER5_VISIBLE Then
            With CX_PM5
                .CX_Supported = PMControl.Support_CX.Support_CX7
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM5 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
    End Sub

    Private Sub InitializeShutterForPM_CX8()
        If RobotConfigurationValues.CHAMBER1_VISIBLE Then
            With CX_PM1
                .CX_Supported = PMControl.Support_CX.Support_CX8
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM1 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER2_VISIBLE Then
            With CX_PM2
                .CX_Supported = PMControl.Support_CX.Support_CX8
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM2 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER3_VISIBLE Then
            With CX_PM3
                .CX_Supported = PMControl.Support_CX.Support_CX8
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM3 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER4_VISIBLE Then
            With CX_PM4
                .CX_Supported = PMControl.Support_CX.Support_CX8
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM4 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER5_VISIBLE Then
            With CX_PM5
                .CX_Supported = PMControl.Support_CX.Support_CX8
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM5 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER6_VISIBLE Then
            With CX_PM6
                .CX_Supported = PMControl.Support_CX.Support_CX8
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = PMControl.PMPosition.PVD_PM6 Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
    End Sub


    Private Sub Initialize_CX5()
#If AVP_CX_STYLE = "CX5" Then
        ''robot body config
        Robot_Body.CX_Supported = PMControl.Support_CX.Support_CX5
        Robot_Body.PM_IN_SCREEN = PMControl.Support_Screen.TM
        Robot_Body.Location = New Point(423, 203)
        If AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False Then
            Robot_Body.SensorLLA.Visible = False
            Robot_Body.SensorLLB.Visible = False
            Robot_Body.SensorPM1.Visible = False
            Robot_Body.SensorPM2.Visible = False
            Robot_Body.SensorPM3.Visible = False
        Else
            Robot_Body.SensorLLA_Position = New Point(40, 140)
            Robot_Body.SensorLLB_Position = New Point(121, 140)
            Robot_Body.SensorPM1_Position = New Point(7, 80)
            Robot_Body.SensorPM2_Position = New Point(83, 7)
            Robot_Body.SensorPM3_Position = New Point(153, 80)
        End If
        
        ticHandOriginal.CXStyle = RobotHand.CX_Style.CX5
        If AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
            If RobotConfigurationValues.ALIGNER_AT_STATION = 1 Then
                awcAligner.Location = New Point(432, 362)
            Else
                awcAligner.Location = New Point(560, 362)
            End If
        Else
            awcAligner.Visible = False
        End If

        ticHandOriginal.Location = New Point(459, 230)
        tabGroup.Top = TMCtl.Top
        IgcgChamber1.Location = New Point(244, 190)
        IgcgChamber2.Location = New Point(330, 28)
        IgcgChamber3.Location = New Point(650, 190)
        'push station id to control

        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM1_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM2_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM3_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.ALIGNER_STATION_NO.ToString()) '9
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO.ToString()) '8
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.LLA_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.LLB_STATION_NO.ToString())

        ''MesaValves config
        MesaValveLLA.CXStyle = RoundRectangleStatusControl.CX_Style.CX5
        MesaValveLLA.Style_CX5 = RoundRectangleStatusControl.DisplayStyle_CX5.LLA
        MesaValveLLA.Location = New Point(405, 387) '417
        MesaValveLLA.Size = New Size(75, 49)

        MesaValveLLB.CXStyle = RoundRectangleStatusControl.CX_Style.CX5
        MesaValveLLB.Style_CX5 = RoundRectangleStatusControl.DisplayStyle_CX5.LLB
        MesaValveLLB.Location = New Point(544, 387) '554
        MesaValveLLB.Size = New Size(75, 49)

        MesaValvePM1.CXStyle = RoundRectangleStatusControl.CX_Style.CX5
        MesaValvePM1.Style_CX5 = RoundRectangleStatusControl.DisplayStyle_CX5.PM1
        MesaValvePM1.Location = New Point(410, 240)
        MesaValvePM1.Size = New Size(16, 100)

        MesaValvePM2.CXStyle = RoundRectangleStatusControl.CX_Style.CX5
        MesaValvePM2.Style_CX5 = RoundRectangleStatusControl.DisplayStyle_CX5.PM2
        MesaValvePM2.Location = New Point(460, 191)
        MesaValvePM2.Size = New Size(100, 16)

        MesaValvePM3.CXStyle = RoundRectangleStatusControl.CX_Style.CX5
        MesaValvePM3.Style_CX5 = RoundRectangleStatusControl.DisplayStyle_CX5.PM3
        MesaValvePM3.Location = New Point(592, 240)
        MesaValvePM3.Size = New Size(16, 100)

        MesaValvePM4.Visible = False
        MesaValvePM5.Visible = False
        MesaValvePM6.Visible = False


        HivacValveLLA.CXStyle = RoundRectangleStatusControl.CX_Style.CX5
        HivacValveLLA.Style_CX5 = RoundRectangleStatusControl.DisplayStyle_CX5.HIVAC_LLA
        HivacValveLLA.Location = New Point(360, 393)
        HivacValveLLA.Size = New Size(43, 62)

        HivacValveLLB.CXStyle = RoundRectangleStatusControl.CX_Style.CX5
        HivacValveLLB.Style_CX5 = RoundRectangleStatusControl.DisplayStyle_CX5.HIVAC_LLB
        HivacValveLLB.Location = New Point(623, 393)
        HivacValveLLB.Size = New Size(43, 62)

        '''Button tool
        btnLeftTool.Location = New Point(363, 442)
        btnRightTool.Location = New Point(640, 442)
        btnMechineTool.Location = New Point(499, 377)

        '''Change gas line
        GasLineNitrogen.Image = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_MainModule
        GasLineNitrogen.ImageSize = New Size(1000, 374)
        GasLineNitrogen.IsChamberPic = False
        GasLineNitrogen.IsStretch = False
        GasLineNitrogen.Location = New Point(11, 336)
        GasLineNitrogen.Size = New Size(1025, 397)
        '''gas line in the left
        GasLineVentValveLLA.Image = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_GasLine_VentValveLLA
        GasLineVentValveLLA.ImageSize = New Size(140, 140)
        GasLineVentValveLLA.IsChamberPic = False
        GasLineVentValveLLA.IsStretch = False
        GasLineVentValveLLA.Location = New Point(34, 374)

        GasLineRoughValveLLB.Image = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_GasLine_RoughValveLLA
        GasLineRoughValveLLB.ImageSize = New Size(140, 120)
        GasLineRoughValveLLB.IsChamberPic = False
        GasLineRoughValveLLB.IsStretch = False
        GasLineRoughValveLLB.Location = New Point(32, 473)
        GasLineRoughValveLLB.Size = New Size(552, 90)

        ''gas line in the right
        GasLineVentValveLLB.Image = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_GasLine_VentValveLLB
        GasLineVentValveLLB.ImageSize = New Size(200, 140)
        GasLineVentValveLLB.IsChamberPic = False
        GasLineVentValveLLB.IsStretch = False
        GasLineVentValveLLB.Location = New Point(638, 371)

        GasLineRoughValveLLA.Image = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_GasLine_RoughValveLLB
        GasLineRoughValveLLA.ImageSize = New Size(320, 120)
        GasLineRoughValveLLA.IsChamberPic = False
        GasLineRoughValveLLA.IsStretch = False
        GasLineRoughValveLLA.Location = New Point(450, 468)
        GasLineRoughValveLLA.Size = New Size(538, 80)
        '''Valves
        ValveVent.Location = New Point(79, 326)
        lblFastVentValve.Location = New Point(ValveVent.Left + 7, ValveVent.Top + ValveVent.Height + 2)
        ValveLLASlowVent.Location = New Point(241, 362)
        lblLLASlowVent.Location = New Point(ValveLLASlowVent.Left - 5, ValveLLASlowVent.Top + ValveLLASlowVent.Height + 2)
        ValveLLAFastVent.Location = New Point(241, 432)
        lblLLAFastVent.Location = New Point(ValveLLAFastVent.Left - 5, ValveLLAFastVent.Top + ValveLLAFastVent.Height + 2)
        ValveLLBSlowVent.Location = New Point(107, 468)
        lblLLBSlowVent.Location = New Point(ValveLLBSlowVent.Left - 5, ValveLLBSlowVent.Top + ValveLLBSlowVent.Height + 2)
        ValveLLBFastVent.Location = New Point(107, 533)
        lblLLBFastVent.Location = New Point(ValveLLBFastVent.Left - 5, ValveLLBFastVent.Top + ValveLLBFastVent.Height + 2)

        ValveRough.Location = New Point(894, 326)
        lblFastRoughtValve.Location = New Point(ValveRough.Left + 7, ValveRough.Top + ValveRough.Height + 2)
        ValveLLBSlowRough.Location = New Point(745, 360)
        lblLLBSlowRough.Location = New Point(ValveLLBSlowRough.Left - 5, ValveLLBSlowRough.Top + ValveLLBSlowRough.Height + 2)
        ValveLLBFastRough.Location = New Point(743, 420)
        lblLLBFastRough.Location = New Point(ValveLLBFastRough.Left - 5, ValveLLBFastRough.Top + ValveLLBFastRough.Height + 2)
        ValveLLASlowRough.Location = New Point(866, 456)
        lblLLASlowRough.Location = New Point(ValveLLASlowRough.Left - 5, ValveLLASlowRough.Top + ValveLLASlowRough.Height + 2)
        ValveLLAFastRough.Location = New Point(866, 517)
        lblLLAFastRough.Location = New Point(ValveLLAFastRough.Left - 5, ValveLLAFastRough.Top + ValveLLAFastRough.Height + 2)

        RoughPumpControl.Location = New Point(970, 545)

        '===========
        'load lock A config
        If RobotConfigurationValues.LOADLOCKA_VISIBLE Then
            LLALeg.Leg_In_Screen = PMControl.Support_Screen.TM
            LLALeg.LoadLockType = LoadLockLeg.Load_Lock_Type.Type_2
            LLALeg.LegStatus = BinaryStatusControl.DisplayStatus.On
            LLALeg.EQ_LoadLock = Equipments.LoadLockA
            LLALeg.Location = New Point(365, 342)
            LLALeg.QuestionMark_Visible = False
            LLALeg.QuestionMark_Location = New Point(5, 65)
            LLALeg.Cassette_Location = New Point(20, 65)
            LLALeg.LegLocation = New Point(0, 142)

        End If

        ''Load lock B config
        If RobotConfigurationValues.LOADLOCKB_VISIBLE Then
            LLBLeg.Leg_In_Screen = PMControl.Support_Screen.TM
            LLBLeg.LoadLockType = LoadLockLeg.Load_Lock_Type.Type_2
            LLBLeg.Location = New Point(516, 342)
            LLBLeg.QuestionMark_Visible = False
            LLBLeg.LegStatus = BinaryStatusControl.DisplayStatus.On
            LLBLeg.EQ_LoadLock = Equipments.LoadLockB
            LLBLeg.QuestionMark_Location = New Point(80, 65)
            LLBLeg.Cassette_Location = New Point(35, 65)
            LLBLeg.LegLocation = New Point(21, 142)
        End If

        ''Chamber config
        If AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
            CX_PM1.CX_Supported = PMControl.Support_CX.Support_CX5
            CX_PM1.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM1.ShowWafer_Border_ToEdit = False
            CX_PM1.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM1.PM_Type = PMControl.PMPosition.IBE_PM1
                CX_PM1.Location = New Point(244, 230)
                CX_PM1.WaferLocation = New Point(47, 23)
                CX_PM1.LabelDisconnect_Location = New Point(28, 50)

            ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM1.PM_Type = PMControl.PMPosition.PVD_PM1
                CX_PM1.Location = New Point(243, 232)
                CX_PM1.WaferLocation = New Point(60, 20)
                CX_PM1.LabelDisconnect_Location = New Point(40, 43)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
            CX_PM2.CX_Supported = PMControl.Support_CX.Support_CX5
            CX_PM2.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM2.ShowWafer_Border_ToEdit = False
            CX_PM2.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM2.PM_Type = PMControl.PMPosition.IBE_PM2
                CX_PM2.Location = New Point(457, 25)
                CX_PM2.WaferLocation = New Point(22, 48)
                CX_PM2.LabelDisconnect_Location = New Point(7, 57)
            ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM2.PM_Type = PMControl.PMPosition.PVD_PM2
                CX_PM2.Location = New Point(456, 22)
                CX_PM2.WaferLocation = New Point(30, 60)
                CX_PM2.LabelDisconnect_Location = New Point(10, 70)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
            CX_PM3.CX_Supported = PMControl.Support_CX.Support_CX5
            CX_PM3.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM3.ShowWafer_Border_ToEdit = False
            CX_PM3.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM3.PM_Type = PMControl.PMPosition.IBE_PM3
                CX_PM3.Location = New Point(594, 230)
                CX_PM3.WaferLocation = New Point(77, 23)
                CX_PM3.LabelDisconnect_Location = New Point(60, 50)
            ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM3.PM_Type = PMControl.PMPosition.PVD_PM3
                CX_PM3.Location = New Point(594, 232)
                CX_PM3.WaferLocation = New Point(67, 20)
                CX_PM3.LabelDisconnect_Location = New Point(51, 43)
            End If
        End If

        InitializeShutterForPM_CX5()
#End If
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Initalize cassettes panel for CX6
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initialize_CX6()
#If AVP_CX_STYLE = "CX6" Then
        ''robot body config
        Robot_Body.CX_Supported = PMControl.Support_CX.Support_CX6
        Robot_Body.PM_IN_SCREEN = PMControl.Support_Screen.TM
        Robot_Body.Location = New Point(413, 170)
        Robot_Body.SensorLLA_Position = New Point(57, 155)
        Robot_Body.SensorLLB_Position = New Point(138, 155)
        Robot_Body.SensorPM1_Position = New Point(10, 90)
        Robot_Body.SensorPM2_Position = New Point(58, 28)
        Robot_Body.SensorPM3_Position = New Point(143, 28)
        Robot_Body.SensorPM4_Position = New Point(185, 90)
        ticHandOriginal.CXStyle = RobotHand.CX_Style.CX6
        If RobotConfigurationValues.ALIGNER_AT_STATION = 1 Then
            awcAligner.Location = New Point(447, 337)
        Else
            awcAligner.Location = New Point(550, 339)
        End If

        ticHandOriginal.Location = New Point(459, 230)
        tabGroup.Top = TMCtl.Top
        IgcgChamber1.Location = New Point(156, 280)
        IgcgChamber2.Location = New Point(323, 28)
        IgcgChamber3.Location = New Point(600, 28)
        IgcgChamber4.Location = New Point(765, 280)
        'push station id to control

        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM1_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM2_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM3_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM4_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.ALIGNER_STATION_NO.ToString()) '9
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO.ToString()) '8
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.LLA_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.LLB_STATION_NO.ToString())

        ''MesaValves config
        MesaValveLLA.CXStyle = RoundRectangleStatusControl.CX_Style.CX6
        MesaValveLLA.Style_CX6 = RoundRectangleStatusControl.DisplayStyle_CX6.LLA
        MesaValveLLA.Location = New Point(417, 358) '417
        MesaValveLLA.Size = New Size(72, 38)

        MesaValveLLB.CXStyle = RoundRectangleStatusControl.CX_Style.CX6
        MesaValveLLB.Style_CX6 = RoundRectangleStatusControl.DisplayStyle_CX6.LLB
        MesaValveLLB.Location = New Point(544, 358) '554
        MesaValveLLB.Size = New Size(72, 38)

        MesaValvePM1.CXStyle = RoundRectangleStatusControl.CX_Style.CX6
        MesaValvePM1.Style_CX6 = RoundRectangleStatusControl.DisplayStyle_CX6.PM1
        MesaValvePM1.Location = New Point(403, 230)
        MesaValvePM1.Size = New Size(16, 80)

        MesaValvePM2.CXStyle = RoundRectangleStatusControl.CX_Style.CX6
        MesaValvePM2.Style_CX6 = RoundRectangleStatusControl.DisplayStyle_CX6.PM2
        MesaValvePM2.Location = New Point(425, 168)
        MesaValvePM2.Size = New Size(80, 44)

        MesaValvePM3.CXStyle = RoundRectangleStatusControl.CX_Style.CX6
        MesaValvePM3.Style_CX6 = RoundRectangleStatusControl.DisplayStyle_CX6.PM3
        MesaValvePM3.Location = New Point(535, 167)
        MesaValvePM3.Size = New Size(80, 44)

        MesaValvePM4.CXStyle = RoundRectangleStatusControl.CX_Style.CX6
        MesaValvePM4.Style_CX6 = RoundRectangleStatusControl.DisplayStyle_CX6.PM4
        MesaValvePM4.Location = New Point(617, 229)
        MesaValvePM4.Size = New Size(16, 80)

        HivacValveLLA.CXStyle = RoundRectangleStatusControl.CX_Style.CX6
        HivacValveLLA.Style_CX6 = RoundRectangleStatusControl.DisplayStyle_CX6.HIVAC_LLA
        HivacValveLLA.Location = New Point(343, 370)
        HivacValveLLA.Size = New Size(56, 73)

        HivacValveLLB.CXStyle = RoundRectangleStatusControl.CX_Style.CX6
        HivacValveLLB.Style_CX6 = RoundRectangleStatusControl.DisplayStyle_CX6.HIVAC_LLB
        HivacValveLLB.Location = New Point(633, 370)
        HivacValveLLB.Size = New Size(55, 74)

        '''Button tool
        btnLeftTool.Location = New Point(363, 431)
        btnRightTool.Location = New Point(640, 431)
        btnMechineTool.Location = New Point(503, 364)
        '''Change gas line
        GasLineNitrogen.Image = AVP_Robot_Project.My.Resources.CX6_Resources.CX6_MainModule
        GasLineNitrogen.ImageSize = New Size(1000, 374)
        GasLineNitrogen.IsChamberPic = False
        GasLineNitrogen.IsStretch = False
        GasLineNitrogen.Location = New Point(11, 326)
        GasLineNitrogen.Size = New Size(1025, 397)
        '''gas line in the left
        GasLineVentValveLLA.Image = AVP_Robot_Project.My.Resources.CX6_Resources.CX6_GasLine_VentValveLLA
        GasLineVentValveLLA.ImageSize = New Size(140, 140)
        GasLineVentValveLLA.IsChamberPic = False
        GasLineVentValveLLA.IsStretch = False
        GasLineVentValveLLA.Location = New Point(34, 354)

        GasLineRoughValveLLB.Image = AVP_Robot_Project.My.Resources.CX6_Resources.CX6_GasLine_RoughValveLLA
        GasLineRoughValveLLB.ImageSize = New Size(140, 120)
        GasLineRoughValveLLB.IsChamberPic = False
        GasLineRoughValveLLB.IsStretch = False
        GasLineRoughValveLLB.Location = New Point(32, 448)
        GasLineRoughValveLLB.Size = New Size(552, 90)

        ''gas line in the right
        GasLineVentValveLLB.Image = AVP_Robot_Project.My.Resources.CX6_Resources.CX6_GasLine_VentValveLLB
        GasLineVentValveLLB.ImageSize = New Size(200, 140)
        GasLineVentValveLLB.IsChamberPic = False
        GasLineVentValveLLB.IsStretch = False
        GasLineVentValveLLB.Location = New Point(643, 351)

        GasLineRoughValveLLA.Image = AVP_Robot_Project.My.Resources.CX6_Resources.CX6_GasLine_RoughValveLLB
        GasLineRoughValveLLA.ImageSize = New Size(320, 120)
        GasLineRoughValveLLA.IsChamberPic = False
        GasLineRoughValveLLA.IsStretch = False
        GasLineRoughValveLLA.Location = New Point(450, 438)
        GasLineRoughValveLLA.Size = New Size(538, 80)
        '''Valves
        ValveVent.Location = New Point(79, 319)
        lblFastVentValve.Location = New Point(ValveVent.Left + 7, ValveVent.Top + ValveVent.Height + 2)
        ValveLLASlowVent.Location = New Point(241, 342)
        lblLLASlowVent.Location = New Point(ValveLLASlowVent.Left - 5, ValveLLASlowVent.Top + ValveLLASlowVent.Height + 2)
        ValveLLAFastVent.Location = New Point(241, 402)
        lblLLAFastVent.Location = New Point(ValveLLAFastVent.Left - 5, ValveLLAFastVent.Top + ValveLLAFastVent.Height + 2)
        ValveLLBSlowVent.Location = New Point(107, 443)
        lblLLBSlowVent.Location = New Point(ValveLLBSlowVent.Left - 5, ValveLLBSlowVent.Top + ValveLLBSlowVent.Height + 2)
        ValveLLBFastVent.Location = New Point(107, 503)
        lblLLBFastVent.Location = New Point(ValveLLBFastVent.Left - 5, ValveLLBFastVent.Top + ValveLLBFastVent.Height + 2)

        ValveRough.Location = New Point(894, 319)
        lblFastRoughtValve.Location = New Point(ValveRough.Left + 7, ValveRough.Top + ValveRough.Height + 2)
        ValveLLBSlowRough.Location = New Point(745, 340)
        lblLLBSlowRough.Location = New Point(ValveLLBSlowRough.Left - 5, ValveLLBSlowRough.Top + ValveLLBSlowRough.Height + 2)
        ValveLLBFastRough.Location = New Point(743, 400)
        lblLLBFastRough.Location = New Point(ValveLLBFastRough.Left - 5, ValveLLBFastRough.Top + ValveLLBFastRough.Height + 2)
        ValveLLASlowRough.Location = New Point(866, 426)
        lblLLASlowRough.Location = New Point(ValveLLASlowRough.Left - 5, ValveLLASlowRough.Top + ValveLLASlowRough.Height + 2)
        ValveLLAFastRough.Location = New Point(866, 487)
        lblLLAFastRough.Location = New Point(ValveLLAFastRough.Left - 5, ValveLLAFastRough.Top + ValveLLAFastRough.Height + 2)

        'RoughPumpControl.Location = New Point(974, 552)

        '===========
        'load lock A config
        If RobotConfigurationValues.LOADLOCKA_VISIBLE Then
            LLALeg.Leg_In_Screen = PMControl.Support_Screen.TM
            LLALeg.LegStatus = BinaryStatusControl.DisplayStatus.Off
            LLALeg.EQ_LoadLock = Equipments.LoadLockA
            LLALeg.Location = New Point(355, 355)
            LLALeg.QuestionMark_Visible = False
            LLALeg.QuestionMark_Location = New Point(0, 65)
            LLALeg.Cassette_Location = New Point(23, 33)
            LLALeg.LegLocation = New Point(0, 104)
        End If

        ''Load lock B config
        If RobotConfigurationValues.LOADLOCKB_VISIBLE Then
            LLBLeg.Leg_In_Screen = PMControl.Support_Screen.TM
            LLBLeg.Location = New Point(550, 355)
            LLBLeg.QuestionMark_Visible = False
            LLBLeg.LegStatus = BinaryStatusControl.DisplayStatus.Off
            LLBLeg.EQ_LoadLock = Equipments.LoadLockB
            LLBLeg.QuestionMark_Location = New Point(87, 65)
            LLBLeg.Cassette_Location = New Point(21, 33)
            LLBLeg.LegLocation = New Point(15, 104)
        End If

        ''Chamber config
        If AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
            CX_PM1.CX_Supported = PMControl.Support_CX.Support_CX6
            CX_PM1.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM1.ShowWafer_Border_ToEdit = False
            CX_PM1.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM1.PM_Type = PMControl.PMPosition.IBE_PM1
                CX_PM1.Location = New Point(264, 220)
                CX_PM1.WaferLocation = New Point(37, 18)
                CX_PM1.LabelDisconnect_Location = New Point(10, 40)

            ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM1.PM_Type = PMControl.PMPosition.PVD_PM1
                CX_PM1.Location = New Point(216, 222)
                CX_PM1.WaferLocation = New Point(75, 19)
                CX_PM1.LabelDisconnect_Location = New Point(60, 40)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
            CX_PM2.CX_Supported = PMControl.Support_CX.Support_CX6
            CX_PM2.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM2.ShowWafer_Border_ToEdit = False
            CX_PM2.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM2.PM_Type = PMControl.PMPosition.IBE_PM2
                CX_PM2.Location = New Point(358, 40)
                CX_PM2.WaferLocation = New Point(38, 48)
                CX_PM2.LabelDisconnect_Location = New Point(20, 60)
            ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM2.PM_Type = PMControl.PMPosition.PVD_PM2
                CX_PM2.Location = New Point(350, 2)
                CX_PM2.WaferLocation = New Point(44, 82)
                CX_PM2.LabelDisconnect_Location = New Point(30, 100)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
            CX_PM3.CX_Supported = PMControl.Support_CX.Support_CX6
            CX_PM3.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM3.ShowWafer_Border_ToEdit = False
            CX_PM3.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM3.PM_Type = PMControl.PMPosition.IBE_PM3
                CX_PM3.Location = New Point(534, 35)
                CX_PM3.WaferLocation = New Point(46, 50)
                CX_PM3.LabelDisconnect_Location = New Point(30, 60)
            ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM3.PM_Type = PMControl.PMPosition.PVD_PM3
                CX_PM3.Location = New Point(536, 3)
                CX_PM3.WaferLocation = New Point(39, 75)
                CX_PM3.LabelDisconnect_Location = New Point(30, 100)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER4_VISIBLE Then
            CX_PM4.CX_Supported = PMControl.Support_CX.Support_CX6
            CX_PM4.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM4.ShowWafer_Border_ToEdit = False
            CX_PM4.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER4_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM4.PM_Type = PMControl.PMPosition.IBE_PM4
                CX_PM4.Location = New Point(611, 220)
                CX_PM4.WaferLocation = New Point(63, 16)
                CX_PM4.LabelDisconnect_Location = New Point(40, 40)
            ElseIf RobotConfigurationValues.CHAMBER4_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM4.PM_Type = PMControl.PMPosition.PVD_PM4
                CX_PM4.Location = New Point(624, 222)
                CX_PM4.WaferLocation = New Point(56, 10)
                CX_PM4.LabelDisconnect_Location = New Point(40, 40)
            End If
        End If
        InitializeShutterForPM_CX6()
#End If
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Initalize cassettes panel for CX7
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initialize_CX7()
#If AVP_CX_STYLE = "CX7" Then
        ''robot body config
        ticHandOriginal.CXStyle = RobotHand.CX_Style.CX7
        Robot_Body.CX_Supported = PMControl.Support_CX.Support_CX7
        Robot_Body.PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen
        Robot_Body.Location = New Point(402, 171) '(402, 171)
        Robot_Body.SensorLLA_Position = New Point(55, 148)
        Robot_Body.SensorLLB_Position = New Point(135, 148)
        Robot_Body.SensorPM1_Position = New Point(20, 90)
        Robot_Body.SensorPM2_Position = New Point(45, 35)
        Robot_Body.SensorPM3_Position = New Point(98, 20)
        Robot_Body.SensorPM4_Position = New Point(148, 35)
        Robot_Body.SensorPM5_Position = New Point(171, 89)

        IgcgChamber1.Location = New Point(150, 250)
        IgcgChamber2.Location = New Point(243, 70)
        IgcgChamber3.Location = New Point(440, 20)
        IgcgChamber4.Location = New Point(650, 70)
        IgcgChamber5.Location = New Point(730, IgcgChamber1.Top)
        'push station id to control
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM1_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM2_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM3_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM4_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM5_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.ALIGNER_STATION_NO.ToString()) '9
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO.ToString()) '8
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.LLA_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.LLB_STATION_NO.ToString())

        If RobotConfigurationValues.ALIGNER_AT_STATION = 1 Then
            awcAligner.Location = New Point(437, 339)
        Else
            awcAligner.Location = New Point(528, 343)
        End If

        ''MesaValves config
        MesaValveLLA.CXStyle = RoundRectangleStatusControl.CX_Style.CX7
        MesaValveLLA.Style_CX7 = RoundRectangleStatusControl.DisplayStyle_CX7.LLA
        MesaValveLLA.Location = New Point(405, 352)
        MesaValveLLA.Size = New Size(67, 41)

        MesaValveLLB.CXStyle = RoundRectangleStatusControl.CX_Style.CX7
        MesaValveLLB.Style_CX7 = RoundRectangleStatusControl.DisplayStyle_CX7.LLB
        MesaValveLLB.Location = New Point(528, 355)
        MesaValveLLB.Size = New Size(70, 38)

        MesaValvePM1.CXStyle = RoundRectangleStatusControl.CX_Style.CX7
        MesaValvePM1.Style_CX7 = RoundRectangleStatusControl.DisplayStyle_CX7.PM1
        MesaValvePM1.Location = New Point(396, 232)
        MesaValvePM1.Size = New Size(17, 70)

        MesaValvePM2.CXStyle = RoundRectangleStatusControl.CX_Style.CX7
        MesaValvePM2.Style_CX7 = RoundRectangleStatusControl.DisplayStyle_CX7.PM2
        MesaValvePM2.Location = New Point(404, 171)
        MesaValvePM2.Size = New Size(61, 53)

        MesaValvePM3.CXStyle = RoundRectangleStatusControl.CX_Style.CX7
        MesaValvePM3.Style_CX7 = RoundRectangleStatusControl.DisplayStyle_CX7.PM3
        MesaValvePM3.Location = New Point(468, 163)
        MesaValvePM3.Size = New Size(80, 17)

        MesaValvePM4.CXStyle = RoundRectangleStatusControl.CX_Style.CX7
        MesaValvePM4.Style_CX7 = RoundRectangleStatusControl.DisplayStyle_CX7.PM4
        MesaValvePM4.Location = New Point(546, 172)
        MesaValvePM4.Size = New Size(59, 58)

        MesaValvePM5.CXStyle = RoundRectangleStatusControl.CX_Style.CX7
        MesaValvePM5.Style_CX7 = RoundRectangleStatusControl.DisplayStyle_CX7.PM1
        MesaValvePM5.Location = New Point(598, 234)
        MesaValvePM5.Size = New Size(17, 70)

        HivacValveLLA.CXStyle = RoundRectangleStatusControl.CX_Style.CX7
        HivacValveLLA.Style_CX7 = RoundRectangleStatusControl.DisplayStyle_CX7.HIVAC_LLA
        HivacValveLLA.Location = New Point(338, 373)
        HivacValveLLA.Size = New Size(53, 60)

        HivacValveLLB.CXStyle = RoundRectangleStatusControl.CX_Style.CX7
        HivacValveLLB.Style_CX7 = RoundRectangleStatusControl.DisplayStyle_CX7.HIVAC_LLB
        HivacValveLLB.Location = New Point(610, 371)
        HivacValveLLB.Size = New Size(53, 60)

        '===========
        'load lock A config
        If RobotConfigurationValues.LOADLOCKA_VISIBLE Then
            LLALeg.Location = New Point(346, 352)
            LLALeg.QuestionMark_Visible = False
            LLALeg.Leg_In_Screen = PMControl.Support_Screen.TM
            LLALeg.LegStatus = BinaryStatusControl.DisplayStatus.Off
            LLALeg.EQ_LoadLock = Equipments.LoadLockA
            LLALeg.QuestionMark_Location = New Point(88, 27)
            LLALeg.Cassette_Location = New Point(23, 33)
        End If

        ''Load lock B config
        If RobotConfigurationValues.LOADLOCKB_VISIBLE Then
            LLBLeg.Location = New Point(529, 351)
            LLBLeg.Size = New Size(166, 115)
            LLBLeg.QuestionMark_Visible = False
            LLBLeg.Leg_In_Screen = PMControl.Support_Screen.TM
            LLBLeg.LegStatus = BinaryStatusControl.DisplayStatus.Off
            LLBLeg.EQ_LoadLock = Equipments.LoadLockB
            LLBLeg.QuestionMark_Location = New Point(88, 27)
            LLBLeg.Cassette_Location = New Point(21, 33)
        End If

        ''Chamber config
        If AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
            CX_PM1.CX_Supported = PMControl.Support_CX.Support_CX7
            CX_PM1.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM1.ShowWafer_Border_ToEdit = False
            CX_PM1.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM1.PM_Type = PMControl.PMPosition.IBE_PM1
                CX_PM1.Location = New Point(268, 217)
                CX_PM1.WaferLocation = New Point(27, 16)
                CX_PM1.LabelDisconnect_Location = New Point(0, 40)
            ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM1.PM_Type = PMControl.PMPosition.PVD_PM1
                CX_PM1.Location = New Point(223, 218)
                CX_PM1.WaferLocation = New Point(72, 24)
                CX_PM1.LabelDisconnect_Location = New Point(40, 40)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
            CX_PM2.CX_Supported = PMControl.Support_CX.Support_CX7
            CX_PM2.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM2.ShowWafer_Border_ToEdit = False
            CX_PM2.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM2.PM_Type = PMControl.PMPosition.IBE_PM2
                CX_PM2.Location = New Point(312, 62)
                CX_PM2.WaferLocation = New Point(40, 42)
                CX_PM2.LabelDisconnect_Location = New Point(20, 63)
            ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM2.PM_Type = PMControl.PMPosition.PVD_PM2
                CX_PM2.Location = New Point(305, 55)
                CX_PM2.WaferLocation = New Point(45, 58)
                CX_PM2.LabelDisconnect_Location = New Point(50, 100)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
            CX_PM3.CX_Supported = PMControl.Support_CX.Support_CX7
            CX_PM3.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM3.ShowWafer_Border_ToEdit = False
            CX_PM3.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM3.PM_Type = PMControl.PMPosition.IBE_PM3
                CX_PM3.Location = New Point(461, 32)
                CX_PM3.WaferLocation = New Point(14, 28)
                CX_PM3.LabelDisconnect_Location = New Point(0, 40)
            ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM3.PM_Type = PMControl.PMPosition.PVD_PM3
                CX_PM3.Location = New Point(460, 0)
                CX_PM3.WaferLocation = New Point(11, 72)
                CX_PM3.LabelDisconnect_Location = New Point(0, 100)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER4_VISIBLE Then
            CX_PM4.CX_Supported = PMControl.Support_CX.Support_CX7
            CX_PM4.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM4.ShowWafer_Border_ToEdit = False
            CX_PM4.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER4_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM4.PM_Type = PMControl.PMPosition.IBE_PM4
                CX_PM4.Location = New Point(543, 68)
                CX_PM4.WaferLocation = New Point(55, 45)
                CX_PM4.LabelDisconnect_Location = New Point(39, 63)
            ElseIf RobotConfigurationValues.CHAMBER4_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM4.PM_Type = PMControl.PMPosition.PVD_PM4
                CX_PM4.Location = New Point(548, 44)
                CX_PM4.WaferLocation = New Point(48, 65)
                CX_PM4.LabelDisconnect_Location = New Point(39, 90)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER5_VISIBLE Then
            CX_PM5.CX_Supported = PMControl.Support_CX.Support_CX7
            CX_PM5.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM5.ShowWafer_Border_ToEdit = False
            CX_PM5.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER5_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM5.PM_Type = PMControl.PMPosition.IBE_PM5
                CX_PM5.Location = New Point(597, 223)
                CX_PM5.WaferLocation = New Point(54, 15)
                CX_PM5.LabelDisconnect_Location = New Point(30, 40)
            ElseIf RobotConfigurationValues.CHAMBER5_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM5.PM_Type = PMControl.PMPosition.PVD_PM5
                CX_PM5.Location = New Point(597, 221)
                CX_PM5.WaferLocation = New Point(48, 12)
                CX_PM5.LabelDisconnect_Location = New Point(30, 40)
            End If
        End If
        InitializeShutterForPM_CX7()
#End If
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Initalize cassettes panel for CX8
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initialize_CX8()
#If AVP_CX_STYLE = "CX8" Then
        ''robot body config
        ticHandOriginal.CXStyle = RobotHand.CX_Style.CX8
        Robot_Body.CX_Supported = PMControl.Support_CX.Support_CX8
        Robot_Body.PM_IN_SCREEN = PMControl.Support_Screen.TM
        Robot_Body.Location = New Point(405, 177)
        'ticHandOriginal.PositionRobot = Positions.Arm_At_LLA_Wafer
        Robot_Body.SensorLLA_Position = New Point(66, 161)
        Robot_Body.SensorLLB_Position = New Point(132, 161)
        Robot_Body.SensorPM1_Position = New Point(20, 118)
        Robot_Body.SensorPM2_Position = New Point(25, 55)
        Robot_Body.SensorPM3_Position = New Point(68, 18)
        Robot_Body.SensorPM4_Position = New Point(131, 17)
        Robot_Body.SensorPM5_Position = New Point(178, 55)
        Robot_Body.SensorPM6_Position = New Point(183, 118)
        If RobotConfigurationValues.ALIGNER_AT_STATION = 1 Then
            awcAligner.Location = New Point(450, 352)
        Else
            awcAligner.Location = New Point(536, 352)
        End If
        IgcgChamber1.Location = New Point(149, 288)
        IgcgChamber2.Location = New Point(223, 120)
        IgcgChamber3.Location = New Point(350, 20)
        IgcgChamber4.Location = New Point(550, 20)
        IgcgChamber5.Location = New Point(651, 120)
        IgcgChamber6.Location = New Point(756, 288)
        'push station id to control
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM1_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM2_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM3_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM4_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM5_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM6_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.ALIGNER_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO.ToString()) '9
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.LLA_STATION_NO.ToString())
        atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.LLB_STATION_NO.ToString())

        ''MesaValves config
        MesaValveLLA.CXStyle = RoundRectangleStatusControl.CX_Style.CX8
        MesaValveLLA.Style_CX8 = RoundRectangleStatusControl.DisplayStyle_CX8.LLA
        MesaValveLLA.Location = New Point(422, 370)
        MesaValveLLA.Size = New Size(73, 40) '(59, 32)

        MesaValveLLB.CXStyle = RoundRectangleStatusControl.CX_Style.CX8
        MesaValveLLB.Style_CX8 = RoundRectangleStatusControl.DisplayStyle_CX8.LLB
        MesaValveLLB.Location = New Point(530, 370)
        MesaValveLLB.Size = New Size(73, 40) '(60, 32)

        MesaValvePM1.CXStyle = RoundRectangleStatusControl.CX_Style.CX8
        MesaValvePM1.Style_CX8 = RoundRectangleStatusControl.DisplayStyle_CX8.PM1
        MesaValvePM1.Location = New Point(395, 270)
        MesaValvePM1.Size = New Size(37, 75) '(34, 71)

        MesaValvePM2.CXStyle = RoundRectangleStatusControl.CX_Style.CX8
        MesaValvePM2.Style_CX8 = RoundRectangleStatusControl.DisplayStyle_CX8.PM2
        MesaValvePM2.Location = New Point(399, 198)
        MesaValvePM2.Size = New Size(45, 71) '(32, 70)


        MesaValvePM3.CXStyle = RoundRectangleStatusControl.CX_Style.CX8
        MesaValvePM3.Style_CX8 = RoundRectangleStatusControl.DisplayStyle_CX8.PM3
        MesaValvePM3.Location = New Point(438, 166)
        MesaValvePM3.Size = New Size(75, 40) '(75, 32)

        MesaValvePM4.CXStyle = RoundRectangleStatusControl.CX_Style.CX8
        MesaValvePM4.Style_CX8 = RoundRectangleStatusControl.DisplayStyle_CX8.PM4
        MesaValvePM4.Location = New Point(513, 167)
        MesaValvePM4.Size = New Size(75, 40) '(74, 33)

        MesaValvePM5.CXStyle = RoundRectangleStatusControl.CX_Style.CX8
        MesaValvePM5.Style_CX8 = RoundRectangleStatusControl.DisplayStyle_CX8.PM5
        MesaValvePM5.Location = New Point(583, 201)
        MesaValvePM5.Size = New Size(47, 69) '(33, 68)

        MesaValvePM6.CXStyle = RoundRectangleStatusControl.CX_Style.CX8
        MesaValvePM6.Style_CX8 = RoundRectangleStatusControl.DisplayStyle_CX8.PM6
        MesaValvePM6.Location = New Point(593, 272)
        MesaValvePM6.Size = New Size(36, 76) '(32, 74)

        HivacValveLLA.CXStyle = RoundRectangleStatusControl.CX_Style.CX8
        HivacValveLLA.Style_CX8 = RoundRectangleStatusControl.DisplayStyle_CX8.HIVAC_LLA
        HivacValveLLA.Location = New Point(352, 387)
        HivacValveLLA.Size = New Size(56, 73)

        HivacValveLLB.CXStyle = RoundRectangleStatusControl.CX_Style.CX8
        HivacValveLLB.Style_CX8 = RoundRectangleStatusControl.DisplayStyle_CX8.HIVAC_LLB
        HivacValveLLB.Location = New Point(618, 386)
        HivacValveLLB.Size = New Size(55, 74)

        btnLeftTool.Location = New Point(372, 445)
        btnRightTool.Location = New Point(625, 445)
        btnMechineTool.Location = New Point(498, 368)

        ''Change gas line
        GasLineNitrogen.Image = AVP_Robot_Project.My.Resources.CX8_Resources.CX8_MainModule
        GasLineNitrogen.ImageSize = New Size(1200, 760)
        GasLineNitrogen.IsChamberPic = False
        GasLineNitrogen.IsStretch = False
        GasLineNitrogen.Location = New Point(0, 267)
        GasLineNitrogen.Size = New Size(1000, 450)
        ''gas line in the left
        GasLineVentValveLLA.Image = AVP_Robot_Project.My.Resources.CX8_Resources.CX8_GasLine_VentValveLLA
        GasLineVentValveLLA.ImageSize = New Size(140, 140)
        GasLineVentValveLLA.IsChamberPic = False
        GasLineVentValveLLA.IsStretch = False
        GasLineVentValveLLA.Location = New Point(23, 409)

        GasLineRoughValveLLB.Image = AVP_Robot_Project.My.Resources.CX8_Resources.CX8_GasLine_RoughValveLLA
        GasLineRoughValveLLB.ImageSize = New Size(140, 120)
        GasLineRoughValveLLB.IsChamberPic = False
        GasLineRoughValveLLB.IsStretch = False
        GasLineRoughValveLLB.Location = New Point(16, 481)
        GasLineRoughValveLLB.Size = New Size(552, 159)
        'gas line in the right
        GasLineVentValveLLB.Image = AVP_Robot_Project.My.Resources.CX8_Resources.CX8_GasLine_VentValveLLB
        GasLineVentValveLLB.ImageSize = New Size(200, 140)
        GasLineVentValveLLB.IsChamberPic = False
        GasLineVentValveLLB.IsStretch = False
        GasLineVentValveLLB.Location = New Point(628, 409)

        GasLineRoughValveLLA.Image = AVP_Robot_Project.My.Resources.CX8_Resources.CX8_GasLine_RoughValveLLB
        GasLineRoughValveLLA.ImageSize = New Size(320, 120)
        GasLineRoughValveLLA.IsChamberPic = False
        GasLineRoughValveLLA.IsStretch = False
        GasLineRoughValveLLA.Location = New Point(458, 470)
        GasLineRoughValveLLA.Size = New Size(538, 124)
        ''Valves
        ValveVent.Location = New Point(79, 255)
        lblFastVentValve.Location = New Point(ValveVent.Left + 7, ValveVent.Top + ValveVent.Height + 2)
        ValveLLASlowVent.Location = New Point(98, 397)
        lblLLASlowVent.Location = New Point(ValveLLASlowVent.Left - 5, ValveLLASlowVent.Top + ValveLLASlowVent.Height + 2)
        ValveLLAFastVent.Location = New Point(98, 452)
        lblLLAFastVent.Location = New Point(ValveLLAFastVent.Left - 5, ValveLLAFastVent.Top + ValveLLAFastVent.Height + 2)
        ValveLLBSlowVent.Location = New Point(101, 526)
        lblLLBSlowVent.Location = New Point(ValveLLBSlowVent.Left - 5, ValveLLBSlowVent.Top + ValveLLBSlowVent.Height + 2)
        ValveLLBFastVent.Location = New Point(101, 580)
        lblLLBFastVent.Location = New Point(ValveLLBFastVent.Left - 5, ValveLLBFastVent.Top + ValveLLBFastVent.Height + 2)

        ValveRough.Location = New Point(898, 256)
        lblFastRoughtValve.Location = New Point(ValveRough.Left + 7, ValveRough.Top + ValveRough.Height + 2)
        ValveLLBSlowRough.Location = New Point(875, 398)
        lblLLBSlowRough.Location = New Point(ValveLLBSlowRough.Left - 5, ValveLLBSlowRough.Top + ValveLLBSlowRough.Height + 2)
        ValveLLBFastRough.Location = New Point(875, 452)
        lblLLBFastRough.Location = New Point(ValveLLBFastRough.Left - 5, ValveLLBFastRough.Top + ValveLLBFastRough.Height + 2)
        ValveLLASlowRough.Location = New Point(874, 515)
        lblLLASlowRough.Location = New Point(ValveLLASlowRough.Left - 5, ValveLLASlowRough.Top + ValveLLASlowRough.Height + 2)
        ValveLLAFastRough.Location = New Point(874, 570)
        lblLLAFastRough.Location = New Point(ValveLLAFastRough.Left - 5, ValveLLAFastRough.Top + ValveLLAFastRough.Height + 2)

        RoughPumpControl.Location = New Point(974, 552)

        '===========
        'load lock A config
        If RobotConfigurationValues.LOADLOCKA_VISIBLE Then
            LLALeg.Leg_In_Screen = PMControl.Support_Screen.TM
            LLALeg.LegStatus = BinaryStatusControl.DisplayStatus.Off
            LLALeg.EQ_LoadLock = Equipments.LoadLockA
            LLALeg.Location = New Point(365, 370)
            LLALeg.QuestionMark_Visible = False
            LLALeg.QuestionMark_Location = New Point(88, 27)
            LLALeg.Cassette_Location = New Point(23, 33)
            LLALeg.LegLocation = New Point(0, 103)
            crcLLACryo.Top = lblStatusText.Top - crcLLACryo.Height - 4
        End If

        ''Load lock B config
        If RobotConfigurationValues.LOADLOCKB_VISIBLE Then
            LLBLeg.Leg_In_Screen = PMControl.Support_Screen.TM
            LLBLeg.Location = New Point(536, 370)
            LLBLeg.QuestionMark_Visible = False
            LLBLeg.LegStatus = BinaryStatusControl.DisplayStatus.Off
            LLBLeg.EQ_LoadLock = Equipments.LoadLockB
            LLBLeg.QuestionMark_Location = New Point(88, 27)
            LLBLeg.Cassette_Location = New Point(21, 33)
            LLBLeg.LegLocation = New Point(0, 103)
            crcLLBCryo.Top = lblStatusText.Top - crcLLBCryo.Height - 4
        End If

        ''Chamber config
        If AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
            CX_PM1.CX_Supported = PMControl.Support_CX.Support_CX8
            CX_PM1.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM1.ShowWafer_Border_ToEdit = False
            CX_PM1.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM1.PM_Type = PMControl.PMPosition.IBE_PM1
                CX_PM1.Location = New Point(263, 274)
                CX_PM1.WaferLocation = New Point(37, 30)
            ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM1.PM_Type = PMControl.PMPosition.PVD_PM1
                CX_PM1.Location = New Point(255, 273)
                CX_PM1.WaferLocation = New Point(53, 31)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
            CX_PM2.CX_Supported = PMControl.Support_CX.Support_CX8
            CX_PM2.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM2.ShowWafer_Border_ToEdit = False
            CX_PM2.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM2.PM_Type = PMControl.PMPosition.IBE_PM2
                CX_PM2.Location = New Point(273, 129)
                CX_PM2.WaferLocation = New Point(40, 34)
            ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM2.PM_Type = PMControl.PMPosition.PVD_PM2
                CX_PM2.Location = New Point(268, 128)
                CX_PM2.WaferLocation = New Point(50, 40)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
            CX_PM3.CX_Supported = PMControl.Support_CX.Support_CX8
            CX_PM3.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM3.ShowWafer_Border_ToEdit = False
            CX_PM3.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM3.PM_Type = PMControl.PMPosition.IBE_PM3
                CX_PM3.Location = New Point(381, 38)
                CX_PM3.WaferLocation = New Point(30, 36)
            ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM3.PM_Type = PMControl.PMPosition.PVD_PM3
                CX_PM3.Location = New Point(391, 28)
                CX_PM3.WaferLocation = New Point(22, 55)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER4_VISIBLE Then
            CX_PM4.CX_Supported = PMControl.Support_CX.Support_CX8
            CX_PM4.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM4.ShowWafer_Border_ToEdit = False
            CX_PM4.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER4_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM4.PM_Type = PMControl.PMPosition.IBE_PM4
                CX_PM4.Location = New Point(512, 36)
                CX_PM4.WaferLocation = New Point(34, 40)
            ElseIf RobotConfigurationValues.CHAMBER4_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM4.PM_Type = PMControl.PMPosition.PVD_PM4
                CX_PM4.Location = New Point(517, 29)
                CX_PM4.WaferLocation = New Point(27, 50)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER5_VISIBLE Then
            CX_PM5.CX_Supported = PMControl.Support_CX.Support_CX8
            CX_PM5.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM5.ShowWafer_Border_ToEdit = False
            CX_PM5.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER5_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM5.PM_Type = PMControl.PMPosition.IBE_PM5
                CX_PM5.Location = New Point(585, 127)
                CX_PM5.WaferLocation = New Point(65, 34)
            ElseIf RobotConfigurationValues.CHAMBER5_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM5.PM_Type = PMControl.PMPosition.PVD_PM5
                CX_PM5.Location = New Point(591, 132)
                CX_PM5.WaferLocation = New Point(53, 32)
            End If
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER6_VISIBLE Then
            CX_PM6.CX_Supported = PMControl.Support_CX.Support_CX8
            CX_PM6.PM_IN_SCREEN = PMControl.Support_Screen.TM
            CX_PM6.ShowWafer_Border_ToEdit = False
            CX_PM6.Show_Disconnected = False

            If RobotConfigurationValues.CHAMBER6_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM6.PM_Type = PMControl.PMPosition.IBE_PM6
                CX_PM6.Location = New Point(598, 271)
                CX_PM6.WaferLocation = New Point(62, 32)
            ElseIf RobotConfigurationValues.CHAMBER6_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM6.PM_Type = PMControl.PMPosition.PVD_PM6
                CX_PM6.Location = New Point(601, 274) '598, 281
                CX_PM6.WaferLocation = New Point(54, 26)
            End If
        End If
        InitializeShutterForPM_CX8()
#End If
    End Sub


#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''    	<date> 20098-10-29</date>
    ''' </author>
    ''' <summary>
    ''' Get ClickedPosition
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Property ClickedInChamber() As Integer
        Get
            Return m_intClickedChamber
        End Get
        Set(ByVal value As Integer)
            m_intClickedChamber = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        If AVPLib.ContainerData.Permission(PERMISSION_001) Then
            ActiveForm()
        Else
            InactiveForm()
        End If
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Enable button when LL is in online mode
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetTMOnline(ByVal mTMOnline As Boolean)
        AVPLib.Log.guiLogger.Info("Enter SetTMOnline")
        Try

            Me.ISTM_ONLINE = mTMOnline
            If AVPLib.ContainerData.Permission(PERMISSION_001) = False Then
                If mTMOnline = False Then
                    Exit Sub
                End If
            End If
            Me.crcTMCryo.IsOnline = mTMOnline
            Me.crcTMWaterPump.IsOnline = mTMOnline
            Me.TMCtl.IsOnline = mTMOnline
            Me.stwSemiautoTransferWafer.btnStart.Enabled = Not (mTMOnline)
            Me.atwAutoTransferWafer.IsOnline = mTMOnline
            Me.ctwcCycleWafer.IsOnline = mTMOnline
            sccSerialCommand.IsOnline = mTMOnline
            cmsChamber.Enabled = Not (mTMOnline)
            ContainerForm.Aligner.IsOnline = mTMOnline
            MesaValveLLA.Enabled = Not (mTMOnline)
            MesaValvePM1.Enabled = Not (mTMOnline)
            MesaValvePM2.Enabled = Not (mTMOnline)
            MesaValvePM3.Enabled = Not (mTMOnline)
            MesaValvePM4.Enabled = Not (mTMOnline)
            MesaValvePM5.Enabled = Not (mTMOnline)
            MesaValvePM6.Enabled = Not (mTMOnline)
            MesaValveLLB.Enabled = Not (mTMOnline)
            Me.btnTMProtectedMode.Enabled = Not (mTMOnline)
            Me.btnCancelMove.Enabled = Not (mTMOnline)
            m_TMCryoPopUpPanel.DeviceOnline = mTMOnline
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SetTMOnline")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Enable button when TM IG degas complete.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Finish_TMIGDegas(ByVal bFinished As Boolean)
        AVPLib.Log.guiLogger.Info("Enter Finish_TMIGDegas")
        Try
            m_PopUpPanel.btnTMIGDegas.Enabled = bFinished And Utils.IsAllowEnable(ISTM_ONLINE)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Finish_TMIGDegas")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Enable button when LLA IG degas complete.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Finish_LLAIGDegas(ByVal bFinished As Boolean)
        AVPLib.Log.guiLogger.Info("Enter Finish_LLAIGDegas")
        Try
            m_PopUpPanel.btnLLAIGDegas.Enabled = bFinished And Utils.IsAllowEnable(ISLLA_ONLINE)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Finish_LLAIGDegas")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Enable button when LLA IG degas complete.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Finish_LLBIGDegas(ByVal bFinished As Boolean)
        AVPLib.Log.guiLogger.Info("Enter Finish_LLBIGDegas")
        Try
            m_PopUpPanel.btnLLBIGDegas.Enabled = bFinished And Utils.IsAllowEnable(ISLLB_ONLINE)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Finish_LLBIGDegas")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Enable button when LL is in online mode
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetLLAOnline(ByVal mLLAOnline As Boolean)
        AVPLib.Log.guiLogger.Info("Enter SetLLAOnline")
        Try
            ISLLA_ONLINE = (mLLAOnline)
            If AVPLib.ContainerData.Permission(PERMISSION_001) = False Then
                If mLLAOnline = False Then
                    Exit Sub
                End If
            End If
            If lccLoadLockA.Is_Connected = False Then
                Exit Try
            End If
            Me.lccLoadLockA.btnHome.Enabled = Not (mLLAOnline)
            Me.lccLoadLockA.btnGoToSlot.Enabled = Not (mLLAOnline)
            Me.lccLoadLockA.btnMap.Enabled = Not (mLLAOnline)
            Me.lccLoadLockA.IsLLOnline = mLLAOnline

            ' If it is manual door elevator, do not enable it
            'Me.lccLoadLockA.btnOpen.Enabled = Not (mLLAOnline)
            Me.lccLoadLockA.btnOpen.Enabled = Me.lccLoadLockA.EnableDisableOpenButton(Not (mLLAOnline))
            Me.lccLoadLockA.btnClose.Enabled = Me.lccLoadLockA.EnableDisableOpenButton(Not (mLLAOnline))

            'Me.lccLoadLockA.btnReset.Enabled = Not (mLLAOnline)
            Me.crcLLACryo.IsOnline = mLLAOnline

            m_LLACryoPopUpPanel.DeviceOnline = mLLAOnline
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SetLLAOnline")
    End Sub

    Public Sub SetLLBOnline(ByVal mLLBOnline As Boolean)
        AVPLib.Log.guiLogger.Info("Enter SetLLBOnline")
        Try
            ISLLB_ONLINE = (mLLBOnline)
            If AVPLib.ContainerData.Permission(PERMISSION_001) = False Then
                If mLLBOnline = False Then
                    Exit Sub
                End If
            End If

            If lccLoadLockA.Is_Connected = False Then
                Exit Try
            End If
            Me.lccLoadLockB.btnHome.Enabled = Not (mLLBOnline)
            Me.lccLoadLockB.btnGoToSlot.Enabled = Not (mLLBOnline)
            Me.lccLoadLockB.btnMap.Enabled = Not (mLLBOnline)
            Me.lccLoadLockB.IsLLOnline = mLLBOnline
            ' If it is manual door elevator, do not enable it
            'Me.lccLoadLockB.btnOpen.Enabled = Not (mLLBOnline)
            Me.lccLoadLockB.btnOpen.Enabled = Me.lccLoadLockB.EnableDisableOpenButton(Not (mLLBOnline))
            Me.lccLoadLockB.btnClose.Enabled = Me.lccLoadLockB.EnableDisableOpenButton(Not (mLLBOnline))

            'Me.lccLoadLockB.btnReset.Enabled = Not (mLLBOnline)
            Me.crcLLBCryo.IsOnline = mLLBOnline

            m_LLBCryoPopUpPanel.DeviceOnline = mLLBOnline
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SetLLBOnline")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Enable/Disable button when LL is working 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetLLIsWorking(ByVal lccLoadLock As AVP_Robot_Project.LockCassetteControl, ByVal mIsWorking As Boolean)
        AVPLib.Log.guiLogger.Info("Enter SetLLIsWorking")
        Try
            If (ISLLA_ONLINE = False And lccLoadLock.Name = LOCKCASSETTEA) OrElse _
                (ISLLB_ONLINE = False And lccLoadLock.Name = LOCKCASSETTEB) Then
                'if menu Online on LLA is Enable (not Online) and LoadLockA is clicked-> change it
                If lccLoadLock.btnHome.Enabled = (mIsWorking) Then
                    lccLoadLock.btnHome.Enabled = Not (mIsWorking)
                    lccLoadLock.btnGoToSlot.Enabled = Not (mIsWorking)
                    lccLoadLock.btnMap.Enabled = Not (mIsWorking)

                    ' If it is manual door elevator, do not enable it
                    'lccLoadLock.btnOpen.Enabled = Not (mIsWorking)
                    lccLoadLock.btnOpen.Enabled = lccLoadLock.EnableDisableOpenButton(Not (mIsWorking))
                    lccLoadLock.btnClose.Enabled = lccLoadLock.EnableDisableOpenButton(Not (mIsWorking))

                    'lccLoadLock.btnReset.Enabled = Not (mIsWorking)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SetLLIsWorking")
    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbcAlignerWafer As New StatusBinaryStatusControl(awcAligner)
            Dim srrRoundRectangleStatus1 As New StatusRoundRectangleControl(MesaValveLLA)
            Dim srrRoundRectangleStatus2 As New StatusRoundRectangleControl(MesaValvePM1)
            Dim srrRoundRectangleStatus3 As New StatusRoundRectangleControl(MesaValvePM2)
            Dim srrRoundRectangleStatus4 As New StatusRoundRectangleControl(MesaValvePM3)
            Dim srrRoundRectangleStatus5 As New StatusRoundRectangleControl(MesaValvePM4)
            Dim srrRoundRectangleStatus6 As New StatusRoundRectangleControl(MesaValvePM5)
            Dim srrRoundRectangleStatus7 As New StatusRoundRectangleControl(MesaValvePM6)
            Dim srrRoundRectangleStatus10 As New StatusRoundRectangleControl(MesaValveLLB)
            Dim srrRoundRectangleStatus8 As New StatusRoundRectangleControl(HivacValveLLA)
            Dim srrRoundRectangleStatus9 As New StatusRoundRectangleControl(HivacValveLLB)
            Dim srbRobot As New StatusRobot(m_Robot)
            Dim sbtLLAIgStatus As New StatusIGCGButton(LLAIgStatus)
            Dim sbtLLbIgStatus As New StatusIGCGButton(LLBIgStatus)
            ''control from Transparent
            Dim sbcValveControl1 As New StatusBinaryStatusControl(ValveVent)
            Dim sbcValveControl2 As New StatusBinaryStatusControl(ValveLLASlowVent)
            Dim sbcValveControl3 As New StatusBinaryStatusControl(ValveLLAFastVent)
            Dim sbcValveControl4 As New StatusBinaryStatusControl(ValveLLBSlowVent)
            Dim sbcValveControl5 As New StatusBinaryStatusControl(ValveLLBFastVent)
            Dim sbcValveControl6 As New StatusBinaryStatusControl(ValveRough)
            Dim sbcValveControl7 As New StatusBinaryStatusControl(ValveLLBSlowRough)
            Dim sbcValveControl8 As New StatusBinaryStatusControl(ValveLLBFastRough)
            Dim sbcValveControl9 As New StatusBinaryStatusControl(ValveLLASlowRough)
            Dim sbcValveControl10 As New StatusBinaryStatusControl(ValveLLAFastRough)
            Dim sbcRoughPumpControl As New StatusBinaryStatusControl(RoughPumpControl)
            Dim stmMechineOnline As New StatusToolStripMenuItem(mnuMechineOnline, cmsMechineTool)
            Dim stmMechineStopPumpDown As New StatusToolStripMenuItem(mnuMechineStopPumpDown, cmsMechineTool)
            Dim stmMechineStopVent As New StatusToolStripMenuItem(mnuMechineStopVent, cmsMechineTool)

            Dim stmLeftOnline As New StatusToolStripMenuItem(mnuLeftOnline, cmsLeftTool)
            Dim stmLeftStopPumpDown As New StatusToolStripMenuItem(mnuLeftStopPumpDown, cmsLeftTool)
            Dim stmLeftStopVent As New StatusToolStripMenuItem(mnuLeftStopVent, cmsLeftTool)

            Dim stmRightOnline As New StatusToolStripMenuItem(mnuRightOnline, cmsRightTool)
            Dim stmRightStopPumpDown As New StatusToolStripMenuItem(mnuRightStopPumpDown, cmsRightTool)
            Dim stmRightStopVent As New StatusToolStripMenuItem(mnuRightStopVent, cmsRightTool)

            Dim ctxMenuStripLLA As New StatusContextMenuStrip(cmsLeftTool)
            Dim ctxMenuStripLLB As New StatusContextMenuStrip(cmsRightTool)
            Dim ctxMenuStripTM As New StatusContextMenuStrip(cmsMechineTool)
            ' Status object for the Button Machine Tool.
            Dim stImgBtnMachineOnline As New StatusImageButton(btnMechineTool)

            stImgBtnMachineOnline.ImageToolOnline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(1)
            stImgBtnMachineOnline.ImageToolOffline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(0)

            Dim stImgBtnLeftTool As New StatusImageButton(btnLeftTool)
            stImgBtnLeftTool.ImageToolOnline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(1)
            stImgBtnLeftTool.ImageToolOffline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(0)

            Dim stImgBtnRightTool As New StatusImageButton(btnRightTool)
            stImgBtnRightTool.ImageToolOnline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(1)
            stImgBtnRightTool.ImageToolOffline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(0)

            Dim stErrorMessageBox As New ErrorMessageBox("MessageBox")
            Dim srbStatus As New StatusLabel(lblStatusText)
            Dim srbCoreMessageBoxStatus As New StatusLabel(lblCoreMessageBoxText)

            Dim slbRoughPump As New StatusLabel(lblRoughPumpInUse)
            Dim sfbFlashingLabel As New StatusFlashingLabel(lblFlashing)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sfbFlashingLabel)
            m_stoStatusObject.AddChild(sbtLLAIgStatus)
            m_stoStatusObject.AddChild(sbtLLbIgStatus)
            m_stoStatusObject.AddChild(m_PopUpPanel.Status)
            m_stoStatusObject.AddChild(m_LLACryoPopUpPanel.Status)
            m_stoStatusObject.AddChild(m_LLBCryoPopUpPanel.Status)
            m_stoStatusObject.AddChild(m_TMCryoPopUpPanel.Status)

            ''import control from TransferPanel
            'm_stoStatusObject.AddChild(sbsHivacButton)
            m_stoStatusObject.AddChild(Robot_Body.Status)
            ' m_stoStatusObject.AddChild(pnlRobotArmStatus.Status)
            m_stoStatusObject.AddChild(ctwcCycleWafer.Status)
            m_stoStatusObject.AddChild(LLALeg.Status)
            m_stoStatusObject.AddChild(LLBLeg.Status)

            m_stoStatusObject.AddChild(sbcValveControl1)
            m_stoStatusObject.AddChild(sbcValveControl2)
            m_stoStatusObject.AddChild(sbcValveControl3)
            m_stoStatusObject.AddChild(sbcValveControl4)
            m_stoStatusObject.AddChild(sbcValveControl5)
            m_stoStatusObject.AddChild(sbcValveControl6)
            m_stoStatusObject.AddChild(sbcValveControl7)
            m_stoStatusObject.AddChild(sbcValveControl8)
            m_stoStatusObject.AddChild(sbcValveControl9)
            m_stoStatusObject.AddChild(sbcValveControl10)
            m_stoStatusObject.AddChild(sbcRoughPumpControl)
            m_stoStatusObject.AddChild(crcTMCryo.Status)
            m_stoStatusObject.AddChild(crcTMWaterPump.Status)
            m_stoStatusObject.AddChild(crcLLACryo.Status)
            m_stoStatusObject.AddChild(crcLLBCryo.Status)
            m_stoStatusObject.AddChild(TMCtl.Status)
            ''
            m_stoStatusObject.AddChild(ctxMenuStripLLA)
            m_stoStatusObject.AddChild(ctxMenuStripLLB)
            m_stoStatusObject.AddChild(ctxMenuStripTM)
            m_stoStatusObject.AddChild(stmMechineOnline)
            m_stoStatusObject.AddChild(stmMechineStopPumpDown)
            m_stoStatusObject.AddChild(stmMechineStopVent)
            m_stoStatusObject.AddChild(stmLeftOnline)
            m_stoStatusObject.AddChild(stmLeftStopPumpDown)
            m_stoStatusObject.AddChild(stmLeftStopVent)
            m_stoStatusObject.AddChild(stmRightOnline)
            m_stoStatusObject.AddChild(stmRightStopPumpDown)
            m_stoStatusObject.AddChild(stmRightStopVent)
            m_stoStatusObject.AddChild(stImgBtnMachineOnline)
            m_stoStatusObject.AddChild(stImgBtnRightTool)
            m_stoStatusObject.AddChild(stImgBtnLeftTool)

            m_stoStatusObject.AddChild(stErrorMessageBox)
            m_stoStatusObject.AddChild(srbStatus)
            m_stoStatusObject.AddChild(srbCoreMessageBoxStatus)

            ''end of import
            If AVPLib.RobotConfigurationValues.INSTALLED_CX7 Then
                m_stoStatusObject.AddChild(srrRoundRectangleStatus6)
                m_stoStatusObject.AddChild(CX_PM5.Status)
            ElseIf AVPLib.RobotConfigurationValues.INSTALLED_CX8 Then
                m_stoStatusObject.AddChild(srrRoundRectangleStatus6)
                m_stoStatusObject.AddChild(srrRoundRectangleStatus7)
                m_stoStatusObject.AddChild(CX_PM5.Status)
                m_stoStatusObject.AddChild(CX_PM6.Status)
            End If

            m_stoStatusObject.AddChild(CX_PM1.Status)
            m_stoStatusObject.AddChild(CX_PM2.Status)
            m_stoStatusObject.AddChild(CX_PM3.Status)
            m_stoStatusObject.AddChild(CX_PM4.Status)

            m_stoStatusObject.AddChild(sbcAlignerWafer)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus1)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus2)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus3)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus4)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus5)

            m_stoStatusObject.AddChild(srrRoundRectangleStatus8)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus9)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus10)

            m_stoStatusObject.AddChild(IgcgChamber1.Status)
            m_stoStatusObject.AddChild(IgcgChamber2.Status)
            m_stoStatusObject.AddChild(IgcgChamber3.Status)
            m_stoStatusObject.AddChild(IgcgChamber4.Status)
            m_stoStatusObject.AddChild(IgcgChamber5.Status)
            m_stoStatusObject.AddChild(lccLoadLockA.Status)
            m_stoStatusObject.AddChild(lccLoadLockB.Status)
            m_stoStatusObject.AddChild(stwSemiautoTransferWafer.Status)
            m_stoStatusObject.AddChild(sccSerialCommand.Status)
            m_stoStatusObject.AddChild(srbRobot)

            m_stoStatusObject.AddChild(slbRoughPump)
            m_stoStatusObject.AddChild(Me.atwAutoTransferWafer.Status)


        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.ticHandOriginal.Enabled = True
            Me.GasLineNitrogen.Enabled = True
            Me.awcAligner.Enabled = True
            Me.CX_PM1.Enabled = True
            Me.CX_PM2.Enabled = True
            Me.CX_PM3.Enabled = True
            Me.CX_PM4.Enabled = True
            Me.CX_PM5.Enabled = True
            Me.CX_PM6.Enabled = True
            Me.btnTool.Enabled = True
            Me.IgcgChamber1.Enabled = True
            Me.IgcgChamber2.Enabled = True
            Me.IgcgChamber3.Enabled = True
            Me.IgcgChamber4.Enabled = True
            Me.IgcgChamber5.Enabled = True
            Me.IgcgChamber6.Enabled = True
            Me.lccLoadLockA.Enabled = True
            Me.lccLoadLockB.Enabled = True
            Me.stwSemiautoTransferWafer.Enabled = True

            Me.atwAutoTransferWafer.Enabled = True
            Me.ctwcCycleWafer.Enabled = True
            Me.sccSerialCommand.Enabled = True

            Me.TMCtl.Enabled = True
            Me.MesaValvePM1.Enabled = True
            Me.MesaValvePM2.Enabled = True
            Me.MesaValvePM3.Enabled = True
            Me.MesaValvePM4.Enabled = True
            Me.MesaValvePM5.Enabled = True
            Me.MesaValvePM6.Enabled = True
            Me.MesaValveLLB.Enabled = True
            Me.MesaValveLLA.Enabled = True
            Me.HivacValveLLA.Enabled = True
            Me.HivacValveLLB.Enabled = True
            Me.ibsHivacButton.Enabled = True
            Me.ValveVent.Enabled = True
            Me.ValveLLASlowVent.Enabled = True
            Me.ValveLLAFastVent.Enabled = True
            Me.ValveLLBSlowVent.Enabled = True
            Me.ValveLLBFastVent.Enabled = True
            Me.ValveRough.Enabled = True
            Me.ValveLLBSlowRough.Enabled = True
            Me.ValveLLBFastRough.Enabled = True
            Me.ValveLLASlowRough.Enabled = True
            Me.ValveLLAFastRough.Enabled = True
            Me.btnMechineTool.Enabled = True
            Me.btnLeftTool.Enabled = True
            Me.btnRightTool.Enabled = True
            Me.crcTMCryo.Enabled = True
            Me.crcTMWaterPump.Enabled = True
            Me.crcLLACryo.Enabled = True
            Me.crcLLBCryo.Enabled = True
            Me.btnTMProtectedMode.Enabled = True
            Me.btnCancelMove.Enabled = True
            'Me.btnCancelMove.Status = SL_CustomButton.DisplayStatus.Off
            '#05/07/2011 
            '#TM.LLx valve buttons are affected of TM or LLx which online /offline 
            '#Begin fix
            MechineValveStatus(Not ISTM_ONLINE)
            LeftValveStatus(Not ISLLA_ONLINE)
            RightValveStatus(Not ISLLB_ONLINE)

            SetTMOnline(ISTM_ONLINE)
            SetLLAOnline(ISLLA_ONLINE)
            SetLLBOnline(ISLLB_ONLINE)

            '#End fix.

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            Me.GasLineNitrogen.Enabled = False
            Me.ticHandOriginal.Enabled = False
            Me.awcAligner.Enabled = False
            Me.CX_PM1.Enabled = False
            Me.CX_PM2.Enabled = False
            Me.CX_PM3.Enabled = False
            Me.CX_PM4.Enabled = False
            Me.CX_PM5.Enabled = False
            Me.CX_PM6.Enabled = False
            Me.btnTool.Enabled = False
            Me.IgcgChamber1.Enabled = False
            Me.IgcgChamber2.Enabled = False
            Me.IgcgChamber3.Enabled = False
            Me.IgcgChamber4.Enabled = False
            Me.IgcgChamber5.Enabled = False
            Me.IgcgChamber6.Enabled = False
            Me.lccLoadLockA.Enabled = False
            Me.lccLoadLockB.Enabled = False
            Me.stwSemiautoTransferWafer.Enabled = False
            Me.atwAutoTransferWafer.Enabled = False
            Me.ctwcCycleWafer.Enabled = False
            Me.sccSerialCommand.Enabled = False
            ticHandOriginal.Enabled = False

            Me.TMCtl.Enabled = False
            Me.MesaValvePM1.Enabled = False
            Me.MesaValvePM2.Enabled = False
            Me.MesaValvePM3.Enabled = False
            Me.MesaValvePM4.Enabled = False
            Me.MesaValvePM5.Enabled = False
            Me.MesaValvePM6.Enabled = False
            Me.MesaValveLLB.Enabled = False
            Me.MesaValveLLA.Enabled = False
            Me.HivacValveLLA.Enabled = False
            Me.HivacValveLLB.Enabled = False
            Me.ibsHivacButton.Enabled = False
            Me.ValveVent.Enabled = False
            Me.ValveLLASlowVent.Enabled = False
            Me.ValveLLAFastVent.Enabled = False
            Me.ValveLLBSlowVent.Enabled = False
            Me.ValveLLBFastVent.Enabled = False
            Me.ValveRough.Enabled = False
            Me.ValveLLBSlowRough.Enabled = False
            Me.ValveLLBFastRough.Enabled = False
            Me.ValveLLASlowRough.Enabled = False
            Me.ValveLLAFastRough.Enabled = False
            Me.btnMechineTool.Enabled = False
            Me.btnLeftTool.Enabled = False
            Me.btnRightTool.Enabled = False
            Me.crcTMCryo.Enabled = False
            Me.crcTMWaterPump.Enabled = False
            Me.crcLLACryo.Enabled = False
            Me.crcLLBCryo.Enabled = False
            Me.btnTMProtectedMode.Enabled = False
            Me.btnCancelMove.Enabled = False
            'Me.btnCancelMove.Status = SL_CustomButton.DisplayStatus.Off

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Display context menu when user click on circle plasma of Chamber
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowContextMenuClickOnChamber(ByVal sender As Object)
        Try
            'Dim cpcTemp As CirclePlasmaControl
            'cpcTemp = CType(sender, CirclePlasmaControl)
            'Dim pos As New System.Drawing.Point(cpcTemp.Location)
            'pos.Y += cpcTemp.Height
            'pos = Me.PointToScreen(pos)
            'cmsChamber.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-24</date>
    ''' </author>
    ''' <summary>
    ''' Display context menu when user click on aligner
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowContextMenuClickOnAligner()
        Try
            Dim pos As New System.Drawing.Point(awcAligner.Location)
            pos.Y += awcAligner.Height
            pos = Me.PointToScreen(pos)
            cmsChamber.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-24</date>
    ''' </author>
    ''' <summary>
    ''' Display context menu when user click on Robot
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowContextMenuClickOnRobot()
        Try
            Dim pos As New System.Drawing.Point(ticHandOriginal.Location)
            pos.Y = ticHandOriginal.Location.Y + 50
            pos = Me.PointToScreen(pos)
            cmsChamber.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Enable menu context item 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetChamberMenuContextEnable(ByVal blnCreateWafer As Boolean, _
                                            ByVal blnDeleteWafer As Boolean, _
                                            ByVal blnSrcForMove As Boolean, _
                                            ByVal blnDstForMove As Boolean, _
                                            ByVal blnUpdateWaferInfo As Boolean)
        Try
            mnuCreateWafer.Enabled = IIf(ContainerForm.CassettesPanel.ISTM_ONLINE, False, blnCreateWafer)
            mnuDeleteWafer.Enabled = blnDeleteWafer
            mnuSrcForMove.Enabled = blnSrcForMove
            mnuDstForMove.Enabled = blnDstForMove
            mnuUpdateWaferInfoToolStripMenuItem.Enabled = blnUpdateWaferInfo
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Prepare context menu before showing
    ''' </summary>
    ''' <param name="ticWaferInside"></param>
    ''' <remarks></remarks>
    Private Sub PrepareChamberMenu(ByVal ticWaferInside As CirclePlasmaControl)
        Try
            If Not (ticWaferInside.WaferID = "") Then
                SetChamberMenuContextEnable(False, True, True, False, True)
            Else
                SetChamberMenuContextEnable(True, False, False, True, False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Prepare context menu before showing
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrepareAlignerMenu()
        Try
            If (awcAligner.Status = BinaryStatusControl.DisplayStatus.On) Then
                SetChamberMenuContextEnable(False, True, True, False, True)
            Else
                SetChamberMenuContextEnable(True, False, False, True, False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Private Sub PrepareRobotMenu()
        Try
            ' Have to get the wafer status from equipment status
            ' Not only on GUI
            Dim Robot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())

            'If (awcRobot.Status = BinaryStatusControl.DisplayStatus.On) Then
            If (Robot.WaferInside = AVPLib.DataManagerment.Equipment.WorkingStatuses.On) Then
                ' if not in home position, disable create and delte menu item
                ' if user wants to create/delete wafer --> must be home position
                'If (Robot.CurrentPosition <> AVPLib.ConstEnum.Positions.Original) Then
                '    SetChamberMenuContextEnable(False, True, True, False)
                'Else
                SetChamberMenuContextEnable(False, True, True, False, True)
                'End If
            Else
                SetChamberMenuContextEnable(True, False, False, True, False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Create string for source or destination text box of semi auto transfer
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GenerateSrcOrDst(Optional ByVal ClickedChamber As Integer = 0) As String
        Dim strResult As String = ""
        Try
            If Not ClickedChamber = 0 Then
                m_intClickedChamber = ClickedChamber
            End If
            If (m_intClickedChamber = CLICKEDALIGNER) Then
                strResult = "Aligner"
            ElseIf (m_intClickedChamber = CLICKEDROBOT) Then
                strResult = "Robot Arm"
            Else
                strResult = "Chamber " + m_intClickedChamber.ToString()
                strResult = AVPLib.Utils.chamberID2ChamberName(strResult)
            End If
            'btnCancleMove_OnChange()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return strResult
    End Function

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-24</date>
    ''' </author>
    ''' <summary>
    ''' Set wafer inside
    ''' </summary>
    ''' <param name="blnWaferVisible"></param>
    ''' <param name="enmPlasmaStatus"></param>
    ''' <remarks></remarks>
    Public Sub SetWaferInside(ByVal blnWaferVisible As Boolean, _
                               ByVal enmPlasmaStatus As BinaryStatusControl.DisplayStatus, _
                               ByVal waferInfo As AVPWaferInfo, Optional ByVal Click_On_Chamber As Integer = 0)
        Try
            Dim chamberObj As DataManagerment.Chamber = Nothing
            If Not (Click_On_Chamber = 0) Then
                m_intClickedChamber = Click_On_Chamber
            End If
            Select Case m_intClickedChamber
                Case CLICKEDCHAMBER1
                    chamberObj = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf(CHAMBER1) > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf(CHAMBER1) > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If
                    If enmPlasmaStatus = BinaryStatusControl.DisplayStatus.On Then
                        chamberObj.WaferInfo = waferInfo
                    Else
                        chamberObj.WaferInfo = Nothing
                        ' Update PM State to IDLE
                        AVPLib.Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), ConstEnum.Equipments.Chamber1.ToString())
                    End If
                    Me.m_stoStatusObject.RequestStatus(WAFER_INSIDE_CHAMBER1, enmPlasmaStatus.ToString())

                Case CLICKEDCHAMBER2
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf(CHAMBER2) > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf(CHAMBER2) > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If

                    chamberObj = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
                    If enmPlasmaStatus = BinaryStatusControl.DisplayStatus.On Then
                        chamberObj.WaferInfo = waferInfo
                    Else
                        chamberObj.WaferInfo = Nothing
                        ' Update PM State to IDLE
                        AVPLib.Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), ConstEnum.Equipments.Chamber2.ToString())
                    End If
                    Me.m_stoStatusObject.RequestStatus(WAFER_INSIDE_CHAMBER2, enmPlasmaStatus.ToString())

                Case CLICKEDCHAMBER3
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf(CHAMBER3) > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf(CHAMBER3) > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If

                    chamberObj = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
                    If enmPlasmaStatus = BinaryStatusControl.DisplayStatus.On Then
                        chamberObj.WaferInfo = waferInfo
                    Else
                        chamberObj.WaferInfo = Nothing
                        ' Update PM State to IDLE
                        AVPLib.Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), ConstEnum.Equipments.Chamber3.ToString())
                    End If
                    Me.m_stoStatusObject.RequestStatus(WAFER_INSIDE_CHAMBER3, enmPlasmaStatus.ToString())

                Case CLICKEDCHAMBER4
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf(CHAMBER4) > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf(CHAMBER4) > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If

                    chamberObj = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber4.ToString())
                    If enmPlasmaStatus = BinaryStatusControl.DisplayStatus.On Then
                        chamberObj.WaferInfo = waferInfo
                    Else
                        chamberObj.WaferInfo = Nothing
                        ' Update PM State to IDLE
                        AVPLib.Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), ConstEnum.Equipments.Chamber4.ToString())
                    End If
                    Me.m_stoStatusObject.RequestStatus(WAFER_INSIDE_CHAMBER4, enmPlasmaStatus.ToString())

                Case CLICKEDCHAMBER5
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf(CHAMBER5) > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf(CHAMBER5) > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If

                    chamberObj = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber5.ToString())
                    If enmPlasmaStatus = BinaryStatusControl.DisplayStatus.On Then
                        chamberObj.WaferInfo = waferInfo
                    Else
                        chamberObj.WaferInfo = Nothing
                        ' Update PM State to IDLE
                        AVPLib.Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), ConstEnum.Equipments.Chamber5.ToString())
                    End If
                    Me.m_stoStatusObject.RequestStatus(WAFER_INSIDE_CHAMBER5, enmPlasmaStatus.ToString())

                Case CLICKEDCHAMBER6
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf(CHAMBER6) > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf(CHAMBER6) > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If

                    chamberObj = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber6.ToString())
                    If enmPlasmaStatus = BinaryStatusControl.DisplayStatus.On Then
                        chamberObj.WaferInfo = waferInfo
                    Else
                        chamberObj.WaferInfo = Nothing
                        ' Update PM State to IDLE
                        AVPLib.Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), ConstEnum.Equipments.Chamber6.ToString())
                    End If

                    Me.m_stoStatusObject.RequestStatus(WAFER_INSIDE_CHAMBER6, enmPlasmaStatus.ToString())
            End Select

            'send status to equiment
            Dim equipment As AVPLib.DataManagerment.Equipment = Nothing
            equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Chamber & Click_On_Chamber)
            If equipment Is Nothing Or equipment.WaferInfo Is Nothing Then
                Exit Sub
            End If
            Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(equipment.Name)
            If (chamberConfig.Type = AVPLib.SystemModule.ModuleType.IBE) Then
                Business.IBEUtility.SetWaferStatusToIBE(equipment.Name, equipment.WaferInfo.WaferStatus)
            ElseIf (chamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD) Then
                Business.PVDUtility.SetWaferStatusToPVD(equipment.Name, equipment.WaferInfo.WaferStatus)
            End If

            ''Save to XML and Log
            'If chamberObj IsNot Nothing Then
            '    AVPLib.Utils.SavingWaferInfo(chamberObj.Name, String.Empty, chamberObj.WaferInfo)
            'End If

            Dim strSource As String
            If (blnWaferVisible) Then
                strSource = "CassettePanel.mnuCreateWafer"
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   "[Robot & Cassette] Create Wafer " & waferInfo.WaferID & " inside PM" + m_intClickedChamber.ToString())
            Else
                strSource = "CassettePanel.mnuDeleteWafer"
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   "[Robot & Cassette] Delete Wafer " & waferInfo.WaferID & " inside PM" + m_intClickedChamber.ToString())
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-10-11</date>
    ''' </author>
    ''' <summary>
    ''' Show or visible chamber based on configuration file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadRobotConfig()
        lblRoughPumpInUse.Location = New Point(RoughPumpControl.Left - 10, RoughPumpControl.Top + RoughPumpControl.Height + 10)
        btnTMProtectedMode.Location = New Point(tabGroup.Right - btnTMProtectedMode.Width, tabGroup.Top + tabGroup.Height + 10)
        btnCancelMove.Location = New Point(btnTMProtectedMode.Location.X, btnTMProtectedMode.Location.Y + btnTMProtectedMode.Height + 6)
        lccLoadLockA.NumSlot = AVPLib.RobotConfigurationValues.LOADLOCKA_SLOTS
        lccLoadLockB.NumSlot = AVPLib.RobotConfigurationValues.LOADLOCKB_SLOTS
        ''base on Harmer button 
        lccLoadLockA.Left = btnMechineTool.Left - lccLoadLockA.Width
        crcLLACryo.Left = lccLoadLockA.Left - crcLLACryo.Width - (lccLoadLockA.NumSlot Mod 12) * 10 - 20
        lccLoadLockB.Left = btnMechineTool.Left + btnMechineTool.Width + 20
        crcLLBCryo.Left = lccLoadLockB.Left + lccLoadLockB.Width + 20
        ' pnlRobotArmStatus.Top = lblRoughPumpInUse.Top + lblRoughPumpInUse.Height + 10
        'pnlRobotArmStatus.Size = New Size(206, 32)
        If RobotConfigurationValues.INSTALLED_CX6 Then
            Me.PanelStyle = CX_Style.CX6
            Initialize_CX6()
            ' lccLoadLockA.Left = TMCtl.Left - lccLoadLockA.Width - 2
        ElseIf RobotConfigurationValues.INSTALLED_CX7 Then
            Me.PanelStyle = CX_Style.CX7
            Initialize_CX7()
            ' lccLoadLockA.Left = TMCtl.Left - lccLoadLockA.Width - 2
        ElseIf RobotConfigurationValues.INSTALLED_CX8 Then
            Me.PanelStyle = CX_Style.CX8
            Initialize_CX8()
        ElseIf RobotConfigurationValues.INSTALLED_CX5 Then
            Me.PanelStyle = CX_Style.CX5
            Initialize_CX5()
        End If

        If atwAutoTransferWafer.cboStationList.Items.Count > 1 Then
            atwAutoTransferWafer.cboStationList.Sorted = True
            atwAutoTransferWafer.cboStationList.SelectedIndex = 1
        End If

        IgcgChamber1.Text = AVPLib.RobotConfigurationValues.CHAMBER1_NAME
        IgcgChamber2.Text = AVPLib.RobotConfigurationValues.CHAMBER2_NAME
        IgcgChamber3.Text = AVPLib.RobotConfigurationValues.CHAMBER3_NAME
        IgcgChamber4.Text = AVPLib.RobotConfigurationValues.CHAMBER4_NAME
        IgcgChamber5.Text = AVPLib.RobotConfigurationValues.CHAMBER5_NAME
        IgcgChamber6.Text = AVPLib.RobotConfigurationValues.CHAMBER6_NAME

        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-03-22</date>
        crcTMWaterPump.Visible = AVPLib.RobotConfigurationValues.TMWATERPUM_VISIBLE

        If (AVPLib.RobotConfigurationValues.LOADLOCKA_VISIBLE = False) Then
            LLALeg.Visible = False
            HivacValveLLA.Visible = False
            lccLoadLockA.Visible = False
            Robot_Body.LLAInstalled = False

            GasLineRoughValveLLA.Visible = False
            GasLineVentValveLLA.Visible = False
            ValveLLAFastVent.Visible = False
            ValveLLASlowRough.Visible = False
            ValveLLASlowVent.Visible = False
            ValveLLAFastRough.Visible = False

            lblLLASlowRough.Visible = False
            lblLLASlowVent.Visible = False
            lblLLAFastRough.Visible = False
            lblLLAFastVent.Visible = False

            HivacValveLLA.Visible = False
            btnLeftTool.Visible = False
            crcLLACryo.Visible = False
            MesaValveLLA.Status = RoundRectangleStatusControl.DisplayStatus.Closed
        End If

        If (AVPLib.RobotConfigurationValues.LOADLOCKB_VISIBLE = False) Then
            LLBLeg.Visible = False
            HivacValveLLB.Visible = False
            lccLoadLockB.Visible = False
            Robot_Body.LLBInstalled = False

            GasLineRoughValveLLB.Dispose()
            GasLineVentValveLLB.Dispose()
            ValveLLBSlowVent.Dispose()
            ValveLLBFastVent.Dispose()
            ValveLLBSlowRough.Dispose()
            ValveLLBFastRough.Dispose()

            lblLLBSlowRough.Visible = False
            lblLLBFastRough.Visible = False
            lblLLBSlowVent.Visible = False
            lblLLBFastVent.Visible = False

            HivacValveLLB.Visible = False
            btnRightTool.Visible = False
            crcLLBCryo.Visible = False
            MesaValveLLB.Status = RoundRectangleStatusControl.DisplayStatus.Closed
        End If

        '#07/26/2011 
        '#-AVP->TM.  LLB menu still available when not installed.
        '#Begin fix:
        PopUpPanel.ConfigShowGUI(Robot_Body.LLAInstalled, Robot_Body.LLBInstalled)
        '#End fix.

        If AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE = False Then
            CX_PM1.Visible = False
            Robot_Body.PM1Installed = False
            IgcgChamber1.Visible = False
            MesaValvePM1.Status = RoundRectangleStatusControl.DisplayStatus.Closed
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE = False Then
            CX_PM2.Visible = False
            Robot_Body.PM2Installed = False
            IgcgChamber2.Visible = False
            MesaValvePM2.Status = RoundRectangleStatusControl.DisplayStatus.Closed
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE = False Then
            CX_PM3.Visible = False
            Robot_Body.PM3Installed = False
            IgcgChamber3.Visible = False
            MesaValvePM3.Status = RoundRectangleStatusControl.DisplayStatus.Closed
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER4_VISIBLE = False Then
            CX_PM4.Visible = False
            Robot_Body.PM4Installed = False
            IgcgChamber4.Visible = False
            MesaValvePM4.Status = RoundRectangleStatusControl.DisplayStatus.Closed
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER5_VISIBLE = False Then
            CX_PM5.Visible = False
            Robot_Body.PM5Installed = False
            IgcgChamber5.Visible = False
            MesaValvePM5.Status = RoundRectangleStatusControl.DisplayStatus.Closed
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER6_VISIBLE = False Then
            CX_PM6.Visible = False
            Robot_Body.PM6Installed = False
            IgcgChamber6.Visible = False
            MesaValvePM6.Status = RoundRectangleStatusControl.DisplayStatus.Closed
        End If
        clearStatusTimer.Enabled = False
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle form load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProcessPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LLALeg.CassettePresent = False
            LLBLeg.CassettePresent = False

            ' TMCtl.Message = AVPLib.ContainerData.GetMessageText("IgcgTMMessage")
            '
            Dim strMessage As String = AVPLib.ContainerData.GetMessageText("IgcgChamberMessage")
            IgcgChamber1.Message = String.Format(strMessage, AVPLib.RobotConfigurationValues.CHAMBER1_NAME)
            IgcgChamber2.Message = String.Format(strMessage, AVPLib.RobotConfigurationValues.CHAMBER2_NAME)
            IgcgChamber3.Message = String.Format(strMessage, AVPLib.RobotConfigurationValues.CHAMBER3_NAME)
            IgcgChamber4.Message = String.Format(strMessage, AVPLib.RobotConfigurationValues.CHAMBER4_NAME)
            IgcgChamber5.Message = String.Format(strMessage, AVPLib.RobotConfigurationValues.CHAMBER5_NAME)

            IgcgChamber1.Text = AVPLib.RobotConfigurationValues.CHAMBER1_NAME
            IgcgChamber2.Text = AVPLib.RobotConfigurationValues.CHAMBER2_NAME
            IgcgChamber3.Text = AVPLib.RobotConfigurationValues.CHAMBER3_NAME
            IgcgChamber4.Text = AVPLib.RobotConfigurationValues.CHAMBER4_NAME
            IgcgChamber5.Text = AVPLib.RobotConfigurationValues.CHAMBER5_NAME

            '
            Me.LoadRobotConfig()
            m_Robot.Initiate()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu create wafer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuCreateWafer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCreateWafer.Click
        AVPLib.Log.guiLogger.Info("Enter mnuCreateWafer_Click")
        Try
            ' Create wafer dialog
            Dim addwafer As WaferInfoDlg = New WaferInfoDlg()
            addwafer.ShowDialog()
            If addwafer.DialogResult = DialogResult.OK Then
                If (m_intClickedChamber = CLICKEDALIGNER) Then
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf("Aligner") > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf("Aligner") > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If
                    'awcAligner.Status = BinaryStatusControl.DisplayStatus.On
                    Me.m_stoStatusObject.RequestStatus("WaferInsideAligner", BinaryStatusControl.DisplayStatus.On.ToString())

                    Dim cb As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                    cb.WaferInfo = addwafer.WaferInfo

                    Dim strSource As String = "CassettePanel.mnuCreateWafer"
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                       AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                       "[Robot & Cassette] Create Wafer " & addwafer.WaferInfo.WaferID & " inside aligner")

                ElseIf (m_intClickedChamber = CLICKEDROBOT) Then
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf("Robot Arm") > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf("Robot Arm") > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If

                    Me.m_stoStatusObject.RequestStatus("WaferInsideRobot", BinaryStatusControl.DisplayStatus.On.ToString())

                    Dim cb As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                    cb.WaferInfo = addwafer.WaferInfo

                    Dim strSource As String = "CassettePanel.mnuCreateWafer"
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                       AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                       "[Robot & Cassette] Create Wafer " & addwafer.WaferInfo.WaferID & " inside Robot Arm")
                Else
                    'update the wafer infomation for the chamber

                    SetWaferInside(True, BinaryStatusControl.DisplayStatus.On, addwafer.WaferInfo)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuCreateWafer_Click")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu delete wafer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuDeleteWafer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteWafer.Click
        AVPLib.Log.guiLogger.Info("Enter mnuDeleteWafer_Click")
        Try
            If (m_intClickedChamber = CLICKEDALIGNER) Then
                stwSemiautoTransferWafer.chkUseAligner.Checked = False
                If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf("Aligner") > -1 Then
                    Me.stwSemiautoTransferWafer.txtSource.Clear()
                ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf("Aligner") > -1 Then
                    Me.stwSemiautoTransferWafer.txtDestination.Clear()
                End If
                Me.m_stoStatusObject.RequestStatus("WaferInsideAligner", BinaryStatusControl.DisplayStatus.Off.ToString())

                Dim cb As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                cb.WaferInfo = Nothing

                Dim strSource As String = "CassettePanel.mnuDeleteWafer"
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   "[Robot & Cassette] Delete Wafer inside aligner")
            ElseIf (m_intClickedChamber = CLICKEDROBOT) Then
                If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf("Robot Arm") > -1 Then
                    Me.stwSemiautoTransferWafer.txtSource.Clear()
                ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf("Robot Arm") > -1 Then
                    Me.stwSemiautoTransferWafer.txtDestination.Clear()
                End If

                Dim cb As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                cb.WaferInfo = Nothing

                Me.m_stoStatusObject.RequestStatus("WaferInsideRobot", BinaryStatusControl.DisplayStatus.Off.ToString())
                Dim strSource As String = "CassettePanel.mnuDeleteWafer"
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   "[Robot & Cassette] Delete Wafer inside Robot Arm")
            Else
                SetWaferInside(False, BinaryStatusControl.DisplayStatus.Off, Nothing)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuDeleteWafer_Click")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu source for move
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuSrcForMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSrcForMove.Click
        AVPLib.Log.guiLogger.Info("Enter mnuSrcForMove_Click")
        Try
            'WHEN STARTING -> SHOW MESSAGE BOX
            If stwSemiautoTransferWafer.btnStart.Enabled = False AndAlso _
              Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) AndAlso _
                     Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then ''transferring
                Utils.ShowAVPMessageBox("Please wait for other transfer to complete...", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
            Else
                'SOURCE = NEW SOURCE
                stwSemiautoTransferWafer.txtSource.Text = GenerateSrcOrDst()
                'CHECK SOURCE AND DESTIANTION
                'IF ERROR CLEAR DESTINATION 
                If stwSemiautoTransferWafer.txtDestination.Text = stwSemiautoTransferWafer.txtSource.Text Then
                    Utils.ShowAVPMessageBox("Source and Destination for Transfer Wafer are the same, Destination will be clear." & Chr(13) & " Please select Destination for Transfer Wafer again", "Transfer Wafer", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                    'KEEP DESTINATION BECAUSE IT'S NOT ERROR
                    stwSemiautoTransferWafer.txtDestination.Clear()
                End If
                'EVERYTHING OK -> SHOW STATUS MESSAGE ON BOTTON LEFT SCREEN
                AVPLib.Utils.ShowStatusMessage("Source for Transfer Wafer: " & stwSemiautoTransferWafer.txtSource.Text)
                'SHOW MESSAGE BOX TO CHOOSE ALIGNER
                ContainerForm.CassettesPanel.ShowTransferWaferDialog()
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Select Source For Move " + stwSemiautoTransferWafer.txtSource.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuSrcForMove_Click")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu destination for move
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuDstForMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDstForMove.Click
        AVPLib.Log.guiLogger.Info("Enter mnuDstForMove_Click")
        Try
            'WHEN STARTING -> SHOW MESSAGE BOX
            If stwSemiautoTransferWafer.btnStart.Enabled = False AndAlso _
               Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) AndAlso _
                      Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then ''transferring
                Utils.ShowAVPMessageBox("Please wait for other transfer to complete...", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
            Else
                'DESTINATION = NEW DESTINATION
                stwSemiautoTransferWafer.txtDestination.Text = GenerateSrcOrDst()

                'WHEN SELECT DESTINATION IS ALIGNER
                'NEED CHECK ALIGNER IS CURRENT IN USE
                If stwSemiautoTransferWafer.txtDestination.Text = STR_ALIGNER Then
                    'stwSemiautoTransferWafer.chkUseAligner.Checked = True
                    stwSemiautoTransferWafer.Dest_Is_Aligner = True
                Else
                    stwSemiautoTransferWafer.Dest_Is_Aligner = False
                End If

                'IF DESTINATION = SOURCE (ERROR)
                If stwSemiautoTransferWafer.txtSource.Text = stwSemiautoTransferWafer.txtDestination.Text Then
                    Utils.ShowAVPMessageBox("Source and Destination for Transfer Wafer are the same, Source will be clear. " & Chr(13) & "Please select Source for Transfer Wafer again", "Transfer Wafer", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                    'NEW DESTIANTION IS WRONG SO CLEAR IT
                    stwSemiautoTransferWafer.txtSource.Clear()
                End If
                'WHEN EVERYTHING OK -> SHOW STATUS MESSAGE ON BOTTON LEFT SCREEN
                AVPLib.Utils.ShowStatusMessage("Destination for Transfer Wafer: " & stwSemiautoTransferWafer.txtDestination.Text)
                'SHOW DIALOG BOX TO SELECT ALIGNER
                ContainerForm.CassettesPanel.ShowTransferWaferDialog()
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Select Destination For Move " + stwSemiautoTransferWafer.txtDestination.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuDstForMove_Click")
    End Sub

    Public Sub ShowTransferWaferDialog()
        Dim strMessageText As String = String.Empty
        If ContainerForm.CassettesPanel.ISTM_ONLINE Then
            Utils.ShowAVPMessageBox("Cannot transfer wafer when TM is online.", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Cannot transfer wafer when TM is online.")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) AndAlso _
               Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then
            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("StartSemiAutoRobotCassettes"), START_SEMIAUTOTRANFER)
            Dim result As Integer = Utils.ShowAVPUseAlignerMessageBox(stwSemiautoTransferWafer.txtSource.Text, _
                                                                      stwSemiautoTransferWafer.txtDestination.Text, _
                                                                      stwSemiautoTransferWafer.Dest_Is_Aligner, _
                                                                      stwSemiautoTransferWafer.txtRecipe.Text)

            If result = System.Windows.Forms.DialogResult.OK Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Main Screen] Start Transfer Wafer")
                Dim blnUseAligner As Boolean = AVPUseAlignerDialogBox.IsUsingAligner
                Dim RecipeName As String = AVPUseAlignerDialogBox.RecipeName
                If blnUseAligner And String.IsNullOrEmpty(RecipeName) Then
                    Utils.ShowAVPMessageBox("Please select Recipe for Aligner", _
                                             START_SEMIAUTOTRANFER, MessageBoxIcon.Error, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] There is not recipe for Aligner.")
                    Exit Sub
                End If
                stwSemiautoTransferWafer.txtStatus.Clear()
                Dim strSrc As String = AVPLib.Utils.chamberName2ChamberID(stwSemiautoTransferWafer.txtSource.Text)
                strSrc = strSrc.Replace(" ", "") ' Remove blank space.
                Dim strDest As String = AVPLib.Utils.chamberName2ChamberID(stwSemiautoTransferWafer.txtDestination.Text)
                strDest = strDest.Replace(" ", "") ' Remove blank space.
                Dim strValue As String = _
                      strSrc + "," + _
                      strDest + "," + _
                      AVPLib.ConstEnum.USEALIGNER + CStr(blnUseAligner) + _
                      IIf(blnUseAligner, "," + RecipeName, String.Empty)
                stwSemiautoTransferWafer.txtRecipe.Text = RecipeName
                stwSemiautoTransferWafer.chkUseAligner.Checked = blnUseAligner
                ContainerForm.CassettesPanel.stwSemiautoTransferWafer.btnStart_Click()
                If blnUseAligner Then
                    ' Arrange_Control_Run_With_AlignerRecipe(True)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                    "[Main Screen] Start Transfer from " & AVPLib.Utils.chamberID2ChamberName(strSrc) & " to " & AVPLib.Utils.chamberID2ChamberName(strDest) & " with using Aligner: " & RecipeName)
                Else
                    'Arrange_Control_Run_With_AlignerRecipe(False)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                    "[Main Screen] Start Transfer from " & AVPLib.Utils.chamberID2ChamberName(strSrc) & " to " & AVPLib.Utils.chamberID2ChamberName(strDest) & " without using Aligner")
                End If
            Else
                stwSemiautoTransferWafer.txtSource.Clear()
                stwSemiautoTransferWafer.txtDestination.Clear()
            End If
        End If
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on circle Plasma of Chamber1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cpcCirclePlasmaHand1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter cpcCirclePlasmaHand1_Click")
        Try
            ' PrepareChamberMenu(Me.cpcWaferChamber1)
            ShowContextMenuClickOnChamber(sender)
            m_intClickedChamber = CLICKEDCHAMBER1
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave cpcCirclePlasmaHand1_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on circle Plasma of Chamber2
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cpcWaferChamber2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter cpcWaferChamber2_Click")
        Try
            'PrepareChamberMenu(Me.cpcWaferChamber2)
            ShowContextMenuClickOnChamber(sender)
            m_intClickedChamber = CLICKEDCHAMBER2
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave cpcWaferChamber2_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on circle Plasma of Chamber3
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cpcCirclePlasmaHand3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter cpcCirclePlasmaHand3_Click")
        Try
            ' PrepareChamberMenu(Me.cpcWaferChamber3)
            ShowContextMenuClickOnChamber(sender)
            m_intClickedChamber = CLICKEDCHAMBER3
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave cpcCirclePlasmaHand3_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on circle Plasma of Chamber4
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cpcWaferChamber4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter cpcWaferChamber4_Click")
        Try
            ' PrepareChamberMenu(Me.cpcWaferChamber4)
            ShowContextMenuClickOnChamber(sender)
            m_intClickedChamber = CLICKEDCHAMBER4
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave cpcWaferChamber4_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on circle Plasma of Chamber5
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cpcCirclePlasmaHand5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter cpcCirclePlasmaHand5_Click")
        Try
            ' PrepareChamberMenu(Me.cpcWaferChamber5)
            ShowContextMenuClickOnChamber(sender)
            m_intClickedChamber = CLICKEDCHAMBER5
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave cpcCirclePlasmaHand5_Click")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Tool button   
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTool.Click
        AVPLib.Log.guiLogger.Info("Enter btnTool_Click")
        Try
            Dim pos As New System.Drawing.Point(btnTool.Location)
            pos.Y += btnTool.Height
            pos = Me.PointToScreen(pos)
            cmsTool.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnTool_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Home menu item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHome.Click
        AVPLib.Log.guiLogger.Info("Enter mnuHome_Click")
        Dim strMessageText As String = String.Empty
        Try
            strMessageText = AVPLib.ContainerData.GetMessageText("HomeMenuRobotCassettes")
            If (Utils.ShowAVPMessageBox(strMessageText, HOME_TM, MessageBoxIcon.Question) = DialogResult.OK) Then
                m_stoStatusObject.RequestStatus(mnuHome.Name, "Click")
                Utils.AlignerCMDAction(False, True)
                cmsTool.Enabled = False
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                  "[Main Screen]" & " click Home Robot")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuHome_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Align menu item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuAlign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAlign.Click
        AVPLib.Log.guiLogger.Info("Enter mnuAlign_Click")
        Dim strMessageText As String = String.Empty
        Try
            strMessageText = AVPLib.ContainerData.GetMessageText("AlignMenuRobotCassettes")
            If (Utils.ShowAVPMessageBox(strMessageText, ALIGN, MessageBoxIcon.Question) = DialogResult.OK) Then
                m_stoStatusObject.RequestStatus(mnuAlign.Name, "Click")
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                 "[Main Screen]" & " click Align Robot")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuAlign_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-24</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on aligner
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub awcAligner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles awcAligner.Click
        AVPLib.Log.guiLogger.Info("Enter awcAligner_Click")
        Try
            PrepareAlignerMenu()
            ShowContextMenuClickOnAligner()
            m_intClickedChamber = CLICKEDALIGNER
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave awcAligner_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-08-14</date>
    ''' </author>
    ''' <summary>
    ''' ticHandOriginal_Click
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub picRobotBody_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
                         Handles ticHandOriginal.Click

        AVPLib.Log.guiLogger.Info("Enter picRobotBody_Click")
        Try
            PrepareRobotMenu()
            ShowContextMenuClickOnRobot()
            m_intClickedChamber = CLICKEDROBOT
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave picRobotBody_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for label Status Text (from Transfer Screen) 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lblStatusText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblStatusText.TextChanged
        If ContainerForm.Chamber1Visible Then
            ContainerForm.ChamberPanel(Equipments.Chamber1.ToString()).StatusText = Me.lblStatusText.Text
        End If
        If ContainerForm.Chamber2Visible Then
            ContainerForm.ChamberPanel(Equipments.Chamber2.ToString()).StatusText = Me.lblStatusText.Text
        End If
        If ContainerForm.Chamber3Visible Then
            ContainerForm.ChamberPanel(Equipments.Chamber3.ToString()).StatusText = Me.lblStatusText.Text
        End If
        If ContainerForm.Chamber4Visible Then
            ContainerForm.ChamberPanel(Equipments.Chamber4.ToString()).StatusText = Me.lblStatusText.Text
        End If
        If ContainerForm.Chamber5Visible Then
            ContainerForm.ChamberPanel(Equipments.Chamber5.ToString()).StatusText = Me.lblStatusText.Text
        End If
        If ContainerForm.Chamber6Visible Then
            ContainerForm.ChamberPanel(Equipments.Chamber6.ToString()).StatusText = Me.lblStatusText.Text
        End If
        ContainerForm.ProcessPanel.lblStatusText.Text = Me.lblStatusText.Text
        ContainerForm.ProcessPanel.lblStatusText.ForeColor = Me.lblStatusText.ForeColor
        '#05/16/2011 
        '#All event messages coming from PVD/IBE should be logged.  All LL’s/TM event message should be logged
        '#Begin fix
        If Not String.IsNullOrEmpty(Me.lblStatusText.Text) Then
            Dim strSource = String.Empty
            Dim strRegularExp = "^\[.*?\] (PM\d):\s?(.*)"
            Try
                Dim FoundMatch As Boolean = Regex.IsMatch(Me.lblStatusText.Text, strRegularExp)
                If (FoundMatch) Then
                    strSource = Regex.Match(Me.lblStatusText.Text, strRegularExp).Groups(1).Value
                End If
            Catch ex As Exception
                strSource = String.Empty
            End Try
            If Not String.IsNullOrEmpty(strSource) AndAlso AVPLib.Utils.CheckSourceLogIsAEquipment(AVPLib.Utils.chamberName2ChamberID(strSource)) = True Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, strSource, Regex.Match(Me.lblStatusText.Text, strRegularExp).Groups(2).Value)
            End If
        End If
        '#End fix.
        clearStatusTimer.Enabled = True
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for clearStatusTimer_Tick (from Transfer Screen) 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    '''dat cao add a local variable to control status text
    Private m_ClearTimerCount As Integer = 0
    Private Sub clearStatusTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearStatusTimer.Tick
        If (String.IsNullOrEmpty(ContainerForm.CassettesPanel.stwSemiautoTransferWafer.txtDestination.Text)) OrElse _
           (String.IsNullOrEmpty(ContainerForm.CassettesPanel.stwSemiautoTransferWafer.txtSource.Text)) OrElse _
         ContainerForm.CassettesPanel.stwSemiautoTransferWafer.btnStart.Enabled Then
            If (m_ClearTimerCount > 600) Then ' increase clear message status from 2 minutes to 10 minutes.
                'if not transfer wafer -> clear status text
                'if transfer wafer -> keep status text more
                ContainerForm.CassettesPanel.lblStatusText.Text = String.Empty
                clearStatusTimer.Enabled = False
                m_ClearTimerCount = 0
                m_ReturnWaferStatus = TranferWaferStatus.None
            Else
                m_ClearTimerCount += 1
            End If
        End If

        'if 
        If (m_ReturnWaferStatus = TranferWaferStatus.Starting And _
        ContainerForm.CassettesPanel.lblStatusText.Text = "" And _
        m_ReturnStatusText = "") Then
            ContainerForm.CassettesPanel.lblStatusText.Text = AVPLib.ConstEnum.Return_Wafer_Starting
            m_ClearTimerCount = 0
        ElseIf (m_ReturnWaferStatus = TranferWaferStatus.Starting And ContainerForm.CassettesPanel.lblStatusText.Text = _
            AVPLib.ConstEnum.Return_Wafer_Starting) Then
            ContainerForm.CassettesPanel.lblStatusText.Text = ""
            m_ClearTimerCount = 0
        ElseIf (m_ReturnWaferStatus = TranferWaferStatus.Starting And _
        ContainerForm.CassettesPanel.lblStatusText.Text.Contains("Start Transfer")) Then
            m_ReturnStatusText = ContainerForm.CassettesPanel.lblStatusText.Text
            ContainerForm.CassettesPanel.lblStatusText.Text = ""
            m_ClearTimerCount = 0
        ElseIf (m_ReturnWaferStatus = TranferWaferStatus.Starting And _
        ContainerForm.CassettesPanel.lblStatusText.Text = "" And Not _
        m_ReturnStatusText = "") Then
            ContainerForm.CassettesPanel.lblStatusText.Text = m_ReturnStatusText
            m_ClearTimerCount = 0
        ElseIf (m_ReturnWaferStatus = TranferWaferStatus.Starting And ContainerForm.CassettesPanel.lblStatusText.Text.Contains("Failed")) Then
            m_ReturnWaferStatus = TranferWaferStatus.Error
            m_ReturnStatusText = ""
            m_ClearTimerCount = 0
        ElseIf (m_ReturnWaferStatus = TranferWaferStatus.Starting And ContainerForm.CassettesPanel.lblStatusText.Text.Contains("Completed")) Then
            m_ReturnWaferStatus = TranferWaferStatus.Finished
            m_ReturnStatusText = ""
            m_ClearTimerCount = 0
        Else
            m_ReturnWaferStatus = TranferWaferStatus.None
            m_ReturnStatusText = ""
        End If

    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for update WaferInfo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UpdateWaferInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdateWaferInfoToolStripMenuItem.Click
        AVPLib.Log.guiLogger.Info("Enter UpdateWaferInfoToolStripMenuItem_Click")
        Try
            Dim waferInfo As AVPLib.AVPWaferInfo = Nothing
            Dim equipment As AVPLib.DataManagerment.Equipment = Nothing
            If (m_intClickedChamber = CLICKEDALIGNER) Then
                ' Get information on Aligner
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())
            ElseIf (m_intClickedChamber = CLICKEDROBOT) Then
                ' Get information on Robot
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            ElseIf (m_intClickedChamber = CLICKEDCHAMBER1) Then
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
            ElseIf (m_intClickedChamber = CLICKEDCHAMBER2) Then
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
            ElseIf (m_intClickedChamber = CLICKEDCHAMBER3) Then
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
            ElseIf (m_intClickedChamber = CLICKEDCHAMBER4) Then
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber4.ToString())
            ElseIf (m_intClickedChamber = CLICKEDCHAMBER5) Then
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber5.ToString())
            ElseIf (m_intClickedChamber = CLICKEDCHAMBER6) Then
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber6.ToString())
            End If

            If equipment IsNot Nothing Then
                waferInfo = equipment.WaferInfo

                ' Create wafer dialog
                Dim updateWafer As WaferInfoDlg = New WaferInfoDlg(waferInfo)
                updateWafer.ShowDialog()

                'Refresh GUI
                If (m_intClickedChamber = CLICKEDALIGNER) Then
                    'awcAligner.Status = BinaryStatusControl.DisplayStatus.On
                    Me.m_stoStatusObject.RequestStatus("WaferInside", BinaryStatusControl.DisplayStatus.On.ToString())
                ElseIf (m_intClickedChamber = CLICKEDROBOT) Then
                    Me.m_stoStatusObject.RequestStatus("WaferInside", BinaryStatusControl.DisplayStatus.On.ToString())
                Else
                    'update the wafer infomation for the chamber
                    SetWaferInside(True, BinaryStatusControl.DisplayStatus.On, waferInfo)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave UpdateWaferInfoToolStripMenuItem_Click")

    End Sub

#Region "Valve" '2 mode Unprotected and Protected
    ''Open - Close Mesa Valve
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for Mesa Valve Click (from 1 to 7)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rrcMesaValve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MesaValveLLA.Click, MesaValvePM1.Click, MesaValvePM2.Click, MesaValvePM3.Click, _
            MesaValvePM4.Click, MesaValvePM5.Click, MesaValveLLB.Click, MesaValvePM6.Click
        AVPLib.Log.guiLogger.Info("Enter rrcMesaValve_Click")
        Try
            Dim strMessageText As String
            'Dim strValue As String
            Dim blRet As Boolean = True
            Dim objTMController As AVPLib.Business.TMController = AVPLib.Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString())
            Dim mesaValve As RoundRectangleStatusControl = CType(sender, RoundRectangleStatusControl)
            Dim strChamber As String = String.Empty
            Dim strChamberName As String = GetChamberName(mesaValve.Name, strChamber)
            If Not AVPLib.ContainerData.IsChamberVisible(strChamber) Then
                Utils.ShowAVPMessageBox(strChamberName & " is not Available", strChamberName, MessageBoxIcon.Information, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                "[Main Screen]" & " - Try to click on Mesa Valve of " & strChamberName)
                Exit Sub
            End If
            If (mesaValve.Status = RoundRectangleStatusControl.DisplayStatus.Opened) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("MesaValvePM" & STRING_CLOSE)
                strMessageText = String.Format(strMessageText, strChamberName)
                If (Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK) Then
                    GoTo CloseMesaValve
                End If
            ElseIf (mesaValve.Status = RoundRectangleStatusControl.DisplayStatus.Closed) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("MesaValvePM" & STRING_OPEN)
                strMessageText = String.Format(strMessageText, strChamberName)
                If (Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK) Then
                    GoTo OpenMesaValve
                End If
            ElseIf (mesaValve.Status = RoundRectangleStatusControl.DisplayStatus.Unknown) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("MesaValvePM" & UNKNOWN)
                strMessageText = String.Format(strMessageText, strChamberName)
                Dim dlgResult As DialogResult = Utils.ShowAVPMessageBox(strMessageText, strChamberName, _
                    MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.OpenCloseCancel)
                If dlgResult = DialogResult.OK Then 'Open
                    GoTo OpenMesaValve
                ElseIf dlgResult = DialogResult.No Then 'Close
                    GoTo CloseMesaValve
                End If
            End If
            Exit Sub
OpenMesaValve:
            'Not in Cycle ATM mode
            If strChamber.StartsWith(ConstEnum.Chamber) Then
                '#07/07/2011 
                '#-	AVP->TM.   Tm override mode does not allow user to open isolation valve when Pmx is disconnected.
                If (m_TM_Protected_Mode.Status = ProtectedModStatus.Off) Then 'Fix.
                    Dim objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(strChamber)
                    If (objChamber.ConnectionStatus <> AVPLib.DataManagerment.Equipment.WorkingStatuses.On) Then
                        Dim MsgText As String = String.Format(AVPLib.ContainerData.GetMessageText("EquipmentDisconnect"), strChamberName)
                        Utils.ShowAVPMessageBox(MsgText, strChamberName, MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                  "[Main Screen]" & " - Open Mesa Valve of " & strChamberName & ", this PM is disconnected")
                        Exit Sub
                    End If
                End If
            Else ''LL is disconnected then 
                Dim objElevator As AVPLib.DataManagerment.LLElevator = Nothing
                If strChamber = LOAD_LOCK_A Then
                    objElevator = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
                ElseIf strChamber = LOAD_LOCK_B Then
                    objElevator = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLBElevator.ToString())
                End If
                If (objElevator.IsCommunicating = False) Then
                    Dim MsgText As String = String.Format(AVPLib.ContainerData.GetMessageText("EquipmentDisconnect"), strChamberName)
                    Utils.ShowAVPMessageBox(MsgText, strChamberName, MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                              "[Main Screen]" & " - Open Mesa Valve of " & strChamberName & ", this LL is disconnected")
                    Exit Sub
                End If

            End If
            If (m_TM_Protected_Mode.Status = ProtectedModStatus.Off) Then
                blRet = objTMController.CheckCondition2OpenTMIsolationValve(strChamber, False)
                If blRet = True Then
                    If strChamber.StartsWith(ConstEnum.Chamber) Then
                        If objTMController.IsOK_2OpenPMSlitValve(strChamber) Then
                            m_stoStatusObject.RequestStatus(mesaValve.Name, STR_ON)
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                           "[Main Screen]" & " - Open Mesa Valve of " & strChamberName)
                        Else
                            Utils.ShowAVPMessageBox(strChamber & " Is Running Process or Plasma Is On", _
                                                         strChamberName, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                              "[Main Screen]" & " - Can not Open Mesa Valve of " & strChamberName & " when Process is running or Plasma Is On")
                        End If
                    Else
                        m_stoStatusObject.RequestStatus(mesaValve.Name, STR_ON)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                        "[Main Screen]" & " - Open Mesa Valve of " & strChamberName)
                    End If
                Else
                    Utils.ShowAVPMessageBox(String.Format(AVPLib.ContainerData.GetMessageText(AVPLib.ConstEnum.CG_OF_TM_AND_RELATED_EQUIPMENT_NO_DIFFER10), _
                    strChamberName), strChamberName, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                         "[Main Screen]" & " - Check conditions to open Mesa Valve of " & strChamberName & " failed.")
                End If
            Else ' alway pass condition
                m_stoStatusObject.RequestStatus(mesaValve.Name, STR_ON)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
               "[Main Screen]" & " - Open Mesa Valve of " & strChamberName)
            End If
            Exit Sub
CloseMesaValve:
            m_stoStatusObject.RequestStatus(mesaValve.Name, STR_OFF)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                 "[Main Screen]" & " - Close Mesa Valve of " & strChamberName)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave rrcMesaValve_Click")
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for Valve Click (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ValveControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
     Handles ValveVent.Click, ValveLLASlowRough.Click, ValveLLBFastRough.Click, ValveLLBSlowRough.Click, ValveRough.Click, ValveLLBFastVent.Click, ValveLLBSlowVent.Click, ValveLLAFastVent.Click, ValveLLASlowVent.Click, ValveLLAFastRough.Click
        AVPLib.Log.guiLogger.Info("Enter ValveControl_Click")
        Try
            Dim Valve As AVP_Robot_Project.ValveControl = CType(sender, AVP_Robot_Project.ValveControl)
            Dim ValveName As String = Valve.Name
            Dim strMessageText As String
            Dim strValue As String
            If (Valve.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("Transfer" + ValveName + "Close")
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
            Else
                strMessageText = AVPLib.ContainerData.GetMessageText("Transfer" + ValveName + "Open")
                strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
            End If

            If (Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Question) = DialogResult.OK) Then
                ' check the condition before open the valve
                Dim cassetteModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                Dim loadlockA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
                Dim loadlockB As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockB.ToString())
                Dim blRet As Boolean = False, strResult As String = String.Empty
                If m_TM_Protected_Mode.Status = ProtectedModStatus.Off Then
                    If Valve.Status = BinaryStatusControl.DisplayStatus.On Then
                        blRet = True
                    Else
                        Select Case ValveName '''we should raise detail error message at the end 
                            Case VALVE_LLA_SLOW_ROUGH, VALVE_LLA_FAST_ROUGH
                                Dim eq As DataManagerment.Equipment = Utils.GetRoughPumpCurrentInUsed()
                                If (eq IsNot Nothing) Then
                                    If (eq.Name = Equipments.LoadLockA.ToString()) Then
                                        strResult = loadlockA.CheckCondition2OpenLLRough()
                                    Else
                                        strResult = STR_ROUGH_PUMP_IN_USE & AVPLib.Utils.chamberID2ChamberName(eq.Name)
                                    End If
                                Else
                                    strResult = loadlockA.CheckCondition2OpenLLRough()
                                End If
                            Case VALVE_LLB_SLOW_ROUGH, VALVE_LLB_FAST_ROUGH
                                Dim eq As DataManagerment.Equipment = Utils.GetRoughPumpCurrentInUsed()
                                If (eq IsNot Nothing) Then
                                    If (eq.Name = Equipments.LoadLockB.ToString()) Then
                                        strResult = loadlockB.CheckCondition2OpenLLRough()
                                    Else
                                        strResult = STR_ROUGH_PUMP_IN_USE & AVPLib.Utils.chamberID2ChamberName(eq.Name)
                                    End If
                                Else
                                    strResult = loadlockB.CheckCondition2OpenLLRough()
                                End If
                            Case VENT_VALVE
                                strResult = cassetteModule.checkCondition2OpenTMVent()
                            Case VALVE_LLB_SLOW_VENT, VALVE_LLB_FAST_VENT
                                strResult = loadlockB.CheckCondition2OpenLLVent()
                            Case VALVE_LLA_SLOW_VENT, VALVE_LLA_FAST_VENT
                                strResult = loadlockA.CheckCondition2OpenLLVent()
                            Case ROUGH_VALVE
                                Dim eq As DataManagerment.Equipment = Utils.GetRoughPumpCurrentInUsed()
                                If (eq IsNot Nothing) Then
                                    'able to open TM rough valve 
                                    If (eq.Name = Equipments.CassettesModule.ToString()) Then
                                        strResult = cassetteModule.checkCondition2OpenTMRough()
                                    Else
                                        strResult = STR_ROUGH_PUMP_IN_USE & AVPLib.Utils.chamberID2ChamberName(eq.Name)
                                    End If
                                Else
                                    strResult = cassetteModule.checkCondition2OpenTMRough()
                                End If

                        End Select
                        If strResult = String.Empty Then
                            blRet = True ''no error message
                        End If
                    End If
                Else
                    blRet = True 'alway true, not need check condition
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                             "[Main Screen]" & " - Clicked on " & ValveName)

                If blRet Then '''no error message
                    m_stoStatusObject.RequestStatus(ValveName, strValue)
                Else ''if strResult has error, we raise it
                    'MessageBox.Show(strResult, ValveName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Utils.ShowAVPMessageBox(strResult, ValveName, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                             "[Main Screen]" & " - Result of clicking on " & ValveName & " has error.")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ValveControl_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for Hivac Valve Click (from Transfer Screen) (LlA and LLB)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HivacValve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
       Handles HivacValveLLA.Click, HivacValveLLB.Click
        AVPLib.Log.guiLogger.Info("Enter HivacValve_Click")
        Dim strValue As String = String.Empty
        Dim hivacValve As RoundRectangleStatusControl = CType(sender, RoundRectangleStatusControl)
        Try
            Dim dlgRes As DialogResult
            Dim strMessageText As String = String.Empty
            Dim strChamberName As String = GetChamberName(hivacValve.Name, strValue)
            ''get equipment to check condition
            Dim loadlock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(strChamberName)
            'check status of Valve to get MessageText from config file
            If (hivacValve.Status = RoundRectangleStatusControl.DisplayStatus.Opened) Then 'Opened
                strMessageText = AVPLib.ContainerData.GetMessageText(hivacValve.Name & STRING_CLOSE)

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                             "[Main Screen]" & " - Close Hivac Valve of " & strChamberName)
                If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    strValue = STR_OFF
                    Exit Try
                Else
                    Exit Sub
                End If
            ElseIf (hivacValve.Status = RoundRectangleStatusControl.DisplayStatus.Unknown) Then 'unknown
                strMessageText = AVPLib.ContainerData.GetMessageText(hivacValve.Name & "Unknown")
            ElseIf (hivacValve.Status = RoundRectangleStatusControl.DisplayStatus.Closed) Then 'Closed
                strMessageText = AVPLib.ContainerData.GetMessageText(hivacValve.Name & STRING_OPEN)

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                             "[Main Screen]" & " - Open Hivac Valve of " & strChamberName)
                If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    GoTo CheckCondition2Open
                Else
                    Exit Sub
                End If
            End If

            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                        "[Main Screen]" & " - Clicked on Hivac Valve of " & strChamberName)

            dlgRes = Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.OpenCloseCancel) 'MessageBoxButtons.YesNoCancel)
            If dlgRes = DialogResult.Cancel Then
                Exit Sub
            ElseIf dlgRes = DialogResult.No Then 'close
                strValue = STR_OFF
                Exit Try
            ElseIf dlgRes = DialogResult.OK Then ''open
                GoTo CheckCondition2Open
            End If

CheckCondition2Open:
            If (m_TM_Protected_Mode.Status = ProtectedModStatus.Off) Then ' if not Protected mode then check condition
                Dim strResult As String = loadlock.CheckCondition2OpenLLHiVac()
                ''button is off->check condition of TM Hivac
                If strResult = String.Empty Then
                    ''if pass-->we have value for strValue
                    strValue = STR_ON
                Else '''''''if has error message
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                "[Main Screen]" & " - Check conditions to open Hivac Valve of " & strChamberName & " has errors.")
                    Utils.ShowAVPMessageBox(strResult, strChamberName, MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                End If
            Else
                strValue = STR_ON
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        If Not (String.IsNullOrEmpty(strValue)) Then
            m_stoStatusObject.RequestStatus(hivacValve.Name, strValue)
        End If
        AVPLib.Log.guiLogger.Info("Leave HivacValve_Click")
    End Sub

#End Region

#Region "button Hammer"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for btnMechineTool_Click (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnMechineTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMechineTool.Click
        AVPLib.Log.guiLogger.Info("Enter btnMechineTool_Click")
        Try
            'Dim pos As New System.Drawing.Point(btnMechineTool.Location)
            'pos.Y += btnMechineTool.Height
            'pos = Me.PointToScreen(pos)
            'cmsMechineTool.Show(pos)

            PopUpPanel.StartPosition = FormStartPosition.CenterScreen
            PopUpPanel.ShowDialog(AVPRobotMain)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnMechineTool_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on Left Tool button  (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLeftTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftTool.Click
        AVPLib.Log.guiLogger.Info("Enter btnLeftTool_Click")
        Try
            'Dim pos As New System.Drawing.Point(btnLeftTool.Location)
            'pos.Y += btnLeftTool.Height
            'pos = Me.PointToScreen(pos)
            'cmsLeftTool.Show(pos)
            '  Dim avpMainForm As AVPRobotMain = CType(AVP_Robot_Project.MainForm, AVPRobotMain)
            PopUpPanel.StartPosition = FormStartPosition.CenterScreen
            PopUpPanel.ShowDialog(AVPRobotMain)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnLeftTool_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on Right Tool button  (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRightTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightTool.Click
        AVPLib.Log.guiLogger.Info("Enter btnRightTool_Click")
        Try
            'Dim pos As New System.Drawing.Point(btnRightTool.Location)
            'pos.Y += btnRightTool.Height
            'pos = Me.PointToScreen(pos)
            'cmsRightTool.Show(pos)
            PopUpPanel.StartPosition = FormStartPosition.CenterScreen
            PopUpPanel.ShowDialog(AVPRobotMain)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnRightTool_Click")
    End Sub
#End Region

#Region "Tool Mechine, Left, Right Click"

    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-03-31</date>
    ''' </author>
    ''' <summary>
    ''' Go Online
    ''' </summary>
    ''' <param name=""></param>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Public Overridable Sub GoOnline()

        ' TM
        If ContainerForm.CassettesPanel.PopUpPanel.btnTMOnline.Status = SL_CustomButton.DisplayStatus.Off Then
            ContainerForm.CassettesPanel.SetTMOnline(True)
            ContainerForm.CassettesPanel.PopUpPanel.blnGoOnline = True
            ContainerForm.CassettesPanel.PopUpPanel.btnTMOnline_Click(ContainerForm.CassettesPanel.PopUpPanel.btnTMOnline, Nothing)
        End If

        ' Load Lock A
        If AVPLib.RobotConfigurationValues.LOADLOCKA_VISIBLE AndAlso ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Status = SL_CustomButton.DisplayStatus.Off Then
            ContainerForm.CassettesPanel.SetLLAOnline(True)
            ContainerForm.CassettesPanel.PopUpPanel.blnGoOnline = True
            ContainerForm.CassettesPanel.PopUpPanel.btnTMOnline_Click(ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline, Nothing)
        End If

        ' Load Lock B
        If AVPLib.RobotConfigurationValues.LOADLOCKB_VISIBLE AndAlso _
           ContainerForm.CassettesPanel.PopUpPanel.btnLLBOnline.Status = SL_CustomButton.DisplayStatus.Off Then
            ContainerForm.CassettesPanel.SetLLBOnline(True)
            ContainerForm.CassettesPanel.PopUpPanel.blnGoOnline = True
            ContainerForm.CassettesPanel.PopUpPanel.btnTMOnline_Click(ContainerForm.CassettesPanel.PopUpPanel.btnLLBOnline, Nothing)
        End If
        ContainerForm.CassettesPanel.PopUpPanel.blnGoOnline = False
    End Sub

    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on Online menu item of machine  (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechineOnline.Click, mnuLeftOnline.Click, mnuRightOnline.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuOnline_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
    '        'Me.DisableOnline(ToolStripMenu)
    '        ' Disable relevant buttons in Cassette Control.
    '        If ToolStripMenu.Name = LEFTONLINE Then 'mnuLeftOnline
    '            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOnlineOfCassettesPanel"), ONLINELOADLOCKA)
    '            If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                ContainerForm.CassettesPanel.SetLLAOnline(True)
    '                m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring LLA online")
    '            End If
    '        ElseIf ToolStripMenu.Name = RIGHTONLINE Then 'mnuRightOnline
    '            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOnlineOfCassettesPanel"), ONLINELOADLOCKB)
    '            If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                ContainerForm.CassettesPanel.SetLLBOnline(True)
    '                m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring LLB online")
    '            End If
    '        ElseIf ToolStripMenu.Name = MECHINEONLINE Then
    '            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOnlineOfCassettesPanel"), ONLINETM)
    '            If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                ContainerForm.CassettesPanel.SetTMOnline(True)
    '                m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring TM online")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuOnline_Click")
    'End Sub
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on Offline menu item of machine (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuOffline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechineOffline.Click, mnuLeftOffline.Click, mnuRightOffline.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuOffline_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
    '        '' Allow users to manipulate valves.
    '        Select Case ToolStripMenu.Name
    '            Case mnuMechineOffline.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOfflineOfCassettesPanel"), ONLINETM)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    Me.MechineValveStatus(True)
    '                    ContainerForm.CassettesPanel.SetTMOnline(False)
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring TM offline")
    '                End If
    '            Case mnuLeftOffline.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOfflineOfCassettesPanel"), ONLINELOADLOCKA)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    Me.LeftValveStatus(True)
    '                    ContainerForm.CassettesPanel.SetLLAOnline(False)
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring LLA offline")
    '                End If
    '            Case mnuRightOffline.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOfflineOfCassettesPanel"), ONLINELOADLOCKB)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    Me.RightValveStatus(True)
    '                    ContainerForm.CassettesPanel.SetLLBOnline(False)
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring LLB offline")
    '                End If
    '        End Select
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuOffline_Click")
    'End Sub
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on Pumb down menu item of machine (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuPumpDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechinePumpDown.Click, mnuLeftPumpDown.Click, mnuRightPumpDown.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuPumpDown_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
    '        ' Run pumpdown Process.
    '        ' Enable and disables Lock Process Control buttons.
    '        Select Case ToolStripMenu.Name
    '            Case mnuMechinePumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuPumpDownOfCassettesPanel"), ONLINETM)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.PumpDown(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtTMVentPumpdownInProgress.Set()
    '                    Me.LockLoadARobotCassettes(False)
    '                    Me.LockLoadBRobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_TM.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start TM Pump down")
    '                End If
    '            Case mnuLeftPumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuPumpDownOfCassettesPanel"), ONLINELOADLOCKA)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.PumpDown(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtLLAVentPumpdownInProgress.Set()
    '                    Me.LockLoadARobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_LLA.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start LLA Pump down")
    '                End If
    '            Case mnuRightPumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuPumpDownOfCassettesPanel"), ONLINELOADLOCKB)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.PumpDown(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtLLBVentPumpdownInProgress.Set()
    '                    Me.LockLoadBRobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_LLB.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start LLB Pump down")
    '                End If
    '        End Select
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuPumpDown_Click")
    'End Sub
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on Stop pumb down menu item of machine (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuStopPumpDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechineStopPumpDown.Click, mnuLeftStopPumpDown.Click, mnuRightStopPumpDown.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuStopPumpDown_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)

    '        Select Case ToolStripMenu.Name
    '            Case mnuMechineStopPumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopPumpDownOfCassettesPanel"), ONLINETM)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.PumpDown(ToolStripMenu, STR_ON)
    '                    ' Reset Event
    '                    m_evtTMVentPumpdownInProgress.Reset()
    '                    Me.LockLoadARobotCassettes(True)
    '                    Me.LockLoadBRobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_TM.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop TM Pump down")
    '                End If
    '            Case mnuLeftStopPumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopPumpDownOfCassettesPanel"), ONLINELOADLOCKA)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    ' Me.PumpDown(ToolStripMenu, STR_ON)
    '                    ' Reset
    '                    m_evtLLAVentPumpdownInProgress.Reset()
    '                    Me.LockLoadARobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_LLA.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop LLA Pump down")
    '                End If
    '            Case mnuRightStopPumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopPumpDownOfCassettesPanel"), ONLINELOADLOCKB)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    '  Me.PumpDown(ToolStripMenu, STR_ON)
    '                    ' Reset Event
    '                    m_evtLLBVentPumpdownInProgress.Reset()
    '                    Me.LockLoadBRobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_LLB.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop LLB Pump down")
    '                End If
    '        End Select
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuStopPumpDown_Click")
    'End Sub
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on vent menu item of machine (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuVent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechineVent.Click, mnuLeftVent.Click, mnuRightVent.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuVent_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
    '        Select Case ToolStripMenu.Name
    '            Case mnuMechineVent.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuVentOfCassettesPanel"), ONLINETM)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.Vent(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtTMVentPumpdownInProgress.Set()
    '                    Me.LockLoadARobotCassettes(False)
    '                    Me.LockLoadBRobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_TM.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start TM Vent")
    '                End If
    '            Case mnuLeftVent.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuVentOfCassettesPanel"), ONLINELOADLOCKA)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.Vent(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtLLAVentPumpdownInProgress.Set()
    '                    Me.LockLoadARobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_LLA.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start LLA Vent")

    '                End If
    '            Case mnuRightVent.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuVentOfCassettesPanel"), ONLINELOADLOCKB)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.Vent(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtLLBVentPumpdownInProgress.Set()
    '                    Me.LockLoadBRobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_LLB.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start LLB Vent")

    '                End If
    '        End Select
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuVent_Click")
    'End Sub
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on stop vent menu item of machine (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuStopVent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechineStopVent.Click, mnuLeftStopVent.Click, mnuRightStopVent.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuStopVent_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
    '        'm_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '        'Me.Vent(ToolStripMenu, AVP_Robot_Project.ConstantAndEnum.STR_ON)
    '        Select Case ToolStripMenu.Name
    '            Case mnuMechineStopVent.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopVentOfCassettesPanel"), ONLINETM)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.Vent(ToolStripMenu, STR_ON)
    '                    ' Pulse Event
    '                    m_evtTMVentPumpdownInProgress.Reset()
    '                    Me.LockLoadARobotCassettes(True)
    '                    Me.LockLoadBRobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_TM.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop TM Vent")

    '                End If
    '            Case mnuLeftStopVent.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopVentOfCassettesPanel"), ONLINELOADLOCKA)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    ' Me.Vent(ToolStripMenu, STR_ON)
    '                    ' Pulse Event
    '                    m_evtLLAVentPumpdownInProgress.Reset()
    '                    Me.LockLoadARobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_LLA.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop LLA Vent")

    '                End If
    '            Case mnuRightStopVent.Name
    '                ' Pulse Event
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopVentOfCassettesPanel"), ONLINELOADLOCKB)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.Vent(ToolStripMenu, STR_ON)
    '                    m_evtLLBVentPumpdownInProgress.Reset()
    '                    Me.LockLoadBRobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_LLB.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop LLB Vent")

    '                End If
    '        End Select
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuStopVent_Click")
    'End Sub
#End Region
#End Region

#Region "Function Support"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' GetChamberName base on MesaValve  
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Function GetChamberName(ByVal MesaValveName As String, ByRef strChamber As String)
        Dim strChamberName As String = String.Empty
        Select Case MesaValveName
            Case MESA_VALVE_PM1
                strChamberName = AVPLib.RobotConfigurationValues.CHAMBER1_NAME
                strChamber = Equipments.Chamber1.ToString()
            Case MESA_VALVE_PM2
                strChamberName = AVPLib.RobotConfigurationValues.CHAMBER2_NAME
                strChamber = Equipments.Chamber2.ToString()
            Case MESA_VALVE_PM3
                strChamberName = AVPLib.RobotConfigurationValues.CHAMBER3_NAME
                strChamber = Equipments.Chamber3.ToString()
            Case MESA_VALVE_PM4
                strChamberName = AVPLib.RobotConfigurationValues.CHAMBER4_NAME
                strChamber = Equipments.Chamber4.ToString()
            Case MESA_VALVE_PM5
                strChamberName = AVPLib.RobotConfigurationValues.CHAMBER5_NAME
                strChamber = Equipments.Chamber5.ToString()
            Case MESA_VALVE_PM6
                strChamberName = AVPLib.RobotConfigurationValues.CHAMBER6_NAME
                strChamber = Equipments.Chamber6.ToString()
            Case MESA_VALVE_LLA, "HivacValveLLA"
                strChamberName = Equipments.LoadLockA.ToString()
                strChamber = Equipments.LoadLockA.ToString()
            Case MESA_VALVE_LLB, "HivacValveLLB"
                strChamberName = Equipments.LoadLockB.ToString()
                strChamber = Equipments.LoadLockB.ToString()
            Case "ibsHivacButton"
                strChamberName = Equipments.CassettesModule.ToString()
                strChamber = Equipments.CassettesModule.ToString()
        End Select
        Return strChamberName
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Set enable MesaValve (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub MechineValveStatus(ByVal blnEnnable)
        Try
            ibsHivacButton.Enabled = IsAllowEnable(Not blnEnnable)
            MesaValvePM1.Enabled = IsAllowEnable(Not blnEnnable)
            MesaValvePM2.Enabled = IsAllowEnable(Not blnEnnable)
            MesaValvePM3.Enabled = IsAllowEnable(Not blnEnnable)
            MesaValvePM4.Enabled = IsAllowEnable(Not blnEnnable)
            MesaValvePM5.Enabled = IsAllowEnable(Not blnEnnable)
            MesaValvePM6.Enabled = IsAllowEnable(Not blnEnnable)
            ValveVent.Enabled = IsAllowEnable(Not blnEnnable)
            ValveRough.Enabled = IsAllowEnable(Not blnEnnable)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Set enable MesaValve (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub LeftValveStatus(ByVal blnEnnable)
        Try
            MesaValveLLA.Enabled = IsAllowEnable(Not blnEnnable)
            HivacValveLLA.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLASlowVent.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLAFastVent.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLASlowRough.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLAFastRough.Enabled = IsAllowEnable(Not blnEnnable)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Set enable MesaValve (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub RightValveStatus(ByVal blnEnnable)
        Try
            MesaValveLLB.Enabled = IsAllowEnable(Not blnEnnable)
            HivacValveLLB.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLBSlowRough.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLBFastRough.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLBSlowVent.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLBFastVent.Enabled = IsAllowEnable(Not blnEnnable)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' PumpDown (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Sub PumpDown(ByVal isLLA As Boolean, ByVal isLLB As Boolean, ByVal isTM As Boolean, ByVal value As String)
        AVPLib.Log.guiLogger.Info("Enter PumpDown")
        Dim PropertyNames As New ArrayList()
        Dim ReplyValues As New ArrayList()

        PropertyNames.Add("PumpDownStatus")
        If value = STR_ON Then
            ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.On)
        Else
            ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)
        End If
        If isLLA Then
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstantAndEnum.LOAD_LOCK_A, PropertyNames, ReplyValues)
        ElseIf isLLB Then
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstantAndEnum.LOAD_LOCK_B, PropertyNames, ReplyValues)
        ElseIf isTM Then
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus("CassettesModule", PropertyNames, ReplyValues)
        End If

        AVPLib.Log.guiLogger.Info("Leave PumpDown")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Set Disable menu and invisible menu (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DisableOnline(ByVal ToolStripMenu As ToolStripMenuItem)
        AVPLib.Log.guiLogger.Info("Enter DisableOnline")
        If ToolStripMenu.Equals(mnuLeftOnline) Then
            Me.SetEnableMenuItemLeftTool(False, False, False, False, False, False)
            Me.SetVisibleMenuItemLeftTool(True, False, True, False, True, False)
        ElseIf ToolStripMenu.Equals(mnuMechineOnline) Then
            Me.SetVisibleMenuItemMechineTool(False, False, False, False, False, False)
            Me.SetVisibleMenuItemMechineTool(True, False, True, False, True, False)
        ElseIf ToolStripMenu.Equals(mnuRightOnline) Then
            Me.SetEnableMenuItemRightTool(False, False, False, False, False, False)
            Me.SetVisibleMenuItemRightTool(True, False, True, False, True, False)
        End If
        AVPLib.Log.guiLogger.Info("Leave DisableOnline")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Vent (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Sub Vent(ByVal isLLA As Boolean, ByVal isLLB As Boolean, ByVal isTM As Boolean, ByVal value As String)
        AVPLib.Log.guiLogger.Info("Enter Vent")
        Dim PropertyNames As New ArrayList()
        Dim ReplyValues As New ArrayList()

        PropertyNames.Add("AutoVentStatus")
        If value = STR_ON Then
            ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.On)
        Else
            ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)
        End If
        If isLLA Then
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstantAndEnum.LOAD_LOCK_A, PropertyNames, ReplyValues)
        ElseIf isLLB Then
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstantAndEnum.LOAD_LOCK_B, PropertyNames, ReplyValues)
        ElseIf isTM Then
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus("CassettesModule", PropertyNames, ReplyValues)
        End If

        AVPLib.Log.guiLogger.Info("Leave Vent")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' LockLoadARobotCassettes
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LockLoadARobotCassettes(ByVal blnEnableDisable As Boolean)
        If (blnEnableDisable) Then
            If (Not (Me.EvtTMVentPumpdownInProgress.WaitOne(0, False))) And (Not (Me.m_evtLLAVentPumpdownInProgress.WaitOne(0, False))) Then
                ContainerForm.ProcessPanel.lpcLoadLockA.Enabled = True
            End If
        Else
            ContainerForm.ProcessPanel.lpcLoadLockA.Enabled = False
        End If
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' LockLoadBRobotCassettes
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LockLoadBRobotCassettes(ByVal blnEnableDisable As Boolean)
        If (blnEnableDisable) Then
            If (Not (Me.EvtTMVentPumpdownInProgress.WaitOne(0, False))) And (Not (Me.m_evtLLBVentPumpdownInProgress.WaitOne(0, False))) Then
                ContainerForm.ProcessPanel.lpcLoadLockB.Enabled = True
            End If
        Else
            ContainerForm.ProcessPanel.lpcLoadLockB.Enabled = False
        End If
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' SetVisibleMenuItemMechineTool(from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SetVisibleMenuItemMechineTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean, _
     ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuMechineOnline.Visible = blnOnline
            mnuMechineOffline.Visible = blnOffline
            mnuMechineOffline.Tag = blnOffline
            mnuMechinePumpDown.Visible = blnPumpDown
            mnuMechineStopPumpDown.Visible = blnStopPumpDown
            mnuMechineVent.Visible = blnVent
            mnuMechineStopVent.Visible = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' show or hide menu item of left tool menu (from Transfer Screen)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetVisibleMenuItemLeftTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean, _
      ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuLeftOnline.Visible = blnOnline
            mnuLeftOffline.Visible = blnOffline
            mnuLeftOffline.Tag = blnOffline
            mnuLeftPumpDown.Visible = blnPumpDown
            mnuLeftStopPumpDown.Visible = blnStopPumpDown
            mnuLeftVent.Visible = blnVent
            mnuLeftStopVent.Visible = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' show or hide menu item of right tool menu (from Transfer Screen)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetVisibleMenuItemRightTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean, _
      ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuRightOnline.Visible = blnOnline
            mnuRightOffline.Visible = blnOffline
            mnuRightOffline.Tag = blnOffline
            mnuRightPumpDown.Visible = blnPumpDown
            mnuRightStopPumpDown.Visible = blnStopPumpDown
            mnuRightVent.Visible = blnVent
            mnuRightStopVent.Visible = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' enable or disable menu item of mechine tool menu (from Transfer Screen)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetEnableMenuItemMechineTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean, _
      ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuMechineOnline.Enabled = blnOnline
            mnuMechineOffline.Enabled = blnOffline
            mnuMechinePumpDown.Enabled = blnPumpDown
            mnuMechineStopPumpDown.Enabled = blnStopPumpDown
            mnuMechineVent.Enabled = blnVent
            mnuMechineStopVent.Enabled = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' enable or disable menu item of left tool menu (from Transfer Screen)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetEnableMenuItemLeftTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean, _
      ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuLeftOnline.Enabled = blnOnline
            mnuLeftOffline.Enabled = blnOffline
            mnuLeftPumpDown.Enabled = blnPumpDown
            mnuLeftStopPumpDown.Enabled = blnStopPumpDown
            mnuLeftVent.Enabled = blnVent
            mnuLeftStopVent.Enabled = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' enable or disable menu item of right tool menu (from Transfer Screen)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetEnableMenuItemRightTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean, _
      ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuRightOnline.Enabled = blnOnline
            mnuRightOffline.Enabled = blnOffline
            mnuRightPumpDown.Enabled = blnPumpDown
            mnuRightStopPumpDown.Enabled = blnStopPumpDown
            mnuRightVent.Enabled = blnVent
            mnuRightStopVent.Enabled = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub RoughPumpControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoughPumpControl.Click
        If lblRoughPumpInUse.Tag IsNot Nothing Then
            If Utils.ShowAVPMessageBox("Do you want to release Mechanical Pump resource? ", _
                                       "Release Rough Pump", MessageBoxIcon.Question, _
                                       MessageBoxButtons.YesNo) = DialogResult.OK Then
                m_stoStatusObject.RequestStatus("ReleaseRoughPumpInUse", lblRoughPumpInUse.Tag.ToString())
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                           "[Main Screen]" & " - Clicked on Rough Pump control to release Mechanical Pump resource")
            End If
        End If
    End Sub
    ''Notify to PVD Rough Pump is in used by ....
    Private Sub lblRoughPumpInUse_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRoughPumpInUse.TextChanged
        If ContainerForm.Chamber1Visible AndAlso ContainerForm.Chamber1Panel.ChamberType = SystemModule.ModuleType.PVD Then
            CType(ContainerForm.Chamber1Panel, PVDPanel).lblRoughPumpInUse.Text = lblRoughPumpInUse.Text
        End If
        If ContainerForm.Chamber2Visible AndAlso ContainerForm.Chamber2Panel.ChamberType = SystemModule.ModuleType.PVD Then
            CType(ContainerForm.Chamber2Panel, PVDPanel).lblRoughPumpInUse.Text = lblRoughPumpInUse.Text
        End If
        If ContainerForm.Chamber3Visible AndAlso ContainerForm.Chamber3Panel.ChamberType = SystemModule.ModuleType.PVD Then
            CType(ContainerForm.Chamber3Panel, PVDPanel).lblRoughPumpInUse.Text = lblRoughPumpInUse.Text
        End If
        If ContainerForm.Chamber4Visible AndAlso ContainerForm.Chamber4Panel.ChamberType = SystemModule.ModuleType.PVD Then
            CType(ContainerForm.Chamber4Panel, PVDPanel).lblRoughPumpInUse.Text = lblRoughPumpInUse.Text
        End If
        If ContainerForm.Chamber5Visible AndAlso ContainerForm.Chamber5Panel.ChamberType = SystemModule.ModuleType.PVD Then
            CType(ContainerForm.Chamber5Panel, PVDPanel).lblRoughPumpInUse.Text = lblRoughPumpInUse.Text
        End If
        If ContainerForm.Chamber6Visible AndAlso ContainerForm.Chamber6Panel.ChamberType = SystemModule.ModuleType.PVD Then
            CType(ContainerForm.Chamber6Panel, PVDPanel).lblRoughPumpInUse.Text = lblRoughPumpInUse.Text
        End If
    End Sub
#End Region

    Private Sub btnTMProtectedMode_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMProtectedMode.Click
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim strValue As String = String.Empty
            If button.Status = SL_CustomButton.DisplayStatus.Off Then
                strValue = STR_ON
            Else
                strValue = STR_OFF
            End If
            Dim Source As String = STR_IBE & "_" & STR_AVP & "." & "btnUnProtected" & "." & strValue
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[TM] " + button.Text + " Button: - Click ")
            If Utils.ShowAVPMessageBox(strMessageText, "TM", MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                If (m_TM_Protected_Mode Is Nothing) Then
                    m_TM_Protected_Mode = New TMProtectedMode(False, 100)
                ElseIf (m_TM_Protected_Mode.Status = ProtectedModStatus.Off) Then
                    m_TM_Protected_Mode.Status = ProtectedModStatus.On
                    m_TM_Protected_Mode.CurrentTime = 0
                    btnTMProtectedMode.Status = SL_CustomButton.DisplayStatus.On
                ElseIf (m_TM_Protected_Mode.Status = ProtectedModStatus.On) Then
                    m_TM_Protected_Mode.Status = ProtectedModStatus.Off
                    m_TM_Protected_Mode.CurrentTime = 0
                    btnTMProtectedMode.Status = SL_CustomButton.DisplayStatus.Off
                End If

                ' Update SECS/GEM variables by Hoa Nguyen
                ' Var Name: OverideModeOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, _
                                                    "OverideModeOnOff", VALUELib.ValueType.U1, btnTMProtectedMode.Status)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnCancleMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelMove.Click
        If String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) AndAlso String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then
            Utils.ShowAVPMessageBox("Nothing to cancel move.", "Cancel Move", MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)
            Exit Sub
        End If
        If Utils.ShowAVPMessageBox("Do you want to cancel move wafer?", "Cancel Move", MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then

            If Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) Then
                stwSemiautoTransferWafer.txtSource.Text = String.Empty
            End If
            If Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then
                stwSemiautoTransferWafer.txtDestination.Text = String.Empty
            End If
            'btnCancelMove.Enabled = False
            'btnCancelMove.Status = SL_CustomButton.DisplayStatus.Off
        End If

    End Sub

    'Private Sub btnCancleMove_OnChange()
    '    If Me.ISTM_ONLINE Then
    '        btnCancelMove.Enabled = False
    '        'btnCancelMove.Status = SL_CustomButton.DisplayStatus.Off
    '    Else
    '        If Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) AndAlso _
    '                               Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then
    '            btnCancelMove.Enabled = False
    '            btnCancelMove.ForeColor = Color.Gray
    '            'btnCancelMove.Status = SL_CustomButton.DisplayStatus.Off
    '        End If
    '        If String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) Or _
    '                                   String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then
    '            btnCancelMove.Enabled = True
    '            btnCancelMove.ForeColor = Color.Black
    '            'btnCancelMove.Status = SL_CustomButton.DisplayStatus.On
    '        End If
    '    End If
    'End Sub

End Class
