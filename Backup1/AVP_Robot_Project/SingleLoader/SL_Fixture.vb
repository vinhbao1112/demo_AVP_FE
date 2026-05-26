Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Public Class SL_Fixture
#Region "Const and Variable"
    Const LOCATION_CLAMP_SWEEP_MODE As Integer = 221
    Const LOCATION_CLAMP_OTHER_MODE As Integer = 188
    Const ROTATION_START As String = "Rotation Start"
    Const ROTATION_RPM As String = "Rotation(RPM)"
    Const ROTATION_ANGLE As String = "Rotation Angle"
    Const TILT_START As String = "Tilt Start"
    Const TILT_ANGLE As String = "Tilt Angle"
    Private m_LocationRotationRight As Point = New Point(259, 133)
    Private m_LocationRotationLeft As Point = New Point(154, 133)
    Public IsWaitingForMovingComplete As Boolean = False
    'Private m_blnIsOnline As Boolean = False
    Private m_blnFixtureAngleAtLoadState As Boolean = True
Public Event FlowcoolStatusChange(ByVal sender As Object, ByVal e As EventArgs)

#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtFlowCoolGasRight.Enabled = Not m_blnIsOnline
            txtTiltAngleRight.Enabled = Not m_blnIsOnline
            txtRotationEnd.Enabled = Not m_blnIsOnline
            txtRotationStaticRight.Enabled = Not m_blnIsOnline
            txtRotationSweepRight.Enabled = Not m_blnIsOnline
            txtRotationContinuousRight.Enabled = Not m_blnIsOnline

            ValveShutoffFlowCoolGas.Enabled = Not m_blnIsOnline
            ValveSupplyFlowCoolGas.Enabled = Not m_blnIsOnline
            btnOpenCloseFlowCoolGas.Enabled = Not m_blnIsOnline
            btnFlowCoolPump.Enabled = Not m_blnIsOnline
            btnMode.Enabled = Not m_blnIsOnline
            btnClampUp.Enabled = Not m_blnIsOnline
            btnClampDown.Enabled = Not m_blnIsOnline
            btnShutterOpen.Enabled = Not m_blnIsOnline
            btnShutterClose.Enabled = Not m_blnIsOnline
            btnRotate.Enabled = Not m_blnIsOnline
            btnMotionInitialized.Enabled = Not m_blnIsOnline
            txtTiltEnd.Enabled = Not m_blnIsOnline
            txtTiltSweepRight.Enabled = Not m_blnIsOnline
            btnTilt.Enabled = (Not m_blnIsOnline) And cbTiltMode.Checked
        End Set
    End Property

    Public Property FixtureAngleAtLoadState() As Boolean
        Get
            Return m_blnFixtureAngleAtLoadState
        End Get
        Set(ByVal value As Boolean)
            m_blnFixtureAngleAtLoadState = value
        End Set
    End Property

    Private m_TypeOfIBEChamber As AVPLib.ConstEnum.AllChamberType
    Public Property TypeOfIBEChamber() As AVPLib.ConstEnum.AllChamberType
        Get
            Return m_TypeOfIBEChamber
        End Get
        Set(ByVal value As AVPLib.ConstEnum.AllChamberType)
            m_TypeOfIBEChamber = value
            If value = AllChamberType.AVP_IBE Then
                btnOpenCloseFlowCoolGas.Visible = False

            End If
        End Set
    End Property
