Imports System
Imports System.Globalization
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Public Class AVPLogoutBox
    Private Shared ReadOnly NullWindow As IWin32Window = Nothing
    Private Shared m_AVPLogoutBox As AVPLogoutBox
    Private Shared _result As LogoutResult = LogoutResult.Cancel
    Private _selectedAction As LogoutResult = LogoutResult.Cancel
    Public Enum LogoutResult
        [Cancel] = 0
        [Ok] = 1
        [Quit] = 2
    End Enum

    ''' <summary>
    ''' Gets or sets the dialog result for the AVP Messagebox form.
    ''' </summary>
    Public Shared Property Result() As LogoutResult
        Get
            Return _result
        End Get
        Set(ByVal value As LogoutResult)
            _result = value
        End Set
    End Property

    Public Overloads Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String) As DialogResult
        Return Show(owner, text, caption, MessageBoxButtons.OK)
    End Function

    Public Overloads Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons) As DialogResult
        Return Show(owner, text, caption, buttons, MessageBoxIcon.None)
    End Function

    Public Overloads Shared Function Show(ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal DisableExit As Boolean) As DialogResult
        Return Show(NullWindow, caption, buttons, icon, MessageBoxDefaultButton.Button1, DisableExit)
    End Function

    Public Overloads Shared Function Show(ByVal owner As IWin32Window, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon) As DialogResult
        Return Show(owner, caption, buttons, icon, MessageBoxDefaultButton.Button1)
    End Function

    Public Overloads Shared Function Show(ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Return Show(NullWindow, caption, buttons, icon, defaultButton)
    End Function

    Public Overloads Shared Function Show(ByVal owner As IWin32Window, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton, Optional ByVal DisableExit As Boolean = False) As DialogResult
        If m_AVPLogoutBox Is Nothing Then
            m_AVPLogoutBox = New AVPLogoutBox
        End If
        m_AVPLogoutBox.lblContent.Text = AVPLib.ContainerData.GetMessageText("LogoutMessage")
        m_AVPLogoutBox.Text = caption
        'if Exit is not disable and enough permission 
        If Not (DisableExit) And AVPLib.ContainerData.Permission(PERMISSION_008) Then
            m_AVPLogoutBox.btnQuit.Enabled = True
        ElseIf (DisableExit) Then 'if disable Exit
            m_AVPLogoutBox.btnQuit.Enabled = False
        ElseIf Not (AVPLib.ContainerData.Permission(PERMISSION_008)) Then ''if not enough permission
            m_AVPLogoutBox.btnQuit.Enabled = False
        End If
        Select Case icon
            Case MessageBoxIcon.Asterisk, MessageBoxIcon.Information
                m_AVPLogoutBox.ImageIcon = DialogIcon.Information
            Case MessageBoxIcon.Exclamation, MessageBoxIcon.Warning
                m_AVPLogoutBox.ImageIcon = DialogIcon.Warning
            Case MessageBoxIcon.Error, MessageBoxIcon.Hand, MessageBoxIcon.Stop
                m_AVPLogoutBox.ImageIcon = DialogIcon.Error
            Case MessageBoxIcon.Question
                m_AVPLogoutBox.ImageIcon = DialogIcon.Question
            Case Else
                m_AVPLogoutBox.ImageIcon = Nothing
        End Select
        m_AVPLogoutBox.ShowDialog(owner)
        Return Result
    End Function

    Private Shared Sub SetStartPosition(ByVal f As Form, ByVal o As IWin32Window)
        If o Is Nothing Then
            f.StartPosition = FormStartPosition.CenterScreen
        Else
            f.StartPosition = FormStartPosition.CenterParent
        End If
    End Sub

    Private Sub AVPMessageBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me._selectedAction = LogoutResult.Cancel
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        _selectedAction = LogoutResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        _selectedAction = LogoutResult.Ok
        Me.Close()
    End Sub

    Private Sub btnOK_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            _selectedAction = LogoutResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        _selectedAction = LogoutResult.Quit
        Me.Close()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-03 </date>
    ''' </author>
    ''' <summary>
    ''' Set Result to Selected Action of user, default is Cancel
    ''' </summary>
    Private Sub AVPLogoutBox_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Result = _selectedAction
    End Sub
End Class
