Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class AVPWaferControl
    Private m_waferStatus As WaferStatuses
    Private m_waferID As String = ""
    Private m_showQuestionMark As Boolean
    Private m_showBorder As Boolean
    Private m_positionID As Integer
    Private m_PMSlotNumber As Integer = 1

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-22</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when the status of wafer is changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event WaferStatusChanged As EventHandler

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-22</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when the id of wafer is changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event WaferIDChanged As EventHandler

#Region "Properties"
    <DefaultValue(1)> _
    Public Property PMSlotNumber() As Integer
        Get
            Return m_PMSlotNumber
        End Get
        Set(ByVal value As Integer)
            m_PMSlotNumber = value
        End Set
    End Property

    <DefaultValue(0)> _
    Public Property PositionID() As Integer
        Get
            Return m_positionID
        End Get
        Set(ByVal value As Integer)
            m_positionID = value
        End Set
    End Property

    <DefaultValue(GetType(WaferStatuses), "NONE")> _
    Public Property WaferStatus() As WaferStatuses
        Get
            Return m_waferStatus
        End Get
        Set(ByVal value As WaferStatuses)
            If m_waferStatus <> value Then
                m_waferStatus = value
                OnWaferStatusChanged(EventArgs.Empty)
                UpdateView()
                If Not Me.HasSuspendUpdate AndAlso Me.m_waferStatus = WaferStatuses.NONE Then
                    Me.Invalidate()
                End If
            End If
        End Set
    End Property

    <DefaultValue(GetType(String), "")> _
    Public Property WaferID() As String
        Get
            Return m_waferID
        End Get
        Set(ByVal value As String)
            If m_waferID <> value Then
                m_waferID = value
                OnWaferIDChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

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

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsShowBorder() As Boolean
        Get
            Return m_showBorder
        End Get
        Set(ByVal value As Boolean)
            If m_showBorder <> value Then
                m_showBorder = value
                If Not Me.HasSuspendUpdate Then
                    Me.Invalidate()
                End If
            End If
        End Set
    End Property
#End Region

