Imports System.Linq
Imports AVPLib.Business

Public Class PVD5T_ChamberInterlock

#Region "Property"
    Private m_blnAirPressureVisible As Boolean = False
    Private m_blnTurboWaterVisible As Boolean = False
    Private m_blnTargetMBWaterVisible As Boolean = False
    Private m_blnBiasMBWaterVisible As Boolean = False
    Private m_blnTarget13WaterVisible As Boolean = False
    Private m_blnTarget24WaterVisible As Boolean = False
    Private m_blnTarget3WaterVisible As Boolean = False
    Private m_blnTarget4WaterVisible As Boolean = False
    Private m_blnTarget5WaterVisible As Boolean = False
    Private m_blnSubTableWaterVisible As Boolean = False
    Private m_blnTurboForelineVisible As Boolean = True

    Const BASIC_HEIGHT As Integer = 45
    Const BUTTON_DIST As Integer = 21
    Private m_lblArrayLocation As New ArrayList ''store Array location for Label
    Private m_bicArrayLocation As New ArrayList ''store Array location for button

    Private m_blnIsOnline As Boolean = False
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnPSRelay.Enabled = Not (m_blnIsOnline)
        End Set
    End Property

    Public Property AirPressure_Visible() As Boolean
        Get
            Return m_blnAirPressureVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnAirPressureVisible = value
            lblAirPressure.Visible = value
            bicAirPressure.Visible = value
        End Set
    End Property

    Public Property TurboWater_Visible() As Boolean
        Get
            Return m_blnTurboWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTurboWaterVisible = value
            lblTurboWater.Visible = value
            bicTurboWater.Visible = value
        End Set
    End Property

    Public Property TargetMBWater_Visible() As Boolean
        Get
            Return m_blnTargetMBWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTargetMBWaterVisible = value
            lblMB1Water.Visible = value
            bicTargetMBWater.Visible = value
        End Set
    End Property

    Public Property BiasMBWater_Visible() As Boolean
        Get
            Return m_blnBiasMBWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnBiasMBWaterVisible = value
            lblMB2Water.Visible = value
            bicBiasMBWater.Visible = value
        End Set
    End Property

    Public Property Target1Water_Visible() As Boolean
        Get
            Return m_blnTarget13WaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTarget13WaterVisible = value
            lblTarget1Water.Visible = value
            bicTarget1Water.Visible = value
        End Set
    End Property

    Public Property Target2Water_Visible() As Boolean
        Get
            Return m_blnTarget24WaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTarget24WaterVisible = value
            lblTarget2Water.Visible = value
            bicTarget2Water.Visible = value
        End Set
    End Property

    Public Property Target3Water_Visible() As Boolean
        Get
            Return m_blnTarget3WaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTarget3WaterVisible = value
            lblTarget3Water.Visible = value
            bicTarget3Water.Visible = value
        End Set
    End Property

    Public Property Target4Water_Visible() As Boolean
        Get
            Return m_blnTarget4WaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTarget4WaterVisible = value
            lblTarget4Water.Visible = value
            bicTarget4Water.Visible = value
        End Set
    End Property

    Public Property Target5Water_Visible() As Boolean
        Get
            Return m_blnTarget5WaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTarget5WaterVisible = value
            lblTarget5Water.Visible = value
            bicTarget5Water.Visible = value
        End Set
    End Property

    Public Property SubTableWater_Visible() As Boolean
        Get
            Return m_blnSubTableWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnSubTableWaterVisible = value
            lblSubTableWater.Visible = value
            bicSubTableWater.Visible = value
        End Set
    End Property

    Public Property TurboForeline_Visible() As Boolean
        Get
            Return m_blnTurboForelineVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTurboForelineVisible = value
            lblTurboForeline.Visible = value
            bicTurboForeline.Visible = value
        End Set
    End Property
