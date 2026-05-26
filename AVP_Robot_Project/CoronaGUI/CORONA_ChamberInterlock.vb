Public Class CORONA_ChamberInterlock

#Region "Property"
    Private m_blnAirPressureVisible As Boolean = False
    Private m_blnTurboWaterVisible As Boolean = False
    Private m_blnTargetMBWaterVisible As Boolean = False
    Private m_blnBiasMBWaterVisible As Boolean = False
    Private m_blnTarget13WaterVisible As Boolean = False
    Private m_blnTarget24WaterVisible As Boolean = False
    Private m_blnSubTableWaterVisible As Boolean = False

    Const BASIC_HEIGHT As Integer = 103
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

    Public Property Target13Water_Visible() As Boolean
        Get
            Return m_blnTarget13WaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTarget13WaterVisible = value
            lblTarget1Water.Visible = value
            bicTarget1_3Water.Visible = value
        End Set
    End Property

    Public Property Target24Water_Visible() As Boolean
        Get
            Return m_blnTarget24WaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTarget24WaterVisible = value
            lblTarget2Water.Visible = value
            bicTarget2_4Water.Visible = value
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
            Dim sTarget1_3Water As New StatusCoronaButton(bicTarget1_3Water)
            Dim sTarget2_4Water As New StatusCoronaButton(bicTarget2_4Water)

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
            m_stoStatusObject.AddChild(sTarget1_3Water)
            m_stoStatusObject.AddChild(sTarget2_4Water)

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
            bicTarget1_3Water.ParentStatusObj = m_stoStatusObject
            bicTarget2_4Water.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#Region "Function"
    Public Sub ArrangeInterlock()
        Dim i As Integer = 0
        If TargetMBWater_Visible Then
            lblMB1Water.Location = m_lblArrayLocation(i)
            bicTargetMBWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If SubTableWater_Visible Then
            lblSubTableWater.Location = m_lblArrayLocation(i)
            bicSubTableWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If BiasMBWater_Visible Then
            lblMB2Water.Location = m_lblArrayLocation(i)
            bicBiasMBWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If AirPressure_Visible Then
            lblAirPressure.Location = m_lblArrayLocation(i)
            bicAirPressure.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If Target13Water_Visible Then
            lblTarget1Water.Location = m_lblArrayLocation(i)
            bicTarget1_3Water.Location = m_bicArrayLocation(i)
            i += 1
        End If
        ''
        If TurboWater_Visible Then
            lblTurboWater.Location = m_lblArrayLocation(i)
            bicTurboWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If Target24Water_Visible Then
            lblTarget2Water.Location = m_lblArrayLocation(i)
            bicTarget2_4Water.Location = m_bicArrayLocation(i)
            i += 1
        End If
        lblPSRelay.Location = m_lblArrayLocation(i)
        btnPSRelay.Location = New Point(lblPSRelay.Right, lblPSRelay.Top)
        Me.Height = BASIC_HEIGHT + (BUTTON_DIST * Math.Ceiling(i / 2))
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ''4 basic interlock
        Me.m_lblArrayLocation.Add(lblMB1Water.Location) '0
        Me.m_lblArrayLocation.Add(lblSubTableWater.Location) '1
        Me.m_lblArrayLocation.Add(lblMB2Water.Location) '2
        Me.m_lblArrayLocation.Add(lblAirPressure.Location) '3
        Me.m_lblArrayLocation.Add(lblTarget1Water.Location) '4
        Me.m_lblArrayLocation.Add(lblTurboWater.Location) '5
        Me.m_lblArrayLocation.Add(lblTarget2Water.Location) '6
        Me.m_lblArrayLocation.Add(lblPSRelay.Location) '7

        Me.m_bicArrayLocation.Add(bicTargetMBWater.Location) '0
        Me.m_bicArrayLocation.Add(bicSubTableWater.Location) '1
        Me.m_bicArrayLocation.Add(bicBiasMBWater.Location) '2
        Me.m_bicArrayLocation.Add(bicAirPressure.Location) '3
        Me.m_bicArrayLocation.Add(bicTarget1_3Water.Location) '4
        Me.m_bicArrayLocation.Add(bicTurboWater.Location) '5
        Me.m_bicArrayLocation.Add(bicTarget2_4Water.Location) '6
        Me.m_bicArrayLocation.Add(btnPSRelay.Location) '7

        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class
