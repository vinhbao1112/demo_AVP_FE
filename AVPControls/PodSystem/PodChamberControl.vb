Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class PodChamberControl

#Region "Fields"
    Private m_pumpingStatus As PodPumpingStatus = PodPumpingStatus.Available
    Private m_lastPumped As Date = Date.MinValue
    Private m_lotID As String = String.Empty
    Private m_podIndex As Integer = 0
    Private m_podType As PodTypes = PodTypes.Type1

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2018-05-29</date>
    ''' <summary>
    ''' Gets or sets Pod index.
    ''' </summary>
    <DefaultValue(0)> _
    Public Property PodIndex() As Integer
        Get
            Return m_podIndex
        End Get
        Set(ByVal value As Integer)
            If m_podIndex <> value Then
                m_podIndex = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-05-29</date>
    ''' <summary>
    ''' Gets or sets last pumped information.
    ''' </summary>
    <DefaultValue(GetType(Date), "1/1/1")> _
    Public Property LastPumped() As Date
        Get
            Return m_lastPumped
        End Get
        Set(ByVal value As Date)
            If m_lastPumped <> value Then
                m_lastPumped = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-05-29</date>
    ''' <summary>
    ''' Gets or sets lot id information.
    ''' </summary>
    <DefaultValue("")> _
    Public Property LotID() As String
        Get
            Return m_lotID
        End Get
        Set(ByVal value As String)
            If m_lotID <> value Then
                m_lotID = value
                lblLotID.Text = value
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-05-29</date>
    ''' <summary>
    ''' Gets or sets lot id information.
    ''' </summary>
    <DefaultValue(GetType(PodPumpingStatus), "Available")> _
    Public Property PumpingStatus() As PodPumpingStatus
        Get
            Return m_pumpingStatus
        End Get
        Set(ByVal value As PodPumpingStatus)
            If m_pumpingStatus <> value Then
                m_pumpingStatus = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-05-29</date>
    ''' <summary>
    ''' Gets or sets lot id information.
    ''' </summary>
    <DefaultValue(GetType(PodTypes), "Type1")> _
    Public Property PodType() As PodTypes
        Get
            Return m_podType
        End Get
        Set(ByVal value As PodTypes)
            If m_podType <> value Then
                m_podType = value

                UpdateView()

                UpdateLodIDLabelLocation()
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2018-05-29</date>
    ''' <summary>
    ''' Returns image of control.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Try
            Const InfoTextSpace As Integer = 11
            Const LastPumpedText As String = "Last Pumped"
            'Const LotText As String = ""

            Dim img As Bitmap
            Dim podTextY As Integer = 66
            Dim pumpingTextY As Integer = 265
            Dim lastPumpedTextY As Integer
            Dim lotTextY As Integer
            'Dim infoTextX As Integer

            If m_podType = PodTypes.Type2 Then
                img = My.Resources.PodChamber_Large
                lastPumpedTextY = 97
                lotTextY = 167
                pumpingTextY = 255
                'infoTextX = 33
            Else
                img = My.Resources.PodChamber_Small
                lastPumpedTextY = 100
                lotTextY = 151
                'infoTextX = 16
            End If

            Using g As Graphics = Graphics.FromImage(img)
                Using podf As New Font("Time News Roman", 17, FontStyle.Bold, GraphicsUnit.Pixel)
                    Dim podText As String = "POD #"
                    If m_podIndex > 0 Then
                        podText &= m_podIndex.ToString()
                    End If

                    Dim podTextSize As SizeF = g.MeasureString(podText, podf)
                    Dim podTextX As Integer = CInt((img.Width - podTextSize.Width) / 2)

                    g.DrawString(podText, podf, Brushes.Navy, podTextX, podTextY)
                End Using

                Using infof As New Font("Time News Roman", 14, FontStyle.Bold, GraphicsUnit.Pixel)
                    Dim lastPumpedTextSize As SizeF = g.MeasureString(LastPumpedText, infof)
                    Dim infoTextX As Integer = CInt((img.Width - lastPumpedTextSize.Width) / 2)

                    g.DrawString(LastPumpedText, infof, Brushes.Black, infoTextX, lastPumpedTextY)
                    'g.DrawString(LotText, infof, Brushes.Black, infoTextX, lotTextY)

                    Dim pumpingText As String = m_pumpingStatus.ToString().ToUpper()
                    Dim pumpingTextSize As SizeF = g.MeasureString(pumpingText, infof)
                    Dim pumpingTextX As Integer = CInt((img.Width - pumpingTextSize.Width) / 2)

                    Select Case m_pumpingStatus
                        Case PodPumpingStatus.Available
                            g.DrawString(pumpingText, infof, Brushes.Black, pumpingTextX, pumpingTextY + 5)
                        Case PodPumpingStatus.Pumping
                            g.DrawString(pumpingText, infof, Brushes.Blue, pumpingTextX, pumpingTextY + 5)
                        Case PodPumpingStatus.Venting
                            g.DrawString(pumpingText, infof, Brushes.OrangeRed, pumpingTextX, pumpingTextY + 5)
                        Case PodPumpingStatus.Waiting
                            g.DrawString(pumpingText, infof, Brushes.Yellow, pumpingTextX, pumpingTextY + 5)
                        Case PodPumpingStatus.PumpFailed
                            g.DrawString("PUMP FAILED", infof, Brushes.Red, pumpingTextX - 2, pumpingTextY + 5)
                        Case PodPumpingStatus.VentFailed
                            g.DrawString("VENT FAILED", infof, Brushes.Red, pumpingTextX - 2, pumpingTextY + 5)
                    End Select
                End Using

                If m_lastPumped <> Date.MinValue OrElse Not String.IsNullOrEmpty(m_lotID) Then
                    Using infof As New Font("Time News Roman", 12, FontStyle.Bold, GraphicsUnit.Pixel)
                        If m_lastPumped <> Date.MinValue Then
                            Dim lastPumpedInfo As String = m_lastPumped.ToString("MM/dd/yyyy")
                            lastPumpedInfo = lastPumpedInfo + vbCrLf + m_lastPumped.ToString("HH:mm:ss")

                            Dim podTextSize As SizeF = g.MeasureString(lastPumpedInfo, infof)
                            Dim podTextX As Integer = CInt((img.Width - podTextSize.Width) / 2)

                            g.DrawString(lastPumpedInfo, infof, Brushes.Black, podTextX, lastPumpedTextY + 12 + InfoTextSpace)
                        End If

                        'If Not String.IsNullOrEmpty(m_lotID) Then
                        '    g.DrawString(m_lotID, infof, Brushes.Black, infoTextX, lotTextY + 15 + InfoTextSpace)
                        'End If
                    End Using
                End If
            End Using

            Return img
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>Hoai Ly</author>
    ''' <date>2018-06-14</date>
    ''' <summary>
    ''' Update LodID Label Location
    ''' </summary>
    Private Sub UpdateLodIDLabelLocation()
        Try
            If m_podType = PodTypes.Type2 Then
                lblLotID.Size = New Size(220, 34)
                lblLotID.Location = New Point(33, 190)
            Else
                lblLotID.Size = New Size(90, 55)
                lblLotID.Location = New Point(21, 190)
            End If

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UpdateLodIDLabelLocation()
    End Sub
#End Region
End Class
