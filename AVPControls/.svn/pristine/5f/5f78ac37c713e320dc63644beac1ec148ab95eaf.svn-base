Imports System.ComponentModel

Public Class StackLightControl
    Inherits AVPControlBase

    Public Enum LightType
        OneLight = 1
        TwoLight = 2
        ThreeLight = 3
        FourLight = 4
    End Enum

#Region "Fields"
    Private m_Type As LightType = LightType.FourLight
    Private m_redLightOn As Boolean
    Private m_greenLightOn As Boolean
    Private m_yellowLightOn As Boolean
    Private m_blueLightOn As Boolean
#End Region

#Region "Properties"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-02</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates number of light of the stacklight.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(LightType), "FourLight"), Description("Gets or sets a value indicates number of light of the stacklight.")> _
    Public Property Type() As LightType
        Get
            Return m_Type
        End Get
        Set(ByVal value As LightType)
            If m_Type <> value Then
                m_Type = value
                Me.UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-02</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether the red light is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False"), Description("Gets or sets a value indicating whether the red light is on.")> _
    Public Property RedLightOn() As Boolean
        Get
            Return m_redLightOn
        End Get
        Set(ByVal value As Boolean)
            If m_redLightOn <> value Then
                m_redLightOn = value
                If m_Type >= LightType.OneLight Then
                    Me.UpdateView()
                End If
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-02</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether the yellow light is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False"), Description("Gets or sets a value indicating whether the yellow light is on.")> _
    Public Property YellowLightOn() As Boolean
        Get
            Return m_yellowLightOn
        End Get
        Set(ByVal value As Boolean)
            If m_yellowLightOn <> value Then
                m_yellowLightOn = value
                If m_Type >= LightType.ThreeLight Then
                    Me.UpdateView()
                End If
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-02</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether the green light is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False"), Description("Gets or sets a value indicating whether the green light is on.")> _
    Public Property GreenLightOn() As Boolean
        Get
            Return m_greenLightOn
        End Get
        Set(ByVal value As Boolean)
            If m_greenLightOn <> value Then
                m_greenLightOn = value
                If m_Type >= LightType.TwoLight Then
                    Me.UpdateView()
                End If
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-02</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether the blue light is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False"), Description("Gets or sets a value indicating whether the blue light is on.")> _
    Public Property BlueLightOn() As Boolean
        Get
            Return m_blueLightOn
        End Get
        Set(ByVal value As Boolean)
            If m_blueLightOn <> value Then
                m_blueLightOn = value
                If m_Type >= LightType.FourLight Then
                    Me.UpdateView()
                End If
            End If
        End Set
    End Property
#End Region

#Region "Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-02</date>
    ''' </author>
    ''' <summary>
    ''' Generate stack light image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Try
            Dim img As Bitmap = My.Resources.Resources.StackLight_Background
            Using g As Graphics = Graphics.FromImage(img)
                Dim lightImage As Bitmap

                ' Draw Red light.
                If m_Type >= LightType.OneLight Then
                    If m_redLightOn Then
                        lightImage = My.Resources.Resources.StackLight_Red_On
                    Else
                        lightImage = My.Resources.Resources.StackLight_Red_Off
                    End If

                    g.DrawImageUnscaled(lightImage, 0, 0)
                    lightImage.Dispose()
                End If

                ' Draw Yellow light.
                If m_Type >= LightType.ThreeLight Then
                    If m_yellowLightOn Then
                        lightImage = My.Resources.Resources.StackLight_Yellow_On
                    Else
                        lightImage = My.Resources.Resources.StackLight_Yellow_Off
                    End If

                    g.DrawImageUnscaled(lightImage, 0, 0)
                    lightImage.Dispose()
                End If

                ' Draw Green light.
                If m_Type >= LightType.TwoLight Then
                    If m_greenLightOn Then
                        lightImage = My.Resources.Resources.StackLight_Green_On
                    Else
                        lightImage = My.Resources.Resources.StackLight_Green_Off
                    End If

                    g.DrawImageUnscaled(lightImage, 0, 0)
                    lightImage.Dispose()
                End If

                ' Draw Blue light.
                If m_Type >= LightType.FourLight Then
                    If m_blueLightOn Then
                        lightImage = My.Resources.Resources.StackLight_Blue_On
                    Else
                        lightImage = My.Resources.Resources.StackLight_Blue_Off
                    End If

                    g.DrawImageUnscaled(lightImage, 0, 0)
                    lightImage.Dispose()
                End If

                lightImage = Nothing
                g.Dispose()
            End Using

            Return img
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
#End Region

#Region "Events"
    Public Sub New()
        Me.IsTransparent = True
        Me.DoubleBuffered = False
        Me.AlphaValueForRegion = 0
        Me.IsInitialized = True
        Me.ResumeUpdateView()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-15</date>
    ''' </author>
    ''' <summary>
    ''' Don't paint background.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Do nothing
    End Sub
#End Region

End Class
