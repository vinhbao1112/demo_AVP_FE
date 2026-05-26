Imports RSTiApdater
Imports AVPLib.Driver.DriverConst
Namespace Driver
    Public Class DeviceRSTiDriver
        Inherits DeviceNetDriver
        Implements IDeviceAdapter

#Region "Class"
        Public Class RSTiTask
            Public m_strCommand As String = String.Empty
            Public m_TaskInfo As RSTiObject = Nothing
            Public m_objWriteValue As Object = Nothing

            Public Sub New(ByVal strCommand As String, ByVal taskInfo As RSTiObject, ByVal objWriteValue As Object)
                m_strCommand = strCommand
                m_TaskInfo = taskInfo
                m_objWriteValue = objWriteValue
            End Sub

        End Class
#End Region

#Region "Variables"
        ''' <summary>
        ''' Byte array containing the bit array readback
        ''' </summary>
        Private m_arrReadByteData() As Byte = Nothing

        ''' <summary>
        ''' Unsigned Int value of write data
        ''' </summary>
        Private m_uWriteByteData As Byte = 0

        ''' <summary>
        ''' Byte array containing the bit array set point
        ''' </summary>
        Private m_arrWriteByteData() As Byte = Nothing

        ''' <summary>
        ''' Indicate the first time polling
        ''' </summary>
        Private m_bFirstRead As Boolean = True

        Protected m_arrTmpAnalogWriteBuffer() As Byte = Nothing

        Protected m_arrTmpAnalogReadBuffer() As Byte = Nothing

        Protected m_arrOutBuffer As Byte() = Nothing

        Private m_hstChannelRSTi As Dictionary(Of String, RSTiObject) = Nothing
        Private m_objRSTiAdapterInfo As RSTIAdapterInfo
        Private m_objPumpPackageList As Hashtable
        Private m_hst2Channel As Hashtable = Nothing

        'the first running then update status AO,DO
        Private Const NUM_OF_RETRY As Integer = 10
        Private m_iRetryTime As Integer = 0
        Private m_bFirstWrite As Boolean = True
        Private m_lstWaitingQueue As Queue(Of RSTiTask) = New Queue(Of RSTiTask)
        Private m_objWriteLock As Object = New Object()
        Private Shared m_ListAllDevice As Dictionary(Of String, PropertyObject) = Nothing
#End Region

#Region "New"
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
            m_hstChannelRSTi = New Dictionary(Of String, RSTiObject)
            m_hst2Channel = New Hashtable
        End Sub

        Public Overrides Function Initialize() As Boolean
            m_arrReadByteData = New Byte(m_objRSTiAdapterInfo.InputSize - 1) {}
            m_arrBuffer = New Byte(m_objRSTiAdapterInfo.InputSize - 1) {}
            m_arrWriteByteData = New Byte(m_objRSTiAdapterInfo.OutputSize - 1) {}
            m_arrOutBuffer = New Byte(m_objRSTiAdapterInfo.OutputSize - 1) {}
            MacID = m_objRSTiAdapterInfo.MacID
            Return RegisterEquipment(m_hCardHandle, m_objRSTiAdapterInfo.InputSize, m_objRSTiAdapterInfo.OutputSize, 64)
        End Function
#End Region

#Region "Properties"
        'Driver name as key, RSTiObject as value
        Public ReadOnly Property ListOfChannelRSTi() As Dictionary(Of String, RSTiObject)
            Get
                Return m_hstChannelRSTi
            End Get
        End Property

        'RSTiAdapterInfo
        Public ReadOnly Property ObjRSTiAdapterInfo() As RSTIAdapterInfo
            Get
                Return m_objRSTiAdapterInfo
            End Get
        End Property

        'PumpPackage List
        Public ReadOnly Property ObjPumpPackageList() As Hashtable
            Get
                Return m_objPumpPackageList
            End Get
        End Property
#End Region

