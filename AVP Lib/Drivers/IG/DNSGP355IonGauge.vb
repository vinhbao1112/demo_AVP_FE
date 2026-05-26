Imports System.Text

Namespace Driver
    Friend Class DNSGP355IonGauge
        Inherits DNSGP354IonGauge

        ''' <summary>
        ''' Active Filament of IG
        ''' </summary>   
        Private m_iActiveFilament As Int32 = 0

        ''' <summary>
        ''' The current step to process sending explicit message
        ''' </summary>   
        Private m_isCheckFilamentFailed As Boolean = False

        ''' <summary>
        ''' Expected Turn IG Degas On/Off
        ''' </summary>
        Private isExpectedTurnIGDegasOn As Boolean = False

        ''' <summary>
        ''' Is Turning IG Off
        ''' </summary>
        Private isTurningIGOff As Boolean = False

        Private Const TIME_OUT As Int32 = 10000

        Private m_objConfig As SystemModule = Nothing

        Public Sub New(ByVal sDeviceName As String, ByVal MacID As UInt16)
            MyBase.New(sDeviceName, MacID, DeviceNetIGCGType.GP355)
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

            Return RegisterEquipment(m_hCardHandle, 0, 0, 64)
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
                If m_DeviceStatus IsNot Nothing Then
                    ReadValue()
                End If

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
                        Case 0 '' Get IG Pressure Readback
                            m_ExplicitData = New Byte(0) {}
                            m_ExplicitData(0) = &H6
                            SendExplicitMessage(&HE, &H31, &H1)
                        Case 1 ' Reset IG Alarm for next action
                            ' Only reset Alarm when turn on IG
                            If m_isExpectedTurnIGOn Then
                                m_ExplicitData = New Byte(63) {}
                                m_iExplicitMsgSize = 0
                                SendExplicitMessageWithMessageSize(&H63, &H31, &H1)
                            End If
                            m_iExplicitSendingMsgStep += 1
                        Case 2 ' Really turn IG On/Off
                            m_ExplicitData = New Byte(1) {}
                            m_ExplicitData(0) = &H5D
                            If m_isExpectedTurnIGOn Then
                                System.Threading.Thread.Sleep(5000)
                                m_ExplicitData(1) = CType(1, Byte)
                            Else
                                isTurningIGOff = True
                                m_ExplicitData(1) = CType(0, Byte)
                            End If
                            SendExplicitMessage(&H10, &H31, &H1)
                            m_iExplicitSendingMsgStep = 0
                        Case 3 '' Turn IG Degas On/Off
                            m_ExplicitData = New Byte(0) {}
                            If isExpectedTurnIGDegasOn Then
                                m_ExplicitData(0) = CType(1, Byte)
                            Else
                                m_ExplicitData(0) = CType(0, Byte)
                            End If
                            SendExplicitMessage(&H61, &H31, &H1)
                            m_iExplicitSendingMsgStep = 0
                        Case 4 ' Switch IG Filament 1
                            m_ExplicitData = New Byte(1) {}
                            m_ExplicitData(0) = 89
                            m_ExplicitData(1) = CType(1, Byte)
                            SendExplicitMessage(&H10, &H31, &H1)
                            m_iExplicitSendingMsgStep = 6
                            AVPLib.Log.avpLogger.Error(Me.EquipmentName & " Set manual filament 1")
                        Case 5 ' Switch IG Filament 2
                            m_ExplicitData = New Byte(1) {}
                            m_ExplicitData(0) = 89
                            m_ExplicitData(1) = CType(2, Byte)
                            SendExplicitMessage(&H10, &H31, &H1)
                            m_iExplicitSendingMsgStep += 1
                            AVPLib.Log.avpLogger.Error(Me.EquipmentName & " Set manual filament 2")
                        Case 6 'Get Filament
                            m_ExplicitData = New Byte(1) {}
                            m_ExplicitData(0) = 89
                            m_ExplicitData(1) = 0
                            SendExplicitMessage(&HE, &H31, &H1)
                            m_iExplicitSendingMsgStep += 1
                            AVPLib.Log.avpLogger.Error(Me.EquipmentName & " Get filament")
                    End Select
                End If

                ' Wait for response message to know the IG status
                If ReceiveExplicit() Then
                    m_ExplicitState = enExplicitState.explicitIdle
                End If

                'update communication
                UpdateDeviceCommunication()

                If m_ExplicitDataReceive IsNot Nothing AndAlso m_ExplicitState = enExplicitState.explicitReceived AndAlso m_ExplicitDataReceive.Length > 0 Then
                    ' update switch ig filament to GUI
                    If m_iExplicitSendingMsgStep = 7 Then
                        Dim numFilament As Int16 = Convert.ToInt16(m_ExplicitDataReceive(0))
                        m_iActiveFilament = numFilament
                        m_iExplicitSendingMsgStep = 0
                        DriverUtility.UpdateSwitchIGFilament(Me.EquipmentName, numFilament)
                        AVPLib.Log.avpLogger.Error(Me.EquipmentName & " Active filament: " & m_iActiveFilament.ToString())
                    ElseIf m_ExplicitDataReceive.Length >= 4 Then
                        '' update Pressure
                        If m_ExplicitDataReceive.Length >= 4 Then
                            'read data from device and store to variable and fire message to business layer
                            Wait4ExplicitReplyMsg()

                            'check data
                            Dim old_pressure As Single = m_fPressure
                            Dim old_IsOn As Boolean = m_bIsOn

                            m_fPressure = BitConverter.ToSingle(m_ExplicitDataReceive, 0)

                            If m_fPressure > 10000.0 Then
                                m_fPressure = 0.0F
                            End If

                            m_bIsOn = (m_fPressure > 0)

                            SyncLock objLock
                                If m_iExplicitSendingMsgStep <> 1 AndAlso m_iExplicitSendingMsgStep <> 2 Then
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

                                If isTurningIGOff Then
                                    isTurningIGOff = False
                                    System.Threading.Thread.Sleep(1000)

                                    SetEmissionCurrent()
                                    System.Threading.Thread.Sleep(500)

                                    SetSensitivityValue()
                                End If
                            End If
                        End If
                    End If
                End If
                'update device status
                Me.GetDeviceStatus()
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
            AVPLib.Log.avpLogger.Info("Enter GP355IonGauge.SwitchIGFilament1")
            Dim blResult As Boolean = False
            Try
                m_iExplicitSendingMsgStep = 4
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave GP355IonGauge.SwitchIGFilament1")
            Return blResult
        End Function

        ''' <summary>
        ''' Switch IG Filament 2
        ''' </summary>
        Public Overrides Function SwitchIGFilament2() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GP355IonGauge.SwitchIGFilament2")
            Dim blResult As Boolean = False
            Try
                m_iExplicitSendingMsgStep = 5
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave GP355IonGauge.SwitchIGFilament2")
            Return blResult
        End Function

        ''' <summary>
        ''' Turn On IG
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overrides Function TurnOnIG() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GP355IonGauge.TurnIGOn")
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
            AVPLib.Log.avpLogger.Info("Leave GP355IonGauge.TurnIGOn")
            Return blResult
        End Function

        ''' <summary>
        ''' Turn OFF IG
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overrides Function TurnOffIG() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GP355IonGauge.TurnIGOff")
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
            AVPLib.Log.avpLogger.Info("Leave GP355IonGauge.TurnIGOff")
            Return blResult
        End Function

        ''' <summary>
        ''' Turn On IG
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overrides Function TurnOnIGDegas() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GP355IonGauge.TurnIGDegasOn")
            Dim blResult As Boolean = False
            Try
                isExpectedTurnIGDegasOn = True

                m_iExplicitSendingMsgStep = 3

                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave GP355IonGauge.TurnIGDegasOn")
            Return blResult
        End Function

        ''' <summary>
        ''' Turn On IG
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overrides Function TurnOffIGDegas() As Boolean
            AVPLib.Log.avpLogger.Info("Enter GP355IonGauge.TurnIGDegasoff")
            Dim blResult As Boolean = False
            Try
                isExpectedTurnIGDegasOn = False

                m_iExplicitSendingMsgStep = 3

                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave GP355IonGauge.TurnIGDegasoff")
            Return blResult
        End Function

        ''' <summary>
        ''' Config the current device
        ''' </summary>
        Public Overrides Sub Setup()
            Try
                ' Determine Current Emission Mode and Level
                SetEmissionCurrent()

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

                m_iExplicitSendingMsgStep = 6

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
        ''' Set Emission Current
        ''' </summary>
        Private Sub SetEmissionCurrent()
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
                ' 0.1mA
                InitialCurrent = 0.0001F
            ElseIf m_objConfig.IonGaugeEmissionCurrent = 3 Then
                bAutoCurrentEmission = False
                ' 4mA
                InitialCurrent = 0.004F
            ElseIf m_objConfig.IonGaugeEmissionCurrent = 4 Then
                bAutoCurrentEmission = True
            End If

            ' Turn off auto current
            m_ExplicitData = New Byte(1) {}
            m_ExplicitData(0) = 103
            m_ExplicitData(1) = 0

            If bAutoCurrentEmission Then
                m_ExplicitData(1) = 0
            Else
                m_ExplicitData(1) = 1
            End If

            SendExplicitMessage(&H10, &H31, &H1) ' Set Service, Class Code = 49, Class Instance = 1
            Wait4ExplicitReplyMsg(TIME_OUT)

            ' Only Set when Emission Current Mode is Manual
            If False = bAutoCurrentEmission Then
                ' Set Emission Current Attribute
                Dim byteVal() As Byte = BitConverter.GetBytes(InitialCurrent)
                '0014316: [KhoiHa - 01/28/2018] [IG 355] Wrong to set Emission Current to Device
                'byteVal(2) = &HAC ' Adjust
                m_ExplicitData = New Byte(4) {}
                m_ExplicitData(0) = 91 ' Emission Current Attribute
                m_ExplicitData(1) = byteVal(0)
                m_ExplicitData(2) = byteVal(1)
                m_ExplicitData(3) = byteVal(2)
                m_ExplicitData(4) = byteVal(3)
                SendExplicitMessage(&H10, &H31, &H1) ' Set Service, Class Code = 49, Class Instance = 1
                Wait4ExplicitReplyMsg(TIME_OUT)
            End If
        End Sub

        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2018-12-28</date>
        ''' </author>
        ''' <summary>
        ''' Set Sensitivity Value
        ''' </summary>
        Private Sub SetSensitivityValue()
            Dim sValue As Integer = 24
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
        End Sub
    End Class
End Namespace
