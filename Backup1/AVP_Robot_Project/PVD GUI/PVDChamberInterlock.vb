Imports AVP_Robot_Project.ConstantAndEnum
Imports AVP_Robot_Project.PVDSupport
Public Class PVDChamberInterlock
#Region "Properties"
    Private m_blnTurboWaterVisible As Boolean = False
    Private m_blnTurboForelineVisible As Boolean = False
    Private m_blnTableWaterVisible As Boolean = False
    Private m_blnLidSensorVisible As Boolean = False
    Private m_blnMatchWaterVisible As Boolean = False
    Private m_blnTargetWaterVisible As Boolean = False
    Private m_blnLidWaterVisible As Boolean = False
    Private m_blnSubMBWaterVisible As Boolean = False
    Private m_blnClampWaterVisible As Boolean = False
    Private m_blnTargetMBWaterVisible As Boolean = False
    Const BASIC_HEIGHT As Integer = 90
    Const BUTTON_DIST As Integer = 20
    Private m_lblArrayLocation As New ArrayList ''store Array location for Label
    Private m_bicArrayLocation As New ArrayList ''store Array location for button
    Private m_blnIsOnline As Boolean = False
    '###################################################################
    '    - Basic - Chuck water/chamber Pressure/Chamber Water /w PS Relay. 
    '    - Configurable - 7 interlocks
    '###################################################################
    Public Property TurboWaterVisible() As Boolean
        Get
            Return m_blnTurboWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTurboWaterVisible = value
            lblTurboWater.Visible = value
            bicTurboWater.Visible = value
        End Set
    End Property

    Public Property TurboForelineVisible() As Boolean
        Get
            Return m_blnTurboForelineVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTurboForelineVisible = value
            lblTurboForeline.Visible = value
            bicTurboForeline.Visible = value
        End Set
    End Property

    Public Property LidSensorVisible() As Boolean
        Get
            Return m_blnLidSensorVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnLidSensorVisible = value
            lblLidSensor.Visible = value
            bicLidSensor.Visible = value
        End Set
    End Property

    Public Property TargetWaterVisible() As Boolean
        Get
            Return m_blnTargetWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTargetWaterVisible = value
            lblTargetWater.Visible = value
            bicTargetWater.Visible = value
        End Set
    End Property

    Public Property LidWaterVisible() As Boolean
        Get
            Return m_blnLidWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnLidWaterVisible = value
            lblLidWater.Visible = value
            bicLidWater.Visible = value
        End Set
    End Property
    ''
    Public Property TargetMBWaterVisible() As Boolean
        Get
            Return m_blnTargetMBWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnTargetMBWaterVisible = value
            lblTargetMBWater.Visible = value
            bicTargetMBWater.Visible = value
        End Set
    End Property

    Public Property ClampWaterVisible() As Boolean
        Get
            Return m_blnClampWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnClampWaterVisible = value
            lblClampWater.Visible = value
            bicClampWater.Visible = value
        End Set
    End Property

    Public Property SubMBWaterVisible() As Boolean
        Get
            Return m_blnSubMBWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnSubMBWaterVisible = value
            lblSubMBWater.Visible = value
            bicSubMBWater.Visible = value
        End Set
    End Property

    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnPSRelay.Enabled = Not m_blnIsOnline
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
        Try ''normal we have 4 interlock
            Dim stbChuckWater As New StatusIGCGButton(Me.bicChuckWater)
            Dim stbChamPress As New StatusIGCGButton(Me.bicChamberPress)
            Dim stbChamWater As New StatusIGCGButton(Me.bicChamberWater)
            Dim stbRSRelay As New StatusIGCGButton(Me.btnPSRelay)
            'we have 8 interlock configurable
            Dim stbTurboWater As New StatusIGCGButton(Me.bicTurboWater)
            Dim stbTurboForeline As New StatusIGCGButton(Me.bicTurboForeline)
            Dim stbChamberLid As New StatusIGCGButton(Me.bicLidSensor)
            Dim stbTargetWater As New StatusIGCGButton(Me.bicTargetWater)
            Dim stbLidWater As New StatusIGCGButton(Me.bicLidWater)
            Dim stbTargetMBWater As New StatusIGCGButton(Me.bicTargetMBWater)
            Dim stbClampWater As New StatusIGCGButton(Me.bicClampWater)
            Dim stbSubMBWater As New StatusIGCGButton(Me.bicSubMBWater)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbChuckWater)
            m_stoStatusObject.AddChild(stbChamPress)
            m_stoStatusObject.AddChild(stbChamWater)
            m_stoStatusObject.AddChild(stbRSRelay)
            If TurboWaterVisible Then
                m_stoStatusObject.AddChild(stbTurboWater)
            End If
            If TurboForelineVisible Then
                m_stoStatusObject.AddChild(stbTurboForeline)
            End If
            If LidSensorVisible Then
                m_stoStatusObject.AddChild(stbChamberLid)
            End If
            If TargetWaterVisible Then
                m_stoStatusObject.AddChild(stbTargetWater)
            End If
            If LidWaterVisible Then
                m_stoStatusObject.AddChild(stbLidWater)
            End If

            If TargetMBWaterVisible Then
                m_stoStatusObject.AddChild(stbTargetMBWater)
            End If
            If ClampWaterVisible Then
                m_stoStatusObject.AddChild(stbClampWater)
            End If
            If SubMBWaterVisible Then
                m_stoStatusObject.AddChild(stbSubMBWater)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    Private Sub btnRSRelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPSRelay.Click
        Dim strLogMessage As String = String.Empty
        If CType(sender, ButtonIGCGControl).Status = DisplayStatus.On Then
            strLogMessage = "Turn off PSRelay"
        Else
            strLogMessage = "Turn On PSRelay"
        End If
        PVDSupport.CommonButtonClick(strLogMessage, sender, Me.Parent, m_stoStatusObject)
    End Sub
