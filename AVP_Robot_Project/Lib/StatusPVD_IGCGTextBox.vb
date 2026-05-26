Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib

Public Class StatusPVD_IGCGTextBox
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_txtTextBox As TextBox
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the text box that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedTextBox() As TextBox
        Get
            Return m_txtTextBox
        End Get
        Set(ByVal value As TextBox)
            m_txtTextBox = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with text box that will be managed by this object
    ''' </summary>
    ''' <param name="txtManagedTextBox"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal txtManagedTextBox As TextBox)
        Try
            m_txtTextBox = txtManagedTextBox
            Me.Name = m_txtTextBox.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Truc Le </name>
    '''     <date> 2011-Mar-17</date>
    ''' </author>
    ''' <summary>
    ''' This procedure handle change UI only IG/CG of PVD and its relevant
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Private Sub UpdateGUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            Dim panelObj As PVDPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
            If panelObj Is Nothing Then
                Exit Sub
            End If
            Select Case Me.Name
                Case "txtIG"
                    'if IG Status of PVD is Off-> don't update anything
                    If Not (panelObj.Baratron.bigcgIG.Status = DisplayStatus.On) Then
                        Exit Sub
                    End If

                    Dim dblIG As Double = 0
                    If Double.TryParse(Value, dblIG) Then
                        If dblIG <= 0 Then
                            Value = UCase(STR_OFF)
                        End If
                    End If
                    Utils.UpdateIGCGValue(Value, panelObj.Name)
                Case "txtCG1"
                    'if IG status is Off => get CG for update value
                    If Not (panelObj.Baratron.bigcgIG.Status = DisplayStatus.On) Then
                        Utils.UpdateIGCGValue(Value, panelObj.Name)
                    End If
            End Select
            m_txtTextBox.Text = Value
            m_txtTextBox.Tag = Value

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateGUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
#End Region

End Class
