Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPControls

Public Class IBEPanel
    Private m_bPM_DeviceNet As Boolean = False
    Private m_CryoVisible As Boolean = False
    Private m_PopUpPanel As SL_PopUpPanel = Nothing
    Private m_CryoPopUpPanel As CryoPopUpPanel = Nothing
    Public bUnProtectedClicked As Boolean = False
    Public intTimeUnProtectedTimeCountInProcessModule As Integer = 0
    Public IsWaitingInitializeMotionOff As Boolean = False
    Private m_TypeOfIBE As AVPLib.ConstEnum.AllChamberType = AllChamberType.AVP_IBE
    Private m_blnIsBeamOn As Boolean = False
    Private m_blnIsShutterOpen As Boolean = False
    Private blnGasLineTotal1Enabled As Boolean = True
    Private blnGasLineTotal2Enabled As Boolean = True
    Private blnGasLineTotal3Enabled As Boolean = True
    Private blnGasLineTotal4Enabled As Boolean = True
    Private blnGasLineTotalEnabled As Boolean = True
    Private m_CGGaugesFrm As CGGaugesFrm = Nothing
    Private m_MPCGGaugesFrm As CGGaugesFrm = Nothing
    Private m_FLCGGaugesFrm As CGGaugesFrm = Nothing
    Private m_iGasEndIndex As Integer = 1
    Private m_IGIsoValveInstalled As Boolean = False
    Private m_DiverterGasValveInstalled As Boolean = False

#Region "Properties"

    Public Property IsBeamOn() As Boolean
        Get
            Return m_blnIsBeamOn
        End Get
        Set(ByVal value As Boolean)
            m_blnIsBeamOn = value
        End Set
    End Property

    Public Property IsShuttterOpen() As Boolean
        Get
            Return m_blnIsShutterOpen
        End Get
        Set(ByVal value As Boolean)
            m_blnIsShutterOpen = value
        End Set
    End Property

    Private m_Gas1ShutoffVisible As Boolean
    Public Property Gas1ShutoffVisible() As Boolean
        Get
            Return m_Gas1ShutoffVisible
        End Get
        Set(ByVal value As Boolean)
            m_Gas1ShutoffVisible = value
            ValveShutoffGas1.Visible = value
            GasLine_Shutoff1.Visible = value
        End Set
    End Property

    Private m_Gas1SupplyVisible As Boolean
    Public Property Gas1SupplyVisible() As Boolean
        Get
            Return m_Gas1SupplyVisible
        End Get
        Set(ByVal value As Boolean)
            m_Gas1SupplyVisible = value
            ValveSupplyGas1.Visible = value
        End Set
    End Property

    Private m_Gas2ShutoffVisible As Boolean
    Public Property Gas2ShutoffVisible() As Boolean
        Get
            Return m_Gas2ShutoffVisible
        End Get
        Set(ByVal value As Boolean)
            m_Gas2ShutoffVisible = value
            ValveShutoffGas2.Visible = value
            GasLine_Shutoff2.Visible = value
        End Set
    End Property

    Private m_Gas2SupplyVisible As Boolean
    Public Property Gas2SupplyVisible() As Boolean
        Get
            Return m_Gas2SupplyVisible
        End Get
        Set(ByVal value As Boolean)
            m_Gas2SupplyVisible = value
            ValveSupplyGas2.Visible = value
        End Set
    End Property

    Private m_Gas3ShutoffVisible As Boolean
    Public Property Gas3ShutoffVisible() As Boolean
        Get
            Return m_Gas3ShutoffVisible
        End Get
        Set(ByVal value As Boolean)
            m_Gas3ShutoffVisible = value
            ValveShutoffGas3.Visible = value
            GasLine_Shutoff3.Visible = value
        End Set
    End Property

    Private m_Gas3SupplyVisible As Boolean
    Public Property Gas3SupplyVisible() As Boolean
        Get
            Return m_Gas3SupplyVisible
        End Get
        Set(ByVal value As Boolean)
            m_Gas3SupplyVisible = value
            ValveSupplyGas3.Visible = value
        End Set
    End Property

    Private m_Gas4ShutoffVisible As Boolean
    Public Property Gas4ShutoffVisible() As Boolean
        Get
            Return m_Gas4ShutoffVisible
        End Get
        Set(ByVal value As Boolean)
            m_Gas4ShutoffVisible = value
            ValveShutoffGas4.Visible = value
            GasLine_Shutoff4.Visible = value
        End Set
    End Property

    Private m_Gas4SupplyVisible As Boolean
    Public Property Gas4SupplyVisible() As Boolean
        Get
            Return m_Gas4SupplyVisible
        End Get
        Set(ByVal value As Boolean)
            m_Gas4SupplyVisible = value
            ValveSupplyGas4.Visible = value
        End Set
    End Property

    Private m_strGas1Type As String
    Public Property Gas1Type() As String
        Get
            Return m_strGas1Type
        End Get
        Set(ByVal value As String)
            m_strGas1Type = value

            If (String.IsNullOrEmpty(value)) Then
                value = "Disabled"
                lblSourceGas1.Visible = False
            Else
                lblGas1.Text &= " (" & value & ")"
                lblSourceGas1.Text &= " (" & value & ") " & GAS_UNIT
            End If
        End Set
    End Property

    Private m_strGas2Type As String
    Public Property Gas2Type() As String
        Get
            Return m_strGas2Type
        End Get
        Set(ByVal value As String)
            m_strGas2Type = value

            If (String.IsNullOrEmpty(value)) Then
                value = "Disabled"
                lblSourceGas2.Visible = False
            Else
                lblGas2.Text &= " (" & value & ")"
                lblSourceGas2.Text &= " (" & value & ") " & GAS_UNIT
            End If
        End Set
    End Property

    Private m_strGas3Type As String
    Public Property Gas3Type() As String
        Get
            Return m_strGas3Type
        End Get
        Set(ByVal value As String)
            m_strGas3Type = value

            If (String.IsNullOrEmpty(value)) Then
                lblSourceGas3.Visible = False
                txtGas3Right_SourceTab.Visible = False
                txtGas3_SourceTab.Visible = False
            Else
                lblGas3.Text &= " (" & value & ")"
                lblSourceGas3.Visible = True
                lblSourceGas3.Text &= " (" & value & ") " & GAS_UNIT
            End If

        End Set
    End Property

    Private m_strGas4Type As String
    Public Property Gas4Type() As String
        Get
            Return m_strGas4Type
        End Get
        Set(ByVal value As String)
            m_strGas4Type = value

            If (String.IsNullOrEmpty(value)) Then
                lblSourceGas4.Visible = False
                txtGas4Right_SourceTab.Visible = False
                txtGas4_SourceTab.Visible = False
            Else
                lblGas4.Text &= " (" & value & ")"
                lblSourceGas4.Visible = True
                lblSourceGas4.Text &= " (" & value & ") " & GAS_UNIT
            End If

        End Set
    End Property

    Private m_strPBNGasType As String
    Public Property PBNGasType() As String
        Get
            Return m_strPBNGasType
        End Get
        Set(ByVal value As String)
            m_strPBNGasType = value

            If (String.IsNullOrEmpty(value)) Then
                value = "Disabled"
            Else
                lblGasPBN.Text &= " (" & value & ")"
            End If
            lblSourcePBNGas.Text = "PBN Gas (" & value & ") " & GAS_UNIT
        End Set
    End Property

    Public Property PM_DeviceNet() As Boolean
        Get
            Return m_bPM_DeviceNet
        End Get
        Set(ByVal value As Boolean)
            m_bPM_DeviceNet = value
            If m_bPM_DeviceNet Then
                txtForelineCG.Visible = True
                ' txtRoughlineCG.Visible = True
                PressureConnector.Visible = True
            Else
                txtForelineCG.Visible = False
                txtRoughlineCG.Visible = False
                PressureConnector.Visible = False
            End If
        End Set
    End Property

    Public Property CryoVisible() As Boolean
        Get
            Return m_CryoVisible
        End Get
        Set(ByVal value As Boolean)
            m_CryoVisible = value
        End Set
    End Property

    Public ReadOnly Property TypeOfIBE() As AVPLib.ConstEnum.AllChamberType
        Get
            Return m_TypeOfIBE
        End Get
    End Property
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2019-03-05</date>
    ''' </author>
    ''' <summary>
    ''' IGIsolation Vale Visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Property IGIsoValveInstalled() As Boolean
        Get
            Return m_IGIsoValveInstalled
        End Get
        Set(ByVal value As Boolean)
            m_IGIsoValveInstalled = value
            GasLine_Isolation.Visible = value
            ValveIGIsolation.Visible = value
            lblIGIsolation.Visible = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2019-03-11</date>
    ''' </author>
    ''' <summary>
    ''' Support Gas Diverter Valve
    ''' </summary>
    ''' <remarks></remarks>
    Public Property DiverterGasValveInstalled() As Boolean
        Get
            Return m_DiverterGasValveInstalled
        End Get
        Set(ByVal value As Boolean)
            m_DiverterGasValveInstalled = value
            If m_DiverterGasValveInstalled Then
                ValveDiverter.Visible = True
                lblDiverterGas.Visible = True
                If m_Gas2ShutoffVisible = False AndAlso m_Gas2SupplyVisible = False AndAlso _
                m_Gas3ShutoffVisible = False AndAlso m_Gas3SupplyVisible = False AndAlso _
                m_Gas4ShutoffVisible = False AndAlso m_Gas4SupplyVisible = False Then
                    m_DiverterGasValveInstalled = False
                    ValveDiverter.Visible = False
                    GasLine234_Total.Visible = False
                End If
            Else
                ValveDiverter.Visible = False
                lblDiverterGas.Visible = False
                GasLine234_Total.Visible = False
                GasLine2_Total.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical
                GasLine2_Total.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_On
                GasLine2_Total.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_On_1

                GasLine2_Total_Below.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_Below
                GasLine2_Total_Below.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_Below_On
                GasLine2_Total_Below.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Vertical_Below_On_1
                GasLine2_Total_Below.Location = New Point(21, 242)

                GasLine_Shutoff2.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal
                GasLine_Shutoff2.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_On
                GasLine_Shutoff2.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_On_1
                GasLine_Shutoff2.Location = New Point(33, 230)
            End If
        End Set
    End Property

#End Region

