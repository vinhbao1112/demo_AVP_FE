Public Class SL_ElectromagnetPS

#Region "Protected method"
    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2018-07-21</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbcStatus As New StatusIGCGButton(Me.Header)
            Dim stbSourceEMVoltageRB As New SL_StatusTextBox(txtSourceEMVolt)
            Dim stbSourceEMCurrentRB As New SL_StatusTextBox(txtSourceEMCurrent)
            Dim stbSourceEMCurrentSP As New SL_StatusTextBox(txtSourceEMCurrentRight)

            m_stoStatusObject.AddChild(sbcStatus)
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbSourceEMVoltageRB)
            m_stoStatusObject.AddChild(stbSourceEMCurrentRB)
            m_stoStatusObject.AddChild(stbSourceEMCurrentSP)

            txtSourceEMVolt.ParentStatusObj = m_stoStatusObject
            txtSourceEMCurrent.ParentStatusObj = m_stoStatusObject
            txtSourceEMCurrentRight.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtSourceEMVoltRight.Enabled = Not (m_blnIsOnline)
            txtSourceEMCurrentRight.Enabled = Not (m_blnIsOnline)
        End Set
    End Property

    Private Sub SourceEMCommunicationStatus_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SourceEMStatus.StatusChange
        Me.Header.Status = IIf(SourceEMStatus.Status = DisplayStatus.On, ButtonIGCGControl.DisplayStatus.On, ButtonIGCGControl.DisplayStatus.Off)
    End Sub
End Class
