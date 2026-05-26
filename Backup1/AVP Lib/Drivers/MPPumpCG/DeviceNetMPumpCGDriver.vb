Namespace Driver
    Public Class DeviceNetMPumpCGDriver
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
        ''' m_hCardHandle = DNSScanner.CardHandle
        ''' macID = read from file
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Poll()
            Try
                Me.GetDeviceStatus()

                If m_DeviceStatus IsNot Nothing Then
                    UpdateDeviceCommunication()

                    If Me.ReadData() Then
                        If m_DeviceConfig.Input1Size = 5 Then

                            Dim old_pressure As Single = m_fPressure

                            m_arrPressVal(0) = m_arrBuffer(1)
                            m_arrPressVal(1) = m_arrBuffer(2)
                            m_arrPressVal(2) = m_arrBuffer(3)
                            m_arrPressVal(3) = m_arrBuffer(4)

                            m_fPressure = BitConverter.ToSingle(m_arrPressVal, 0)

                            If m_fPressure < 0.001F Then
                                m_fPressure = 0.001F
                            End If

                            If (old_pressure <> m_fPressure) Then
                                DriverUtility.UpdateCGPressure(EquipmentName, m_fPressure)
                                AVPLib.Log.avpLogger.Debug(EquipmentName & ": " & m_fPressure)
                            End If

                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub
    End Class
End Namespace