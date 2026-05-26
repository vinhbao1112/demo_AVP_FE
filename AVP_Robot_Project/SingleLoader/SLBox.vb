Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Imports System.ComponentModel

Public Class SLBox
#Region "Public Property"
    Private m_TypeOfIBEChamber As AVPLib.ConstEnum.AllChamberType

    Public Property TypeOfIBEChamber() As AVPLib.ConstEnum.AllChamberType
        Get
            Return m_TypeOfIBEChamber
        End Get
        Set(ByVal value As AVPLib.ConstEnum.AllChamberType)
            m_TypeOfIBEChamber = value
            If value = AllChamberType.VEECO_IBE Then
                lblT1.Visible = False
                txtT1.Visible = False
            ElseIf value = AllChamberType.AVP_IBE Then
                lblT1.Visible = True
                txtT1.Visible = True
            End If
        End Set
    End Property

    Private m_FullyInstalled As Boolean = True
    Public Property FullyInstalled() As Boolean
        Get
            Return m_FullyInstalled
        End Get
        Set(ByVal value As Boolean)
            m_FullyInstalled = value
            If value Then
                Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.SL_ProcessModel
                txtWaterPump.Visible = True
                txtT2.Visible = True
                txtT1.Visible = True
                ValveCryoHivac.Visible = True
                btnCryoOn.Visible = True
                lblT2.Visible = True
                lblT1.Visible = True
                btnCryoStatus.Visible = True
            Else
                Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.SL_ProcessModel_withoutAll
                txtWaterPump.Visible = False
                txtT1.Visible = False
                txtT2.Visible = False
                ValveCryoHivac.Visible = False
                btnCryoOn.Visible = False
                lblT1.Visible = False
                lblT2.Visible = False
                btnCryoStatus.Visible = False
            End If
        End Set
    End Property

    Private m_NoWaterPumpInstalled As Boolean = False
    Public Property NoWaterPumpInstalled() As Boolean
        Get
            Return m_NoWaterPumpInstalled
        End Get
        Set(ByVal value As Boolean)
            m_NoWaterPumpInstalled = value
            If value Then
                Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.SL_ProcessModel_withoutWP
                txtWaterPump.Visible = False
                txtT2.Visible = True
                txtT1.Visible = True
                ValveCryoHivac.Visible = True
                btnCryoOn.Visible = True
                lblT2.Visible = True
                lblT1.Visible = True
                btnCryoStatus.Visible = True
            End If
        End Set
    End Property

    Private m_NoCryoInstalled As Boolean = False
    Public Property NoCryoInstalled() As Boolean
        Get
            Return m_NoCryoInstalled
        End Get
        Set(ByVal value As Boolean)
            m_NoCryoInstalled = value
            If value Then
                Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.SL_ProcessModel_NoCryo
                txtT2.Visible = False
                txtT1.Visible = False
                ValveCryoHivac.Visible = False
                btnCryoOn.Visible = False
                lblT2.Visible = False
                lblT1.Visible = False
                btnCryoStatus.Visible = False
                txtWaterPump.Visible = True
            End If
        End Set
    End Property

    Private m_ShutterInstalled As Boolean = False
    Public Property ShutterInstalled() As Boolean
        Get
            Return m_ShutterInstalled
        End Get
        Set(ByVal value As Boolean)
            m_ShutterInstalled = value
            ShutterControl.Visible = value
        End Set
    End Property

