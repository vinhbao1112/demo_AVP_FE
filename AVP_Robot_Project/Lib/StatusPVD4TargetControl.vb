Imports AVPLib.SystemModule

Public Class StatusPVD4TargetControl
    Inherits AVPControls.StatusObject

    Private m_managedControl As PVD4TargetControl

    Public Property ManagedControl() As PVD4TargetControl
        Get
            Return m_managedControl
        End Get
        Set(ByVal value As PVD4TargetControl)
            m_managedControl = value
        End Set
    End Property

    Public Sub New(ByVal control As PVD4TargetControl)
        Try
            m_managedControl = control
            Me.Name = m_managedControl.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-30 </date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)

            Dim objChamber As ChamberPanel = AVP_Robot_Project.ContainerForm.ChamberPanel(Me.Parent.Name)
            If objChamber.ChamberType = ModuleType.PVD5T Then
                Dim objPanel As PVD5TPanel = CType(objChamber, PVD5TPanel)
                Dim index As Integer = objPanel.TabTargetPowerSupply.RFTargetPowerSupply.ActiveTarget
                m_managedControl.ActiveTarget = index
                Select Case Value
                    Case "0"
                        m_managedControl.TargetStatus = DisplayStatus.Off
                    Case "1"
                        m_managedControl.TargetStatus = DisplayStatus.On
                    Case "2"
                        m_managedControl.TargetStatus = DisplayStatus.Unknow
                End Select
            Else
                Dim objPanel As CoronaPanel = CType(objChamber, CoronaPanel)
                Dim index As Integer = objPanel.RFTargetPowerSupply.ActiveTarget
                m_managedControl.ActiveTarget = index
                Select Case Value
                    Case "0"
                        m_managedControl.TargetStatus = DisplayStatus.Off
                    Case "1"
                        m_managedControl.TargetStatus = DisplayStatus.On
                    Case "2"
                        m_managedControl.TargetStatus = DisplayStatus.Unknow
                End Select
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-30 </date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-30 </date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub
End Class
