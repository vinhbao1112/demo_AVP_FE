Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class AVPPanel
    Inherits Panel

#Region "Fields"
    ' Appearance
    Private m_image As Bitmap
    Private m_transparent As Boolean = True
    Private m_translucent As Boolean
    Private m_enableFormLevelDoubleBuffering As Boolean
    Private m_borderStyle As AVPBorderStyles
#End Region

#Region "Properties"

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-07</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether this control is transparent to parent control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "True"), Category("AVP Appearance"), Description("Gets or sets a value indicating whether this control is transparent to parent control.")> _
    Public Property Transparent() As Boolean
        Get
            Return m_transparent
        End Get
        Set(ByVal value As Boolean)
            If m_transparent <> value Then
                m_transparent = value
                Me.SetStyle(ControlStyles.SupportsTransparentBackColor, m_transparent)
                Me.UpdateStyles()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-07</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether this control is transparent to other control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False"), Category("AVP Appearance"), Description("Gets or sets a value indicating whether this control is transparent to other control.")> _
    Public Property Translucent() As Boolean
        Get
            Return m_translucent
        End Get
        Set(ByVal value As Boolean)
            If m_translucent <> value Then
                m_translucent = value
                Me.DoubleBuffered = Not m_translucent
                Me.UpdateStyles()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-07</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicating whether this control and its childs enable double buffering.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False"), Category("AVP Behavior"), Description("Get or set a value indicating whether this control and its childs enable double buffering.")> _
    Public Property EnableFormLevelDoubleBuffering() As Boolean
        Get
            Return m_enableFormLevelDoubleBuffering
        End Get
        Set(ByVal value As Boolean)
            If m_enableFormLevelDoubleBuffering <> value Then
                m_enableFormLevelDoubleBuffering = value
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-07</date>
    ''' </author>
    ''' <summary>
    ''' Overrides for optionally styles.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams

            ' For double buffering
            If EnableFormLevelDoubleBuffering Then
                Dim OSVer As Version = System.Environment.OSVersion.Version()
                If OSVer.Major > 5 Then
                    cp.ExStyle = cp.ExStyle Or &H2000000
                End If
                OSVer = Nothing
            End If

            ' For transparent
            If m_translucent Then
                cp.ExStyle = cp.ExStyle Or 32
            End If

            Return cp
        End Get
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-07</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates border style of control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(AVPBorderStyles), "None"), Category("AVP Appearance"), Description("Gets or sets a value indicates border style of control.")> _
    Public Property AVPBorderStyle() As AVPBorderStyles
        Get
            Return m_borderStyle
        End Get
        Set(ByVal value As AVPBorderStyles)
            If m_borderStyle <> value Then
                m_borderStyle = value
                Me.Invalidate()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-07</date>
    ''' </author>
    <DefaultValue(GetType(Bitmap), "Nothing")> _
    Public Property [Image]() As Bitmap
        Get
            Return m_image
        End Get
        Set(ByVal value As Bitmap)
            m_image = value
            Me.Invalidate()
        End Set
    End Property

#End Region

#Region "Constructor"
    Public Sub New()
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.Opaque, False)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.DoubleBuffered = True
    End Sub
#End Region

#Region "Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-07</date>
    ''' </author>
    ''' <summary>
    ''' Draw control.
    ''' </summary>
    ''' <param name="g">The Graphics to draw.</param>
    ''' <remarks></remarks>
    Protected Overridable Sub DrawControl(ByVal g As Graphics)
        Try
            ' Draw border.
            If Me.m_borderStyle = AVPBorderStyles.AVP3D Then
                If Me.BackColor = Color.Black Then
                    AVPGraphicsLib.DrawBorder3D(g, 0, 0, Me.Width, Me.Height, Color.White, Me.BackColor)
                Else
                    AVPGraphicsLib.DrawBorder3D(g, 0, 0, Me.Width, Me.Height, Color.Black, Me.BackColor)
                End If
            ElseIf Me.m_borderStyle = AVPBorderStyles.AVP3DDown Then
                If Me.BackColor = Color.Black Then
                    AVPGraphicsLib.DrawBorder3DDown(g, Me.Width, Me.Height, Color.White)
                Else
                    AVPGraphicsLib.DrawBorder3DDown(g, Me.Width, Me.Height, Color.Black)
                End If
            End If

            ' Draw image.
            If m_image IsNot Nothing Then
                g.DrawImageUnscaled(m_image, 0, 0)
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-07</date>
    ''' </author>
    ''' <summary>
    ''' Draw control with options.
    ''' </summary>
    ''' <param name="g">The Graphics to draw.</param>
    ''' <remarks></remarks>
    Private Sub DoPaint(ByVal g As Graphics)
        Try
            DrawControl(g)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        DoPaint(e.Graphics)
    End Sub
#End Region

End Class
