Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class AVPFixtureControl
    Protected m_fAngle As Single
    Protected m_isShutterOpen As Boolean
    Protected m_isPositiveDirection As Boolean = True
    Protected m_chamberPanelType As AVPChamberTypes = AVPControls.AVPDataLib.AVPChamberTypes.IBE
    Protected m_WaferID As String = String.Empty
    Protected m_WaferStatus As WaferStatuses = WaferStatuses.NONE
    Protected m_hasShutterOnFixture As Boolean
    Protected m_ShutterOpen1OnFixture As Bitmap = My.Resources.Resources.FixtureControl_Shutter_Open1
    Protected m_ShutterOpenOnFixture As Bitmap = My.Resources.Resources.FixtureControl_Shutter_Open
    Protected m_ShutterClosedOnFixture As Bitmap = My.Resources.Resources.FixtureControl_Shutter_Closed
    Protected m_ShutterOnFixtureUsedByGalilVisible As Boolean
    Private m_tiltAngleReferenceAsLegacy As Boolean
    Private _tiltAngle As Single

#Region "Properties"

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-02-23</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether the tilt angle of fixture is references as legacy.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False)> _
    Public Property TiltAngleReferenceAsLegacy() As Boolean
        Get
            Return m_tiltAngleReferenceAsLegacy
        End Get
        Set(ByVal value As Boolean)
            If m_tiltAngleReferenceAsLegacy = value Then
                Return
            End If

            m_tiltAngleReferenceAsLegacy = value
            Me.RotationAngle = _tiltAngle

        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicates the tilt angle of this fixture control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(0.0F)> _
    Public Overrides Property RotationAngle() As Single
        Get
            Return _tiltAngle
        End Get
        Set(ByVal value As Single)
            _tiltAngle = value
            Dim rotationAngle As Single = _tiltAngle
            If Me.TiltAngleReferenceAsLegacy Then
                rotationAngle = 90 - _tiltAngle
            End If

            MyBase.RotationAngle = rotationAngle
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsShutterOpen() As Boolean
        Get
            Return m_isShutterOpen
        End Get
        Set(ByVal value As Boolean)
            If m_isShutterOpen <> value Then
                m_isShutterOpen = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsPositiveDirection() As Boolean
        Get
            Return m_isPositiveDirection
        End Get
        Set(ByVal value As Boolean)
            If ShutterOnFixtureUsedByGalilVisible Then
                If m_isPositiveDirection <> value Then
                    m_isPositiveDirection = value
                End If
            Else
                m_isPositiveDirection = False
            End If
            UpdateView()
        End Set
    End Property

    <DefaultValue(GetType(AVPChamberTypes), "IBE")> _
    Public Property ChamberPanelType() As AVPChamberTypes
        Get
            Return m_chamberPanelType
        End Get
        Set(ByVal value As AVPChamberTypes)
            If m_chamberPanelType <> value Then
                m_chamberPanelType = value
            End If
        End Set
    End Property

    <DefaultValue(GetType(String), "")> _
    Public Property WaferID() As String
        Get
            Return m_WaferID
        End Get
        Set(ByVal value As String)
            If m_WaferID <> value Then
                m_WaferID = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(GetType(WaferStatuses), "NONE")> _
    Public Property WaferStatus() As WaferStatuses
        Get
            Return m_WaferStatus
        End Get
        Set(ByVal value As WaferStatuses)
            If m_WaferStatus <> value Then
                m_WaferStatus = value
                UpdateView()
            End If
            If m_WaferStatus <> WaferStatuses.NONE Then
                Me.Cursor = Cursors.Hand
            Else
                Me.Cursor = Cursors.Default
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property HasShutterOnFixture() As Boolean
        Get
            Return m_hasShutterOnFixture
        End Get
        Set(ByVal value As Boolean)
            If m_hasShutterOnFixture <> value Then
                m_hasShutterOnFixture = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property ShutterOnFixtureUsedByGalilVisible() As Boolean
        Get
            Return m_ShutterOnFixtureUsedByGalilVisible
        End Get
        Set(ByVal value As Boolean)
            m_ShutterOnFixtureUsedByGalilVisible = value
        End Set
    End Property
