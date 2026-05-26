Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVPLib.SystemModule
Public Class StatusCoronaPressure
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
            If Not AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Exit Sub
            End If
            Dim Value As String = CType(arg, String)

            Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
            If objPanel Is Nothing Then
                Exit Try
            End If

            Dim dblIg As Double = 0
            m_txtTextBox.Text = Value
            Double.TryParse(m_txtTextBox.Text, dblIg)
            If objPanel.ChamberType = ModuleType.PVD5T Then
                Dim objPVD5TPanel As PVD5TPanel = CType(objPanel, PVD5TPanel)
                If m_txtTextBox.Name = objPVD5TPanel.PVD5TPressure.txtIGPressure.Name Then
                    If dblIg > 0 Then
                        objPVD5TPanel.PVD5TPressure.txtIGPressure.Text = Format(dblIg, AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                    End If
                Else
                    If dblIg < 0 Then
                        objPVD5TPanel.PVD5TPressure.txtCGPressure.Text = "Error"
                        objPVD5TPanel.PVD5TPressure.txtPressure.ForeColor = Color.Red
                    Else
                        objPVD5TPanel.PVD5TPressure.txtCGPressure.Text = Format(dblIg, AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                        objPVD5TPanel.PVD5TPressure.txtPressure.ForeColor = Color.Lime
                    End If
                End If
            ElseIf objPanel.ChamberType = ModuleType.PVD4 Then
                Dim objCoronaPanel As CoronaPanel = CType(objPanel, CoronaPanel)
                If m_txtTextBox.Name = objCoronaPanel.CoronaPressure.txtIGPressure.Name Then
                    If dblIg > 0 Then
                        objCoronaPanel.CoronaPressure.txtIGPressure.Text = m_txtTextBox.Text
                    End If
                Else
                    If dblIg < 0 Then
                        objCoronaPanel.CoronaPressure.txtCGPressure.Text = "Error"
                        objCoronaPanel.CoronaPressure.txtPressure.ForeColor = Color.Red
                    Else
                        objCoronaPanel.CoronaPressure.txtCGPressure.Text = Value
                        objCoronaPanel.CoronaPressure.txtPressure.ForeColor = Color.Lime
                    End If
                End If
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
