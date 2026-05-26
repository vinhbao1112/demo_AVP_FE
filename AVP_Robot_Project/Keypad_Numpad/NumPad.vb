Imports Microsoft.VisualBasic.CompilerServices
Imports System.Runtime.CompilerServices

Public Class NumPad

    Private m_lblActiveInput As Label = Nothing
    Private m_bIsMaxMinModified As Boolean = False
    Public ReadOnly Property IsMaxMinModified() As Boolean
        Get
            Return m_bIsMaxMinModified
        End Get
    End Property

    Private m_fNewMax As Double = 0
    Private m_fNewMin As Double = 0

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
    Private Sub btnBkSpc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBkSpc.Click
        lbErr.Text = String.Empty
        Dim num As Integer = Strings.Len(Me.m_lblActiveInput.Text)
        If (num > 0) Then
            Me.m_lblActiveInput.Text = Strings.Mid(Me.m_lblActiveInput.Text, 1, (num - 1))
        End If
        Me.PnlBorder.Focus()
    End Sub

    ' Handle Cancel button
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ' Verify new Max Min
        If fraMinMax.Visible = True Then
            Me.VerifyNewMaxMin()
        End If

        If Me.MinMaxChk Then
            txtNumVal.Text = Me.dCurrValue.ToString()
            If (Me.dCurrValue < Me.Min) Then
                lbErr.Text = "Current value is less than Min"
            ElseIf (Me.dCurrValue > Me.Max) Then
                lbErr.Text = "Current value is more than Max"
            Else
                Me.Copy = False
                Me.UserResponse = MsgBoxResult.Cancel
                Me.Close()
            End If
        Else
            Me.Copy = False
            Me.UserResponse = MsgBoxResult.Cancel
            Me.Close()
        End If
    End Sub

    ' Handle OK button
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If (Me.txtNumVal.Text.Length <> 0) Then
            If Not Versioned.IsNumeric(Me.txtNumVal.Text) Then
                lbErr.Text = "Input value is not a number"
            Else
                Dim dInputValue As Double = Conversions.ToDouble(Me.txtNumVal.Text)
                If (dInputValue = 0) Then
                    Me.txtNumVal.Text = "0"
                End If
                If (Me.txtNumVal.Text.IndexOf(".") = (Me.txtNumVal.Text.Length - 1)) Then
                    Dim startIndex As Integer = (Me.txtNumVal.Text.Length - 1)
                    Me.txtNumVal.Text = Me.txtNumVal.Text.Remove(startIndex, 1)
                End If

                ' Verify new Max Min
                If fraMinMax.Visible = True Then
                    Me.VerifyNewMaxMin()
                End If

                If Me.MinMaxChk Then
                    If (dInputValue < Me.Min) Then
                        lbErr.Text = "Input value is less than Min"
                    ElseIf (dInputValue > Me.Max) Then
                        lbErr.Text = "Input value is more than Max"
                    Else
                        Me.dCurrValue = dInputValue
                        Me.m_lblActiveInput.Text = Me.dCurrValue
                        Me.Copy = True
                        Me.UserResponse = MsgBoxResult.Ok
                        Me.Close()
                    End If
                Else
                    Me.dCurrValue = dInputValue
                    Me.m_lblActiveInput.Text = Me.dCurrValue
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
                If Me.dMinLimit <> m_fNewMin Or Me.dMaxLimit <> m_fNewMax Then
                    m_bIsMaxMinModified = True
                End If
            End If
        Catch ex As Exception
            m_bIsMaxMinModified = False
        End Try
    End Sub

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
        Me.m_lblActiveInput.Text = ""
        Me.PnlBorder.Focus()
    End Sub

    ' Handle "." button
    Private Sub btn_dot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_dot.Click
        lbErr.Text = String.Empty
        '#02/28/2011 
        '#Fix bug: -Keypad.  User cannot type .6, instead user have type 0.6
        '#Begin fix
        If String.IsNullOrEmpty(Me.m_lblActiveInput.Text) OrElse Me.ClearPreviousVals Then
            Me.m_lblActiveInput.Text = "0."
            ClearPreviousVals = False
        End If
        '#End fix.
        If Versioned.IsNumeric((Me.m_lblActiveInput.Text & ".")) Then
            Me.m_lblActiveInput.Text = (Me.m_lblActiveInput.Text & ".")
        End If
        Me.PnlBorder.Focus()
    End Sub

    ' Handle "-" button
    Private Sub btn_Neg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Neg.Click
        lbErr.Text = String.Empty
        Try
            If (Me.m_lblActiveInput.Text.Length <> 0) Then
                If (Me.m_lblActiveInput.Text.IndexOf("E") >= 0) Then
                    If (Me.m_lblActiveInput.Text.Substring((Me.m_lblActiveInput.Text.Length - 1)) <> "E") Then
                        If (Me.m_lblActiveInput.Text.Substring((Me.m_lblActiveInput.Text.Length - 1)) = "-") Then
                            Me.m_lblActiveInput.Text = Me.m_lblActiveInput.Text.Substring(0, (Me.m_lblActiveInput.Text.Length - 1))
                        End If
                    Else
                        Me.m_lblActiveInput.Text = (Me.m_lblActiveInput.Text & "-")
                    End If
                    Return
                End If
                If (Conversions.ToDouble(Me.m_lblActiveInput.Text) <> 0) Then
                    If (Conversions.ToString(Me.m_lblActiveInput.Text.Chars(0)) <> "-") Then
                        Me.m_lblActiveInput.Text = Me.m_lblActiveInput.Text.Insert(0, "-")
                    Else
                        Me.m_lblActiveInput.Text = Me.m_lblActiveInput.Text.Remove(0, 1)
                    End If
                End If
            End If
        Catch exception1 As Exception
            lbErr.Text = "Exception: " & exception1.Message
        End Try
        Me.PnlBorder.Focus()
    End Sub

    ' Handle input buttons
    Private Sub NumberButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_0.Click, btn_1.Click, btn_2.Click, btn_3.Click, btn_4.Click, btn_5.Click, _
                                                                                                       btn_6.Click, btn_7.Click, btn_8.Click, btn_9.Click
        lbErr.Text = String.Empty
        If ((Me.m_lblActiveInput.Text = "0") Or Me.ClearPreviousVals) Then
            Me.m_lblActiveInput.Text = DirectCast(sender, Button).Text
            Me.ClearPreviousVals = False
        Else
            If (Me.m_lblActiveInput.Text.Length > 22) Then
                Return
            End If
            Me.m_lblActiveInput.Text = (Me.m_lblActiveInput.Text & DirectCast(sender, Button).Text)
        End If
        Try
            Me.dbl = Conversions.ToDouble(Me.m_lblActiveInput.Text)
            Me.PnlBorder.Focus()
        Catch exception1 As Exception
            lbErr.Text = "Exception: " & exception1.Message
        End Try
    End Sub

    ' Start drag'n'drop
    Private Sub NumPadLabel_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NumPadLabel.MouseDown
        Me.doDrag = True
        Me.baseX = e.X
        Me.baseY = e.Y
    End Sub

    ' End ' drag'n'drop
    Private Sub NumPadLabel_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NumPadLabel.MouseUp
        Me.doDrag = False
        Me.PnlBorder.Focus()
    End Sub

    ' Being ' drag'n'drop
    Private Sub NumPadLabel_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NumPadLabel.MouseMove
        If Me.doDrag Then
            Dim VerticalChanged As Integer = (Me.baseX - e.X)
            Dim HorizonalChanged As Integer = (Me.baseY - e.Y)
            Me.Left = (Me.Left - VerticalChanged)
            Me.Top = (Me.Top - HorizonalChanged)
        End If
    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMn.Click, lblMin.Click, lblMx.Click, lblMax.Click
        Me.PnlBorder.Focus()
    End Sub

    Private Sub NumPad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    ' Handle input keys
    Private Sub NumPad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case CInt(e.KeyCode)
            Case 8
                Me.btnBkSpc_Click(RuntimeHelpers.GetObjectValue(sender), e)
                Exit Select
            Case 13
                Me.btnOK_Click(RuntimeHelpers.GetObjectValue(sender), e)
                Exit Select
            Case 27
                Me.btnCancel_Click(RuntimeHelpers.GetObjectValue(sender), e)
                Exit Select
            Case 46
                Me.btnClear_Click(RuntimeHelpers.GetObjectValue(sender), e)
                Exit Select
            Case 48, 96
                Me.NumberButton_Click(Me.btn_0, e)
                Exit Select
            Case 49, 97
                Me.NumberButton_Click(Me.btn_1, e)
                Exit Select
            Case 50, 98
                Me.NumberButton_Click(Me.btn_2, e)
                Exit Select
            Case 51, 99
                Me.NumberButton_Click(Me.btn_3, e)
                Exit Select
            Case 52, 100
                Me.NumberButton_Click(Me.btn_4, e)
                Exit Select
            Case 53, 101
                Me.NumberButton_Click(Me.btn_5, e)
                Exit Select
            Case 54, 102
                Me.NumberButton_Click(Me.btn_6, e)
                Exit Select
            Case 55, 103
                Me.NumberButton_Click(Me.btn_7, e)
                Exit Select
            Case 56, 104
                Me.NumberButton_Click(Me.btn_8, e)
                Exit Select
            Case 57, 105
                Me.NumberButton_Click(Me.btn_9, e)
                Exit Select
            Case 110, 190
                If btn_dot.Enabled Then
                    Me.btn_dot_Click(RuntimeHelpers.GetObjectValue(sender), e)
                End If
                Exit Select
        End Select
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.doDrag = False
        Me.MinMaxChk = True
        Me.ClearPreviousVals = False
        Me.UserResponse = MsgBoxResult.Cancel
        m_lblActiveInput = Me.txtNumVal
    End Sub

    Public Sub New(ByVal IsIntegerInput As Boolean)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.doDrag = False
        Me.MinMaxChk = True
        Me.ClearPreviousVals = False
        Me.UserResponse = MsgBoxResult.Cancel
        m_lblActiveInput = Me.txtNumVal
        If IsIntegerInput Then
            btn_dot.Enabled = False
            btn_Neg.Enabled = False
            btn_exp.Enabled = False
        End If
    End Sub

    Public Overloads Function GetUserInput(ByRef numval As String, ByVal LPos As Integer, ByVal TPos As Integer, ByVal Min As Double, ByVal Max As Double, Optional ByVal Title As String = "", Optional ByVal Unit As Short = 0, Optional ByVal MinMaxCheck As Boolean = True, Optional ByVal AllowDecimalValues As Boolean = True) As MsgBoxResult
        m_bIsMaxMinModified = False
        If ((LPos = -1) Or (TPos = -1)) Then
            Me.StartPosition = FormStartPosition.CenterScreen
        Else
            Me.StartPosition = FormStartPosition.Manual
            Dim point As New Point(LPos, TPos)
            Me.Location = point
        End If
        Me.ResizeRedraw = True
        Me.Size = Me.PnlBorder.Size
        Me.btn_dot.Enabled = AllowDecimalValues
        If (numval <> Nothing AndAlso numval.Length <> 0) Then
            If Not AllowDecimalValues Then
                numval = Conversions.ToInteger(CStr(numval)).ToString
            End If
            Me.dCurrValue = Conversions.ToDouble(CStr(numval))
        End If
        Me.NumPadLabel.Text = Title
        Me.MinMaxChk = MinMaxCheck
        If Me.MinMaxChk Then
            Me.dMinLimit = Min
            Me.dMaxLimit = Max
            Me.lblMax.Text = Conversions.ToString(Me.dMaxLimit)
            Me.lblMin.Text = Conversions.ToString(Me.dMinLimit)
        Else
            Me.fraMinMax.Visible = False
        End If
        Me.ClearPreviousVals = True
        Me.Copy = True
        Me.m_lblActiveInput.Text = numval.ToUpper()
        Me.ShowDialog()
        If Me.Copy Then
            numval = Me.txtNumVal.Text.ToUpper()
        End If
        Return Me.UserResponse
    End Function

    Private Sub NumPad_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
        End If
    End Sub

    Private Sub btn_exp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exp.Click
        lbErr.Text = String.Empty
        If (Me.m_lblActiveInput.Text.Length <> 0) Then
            If (Me.m_lblActiveInput.Text.IndexOf("E") >= 0 Or Me.m_lblActiveInput.Text.IndexOf("e") >= 0) Then
                Return
            End If
            Me.m_lblActiveInput.Text = (Me.m_lblActiveInput.Text & "E")
        End If
        Me.PnlBorder.Focus()
    End Sub

    Private Sub txtVal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumVal.Click, lblMax.Click, lblMin.Click
        txtNumVal.BackColor = Color.Gainsboro
        lblMax.BackColor = Color.Gainsboro
        lblMin.BackColor = Color.Gainsboro
        m_lblActiveInput = sender
        m_lblActiveInput.BackColor = Color.White
    End Sub
End Class