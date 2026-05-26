Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class CommunicationControl

    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(68, 28)
        End Get
    End Property

    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Overrides Property Status() As DisplayStatus
        Get
            Return Me.LED.Status
        End Get
        Set(ByVal value As DisplayStatus)
            Me.LED.Status = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-03-15</date>
    ''' <summary>
    ''' Gets or sets status of the second communication.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Property Status2() As DisplayStatus
        Get
            Return LED2.Status
        End Get
        Set(ByVal value As DisplayStatus)
            LED2.Status = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-03-15</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether Com. LED1 is visible.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(True)> _
    Public Property Com1Visible() As Boolean
        Get
            Return ComPanel1.Visible
        End Get
        Set(ByVal value As Boolean)
            ComPanel1.Visible = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-03-15</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether Com. LED2 is visible.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False)> _
    Public Property Com2Visible() As Boolean
        Get
            Return ComPanel2.Visible
        End Get
        Set(ByVal value As Boolean)
            ComPanel2.Visible = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-03-15</date>
    ''' <summary>
    ''' Gets or sets a value indicates text display of LED1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue("")> _
    Public Property ComLabel1Text() As String
        Get
            Return ComLabel1.Text
        End Get
        Set(ByVal value As String)
            ComLabel1.Text = value
            ComLabel1.Visible = Not String.IsNullOrEmpty(value)
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-03-15</date>
    ''' <summary>
    ''' Gets or sets a value indicates text display of LED2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue("")> _
    Public Property ComLabel2Text() As String
        Get
            Return ComLabel2.Text
        End Get
        Set(ByVal value As String)
            ComLabel2.Text = value
            ComLabel2.Visible = Not String.IsNullOrEmpty(value)
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-03-15</date>
    ''' <summary>
    ''' Update width, location.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComPanel_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComPanel1.VisibleChanged, ComPanel2.VisibleChanged, ComLabel1.VisibleChanged, ComLabel2.VisibleChanged
        Dim w As Integer = pnlComLeftEdge.Width + pnlComRightEdge.Width + lblCom.Width + 2
        If ComPanel1.Visible Then
            If Not ComLabel1.Visible Then
                ComPanel1.Width = LED.Width
                LED.Left = 0
            Else
                ComPanel1.Width = 35
                LED.Left = ComPanel1.Width - LED.Width - 1
                ComLabel1.Left = LED.Left - ComLabel1.Width + 1
            End If
            w += ComPanel1.Width
        End If

        If ComPanel2.Visible Then
            If Not ComLabel2.Visible Then
                ComPanel2.Width = LED2.Width
                LED2.Left = 0
            Else
                ComPanel2.Width = 35
                LED2.Left = ComPanel2.Width - LED2.Width - 1
                ComLabel2.Left = LED2.Left - ComLabel2.Width + 1
            End If
            w += ComPanel2.Width
        End If

        Me.Width = w + 2
        If Me.Width >= 100 Then
            pnlCom.BackgroundImage = My.Resources.BgCommunicationLarger
        Else
            pnlCom.BackgroundImage = My.Resources.BgCommunication
        End If
    End Sub
End Class
