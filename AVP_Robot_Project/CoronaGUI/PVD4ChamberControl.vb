Imports System.ComponentModel
Imports System.Timers
Imports AVPLib

Public Class PVD4ChamberControl
    Private Const DEFAULT_NUMBER_OF_SLOT = 8
    Private Const TABLE_UPDOWN_DISTANCE = 30
    Private Const TABLE_MAX_POSITION = 30
    Private Const TABLE_MIN_POSITION = -10

    Private m_isPlasmaOn As Boolean = False
    Private m_numberOfSlot As Integer = DEFAULT_NUMBER_OF_SLOT
    Private m_currentSlot As Integer = 1
    Private m_arrSlotLocations(DEFAULT_NUMBER_OF_SLOT) As Point
    Private m_lstWaferControl As List(Of PVD4WaferControl)
    Private m_tableHomePosition As Single = 0
    Private m_tablePosition As Single = 0
    Private m_isTableHome As Boolean = True
    Private m_waferStatus As ConstEnum.enumWaferStatus = ConstEnum.enumWaferStatus.eWaferNone
    Private m_shutter1Visible As Boolean = True
    Private m_shutter2Visible As Boolean = True
    Private m_shutter3Visible As Boolean = True
    Private m_shutter4Visible As Boolean = True
    Private m_slitValveStatus As DisplayStatus = DisplayStatus.Unknow
    Private m_shutter1Status As DisplayStatus = DisplayStatus.Unknow
    Private m_shutter2Status As DisplayStatus = DisplayStatus.Unknow
    Private m_shutter3Status As DisplayStatus = DisplayStatus.Unknow
    Private m_shutter4Status As DisplayStatus = DisplayStatus.Unknow
    Private m_tableMaxPosition As Single = TABLE_MAX_POSITION
    Private m_tableMinPosition As Single = TABLE_MIN_POSITION

    ' Drawing varibles
    Private imgCtrl As Bitmap = Nothing
    Private m_needCreateRegion As Boolean = True
    Private m_hasDataChanged As Boolean = True
    Private m_currentLiftDistance As Single = 0

    Public Event PlasmaStatusChanged(ByVal sender As Object)

#Region "Config Properties"
    <DefaultValue(GetType(Single), "30")> _
    Public Property TableMaxPosition() As Single
        Get
            Return m_tableMaxPosition
        End Get
        Set(ByVal value As Single)
            If m_tableMaxPosition <> value AndAlso value > m_tableMinPosition Then
                m_tableMaxPosition = value
                ' Update position
                If m_tablePosition > m_tableMaxPosition Then
                    m_tablePosition = m_tableMaxPosition
                End If
                LiftToPosition(m_tablePosition)
            End If
        End Set
    End Property

    <DefaultValue(GetType(Single), "-10")> _
    Public Property TableMinPosition() As Single
        Get
            Return m_tableMinPosition
        End Get
        Set(ByVal value As Single)
            If m_tableMinPosition <> value AndAlso value < m_tableMaxPosition Then
                m_tableMinPosition = value
                ' Update position
                If m_tablePosition < m_tableMinPosition Then
                    m_tablePosition = m_tableMinPosition
                End If
                LiftToPosition(m_tablePosition)
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Public Property Shutter1Visible() As Boolean
        Get
            Return m_shutter1Visible
        End Get
        Set(ByVal value As Boolean)
            If m_shutter1Visible <> value Then
                m_shutter1Visible = value
                Shutter1.Visible = m_shutter1Visible
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Public Property Shutter2Visible() As Boolean
        Get
            Return m_shutter2Visible
        End Get
        Set(ByVal value As Boolean)
            If m_shutter2Visible <> value Then
                m_shutter2Visible = value
                Shutter2.Visible = m_shutter2Visible
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Public Property Shutter3Visible() As Boolean
        Get
            Return m_shutter3Visible
        End Get
        Set(ByVal value As Boolean)
            If m_shutter3Visible <> value Then
                m_shutter3Visible = value
                Shutter3.Visible = m_shutter3Visible
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Public Property Shutter4Visible() As Boolean
        Get
            Return m_shutter4Visible
        End Get
        Set(ByVal value As Boolean)
            If m_shutter4Visible <> value Then
                m_shutter4Visible = value
                Shutter4.Visible = m_shutter4Visible
            End If
        End Set
    End Property

    <DefaultValue(GetType(Single), "0")> _
    Public Property TableHomePosition() As Single
        Get
            Return m_tableHomePosition
        End Get
        Set(ByVal value As Single)
            If m_tableHomePosition <> value Then
                m_tableHomePosition = value
                m_isTableHome = (m_tablePosition = m_tableHomePosition)
            End If
        End Set
    End Property

    <DefaultValue(GetType(Integer), "8")> _
    Public Property NumberOfWafer() As Integer
        Get
            Return m_numberOfSlot
        End Get
        Set(ByVal value As Integer)
            If m_numberOfSlot <> value AndAlso value > 0 Then
                m_numberOfSlot = value
                ReDim m_arrSlotLocations(m_numberOfSlot)
                CalcSlotLocation()
                InitializeWaferControl()
                SetLocationAllWafers()
                m_hasDataChanged = True
                Repaint()
            End If
        End Set
    End Property

