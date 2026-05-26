Public Class Logout
#Region "Class Constants & Variables"
    Public Enum LogoutResult
        [Canel] = 0
        [Ok] = 1
        [Quit] = 2
    End Enum
    Private m_enmLogoutResult As LogoutResult = LogoutResult.Canel

#End Region

#Region "properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-10-13</date>
    ''' </author>
    ''' <summary>
    ''' Get result of logout diaglog
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Result() As LogoutResult
        Get
            Return m_enmLogoutResult
        End Get
        Set(ByVal value As LogoutResult)
            m_enmLogoutResult = value
        End Set
    End Property
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-10-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle form load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Logout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblMessageText.Text = AVPLib.ContainerData.GetMessageText("LogoutMessage")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-10-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on button OK
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        m_enmLogoutResult = LogoutResult.Ok
        Me.Close()
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-10-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on button Cancel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_enmLogoutResult = LogoutResult.Canel
        Me.Close()
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-10-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on button Quit
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        m_enmLogoutResult = LogoutResult.Quit
        Me.Close()
    End Sub
#End Region

End Class