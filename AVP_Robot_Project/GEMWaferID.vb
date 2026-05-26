Public Class GEMWaferID
    Private m_disableDefine As Boolean = False
    Public Event AutoWaferIDPress As EventHandler

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        txtGEMWaferID.Font = Me.Font
        txtGEMWaferID.AccessibleDescription = "Wafer ID"
        lblWaferID.Font = Me.Font
        lblWaferID.Dock = DockStyle.Left
        lblPadding.Dock = DockStyle.Right
        txtGEMWaferID.Dock = DockStyle.Fill
        Me.Controls.Add(txtGEMWaferID)
        Me.Controls.Add(lblWaferID)
        Me.Controls.Add(lblPadding)
        AddHandler txtGEMWaferID.AutoKeyEnterPress, AddressOf KeyEnterPress


        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property WaferID() As String
        Get
            Return lblWaferID.Text
        End Get
        Set(ByVal value As String)
            lblWaferID.Text = value
        End Set
    End Property

    Public Property GEMWaferID() As String
        Get
            Return txtGEMWaferID.Text
        End Get
        Set(ByVal value As String)
            txtGEMWaferID.Text = value
        End Set
    End Property

    Public Property DisableDefine() As Boolean
        Get
            Return m_disableDefine
        End Get
        Set(ByVal value As Boolean)
            m_disableDefine = value
            txtGEMWaferID.Enabled = Not m_disableDefine
            lblWaferID.Enabled = Not m_disableDefine
        End Set
    End Property

    Private Sub GEMWaferID_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged
        txtGEMWaferID.Font = Me.Font
        lblWaferID.Font = Me.Font
    End Sub

    Private Sub KeyEnterPress(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent AutoWaferIDPress(Me, Nothing)
    End Sub
End Class
