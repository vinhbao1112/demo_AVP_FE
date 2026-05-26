Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Public Class WaferTransparent
#Region "Variables and properties"
    Private m_strChamberName As String = String.Empty
    Private m_blnPlasmaOn As Boolean = False
    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''    	<date> 20098-10-29</date>
    ''' </author>
    ''' <summary>
    ''' Get  Chamber Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ChamberName() As String
        Get
            Return m_strChamberName
        End Get
        Set(ByVal value As String)
            m_strChamberName = value
        End Set
    End Property
    Public Property PlasmaIsOn() As Boolean
        Get
            Return m_blnPlasmaOn
        End Get
        Set(ByVal value As Boolean)
            m_blnPlasmaOn = value
            Me.CirclePlasmaControlWafer.PlasmaOn = value
        End Set
    End Property
#End Region
    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''    	<date> 20098-10-29</date>
    ''' </author>
    ''' <summary>
    ''' Handle WaferTransparent_Click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub WaferTransparent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Try
            Dim chamber As AVPLib.SystemModule = Nothing
            Dim strChamberName As String = String.Empty
            If m_strChamberName = CHAMBER1 Then
                AVPRobotMain.tabMain.SelectedTab = AVPRobotMain.tabPM1
            ElseIf m_strChamberName = CHAMBER2 Then
                AVPRobotMain.tabMain.SelectedTab = AVPRobotMain.tabPM2
            ElseIf m_strChamberName = CHAMBER3 Then
                AVPRobotMain.tabMain.SelectedTab = AVPRobotMain.tabPM3
            End If
            AVPRobotMain.tabMain.BringToFront()
            AVPRobotMain.pnlPMConnection.BringToFront()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''    	<date> 20098-10-29</date>
    ''' </author>
    ''' <summary>
    ''' Handle click CirclePlasmaControlWafer_Click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CirclePlasmaControlWafer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CirclePlasmaControlWafer.Click
        AVPLib.Log.guiLogger.Info("Enter CirclePlasmaControlWafer_Click")
        Try
            Dim objchamber As AVPLib.DataManagerment.Chamber = Nothing
            Dim blResumed As Boolean = False
            If m_strChamberName = CHAMBER1 Then
                ProcessPanel.ClickedPosition = CLICKEDCHAMBER1
                objchamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
            ElseIf m_strChamberName = CHAMBER2 Then
                ProcessPanel.ClickedPosition = CLICKEDCHAMBER2
                objchamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
            ElseIf m_strChamberName = CHAMBER3 Then
                ProcessPanel.ClickedPosition = CLICKEDCHAMBER3
                objchamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
            End If

            If objchamber IsNot Nothing AndAlso objchamber.GetWaferInfo() IsNot Nothing Then
                Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
                avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(objchamber.GetWaferInfo().WaferID)
                Dim bShowReturnNow As Boolean = False
                If avpProcessJob IsNot Nothing Then
                    blResumed = avpProcessJob.IsPaused()
                    bShowReturnNow = avpProcessJob.IsJobOver()
                Else
                    bShowReturnNow = IIf(objchamber.IsProcessRunning, False, True)
                End If
                ShowContextMenuClickOnChamber(sender, blResumed, bShowReturnNow)
            ElseIf objchamber IsNot Nothing AndAlso objchamber.GetWaferInfo() Is Nothing Then
                WaferTransparent_Click(sender, e)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CirclePlasmaControlWafer_Click")
    End Sub
    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''    	<date> 20098-10-29</date>
    ''' </author>
    ''' <summary>
    ''' Display context menu when user click on circle plasma of Chamber
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowContextMenuClickOnChamber(ByVal sender As Object, ByVal blshowResume As Boolean, ByVal bShowReturnNow As Boolean)
        Try
            Dim cpcTemp As CirclePlasmaControl
            cpcTemp = CType(sender, CirclePlasmaControl)
            Dim pos As New System.Drawing.Point(cpcTemp.Location)
            pos.Y += cpcTemp.Height
            pos = Me.PointToScreen(pos)
            ContainerForm.ProcessPanel.mnuResume.Enabled = blshowResume
            ContainerForm.ProcessPanel.mnuReturn.Enabled = blshowResume
            ContainerForm.ProcessPanel.mnuReturnNow.Enabled = bShowReturnNow And (Not ContainerForm.ProcessPanel.IsButtonClearAllWaferClicked)
            ContainerForm.ProcessPanel.cmsChamber.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
     
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
