Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Imports AVPControls

Public Class AVPProcessChimeBox
    Private Shared ReadOnly NullWindow As IWin32Window = Nothing
    Private m_statusObj As StatusObject = Nothing

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbortOnly.Click
        Try
            m_statusObj.RequestStatus(ContainerForm.CassettesPanel.btnFakeProcessCompleteChime.Name, STR_OFF)
            Me.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New(ByVal caption As String, ByVal MessageText As String, ByVal icon As MessageBoxIcon, ByVal statusObj As StatusObject)
        InitializeComponent()
        lblContent.Text = MessageText
        Me.Text = caption
        Select Case icon
            Case MessageBoxIcon.Asterisk, MessageBoxIcon.Information
                Me.ImageIcon = DialogIcon.Information
            Case MessageBoxIcon.Exclamation, MessageBoxIcon.Warning
                Me.ImageIcon = DialogIcon.Warning
            Case MessageBoxIcon.Error, MessageBoxIcon.Hand, MessageBoxIcon.Stop
                Me.ImageIcon = DialogIcon.Error
            Case MessageBoxIcon.Question
                Me.ImageIcon = DialogIcon.Question
            Case Else
                Me.ImageIcon = Nothing
        End Select
        m_statusObj = statusObj
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub


End Class
