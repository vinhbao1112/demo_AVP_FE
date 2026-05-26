Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib

Public Class StatusCoronaPlasmaControl
    Inherits StatusObject

#Region "Class Constants & Variables"
    Private m_bigcgButton As ValveControl
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
    Public Property ManagedIgCgButton() As ValveControl
        Get
            Return m_bigcgButton
        End Get
        Set(ByVal value As ValveControl)
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
    Public Sub New(ByVal bigcgButton As ValveControl)
        Try
            m_bigcgButton = bigcgButton
            Me.Name = m_bigcgButton.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"
    Private lastindex As Integer = 0
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            Dim objPanel As CoronaPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
            Dim index As Integer = objPanel.RFTargetPowerSupply.ActiveTarget
            If index = 0 OrElse lastindex <> index Then
                objPanel.TurnOffPlasma(index, "0")
                lastindex = index
                Exit Sub
            End If
            Select Case Value
                Case "0"
                    If CType(objPanel.Controls("Plasma" & index), ValveControl).Status <> BinaryStatusControl.DisplayStatus.Off Then
                        objPanel.TurnOffPlasma(index, Value)
                    End If
                Case "1"
                    If CType(objPanel.Controls("Plasma" & index), ValveControl).Status <> BinaryStatusControl.DisplayStatus.On Then
                        objPanel.TurnOffPlasma(index, Value)
                    End If
                Case "2"
                    If CType(objPanel.Controls("Plasma" & index), ValveControl).Status <> BinaryStatusControl.DisplayStatus.Unknown Then
                        objPanel.TurnOffPlasma(index, Value)
                    End If
            End Select
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
