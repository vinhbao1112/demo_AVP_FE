Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.Business

Public Class StatusAlignerControl
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_AlignerControl As usrOperationsAligner
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
    Public Property ManagedOperationsAligner() As usrOperationsAligner
        Get
            Return m_AlignerControl
        End Get
        Set(ByVal value As usrOperationsAligner)
            m_AlignerControl = value
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
    Public Sub New(ByVal AlignerCtrl As usrOperationsAligner, ByVal strName As String)
        Try
            m_AlignerControl = AlignerCtrl
            Me.Name = strName
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
        AVPLib.Log.guiLogger.Info("Enter UpdateUI Aligner Status Control")
        Try
            Dim Value As String = CType(arg, String) ''arg=BUSY, READY
            Dim alignerController As AlignerController = CType(ControllerManager.GetController(AVPLib.ConstEnum.Equipments.Aligner.ToString()), AlignerController)
            If Value = "READY" Then
                If alignerController.ActionCMDSent = True And alignerController.IsManualAction = True Then
                    If Not m_AlignerControl.Enabled Then
                        m_AlignerControl.Enabled = True
                    End If
                    If Not ContainerForm.CassettesPanel.cmsTool.Enabled Then
                        ContainerForm.CassettesPanel.cmsTool.Enabled = True
                    End If
                    alignerController.ActionCMDSent = False
                    alignerController.IsManualAction = False
                End If
            ElseIf Value = "ERROR" Then
                'happen when Aligner is not connected
            Else
                AVPLib.Log.avpLogger.Error("Invalid Aligner Status: " + Value)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave UpdateUI Aligner Status Control")
    End Sub

    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

#End Region

End Class
