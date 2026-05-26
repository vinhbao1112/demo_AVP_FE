Imports AVPControls.AVPDataLib
Imports System.ComponentModel

<DefaultEvent("Click")> _
Public Class HeaderControl
    Private m_headerAlignStyle As AVPAlignStyles = AVPAlignStyles.Left

#Region "Properties"
    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(280, 28)
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultMinimumSize() As System.Drawing.Size
        Get
            Return New Size(68, 0)
        End Get
    End Property

    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Overrides Property Status() As DisplayStatus
        Get
            Return MyBase.Status
        End Get
        Set(ByVal value As DisplayStatus)
            If MyBase.Status <> value Then
                MyBase.Status = value
                Select Case value
                    Case DisplayStatus.Off
                        Me.pnlHeader.BackColor = STATUS_OFF_COLOR
                        Me.lblHeaderText.ForeColor = TEXT_OFF_COLOR
                        Me.lblOnline.ForeColor = Color.Yellow
                    Case DisplayStatus.On
                        Me.pnlHeader.BackColor = STATUS_ON_COLOR
                        Me.lblHeaderText.ForeColor = TEXT_ON_COLOR
                        Me.lblOnline.ForeColor = Color.Black
                    Case DisplayStatus.Unknow
                        Me.pnlHeader.BackColor = STATUS_UNKNOWN_COLOR
                        Me.lblHeaderText.ForeColor = TEXT_UNKNOWN_COLOR
                        Me.lblOnline.ForeColor = Color.Black
                    Case DisplayStatus.Error
                        Me.pnlHeader.BackColor = STATUS_ERROR_COLOR
                        Me.lblHeaderText.ForeColor = TEXT_ERROR_COLOR
                        Me.lblOnline.ForeColor = Color.Yellow
                    Case Else
                        Me.pnlHeader.BackColor = STATUS_NONE_COLOR
                        Me.lblHeaderText.ForeColor = TEXT_NONE_COLOR
                        Me.lblOnline.ForeColor = Color.Yellow
                End Select
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property CommunicationVisible() As Boolean
        Get
            Return pnlHeaderCom.Visible
        End Get
        Set(ByVal value As Boolean)
            If pnlHeaderCom.Visible <> value Then
                pnlHeaderCom.Visible = value
            End If
        End Set
    End Property

    <DefaultValue(GetType(ContentAlignment), "MiddleCenter")> _
    Public Property HeaderTextAlign() As ContentAlignment
        Get
            Return Me.lblHeaderText.TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            If Me.lblHeaderText.TextAlign <> value Then
                Me.lblHeaderText.TextAlign = value
            End If
        End Set
    End Property

    <DefaultValue(GetType(AVPAlignStyles), "Left")> _
    Public Property AlignStyle() As AVPAlignStyles
        Get
            Return m_headerAlignStyle
        End Get
        Set(ByVal value As AVPAlignStyles)
            If m_headerAlignStyle <> value Then
                m_headerAlignStyle = value
                Select Case m_headerAlignStyle
                    Case AVPAlignStyles.Left
                        Me.pnlHeaderCom.Dock = DockStyle.Right
                        Me.lblOnline.Dock = DockStyle.Right
                    Case AVPAlignStyles.Right
                        Me.pnlHeaderCom.Dock = DockStyle.Left
                        Me.lblOnline.Dock = DockStyle.Left
                End Select
            End If
        End Set
    End Property

    <DefaultValue(GetType(Single), "12.5")> _
    Public Property HeaderFontSize() As Single
        Get
            Return Me.lblHeaderText.Font.Size
        End Get
        Set(ByVal value As Single)
            If Me.lblHeaderText.Font.Size <> value Then
                Me.lblHeaderText.Font = New Font(Me.lblHeaderText.Font.FontFamily.Name, value, FontStyle.Bold, GraphicsUnit.Point)
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property OnlineVisible() As Boolean
        Get
            Return Me.lblOnline.Visible
        End Get
        Set(ByVal value As Boolean)
            If Me.lblOnline.Visible <> value Then
                Me.lblOnline.Visible = value
            End If
        End Set
    End Property

    <DefaultValue(GetType(String), "Header Text"), Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Overrides Property Text() As String
        Get
            Return Me.lblHeaderText.Text
        End Get
        Set(ByVal value As String)
            Me.lblHeaderText.Text = value
        End Set
    End Property
#End Region

#Region "Events"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.pnlHeader.BackColor = STATUS_OFF_COLOR
        Me.lblHeaderText.ForeColor = TEXT_OFF_COLOR
    End Sub

    Private Sub HeaderControl_ConnectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ConnectionChanged
        If Me.IsConnected Then
            Me.ComPanel.Status = DisplayStatus.On
        Else
            Me.ComPanel.Status = DisplayStatus.Off
        End If
    End Sub

    Private Sub pnlHeaderText_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlHeaderText.SizeChanged
        Me.lblHeaderText.Size = Me.pnlHeaderText.Size
    End Sub

    Private Sub HeaderControl_OnlineChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnlineChanged
        If Me.IsOnline Then
            Me.lblOnline.Text = "(Online)"
        Else
            Me.lblOnline.Text = "(Offline)"
        End If
    End Sub

    Private Sub HeaderControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles lblOnline.Click, lblHeaderText.Click
        MyBase.OnClick(e)
    End Sub
#End Region

End Class
