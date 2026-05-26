Imports System.ComponentModel
Imports AVPControls.AVPDataLib

''' <author>Hai Tran</author>
''' <date>2018-04-13</date>
''' <summary>
''' Inline pallet.
''' </summary>
''' <remarks></remarks>
Public Class InlinePallet

#Region "Fields"
    Const DefaultPalletSize As Integer = 102
    Const DefaultWaferSize As Integer = 102
    Const DefaultDistanceWafer As Integer = 0
    Const WaferHeight As Integer = 3
    Const PalletHeightWithWafer As Integer = 20
    Const MinPalletWidth As Integer = 30

    Private m_processingStatus As WaferStatuses = WaferStatuses.UNPROCESS
    Private m_palletID As String = String.Empty
    Private m_showQuestionMark As Boolean
    Private m_showWaferPosition As Boolean
    Private m_waferSize As Integer = DefaultWaferSize
    Private m_distanceWaferForForwardDirection As Integer = DefaultDistanceWafer
    Private m_palletSize As Integer = DefaultPalletSize

#End Region

#Region "Events"

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Occurs when the status of pallet is changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ProcessingStatusChanged As EventHandler

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Occurs when the id of pallet is changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event PalletIDChanged As EventHandler

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Gets or sets processing status.
    ''' </summary>
    <DefaultValue(GetType(WaferStatuses), "NONE")> _
    Public Property ProcessingStatus() As WaferStatuses
        Get
            Return m_processingStatus
        End Get
        Set(ByVal value As WaferStatuses)
            If m_processingStatus <> value Then
                m_processingStatus = value

                OnProcessingStatusChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Gets or sets pallet ID.
    ''' </summary>
    <DefaultValue(GetType(String), "")> _
    Public Property PalletID() As String
        Get
            Return m_palletID
        End Get
        Set(ByVal value As String)
            If m_palletID <> value Then
                m_palletID = value

                OnWaferIDChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the question mark is shown.
    ''' </summary>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsShowQuestionMark() As Boolean
        Get
            Return m_showQuestionMark
        End Get
        Set(ByVal value As Boolean)
            If m_showQuestionMark <> value Then
                m_showQuestionMark = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-06-12</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the wafer position is shown.
    ''' </summary>
    ''' <returns></returns>
    <DefaultValue(False)> _
    Public Property IsShowWaferPosition() As Boolean
        Get
            Return m_showWaferPosition
        End Get
        Set(ByVal value As Boolean)
            If m_showWaferPosition <> value Then
                m_showWaferPosition = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-06-12</date>
    ''' <summary>
    ''' Gets or sets pallet size.
    ''' </summary>
    ''' <returns></returns>
    <DefaultValue(DefaultPalletSize)> _
    Public Property PalletSize() As Integer
        Get
            Return m_palletSize
        End Get
        Set(ByVal value As Integer)
            If m_palletSize <> value AndAlso value >= 0 Then
                m_palletSize = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-06-12</date>
    ''' <summary>
    ''' Gets or sets wafer size.
    ''' </summary>
    ''' <returns></returns>
    <DefaultValue(DefaultWaferSize)> _
    Public Property WaferSize() As Integer
        Get
            Return m_waferSize
        End Get
        Set(ByVal value As Integer)
            If m_waferSize <> value AndAlso value >= 0 Then
                m_waferSize = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-06-12</date>
    ''' <summary>
    ''' Gets or sets distance of wafer for forward direction.
    ''' </summary>
    ''' <returns></returns>
    <DefaultValue(DefaultDistanceWafer)> _
    Public Property DistanceWaferForForwardDirection() As Integer
        Get
            Return m_distanceWaferForForwardDirection
        End Get
        Set(ByVal value As Integer)
            If m_distanceWaferForForwardDirection <> value AndAlso value >= 0 Then
                m_distanceWaferForForwardDirection = value

                UpdateView()
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Draw wafer image
    ''' </summary>
    Protected Overrides Function GenerateControlImage() As Bitmap
        Dim palletImage As Bitmap = GeneratePalletImage()

        If PatternBitmap Is Nothing AndAlso palletImage IsNot Nothing Then
            PatternBitmap = New Bitmap(palletImage)
        End If

        Return palletImage
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2018-06-13</date>
    ''' <summary>
    ''' Generates pallet image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GeneratePalletImage() As Bitmap
        If m_processingStatus = WaferStatuses.NONE Then
            Return Nothing
        End If

        Try
            Const PalletDiameter As Integer = 8
            Const WaferDiameter As Integer = 5

            Dim palletHeight As Integer = PalletHeightWithWafer
            Dim palletWidth As Integer = m_palletSize
            If m_palletSize < MinPalletWidth Then
                palletWidth = MinPalletWidth
            End If

            Dim waferWidth As Integer = m_waferSize
            If m_waferSize + m_distanceWaferForForwardDirection > palletWidth - PalletDiameter Then
                waferWidth = palletWidth - PalletDiameter - m_distanceWaferForForwardDirection
            End If

            Dim img As New Bitmap(palletWidth, palletHeight)

            Using g As Graphics = Graphics.FromImage(img)
                Dim backBrush As Brush
                Dim textBrush As Brush
                Dim borderPen As Pen = Pens.Black
                Dim backPen As Pen

                Select Case m_processingStatus
                    Case WaferStatuses.UNPROCESS
                        backBrush = Brushes.Blue
                        backPen = Pens.Blue
                        textBrush = Brushes.White
                    Case WaferStatuses.PARTIAL
                        backBrush = Brushes.Yellow
                        backPen = Pens.Yellow
                        textBrush = Brushes.Black
                    Case WaferStatuses.COMPLETE
                        backBrush = Brushes.Lime
                        backPen = Pens.Lime
                        textBrush = Brushes.Black
                    Case WaferStatuses.ERROR
                        backBrush = Brushes.Red
                        backPen = Pens.Red
                        textBrush = Brushes.White
                    Case Else
                        backBrush = Brushes.Transparent
                        backPen = Pens.Transparent
                        textBrush = Brushes.Transparent
                End Select

                Dim waferRect As Rectangle = New Rectangle(palletWidth - CInt(PalletDiameter / 2.0F) - m_distanceWaferForForwardDirection - waferWidth - 1, 0, waferWidth + 1, WaferHeight * 2)
                If IsShowWaferPosition Then
                    AVPGraphicsLib.FillRoundedRectangle(g, waferRect, WaferDiameter, backBrush)
                    AVPGraphicsLib.DrawRoundedRectangle(g, waferRect, WaferDiameter, borderPen)
                End If

                Dim palletRect As Rectangle = New Rectangle(0, WaferHeight, palletWidth - 1, palletHeight - WaferHeight - 1)
                AVPGraphicsLib.FillRoundedRectangle(g, palletRect, PalletDiameter, backBrush)
                AVPGraphicsLib.DrawRoundedRectangle(g, palletRect, PalletDiameter, borderPen)

                If IsShowWaferPosition Then
                    g.DrawLine(backPen, waferRect.X + 1, WaferHeight, waferRect.X + waferRect.Width - 1, WaferHeight)
                End If

                ' Draw question mark
                Dim isDrawnQuestionMark As Boolean = False
                Dim questionMarkWidth As Integer
                If IsShowQuestionMark Then
                    Dim qmImg As Bitmap = CType(IIf(m_processingStatus = WaferStatuses.ERROR, My.Resources.Resources.InlinePallet_QuestionMark_White, My.Resources.Resources.InlinePallet_QuestionMark_Red), Bitmap)
                    questionMarkWidth = qmImg.Width
                    If palletWidth >= MinPalletWidth + questionMarkWidth Then
                        g.DrawImageUnscaled(qmImg, palletWidth - questionMarkWidth - 2, WaferHeight)
                        isDrawnQuestionMark = True
                    End If
                    qmImg.Dispose()
                End If

                ' Draw text
                If Not String.IsNullOrEmpty(PalletID) Then
                    Dim fontid As Font = New Font(WAFERID_FONT_NAME, 11, WAFERID_FONT_STYLE)
                    Dim textSize As SizeF = g.MeasureString(PalletID, fontid)
                    Dim textArea As Integer = palletWidth
                    If isDrawnQuestionMark Then
                        textArea -= questionMarkWidth
                    End If
                    Dim pos As PointF = New PointF((textArea - textSize.Width) / 2.0F, (palletHeight - WaferHeight - textSize.Height) / 2.0F)

                    g.DrawString(PalletID, fontid, textBrush, pos.X, WaferHeight + pos.Y)

                    fontid.Dispose()
                End If

            End Using

            Return img
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Set wafer info to control
    ''' </summary>
    Public Overloads Sub SetWaferInfo(ByVal waferInfo As WaferInfo, ByVal isShowQuestionMark As Boolean)
        Try
            Dim waferStatus As WaferStatuses = WaferStatuses.NONE
            Dim waferID As String = ""

            If Not AVPControls.AVPDataLib.WaferInfo.IsEmpty(waferInfo) Then
                waferStatus = waferInfo.WaferStatus
                waferID = waferInfo.WaferID
            End If

            SetWaferInfo(waferStatus, waferID, isShowQuestionMark)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Set wafer info to control
    ''' </summary>
    Public Overloads Sub SetWaferInfo(ByVal waferInfo As WaferInfo)
        Try
            Dim waferStatus As WaferStatuses = WaferStatuses.NONE
            Dim waferID As String = ""

            If Not AVPControls.AVPDataLib.WaferInfo.IsEmpty(waferInfo) Then
                waferStatus = waferInfo.WaferStatus
                waferID = waferInfo.WaferID
            End If

            SetWaferInfo(waferStatus, waferID)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Set wafer info to control
    ''' </summary>
    Public Overloads Sub SetWaferInfo(ByVal waferStatus As WaferStatuses, ByVal waferID As String, ByVal isShowQuestionMark As Boolean)
        Try
            Dim statusChanged As Boolean
            Dim idChanged As Boolean
            Dim dataChanged As Boolean

            If m_processingStatus <> waferStatus Then
                m_processingStatus = waferStatus
                statusChanged = True
                dataChanged = True
            End If

            If m_palletID <> waferID Then
                m_palletID = waferID
                idChanged = True
                dataChanged = True
            End If

            If m_showQuestionMark <> isShowQuestionMark Then
                m_showQuestionMark = isShowQuestionMark
                dataChanged = True
            End If

            If dataChanged Then
                UpdateView()
            End If

            If statusChanged Then
                OnProcessingStatusChanged(EventArgs.Empty)
            End If

            If idChanged Then
                OnWaferIDChanged(EventArgs.Empty)
            End If

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Set wafer info to control
    ''' </summary>
    Public Overloads Sub SetWaferInfo(ByVal waferStatus As WaferStatuses, ByVal waferID As String)
        SetWaferInfo(waferStatus, waferID, m_showQuestionMark)
    End Sub

#End Region

#Region "Events"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_allowEmptyRegion = False

        ' Set region of control when wafer status is NONE.
        Me.RequireInitializeForUpdateView = False
        Me.DoubleBuffered = True
        Me.IsInitialized = True
        Me.ResumeUpdateView()

    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Raise the event WaferStatusChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnProcessingStatusChanged(ByVal e As EventArgs)
        RaiseEvent ProcessingStatusChanged(Me, e)
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Raise the event WaferIDChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnWaferIDChanged(ByVal e As EventArgs)
        RaiseEvent PalletIDChanged(Me, e)
    End Sub

#End Region

End Class
