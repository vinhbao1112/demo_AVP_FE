Imports System.ComponentModel

''' <author>
'''     <name>Hai Tran</name>
'''     <date>2015-10-01</date>
''' </author>
''' <summary>
''' Application panel.
''' </summary>
''' <remarks></remarks>
Public Class AppPanel

    Public Enum PanelBackgroundSizes
        Size1
        Size2
        Size3
        Size4
    End Enum

    Private m_image As Bitmap = My.Resources.Resources.BgAppPanel
    Private m_backgroundSize As PanelBackgroundSizes = PanelBackgroundSizes.Size1

    Private Property [Image]() As Bitmap
        Get
            Return m_image
        End Get
        Set(ByVal value As Bitmap)
            Dim preImage As Bitmap = m_image

            m_image = value

            If preImage IsNot Nothing Then
                preImage.Dispose()
                preImage = Nothing
            End If

            Me.Invalidate()
        End Set
    End Property

#Region "Design Properties"
    Protected Overrides ReadOnly Property DefaultCursor() As System.Windows.Forms.Cursor
        Get
            Return Cursors.Default
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(207, 76)
        End Get
    End Property

    ''' <summary>
    ''' Overrides for set childs cursor as this cursor.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property Cursor() As System.Windows.Forms.Cursor
        Get
            Return MyBase.Cursor
        End Get
        Set(ByVal value As System.Windows.Forms.Cursor)
            MyBase.Cursor = value
            If Me.HasChildren Then
                For Each ctrl As Control In Me.Controls
                    ctrl.Cursor = MyBase.Cursor
                Next
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-05-25</date>
    ''' <summary>
    ''' Gets or sets size of panel.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(PanelBackgroundSizes), "Size1")> _
    Public Property BackgroundSize() As PanelBackgroundSizes
        Get
            Return m_backgroundSize
        End Get
        Set(ByVal value As PanelBackgroundSizes)
            If m_backgroundSize <> value Then
                m_backgroundSize = value

                Image = GetImageForSize(value)

                If Image IsNot Nothing Then
                    Me.Size = New Size(Image.Width, Image.Height)
                End If

                OnBackgroundSizeChanged()
            End If
        End Set
    End Property

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.Opaque, False)
        Me.DoubleBuffered = True
        Me.UpdateStyles()
        Me.BackColor = Color.Transparent


    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-02</date>
    ''' </author>
    ''' <summary>
    ''' Click event for child controls.
    ''' </summary>
    Private Sub AppPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.OnClick(e)
    End Sub

    Private Sub AppPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddChildHandler()
    End Sub

    Private Sub AppPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If m_image IsNot Nothing Then
            e.Graphics.DrawImage(m_image, 0, 0, m_image.Width, m_image.Height)
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-02</date>
    ''' </author>
    ''' <summary>
    ''' Apply click event to all child controls.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddChildHandler()
        If Me.HasChildren Then
            For Each ctrl As Control In Me.Controls
                AddHandler ctrl.Click, AddressOf AppPanel_Click
            Next
        End If
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-05-25</date>
    ''' <summary>
    ''' Returns image of background size.
    ''' </summary>
    ''' <param name="size"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetImageForSize(ByVal size As PanelBackgroundSizes) As Bitmap
        Select Case size
            Case PanelBackgroundSizes.Size1
                Return My.Resources.Resources.BgAppPanel
            Case PanelBackgroundSizes.Size2
                Return My.Resources.Resources.BgAppPanelLittleLarge
            Case PanelBackgroundSizes.Size3
                Return My.Resources.Resources.BgAppPanelLarge
            Case PanelBackgroundSizes.Size4
                Return My.Resources.Resources.BgAppPanelExtraLarge
        End Select
        Return My.Resources.Resources.BgAppPanel
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2018-05-25</date>
    ''' <summary>
    ''' On background size changed.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub OnBackgroundSizeChanged()

    End Sub


End Class
