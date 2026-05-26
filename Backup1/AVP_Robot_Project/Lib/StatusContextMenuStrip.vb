Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Public Class StatusContextMenuStrip
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_ctxMenuStrip As ContextMenuStrip
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
    Public Property ManagedContextMenuStrip() As ContextMenuStrip
        Get
            Return m_ctxMenuStrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            m_ctxMenuStrip = value
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
    ''' <param name="ctxMenuStrip"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ctxMenuStrip As ContextMenuStrip)
        Try
            m_ctxMenuStrip = ctxMenuStrip
            Me.Name = m_ctxMenuStrip.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

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
            If (Value.CompareTo(START) = 0) Then 'Abort mode or finish processing
                If m_ctxMenuStrip.Name = CMSMACHINETOOL Then
                    'if finish processing or abort is clicked
                    If (m_ctxMenuStrip.Items(MenuIndex.Offline).Enabled Or m_ctxMenuStrip.Items(MenuIndex.Online).Enabled) And _
                    (ContainerForm.ProcessPanel.lpcLoadLockA.btnStart.Text = PAUSE Or ContainerForm.ProcessPanel.lpcLoadLockA.btnStart.Text = REZUME) Then
                        'if it is Menu TM, LLA or LLB is running or pause
                        m_ctxMenuStrip.Items(MenuIndex.PumpDown).Visible = True
                        m_ctxMenuStrip.Items(MenuIndex.PumpDown).Enabled = False
                        m_ctxMenuStrip.Items(MenuIndex.Vent).Visible = True
                        m_ctxMenuStrip.Items(MenuIndex.Vent).Enabled = False
                    ElseIf m_ctxMenuStrip.Items(MenuIndex.Online).Enabled _
                     And Not m_ctxMenuStrip.Items(MenuIndex.PumpDown).Enabled Then
                        'finish processing or abort 
                        m_ctxMenuStrip.Items(MenuIndex.Offline).Visible = False
                        m_ctxMenuStrip.Items(MenuIndex.Offline).Enabled = False
                        m_ctxMenuStrip.Items(MenuIndex.PumpDown).Visible = True
                        m_ctxMenuStrip.Items(MenuIndex.PumpDown).Enabled = True
                        m_ctxMenuStrip.Items(MenuIndex.Vent).Visible = True
                        m_ctxMenuStrip.Items(MenuIndex.Vent).Enabled = True
                        m_ctxMenuStrip.Items(MenuIndex.StopPumpDown).Visible = False
                        m_ctxMenuStrip.Items(MenuIndex.StopVent).Visible = False
                    End If
                ElseIf m_ctxMenuStrip.Items(MenuIndex.Online).Enabled And m_ctxMenuStrip.Items(MenuIndex.PumpDown).Visible = False Then 'Offline mode
                    m_ctxMenuStrip.Items(MenuIndex.Offline).Visible = False
                    m_ctxMenuStrip.Items(MenuIndex.Offline).Enabled = False
                    m_ctxMenuStrip.Items(MenuIndex.PumpDown).Visible = True
                    m_ctxMenuStrip.Items(MenuIndex.PumpDown).Enabled = True
                    m_ctxMenuStrip.Items(MenuIndex.Vent).Visible = True
                    m_ctxMenuStrip.Items(MenuIndex.Vent).Enabled = True
                    m_ctxMenuStrip.Items(MenuIndex.StopPumpDown).Visible = False
                    m_ctxMenuStrip.Items(MenuIndex.StopVent).Visible = False
                End If
            ElseIf Value.CompareTo(REZUME) = 0 Then 'system alarm change button text-->change status system
                AVPLib.Utils.ShowStatusMessage("Scheduler is pausing...")
                If (ContainerForm.ProcessPanel.lpcLoadLockA.btnStart.Text) = REZUME Then
                    ContainerForm.ProcessPanel.lpcLoadLockA.ProcessStatus = ProcessStatuses.PAUSE
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-18</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus") 'pause mode -> don't care
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

#End Region


End Class
