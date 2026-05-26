Imports AVPLib.Business
Imports AVPLib.ConstEnum
Imports AVPLib.SystemModule
Namespace DataManagerment

    Public Enum EnumPressureMode
        IG = 0
        CG
    End Enum

    Public Class LoadLock
        Inherits Equipment

#Region "Class Constants & Variables"
        Private m_strLotID As String = String.Empty
        Private m_strSeqID As String = String.Empty
        Private m_intWaferCount As Integer = 0
        Private m_blnInCycleMode As Boolean = False
        Private m_blnCycleInATMMode As Boolean = False
        Private m_blnRunWithRecipe As Boolean = False

        Private m_MaxCycleCount As UInt16 = 0

        Private m_dblIG As Double
        Private m_dblCG As Double

        'support detect device net communication
        Protected m_IG_Communication As WorkingStatuses = WorkingStatuses.On
        Protected m_CG_Communication As WorkingStatuses = WorkingStatuses.On
        Protected m_TurboForelineCG_Communication As WorkingStatuses = WorkingStatuses.On

        Private m_enmPressureMode As EnumPressureMode = EnumPressureMode.CG
        Private m_enmIGStatus As WorkingStatuses = WorkingStatuses.Off
        Private m_SwitchIGFilament As Integer
        Private m_enmFastVentValveStatus As WorkingStatuses
        Private m_enmSlowVentValveStatus As WorkingStatuses
        Private m_enmFastRoughValveStatus As WorkingStatuses
        Private m_enmSlowRoughValveStatus As WorkingStatuses
        Private m_enmHiVacValveStatus As WorkingStatuses
        Private m_enmHiVacValveOpenStatus As WorkingStatuses
        Private m_enmHiVacValveCloseStatus As WorkingStatuses
        Private m_enmControlStatus As ControlStatuses = ControlStatuses.ONLINE
        Private m_enmAutoVentStatus As WorkingStatuses
        Private m_enmPumpDownStatus As WorkingStatuses
        Private m_enmStart As ProcessStatuses = ProcessStatuses.START
        Private m_strSemiTransferStatus As String
        Private m_enmLoad As WorkingStatuses
        Private m_enmUnload As WorkingStatuses
        Private m_enmAbort As WorkingStatuses
        Private m_Elevator As LLElevator
        Private m_enmVacSwitchStatus As WorkingStatuses

        Public Event WaferCountIncreased(ByVal sender As Object, ByVal wfc As WaferCountEventArgs)

        Private m_RateOfRise_Status As WorkingStatuses = WorkingStatuses.Off
        Private m_strRateOfRise_Sample As String
        Private m_strRateOfRise_FileName As String

        Private m_PumpDown_Curve_Status As WorkingStatuses = WorkingStatuses.Off
        Private m_strPumpDown_Curve_Sample As String
        Private m_strPumpDown_Curve_FileName As String
        Private m_enmIG_Degas_Status As WorkingStatuses
        Private m_enmOverideModeStatus As WorkingStatuses

        Private m_MaterialReceived As Boolean = False
        Private m_MaterialRemoved As Boolean = False

        Private m_enmTurboValveStatus As WorkingStatuses = WorkingStatuses.Off
        Private m_dblTurboForelineCG As Double
        Private m_enmTurboForeLineCGRelay As WorkingStatuses = WorkingStatuses.Unknown
        Private m_isRaiseLoadEventAtStart As Boolean = False
        Private m_blnIsWithoutMotion As Boolean = False
#End Region

