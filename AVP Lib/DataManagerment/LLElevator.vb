Imports System.Threading
Imports AVPLib.Business
Namespace DataManagerment
    Public Class LLElevator
        Inherits Equipment
#Region "Class Constants & Variables"
        Public kNumberOfSlotsCmd As String = "00,S,CF,NS"
        Public kPitchCmd As String = "00,S,CF,PT"
        Public kBaseOffsetCmd As String = "00,S,CF,CT"
        Public kTravelLengthCmd As String = "00,S,CF,LM"
        Public kFindBiasCmd As String = "00,S,FB"
        Public kWaferThicknessType As String = "00,S,SPS,MODE"
        Public kEchoOffCmd As String = "00,S,EC,N"

        Public Sub New(ByVal loadLockName As String)
            Me.Name = loadLockName
            If (Me.Name = ConstEnum.Equipments.LLAElevator.ToString()) Then
                ReDim Preserve m_arrSlotStatus(RobotConfigurationValues.SLOT_NUM_LLA - 1)
                ReDim Preserve m_listWaferInfo(RobotConfigurationValues.SLOT_NUM_LLA - 1)
            End If
        End Sub

        'Private Sub ChangeCommandName4VC2()
        '    Dim tb As Server = DataManagerment.ConfigurationManager.ConfigItemList.Item(Name)
        '    If (tb.Version = "VC2") Then
        '        kNumberOfSlotsCmd = "00," & kNumberOfSlotsCmd
        '        kPitchCmd = "00," & kPitchCmd
        '        kBaseOffsetCmd = "00," & kBaseOffsetCmd
        '        kTravelLengthCmd = "00," & kTravelLengthCmd
        '        kFindBiasCmd = "00," & kFindBiasCmd
        '    End If
        'End Sub

        Private m_arrSlotStatus As ConstEnum.SlotStatuses()
        Private m_listWaferInfo As AVPLib.AVPWaferInfo()

        Private m_enmManualDoorStatus As WorkingStatuses

        Private m_intCurrentSlot As Integer
        Private m_blnIsCommunicating As Boolean
        Private m_strResponseMessage As String

        Private m_enmCLStatus As WorkingStatuses
        Private m_blnMapWaferSuccess As Boolean = True
        Private m_enmCPStatus As WorkingStatuses = WorkingStatuses.Unknown
        Private m_enmDCStatus As WorkingStatuses
        Private m_blnIsCassetPresent As Boolean
        Private m_EventBusyThread As ManualResetEvent = New ManualResetEvent(False)
        Private blnIsAbort As Boolean = False
        Private m_oldDCStatus As WorkingStatuses = WorkingStatuses.Unknown

        Private m_IsHwErrorReceived As Boolean = False
        Private m_HasWaferPresent As WorkingStatuses = WorkingStatuses.Unknown

        ''this mapping is store GEM WAFER ID for each AVP Wafer ID (AVP WAFER ID, GEM ID)
        Private m_MappingGEMWaferID As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Private m_gemWaferStatuses As Dictionary(Of Integer, ConstEnum.enumWaferStatus) = New Dictionary(Of Integer, ConstEnum.enumWaferStatus)

        'ALL CXX (Need to implement this feature with care).   
        'Schedule run or auto transfer.   When place a wafer back to Llx, 
        'before closing Llx iso valve, issue a command �A,GC,xx� then �R,WP�.  
        'If request for wafer is OK then continue on or alarm (�Wafer not found in LLx�) if WP is not OK.  
        'Keep in mind that �R,WP� sometime will cause wafer slide out alarm....   
        '***********************************************************************************************
        'Full Step Mode: id,A,GC,aa
        'Partial Step Mode: id,A,GC,aa,d
        'id:   Two digit device ID.
        'aa:   Slot Position (decimal)
        'd:   UUp
        'D  Down    (Partial Step Mode only)
        '***********************************************************************************************
        Private m_WaferPresentStatus As WorkingStatuses = WorkingStatuses.On

        Private m_version As String
        Private m_WaferSlideOut As WorkingStatuses = WorkingStatuses.Unknown

#End Region

