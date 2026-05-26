Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Imports System.Timers
Imports System.ComponentModel
Imports AVPControls

Public Class PMControl
    Public Const WAFER_RADIUS As Integer = 35
    Private Const ROTATE_COUNT As Single = 5
    Private Const MIN_ANGLE_CHANGE As Integer = 5

    Private bmp As Bitmap = Nothing
    Private m_PM As AVPLib.ConstEnum.Equipments = AVPLib.ConstEnum.Equipments.Chamber1
    Private m_pmPos As TypeOfAVPChamber = TypeOfAVPChamber.PVD4
    Private m_pmSlot As Int16 = 1
    Private m_pmInscreen As Support_Screen = Support_Screen.ProcessScreen
    Private m_supportCX As Support_CX = Support_CX.Support_CX4
    Private m_blnShowWaferBorder As Boolean = True
    Public IsLoaderCreateWafer As Boolean = False
    Private m_blnHasShutter As Boolean = False
    Private m_ShutterStatus As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Unknown
    Private m_ChamberType As AllChamberType = AllChamberType.AVP_IBE
    Private m_dockPosition As ChamberDockPositions = ChamberDockPositions.None
    Private m_IBEShutterOnFixture As Boolean = True
    Private m_PVDHasTarget As Boolean = True
    Private m_hasDataChanged As Boolean = True
    Private m_targetShutterStatus As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Unknown
    Private m_numberOfTargetInstalled As Integer = 4
    Private m_currentTargetIndex As Integer = 1
    Private m_isDisconnected As Boolean = False
    Private m_fixtureTiltAngle As Single = 0
    Private m_drawLocker As New Object
    Private m_waferStatus As AVPLib.ConstEnum.enumWaferStatus = enumWaferStatus.eWaferNone

    ' Support rotate target
    Private Const ROTATING_SPEED As Integer = 3
    Private m_rotatingAngle As Single = 0
    Delegate Sub TimerUpdatePosition()
    Private m_lockChangeData As Object = New Object
    Private m_isRotateCW As Boolean = True
    Private m_needCreateRegion As Boolean = True
    Private m_targetLocation(3) As Point
    Private m_newTargetIndex As Integer = 1

    ' Drawing variables
    Private m_iCurrentPosition As Int16 = 1
    Private m_NumberOfWafer As Integer = 8
    Public m_lstWaferControl As List(Of AVPWaferControl)
    Private m_biasRotatingAngle As Single = 0
    Private m_slotDistanceAngle As Single = 45
    Private m_angleSpan As Single = m_slotDistanceAngle / ROTATE_COUNT
    Private m_chamberAngle As Single = 0
    Private m_firstSlotAngle As Single = 0
    
    'Private m_RotTimer As System.Timers.Timer

    ' End Drawing variables

    Private m_currentEncoderCount As Single = 0
    Private m_totalEncoderCount As Single = 20000
    Private m_slotCountDistance As Single = m_totalEncoderCount / m_NumberOfWafer

    Public Enum Support_Screen
        TM
        ProcessScreen
    End Enum

    Public Enum Support_CX
        Support_CX4
        Support_CX5
    End Enum

    Public Enum ChamberDockPositions
        None = 0
        PM1 = 1
        PM2 = 2
        PM3 = 3
    End Enum

    Public Enum WaferPosition
        WAFER_1
        WAFER_2
        WAFER_3
        WAFER_4
        WAFER_5
        WAFER_6
        WAFER_7
        WAFER_8
    End Enum

    Public Enum Radial
        WAFER_1 = 30
        WAFER_2 = 28
        WAFER_3 = 26
        WAFER_4 = 20
        WAFER_5 = 20
        WAFER_6 = 18
        WAFER_7 = 16
        WAFER_8 = 16
    End Enum


    Private Const CLICKEDCHAMBER1 As Integer = 1
    Private Const CLICKEDCHAMBER2 As Integer = 2
    Private Const CLICKEDCHAMBER3 As Integer = 3

