Public Class AVPAbortBox
    Private Shared ReadOnly NullWindow As IWin32Window = Nothing

    Private Shared Sub SetStartPosition(ByVal f As Form, ByVal o As IWin32Window)
        If o Is Nothing Then
            f.StartPosition = FormStartPosition.CenterScreen
        Else
            f.StartPosition = FormStartPosition.CenterParent
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbortAndReturn.Click
        DialogResult = Windows.Forms.DialogResult.Ignore
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbortOnly.Click
        DialogResult = Windows.Forms.DialogResult.Abort
    End Sub

    Private Sub Me_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Public Sub New(ByVal caption As String, ByVal MessageText As String, ByVal icon As MessageBoxIcon)
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
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub


End Class