#End Region

    Protected Overrides Sub CreateStatusTree()
        Try
            MyBase.CreateStatusTree()
            m_stoStatusObject.Name = Me.Name
            Dim sPSRelay As New StatusCoronaButton(btnPSRelay)
            Dim sTurboWater As New StatusCoronaButton(bicTurboWater)
            Dim sLidClosed As New StatusCoronaButton(bicLidClosed)
            Dim sTargetPanels As New StatusCoronaButton(bicTargetPanels)
            Dim sAirPressure As New StatusCoronaButton(bicAirPressure)
            Dim sSubTableWater As New StatusCoronaButton(bicSubTableWater)
            Dim sDeviceNetCom As New StatusCoronaButton(bicDeviceNetCom)
            Dim sChamberPress As New StatusCoronaButton(bicChamberPress)
            Dim sTurboForeline As New StatusCoronaButton(bicTurboForeline)
            Dim sTargetMBWater As New StatusCoronaButton(bicTargetMBWater)
            Dim sBiasMBWater As New StatusCoronaButton(bicBiasMBWater)
            Dim sTarget1Water As New StatusCoronaButton(bicTarget1Water)
            Dim sTarget2Water As New StatusCoronaButton(bicTarget2Water)
            Dim sTarget3Water As New StatusCoronaButton(bicTarget3Water)
            Dim sTarget4Water As New StatusCoronaButton(bicTarget4Water)
            Dim sTarget5Water As New StatusCoronaButton(bicTarget5Water)

            m_stoStatusObject.AddChild(sPSRelay)
            m_stoStatusObject.AddChild(sTurboWater)
            m_stoStatusObject.AddChild(sLidClosed)
            m_stoStatusObject.AddChild(sTargetPanels)
            m_stoStatusObject.AddChild(sAirPressure)
            m_stoStatusObject.AddChild(sSubTableWater)
            m_stoStatusObject.AddChild(sDeviceNetCom)
            m_stoStatusObject.AddChild(sChamberPress)
            m_stoStatusObject.AddChild(sTurboForeline)
            m_stoStatusObject.AddChild(sTargetMBWater)
            m_stoStatusObject.AddChild(sBiasMBWater)
            m_stoStatusObject.AddChild(sTarget1Water)
            m_stoStatusObject.AddChild(sTarget2Water)
            m_stoStatusObject.AddChild(sTarget3Water)
            m_stoStatusObject.AddChild(sTarget4Water)
            m_stoStatusObject.AddChild(sTarget5Water)

            btnPSRelay.ParentStatusObj = m_stoStatusObject
            bicLidClosed.ParentStatusObj = m_stoStatusObject
            bicTurboWater.ParentStatusObj = m_stoStatusObject
            bicTargetPanels.ParentStatusObj = m_stoStatusObject
            bicAirPressure.ParentStatusObj = m_stoStatusObject
            bicSubTableWater.ParentStatusObj = m_stoStatusObject
            bicDeviceNetCom.ParentStatusObj = m_stoStatusObject
            bicChamberPress.ParentStatusObj = m_stoStatusObject
            bicTurboForeline.ParentStatusObj = m_stoStatusObject
            bicTargetMBWater.ParentStatusObj = m_stoStatusObject
            bicBiasMBWater.ParentStatusObj = m_stoStatusObject
            bicTarget1Water.ParentStatusObj = m_stoStatusObject
            bicTarget2Water.ParentStatusObj = m_stoStatusObject
            bicTarget3Water.ParentStatusObj = m_stoStatusObject
            bicTarget4Water.ParentStatusObj = m_stoStatusObject
            bicTarget5Water.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeInterlockControls()

        ''4 basic interlock
        Me.m_lblArrayLocation.Add(lblSubTableWater.Location) '0
        Me.m_lblArrayLocation.Add(lblAirPressure.Location) '1
        Me.m_lblArrayLocation.Add(lblTurboWater.Location) '2

        Me.m_lblArrayLocation.Add(lblMB1Water.Location) '3
        Me.m_lblArrayLocation.Add(lblMB2Water.Location) '4
        Me.m_lblArrayLocation.Add(lblTarget1Water.Location) '5
        Me.m_lblArrayLocation.Add(lblTarget2Water.Location) '6
        Me.m_lblArrayLocation.Add(lblTarget3Water.Location) '7
        Me.m_lblArrayLocation.Add(lblTarget4Water.Location) '8
        Me.m_lblArrayLocation.Add(lblTarget5Water.Location) '9
        Me.m_lblArrayLocation.Add(lblPSRelay.Location) '10

        Me.m_bicArrayLocation.Add(bicSubTableWater.Location) '0
        Me.m_bicArrayLocation.Add(bicAirPressure.Location) '1
        Me.m_bicArrayLocation.Add(bicTurboWater.Location) '2

        Me.m_bicArrayLocation.Add(bicTargetMBWater.Location) '3
        Me.m_bicArrayLocation.Add(bicBiasMBWater.Location) '4
        Me.m_bicArrayLocation.Add(bicTarget1Water.Location) '5
        Me.m_bicArrayLocation.Add(bicTarget2Water.Location) '6
        Me.m_bicArrayLocation.Add(bicTarget3Water.Location) '7
        Me.m_bicArrayLocation.Add(bicTarget4Water.Location) '8
        Me.m_bicArrayLocation.Add(bicTarget5Water.Location) '9
        Me.m_bicArrayLocation.Add(btnPSRelay.Location) '10

        ' Add any initialization after the InitializeComponent() call.
    End Sub


