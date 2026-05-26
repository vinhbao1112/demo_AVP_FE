Imports System.Text.RegularExpressions
Public Class KeyPad

    ' To turn on/off the capslock key
    Private Declare Sub keybd_event Lib "user32" ( _
        ByVal bVk As Byte, _
        ByVal bScan As Byte, _
        ByVal dwFlags As Integer, _
        ByVal dwExtraInfo As Integer _
    )

    Private Const VK_CAPITAL As Integer = &H14
    Private Const KEYEVENTF_EXTENDEDKEY As Integer = &H1
    Private Const KEYEVENTF_KEYUP As Integer = &H2
    Private m_IsCheckInvalidCharacter As Boolean
    Private m_RemoveSpecialKey As Boolean
    Private m_CurrentSelectionStart As Integer
    Private isEnableBtnColon As Boolean
    Private m_isremovespace As Boolean
    Private m_isEnableBtnAt As Boolean

    Private ShiftStatus As Boolean
    Private strDisplay As String
    Private UserResponse As DialogResult
    Private m_IsEnableTextChange As Boolean = False
    Private textControl As TextBox

    Public Property IsEnableTextChange() As Boolean
        Get
            Return m_IsEnableTextChange
        End Get
        Set(ByVal value As Boolean)
            m_IsEnableTextChange = value
        End Set
    End Property

    Public Property IsRemoveSpaceStr() As Boolean
        Get
            Return m_isremovespace
        End Get
        Set(ByVal value As Boolean)
            m_isremovespace = value
        End Set
    End Property

    Public Property Enable_DisableBtnAt() As Boolean
        Get
            Return m_isEnableBtnAt
        End Get
        Set(ByVal value As Boolean)
            m_isEnableBtnAt = value
        End Set
    End Property

    Public Property IsCheckInvalidCharacter() As Boolean
        Get
            Return m_IsCheckInvalidCharacter
        End Get
        Set(ByVal value As Boolean)
            m_IsCheckInvalidCharacter = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.UserResponse = Windows.Forms.DialogResult.Cancel

        ' Add handler for almost all buttons on screen
        Dim handler As EventHandler = New EventHandler(AddressOf Me.GetClickedButtonText)
        Dim control As Control
        For Each control In Me.pnlContainer.Controls
            If (TypeOf control Is Button AndAlso _
                      Not ((control.Name = "btnBackSpace") OrElse (control.Name = "btnEnter") _
                        OrElse (control.Name = "btnShift") OrElse (control.Name = "btnCancel"))) Then
                AddHandler control.Click, handler
            End If
        Next
        ' MyBase.Size = Me.pnlBorder.Size

        ' Show on the center of screen
        MyBase.StartPosition = FormStartPosition.CenterScreen
    End Sub

    ' Handle BackSpace button
    Private Sub btnBackSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackSpace.Click
        Dim text As String = Me.txtDisplay.Text
        Dim intCaret As Integer = Me.txtDisplay.SelectionStart
        Try
            If Me.txtDisplay.SelectionLength = text.Length Then ''clear all 
                txtDisplay.Text = String.Empty
            ElseIf Me.txtDisplay.SelectionLength > 0 Then
                text = text.Remove(intCaret, Me.txtDisplay.SelectionLength)
                Me.txtDisplay.Text = text
                Me.txtDisplay.SelectionStart = intCaret
            ElseIf (text.Length <> 0) AndAlso (intCaret > 0) Then
                text = text.Remove(intCaret - 1, 1)
                Me.txtDisplay.Text = text
                Me.txtDisplay.SelectionStart = intCaret - 1
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Me.txtDisplay.Focus()
        End Try
    End Sub

    ' Handle Cancel button
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.UserResponse = Windows.Forms.DialogResult.Cancel
        MyBase.Close()
    End Sub

    ' Handle Enter button
    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        Me.strDisplay = Me.txtDisplay.Text
        Me.UserResponse = Windows.Forms.DialogResult.OK
        MyBase.Close()
    End Sub

    ' For all charater and number buttons
    Private Sub GetClickedButtonText(ByVal sender As Object, ByVal e As EventArgs)

        If Me.txtDisplay.SelectionLength > 0 Then
            Me.btnBackSpace_Click(sender, e)
        End If

        Dim inputChar As String = DirectCast(sender, Button).Text
        m_CurrentSelectionStart = txtDisplay.SelectionStart + 1
        Me.txtDisplay.Focus()

        If m_CurrentSelectionStart - 1 < txtDisplay.Text.Length Then
            Me.txtDisplay.Text = Me.txtDisplay.Text.Insert(m_CurrentSelectionStart - 1, inputChar)
        Else
            Me.txtDisplay.Text = txtDisplay.Text & inputChar
        End If

        Me.txtDisplay.SelectionLength = 0
    End Sub

    ' Change the all charater and number button text to UPPER or lower
    Private Sub ChangeCase()
        If Me.ShiftStatus Then
            btnShift.Image = Global.AVPControls.My.Resources.Resources.Sensor_Green
        Else
            btnShift.Image = Global.AVPControls.My.Resources.Resources.Sensor_Black
        End If
        Dim control As Control
        For Each control In Me.pnlContainer.Controls
            If TypeOf control Is Button Then
                Dim text As String = control.Text
                If Not ((control.Name = "btnBackSpace") Or (control.Name = "btnEnter") Or _
                           (control.Name = "btnShift") Or (control.Name = "btnCancel") Or _
                           (control.Name = "btnSpace")) Then
                    If Me.ShiftStatus Then
                        control.Text = text.ToUpper
                    Else
                        control.Text = text.ToLower
                    End If
                End If
            End If
        Next
    End Sub

    ' Form load event
    Private Sub KeyPad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnColon.Visible = isEnableBtnColon
        Me.btnAt.Visible = m_isEnableBtnAt

        If isEnableBtnColon Then
            Me.btnEnter.Left = Me.btnColon.Right
        Else
            Me.btnEnter.Left = Me.btnColon.Left
        End If

        Me.ShiftStatus = Control.IsKeyLocked(Keys.CapsLock)
        Me.ChangeCase()
        txtDisplay.SelectAll()
    End Sub

    Public Sub Enable_Disable_SpecKey(ByVal IsEnable As Boolean)
        m_RemoveSpecialKey = Not IsEnable
    End Sub

    ' Capslock button click
    Private Sub btnShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShift.Click
        Me.ShiftStatus = Not Me.ShiftStatus
        Me.ChangeCase()
        Me.txtDisplay.Focus()
        Me.txtDisplay.SelectionStart = Me.txtDisplay.Text.Length

        ' Turn On/Off capslock state
        ' Simulate the Key Press
        keybd_event(VK_CAPITAL, &H45, KEYEVENTF_EXTENDEDKEY Or 0, 0)

        ' Simulate the Key Release
        keybd_event(VK_CAPITAL, &H45, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)

    End Sub

    ' Key down on textbox
    Private Sub txtDisplay_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDisplay.KeyDown
        If (e.KeyCode = Keys.Return) Then
            Me.btnEnter_Click(sender, e)
        ElseIf (e.KeyCode = Keys.Escape) Then
            Me.btnCancel_Click(sender, e)
        End If
    End Sub

    ' Key down on textbox
    Private Sub txtDisplay_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDisplay.KeyUp
        If (e.KeyCode = Keys.Capital) Then
            Me.ShiftStatus = Control.IsKeyLocked(Keys.CapsLock)
            Me.ChangeCase()
        End If
    End Sub

    ' Public function for other components to call
    Public Function DisplayKeypad(ByRef TextToDisplay As String, ByVal Caption As String, ByVal IsPassword As Boolean) As DialogResult
        If IsPassword Then
            Me.txtDisplay.PasswordChar = "*"c
        Else
            Me.txtDisplay.PasswordChar = ChrW(0)
        End If

        If IsCheckInvalidCharacter Then
            Me.btnBackSlash.Visible = False
            Me.btnFrontSlash.Visible = False
        End If

        Me.Text = Caption
        Me.strDisplay = TextToDisplay
        Me.txtDisplay.Text = Me.strDisplay
        Me.txtDisplay.Focus()
        Me.txtDisplay.SelectionStart = Me.txtDisplay.Text.Length
        MyBase.ShowDialog()
        TextToDisplay = Me.strDisplay
        Return Me.UserResponse
    End Function

    ' Public function for other components to call
    Public Function DisplayKeypad(ByVal control As TextBox, ByVal Caption As String) As DialogResult
        Try
            textControl = control
            Dim IsPassword As Boolean
            If control IsNot Nothing AndAlso (control.UseSystemPasswordChar OrElse control.PasswordChar <> ChrW(0)) Then
                IsPassword = True
            End If
            Dim value As String = control.Text
            Dim result As DialogResult = DisplayKeypad(value, Caption, IsPassword)
            If result = Windows.Forms.DialogResult.Cancel AndAlso Not IsClosedByLostFocus Then
                control.Text = value
            End If
            Return result
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Windows.Forms.DialogResult.Cancel
    End Function

    Private Sub txtDisplay_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisplay.TextChanged
        Dim currentSelection As Integer = m_CurrentSelectionStart

        If txtDisplay.SelectionStart <> 0 Then
            currentSelection = txtDisplay.SelectionStart
        End If

        ''fix bug check Invalid Character when user input LotID, Seq, Recipe, WaferFlow Name
        If IsCheckInvalidCharacter Then
            Dim beforeText As String = txtDisplay.Text
            Dim afterText As String = Utils.Clean_Invalid_Input(txtDisplay.Text)

            If Not beforeText.Equals(afterText) Then
                currentSelection -= 1
            End If
            beforeText = afterText

            If m_RemoveSpecialKey Then
                afterText = Regex.Replace(afterText, "[^a-zA-Z0-9\s_\-\.]+", "")
            End If

            If Not beforeText.Equals(afterText) Then
                currentSelection -= 1
            End If

            txtDisplay.Text = afterText
        End If
        If m_isremovespace Then
            txtDisplay.Text = Regex.Replace(txtDisplay.Text, " ", "")
        End If

        If IsEnableTextChange AndAlso textControl IsNot Nothing Then
            textControl.Text = txtDisplay.Text
        End If

        txtDisplay.SelectionStart = currentSelection
    End Sub

    Public Sub Enable_DisableBtnColon(ByVal isEnable As Boolean)
        isEnableBtnColon = isEnable
    End Sub

End Class