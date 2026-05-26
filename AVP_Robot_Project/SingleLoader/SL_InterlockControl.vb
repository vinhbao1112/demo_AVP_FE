Public Class SL_InterlockControl
    Const BASIC_HEIGHT As Integer = 37
    Const BUTTON_DIST As Integer = 30
    Private m_lblArrayLocation As New ArrayList ''store Array location for Label
    Private m_bicArrayLocation As New ArrayList ''store Array location for button
#Region "Properties"

    Private m_SoureVisible As Boolean
    Public Property SourceVisible() As Boolean
        Get
            Return m_SoureVisible
        End Get
        Set(ByVal value As Boolean)
            m_SoureVisible = value
            btnSource.Visible = value
            lblSource.Visible = value
        End Set
    End Property

    Private m_PanelVisible As Boolean
    Public Property PanelVisible() As Boolean
        Get
            Return m_PanelVisible
        End Get
        Set(ByVal value As Boolean)
            m_PanelVisible = value
            btnPanels.Visible = value
            lblChamberLid.Visible = value
        End Set
    End Property

    Private m_ForeLineVisible As Boolean
    Public Property ForeLineVisible() As Boolean
        Get
            Return m_ForeLineVisible
        End Get
        Set(ByVal value As Boolean)
            m_ForeLineVisible = value
            btnForelinePress.Visible = value
            Label6.Visible = value
        End Set
    End Property

    Private m_ChamPressVisible As Boolean
    Public Property ChamPressVisible() As Boolean
        Get
            Return m_ChamPressVisible
        End Get
        Set(ByVal value As Boolean)
            m_ChamPressVisible = value
            btnChamPress.Visible = value
            Label2.Visible = value
        End Set
    End Property


    Private m_AirPressureVisible As Boolean
    Public Property AirPressureVisible() As Boolean
        Get
            Return m_AirPressureVisible
        End Get
        Set(ByVal value As Boolean)
            m_AirPressureVisible = value
            btnAirPressure.Visible = value
            lblAirPressure.Visible = value
        End Set
    End Property

    Private m_TurboWaterVisible As Boolean
    Public Property TurboWaterVisible() As Boolean
        Get
            Return m_TurboWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_TurboWaterVisible = value
            btnTurboWater.Visible = value
            lblTurboWater.Visible = value
        End Set
    End Property

    Private m_FixtureWaterBugVisible As Boolean
    Public Property FixtureWaterBugVisible() As Boolean
        Get
            Return m_FixtureWaterBugVisible
        End Get
        Set(ByVal value As Boolean)
            m_FixtureWaterBugVisible = value
            btnFixtureWaterBug.Visible = value
            Label1.Visible = value
        End Set
    End Property

    Private m_FixtureWaterVisible As Boolean
    Public Property FixtureWaterVisible() As Boolean
        Get
            Return m_FixtureWaterVisible
        End Get
        Set(ByVal value As Boolean)
            m_FixtureWaterVisible = value
            btnFixtureWater.Visible = value
            Label4.Visible = value
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
            Dim sbtChamPress As New SL_StatusButton(btnChamPress)
            Dim sbtFixtureWater As New SL_StatusButton(btnFixtureWater)
            Dim sbtFixtureWaterBug As New SL_StatusButton(btnFixtureWaterBug)
            Dim sbtSource As New SL_StatusButton(btnSource)
            Dim sbtAirPressure As New SL_StatusButton(btnAirPressure)
            Dim sbtForelinePress As New SL_StatusButton(btnForelinePress)
            Dim sbtTurboWater As New SL_StatusButton(btnTurboWater)
            Dim sbtPanels As New SL_StatusButton(btnPanels)

            m_stoStatusObject.Name = Me.Name

            m_stoStatusObject.AddChild(sbtChamPress)
            m_stoStatusObject.AddChild(sbtFixtureWater)
            m_stoStatusObject.AddChild(sbtFixtureWaterBug)
            m_stoStatusObject.AddChild(sbtSource)
            m_stoStatusObject.AddChild(sbtAirPressure)
            m_stoStatusObject.AddChild(sbtForelinePress)
            m_stoStatusObject.AddChild(sbtTurboWater)
            m_stoStatusObject.AddChild(sbtPanels)
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
        btnAirPressure.Status = SL_CustomButton.DisplayStatus.Off
        btnChamPress.Status = SL_CustomButton.DisplayStatus.Off
        btnFixtureWater.Status = SL_CustomButton.DisplayStatus.Off
        btnFixtureWaterBug.Status = SL_CustomButton.DisplayStatus.Off
        btnForelinePress.Status = SL_CustomButton.DisplayStatus.Off
        btnPanels.Status = SL_CustomButton.DisplayStatus.Off
        btnSource.Status = SL_CustomButton.DisplayStatus.Off
        btnTurboWater.Status = SL_CustomButton.DisplayStatus.Off
    End Sub

    Public Sub ArrangePanel()
        Dim i As Integer = 0
        If SourceVisible Then
            lblSource.Location = m_lblArrayLocation(i)
            btnSource.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If PanelVisible Then
            lblChamberLid.Location = m_lblArrayLocation(i)
            btnPanels.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If ForeLineVisible Then
            Label6.Location = m_lblArrayLocation(i)
            btnForelinePress.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If ChamPressVisible Then
            Label2.Location = m_lblArrayLocation(i)
            btnChamPress.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If AirPressureVisible Then
            lblAirPressure.Location = m_lblArrayLocation(i)
            btnAirPressure.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If TurboWaterVisible Then
            lblTurboWater.Location = m_lblArrayLocation(i)
            btnTurboWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If FixtureWaterVisible Then
            Label4.Location = m_lblArrayLocation(i)
            btnFixtureWater.Location = m_bicArrayLocation(i)
            i += 1
        End If
        If FixtureWaterBugVisible Then
            Label1.Location = m_lblArrayLocation(i)
            btnFixtureWaterBug.Location = m_bicArrayLocation(i)
            i += 1
        End If
        Me.Height = BASIC_HEIGHT + (BUTTON_DIST * Math.Ceiling(i / 2))
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.m_lblArrayLocation.Add(lblSource.Location)
        Me.m_lblArrayLocation.Add(lblChamberLid.Location)
        Me.m_lblArrayLocation.Add(Label6.Location)
        Me.m_lblArrayLocation.Add(Label2.Location)
        Me.m_lblArrayLocation.Add(lblAirPressure.Location)
        Me.m_lblArrayLocation.Add(lblTurboWater.Location)
        Me.m_lblArrayLocation.Add(Label4.Location)
        Me.m_lblArrayLocation.Add(Label1.Location)


        Me.m_bicArrayLocation.Add(btnSource.Location)
        Me.m_bicArrayLocation.Add(btnPanels.Location)
        Me.m_bicArrayLocation.Add(btnForelinePress.Location)
        Me.m_bicArrayLocation.Add(btnChamPress.Location)
        Me.m_bicArrayLocation.Add(btnAirPressure.Location)
        Me.m_bicArrayLocation.Add(btnTurboWater.Location)
        Me.m_bicArrayLocation.Add(btnFixtureWater.Location)
        Me.m_bicArrayLocation.Add(btnFixtureWaterBug.Location)

    End Sub
End Class
