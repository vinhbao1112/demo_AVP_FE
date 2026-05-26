Imports AVPLib.ConstEnum
Namespace Driver
    Public Class PumpPackageDriver
        Inherits ProxyDriverObject
        Implements IPumpPackageDriver

        ''' <summary>
        ''' PumpPackageDriver constructor
        ''' </summary>
        Public Sub New(ByVal sDriverName As String, ByVal eCommunicationType As CommType, ByVal eDeviceType As DeviceType, ByVal eModel As String)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Initialize(sDriverName, eCommunicationType, eDeviceType, eModel)
        End Sub

        ''' <summary>
        ''' PumpPackageDriver constructor
        ''' </summary>
        Public Sub New(ByVal sDriverName As String, ByVal eCommunicationType As CommType, ByVal eDeviceType As DeviceType)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Initialize(sDriverName, eCommunicationType, eDeviceType, String.Empty)
        End Sub

        Private Sub Initialize(ByVal sDriverName As String, ByVal eCommunicationType As CommType, ByVal eDeviceType As DeviceType, Optional ByVal eModel As String = "")
            Select Case eCommunicationType
                Case CommType.Serial
                    If eDeviceType = DeviceType.Cryo Then
                        proxyObject = New SerialCryoDriver(sDriverName)
                        proxyObject.EquipmentName = sDriverName
                    ElseIf eDeviceType = DeviceType.Turbo Then

                        Dim lSetPointFrequency As Double = 963

                        'Type Driver and Type Turbo SetPoint Frequency
                        If sDriverName = DriverConst.LLAPumpPackage Then
                            lSetPointFrequency = AVPLib.ContainerDAO.LLATurboSetPoinFrequency
                            RobotConfigurationValues.IS_LLATURBO_SERIAL = True
                        ElseIf sDriverName = DriverConst.TMPumpPackage Then
                            lSetPointFrequency = AVPLib.ContainerDAO.TMTurboSetPoinFrequency
                            RobotConfigurationValues.IS_TMTURBO_SERIAL = True
                        End If

                        'turbo serial Labol MAG or Labol 350
                        If eModel = TurboModel.LeboldMAG.ToString() OrElse eModel = TurboModel.Lebold350ix.ToString() Then
                            Dim turboDriver As New SerialLeboldMAGTurboDriver(sDriverName, lSetPointFrequency)
                            turboDriver.EquipmentName = sDriverName
                            proxyObject = turboDriver
                        Else 'turbo serial other
                            Dim turboDriver As New SerialTurboDriver(sDriverName, lSetPointFrequency)
                            turboDriver.EquipmentName = sDriverName
                            proxyObject = turboDriver
                        End If
                    End If
                Case CommType.Kepware
                    If eDeviceType = DeviceType.Cryo Then
                        AVPLib.Log.coreLogger.Error("KepwareCryoDriver hasn't been supported")
                    ElseIf eDeviceType = DeviceType.Turbo Then
                        Dim turboDriver As New KepwareTurboDriver(sDriverName)
                        proxyObject = turboDriver
                    End If
                Case CommType.DeviceNet
                    proxyObject = New DeviceNetTurboDriver(sDriverName)
                Case CommType.RSTi_Serial
                    Dim lSetPointFrequency As Double = 0

                    'Type Driver and Type Turbo SetPoint Frequency
                    If sDriverName = DriverConst.LLAPumpPackage Then
                        lSetPointFrequency = AVPLib.ContainerDAO.LLATurboSetPoinFrequency
                        RobotConfigurationValues.IS_LLATURBO_RSTi_SERIAL = True
                    ElseIf sDriverName = DriverConst.TMPumpPackage Then
                        lSetPointFrequency = AVPLib.ContainerDAO.TMTurboSetPoinFrequency
                        RobotConfigurationValues.IS_TMTURBO_RSTi_SERIAL = True
                    End If
                    ' new RSTi Serial
                    If eModel = TurboModel.Lebold350ix.ToString() Then
                        Dim turboDriver As New RSTiSerialLebold350ixTurboDriver(sDriverName, lSetPointFrequency)
                        turboDriver.EquipmentName = sDriverName
                        proxyObject = turboDriver
                    End If
                Case Else
                    AVPLib.Log.coreLogger.Error("New wrong type")
            End Select
        End Sub

        ''' <summary>
        ''' Turn On Cryo/Turbo
        ''' </summary>
        Public Function TurnOn() As Boolean Implements IPumpPackageDriver.TurnOn
            AVPLib.Log.avpLogger.Info("Enter PumpPackageDriver.TurnOn")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IPumpPackageDriver).TurnOn
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave PumpPackageDriver.TurnOn")
            Return blResult
        End Function

        ''' <summary>
        ''' Turn Off Cryo/Turbo
        ''' </summary>
        Public Function TurnOff() As Boolean Implements IPumpPackageDriver.TurnOff
            AVPLib.Log.avpLogger.Info("Enter PumpPackageDriver.TurnOff")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IPumpPackageDriver).TurnOff
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave PumpPackageDriver.TurnOff")
            Return blResult
        End Function

        ''' <summary>
        ''' Start Fast Regen
        ''' </summary>
        Public Function StartFastRegen() As Boolean Implements IPumpPackageDriver.StartFastRegen
            AVPLib.Log.avpLogger.Info("Enter PumpPackageDriver.StartFastRegen")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IPumpPackageDriver).StartFastRegen
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave PumpPackageDriver.StartFastRegen")
            Return blResult
        End Function

        ''' <summary>
        ''' Start Regen
        ''' </summary>
        Public Function StartRegen() As Boolean Implements IPumpPackageDriver.StartRegen
            AVPLib.Log.avpLogger.Info("Enter PumpPackageDriver.StartRegen")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IPumpPackageDriver).StartRegen
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave PumpPackageDriver.StartRegen")
            Return blResult
        End Function

        ''' <summary>
        ''' Stop Regen
        ''' </summary>
        Public Function StopRegen() As Boolean Implements IPumpPackageDriver.StopRegen
            AVPLib.Log.avpLogger.Info("Enter PumpPackageDriver.StopRegen")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IPumpPackageDriver).StopRegen
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave PumpPackageDriver.StopRegen")
            Return blResult
        End Function

        ''' <summary>
        ''' Extended Purge Time
        ''' </summary>
        Public Function CryoSetExtendedPurgeTime(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetExtendedPurgeTime
            AVPLib.Log.avpLogger.Info("Enter PumpPackageDriver.CryoSetExtendedPurgeTime")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IPumpPackageDriver).CryoSetExtendedPurgeTime(strVal)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave PumpPackageDriver.CryoSetExtendedPurgeTime")
            Return blResult
        End Function

        ''' <summary>
        ''' Pump Restart Delay
        ''' </summary>
        Public Function CryoSetPumpRestartDelay(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetPumpRestartDelay
            AVPLib.Log.avpLogger.Info("Enter PumpPackageDriver.CryoSetPumpRestartDelay")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IPumpPackageDriver).CryoSetPumpRestartDelay(strVal)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave PumpPackageDriver.CryoSetPumpRestartDelay")
            Return blResult
        End Function

        ''' <summary>
        ''' Rate Of Rise
        ''' </summary>
        Public Function CryoSetRateOfRise(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRateOfRise
            AVPLib.Log.avpLogger.Info("Enter PumpPackageDriver.CryoSetRateOfRise")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IPumpPackageDriver).CryoSetRateOfRise(strVal)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave PumpPackageDriver.CryoSetRateOfRise")
            Return blResult
        End Function

        ''' <summary>
        ''' Repurge Cycles
        ''' </summary>
        Public Function CryoSetRepurgeCycles(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRepurgeCycles
            AVPLib.Log.avpLogger.Info("Enter PumpPackageDriver.CryoSetRepurgeCycles")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IPumpPackageDriver).CryoSetRepurgeCycles(strVal)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave PumpPackageDriver.CryoSetRepurgeCycles")
            Return blResult
        End Function

        ''' <summary>
        ''' Rough To Pressure
        ''' </summary>
        Public Function CryoSetRoughToPressure(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRoughToPressure
            AVPLib.Log.avpLogger.Info("Enter PumpPackageDriver.CryoSetRoughToPressure")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IPumpPackageDriver).CryoSetRoughToPressure(strVal)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave PumpPackageDriver.CryoSetRoughToPressure")
            Return blResult
        End Function

        ''' <summary>
        ''' Start Up Temperature
        ''' </summary>
        Public Function CryoSetStartUpTemp(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetStartUpTemp
            AVPLib.Log.avpLogger.Info("Enter PumpPackageDriver.CryoSetStartUpTemp")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IPumpPackageDriver).CryoSetStartUpTemp(strVal)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave PumpPackageDriver.CryoSetStartUpTemp")
            Return blResult
        End Function

        Public Overrides Sub Dispose()
            If (proxyObject IsNot Nothing) Then
                proxyObject.Dispose()
            End If
        End Sub
    End Class
End Namespace
