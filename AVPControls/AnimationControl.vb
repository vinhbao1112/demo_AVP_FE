Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class AnimationControl
    Inherits AVPAnimationControlBase

#Region "Fields"
    Private Const MAX_IMAGE_COUNT As Integer = 3
    Private Const OffImageIndexName As String = "0"
    Private Const OnImage0IndexName As String = "1"
    Private Const OnImage1IndexName As String = "2"

    Protected m_currentImageIndex As Integer
#End Region

#Region "Properties"
    ''' <summary>
    ''' Shadows property for optional transparent on design.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Property IsTransparent() As Boolean
        Get
            Return MyBase.IsTransparent
        End Get
        Set(ByVal value As Boolean)
            MyBase.IsTransparent = value
            Me.DoubleBuffered = Not MyBase.IsTransparent
        End Set
    End Property

    <DefaultValue(GetType(Bitmap), "Nothing")> _
    Public Property OffImage() As Bitmap
        Get
            Return GetCachingImage(OffImageIndexName)
        End Get
        Set(ByVal value As Bitmap)
            Try
                If value IsNot Nothing Then
                    Dim newImage As Bitmap = Nothing

                    If Me.DesignMode Then
                        newImage = value
                    Else
                        newImage = New Bitmap(value)
                    End If

                    AddCachingImage(OffImageIndexName, newImage, False)

                    If value IsNot Nothing Then
                        Me.Size = New Size(value.Width, value.Height)
                    End If

                    If m_status = DisplayStatus.Off Then
                        m_currentImageIndex = 0
                        Me.UpdateView()
                    End If
                Else
                    RemoveCachingImage(OffImageIndexName, Not Me.DesignMode)
                End If
            Catch ex As Exception
                Logger.Error(ex.ToString)
            End Try
        End Set
    End Property

    <DefaultValue(GetType(Bitmap), "Nothing")> _
    Public Property OnImage0() As Bitmap
        Get
            Return GetCachingImage(OnImage0IndexName)
        End Get
        Set(ByVal value As Bitmap)
            Try
                If value IsNot Nothing Then
                    Dim newImage As Bitmap = Nothing

                    If Me.DesignMode Then
                        newImage = value
                    Else
                        newImage = New Bitmap(value)
                    End If

                    AddCachingImage(OnImage0IndexName, newImage, False)

                    If m_status = DisplayStatus.On Then
                        m_currentImageIndex = 1
                        Me.UpdateView()
                    End If
                Else
                    RemoveCachingImage(OnImage0IndexName, Not Me.DesignMode)
                End If
            Catch ex As Exception
                Logger.Error(ex.ToString)
            End Try
        End Set
    End Property

    <DefaultValue(GetType(Bitmap), "Nothing")> _
    Public Property OnImage1() As Bitmap
        Get
            Return GetCachingImage(OnImage1IndexName)
        End Get
        Set(ByVal value As Bitmap)
            Try
                If value IsNot Nothing Then
                    Dim newImage As Bitmap = Nothing

                    If Me.DesignMode Then
                        newImage = value
                    Else
                        newImage = New Bitmap(value)
                    End If

                    AddCachingImage(OnImage1IndexName, newImage, False)

                    If m_status = DisplayStatus.On Then
                        Me.UpdateView()
                    End If
                Else
                    RemoveCachingImage(OnImage1IndexName, Not Me.DesignMode)
                End If
            Catch ex As Exception
                Logger.Error(ex.ToString)
            End Try
        End Set
    End Property
#End Region

#Region "Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-28</date>
    ''' </author>
    ''' <summary>
    ''' Generate image for control
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Return GetCachingImage(m_currentImageIndex.ToString())
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-28</date>
    ''' </author>
    ''' <summary>
    ''' Restart animation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Restart()
        Me.RestartAnimation()
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-07-18</date>
    ''' <summary>
    ''' Changes on images.
    ''' </summary>
    ''' <param name="onImage0"></param>
    ''' <param name="onImage1"></param>
    ''' <param name="shouldCopy"></param>
    ''' <remarks></remarks>
    Public Sub ChangeOnImages(ByVal onImage0 As Bitmap, ByVal onImage1 As Bitmap, Optional ByVal shouldCopy As Boolean = False)
        Try
            If onImage0 IsNot Nothing Then
                AddCachingImage(OnImage0IndexName, onImage0, shouldCopy)
            Else
                RemoveCachingImage(OnImage0IndexName)
            End If

            If onImage1 IsNot Nothing Then
                AddCachingImage(OnImage1IndexName, onImage1, shouldCopy)
            Else
                RemoveCachingImage(OnImage1IndexName)
            End If

            If m_status = DisplayStatus.On Then
                Me.UpdateView()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString)
        End Try
    End Sub

#End Region

#Region "Animation Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-28</date>
    ''' </author>
    ''' <summary>
    ''' Check condition to start animation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function IsStartAnimation() As Boolean
        Return Me.Status = DisplayStatus.On
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-28</date>
    ''' </author>
    ''' <summary>
    ''' Check condition to stop animation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function IsStopAnimation() As Boolean
        Return Me.Status <> DisplayStatus.On
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-28</date>
    ''' </author>
    ''' <summary>
    ''' Change image in list on animation.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub UpdateAnimatingView()
        If Me.Status = DisplayStatus.Off Then
            m_currentImageIndex = 0
        Else
            m_currentImageIndex += 1
            If m_currentImageIndex >= ImageCache.Count Then
                m_currentImageIndex = 1
            End If
        End If
        UpdateView()
    End Sub
#End Region

#Region "Events"
    Public Sub New()
        Me.IsInitialized = True
        Me.KeepControlImage = True
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-28</date>
    ''' </author>
    ''' <summary>
    ''' Reset to first image on stop.
    ''' </summary>
    Private Sub AnimationControl_AnimationStoped(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AnimationStoped
        Me.m_currentImageIndex = 0
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-28</date>
    ''' </author>
    ''' <summary>
    ''' Start animation on status ON.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AnimationControl_StatusChanged(ByVal sender As Object, ByVal e As StatusChangedEventArgs) Handles Me.StatusChanged
        If Me.Status = DisplayStatus.On Then
            Me.StartAnimation()
        Else
            Me.m_currentImageIndex = 0
            Me.UpdateView()
        End If
    End Sub
#End Region

End Class
