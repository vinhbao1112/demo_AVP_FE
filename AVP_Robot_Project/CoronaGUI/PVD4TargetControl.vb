Imports System.ComponentModel

Public Class PVD4TargetControl
    Private m_defaultWidth As Integer = 322
    Private m_defaultHeight As Integer = 144
    Private imgCtrl As Bitmap = Nothing
    Private m_t1installed As Boolean = True
    Private m_t2installed As Boolean = True
    Private m_t3installed As Boolean = True
    Private m_t4installed As Boolean = True
    Private m_t1status As DisplayStatus = DisplayStatus.Off
    Private m_t2status As DisplayStatus = DisplayStatus.Off
    Private m_t3status As DisplayStatus = DisplayStatus.Off
    Private m_t4status As DisplayStatus = DisplayStatus.Off
    Private m_t1text As String = "T1"
    Private m_t2text As String = "T2"
    Private m_t3text As String = "T3"
    Private m_t4text As String = "T4"
    Private m_currentTargetIndex As TargetIndexs = TargetIndexs.None
    Private m_currentTargetStatus As DisplayStatus = DisplayStatus.Off
    Private m_needCreateRegion As Boolean = True
    Private m_hasDataChanged As Boolean = True
    Private m_drawLocker As New Object

    Public Event StatusChanged(ByVal sender As Object, ByVal targetIndex As TargetIndexs)

    Public Enum TargetIndexs
        None = 0
        Target1 = 1
        Target2 = 2
        Target3 = 3
        Target4 = 4
        Target5 = 5
    End Enum

#Region "Properties"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the value indicate Target 1 is installed
    ''' </summary>
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property T1Installed() As Boolean
        Get
            Return m_t1installed
        End Get
        Set(ByVal value As Boolean)
            If m_t1installed <> value Then
                m_t1installed = value
                m_hasDataChanged = True
                m_needCreateRegion = True
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the value indicate Target 2 is installed
    ''' </summary>
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property T2Installed() As Boolean
        Get
            Return m_t2installed
        End Get
        Set(ByVal value As Boolean)
            If m_t2installed <> value Then
                m_t2installed = value
                m_hasDataChanged = True
                m_needCreateRegion = True
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the value indicate Target 3 is installed
    ''' </summary>
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property T3Installed() As Boolean
        Get
            Return m_t3installed
        End Get
        Set(ByVal value As Boolean)
            If m_t3installed <> value Then
                m_t3installed = value
                m_hasDataChanged = True
                m_needCreateRegion = True
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the value indicate Target 4 is installed
    ''' </summary>
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property T4Installed() As Boolean
        Get
            Return m_t4installed
        End Get
        Set(ByVal value As Boolean)
            If m_t4installed <> value Then
                m_t4installed = value
                m_hasDataChanged = True
                m_needCreateRegion = True
            End If
        End Set
    End Property


    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set text for Target 1
    ''' </summary>
    <DefaultValue(GetType(String), "T1")> _
    Public Property T1Text() As String
        Get
            Return m_t1text
        End Get
        Set(ByVal value As String)
            If m_t1text <> value Then
                m_t1text = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set text for Target 2
    ''' </summary>
    <DefaultValue(GetType(String), "T2")> _
    Public Property T2Text() As String
        Get
            Return m_t2text
        End Get
        Set(ByVal value As String)
            If m_t2text <> value Then
                m_t2text = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set text for Target 3
    ''' </summary>
    <DefaultValue(GetType(String), "T3")> _
    Public Property T3Text() As String
        Get
            Return m_t3text
        End Get
        Set(ByVal value As String)
            If m_t3text <> value Then
                m_t3text = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set text for Target 4
    ''' </summary>
    <DefaultValue(GetType(String), "T4")> _
    Public Property T4Text() As String
        Get
            Return m_t4text
        End Get
        Set(ByVal value As String)
            If m_t4text <> value Then
                m_t4text = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set current target index
    ''' </summary>
    <DefaultValue(GetType(TargetIndexs), "None")> _
    Public Property ActiveTarget() As TargetIndexs
        Get
            Return m_currentTargetIndex
        End Get
        Set(ByVal value As TargetIndexs)
            If m_currentTargetIndex <> value AndAlso value >= TargetIndexs.None AndAlso value <= TargetIndexs.Target4 Then
                TargetStatus = DisplayStatus.Off
                m_currentTargetIndex = value
                m_currentTargetStatus = DisplayStatus.Off
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set current target status
    ''' </summary>
    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Property TargetStatus() As DisplayStatus
        Get
            Return m_currentTargetStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_currentTargetStatus <> value Then
                If value = DisplayStatus.Off OrElse value = DisplayStatus.On OrElse value = DisplayStatus.Unknow Then
                    m_t1status = DisplayStatus.Off
                    m_t2status = DisplayStatus.Off
                    m_t3status = DisplayStatus.Off
                    m_t4status = DisplayStatus.Off

                    m_currentTargetStatus = value

                    Select Case m_currentTargetIndex
                        Case TargetIndexs.Target1
                            m_t1status = m_currentTargetStatus
                        Case TargetIndexs.Target2
                            m_t2status = m_currentTargetStatus
                        Case TargetIndexs.Target3
                            m_t3status = m_currentTargetStatus
                        Case TargetIndexs.Target4
                            m_t4status = m_currentTargetStatus
                    End Select

                    m_hasDataChanged = True
                    Repaint()

                    Try
                        RaiseEvent StatusChanged(Me, m_currentTargetIndex)
                    Catch ex As Exception
                        AVPLib.Log.avpLogger.Error(ex.ToString())
                    End Try
                End If
            End If
        End Set
    End Property
#End Region