#End Region

#Region "Status Properties"
    <DefaultValue(GetType(Integer), "1")> _
    Public Property CurrentSlot() As Integer
        Get
            Return m_currentSlot
        End Get
        Set(ByVal value As Integer)
            If m_currentSlot <> value AndAlso value > 0 AndAlso value <= m_numberOfSlot Then
                m_currentSlot = value

                StartRotate()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Single), "0")> _
    Public Property TableCurrentPosition() As Single
        Get
            Return m_tablePosition
        End Get
        Set(ByVal value As Single)
            If value < m_tableMinPosition Then
                value = m_tableMinPosition
            ElseIf value > m_tableMaxPosition Then
                value = m_tableMaxPosition
            End If
            If m_tablePosition <> value Then
                m_tablePosition = value
                m_isTableHome = (m_tablePosition = m_tableHomePosition)

                LiftToPosition(m_tablePosition)
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property BiasPlasmaOn() As Boolean
        Get
            Return m_isPlasmaOn
        End Get
        Set(ByVal value As Boolean)
            If m_isPlasmaOn <> value Then
                m_isPlasmaOn = value
                m_hasDataChanged = True

                Repaint()
                Try
                    RaiseEvent PlasmaStatusChanged(Me)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Public Property IsTableHome() As Boolean
        Get
            Return m_isTableHome
        End Get
        Set(ByVal value As Boolean)
            If m_isTableHome <> value Then
                m_isTableHome = value

                If m_isTableHome Then
                    m_tablePosition = m_tableHomePosition
                    LiftToPosition(m_tableHomePosition)
                End If
            End If
        End Set
    End Property

    <DefaultValue(GetType(ConstEnum.enumWaferStatus), "eWaferNone")> _
    Public Property WaferStatus() As ConstEnum.enumWaferStatus
        Get
            Return m_waferStatus
        End Get
        Set(ByVal value As ConstEnum.enumWaferStatus)
            If m_waferStatus <> value Then
                m_waferStatus = value

                For index As Integer = 0 To m_numberOfSlot - 1
                    m_lstWaferControl(index).Status = m_waferStatus
                Next
            End If
        End Set
    End Property

    <DefaultValue(GetType(DisplayStatus), "Unknow")> _
    Public Property Shutter1Status() As DisplayStatus
        Get
            Return m_shutter1Status
        End Get
        Set(ByVal value As DisplayStatus)
            If m_shutter1Status <> value Then
                m_shutter1Status = value
                Shutter1.Status = m_shutter1Status
            End If
        End Set
    End Property

    <DefaultValue(GetType(DisplayStatus), "Unknow")> _
    Public Property Shutter2Status() As DisplayStatus
        Get
            Return m_shutter2Status
        End Get
        Set(ByVal value As DisplayStatus)
            If m_shutter2Status <> value Then
                m_shutter2Status = value
                Shutter2.Status = m_shutter2Status
            End If
        End Set
    End Property

    <DefaultValue(GetType(DisplayStatus), "Unknow")> _
    Public Property Shutter3Status() As DisplayStatus
        Get
            Return m_shutter3Status
        End Get
        Set(ByVal value As DisplayStatus)
            If m_shutter3Status <> value Then
                m_shutter3Status = value
                Shutter3.Status = m_shutter3Status
            End If
        End Set
    End Property

    <DefaultValue(GetType(DisplayStatus), "Unknow")> _
    Public Property Shutter4Status() As DisplayStatus
        Get
            Return m_shutter4Status
        End Get
        Set(ByVal value As DisplayStatus)
            If m_shutter4Status <> value Then
                m_shutter4Status = value
                Shutter4.Status = m_shutter4Status
            End If
        End Set
    End Property

    <DefaultValue(GetType(DisplayStatus), "Unknow")> _
    Public Property SlitValveStatus() As DisplayStatus
        Get
            Return m_slitValveStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_slitValveStatus <> value Then
                m_slitValveStatus = value
                btnMesaValve.Status = m_slitValveStatus
            End If
        End Set
    End Property

    Public WriteOnly Property SlotxStatus(ByVal x As Byte) As ConstEnum.enumWaferStatus
        Set(ByVal value As ConstEnum.enumWaferStatus)
            Select Case x
                Case 1
                    Wafer1.Status = value
                Case 2
                    Wafer2.Status = value
                Case 3
                    Wafer3.Status = value
                Case 4
                    Wafer4.Status = value
                Case 5
                    Wafer5.Status = value
                Case 6
                    Wafer6.Status = value
                Case 7
                    Wafer7.Status = value
                Case 8
                    Wafer8.Status = value
            End Select
        End Set
    End Property

    Public WriteOnly Property SlotxWaferID(ByVal x As Byte) As String
        Set(ByVal value As String)
            Select Case x
                Case 1
                    Wafer1.ID = value
                Case 2
                    Wafer2.ID = value
                Case 3
                    Wafer3.ID = value
                Case 4
                    Wafer4.ID = value
                Case 5
                    Wafer5.ID = value
                Case 6
                    Wafer6.ID = value
                Case 7
                    Wafer7.ID = value
                Case 8
                    Wafer8.ID = value
            End Select
        End Set
    End Property

