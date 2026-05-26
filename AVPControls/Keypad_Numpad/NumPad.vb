Imports Microsoft.VisualBasic.CompilerServices
Imports System.Runtime.CompilerServices

Public Class NumPad

    Private _activeInputControl As TextBox
    Private _isMaxMinModified As Boolean
    Private _isFirstFocusedInput As Boolean
    Private _isAllowApplyMaxMin As Boolean

    Private MinMaxChk As Boolean
    Private Copy As Boolean
    Private dCurrValue As Double
    Private dMaxLimit As Double
    Private dMinLimit As Double
    Private UserResponse As MsgBoxResult
    Private m_blnEnable_EditMinValue As Boolean = True
    Private m_blnEnable_EditMaxValue As Boolean = True
    Private oldMaxValue As String
    Private oldMinValue As String

    Public ReadOnly Property IsMaxMinModified() As Boolean
        Get
            Return _isMaxMinModified
        End Get
    End Property

    Private m_fNewMax As Double
    Private m_fNewMin As Double

    Public ReadOnly Property NewMax() As Double
        Get
            Return m_fNewMax
        End Get
    End Property

    Public ReadOnly Property NewMin() As Double
        Get
            Return m_fNewMin
        End Get
    End Property

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        Return ((((keyData = Keys.Return) Or (keyData = Keys.Space)) AndAlso TypeOf Control.FromChildHandle(msg.HWnd) Is Button) OrElse MyBase.ProcessCmdKey((msg), keyData))
    End Function


    ' Handle "<<" button
    Private Sub btnBkSpc_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnBkSpc.Click
        lbErr.Text = String.Empty
        Try
            Dim num As Integer = Strings.Len(Me._activeInputControl.Text)
            If (num > 0) Then
                Dim startIndex As Integer = _activeInputControl.SelectionStart
                Dim deleteStartIndex As Integer = startIndex - 1
                If deleteStartIndex < 0 Then
                    deleteStartIndex = 0
                End If
                Dim lenDelete As Integer = 1

                Dim expPositionIndex As Integer = _activeInputControl.Text.IndexOf("E")
                If expPositionIndex >= 0 AndAlso expPositionIndex = startIndex - 1 Then
                    lenDelete = _activeInputControl.Text.Length - expPositionIndex

                ElseIf _activeInputControl.SelectionLength > 0 Then
                    deleteStartIndex = startIndex
                    lenDelete = _activeInputControl.SelectionLength
                    If _activeInputControl.SelectedText.Contains("E") Then
                        lenDelete = _activeInputControl.Text.Length - deleteStartIndex
                    End If
                End If

                _activeInputControl.Text = _activeInputControl.Text.Remove(deleteStartIndex, lenDelete)
                _activeInputControl.SelectionStart = deleteStartIndex

                ' Clear if text is not a valid number.
                If _activeInputControl.Text.StartsWith("E") _
                OrElse _activeInputControl.Text.StartsWith("-E") _
                OrElse _activeInputControl.Text = "." Then
                    _activeInputControl.Text = ""
                End If

            End If
        Catch ex As Exception
            lbErr.Text = "Error: " & ex.ToString()
        End Try
        Me._activeInputControl.Focus()
    End Sub

    ' Handle Cancel button
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ' Verify new Max Min
        If fraMinMax.Visible = True Then
            Me.VerifyNewMaxMin()
        End If

        Me.Copy = False
        Me.UserResponse = MsgBoxResult.Cancel
        Me.Close()
    End Sub

    ' Handle OK button
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If (Me.txtDisplay.Text.Length <> 0) Then
            Dim dInputValue As Double
            If Not Double.TryParse(Me.txtDisplay.Text, dInputValue) Then
                lbErr.Text = "Input value is not a number"
            Else
                'Dim dInputValue As Double = Conversions.ToDouble(Me.txtDisplay.Text)
                If (dInputValue = 0) Then
                    Me.txtDisplay.Text = "0"
                End If
                If (Me.txtDisplay.Text.IndexOf(".") = (Me.txtDisplay.Text.Length - 1)) Then
                    Dim startIndex As Integer = (Me.txtDisplay.Text.Length - 1)
                    Me.txtDisplay.Text = Me.txtDisplay.Text.Remove(startIndex, 1)
                End If

                ' Verify new Max Min
                If fraMinMax.Visible = True Then
                    Me.VerifyNewMaxMin()
                End If

                If Me.MinMaxChk AndAlso ((dInputValue < Me.Min) OrElse (dInputValue > Me.Max)) Then
                    If (dInputValue < Me.Min) Then
                        lbErr.Text = "Input value is less than Min"
                    ElseIf (dInputValue > Me.Max) Then
                        lbErr.Text = "Input value is more than Max"
                    End If
                Else
                    Me.dCurrValue = dInputValue
                    Me.txtDisplay.Text = Me.dCurrValue.ToString()
                    Me.Copy = True
                    Me.UserResponse = MsgBoxResult.Ok
                    Me.Close()
                End If
            End If
        Else
            Me.Copy = False
            lbErr.Text = "Please input the number"
        End If
    End Sub

    ' Verify the new Max Min and check if they are modified or not
    Private Sub VerifyNewMaxMin()
        Try
            If IsNumeric(Me.lblMax.Text) AndAlso IsNumeric(Me.lblMin.Text) Then
                m_fNewMax = Conversions.ToDouble(Me.lblMax.Text)
                m_fNewMin = Conversions.ToDouble(Me.lblMin.Text)
                If (Me.dMinLimit <> m_fNewMin Or Me.dMaxLimit <> m_fNewMax) AndAlso _isAllowApplyMaxMin Then
                    _isMaxMinModified = True
                End If
            End If
        Catch ex As Exception
            _isMaxMinModified = False
        End Try
    End Sub

    ''This property is used for Enable - Disable Max Min Panel in NumPad Editor
    ''Default value is True -> always enable
    ''Truc Le
    Public Property Enable_EditMaxValue() As Boolean
        Get
            Return m_blnEnable_EditMaxValue
        End Get
        Set(ByVal value As Boolean)
            m_blnEnable_EditMaxValue = value
            lblMax.Enabled = value
        End Set
    End Property

    ''This property is used for Enable - Disable Max Min Panel in NumPad Editor
    ''Default value is True -> always enable
    ''Truc Le
    Public Property Enable_EditMinValue() As Boolean
        Get
            Return m_blnEnable_EditMinValue
        End Get
        Set(ByVal value As Boolean)
            m_blnEnable_EditMinValue = value
            lblMin.Enabled = value
        End Set
    End Property

    Private ReadOnly Property Min() As Double
        Get
            If Me.IsMaxMinModified Then
                Return Me.NewMin
            Else
                Return Me.dMinLimit
            End If
        End Get
    End Property

    Private ReadOnly Property Max() As Double
        Get
            If Me.IsMaxMinModified Then
                Return Me.NewMax
            Else
                Return Me.dMaxLimit
            End If
        End Get
    End Property

    ' Handle Clear button
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lbErr.Text = String.Empty
        Me._activeInputControl.Text = ""
        Me._activeInputControl.Focus()
    End Sub

    ' Handle "." button
    Private Sub btn_dot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_dot.Click
        lbErr.Text = String.Empty
        Try
            Dim startIndex As Integer = _activeInputControl.SelectionStart
            If Not _activeInputControl.Text.Contains(".") OrElse _activeInputControl.SelectedText.Contains(".") Then
                If _activeInputControl.SelectionLength > 0 Then
                    _activeInputControl.Text = _activeInputControl.Text.Remove(startIndex, _activeInputControl.SelectionLength)

                End If

                '#02/28/2011 
                '#Fix bug: -Keypad.  User cannot type .6, instead user have type 0.6
                '#Begin fix
                If String.IsNullOrEmpty(Me._activeInputControl.Text) OrElse Me._activeInputControl.Text = "-" Then
                    _activeInputControl.Text += "0."
                    _activeInputControl.SelectionStart = _activeInputControl.Text.Length

                Else
                    If Not _activeInputControl.Text.Contains(".") Then
                        If startIndex > 0 AndAlso (_activeInputControl.Text.IndexOf("E") > startIndex OrElse _activeInputControl.Text.IndexOf("E") < 0) Then
                            _activeInputControl.Text = _activeInputControl.Text.Insert(startIndex, ".")
                            startIndex += 1

                        ElseIf startIndex = 0 Then
                            _activeInputControl.Text = _activeInputControl.Text.Insert(startIndex, "0.")
                            startIndex += 2

                        End If

                        _activeInputControl.SelectionStart = startIndex
                    End If
                End If
                '#End fix.
            End If
        Catch ex As Exception
            lbErr.Text = "Error: " & ex.ToString()
        End Try
        _activeInputControl.Focus()
    End Sub

    ' Handle "-" button
    Private Sub btn_Neg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Neg.Click
        lbErr.Text = String.Empty
        Try
            If _activeInputControl.Text = "-" Then
                _activeInputControl.Text = ""
                Exit Try
            End If

            If (Me._activeInputControl.Text.Length <> 0) Then
                Dim eIndex As Integer = _activeInputControl.Text.IndexOf("E")
                If eIndex >= 0 Then
                    If eIndex + 1 = _activeInputControl.Text.Length Then
                        _activeInputControl.Text += "-"

                    ElseIf eIndex + 1 < _activeInputControl.Text.Length AndAlso (Me._activeInputControl.Text.Substring(eIndex + 1, 1) <> "-") Then
                        Me._activeInputControl.Text = Me._activeInputControl.Text.Insert(eIndex + 1, "-")

                    Else
                        Me._activeInputControl.Text = Me._activeInputControl.Text.Remove(eIndex + 1, 1)

                    End If

                    Exit Try
                End If
                If (Conversions.ToDouble(Me._activeInputControl.Text) <> 0) Then
                    If (Conversions.ToString(Me._activeInputControl.Text.Chars(0)) <> "-") Then
                        Me._activeInputControl.Text = Me._activeInputControl.Text.Insert(0, "-")
                    Else
                        Me._activeInputControl.Text = Me._activeInputControl.Text.Remove(0, 1)
                    End If
                End If
            Else
                _activeInputControl.Text = "-"
            End If
        Catch ex As Exception
            lbErr.Text = "Error: " & ex.ToString()
        End Try
        _activeInputControl.SelectionStart = _activeInputControl.Text.Length
        _activeInputControl.Focus()
    End Sub

    ' Handle input buttons
    Private Sub NumberButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_0.Click, btn_1.Click, btn_2.Click, btn_3.Click, btn_4.Click, btn_5.Click, _
                                                                                                       btn_6.Click, btn_7.Click, btn_8.Click, btn_9.Click

        Try
            Dim btnSender As Button = DirectCast(sender, Button)
            lbErr.Text = String.Empty
            If (Me._activeInputControl.Text.Length > 22) Then
                Exit Try
            End If

            Dim textDisplay As String = _activeInputControl.Text
            Dim startIndex As Integer = _activeInputControl.SelectionStart
            If _activeInputControl.SelectionLength > 0 Then
                textDisplay = textDisplay.Remove(startIndex, _activeInputControl.SelectionLength)
            End If

            If String.IsNullOrEmpty(textDisplay) OrElse textDisplay = "0" OrElse textDisplay = "-0" Then
                If textDisplay.StartsWith("-") Then
                    textDisplay = "-" & btnSender.Text
                Else
                    textDisplay = btnSender.Text
                End If
            Else
                textDisplay = textDisplay.Insert(startIndex, btnSender.Text)
            End If

            _activeInputControl.Text = textDisplay
            _activeInputControl.SelectionStart = startIndex + 1
            _activeInputControl.Focus()
        Catch ex As Exception
            lbErr.Text = "Error: " & ex.ToString()
        End Try
    End Sub

    ' Handle input keys
    Private Sub NumPad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case CInt(e.KeyCode)
            Case 8
                Me.btnBkSpc.PerformClick()

            Case 13
                Me.btnOK.PerformClick()

            Case 27
                Me.btnCancel.PerformClick()

            Case 46
                Me.btnClear.PerformClick()

            Case 48, 96
                Me.btn_0.PerformClick()

            Case 49, 97
                Me.btn_1.PerformClick()

            Case 50, 98
                Me.btn_2.PerformClick()

            Case 51, 99
                Me.btn_3.PerformClick()

            Case 52, 100
                Me.btn_4.PerformClick()

            Case 53, 101
                Me.btn_5.PerformClick()

            Case 54, 102
                Me.btn_6.PerformClick()

            Case 55, 103
                Me.btn_7.PerformClick()

            Case 56, 104
                Me.btn_8.PerformClick()

            Case 57, 105
                Me.btn_9.PerformClick()

            Case 110, 190
                If btn_dot.Enabled Then
                    Me.btn_dot.PerformClick()
                End If

            Case 109
                Me.btn_Neg.PerformClick()

            Case AscW("e"c), AscW("E"c)
                Me.btn_exp.PerformClick()

        End Select

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.MinMaxChk = True
        Me.UserResponse = MsgBoxResult.Cancel
        _activeInputControl = Me.txtDisplay
    End Sub

    Public Sub New(ByVal IsIntegerInput As Boolean)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.MinMaxChk = True
        Me.UserResponse = MsgBoxResult.Cancel
        _activeInputControl = Me.txtDisplay
        If IsIntegerInput Then
            btn_dot.Enabled = False
            btn_Neg.Enabled = False
            btn_exp.Enabled = False
        End If
    End Sub

    Public Overloads Function GetUserInput(ByRef numval As String, ByVal LPos As Integer, ByVal TPos As Integer, ByVal Min As Double, ByVal Max As Double, Optional ByVal Title As String = "", Optional ByVal Unit As Short = 0, Optional ByVal MinMaxCheck As Boolean = True, Optional ByVal AllowDecimalValues As Boolean = True) As MsgBoxResult
        _isMaxMinModified = False
        _isAllowApplyMaxMin = False
        oldMaxValue = Max
        oldMinValue = Min

        If ((LPos = -1) Or (TPos = -1)) Then
            Me.StartPosition = FormStartPosition.CenterScreen
        Else
            Me.StartPosition = FormStartPosition.Manual
            Dim point As New Point(LPos, TPos)
            Me.Location = point
        End If
        Me.ResizeRedraw = True
        Me.btn_dot.Enabled = AllowDecimalValues
        If (numval <> Nothing AndAlso numval.Length <> 0) Then
            If Not AllowDecimalValues Then
                numval = Conversions.ToInteger(CStr(numval)).ToString
            End If
            Me.dCurrValue = Conversions.ToDouble(CStr(numval))
        End If
        Me.Text = Title
        Me.MinMaxChk = MinMaxCheck
        If Me.MinMaxChk Then
            Me.dMinLimit = Min
            Me.dMaxLimit = Max
            Me.lblMax.Text = Conversions.ToString(Me.dMaxLimit)
            Me.lblMin.Text = Conversions.ToString(Me.dMinLimit)
            Me.Height = 555
        Else
            Me.fraMinMax.Visible = False
            Me.Height = 465
        End If
        Me.Copy = True
        Me._activeInputControl.Text = numval.ToUpper()
        Me.ShowDialog()
        If Me.Copy Then
            numval = Me.txtDisplay.Text.ToUpper()
        End If
        Return Me.UserResponse
    End Function

    Private Sub btn_exp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exp.Click
        lbErr.Text = String.Empty
        If (Me._activeInputControl.Text.Length <> 0) Then
            If (Me._activeInputControl.Text.IndexOf("E") >= 0 OrElse Me._activeInputControl.Text.IndexOf("e") >= 0) Then
                Return
            End If
            Me._activeInputControl.Text = (Me._activeInputControl.Text & "E")

        End If
        _activeInputControl.SelectionStart = _activeInputControl.Text.Length
        _activeInputControl.Focus()
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-08</date>
    ''' <summary>
    ''' Select all text when clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub InputControl_Click(ByVal sender As Object, ByVal e As MouseEventArgs) Handles lblMax.MouseUp, lblMin.MouseUp, txtDisplay.MouseUp
        If _isFirstFocusedInput Then
            CType(sender, TextBox).SelectAll()
            _isFirstFocusedInput = False
        End If
    End Sub

    Private Sub InputControl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMin.Enter, lblMax.Enter, txtDisplay.Enter
        txtDisplay.BackColor = Color.Gainsboro
        lblMax.BackColor = Color.Gainsboro
        lblMin.BackColor = Color.Gainsboro
        Dim clickedControl As TextBox = DirectCast(sender, TextBox)
        If Not _activeInputControl Is clickedControl Then
            Dim errorMessage As String = String.Empty
            ' Restore Min, Max value if empty.
            If _activeInputControl Is lblMax OrElse _activeInputControl Is lblMin Then
                If String.IsNullOrEmpty(lblMax.Text) Then
                    lblMax.Text = Me.dMaxLimit.ToString
                ElseIf String.IsNullOrEmpty(lblMin.Text) Then
                    lblMin.Text = Me.dMinLimit.ToString
                Else
                    Dim max As Double
                    Dim min As Double
                    If Double.TryParse(lblMax.Text, max) AndAlso Double.TryParse(lblMin.Text, min) Then
                        If max < min Then
                            lblMax.Text = Me.dMaxLimit.ToString
                            lblMin.Text = Me.dMinLimit.ToString
                            errorMessage = "Min, Max is not valid."
                        End If
                    End If
                End If
            End If

            _activeInputControl = clickedControl
            _activeInputControl.SelectAll()
            _isFirstFocusedInput = True

            If Not String.IsNullOrEmpty(errorMessage) Then
                lbErr.Text = errorMessage
            End If
        End If

        _activeInputControl.BackColor = Color.White

    End Sub

    ''' <author> Duc Pham </author>
    ''' <date> 2019-08-20 </date>
    ''' <summary>
    ''' Event click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEditApplyMaxMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditApplyMaxMin.Click, btnCancelMaxMin.Click
        Try
            Dim action As String = CType(sender, Button).Text

            If action = "Edit" Then
                lblMax.Enabled = True
                lblMin.Enabled = True

                btnCancelMaxMin.Visible = True
                btnEditApplyMaxMin.Text = "Apply"
                btnEditApplyMaxMin.Location = New Point(187, 51)

            Else
                If action = "Cancel" Then
                    _isAllowApplyMaxMin = False
                    lblMax.Text = oldMaxValue
                    lblMin.Text = oldMinValue

                ElseIf action = "Apply" Then
                    _isAllowApplyMaxMin = True
                End If

                lblMax.Enabled = False
                lblMin.Enabled = False
                btnCancelMaxMin.Visible = False
                btnEditApplyMaxMin.Text = "Edit"
                btnEditApplyMaxMin.Location = btnCancelMaxMin.Location
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub


    ''' <author> Duc Pham </author>
    ''' <date> 2019-08-20 </date>
    ''' <summary>
    ''' Event Form Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NumPad_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            ' Verify new Max Min
            If fraMinMax.Visible = True Then
                Me.VerifyNewMaxMin()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub
End Class