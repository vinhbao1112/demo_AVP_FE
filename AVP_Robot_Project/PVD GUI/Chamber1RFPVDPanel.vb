Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Public Class Chamber1RFPVDPanel
#Region "Class Constants & Variables"
    '''For Visible Equipment
    Const TITLE As String = "RFPVD: MAINTENANCE"

#End Region

#Region "Public Methods"
    Public Overrides ReadOnly Property TargetPowerSupplyType() As AVPLib.SystemModule.PowerSupplyType
        Get
            Return AVPLib.SystemModule.PowerSupplyType.RF
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
            m_stoStatusObject.AddChild(Me.RFTargetPowerSupply.Status)
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
        Me.RFTargetPowerSupply.StartProcessing()
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

        Me.RFTargetPowerSupply.IsOnline = Not IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, blnStatus)
        ''Add permission
        Me.RFTargetPowerSupply.IsOnline = RFTargetPowerSupply.IsOnline Or Not AVPLib.ContainerData.Permission(PERMISSION_001)
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
        '''''''''''''''''''''''''''''''''''''''''''
        Me.RFTargetPowerSupply.Left = 0
        Me.RFTargetPowerSupply.Top = lblChamberType.Top + 20
        Me.RFTargetPowerSupply.Height = 245
        Me.RFTargetPowerSupply.IsBiasPowerSupply = False
        Me.BiasPowerSupply.Left = 0
        Me.BiasPowerSupply.Top = RFTargetPowerSupply.Top + RFTargetPowerSupply.Height + 1
        Me.BiasPowerSupply.Height = 245
        Me.ChamberInterlock.Left = 0
        Me.ChamberInterlock.Top = BiasPowerSupply.Top + BiasPowerSupply.Height + 1
        ''run recipe panel is fixed
        ''gas controller panel is fixed
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
            'Me.RFTargetPowerSupply.Enabled = blnStatus
         
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
  
#End Region

#Region "Events – Buttons – Forms…"
#End Region


    Public Sub New(ByVal ChamberName As String)

        ' This call is required by the Windows Form Designer.
        MyBase.New(ChamberName)
        InitializeComponent()
        Me.Name = ChamberName
        Me.ButtonReConnectLocation = New Point(1181, 0)
        Me.ButtonTooltipMachineLocation = New Point(407, 334)
        Me.AlarmTextLocation = New Point(20, 50)
        Me.TitleTextLocation = New Point(0, 0)
        ' Add any initialization after the InitializeComponent() call.
        Me.SetTypePVD()
    End Sub
End Class
