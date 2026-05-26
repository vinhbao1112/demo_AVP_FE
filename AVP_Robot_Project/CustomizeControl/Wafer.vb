'Use for Wafer Presentation in Select Wafer Form
Public Class WaferControl
    Private m_WaferImage As Image
    Private m_SlotStatus As AVPLib.ConstEnum.enumWaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
    Private m_WaferIDColor As Color = Color.White
    Public Property SlotStatus() As AVPLib.ConstEnum.enumWaferStatus
        Get
            Return m_SlotStatus
        End Get
        Set(ByVal value As AVPLib.ConstEnum.enumWaferStatus)
            m_SlotStatus = value
            Select Case m_SlotStatus
                Case AVPLib.ConstEnum.enumWaferStatus.eWaferExposed 'Invalid
                    m_WaferImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Partial
                    m_WaferIDColor = Color.Black
                Case AVPLib.ConstEnum.enumWaferStatus.eWaferNone
                    m_WaferImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_BlackGraph
                    m_WaferIDColor = Color.White
                Case AVPLib.ConstEnum.enumWaferStatus.eWaferError
                    m_WaferImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Error
                    m_WaferIDColor = Color.White
                Case AVPLib.ConstEnum.enumWaferStatus.eWaferComplete
                    m_WaferImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Complete
                    m_WaferIDColor = Color.Black
                Case AVPLib.ConstEnum.enumWaferStatus.eWaferNew
                    m_WaferImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Unprocess
                    m_WaferIDColor = Color.White
            End Select
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Try
            Dim graphics As Graphics = e.Graphics
            Dim pen As Pen = New Pen(Color.Black, 1)

            Dim fontHeight As Integer = 20
            Dim font As Font = New Font("Arial", fontHeight, FontStyle.Bold)
            graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
            'Dim brush As SolidBrush = New SolidBrush(WaferColor)
            graphics.DrawImage(m_WaferImage, 0, 0, Me.Width, Me.Height)

            Dim textBrush As SolidBrush = New SolidBrush(m_WaferIDColor)
            'graphics.DrawEllipse(pen, 0, 0, Width, Height)
            If Me.Text.Length > 1 Then
                graphics.DrawString(Me.Text, font, textBrush, CInt(Width / 4) - 3, CInt(Height / 4))
            Else
                graphics.DrawString(Me.Text, font, textBrush, CInt(Width / 4) + 3, CInt(Height / 4))
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Cursor = Cursors.Hand
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