#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbtCryoOn As New SL_StatusButton(btnCryoOn)
            Dim sbtCryoStatus As New SL_StatusButton(btnCryoStatus)
            Dim sbtWaterPumpOn As New SL_StatusButton(btnWaterPumpOn)
            'Dim sbtWaterPumpStatus As New SL_StatusButton(btnWaterPumpStatus)
            Dim sbtSlitValve As New SL_StatusButton(btnMesaValve)
            Dim slInternalShutter As New SL_StatusButton(stInternalShutter)
            Dim slInternalShutterOff As New SL_StatusButton(stInternalShutterOff)

            Dim stbWaterPump As New SL_StatusTextBox(txtWaterPump)
            Dim stbT2 As New SL_StatusTextBox(txtT2)
            Dim stbT1 As New SL_StatusTextBox(txtT1)
            Dim stbShutterStatus As New SL_StatusValve(Shutter)
            Dim stbPlasmaStatus As New SL_StatusValve(SourcePlasma)
            Dim sbtWafer As New SL_StatusIBEWafer(Wafer)
            Dim stbRampingPercent As New StatusLabel(txtRampingPercent)

            m_stoStatusObject.Name = Me.Name

            'Valve control'
            Dim svctTurboHivacValveStatus As New SL_StatusValve(ValveTurboHivac)
            Dim svctCryoHivacValveStatus As New SL_StatusValve(ValveCryoHivac)

            'Dim sbtTiltAtAngleSensor As New StatusLabel(lblTiltAtAngleSensor)
            Dim sbtTiltSensor As New SL_StatusButton(btnTiltSensor)

            m_stoStatusObject.AddChild(sbtCryoOn)
            m_stoStatusObject.AddChild(sbtCryoStatus)
            m_stoStatusObject.AddChild(sbtWaterPumpOn)
            'm_stoStatusObject.AddChild(sbtWaterPumpStatus)
            m_stoStatusObject.AddChild(sbtSlitValve)
            m_stoStatusObject.AddChild(stbWaterPump)
            m_stoStatusObject.AddChild(stbT1)
            m_stoStatusObject.AddChild(stbT2)
            m_stoStatusObject.AddChild(stbShutterStatus)
            m_stoStatusObject.AddChild(stbPlasmaStatus)
            m_stoStatusObject.AddChild(sbtWafer)

            m_stoStatusObject.AddChild(svctTurboHivacValveStatus)
            m_stoStatusObject.AddChild(svctCryoHivacValveStatus)

            'm_stoStatusObject.AddChild(sbtTiltAtAngleSensor)
            m_stoStatusObject.AddChild(sbtTiltSensor)

            m_stoStatusObject.AddChild(slInternalShutter)
            m_stoStatusObject.AddChild(slInternalShutterOff)
            m_stoStatusObject.AddChild(stbRampingPercent)


            txtWaterPump.ParentStatusObj = m_stoStatusObject
            ValveTurboHivac.ParentStatusObj = m_stoStatusObject
            ValveCryoHivac.ParentStatusObj = m_stoStatusObject
            Shutter.ParentStatusObj = m_stoStatusObject
            txtT2.ParentStatusObj = m_stoStatusObject
            txtT1.ParentStatusObj = m_stoStatusObject

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region


#Region "Private methods"

    Private Sub SLBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShowShutterOnFixture()
        ShowPlasma()
        '# '#07/25/2011 
        '# 'Hoa Nguyen add: Visible control Wafer. It is used to update wafer status but not show in GUI.
        Me.Wafer.Visible = False

        If Not Me.DesignMode Then
            Dim objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Name)
            Dim objSystemModule As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(objChamber.Name)
            If objSystemModule.VerifyTiltSensorAtPosition Then
                lblTiltAtAngleSensor.Visible = True
                btnTiltSensor.Visible = True
                lblTiltAtAngleSensor.Text_In_Label = "Tilt Sensor @" & objSystemModule.VerifiedAngle
            End If
        End If
    End Sub

    Private Sub ButtonPower_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnWaterPumpOn.Click
        SL_Support.ButtonClick(sender, Me.Name, m_stoStatusObject)
    End Sub

    Private Sub btnGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneral.Click
        Try
            Dim ibeParent As IBEPanel = ContainerForm.ChamberPanel(Me.Parent.Name) ''must be IBE Panel
            If ibeParent Is Nothing Then
                Exit Sub
            End If

            If ibeParent IsNot Nothing Then
                ibeParent.PopUpPanel.StartPosition = FormStartPosition.CenterScreen
                ibeParent.PopUpPanel.ShowDialog(ibeParent)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub Shutter_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Shutter.StatusChange
        ShutterControl.Status = Shutter.Status

        ShowShutterOnFixture()

        ShowPlasma()
    End Sub

    Private Sub SourcePlasma_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SourcePlasma.StatusChange
        ShowPlasma()
    End Sub

    Private Sub ShowPlasma()
        If RotationFixture.HasShutterOnFixture Then
            If SourcePlasma.Status = SL_ValveControl.DisplayStatus.On Then
                picBoxPlasma.Status = DisplayStatus.On
            Else
                picBoxPlasma.Status = DisplayStatus.Off
            End If
        Else
            If SourcePlasma.Status = SL_ValveControl.DisplayStatus.On AndAlso (Not ShutterControl.Visible OrElse Shutter.Status = SL_ValveControl.DisplayStatus.On) Then
                picBoxPlasma.Status = DisplayStatus.On
            Else
                picBoxPlasma.Status = DisplayStatus.Off
            End If
        End If

        ' Show/hide plasma
        If picBoxPlasma.Status = DisplayStatus.On Then
            picBoxPlasma.Visible = True
        Else
            picBoxPlasma.Visible = False
        End If
    End Sub

    Public Sub ShowShutterOnFixture()
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                RotationFixture.IsShutterOpen = (Shutter.Status = SL_ValveControl.DisplayStatus.On)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtT2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT2.Click, txtT1.Click, btnCryoOn.Click, btnCryoStatus.Click
        Try
            If m_TypeOfIBEChamber = AllChamberType.AVP_IBE Then
                If String.IsNullOrEmpty(Me.Parent.Name) = False Then
                    Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                    objIBEPanel.CryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                    objIBEPanel.CryoPopUpPanel.ShowDialog(AVPRobotMain)

                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Constructors & Dispose"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtT1.Cursor = Cursors.Hand
        txtT2.Cursor = Cursors.Hand
    End Sub