#Region "Properties"
        Function UpdateCGRelay(ByVal value As WorkingStatuses) As Boolean

            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add("VacSwitchStatus")
            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(value)
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.Name, PropertyNames, ReplyValues)
        End Function

        Function UpdatePressureError() As Boolean

            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add("PressureError")
            Dim values As ArrayList = New ArrayList()
            values.Add("PressureError")
            Me.ChangeStatus(PropertyNames, values)
        End Function

        Function UpdateTurboCGPressureError() As Boolean

            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add("Error")

            Dim PropertyNames As ArrayList = New ArrayList()

            PropertyNames.Add("TurboForelineCGError")

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.Name, PropertyNames, ReplyValues)
        End Function

        Public WriteOnly Property RaiseLoadEventAtStart() As Boolean
            Set(ByVal value As Boolean)
                m_isRaiseLoadEventAtStart = value
            End Set
        End Property

        Public Property IG_Communication() As WorkingStatuses
            Get
                Return m_IG_Communication
            End Get
            Set(ByVal value As WorkingStatuses)
                m_IG_Communication = value

                If (value = WorkingStatuses.Off) Then
                    m_enmIGStatus = value
                    m_dblIG = -1.0
                End If
                UpdatePressureError()
            End Set
        End Property
        Public Property CG_Communication() As WorkingStatuses
            Get
                Return m_CG_Communication
            End Get
            Set(ByVal value As WorkingStatuses)
                m_CG_Communication = value

                If (value = WorkingStatuses.Off) Then
                    m_dblCG = -1.0

                    ''0005537: [KhoiHa- 08/21/2014][VCO19]When TM CG device is disconnected, shutdown system and restart application, 
                    ''TM relay pressure still shows ON. Re-check this case in LL and PM
                    'UpdateCGRelay(value)
                End If

                UpdatePressureError()

            End Set
        End Property
        Public Property TurboForelineCG_Communication() As WorkingStatuses
            Get
                Return m_TurboForelineCG_Communication
            End Get
            Set(ByVal value As WorkingStatuses)

                m_TurboForelineCG_Communication = value

                If (m_TurboForelineCG_Communication = WorkingStatuses.Off) Then
                    m_dblTurboForelineCG = -1.0
                    UpdateTurboCGPressureError()
                    'Dim objLLController As Business.LoadLockController = Business.ControllerManager.GetController(Me.Name)
                    'If objLLController IsNot Nothing Then
                    '    objLLController.ThrowAlarm(Me.Name & " Turbo Forline CG is disconnected.")
                    'End If
                    'DoActionTurboForlineCGOff()
                End If

            End Set
        End Property

        Public Sub DoActionTurboForlineCGOff()
            If Me.Name.Contains("LoadLockA") Then
                If (RobotConfigurationValues.LLA_TURBO_VISIBLE) Then
                    Business.LLCryoUtility.TurnOffIG(Me.Name)
                    Business.LLCryoUtility.CloseLLTurboForeLineValve(Me.Name)
                    Business.LoadLockUtility.CloseLLHivac(Me.Name)
                    Dim objLLATurboCtrl As Business.TurboController = Business.ControllerManager.GetController(ConstEnum.Equipments.LLAPumpPackage.ToString())
                    If objLLATurboCtrl IsNot Nothing Then
                        objLLATurboCtrl.TurnOff()
                    End If
                End If
            End If
        End Sub

        ''Create only for SECSGEM
        Public Property MaterialReceived() As Boolean
            Get
                Return m_MaterialReceived
            End Get
            Set(ByVal value As Boolean)
                If m_MaterialReceived <> value Then
                    m_MaterialReceived = value
                    If value Then
                        AVPLib.Business.AVPSecsGemLib.TriggerEvent(Me.Name, "MaterialReceived")
                    End If
                End If
            End Set
        End Property

        Public Property MaterialRemoved() As Boolean
            Get
                Return m_MaterialRemoved
            End Get
            Set(ByVal value As Boolean)
                If m_MaterialRemoved <> value Then
                    m_MaterialRemoved = value
                    If value Then
                        AVPLib.Business.AVPSecsGemLib.TriggerEvent(Me.Name, "MaterialRemoved")
                    End If
                End If
            End Set
        End Property
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OverideModeStatus() As WorkingStatuses
            Get
                Return m_enmOverideModeStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmOverideModeStatus = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property VacSwitchStatus() As WorkingStatuses
            Get
                Return m_enmVacSwitchStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmVacSwitchStatus = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-16</date>
        ''' </author>
        ''' <summary>
        ''' Elevator of load lock
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Elevator() As LLElevator
            Get
                Return m_Elevator
            End Get
            Set(ByVal value As LLElevator)
                m_Elevator = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-12</date>
        ''' </author>
        ''' <summary>
        ''' Get current wafercount
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WaferCount() As Integer
            Get
                Return m_intWaferCount
            End Get
            Set(ByVal value As Integer)
                m_intWaferCount = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: WaferCount
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "CycleWaferCount", VALUELib.ValueType.F4, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-12</date>
        ''' </author>
        ''' <summary>
        ''' Get current wafercount
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LotID() As String
            Get
                Return m_strLotID
            End Get
            Set(ByVal value As String)
                m_strLotID = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: LotID
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "LotID", VALUELib.ValueType.A, value)
            End Set
        End Property

        Public Property SequenceID() As String
            Get
                Return m_strSeqID
            End Get
            Set(ByVal value As String)
                m_strSeqID = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: SequenceID
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SequenceID", VALUELib.ValueType.A, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2008-11-12</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property InCycleMode_RunWithRecipe() As Boolean
            Get
                Return m_blnInCycleMode
            End Get
            Set(ByVal value As Boolean)
                m_blnInCycleMode = value
                m_blnRunWithRecipe = value
                If Not (value) Then
                    MaxCycleCount = 0
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-07-24</date>
        ''' </author>
        ''' <summary>
        ''' when check box = checked -> value = textbox.text
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MaxCycleCount() As UInt16
            Get
                Return m_MaxCycleCount
            End Get
            Set(ByVal value As UInt16)
                m_MaxCycleCount = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2011-02-28</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsCycleInATM_Mode() As Boolean
            Get
                Return m_blnCycleInATMMode
            End Get
            Set(ByVal value As Boolean)
                m_blnCycleInATMMode = value
            End Set
        End Property

        Public Property RunWithRecipe() As Boolean
            Get
                Return m_blnRunWithRecipe
            End Get
            Set(ByVal value As Boolean)
                m_blnRunWithRecipe = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LoadStatus() As WorkingStatuses
            Get
                Return m_enmLoad
            End Get
            Set(ByVal value As WorkingStatuses)
                If m_isRaiseLoadEventAtStart Then
                    If value = WorkingStatuses.On AndAlso m_enmLoad = WorkingStatuses.Off Then
                        AVPLib.Business.AVPSecsGemLib.TriggerEvent(Me.Name, "LoadCompleted")
                    End If
                Else
                    If value = WorkingStatuses.Off AndAlso m_enmLoad = WorkingStatuses.On Then
                        AVPLib.Business.AVPSecsGemLib.TriggerEvent(Me.Name, "LoadCompleted")
                    End If
                End If
                m_enmLoad = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UnloadStatus() As WorkingStatuses
            Get
                Return m_enmUnload
            End Get
            Set(ByVal value As WorkingStatuses)
                If value = WorkingStatuses.Off AndAlso m_enmUnload = WorkingStatuses.On Then
                    AVPLib.Business.AVPSecsGemLib.TriggerEvent(Me.Name, "UnloadCompleted")
                End If
                m_enmUnload = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AbortStatus() As WorkingStatuses
            Get
                Return m_enmAbort
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmAbort = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StartStatus() As ProcessStatuses
            Get
                Return m_enmStart
            End Get
            Set(ByVal value As ProcessStatuses)
                m_enmStart = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Control Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SemiTransferStatus() As String
            Get
                Return m_strSemiTransferStatus
            End Get
            Set(ByVal value As String)
                m_strSemiTransferStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' AutoVentStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AutoVentStatus() As WorkingStatuses
            Get
                Return m_enmAutoVentStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                If (m_enmAutoVentStatus <> value) Then
                    Utils.UpdateSequenceRunningStatusText(Me.Name, AUTO_VENT_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString)
                End If
                m_enmAutoVentStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: AutoVentRunning
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "AutoVentRunning", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' PumpDownStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PumpDownStatus() As WorkingStatuses
            Get
                Return m_enmPumpDownStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                If (m_enmPumpDownStatus <> value) Then
                    Utils.UpdateSequenceRunningStatusText(Me.Name, AUTO_PUMPDOWN_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString)
                End If
                m_enmPumpDownStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: AutoPumpdownRunning
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "AutoPumpdownRunning", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Truc Le</name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' PumpDownStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IG_Degas_Status() As WorkingStatuses
            Get
                Return m_enmIG_Degas_Status
            End Get
            Set(ByVal value As WorkingStatuses)
                If (m_enmIG_Degas_Status <> value) Then
                    Utils.UpdateSequenceRunningStatusText(Me.Name, IG_DEGAS_SEQ_NAME, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, value.ToString)
                End If
                m_enmIG_Degas_Status = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: IG_Degas_Status
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "IGDegasRunning", VALUELib.ValueType.U1, IIf(value = WorkingStatuses.On, 1, 0))
            End Set
        End Property


        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current fast vet valve status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FastVentValveStatus() As WorkingStatuses
            Get
                Return m_enmFastVentValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmFastVentValveStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: FastVentValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FastVentValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current slow vent valve status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SlowVentValveStatus() As WorkingStatuses
            Get
                Return m_enmSlowVentValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmSlowVentValveStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: SlowVentValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SlowVentValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get curretn Fast Rough Valve Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FastRoughValveStatus() As WorkingStatuses
            Get
                Return m_enmFastRoughValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                If (m_enmFastRoughValveStatus <> value) Then


                    Dim objRough As RoughPumpMachine = EquipmentManager.GetRoughPumpMachine(Me.Name)
                    If (objRough IsNot Nothing) Then
                        'release rough pump 
                        If (value = WorkingStatuses.Off AndAlso
                        m_enmSlowRoughValveStatus = WorkingStatuses.Off) Then
                            objRough.ReleaseRoughLineInUse(Me.Name)
                            'make rough pump opened
                        ElseIf (value = WorkingStatuses.On) Then
                            objRough.SetRoughLineInUse(Me.Name)
                        End If
                    End If

                    m_enmFastRoughValveStatus = value


                End If

                ' Update SECS/GEM variables by Truc Le
                ' Var Name: FastRoughValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "FastRoughValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current slow rough valve status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SlowRoughValveStatus() As WorkingStatuses
            Get
                Return m_enmSlowRoughValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                If (m_enmSlowRoughValveStatus <> value) Then

                    Dim objRough As RoughPumpMachine = EquipmentManager.GetRoughPumpMachine(Me.Name)
                    If (objRough IsNot Nothing) Then
                        If (value = WorkingStatuses.Off AndAlso
                        m_enmFastRoughValveStatus = WorkingStatuses.Off) Then
                            objRough.ReleaseRoughLineInUse(Me.Name)
                        ElseIf (value = WorkingStatuses.On) Then
                            objRough.SetRoughLineInUse(Me.Name)
                        End If
                    End If

                    m_enmSlowRoughValveStatus = value
                End If

                ' Update SECS/GEM variables by Truc Le
                ' Var Name: SlowRoughValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "SlowRoughValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current Pressure
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Pressure() As Double
            Get
                If IGStatus = WorkingStatuses.On Then
                    Return IG
                Else
                    Return CG
                End If
            End Get
        End Property

        Public WriteOnly Property PressureMode() As EnumPressureMode
            Set(ByVal value As EnumPressureMode)
                m_enmPressureMode = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current IG LLCryo
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IG() As Double
            Get
                Return m_dblIG
            End Get
            Set(ByVal value As Double)
                m_dblIG = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current CG LLCryo
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CG() As Double
            Get
                Return m_dblCG
            End Get
            Set(ByVal value As Double)
                'dat cao 2011-03-22
                'check CG condition 
                'when CG < e-3 then whow only e-3
                If value < 0.001 Then
                    value = 0.001
                End If
                m_dblCG = value
            End Set
        End Property

        Public Property TurboForeLineValveStatus() As WorkingStatuses
            Get
                Return m_enmTurboValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)

                If (m_enmTurboValveStatus <> value) Then
                    ' Update SECS/GEM variables by Truc Le
                    ' Var Name: SlowRoughValveStatus
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Turbo.ForelineStatus", VALUELib.ValueType.U1, value)
                End If

                m_enmTurboValveStatus = value
            End Set
        End Property

        Public Property TurboForelineCG() As Double
            Get
                Return m_dblTurboForelineCG
            End Get
            Set(ByVal value As Double)
                m_dblTurboForelineCG = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: SlowRoughValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Turbo.ForelineCGPressure", VALUELib.ValueType.F4, value)
            End Set
        End Property


        Public Property TurboForelineCGRelay() As WorkingStatuses
            Get
                Return m_enmTurboForeLineCGRelay
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmTurboForeLineCGRelay = value
            End Set
        End Property

        ''Truc Le add
        Public ReadOnly Property SlowRoughPressureSetPoint() As Double
            Get
                Return VentPumdownLib.LLPumpdownConfig.LLASlowRoughPressure
            End Get
        End Property

        Public ReadOnly Property FastRoughPressureSetPoint() As Double
            Get
                Return VentPumdownLib.LLPumpdownConfig.LLAFastRoughPressure
            End Get
        End Property

        Public ReadOnly Property SlowVentPressureSetPoint() As Double
            Get
                Return VentPumdownLib.LLVentConfig.LLASlowVentPressure

            End Get
        End Property

        Public ReadOnly Property FastVentPressureSetPoint() As Double
            Get
                Return VentPumdownLib.LLVentConfig.LLAVentPressure

            End Get
        End Property



        Public ReadOnly Property FastRoughPressureTimeOut() As Integer
            Get
                Return VentPumdownLib.LLPumpdownConfig.LLAFastRoughPressureTimeOut
            End Get
        End Property

        Public ReadOnly Property SlowRoughPressureTimeOut() As Integer
            Get
                Return VentPumdownLib.LLPumpdownConfig.LLASlowRoughPressureTimeOut
            End Get
        End Property

        Public ReadOnly Property SlowVentTimeout() As Integer
            Get
                Return VentPumdownLib.LLVentConfig.LLASlowVentTimeout
            End Get
        End Property

        Public ReadOnly Property FastVentTimeout() As Integer
            Get
                Return VentPumdownLib.LLVentConfig.LLAFastVentTimeout
            End Get
        End Property

        Public ReadOnly Property CryoColdTemp() As Double
            Get
                Return VentPumdownLib.LLPumpdownConfig.LLACryoColdTemp
            End Get
        End Property


        'Public ReadOnly Property TurboRealyOffTimeOutInMinutes() As Integer
        '    Get
        '        Return VentPumdownLib.LLVentConfig.TurboReallyOffTimeOutInMinutes
        '    End Get
        'End Property


