Imports AVP_Robot_Project.ConstantAndEnum
Public Class StatusClearAllWaferControl
    Inherits AVPControls.StatusObject
#Region "Class Constants & Variables"
    Private Const Unknown As String = "Unknown"
    Private m_ClearAllWaferControl As System.Windows.Forms.Button
#End Region
#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with text box that will be managed by this object
    ''' </summary>
    ''' <param name="rrcRoundRectangleControl"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ClearAllWaferControl As System.Windows.Forms.Button)
        Try
            m_ClearAllWaferControl = ClearAllWaferControl
            Me.Name = m_ClearAllWaferControl.Name
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
            If Value = AVPLib.ConstEnum.STR_ON Then
                ContainerForm.ProcessPanel.EnableClearAllWaferButton(True)
                '#08/29/2011 
                '#-	“Return wafer”  This option is disable along with the “Clear all wafer” feature.
                '# We only need to disable the “Clear all wafer” when the scheduler is running NOT “return wafer”
                '#Begin fix:
                With ContainerForm.ProcessPanel
                    .IsButtonClearAllWaferClicked = False
                    .lpcLoadLockA.ClearAllWaferStatus()
                End With
                
                '#End fix.
            Else
                ContainerForm.ProcessPanel.EnableClearAllWaferButton(False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-05</date>
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
    '''     	<name> Ngo Cao Dinh </name>
    '''     	<date> 2008-08-21</date>
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

