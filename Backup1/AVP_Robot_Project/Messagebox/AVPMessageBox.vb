Public Class AVPMessageBox
    Private Shared ReadOnly NullWindow As IWin32Window = Nothing

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
        AutoManualCancel = 10
        UpDownCancel = 11
        SaveLoadLoadFromRecipeCancel = 13
        OnOffCancel = 14
    End Enum

    Private Shared Sub SetStartPosition(ByVal f As Form, ByVal o As IWin32Window)
        If o Is Nothing Then
            f.StartPosition = FormStartPosition.CenterScreen
        Else
            f.StartPosition = FormStartPosition.CenterParent
        End If
    End Sub

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
                   ByVal strMessage As String, _
                   ByVal mIcon As MessageBoxIcon, _
                   Optional ByVal mbutton As AVPMessageBoxButton = AVPMessageBoxButton.OKCancel)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        lblContent.Text = strMessage
        Me.Text = strTitle
        Select Case mIcon
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
        ' change the button 
        Select Case mbutton
            Case AVPMessageBoxButton.OK
                btnCancel.Visible = False
                btnOK.Location = New Point(163, 9)
            Case AVPMessageBoxButton.OpenCloseCancel '.YesNoCancel
                btnOK.Text = "Open"
                btnNo.Text = "Close  "
                btnCancel.Text = "Cancel"
                btnOK.Visible = True
                btnNo.Visible = True
                btnCancel.Visible = True
                btnOK.Location = New Point(19, 9)
                btnNo.Location = New Point(167, 9)
                btnCancel.Location = New Point(305, 9)
            Case AVPMessageBoxButton.SaveLoadCancel  '.AbortRetryIgnore
                btnOK.Text = "Save"
                btnNo.Text = "Load  "
                btnCancel.Text = "Cancel"
                btnOK.Visible = True
                btnNo.Visible = True
                btnCancel.Visible = True
                btnOK.Location = New Point(19, 9)
                btnNo.Location = New Point(167, 9)
                btnCancel.Location = New Point(305, 9)
            Case AVPMessageBoxButton.OKCancel
                btnOK.Location = New Point(57, 9)
                btnCancel.Location = New Point(267, 9)
                btnNo.Visible = False
                btnOK.Visible = True
                btnCancel.Visible = True
            Case AVPMessageBoxButton.PumpDownVentCancel 'AbortRetryCancel
                btnOK.Text = "Pumpdown"
                btnOK.Image = Nothing
                btnOK.TextAlign = ContentAlignment.MiddleCenter
                btnNo.Text = "Vent"
                btnNo.Image = Nothing
                btnNo.TextAlign = ContentAlignment.MiddleCenter
                btnCancel.Text = "Cancel"
                'btnCancel.Image = Nothing
                btnOK.Visible = True
                btnNo.Visible = True
                btnCancel.Visible = True
                btnOK.Location = New Point(19, 9)
                btnNo.Location = New Point(167, 9)
                btnCancel.Location = New Point(305, 9)
                '#05/04/2011 
                '#-	AVP (Recipe editor).   Change below popup message to “Yes”/”No” instead of “OK”/”Cancel”
                '#Begin fix
            Case AVPMessageBoxButton.YesNo
                btnOK.Location = New Point(57, 9)
                btnCancel.Location = New Point(267, 9)
                btnNo.Visible = False
                btnOK.Visible = True
                btnCancel.Visible = True
                btnOK.Text = "Yes"
                btnCancel.Text = "No  "
                btnCancel.TextAlign = ContentAlignment.MiddleCenter
                '#End fix
            Case AVPMessageBoxButton.TurnOnTurnOffCancel
                btnOK.Text = "Turn On"
                btnOK.Image = Nothing
                btnOK.TextAlign = ContentAlignment.MiddleCenter
                btnNo.Text = "Turn Off"
                btnNo.Image = Nothing
                btnNo.TextAlign = ContentAlignment.MiddleCenter
                btnCancel.Text = "Cancel"
                'btnCancel.Image = Nothing
                btnOK.Visible = True
                btnNo.Visible = True
                btnCancel.Visible = True
                btnOK.Location = New Point(19, 9)
                btnNo.Location = New Point(167, 9)
                btnCancel.Location = New Point(305, 9)
            Case AVPMessageBoxButton.AutoManualCancel 'AbortRetryCancel
                btnOK.Text = "Auto"
                btnOK.Image = Nothing
                btnOK.TextAlign = ContentAlignment.MiddleCenter
                btnNo.Text = "Manual"
                btnNo.Image = Nothing
                btnNo.TextAlign = ContentAlignment.MiddleCenter
                btnCancel.Text = "Cancel"
                'btnCancel.Image = Nothing
                btnOK.Visible = True
                btnNo.Visible = True
                btnCancel.Visible = True
                btnOK.Location = New Point(19, 9)
                btnNo.Location = New Point(167, 9)
                btnCancel.Location = New Point(305, 9)
            Case AVPMessageBoxButton.SaveLoadLoadFromRecipeCancel
                Me.Size = New Size(552, 236)
                Me.CancelButton = btnCancel

                btnOK.Text = "   Save"
                btnOK.Size = New Size(100, 40)
                btnOK.Location = New Point(12, 9)
                btnOK.Image = Global.AVP_Robot_Project.My.Resources.Resources.filesave
                btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
                btnOK.TabIndex = 1
                btnOK.Visible = True

                btnNo.Text = "Load"
                btnNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                btnNo.Size = New System.Drawing.Size(100, 40)
                btnNo.Location = New System.Drawing.Point(118, 9)
                btnNo.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_update
                btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
                btnNo.TabIndex = 2
                btnNo.Visible = True

                btnYesToAll.Text = "Load from recipe"
                btnYesToAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
                btnYesToAll.Size = New System.Drawing.Size(200, 40)
                btnYesToAll.Location = New System.Drawing.Point(224, 9)
                btnYesToAll.Image = Global.AVP_Robot_Project.My.Resources.Resources.db_update
                btnYesToAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
                btnYesToAll.TabIndex = 3
                btnYesToAll.Visible = True

                btnCancel.Text = " Cancel"
                btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                btnCancel.Size = New System.Drawing.Size(110, 40)
                btnCancel.Location = New System.Drawing.Point(430, 9)
                btnCancel.TabIndex = 4
                btnCancel.Visible = True
        End Select
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strTitle As String, _
                   ByVal strMessage As String, _
                   ByVal mIcon As MessageBoxIcon, _
                 ByVal blnDeleteMulti As Boolean)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        lblContent.Text = strMessage
        Me.Text = strTitle
        Select Case mIcon
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
        ' change the button 
        If blnDeleteMulti Then
            btnOK.Text = "Yes"
            btnOK.TextAlign = ContentAlignment.MiddleRight
            btnOK.Width = 80
            btnYesToAll.Visible = True
            btnNo.Visible = True
            btnNo.Width = 90
            btnCancel.Width = 110
            btnOK.Location = New Point(10, 9)
            btnYesToAll.Left = btnOK.Left + btnOK.Width + 8
            btnNo.Left = btnYesToAll.Left + btnYesToAll.Width + 8
            btnCancel.Left = btnNo.Left + btnNo.Width + 8
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub UpdateCheckboxText(ByVal text As String)
        cbAdditionalInfo.Text = text
        cbAdditionalInfo.Visible = True
    End Sub

    Public ReadOnly Property CheckBoxChecked() As Boolean
        Get
            Return cbAdditionalInfo.Checked
        End Get
    End Property

    Private Sub btnYesToAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYesToAll.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub
End Class

Public Module DialogIcon
    Public ReadOnly Question As Image = Global.AVP_Robot_Project.My.Resources.Question
    Public ReadOnly Information As Image = Global.AVP_Robot_Project.My.Resources.Information
    Public ReadOnly Warning As Image = Global.AVP_Robot_Project.My.Resources.Warning
    Public ReadOnly [Error] As Image = Global.AVP_Robot_Project.My.Resources.ErrorImage
    Public ReadOnly Security As Image = Global.AVP_Robot_Project.My.Resources.Security
    Public ReadOnly SecuritySuccess As Image = Global.AVP_Robot_Project.My.Resources.SecuritySuccess
    Public ReadOnly SecurityQuestion As Image = Global.AVP_Robot_Project.My.Resources.SecurityQuestion
    Public ReadOnly SecurityWarning As Image = Global.AVP_Robot_Project.My.Resources.SecurityWarning
    Public ReadOnly SecurityError As Image = Global.AVP_Robot_Project.My.Resources.SecurityError
End Module