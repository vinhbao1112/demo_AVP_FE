Imports AVPLib.ConstEnum
Namespace DataManagerment

    Public Class Equipment
        Inherits AVPLib.Business.AVPObject
#Region "Class Constants & Variables"
        Public Enum ProcessStatuses
            [PAUSE] = 0
            [START] = 1
            [RESUME] = 2
        End Enum

        Public Enum WorkingStatuses
            [Off] = 0
            [On] = 1
            [Unknown] = 2
            [Abort] = 3 ' Error
            [Other] = 4
            [None] = 5
        End Enum

        Public Enum ControlStatuses
            [OFFLINE] = 0
            [ONLINE] = 1
            [MAINTENANCE] = 2
        End Enum

        Public Enum OperationStatuses
            [READY] = 0
            [BUSY] = 1
            [ERROR] = 2
            [WAITING] 'waiting for pick full wafer to chamber on Batch Process mode
        End Enum

        Private m_intID As Integer
        Protected m_strName As String
        Protected m_enmOperationStatus As OperationStatuses
        Private m_strErrorMessage As String
        Public Event StatusChangedEvent As StatusChangedEventHandler
        Public Event DiagnosPumpDownSample_Event As EventHandler
        Public Event DiagnosRateOfRiseSample_Event As EventHandler
        Public Event DiagnosPumpDownStop_Event As EventHandler
        Public Event DiagnosPumpDownStart_Event As EventHandler
        Public Event DiagnosRateOfRiseStop_Event As EventHandler
        Public Event DiagnosRateOfRiseStart_Event As EventHandler
        Public Event DiagnosRecoverPressureSample_Event As EventHandler
        Public Event DiagnosRecoverPressureStop_Event As EventHandler
        Public Event DiagnosRecoverPressureStart_Event As EventHandler
        Public Event WaferRunStop_Event As EventHandler

        Private m_WaferInside As WorkingStatuses
        Private m_enmControlStatus As ControlStatuses = ControlStatuses.OFFLINE
        Private m_waferInfo As AVPWaferInfo = Nothing
        Private m_objLock As Object = New Object

        Private m_TransferSetPoint As Double

        Private m_Recover_Pressure_Status As WorkingStatuses = WorkingStatuses.Unknown
        Private m_Recover_Pressure_Sample As String = String.Empty
        Private m_Recover_Pressure_FileName As String = String.Empty

        Private m_PumpDown_Curve_Status As WorkingStatuses
        Private m_strPumpDown_Curve_Sample As String
        Private m_strPumpDown_Curve_FileName As String

        Private m_RateOfRise_Status As WorkingStatuses
        Private m_strRateOfRise_Sample As String
        Private m_strRateOfRise_FileName As String
        Protected m_lstWaferInfo(0) As AVPLib.AVPWaferInfo
        Protected m_ProcessingWithWaferFlowName As String = String.Empty
        Protected m_WaferStatus As enumWaferStatus = enumWaferStatus.eWaferNone
        Protected listOfWaferIsProcessing As New List(Of String)
        Protected m_lstOfSlotWafer As New List(Of Integer)
#End Region

#Region "Properties"

