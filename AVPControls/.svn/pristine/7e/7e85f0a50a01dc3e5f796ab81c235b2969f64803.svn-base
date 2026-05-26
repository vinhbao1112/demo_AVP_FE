Imports System.ComponentModel
Imports System.Collections

Public Class AVPButton
    Protected m_pressedImage As Bitmap
    Protected m_normalImage As Bitmap
    Protected m_pressedBackground As Bitmap
    Protected m_normalBackground As Bitmap
    Protected m_clickable As Boolean = True
    Protected m_selectable As Boolean
    Protected m_isSelected As Boolean
    Protected m_isPressed As Boolean
    Protected m_flatFocusStyleEnabled As Boolean


#Region "Properties"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-25 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set a image of the button when press down
    ''' </summary>
    <DefaultValue(GetType(Bitmap), "Nothing")> _
    Public Property PressedImage() As Bitmap
        Get
            Return m_pressedImage
        End Get
        Set(ByVal value As Bitmap)
            m_pressedImage = value
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-05-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set a image of the button when press release
    ''' </summary>
    <DefaultValue(GetType(Bitmap), "Nothing")> _
    Public Property NormalImage() As Bitmap
        Get
            Return m_normalImage
        End Get
        Set(ByVal value As Bitmap)
            m_normalImage = value
            If Not m_isPressed Then
                Me.Image = m_normalImage
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-27 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set a background image of the button when press down
    ''' </summary>
    <DefaultValue(GetType(Bitmap), "Nothing")> _
    Public Property PressedBackground() As Bitmap
        Get
            Return m_pressedBackground
        End Get
        Set(ByVal value As Bitmap)
            m_pressedBackground = value
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-05-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set a background image of the button when press release
    ''' </summary>
    <DefaultValue(GetType(Bitmap), "Nothing")> _
    Public Property NormalBackground() As Bitmap
        Get
            Return m_normalBackground
        End Get
        Set(ByVal value As Bitmap)
            m_normalBackground = value
            If Not m_isPressed Then
                Me.BackgroundImage = m_normalBackground
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-27 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicating whether the button is clickable
    ''' </summary>
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property Clickable() As Boolean
        Get
            Return m_clickable
        End Get
        Set(ByVal value As Boolean)
            m_clickable = value
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-27 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicating whether the button is selected
    ''' </summary>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property Selectable() As Boolean
        Get
            Return m_selectable
        End Get
        Set(ByVal value As Boolean)
            m_selectable = value
            If m_selectable Then
                SetPressedStateImage(m_isSelected)
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-27 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicating whether the button is selectable
    ''' </summary>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsSelected() As Boolean
        Get
            Return m_isSelected
        End Get
        Set(ByVal value As Boolean)
            If m_isSelected <> value Then
                m_isSelected = value
                If m_selectable Then
                    SetPressedStateImage(m_isSelected)
                End If
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Duc Pham </name>
    '''     <date> 2018-7-17 </date>
    ''' </author>
    ''' <summary>
    ''' Enabled Flat Focus Style
    ''' </summary>
    <DefaultValue(False)> _
    Public Property FlatFocusStyleEnabled() As Boolean
        Get
            Return m_flatFocusStyleEnabled
        End Get
        Set(ByVal value As Boolean)
            If m_flatFocusStyleEnabled <> value Then
                m_flatFocusStyleEnabled = value
            End If
        End Set
    End Property
#End Region

#Region "Events"

    ''' <author>
    '''     <name> Duc Pham </name>
    '''     <date> 2018-7-17 </date>
    ''' </author>
    ''' <summary>
    ''' Got Forcus for AppButton
    ''' </summary>
    Private Sub AVPButton_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Try
            If Me.FlatStyle = Windows.Forms.FlatStyle.Flat AndAlso FlatFocusStyleEnabled Then
                Me.FlatAppearance.BorderColor = Color.Green
                Me.FlatAppearance.BorderSize = 1
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub AVPButton_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Try
            If m_isPressed AndAlso (Not m_selectable OrElse (m_selectable AndAlso Not m_isSelected)) Then
                m_isPressed = False
                SetPressedStateImage(m_isPressed)
            End If

            If Me.FlatStyle = Windows.Forms.FlatStyle.Flat AndAlso FlatFocusStyleEnabled Then
                Me.FlatAppearance.BorderColor = Color.Empty
                Me.FlatAppearance.BorderSize = 0
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-25 </date>
    ''' </author>
    ''' <summary>
    ''' Replace image when mouse down
    ''' </summary>
    Protected Sub AVPButton_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If m_clickable Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                SetPressedStateImage(True)
                m_isPressed = True
            End If
        End If

    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-25 </date>
    ''' </author>
    ''' <summary>
    ''' Replace image when mouse up
    ''' </summary>
    Protected Sub AVPButton_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If m_clickable AndAlso (Not m_selectable OrElse (m_selectable AndAlso Not m_isSelected)) Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                SetPressedStateImage(False)
                m_isPressed = False
            End If
        End If
    End Sub


#End Region

#Region "Methods"

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-25 </date>
    ''' </author>
    ''' <summary>
    ''' Change image of the button base on press state
    ''' </summary>
    Private Sub SetPressedStateImage(ByVal isPressed As Boolean)
        If isPressed Then
            If m_pressedImage IsNot Nothing Then
                Me.Image = m_pressedImage
            End If

            If m_pressedBackground IsNot Nothing Then
                Me.BackgroundImage = m_pressedBackground
            End If
        Else
            If m_normalImage IsNot Nothing Then
                Me.Image = m_normalImage
            End If

            If m_normalBackground IsNot Nothing Then
                Me.BackgroundImage = m_normalBackground
            End If
        End If
    End Sub
#End Region


End Class