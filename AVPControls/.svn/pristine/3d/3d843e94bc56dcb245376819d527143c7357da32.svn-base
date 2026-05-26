Imports System.ComponentModel
Imports AVPControls.AVPDataLib

''' <author>Hai Tran</author>
''' <date>2016-06-23</date>
Public Class PVDChamberControl

#Region "Fields"
    Private Const MinChuckHeight As Integer = 0
    Private Const MaxChuckHeight As Integer = 20
    Private Const PVDAChuckYAxis As Integer = 84
    Private Const PVDAChuckXAxis As Integer = 67
    Private Const PVDChuckYAxis As Integer = 105
    Private Const PVDChuckXAxis As Integer = 52

    Public Event PositionChanged As EventHandler

    Private _isPVDA As Boolean = True
    Private _chuckHeight As Integer
    Private _chuckPosition As Single
    Private _targetText As String = "Target"
    Private _chuckText As String = "Chuck (TSD In.)"
    Private _positionTSD As Boolean = True
    Private _chuckMinPosition As Single = 0
    Private _chuckMaxPosition As Single = 6

    ''' <summary>
    ''' Occurs when WaferControl is clicked.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event WaferControlClick As EventHandler

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-23</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the chamber is PVD_A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(True)> _
    Public Property IsPVDA() As Boolean
        Get
            Return _isPVDA
        End Get
        Set(ByVal value As Boolean)
            If _isPVDA <> value Then
                _isPVDA = value
                UpdateChuckText()
                If _isPVDA Then
                    ChamberType = AVPChamberTypes.PVD_A
                Else
                    ChamberType = AVPChamberTypes.PVD
                End If
            End If

        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-23</date>
    ''' <summary>
    ''' Gets or sets a value indicates chuck position of chamber.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(0.0F)> _
    Public Property ChuckPosition() As Single
        Get
            Return _chuckPosition
        End Get
        Set(ByVal value As Single)
            If _chuckPosition = value Then
                Return
            End If

            _chuckPosition = value

            Dim height As Integer = GetDrawingChuckHeight()
            If _chuckHeight <> height Then
                _chuckHeight = height
                Dim rc As Rectangle
                If IsPVDA Then
                    rc = New Rectangle(60, 45, 200, 80)
                Else
                    rc = New Rectangle(45, 80, 220, 100)
                End If
                UpdateView(rc)
                UpdateWaferLocation()
                OnPositionChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-24</date>
    ''' <summary>
    ''' Gets or sets chuck min position.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(0.0F)> _
    Public Property ChuckMinPosition() As Single
        Get
            Return _chuckMinPosition
        End Get
        Set(ByVal value As Single)
            If _chuckMinPosition <> value Then
                _chuckMinPosition = value
                If ChuckPosition < _chuckMinPosition Then
                    ChuckPosition = _chuckMinPosition
                End If
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-24</date>
    ''' <summary>
    ''' Gets or sets chuck max position.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(6.0F)> _
    Public Property ChuckMaxPosition() As Single
        Get
            Return _chuckMaxPosition
        End Get
        Set(ByVal value As Single)
            If _chuckMaxPosition <> value Then
                _chuckMaxPosition = value
                If ChuckPosition > _chuckMaxPosition Then
                    ChuckPosition = _chuckMaxPosition
                End If
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-23</date>
    ''' <summary>
    ''' Gets or sets the text on target.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue("Target")> _
    Public Property TargetText() As String
        Get
            Return _targetText
        End Get
        Set(ByVal value As String)
            If _targetText <> value Then
                _targetText = value
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-23</date>
    ''' <summary>
    ''' Gets or sets the text on chuck.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue("Chuck (TSD In.)")> _
    Public Property ChuckText() As String
        Get
            Return _chuckText
        End Get
        Set(ByVal value As String)
            If _chuckText <> value Then
                _chuckText = value
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-23</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether chuck position TSD.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(True)> _
    Public Property PositionTSD() As Boolean
        Get
            Return _positionTSD
        End Get
        Set(ByVal value As Boolean)
            If _positionTSD <> value Then
                _positionTSD = value
                UpdateChuckText()
                UpdateView()
                UpdateWaferLocation()
                OnPositionChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-24</date>
    ''' <summary>
    ''' Gets chuck drawing location.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable ReadOnly Property ChuckLocation() As Point
        Get
            Dim x As Integer
            Dim y As Integer
            If IsPVDA Then
                x = PVDAChuckXAxis
                If PositionTSD Then
                    y = PVDAChuckYAxis - MaxChuckHeight + _chuckHeight
                Else
                    y = PVDAChuckYAxis - _chuckHeight
                End If
            Else
                x = PVDChuckXAxis
                If PositionTSD Then
                    y = PVDChuckYAxis - MaxChuckHeight + _chuckHeight
                Else
                    y = PVDChuckYAxis - _chuckHeight
                End If
            End If

            Return New Point(x, y)
        End Get
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-24</date>
    ''' <summary>
    ''' Gets wafer drawing location.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable ReadOnly Property WaferLocation() As Point
        Get
            Dim p As Point = ChuckLocation
            If IsPVDA Then
                p.X += 24
                p.Y += 2
            Else
                p.X += 33
                p.Y += 3
            End If
            Return p
        End Get
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-23</date>
    ''' <summary>
    ''' Generate PVD/PVD_A chamber image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Try
            Me.CurrentRegionName = GetRegionName()
            If IsPVDA Then
                Return GeneratePVDAImage()
            Else
                Return GeneratePVDImage()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-23</date>
    ''' <summary>
    ''' Generate PVD_A chamber image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GeneratePVDAImage() As Bitmap
        Dim chamberImage As Bitmap = My.Resources.PVDAChamber
        Try
            Using g As Graphics = Graphics.FromImage(chamberImage)
                ' Draw chuck.
                Dim chuckImage As Bitmap
                If BiasPlasmaOn Then
                    chuckImage = My.Resources.PVDAChamber_Chuck_Plasma
                Else
                    chuckImage = My.Resources.PVDAChamber_Chuck
                End If

                g.DrawImageUnscaled(chuckImage, ChuckLocation)

                ' Draw slit valve.
                Dim slitValveImage As Bitmap = Nothing
                Select Case SlitValveStatus
                    Case AVPControls.AVPDataLib.DisplayStatus.Off
                        slitValveImage = My.Resources.PVDAChamber_SlitValve_Off
                    Case AVPControls.AVPDataLib.DisplayStatus.On
                        slitValveImage = My.Resources.PVDAChamber_SlitValve_On
                    Case Else
                        slitValveImage = My.Resources.PVDAChamber_SlitValve_Unknown
                End Select
                g.DrawImageUnscaled(slitValveImage, 16, 55)
                slitValveImage.Dispose()

                ' Draw chuck text.
                If Not String.IsNullOrEmpty(ChuckText) Then
                    Const ChuckCenterX As Integer = 155
                    Dim f As New Font("Times New Roman", 11, FontStyle.Bold, GraphicsUnit.Point)
                    Dim sizeText As SizeF = g.MeasureString(ChuckText, f)
                    Dim x As Integer = ChuckCenterX - CInt((sizeText.Width / 2.0F))
                    g.DrawString(ChuckText, f, Brushes.Black, x, 147)
                    f.Dispose()
                End If

                chuckImage.Dispose()
            End Using
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return chamberImage
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-23</date>
    ''' <summary>
    ''' Generate PVD chamber image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GeneratePVDImage() As Bitmap
        Dim chamberImage As Bitmap = My.Resources.PVDChamber
        Try
            Using g As Graphics = Graphics.FromImage(chamberImage)
                ' Draw shutter.
                If ShutterInstalled Then
                    Dim shutterImage As Bitmap = My.Resources.PVDChamber_Shutter
                    g.DrawImageUnscaled(shutterImage, 0, 0)
                    shutterImage.Dispose()
                End If

                ' Draw chuck.
                Dim chuckImage As Bitmap
                If BiasPlasmaOn Then
                    chuckImage = My.Resources.PVDChamber_Chuck_Plasma
                Else
                    chuckImage = My.Resources.PVDChamber_Chuck
                End If

                g.DrawImageUnscaled(chuckImage, ChuckLocation)

                ' Draw slit valve.
                Dim slitValveImage As Bitmap = Nothing
                Select Case SlitValveStatus
                    Case AVPControls.AVPDataLib.DisplayStatus.Off
                        slitValveImage = My.Resources.PVDChamber_SlitValve_Off
                    Case AVPControls.AVPDataLib.DisplayStatus.On
                        slitValveImage = My.Resources.PVDChamber_SlitValve_On
                    Case Else
                        slitValveImage = My.Resources.PVDChamber_SlitValve_Unknown
                End Select
                g.DrawImageUnscaled(slitValveImage, 6, 72)
                slitValveImage.Dispose()

                ' Draw chuck text.
                If Not String.IsNullOrEmpty(ChuckText) Then
                    Const ChuckCenterX As Integer = 150
                    Dim f As New Font("Times New Roman", 11, FontStyle.Bold, GraphicsUnit.Point)
                    Dim sizeText As SizeF = g.MeasureString(ChuckText, f)
                    Dim x As Integer = ChuckCenterX - CInt((sizeText.Width / 2.0F))
                    g.DrawString(ChuckText, f, Brushes.Black, x, 208)
                    f.Dispose()
                End If

                chuckImage.Dispose()
            End Using
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return chamberImage
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-23</date>
    ''' <summary>
    ''' Gets the name of current region.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRegionName() As String
        Return IIf(IsPVDA, "PVD_A", "PVD").ToString() & "-Target=" & TargetInstalled & "-Chuck=" & ChuckInstalled
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-24</date>
    ''' <summary>
    ''' Gets chuck height for drawing
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDrawingChuckHeight() As Integer
        Dim distance As Single = _chuckMaxPosition - _chuckMinPosition
        Dim rate As Single = _chuckPosition / distance
        Dim drawingHeight As Integer = CInt(rate * (MaxChuckHeight - MinChuckHeight))
        If drawingHeight < MinChuckHeight Then
            drawingHeight = MinChuckHeight
        ElseIf drawingHeight > MaxChuckHeight Then
            drawingHeight = MaxChuckHeight
        End If
        Return drawingHeight
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-27</date>
    ''' <summary>
    ''' Update chuck text.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateChuckText()
        If _isPVDA Then
            If _positionTSD Then
                _chuckText = "Chuck (TSD In.)"
            Else
                _chuckText = "Chuck (In.)"
            End If
        Else
            _chuckText = "Chuck Pos"
        End If
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-28</date>
    ''' <summary>
    ''' Update wafer location when chuck moving.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateWaferLocation()
        WaferControl.Location = WaferLocation
        WaferControl.Invalidate()
    End Sub

