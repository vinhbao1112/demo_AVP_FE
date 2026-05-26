Imports AVPControls.AVPDataLib

''' <author>Hai Tran</author>
''' <date>2018-03-22</date>
''' <summary>
''' Class for drawing wafer in slot map.
''' </summary>
''' <remarks></remarks>
Public Class SlotMapWaferControl

#Region "Fields"

    Private m_waferStatus As WaferStatuses

#End Region

#Region "Constructors"

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-22</date>
    ''' <summary>
    ''' Class for drawing wafer in slot map.
    ''' </summary>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.RequireInitializeForUpdateView = False

    End Sub

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-22</date>
    ''' <summary>
    ''' Gets or sets wafer status in slot.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WaferStatus() As WaferStatuses
        Get
            Return m_waferStatus
        End Get
        Set(ByVal value As WaferStatuses)
            If m_waferStatus <> value Then
                m_waferStatus = value

                UpdateView()
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Generate control image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Try
            Const BorderWidth As Integer = 3

            Dim waferImage As Bitmap
            Dim waferIDColor As Color

            Select Case m_waferStatus
                Case WaferStatuses.COMPLETE
                    waferImage = My.Resources.Resources.Wafer_Complete
                    waferIDColor = Color.Black
                Case WaferStatuses.ERROR
                    waferImage = My.Resources.Resources.Wafer_Error
                    waferIDColor = Color.White
                Case WaferStatuses.PARTIAL
                    waferImage = My.Resources.Resources.Wafer_Partial
                    waferIDColor = Color.Black
                Case WaferStatuses.UNPROCESS
                    waferImage = My.Resources.Resources.Wafer_Unprocess
                    waferIDColor = Color.White
                Case Else
                    waferImage = My.Resources.Resources.Wafer_BlackGraph
                    waferIDColor = Color.White
            End Select

            Dim img As New Bitmap(Me.Width, Me.Height)

            Using g As Graphics = Graphics.FromImage(img)
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half

                g.DrawImage(waferImage, BorderWidth, BorderWidth, Me.Width - BorderWidth, Me.Width - BorderWidth)

                If Not String.IsNullOrEmpty(Me.Text) Then
                    Dim textFont As Font = New Font("Arial", 20, FontStyle.Bold)
                    Dim textSize As SizeF = g.MeasureString(Me.Text, textFont)
                    Dim textBrush As SolidBrush = New SolidBrush(waferIDColor)

                    g.DrawString(Me.Text, textFont, textBrush, BorderWidth + (Me.Width - textSize.Width) / 2.0F, BorderWidth + (Me.Height - textSize.Height) / 2.0F)

                    textBrush.Dispose()
                    textFont.Dispose()
                End If

                waferImage.Dispose()
            End Using

            Return img
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Update view when size changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SlotMapWaferControl_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        UpdateView()
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Update view when text changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SlotMapWaferControl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        UpdateView()
    End Sub

#End Region

End Class