#End Region
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
            Dim stbGasLeft As New SL_StatusTextBox(Me.txtFlowCoolGas)
            Dim stbGasRight As New SL_StatusTextBox(Me.txtFlowCoolGasRight)
            Dim stbRotationMode As New SL_StatusTextBox(Me.txtRotationMode)
            Dim stbTiltAngleLeft As New SL_StatusTextBox(Me.txtTiltAngleLeft)
            Dim stbTiltAngleRight As New SL_StatusTextBox(Me.txtTiltAngleRight)
            Dim sbcValveShutoffStatus As New StatusBinaryStatusControl(ValveShutoffFlowCoolGas)
            Dim sbcValveSupplyStatus As New StatusBinaryStatusControl(ValveSupplyFlowCoolGas)
            Dim sbtMode As New SL_StatusButton(btnMode)
            Dim sbtClamp As New SL_StatusButton(btnClampDown)
            Dim sbtFlowCoolPumpStatus As New SL_StatusButton(btnFlowCoolPump)
            Dim sbtMotionInitializedStatus As New SL_StatusButton(btnMotionInitialized)
            Dim sbtMotionInitializingStatus As New SL_StatusButton(slMotionInitializingStatus)
            Dim sbtShutterOpenStatus As New SL_StatusButton(btnShutterOpen)
            Dim sbtShutterCloseStatus As New SL_StatusButton(btnShutterClose)
            Dim sbtRotateStatus As New SL_StatusButton(btnRotate)

            Dim stbRotationStaticLeft As New SL_StatusTextBox(Me.txtRotationStaticLeft)
            Dim stbRotationStaticRight As New SL_StatusTextBox(Me.txtRotationStaticRight)
            Dim stbRotationSweepLeft As New SL_StatusTextBox(Me.txtRotationSweepLeft)
            Dim stbRotationSweepRight As New SL_StatusTextBox(Me.txtRotationSweepRight)
            Dim stbRotationSweepAngle As New SL_StatusTextBox(txtRotationSweepAngleReadback)
            Dim stbRotationContinuousLeft As New SL_StatusTextBox(Me.txtRotationContinuousLeft)
            Dim stbRotationContinuousRight As New SL_StatusTextBox(Me.txtRotationContinuousRight)
            Dim stbRotationEnd As New SL_StatusTextBox(Me.txtRotationEnd)

            Dim slHomeTilt As New SL_FourStatusControl(Me.stHomeTilt)
            Dim slHomeRotation As New SL_FourStatusControl(Me.stHomeRotation)
            Dim slStartRotation As New SL_FourStatusControl(Me.stStartRotation)
            Dim slTiltMovingStatus As New SL_FourStatusControl(Me.stTiltMoving)
            Dim slTiltErrorStatus As New SL_FourStatusControl(Me.stTiltError)
            Dim slRotationErrorStatus As New SL_FourStatusControl(Me.stRotationError)

            Dim stbtTiltMode As New SL_StatusTextBox(Me.txtTiltMode)
            Dim sltTiltEnd As New SL_StatusTextBox(Me.txtTiltEnd)
            Dim sltTiltSweepRight As New SL_StatusTextBox(Me.txtTiltSweepRight)
            Dim sbtTiltRotationMode As New SL_StatusButton(btnTilt)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sbtClamp)
            m_stoStatusObject.AddChild(slHomeTilt)
            m_stoStatusObject.AddChild(slHomeRotation)
            m_stoStatusObject.AddChild(slStartRotation)
            m_stoStatusObject.AddChild(slTiltMovingStatus)
            m_stoStatusObject.AddChild(slTiltErrorStatus)
            m_stoStatusObject.AddChild(slRotationErrorStatus)

            m_stoStatusObject.AddChild(stbGasLeft)
            m_stoStatusObject.AddChild(stbGasRight)
            m_stoStatusObject.AddChild(stbRotationMode)
            m_stoStatusObject.AddChild(stbTiltAngleLeft)
            m_stoStatusObject.AddChild(stbTiltAngleRight)
            m_stoStatusObject.AddChild(sbcValveShutoffStatus)
            m_stoStatusObject.AddChild(sbcValveSupplyStatus)
            m_stoStatusObject.AddChild(sbtMode)

            m_stoStatusObject.AddChild(stbRotationStaticLeft)
            m_stoStatusObject.AddChild(stbRotationStaticRight)
            m_stoStatusObject.AddChild(stbRotationSweepLeft)
            m_stoStatusObject.AddChild(stbRotationSweepRight)
            m_stoStatusObject.AddChild(stbRotationSweepAngle)
            m_stoStatusObject.AddChild(stbRotationContinuousLeft)
            m_stoStatusObject.AddChild(stbRotationContinuousRight)
            m_stoStatusObject.AddChild(stbRotationEnd)
            m_stoStatusObject.AddChild(sbtFlowCoolPumpStatus)
            m_stoStatusObject.AddChild(sbtMotionInitializedStatus)
            m_stoStatusObject.AddChild(sbtMotionInitializingStatus)
            m_stoStatusObject.AddChild(sbtShutterOpenStatus)
            m_stoStatusObject.AddChild(sbtShutterCloseStatus)
            m_stoStatusObject.AddChild(sbtRotateStatus)

            m_stoStatusObject.AddChild(stbtTiltMode)
            m_stoStatusObject.AddChild(sltTiltEnd)
            m_stoStatusObject.AddChild(sltTiltSweepRight)
            m_stoStatusObject.AddChild(sbtTiltRotationMode)

            btnClampDown.ParentStatusObj = m_stoStatusObject
            txtFlowCoolGas.ParentStatusObj = m_stoStatusObject
            txtFlowCoolGasRight.ParentStatusObj = m_stoStatusObject
            txtRotationMode.ParentStatusObj = m_stoStatusObject
            txtTiltAngleLeft.ParentStatusObj = m_stoStatusObject
            txtTiltAngleRight.ParentStatusObj = m_stoStatusObject

            txtRotationEnd.ParentStatusObj = m_stoStatusObject
            txtRotationStaticLeft.ParentStatusObj = m_stoStatusObject
            txtRotationStaticRight.ParentStatusObj = m_stoStatusObject
            txtRotationSweepLeft.ParentStatusObj = m_stoStatusObject
            txtRotationSweepRight.ParentStatusObj = m_stoStatusObject
            txtRotationContinuousLeft.ParentStatusObj = m_stoStatusObject
            txtRotationContinuousRight.ParentStatusObj = m_stoStatusObject
            btnFlowCoolPump.ParentStatusObj = m_stoStatusObject
            btnMotionInitialized.ParentStatusObj = m_stoStatusObject
            slMotionInitializingStatus.ParentStatusObj = m_stoStatusObject
            btnShutterOpen.ParentStatusObj = m_stoStatusObject
            btnShutterClose.ParentStatusObj = m_stoStatusObject
            btnRotate.ParentStatusObj = m_stoStatusObject
            btnMode.ParentStatusObj = m_stoStatusObject

            txtTiltEnd.ParentStatusObj = m_stoStatusObject
            txtTiltSweepRight.ParentStatusObj = m_stoStatusObject
            txtTiltMode.ParentStatusObj = m_stoStatusObject
            btnTilt.ParentStatusObj = m_stoStatusObject

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        txtRotationStaticLeft.Location = m_LocationRotationLeft
        txtRotationStaticRight.Location = m_LocationRotationRight
        txtRotationSweepLeft.Location = m_LocationRotationLeft
        txtRotationSweepRight.Location = m_LocationRotationRight
        txtRotationContinuousLeft.Location = m_LocationRotationLeft
        txtRotationContinuousRight.Location = m_LocationRotationRight
        txtTiltMode.Text = FixtureMode.Static.ToString()

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
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
     Handles ValveShutoffFlowCoolGas.Click, ValveSupplyFlowCoolGas.Click
        Dim ValveCtl As ValveControl = CType(sender, ValveControl)
        Dim strTitleMessage As String = String.Empty
        strTitleMessage = AVPLib.Utils.chamberID2ChamberName(m_stoStatusObject.Name)
        If String.IsNullOrEmpty(strTitleMessage) OrElse Not m_stoStatusObject.Name.StartsWith(AVPLib.ConstEnum.Chamber) Then
            strTitleMessage = AVPLib.Utils.chamberID2ChamberName(m_stoStatusObject.Parent.Name)
        End If
        SL_Support.ValveClick(sender, e, strTitleMessage, ValveCtl.Name, m_stoStatusObject)
    End Sub

    Private Sub FixtureButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClampDown.Click, btnClampUp.Click
        Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
        Dim messageLog As String = "[" + AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name) + "] " + button.Text + " Button: - Click "
        SL_Support.NormalButtonClick(messageLog, sender, Me.Name, m_stoStatusObject)
    End Sub

    Private Sub btnMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMode.Click
        If txtRotationMode.Text = FixtureMode.Static.ToString() Then
            LoadingHomeMode()
        ElseIf txtRotationMode.Text = FixtureMode.Sweep.ToString() Then
            LoadingStaticMode()
        ElseIf txtRotationMode.Text = FixtureMode.Continuous.ToString() Then
            LoadingSweepMode()
        ElseIf txtRotationMode.Text = FixtureMode.Home.ToString() Then
            LoadingContinuousMode()
        End If
        '  m_stoStatusObject.RequestStatus(btnMode.Name, txtRotationMode.Text)
        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                               "[" & AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name) & "] User Change Mode to " & txtRotationMode.Text)
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-04-17</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtTiltMode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTiltMode.TextChanged

        Try
            If txtTiltMode.Text = FixtureMode.Static.ToString() Then
                cbTiltMode.Checked = False
                LoadingStaticTiltMode()
            Else
                cbTiltMode.Checked = True
                LoadingSweepTiltMode()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub FixtureButtonChangeStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFlowCoolPump.Click, btnMotionInitialized.Click
        SL_Support.ButtonClick(sender, Me.Name, m_stoStatusObject)
    End Sub

    Private Sub SL_Fixture_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnShutterOpen.ValueToBeSend = STR_ON
        btnShutterClose.ValueToBeSend = STR_OFF
        LoadingHomeMode()
    End Sub

    Public Sub LoadingStaticMode()
        txtRotationSweepLeft.Visible = False
        txtRotationSweepRight.Visible = False
        txtRotationContinuousLeft.Visible = False
        txtRotationContinuousRight.Visible = False
        txtRotationSweepAngleReadback.Visible = False
        txtRotationMode.Text = FixtureMode.Static.ToString()
        txtRotationEnd.Visible = False

        txtRotationStaticLeft.Visible = True
        txtRotationStaticRight.Visible = True
        lblEnd.Visible = txtTiltEnd.Visible Or txtRotationEnd.Visible
        Label1.Visible = lblEnd.Visible
    End Sub

    Public Sub LoadingSweepMode()
        txtRotationStaticLeft.Visible = False
        txtRotationStaticRight.Visible = False
        txtRotationContinuousLeft.Visible = False
        txtRotationContinuousRight.Visible = False

        txtRotationMode.Text = FixtureMode.Sweep.ToString()
        Label3.Text = "Rotation Angle"
        txtRotationEnd.Visible = True
        'new
        txtRotationSweepAngleReadback.Visible = True

        txtRotationSweepLeft.Visible = False
        txtRotationSweepRight.Visible = True
        lblEnd.Visible = txtTiltEnd.Visible Or txtRotationEnd.Visible
        Label1.Visible = lblEnd.Visible
    End Sub

    Public Sub LoadingContinuousMode()
        txtRotationStaticLeft.Visible = False
        txtRotationStaticRight.Visible = False
        txtRotationSweepLeft.Visible = False
        txtRotationSweepRight.Visible = False
        txtRotationSweepAngleReadback.Visible = False
        txtRotationMode.Text = FixtureMode.Continuous.ToString()
        Label3.Text = "Rotation(RPM)"
        txtRotationEnd.Visible = False

        txtRotationContinuousLeft.Visible = True
        txtRotationContinuousRight.Visible = True
        lblEnd.Visible = txtTiltEnd.Visible Or txtRotationEnd.Visible
        Label1.Visible = lblEnd.Visible
    End Sub

    Public Sub LoadingHomeMode()
        txtRotationContinuousLeft.Visible = False
        txtRotationContinuousRight.Visible = False
        txtRotationStaticLeft.Visible = False
        txtRotationStaticRight.Visible = False
        txtRotationSweepLeft.Visible = False
        txtRotationSweepRight.Visible = False
        txtRotationSweepAngleReadback.Visible = False
        txtRotationMode.Text = FixtureMode.Home.ToString()
        txtRotationEnd.Visible = False
        lblEnd.Visible = txtTiltEnd.Visible Or txtRotationEnd.Visible
        Label1.Visible = lblEnd.Visible
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-04-12</date>
    ''' </author>
    ''' <summary>
    ''' Load sweep tilt mode.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoadingSweepTiltMode()
        txtTiltAngleRight.Visible = False
        txtTiltSweepRight.Location = txtTiltAngleRight.Location
        txtTiltSweepRight.Visible = True
        lblEnd.Visible = True
        Label1.Visible = lblEnd.Visible
        txtTiltEnd.Visible = True
        btnTilt.Enabled = Not m_blnIsOnline
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-04-12</date>
    ''' </author>
    ''' <summary>
    ''' Load static tilt mode.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoadingStaticTiltMode()
        txtTiltSweepRight.Visible = False
        txtTiltAngleRight.Visible = True
        txtTiltEnd.Visible = False
        btnTilt.Enabled = False
        lblEnd.Visible = txtTiltEnd.Visible Or txtRotationEnd.Visible
        Label1.Visible = lblEnd.Visible
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-04-12</date>
    ''' </author>
    ''' <summary>
    ''' Load static tilt angle.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub LoadingStaticTiltAngle()

        txtTiltMode.Text = FixtureMode.Static.ToString()
        btnTilt.Visible = False
        cbTiltMode.Visible = False
        txtTiltEnd.Visible = False
        txtTiltSweepRight.Visible = False
        btnFlowCoolPump.Location = New Point(336, 34)
    End Sub

    Private Sub btnRotate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotate.Click
        Try
            Dim strValue As String = txtRotationMode.Text

            'Case button Rotate with mode Home of Fixture
            Dim Source As String = STR_IBE & "." & Me.Name & "." & btnRotate.Name & "."
            If btnRotate.Status = SL_CustomButton.DisplayStatus.On Then
                Source = Source & STR_OFF
                strValue = STR_OFF
            Else
                If txtRotationMode.Text = FixtureMode.Home.ToString() Then
                    Source = Source & "Home"
                ElseIf txtRotationMode.Text = FixtureMode.Sweep.ToString() Then
                    Source = Source & "Sweep"
                ElseIf txtRotationMode.Text = FixtureMode.Continuous.ToString() Then
                    Source = Source & "Continuous"
                ElseIf txtRotationMode.Text = FixtureMode.Static.ToString() Then
                    Source = Source & "Static"
                Else
                    Source = Source & STR_OTHER
                End If
                End If
                Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, Utils.FormatLogMessage(AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name), btnRotate))
            If Utils.ShowAVPMessageBox(strMessageText, AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name), MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                m_stoStatusObject.RequestStatus(btnMode.Name, strValue)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-04-12</date>
    ''' </author>
    ''' <summary>
    ''' Handler event tilt.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnTilt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTilt.Click
        Try
            Dim strValue As String = txtTiltMode.Text

            'Case button Rotate with mode Home of Fixture
            Dim Source As String = STR_IBE & "." & Me.Name & "." & btnTilt.Name & "."
            If btnTilt.Status = SL_CustomButton.DisplayStatus.On Then
                Source = Source & STR_OFF
                strValue = STR_OFF
            Else
                If txtTiltMode.Text = FixtureMode.Sweep.ToString() Then
                    Source = Source & "Sweep"
                ElseIf txtTiltMode.Text = FixtureMode.Static.ToString() Then
                    Source = Source & "Static"
                Else
                    Source = Source & STR_OTHER
                End If
            End If
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, Utils.FormatLogMessage(AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name), btnTilt))
            If Utils.ShowAVPMessageBox(strMessageText, AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name), MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                If txtTiltMode.Text = FixtureMode.Sweep.ToString() Then
                    If btnTilt.Status = SL_CustomButton.DisplayStatus.Off Then
                        m_stoStatusObject.RequestStatus(btnTilt.Name, "04")
                    Else
                        m_stoStatusObject.RequestStatus(btnTilt.Name, "0")
                    End If
                Else
                    m_stoStatusObject.RequestStatus(txtTiltAngleRight.Name, txtTiltAngleRight.Text.ToString())
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-05-23</date>
    ''' </author>
    ''' <summary>
    ''' Event cbTiltMode check.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbTiltMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTiltMode.CheckedChanged
        Try
            If cbTiltMode.Checked = True Then
                txtTiltMode.Text = FixtureMode.Sweep.ToString()
            Else
                txtTiltMode.Text = FixtureMode.Static.ToString()
            End If
            '  m_stoStatusObject.RequestStatus(btnMode.Name, txtRotationMode.Text)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   "[" & AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name) & "] User Change Mode to " & txtTiltMode.Text)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Public methods"
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
        txtFlowCoolGas.Text = String.Empty
        txtFlowCoolGasRight.Text = String.Empty
        txtTiltAngleLeft.Text = String.Empty
        txtTiltAngleRight.Text = String.Empty
        txtRotationMode.Text = String.Empty
        txtRotationContinuousLeft.Text = String.Empty
        txtRotationContinuousRight.Text = String.Empty
        txtRotationStaticLeft.Text = String.Empty
        txtRotationStaticRight.Text = String.Empty
        txtRotationSweepLeft.Text = String.Empty
        txtRotationSweepRight.Text = String.Empty
        txtRotationEnd.Text = String.Empty
 
        ValveShutoffFlowCoolGas.Status = BinaryStatusControl.DisplayStatus.Off
        ValveSupplyFlowCoolGas.Status = BinaryStatusControl.DisplayStatus.Off
        btnFlowCoolPump.Status = SL_CustomButton.DisplayStatus.Off
        LoadingHomeMode()
        stHomeTilt.Status = FourStatusControl.DisplayStatus.Default
        stHomeRotation.Status = FourStatusControl.DisplayStatus.Default
        stStartRotation.Status = FourStatusControl.DisplayStatus.Default
        btnClampUp.Status = SL_CustomButton.DisplayStatus.Off
        btnClampDown.Status = SL_CustomButton.DisplayStatus.On
        btnShutterOpen.Status = SL_CustomButton.DisplayStatus.Off
        btnShutterClose.Status = SL_CustomButton.DisplayStatus.On
        btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Off
        btnRotate.Status = SL_CustomButton.DisplayStatus.Off
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-05-24</date>
    ''' </author>
    ''' <summary>
    ''' Set dissable btnShutterOpen and btnShutterClose when Shutter_Installed not installed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DissableButtonShutter()
        Try
            btnShutterOpen.Visible = False
            btnShutterClose.Visible = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

    Private Sub btnOpenCloseFlowCoolGas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenCloseFlowCoolGas.Click
        Dim titleMessage = String.Empty
        titleMessage = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
        SL_Support.OpenCloseBothShutoffSupplyValve(sender, titleMessage, m_stoStatusObject)
    End Sub

    Private Sub txtRotationMode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRotationMode.TextChanged
        Dim rotationMode As String = txtRotationMode.Text
        If rotationMode = "Continuous" Then
            rotationMode = "Cont"
        End If
        Select Case Me.Parent.Name
            Case Equipments.Chamber1.ToString()
                ContainerForm.ProcessPanel.PM1_PopUpStatusPanel.PMRotationMode = rotationMode
            Case Equipments.Chamber2.ToString()
                ContainerForm.ProcessPanel.PM2_PopUpStatusPanel.PMRotationMode = rotationMode
            Case Equipments.Chamber3.ToString()
                ContainerForm.ProcessPanel.PM3_PopUpStatusPanel.PMRotationMode = rotationMode
        End Select
    End Sub

    Private Sub ValveSupplyFlowCoolGas_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveSupplyFlowCoolGas.StatusChange
        GasLine_FlowCool.Status = Utils.ConvertToDisplayStatus(ValveSupplyFlowCoolGas.Status)
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            RaiseEvent FlowcoolStatusChange(sender, e)
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-01-15 </date>
    ''' </author>
    ''' <summary>
    ''' Update tilt angle text box when tilt is error
    ''' </summary>
    Private Sub stTiltError_StatusChanged(ByVal sender As System.Object, ByVal e As AVP_Robot_Project.FourStatusControl.StatusEventArgs) Handles stTiltError.StatusChanged
        UpdateTiltAngleText()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-01-15 </date>
    ''' </author>
    ''' <summary>
    ''' Update tilt angle text box when tilt is moving
    ''' </summary>
    Private Sub stTiltMoving_StatusChanged(ByVal sender As System.Object, ByVal e As AVP_Robot_Project.FourStatusControl.StatusEventArgs) Handles stTiltMoving.StatusChanged
        UpdateTiltAngleText()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-01-15 </date>
    ''' </author>
    ''' <summary>
    ''' Update tilt angle text box value
    ''' </summary>
    Public Sub UpdateTiltAngleText(Optional ByVal angle As String = "")
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Dim objChamber As AVPLib.DataManagerment.IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Name)
                If objChamber IsNot Nothing Then
                    If stTiltError.Status = FourStatusControl.DisplayStatus.Home Then
                        txtTiltAngleLeft.Text = objChamber.Fixture_TiltAngle_Program.ToString("0.#") & " (Err)"
                        txtTiltAngleLeft.ForeColor = Color.Red
                    ElseIf stTiltMoving.Status = FourStatusControl.DisplayStatus.Home Then
                        txtTiltAngleLeft.Text = "Mov"
                        txtTiltAngleLeft.ForeColor = Color.Black
                    Else
                        If String.IsNullOrEmpty(angle) Then
                            txtTiltAngleLeft.Text = Format(objChamber.Fixture_TiltAngle_Program, "0.0")
                            txtTiltAngleLeft.ForeColor = Color.Black
                        Else
                            Dim angleNumber As Double
                            Double.TryParse(angle, angleNumber)
                            txtTiltAngleLeft.Text = Format(angleNumber, "0.0")
                            txtTiltAngleLeft.ForeColor = Color.Black
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
