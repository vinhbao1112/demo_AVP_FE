Imports System.ComponentModel
Imports AVPControls.AVPDataLib
Imports AVPControls.AVPUtils

''' <author>
'''     <name>Hai Tran</name>
'''     <date>2015-09-14</date>
''' </author>
''' <summary>
''' Gas-line control
''' </summary>
''' <remarks></remarks>
Public Class AVPGaslineControl
    Private m_img As Bitmap
    Private m_bubbles As List(Of GasBubble) = New List(Of GasBubble)
    Private m_direction As GasDirections = GasDirections.FromLeftBottom
    Private m_fromAngle As Integer = 270
    Private m_toAngle As Integer = 360
    Private m_minDistance As Integer = 10
    Private m_maxDistance As Integer = 20
    Private m_minDiameter As Integer = 3
    Private m_maxDiameter As Integer = 5
    Private m_startPoints As List(Of PointF) = New List(Of PointF)
    Private m_gasRegion As Region
    Private m_error As String
    Private m_bubbleCount As Integer = 10
    Private m_flowAngle As Single
    Private m_startBubbles As List(Of GasBubble) = New List(Of GasBubble)

#Region "Data"
    ''' <summary>
    ''' Indicates the direction of gas-bubble in gas-line control.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum GasDirections
        FromLeft
        FromTop
        FromRight
        FromBottom
        FromLeftBottom
        FromLeftTop
        FromRightTop
        FromRightBottom
    End Enum

#End Region

#Region "Properties"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicates the direction of all gas-bubble of this gas-line control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(GasDirections), "FromLeftBottom")> _
    Public Property Direction() As GasDirections
        Get
            Return m_direction
        End Get
        Set(ByVal value As GasDirections)
            If m_direction <> value Then
                m_direction = value
                Me.GetFlowAngle()
                Me.InitBubbles()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicates the minimum distance on moving of gas-bubble of this gas-line control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Integer), "30")> _
    Public Property MinDistance() As Integer
        Get
            Return m_minDistance
        End Get
        Set(ByVal value As Integer)
            If m_minDistance <> value Then
                m_minDistance = value
                Me.InitBubbles()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicates the maximum distance on moving of gas-bubble of this gas-line control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Integer), "50")> _
    Public Property MaxDistance() As Integer
        Get
            Return m_maxDistance
        End Get
        Set(ByVal value As Integer)
            If m_maxDistance <> value Then
                m_maxDistance = value
                Me.InitBubbles()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicates the minimum distance of gas-bubble of this gas-line control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Integer), "3")> _
    Public Property MinDiameter() As Integer
        Get
            Return m_minDiameter
        End Get
        Set(ByVal value As Integer)
            If m_minDiameter <> value Then
                m_minDiameter = value
                Me.InitBubbles()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicates the maximum diameter of gas-bubble of this gas-line control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Integer), "5")> _
    Public Property MaxDiameter() As Integer
        Get
            Return m_maxDiameter
        End Get
        Set(ByVal value As Integer)
            If m_maxDiameter <> value Then
                m_maxDiameter = value
                Me.InitBubbles()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a image indicates gas-line image of this control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Image() As Bitmap
        Get
            Return m_img
        End Get
        Set(ByVal value As Bitmap)
            m_img = value
            m_gasRegion = AVPGraphicsLib.GetRegion(m_img)
            UpdateView()
            InitBubbles()
        End Set
    End Property

    Protected ReadOnly Property GasRegion() As Region
        Get
            Return m_gasRegion
        End Get
    End Property

    Public ReadOnly Property StartPointCount() As Integer
        Get
            Return m_startPoints.Count
        End Get
    End Property

    ''' <summary>
    ''' Get or set a value indicates number of bubble will be moved in gas-line.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BubbleCount() As Integer
        Get
            Return m_bubbleCount
        End Get
        Set(ByVal value As Integer)
            If m_bubbleCount <> value Then
                m_bubbleCount = value
                InitBubbles()
            End If
        End Set
    End Property

    Public Property StartPoints() As List(Of PointF)
        Get
            Return m_startPoints
        End Get
        Set(ByVal value As List(Of PointF))
            m_startPoints = value
        End Set
    End Property

    Public Property FlowAngle() As Single
        Get
            Return m_flowAngle
        End Get
        Set(ByVal value As Single)
            If m_flowAngle <> value Then
                m_flowAngle = value
            End If
        End Set
    End Property

    Public Property [Error]() As String
        Get
            Return m_error
        End Get
        Set(ByVal value As String)
            m_error = value
        End Set
    End Property
#End Region