#Region "Implementations"
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' Add Channel in Block RSTI
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddChannelRSTi(ByVal objRSTi As RSTiObject) Implements IDeviceAdapter.AddChannelRSTi
            AVPLib.Log.avpLogger.Info("Enter AddChannelRSTi")
            Try
                m_hstChannelRSTi.Add(objRSTi.DriverName, objRSTi)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave AddChannelRSTi")
        End Sub
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-12-27 </date>
        ''' </author>
        ''' <summary>
        ''' Add Adapter Info RSTI
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddAdapterInfoRSTi(ByVal objRSTiAdapterInfo As RSTIAdapterInfo, ByVal objPumpPackageList As Hashtable) Implements IDeviceAdapter.AddAdapterInfoRSTi
            AVPLib.Log.avpLogger.Info("Enter AddAdapterInfoRSTi")
            Try
                m_objRSTiAdapterInfo = objRSTiAdapterInfo
                m_objPumpPackageList = objPumpPackageList

                For Each pair As KeyValuePair(Of String, RSTiObject) In m_hstChannelRSTi
                    Dim objRSTi As RSTiObject = pair.Value
                    Dim iSlotID As Integer = 0
                    Dim iChanelID As Integer = 0
                    Dim isOutput As Boolean = False
                    Dim isAnalog As Boolean = False
                    Dim iBytePos As Integer = 0
                    Dim iBitPos As Integer = 0

                    Integer.TryParse(objRSTi.SlotID, iSlotID)
                    Integer.TryParse(objRSTi.ChannelID, iChanelID)

                    If objRSTi.Type = RSTI_ADAPTER_INPUT_ANALOG_CHANNEL Then
                        isOutput = False
                        isAnalog = True
                    ElseIf objRSTi.Type = RSTI_ADAPTER_OUTPUT_ANALOG_CHANNEL Then
                        isOutput = True
                        isAnalog = True
                    ElseIf objRSTi.Type = RSTI_ADAPTER_INPUT_DISCRETE_CHANNEL Then
                        isOutput = False
                        isAnalog = False
                    ElseIf objRSTi.Type = RSTI_ADAPTER_OUTPUT_DISCRETE_CHANNEL Then
                        isOutput = True
                        isAnalog = False
                    End If

                    objRSTiAdapterInfo.GetBytePosition(objRSTi.SlotID, objRSTi.ChannelID, isOutput, isAnalog, iBytePos, iBitPos)

                    'update for each RSTiObject in m_hstChannelRSTi
                    objRSTi.BytePosition = iBytePos
                    objRSTi.BitPosition = iBitPos
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave AddAdapterInfoRSTi")
        End Sub
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' Set Value of Channel
        ''' </summary>
        ''' <remarks></remarks>
        Public Function SetValue(ByVal value As Double, ByVal sDriverName As String) As Boolean Implements IDeviceAdapter.SetValue
            AVPLib.Log.avpLogger.Info("Enter SetValue")
            Dim blResult As Boolean = False
            Try
                Dim objRSTi As RSTiObject = m_hstChannelRSTi.Item(sDriverName)

                SyncLock m_objWriteLock
                    If m_bFirstWrite Then
                        ' add to waiting list
                        m_lstWaitingQueue.Enqueue(New RSTiTask(RSTI_CMD_VALUE, objRSTi, value))
                        Return True
                    End If
                End SyncLock

                If (value < objRSTi.MinScale Or value > objRSTi.MaxScale) Then
                    Return blResult
                End If

                Dim usValue As UShort = CUShort(CDbl(value - objRSTi.MinScale) * (objRSTi.MaxRawValue - objRSTi.MinRawValue) / _
                                                (objRSTi.MaxScale - objRSTi.MinScale) + objRSTi.MinRawValue)

                m_arrTmpAnalogWriteBuffer = New Byte(1) {}
                m_arrTmpAnalogWriteBuffer = BitConverter.GetBytes(usValue)
                m_arrWriteByteData(objRSTi.BytePosition - 1) = m_arrTmpAnalogWriteBuffer(0)
                m_arrWriteByteData(objRSTi.BytePosition) = m_arrTmpAnalogWriteBuffer(1)
                Write()

                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave SetValue")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function TurnBitOff(ByVal strDriverName As String) As Boolean Implements IDeviceAdapter.TurnBitOff
            AVPLib.Log.avpLogger.Info("Enter TurnBitOff")
            Dim blResult As Boolean = False
            Dim strEquipmentName As String = String.Empty
            Dim strPropertyName As String = String.Empty
            Dim currentState As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Unknown
            Try
                Dim objRSTi As RSTiObject = m_hstChannelRSTi.Item(strDriverName)

                SyncLock m_objWriteLock
                    If m_bFirstWrite Then
                        ' add to waiting list
                        m_lstWaitingQueue.Enqueue(New RSTiTask(RSTI_CMD_ON_OFF, objRSTi, False))
                        Return True
                    End If
                End SyncLock

                Dim uBitMask As Byte = CByte(1 << objRSTi.BitPosition)
                blResult = Me.Off(objRSTi.BytePosition, uBitMask, True)

                'Get EquipmentName, PropertyName
                ParseDriverName(strDriverName, strEquipmentName, strPropertyName)

                'update turbo status
                Dim objState As Object = Nothing
                If strEquipmentName.Contains("PumpPackage") AndAlso strPropertyName = "TurboStatus" Then
                    If (Not m_objPumpPackageList.Item(strEquipmentName)) Then
                        Return blResult
                    End If
                    objState = (Not blResult)
                ElseIf strEquipmentName = "Alarm" AndAlso strPropertyName = "AlarmStatus" Then
                    'Get current state normal
                    objState = IIf(blResult, DataManagerment.Equipment.WorkingStatuses.Off, DataManagerment.Equipment.WorkingStatuses.On)
                    'Update status
                    DriverUtility.UpdateDataStatus(strEquipmentName, "AlarmStatusIOtab", objState)
                    Return blResult
                Else
                    'Get current state normal
                    objState = IIf(blResult, DataManagerment.Equipment.WorkingStatuses.Off, DataManagerment.Equipment.WorkingStatuses.On)
                End If

                'Update status
                DriverUtility.UpdateDataStatus(strEquipmentName, strPropertyName, objState)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave TurnBitOff")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function TurnBitOn(ByVal strDriverName As String) As Boolean Implements IDeviceAdapter.TurnBitOn
            AVPLib.Log.avpLogger.Info("Enter TurnBitOn")
            Dim blResult As Boolean = False
            Dim strEquipmentName As String = String.Empty
            Dim strPropertyName As String = String.Empty
            Dim currentState As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Unknown
            Try
                Dim objRSTi As RSTiObject = m_hstChannelRSTi.Item(strDriverName)

                SyncLock m_objWriteLock
                    If m_bFirstWrite Then
                        ' add to waiting list
                        m_lstWaitingQueue.Enqueue(New RSTiTask(RSTI_CMD_ON_OFF, objRSTi, True))
                        Return True
                    End If
                End SyncLock

                Dim uBitMask As Byte = CByte(1 << objRSTi.BitPosition)
                blResult = Me.On(objRSTi.BytePosition, uBitMask, True)

                'Get EquipmentName, PropertyName
                ParseDriverName(strDriverName, strEquipmentName, strPropertyName)

                ''If PropertyName Is AlarmStaus, not update status for it
                'If strEquipmentName = "Alarm" AndAlso strPropertyName = "AlarmStatus" Then
                '    Return blResult
                'End If

                'update turbo status
                Dim objState As Object = Nothing
                If strEquipmentName.Contains("PumpPackage") AndAlso strPropertyName = "TurboStatus" Then
                    If (Not m_objPumpPackageList.Item(strEquipmentName)) Then
                        Return blResult
                    End If
                    objState = blResult
                ElseIf strEquipmentName = "Alarm" AndAlso strPropertyName = "AlarmStatus" Then
                    'Get current state normal
                    objState = IIf(blResult, DataManagerment.Equipment.WorkingStatuses.On, DataManagerment.Equipment.WorkingStatuses.Off)
                    'Update status
                    DriverUtility.UpdateDataStatus(strEquipmentName, "AlarmStatusIOtab", objState)
                    Return blResult
                Else

                    'Get current state normal
                    objState = IIf(blResult, DataManagerment.Equipment.WorkingStatuses.On, DataManagerment.Equipment.WorkingStatuses.Off)
                End If

                'Update status
                DriverUtility.UpdateDataStatus(strEquipmentName, strPropertyName, objState)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave TurnBitOn")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-04-04 </date>
        ''' </author>
        ''' <summary>
        ''' UpdateWriteData
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub UpdateWriteData(ByVal strCommand As String, ByVal taskInfo As RSTiObject, ByVal objWriteValue As Object)
            AVPLib.Log.avpLogger.Info("Enter UpdateWriteData")
            Try

                Select Case strCommand
                    Case RSTI_CMD_VALUE
                        Dim fValue As Double = CType(objWriteValue, Double)

                        If (fValue < taskInfo.MinScale Or fValue > taskInfo.MaxScale) Then
                            Return
                        End If

                        Dim usValue As UShort = CUShort(CDbl(fValue - taskInfo.MinScale) * (taskInfo.MaxRawValue - taskInfo.MinRawValue) / _
                                                        (taskInfo.MaxScale - taskInfo.MinScale) + taskInfo.MinRawValue)

                        m_arrTmpAnalogWriteBuffer = New Byte(1) {}
                        m_arrTmpAnalogWriteBuffer = BitConverter.GetBytes(usValue)
                        m_arrWriteByteData(taskInfo.BytePosition - 1) = m_arrTmpAnalogWriteBuffer(0)
                        m_arrWriteByteData(taskInfo.BytePosition) = m_arrTmpAnalogWriteBuffer(1)

                    Case RSTI_CMD_ON_OFF
                        Dim isOn As Boolean = CType(objWriteValue, Boolean)
                        Dim uBitMask As Byte = CByte(1 << taskInfo.BitPosition)

                        If isOn Then
                            Me.On(taskInfo.BytePosition, uBitMask, False)
                        Else
                            Me.Off(taskInfo.BytePosition, uBitMask, False)
                        End If

                End Select

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave UpdateWriteData")
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-04-02 </date>
        ''' </author>
        ''' <summary>
        ''' GetOutputData
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetOutputData() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GetOutputData")
            Dim bResult As Boolean = False

            Try
                'read all ouput buffer first
                m_iExplicitMsgSize = 1
                m_ExplicitData = New Byte(0) {}
                m_ExplicitData(0) = 3
                bResult = SendExplicitMessageWithMessageSize(&HE, &H4, &H96)

                If bResult Then
                    If (Wait4ExplicitReplyMsg(5000)) Then
                        Array.Copy(m_ExplicitDataReceive, m_arrWriteByteData, m_objRSTiAdapterInfo.OutputSize)
                        WriteDelayData()
                    Else
                        m_iRetryTime += 1
                        If m_iRetryTime > NUM_OF_RETRY Then
                            WriteDelayData()
                        End If
                    End If
                Else
                    m_iRetryTime += 1
                    If m_iRetryTime > NUM_OF_RETRY Then
                        WriteDelayData()
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
                Return False
            End Try

            AVPLib.Log.avpLogger.Info("Leave GetOutputData")

            Return True
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-04-02 </date>
        ''' </author>
        ''' <summary>
        ''' WriteDelayData
        ''' </summary>
        ''' <remarks></remarks>
        Public Function WriteDelayData() As Boolean
            AVPLib.Log.avpLogger.Info("Enter WriteDelayData")

            Try
                SyncLock m_objWriteLock
                    While (m_lstWaitingQueue.Count > 0)
                        Dim objTask As RSTiTask = m_lstWaitingQueue.Dequeue

                        If ((objTask IsNot Nothing) AndAlso (Not String.IsNullOrEmpty(objTask.m_strCommand)) AndAlso _
                            (objTask.m_TaskInfo IsNot Nothing) AndAlso (objTask.m_objWriteValue IsNot Nothing)) Then

                            UpdateWriteData(objTask.m_strCommand, objTask.m_TaskInfo, objTask.m_objWriteValue)

                        End If
                    End While

                    UpdateProperties("O")
                    Write()
                    m_bFirstWrite = False
                End SyncLock
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
                Return False
            End Try

            AVPLib.Log.avpLogger.Info("Leave WriteDelayData")

            Return True
        End Function

        ''' <summary>
        ''' Read the bit array and store to array and unsigned in value
        ''' </summary>
        Public Sub Read()

            If Me.ReadData() Then
                Array.Copy(m_arrBuffer, m_arrReadByteData, m_objRSTiAdapterInfo.InputSize)
            End If

            If m_bFirstWrite Then
                GetOutputData()
            End If

            UpdateProperties("I")
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-04-04 </date>
        ''' </author>
        ''' <summary>
        ''' UpdateProperties
        ''' </summary>
        ''' <remarks></remarks>
        Public Function UpdateProperties(ByVal strInOrOut As String) As Boolean
            AVPLib.Log.avpLogger.Info("Enter UpdateProperties")

            Try
                Dim blnSecondRead As Boolean = False

                If m_ListAllDevice Is Nothing Then
                    m_ListAllDevice = Driver.DriverManager.ListAllDevice
                End If

                Dim temp() As Byte = New Byte(1) {}
                For Each pair As KeyValuePair(Of String, RSTiObject) In m_hstChannelRSTi
                    Dim objRSTi As RSTiObject = pair.Value

                    If objRSTi.Type = ("A" & strInOrOut) Then
                        'Remember check changed
                        'Get value
                        temp(0) = m_arrReadByteData(objRSTi.BytePosition - 1)
                        temp(1) = m_arrReadByteData(objRSTi.BytePosition)
                        Dim sRawValue As Short = BitConverter.ToInt16(temp, 0)
                        Dim fValue As Double = CDbl((sRawValue - objRSTi.MinRawValue) * ((objRSTi.MaxScale - objRSTi.MinScale) / _
                                                (objRSTi.MaxRawValue - objRSTi.MinRawValue)) + objRSTi.MinScale)
                        'Update to EQ and GUI

                    ElseIf objRSTi.Type = ("D" & strInOrOut) Then
                        'Update to EQ and GUI
                        'Note: SlitValve On/Off has 2 channel -> must and..before update data
                        Dim uBitMask As Byte = CByte(1 << objRSTi.BitPosition)
                        Dim currentState As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Unknown
                        currentState = IIf(GetState(m_arrReadByteData(objRSTi.BytePosition - 1), uBitMask), DataManagerment.Equipment.WorkingStatuses.On, DataManagerment.Equipment.WorkingStatuses.Off)

                        'create m_hst2Channel
                        If (Not m_hst2Channel.ContainsKey(objRSTi.DriverName)) Then
                            m_hst2Channel.Add(objRSTi.DriverName, currentState)
                            Continue For
                        Else
                            blnSecondRead = True
                        End If

                        Dim preState As AVPLib.DataManagerment.Equipment.WorkingStatuses = m_hst2Channel.Item(objRSTi.DriverName)

                        If preState <> currentState Or m_bFirstRead Then
                            'Get equipmentName, propertyName
                            Dim strEquipmentName As String = String.Empty
                            Dim strPropertyName As String = String.Empty

                            ParseDriverName(objRSTi.DriverName, strEquipmentName, strPropertyName)

                            'update value to m_hst2Channel
                            m_hst2Channel.Item(objRSTi.DriverName) = currentState

                            'Get state for 2 channel
                            GetStateFor2Channel(objRSTi, strEquipmentName, strPropertyName, currentState)

                            'If PropertyName Is AlarmStaus, not update status for it
                            If strEquipmentName = "Alarm" AndAlso strPropertyName = "AlarmStatus" Then
                                Continue For
                            End If

                            'update status for turbo up to speed and turbo status
                            Dim objState As Object = Nothing
                            If strEquipmentName.Contains("PumpPackage") Then
                                If (Not m_objPumpPackageList.Item(strEquipmentName)) Then
                                    Continue For
                                End If
                                objState = IIf(currentState = DataManagerment.Equipment.WorkingStatuses.On, True, False)
                            Else
                                objState = currentState
                            End If

                            'Update status
                            DriverUtility.UpdateDataStatus(strEquipmentName, strPropertyName, objState)
                        End If

                    End If

                Next

                m_bFirstRead = (Not blnSecondRead)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
                Return False
            End Try

            AVPLib.Log.avpLogger.Info("Leave UpdateProperties")

            Return True
        End Function

        ''' <summary>
        ''' Write the bit array to device
        ''' </summary>
        Public Sub Write()
            AVPLib.Log.avpLogger.Info("Enter Write")
            Try
                If m_objDnetController.IsDeviceActive(m_DeviceStatus.StatusCode) Then
                    Array.Copy(m_arrWriteByteData, m_arrOutBuffer, m_objRSTiAdapterInfo.OutputSize)
                    WriteData()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave Write")
        End Sub

        ''' <summary>
        ''' Write data to IO device
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function WriteData() As [Boolean]
            ' Please construct m_arrBuffer array before call this function (size = m_DeviceConfig.Output1Size)
            Dim retVal As Boolean = m_objDnetController.WriteDeviceIo(m_hCardHandle, m_DeviceConfig.MacId, m_arrOutBuffer)
            If Not retVal Then
                AVPLib.Log.coreLogger.[Error]("Error when writting data to the device.")
            End If
            Return retVal
        End Function

        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        '''  'Poll data for update gui
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Poll()
            AVPLib.Log.avpLogger.Info("Enter Poll")
            Try
                GetDeviceStatus()
                If m_DeviceStatus IsNot Nothing Then
                    Read()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave Poll")
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-02-27 </date>
        ''' </author>
        ''' <summary>
        '''  Parse Driver Name (DriverName = Alarm.AlarmStatus, equipmentName = Alarm, propertyName = AlarmStatus)
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ParseDriverName(ByVal strDriverName As String, ByRef strEquipmentName As String, ByRef strPropertyName As String)

            AVPLib.Log.avpLogger.Info("Enter ParseDriverName")
            Try
                'Get equipmentName, propertyName
                Dim arrValue As String() = strDriverName.Split(".")

                If arrValue.Length = 2 Then
                    strEquipmentName = arrValue(0)
                    strPropertyName = arrValue(1)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave ParseDriverName")
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-12-31 </date>
        ''' </author>
        ''' <summary>
        '''  Get Current State For 2 Channel (SplitValve1Status On/Off,....)
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub GetStateFor2Channel(ByVal objRSTi As RSTiObject, ByVal strEquipmentName As String, ByRef strPropertyName As String, ByRef currentState As String)
            AVPLib.Log.avpLogger.Info("Enter GetCurrentStateFor2Channel")
            Try

                'm_CurrentState = (SplitValve1Status On/Off,.....)
                Dim arrProperty As String() = strPropertyName.Split(" ")
                If arrProperty.Length = 2 Then
                    Dim strOnOff As String = String.Empty
                    Dim strSignalName As String = String.Empty

                    strPropertyName = arrProperty(0)
                    strOnOff = arrProperty(1)

                    If strOnOff = ConstEnum.STR_ON Then
                        strSignalName = strEquipmentName & "." & strPropertyName & " " & ConstEnum.STR_OFF
                        If m_hst2Channel.ContainsKey(strSignalName) AndAlso currentState = m_hst2Channel.Item(strSignalName) Then
                            currentState = AVPLib.DataManagerment.Equipment.WorkingStatuses.Unknown
                        End If
                    Else
                        strSignalName = strEquipmentName & "." & strPropertyName & " " & ConstEnum.STR_ON
                        If m_hst2Channel.ContainsKey(strSignalName) Then
                            If currentState = m_hst2Channel.Item(strSignalName) Then
                                currentState = AVPLib.DataManagerment.Equipment.WorkingStatuses.Unknown
                            Else
                                currentState = IIf(currentState = AVPLib.DataManagerment.Equipment.WorkingStatuses.On, _
                                 AVPLib.DataManagerment.Equipment.WorkingStatuses.Off, _
                                 AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                            End If
                        End If
                    End If

                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave GetCurrentStateFor2Channel")
        End Sub

        ''' <summary>
        ''' Check if data of solenoid block is changed
        ''' </summary>
        ''' <returns></returns>
        Private Function Changed(ByVal uByte1 As Byte, ByVal uByte2 As Byte) As Boolean
            Return ((uByte1 Xor uByte2) <> 0)
        End Function

        ''' <summary>
        ''' Check if data of solenoid block is changed
        ''' </summary>
        ''' <returns></returns>
        Private Function Changed(ByVal uLowByte1 As Byte, ByVal uHighByte1 As Byte, ByVal uLowByte2 As Byte, ByVal uHighByte2 As Byte) As Boolean
            Return (((uLowByte1 Xor uLowByte2) <> 0) Or ((uHighByte1 Xor uHighByte2) <> 0))
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="uBitMask"></param>
        ''' <returns></returns>
        Public Function GetState(ByVal bByte As Byte, ByVal uBitMask As UInt16) As Boolean
            Return ((bByte And uBitMask) <> 0)
        End Function

        ''' <summary>
        ''' Turn On or Open the device
        ''' </summary>
        ''' <param name="uBitMask"></param>
        Public Function [On](ByVal iByteIndex As Integer, ByVal uBitMask As Byte, ByVal bWrite As Boolean) As Boolean
            AVPLib.Log.avpLogger.Info("Enter DeviceRSTiDriver.[On]")
            Dim blResult As Boolean = False
            Try
                If m_arrWriteByteData Is Nothing Then
                    Exit Try
                End If

                m_uWriteByteData = m_arrWriteByteData(iByteIndex - 1)
                m_uWriteByteData = CByte(m_uWriteByteData Or uBitMask)
                AVPLib.Log.avpLogger.Debug("Write Data = " + m_uWriteByteData.ToString("X"))
                m_arrWriteByteData(iByteIndex - 1) = m_uWriteByteData

                If bWrite Then
                    SyncData()
                End If

                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave DeviceRSTiDriver.[On]")
            Return blResult
        End Function

        ''' <summary>
        ''' Turn Off or Close the device
        ''' </summary>
        ''' <param name="uBitMask"></param>
        Public Function [Off](ByVal iByteIndex As Integer, ByVal uBitMask As Byte, ByVal bWrite As Boolean) As Boolean
            AVPLib.Log.avpLogger.Info("Enter DeviceRSTiDriver.[Off]")
            Dim blResult As Boolean = False
            Try
                m_uWriteByteData = m_arrWriteByteData(iByteIndex - 1)
                m_uWriteByteData = CByte(m_uWriteByteData And (Not uBitMask))
                AVPLib.Log.avpLogger.Debug("Write Data = " + m_uWriteByteData.ToString("X"))
                m_arrWriteByteData(iByteIndex - 1) = m_uWriteByteData

                If bWrite Then
                    SyncData()
                End If

                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave DeviceRSTiDriver.[Off]")
            Return blResult
        End Function

        ''' <summary>
        ''' Read & write data
        ''' </summary>
        Public Sub SyncData()
            GetDeviceStatus()
            'Read()
            Write()
        End Sub

        ''' <summary>
        ''' Reset all IO of Solenoid Block
        ''' </summary>
        ''' <returns></returns>
        Public Function ResetAllIO() As Boolean
            ' Reset all IO
            m_uWriteByteData = 0
            Array.Clear(m_arrWriteByteData, 0, m_arrWriteByteData.Length)

            ' Write to device
            Write()

            Return True
        End Function

#End Region
    End Class
End Namespace
