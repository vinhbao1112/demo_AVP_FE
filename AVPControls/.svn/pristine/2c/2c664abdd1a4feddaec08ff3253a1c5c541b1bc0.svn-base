Imports System.ComponentModel
Imports AVPControls
Imports AVPControls.AVPDataLib

Public Class AVPChamberControl

#Region "Fields - Events"
    Protected Const DEFAULT_SHUTTER_INSTALLED As Boolean = True
    Protected Const STR_DEFAULT_SHUTTER_INSTALLED As String = "True"
    Protected Const DEFAULT_SHUTTER_STATUS As DisplayStatus = DisplayStatus.Off

    Protected m_waferStatus(0) As WaferStatuses
    Protected m_waferID(0) As String
    Protected m_slitValveStatus As DisplayStatus = DisplayStatus.None
    Protected m_shutterInstalled(0) As Boolean
    Protected m_shutterStatus(0) As DisplayStatus
    Protected m_plasmaOn As Boolean
    Protected m_GroundStatus(0) As DisplayStatus
    ''' <summary>
    ''' Gets or sets a value indicating whether the control is update view when wafer status or wafer ID is changed.
    ''' </summary>
    ''' <remarks></remarks>
    Protected UpdateViewOnWaferChanged As Boolean = True

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when wafer status changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event WaferStatusChanged As EventHandler

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when slit valve status changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event SlitValveStatusChanged As EventHandler

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when shutter installed changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ShutterInstalledChanged As EventHandler

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when shutter status changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ShutterStatusChanged As EventHandler
    Public Event GroundStatusChanged As EventHandler
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when plasma changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event PlasmaChanged As EventHandler

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-05</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when wafer ID changed
    ''' </summary>
    ''' <remarks></remarks>
    Public Event WaferIDChanged As EventHandler

#End Region

