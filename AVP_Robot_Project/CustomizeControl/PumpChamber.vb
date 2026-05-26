Imports System.ComponentModel

Public Class PumpChamber
    Private m_img As Image = My.Resources.Resources.TMTurbo
    Private m_dockTo As PumpDockPositions = PumpDockPositions.TM
    Private m_type As PumpTypes = PumpTypes.Turbo

    Public Enum PumpTypes
        Turbo
        Cryo
    End Enum

    Public Enum PumpDockPositions
        TM = -45
        LoadLock = 0
    End Enum

    <DefaultValue(GetType(PumpTypes), "Turbo")> _
        Public Property PumpType() As PumpTypes
        Get
            Return m_type
        End Get
        Set(ByVal value As PumpTypes)
            If m_type <> value Then
                m_type = value
                If m_type = PumpTypes.Turbo Then
                    m_img = My.Resources.Resources.TMTurbo
                ElseIf m_type = PumpTypes.Cryo Then
                    m_img = My.Resources.Resources.TMCryo
                End If
                Repaint()
            End If
        End Set
    End Property

    <DefaultValue(GetType(PumpDockPositions), "TM")> _
    Public Property DockPosition() As PumpDockPositions
        Get
            Return m_dockTo
        End Get
        Set(ByVal value As PumpDockPositions)
            If m_dockTo <> value Then
                m_dockTo = value
                Repaint()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summmary>
    ''' Paint control image
    ''' </summary>
    Private Sub Repaint()
        Try
            Dim angle As Single = CSng(m_dockTo)
            Dim size As Integer = CInt(Math.Sqrt(m_img.Width * m_img.Width + m_img.Height * m_img.Height))
            Dim img As Bitmap = New Bitmap(size, size)
            img.SetResolution(m_img.HorizontalResolution, m_img.VerticalResolution)

            Using gr As Graphics = Graphics.FromImage(img)
                gr.TranslateTransform(size / 2.0F, size / 2.0F)
                gr.RotateTransform(angle)
                gr.TranslateTransform(size / -2.0F, size / -2.0F)

                gr.DrawImage(m_img, (size - m_img.Width) / 2.0F, (size - m_img.Height) / 2.0F)
            End Using

            Utils.CreateControlRegion(Me, img)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub PumpChamber_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Repaint()
    End Sub
End Class
