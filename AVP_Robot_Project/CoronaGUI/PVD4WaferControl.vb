Imports AVPLib
Imports System.ComponentModel

Public Class PVD4WaferControl
    Private imgCtrl As Bitmap = My.Resources.Resources.PVD4Chamber_Wafer_None
    Private m_status As ConstEnum.enumWaferStatus = ConstEnum.enumWaferStatus.eWaferNone
    Private m_waferID As String = String.Empty
    Private m_positionSlot As Integer = 1

    Private m_needCreateRegion As Boolean = True
    Private m_hasDataChanged As Boolean = True
    Private m_drawLocker As New Object

    Public Event StatusChanged(ByVal sender As Object)
    Public Event IDChanged(ByVal sender As Object)

#Region "Properties"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the value indicate slot wafer in
    ''' </summary>
    <DefaultValue(GetType(Integer), "1")> _
    Public Property PositionSlot() As Integer
        Get
            Return m_positionSlot
        End Get
        Set(ByVal value As Integer)
            If m_positionSlot <> value Then
                m_positionSlot = value
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the value indicate status of wafer
    ''' </summary>
    <DefaultValue(GetType(ConstEnum.enumWaferStatus), "eWaferNone")> _
    Public Property Status() As ConstEnum.enumWaferStatus
        Get
            Return m_status
        End Get
        Set(ByVal value As ConstEnum.enumWaferStatus)
            If m_status <> value Then
                m_status = value
                SetControlCursor()
                m_hasDataChanged = True
                Repaint()
                Try
                    RaiseEvent StatusChanged(Me)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set wafer ID
    ''' </summary>
    <DefaultValue(GetType(String), "")> _
    Public Property ID() As String
        Get
            Return m_waferID
        End Get
        Set(ByVal value As String)
            If m_waferID <> value Then
                m_waferID = value
                m_hasDataChanged = True
                Repaint()
                Try
                    RaiseEvent IDChanged(Me)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
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
    ''' Set mouse cursor for control
    ''' </summary>
    Private Sub SetControlCursor()
        If Me.Enabled AndAlso Me.Status <> ConstEnum.enumWaferStatus.eWaferNone Then
            Me.Cursor = Cursors.Hand
        Else
            Me.Cursor = Cursors.Default
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-22 </date>
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
    '''     <date> 2015-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Paint wafer image
    ''' </summary>
    Private Sub PaintImage()
        Dim imgWafer As Bitmap = My.Resources.Resources.PVD4Chamber_Wafer_None

        imgCtrl = New Bitmap(imgWafer.Width, imgWafer.Height)
        imgCtrl.SetResolution(imgWafer.HorizontalResolution, imgWafer.VerticalResolution)

        Using gr As Graphics = Graphics.FromImage(imgCtrl)
            ' Draw wafer image
            Select Case m_status
                Case ConstEnum.enumWaferStatus.eWaferNew
                    imgWafer = My.Resources.Resources.PVD4Chamber_Wafer_Unprocess
                Case ConstEnum.enumWaferStatus.eWaferExposed
                    imgWafer = My.Resources.Resources.PVD4Chamber_Wafer_Partial
                Case ConstEnum.enumWaferStatus.eWaferComplete
                    imgWafer = My.Resources.Resources.PVD4Chamber_Wafer_Complete
                Case ConstEnum.enumWaferStatus.eWaferError
                    imgWafer = My.Resources.Resources.PVD4Chamber_Wafer_Error
            End Select

            gr.DrawImage(imgWafer, 0, 0, imgWafer.Width, imgWafer.Height)

            If m_status <> ConstEnum.enumWaferStatus.eWaferNone AndAlso Not String.IsNullOrEmpty(m_waferID) Then
                Dim idFont As Font = New Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Point)
                Dim idColor As SolidBrush = New SolidBrush(Color.White)

                If m_status = ConstEnum.enumWaferStatus.eWaferExposed OrElse m_status = ConstEnum.enumWaferStatus.eWaferComplete Then
                    idColor = New SolidBrush(Color.Black)
                End If

                Dim centerPoint As PointF = New PointF(imgWafer.Width / 2, imgWafer.Height / 2)
                Dim idSize As SizeF = gr.MeasureString(m_waferID, idFont)
                Dim idLoc As PointF = New PointF(centerPoint.X - idSize.Width / 2, centerPoint.Y - idSize.Height / 2)

                gr.DrawString(m_waferID, idFont, idColor, idLoc.X, idLoc.Y)

                idFont.Dispose()
                idColor.Dispose()
                centerPoint = Nothing
                idSize = Nothing
                idLoc = Nothing
            End If
        End Using

        If m_needCreateRegion Then
            Utils.CreateControlRegion(Me, imgCtrl)
            m_needCreateRegion = False
        Else
            Me.BackgroundImage = imgCtrl
        End If

        imgWafer = Nothing
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Get the image of control
    ''' </summary>
    Public Function GetImage() As Bitmap
        Return imgCtrl
    End Function
#End Region

#Region "Events"

    Private Sub PVD4WaferControl_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
        SetControlCursor()
    End Sub

    Private Sub PVD4WaferControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Repaint()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If imgCtrl IsNot Nothing Then
            Me.Width = imgCtrl.Width
            Me.Height = imgCtrl.Height
        End If
    End Sub


#End Region
End Class
