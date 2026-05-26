Imports AVPControls

Public Class CustomEmailMessage_Popup
    Private m_ListEmail As New ArrayList

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-08-06 </date>
    ''' </author>
    ''' <summary>
    ''' get and set list of email
    ''' </summary>
    Public Property ListEmail() As ArrayList
        Get
            Return m_ListEmail
        End Get
        Set(ByVal value As ArrayList)
            m_ListEmail = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-07-23 </date>
    ''' </author>
    ''' <summary>
    ''' send email to customer (address To) when click send button
    ''' </summary>
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            If Not String.IsNullOrEmpty(txtTo.Text) Then
                Dim isAnyEmailValid As Boolean = False
                Dim emailError As String = String.Empty
                Dim listEmail() As String = txtTo.Text.Split(";")

                If listEmail.Length = 0 Then
                    listEmail = txtTo.Text.Split(",")
                End If

                For i As Integer = 0 To listEmail.Length - 1
                    If Not AVPLib.SendEmail.Instance.ValidateEmail(listEmail(i)) Then
                        If String.IsNullOrEmpty(emailError) Then
                            emailError = listEmail(i)
                        End If
                    Else
                        isAnyEmailValid = True
                        Exit For
                    End If
                Next

                If isAnyEmailValid Then
                    AVPLib.SendEmail.Instance.Send(txtContent.Text, AVPLib.ConstEnum.TriggerType.NONE, txtSubject.Text, txtTo.Text)
                    Me.Close()
                Else
                    Utils.ShowAVPMessageBox("Email " & emailError & " is invalid", "Validate Email Address", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-08-06 </date>
    ''' </author>
    ''' <summary>
    ''' evant load of Custom Email Message form
    ''' </summary>
    Private Sub CustomEmailMessage_Popup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If ListEmail.Count > 0 Then
                For index As Integer = 0 To ListEmail.Count - 1
                    txtTo.Text = txtTo.Text & ListEmail(index) & "; "
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Pham </name>
    '''     <date> 2015-08-06 </date>
    ''' </author>
    ''' <summary>
    '''  ShowKeyPad use for all key pop up in email form
    ''' </summary>
    Private Sub ShowKeyPad(ByVal sender As Object, ByVal title As String, ByVal valueDefault As String, ByVal hidekey As Boolean)
        Try
            Dim textBox As TextBox = CType(sender, TextBox)
            Dim pad As New KeyPad
            Dim Value As String = valueDefault
            pad.Enable_DisableBtnAt = True
            If pad.DisplayKeypad(Value, title, hidekey) = Windows.Forms.DialogResult.OK Then
                If Not String.IsNullOrEmpty(Value) Then
                    textBox.Text = Value
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Pham </name>
    '''     <date> 2015-08-06 </date>
    ''' </author>
    ''' <summary>
    '''  ShowKeyPad use for email address
    ''' </summary>
    Private Sub txtTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTo.Click
        Try
            ShowKeyPad(sender, "Please Input Email Address", txtTo.Text, False)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Pham </name>
    '''     <date> 2015-08-06 </date>
    ''' </author>
    ''' <summary>
    '''  ShowKeyPad use for email subject
    ''' </summary>
    Private Sub txtSubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubject.Click
        Try
            ShowKeyPad(sender, "Please Input Email Subject", "", False)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Pham </name>
    '''     <date> 2015-08-06 </date>
    ''' </author>
    ''' <summary>
    '''  ShowKeyPad use for email content
    ''' </summary>
    Private Sub txtContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContent.Click
        Try
            ShowKeyPad(sender, "Please Input Email Content", "", False)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class