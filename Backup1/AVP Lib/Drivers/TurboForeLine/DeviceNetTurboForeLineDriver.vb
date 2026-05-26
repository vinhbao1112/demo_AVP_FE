Namespace Driver
    Public Class DeviceNetTurboForeLineValveDriver
        Inherits DeviceNetValveDriver
        '''' <summary>
        '''' Init Turbo fore line valve Component
        '''' </summary>
        '''' <returns></returns>
        'Public Function Intialize() As Boolean
        '    AVPLib.Log.avpLogger.Info("Enter DeviceNetTurboForeLineValveDriver.Intialize")
        '    Dim blResult As Boolean = False
        '    Try

        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Info(ex.Message)
        '    End Try
        '    AVPLib.Log.avpLogger.Info("Leave DeviceNetTurboForeLineValveDriver.Intialize")
        '    Return blResult
        'End Function


        Public Sub New(ByVal sDriverName As String, ByVal MacID As String, ByVal solenoidBitIndex As String)
            MyBase.new(sDriverName)
            m_SolenoidBitIndex = solenoidBitIndex
            MyBase.objSolenoidDriver = AVPLib.DeviceNet.DNSScanner.objSolenoidBlock(Convert.ToInt32(MacID))
        End Sub
        'get all value, status send to AVP
        Public Overrides Sub Poll()
            Try
                Dim PreState As Boolean = CurrentState
                CurrentState = m_SolenoidDriver.GetState(1 << m_SolenoidBitIndex)
                If (PreState <> CurrentState) Then
                    'Current state = True = ON
                    If (CurrentState) Then
                        DriverUtility.UpdateTurboForeLineValveStatus(Me.EquipmentName, DataManagerment.Equipment.WorkingStatuses.On)
                    Else 'Current state = False = OFF
                        DriverUtility.UpdateTurboForeLineValveStatus(Me.EquipmentName, DataManagerment.Equipment.WorkingStatuses.Off)
                    End If
                    PreState = CurrentState
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub
    End Class

    Public Class DeviceNetTurboForeLineDriver
        Inherits DeviceNetCGDriver
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' New obj and macID with Device Name = DeviceConfig.xml
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDeviceName As String, ByVal MacID As String)
            MyBase.New(sDeviceName)
            Try
                m_DeviceConfig.MacId = Convert.ToUInt16(MacID)
                m_arrPressVal = New Byte(3) {}
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' m_hCardHandle = DNSScanner.CardHandle
        ''' macID = read from file
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Initialize() As Boolean
            Return RegisterEquipment(m_hCardHandle, 5, 0, 64)
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Update to GUI
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub UpdateGetCGRelay()
            Dim oldCGRelay As DataManagerment.Equipment.WorkingStatuses = m_CGRelay
            GetCGRelay()
            If (oldCGRelay <> m_CGRelay Or Not m_IsInitialized) Then
                DriverUtility.UpdateTurboForeLineCGRelay(EquipmentName, m_CGRelay)
                m_IsInitialized = True
            End If
        End Sub

        Public Overrides Sub UpdateDeviceCommunication()
            Dim old_comm As Boolean = m_Communication
            m_Communication = IsDeviceActive()
            If (old_comm <> m_Communication) Then 'Or Not m_IsUpdateCommunicationError) Then
                If (m_Communication) Then
                    DriverUtility.UpdateTurboForelineCG_Communication(EquipmentName, AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                Else
                    DriverUtility.UpdateTurboForelineCG_Communication(EquipmentName, AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                    m_fPressure = 0.0
                End If
                'm_IsUpdateCommunicationError = True
            End If
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' m_hCardHandle = DNSScanner.CardHandle
        ''' macID = read from file
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Poll()
            Try
                Me.GetDeviceStatus()
                UpdateDeviceCommunication()
                If Me.ReadData() Then
                    If m_DeviceConfig.Input1Size = 5 Then
                        Dim old_pressure As Single = m_fPressure
                        Dim old_communication As Boolean = m_Communication

                        m_arrPressVal(0) = m_arrBuffer(1)
                        m_arrPressVal(1) = m_arrBuffer(2)
                        m_arrPressVal(2) = m_arrBuffer(3)
                        m_arrPressVal(3) = m_arrBuffer(4)

                        m_fPressure = BitConverter.ToSingle(m_arrPressVal, 0)

                        If m_fPressure < 0.001F Then
                            m_fPressure = 0.001F
                        End If

                        If (m_fPressure <> old_pressure) Then
                            DriverUtility.UpdateTurboForeLineCGPressure(EquipmentName, m_fPressure)
                            AVPLib.Log.avpLogger.Debug(EquipmentName & ": " & m_fPressure)
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
