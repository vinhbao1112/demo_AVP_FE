Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class SlotMapControl

#Region "Class Constants & Variables"
    Private Const DEFAULT_NUMBER_OF_SLOT As Integer = 12
    Private Const WAFER_RADIUS As Integer = 23
    Private Const SPACE_BTW_WAFER As Integer = 5

    Private m_columnCount As Integer = 6
    Private m_drawColumnHeight As Integer

    Private MyFont As New Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Pixel)

    Private m_numslots As Integer
    Private m_slotStatuses As WaferStatuses()
    Private m_currentSlotNumber As Integer

#End Region

#Region "Constructors & Dispose"

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Initate pressure graph
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetNumOfSlots(DEFAULT_NUMBER_OF_SLOT)
    End Sub

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Get or set the number of slots
    ''' </summary>
    <DefaultValue(DEFAULT_NUMBER_OF_SLOT)> _
    Public Property Numslots() As Integer
        Get
            Return m_numslots
        End Get
        Set(ByVal value As Integer)
            SetNumOfSlots(value)
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Get or set status of a slot based on index
    ''' </summary>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Default Public Property SlotStatuses(ByVal index As Integer) As WaferStatuses
        Get
            If index >= 0 AndAlso index < m_numslots Then
                Return m_slotStatuses(index)
            End If
            Return WaferStatuses.NONE
        End Get
        Set(ByVal value As WaferStatuses)
            If index >= 0 AndAlso index < m_numslots Then
                If m_slotStatuses(index) <> value Then
                    m_slotStatuses(index) = value
                    UpdateView()
                End If
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Get or set Position slot of Elevator
    ''' </summary>
    <DefaultValue(0)> _
    Public Property CurrentSlotNumber() As Integer
        Get
            Return m_currentSlotNumber
        End Get
        Set(ByVal value As Integer)
            If m_currentSlotNumber <> value Then
                m_currentSlotNumber = value
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Get or set current slot status.
    ''' </summary>
    <DefaultValue(GetType(WaferStatuses), "NONE")> _
    Public Property CurrentSlotStatus() As WaferStatuses
        Get
            If CurrentSlotNumber >= 1 AndAlso CurrentSlotNumber <= m_slotStatuses.Length Then
                Return m_slotStatuses(CurrentSlotNumber - 1)
            End If
            Return WaferStatuses.NONE
        End Get
        Set(ByVal value As WaferStatuses)
            If CurrentSlotNumber >= 1 AndAlso CurrentSlotNumber <= m_slotStatuses.Length Then
                If m_slotStatuses(CurrentSlotNumber - 1) <> value Then
                    m_slotStatuses(CurrentSlotNumber - 1) = value
                    UpdateView()
                End If
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Get or set draw column height.
    ''' </summary>
    <DefaultValue(0)> _
    Public Property DrawColumnHeight() As Integer
        Get
            Return m_drawColumnHeight
        End Get
        Set(ByVal value As Integer)
            If m_drawColumnHeight <> value AndAlso value >= 0 Then
                m_drawColumnHeight = value
                UpdateColumnCount()
            End If
        End Set
    End Property

#End Region

#Region "Public methods"

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Clear slot status.
    ''' </summary>
    Public Sub Clear()
        Try
            For i As Integer = 0 To (m_numslots - 1)
                m_slotStatuses(i) = WaferStatuses.NONE
            Next i
            UpdateView()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Get slot status.
    ''' </summary>
    Public Function GetSlotStatus(ByVal i As Integer) As WaferStatuses
        Try
            Return m_slotStatuses(i)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Set bar status, reset BarsNum if the index is out of range
    ''' </summary>
    Public Sub SetSlotStatus(ByVal index As Integer, ByVal value As WaferStatuses)
        Try
            If index >= m_numslots Then
                Numslots = index + 1
            End If
            If m_slotStatuses(index) <> value Then
                m_slotStatuses(index) = value
                UpdateView()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Events – Buttons – Forms…"

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Set number of slots, redim status array, and set width of control
    ''' </summary>
    Private Sub SetNumOfSlots(ByVal value As Integer)
        Try
            If m_numslots <> value AndAlso value > 0 Then
                m_numslots = value
                ReDim Preserve m_slotStatuses(m_numslots - 1)
                UpdateView()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Draws slot image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Try
            Dim x As Single = 0
            Dim y As Single = 0
            Dim slotNumber As Integer = 0
            Dim int_nextRow As Integer = 0
            Dim verticalSpace As Integer = SPACE_BTW_WAFER
            If m_drawColumnHeight <> 0 Then
                verticalSpace = CInt(((Me.Height - 2.0 - SPACE_BTW_WAFER * 2.0) - WAFER_RADIUS * m_drawColumnHeight) / (m_drawColumnHeight - 1.0))
                If verticalSpace <= 0 Then
                    verticalSpace = 1
                End If
            End If

            Dim img As Bitmap = New Bitmap(Me.Width, Me.Height)
            Using g As Graphics = Graphics.FromImage(img)
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                g.FillRectangle(Brushes.Gainsboro, New Rectangle(0, 0, img.Width - 1, img.Height - 1))

                'GET CONFIG COLOR FOR WAFER STATUS
                Dim lastRowPosition As Integer = 1 + SPACE_BTW_WAFER + (m_columnCount - 1) * (WAFER_RADIUS + verticalSpace)
                y = lastRowPosition
                x = SPACE_BTW_WAFER
                For i As Integer = 0 To (m_numslots - 1)
                    If (y < SPACE_BTW_WAFER) Then
                        int_nextRow = m_columnCount - 1
                        x += WAFER_RADIUS + SPACE_BTW_WAFER
                        y = lastRowPosition
                    Else
                        int_nextRow -= 1
                    End If
                    'TEXT NUM
                    slotNumber = i + 1

                    Dim waferImage As Bitmap = Nothing
                    Dim waferIDColor As Color = Color.White

                    Select Case m_slotStatuses(slotNumber - 1)
                        Case WaferStatuses.PARTIAL 'Invalid
                            waferImage = My.Resources.Resources.Wafer_Partial
                            waferIDColor = Color.Black
                        Case WaferStatuses.NONE
                            waferImage = My.Resources.Resources.Wafer_BlackGraph
                            waferIDColor = Color.White
                        Case WaferStatuses.ERROR
                            waferImage = My.Resources.Resources.Wafer_Error
                            waferIDColor = Color.White
                        Case WaferStatuses.COMPLETE
                            waferImage = My.Resources.Resources.Wafer_Complete
                            waferIDColor = Color.Black
                        Case WaferStatuses.UNPROCESS
                            waferImage = My.Resources.Resources.Wafer_Unprocess
                            waferIDColor = Color.White
                    End Select

                    ''DRAW CIRCLE
                    g.DrawImage(waferImage, x, y, WAFER_RADIUS, WAFER_RADIUS)

                    Dim textSize As SizeF = g.MeasureString(slotNumber.ToString(), MyFont)
                    Dim xPos As Single = x + (WAFER_RADIUS - textSize.Width) / 2.0F + 1

                    Using textBrush As Brush = New SolidBrush(waferIDColor)
                        g.DrawString(slotNumber.ToString(), MyFont, textBrush, xPos, y + SPACE_BTW_WAFER - 1)
                    End Using

                    'DRAW INDICATOR LED
                    If slotNumber = Me.CurrentSlotNumber Then
                        g.FillEllipse(Brushes.Yellow, x, y, 7, 7)
                        g.DrawEllipse(Pens.Black, x, y, 7, 7)
                    End If

                    waferImage.Dispose()
                    waferImage = Nothing

                    y -= (WAFER_RADIUS + verticalSpace)
                Next i
            End Using
            Return img
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Update view on size changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SlotMapControl_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Try
            If Not UpdateColumnCount() Then
                UpdateView()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-15</date>
    ''' <summary>
    ''' Update column count.
    ''' </summary>
    Private Function UpdateColumnCount() As Boolean
        Try
            Dim columnCount As Integer

            If m_drawColumnHeight <> 0 Then
                columnCount = m_drawColumnHeight
            Else
                columnCount = CInt(Me.Height / (WAFER_RADIUS + SPACE_BTW_WAFER))
            End If

            If m_columnCount <> columnCount Then
                m_columnCount = columnCount
                UpdateView()
                Return True
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return False
    End Function

#End Region

End Class
