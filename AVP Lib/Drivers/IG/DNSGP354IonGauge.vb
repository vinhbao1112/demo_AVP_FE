Imports System.Text

Namespace Driver
    Friend Class DNSGP354IonGauge
        Inherits DeviceNetIGDriver

        Private Const TIME_OUT As Int32 = 10000
        Private Const PollInterVal As Int32 = 2000
        ''' <summary>
        ''' The current step to process sending explicit message
        ''' </summary>   
        Protected m_iExplicitSendingMsgStep As Int32 = 0

        ''' <summary>
        ''' Active Filament of IG
        ''' </summary>   
        Private m_iActiveFilament As Int32 = 0

        ''' <summary>
        ''' The current step to process sending explicit message
        ''' </summary>   
        Private m_isCheckFilamentFailed As Boolean = False

        ''' <summary>
        ''' Expected Filament On
        ''' </summary>
        Protected m_isExpectedTurnIGOn As Boolean = False
        Protected objLock = New Object()
        Private m_objConfig As SystemModule = Nothing

        Public Sub New(ByVal sDeviceName As String, ByVal MacID As UInt16, Optional ByVal eDeviceNetIGType As DeviceNetIGCGType = DeviceNetIGCGType.GP354)
            MyBase.New(sDeviceName, MacID, eDeviceNetIGType)
            m_arrPressVal = New Byte(3) {}
        End Sub

        ''' <summary>
        ''' Init Ion Gauge Component
        ''' </summary>
        ''' <param name="CardHandle"></param>
        ''' <param name="DeviceId"></param>
        ''' <returns></returns>
        Public Overrides Function Initialize() As Boolean

            Dim deviceName As String = Me.EquipmentName

            If (Me.EquipmentName = ConstEnum.Equipments.CassettesModule.ToString) Then
                deviceName = ConstEnum.Equipments.Robot.ToString
            End If

            m_objConfig = AVPLib.ContainerData.GetRobotConfig(deviceName)

            Return RegisterEquipment(m_hCardHandle, 5, 1, 64)
        End Function
        ''' <summary>
        ''' Get the IG Pressure from the real device
        ''' </summary>
        Public Overrides Sub Poll()
            Try

                ' Get the pressure value
                If (m_bIsDisposing) Then
                    m_IsRevisionNoValuesVersion = False
                    Exit Sub
                End If

                If Not m_IsRevisionNoValuesVersion Then
                    '' poll Firmware Version
                    PollFirmwareVersion()
                    ' wait 200ms
                    System.Threading.Thread.Sleep(200)
                    ' poll Version
                    PollSoftwareVersion()
                    m_IsRevisionNoValuesVersion = True
                End If

                ReadValue()

                If Not m_bIsOn Then
                    m_fPressure = 0.0F
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Read Pressure Value
        ''' </summary>
        Public Overrides Sub ReadValue()
            Try
                If m_ExplicitState = enExplicitState.explicitIdle Then
                    Select Case m_iExplicitSendingMsgStep
                        Case 0
                        Case 1 ' Reset IG Alarm for next action
                            ' Only reset Alarm when turn on IG
                            If m_isExpectedTurnIGOn Then
                                m_ExplicitData = New Byte(63) {}
                                m_iExplicitMsgSize = 0
                                SendExplicitMessageWithMessageSize(&H63, &H31, &H1)
                            End If
                            m_iExplicitSendingMsgStep += 1
                        Case 2
                            If m_objConfig.Filament = 4 Then
                                m_ExplicitData = New Byte(1) {}
                                m_ExplicitData(0) = 95
                                m_ExplicitData(1) = 0
                                SendExplicitMessage(&HE, &H31, &H1)
                                m_isCheckFilamentFailed = True
                            End If
                            m_iExplicitSendingMsgStep += 1
                        Case 3 ' Really turn IG On/Off
                            m_ExplicitData = New Byte(1) {}
                            m_ExplicitData(0) = 93
                            If m_isExpectedTurnIGOn Then
                                m_ExplicitData(1) = CType(1, Byte)
                            Else
                                m_ExplicitData(1) = CType(0, Byte)
                            End If
                            SendExplicitMessage(&H10, &H31, &H1)
                            m_iExplicitSendingMsgStep += 1
                        Case 4 ' Check if any error
                            m_ExplicitData = New Byte(1) {}
                            m_ExplicitData(0) = 5
                            m_ExplicitData(1) = 0
                            SendExplicitMessage(&HE, &H31, &H1)
                            m_iExplicitSendingMsgStep += 1
                        Case 6 ' Switch IG Filament 1
                            SetCurrentEmission()
                            SetSensitivityValue()
                            m_ExplicitData = New Byte(1) {}
                            m_ExplicitData(0) = 89
                            m_ExplicitData(1) = CType(1, Byte)
                            SendExplicitMessage(&H10, &H31, &H1)
                            m_iExplicitSendingMsgStep = 9
                            AVPLib.Log.avpLogger.Error(Me.EquipmentName & "Set manual filament 1")
                        Case 8 ' Switch IG Filament 2
                            SetCurrentEmission()
                            SetSensitivityValue()
                            m_ExplicitData = New Byte(1) {}
                            m_ExplicitData(0) = 89
                            m_ExplicitData(1) = CType(2, Byte)
                            SendExplicitMessage(&H10, &H31, &H1)
                            m_iExplicitSendingMsgStep += 1
                            AVPLib.Log.avpLogger.Error(Me.EquipmentName & "Set manual filament 2")
                        Case 9 ' Get Filament
                            m_ExplicitData = New Byte(1) {}
                            m_ExplicitData(0) = 89
                            m_ExplicitData(1) = 0
                            SendExplicitMessage(&HE, &H31, &H1)
                            m_iExplicitSendingMsgStep += 1
                            AVPLib.Log.avpLogger.Error(Me.EquipmentName & "Get filament")
                    End Select
                End If

                ' Wait for response message to know the IG status
                If ReceiveExplicit() Then
                    m_ExplicitState = enExplicitState.explicitIdle
                End If

                'update device status
                Me.GetDeviceStatus()

                If m_ExplicitDataReceive IsNot Nothing AndAlso m_ExplicitState = enExplicitState.explicitReceived Then
                    '' Check explicitReceived
                    If m_isCheckFilamentFailed Then
                        'Check if has filament 1 or 2 failed
                        If m_ExplicitDataReceive IsNot Nothing AndAlso m_ExplicitDataReceive.Length > 0 Then
                            Dim iFilamentFailed As Int16 = Convert.ToInt16(m_ExplicitDataReceive(0))
                            Dim iSwitchToFilament As Int16 = 0
                            If iFilamentFailed = 1 AndAlso m_iActiveFilament = iFilamentFailed Then
                                iSwitchToFilament = 2
                            ElseIf iFilamentFailed = 2 AndAlso m_iActiveFilament = iFilamentFailed Then
                                iSwitchToFilament = 1
                            End If

                            If iSwitchToFilament <> 0 Then
                                AVPLib.Log.avpLogger.Error("Switch filament from " & m_iActiveFilament.ToString() & " to " & iSwitchToFilament.ToString())
                                If m_bIsOn Then
                                    ' Turn IG off before switching filament
                                    m_ExplicitData = New Byte(1) {}
                                    m_ExplicitData(0) = 93
                                    m_ExplicitData(1) = CType(0, Byte)
                                    SendExplicitMessage(&H10, &H31, &H1)
                                End If

                                'Switch to another filament
                                m_ExplicitData = New Byte(1) {}
                                m_ExplicitData(0) = 89
                                m_ExplicitData(1) = Convert.ToByte(iSwitchToFilament)
                                If SendExplicitMessage(&H10, &H31, &H1) Then
                                    m_iExplicitSendingMsgStep = 9
                                    AVPLib.Log.avpLogger.Error(Me.EquipmentName & "Auto get filament")
                                End If
                            End If
                        End If
                        m_isCheckFilamentFailed = False
                    End If

                    '' update witch ig filament to GUI
                    If m_iExplicitSendingMsgStep = 10 AndAlso m_ExplicitDataReceive.Length > 0 Then
                        Dim numFilament As Int16 = Convert.ToInt16(m_ExplicitDataReceive(0))
                        m_iActiveFilament = numFilament
                        DriverUtility.UpdateSwitchIGFilament(Me.EquipmentName, numFilament)
                        AVPLib.Log.avpLogger.Error(Me.EquipmentName & " Active filament: " & m_iActiveFilament.ToString())
                    End If
                End If

                'update communication
                UpdateDeviceCommunication()

                'read data from device and store to variable and fire message to business layer
                If Me.ReadData() Then
                    If m_DeviceConfig.Input1Size = 5 Then
                        Dim old_pressure As Single = m_fPressure
                        Dim old_IsOn As Boolean = m_bIsOn
                        m_arrPressVal(0) = m_arrBuffer(1)
                        m_arrPressVal(1) = m_arrBuffer(2)
                        m_arrPressVal(2) = m_arrBuffer(3)
                        m_arrPressVal(3) = m_arrBuffer(4)
                        m_fPressure = BitConverter.ToSingle(m_arrPressVal, 0)

                        If m_fPressure > 10000.0 Then
                            m_fPressure = 0.0F
                        End If

                        m_bIsOn = (m_fPressure > 0)

                        SyncLock objLock
                            If m_iExplicitSendingMsgStep > 3 Then
                                AVPLib.Log.avpLogger.Debug("ReadValue: New IsIGOn " + m_bIsOn.ToString())
                                m_isExpectedTurnIGOn = m_bIsOn
                            End If
                        End SyncLock

                        AVPLib.Log.avpLogger.Debug(EquipmentName & ": " & m_fPressure)

                        If (old_pressure <> m_fPressure) Then
                            DriverUtility.UpdateIGPressure(Me.EquipmentName, m_fPressure)
                        End If

                        If (m_bIsOn <> old_IsOn AndAlso m_bIsOn = True) Then
                            DriverUtility.UpdateIGStatus(Me.EquipmentName, DataManagerment.Equipment.WorkingStatuses.On)

                        ElseIf (m_bIsOn <> old_IsOn AndAlso m_bIsOn = False) Then
                            DriverUtility.UpdateIGStatus(Me.EquipmentName, DataManagerment.Equipment.WorkingStatuses.Off)
                        End If
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Turn Filament On/Off
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overrides Sub TurnIGOnOff(ByVal bOn As Boolean)
            SyncLock objLock
                If m_isExpectedTurnIGOn <> bOn Then
                    m_isExpectedTurnIGOn = bOn
                    m_iExplicitSendingMsgStep = 1
                End If
            End SyncLock
        End Sub

        ''' <summary>
        ''' Switch IG Filament 1
        ''' </summary>
        Public Overrides Function SwitchIGFilament1() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GP354IonGauge.SwitchIGFilament1")
            Dim blResult As Boolean = False
            Try
                m_iExplicitSendingMsgStep = 6
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave GP354IonGauge.SwitchIGFilament1")
            Return blResult
        End Function

        ''' <summary>
        ''' Switch IG Filament 2
        ''' </summary>
        Public Overrides Function SwitchIGFilament2() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GP354IonGauge.SwitchIGFilament2")
            Dim blResult As Boolean = False
            Try
                m_iExplicitSendingMsgStep = 8
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave GP354IonGauge.SwitchIGFilament2")
            Return blResult
        End Function

        ''' <summary>
        ''' Turn On IG
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overrides Function TurnOnIG() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GP354IonGauge.TurnIGOn")
            Dim blResult As Boolean = False
            Try
                SyncLock objLock
                    If m_isExpectedTurnIGOn <> True Then
                        m_isExpectedTurnIGOn = True
                        m_iExplicitSendingMsgStep = 1
                    End If
                End SyncLock
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave GP354IonGauge.TurnIGOn")
            Return blResult
        End Function
        ''' <summary>
        ''' Turn OFF IG
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overrides Function TurnOffIG() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GP354IonGauge.TurnIGOff")
            Dim blResult As Boolean = False
            Try
                SyncLock objLock
                    If m_isExpectedTurnIGOn <> False Then
                        m_isExpectedTurnIGOn = False
                        m_iExplicitSendingMsgStep = 1
                    End If
                End SyncLock
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave GP354IonGauge.TurnIGOff")
            Return blResult
        End Function
        ''' <summary>
        ''' Turn On IG
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overrides Function TurnOnIGDegas() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GP354IonGauge.TurnIGDegasOn")
            Dim blResult As Boolean = False
            Try
                m_ExplicitData = New Byte(1) {}
                m_ExplicitData(0) = 88
                m_ExplicitData(1) = CType(1, Byte)
                SendExplicitMessage(&H10, &H31, &H1) ' Set Service(0x10), Class Code = 49(0x31), Class Instance = 0x01
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave GP354IonGauge.TurnIGDegasOn")
            Return blResult
        End Function
        ''' <summary>
        ''' Turn On IG
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overrides Function TurnOffIGDegas() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GP354IonGauge.TurnIGDegasoff")
            Dim blResult As Boolean = False
            Try
                m_ExplicitData = New Byte(1) {}
                m_ExplicitData(0) = 88
                m_ExplicitData(1) = CType(0, Byte)
                SendExplicitMessage(&H10, &H31, &H1) ' Set Service(0x10), Class Code = 49(0x31), Class Instance = 0x01
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave GP354IonGauge.TurnIGDegasoff")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2024-12-03</date>
        ''' </author>
        ''' <summary>
        ''' PollFirmwareVersion
        ''' </summary>
        Public Function PollFirmwareVersion() As Boolean
            AVPLib.Log.avpLogger.Info("Enter PollFirmwareVersion")
            Dim blResult As Boolean = True
            Try
                m_ExplicitData = New Byte(1) {}
                m_ExplicitData(0) = 4
                m_ExplicitData(1) = 0
                SendExplicitMessage(&HE, &H1, &H1) ' Set Service(0xE), Class Code = 1(0x1), Class Instance = 0x01
                AVPLib.Log.avpLogger.Error(Me.EquipmentName & " Get Firmware Version")

                ' Wait for response message to know the IG status
                If Wait4ExplicitReplyMsg(PollInterVal) Then
                    If m_ExplicitDataReceive IsNot Nothing AndAlso m_ExplicitState = enExplicitState.explicitReceived AndAlso m_ExplicitDataReceive.Length > 0 Then
                        '' Read Firmware Version
                        m_arrFirmwareVersion = New Byte(1) {}
                        m_arrFirmwareVersion(0) = m_ExplicitDataReceive(0)
                        m_arrFirmwareVersion(1) = m_ExplicitDataReceive(1)
                        FirmwareVersionVal = BitConverter.ToString(m_arrFirmwareVersion, 0).Replace("-", " ")
                        AVPLib.Log.avpLogger.Error("AddLog Firmware Version: " & FirmwareVersionVal)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave PollFirmwareVersion")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2024-12-03</date>
        ''' </author>
        ''' <summary>
        ''' PollSoftwareVersion
        ''' </summary>
        Public Function PollSoftwareVersion() As Boolean
            AVPLib.Log.avpLogger.Info("Enter PollSoftwareVersion")
            Dim blResult As Boolean = True
            Try
                m_ExplicitData = New Byte(1) {}
                m_ExplicitData(0) = 7
                m_ExplicitData(1) = 0
                SendExplicitMessage(&HE, &H30, &H1) ' Set Service(0xE), Class Code = 48(0x30), Class Instance = 0x01
                m_IsRevisionNoValuesVersion = True
                AVPLib.Log.avpLogger.Error(Me.EquipmentName & " Get software revision level")

                ' Wait for response message to know the IG status
                If Wait4ExplicitReplyMsg(PollInterVal) Then
                    If m_ExplicitDataReceive IsNot Nothing AndAlso m_ExplicitState = enExplicitState.explicitReceived AndAlso m_ExplicitDataReceive.Length > 0 Then
                        '' Read software revision
                        SoftwareVersionVal = Convert.ToString(m_ExplicitDataReceive(0))
                        AVPLib.Log.avpLogger.Error("AddLog software revision level: " & SoftwareVersionVal)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave PollSoftwareVersion")
            Return blResult
        End Function
        ''' <summary>
        ''' Config the current device
        ''' </summary>
        Public Overrides Sub Setup()
            Try
                ' Determine Current Emission Mode and Level
                SetCurrentEmission()

                '' Set sensitivity value
                SetSensitivityValue()

                ' Use ion gauge filament 1 or filament 2
                m_iExplicitMsgSize = 2
                m_ExplicitData = New Byte(1) {}
                m_ExplicitData(0) = 89
                If m_objConfig.Filament = 3 Then
                    m_ExplicitData(1) = 3
                ElseIf m_objConfig.Filament = 2 Then
                    m_ExplicitData(1) = 2
                Else
                    m_ExplicitData(1) = 1
                End If
                SendExplicitMessage(&H10, &H31, &H1)
                Wait4ExplicitReplyMsg(TIME_OUT)
                m_iExplicitSendingMsgStep = 9

                m_ExplicitState = enExplicitState.explicitIdle
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2018-12-28</date>
        ''' </author>
        ''' <summary>
        ''' Set Current Emission
        ''' </summary>
        Public Sub SetCurrentEmission()
            Try
                ' Determine Current Emission Mode and Level
                Dim bAutoCurrentEmission As [Boolean] = False
                Dim InitialCurrent As [Single] = 0.00002F
                '' 20uA
                If m_objConfig.IonGaugeEmissionCurrent = 1 Then
                    bAutoCurrentEmission = False
                    ' 20uA
                    InitialCurrent = 0.00002F
                ElseIf m_objConfig.IonGaugeEmissionCurrent = 2 Then
                    bAutoCurrentEmission = False
                    ' 1mA
                    InitialCurrent = 0.001F
                ElseIf m_objConfig.IonGaugeEmissionCurrent = 3 Then
                    bAutoCurrentEmission = False
                    ' 4mA
                    InitialCurrent = 0.004F
                ElseIf m_objConfig.IonGaugeEmissionCurrent = 4 Then
                    bAutoCurrentEmission = True
                End If

                ' Turn off auto current
                m_ExplicitData = New Byte(1) {}
                m_ExplicitData(0) = 6
                m_ExplicitData(1) = 0

                If bAutoCurrentEmission Then
                    m_ExplicitData(1) = 1
                Else
                    m_ExplicitData(1) = 0
                End If

                SendExplicitMessage(&H10, &H35, &H1) ' Set Service, Class Code = 199, Class Instance = 3
                Wait4ExplicitReplyMsg(TIME_OUT)

                ' Only Set when Emission Current Mode is Manual
                If False = bAutoCurrentEmission Then
                    ' Set Emission Current Attribute
                    Dim byteVal() As Byte = BitConverter.GetBytes(InitialCurrent)
                    byteVal(2) = &HAC ' Adjust
                    m_ExplicitData = New Byte(4) {}
                    m_ExplicitData(0) = 91 ' Emission Current Attribute
                    m_ExplicitData(1) = byteVal(0)
                    m_ExplicitData(2) = byteVal(1)
                    m_ExplicitData(3) = byteVal(2)
                    m_ExplicitData(4) = byteVal(3)
                    SendExplicitMessage(&H10, &H31, &H1) ' Set Service, Class Code = 49, Class Instance = 1
                    Wait4ExplicitReplyMsg(TIME_OUT)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
        End Sub

        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2018-12-28</date>
        ''' </author>
        ''' <summary>
        ''' Set Sensitivity Value
        ''' </summary>
        Private Sub SetSensitivityValue()
            Try
                '' Set sensitivity value
                Dim sValue As Integer = 20
                Dim byteVals() As Byte = BitConverter.GetBytes(sValue)
                m_iExplicitMsgSize = 5
                m_ExplicitData = New Byte(4) {}
                m_ExplicitData(0) = 90
                m_ExplicitData(1) = byteVals(0)
                m_ExplicitData(2) = byteVals(1)
                m_ExplicitData(3) = byteVals(2)
                m_ExplicitData(4) = byteVals(3)
                SendExplicitMessage(&H10, &H31, &H1) '' Set Service, Class Code = 49, Class Instance = 1 
                Wait4ExplicitReplyMsg(TIME_OUT)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
        End Sub
    End Class
End Namespace