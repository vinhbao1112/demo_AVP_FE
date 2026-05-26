Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib

Public Class StatusCoronaButton
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
            Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
            ''try to get Chamber Panel (some obj has GrandParent)
            If objPanel Is Nothing Then
                objPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
            End If
            If objPanel Is Nothing Then
                objPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Parent.Name)
            End If
            If objPanel Is Nothing Then
                Exit Try
            End If
            If Value = UCase(STRING_ONLINE) Then
                Value = STR_ON
            End If
            If Value = UCase(STRING_OFFLINE) Then
                Value = STR_OFF
            End If
            If objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                Dim objPVD4Panel As CoronaPanel = CType(objPanel, CoronaPanel)
                Dim objChamber As DataManagerment.CoronaChamber = DataManagerment.EquipmentManager.GetEquipment(objPanel.Name)
                Select Case Value
                    Case UCase(STRING_MAINTENANCE) ''set directly
                        'If m_bigcgButton.Status <> SL_CustomButton.DisplayStatus.Off Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
                    'End If
                    Case STR_ON
                        If m_bigcgButton.Status <> SL_CustomButton.DisplayStatus.On Then
                            m_bigcgButton.Status = SL_CustomButton.DisplayStatus.On
                            If Me.Name = "btnOnline" Then
                                objPVD4Panel.IsOnline = True
                                objPVD4Panel.SetOnlineOfflinePM(True)
                            ElseIf Me.Name = objPVD4Panel.PopUpPanel.btnAutoVent.Name Then
                                objPVD4Panel.PopUpPanel.ManageEnableOfChamberControl(False, True, False, False, False)
                            ElseIf Me.Name = objPVD4Panel.PopUpPanel.btnAutoPumpDown.Name Then
                                objPVD4Panel.PopUpPanel.ManageEnableOfChamberControl(True, False, False, False, False)
                            ElseIf Me.Name = objPVD4Panel.PopUpPanel.btnIGDegas.Name Then
                                objPVD4Panel.PopUpPanel.ManageEnableOfChamberControl(False, False, True, False, False)
                            ElseIf Me.Name = objPVD4Panel.PopUpPanel.btnPumpPurge.Name Then
                                objPVD4Panel.PopUpPanel.ManageEnableOfChamberControl(False, False, False, True, False)
                            ElseIf Me.Name = objPVD4Panel.PopUpPanel.btnShutDownPower.Name Then
                                objPVD4Panel.PopUpPanel.ManageEnableOfChamberControl(False, False, False, False, True)
                            ElseIf Me.Name = objPVD4Panel.RFTargetPowerSupply.btnPulse.Name Then
                                objPVD4Panel.RFTargetPowerSupply.txtPulseMode.Text = "Pulse"
                            ElseIf Me.Name = objPVD4Panel.TableControl.btnHOME.Name Then
                                objPVD4Panel.TableControl.CheckMotion()
                            ElseIf Me.Name = objPVD4Panel.HeaterControl.btnZone1ComStatus.Name Then
                                If objPVD4Panel.HeaterControl.btnZone2ComStatus.Status = SL_CustomButton.DisplayStatus.On Then
                                    objPVD4Panel.HeaterControl.Header.Status = DisplayStatus.On
                                Else
                                    objPVD4Panel.HeaterControl.Header.Status = DisplayStatus.Off
                                End If
                            ElseIf Me.Name = objPVD4Panel.HeaterControl.btnZone2ComStatus.Name Then
                                If objPVD4Panel.HeaterControl.btnZone1ComStatus.Status = SL_CustomButton.DisplayStatus.On Then
                                    objPVD4Panel.HeaterControl.Header.Status = DisplayStatus.On
                                Else
                                    objPVD4Panel.HeaterControl.Header.Status = DisplayStatus.Off
                                End If
                            ElseIf Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag1RotationStart.Name _
                            OrElse Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag2RotationStart.Name _
                            OrElse Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag3RotationStart.Name _
                            OrElse Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag4RotationStart.Name Then
                                objPVD4Panel.RFTargetPowerSupply.txtMagnatron.Text = ConstantAndEnum.STR_ROTATING
                            ElseIf Me.Name = objPVD4Panel.PVD4Interlock.bicChamberPress.Name Then
                                objPVD4Panel.CoronaPressure.EnableButtonIGOnOff(True)
                            End If
                        End If

                    Case STR_OFF
                        'If m_bigcgButton.Status <> SL_CustomButton.DisplayStatus.Off Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
                        If Me.Name = "btnOnline" Then
                            objPVD4Panel.IsOnline = False
                            objPVD4Panel.SetOnlineOfflinePM(False)
                        ElseIf Me.Name = objPVD4Panel.PopUpPanel.btnAutoVent.Name Then
                            objPVD4Panel.PopUpPanel.ManageEnableOfChamberControl(True, True, True, True, True)
                        ElseIf Me.Name = objPVD4Panel.PopUpPanel.btnAutoPumpDown.Name Then
                            objPVD4Panel.PopUpPanel.ManageEnableOfChamberControl(True, True, True, True, True)
                        ElseIf Me.Name = objPVD4Panel.PopUpPanel.btnIGDegas.Name Then
                            objPVD4Panel.PopUpPanel.ManageEnableOfChamberControl(True, True, True, True, True)
                        ElseIf Me.Name = objPVD4Panel.PopUpPanel.btnPumpPurge.Name Then
                            objPVD4Panel.PopUpPanel.ManageEnableOfChamberControl(True, True, True, True, True)
                        ElseIf Me.Name = objPVD4Panel.PopUpPanel.btnShutDownPower.Name Then
                            objPVD4Panel.PopUpPanel.ManageEnableOfChamberControl(True, True, True, True, True)
                        ElseIf Me.Name = objPVD4Panel.RFTargetPowerSupply.btnPulse.Name Then
                            objPVD4Panel.RFTargetPowerSupply.txtPulseMode.Text = "Normal"
                        ElseIf Me.Name = objPVD4Panel.TableControl.btnHOME.Name Then
                            objPVD4Panel.TableControl.CheckMotion()
                        ElseIf Me.Name = objPVD4Panel.HeaterControl.btnZone1ComStatus.Name Then
                            objPVD4Panel.HeaterControl.Header.Status = DisplayStatus.Off
                        ElseIf Me.Name = objPVD4Panel.HeaterControl.btnZone2ComStatus.Name Then
                            objPVD4Panel.HeaterControl.Header.Status = DisplayStatus.Off
                        ElseIf Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag1RotationStart.Name _
                        OrElse Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag2RotationStart.Name _
                        OrElse Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag3RotationStart.Name _
                        OrElse Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag4RotationStart.Name Then
                            If (Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag1RotationStart.Name AndAlso
                                objPVD4Panel.RFTargetPowerSupply.btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.On) _
                            OrElse (Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag2RotationStart.Name AndAlso
                                objPVD4Panel.RFTargetPowerSupply.btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.On) _
                            OrElse (Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag3RotationStart.Name AndAlso
                                objPVD4Panel.RFTargetPowerSupply.btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.On) _
                            OrElse (Me.Name = objPVD4Panel.RFTargetPowerSupply.btnMag4RotationStart.Name AndAlso
                                objPVD4Panel.RFTargetPowerSupply.btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.On) Then

                                objPVD4Panel.RFTargetPowerSupply.txtMagnatron.Text = String.Empty
                            End If
                        ElseIf Me.Name = objPVD4Panel.PVD4Interlock.bicChamberPress.Name Then
                            objPVD4Panel.CoronaPressure.EnableButtonIGOnOff(False)
                        End If
                    Case STR_ERROR, UNKNOWN
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Error

                    Case STR_OTHER
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Unknow
                        objPVD4Panel.TableControl.CheckMotion()
                End Select
            ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then
                Dim objPVD5TPanel As PVD5TPanel = CType(objPanel, PVD5TPanel)
                Dim objChamber As DataManagerment.PVD5TChamber = DataManagerment.EquipmentManager.GetEquipment(objPanel.Name)
                Select Case Value
                    Case UCase(STRING_MAINTENANCE) ''set directly
                        'If m_bigcgButton.Status <> SL_CustomButton.DisplayStatus.Off Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
                    'End If
                    Case STR_ON
                        If m_bigcgButton.Status <> SL_CustomButton.DisplayStatus.On Then
                            m_bigcgButton.Status = SL_CustomButton.DisplayStatus.On
                            If Me.Name = "btnOnline" Then
                                objPVD5TPanel.IsOnline = True
                                objPVD5TPanel.SetOnlineOfflinePM(True)
                            ElseIf Me.Name = objPVD5TPanel.PopUpPanel.btnAutoVent.Name Then
                                objPVD5TPanel.PopUpPanel.ManageEnableOfChamberControl(False, True, False, False, False)
                            ElseIf Me.Name = objPVD5TPanel.PopUpPanel.btnAutoPumpDown.Name Then
                                objPVD5TPanel.PopUpPanel.ManageEnableOfChamberControl(True, False, False, False, False)
                            ElseIf Me.Name = objPVD5TPanel.PopUpPanel.btnIGDegas.Name Then
                                objPVD5TPanel.PopUpPanel.ManageEnableOfChamberControl(False, False, True, False, False)
                            ElseIf Me.Name = objPVD5TPanel.PopUpPanel.btnPumpPurge.Name Then
                                objPVD5TPanel.PopUpPanel.ManageEnableOfChamberControl(False, False, False, True, False)
                            ElseIf Me.Name = objPVD5TPanel.PopUpPanel.btnShutDownPower.Name Then
                                objPVD5TPanel.PopUpPanel.ManageEnableOfChamberControl(False, False, False, False, True)
                            ElseIf Me.Name = objPVD5TPanel.TableControl.btnHOME.Name Then
                                objPVD5TPanel.TableControl.CheckMotion()
                            ElseIf Me.Name = objPVD5TPanel.HeaterControl.btnZone1ComStatus.Name Then
                                If objPVD5TPanel.HeaterControl.btnZone2ComStatus.Status = SL_CustomButton.DisplayStatus.On Then
                                    objPVD5TPanel.HeaterControl.Header.Status = DisplayStatus.On
                                Else
                                    objPVD5TPanel.HeaterControl.Header.Status = DisplayStatus.Off
                                End If
                            ElseIf Me.Name = objPVD5TPanel.HeaterControl.btnZone2ComStatus.Name Then
                                If objPVD5TPanel.HeaterControl.btnZone1ComStatus.Status = SL_CustomButton.DisplayStatus.On Then
                                    objPVD5TPanel.HeaterControl.Header.Status = DisplayStatus.On
                                Else
                                    objPVD5TPanel.HeaterControl.Header.Status = DisplayStatus.Off
                                End If
                            ElseIf Me.Parent.Name = objPVD5TPanel.TabTargetPowerSupply.RFTargetPowerSupply.Name Then
                                Dim rFTargetPowerSupply As PVD5TBiasPowerSupply = objPVD5TPanel.TabTargetPowerSupply.RFTargetPowerSupply
                                If Me.Name = rFTargetPowerSupply.btnPulse.Name Then
                                    rFTargetPowerSupply.txtPulseMode.Text = "Pulse"
                                ElseIf Me.Name = rFTargetPowerSupply.btnMag1RotationStart.Name OrElse
                                 Me.Name = rFTargetPowerSupply.btnMag2RotationStart.Name OrElse
                                 Me.Name = rFTargetPowerSupply.btnMag3RotationStart.Name OrElse
                                 Me.Name = rFTargetPowerSupply.btnMag4RotationStart.Name OrElse
                                 Me.Name = rFTargetPowerSupply.btnMag5RotationStart.Name Then

                                    'RF & DC use same target so display same status
                                    rFTargetPowerSupply.txtMagnatron.Text = ConstantAndEnum.STR_ROTATING
                                    objPVD5TPanel.TabTargetPowerSupply.DCTargetPowerSupply.txtMagnatron.Text = ConstantAndEnum.STR_ROTATING
                                End If
                            ElseIf Me.Parent.Name = objPVD5TPanel.TabTargetPowerSupply.DCTargetPowerSupply.Name Then
                                Dim dCTargetPowerSupply As PVD5TBiasPowerSupply = objPVD5TPanel.TabTargetPowerSupply.DCTargetPowerSupply
                                If Me.Name = dCTargetPowerSupply.btnPulse.Name Then
                                    dCTargetPowerSupply.txtPulseMode.Text = "Pulse"
                                End If

                            ElseIf Me.Name = objPVD5TPanel.PVD5TInterlock.bicChamberPress.Name Then
                                objPVD5TPanel.PVD5TPressure.EnableButtonIGOnOff(True)
                            End If
                        End If

                    Case STR_OFF
                        'If m_bigcgButton.Status <> SL_CustomButton.DisplayStatus.Off Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
                        If Me.Name = "btnOnline" Then
                            objPVD5TPanel.IsOnline = False
                            objPVD5TPanel.SetOnlineOfflinePM(False)
                        ElseIf Me.Name = objPVD5TPanel.PopUpPanel.btnAutoVent.Name Then
                            objPVD5TPanel.PopUpPanel.ManageEnableOfChamberControl(True, True, True, True, True)
                        ElseIf Me.Name = objPVD5TPanel.PopUpPanel.btnAutoPumpDown.Name Then
                            objPVD5TPanel.PopUpPanel.ManageEnableOfChamberControl(True, True, True, True, True)
                        ElseIf Me.Name = objPVD5TPanel.PopUpPanel.btnIGDegas.Name Then
                            objPVD5TPanel.PopUpPanel.ManageEnableOfChamberControl(True, True, True, True, True)
                        ElseIf Me.Name = objPVD5TPanel.PopUpPanel.btnPumpPurge.Name Then
                            objPVD5TPanel.PopUpPanel.ManageEnableOfChamberControl(True, True, True, True, True)
                        ElseIf Me.Name = objPVD5TPanel.PopUpPanel.btnShutDownPower.Name Then
                            objPVD5TPanel.PopUpPanel.ManageEnableOfChamberControl(True, True, True, True, True)
                        ElseIf Me.Name = objPVD5TPanel.TableControl.btnHOME.Name Then
                            objPVD5TPanel.TableControl.CheckMotion()
                        ElseIf Me.Name = objPVD5TPanel.HeaterControl.btnZone1ComStatus.Name Then
                            objPVD5TPanel.HeaterControl.Header.Status = DisplayStatus.Off
                        ElseIf Me.Name = objPVD5TPanel.HeaterControl.btnZone2ComStatus.Name Then
                            objPVD5TPanel.HeaterControl.Header.Status = DisplayStatus.Off

                        ElseIf Me.Parent.Name = objPVD5TPanel.TabTargetPowerSupply.RFTargetPowerSupply.Name Then
                            Dim rFTargetPowerSupply As PVD5TBiasPowerSupply = objPVD5TPanel.TabTargetPowerSupply.RFTargetPowerSupply
                            Dim dCTargetPowerSupply As PVD5TBiasPowerSupply = objPVD5TPanel.TabTargetPowerSupply.DCTargetPowerSupply
                            If Me.Name = rFTargetPowerSupply.btnPulse.Name Then
                                rFTargetPowerSupply.txtPulseMode.Text = "Normal"
                            ElseIf Me.Name = rFTargetPowerSupply.btnMag1RotationStart.Name OrElse
                             Me.Name = rFTargetPowerSupply.btnMag2RotationStart.Name OrElse
                             Me.Name = rFTargetPowerSupply.btnMag3RotationStart.Name OrElse
                             Me.Name = rFTargetPowerSupply.btnMag4RotationStart.Name OrElse
                                Me.Name = rFTargetPowerSupply.btnMag5RotationStart.Name Then

                                If (Me.Name = rFTargetPowerSupply.btnMag1RotationStart.Name AndAlso rFTargetPowerSupply.btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.On) OrElse
                                    (Me.Name = rFTargetPowerSupply.btnMag2RotationStart.Name AndAlso rFTargetPowerSupply.btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.On) OrElse
                                    (Me.Name = rFTargetPowerSupply.btnMag3RotationStart.Name AndAlso rFTargetPowerSupply.btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.On) OrElse
                                    (Me.Name = rFTargetPowerSupply.btnMag4RotationStart.Name AndAlso rFTargetPowerSupply.btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.On) OrElse
                                    (Me.Name = rFTargetPowerSupply.btnMag5RotationStart.Name AndAlso rFTargetPowerSupply.btnTarget5Switch.Status = SL_CustomButton.DisplayStatus.On) Then

                                    'RF & DC use same target so display same status
                                    rFTargetPowerSupply.txtMagnatron.Text = String.Empty
                                    dCTargetPowerSupply.txtMagnatron.Text = String.Empty
                                End If
                            End If
                        ElseIf Me.Parent.Name = objPVD5TPanel.TabTargetPowerSupply.DCTargetPowerSupply.Name Then
                            Dim dCTargetPowerSupply As PVD5TBiasPowerSupply = objPVD5TPanel.TabTargetPowerSupply.DCTargetPowerSupply
                            If Me.Name = dCTargetPowerSupply.btnPulse.Name Then
                                dCTargetPowerSupply.txtPulseMode.Text = "Normal"
                            End If
                        ElseIf Me.Name = objPVD5TPanel.PVD5TInterlock.bicChamberPress.Name Then
                            objPVD5TPanel.PVD5TPressure.EnableButtonIGOnOff(False)
                        End If
                    Case STR_ERROR, UNKNOWN
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Error

                    Case STR_OTHER
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Unknow
                        objPVD5TPanel.TableControl.CheckMotion()
                End Select
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