#Region "Graph"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set RateOfRise_Start_Stop
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property RateOfRise_Status() As WorkingStatuses
            Get
                Return m_RateOfRise_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                If (m_RateOfRise_Status <> value) Then
                    SequenceRunningStatusText(Me.Name, RATE_OF_RISE_SEQ_NAME, value)
                End If

                m_RateOfRise_Status = value
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "RateOfRise_Status", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_strRateOfRise_Sample
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property RateOfRise_Sample() As String
            Get
                Return m_strRateOfRise_Sample
            End Get
            Set(ByVal value As String)
                m_strRateOfRise_Sample = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_strRateOfRise_FileName
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property RateOfRise_FileName() As String
            Get
                Return m_strRateOfRise_FileName
            End Get
            Set(ByVal value As String)
                If Not (m_strRateOfRise_FileName = value) Then
                    m_strRateOfRise_FileName = value
                End If
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set RateOfRise_Start_Stop
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property PumpDown_Curve_Status() As WorkingStatuses
            Get
                Return m_PumpDown_Curve_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                If (m_PumpDown_Curve_Status <> value) Then
                    SequenceRunningStatusText(Me.Name, PUMPDOWN_CURVE_SEQ_NAME, value)
                End If

                m_PumpDown_Curve_Status = value
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "PumpDown_Curve_Status", VALUELib.ValueType.U1, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_strRateOfRise_Sample
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property PumpDown_Curve_Sample() As String
            Get
                Return m_strPumpDown_Curve_Sample
            End Get
            Set(ByVal value As String)
                m_strPumpDown_Curve_Sample = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_strRateOfRise_FileName
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property PumpDown_Curve_FileName() As String
            Get
                Return m_strPumpDown_Curve_FileName
            End Get
            Set(ByVal value As String)
                If Not (m_strPumpDown_Curve_FileName = value) Then
                    m_strPumpDown_Curve_FileName = value
                End If
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Recover_Pressure_Status
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property Recover_Pressure_Status() As WorkingStatuses
            Get
                Return m_Recover_Pressure_Status
            End Get
            Set(ByVal value As WorkingStatuses)

                If (m_Recover_Pressure_Status <> value) Then
                    SequenceRunningStatusText(Me.Name, RECOVER_PRESSURE_SEQ_NAME, value)
                End If

                m_Recover_Pressure_Status = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_strRateOfRise_Sample
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property Recover_Pressure_Sample() As String
            Get
                Return m_Recover_Pressure_Sample
            End Get
            Set(ByVal value As String)
                m_Recover_Pressure_Sample = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set m_Recover_Pressure_FileName
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property Recover_Pressure_FileName() As String
            Get
                Return m_Recover_Pressure_FileName
            End Get
            Set(ByVal value As String)
                If Not (m_Recover_Pressure_FileName = value) Then
                    m_Recover_Pressure_FileName = value
                End If
            End Set
        End Property