#Region "Methods"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-31 </date>
    ''' </author>
    ''' <summary>
    ''' Set current target index
    ''' </summary>
    Public Sub SetActiveTarget(ByVal index As Integer)
        Dim targetIndex As TargetIndexs
        Dim isOther As Boolean = False
        Select Case index
            Case 0
                targetIndex = TargetIndexs.Target1
            Case 1
                targetIndex = TargetIndexs.Target2
            Case 2
                targetIndex = TargetIndexs.Target3
            Case 3
                targetIndex = TargetIndexs.Target4
            Case Else
                isOther = True
        End Select

        If Not isOther Then
            If targetIndex <> m_currentTargetIndex Then
                m_currentTargetIndex = targetIndex

                m_t1status = DisplayStatus.Off
                m_t2status = DisplayStatus.Off
                m_t3status = DisplayStatus.Off
                m_t4status = DisplayStatus.Off


            End If
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Paint control base on status data
    ''' </summary>
    Public Sub Repaint()
        SyncLock m_drawLocker
            Try
                If m_hasDataChanged Then
                    PaintImage()
                    m_hasDataChanged = False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End SyncLock
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Paint control
    ''' </summary>
    Private Sub PaintImage()
        Try
            Dim imgTarget As Bitmap = My.Resources.Resources.PVD4Chamber_Target

            imgCtrl = New Bitmap(m_defaultWidth, m_defaultHeight)
            imgCtrl.SetResolution(imgTarget.HorizontalResolution, imgTarget.VerticalResolution)

            Using gr As Graphics = Graphics.FromImage(imgCtrl)
                If T2Installed Then
                    Dim p As Point = GetTargetLocation(2)
                    Dim img As Bitmap = GetTargetImage(m_t2status, T2Text)
                    gr.DrawImage(img, p)

                    p = Nothing
                    img.Dispose()
                End If

                If T1Installed Then
                    Dim p As Point = GetTargetLocation(1)
                    Dim img As Bitmap = GetTargetImage(m_t1status, T1Text)
                    gr.DrawImage(img, p)

                    p = Nothing
                    img.Dispose()
                End If

                If T3Installed Then
                    Dim p As Point = GetTargetLocation(3)
                    Dim img As Bitmap = GetTargetImage(m_t3status, T3Text)
                    gr.DrawImage(img, p)

                    p = Nothing
                    img.Dispose()
                End If

                If T4Installed Then
                    Dim p As Point = GetTargetLocation(4)
                    Dim img As Bitmap = GetTargetImage(m_t4status, T4Text)
                    gr.DrawImage(img, p)

                    p = Nothing
                    img.Dispose()
                End If
            End Using

            If m_needCreateRegion Then
                Utils.CreateControlRegion(Me, imgCtrl)
                m_needCreateRegion = False
            Else
                Me.BackgroundImage = imgCtrl
            End If

            imgTarget = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-21 </date>
    ''' </author>
    ''' <summary>
    ''' Target location
    ''' </summary>
    Private Function GetTargetLocation(ByVal targetIndex As Integer) As Point
        Dim location As Point = New Point(0, 0)
        Select Case targetIndex
            Case 1
                location = New Point(0, 13)
            Case 2
                location = New Point(110, 0)
            Case 3
                location = New Point(191, 19)
            Case 4
                location = New Point(84, 33)
        End Select
        Return location
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-14 </date>
    ''' </author>
    ''' <summary>
    ''' Draw target label
    ''' </summary>
    Private Function GetTargetImage(ByVal status As DisplayStatus, ByVal text As String) As Bitmap
        Try
            Dim imgTarget As Bitmap = My.Resources.Resources.PVD4Chamber_Target
            Dim imgTargetPlasma As Bitmap = My.Resources.Resources.PVD4Chamber_Target_Plasma
            Dim imgTargetRamp As Bitmap = My.Resources.Resources.PVD4Chamber_Target_Ramp

            Dim img As Bitmap = New Bitmap(imgTarget.Width, imgTarget.Height)
            img.SetResolution(imgTarget.HorizontalResolution, imgTarget.VerticalResolution)

            Using gr As Graphics = Graphics.FromImage(img)
                Dim targetFont As Font = New Font("Times New Roman", 11, FontStyle.Bold, GraphicsUnit.Point)
                Dim targetTextColor As New SolidBrush(Me.ForeColor)
                Dim centerPoint As PointF = New PointF(imgTarget.Width / 2, 11.5F)
                Dim targetSize As SizeF = gr.MeasureString(text, targetFont)
                Dim targetLocation As PointF = New PointF(centerPoint.X - targetSize.Width / 2, centerPoint.Y - targetSize.Height / 2)

                Dim imgDraw As Bitmap
                Select Case status
                    Case DisplayStatus.Off
                        imgDraw = imgTarget
                    Case DisplayStatus.On
                        imgDraw = imgTargetPlasma
                    Case Else
                        imgDraw = imgTargetRamp
                End Select

                gr.DrawImage(imgDraw, 0, 0, imgDraw.Width, imgDraw.Height)
                gr.DrawString(text, targetFont, targetTextColor, targetLocation)

                targetFont.Dispose()
                targetTextColor.Dispose()
                centerPoint = Nothing
                targetSize = Nothing
                targetLocation = Nothing
                imgDraw = Nothing
            End Using

            imgTarget = Nothing
            imgTargetPlasma = Nothing
            imgTargetRamp = Nothing

            Return img
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

#End Region

#Region "Events"
    Private Sub CORONA_TargetControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Repaint()

        If imgCtrl IsNot Nothing Then
            Me.Width = imgCtrl.Width
            Me.Height = imgCtrl.Height
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DoubleBuffered = True
        Me.Width = m_defaultWidth
        Me.Height = m_defaultHeight
    End Sub
#End Region

End Class