#Region "Properties"
        ''AVP WAFER ID = Keys, GEM ID value
        Public Property MappingGEMWaferID() As Dictionary(Of String, String)
            Get
                Return m_MappingGEMWaferID
            End Get
            Set(ByVal value As Dictionary(Of String, String))
                m_MappingGEMWaferID = value
            End Set
        End Property

        Public Property WaferPresentStatus() As WorkingStatuses
            Get
                Return m_WaferPresentStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_WaferPresentStatus = value
            End Set
        End Property

        Public Property IsHwErrorReceived() As Boolean
            Get
                Return m_IsHwErrorReceived
            End Get
            Set(ByVal value As Boolean)
                m_IsHwErrorReceived = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-01-11</date>
        ''' </author>
        ''' <summary>
        ''' Event Busy Thread
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EventBusyThread() As ManualResetEvent
            Get
                Return Me.m_EventBusyThread
            End Get
            Set(ByVal value As ManualResetEvent)
                m_EventBusyThread = value
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
        Public Overloads Property OperationStatus() As OperationStatuses
            Get
                Return Me.m_enmOperationStatus
            End Get
            Set(ByVal value As OperationStatuses)
                If Not blnIsAbort Then
                    If (value = Equipment.OperationStatuses.BUSY) Then
                        m_EventBusyThread.Set()
                    Else
                        m_EventBusyThread.Reset()
                    End If
                    m_enmOperationStatus = value
                End If
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current SlotStatus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SlotStatus() As Integer()
            Get
                Return m_arrSlotStatus
            End Get
            Set(ByVal listOfWafers As Integer())
                ' After mapping wafers in LL, if wafer id is duplicated with the one in PMs, do not update map result and alarm "Duplicate wafer id".
                Dim ListOfWafersIdExist As List(Of String) = Utils.GetWaferIdsFromChambers(IIf(Me.Name = AVPLib.ConstEnum.Equipments.LLAElevator.ToString(), True, False))
                For idx As Integer = 0 To listOfWafers.Length() - 1
                    If listOfWafers(idx) = ConstEnum.SlotStatuses.Available Then
                        Dim newWaferId As String = Utils.GenerateWaferID(idx + 1, Me.Name)
                        If ListOfWafersIdExist.Contains(newWaferId) Then
                            ' Alarm.
                            Dim strAlarm As String = ConstEnum.LLA_STR
                            strAlarm = strAlarm & ": There is duplicated wafer id - " & newWaferId 'not good for this thing
                            Utils.ThrowAlarm(strAlarm, Utils.GemGetAlarmName(Me.Name))
                            Return
                        End If
                    End If
                Next
                ' Commit mapped wafers.
                Dim intSlot As Integer = 0
                m_arrSlotStatus = listOfWafers
                For iIndex As Integer = 0 To SlotStatus.Length() - 1
                    If SlotStatus(iIndex) = ConstEnum.SlotStatuses.Available Then
                        Dim waferinfo As AVPWaferInfo = New AVPWaferInfo(Utils.GenerateWaferID(iIndex + 1, Me.Name), iIndex + 1, ConstEnum.enumWaferStatus.eWaferNew)
                        ListOfWaferInfo(iIndex) = waferinfo
                        intSlot += 1
                    Else
                        ListOfWaferInfo(iIndex) = Nothing
                    End If
                Next
                '''
                If intSlot > 0 Then
                    'map success
                    MapWaferSuccess = True
                Else ''map failed
                    MapWaferSuccess = False
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[LogLoad]- MapWaferSuccess " & MapWaferSuccess)
                ' Raise Event
                RaisePropertyChangedEvents("SlotStatus", listOfWafers)

                UpdateGEMWaferMapInfo()
                UpdateGEMWaferStatuses()
          
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current CurrentSlot
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CurrentSlot() As Integer
            Get
                Return m_intCurrentSlot
            End Get
            Set(ByVal value As Integer)
                m_intCurrentSlot = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current IsCommunicating
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsCommunicating() As Boolean
            Get
                Return m_blnIsCommunicating
            End Get
            Set(ByVal value As Boolean)
                m_blnIsCommunicating = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: CommunicationStatus
                Dim strLLName As String = ConstEnum.Equipments.LoadLockA.ToString()
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, "CommunicationStatus", VALUELib.ValueType.U1, IIf(value, 1, 0))
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current Response Message
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ResponseMessage() As String
            Get
                Return m_strResponseMessage
            End Get
            Set(ByVal value As String)
                m_strResponseMessage = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current manual door status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ManualDoorStatus() As WorkingStatuses
            Get
                Return m_enmManualDoorStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmManualDoorStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current CLStatus LLElevator
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CLStatus() As WorkingStatuses
            Get
                Return m_enmCLStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmCLStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Van Le </name>
        '''    	<date> 2012-3-21</date>
        ''' </author>
        ''' <summary>
        ''' Get current CLStatus LLElevator
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MapWaferSuccess() As Boolean
            Get
                Return m_blnMapWaferSuccess
            End Get
            Set(ByVal value As Boolean)
                m_blnMapWaferSuccess = value
                If value Then
                    RaisePropertyChangedEvents("MapWaferSuccess", ConstEnum.MAPPING_SUCCESS)
                Else
                    RaisePropertyChangedEvents("MapWaferSuccess", ConstEnum.MAPPING_FAIL)
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current CPStatus LLElevator--Cassette Present
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CPStatus() As WorkingStatuses
            Get
                Return m_enmCPStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                Dim LoadlockName As String = ConstEnum.LoadLockA_STR
                Dim objLoadLockController As LoadLockController = CType(ControllerManager.GetController(LoadlockName), LoadLockController)

                If objLoadLockController Is Nothing Then
                    Exit Property
                End If
                Dim objElevatorController As LLElevatorController = CType(objLoadLockController.ChildController.Item("LLElevator"), LLElevatorController)

                If m_enmCPStatus <> value OrElse Me.DCStatus <> m_oldDCStatus Then
                    If value = WorkingStatuses.Off AndAlso Me.DCStatus = WorkingStatuses.On Then
                        ''Cassette is not present
                        ''''AVP. Currently we clear all wafers when LLx door open. We need to change to this to clear all wafers when cassette is not present.
                        objElevatorController.ClearAlWafers()
                    End If
                End If
                m_enmCPStatus = value
                m_oldDCStatus = Me.DCStatus
                ''Update SECS/GEM Variable
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(LoadlockName, EMSERVICELib.VarType.SV, _
                                                                             "IsCassettePlaced", VALUELib.ValueType.Bo, _
                                                                             IIf(value = WorkingStatuses.Off, False, True))
                

            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current DCStatus LLElevator--LL Door
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DCStatus() As WorkingStatuses
            Get
                Return m_enmDCStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                ''''''''''Raise Event LL Door Open/Close to SECS/GEM
                Dim LoadlockName As String = ConstEnum.LoadLockA_STR
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: IsDoorClosed--> Value = On - Door Open, Value = Off - Door Close
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(LoadlockName, EMSERVICELib.VarType.SV, _
                                                                 "IsDoorClosed", VALUELib.ValueType.Bo, _
                                                                 IIf(value = WorkingStatuses.Off, True, False))
                ''trigger Event
                If m_enmDCStatus <> value AndAlso value = WorkingStatuses.On Then
                    AVPLib.Business.AVPSecsGemLib.TriggerEvent(LoadlockName, "LLDoorOpened")
                ElseIf m_enmDCStatus <> value AndAlso value = WorkingStatuses.Off Then
                    AVPLib.Business.AVPSecsGemLib.TriggerEvent(LoadlockName, "LLDoorClosed")
                End If

                ''''''''''''''''''''''''''
                m_enmDCStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc</name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set AngularLocation of command RSLT
        ''' </summary>
        Public Property ListOfWaferInfo() As AVPWaferInfo()
            Get
                Return m_listWaferInfo
            End Get
            Set(ByVal value As AVPWaferInfo())
                m_listWaferInfo = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Dy Do </name>
        '''    	<date> 2015-06-30 </date>
        ''' </author>
        ''' <summary>
        ''' Get current HasWaferPresent LLElevator
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property HasWaferPresent() As WorkingStatuses
            Get
                Return m_HasWaferPresent
            End Get
            Set(ByVal value As WorkingStatuses)
                m_HasWaferPresent = value
            End Set
        End Property
    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2024-01-24</date>
    ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the set of configs.
        ''' </summary>
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
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates firmware version of elevator.
        ''' </summary>
        Public Property Version() As String
            Get
                Return m_version
            End Get
            Set(ByVal value As String)
                m_version = value
                m_RevisionNoValues = m_version
            End Set
        End Property
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-03-25 </date>
        ''' </author>
        ''' <summary>
        ''' WaferSlideOut
        ''' </summary>
        Public Property WaferSlideOut() As WorkingStatuses
            Get
                Return m_WaferSlideOut
            End Get
            Set(ByVal value As WorkingStatuses)
                m_WaferSlideOut = value
            End Set
        End Property

#End Region

#Region "Public methods"

        Public Function Build_Mapping_GEMWaferID_AVPWaferID(ByVal ArrWaferIDs As String()) As Boolean
            Try ''stored Host Wafer ID
                m_MappingGEMWaferID.Clear()
                Dim strGEMWAFERID As String = String.Empty
                Dim WaferIDPrefix As String = "A"

                ''Generate map
                For i As Integer = 0 To ListOfWaferInfo.Length - 1

                    If ArrWaferIDs IsNot Nothing AndAlso (i < ArrWaferIDs.Length) Then
                        strGEMWAFERID = ArrWaferIDs(i) ''get item in GEM ID list
                    Else
                        ''if GEM ID List < List of AVP Wafer 
                        strGEMWAFERID = String.Empty
                    End If

                    If (ListOfWaferInfo(i) IsNot Nothing) Then ''if wafer exist
                        'Gem ID or AVP Wafer ID
                        strGEMWAFERID = IIf(String.IsNullOrEmpty(strGEMWAFERID), ListOfWaferInfo(i).WaferID, strGEMWAFERID)
                        m_MappingGEMWaferID.Add(ListOfWaferInfo(i).WaferID, strGEMWAFERID)
                    Else
                        'if wafer doesn't exist -> auto create mapping (avp Wafer ID - Gem ID)
                        strGEMWAFERID = IIf(String.IsNullOrEmpty(strGEMWAFERID), WaferIDPrefix & Format(i + 1, "00"), strGEMWAFERID)
                        m_MappingGEMWaferID.Add(WaferIDPrefix & Format(i + 1, "00"), strGEMWAFERID)
                    End If
                Next
                'applied Host Wafer ID to Chamber, Aligner, TM wafer
                Utils.Applied_Host_WaferID()

                'applied Host Wafer ID and update WaferMapInfo
                Dim strWaferMapping As String = LLElevatorUtility.GenerateWaferMappingInfo(ListOfWaferInfo, m_MappingGEMWaferID, WaferIDPrefix)
                Dim strLLName As String = ConstEnum.Equipments.LoadLockA.ToString()
                AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, _
                                 "WaferMapInfo", VALUELib.ValueType.A, strWaferMapping)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
                Return False
            End Try
            Return True
        End Function

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-01-11</date>
        ''' </author>
        ''' <summary>
        ''' Abort
        ''' </summary>
        Public Sub Abort()
            AVPLib.Log.coreLogger.Info("Enter Abort")
            Try
                OperationStatus = OperationStatuses.READY
                blnIsAbort = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Abort")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-17</date>
        ''' </author>
        ''' <summary>
        ''' Clear all Status Graph
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ClearStatusGraph()
            AVPLib.Log.coreLogger.Info("Enter ClearStatusGraph")
            Try
                For i As Integer = 0 To Me.SlotStatus.Length - 1
                    Me.SlotStatus(i) = 0

                    'Begin raise Message to Gui
                    Dim PropertyName As String = "StatusGraph " + (i + 1).ToString()
                    Dim ReplyValue As String = ConstEnum.SlotStatuses.Empty.ToString()
                    Dim ListMessage As ArrayList = MessageGenerator.CreateMessage(Me.Name, PropertyName, ReplyValue)
                    For Each Message As String In ListMessage
                        Dim sce As New StatusChangedEventArgs()
                        sce.Message = Message
                        Me.StatusChanged(Me, sce)
                    Next
                    UpdateSecGemUnloadProcessing(i + 1)
                    'End raise Message to Gui
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ClearStatusGraph")
        End Sub

        ''' <author>Duc Pham</author>
        ''' <date>2018-11-01</date>
        ''' <summary>
        ''' Update GEM status of all slots.
        ''' </summary>
        Public Sub UpdateGEMWaferStatuses()
            AVPLib.Log.coreLogger.Info("Enter UpdateGEMWaferStatuses")
            Try
                Dim loadLockName As String = ConstEnum.LoadLockA_STR
             
                If m_listWaferInfo IsNot Nothing Then
                    For slot As Integer = 1 To m_listWaferInfo.Length
                        Dim currentWaferStatus As ConstEnum.enumWaferStatus = ConstEnum.enumWaferStatus.eWaferNone
                        If m_listWaferInfo(slot - 1) IsNot Nothing Then
                            currentWaferStatus = m_listWaferInfo(slot - 1).WaferStatus
                        End If

                        Dim previousWaferStatus As ConstEnum.enumWaferStatus = ConstEnum.enumWaferStatus.eWaferNone
                        If m_gemWaferStatuses.ContainsKey(slot) Then
                            previousWaferStatus = m_gemWaferStatuses(slot)
                        End If

                        m_gemWaferStatuses(slot) = currentWaferStatus

                        Utils.UpdataMaterialStateAndTriggerEvent(loadLockName, currentWaferStatus, previousWaferStatus, slot)
                    Next
                Else
                    For slot As Integer = 1 To m_arrSlotStatus.Length
                        Utils.UpdataMaterialStateAndTriggerEvent(loadLockName, ConstEnum.enumWaferStatus.eWaferNone, ConstEnum.enumWaferStatus.eWaferNone, slot)
                    Next
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.coreLogger.Info("Leave UpdateGEMWaferStatuses")
        End Sub

        Private Sub UpdateSecGemUnloadProcessing(ByVal iSlot As Integer)
            AVPLib.Log.coreLogger.Info("Enter UpdateSecGemUnloadProcessing")
            Try
                Dim LoadlockName As String = ConstEnum.LoadLockA_STR
                AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(LoadlockName, EMSERVICELib.VarType.SV, _
    "MaterialStatusState" & iSlot.ToString(), VALUELib.ValueType.U1, AVPLib.ConstEnum.enumWaferStatus.eWaferNone)
                'trigger event
                Business.AVPSecsGemLib.TriggerEvent(LoadlockName, "MaterialStatusStateChanged" & iSlot.ToString())
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UpdateSecGemUnloadProcessing")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-17</date>
        ''' </author>
        ''' <summary>
        ''' Status Graph that added to HashTable
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetStatusGraph(ByVal iSlotID As Integer, ByVal waferInfo As AVPWaferInfo)
            AVPLib.Log.coreLogger.Info("Enter SetStatusGraph")
            Try
                Dim ReplyValue As String = ConstEnum.enumWaferStatus.eWaferNew.ToString()
                'Begin set SlotStatuses
                If (waferInfo Is Nothing) Then
                    Me.SlotStatus(iSlotID - 1) = ConstEnum.SlotStatuses.Empty
                    ReplyValue = ConstEnum.enumWaferStatus.eWaferNone.ToString()
                    Me.ListOfWaferInfo(iSlotID - 1) = waferInfo
                Else
                    Me.SlotStatus(iSlotID - 1) = ConstEnum.SlotStatuses.Available
                    ReplyValue = waferInfo.WaferStatus.ToString()
                    waferInfo.SlotID = iSlotID
                    Me.ListOfWaferInfo(iSlotID - 1) = waferInfo
                    waferInfo.WaferProcessingStatus = ConstEnum.WaferProcessingState.IN_CASSETTE_MODULE
                End If

                'Begin raise Message to Gui
                Dim PropertyName As String = "StatusGraph"
                Dim strVal As String = iSlotID.ToString() & " " & ReplyValue
                Dim ListMessage As ArrayList = MessageGenerator.CreateMessage(Me.Name, PropertyName, strVal)

                For Each Message As String In ListMessage
                    Dim sce As New StatusChangedEventArgs()
                    sce.Message = Message
                    Me.StatusChanged(Me, sce)
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetStatusGraph")
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
        ''' Change status LLElevator
        ''' </summary>
        ''' <param name="PropertyNames"></param>
        ''' <param name="ReplyValues"></param>
        ''' <remarks></remarks>
        Public Overrides Sub ChangeStatus(ByVal PropertyNames As System.Collections.ArrayList, ByVal ReplyValues As System.Collections.ArrayList)
            'modify 
            AVPLib.Log.coreLogger.Info("Enter ChangeStatus")
            MyBase.ChangeStatus(PropertyNames, ReplyValues)
            AVPLib.Log.coreLogger.Info("Leave ChangeStatus")
        End Sub

        ''' <author>
        '''    	<name> Le Hieu Truc</name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        Public Function GetWaferInfo_ByJobId(ByVal jobId As String) As AVPWaferInfo
            For Each objWaferInfo As AVPWaferInfo In Me.ListOfWaferInfo()
                If objWaferInfo IsNot Nothing AndAlso objWaferInfo.WaferID = jobId Then
                    Return objWaferInfo
                End If
            Next
            Return Nothing
        End Function

        Public Sub UpdateGEMWaferMapInfo()
            Try
                ''Update SVID WaferMapInfo to GEM
                Dim strLLName As String = String.Empty
                Dim strWaferMapping As String = String.Empty
                If (Me.Name = ConstEnum.Equipments.LLAElevator.ToString()) Then
                    strLLName = ConstEnum.Equipments.LoadLockA.ToString()
                    strWaferMapping = LLElevatorUtility.GenerateWaferMappingInfo(ListOfWaferInfo, MappingGEMWaferID, "A")
                End If

                AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, _
                                 "WaferMapInfo", VALUELib.ValueType.A, strWaferMapping)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
#End Region
    End Class
End Namespace