#Region "Methods"
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Dim img As Bitmap = Nothing

        If m_img IsNot Nothing Then
            img = New Bitmap(m_img.Width, m_img.Height)
            img.SetResolution(m_img.HorizontalResolution, m_img.VerticalResolution)

            Dim g As Graphics = Graphics.FromImage(img)
            ' Draw gas-line image
            g.DrawImage(m_img, 0, 0, img.Width, img.Height)

            If m_status = AVPControls.AVPDataLib.DisplayStatus.On Then
                ' Draw all gas-bubbles
                g.Clip = Me.GasRegion
                For index As Integer = 0 To m_bubbles.Count - 1
                    Dim bubble As GasBubble = m_bubbles(index)
                    g.DrawEllipse(Pens.Green, CInt(bubble.Point.X), CInt(bubble.Point.Y), CInt(bubble.Diameter), CInt(bubble.Diameter))
                    g.FillEllipse(Brushes.Green, CInt(bubble.Point.X), CInt(bubble.Point.Y), CInt(bubble.Diameter), CInt(bubble.Diameter))
                Next
            End If

            g.Dispose()
        End If

        Return img
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Get a range of angle base on direction.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetFlowAngle()
        Select Case m_direction
            Case GasDirections.FromLeft
                m_flowAngle = 0
            Case GasDirections.FromTop
                m_flowAngle = 90
            Case GasDirections.FromRight
                m_flowAngle = 180
            Case GasDirections.FromBottom
                m_flowAngle = 270
            Case GasDirections.FromLeftBottom
                m_flowAngle = 315
            Case GasDirections.FromLeftTop
                m_flowAngle = 45
            Case GasDirections.FromRightTop
                m_flowAngle = 135
            Case GasDirections.FromRightBottom
                m_flowAngle = 225
        End Select
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Get a random value indicates distance of gas-bubble.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRandomDistance() As Integer
        Return GetRandom(m_minDistance, m_maxDistance)
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Move all gas-bubbles to the next available position in control region.
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Function MoveNextAll() As Boolean
        Dim isMoved As Boolean = True
        If Not AVPGraphicsLib.IsRegionNullOrEmpty(Me.GasRegion, Me.CreateGraphics()) Then
            For index As Integer = 0 To m_bubbles.Count - 1
                isMoved = isMoved And Me.MoveNext(m_bubbles(index))
            Next
        End If
        Return isMoved
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Move specified gas-bubble to the next available position in control region.
    ''' </summary>
    ''' <param name="bubble"></param>
    ''' <remarks></remarks>
    Private Overloads Function MoveNext(ByRef bubble As GasBubble) As Boolean
        Dim isMoved As Boolean = False
        Try
            Dim availableBubbles As List(Of GasBubble) = GetNext(bubble)
            isMoved = SelectNext(bubble, availableBubbles)
            availableBubbles.Clear()
            availableBubbles = Nothing
        Catch ex As Exception
            Logger.Error(ex.ToString())
            m_error = ex.ToString()
        End Try
        Return isMoved
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-16</date>
    ''' </author>
    ''' <summary>
    ''' Get a list of available bubbles which moved by specified bubble.
    ''' </summary>
    ''' <param name="bubble">Current bubble will be moved.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNext(ByVal bubble As GasBubble) As List(Of GasBubble)
        Dim lst As List(Of GasBubble) = New List(Of GasBubble)

        Dim nextPoint As PointF
        Dim dAngle As Integer = 0
        While dAngle < 360
            nextPoint = GetPointNext(bubble.Point, bubble.Distance, dAngle)
            If IsInGasline(nextPoint, bubble.Diameter) Then
                Dim validBubble As New GasBubble(nextPoint, bubble.Diameter, bubble.Distance, dAngle)
                If Not lst.Contains(validBubble) Then
                    lst.Add(validBubble)
                End If
            End If

            dAngle += 1
        End While

        Return lst
    End Function

    ''' <summary>
    ''' Get a value indicates the point which moved by specified point.
    ''' </summary>
    ''' <param name="point">Current point.</param>
    ''' <param name="distance">Distance to move.</param>
    ''' <param name="angle">Angle to move.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPointNext(ByVal point As PointF, ByVal distance As Single, ByVal angle As Single) As PointF
        Dim dx As Single = Convert.ToSingle(Math.Round(distance * Math.Cos(angle * Math.PI / 180)) + point.X)
        Dim dy As Single = Convert.ToSingle(Math.Round(distance * Math.Sin(angle * Math.PI / 180)) + point.Y)
        Return New PointF(dx, dy)
    End Function

    ''' <summary>
    ''' Select next moved bubble.
    ''' </summary>
    ''' <param name="bubble"></param>
    ''' <param name="listBubbles"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SelectNext(ByRef bubble As GasBubble, ByVal listBubbles As List(Of GasBubble)) As Boolean
        Dim isMoved As Boolean = False

        If listBubbles IsNot Nothing AndAlso listBubbles.Count > 0 Then
            ' Get range of angle of gas flow.
            Dim fromAngle As Single = bubble.Angle - 100
            Dim toAngle As Single = bubble.Angle + 100
            'If bubble.Angle < FlowAngle Then
            '    fromAngle = bubble.Angle
            '    toAngle = FlowAngle
            'Else
            '    fromAngle = bubble.Angle - 90
            '    toAngle = bubble.Angle
            'End If

            ' Add available gas bubble in range to list
            Dim lst As List(Of GasBubble) = New List(Of GasBubble)
            For index As Integer = 0 To listBubbles.Count - 1
                If (FlowAngle = bubble.Angle OrElse (listBubbles(index).Angle >= fromAngle AndAlso listBubbles(index).Angle <= toAngle)) AndAlso Not HasIntersection(listBubbles(index)) Then
                    lst.Add(listBubbles(index))
                End If
            Next

            ' Select from list
            If lst.Count > 0 Then
                m_error = lst.Count.ToString()
                Dim index As Integer = GetRandom(0, lst.Count - 1)
                bubble = New GasBubble(lst(index))
                isMoved = True
            End If

            ' Select start point if not selected
            If Not isMoved Then
                Dim startPoint As PointF = GetStartPoint()
                If Not startPoint.IsEmpty Then
                    bubble.SetPoint(startPoint)
                    bubble.Angle = FlowAngle
                    isMoved = True
                    m_error = bubble.ToString()
                End If
            End If

            lst.Clear()
            lst = Nothing
        End If

        Return isMoved
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Scan available start point in region of this control.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalculateStartPoints()
        m_startPoints.Clear()
        If Not AVPGraphicsLib.IsRegionNullOrEmpty(Me.GasRegion, Me.CreateGraphics()) Then

            ' Get available point from left edge of control.
            If m_direction = GasDirections.FromLeft _
            OrElse m_direction = GasDirections.FromLeftBottom _
            OrElse m_direction = GasDirections.FromLeftTop Then
                GetPointFromRect(0, 0, 1, Me.Height)
            End If

            ' Get available point from top edge of control.
            If m_direction = GasDirections.FromTop _
            OrElse m_direction = GasDirections.FromLeftTop _
            OrElse m_direction = GasDirections.FromRightTop Then
                GetPointFromRect(0, 0, Me.Width, 1)
            End If

            ' Get available point from left right of control.
            If m_direction = GasDirections.FromRight _
            OrElse m_direction = GasDirections.FromRightTop _
            OrElse m_direction = GasDirections.FromRightBottom Then
                GetPointFromRect(Me.Width - 1, 0, 1, Me.Height)
            End If

            ' Get available point from left bottom of control.
            If m_direction = GasDirections.FromBottom _
            OrElse m_direction = GasDirections.FromLeftBottom _
            OrElse m_direction = GasDirections.FromRightBottom Then
                GetPointFromRect(0, Me.Height - 1, Me.Width, 1)
            End If

            m_startPoints.TrimExcess()
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-09</date>
    ''' </author>
    ''' <summary>
    ''' Get points in gas-region from specified rectangle.
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="width"></param>
    ''' <param name="height"></param>
    ''' <remarks></remarks>
    Private Sub GetPointFromRect(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        Dim isStart As Boolean
        Dim isEnd As Boolean
        Dim edgePoints As New List(Of PointF)
        Dim p As PointF
        For startX As Integer = 0 To width - 1
            For startY As Integer = 0 To height - 1
                p = New PointF(startX + x, startY + y)
                If Me.GasRegion.IsVisible(p) Then
                    edgePoints.Add(p)
                    isStart = True
                Else
                    If isStart Then
                        isEnd = True
                    End If
                End If

                ' Add start point as the middle point of gas-line.
                If isStart AndAlso isEnd AndAlso edgePoints.Count > 0 Then
                    Dim middleIndex As Integer = Convert.ToInt32((edgePoints.Count - 1) / 2)
                    m_startPoints.Add(edgePoints(middleIndex))
                    edgePoints.Clear()
                    isStart = False
                    isEnd = False
                End If
            Next
        Next

        edgePoints.Clear()
        edgePoints = Nothing
    End Sub

    ''' <summary>
    ''' Get a random point from start points of this control.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetStartPoint() As PointF
        If m_startPoints.Count > 0 Then
            Dim index As Integer = GetRandom(0, m_startPoints.Count - 1)
            Dim startPoint As PointF = m_startPoints(index)
            Return startPoint
        End If
        Return PointF.Empty
    End Function

    Private Function GetRandomDiameter() As Single
        Dim diameter As Single = GetRandom(m_minDiameter, m_maxDiameter)
        Return diameter
    End Function

    Private Sub InitBubbles()
        Me.CalculateStartPoints()
        If m_startPoints.Count > 0 Then
            m_bubbles.Clear()
            Dim index As Integer = 0
            While index < m_bubbleCount
                Dim startpoint As PointF = GetStartPoint()

                If Not startpoint.IsEmpty Then
                    'Dim bubble As GasBubble = New GasBubble()
                    'bubble.SetPoint(startpoint)
                    'bubble.Diameter = GetRandomDiameter()
                    'bubble.Distance = GetRandomDistance()
                    'bubble.Angle = m_flowAngle
                    m_bubbles.Add(New GasBubble(startpoint, GetRandomDiameter(), GetRandomDistance(), m_flowAngle))
                    'bubble = Nothing
                End If

                index += 1
            End While
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-15</date>
    ''' </author>
    ''' <summary>
    ''' Check whether the specified point and diameter is in gas-line.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsInGasline(ByVal bubble As GasBubble) As Boolean
        Dim result As Boolean
        If Not AVPGraphicsLib.IsRegionNullOrEmpty(Me.GasRegion, Me.CreateGraphics()) Then
            result = Me.GasRegion.IsVisible(bubble.Point) _
                        AndAlso Me.GasRegion.IsVisible(bubble.Point.X + bubble.Diameter, bubble.Point.Y) _
                        AndAlso Me.GasRegion.IsVisible(bubble.Point.X + bubble.Diameter, bubble.Point.Y + bubble.Diameter) _
                        AndAlso Me.GasRegion.IsVisible(bubble.Point.X, bubble.Point.Y + bubble.Diameter)
        End If
        Return result
    End Function

    Private Function IsInGasline(ByVal point As PointF, ByVal diameter As Single) As Boolean
        Dim result As Boolean = False
        If Not AVPGraphicsLib.IsRegionNullOrEmpty(Me.GasRegion, Me.CreateGraphics()) Then
            result = Me.GasRegion.IsVisible(point) _
                        AndAlso Me.GasRegion.IsVisible(point.X + diameter, point.Y) _
                        AndAlso Me.GasRegion.IsVisible(point.X + diameter, point.Y + diameter) _
                        AndAlso Me.GasRegion.IsVisible(point.X, point.Y + diameter)
        End If
        Return result
    End Function

    Private Function HasIntersection(ByVal bubble As GasBubble) As Boolean
        Dim result As Boolean = False
        For index As Integer = 0 To m_bubbles.Count - 1
            If bubble.IntersectsWith(m_bubbles(index)) Then
                result = True
                Exit For
            End If
        Next
        Return result
    End Function

    Private Function GetRandom(ByVal minValue As Integer, ByVal maxValue As Integer) As Integer
        Static rd As System.Random = New System.Random()
        Return rd.Next(minValue, maxValue)
    End Function
#End Region

#Region "Animation"
    Protected Overrides Function IsStopAnimation() As Boolean
        Return m_status <> AVPControls.AVPDataLib.DisplayStatus.On
    End Function

    Protected Overrides Function IsStartAnimation() As Boolean
        Return m_status = AVPControls.AVPDataLib.DisplayStatus.On
    End Function

    Protected Overrides Sub UpdateAnimatingView()
        Me.MoveNextAll()
        Me.UpdateView()
    End Sub
#End Region

#Region "Events"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

    Private Sub AVPGaslineControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitBubbles()
    End Sub

    Private Sub AVPGaslineControl_StatusChanged(ByVal sender As Object, ByVal e As StatusChangedEventArgs) Handles Me.StatusChanged
        Try
            If m_status = AVPControls.AVPDataLib.DisplayStatus.On Then
                Me.StartAnimation()
            End If
        Catch ex As Exception
            m_error = ex.ToString()
        End Try
    End Sub
End Class

''' <author>
'''     <name>Hai Tran</name>
'''     <date>2015-09-14</date>
''' </author>
''' <summary>
''' Represents a gas-bubble of gas-line control.
''' </summary>
''' <remarks></remarks>
Public Class GasBubble
    Public Const DEFAULT_DIAMETER As Integer = 3
    Public Const DEFAULT_DISTANCE As Integer = 15

    Private m_point As PointF
    Private m_diameter As Single
    Private m_distance As Single
    Private m_angle As Single
    Private m_nextBubbles As List(Of GasBubble) = New List(Of GasBubble)

    Public Sub New()
        m_point = PointF.Empty
        m_diameter = DEFAULT_DIAMETER
        m_distance = DEFAULT_DISTANCE
    End Sub

    Public Sub New(ByVal value As GasBubble)
        m_point = New PointF(value.Point.X, value.Point.Y)
        m_diameter = value.Diameter
        m_distance = value.Distance
        m_angle = value.Angle
    End Sub

    Public Sub New(ByVal point As PointF, ByVal diameter As Single, ByVal distance As Single)
        m_point = point
        m_diameter = diameter
        m_distance = distance
    End Sub

    Public Sub New(ByVal point As PointF, ByVal diameter As Single, ByVal distance As Single, ByVal angle As Single)
        m_point = point
        m_diameter = diameter
        m_distance = distance
        m_angle = angle
    End Sub

    Public Property [Point]() As PointF
        Get
            Return m_point
        End Get
        Set(ByVal value As PointF)
            m_point = value
        End Set
    End Property

    Public Property Diameter() As Single
        Get
            Return m_diameter
        End Get
        Set(ByVal value As Single)
            m_diameter = value
        End Set
    End Property

    Public Property Distance() As Single
        Get
            Return m_distance
        End Get
        Set(ByVal value As Single)
            m_distance = value
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-08</date>
    ''' </author>
    Public Property NextBubbles() As List(Of GasBubble)
        Get
            Return m_nextBubbles
        End Get
        Set(ByVal value As List(Of GasBubble))
            m_nextBubbles = value
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-08</date>
    ''' </author>
    Public ReadOnly Property HasNext() As Boolean
        Get
            If m_nextBubbles Is Nothing OrElse m_nextBubbles.Count = 0 Then
                Return False
            End If
            Return True
        End Get
    End Property

    Public Property Angle() As Single
        Get
            Return m_angle
        End Get
        Set(ByVal value As Single)
            m_angle = value
        End Set
    End Property

    Public Overloads Sub SetPoint(ByVal x As Single, ByVal y As Single)
        Me.m_point.X = x
        Me.m_point.Y = y
    End Sub

    Public Overloads Sub SetPoint(ByVal point As PointF)
        Me.m_point = point
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-08</date>
    ''' </author>
    Public Function IntersectsWith(ByVal bubble As GasBubble) As Boolean
        Dim theirRect As RectangleF = New RectangleF(bubble.Point, New SizeF(bubble.Diameter, bubble.Diameter))
        Dim ownRect As RectangleF = New RectangleF(Me.Point, New SizeF(Me.Diameter, Me.Diameter))
        Dim result As Boolean = ownRect.IntersectsWith(theirRect)
        theirRect = Nothing
        ownRect = Nothing
        Return result
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("({0}, {1}, {2})", Point.ToString, Diameter.ToString(), Angle.ToString())
    End Function

    Public Shared Operator =(ByVal left As GasBubble, ByVal right As GasBubble) As Boolean
        Return left.Point = right.Point AndAlso left.Diameter = right.Diameter
    End Operator

    Public Shared Operator <>(ByVal left As GasBubble, ByVal right As GasBubble) As Boolean
        Return left.Point <> right.Point OrElse left.Diameter <> right.Diameter
    End Operator

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is GasBubble Then
            Dim bubble As GasBubble = DirectCast(obj, GasBubble)
            Return Me.Point = bubble.Point AndAlso Me.Diameter = bubble.Diameter
        End If
        Return False
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-08</date>
    ''' </author>
    ''' <summary>
    ''' Get next available bubble.
    ''' </summary>
    ''' <param name="bubble"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNext(ByRef bubble As GasBubble) As Boolean
        Dim success As Boolean
        Try
            If Me.HasNext Then
                If Me.m_nextBubbles.Count = 1 Then
                    bubble = m_nextBubbles(0)
                Else
                    Static rd As New Random
                    Dim index As Integer = rd.Next(0, m_nextBubbles.Count - 1)
                    bubble = m_nextBubbles(index)
                End If
                success = True
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return success
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-08</date>
    ''' </author>
    ''' <summary>
    ''' Release all references.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose()
        Try
            m_point = Nothing
            m_distance = Nothing
            m_diameter = Nothing
            m_angle = Nothing
            If m_nextBubbles IsNot Nothing Then
                For index As Integer = 0 To m_nextBubbles.Count - 1
                    m_nextBubbles(0).Dispose()
                Next
                m_nextBubbles.Clear()
                m_nextBubbles = Nothing
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub
End Class