#Region "Properties"
   
    <DefaultValue(GetType(Int16), "1")> _
    Public Property CurrentPosition() As Int16
        Get
            Return m_iCurrentPosition
        End Get
        Set(ByVal value As Int16)
            If m_iCurrentPosition <> value AndAlso value >= 1 AndAlso value <= m_NumberOfWafer Then
                m_iCurrentPosition = value

                CurrentEncoderCount = m_iCurrentPosition * m_slotCountDistance - m_slotCountDistance
            End If
        End Set
    End Property

    <DefaultValue(GetType(Single), "0")> _
    Public Property FixtureTiltAngle() As Single
        Get
            Return m_fixtureTiltAngle
        End Get
        Set(ByVal value As Single)
            If m_fixtureTiltAngle <> value Then
                m_fixtureTiltAngle = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    <DefaultValue(GetType(Single), "20000")> _
    Public Property TotalEncoderCount() As Single
        Get
            Return m_totalEncoderCount
        End Get
        Set(ByVal value As Single)
            If m_totalEncoderCount <> value Then
                m_totalEncoderCount = value
                m_slotCountDistance = m_totalEncoderCount / m_NumberOfWafer
                UpdateRotatePosition()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Single), "0")> _
    Public Property CurrentEncoderCount() As Single
        Get
            Return m_currentEncoderCount
        End Get
        Set(ByVal value As Single)
            If m_currentEncoderCount <> value Then
                m_currentEncoderCount = value

                UpdateRotatePosition()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Integer), "8")> _
    Public Property NumberOfWafer() As Integer
        Get
            Return m_NumberOfWafer
        End Get
        Set(ByVal value As Integer)
            If m_NumberOfWafer <> value Then
                m_slotDistanceAngle = 360.0F / value
                m_angleSpan = m_slotDistanceAngle / ROTATE_COUNT
                If m_iCurrentPosition > value Then
                    m_iCurrentPosition = value
                End If
                m_NumberOfWafer = value
                m_hasDataChanged = True
                InitializeWaferControl(m_NumberOfWafer)
                m_slotCountDistance = m_totalEncoderCount / m_NumberOfWafer
            End If

        End Set
    End Property

    <DefaultValue(GetType(Integer), "1")> _
        Public Property CurrentTargetIndex() As Integer
        Get
            Return m_newTargetIndex
        End Get
        Set(ByVal value As Integer)
            If value >= 1 AndAlso value <= m_numberOfTargetInstalled Then
                If m_newTargetIndex <> value Then
                    m_newTargetIndex = value
                    m_hasDataChanged = True
                    m_currentTargetIndex = value

                End If
            End If
        End Set
    End Property

    <DefaultValue(GetType(AVPLib.DataManagerment.Equipment.WorkingStatuses), "Unknown")> _
    Public Property TargetShutterStatus() As AVPLib.DataManagerment.Equipment.WorkingStatuses
        Get
            Return m_targetShutterStatus
        End Get
        Set(ByVal value As AVPLib.DataManagerment.Equipment.WorkingStatuses)
            If m_targetShutterStatus <> value Then
                m_targetShutterStatus = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Public Property PVDHasTarget() As Boolean
        Get
            Return m_PVDHasTarget
        End Get
        Set(ByVal value As Boolean)
            If m_PVDHasTarget <> value Then
                m_PVDHasTarget = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Public Property IBEShutterOnFixture() As Boolean
        Get
            Return m_IBEShutterOnFixture
        End Get
        Set(ByVal value As Boolean)
            If m_IBEShutterOnFixture <> value Then
                m_IBEShutterOnFixture = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    <DefaultValue(GetType(ChamberDockPositions), "None")> _
    Public Property DockPosition() As ChamberDockPositions
        Get
            Return m_dockPosition
        End Get
        Set(ByVal value As ChamberDockPositions)
            If m_dockPosition <> value Then
                m_dockPosition = value
                m_hasDataChanged = True
                m_needCreateRegion = True
                m_chamberAngle = GetAngle(m_supportCX, m_dockPosition)
                m_firstSlotAngle = GetFirstSlotAngle(m_dockPosition)
                m_biasRotatingAngle = 0
                Repaint()
                SetWaferLocation()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property ShowWafer_Border_ToEdit() As Boolean
        Get
            Return m_blnShowWaferBorder
        End Get
        Set(ByVal value As Boolean)
            If m_blnShowWaferBorder <> value Then
                m_blnShowWaferBorder = value
                ShowBorderAllWafers(m_blnShowWaferBorder)
            End If
        End Set
    End Property

    Public Property LabelDisconnect_Location() As Point
        Get
            Return lblDisconnected.Location
        End Get
        Set(ByVal value As Point)
            If lblDisconnected.Location <> value Then
                lblDisconnected.Location = value
                Me.Refresh()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property Show_Disconnected() As Boolean
        Get
            Return m_isDisconnected
        End Get
        Set(ByVal value As Boolean)
            If m_isDisconnected <> value Then
            m_isDisconnected = value
            Refresh()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Support_CX), "Support_CX4")> _
    Public Property CX_Supported() As Support_CX
        Get
            Return m_supportCX
        End Get
        Set(ByVal value As Support_CX)
            If m_supportCX <> value Then
            m_supportCX = value
            m_hasDataChanged = True
            m_chamberAngle = GetAngle(m_supportCX, m_dockPosition)
            m_firstSlotAngle = GetFirstSlotAngle(m_dockPosition)
            m_biasRotatingAngle = m_firstSlotAngle
            m_needCreateRegion = True
            Repaint()
            SetWaferLocation()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Support_Screen), "ProcessScreen")> _
    Public Property PM_IN_SCREEN() As Support_Screen
        Get
            Return m_pmInscreen
        End Get
        Set(ByVal value As Support_Screen)
            m_pmInscreen = value
        End Set
    End Property

    <DefaultValue(GetType(TypeOfAVPChamber), "PVD4")> _
    Public Property PM_Type() As TypeOfAVPChamber
        Get
            Return m_pmPos
        End Get
        Set(ByVal value As TypeOfAVPChamber)
            If m_pmPos <> value Then
                m_pmPos = value
                m_hasDataChanged = True
                m_needCreateRegion = True
                UpdateChamberTypeChanged()
                Repaint()
                SetLabelDisconnectedLocation()
            End If
        End Set
    End Property

    <DefaultValue(GetType(AllChamberType), "AVP_IBE")>
    Public Property ChamberType() As AllChamberType
        Get
            Return m_ChamberType
        End Get
        Set(ByVal value As AllChamberType)
            If m_ChamberType <> value Then
                m_ChamberType = value
                m_hasDataChanged = True
                m_needCreateRegion = True
                UpdateChamberTypeChanged()
                Repaint()
                SetLabelDisconnectedLocation()
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name>Tin Pham</name>
    '''    	<date> 2015-06-30 </date>
    ''' </author>
    ''' <summary>
    ''' Get PMx Index->return 1 to 6
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PM_Index() As Integer
        Get
            Return Convert.ToInt32(m_dockPosition)
        End Get
    End Property

    Private m_blnSourceIsOn As Boolean = False 'Support for IBE, PQL Chamber
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property SourceIsOn() As Boolean
        Get
            Return m_blnSourceIsOn
        End Get
        Set(ByVal value As Boolean)
            If m_blnSourceIsOn <> value Then
                m_blnSourceIsOn = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_isPlasmaOn As Boolean = False
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property PlasmaIsOn() As Boolean
        Get
            Return m_isPlasmaOn
        End Get
        Set(ByVal value As Boolean)
            If m_isPlasmaOn <> value Then
                m_isPlasmaOn = value
                'WFControl.PlasmaOn = value
                m_hasDataChanged = True
                Repaint()
            End If
        End Set
    End Property

    <DefaultValue(GetType(AVPLib.ConstEnum.enumWaferStatus), "eWaferNone")> _
    Public Property WaferStatus() As AVPLib.ConstEnum.enumWaferStatus
        Get
            Return m_waferStatus
        End Get
        Set(ByVal value As AVPLib.ConstEnum.enumWaferStatus)
            If m_waferStatus <> value Then
                m_waferStatus = value
                SetWaferStatus()
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Public Property WaferID() As String
        Get
            Return WFControl.WaferID
        End Get
        Set(ByVal value As String)
            If WFControl.WaferID <> value Then
                WFControl.WaferID = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Public Property WaferLocation() As Point
        Get
            Return WFControl.Location
        End Get
        Set(ByVal value As Point)
            If WFControl.Location <> value Then
                WFControl.Location = value
                Me.Refresh()
            End If
        End Set
    End Property

    Public Property ShutterLocation() As Point
        Get
            Return bicShutter.Location
        End Get
        Set(ByVal value As Point)
            bicShutter.Location = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-15</date>
    ''' </author>
    ''' <summary>
    ''' Get/Set PVD has install shutter or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property HasShutter() As Boolean
        Get
            Return m_blnHasShutter
        End Get
        Set(ByVal value As Boolean)
            If m_blnHasShutter <> value Then
                m_blnHasShutter = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    <DefaultValue(GetType(AVPLib.DataManagerment.Equipment.WorkingStatuses), "Unknown")> _
    Public Property ShutterStatus() As AVPLib.DataManagerment.Equipment.WorkingStatuses
        Get
            Return m_ShutterStatus
        End Get
        Set(ByVal value As AVPLib.DataManagerment.Equipment.WorkingStatuses)
            If m_ShutterStatus <> value Then
                m_ShutterStatus = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_T1HasPlasma As Boolean = False
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property T1HasPlasma() As Boolean
        Get
            Return m_T1HasPlasma
        End Get
        Set(ByVal value As Boolean)
            If m_T1HasPlasma <> value Then
                m_T1HasPlasma = value
                If m_T1HasPlasma Then
                    m_T2HasPlasma = False
                    m_T3HasPlasma = False
                    m_T4HasPlasma = False
                    m_T5HasPlasma = False
                End If
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_T2HasPlasma As Boolean = False
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property T2HasPlasma() As Boolean
        Get
            Return m_T2HasPlasma
        End Get
        Set(ByVal value As Boolean)
            If m_T2HasPlasma <> value Then
                m_T2HasPlasma = value
                If m_T2HasPlasma Then
                    m_T1HasPlasma = False
                    m_T3HasPlasma = False
                    m_T4HasPlasma = False
                    m_T5HasPlasma = False
                End If
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_T3HasPlasma As Boolean = False
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property T3HasPlasma() As Boolean
        Get
            Return m_T3HasPlasma
        End Get
        Set(ByVal value As Boolean)
            If m_T3HasPlasma <> value Then
                m_T3HasPlasma = value
                If m_T3HasPlasma Then
                    m_T2HasPlasma = False
                    m_T1HasPlasma = False
                    m_T4HasPlasma = False
                    m_T5HasPlasma = False
                End If
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_T4HasPlasma As Boolean = False
    <DefaultValue(GetType(Boolean), "False")>
    Public Property T4HasPlasma() As Boolean
        Get
            Return m_T4HasPlasma
        End Get
        Set(ByVal value As Boolean)
            If m_T4HasPlasma <> value Then
                m_T4HasPlasma = value
                If m_T4HasPlasma Then
                    m_T2HasPlasma = False
                    m_T3HasPlasma = False
                    m_T1HasPlasma = False
                    m_T5HasPlasma = False
                End If
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_T5HasPlasma As Boolean = False
    <DefaultValue(GetType(Boolean), "False")>
    Public Property T5HasPlasma() As Boolean
        Get
            Return m_T5HasPlasma
        End Get
        Set(ByVal value As Boolean)
            If m_T5HasPlasma <> value Then
                m_T5HasPlasma = value
                If m_T5HasPlasma Then
                    m_T2HasPlasma = False
                    m_T3HasPlasma = False
                    m_T1HasPlasma = False
                    m_T4HasPlasma = False
                End If
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_TotalTargetInstalled As Int16 = 0
    Public Property TotalTargetInstalled() As Int16
        Get
            Return m_TotalTargetInstalled
        End Get
        Set(ByVal value As Int16)
            m_TotalTargetInstalled = value
        End Set
    End Property

    Private m_T1Installed As Boolean = True
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property T1Installed() As Boolean
        Get
            Return m_T1Installed
        End Get
        Set(ByVal value As Boolean)
            If m_T1Installed <> value Then
                m_T1Installed = value
                m_hasDataChanged = True
                GetNumberOfTargetInstalled()
            End If
        End Set
    End Property

    Private m_T2Installed As Boolean = True
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property T2Installed() As Boolean
        Get
            Return m_T2Installed
        End Get
        Set(ByVal value As Boolean)
            If m_T2Installed <> value Then
                m_T2Installed = value
                m_hasDataChanged = True
                GetNumberOfTargetInstalled()
            End If
        End Set
    End Property

    Private m_T3Installed As Boolean = True
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property T3Installed() As Boolean
        Get
            Return m_T3Installed
        End Get
        Set(ByVal value As Boolean)
            If m_T3Installed <> value Then
                m_T3Installed = value
                m_hasDataChanged = True
                GetNumberOfTargetInstalled()
            End If
        End Set
    End Property

    Private m_T4Installed As Boolean = True
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property T4Installed() As Boolean
        Get
            Return m_T4Installed
        End Get
        Set(ByVal value As Boolean)
            If m_T4Installed <> value Then
                m_T4Installed = value
                m_hasDataChanged = True
                GetNumberOfTargetInstalled()
            End If
        End Set
    End Property

    Private m_T5Installed As Boolean = True
    <DefaultValue(GetType(Boolean), "True")>
    Public Property T5Installed() As Boolean
        Get
            Return m_T5Installed
        End Get
        Set(ByVal value As Boolean)
            If m_T5Installed <> value Then
                m_T5Installed = value
                m_hasDataChanged = True
                GetNumberOfTargetInstalled()
            End If
        End Set
    End Property

    Private m_T1ShutterStatus As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Unknown
    <DefaultValue(GetType(AVPLib.DataManagerment.Equipment.WorkingStatuses), "Unknown")> _
    Public Property T1ShutterStatus() As AVPLib.DataManagerment.Equipment.WorkingStatuses
        Get
            Return m_T1ShutterStatus
        End Get
        Set(ByVal value As AVPLib.DataManagerment.Equipment.WorkingStatuses)
            If m_T1ShutterStatus <> value Then
                m_T1ShutterStatus = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_T2ShutterStatus As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Unknown
    <DefaultValue(GetType(AVPLib.DataManagerment.Equipment.WorkingStatuses), "Unknown")> _
    Public Property T2ShutterStatus() As AVPLib.DataManagerment.Equipment.WorkingStatuses
        Get
            Return m_T2ShutterStatus
        End Get
        Set(ByVal value As AVPLib.DataManagerment.Equipment.WorkingStatuses)
            If m_T2ShutterStatus <> value Then
                m_T2ShutterStatus = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_T3ShutterStatus As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Unknown
    <DefaultValue(GetType(AVPLib.DataManagerment.Equipment.WorkingStatuses), "Unknown")> _
    Public Property T3ShutterStatus() As AVPLib.DataManagerment.Equipment.WorkingStatuses
        Get
            Return m_T3ShutterStatus
        End Get
        Set(ByVal value As AVPLib.DataManagerment.Equipment.WorkingStatuses)
            If m_T3ShutterStatus <> value Then
                m_T3ShutterStatus = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_T4ShutterStatus As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Unknown
    <DefaultValue(GetType(AVPLib.DataManagerment.Equipment.WorkingStatuses), "Unknown")> _
    Public Property T4ShutterStatus() As AVPLib.DataManagerment.Equipment.WorkingStatuses
        Get
            Return m_T4ShutterStatus
        End Get
        Set(ByVal value As AVPLib.DataManagerment.Equipment.WorkingStatuses)
            If m_T4ShutterStatus <> value Then
                m_T4ShutterStatus = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_T5ShutterStatus As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Unknown
    <DefaultValue(GetType(AVPLib.DataManagerment.Equipment.WorkingStatuses), "Unknown")>
    Public Property T5ShutterStatus() As AVPLib.DataManagerment.Equipment.WorkingStatuses
        Get
            Return m_T5ShutterStatus
        End Get
        Set(ByVal value As AVPLib.DataManagerment.Equipment.WorkingStatuses)
            If m_T5ShutterStatus <> value Then
                m_T5ShutterStatus = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_depSourcesInstalled As Boolean = True
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property DepSourceInstalled() As Boolean
        Get
            Return m_depSourcesInstalled
        End Get
        Set(ByVal value As Boolean)
            If m_depSourcesInstalled <> value Then
                m_depSourcesInstalled = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    Private m_etchSourceInstalled As Boolean = True
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property EtchSourceInstalled() As Boolean
        Get
            Return m_etchSourceInstalled
        End Get
        Set(ByVal value As Boolean)
            If m_etchSourceInstalled <> value Then
                m_etchSourceInstalled = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

#End Region

#Region "Sub and Methods"
    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            Dim swiWaferInside As New StatusWaferInside(WFControl)
            Dim swiWaferInside1 As New StatusWaferInside(WFControl8)
            Dim swiWaferInside2 As New StatusWaferInside(WFControl2)
            Dim swiWaferInside3 As New StatusWaferInside(WFControl3)
            Dim swiWaferInside4 As New StatusWaferInside(WFControl4)
            Dim swiWaferInside5 As New StatusWaferInside(WFControl5)
            Dim swiWaferInside6 As New StatusWaferInside(WFControl6)
            Dim swiWaferInside7 As New StatusWaferInside(WFControl7)
            Dim stlCurPos As New StatusLabel(lblCurrentPos)
            m_stoStatusObject.AddChild(swiWaferInside)
            m_stoStatusObject.AddChild(swiWaferInside1)
            m_stoStatusObject.AddChild(swiWaferInside2)
            m_stoStatusObject.AddChild(swiWaferInside3)
            m_stoStatusObject.AddChild(swiWaferInside4)
            m_stoStatusObject.AddChild(swiWaferInside5)
            m_stoStatusObject.AddChild(swiWaferInside6)
            m_stoStatusObject.AddChild(swiWaferInside7)
            m_stoStatusObject.AddChild(stlCurPos)
            Dim sbcShutterStatus As New SL_StatusButton(bicShutter)
            m_stoStatusObject.AddChild(sbcShutterStatus)
            bicShutter.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Dy Do</author>
    ''' <date>2016-08-19</date>
    ''' <summary>
    ''' Update wafer for each chamber type.
    ''' </summary>
    Private Sub UpdateChamberTypeChanged()
        If PM_Type <> TypeOfAVPChamber.PVD4 AndAlso PM_Type <> TypeOfAVPChamber.PVD5T Then
            InitializeWaferControl(1)
        Else
            InitializeWaferControl(m_NumberOfWafer)
        End If
        SetWaferLocation()
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Display context menu when user click on circle plasma of Chamber
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowContextMenuClickOnChamber(ByVal sender As Object)
        Try
            Dim cpcTemp As Control = CType(sender, Control)
            Dim pos As New System.Drawing.Point(cpcTemp.Location)
            pos.Y += cpcTemp.Height
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
    ''' Prepare context menu before showing
    ''' </summary>
    ''' <param name="ticWaferInside"></param>
    ''' <remarks></remarks>
    Public Sub PrepareChamberMenu(ByVal objWafer As AVPWaferControl)
        Try
            If objWafer.WaferStatus <> AVPControls.AVPDataLib.WaferStatuses.NONE Then
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
    ''' Enable menu context item 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetChamberMenuContextEnable(ByVal blnCreateWafer As Boolean, _
                                            ByVal blnDeleteWafer As Boolean, _
                                            ByVal blnSrcForMove As Boolean, _
                                            ByVal blnDstForMove As Boolean, _
                                            ByVal blnUpdateWaferInfo As Boolean)
        Try
            Dim hasSelfAlign As Boolean = IIf(RobotConfigurationValues.ALINER_VISIBLE, _
                                        ContainerForm.CassettesPanel.saSelfAligner.btnSelfAligner.Enabled, True)
            mnuCreateWafer.Enabled = IIf(ContainerForm.CassettesPanel.ISTM_ONLINE, False, blnCreateWafer)
            mnuDeleteWafer.Enabled = IIf(ContainerForm.CassettesPanel.ISTM_ONLINE, False, blnDeleteWafer)
            mnuSrcForMove.Enabled = IIf(ContainerForm.CassettesPanel.ISTM_ONLINE, False, (blnSrcForMove AndAlso hasSelfAlign))
            mnuDstForMove.Enabled = IIf(ContainerForm.CassettesPanel.ISTM_ONLINE, False, (blnDstForMove AndAlso hasSelfAlign))
            mnuUpdateWaferInfoToolStripMenuItem.Enabled = IIf(ContainerForm.CassettesPanel.ISTM_ONLINE, False, blnUpdateWaferInfo)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub WaferControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    WFControl.Click, WFControl2.Click, WFControl3.Click, WFControl4.Click, _
     WFControl5.Click, WFControl6.Click, WFControl7.Click, WFControl8.Click
        AVPLib.Log.guiLogger.Info("Enter WaferControl_Click")
        Try
            Dim wf As AVPWaferControl = CType(sender, AVPWaferControl)
            m_pmSlot = wf.PMSlotNumber
            Dim objchamber As AVPLib.DataManagerment.Chamber = Nothing
            Dim blResumed As Boolean = False
            Select Case m_dockPosition
                Case ChamberDockPositions.PM1
                    ProcessPanel.ClickedPosition = CLICKEDCHAMBER1
                        ContainerForm.CassettesPanel.ClickedInChamber = CLICKEDCHAMBER1
                    objchamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
                Case ChamberDockPositions.PM2
                    ProcessPanel.ClickedPosition = CLICKEDCHAMBER2
                        ContainerForm.CassettesPanel.ClickedInChamber = CLICKEDCHAMBER2
                    objchamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
                Case ChamberDockPositions.PM3
                    ProcessPanel.ClickedPosition = CLICKEDCHAMBER3
                        ContainerForm.CassettesPanel.ClickedInChamber = CLICKEDCHAMBER3
                    objchamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
            End Select

            'add slot 
            ProcessPanel.ClickedSlot = m_pmSlot
            Dim isRecipeAbortedInPM As Boolean = False
            If PM_IN_SCREEN = Support_Screen.TM Then
                PrepareChamberMenu(wf)
                ShowContextMenuClickOnChamber(wf)
            Else
                If objchamber IsNot Nothing AndAlso objchamber.GetWaferInfo(m_pmSlot) IsNot Nothing Then
                    Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
                    avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(objchamber.GetWaferInfo(m_pmSlot).WaferID)
                    Dim bShowReturnNow As Boolean = False
                    If avpProcessJob IsNot Nothing Then
                        blResumed = avpProcessJob.IsPaused()
                        bShowReturnNow = avpProcessJob.IsJobOver()
                        isRecipeAbortedInPM = avpProcessJob.IsWaitingProcessingComplete
                    Else
                        If (Utils.isAlignerInUse()) Then
                            If (AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = AVPLib.RobotConfigurationValues.LLA_STATION_NO AndAlso _
                            objchamber.GetWaferInfo(m_pmSlot).WaferID.ToString().Contains("A")) Then
                                bShowReturnNow = False
                            Else
                                bShowReturnNow = IIf(objchamber.IsProcessRunning, False, True)
                            End If
                        Else
                            bShowReturnNow = IIf(objchamber.IsProcessRunning, False, True)
                        End If
                    End If
                    ShowContextMenuClickOnChamber(sender, blResumed, bShowReturnNow)
                ElseIf objchamber IsNot Nothing AndAlso objchamber.GetWaferInfo(m_pmSlot) Is Nothing Then
                    GoTo_PMTab()
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave WaferControl_Click")
    End Sub

    Private Sub GoTo_PMTab()
        Try
            Select Case m_dockPosition
                Case ChamberDockPositions.PM1
                    AVPRobotMain.GotoScreen(AVPRobotMain.SystemScreens.PM1Screen)

                Case ChamberDockPositions.PM2
                    AVPRobotMain.GotoScreen(AVPRobotMain.SystemScreens.PM2Screen)

                Case ChamberDockPositions.PM3
                    AVPRobotMain.GotoScreen(AVPRobotMain.SystemScreens.PM3Screen)

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''    	<date> 20098-10-29</date>
    ''' </author>
    ''' <summary>
    ''' Display context menu when user click on circle plasma of Chamber
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowContextMenuClickOnChamber(ByVal sender As Object, ByVal blshowResume As Boolean, ByVal bShowReturnNow As Boolean, Optional ByVal isRecipeAbortedInPM As Boolean = False)
        Try
            Dim cpcTemp As Control
            cpcTemp = CType(sender, Control)
            Dim pos As New System.Drawing.Point(cpcTemp.Location)
            pos.Y += cpcTemp.Height
            pos = Me.PointToScreen(pos)
                ContainerForm.ProcessPanel.mnuResume.Enabled = (blshowResume And Not isRecipeAbortedInPM)
            ContainerForm.ProcessPanel.mnuReturn.Enabled = blshowResume
            ContainerForm.ProcessPanel.mnuReturnNow.Enabled = bShowReturnNow And (Not ContainerForm.ProcessPanel.IsButtonClearAllWaferClicked)
            ContainerForm.ProcessPanel.cmsChamber.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub InitializeWaferControl(ByVal iNumberOfWafer As Integer)
        Try
            m_lstWaferControl = New List(Of AVPWaferControl)
            Select Case iNumberOfWafer
                Case 1
                    m_lstWaferControl.Add(WFControl)

                    WFControl2.Visible = False
                    WFControl3.Visible = False
                    WFControl4.Visible = False
                    WFControl5.Visible = False
                    WFControl6.Visible = False
                    WFControl7.Visible = False
                    WFControl8.Visible = False

                Case 2
                    m_lstWaferControl.Add(WFControl)
                    m_lstWaferControl.Add(WFControl2)

                    WFControl2.Visible = True
                    WFControl3.Visible = False
                    WFControl4.Visible = False
                    WFControl5.Visible = False
                    WFControl6.Visible = False
                    WFControl7.Visible = False
                    WFControl8.Visible = False
                Case 3
                    m_lstWaferControl.Add(WFControl)
                    m_lstWaferControl.Add(WFControl2)
                    m_lstWaferControl.Add(WFControl3)


                    WFControl2.Visible = True
                    WFControl3.Visible = True
                    WFControl4.Visible = False
                    WFControl5.Visible = False
                    WFControl6.Visible = False
                    WFControl7.Visible = False
                    WFControl8.Visible = False
                Case 4
                    m_lstWaferControl.Add(WFControl)
                    m_lstWaferControl.Add(WFControl2)
                    m_lstWaferControl.Add(WFControl3)
                    m_lstWaferControl.Add(WFControl4)

                    WFControl2.Visible = True
                    WFControl3.Visible = True
                    WFControl4.Visible = True
                    WFControl5.Visible = False
                    WFControl6.Visible = False
                    WFControl7.Visible = False
                    WFControl8.Visible = False
                Case 5
                    m_lstWaferControl.Add(WFControl)
                    m_lstWaferControl.Add(WFControl2)
                    m_lstWaferControl.Add(WFControl3)
                    m_lstWaferControl.Add(WFControl4)
                    m_lstWaferControl.Add(WFControl5)
                    WFControl2.Visible = True
                    WFControl3.Visible = True
                    WFControl4.Visible = True
                    WFControl5.Visible = True
                    WFControl6.Visible = False
                    WFControl7.Visible = False
                    WFControl8.Visible = False
                Case 6
                    m_lstWaferControl.Add(WFControl)
                    m_lstWaferControl.Add(WFControl2)
                    m_lstWaferControl.Add(WFControl3)
                    m_lstWaferControl.Add(WFControl4)
                    m_lstWaferControl.Add(WFControl5)
                    m_lstWaferControl.Add(WFControl6)
                    WFControl2.Visible = True
                    WFControl3.Visible = True
                    WFControl4.Visible = True
                    WFControl5.Visible = True
                    WFControl6.Visible = True
                    WFControl7.Visible = False
                    WFControl8.Visible = False
                Case 7
                    m_lstWaferControl.Add(WFControl)
                    m_lstWaferControl.Add(WFControl2)
                    m_lstWaferControl.Add(WFControl3)
                    m_lstWaferControl.Add(WFControl4)
                    m_lstWaferControl.Add(WFControl5)
                    m_lstWaferControl.Add(WFControl6)
                    m_lstWaferControl.Add(WFControl7)
                    WFControl2.Visible = True
                    WFControl3.Visible = True
                    WFControl4.Visible = True
                    WFControl5.Visible = True
                    WFControl6.Visible = True
                    WFControl7.Visible = True
                    WFControl8.Visible = False
                Case 8
                    m_lstWaferControl.Add(WFControl)
                    m_lstWaferControl.Add(WFControl2)
                    m_lstWaferControl.Add(WFControl3)
                    m_lstWaferControl.Add(WFControl4)
                    m_lstWaferControl.Add(WFControl5)
                    m_lstWaferControl.Add(WFControl6)
                    m_lstWaferControl.Add(WFControl7)
                    m_lstWaferControl.Add(WFControl8)
                    WFControl2.Visible = True
                    WFControl3.Visible = True
                    WFControl4.Visible = True
                    WFControl5.Visible = True
                    WFControl6.Visible = True
                    WFControl7.Visible = True
                    WFControl8.Visible = True
                Case Else
                    AVPLib.Log.avpLogger.Error("Do not support this case")
            End Select

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.Message)
        End Try
    End Sub

    Public Function ChangeWaferStatus(ByVal WaferID As String, ByVal NewWaferStatus As AVPLib.ConstEnum.enumWaferStatus) As Boolean
        Dim blResult As Boolean = False
        Try
            If (CX_Supported = Support_CX.Support_CX4) Then
                If (m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count > 0) Then
                    For Each Item As AVPWaferControl In m_lstWaferControl
                        If (Item IsNot Nothing AndAlso Item.WaferID = WaferID) Then
                            Item.WaferStatus = NewWaferStatus
                            blResult = True
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blResult
    End Function

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Active/Inactive controls in form
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActiveForm(ByVal isEnabled As Boolean)
        WFControl.Enabled = isEnabled
    End Sub
#End Region

#Region "Behavior Methods"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        'Utils.CreateControlRegion(Me, bmp)
        WFControl.WaferID = ""
        Me.Cursor = Cursors.Hand
        bicShutter.Visible = False
        Me.DoubleBuffered = True
        ' Add any initialization after the InitializeComponent() call.
        Me.DoubleBuffered = True
        m_targetLocation(0) = New Point(18, 53)
        m_targetLocation(1) = New Point(76, 53)
        m_targetLocation(2) = New Point(18, 5)
        m_targetLocation(3) = New Point(76, 5)


        InitializeWaferControl(m_NumberOfWafer)

    End Sub


    Private Sub PMControl_6PMs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        GoTo_PMTab()
    End Sub

    Private Sub mnuCreateWafer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCreateWafer.Click
        Try
            Dim addwafer As WaferInfoDlg = New WaferInfoDlg()
            Dim chamberName As String = String.Empty
            addwafer.PMTotalWafer = Me.m_NumberOfWafer
            addwafer.PMSlot = m_pmSlot

            Dim waferInfo As enumWaferStatus
            For i As Integer = 1 To Me.m_NumberOfWafer
                waferInfo = GetWaferStatus(i)
                Select Case waferInfo
                    Case enumWaferStatus.eWaferComplete
                        addwafer.PMWaferStatus = WaferInfoDlg.WaferStatus.COMPLETE
                        Exit For
                    Case enumWaferStatus.eWaferError
                        addwafer.PMWaferStatus = WaferInfoDlg.WaferStatus.ERROR
                        Exit For
                    Case enumWaferStatus.eWaferExposed
                        addwafer.PMWaferStatus = WaferInfoDlg.WaferStatus.PARTIAL
                        Exit For
                    Case enumWaferStatus.eWaferNew
                        addwafer.PMWaferStatus = WaferInfoDlg.WaferStatus.UNPROCESS
                        Exit For
                End Select
            Next
            addwafer.ShowDialog()
            If addwafer.DialogResult = DialogResult.OK Then
                If Me.PM_Type = TypeOfAVPChamber.IBE Or Me.PM_Type = TypeOfAVPChamber.PVD Then
                    ContainerForm.CassettesPanel.SetWaferInside(ConstEnum.STR_CREATE_WAFER, BinaryStatusControl.DisplayStatus.On, addwafer.WaferInfo, Me.PM_Index)
                ElseIf Me.PM_Type = TypeOfAVPChamber.PVD4 Then
                    ContainerForm.CassettesPanel.SetWaferInside(ConstEnum.STR_CREATE_WAFER, BinaryStatusControl.DisplayStatus.On, addwafer.WaferInfo, Me.PM_Index, addwafer.PMSlot)
                ElseIf Me.PM_Type = TypeOfAVPChamber.PVD5T Then
                    ContainerForm.CassettesPanel.SetWaferInside(ConstEnum.STR_CREATE_WAFER, BinaryStatusControl.DisplayStatus.On, addwafer.WaferInfo, Me.PM_Index, addwafer.PMSlot)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Private Sub mnuDeleteWafer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDeleteWafer.Click
        AVPLib.Log.guiLogger.Info("Enter mnuDeleteWafer_Click")
        Try
            Dim chamberName As String = String.Empty
            If Me.PM_Type = TypeOfAVPChamber.IBE Or Me.PM_Type = TypeOfAVPChamber.PVD Then
                ContainerForm.CassettesPanel.SetWaferInside(ConstEnum.STR_DELETE_WAFER, BinaryStatusControl.DisplayStatus.Off, Nothing, Me.PM_Index)
            ElseIf Me.PM_Type = TypeOfAVPChamber.PVD4 Then
                ContainerForm.CassettesPanel.SetWaferInside(ConstEnum.STR_DELETE_WAFER, BinaryStatusControl.DisplayStatus.Off, Nothing, Me.PM_Index, m_pmSlot)
                AVPLib.Business.CoronaUtility.UpdateWaferID(GetChamberID())
            ElseIf Me.PM_Type = TypeOfAVPChamber.PVD5T Then
                ContainerForm.CassettesPanel.SetWaferInside(ConstEnum.STR_DELETE_WAFER, BinaryStatusControl.DisplayStatus.Off, Nothing, Me.PM_Index, m_pmSlot)
                AVPLib.Business.CoronaUtility.UpdateWaferID(GetChamberID())
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuDeleteWafer_Click")
    End Sub

    Private Sub mnuDstForMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDstForMove.Click
        AVPLib.Log.guiLogger.Info("Enter mnuDstForMove_Click")
        Try
            If CheckWaferIsPausingInPM() Then
                Exit Try
            End If

            With ContainerForm.CassettesPanel
                If .stwSemiautoTransferWafer.btnStart.Enabled = False AndAlso _
                Not String.IsNullOrEmpty(.stwSemiautoTransferWafer.txtSource.Text) AndAlso _
                       Not String.IsNullOrEmpty(.stwSemiautoTransferWafer.txtDestination.Text) Then ''transferring
                    Utils.ShowAVPMessageBox("Please wait for other transfer to complete...", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
                Else
                    .stwSemiautoTransferWafer.txtDestination.Text = .GenerateSrcOrDst(Me.PM_Index) & ",Slot" & m_pmSlot
                    AVPLib.Utils.ShowStatusMessage("Destination for Transfer Wafer: " & .stwSemiautoTransferWafer.txtDestination.Text)
                    If .stwSemiautoTransferWafer.txtDestination.Text = STR_ALIGNER Then
                        .stwSemiautoTransferWafer.Dest_Is_Aligner = True
                    Else
                        .stwSemiautoTransferWafer.Dest_Is_Aligner = False
                    End If
                    If .stwSemiautoTransferWafer.txtSource.Text = .stwSemiautoTransferWafer.txtDestination.Text Then
                        Utils.ShowAVPMessageBox("Source and Destination for Transfer Wafer are the same, Source will be clear. " & Chr(13) & "Please select Source for Transfer Wafer again", "Transfer Wafer", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                        .stwSemiautoTransferWafer.txtSource.Clear()
                    End If
                    ContainerForm.CassettesPanel.ShowTransferWaferDialog()
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Select Destination For Move " + .stwSemiautoTransferWafer.txtDestination.Text)
                End If
            End With
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuDstForMove_Click")
    End Sub

    Private Sub mnuSrcForMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSrcForMove.Click
        AVPLib.Log.guiLogger.Info("Enter mnuSrcForMove_Click")
        Try
            If CheckWaferIsPausingInPM() Then
                Exit Try
            End If

            With ContainerForm.CassettesPanel
                If .stwSemiautoTransferWafer.btnStart.Enabled = False AndAlso _
                Not String.IsNullOrEmpty(.stwSemiautoTransferWafer.txtSource.Text) AndAlso _
                       Not String.IsNullOrEmpty(.stwSemiautoTransferWafer.txtDestination.Text) Then ''transferring
                    Utils.ShowAVPMessageBox("Please wait for other transfer to complete...", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
                Else ''is online
                    .stwSemiautoTransferWafer.txtSource.Text = .GenerateSrcOrDst(Me.PM_Index) & ",Slot" & m_pmSlot
                    AVPLib.Utils.ShowStatusMessage("Source for Transfer Wafer: " & .stwSemiautoTransferWafer.txtSource.Text)
                    If .stwSemiautoTransferWafer.txtDestination.Text = .stwSemiautoTransferWafer.txtSource.Text Then
                        Utils.ShowAVPMessageBox("Source and Destination for Transfer Wafer are the same, Destination will be clear. " & Chr(13) & "Please select Destination for Transfer Wafer again", "Transfer Wafer", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                        .stwSemiautoTransferWafer.txtDestination.Clear()
                    End If

                    ContainerForm.CassettesPanel.ShowTransferWaferDialog()
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Select Source For Move " + .stwSemiautoTransferWafer.txtSource.Text)
                End If
            End With
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuSrcForMove_Click")
    End Sub

    Private Sub mnuUpdateWaferInfoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuUpdateWaferInfoToolStripMenuItem.Click
        AVPLib.Log.guiLogger.Info("Enter UpdateWaferInfoToolStripMenuItem_Click")
        Try
            Dim waferInfo As AVPLib.AVPWaferInfo = Nothing
            Dim equipment As AVPLib.DataManagerment.Equipment = Nothing

            '''for CX
            Dim PMIndex As String = Me.DockPosition.ToString()
            PMIndex = PMIndex.Substring(PMIndex.Length - 1)
            equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Chamber & PMIndex)

            If equipment IsNot Nothing Then
                waferInfo = equipment.GetWaferInfo(m_pmSlot)
                ' Create wafer dialog
                Dim updateWafer As WaferInfoDlg = New WaferInfoDlg(waferInfo)
                updateWafer.PMSlot = m_pmSlot
                updateWafer.PMTotalWafer = m_NumberOfWafer

                'update the wafer infomation for the chamber
                Dim dlgResult As DialogResult = updateWafer.ShowDialog()
                If dlgResult = DialogResult.OK Then
                    ContainerForm.CassettesPanel.SetWaferInside(ConstEnum.STR_UPDATE_WAFER, BinaryStatusControl.DisplayStatus.On, waferInfo, PMIndex, updateWafer.PMSlot)
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave UpdateWaferInfoToolStripMenuItem_Click")
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-09-29 </date>
    ''' </author>
    ''' <summary>
    ''' check if wafer is pausing in PM or Mechanical Aligner when transfer manual
    ''' </summary>
    Private Function CheckWaferIsPausingInPM() As Boolean
        Dim result As Boolean = False

        Try
            Dim waferID As String = String.Empty
            Dim objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Chamber & Me.PM_Index)

            If objChamber IsNot Nothing AndAlso objChamber.GetWaferInfo(m_pmSlot) IsNot Nothing Then
                waferID = objChamber.GetWaferInfo(m_pmSlot).WaferID
            End If

            result = Utils.IsWaferPausing(waferID)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return result
    End Function