#End Region

#Region "Paint Control Methods"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Paint control base on status data
    ''' </summary>
    Public Sub Repaint()
        Try
            If m_hasDataChanged Then
                PaintImage()
                m_hasDataChanged = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Paint wafer image
    ''' </summary>
    Private Sub PaintImage()
        Dim imgChamber As Bitmap = My.Resources.Resources.PVD4Chamber
        Dim imgTable As Bitmap = GenerateWaferTable()

        Dim tempImg As Bitmap = imgCtrl
        imgCtrl = New Bitmap(imgChamber.Width, imgChamber.Height)
        imgCtrl.SetResolution(imgChamber.HorizontalResolution, imgChamber.VerticalResolution)

        Using gr As Graphics = Graphics.FromImage(imgCtrl)
            gr.DrawImage(imgChamber, 0, 0, imgChamber.Width, imgChamber.Height)
            gr.DrawImage(imgTable, 0, 0, imgTable.Width, imgTable.Height)
        End Using

        If m_needCreateRegion Then
            Utils.CreateControlRegion(Me, imgCtrl)
            m_needCreateRegion = False
        Else
            Me.BackgroundImage = imgCtrl
            Me.Refresh()
        End If

        imgChamber = Nothing
        imgTable = Nothing

        ' Release preview image.
        If tempImg IsNot Nothing Then
            tempImg.Dispose()
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Create table image
    ''' </summary>
    Private Function GenerateWaferTable() As Bitmap
        Dim imgWaferSlot As Bitmap = My.Resources.Resources.PVD4Chamber_WaferSlot
        Dim imgWaferTable As Bitmap = My.Resources.Resources.PVD4Chamber_WaferTable
        If m_isPlasmaOn Then
            imgWaferTable = My.Resources.Resources.PVD4Chamber_WaferTable_Plasma
        End If

        Dim img As Bitmap = New Bitmap(imgWaferTable.Width, imgWaferTable.Height)
        img.SetResolution(imgWaferTable.HorizontalResolution, imgWaferTable.VerticalResolution)

        Using gr As Graphics = Graphics.FromImage(img)
            gr.DrawImage(imgWaferTable, 0, -1 * m_currentLiftDistance)

            ' Draw slots
            If m_numberOfSlot = 8 Then
                gr.DrawImage(imgWaferSlot, m_arrSlotLocations(6))
                gr.DrawImage(imgWaferSlot, m_arrSlotLocations(5))
                gr.DrawImage(imgWaferSlot, m_arrSlotLocations(7))
                gr.DrawImage(imgWaferSlot, m_arrSlotLocations(0))
                gr.DrawImage(imgWaferSlot, m_arrSlotLocations(4))
                gr.DrawImage(imgWaferSlot, m_arrSlotLocations(3))
                gr.DrawImage(imgWaferSlot, m_arrSlotLocations(1))
                gr.DrawImage(imgWaferSlot, m_arrSlotLocations(2))
            Else
                For slotIndex As Integer = 0 To m_numberOfSlot - 1
                    gr.DrawImage(imgWaferSlot, m_arrSlotLocations(slotIndex))
                Next
            End If

        End Using

        imgWaferSlot = Nothing
        imgWaferTable = Nothing
        Return img
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Get home position location of wafer
    ''' </summary>
    Private Function GetSlotDefaultLocation(ByVal slot As Integer) As Point
        Dim p As Point = New Point(0, 0)
        If m_numberOfSlot = 8 Then
            Select Case slot
                Case 1
                    p = New Point(90, 172)
                Case 2
                    p = New Point(108, 185)
                Case 3
                    p = New Point(173, 191)
                Case 4
                    p = New Point(244, 188)
                Case 5
                    p = New Point(282, 177)
                Case 6
                    p = New Point(263, 165)
                Case 7
                    p = New Point(199, 159)
                Case 8
                    p = New Point(127, 162)
            End Select
        ElseIf m_numberOfSlot = 6 Then
            Select Case slot
                Case 1
                    p = New Point(84, 177)
                Case 2
                    p = New Point(149, 190)
                Case 3
                    p = New Point(226, 190)
                Case 4
                    p = New Point(289, 177)
                Case 5
                    p = New Point(223, 165)
                Case 6
                    p = New Point(146, 165)
            End Select
        ElseIf m_numberOfSlot = 4 Then
            Select Case slot
                Case 1
                    p = New Point(90, 172)
                Case 2
                    p = New Point(173, 191)
                Case 3
                    p = New Point(282, 177)
                Case 4
                    p = New Point(199, 159)
            End Select
        ElseIf m_numberOfSlot = 2 Then
            Select Case slot
                Case 1
                    p = New Point(90, 172)
                Case 2
                    p = New Point(282, 177)
            End Select
        ElseIf m_numberOfSlot = 1 Then
            p = New Point(90, 172)
        End If
        Return p
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Calculate slot locations base on current table location and set it to array
    ''' </summary>
    Private Sub CalcSlotLocation()
        Try
            Dim location As Point
            Dim currentSlot As Integer = m_currentSlot
            Dim index As Integer = 0
            While index < m_numberOfSlot
                location = GetSlotDefaultLocation(index + 1)
                m_arrSlotLocations(currentSlot - 1) = New Point(location.X, location.Y - m_currentLiftDistance)

                currentSlot += 1
                index += 1

                If currentSlot > m_numberOfSlot Then
                    currentSlot = 1
                End If
            End While
            location = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Get wafer location
    ''' </summary>
    Private Function GetWaferLocation(ByVal slot As Integer) As Point
        Try
            If slot > 0 AndAlso slot <= m_numberOfSlot Then
                Dim viewSlot As Integer = slot - 1
                Dim slotLocation As Point = m_arrSlotLocations(viewSlot)
                Return New Point(slotLocation.X + 1, slotLocation.Y)
            End If
            Return New Point(0, 0)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Set location for all wafer controls
    ''' </summary>
    Private Sub SetLocationAllWafers()
        For index As Integer = 0 To m_lstWaferControl.Count - 1
            m_lstWaferControl(index).Location = GetWaferLocation(m_lstWaferControl(index).PositionSlot)
        Next
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Initialize wafers
    ''' </summary>
    Private Sub InitializeWaferControl()
        If m_lstWaferControl IsNot Nothing Then
            m_lstWaferControl.Clear()
        Else
            m_lstWaferControl = New List(Of PVD4WaferControl)
        End If

        Wafer1.Visible = True
        Wafer2.Visible = True
        Wafer3.Visible = True
        Wafer4.Visible = True
        Wafer5.Visible = True
        Wafer6.Visible = True
        Wafer7.Visible = True
        Wafer8.Visible = True
        Select Case m_numberOfSlot
            Case 8
                m_lstWaferControl.Add(Wafer1)
                m_lstWaferControl.Add(Wafer2)
                m_lstWaferControl.Add(Wafer3)
                m_lstWaferControl.Add(Wafer4)
                m_lstWaferControl.Add(Wafer5)
                m_lstWaferControl.Add(Wafer6)
                m_lstWaferControl.Add(Wafer7)
                m_lstWaferControl.Add(Wafer8)
            Case 7
                m_lstWaferControl.Add(Wafer1)
                m_lstWaferControl.Add(Wafer2)
                m_lstWaferControl.Add(Wafer3)
                m_lstWaferControl.Add(Wafer4)
                m_lstWaferControl.Add(Wafer5)
                m_lstWaferControl.Add(Wafer6)
                m_lstWaferControl.Add(Wafer7)
                Wafer8.Visible = False
            Case 6
                m_lstWaferControl.Add(Wafer1)
                m_lstWaferControl.Add(Wafer2)
                m_lstWaferControl.Add(Wafer3)
                m_lstWaferControl.Add(Wafer4)
                m_lstWaferControl.Add(Wafer5)
                m_lstWaferControl.Add(Wafer6)
                Wafer7.Visible = False
                Wafer8.Visible = False
            Case 5
                m_lstWaferControl.Add(Wafer1)
                m_lstWaferControl.Add(Wafer2)
                m_lstWaferControl.Add(Wafer3)
                m_lstWaferControl.Add(Wafer4)
                m_lstWaferControl.Add(Wafer5)
                Wafer6.Visible = False
                Wafer7.Visible = False
                Wafer8.Visible = False
            Case 4
                m_lstWaferControl.Add(Wafer1)
                m_lstWaferControl.Add(Wafer2)
                m_lstWaferControl.Add(Wafer3)
                m_lstWaferControl.Add(Wafer4)
                Wafer5.Visible = False
                Wafer6.Visible = False
                Wafer7.Visible = False
                Wafer8.Visible = False
            Case 3
                m_lstWaferControl.Add(Wafer1)
                m_lstWaferControl.Add(Wafer2)
                m_lstWaferControl.Add(Wafer3)
                Wafer4.Visible = False
                Wafer5.Visible = False
                Wafer6.Visible = False
                Wafer7.Visible = False
                Wafer8.Visible = False
            Case 2
                m_lstWaferControl.Add(Wafer1)
                m_lstWaferControl.Add(Wafer2)
                Wafer3.Visible = False
                Wafer4.Visible = False
                Wafer5.Visible = False
                Wafer6.Visible = False
                Wafer7.Visible = False
                Wafer8.Visible = False
            Case 1
                m_lstWaferControl.Add(Wafer1)
                Wafer2.Visible = False
                Wafer3.Visible = False
                Wafer4.Visible = False
                Wafer5.Visible = False
                Wafer6.Visible = False
                Wafer7.Visible = False
                Wafer8.Visible = False
        End Select
        m_lstWaferControl.TrimExcess()
    End Sub

