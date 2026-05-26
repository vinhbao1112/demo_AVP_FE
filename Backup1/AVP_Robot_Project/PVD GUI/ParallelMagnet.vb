Imports AVP_Robot_Project.ConstantAndEnum
Public Class ParallelMagnet
    Private m_blnIsOnline As Boolean = False
#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnStatus.Enabled = Not m_blnIsOnline
            txtCurrentRight.Enabled = Not m_blnIsOnline
            txtDutyRight.Enabled = Not m_blnIsOnline
            txtFrequencyRight.Enabled = Not m_blnIsOnline
        End Set
    End Property
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbCurrent As New StatusTextBox(Me.txtCurrent)
            Dim stbCurrentRight As New StatusTextBox(Me.txtCurrentRight)
            Dim stbDutyRight As New StatusTextBox(Me.txtDutyRight)
            Dim stbFrequencyRight As New StatusTextBox(Me.txtFrequencyRight)
            Dim stbVoltage As New StatusTextBox(Me.txtVoltage)
            Dim sibStatus As New StatusIGCGButton(Me.btnStatus)
            
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbCurrent)
            m_stoStatusObject.AddChild(stbCurrentRight)
            m_stoStatusObject.AddChild(stbDutyRight)
            m_stoStatusObject.AddChild(stbFrequencyRight)
            m_stoStatusObject.AddChild(stbVoltage)
            m_stoStatusObject.AddChild(sibStatus)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub StartProcessing() ''reset editbox to empty
        Me.txtCurrentRight.Text = String.Empty
        Me.txtDutyRight.Text = String.Empty
        Me.txtFrequencyRight.Text = String.Empty
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-15</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub txtCurrentRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                         Handles txtCurrentRight.Click, txtDutyRight.Click, txtFrequencyRight.Click
        PVDSupport.TextboxClick(sender, e, Me.Parent, m_stoStatusObject)
    End Sub
    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        Dim strLogMessage As String = String.Empty

        If CType(sender, ButtonIGCGControl).Status = DisplayStatus.On Then
            strLogMessage = "Turn Off Parallel Magnet"
        Else
            strLogMessage = "Turn On Parallel Magnet"
        End If
        PVDSupport.CommonButtonClick(strLogMessage, sender, Me.Parent, m_stoStatusObject)
    End Sub
#End Region

End Class
