Imports AVPControls

Public Class SerialCommandControl
    Private m_blnIsOnline As Boolean = False

#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            cboSerialCommand.Enabled = Not m_blnIsOnline
            txtCommand.Enabled = Not m_blnIsOnline
            btnSend.Enabled = Not m_blnIsOnline
        End Set
    End Property
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Dim stbResponse As New StatusTextBox(txtResponse)

        m_stoStatusObject.Name = Me.Name
        m_stoStatusObject.AddChild(stbResponse)
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle form load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SerialCommandControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not DesignMode) Then
                cboSerialCommand.DataSource = ContainerData.GetComboItem("SerialCommand")
                cboSerialCommand.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle event that user click on send button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        AVPLib.Log.guiLogger.Info("Enter btnSend_Click")
        Dim strMessageText As String = String.Empty
        strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("SendSerialCommandRobotCassettes"), cboSerialCommand.Text)
        'If (Utils.ShowAVPMessageBox(strMessageText, ConstantAndEnum.SEND_SERIALCOMMAND, MessageBoxIcon.Question) = DialogResult.OK) Then
        If (txtCommand.Text.Length() > 0) Then
            txtResponse.Text = ""
            '#07/07/2011 
            '#-	“00,”  should be add on the background when sending command to cassette instead of showing “00,” on the virtual keypad
            '#Begin fix:
            Dim strPreValue As String = String.Empty
            If cboSerialCommand.SelectedItem.ToString() = "LLA" Then
                strPreValue = "00,"
            End If
            '#End fix
            Dim strValue As String = cboSerialCommand.Text + "." + strPreValue + txtCommand.Text
            m_stoStatusObject.RequestStatus(btnSend.Name, strValue)
            Me.btnSend.Enabled = False
            Utils.LogUserEvent("Send Serial Command: " & strValue, "TM Screen")
        End If
        'End If
        AVPLib.Log.guiLogger.Info("Leave btnSend_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-02</date>
    ''' </author>
    ''' <summary>
    ''' txtResponse_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtResponse_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResponse.TextChanged
        AVPLib.Log.guiLogger.Info("Enter txtResponse_TextChanged")
        Try
            If Me.txtResponse.Text.Length > 0 Then
                Me.btnSend.Enabled = True AndAlso Not m_blnIsOnline
            Else
                Me.btnSend.Enabled = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtStatus_TextChanged")
    End Sub
#End Region

    Private Sub txtCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCommand.Click
        Dim pad As New KeyPad
        Dim Value As String = txtCommand.Text
        'Fix Need to auto add “00,” so that user only have to type “R,ER” to communication with cassettes.
        'Begin
        'If cboSerialCommand.SelectedItem.ToString() = "CASSETTE 1" Or cboSerialCommand.SelectedItem.ToString() = "CASSETTE 2" Then
        '    Value = "00,"
        'End If
        'End
        If pad.DisplayKeypad(Value, "Please input the serial command", False) = DialogResult.OK Then
            txtCommand.Text = Value
        End If
    End Sub

    '"AVP.  TM Serial command tab.   Cassette 2 is available to send command when LLB is not installed. 
    ' After sending a serial command to cassette 2 (which is not present),  the Send button remain disable and 
    'therefore we cannot send any serial command to ot" 
    ' Solution: disable Send button when cassette is uninstalled
    'Begin
    Private Sub cboSerialCommand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSerialCommand.SelectedIndexChanged
        Try
            Me.btnSend.Enabled = True AndAlso Not m_blnIsOnline
        Catch ex As Exception

        End Try
    End Sub
    'End
End Class
