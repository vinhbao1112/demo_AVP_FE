Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.Business
Public Class StatusLoadLockControl
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_LCControl As LockCassetteControl
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
    Public Property ManageLockCassette() As LockCassetteControl
        Get
            Return m_LCControl
        End Get
        Set(ByVal value As LockCassetteControl)
            m_LCControl = value
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
    Public Sub New(ByVal lcControl As LockCassetteControl, ByVal strName As String)
        Try
            m_LCControl = lcControl
            Me.Name = strName
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
    Public Sub New(ByVal lcControl As LockCassetteControl)
        Try
            m_LCControl = lcControl
            Me.Name = lcControl.Name
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
        AVPLib.Log.guiLogger.Info("Enter UpdateUI LoadLock Status Control")
        Try
            Dim Value As String = CType(arg, String) ''arg=BUSY, READY
            Dim ctrLoadLock As LoadLockController = Nothing
            Dim ctrElevator As LLElevatorController = nothing

            If m_LCControl.Name.CompareTo(LOCKCASSETTEA) = 0 Then
                ctrLoadLock = CType(ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString()), LoadLockController)
            End If

            If (ctrLoadLock Is Nothing) Then
                Return
            End If
            ctrElevator = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)
            'As DatN suggestion
            If Value = "BUSY" And ctrElevator.IsManualAction = True Then ''equipment is busy
                ContainerForm.CassettesPanel.SetLLIsWorking(m_LCControl, True)
            ElseIf Value = "READY" Then
                If ctrElevator.ActionCMDSent = True And ctrElevator.IsManualAction = True Then 'will update GUI
                    ContainerForm.CassettesPanel.SetLLIsWorking(m_LCControl, False)
                    ctrElevator.ActionCMDSent = False
                    ctrElevator.IsManualAction = False
                ElseIf ctrElevator.IsManualAction = False Then 'update as normal
                    ContainerForm.CassettesPanel.SetLLIsWorking(m_LCControl, False)
                End If
            ElseIf Value = "ERROR" Then
                'happen when loadlock is not connected
            Else
                AVPLib.Log.avpLogger.Debug("Invalid LoadLock Status: " + Value)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave UpdateUI LoadLock Status Control")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-18</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification">LoadLockName</param>
    ''' <param name="Value">Working Status</param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

#End Region


End Class
