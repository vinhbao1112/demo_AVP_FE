Imports System.Windows.Forms
Public Class StatusToolStripMenuItemChamber3
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_mnuToolStripMenuItem As ToolStripMenuItem
#End Region


#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the menu item that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedToolStripMenuItem() As ToolStripMenuItem
        Get
            Return m_mnuToolStripMenuItem
        End Get
        Set(ByVal value As ToolStripMenuItem)
            m_mnuToolStripMenuItem = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-18</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with menu item that will be managed by this object
    ''' </summary>
    ''' <param name="mnuToolStripMenuItem"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal mnuToolStripMenuItem As ToolStripMenuItem)
        m_mnuToolStripMenuItem = mnuToolStripMenuItem
        Me.Name = m_mnuToolStripMenuItem.Name
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

            If m_mnuToolStripMenuItem.Enabled = False And Value = "On" Then
                m_mnuToolStripMenuItem.Enabled = True
            ElseIf m_mnuToolStripMenuItem.Enabled = True And Value <> "On" Then
                m_mnuToolStripMenuItem.Enabled = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''     <date> 2008-09-20</date>
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
    ''' <author>
    '''     	<name> Cao Anh Kiet </name>
    '''     	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub

#End Region

End Class