#End Region

#Region "Rotating Methods"

    Public Function AddNewWafer(ByVal WaferStatus As AVPLib.ConstEnum.enumWaferStatus, ByVal sWaferID As String) As Boolean
        Dim blResult As Boolean = False
        Try
            If (CX_Supported = Support_CX.Support_CX4) Then
                If (m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count > 1) Then
                    m_lstWaferControl(0).WaferStatus = WaferStatus
                    m_lstWaferControl(0).WaferID = WaferID
                    blResult = True
                End If
            Else
                AVPLib.Log.avpLogger.Error("Do not support for this PM type")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blResult
    End Function

    Public Sub DrawAllWafer()
        If (m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count > 0) Then
            For Each Item As AVPWaferControl In m_lstWaferControl
                If (Item IsNot Nothing) Then ' AndAlso Item.WaferID = WaferID) Then
                    DrawWafer(Item)
                End If
            Next
        End If
    End Sub

    Public Sub DrawWafer(ByVal WaferPos As Int16)
        Try
            If WaferPos >= 0 AndAlso WaferPos < m_lstWaferControl.Count - 1 Then
                DrawWafer(m_lstWaferControl(WaferPos))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrawWafer(ByVal wafer As AVPWaferControl)
        Dim x_position As Int32 = 0
        Dim y_position As Int32 = 0
        Dim x_center_wafer As Single = 0
        Dim y_center_wafer As Single = 0
        Dim r_wafer As Single = WAFER_RADIUS / 2.0F
        Dim wafer_rotate_angle As Single = m_slotDistanceAngle
        Dim x_center_table As Single = bmp.Width / 2.0F
        Dim y_center_table As Single = bmp.Height / 2.0F
        Dim r_center_table As Single = 74.5
        Dim margin_distanse As Int32 = 10
        Dim center_distane As Single = r_center_table - r_wafer - margin_distanse
        Dim x_ShowSlotPos As Single = 0
        Dim y_ShowSlotPos As Single = 0
        Dim WidthOfControl As Single = 0
        ' Calculate current rotating angle of wafer at specific slot
        Dim angle As Single = wafer_rotate_angle * wafer.PositionID + m_firstSlotAngle + 360 - m_biasRotatingAngle

        wafer.Size = New Size(r_wafer * 2, r_wafer * 2)
        WidthOfControl = r_center_table - 6.5F
        'wafer.SizeControl = New Size(r_wafer * 2, r_wafer * 2)

        x_center_wafer = x_center_table + center_distane * Math.Cos(Math.PI * angle / -180)
        y_center_wafer = y_center_table + center_distane * Math.Sin(Math.PI * angle / -180)

        x_ShowSlotPos = x_center_table + (WidthOfControl) * Math.Cos(Math.PI * angle / -180)
        y_ShowSlotPos = y_center_table + (WidthOfControl) * Math.Sin(Math.PI * angle / -180)
        'wafer.ShowSlotNumber = True
        'wafer.ShowSlotPosition = New Point(CInt(x_ShowSlotPos), CInt(y_ShowSlotPos))

        x_position = x_center_wafer - r_wafer
        y_position = y_center_wafer - r_wafer
        wafer.Location = New Point(x_position, y_position)
        wafer.Visible = True
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-24 </date>
    ''' </author>
    ''' <summary>
    ''' Set location for all wafers
    ''' </summary>
    Private Sub SetLocationAllWafers()
        If (m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count > 0) Then
            For Each Item As AVPWaferControl In m_lstWaferControl
                If (Item IsNot Nothing) Then
                    Dim p As PointF = GetLocationWafer(Item.PositionID)
                    Item.Location = New Point(Convert.ToInt32(p.X), Convert.ToInt32(p.Y))
                End If
            Next
        End If
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-24 </date>
    ''' </author>
    ''' <summary>
    ''' Calculate location of wafer
    ''' </summary>
    Private Function GetLocationWafer(ByVal positionID As Integer) As PointF
        Dim rWafer As Single = WAFER_RADIUS / 2.0F
        Dim waferDistance As Single = rWafer + 10
        Dim waferLoc As PointF = GetRotatingLocation(positionID, waferDistance)
        Return New PointF(waferLoc.X - rWafer, waferLoc.Y - rWafer)
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-24 </date>
    ''' </author>
    ''' <summary>
    ''' Calculate location of wafer slot
    ''' </summary>
    Private Function GetLocationSlot(ByVal positionID As Integer) As PointF
        Dim slotDistance As Single = 6.5F
        Return GetRotatingLocation(positionID, slotDistance)
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-24 </date>
    ''' </author>
    ''' <summary>
    ''' Calculate location base on rotate angle
    ''' </summary>
    Private Overloads Function GetRotatingLocation(ByVal positionID As Integer, ByVal distance As Single) As PointF
        Dim x_center_wafer As Single = 0
        Dim y_center_wafer As Single = 0
        Dim x_center_table As Single = bmp.Width / 2.0F
        Dim y_center_table As Single = bmp.Height / 2.0F
        Dim r_center_table As Single = 74.5
        Dim center_distane As Single = r_center_table - distance
        ' Calculate current rotating angle of wafer at specific slot
        Dim angle As Single = m_slotDistanceAngle * positionID + m_firstSlotAngle + 360 - m_biasRotatingAngle

        x_center_wafer = x_center_table + center_distane * Math.Cos(Math.PI * angle / -180)
        y_center_wafer = y_center_table + center_distane * Math.Sin(Math.PI * angle / -180)

        Return New PointF(x_center_wafer, y_center_wafer)
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-26 </date>
    ''' </author>
    ''' <summary>
    ''' Calculate location base on rotate angle
    ''' </summary>
    Private Overloads Function GetRotatingLocation(ByVal angle As Single, ByVal margin As Single) As PointF
        Dim x_center_wafer As Single = 0
        Dim y_center_wafer As Single = 0
        Dim x_center_table As Single = bmp.Width / 2.0F
        Dim y_center_table As Single = bmp.Height / 2.0F
        Dim center_distane As Single = x_center_table - margin

        x_center_wafer = x_center_table + center_distane * Math.Cos(Math.PI * angle / -180)
        y_center_wafer = y_center_table + center_distane * Math.Sin(Math.PI * angle / -180)

        Return New PointF(x_center_wafer, y_center_wafer)
    End Function

