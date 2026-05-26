Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Public Class StatusIBE_IGCGTextBox
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_txtTextBox As SL_Textbox
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
    Public Property ManagedTextBox() As SL_Textbox
        Get
            Return m_txtTextBox
        End Get
        Set(ByVal value As SL_Textbox)
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
    Public Sub New(ByVal txtManagedTextBox As SL_Textbox)
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
    ''' This procedure handle change GUI of IG/CG of IBE and its relevant
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Private Sub UpdateGUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
            If objIBEPanel Is Nothing Then
                Exit Try
            End If
            m_txtTextBox.Text = Value

            If (m_txtTextBox.Name = objIBEPanel.SLIGCGControl.txtIG.Name) AndAlso _
            Not String.IsNullOrEmpty(objIBEPanel.SLIGCGControl.txtIG.Text) OrElse _
               m_txtTextBox.Name = objIBEPanel.SLIGCGControl.txtCG.Name Then
                ''Fire IG/CG value to Pressure Textbox in IBE Panel
                Dim dblIg As Double = 0
                Double.TryParse(objIBEPanel.SLIGCGControl.txtIG.Text, dblIg)

                Dim pressure As String = String.Empty
                If (Value = "-1.0E+00" OrElse objIBEPanel.SLIGCGControl.txtCG.Text = "-1.0E+00") AndAlso dblIg <= 0 Then
                    pressure = "Error"
                    objIBEPanel.SLPM.txtInformation.ForeColor = Color.Red
                Else
                    objIBEPanel.SLPM.txtInformation.ForeColor = Color.Lime
                    pressure = IIf(dblIg <= 0, objIBEPanel.SLIGCGControl.txtCG.Text, objIBEPanel.SLIGCGControl.txtIG.Text)
                End If

                'fire IG/CG Pressure txt in IBE
                objIBEPanel.SLPM.txtInformation.Text = pressure
                'fire IG/CG Pressure txt in other screen
                Utils.UpdateIGCGValue(pressure, objIBEPanel.Name)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
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
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateGUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
#End Region
End Class
