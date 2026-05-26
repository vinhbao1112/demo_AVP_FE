Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib

Public Class StatusCryo_PopUpTextbox
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
    '''    	<name> Dat Do </name>
    '''     <date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Private Sub UpdateGUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            If Me.Name = "txtCryoRegenStatus" Then
                Value = Utils.GenerateRegenStatusToRegenStatusText(Value)
            ElseIf Me.Name = "txtExtendedPurgeTimeRB" AndAlso (Me.Parent.Parent.Name.Contains("Chamber")) Then
                Dim ar As Array = Value.Split("#")
                If ar.Length = 2 Then
                    Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                    Dim dblVal As Double = 0
                    Double.TryParse(ar(1), dblVal)
                    Select Case ar(0) & "#"
                        Case ConstEnum.REGEN_PARAM_ID_PUMP_RESTART_DELAY
                            If objPanel.ChamberType = SystemModule.ModuleType.IBE Then
                                CType(objPanel, IBEPanel).CryoPopUpPanel.txtPumpRestartDelayRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD Then
                                CType(objPanel, PVDPanel).CryoPopUpPanel.txtPumpRestartDelayRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                                CType(objPanel, CoronaPanel).CryoPopUpPanel.txtPumpRestartDelayRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then
                                CType(objPanel, PVD5TPanel).CryoPopUpPanel.txtPumpRestartDelayRB.Text = dblVal
                            End If
                        Case ConstEnum.REGEN_PARAM_ID_EXTENDED_PURGE_TIME
                            If objPanel.ChamberType = SystemModule.ModuleType.IBE Then
                                CType(objPanel, IBEPanel).CryoPopUpPanel.txtExtendedPurgeTimeRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD Then
                                CType(objPanel, PVDPanel).CryoPopUpPanel.txtExtendedPurgeTimeRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                                CType(objPanel, CoronaPanel).CryoPopUpPanel.txtExtendedPurgeTimeRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then
                                CType(objPanel, PVD5TPanel).CryoPopUpPanel.txtExtendedPurgeTimeRB.Text = dblVal
                            End If

                        Case ConstEnum.REGEN_PARAM_ID_REPURGE_CYCLES
                            If objPanel.ChamberType = SystemModule.ModuleType.IBE Then
                                CType(objPanel, IBEPanel).CryoPopUpPanel.txtRepurgeCyclesRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD Then
                                CType(objPanel, PVDPanel).CryoPopUpPanel.txtRepurgeCyclesRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                                CType(objPanel, CoronaPanel).CryoPopUpPanel.txtRepurgeCyclesRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then
                                CType(objPanel, PVD5TPanel).CryoPopUpPanel.txtRepurgeCyclesRB.Text = dblVal
                            End If

                        Case ConstEnum.REGEN_PARAM_ID_ROUGH_TO_PRESSURE
                            If objPanel.ChamberType = SystemModule.ModuleType.IBE Then
                                CType(objPanel, IBEPanel).CryoPopUpPanel.txtRoughtToPressureRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD Then
                                CType(objPanel, PVDPanel).CryoPopUpPanel.txtRoughtToPressureRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                                CType(objPanel, CoronaPanel).CryoPopUpPanel.txtRoughtToPressureRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then
                                CType(objPanel, PVD5TPanel).CryoPopUpPanel.txtRoughtToPressureRB.Text = dblVal
                            End If

                        Case ConstEnum.REGEN_PARAM_ID_RATE_OF_RISE
                            If objPanel.ChamberType = SystemModule.ModuleType.IBE Then
                                CType(objPanel, IBEPanel).CryoPopUpPanel.txtRateOfRiseRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD Then
                                CType(objPanel, PVDPanel).CryoPopUpPanel.txtRateOfRiseRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                                CType(objPanel, CoronaPanel).CryoPopUpPanel.txtRateOfRiseRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then
                                CType(objPanel, PVD5TPanel).CryoPopUpPanel.txtRateOfRiseRB.Text = dblVal
                            End If

                        Case ConstEnum.REGEN_PARAM_ID_START_UP_TEMPERATURE
                            If objPanel.ChamberType = SystemModule.ModuleType.IBE Then
                                CType(objPanel, IBEPanel).CryoPopUpPanel.txtStartUpTempRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD Then
                                CType(objPanel, PVDPanel).CryoPopUpPanel.txtStartUpTempRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                                CType(objPanel, CoronaPanel).CryoPopUpPanel.txtStartUpTempRB.Text = dblVal
                            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then
                                CType(objPanel, PVD5TPanel).CryoPopUpPanel.txtStartUpTempRB.Text = dblVal
                            End If
                    End Select
                    Exit Try
                End If

            End If

            m_txtTextBox.Text = Value
            m_txtTextBox.Tag = Value
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

