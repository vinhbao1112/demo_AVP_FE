Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum

Public Class StatusMotionLabel
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_lblLabel As Label
#End Region


#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the label that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedLabel() As Label
        Get
            Return m_lblLabel
        End Get
        Set(ByVal value As Label)
            m_lblLabel = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with label that will be managed by this object
    ''' </summary>
    ''' <param name="lblManagedLabel"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal lblManagedLabel As Label)
        Try
            m_lblLabel = lblManagedLabel
            Me.Name = m_lblLabel.Name
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
            If Value = "Other" Then
                m_lblLabel.Visible = True
            Else
                m_lblLabel.Visible = False
            End If

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
    ''' <author>
    '''     	<name> Ngo Cao Dinh </name>
    '''     	<date> 2008-09-11</date>
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
