Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class PVD2TChamberControl

#Region "Fields"

    Private m_DepShutterInstall As Boolean = True
    Private m_DepSourceInstall As Boolean = True
    Private m_DepSourcePlasmaStatus As DisplayStatus = DisplayStatus.Off
    Private m_EtchShutterInstall As Boolean = True
    Private m_PaddleShutterInstall As Boolean = True
    Private m_EtchSourceInstall As Boolean = True
    Private m_EtchSourcePlasmaStatus As DisplayStatus = DisplayStatus.Off
    Private m_ShutterOnFixtureInstall As Boolean = False
    Private m_targetText As String = String.Empty
    Private m_targetMaterialText As String = String.Empty
    Private m_targetMaterialTextColor As Color = Color.Green
    Private m_DepShutterStatus As DisplayStatus = DisplayStatus.Off
    Private m_EtchShutterStatus As DisplayStatus = DisplayStatus.Off
    Private m_PaddleShutterStatus As DisplayStatus = DisplayStatus.Off
#End Region

#Region "Properties"

    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Property DepShutterStatus() As DisplayStatus
        Get
            Return m_DepShutterStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_DepShutterStatus <> value Then
                m_DepShutterStatus = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(GetType(DisplayStatus), "Off")> _
   Public Property EtchShutterStatus() As DisplayStatus
        Get
            Return m_EtchShutterStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_EtchShutterStatus <> value Then
                m_EtchShutterStatus = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Property PaddleShutterStatus() As DisplayStatus
        Get
            Return m_PaddleShutterStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_PaddleShutterStatus <> value Then
                m_PaddleShutterStatus = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(True)> _
    Public Property DepShutterInstall() As Boolean
        Get
            Return m_DepShutterInstall
        End Get
        Set(ByVal value As Boolean)
            If m_DepShutterInstall <> value Then
                m_DepShutterInstall = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(True)> _
    Public Property EtchShutterInstall() As Boolean
        Get
            Return m_EtchShutterInstall
        End Get
        Set(ByVal value As Boolean)
            If m_EtchShutterInstall <> value Then
                m_EtchShutterInstall = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(True)> _
    Public Property PaddleShutterInstall() As Boolean
        Get
            Return m_PaddleShutterInstall
        End Get
        Set(ByVal value As Boolean)
            If m_PaddleShutterInstall <> value Then
                m_PaddleShutterInstall = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(True)> _
    Public Property DepSourceInstall() As Boolean
        Get
            Return m_DepSourceInstall
        End Get
        Set(ByVal value As Boolean)
            If m_DepSourceInstall <> value Then
                m_DepSourceInstall = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Property DepSourcePlasmaStatus() As DisplayStatus
        Get
            Return m_DepSourcePlasmaStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_DepSourcePlasmaStatus <> value Then
                m_DepSourcePlasmaStatus = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(True)> _
    Public Property EtchSourceInstall() As Boolean
        Get
            Return m_EtchSourceInstall
        End Get
        Set(ByVal value As Boolean)
            If m_EtchSourceInstall <> value Then
                m_EtchSourceInstall = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Property EtchSourcePlasmaStatus() As DisplayStatus
        Get
            Return m_EtchSourcePlasmaStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_EtchSourcePlasmaStatus <> value Then
                m_EtchSourcePlasmaStatus = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(False)> _
    Public Property ShutterOnFixtureInstall() As Boolean
        Get
            Return m_ShutterOnFixtureInstall
        End Get
        Set(ByVal value As Boolean)
            If m_ShutterOnFixtureInstall <> value Then
                m_ShutterOnFixtureInstall = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue("")> _
    Public Property TargetText() As String
        Get
            Return m_targetText
        End Get
        Set(ByVal value As String)
            If m_targetText <> value Then
                m_targetText = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue("")> _
    Public Property TargetMaterialText() As String
        Get
            Return m_targetMaterialText
        End Get
        Set(ByVal value As String)
            If m_targetMaterialText <> value Then
                m_targetMaterialText = value
                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Color), "Green")> _
    Public Property TargetMaterialTextColor() As Color
        Get
            Return m_targetMaterialTextColor
        End Get
        Set(ByVal value As Color)
            If m_targetMaterialTextColor <> value Then
                m_targetMaterialTextColor = value
                UpdateView()
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2025-06-24</date>
    ''' <summary>
    ''' Generate PVD2T chamber image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Try
            Return GeneratePVD2TImage()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2025-06-24</date>
    ''' <summary>
    ''' Generate PVD2T Chamber image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GeneratePVD2TImage() As Bitmap
        Dim chamberImage As Bitmap = My.Resources.PVD2T_Chamber
        Try
            Using g As Graphics = Graphics.FromImage(chamberImage)
                ' Draw slit valve.
                Dim slitValveImage As Bitmap = Nothing
                Select Case SlitValveStatus
                    Case AVPControls.AVPDataLib.DisplayStatus.Off
                        slitValveImage = My.Resources.PVD2T_Chamber_SlitValve_Closed
                    Case AVPControls.AVPDataLib.DisplayStatus.On
                        slitValveImage = My.Resources.PVD2T_Chamber_SlitValve_Open
                    Case Else
                        slitValveImage = My.Resources.PVD2T_Chamber_SlitValve_Unknown
                End Select
                g.DrawImageUnscaled(slitValveImage, 0, 0)
                slitValveImage.Dispose()

                ' Draw Etch.
                If EtchSourceInstall Then
                    Dim etchSourceImage As Bitmap = Nothing
                    Select Case EtchSourcePlasmaStatus
                        Case AVPControls.AVPDataLib.DisplayStatus.Unknow
                            etchSourceImage = My.Resources.PVD2T_Source_Ramp
                        Case AVPControls.AVPDataLib.DisplayStatus.On
                            etchSourceImage = My.Resources.PVD2T_Source_Plasma
                        Case Else
                            etchSourceImage = My.Resources.PVD2T_Source
                    End Select

                    g.DrawImageUnscaled(etchSourceImage, 0, 0)
                    etchSourceImage.Dispose()
                End If

                ' Draw Dep.
                If DepSourceInstall Then
                    Dim depSourceImage As Bitmap
                    Select Case DepSourcePlasmaStatus
                        Case AVPControls.AVPDataLib.DisplayStatus.Unknow
                            depSourceImage = My.Resources.PVD2T_Target_Plasma
                        Case AVPControls.AVPDataLib.DisplayStatus.On
                            depSourceImage = My.Resources.PVD2T_Target_Plasma
                        Case Else
                            depSourceImage = My.Resources.PVD2T_Target
                    End Select

                    g.DrawImageUnscaled(depSourceImage, 0, 0)
                    depSourceImage.Dispose()
                End If

                ' Draw heater panel.
                Dim frontPanelImage As Bitmap
                frontPanelImage = My.Resources.PVD2T_FrontPanel
                g.DrawImageUnscaled(frontPanelImage, 0, 0)
                frontPanelImage.Dispose()
            End Using
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return chamberImage
    End Function
#End Region

End Class
