Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib

Public Class SL_StatusButton
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
            Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
            'try to get Chamber Panel (some obj has GrandParent)
            If objIBEPanel Is Nothing Then
                objIBEPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
            End If
            If objIBEPanel Is Nothing Then
                Exit Try
            End If
            Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(objIBEPanel.Name)
            If Me.Name = "Wafer" Then
                AVP_Robot_Project.Utils.ChangeWaferStatusColor(Value, Me.Parent.Parent.Name)
                Exit Try
            End If
            If m_bigcgButton.Name = objIBEPanel.SLFixture.btnMode.Name Then
                '#02/25/2011 
                '#0001266: [Sl_Build 12_Feb 16, 2011]Rotation mode default to �Home� mode and user select other mode. 
                '#This is due to the fact that ibe is updating this mode. Only updating this mode when SL start up or 
                '#during process running to show user what mode it is currently in 
                '#Begin Fix
                If objIBE IsNot Nothing Then
                    '#End fix
                    Select Case Value
                        Case ConfigurationValues.DEVICE_STATUS_OPEN '01
                            objIBEPanel.SLFixture.LoadingContinuousMode()
                        Case ConfigurationValues.DEVICE_STATUS_STOPPED '02
                            objIBEPanel.SLFixture.LoadingHomeMode()
                        Case ConfigurationValues.DEVICE_STATUS_ABORT '03
                            objIBEPanel.SLFixture.LoadingStaticMode()
                        Case ConfigurationValues.DEVICE_STATUS_OTHER '04
                            objIBEPanel.SLFixture.LoadingSweepMode()
                    End Select
                    Exit Sub
                End If
            End If

            If Value = UCase(STRING_ONLINE) Then
                Value = STR_ON
            End If
            If Value = UCase(STRING_OFFLINE) Then
                Value = STR_OFF
            End If
            Select Case Value
                Case UCase(STRING_MAINTENANCE) ''set directly
                    m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
                Case STR_ON
                    m_bigcgButton.Status = SL_CustomButton.DisplayStatus.On
                    If Me.Name = objIBEPanel.btnSourceManual.Name Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
                        objIBEPanel.btnSourceAuto.Status = SL_CustomButton.DisplayStatus.On
                    ElseIf Me.Name = objIBEPanel.SLFixture.btnClampDown.Name Then ''Clamp Up
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
                        objIBEPanel.SLFixture.btnClampUp.Status = SL_CustomButton.DisplayStatus.On
                    ElseIf Me.Name = objIBEPanel.SLFixture.btnShutterOpen.Name Then
                        objIBEPanel.SLFixture.btnShutterClose.Status = SL_CustomButton.DisplayStatus.Off
                    ElseIf Me.Name = objIBEPanel.PopUpPanel.btnAutoVentGeneral.Name Then
                        objIBEPanel.PopUpPanel.EnableDisableChamberButton(False, True, False, False, False)
                    ElseIf Me.Name = objIBEPanel.PopUpPanel.btnAutoPumpDownGeneral.Name Then
                        objIBEPanel.PopUpPanel.EnableDisableChamberButton(True, False, False, False, False)
                        objIBE.IsAutoPumpdownRunning = True
                    ElseIf Me.Name = objIBEPanel.PopUpPanel.btnRateOfRise.Name Then
                        objIBEPanel.PopUpPanel.EnableDisableChamberButton(False, False, False, True, False)
                    ElseIf Me.Name = objIBEPanel.PopUpPanel.btnIGDegas.Name Then
                        objIBEPanel.PopUpPanel.EnableDisableChamberButton(False, False, True, False, False)
                    ElseIf Me.Name = objIBEPanel.PopUpPanel.btnPumpdownCurve.Name Then
                        objIBEPanel.PopUpPanel.EnableDisableChamberButton(False, False, False, False, True)
                    ElseIf Me.Name = objIBEPanel.SLFixture.slMotionInitializingStatus.Name Then
                        objIBEPanel.IsWaitingInitializeMotionOff = False
                        objIBEPanel.SLFixture.btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Unknow
                        objIBEPanel.SLStatusPanel.btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Unknow
                    ElseIf Me.Name = "btnOnline" Then
                        objIBEPanel.IsOnline = True
                        '#02/22/2011 
                        '#0001269: [Sl_Build 12_Feb 16, 2011]PM. All button still available during online mode 
                        '#Begin fix
                        objIBEPanel.SetOnlineOfflinePM(True)
                        '#End fix.
                        '#02/22/2011 
                        '#0001097: [SL_RFE_KhoiHa_Jan 17 ,2011]Process screen. Add more Ion icon when shutter open 
                        '#Begin Fix
                    ElseIf Me.Name = "btnIonBeam" Then
                        objIBEPanel.IsBeamOn = True
                    ElseIf Me.Name = "btnChamPress" Then
                        objIBEPanel.CGGaugesFrm.EnableButtonIGOnOff(True)
                    End If

                Case STR_OFF
                    If Me.Name = objIBEPanel.SLFixture.btnMotionInitialized.Name Then 'Receive command: 03,01,14,01,01,00
                        '#02/25/2011 
                        '#0001245: [SL_RFE_KhoiHa_Feb 14,2011]Motion initialize status flashing on/off 
                        '#Begin fix
                        If objIBEPanel.IsWaitingInitializeMotionOff Then
                            '#End fix
                            objIBEPanel.IsWaitingInitializeMotionOff = False
                            objIBEPanel.SLFixture.btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Off
                            objIBEPanel.SLStatusPanel.btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Off
                        End If
                        Exit Try
                    End If
                    m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
                    If Me.Name = objIBEPanel.btnSourceManual.Name Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.On
                        objIBEPanel.btnSourceAuto.Status = SL_CustomButton.DisplayStatus.Off
                    ElseIf Me.Name = objIBEPanel.SLFixture.btnClampDown.Name Then ''Clamp Down
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.On
                        objIBEPanel.SLFixture.btnClampUp.Status = SL_CustomButton.DisplayStatus.Off
                    ElseIf Me.Name = objIBEPanel.SLFixture.btnShutterOpen.Name Then
                        objIBEPanel.SLFixture.btnShutterClose.Status = SL_CustomButton.DisplayStatus.On
                    ElseIf Me.Name = objIBEPanel.PopUpPanel.btnAutoVentGeneral.Name Then
                        objIBEPanel.PopUpPanel.EnableDisableChamberButton(True, True, True, True, True)
                    ElseIf Me.Name = objIBEPanel.PopUpPanel.btnAutoPumpDownGeneral.Name Then
                        objIBEPanel.PopUpPanel.EnableDisableChamberButton(True, True, True, True, True)
                        objIBE.IsAutoPumpdownRunning = False
                    ElseIf Me.Name = objIBEPanel.PopUpPanel.btnRateOfRise.Name Then
                        objIBEPanel.PopUpPanel.EnableDisableChamberButton(True, True, True, True, True)
                    ElseIf Me.Name = objIBEPanel.PopUpPanel.btnIGDegas.Name Then
                        objIBEPanel.PopUpPanel.EnableDisableChamberButton(True, True, True, True, True)
                    ElseIf Me.Name = objIBEPanel.PopUpPanel.btnPumpdownCurve.Name Then
                        objIBEPanel.PopUpPanel.EnableDisableChamberButton(True, True, True, True, True)
                    ElseIf Me.Name = objIBEPanel.SLFixture.slMotionInitializingStatus.Name Then  'Receive command: 03,01,13,01,01,00
                        objIBEPanel.IsWaitingInitializeMotionOff = True
                    ElseIf Me.Name = "btnOnline" Then
                        objIBEPanel.IsOnline = False
                        '#02/22/2011 
                        '#0001269: [Sl_Build 12_Feb 16, 2011]PM. All button still available during online mode 
                        '#Begin fix
                        objIBEPanel.SetOnlineOfflinePM(False)
                        '#End fix.
                    ElseIf Me.Name = "btnChamPress" Then
                        objIBEPanel.CGGaugesFrm.EnableButtonIGOnOff(False)
                    End If
                Case STR_ERROR, UNKNOWN
                    m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Error
                Case STR_OTHER
                    m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Unknow
                    If m_bigcgButton.Name = "btnRotate" Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
                    End If
                    If Me.Name = objIBEPanel.SLFixture.btnShutterOpen.Name Then
                        objIBEPanel.SLFixture.btnShutterClose.Status = SL_CustomButton.DisplayStatus.Unknow
                    ElseIf Me.Name = objIBEPanel.SLFixture.slMotionInitializingStatus.Name Then
                        objIBEPanel.SLFixture.btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Error
                        objIBEPanel.SLStatusPanel.btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Error
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