#End Region

#Region "Public methods"
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-02-22</date>
    ''' </author>
    ''' <summary>
    ''' Disable/Enable control when online/offline
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetOnlineOfflineContainerBox(ByVal blnIsOnline As Boolean)
        btnWaterPumpOn.Enabled = Not blnIsOnline
        ValveTurboHivac.Enabled = Not blnIsOnline
        ValveCryoHivac.Enabled = Not blnIsOnline
        Shutter.Enabled = Not blnIsOnline
        ShutterControl.Enabled = Not blnIsOnline
        RotationFixture.Enabled = Not blnIsOnline
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
        'All textbox    
        txtT2.Text = String.Empty
        txtT1.Text = String.Empty
        txtWaterPump.Text = String.Empty

        ValveTurboHivac.Status = SL_ValveControl.DisplayStatus.Off
        ValveCryoHivac.Status = SL_ValveControl.DisplayStatus.Off
        btnWaterPumpOn.Status = DisplayStatus.Off
        Shutter.Status = SL_ValveControl.DisplayStatus.Off
        ShutterControl.Status = AVPControls.AVPDataLib.DisplayStatus.Off
        btnCryoOn.Status = DisplayStatus.Off
        SourcePlasma.Status = SL_ValveControl.DisplayStatus.Off
    End Sub
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-09-29</date>
    ''' </author>
    ''' <summary>
    ''' Change Wafer Status in PM
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RotationFixture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotationFixture.Click
        Try
            Dim chamberName As String = Me.Parent.Name
            Dim equipment As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(chamberName)
            If equipment IsNot Nothing AndAlso equipment.WaferInfo IsNot Nothing Then
                Dim waferInfo As AVPLib.AVPWaferInfo = equipment.WaferInfo
                ' Create wafer dialog
                Dim isOnline As Boolean = (equipment.ControlStatus = AVPLib.DataManagerment.Equipment.ControlStatuses.ONLINE)
                Dim updateWafer As WaferInfoDlg = New WaferInfoDlg(waferInfo, True, isOnline)
                updateWafer.ShowDialog()
                'update the wafer infomation for the chamber
                Dim ChamberIndex As String = chamberName.Replace(ConstantAndEnum.CHAMBER, "")
                If (ChamberIndex <> String.Empty) Then
                    ContainerForm.CassettesPanel.SetWaferInside(AVPLib.ConstEnum.STR_UPDATE_WAFER, BinaryStatusControl.DisplayStatus.On, waferInfo, ChamberIndex)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-14</date>
    ''' </author>
    ''' <summary>
    ''' Do Shutter click event.
    ''' </summary>
    Private Sub ShutterControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutterControl.Click
        Shutter.PerformClick()
    End Sub
End Class