#End Region

#Region "Lift Table Methods"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Lift table to position
    ''' </summary>
    Private Sub LiftToPosition(ByVal position As Single)
        m_currentLiftDistance = GetLiftPosition(m_tablePosition)
        CalcSlotLocation()
        SetLocationAllWafers()
        m_hasDataChanged = True
        Repaint()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-08-07 </date>
    ''' </author>
    ''' <summary>
    ''' Calculate lift position base on real position
    ''' </summary>
    Private Function GetLiftPosition(ByVal position As Single) As Single
        Return TABLE_UPDOWN_DISTANCE / (m_tableMaxPosition - m_tableMinPosition) * position - TABLE_UPDOWN_DISTANCE / (m_tableMaxPosition - m_tableMinPosition) * m_tableMinPosition
    End Function

#End Region

#Region "Rotate Table Methods"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Rotate table to slot
    ''' </summary>
    Private Sub StartRotate()
        CalcSlotLocation()
        SetLocationAllWafers()
        m_hasDataChanged = True
        Repaint()
    End Sub

#End Region

#Region "Events"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DoubleBuffered = True
        InitializeWaferControl()

    End Sub

    Private Sub PVD4ChamberControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LiftToPosition(m_tablePosition)

        btnMesaValve.Location = New Point(28, 116)
        Shutter1.Location = New Point(69, 94)
        Shutter2.Location = New Point(178, 84)
        Shutter3.Location = New Point(261, 99)
        Shutter4.Location = New Point(152, 108)
        btnCtxMenu.Location = New Point(10, 194)
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Tool button click event
    ''' </summary>
    Private Sub btnCtxMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtxMenu.Click
        Try
            Dim CoronaParent As CoronaPanel = ContainerForm.ChamberPanel(Me.Parent.Name) ''must be Corona Panel
            If CoronaParent Is Nothing Then
                Exit Sub
            End If

            If CoronaParent IsNot Nothing Then
                CoronaParent.PopUpPanel.StartPosition = FormStartPosition.CenterScreen
                CoronaParent.PopUpPanel.ShowDialog(CoronaParent)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Click event for wafer
    ''' </summary>
    Private Sub Wafer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    Wafer1.Click, Wafer2.Click, Wafer3.Click, Wafer4.Click, Wafer5.Click, Wafer6.Click, Wafer7.Click, Wafer8.Click
        Dim chamberName As String = Me.Parent.Name

        Dim equipment As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(chamberName)
        If equipment IsNot Nothing Then
            Dim waferInfo As AVPLib.AVPWaferInfo = Nothing
            Dim slot As Byte = 0
            Select Case sender.Name.ToString
                Case "Wafer1"
                    waferInfo = equipment.GetWaferInfo(1)
                    slot = 1
                Case "Wafer2"
                    waferInfo = equipment.GetWaferInfo(2)
                    slot = 2
                Case "Wafer3"
                    waferInfo = equipment.GetWaferInfo(3)
                    slot = 3
                Case "Wafer4"
                    waferInfo = equipment.GetWaferInfo(4)
                    slot = 4
                Case "Wafer5"
                    waferInfo = equipment.GetWaferInfo(5)
                    slot = 5
                Case "Wafer6"
                    waferInfo = equipment.GetWaferInfo(6)
                    slot = 6
                Case "Wafer7"
                    waferInfo = equipment.GetWaferInfo(7)
                    slot = 7
                Case "Wafer8"
                    waferInfo = equipment.GetWaferInfo(8)
                    slot = 8
            End Select
            If waferInfo Is Nothing Then
                Exit Sub
            End If
            ' Create wafer dialog
            Dim updateWafer As WaferInfoDlg = New WaferInfoDlg(slot, waferInfo, True)
            'updateWafer.ShowDialog()
            If (updateWafer.ShowDialog() = DialogResult.OK) Then
                'update the wafer infomation for the chamber
                Dim ChamberIndex As String = chamberName.Replace(ConstantAndEnum.CHAMBER, "")
                If (ChamberIndex <> String.Empty) Then
                    ContainerForm.CassettesPanel.SetWaferInside(ConstEnum.STR_UPDATE_WAFER, BinaryStatusControl.DisplayStatus.On, waferInfo, ChamberIndex, slot)
                End If
            End If
        End If
    End Sub