#Region "Methods"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Draw wafer image
    ''' </summary>
    Protected Overrides Function GenerateControlImage() As Bitmap
        Select Case m_chamberType
            Case AVPChamberTypes.PVD2R4
                Return GeneratePVD2R4WaferImage()
            Case AVPChamberTypes.PVD
                Return GeneratePVDWaferImage()
            Case AVPChamberTypes.PVD_A
                Return GeneratePVDAWaferImage()
            Case AVPChamberTypes.PVDA_SA
                Return GeneratePVDAStandaloneWaferImage()
            Case AVPChamberTypes.RIE
                Return GenerateRIEWaferImage()
        End Select
        Return AVPWaferControl.GenerateWaferImage(m_waferStatus, m_waferID, m_showQuestionMark, 0, AVPStyle, m_chamberType)
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
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
            Else
                ' Force set ShowQuestionMark to False when wafer none.
                isShowQuestionMark = False
            End If

            SetWaferInfo(waferStatus, waferID, isShowQuestionMark)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-30 </date>
    ''' </author>
    ''' <summary>
    ''' Set wafer info to control
    ''' </summary>
    Public Overloads Sub SetWaferInfo(ByVal waferInfo As WaferInfo)
        Try
            Dim waferStatus As WaferStatuses = WaferStatuses.NONE
            Dim waferID As String = ""
            Dim isShowQuestionMark As Boolean = Me.m_showQuestionMark

            If Not AVPControls.AVPDataLib.WaferInfo.IsEmpty(waferInfo) Then
                waferStatus = waferInfo.WaferStatus
                waferID = waferInfo.WaferID
            Else
                ' Set ShowQuestionMark to False when wafer none.
                isShowQuestionMark = False
            End If

            SetWaferInfo(waferStatus, waferID, isShowQuestionMark)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Set wafer info to control
    ''' </summary>
    Public Overloads Sub SetWaferInfo(ByVal waferStatus As WaferStatuses, ByVal waferID As String, ByVal isShowQuestionMark As Boolean)
        Try
            Dim statusChanged As Boolean
            Dim idChanged As Boolean

            If m_waferStatus <> waferStatus Then
                m_waferStatus = waferStatus
                statusChanged = True
            End If

            If m_waferID <> waferID Then
                m_waferID = waferID
                idChanged = True
            End If

            If m_showQuestionMark <> isShowQuestionMark Then
                m_showQuestionMark = isShowQuestionMark
                statusChanged = True
            End If

            If statusChanged OrElse idChanged Then
                UpdateView()
            End If

            If statusChanged Then
                OnWaferStatusChanged(EventArgs.Empty)
            End If

            If idChanged Then
                OnWaferIDChanged(EventArgs.Empty)
            End If

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-30 </date>
    ''' </author>
    ''' <summary>
    ''' Set wafer info to control
    ''' </summary>
    Public Overloads Sub SetWaferInfo(ByVal waferStatus As WaferStatuses, ByVal waferID As String)
        Try
            Dim statusChanged As Boolean
            Dim idChanged As Boolean

            If m_waferStatus <> waferStatus Then
                m_waferStatus = waferStatus
                statusChanged = True
            End If

            If m_waferID <> waferID Then
                m_waferID = waferID
                idChanged = True
            End If

            If statusChanged OrElse idChanged Then
                UpdateView()
            End If

            If statusChanged Then
                OnWaferStatusChanged(EventArgs.Empty)
            End If

            If idChanged Then
                OnWaferIDChanged(EventArgs.Empty)
            End If

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Generate image of wafer control
    ''' </summary>
    Public Overloads Shared Function GenerateWaferImage(ByVal waferStatus As WaferStatuses, ByVal waferID As String, ByVal isShowQuestionMark As Boolean, ByVal rotateAngle As Single, ByVal waferDiameter As Integer) As Bitmap
       Dim img As Bitmap = Nothing

        Try
            Dim imgWafer As Bitmap
            Dim brushColor As Brush = Brushes.White
            Dim qmImg As Bitmap = Nothing

            ' Get the wafer image base on status
            Select Case waferStatus
                Case WaferStatuses.UNPROCESS
                    imgWafer = My.Resources.Resources.Wafer_Unprocess
                    qmImg = My.Resources.Resources.QuestionMark_Red

                Case WaferStatuses.PARTIAL
                    imgWafer = My.Resources.Resources.Wafer_Partial
                    brushColor = Brushes.Black
                    qmImg = My.Resources.Resources.QuestionMark_Red

                Case WaferStatuses.ERROR
                    imgWafer = My.Resources.Resources.Wafer_Error
                    qmImg = My.Resources.Resources.QuestionMark_White

                Case WaferStatuses.COMPLETE
                    imgWafer = My.Resources.Resources.Wafer_Complete
                    brushColor = Brushes.Black
                    qmImg = My.Resources.Resources.QuestionMark_Red

                Case Else
                    imgWafer = My.Resources.Resources.Wafer_None

            End Select

            If waferStatus = WaferStatuses.NONE Then
                img = New Bitmap(imgWafer, waferDiameter, waferDiameter)
                imgWafer.Dispose()
                Return img
            End If

            Dim waferFontSize As Single = CSng(Math.Ceiling(waferDiameter / 4.0F))

            ' Create new bitmap
            img = New Bitmap(waferDiameter, waferDiameter)
            img.SetResolution(imgWafer.HorizontalResolution, imgWafer.VerticalResolution)

            Dim g As Graphics = Graphics.FromImage(img)
            ' Draw image
            g.DrawImage(imgWafer, 0, 0, waferDiameter, waferDiameter)

            ' Draw text
            If Not String.IsNullOrEmpty(waferID) Then
                Dim rotateMatrix As New Drawing2D.Matrix()
                rotateMatrix.RotateAt(rotateAngle, New PointF(waferDiameter / 2.0F, waferDiameter / 2.0F))
                Dim fontid As Font = New Font(WAFERID_FONT_NAME, waferFontSize, WAFERID_FONT_STYLE)
                Dim size As SizeF = g.MeasureString(waferID, fontid)
                Dim pos As PointF = New PointF((waferDiameter - size.Width) / 2, (waferDiameter - size.Height) / 2)

                '' Rotate wafer ID
                If rotateAngle <> 0 Then
                    g.Transform = rotateMatrix
                End If

                If Not isShowQuestionMark Then
                    g.DrawString(waferID, fontid, brushColor, pos.X, pos.Y)
                Else
                    g.DrawString(waferID, fontid, brushColor, pos.X, pos.Y + 2)
                End If

                '' Reset rotate transform
                If rotateAngle <> 0 Then
                    g.ResetTransform()
                End If

                fontid.Dispose()
                pos = Nothing
                size = Nothing
                rotateMatrix.Dispose()
            End If

            ' Draw question mark
            If isShowQuestionMark Then
                g.DrawImage(qmImg, 0, 0, waferDiameter, waferDiameter)
            End If

            ' Release resources
            imgWafer.Dispose()
            qmImg.Dispose()
            g.Dispose()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        Return img
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2016-04-06 </date>
    ''' </author>
    ''' <summary>
    ''' Generate image of wafer control
    ''' </summary>
    Public Overloads Shared Function GenerateWaferImage( _
        ByVal waferStatus As WaferStatuses, _
        ByVal waferID As String, _
        Optional ByVal isShowQuestionMark As Boolean = False, _
        Optional ByVal rotateAngle As Single = 0, _
        Optional ByVal avpStyle As AVPStyles = AVPStyles.CX8, _
        Optional ByVal chamberType As AVPChamberTypes = AVPChamberTypes.Undefined _
    ) As Bitmap
        ' Get wafer size for each AVPStyle
        Dim waferDiameter As Integer = WAFER_DIAMETER(avpStyle, chamberType)
        Return GenerateWaferImage(waferStatus, waferID, isShowQuestionMark, rotateAngle, waferDiameter)
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-05 </date>
    ''' </author>
    ''' <summary>
    ''' Generate image of wafer control
    ''' </summary>
    Public Overloads Shared Function GenerateWaferImage(ByVal waferStatus As WaferStatuses, ByVal waferID As String, ByVal avpStyle As AVPStyles) As Bitmap
        Return AVPWaferControl.GenerateWaferImage(waferStatus, waferID, False, 0, avpStyle)
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2016-04-06 </date>
    ''' </author>
    ''' <summary>
    ''' Generate image of wafer control
    ''' </summary>
    Public Overloads Shared Function GenerateWaferImage(ByVal waferStatus As WaferStatuses, ByVal waferID As String, ByVal waferDiameter As Integer) As Bitmap
        Return AVPWaferControl.GenerateWaferImage(waferStatus, waferID, False, 0, waferDiameter)
    End Function

    Public Overloads Shared Function GenerateWaferImage(ByVal waferStatus As WaferStatuses, ByVal waferID As String, ByVal avpStyle As AVPStyles, ByVal showQuestionMark As Boolean) As Bitmap
        Return AVPWaferControl.GenerateWaferImage(waferStatus, waferID, showQuestionMark, 0, avpStyle)
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2016-04-06 </date>
    ''' </author>
    ''' <summary>
    ''' Generate image of wafer control
    ''' </summary>
    ''' <param name="waferStatus"></param>
    ''' <param name="waferID"></param>
    ''' <param name="waferDiameter"></param>
    ''' <param name="showQuestionMark"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GenerateWaferImage(ByVal waferStatus As WaferStatuses, ByVal waferID As String, ByVal waferDiameter As Integer, ByVal showQuestionMark As Boolean) As Bitmap
        Return AVPWaferControl.GenerateWaferImage(waferStatus, waferID, showQuestionMark, 0, waferDiameter)
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2016-01-22 </date>
    ''' </author>
    ''' <summary>
    ''' Generate image of wafer control for PVD2R4 chamber.
    ''' </summary>
    Private Function GeneratePVD2R4WaferImage() As Bitmap
        Try
            Dim imgWafer As Bitmap = Nothing
            Select Case m_waferStatus
                Case WaferStatuses.UNPROCESS
                    imgWafer = My.Resources.Resources.PVD2R4_Wafer_Unprocess
                Case WaferStatuses.PARTIAL
                    imgWafer = My.Resources.Resources.PVD2R4_Wafer_Partial
                Case WaferStatuses.ERROR
                    imgWafer = My.Resources.Resources.PVD2R4_Wafer_Error
                Case WaferStatuses.COMPLETE
                    imgWafer = My.Resources.Resources.PVD2R4_Wafer_Complete
            End Select

            ' Draw wafer ID
            If imgWafer IsNot Nothing AndAlso Not String.IsNullOrEmpty(m_waferID) Then
                Using g As Graphics = Graphics.FromImage(imgWafer)
                    Dim fontid As Font = New Font(WAFERID_FONT_NAME, 10, WAFERID_FONT_STYLE)
                    Dim size As SizeF = g.MeasureString(m_waferID, fontid)
                    Dim idBrush As New SolidBrush(AVPControls.AVPDataLib.GetTextColor(AVPControls.AVPDataLib.ParseDisplayStatus(m_waferStatus.ToString)))

                    g.DrawString(m_waferID, fontid, idBrush, (imgWafer.Width - size.Width) / 2.0F, (imgWafer.Height - size.Height) / 2.0F)

                    fontid.Dispose()
                    idBrush.Dispose()
                    g.Dispose()
                End Using
            End If

            Return imgWafer
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2016-06-27 </date>
    ''' </author>
    ''' <summary>
    ''' Generate image of wafer control for PVD chamber.
    ''' </summary>
    Private Function GeneratePVDWaferImage() As Bitmap
        Dim imgWafer As Bitmap = Nothing
        Try
            Select Case WaferStatus
                Case WaferStatuses.UNPROCESS
                    imgWafer = My.Resources.PVD_Wafer_Unprocess
                Case WaferStatuses.PARTIAL
                    imgWafer = My.Resources.PVD_Wafer_Partial
                Case WaferStatuses.ERROR
                    imgWafer = My.Resources.PVD_Wafer_Error
                Case WaferStatuses.COMPLETE
                    imgWafer = My.Resources.PVD_Wafer_Complete
            End Select

            ' Draw wafer ID.
            If imgWafer IsNot Nothing AndAlso Not String.IsNullOrEmpty(WaferID) Then
                Using g As Graphics = Graphics.FromImage(imgWafer)
                    Dim f As New Font(WAFERID_FONT_NAME, 10, WAFERID_FONT_STYLE, GraphicsUnit.Point)
                    Dim sizeText As SizeF = g.MeasureString(WaferID, f)
                    Dim x As Integer = CInt((imgWafer.Width - sizeText.Width) / 2.0F)
                    Dim y As Integer = CInt((imgWafer.Height - sizeText.Height) / 2.0F)
                    Dim brush As SolidBrush = New SolidBrush(AVPControls.AVPDataLib.GetTextColor(WaferStatus))
                    g.DrawString(WaferID, f, brush, x, y)

                    brush.Dispose()
                    f.Dispose()
                End Using
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return imgWafer
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2016-06-27 </date>
    ''' </author>
    ''' <summary>
    ''' Generate image of wafer control for PVD chamber.
    ''' </summary>
    Private Function GeneratePVDAWaferImage() As Bitmap
        Dim imgWafer As Bitmap = Nothing
        Try
            Select Case WaferStatus
                Case WaferStatuses.UNPROCESS
                    imgWafer = My.Resources.PVDA_Wafer_Unprocess
                Case WaferStatuses.PARTIAL
                    imgWafer = My.Resources.PVDA_Wafer_Partial
                Case WaferStatuses.ERROR
                    imgWafer = My.Resources.PVDA_Wafer_Error
                Case WaferStatuses.COMPLETE
                    imgWafer = My.Resources.PVDA_Wafer_Complete
            End Select

            ' Draw wafer ID.
            If imgWafer IsNot Nothing AndAlso Not String.IsNullOrEmpty(WaferID) Then
                Using g As Graphics = Graphics.FromImage(imgWafer)
                    Dim f As New Font(WAFERID_FONT_NAME, 10, WAFERID_FONT_STYLE, GraphicsUnit.Point)
                    Dim sizeText As SizeF = g.MeasureString(WaferID, f)
                    Dim x As Integer = CInt((imgWafer.Width - sizeText.Width) / 2.0F)
                    Dim y As Integer = CInt((imgWafer.Height - sizeText.Height) / 2.0F)
                    Dim brush As SolidBrush = New SolidBrush(AVPControls.AVPDataLib.GetTextColor(WaferStatus))
                    g.DrawString(WaferID, f, brush, x, y)

                    brush.Dispose()
                    f.Dispose()
                End Using
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return imgWafer
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-07</date>
    ''' <summary>
    ''' Generate image of wafer control for PVDA Standalone chamber.
    ''' </summary>
    Private Function GeneratePVDAStandaloneWaferImage() As Bitmap
        Dim imgWafer As Bitmap = Nothing
        Try
            Select Case WaferStatus
                Case WaferStatuses.PARTIAL
                    imgWafer = My.Resources.PVDA_SA_WaferPartial
                Case WaferStatuses.ERROR
                    imgWafer = My.Resources.PVDA_SA_WaferError
                Case WaferStatuses.COMPLETE
                    imgWafer = My.Resources.PVDA_SA_WaferCompleted
                Case WaferStatuses.UNPROCESS
                    imgWafer = My.Resources.PVDA_SA_WaferUnprocess
                Case Else
                    imgWafer = My.Resources.PVDA_SA_WaferNone
            End Select

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return imgWafer
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-12</date>
    ''' <summary>
    ''' Generate image of wafer control for RIE chamber.
    ''' </summary>
    Private Function GenerateRIEWaferImage() As Bitmap
        Dim imgWafer As Bitmap = Nothing
        Try
            Select Case WaferStatus
                Case WaferStatuses.PARTIAL
                    imgWafer = My.Resources.RIE_Wafer_Partial
                Case WaferStatuses.ERROR
                    imgWafer = My.Resources.RIE_Wafer_Error
                Case WaferStatuses.COMPLETE
                    imgWafer = My.Resources.RIE_Wafer_Completed
                Case Else
                    imgWafer = My.Resources.RIE_Wafer_Unprocessed
            End Select

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return imgWafer
    End Function

#End Region

#Region "Events"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_allowEmptyRegion = False

        ' Set region of control when wafer status is NONE.
        Me.PatternBitmap = AVPWaferControl.GenerateWaferImage(WaferStatuses.COMPLETE, String.Empty, False, 0, Me.AVPStyle)

        Me.IsTransparent = True
        Me.DoubleBuffered = False
        Me.IsInitialized = True
        Me.ResumeUpdateView()

    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Paint border when wafer status none
    ''' </summary>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If m_showBorder AndAlso m_waferStatus = WaferStatuses.NONE Then
            e.Graphics.DrawEllipse(Pens.Black, 1, 1, WAFER_DIAMETER(AVPStyle, ChamberType) - 3, WAFER_DIAMETER(AVPStyle, ChamberType) - 3)
        Else
            If m_waferStatus <> WaferStatuses.NONE OrElse AVPStyle = AVPStyles.StandAlone Then
                MyBase.OnPaint(e)
            End If
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-20</date>
    ''' </author>
    ''' <summary>
    ''' Change default region of control.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPWaferControl_AVPStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AVPStyleChanged
        Try
            Dim tmpImg As Bitmap = Me.PatternBitmap
            If AVPStyle <> AVPStyles.StandAlone Then
                Me.PatternBitmap = AVPWaferControl.GenerateWaferImage(WaferStatuses.COMPLETE, String.Empty, False, 0, Me.AVPStyle)
            Else
                Me.PatternBitmap = Nothing
            End If
            If (tmpImg IsNot Nothing) Then
                tmpImg.Dispose()
                tmpImg = Nothing
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-05</date>
    ''' </author>
    ''' <summary>
    ''' Change style of control.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPWaferControl_ChamberTypeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ChamberTypeChanged
        If Me.ChamberType = AVPChamberTypes.PVD2R4 Then
            Me.IsTransparent = False
            Me.DoubleBuffered = True
        Else
            Me.IsTransparent = True
            Me.DoubleBuffered = False
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-22</date>
    ''' </author>
    ''' <summary>
    ''' Raise the event WaferStatusChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnWaferStatusChanged(ByVal e As EventArgs)
        RaiseEvent WaferStatusChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-22</date>
    ''' </author>
    ''' <summary>
    ''' Raise the event WaferIDChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnWaferIDChanged(ByVal e As EventArgs)
        RaiseEvent WaferIDChanged(Me, e)
    End Sub
#End Region

End Class
