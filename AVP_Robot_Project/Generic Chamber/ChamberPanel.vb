Imports AVPLib.ConstEnum

Public Class ChamberPanel
    Private m_strTitleText As String = String.Empty
    Private m_strStatusText As String = String.Empty
    Private m_strAlarmText As String = String.Empty
    Private m_TitleTextLocation As Point = Nothing
    Private m_StatusTextLocation As Point = Nothing
    Private m_AlarmTextLocation As Point = Nothing
    Private m_btnReConnectLocation As Point = Nothing
    Private m_btnTooltipMachineLocation As Point = Nothing
    Private m_ChamberType As AVPLib.SystemModule.ModuleType = AVPLib.SystemModule.ModuleType.IBE
    Private m_isblnOnline As Boolean = False
    Private m_dblROR_Litter_Value As Double = 0
    Private m_isblnConnect As Boolean = False
    Protected m_IsMaintenanceMode As Boolean = False
    Protected m_IsEditable_InMaintenanceMode As Boolean = False
    Protected m_IsProtectedMode As Boolean = False
    Protected m_slitValveStatus As SlitValve.SlitValveDisplayStatus = SlitValve.SlitValveDisplayStatus.Unknown

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the value indicates SlitValve status of chamber
    ''' </summary>
    Public Property SlitValveStatus() As SlitValve.SlitValveDisplayStatus
        Get
            Return m_slitValveStatus
        End Get
        Set(ByVal value As SlitValve.SlitValveDisplayStatus)
            If m_slitValveStatus <> value Then
                m_slitValveStatus = value

                ' Calc this function to set status to control
                SetSlitValveStatus()
            End If
        End Set
    End Property

    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbcConnectionStatus As New StatusIGCGButton(btnReConnect)
            '''
            Dim sTooltipMachineOnline As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineOnline)
            Dim sTooltipMachinePumpDown As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachinePumpDown)
            Dim sTooltipMachineVent As New StatusToolStripMenuItemChamber3TextChanged(Me.mnuMachineVent)
            Dim srbStatus As New StatusLabel(lblStatusText)
            Dim stbShieldQuart As New StatusTextBox(txtShieldQuart)

            'm_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sbcConnectionStatus)
            m_stoStatusObject.AddChild(sTooltipMachineOnline)
            m_stoStatusObject.AddChild(sTooltipMachinePumpDown)
            m_stoStatusObject.AddChild(sTooltipMachineVent)
            m_stoStatusObject.AddChild(srbStatus)
            m_stoStatusObject.AddChild(stbShieldQuart)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    Public ReadOnly Property IsProtectedMode() As Boolean
        Get
            Return m_IsProtectedMode
        End Get
    End Property

    Public Property IsMaintenanceMode() As Boolean
        Get
            Return m_IsMaintenanceMode
        End Get
        Set(ByVal value As Boolean)
            m_IsMaintenanceMode = value
        End Set
    End Property

    Public Property IsEditable_InMaintenanceMode() As Boolean
        Get
            Return m_IsEditable_InMaintenanceMode
        End Get
        Set(ByVal value As Boolean)
            m_IsEditable_InMaintenanceMode = value
        End Set
    End Property

    Public Property ROR_Litter_Value() As Double
        Get
            Return m_dblROR_Litter_Value
        End Get
        Set(ByVal value As Double)
            m_dblROR_Litter_Value = value
        End Set
    End Property

    Public Property ChamberType() As AVPLib.SystemModule.ModuleType
        Get
            Return m_ChamberType
        End Get
        Set(ByVal value As AVPLib.SystemModule.ModuleType)
            m_ChamberType = value
        End Set
    End Property

    Public Overridable ReadOnly Property TargetPowerSupplyType() As AVPLib.SystemModule.PowerSupplyType
        Get
            Return AVPLib.SystemModule.PowerSupplyType.DC
        End Get
    End Property

    Public Property TitleText() As String
        Get
            Return m_strTitleText
        End Get
        Set(ByVal value As String)
            m_strTitleText = value
            Me.LabTitle.Text = m_strTitleText
        End Set
    End Property

    Public Property StatusText() As String
        Get
            Return m_strStatusText
        End Get
        Set(ByVal value As String)
            m_strStatusText = value
            Me.lblStatusText.Text = m_strStatusText
        End Set
    End Property

    Public Property AlarmText() As String
        Get
            Return m_strAlarmText
        End Get
        Set(ByVal value As String)
            m_strAlarmText = value
        End Set
    End Property

    Public Property TitleTextLocation() As Point
        Get
            Return m_TitleTextLocation
        End Get
        Set(ByVal value As Point)
            m_TitleTextLocation = value
        End Set
    End Property

    Public Property StatusTextLocation() As Point
        Get
            Return m_StatusTextLocation
        End Get
        Set(ByVal value As Point)
            m_StatusTextLocation = value
            Me.lblStatusText.Location = m_StatusTextLocation
        End Set
    End Property

    Public Property AlarmTextLocation() As Point
        Get
            Return m_AlarmTextLocation
        End Get
        Set(ByVal value As Point)
            m_AlarmTextLocation = value
        End Set
    End Property

    Public Property ButtonReConnectLocation() As Point
        Get
            Return m_btnReConnectLocation
        End Get
        Set(ByVal value As Point)
            m_btnReConnectLocation = value
        End Set
    End Property

    Public Property ButtonTooltipMachineLocation() As Point
        Get
            Return m_btnTooltipMachineLocation
        End Get
        Set(ByVal value As Point)
            m_btnTooltipMachineLocation = value
        End Set
    End Property

   Public Property IsOnline() As Boolean
        Get
            Return m_isblnOnline
        End Get
        Set(ByVal value As Boolean)
            m_isblnOnline = value
        End Set
    End Property

    Public ReadOnly Property IsConnect() As Boolean
        Get
            Dim objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
            If objChamber Is Nothing Then
                Return False
            End If
            Return (objChamber.ConnectionStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
        End Get
    End Property

    Protected Overridable Sub btnTooltipMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTooltipMachine.Click

    End Sub
    Public Overridable Sub CheckPermission(ByVal PERMISSION_Code As String)

    End Sub

    ' Dat Vo added
    Public Overridable Sub GoOnline(ByVal blnThrowAlarm As Boolean)
        'm_stoStatusObject.RequestStatus(mnuMachineOnline.Name, STR_ON)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.lblStatusText.Dock = DockStyle.Bottom
        Me.lblStatusText.TextAlign = ContentAlignment.BottomLeft
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Friend Overridable Sub btnReConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReConnect.Click
        AVPLib.Log.guiLogger.Info("Enter btnReConnect_Click")
        Try
            If Me.btnReConnect.Status = DisplayStatus.Off Then
                Dim strChamber As String = AVPLib.Utils.chamberID2ChamberName(Me.Name)
                btnReConnect.Enabled = False
                btnReConnect.Status = DisplayStatus.Unknow
                m_stoStatusObject.RequestStatus(Me.btnReConnect.Name, STR_ON)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnReConnect_Click")
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Panel must implement to set SlitValve status when SlitValveStatus changed
    ''' </summary>
    Protected Overridable Sub SetSlitValveStatus()
        ' Childrens set SlitValve status to control
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Set default status on load
    ''' </summary>
    Private Sub ChamberPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetSlitValveStatus()
    End Sub
End Class
