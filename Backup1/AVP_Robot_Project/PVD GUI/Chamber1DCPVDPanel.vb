Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Public Class Chamber1DCPVDPanel
#Region "Class Constants & Variables"
    Private TimeWait As Integer = 60
    Private TimeWaiting As Integer = 0
    Private ValveRingClicked As Boolean = False
    Private HivacValveStatus As String = BinaryStatusControl.DisplayStatus.Off.ToString()
    '''For Visible Equipment
    Const TITLE As String = ": MAINTENANCE"

#End Region


#Region "Public Methods"
    Public Overrides Property DCTargetPowerModel() As SystemModule.Power_Supply_Model
        Get
            Return MyBase.m_DCTargetPowerModel
        End Get
        Set(ByVal value As SystemModule.Power_Supply_Model)
            MyBase.m_DCTargetPowerModel = value
            If value = SystemModule.Power_Supply_Model.ENI_RPG_50_100 OrElse _
            value = SystemModule.Power_Supply_Model.ENI_RPG50 OrElse _
            value = SystemModule.Power_Supply_Model.ENI_RPG100 Then
                Me.DCTargetPowerSupply.bicDCPulse.Visible = True
                Me.DCTargetPowerSupply.Height = 170
                Me.DCTargetPowerSupply.Top = 12
            Else
                Me.DCTargetPowerSupply.bicDCPulse.Visible = False
            End If
            ''also hide textbox and label
            Me.DCTargetPowerSupply.txtTargetDCPulse.Visible = DCTargetPowerSupply.bicDCPulse.Visible
            DCTargetPowerSupply.lblDCPulse.Visible = DCTargetPowerSupply.bicDCPulse.Visible

            ''call reset type
            SetTypePVD()
        End Set
    End Property

    Public Overrides ReadOnly Property TargetPowerSupplyType() As AVPLib.SystemModule.PowerSupplyType
        Get
            Return AVPLib.SystemModule.PowerSupplyType.DC
        End Get
    End Property
#End Region

#Region "Protected method"
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
            m_stoStatusObject.Name = Me.Name
            MyBase.CreateStatusTree()
            m_stoStatusObject.AddChild(Me.DCTargetPowerSupply.Status)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Overrides Sub OnStartProcessing()
        MyBase.OnStartProcessing()
        Me.DCTargetPowerSupply.StartProcessing()
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Overrides Sub Online_OfflineValveStatus(ByVal blnStatus As Boolean, ByVal blnIsMenuOnlineClick As Boolean)
        MyBase.Online_OfflineValveStatus(blnStatus, blnIsMenuOnlineClick)
        Me.DCTargetPowerSupply.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        Me.DCTargetPowerSupply.IsOnline = DCTargetPowerSupply.IsOnline Or Not AVPLib.ContainerData.Permission(PERMISSION_001)
    End Sub
#End Region

#Region "Private method"
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Set Type of PVD
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub SetTypePVD()
        DCTargetPowerSupply.Top = 40
        DCTargetPowerSupply.MagnatronInstalled = MyBase.ManatronVisible
        If DCTargetPowerSupply.txtTargetDCPulse.Visible Then
            If MyBase.ManatronVisible Then
                Me.DCTargetPowerSupply.Height = 199
            Else
                Me.DCTargetPowerSupply.Height = 170
            End If
        Else
            If MyBase.ManatronVisible Then
                Me.DCTargetPowerSupply.Height = 170
            Else
                Me.DCTargetPowerSupply.Height = 145
            End If
        End If
        BiasPowerSupply.Top = DCTargetPowerSupply.Top + DCTargetPowerSupply.Height + 1
        ChamberInterlock.Top = BiasPowerSupply.Top + BiasPowerSupply.Height + 1
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-12-09</date>
    ''' </author>
    ''' <summary>
    ''' Active and InActive Form
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Active_InActiveForm(ByVal blnStatus As Boolean)
        Try
            MyBase.Active_InActiveForm(blnStatus)
           ' Me.DCTargetPowerSupply.Enabled = blnStatus
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
  
#End Region


    Public Sub New(ByVal ChamberName As String)
        MyBase.New(ChamberName)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Name = ChamberName
        Me.ButtonReConnectLocation = New Point(1181, 0)
        Me.ButtonTooltipMachineLocation = New Point(407, 334)
        Me.AlarmTextLocation = New Point(20, 50)
        Me.TitleTextLocation = New Point(0, 0)
        ' Add any initialization after the InitializeComponent() call.
        'Me.SetTypePVD()

    End Sub
End Class
