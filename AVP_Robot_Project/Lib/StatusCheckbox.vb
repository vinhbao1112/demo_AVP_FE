Imports System.Windows.Forms

Public Class StatusCheckbox
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_chkBox As CheckBox
#End Region

#Region "Properties"
    
    Public Property ManagedCheckbox() As CheckBox
        Get
            Return m_chkBox
        End Get
        Set(ByVal value As CheckBox)
            m_chkBox = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    Public Sub New(ByVal chkBox As CheckBox)
        Try
            m_chkBox = chkBox
            Me.Name = m_chkBox.Name
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
            Dim defVal As Boolean = False
            If (Me.Name = "cbLLAStopCycleAt") Then
                ContainerForm.CassettesPanel.ctwcCycleWafer.IsLLAShowPopup = False
            End If

            Boolean.TryParse(Value, defVal)
            m_chkBox.Checked = defVal
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-11</date>
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