#End Region

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-01 </date>
    ''' </author>
    ''' <summary>
    ''' Generate image use for fixture control
    ''' </summary>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Dim img As Bitmap = My.Resources.Resources.FixtureControl
        Try
            Dim g As Graphics = Graphics.FromImage(img)
            ' Draw Wafer
            Dim imgWafer As Bitmap = GenerateWaferImage()
            If imgWafer IsNot Nothing Then
                g.DrawImageUnscaled(imgWafer, 50, 37)
                imgWafer.Dispose()
            End If

            'Draw Shutter
            If m_hasShutterOnFixture Then
                Dim imgShutter As Bitmap = m_ShutterClosedOnFixture
                If m_isShutterOpen Then
                    If m_isPositiveDirection Then
                        imgShutter = m_ShutterOpen1OnFixture
                    Else
                        imgShutter = m_ShutterOpenOnFixture
                    End If
                End If

                If imgShutter IsNot Nothing Then
                    g.DrawImageUnscaled(imgShutter, 0, 0)

                    imgShutter = Nothing
                End If
            End If
            g.Dispose()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return img
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-01 </date>
    ''' </author>
    ''' <summary>
    ''' Generate wafer image on fixture control
    ''' </summary>
    Private Function GenerateWaferImage() As Bitmap
        Dim img As Bitmap = Nothing

        Try
            If m_WaferStatus <> WaferStatuses.NONE Then
                Dim brushColor As Brush = Brushes.Black
                Dim imgWafer As Bitmap = Nothing
                Select Case m_WaferStatus
                    Case WaferStatuses.UNPROCESS
                        imgWafer = My.Resources.Resources.Fixture_Wafer_Blue
                        brushColor = Brushes.White
                    Case WaferStatuses.PARTIAL
                        imgWafer = My.Resources.Resources.Fixture_Wafer_Yellow
                    Case WaferStatuses.ERROR
                        imgWafer = My.Resources.Resources.Fixture_Wafer_Red
                        brushColor = Brushes.White
                    Case WaferStatuses.COMPLETE
                        imgWafer = My.Resources.Resources.Fixture_Wafer_Green
                End Select

                img = New Bitmap(65, 14)
                img.SetResolution(imgWafer.HorizontalResolution, imgWafer.VerticalResolution)

                Dim g As Graphics = Graphics.FromImage(img)
                ' Draw wafer image
                g.DrawImage(imgWafer, 0, 0, img.Width, img.Height)

                ' Draw wafer ID
                Dim fontId As New Font("Times New Roman", 10.0!, FontStyle.Bold)
                Dim sizeId As SizeF = g.MeasureString(m_WaferID, fontId)
                g.DrawString(m_WaferID, fontId, brushColor, CSng(Math.Round((img.Width - sizeId.Width) / 2)), CSng(Math.Round((img.Height - sizeId.Height) / 2)))

                fontId.Dispose()
                sizeId = Nothing
                g.Dispose()

                brushColor = Nothing
                imgWafer.Dispose()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        Return img
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-27</date>
    ''' </author>
    ''' <summary>
    ''' Clean up memory.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub MemoryCleanup()
        MyBase.MemoryCleanup()

        Try
            Me.ReleaseBitmap(m_ShutterOpen1OnFixture)
            Me.ReleaseBitmap(m_ShutterOpenOnFixture)
            Me.ReleaseBitmap(m_ShutterClosedOnFixture)

        Catch ex As Exception
            ' Ignore any errors.
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DoubleBuffered = True

        Me.RotationMode = AVPControlStyleModes.ControlOwner
        Me.IsInitialized = True
        Me.ResumeUpdateView()
    End Sub
End Class
