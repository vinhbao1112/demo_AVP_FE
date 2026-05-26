Imports AVPLib.ConstEnum
Imports AVPLib.business
Namespace DataManagerment

    Public Class EquipmentUsedRoughPump
        'declaring a structure named Equipment 
        'Equipment used ROUGH pump
        Private m_EquipmentName As String
        Private m_RoughValveStatus As Equipment.WorkingStatuses
        Private m_isUsedbyCryo As Boolean = False
        Private m_IsPumpdownHighestPriority As Boolean = False

        Public Sub New(ByVal EquipmentName As String, ByVal RoughValveStatus As Equipment.WorkingStatuses)
            m_EquipmentName = EquipmentName
            m_RoughValveStatus = RoughValveStatus
        End Sub

        
        Public Property EquipmentName() As String
            Get
                Return m_EquipmentName
            End Get
            Set(ByVal value As String)
                m_EquipmentName = value
            End Set
        End Property

        Public Property RoughValveStatus() As Equipment.WorkingStatuses
            Get
                Return m_RoughValveStatus
            End Get
            Set(ByVal value As Equipment.WorkingStatuses)
                m_RoughValveStatus = value
            End Set
        End Property

        Public Property IsUsedbyCryo() As Boolean
            Get
                Return m_isUsedbyCryo
            End Get
            Set(ByVal value As Boolean)
                m_isUsedbyCryo = value
            End Set
        End Property

        Public Property IsPumpdownHighestPriority() As Boolean
            Get
                Return m_IsPumpdownHighestPriority
            End Get
            Set(ByVal value As Boolean)
                m_IsPumpdownHighestPriority = value
            End Set
        End Property
    End Class

    '''Init Rough Pump 
    '''ADD Equipment use this rough
    '''Control RoughValve Status
    'Each Rough Pump have list of EquipmentUsedRoughPump structure (read from config)
    'when Open/ Close valve EquipmentUsedRoughPump will be change
    Public Class RoughPumpMachine
        Inherits Equipment
#Region "Class Constants & Variables"
        Private m_dblCG As Double
        'support detect device net communication
        Protected m_CG_Communication As WorkingStatuses = WorkingStatuses.On
        Protected m_WaitingMPOn As String = String.Empty

        Private m_VacSwitchStatus As WorkingStatuses
        Private m_RoughPumpStatus As WorkingStatuses
        Private m_UsedByEquipment As Equipment
        'Read config and store data to list
        Private m_ListOfEquipmentUsed As List(Of EquipmentUsedRoughPump) = Nothing
        Private m_objRoughLineInUseLock As Object = New Object
        Private m_intRoughPumpOnTickCount As Integer = 0
#End Region

#Region "Properties"
        ' Is MP Commnicating
        Private m_blnIsCommunicating As Boolean = False
        Public Property IsCommunicating() As Boolean
            Get
                Return m_blnIsCommunicating
            End Get
            Set(ByVal value As Boolean)
                m_blnIsCommunicating = value
            End Set
        End Property
        Public Property CG_Communication() As WorkingStatuses
            Get
                Return m_CG_Communication
            End Get
            Set(ByVal value As WorkingStatuses)
                m_CG_Communication = value

                If (m_CG_Communication = WorkingStatuses.Off) Then
                    m_dblCG = 0.0
                    UpdateCGPressureError()
                End If

            End Set
        End Property

        Private Sub UpdateCGPressureError()
            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add("CGPressureError")
            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add("Error")

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.Name, PropertyNames, ReplyValues)
        End Sub

        Public Property WaitingMPOn() As String
            Get
                Return m_WaitingMPOn
            End Get
            Set(ByVal value As String)
                m_WaitingMPOn = value
                UpdateWaitingMPOn()
            End Set
        End Property
        Private Sub UpdateWaitingMPOn()
            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add("WaitingMPOnMessager")
            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(m_WaitingMPOn)

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.Name, PropertyNames, ReplyValues)
        End Sub
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current CG RoughPumpMachine
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CG() As Double
            Get
                Return m_dblCG
            End Get
            Set(ByVal value As Double)
                m_dblCG = value

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: RoughPumpPressure
                If (IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.LoadLockA_STR, EMSERVICELib.VarType.SV, "RoughPumpPressure", VALUELib.ValueType.F4, value)

                    If CDbl(value) <= AVPLib.ContainerData.GetPressureConfig("RoughPump_Max_Value") Then
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.LoadLockA_STR, EMSERVICELib.VarType.SV, "RoughPumpPowerOnOff", VALUELib.ValueType.U1, WorkingStatuses.On)
                    Else
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.LoadLockA_STR, EMSERVICELib.VarType.SV, "RoughPumpPowerOnOff", VALUELib.ValueType.U1, WorkingStatuses.Off)
                    End If
                End If

                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: RoughPumpPressure
                If (IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "RoughPumpPressure", VALUELib.ValueType.F4, value)

                    If CDbl(value) <= AVPLib.ContainerData.GetPressureConfig("RoughPump_Max_Value") Then
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "RoughPumpPowerOnOff", VALUELib.ValueType.U1, WorkingStatuses.On)
                    Else
                        Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "RoughPumpPowerOnOff", VALUELib.ValueType.U1, WorkingStatuses.Off)
                    End If
                End If
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current VacSwitchStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property VacSwitchStatus() As WorkingStatuses
            Get
                Return m_VacSwitchStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_VacSwitchStatus = value
            End Set
        End Property

        Public Property RoughPumpStatus() As WorkingStatuses
            Get
                Return m_RoughPumpStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                If m_RoughPumpStatus = WorkingStatuses.Off AndAlso value = WorkingStatuses.On Then
                    m_intRoughPumpOnTickCount = Environment.TickCount
                ElseIf m_RoughPumpStatus = WorkingStatuses.On AndAlso value = WorkingStatuses.Off Then
                    m_intRoughPumpOnTickCount = 0
                End If
                m_RoughPumpStatus = value
            End Set
        End Property
        Public Property RoughPumpStatusOnTickCount() As Integer
            Get
                Return m_intRoughPumpOnTickCount
            End Get
            Set(ByVal value As Integer)
                m_intRoughPumpOnTickCount = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-04-14</date>
        ''' </author>
        ''' <summary>
        ''' Get current CG RoughPumpMachine
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property EquipmentUsed() As List(Of String)
            Get
                Dim arrResult As List(Of String) = Nothing

                If (m_ListOfEquipmentUsed IsNot Nothing) Then
                    arrResult = New List(Of String)
                    For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                        If (Item.RoughValveStatus = WorkingStatuses.On) OrElse (Item.IsUsedbyCryo) Then
                            arrResult.Add(Item.EquipmentName)
                        End If
                    Next
                End If
                Return arrResult
            End Get
        End Property

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-08-09 </date>
        ''' </author>
        ''' <summary>
        ''' Get equipment has highest priority
        ''' </summary>
        ''' <value></value>
        Public ReadOnly Property EquipmentHasHighestPriority() As EquipmentUsedRoughPump
            Get
                If (m_ListOfEquipmentUsed IsNot Nothing) Then
                    For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                        If Item.IsPumpdownHighestPriority Then
                            Return Item
                        End If
                    Next
                End If
                Return Nothing
            End Get
        End Property

#End Region

#Region "Public methods"
        ''' <author>
        '''    	<name> Huy Nguyen </name>
        '''    	<date> 2015-07-03</date>
        ''' </author>
        ''' <summary>
        ''' get Equipment is using this rough pump
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetEquipmentIsUsing() As String
            Dim strEquipment As String = String.Empty

            Try
                If (m_ListOfEquipmentUsed IsNot Nothing) Then

                    For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed

                        If (Item.RoughValveStatus = WorkingStatuses.On) Then
                            strEquipment = Utils.chamberID2ChamberName(Item.EquipmentName)
                            strEquipment = IIf(strEquipment = ConstEnum.Equipments.LoadLockA.ToString, LLA_STR, strEquipment)
                            Exit For
                        ElseIf Item.IsUsedbyCryo Then
                            strEquipment = Utils.chamberID2ChamberName(Item.EquipmentName)
                            strEquipment = IIf(strEquipment = ConstEnum.Equipments.LoadLockA.ToString, LLA_STR, strEquipment & " Cryo")
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            Return strEquipment
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-04-14</date>
        ''' </author>
        ''' <summary>
        ''' Check Equipment used this rough pump
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsUsed(ByVal EquipmentName As String) As Boolean
            Dim blResult As Boolean = False
            Try
                If (m_ListOfEquipmentUsed IsNot Nothing) Then
                    For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                        If (Item.EquipmentName = EquipmentName) Then
                            blResult = True
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' Open Valve OK when all difference valves is closed
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckOpenValveCondition(ByVal EquipmentName As String) As Boolean
            Dim blResult As Boolean = True
            Try
                If (m_ListOfEquipmentUsed IsNot Nothing) Then
                    For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                        If (Item.EquipmentName <> EquipmentName AndAlso Item.RoughValveStatus = WorkingStatuses.On) _
                            OrElse Item.IsUsedbyCryo Then
                            blResult = False
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' check equipment will be use this rough
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckEquipmentUsedRough(ByVal EquipmentName As String) As Boolean
            Dim blResult As Boolean = False
            Try
                If (m_ListOfEquipmentUsed IsNot Nothing) Then
                    For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                        If (Item.EquipmentName = EquipmentName) Then
                            blResult = True
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' check equipment will be use this rough
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function WaitForRoughFree(ByVal EquipmentName As String, ByVal abortedEvent As Threading.ManualResetEvent, _
                        Optional ByVal waitTimeout As Int64 = 300000) As Boolean
            AVPLib.Log.coreLogger.Debug("Enter WaitForRoughFree")
            Dim span As Int64 = waitTimeout ' 5 minutes default.
            Dim start As Int64 = Environment.TickCount
            Dim blResult As Boolean = False
            Try
                While (Environment.TickCount - start <= span)
                    If abortedEvent.WaitOne(0, False) Then
                        AVPLib.Log.coreLogger.Debug("Abored requested.")
                        blResult = False
                        GoTo ExitFunction
                    End If
                    SyncLock m_objRoughLineInUseLock
                        Dim listOfEqUsed As List(Of String) = EquipmentUsed()
                        If (listOfEqUsed IsNot Nothing AndAlso listOfEqUsed.Count = 0) Then
                            blResult = True
                            GoTo ExitFunction
                        ElseIf (listOfEqUsed IsNot Nothing AndAlso _
                        listOfEqUsed.Count = 1 AndAlso listOfEqUsed(0) = EquipmentName) Then
                            blResult = True
                            GoTo ExitFunction
                        End If
                    End SyncLock
                    If abortedEvent.WaitOne(200, False) Then
                        AVPLib.Log.coreLogger.Debug("Abored requested.")
                        blResult = False
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
ExitFunction:
            AVPLib.Log.coreLogger.Debug("Leave WaitForRoughFree")
            RaiseRoughLineInUseEvent()
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' Add Equipment to list
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AddEquipmentWillBeUsed(ByVal EquipmentName As String) As Boolean
            Dim blResult As Boolean = False
            Try

                If (m_ListOfEquipmentUsed Is Nothing) Then
                    m_ListOfEquipmentUsed = New List(Of EquipmentUsedRoughPump)()
                End If

                'default working status is off
                Dim item As EquipmentUsedRoughPump = New EquipmentUsedRoughPump(EquipmentName, WorkingStatuses.Off)
                m_ListOfEquipmentUsed.Add(item)
                blResult = True

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' Make Rough In Use
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function MakeRoughLineInUse(ByVal EquipmentName As String, _
                        ByVal expectedMechanicalPumpPressure As Double, _
                        ByVal abortedEvent As Threading.ManualResetEvent, _
                        Optional ByVal waitTimeout As Int64 = 300000)
            AVPLib.Log.coreLogger.Debug("Enter MakeRoughLineInUse")
            Dim span As Int64 = waitTimeout ' 5 minutes default.
            Dim start As Int64 = Environment.TickCount
            Dim blResult As Boolean = False
            Dim isFreeRough As Boolean = False
            Dim isNeedWaitForRoughStable As Boolean = Not CheckEquipmentUsedRough(EquipmentName)
            Utils.ShowStatusMessage(EquipmentName & ": Waiting for other Rough valve closed with time out " & TimeSpan.FromMilliseconds(waitTimeout).TotalSeconds & "s")
            Try
                While (Environment.TickCount - start <= span)

                    If abortedEvent.WaitOne(0, False) Then
                        AVPLib.Log.coreLogger.Debug("Abored requested.")
                        blResult = False
                        GoTo ExitFunction
                    End If

                    If (CG_Communication = WorkingStatuses.Off) Then
                        blResult = False
                        GoTo ExitFunction
                    End If

                    If (Me.CG < expectedMechanicalPumpPressure) Then
                        SyncLock m_objRoughLineInUseLock
                            If (m_ListOfEquipmentUsed IsNot Nothing) Then
                                'check rough free
                                If (EquipmentUsed IsNot Nothing AndAlso EquipmentUsed.Count > 0) Then
                                    For Each strEqm As String In EquipmentUsed
                                        If (strEqm = EquipmentName) Then
                                            isFreeRough = True
                                            Exit For
                                        End If
                                    Next
                                Else
                                    isFreeRough = True
                                End If

                                If (isFreeRough) Then
                                    For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                                        If (Item.EquipmentName = EquipmentName) Then
                                            Item.RoughValveStatus = WorkingStatuses.On
                                            blResult = True

                                            GoTo ExitFunction
                                        End If
                                    Next
                                End If
                            End If
                        End SyncLock
                    End If

                    If abortedEvent.WaitOne(200, False) Then
                        AVPLib.Log.coreLogger.Debug("Abored requested.")
                        blResult = False
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
ExitFunction:
            '	Rough pump resource delay.  
            'Anytime a rough pump in being shared,  
            'there should be a 5s delay before allocating available pump to other sequence.  
            'Example,  TM with 1 LL rough only configuration.   
            'User autopump TM and LL at the same time,  
            'when TM release mechanical pump resource,  
            'we need to wait 5s before allocating mechanical pump to LL.
            If Not (abortedEvent.WaitOne(0, True)) Then
                If (blResult AndAlso isNeedWaitForRoughStable) Then
                    Utils.Wait(VentPumdownLib.LLPumpdownConfig.LLRoughPumpStable, abortedEvent)
                End If
            End If

            AVPLib.Log.coreLogger.Debug("Leave MakeRoughLineInUse")
            RaiseRoughLineInUseEvent()
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' Make Rough In Use
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function WaitMPPressure(ByVal expectedMechanicalPumpPressure As Double, _
                        ByVal abortedEvent As Threading.ManualResetEvent, _
                        Optional ByVal waitTimeout As Int64 = 300000)
            AVPLib.Log.coreLogger.Debug("Enter MakeRoughLineInUse")
            Dim span As Int64 = waitTimeout ' 5 minutes default.
            Dim start As Int64 = Environment.TickCount
            Dim blResult As Boolean = False
            Try
                While (Environment.TickCount - start <= span)
                    If abortedEvent.WaitOne(0, False) Then
                        AVPLib.Log.coreLogger.Debug("Abored requested.")
                        blResult = False
                        GoTo ExitFunction
                    End If

                    If (CG_Communication = WorkingStatuses.Off) Then
                        blResult = False
                        GoTo ExitFunction
                    End If

                    If (Me.CG < expectedMechanicalPumpPressure) Then
                        blResult = True
                        GoTo ExitFunction
                    End If
                    If abortedEvent.WaitOne(200, False) Then
                        AVPLib.Log.coreLogger.Debug("Abored requested.")
                        blResult = False
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
ExitFunction:
            AVPLib.Log.coreLogger.Debug("Leave MakeRoughLineInUse")

            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' Make Rough In Use
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetRoughLineInUse(ByVal EquipmentName As String, Optional ByVal isUsedbyCryo As Boolean = False) As Boolean
            AVPLib.Log.coreLogger.Debug("Enter SetRoughLineInUse")
            Dim blResult As Boolean = False
            SyncLock m_objRoughLineInUseLock
                If (m_ListOfEquipmentUsed IsNot Nothing) Then

                    For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                        If (Item.EquipmentName = EquipmentName) Then
                            Item.RoughValveStatus = IIf(isUsedbyCryo, WorkingStatuses.Off, WorkingStatuses.On)
                            Item.IsUsedbyCryo = isUsedbyCryo
                            blResult = True
                            Exit For
                        End If
                    Next
                End If
            End SyncLock
            RaiseRoughLineInUseEvent()
            AVPLib.Log.coreLogger.Debug("Leave SetRoughLineInUse")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' Make Rough In Use
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function MakeRoughLineInUseNoWait(ByVal EquipmentName As String, Optional ByVal isManual As Boolean = True) As Boolean
            AVPLib.Log.coreLogger.Debug("Enter MakeRoughLineInUseNoWait")

            Dim blResult As Boolean = False
            Try

                If (CG_Communication = WorkingStatuses.Off) Then
                    blResult = False
                    GoTo ExitFunction
                End If

                Dim objTM As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString)

                If (Me.CG < AVPLib.ConstEnum.ExpectedMechanicalPumpPressureWhenPumpDown) Or _
                    objTM.OverideModeStatus = DataManagerment.Equipment.WorkingStatuses.On Then

                    SyncLock m_objRoughLineInUseLock
                        If (m_ListOfEquipmentUsed IsNot Nothing) Then

                            For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                                If (Item.EquipmentName = EquipmentName) Then
                                    Item.RoughValveStatus = WorkingStatuses.On
                                    blResult = True
                                    GoTo ExitFunction
                                End If
                            Next
                        End If
                    End SyncLock
                ElseIf (isManual) Then
                    Utils.ThrowAlarm("Mechanical Pump CG Pressure is not less than " & _
                    AVPLib.ConstEnum.ExpectedMechanicalPumpPressureWhenPumpDown, Utils.GemGetAlarmName(EquipmentName, AVPLib.ConstEnum.GEM_ALARM_SUB_COMMON_ALARM))                   
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
ExitFunction:
            RaiseRoughLineInUseEvent()
            AVPLib.Log.coreLogger.Debug("Leave MakeRoughLineInUseNoWait")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' for all item in list of equipment using this rough
        ''' raise last equipment name
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub RaiseRoughLineInUseEvent()
            Dim EquipmentName As String = String.Empty
            Dim isUsedbyCryo As Boolean = False
            If (m_ListOfEquipmentUsed IsNot Nothing) Then

                For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                    If (Item.RoughValveStatus = WorkingStatuses.On) OrElse Item.IsUsedbyCryo Then
                        EquipmentName = Item.EquipmentName
                        isUsedbyCryo = Item.IsUsedbyCryo
                    End If
                Next
            End If

            EquipmentName = Utils.ConvertEQName_ToShortName(EquipmentName)
            If isUsedbyCryo Then
                EquipmentName = EquipmentName & " Cryo"
            End If

            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(EquipmentName)

            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add(Me.Name & "InUse")
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus("CassettesModule", PropertyNames, ReplyValues)
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' Release all resource of this rough pump
        ''' raise last equipment name
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ReleaseRoughLineInUse() As Boolean
            AVPLib.Log.coreLogger.Debug("Enter ReleaseRoughLineInUse")
            Dim blResult As Boolean = False
            Try
                SyncLock m_objRoughLineInUseLock
                    For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                        Item.RoughValveStatus = WorkingStatuses.Off
                        Item.IsUsedbyCryo = False
                    Next
                    RaiseRoughLineInUseEvent()
                    blResult = True
                End SyncLock
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            AVPLib.Log.coreLogger.Debug("Leave ReleaseRoughLineInUse")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-12-02</date>
        ''' </author>
        ''' <summary>
        ''' Release  resource by Name
        ''' raise last equipment name
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ReleaseRoughLineInUse(ByVal EquipmentName As String, Optional ByVal isCheckCryoBeforeRelease As Boolean = False) As Boolean
            AVPLib.Log.coreLogger.Debug("Enter ReleaseRoughLineInUse")
            Dim blResult As Boolean = False
            Try
                SyncLock m_objRoughLineInUseLock
                    For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                        If (Item.EquipmentName = EquipmentName) Then

                            If isCheckCryoBeforeRelease AndAlso Item.IsUsedbyCryo Then
                                Continue For
                            End If

                            Item.RoughValveStatus = WorkingStatuses.Off
                            Item.IsUsedbyCryo = False
                            RaiseRoughLineInUseEvent()
                            blResult = True
                            Exit For
                        End If
                    Next
                End SyncLock
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
            AVPLib.Log.coreLogger.Debug("Leave ReleaseRoughLineInUse")
            Return blResult
        End Function
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
            Me.CG = CG 'Update RoughPump Pressure.
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
                Dim minValue As Single = ConstEnum.ATM_VALUE - ConstEnum.ATM_VALUE * ConstEnum.TOLERANCE
                '' 0008782: [KhoiHa - 12/02/2015] Set CG ATM. Currently set CG ATM is only allow plus/minus 10% from ATM. Button should be enable when pressure > (minus 20%) from ATM.
                'Dim maxValue As Single = ConstEnum.ATM_VALUE + ConstEnum.ATM_VALUE * ConstEnum.TOLERANCE
                If minValue <= CG Then 'AndAlso CG <= maxValue Then
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return False
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-08-09</date>
        ''' </author>
        ''' <summary>
        ''' Make pumpdown priority
        ''' </summary>
        Public Function MakePumpdownPriority(ByVal EquipmentName As String, ByVal isPumpdownHighestPriority As Boolean) As Boolean
            AVPLib.Log.coreLogger.Debug("Enter MakePumpdownPriority")
            Dim blResult As Boolean = False
            Try
                SyncLock m_objRoughLineInUseLock
                    If (m_ListOfEquipmentUsed IsNot Nothing) Then
                        For Each Item As EquipmentUsedRoughPump In m_ListOfEquipmentUsed
                            If (Item.EquipmentName = EquipmentName) Then
                                Item.IsPumpdownHighestPriority = isPumpdownHighestPriority
                                blResult = True
                                Exit For
                            End If
                        Next
                    End If
                End SyncLock

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try

            AVPLib.Log.coreLogger.Debug("Leave MakePumpdownPriority")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-08-09</date>
        ''' </author>
        ''' <summary>
        ''' Wait For Make Pumpdown Highest Priority
        ''' </summary>
        Public Function WaitForMakePumpdownHighestPriority(ByVal EquipmentName As String, ByVal abortedEvent As Threading.ManualResetEvent,
                        Optional ByVal waitTimeout As Int64 = 300000) As Boolean
            AVPLib.Log.coreLogger.Debug("Enter WaitPumpdownHighestPriorityComplete")
            Dim span As Int64 = waitTimeout ' 5 minutes default.
            Dim start As Int64 = Environment.TickCount
            Dim blResult As Boolean = False
            Try
                While (Environment.TickCount - start <= span)

                    If abortedEvent.WaitOne(0, False) Then
                        AVPLib.Log.coreLogger.Debug("Abored requested.")
                        blResult = False
                        GoTo ExitFunction
                    End If

                    SyncLock m_objRoughLineInUseLock

                        Dim equipmentHasPumpdownHighestPriority As EquipmentUsedRoughPump = EquipmentHasHighestPriority

                        If (equipmentHasPumpdownHighestPriority Is Nothing) Then
                            MakePumpdownPriority(EquipmentName, True)
                            blResult = True
                            GoTo ExitFunction
                        ElseIf (equipmentHasPumpdownHighestPriority IsNot Nothing) AndAlso (equipmentHasPumpdownHighestPriority.EquipmentName = EquipmentName) Then
                            blResult = True
                            GoTo ExitFunction
                        End If

                    End SyncLock

                    If abortedEvent.WaitOne(200, False) Then
                        AVPLib.Log.coreLogger.Debug("Abored requested.")
                        blResult = False
                    End If
                End While
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
ExitFunction:
            AVPLib.Log.coreLogger.Debug("Leave WaitPumpdownHighestPriorityComplete")
            Return blResult
        End Function
#End Region
    End Class
End Namespace

