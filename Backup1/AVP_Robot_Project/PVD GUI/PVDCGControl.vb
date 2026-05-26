Public Class PVDCGControl
#Region "Properties"
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbInformation As New StatusTextBox(Me.txtInfor)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbInformation)
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
    ''' Handling control loading event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CGControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
#End Region
End Class
