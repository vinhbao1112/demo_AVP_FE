Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib

Public Class StatusTurboRelayIndicator
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_bigcgButton As SL_CustomButton
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
    Public Property ManagedIgCgButton() As SL_CustomButton
        Get
            Return m_bigcgButton
        End Get
        Set(ByVal value As SL_CustomButton)
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
    Public Sub New(ByVal bigcgButton As SL_CustomButton)
        Try
            m_bigcgButton = bigcgButton
            Me.Name = m_bigcgButton.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            m_bigcgButton.Status = CType([Enum].Parse(GetType(SL_CustomButton.DisplayStatus), Value), SL_CustomButton.DisplayStatus)

            If m_bigcgButton.AccessibleName = ContainerForm.CassettesPanel.TMCtl.btnRelay.AccessibleName AndAlso _
           m_bigcgButton.Name = ContainerForm.CassettesPanel.TMCtl.btnRelay.Name Then
                ContainerForm.CassettesPanel.TMCGGaugesFrm.btnTurnIGOn.Enabled = IIf(m_bigcgButton.Status = SL_CustomButton.DisplayStatus.On, True, False)
                ContainerForm.CassettesPanel.TMCGGaugesFrm.btnTurnIGOff.Enabled = IIf(m_bigcgButton.Status = SL_CustomButton.DisplayStatus.On, True, False)

            ElseIf m_bigcgButton.AccessibleName = ContainerForm.CassettesPanel.lccLoadLockA.btnRelay.AccessibleName AndAlso _
                        m_bigcgButton.Name = ContainerForm.CassettesPanel.lccLoadLockA.btnRelay.Name Then
                ContainerForm.CassettesPanel.LLACGGaugesFrm.btnTurnIGOn.Enabled = IIf(m_bigcgButton.Status = SL_CustomButton.DisplayStatus.On, True, False)
                ContainerForm.CassettesPanel.LLACGGaugesFrm.btnTurnIGOff.Enabled = IIf(m_bigcgButton.Status = SL_CustomButton.DisplayStatus.On, True, False)
            End If
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


