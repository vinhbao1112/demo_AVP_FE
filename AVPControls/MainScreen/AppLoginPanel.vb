Imports System.ComponentModel

''' <author>
'''     <name>Hai Tran</name>
'''     <date>2015-10-01</date>
''' </author>
''' <summary>
''' Host communication panel.
''' </summary>
''' <remarks></remarks>
Public Class AppLoginPanel
    Private m_username As String
    Private m_groupName As String
    <DefaultValue(GetType(String), "")> _
    Public Property Username() As String
        Get
            Return m_username
        End Get
        Set(ByVal value As String)
            If m_username <> value Then
                m_username = value

                UpdateLoginStyle()
            End If
        End Set
    End Property

    <DefaultValue(GetType(String), "")> _
    Public Property Group() As String
        Get
            Return m_groupName
        End Get
        Set(ByVal value As String)
            If m_groupName <> value Then
                m_groupName = value

                UpdateLoginStyle()
            End If
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.BackgroundSize = PanelBackgroundSizes.Size3
        UpdateLoginStyle()
    End Sub

    ''' <author>Tinh Le</author>
    ''' <date>2018-04-04</date>
    ''' <summary>
    ''' Update login text box style.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateLoginStyle()
        Try
            Const DefaulltUsenameText As String = "PLEASE LOGIN"
            Const DefaultPrivilege As String = "NONE"

            If Not String.IsNullOrEmpty(m_username) OrElse Not String.IsNullOrEmpty(m_groupName) Then
                txtUsername.ForeColor = Color.Blue
                txtGroup.ForeColor = Color.Blue

                txtUsername.Text = m_username
                txtGroup.Text = m_groupName
            Else
                txtUsername.ForeColor = Color.OrangeRed
                txtGroup.ForeColor = Color.OrangeRed

                txtUsername.Text = DefaulltUsenameText
                txtGroup.Text = DefaultPrivilege
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <summary>
    ''' Update GUI on background size changed.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnBackgroundSizeChanged()
        Try
            Dim margin As Integer
            Dim space As Integer
            Select Case BackgroundSize
                Case PanelBackgroundSizes.Size1
                    margin = 3
                    space = 3
                Case Else
                    margin = 12
                    space = 5
            End Select

            Dim textWidth As Integer = CInt((Me.Width - (margin * 2 + 1) - space) / 2)

            txtUsername.Width = textWidth
            txtGroup.Width = textWidth

            txtUsername.Left = margin + 1
            txtGroup.Left = margin + textWidth + space

            lblUser.Left = txtUsername.Left + CInt((textWidth - lblUser.Width) / 2)
            lblPrivilege.Left = txtGroup.Left + CInt((textWidth - lblPrivilege.Width) / 2)

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

#End Region

End Class
