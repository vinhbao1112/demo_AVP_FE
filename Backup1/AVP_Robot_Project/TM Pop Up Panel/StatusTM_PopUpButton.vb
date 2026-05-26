Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib

Public Class StatusTM_PopUpButton
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
            Dim blnOnline As Boolean = (Value = STR_OFF)
            '#06/27/2011 
            '#-	TM/LLx.  IG degas button does not turn green when degas is running.   It show disable button instead.
            '#Begin fix: add blnFinished into parameter of function Finish_LLx/TMIGDegas to check condition for enable/disable button.
            Dim blnFinished As Boolean = IIf(Value = STR_OFF, True, False)
            '#End fix
            Select Case Me.Name
                Case "btnTMIGDegas"
                    ContainerForm.CassettesPanel.Enable_TMIGDegas()
                Case "btnLLAIGDegas"
                    ContainerForm.CassettesPanel.Enable_LLAIGDegas()
                Case "btnTMOnline"
                    Value = IIf(blnOnline, STR_ON, STR_OFF)
                    ContainerForm.CassettesPanel.SetTMOnline(blnOnline)
                    ContainerForm.TroubleShootPanel.SetOnlineOfflineForm(blnOnline)
                    ContainerForm.CassettesPanel.MechineValveStatus(Not blnOnline)
                Case "btnLLAOnline"
                    Value = IIf(blnOnline, STR_ON, STR_OFF)
                    ContainerForm.CassettesPanel.SetLLAOnline(blnOnline)
                    ContainerForm.CassettesPanel.LeftValveStatus(Not blnOnline)
            End Select
            If Value = AVPLib.ConstEnum.Abort And Me.Name.EndsWith("CryoRegen") Then
                Value = STR_OFF
            End If
            m_bigcgButton.Status = [Enum].Parse(GetType(SL_CustomButton.DisplayStatus), Value, True)

            Dim EnableLLA_After_Pumpdown As Boolean = (ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoPumpDown.Status = SL_CustomButton.DisplayStatus.Off)
            Dim EnableTM_After_Pumpdown As Boolean = (ContainerForm.CassettesPanel.PopUpPanel.btnTMAutoPumpDown.Status = SL_CustomButton.DisplayStatus.Off)

            Dim EnableLLA_After_Vent As Boolean = (ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoVent.Status = SL_CustomButton.DisplayStatus.Off)
            Dim EnableTM_After_Vent As Boolean = (ContainerForm.CassettesPanel.PopUpPanel.btnTMAutoVent.Status = SL_CustomButton.DisplayStatus.Off)

            Select Case Me.Name
                Case "btnTMAutoPumpDown"
                    If EnableTM_After_Pumpdown Then
                        ContainerForm.CassettesPanel.EvtTMVentPumpdownInProgress.Reset()
                    End If
                    ContainerForm.CassettesPanel.LockLoadARobotCassettes(EnableTM_After_Pumpdown)
                    ContainerForm.Diagnostic.dgsRateOfRiseTM.SplitContainer2.Panel1.Enabled = EnableTM_After_Pumpdown
                    ContainerForm.Diagnostic.dgsPumpDownTM.SplitContainer2.Panel1.Enabled = EnableTM_After_Pumpdown

                Case "btnTMAutoVent"
                    If EnableTM_After_Vent Then
                        ContainerForm.CassettesPanel.EvtTMVentPumpdownInProgress.Reset()
                    End If

                    ContainerForm.CassettesPanel.LockLoadARobotCassettes(EnableTM_After_Vent)
                    ContainerForm.Diagnostic.dgsRateOfRiseTM.SplitContainer2.Panel1.Enabled = EnableTM_After_Vent
                    ContainerForm.Diagnostic.dgsPumpDownTM.SplitContainer2.Panel1.Enabled = EnableTM_After_Vent

                Case "btnLLAAutoPumpDown"
                    If EnableLLA_After_Pumpdown Then
                        ContainerForm.CassettesPanel.EvtLLAVentPumpdownInProgress.Reset()
                    End If

                    'load is not running
                    If (ContainerForm.ProcessPanel.lpcLoadLockA.btnLoad.Text <> "ABORT") Then
                        ContainerForm.CassettesPanel.LockLoadARobotCassettes(EnableLLA_After_Pumpdown)
                    Else
                        ContainerForm.CassettesPanel.LockLoadARobotCassettes(True)
                    End If

                    ContainerForm.Diagnostic.dgsPumpDownLLA.SplitContainer2.Panel1.Enabled = EnableLLA_After_Pumpdown
                    ContainerForm.Diagnostic.dgsRateOfRiseLLA.SplitContainer2.Panel1.Enabled = EnableLLA_After_Pumpdown

                Case "btnLLAAutoVent"
                    If EnableLLA_After_Vent Then
                        ContainerForm.CassettesPanel.EvtLLAVentPumpdownInProgress.Reset()
                    End If

                    Dim IsLLA_Unload_Running As Boolean = (ContainerForm.ProcessPanel.lpcLoadLockA.btnUnload.Text <> "UNLOAD")
                    If (IsLLA_Unload_Running) Then '= Vent Running => Not disable form
                        ContainerForm.CassettesPanel.LockLoadARobotCassettes(True)
                    Else
                        ContainerForm.CassettesPanel.LockLoadARobotCassettes(EnableLLA_After_Vent)
                    End If

                    ContainerForm.Diagnostic.dgsPumpDownLLA.SplitContainer2.Panel1.Enabled = EnableLLA_After_Vent
                    ContainerForm.Diagnostic.dgsRateOfRiseLLA.SplitContainer2.Panel1.Enabled = EnableLLA_After_Vent
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