#End Region

#Region "Function"
    Public Sub ArrangeInterlock()
        Dim i As Integer = 0
        If TurboWaterVisible Then
            lblTurboWater.Location = m_lblArrayLocation(i)
            bicTurboWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If TurboForelineVisible Then
            lblTurboForeline.Location = m_lblArrayLocation(i)
            bicTurboForeline.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If LidSensorVisible Then
            lblLidSensor.Location = m_lblArrayLocation(i)
            bicLidSensor.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If TargetWaterVisible Then
            lblTargetWater.Location = m_lblArrayLocation(i)
            bicTargetWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If LidWaterVisible Then
            lblLidWater.Location = m_lblArrayLocation(i)
            bicLidWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        ''
        If TargetMBWaterVisible Then
            lblTargetMBWater.Location = m_lblArrayLocation(i)
            bicTargetMBWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If ClampWaterVisible Then
            lblClampWater.Location = m_lblArrayLocation(i)
            bicClampWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If SubMBWaterVisible Then
            lblSubMBWater.Location = m_lblArrayLocation(i)
            bicSubMBWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        Me.Height = BASIC_HEIGHT + (BUTTON_DIST * Math.Ceiling(i / 2))
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ''4 basic interlock
        Me.m_lblArrayLocation.Add(lblTurboWater.Location) '0
        Me.m_lblArrayLocation.Add(lblTurboForeline.Location) '1
        Me.m_lblArrayLocation.Add(lblLidWater.Location) '2
        Me.m_lblArrayLocation.Add(lblLidSensor.Location) '3
        Me.m_lblArrayLocation.Add(lblClampWater.Location) '4
        Me.m_lblArrayLocation.Add(lblTargetWater.Location) '5
        Me.m_lblArrayLocation.Add(lblSubMBWater.Location) '6
        Me.m_lblArrayLocation.Add(lblTargetMBWater.Location) '7

        Me.m_bicArrayLocation.Add(bicTurboWater.Location) '0
        Me.m_bicArrayLocation.Add(bicTurboForeline.Location) '1
        Me.m_bicArrayLocation.Add(bicLidWater.Location) '2
        Me.m_bicArrayLocation.Add(bicLidSensor.Location) '3
        Me.m_bicArrayLocation.Add(bicClampWater.Location) '4
        Me.m_bicArrayLocation.Add(bicTargetWater.Location) '5
        Me.m_bicArrayLocation.Add(bicSubMBWater.Location) '6
        Me.m_bicArrayLocation.Add(bicTargetMBWater.Location) '7

        ' Add any initialization after the InitializeComponent() call.
        lblTurboForeline.Location = lblTurboWater.Location

        lblLidSensor.Location = lblTurboWater.Location

        lblTargetWater.Location = lblTurboWater.Location
        lblLidWater.Location = lblTurboWater.Location
        lblTargetMBWater.Location = lblTurboWater.Location
        lblClampWater.Location = lblTurboWater.Location
        lblSubMBWater.Location = lblTurboWater.Location

        bicTurboForeline.Location = bicTurboWater.Location

        bicLidSensor.Location = bicTurboWater.Location

        bicTargetWater.Location = bicTurboWater.Location
        bicLidWater.Location = bicTurboWater.Location

        bicTargetMBWater.Location = bicTurboWater.Location
        bicClampWater.Location = bicTurboWater.Location
        bicSubMBWater.Location = bicTurboWater.Location

        Me.Height = 90
    End Sub
End Class