#Region "Private method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.Name)
            If objPanel.IsOnline Then
                SLContainerBox.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
                SLContainerBox.SetOnlineOfflineContainerBox(IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True))
                Exit Sub
            End If
            SLContainerBox.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveIGIsolation.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveDiverter.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveRough.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveVent.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveForeline.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveFixtureWater.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            SLPowerPanel.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            'SLStatusPanel.Enabled = True
            RunRecipe.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            btnUnProtected.Status = SL_CustomButton.DisplayStatus.Off
            btnUnProtected.Clickable = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            'Source control'
            txtBeamVoltageRight.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtBeamCurrentRight.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtSuppressorVoltageRight.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtSuppressorCurrentRight.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtRFPowerRight.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtRFReflectedRight.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtKFactorRight.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtPBNGasRight_SourceTab.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtGas1Right_SourceTab.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtGas2Right_SourceTab.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtGas3Right_SourceTab.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtGas4Right_SourceTab.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtPBNBodyRight.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtPBNDischRight.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnAutoBeam.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnSourceManual.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnSourceAuto.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtRoughlineCG.Clickable = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtForelineCG.Clickable = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnSourceSaveLoad.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            'Gas control'
            txtPBNGasRight.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtGas1Right.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtGas2Right.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtGas3Right.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtGas4Right.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveShutoffPBNGas.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveShutoffGas1.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveShutoffGas2.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveShutoffGas3.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveShutoffGas4.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveSupplyPBNGas.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveSupplyGas1.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveSupplyGas2.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveSupplyGas3.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveSupplyGas4.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            RoughPump.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnOpenCloseGas1.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnOpenCloseGas2.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnOpenCloseGas3.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnOpenCloseGas4.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnOpenClosePBNGas.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            btnSourceSaveLoad.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            SLFixture.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            EMPowerSupply.IsOnline = IIf(IsMaintenanceMode, Not IsEditable_InMaintenanceMode, False)
            btnTooltipFixture.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            ValveFlowCoolReturn.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtGridSerialNumber.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtGridID.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            cmbRebuildLevel.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtPBNMinutes.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtSourceMinutesMaint.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtShieldQuartSP.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtCoverFixtureShieldUsageSP.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtWaferClampUsageSP.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtTopFixtureShieldUsageSP.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtShutterUsageSP.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtLinerSP.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtCryoUsageSP.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtFixtureRotationMotorUsageSP.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtWaterJournalSP.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtRoughlineCG.Clickable = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            SLPM.txtInformation.Clickable = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            lblDisconnect.Tag = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            lblDisconnect.Cursor = IIf(lblDisconnect.Tag, Cursors.Hand, Cursors.Default)
            'Chiller
            ChillerControl.IsOnline() = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
            txtSourceEMCurrentRight_SourceTab.Enabled = IIf(IsMaintenanceMode, IsEditable_InMaintenanceMode, True)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            SLContainerBox.Enabled = False
            ValveIGIsolation.Enabled = False
            ValveDiverter.Enabled = False
            ValveRough.Enabled = False
            ValveVent.Enabled = False
            ValveForeline.Enabled = False
            ValveFixtureWater.Enabled = False
            SLPowerPanel.IsOnline = True
            ' SLStatusPanel.Enabled = False
            RunRecipe.IsOnline = True
            btnUnProtected.Status = SL_CustomButton.DisplayStatus.Unknow
            btnUnProtected.Clickable = False
            'Source control'
            txtBeamVoltageRight.Enabled = False
            txtBeamCurrentRight.Enabled = False
            txtSuppressorVoltageRight.Enabled = False
            txtSuppressorCurrentRight.Enabled = False
            txtRFPowerRight.Enabled = False
            txtRFReflectedRight.Enabled = False
            txtKFactorRight.Enabled = False
            txtPBNGasRight_SourceTab.Enabled = False
            txtGas1Right_SourceTab.Enabled = False
            txtGas2Right_SourceTab.Enabled = False
            txtGas3Right_SourceTab.Enabled = False
            txtGas4Right_SourceTab.Enabled = False
            txtPBNBodyRight.Enabled = False
            txtPBNDischRight.Enabled = False
            btnAutoBeam.Enabled = False
            btnSourceManual.Enabled = False
            btnSourceAuto.Enabled = False
            txtRoughlineCG.Clickable = False
            txtForelineCG.Clickable = False
            btnSourceSaveLoad.Enabled = False
            'Gas control'
            txtPBNGasRight.Enabled = False
            txtGas1Right.Enabled = False
            txtGas2Right.Enabled = False
            txtGas3Right.Enabled = False
            txtGas4Right.Enabled = False
            ValveShutoffPBNGas.Enabled = False
            ValveShutoffGas1.Enabled = False
            ValveShutoffGas2.Enabled = False
            ValveShutoffGas3.Enabled = False
            ValveShutoffGas4.Enabled = False
            ValveSupplyPBNGas.Enabled = False
            ValveSupplyGas1.Enabled = False
            ValveSupplyGas2.Enabled = False
            ValveSupplyGas3.Enabled = False
            ValveSupplyGas4.Enabled = False
            RoughPump.Enabled = False
            btnOpenCloseGas1.Enabled = False
            btnOpenCloseGas2.Enabled = False
            btnOpenCloseGas3.Enabled = False
            btnOpenCloseGas4.Enabled = False
            btnOpenClosePBNGas.Enabled = False
            btnSourceSaveLoad.Enabled = False
            SLFixture.IsOnline = True
            EMPowerSupply.IsOnline = True
            btnTooltipFixture.Enabled = False
            ValveFlowCoolReturn.Enabled = False
            txtGridSerialNumber.Enabled = False
            txtGridID.Enabled = False
            cmbRebuildLevel.Enabled = False
            txtPBNMinutes.Enabled = False
            txtSourceMinutesMaint.Enabled = False
            txtShieldQuartSP.Enabled = False
            txtCoverFixtureShieldUsageSP.Enabled = False
            txtWaferClampUsageSP.Enabled = False
            txtTopFixtureShieldUsageSP.Enabled = False
            txtShutterUsageSP.Enabled = False
            txtLinerSP.Enabled = False
            txtCryoUsageSP.Enabled = False
            txtFixtureRotationMotorUsageSP.Enabled = False
            txtWaterJournalSP.Enabled = False

            txtRoughlineCG.Clickable = False
            SLPM.txtInformation.Clickable = False
            lblDisconnect.Tag = False
            lblDisconnect.Cursor = Cursors.Default
            'Chiller
            ChillerControl.IsOnline() = False
            txtSourceEMCurrentRight_SourceTab.Enabled = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-29 </date>
    ''' </author>
    ''' <summary>
    ''' Set SlitValve status to chamber control
    ''' </summary>
    Protected Overrides Sub SetSlitValveStatus()
        Try
            Select Case SlitValveStatus
                Case AVPControls.AVPDataLib.DisplayStatus.On
                    Me.SLContainerBox.btnMesaValve.Status = SL_CustomButton.DisplayStatus.On
                Case AVPControls.AVPDataLib.DisplayStatus.Off
                    Me.SLContainerBox.btnMesaValve.Status = SL_CustomButton.DisplayStatus.Off
                Case Else
                    Me.SLContainerBox.btnMesaValve.Status = SL_CustomButton.DisplayStatus.Unknow
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Overrides Sub GoOnline(ByVal blnThrowAlarm As Boolean)
        ''must get status obj PopUpPanel to Request Status-> ParseMessageGui will convert
        If m_PopUpPanel IsNot Nothing Then
            m_PopUpPanel.Status.RequestStatus(SL_PopUpPanel.btnOnline.Name, blnThrowAlarm)
        End If
    End Sub

    Public Sub New(ByVal ChamberName As String, ByVal TypeOfIBE As AVPLib.ConstEnum.AllChamberType, Optional ByVal CryoInstalled As Boolean = True, _
    Optional ByVal WPInstalled As Boolean = True, Optional ByVal IGFilamentVisible As Boolean = True)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.lblDisconnect.Location = New Point(377, 303)
        Me.Name = ChamberName
        Me.Tag = AVPLib.Utils.chamberID2ChamberName(Me.Name)
        Me.m_TypeOfIBE = TypeOfIBE
        m_PopUpPanel = New SL_PopUpPanel
        m_PopUpPanel.IBE_Type = TypeOfIBE


        '#02/21/2011 
        '#0001243: [SL_RFE_KhoiHa_Feb 12 ,2011]PM screen. IBE panel pop up menu still show water pump when it is not install 
        If m_TypeOfIBE = AllChamberType.AVP_IBE Then
            m_PopUpPanel.NoCryoAndWPInstalled = True
        Else
            If CryoInstalled = False And WPInstalled = True Then
                m_PopUpPanel.NoCryoInstalled = True
            ElseIf CryoInstalled = True And WPInstalled = False Then
                m_PopUpPanel.NoWaterPumpInstalled = True
            ElseIf CryoInstalled = False And WPInstalled = False Then
                m_PopUpPanel.NoCryoAndWPInstalled = True
            End If
        End If

        m_PopUpPanel.StartPosition = FormStartPosition.CenterScreen
        m_PopUpPanel.ShowInTaskbar = False
        m_PopUpPanel.ShowIcon = False
        m_PopUpPanel.Text = AVPLib.Utils.chamberID2ChamberName(ChamberName) & " Menu"
        m_PopUpPanel.ChamberHandle = ChamberName
        m_PopUpPanel.Hide()

        m_CryoPopUpPanel = New CryoPopUpPanel
        ''m_CryoPopUpPanel.Type=TypeOfIBE
        m_CryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
        m_CryoPopUpPanel.ShowInTaskbar = False
        m_CryoPopUpPanel.ShowIcon = False
        m_CryoPopUpPanel.Text = AVPLib.Utils.chamberID2ChamberName(ChamberName) & " Cryo"
        m_CryoPopUpPanel.PanelHandle = ChamberName
        m_CryoPopUpPanel.txtExtendedPurgeTime.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtPumpRestartDelay.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtRateOfRise.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtRoughToPressure.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtStartUpTemp.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.txtRepurgeCycles.SourceOfMessageBox = "CryoPopUpPanel"
        m_CryoPopUpPanel.ChamberType = "IBE"
        m_CryoPopUpPanel.Hide()

        NewConvectronGaugeFrm(IGFilamentVisible)
        NewFLConvectronGaugeFrm()
        NewMPConvectronGaugeFrm()

        RunRecipe.Left = SLInterlocks.Left
        RunRecipe.Height += 3
        RunRecipe.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusTextLocation = New Point(3, RoughPump.Top + RoughPump.Height - 6)
        Me.lblStatusText.Visible = True
        '#06/05/2012
        '#0000500: [KhoiHa 02-03-2012] -These on/off button should be invisible if IBE type is AVP. These on/off button is for VEECO IBE...
        If m_TypeOfIBE = AllChamberType.AVP_IBE Then
            btnOpenCloseGas1.Visible = False
            btnOpenCloseGas2.Visible = False
            btnOpenCloseGas3.Visible = False
            btnOpenCloseGas4.Visible = False
            btnOpenClosePBNGas.Visible = False
        End If

        ' Add any initialization after the InitializeComponent() call.
        AddHandler m_CryoPopUpPanel.ButtonPump_StatusChanged, AddressOf btnCryoPumpOnOff_StatusChange
        AddHandler m_CryoPopUpPanel.ButtonRegen_StatusChanged, AddressOf btnCryoPumpOnOff_StatusChange
        AddHandler SLPM.PressureCG_Click, AddressOf PressureCG_Click
        AddHandler SLIGCGControl.PressureCG_StatusChange, AddressOf PressureCG_StatusChange
        AddHandler SLIGCGControl.SwitchIGFilament_StatusChange, AddressOf SwitchIGFilament_StatusChange
        AddHandler SLIGCGControl.SwitchIGFilament_EnableChange, AddressOf SwitchIGFilament_EnableChange

        tabProcessModule.HideTab("tabProcessStatus")
        txtForelineCG.Cursor = Cursors.Hand


    End Sub

    ''' <author>
    '''    	<name> Dy Do</name>
    '''    	<date> 2016-10-31</date>
    ''' </author>
    ''' <summary>
    ''' ArrangeSourceBeam
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ArrangeSourceBeam(ByVal ChamberConfig As AVPLib.SystemModule)
        Try
            If ChamberConfig.SourceMagnetVisible Then
                lblSourceEMCurrent_SourceTab.Left = lblSourceGas1.Left
                txtSourceEMCurrent_SourceTab.Left = txtGas1_SourceTab.Left
                txtSourceEMCurrentRight_SourceTab.Left = txtGas1Right_SourceTab.Left
            End If

            Dim InstallArray As Boolean() = {ChamberConfig.Gas1Install, ChamberConfig.Gas2Install, ChamberConfig.Gas3Install, ChamberConfig.Gas4Install, True, True, True, ChamberConfig.SupportPBNBodyDischargeVoltage, ChamberConfig.SupportPBNBodyDischargeVoltage, ChamberConfig.ANCInstalled, ChamberConfig.SourceMagnetVisible}
            Dim LabelArray As Label() = {lblSourceGas1, lblSourceGas2, lblSourceGas3, lblSourceGas4, lblKFactor, Label10, Label11, Label20, Label22, lblANC, lblSourceEMCurrent_SourceTab}
            Dim TextboxRBArray As TextBox() = {txtGas1_SourceTab, txtGas2_SourceTab, txtGas3_SourceTab, txtGas4_SourceTab, txtKFactor, txtPBNBody, txtPBNDisch, txtPBNBodyVolt, txtPBNDischVolt, txtANC, txtSourceEMCurrent_SourceTab}
            Dim TextboxSPArray As TextBox() = {txtGas1Right_SourceTab, txtGas2Right_SourceTab, txtGas3Right_SourceTab, txtGas4Right_SourceTab, txtKFactorRight, Nothing, Nothing, Nothing, Nothing, Nothing, txtSourceEMCurrentRight_SourceTab}

            Dim labelTop As Integer = lblSourceGas1.Top
            Dim textboxTop As Integer = txtGas1_SourceTab.Top

            For i As Integer = 0 To InstallArray.Length - 1
                If InstallArray(i) Then
                    LabelArray(i).Top = labelTop
                    TextboxRBArray(i).Top = textboxTop

                    If TextboxSPArray(i) IsNot Nothing Then
                        TextboxSPArray(i).Top = textboxTop

                        btnSourceSaveLoad.Top = TextboxSPArray(i).Bottom + 2
                    Else
                        btnSourceSaveLoad.Top = textboxTop
                    End If

                    labelTop = LabelArray(i).Bottom + 8
                    textboxTop = TextboxRBArray(i).Bottom + 2
                Else
                    LabelArray(i).Visible = False
                    TextboxRBArray(i).Visible = False

                    If TextboxSPArray(i) IsNot Nothing Then
                        TextboxSPArray(i).Visible = False
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            MyBase.CreateStatusTree()

            'Maint tab
            Dim stbPBNRB As New SL_StatusTextBox(txtPBNMinutes)
            Dim stbSourceRB As New SL_StatusTextBox(txtSourceMinutesMaint)
            Dim stbShieldRB As New SL_StatusTextBox(txtShieldQuartSP)
            Dim stbFixtureCoverRB As New SL_StatusTextBox(txtCoverFixtureShieldUsageSP)
            Dim stbWaferClampRB As New SL_StatusTextBox(txtWaferClampUsageSP)
            Dim stbGridSourceRB As New SL_StatusTextBox(txtTopFixtureShieldUsageSP)
            Dim stbSourceUsedRB As New SL_StatusTextBox(txtShutterUsageSP)
            Dim stbLinerRB As New SL_StatusTextBox(txtLinerSP)
            Dim stbCryoRB As New SL_StatusTextBox(txtCryoUsageSP)
            Dim stbFixtureRotationRB As New SL_StatusTextBox(txtFixtureRotationMotorUsageSP)
            Dim stbWaterJournalRB As New SL_StatusTextBox(txtWaterJournalSP)

            'Source tab
            Dim sbcConnectionStatus As New StatusIGCGButton(btnReConnect)
            Dim stbBeamVoltage As New SL_StatusTextBox(txtBeamVoltage)
            Dim stbBeamCurrent As New SL_StatusTextBox(txtBeamCurrent)
            Dim stbSuppressorVoltage As New SL_StatusTextBox(txtSuppressorVoltage)
            Dim stbSuppressorCurrent As New SL_StatusTextBox(txtSuppressorCurrent)
            Dim stbRFPower As New SL_StatusTextBox(txtRFPower)
            Dim stbRFReflected As New SL_StatusTextBox(txtRFReflected)
            Dim stbKFactor As New SL_StatusTextBox(txtKFactor)
            Dim stbANC As New SL_StatusTextBox(txtANC)
            Dim stbPBNBody As New SL_StatusTextBox(txtPBNBody)
            Dim stbPBNDisch As New SL_StatusTextBox(txtPBNDisch)
            Dim stbPBNBodyVolt As New SL_StatusTextBox(txtPBNBodyVolt)
            Dim stbPBNDischVolt As New SL_StatusTextBox(txtPBNDischVolt)

            Dim stbPBNGas_SourceTabStatus As New SL_StatusTextBox(txtPBNGas_SourceTab)
            Dim stbGas1_SourceTabStatus As New SL_StatusTextBox(txtGas1_SourceTab)
            Dim stbGas2_SourceTabStatus As New SL_StatusTextBox(txtGas2_SourceTab)
            Dim stbGas3_SourceTabStatus As New SL_StatusTextBox(txtGas3_SourceTab)
            Dim stbGas4_SourceTabStatus As New SL_StatusTextBox(txtGas4_SourceTab)

            Dim stbBeamVoltageRight As New SL_StatusTextBox(txtBeamVoltageRight)
            Dim stbBeamCurrentRight As New SL_StatusTextBox(txtBeamCurrentRight)
            Dim stbSuppressorVoltageRight As New SL_StatusTextBox(txtSuppressorVoltageRight)
            Dim stbSuppressorCurrentRight As New SL_StatusTextBox(txtSuppressorCurrentRight)
            Dim stbRFPowerRight As New SL_StatusTextBox(txtRFPowerRight)
            Dim stbRFReflectedRight As New SL_StatusTextBox(txtRFReflectedRight)
            Dim stbKFactorRight As New SL_StatusTextBox(txtKFactorRight)
            Dim stbPBNBodyRight As New SL_StatusTextBox(txtPBNBodyRight)
            Dim stbPBNDischRight As New SL_StatusTextBox(txtPBNDischRight)
            Dim stbPBNGasRight_SourceTabStatus As New SL_StatusTextBox(txtPBNGasRight_SourceTab)
            Dim stbGas1Right_SourceTabStatus As New SL_StatusTextBox(txtGas1Right_SourceTab)
            Dim stbGas2Right_SourceTabStatus As New SL_StatusTextBox(txtGas2Right_SourceTab)
            Dim stbGas3Right_SourceTabStatus As New SL_StatusTextBox(txtGas3Right_SourceTab)
            Dim stbGas4Right_SourceTabStatus As New SL_StatusTextBox(txtGas4Right_SourceTab)
            Dim sbtAutoBeamStatus As New SL_StatusButton(btnAutoBeam)
            Dim sbtSourceManual As New SL_StatusButton(btnSourceManual)
            Dim sbtSourceAuto As New SL_StatusButton(btnSourceAuto)
            'Process Status tab
            Dim stbRecipe As New SL_StatusTextBox(txtRecipe)
            Dim stbRemainingTime As New SL_StatusTextBox(txtRemainingTime)
            Dim stbElapsedTime As New SL_StatusTextBox(txtElapsedTime)
            Dim stbProcessStep As New SL_StatusTextBox(txtProcessStep)
            Dim stbStepTime As New SL_StatusTextBox(txtStepTime)
            Dim stbTotalStepStatus As New SL_StatusTextBox(txtTotalStep)
            Dim stbSourceMinutesStatus As New SL_StatusTextBox(txtSourceMinutes)
            'Gas tab
            Dim stbGasPBN As New SL_StatusTextBox(txtPBNGas)
            Dim stbGas1 As New SL_StatusTextBox(txtGas1)
            Dim stbGas2 As New SL_StatusTextBox(txtGas2)
            Dim stbGas3 As New SL_StatusTextBox(txtGas3)
            Dim stbGas4 As New SL_StatusTextBox(txtGas4)

            Dim stbGasPBNRight As New SL_StatusTextBox(txtPBNGasRight)
            Dim stbGas1Right As New SL_StatusTextBox(txtGas1Right)
            Dim stbGas2Right As New SL_StatusTextBox(txtGas2Right)
            Dim stbGas3Right As New SL_StatusTextBox(txtGas3Right)
            Dim stbGas4Right As New SL_StatusTextBox(txtGas4Right)

            Dim stbForelineStatus As New SL_StatusTextBox(txtForelineCG)
            Dim stbRoughlineStatus As New SL_StatusTextBox(txtRoughlineCG)
            Dim stbMGStatus As New SL_StatusTextBox(txtMG)
            Dim stbStatus As New SL_StatusTextBox(txtStatus)

            Dim sbcValveShutoffGasPBNStatus As New StatusBinaryStatusControl(ValveShutoffPBNGas)
            Dim sbcValveShutoffGas1Status As New StatusBinaryStatusControl(ValveShutoffGas1)
            Dim sbcValveShutoffGas2Status As New StatusBinaryStatusControl(ValveShutoffGas2)
            Dim sbcValveShutoffGas3Status As New StatusBinaryStatusControl(ValveShutoffGas3)
            Dim sbcValveShutoffGas4Status As New StatusBinaryStatusControl(ValveShutoffGas4)
            Dim sbcValveSupplyGasPBNStatus As New StatusBinaryStatusControl(ValveSupplyPBNGas)
            Dim sbcValveSupplyGas1Status As New StatusBinaryStatusControl(ValveSupplyGas1)
            Dim sbcValveSupplyGas2Status As New StatusBinaryStatusControl(ValveSupplyGas2)
            Dim sbcValveSupplyGas3Status As New StatusBinaryStatusControl(ValveSupplyGas3)
            Dim sbcValveSupplyGas4Status As New StatusBinaryStatusControl(ValveSupplyGas4)
            'Valve
            Dim sbcIsolationValveStatus As New StatusBinaryStatusControl(ValveIGIsolation)
            Dim sbcDiverterValveStatus As New StatusBinaryStatusControl(ValveDiverter)
            Dim sbcVentValveStatus As New StatusBinaryStatusControl(ValveVent)
            Dim sbcRoughValveStatus As New StatusBinaryStatusControl(ValveRough)
            Dim sbcForelineValveStatus As New StatusBinaryStatusControl(ValveForeline)
            Dim sbcRoughPumpValveStatus As New StatusBinaryStatusControl(RoughPump)
            Dim sbcFixtureWaterValveStatus As New StatusBinaryStatusControl(ValveFixtureWater)
            'Menu item
            Dim smnuCoolingWaterStatus As New SL_StatusToolStripMenuItemTextChanged(mnuCoolingWater)
            Dim smnuStartRotationStatus As New SL_StatusToolStripMenuItemTextChanged(mnuStartRotation)
            Dim smnuHomeRotationStatus As New SL_StatusToolStripMenuItemTextChanged(mnuHomeRotation)
            'Unprotected
            Dim sbtUnprotectedStatus As New SL_StatusButton(btnUnProtected)
            Dim stbWaferCount As New StatusTextBox(txtPMWaferCount)
            Dim stbShieldQuart As New StatusTextBox(txtShieldQuart)
            Dim slbSequenceRunningStatus As New SL_StatusLabel(lblNameOfSequenceRunning)
            Dim stb_PumpRelay As New StatusTurboRelayIndicator(btnRelayIndicatorPump)
            Dim slbCurrentPurgeCycle As New StatusLabel(lblCurrentPurgeCycle)
            Dim slGridSerialNumber As New SL_StatusTextBox(txtGridSerialNumber)
            Dim slGridID As New SL_StatusTextBox(txtGridID)
            Dim slPBNMinutes As New SL_StatusTextBox(txtPBNMinutes)
            Dim slSourceMinutesMaint As New SL_StatusTextBox(txtSourceMinutesMaint)
            '' Source EM PS
            Dim stbSourceEMCurrentSP As New SL_StatusTextBox(txtSourceEMCurrentRight_SourceTab)
            Dim stbSourceEMCurrentRB As New SL_StatusTextBox(txtSourceEMCurrent_SourceTab)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stb_PumpRelay)
            m_stoStatusObject.AddChild(stbShieldQuart)
            m_stoStatusObject.AddChild(stbWaferCount)
            m_stoStatusObject.AddChild(SLPowerPanel.Status)
            m_stoStatusObject.AddChild(SLContainerBox.Status)
            m_stoStatusObject.AddChild(SLStatusPanel.Status)
            m_stoStatusObject.AddChild(SLInterlocks.Status)
            m_stoStatusObject.AddChild(SLFLCG.Status)
            m_stoStatusObject.AddChild(SLRLCG.Status)
            m_stoStatusObject.AddChild(SLFixture.Status)
            m_stoStatusObject.AddChild(SLIGCGControl.Status)
            m_stoStatusObject.AddChild(SL_SourceUsage.Status)
            m_stoStatusObject.AddChild(Me.RunRecipe.Status)
            m_stoStatusObject.AddChild(Me.m_CGGaugesFrm.Status)
            m_stoStatusObject.AddChild(Me.m_MPCGGaugesFrm.Status)
            m_stoStatusObject.AddChild(Me.m_FLCGGaugesFrm.Status)
            m_stoStatusObject.AddChild(EMPowerSupply.Status)

            'm_stoStatusObject.AddChild(stbReconnect)
            m_stoStatusObject.AddChild(stbBeamVoltage)
            m_stoStatusObject.AddChild(stbBeamCurrent)
            m_stoStatusObject.AddChild(stbSuppressorVoltage)
            m_stoStatusObject.AddChild(stbSuppressorCurrent)
            m_stoStatusObject.AddChild(stbRFPower)
            m_stoStatusObject.AddChild(stbRFReflected)
            m_stoStatusObject.AddChild(stbKFactor)
            m_stoStatusObject.AddChild(stbANC)
            m_stoStatusObject.AddChild(stbPBNBody)
            m_stoStatusObject.AddChild(stbPBNDisch)
            m_stoStatusObject.AddChild(stbPBNBodyVolt)
            m_stoStatusObject.AddChild(stbPBNDischVolt)
            m_stoStatusObject.AddChild(stbPBNGas_SourceTabStatus)
            m_stoStatusObject.AddChild(stbGas1_SourceTabStatus)
            m_stoStatusObject.AddChild(stbGas2_SourceTabStatus)
            m_stoStatusObject.AddChild(stbGas3_SourceTabStatus)
            m_stoStatusObject.AddChild(stbGas4_SourceTabStatus)

            m_stoStatusObject.AddChild(stbBeamVoltageRight)
            m_stoStatusObject.AddChild(stbBeamCurrentRight)
            m_stoStatusObject.AddChild(stbSuppressorVoltageRight)
            m_stoStatusObject.AddChild(stbSuppressorCurrentRight)
            m_stoStatusObject.AddChild(stbRFPowerRight)
            m_stoStatusObject.AddChild(stbRFReflectedRight)
            m_stoStatusObject.AddChild(stbKFactorRight)
            m_stoStatusObject.AddChild(stbPBNBodyRight)
            m_stoStatusObject.AddChild(stbPBNDischRight)
            m_stoStatusObject.AddChild(stbPBNGasRight_SourceTabStatus)
            m_stoStatusObject.AddChild(stbGas1Right_SourceTabStatus)
            m_stoStatusObject.AddChild(stbGas2Right_SourceTabStatus)
            m_stoStatusObject.AddChild(stbGas3Right_SourceTabStatus)
            m_stoStatusObject.AddChild(stbGas4Right_SourceTabStatus)
            m_stoStatusObject.AddChild(sbtAutoBeamStatus)
            m_stoStatusObject.AddChild(sbtSourceManual)
            m_stoStatusObject.AddChild(sbtSourceAuto)

            'Maint
            m_stoStatusObject.AddChild(stbPBNRB)
            m_stoStatusObject.AddChild(stbSourceRB)
            m_stoStatusObject.AddChild(stbShieldRB)
            m_stoStatusObject.AddChild(stbFixtureCoverRB)
            m_stoStatusObject.AddChild(stbWaferClampRB)
            m_stoStatusObject.AddChild(stbGridSourceRB)
            m_stoStatusObject.AddChild(stbSourceUsedRB)
            m_stoStatusObject.AddChild(stbLinerRB)
            m_stoStatusObject.AddChild(stbCryoRB)
            m_stoStatusObject.AddChild(stbFixtureRotationRB)
            m_stoStatusObject.AddChild(stbWaterJournalRB)

            'Source
            m_stoStatusObject.AddChild(stbForelineStatus)
            m_stoStatusObject.AddChild(stbRoughlineStatus)
            m_stoStatusObject.AddChild(stbMGStatus)
            m_stoStatusObject.AddChild(sbcConnectionStatus)
            m_stoStatusObject.AddChild(slGridSerialNumber)
            m_stoStatusObject.AddChild(slGridID)
            m_stoStatusObject.AddChild(slPBNMinutes)
            m_stoStatusObject.AddChild(slSourceMinutesMaint)

            txtBeamVoltage.ParentStatusObj = m_stoStatusObject
            txtBeamCurrent.ParentStatusObj = m_stoStatusObject
            txtSuppressorVoltage.ParentStatusObj = m_stoStatusObject
            txtSuppressorCurrent.ParentStatusObj = m_stoStatusObject
            txtRFPower.ParentStatusObj = m_stoStatusObject
            txtRFReflected.ParentStatusObj = m_stoStatusObject
            txtKFactor.ParentStatusObj = m_stoStatusObject
            txtPBNBody.ParentStatusObj = m_stoStatusObject
            txtPBNDisch.ParentStatusObj = m_stoStatusObject
            txtPBNGas_SourceTab.ParentStatusObj = m_stoStatusObject
            txtGas1_SourceTab.ParentStatusObj = m_stoStatusObject
            txtGas2_SourceTab.ParentStatusObj = m_stoStatusObject
            txtGas3_SourceTab.ParentStatusObj = m_stoStatusObject
            txtGas4_SourceTab.ParentStatusObj = m_stoStatusObject
            txtGridSerialNumber.ParentStatusObj = m_stoStatusObject
            txtGridID.ParentStatusObj = m_stoStatusObject
            txtPBNMinutes.ParentStatusObj = m_stoStatusObject
            txtSourceMinutesMaint.ParentStatusObj = m_stoStatusObject
            txtShieldQuartSP.ParentStatusObj = m_stoStatusObject
            txtCoverFixtureShieldUsageSP.ParentStatusObj = m_stoStatusObject
            txtWaferClampUsageSP.ParentStatusObj = m_stoStatusObject
            txtTopFixtureShieldUsageSP.ParentStatusObj = m_stoStatusObject
            txtShutterUsageSP.ParentStatusObj = m_stoStatusObject
            txtLinerSP.ParentStatusObj = m_stoStatusObject
            txtCryoUsageSP.ParentStatusObj = m_stoStatusObject
            txtFixtureRotationMotorUsageSP.ParentStatusObj = m_stoStatusObject
            txtWaterJournalSP.ParentStatusObj = m_stoStatusObject

            txtBeamVoltageRight.ParentStatusObj = m_stoStatusObject
            txtBeamCurrentRight.ParentStatusObj = m_stoStatusObject
            txtSuppressorVoltageRight.ParentStatusObj = m_stoStatusObject
            txtSuppressorCurrentRight.ParentStatusObj = m_stoStatusObject
            txtRFPowerRight.ParentStatusObj = m_stoStatusObject
            txtRFReflectedRight.ParentStatusObj = m_stoStatusObject
            txtKFactorRight.ParentStatusObj = m_stoStatusObject
            txtPBNBodyRight.ParentStatusObj = m_stoStatusObject
            txtPBNDischRight.ParentStatusObj = m_stoStatusObject
            txtPBNGasRight_SourceTab.ParentStatusObj = m_stoStatusObject
            txtGas1Right_SourceTab.ParentStatusObj = m_stoStatusObject
            txtGas2Right_SourceTab.ParentStatusObj = m_stoStatusObject
            txtGas3Right_SourceTab.ParentStatusObj = m_stoStatusObject
            txtGas4Right_SourceTab.ParentStatusObj = m_stoStatusObject
            btnAutoBeam.ParentStatusObj = m_stoStatusObject
            btnSourceAuto.ParentStatusObj = m_stoStatusObject
            btnSourceManual.ParentStatusObj = m_stoStatusObject
            txtForelineCG.ParentStatusObj = m_stoStatusObject
            txtRoughlineCG.ParentStatusObj = m_stoStatusObject
            txtMG.ParentStatusObj = m_stoStatusObject

            m_stoStatusObject.AddChild(stbRecipe)
            m_stoStatusObject.AddChild(stbRemainingTime)
            m_stoStatusObject.AddChild(stbElapsedTime)
            m_stoStatusObject.AddChild(stbProcessStep)
            m_stoStatusObject.AddChild(stbStepTime)
            m_stoStatusObject.AddChild(stbTotalStepStatus)
            m_stoStatusObject.AddChild(stbSourceMinutesStatus)
            m_stoStatusObject.AddChild(m_PopUpPanel.Status)
            m_stoStatusObject.AddChild(m_CryoPopUpPanel.Status)
            m_stoStatusObject.AddChild(stbStatus)

            txtStatus.ParentStatusObj = m_stoStatusObject
            txtRecipe.ParentStatusObj = m_stoStatusObject
            txtRemainingTime.ParentStatusObj = m_stoStatusObject
            txtElapsedTime.ParentStatusObj = m_stoStatusObject
            txtProcessStep.ParentStatusObj = m_stoStatusObject
            txtStepTime.ParentStatusObj = m_stoStatusObject
            txtTotalStep.ParentStatusObj = m_stoStatusObject
            txtSourceMinutes.ParentStatusObj = m_stoStatusObject

            m_stoStatusObject.AddChild(stbGas1)
            m_stoStatusObject.AddChild(stbGas2)
            m_stoStatusObject.AddChild(stbGas3)
            m_stoStatusObject.AddChild(stbGas4)
            m_stoStatusObject.AddChild(stbGasPBN)

            m_stoStatusObject.AddChild(stbGas1Right)
            m_stoStatusObject.AddChild(stbGas2Right)
            m_stoStatusObject.AddChild(stbGas3Right)
            m_stoStatusObject.AddChild(stbGas4Right)
            m_stoStatusObject.AddChild(stbGasPBNRight)

            txtPBNGas.ParentStatusObj = m_stoStatusObject
            txtGas1.ParentStatusObj = m_stoStatusObject
            txtGas2.ParentStatusObj = m_stoStatusObject
            txtGas3.ParentStatusObj = m_stoStatusObject
            txtGas4.ParentStatusObj = m_stoStatusObject

            txtPBNGasRight.ParentStatusObj = m_stoStatusObject
            txtGas1Right.ParentStatusObj = m_stoStatusObject
            txtGas2Right.ParentStatusObj = m_stoStatusObject
            txtGas3Right.ParentStatusObj = m_stoStatusObject
            txtGas4Right.ParentStatusObj = m_stoStatusObject

            m_stoStatusObject.AddChild(sbcValveShutoffGas1Status)
            m_stoStatusObject.AddChild(sbcValveShutoffGas2Status)
            m_stoStatusObject.AddChild(sbcValveShutoffGas3Status)
            m_stoStatusObject.AddChild(sbcValveShutoffGas4Status)
            m_stoStatusObject.AddChild(sbcValveShutoffGasPBNStatus)
            m_stoStatusObject.AddChild(sbcValveSupplyGas1Status)
            m_stoStatusObject.AddChild(sbcValveSupplyGas2Status)
            m_stoStatusObject.AddChild(sbcValveSupplyGas3Status)
            m_stoStatusObject.AddChild(sbcValveSupplyGas4Status)
            m_stoStatusObject.AddChild(sbcValveSupplyGasPBNStatus)

            m_stoStatusObject.AddChild(sbcIsolationValveStatus)
            m_stoStatusObject.AddChild(sbcDiverterValveStatus)
            m_stoStatusObject.AddChild(sbcVentValveStatus)
            m_stoStatusObject.AddChild(sbcRoughValveStatus)
            m_stoStatusObject.AddChild(sbcForelineValveStatus)
            m_stoStatusObject.AddChild(sbcRoughPumpValveStatus)
            m_stoStatusObject.AddChild(sbcFixtureWaterValveStatus)

            m_stoStatusObject.AddChild(smnuCoolingWaterStatus)
            m_stoStatusObject.AddChild(smnuStartRotationStatus)
            m_stoStatusObject.AddChild(smnuHomeRotationStatus)

            m_stoStatusObject.AddChild(sbtUnprotectedStatus)
            btnUnProtected.ParentStatusObj = m_stoStatusObject

            txtSourceEMCurrent_SourceTab.ParentStatusObj = m_stoStatusObject
            txtSourceEMCurrentRight_SourceTab.ParentStatusObj = m_stoStatusObject

            ' Add chiller control
            m_stoStatusObject.AddChild(ChillerControl.Status)

            m_stoStatusObject.AddChild(slbSequenceRunningStatus)
            m_stoStatusObject.AddChild(slbCurrentPurgeCycle)

            m_stoStatusObject.AddChild(stbSourceEMCurrentSP)
            m_stoStatusObject.AddChild(stbSourceEMCurrentRB)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Public methods"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-01-19</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of SLPopUpPanel
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PopUpPanel() As SL_PopUpPanel
        Get
            Return m_PopUpPanel
        End Get
    End Property

    Public ReadOnly Property CryoPopUpPanel() As CryoPopUpPanel
        Get
            Return m_CryoPopUpPanel
        End Get
    End Property
    ''' <author>
    '''    	<name> Van Le </name>
    '''    	<date> 2014-09-04</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of CGGaugesFrm
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CGGaugesFrm() As CGGaugesFrm
        Get
            Return m_CGGaugesFrm
        End Get
    End Property


    ''' <author>
    '''    	<name> Van Le </name>
    '''    	<date> 2014-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of CGGaugesFrm
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MPCGGaugesFrm() As CGGaugesFrm
        Get
            Return m_MPCGGaugesFrm
        End Get
    End Property


    ''' <author>
    '''    	<name> Van Le </name>
    '''    	<date> 2014-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of CGGaugesFrm
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FLCGGaugesFrm() As CGGaugesFrm
        Get
            Return m_FLCGGaugesFrm
        End Get
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub CheckPermission(ByVal PERMISSION_Code As String)
        AVPLib.Log.guiLogger.Info("Enter CheckPermission")
        Try
            If AVPLib.ContainerData.Permission(PERMISSION_Code) Then
                ActiveForm()
            Else
                InactiveForm()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CheckPermission")
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-02-22</date>
    ''' </author>
    ''' <summary>
    ''' Disable/Enable control when online/offline
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetOnlineOfflinePM(ByVal blnIsOnline As Boolean)

        If blnIsOnline Then
            InactiveForm()
            If AVPLib.ContainerData.Permission(PERMISSION_001) Then
                SLContainerBox.Enabled = True
            End If
            Me.IsOnline = True
        Else
            Me.IsOnline = False
            If AVPLib.ContainerData.Permission(PERMISSION_001) Then
                ActiveForm()
            End If
        End If
        SLContainerBox.SetOnlineOfflineContainerBox(blnIsOnline)
        m_PopUpPanel.SetOnlineOfflinePopUp(blnIsOnline)
        m_CryoPopUpPanel.DeviceOnline = blnIsOnline
    End Sub

    Friend Sub Online_OfflineValveStatus(ByVal blnEnableStatus As Boolean, ByVal blnIsMenuOnlineClick As Boolean)

    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-22-23</date>
    ''' </author>
    ''' <summary>
    ''' Set default status to show on GUI when PM disconnect.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaultStatus()
        'Power panel
        SLPowerPanel.SetDefaultStatus()
        'Status panel
        SLStatusPanel.SetDefaultStatus()
        'Interlocks
        SLInterlocks.SetDefaultStatus()
        'PM
        txtRoughlineCG.Text = String.Empty
        txtForelineCG.Text = String.Empty
        txtMG.Text = String.Empty
        SLContainerBox.SetDefaultStatus()
        ValveForeline.Status = BinaryStatusControl.DisplayStatus.Off
        ValveRough.Status = BinaryStatusControl.DisplayStatus.Off
        ValveVent.Status = BinaryStatusControl.DisplayStatus.Off
        ValveIGIsolation.Status = BinaryStatusControl.DisplayStatus.Off
        ValveDiverter.Status = BinaryStatusControl.DisplayStatus.Off
        ValveFixtureWater.Status = BinaryStatusControl.DisplayStatus.Off
        RoughPump.Status = BinaryStatusControl.DisplayStatus.Off
        SLPM.SetDefaultStatus()
        btnUnProtected.Status = SL_CustomButton.DisplayStatus.Off
        'tab Source
        txtBeamVoltage.Text = String.Empty
        txtBeamVoltageRight.Text = String.Empty
        txtBeamCurrent.Text = String.Empty
        txtBeamCurrentRight.Text = String.Empty
        txtSuppressorVoltage.Text = String.Empty
        txtSuppressorVoltageRight.Text = String.Empty
        txtSuppressorCurrent.Text = String.Empty
        txtSuppressorCurrentRight.Text = String.Empty
        txtRFPower.Text = String.Empty
        txtRFPowerRight.Text = String.Empty
        txtRFReflected.Text = String.Empty
        txtRFReflectedRight.Text = String.Empty
        txtPBNGas_SourceTab.Text = String.Empty
        txtPBNGasRight_SourceTab.Text = String.Empty
        txtGas1_SourceTab.Text = String.Empty
        txtGas1Right_SourceTab.Text = String.Empty
        txtGas2_SourceTab.Text = String.Empty
        txtGas2Right_SourceTab.Text = String.Empty
        txtGas3_SourceTab.Text = String.Empty
        txtGas3Right_SourceTab.Text = String.Empty
        txtGas4_SourceTab.Text = String.Empty
        txtGas4Right_SourceTab.Text = String.Empty
        txtKFactor.Text = String.Empty
        txtKFactorRight.Text = String.Empty
        txtPBNDisch.Text = String.Empty
        txtPBNDischRight.Text = String.Empty
        txtPBNBody.Text = String.Empty
        txtPBNBodyRight.Text = String.Empty
        btnSourceManual.Status = SL_CustomButton.DisplayStatus.Off
        btnSourceAuto.Status = SL_CustomButton.DisplayStatus.Off
        btnAutoBeam.Status = SL_CustomButton.DisplayStatus.Off
        'tab Process status
        txtRecipe.Text = String.Empty
        txtWaferID.Text = String.Empty
        txtRemainingTime.Text = String.Empty
        txtElapsedTime.Text = String.Empty
        txtProcessStep.Text = String.Empty
        txtStatus.Text = String.Empty
        txtSourceMinutes.Text = String.Empty
        'tab Gas
        txtGas1.Text = String.Empty
        txtGas1Right.Text = String.Empty
        txtGas2.Text = String.Empty
        txtGas2Right.Text = String.Empty
        txtGas3.Text = String.Empty
        txtGas3Right.Text = String.Empty
        txtGas4.Text = String.Empty
        txtGas4Right.Text = String.Empty
        txtPBNGas.Text = String.Empty
        txtPBNGasRight.Text = String.Empty
        ValveSupplyGas1.Status = BinaryStatusControl.DisplayStatus.Off
        ValveShutoffGas1.Status = BinaryStatusControl.DisplayStatus.Off
        ValveSupplyGas2.Status = BinaryStatusControl.DisplayStatus.Off
        ValveShutoffGas2.Status = BinaryStatusControl.DisplayStatus.Off
        ValveSupplyGas3.Status = BinaryStatusControl.DisplayStatus.Off
        ValveShutoffGas3.Status = BinaryStatusControl.DisplayStatus.Off
        ValveSupplyGas4.Status = BinaryStatusControl.DisplayStatus.Off
        ValveShutoffGas4.Status = BinaryStatusControl.DisplayStatus.Off
        ValveSupplyPBNGas.Status = BinaryStatusControl.DisplayStatus.Off
        ValveShutoffPBNGas.Status = BinaryStatusControl.DisplayStatus.Off

        ''Source EM
        txtSourceEMCurrent_SourceTab.Text = String.Empty
        txtSourceEMCurrentRight_SourceTab.Text = String.Empty

        'Fixture
        SLFixture.SetDefaultStatus()
        'PopUp panel
        m_PopUpPanel.SetDefaultStatus()
        InactiveForm()
    End Sub

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2019-03-14</date>
    ''' </author>
    ''' <summary>
    ''' Set Location Of Label IGIsolation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetLabelIGIsolation(ByVal FullInstall As Boolean)
        If FullInstall Then
            lblIGIsolation.Location = New Point(701, 115)
        Else
            lblIGIsolation.Location = New Point(620, 145)
        End If
    End Sub

    Public Sub SetGas1Info(ByVal strGasType As String, ByVal blShutoffPresent As Boolean, _
                ByVal blSupplyPresent As Boolean)

        SetGasLine1Visible(blShutoffPresent, blSupplyPresent)
        Gas1Type = strGasType
    End Sub

    Public Sub SetGas2Info(ByVal strGasType As String, ByVal blShutoffPresent As Boolean, _
                ByVal blSupplyPresent As Boolean)

        SetGasLine2Visible(blShutoffPresent, blSupplyPresent)
        Gas2Type = strGasType
    End Sub

    Public Sub SetGas3Info(ByVal strGasType As String, ByVal blShutoffPresent As Boolean, _
                ByVal blSupplyPresent As Boolean)

        SetGasLine3Visible(blShutoffPresent, blSupplyPresent)
        Gas3Type = strGasType
    End Sub

    Public Sub SetGas4Info(ByVal strGasType As String, ByVal blShutoffPresent As Boolean, _
                ByVal blSupplyPresent As Boolean)

        SetGasLine4Visible(blShutoffPresent, blSupplyPresent)
        Gas4Type = strGasType
    End Sub

    Public Sub SetPBNGasInfo(ByVal strGasType As String)
        PBNGasType = strGasType
    End Sub

    Protected Overridable Sub SetGasLine1Visible(ByVal blShutoffPresent As Boolean, _
                                                 ByVal blSupplyPresent As Boolean)
        SetGasLineVisible(blShutoffPresent, blSupplyPresent, GasLine_Supply1, Gas1ShutoffVisible, Gas1SupplyVisible)
    End Sub
    Protected Overridable Sub SetGasLine2Visible(ByVal blShutoffPresent As Boolean, _
                                                 ByVal blSupplyPresent As Boolean)
        SetGasLineVisible(blShutoffPresent, blSupplyPresent, GasLine_Supply2, Gas2ShutoffVisible, Gas2SupplyVisible)
    End Sub
    Protected Overridable Sub SetGasLine3Visible(ByVal blShutoffPresent As Boolean, _
                                                 ByVal blSupplyPresent As Boolean)
        SetGasLineVisible(blShutoffPresent, blSupplyPresent, GasLine_Supply3, Gas3ShutoffVisible, Gas3SupplyVisible)
    End Sub
    Protected Overridable Sub SetGasLine4Visible(ByVal blShutoffPresent As Boolean, _
                                                 ByVal blSupplyPresent As Boolean)
        SetGasLineVisible(blShutoffPresent, blSupplyPresent, GasLine_Supply4, Gas4ShutoffVisible, Gas4SupplyVisible)
    End Sub

    Protected Overridable Sub SetGasLineVisible( _
                ByVal blShutoffPresent As Boolean, _
                ByVal blSupplyPresent As Boolean, _
                ByVal GasLine_Supply As AnimationControl, _
                ByRef blShutoffGasVisible As Boolean, _
                ByRef blSupplyGasVisible As Boolean)

        blShutoffGasVisible = blShutoffPresent
        blSupplyGasVisible = blSupplyPresent
        GasLine_Supply.Visible = blSupplyPresent

        'This is the special case
        If (blShutoffPresent = False And blSupplyPresent = True) Then
            GasLine_Supply.Location = New Point(14, GasLine_Supply.Location.Y)
            GasLine_Supply.Size = New Size(301, GasLine_Supply.Size.Height)
        End If
    End Sub

    Public Sub SetGasLineTotalVisible()
        If Not Gas4ShutoffVisible And Not Gas4SupplyVisible Then
            blnGasLineTotal4Enabled = False
            GasLine3_Total_Below.Visible = False
            txtGas4.Visible = False
            txtGas4Right.Visible = False
            lblGas4.Visible = False
            txtGas4Right_SourceTab.IsReadBack = True
            txtGas4Right_SourceTab.TabIndex = ConstantAndEnum.TAB_INDEX_NO_FOCUS
            lblSourceGas4.Enabled = False
        End If

        If Not Gas3ShutoffVisible And Not Gas3SupplyVisible Then
            txtGas3.Visible = False
            txtGas3Right.Visible = False
            lblGas3.Visible = False
            txtGas3Right_SourceTab.IsReadBack = True
            txtGas3Right_SourceTab.TabIndex = ConstantAndEnum.TAB_INDEX_NO_FOCUS
            lblSourceGas3.Enabled = False
            If Not blnGasLineTotal4Enabled Then
                blnGasLineTotal3Enabled = False
                GasLine2_Total_Below.Visible = False
                GasLine3_Total.Visible = False
            End If
        End If

        If Not Gas2ShutoffVisible And Not Gas2SupplyVisible Then
            txtGas2.Visible = False
            txtGas2Right.Visible = False
            lblGas2.Visible = False
            txtGas2Right_SourceTab.IsReadBack = True
            txtGas2Right_SourceTab.TabIndex = ConstantAndEnum.TAB_INDEX_NO_FOCUS
            lblSourceGas2.Enabled = False

            If Not blnGasLineTotal4Enabled AndAlso Not blnGasLineTotal3Enabled Then
                blnGasLineTotal2Enabled = False
                GasLine1_Total_Below.Visible = False
                GasLine2_Total.Visible = False
            End If
        End If

        If Not Gas1ShutoffVisible And Not Gas1SupplyVisible Then
            txtGas1.Visible = False
            txtGas1Right.Visible = False
            lblGas1.Visible = False
            txtGas1Right_SourceTab.IsReadBack = True
            txtGas1Right_SourceTab.TabIndex = ConstantAndEnum.TAB_INDEX_NO_FOCUS
            lblSourceGas1.Enabled = False

            If Not blnGasLineTotal4Enabled AndAlso Not blnGasLineTotal3Enabled AndAlso Not blnGasLineTotal2Enabled Then
                blnGasLineTotal1Enabled = False
                GasLine_Total1.Visible = False
                GasLine1_Total.Visible = False
            End If
        End If

        If Not blnGasLineTotal4Enabled AndAlso Not blnGasLineTotal3Enabled AndAlso Not blnGasLineTotal2Enabled AndAlso Not blnGasLineTotal1Enabled Then
            GasLine_Total.Visible = False
            blnGasLineTotalEnabled = False
        End If
    End Sub

    Public Sub GetGasEndIndex()
        If Gas4SupplyVisible OrElse Gas4ShutoffVisible Then
            m_iGasEndIndex = 4
        ElseIf Gas3SupplyVisible OrElse Gas3ShutoffVisible Then
            m_iGasEndIndex = 3
            GasLine_Shutoff3.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End
            GasLine_Shutoff3.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End_On
            GasLine_Shutoff3.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End_On_1
            GasLine3_Total.Visible = False
            GasLine_Shutoff3.Location = New Point(GasLine3_Total.Location.X, GasLine3_Total.Location.Y)
        ElseIf Gas2SupplyVisible OrElse Gas2ShutoffVisible Then
            m_iGasEndIndex = 2
            If DiverterGasValveInstalled = False Then
                GasLine_Shutoff2.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End
                GasLine_Shutoff2.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End_On
                GasLine_Shutoff2.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End_On_1
                GasLine2_Total.Visible = False
                GasLine_Shutoff2.Location = New Point(GasLine2_Total.Location.X, GasLine2_Total.Location.Y)
            End If

        ElseIf Gas1SupplyVisible OrElse Gas1ShutoffVisible Then
            m_iGasEndIndex = 1
            GasLine_Shutoff1.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End
            GasLine_Shutoff1.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End_On
            GasLine_Shutoff1.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End_On_1
            GasLine1_Total.Visible = False
            GasLine_Shutoff1.Location = New Point(GasLine1_Total.Location.X, GasLine1_Total.Location.Y)
        End If
    End Sub

    Public Sub SetInternalShutterVisible(ByVal visible As Boolean)
        SLContainerBox.stInternalShutter.Visible = visible
        SLContainerBox.stInternalShutterOff.Visible = visible
        SLContainerBox.lblOn.Visible = visible
        SLContainerBox.lblOff.Visible = visible
        SLContainerBox.lblInternalShutter.Visible = visible
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    Private Sub txtForelineCG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtForelineCG.Click
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If txtForelineCG.Enabled = False Or (Not PM_DeviceNet) Then
                    Return
                End If
                Dim objChamber As AVPLib.DataManagerment.IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
                If FLCGGaugesFrm IsNot Nothing AndAlso objChamber IsNot Nothing Then
                    FLCGGaugesFrm.IsSetATM = IIf(objChamber.EnableForelineCGATM = AVPLib.DataManagerment.Equipment.WorkingStatuses.On, True, False)
                    FLCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
                    FLCGGaugesFrm.ShowDialog(AVPRobotMain)
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for Valve Click (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ValveControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
     Handles ValveVent.Click, ValveRough.Click, ValveForeline.Click, ValveShutoffPBNGas.Click, ValveShutoffGas1.Click, ValveShutoffGas2.Click, _
            ValveShutoffGas3.Click, ValveSupplyPBNGas.Click, ValveSupplyGas1.Click, ValveSupplyGas2.Click, _
            ValveSupplyGas3.Click, RoughPump.Click, ValveFixtureWater.Click, ValveShutoffGas4.Click, ValveSupplyGas4.Click, _
        ValveIGIsolation.Click, ValveDiverter.Click
        Dim ValveCtl As ValveControl = CType(sender, ValveControl)
        Dim strTitleMessage As String = String.Empty
        strTitleMessage = Me.Tag
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            If ValveCtl.Name = RoughPump.Name Then
                If (Not PM_DeviceNet) Then
                    Return
                End If
                Dim objChamber As AVPLib.DataManagerment.IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
                If MPCGGaugesFrm IsNot Nothing AndAlso objChamber IsNot Nothing Then
                    MPCGGaugesFrm.IsSetATM = IIf(objChamber.EnableRoughCGATM = AVPLib.DataManagerment.Equipment.WorkingStatuses.On, True, False)
                    MPCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
                    MPCGGaugesFrm.ShowDialog(AVPRobotMain)
                End If

            Else
                SL_Support.ValveClick(sender, e, strTitleMessage, ValveCtl.Name, m_stoStatusObject)
            End If
        End If
    End Sub

    Private Sub SL_ProcessModule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPBNGasRight.GasName = "PBN"
        txtGas1Right.GasName = Gas1Type
        txtGas2Right.GasName = Gas2Type
        txtGas3Right.GasName = Gas3Type
        txtGas4Right.GasName = Gas4Type
        txtPBNGasRight_SourceTab.GasName = "PBN"
        txtGas1Right_SourceTab.GasName = Gas1Type
        txtGas2Right_SourceTab.GasName = Gas2Type
        txtGas3Right_SourceTab.GasName = Gas3Type
        txtGas4Right_SourceTab.GasName = Gas4Type
        SLFixture.txtFlowCoolGasRight.GasName = "FlowCool He"
        btnSourceAuto.ValueToBeSend = STR_ON
        btnSourceManual.ValueToBeSend = STR_OFF
        lblStatusText.BackColor = Color.Transparent
        lblStatusText.Location = New Point(0, 742)
        btnUnProtected.Text = "Override Mode"
        Dim chamber As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.Name)
        ChillerControl.ChillerModel = chamber.ChillerModel
        If (chamber IsNot Nothing AndAlso chamber.Filament_Installed) Then
            Label11.Text = "PBN Filament(A)"
        End If

        If chamber.SourceMagnetVisible Then
            SLPowerPanel.Top = 5
            SLStatusPanel.Top = SLPowerPanel.Bottom + 5
            SLInterlocks.Top = SLStatusPanel.Bottom + 5
            EMPowerSupply.Top = SLInterlocks.Bottom + 5
            RunRecipe.Top = EMPowerSupply.Bottom + 5
        Else
            EMPowerSupply.Visible = False
        End If

        RoughLineTimer.Start()
    End Sub

    Private Sub btnTooltipFixture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTooltipFixture.Click
        AVPLib.Log.guiLogger.Info("Enter btnTooltipFixture_Click")
        Try
            If CType(sender, Button).Name = btnTooltipFixture.Name Then
                Dim pos As New System.Drawing.Point(Me.btnTooltipFixture.Location)
                pos.Y += Me.btnTooltipFixture.Height
                pos = Me.PointToScreen(pos)
                Me.cmstooltipFixture.Show(pos)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnTooltipFixture_Click")
    End Sub

    Private Sub mnuTooltipFixture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
         Handles mnuHomeRotation.Click, mnuStartRotation.Click, mnuCoolingWater.Click
        AVPLib.Log.guiLogger.Info("Enter mnuTooltip_Click")
        Dim strMessageText As String = String.Empty
        Dim strLogMessage As String = String.Empty
        Try
            Dim Tooltip As System.Windows.Forms.ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
            Dim Message As String = Tooltip.Name

            If Tooltip.Text = START_ROTATION_AXIS Then
                strMessageText = AVPLib.ContainerData.GetMessageText("StartRotationAxisChamberPanel")
                If (Utils.ShowAVPMessageBox(strMessageText, Me.Tag, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(Message, AVPLib.ConfigurationValues.DEVICE_STATUS_OPEN)
                    strLogMessage = "[" + STR_PROCESS_MODULE + "] Start Rotation"
                End If

            ElseIf Tooltip.Text = STOP_ROTATION_AXIS Then
                strMessageText = AVPLib.ContainerData.GetMessageText("StopRotationAxisChamberPanel")
                If (Utils.ShowAVPMessageBox(strMessageText, Me.Tag, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(Message, AVPLib.ConfigurationValues.DEVICE_STATUS_CLOSED)
                    strLogMessage = "[" + STR_PROCESS_MODULE + "] Stop Rotation"
                End If

            ElseIf Tooltip.Text = mnuHomeRotation.Text Then
                strMessageText = AVPLib.ContainerData.GetMessageText("HomeRotationAxisChamberPanel")
                If (Utils.ShowAVPMessageBox(strMessageText, Me.Tag, MessageBoxIcon.Question) = DialogResult.OK) Then
                    m_stoStatusObject.RequestStatus(Message, AVPLib.ConfigurationValues.DEVICE_STATUS_RESUMING)
                    strLogMessage = "[" + STR_PROCESS_MODULE + "] " + MNU_FIXTURE_HOME_ROTATION_AXIS
                End If

            ElseIf Tooltip.Text = STR_FLOWCOOL_COOLING_WATER_ON Then
                strMessageText = AVPLib.ContainerData.GetMessageText("TurnCoolingWaterOn")
                If Utils.ShowAVPMessageBox(strMessageText, Me.Tag, MessageBoxIcon.Question) = DialogResult.OK Then
                    m_stoStatusObject.RequestStatus(Message, AVPLib.ConfigurationValues.DEVICE_STATUS_OPEN)
                    strLogMessage = "[" + STR_PROCESS_MODULE + "] " + STR_FLOWCOOL_COOLING_WATER_ON
                End If

            ElseIf Tooltip.Text = STR_FLOWCOOL_COOLING_WATER_OFF Then
                strMessageText = AVPLib.ContainerData.GetMessageText("TurnCoolingWaterOff")
                If Utils.ShowAVPMessageBox(strMessageText, Me.Tag, MessageBoxIcon.Question) = DialogResult.OK Then
                    m_stoStatusObject.RequestStatus(Message, AVPLib.ConfigurationValues.DEVICE_STATUS_CLOSED)
                    strLogMessage = "[" + STR_PROCESS_MODULE + "] " + STR_FLOWCOOL_COOLING_WATER_OFF
                End If

            End If
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, strLogMessage)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuTooltip_Click")
    End Sub

    Private Sub AutoBeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAutoBeam.Click
        SL_Support.ButtonClick(sender, Me.Name, m_stoStatusObject)
    End Sub

    Private Sub btnUnProtected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnProtected.Click
        If btnUnProtected.Clickable Then
            SL_Support.ButtonClick(sender, Me.Name, m_stoStatusObject)
        End If
    End Sub

    Private Sub btnOpenCloseGas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenClosePBNGas.Click, _
      btnOpenCloseGas1.Click, btnOpenCloseGas2.Click, btnOpenCloseGas3.Click, btnOpenCloseGas4.Click
        Dim titleMessage = String.Empty
        titleMessage = AVPLib.Utils.chamberID2ChamberName(Me.Name)
        SL_Support.OpenCloseBothShutoffSupplyValve(sender, titleMessage, m_stoStatusObject)
    End Sub
#End Region

    Private Sub txtPBNDischRight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPBNDischRight.TextChanged

    End Sub

    Private Sub btnSourceSaveLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSourceSaveLoad.Click
        Try
            Dim dlgResult As DialogResult = Utils.ShowAVPMessageBox("Load/Save Source", AVPLib.Utils.chamberID2ChamberName(Me.Name), MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.SaveLoadLoadFromRecipeCancel) 'MessageBoxButtons.AbortRetryIgnore)
            If dlgResult = DialogResult.OK Then 'Open
                SourceSave2File()
            ElseIf dlgResult = DialogResult.No Then 'Close
                SourceLoadFromFile()
            ElseIf dlgResult = DialogResult.Yes Then
                SourceLoadFromRecipe()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2014-12-17 </date>
    ''' </author>
    ''' <summary>
    ''' Load source from recipe
    ''' </summary>
    Private Function SourceLoadFromRecipe() As Boolean
        Try
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(Me.Name)
            Dim recipeName As String = String.Empty
            Dim recipeStep As Integer
            If Utils.ShowSelectRecipeStepDialog(ChamberName, recipeName, recipeStep) = DialogResult.OK Then
                If Not recipeName.Contains(STR_XML_EXT) Then
                    recipeName = recipeName & STR_XML_EXT
                End If

                Dim ChamberModule As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(Me.Name)
                Dim selectedRecipe As AVPLib.DBChamber = Nothing
                selectedRecipe = AVPLib.ContainerData.Chamber(ChamberName, recipeName)
                If selectedRecipe Is Nothing Then
                    Utils.ShowAVPMessageBox("Can not load recipe '" & recipeName & "'", _
                            AVPLib.Utils.chamberID2ChamberName(Me.Name), MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                    Return False
                End If
                selectedRecipe.ChamberType = ChamberModule.Type.ToString()

                Dim dt As DataTable
                dt = AVPLib.ContainerData.ChamberDB(selectedRecipe, AVPLib.ContainerData.ChamberPVDType(ChamberName))
                If dt Is Nothing Then
                    Utils.ShowAVPMessageBox("Can not load data from recipe '" & recipeName & "'", _
                            AVPLib.Utils.chamberID2ChamberName(Me.Name), MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                    Return False
                End If

                Dim stepColumn As Integer = dt.Columns.Count - selectedRecipe.ListChamberSteps.Count + recipeStep - 1
                For Each row As DataRow In dt.Rows
                    Dim propName = row.Item(0).ToString()
                    propName = CType(propName, String).Split(" ")(0)
                    Dim value As String = row.Item(stepColumn).ToString()

                    Select Case propName
                        Case "Beam_Voltage"
                            txtBeamVoltageRight.Text = value
                        Case "Beam_Current"
                            txtBeamCurrentRight.Text = value
                        Case "Suppressor_Voltage", "Suppresser_Voltage"
                            txtSuppressorVoltageRight.Text = value
                        Case "RF_Power", "Incident_RF_Power"
                            txtRFPowerRight.Text = value
                        Case "PBN_Gas", "PBN_FLOWRATE"
                            txtPBNGasRight_SourceTab.Text = value
                        Case "Gas1", "Gas_1"
                            If Me.Gas1ShutoffVisible AndAlso Me.Gas1SupplyVisible Then
                                txtGas1Right_SourceTab.Text = value
                            End If
                        Case "Gas2", "Gas_2"
                            If Me.Gas2ShutoffVisible AndAlso Me.Gas2SupplyVisible Then
                                txtGas2Right_SourceTab.Text = value
                            End If
                        Case "Gas3", "Gas_3"
                            If Me.Gas3ShutoffVisible AndAlso Me.Gas3SupplyVisible Then
                                txtGas3Right_SourceTab.Text = value
                            End If
                        Case "Gas4", "Gas_4"
                            If Me.Gas4ShutoffVisible AndAlso Me.Gas4SupplyVisible Then
                                txtGas4Right_SourceTab.Text = value
                            End If
                        Case "KFactor", "K_Factor"
                            txtKFactorRight.Text = value
                        Case "Source_Electromagnet_Current"
                            txtSourceEMCurrentRight_SourceTab.Text = value
                    End Select
                Next

                ''send to device
                m_stoStatusObject.RequestStatus(txtBeamVoltageRight.Name, txtBeamVoltageRight.Text)
                m_stoStatusObject.RequestStatus(txtBeamCurrentRight.Name, Utils.Contvert_mA2A(txtBeamCurrentRight.Text))
                m_stoStatusObject.RequestStatus(txtSuppressorVoltageRight.Name, txtSuppressorVoltageRight.Text)
                m_stoStatusObject.RequestStatus(txtRFPowerRight.Name, txtRFPowerRight.Text)
                ''don't send to device if this is AVP_IBE
                If ChamberModule IsNot Nothing Then
                    '''If IBE is Veeco or AVP_IBE in Auto Beam On -> send new value
                    'If (ChamberModule.IBE_Type = IBEType.VEECO_IBE) OrElse _
                    '(ChamberModule.IBE_Type = IBEType.AVP_IBE And btnAutoBeam.Status = DisplayStatus.On) Then
                    If (ChamberModule.IBE_Type = AllChamberType.VEECO_IBE) OrElse _
                    (btnAutoBeam.Status = DisplayStatus.On) Then
                        m_stoStatusObject.RequestStatus(txtPBNGasRight_SourceTab.Name, txtPBNGasRight_SourceTab.Text)
                        m_stoStatusObject.RequestStatus(txtGas1Right_SourceTab.Name, txtGas1Right_SourceTab.Text)
                        m_stoStatusObject.RequestStatus(txtGas2Right_SourceTab.Name, txtGas2Right_SourceTab.Text)
                    End If
                End If
                '''
                m_stoStatusObject.RequestStatus(txtKFactorRight.Name, txtKFactorRight.Text)

                If ChamberModule.SourceMagnetVisible Then
                    m_stoStatusObject.RequestStatus(txtSourceEMCurrentRight_SourceTab.Name, txtSourceEMCurrentRight_SourceTab.Text)
                End If

                Return True 'Load success
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return False
    End Function

    Private Function SourceSave2File() As Boolean
        Dim ChamberModule As AVPLib.SystemModule = _
                                                   AVPLib.ContainerData.GetRobotConfig(Me.Name) ''get preset config file
        ChamberModule.IBESourceValue.Item("Beam_Voltage") = txtBeamVoltageRight.Text
        ChamberModule.IBESourceValue.Item("Beam_Current") = txtBeamCurrentRight.Text
        ChamberModule.IBESourceValue.Item("Suppressor_Voltage") = txtSuppressorVoltageRight.Text
        ChamberModule.IBESourceValue.Item("RF_Power") = txtRFPowerRight.Text

        ChamberModule.IBESourceValue.Item("PBN_Gas") = txtPBNGasRight_SourceTab.Text
        ChamberModule.IBESourceValue.Item("Gas1") = txtGas1Right_SourceTab.Text
        ChamberModule.IBESourceValue.Item("Gas2") = txtGas2Right_SourceTab.Text
        ChamberModule.IBESourceValue.Item("Gas3") = txtGas3Right_SourceTab.Text
        ChamberModule.IBESourceValue.Item("Gas4") = txtGas4Right_SourceTab.Text
        ChamberModule.IBESourceValue.Item("KFactor") = txtKFactorRight.Text

        AVPLib.Utils.SaveIBESourceValue(ChamberModule, ChamberModule.IBESourceValue)

        Return True 'save success
    End Function

    Private Function SourceLoadFromFile() As Boolean
        Dim ChamberModule As AVPLib.SystemModule = _
        AVPLib.ContainerData.GetRobotConfig(Me.Name) ''get preset config file
        txtBeamVoltageRight.Text = ChamberModule.IBESourceValue.Item("Beam_Voltage")
        txtBeamCurrentRight.Text = ChamberModule.IBESourceValue.Item("Beam_Current")
        txtSuppressorVoltageRight.Text = ChamberModule.IBESourceValue.Item("Suppressor_Voltage")
        txtRFPowerRight.Text = ChamberModule.IBESourceValue.Item("RF_Power")

        txtPBNGasRight_SourceTab.Text = ChamberModule.IBESourceValue.Item("PBN_Gas")

        If Me.Gas1ShutoffVisible AndAlso Me.Gas1SupplyVisible Then
            txtGas1Right_SourceTab.Text = ChamberModule.IBESourceValue.Item("Gas1")
        End If

        If Me.Gas2ShutoffVisible AndAlso Me.Gas2SupplyVisible Then
            txtGas2Right_SourceTab.Text = ChamberModule.IBESourceValue.Item("Gas2")
        End If

        If Me.Gas3ShutoffVisible AndAlso Me.Gas3SupplyVisible Then
            txtGas3Right_SourceTab.Text = ChamberModule.IBESourceValue.Item("Gas3")
        End If

        If Me.Gas4ShutoffVisible AndAlso Me.Gas4SupplyVisible Then
            txtGas4Right_SourceTab.Text = ChamberModule.IBESourceValue.Item("Gas4")
        End If
        txtKFactorRight.Text = ChamberModule.IBESourceValue.Item("KFactor")

        txtSourceEMCurrentRight_SourceTab.Text = ChamberModule.IBESourceValue.Item("Source_Electromagnet_Current")

        ''send to device
        m_stoStatusObject.RequestStatus(txtBeamVoltageRight.Name, txtBeamVoltageRight.Text)
        m_stoStatusObject.RequestStatus(txtBeamCurrentRight.Name, Utils.Contvert_mA2A(txtBeamCurrentRight.Text))
        m_stoStatusObject.RequestStatus(txtSuppressorVoltageRight.Name, txtSuppressorVoltageRight.Text)
        m_stoStatusObject.RequestStatus(txtRFPowerRight.Name, txtRFPowerRight.Text)
        ''don't send to device if this is AVP_IBE
        If ChamberModule IsNot Nothing Then
            '''If IBE is Veeco or AVP_IBE in Auto Beam On -> send new value
            'If (ChamberModule.IBE_Type = IBEType.VEECO_IBE) OrElse _
            '(ChamberModule.IBE_Type = IBEType.AVP_IBE And btnAutoBeam.Status = SL_CustomButton.DisplayStatus.On) Then
            If (ChamberModule.IBE_Type = AllChamberType.VEECO_IBE) OrElse _
            (btnAutoBeam.Status = SL_CustomButton.DisplayStatus.On) Then
                m_stoStatusObject.RequestStatus(txtPBNGasRight_SourceTab.Name, txtPBNGasRight_SourceTab.Text)
                m_stoStatusObject.RequestStatus(txtGas1Right_SourceTab.Name, txtGas1Right_SourceTab.Text)
                m_stoStatusObject.RequestStatus(txtGas2Right_SourceTab.Name, txtGas2Right_SourceTab.Text)
            End If
        End If
        '''
        m_stoStatusObject.RequestStatus(txtKFactorRight.Name, txtKFactorRight.Text)

        If ChamberModule.SourceMagnetVisible Then
            m_stoStatusObject.RequestStatus(txtSourceEMCurrentRight_SourceTab.Name, txtSourceEMCurrentRight_SourceTab.Text)
        End If

        Return True 'Load success
    End Function

    Private Sub btnUnProtected_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnProtected.StatusChange
        If btnUnProtected.Status = SL_CustomButton.DisplayStatus.Off Then
            bUnProtectedClicked = False
        End If
    End Sub

    Private Sub ValveFlowCoolReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveFlowCoolReturn.Click
        Dim ValveCtl As ValveControl = CType(sender, ValveControl)
        Dim strTitleMessage As String = String.Empty
        strTitleMessage = Me.Tag
        SL_Support.ValveClick(SLFixture.ValveShutoffFlowCoolGas, e, strTitleMessage, SLFixture.ValveShutoffFlowCoolGas.Name, SLFixture.Status)
    End Sub

    '#Fix bug:
    '#-When user set gas1/2/3 SP @ Source tab,  Gas tab sp must also change and vice versa.  The 2 pictures below show different set point.
    '# Example if user autobeam with gas 2 sp = 5 and switch to gas tab,  user will see sp = 10,  which causes lots of confusion.
    '#Begin fix:
    'Private Sub txtGas1SPTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGas1Right_SourceTab.TextChanged, txtGas1Right.TextChanged
    'Dim textbox As SL_Textbox = CType(sender, SL_Textbox)
    'txtGas1Right_SourceTab.Text = textbox.Text
    'txtGas1Right.Text = textbox.Text
    'End Sub

    'Private Sub txtGas2SPTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGas2Right_SourceTab.TextChanged, txtGas2Right.TextChanged
    'Dim textbox As SL_Textbox = CType(sender, SL_Textbox)
    'txtGas2Right_SourceTab.Text = textbox.Text
    'txtGas2Right.Text = textbox.Text
    'End Sub

    'Private Sub txtGas3SPTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGas3Right_SourceTab.TextChanged, txtGas3Right.TextChanged
    'Dim textbox As SL_Textbox = CType(sender, SL_Textbox)
    'txtGas3Right_SourceTab.Text = textbox.Text
    'txtGas3Right.Text = textbox.Text
    'End Sub

    'Private Sub txtGas4SPTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGas4Right_SourceTab.TextChanged, txtGas4Right.TextChanged
    'Dim textbox As SL_Textbox = CType(sender, SL_Textbox)
    'txtGas4Right_SourceTab.Text = textbox.Text
    'txtGas4Right.Text = textbox.Text
    'End Sub

    'Private Sub txtPBNGasSPTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPBNGasRight_SourceTab.TextChanged, txtPBNGasRight.TextChanged
    'Dim textbox As SL_Textbox = CType(sender, SL_Textbox)
    'txtPBNGasRight_SourceTab.Text = textbox.Text
    'txtPBNGasRight.Text = textbox.Text
    'End Sub
    '#End fix.

    Private Sub Valve_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ValveRough.StatusChange, ValveForeline.StatusChange, ValveFlowCoolReturn.StatusChange, _
            ValveFixtureWater.StatusChange, ValveVent.StatusChange, ValveShutoffPBNGas.StatusChange, _
            ValveSupplyPBNGas.StatusChange, ValveShutoffGas1.StatusChange, ValveSupplyGas1.StatusChange, _
            ValveShutoffGas2.StatusChange, ValveSupplyGas2.StatusChange, _
            ValveShutoffGas3.StatusChange, ValveSupplyGas3.StatusChange, _
            ValveShutoffGas4.StatusChange, ValveSupplyGas4.StatusChange, _
            ValveIGIsolation.StatusChange, ValveDiverter.StatusChange
        Dim valveStatus As BinaryStatusControl.DisplayStatus = CType(sender, ValveControl).Status
        Dim gaslineStatus As DisplayStatus = Utils.ConvertToDisplayStatus(valveStatus)

        If sender Is ValveRough Then
            If valveStatus = BinaryStatusControl.DisplayStatus.On Then
                GasLine_Rough.Status = RoughPump_Line.Status
            Else
                GasLine_Rough.Status = DisplayStatus.Off
            End If

            If GasLine_Rough.Status = DisplayStatus.On Then
                Foreline_Line.Restart()
                RoughPump_Line.Restart()
            End If

        ElseIf sender Is ValveForeline Then
            If valveStatus = BinaryStatusControl.DisplayStatus.On Then
                Foreline_Line.Status = RoughPump_Line.Status
            Else
                Foreline_Line.Status = DisplayStatus.Off
            End If

            If GasLine_Rough.Status = DisplayStatus.On Then
                GasLine_Rough.Restart()
                RoughPump_Line.Restart()
            End If

        ElseIf sender Is ValveFlowCoolReturn Then
            GasLine_Flowcool_Return.Status = gaslineStatus

        ElseIf sender Is ValveFixtureWater Then
            GasLine_FixtureWater.Status = gaslineStatus

        ElseIf sender Is ValveVent Then
            GasLine_Vent.Status = gaslineStatus

        ElseIf sender Is ValveIGIsolation Then
            GasLine_Isolation.Status = gaslineStatus

        ElseIf sender Is ValveDiverter Then
            If DiverterGasValveInstalled Then
                If gaslineStatus = DisplayStatus.On Then
                    GasLine234_Total.Visible = True
                    GasLine2_Total.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_GasDiverterCurve
                    GasLine2_Total.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_GasDiverterCurve_On
                    GasLine2_Total.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_GasDiverterCurve_On1
                    GasLine2_Total.Location = New Point(0, 230)
                    GasLine234_Total.Status = GasLine2_Total.Status

                    GasLine1_Total_Below.Visible = False
                    GasLine1_Total.Visible = False
                    GasLine_Shutoff1.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End
                    GasLine_Shutoff1.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End_On
                    GasLine_Shutoff1.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_End_On_1
                    GasLine_Shutoff1.Location = New Point(GasLine1_Total.Location.X, GasLine1_Total.Location.Y)

                    GasLine_Total1.Status = GasLine_Shutoff1.Status
                    GasLine_Total.Status = GasLine_Total1.Status

                    If m_iGasEndIndex = 2 Then
                        GasLine2_Total.Visible = True
                        GasLine_Shutoff2.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_Gas2ShutOffDiverter
                        GasLine_Shutoff2.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_Gas2ShutOffDiverter_On
                        GasLine_Shutoff2.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_Gas2ShutOffDiverter
                        GasLine_Shutoff2.Location = New Point(42, 230)
                    End If

                Else

                    GasLine234_Total.Visible = False
                    GasLine2_Total.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_GasDiverter
                    GasLine2_Total.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_GasDiverter_On
                    GasLine2_Total.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_GasDiverter_On1
                    GasLine2_Total.Location = New Point(21, 196)

                    GasLine1_Total_Below.Visible = True
                    GasLine1_Total.Visible = True
                    GasLine_Shutoff1.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal
                    GasLine_Shutoff1.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_On
                    GasLine_Shutoff1.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_Gas_Supply_Horizontal_On_1
                    GasLine_Shutoff1.Location = New Point(33, 150)

                    GasLine1_Total.Status = IIf(GasLine_Shutoff1.Status = AVPControls.AVPDataLib.DisplayStatus.On OrElse _
                                                GasLine_Shutoff2.Status = AVPControls.AVPDataLib.DisplayStatus.On OrElse _
                                                GasLine_Shutoff3.Status = AVPControls.AVPDataLib.DisplayStatus.On OrElse _
                                                GasLine_Shutoff4.Status = AVPControls.AVPDataLib.DisplayStatus.On, AVPControls.AVPDataLib.DisplayStatus.On, AVPControls.AVPDataLib.DisplayStatus.Off)
                    GasLine_Total1.Status = GasLine1_Total.Status
                    GasLine_Total.Status = GasLine_Total1.Status

                    If m_iGasEndIndex = 2 Then
                        GasLine2_Total.Visible = False
                        GasLine_Shutoff2.OffImage = AVP_Robot_Project.My.Resources.Resources.SL_Gas2DiverterCurveEnd
                        GasLine_Shutoff2.OnImage0 = AVP_Robot_Project.My.Resources.Resources.SL_Gas2DiverterCurveEnd_On
                        GasLine_Shutoff2.OnImage1 = AVP_Robot_Project.My.Resources.Resources.SL_Gas2DiverterCurveEnd_On1
                        GasLine_Shutoff2.Location = New Point(GasLine2_Total.Location.X, GasLine2_Total.Location.Y)
                    End If

                End If

                If valveStatus <> BinaryStatusControl.DisplayStatus.On Then
                    lblDiverterGas.Text = "CIBE"
                Else
                    lblDiverterGas.Text = "RIBE"
                End If
            End If
        ElseIf sender Is ValveShutoffPBNGas OrElse sender Is ValveSupplyPBNGas Then
            If ValveSupplyPBNGas.Visible Then
                GasLine_PBNSupply.Status = Utils.ConvertToDisplayStatus(ValveSupplyPBNGas.Status)
            Else
                GasLine_PBNSupply.Status = Utils.ConvertToDisplayStatus(ValveShutoffPBNGas.Status)
            End If

            If ValveShutoffPBNGas.Status = BinaryStatusControl.DisplayStatus.On Then
                GasLine_PBNShutoff.Status = GasLine_PBNSupply.Status
                PBNGasLine.Status = GasLine_PBNSupply.Status
            Else
                GasLine_PBNShutoff.Status = DisplayStatus.Off
                PBNGasLine.Status = DisplayStatus.Off
            End If

            If GasLine_PBNShutoff.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
                txtPBNGas_SourceTab.BackColor = Color.Lime
            Else
                txtPBNGas_SourceTab.BackColor = Color.FromArgb(224, 221, 212)
            End If

            GasLine_PBNSupply.Restart()
            GasLine_PBNShutoff.Restart()
            PBNGasLine.Restart()

        ElseIf sender Is ValveShutoffGas1 _
            OrElse sender Is ValveSupplyGas1 _
            OrElse sender Is ValveShutoffGas2 _
            OrElse sender Is ValveSupplyGas2 _
            OrElse sender Is ValveShutoffGas3 _
            OrElse sender Is ValveSupplyGas3 _
            OrElse sender Is ValveShutoffGas4 _
            OrElse sender Is ValveSupplyGas4 Then

            ChangeStatusGaslines()
            ReflowGaslines()

        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-08-06 </date>
    ''' <author>
    ''' <summary>
    ''' Change gas line status base on valve status
    ''' </summary>
    Private Sub ChangeStatusGaslines()
        ' Gas 1
        If Gas1SupplyVisible Then
            GasLine_Supply1.Status = Utils.ConvertToDisplayStatus(ValveSupplyGas1.Status)
        Else
            GasLine_Supply1.Status = Utils.ConvertToDisplayStatus(ValveShutoffGas1.Status)
        End If

        If ValveShutoffGas1.Status = BinaryStatusControl.DisplayStatus.On Then
            GasLine_Shutoff1.Status = GasLine_Supply1.Status
        Else
            GasLine_Shutoff1.Status = DisplayStatus.Off
        End If

        ' Gas 2
        If Gas2SupplyVisible Then
            GasLine_Supply2.Status = Utils.ConvertToDisplayStatus(ValveSupplyGas2.Status)
        Else
            GasLine_Supply2.Status = Utils.ConvertToDisplayStatus(ValveShutoffGas2.Status)
        End If

        If ValveShutoffGas2.Status = BinaryStatusControl.DisplayStatus.On Then
            GasLine_Shutoff2.Status = GasLine_Supply2.Status
        Else
            GasLine_Shutoff2.Status = DisplayStatus.Off
        End If

        ' Gas 3
        If Gas3SupplyVisible Then
            GasLine_Supply3.Status = Utils.ConvertToDisplayStatus(ValveSupplyGas3.Status)
        Else
            GasLine_Supply3.Status = Utils.ConvertToDisplayStatus(ValveShutoffGas3.Status)
        End If

        If ValveShutoffGas3.Status = BinaryStatusControl.DisplayStatus.On Then
            GasLine_Shutoff3.Status = GasLine_Supply3.Status
        Else
            GasLine_Shutoff3.Status = DisplayStatus.Off
        End If

        ' Gas 4
        If Gas4SupplyVisible Then
            GasLine_Supply4.Status = Utils.ConvertToDisplayStatus(ValveSupplyGas4.Status)
        Else
            GasLine_Supply4.Status = Utils.ConvertToDisplayStatus(ValveShutoffGas4.Status)
        End If

        If ValveShutoffGas4.Status = BinaryStatusControl.DisplayStatus.On Then
            GasLine_Shutoff4.Status = GasLine_Supply4.Status
        Else
            GasLine_Shutoff4.Status = DisplayStatus.Off
        End If

        ' Gas total
        GasLine3_Total_Below.Status = GasLine_Shutoff4.Status
        GasLine3_Total.Status = IIf(GasLine_Shutoff4.Status = DisplayStatus.On _
                                            OrElse GasLine_Shutoff3.Status = DisplayStatus.On, DisplayStatus.On, DisplayStatus.Off)
        GasLine2_Total_Below.Status = GasLine3_Total.Status

        GasLine2_Total.Status = IIf(GasLine_Shutoff4.Status = DisplayStatus.On _
                                            OrElse GasLine_Shutoff3.Status = DisplayStatus.On _
                                            OrElse GasLine_Shutoff2.Status = DisplayStatus.On, DisplayStatus.On, DisplayStatus.Off)
        GasLine1_Total_Below.Status = GasLine2_Total.Status

        GasLine1_Total.Status = IIf(GasLine_Shutoff4.Status = DisplayStatus.On _
                                            OrElse GasLine_Shutoff3.Status = DisplayStatus.On _
                                            OrElse GasLine_Shutoff2.Status = DisplayStatus.On _
                                            OrElse GasLine_Shutoff1.Status = DisplayStatus.On, DisplayStatus.On, DisplayStatus.Off)

        If ValveDiverter.Status = BinaryStatusControl.DisplayStatus.On Then
            GasLine_Total1.Status = GasLine_Shutoff1.Status
            GasLine_Total.Status = GasLine_Total1.Status
            GasLine234_Total.Status = GasLine2_Total.Status
        Else
            GasLine_Total1.Status = GasLine1_Total.Status
            GasLine_Total.Status = GasLine_Total1.Status
        End If

        If GasLine_Shutoff1.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
            txtGas1_SourceTab.BackColor = Color.Lime
        Else
            txtGas1_SourceTab.BackColor = Color.FromArgb(224, 221, 212)
        End If

        If GasLine_Shutoff2.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
            txtGas2_SourceTab.BackColor = Color.Lime
        Else
            txtGas2_SourceTab.BackColor = Color.FromArgb(224, 221, 212)
        End If

        If GasLine_Shutoff3.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
            txtGas3_SourceTab.BackColor = Color.Lime
        Else
            txtGas3_SourceTab.BackColor = Color.FromArgb(224, 221, 212)
        End If

        If GasLine_Shutoff4.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
            txtGas4_SourceTab.BackColor = Color.Lime
        Else
            txtGas4_SourceTab.BackColor = Color.FromArgb(224, 221, 212)
        End If

    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-08-06 </date>
    ''' <author>
    ''' <summary>
    ''' Restart animation of gas line for sync flow
    ''' </summary>
    Private Sub ReflowGaslines()
        ' Gas 1
        GasLine_Supply1.Restart()
        GasLine_Shutoff1.Restart()
        ' Gas 2
        GasLine_Supply2.Restart()
        GasLine_Shutoff2.Restart()
        ' Gas 3
        GasLine_Supply3.Restart()
        GasLine_Shutoff3.Restart()
        ' Gas 4
        GasLine_Supply4.Restart()
        GasLine_Shutoff4.Restart()
        'Gas total
        GasLine3_Total_Below.Restart()
        GasLine3_Total.Restart()
        GasLine2_Total_Below.Restart()
        GasLine2_Total.Restart()
        GasLine1_Total_Below.Restart()
        GasLine1_Total.Restart()
        GasLine_Total1.Restart()
        GasLine_Total.Restart()

    End Sub

    Public Sub SetMaintenanceMode(ByVal blnEditable As Boolean, ByVal blnMaintenanceMode As Boolean)
        m_IsMaintenanceMode = blnMaintenanceMode
        m_IsEditable_InMaintenanceMode = blnEditable
        If blnMaintenanceMode Then
            IsOnline = False
            If blnEditable Then
                If AVPLib.ContainerData.Permission(PERMISSION_001) Then
                    ActiveForm()
                End If
            Else
                InactiveForm()
            End If
            SLContainerBox.SetOnlineOfflineContainerBox(Not blnEditable)
            m_PopUpPanel.SetOnlineOfflinePopUp(Not blnEditable)
            m_CryoPopUpPanel.DeviceOnline = Not blnEditable
        Else
            If AVPLib.ContainerData.Permission(PERMISSION_001) Then
                ActiveForm()
                SLContainerBox.SetOnlineOfflineContainerBox(False)
                m_PopUpPanel.SetOnlineOfflinePopUp(False)
                m_CryoPopUpPanel.DeviceOnline = False
            End If
        End If

    End Sub

    Private Sub btnCryoPumpOnOff_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim objChamber As AVPLib.DataManagerment.IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
            If CryoPopUpPanel IsNot Nothing AndAlso objChamber IsNot Nothing Then
                ' Hai Tran (2016-07-12): Update Cryo status button.
                ' > If pump is On, show status On, 
                ' > else if pump is regenning or fast regenning show Unknown status with text "Reg",
                ' > else show status Off
                If objChamber.CryoPumpStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.On Then
                    SLContainerBox.btnCryoOn.Status = DisplayStatus.On
                ElseIf objChamber.CryoAutoRegenStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.On Then
                    SLContainerBox.btnCryoOn.Status = SL_CustomButton.DisplayStatus.Unknow
                Else
                    SLContainerBox.btnCryoOn.Status = SL_CustomButton.DisplayStatus.Off
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub cmbRebuildLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRebuildLevel.SelectedIndexChanged
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            m_stoStatusObject.RequestStatus(cmbRebuildLevel.AccessibleName, cmbRebuildLevel.Text)
        End If
    End Sub

    Private Sub NewConvectronGaugeFrm(ByVal bIGFilamentVisible As Boolean)
        Dim dblIG As Double = 0
        Double.TryParse(SLIGCGControl.txtIG.Text, dblIG)
        m_CGGaugesFrm = New CGGaugesFrm(True, False, True, bIGFilamentVisible)
        m_CGGaugesFrm.Name = AVPLib.ConstEnum.PRESSURE & AVPLib.ConstEnum.CG_IG_FORM
        m_CGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_CGGaugesFrm.ShowInTaskbar = False
        m_CGGaugesFrm.ShowIcon = False
        m_CGGaugesFrm.Text = AVPLib.Utils.chamberID2ChamberName(Me.Name) & " " & AVPLib.ConstEnum.PRESSURE
        m_CGGaugesFrm.UpdateIGStatus(dblIG > 0)
        m_CGGaugesFrm.Hide()
    End Sub

    Private Sub NewMPConvectronGaugeFrm()
        m_MPCGGaugesFrm = New CGGaugesFrm(False, True, False)
        m_MPCGGaugesFrm.Name = AVPLib.ConstEnum.ROUGHPUMP & AVPLib.ConstEnum.CG_IG_FORM
        m_MPCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_MPCGGaugesFrm.ShowInTaskbar = False
        m_MPCGGaugesFrm.ShowIcon = False
        m_MPCGGaugesFrm.Text = AVPLib.Utils.chamberID2ChamberName(Me.Name) & " " & AVPLib.ConstEnum.MECHANICAL_PUMP
        m_MPCGGaugesFrm.UpdatePumpStatus(RoughPump.Status = BinaryStatusControl.DisplayStatus.On)
        m_MPCGGaugesFrm.Hide()
    End Sub

    Private Sub NewFLConvectronGaugeFrm()
        m_FLCGGaugesFrm = New CGGaugesFrm(False, False, False)
        m_FLCGGaugesFrm.Name = AVPLib.ConstEnum.FORELINE & AVPLib.ConstEnum.CG_IG_FORM
        m_FLCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_FLCGGaugesFrm.ShowInTaskbar = False
        m_FLCGGaugesFrm.ShowIcon = False
        m_FLCGGaugesFrm.Text = AVPLib.Utils.chamberID2ChamberName(Me.Name) & " " & AVPLib.ConstEnum.FORELINE
        m_FLCGGaugesFrm.Hide()
    End Sub

    Private Sub PressureCG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If SLPM.txtInformation.Clickable = False Or (Not PM_DeviceNet) Then
                    Return
                End If
                Dim objChamber As AVPLib.DataManagerment.IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
                If CGGaugesFrm IsNot Nothing AndAlso objChamber IsNot Nothing Then
                    CGGaugesFrm.IsSetATM = IIf(objChamber.EnablePressureCGATM = AVPLib.DataManagerment.Equipment.WorkingStatuses.On, True, False)
                    CGGaugesFrm.IsSetVAC = IIf(objChamber.EnablePressureCGVAC = AVPLib.DataManagerment.Equipment.WorkingStatuses.On, True, False)
                    CGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
                    CGGaugesFrm.ShowDialog(AVPRobotMain)
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub PressureCG_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If CGGaugesFrm IsNot Nothing Then
                    Dim dblIG As Double = 0
                    Double.TryParse(SLIGCGControl.txtIG.Text, dblIG)
                    CGGaugesFrm.UpdateIGStatus(dblIG > 0)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    '<author>Dua Tran<author>
    '<Date>2017-08-24<Date>
    Private Sub SwitchIGFilament_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If CGGaugesFrm IsNot Nothing Then
                    Dim isIGOn As Double = 0
                    Double.TryParse(SLIGCGControl.txtSwitchIGFilament.Text, isIGOn)
                    CGGaugesFrm.UpdateSwitchIGFilament(isIGOn)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    '<author>Dua Tran<author>
    '<Date>2017-08-24<Date>
    Private Sub SwitchIGFilament_EnableChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If CGGaugesFrm IsNot Nothing Then
                    If SLIGCGControl.txtEnableIGFilament.Text = "0" Then
                        CGGaugesFrm.btnIGFilament1.Enabled = True
                        CGGaugesFrm.btnIGFilament2.Enabled = True
                    Else
                        CGGaugesFrm.btnIGFilament1.Enabled = False
                        CGGaugesFrm.btnIGFilament2.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtRoughlineCG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRoughlineCG.Click
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            If txtRoughlineCG.Clickable = False Or (Not PM_DeviceNet) Then
                Return
            End If
            Dim objChamber As AVPLib.DataManagerment.IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Name)
            If MPCGGaugesFrm IsNot Nothing AndAlso objChamber IsNot Nothing Then
                MPCGGaugesFrm.IsSetATM = IIf(objChamber.EnableRoughCGATM = AVPLib.DataManagerment.Equipment.WorkingStatuses.On, True, False)
                MPCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
                MPCGGaugesFrm.ShowDialog(AVPRobotMain)
            End If

        End If
    End Sub

    Private Sub lblDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDisconnect.Click
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize AndAlso lblDisconnect.Tag Then
                Dim chamberName As String = AVPLib.Utils.chamberID2ChamberName(Me.Name)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + chamberName + "] " + lblDisconnect.Text + " Click ")
                If (Utils.ShowAVPMessageBox("Do you want to connect to " & chamberName & " ?", chamberName & " Reconnect", _
                                            MessageBoxIcon.Question) = DialogResult.OK) Then
                    ContainerForm.ChamberPanel(Me.Name).btnReConnect_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub RoughPump_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoughPump.StatusChange
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If m_MPCGGaugesFrm IsNot Nothing Then
                    m_MPCGGaugesFrm.UpdatePumpStatus(RoughPump.Status = BinaryStatusControl.DisplayStatus.On)
                End If

                RoughPump_Line.Status = RoughPump.Status

                If RoughPump.Status = BinaryStatusControl.DisplayStatus.On Then
                    Foreline_Line.Status = Utils.ConvertToDisplayStatus(ValveForeline.Status)
                    GasLine_Rough.Status = Utils.ConvertToDisplayStatus(ValveRough.Status)
                ElseIf RoughPump.Status = BinaryStatusControl.DisplayStatus.Off Then
                    Foreline_Line.Status = DisplayStatus.Off
                    GasLine_Rough.Status = DisplayStatus.Off
                End If

                RoughPump_Line.Restart()
                Foreline_Line.Restart()
                GasLine_Rough.Restart()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub FlowcoolStatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLFixture.FlowcoolStatusChange
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            GasLine_FlowCool_Supply.Status = SLFixture.GasLine_FlowCool.Status
            SLFixture.GasLine_FlowCool.Restart()
            GasLine_FlowCool_Supply.Restart()
        End If
    End Sub
End Class