#End Region

#Region "Status Methods"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-30 </date>
    ''' </author>
    ''' <summary>
    ''' Create status handler
    ''' </summary>
    Protected Overrides Sub CreateStatusTree()
        Try
            MyBase.CreateStatusTree()
            Dim sShutter1 As New SL_StatusValve(Shutter1)
            Dim sShutter2 As New SL_StatusValve(Shutter2)
            Dim sShutter3 As New SL_StatusValve(Shutter3)
            Dim sShutter4 As New SL_StatusValve(Shutter4)

            Dim sWafer1 As New StatusPVD4Wafer(Wafer1)

            m_stoStatusObject.AddChild(sWafer1)
            m_stoStatusObject.AddChild(sShutter1)
            m_stoStatusObject.AddChild(sShutter2)
            m_stoStatusObject.AddChild(sShutter3)
            m_stoStatusObject.AddChild(sShutter4)

            Shutter1.ParentStatusObj = m_stoStatusObject
            Shutter2.ParentStatusObj = m_stoStatusObject
            Shutter3.ParentStatusObj = m_stoStatusObject
            Shutter4.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-30 </date>
    ''' </author>
    ''' <summary>
    ''' Set Online/Offline
    ''' </summary>
    Public Sub SetOnlineOfflineContainerBox(ByVal blnIsOnline As Boolean)
        Shutter1.Enabled = Not blnIsOnline
        Shutter2.Enabled = Not blnIsOnline
        Shutter3.Enabled = Not blnIsOnline
        Shutter4.Enabled = Not blnIsOnline
        btnMesaValve.Enabled = Not blnIsOnline
        Wafer1.Enabled = Not blnIsOnline
        Wafer2.Enabled = Not blnIsOnline
        Wafer3.Enabled = Not blnIsOnline
        Wafer4.Enabled = Not blnIsOnline
        Wafer5.Enabled = Not blnIsOnline
        Wafer6.Enabled = Not blnIsOnline
        Wafer7.Enabled = Not blnIsOnline
        Wafer8.Enabled = Not blnIsOnline
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-08-04 </date>
    ''' </author>
    ''' <summary>
    ''' Update property when Plasma status changed
    ''' </summary>
    Private Sub btnBiasPlasmaStatus_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBiasPlasmaStatus.StatusChange
        Dim plasmaOn As Boolean
        If Utils.TryParseToBoolean(btnBiasPlasmaStatus.Status, plasmaOn) Then
            BiasPlasmaOn = plasmaOn
        End If
    End Sub
#End Region

End Class