#End Region

        Public Overridable Property WaferStatus() As enumWaferStatus
            Get
                Return m_WaferStatus
            End Get
            Set(ByVal value As enumWaferStatus)
                m_WaferStatus = value
            End Set
        End Property

        Public ReadOnly Property NumberOfWafer() As Int16
            Get
                Return m_lstWaferInfo.Length
            End Get
        End Property

        ''' <author>
        '''    	<name> Hoai Ly </name>
        '''    	<date> 2015-12-28 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set ListOfSlotWafer
        ''' </summary>
        Public ReadOnly Property ListOfSlotWafer() As List(Of Integer)
            Get
                m_lstOfSlotWafer.Clear()
                For Each wafer As AVPWaferInfo In m_lstWaferInfo
                    If wafer IsNot Nothing Then
                        m_lstOfSlotWafer.Add(wafer.SlotID)
                    End If
                Next
                Return m_lstOfSlotWafer
            End Get
        End Property

        Public Property ProcessingWaferFlow() As String
            Get
                Return m_ProcessingWithWaferFlowName
            End Get
            Set(ByVal value As String)
                m_ProcessingWithWaferFlowName = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set AngularLocation of command RSLT
        ''' </summary>
        Public Property TransferSetPoint() As Double
            Get
                Return m_TransferSetPoint
            End Get
            Set(ByVal value As Double)
                m_TransferSetPoint = value
                ''this property is contained in every EQ -> consider when update GEM 
                ' Update SECS/GEM variables by Truc Le
                ' Var Name:TransferSetPoint
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "TransferSetPointPressure", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property
        ''' <author>
        '''    	<name> TODO ADD NAME </name>
        '''    	<date> TODO ADD DATE </date>
        ''' </author>
        ''' <summary>
        ''' Set Wafer Info of  corona chamber
        ''' </summary>
        ''' <remarks></remarks>
        Public Function SetWaferInfo(Optional ByVal waferInfo As AVPWaferInfo = Nothing, Optional ByVal SlotID As Integer = 1) As Boolean
            Dim blResult As Boolean = False
            Try
                If (m_lstWaferInfo IsNot Nothing) Then
                    If (SlotID >= 1 AndAlso SlotID <= m_lstWaferInfo.Length) Then

                        'set a wafer to equipment
                        If (waferInfo IsNot Nothing) Then
                            'set new wafer status  = old wafer wafer status
                            If (WaferInside = WorkingStatuses.On AndAlso (Not IsExistWaferProcessing(waferInfo.WaferID))) AndAlso m_lstWaferInfo.Length > 1 Then
                                waferInfo.WaferStatus = WaferStatus
                            Else
                                WaferStatus = waferInfo.WaferStatus
                            End If
                        End If

                        m_lstWaferInfo(SlotID - 1) = waferInfo

                        'set a wafer none to equipment
                        If (waferInfo Is Nothing) Then
                            'all wafer is empty -> set wafer none
                            If (WaferInside = WorkingStatuses.Off) Then
                                WaferStatus = enumWaferStatus.eWaferNone
                            End If
                        End If

                        blResult = True
                    End If
                Else
                    AVPLib.Log.avpLogger.Error("Missing initialize max wafer slot for " & Me.Name)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function


        ''' <author>
        '''    	<name> TODO ADD NAME </name>
        '''    	<date> TODO ADD DATE </date>
        ''' </author>
        ''' <summary>
        ''' Set Wafer Info of  corona chamber
        ''' </summary>
        ''' <remarks></remarks>
        Public Function SetWaferStatus(ByVal waferstatus As ConstEnum.enumWaferStatus, Optional ByVal SlotID As Integer = 1) As Boolean
            Dim blResult As Boolean = False
            Try
                If (m_lstWaferInfo IsNot Nothing) Then
                    If (SlotID >= 1 AndAlso SlotID <= m_lstWaferInfo.Length) Then
                        If (m_lstWaferInfo(SlotID - 1) IsNot Nothing) Then
                            m_lstWaferInfo(SlotID - 1).WaferStatus = waferstatus
                            blResult = True
                        End If
                    End If
                Else
                    AVPLib.Log.avpLogger.Error("Missing initialize max wafer slot for " & Me.Name)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function

        Public Function GetWaferStatus(ByVal SlotID As Integer) As ConstEnum.enumWaferStatus
            Dim blResult As ConstEnum.enumWaferStatus = enumWaferStatus.eWaferNone
            Try
                If (m_lstWaferInfo IsNot Nothing) Then
                    If (SlotID >= 1 AndAlso SlotID <= m_lstWaferInfo.Length) Then
                        If (m_lstWaferInfo(SlotID - 1) IsNot Nothing) Then
                            blResult = m_lstWaferInfo(SlotID - 1).WaferStatus
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blResult
        End Function
        ''' <author>
        '''    	<name> TODO ADD NAME </name>
        '''    	<date> TODO ADD DATE </date>
        ''' </author>
        ''' <summary>
        ''' Get Wafer Info of  corona chamber
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetWaferInfo(Optional ByVal idx As Integer = 1) As AVPWaferInfo
            Dim waferInfoRS As AVPWaferInfo = Nothing
            Try
                If (m_lstWaferInfo IsNot Nothing) Then
                    If (idx >= 1 AndAlso idx <= m_lstWaferInfo.Length) Then
                        waferInfoRS = m_lstWaferInfo(idx - 1)
                    End If
                Else
                    AVPLib.Log.avpLogger.Error("Missing initialize max wafer slot for " & Me.Name)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return waferInfoRS
        End Function

        Public Function IsEquipmentFree() As Boolean
            Dim bRes = False
            Try
                If (m_lstWaferInfo IsNot Nothing) Then
                    For Each item As AVPWaferInfo In m_lstWaferInfo
                        If item Is Nothing OrElse item.WaferStatus = enumWaferStatus.eWaferNone Then
                            bRes = True
                        Else
                            bRes = False
                        End If
                    Next
                Else
                    bRes = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bRes
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-1-05 </date>
        ''' </author>
        ''' <summary>
        ''' Get Wafer Idx chamber
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetWaferSlotIndex(ByVal WaferID As String) As Integer
            Dim Result As Integer = -1
            Try
                If (m_lstWaferInfo IsNot Nothing) Then
                    Dim waferInfo As AVPWaferInfo = Nothing
                    For i As Integer = 0 To m_lstWaferInfo.Length - 1
                        waferInfo = m_lstWaferInfo(i)
                        If (waferInfo IsNot Nothing AndAlso waferInfo.WaferID = WaferID) Then
                            Result = i + 1
                            Exit For
                        End If
                    Next
                Else
                    AVPLib.Log.avpLogger.Error("Missing initialize max wafer slot for " & Me.Name)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return Result
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-1-05 </date>
        ''' </author>
        ''' <summary>
        ''' Get Next Free slot Idx chamber
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetNextFreeWaferSlotIndex() As Integer
            Dim Result As Integer = -1
            Try
                If (m_lstWaferInfo IsNot Nothing) Then
                    Dim waferInfo As AVPWaferInfo = Nothing
                    For i As Integer = 0 To m_lstWaferInfo.Length - 1
                        waferInfo = m_lstWaferInfo(i)
                        If (waferInfo Is Nothing) Then
                            Result = i + 1
                            Exit For
                        End If
                    Next
                Else
                    AVPLib.Log.avpLogger.Error("Missing initialize max wafer slot for " & Me.Name)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return Result
        End Function
        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set AngularLocation of command RSLT
        ''' </summary>
        Public Property WaferInfo() As AVPWaferInfo
            Get
                Return m_lstWaferInfo(0)
            End Get
            Set(ByVal value As AVPWaferInfo)
                SyncLock m_objLock
                    m_lstWaferInfo(0) = value
                    If m_lstWaferInfo(0) IsNot Nothing Then
                        m_WaferInside = WorkingStatuses.On
                    Else
                        m_WaferInside = WorkingStatuses.Off
                    End If
                End SyncLock
                ''this property is contained in every EQ -> consider when update GEM 
                ' Update SECS/GEM variables by Truc Le
                ' Var Name:Aligner Wafer , Chamber Wafer, TM Wafer
                Dim strWaferID As String
                If value Is Nothing Then
                    strWaferID = ""
                Else
                    strWaferID = Utils.GetGEMWaferID(value.WaferID)
                End If

                If Me.Name.Contains(ConstEnum.Chamber) Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ProcessWaferID", VALUELib.ValueType.A, strWaferID)
                ElseIf Me.Name = ConstEnum.Equipments.Aligner.ToString Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Aligner.WaferID", VALUELib.ValueType.A, strWaferID)
                Else ''Wafer on Robot Arm
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "WaferOnArm", VALUELib.ValueType.A, strWaferID)
                End If

            End Set
        End Property

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current control status (ONLINE, OFFLINE)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ControlStatus() As ControlStatuses
            Get
                If RobotConfigurationValues.DEBUGMODE Then
                    Return ControlStatuses.ONLINE
                End If
                Return m_enmControlStatus
            End Get
            Set(ByVal value As ControlStatuses)
                m_enmControlStatus = value
                ''this property is contained in every EQ -> consider when update GEM 
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Chamber, TM, LL
                If Me.Name.Contains(ConstEnum.Chamber) Then
                    Dim newvalue As ControlStatuses = value
                    If (newvalue = ControlStatuses.MAINTENANCE) Then
                        newvalue = ControlStatuses.OFFLINE
                    End If
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ControlStatus", VALUELib.ValueType.U1, newvalue)
                ElseIf Me.Name.Contains(ConstEnum.LoadLock) Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Name, EMSERVICELib.VarType.SV, "ControlStatus", VALUELib.ValueType.U1, value)
                Else ''Robot
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "ControlStatus", VALUELib.ValueType.U1, value)
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current WaferID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property WaferInside() As WorkingStatuses
            Get
                If m_lstWaferInfo IsNot Nothing Then
                    For Each Item As AVPWaferInfo In m_lstWaferInfo
                        If Item IsNot Nothing AndAlso Item.WaferStatus <> enumWaferStatus.eWaferNone Then
                            m_WaferInside = WorkingStatuses.On
                            Exit For
                        Else
                            m_WaferInside = WorkingStatuses.Off
                        End If
                    Next
                Else
                    m_WaferInside = WorkingStatuses.Off
                End If

                Return m_WaferInside
            End Get
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current id equipment
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ID() As Integer
            Get
                Return m_intID
            End Get
            Set(ByVal value As Integer)
                m_intID = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current name equipment
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Name() As String
            Get
                Return m_strName
            End Get
            Set(ByVal value As String)
                m_strName = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current operation status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OperationStatus() As OperationStatuses
            Get
                Return m_enmOperationStatus
            End Get
            Set(ByVal value As OperationStatuses)
                m_enmOperationStatus = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current a error message
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ErrorMessage() As String
            Get
                Return m_strErrorMessage
            End Get
            Set(ByVal value As String)
                m_strErrorMessage = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-12</date>
        ''' </author>
        ''' <summary>
        ''' Mark For return
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub SetMarkForReturnFlag(Optional ByVal SlotID As Integer = 1)
            If GetWaferInfo(SlotID) IsNot Nothing Then
                ' Set the mark for return value
                GetWaferInfo(SlotID).MarkForReturnEquipment = Me
            Else
                AVPLib.Log.avpLogger.Error("Can not set the Mark For Return")
            End If
        End Sub
        Public Function WaferCapacity() As Integer
            Return (m_lstWaferInfo.Length)
        End Function
        Public Function IsFullWaferCapacity() As Boolean
            Dim blResult As Boolean = True
            Try
                If (m_lstWaferInfo Is Nothing) Then
                    AVPLib.Log.avpLogger.Error("List of Wafer Info is Empty")
                Else

                    For Each Item As AVPWaferInfo In m_lstWaferInfo
                        If (Item Is Nothing) Then
                            Exit For
                        End If
                    Next
                    blResult = False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            Return blResult
        End Function
        Public Function CurrentWaferCount() As Integer
            Dim iResult As Integer = 0
            Try
                If (m_lstWaferInfo Is Nothing) Then
                    AVPLib.Log.avpLogger.Error("List of Wafer Info is Empty")
                Else
                    For Each Item As AVPWaferInfo In m_lstWaferInfo
                        If (Item IsNot Nothing) Then
                            iResult += 1
                        End If
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            Return iResult
        End Function

        ''' <author>
        '''    	<name> Hoai Ly </name>
        '''    	<date> 2015-07-17 </date>
        ''' </author>
        ''' <summary>
        ''' Add Sequence Name To List
        ''' </summary>
        Protected Sub SequenceRunningStatusText(ByVal sEquipmentName As String, ByVal sSequenceName As String, ByVal value As WorkingStatuses)
            Try
                Utils.SequenceRunningStatusText(sEquipmentName, sSequenceName, value.ToString)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-12-08 </date>
        ''' </author>
        ''' <summary>
        ''' Clear List Of Wafer is processing
        ''' </summary>
        Public Sub ClearListOfWafer(Optional ByVal batchProcessCount As Integer = 0)
            Try
                If listOfWaferIsProcessing IsNot Nothing Then
                    If batchProcessCount = 0 OrElse listOfWaferIsProcessing.Count = batchProcessCount Then
                        listOfWaferIsProcessing.Clear()
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-12-08 </date>
        ''' </author>
        ''' <summary>
        ''' Add WaferID To List Of Wafer is processing
        ''' </summary>
        Public Sub AddWaferToList(ByVal waferID As String)
            Try
                If listOfWaferIsProcessing IsNot Nothing AndAlso Not listOfWaferIsProcessing.Contains(waferID) Then
                    listOfWaferIsProcessing.Add(waferID)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-12-08 </date>
        ''' </author>
        ''' <summary>
        ''' Check if wafer id is exist in list of wafer
        ''' </summary>
        Public Function IsExistWaferProcessing(ByVal waferID As String) As Boolean
            Dim result As Boolean = False

            Try
                If listOfWaferIsProcessing IsNot Nothing AndAlso listOfWaferIsProcessing.Contains(waferID) Then
                    result = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try

            Return result
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-12-08 </date>
        ''' </author>
        ''' <summary>
        ''' Get Count Wafer Is Processing
        ''' </summary>
        Public Function GetCountWaferIsProcessing() As Integer
            Dim result As Integer = 0

            Try
                If listOfWaferIsProcessing IsNot Nothing Then
                    result = listOfWaferIsProcessing.Count
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try

            Return result
        End Function
