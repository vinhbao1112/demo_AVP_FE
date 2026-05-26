Namespace Driver
    Public Class IGDriver
        Inherits ProxyDriverObject
        Implements IIGDriver
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Initialize All Driver
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.Serial
                    proxyObject = New SerialIGDriver(sDriverName)
                Case CommType.Kepware
                    proxyObject = New KepwareIGDriver(sDriverName)
                Case Else
                    AVPLib.Log.avpLogger.Error("New Wrong Object Type")
            End Select
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Only used for new device net object
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType, _
                        ByVal sMacID As String)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.DeviceNet
                    If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                        proxyObject = New DeviceNetAppIGDriver(sDriverName, Convert.ToUInt16(sMacID))
                    Else
                        Dim SystemDevice As SystemModule = Nothing
                        If sDriverName.Contains(ConstEnum.LoadLockA_STR) Then
                            SystemDevice = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.LoadLockA.ToString())                       
                        End If

                        If sDriverName.Contains(ConstEnum.CassettesModule_STR) Then
                            SystemDevice = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Robot.ToString())
                        End If

                        If SystemDevice IsNot Nothing AndAlso SystemDevice.IonGaugeType = DeviceNetIGCGType.GP355.ToString() Then
                            proxyObject = New DNSGP355IonGauge(sDriverName, Convert.ToUInt16(sMacID))
                        Else
                            'Default is GP 354 ION GAUGE
                            proxyObject = New DNSGP354IonGauge(sDriverName, Convert.ToUInt16(sMacID))
                        End If
                        End If
                Case Else
                        AVPLib.Log.avpLogger.Error("New Wrong Object Type")
            End Select
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Only used for new device net object
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType, ByVal sMacID As String, _
                        ByVal eDeviceNetIGType As DeviceNetIGCGType)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.DeviceNet
                    If (eDeviceNetIGType = DeviceNetIGCGType.GP354) Then
                        proxyObject = New DNSGP354IonGauge(sDriverName, Convert.ToUInt16(sMacID))
                    ElseIf (eDeviceNetIGType = DeviceNetIGCGType.GP355) Then
                        proxyObject = New DNSGP355IonGauge(sDriverName, Convert.ToUInt16(sMacID))
                    Else
                        AVPLib.Log.avpLogger.Error("Not Implement yet")
                    End If
                Case Else
                    AVPLib.Log.avpLogger.Error("New Wrong Driver")
            End Select
        End Sub

        Public Function SwitchIGFilament1() As Boolean Implements IIGDriver.SwitchIGFilament1
            If proxyObject IsNot Nothing Then
                Return CType(proxyObject, IIGDriver).SwitchIGFilament1
            End If
        End Function
        Public Function SwitchIGFilament2() As Boolean Implements IIGDriver.SwitchIGFilament2
            If proxyObject IsNot Nothing Then
                Return CType(proxyObject, IIGDriver).SwitchIGFilament2
            End If
        End Function
        Public Function TurnOffIG() As Boolean Implements IIGDriver.TurnOffIG
            If proxyObject IsNot Nothing Then
                Return CType(proxyObject, IIGDriver).TurnOffIG
            End If
        End Function
        Public Function TurnOnIG() As Boolean Implements IIGDriver.TurnOnIG
            If proxyObject IsNot Nothing Then
                Return CType(proxyObject, IIGDriver).TurnOnIG
            End If
        End Function
        Public Function TurnOffIGDegas() As Boolean Implements IIGDriver.TurnOffIGDegas
            If proxyObject IsNot Nothing Then
                Return CType(proxyObject, IIGDriver).TurnOffIGDegas
            End If
        End Function
        Public Function TurnOnIGDegas() As Boolean Implements IIGDriver.TurnOnIGDegas
            If proxyObject IsNot Nothing Then
                Return CType(proxyObject, IIGDriver).TurnOnIGDegas
            End If
        End Function
        Public ReadOnly Property IGPressure() As Single Implements IIGDriver.IGPressure
            Get
                If (proxyObject IsNot Nothing And m_CommType = CommType.Kepware) Then
                    Return CType(proxyObject, KepwareIGDriver).TurnOnIGDegas
                Else
                    Return -1
                End If
            End Get
        End Property
    End Class
End Namespace
