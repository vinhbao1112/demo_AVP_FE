Public Class AVPWarningBox
    'Private Shared ReadOnly NullWindow As IWin32Window

    Public Enum AVPDialogIcon
        None
        Information
        Question
        Warning
        [Error]
        SecuritySuccess
        SecurityQuestion
        SecurityWarning
        SecurityError
        SecurityShield
        SecurityShieldBlue
        SecurityShieldGray
    End Enum

    Public Enum AVPMessageBoxButton
        ''from 0 to 5 -> base on Window Messagebox Button=>do not change
        OK = 0
        OKCancel = 1
        AbortRetryIgnore = 2
        YesNoCancel = 3
        YesNo = 4
        RetryCancel = 5
        ''we can add more custome button from here
        OpenCloseCancel = 6
        PumpDownVentCancel = 7
        SaveLoadCancel = 8
        TurnOnTurnOffCancel = 9
        OnOffCancel = 10
        UpDownCancel = 11
        AutoManualCancel = 12
    End Enum

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnOK_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Public Sub New(ByVal strTitle As String, _
                   ByVal strMessage As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        strMessage = strMessage.Replace("\n", Environment.NewLine)
        lblText.Text = strMessage
        Me.Text = strTitle

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class