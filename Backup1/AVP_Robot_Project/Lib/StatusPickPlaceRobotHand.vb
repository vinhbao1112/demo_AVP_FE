Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib

Public Class StatusPickPlaceRobotHand
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_bigcgButton As ButtonIGCGControl
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-04</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the IgCgButton that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedIgCgButton() As ButtonIGCGControl
        Get
            Return m_bigcgButton
        End Get
        Set(ByVal value As ButtonIGCGControl)
            m_bigcgButton = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-04</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with button igcg control that will be managed by this object
    ''' </summary>
    ''' <param name="bigcgButton"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal bigcgButton As ButtonIGCGControl)
        Try
            m_bigcgButton = bigcgButton
            Me.Name = m_bigcgButton.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"

    Private Sub UpdateRobotArmStatus(ByVal val As String)
        Try
            Select Case val
                Case AVPLib.ConstEnum.RobotPickPlaceStatus.PICK.ToString()
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnPick.Status = DisplayStatus.On
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnPlace.Status = DisplayStatus.Off
                Case AVPLib.ConstEnum.RobotPickPlaceStatus.PLACE.ToString()
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnPick.Status = DisplayStatus.Off
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnPlace.Status = DisplayStatus.On
                Case Else
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnPick.Status = DisplayStatus.Unknow
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnPlace.Status = DisplayStatus.Unknow
                    AVPLib.Log.avpLogger.Error("Invalid Robot Arm Status: " + val)
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            UpdateRobotArmStatus(Value)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-04</date>
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