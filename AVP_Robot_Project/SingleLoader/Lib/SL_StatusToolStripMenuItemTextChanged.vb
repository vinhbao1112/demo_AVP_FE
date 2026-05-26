Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum

Public Class SL_StatusToolStripMenuItemTextChanged
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
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-20</date>
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
    ''' if menu item change from enable to disable or something else, go to StatusToolstripmenuitemchamber3
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            'cryo
            If ManagedToolStripMenuItem.Text = STRING_CRYO_ON Or ManagedToolStripMenuItem.Text = STRING_CRYO_OFF Then
                ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STRING_CRYO_ON, STRING_CRYO_OFF)
            ElseIf ManagedToolStripMenuItem.Text = STR_CRYO_REGEN_VALVE_OPEN Or ManagedToolStripMenuItem.Text = STR_CRYO_REGEN_VALVE_CLOSE Then
                ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_CRYO_REGEN_VALVE_OPEN, STR_CRYO_REGEN_VALVE_CLOSE)
            ElseIf ManagedToolStripMenuItem.Text = STR_CRYO_PURGE_OPEN Or ManagedToolStripMenuItem.Text = STR_CRYO_PURGE_CLOSE Then
                ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_CRYO_PURGE_OPEN, STR_CRYO_PURGE_CLOSE)
            ElseIf ManagedToolStripMenuItem.Text = STR_CRYO_GATE_OPEN Or ManagedToolStripMenuItem.Text = STR_CRYO_GATE_CLOSE Then
                ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_CRYO_GATE_OPEN, STR_CRYO_GATE_CLOSE)
            ElseIf ManagedToolStripMenuItem.Text = STR_AUTO_REGEN_ON Or ManagedToolStripMenuItem.Text = STR_AUTO_REGEN_OFF Then
                ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_AUTO_REGEN_ON, STR_AUTO_REGEN_OFF)
            ElseIf ManagedToolStripMenuItem.Text = STR_AUTO_POWER_DOWN_ON Or ManagedToolStripMenuItem.Text = STR_AUTO_POWER_DOWN_OFF Then
                ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_AUTO_POWER_DOWN_ON, STR_AUTO_POWER_DOWN_OFF)
                'turbo
            ElseIf ManagedToolStripMenuItem.Text = STRING_WATERPUMP_ON Or ManagedToolStripMenuItem.Text = STRING_WATERPUMP_OFF Then
                ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STRING_WATERPUMP_ON, STRING_WATERPUMP_OFF)
            ElseIf ManagedToolStripMenuItem.Text = STR_WATERPUMP_REGEN_ON Or ManagedToolStripMenuItem.Text = STR_WATERPUMP_REGEN_OFF Then
                ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_WATERPUMP_REGEN_ON, STR_WATERPUMP_REGEN_OFF)
                'ElseIf ManagedToolStripMenuItem.Text = STR_WP_GATE_OPEN Or ManagedToolStripMenuItem.Text = STR_WP_GATE_CLOSE Then
                '    ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_WP_GATE_OPEN, STR_WP_GATE_CLOSE)
                ''Others
            ElseIf ManagedToolStripMenuItem.Text = STR_AUTO_VENT_ON Or ManagedToolStripMenuItem.Text = STR_AUTO_VENT_OFF Then
                ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_AUTO_VENT_ON, STR_AUTO_VENT_OFF)
            ElseIf ManagedToolStripMenuItem.Text = STR_AUTO_PUMPDOWN_ON Or ManagedToolStripMenuItem.Text = STR_AUTO_PUMPDOWN_OFF Then
                ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_AUTO_PUMPDOWN_ON, STR_AUTO_PUMPDOWN_OFF)
            ElseIf ManagedToolStripMenuItem.Text = STR_RUN_RATE_OF_RISE Or ManagedToolStripMenuItem.Text = STR_ABORT_RATE_OF_RISE Then
                ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_RUN_RATE_OF_RISE, STR_ABORT_RATE_OF_RISE)

                'ElseIf ManagedToolStripMenuItem.Text = STR_FLOWCOOL_COOLING_WATER_ON Or ManagedToolStripMenuItem.Text = STR_FLOWCOOL_COOLING_WATER_OFF Then
                '    ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_FLOWCOOL_COOLING_WATER_ON, STR_FLOWCOOL_COOLING_WATER_OFF)
                'ElseIf ManagedToolStripMenuItem.Text = STR_CRYO_PURGE_CLOSE Or ManagedToolStripMenuItem.Text = STR_CRYO_PURGE_OPEN Then
                '    ManagedToolStripMenuItem.Text = IIf((STR_OFF = Value), STR_CRYO_PURGE_OPEN, STR_CRYO_PURGE_CLOSE)

                'ElseIf ManagedToolStripMenuItem.Text = START_ROTATION_AXIS Or ManagedToolStripMenuItem.Text = STOP_ROTATION_AXIS Then
                '    If Value = STR_OTHER Then
                '        ContainerForm.SLProcessModule.SLFixture.stHomeRotation.Status = FourStatusControl.DisplayStatus.Home
                '        If ContainerForm.SLProcessModule.SLFixture.stStartRotation.Status = FourStatusControl.DisplayStatus.Home Then
                '            ContainerForm.SLProcessModule.SLFixture.stStartRotation.Status = FourStatusControl.DisplayStatus.Default
                '            ManagedToolStripMenuItem.Text = START_ROTATION_AXIS
                '        End If
                '    Else
                '        ContainerForm.SLProcessModule.SLFixture.stHomeRotation.Status = FourStatusControl.DisplayStatus.Default
                '        If Value = STR_ON Then
                '            ManagedToolStripMenuItem.Text = STOP_ROTATION_AXIS
                '        ElseIf Value = STR_OFF Then
                '            ManagedToolStripMenuItem.Text = START_ROTATION_AXIS
                '        End If
                '    End If
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