#Region "Properties"

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates wafer status of chamber.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(WaferStatuses), "NONE")> _
    Public Overridable Overloads Property WaferStatus() As WaferStatuses
        Get
            Return m_waferStatus(0)
        End Get
        Set(ByVal value As WaferStatuses)
            If m_waferStatus(0) <> value Then
                m_waferStatus(0) = value
                OnWaferStatusChanged(EventArgs.Empty)

                If UpdateViewOnWaferChanged Then
                    UpdateView()
                End If
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-11</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates wafer id of chamber.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Overridable Overloads Property WaferID() As String
        Get
            Return m_waferID(0)
        End Get
        Set(ByVal value As String)
            If m_waferID(0) = value Then
                Return
            End If

            m_waferID(0) = value
            OnWaferIDChanged(EventArgs.Empty)

            If UpdateViewOnWaferChanged Then
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-11</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates wafer id of chamber.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Overloads Property WaferID(ByVal index As Integer) As String
        Get
            If index < 0 OrElse index >= m_waferID.Length Then
                Return String.Empty
            End If

            Return m_waferID(index)
        End Get
        Set(ByVal value As String)
            If index < 0 OrElse index >= m_waferID.Length OrElse m_waferID(index) = value Then
                Return
            End If

            m_waferID(index) = value
            OnWaferIDChanged(EventArgs.Empty)

            If UpdateViewOnWaferChanged Then
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates wafer status of chamber.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Overloads Property WaferStatus(ByVal index As Integer) As WaferStatuses
        Get
            If index < 0 OrElse index >= m_waferStatus.Length Then
                Return WaferStatuses.NONE
            End If

            Return m_waferStatus(index)
        End Get
        Set(ByVal value As WaferStatuses)
            If index < 0 OrElse index >= m_waferStatus.Length Then
                Exit Property
            End If

            If m_waferStatus(index) <> value Then
                m_waferStatus(index) = value
                OnWaferStatusChanged(EventArgs.Empty)

                If UpdateViewOnWaferChanged Then
                    UpdateView()
                End If
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates slit valve status of chamber.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(DisplayStatus), "None")> _
    Public Overridable Property SlitValveStatus() As DisplayStatus
        Get
            Return m_slitValveStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_slitValveStatus <> value Then
                m_slitValveStatus = value
                OnSlitValveStatusChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether the shutter is installed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), STR_DEFAULT_SHUTTER_INSTALLED)> _
    Public Overridable Overloads Property ShutterInstalled(ByVal index As Integer) As Boolean
        Get
            If index < 0 OrElse index >= m_shutterInstalled.Length Then
                Return False
            End If

            Return m_shutterInstalled(index)
        End Get
        Set(ByVal value As Boolean)
            If index < 0 OrElse index >= m_shutterInstalled.Length Then
                Exit Property
            End If

            If m_shutterInstalled(index) <> value Then
                m_shutterInstalled(index) = value
                OnShutterInstalledChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-17</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether the shutter is installed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), STR_DEFAULT_SHUTTER_INSTALLED)> _
    Public Overridable Overloads Property ShutterInstalled() As Boolean
        Get
            Return m_shutterInstalled(0)
        End Get
        Set(ByVal value As Boolean)
            If m_shutterInstalled(0) <> value Then
                m_shutterInstalled(0) = value
                OnShutterInstalledChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates the shutter status of chamber.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Overridable Overloads Property ShutterStatus(ByVal index As Integer) As DisplayStatus
        Get
            If index < 0 OrElse index >= m_shutterStatus.Length Then
                Return DisplayStatus.None
            End If

            Return m_shutterStatus(index)
        End Get
        Set(ByVal value As DisplayStatus)
            If index < 0 OrElse index >= m_shutterStatus.Length Then
                Exit Property
            End If

            If m_shutterStatus(index) <> value Then
                m_shutterStatus(index) = value
                OnShutterStatusChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-11</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates the shutter status of chamber.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Overridable Overloads Property ShutterStatus() As DisplayStatus
        Get
            Return m_shutterStatus(0)
        End Get
        Set(ByVal value As DisplayStatus)
            If m_shutterStatus(0) <> value Then
                m_shutterStatus(0) = value
                OnShutterStatusChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Tinh Le</name>
    '''     <date>2020-07-02</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates the ground status of chamber.
    ''' </summary>
    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Overridable Overloads Property GroundStatus() As DisplayStatus
        Get
            Return m_GroundStatus(0)
        End Get
        Set(ByVal value As DisplayStatus)
            If m_GroundStatus(0) <> value Then
                m_GroundStatus(0) = value
                OnGroundStatusChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether plasma is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Overridable Property PlasmaOn() As Boolean
        Get
            Return m_plasmaOn
        End Get
        Set(ByVal value As Boolean)
            If m_plasmaOn <> value Then
                m_plasmaOn = value
                OnPlasmaChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates number of processing wafer of chamber.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property NumberOfWafers() As Integer
        Get
            Return m_waferStatus.Length
        End Get
        Set(ByVal value As Integer)
            If value <= 1 Then
                Exit Property
            End If

            If m_waferStatus.Length <> value Then
                ReDim Preserve m_waferStatus(value - 1)
                ReDim Preserve m_waferID(value - 1)
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates number of shutters of chamber.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property NumberOfShutters() As Integer
        Get
            Return m_shutterInstalled.Length
        End Get
        Set(ByVal value As Integer)
            If value <= 1 Then
                Exit Property
            End If

            If m_shutterStatus.Length <> value Then
                ReDim Preserve m_shutterInstalled(value - 1)
                Me.SetAllShutterInstalled(DEFAULT_SHUTTER_INSTALLED)
            End If

            If m_shutterStatus.Length <> value Then
                ReDim Preserve m_shutterStatus(value - 1)
                Me.SetAllShutterStatus(DEFAULT_SHUTTER_STATUS)
            End If

        End Set
    End Property
#End Region