#Region "Function"
    ' Add this helper class at the module level or as a nested class
    Private Class InterlockControl
        Public Label As Label
        Public Button As Control
        Public VisibilityProperty As Func(Of Boolean)
        Public LocationLable As New System.Drawing.Point(0, 0)
        Public LocationButton As New System.Drawing.Point(0, 0)

        Public Sub New(lbl As Label, btn As Control, visibilityFunc As Func(Of Boolean))
            Me.Label = lbl
            Me.LocationLable = lbl.Location
            Me.Button = btn
            Me.LocationButton = btn.Location
            Me.VisibilityProperty = visibilityFunc
        End Sub
    End Class

    ' Add this field to replace the manual ArrayList approach
    Private m_interlockControls As List(Of InterlockControl)

    ' Call this method from the constructor to initialize the control collection
    Private Sub InitializeInterlockControls()
        ' Keep this list in INTERLEAVED order to define physical slots:
        ' Index 0, 2, 4... = Left Column Slots
        ' Index 1, 3, 5... = Right Column Slots
        m_interlockControls = New List(Of InterlockControl) From {
            New InterlockControl(lblTargetPanels, bicTargetPanels, Function() True),
            New InterlockControl(lblMB1Water, bicTargetMBWater, Function() TargetMBWater_Visible),
            New InterlockControl(lblLidClosed, bicLidClosed, Function() True),
            New InterlockControl(lblMB2Water, bicBiasMBWater, Function() BiasMBWater_Visible),
            New InterlockControl(lblDeviceNetCom, bicDeviceNetCom, Function() True),
            New InterlockControl(lblTarget1Water, bicTarget1Water, Function() Target1Water_Visible),
            New InterlockControl(Label6, bicChamberPress, Function() True),
            New InterlockControl(lblTarget2Water, bicTarget2Water, Function() Target2Water_Visible),
            New InterlockControl(lblAirPressure, bicAirPressure, Function() AirPressure_Visible),
            New InterlockControl(lblTarget3Water, bicTarget3Water, Function() Target3Water_Visible),
            New InterlockControl(lblSubTableWater, bicSubTableWater, Function() SubTableWater_Visible),
            New InterlockControl(lblTarget4Water, bicTarget4Water, Function() Target4Water_Visible),
            New InterlockControl(lblTurboForeline, bicTurboForeline, Function() TurboForeline_Visible),
            New InterlockControl(lblTarget5Water, bicTarget5Water, Function() Target5Water_Visible),
            New InterlockControl(lblTurboWater, bicTurboWater, Function() TurboWater_Visible),
            New InterlockControl(lblPSRelay, btnPSRelay, Function() True)
        }
    End Sub

    Public Sub ArrangeInterlock()
        Try
            ' 1. Get all currently visible controls
            Dim visibleControls As New List(Of InterlockControl)
            For Each ctrl As InterlockControl In m_interlockControls
                If ctrl.VisibilityProperty.Invoke() Then
                    visibleControls.Add(ctrl)
                End If
            Next
            If visibleControls.Count = 0 Then Return

            ' 2. Categorize visible items directly into strictly Left or Right list, with PS Relay floating to balance
            Dim leftVisible As New List(Of InterlockControl)
            Dim rightVisible As New List(Of InterlockControl)
            Dim floatItems As New List(Of InterlockControl)

            For Each ctrl As InterlockControl In visibleControls
                Dim name As String = ctrl.Label.Name
                ' Float the PS Interlock to the shorter column to ensure they are even (cắt đều)
                If name.Contains("PS") Then
                    floatItems.Add(ctrl)
                ElseIf (name.Contains("Target") AndAlso name <> "lblTargetPanels") OrElse name.Contains("MB") Then
                    rightVisible.Add(ctrl)
                Else
                    leftVisible.Add(ctrl)
                End If
            Next

            ' Assign float items to the shorter column
            For Each ctrl As InterlockControl In floatItems
                If leftVisible.Count <= rightVisible.Count Then
                    leftVisible.Add(ctrl)
                Else
                    rightVisible.Add(ctrl)
                End If
            Next

            ' 4. Arrange Left column (Slots 0, 2, 4...)
            For j As Integer = 0 To leftVisible.Count - 1
                Dim ctrl As InterlockControl = leftVisible(j)
                ctrl.Label.Location = CType(m_interlockControls(j * 2).LocationLable, Point)
                ctrl.Button.Location = CType(m_interlockControls(j * 2).LocationButton, Point)
            Next

            ' 5. Arrange Right column (Slots 1, 3, 5...)
            For j As Integer = 0 To rightVisible.Count - 1
                Dim ctrl As InterlockControl = rightVisible(j)
                ctrl.Label.Location = CType(m_interlockControls(j * 2 + 1).LocationLable, Point)
                ctrl.Button.Location = CType(m_interlockControls(j * 2 + 1).LocationButton, Point)
            Next

            ' Special handling for PSRelay button (wider than circles)
            Dim psRelayControl As InterlockControl = m_interlockControls(m_interlockControls.Count - 1)
            If psRelayControl.VisibilityProperty.Invoke() Then
                psRelayControl.Button.Location = New Point(psRelayControl.Label.Right - 1, psRelayControl.Label.Top)
            End If

            ' Adjust panel height based on the longest column
            Dim maxRows As Integer = Math.Max(leftVisible.Count, rightVisible.Count)
            Me.Height = BASIC_HEIGHT + (BUTTON_DIST * maxRows)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region
End Class
