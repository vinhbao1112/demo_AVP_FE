Imports System.ComponentModel

Public Class MaskControl

#Region "Fields"

    Private _maskImage As Bitmap = Nothing

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-21</date>
    ''' <summary>
    ''' Gets or sets an image to create region mask.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Bitmap), "Nothing"), Category("AVP Layout"), Description("Gets or sets a bitmap defining the control shape.")> _
    Public Property MaskImage() As Bitmap
        Get
            Return _maskImage
        End Get
        Set(ByVal value As Bitmap)
            _maskImage = value
            Try
                If _maskImage IsNot Nothing Then
                    Me.Width = value.Width
                    Me.Height = value.Height
                    Dim re As Region = AVPGraphicsLib.GetRegion(_maskImage)
                    Me.Region = re
                Else
                    Me.Region = Nothing
                End If
            Catch ex As Exception
                Logger.Error(ex.ToString())
            End Try
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.IsTransparent = True
        Me.DoubleBuffered = False
        Me.IsInitialized = True

    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-22</date>
    ''' <summary>
    ''' Overrides for painting.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            If Me.DesignMode Then
                If _maskImage IsNot Nothing Then
                    e.Graphics.DrawImageUnscaled(_maskImage, 0, 0)
                End If
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

#End Region

End Class