#Region "Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Raise event WaferStatusChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnWaferStatusChanged(ByVal e As EventArgs)
        RaiseEvent WaferStatusChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Raise event SlitValveStatusChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnSlitValveStatusChanged(ByVal e As EventArgs)
        RaiseEvent SlitValveStatusChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Raise event SlitValveStatusChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnShutterInstalledChanged(ByVal e As EventArgs)
        RaiseEvent ShutterInstalledChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Raise event ShutterStatusChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnShutterStatusChanged(ByVal e As EventArgs)
        RaiseEvent ShutterStatusChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Tinh Le</name>
    '''     <date>2020-07-02</date>
    ''' </author>
    ''' <summary>
    ''' Raise event GroundStatusChanged.
    ''' </summary>
    Protected Overridable Sub OnGroundStatusChanged(ByVal e As EventArgs)
        RaiseEvent GroundStatusChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Raise event OnPlasmaChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnPlasmaChanged(ByVal e As EventArgs)
        RaiseEvent PlasmaChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-05</date>
    ''' </author>
    ''' <summary>
    ''' Raise event WaferIDChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnWaferIDChanged(ByVal e As EventArgs)
        RaiseEvent WaferIDChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Set all shutter status.
    ''' </summary>
    ''' <param name="status"></param>
    ''' <remarks></remarks>
    Protected Sub SetAllShutterStatus(ByVal status As DisplayStatus)
        For index As Integer = 0 To m_shutterStatus.Length - 1
            m_shutterStatus(index) = status
        Next
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-18</date>
    ''' </author>
    ''' <summary>
    ''' Set all shutter status.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetAllShutterInstalled(ByVal installed As Boolean)
        For index As Integer = 0 To m_shutterInstalled.Length - 1
            m_shutterInstalled(index) = installed
        Next
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Generate Fixture image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Overloads Function GenerateFixtureImage(Optional ByVal fixtureTiltAngle As Single = 0) As Bitmap
        Try
            'Dim imgFixture As Bitmap = My.Resources.Resources.IBD_Fixture
            'Using g As Graphics = Graphics.FromImage(imgFixture)
            '    ' Draw shutter.
            '    If m_shutterInstalled(0) Then
            '        Dim imgShutter As Bitmap
            '        Select Case m_shutterStatus(0)
            '            Case DisplayStatus.Off
            '                imgShutter = My.Resources.Resources.Fixture_Shutter_Close
            '            Case DisplayStatus.On
            '                imgShutter = My.Resources.Resources.Fixture_Shutter_Open
            '            Case Else
            '                imgShutter = My.Resources.Resources.Fixture_Shutter_Unknown
            '        End Select

            '        g.DrawImageUnscaled(imgShutter, 0, 0)
            '        imgShutter.Dispose()
            '    End If

            '    ' Draw wafer.
            '    If m_waferStatus(0) <> WaferStatuses.NONE OrElse Me.DesignMode Then
            '        Dim idBrush As SolidBrush = Nothing
            '        Dim imgWafer As Bitmap = Nothing
            '        Select Case m_waferStatus(0)
            '            Case WaferStatuses.UNPROCESS
            '                imgWafer = My.Resources.Resources.Fixture_Wafer_Unprocess
            '                idBrush = New SolidBrush(TEXT_OFF_COLOR)
            '            Case WaferStatuses.PARTIAL
            '                imgWafer = My.Resources.Resources.Fixture_Wafer_Partial
            '                idBrush = New SolidBrush(TEXT_UNKNOWN_COLOR)
            '            Case WaferStatuses.ERROR
            '                imgWafer = My.Resources.Resources.Fixture_Wafer_Error
            '                idBrush = New SolidBrush(TEXT_ERROR_COLOR)
            '            Case WaferStatuses.COMPLETE
            '                imgWafer = My.Resources.Resources.Fixture_Wafer_Complete
            '                idBrush = New SolidBrush(TEXT_ON_COLOR)
            '            Case WaferStatuses.NONE
            '                imgWafer = My.Resources.Resources.Fixture_Wafer_None
            '                idBrush = New SolidBrush(Color.Black)
            '        End Select

            '        g.DrawImageUnscaled(imgWafer, 74, 103)

            '        ' Draw wafer ID.
            '        If Not String.IsNullOrEmpty(m_waferID(0)) Then
            '            Dim idFont As New Font(WAFERID_FONT_NAME, 10, WAFERID_FONT_STYLE, GraphicsUnit.Point)
            '            Dim idSize As SizeF = g.MeasureString(m_waferID(0), idFont)
            '            g.DrawString(m_waferID(0), idFont, idBrush, 74 + CInt((imgWafer.Width - idSize.Width) / 2.0F), 103 + CInt((imgWafer.Height - idSize.Height) / 2.0F) + 1)
            '            idFont.Dispose()
            '        End If

            '        imgWafer.Dispose()
            '        idBrush.Dispose()
            '    End If

            '    g.Dispose()
            'End Using

            ''Rotate fixture image.
            'If fixtureTiltAngle <> 0 Then
            '    Dim rotatedImg As Bitmap = AVPGraphicsLib.RotateImage(imgFixture, fixtureTiltAngle, True)

            '    imgFixture.Dispose()
            '    Return rotatedImg
            'End If

            'Return imgFixture
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-23</date>
    ''' </author>
    ''' <summary>
    ''' Generate Fixture image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Overloads Function GenerateFixtureImage(ByVal fixtureTiltAngle As Single, ByVal shutterStatus As DisplayStatus, ByVal waferStatus As WaferStatuses, ByVal waferID As String) As Bitmap
        Try
            'Dim imgFixture As Bitmap = My.Resources.Resources.IBD_Fixture
            'Using g As Graphics = Graphics.FromImage(imgFixture)
            '    ' Draw shutter.
            '    If shutterStatus <> DisplayStatus.None Then
            '        Dim imgShutter As Bitmap
            '        Select Case shutterStatus
            '            Case DisplayStatus.Off
            '                imgShutter = My.Resources.Resources.Fixture_Shutter_Close
            '            Case DisplayStatus.On
            '                imgShutter = My.Resources.Resources.Fixture_Shutter_Open
            '            Case Else
            '                imgShutter = My.Resources.Resources.Fixture_Shutter_Unknown
            '        End Select

            '        g.DrawImageUnscaled(imgShutter, 0, 0)
            '        imgShutter.Dispose()
            '    End If

            '    ' Draw wafer.
            '    If waferStatus <> WaferStatuses.NONE OrElse Me.DesignMode Then
            '        Dim idBrush As SolidBrush = Nothing
            '        Dim imgWafer As Bitmap = Nothing
            '        Select Case waferStatus
            '            Case WaferStatuses.UNPROCESS
            '                imgWafer = My.Resources.Resources.Fixture_Wafer_Unprocess
            '                idBrush = New SolidBrush(TEXT_OFF_COLOR)
            '            Case WaferStatuses.PARTIAL
            '                imgWafer = My.Resources.Resources.Fixture_Wafer_Partial
            '                idBrush = New SolidBrush(TEXT_UNKNOWN_COLOR)
            '            Case WaferStatuses.ERROR
            '                imgWafer = My.Resources.Resources.Fixture_Wafer_Error
            '                idBrush = New SolidBrush(TEXT_ERROR_COLOR)
            '            Case WaferStatuses.COMPLETE
            '                imgWafer = My.Resources.Resources.Fixture_Wafer_Complete
            '                idBrush = New SolidBrush(TEXT_ON_COLOR)
            '            Case WaferStatuses.NONE
            '                imgWafer = My.Resources.Resources.Fixture_Wafer_None
            '                idBrush = New SolidBrush(Color.Black)
            '        End Select

            '        g.DrawImageUnscaled(imgWafer, 74, 103)

            '        ' Draw wafer ID.
            '        If Not String.IsNullOrEmpty(waferID) Then
            '            Dim idFont As New Font(WAFERID_FONT_NAME, 10, WAFERID_FONT_STYLE, GraphicsUnit.Point)
            '            Dim idSize As SizeF = g.MeasureString(waferID, idFont)
            '            g.DrawString(waferID, idFont, idBrush, 74 + CInt((imgWafer.Width - idSize.Width) / 2.0F), 103 + CInt((imgWafer.Height - idSize.Height) / 2.0F) + 1)
            '            idFont.Dispose()
            '        End If

            '        imgWafer.Dispose()
            '        idBrush.Dispose()
            '    End If

            '    g.Dispose()
            'End Using

            ''Rotate fixture image.
            'If fixtureTiltAngle <> 0 Then
            '    Dim rotatedImg As Bitmap = AVPGraphicsLib.RotateImage(imgFixture, fixtureTiltAngle, True)

            '    imgFixture.Dispose()
            '    Return rotatedImg
            'End If

            'Return imgFixture
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-22</date>
    ''' </author>
    ''' <summary>
    ''' Set wafer status and wafer id.
    ''' </summary>
    ''' <param name="waferStatus"></param>
    ''' <param name="waferID"></param>
    ''' <remarks></remarks>
    Public Overloads Sub SetWaferInfo(ByVal waferStatus As WaferStatuses, ByVal waferID As String)
        Try
            Dim statusChanged As Boolean
            Dim idChanged As Boolean

            ' Check different and set wafer status.
            If Me.m_waferStatus(0) <> waferStatus Then
                Me.m_waferStatus(0) = waferStatus
                statusChanged = True
            End If

            ' Check different and set wafer ID.
            If Me.m_waferID(0) <> waferID Then
                Me.m_waferID(0) = waferID
                idChanged = True
            End If

            ' Raise event WaferStatusChanged.
            If statusChanged Then
                OnWaferStatusChanged(EventArgs.Empty)
            End If

            ' Raise event WaferIDChanged.
            If idChanged Then
                OnWaferIDChanged(EventArgs.Empty)
            End If

            ' Update view if need.
            If (statusChanged OrElse idChanged) AndAlso Me.UpdateViewOnWaferChanged Then
                Me.UpdateView()
            End If

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-22</date>
    ''' </author>
    ''' <summary>
    ''' Set wafer status and wafer id for chamber with many wafers.
    ''' </summary>
    ''' <param name="waferStatus"></param>
    ''' <param name="waferID"></param>
    ''' <remarks></remarks>
    Public Overloads Sub SetWaferInfo(ByVal waferStatus() As WaferStatuses, ByVal waferID() As String)
        Try
            Dim statusChanged As Boolean
            Dim idChanged As Boolean

            ' Check different and set wafer status.
            If waferStatus IsNot Nothing AndAlso Me.m_waferStatus.Length = waferStatus.Length Then
                For index As Integer = 0 To waferStatus.Length - 1
                    If Me.m_waferStatus(index) <> waferStatus(index) Then
                        Me.m_waferStatus(index) = waferStatus(index)
                        statusChanged = True
                    End If
                Next
            End If

            ' Check different and set wafer ID.
            If waferID IsNot Nothing AndAlso Me.m_waferID.Length = waferID.Length Then
                For index As Integer = 0 To waferID.Length - 1
                    If Me.m_waferID(index) <> waferID(index) Then
                        Me.m_waferID(index) = waferID(index)
                        idChanged = True
                    End If
                Next
            End If

            ' Raise event WaferStatusChanged.
            If statusChanged Then
                OnWaferStatusChanged(EventArgs.Empty)
            End If

            ' Raise event WaferIDChanged.
            If idChanged Then
                OnWaferIDChanged(EventArgs.Empty)
            End If

            ' Update view if need.
            If (statusChanged OrElse idChanged) AndAlso Me.UpdateViewOnWaferChanged Then
                Me.UpdateView()
            End If

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_shutterInstalled(0) = DEFAULT_SHUTTER_INSTALLED

    End Sub

End Class