#End Region

#Region "Public methods"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Change a status
        ''' </summary>
        ''' <param name="PropertyNames"></param>
        ''' <param name="ReplyValues"></param>
        ''' <remarks></remarks>
        Public Overridable Sub ChangeStatus(ByVal PropertyNames As ArrayList, ByVal ReplyValues As ArrayList)
            AVPLib.Log.coreLogger.Info("Enter ChangeStatus")
            Try
                Dim PropertyName As String

                For i As Integer = 0 To ReplyValues.Count - 1
                    Dim ReplyValue As Object = ReplyValues(i)
                    If (ReplyValue IsNot Nothing) Then
                        If (i < PropertyNames.Count) Then
                            PropertyName = PropertyNames(i)
                        Else
                            PropertyName = "ErrorMessage"
                        End If
                        Try
                            Dim propInfo As System.Reflection.PropertyInfo = Me.GetType().GetProperty(PropertyName)
                            If (propInfo IsNot Nothing) Then
                                If (propInfo.CanWrite = True) Then
                                    propInfo.SetValue(Me, ReplyValue, Nothing)
                                End If
                            End If
                        Catch ex As Exception
                            AVPLib.Log.avpLogger.Warn(ex.ToString())
                        End Try

                        If PropertyName.Contains("PumpDown_Curve_Sample") Then
                            RaiseEvent DiagnosPumpDownSample_Event(ReplyValue.ToString(), Nothing)
                        ElseIf PropertyName.Contains("RateOfRise_Sample") Then
                            RaiseEvent DiagnosRateOfRiseSample_Event(ReplyValue.ToString(), Nothing)
                        ElseIf PropertyName.Contains("Recover_Pressure_Sample") Then
                            RaiseEvent DiagnosRecoverPressureSample_Event(ReplyValue.ToString(), Nothing)

                        ElseIf PropertyName.Contains("PumpDown_Curve_Status") Then
                            If ReplyValue.ToString() = STR_OFF Then
                                RaiseEvent DiagnosPumpDownStop_Event("PumpDown_Curve_Status", Nothing)
                            ElseIf ReplyValue.ToString() = STR_ON Then
                                RaiseEvent DiagnosPumpDownStart_Event("PumpDown_Curve_Status", Nothing)
                            End If
                        ElseIf PropertyName.Contains("RateOfRise_Status") Then
                            If ReplyValue.ToString() = STR_OFF Then
                                RaiseEvent DiagnosRateOfRiseStop_Event("RateOfRise_Status", Nothing)
                            ElseIf ReplyValue.ToString() = STR_ON Then
                                RaiseEvent DiagnosRateOfRiseStart_Event("RateOfRise_Status", Nothing)
                            End If
                        ElseIf PropertyName.Contains("Recover_Pressure_Status") Then
                            If ReplyValue.ToString() = STR_OFF Then
                                RaiseEvent DiagnosRecoverPressureStop_Event("Recover_Pressure_Status", Nothing)
                            ElseIf ReplyValue.ToString() = STR_ON Then
                                RaiseEvent DiagnosRecoverPressureStart_Event("Recover_Pressure_Status", Nothing)
                            End If

                        ElseIf PropertyName.Contains("WaferRun_Status") And ReplyValue.ToString() = "Off" Then
                            RaiseEvent WaferRunStop_Event("WaferRun_Status", Nothing)
                        End If
                        If Not PropertyName.Contains("SlotStatus") Then ' Treat SlotStatus special.
                            RaisePropertyChangedEvents(PropertyName, ReplyValue)
                        End If
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ChangeStatus")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-29</date>
        ''' </author>
        ''' <summary>
        ''' A helper function that helps raise property changed event.
        ''' </summary>
        ''' <param name="PropertyNames"></param>
        ''' <param name="ReplyValues"></param>
        ''' <remarks></remarks>
        Public Overridable Sub RaisePropertyChangedEvents(ByVal PropertyNames As ArrayList, ByVal changedValues As ArrayList)
            AVPLib.Log.coreLogger.Info("Enter RaisePropertyChangedEvents")
            Try
                Dim PropertyName As String
                For i As Integer = 0 To changedValues.Count - 1
                    Dim changedValue As Object = changedValues(i)
                    If (changedValue IsNot Nothing) Then
                        If (i < PropertyNames.Count) Then
                            PropertyName = PropertyNames(i)
                            Dim ListMessage As ArrayList = MessageGenerator.CreateMessage(Me.Name, PropertyName, changedValue)
                            For Each Message As String In ListMessage
                                Dim sce As New StatusChangedEventArgs()
                                sce.Message = Message
                                Me.StatusChanged(Me, sce)
                            Next
                        End If
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaisePropertyChangedEvents")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-29</date>
        ''' </author>
        ''' <summary>
        ''' A helper function that helps raise property changed event.
        ''' </summary>
        ''' <param name="PropertyNames"></param>
        ''' <param name="ReplyValues"></param>
        ''' <remarks></remarks>
        Public Overridable Sub RaisePropertyChangedEvents(ByVal PropertyName As String, ByVal newVal As Object)
            AVPLib.Log.coreLogger.Info("Enter RaisePropertyChangedEvents")
            Try
                Dim ListMessage As ArrayList = MessageGenerator.CreateMessage(Me.Name, PropertyName, newVal)
                For Each Message As String In ListMessage
                    Dim sce As New StatusChangedEventArgs()
                    sce.Message = Message
                    sce.ChamberName = Me.Name
                    Me.StatusChanged(Me, sce)
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaisePropertyChangedEvents")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Status Changed
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="sce"></param>
        ''' <remarks></remarks>
        Public Sub StatusChanged(ByVal sender As Object, ByVal sce As StatusChangedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter StatusChanged")
            AVPLib.Log.coreLogger.Info("Message=" + sce.Message.ToString())
            RaiseEvent StatusChangedEvent(sender, sce)
            If sce.Message.Contains("ConnectionStatusTo") And sce.Message.contains("Off") _
                           AndAlso (Me.Name = AVPLib.ConstEnum.Equipments.Chamber1.ToString() Or _
                                    Me.Name = AVPLib.ConstEnum.Equipments.Chamber2.ToString() Or _
                                    Me.Name = AVPLib.ConstEnum.Equipments.Chamber3.ToString()) Then
                RaiseEvent DiagnosPumpDownStop_Event(AVPLib.ConstEnum.STR_OFF, Nothing)
                RaiseEvent DiagnosRateOfRiseStop_Event(AVPLib.ConstEnum.STR_OFF, Nothing)
            End If
            AVPLib.Log.coreLogger.Info("Leave StatusChanged")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Stutus changed event handler
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="sce"></param>
        ''' <remarks></remarks>
        Delegate Sub StatusChangedEventHandler(ByVal sender As Object, ByVal sce As StatusChangedEventArgs)

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-08-10</date>
        ''' </author>
        ''' <summary>
        ''' Update Variables For Gem When Init
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Sub UpdateVariableForGemWhenInit()
            Me.ControlStatus = ControlStatus
        End Sub

#End Region
    End Class
End Namespace

