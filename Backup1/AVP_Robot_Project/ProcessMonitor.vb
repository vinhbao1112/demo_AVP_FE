Public Class ProcessMonitor
#Region "Properties"
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbProcessStep As New StatusTextBox(Me.txtProcessStep)
            Dim stbTotalStep As New StatusTextBox(Me.txtTotalStep)
            Dim stbProcessTime As New StatusTextBox(Me.txtRemainingTime)
            Dim stbElapsedTime As New StatusTextBox(Me.txtElapsedTime)

            Dim stbRecipe As New StatusTextBox(Me.txtRecipe)
            Dim stbStatus As New StatusTextBox(Me.txtStatus)
            Dim stbStepTime As New StatusTextBox(Me.txtStepTime)
            Dim stbWaferID As New StatusTextBox(Me.txtWaferID) 'Note: The wafer ID will be retrieve from ROBOT and CASSETTES 

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbProcessStep)
            m_stoStatusObject.AddChild(stbTotalStep)
            m_stoStatusObject.AddChild(stbProcessTime)
            m_stoStatusObject.AddChild(stbRecipe)
            m_stoStatusObject.AddChild(stbStatus)
            m_stoStatusObject.AddChild(stbStepTime)
            m_stoStatusObject.AddChild(stbWaferID)
            m_stoStatusObject.AddChild(stbElapsedTime)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19 </date>
    ''' </author>
    ''' <summary>
    ''' Handling control loading event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProcessMonitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
#End Region

End Class