#Region "Function Support"
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Update Pressure
        ''' </summary>
        Private Sub UpdatePressureMode()
            If m_enmIGStatus = WorkingStatuses.On Then
                m_enmPressureMode = EnumPressureMode.IG
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Pressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Pressure", VALUELib.ValueType.F4, IG)
            Else
                m_enmPressureMode = EnumPressureMode.CG
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Pressure
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "Pressure", VALUELib.ValueType.F4, CG)
            End If
        End Sub

        Private Sub RaiseUpdatePressureEvent()
            Try
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("PressureMode")
                Dim values As ArrayList = New ArrayList()
                values.Add(m_enmPressureMode)

                Me.ChangeStatus(PropertyNames, values)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Public Overrides Sub ChangeStatus(ByVal PropertyNames As System.Collections.ArrayList, ByVal ReplyValues As System.Collections.ArrayList)
            AVPLib.Log.coreLogger.Info("Enter ChangeStatus")
            MyBase.ChangeStatus(PropertyNames, ReplyValues)
            ' Post Processing.
            If (PropertyNames.Count = 1) Then
                Dim propertyName As String = PropertyNames.Item(0)
                If (propertyName = ConstEnum.IG) Or (propertyName = ConstEnum.CG) Or (propertyName = ConstEnum.IGStatus) Then
                    RaiseUpdatePressureEvent()
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave ChangeStatus")
        End Sub
#End Region

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2017-07-05 </date>
        ''' </author>
        Public Property SwitchIGFilament() As Integer
            Get
                Return m_SwitchIGFilament
            End Get
            Set(ByVal value As Integer)
                If m_SwitchIGFilament <> value Then
                    m_SwitchIGFilament = value
                    AVPLib.ContainerData.SetConfigFilament(Me.Name, value)
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current IG Status LLCryo
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IGStatus() As WorkingStatuses
            Get
                Return m_enmIGStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmIGStatus = value
                UpdatePressureMode()
            End Set
        End Property
        Private m_RevisionNoValues As String
        Public Property RevisionNoValues() As String
            Get
                Return m_RevisionNoValues
            End Get
            Set(ByVal value As String)
                m_RevisionNoValues = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current HiVacValveStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property HiVacValveStatus() As WorkingStatuses
            Get
                If HiVacValveOpenStatus = WorkingStatuses.On AndAlso HiVacValveCloseStatus = WorkingStatuses.Off Then
                    m_enmHiVacValveStatus = WorkingStatuses.On
                ElseIf HiVacValveCloseStatus = WorkingStatuses.On AndAlso HiVacValveOpenStatus = WorkingStatuses.Off Then
                    m_enmHiVacValveStatus = WorkingStatuses.Off
                Else
                    m_enmHiVacValveStatus = WorkingStatuses.Unknown
                End If

                Return m_enmHiVacValveStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmHiVacValveStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: HivacValveStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "HivacValveStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-17</date>
        ''' </author>
        ''' <summary>
        ''' Get or set HiVacValveOpenStatus
        ''' </summary>
        Public Property HiVacValveOpenStatus() As WorkingStatuses
            Get
                Return m_enmHiVacValveOpenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                If m_enmHiVacValveOpenStatus <> value Then
                    m_enmHiVacValveOpenStatus = value
                    Utils.ChangeStatusForFor2Channel(Me.Name, "HiVacValveStatus", HiVacValveStatus)
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2020-03-17</date>
        ''' </author>
        ''' <summary>
        ''' Get or set HiVacValveCloseStatus
        ''' </summary>
        Public Property HiVacValveCloseStatus() As WorkingStatuses
            Get
                Return m_enmHiVacValveCloseStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                If m_enmHiVacValveCloseStatus <> value Then
                    m_enmHiVacValveCloseStatus = value
                    Utils.ChangeStatusForFor2Channel(Me.Name, "HiVacValveStatus", HiVacValveStatus)
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Dua Tran </name>
        '''    	<date> 2017-10-09</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsWithoutMotion() As Boolean
            Get
                Return m_blnIsWithoutMotion
            End Get
            Set(ByVal value As Boolean)
                m_blnIsWithoutMotion = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> June 15 2009 </date>
        ''' </author>
        ''' <summary>
        ''' Check the condition to open the LL IG
        ''' true if meet the condition 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CheckCondition2OpenLLIG() As String
            AVPLib.Log.coreLogger.Info("Enter checkCondition2OpenLLIG")
            Dim strRet As String = String.Empty
            ' Is LL HiVac valve open
            If (RobotConfigurationValues.LLA_HIVAC_INSTALLED) Then
                Dim objLLAPumpPackageCtrl As PumpPackageController = Business.ControllerManager.GetController(ConstEnum.Equipments.LLAPumpPackage.ToString())

                If Me.HiVacValveStatus = WorkingStatuses.On Then
                    If Me.Name = LoadLockA_STR AndAlso (RobotConfigurationValues.LLA_CRYO_VISIBLE OrElse RobotConfigurationValues.LLA_TURBO_VISIBLE) Then
                        Dim strErrorMsg As String = String.Empty
                        strRet = String.Empty
                        If (objLLAPumpPackageCtrl IsNot Nothing) AndAlso (Not objLLAPumpPackageCtrl.IsPumpPackageOK(strErrorMsg)) Then
                            strRet = strErrorMsg
                        End If
                    End If
                Else
                    strRet = String.Format(ContainerData.GetMessageText("HivacValveLL"), LLA_STR)
                End If
            End If

            AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenLLIG" + strRet.ToString())
            Return strRet
        End Function

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> June 15 2009 </date>
        ''' </author>
        ''' <summary>
        ''' Check the condition to open the LL HiVac
        ''' return nothing if meet the condition, return error message if not
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CheckCondition2OpenLLHiVac(Optional ByVal dbCGMultiFactor As Double = 1) As String
            AVPLib.Log.coreLogger.Info("Enter checkCondition2OpenLLHiVac")
            Dim strRet As String = String.Empty
            Dim LLCG As Double = 0.0

            If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                If SlowRoughValveStatus = WorkingStatuses.On Then
                    Return "Cannot open hivac valve, " & LLA_STR + " Rough Valve open"
                    AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenLLHiVac" + strRet.ToString())
                End If
            End If

            If FastRoughValveStatus = WorkingStatuses.On Then
                Return "Cannot open hivac valve, " & LLA_STR + " Rough Valve open"
                AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenLLHiVac" + strRet.ToString())
            End If

            If (FastVentValveStatus = WorkingStatuses.On) Then
                Return "Cannot open hivac valve, " & LLA_STR + " Vent Valve is opened"
                AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenLLHiVac" + strRet.ToString())
            End If

            '''get LLAFastRoughPressure,LLBFastRoughPressure in SystemConfig.xml
            LLCG = VentPumdownLib.LLPumpdownConfig.LLAFastRoughPressure

            ' IS CG Relay On (check the new tag, WTM_VacSwitch_FB = 1)
            If Me.VacSwitchStatus = WorkingStatuses.On Then
                ' IS TM CG < .02 (configurable value)
                If (Me.CG * dbCGMultiFactor) < LLCG Then
                    strRet = String.Empty
                Else
                    strRet = "Cannot open hivac valve, " & String.Format(ContainerData.GetMessageText("CGSmallerThan"), LLA_STR, "<" & " " & LLCG.ToString())
                End If
            Else
                strRet = String.Format(ContainerData.GetMessageText("VacSwitch_FB"), LLA_STR)
            End If

            AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenLLHiVac" + strRet.ToString())
            Return strRet
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-03-04 </date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsIGInstalled() As Boolean
            AVPLib.Log.coreLogger.Info("Enter IsIGInstalled")
            Dim blResult As Boolean = False
            Try
                If Not IsHivacInstalled() AndAlso IsRoughOnlyMode() Then
                    blResult = False
                Else
                    blResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            AVPLib.Log.coreLogger.Info("Leave IsIGInstalled" + blResult.ToString())
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> June 15 2009 </date>
        ''' </author>
        ''' <summary>
        ''' Check the condition to open the TM Rough
        ''' return error message if not meet condition, else return nothing
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CheckCondition2OpenLLRough() As String
            AVPLib.Log.coreLogger.Info("Enter checkCondition2OpenLLRough")
            Dim strRet As String = String.Empty

            If (RobotConfigurationValues.DEBUGMODE) Then
                AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenLLRough")
                Return strRet
            End If

            Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)

            Try

                Dim objLLElevator As LLElevator = Nothing
                Dim LLElevatorName As String = ConstEnum.Equipments.LLAElevator.ToString()
                objLLElevator = EquipmentManager.GetEquipment(LLElevatorName)
                If (objLLElevator IsNot Nothing AndAlso objLLElevator.DCStatus = WorkingStatuses.On) Then
                    strRet = LLA_STR & " door is opened."
                    Exit Try
                End If

                EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                '''''''''''''''HivacValve is On
                If (RobotConfigurationValues.LLA_HIVAC_INSTALLED AndAlso Me.HiVacValveStatus <> WorkingStatuses.Off) Then
                    strRet = String.Format(ContainerData.GetMessageText(LL_ROUGH), "Hivac Valve " & LLA_STR)
                    Exit Try
                End If

                '''''''''check IG Status
                If (IsIGInstalled() AndAlso Me.IGStatus <> WorkingStatuses.Off) Then
                    strRet = (String.Format(ContainerData.GetMessageText(LL_IG_WAS_NOT_OFF), LLA_STR))
                    Exit Try
                End If

                '''''''''''''''''check Slit valve
                If (Me.Name = ConstEnum.Equipments.LoadLockA.ToString() And TM.SplitValve1Status = WorkingStatuses.Off) Then
                    ''''''''''''''check Vent Valve
                    If (RobotConfigurationValues.LL_SLOW_VENT_INSTALLED) Then
                        If Me.SlowVentValveStatus = WorkingStatuses.Off And Me.FastVentValveStatus = WorkingStatuses.Off Then
                            strRet = String.Empty
                        Else ''''''''''''''Vent Valve is On
                            strRet = String.Format(ContainerData.GetMessageText(LL_ROUGH), "Vent Valve " & LLA_STR)
                        End If
                    Else
                        If Me.FastVentValveStatus = WorkingStatuses.Off Then
                            strRet = String.Empty
                        Else ''''''''''''''Vent Valve is On
                            strRet = String.Format(ContainerData.GetMessageText(LL_ROUGH), "Vent Valve " & LLA_STR)
                        End If
                    End If

                Else ''''''''''''Slit valve is On
                    strRet = (String.Format(ContainerData.GetMessageText(LL_ROUGH), "Slit valve " & LLA_STR))
                End If

                ' Check auto vent sequence is running
                If Me.AutoVentStatus = WorkingStatuses.On Then
                    strRet = LLA_STR & " " & ConstEnum.AUTO_VENT_RUNNING
                End If

                If (String.IsNullOrEmpty(strRet)) Then

                    Dim objRoughPump As DataManagerment.RoughPumpMachine = EquipmentManager.GetRoughPumpMachine(Me.Name)
                    If (objRoughPump IsNot Nothing) Then
                        If (objRoughPump.IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                            Dim objLL As LoadLock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)
                            If (objLL IsNot Nothing AndAlso
                                RobotConfigurationValues.LLA_TURBO_VISIBLE AndAlso
                                objLL.TurboForeLineValveStatus = WorkingStatuses.On) Then
                                strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Foreline valve of " & LLA_STR)
                                Exit Try
                            End If
                        End If

                        If (objRoughPump.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                            Dim objLL As CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
                            If (objLL IsNot Nothing AndAlso
                                RobotConfigurationValues.TMTURBO_VISIBLE AndAlso
                                objLL.TurboForeLineValveStatus = WorkingStatuses.On) Then
                                strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Foreline valve of " & AVPLib.Utils.chamberID2ChamberName(objLL.Name))
                                Exit Try
                            End If
                        End If

                        '0009760: Foreline/rough valve should not be allow to open when TM's pump is not on and pressure is not reach.
                        Dim PumpStatus As WorkingStatuses = IIf(objRoughPump.Name = ConstEnum.Equipments.RoughPumpMachine1.ToString, TM.RoughPump1Status, TM.RoughPump2Status)
                        If Not PumpStatus = WorkingStatuses.On Then
                            strRet = MECHANICAL_PUMP_NOT_ON
                            Exit Try
                        End If
                    End If
                End If


            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try


            AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenLLRough")
            Return strRet
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2017-10-31 </date>
        ''' </author>
        ''' <summary>
        ''' Check the condition to start Regen
        ''' </summary>
        Public Function CheckCondition2StartRegen() As String
            AVPLib.Log.coreLogger.Info("Enter CheckCondition2StartRegen")
            Dim strRet As String = String.Empty

            If (RobotConfigurationValues.DEBUGMODE) Then
                AVPLib.Log.coreLogger.Info("Leave CheckCondition2StartRegen")
                Return strRet
            End If

            Try
                Dim objRoughPump As DataManagerment.RoughPumpMachine = EquipmentManager.GetRoughPumpMachine(Me.Name)
                If (objRoughPump IsNot Nothing) Then
                    If (objRoughPump.IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                        Dim objLL As LoadLock = EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString)
                        If objLL IsNot Nothing Then
                            If objLL.FastRoughValveStatus = WorkingStatuses.On Then
                                strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Fast rough valve of " & LLA_STR)
                                Exit Try
                            End If
                            If RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED AndAlso objLL.SlowRoughValveStatus = WorkingStatuses.On Then
                                strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Slow rough valve of " & LLA_STR)
                                Exit Try
                            End If
                            If RobotConfigurationValues.LLA_TURBO_VISIBLE AndAlso objLL.TurboForeLineValveStatus = WorkingStatuses.On Then
                                strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Foreline valve of " & LLA_STR)
                                Exit Try
                            End If
                        End If
                    End If

                    If (objRoughPump.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                        Dim objTM As CassettesModule = EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)
                        If objTM IsNot Nothing Then
                            If objTM.FastRoughValveStatus = WorkingStatuses.On Then
                                strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Fast rough valve of " & AVPLib.Utils.chamberID2ChamberName(objTM.Name))
                                Exit Try
                            End If
                            If RobotConfigurationValues.TMTURBO_VISIBLE AndAlso objTM.TurboForeLineValveStatus = WorkingStatuses.On Then
                                strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Foreline valve of " & AVPLib.Utils.chamberID2ChamberName(objTM.Name))
                                Exit Try
                            End If
                        End If
                    End If

                    If AVPLib.RobotConfigurationValues.SHARED_MP_WITH_PM Then
                        Dim intMaxOfPM As Integer = 3 'default for CX4
                        For i As Integer = 1 To intMaxOfPM
                            Dim strName As String = ConstEnum.Chamber & i.ToString()
                            Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(strName)

                            If objChamber Is Nothing OrElse Not objChamber.EquipmentType = ModuleType.PVD5T Then
                                Continue For
                            End If
                            Dim objPVD5TChamber As DataManagerment.PVD5TChamber = CType(objChamber, DataManagerment.PVD5TChamber)

                            If objRoughPump.IsUsed(strName) AndAlso
                                objPVD5TChamber.RoughValveStatus = WorkingStatuses.On Then

                                strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Rough valve of " & AVPLib.Utils.chamberID2ChamberName(strName))
                            End If
                        Next
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try

            AVPLib.Log.coreLogger.Info("Leave CheckCondition2StartRegen")
            Return strRet
        End Function

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> June 15 2009 </date>
        ''' </author>
        ''' <summary>
        ''' Check the condition to open the LL Vent
        ''' true if meet the condition 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CheckCondition2OpenLLVent() As String
            AVPLib.Log.coreLogger.Info("Enter checkCondition2OpenLLVent")
            Dim strRet As String = String.Empty

            If (RobotConfigurationValues.DEBUGMODE) Then
                Return strRet
            End If

            Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            ' is LL hivac valve closed?
            ' this case llhivacvalve = On <> (Me.Name = LoadLockA_STR AndAlso RobotConfigurationValues.LLA_HIVAC_INSTALLED) OrElse _
            '                                (Me.Name = LoadLockB_STR AndAlso RobotConfigurationValues.LLB_HIVAC_INSTALLED)
            'so we not need check when HivacValve = On
            If (RobotConfigurationValues.LLA_HIVAC_INSTALLED AndAlso Me.HiVacValveStatus <> WorkingStatuses.Off) Then
                strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Hivac valve " & LLA_STR)
                GoTo ENDFUNC
            End If

            ' is LL IG off
            If IsIGInstalled() AndAlso Me.IGStatus <> WorkingStatuses.Off Then
                strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "IG of " & LLA_STR)
                GoTo ENDFUNC
            End If

            ' is LL Slit valves closed
            If (Me.Name = Equipments.LoadLockA.ToString() And TM.SplitValve1Status <> WorkingStatuses.Off) Then
                strRet = (String.Format(ContainerData.GetMessageText(MESA_VALVES), "Slit valve of " & LLA_STR))
                GoTo ENDFUNC
            End If


            ' is LL rough valves  closed
            'Slow rough valve
            If (IsRoughInstalled()) Then
                If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED) Then
                    If Me.SlowRoughValveStatus <> WorkingStatuses.Off Then
                        strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Slow Rough Valve of " & LLA_STR)
                        GoTo ENDFUNC
                    End If
                End If

                'Fast rough valve
                If Me.FastRoughValveStatus <> WorkingStatuses.Off Then
                    strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Fast Rough Valve of " & LLA_STR)
                    GoTo ENDFUNC
                End If

            Else
                Dim objPumpPackageCtrl As PumpPackageController = Nothing
                If Me.Name = LoadLockA_STR Then
                    objPumpPackageCtrl = Business.ControllerManager.GetController(ConstEnum.Equipments.LLAPumpPackage.ToString())
                End If

                If objPumpPackageCtrl IsNot Nothing Then
                    If Not objPumpPackageCtrl.IsPumpPackageOff Then
                        strRet = String.Format(ContainerData.GetMessageText(LL_ROUGH), "Turbo")
                        GoTo ENDFUNC
                    End If
                End If

                If TurboForeLineValveStatus <> WorkingStatuses.Off Then
                    strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Turbo Foreline Valve")
                    GoTo ENDFUNC
                End If

            End If

            ' Check LL PumpDown sequence running
            If Me.PumpDownStatus = WorkingStatuses.On Then
                strRet = LLA_STR & " " & ConstEnum.AUTO_PUMPDOWN_RUNNING
                GoTo ENDFUNC
            End If

            strRet = String.Empty
ENDFUNC:
            AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenLLIG" + strRet.ToString())
            Return strRet
        End Function


        Public Function CheckCondition2TurnOnTurbo() As String
            AVPLib.Log.coreLogger.Info("Enter checkCondition2OpenLLVent")
            Dim strRet As String = String.Empty

            If Not IsRoughInstalled() Then
                If (FastVentValveStatus <> DataManagerment.Equipment.WorkingStatuses.Off) Then
                    strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Fast Vent Valve")
                    GoTo ENDFUNC
                End If

                If (RobotConfigurationValues.LL_SLOW_VENT_INSTALLED) _
                    AndAlso SlowVentValveStatus <> DataManagerment.Equipment.WorkingStatuses.Off Then

                    strRet = String.Format(ContainerData.GetMessageText(MESA_VALVES), "Slow Vent Valve")
                    GoTo ENDFUNC

                End If
            End If

            strRet = String.Empty
ENDFUNC:
            AVPLib.Log.coreLogger.Info("Leave checkCondition2OpenLLIG" + strRet.ToString())
            Return strRet
        End Function
#End Region

#Region "Public methods"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-12</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date> 2008-12-15</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Reset wafer count
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ResetWaferCount()
            WaferCount = 0
            ContainerData.SaveWaferCountForEQ(Me.Name, WaferCount)
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-12</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date> 2008-12-15</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Increase wafer count
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub IncreaseWaferCount()
            AVPLib.Log.coreLogger.Info("Enter IncreaseWaferCount")
            Try
                WaferCount += 1
                Dim wfc As New WaferCountEventArgs
                wfc.Count = WaferCount
                '#04/27/2011 
                '#AVP.  Lifetime wafer reset to �2� when restart.
                '#Begin fix:
                ContainerData.LifeTimeWafer += 1
                ContainerData.SaveLifeTimeWafer()
                ContainerData.SaveWaferCountForEQ(Me.Name, WaferCount)
                ContainerData.IncreaseTotalWaferCount()
                '#End fix.
                RaiseEvent WaferCountIncreased(Me, wfc)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave IncreaseWaferCount")
        End Sub

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-08-10</date>
        ''' </author>
        ''' <summary>
        ''' Update Variables For Gem When Init
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Sub UpdateVariableForGemWhenInit()
            Me.ControlStatus = ControlStatus
            Me.FastVentValveStatus = FastVentValveStatus
            Me.FastRoughValveStatus = FastRoughValveStatus
            Me.SlowVentValveStatus = SlowVentValveStatus
            Me.SlowRoughValveStatus = SlowRoughValveStatus
            Me.HiVacValveStatus = HiVacValveStatus
            Me.IG_Degas_Status = IG_Degas_Status
            Me.PumpDownStatus = PumpDownStatus
            Me.AutoVentStatus = AutoVentStatus
            Me.LotID = LotID
            Me.SequenceID = SequenceID
            Me.WaferCount = WaferCount
            Me.OverideModeStatus = OverideModeStatus
            Me.TurboForeLineValveStatus = TurboForeLineValveStatus
            Me.TurboForelineCG = TurboForelineCG
            UpdatePressureMode()
        End Sub


        ''' <author>
        '''    	<name>Van Le</name>
        '''    	<date> 2014-08-22</date>
        ''' </author>
        ''' <summary>
        ''' IsSafetySetATM
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsSafetySetATM() As Boolean
            Try
                Dim minValue As Single = ATM_VALUE - ATM_VALUE * TOLERANCE
                '' 0008782: [KhoiHa - 12/02/2015] Set CG ATM. Currently set CG ATM is only allow plus/minus 10% from ATM. Button should be enable when pressure > (minus 20%) from ATM.
                'Dim maxValue As Single = ATM_VALUE + ATM_VALUE * TOLERANCE
                If minValue <= CG Then 'AndAlso CG <= maxValue Then
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return False
        End Function

        ''' <author>
        '''    	<name>Van Le</name>
        '''    	<date> 2014-08-22</date>
        ''' </author>
        ''' <summary>
        ''' IsSafetySetATM
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsSafetySetVAC() As Boolean
            Dim bRes As Boolean = False
            Try
                If RobotConfigurationValues.LLA_HIVAC_INSTALLED Then
                    If HiVacValveStatus <> WorkingStatuses.On _
                                        AndAlso IGStatus <> WorkingStatuses.On Then

                        Return False
                    End If
                End If

                If VacSwitchStatus <> WorkingStatuses.On Then

                    Return False
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            Return True
        End Function

        ''' <author>
        '''    	<name>Van Le</name>
        '''    	<date> 2014-08-22</date>
        ''' </author>
        ''' <summary>
        ''' IsSafetySetATM
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsSafetySetTurboForelineATM() As Boolean
            Try
                Dim minValue As Single = ATM_VALUE - ATM_VALUE * TOLERANCE
                '' 0008782: [KhoiHa - 12/02/2015] Set CG ATM. Currently set CG ATM is only allow plus/minus 10% from ATM. Button should be enable when pressure > (minus 20%) from ATM.
                'Dim maxValue As Single = ATM_VALUE + ATM_VALUE * TOLERANCE
                If minValue <= TurboForelineCG Then 'AndAlso TurboForelineCG <= maxValue Then
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return False
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2014-10-17</date>
        ''' </author>
        ''' <summary>
        ''' Check Rough installed
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsRoughInstalled() As Boolean
            Try
                If RobotConfigurationValues.LLA_TURBO_VISIBLE Then

                    If RobotConfigurationValues.LLA_HIVAC_INSTALLED Then
                        Return True
                    End If

                Else
                    Return True
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return False
        End Function

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2014-10-21 </date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsRoughOnlyMode() As Boolean
            Try
                If Not (IsCryoInstalled() OrElse IsTurboInstalled()) Then
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            Return False
        End Function

        ''' <author>
        '''    	<name> Kiet Tran </name>
        '''    	<date> 2026-04-23 </date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsCryoInstalled() As Boolean
            AVPLib.Log.coreLogger.Info("Enter IsCryoInstalled")
            Dim blResult As Boolean = False
            Try
                blResult = (Me.Name = ConstEnum.Equipments.LoadLockA.ToString() AndAlso
                    RobotConfigurationValues.LLA_CRYO_VISIBLE)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            AVPLib.Log.coreLogger.Info("Leave IsCryoInstalled" + blResult.ToString())
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Kiet Tran </name>
        '''    	<date> 2026-04-23 </date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsTurboInstalled() As Boolean
            AVPLib.Log.coreLogger.Info("Enter IsTurboInstalled")
            Dim blResult As Boolean = False
            Try
                blResult = (Me.Name = ConstEnum.Equipments.LoadLockA.ToString() AndAlso
                    RobotConfigurationValues.LLA_TURBO_VISIBLE)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            AVPLib.Log.coreLogger.Info("Leave IsTurboInstalled" + blResult.ToString())
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Kiet Tran </name>
        '''    	<date> 2026-04-23 </date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsHivacInstalled() As Boolean
            AVPLib.Log.coreLogger.Info("Enter IsHivacInstalled")
            Dim blResult As Boolean = False
            Try
                blResult = (Me.Name = ConstEnum.Equipments.LoadLockA.ToString() AndAlso
                    RobotConfigurationValues.LLA_HIVAC_INSTALLED)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            AVPLib.Log.coreLogger.Info("Leave IsHivacInstalled" + blResult.ToString())
            Return blResult
        End Function
#End Region
    End Class
End Namespace