#End Region

#Region "Events"

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-23</date>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.UseCachingRegion = True
        UpdateWaferLocation()

    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-24</date>
    ''' <summary>
    ''' Raise event PositionChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnPositionChanged(ByVal e As EventArgs)
        RaiseEvent PositionChanged(Me, e)
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-27</date>
    ''' <summary>
    ''' Raise WaferControlClick event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WaferControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaferControl.Click
        RaiseEvent WaferControlClick(sender, e)
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-28</date>
    ''' <summary>
    ''' Enable/Disable control.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PVDChamberControl_ActivationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ActivationChanged
        WaferControl.Enabled = Not Me.IsOnline AndAlso Me.IsActive
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-27</date>
    ''' <summary>
    ''' Update chamber type of WaferControl.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PVDChamberControl_ChamberTypeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ChamberTypeChanged
        WaferControl.ChamberType = ChamberType
        UpdateWaferLocation()
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-28</date>
    ''' <summary>
    ''' Enable/Disable control.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PVDChamberControl_OnlineChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnlineChanged
        WaferControl.Enabled = Not Me.IsOnline AndAlso Me.IsActive
    End Sub

    ''' <author>Hai Tran</author> 
    ''' <date>2016-06-30</date>
    ''' <summary>
    ''' Repaint wafer when update view.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PVDChamberControl_ViewUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ViewUpdated
        WaferControl.Invalidate()
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-27</date>
    ''' <summary>
    ''' Update wafer ID to control.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PVDChamberControl_WaferIDChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.WaferIDChanged
        WaferControl.WaferID = WaferID
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-06-27</date>
    ''' <summary>
    ''' Update wafer status to control.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PVDChamberControl_WaferStatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.WaferStatusChanged
        WaferControl.WaferStatus = Me.WaferStatus
        If WaferStatus = WaferStatuses.NONE Then
            WaferControl.Visible = False
        Else
            WaferControl.Visible = True
            UpdateWaferLocation()
        End If
    End Sub

#End Region

End Class