#End Region


#Region "Support multi wafer"
    Public Sub SetWaferStatus(ByVal WaferIndex As Integer, ByVal eWaferStatus As AVPLib.ConstEnum.enumWaferStatus)
        Try
            If (m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count >= WaferIndex AndAlso WaferIndex > 0) Then
                If m_lstWaferControl(WaferIndex - 1).WaferStatus <> eWaferStatus Then
                    m_hasDataChanged = True
                End If
                m_lstWaferControl(WaferIndex - 1).WaferStatus = eWaferStatus
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Public Function GetWaferStatus(Optional ByVal WaferIndex As Integer = 1) As AVPLib.ConstEnum.enumWaferStatus
        Try
            If (m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count >= WaferIndex AndAlso WaferIndex > 0) Then
                Return m_lstWaferControl(WaferIndex - 1).WaferStatus
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return AVPLib.ConstEnum.enumWaferStatus.eWaferNone
    End Function

    Public Sub SetWaferID(ByVal WaferIndex As Integer, ByVal strWaferID As String)
        Try
            If (m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count >= WaferIndex AndAlso WaferIndex > 0) Then
                If m_lstWaferControl(WaferIndex - 1).WaferID = strWaferID Then
                    m_hasDataChanged = True
                End If
                m_lstWaferControl(WaferIndex - 1).WaferID = strWaferID
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Public Function GetWaferID(Optional ByVal WaferID As Integer = 1) As String
        Try
            If (m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count >= WaferID AndAlso WaferID > 0) Then
                Return m_lstWaferControl(WaferID - 1).WaferID
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-07-14 </date>
    ''' </author>
    ''' <summary>
    ''' Set wafer, label Disconnected location
    ''' </summary>
    Private Sub SetWaferLocation()
        Dim labelLoc As Point = New Point(0, 0)

        If m_ChamberType = AllChamberType.PVD4 OrElse m_ChamberType = AllChamberType.PVD5T Then
            SetLocationAllWafers()
            labelLoc = New Point(48, 9)
        Else
            Dim waferLoc As Point = New Point(0, 0)
            If m_ChamberType = AllChamberType.MECHANICAL_ALIGNER Then
                Select Case m_dockPosition
                    Case ChamberDockPositions.PM1
                        waferLoc = New Point(43, 49)
                        labelLoc = New Point(25, 25)
                    Case ChamberDockPositions.PM2
                        waferLoc = New Point(49, 45)
                        labelLoc = New Point(20, 20)
                    Case ChamberDockPositions.PM3
                        waferLoc = New Point(57, 49)
                        labelLoc = New Point(25, 25)
                End Select
            ElseIf m_ChamberType = AllChamberType.AVP_IBE OrElse m_ChamberType = AllChamberType.VEECO_IBE Then
                Select Case m_dockPosition
                    Case ChamberDockPositions.PM1
                        waferLoc = New Point(127, 97)
                        labelLoc = New Point(97, 75)
                    Case ChamberDockPositions.PM2
                        waferLoc = New Point(96, 127)
                        labelLoc = New Point(68, 103)
                    Case ChamberDockPositions.PM3
                        waferLoc = New Point(67, 95)
                        labelLoc = New Point(40, 73)
                End Select
            ElseIf m_ChamberType = AllChamberType.PVD Then
                Select Case m_dockPosition
                    Case ChamberDockPositions.PM1
                        waferLoc = New Point(139, 98)
                        labelLoc = New Point(110, 75)
                    Case ChamberDockPositions.PM2
                        waferLoc = New Point(98, 140)
                        labelLoc = New Point(70, 115)
                    Case ChamberDockPositions.PM3
                        waferLoc = New Point(59, 99)
                        labelLoc = New Point(30, 75)
                End Select
            ElseIf m_ChamberType = AllChamberType.PVDA Then
                Select Case m_dockPosition
                    Case ChamberDockPositions.PM1
                        waferLoc = New Point(116, 91)
                        labelLoc = New Point(85, 67)
                    Case ChamberDockPositions.PM2
                        waferLoc = New Point(90, 116)
                        labelLoc = New Point(60, 50)
                    Case ChamberDockPositions.PM3
                        waferLoc = New Point(66, 90)
                        labelLoc = New Point(35, 67)
                End Select
            End If
            WaferLocation = waferLoc
        End If
        LabelDisconnect_Location = labelLoc
    End Sub

    Public Function GetWaferLocation(Optional ByVal WaferID As Integer = 1) As Point
        Try
            If (m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count > WaferID AndAlso WaferID > 0) Then
                Return m_lstWaferControl(WaferID - 1).Location
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2016-01-20 </date>
    ''' </author>
    ''' <summary>
    ''' Set wafer info
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetWaferInfo(ByVal WaferIndex As Integer, ByVal eWaferStatus As AVPLib.ConstEnum.enumWaferStatus, Optional ByVal waferID As String = "", Optional ByVal isShowQM As Boolean = False)
        Try
            If (m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count >= WaferIndex AndAlso WaferIndex > 0) Then
                m_lstWaferControl(WaferIndex - 1).SetWaferInfo(eWaferStatus, waferID, isShowQM)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Huy Nguyen </name>
    '''    	<date> 2015-07-13 </date>
    ''' </author>
    ''' <summary>
    ''' Force repaint pm
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ForceRepaint()
        m_hasDataChanged = True
        Repaint()
    End Sub
#End Region

    Private Sub lblCurrentPos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCurrentPos.TextChanged
        Try

            Dim newPos As Int16 = 1
            Int16.TryParse(lblCurrentPos.Text, newPos)
            If newPos < 1 OrElse newPos > NumberOfWafer Then
                Exit Sub
            End If
            If (CurrentPosition <> newPos) Then
                CurrentPosition = newPos
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get rotation angle for PM
    ''' </summary>
    Private Function GetAngle(ByVal cx As Support_CX, ByVal pos As ChamberDockPositions) As Single
        Dim angle As Single = 0

        If cx = Support_CX.Support_CX4 Then
            Select Case pos
                Case ChamberDockPositions.PM1
                    angle = -90
                Case ChamberDockPositions.PM2
                    angle = 0
                Case ChamberDockPositions.PM3
                    angle = 90
            End Select
        End If

        Return angle
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-23 </date>
    ''' </author>
    ''' <summary>
    ''' Get first slot angle
    ''' </summary>
    Private Function GetFirstSlotAngle(ByVal pos As ChamberDockPositions) As Single
        Dim angle As Single = 0

        Select Case pos
            Case ChamberDockPositions.PM1
                angle = 0
            Case ChamberDockPositions.PM2
                angle = -90
            Case ChamberDockPositions.PM3
                angle = 180
        End Select

        Return angle
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get chamber ID of PM control
    ''' </summary>
    Private Function GetChamberID() As String
        Return "Chamber" & CInt(m_dockPosition)
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get number of Target installed (using for draw IBD image)
    ''' </summary>
    Private Sub GetNumberOfTargetInstalled()
        m_numberOfTargetInstalled = 0

        If T1Installed Then
            m_numberOfTargetInstalled += 1
        End If

        If T2Installed Then
            m_numberOfTargetInstalled += 1
        End If

        If T3Installed Then
            m_numberOfTargetInstalled += 1
        End If

        If T4Installed Then
            m_numberOfTargetInstalled += 1
        End If

        If T5Installed Then
            m_numberOfTargetInstalled += 1
        End If
    End Sub

    Private Sub PMControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetLocationAllWafers()
        Repaint()
    End Sub


    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-08 </date>
    ''' </author>
    ''' <summary>
    ''' Show disconnected label
    ''' </summary>
    Private Sub PMControl_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If m_isDisconnected Then
            e.Graphics.DrawString(lblDisconnected.Text, lblDisconnected.Font, Brushes.Red, lblDisconnected.Location)
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-08 </date>
    ''' </author>
    ''' <summary>
    ''' Repaint chamber image
    ''' </summary>
    Public Sub Repaint()
        Try
            If m_hasDataChanged Then
                Select Case m_pmPos
                    Case TypeOfAVPChamber.PVD4
                        PaintImageForPVD4()
                    Case TypeOfAVPChamber.IBE
                        PaintImageForIBE()
                    Case TypeOfAVPChamber.PVD5T
                        PaintImageForPVD5T()

                End Select
                m_hasDataChanged = False
                Me.Refresh()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-09 </date>
    ''' </author>
    ''' <summary>
    ''' Rotate image for PVD4 chamber
    ''' </summary>
    Private Function RotatePVD4Chamber(ByVal img As Image, ByVal angle As Single) As Bitmap
        Dim imgResult As New Bitmap(img.Width, img.Height)
        imgResult.SetResolution(img.HorizontalResolution, img.VerticalResolution)

        Using gr As Graphics = Graphics.FromImage(imgResult)
            Dim m As New Drawing2D.Matrix()
            m.RotateAt(angle, New PointF(img.Width / 2.0F, img.Height / 2.0F), Drawing2D.MatrixOrder.Append)
            gr.Transform = m
            gr.DrawImage(img, 0, 0)
            m.Dispose()
        End Using

        Return imgResult
    End Function

    Private Function RotateImage(ByVal image As Image, ByVal angle As Single) As Bitmap
        Try
            If image Is Nothing Then
                Throw New ArgumentNullException("image")
            End If

            Dim NewImageWidth As Integer = 0
            Dim NewImageHeight As Integer = 0
            Dim temp As Integer = CInt(Math.Sqrt((image.Width) * (image.Width) + (image.Height) * (+image.Height)))
            NewImageWidth = temp
            NewImageHeight = temp

            Dim upperLeftDrawPoint As Point = New Point(0, 0)
            Dim imageCenterOffset As Point = New Point(NewImageWidth / 2, NewImageHeight / 2)

            'create a new empty bitmap to hold rotated image
            Dim rotatedBmp As New Bitmap(NewImageWidth, NewImageHeight)
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution)

            'make a graphics object from the empty bitmap
            Dim g As Graphics = Graphics.FromImage(rotatedBmp)
            g.TranslateTransform(upperLeftDrawPoint.X + imageCenterOffset.X, upperLeftDrawPoint.Y + imageCenterOffset.Y)
            g.RotateTransform(angle)
            g.TranslateTransform((upperLeftDrawPoint.X + imageCenterOffset.X) * -1, (upperLeftDrawPoint.Y + imageCenterOffset.Y) * -1)
            g.DrawImage(image, New PointF((NewImageWidth - image.Width) / 2.0F, (NewImageHeight - image.Height) / 2.0F))
            g.Dispose()
            Return rotatedBmp
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-09 </date>
    ''' </author>
    ''' <summary>
    ''' Paint image for PVD4 chamber
    ''' </summary>
    Private Sub PaintImageForPVD4()
        Dim img_PM As Bitmap = My.Resources.Resources.PVD4_Chamber
        Dim imgBias As Bitmap = My.Resources.Resources.PVD4_Table
        If PlasmaIsOn Then
            imgBias = My.Resources.Resources.PVD4_Table_Plasma
        End If
        Dim imgTarget As Bitmap = My.Resources.Resources.PVD4_Target
        Dim imgTargetPlasma As Bitmap = My.Resources.Resources.PVD4_Target_Plasma

        bmp = New Bitmap(img_PM.Width, img_PM.Height)
        bmp.SetResolution(img_PM.HorizontalResolution, img_PM.VerticalResolution)

        Using gr As Graphics = Graphics.FromImage(bmp)
            gr.DrawImage(img_PM, 0, 0)

            Dim bias As Bitmap = GeneratePVD4Wafer(imgBias)

            gr.DrawImage(bias, 0, 0)

            If T1Installed Then
                Dim p As Point = GetTargetLocation(1)
                If T1HasPlasma Then
                    gr.DrawImage(imgTargetPlasma, p)
                Else
                    gr.DrawImage(imgTarget, p)
                End If
                p = Nothing
                DrawTargetLabel(gr, 1)
            End If

            If T2Installed Then
                Dim p As Point = GetTargetLocation(2)
                If T2HasPlasma Then
                    gr.DrawImage(imgTargetPlasma, p)
                Else
                    gr.DrawImage(imgTarget, p)
                End If
                p = Nothing
                DrawTargetLabel(gr, 2)
            End If

            If T3Installed Then
                Dim p As Point = GetTargetLocation(3)
                If T3HasPlasma Then
                    gr.DrawImage(imgTargetPlasma, p)
                Else
                    gr.DrawImage(imgTarget, p)
                End If
                p = Nothing
                DrawTargetLabel(gr, 3)
            End If

            If T4Installed Then
                Dim p As Point = GetTargetLocation(4)
                If T4HasPlasma Then
                    gr.DrawImage(imgTargetPlasma, p)
                Else
                    gr.DrawImage(imgTarget, p)
                End If
                p = Nothing
                DrawTargetLabel(gr, 4)
            End If

            bias.Dispose()
        End Using

        DrawChamber(bmp)

        img_PM = Nothing
        imgBias = Nothing
        imgTarget = Nothing
        imgTargetPlasma = Nothing
    End Sub

    ''' <author>
    '''     <name> Duc Dang </name>
    '''     <date> 2025-11-18 </date>
    ''' </author>
    ''' <summary>
    ''' Paint image for PVD5T chamber
    ''' </summary>
    Private Sub PaintImageForPVD5T()
        Dim img_PM As Bitmap = My.Resources.Resources.PVD4_Chamber
        Dim imgBias As Bitmap = My.Resources.Resources.PVD4_Table
        If PlasmaIsOn Then
            imgBias = My.Resources.Resources.PVD4_Table_Plasma
        End If
        Dim imgTarget As Bitmap = My.Resources.Resources.PVD5T_Target
        Dim imgTargetPlasma As Bitmap = My.Resources.Resources.PVD5T_Target_Plasma

        bmp = New Bitmap(img_PM.Width, img_PM.Height)
        bmp.SetResolution(img_PM.HorizontalResolution, img_PM.VerticalResolution)

        Using gr As Graphics = Graphics.FromImage(bmp)
            gr.DrawImage(img_PM, 0, 0)

            Dim bias As Bitmap = GeneratePVD4Wafer(imgBias)

            gr.DrawImage(bias, 0, 0)

            If T1Installed Then
                Dim p As Point = GetPVD5TTargetLocation(1)
                If T1HasPlasma Then
                    gr.DrawImage(imgTargetPlasma, p)
                Else
                    gr.DrawImage(imgTarget, p)
                End If
                p = Nothing
                DrawPVD5TTargetLabel(gr, 1)
            End If

            If T2Installed Then
                Dim p As Point = GetPVD5TTargetLocation(2)
                If T2HasPlasma Then
                    gr.DrawImage(imgTargetPlasma, p)
                Else
                    gr.DrawImage(imgTarget, p)
                End If
                p = Nothing
                DrawPVD5TTargetLabel(gr, 2)
            End If

            If T3Installed Then
                Dim p As Point = GetPVD5TTargetLocation(3)
                If T3HasPlasma Then
                    gr.DrawImage(imgTargetPlasma, p)
                Else
                    gr.DrawImage(imgTarget, p)
                End If
                p = Nothing
                DrawPVD5TTargetLabel(gr, 3)
            End If

            If T4Installed Then
                Dim p As Point = GetPVD5TTargetLocation(4)
                If T4HasPlasma Then
                    gr.DrawImage(imgTargetPlasma, p)
                Else
                    gr.DrawImage(imgTarget, p)
                End If
                p = Nothing
                DrawPVD5TTargetLabel(gr, 4)
            End If

            If T5Installed Then
                Dim p As Point = GetPVD5TTargetLocation(5)
                If T5HasPlasma Then
                    gr.DrawImage(imgTargetPlasma, p)
                Else
                    gr.DrawImage(imgTarget, p)
                End If
                p = Nothing
                DrawPVD5TTargetLabel(gr, 5)
            End If

            bias.Dispose()
        End Using

        DrawChamber(bmp)

        img_PM = Nothing
        imgBias = Nothing
        imgTarget = Nothing
        imgTargetPlasma = Nothing
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-05-13 </date>
    ''' </author>
    Public Sub PaintImageForIBE()
        Dim img_PM As Bitmap = My.Resources.Resources.IBE
        Dim isShutterClosed As Boolean = (m_ShutterStatus = DataManagerment.Equipment.WorkingStatuses.Off)

        ' Get IBE image base on status
        If SourceIsOn Then
            If (m_blnHasShutter OrElse m_IBEShutterOnFixture) AndAlso (isShutterClosed) Then
                img_PM = My.Resources.Resources.IBE_ShutterOnSource_Beam
            Else
                img_PM = My.Resources.Resources.IBE_Beam
            End If
        Else
            If (m_blnHasShutter OrElse m_IBEShutterOnFixture) AndAlso (isShutterClosed) Then
                img_PM = My.Resources.Resources.IBE_ShutterOnSource
            Else
                img_PM = My.Resources.Resources.IBE
            End If
        End If

        'Rotate & draw image
        DrawChamber(img_PM)

        img_PM = Nothing
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-24 </date>
    ''' </author>
    ''' <summary>
    ''' Draw chamber image 
    ''' </summary>
    Private Sub DrawChamber(ByVal chamberImage As Image)

        Dim angle As Single = GetAngle(m_supportCX, m_dockPosition)

        If Me.PM_Type = TypeOfAVPChamber.PVD4 OrElse Me.PM_Type = TypeOfAVPChamber.PVD5T Then
            bmp = RotatePVD4Chamber(chamberImage, angle)
        Else
            bmp = RotateImage(chamberImage, angle)
        End If

        If m_needCreateRegion Then
            Utils.CreateControlRegion(Me, bmp)
            m_needCreateRegion = False
        Else
            Me.BackgroundImage = bmp
        End If

    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-29 </date>
    ''' </author>
    ''' <summary>
    ''' Draw target label
    ''' </summary>
    Private Sub DrawTargetLabel(ByVal gr As Graphics, ByVal targetIndex As Integer)
        Try
            Dim margin As Integer = 8
            Dim angle As Single = m_firstSlotAngle - (targetIndex - 1) * 90
            Dim centerPoint As PointF = Me.GetRotatingLocation(angle, margin)
            Dim strTarget As String = "T" & targetIndex.ToString()
            Dim targetFont As Font = New Font("Times New Roman", 10, FontStyle.Bold)
            Dim targetSize As SizeF = gr.MeasureString(strTarget, targetFont)
            Dim targetLocation As PointF = New PointF(centerPoint.X - targetSize.Width / 2.0F, centerPoint.Y - targetSize.Height / 2.0F)
            Dim drawingMatrix As New Drawing2D.Matrix
            Dim rotatePoint As PointF = New PointF(bmp.Width / 2.0F, bmp.Height / 2.0F)
            drawingMatrix.RotateAt(-1 * m_chamberAngle, rotatePoint)
            gr.Transform = drawingMatrix
            gr.DrawString(strTarget, targetFont, Brushes.DarkBlue, targetLocation)
            gr.ResetTransform()
            centerPoint = Nothing
            targetFont.Dispose()
            targetSize = Nothing
            targetLocation = Nothing
            drawingMatrix.Dispose()
            rotatePoint = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    ''' <author>
    '''     <name> Duc Dang </name>
    '''     <date> 2025-11-18 </date>
    ''' </author>
    ''' <summary>
    ''' Draw PVD5T target label
    ''' </summary>
    Private Sub DrawPVD5TTargetLabel(ByVal gr As Graphics, ByVal targetIndex As Integer)
        Try
            Dim margin As Integer = 8
            Dim angle As Single = m_firstSlotAngle - (targetIndex + 1) * 72
            Dim centerPoint As PointF = Me.GetRotatingLocation(angle, margin)
            Dim strTarget As String = "T" & targetIndex.ToString()
            Dim targetFont As Font = New Font("Times New Roman", 10, FontStyle.Bold)
            Dim targetSize As SizeF = gr.MeasureString(strTarget, targetFont)
            Dim targetLocation As PointF = New PointF(centerPoint.X - targetSize.Width / 2.0F, centerPoint.Y - targetSize.Height / 2.0F)
            Dim drawingMatrix As New Drawing2D.Matrix
            Dim rotatePoint As PointF = New PointF(bmp.Width / 2.0F, bmp.Height / 2.0F)
            drawingMatrix.RotateAt(-1 * m_chamberAngle, rotatePoint)
            gr.Transform = drawingMatrix
            gr.DrawString(strTarget, targetFont, Brushes.DarkBlue, targetLocation)
            gr.ResetTransform()
            centerPoint = Nothing
            targetFont.Dispose()
            targetSize = Nothing
            targetLocation = Nothing
            drawingMatrix.Dispose()
            rotatePoint = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-10 </date>
    ''' </author>
    ''' <summary>
    ''' Generate Bias image
    ''' </summary>
    Private Function GeneratePVD4Wafer(ByVal imgBias As Image) As Bitmap
        Dim img As Bitmap = New Bitmap(imgBias.Width, imgBias.Height)
        img.SetResolution(imgBias.HorizontalResolution, imgBias.VerticalResolution)
        img = RotatePVD4Chamber(imgBias, m_biasRotatingAngle)

        Dim slotFont As Font = New Font("Times New Roman", 8, FontStyle.Bold)

        Using gr As Graphics = Graphics.FromImage(img)
            If m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count > 0 Then
                Dim imgSlot As Bitmap = My.Resources.Resources.PVD4_Wafer_Slot
                Dim slotMatrix As New Drawing2D.Matrix
                slotMatrix.RotateAt(-1 * m_chamberAngle, New PointF(img.Width / 2.0F, img.Height / 2.0F))
                gr.Transform = slotMatrix

                ' Draw slot label
                For i As Integer = 0 To m_NumberOfWafer - 1
                    If m_lstWaferControl(i) IsNot Nothing Then
                        Dim slotCenterLocation As PointF = GetLocationSlot(m_lstWaferControl(i).PositionID)
                        Dim slotSize As SizeF = gr.MeasureString(m_lstWaferControl(i).PMSlotNumber.ToString(), slotFont)
                        gr.DrawString(m_lstWaferControl(i).PMSlotNumber.ToString(), slotFont, Brushes.DarkBlue, slotCenterLocation.X - slotSize.Width / 2.0F, slotCenterLocation.Y - slotSize.Height / 2.0F)

                        Dim locationWafer As PointF = GetLocationWafer(m_lstWaferControl(i).PositionID)
                        gr.DrawImage(imgSlot, locationWafer.X, locationWafer.Y)
                    End If
                Next

                slotMatrix.Dispose()
                imgSlot = Nothing
            End If
        End Using

        slotFont.Dispose()

        Return img
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-09 </date>
    ''' </author>
    ''' <summary>
    ''' Target location
    ''' </summary>
    Private Function GetTargetLocation(ByVal targetIndex As Integer) As Point
        Dim location As Point = New Point(0, 0)
        Select Case targetIndex
            Case 1
                location = New Point(61, 108)
            Case 2
                location = New Point(15, 62)
            Case 3
                location = New Point(61, 15)
            Case 4
                location = New Point(107, 62)
        End Select
        Return location
    End Function

    ''' <author>
    '''     <name> Duc Dang </name>
    '''     <date> 2025-11-18 </date>
    ''' </author>
    ''' <summary>
    ''' PVD5T Target location
    ''' </summary>
    Private Function GetPVD5TTargetLocation(ByVal targetIndex As Integer) As Point
        Dim location As Point = New Point(0, 0)
        Select Case targetIndex
            Case 1
                location = New Point(39, 27)
            Case 2
                location = New Point(95, 27)
            Case 3
                location = New Point(113, 81)
            Case 4
                location = New Point(67, 114)
            Case 5
                location = New Point(21, 81)
        End Select

        Return location
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-24 </date>
    ''' </author>
    ''' <summary>
    ''' Show border for all wafers
    ''' </summary>
    Private Sub ShowBorderAllWafers(ByVal isShowBorder As Boolean)
        Try
            If m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count > 0 Then
                For i As Integer = 0 To m_NumberOfWafer - 1
                    If m_lstWaferControl(i) IsNot Nothing Then
                        m_lstWaferControl(i).IsShowBorder = isShowBorder
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-24 </date>
    ''' </author>
    ''' <summary>
    ''' Show/hide wafers
    ''' </summary>
    Private Sub VisibleAllWafers(ByVal isVisible As Boolean)
        If (m_lstWaferControl IsNot Nothing AndAlso m_lstWaferControl.Count > 0) Then
            For Each Item As AVPWaferControl In m_lstWaferControl
                If (Item IsNot Nothing) Then
                    Item.Visible = isVisible
                End If
            Next
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-27 </date>
    ''' </author>
    ''' <summary>
    ''' Set wafer status to all wafers
    ''' </summary>
    Private Sub SetWaferStatus()
        WFControl.WaferStatus = m_waferStatus
        If m_lstWaferControl IsNot Nothing Then
            For i As Int16 = 0 To m_lstWaferControl.Count - 1
                If m_lstWaferControl(i) IsNot Nothing Then
                    m_lstWaferControl(i).WaferStatus = m_waferStatus
                End If
            Next
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-01 </date>
    ''' </author>
    ''' <summary>
    ''' Update table rotate position base on current encoder count
    ''' </summary>
    Private Sub UpdateRotatePosition()
        Try
            Dim countFromHome As Single = m_currentEncoderCount Mod m_totalEncoderCount
            m_iCurrentPosition = CInt(Math.Floor(countFromHome / m_slotCountDistance)) + 1

            Dim angle As Single = (countFromHome / m_totalEncoderCount * 360)
            If GetMinimumDistanceAngle(angle, m_biasRotatingAngle) >= MIN_ANGLE_CHANGE Then
                m_biasRotatingAngle = angle
                SetLocationAllWafers()
                m_hasDataChanged = True
                Repaint()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-01 </date>
    ''' </author>
    ''' <summary>
    ''' Calculate minimum distance between two angle
    ''' </summary>
    Private Function GetMinimumDistanceAngle(ByVal angle1 As Single, ByVal angle2 As Single) As Single
        Dim result As Single = 0

        Dim d1to2 As Single = CalculateDistanceAngle(angle1, angle2)
        Dim d2to1 As Single = CalculateDistanceAngle(angle2, angle1)
        If d1to2 < d2to1 Then
            result = d1to2
        Else
            result = d2to1
        End If

        Return result
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-01 </date>
    ''' </author>
    ''' <summary>
    ''' Calculate distance between two angle by clockwise from angle1 to angle2
    ''' </summary>
    Private Function CalculateDistanceAngle(ByVal angle1 As Single, ByVal angle2 As Single)
        Dim result As Single = 0

        angle1 = angle1 Mod 360
        angle2 = angle2 Mod 360
        If angle1 < 0 Then
            angle1 = 360 + angle1
        End If

        If angle2 < 0 Then
            angle2 = 360 + angle2
        End If

        Dim distanceToZeroAngle1 As Single = 360 - angle1
        result = angle2 + distanceToZeroAngle1
        result = result Mod 360

        Return result
    End Function

    ''' <author>Dy Do</author>
    ''' <date>2017-02-22</date>
    ''' <summary>
    ''' Set location of disconnected label.
    ''' </summary>
    Private Sub SetLabelDisconnectedLocation()

        Dim labelLoc As Point = New Point(0, 0)

        Select Case m_dockPosition
            Case ChamberDockPositions.PM1
                labelLoc = New Point(50, 70)
            Case ChamberDockPositions.PM2
                labelLoc = New Point(50, 70)
            Case ChamberDockPositions.PM3
                labelLoc = New Point(50, 70)
        End Select
        LabelDisconnect_Location = labelLoc

    End Sub

    Public Sub SetDefaultStatus()
        m_ShutterStatus = DataManagerment.Equipment.WorkingStatuses.Unknown
        m_targetShutterStatus = DataManagerment.Equipment.WorkingStatuses.Unknown
        m_blnSourceIsOn = False
        m_T1HasPlasma = False
        m_T2HasPlasma = False
        m_T3HasPlasma = False
        m_T4HasPlasma = False
        'WFControl.PlasmaOn = m_isPlasmaOn
        m_currentTargetIndex = 1
        m_hasDataChanged = True
    End Sub
End Class
