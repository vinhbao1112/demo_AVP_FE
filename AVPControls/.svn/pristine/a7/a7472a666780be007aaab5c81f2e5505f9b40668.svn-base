Imports System.ComponentModel

''' <author>
'''     <name> Hai Tran </name>
'''     <date> 2016-04-07 </date>
''' </author>
Public Class PumpChamberControl

    Private _dockTo As PumpDockPositions = PumpDockPositions.TM
    Private _type As PumpTypes = PumpTypes.Turbo

    Public Enum PumpTypes
        Turbo
        Cryo
    End Enum

    Public Enum PumpDockPositions
        TM = 45
        LoadLockA = 0
        LoadLockB
    End Enum

    <DefaultValue(GetType(PumpTypes), "Turbo")> _
    Public Property PumpType() As PumpTypes
        Get
            Return _type
        End Get
        Set(ByVal value As PumpTypes)
            If _type <> value Then
                _type = value

                UpdateView()
            End If
        End Set
    End Property

    <DefaultValue(GetType(PumpDockPositions), "TM")> _
    Public Property DockPosition() As PumpDockPositions
        Get
            Return _dockTo
        End Get
        Set(ByVal value As PumpDockPositions)
            If _dockTo <> value Then
                _dockTo = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2016-04-07 </date>
    ''' </author>
    ''' <summary>
    ''' Generate control image
    ''' </summary>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Dim img As Bitmap = Nothing
        Try
            If AVPStyle = AVPControls.AVPDataLib.AVPStyles.PodSystem Then
                img = My.Resources.Resources.PodTurbo
            ElseIf AVPStyle <> AVPControls.AVPDataLib.AVPStyles.Inline Then
                If _type = PumpTypes.Turbo Then
                    If AVPStyle = AVPControls.AVPDataLib.AVPStyles.ML Then
                        img = My.Resources.Resources.LoaderTurbo
                    ElseIf AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX6 OrElse AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX7 OrElse AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8 Then
                        img = My.Resources.Resources.Turbo_CXX
                    Else
                        img = My.Resources.Resources.TMTurbo
                    End If
                ElseIf _type = PumpTypes.Cryo Then
                    If AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4 Then
                        img = My.Resources.Resources.TMCryo_CX4
                    ElseIf AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX6 OrElse AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX7 OrElse AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8 Then
                        img = My.Resources.Resources.Cryo_CXX
                    Else
                        img = My.Resources.Resources.TMCryo
                    End If
                End If

                If img IsNot Nothing Then
                    Dim angle As Single = 0
                    If AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4 Then
                        Select Case DockPosition
                            Case PumpDockPositions.LoadLockA, PumpDockPositions.LoadLockB
                                angle = 0
                            Case PumpDockPositions.TM
                                angle = 45
                        End Select
                    ElseIf AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX5 Then
                        Select Case DockPosition
                            Case PumpDockPositions.LoadLockA
                                angle = -151
                            Case PumpDockPositions.LoadLockB
                                angle = -29
                            Case PumpDockPositions.TM
                                angle = -45
                        End Select
                    ElseIf AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX6 OrElse AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX7 OrElse AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX8 Then
                        Select Case DockPosition
                            Case PumpDockPositions.LoadLockA
                                angle = -151
                            Case PumpDockPositions.LoadLockB
                                angle = -29
                        End Select
                    End If
                    Me.m_rotationAngle = angle
                End If
            Else
                img = My.Resources.Resources.InlineTurbo
                If DockPosition = PumpDockPositions.LoadLockB Then
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX)
                End If
                m_rotationAngle = 0
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return img
    End Function

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.RotationMode = AVPControls.AVPDataLib.AVPControlStyleModes.ControlOwner

    End Sub
End Class
