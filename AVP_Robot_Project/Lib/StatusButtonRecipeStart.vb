Imports System.Windows.Forms

Public Class StatusButtonRecipeStartStop
    Inherits AVPControls.StatusObject
#Region "Class Constants & Variables"
    Private m_btnStart As Button
    Private m_btnPause As Button
#End Region


#Region "Properties"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-03-03</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the text box that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedButton() As Button
        Get
            Return m_btnStart
        End Get
        Set(ByVal value As Button)
            m_btnStart = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-03</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the text box that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PauseButton() As Button
        Get
            Return m_btnPause
        End Get
        Set(ByVal value As Button)
            m_btnPause = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-03</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with text box that will be managed by this object
    ''' </summary>
    ''' <param name="btnButtonStart"></param>
    ''' <param name="btnButtonPause"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal btnButtonStart As Button, ByVal btnButtonPause As Button)
        m_btnStart = btnButtonStart
        m_btnPause = btnButtonPause
        Me.Name = m_btnStart.Name
    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Dat Do </name>
    '''     <date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)

            If (Value = "Off") Then
                Me.m_btnStart.Text = "Start"
                Me.m_btnStart.Enabled = True
                Me.m_btnPause.Text = "Pause"
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''     <date> 2009-03-03</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
#End Region
End Class
