Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class PVDADoorControl

#Region "Fields"

    Private m_doorClosed As Boolean = True
    Private m_plasmaStatus As DisplayStatus = DisplayStatus.Off
    Private m_isPlasmaOn As Boolean = False
    Private m_chuckText As String = "Chuck Pos."
    Private m_chuckPositionText As String = String.Empty

#End Region

#Region "Events"

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-20</date>
    ''' <summary>
    ''' Occurs when door open/closed status changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event DoorStatusChanged As EventHandler

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-20</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the door is closed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(True)> _
    Public Property DoorClosed() As Boolean
        Get
            Return m_doorClosed
        End Get
        Set(ByVal value As Boolean)
            If m_doorClosed <> value Then
                m_doorClosed = value

                UpdateView()

                RaiseDoorStatusChangedEvent()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-20</date>
    ''' <summary>
    ''' Gets or sets plasma status.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Property PlasmaStatus() As DisplayStatus
        Get
            Return m_plasmaStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_plasmaStatus <> value Then
                m_plasmaStatus = value
                m_isPlasmaOn = (m_plasmaStatus = DisplayStatus.On OrElse m_plasmaStatus = DisplayStatus.Unknow)

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-20</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the plasma is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False)> _
    Public Property IsPlasmaOn() As Boolean
        Get
            Return m_isPlasmaOn
        End Get
        Set(ByVal value As Boolean)
            If m_isPlasmaOn <> value Then
                m_isPlasmaOn = value
                m_plasmaStatus = IIf(m_isPlasmaOn, DisplayStatus.On, DisplayStatus.Off)

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-20</date>
    ''' <summary>
    ''' Gets or sets chuck text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue("Chuck Pos.")> _
    Public Property ChuckText() As String
        Get
            Return m_chuckText
        End Get
        Set(ByVal value As String)
            If m_chuckText <> value Then
                m_chuckText = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-20</date>
    ''' <summary>
    ''' Gets or sets chuck position text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue("")> _
    Public Property ChuckPositionText() As String
        Get
            Return m_chuckPositionText
        End Get
        Set(ByVal value As String)
            If m_chuckPositionText <> value Then
                m_chuckPositionText = value

                UpdateView()
            End If
        End Set
    End Property

#End Region

#Region "Private Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-20</date>
    ''' <summary>
    ''' Generate control image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Try
            Dim img As Bitmap
            If DoorClosed Then
                If PlasmaStatus = DisplayStatus.On Then
                    img = My.Resources.Resources.PVDA_SA_LidClosed_Plasma
                ElseIf PlasmaStatus = DisplayStatus.Unknow Then
                    img = My.Resources.Resources.PVDA_SA_LidClosed_Ramping
                Else
                    img = My.Resources.Resources.PVDA_SA_LidClosed
                End If
            Else
                img = My.Resources.Resources.PVDA_SA_LidOpen
            End If

            Using g As Graphics = Graphics.FromImage(img)

                ' Draw chuck text.
                If Not String.IsNullOrEmpty(ChuckText) Then
                    Dim f As New Font("Times New Roman", 11, FontStyle.Regular, GraphicsUnit.Point)
                    Dim strFormat As New StringFormat()
                    strFormat.Alignment = StringAlignment.Center
                    strFormat.LineAlignment = StringAlignment.Center

                    Dim drawRect As RectangleF
                    If DoorClosed Then
                        drawRect = New RectangleF(316, 64, 145, 15)
                    Else
                        drawRect = New RectangleF(54, 300, 145, 15)
                    End If

                    g.DrawString(ChuckText, f, Brushes.Black, drawRect, strFormat)

                    f.Dispose()
                End If

                ' Draw chuck position text.
                If Not String.IsNullOrEmpty(ChuckPositionText) Then
                    Dim f As New Font("Times New Roman", 11, FontStyle.Bold, GraphicsUnit.Point)
                    Dim strFormat As New StringFormat()
                    strFormat.Alignment = StringAlignment.Center
                    strFormat.LineAlignment = StringAlignment.Center

                    Dim drawRect As RectangleF
                    If DoorClosed Then
                        drawRect = New RectangleF(316, 80, 145, 15)
                    Else
                        drawRect = New RectangleF(54, 284, 145, 15)
                    End If

                    g.DrawString(ChuckPositionText, f, Brushes.Black, drawRect, strFormat)

                    f.Dispose()
                End If

            End Using

            Return img
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-20</date>
    ''' <summary>
    ''' Raise DoorStatusChanged event.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub RaiseDoorStatusChangedEvent()
        RaiseEvent DoorStatusChanged(Me, EventArgs.Empty)
    End Sub

#End Region

End Class
